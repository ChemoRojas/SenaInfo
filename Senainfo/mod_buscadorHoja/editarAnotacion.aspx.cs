using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_buscadorHoja_editarAnotacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            recuperaAnotacion(Convert.ToInt32(Request["id"]));
            txtId.Value = Request["id"];
            
        }
    }

    private void recuperaAnotacion(int id)
    {

        try
        {
            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "[dbo].[sp_getRecuperaAnotacion]";
            sqlc.Parameters.Add("@id", SqlDbType.Int).Value = id;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                txtMotivo.Text = dr["motivo"].ToString();
                txtObservacion.Text = dr["observacion"].ToString();
                txtFecha.Text = dr["fechaAnotacion"].ToString();
            }

           
        }
        catch (Exception ex)
        {
            Response.Write("Error gravísimo: en recuperar: " + ex.Message);

        }

        
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


    protected void btnModificar_Click(object sender, EventArgs e)
    {
        get_spEditarAnotacion(Convert.ToInt32(txtId.Value), txtMotivo.Text, txtObservacion.Text, txtFecha.Text);
        
    }

    private void get_spEditarAnotacion(int id, string motivo, string observacion, string fechaAnotacion)
    {
       

        try
        {
            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "[dbo].[sp_getEditarAnotacion]";
            sqlc.Parameters.Add("@id", SqlDbType.Int).Value = id;
            sqlc.Parameters.Add("@motivo", SqlDbType.VarChar, 50).Value = motivo;
            sqlc.Parameters.Add("@observacion", SqlDbType.VarChar, 2000).Value = observacion;
            sqlc.Parameters.Add("@fechaAnotacion", SqlDbType.Date).Value = fechaAnotacion;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

            sconn.Open();
            sqlc.ExecuteNonQuery();
            sconn.Close();

            alertaEditar.Visible = true;
        }
           
           
        catch (Exception ex)
        {
            Response.Write("error: " + ex.Message);
        }
        
        
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        txtRut.Value = Request["Rut"];

        Response.Redirect("buscador.aspx?Rut=" + txtRut.Value);
    }
}