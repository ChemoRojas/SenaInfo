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

public partial class mod_mesa_index_mesa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("3F536B45-ACCE-4623-AEEE-471FC199185D"))
            {
                Response.Redirect("~/logout.aspx"); ;
            }
        
        }
    }
    private void validatescurity()
    {
        //F6853F48-804C-47BD-8B43-4010F21F00ED 6.1_VER
        if (!window.existetoken("F6853F48-804C-47BD-8B43-4010F21F00ED"))
        {
            Imb_ResAtencion.Visible = false;
        }
        //EEC5380C-60B8-4E41-9B51-7BB60CA12C93 6.2_VER
        if (!window.existetoken("EEC5380C-60B8-4E41-9B51-7BB60CA12C93"))
        {
            Imb_MesaRectif.Visible = false;
        }
        //4A049F53-E5E6-4990-B6A3-FD62B81A51EB 6.3_VER
        if (!window.existetoken("4A049F53-E5E6-4990-B6A3-FD62B81A51EB"))
        {
            Imb_MesaRegenerar.Visible = false;
        
        }

    }
    protected void Imb_MesaRectif_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("mesa_rectificacionidentidad.aspx");
    }
    protected void Imb_MesaRegenerar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../mod_ninos/cierre_registroatencion.aspx");
    }
    protected void Imb_ResAtencion_Click(object sender, ImageClickEventArgs e)
    {

    }
}
