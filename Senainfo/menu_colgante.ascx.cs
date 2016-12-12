using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menu_colgante : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(userName) == false)
        {
            lbl_name.Text = "Usuario: " + userName;
            menu_dinamico.Text = Session["mm"].ToString();
        }
    }
        
    public string userName
    {
        get { return (string)Session["Usuario"]; }
        set { Session["Usuario"] = value; }
    }

    protected void lnk_CerrarSesion_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/logout.aspx");

    }
}