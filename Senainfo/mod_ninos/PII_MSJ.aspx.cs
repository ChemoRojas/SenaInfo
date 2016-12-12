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

public partial class mod_ninos_PII_MSJ : System.Web.UI.Page
{
    public DataTable DTPII
    {
        get { return (DataTable)Session["DTPII"]; }
        set { Session["DTPII"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["msj"] != null)
            {
                Label1.Text = Request.QueryString["msj"];
                Label1.Visible = true;
            }
            funcion_muestra_grilla();
        }
    }
    private void funcion_muestra_grilla()
    {

        pintervencion pint = new pintervencion();
        DataTable dt = pint.Get_PII_Resulta(DTPII);

        grd001.DataSource = dt;
        grd001.DataBind();
    
    }

    protected void imb003_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
}
