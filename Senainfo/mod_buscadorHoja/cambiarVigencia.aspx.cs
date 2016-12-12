using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_buscadorHoja_cambiarVigencia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            sp_getCambiarAnotacion(Convert.ToInt32(Request["id"]),Request["vigencia"]); 
            
           
        }
    }

    private void sp_getCambiarAnotacion(int id,string vigencia)
    {
        string Rut = "";
        int vigenciaNew = 0;

        if (vigencia == "True")
        {

            vigenciaNew = 0;

        }
        else
        {
            vigenciaNew = 1;
        }

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[sp_getCambiarVigencia]";
        sqlc.Parameters.Add("@id", SqlDbType.Int).Value = id;
        sqlc.Parameters.Add("@vigencia", SqlDbType.Int).Value = vigenciaNew;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        foreach(DataRow dr in dt.Rows)
            Rut = dr["Rut"].ToString();

        Response.Redirect("buscador.aspx?Rut=" + Rut);
    }

}

