using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for Resolucionescoll
/// </summary>
public class Resolucionescoll
{

    public Resolucionescoll()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Felipe Ormazabal

    private string SQL_resoluciones()
    {
        string tsql = string.Empty;
        tsql = "SELECT DISTINCT * FROM Resoluciones order by NumeroResolucion";

        return tsql;
    }

    public DataTable GetTipoResolucion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_resoluciones(), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Numero Resolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Codigo Institucion"));
        //dt.Columns.Add(new DataColumn("Tipo Termino"));
        //dt.Columns.Add(new DataColumn("IdUsuarioActualizacion"));

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["NumeroResolucion"];
                dr[1] = (System.Int32)datareader["CodInstitucion"];//.ToString() + ") " + (System.Int32)datareader["CodInstitucion"];
                //dr[2] = (System.Char)datareader["TipoTermino"];
                //dr[3] = (System.Int32)datareader["IdUsuarioActualizacion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetTipoResolucionxProyInst(int CodProyecto, int CodInstitucion)
    {
        string sql = "SELECT NumeroResolucion,ICodResolucion FROM Resoluciones Where CodProyecto=" + CodProyecto + " and CodInstitucion =" + CodInstitucion +
                      " Order by FechaResolucion DESC";

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(sql, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("NumeroResolucion", typeof(String)));
        dt.Columns.Add(new DataColumn("ICodResolucion"));

        //dr = dt.NewRow();
        //dr[0] = " Seleccionar ";
        //dr[1] = "0";
        //dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (String)datareader["NumeroResolucion"];
                dr[1] = (int)datareader["ICodResolucion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetTipoTermino()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_resoluciones(), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Tipo Termino", typeof(String)));
        dt.Columns.Add(new DataColumn("Numero resolucion"));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["TipoTermino"];
                dr[1] = (System.Int32)datareader["NumeroResolucion"];
                dt.Rows.Add(dr);

            }
            catch
            { }

        }
        con.Desconectar();

        return dt;
    }

    public DataTable GetTecnicoProyecto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_resoluciones(), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Tecnico Proyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("Numero resolucion"));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["IdUsuarioActualizacion"];
                dr[1] = (System.Int32)datareader["NumeroResolucion"];
                dt.Rows.Add(dr);

            }
            catch
            { }

        }
        con.Desconectar();

        return dt;
    }

    public void Update_EstadoProyecto(int CodProyecto)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        string sql = "UPDATE Proyectos SET EstadoProyecto = 1 WHERE CodProyecto =" + CodProyecto;
        con.ejecutar(sql, out datareader);
        con.Desconectar();

    }

    //inserta resoluciones

    //    public int Insert_Resoluciones(
    //int AnoResolucion, int NumeroResolucion, int CodInstitucion, int CodDiasAtencion, DateTime FechaResolucion, String Descripcion, DateTime FechaConvenio, DateTime FechaInicio, DateTime FechaTermino, int Etapas, int NumeroPlazas, int PlazasAdicionales, int PorPlazasAsignadasTribunales, String TipoResolucion, String TipoTermino, int MesesSubAtencion, String Sexo, int Monto, int FactorEdad, int FactorCobertura, int FactorDiscapacidad, int FactorComplejidad, String IndVigencia, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    //    {
    //        int returnvalue = 0;
    //        DbDataReader datareader = null;
    //        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
    //        DbParameter[] parametros = {
    //        con.parametros("@AnoResolucion", SqlDbType.Int, 4, AnoResolucion) , 
    //        con.parametros("@NumeroResolucion", SqlDbType.Int, 4, NumeroResolucion) , 
    //        con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
    //        con.parametros("@CodDiasAtencion", SqlDbType.Int, 4, CodDiasAtencion) , 
    //        con.parametros("@FechaResolucion", SqlDbType.DateTime, 16, FechaResolucion) , 
    //        con.parametros("@Descripcion", SqlDbType.VarChar, 100, Descripcion) , 
    //        con.parametros("@FechaConvenio", SqlDbType.DateTime, 16, FechaConvenio) , 
    //        con.parametros("@FechaInicio", SqlDbType.DateTime, 16, FechaInicio) , 
    //        con.parametros("@FechaTermino", SqlDbType.DateTime, 16, FechaTermino) , 
    //        con.parametros("@Etapas", SqlDbType.Int, 4, Etapas) , 
    //        con.parametros("@NumeroPlazas", SqlDbType.Int, 4, NumeroPlazas) , 
    //        con.parametros("@PlazasAdicionales", SqlDbType.Int, 4, PlazasAdicionales) , 
    //        con.parametros("@PorPlazasAsignadasTribunales", SqlDbType.Int, 1, PorPlazasAsignadasTribunales) , 
    //        con.parametros("@TipoResolucion", SqlDbType.Char, 1, TipoResolucion) , 
    //        con.parametros("@TipoTermino", SqlDbType.Char, 1, TipoTermino) , 
    //        con.parametros("@MesesSubAtencion", SqlDbType.Int, 4, MesesSubAtencion) , 
    //        con.parametros("@Sexo", SqlDbType.Char, 1, Sexo) , 
    //        con.parametros("@Monto", SqlDbType.Int, 4, Monto) , 
    //        con.parametros("@FactorEdad", SqlDbType.Int, 8, FactorEdad) , 
    //        con.parametros("@FactorCobertura", SqlDbType.Int, 8, FactorCobertura) , 
    //        con.parametros("@FactorDiscapacidad", SqlDbType.Int, 8, FactorDiscapacidad) , 
    //        con.parametros("@FactorComplejidad", SqlDbType.Int, 8, FactorComplejidad) , 
    //        con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
    //        con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
    //        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
    //        };
    //        con.ejecutarProcedimiento("Insert_Resoluciones", parametros, out datareader);
    //        if (datareader.Read())
    //        {
    //            returnvalue = Convert.ToInt32(datareader["identidad"]);
    //        }
    //        con.Desconectar();
    //        return returnvalue;
    //    }

    public DataTable Insert_Resoluciones(int codproyecto, int anoresolucion, String numeroresolucion, int codinstitucion, int coddiasatencion, DateTime fecharesolucion, string descripcion, DateTime fechaconvenio, DateTime fechainicio, DateTime fechatermino, int etapas, int numeroplazas, int plazasadicionales, int porplazasasignadastribunales, string tiporesolucion, string tipotermino, int mesessubatencion, string sexo, int monto, string indvigencia, DateTime fechaactualizacion, int idusuarioactualizacion)
    {
        object objFechaTermino = DBNull.Value;
        if (fechatermino != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaTermino = fechatermino;
        };

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_Resoluciones";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@AnoResolucion", SqlDbType.Int, 4).Value = anoresolucion;
        sqlc.Parameters.Add("@NumeroResolucion", SqlDbType.VarChar, 10).Value = numeroresolucion;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodDiasAtencion", SqlDbType.Int, 4).Value = coddiasatencion;
        sqlc.Parameters.Add("@FechaResolucion", SqlDbType.DateTime, 16).Value = fecharesolucion;
        sqlc.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = descripcion;
        sqlc.Parameters.Add("@FechaConvenio", SqlDbType.DateTime, 16).Value = fechaconvenio;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = objFechaTermino;
        sqlc.Parameters.Add("@Etapas", SqlDbType.Int, 4).Value = etapas;
        sqlc.Parameters.Add("@NumeroPlazas", SqlDbType.Int, 4).Value = numeroplazas;
        sqlc.Parameters.Add("@PlazasAdicionales", SqlDbType.Int, 4).Value = plazasadicionales;
        sqlc.Parameters.Add("@PorPlazasAsignadasTribunales", SqlDbType.Int, 4).Value = porplazasasignadastribunales;
        sqlc.Parameters.Add("@TipoResolucion", SqlDbType.Char, 1).Value = tiporesolucion;
        sqlc.Parameters.Add("@TipoTermino", SqlDbType.Char, 1).Value = tipotermino;
        sqlc.Parameters.Add("@MesesSubAtencion", SqlDbType.Int, 4).Value = mesessubatencion;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = sexo;
        sqlc.Parameters.Add("@Monto", SqlDbType.Int, 4).Value = monto;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetEtapasResolucion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEtapasResolucion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodEtapaResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("AnoResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Etapa", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("MontoInversion", typeof(int)));
        dt.Columns.Add(new DataColumn("MontoOperacion", typeof(int)));
        dt.Columns.Add(new DataColumn("MontoPersonal", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("FactorEtapa", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodEtapaResolucion"];
                dr[1] = (int)datareader["ICodResolucion"];
                dr[2] = (int)datareader["CodProyecto"];
                dr[3] = (int)datareader["AnoResolucion"];
                dr[4] = (int)datareader["NumeroResolucion"];
                dr[5] = (int)datareader["Etapa"];
                dr[6] = (DateTime)datareader["FechaInicio"];
                dr[7] = (DateTime)datareader["FechaTermino"];
                dr[8] = (int)datareader["MontoInversion"];
                dr[9] = (int)datareader["MontoOperacion"];
                dr[10] = (int)datareader["MontoPersonal"];
                dr[11] = (DateTime)datareader["FechaActualizacion"];
                dr[12] = (int)datareader["IdUsuarioActualizacion"];
                dr[13] = (int)datareader["FactorEtapa"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetEtapasResolucionxCod(int ICodResolucion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEtapasResolucion + ICodResolucion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodEtapaResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("AnoResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroResolucion", typeof(String)));
        dt.Columns.Add(new DataColumn("Etapa", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("MontoInversion", typeof(int)));
        dt.Columns.Add(new DataColumn("MontoOperacion", typeof(int)));
        dt.Columns.Add(new DataColumn("MontoPersonal", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("FactorEtapa", typeof(Double)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodEtapaResolucion"];
                dr[1] = (int)datareader["ICodResolucion"];
                dr[2] = (int)datareader["CodProyecto"];
                dr[3] = (int)datareader["AnoResolucion"];
                dr[4] = (String)datareader["NumeroResolucion"];
                dr[5] = (int)datareader["Etapa"];
                try
                {
                    dr[6] = (DateTime)datareader["FechaInicio"];
                }
                catch
                { }

                try
                {
                    dr[7] = (DateTime)datareader["FechaTermino"];
                }
                catch
                { }

                dr[8] = (int)datareader["MontoInversion"];
                dr[9] = (int)datareader["MontoOperacion"];
                dr[10] = (int)datareader["MontoPersonal"];
                dr[11] = (DateTime)datareader["FechaActualizacion"];
                dr[12] = (int)datareader["IdUsuarioActualizacion"];

                try
                {
                    dr[13] = (Double)datareader["FactorEtapa"];
                }
                catch
                { }
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetResolucionxIcod(int ICodResolucion)
    {
        string sql = "SELECT ICodResolucion,CodProyecto, AnoResolucion, NumeroResolucion, CodInstitucion, CodDiasAtencion," +
                     "FechaResolucion, Descripcion, FechaConvenio, FechaInicio, FechaTermino, Etapas," +
                     "NumeroPlazas, PlazasAdicionales, PorPlazasAsignadasTribunales, TipoResolucion, TipoTermino," +
                     "MesesSubAtencion, Sexo, Monto, " +
                     "IndVigencia, FechaActualizacion, IdUsuarioActualizacion " +
                     "FROM Resoluciones Where ICodResolucion =" + ICodResolucion;

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sql, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("ICodResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("AnoResolucion", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroResolucion", typeof(String)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiasAtencion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaResolucion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaConvenio", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Etapas", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroPlazas", typeof(int)));
        dt.Columns.Add(new DataColumn("PlazasAdicionales", typeof(int)));
        dt.Columns.Add(new DataColumn("PorPlazasAsignadasTribunales", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoResolucion", typeof(String)));
        dt.Columns.Add(new DataColumn("TipoTermino", typeof(String)));
        dt.Columns.Add(new DataColumn("MesesSubAtencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("Monto", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodResolucion"];
                dr[1] = (int)datareader["CodProyecto"];
                dr[2] = (int)datareader["AnoResolucion"];
                dr[3] = (String)datareader["NumeroResolucion"];
                dr[4] = (int)datareader["CodInstitucion"];
                dr[5] = (int)datareader["CodDiasAtencion"];
                dr[6] = (DateTime)datareader["FechaResolucion"];
                dr[7] = (String)datareader["Descripcion"];
                dr[8] = (DateTime)datareader["FechaConvenio"];
                dr[9] = (DateTime)datareader["FechaInicio"];
                try
                {
                    dr[10] = (DateTime)datareader["FechaTermino"];
                }
                catch
                { }
                dr[11] = (int)datareader["Etapas"];
                dr[12] = (int)datareader["NumeroPlazas"];
                dr[13] = (int)datareader["PlazasAdicionales"];
                dr[14] = (int)datareader["PorPlazasAsignadasTribunales"];
                dr[15] = (String)datareader["TipoResolucion"];
                dr[16] = (String)datareader["TipoTermino"];
                dr[17] = (int)datareader["MesesSubAtencion"];
                dr[18] = (String)datareader["Sexo"];
                dr[19] = (int)datareader["Monto"];
                dr[20] = (String)datareader["IndVigencia"];
                dr[21] = (DateTime)datareader["FechaActualizacion"];
                dr[22] = (int)datareader["IdUsuarioActualizacion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable update_proyecto_resolucion(int codproyecto, DateTime fechatermino, int numeroplazas)
    {
        object objFechaTermino = DBNull.Value;
        if (fechatermino != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaTermino = fechatermino;
        };
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_Proyecto_Resolucion";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = objFechaTermino;
        sqlc.Parameters.Add("@NumeroPlazas", SqlDbType.Int, 4).Value = numeroplazas;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public int GetEstadoProyecto(int codproyecto)
    {
        int EstadoProyecto = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEstadoProyecto + codproyecto, out datareader);
        while (datareader.Read())
        {
            try
            {
                EstadoProyecto = (int)datareader["EstadoProyecto"];
            }
            catch { }
        }
        con.Desconectar();
        return EstadoProyecto;
    }
    public int GetTipoSubvencionxProyecto(int codproyecto)
    {
        int tipoSubvencion = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoSubvencionxProyecto + codproyecto, out datareader);
        while (datareader.Read())
        {
            try
            {
                tipoSubvencion = (int)datareader["TipoSubvencion"];
            }
            catch { }
        }
        con.Desconectar();
        return tipoSubvencion;
    }
    public int CheckResolExiste(string NumeroResolucion, int CodProyecto, int Ano)
    {
        int val = 0;
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = "Select Count(ICodResolucion) as Contador From Resoluciones " +
                "Where CodProyecto =@pCodProyecto  and AnoResolucion =@pAnoResolucion and NumeroResolucion =@pNumeroResolucion ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, CodProyecto));
        listDbParameter.Add(Conexiones.CrearParametro("@pAnoResolucion", SqlDbType.Int, 4, Ano));
        listDbParameter.Add(Conexiones.CrearParametro("@pNumeroResolucion", SqlDbType.VarChar, 10, NumeroResolucion));

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sql, listDbParameter, out datareader);
        while (datareader.Read())
        {
            try
            {
                val = (int)datareader["Contador"];
            }
            catch
            { }
        }

        con.Desconectar();

        return val;
    }
}