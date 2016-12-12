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

public partial class mod_reportes_Rep_VigenciaDiariaCentros : System.Web.UI.Page
{
    public DataTable dtReporte
    {
        get { return (DataTable)Session["dtReporte"]; }
        set { Session["dtReporte"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }

        else
        {
            // JOVM - 29/12/2014
            //cal_Nacim.MaxDate = DateTime.Now;
            //txtFecha.Text = DateTime.Now.ToString();
        }
    }
   
    protected void imb_limpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
    protected void imb_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
    }
    
    private void Limpiar()
    {
        // JOVM - 29/12/2014
        //cal_Nacim.Value = "Seleccione Fecha";
        txtFecha.Text = "";
    }
    private void Imprimir()
    {
        try
        {
            ReporteNinoColl rI = new ReporteNinoColl();

            dtReporte = rI.callto_asistenciadiariaaadd_2(Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(Session["IdUsuario"]));
            DataTable dtAsistencia = dtReporte;

            if (dtAsistencia.Rows.Count > 0)
            {
                ExportOptions crExportOptions = new ExportOptions();
                DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ReportDocument crReporteEventos = new ReportDocument();

                string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
                DateTime dFecha = Convert.ToDateTime(txtFecha.Text);

                crReporteEventos.Load(@rptPath + "crVigenciaDiaria.rpt");
                //  crReporteEventos.DataDefinition.FormulaFields["FechaVigencia"].Text = "date(" + dFecha.Year + "," + dFecha.Month + "," + dFecha.Day + ")";
                crReporteEventos.SetDataSource(dtAsistencia);
                crReporteEventos.Refresh();

                string Fname = ConfigurationSettings.AppSettings["PathReportes"].ToString() + "crVigenciaDiaria.pdf";//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crCatastroJueces.pdf";
                crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
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
                System.IO.File.Delete(Fname);
                crReporteEventos.Dispose();
                crReporteEventos.Close();
            }
            else
            {
                alerts.Visible = true;
                lblError.Visible = true;
                lblError.Text = "No se Encotraros Coincidencias...";
            }
        }
        catch (Exception ex)
        {
            alerts.Visible = true;
            lblError.Visible = true;
            //lblError.Text = ex.Message + " " + ex.InnerException;
            lblError.Text = "No se encuentran registros con la fecha selecionada...";
        }
      
    }

    /*-----------------------------------------------------------------------------------------
    // 29/12/2014
    // Juan Valenzuela.
    // Se modifican botones para descartar uso de libreria Infragistics.
    //-----------------------------------------------------------------------------------------*/

    protected void btnImprimir_NEW_Click(object sender, EventArgs e)
    {
        if (txtFecha.Text == "")
        {
            txtFecha.BackColor = System.Drawing.Color.Yellow;
        }
        else
        {
            txtFecha.BackColor = System.Drawing.Color.White;
            Imprimir();
        }
    }
    protected void btnVolver_NEW_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
    }
    protected void btnLimpiar_NEW_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
}
