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
using System.Data.Common;
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Descripción breve de coordinador
/// </summary>
public class coordinador
{
	public coordinador()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
    }
    

    #region Historicos

    public DataTable callto_historico_ninos_coordinacion_audiencia(int CodNino, string ruc)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "historico_ninos_coordinacion_audiencia";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar, 255).Value = ruc;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable callto_get_coordinacionninoingresorep(int codnino, int codproyecto, string ruc,DateTime FechaDerivacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_CoordinacionNinoIngresoRep";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar, 50).Value = ruc;
        sqlc.Parameters.Add("@FechaDerivacion", SqlDbType.DateTime,16).Value = FechaDerivacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable callto_historico_coordinadores_modifica(int codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "historico_coordinadores_modifica";
        sqlc.Parameters.Add("@codnino", SqlDbType.Int, 4).Value = codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable callto_historico_cierrecausa(int codnino,string ruc)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Historico_CierreCausa";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@Ruc", SqlDbType.VarChar, 50).Value = ruc;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable callto_historico_ninos_coordinacion(int codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "historico_ninos_coordinacion";
        sqlc.Parameters.Add("@codnino", SqlDbType.Int, 4).Value = codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    #endregion

    public DataTable ejecuta_SQL(string sql, List<DbParameter> listDbParameter) 
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = sql;
        if (listDbParameter != null)
            foreach (DbParameter dbParameter in listDbParameter)
                sqlc.Parameters.Add(dbParameter);

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable consulta_rol(int userid)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        String sql = "Select * from usuarios where IdUsuario =" + userid;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDireccionRegional", typeof(int)));
        dt.Columns.Add(new DataColumn("Contrasena", typeof(String)));
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDireccionRegional"];
                dr[1] = (String)datareader["Contrasena"];
                dr[2] = (int)datareader["CodRegion"];
                dr[3] = (int)datareader["ICodTrabajador"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }//GetOrdenTribunalCoor
    

    #region INSERT_COORDINACION
    
    public DataTable callto_insert_coordinacionaudiencia(int ICodOrdenTribunal, int codtipoaudiencia, string Observacion, DateTime fechaaudiencia, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CoordinacionAudiencia";
       // sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
        sqlc.Parameters.Add("@CodTipoAudiencia", SqlDbType.Int, 4).Value = codtipoaudiencia;
        sqlc.Parameters.Add("@Observacion", SqlDbType.VarChar, 300).Value = Observacion;
        sqlc.Parameters.Add("@FechaAudiencia", SqlDbType.DateTime, 16).Value = fechaaudiencia;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
   
    public DataTable callto_insert_coordinacioncausalingreso(int codcausalingreso, int codnumcausal, int icodordentribunal, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CoordinacionCausalIngreso";
        //sqlc.Parameters.Add("@ICodCausalIngreso", SqlDbType.Int, 4).Value = ICodCausalIngreso;
        sqlc.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = codcausalingreso;
        sqlc.Parameters.Add("@CodNumCausal", SqlDbType.Int, 4).Value = codnumcausal;
        sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = icodordentribunal;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable callto_insert_coordinacioningreso(int IcodOrdenTribunal, int CodResolucionTribunal, int codnino, int codproyecto, DateTime fechaderivacion, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CoordinacionIngreso";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = codnino;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@FechaDerivacion", SqlDbType.DateTime, 16).Value = fechaderivacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IcodOrdenTribunal", SqlDbType.Int, 4).Value = IcodOrdenTribunal;
        sqlc.Parameters.Add("@CodResolucionTribunal", SqlDbType.Int, 4).Value = CodResolucionTribunal;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public DataTable callto_insert_coordinacionordentribunal(int codtribunal, string ruc, string rit, DateTime fechaorden, int sentenciaejecutoriada, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CoordinacionOrdenTribunal";
       // sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = codtribunal;
        sqlc.Parameters.Add("@RUC", SqlDbType.VarChar, 50).Value = ruc;
        sqlc.Parameters.Add("@RIT", SqlDbType.VarChar, 50).Value = rit;
        sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime, 16).Value = fechaorden;
        sqlc.Parameters.Add("@SentenciaEjecutoriada", SqlDbType.Bit, 1).Value = sentenciaejecutoriada;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }




    public DataTable callto_insert_coordinacionsancionaccesoria(int CodTipoSancionAccesoria, int CodSancion)
    { 
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CoordinacionSancionAccesoria";
        sqlc.Parameters.Add("CodSancion", SqlDbType.Int, 4).Value = CodSancion;
        sqlc.Parameters.Add("CodTipoSancionAccesoria", SqlDbType.Int, 4).Value = CodTipoSancionAccesoria;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);////SANCION REVISAR DATATABLE
        sconn.Close();
        return dt;
    }
    
    


    public DataTable callto_insert_coordinacionsancion(int ICodOrdenTribunal, DateTime fechainicio, DateTime fechatermino, int DuracionAno, int DuracionMes, int DuracionDia,
                                                        int CodTribunal, int SancionAccesoria, int abono, int horas,DateTime FechaInicioMixta, DateTime FechaTerminoMixta, 
                                                        int DuracionAnoMixta, int DuracionMesMixta, int DuracionDiaMixta, int CodTerminoSancion, DateTime FechaTerminoSancion, 
                                                        int CodModeloSancionMixta, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_CoordinacionSancion";
        //sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@DuracionAno", SqlDbType.Int, 4).Value = DuracionAno;
        sqlc.Parameters.Add("@DuracionMes", SqlDbType.Int, 4).Value = DuracionMes;
        sqlc.Parameters.Add("@DuracionDia", SqlDbType.Int, 4).Value = DuracionDia;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = CodTribunal;
        sqlc.Parameters.Add("@SancionAccesoria", SqlDbType.Int, 4).Value = SancionAccesoria;
        sqlc.Parameters.Add("@Abono", SqlDbType.Int, 4).Value = abono;
        sqlc.Parameters.Add("@Horas", SqlDbType.Int, 4).Value = horas;
        sqlc.Parameters.Add("@FechaInicioMixta", SqlDbType.DateTime, 16).Value = FechaInicioMixta;
        sqlc.Parameters.Add("@FechaTerminoMixta", SqlDbType.DateTime, 16).Value = FechaTerminoMixta;
        sqlc.Parameters.Add("@DuracionAnoMixta", SqlDbType.Int, 4).Value = DuracionAnoMixta;
        sqlc.Parameters.Add("@DuracionMesMixta", SqlDbType.Int, 4).Value = DuracionMesMixta;
        sqlc.Parameters.Add("@DuracionDiaMixta", SqlDbType.Int, 4).Value = DuracionDiaMixta;
        sqlc.Parameters.Add("@CodTerminoSancion", SqlDbType.Int, 4).Value = CodTerminoSancion;
        sqlc.Parameters.Add("@FechaTerminoSancion", SqlDbType.DateTime, 16).Value = FechaTerminoSancion;
        sqlc.Parameters.Add("@CodModeloSancionMixta", SqlDbType.Int, 4).Value = CodModeloSancionMixta;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;  //20
        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    #endregion

    #region GET_COORDINACION

        public DataTable Get_RegionByUsers(string ConsultaUser)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(ConsultaUser, out datareader);
        DataTable dt = new DataTable();

        DataRow dr;

        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));
       



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodRegion"];
               

                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

        public DataTable Get_ProyectosLRPA(string Consulta)
    {
        
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
            con.ejecutar(Consulta, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));

            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = " Seleccionar";
            dt.Rows.Add(dr);
            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodProyecto"];
                    dr[1] = (String)datareader["Nombre"];
                   
                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        
    }

    public DataTable GetInsCordinador()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetInsCordinador, out datareader);
        DataTable dt = new DataTable();
       

        DataRow dr;

        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstitucion"];
                dr[1] = (String)datareader["Nombre"];

                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable callto_insert_MedidasInvestigacion(int IcodOrdenTribunal, DateTime FechaInicio, DateTime FechaTermino, int DuracionDia, int PlazoInvestigacion, DateTime FechaPlazoInvestigacion, int idusuarioactualizacion, DateTime fechaactualizacion) //int sentenciaejecutoriada, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_MedidasInvestigacion";
        sqlc.Parameters.Add("@IcodOrdenTribunal", SqlDbType.Int, 4).Value = IcodOrdenTribunal;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = FechaTermino;
        sqlc.Parameters.Add("@DuracionDia", SqlDbType.Int, 4).Value = DuracionDia;
        sqlc.Parameters.Add("@PlazoInvestigacion", SqlDbType.Int, 4).Value = PlazoInvestigacion;
        sqlc.Parameters.Add("@FechaPlazoInvestigacion", SqlDbType.DateTime, 16).Value = FechaPlazoInvestigacion;
        sqlc.Parameters.Add("@idusuarioactualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@fechaactualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_insert_CoordinacionAmpliaInvestigacion(int CodSancion, int Dias, DateTime FechaActualizacion, int idusuarioactualizacion) //int sentenciaejecutoriada, int idusuarioactualizacion, DateTime fechaactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_AmpliaInvestigacion";
        sqlc.Parameters.Add("@CodSancion", SqlDbType.Int, 4).Value = CodSancion;
        sqlc.Parameters.Add("@Dias", SqlDbType.Int, 4).Value = Dias;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = FechaActualizacion;
        sqlc.Parameters.Add("@idusuarioactualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;


        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable GetCodRegionUser(int codusuario)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar("select icodtrabajador, codregion from Usuarios where idusuario ="+ codusuario, out datareader);
        DataTable dt02 = new DataTable();


        DataRow dr;

        dt02.Columns.Add(new DataColumn("icodtrabajador", typeof(int)));
        dt02.Columns.Add(new DataColumn("codregion", typeof(int)));
       

        //dr = dt02.NewRow();
        //dr[0] = "0";
        //dr[1] = " Seleccionar";
        //dt02.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt02.NewRow();
                dr[0] = (int)datareader["icodtrabajador"];
                dr[1] = (int)datareader["codregion"];

                dt02.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt02;

    }


    public DataTable GetParMedida()
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar("Select * from parmodelointervencion where lrpa >= 1", out datareader);
        DataTable dt03 = new DataTable();


        DataRow dr;

        dt03.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int)));
        dt03.Columns.Add(new DataColumn("Descripcion", typeof(String)));

        dr = dt03.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt03.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt03.NewRow();
                dr[0] = (int)datareader["CodModeloIntervencion"];
                dr[1] = (String)datareader["Descripcion"];

                dt03.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt03;

    }

    public DataTable getexcelcordina(int UserId, int CodInstitucion,int CodProyecto, int Medida, int Media, DateTime FechaInicio, DateTime FechaTermino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Nomina_Coordinadores";
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = UserId;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@Medida", SqlDbType.Int, 4).Value = Medida;
        sqlc.Parameters.Add("@Medio", SqlDbType.Int, 4).Value = Media;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 8).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 8).Value = FechaTermino;
      
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable getCertificadoI(int UserId, int CodInstitucion, int CodProyecto, int Medida, int Media, DateTime FechaInicio, DateTime FechaTermino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_CertificadoIngreso";
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = UserId;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@Medida", SqlDbType.Int, 4).Value = Medida;
        sqlc.Parameters.Add("@Medio", SqlDbType.Int, 4).Value = Media;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 8).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 8).Value = FechaTermino;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }




    public DataTable GetProyCor(int codinst, int codregion)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar("SELECT     Nombre, CodProyecto FROM Proyectos WHERE CodCausalTerminoProyecto = 20084 AND IndVigencia = 'v' AND CodRegion ='"+codregion+"' AND CodInstitucion ="+codinst, out datareader);
        DataTable dt03 = new DataTable();


        DataRow dr;

        dt03.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt03.Columns.Add(new DataColumn("Nombre", typeof(String)));

        dr = dt03.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt03.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt03.NewRow();
                dr[0] = (int)datareader["CodProyecto"];
                dr[1] = (String)datareader["Nombre"];

                dt03.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt03;

    }




    public DataTable callto_get_coordinacionaudiencia(int ICodOrdenTribunal)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_CoordinacionAudiencia";
        sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_get_coordinacionsancion(int ICodOrdenTribunal)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_CoordinacionSancion";
        sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_get_coordinacioncausalingreso(int ICodOrdenTribunal)
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Get_CoordinacionCausalIngreso";
            sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();
            return dt;
        }

        public DataTable callto_getparresoluciontribunal()
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
            con.ejecutarProcedimiento("GetparResolucionTribunal", out datareader);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("CodResolucionTribunal", typeof(int)));
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
                    dr[0] = (int)datareader["CodResolucionTribunal"];
                    dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                    dr[2] = (String)datareader["IndVigencia"];
                  
                    dt.Rows.Add(dr);
                }
                catch { }
            }
            con.Desconectar();
            return dt;

        
        }

    public DataTable callto_get_coordinacioningreso(int @ICodIngreso)
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Get_CoordinacionIngreso";
            sqlc.Parameters.Add("@ICodIngreso", SqlDbType.Int, 4).Value = ICodIngreso;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();
            return dt;
        }

    public DataTable callto_get_coordinacionordentribunal(int ICodOrdenTribunal)
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Get_CoordinacionOrdenTribunal";
            sqlc.Parameters.Add("@ICodOrdenTribunal", SqlDbType.Int, 4).Value = ICodOrdenTribunal;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();
            return dt;
        }

    public DataTable callto_getOrdenTribunalCoor()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        //con.ejecutarProcedimiento("GetparResolucionTribunal", out datareader);
        con.ejecutar(Resources.Procedures.GetOrdenTribunalCoor, out datareader);
            
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ruc", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("rucdescripcion", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[2] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["ruc"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = "("+(String)datareader["ruc"].ToString().ToUpper()+")"+" "+(String)datareader["Descripcion"].ToString().ToUpper();
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }

    #endregion
    
    #region UPDATE_COORDINACION //modificada FOP
        
        public DataTable callto_update_coordinacioningreso(/*int icodie,*/int IcodIngreso,int ICodOrdentribunal,int CodNino
            ,int CodProyecto, int CodResolucionTribunal, DateTime fechaderivacion, int idusuarioactualizacion, DateTime fechaactualizacion)
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "UPDATE_CoordinacionIngreso";
            sqlc.Parameters.Add("@IcodIngreso", SqlDbType.Int, 4).Value = IcodIngreso;
            sqlc.Parameters.Add("@ICodOrdentribunal", SqlDbType.Int, 4).Value = ICodOrdentribunal;
            sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
            sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
            sqlc.Parameters.Add("@CodResolucionTribunal", SqlDbType.Int, 4).Value = CodResolucionTribunal;
            sqlc.Parameters.Add("@FechaDerivacion", SqlDbType.DateTime, 16).Value = fechaderivacion;
            sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
            sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();
            return dt;
        }
    
    #endregion


    }
