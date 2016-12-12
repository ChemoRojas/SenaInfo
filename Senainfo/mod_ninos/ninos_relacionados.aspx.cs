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
using System.Data.Common;

public partial class mod_ninos_ninos_relacionados2 : System.Web.UI.Page
{
    public DataSet DVNinos
    {
        get { return (DataSet)ViewState["DVNinos"]; }
        set { ViewState["DVNinos"] = value; }
    }
    public DataTable DtBusqueda
    {
        get { return (DataTable)Session["DtBusqueda"]; }
        set { Session["DtBusqueda"] = value; }
    }

    string SParametrosConsultas = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!window.existetoken("61736ABB-4B02-4DA0-AD99-C5C7114DBB5D"))
            {
                Response.Redirect("autenticacion.aspx");
            }
            getinstituciones();
           // getproyectos();
            gettiporelacionnino();

            if (Request.QueryString["sw"] == "3")
            {
                ddown001.SelectedValue = Request.QueryString["codinst"];
                getproyectos();
            }else if (Request.QueryString["sw"] == "4")
            {
                buscador_institucion bsc = new buscador_institucion();
                int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                ddown001.SelectedValue = Convert.ToString(codinst);
                getproyectos();
                ddown002.SelectedValue = Request.QueryString["codinst"];
                funcion_ninos();
            }

            if (ddown002.Items.Count > 1)
            {
                funcion_ninos();
            }
            validatescurity();
        }
    }
    private void validatescurity()
    {
        //9DBC19F1-1053-47B3-9D35-F12FEB3AB649 2.9_INGRESAR
        if (!window.existetoken("9DBC19F1-1053-47B3-9D35-F12FEB3AB649"))
        {
            btn_guardar.Visible = false;
            pnl001.Visible = false;
        }
        //330DC7B0-1ADA-4F24-AA77-1B84AFE5595E 2.9_MODIFICAR
        if (!window.existetoken("330DC7B0-1ADA-4F24-AA77-1B84AFE5595E"))
        {
            btn_actualizar.Visible = false;
            grd005.Columns[7].Visible = false;
        }

        //
    }
    private void gettiporelacionnino()
    {
        ninocoll nic = new ninocoll();
        DataTable dt = nic.GetparTipoRelacionNinos();
        ddown005.DataSource = dt;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "TipoRelacion";
        ddown005.DataBind();


    }

    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        dv1.Sort = "Nombre";
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        ddown001.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dv1.Count > 0)
        {
            ddown001.SelectedIndex = 1;
            ddown001_SelectedIndexChanged(new object(), new EventArgs());
        }
        // <---------- DPL ---------->  09-08-2010
        
    }
    private void getproyectos()
    {
        proyectocoll pcoll = new proyectocoll();
        DataView dv2 = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        //DataTable dtproy =
        dv2.Sort = "Nombre";
        //ddown002.DataSource = dtproy;
        // <---------- DPL ---------->  09-08-2010
        dv2.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
        if (dv2.Count == 2)
        {
            ddown002.SelectedIndex = 1;
            ddown002_SelectedIndexChanged(new object(), new EventArgs());
        }
    }
  
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_relacionados.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_relacionados.aspx", "Buscador", false, true, 770, 420, false, false, true);

    }
    protected void WebImageButton1_Click1(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CargaGrilla(txt001.Text.Trim());
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    private void funcion_ninos()
    {
        pintervencion pii = new pintervencion();
        DataTable dt = pii.GetNinosProyecto(Convert.ToInt32(ddown002.SelectedValue));
        DVNinos = new DataSet();

        DVNinos.Tables.Add(dt);

        //CodProyecto = tddown002.SelectedValue;
        //CodInstitucion = tddown001.SelectedValue;
      
        CargaGrilla(txt001.Text.Trim());

        if (grd001.Rows.Count > 0)
        {
            grd001.Visible = true;
            ddown002.Enabled = false;
            ddown001.Enabled = false;
            txt001.Enabled = true;
            

        }
        else
        {

            ddown002.Enabled = true;
            ddown001.Enabled = true;
            txt001.Enabled = false;
        }
        
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        funcion_ninos();
    }
    private void CargaGrilla(String Filtro)
    {
        DataSet dv = DVNinos;
        grd001.DataSource = null;
        grd001.DataBind();

        if (Filtro.Trim() != "")
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '" + Filtro.ToUpper() + "%'";
            //dv.RowFilter = "Apellido_paterno LIKE '" + Filtro.ToUpper() + "%'";
        }
        else
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '%'";
            //dv.RowFilter = "Apellido_paterno LIKE '%'";
        }
        dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        //dv.Sort = "Apellido_paterno";
        grd001.DataSource = dv;
        grd001.DataBind();
    }
    
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla(txt001.Text.Trim());
    }
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Agregar")
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
            dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
            dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
            dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
            dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
            dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
            dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8
            dr = dt.NewRow();
            for (int i = 0; i < grd001.Columns.Count-1; i++)
            {
                try
                {
                    dr[i] = Server.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[i].Text);
                }
                catch { }
            }
            dt.Rows.Add(dr);
            grd002.DataSource = dt;
            grd002.DataBind();
            grd002.Visible = true;
            grd001.Visible = false;
            pnl001.Visible = true;
            pnl002.Visible = true;
            imb001.Visible = false;
            imb002.Visible = false;
        
        }
        validatescurity();
    }
    
    
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        Function_Genera_String_Consulta(SParametrosConsultas);
    }
    private void Function_Genera_String_Consulta(string sParametrosConsulta)
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

        sParametrosConsulta = "Select Distinct top 201 T1.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                              "T2.FechaNacimiento, T2.CodNacionalidad From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino " +
                              "inner join Proyectos T3 On T1.CodProyecto = T3.CodProyecto ";

        string rut = txt007.Text.ToString().Substring(0, txt007.Text.ToString().Length - 1) + "-" + txt007.Text.ToString().Substring(txt007.Text.ToString().Length - 1, 1);
        if (rut.Trim() != "" || txt002.Text.Trim() != "" ||
                txt004.Text != "" || txt005.Text != "" || txt006.Text != "" || rdolist001.SelectedValue != "")
            {
                sParametrosConsulta = sParametrosConsulta + "Where ";
            }

          
            if (txt002.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T1.CodNino =@pCodNino And";

                listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txt002.Text.Trim())));
            }
            if (txt004.Text != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt004.Text + "%"));
            }
            if (txt005.Text != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt005.Text + "%"));
            }
            if (txt006.Text != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt006.Text + "%"));
            }
            if (rut.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

                listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, rut.Trim()));
            }
            if (rdolist001.SelectedValue != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Sexo =@pSexo And";

                listDbParameter.Add(Conexiones.CrearParametro("@pSexo", SqlDbType.Char, 1, rdolist001.SelectedValue));
            }

            if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            {
                sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
            }
        
        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, listDbParameter);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = true;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);
            pnl003.Visible = true;
            DtBusqueda = dt;

        }
        else if (dt.Rows.Count == 0)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);
            pnl003.Visible = true;
        }
        else if (dt.Rows.Count > 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
            pnl003.Visible = true;
        }


    }

    protected void lbl0015_Click(object sender, EventArgs e)
    {
        WebImageButton1.Visible = false;
        WebImageButton3.Visible = true;
        pnl001.Visible = false;
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        cargagrilla_busqueda();
        grd003.Visible = true;
    }
    private void cargagrilla_busqueda()
    {
        DataView dv = new DataView(DtBusqueda);
        dv.Sort = "Apellido_paterno";
        grd003.DataSource = dv;
        grd003.DataBind();
    }
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        pnl001.Visible = true;
        WebImageButton1.Visible = true;
        WebImageButton3.Visible = false;
        grd003.Visible = false;
    }

    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Agregar")
        {
            if (grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text != grd002.Rows[0].Cells[0].Text)
            {
                lbl006.Visible = false;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
                dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
                dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
                dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
                dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
                dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
                dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8
                dr = dt.NewRow();
                for (int i = 0; i < grd001.Columns.Count - 1; i++)
                {
                    dr[i] = Server.HtmlDecode(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[i].Text);
                }
                dt.Rows.Add(dr);
                grd004.DataSource = dt;
                grd004.DataBind();
                grd004.Visible = true;
                pnl001.Visible = false;
                pnl002.Visible = false;
                pnl003.Visible = false;
                pnl004.Visible = true;
            }
            else
            {
                lbl006.Text = "ERROR. EL NIÑO A RELACIONAR NO PUEDE SER EL MISMO, ELIJA OTRO.";
                lbl006.Visible = true;
            }
        }

    }
    protected void grd003_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd003.PageIndex = e.NewPageIndex;
        cargagrilla_busqueda();
    }

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        ninocoll nic = new ninocoll();
        if (ddown005.SelectedValue != "0")
        {
            lbl007.Visible = false;
            string desc = "";

            if (txt008.Text != "")
            {
                desc = txt008.Text.ToUpper();
            }
            int num = nic.Check_Existencia(Convert.ToInt32(grd002.Rows[0].Cells[0].Text), Convert.ToInt32(grd004.Rows[0].Cells[0].Text));

            if (num < 1)
            {
                lbl003.Visible = false;
                nic.insert_ninosrelacionados(Convert.ToInt32(grd002.Rows[0].Cells[0].Text), Convert.ToInt32(grd004.Rows[0].Cells[0].Text), Convert.ToInt32(Session["IdUsuario"])/*usr*/,
                                          Convert.ToInt32(ddown005.SelectedValue), desc, "V", DateTime.Now);
                funcion_limpiar();
                lnk002.Visible = true;
            }
            else
            {
                lbl003.Text = "* ESTA RELACION YA EXISTE.";
                lbl003.Visible = true;
                WebImageButton1.Visible = false;
               
            }
        }
        else
        {
            lbl007.Text = "ERROR. SELECCIONE TIPO DE RELACION.";
            lbl007.Visible = true;
        
        }

        txt004.Text = "";
        txt002.Text = "";
        txt005.Text = "";
        txt006.Text = "";
        txt007.Text = "";
        rdolist001.SelectedIndex = -1;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_ninos.aspx");
    }
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        funcion_limpiar();

    }
    private void funcion_limpiar()
    {
        ddown002.DataSource = null;
        ddown002.DataBind();
        ddown002.Items.Clear();
        ddown002.Items.Add("Seleccionar");

        ddown001.Enabled = true;
        ddown002.Enabled = true;
        pnl001.Visible = false;
        pnl002.Visible = false;
        pnl003.Visible = false;
        pnl004.Visible = false;
        grd001.Visible = false;
        grd002.Visible = false;
        grd005.Visible = false;
        imb001.Visible = true;
        imb002.Visible = true;
        txt001.Text = "";
        if (ddown001.SelectedValue != "0" && ddown002.SelectedValue != "0")
        {
            lnk002.Visible = true;
        }
    }
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            ninocoll nic = new ninocoll();
            DataTable dt = nic.get_relacionesxcodnino(Convert.ToInt32(grd002.Rows[0].Cells[0].Text));
            if (dt.Rows.Count > 0)
            {
                grd005.DataSource = dt;
                grd005.DataBind();
                grd005.Visible = true;
                pnl001.Visible = false;
                pnl002.Visible = false;
                pnl003.Visible = false;
                pnl004.Visible = false;
            }
        }
    }
    protected void grd005_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modificar")
        {

            ddown005.SelectedValue = grd005.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            txt008.Text = Server.HtmlDecode(grd005.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
            lbl004.Text = grd005.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            pnl004.Visible = true;
            grd004.Visible = false;
            btn_guardar.Visible = false;
            btn_actualizar.Visible = true;
            validatescurity();
        }
    }
    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (ddown005.SelectedValue != "0")
        {
            lbl007.Visible = false;
            ninocoll nic = new ninocoll();
            nic.Update_NinosRelacionados(Convert.ToInt32(grd002.Rows[0].Cells[0].Text),
                Convert.ToInt32(lbl004.Text), Convert.ToInt32(Session["IdUsuario"])/*USR*/, Convert.ToInt32(ddown005.SelectedValue),
                txt008.Text.ToUpper(), "V", DateTime.Now);
            funcion_limpiar();
            lnk002.Visible = true;
        }
        else
        {
            lbl007.Text = "ERROR. SELECCIONE TIPO DE RELACION.";
            lbl007.Visible = true;

        }
    }
    protected void lnk002_Click(object sender, EventArgs e)
    {
        funcion_ninos();
        lnk002.Visible = false;
    }
    protected void grd002_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grd001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
