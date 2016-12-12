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
using System.Drawing;
using Argentis.Regmen;


public partial class mod_ninos_ninos_HistoricodeDiagnosticos : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }

            else
            {
                ninocoll ncoll = new ninocoll();

                DataTable dt = ncoll.callto_historico_ingresos(SSninoDiag.CodNino);
                DataView dv = new DataView(dt);
                grd001.DataSource = dv;
                grd001.DataBind();
                //gfontbrevis: si no hay registro, hacer invisible boton exportar e indicar que no hay registro.
                if (grd001.Rows.Count < 1)
                {
                    lblmsg.Visible = true;
                    Webimagebutton2.Visible = false;
                }
            }
        }
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
    protected void btn_exelHistoricoNino_Click(object sender, ImageClickEventArgs e)
    {
        ExportarExcel();
    }
    protected void wibtnprint_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();

        DataTable dt = ncoll.callto_historico_ingresos(SSninoDiag.CodNino);
        DataView dv = new DataView(dt);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Ninos_Historico.xls");
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

    private void ExportarExcel() //recibe el html de la grilla
    {
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=AsistenciaMensual.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        grd001.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    } 

}



