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

public partial class mod_coordinadores_index_coordinadores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void Imb_ingreso_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ingreso_coordinadores.aspx");
    }
    protected void Imb_reportes_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("../mod_reportes/Rep_Informes_Coordinador.aspx");
    }
    
    protected void imgbtn_ingresar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("coordinadores_ingreso.aspx");
    }
    protected void imgbtn_modificar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("New_CoordinadoresModif.aspx");
    }
}
