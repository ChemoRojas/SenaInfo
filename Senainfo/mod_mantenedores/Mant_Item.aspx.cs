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

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox1.Text == "")
        {
            SqlDataSource2.DataBind();
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
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {

        //SqlDataSource2.InsertParameters["CodItem"].DefaultValue = Convert.ToString(45);
        SqlDataSource2.InsertParameters["Descripcion"].DefaultValue = TextBox2.Text;
        SqlDataSource2.InsertParameters["SubTitulo"].DefaultValue = TextBox3.Text;
        SqlDataSource2.InsertParameters["Debe_Haber"].DefaultValue = TextBox4.Text;

        if (CheckBox1.Checked == true)
            SqlDataSource2.InsertParameters["ItemPorDefecto"].DefaultValue = Convert.ToString(Convert.ToBoolean(1));
        else
            SqlDataSource2.InsertParameters["ItemPorDefecto"].DefaultValue = Convert.ToString(Convert.ToBoolean(0));

        SqlDataSource2.InsertParameters["IndVigencia"].DefaultValue = DropDownList1.SelectedValue;
        SqlDataSource2.Insert();
        SqlDataSource1.DataBind();
        SqlDataSource2.DataBind();

        Panel1.Visible = false;
        TextBox2.Text = "";
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_mantenedores.aspx");
    }
}
