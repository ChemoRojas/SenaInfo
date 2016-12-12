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
/// Summary description for proyectocoll
/// </summary>
public class proyectocoll
{
	public proyectocoll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string SQL_Proyecto(int CodInstitucion)
    {
        string tsql = string.Empty;
        tsql = "SELECT DISTINCT * FROM Proyectos  where EstadoProyecto=1 and CodInstitucion = " + CodInstitucion.ToString() + "   order by nombre";

        return tsql;
    }

    private string SQL_Proyecto_C(int CodInstitucion)
    {
        string tsql = string.Empty;
        tsql = "SELECT DISTINCT * FROM Proyectos  where EstadoProyecto = 1 and IndVigencia = 'C'AND CodInstitucion = " + CodInstitucion.ToString() + "   order by nombre";

        return tsql;
    }

    private string SQL_Proyecto_V(int CodInstitucion)
    {
        string tsql = string.Empty;
        tsql = "SELECT DISTINCT * FROM Proyectos  where EstadoProyecto = 1 and IndVigencia = 'V'AND CodInstitucion = " + CodInstitucion.ToString() + "   order by nombre";

        return tsql;
    }




    public DataTable GetData(int CodInstitucion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };



        con.ejecutar(SQL_Proyecto(CodInstitucion), out datareader);


        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Codigo Proyecto"));
        dt.Columns.Add(new DataColumn("Nombre"));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = "(" + datareader["IndVigencia"].ToString() + ")(" + ((System.Int32)datareader["CodProyecto"]).ToString() + ") " + (System.String)datareader["Nombre"];
                //dr[1] = "(" + ((System.Int32)datareader["CodProyecto"]).ToString() + ") " + (System.String)datareader["Nombre"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetData(int userid, int codinstitucion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[15] = " Seleccionar";
        dt.Rows.Add(dr);

        return dt;
    }

    public DataTable GetData(int userid, string indvigencia, int codinstitucion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_byuserid2";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[15] = " Seleccionar";
        
        dt.Rows.Add(dr);

        return dt;
    }

    public DataTable GetDataII(int userid, string indvigencia, int codinstitucion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_byuserid4";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[15] = " Seleccionar";

        dt.Rows.Add(dr);

        return dt;
    }

    public DataTable GetData(int CodInstitucion, Boolean estado)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };

        if (estado == true)
        {

            con.ejecutar(SQL_Proyecto_C(CodInstitucion), out datareader);
        }
        else 
        {
            con.ejecutar(SQL_Proyecto_V(CodInstitucion), out datareader);
        }

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Codigo Proyecto"));
        dt.Columns.Add(new DataColumn("Nombre"));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = "(" + datareader["IndVigencia"].ToString() + ")("  +((System.Int32)datareader["CodProyecto"]).ToString() + ") " + (System.String)datareader["Nombre"];
                //dr[1] = "(" + ((System.Int32)datareader["CodProyecto"]).ToString() + ") " + (System.String)datareader["Nombre"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public string GetCodSistemaAsistencialDesc( int CodSistema)
    {
        string Desc = "";
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        string sql = "Select Descripcion from parSistemaASistencial Where Codsistemaasistencial = " + CodSistema;
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                Desc = (String)datareader["Descripcion"];
            }
            catch { }
        }
        con.Desconectar();
        return Desc;
    }

    public DataTable GetProyectos(string CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetProyectos";
        sqlc.Parameters.Add("@CodProyeto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    //public DataTable GetProyectos( string CodProyecto)
    //{
    //    DbDataReader datareader = null;
    //    /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
    //    List<DbParameter> listDbParameter = new List<DbParameter>();

    //    string sql = Resources.Procedures.GetProyectos + "@pCodProyecto";

    //    listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodProyecto)));

    //    con.ejecutar(sql, listDbParameter, out datareader);
    //    DataTable dt = new DataTable();
    //    DataRow dr;
    //    dt.Columns.Add(new DataColumn("CodProyecto", typeof(int))); //0
    //    dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int))); //1
    //    dt.Columns.Add(new DataColumn("CodRegion", typeof(int))); //2
    //    dt.Columns.Add(new DataColumn("CodComuna", typeof(int))); //3
    //    dt.Columns.Add(new DataColumn("Localidad", typeof(String))); //4
    //    dt.Columns.Add(new DataColumn("TipoProyecto", typeof(int))); //5
    //    dt.Columns.Add(new DataColumn("TipoSubvencion", typeof(int))); //6
    //    dt.Columns.Add(new DataColumn("CodTipoAtencion", typeof(int))); //7
    //    dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int))); //8
    //    dt.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int))); //9
    //    dt.Columns.Add(new DataColumn("CodSistemaAsistencial", typeof(int)));//10
    //    dt.Columns.Add(new DataColumn("CodDepartamentosSENAME", typeof(int))); //11
    //    dt.Columns.Add(new DataColumn("CodCausalTerminoProyecto", typeof(int))); //12
    //    dt.Columns.Add(new DataColumn("CodInstitucionOrigen", typeof(int)));  //13
    //    dt.Columns.Add(new DataColumn("CodProyectoOrigen", typeof(int))); //14
    //    dt.Columns.Add(new DataColumn("Nombre", typeof(String))); //15
    //    dt.Columns.Add(new DataColumn("NombreCorto", typeof(String))); //16
    //    dt.Columns.Add(new DataColumn("RutNumeroProyecto", typeof(String))); //17
    //    dt.Columns.Add(new DataColumn("Direccion", typeof(String))); //18
    //    dt.Columns.Add(new DataColumn("Telefono", typeof(String))); //29
    //    dt.Columns.Add(new DataColumn("Mail", typeof(String))); //20
    //    dt.Columns.Add(new DataColumn("Fax", typeof(String))); //21
    //  //  dt.Columns.Add(new DataColumn("CodigoPostal", typeof(int)));
    //    dt.Columns.Add(new DataColumn("Director", typeof(String)));  //22
    //    dt.Columns.Add(new DataColumn("RutDirector", typeof(String)));  //23
    //    dt.Columns.Add(new DataColumn("FechaAniversario", typeof(String))); //24
    //    dt.Columns.Add(new DataColumn("EdadMaximaPermanencia", typeof(int))); //25
    //    dt.Columns.Add(new DataColumn("CodBanco", typeof(int))); //26
    //    dt.Columns.Add(new DataColumn("CuentaCorrienteNumero", typeof(String))); //27
    //    dt.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime))); //28
    //    dt.Columns.Add(new DataColumn("EdadMinima", typeof(int)));  //29
    //    dt.Columns.Add(new DataColumn("EdadMaximaIngreso", typeof(int)));  //30
    //    dt.Columns.Add(new DataColumn("Etapas", typeof(int))); //31
    //    dt.Columns.Add(new DataColumn("MontoInversion", typeof(int))); //32
    //    dt.Columns.Add(new DataColumn("MontoOperacion", typeof(int))); //33
    //    dt.Columns.Add(new DataColumn("MontoPersonal", typeof(int)));  //34
    //    dt.Columns.Add(new DataColumn("IdUsuarioTecnico", typeof(int)));  //35
    //    dt.Columns.Add(new DataColumn("IndVigencia", typeof(String))); //36
    //    dt.Columns.Add(new DataColumn("FechaCreacion", typeof(DateTime))); //37
    //    dt.Columns.Add(new DataColumn("ProyectoDeContinuacion", typeof(bool))); //38
    //    dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime))); //39
    //    dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int))); //40
    //    dt.Columns.Add(new DataColumn("EstadoProyecto", typeof(int))); //41
    //    dt.Columns.Add(new DataColumn("NumeroPlazas", typeof(int))); //42
    //    dt.Columns.Add(new DataColumn("FactorZona", typeof(int)));  //43
    //    dt.Columns.Add(new DataColumn("FatorEdad", typeof(int))); //44
    //    dt.Columns.Add(new DataColumn("FactorCobertura", typeof(int))); //45
    //    dt.Columns.Add(new DataColumn("FactorDiscapacidad", typeof(int))); //46
    //    dt.Columns.Add(new DataColumn("FactorComplejidad", typeof(int))); //47
    //    dt.Columns.Add(new DataColumn("FactorVF", typeof(int))); //48
    //    dt.Columns.Add(new DataColumn("CalidadVidaFamiliar", typeof(int))); //49
        
       
    //    while (datareader.Read())
    //    {
    //        try
    //        {
    //            dr = dt.NewRow();
    //            dr[0] = (int)datareader["CodProyecto"];
    //            dr[1] = (int)datareader["CodInstitucion"];
    //            dr[2] = (int)datareader["CodRegion"];
    //            dr[3] = (int)datareader["CodComuna"];
    //            dr[4] = (String)datareader["Localidad"];
    //            dr[5] = (int)datareader["TipoProyecto"];
    //            dr[6] = (int)datareader["TipoSubvencion"];
    //            dr[7] = (int)datareader["CodTipoAtencion"];
    //            dr[8] = (int)datareader["CodTematicaProyecto"];
    //            dr[9] = (int)datareader["CodModeloIntervencion"];
    //            dr[10] = (int)datareader["CodSistemaAsistencial"];
    //            dr[11] = (int)datareader["CodDepartamentosSENAME"];
    //            dr[12] = (int)datareader["CodCausalTerminoProyecto"];
    //            dr[13] = (int)datareader["CodInstitucionOrigen"];
    //            dr[14] = (int)datareader["CodProyectoOrigen"];
    //            dr[15] = (String)datareader["Nombre"];
    //            dr[16] = (String)datareader["NombreCorto"];
    //            dr[17] = (String)datareader["RutNumeroProyecto"];
    //            dr[18] = (String)datareader["Direccion"];
    //            dr[19] = (String)datareader["Telefono"];
    //            dr[20] = (String)datareader["Mail"];
    //            dr[21] = (String)datareader["Fax"];
    //           // dr[22] = (int)datareader["CodigoPostal"];
    //            dr[22] = (String)datareader["Director"];
    //            dr[23] = (String)datareader["RutDirector"];
    //            dr[24] = (String)datareader["FechaAniversario"];
    //            dr[25] = (int)datareader["EdadMaximaPermanencia"];
    //            dr[26] = (int)datareader["CodBanco"];
    //            dr[27] = (String)datareader["CuentaCorrienteNumero"];
    //            try
    //            {
    //                dr[28] = (DateTime)datareader["FechaTermino"];
    //            }
    //            catch
    //            {
    //                dr[28] = Convert.ToDateTime("01-01-1900");
    //            }
    //            dr[29] = (int)datareader["EdadMinima"];
    //            dr[30] = (int)datareader["EdadMaximaIngreso"];
    //            dr[31] = (int)datareader["Etapas"];
    //            dr[32] = (int)datareader["MontoInversion"];
    //            dr[33] = (int)datareader["MontoOperacion"];
    //            dr[34] = (int)datareader["MontoPersonal"];
    //            dr[35] = (int)datareader["IdUsuarioTecnico"];
    //            dr[36] = (String)datareader["IndVigencia"];
    //            dr[37] = (DateTime)datareader["FechaCreacion"];
    //            dr[38] = (bool)datareader["ProyectoDeContinuacion"];
    //            dr[39] = (DateTime)datareader["FechaActualizacion"];
    //            dr[40] = (int)datareader["IdUsuarioActualizacion"];
    //            dr[41] = (int)datareader["EstadoProyecto"];
    //            dr[42] = (int)datareader["CalidadVidaFamiliar"];
    //            dr[43] = (int)datareader["NumeroPlazas"];

    //            dt.Rows.Add(dr);
    //        }
    //        catch { }
    //    }
    //    con.Desconectar();
    //    return dt;
    //}



    public DataTable GetProyectos2(int CodProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetProyectos2";
        sqlc.Parameters.Add("@CodProyeto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }

    //Felipe Ormazabal

    //MOdificacion a busqued de institucion por estado de proyecto.

    private string SQL_Proyecto(int CodInstitucion, int EstadoProyecto)
    {
        string tsql = string.Empty;
        tsql = "SELECT DISTINCT * FROM Proyectos  where CodInstitucion = " + CodInstitucion.ToString() + " AND EstadoProyecto =" + EstadoProyecto.ToString() + " AND IndVigencia = 'V'  order by nombre";

        return tsql;
    }

  
    public DataTable GetProyectoEstado(int userid, string indvigencia, int codinstitucion, int estadoproyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_byuserid3";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@EstadoProyecto", SqlDbType.Int, 4).Value = estadoproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[15] = " Seleccionar";

        dt.Rows.Add(dr);
        return dt;
    }
    public int GetLRPA_ModeloIntervencion(int codmodelointervencion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetLRPA_ModeloIntervencion + codmodelointervencion, out datareader);
        int LRPA = 0; 
        while (datareader.Read())
        {
            try
            {
                LRPA = (int)datareader["LRPA"];
            }
            catch { }
        }
        con.Desconectar();
        return LRPA;

    
    }
    //Felipe Ormazabal
    public DataTable GetProyectoxInst(int CodInstitucion)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetProyectosxInst + CodInstitucion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCorto", typeof(String)));

        dr = dt.NewRow();
        dr[2] = "Seleccionar";
        dr[0] = "0";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodProyecto"];
                dr[1] = (int)datareader["CodInstitucion"];
                dr[2] = "(" + ((int)datareader["CodProyecto"]).ToString() + ") " + (String)datareader["Nombre"];
                dr[3] = (String)datareader["NombreCorto"];
                
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetInmuebletodos()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetInmuebletodos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodsituacionLegalInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Direccion", typeof(String)));
        dt.Columns.Add(new DataColumn("Telefono", typeof(String)));
        dt.Columns.Add(new DataColumn("Fax", typeof(String)));
        dt.Columns.Add(new DataColumn("CodigoPostal", typeof(int)));
        dt.Columns.Add(new DataColumn("m2Construidos", typeof(int)));
        dt.Columns.Add(new DataColumn("m2totales", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroDormitorios", typeof(int)));
        dt.Columns.Add(new DataColumn("CapacidadNinos", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroBanos", typeof(int)));
        dt.Columns.Add(new DataColumn("CantidadPisos", typeof(int)));
        dt.Columns.Add(new DataColumn("AreasVerdes", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodInmueble"];
                dr[1] = (int)datareader["CodInstitucion"];
                dr[2] = (int)datareader["CodInmueble"];
                dr[3] = (int)datareader["IdUsuarioActualizacion"];
                dr[4] = (int)datareader["CodsituacionLegalInmueble"];
                dr[5] = (int)datareader["CodComuna"];
                dr[6] = (int)datareader["TipoInmueble"];
                dr[7] = (String)datareader["Nombre"];
                dr[8] = (String)datareader["Direccion"];
                dr[9] = (String)datareader["Telefono"];
                dr[10] = (String)datareader["Fax"];
                dr[11] = (int)datareader["CodigoPostal"];
                dr[12] = (int)datareader["m2Construidos"];
                dr[13] = (int)datareader["m2totales"];
                dr[14] = (int)datareader["NumeroDormitorios"];
                dr[15] = (int)datareader["CapacidadNinos"];
                dr[16] = (int)datareader["NumeroBanos"];
                dr[17] = (int)datareader["CantidadPisos"];
                dr[18] = (String)datareader["AreasVerdes"];
                dr[19] = (String)datareader["IndVigencia"];
                dr[20] = (DateTime)datareader["FechaActualizacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable Get_FactoresLey_20032(int CodModeloIntervencion,int NumeroPlazas,int CodComuna,int CalidadVF)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
            con.parametros("@CodModeloIntervencion",SqlDbType.Int,4,CodModeloIntervencion),
            con.parametros("@NumeroPlazas",SqlDbType.Int,4,NumeroPlazas),
            con.parametros("@CodComuna",SqlDbType.Int,4,CodComuna),
            con.parametros("@CalidadVidaFamiliar",SqlDbType.Int,4,CalidadVF) };
        con.ejecutarProcedimiento("Get_FactoresLey20032_xModelo", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("FactorFijo", typeof(double))); //0
        dt.Columns.Add(new DataColumn("FactorCobertura", typeof(double))); //1
        dt.Columns.Add(new DataColumn("FactorCVF", typeof(double))); //2
        dt.Columns.Add(new DataColumn("PorcentajeAsignacionNL", typeof(int))); //3
        dt.Columns.Add(new DataColumn("FactorVariable", typeof(double)));//4
        dt.Columns.Add(new DataColumn("FactorEdad", typeof(double)));//5
        dt.Columns.Add(new DataColumn("FactorComplejidad", typeof(double)));//6
        dt.Columns.Add(new DataColumn("FactorDiscapacidad", typeof(double)));//7
        dt.Columns.Add(new DataColumn("IntervencionesExigidas", typeof(int)));//8
        dt.Columns.Add(new DataColumn("USS", typeof(double)));//9
        dt.Columns.Add(new DataColumn("FactorReajusteUSS", typeof(double)));//10
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (double)datareader["FactorFijo"];
                dr[1] = (double)datareader["FactorCobertura"];
                dr[2] = (double)datareader["FactorCVF"];
                dr[3] = (int)datareader["PorcentajeAsignacionNL"];
                dr[4] = (double)datareader["FactorVariable"];
                dr[5] = (double)datareader["FactorEdad"];
                dr[6] = (double)datareader["FactorComplejidad"];
                dr[7] = (double)datareader["FactorDiscapacidad"];
                dr[8] = (int)datareader["IntervencionesExigidas"];
                dr[9] = (double)datareader["USS"];
                dr[10] = (double)datareader["FactorReajusteUSS"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    }
   public int Insert_Proyectos(
int CodProyecto, int CodInstitucion, int CodRegion, int CodComuna, String Localidad, int TipoProyecto, int TipoSubvencion, int CodTipoAtencion, int CodTematicaProyecto, int CodModeloIntervencion, int CodSistemaAsistencial, int CodDepartamentosSENAME, int CodCausalTerminoProyecto, int CodInstitucionOrigen, int CodProyectoOrigen, String Nombre, String NombreCorto, String RutNumeroProyecto, String Direccion, String Telefono, String Mail, String Fax, int CalidadVidaFamiliar, String Director, String RutDirector, String FechaAniversario, int EdadMaximaPermanencia, int CodBanco, String CuentaCorrienteNumero, DateTime FechaTermino, int EdadMinima, int EdadMaximaIngreso, int Etapas, int MontoInversion, int MontoOperacion, int MontoPersonal, int IdUsuarioTecnico, String IndVigencia, DateTime FechaCreacion, bool ProyectoDeContinuacion, DateTime FechaActualizacion, int IdUsuarioActualizacion, int EstadoProyecto, int NumeroPlazas)
    {

        object objFechaTermino = DBNull.Value;
        if (FechaTermino != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaTermino = FechaTermino;
        };
        
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodRegion", SqlDbType.Int, 4, CodRegion) , 
		con.parametros("@CodComuna", SqlDbType.Int, 4, CodComuna) , 
		con.parametros("@Localidad", SqlDbType.VarChar, 30,Localidad) , 
		con.parametros("@TipoProyecto", SqlDbType.Int, 4, TipoProyecto) , 
		con.parametros("@TipoSubvencion", SqlDbType.Int, 4, TipoSubvencion) , 
		con.parametros("@CodTipoAtencion", SqlDbType.Int, 4, CodTipoAtencion) , 
		con.parametros("@CodTematicaProyecto", SqlDbType.Int, 4, CodTematicaProyecto) , 
		con.parametros("@CodModeloIntervencion", SqlDbType.Int, 4, CodModeloIntervencion) , 
		con.parametros("@CodSistemaAsistencial", SqlDbType.Int, 4, CodSistemaAsistencial) , 
		con.parametros("@CodDepartamentosSENAME", SqlDbType.Int, 4, CodDepartamentosSENAME) , 
		con.parametros("@CodCausalTerminoProyecto", SqlDbType.Int, 4, CodCausalTerminoProyecto) , 
		con.parametros("@CodInstitucionOrigen", SqlDbType.Int, 4, CodInstitucionOrigen) , 
		con.parametros("@CodProyectoOrigen", SqlDbType.Int, 4, CodProyectoOrigen) , 
		con.parametros("@Nombre", SqlDbType.VarChar, 100, Nombre) , 
		con.parametros("@NombreCorto", SqlDbType.VarChar, 50, NombreCorto) , 
		con.parametros("@RutNumeroProyecto", SqlDbType.VarChar, 11, RutNumeroProyecto) , 
		con.parametros("@Direccion", SqlDbType.VarChar, 100, Direccion) , 
		con.parametros("@Telefono", SqlDbType.VarChar, 30, Telefono) , 
		con.parametros("@Mail", SqlDbType.VarChar, 50, Mail) , 
		con.parametros("@Fax", SqlDbType.VarChar, 30, Fax) , 
		con.parametros("@CalidadVidaFamiliar", SqlDbType.Int, 4, CalidadVidaFamiliar) , 
		con.parametros("@Director", SqlDbType.VarChar, 50, Director) , 
		con.parametros("@RutDirector", SqlDbType.VarChar, 11, RutDirector) , 
		con.parametros("@FechaAniversario", SqlDbType.VarChar, 4, FechaAniversario) , 
		con.parametros("@EdadMaximaPermanencia", SqlDbType.Int, 4, EdadMaximaPermanencia) , 
		con.parametros("@CodBanco", SqlDbType.Int, 4, CodBanco) , 
		con.parametros("@CuentaCorrienteNumero", SqlDbType.VarChar, 50, CuentaCorrienteNumero) , 
		con.parametros("@FechaTermino", SqlDbType.DateTime, 16, objFechaTermino) , 
		con.parametros("@EdadMinima", SqlDbType.Int, 4, EdadMinima) , 
		con.parametros("@EdadMaximaIngreso", SqlDbType.Int, 4, EdadMaximaIngreso) , 
		con.parametros("@Etapas", SqlDbType.Int, 4, Etapas) , 
		con.parametros("@MontoInversion", SqlDbType.Int, 4, MontoInversion) , 
		con.parametros("@MontoOperacion", SqlDbType.Int, 4, MontoOperacion) , 
		con.parametros("@MontoPersonal", SqlDbType.Int, 4, MontoPersonal) , 
		con.parametros("@IdUsuarioTecnico", SqlDbType.Int, 4, IdUsuarioTecnico) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion) , 
		con.parametros("@ProyectoDeContinuacion", SqlDbType.Int, 1, ProyectoDeContinuacion) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@EstadoProyecto", SqlDbType.Int, 4, EstadoProyecto),
        con.parametros("@NumeroPlazas",SqlDbType.Int,4,NumeroPlazas)
		};
        con.ejecutarProcedimiento("Insert_Proyectos", parametros, out datareader);
        //if (datareader.Read())
        //{
        //    returnvalue = Convert.ToInt32(datareader["identidad"]);
        //}
        con.Desconectar();
        return returnvalue;
    }
    public int funcioncodproyecto(int CodProyecto)
    {
        string SQL = "Select Max(CodProyecto)as CodProyecto From Proyectos Where CodProyecto like ('" + CodProyecto + "%')";

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(SQL, out datareader);

        int Cod = 0;
        while (datareader.Read())
        {
            try
            {
                 Cod = (int)datareader["CodProyecto"];
             
            }
            catch
            { }
        }

        con.Desconectar();

        return Cod;
    }
public DataTable GetProyectoxInstyRegion(int CodInstitucion,int Region)
    {
        proyectocoll pc = new proyectocoll();


        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetProyectosxInst + CodInstitucion + " And T1.CodRegion= "+Region + " and T1.IndVigencia = 'V' Order by CodProyecto"          , out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCorto", typeof(String)));

        dr = dt.NewRow();
        dr[2] = "Seleccionar";
        dr[0] = "0";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodProyecto"];
                dr[1] = (int)datareader["CodInstitucion"];
                dr[2] = "(V)"+"(" + ((int)datareader["CodProyecto"]).ToString() + ") " + (String)datareader["Nombre"];
                dr[3] = (String)datareader["NombreCorto"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetProyectoOrigen(int CodProyecto)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        string Sql = "select Codproyecto,Nombre from proyectos where codproyecto in (select codproyectoorigen "+
            "from proyectos where codproyecto = "+CodProyecto+" )";

        con.ejecutar(Sql, out datareader);
        
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodProyecto"));
        dt.Columns.Add(new DataColumn("Nombre"));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = "("+((System.Int32)datareader["CodProyecto"]).ToString() + ") " + (System.String)datareader["Nombre"];
               
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetProyectos_Region_Institucion(int CodRegion,int userid, string indvigencia, int codinstitucion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_Region_Inst_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@Region", SqlDbType.Int, 4).Value = CodRegion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[15] = " Seleccionar";

        dt.Rows.Add(dr);

        return dt;
    }


    public int GetResidenciasFAEVigentesNino(int CodNino)
    {        
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetResidenciasFAEVigentesNino";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;       
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt.Rows.Count;
    }
}