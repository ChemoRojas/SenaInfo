using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_buscador_proteccionDerechos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getHeaderDetalleNNA(Request["CodNino"]);
            getProtDerDetalle(Request["CodNino"]);
        }
    }

    private void getHeaderDetalleNNA(string CodNino)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getHeaderDetalleNNA]";
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 100).Value = CodNino;
        sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar, 100).Value = "";
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

    private void getProtDerDetalle(string CodNino)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getProtDerDetalleNNA]";
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 100).Value = CodNino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        grdProtDer.DataSource = dt;
        grdProtDer.DataBind();
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("detalleNNA.aspx?CodNino=" + Request["CodNino"] + "&Ruc=" + Request["Ruc"]);
    }
}