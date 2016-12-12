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
        SqlDataSource1.DataBind();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        SqlDataSource1.InsertParameters["CodInstrumentoDiagnostico"].DefaultValue = DropDownList4.SelectedValue;
        SqlDataSource1.InsertParameters["CodMedicionesDiagnosticas"].DefaultValue = DropDownList5.SelectedValue;

        SqlDataSource1.Insert();
        SqlDataSource1.DataBind();

        Panel1.Visible = false;
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_mantenedores.aspx");
    }
}
