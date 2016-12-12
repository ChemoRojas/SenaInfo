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


public partial class mod_ninos_MensajeEgreso : System.Web.UI.Page
{
    public String msgEgreso
    {
        get { return (String)Session["msgEgreso"]; }
        set { Session["msgEgreso"] = value; }
    }
    public String nombreNinoEgreso
    {
        get { return (String)Session["nombreNinoEgreso"]; }
        set { Session["nombreNinoEgreso"] = value; }
    }

    string dir;


    protected void Page_Load(object sender, EventArgs e)
    {
        dir = Request.QueryString["dir"];

        

        if (!IsPostBack)
        {
            if (msgEgreso!= null)
            { 
            //    lbl_msjegreso.Text = msgEgreso;
                li_pendiente.Controls.Add(new LiteralControl(msgEgreso)); 
            }
            if(nombreNinoEgreso != null)
            { lbl_nino.Text = nombreNinoEgreso; }
        }
    }

    protected void btnCancelarBusqueda_NEW_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);
    }
}

