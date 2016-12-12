using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Log_mesa_ayuda
/// </summary>
public class Log_mesa_ayuda
{
    public int idusuario;
    public int idmesadeayuda;
    public DateTime fechaactualizacion;
    public string Codproyecto;
    public string anomes;
    public string datoanexo;
    public string mensaje;
    public string msj_retorno_sp;
    public string nombre_sp_ejecutado;

	public Log_mesa_ayuda()
	{
      		
	}
    public void insertLog()
    {
        //objconnection objconn = ASP.global_asax.globaconn;
        Conexiones con = new Conexiones();
        using (SqlConnection connection = new SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False"))
        {

            using (SqlCommand command = new SqlCommand())
            {
                int idUser = Convert.ToInt32(HttpContext.Current.Session["IdUsuario"].ToString());
                DateTime dti = DateTime.Now;
                int idmesa = Get_IdRol_user();
               

                command.Connection = connection;            // <== lacking
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into logexcepcionasistencia (IdUsuario, IdMesaDeAyuda, FechaActualizacion,P1,P2,P3,P4,P5,spEjecutado) VALUES (@IdUsuario, @IdMesaDeAyuda, @FechaActualizacion,@P1,@P2,@P3,@P4,@P5,@spEjecutado)";
                command.Parameters.AddWithValue("@IdUsuario", idUser);
                command.Parameters.AddWithValue("@IdMesaDeAyuda", idmesa);
                command.Parameters.AddWithValue("@FechaActualizacion", dti);
                command.Parameters.AddWithValue("@P1", Codproyecto);
                command.Parameters.AddWithValue("@P2", anomes);
                command.Parameters.AddWithValue("@P3", datoanexo);
                command.Parameters.AddWithValue("@P4", mensaje);
                command.Parameters.AddWithValue("@P5", msj_retorno_sp.Length > 100 ? msj_retorno_sp.Substring(0, 99) : msj_retorno_sp);
                command.Parameters.AddWithValue("@spEjecutado", nombre_sp_ejecutado);

                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    // error here
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        ////////////////////////////////////////////////////////////////

    }
    protected int Get_IdRol_user()
    {
        int int_valor = 0;
        try
        {
            coordinador cr = new coordinador();
            string sql = "Select  * From  usuarios  where idUsuario =" + HttpContext.Current.Session["IdUsuario"].ToString();
            DataTable dtproy = cr.ejecuta_SQL(sql, null);
            string contrasena = dtproy.Rows[0]["Contrasena"].ToString();
            int_valor = Convert.ToInt32(contrasena);
        }
        catch { }
        return int_valor;
    }
}