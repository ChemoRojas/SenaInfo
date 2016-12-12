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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;


public partial class Reportes_Rep_Eventis : System.Web.UI.Page
{

    public DataTable dtReporte
    {
         
        get { return (DataTable)Session["dtReporte"]; }
        set { Session["dtReporte"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("BA388C19-048E-4235-93D4-AF3187DA84E3"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                getparregion();
                if (Session["CodRegion"] != null)
                    ddregion.SelectedValue = Session["CodRegion"].ToString();


                getinstitucionesxRgn();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();

                cPII.Enabled = false;
                btn_excel.Visible = false;
               btnImprimir.Visible = false;
               btn_buscar.Visible = true;

                if (Request.QueryString["sw"] == "3")
                {
                    limpiaSession();
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddown002_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    limpiaSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    ddregion.SelectedValue = "-1";
                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                }
            }
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
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }


    private void getparregion()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        // DataView dv1 = new DataView(par.GetparRegion());
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddregion.DataBind();
        if (ddregion.SelectedValue == "15")
        {
            ddregion.SelectedValue = "-1";
        }
        else
        {
            if (dv1.Count == 2)
            {
                ddregion.SelectedIndex = 1;
            }
        }
    }
    private int validatesecurity()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
        int val = 0;

        if (rol == "267" || rol == "265")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = colorCampoObligatorio;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }

            if (ddproyecto.SelectedValue == "0")
            {
                ddproyecto.BackColor = colorCampoObligatorio;
                val = 1;
                limpiar();
            }
            else { ddproyecto.BackColor = System.Drawing.Color.White; }
        }
        if (rol == "251")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = colorCampoObligatorio;
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
        alerts.Visible = false;
        btnImprimir.Visible = false;
        btn_buscar.Visible = true;

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
        {
            ddinstitucion.SelectedIndex = 1;
        }
    }
    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();

        DataView dv2 = new DataView(inst.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));

        // DataView dv2 = new DataView(inst.GetInstitucionReportexRgn(Convert.ToInt32(ddregion.SelectedValue)));
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
        //DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        ddproyecto.DataSource = dv3;
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();

        if (dv3.Count == 2)
            ddproyecto.SelectedIndex = 1;
    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_eventos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_eventos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    //protected void btn_volver_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../mod_reportes/index_reportes.aspx");
    //}
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        grd001.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        alerts.Visible = false;
        btnImprimir.Visible = false;
        btn_buscar.Visible = true;

        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        cal_inicio.Text = null;
        cal_Termino.Text = null;

        cPII.Enabled = false;
        cPII.Text = "0";
        RadioButtonList1.SelectedValue = "0";

        //dtReporte.Rows.Clear();
        // grd001.DataSource = "";
        // grd001.DataBind();

    }


    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1" || ddregion.SelectedValue == "15")
        {
            getinstituciones();
        }
        else
        {
            getinstitucionesxRgn();
        }
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
         int val = validatesecurity();
         if (val == 0)
         {
             if (cal_inicio.Text == "")
                 cal_inicio.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
             if (cal_Termino.Text == "")
                 cal_Termino.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
             if (RadioButtonList1.SelectedValue == "0")
                 cPII.Text = "0";
             
             int mes = 0;
             if (cal_inicio.Text != "" && cal_Termino.Text != "")
             {
                 if (Convert.ToDateTime(cal_Termino.Text).Year != Convert.ToDateTime(cal_inicio.Text).Year)
                 {
                     if (Convert.ToDateTime(cal_Termino.Text).Month != 1 || Convert.ToDateTime(cal_inicio.Text).Month != 12)
                     {
                         mes = 2;
                     }
                 }
                 else
                 {
                     mes = Convert.ToInt32(Convert.ToDateTime(cal_Termino.Text).Month - Convert.ToDateTime(cal_inicio.Text).Month);
                 }
             }
            if (/*Convert.ToInt32(ddregion.SelectedValue) == -2 || */ cPII.Text.Trim() == ""
                 || Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_Termino.Text) ||
                 (ddproyecto.SelectedValue == "0" && mes > 1))
             {
                 if (Convert.ToInt32(ddinstitucion.SelectedValue) == 0 || Convert.ToInt32(ddinstitucion.SelectedValue) == -1)
                 {
                     lbl_error.Visible = true;
                     lbl_error.Text = "Consulta Ambigua. Debe Ingresar Region o Institución o Proyecto";
                     ddregion.Focus();
                     alerts.Visible = true;
                     return;
                 }
                
                 if (cPII.Text.Trim() == "")
                 {
                     alerts.Visible = true;
                     lbl_error.Visible = true;
                     lbl_error.Text = "Debe Ingresar Codigo Plan de Intervencion";
                     cPII.Focus();
                     return;

                 }
                 if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_Termino.Text))
                 {
                     alerts.Visible = true;
                     lbl_error.Visible = true;
                     lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
                     cal_inicio.Focus();
                     return;
                 }
                 if (ddproyecto.SelectedValue == "0" && mes > 1)
                 {
                     alerts.Visible = true;
                     lbl_error.Visible = true;
                     lbl_error.Text = "El Período no puede ser mayor a Un Mes";
                     cal_inicio.Focus();
                     return;
                 }
             }
             else
             {
                 cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_Termino.Text), Convert.ToInt32(cPII.Text.Trim())); //);
             }
         }
    }
    private void cargaDTG(int region, int codinstitucion, int codproyecto, DateTime fechainicio, DateTime fechatermino, int PII)
    {
        ReporteNinoColl rI = new ReporteNinoColl();

        if (RadioButtonList2.SelectedValue == "0")
            dtReporte = rI.Get_ReporteNino(region, codinstitucion, codproyecto, fechainicio, fechatermino, PII, Convert.ToInt32(Session["IdUsuario"]));//, dtReporte);
        else
        {
            if (RadioButtonList2.SelectedValue == "1")
            {
            dtReporte = rI.Get_ReportePII(region, codinstitucion, codproyecto, PII, fechainicio, fechatermino);
            ReportePII();
            return; 
            }
            else
            {
                dtReporte = rI.Get_ReportePII(region, codinstitucion, codproyecto, PII, fechainicio, fechatermino);
                ReportePII_Excel();
                //return;
            }
        }
        //cal_inicio.Value = 0;
        //cal_Termino.Value = 0;

        if (dtReporte.Rows.Count > 0)
        {
            grd001.DataSource = dtReporte;
            grd001.DataBind();
            btn_excel.Visible = true;
            btnImprimir.Visible = true;
            btn_buscar.Visible = false;
            lbl_error.Visible = false;
            alerts.Visible = false;
            grd001.Visible = true;
        }
        else
        {
            btn_excel.Visible = false;
            lbl_error.Text = "No se han encontrado registros coincidentes";
            lbl_error.Visible = true;
            alerts.Visible = true;
            btnImprimir.Visible = false;
            btn_buscar.Visible = true;
            grd001.Visible = false;
        }

    }
    private void ReportePII()
    {
        if (dtReporte.Rows.Count > 0)
        {
           
            window.open(Page, "Reg_Reportes.aspx?param001=6", 600, 800);
           
        }
    }
    private void ReportePII_Excel()
    {
        if (dtReporte.Rows.Count > 0)
        {        
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=AreasIntervencion.xls");
                this.EnableViewState = false;

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                DataView dv = new DataView(dtReporte);

                GridView grd002 = new GridView();
                grd002.DataSource = dv;
                grd002.DataBind();
                grd002.RenderControl(hw);
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(tw.ToString());
                Response.End();
                    
        }
    }

    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("codinstitucion");
        dt.Columns.Add("nombinst");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("nombre");
        dt.Columns.Add("CodRegion");
        dt.Columns.Add("CodNino");
        dt.Columns.Add("apellido_paterno");
        dt.Columns.Add("apellido_materno");
        dt.Columns.Add("nombres");
        dt.Columns.Add("Fechanacimiento");
        dt.Columns.Add("run");
        dt.Columns.Add("FechaIngreso");
        dt.Columns.Add("FechaEgreso");
        dt.Columns.Add("Grupo");
        dt.Columns.Add("DescripcionGrupo");
        dt.Columns.Add("CodPlanIntervencion");
        dt.Columns.Add("FechaElaboracionPII");
        dt.Columns.Add("EstadoPlan");
        dt.Columns.Add("Grado");
        dt.Columns.Add("FechaTerminoRealPII");
        dt.Columns.Add("TipoIntervencion");
        dt.Columns.Add("Nivel");
        dt.Columns.Add("FechaEvento");
        dt.Columns.Add("TipoEvento");
        dt.Columns.Add("DescripcionEvento");
        dt.Columns.Add("Clasif_Evento");
        dt.Columns.Add("ICodIE");
        dt.Columns.Add("desde");
        dt.Columns.Add("hasta");
        dt.Columns.Add("reporte");
        dt.Columns.Add("Tpaterno");
        dt.Columns.Add("Tmaterno");
        dt.Columns.Add("Tnombres");
        dt.Columns.Add("FechaActualizacion");

        DataRow dr;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            dr = dt.NewRow();
            for (int j = 0; j < grd001.Columns.Count; j++)
            {
                dr[j] = Server.HtmlDecode(grd001.Rows[i].Cells[j].Text);
            }
            dt.Rows.Add(dr);
        }


        //window.open(this.Page,"Reg_Reportes.aspx?param001=3" ,"../Reportes",false,true,800,600,false,false,true);

        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument crReporteEventos = new ReportDocument();

        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
        crReporteEventos.Load(@rptPath + "crEventosPII.rpt");
        crReporteEventos.SetDataSource(dt);
        crReporteEventos.Refresh();

        string Fname = ConfigurationSettings.AppSettings["PathReportes"].ToString() + "crEventos.pdf"; ;//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crEventos.pdf";
        crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
        crDiskFileDestinationOptions.DiskFileName = Fname;
        crExportOptions = crReporteEventos.ExportOptions;
        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        crReporteEventos.Export();
        crReporteEventos.Dispose();
        //		System.Web.UI.Page sCDP = new Page();
        //Modifica el header de la página para descargar el archivo .pdf	
        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.ContentType = "application/pdf";
        this.Response.WriteFile(Fname);
        this.Response.Flush();
        this.Response.Close();
        //delete the exported file from disk
        System.IO.File.Delete(Fname);
        crReporteEventos.Dispose();
        crReporteEventos.Close();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            cPII.Enabled = true;
        }
        else
        {
            cPII.Enabled = false;
            cPII.Text = "0";
        }
    }
    protected void cPII_ValueChange(object sender, EventArgs e)
    {
        if (cPII.Text.Trim() == "")
        {
            cPII.Text = "0";
        }
    }

    protected void btn_excel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Intervenciones.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataTable dt = new DataTable();
            dt.Columns.Add("codinstitucion");
            dt.Columns.Add("nombinst");
            dt.Columns.Add("codproyecto");
            dt.Columns.Add("nombre");
            dt.Columns.Add("CodRegion");
            dt.Columns.Add("CodNino");
            dt.Columns.Add("apellido_paterno");
            dt.Columns.Add("apellido_materno");
            dt.Columns.Add("nombres");
            dt.Columns.Add("Fechanacimiento");
            dt.Columns.Add("run");
            dt.Columns.Add("FechaIngreso");
            dt.Columns.Add("FechaEgreso");
            dt.Columns.Add("Grupo");
            dt.Columns.Add("DescripcionGrupo");
            dt.Columns.Add("CodPlanIntervencion");
            dt.Columns.Add("FechaElaboracionPII");
            dt.Columns.Add("EstadoPlan");
            dt.Columns.Add("Grado");
            dt.Columns.Add("FechaTerminoRealPII");
            dt.Columns.Add("TipoIntervencion");
            dt.Columns.Add("Nivel");
            dt.Columns.Add("FechaEvento");
            dt.Columns.Add("TipoEvento");
            dt.Columns.Add("DescripcionEvento");
            dt.Columns.Add("Clasif_Evento");
            dt.Columns.Add("ICodIE");
            dt.Columns.Add("desde");
            dt.Columns.Add("hasta");
            dt.Columns.Add("reporte");
            dt.Columns.Add("Tpaterno");
            dt.Columns.Add("Tmaterno");
            dt.Columns.Add("Tnombres");
            dt.Columns.Add("FechaActualizacion");

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
            DataView dv = new DataView(dt);
            DataGrid d1 = new DataGrid();
            d1.DataSource = dv;
            d1.DataBind();
            d1.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
        catch (Exception ex)
        { }
    }
}
