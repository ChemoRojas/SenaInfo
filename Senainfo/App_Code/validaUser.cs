using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for validaUser
/// </summary>
public class validaUser
{
	public validaUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string neo_usuario;
    public string usuario
    {
        get { return neo_usuario; }
        set { neo_usuario = value; }
    }
    private string neo_contrasena;
    public string contrasena
    {
        get { return neo_contrasena; }
        set { neo_contrasena = value; }
    }
}
