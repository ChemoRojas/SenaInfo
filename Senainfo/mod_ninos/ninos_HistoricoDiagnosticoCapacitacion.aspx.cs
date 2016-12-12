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
using Argentis.Regmen;


public partial class mod_ninos_ninos_HistoricoDiagnosticoCapacitacion : System.Web.UI.Page
{
    public nino SSninoDiag
    {
        get
        {
            if (Session["neo_SSninoDiag"] == null)
            { Session["neo_SSninoDiag"] = new nino(); }
            return (nino)Session["neo_SSninoDiag"];
        }
        set { Session["neo_SSninoDiag"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt = dcoll.Historico_diag_capacitacion(SSninoDiag.CodNino);
        DataView dv = new DataView(dt);
        //  dv.Sort = "AnoUltimoCursoAprobado";
        grdcapacitacion.DataSource = dv;
        grdcapacitacion.DataBind();
        //gfontbrevis: si no hay registro, hacer invisible boton exportar e indicar que no hay registro.
        if (grdcapacitacion.Rows.Count < 1)
        {
            lblmsg.Visible = true;
            btn_exelCapacitacion.Visible = false;
            
        }
    }
    protected void imb_Hescolar(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
    


    private void ExportarExcel() //recibe el html de la grilla
    {
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=Historico_Diagnostico_Capacitacion.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        grdcapacitacion.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btn_exelCapacitacion_Click(object sender, EventArgs e)
    {
        ExportarExcel();
    }
}