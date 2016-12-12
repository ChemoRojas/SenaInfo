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

public partial class mod_ninos_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("6F360136-E048-44FA-828E-E62CE3BDE05F"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                 validatescurity();
                }
            }
        }
    }
    private void validatescurity()
    {
       //DCE10CD5-8F3E-42F6-818C-9827C89A2FCD 2.6_INGRESAR
        if (!window.existetoken("DCE10CD5-8F3E-42F6-818C-9827C89A2FCD"))
        {
            Imb_NuevoPlan.Visible = false;
        }
        
    }

    protected void Imb_gestionPlan_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("pi_gestion.aspx");
    }
    protected void Imb_NuevoPlan_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("plan_intervencion_new.aspx");
    }
}
