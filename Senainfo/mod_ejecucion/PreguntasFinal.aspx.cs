using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ejecucion_PreguntasFinal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor


            btnBoton.Attributes.Add("onclick", "history.back(); return false;");
            getIActividadesModulosNNA(Request["CodModulo"]);
            getHeaderDetalleModuloObjetivo(Request["CodModulo"]);
            txtCodNino.Text = Request["CodNino"];
            TxtCodCalendario.Text = Request["CodCalendario"];
            TxtCodModulo.Text = Request["CodModulo"];

            alertW.Visible = false;

        }
    }





    private void getIActividadesModulosNNA(string CodModulo)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_PreguntasModulo]";
        sqlc.Parameters.Add("@CodModulo", SqlDbType.VarChar, 100).Value = CodModulo;
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
        int respuesta = 0;
        int existe = 0;


        foreach (GridViewRow row in grdPlanificarModulo.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                RadioButton rb = (row.Cells[1].FindControl("Row1") as RadioButton);
                RadioButton rb2 = (row.Cells[1].FindControl("Row2") as RadioButton);
                RadioButton rb3 = (row.Cells[1].FindControl("Row3") as RadioButton);




                TextBox codPregunta = (row.Cells[1].FindControl("txt2") as TextBox);


                if (rb.Checked == true)
                {
                    respuesta = 1;
                }
                else if (rb2.Checked == true)
                {
                    respuesta = 2;
                }
                else if (rb3.Checked == true)
                {
                    respuesta = 3;
                }
                else
                {
                    existe = 1;
                }
                if (existe == 0)
                {


                    DbDataReader datareader = null;
                    /* Database db = new Database(objconn); */
                    Conexiones con = new Conexiones();
                    DbParameter[] parametros = {
                        con.parametros("@CodPreguntaModulo", SqlDbType.Int, 100, codPregunta.Text) , 
                        con.parametros("@TipoRespuesta", SqlDbType.Int, 100, 2) , 
		                con.parametros("@Respuesta", SqlDbType.Int, 100, respuesta),
		                con.parametros("@CodNino", SqlDbType.Int, 100, txtCodNino.Text),
                        con.parametros("@CodCalendario", SqlDbType.Int, 100, TxtCodCalendario.Text),
                        con.parametros("@Vigencia", SqlDbType.Int, 100, 1),
                        con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		                //con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		                };


                    con.ejecutarProcedimiento("Insert_Update_RespuestaModulo", parametros, out datareader);

                    if (datareader.Read())
                    {
                        returnvalue = Convert.ToInt32(datareader["retorno"]);
                    }
                    con.Desconectar();





                }
                else
                {

                    Conexiones con = new Conexiones();

                    DbParameter[] parametros2 = {
                        con.parametros("@CodCalendario", SqlDbType.Int, 100, TxtCodCalendario.Text), 
                        con.parametros("@CodNino", SqlDbType.Int, 100, txtCodNino.Text),
                        con.parametros("@TipoRespuesta", SqlDbType.Int, 100, 2) 
		                
		 
		                //con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		                };
                        con.ejecutarProcedimiento("SP_UpdatePreguntaCalendario", parametros2);

                        alertW.Visible = true;

                        break;


                }
            }
        }


        Response.Redirect("~/mod_ejecucion/ResumenPreguntasFin.aspx?CodModulo=" + TxtCodModulo.Text + "&CodNino=" + txtCodNino.Text + "&CodCalendario=" + TxtCodCalendario.Text + "");



    }



}