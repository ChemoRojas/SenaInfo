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
using System.Data.Common;
using System.Drawing;

public partial class Reportes_Rep_resoluciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                getparregion();
                if (Session["CodRegion"] != null)
                    ddregion.SelectedValue = Session["CodRegion"].ToString();

                getinstituciones();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();
                //chk001.Checked = false;

                btn_excel.Visible = false;

                if (Request.QueryString["sw"] == "3")
                {
                    limpiarDatosSession();
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddproyectos_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    limpiarDatosSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    ddregion.SelectedValue = "-1";
                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                }

                // si los datos de session poseen datos, estos se asignan a los controles que correspondan
            }
        }

        //Se cargan en Session los datos utilizados
        Session["CodRegion"] = ddregion.SelectedValue;
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
        Session["CodProyecto"] = ddproyecto.SelectedValue;
    }

    private void limpiarDatosSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }

    private int validatesecurity()
    {
        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
        int val = 0;

        if (rol == "267" || rol == "265")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }

            if (ddproyecto.SelectedValue == "0")
            {
                ddproyecto.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddproyecto.BackColor = System.Drawing.Color.White; }
        }
        if (rol == "251")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }
        }

        return val;
    }
    private void limpiar()
    {
        grd001.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        
    }
    private void getparregion()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion2(Convert.ToInt32(Session["IdUsuario"])));
       
        //DataView dv1 = new DataView(par.GetparRegion());
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddregion.DataBind();

        if (dv1.Count == 3)
            ddregion.SelectedIndex = 2;
      }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetData(Convert.ToInt32(Session["IdUsuario"])));
        //DataView dv2 = new DataView(inst.GetInstitucionReporte());
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;

    }
    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();
        //DataView dv2 = new DataView(inst.GetInstitucionReportexRgn(Convert.ToInt32(ddregion.SelectedValue)));
        DataView dv2 = new DataView(inst.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;
    }
    private void getproyectoxinst()
    {
        proyectocoll proy = new proyectocoll();
        //DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        // DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        ddproyecto.DataSource = dv3;
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();

        if (dv3.Count == 2)
            ddproyecto.SelectedIndex = 1;

        //proyectocoll proy = new proyectocoll();
        ////DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        //DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        //ddproyecto.DataSource = dv3;
        //ddproyecto.DataTextField = "Nombre";
        //ddproyecto.DataValueField = "CodProyecto";
        //dv3.Sort = "CodProyecto";
        //ddproyecto.DataBind();
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
       
         int val = validatesecurity();

         if (val == 0)
         {
           

             int Vigentes = 0;
             if (chk_001.Checked)
             {
                 Vigentes = 0;
             }
             else 
             {
                 Vigentes = 1;
             }
             if (ddproyecto.SelectedValue == "0" && ddregion.SelectedValue != "0" )// && mes > 1) //SGF
             {
                 lbl_error.Visible = true;
                 alerts.Visible = true;
                 lbl_error.Text = "Debe Ingresar un proyecto";
                 chk_001.Focus();
                 return;
             }
             else
             {
                cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Vigentes);
                
             }
         }
    }
    private void cargaDTG(int region, int codinstitucion, int codproyecto,int Vigentes )
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                 con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@codproyecto",SqlDbType.Int ,4, codproyecto),
                                 con.parametros("@Vigentes",SqlDbType.Int ,4, Vigentes)
										};
        con.ejecutarProcedimiento("reporte_resoluciones_historico", parametros, out datareader);

        DataTable dt = new DataTable();//modificar datatble y grilla
        dt.Columns.Add("codProyecto");                          //0
        dt.Columns.Add("nombre", typeof(String));               //1 
        dt.Columns.Add("codinstitucion");	                    //2
        dt.Columns.Add("nombinst");		                        //3
        dt.Columns.Add("region");                               //4
        dt.Columns.Add("comuna");                               //5
        dt.Columns.Add("Tematica");                             //6
        dt.Columns.Add("Modelo");                               //7
        dt.Columns.Add("SistemaAsistencial");                   //8 
        dt.Columns.Add("TipoSubvencion");                       //9 
        dt.Columns.Add("TipoProyecto");                         //10    
        dt.Columns.Add("Departamento");                          //11
        dt.Columns.Add("numeroresolucion");                     //12
        dt.Columns.Add("anoresolucion");                        //13
        dt.Columns.Add("tipo");                                 //14
        dt.Columns.Add("materia");                              //15
        dt.Columns.Add("FechaResolucion");                      //16
        dt.Columns.Add("fechaconvenio");                        //17
        dt.Columns.Add("fechainicio");                          //18
        dt.Columns.Add("fechatermino");                         //19
        dt.Columns.Add("numeroplazas");                         //20
        dt.Columns.Add("dias_atencion");                        //21
        dt.Columns.Add("sexo");                                 //22
        dt.Columns.Add("termino");                              //23
        dt.Columns.Add("Vigencia");                             //24
        dt.Columns.Add("reporte");                              //25
        
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["codProyecto"];
                dr[1] = (System.String)datareader["nombre"];
                dr[2] = (System.Int32)datareader["codinstitucion"];
                dr[3] = (System.String)datareader["nombinst"];
                dr[4] = (System.Int32)datareader["region"];
                dr[5] = (System.String)datareader["comuna"];
                dr[6] = (System.String)datareader["Tematica"];//dt.Columns.Add("Tematica");
                dr[7] = (System.String)datareader["Modelo"];//dt.Columns.Add("Modelo");
                dr[8] = (System.String)datareader["SistemaAsistencial"];//dt.Columns.Add("SistemaAsistencial");
                dr[9] = (System.String)datareader["TipoSubvencion"];//dt.Columns.Add("TipoSubvencion");
                dr[10] = (System.String)datareader["TipoProyecto"];//dt.Columns.Add("TipoProyecto");
                dr[11] = (System.String)datareader["Departamento"];//dt.Columns.Add("Departameto");
                dr[12] = (System.String)datareader["numeroresolucion"];
                dr[13] = (System.Int32)datareader["anoresolucion"];
                dr[14] = (System.String)datareader["tipo"];
                dr[15] = (System.String)datareader["materia"];
                dr[16] = (System.String)datareader["FechaResolucion"];
                dr[17] = (System.String)datareader["fechaconvenio"];
                dr[18] = (System.String)datareader["fechainicio"];
                dr[19] = (System.String)datareader["fechatermino"];
                dr[20] = (System.Int32)datareader["numeroplazas"];
                dr[21] = (System.String)datareader["dias_atencion"];
                dr[22] = (System.String)datareader["sexo"];
                dr[23] = (System.String)datareader["Termino"];
                dr[24] = (System.String)datareader["Vigencia"];
                dr[25] = (System.String)datareader["reporte"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();

        DataView dv = new DataView(dt);
        if (dv.Count > 0)
        {
            grd001.DataSource = dv;
            grd001.DataBind();
            btn_excel.Visible = true;
            lbl_error.Text = string.Empty;
            alerts.Visible = false; 
            grd001.Visible = true;
            
        }
        else
        {
            btn_excel.Visible = false;
            lbl_error.Visible = true;
            lbl_error.Text = "No se han encontrado registros coincidentes";
            alerts.Visible = true;
            grd001.Visible = false;
        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        grd001.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        chk_001.Checked = false;
        alerts.Visible = false;
    }
    
    protected void ddinstitucion_SelectIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1" ) //SGF
        {
            getinstituciones();
        }
        else
        {
            getinstitucionesxRgn();
        }
    }
    protected void ddproyectos_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
 
    //protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        string etiqueta = "Plan de Intervencion";
    //        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_resoluciones.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //    }
    //    catch (Exception ex)
    //    { }
    //}
    //protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        string etiqueta = "Busca Proyectos";
    //        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_resoluciones.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //    }
    //    catch (Exception ex)
    //    { }
    //}
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1" )   //SGF
        {
            getinstituciones();
            Session["regselec"] = ddregion.SelectedValue;
        }
        else
        {
            getinstitucionesxRgn();
            Session["regselec"] = ddregion.SelectedValue;
        }
    }
   
    protected void chk_001_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btn_excel_Click1(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Resoluciones.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataTable dt = new DataTable();
            dt.Columns.Add("codProyecto");                          //0
            dt.Columns.Add("nombre", typeof(String));               //1 
            dt.Columns.Add("codinstitucion");	                    //2
            dt.Columns.Add("nombinst");		                        //3
            dt.Columns.Add("region");                               //4
            dt.Columns.Add("comuna");                               //5
            dt.Columns.Add("Tematica");                             //6
            dt.Columns.Add("Modelo");                               //7
            dt.Columns.Add("SistemaAsistencial");                   //8 
            dt.Columns.Add("TipoSubvencion");                       //9 
            dt.Columns.Add("TipoProyecto");                         //10    
            dt.Columns.Add("Departamento");                          //11
            dt.Columns.Add("numeroresolucion");                     //12
            dt.Columns.Add("anoresolucion");                        //13
            dt.Columns.Add("tipo");                                 //14
            dt.Columns.Add("materia");                              //15
            dt.Columns.Add("FechaResolucion");                      //16
            dt.Columns.Add("fechaconvenio");                        //17
            dt.Columns.Add("fechainicio");                          //18
            dt.Columns.Add("fechatermino");                         //19
            dt.Columns.Add("numeroplazas");                         //20
            dt.Columns.Add("dias_atencion");                        //21
            dt.Columns.Add("sexo");                                 //22
            dt.Columns.Add("termino");                              //23
            dt.Columns.Add("Vigencia");                             //24
            dt.Columns.Add("reporte");                              //25

            DataRow dr;

            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < grd001.Columns.Count; j++)
                {
                    dr[j] = grd001.Rows[i].Cells[j].Text;
                }
                dt.Rows.Add(dr);
            }
            //DataView dv = new DataView(dt);
            //DataGrid d1 = new DataGrid();
            //d1.DataSource = dv;
            //d1.DataBind();
            //d1.RenderControl(hw);
            //Response.Write(tw.ToString());
            //Response.End();

            DataGrid d1 = new DataGrid();
            d1.DataSource = dt;
            d1.DataBind();
            d1.RenderControl(hw);
            Response.Write(tw.ToString());
            //Response.Close();
            Response.End();


            //Response.TransmitFile(tw.ToString());
            //Response.Flush();
            //Response.Close();


        }
        catch(Exception ex)
        { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}
