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

public partial class mod_ninos_index_ninos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!window.existetoken("15152ADB-D98E-4D32-BFD5-4333DBC1ED78"))
        {
            Response.Redirect("autenticacion.aspx");
        }

        validatescurity();
    }
    protected void Imb_Ninos_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_index.aspx");
        Response.Redirect("inferior_menu.htm?Target=bottomFrame");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DatosdeGestion.aspx");
    }
    protected void Imb_DiagNiño_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_diagnosticoninos.aspx");
    }
    protected void Imb_Cierre_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("cierre_movmensual.aspx");
    }
    protected void Imb_Planes_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("index_pintervencion.aspx");
    }
    protected void Imb_Egresos_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_egreso.aspx");
    }
    protected void Imb_Direccion_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_direccionnino.aspx");
    }
    protected void Imb_NinoVisitado_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_visitados.aspx");
    }
    protected void Imb_NinoRelac_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_relacionados.aspx");
    }
    protected void Imb_ADN_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ninos_adn.aspx");
    }

    private void validatescurity()
    {
        //053760A4-E027-40D6-8F8A-3F8A64DD075C 2.1 
        //79270734-C383-487D-8EAB-BC63F1521932 2.2
        //3FE17A39-80A0-4F7A-9A46-EC2BB934697D 2.3
        //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5
        if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C")|| window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") )
        {
            Imb_Ninos.Visible = true;
        }
        else
        {
            Imb_Ninos.Visible = false;
        }
        if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") )
        {
            ImageButton1.Visible = false;
        }
        if (!window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D")) // || !window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            Imb_DiagNiño.Visible = false;
            
        }
        //6F360136-E048-44FA-828E-E62CE3BDE05F 2.6
        if (!window.existetoken("6F360136-E048-44FA-828E-E62CE3BDE05F"))
        {
            Imb_Planes.Visible = false;
        }
        //8A25E23A-114B-4CDE-9C26-A0567B2A4D77 2.7
        if (!window.existetoken("8A25E23A-114B-4CDE-9C26-A0567B2A4D77"))
        {
            Imb_Egresos.Visible = false;
        }
        //07175B93-AD3C-45C4-A5BB-85A1EF272AF4 2.8
        if (!window.existetoken("07175B93-AD3C-45C4-A5BB-85A1EF272AF4"))
        {
            Imb_Cierre.Visible = false;
        }
        //61736ABB-4B02-4DA0-AD99-C5C7114DBB5D 2.9
        if (!window.existetoken("61736ABB-4B02-4DA0-AD99-C5C7114DBB5D"))
        {
            Imb_NinoRelac.Visible = false;
        }
        //749D2D91-2F3C-4AEE-9148-42B94C4A53CA 2.10
        if (!window.existetoken("749D2D91-2F3C-4AEE-9148-42B94C4A53CA"))
        {
            Imb_NinoVisitado.Visible = false;
        }
        //6F447A62-BF21-4ADA-A29D-FC485AA5CE70 2.11
        if (!window.existetoken("6F447A62-BF21-4ADA-A29D-FC485AA5CE70"))
        {
            Imb_Direccion.Visible = false;
        }
        if (!window.existetoken("B0803670-B908-4301-B01A-7B0FA6F360B9"))
        {
            Imb_adn.Visible = false;
        }
        if (!window.existetoken("80B8FE09-8BC5-4738-90AB-A1C38DE50063"))
        {
            imb_Faltas.Visible = false;
        }
    }



    protected void Imb_ADN_Click1(object sender, ImageClickEventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../mod_faltas/registro_faltas.aspx");
    }
}
