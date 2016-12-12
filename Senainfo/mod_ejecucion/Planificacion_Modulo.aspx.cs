using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ejecucion_Planificacion_Modulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor

            getIActividadesModulosNNA(Request["CodModulo"]);
            getCalendarioModulo(Request["CodModulo"]);
            TxtCodNino.Text = Request["CodNino"];
            TxtRuc.Text = Request["Ruc"];
            getIActividadesModulosVigentesNNA(Request["CodModulo"], Request["CodNino"]);

            alertS.Visible = false;
            alertW.Visible = false;
        }
    }

    private void getCalendarioModulo(string CodModulo)
    {
     


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetCalendariosModulos(CodModulo));
        ddownCalendario.DataSource = dv6;
        ddownCalendario.DataTextField = "CalMod";
        ddownCalendario.DataValueField = "CodCalendario";
        dv6.Sort = "CodCalendario";
        ddownCalendario.DataBind();


    
    }



    private void getIActividadesModulosNNA(string CodModulo)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_ActividadModuloNNA]";
        sqlc.Parameters.Add("@CodModulo", SqlDbType.VarChar, 100).Value = CodModulo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        grdPlanificarModulo.DataSource = dt;
        grdPlanificarModulo.DataBind();
    }


    private void getIActividadesModulosVigentesNNA(string CodModulo, string CodNino)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_ActividadModuloActivosNNA]";
        sqlc.Parameters.Add("@CodModulo", SqlDbType.VarChar, 100).Value = CodModulo;
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 100).Value = CodNino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        grdListado.DataSource = dt;
        grdListado.DataBind();
    }






    protected void GetSelectedRecords(object sender, EventArgs e)
    {

        if (ddownCalendario.SelectedValue == "0")
        {
            alertS.Visible = false;
            alertW.Visible = true;

        }
        else
        {

            DataTable dt = new DataTable();
            int returnvalue = 0;

            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("NombreActividad") });
            foreach (GridViewRow row in grdPlanificarModulo.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        DbDataReader datareader = null;
                        /* Database db = new Database(objconn); */
                        Conexiones con = new Conexiones();
                        DbParameter[] parametros = {
                    con.parametros("@CodActividad", SqlDbType.Int, 4, row.Cells[1].Text) , 
                    con.parametros("@CodCalendario", SqlDbType.Int, 4, ddownCalendario.SelectedValue) , 
		            con.parametros("@CodNino", SqlDbType.VarChar, 30, TxtCodNino.Text),
		            con.parametros("@Vigencia", SqlDbType.Int, 4, 1),
                    con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString()),
                    con.parametros("@Ruc", SqlDbType.VarChar, 250, TxtRuc.Text)
		 
		            //con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		            };
                        con.ejecutarProcedimiento("Insert_Update_ActCalNNA", parametros, out datareader);

                        if (datareader.Read())
                        {
                            returnvalue = Convert.ToInt32(datareader["retorno"]);
                        }
                        con.Desconectar();

                    }
                    else
                    {
                        DbDataReader datareader = null;
                        /* Database db = new Database(objconn); */
                        Conexiones con = new Conexiones();
                        DbParameter[] parametros = {
                    con.parametros("@CodActividad", SqlDbType.Int, 4, row.Cells[1].Text) , 
                    con.parametros("@CodCalendario", SqlDbType.Int, 4, ddownCalendario.SelectedValue) , 
		            con.parametros("@CodNino", SqlDbType.VarChar, 30, TxtCodNino.Text),
		            con.parametros("@Vigencia", SqlDbType.Int, 4, 0),
                    con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString()),
                    con.parametros("@Ruc", SqlDbType.VarChar, 250, TxtRuc.Text)
		 
		            //con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		            };
                        con.ejecutarProcedimiento("Insert_Update_ActCalNNA", parametros, out datareader);

                        if (datareader.Read())
                        {
                            returnvalue = Convert.ToInt32(datareader["retorno"]);
                        }
                        con.Desconectar();


                    }


                    if (returnvalue == 0)
                    {

                        alertS.Visible = true;
                        alertW.Visible = false;



                    }
                    else
                    {

                        alertS.Visible = false;
                        alertW.Visible = true;


                    }
                }
            }

            Response.Redirect(Request.RawUrl, true);
          }
 
      
    }


   
}