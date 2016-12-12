using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
////////using neocsharp.NeoDatabase;

/// <summary>
/// Descripción breve de Recepcioncoll
/// </summary>
public class Recepcioncoll
{
	public Recepcioncoll()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable cierre_recepcion_estadistica(int mesano, int codregion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_recepcion_estadistica";
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@codregion", SqlDbType.Int, 4).Value = codregion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable cierre_recepcion_movimientomensual(int mesano, int codproyecto, int estado, int codregion, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_recepcion_movimientomensual";
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@estado", SqlDbType.Int, 4).Value = estado;
        sqlc.Parameters.Add("@codregion", SqlDbType.Int, 4).Value = codregion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable Cierre_Recepcion_MovimientoMensual_Reliquidaciones(int MesAno, int CodProyecto, int CodRegion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Cierre_Recepcion_MovimientoMensual_Reliquidaciones";
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = MesAno;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = CodRegion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable Cierre_Retencion_Guardar(int CodProyecto, int MesAno, Int32 Correlativo, DateTime FechaRetencion, int Estado, int IdUsuarioActualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Cierre_Retencion_Guardar";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = MesAno;
        sqlc.Parameters.Add("@Correlativo", SqlDbType.Int, 4).Value = Correlativo;
        sqlc.Parameters.Add("@FechaRetencion", SqlDbType.DateTime, 16).Value = FechaRetencion;
        sqlc.Parameters.Add("@Estado", SqlDbType.Int, 4).Value = Estado;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable cierre_recepcion_guardar(int codproyecto, int mesano, DateTime fecharecepcion, int estado, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_recepcion_guardar";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@fecharecepcion", SqlDbType.DateTime, 16).Value = fecharecepcion;
        sqlc.Parameters.Add("@estado", SqlDbType.Int, 4).Value = estado;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable rendicion_recepcionrendicioncuentas(string spaccion, int codproyecto, int codregion,
        int anomes, int recibido, int indicepago, DateTime fecharecepcion, int idusuarioactualizacion,
        int returns)
    {
        object objCodProyecto = DBNull.Value;
        if (codproyecto != 0)
        {
            objCodProyecto = codproyecto;
        };
        object objcodregion = DBNull.Value;
        if (codregion != -2)
        {
            objcodregion = codregion;
        };
        object objrecibido = DBNull.Value;
        if (recibido != 0)
        {
            objrecibido = recibido;
        };
        //object objindicepago = DBNull.Value;
        //if (indicepago != 0)
        //{
        //    objindicepago = indicepago;
        //};
        object objfecharecepcion = DBNull.Value;
        if (fecharecepcion != Convert.ToDateTime("01-01-1900"))
        {
            objfecharecepcion = fecharecepcion;
        };
        object objidusuarioactualizacion = DBNull.Value;
        if (idusuarioactualizacion != 0)
        {
            objidusuarioactualizacion = idusuarioactualizacion;
        };
        object objreturns = DBNull.Value;
        if (returns != 0)
        {
            objreturns = returns;
        };

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Rendicion_RecepcionRendicionCuentas";
        sqlc.Parameters.Add("@SpAccion", SqlDbType.Char, 1).Value = spaccion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = objCodProyecto;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = objcodregion;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = anomes;
        sqlc.Parameters.Add("@Recibido", SqlDbType.Int, 4).Value = objrecibido;
        sqlc.Parameters.Add("@IndicePago", SqlDbType.Int, 4).Value = indicepago;
        sqlc.Parameters.Add("@FechaRecepcion", SqlDbType.DateTime, 16).Value = objfecharecepcion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = objidusuarioactualizacion;
        sqlc.Parameters.Add("@Returns", SqlDbType.Int, 4).Value = objreturns;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        try
        {
            da.Fill(dt);
        }
        catch { }
        sconn.Close();
        return dt;
    }

    public DataTable rendicion_RetencionCuentas(int CodProyecto, int AnoMes, int Correlativo, DateTime FechaRetencion, int Estado, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Cierre_RetencionRendicion_Guardar";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = AnoMes;
        sqlc.Parameters.Add("@Correlativo", SqlDbType.Int, 4).Value = Correlativo;
        sqlc.Parameters.Add("@FechaRetencion", SqlDbType.DateTime, 16).Value = FechaRetencion;
        sqlc.Parameters.Add("@Estado", SqlDbType.Int, 4).Value = Estado;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        try
        {
            da.Fill(dt);
        }
        catch { }
        sconn.Close();
        return dt;
    }
}
