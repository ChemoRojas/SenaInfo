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
using System.Drawing;

public partial class mod_reportes_Rep_Diag_Ninos_Rep_ReportesLRPA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial


        if (!IsPostBack)
        {
            # region Valida Usuraio
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                //    GetData();
                //    imb_002d.Visible = false;
                //    validatescurity();

                ddown001.Attributes.Add("onchange", "carga()");

            }
            #endregion
        }
        # endregion
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        if (ddown001.SelectedValue == "0")
        {
            Validate();
        }
        else if (ddown001.SelectedValue == "1")
        {
            Response.Redirect("../mod_reportes/Rep_OcupacionDiariaCentros.aspx");
        }
        else if (ddown001.SelectedValue == "2")
        {
            Response.Redirect("../mod_reportes/Rep_NominaAdolescente.aspx");
        }
        else if (ddown001.SelectedValue == "3")
        {
            Response.Redirect("../mod_reportes/Rep_VigenciaDiariaCentros.aspx");
        }
        else
        {
            Response.Redirect("../mod_reportes/Rep_InfraccionDisciplinaria.aspx");
        }*/
        RegisterClientScriptBlock("carga", arma_script(ddown001.SelectedValue));
    }
    private string arma_script(string ruta)
    {

        string script = "<script> ";
        script += @" iframe = window.document.getElementById(""LRPA""); ";
        script += " var link ='" + ruta + "';";
        script += " iframe.src = link; ";
        script += " </script>";
        return script;

    }

    private void validate()
    {
        if (ddown001.SelectedValue == "0")
        {
            ddown001.BackColor = System.Drawing.Color.Yellow;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;
        }
    }

    /*-----------------------------------------------------------------------------------------
    // 29/12/2014
    // Juan Valenzuela.
    // Se modifican botones para descartar uso de librería Infragistics.
    //-----------------------------------------------------------------------------------------*/


    protected void btnVolver_NEW_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/Index_Reportes.aspx");
    }
    protected void btnLimpiar_NEW_Click(object sender, EventArgs e)
    {
        ddown001.BackColor = System.Drawing.Color.White;
        ddown001.SelectedValue = "0";
    }
    protected void btnBuscar_NEW_Click(object sender, EventArgs e)
    {

    }
}
