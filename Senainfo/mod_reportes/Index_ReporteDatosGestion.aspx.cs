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

public partial class mod_reportes_Index_ReporteDatosGestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // ddown001.Attributes.Add("onchange", "carga()");
        }
    }


    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
       // RegisterClientScriptBlock("carga", arma_script(ddown001.SelectedValue));
    }
    private string arma_script(string ruta)
    {

        string script = "<script> ";
        script += @" iframe = window.document.getElementById(""gestion""); ";
        script += " var link ='"+ruta+"';";
        script += " iframe.src = link; ";
        script += " </script>";
        return script;

    }

    //protected void btn_volver_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../mod_reportes/index_reportes.aspx");
    //}
}
