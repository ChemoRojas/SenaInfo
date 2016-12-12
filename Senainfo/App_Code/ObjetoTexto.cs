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
/// Se crea clase ObjetoTexto para manejar el color de fondo y foco de un textbox,
/// de acuerdo a las reglas de ingreso definidas.
/// </summary>
public class ObjetoTexto
{
    public TextBox CajaDeTexto= new TextBox();
	
    public ObjetoTexto()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
    }
    public void Blanquear()
    {
        CajaDeTexto.Text = " ";
    }
    public void DejarEnCero()
    {
        CajaDeTexto.Text = "0";
    }
    public void ApagaFondo()
    {
        CajaDeTexto.BackColor = System.Drawing.Color.White;
    }
    public void ResaltaFondo()
    {
        CajaDeTexto.BackColor = System.Drawing.Color.Yellow;
        CajaDeTexto.Focus();
    }
}
