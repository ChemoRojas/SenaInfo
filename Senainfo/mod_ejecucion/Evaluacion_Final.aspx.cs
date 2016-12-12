using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ejecucion_Evaluacion_Final : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor
            getHeaderDetalleModuloObjetivo(Request["CodModulo"]);
            getINNAEjecucion(Request["CodCalendario"]);
        }
    }



    private void getINNAEjecucion(string CodCalendario)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getResultadoEjecucion]";
        sqlc.Parameters.Add("@CodCalendario", SqlDbType.VarChar, 11).Value = CodCalendario;
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
            lblNombreModulo.InnerHtml = dr["NombreModulo"].ToString();
            lblNombreObjetivo.InnerHtml = dr["NombreObjetivo"].ToString();

        }
    }

  
}