﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class buscador : System.Web.UI.Page
{
    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor
        }
    }

    private DataTable resultadoBusqueda(string CodNino, string Rut, string Ruc, string ApellPaterno, string ApellMaterno, string Nombres)
    {
        Conexiones con = new Conexiones();
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getNinosBusqueda]";
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar).Value = Rut;
        sqlc.Parameters.Add("@nombres", SqlDbType.VarChar).Value = Nombres;
        sqlc.Parameters.Add("@apellidoPaterno", SqlDbType.VarChar).Value = ApellPaterno;
        sqlc.Parameters.Add("@apellidoMaterno", SqlDbType.VarChar).Value = ApellMaterno;
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar).Value = CodNino;
        sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = Ruc;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        dt1 = resultadoBusqueda(txtCodNino.Text, txtRun.Text, txtRuc.Text, txtApellPaterno.Text, txtApellMaterno.Text, txtNombre.Text);
        grdBusqueda.DataSource = dt1;

        grdBusqueda.DataBind();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodNino.Text = "";
        txtRun.Text = "";
        txtRuc.Text = "";
        txtApellPaterno.Text = "";
        txtApellMaterno.Text = "";
        txtNombre.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }

    protected void grdBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBusqueda.DataSource = dt1;
        grdBusqueda.PageIndex = e.NewPageIndex;
        grdBusqueda.DataBind();
    }
}