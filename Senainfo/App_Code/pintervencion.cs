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
/// Descripción breve de pintervencion
/// </summary>
public class pintervencion
{
    public pintervencion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public void Delete_EventosIntervencion( String IdGrupoEventos)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@IdGrupoEventos", SqlDbType.VarChar, 50, IdGrupoEventos) 
        };
        con.ejecutarProcedimiento("Delete_EventosIntervencion", parametros, out datareader);
        con.Desconectar();
    
    }
    public DataTable GetTrabajadoresxCodProyecto( int CodProyecto)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTrabajadoresxCodProyecto + CodProyecto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Materno", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dr[1] = (String)datareader["Nombres"] + " " + (String)datareader["Paterno"] + " " + (String)datareader["Materno"];
                dr[2] = (String)datareader["Paterno"];
                dr[3] = (String)datareader["Materno"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    public DataTable GetGrupoxCodProyecto( int CodProyecto)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetGrupoxCodProyecto + CodProyecto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodGrupo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        // dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodGrupo"];
                dr[1] = (String)datareader["Descripcion"];
                //    dr[2] = (String)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    public DataTable GetparEStadoIntervencion()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "select CodEstadoIntervencion,Descripcion from parEstadoIntervencion Where IndVigencia ='V'";
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEstadoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        // dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
       
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEstadoIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                //    dr[2] = (String)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetNinosProyecto(int CodProyecto)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinosxProyectos";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dtLista = new DataTable();
        sconn.Open();
        da.Fill(dtLista);
        sconn.Close();
        DataView dv = new DataView(dtLista);

        //DbDataReader datareader = null;
        ///* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        //string sql = "Select T1.CodNino,T1.ICodIE,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
        //             "T1.FechaIngreso,T2.FechaNacimiento From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino " +
        //             "Where T1.FechaEgreso is null and T1.EstadoIE=0 and T1.CodProyecto = " + CodProyecto;
        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt1 = new DataTable();
        if (CodProyecto > 0)
        {
            dt1 = LRPA.callto_get_proyectoslrpa(CodProyecto);

            if (Convert.ToInt32(dt1.Rows[0][0]) > 0 && dt1.Rows[0][1].ToString() == "20084")
                swLrpa = true;
            else
                swLrpa = false;
        }
        else
            swLrpa = false;

        //if (swLrpa)
        //    sql += " and t1.CodCalidadJuridica <> 25";
        if (swLrpa)
            dv.RowFilter = "CodCalidadJuridica <> 25";
            //sql += " and t1.CodCalidadJuridica <> 25";

        //con.ejecutar(sql, out datareader);
        //DataTable dt = new DataTable();
        //DataRow dr;
        //dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        //dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0
        //dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
        //dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
        //dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
        //dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
        //dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
        //dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //8
        //dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8
        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (int)datareader["CodNino"];
        //        dr[1] = (int)datareader["ICodIE"];
        //        dr[2] = (String)datareader["Rut"];
        //        dr[3] = (String)datareader["Sexo"];
        //        dr[4] = (String)datareader["Nombres"];
        //        dr[5] = (String)datareader["Apellido_paterno"];
        //        dr[6] = (String)datareader["Apellido_Materno"];
        //        dr[7] = (DateTime)datareader["FechaIngreso"];
        //        try
        //        {
        //            dr[8] = (DateTime)datareader["FechaNacimiento"];
        //        }
        //        catch { }
        //        dt.Rows.Add(dr);
        //    }
        //    catch { }
        //}
        //con.Desconectar();
        DataTable dt2;
        dt2 = dv.ToTable();

        return dt2;
    }






 public int callto_get_planintervencion_vigente(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_PlanIntervencion_Vigente";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        int codigo = Convert.ToInt32(dt.Rows[0][0]);
        return codigo;
    }
    public DataTable GetPersonaRelacionadaNinos(int CodIE)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetPersonaRelacionadaNinos + CodIE, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("apellido_paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("apellido_materno", typeof(String)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("fecharelacion", typeof(DateTime)));
        dr = dt.NewRow();
        dr[0] = " Seleccionar ";
        dr[1] = "0";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["nombres"] + " " + (String)datareader["apellido_paterno"] + " " + (String)datareader["apellido_materno"];
                dr[1] = (int)datareader["CodPersonaRelacionada"];
                dr[2] = (String)datareader["apellido_paterno"];
                dr[3] = (String)datareader["apellido_materno"];
                dr[4] = (String)datareader["descripcion"];
                dr[5] = (DateTime)datareader["fecharelacion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }


    public DataTable GetparGradoCumplimiento()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar("Select  CodGradoCumplimiento,Descripcion,IndVigencia From parGradoCumplimientoIntervencion Where IndVigencia = 'V'", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodGradoCumplimiento", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        // dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
       
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodGradoCumplimiento"];
                dr[1] = (String)datareader["Descripcion"];
                //    dr[2] = (String)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparGradoCumplimiento(int CodModeloIntervencion = 0)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parGradoCumplimientoIntervencion";
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public int Insert_Update_PlanIntervencion( int CodPlanIntervencion,
                int ICodIE, int CodProyecto, int CodNino, DateTime FechaIngreso, DateTime FechaElaboracionPII,
                int CodGradoCumplimiento, int ColaboracionNino, int ParticipacionFamilia, int ICodTrabajador,
                int CodInstitucion, int CodTrabajador, DateTime FechaInicioPII, DateTime FechaTerminoEstimadaPII,
                DateTime FechaTerminoRealPII, String Descripcion, String ObservacionCumplimiento,
                int HabilitadoParaEgreso, int IntervencionCompleta, /*DateTime FechaActualizacion, */
                int IdUsuarioActualizacion, int CodGrupo)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@FechaIngreso", SqlDbType.DateTime, 16, FechaIngreso) , 
		con.parametros("@FechaElaboracionPII", SqlDbType.DateTime, 16, FechaElaboracionPII) , 
		con.parametros("@CodGradoCumplimiento", SqlDbType.Int, 4, CodGradoCumplimiento) , 
		con.parametros("@ColaboracionNino", SqlDbType.Int, 1, ColaboracionNino) , 
		con.parametros("@ParticipacionFamilia", SqlDbType.Int, 1, ParticipacionFamilia) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaInicioPII", SqlDbType.DateTime, 16, FechaInicioPII) , 
		con.parametros("@FechaTerminoEstimadaPII", SqlDbType.DateTime, 16, FechaTerminoEstimadaPII) , 
		con.parametros("@FechaTerminoRealPII", SqlDbType.DateTime, 16, FechaTerminoRealPII) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 1000, Descripcion) , 
		con.parametros("@ObservacionCumplimiento", SqlDbType.VarChar, 1000, ObservacionCumplimiento) , 
		con.parametros("@HabilitadoParaEgreso", SqlDbType.Int, 1, HabilitadoParaEgreso) , 
		con.parametros("@IntervencionCompleta", SqlDbType.Int, 1, IntervencionCompleta) , 
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@CodGrupo", SqlDbType.Int, 4, CodGrupo) 
		};
        con.ejecutarProcedimiento("Insert_Update_PlanIntervencion", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }


    public int Insert_Update_PlanIntervencionTransaccional(SqlTransaction sqlt, int CodPlanIntervencion,
               int ICodIE, int CodProyecto, int CodNino, DateTime FechaIngreso, DateTime FechaElaboracionPII,
               int CodGradoCumplimiento, int ColaboracionNino, int ParticipacionFamilia, int ICodTrabajador,
               int CodInstitucion, int CodTrabajador, DateTime FechaInicioPII, DateTime FechaTerminoEstimadaPII,
               DateTime FechaTerminoRealPII, String Descripcion, String ObservacionCumplimiento,
               int HabilitadoParaEgreso, int IntervencionCompleta, /*DateTime FechaActualizacion, */
               int IdUsuarioActualizacion, int CodGrupo)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Update_PlanIntervencion", 	sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;


		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodIE", SqlDbType.Int, 4, ICodIE));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodProyecto", SqlDbType.Int, 4, CodProyecto));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodNino", SqlDbType.Int, 4, CodNino));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaIngreso", SqlDbType.DateTime, 16, FechaIngreso));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaElaboracionPII", SqlDbType.DateTime, 16, FechaElaboracionPII));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodGradoCumplimiento", SqlDbType.Int, 4, CodGradoCumplimiento));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@ColaboracionNino", SqlDbType.Int, 1, ColaboracionNino));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@ParticipacionFamilia", SqlDbType.Int, 1, ParticipacionFamilia)); 
		sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaInicioPII", SqlDbType.DateTime, 16, FechaInicioPII));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaTerminoEstimadaPII", SqlDbType.DateTime, 16, FechaTerminoEstimadaPII));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaTerminoRealPII", SqlDbType.DateTime, 16, FechaTerminoRealPII));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@Descripcion", SqlDbType.VarChar, 1000, Descripcion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@ObservacionCumplimiento", SqlDbType.VarChar, 1000, ObservacionCumplimiento));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@HabilitadoParaEgreso", SqlDbType.Int, 1, HabilitadoParaEgreso));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@IntervencionCompleta", SqlDbType.Int, 1, IntervencionCompleta));
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodGrupo", SqlDbType.Int, 4, CodGrupo));

        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        return returnvalue;
    }

    public int Insert_Update_PlanIntervencionGrupo( int CodGrupo,
String Descripcion, String IndVigencia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodGrupo",SqlDbType.Int ,4,CodGrupo),
		con.parametros("@Descripcion", SqlDbType.Char, 30, Descripcion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 2, IndVigencia) 
		};
        con.ejecutarProcedimiento("Insert_Update_PlanIntervencionGrupo", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_Update_PlanIntervencionGrupoTransaccional(SqlTransaction sqlt, int CodGrupo,
    String Descripcion, String IndVigencia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Update_PlanIntervencionGrupo", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
                
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodGrupo",SqlDbType.Int ,4,CodGrupo));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@Descripcion", SqlDbType.Char, 30, Descripcion)); 
		sqlc.Parameters.Add(Conexiones.CrearParametro("@IndVigencia", SqlDbType.Char, 2, IndVigencia));

        datareader = sqlc.ExecuteReader();
        
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        return returnvalue;
    }



    public int Insert_Intervenciones(
int CodPlanIntervencion, int TipoIntervencion, int CodNivelIntervencion, DateTime FechaCreacion, String IdGrupoIntervenciones)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion) , 
		con.parametros("@TipoIntervencion", SqlDbType.Int, 4, TipoIntervencion) , 
		con.parametros("@CodNivelIntervencion", SqlDbType.Int, 4, CodNivelIntervencion) , 
		con.parametros("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion) , 
		con.parametros("@IdGrupoIntervenciones", SqlDbType.VarChar, 50, IdGrupoIntervenciones) 
		};
        con.ejecutarProcedimiento("Insert_Intervenciones", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_IntervencionesTransaccional(SqlTransaction sqlt,
int CodPlanIntervencion, int TipoIntervencion, int CodNivelIntervencion, DateTime FechaCreacion, String IdGrupoIntervenciones)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Intervenciones", 	sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;


		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@TipoIntervencion", SqlDbType.Int, 4, TipoIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodNivelIntervencion", SqlDbType.Int, 4, CodNivelIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdGrupoIntervenciones", SqlDbType.VarChar, 50, IdGrupoIntervenciones));

        datareader = sqlc.ExecuteReader();
        
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        return returnvalue;
    }


    public void Insert_Update_EstadosPlanIntervencion(
int ICodEstadoIntervencion, int CodPlanIntervencion, int CodEstadoIntervencion /*, DateTime FechaCreacion*/)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodEstadoIntervencion", SqlDbType.Int, 4, ICodEstadoIntervencion) , 
		con.parametros("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion) , 
		con.parametros("@CodEstadoIntervencion", SqlDbType.Int, 4, CodEstadoIntervencion) 
		//con.parametros("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_EstadosPlanIntervencion", parametros, out datareader);
        con.Desconectar();

    }

    public void Insert_Update_EstadosPlanIntervencionTransaccional(SqlTransaction sqlt,
int ICodEstadoIntervencion, int CodPlanIntervencion, int CodEstadoIntervencion /*, DateTime FechaCreacion*/)
    {
        
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Update_EstadosPlanIntervencion", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

		sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodEstadoIntervencion", SqlDbType.Int, 4, ICodEstadoIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodEstadoIntervencion", SqlDbType.Int, 4, CodEstadoIntervencion));

        sqlc.ExecuteNonQuery();        

    }

    public int Insert_Update_EventosIntervencion(
                int ICodEventosIntervencion, int ICodIntervenciones, int CodProyecto, int ICodIE, 
                DateTime FechaEvento, int TipoEventoIntervencion, String Descripcion, int ICodTrabajador,
                int CodInstitucion, int CodTrabajador, DateTime FechaActualizacion, int IdUsuarioActualizacion, String IdGrupoEventos)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodEventosIntervencion", SqlDbType.Int, 4, ICodEventosIntervencion) , 
		con.parametros("@ICodIntervenciones", SqlDbType.Int, 4, ICodIntervenciones) , 
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@FechaEvento", SqlDbType.DateTime, 16, FechaEvento) , 
		con.parametros("@TipoEventoIntervencion", SqlDbType.Int, 4, TipoEventoIntervencion) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 1000, Descripcion) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@IdGrupoEventos", SqlDbType.VarChar, 50, IdGrupoEventos)
		};
        con.ejecutarProcedimiento("Insert_Update_EventosIntervencion", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
        

    }
    public void Insert_Update_TrabajaEgreso(
int ICodTrabajaEgreso, int CodPlanIntervencion, int CodPersonaRelacionada, DateTime FechaCreacion, DateTime FechaEliminacion, String IndVigencia)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodTrabajaEgreso", SqlDbType.Int, 4, ICodTrabajaEgreso) , 
		con.parametros("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion) , 
		con.parametros("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada) , 
		con.parametros("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion) , 
		con.parametros("@FechaEliminacion", SqlDbType.DateTime, 16, FechaEliminacion) , 
		con.parametros("@IndVigencia", SqlDbType.VarChar, 1, IndVigencia) 
		};
        con.ejecutarProcedimiento("Insert_Update_TrabajaEgreso", parametros, out datareader);
        con.Desconectar();

    }

    public void Insert_Update_TrabajaEgresoTransaccional(SqlTransaction sqlt,
int ICodTrabajaEgreso, int CodPlanIntervencion, int CodPersonaRelacionada, DateTime FechaCreacion, DateTime FechaEliminacion, String IndVigencia)
    {        

        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Update_TrabajaEgreso", 	sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

		sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodTrabajaEgreso", SqlDbType.Int, 4, ICodTrabajaEgreso));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion));
		sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaEliminacion", SqlDbType.DateTime, 16, FechaEliminacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IndVigencia", SqlDbType.VarChar, 1, IndVigencia));

        sqlc.ExecuteNonQuery();

    }

    public DataTable Get_Resultado_Busqueda_Eventos(string sParametrosConsulta, List<DbParameter> listDbParameter)
    {
        
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
        DataTable dt = new DataTable();


        DataRow dr;
       
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoRealPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("CodGrupo", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPlanIntervencion"];
                dr[1] = (int)datareader["ICodIE"];
                dr[2] = (int)datareader["CodNino"];
                dr[3] = (DateTime)datareader["FechaInicioPII"];
                dr[4] = (DateTime)datareader["FechaTerminoRealPII"];
                dr[5] = (String)datareader["Rut"];
                dr[6] = (String)datareader["Nombres"];
                dr[7] = (String)datareader["Apellido_Paterno"];
                dr[8] = (String)datareader["Apellido_Materno"];
                dr[9] = (String)datareader["Sexo"];
                dr[10] = (int)datareader["CodGrupo"];
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_Resultado_Busqueda(string sParametrosConsulta, List<DbParameter> listDbParameter)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
        DataTable dt = new DataTable();


        DataRow dr;


        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int))); //0
        //dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));     //1
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int))); //2
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //3
        dt.Columns.Add(new DataColumn("Apellidos_Nino", typeof(String))); //4
        dt.Columns.Add(new DataColumn("Nombres", typeof(String))); //5
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime))); //6
        dt.Columns.Add(new DataColumn("FechaInicioPII", typeof(DateTime))); //7
        dt.Columns.Add(new DataColumn("CodGrupo", typeof(int))); //8
        dt.Columns.Add(new DataColumn("NombreGrupo", typeof(String))); //9


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPlanIntervencion"];
               //dr[1] = (String)datareader["Descripcion"];
                dr[1] = (int)datareader["CodProyecto"];
                dr[2] = (int)datareader["CodNino"];
                dr[3] = (String)datareader["Apellido_Paterno"] + " " + (String)datareader["Apellido_Materno"];
                dr[4] = (String)datareader["Nombres"];
                dr[5] = (DateTime)datareader["FechaIngreso"];
                dr[6] = (DateTime)datareader["FechaInicioPII"];
                dr[7] = (int)datareader["CodGrupo"];
                dr[8] = (String)datareader["NombreGrupo"];
                
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable Get_PII_Resulta(DataTable dtpii)
    {
        String sParametrosConsulta="";
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CodGrupo", typeof(int)));
        
        for (int i = 0; i < dtpii.Rows.Count; i++)
        {
            sParametrosConsulta = "Select CodPlanIntervencion,ICodIE, CodProyecto, CodNino, FechaIngreso, FechaElaboracionPII," +
                             "CodGradoCumplimiento, ColaboracionNino, ParticipacionFamilia, ICodTrabajador," +
                             "CodInstitucion, CodTrabajador, FechaInicioPII, FechaTerminoEstimadaPII," +
                             "FechaTerminoRealPII, Descripcion, ObservacionCumplimiento, HabilitadoParaEgreso," +
                             "IntervencionCompleta, FechaActualizacion, IdUsuarioActualizacion, CodGrupo " +
                             "From PlanIntervencion Where CodPlanIntervencion ="+Convert.ToInt32(dtpii.Rows[i][0]);
            con.ejecutar(sParametrosConsulta, out datareader);
             
            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodPlanIntervencion"];
                    dr[1] = (int)datareader["ICodIE"];
                    String nombre = get_nombre_nino((int)datareader["CodNino"]);
                    dr[2] = nombre; 
                    dr[3] = (int)datareader["CodNino"];
                    dr[4] = (String)datareader["Descripcion"];
                    dr[5] = (int)datareader["CodGrupo"];
                    dt.Rows.Add(dr);


                }
                catch { }
            }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable Get_PII_Ninos(int CodProyecto, int CodPlanIntervencion, int CodNino, string Rut, int ICodTrabajador, string Apellido_Paterno, string Apellido_Materno, string Nombres, int CodGrupo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_PII_Ninos";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@Rut", SqlDbType.NVarChar, 10).Value = Rut;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = ICodTrabajador;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.NVarChar, 100).Value = Apellido_Paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.NVarChar, 100).Value = Apellido_Materno;
        sqlc.Parameters.Add("@Nombres", SqlDbType.NVarChar, 100).Value = Nombres;
        sqlc.Parameters.Add("@CodGrupo", SqlDbType.Int, 4).Value = CodGrupo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public String get_nombre_nino(int CodNino)
    {
        DbDataReader datareader = null;
        
        Conexiones con = new Conexiones();
        string sql = "Select CodNino,Nombres,Apellido_Paterno,Apellido_Materno From Ninos Where CodNino ="+CodNino;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
       while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (String)datareader["Nombres"] + " " + (String)datareader["Apellido_Paterno"] + " " + (String)datareader["Apellido_Materno"];
               dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return Convert.ToString(dt.Rows[0][1]);

    
    }
    public DataTable get_ninos_grupo(int CodGrupo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select T3.CodPlanIntervencion,T1.CodNino,T1.ICodIE,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno,"+
                     "T1.FechaIngreso,T2.FechaNacimiento From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino "+ 
                     "INNER Join PlanIntervencion T3 On T1.CodNino=T3.CodNino and T1.CodProyecto = T3.CodProyecto "+
                     "Where T1.FechaEgreso is null and T1.EstadoIE=0 and T3.CodGrupo ="+CodGrupo;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
        dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //7
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPlanIntervencion"];
                dr[1] = (int)datareader["CodNino"];
                dr[2] = (int)datareader["ICodIE"];
                dr[3] = (String)datareader["Rut"];
                dr[4] = (String)datareader["Sexo"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["Apellido_paterno"];
                dr[7] = (String)datareader["Apellido_Materno"];
                dr[8] = (DateTime)datareader["FechaIngreso"];
                try
                {
                    dr[9] = (DateTime)datareader["FechaNacimiento"];
                }
                catch { }
                    dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }
    public DataTable get_nino_solo(int PlanIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        
        string sql = "Select T3.CodPlanIntervencion,T1.CodNino,T1.ICodIE,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                     "T1.FechaIngreso,T2.FechaNacimiento From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino " +
                     "INNER Join PlanIntervencion T3 On T1.CodNino=T3.CodNino and T1.CodProyecto = T3.CodProyecto " +
                     "Where T1.FechaEgreso is null and T1.EstadoIE=0 and T3.CodPlanIntervencion ="+PlanIntervencion;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
        dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //7
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPlanIntervencion"];
                dr[1] = (int)datareader["CodNino"];
                dr[2] = (int)datareader["ICodIE"];
                dr[3] = (String)datareader["Rut"];
                dr[4] = (String)datareader["Sexo"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["Apellido_paterno"];
                dr[7] = (String)datareader["Apellido_Materno"];
                dr[8] = (DateTime)datareader["FechaIngreso"];
                try
                {
                    dr[9] = (DateTime)datareader["FechaNacimiento"];
                }
                catch { }
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }

    public DataTable GetPlanIntervencionxNino(int CodPlanIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetPlanIntervencionxNino + CodPlanIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaElaboracionPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodGradoCumplimiento", typeof(int)));
        dt.Columns.Add(new DataColumn("ColaboracionNino", typeof(bool)));
        dt.Columns.Add(new DataColumn("ParticipacionFamilia", typeof(bool)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoEstimadaPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoRealPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("ObservacionCumplimiento", typeof(String)));
        dt.Columns.Add(new DataColumn("HabilitadoParaEgreso", typeof(int)));
        dt.Columns.Add(new DataColumn("IntervencionCompleta", typeof(int)));
        dt.Columns.Add(new DataColumn("CodGrupo", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPlanIntervencion"];
                dr[1] = (int)datareader["CodProyecto"];
                dr[2] = (DateTime)datareader["FechaIngreso"];
                dr[3] = (DateTime)datareader["FechaElaboracionPII"];
                dr[4] = (int)datareader["CodGradoCumplimiento"];
                dr[5] = (bool)datareader["ColaboracionNino"];
                dr[6] = (bool)datareader["ParticipacionFamilia"];
                dr[7] = (int)datareader["ICodTrabajador"];
                dr[8] = (int)datareader["CodInstitucion"];
                dr[9] = (int)datareader["CodTrabajador"];
                dr[10] = (DateTime)datareader["FechaInicioPII"];
                dr[11] = (DateTime)datareader["FechaTerminoEstimadaPII"];
                dr[12] = (DateTime)datareader["FechaTerminoRealPII"];
                dr[13] = (String)datareader["Descripcion"];
                dr[14] = (String)datareader["ObservacionCumplimiento"];
                dr[15] = (int)datareader["HabilitadoParaEgreso"];
                dr[16] = (int)datareader["IntervencionCompleta"];
                string Grupo = get_nombre_Grupo((int)datareader["CodGrupo"]);
                dr[17] = Grupo;

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }
    public DataTable GetPlanIntervencionxGrupo(int CodGrupo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetPlanIntervencionxGrupo + CodGrupo, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        //dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        //dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaElaboracionPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodGradoCumplimiento", typeof(int)));
        dt.Columns.Add(new DataColumn("ColaboracionNino", typeof(bool)));
        dt.Columns.Add(new DataColumn("ParticipacionFamilia", typeof(bool)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoEstimadaPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoRealPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("ObservacionCumplimiento", typeof(String)));
        dt.Columns.Add(new DataColumn("HabilitadoParaEgreso", typeof(int)));
        dt.Columns.Add(new DataColumn("IntervencionCompleta", typeof(int)));
        dt.Columns.Add(new DataColumn("CodGrupo", typeof(String)));
       
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                //dr[0] = (int)datareader["CodPlanIntervencion"];
                dr[0] = (int)datareader["CodProyecto"];
                //dr[0] = (DateTime)datareader["FechaIngreso"];
                dr[1] = (DateTime)datareader["FechaElaboracionPII"];
                dr[2] = (int)datareader["CodGradoCumplimiento"];
                dr[3] = (bool)datareader["ColaboracionNino"];
                dr[4] = (bool)datareader["ParticipacionFamilia"];
                dr[5] = (int)datareader["ICodTrabajador"];
                dr[6] = (int)datareader["CodInstitucion"];
                dr[7] = (int)datareader["CodTrabajador"];
                dr[8] = (DateTime)datareader["FechaInicioPII"];
                dr[9] = (DateTime)datareader["FechaTerminoEstimadaPII"];
                dr[10] = (DateTime)datareader["FechaTerminoRealPII"];
                dr[11] = (String)datareader["Descripcion"];
                dr[12] = (String)datareader["ObservacionCumplimiento"];
                dr[13] = (int)datareader["HabilitadoParaEgreso"];
                dr[14] = (int)datareader["IntervencionCompleta"];
                string Grupo = get_nombre_Grupo((int)datareader["CodGrupo"]);
                dr[15] = Grupo;
                
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }
    public String get_nombre_Grupo(int CodGrupo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select Descripcion From PlanIntervencionGrupo Where IndVigencia = 'V' and CodGrupo =" + CodGrupo;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return Convert.ToString(dt.Rows[0][0]);
        
    }
    public int get_CodModeloInterv(int CodProyecto)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select CodModeloIntervencion From Proyectos Where CodProyecto ="+CodProyecto;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodModeloIntervencion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return Convert.ToInt32(dt.Rows[0][0]);

    }
    public DataTable get_areaintervencion_grupo(int CodGrupo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select Distinct T2.CodGrupo,T1.TipoIntervencion,T1.CodNivelIntervencion,T3.Descripcion as DesTipoIntervencion, T4.Descripcion as DesNivelIntervencion,T1.IdGrupoIntervenciones "+
                     "From Intervenciones T1 inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion "+
                     "Inner join parTipoIntervencion T3 On T1.TipoIntervencion = T3.TipoIntervencion "+
                     "Inner Join parNivelIntervencion T4 On T1.CodNivelIntervencion = T4.CodNivelIntervencion Where T2.CodGrupo ="+CodGrupo;
         
       
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoIntervencion", typeof(String)));
        dt.Columns.Add(new DataColumn("NivelIntervencion", typeof(String)));
        dt.Columns.Add(new DataColumn("IdGrupoIntervenciones", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["DesTipoIntervencion"];
                dr[1] = (String)datareader["DesNivelIntervencion"];
                dr[2] = (String)datareader["IdGrupoIntervenciones"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable get_areaintervencion_grupoII(int CodGrupo, int CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_AreaIntervencionGrupo";
        sqlc.Parameters.Add("@CodGrupo", SqlDbType.Int, 4).Value = CodGrupo;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable get_areaintervencion_NinoII(int CodPlanIntervencion, int CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_AreaIntervencionNino";
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable get_areaintervencion_Nino(int CodPlanIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select Distinct T2.CodGrupo,T1.TipoIntervencion,T1.CodNivelIntervencion,T3.Descripcion as DesTipoIntervencion, T4.Descripcion as DesNivelIntervencion,T1.IdGrupoIntervenciones " +
        " From Intervenciones T1 inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion " +
        " inner join partipointervencion T3 ON T3.TipoIntervencion = T1.TipoIntervencion " +
        " inner join parnivelintervencion T4 ON T4.CodNivelIntervencion = T1.CodNivelIntervencion " +
        " Where T2.CodPlanIntervencion = "+CodPlanIntervencion ;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoIntervencion", typeof(String)));
        dt.Columns.Add(new DataColumn("NivelIntervencion", typeof(String)));
        dt.Columns.Add(new DataColumn("IdGrupoIntervenciones", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["DesTipoIntervencion"];
                dr[1] = (String)datareader["DesNivelIntervencion"];
                dr[2] = (String)datareader["IdGrupoIntervenciones"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable get_areaintervencion_grupo_Ins(int CodGrupo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select T1.CodPlanIntervencion,T1.ICodIntervenciones,T2.CodGrupo,T1.TipoIntervencion,T1.CodNivelIntervencion" +
                     " From Intervenciones T1 inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion " +
                     "Where T2.CodGrupo =" + CodGrupo;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodIntervenciones", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodIntervenciones"];
                dr[1] = (int)datareader["CodPlanIntervencion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetEstadoIntervencionxGrupo(int CodGrupo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEstadoIntervencionxGrupo + CodGrupo, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodEstadoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEstadoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaCreacion", typeof(DateTime)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodEstadoIntervencion"];
                dr[1] = (int)datareader["CodPlanIntervencion"];
                dr[2] = (int)datareader["CodEstadoIntervencion"];
                dr[3] = (DateTime)datareader["FechaCreacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetEstadoIntervencionxNino(int CodPlanIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEstadoIntervencionxNino + CodPlanIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodEstadoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEstadoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaCreacion", typeof(DateTime)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodEstadoIntervencion"];
                dr[1] = (int)datareader["CodPlanIntervencion"];
                dr[2] = (int)datareader["CodEstadoIntervencion"];
                dr[3] = (DateTime)datareader["FechaCreacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetTrabajaEgreso(int CodPlanIntervencion, int icodie)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTrabajaEgreso + CodPlanIntervencion + " and T3.icodie ="+icodie, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("ICodTrabajaEgreso", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["nombre"];
                dr[1] = (int)datareader["ICodTrabajaEgreso"];
                dr[2] = (int)datareader["CodPlanIntervencion"];
                dr[3] = (int)datareader["CodPersonaRelacionada"];
                dr[4] = (String)datareader["IndVigencia"];
                dr[5] = (String)datareader["Descripcion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    public DataTable get_areaintervencion(int CodGrupo,int PlanIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "";
        if (CodGrupo == 0)
        {
            sql = "Select Distinct T2.CodGrupo,T1.TipoIntervencion,T1.ICodIntervenciones,T1.CodNivelIntervencion,T3.Descripcion as DesTipoIntervencion, T4.Descripcion as DesNivelIntervencion " +
                  "From Intervenciones T1 inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion " +
                  "Inner join parTipoIntervencion T3 On T1.TipoIntervencion = T3.TipoIntervencion " +
                  "Inner Join parNivelIntervencion T4 On T1.CodNivelIntervencion = T4.CodNivelIntervencion Where T2.CodPlanIntervencion =" +PlanIntervencion;
        }
        else
        {
            sql = "Select Distinct T2.CodGrupo,T1.TipoIntervencion,T1.CodNivelIntervencion, "+
                  "T3.Descripcion as DesTipoIntervencion, T4.Descripcion as DesNivelIntervencion,T1.IdGrupoIntervenciones "+
                  "From Intervenciones T1 "+
                  "inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion "+
                  "Inner join parTipoIntervencion T3 On T1.TipoIntervencion = T3.TipoIntervencion "+
                  "Inner Join parNivelIntervencion T4 On T1.CodNivelIntervencion = T4.CodNivelIntervencion "+
                  "Where T2.CodGrupo =" + CodGrupo;
        }         
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodIntervenciones", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                if (CodGrupo == 0)
                {
                   dr[0] = Convert.ToString((int)datareader["ICodIntervenciones"]) + "_" + Convert.ToString((int)datareader["TipoIntervencion"]);
                }
                else
                {
                    dr[0] = Convert.ToString((String)datareader["IdGrupoIntervenciones"]) + "_" + Convert.ToString((int)datareader["TipoIntervencion"]);
                }
                   dr[1] = (String)datareader["DesTipoIntervencion"] + " / " + (String)datareader["DesNivelIntervencion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable get_areaintervencionII(int CodGrupo, int CodPlanIntervencion, int CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_AreaIntervencion";
        sqlc.Parameters.Add("@CodGrupo", SqlDbType.Int, 4).Value = CodGrupo;
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable get_ICodIntervenciones(int CodGrupo, int PlanIntervencion,int TipoIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "";
        if (CodGrupo == 0)
        {
            sql = "Select T1.ICodIntervenciones, T2.CodGrupo,T1.TipoIntervencion,T1.CodNivelIntervencion,T3.Descripcion as DesTipoIntervencion, T4.Descripcion as DesNivelIntervencion "+
                  "From Intervenciones T1 inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion "+
                  "Inner join parTipoIntervencion T3 On T1.TipoIntervencion = T3.TipoIntervencion "+
                  "Inner Join parNivelIntervencion T4 On T1.CodNivelIntervencion = T4.CodNivelIntervencion "+
                  "Where T2.CodPlanIntervencion ="+PlanIntervencion+" and T1.TipoIntervencion = "+TipoIntervencion;
        }
        else
        {
            sql = "Select T1.ICodIntervenciones, T2.CodGrupo,T1.TipoIntervencion,T1.CodNivelIntervencion,T3.Descripcion as DesTipoIntervencion, T4.Descripcion as DesNivelIntervencion "+
                  "From Intervenciones T1 inner join PlanIntervencion T2 On T1.CodPlanIntervencion = T2.CodPlanIntervencion "+
                  "Inner join parTipoIntervencion T3 On T1.TipoIntervencion = T3.TipoIntervencion "+
                  "Inner Join parNivelIntervencion T4 On T1.CodNivelIntervencion = T4.CodNivelIntervencion "+
                  "Where T2.CodGrupo ="+CodGrupo+" and T1.TipoIntervencion = "+TipoIntervencion + " " +
                  "Order by T1.TipoIntervencion, T1.CodNivelIntervencion";
        }
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodIntervenciones", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodIntervenciones"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable get_tipoevento(int CodGrupo, int PlanIntervencion,int TipoIntervencion,int ModeloIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "";
        if (CodGrupo == 0)
        {
            sql = "SELECT distinct a.codproyecto , b.TipoIntervencion , c.CodModeloIntervencion, d.TipoEventoIntervencion , e.descripcion " +
                  "FROM  planintervencion a " +
                  "INNER join intervenciones b ON a.codplanintervencion = b.codplanintervencion " +
                  "INNER JOIN  proyectos c ON a.codproyecto = c.codproyecto " +
                  "INNER JOIN parEventosIntervencionCantidad d ON b.TipoIntervencion = d.TipoIntervencion AND c.CodModeloIntervencion = d.CodModeloIntervencion " +
                  "INNER JOIN partipoeventointervencion e on d.TipoEventoIntervencion = e.TipoEventoIntervencion " +
                  "WHERE a.CodPlanIntervencion =" + PlanIntervencion + " and  b.TipoIntervencion=" + TipoIntervencion + " and c.CodModeloIntervencion=" + ModeloIntervencion +
                  " And d.indvigencia = 'V'";

        }
        else
        {
            sql = "SELECT distinct a.codproyecto , b.TipoIntervencion , c.CodModeloIntervencion, d.TipoEventoIntervencion , e.descripcion " +
                  "FROM  planintervencion a " +
                  "INNER join intervenciones b ON a.codplanintervencion = b.codplanintervencion " +
                  "INNER JOIN  proyectos c ON a.codproyecto = c.codproyecto " +
                  "INNER JOIN parEventosIntervencionCantidad d ON b.TipoIntervencion = d.TipoIntervencion AND c.CodModeloIntervencion = d.CodModeloIntervencion " +
                  "INNER JOIN partipoeventointervencion e on d.TipoEventoIntervencion = e.TipoEventoIntervencion " +
                  "WHERE a.codgrupo =" + CodGrupo + " and  b.TipoIntervencion=" + TipoIntervencion + " and c.CodModeloIntervencion=" + ModeloIntervencion +
                  " And d.indvigencia = 'V'";
        }

       
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoEventoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoEventoIntervencion"];
                dr[1] = (String)datareader["descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable get_tipoeventoII(int CodGrupo, int CodPlanIntervencion, int TipoIntervencion, int ModeloIntervencion, int CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_TipoEvento";
        sqlc.Parameters.Add("@CodGrupo", SqlDbType.Int, 4).Value = CodGrupo;
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = CodPlanIntervencion;
        sqlc.Parameters.Add("@TipoIntervencion", SqlDbType.Int, 4).Value = TipoIntervencion;
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = ModeloIntervencion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable get_tipoevento_Cons(int CodGrupo, int PlanIntervencion, int CodProyecto)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        if (CodGrupo == 0)
        {
            DbParameter[] parametros = {
		        con.parametros("@param_codproyecto", SqlDbType.Int, 4, CodProyecto) , 
		        con.parametros("@param_codplanIntervencion", SqlDbType.Int, 4, PlanIntervencion)    
		        };
            con.ejecutarProcedimiento("Get_EventosIntervencion_Individual", parametros, out datareader);
           
        }
        else
        {
            DbParameter[] parametros = {
		        con.parametros("@param_codproyecto", SqlDbType.Int, 4, CodProyecto) , 
		        con.parametros("@param_codgrupo", SqlDbType.Int, 4, CodGrupo)
		        };
            con.ejecutarProcedimiento("Get_EventosIntervencion_Grupal", parametros, out datareader);
        }
        
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("FechaEvento", typeof(DateTime))); //1
        dt.Columns.Add(new DataColumn("TipoEventoIntervencion", typeof(String))); //2
        dt.Columns.Add(new DataColumn("DescTipoIntervencion", typeof(String))); //3
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(String))); //4
        dt.Columns.Add(new DataColumn("IdGrupoEventos", typeof(String))); //5

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (DateTime)datareader["FechaEvento"]; 
                dr[1] = (String)datareader["TipoEvento"];
                dr[2] = (String)datareader["DescTipoIntervencion"] + "/" + (String)datareader["Nivel"];
                dr[3] = (String)datareader["Nombres"] + " " + (String)datareader["Paterno"] + " " + (String)datareader["Materno"];
                if ((String)datareader["IdGrupoEventos"] == "0")
                {
                    dr[4] = (int)datareader["ICodEventosIntervencion"];
                }
                else
                {
                    dr[4] = (String)datareader["IdGrupoEventos"];
                }
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public int get_planintervencion_vigente(int icodie)
    {
        int retorno=0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@ICodIE", SqlDbType.Int,4, icodie) };
       con.ejecutarProcedimiento("Get_PlanIntervencion_Vigente",parametros, out datareader);
       while (datareader.Read())
        {
            try
            {
                retorno = (int)datareader["Retorno"];
            }
            catch { }
        }
        con.Desconectar();
        return retorno;

    
    }
    public int chek_interv_evento(String IdGrupoIntervenciones)
    {

        int ICodIntervenciones = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "";
        List<DbParameter> listDbParameter = new List<DbParameter>();
      
        sql = "Select T1.IcodIntervenciones From EventosIntervencion T1 inner  Join Intervenciones T2 ON T1.ICodIntervenciones = T2.ICodIntervenciones " +
                         "Where T2.IdGrupoIntervenciones =@pIdGrupoIntervenciones";

        listDbParameter.Add(Conexiones.CrearParametro("@pIdGrupoIntervenciones", SqlDbType.VarChar, 50, IdGrupoIntervenciones));

        con.ejecutar(sql, listDbParameter, out datareader);
        while (datareader.Read())
        {
            try
            {
                ICodIntervenciones = (int)datareader["IcodIntervenciones"];
            }
            catch { }
        }
        con.Desconectar();
        return ICodIntervenciones;


    }
    public DataTable delete_intervenciones(string idgrupointervenciones)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Delete_Intervenciones";
        sqlc.Parameters.Add("@IdGrupoIntervenciones", SqlDbType.VarChar, 50).Value = idgrupointervenciones;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetEstadosPlanIntevencion(int CodPlanIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEstadosPlanIntevencion + CodPlanIntervencion + " Order By t1.FechaCreacion DESC", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));

        dt.Columns.Add(new DataColumn("FechaCreacion", typeof(DateTime)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dr[1] = (DateTime)datareader["FechaCreacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable delete_eventosintervencionxcodigo(int icodeventosintervencion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Delete_EventosIntervencionxCodigo";
        sqlc.Parameters.Add("@ICodEventosIntervencion", SqlDbType.Int, 4).Value = icodeventosintervencion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable delete_intervencionesxcodigo(int icodintervenciones)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Delete_IntervencionesxCodigo";
        sqlc.Parameters.Add("@ICodIntervenciones", SqlDbType.Int, 4).Value = icodintervenciones;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_update_planintervencion_datosplan(int codplanintervencion, int icodtrabajador, DateTime fechainiciopii, DateTime fechaterminoestimadapii, string descripcion, int idusuarioactualizacion, int codgrupo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_PlanIntervencion_DatosPlan";
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = codplanintervencion;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@FechaInicioPII", SqlDbType.DateTime, 16).Value = fechainiciopii;
        sqlc.Parameters.Add("@FechaTerminoEstimadaPII", SqlDbType.DateTime, 16).Value = fechaterminoestimadapii;
        sqlc.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = descripcion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodGrupo", SqlDbType.Int, 4).Value = codgrupo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_insert_update_planintervencion_seguimientoplan(int codplanintervencion, int colaboracionnino, int participacionfamilia, string observacioncumplimiento)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_Update_PlanIntervencion_SeguimientoPlan";
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = codplanintervencion;
        sqlc.Parameters.Add("@ColaboracionNino", SqlDbType.Bit, 1).Value = colaboracionnino;
        sqlc.Parameters.Add("@ParticipacionFamilia", SqlDbType.Bit, 1).Value = participacionfamilia;
        sqlc.Parameters.Add("@ObservacionCumplimiento", SqlDbType.VarChar, 200).Value = observacioncumplimiento;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_update_planintervencion_terminoplan(int codplanintervencion, DateTime fechaterminorealpii, int habilitadoparaegreso, int intervencioncompleta, int CodGradoCumplimiento)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_PlanIntervencion_TerminoPlan";
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = codplanintervencion;
        sqlc.Parameters.Add("@FechaTerminoRealPII", SqlDbType.DateTime, 16).Value = fechaterminorealpii;
        sqlc.Parameters.Add("@HabilitadoParaEgreso", SqlDbType.Int, 4).Value = habilitadoparaegreso;
        sqlc.Parameters.Add("@IntervencionCompleta", SqlDbType.Int, 4).Value = intervencioncompleta;
        sqlc.Parameters.Add("@CodGradoCumplimiento", SqlDbType.Int, 4).Value = CodGradoCumplimiento;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
}
