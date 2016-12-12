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
/// 15/12/2014
/// Juan Valenzuela.
/// Se crea clase MuestraMensaje para activar o desactivar Label de mensajes al usuario, 
/// y asignar el texto deseado al mensaje.
/// </summary>
public class MuestraMensaje
{
    public Label Mensaje = new Label();
    
    public MuestraMensaje()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public void Mostrar(string texto)
    {
        Mensaje.Text = texto;
        Mensaje.Visible = true;
    }
    public void Ocultar()
    {
        Mensaje.Text = "";
        Mensaje.Visible = false;
    }

}
