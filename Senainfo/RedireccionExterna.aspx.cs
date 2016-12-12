using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RedireccionExterna : System.Web.UI.Page
{
    private static string destino = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (Request.QueryString["uri"] != string.Empty)
            {
                destino = window.Base64Decode(Request.QueryString["uri"].ToString());
                Session["RedireccionExterna"] = destino;
                lb_destino.Text = destino;
                Response.Redirect(destino);
            }
            else if (Request.QueryString["uri"] == string.Empty && Session["RedireccionExterna"].ToString() != string.Empty)
            {
                destino = Session["RedireccionExterna"].ToString();
                lb_destino.Text = destino;
                Response.Redirect(destino);
            }
            else
            {
                lb_destino.Text = "No se puede redireccionar, intente mas tarde.";
            }
        }
    }
}