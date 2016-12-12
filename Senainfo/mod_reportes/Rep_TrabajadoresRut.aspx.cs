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

public partial class mod_reportes_Rep_TrabajadoresRut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            # region VALIDACION USUARIO

            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("8F324DF0-04C2-4E56-B1CC-7D25DD3BA16C"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    rellenar();
                    try
                    {
                        if (Request.QueryString["sw"] == "4")
                        {
                            buscador_institucion bsc = new buscador_institucion();
                            int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                            ddinstitucion.SelectedValue = Convert.ToString(codinst);
                            getproyectos();
                            ddproyecto.SelectedValue = Request.QueryString["codinst"];
                            

                        }
                        if (Request.QueryString["sw"] == "3")
                        {
                            ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                            ddproyecto_SelectedIndexChanged(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            #endregion

        }
        ddregion.Enabled = true;
        ddinstitucion.Enabled = true;
        ddproyecto.Enabled = true;
        if (rbt_buscador.SelectedValue == "región")
        {
            ddinstitucion.Enabled = false;
            ddproyecto.Enabled = false;
        }
        if (rbt_buscador.SelectedValue == "institución")
        {
            ddregion.Enabled = false;
            ddproyecto.Enabled = false;
        }
        if (rbt_buscador.SelectedValue == "proyecto")
        {
            ddregion.Enabled = false;
            ddinstitucion.Enabled = false;
        }


        Session["CodRegion"] = ddregion.SelectedValue;
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
        Session["CodProyecto"] = ddproyecto.SelectedValue;
    }

    private void limpiaSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }

    private void getparregion()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        // DataView dv1 = new DataView(par.GetparRegion());
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        ddregion.DataBind();
        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
        if (rol == "252")
        {
            //List<ListItem> items = new List<ListItem>();
            //items.Add(new ListItem("Todas Las Regiones", "115"));
            //ddregion.Items.Add(items);
            ddregion.Items.Add("Todas Las Regiones");

            if (dv1.Count == 3)
                ddregion.SelectedIndex = 0; ddregion.Enabled = true;

        }

        if (dv1.Count == 2)
            ddregion.SelectedIndex = 0; ddregion.Enabled = false;

        

    }

    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre";
        ddinstitucion.DataSource = dv;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "Codinstitucion";
        ddinstitucion.DataBind();
        if (dtinst.Rows.Count > 0)
        {
            ddinstitucion.SelectedIndex = 1;
        }

    }

    private void getproyectos()
    {
        if (ddinstitucion.Items.Count > 0 && Convert.ToInt32(ddinstitucion.SelectedValue) > 0)
        {
            proyectocoll proy = new proyectocoll();

            //DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue));
            DataView dv1 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
            dv1.Sort = "Nombre";
            ddproyecto.DataSource = dv1;
            ddproyecto.DataTextField = "Nombre";
            ddproyecto.DataValueField = "CodProyecto";
            ddproyecto.DataBind();
            if (dv1.Count == 2)
            {
                ddproyecto.SelectedIndex = 1;                
            }
        }


    }

    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));       
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();
    }        

    private void rellenar()
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
    }

    protected void imgbtn_lupaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_TrabajadoresRut.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void imgbtn_lupaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
       // ../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_mesa/LayerControl/C_buscar_x_institu_proyecto.ascx"
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyecto&dir=../mod_reportes/Rep_TrabajadoresRut.aspx", "Buscador", false, true, 770, 420, false, false, true);    
    }
   
  
    
    private void CleanSessions()
    {
        try
        {
            Session.Remove("ReporteTrabajadoresRegion");
            Session.Remove("ReporteTrabajadoresInstitucion");
            Session.Remove("ReporteTrabajadoresProyecto");
            Session.Remove("addNewWorker");
        }      
        catch(Exception ex)
        {

        }
    }
    protected void ddproyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        //getproyectos();
    }
    private void printAllRegions()
    {
        diagnosticoscoll dgcoll = new diagnosticoscoll();
        DataTable dt = new DataTable();        
        dt = dgcoll.GetRepTrabajadoresxTodo();
        DataView dv = new DataView(dt);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Trabajadores.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        GridView grd002 = new GridView();
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End(); 
    }
  
    protected void imgbtn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index_Reportes.aspx");
    }
    //protected void imgbtn_Region_Click(object sender, EventArgs e)
    protected void SearchRegion()
    {
        string vig = string.Empty;
        if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
        {
            vig = "V";
        }
        if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
        {
            vig = "C";
        }
        if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
        {
            vig = "T";
        }
        CleanSessions();
        Session["ReporteTrabajadoresRegion"] = ddregion.SelectedValue.ToString() + "," + vig;
        if (Session["ReporteTrabajadoresRegion"].Equals("Todas Las Regiones"))
        {
            printAllRegions();
        }
        else
        {
            window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);
        }
    }
    //protected void imgbtn_Institucion_Click(object sender, EventArgs e)
    protected void SearchInstitucion()
    {
        string vig = string.Empty;
        if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
        {
            vig = "V";
        }
        if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
        {
            vig = "C";
        }
        if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
        {
            vig = "T";
        }
        CleanSessions();
        Session["ReporteTrabajadoresInstitucion"] = ddinstitucion.SelectedValue.ToString() + "," + vig;
        window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);
    }
    //protected void imgbtn_Proyecto_Click(object sender, EventArgs e)
    protected void Searchproyecto()
    {
        string vig = string.Empty;
        if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
        {
            vig = "V";
        }
        if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
        {
            vig = "C";
        }
        if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
        {
            vig = "T";
        }
        CleanSessions();
        Session["ReporteTrabajadoresProyecto"] = ddproyecto.SelectedValue.ToString() + "," + vig;
        window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);
    }
    protected void imgbtn_AddNewTrabaj_Click(object sender, EventArgs e)
    {
        if (ddproyecto.SelectedValue != "0")
        {
            lbl_Error.Visible = false;
            string vig = string.Empty;
            if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
            {
                vig = "V";
            }
            if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
            {
                vig = "C";
            }
            if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
            {
                vig = "T";
            }
            CleanSessions();
            Session["addNewWorker"] = ddproyecto.SelectedValue.ToString() + "," + vig;
           // window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);

            string cadena = string.Empty;
            //cadena = @"window.open(this.Page, '/mod_reportes/RepTrabajadoresExcel.aspx', 'ReporteTrabajadores', true, 1600, 430, false, false, true);";
            //ClientScript.RegisterStartupScript(this.GetType(), "", cadena, true); 
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);

            string url = "RepTrabajadoresExcel.aspx";
            ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "')", true);
        }
        else
        {
            lbl_Error.Visible = true;
        }
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        if (rbt_buscador.SelectedValue == "Región")
        {
            SearchRegion();
            ddinstitucion.Enabled = false;
            ddproyecto.Enabled = false;
        }
        if (rbt_buscador.SelectedValue == "Institución")
        {
            SearchInstitucion();
            ddregion.Enabled = false;
            ddproyecto.Enabled = false;
        }
        if (rbt_buscador.SelectedValue == "Proyecto")
        {
            Searchproyecto();
            ddregion.Enabled = false;
            ddinstitucion.Enabled = false;
        }
       
    }
    protected bool SolicitudxRegion()
    {
        bool status = false;
        try
        {
            string vig = string.Empty;
            if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
            {
                vig = "V";
            }
            if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
            {
                vig = "C";
            }
            if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
            {
                vig = "T";
            }
            CleanSessions();
            //Session["ReporteTrabajadoresRegion"] = ddregion.SelectedValue.ToString() + "," + vig;
            if (Session["ReporteTrabajadoresRegion"].Equals("Todas Las Regiones"))
            {
                printAllRegions();
            }
            else
            {
                window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);
            }
        }
        catch (Exception ex)
        { }
        return status;
    }
    protected bool SolicitudxInstitucion()
    {
        bool status = false;
        try
        {
            string vig = string.Empty;
            if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
            {
                vig = "V";
            }
            if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
            {
                vig = "C";
            }
            if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
            {
                vig = "T";
            }
            CleanSessions();
            Session["ReporteTrabajadoresInstitucion"] = ddinstitucion.SelectedValue.ToString() + "," + vig;
            window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);
        }
        catch (Exception ex)
        { }
        return status;
    }
    protected bool SolicitudxProyecto()
    {
        bool status = false;
        try
        {
            string vig = string.Empty;
            if (Convert.ToBoolean(rdbtn_Vigente.Checked) == true)
            {
                vig = "V";
            } 
            if (Convert.ToBoolean(rdbtn_Caducado.Checked) == true)
            {
                vig = "C";
            }
            if (Convert.ToBoolean(rdbtn_Todos.Checked) == true)
            {
                vig = "T";
            }
            CleanSessions();
            Session["ReporteTrabajadoresProyecto"] = ddproyecto.SelectedValue.ToString() + "," + vig;
            window.open(this.Page, "RepTrabajadoresExcel.aspx", "ReporteTrabajadores", true, 1600, 430, false, false, true);
        }
        catch (Exception ex)
        { }
        return status;
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        limpiaSession();
        ScriptManager.RegisterStartupScript(this, GetType(), "fn1", "$('#ddregion').val(-2);$('#ddinstitucion').val(0); $('#ddproyecto').val(0)", true);
    }
    protected void ddinstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
}
