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


public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        if (DropDownList5.SelectedIndex == 0)
        {
            SqlDataSource5.DataBind();
            GridView2.Visible = true;
            GridView1.Visible = false;
        }
        else
        {
            SqlDataSource1.DataBind();
            GridView1.Visible = true;
            GridView2.Visible = false;
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        SqlDataSource1.InsertParameters["CodEstadoAbandono"].DefaultValue = DropDownList3.SelectedValue;
        SqlDataSource1.InsertParameters["CodSituacionTuicion"].DefaultValue = DropDownList4.SelectedValue;

        SqlDataSource1.Insert();
        SqlDataSource2.DataBind();
        SqlDataSource1.DataBind();

        Panel1.Visible = false;
        DropDownList3.SelectedIndex = 1;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void SqlDataSource5_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_mantenedores.aspx");
    }
}
