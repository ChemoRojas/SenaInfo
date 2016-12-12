using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ccontrasena : System.Web.UI.Page
{
    private string usuario = "";
    private string contrasena = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NameValueCollection nvc = Request.Form;
            if (!string.IsNullOrEmpty(nvc["usuario"]) || !string.IsNullOrEmpty(nvc["password"]))
            {
                usuario = nvc["usuario"];
                contrasena = nvc["password"];
                cambiar();
            }
            else
            {
                lbl_aviso.Text = "Debe Completar Ambos Campos.";
                lbl_aviso.Visible = true;
            }
        }
    }

    protected void cambiar()
    { }
}