/*
 * 
 * GMP
 * 20/05/2015
 * Revisión, encontré todo ok
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

public partial class mod_recepcion_Default : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["CodProyecto"] != "" && Request.QueryString["AnoMes"] != "" && Request.QueryString["IdUsr"] != "")
        {
            if (Request.QueryString["TipoDocumento"] == "0")
                GeneraRC();
            else
                GeneraRAM();
        }
    }

    private void GeneraRC()
    {
        DTingresoResumen = new DataTable();
        DTegresoResumen = new DataTable();
        DTingresoResumen.Columns.Add("DescTipoIngreso", typeof(string));
        DTingresoResumen.Columns.Add("Monto", typeof(int));

        DTegresoResumen.Columns.Add("Descripcion", typeof(string));
        DTegresoResumen.Columns.Add("Monto", typeof(int));

        RendicionCuentasColl rC = new RendicionCuentasColl();

        DataTable dtResumenRendicionMensualFirma = new DataTable();
        dtResumenRendicionMensualFirma = rC.GetResumenRendicionMensualFirma(Request.QueryString["CodProyecto"], Convert.ToInt32(Request.QueryString["AnoMes"]));
        LlenaTablaIE(dtResumenRendicionMensualFirma, 1);
        imp_reportes(dtResumenRendicionMensualFirma);

    }

    private void GeneraRAM()
    {
        DataTable dt = getImpresionResumen(Convert.ToInt32(Request.QueryString["CodProyecto"]), Convert.ToInt32(Request.QueryString["AnoMes"]));

        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument reportDocument = new ReportDocument();

        ninocoll ncoll = new ninocoll();
        int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(Request.QueryString["CodProyecto"]));
        string rptName = "";

        if (CodModeloIntervencion == 83) rptName = "crResumenAtencionMensual_PAD.rpt"; else rptName = "crResumenAtencionMensual.rpt";

        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();
        reportDocument.Load(@rptPath + rptName);

        reportDocument.SetDataSource(dt);

        rptPath = rptPath + "crResumenAtencionMensual" +
                Session.SessionID.ToString() +
                Convert.ToString(DateTime.Today.Year) +
                Convert.ToString(DateTime.Today.Day) +
                Convert.ToString(DateTime.Today.Month) +
                Convert.ToString(DateTime.Now.Minute) +
                Convert.ToString(DateTime.Now.Second) + ".pdf";

        reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;

        crDiskFileDestinationOptions.DiskFileName = rptPath;
        crExportOptions = reportDocument.ExportOptions;

        crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

        reportDocument.Export();
        reportDocument.Dispose();

        this.Response.ClearContent();
        this.Response.ClearHeaders();
        this.Response.ContentType = "application/pdf";
        this.Response.WriteFile(rptPath);
        this.Response.Flush();
        this.Response.Close();

        System.IO.File.Delete(rptPath);
        reportDocument.Dispose();
        reportDocument.Close();
    }

    public DataTable getImpresionResumen(int CodProyecto, int MesAno)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_resumenatencionmensual_Firma_impresion";


        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = MesAno;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    protected void LlenaTablaIE(DataTable dtResumenRendicionMensualFirma, int AsignaTablas)
    {
        DataTable dtIngresos = new DataTable();
        DataTable dtEgresos = new DataTable();

        dtIngresos.Columns.Add("DescTipoIngreso", typeof(string));
        dtIngresos.Columns.Add("Monto", typeof(int));

        dtEgresos.Columns.Add("Descripcion", typeof(string));
        dtEgresos.Columns.Add("Monto", typeof(int));

        DataRow dr;
        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Subvencion"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "TRANSFERENCIA SUBVENCION";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Subvencion"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Remesa"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "TRANSFERENCIA REMESA";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Remesa"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Aguinaldos"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "OTROS APORTE SENAME AGUINALDOS";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Aguinaldos"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Otros"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "OTROS APORTE SENAME OTROS";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Otros"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_AportesInstituciones"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "INGRESOS DISTINTOS A SENAME APORTES INSTITUCIONES";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_AportesInstituciones"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Donaciones"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "INGRESOS DISTINTOS A SENAME DONACIONES";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Donaciones"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Otros"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "INGRESOS DISTINTOS A SENAME OTROS";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Otros"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosPersonal"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "GASTOS PERSONAL";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosPersonal"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosOperacion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "GASTOS OPERACIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosOperacion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosInversion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "GASTOS INVERSIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosInversion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Devolucion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "DEVOLUCIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Devolucion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["PagoProvisionPorIndemnizacion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "PAGO PROVISIÓN POR INDEMNIZACIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["PagoProvisionPorIndemnizacion"]);
            dtEgresos.Rows.Add(dr);
        }

        //txtTotalIngresos.ValueInt = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Ingresos"]);
        //txtTotalEgresos.ValueInt = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Egresos"]);

        if (AsignaTablas == 1)
        {
            DTingresoResumen = dtIngresos;
            DTegresoResumen = dtEgresos;
        }
    }
    private void imp_reportes(DataTable dtResumenRendicionMensualFirma)
    {
        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();
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

        crReportDocument.Load(@rptPath + "crRendicionCuentasV03.rpt");

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

}
