using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ejecucion_ResumenPreguntasInicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor




            

            getIActividadesModulosNNA("1", Request["CodNino"], Request["CodCalendario"]);
            getHeaderDetalleModuloObjetivo(Request["CodModulo"]);
            TxtCodNino.Text = Request["CodNino"];
            TxtCodCalendario.Text = Request["CodCalendario"];
            TxtCodModulo.Text = Request["CodModulo"];
            getHeaderDetalleNNA(Request["CodNino"],"");
            



        }
    }





    private void getIActividadesModulosNNA(string TipoRespuesta, string CodNino, string CodCalendario)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_CuadroInicial]";
        sqlc.Parameters.Add("@TipoRespuesta", SqlDbType.VarChar, 100).Value = TipoRespuesta;
        sqlc.Parameters.Add("@CodCalendario", SqlDbType.VarChar, 100).Value = CodCalendario;
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 100).Value = CodNino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();



        grdPlanificarModulo.DataSource = dt;
        grdPlanificarModulo.DataBind();
    }


    private void getHeaderDetalleModuloObjetivo(string CodModulo)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getModuloAndObjetivo]";
        sqlc.Parameters.Add("@CodModulo", SqlDbType.VarChar, 100).Value = CodModulo;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        foreach (DataRow dr in dt.Rows)
        {
           NombreM.InnerHtml = dr["NombreObjetivo"].ToString();
        }
    }


    private void getHeaderDetalleNNA(string CodNino, string Ruc)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getHeaderDetalleNNA]";
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 100).Value = CodNino;
        sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar, 100).Value = Ruc;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        foreach (DataRow dr in dt.Rows)
        {
            lblNombre.InnerHtml = dr["Nombre"].ToString();
            lblFechaNac.InnerHtml = string.Format("{0:d}", Convert.ToDateTime(dr["FechaNacimiento"].ToString()));
            lblRun.InnerHtml = dr["Rut"].ToString();
            lblSexo.InnerHtml = dr["Sexo"].ToString();
            lblCodNino.InnerHtml = dr["CodNino"].ToString();
            lblDireccion.InnerHtml = dr["Direccion"].ToString();
            lblComuna.InnerHtml = dr["Comuna"].ToString();
        }
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/mod_ejecucion/BuscarCalendario.aspx");

    }

    
}