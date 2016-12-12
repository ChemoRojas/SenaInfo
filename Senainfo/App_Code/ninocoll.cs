using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Summary description for ninocoll
/// </summary>
/// 
public class ninoslist : ArrayList { }
public class ninocoll
{

    public enum querytype { inred, inproyect, onlycount, inlista };
    public ninocoll()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetparLugarFallecimiento()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodLugarFallecimiento, Descripcion FROM parLugarFallecimiento WHERE (IndVigencia = 'V')";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);

        DataRow dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public int callto_get_consultaRut(string rut)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "ConsultaRutNINO";
        sqlc.Parameters.Add("@rut", SqlDbType.VarChar, 30).Value = rut;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    //public 

    public int callto_get_codmodelointervencion(int codproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GET_CodModeloIntervencion";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        if (dt.Rows.Count == 0)
        {
            return 0;
        }
        else
        {
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
    public int callto_get_ninoingresado(int param_codproyecto, int param_estadoie, int param_codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ninoIngresado";
        sqlc.Parameters.Add("@param_codProyecto", SqlDbType.Int, 4).Value = param_codproyecto;
        sqlc.Parameters.Add("@param_estadoIE", SqlDbType.Int, 4).Value = param_estadoie;
        sqlc.Parameters.Add("@param_codNino", SqlDbType.Int, 4).Value = param_codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public DataTable callto_getNinoLRPA_Jueces(int CodNino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinoLRPA_Jueces";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_getRUC_LRPA_Jueces(string RUC)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetRUCLRPA_Jueces";
        sqlc.Parameters.Add("@RUC", SqlDbType.VarChar, 12).Value = RUC;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_getNinoProteccion_Jueces(int CodNino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinoProteccion_Jueces";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    //[GetNinoProteccion_RUC_Jueces]

    public DataTable callto_getNinoProteccion_RUC_Jueces(string RUC)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinoProteccion_RUC_Jueces";
        sqlc.Parameters.Add("@RUC", SqlDbType.VarChar, 12).Value = RUC;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable get_EgresosPendientesMesActual(int ICodTrabajador, int Rol, int periodoMesAno)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "getEgresosPendientes";
        sqlc.Parameters.Add("@IcodTrabajador", SqlDbType.Int, 10).Value = ICodTrabajador;
        sqlc.Parameters.Add("@usuContrasena", SqlDbType.Int, 10).Value = Rol;
        sqlc.Parameters.Add("@periodoMesAno", SqlDbType.Int, 10).Value = periodoMesAno;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }

    public string SQL_Nino(querytype qt, string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres, string codproyecto)
    {
        string tsql = string.Empty;
        switch (qt)
        {
            case querytype.onlycount:
                tsql = "SELECT DISTINCT count(T1.CodNino) as counter  ";
                tsql += "FROM NINOS T1 ";

                break;
            case querytype.inred:
                tsql = "SELECT DISTINCT T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento ";
                tsql += "FROM Ninos T1 ";
                /* tsql += "INNER JOIN Ingresos_Egresos T2 ON T2.Codnino = T1.Codnino ";
                 tsql += "INNER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";*/

                break;
            case querytype.inproyect:
                tsql = "SELECT DISTINCT T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento,";
                tsql += "T2.CodProyecto, T4.Nombre as NombreProy, T5.Nombre as NombreInst, T2.FechaIngreso, T2.ICodIE FROM Ninos T1 ";
                tsql += "INNER JOIN Ingresos_Egresos T2 ON T2.Codnino = T1.Codnino ";
                tsql += "INNER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";
                tsql += "INNER JOIN Instituciones T5 ON T5.CodInstitucion = T4.CodInstitucion ";
                break;

        }




        tsql += "WHERE T1.CodNino = T1.CodNino ";

        if (ap1.Length > 1)
        {
            tsql += " AND T1.Apellido_Paterno LIKE '" + ap1 + "%'";
        }
        if (ap2.Length > 1)
        {
            tsql += " AND T1.Apellido_Materno LIKE '" + ap2 + "%'";
        }
        if (rut.Length > 1)
        {
            tsql += " AND T1.Rut = '" + rut + "'";
        }
        if (codnino.Length > 1)
        {
            tsql += " AND T1.CodNino = '" + codnino + "'";
        }
        if (sexo.Length > 0)
        {
            tsql += " AND T1.sexo = '" + sexo + "'";
        }
        if (inst.Length > 1 && qt == querytype.inproyect)
        {
            tsql += " AND T5.CodInstitucion = " + inst;
            tsql += " AND T4.CodProyecto = " + codproyecto;
            tsql += " AND T2.EstadoIE = 0";
        }

        /*else if (qt == querytype.inred)
        {
            tsql += " AND T4.CodProyecto <> " + codproyecto;

        }*/

        if (nombres.Length > 1)
        {
            tsql += " AND T1.Nombres like  '%" + nombres + "%' ";
        }



        return tsql;


    }





    public DataTable SQL_NinoII(querytype qt, string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres, string codproyecto)
    {
        string TipoConsulta = "";
        //string tSQL = string.Empty;
        switch (qt)
        {
            case querytype.onlycount:
                TipoConsulta = "1";
                break;
            case querytype.inred:
                TipoConsulta = "2";
                break;
            case querytype.inproyect:
                TipoConsulta = "3";
                break;
            case querytype.inlista:
                TipoConsulta = "4";
                break;
        }

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Busqueda_IngresoNino";
        sqlc.Parameters.AddWithValue("@TipoConsulta", TipoConsulta);
        sqlc.Parameters.AddWithValue("@Apellido_Paterno", ap1);
        sqlc.Parameters.AddWithValue("@Apellido_Materno", ap2);
        sqlc.Parameters.AddWithValue("@Rut", rut);
        sqlc.Parameters.AddWithValue("@CodNino", codnino);
        sqlc.Parameters.AddWithValue("@Sexo", sexo);
        sqlc.Parameters.AddWithValue("@CodInstitucion", inst);
        sqlc.Parameters.AddWithValue("@Nombres", nombres);
        sqlc.Parameters.AddWithValue("@CodProyecto", codproyecto);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();

        //if (dt.Rows.Count > 0)
        //    tSQL = dt.Rows[0][0].ToString();

        return dt;
    }

    public DataTable SQL_NinoListaEspera(querytype qt, int codnino, string codproyecto)
    {
        string TipoConsulta = "";
        string tSQL = string.Empty;
        switch (qt)
        {
            case querytype.onlycount:
                TipoConsulta = "1";
                break;
            case querytype.inred:
                TipoConsulta = "2";
                break;
            case querytype.inproyect:
                TipoConsulta = "3";
                break;
            case querytype.inlista:
                TipoConsulta = "4";
                break;
        }

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GET_ListaEspera";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 10).Value = codnino;
        //sqlc.Parameters.Add("@CodProyecto", SqlDbType.VarChar, 255).Value = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        //if (dt.Rows.Count > 0)
        //    tSQL = dt.Rows[0][0].ToString();

        return dt; // tSQL;
    }

    public DataTable SQL_ProyectosByUser(int userid, int CodInstitucion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 10).Value = userid;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 10).Value = CodInstitucion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }


    public DataTable Get_NinosEnOtrosProyectos(string CodNino, string CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_NinosEnOtrosProyectos";
        sqlc.Parameters.Add("@CodNino", SqlDbType.VarChar, 255).Value = CodNino;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.VarChar, 255).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }
    public nino GetDataTransactional(SqlTransaction sqlt, string codnino, string ICodIE)
    {
        DbDataReader datareader = null;
        //Conexiones con = new Conexiones();
        //List<DbParameter> listDbParameter = new List<DbParameter>();

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.CommandType = System.Data.CommandType.Text;

        string tsql = "SELECT DISTINCT T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento,";
        tsql += " CodProyecto = CASE WHEN T2.CodProyecto is null then 0 else T2.CodProyecto end ";
        tsql += ", NombreProy = CASE WHEN T4.Nombre is null then '0' else T4.Nombre end ";
        tsql += ", NombreInst = CASE WHEN T5.Nombre is null then '0' else T5.Nombre end ";
        tsql += ", FechaIngreso = CASE WHEN T2.FechaIngreso is null then 0 else T2.FechaIngreso end ";
        tsql += ", CodInstitucion = CASE WHEN T5.CodInstitucion is null then 0 else T5.CodInstitucion end ";
        tsql += " FROM NINOS T1 ";
        tsql += "LEFT OUTER JOIN Ingresos_Egresos T2 ON T2.Codnino = T1.Codnino ";
        tsql += "LEFT OUTER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";
        tsql += "LEFT OUTER JOIN Instituciones T5 ON T5.CodInstitucion = T4.CodInstitucion ";
        tsql += "WHERE T1.CodNino =@pCodNino ";

        //listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(codnino)));
        sqlc.Parameters.Add("@pCodNino", SqlDbType.Int, 4).Value = Convert.ToInt32(codnino);

        if (Convert.ToInt32(ICodIE) != 0)
        {
            tsql += " AND ICODIE=@pICODIE";

            sqlc.Parameters.Add("@pICODIE", SqlDbType.Int, 4).Value = Convert.ToInt32(ICodIE);
        }

        sqlc.Connection = sqlt.Connection;
        sqlc.CommandText = tsql;
        sqlc.Transaction = sqlt;


        //con.ejecutar(tsql, listDbParameter, out datareader);

        datareader = sqlc.ExecuteReader();

        nino n = null;

        if (datareader.Read())
        {
            try
            {

                n = new nino();
                n.CodNino = Convert.ToInt32(datareader["CodNino"]);
                n.rut = datareader["Rut"].ToString();
                n.sexo = datareader["Sexo"].ToString();
                n.Nombres = datareader["Nombres"].ToString();
                n.Apellido_Paterno = datareader["Apellido_Paterno"].ToString();
                n.Apellido_Materno = datareader["Apellido_Materno"].ToString();
                n.ICodIE = Convert.ToInt32(ICodIE);
                try
                {
                    n.FechaNacimiento = Convert.ToDateTime(datareader["FechaNacimiento"]);
                }
                catch { }
                n.CodInst = (System.Int32)datareader["CodInstitucion"];
                n.CodProyecto = (System.Int32)datareader["CodProyecto"];
                n.NombreProy = (System.String)datareader["NombreProy"];
                n.NombreInst = (System.String)datareader["NombreInst"];
                try
                {
                    n.fchingdesde = (System.DateTime)datareader["FechaIngreso"];

                }
                catch { }
                // agregado felipe
                //  
                //n.fchinghasta = (System.DateTime)datareader["FechaIngreso"];

            }
            catch { }
        }

        datareader.Close();
        //con.Desconectar();
        return n;

    }
    public nino GetData(string codnino, string ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string tsql = "SELECT DISTINCT T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento,";
        tsql += " CodProyecto = CASE WHEN T2.CodProyecto is null then 0 else T2.CodProyecto end ";
        tsql += ", NombreProy = CASE WHEN T4.Nombre is null then '0' else T4.Nombre end ";
        tsql += ", NombreInst = CASE WHEN T5.Nombre is null then '0' else T5.Nombre end ";
        tsql += ", FechaIngreso = CASE WHEN T2.FechaIngreso is null then 0 else T2.FechaIngreso end ";
        tsql += ", CodInstitucion = CASE WHEN T5.CodInstitucion is null then 0 else T5.CodInstitucion end ";
        tsql += " FROM NINOS T1 ";
        tsql += "LEFT OUTER JOIN Ingresos_Egresos T2 ON T2.Codnino = T1.Codnino ";
        tsql += "LEFT OUTER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";
        tsql += "LEFT OUTER JOIN Instituciones T5 ON T5.CodInstitucion = T4.CodInstitucion ";
        tsql += "WHERE T1.CodNino =@pCodNino ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(codnino)));

        if (Convert.ToInt32(ICodIE) != 0)
        {
            tsql += " AND ICODIE=@pICODIE";

            listDbParameter.Add(Conexiones.CrearParametro("@pICODIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        }
        con.ejecutar(tsql, listDbParameter, out datareader);
        nino n = null;

        if (datareader.Read())
        {
            try
            {

                n = new nino();
                n.CodNino = Convert.ToInt32(datareader["CodNino"]);
                n.rut = datareader["Rut"].ToString();
                n.sexo = datareader["Sexo"].ToString();
                n.Nombres = datareader["Nombres"].ToString();
                n.Apellido_Paterno = datareader["Apellido_Paterno"].ToString();
                n.Apellido_Materno = datareader["Apellido_Materno"].ToString();
                n.ICodIE = Convert.ToInt32(ICodIE);
                try
                {
                    n.FechaNacimiento = Convert.ToDateTime(datareader["FechaNacimiento"]);
                }
                catch { }
                n.CodInst = (System.Int32)datareader["CodInstitucion"];
                n.CodProyecto = (System.Int32)datareader["CodProyecto"];
                n.NombreProy = (System.String)datareader["NombreProy"];
                n.NombreInst = (System.String)datareader["NombreInst"];
                try
                {
                    n.fchingdesde = (System.DateTime)datareader["FechaIngreso"];

                }
                catch { }
                // agregado felipe
                //  
                //n.fchinghasta = (System.DateTime)datareader["FechaIngreso"];

            }
            catch { }
        }
        datareader.Close();
        con.Desconectar();
        return n;

    }

    public nino GetDataTransaccional(SqlTransaction sqlt, string codnino, string ICodIE)
    {
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.CommandType = System.Data.CommandType.Text;

        string tsql = "SELECT DISTINCT T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento,";
        tsql += " CodProyecto = CASE WHEN T2.CodProyecto is null then 0 else T2.CodProyecto end ";
        tsql += ", NombreProy = CASE WHEN T4.Nombre is null then '0' else T4.Nombre end ";
        tsql += ", NombreInst = CASE WHEN T5.Nombre is null then '0' else T5.Nombre end ";
        tsql += ", FechaIngreso = CASE WHEN T2.FechaIngreso is null then 0 else T2.FechaIngreso end ";
        tsql += ", CodInstitucion = CASE WHEN T5.CodInstitucion is null then 0 else T5.CodInstitucion end ";
        tsql += " FROM NINOS T1 ";
        tsql += "LEFT OUTER JOIN Ingresos_Egresos T2 ON T2.Codnino = T1.Codnino ";
        tsql += "LEFT OUTER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";
        tsql += "LEFT OUTER JOIN Instituciones T5 ON T5.CodInstitucion = T4.CodInstitucion ";
        tsql += "WHERE T1.CodNino =@pCodNino ";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(codnino)));

        if (Convert.ToInt32(ICodIE) != 0)
        {
            tsql += " AND ICODIE=@pICODIE";

            sqlc.Parameters.Add(Conexiones.CrearParametro("@pICODIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        }

        sqlc.Connection = sqlt.Connection;
        sqlc.CommandText = tsql;
        sqlc.Transaction = sqlt;

        datareader = sqlc.ExecuteReader();

        nino n = null;

        if (datareader.Read())
        {
            try
            {

                n = new nino();
                n.CodNino = Convert.ToInt32(datareader["CodNino"]);
                n.rut = datareader["Rut"].ToString();
                n.sexo = datareader["Sexo"].ToString();
                n.Nombres = datareader["Nombres"].ToString();
                n.Apellido_Paterno = datareader["Apellido_Paterno"].ToString();
                n.Apellido_Materno = datareader["Apellido_Materno"].ToString();
                n.ICodIE = Convert.ToInt32(ICodIE);
                try
                {
                    n.FechaNacimiento = Convert.ToDateTime(datareader["FechaNacimiento"]);
                }
                catch { }
                n.CodInst = (System.Int32)datareader["CodInstitucion"];
                n.CodProyecto = (System.Int32)datareader["CodProyecto"];
                n.NombreProy = (System.String)datareader["NombreProy"];
                n.NombreInst = (System.String)datareader["NombreInst"];
                try
                {
                    n.fchingdesde = (System.DateTime)datareader["FechaIngreso"];

                }
                catch { }
                // agregado felipe
                //  
                //n.fchinghasta = (System.DateTime)datareader["FechaIngreso"];

            }
            catch { }
        }
        datareader.Close();

        return n;

    }

    public nino GetData(string codnino, string ICodIE, string CodIngresoLE)
    {
        DbDataReader datareader = null;
        DbDataReader datareader2 = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string tsql = tsql = "SELECT DISTINCT T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento,";

        tsql += " CodProyecto = CASE WHEN T2.CodProyecto is null then 0 else T2.CodProyecto end ";
        tsql += ", NombreProy = CASE WHEN T4.Nombre is null then '0' else T4.Nombre end ";
        tsql += ", NombreInst = CASE WHEN T5.Nombre is null then '0' else T5.Nombre end ";
        tsql += ", FechaIngreso = CASE WHEN T2.FechaIngreso is null then 0 else T2.FechaIngreso end ";
        // agregado por Felipe
        // tsql += ", CodInstitucion = CASE WHEN T5.CodInstitucion is null then 0 else T5.CodInstitucion end";
        tsql += " FROM NINOS T1 ";
        tsql += "LEFT OUTER JOIN Ingresos_Egresos T2 ON T2.Codnino = T1.Codnino ";
        tsql += "LEFT OUTER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";
        tsql += "LEFT OUTER JOIN Instituciones T5 ON T5.CodInstitucion = T4.CodInstitucion ";
        tsql += "WHERE T1.CodNino =@pCodNino ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(codnino)));

        if (Convert.ToInt32(ICodIE) != 0)
        {
            tsql += " AND ICODIE=@pICODIE";

            listDbParameter.Add(Conexiones.CrearParametro("@pICODIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        }
        con.ejecutar(tsql, listDbParameter, out datareader);



        nino n = null;

        if (datareader.Read())
        {
            try
            {
                n = new nino();
                n.CodNino = Convert.ToInt32(datareader["CodNino"]);
                n.rut = datareader["Rut"].ToString();
                n.sexo = datareader["Sexo"].ToString();
                n.Nombres = datareader["Nombres"].ToString();
                n.Apellido_Paterno = datareader["Apellido_Paterno"].ToString();
                n.Apellido_Materno = datareader["Apellido_Materno"].ToString();
                try
                {
                    n.FechaNacimiento = Convert.ToDateTime(datareader["FechaNacimiento"]);
                }
                catch { }
                n.CodProyecto = (System.Int32)datareader["CodProyecto"];
                n.NombreProy = (System.String)datareader["NombreProy"];
                n.NombreInst = (System.String)datareader["NombreInst"];
                try
                {
                    n.fchingdesde = (System.DateTime)datareader["FechaIngreso"];

                }
                catch { }
                // agregado felipe
                //  n.CodInst = (System.Int32)datareader["CodInstitucion"];
                //n.fchinghasta = (System.DateTime)datareader["FechaIngreso"];

            }
            catch { }
        }

        string tsql2 = tsql2 = "select a.CodTribunal, b.CodTribunal Tribunal , a.RUC, a.rit, a.FechaOrden, b.TipoTribunal, c.Descripcion DesTipoTribunal,";

        tsql2 += "b.CodRegion  , d.Descripcion Region, e.CodTipoCausalIngreso, e.CodCausalIngreso Causal, e.CodNumCausal from  ListaEspera a ";

        tsql2 += "inner join parTribunales b on a.CodTribunal  = b.CodTribunal inner join parTipoTribunal c on b.TipoTribunal = c.TipoTribunal ";

        tsql2 += "inner join parRegion d on b.CodRegion = d.CodRegion inner join parCausalesIngreso e on a.codcausalingreso  = e.CodCausalIngreso ";

        tsql2 += "inner join parTipoCausalIngreso f on e.CodTipoCausalIngreso= f.CodTipoCausalIngreso ";

        tsql2 += "where a.ICodIngresoLE =@pICodIngresoLE ";

        listDbParameter.Clear();
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIngresoLE", SqlDbType.Int, 4, Convert.ToInt32(CodIngresoLE)));

        con.ejecutar(tsql2, listDbParameter, out datareader2);

        if (datareader2.Read())
        {
            try
            {
                n.CodTribunal = (System.Int32)datareader2["CodTribunal"];
                n.Tribunal = (System.Int32)datareader2["Tribunal"];
                n.RUC = (System.String)datareader2["RUC"];
                n.RIT = (System.String)datareader2["rit"];
                n.FechaOrden = (System.DateTime)datareader2["FechaOrden"];
                n.Tipo_Tribunal = (System.Int32)datareader2["TipoTribunal"];
                n.DesTipoTribunal = (System.String)datareader2["DesTipoTribunal"];
                n.CodRegion = (System.Int32)datareader2["CodRegion"];
                n.Region = (System.String)datareader2["Region"];
                n.CodTipoCausalIngreso = (System.Int32)datareader2["CodTipoCausalIngreso"];
                n.CodCausal = (System.Int32)datareader2["Causal"];
                n.CodNumCausal = (System.Int32)datareader2["CodNumCausal"];
            }
            catch (Exception ex)
            {

            }
        }

        con.Desconectar();
        return n;

    }




    public DataTable GetDataLE_Ingreso(string codingresoLE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string tsql = "SELECT * ";
        tsql += "FROM ListaEspera ";
        tsql += "WHERE ICodIngresoLE =@pICodIngresoLE";

        listDbParameter.Add(Conexiones.CrearParametro("@pICodIngresoLE", SqlDbType.Int, 4, Convert.ToInt32(codingresoLE)));

        con.ejecutar(tsql, listDbParameter, out datareader);
        ninoslist nlist = new ninoslist();


        DataTable dt = new DataTable();
        DataRow dr;


        dt.Columns.Add(new DataColumn("ICodIngresoLE"));
        dt.Columns.Add(new DataColumn("CodNino"));
        dt.Columns.Add(new DataColumn("ICodIE"));
        dt.Columns.Add(new DataColumn("FechaIngresoLE"));
        dt.Columns.Add(new DataColumn("FechaEgresoLE"));
        dt.Columns.Add(new DataColumn("CodTribunal"));
        dt.Columns.Add(new DataColumn("RUC"));
        dt.Columns.Add(new DataColumn("RIT"));
        dt.Columns.Add(new DataColumn("FechaOrden"));
        dt.Columns.Add(new DataColumn("CodCausalIngreso"));
        dt.Columns.Add(new DataColumn("CodProyecto"));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion"));
        dt.Columns.Add(new DataColumn("FechaActualizacion"));
        dt.Columns.Add(new DataColumn("Estado"));


        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["ICodIngresoLE"];
                dr[1] = (System.Int32)datareader["CodNino"];
                dr[2] = (System.Int32)datareader["ICodIE"];
                dr[3] = (System.DateTime)datareader["FechaIngresoLE"];
                dr[4] = (System.DateTime)datareader["FechaEgresoLE"];
                dr[5] = (System.Int32)datareader["CodTribunal"];
                dr[6] = ((System.String)datareader["RUC"]);
                dr[7] = (System.String)datareader["RIT"];
                dr[8] = (System.DateTime)datareader["FechaOrden"];
                dr[9] = (System.Int32)datareader["CodCausalIngreso"];
                dr[10] = (System.Int32)datareader["CodProyecto"];
                dr[11] = (System.Int32)datareader["IdUsuarioActualizacion"];
                dr[12] = (System.DateTime)datareader["FechaActualizacion"];
                dr[13] = (System.Int32)datareader["Estado"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;

    }
    public DataTable GetDataLE(querytype qt, string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres, string codproyecto)
    {
        //DbDataReader datareader = null;
        // Conexiones con = new Conexiones();
        //DbParameter[] parametros = { };
        //con.ejecutar(SQL_NinoListaEspera(qt, 133862, codproyecto, objconn));

        //counter = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string tsql = "SELECT T1.ICodIngresoLE, T1.codnino, T2.Rut, T2.Sexo, T2.Nombres, T2.Apellido_Paterno, T2.Apellido_Materno, T2.FechaNacimiento, T1.FechaIngresoLE, T1.CodProyecto ";

        tsql += "FROM ListaEspera T1 INNER JOIN Ninos T2 on T1.codnino =T2.codnino ";
        tsql += "WHERE T1.Estado = 0 ";

        if (codnino != "0")
        {
            tsql += " AND T1.codnino =@pcodnino";

            listDbParameter.Add(Conexiones.CrearParametro("@pcodnino", SqlDbType.Int, 20, Convert.ToInt32(codnino)));
        }
        if (rut != string.Empty)
        {
            tsql += " AND T2.Rut Like @pRut ";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, "%" + rut + "%"));
        }
        if (ap1 != string.Empty)
        {
            tsql += " AND T2.Apellido_Paterno like @pApellido_Paterno ";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + ap1 + "%"));
        }
        if (ap2 != string.Empty)
        {
            tsql += " AND T2.Apellido_Materno like @pApellido_Materno ";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + ap2 + "%"));
        }
        if (nombres != string.Empty)
        {
            tsql += " AND T2.Nombres like @pNombres ";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + nombres + "%"));
        }
        if (sexo != string.Empty)
        {
            tsql += " AND T2.Sexo = @pSexo ";

            listDbParameter.Add(Conexiones.CrearParametro("@pSexo", SqlDbType.Char, 1, sexo));
        }

        try
        {

            con.ejecutar(tsql, listDbParameter, out datareader);
        }
        catch (Exception ex)
        {

        }
        ninoslist nlist = new ninoslist();


        DataTable dt = new DataTable();
        DataRow dr;


        dt.Columns.Add(new DataColumn("CodigoNino", typeof(int)));
        dt.Columns.Add(new DataColumn("Rut"));
        dt.Columns.Add(new DataColumn("Sexo"));
        dt.Columns.Add(new DataColumn("Nombres"));
        dt.Columns.Add(new DataColumn("Apellido Paterno"));
        dt.Columns.Add(new DataColumn("Apellido Materno"));
        dt.Columns.Add(new DataColumn("Fecha de Nacimiento"));

        if (qt == querytype.inlista)
        {
            dt.Columns.Add(new DataColumn("FechaIngresoLE"));
            dt.Columns.Add(new DataColumn("CodProyecto"));
            dt.Columns.Add(new DataColumn("Ingresar"));
            dt.Columns.Add(new DataColumn("Seleccionar"));
            dt.Columns.Add(new DataColumn("ICodIngresoLE", typeof(int)));
            while (datareader.Read())
            {
                try
                {

                    dr = dt.NewRow();
                    dr[0] = (System.Int32)datareader["CodNino"];
                    dr[1] = (System.String)datareader["Rut"];
                    dr[2] = (System.String)datareader["Sexo"];
                    dr[3] = (System.String)datareader["Nombres"];
                    dr[4] = (System.String)datareader["Apellido_Paterno"];
                    dr[5] = (System.String)datareader["Apellido_Materno"];

                    try
                    {
                        dr[6] = ((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString();
                    }
                    catch
                    {
                        dr[6] = "";
                    }
                    dr[7] = (System.DateTime)datareader["FechaIngresoLE"];
                    dr[8] = (System.Int32)datareader["CodProyecto"];
                    dr[9] = "Ingresar";
                    dr[10] = "Seleccionar";
                    dr[11] = (System.Int32)datareader["ICodIngresoLE"];
                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                }
            }
        }
        con.Desconectar();

        return dt;
    }

    public DataTable GetData(querytype qt, string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres, string codproyecto, out int counter)
    {

        //DbDataReader datareader = null;
        //Conexiones con = new Conexiones();
        //DbParameter[] parametros = { };
        //ninoslist nlist = new ninoslist();
        //con.ejecutar(SQL_NinoII(qt, ap1, ap2, rut, codnino, sexo, inst, nombres, codproyecto), out datareader);
        //dt.Rows[0][0].ToString();

        DataTable DtNinosIngreso = SQL_NinoII(qt, ap1, ap2, rut, codnino, sexo, inst, nombres, codproyecto);
        //counter = 0;

        //DataTable dt = new DataTable();
        //DataRow dr;

        //if (qt == querytype.onlycount)
        //{
        //    //if (datareader.Read()) { counter = (System.Int32)datareader["counter"]; }

        //    if (DtNinosIngreso.Rows.Count > 0)
        //    {
        //        counter = Convert.ToInt32(DtNinosIngreso.Rows[0][0]);
        //    }
        //}

        //dt.Columns.Add(new DataColumn("Codigo Niño", typeof(int)));
        //dt.Columns.Add(new DataColumn("Rut"));
        //dt.Columns.Add(new DataColumn("Sexo"));
        //dt.Columns.Add(new DataColumn("Nombres"));
        //dt.Columns.Add(new DataColumn("Apellido Paterno"));
        //dt.Columns.Add(new DataColumn("Apellido Materno"));
        //dt.Columns.Add(new DataColumn("Fecha de Nacimiento"));

        //if (qt == querytype.inproyect)
        //{
        //    dt.Columns.Add(new DataColumn("Codigo de Proyecto"));
        //    dt.Columns.Add(new DataColumn("Nombre del Proyecto"));
        //    dt.Columns.Add(new DataColumn("Nombre Institución"));
        //    dt.Columns.Add(new DataColumn("Fecha Ingreso"));
        //    dt.Columns.Add(new DataColumn("Fecha Ingresoo"));
        //    dt.Columns.Add(new DataColumn("IN", typeof(bool)));
        //    dt.Columns.Add(new DataColumn("Ingresar"));
        //    dt.Columns.Add(new DataColumn("Seleccionar"));
        //    dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        //}

        //else
        //{
        //   if (qt == querytype.inred)
        //       dt.Columns.Add(new DataColumn("CantidadVecesVigenteEnOtrosProyectos"));

        //    while (datareader.Read())
        //    {
        //        try
        //        {

        //            dr = dt.NewRow();
        //            dr[0] = (System.Int32)datareader["CodNino"];
        //            dr[1] = (System.String)datareader["Rut"];
        //            dr[2] = (System.String)datareader["Sexo"];
        //            dr[3] = (System.String)datareader["Nombres"];
        //            dr[4] = (System.String)datareader["Apellido_Paterno"];
        //            dr[5] = (System.String)datareader["Apellido_Materno"];

        //            try
        //            {
        //                dr[6] = ((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString();
        //            }
        //            catch
        //            {
        //                dr[6] = "";
        //            }

        //            if (qt == querytype.inproyect)
        //            {
        //                dr[7] = (System.Int32)datareader["CodProyecto"];
        //                dr[8] = (System.String)datareader["NombreProy"];
        //                dr[9] = (System.String)datareader["NombreInst"];
        //                dr[10] = ((System.DateTime)datareader["FechaIngreso"]).ToShortDateString();
        //                dr[11] = ((System.DateTime)datareader["FechaIngreso"]).ToShortDateString();
        //                dr[12] = false;
        //                dr[13] = "Ingresar";
        //                dr[14] = "Seleccionar";
        //                dr[15] = (System.Int32)datareader["ICodIE"];
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    dr[7] = (System.Int32)datareader["CantidadVecesVigenteEnOtrosProyectos"];
        //                }
        //                catch
        //                {
        //                    dr[7] = "";
        //                }
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //        catch
        //        { }
        //    }
        //    counter = dt.Rows.Count;
        //}
        //con.Desconectar();
        if (DtNinosIngreso.Rows.Count > 0)
        {
            counter = Convert.ToInt32(DtNinosIngreso.Rows[0][0]);
        }
        else
        {
            counter = 0;
        }

        return DtNinosIngreso;
    }

    //furrutia 22-10-2014
    //public DataTable GetDataEgre(querytype qt, string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres, string codproyecto, out int counter)
    //{

    //    DbDataReader datareader = null;
    //    Conexiones con = new Conexiones();
    //    DbParameter[] parametros = { };
    //    con.ejecutar(SQL_NinoII(qt, ap1, ap2, rut, codnino, sexo, inst, nombres, codproyecto), out datareader);

    //    counter = 0;
    //    ninoslist nlist = new ninoslist();


    //    DataTable dt = new DataTable();
    //    DataRow dr;

    //    dt.Columns.Add(new DataColumn("Codigo Niño", typeof(int)));
    //    dt.Columns.Add(new DataColumn("Rut"));
    //    dt.Columns.Add(new DataColumn("Sexo"));
    //    dt.Columns.Add(new DataColumn("Nombres"));
    //    dt.Columns.Add(new DataColumn("Apellido Paterno"));
    //    dt.Columns.Add(new DataColumn("Apellido Materno"));
    //    dt.Columns.Add(new DataColumn("Fecha de Nacimiento"));

    //    if (qt == querytype.inproyect)
    //    {
    //        dt.Columns.Add(new DataColumn("Codigo de Proyecto"));
    //        dt.Columns.Add(new DataColumn("Nombre del Proyecto"));
    //        dt.Columns.Add(new DataColumn("Nombre Institución"));
    //        dt.Columns.Add(new DataColumn("Fecha Ingreso"));
    //        dt.Columns.Add(new DataColumn("Fecha Ingresoo"));
    //        dt.Columns.Add(new DataColumn("IN", typeof(bool)));
    //        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
    //    }


    //    if (qt == querytype.onlycount)
    //    {
    //        if (datareader.Read())
    //        {
    //            counter = (System.Int32)datareader["counter"];
    //        }

    //    }
    //    else
    //    {
    //        if (qt == querytype.inred)
    //            dt.Columns.Add(new DataColumn("CantidadVecesVigenteEnOtrosProyectos"));

    //        while (datareader.Read())
    //        {
    //            try
    //            {

    //                dr = dt.NewRow();
    //                dr[0] = (System.Int32)datareader["CodNino"];
    //                dr[1] = (System.String)datareader["Rut"];
    //                dr[2] = (System.String)datareader["Sexo"];
    //                dr[3] = (System.String)datareader["Nombres"];
    //                dr[4] = (System.String)datareader["Apellido_Paterno"];
    //                dr[5] = (System.String)datareader["Apellido_Materno"];

    //                try
    //                {
    //                    dr[6] = ((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString();
    //                }
    //                catch
    //                {
    //                    dr[6] = "";
    //                }

    //                if (qt == querytype.inproyect)
    //                {
    //                    dr[7] = (System.Int32)datareader["CodProyecto"];
    //                    dr[8] = (System.String)datareader["NombreProy"];
    //                    dr[9] = (System.String)datareader["NombreInst"];
    //                    dr[10] = ((System.DateTime)datareader["FechaIngreso"]).ToShortDateString();
    //                    dr[11] = ((System.DateTime)datareader["FechaIngreso"]).ToShortDateString();
    //                    dr[12] = false;
    //                    dr[13] = (System.Int32)datareader["ICodIE"];
    //                }
    //                else
    //                {
    //                    try
    //                    {
    //                        dr[7] = (System.Int32)datareader["CantidadVecesVigenteEnOtrosProyectos"];
    //                    }
    //                    catch
    //                    {
    //                        dr[7] = "";
    //                    }
    //                }
    //                dt.Rows.Add(dr);
    //            }
    //            catch
    //            { }
    //        }
    //        counter = dt.Rows.Count;
    //    }
    //    con.Desconectar();

    //    return dt;
    //}

    public DataTable callto_getninosxproyectos(int codproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinosxProyectos";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    // Felipe Ormazabal 01/09/2006

    public DataTable callto_update_ingresos_egresos(int icodie, string personacontacto, int codtiporelacionpersonacontacto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_Ingresos_Egresos";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@PersonaContacto", SqlDbType.VarChar, 50).Value = personacontacto;
        sqlc.Parameters.Add("@CodTipoRelacionPersonaContacto", SqlDbType.Int, 4).Value = codtiporelacionpersonacontacto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable callto_update_ListaEspera(int icodie, int ICodIngresoLE)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "UPDATE_ListaEspera";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 50).Value = icodie;
        sqlc.Parameters.Add("@ICodIngreso", SqlDbType.Int, 50).Value = ICodIngresoLE;
        sqlc.Parameters.Add("@FechaEgreso", SqlDbType.DateTime).Value = DateTime.Now;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public bool ConsultaRutnino(string rut)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.ConsultaRutnino + "@prut";
        listDbParameter.Add(Conexiones.CrearParametro("@prut", SqlDbType.VarChar, 11, rut));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        bool sw = false;
        dt.Columns.Add(new DataColumn("rut", typeof(String)));

        dr = dt.NewRow();

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["rut"];

                dt.Rows.Add(dr);
            }
            catch { sw = true; }
            sw = true;
        }
        con.Desconectar();
        return sw;
    }

    
    public DataTable consulta_Adopcion_Tipo_Usuario(int subprograma)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "SELECT CODTIPOUSUARIO, DESCRIPCION, INDVIGENCIA, TIPOSUBPROGRAMA FROM PARADOPCIONTIPOUSUARIO WHERE INDVIGENCIA = 'V' AND TIPOSUBPROGRAMA ='" + subprograma + "'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("codtipousuario", typeof(int)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("indvigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("tiposubprograma", typeof(int)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["codtipousuario"];
                dr[1] = (String)datareader["descripcion"];
                dr[2] = (String)datareader["indvigencia"];
                dr[3] = (int)datareader["tiposubprograma"];

                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }

    public DataTable consulta_LPRA_ADOPCION(string rut, string codnino)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = "SELECT fechanacimiento FROM ninos WHERE rut =@prut and Codnino =@pCodnino";
        listDbParameter.Add(Conexiones.CrearParametro("@prut", SqlDbType.VarChar, 11, rut));
        listDbParameter.Add(Conexiones.CrearParametro("@pCodnino", SqlDbType.Int, 4, Convert.ToInt32(codnino)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("fechanacimiento", typeof(DateTime)));
        DateTime fecha = Convert.ToDateTime("01-01-1800");
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (DateTime)datareader["fechanacimiento"];

                dt.Rows.Add(dr);
            }
            catch
            {
                dr = dt.NewRow();
                dr[0] = fecha;
                dt.Rows.Add(dr);
            }

        }
        con.Desconectar();
        return dt;
    }


    public DataTable consulta_region_adulto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "select codregion, descripcion, codigoregion from parregion where indvigencia = 'V'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("codregion", typeof(int)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("codigoregion", typeof(int)));

        dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["codregion"];
                dr[1] = (String)datareader["descripcion"];
                dr[2] = (int)datareader["codigoregion"];

                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }
    public DataTable consulta_comuna_Adulto(int codregion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sqladd = "ORDER BY parRegion.Descripcion";
        con.ejecutar(Resources.Procedures.Get_comuna_adulto + codregion + " " + sqladd, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Codregion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(String)));


        dr = dt.NewRow();
        dr[1] = -2;
        dr[2] = "Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodRegion"];
                dr[1] = (int)datareader["CodComuna"];
                dr[2] = (String)datareader["descripcion"];


                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }

    public DataTable consulta_DATOSPROYECTO_Adulto(int codproy, int CodModeloIntervencion)
    {
        DataRow dr;

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;

        sqlc.CommandText = "getDatosProyectoAdulto";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproy;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);

        dr = dt.NewRow();
        dr[1] = -2;
        dr[5] = " Seleccionar";
        dt.Rows.Add(dr);

        sconn.Close();
        return dt;
    }



    public DataTable filtro_ingreso_adulto(int codproy)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.consulta_filtro_adulto + codproy, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;



        dt.Columns.Add(new DataColumn("Nemotecnico", typeof(string)));
        dt.Columns.Add(new DataColumn("Modelo", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (string)datareader["Nemotecnico"];
                dr[1] = (int)datareader["Modelo"];
                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }

    public DataTable filtro_DEPRODE_ADOPCION(int codproy)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "SELECT codinstitucion, codproyecto FROM Proyectos WHERE CodDepartamentosSENAME <> 7 AND CodProyecto ='" + codproy + "'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;



        dt.Columns.Add(new DataColumn("codinstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["codinstitucion"];
                dr[1] = (int)datareader["codproyecto"];
                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }

    public DataTable filtro_LPRA_SANCION2(int opcion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "SELECT LRPA FROM parTipoCausalIngreso WHERE CodTipoCausalIngreso = '" + opcion + "'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;



        dt.Columns.Add(new DataColumn("LRPA", typeof(int)));




        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["LRPA"];

                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }


    public DataTable consulta_Nacionalidad_Adulto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "select codnacionalidad,  codintenacional, descripcion, indvigencia from parnacionalidades where CodNacionalidad <> 0";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("codnacionalidad", typeof(int)));
        dt.Columns.Add(new DataColumn("codintenacional", typeof(string)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("indvigencia", typeof(string)));

        dr = dt.NewRow();
        dr[0] = -1;
        dr[2] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["codnacionalidad"];
                dr[1] = (string)datareader["codintenacional"];
                dr[2] = (string)datareader["descripcion"];
                dr[3] = (string)datareader["indvigencia"];

                dt.Rows.Add(dr);
            }
            catch { }

        }
        con.Desconectar();
        return dt;
    }


    public DataTable callto_get_informediagnostico(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_informediagnostico";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;



    }


    public DataTable callto_get_personasrelacionadas(int codpersonarelacionada)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_PersonasRelacionadas";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_get_personasrelacionadasII(int CodPersonaRelacionada, int CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetPersonasRelacionadas_EnProyecto";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = CodPersonaRelacionada;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable ingresoRelacion(int codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "sp_Ingresorelacion";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_getpersonasrelacionadas(int codpersonarelacionada, int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetPersonasRelacionadas";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_getrut_personasrelacionadas(string rut)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetRut_personasRelacionadas";
        sqlc.Parameters.Add("@rut", SqlDbType.VarChar, 100).Value = rut;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetTermino(string ICodInformeDiagnostico)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetTermino + "@pICodInformeDiagnostico";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodInformeDiagnostico", SqlDbType.Int, 4, Convert.ToInt32(ICodInformeDiagnostico)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTerminoDiagnostico", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaTerminoInforme", typeof(DateTime)));
        dr = dt.NewRow();


        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTerminoDiagnostico"];
                dr[1] = (DateTime)datareader["FechaTerminoInforme"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;



    }

    public DataTable GetPersonasRelacionadas(string CodNino)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetPersonasRelacionadas + "@pCodNino";
        listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(CodNino)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        // dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        // dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        // dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        // dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        // dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Agresor", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[5] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPersonaRelacionada"];
                //  dr[1] = (int)datareader["CodNino"];
                dr[1] = (String)datareader["Rut"];
                dr[2] = (String)datareader["Nombres"];
                dr[3] = (String)datareader["Apellido_Paterno"];
                dr[4] = (String)datareader["Apellido_Materno"];
                //  dr[6] = (String)datareader["Sexo"];
                //  dr[7] = (DateTime)datareader["FechaNacimiento"];
                //  dr[8] = (DateTime)datareader["FechaActualizacion"];
                //  dr[9] = (int)datareader["IdUsuarioActualizacion"];
                dr[5] = (String)datareader["Agresor"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_TipoRelacionMaltrato()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.Text;
        sqlc.CommandText = "select TipoRelacion, Descripcion, IndVigencia  from partiporelacion where IndVigencia = 'V'";
       // sqlc.CommandText = "select TipoRelacion, Descripcion, IndVigencia, RepresentaLegal  from partiporelacion where IndVigencia = 'V'";   
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetMadre(string run, string nombres, string apaterno, string amaterno)
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string tsql = "SELECT T1.CodPersonaRelacionada, T1.Rut, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.Sexo,  T1.FechaNacimiento, T1.FechaActualizacion, T1.IdUsuarioActualizacion ";
        tsql += "FROM PersonasRelacionadas T1 ";
        //  tsql += "WHERE T1.SEXO = 'F' AND T1.Rut = '" + run + "' OR (T1.Nombres  LIKE '%" + nombres + "%'  AND  ( T1.Apellido_Paterno = '" + apaterno + "' OR T1.Apellido_Materno = '" + amaterno + "'))";
        if (run.Length > 0)
        {
            tsql += "WHERE T1.SEXO = 'F' AND T1.Rut =@pRut ";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, run));
        }
        else
        {
            tsql += "WHERE T1.SEXO = 'F' AND (T1.Nombres  LIKE @pNombres AND  ( T1.Apellido_Paterno LIKE @pApellido_Paterno OR T1.Apellido_Materno LIKE @pApellido_Materno))";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 30, "%" + nombres + "%"));
            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 30, apaterno + "%"));
            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 30, amaterno + "%"));
        }



        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(tsql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPersonaRelacionada"];
                dr[1] = (String)datareader["Rut"];
                dr[2] = (String)datareader["Nombres"];
                dr[3] = (String)datareader["Apellido_Paterno"];
                dr[4] = (String)datareader["Apellido_Materno"];
                dr[5] = (String)datareader["Sexo"];
                dr[6] = (DateTime)datareader["FechaNacimiento"];
                dr[7] = (DateTime)datareader["FechaActualizacion"];
                dr[8] = (int)datareader["IdUsuarioActualizacion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetPersonasRelacionadas(int CodPersonaRelacionada)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetPersonasRelacionadas2 + CodPersonaRelacionada, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPersonaRelacionada"];
                dr[1] = (String)datareader["Rut"];
                dr[2] = (String)datareader["Nombres"];
                dr[3] = (String)datareader["Apellido_Paterno"];
                dr[4] = (String)datareader["Apellido_Materno"];
                dr[5] = (String)datareader["Sexo"];
                dr[6] = (DateTime)datareader["FechaNacimiento"];
                dr[7] = (DateTime)datareader["FechaActualizacion"];
                dr[8] = (int)datareader["IdUsuarioActualizacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }




    public DataTable callto_search_persona_realcionada(string rut, string nombres, string apellido_materno, string apellido_paterno, int logitud)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string tsql = string.Empty;
        if (logitud > 2)
        {
            tsql = "Select * From PersonasRelacionadas WHERE RUT = @pRUT";

            listDbParameter.Add(Conexiones.CrearParametro("@pRUT", SqlDbType.VarChar, 11, rut));
        }
        else
        {
            tsql = "SELECT * From PersonasRelacionadas WHERE ";
        }


        if ((nombres.Length > 2 && apellido_paterno.Length > 2))
        {
            if (logitud > 2)
            { tsql += " OR "; }

            tsql += " (Nombres  Like @pNombres AND Apellido_Paterno Like @pApellido_Paterno ";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 30, nombres + "%"));
            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 30, apellido_paterno + "%"));

            if (apellido_materno.Length > 2)
            {
                tsql += " AND Apellido_Materno Like @pApellido_Materno";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 30, apellido_materno + "%"));
            }
            tsql += " )";
        }
        else if (nombres.Length > 2 && apellido_materno.Length > 2)
        {
            if (logitud > 2)
            { tsql += " OR "; }

            tsql += " (Nombres  Like @pNombres AND Apellido_Materno Like @pApellido_Materno ";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 30, nombres + "%"));
            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 30, apellido_materno + "%"));

            if (apellido_paterno.Length > 2)
            {
                tsql += " AND Apellido_Paterno Like @pApellido_Paterno";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 30, apellido_paterno + "%"));
            }
            tsql += " )";
        }
        else if (apellido_paterno.Length > 2 || apellido_materno.Length > 2)
        {
            if (logitud > 2)
            { tsql += " OR "; }

            tsql += " (apellido_paterno  Like @pApellido_Paterno  AND Apellido_Materno Like @pApellido_Materno ";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 30, apellido_paterno + "%"));
            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 30, apellido_materno + "%"));

            tsql += " )";
        }


        con.ejecutar(tsql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada2", typeof(int)));
        dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        dt.Columns.Add(new DataColumn("Direccion", typeof(String)));
        dt.Columns.Add(new DataColumn("Telefono", typeof(String)));


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPersonaRelacionada"];
                try
                { dr[1] = (String)datareader["Rut"]; }
                catch { dr[1] = ""; }


                dr[2] = (String)datareader["Nombres"];
                dr[3] = (String)datareader["Apellido_Paterno"];

                try
                {
                    dr[4] = (String)datareader["Apellido_Materno"];
                }
                catch
                {
                    dr[4] = "";
                }



                dr[5] = (String)datareader["Sexo"];
                try { dr[6] = (DateTime)datareader["FechaNacimiento"]; }
                catch { }

                dr[7] = (DateTime)datareader["FechaActualizacion"];
                dr[8] = (int)datareader["IdUsuarioActualizacion"];

                try { dr[9] = (int)datareader["CodPersonaRelacionada2"]; }
                catch { dr[9] = 0; }

                try { dr[10] = (int)datareader["CodComuna"]; }
                catch { dr[10] = 0; }

                try { dr[11] = (String)datareader["Direccion"]; }
                catch { dr[11] = ""; }


                try
                {
                    dr[12] = (String)datareader["Telefono"];
                }
                catch
                {
                    dr[12] = "";
                }
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }



    public DataTable GetIngresoPersonaRelacionada(string ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetIngresoPersonaRelacionada + "@pICodIE";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("CodSituacion1", typeof(int)));
        dt.Columns.Add(new DataColumn("CodSituacion2", typeof(int)));
        dt.Columns.Add(new DataColumn("CodSituacion3", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaRelacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEscolaridadAdulto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProfesion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodActividad", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        //dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));

        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("DescrSitiacion", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodIE"];
                dr[1] = (int)datareader["CodPersonaRelacionada"];
                dr[2] = (int)datareader["CodSituacion1"];
                dr[3] = (int)datareader["CodSituacion2"];
                dr[4] = (int)datareader["CodSituacion3"];
                dr[5] = (DateTime)datareader["FechaRelacion"];
                dr[6] = (int)datareader["TipoRelacion"];
                dr[7] = (int)datareader["CodEscolaridadAdulto"];
                dr[8] = (int)datareader["CodProfesion"];
                dr[9] = (int)datareader["CodNacionalidad"];
                dr[10] = (int)datareader["CodActividad"];
                dr[11] = (DateTime)datareader["FechaActualizacion"];
                //  dr[12] = (int)datareader["IdUsuarioActualizacion"];
                dr[12] = (String)datareader["descripcion"];
                dr[13] = (String)datareader["Rut"];
                dr[14] = (String)datareader["Nombres"];
                dr[15] = (String)datareader["Apellido_Paterno"];
                dr[16] = (String)datareader["Apellido_Materno"];
                dr[17] = (String)datareader["Sexo"];
                dr[18] = (DateTime)datareader["FechaNacimiento"];
                dr[19] = (String)datareader["DescrSitiacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public int SetIngresos_Egresos(SqlTransaction sqlt,
        int CodProyecto,
        int CodNino,
        DateTime FechaIngreso,
        int CodSolicitanteIngreso,
        bool IdentidadConfirmada,
        int CodTipoAtencion,
        int CodCalidadJuridica,/*nuevo*/
        int CodInstitucionInmueble,
        int ICodInmueble,
        int EdadAno,
        int EdadMeses,
        int CodTipoRelacionConQuienVive,
        String PersonaContacto,
        String TelefonoContacto,
        int CodTipoRelacionPersonaContacto,/*nuevo*/
        int CodInstitucion_Entreveistador,   //16
        int CodTrabajador_Entrevistador,     //17
        int CodTrabajador_Revisador,         //18
        bool IngresoComunicadoFamiliaUOtro,  //19
        String HuellaDigital,                //20
        String PresentaLesiones,
        String OrdenesTribunal,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion,
        DateTime FechaEgreso,
        String Glosa,
        int CodCausalEgreso,
        String TieneOrdenTribunal,
        int CodMedidaAplicadaTribunal,
        int CodMedidaSugeridaTribunal,
        int CodConQuienEgresa,
        int CodProyectoEgresa,
        int EstadoIE)
    {

        object ObjEgreso = DBNull.Value;
        if (FechaEgreso != Convert.ToDateTime("01-01-1900").Date)
        {
            ObjEgreso = FechaEgreso;
        }

        //else 
        //{
        //    ObjEgreso = " '" + FechaEgreso.ToString() + "' ";
        //};

        int returnvalue = 0;

        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sqlt.Connection;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;


        DbDataReader datareader = null;
        //Conexiones con = new Conexiones();

        //List<DbParameter> listDbParameter = new List<DbParameter>();

        /*
           CodProyecto, CodNino, FechaIngreso, CodSolicitanteIngreso, 
         * IdentidadConfirmada, CodTipoAtencion, CodCalidadJuridica, ICodInmueble, 
         * EdadAno, EdadMeses, CodTipoRelacionConQuienVive, PersonaContacto, 
         * TelefonoContacto, CodTipoRelacionPersonaContacto, CodTrabajador_Entrevistador, CodTrabajador_Revisador, 
         * IngresoComunicadoFamiliaUOtro, HuellaDigital, PresentaLesiones, OrdenesTribunal, FechaActualizacion, IdUsuarioActualizacion, FechaEgreso, Glosa, CodCausalEgreso, TieneOrdenTribunal, CodMedidaAplicadaTribunal, CodMedidaSugeridaTribunal, CodConQuienEgresa, 
         * CodProyectoEgresa, EstadoIE)
         */
        string qvalues = Resources.Procedures.SetIngresos_Egresos + "@pCodProyecto, @pCodNino, " +
            "@pFechaIngreso, @pCodSolicitanteIngreso, " +
            "@pIdentidadConfirmada, @pCodTipoAtencion, " +
            "@pCodCalidadJuridica, @pCodInstitucionInmueble, " +
            "@pICodInmueble, @pEdadAno, @pEdadMeses, " +
            "@pCodTipoRelacionConQuienVive, @pPersonaContacto, " +
            "@pTelefonoContacto, @pCodTipoRelacionPersonaContacto, " +
            "@pCodInstitucion_Entrevistador, @pCodTrabajador_Entrevistador, " +
            "@pCodTrabajador_Revisador, @pIngresoComunicadoFamiliaUOtro, " +
            "@pHuellaDigital, @pPresentaLesiones, @pOrdenesTribunal, " +
            "@pFechaActualizacion, @pIdUsuarioActualizacion, @pFechaEgreso, " +
            "@pGlosa, @pCodCausalEgreso, @pTieneOrdenTribunal, " +
            "@pCodMedidaAplicadaTribunal, @pCodMedidaSugeridaTribunal, " +
            "@pCodConQuienEgresa, @pCodProyectoEgresa, @pEstadoIE ) SELECT @@identity as identidad";



        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, CodProyecto));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, CodNino));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pFechaIngreso", SqlDbType.DateTime, 8, FechaIngreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodSolicitanteIngreso", SqlDbType.Int, 4, CodSolicitanteIngreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pIdentidadConfirmada", SqlDbType.Bit, 1, Convert.ToByte(IdentidadConfirmada)));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodTipoAtencion", SqlDbType.Int, 4, CodTipoAtencion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodCalidadJuridica", SqlDbType.Int, 4, CodCalidadJuridica));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodInstitucionInmueble", SqlDbType.Int, 4, CodInstitucionInmueble));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pICodInmueble", SqlDbType.Int, 4, ICodInmueble));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pEdadAno", SqlDbType.Int, 4, EdadAno));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pEdadMeses", SqlDbType.Int, 4, EdadMeses));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodTipoRelacionConQuienVive", SqlDbType.Int, 4, CodTipoRelacionConQuienVive));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pPersonaContacto", SqlDbType.VarChar, 50, PersonaContacto));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pTelefonoContacto", SqlDbType.VarChar, 30, TelefonoContacto));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodTipoRelacionPersonaContacto", SqlDbType.Int, 4, CodTipoRelacionPersonaContacto));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodInstitucion_Entrevistador", SqlDbType.Int, 4, 0));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodTrabajador_Entrevistador", SqlDbType.Int, 4, CodTrabajador_Entrevistador));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodTrabajador_Revisador", SqlDbType.Int, 4, CodTrabajador_Revisador));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pIngresoComunicadoFamiliaUOtro", SqlDbType.Bit, 1, Convert.ToByte(IngresoComunicadoFamiliaUOtro)));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pHuellaDigital", SqlDbType.VarChar, 255, HuellaDigital));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pPresentaLesiones", SqlDbType.VarChar, 2, PresentaLesiones));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pOrdenesTribunal", SqlDbType.VarChar, 2, OrdenesTribunal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pFechaActualizacion", SqlDbType.DateTime, 8, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pIdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pFechaEgreso", SqlDbType.DateTime, 8, ObjEgreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pGlosa", SqlDbType.VarChar, 200, Glosa));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodCausalEgreso", SqlDbType.Int, 4, CodCausalEgreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pTieneOrdenTribunal", SqlDbType.Char, 2, TieneOrdenTribunal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodMedidaAplicadaTribunal", SqlDbType.Int, 4, CodMedidaAplicadaTribunal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodMedidaSugeridaTribunal", SqlDbType.Int, 4, CodMedidaSugeridaTribunal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodConQuienEgresa", SqlDbType.Int, 4, CodConQuienEgresa));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pCodProyectoEgresa", SqlDbType.Int, 4, CodProyectoEgresa));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@pEstadoIE", SqlDbType.Int, 4, EstadoIE));

        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = qvalues;

        //sqlc.ExecuteNonQuery();
        //returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        datareader = sqlc.ExecuteReader();
        //con.ejecutar(qvalues, listDbParameter, out datareader);

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        //con.Desconectar();
        return returnvalue;

    }
    //private DataTable callto_insert_ordentribunalingreso(int ICodIE, int CodTribunal, DateTime FechaOrden,
    //    int IdUsuarioActualizacion, string Expediente, string Ruc, string Rit)
    //{
    //    SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
    //    System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
    //    sqlc.Connection = sconn;
    //    sqlc.CommandType = System.Data.CommandType.StoredProcedure;
    //    sqlc.CommandText = "Insert_OrdenTribunalIngreso";
    //    sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
    //    sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = CodTribunal;
    //    sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime, 16).Value = FechaOrden;
    //    sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
    //    sqlc.Parameters.Add("@Expediente", SqlDbType.VarChar, 100).Value = Expediente;
    //    sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar, 100).Value = Ruc;
    //    sqlc.Parameters.Add("@Rit", SqlDbType.VarChar, 100).Value = Rit;
    //    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
    //    DataTable dt = new DataTable();
    //    sconn.Open();
    //    da.Fill(dt);
    //    sconn.Close();
    //    return dt;
    //}


    public int Insert_OrdenTribunalIngreso(int ICodIE, int CodTribunal, DateTime FechaOrden, int IdUsuarioActualizacion, String Expediente, String Ruc, String Rit)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        Conexiones con = new Conexiones();

        //DbParameter[] parametros = {
        //con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE),
        //con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
        //con.parametros("@CodTribunal", SqlDbType.Int, 2, CodTribunal) , 
        //con.parametros("@FechaOrden", SqlDbType.DateTime, 16, FechaOrden.ToShortDateString()) , 
        //con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion), 
        //con.parametros("@Expediente", SqlDbType.VarChar, 100, Expediente) , 
        //con.parametros("@Ruc", SqlDbType.VarChar, 100, Ruc) , 
        //con.parametros("@Rit", SqlDbType.VarChar, 100, Rit)
        //};
        //con.ejecutarProcedimiento("Insert_OrdenTribunalIngreso", parametros, out datareader);
        con.Autenticar();
        datareader = (SqlDataReader)con.TraerDataReader("Insert_OrdenTribunalIngreso", ICodIE, CodTribunal, FechaOrden, IdUsuarioActualizacion, Expediente, Ruc, Rit);


        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.CerrarConexion();
        return returnvalue;
    }

    public int Insert_OrdenTribunalIngresoTransaccional(SqlTransaction sqlt, int ICodIE, int CodTribunal, DateTime FechaOrden, int IdUsuarioActualizacion, String Expediente, String Ruc, String Rit)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_OrdenTribunalIngreso", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;


        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodIE", SqlDbType.Int, 4, ICodIE));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTribunal", SqlDbType.Int, 2, CodTribunal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaOrden", SqlDbType.DateTime, 16, FechaOrden.ToShortDateString()));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Expediente", SqlDbType.VarChar, 100, Expediente));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Ruc", SqlDbType.VarChar, 100, Ruc));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Rit", SqlDbType.VarChar, 100, Rit));

        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }

        datareader.Close();

        return returnvalue;
    }

    public int Insert_CausalesIngreso(
    int ICodIE, int CodCausalIngreso, int Prioridad, String CodEntidadAsigna,
    DateTime FechaActualizacion, int IdUsuarioActualizacion, int ICodTribunalIngreso)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@CodCausalIngreso", SqlDbType.Int, 4, CodCausalIngreso) , 
		con.parametros("@Prioridad", SqlDbType.Int, 1, Prioridad) , 
		con.parametros("@CodEntidadAsigna", SqlDbType.VarChar, 1, CodEntidadAsigna.Substring(0,1)) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 2, IdUsuarioActualizacion),
        con.parametros("@ICodTribunalIngreso", SqlDbType.Int, 4, ICodTribunalIngreso)
		};
        con.ejecutarProcedimiento("Insert_CausalesIngreso", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }


    public int Insert_CausalesIngresoTransaccional(SqlTransaction sqlt,
    int ICodIE, int CodCausalIngreso, int Prioridad, String CodEntidadAsigna,
    DateTime FechaActualizacion, int IdUsuarioActualizacion, int ICodTribunalIngreso)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_CausalesIngreso", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodIE", SqlDbType.Int, 4, ICodIE));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodCausalIngreso", SqlDbType.Int, 4, CodCausalIngreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Prioridad", SqlDbType.Int, 4, Prioridad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodEntidadAsigna", SqlDbType.VarChar, 4, CodEntidadAsigna.Substring(0, 1)));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodTribunalIngreso", SqlDbType.Int, 4, ICodTribunalIngreso));

        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }

        datareader.Close();
        return returnvalue;
    }


    public int Insert_DetalleLesiones(
    int ICodIE, int TipoLesiones, int CodQuienOcasionaLesion, String Observacion,
    DateTime FechaActualizacion, int IdUsuarioActualizacion, int InformoFiscalia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@TipoLesiones", SqlDbType.Int, 2, TipoLesiones) , 
		con.parametros("@CodQuienOcasionaLesion", SqlDbType.Int, 2, CodQuienOcasionaLesion) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 2, IdUsuarioActualizacion),
        con.parametros("@InformoFiscalia", SqlDbType.Int,2,InformoFiscalia)
		};
        con.ejecutarProcedimiento("Insert_DetalleLesiones", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_DetalleLesionesTransaccional(SqlTransaction sqlt,
    int ICodIE, int TipoLesiones, int CodQuienOcasionaLesion, String Observacion,
    DateTime FechaActualizacion, int IdUsuarioActualizacion, int InformoFiscalia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        SqlCommand sqlc = new SqlCommand("Insert_DetalleLesiones", sqlt.Connection);
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodIE", SqlDbType.Int, 4, ICodIE));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@TipoLesiones", SqlDbType.Int, 2, TipoLesiones));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodQuienOcasionaLesion", SqlDbType.Int, 2, CodQuienOcasionaLesion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Observacion", SqlDbType.VarChar, 100, Observacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioActualizacion", SqlDbType.Int, 2, IdUsuarioActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InformoFiscalia", SqlDbType.Int, 2, InformoFiscalia));

        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        return returnvalue;
    }

    public int CodInmueble(int codproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Consulta_InmuebleProyecto";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        if (dt.Rows.Count > 0)
        {
            return Convert.ToInt32(dt.Rows[0][0]); // SE DEBE VALIDAR QUE EXISTE INMUEBLE
        }
        else
        {
            return (-1);
        }
    }

    //public int CodInmueble( int CodProyecto)
    //{

    //    // Conexiones con = new Conexiones();
    //    //DbParameter[] parametros = {
    //    //con.parametros("@CodInstitucionIn", SqlDbType.Int, 4, CodInstitucion) , 
    //    //db.neooutprms("ReturnValue",SqlDbType.Int,4)};

    //    //con.ejecutarProcedimiento("sp_ObtieneCodigoInstitucion", parametros);
    //    //int Codigo = Convert.ToInt32(parametros[1].Value);
    //    //con.Desconectar();

    //    //return Codigo;


    //     Conexiones con = new Conexiones();
    //    DbParameter[] parametros = {
    //    con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto), 
    //    db.neooutprms("Returns",SqlDbType.Int,4)};

    //    con.ejecutarProcedimiento("Consulta_InmuebleProyecto", parametros);


    //    int Codigo = Convert.ToInt32(parametros[1].Value);
    //    con.Desconectar();
    //    return Codigo;     


    //}


    public int Insert_Ninos(
        DateTime FechaAdoptabilidad, bool IdentidadConfirmada, String Rut, String Sexo,
        String Nombres, String Apellido_Paterno, String Apellido_Materno, DateTime FechaNacimiento,
        int CodNacionalidad, int CodEtnia, String OficinaInscripcion, int AnoInscripcion,
        String NumeroInscripcionCivil, String AlergiasConocidas, bool InscritoFONADIS,
        bool InscritoFONASA/*, DateTime FechaDeclaracionSuceptibilidad*/, bool NinoSuceptibleAdopcion,
        /*int CodTribunalSusceptibilidad, String HuellaDigital,*/ String EstadoGestacion,
        /*DateTime FechaUltimaSituacionAbandono,*/ DateTime FechaActualizacion, int IdUsuarioActualizacion,
        int CodTipoNacionalidad)
    {

        Object ObjFechaNac = DBNull.Value;
        if (FechaNacimiento != Convert.ToDateTime("01-01-1900").Date)
        {
            ObjFechaNac = FechaNacimiento;
        };


        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@FechaAdoptabilidad", SqlDbType.DateTime, 16, FechaAdoptabilidad) , 
		con.parametros("@IdentidadConfirmada", SqlDbType.Int, 1, IdentidadConfirmada) , 
		con.parametros("@Rut", SqlDbType.VarChar, 11, Rut) , 
		con.parametros("@Sexo", SqlDbType.Char, 1, Sexo) , 
		con.parametros("@Nombres", SqlDbType.VarChar, 100, Nombres) , 
		con.parametros("@Apellido_Paterno", SqlDbType.VarChar, 50, Apellido_Paterno) , 
		con.parametros("@Apellido_Materno", SqlDbType.VarChar, 50, Apellido_Materno) , 
		con.parametros("@FechaNacimiento", SqlDbType.DateTime, 16, ObjFechaNac) , //viene vacia
		con.parametros("@CodNacionalidad", SqlDbType.Int, 4, CodNacionalidad) , 
		con.parametros("@CodEtnia", SqlDbType.Int, 4, CodEtnia) , 
		con.parametros("@OficinaInscripcion", SqlDbType.VarChar, 50, OficinaInscripcion) , 
		con.parametros("@AnoInscripcion", SqlDbType.Int, 4, AnoInscripcion) , 
		con.parametros("@NumeroInscripcionCivil", SqlDbType.VarChar, 20, NumeroInscripcionCivil) , 
		con.parametros("@AlergiasConocidas", SqlDbType.VarChar, 200, AlergiasConocidas) , 
		con.parametros("@InscritoFONADIS", SqlDbType.Int, 1, InscritoFONADIS) , 
		con.parametros("@InscritoFONASA", SqlDbType.Int, 1, InscritoFONASA) , 
		//con.parametros("@FechaDeclaracionSuceptibilidad", SqlDbType.DateTime, 16, FechaDeclaracionSuceptibilidad) , 
		con.parametros("@NinoSuceptibleAdopcion", SqlDbType.Int, 1, NinoSuceptibleAdopcion) , 
		//con.parametros("@CodTribunalSusceptibilidad", SqlDbType.Int, 4, CodTribunalSusceptibilidad) , 
		//con.parametros("@HuellaDigital", SqlDbType.VarChar, 255, HuellaDigital) , 
		con.parametros("@EstadoGestacion", SqlDbType.Char, 1, EstadoGestacion) , 
		//con.parametros("@FechaUltimaSituacionAbandono", SqlDbType.DateTime, 16, FechaUltimaSituacionAbandono) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) ,
        con.parametros("@CodTipoNacionalidad", SqlDbType.Int, 4, CodTipoNacionalidad) 
		};

        con.ejecutarProcedimiento("Insert_Ninos", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_NinosTransaccional(SqlTransaction sqlt,
        DateTime FechaAdoptabilidad, bool IdentidadConfirmada, String Rut, String Sexo,
        String Nombres, String Apellido_Paterno, String Apellido_Materno, DateTime FechaNacimiento,
        int CodNacionalidad, int CodEtnia, String OficinaInscripcion, int AnoInscripcion,
        String NumeroInscripcionCivil, String AlergiasConocidas, bool InscritoFONADIS,
        bool InscritoFONASA/*, DateTime FechaDeclaracionSuceptibilidad*/, bool NinoSuceptibleAdopcion,
        /*int CodTribunalSusceptibilidad, String HuellaDigital,*/ String EstadoGestacion,
        /*DateTime FechaUltimaSituacionAbandono,*/ DateTime FechaActualizacion, int IdUsuarioActualizacion,
        int CodTipoNacionalidad)
    {

        Object ObjFechaNac = DBNull.Value;
        if (FechaNacimiento != Convert.ToDateTime("01-01-1900").Date)
        {
            ObjFechaNac = FechaNacimiento;
        };


        int returnvalue = 0;
        DbDataReader datareader = null;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Ninos", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaAdoptabilidad", SqlDbType.DateTime, 16, FechaAdoptabilidad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdentidadConfirmada", SqlDbType.Int, 1, IdentidadConfirmada));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Rut", SqlDbType.VarChar, 11, Rut));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Sexo", SqlDbType.Char, 1, Sexo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Nombres", SqlDbType.VarChar, 100, Nombres));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Apellido_Paterno", SqlDbType.VarChar, 50, Apellido_Paterno));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Apellido_Materno", SqlDbType.VarChar, 50, Apellido_Materno));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaNacimiento", SqlDbType.DateTime, 16, ObjFechaNac)); //viene vacia
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodNacionalidad", SqlDbType.Int, 4, CodNacionalidad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodEtnia", SqlDbType.Int, 4, CodEtnia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@OficinaInscripcion", SqlDbType.VarChar, 50, OficinaInscripcion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@AnoInscripcion", SqlDbType.Int, 4, AnoInscripcion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@NumeroInscripcionCivil", SqlDbType.VarChar, 20, NumeroInscripcionCivil));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@AlergiasConocidas", SqlDbType.VarChar, 200, AlergiasConocidas));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InscritoFONADIS", SqlDbType.Int, 1, InscritoFONADIS));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InscritoFONASA", SqlDbType.Int, 1, InscritoFONASA));
        //con.parametros("@FechaDeclaracionSuceptibilidad", SqlDbType.DateTime, 16, FechaDeclaracionSuceptibilidad) , 
        sqlc.Parameters.Add(Conexiones.CrearParametro("@NinoSuceptibleAdopcion", SqlDbType.Int, 1, NinoSuceptibleAdopcion));
        //con.parametros("@CodTribunalSusceptibilidad", SqlDbType.Int, 4, CodTribunalSusceptibilidad) , 
        //con.parametros("@HuellaDigital", SqlDbType.VarChar, 255, HuellaDigital) , 
        sqlc.Parameters.Add(Conexiones.CrearParametro("@EstadoGestacion", SqlDbType.Char, 1, EstadoGestacion));
        //con.parametros("@FechaUltimaSituacionAbandono", SqlDbType.DateTime, 16, FechaUltimaSituacionAbandono) , 
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTipoNacionalidad", SqlDbType.Int, 4, CodTipoNacionalidad));


        datareader = sqlc.ExecuteReader();
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }

        datareader.Close();
        return returnvalue;
    }

    public DataTable callto_update_ninospersonasrelacionadas(int codpersonarelacionada, int icodie, int codnino, DateTime fecharelacion, int tiporelacion, int codescolaridadadulto, int codprofesion, int codnacionalidad, int codactividad, int codsituacion1, int codsituacion2, int codsituacion3, DateTime fechaactualizacion, int idusuarioactualizacion, int CodTipoNacionalidad)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_NinosPersonasRelacionadas";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaRelacion", SqlDbType.DateTime, 16).Value = fecharelacion;
        sqlc.Parameters.Add("@TipoRelacion", SqlDbType.Int, 4).Value = tiporelacion;
        sqlc.Parameters.Add("@CodEscolaridadAdulto", SqlDbType.Int, 4).Value = codescolaridadadulto;
        sqlc.Parameters.Add("@CodProfesion", SqlDbType.Int, 4).Value = codprofesion;
        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = codnacionalidad;
        sqlc.Parameters.Add("@CodActividad", SqlDbType.Int, 4).Value = codactividad;
        sqlc.Parameters.Add("@CodSituacion1", SqlDbType.Int, 4).Value = codsituacion1;
        sqlc.Parameters.Add("@CodSituacion2", SqlDbType.Int, 4).Value = codsituacion2;
        sqlc.Parameters.Add("@CodSituacion3", SqlDbType.Int, 4).Value = codsituacion3;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodTipoNacionalidad", SqlDbType.Int, 4).Value = CodTipoNacionalidad;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public int Insert_SOLICITANTE_UNICO(
    int codtipousuario,
    string rut,
    string nombres,
    string apellido_materno,
    string apellido_paterno,
    string sexo,

    int codnacionalidad,
    DateTime fechaactualizacion,
    int usuarioactualizacion)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_ninos_PAG";

        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 50).Value = sexo;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 50).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 50).Value = apellido_materno;
        sqlc.Parameters.Add("@CodTipoUsuario", SqlDbType.Int, 4).Value = codtipousuario;

        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = codnacionalidad;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = usuarioactualizacion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int Insert_SOLICITANTE_UNICOTRANSACCIONAL(SqlTransaction sqlt,
    int codtipousuario,
    string rut,
    string nombres,
    string apellido_materno,
    string apellido_paterno,
    string sexo,

    int codnacionalidad,
    DateTime fechaactualizacion,
    int usuarioactualizacion)
    {

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_ninos_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 50).Value = sexo;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 50).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 50).Value = apellido_materno;
        sqlc.Parameters.Add("@CodTipoUsuario", SqlDbType.Int, 4).Value = codtipousuario;

        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = codnacionalidad;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = usuarioactualizacion;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int Insert_PersonaRelacionada_PAGTransaccional(SqlTransaction sqlt,

    string rut,
    string nombres,
    string apellido_materno,
    string apellido_paterno,
    string sexo,
    DateTime fechanacimiento,
    int codcomuna,
    DateTime fechaactualizacion,
    int IdUsuarioActualizacion,
    int per_rel
    )
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_PersonasRelacionadas_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 50).Value = sexo;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 50).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 50).Value = apellido_materno;

        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = fechanacimiento;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodTipoUsuario", SqlDbType.Int, 4).Value = per_rel;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return Convert.ToInt32(dt.Rows[0][0]);
    }


    public int Insert_PersonaRelacionada_PAG(

    string rut,
    string nombres,
    string apellido_materno,
    string apellido_paterno,
    string sexo,
    DateTime fechanacimiento,
    int codcomuna,
    DateTime fechaactualizacion,
    int IdUsuarioActualizacion,
    int per_rel
    )
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_PersonasRelacionadas_PAG";

        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 50).Value = sexo;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 50).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 50).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 50).Value = apellido_materno;

        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = fechanacimiento;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodTipoUsuario", SqlDbType.Int, 4).Value = per_rel;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int Insert_Ingreso_Egreso_PAGTransaccional(SqlTransaction sqlt,

    int codproy,
    int codnino,
    DateTime fechaingreso,
    int cond_ins_inmu,
    int cod_inmu,
    int cod_inst_entre,
    int cod_trab_entre,
    int cod_inst_revisa,
    int cod_traba_revisa,
    DateTime fechaactualizacion,
    int IdUsuarioActualizacion,
    int CodModeloIntervencion

   )
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Ingresos_Egresos_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproy;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = fechaingreso;
        sqlc.Parameters.Add("@CodInstitucionInmueble", SqlDbType.Int, 4).Value = cond_ins_inmu;
        sqlc.Parameters.Add("@ICodInmueble", SqlDbType.Int, 4).Value = cod_inmu;
        sqlc.Parameters.Add("@CodInstitucion_Entrevistador", SqlDbType.Int, 4).Value = cod_inst_entre;
        sqlc.Parameters.Add("@CodTrabajador_Entrevistador", SqlDbType.Int, 4).Value = cod_trab_entre;

        sqlc.Parameters.Add("@CodInstitucion_Revisador", SqlDbType.Int, 4).Value = cod_inst_revisa;
        sqlc.Parameters.Add("@CodTrabajador_Revisador", SqlDbType.Int, 4).Value = cod_traba_revisa;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int Insert_Ingreso_Egreso_PAG(

    int codproy,
    int codnino,
    DateTime fechaingreso,
    int cond_ins_inmu,
    int cod_inmu,
    int cod_inst_entre,
    int cod_trab_entre,
    int cod_inst_revisa,
    int cod_traba_revisa,
    DateTime fechaactualizacion,
    int IdUsuarioActualizacion,
    int CodModeloIntervencion

   )
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_Ingresos_Egresos_PAG";

        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproy;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = fechaingreso;
        sqlc.Parameters.Add("@CodInstitucionInmueble", SqlDbType.Int, 4).Value = cond_ins_inmu;
        sqlc.Parameters.Add("@ICodInmueble", SqlDbType.Int, 4).Value = cod_inmu;
        sqlc.Parameters.Add("@CodInstitucion_Entrevistador", SqlDbType.Int, 4).Value = cod_inst_entre;
        sqlc.Parameters.Add("@CodTrabajador_Entrevistador", SqlDbType.Int, 4).Value = cod_trab_entre;

        sqlc.Parameters.Add("@CodInstitucion_Revisador", SqlDbType.Int, 4).Value = cod_inst_revisa;
        sqlc.Parameters.Add("@CodTrabajador_Revisador", SqlDbType.Int, 4).Value = cod_traba_revisa;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;



        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int Insert_Plan_intervencion_PAG(
        int IcodIE,
        int CodProyecto,
        int codnino,
        DateTime fechaingreso,
        int codinstitucion,
        int icodtrabajador,
        int codtrabajador,
        DateTime fechaactualizacion,
        int IdUsuarioActualizacion,
        int CodModeloIntervencion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_PlanIntervencion_PAG";

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = IcodIE;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = fechaingreso;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int Insert_Plan_intervencion_PAGTransaccional(SqlTransaction sqlt,
        int IcodIE,
        int CodProyecto,
        int codnino,
        DateTime fechaingreso,
        int codinstitucion,
        int icodtrabajador,
        int codtrabajador,
        DateTime fechaactualizacion,
        int IdUsuarioActualizacion,
        int CodModeloIntervencion)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_PlanIntervencion_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        //sqlc.CommandText = "Insert_PlanIntervencion_PAG";

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = IcodIE;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = fechaingreso;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }


    public DataTable Insert_Intervenciones_PAG(
        int CodPlanIntervencion,
        int TipoIntervencion,
        DateTime FechaCreacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_Intervenciones_PAG";

        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@TipoIntervencion", SqlDbType.Int, 4).Value = TipoIntervencion;
        sqlc.Parameters.Add("@FechaCreacion", SqlDbType.DateTime, 16).Value = FechaCreacion;



        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable Insert_Intervenciones_PAGTransaccional(SqlTransaction sqlt,
        int CodPlanIntervencion,
        int TipoIntervencion,
        DateTime FechaCreacion)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Insert_Intervenciones_PAG";

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Intervenciones_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@TipoIntervencion", SqlDbType.Int, 4).Value = TipoIntervencion;
        sqlc.Parameters.Add("@FechaCreacion", SqlDbType.DateTime, 16).Value = FechaCreacion;



        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return dt;
    }


    public DataTable Insert_Estados_Intervenciones_PAG(
    int CodPlanIntervencion,
    DateTime FechaCreacion
    )
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_EstadosPlanIntervencion_PAG";

        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;

        sqlc.Parameters.Add("@FechaCreacion", SqlDbType.DateTime, 16).Value = FechaCreacion;



        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Insert_Estados_Intervenciones_PAGTransaccional(SqlTransaction sqlt,
       int CodPlanIntervencion,
       DateTime FechaCreacion
        )
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Insert_EstadosPlanIntervencion_PAG";

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_EstadosPlanIntervencion_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@FechaCreacion", SqlDbType.DateTime, 16).Value = FechaCreacion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return dt;
    }

    public DataTable Insert_Cierre_ingreso_PAGTransaccional(SqlTransaction sqlt,


        int ICodIE,
        int CodProyecto,
        DateTime FechaIngreso,
        int codnino,
        string sexo,
        int IdUsuarioActualizacion
   )
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("dbo.cierre_Ingreso", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;


        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = FechaIngreso;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@Sexo", SqlDbType.NVarChar, 50).Value = sexo;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Insert_Cierre_ingreso_PAG(


        int ICodIE,
        int CodProyecto,
        DateTime FechaIngreso,
        int codnino,
        string sexo,
        int IdUsuarioActualizacion
   )
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "dbo.cierre_Ingreso";

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;


        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = FechaIngreso;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@Sexo", SqlDbType.NVarChar, 50).Value = sexo;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable Insert_ninos_personas_relacionadas_PAG(

  int cod_per_rel,
  int IcodIE,
  int codnino,
  int cod_nac,
  DateTime fechaactualizacion,
  int IdUsuarioActualizacion,
  DateTime fechaingreso,
  int cod_tipo_nac
  )
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_NinosPersonasRelacionadas_PAG";

        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = cod_per_rel;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = IcodIE;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = cod_nac;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@FechaRelacion", SqlDbType.DateTime, 16).Value = fechaingreso;
        sqlc.Parameters.Add("@CodTipoNacionalidad", SqlDbType.Int, 4).Value = cod_tipo_nac;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Insert_ninos_personas_relacionadas_PAGTransaccional(SqlTransaction sqlt,

 int cod_per_rel,
 int IcodIE,
 int codnino,
 int cod_nac,
 DateTime fechaactualizacion,
 int IdUsuarioActualizacion,
 DateTime fechaingreso,
 int cod_tipo_nac
 )
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_NinosPersonasRelacionadas_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = cod_per_rel;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = IcodIE;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = cod_nac;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@FechaRelacion", SqlDbType.DateTime, 16).Value = fechaingreso;
        sqlc.Parameters.Add("@CodTipoNacionalidad", SqlDbType.Int, 4).Value = cod_tipo_nac;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }


    public DataTable Insert_Causal_Ingreso_PAGTransaccional(SqlTransaction sqlt,

    int ICodIE,
    DateTime fechaactualizacion,
    int IdUsuarioActualizacion,
    int CodModeloIntervencion
    )
    {

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_CausalesIngreso_PAG", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable Insert_Causal_Ingreso_PAG(

    int ICodIE,
    DateTime fechaactualizacion,
    int IdUsuarioActualizacion,
    int CodModeloIntervencion
    )
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CausalesIngreso_PAG";

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    //public int Insert_SOLICITANTE_UNICO(
    //int codtipousuario,
    //int rut, 
    //string nombres,
    //string apellido_materno,
    //string apellido_paterno,
    //string sexo, 
    //DateTime fechanacimiento,
    //int codnacionalidad,    
    //DateTime fechaactualizacion,
    //int usuarioactualizacion,

    //     )
    //{
    //    int returnvalue = 0;
    //    DbDataReader datareader = null;
    //     Conexiones con = new Conexiones();
    //    DbParameter[] parametros = {
    //    con.parametros("@codtipousuario", SqlDbType.Int, 4, codtipousuario) , 
    //    con.parametros("@rut", SqlDbType.Int, 11, rut) , 
    //    con.parametros("@nombres", SqlDbType.VarChar,50, nombres) , 
    //    con.parametros("@apellido_paterno", SqlDbType.VarChar, 50, apellido_paterno) , 
    //    con.parametros("@apellido_materno", SqlDbType.VarChar, 50, apellido_materno) , 
    //    con.parametros("@sexo", SqlDbType.VarChar, 50, sexo) , 
    //    con.parametros("@fechanacimiento", SqlDbType.DateTime,16, fechanacimiento),
    //    con.parametros("@codnacionalidad", SqlDbType.Int, 4, codnacionalidad),
    //    con.parametros("@idusuarioactualizacion", SqlDbType.Int, 4, usuarioactualizacion) , 
    //    con.parametros("@fechaactualizacion", SqlDbType.DateTime,16, fechaactualizacion)
    //    };
    //    con.ejecutarProcedimiento("Insert_ninos_PAG", parametros, out datareader);

    //    con.Desconectar();
    //    return returnvalue;
    //}

















    public DataTable callto_update_personasrelacionadas_2f(int codpersonarelacionada, string rut, string nombres, string apellido_paterno, string apellido_materno, string sexo, DateTime fechanacimiento, DateTime fechaactualizacion, int idusuarioactualizacion, int codpersonarelacionada2, int codcomuna, string direccion, string telefono)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_PersonasRelacionadas_2f";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 30).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 30).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 30).Value = apellido_materno;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = sexo;
        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = fechanacimiento;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodPersonaRelacionada2", SqlDbType.Int, 4).Value = codpersonarelacionada2;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        sqlc.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = direccion;
        sqlc.Parameters.Add("@Telefono", SqlDbType.VarChar, 30).Value = telefono;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }




    public DataTable callto_update_personasrelacionadas(int codpersonarelacionada, string rut, string nombres, string apellido_paterno, string apellido_materno, string sexo, DateTime fechanacimiento, DateTime fechaactualizacion, int idusuarioactualizacion, int codpersonarelacionada2)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_PersonasRelacionadas";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 1).Value = rut;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 1).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 1).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 1).Value = apellido_materno;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = sexo;
        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = fechanacimiento;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodPersonaRelacionada2", SqlDbType.Int, 4).Value = codpersonarelacionada2;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_insert_personasrelacionadas_2f(string rut, string nombres, string apellido_paterno, string apellido_materno, string sexo, DateTime fechanacimiento, DateTime fechaactualizacion, int idusuarioactualizacion, int codpersonarelacionada2, int codcomuna, string direccion, string telefono)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_PersonasRelacionadas_2f";
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 30).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 30).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 30).Value = apellido_materno;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = sexo;
        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = fechanacimiento;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodPersonaRelacionada2", SqlDbType.Int, 4).Value = codpersonarelacionada2;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        sqlc.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = direccion;
        sqlc.Parameters.Add("@Telefono", SqlDbType.VarChar, 30).Value = telefono;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_insert_personasrelacionadas_2fTransaccional(SqlTransaction sqlt, string rut, string nombres, string apellido_paterno, string apellido_materno, string sexo, DateTime fechanacimiento, DateTime fechaactualizacion, int idusuarioactualizacion, int codpersonarelacionada2, int codcomuna, string direccion, string telefono)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Insert_PersonasRelacionadas_2f";

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_PersonasRelacionadas_2f", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = rut;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 30).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 30).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 30).Value = apellido_materno;
        sqlc.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = sexo;
        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = fechanacimiento;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodPersonaRelacionada2", SqlDbType.Int, 4).Value = codpersonarelacionada2;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        sqlc.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = direccion;
        sqlc.Parameters.Add("@Telefono", SqlDbType.VarChar, 30).Value = telefono;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return dt;
    }

    public DataTable callto_insert_ninospersonasrelacionadas(int codpersonarelacionada, int icodie, int codnino, DateTime fecharelacion, int tiporelacion, int codescolaridadadulto, int codprofesion, int codnacionalidad, int codactividad, int codsituacion1, int codsituacion2, int codsituacion3, DateTime fechaactualizacion, int idusuarioactualizacion, int CodTipoNacionalidad)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_NinosPersonasRelacionadas";
        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaRelacion", SqlDbType.DateTime, 16).Value = fecharelacion;
        sqlc.Parameters.Add("@TipoRelacion", SqlDbType.Int, 4).Value = tiporelacion;
        sqlc.Parameters.Add("@CodEscolaridadAdulto", SqlDbType.Int, 4).Value = codescolaridadadulto;
        sqlc.Parameters.Add("@CodProfesion", SqlDbType.Int, 4).Value = codprofesion;
        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = codnacionalidad;
        sqlc.Parameters.Add("@CodActividad", SqlDbType.Int, 4).Value = codactividad;
        sqlc.Parameters.Add("@CodSituacion1", SqlDbType.Int, 4).Value = codsituacion1;
        sqlc.Parameters.Add("@CodSituacion2", SqlDbType.Int, 4).Value = codsituacion2;
        sqlc.Parameters.Add("@CodSituacion3", SqlDbType.Int, 4).Value = codsituacion3;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodTipoNacionalidad", SqlDbType.Int, 4).Value = CodTipoNacionalidad;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_insert_ninospersonasrelacionadasTransaccional(SqlTransaction sqlt, int codpersonarelacionada, int icodie, int codnino, DateTime fecharelacion, int tiporelacion, int codescolaridadadulto, int codprofesion, int codnacionalidad, int codactividad, int codsituacion1, int codsituacion2, int codsituacion3, DateTime fechaactualizacion, int idusuarioactualizacion)
    {

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_NinosPersonasRelacionadas", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Insert_NinosPersonasRelacionadas";

        sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int, 4).Value = codpersonarelacionada;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaRelacion", SqlDbType.DateTime, 16).Value = fecharelacion;
        sqlc.Parameters.Add("@TipoRelacion", SqlDbType.Int, 4).Value = tiporelacion;
        sqlc.Parameters.Add("@CodEscolaridadAdulto", SqlDbType.Int, 4).Value = codescolaridadadulto;
        sqlc.Parameters.Add("@CodProfesion", SqlDbType.Int, 4).Value = codprofesion;
        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = codnacionalidad;
        sqlc.Parameters.Add("@CodActividad", SqlDbType.Int, 4).Value = codactividad;
        sqlc.Parameters.Add("@CodSituacion1", SqlDbType.Int, 4).Value = codsituacion1;
        sqlc.Parameters.Add("@CodSituacion2", SqlDbType.Int, 4).Value = codsituacion2;
        sqlc.Parameters.Add("@CodSituacion3", SqlDbType.Int, 4).Value = codsituacion3;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return dt;
    }



    public int Insert_PersonasRelacionadas(
   String Rut, String Nombres, String Apellido_Paterno, String Apellido_Materno, String Sexo, DateTime FechaNacimiento, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@Rut", SqlDbType.VarChar, 11, Rut) , 
		con.parametros("@Nombres", SqlDbType.VarChar, 30, Nombres) , 
		con.parametros("@Apellido_Paterno", SqlDbType.VarChar, 30, Apellido_Paterno) , 
		con.parametros("@Apellido_Materno", SqlDbType.VarChar, 30, Apellido_Materno) , 
		con.parametros("@Sexo", SqlDbType.Char, 1, Sexo) , 
		con.parametros("@FechaNacimiento", SqlDbType.DateTime, 16, FechaNacimiento) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_PersonasRelacionadas", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }
    //Felipe Ormazabal


    public void Update_DiagnosticoGeneral(
        /*int CodDiagnostico,*/ int CodTipoDiagnosticoGlosa, DateTime FechaDiagnostico, int CodNino, int ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		//con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodTipoDiagnosticoGlosa", SqlDbType.Int, 4, CodTipoDiagnosticoGlosa) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) 
		};
        con.ejecutarProcedimiento("Update_DiagnosticoGeneral", parametros, out datareader);
        con.Desconectar();

    }

    public void Update_DiagnosticosMaltrato(
        int ICodMaltrato,
        int CodDiagnostico,
        DateTime FechaDiagnostico,
        bool PresentaMaltrato,
        int CodMaltrato, bool ConoceMaltratador,
        int CodPersonaRelacionada,
        bool ViveConAgresor,
        bool ExisteQuerellaSENAME,
        int ICodTrabajador,
        int CodInstitucion,
        int CodTrabajador,
        String Observacion,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodMaltrato", SqlDbType.Int, 4, ICodMaltrato) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@PresentaMaltrato", SqlDbType.Int, 1, PresentaMaltrato) , 
		con.parametros("@CodMaltrato", SqlDbType.Int, 4, CodMaltrato) , 
		con.parametros("@ConoceMaltratador", SqlDbType.Int, 1, ConoceMaltratador) , 
		con.parametros("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada) , 
		con.parametros("@ViveConAgresor", SqlDbType.Int, 1, ViveConAgresor) , 
		con.parametros("@ExisteQuerellaSENAME", SqlDbType.Int, 1, ExisteQuerellaSENAME) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_DiagnosticosMaltrato", parametros, out datareader);
        con.Desconectar();

    }




    public void Update_DiagnosticosEscolar(
        int ICodEscolar,
        int CodDiagnostico,
        DateTime FechaCreacion,
        int CodEscolaridad,
        DateTime FechaDiagnostico,
        int ICodTrabajador,
        int CodInstitucion_Entrevistador,
        int CodTrabajador_Entrevistador,
        int TipoAsistenciaEscolar,
        int AnoUltimoCursoAprobado,
        String Observaciones,
        int AlIngreso,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@ICodEscolar", SqlDbType.Int, 4, ICodEscolar) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion) , 
		con.parametros("@CodEscolaridad", SqlDbType.Int, 4, CodEscolaridad) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion_Entrevistador", SqlDbType.Int, 4, CodInstitucion_Entrevistador) , 
		con.parametros("@CodTrabajador_Entrevistador", SqlDbType.Int, 4, CodTrabajador_Entrevistador) , 
		con.parametros("@TipoAsistenciaEscolar", SqlDbType.Int, 4, TipoAsistenciaEscolar) , 
		con.parametros("@AnoUltimoCursoAprobado", SqlDbType.Int, 4, AnoUltimoCursoAprobado) , 
		con.parametros("@Observaciones", SqlDbType.VarChar, 200, Observaciones) , 
		con.parametros("@AlIngreso", SqlDbType.Int, 1, AlIngreso) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_DiagnosticosEscolar", parametros, out datareader);
        con.Desconectar();
    }

    public int Insert_DiagnosticoGeneralTransaccional(SqlTransaction sqlt, int CodTipoDiagnosticoGlosa, int CodNino, int ICodIE, DateTime FechaDiagnostico)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_DiagnosticoGeneral", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTipoDiagnosticoGlosa", SqlDbType.Int, 4, CodTipoDiagnosticoGlosa));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodNino", SqlDbType.Int, 4, CodNino));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodIE", SqlDbType.Int, 4, ICodIE));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }

        datareader.Close();
        return returnvalue;
    }

    public int Insert_DiagnosticoGeneral(
        int CodTipoDiagnostico, int CodNino, int ICodIE, DateTime FechaDiagnostico)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodTipoDiagnostico", SqlDbType.Int, 4, CodTipoDiagnostico) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico),
       
		};
        con.ejecutarProcedimiento("Insert_DiagnosticoGeneral", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }


    // Metodo Felipe Ormazabal Cierres_Ingreso 11/07/2006

    public void Cierre_ingreso(int ICodIE, int codproyecto, DateTime FechaIngreso,
        int codnino, string sexo, int IdusuarioActualizacion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE),
        con.parametros("@codproyecto", SqlDbType.Int, 4, codproyecto),
        con.parametros("@FechaIngreso", SqlDbType.DateTime, 16, FechaIngreso),
        con.parametros("@codnino", SqlDbType.Int, 4, codnino),
        con.parametros("@sexo", SqlDbType.VarChar, 1, sexo),
        con.parametros("@IdusuarioActualizacion", SqlDbType.Int, 4, IdusuarioActualizacion)};

        con.ejecutarProcedimiento("cierre_Ingreso", parametros, out datareader);

        con.Desconectar();
    }



    public void Cierre_ingresoTransaccional(SqlTransaction sqlt, int ICodIE, int codproyecto, DateTime FechaIngreso,
        int codnino, string sexo, int IdusuarioActualizacion)
    {

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("cierre_Ingreso", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@FechaIngreso", SqlDbType.DateTime, 16).Value = FechaIngreso;
        sqlc.Parameters.Add("@codnino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = sexo;
        sqlc.Parameters.Add("@IdusuarioActualizacion", SqlDbType.Int, 4).Value = IdusuarioActualizacion;

        sqlc.ExecuteNonQuery();



    }

    public int Insert_DireccionNinos(
    int ICodIE,
        int CodProyecto,
        int CodNino,
        DateTime FechaIngresoDireccion,
        String Direccion,
        String Telefono,
        String TelefonoRecado,
        String Mail,
        String Fax,
        int CodigoPostal,
        int CodComuna,
        bool AlIngreso,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion,
        String IndVigencia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@FechaIngresoDireccion", SqlDbType.DateTime, 16, FechaIngresoDireccion) , 
		con.parametros("@Direccion", SqlDbType.VarChar, 100, Direccion) , 
		con.parametros("@Telefono", SqlDbType.VarChar, 30, Telefono) , 
		con.parametros("@TelefonoRecado", SqlDbType.VarChar, 30, TelefonoRecado) , 
		con.parametros("@Mail", SqlDbType.VarChar, 30, Mail) , 
		con.parametros("@Fax", SqlDbType.VarChar, 30, Fax) , 
		con.parametros("@CodigoPostal", SqlDbType.Int, 4, CodigoPostal) , 
		con.parametros("@CodComuna", SqlDbType.Int, 4, CodComuna) , 
		con.parametros("@AlIngreso", SqlDbType.Int, 1, AlIngreso) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) 
		};
        con.ejecutarProcedimiento("Insert_DireccionNinos", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_DireccionNinosTransaccional(SqlTransaction sqlt,
    int ICodIE,
        int CodProyecto,
        int CodNino,
        DateTime FechaIngresoDireccion,
        String Direccion,
        String Telefono,
        String TelefonoRecado,
        String Mail,
        String Fax,
        int CodigoPostal,
        int CodComuna,
        bool AlIngreso,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion,
        String IndVigencia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_DireccionNinos", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@FechaIngresoDireccion", SqlDbType.DateTime, 16).Value = FechaIngresoDireccion;
        sqlc.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = Direccion;
        sqlc.Parameters.Add("@Telefono", SqlDbType.VarChar, 10).Value = Telefono;
        sqlc.Parameters.Add("@TelefonoRecado", SqlDbType.VarChar, 30).Value = TelefonoRecado;
        sqlc.Parameters.Add("@Mail", SqlDbType.VarChar, 30).Value = Mail;
        sqlc.Parameters.Add("@Fax", SqlDbType.VarChar, 30).Value = Fax;
        sqlc.Parameters.Add("@CodigoPostal", SqlDbType.Int, 4).Value = CodigoPostal;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = CodComuna;
        sqlc.Parameters.Add("@AlIngreso", SqlDbType.Int, 4).Value = AlIngreso;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = FechaActualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = IndVigencia;

        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        //con.Desconectar();
        datareader.Close();
        return returnvalue;
    }

    public DataTable callto_historico_ingresos(int codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "historico_ingresos";
        sqlc.Parameters.Add("@codnino", SqlDbType.Int, 4).Value = codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetDireccionNinos(int IcodIe)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetDireccionNinos + IcodIe + " Order by t1.FechaIngresoDireccion DESC", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaIngresoDireccion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Direccion", typeof(String)));
        dt.Columns.Add(new DataColumn("Telefono", typeof(String)));
        dt.Columns.Add(new DataColumn("TelefonoRecado", typeof(String)));
        dt.Columns.Add(new DataColumn("Mail", typeof(String)));
        dt.Columns.Add(new DataColumn("Fax", typeof(String)));
        dt.Columns.Add(new DataColumn("CodigoPostal", typeof(int)));
        dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        dt.Columns.Add(new DataColumn("AlIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("ICodDireccion", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodIE"];
                dr[1] = (int)datareader["CodProyecto"];
                dr[2] = (int)datareader["CodNino"];
                dr[3] = (DateTime)datareader["FechaIngresoDireccion"];
                dr[4] = (String)datareader["Direccion"];
                dr[5] = (String)datareader["Telefono"];
                dr[6] = (String)datareader["TelefonoRecado"];
                dr[7] = (String)datareader["Mail"];
                dr[8] = (String)datareader["Fax"];
                dr[9] = (int)datareader["CodigoPostal"];
                dr[10] = (int)datareader["CodComuna"];
                dr[11] = (int)datareader["AlIngreso"];
                dr[12] = (DateTime)datareader["FechaActualizacion"];
                dr[13] = (int)datareader["IdUsuarioActualizacion"];
                dr[14] = (String)datareader["IndVigencia"];
                dr[15] = (String)datareader["Descripcion"];
                dr[16] = (int)datareader["ICodDireccion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



    public DataTable trae_datos_inmueble(int codproy, int codtipo)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "select T2.CODINSTITUCION, t1.ICodInmueble from ProyectoInmueble T1 INNER JOIN INMUEBLE T2 ON T1.ICodInmueble = T2.ICodInmueble where T1.codproyecto = '" + codproy + "' AND T2.TIPOINMUEBLE = '" + codtipo + "'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodInmueble", typeof(int)));


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstitucion"];
                dr[1] = (int)datareader["ICodInmueble"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public int trae_inst_entrevistador(int codtrabajador)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "SELECT CodInstitucion FROM Trabajadores WHERE ICodTrabajador ='" + codtrabajador + "'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstitucion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return Convert.ToInt32(dt.Rows[0][0]);
    }


    public DataTable update_direccionninos(int icoddireccion, int icodie, DateTime fechaingresodireccion, string direccion, string telefono, string telefonorecado, string mail, string fax, int codigopostal, int codcomuna)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_DireccionNinos";
        sqlc.Parameters.Add("@ICodDireccion", SqlDbType.Int, 4).Value = icoddireccion;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@FechaIngresoDireccion", SqlDbType.DateTime, 16).Value = fechaingresodireccion;
        sqlc.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = direccion;
        sqlc.Parameters.Add("@Telefono", SqlDbType.VarChar, 30).Value = telefono;
        sqlc.Parameters.Add("@TelefonoRecado", SqlDbType.VarChar, 30).Value = telefonorecado;
        sqlc.Parameters.Add("@Mail", SqlDbType.VarChar, 30).Value = mail;
        sqlc.Parameters.Add("@Fax", SqlDbType.VarChar, 30).Value = fax;
        sqlc.Parameters.Add("@CodigoPostal", SqlDbType.Int, 4).Value = codigopostal;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }

    public DataTable GetNinosVisitados(DateTime FechaRegistro, int CodProyecto)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "Select T1.CodProyecto, T1.CodNino, T1.FechaRegistro, T1.IdUsuarioActualizacion, T1.PadreMadreTutor, " +
                    "T1.Otro, T1.FechaActualizacion,T1.Padre,T1.OtroMasculino,T2.Nombres, T2.Apellido_paterno, T2.Apellido_Materno " +
                    "From NinosVisitados T1 INNER Join Ninos T2 ON T1.CodNino = T2.CodNino " +
                    "Where T1.FechaRegistro ='" + FechaRegistro + "' and T1.CodProyecto = " + CodProyecto + " order by T2.Apellido_paterno, T2.Apellido_Materno, T2.Nombres ";

        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaRegistro", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("PadreMadreTutor", typeof(bool)));
        dt.Columns.Add(new DataColumn("Otro", typeof(bool)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Padre", typeof(bool)));
        dt.Columns.Add(new DataColumn("OtroMasculino", typeof(bool)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodProyecto"];
                dr[1] = (int)datareader["CodNino"];
                dr[2] = (DateTime)datareader["FechaRegistro"];
                dr[3] = (int)datareader["IdUsuarioActualizacion"];
                dr[4] = (bool)datareader["PadreMadreTutor"];
                dr[5] = (bool)datareader["Otro"];
                dr[6] = (DateTime)datareader["FechaActualizacion"];
                dr[7] = (String)datareader["Nombres"];
                dr[8] = (String)datareader["Apellido_paterno"];
                dr[9] = (String)datareader["Apellido_Materno"];
                dr[10] = (bool)datareader["Padre"];
                dr[11] = (bool)datareader["OtroMasculino"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetNinosVisitados_Verifica(DateTime FechaRegistro, int CodProyecto, int codnino)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "Select T1.CodProyecto, T1.CodNino, T1.FechaRegistro, T1.IdUsuarioActualizacion, T1.PadreMadreTutor, " +
                    "T1.Otro, T1.FechaActualizacion, T1.Padre,T1.OtroMasculino " +
                    "From NinosVisitados T1 " +
                    "Where T1.FechaRegistro ='" + FechaRegistro + "' and T1.CodProyecto = " + CodProyecto +
                    " and CodNino = " + codnino;

        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaRegistro", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("PadreMadreTutor", typeof(bool)));
        dt.Columns.Add(new DataColumn("Otro", typeof(bool)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Padre", typeof(bool)));
        dt.Columns.Add(new DataColumn("OtroMasculino", typeof(bool)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodProyecto"];
                dr[1] = (int)datareader["CodNino"];
                dr[2] = (DateTime)datareader["FechaRegistro"];
                dr[3] = (int)datareader["IdUsuarioActualizacion"];
                dr[4] = (bool)datareader["PadreMadreTutor"];
                dr[5] = (bool)datareader["Otro"];
                dr[6] = (DateTime)datareader["FechaActualizacion"];
                dr[7] = (bool)datareader["Padre"];
                dr[8] = (bool)datareader["OtroMasculino"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    //////////////MODIFICACION A MEDIDA O SANCION 


    /////////////


    public void Update_NinosVisitados(
    int CodProyecto, int CodNino, DateTime FechaRegistro, int IdUsuarioActualizacion, bool PadreMadreTutor, bool Otro, DateTime FechaActualizacion, bool Padre, bool OtroMasculino)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@FechaRegistro", SqlDbType.DateTime, 16, FechaRegistro) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@PadreMadreTutor", SqlDbType.Int, 1, PadreMadreTutor) , 
		con.parametros("@Otro", SqlDbType.Int, 1, Otro) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion),
        con.parametros("@Padre", SqlDbType.Int, 1, Padre) , 
		con.parametros("@OtroMasculino", SqlDbType.Int, 1, OtroMasculino)
		};
        con.ejecutarProcedimiento("Update_NinosVisitados", parametros, out datareader);
        con.Desconectar();

    }


    public int Insert_NinosVisitados(
    int CodProyecto, int CodNino, DateTime FechaRegistro, int IdUsuarioActualizacion, bool PadreMadreTutor, bool Otro, DateTime FechaActualizacion,
         bool Padre, bool OtroMasculino)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@FechaRegistro", SqlDbType.DateTime, 16, FechaRegistro) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@PadreMadreTutor", SqlDbType.Int, 1, PadreMadreTutor) , 
		con.parametros("@Otro", SqlDbType.Int, 1, Otro) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion),
         con.parametros("@Padre", SqlDbType.Int, 1, Padre) , 
		con.parametros("@OtroMasculino", SqlDbType.Int, 1, OtroMasculino)
		};
        con.ejecutarProcedimiento("Insert_NinosVisitados", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }
    public int GetNinosVisitados_VerifCierre(DateTime FechaRegistro, int CodProyecto)
    {
        int cuenta = 0;
        string mes = "";
        if (Convert.ToString(FechaRegistro.Month).Length == 1)
        {
            mes = "0" + Convert.ToString(FechaRegistro.Month);
        }
        else
        {
            mes = Convert.ToString(FechaRegistro.Month);
        }

        string AnoMes = Convert.ToString(FechaRegistro.Year) + mes;
        int AnoMesF = Convert.ToInt32(AnoMes);

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "Select count(*)as cuenta From CierreMovimientoMensual " +
                     "where codProyecto=" + CodProyecto + " and AnoMes=" + AnoMesF;

        con.ejecutar(sql, out datareader);
        while (datareader.Read())
        {
            try
            {
                cuenta = (int)datareader["cuenta"];
            }
            catch { }
        }
        con.Desconectar();
        return cuenta;
    }
    public DataTable delete_ninosvisitados(int codproyecto, int codnino, DateTime fecharegistro)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Delete_NinosVisitados";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaRegistro", SqlDbType.DateTime, 16).Value = fecharegistro;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Get_NinosxNombres(string Apellido_Paterno, string Apellido_Materno, string Nombres)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sParametrosConsulta = "select CodNino,FechaAdoptabilidad, IdentidadConfirmada, Rut, Sexo, Nombres, " +
        "Apellido_Paterno, Apellido_Materno, FechaNacimiento, CodNacionalidad, CodEtnia, " +
        "OficinaInscripcion, AnoInscripcion, NumeroInscripcionCivil, AlergiasConocidas, " +
        "InscritoFONADIS, InscritoFONASA, NinoSuceptibleAdopcion, EstadoGestacion, FechaActualizacion, " +
        "IdUsuarioActualizacion From Ninos ";

        if (Apellido_Materno != "" || Apellido_Paterno != "" || Nombres != "")
        {
            sParametrosConsulta = sParametrosConsulta + " Where";
        }
        if (Apellido_Paterno != "")
        {
            sParametrosConsulta = sParametrosConsulta + " Apellido_Paterno like @pApellido_Paterno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, Apellido_Paterno + "%"));
        }
        if (Apellido_Materno != "")
        {
            sParametrosConsulta = sParametrosConsulta + " Apellido_Materno like @pApellido_Materno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, Apellido_Materno + "%"));
        }
        if (Nombres != "")
        {
            sParametrosConsulta = sParametrosConsulta + " Nombres like @pNombres And";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, Nombres + "%"));
        }

        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }


        con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaAdoptabilidad", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdentidadConfirmada", typeof(bool)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEtnia", typeof(int)));
        dt.Columns.Add(new DataColumn("OficinaInscripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("AnoInscripcion", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroInscripcionCivil", typeof(String)));
        dt.Columns.Add(new DataColumn("AlergiasConocidas", typeof(String)));
        dt.Columns.Add(new DataColumn("InscritoFONADIS", typeof(bool)));
        dt.Columns.Add(new DataColumn("InscritoFONASA", typeof(bool)));
        dt.Columns.Add(new DataColumn("NinoSuceptibleAdopcion", typeof(bool)));
        dt.Columns.Add(new DataColumn("EstadoGestacion", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (DateTime)datareader["FechaAdoptabilidad"];
                dr[2] = (bool)datareader["IdentidadConfirmada"];
                dr[3] = (String)datareader["Rut"];
                dr[4] = (String)datareader["Sexo"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["Apellido_Paterno"];
                dr[7] = (String)datareader["Apellido_Materno"];
                dr[8] = (DateTime)datareader["FechaNacimiento"];
                dr[9] = (int)datareader["CodNacionalidad"];
                dr[10] = (int)datareader["CodEtnia"];
                dr[11] = (String)datareader["OficinaInscripcion"];
                dr[12] = (int)datareader["AnoInscripcion"];
                dr[13] = (String)datareader["NumeroInscripcionCivil"];
                dr[14] = (String)datareader["AlergiasConocidas"];
                dr[15] = (bool)datareader["InscritoFONADIS"];
                dr[16] = (bool)datareader["InscritoFONASA"];
                dr[17] = (bool)datareader["NinoSuceptibleAdopcion"];
                dr[18] = (String)datareader["EstadoGestacion"];
                dr[19] = (DateTime)datareader["FechaActualizacion"];
                dr[20] = (int)datareader["IdUsuarioActualizacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparTipoRelacionNinos()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoRelacionNinos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoRelacion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable insert_ninosrelacionados(int codnino, int codninorelacionado, int idusuarioactualizacion, int tiporelacion, string observacion, string indvigencia, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_NinosRelacionados";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@CodNinoRelacionado", SqlDbType.Int, 4).Value = codninorelacionado;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@TipoRelacion", SqlDbType.Int, 4).Value = tiporelacion;
        sqlc.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = observacion;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetNinosRelacionadosPorNino(int CodNino)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetNinosRelacionadosPorNino + CodNino, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNinoRelacionado", typeof(int)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (int)datareader["CodNinoRelacionado"];
                dr[2] = (int)datareader["IdUsuarioActualizacion"];
                dr[3] = (int)datareader["TipoRelacion"];
                dr[4] = (String)datareader["Observacion"];
                dr[5] = (String)datareader["IndVigencia"];
                dr[6] = (DateTime)datareader["FechaActualizacion"];
                dr[7] = (String)datareader["Rut"];
                dr[8] = (String)datareader["Sexo"];
                dr[9] = (String)datareader["Nombres"];
                dr[10] = (String)datareader["Apellido_Paterno"];
                dr[11] = (String)datareader["Apellido_Materno"];
                dr[12] = (DateTime)datareader["FechaNacimiento"];
                dr[13] = (String)datareader["Descripcion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public int Check_Existencia(int CodNino, int CodNinoRel)
    {
        int cuenta = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sql = "Select count(CodNino)as num from NinosRelacionados " +
        "Where CodNino = " + CodNino + " and CodNinoRelacionado= " + CodNinoRel;

        con.ejecutar(sql, out datareader);

        while (datareader.Read())
        {
            try
            {
                cuenta = (int)datareader["num"];
            }
            catch { }
        }
        con.Desconectar();
        return cuenta;
    }
    public void Update_NinosRelacionados(
                int CodNino, int CodNinoRelacionado, int IdUsuarioActualizacion, int TipoRelacion,
                String Observacion, String IndVigencia, DateTime FechaActualizacion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@CodNinoRelacionado", SqlDbType.Int, 4, CodNinoRelacionado) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@TipoRelacion", SqlDbType.Int, 4, TipoRelacion) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Update_NinosRelacionados", parametros, out datareader);
        con.Desconectar();

    }
    public DataTable insert_direccionninos(int icodie, int codproyecto, int codnino, DateTime fechaingresodireccion, string direccion, string telefono, string telefonorecado, string mail, string fax, int codigopostal, int codcomuna, int alingreso, DateTime fechaactualizacion, int idusuarioactualizacion, string indvigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_DireccionNinos";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@FechaIngresoDireccion", SqlDbType.DateTime, 16).Value = fechaingresodireccion;
        sqlc.Parameters.Add("@Direccion", SqlDbType.VarChar, 100).Value = direccion;
        sqlc.Parameters.Add("@Telefono", SqlDbType.VarChar, 30).Value = telefono;
        sqlc.Parameters.Add("@TelefonoRecado", SqlDbType.VarChar, 30).Value = telefonorecado;
        sqlc.Parameters.Add("@Mail", SqlDbType.VarChar, 30).Value = mail;
        sqlc.Parameters.Add("@Fax", SqlDbType.VarChar, 30).Value = fax;
        sqlc.Parameters.Add("@CodigoPostal", SqlDbType.Int, 4).Value = codigopostal;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = codcomuna;
        sqlc.Parameters.Add("@AlIngreso", SqlDbType.Int, 4).Value = alingreso;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable get_ninorelacionado(string sParametrosConsulta, List<DbParameter> listDbParameter)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = sParametrosConsulta;

        if (listDbParameter != null)
        {
            foreach (DbParameter dbParameter in listDbParameter)
                sqlc.Parameters.Add(dbParameter);
        }

        //sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = CodComuna;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }


    public DataTable get_CapturaRucIcodei(string sParametrosConsulta, List<DbParameter> listDbParameter)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //1
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));       //2
        dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(int)));       //3
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));    //4
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //5
        dt.Columns.Add(new DataColumn("Nombres", typeof(String))); //6   
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));  //7
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));//8
        dt.Columns.Add(new DataColumn("Nacionalidad", typeof(String))); //9
        dt.Columns.Add(new DataColumn("CodTribunal", typeof(int))); //10
        dt.Columns.Add(new DataColumn("RegionTribunal", typeof(String)));       //11
        dt.Columns.Add(new DataColumn("TipoTribunal", typeof(String)));    //12
        dt.Columns.Add(new DataColumn("Tribunal", typeof(String))); //13
        dt.Columns.Add(new DataColumn("Ruc", typeof(String))); //14  
        dt.Columns.Add(new DataColumn("Rit", typeof(string)));  //15
        dt.Columns.Add(new DataColumn("CodCausalIngreso", typeof(Int32)));//16
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int))); //17
        dt.Columns.Add(new DataColumn("TipoDelito", typeof(String))); //18
        dt.Columns.Add(new DataColumn("Delito", typeof(String)));       //19
        dt.Columns.Add(new DataColumn("CodigoDelito", typeof(int)));    //20
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int))); //21
        dt.Columns.Add(new DataColumn("RegionProyecto", typeof(String))); //22
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));  //23
        dt.Columns.Add(new DataColumn("NombreProyecto", typeof(string)));//24
        dt.Columns.Add(new DataColumn("Proyecto", typeof(string))); //25

        while (datareader.Read())
        {
            //try
            //{
            dr = dt.NewRow();
            dr[0] = (int)datareader["ICodIE"];
            dr[1] = (int)datareader["CodNino"];
            dr[2] = (String)datareader["Rut"];
            dr[3] = (int)datareader["CodNacionalidad"];
            dr[4] = (String)datareader["Apellido_Paterno"];
            dr[5] = (String)datareader["Apellido_Materno"];
            dr[6] = (String)datareader["Nombres"];
            dr[7] = (String)datareader["Sexo"];
            try
            {
                dr[8] = (DateTime)datareader["FechaNacimiento"];
            }
            catch { }
            dr[9] = (String)datareader["Nacionalidad"];
            dr[10] = (int)datareader["CodTribunal"];
            dr[11] = (String)datareader["RegionTribunal"];
            dr[12] = (String)datareader["TipoTribunal"];
            dr[13] = (String)datareader["Tribunal"];
            dr[14] = (String)datareader["Ruc"];
            dr[15] = (String)datareader["Rit"];
            try
            {
                dr[16] = (int)datareader["CodCausalIngreso"];
            }
            catch { }
            try
            {
                dr[17] = (int)datareader["CodTipoCausalIngreso"];
            }
            catch { }
            try
            {
                dr[18] = (String)datareader["TipoDelito"];
            }
            catch { }
            try
            {
                dr[19] = (String)datareader["Delito"];
            }
            catch { }

            try
            {
                dr[20] = (int)datareader["CodigoDelito"];
            }
            catch { }
            dr[21] = (int)datareader["CodRegion"];
            dr[22] = (String)datareader["RegionProyecto"];
            dr[23] = (int)datareader["CodProyecto"];
            dr[24] = (String)datareader["NombreProyecto"];
            dr[25] = (String)datareader["Proyecto"];

            dt.Rows.Add(dr);

            // }
            //catch { }
        }
        con.Desconectar();
        return dt;

    }

    public int GetCodRegion(int CodComuna)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select CodRegion from parProvincia where CodProvincia = (select CodProvincia from parComunas where CodComuna =  @CodComuna)";
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int, 4).Value = CodComuna;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);

    }

    public DataTable getNinoRelacionadoJuez(int CodNino, bool LRPA_Familia, string ApellidoPaterno, string ApellidoMaterno, string nombres, string rut, string ruc, string rit)
    {
        DataTable dt = new DataTable();

        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("GET_NinoRelacionadoJuez", sqlc);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@CodNino", SqlDbType.Int).Value = CodNino;
        command.Parameters.Add("@LRPA_Familia", SqlDbType.Bit).Value = LRPA_Familia;
        command.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = ApellidoPaterno;
        command.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = ApellidoMaterno;
        command.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = nombres;
        command.Parameters.Add("@Rut", SqlDbType.VarChar).Value = rut;
        command.Parameters.Add("@Ruc", SqlDbType.VarChar).Value = ruc;
        command.Parameters.Add("@Rit", SqlDbType.VarChar).Value = rit;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();


        return dt;
    }

    public DataTable get_ninorelacionado_juez(string sParametrosConsulta, List<DbParameter> listDbParameter)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8
        dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(Int32)));
        dt.Columns.Add(new DataColumn("RUC", typeof(String)));
        dt.Columns.Add(new DataColumn("RIT", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (String)datareader["Rut"];
                dr[2] = (String)datareader["Sexo"];
                dr[3] = (String)datareader["Nombres"];
                dr[4] = (String)datareader["Apellido_paterno"];
                dr[5] = (String)datareader["Apellido_Materno"];
                try
                {
                    dr[6] = (DateTime)datareader["FechaNacimiento"];
                }
                catch { }
                dr[7] = (int)datareader["CodNacionalidad"];
                dr[8] = (String)datareader["RUC"];
                dr[9] = (String)datareader["RIT"];
                dt.Rows.Add(dr);

            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    public DataTable callto_get_tribunalingreso(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GEt_TribunalIngreso";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable callto_get_causalesingreso(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GEt_CausalesIngreso";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }



    public DataTable get_relacionesxcodnino(int CodNino)
    {
        string sql = "Select t1.CodNinoRelacionado as CodNino,t2.Nombres,t2.Apellido_paterno,t2.Apellido_Materno,t1.TipoRelacion, " +
                     "t3.Descripcion,t1.Observacion from NinosRelacionados t1 inner join Ninos t2 on t1.CodNinoRelacionado = t2.CodNino " +
                     "inner join parTipoRelacionNinos t3 on t1.TipoRelacion = t3.TipoRelacion Where t1.CodNino = " + CodNino;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("Nombres", typeof(String))); //1
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //2
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));       //3
        dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int))); //5
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String))); //6   
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (String)datareader["Nombres"];
                dr[2] = (String)datareader["Apellido_paterno"];
                dr[3] = (String)datareader["Apellido_Materno"];
                dr[4] = (int)datareader["TipoRelacion"];
                dr[5] = (String)datareader["Descripcion"];
                dr[6] = (String)datareader["Observacion"];

                dt.Rows.Add(dr);

            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }


    public void Update_Ninos(
    int CodNino, DateTime FechaAdoptabilidad, bool IdentidadConfirmada, String Rut, String Sexo, String Nombres, String Apellido_Paterno, String Apellido_Materno, DateTime FechaNacimiento, int CodNacionalidad, int CodEtnia, String OficinaInscripcion, int AnoInscripcion, String NumeroInscripcionCivil, String AlergiasConocidas, bool InscritoFONADIS, bool InscritoFONASA, bool NinoSuceptibleAdopcion, String EstadoGestacion, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        object objFechaNac = DBNull.Value;
        if (FechaNacimiento != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaNac = FechaNacimiento;
        };

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@FechaAdoptabilidad", SqlDbType.DateTime, 16, FechaAdoptabilidad) , 
		con.parametros("@IdentidadConfirmada", SqlDbType.Int, 1, IdentidadConfirmada) , 
		con.parametros("@Rut", SqlDbType.VarChar, 11, Rut) , 
		con.parametros("@Sexo", SqlDbType.Char, 1, Sexo) , 
		con.parametros("@Nombres", SqlDbType.VarChar, 100, Nombres) , 
		con.parametros("@Apellido_Paterno", SqlDbType.VarChar, 50, Apellido_Paterno) , 
		con.parametros("@Apellido_Materno", SqlDbType.VarChar, 50, Apellido_Materno) , 
		con.parametros("@FechaNacimiento", SqlDbType.DateTime, 16, objFechaNac) , 
		con.parametros("@CodNacionalidad", SqlDbType.Int, 4, CodNacionalidad) , 
		con.parametros("@CodEtnia", SqlDbType.Int, 4, CodEtnia) , 
		con.parametros("@OficinaInscripcion", SqlDbType.VarChar, 50, OficinaInscripcion) , 
		con.parametros("@AnoInscripcion", SqlDbType.Int, 4, AnoInscripcion) , 
		con.parametros("@NumeroInscripcionCivil", SqlDbType.VarChar, 20, NumeroInscripcionCivil) , 
		con.parametros("@AlergiasConocidas", SqlDbType.VarChar, 200, AlergiasConocidas) , 
		con.parametros("@InscritoFONADIS", SqlDbType.Int, 1, InscritoFONADIS) , 
		con.parametros("@InscritoFONASA", SqlDbType.Int, 1, InscritoFONASA) , 
		con.parametros("@NinoSuceptibleAdopcion", SqlDbType.Int, 1, NinoSuceptibleAdopcion) , 
		con.parametros("@EstadoGestacion", SqlDbType.Char, 1, EstadoGestacion) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_Ninos", parametros, out datareader);
        con.Desconectar();

    }

    public void Update_ninos_F(
        int CodNino,
        string CausalFallecimiento,
        DateTime FechaDefuncion,
        int CodLugarFallecimiento,
        int CodComunaFallecimiento,
        DateTime FechaDenunciaMP,
        DateTime FechaQuerella,
        int SeActivaCircular,
        DateTime FechaCertificado,
        string NumeroCertificado)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "Update Ninos SET CausalFallecimiento = @CausalFallecimiento, FechaDefuncion = @FechaDefuncion, CodLugarFallecimiento = @CodLugarFallecimiento, CodComunaFallecimiento = @CodComunaFallecimiento, " +
                           "FechaDenunciaMP = @FechaDenunciaMP, FechaQuerella = @FechaQuerella, SeActivaCircular = @SeActivaCircular, FechaCertificado = @FechaCertificado, NumeroCertificado = @NumeroCertificado where CodNino = @CodNino";

        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@CausalFallecimiento", SqlDbType.VarChar, 35).Value = CausalFallecimiento;
        sqlc.Parameters.Add("@FechaDefuncion", SqlDbType.DateTime, 16).Value = FechaDefuncion;
        sqlc.Parameters.Add("@CodLugarFallecimiento", SqlDbType.Int, 4).Value = CodLugarFallecimiento;
        sqlc.Parameters.Add("@CodComunaFallecimiento", SqlDbType.Int, 4).Value = CodComunaFallecimiento;
        sqlc.Parameters.Add("@FechaDenunciaMP", SqlDbType.DateTime, 16).Value = FechaDenunciaMP;
        sqlc.Parameters.Add("@FechaQuerella", SqlDbType.DateTime, 16).Value = FechaQuerella;
        sqlc.Parameters.Add("@SeActivaCircular", SqlDbType.Int, 4).Value = SeActivaCircular;
        sqlc.Parameters.Add("@FechaCertificado", SqlDbType.DateTime, 16).Value = FechaCertificado;
        sqlc.Parameters.Add("@NumeroCertificado", SqlDbType.VarChar, 10).Value = NumeroCertificado;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }


    public int Update_ninos_F_T(SqlConnection sqlc, SqlTransaction sqlt, nino nino)
    {
        int resultado = 0;
        SqlCommand command = new SqlCommand("Update_Nino_F", sqlc, sqlt);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 10000000;

        command.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = nino.CodNino;
        command.Parameters.Add("@CausalFallecimiento", SqlDbType.VarChar, 35).Value = nino.CausalDefuncion;
        command.Parameters.Add("@FechaDefuncion", SqlDbType.DateTime, 16).Value = nino.FechaDefuncion;
        command.Parameters.Add("@CodLugarFallecimiento", SqlDbType.Int, 4).Value = nino.CodLugarDefuncion;
        command.Parameters.Add("@CodComunaFallecimiento", SqlDbType.Int, 4).Value = nino.CodComunaDefuncion;
        command.Parameters.Add("@FechaDenunciaMP", SqlDbType.DateTime, 16).Value = nino.FechaDenunciaMP;
        command.Parameters.Add("@FechaQuerella", SqlDbType.DateTime, 16).Value = nino.FechaQuerella;
        command.Parameters.Add("@SeActivaCircular", SqlDbType.Int, 4).Value = nino.SeActivaCircular;
        command.Parameters.Add("@FechaCertificado", SqlDbType.DateTime, 16).Value = nino.FechaCertificado;
        command.Parameters.Add("@NumeroCertificado", SqlDbType.VarChar, 10).Value = nino.NumeroCertificado;

        resultado = Convert.ToInt32(command.ExecuteScalar());

        return resultado;
    }


    public nino GetNinos(int codnino)
    {
        nino n = new nino();
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@CodNino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("GetNino", parametros, out datareader);
        if (datareader.Read())
        {
            try
            {

                n.CodNino = (int)datareader["CodNino"];
                n.FechaAdoptabilidad = (DateTime)datareader["FechaAdoptabilidad"];
                n.IdentidadConfirmada = (bool)datareader["IdentidadConfirmada"];
                n.rut = (String)datareader["Rut"];
                n.sexo = (String)datareader["Sexo"];
                n.Nombres = (String)datareader["Nombres"];
                n.Apellido_Paterno = (String)datareader["Apellido_Paterno"];
                n.Apellido_Materno = (String)datareader["Apellido_Materno"];
                n.FechaNacimiento = (DateTime)datareader["FechaNacimiento"];
                n.CodNacionalidad = (int)datareader["CodNacionalidad"];
                n.CodEtnia = (int)datareader["CodEtnia"];
                n.OficinaInscripcion = (String)datareader["OficinaInscripcion"];
                n.AnoInscripcion = (int)datareader["AnoInscripcion"];
                n.NumeroInscripcionCivil = (String)datareader["NumeroInscripcionCivil"];
                n.AlergiasConocidas = (String)datareader["AlergiasConocidas"];
                n.InscritoFONADIS = (bool)datareader["InscritoFONADIS"];
                n.InscritoFONASA = (bool)datareader["InscritoFONASA"];
                n.NinoSuceptibleAdopcion = (bool)datareader["NinoSuceptibleAdopcion"];
                n.EstadoGestacion = (String)datareader["EstadoGestacion"];
                n.FechaActualizacion = (DateTime)datareader["FechaActualizacion"];
                n.IdUsuarioActualizacion = (int)datareader["IdUsuarioActualizacion"];

            }
            catch { }
        }

        con.Desconectar();
        return n;
    }

    public DataTable callto_consulta_calidajuridica(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Consulta_CalidaJuridica";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_getingresos_egresos(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetIngresos_Egresos";
        sqlc.Parameters.Add("@ICODIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable trae_tipousuario_Ninos(int codnino)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sqlc = "SELECT CodTipoUsuario FROM Ninos WHERE CodNino =" + codnino;
        con.ejecutar(sqlc, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodTipoUsuario", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                try
                {
                    dr[0] = (int)datareader["CodTipoUsuario"];
                }
                catch
                {
                    dr[0] = 0;
                }
                dt.Rows.Add(dr);

            }
            catch
            {

            }
        }
        con.Desconectar();
        return dt;
    }



    public DataTable trae_codinstitucion_inmueble(int ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string sqlc = "SELECT CodInstitucionInmueble from ingresos_egresos where ICodIE = " + ICodIE;
        con.ejecutar(sqlc, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodInstitucionInmueble", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstitucionInmueble"];
                dt.Rows.Add(dr);
            }
            catch
            {

            }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable trae_codTrabajador(int UserId)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select ICodTrabajador from Usuarios where IdUsuario = " + UserId;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            sconn.Close();
            sqlc.CommandText = "select codtrabajador from trabajadores where Icodtrabajador = " + dt.Rows[0][0].ToString();

            da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
        }

        if (dt.Rows.Count == 0)
        {
            DataRow newRow = dt.NewRow();
            newRow[0] = -1;
            dt.Rows.Add(newRow);
        }

        sconn.Close();
        return dt;

        #region codigo erroneo
        //DbDataReader datareader = null;
        // Conexiones con = new Conexiones();
        //string sqlc = "select codtrabajador from trabajadores where Icodtrabajador =" +ICodTrabajador;
        //con.ejecutar(sqlc, out datareader);
        //DataTable dt = new DataTable();
        //DataRow dr;

        //dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));



        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (int)datareader["CodTrabajador"];
        //        dt.Rows.Add(dr);
        //    }
        //    catch
        //    {

        //    }
        //}
        //con.Desconectar();
        //return dt;
        #endregion

    }


    public DataTable get_ninoxrut(string sParametrosConsulta)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaAdoptabilidad", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdentidadConfirmada", typeof(bool)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEtnia", typeof(int)));
        dt.Columns.Add(new DataColumn("OficinaInscripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("AnoInscripcion", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroInscripcionCivil", typeof(String)));
        dt.Columns.Add(new DataColumn("AlergiasConocidas", typeof(String)));
        dt.Columns.Add(new DataColumn("InscritoFONADIS", typeof(bool)));
        dt.Columns.Add(new DataColumn("InscritoFONASA", typeof(bool)));
        dt.Columns.Add(new DataColumn("NinoSuceptibleAdopcion", typeof(bool)));
        dt.Columns.Add(new DataColumn("EstadoGestacion", typeof(String)));


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (DateTime)datareader["FechaAdoptabilidad"];
                dr[2] = (bool)datareader["IdentidadConfirmada"];
                dr[3] = (String)datareader["Rut"];
                dr[4] = (String)datareader["Sexo"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["Apellido_Paterno"];
                dr[7] = (String)datareader["Apellido_Materno"];
                dr[8] = (DateTime)datareader["FechaNacimiento"];
                dr[9] = (int)datareader["CodNacionalidad"];
                dr[10] = (int)datareader["CodEtnia"];
                dr[11] = (String)datareader["OficinaInscripcion"];
                dr[12] = (int)datareader["AnoInscripcion"];
                dr[13] = (String)datareader["NumeroInscripcionCivil"];
                dr[14] = (String)datareader["AlergiasConocidas"];
                dr[15] = (bool)datareader["InscritoFONADIS"];
                dr[16] = (bool)datareader["InscritoFONASA"];
                dr[17] = (bool)datareader["NinoSuceptibleAdopcion"];
                dr[18] = (String)datareader["EstadoGestacion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable callto_get_ninoxrut(string param_rut)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_NinoxRut";
        sqlc.Parameters.Add("@param_rut", SqlDbType.VarChar, 150).Value = param_rut;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public int Get_EstadoIExNino(int CodNino, int codproyecto)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.Get_EstadoIExNino + CodNino + " and codproyecto= " + codproyecto, out datareader);

        int cod_EstadoIE = 1;

        while (datareader.Read())
        {
            try
            {
                cod_EstadoIE = (int)datareader["EstadoIE"];
            }
            catch { }
        }
        con.Desconectar();
        return cod_EstadoIE;
    }



    //public void Insert_SOLICITANTE_UNICO(int p, int p_2, object p_3, object p_4, object p_5, string p_6, DateTime dateTime, int p_8, DateTime dateTime_9, object p_10)
    //{
    //    throw new Exception("The method or operation is not implemented.");
    //}
    public void Insert_VisitaReporteJueces(Int32 IdUsuario, String NombreReporte)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        String strInsert = "INSERT INTO JuecesAcceso (IdUsuario, NombreReporte, FechaAcceso) VALUES (@pIdUsuario, @pNombreReporte, @pFechaAcceso)";

        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, IdUsuario));
        listDbParameter.Add(Conexiones.CrearParametro("@pNombreReporte", SqlDbType.NVarChar, 50, NombreReporte));
        listDbParameter.Add(Conexiones.CrearParametro("@pFechaAcceso", SqlDbType.DateTime, 8, DateTime.Now));

        con.ejecutar(strInsert, listDbParameter);
    }


    public int guardarDatosReunionAtendidos(int codProyecto, DateTime fechaReunion, string comentario, int idUsuario)
    {
        int iCodAnalisisCaso;
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
            sqlc.Parameters.Add("@fechareunion", SqlDbType.DateTime).Value = fechaReunion;
            sqlc.Parameters.Add("@comentario", SqlDbType.VarChar, 200).Value = comentario;
            sqlc.Parameters.Add("@idUsuario", SqlDbType.Int, 8).Value = idUsuario;

            SqlParameter iCodAnalisisCasoReturn = new SqlParameter();
            iCodAnalisisCasoReturn.ParameterName = "@ICodAnalisisCaso";
            iCodAnalisisCasoReturn.SqlDbType = SqlDbType.Int;
            iCodAnalisisCasoReturn.Direction = ParameterDirection.Output;
            sqlc.Parameters.Add(iCodAnalisisCasoReturn);

            sqlc.CommandText = "Insert_AnalisisCasos";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            sconn.Open();
            sqlc.ExecuteNonQuery();
            iCodAnalisisCaso = Int32.Parse(sqlc.Parameters["@iCodAnalisisCaso"].Value.ToString());
            sconn.Close();

            return iCodAnalisisCaso;
        }
        catch
        {
            return 0;
        }
    }

    public void guardarNiñosTratadosReunionAtendidos(int iCodAnalisisCaso, int iCodIE, int CodEventoAnalisisCaso)
    {
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand sqlc = new SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.Add("@icodanalisiscaso", SqlDbType.Int, 10).Value = iCodAnalisisCaso;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int, 10).Value = iCodIE;
            sqlc.Parameters.Add("@codeventosanalisiscaso", SqlDbType.Int, 10).Value = CodEventoAnalisisCaso;
            sqlc.CommandText = "Insert_AnalisisCaso_Atendidos";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            sconn.Open();
            sqlc.ExecuteNonQuery();
            sconn.Close();
        }
        catch
        { }
    }

    public DataTable getAtendidos(int codProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
        sqlc.CommandText = "getAtendidos";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }

    public string formatearRut(string rut)
    {
        int cont = 0;
        string format;
        if (rut.Length == 0)
        {
            return "";
        }
        else
        {
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            format = "-" + rut.Substring(rut.Length - 1);
            for (int i = rut.Length - 2; i >= 0; i--)
            {
                format = rut.Substring(i, 1) + format;
                cont++;
                if (cont == 3 && i != 0)
                {
                    format = "." + format;
                    cont = 0;
                }
            }
            return format;
        }
    }

}
