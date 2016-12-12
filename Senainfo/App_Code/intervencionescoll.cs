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
////////using neocsharp.NeoDatabase;

/// <summary>
/// Summary description for Intervencionescoll
/// </summary>
public class Intervencionescoll
{
    public Intervencionescoll()
    {
        //
        // TODO: Add constructor logic here
        //
    }







    //private string SQL_Intervenciones(int CodNino)
    //{
    //    string tsql = string.Empty;

    //    tsql = "SELECT DISTINCT * FROM PlanIntervencion T1 Inner join Ingresos_Egresos T2 On T1.ICodIE = T2.ICodIE Where T2.CodNino =" + CodNino;

    //    return tsql;
    //}

    //public DataTable GetIntervenciones(int CodNino)
    //{
    //    DbDataReader datareader = null;
    //    /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
    //    DbParameter[] parametros = { };
    //    con.ejecutar(SQL_Intervenciones(CodNino), out datareader);

    //    DataTable dt = new DataTable();
    //    DataRow dr;

    //    dt.Columns.Add(new DataColumn("CodPlanIntervencion"));
    //    dt.Columns.Add(new DataColumn("ICodIE"));
    //    dt.Columns.Add(new DataColumn("FechaElaboracionPII"));
    //    dt.Columns.Add(new DataColumn("CodGradoCumplimiento"));
    //    dt.Columns.Add(new DataColumn("ColaboracionNino"));
    //    dt.Columns.Add(new DataColumn("ParticipacionFamilia"));
    //    dt.Columns.Add(new DataColumn("CodInstitucion"));
    //    dt.Columns.Add(new DataColumn("CodTrabajador"));
    //    dt.Columns.Add(new DataColumn("FechaInicioPII"));
    //    dt.Columns.Add(new DataColumn("FechaTerminoEstimadaPII"));
    //    dt.Columns.Add(new DataColumn("FechaTerminoRealPII"));
    //    dt.Columns.Add(new DataColumn("Descripcion"));
    //    dt.Columns.Add(new DataColumn("ObservacionCumplimiento"));
    //    dt.Columns.Add(new DataColumn("HabilitadoparaEgreso"));
    //    dt.Columns.Add(new DataColumn("IntervencionCompleta"));
    //    dt.Columns.Add(new DataColumn("FechaActualizacion"));
    //    dt.Columns.Add(new DataColumn("IdUsuarioActualizacion"));



    //    //dr[1] = "(" + ((System.Int32)datareader["CodProyecto"]).ToString() + ") " + (System.String)datareader["Nombre"];



    //    while (datareader.Read())
    //    {
    //        try
    //        {

    //            dr = dt.NewRow();
    //            dr[0] = (System.Int32)datareader["CodPlanIntervencion"];
    //            dr[1] = (System.Int32)datareader["ICodIE"];
    //            dr[2] = (System.Int32)datareader["FechaElaboracionPII"];
    //            dr[3] = (System.Int32)datareader["CodGradoCumplimiento"];
    //            dr[4] = (System.Int32)datareader["ColaboracionNino"];
    //            dr[5] = (System.Int32)datareader["ParticipacionFamilia"];
    //            dr[6] = (System.Int32)datareader["CodInstitucion"];
    //            dr[7] = (System.Int32)datareader["CodTrabajador"];
    //            dr[8] = (System.Int32)datareader["FechaInicioPII"];
    //            dr[9] = (System.Int32)datareader["FechaTerminoEstimadaPII"];
    //            dr[10] = (System.Int32)datareader["FechaTerminoRealPII"];
    //            dr[11] = (System.Int32)datareader["Descripcion"];
    //            dr[12] = (System.Int32)datareader["ObservacionCumplimiento"];
    //            dr[13] = (System.Int32)datareader["HabilitadoparaEgreso"];
    //            dr[14] = (System.Int32)datareader["IntervencionCompleta"];
    //            dr[15] = (System.Int32)datareader["FechaActualizacion"];
    //            dr[16] = (System.Int32)datareader["IdUsuarioActualizacion"];
    //            dt.Rows.Add(dr);
    //        }
    //        catch
    //        { }
    //    }

    //    con.Desconectar();

    //    return dt;

    //}



    public DataTable GetIntervenciones(int CodNino)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetIntervenciones + CodNino, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaElaboracionPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodGradoCumplimiento", typeof(int)));
        dt.Columns.Add(new DataColumn("ColaboracionNino", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("ParticipacionFamilia", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoEstimadaPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoRealPII", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("ObservacionCumplimiento", typeof(String)));
        dt.Columns.Add(new DataColumn("HabilitadoparaEgreso", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("IntervencionCompleta", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodPlanIntervencion"];
                dr[1] = (System.Int32)datareader["ICodIE"];
                dr[2] = (System.DateTime)datareader["FechaElaboracionPII"];
                dr[3] = (System.Int32)datareader["CodGradoCumplimiento"];
                dr[4] = (System.Boolean)datareader["ColaboracionNino"];
                dr[5] = (System.Boolean)datareader["ParticipacionFamilia"];
                dr[6] = (System.Int32)datareader["CodInstitucion"];
                dr[7] = (System.Int32)datareader["CodTrabajador"];
                dr[8] = (System.DateTime)datareader["FechaInicioPII"];
                dr[9] = (System.DateTime)datareader["FechaTerminoEstimadaPII"];
                dr[10] = (System.DateTime)datareader["FechaTerminoRealPII"];
                dr[11] = (System.String)datareader["Descripcion"];
                dr[12] = (System.String)datareader["ObservacionCumplimiento"];
                dr[13] = (System.Boolean)datareader["HabilitadoparaEgreso"];
                dr[14] = (System.Boolean)datareader["IntervencionCompleta"];
                dr[15] = (System.DateTime)datareader["FechaActualizacion"];
                dr[16] = (System.Int32)datareader["IdUsuarioActualizacion"];
                dt.Rows.Add(dr);


            }
            catch
            { }
        }

        con.Desconectar();

        return dt;

    }



    public DataTable GetTipoNivelIntervencion(int CodPlanIntervencion)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoNivelIntervencion + CodPlanIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("IcodIntervenciones", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNivelIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Tipos", typeof(String)));





        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["IcodIntervenciones"];
                dr[1] = (System.Int32)datareader["CodPlanIntervencion"];
                dr[2] = (System.Int32)datareader["CodNivelIntervencion"];
                dr[3] = (System.String)datareader["Tipos"];


                dt.Rows.Add(dr);


            }
            catch
            { }
        }

        con.Desconectar();

        return dt;


    }

    public DataTable GetparTipoEventos()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoEventos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoEventos", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoEventos"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



    public void Update_PlanIntervencion( int CodPlanIntervencion, int ICodIE, DateTime FechaElaboracionPII, int CodGradoCumplimiento, bool ColaboracionNino, bool ParticipacionFamilia, int CodInstitucion, int CodTrabajador, DateTime FechaInicioPII, DateTime FechaTerminoEstimadaPII, DateTime FechaTerminoRealPII, String Descripcion, String ObservacionCumplimiento, bool HabilitadoParaEgreso, bool IntervencionCompleta, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodPlanIntervencion", SqlDbType.Int, 4, CodPlanIntervencion) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@FechaElaboracionPII", SqlDbType.DateTime, 16, FechaElaboracionPII) , 
		con.parametros("@CodGradoCumplimiento", SqlDbType.Int, 4, CodGradoCumplimiento) , 
		con.parametros("@ColaboracionNino", SqlDbType.Int, 1, ColaboracionNino) , 
		con.parametros("@ParticipacionFamilia", SqlDbType.Int, 1, ParticipacionFamilia) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaInicioPII", SqlDbType.DateTime, 16, FechaInicioPII) , 
		con.parametros("@FechaTerminoEstimadaPII", SqlDbType.DateTime, 16, FechaTerminoEstimadaPII) , 
		con.parametros("@FechaTerminoRealPII", SqlDbType.DateTime, 16, FechaTerminoRealPII) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 200, Descripcion) , 
		con.parametros("@ObservacionCumplimiento", SqlDbType.VarChar, 200, ObservacionCumplimiento) , 
		con.parametros("@HabilitadoParaEgreso", SqlDbType.Int, 1, HabilitadoParaEgreso) , 
		con.parametros("@IntervencionCompleta", SqlDbType.Int, 1, IntervencionCompleta) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_PlanIntervencion", parametros, out datareader);
        con.Desconectar();

    }

    public void Update_EventosIntervencion(
int ICodEventosItervencion, int ICodIntervenciones, DateTime FechaEvento, String Descripcion, int CodInstitucion, int CodTrabajador, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodEventosItervencion", SqlDbType.Int, 4, ICodEventosItervencion) , 
		con.parametros("@ICodIntervenciones", SqlDbType.Int, 4, ICodIntervenciones) , 
		con.parametros("@FechaEvento", SqlDbType.DateTime, 16, FechaEvento) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 200, Descripcion) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_EventosIntervencion", parametros, out datareader);
        con.Desconectar();

    }

    public DataTable callto_cierre_cuentaintervenciones_porperiodo(int icodie, int mesano)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_cuentaintervenciones_porperiodo";
        sqlc.Parameters.Add("@icodie", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }


}
