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
    public DataTable dtResumenRendicionMensualFirma
    {
        get { return (DataTable)Session["dtResumenRendicionMensualFirma"]; }
        set { Session["dtResumenRendicionMensualFirma"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["param001"] == "1")
        {
            imp_reportes();
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
    }
    private void imp_reportes()
    {
        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString(); //@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
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

        //crReportDocument.Load(@rptPath + "crRendicionCuentasInstitucion.rpt");
        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["CodProyecto"].ToString()) != 0)
        {
            crReportDocument.Load(@rptPath + "crRendicionCuentasV03.rpt");
        }
        else
        {
            crReportDocument.Load(@rptPath + "crRendicionCuentasInstitucion.rpt");
        }

        string strSiNo = "";
        crReportDocument.SetDataSource(dtResumenRendicionMensualFirma);
        crReportDocument.Subreports["srptRendicionIngresos"].SetDataSource(dS);
        if (dS.Tables[1].Rows.Count == 0) strSiNo = "S"; else strSiNo = "N";
        crReportDocument.Subreports["srptRendicionIngresos"].DataDefinition.FormulaFields["bMostrarRendicionIngreso"].Text = "'" + strSiNo + "'";
        crReportDocument.Subreports["srptRendicionEgresos"].SetDataSource(dS);
        if (dS.Tables[0].Rows.Count == 0) strSiNo = "S"; else strSiNo = "N";
        crReportDocument.Subreports["srptRendicionEgresos"].DataDefinition.FormulaFields["bMostrarRendicionEgresos"].Text = "'" + strSiNo + "'";
        crReportDocument.Refresh();

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
        dtIngresosRPT = (DataTable)Session["dtIngresosRPT"];
        dtEgresosRPT = (DataTable)Session["dtEgresosRPT"];

        if ((dtIngresosRPT != null) || (dtEgresosRPT != null))
        {
            ExportOptions crExportOptions = new ExportOptions();
            DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            ReportDocument crReportDocument = new ReportDocument();

            if (IE == 1)
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
            {
                //   this.Response.ContentType = "application/pdf";
                this.Response.AddHeader("Content-Type", "application/pdf");
                this.Response.AddHeader("Content-Disposition", "attachment; filename=Reg_Reportes.pdf");
            }
            else
            {
                //this.Response.ContentType = "application/vnd.ms-excel";
                this.Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                this.Response.AddHeader("Content-Disposition", "attachment; filename=Reg_Reportes.xls");
            }
                

            this.Response.WriteFile(rptPath);
            this.Response.Flush();
            this.Response.Close();


            System.IO.File.Delete(rptPath);
            crReportDocument.Dispose();
            crReportDocument.Close();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox()", true);  
    }
}
