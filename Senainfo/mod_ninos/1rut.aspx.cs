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

public partial class mod_ninos_1rut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private string digitoVerificador(int rut)
    {
        int Digito;
        int Contador;
        int Multiplo;
        int Acumulador;
        string RutDigito;

        Contador = 2;
        Acumulador = 0;

        while (rut != 0)
        {
            Multiplo = (rut % 10) * Contador;
            Acumulador = Acumulador + Multiplo;
            rut = rut / 10;
            Contador = Contador + 1;
            if (Contador == 8)
            {
                Contador = 2;
            }

        }

        Digito = 11 - (Acumulador % 11);
        RutDigito = Digito.ToString().Trim();
        if (Digito == 10)
        {
            RutDigito = "K";
        }
        if (Digito == 11)
        {
            RutDigito = "0";
        }
        return (RutDigito);
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (TextBox1.Text.Length > 3)
            {
                string rutsinnada = TextBox1.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);
                
                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "")));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    Response.Write("BIEN");
                }
                else
                {
                    Response.Write("MAL");
                }
            }
            else
            {
                Response.Write("PARAMETRO INGRESADOR NO ES VALIDO");
            }
        }
        catch
        {
            Response.Write("PARAMETRO INGRESADOR NO ES VALIDO");
        }
    }
}
