using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        window.logout();
        string fuera = (string)ConfigurationManager.AppSettings["logout"].ToString();
        Response.Redirect(fuera);
    }
}