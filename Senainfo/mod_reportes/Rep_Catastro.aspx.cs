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

public partial class Reportes_Rep_Catastro : System.Web.UI.Page
{
    public DataTable dtReporte
    {
        get { return (DataTable)Session["dtReporte"]; }
        set { Session["dtReporte"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        # region VALIDACION USUARIO
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("E298F94F-CDA5-4E3A-975F-1EBD35D418BF"))
                {
                    Response.Redirect("~/e403.aspx");
                }
            }

        }

    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (cal_inicio.Text == "")
            {
                cal_inicio.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
            }

            ReporteNinoColl rI = new ReporteNinoColl();
            //DataSet ds = new DataSet();

            dtReporte = rI.Get_CatastroColl(Convert.ToDateTime(cal_inicio.Text));
            DataTable dtCatastro = dtReporte;

            if (dtCatastro.Rows.Count > 0)
            {
                ExportOptions crExportOptions = new ExportOptions();
                DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ReportDocument crReporteEventos = new ReportDocument();

                string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
                DateTime dFecha = Convert.ToDateTime(cal_inicio.Text);

                crReporteEventos.Load(@rptPath + "crCatastroJueces.rpt");
                //  crReporteEventos.DataDefinition.FormulaFields["FechaVigencia"].Text = "date(" + dFecha.Year + "," + dFecha.Month + "," + dFecha.Day + ")";
                crReporteEventos.SetDataSource(dtCatastro);
                crReporteEventos.Refresh();

                string Fname = ConfigurationSettings.AppSettings["PathReportes"].ToString() + "crCatastroJueces.pdf";//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crCatastroJueces.pdf";
                crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                crDiskFileDestinationOptions.DiskFileName = Fname;
                crExportOptions = crReporteEventos.ExportOptions;
                crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                crReporteEventos.Export();
                crReporteEventos.Dispose();
                //System.Web.UI.Page sCDP = new Page();
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
                if (Convert.ToInt32(Session["contrasena"]) == 252)
                    ImpresionIndividual(dtReporte);
                lbl_error.Text = string.Empty;
                alerts.Visible = false;
                
            }
            else
            {
                lbl_error.Visible = true;
                lbl_error.Text = "No se han encontrado registros coincidentes";
                alerts.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //RPA
            lbl_error.Visible = true;
            alerts.Visible = true;
            lbl_error.Text = ex.Message;
        }
    }


    protected void ImpresionIndividual(DataTable dt)
    {
        String CodProyeto = string.Empty;
        String CodModeloIntervencion = string.Empty;
        try
        {
            foreach (DataRow row in dt.Rows)
            {

                //DataView dv = new DataView(dt.Select("select CodModeloIntervencion, codproyecto group by CodModeloIntervencion, codproyecto"));
                CodProyeto = row["CodProyecto"].ToString();
                CodModeloIntervencion = row["CodModeloIntervencion"].ToString();

                string Fname = ConfigurationSettings.AppSettings["PathCatastroJueces-FichaIndividual"].ToString() + "ProyectosModelos" + CodModeloIntervencion.ToString() + ".pdf";//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crCatastroJueces.pdf";

                if (!System.IO.File.Exists(Fname))
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "CodModeloIntervencion = " + CodModeloIntervencion.ToString();

                    ExportOptions crExportOptions = new ExportOptions();
                    DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    ReportDocument crReporteEventos = new ReportDocument();

                    string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
                    DateTime dFecha = Convert.ToDateTime(cal_inicio.Text);

                    crReporteEventos.Load(@rptPath + "crCatastroJueces-FichaIndividual.rpt");
                    crReporteEventos.SetDataSource(dv);
                    crReporteEventos.Refresh();

                    crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    crDiskFileDestinationOptions.DiskFileName = Fname;
                    crExportOptions = crReporteEventos.ExportOptions;
                    crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                    crReporteEventos.Export();
                    crReporteEventos.Dispose();
                    //this.Response.ClearContent();
                    //this.Response.ClearHeaders();
                    //this.Response.ContentType = "application/pdf";
                    //this.Response.WriteFile(Fname);
                    //this.Response.Flush();
                    //this.Response.Close();
                    //System.IO.File.Delete(Fname);

                    crReporteEventos.Close();
                }

                #region comentario
                //CodProyeto = row["CodProyecto"].ToString() ;
                //DataView dv = new DataView(dt);
                //dv.RowFilter = "CodProyecto = " + CodProyeto.ToString();

                //ExportOptions crExportOptions = new ExportOptions();
                //DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                //ReportDocument crReporteEventos = new ReportDocument();

                //string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
                //DateTime dFecha = Convert.ToDateTime(cal_inicio.Text);

                //crReporteEventos.Load(@rptPath + "crCatastroJueces-FichaIndividual.rpt");
                //crReporteEventos.SetDataSource(dv);
                //crReporteEventos.Refresh();

                //string Fname = ConfigurationSettings.AppSettings["PathCatastroJueces-FichaIndividual"].ToString() + CodProyeto.ToString() + ".pdf";//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crCatastroJueces.pdf";
                //crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                //crDiskFileDestinationOptions.DiskFileName = Fname;
                //crExportOptions = crReporteEventos.ExportOptions;
                //crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                //crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                //crReporteEventos.Export();
                //crReporteEventos.Dispose();
                ////this.Response.ClearContent();
                ////this.Response.ClearHeaders();
                ////this.Response.ContentType = "application/pdf";
                ////this.Response.WriteFile(Fname);
                ////this.Response.Flush();
                ////this.Response.Close();
                ////System.IO.File.Delete(Fname);

                //crReporteEventos.Close();
                #endregion
            }
            this.Response.ClearContent();
            //this.Response.ClearHeaders();
            this.Response.ContentType = "application/pdf";
            this.Response.Flush();
            this.Response.Close();
        }
        catch (Exception ex)
        {
            //RPA
            lbl_error.Visible = true;
            alerts.Visible = true;
            lbl_error.Text = ex.Message;
        }
    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
       
        
        cal_inicio.Text = string.Empty;
        cal_inicio.Text = "Seleccione fecha";
    }
}

        #endregion