using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ejecucion_EvaluearActividades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor




            btnBoton.Attributes.Add("onclick", "history.back(); return false;");

            getIActividadesModulosNNA(Request["CodCalendario"], Request["CodNino"]);
            getHeaderDetalleModuloObjetivo(Request["CodModulo"]);
            txtCodNino.Text = Request["CodNino"];
            TxtCodCalendario.Text = Request["CodCalendario"];
            TxtCodModulo.Text = Request["CodModulo"];

            alertS.Visible = false;



        }
    }





    private void getIActividadesModulosNNA(string CodCalendario, string CodNino)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_ActividadesCalendario]";
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
            lblNombreModulo.InnerHtml = dr["NombreModulo"].ToString();
            NombreM.InnerHtml = dr["NombreModulo"].ToString();
            lblNombreObjetivo.InnerHtml = dr["NombreObjetivo"].ToString();

        }
    }










    protected void btnGuardar_Click(object sender, EventArgs e)
    {



        int returnvalue = 0;
    


        foreach (GridViewRow row in grdPlanificarModulo.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox rb = (row.Cells[2].FindControl("ChkAsistencia") as CheckBox);
                TextBox codactividad = (row.Cells[2].FindControl("CodActividad") as TextBox);
                TextBox Autoevaluacion = (row.Cells[3].FindControl("TxtAutoevaluacion") as TextBox);
                TextBox Observacion = (row.Cells[4].FindControl("txtObservacion") as TextBox);
                int asistencia = 0;

                if (rb.Checked)
                {
                    asistencia = 1;
                }

                if (Autoevaluacion.Text != "")
                {

                    DbDataReader datareader = null;
                    /* Database db = new Database(objconn); */
                    Conexiones con = new Conexiones();
                    DbParameter[] parametros = {
                        con.parametros("@CodActividad", SqlDbType.Int, 100, codactividad.Text) , 
                        con.parametros("@CodCalendario", SqlDbType.Int, 100, TxtCodCalendario.Text) , 
		                con.parametros("@CodNino", SqlDbType.Int, 100, txtCodNino.Text),
		                con.parametros("@Asistencia", SqlDbType.Int, 100, asistencia),
                        con.parametros("@Autoevaluacion", SqlDbType.Int, 100, Autoevaluacion.Text),
                        con.parametros("@Observacion", SqlDbType.VarChar, 2500, Observacion.Text),
                        con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		                //con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		                };


                    con.ejecutarProcedimiento("Update_ActCalNNA", parametros, out datareader);

                    if (datareader.Read())
                    {
                        returnvalue = Convert.ToInt32(datareader["retorno"]);
                    }
                    con.Desconectar();

                    if (returnvalue == 0)
                    {
                        alertS.Visible = true;
                    }


                }


                
            
            }
        }


       // Response.Redirect("~/mod_ejecucion/ResumenPreguntasInicio.aspx?CodModulo=" + TxtCodModulo.Text + "&CodNino=" + txtCodNino.Text + "&CodCalendario=" + TxtCodCalendario.Text + "");



    }



}