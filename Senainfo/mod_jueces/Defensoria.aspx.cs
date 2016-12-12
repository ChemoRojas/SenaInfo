using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_jueces_Defensoria : System.Web.UI.Page
{
    public System.Data.DataTable dt = null;
    public int cantidad_registros = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //B5173CC3-9837-4410-88FB-244483548B2F

        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("B5173CC3-9837-4410-88FB-244483548B2F"))
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
        dt = con.TraerDataTable("LRPA_Defensoria", txt_run.Text.Replace(".", "").ToString(), txt_apaterno.Text.ToString(), txt_amaterno.Text.ToString(), txt_nombres.Text.ToString());
        cantidad_registros = (int)dt.Rows.Count;

        if (cantidad_registros > 0 && cantidad_registros <= 50)
        {
            grd_resultado.DataSource = dt;
            grd_resultado.DataBind();
            grd_resultado.Visible = true;
            lnb_ExportarExcel.Visible = true;
            lb_informacion.Text = "Registros:" + cantidad_registros;
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
        lb_informacion.Text = "";
        cantidad_registros = 0;
    }

    protected void lnb_ExportarExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "UTF-8";
        string FileName = "Defensoria.xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        grd_resultado.GridLines = GridLines.Both;
        grd_resultado.HeaderStyle.Font.Bold = true;
        grd_resultado.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

}