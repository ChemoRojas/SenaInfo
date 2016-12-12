using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cerrar_sesion();
    }

    public void cerrar_sesion()
    {
        Session.Clear();
        Session.Remove("NNANombres");
        Session.Remove("NNAApellidoPaterno");
        Session.Remove("NNAApellidoMaterno");
        Session.Remove("NNACodProyecto");
        Session.Remove("NNACodInstitucion");
        Session.Remove("NNASexo");
        Session.Remove("NNARutNino");
        Session.Remove("NNACodNino");
        Session.Remove("NNAFechaNacimiento");
        Response.Write("<script>parent.location.href='autenticacion.aspx';</script>");
    }
}