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

public partial class Mant_EnfermedadesCronicas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox1.Text == "")
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
        }
        else
        {
            SqlDataSource2.DataBind();
            GridView2.Visible = true;
            GridView1.Visible = false;
        }
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        SqlDataSource1.InsertParameters["Descripcion"].DefaultValue = TextBox2.Text;
        SqlDataSource1.InsertParameters["IndVigencia"].DefaultValue = DropDownList1.SelectedValue;
        SqlDataSource1.Insert();

        Panel1.Visible = false;
        TextBox2.Text = "";
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = false;
        TextBox2.Text = "";
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_mantenedores.aspx");
    }
}
