/* 
 * GMP
 * 20/05/2015
 * Revisión windows.open, agregué reloj de espera, validación de fecha, no hay descargas excel
 * 
 */

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


public partial class mod_ninos_ninos_visitados : System.Web.UI.Page
{
    private static Dictionary<string, int> grd001_hash_map = new Dictionary<string, int>();//gfontbrevis usado para actualizar icono ok

    public DataSet DVNinos
    {
        get { return (DataSet)Session["DVNinos"]; }
        set { Session["DVNinos"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            //CalendarExtende1091.StartDate = Convert.ToDateTime("01-01-1900");
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("749D2D91-2F3C-4AEE-9148-42B94C4A53CA"))
                {
                    Response.Redirect("autenticacion.aspx");
                }

                getinstituciones();
                getproyectosxcod();

                // esto ya no se usa: reemplazado por AIO
                if (Request.QueryString["sw"] == "3")
                {
                  ddown001.SelectedValue = Request.QueryString["codinst"];
                  getproyectosxcod();
                }
                else if (Request.QueryString["sw"] == "4")
                {
                  buscador_institucion bsc = new buscador_institucion();
                  int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                  ddown001.SelectedValue = Convert.ToString(codinst);
                  getproyectosxcod();
                  ddown002.SelectedValue = Request.QueryString["codinst"];
                  funcion_dd002();
                  Session["NNA"] = null;

                }
                CalendarExtende1091.EndDate = DateTime.Now;
                getinstituciones();

                if (Session["NNA"] != null)
                {
                  oNNA NNA = (oNNA)Session["NNA"];

                  ddown001.SelectedValue = NNA.NNACodInstitucion;
                  getproyectosxcod();
                  ddown002.SelectedValue = NNA.NNACodProyecto;
                  funcion_dd002();
                }
                
                validatescurity();
            }
        }
        Session["vsdir"] = "../mod_ninos/ninos_visitados.aspx";
    }
    private void validatescurity()
    {
        //C625A6E1-5FAF-4A04-B7E0-4B747FD8C76F 2.10_INGRESAR
        if (!window.existetoken("C625A6E1-5FAF-4A04-B7E0-4B747FD8C76F"))
        {
            imb_guardar.Visible = false;
            grd001.Visible = false;
            //lblTitNinVigentes.Visible = false;
        }
        //5D2C7956-AC23-4CC5-9A37-A2A04FB8A029 2.10_MODIFICAR
        if (!window.existetoken("5D2C7956-AC23-4CC5-9A37-A2A04FB8A029"))
        {
            imb_actualizar.Visible = false;
        }
        //66469021-AF97-49D1-AAE9-6039810F9781 2.10_ELIMINAR
        if (!window.existetoken("66469021-AF97-49D1-AAE9-6039810F9781"))
        {
            grd003.Columns[6].Visible = false;
        }
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null) {
            NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
        }
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        Session["NNA"] = NNA;
        getproyectosxcod();

    }

    private void getproyectosxcod()
    {
        proyectocoll pcoll = new proyectocoll();
        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddown001.SelectedValue));
        DataView dv = new DataView(dtproy) ;
        dv.Sort = "CodProyecto";
        // <---------- DPL ---------->  09-08-2010
        dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
        if (dv.Count == 2)
        {
            ddown002.SelectedIndex = 1;
            ddown002_SelectedIndexChanged(new object(), new EventArgs());
        }
    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null)
        {
            NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
        }
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        NNA.NNACodProyecto = ddown002.SelectedValue;
        Session["NNA"] = NNA;
        funcion_dd002();
    }

    private void funcion_dd002()
    {
        lbl001.Visible = false;
        error.Visible = false;
        WebImageButton2.Visible = false;
        DataTable dt = new DataTable();
        grd002.DataSource = dt;
        grd002.DataBind();
        lblTitNinVisitados.Visible = false;
        pintervencion pii = new pintervencion();
        dt = pii.GetNinosProyecto(Convert.ToInt32(ddown002.SelectedValue));
        DVNinos = new DataSet();
        DVNinos.Tables.Add(dt);
        //if (txt001.Text != "")
        CargaGrilla(txt001.Text.Trim(), txtNombres.Text.Trim(), txtApeMat.Text.Trim());

        if (grd001.Rows.Count > 0)
        {
            //ddown002.Enabled = false;
            //ddown001.Enabled = false;
            txt001.Enabled = true;
            txtNombres.Enabled = true;
            txtApeMat.Enabled = true;
            //imb_guardar.Visible = true;
            imb_actualizar.Visible = false;
            grd001.Visible = true;
            Label2.Visible = true;
            LinkButton1.Visible = true;
            generarGrd001HashMap();//gfontbrevis
            if (grd001.Rows.Count > 15)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
            }
            

        }
        else
        {
            imb_guardar.Visible = false;
            imb_actualizar.Visible = false;

            //ddown002.Enabled = true;
            //ddown001.Enabled = true;

            txt001.Enabled = false;
            txtApeMat.Enabled = false;
            txtNombres.Enabled = false;
            lbl001.Visible = false;
            error.Visible = false;
            lbl001.Text = "No se han encontrado coincidencias";

            
        }
        validatescurity();
        
    }
    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();

        if (dv1.Count == 2)
        {
            ddown001.SelectedIndex = 1;
            ddown001_SelectedIndexChanged(new object(), new EventArgs());
        }
            
    }

    private void CargaGrilla(String Filtro, String nombres, String apeMat)
    {
        //DataSet dv = DVNinos;
        ////grd001.Page.Items.Clear();
        //if (Filtro.Trim() != "")
        //{
        //    dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '" + Filtro.ToUpper() + "%'";
        //}
        //else
        //{
        //    dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '%'";
        //}
        //dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        //grd001.DataSource = dv.Tables[0].DefaultView;
        //grd001.DataBind();
        //lblTitNinVigentes.Visible = (dv.Tables[0].Rows.Count > 0);

      DataSet dv = DVNinos;
      String rowFilterQuery;

      rowFilterQuery = "";

      if (Filtro.Trim() != "")
      {
        rowFilterQuery = "Apellido_paterno LIKE '%" + Filtro.ToUpper().Trim() + "%'";
      }

      if (nombres.Trim() != "")
      {
        if (rowFilterQuery.Length > 0)
          rowFilterQuery = rowFilterQuery + " and ";

        rowFilterQuery = "Nombres LIKE '%" + nombres.ToUpper().Trim() + "%'";
      
      }

      if (apeMat.Trim() != "")
      {
        if (rowFilterQuery.Length > 0)
          rowFilterQuery = rowFilterQuery + " and ";

        rowFilterQuery = "Apellido_materno like '%" + apeMat.ToUpper().Trim() + "%'";
      }

      dv.Tables[0].DefaultView.RowFilter = rowFilterQuery;
      dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
      grd001.DataSource = dv.Tables[0].DefaultView;
      grd001.DataBind();
      
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblTitVisible.Visible = false;
        grd003.Visible = false;
        funcion_dd002();
        CargaGrilla(txt001.Text.Trim(), txtNombres.Text.Trim(), txtApeMat.Text.Trim());
    }
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Agregar")
        {
            if (grd002.Rows.Count < 10)
            {
                if ((call001.Text != "Seleccione Fecha") && (call001.Text != ""))
                {
                    lbl001.Visible = false;
                    error.Visible = false;
                    WebImageButton2.Visible = false;
                    int var = 0, var2 = 0, var3=0;
                    //datetime FechaHoy = FormatDateTime(fecha.Now,vbShortDate); 

                    DateTime FechaHoy = DateTime.Now;
                                            
                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add(new DataColumn("CodNino", typeof(String)));
                    dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
                    dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
                    dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
                    imb_lupa_modal_proyecto.Attributes.Add("disabled", "true");
                    imb_lupa_modal.Attributes.Add("disabled", "true");

                    for (int i = 0; i < grd002.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr[0] = grd002.Rows[i].Cells[0].Text;
                        dr[1] = Server.HtmlDecode(grd002.Rows[i].Cells[1].Text);
                        dr[2] = Server.HtmlDecode(grd002.Rows[i].Cells[2].Text);
                        dr[3] = Server.HtmlDecode(grd002.Rows[i].Cells[3].Text);
                        dt.Rows.Add(dr);
                        
                    }

                        if (Convert.ToDateTime(Convert.ToDateTime(call001.Text).ToShortDateString()) < Convert.ToDateTime(Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text).ToShortDateString()))
                    {
                        var2 = 1;
                    }
                    if (Convert.ToDateTime(Convert.ToDateTime(call001.Text).ToShortDateString()) > Convert.ToDateTime(FechaHoy))
                    {
                        var3 = 1;
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text == grd002.Rows[i].Cells[0].Text)
                        {
                            var = 1;
                        }
                    }
                    if (var == 0 && var2 == 0 && var3 ==0)
                    {
                        dr = dt.NewRow();
                        dr[0] = Server.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);//[0]Codnino, [1] ICODIE, [2]Rut, [3] ApePaterno, [4] ApeMaterno, [5] Nombres, [6] Sexo, [7] Fecha Nac, [8] Fecha Ingreso
                        dr[1] = Server.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);//ApePaterno
                        dr[2] = Server.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);//ApeMaterno
                        dr[3] = Server.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
                        dt.Rows.Add(dr);

                        //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Visible = false;//gfontbrevis
                        lbl001.Visible = false;
                        error.Visible = false;
                        WebImageButton2.Visible = false;
                        if (dt.Rows.Count > 0)
                        {
                            
                            grd002.DataSource = dt;
                            grd002.DataBind();
                            grd002.Visible = true;
                            lblTitNinVisitados.Visible = true;
                            ddown001.Enabled = false;
                            ddown002.Enabled = false;
                            txt001.Enabled = false;
                            txtNombres.Enabled = false;
                            txtApeMat.Enabled = false;
                            LinkButton1.Visible = false;
                            Label1.Visible = true;
                            imb_guardar.Visible = true;

                        }
                        else
                        {
                            lblTitNinVisitados.Visible = false;
                        }
                    }
                    else
                    {
                        if (var2 == 1)
                        {
                            lbl001.Text = "La Fecha de Visita debe ser mayor a la de Ingreso del Niño.";
                            error.Visible = true;
                            lbl001.Visible = true;
                            error.Style.Add("display", "none");
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
                        }
                        if (var3 == 1)
                        {
                            
                            lbl001.Text = "La Fecha de Visita debe ser menor o igual a la de hoy.";
                            lbl001.Visible = true;
                            error.Visible = true;
                            error.Style.Add("display", "none");
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
                        }
                        if (var == 1)
                        {
                            lbl001.Text = "El niño seleccionado ya ha sido ingresado.";
                            lbl001.Visible = true;
                            error.Visible = true;
                            error.Style.Add("display", "none");
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
                        }




                    }

                }
                else
                {
                    lbl001.Text = "PRIMERO DEBE INGRESAR LA FECHA DE LA VISITA.";
                    lbl001.Visible = true;
                    error.Visible = true;
                    error.Style.Add("display", "none");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').delay(750).slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "loopflowHeader", "collapseFixHeaderTimeLimit();", true);
                }
            }
        }
        //gfontbrevis
        if (grd002.Rows.Count > 0)
        {
            mostrarIconoOkGrd001();
        }
        if (grd001.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
        }
    }
    private void generarGrd001HashMap()
    {
        /*gfontbrevis
         * funcion que genera hash map CodNino->N°Fila, usado para poner simbolo ok en niños ya agregados
         * TODO: se cae al cambiar de pagina.
         */
        grd001_hash_map.Clear();
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            grd001_hash_map.Add(grd001.Rows[i].Cells[0].Text, i);

        }

    }
    private void mostrarIconoOkGrd001()
    {
        /*gfontbrevis
         * llamada por command agregar y command quitar, para actualizar iconos ok segun contenido de grd002.
         */
        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            string codigo_nino = grd002.Rows[i].Cells[0].Text;
            int fila = grd001_hash_map[codigo_nino];
            grd001.Rows[fila].Cells[9].Text = "<span class='glyphicon glyphicon-ok-sign' style='color:green;' ></span>";
        }
        

    }

    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
       
        if (e.CommandName == "Quitar")
        {
            funcion_quitar(Convert.ToInt32(e.CommandArgument));
        }
        //gfontbrevis
        if (grd002.Rows.Count > 0)
        {
            mostrarIconoOkGrd001();
        }
        if (grd001.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
        }
        
    }
    
    private void funcion_quitar(int e)
    {
        CheckBox tchk001 = new CheckBox();
        CheckBox tchk002 = new CheckBox();
        CheckBox tchk003 = new CheckBox();
        CheckBox tchk004 = new CheckBox();

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataRow dr;
        dt2.Columns.Add(new DataColumn("Indice", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); 
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); 
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    
        dt.Columns.Add(new DataColumn("chk001", typeof(int))); 
        dt.Columns.Add(new DataColumn("chk002", typeof(int)));
        dt.Columns.Add(new DataColumn("chk003", typeof(int)));
        dt.Columns.Add(new DataColumn("chk004", typeof(int))); 
        
        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            
            tchk001 = (CheckBox)grd002.Rows[i].Cells[5].FindControl("chk001");
            tchk002 = (CheckBox)grd002.Rows[i].Cells[7].FindControl("chk002");
            tchk003 = (CheckBox)grd002.Rows[i].Cells[4].FindControl("chk003");
            tchk004 = (CheckBox)grd002.Rows[i].Cells[6].FindControl("chk004");
            
            dr = dt.NewRow();
            dr[0] = grd002.Rows[i].Cells[0].Text;
            dr[1] = Server.HtmlDecode(grd002.Rows[i].Cells[1].Text);
            dr[2] = Server.HtmlDecode(grd002.Rows[i].Cells[2].Text);
            dr[3] = Server.HtmlDecode(grd002.Rows[i].Cells[3].Text);
            dr[4] = Convert.ToInt32(tchk001.Checked);
            dr[5] = Convert.ToInt32(tchk002.Checked);
            dr[6] = Convert.ToInt32(tchk003.Checked);
            dr[7] = Convert.ToInt32(tchk004.Checked);
            dt.Rows.Add(dr);
            if (i != e && grd002.Rows[i].BackColor == System.Drawing.Color.Pink)
            {
               
                dr = dt2.NewRow();
                dr[0] = Convert.ToInt32(grd002.Rows[i].Cells[0].Text);
                dt2.Rows.Add(dr);

            }

        }
        dt.Rows.Remove(dt.Rows[e]);

        int r;
        int pinkRows = 0;
        for (r = 0; r < grd002.Rows.Count; r++)
        {
          if (grd002.Rows[r].BackColor == System.Drawing.Color.Pink)
          {
            pinkRows++;
          }
        }

        if (pinkRows == 1)
        {
          lbl001.Visible = false;
          if (lblErrorVerde.Visible == true)
          {
            error.Visible = true;
            lblErrorVerde.Visible = true;
            error.Style.Add("display", "none");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
          }
          else
          {
            error.Visible = false;
          }
          

        }

        
        
        grd002.DataSource = dt;
        grd002.DataBind();
        lblTitNinVisitados.Visible = (dt.Rows.Count > 0);

        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            tchk001 = (CheckBox)grd002.Rows[i].Cells[5].FindControl("chk001");
            tchk002 = (CheckBox)grd002.Rows[i].Cells[7].FindControl("chk002");
            tchk003 = (CheckBox)grd002.Rows[i].Cells[4].FindControl("chk003");
            tchk004 = (CheckBox)grd002.Rows[i].Cells[6].FindControl("chk004");
            
            tchk001.Checked = Convert.ToBoolean(dt.Rows[i][4]);
            tchk002.Checked = Convert.ToBoolean(dt.Rows[i][5]);
            tchk003.Checked = Convert.ToBoolean(dt.Rows[i][6]);
            tchk004.Checked = Convert.ToBoolean(dt.Rows[i][7]);
            grd002.Rows[i].Cells[8].Enabled = true;
            grd002.Rows[i].BackColor = System.Drawing.Color.PaleGreen;
        }
        
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            for (int j = 0; j < grd002.Rows.Count; j++)
            {
                if (Convert.ToInt32(grd002.Rows[j].Cells[0].Text) == Convert.ToInt32(dt2.Rows[i][0]))
                {
                    grd002.Rows[j].BackColor = System.Drawing.Color.Pink;
                    grd002.Rows[j].Cells[8].Enabled = true;
                    
                }
               
            }
        }
        if (grd002.Rows.Count == 0)
        {
          lbl001.Visible = false;
          error.Visible = false;
          imb_guardar.Visible = false;
          WebImageButton2.Visible = false;
          CargaGrilla(txt001.Text.Trim(), txtNombres.Text.Trim(), txtApeMat.Text.Trim());
        }

    }

    protected void imb_guardar_Click(object sender, EventArgs e)
    {
        ninocoll nic = new ninocoll();
        CheckBox tchk001 = new CheckBox();
        CheckBox tchk002 = new CheckBox();
        CheckBox tchk003 = new CheckBox();
        CheckBox tchk004 = new CheckBox();
        DateTime FechaHoy = DateTime.Now;
        DataTable dt;
        int check01 = 0, check02 = 0,check03=0,check04=0,var = 0, var2 =0 , var3=0;
        lbl001.Visible = false;
        error.Visible = false;
        lblErrorVerde.Visible = false;
        //alerts.Visible = false;
        //lblErrorRosado.Visible = false;
        //lblErrorVerde.Visible = false;


        WebImageButton2.Visible = false;
        // valida que haya seleccionado proyecto, fecha y registros
        if (ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || (call001.Text == null || call001.Text == "") || grd002.Rows.Count == 0)
        {
                string mensaje = "";
                if (ddown001.SelectedValue == "0")
                    mensaje += "Institución, ";
                if (ddown002.SelectedValue == "0")
                    mensaje += "Proyecto, ";
                if (call001.Text == null)
                    mensaje += "Fecha Registro, ";
                if (grd002.Rows.Count < 1)
                    mensaje += " Al menos un niño, ";

                if (mensaje.Substring(mensaje.Length - 2, 2) == ", ")
                {
                    mensaje = mensaje.Substring(0, mensaje.Length - 2);
                }
                lbl001.Text = "Debe seleccionar," + mensaje;
                error.Visible = true;
                lbl001.Visible = true;
                error.Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
                return;
        }

        // ---------------- valida fecha de visita
        if (Convert.ToDateTime(Convert.ToDateTime(call001.Text).ToShortDateString()) > Convert.ToDateTime(FechaHoy))
        {
            lbl001.Text = "La Fecha de Visita debe ser menor o igual a la de hoy.";
            lbl001.Visible = true;
            error.Visible = true;
            error.Style.Add("display", "none");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
            return;
        }

        // ------------------- validaciones de datos para todos los registros seleccionados
        lbl001.Text = "";
        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            //-- revisa que haya chequeado algo
            tchk001 = (CheckBox)grd002.Rows[i].Cells[5].FindControl("chk001");
            tchk002 = (CheckBox)grd002.Rows[i].Cells[7].FindControl("chk002");
            tchk003 = (CheckBox)grd002.Rows[i].Cells[4].FindControl("chk003");
            tchk004 = (CheckBox)grd002.Rows[i].Cells[6].FindControl("chk004");
            // pinta LawnGreen los que no tienen nada checkeado
            if (tchk001.Checked == false && tchk002.Checked == false && tchk003.Checked == false && tchk004.Checked == false)
            {
                grd002.Rows[i].BackColor = System.Drawing.Color.PaleGreen;
                var = 1; // = hay al menos un registro con nada checkeado
            }
            else
                grd002.Rows[i].BackColor = System.Drawing.Color.WhiteSmoke;
            //if (Convert.ToDateTime(Convert.ToDateTime(call001.Value).ToShortDateString()) < Convert.ToDateTime(Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text).ToShortDateString()))
            //{
            //    lbl001.Text = "La Fecha de Visita debe ser posterior a la de Ingreso del Niño.";
            //    lbl001.Visible = true;
            //    var2 = 1;
            //}
            // revisa que no tenga registro anterior
            dt = nic.GetNinosVisitados_Verifica(Convert.ToDateTime(call001.Text), Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(grd002.Rows[i].Cells[0].Text));
            // pinta pink los ya registrados
            if (dt.Rows.Count > 0)
            {
                grd002.Rows[i].BackColor = System.Drawing.Color.Pink;
                var2 = 1; // = hay al menos un registro ya registrado
            }
        }
        if (var == 1) // si hay al menos un registro con nada checkeado
        {
            //lbl001.Text += "Debe seleccionar al menos un tipo de Visita (verde)" + "<br />";
            lblErrorVerde.Text = "Debe Seleccionar al menos un tipo de Visita (verde)." + "<br />";
            error.Visible = true;
            //lbl001.Visible = true;
            lblErrorVerde.Visible = true;
            error.Style.Add("display", "none");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
            
        }
        if (var2 == 1) // si hay al menos un registro ya registrado
        {
            lbl001.Text += "Los Niños señalados ya estan registrados para el proyecto y la fecha seleccionada (Rosado)." + "<br />";
            error.Visible = true;
            lbl001.Visible = true;
            WebImageButton2.Visible = true;
            error.Style.Add("display", "none");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
        }
        
        if (var == 1 || var2 == 1) return; // si hay problemas con al menos un registro, sale.
      
        // si todos los registros estan correctos... los ingreso
        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            tchk001 = (CheckBox)grd002.Rows[i].Cells[5].FindControl("chk001");
            tchk002 = (CheckBox)grd002.Rows[i].Cells[7].FindControl("chk002");
            tchk003 = (CheckBox)grd002.Rows[i].Cells[4].FindControl("chk003");
            tchk004 = (CheckBox)grd002.Rows[i].Cells[6].FindControl("chk004");

            check01 = tchk001.Checked?1:0;
            check02 = tchk002.Checked?1:0;
            check03 = tchk003.Checked?1:0;
            check04 = tchk004.Checked?1:0;

            nic.Insert_NinosVisitados(Convert.ToInt32(ddown002.SelectedValue),
                Convert.ToInt32(grd002.Rows[i].Cells[0].Text), Convert.ToDateTime(call001.Text), Convert.ToInt32(Session["IdUsuario"]) /*usr*/, Convert.ToBoolean(check01),
                Convert.ToBoolean(check02), DateTime.Now,Convert.ToBoolean(check03),Convert.ToBoolean(check04));

            grd002.Rows[i].BackColor = System.Drawing.Color.WhiteSmoke;

            grd002.Rows[i].Cells[4].Enabled = false;
            grd002.Rows[i].Cells[5].Enabled = false;
            grd002.Rows[i].Cells[6].Enabled = false;
            grd002.Rows[i].Cells[7].Enabled = false;
        }
                //for (int j = 0; j < grd002.Rows.Count; j++)
                //{
                //    if (grd002.Rows[j].BackColor != System.Drawing.Color.Pink)
                //    {
                //        funcion_quitar(j);
                //     }
                //}
        grd001.Visible = false;
        grd003.Visible = false;
        lblTitVisible.Visible = false;
        //lblTitNinVigentes.Visible = false;
        LinkButton2.Visible = true;
        busca_ninosv();
        //lbl001.Visible = true;
        //error.Visible = true;
        //lbl001.Text = "Las visitas fueron ingresadas correctamente.";
        lblCorrecto.Visible = true;
        lblCorrecto.Text = "Las visitas fueron ingresadas correctamente.";
        alertCorrecto.Visible = true;
        lblTitNinVigentes.Visible = false;
        alertCorrecto.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#alertCorrecto').is(':hidden')) { $('#alertCorrecto').slideDown({ duration: 750 });$('#alertCorrecto').delay(3000).slideUp();}", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#').click();", true);
    }

    
    //protected void WebImageButton1_Click(object sender, EventArgs e)
    //{
    //    if ((call001.Text != "Seleccione Fecha") && (call001.Text != ""))
    //    {
    //        call001.BackColor = System.Drawing.Color.White;
    //        busca_ninosv();
    //    }
    //    else
    //    {
    //        call001.BackColor = System.Drawing.Color.Pink;
    //    }
    //}
    private void busca_ninosv()
    {
        lbl001.Visible = false;
        error.Visible = false;
        WebImageButton2.Visible = false;
        if (ddown001.SelectedValue != "0" && ddown002.SelectedValue != "0" && call001.Text != null)
        {
            ninocoll nic = new ninocoll();
            DataTable dt = nic.GetNinosVisitados(Convert.ToDateTime(call001.Text), Convert.ToInt32(ddown002.SelectedValue));
            CheckBox tchk001 = new CheckBox();
            CheckBox tchk002 = new CheckBox();
            CheckBox tchk003 = new CheckBox();
            CheckBox tchk004 = new CheckBox();

            grd001.Visible = false;
            //lblTitNinVigentes.Visible = false;
            grd002.Visible = false;
            lblTitNinVisitados.Visible = false;
            grd003.Visible = true;

            if (dt.Rows.Count > 0)
            {
                
                int pi;
                pi = grd003.PageIndex;
                grd003.DataSource = dt;
                grd003.DataBind();
                lblTitVisible.Visible = true;
                grd003.Visible = true;
                imb_guardar.Visible = false;
                LinkButton2.Visible = true;
                imb_actualizar.Visible = true;
                LinkButton3.Visible = false;


                for (int i = 0; i < grd003.Rows.Count; i++)
                {
                    tchk001 = (CheckBox)grd003.Rows[i].Cells[5].FindControl("chk001");
                    tchk002 = (CheckBox)grd003.Rows[i].Cells[7].FindControl("chk002");
                    tchk003 = (CheckBox)grd003.Rows[i].Cells[4].FindControl("chk003");
                    tchk004 = (CheckBox)grd003.Rows[i].Cells[6].FindControl("chk004");
                    if (Convert.ToInt32(dt.Rows[(pi*10)+i][4]) == 1)
                    {
                        tchk001.Checked = true;
                    }
                    if (Convert.ToInt32(dt.Rows[(pi * 10) + i][5]) == 1)
                    {
                        tchk002.Checked = true;
                    }
                    if (Convert.ToInt32(dt.Rows[(pi * 10) + i][10]) == 1)
                    {
                        tchk003.Checked = true;
                    }
                    if (Convert.ToInt32(dt.Rows[(pi * 10) + i][11]) == 1)
                    {
                        tchk004.Checked = true;
                    }

                    int comp = nic.GetNinosVisitados_VerifCierre(Convert.ToDateTime(call001.Text),
                        Convert.ToInt32(ddown002.SelectedValue));
                    if (comp > 0)
                    {
                        grd003.Rows[(pi * 10) + i].Enabled = false;

                    }
                }
                if (grd003.Rows.Count > 15)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd003', '#tableHeader3','#tableContainer3',1);", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd003', '1' );", true);
                }
                validatescurity();
               
            }
            else
            {
                grd003.Visible = false;
                lblTitVisible.Visible = false;

            }
        }
        else
        {

            mensaje_error();

        }
        
    }

    protected void imb_limpiar_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        grd002.DataSource = dt;
        grd002.DataBind();
        lblTitNinVisitados.Visible = false;
        //call001.MinDate = Convert.ToDateTime("01-01-1900");
       
       // Session.Clear();
        //ddown001.SelectedIndex = 0;
        //ddown002.SelectedIndex = 0;

        txt001.Text = "";
        call001.Text = null;
        grd001.Visible = true;
        grd001.PageIndex  = 0 ;
        grd002.Visible = false;
        grd001.Visible = false;
        //lblTitNinVigentes.Visible = false;
        grd003.Visible = false;
        lblTitVisible.Visible = false;
        lbl001.Text = "";
        lbl001.Visible = false;
        error.Visible = false;
        WebImageButton2.Visible = false;
        LinkButton2.Visible = true;
        txt001.Text = "";
        imb_actualizar.Visible = false;
        imb_guardar.Visible = false;
        imb_limpiar.Visible = false;
        
        

    }
    protected void imb_actualizar_Click(object sender, EventArgs e)
    {
        lbl001.Visible = false;
        error.Visible = false;
        WebImageButton2.Visible = false;
        ninocoll nic = new ninocoll();
        CheckBox tchk001 = new CheckBox();
        CheckBox tchk002 = new CheckBox();
        CheckBox tchk003 = new CheckBox();
        CheckBox tchk004 = new CheckBox();
        int check01 = 0, check02 = 0, check03 = 0, check04 = 0;
        if (ddown001.SelectedValue != "0" && ddown002.SelectedValue != "0" && call001.Text != null && grd003.Rows.Count > 0)
        {
            for (int i = 0; i < grd003.Rows.Count; i++)
            {
                tchk001 = (CheckBox)grd003.Rows[i].Cells[5].FindControl("chk001");
                tchk002 = (CheckBox)grd003.Rows[i].Cells[7].FindControl("chk002");
                tchk003 = (CheckBox)grd003.Rows[i].Cells[4].FindControl("chk003");
                tchk004 = (CheckBox)grd003.Rows[i].Cells[6].FindControl("chk004");

                check01 = tchk001.Checked ? 1 : 0;
                check02 = tchk002.Checked ? 1 : 0;
                check03 = tchk003.Checked ? 1 : 0;
                check04 = tchk004.Checked ? 1 : 0;

                nic.Update_NinosVisitados(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(grd003.Rows[i].Cells[0].Text),
                    Convert.ToDateTime(call001.Text), Convert.ToInt32(Session["IdUsuario"]) /*usr*/, Convert.ToBoolean(check01), Convert.ToBoolean(check02), DateTime.Now,
                    Convert.ToBoolean(check03), Convert.ToBoolean(check04));

            }
            //lbl001.Text = "Las visitas fueron actualizadas correctamente.";
            lblCorrecto.Text = "Las visitas fueron actualizadas correctamente.";
            alertCorrecto.Visible = true;
            lblCorrecto.Visible = true;
            alertCorrecto.Style.Add("display", "none");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#alertCorrecto').is(':hidden')) { $('#alertCorrecto').slideDown({ duration: 750 });$('#alertCorrecto').delay(3000).slideUp();}", true);
            //lbl001.Visible = true;
            //error.Visible = true;
        }
        else
        {
            mensaje_error();

        }
        if (grd003.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd003', '#tableHeader3','#tableContainer3',1);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd003', '1' );", true);
        }
    }
    private void mensaje_error()
    {
        string mensaje = "";
        if (ddown001.SelectedValue == "0")
            mensaje += "Institución, ";
        if (ddown002.SelectedValue == "0")
            mensaje += "Proyecto, ";
        if (call001.Text == null)
            mensaje += "Fecha Registro, ";
        if (grd002.Rows.Count < 1)
            mensaje += " Al menos un niño, ";

        if (mensaje.Substring(mensaje.Length - 2, 2) == ", ")
        {
            mensaje = mensaje.Substring(0, mensaje.Length - 2);
        }
        lbl001.Text = "Debe seleccionar," + mensaje;
        lbl001.Visible = true;
        error.Visible = true;
        error.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 750);", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);

    }
    
    protected void grd001_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla(txt001.Text.Trim(), txtNombres.Text.Trim(), txtApeMat.Text.Trim());
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        grd002.DataSource = dt;
        grd002.DataBind();
        WebImageButton2.Visible = false;
        lblTitNinVisitados.Visible = false;
        lbl001.Visible = false;
        error.Visible = false;
        imb_guardar.Visible = false;
        CargaGrilla(txt001.Text.Trim(), txtNombres.Text.Trim(), txtApeMat.Text.Trim());
    }
    
    protected void call001_ValueChanged(object sender, EventArgs e)
    {
       
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        funcion_dd002();
        LinkButton2.Visible = false;
        grd003.Visible = false;
        lblTitVisible.Visible = false;
        LinkButton3.Visible = true;
    }
    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            ninocoll nic = new ninocoll();
            if (ddown001.SelectedValue != "0" && ddown002.SelectedValue != "0" && call001.Text != null)
            {
                nic.delete_ninosvisitados(Convert.ToInt32(ddown002.SelectedValue),
                Convert.ToInt32(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text),
                Convert.ToDateTime(call001.Text));
                //lbl001.Visible = true;
                //lbl001.Text = "Se ha eliminado una visita";
                lblCorrecto.Text = "Se ha eliminado una visita";
                alertCorrecto.Visible = true;
                alertCorrecto.Style.Add("display", "none");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#alertCorrecto').is(':hidden')) { $('#alertCorrecto').slideDown({ duration: 750 });$('#alertCorrecto').delay(3000).slideUp();}", true);
                //error.Visible = true;
                //error.Style.Add("display", "none");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "if ($('#error').is(':hidden')) { $('#error').slideDown({ duration: 750 });$('#error').delay(3000).slideUp();}", true);
                busca_ninosv();
            }
            else
            {
                mensaje_error();
            }
        }
        if (grd003.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd003', '#tableHeader3','#tableContainer3',1);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd003', '1' );", true);
        }
    }
    protected void grd003_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd003.PageIndex = e.NewPageIndex;
        busca_ninosv();
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if ((call001.Text != "Seleccione Fecha") && (call001.Text != ""))
        {
            call001.BackColor = System.Drawing.Color.White;
            busca_ninosv();
            Label2.Visible = false;
        }
        else
        {
            call001.BackColor = System.Drawing.Color.Pink;
        }
    }
    protected void imb_lupa_modal_proyecto_Click(object sender, EventArgs e)
    {
      string etiqueta = "Busca Proyectos";
      window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_visitados.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
      //ddown001.SelectedIndex = 0;
      //ddown002.SelectedIndex = 0;
      lblTitVisible.Visible = false;
      ddown001.Enabled = true;  
      ddown002.Enabled = true;
      txt001.Text = "";
      txt001.Enabled = false;
      txtNombres.Text = "";
      txtNombres.Enabled = false;
      txtApeMat.Text = "";
      txtApeMat.Enabled = false;
      grd001.Visible = false;
      LinkButton1.Visible = true;
      grd002.Visible = false;
      grd003.Visible = false;
      imb_actualizar.Visible = false;
      imb_guardar.Visible = false;
      imb_limpiar.Visible = false;
      lbl001.Visible = false;
      error.Visible = false;
      lblErrorVerde.Visible = false;
      alertCorrecto.Visible = false;
      call001.Text = "";
      alertCorrecto.Visible = false;
      lblCorrecto.Visible = false;
      lblCorrecto.Text = "";
      Label1.Visible = false;
      Label2.Visible = false;
      imb_lupa_modal_proyecto.Attributes.Remove("disabled");
      imb_lupa_modal.Attributes.Remove("disabled");
    }


    protected void rv_fecha_Init(object sender, EventArgs e)
    {
      ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
      ((RangeValidator)sender).MinimumValue = "01-01-1900";
    }
   
}
