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
using System.Data.Common;
using System.Drawing;

public partial class mod_instituciones_RendicionDeCuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (Request.QueryString["f"] == "UmVnX0luZ3Jlc29zX0luc3RpdHVjaW9uZXM=")
            {
                //Formulario rendicion de cuenta Ingresos
                if (!window.existetoken("93212935-F018-4B05-8D0D-7D67B67CFF3B"))
                    Response.Redirect("~/logout.aspx");
            }

            else if (Request.QueryString["f"] == "UmVnX0VncmVzb3NfSW5zdGl0dWNpb25lcw==")
            //Formulario rendicion de cuenta egresos
            {
                if (!window.existetoken("9DDBB7ED-19CB-4962-A2FE-DE4D6C5B8C32"))
                    Response.Redirect("~/logout.aspx");
            }

                //Formulario rendicion de cuenta instituciones
            else if (Request.QueryString["f"] == "UmVnX1JlbmRpY2lvbl9JbnN0aXR1Y2lvbmVz")
            {
                if (!window.existetoken("09B7EC80-B028-4F5E-89E3-AA6AB005FAC7"))
                    Response.Redirect("~/logout.aspx");
            }

        }
    }
}