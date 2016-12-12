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

using System.Collections.Generic;

/// <summary>
/// Summary description for LRPAcoll
/// </summary>
public class LRPAcoll
{
	public LRPAcoll()
	{

		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable callto_get_parmodelosancionmixta()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parModeloSancionMixta";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr;
        dr = dt.NewRow();
        dr[0] = -1;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
     
        return dt;
    }
    public DataTable callto_get_sancionesbycodigo(int codmedidasancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GET_SANCIONESbyCodigo";
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_get_sancionesbycodigo_2(int codmedidasancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GET_SANCIONESbyCodigo_2";
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetICodTribunalIngreso_LRPA( int icodie)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        // conexiones
        con.ejecutar(Resources.Procedures.GetICodTribunalIngreso_LRPA + icodie, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTribunalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("Ruc", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodTribunalIngreso"];
                dr[1] = "("+(String)datareader["Ruc"]+")"+" - "+(String)datareader["Descripcion"];
                dr[2] = (String)datareader["Ruc"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
  
    /// /////////////////TIPO SANCION///////////////////////////
 
    public DataTable GetPartiposancion()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoSancion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodTipoSancion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoSancion"];
                dr[1] = (string)datareader["Descripcion"];
                dr[2] = (string)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable Get_traenemotec( string nemo)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "select * from parcondicioningreso where indvigencia = 'V' and nemotecnico =@pnemotecnico";

        List<DbParameter> listDbParameter = new List<DbParameter>();
        listDbParameter.Add(Conexiones.CrearParametro("@pnemotecnico", SqlDbType.VarChar, 1, nemo));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (string)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



//////////////////////TIPO ACTIVIDAD//////////////////////////////

    public DataTable GetParActividad()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string slq = "select * from partipoactividad where indvigencia = 'V'";
        con.ejecutar(slq, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodTipoActividad", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoActividad"];
                dr[1] = (string)datareader["Descripcion"];
                dr[2] = (string)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
   ///////////////////// TIPO AREA DE TRABAJO ////////////////////
   
    public DataTable GetAreaTrabajo()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string slq = "select * from partipoareatrabajo where indvigencia = 'V'";
        con.ejecutar(slq, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodTipoAreaTrabajo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoAreaTrabajo"];
                dr[1] = (string)datareader["Descripcion"];
                dr[2] = (string)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

 
   //////////////////TIPO REPARACION //////////////////////

    public DataTable GetReparacion()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string slq = "select * from partiporeparacion where indvigencia = 'V'";
        con.ejecutar(slq, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodTipoReparacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoReparacion"];
                dr[1] = (string)datareader["Descripcion"];
                dr[2] = (string)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
   
   //////////////////////TIPO INSTITUCION ////////////////
   
    public DataTable GetParTipoInstitucion()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string slq = "select * from partipoinstitucion where indvigencia = 'V'";
        con.ejecutar(slq, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("TipoInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoInstitucion"];
                dr[1] = (string)datareader["Descripcion"];
                dr[2] = (string)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

   
    /// //////////////// TIPO CONDICION INGRESO/////////////////////

    public DataTable GetCondicionIngreso()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string slq = "select * from parcondicionIngreso where indvigencia = 'V'";
        con.ejecutar(slq, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodCondicionIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));
        dt.Columns.Add(new DataColumn("NemoTecnico", typeof(string)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCondicionIngreso"];
                dr[1] = (string)datareader["Descripcion"];
                dr[2] = (string)datareader["IndVigencia"];
                dr[3] = (string)datareader["NemoTecnico"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

   
    ///////////////////////////TRAE COD MODELO INTERVENCION POR PROYECTO //////////////////////////

    public DataTable GetCodModIntervencion( int codproy)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string slq = "select codmodelointervencion, codproyecto, nombre, indvigencia from proyectos where indvigencia = 'V' and codproyecto = '"+codproy+"'";
        con.ejecutar(slq, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("codmodelointervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(string)));
        dt.Columns.Add(new DataColumn("nombre", typeof(string)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["codmodelointervencion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (string)datareader["IndVigencia"];
                dr[3] = (string)datareader["nombre"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }







    public DataTable GetparSituacionTuicionLRPA( int CodSituacion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        // conexiones
        con.ejecutar(Resources.Procedures.GetparSituacionTuicionLRPA + CodSituacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacionTuicion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacionTuicion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparEstadoAbandonoLRPA()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEstadoAbandonoLRPA, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEstadoAbandono", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("Nemotecnico", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEstadoAbandono"];
                dr[1] = "(" + datareader["Nemotecnico"].ToString().ToUpper() + ") " + datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["Nemotecnico"];
                dr[3] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparDiligenciaLRPA()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDiligenciaLRPA, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("PropuestaTecnica", typeof(bool)));
        dt.Columns.Add(new DataColumn("ResultadoDiscernimiento", typeof(bool)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDiligencia"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dr[3] = (bool)datareader["PropuestaTecnica"];
                dr[4] = (bool)datareader["ResultadoDiscernimiento"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
   
    public DataTable GetparTipoAtencionLRPA()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoAtencionLRPA, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoAtencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoAtencion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparCalidadJuridicaLRPA()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparCalidadJuridicaLRPA, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCalidadJuridica", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCalidadJuridica"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    
    public DataTable GetparCalidadJuridicaLRPA_II( int CodModeloIntervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetParCalidadJuridicaLRPA_II + CodModeloIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCalidadJuridica", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCalidadJuridica"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable callto_getpartiposancionaccesoria()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoSancionAccesoria";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        

        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr;
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr); 
        return dt;
    }

    public DataTable callto_getparcondicioningreso_2(int codmedsan)///ACA
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select T1.CodMedidaSancion , T1.CodCondicionIngreso,t2.nemotecnico, T2.descripcion from TipoMedidaCondicion t1, parcondicionIngreso t2 where t1.codcondicioningreso = t2.codcondicioningreso and t1.codmedidasancion = '" + codmedsan + "'";

        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodMedidaSancion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CodCondicionIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Nemotecnico", typeof(String)));
       
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodMedidaSancion"];
                dr[1] = "("+(String)datareader["Nemotecnico"]+")"+" - "+(String)datareader["Descripcion"];
                dr[2] = (int)datareader["CodCondicionIngreso"];
               
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
  


 ////////////////michael

    public DataTable callto_getpartipoConIngreso()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoConIngreso";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();


        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr;
        dr = dt.NewRow();
        dr[0] = -1;
        dr[2] = "Seleccionar";
        dt.Rows.Add(dr);
        return dt;
    }
    
    
public int callto_insert_tipomedidassanciones (int icodie ,DateTime fechainicio ,DateTime fechatermino ,int mesduracion ,int anoduracion ,int codtibunal ,int sancionaccesoria ,int idusuarioactualizacion ,DateTime fechaactualizacion ,int codterminosancion ,int codregion ,int codtipotribunal ,int mesduracionmix ,int anoduracionmix ,DateTime fechaterminomix ,DateTime fechainiciomix ,DateTime fechaterminosansion ,int icodtribunalingreso ,int diaduracion ,int diaduracionmixta ,int codmodelosancionmixta ,int bono ,int horas ) 
	{ 
	 SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
	 System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
	 sqlc.Connection = sconn;
	 sqlc.CommandType = System.Data.CommandType.StoredProcedure;
	 sqlc.CommandText = "Insert_TipoMedidasSanciones";
		sqlc.Parameters.Add("@ICodIE",SqlDbType.Int, 4 ).Value = icodie;
		sqlc.Parameters.Add("@FechaInicio",SqlDbType.DateTime, 16 ).Value = fechainicio;
		sqlc.Parameters.Add("@FechaTermino",SqlDbType.DateTime, 16 ).Value = fechatermino;
		sqlc.Parameters.Add("@MesDuracion",SqlDbType.Int, 4 ).Value = mesduracion;
		sqlc.Parameters.Add("@AnoDuracion",SqlDbType.Int, 4 ).Value = anoduracion;
		sqlc.Parameters.Add("@CodTibunal",SqlDbType.Int, 4 ).Value = codtibunal;
		sqlc.Parameters.Add("@SancionAccesoria",SqlDbType.Int, 4 ).Value = sancionaccesoria;
		sqlc.Parameters.Add("@IdUsuarioActualizacion",SqlDbType.Int, 4 ).Value = idusuarioactualizacion;
		sqlc.Parameters.Add("@FechaActualizacion",SqlDbType.DateTime, 16 ).Value = fechaactualizacion;
		sqlc.Parameters.Add("@CodTerminoSancion",SqlDbType.Int, 4 ).Value = codterminosancion;
		sqlc.Parameters.Add("@CodRegion",SqlDbType.Int, 4 ).Value = codregion;
		sqlc.Parameters.Add("@CodTipoTribunal",SqlDbType.Int, 4 ).Value = codtipotribunal;
		sqlc.Parameters.Add("@MesDuracionMix",SqlDbType.Int, 4 ).Value = mesduracionmix;
		sqlc.Parameters.Add("@AnoDuracionMix",SqlDbType.Int, 4 ).Value = anoduracionmix;
		sqlc.Parameters.Add("@FechaTerminoMix",SqlDbType.DateTime, 16 ).Value = fechaterminomix;
		sqlc.Parameters.Add("@FechaInicioMix",SqlDbType.DateTime, 16 ).Value = fechainiciomix;
		sqlc.Parameters.Add("@FechaTerminoSansion",SqlDbType.DateTime, 16 ).Value = fechaterminosansion;
		sqlc.Parameters.Add("@ICodTribunalIngreso",SqlDbType.Int, 4 ).Value = icodtribunalingreso;
		sqlc.Parameters.Add("@DiaDuracion",SqlDbType.Int, 4 ).Value = diaduracion;
		sqlc.Parameters.Add("@DiaDuracionMixta",SqlDbType.Int, 4 ).Value = diaduracionmixta;
		sqlc.Parameters.Add("@CodModeloSancionMixta",SqlDbType.Int, 4 ).Value = codmodelosancionmixta;
		sqlc.Parameters.Add("@Bono",SqlDbType.Int, 4 ).Value = bono;
        sqlc.Parameters.Add("@Horas", SqlDbType.Int, 4).Value = horas;

	 System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
	 DataTable dt = new DataTable();
	 sconn.Open(); 
	 da.Fill(dt); 
	 sconn.Close();
	 return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int callto_insert_tipomedidassanciones2(int icodie, DateTime fechainicio, DateTime fechatermino, int mesduracion, int anoduracion, int codtibunal, int sancionaccesoria, int idusuarioactualizacion, DateTime fechaactualizacion, int codterminosancion, int codregion, int codtipotribunal, int mesduracionmix, int anoduracionmix, DateTime fechaterminomix, DateTime fechainiciomix, DateTime fechaterminosansion, int icodtribunalingreso, int diaduracion, int diaduracionmixta, int codmodelosancionmixta, int bono, int horas, int tsancion, int tipobc, int ipser, int areaTI, int repdaño)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_TipoMedidasSanciones_2";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@MesDuracion", SqlDbType.Int, 4).Value = mesduracion;
        sqlc.Parameters.Add("@AnoDuracion", SqlDbType.Int, 4).Value = anoduracion;
        sqlc.Parameters.Add("@CodTibunal", SqlDbType.Int, 4).Value = codtibunal;
        sqlc.Parameters.Add("@SancionAccesoria", SqlDbType.Int, 4).Value = sancionaccesoria;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@CodTerminoSancion", SqlDbType.Int, 4).Value = codterminosancion;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = codregion;
        sqlc.Parameters.Add("@CodTipoTribunal", SqlDbType.Int, 4).Value = codtipotribunal;
        sqlc.Parameters.Add("@MesDuracionMix", SqlDbType.Int, 4).Value = mesduracionmix;
        sqlc.Parameters.Add("@AnoDuracionMix", SqlDbType.Int, 4).Value = anoduracionmix;
        sqlc.Parameters.Add("@FechaTerminoMix", SqlDbType.DateTime, 16).Value = fechaterminomix;
        sqlc.Parameters.Add("@FechaInicioMix", SqlDbType.DateTime, 16).Value = fechainiciomix;
        sqlc.Parameters.Add("@FechaTerminoSansion", SqlDbType.DateTime, 16).Value = fechaterminosansion;
        sqlc.Parameters.Add("@ICodTribunalIngreso", SqlDbType.Int, 4).Value = icodtribunalingreso;
        sqlc.Parameters.Add("@DiaDuracion", SqlDbType.Int, 4).Value = diaduracion;
        sqlc.Parameters.Add("@DiaDuracionMixta", SqlDbType.Int, 4).Value = diaduracionmixta;
        sqlc.Parameters.Add("@CodModeloSancionMixta", SqlDbType.Int, 4).Value = codmodelosancionmixta;
        sqlc.Parameters.Add("@Bono", SqlDbType.Int, 4).Value = bono;
        sqlc.Parameters.Add("@Horas", SqlDbType.Int, 4).Value = horas;

        sqlc.Parameters.Add("@tsancion", SqlDbType.Int, 4).Value = tsancion;
        sqlc.Parameters.Add("@tipoBC", SqlDbType.Int, 4).Value = tipobc;
        sqlc.Parameters.Add("@ipser", SqlDbType.Int, 4).Value = ipser;
        sqlc.Parameters.Add("@areaTI", SqlDbType.Int, 4).Value = areaTI;
        sqlc.Parameters.Add("@repdaño", SqlDbType.Int, 4).Value = repdaño;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public int callto_insert_tipomedidassanciones2Transaccional(SqlTransaction sqlt, int icodie, DateTime fechainicio, DateTime fechatermino, int mesduracion, int anoduracion, int codtibunal, int sancionaccesoria, int idusuarioactualizacion, DateTime fechaactualizacion, int codterminosancion, int codregion, int codtipotribunal, int mesduracionmix, int anoduracionmix, DateTime fechaterminomix, DateTime fechainiciomix, DateTime fechaterminosansion, int icodtribunalingreso, int diaduracion, int diaduracionmixta, int codmodelosancionmixta, int bono, int horas, int tsancion, int tipobc, int ipser, int areaTI, int repdaño)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_TipoMedidasSanciones_2", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
                
        //sqlc.CommandText = "Insert_TipoMedidasSanciones_2";

        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@MesDuracion", SqlDbType.Int, 4).Value = mesduracion;
        sqlc.Parameters.Add("@AnoDuracion", SqlDbType.Int, 4).Value = anoduracion;
        sqlc.Parameters.Add("@CodTibunal", SqlDbType.Int, 4).Value = codtibunal;
        sqlc.Parameters.Add("@SancionAccesoria", SqlDbType.Int, 4).Value = sancionaccesoria;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@CodTerminoSancion", SqlDbType.Int, 4).Value = codterminosancion;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = codregion;
        sqlc.Parameters.Add("@CodTipoTribunal", SqlDbType.Int, 4).Value = codtipotribunal;
        sqlc.Parameters.Add("@MesDuracionMix", SqlDbType.Int, 4).Value = mesduracionmix;
        sqlc.Parameters.Add("@AnoDuracionMix", SqlDbType.Int, 4).Value = anoduracionmix;
        sqlc.Parameters.Add("@FechaTerminoMix", SqlDbType.DateTime, 16).Value = fechaterminomix;
        sqlc.Parameters.Add("@FechaInicioMix", SqlDbType.DateTime, 16).Value = fechainiciomix;
        sqlc.Parameters.Add("@FechaTerminoSansion", SqlDbType.DateTime, 16).Value = fechaterminosansion;
        sqlc.Parameters.Add("@ICodTribunalIngreso", SqlDbType.Int, 4).Value = icodtribunalingreso;
        sqlc.Parameters.Add("@DiaDuracion", SqlDbType.Int, 4).Value = diaduracion;
        sqlc.Parameters.Add("@DiaDuracionMixta", SqlDbType.Int, 4).Value = diaduracionmixta;
        sqlc.Parameters.Add("@CodModeloSancionMixta", SqlDbType.Int, 4).Value = codmodelosancionmixta;
        sqlc.Parameters.Add("@Bono", SqlDbType.Int, 4).Value = bono;
        sqlc.Parameters.Add("@Horas", SqlDbType.Int, 4).Value = horas;

        sqlc.Parameters.Add("@tsancion", SqlDbType.Int, 4).Value = tsancion;
        sqlc.Parameters.Add("@tipoBC", SqlDbType.Int, 4).Value = tipobc;
        sqlc.Parameters.Add("@ipser", SqlDbType.Int, 4).Value = ipser;
        sqlc.Parameters.Add("@areaTI", SqlDbType.Int, 4).Value = areaTI;
        sqlc.Parameters.Add("@repdaño", SqlDbType.Int, 4).Value = repdaño;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public DataTable callto_insert_tiposancionaccesoria(int codtiposancionaccesoria, int codmedidasancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_TipoSancionAccesoria";
        sqlc.Parameters.Add("@CodTipoSancionAccesoria", SqlDbType.Int, 4).Value = codtiposancionaccesoria;
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_insert_tiposancionaccesoriaTransaccional(SqlTransaction sqlt, int codtiposancionaccesoria, int codmedidasancion)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;

        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_TipoSancionAccesoria";
        sqlc.Parameters.Add("@CodTipoSancionAccesoria", SqlDbType.Int, 4).Value = codtiposancionaccesoria;
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        //sconn.Open();
        da.Fill(dt);
        //sconn.Close();
        return dt;
    }

    public DataTable Insert_NemoTecnicoLRPA(string Codconing, int CodSancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_NemoTecnicoLRPA";
        sqlc.Parameters.Add("@CodSancion", SqlDbType.Int, 4).Value = CodSancion;
        sqlc.Parameters.Add("@Codconing", SqlDbType.VarChar, 4).Value = Codconing;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable callto_update_tipomedidassanciones(int codmedidasancion, int icodie, DateTime fechainicio, DateTime fechatermino, int mesduracion, int anoduracion, int codtibunal, int sancionaccesoria, int idusuarioactualizacion, DateTime fechaactualizacion, int codterminosancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_TipoMedidasSanciones";
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@MesDuracion", SqlDbType.Int, 4).Value = mesduracion;
        sqlc.Parameters.Add("@AnoDuracion", SqlDbType.Int, 4).Value = anoduracion;
        sqlc.Parameters.Add("@CodTibunal", SqlDbType.Int, 4).Value = codtibunal;
        sqlc.Parameters.Add("@SancionAccesoria", SqlDbType.Int, 4).Value = sancionaccesoria;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@CodTerminoSancion", SqlDbType.Int, 4).Value = codterminosancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_update_tiposancionaccesoria(int codtiposancionaccesoria, int codmedidasancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_TipoSancionAccesoria";
        sqlc.Parameters.Add("@CodTipoSancionAccesoria", SqlDbType.Int, 4).Value = codtiposancionaccesoria;
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_update_NemotecnicoLRPA(int CodCondicionIngreso, int CodMedidaSancion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_NemoTecnicoLRPA";
        sqlc.Parameters.Add("@CodCondicionIngreso", SqlDbType.Int, 4).Value = CodCondicionIngreso;
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = CodMedidaSancion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable callto_get_parterminomedidasancion()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parTerminoMedidaSancion";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        //DataRow dr;
        //dr = dt.NewRow();
        //dr[0] = 0;
        //dr[1] = " Seleccionar ";
        //dt.Rows.Add(dr);
        return dt;
    }

    public DataTable callto_get_sancionesbycodmedidasancion(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GET_SANCIONESbyCodMedidaSancion";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_get_proyectoreescolarizacion(int param_codproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ProyectoReescolarizacion";
        sqlc.Parameters.Add("@param_codproyecto", SqlDbType.Int, 4).Value = param_codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_get_proyectoslrpa(int codproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ProyectosLRPA";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;


        
    }
    public DataTable callto_get_ProyectosLRPAxCodProyecto(int CodInstitucion)
    { 
       
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ProyectosLRPAxCodProyecto";
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;


         
    
    }
    public DataTable callto_update_tipomedidassancioneslrpa(int codmedidasancion, DateTime fechainicio, DateTime fechatermino, int mesduracion, int anoduracion, int codtribunal, int sancionaccesoria, int idusuarioactualizacion, DateTime fechaactualizacion, int codterminosancion, int mesduracionmix, int anoduracionmix, DateTime fechaterminomix, DateTime fechainiciomix, DateTime fechaterminosansion, int icodtribunalingreso, int diaduracion, int diaduracionmixta, int codmodelosancionmixta, int Bono,int Horas)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
                    
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_TipoMedidasSancionesLRPA";
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@MesDuracion", SqlDbType.Int, 4).Value = mesduracion;
        sqlc.Parameters.Add("@AnoDuracion", SqlDbType.Int, 4).Value = anoduracion;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = codtribunal;
        sqlc.Parameters.Add("@SancionAccesoria", SqlDbType.Int, 4).Value = sancionaccesoria;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@CodTerminoSancion", SqlDbType.Int, 4).Value = codterminosancion;
        sqlc.Parameters.Add("@MesDuracionMix", SqlDbType.Int, 4).Value = mesduracionmix;
        sqlc.Parameters.Add("@AnoDuracionMix", SqlDbType.Int, 4).Value = anoduracionmix;
        sqlc.Parameters.Add("@FechaTerminoMix", SqlDbType.DateTime, 16).Value = fechaterminomix;
        sqlc.Parameters.Add("@FechaInicioMix", SqlDbType.DateTime, 16).Value = fechainiciomix;
        sqlc.Parameters.Add("@FechaTerminoSansion", SqlDbType.DateTime, 16).Value = fechaterminosansion;
        sqlc.Parameters.Add("@ICodTribunalIngreso", SqlDbType.Int, 4).Value = icodtribunalingreso;
        sqlc.Parameters.Add("@DiaDuracion", SqlDbType.Int, 4).Value = diaduracion;
        sqlc.Parameters.Add("@DiaDuracionMixta", SqlDbType.Int, 4).Value = diaduracionmixta;
        sqlc.Parameters.Add("@CodModeloSancionMixta", SqlDbType.Int, 4).Value = codmodelosancionmixta;
        sqlc.Parameters.Add("@Bono", SqlDbType.Int, 4).Value = Bono;
        sqlc.Parameters.Add("@Horas", SqlDbType.Int, 4).Value = Horas;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_update_tipomedidassancioneslrpa_2(int codmedidasancion, DateTime fechainicio, DateTime fechatermino, int mesduracion, int anoduracion, int codtribunal, int sancionaccesoria, int idusuarioactualizacion, DateTime fechaactualizacion, int codterminosancion, int mesduracionmix, int anoduracionmix, DateTime fechaterminomix, DateTime fechainiciomix, DateTime fechaterminosansion, int icodtribunalingreso, int diaduracion, int diaduracionmixta, int codmodelosancionmixta, int Bono, int Horas, int CodTipoSancion, int CodTipoActividad, int TipoInstitucion, int CodTipoAreaTrabajo, int CodTipoReparacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;

        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_TipoMedidasSancionesLRPA_2";
        sqlc.Parameters.Add("@CodMedidaSancion", SqlDbType.Int, 4).Value = codmedidasancion;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@MesDuracion", SqlDbType.Int, 4).Value = mesduracion;
        sqlc.Parameters.Add("@AnoDuracion", SqlDbType.Int, 4).Value = anoduracion;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = codtribunal;
        sqlc.Parameters.Add("@SancionAccesoria", SqlDbType.Int, 4).Value = sancionaccesoria;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@CodTerminoSancion", SqlDbType.Int, 4).Value = codterminosancion;
        sqlc.Parameters.Add("@MesDuracionMix", SqlDbType.Int, 4).Value = mesduracionmix;
        sqlc.Parameters.Add("@AnoDuracionMix", SqlDbType.Int, 4).Value = anoduracionmix;
        sqlc.Parameters.Add("@FechaTerminoMix", SqlDbType.DateTime, 16).Value = fechaterminomix;
        sqlc.Parameters.Add("@FechaInicioMix", SqlDbType.DateTime, 16).Value = fechainiciomix;
        sqlc.Parameters.Add("@FechaTerminoSansion", SqlDbType.DateTime, 16).Value = fechaterminosansion;
        sqlc.Parameters.Add("@ICodTribunalIngreso", SqlDbType.Int, 4).Value = icodtribunalingreso;
        sqlc.Parameters.Add("@DiaDuracion", SqlDbType.Int, 4).Value = diaduracion;
        sqlc.Parameters.Add("@DiaDuracionMixta", SqlDbType.Int, 4).Value = diaduracionmixta;
        sqlc.Parameters.Add("@CodModeloSancionMixta", SqlDbType.Int, 4).Value = codmodelosancionmixta;
        sqlc.Parameters.Add("@Bono", SqlDbType.Int, 4).Value = Bono;
        sqlc.Parameters.Add("@Horas", SqlDbType.Int, 4).Value = Horas;

        sqlc.Parameters.Add("@CodTipoSancion", SqlDbType.Int, 4).Value = CodTipoSancion;
        sqlc.Parameters.Add("@TipoInstitucion", SqlDbType.Int, 4).Value = TipoInstitucion;
        sqlc.Parameters.Add("@CodTipoActividad", SqlDbType.Int, 4).Value = CodTipoActividad;
        sqlc.Parameters.Add("@CodTipoAreaTrabajo", SqlDbType.Int, 4).Value = CodTipoAreaTrabajo;
        sqlc.Parameters.Add("@CodTipoReparacion", SqlDbType.Int, 4).Value = CodTipoReparacion;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
   
   
    //GetparTipoTribunalLRPA

    public DataTable GetparTipoTribunalLRPA()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoTribunalLRPA, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoTribunal", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoTribunal"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public int Get_LRPAModeloIntervencion(int codproyecto)
    {
         SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
	     System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
	     sqlc.Connection = sconn;
	     sqlc.CommandType = System.Data.CommandType.StoredProcedure;
	     sqlc.CommandText = "Get_ModeloIntervencionLRPA";
		    sqlc.Parameters.Add("@codproyecto",SqlDbType.Int, 4 ).Value = codproyecto;
	     System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
	     DataTable dt = new DataTable();
	     sconn.Open(); 
	     da.Fill(dt); 
	     sconn.Close();
	     return Convert.ToInt32(dt.Rows[0][0]);
    	 
     }

    public int Get_IsLRPA(int codproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select LRPA from parModeloIntervencion pmi inner join Proyectos pry ON pry.CodModeloIntervencion = pmi.CodModeloIntervencion where pry.CodProyecto = @CodProyecto and pmi.IndVigencia = 'V'";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);

    }

    public DataTable callto_update_calidadjuridica_ingresosegresos(int icodie, int codcalidadjuridica)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_CalidadJuridica_IngresosEgresos";
        sqlc.Parameters.Add("@icodie", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@codcalidadjuridica", SqlDbType.Int, 4).Value = codcalidadjuridica;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public int GetCalidadJuridica_IcodIE(int icodie)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetCalidadJuridica_IcodIE + icodie, out datareader);
        int codCalidadJuridica = 0;
        while (datareader.Read())
        {
            try
            {
                codCalidadJuridica = (int)datareader["codcalidadjuridica"];
                
            }
            catch { }
        }
        con.Desconectar();
        return codCalidadJuridica;
     }
    public DataTable GetparTipoCausalIngresoLRPA()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoCausalIngresoLRPA, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("EdadMinima", typeof(int)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoCausalIngreso"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dr[3] = (int)datareader["EdadMinima"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }

    public DataTable GetTipoEgreso_bycod(int codigo)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoEgreso_bycod + codigo.ToString(), out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoEgreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoEgreso"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }

    public DataTable GetparCausalesIngresoPar(string CodTipoCausalIngreso)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = " Select * from parCausalesIngreso where CodTipoCausalIngreso=@pCodTipoCausalIngreso AND IndVigencia = 'V'" + "' AND LRPA = 1";
        listDbParameter.Add(Conexiones.CrearParametro("@pCodTipoCausalIngreso", SqlDbType.Int, 4, Convert.ToInt32(CodTipoCausalIngreso)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion"));//, typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia"));//, typeof(String)));
        dt.Columns.Add(new DataColumn("CodNumCausal"));//, typeof(String)));



        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCausalIngreso"];
                dr[1] = (int)datareader["CodTipoCausalIngreso"];
                if ((int)datareader["CodNumCausal"] > 0)
                {
                    dr[2] = "(" + Convert.ToString((int)datareader["CodNumCausal"]) + ") " + (String)datareader["Descripcion"].ToString().ToUpper();
                }
                else
                {
                    dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                }
                dr[3] = (String)datareader["IndVigencia"];
                dr[1] = (int)datareader["CodNumCausal"];


                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable callto_update_calidadjuridica_ingresos_CalidadJuridica(int icodie, int codcalidadjuridica, DateTime FechaCambio, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_CalidadJuridica_Ingresos_CalidadJuridica";
        sqlc.Parameters.Add("@icodie", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@codcalidadjuridica", SqlDbType.Int, 4).Value = codcalidadjuridica;
        sqlc.Parameters.Add("@fechacambio", SqlDbType.DateTime).Value = FechaCambio;
        sqlc.Parameters.Add("@fechaactualizacion", SqlDbType.DateTime).Value = FechaActualizacion;
        sqlc.Parameters.Add("@idusuarioactualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    
    
   

}
