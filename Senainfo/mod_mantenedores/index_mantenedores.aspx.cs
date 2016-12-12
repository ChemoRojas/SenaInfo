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

public partial class Mantenedores_index_mantenedores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            carga_grilla();

        }



    }
    private void carga_grilla()
    {
        parcoll par = new parcoll();
        DataTable dt = par.GetParmantenedores();
        DataView dv = new DataView(dt);

        grd001.Page.Items.Clear();
        if (txt_buscar.Text.Trim() != "")
        {
            dv.RowFilter = "Descripcion LIKE '" + txt_buscar.Text.ToUpper() + "%'";
        }


        dv.Sort = "Descripcion";
        grd001.DataSource = dv;
        grd001.DataBind();


    }

    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            Response.Redirect("Mant_" + grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text + ".aspx");

        }
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        carga_grilla();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        carga_grilla();
    }
}
