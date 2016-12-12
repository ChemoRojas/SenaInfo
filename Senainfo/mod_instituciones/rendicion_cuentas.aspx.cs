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

public partial class mod_instituciones_rendicion_cuentas : System.Web.UI.Page
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
                if (!window.existetoken("D889FD88-85E5-450B-B77C-961598E659F7"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reg_Ingresos.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reg_egresos.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reg_Rendicion.aspx");
    }
    private void validatescurity()
    {
        //E73B1051-C725-4C6C-A226-0D069582367C 1.9.1
        if (!window.existetoken("E73B1051-C725-4C6C-A226-0D069582367C"))
            ImageButton1.Visible = false;
        //F5E94FD8-7C0D-475C-81AB-D30159E5C8FE 1.9.2
        if (!window.existetoken("F5E94FD8-7C0D-475C-81AB-D30159E5C8FE"))
            ImageButton2.Visible = false;
        //127ED738-05E2-4843-96DD-827002DD8237 1.9.3
        if (!window.existetoken("127ED738-05E2-4843-96DD-827002DD8237"))
            ImageButton3.Visible = false;

        //09B7EC80-B028-4F5E-89E3-AA6AB005FAC7 1.9.5 Rendicion Cuenta Instituciones
        if (!window.existetoken("09B7EC80-B028-4F5E-89E3-AA6AB005FAC7"))
            ImageButton6.Visible = false;
        
        //93212935-F018-4B05-8D0D-7D67B67CFF3B 1.9.3 Rendicion Cuenta Instituciones Ingresos
        if (!window.existetoken("93212935-F018-4B05-8D0D-7D67B67CFF3B"))
            ImageButton4.Visible = false;

        //9DDBB7ED-19CB-4962-A2FE-DE4D6C5B8C32 1.9.4 Rendicion Cuenta Instituciones Egresos
        if (!window.existetoken("9DDBB7ED-19CB-4962-A2FE-DE4D6C5B8C32"))
            ImageButton5.Visible = false;
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reg_Ingresos_Instituciones.aspx");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reg_Egresos_Instituciones.aspx");
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reg_Rendicion_Instituciones.aspx");
    }
}
