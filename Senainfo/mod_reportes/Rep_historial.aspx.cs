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



public partial class Reportes_Rep_historial : System.Web.UI.Page
{
    public DataTable dtReporte
    {
        get { return (DataTable)Session["dtReporte"]; }
        set { Session["dtReporte"] = value; }
    }
    public DataTable dtHisEscolar
    {
        get { return (DataTable)Session["dtHisEscolar"]; }
        set { Session["dtHisEscolar"] = value; }
    }
    public DataTable dtHisMaltrato
    {
        get { return (DataTable)Session["dtHisMaltrato"]; }
        set { Session["dtHisMaltrato"] = value; }
    }
    public DataTable dtHisDroga
    {
        get { return (DataTable)Session["dtHisDroga"]; }
        set { Session["dtHisDroga"] = value; }
    }
    public DataTable dtHisPsicologico
    {
        get { return (DataTable)Session["dtHisPsicologico"]; }
        set { Session["dtHisPsicologico"] = value; }
    }
    public DataTable dtHisSocial
    {
        get { return (DataTable)Session["dtHisSocial"]; }
        set { Session["dtHisSocial"] = value; }
    }
    public DataTable dtHisCapacitacion
    {
        get { return (DataTable)Session["dtHisCapacitacion"]; }
        set { Session["dtHisCapacitacion"] = value; }
    }
    public DataTable dtHisLaboral
    {
        get { return (DataTable)Session["dtHisLaboral"]; }
        set { Session["dtHisLaboral"] = value; }
    }
    public DataTable dtHisJudiciales
    {
        get { return (DataTable)Session["dtHisJudiciales"]; }
        set { Session["dtHisJudiciales"] = value; }
    }
    public DataTable dtHisPfti
    {
        get { return (DataTable)Session["dtHisPfti"]; }
        set { Session["dtHisPfti"] = value; }
    }
    public DataTable dtHisDiscapacidad
    {
        get { return (DataTable)Session["dtHisDiscapacidad"]; }
        set { Session["dtHisDiscapacidad"] = value; }
    }
    public DataTable dtHisSalud
    {
        get { return (DataTable)Session["dtHisSalud"]; }
        set { Session["dtHisSalud"] = value; }
    }
    public DataTable dtHisEnfermedades
    {
        get { return (DataTable)Session["dtHisEnfermedades"]; }
        set { Session["dtHisEnfermedades"] = value; }
    }
    public DataTable dtHisPersonas
    {
        get { return (DataTable)Session["dtHisPersonas"]; }
        set { Session["dtHisPersonas"] = value; }
    }
    
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
                if (!window.existetoken("6490EDC0-B9A2-44B5-94F0-E5222FB6E3DD"))
                {

                    Response.Redirect("~/logout.aspx");

                }
            }
            lbl_error.Visible = false;
        }
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }

    protected void btn_imprimir_Click(object sender, EventArgs e)
    {

        if (Wcodnino.Text.Trim() == "")
        {
            lbl_error.Visible = true;
            lbl_error.Text = "Debe Ingresar Código del Niño a Buscar";
            Wcodnino.Focus();
            return;
        }
        
        ReporteNinoColl rI = new ReporteNinoColl();
        DataSet ds = new DataSet();

        dtReporte = rI.Get_HisIngreso(Convert.ToInt32(Wcodnino.Text));
        DataTable dtHistorico = dtReporte;
        if (dtHistorico.Rows.Count > 0)
        {
            ds.Tables.Add(dtHistorico);
            ds.Tables[0].TableName = "dtHistorico";
        }

        int i = 1;

        if (chEscolar.Checked == true)
        {
            dtHisEscolar = rI.Get_HisEscolar(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHEscolar = dtHisEscolar;
            if (dtHEscolar.Rows.Count > 0)
            {
                ds.Tables.Add(dtHEscolar);
                ds.Tables[i].TableName = "dtHisEscolar"; i++;
            }
        }
        if (chMaltrato.Checked == true)
        {
            dtHisMaltrato = rI.Get_HisMaltrato(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHMaltrato = dtHisMaltrato;
            if (dtHMaltrato.Rows.Count > 0)
            {
                ds.Tables.Add(dtHMaltrato);
                ds.Tables[i].TableName = "dtHisMaltrato"; i++;
            }
        }
        if (chDrogas.Checked == true)
        {
                dtHisDroga = rI.Get_HisDroga(Convert.ToInt32(Wcodnino.Text));
                DataTable dtHDroga = dtHisDroga;
                if (dtHDroga.Rows.Count > 0)
                {
                    ds.Tables.Add(dtHDroga);
                    ds.Tables[i].TableName = "dtHisDroga"; i++;
                }
        }

        if (chPsicologico.Checked == true)
        {
            dtHisPsicologico = rI.Get_HisPsicologico(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHPsicologico = dtHisPsicologico;
            if (dtHPsicologico.Rows.Count > 0)
            {
                ds.Tables.Add(dtHPsicologico);
                ds.Tables[i].TableName = "dtHisPsicologico"; i++;
            }
        }

        if (chSocial.Checked == true)
        {
            dtHisSocial = rI.Get_HisSocial(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHSocial = dtHisSocial;
            if (dtHSocial.Rows.Count > 0)
            {
                ds.Tables.Add(dtHSocial);
                ds.Tables[i].TableName = "dtHisSocial"; i++;
            }
        }

        if (chCapacitacion.Checked == true)
        {
            dtHisCapacitacion = rI.Get_HisCapacitacion(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHCapacitacion = dtHisCapacitacion;
            if (dtHCapacitacion.Rows.Count > 0)
            {
                ds.Tables.Add(dtHCapacitacion);
                ds.Tables[i].TableName = "dtHisCapacitacion"; i++;
            }
        }

        if (chLaboral.Checked == true)
        {
            dtHisLaboral = rI.Get_HisLaboral(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHLaboral = dtHisLaboral;
            if (dtHisLaboral.Rows.Count > 0)
            {
                ds.Tables.Add(dtHisLaboral);
                ds.Tables[i].TableName = "dtHisLaboral"; i++;
            }
        }
        if (chJudiciales.Checked == true)
        {
            dtHisJudiciales = rI.Get_HisJudiciales(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHJudiciales = dtHisJudiciales;
            if (dtHJudiciales.Rows.Count > 0)
            {
                ds.Tables.Add(dtHJudiciales);
                ds.Tables[i].TableName = "dtHisJudiciales"; i++;
            }
        }

        if (chPfti.Checked == true)
        {

            dtHisPfti = rI.Get_HisPfti(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHPfti = dtHisPfti;
            if (dtHPfti.Rows.Count > 0)
            {
                ds.Tables.Add(dtHPfti);
                ds.Tables[i].TableName = "dtHisPfti"; i++;
            }
        }

        if (chCapacitacion.Checked == true)
        {
            dtHisDiscapacidad = rI.Get_HisDiscapacidad(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHDiscapacidad = dtHisDiscapacidad;
            if (dtHDiscapacidad.Rows.Count > 0)
            {
                ds.Tables.Add(dtHDiscapacidad);
                ds.Tables[i].TableName = "dtHisDiscapacidad"; i++;
            }
        }

        if (chHechosSalud.Checked == true)
        {
            dtHisSalud = rI.Get_HisSalud(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHSalud = dtHisSalud;
            if (dtHSalud.Rows.Count > 0)
            {
                ds.Tables.Add(dtHSalud);
                ds.Tables[i].TableName = "dtHisSalud"; i++;
            }
        }
        if (chEnfermedades.Checked == true)
        {

            dtHisEnfermedades = rI.Get_HisEnfermedades(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHEnfermedades = dtHisEnfermedades;
            if (dtHEnfermedades.Rows.Count > 0)
            {
                ds.Tables.Add(dtHEnfermedades);
                ds.Tables[i].TableName = "dtHisEnfermedades"; i++;
            }
        }

        if (chPersonasRelacionadas.Checked == true)
        {
            dtHisPersonas = rI.Get_HisPersonas(Convert.ToInt32(Wcodnino.Text));
            DataTable dtHPersonas = dtHisPersonas;
            if (dtHPersonas.Rows.Count > 0)
            {
                ds.Tables.Add(dtHPersonas);
                ds.Tables[i].TableName = "dtHisPersonas"; i++;
            }
        }

        ds.DataSetName = "dsHistorico";

  //----------------------------------------------------------------------------

        string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument crReportDocument = new ReportDocument();

        crReportDocument.Load(@rptPath + "THistorico.rpt");
        crReportDocument.Subreports["ingreso"].SetDataSource(ds);

        if (chEscolar.Checked == true ) 
        {
            crReportDocument.Subreports["DiagnosticoEscolar"].SetDataSource(ds);
        }
        if (chMaltrato.Checked == true)
        {
            crReportDocument.Subreports["DiagnosticoMaltrato"].SetDataSource(ds);
        }
        if (chDrogas.Checked == true)
        {
            crReportDocument.Subreports["DiagnosticoDroga"].SetDataSource(ds);
        }
        if (chPsicologico.Checked == true)
        {
            crReportDocument.Subreports["DiagnosticoPsicologico"].SetDataSource(ds);
        }
        if (chSocial.Checked == true)
        {
            crReportDocument.Subreports["DiagnosticoSocial"].SetDataSource(ds);
        }
        if (chCapacitacion.Checked == true)
        {
            crReportDocument.Subreports["Capacitacion"].SetDataSource(ds);
        }
        if (chLaboral.Checked == true)
        {
            crReportDocument.Subreports["SituacionLaboral"].SetDataSource(ds);
        }
        if (chJudiciales.Checked == true)
        {
            crReportDocument.Subreports["HechosJudiciales"].SetDataSource(ds);
        }
        if (chPfti.Checked == true)
        {
            crReportDocument.Subreports["PeoresFormas"].SetDataSource(ds);
        }
        if (chDiscapacidad.Checked == true)
        {
            crReportDocument.Subreports["Discapacidad"].SetDataSource(ds);
        }
        if (chHechosSalud.Checked == true)
        {
            crReportDocument.Subreports["HechosSalud"].SetDataSource(ds);
        }
        if (chEnfermedades.Checked == true)
        {
            crReportDocument.Subreports["Enfermedades"].SetDataSource(ds);
        }
        if (chPersonasRelacionadas.Checked == true)
        {
            crReportDocument.Subreports["PersonasRelacionadas"].SetDataSource(ds);
        }
      //  crReportDocument.Refresh();

        rptPath = rptPath + "HistorialNiño_" +
                Session.SessionID.ToString() +
                Convert.ToString(DateTime.Today.Year) +
                Convert.ToString(DateTime.Today.Day) +
                Convert.ToString(DateTime.Today.Month) +
                Convert.ToString(DateTime.Now.Minute) +
                Convert.ToString(DateTime.Now.Second) + ".pdf";

        crReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
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
        //////
    }


    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        lbl_error.Visible = false;
        Wcodnino.Text = "0";

        chEscolar.Checked = false;
        chMaltrato.Checked = false;
        chDrogas.Checked = false;
        chPsicologico.Checked = false;
        chSocial.Checked = false;
        chCapacitacion.Checked = false;
        chLaboral.Checked = false;
        chJudiciales.Checked = false;
        chPfti.Checked = false;
        chDiscapacidad.Checked = false;
        chHechosSalud.Checked = false;
        chEnfermedades.Checked = false;
        chPersonasRelacionadas.Checked = false;
    }
}
