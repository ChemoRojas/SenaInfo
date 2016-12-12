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

public partial class mod_rendiciones_Reg_Reportes : System.Web.UI.Page
{
    public string StrPath
    {
        get { return (string)Session["StrPath"]; }
        set { Session["StrPath"] = value; }
    }
    public DataTable DTingresoResumen
    {
        get { return (DataTable)Session["DTingresoResumen"]; }
        set { Session["DTingresoResumen"] = value; }
    }
    public DataTable DTegresoResumen
    {
        get { return (DataTable)Session["DTegresoResumen"]; }
        set { Session["DTegresoResumen"] = value; }
    }
    public DataTable dtIngresosRPT
    {
        get { return (DataTable)Session["dtIngresosRPT"]; }
        set { Session["dtIngresosRPT"] = value; }
    }
    public DataTable dtEgresosRPT
    {
        get { return (DataTable)Session["dtEgresosRPT"]; }
        set { Session["dtEgresosRPT"] = value; }
    }
    public DataTable dtReporte
    {
        get { return (DataTable)Session["dtReporte"]; }
        set { Session["dtReporte"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        # region VALIDACION USUARIO
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {

            }

        }
        #endregion
        if (Request.QueryString["param001"] == "1")
        {
            imp_reportes(
                Request.QueryString["Impresora_Excel"],
                Request.QueryString["AnoPresupuestario"],
                Request.QueryString["Monto"],
                Request.QueryString["NumeroCheque"],
                Request.QueryString["Institucion"],
                Request.QueryString["Proyecto"],
                Request.QueryString["CodProyecto"],
                Request.QueryString["RutNumeroProyecto"],
                Request.QueryString["Banco"],
                Request.QueryString["CuentaCorriente"],
                Request.QueryString["Plazas"],
                Request.QueryString["SaldoAnterior"],
                Request.QueryString["TotalDisponible"],
                Request.QueryString["SaldoDisponible"],
                Request.QueryString["Meses"],
                Request.QueryString["Ano"]);
        }
        if (Request.QueryString["param001"] == "2")
        {
            imp_reportes(
                Request.QueryString["Impresora_Excel"],
                Request.QueryString["Institucion"],
                Request.QueryString["Proyecto"],
                Request.QueryString["Meses"],
                Request.QueryString["Ano"], 1);
        }
        if (Request.QueryString["param001"] == "5")
        {
            imp_reportes(
                Request.QueryString["Impresora_Excel"],
                Request.QueryString["Institucion"],
                Request.QueryString["Proyecto"],
                Request.QueryString["Meses"],
                Request.QueryString["Ano"], 2);
        }
        if (Request.QueryString["param001"] == "6")
        {
            imp_reportes();
        }
        if (Request.QueryString["param001"] == "7")
        {
            imp_reporteEstadistico();
        }

        if (Request.QueryString["param001"] == "8")
        {
            imp_definicionCausalIngreso();
        }
    }

    private void imp_definicionCausalIngreso()
    {
        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.ContentType = "application/pdf";
        this.Response.WriteFile(ConfigurationSettings.AppSettings["PathDefinicionCausal"].ToString());
        this.Response.Flush();
        this.Response.Close();
    }

    private void imp_reporteEstadistico()
    {
        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.ContentType = "application/pdf";
        this.Response.WriteFile(StrPath);        
        this.Response.Flush();
        this.Response.Close();
    }

    private void imp_reportes()
    {
        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument crReporteEventos = new ReportDocument();

        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";

        crReporteEventos.Load(@rptPath + "crReporte_PII_Atendidos.rpt");
        crReporteEventos.SetDataSource(dtReporte);
        crReporteEventos.Refresh();

        string Fname = rptPath + "crReporte_PII_Atendidos" +
                Session.SessionID.ToString() +
                Convert.ToString(DateTime.Today.Year) +
                Convert.ToString(DateTime.Today.Day) +
                Convert.ToString(DateTime.Today.Month) +
                Convert.ToString(DateTime.Now.Minute) +
                Convert.ToString(DateTime.Now.Second) + ".pdf";
            //ConfigurationSettings.AppSettings["PathReportes"].ToString() + "crReporte_PII_Atendidos.rpt";

        crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
        crDiskFileDestinationOptions.DiskFileName = Fname;
        crExportOptions = crReporteEventos.ExportOptions;
        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

        crReporteEventos.Export();
        crReporteEventos.Dispose();

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

    private void imp_reportes(
        String Impresora_Excel,
        String AnoPresupuestario,
        String Monto,
        String NumeroCheque,
        String Institucion,
        String Proyecto,
        String CodProyecto,
        String RutNumeroProyecto,
        String Banco,
        String CuentaCorriente,
        String Plazas,
        String SaldoAnterior,
        String TotalDisponible,
        String SaldoDisponible,
        String Meses,
        String Ano)
    {
        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
        DataTable dtIngresosResumen = new DataTable();
        dtIngresosResumen = DTingresoResumen;
        DataTable dtEgresosResumen = new DataTable();
        dtEgresosResumen = DTegresoResumen;

        DataSet dS = new DataSet();
        dS.Tables.Add(dtEgresosResumen);
        dS.Tables.Add(dtIngresosResumen);

        dS.Tables[0].TableName = "DatosEgreso";
        dS.Tables[1].TableName = "DatosIngreso";
        dS.DataSetName = "dsRendicionCuentas";

        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument crReportDocument = new ReportDocument();

        //crReportDocument.Load(@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crRendicionCuentas.rpt");
        crReportDocument.Load(@rptPath + "crRendicionCuentas.rpt");

        string strSiNo = "";
        crReportDocument.Subreports["srptRendicionIngresos"].SetDataSource(dS);
        if (dS.Tables[1].Rows.Count == 0) strSiNo = "S"; else strSiNo = "N";
        crReportDocument.Subreports["srptRendicionIngresos"].DataDefinition.FormulaFields["bMostrarRendicionIngreso"].Text = "'" + strSiNo + "'";
        crReportDocument.Subreports["srptRendicionEgresos"].SetDataSource(dS);
        if (dS.Tables[0].Rows.Count == 0) strSiNo = "S"; else strSiNo = "N";
        crReportDocument.Subreports["srptRendicionEgresos"].DataDefinition.FormulaFields["bMostrarRendicionEgresos"].Text = "'" + strSiNo + "'";
        crReportDocument.Refresh();

        crReportDocument.DataDefinition.FormulaFields["AnoPresupuestario"].Text = "'" + AnoPresupuestario + "'";
        crReportDocument.DataDefinition.FormulaFields["MontoReintegro"].Text = "'" + Monto + "'";
        crReportDocument.DataDefinition.FormulaFields["NumeroCheque"].Text = "'" + NumeroCheque + "'";
        crReportDocument.DataDefinition.FormulaFields["RutInstitucion"].Text = "'" + RutNumeroProyecto + "'";
        crReportDocument.DataDefinition.FormulaFields["Institucion"].Text = "'" + Institucion + "'";
        crReportDocument.DataDefinition.FormulaFields["Proyecto"].Text = "'" + Proyecto + "'";
        crReportDocument.DataDefinition.FormulaFields["CodProyecto"].Text = "'" + CodProyecto + "'";
        crReportDocument.DataDefinition.FormulaFields["Banco"].Text = "'" + Banco + "'";
        crReportDocument.DataDefinition.FormulaFields["CuentaCorriente"].Text = "'" + CuentaCorriente + "'";
        crReportDocument.DataDefinition.FormulaFields["Plazas"].Text = "'" + Plazas + "'";
        crReportDocument.DataDefinition.FormulaFields["TotalAcumulado"].Text = "'" + SaldoAnterior + "'";
        crReportDocument.DataDefinition.FormulaFields["TotalDisponible"].Text = "'" + TotalDisponible + "'";
        crReportDocument.DataDefinition.FormulaFields["TotalCtaCte"].Text = "'" + SaldoDisponible + "'";
        crReportDocument.DataDefinition.FormulaFields["Mes"].Text = "'" + Meses + "'";
        crReportDocument.DataDefinition.FormulaFields["Anho"].Text = "'" + Ano + "'";
        crReportDocument.DataDefinition.FormulaFields["FechaRendicion"].Text = "'" + System.DateTime.Today.ToString() + "'";


        //string rptPath = @"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crRendicionCuentas" +
        rptPath = rptPath + "crRendicionCuentas" +
                Session.SessionID.ToString() +
                Convert.ToString(DateTime.Today.Year) +
                Convert.ToString(DateTime.Today.Day) +
                Convert.ToString(DateTime.Today.Month) +
                Convert.ToString(DateTime.Now.Minute) +
                Convert.ToString(DateTime.Now.Second) + ".pdf";

        crReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;

        crDiskFileDestinationOptions.DiskFileName = rptPath;
        crExportOptions = crReportDocument.ExportOptions;

        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

        crReportDocument.Export();
        crReportDocument.Dispose();

        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.ContentType = "application/pdf";
        this.Response.WriteFile(rptPath);
        this.Response.Flush();
        this.Response.Close();


        System.IO.File.Delete(rptPath);
        crReportDocument.Dispose();
        crReportDocument.Close();
    }
    private void imp_reportes(String Impresora_Excel, String Institucion, String Proyecto, String Meses, String Ano, int IE)
    {
        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString(); //@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
        //DataTable dtIngresosReporte = dtIngresosRPT;

        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument crReportDocument = new ReportDocument();

        if (IE==1)
            crReportDocument.Load(@rptPath + "crIngresos.rpt");
        else
            crReportDocument.Load(@rptPath + "crEgresos.rpt");

        crReportDocument.DataDefinition.FormulaFields["Institucion"].Text = "'" + Institucion + "'";
        crReportDocument.DataDefinition.FormulaFields["Proyecto"].Text = "'" + Proyecto + "'";
        crReportDocument.DataDefinition.FormulaFields["Mes"].Text = "'" + Meses + "'";
        crReportDocument.DataDefinition.FormulaFields["Anho"].Text = "'" + Ano + "'";

        if (IE == 1)
            crReportDocument.SetDataSource(dtIngresosRPT);
        else
            crReportDocument.SetDataSource(dtEgresosRPT);

        crReportDocument.Refresh();

        if (IE == 1)
            rptPath = rptPath + "crIngresos";
        else
            rptPath = rptPath + "crEgresos";

//        rptPath = rptPath + "crIngresos" +
        rptPath = rptPath + Session.SessionID.ToString() +
            Convert.ToString(DateTime.Today.Year) +
            Convert.ToString(DateTime.Today.Day) +
            Convert.ToString(DateTime.Today.Month) +
            Convert.ToString(DateTime.Now.Minute);

        if (Impresora_Excel == "1")
            rptPath += Convert.ToString(DateTime.Now.Second) + ".pdf";
        else
            rptPath += Convert.ToString(DateTime.Now.Second) + ".xls";

        if (IE == 1)
            crReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
        else
            crReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;

        crDiskFileDestinationOptions.DiskFileName = rptPath;
        crExportOptions = crReportDocument.ExportOptions;

        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

        if (Impresora_Excel == "1")
            crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        else
            crExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;

        crReportDocument.Export();
        crReportDocument.Dispose();

        this.Response.ClearContent();
        this.Response.ClearHeaders();

        if (Impresora_Excel == "1")
            this.Response.ContentType = "application/pdf";
        else
            this.Response.ContentType = "application/vnd.ms-excel";

        this.Response.WriteFile(rptPath);
        this.Response.Flush();
        this.Response.Close();


        System.IO.File.Delete(rptPath);
        crReportDocument.Dispose();
        crReportDocument.Close();
    }
}
