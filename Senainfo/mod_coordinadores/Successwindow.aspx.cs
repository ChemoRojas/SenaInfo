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

public partial class mod_coordinadores_Successwindow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    //protected void btn_volver_Click(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["pag"] != null)
    //    {
    //        if (Request.QueryString["pag"].ToString() == "ingreso")
    //        {
    //            Response.Redirect("Coordinadores_Ingreso.aspx");
    //        }
    //        else
    //        {
    //            Response.Redirect("New_CoordinadoresModif.aspx");
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect("index_coordinadores.aspx");
    //    }
    //}
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["pag"] != null)
        {
            if (Request.QueryString["pag"].ToString() == "ingreso")
            {
                Response.Redirect("Coordinadores_Ingreso.aspx");
            }
            else
            {
                Response.Redirect("New_CoordinadoresModif.aspx");
            }
        }
        else
        {
            Response.Redirect("index_coordinadores.aspx");
        }
    }
}
