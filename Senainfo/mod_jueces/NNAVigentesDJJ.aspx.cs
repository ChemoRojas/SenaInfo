using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_jueces_NNAVigentesDJJ : System.Web.UI.Page
{
    public System.Data.DataTable dt = null;
    public int cantidad_registros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("055E1E1B-377B-4313-A875-3950AD9571EE"))
            {
                Response.Redirect("~/e403.aspx");
            }
        }
    }

    protected void lnb_buscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_run.Text) && string.IsNullOrEmpty(txt_apaterno.Text) && string.IsNullOrEmpty(txt_amaterno.Text) && string.IsNullOrEmpty(txt_nombres.Text))
        {
            lb_informacion.Text = "Debe completar al menos un criterio de busqueda.";
            LimpiarGrilla();
        }
        else
        {
            LimpiarGrilla();
            GetData();
            //lb_informacion.Text = "";
        }
    }

    private void GetData()
    {
        Conexiones con = new Conexiones();
        con.Autenticar();
        dt = con.TraerDataTable("VIGENTES_NNA_MINJUSTICIA_DJJ", txt_run.Text.Replace(".", "").ToString(), txt_apaterno.Text.ToString(), txt_amaterno.Text.ToString(), txt_nombres.Text.ToString());
        cantidad_registros = (int)dt.Rows.Count;

        if (cantidad_registros > 0 && cantidad_registros <= 50)
        {
            grd_resultado.DataSource = dt;
            grd_resultado.DataBind();
            grd_resultado.Visible = true;
            lnb_ExportarExcel.Visible = true;
            lb_informacion.Text = "Registros:" + cantidad_registros;

            grd_excel.DataSource = dt;
            grd_excel.DataBind();
        }
        else if (cantidad_registros >= 51)
        {
            lb_informacion.Text = "Debe acotar la busqueda.<br>Registros:" + cantidad_registros;
            LimpiarGrilla();
        }
        else
        {
            lb_mensaje.Text = "La consulta no ha arrojado resultados, pruebe cambiar/verificar los parametros.";
            LimpiarGrilla();
        }
    }

    private void LimpiarGrilla()
    {
        grd_resultado.DataSource = null;
        grd_resultado.Dispose();

        grd_excel.DataSource = null;
        grd_excel.Dispose();
    }

    protected void lbn_Limpiar_Click(object sender, EventArgs e)
    {
        txt_run.Text = "";
        txt_nombres.Text = "";
        txt_apaterno.Text = "";
        txt_amaterno.Text = "";
        lnb_ExportarExcel.Visible = false;
        alerts.Visible = false;
        lb_mensaje.Text = "";
        grd_resultado.DataSource = null;
        grd_resultado.Dispose();
        grd_resultado.Visible = false;
        grd_excel.DataSource = null;
        grd_excel.Dispose();
        lb_informacion.Text = "";
        cantidad_registros = 0;
    }

    protected void lnb_ExportarExcel_Click(object sender, EventArgs e)
    {
        grd_excel.Visible = true;

        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "UTF-8";
        string FileName = "NNAVigentesDJJ.xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //grd_resultado.GridLines = GridLines.Both;
        //grd_resultado.HeaderStyle.Font.Bold = true;
        //grd_resultado.RenderControl(htmltextwrtter);
        grd_excel.GridLines = GridLines.Both;
        grd_excel.HeaderStyle.Font.Bold = true;
        grd_excel.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

        grd_excel.Visible = false;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}