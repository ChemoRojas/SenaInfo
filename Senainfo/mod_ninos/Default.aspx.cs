using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ninos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cerrar_sesion();
    }

    public void cerrar_sesion()
    {
        Response.Write("<script>parent.location.href='~/index.aspx';</script>");
    }
}