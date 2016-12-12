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

public partial class mod_institucion_Transferencias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["param001"] != null)
        {
           string vsParametro = Request.QueryString["param001"];
           institucioncoll icoll = new institucioncoll();
           DataTable dt = icoll.GetTransferencia(Convert.ToInt32(vsParametro));
           if (dt.Rows.Count > 0)
           {
               WebDateTimeEdit1.Text = Convert.ToDateTime(dt.Rows[0][1]).ToString();
               lbl003.Text = Convert.ToString(dt.Rows[0][2]);
               lbl005.Text = "(" + vsParametro + ") " + Request.QueryString["param002"]; ;
           }
        }

    }

    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
}
