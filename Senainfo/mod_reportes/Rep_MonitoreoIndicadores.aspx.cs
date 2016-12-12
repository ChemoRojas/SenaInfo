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
using regfaltas2TableAdapters;
using System.Drawing;

public partial class mod_reportes_Rep_MonitoreoIndicadores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
                Response.Redirect("~/logout.aspx");
            else
            {
                if (!window.existetoken("2978373A-77C7-4196-827B-C9AB3F735375"))
                    Response.Redirect("~/logout.aspx");

                GetRegiones();
                if (Session["CodRegion"] != null)
                    ddl_region.SelectedValue = Session["CodRegion"].ToString();

                getinstituciones();
                if (Session["CodInstitucion"] != null)
                    ddown001.SelectedValue = Session["CodInstitucion"].ToString();
                    
                getproyectos();
                if (Session["CodProyecto"] != null)
                    ddown002.SelectedValue = Session["CodProyecto"].ToString();

                GetReportesMonitoreo();
                

                getanos();
                
                if (Request.QueryString["sw"] == "3")
                {
                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    getproyectos();
                }
                else if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                }
            }
        }
        Session["CodRegion"] = ddl_region.SelectedValue;
        Session["CodInstitucion"] = ddown001.SelectedValue;
        Session["CodProyecto"] = ddown002.SelectedValue;
    }

    private void limpiaSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }
    private void getanos()
    {
        for (int i = 0; i < 4; i++)
        {
            ddown_AnoCierre.Items.Add(Convert.ToString(DateTime.Now.Year - i)); 
        }
    }
    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre";
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "Codinstitucion";
        ddown001.DataBind();

        if (dv.Count == 2)
            ddown001.SelectedIndex = 1;

    }
    private void getproyectos()
    {
        if (ddown001.Items.Count > 0)// && Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            proyectocoll pcoll = new proyectocoll();

            DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue));
            DataView dv = new DataView(dtproy);
            dv.Sort = "Nombre";
            ddown002.DataSource = dv;
            ddown002.DataTextField = "Nombre";
            ddown002.DataValueField = "CodProyecto";
            ddown002.DataBind();

            if (dv.Count == 2)
                ddown002.SelectedIndex = 1;
        }
    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_MonitoreoIndicadores.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_MonitoreoIndicadores.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index_Reportes.aspx");
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {                                                                                                                                                               

        
        if (ddl_region.Items.Count == 2)
            ddl_region.SelectedIndex = 1;

        ObjetosBlancos();
        ddown001.SelectedIndex = -1;
        ddown002.SelectedIndex = -1;
        ddown_AnoCierre.SelectedIndex = -1;
        ddown_MesCierre.SelectedIndex = -1;
    }

    private void ObjetosBlancos()
    {
        ddl_indicadores.BackColor = System.Drawing.Color.White;
        ddown001.BackColor = System.Drawing.Color.White;
        ddown002.BackColor = System.Drawing.Color.White;
        ddown_MesCierre.BackColor = System.Drawing.Color.White;
        ddl_region.BackColor = System.Drawing.Color.White;
        lbl_error.Visible = false;
    }
    public void ExtraerExcel()
    {
        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));

        //265,287,267,286
        int codRegion = -1;
        if (Convert.ToInt32(ddl_region.SelectedValue) > 0)
            codRegion = Convert.ToInt32(ddl_region.SelectedValue);

            if (ddown_MesCierre.SelectedValue != "0")
            {
                if (rol == "265" || rol == "267" || rol == "286" || rol == "287")
                {
                    if (ddown002.SelectedValue == "0")
                    {
                        ddown002.BackColor = System.Drawing.Color.Pink;
                        lbl_warningvacios.Text = "Debe filtrar por proyecto.";
                        lbl_warningvacios.Visible = true;
                        lbl_warningvacios.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        ddown002.BackColor = System.Drawing.Color.White;
                        lbl_warningvacios.Text = string.Empty;
                        lbl_warningvacios.Visible = false;

                        ReporteNinoColl rpn = new ReporteNinoColl();

                        DataTable dt = rpn.callto_reporte_monitoreo_indicadores(Convert.ToInt32(ddown002.SelectedValue),
                            Convert.ToDateTime("01/" + ddown_MesCierre.SelectedValue.ToString() + "/" + ddown_AnoCierre.SelectedValue.ToString()),
                            ddl_indicadores.SelectedValue.ToString(), Convert.ToInt32(ddown001.SelectedValue),
                            codRegion);

                        if (dt.Rows.Count > 0)
                            ExportaExcel(dt);
                        else
                        {
                            alerts.Visible = true;
                            lbl_error.Text = "No se han encontrado registros para los parametros ingresados.";
                            lbl_error.Visible = true;
                            return;
                        }
                    }
                }
                else //if (rol == "263" || rol == "273" || rol == "252")
                {
                    if (Convert.ToInt32(ddl_region.SelectedValue) < 1 &&  rol != "252")
                    {
                        alerts.Visible = true;
                        lbl_error.Text = "Ingrese todos los parametros solicitados.";
                        lbl_error.Visible = true;
                        ddl_region.BackColor = System.Drawing.Color.Pink;
                        return;
                    }
                    else
                    {
                        int idproyecto = 0;
                        int idinstitucion = 0;
                        if (ddown002.SelectedValue == "0")
                            idproyecto = -1;
                        else
                            idproyecto = Convert.ToInt32(ddown002.SelectedValue);
                        
                        if (ddown001.SelectedValue == "0")
                            idinstitucion = -1;
                        else
                            idinstitucion = Convert.ToInt32(ddown001.SelectedValue);

                        ReporteNinoColl rpn = new ReporteNinoColl();

                        DataTable dt = rpn.callto_reporte_monitoreo_indicadores(idproyecto,
                            Convert.ToDateTime("01/" + ddown_MesCierre.SelectedValue.ToString() + "/" + ddown_AnoCierre.SelectedValue.ToString()),
                            ddl_indicadores.SelectedValue.ToString(), idinstitucion,
                            codRegion);

                        if (dt.Rows.Count > 0)
                            ExportaExcel(dt);
                        else
                        {
                            alerts.Visible = true;
                            lbl_error.Text = "No se han encontrado registros para los parametros ingresados.";
                            lbl_error.Visible = true;
                            return;
                        }
                    }
                }
            }
            else
            {
                if (ddown_MesCierre.SelectedValue == "0")
                {
                    ddown_MesCierre.BackColor = System.Drawing.Color.Pink;
                }
                else
                {
                    ddown_MesCierre.BackColor = System.Drawing.Color.White;
                }
                alerts.Visible = true;
                lbl_error.Text = "Ingrese todos los parametros solicitados.";
                lbl_error.Visible = true;
                return;
            }
        
    }

    private void ExportaExcel(DataTable dt)
    {
        ObjetosBlancos();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Monitoreo_Indicadores.xls");

        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        //for (int k = 0; k < dt.Columns.Count; k++)
        //{
        //    string pruebas = Convert.ToString(dt.Columns[k]);
        //    dt.Columns[k].ColumnName = Convert.ToString(dt.Columns[k]);
        //}
        DataView dv = new DataView(dt);
        GridView grd002 = new GridView();
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.RenderControl(hw);

        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ddl_indicadores.SelectedValue != "0")
        {
            lbl_error.Visible = false;
            ddl_indicadores.BackColor = System.Drawing.Color.White;
            ExtraerExcel();
        }
        else
        {
            lbl_error.Text = "Ingrese todos los parametros solicitados.";
            lbl_error.Visible = true;
            ddl_indicadores.BackColor = System.Drawing.Color.Pink;
        }
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        if (ddl_indicadores.SelectedValue != "0")
        {   
            lbl_error.Visible = false;
            ddl_indicadores.BackColor = System.Drawing.Color.White;
            ExtraerExcel();
            if(!lbl_error.Visible)
                btn_limpiar_Click(sender, e);
        }
        else
        {
            lbl_error.Text = "Ingrese todos los parametros solicitados.";
            lbl_error.Visible = true;
            ddl_indicadores.BackColor = System.Drawing.Color.Pink;
        }
    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }

    private void GetRegiones()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        dv1.RowFilter = "CodRegion not in (-1, 16)";    // Se excluye NO CORRESPONDE y SIN INFORMACION
        ddl_region.DataSource = dv1;
        ddl_region.DataTextField = "Descripcion";
        ddl_region.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddl_region.DataBind();

        if (dv1.Count == 2)
        {
            ddl_region.SelectedIndex = 1;
            ddl_region.Enabled = false;
        }
        else
            ddl_region.Enabled = true;

        #region 
        //parRegionTableAdapter region = new parRegionTableAdapter();
        //DataTable dtregion = region.GetRegionesByUser(Convert.ToInt32(Session["IdUsuario"]));

        //DataTable dtTempRegion = new DataTable();
        //dtTempRegion.Columns.Add("CodRegion");
        //dtTempRegion.Columns.Add("Descripcion");

        //DataRow drTempRegion;
        //drTempRegion = dtTempRegion.NewRow();
        //drTempRegion[0] = "0";
        //drTempRegion[1] = "Seleccionar";
        //dtTempRegion.Rows.Add(drTempRegion);

        //for (int m = 0; m <= dtregion.Rows.Count; m++)
        //{
        //    try
        //    {
        //        drTempRegion = dtTempRegion.NewRow();
        //        drTempRegion[0] = Convert.ToString(dtregion.Rows[m]["CodRegion"]);
        //        drTempRegion[1] = Convert.ToString(dtregion.Rows[m]["Descripcion"]);
        //        dtTempRegion.Rows.Add(drTempRegion);
        //    }
        //    catch
        //    {
        //    }
        //}

        //if (dtregion.Rows.Count > 0)
        //{
        //    ddl_region.DataSource = dtTempRegion;
        //    ddl_region.DataTextField = "Descripcion";
        //    ddl_region.DataValueField = "CodRegion";
        //    ddl_region.DataBind();
        //}
        #endregion
    }

    private void GetReportesMonitoreo()
    {
        par_ReporteMonitoreoTableAdapter reportes = new par_ReporteMonitoreoTableAdapter();
        DataTable dtReportes = reportes.Get_ReporteMonitoreo();
        if (dtReportes.Rows.Count > 0)
        {
            DataTable dtTempReportes = new DataTable();
            dtTempReportes.Columns.Add("Procedimiento");
            dtTempReportes.Columns.Add("Indicador");

            DataRow drTempReportes;
            drTempReportes = dtTempReportes.NewRow();
            drTempReportes[0] = "0";
            drTempReportes[1] = "Seleccionar";
            dtTempReportes.Rows.Add(drTempReportes);

            for (int i = 0; i < dtReportes.Rows.Count; i++)
            {
                try
                {
                    drTempReportes = dtTempReportes.NewRow();
                    drTempReportes[0] = dtReportes.Rows[i]["Procedimiento"].ToString();
                    drTempReportes[1] = dtReportes.Rows[i]["tipo_Indicador"].ToString().Trim() + " - " + dtReportes.Rows[i]["Indicador"].ToString().Trim(); 
                    dtTempReportes.Rows.Add(drTempReportes);
                }
                catch
                {
                }
            }
            if (dtTempReportes.Rows.Count > 0)
            {
                ddl_indicadores.DataSource = dtTempReportes;
                ddl_indicadores.DataValueField = "Procedimiento";
                ddl_indicadores.DataTextField = "indicador";
                ddl_indicadores.DataBind();
            }
        }        
    }
    
}
