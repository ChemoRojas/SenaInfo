using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ejecucion_BuscarCalendario : System.Web.UI.Page
{
    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor
        }
    }

    private DataTable resultadoBusqueda(string CodModulo, string NombreModulo)
    {
        Conexiones con = new Conexiones();
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "EXEC [dbo].[SP_getCalendarioEjecucion] '" + CodModulo + "', '" + NombreModulo + "' ";
        //sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 4).Value = Rut;
        //sqlc.Parameters.Add("@nombres", SqlDbType.VarChar, 4).Value = Nombres;
        //sqlc.Parameters.Add("@apellidoPaterno", SqlDbType.VarChar, 1).Value = ApellPaterno;
        //sqlc.Parameters.Add("@apellidoMaterno", SqlDbType.VarChar, 1).Value = ApellMaterno;
        //sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 1).Value = CodNino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        dt1 = resultadoBusqueda(txtCodModulo.Text, txtNombreModulo.Text);
        grdBusqueda.DataSource = dt1;

        grdBusqueda.DataBind();
    }



    protected void grdBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBusqueda.DataSource = dt1;
        grdBusqueda.PageIndex = e.NewPageIndex;
        grdBusqueda.DataBind();
    }
 
    protected void grdBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        foreach (GridViewRow row in grdBusqueda.Rows)
        {
            TextBox comparacion = (row.Cells[1].FindControl("TxtComparacion") as TextBox);
            TextBox EvaInicialComparacion = (row.Cells[1].FindControl("TxtEvaInicialComparacion") as TextBox); 
            TextBox EvaFinalComparacion = (row.Cells[1].FindControl("TxtEvaFinalComparacion") as TextBox);
            TextBox ActividadesPlanificadas = (row.Cells[1].FindControl("TxtActividadesPlanificadas") as TextBox);
            TextBox ActividadesRealizadas = (row.Cells[1].FindControl("TxtActividadesRealizadas") as TextBox);
            Label Estado = (row.Cells[8].FindControl("LblEstado") as Label);

            if (comparacion.Text != EvaInicialComparacion.Text)
            {

                row.Cells[6].Enabled = false;
                row.Cells[7].Enabled = false;
                Estado.Text="Evaluación Iniciado";
            }
            else if (ActividadesPlanificadas.Text != ActividadesRealizadas.Text)
            {
                row.Cells[5].Enabled = false;
                row.Cells[7].Enabled = false;
                Estado.Text = "Trabajando";

            }
            else if (comparacion.Text != EvaFinalComparacion.Text)
            {

                row.Cells[5].Enabled = false;
                row.Cells[6].Enabled = false;
                Estado.Text = "Evaluación Final";

            }
            else
            {
                row.Cells[5].Enabled = false;
                row.Cells[6].Enabled = false;
                row.Cells[7].Enabled = false;
                Estado.Text = "Finalizado";

            }
            
        }
       

    }
}