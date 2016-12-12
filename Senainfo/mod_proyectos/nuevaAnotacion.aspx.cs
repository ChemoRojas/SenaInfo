using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class mod_buscadorHoja_nuevaAnotacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           txtCodNino.Value = Request["CodNino"];
        }
    }

    private void getSp_nuevaAnotacion(String CodNino ,string motivo, string observacion, string fechaAnotacion)
    {

        try
        {
            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "[dbo].[SP_getNuevaAnotacion]";

            sqlc.Parameters.Add("@CodNino", SqlDbType.Int).Value = CodNino;
            sqlc.Parameters.Add("@motivo", SqlDbType.VarChar, 50).Value = motivo;
            sqlc.Parameters.Add("@observacion", SqlDbType.VarChar, 2000).Value = observacion;
            sqlc.Parameters.Add("@fechaAnotacion", SqlDbType.Date).Value = fechaAnotacion;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

            sconn.Open();
            sqlc.BeginExecuteNonQuery();
            sconn.Close();

            Response.Write("se pudo");
        }
        catch(Exception ex)
        {
            Response.Write("error: " + ex.Message);
        }
        

      
    }
    
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        getSp_nuevaAnotacion(txtCodNino.Value , txtMotivo.Text, txtObservacion.Text, txtFecha.Text);
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFecha.Text = CalFechaAnotacion.SelectedDate.ToString();
        CalFechaAnotacion.Visible = false;
    }
    protected void btnFecha_Click(object sender, EventArgs e)
    {
        CalFechaAnotacion.Visible = true;
    }
}