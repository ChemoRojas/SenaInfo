using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NinosEnProyecto : System.Web.UI.Page
{
    public string autocom;

    protected void Page_Load(object sender, EventArgs e)
    {
        validatescurity();
        alert.Visible = false;
        traer_ninos();
    }

    private void validatescurity()
    {
        if (!window.existetoken("15152ADB-D98E-4D32-BFD5-4333DBC1ED78"))
        {
            Response.Redirect("index.aspx");
        }
    }

    public void traer_ninos()
    {
        DataTable dt = new DataTable();

        string message = "";
        int cantidad = 0;

        Conexiones con = new Conexiones();
        dt = con.TraerDataTable("NinosEnProyecto", 39185);

        message = message + "<ul>";
        foreach (DataRow row in dt.Rows)
        {
            message += "<li>";
            message += "<a href='ResumenNNA.aspx?icodie=" + row["ICodIE"] + "'>" + "(" + row["ICodIE"] + ") - " + row["autocomplete"] + "</a>";
            message += "</li>";
            autocom += "'(" + row["ICodIE"] + ") - " + row["autocomplete"] + "', ";
            cantidad++;
        }
        message = message + "</ul>";

        autocom = autocom.Substring(0, autocom.Length-2);
        NNAVigentes.Text = message;
        CantidadNNA.Text = cantidad.ToString();
        TotalNNA.Text = cantidad.ToString();
        con.Desconectar();
    }

    protected void bt_selecionarNNA_Click(object sender, EventArgs e)
    {
        if (tags.Text == "")
        {
            alert.Visible = true;
            lb_busqueda.Text = "<strong>Atención:</strong> Debe Seleccionar un Niño, Niña o Adolescente";
        }
        else
        {
            string aux = tags.Text.ToString();
            aux = aux.Substring(1, 7);
            Response.Redirect("ResumenNNA.aspx?icodie=" + aux);
        }
        
    }

    protected void bt_limpiar_Click(object sender, EventArgs e)
    {
        alert.Visible = false;
        lb_busqueda.Text = "";
        tags.Text = "";
        tags.Focus();
    }
}