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
//////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Summary description for EncuestasColl
/// </summary>
public class EncuestasColl
{
	public EncuestasColl()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string[] ExisteEncuesta(string[] DatosDevueltos)
    {
        DataView dt = new DataView(GetData());

        if (dt.Count > 0)
        {
            DatosDevueltos[0] = dt.Count.ToString();
            DatosDevueltos[1] = dt[0]["CodEncuesta"].ToString();
            DatosDevueltos[2] = dt[0]["Formulario"].ToString();
            DatosDevueltos[3] = dt[0]["FechaObligatoria"].ToString();
        }
        return DatosDevueltos;
    }
    public int ExisteEncuesta()
    {
        DataView dt = new DataView(GetData());
        int HayDatos = dt.Count;
        //dt.Rows.Count;
        return HayDatos;
    }
    public int Respondido()
    {
        DataView dt = new DataView(GetData());
        int CodEncuesta = (int)dt[0]["CodEncuesta"];
        return CodEncuesta;
    }
    public int CodigoEncuesta()
    {
        DataView dt = new DataView(GetData());
        if (dt.Count == 0)
            return 0;
        return (int)dt[0]["CodEncuesta"];
    }
    public DataTable GetData()
    {
        DbDataReader datareader = null;
        /*/* Database db = new Database(); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(Resources.Procedures.GetEncuestas, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodEncuesta", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("CodPregunta", typeof(int)));
        dt.Columns.Add(new DataColumn("Pregunta", typeof(string)));
        dt.Columns.Add(new DataColumn("CodSubPregunta", typeof(int)));
        dt.Columns.Add(new DataColumn("SubPregunta", typeof(string)));
        dt.Columns.Add(new DataColumn("Nota", typeof(int)));
        dt.Columns.Add(new DataColumn("NoCorresponde", typeof(int)));
        dt.Columns.Add(new DataColumn("NoSabe", typeof(int)));
        dt.Columns.Add(new DataColumn("Observaciones", typeof(string)));
        dt.Columns.Add(new DataColumn("Formulario", typeof(string)));
        dt.Columns.Add(new DataColumn("FechaObligatoria", typeof(DateTime)));

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodEncuesta"];
                dr[1] = (System.String)datareader["Descripcion"];
                dr[2] = (System.Int32)datareader["CodPregunta"];
                dr[3] = (System.String)datareader["Pregunta"];
                dr[4] = (System.Int32)datareader["CodSubPregunta"];
                dr[5] = (System.String)datareader["SubPregunta"];
                dr[6] = 0;
                dr[7] = 0;
                dr[8] = 0;
                dr[9] = "";
                dr[10] = (System.String)datareader["Formulario"];
                dr[11] = (System.DateTime)datareader["FechaObligatoria"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public DataTable GetData2()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(Resources.Procedures.GetEncuestas2, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodEncuesta", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("CodPregunta", typeof(int)));
        dt.Columns.Add(new DataColumn("Pregunta", typeof(string)));
        dt.Columns.Add(new DataColumn("Observaciones", typeof(string)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodEncuesta"];
                dr[1] = (System.String)datareader["Descripcion"];
                dr[2] = (System.Int32)datareader["CodPregunta"];
                dr[3] = (System.String)datareader["Pregunta"];
                dr[4] = "";
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public int GetData(int CodEncuesta, string IdUsuario)
    {
        DbDataReader datareader = null;
        /*/* Database db = new Database(); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        String Consulta = "select IdUsuario ";
        Consulta += "from EncuestasUsuarios ";
        Consulta += "where IdUsuario = @pIdUsuario ";
        Consulta += "and CodEncuestas = @pCodEncuestas ";
        Consulta += "and CodProyecto is null";

        List<DbParameter> listDbParameter = new List<DbParameter>();
        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(IdUsuario)));
        listDbParameter.Add(Conexiones.CrearParametro("@pCodEncuestas", SqlDbType.Int, 4, CodEncuesta));

        con.ejecutar(Consulta, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("IdUsuario", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["IdUsuario"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt.Rows.Count;
    }
    public int GetData(int CodEncuesta, string IdUsuario, bool ListasEspera)
    {
        DbDataReader datareader = null;
        /*/* Database db = new Database(); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        String Consulta = "select IdUsuario ";
        Consulta += "from EncuestasUsuarios ";
        Consulta += "where IdUsuario = @pIdUsuario ";
        Consulta += "and CodEncuestas = @pCodEncuestas ";

        List<DbParameter> listDbParameter = new List<DbParameter>();
        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(IdUsuario)));
        listDbParameter.Add(Conexiones.CrearParametro("@pCodEncuestas", SqlDbType.Int, 4, CodEncuesta));

        con.ejecutar(Consulta, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("IdUsuario", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["IdUsuario"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt.Rows.Count;
    }

    public DataTable GetDataEncuestaListaEspera(string IdUsuario, int intCodEncuesta)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + .Server + " ;Database= " + .DatabaseName + " ; User ID= " + .User + " ;Password= " + .Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = Convert.ToInt32(IdUsuario);
        if (intCodEncuesta > 0)
            sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = Convert.ToInt32(intCodEncuesta);

        sqlc.CommandText = "PA_Get_Proyecto_por_Usuario";

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);


        if (dt.Rows.Count == 0)     // El Usuario no tiene proyecto asignado
        {
            sconn.Close();
            return dt;
        }
        proyectocoll pcoll = new proyectocoll();
        DataTable dt2 = new DataTable();
        dt2 = pcoll.GetProyectos2(Convert.ToInt32(dt.Rows[0][0]));

        if (dt2.Rows.Count == 0)
        {
            sconn.Close();
            return dt2;
        }

        sqlc.Parameters.Clear();
        sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = intCodEncuesta;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = dt.Rows[0][0];
        sqlc.CommandText = "PA_Get_Contesto_Proyecto";

        da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt3 = new DataTable();
        da.Fill(dt3);
        sconn.Close();
        dt.Clear();

        if (dt3.Rows.Count == 0)    // El proyecto NO Contestó la encuesta
            return dt2;
        else
            return dt;

    }

    public int InsertaRespuestaListaEspera(int IdUsuario, int CodEncuesta, int CodProyecto, int CantidadFemenino, int CantidadMasculino, int Total, int NroTribunalesFiscalia, int EnOtraOportunidad)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(); */ Conexiones con = new Conexiones();


            DbParameter[] parametros =
            {
		    con.parametros("@CodEncuesta", SqlDbType.Int, 4, CodEncuesta) ,
		    //con.parametros("@CodRol", SqlDbType.Int, 4, CodRol) ,
		    con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) ,
		    con.parametros("@CantidadFemenino", SqlDbType.Int, 4, CantidadFemenino) ,
		    con.parametros("@CantidadMasculino", SqlDbType.Int, 4, CantidadMasculino) ,
		    con.parametros("@Total", SqlDbType.Int, 4, Total) ,
		    con.parametros("@NroTribunalesFiscalia", SqlDbType.Int, 4, NroTribunalesFiscalia), 
		    con.parametros("@EnOtraOportunidad", SqlDbType.Int, 4, EnOtraOportunidad)
		    };

            con.ejecutarProcedimiento("pa_InsertaRespuestasListasEspera", parametros, out datareader);
            if (datareader.Read())
            {
                returnvalue = Convert.ToInt32(datareader["Retorno"]);
                if (returnvalue == 0)
                {
                    string SQL = "INSERT INTO EncuestasUsuarios (CodEncuestas, IdUsuario, CodProyecto) VALUES (" + Convert.ToString(CodEncuesta) + ", " + Convert.ToString(IdUsuario) + ", " + Convert.ToInt32(CodProyecto) + ")";
                    con.ejecutar(SQL);
                }
            }

        con.Desconectar();
        return returnvalue;
    }

    public DataTable EncuestasPreguntasExperiencia(int CodEncuesta)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + .Server + " ;Database= " + .DatabaseName + " ; User ID= " + .User + " ;Password= " + .Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = CodEncuesta;
        sqlc.CommandText = "Get_EncuestasPreguntasExperiencia";

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }
    public int InsertaRespuestaCabeza(int CodEncuesta, string IdUsuario)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(); */ Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@CodEncuesta", SqlDbType.Int, 4, CodEncuesta) ,
		con.parametros("@IdUsuario", SqlDbType.Int, 4, IdUsuario) ,
		};

        con.ejecutarProcedimiento("pa_InsertaCabezaRespuestas", parametros, out datareader);
        if (datareader.Read())
            returnvalue = Convert.ToInt32(datareader["Retorno"]);

        con.Desconectar();
        return returnvalue;
    }
    public int InsertaRespuestaCabeza(int CodEncuesta, string IdUsuario, string Comentarios)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(); */ Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@CodEncuesta", SqlDbType.Int, 4, CodEncuesta) ,
		con.parametros("@IdUsuario", SqlDbType.Int, 4, IdUsuario) ,
		con.parametros("@Comentarios", SqlDbType.VarChar, 500, Comentarios) ,
		};

        con.ejecutarProcedimiento("pa_InsertaCabezaRespuestas", parametros, out datareader);
        if (datareader.Read())
            returnvalue = Convert.ToInt32(datareader["Retorno"]);

        con.Desconectar();
        return returnvalue;
    }
    public int InsertaRespuestaDetalle(int CodEncuestado, DataSet dtRespuestas, int IdUsuario, int CodEncuestas)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(); */
        Conexiones con = new Conexiones();


        for (int x = 0; x < dtRespuestas.Tables[0].Rows.Count; x++)
        {
            DbParameter[] parametros =
            {
		    con.parametros("@CodEncuestado", SqlDbType.Int, 4, CodEncuestado) ,
		    con.parametros("@CodPregunta", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestas.Tables[0].Rows[x]["CodPregunta"])) ,
		    con.parametros("@CodSubPregunta", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestas.Tables[0].Rows[x]["CodSubPregunta"])) ,
		    con.parametros("@Nota", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestas.Tables[0].Rows[x]["Nota"])) ,
		    con.parametros("@NoCorresponde", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestas.Tables[0].Rows[x]["NoCorresponde"])) ,
		    con.parametros("@NoSabe", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestas.Tables[0].Rows[x]["NoSabe"])) ,
//		    con.parametros("@Observaciones", SqlDbType.VarChar, 4, Convert.ToString("")) ,
		    con.parametros("@Observaciones", SqlDbType.VarChar, 400, Convert.ToString(dtRespuestas.Tables[0].Rows[x]["Observaciones"])) ,
		    };

            con.ejecutarProcedimiento("pa_InsertaDetalleRespuestas", parametros, out datareader);
            if (datareader.Read())
                returnvalue = Convert.ToInt32(datareader["Retorno"]);

        }
        string SQL = "INSERT INTO EncuestasUsuarios (CodEncuestas, IdUsuario) VALUES (" + Convert.ToString(CodEncuestas) + ", " + Convert.ToString(@IdUsuario)+")";
        con.ejecutar(SQL);

        con.Desconectar();
        return returnvalue;
    }
    public int InsertaRespuestaExperiencia(int CodEncuestado, DataSet dtRespuestasExperiencia, int IdUsuario, int CodEncuestas)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(); */ Conexiones con = new Conexiones();


        for (int x = 0; x < dtRespuestasExperiencia.Tables[0].Rows.Count; x++)
        {
            DbParameter[] parametros =
            {
		    con.parametros("@CodEncuestado", SqlDbType.Int, 4, CodEncuestado) ,
		    con.parametros("@CodPreguntaExperiencia", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestasExperiencia.Tables[0].Rows[x]["CodPreguntaExperiencia"])) ,
		    con.parametros("@NotaFrecuencia", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"])) ,
		    con.parametros("@NotaTiempo", SqlDbType.Int, 4, Convert.ToInt32(dtRespuestasExperiencia.Tables[0].Rows[x]["NotaTiempo"])) ,
		    };

            con.ejecutarProcedimiento("pa_InsertaRespuestasExperiencia", parametros, out datareader);
            if (datareader.Read())
                returnvalue = Convert.ToInt32(datareader["Retorno"]);

        }
        //string SQL = "INSERT INTO EncuestasUsuarios (CodEncuestas, IdUsuario) VALUES (" + Convert.ToString(CodEncuestas) + ", " + Convert.ToString(@IdUsuario) + ")";
        //con.ejecutar(SQL);

        con.Desconectar();
        return returnvalue;
    }

    public int EncuestasRoles(int CodEncuesta, int IdUsuario)
    {
        DataTable dt = new DataTable();
        try
        {
            //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + .Server + " ;Database= " + .DatabaseName + " ; User ID= " + .User + " ;Password= " + .Password + " ;Trusted_Connection=False");
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + "si-sql001.cloudapp.net" + " ;Database= " + "Senainfo" + " ; User ID= " + .User + " ;Password= " + .Password + " ;Trusted_Connection=False");
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = Convert.ToInt32(IdUsuario);
            sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = Convert.ToInt32(CodEncuesta);
            sqlc.CommandText = "PA_GetRolEncuesta";

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            
            sconn.Open();
            da.Fill(dt);


        #region Codigo eliminado
        //Consulta = "select Contrasena ";
        //Consulta += "from Usuarios ";
        //Consulta += "where IdUsuario = " + IdUsuario;

        //con.ejecutar(Consulta, out datareader);

        //DataTable dt = new DataTable();
        //DataRow dr;

        //dt.Columns.Add(new DataColumn("CodRol", typeof(string)));

        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (System.String)datareader["Contrasena"];
        //        dt.Rows.Add(dr);
        //    }
        //    catch
        //    { }
        //}

        //con.Desconectar();

        //if (dt.Rows.Count == 0)
        //    return 0;

        //int CodRol = Convert.ToInt32(dt.Rows[0][0]);

        //Consulta = "select CodRol ";
        //Consulta += "from EncuestasRoles ";
        //Consulta += "where CodRol = " + CodRol + " ";
        //Consulta += "and CodEncuesta = " + CodEncuesta;

        //con.ejecutar(Consulta, out datareader);

        #endregion

        #region Codigo Eliminado 25-11-200
        //DbDataReader datareader = null;
        ///* Database db = new Database(); */ Conexiones con = new Conexiones();
        //DbParameter[] parametros = { };
        //String Consulta = string.Empty;

        //Consulta += "select t3.RoleId ";
        //Consulta += "from Usuarios t1 ";
        //Consulta += "inner join NeoProduccion.dbo.Users t2 ON t1.Usuario = t2.Name ";
        //Consulta += "inner join NeoProduccion.dbo.RelRolesUsers t3 ON t2.UserId = t3.UserId ";
        //Consulta += "where t1.IdUsuario = " + IdUsuario;
        //Consulta += "and t3.RoleId in (select CodRol ";
        //Consulta += "					from EncuestasRoles ";
        //Consulta += "					where CodEncuesta = " + CodEncuesta;
        //Consulta += "					)";

        //con.ejecutar(Consulta, out datareader);

        //DataTable dt = new DataTable();
        //DataRow dr;

        //dt.Columns.Add(new DataColumn("CodRol", typeof(string)));

        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (System.String)datareader["RoleId"].ToString();
        //        dt.Rows.Add(dr);
        //    }
        //    catch
        //    { }
        //}

        //con.Desconectar();
#endregion

        if (dt.Rows.Count == 0)
            return 0;

        #region codigo Eliminado 2
        //int CodRol = Convert.ToInt32(dt.Rows[0][0]);

        //Consulta = "select CodRol ";
        //Consulta += "from EncuestasRoles ";
        //Consulta += "where CodRol = " + CodRol + " ";
        //Consulta += "and CodEncuesta = " + CodEncuesta;

        //con.ejecutar(Consulta, out datareader);

        //dt = new DataTable();

        //dt.Columns.Add(new DataColumn("CodRol", typeof(int)));

        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (System.Int32)datareader["CodRol"];
        //        dt.Rows.Add(dr);
        //    }
        //    catch
        //    { }
        //}

        //con.Desconectar();
        #endregion

          
        }
        catch (Exception ex)
        { }
        return dt.Rows.Count;
    }
}
