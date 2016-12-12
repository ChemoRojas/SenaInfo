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
/// Summary description for institucioncoll
/// </summary>
public class institucioncoll
{
    public institucioncoll()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string SQL_Institucion()
    {
        string tsql = string.Empty;
        tsql = "SELECT DISTINCT * FROM Instituciones order by nombre";

        return tsql;
    }

    public DataTable GetData()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_Institucion(), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Codigo Institución", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre"));
        dt.Columns.Add(new DataColumn("RutInstitucion", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Nombre"];
                dr[2] = (System.String)datareader["RutInstitucion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetData(int userid)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Instituciones_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
          da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "0";
        dr[5] = " Seleccionar ";
        dr[6] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }

    public DataTable GetData_DataSet(DataSet ds)
    {
        DataTable dt = ds.Tables["dtInstituciones"];
        return dt;
    }

    public DataTable Get_DataConProyectos_byUserId(int userid)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_InstitucionesConProyectos_byUserId";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "0";
        dr[5] = " Seleccionar ";
        dr[6] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }

    public DataTable GetRutInst(String Rut)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        string sql = "Select CodInstitucion,Nombre,RutInstitucion From Instituciones Where RutInstitucion =@pRutInstitucion";

        List<DbParameter> listDbParameter = new List<DbParameter>();
        listDbParameter.Add(Conexiones.CrearParametro("@pRutInstitucion", SqlDbType.VarChar, 11, Rut));

        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Codigo Institución", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("RutInstitucion", typeof(String)));

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstitucion"];
                dr[1] = (String)datareader["Nombre"];
                dr[2] = (String)datareader["RutInstitucion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public DataTable GetparTipoInstitucion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoInstitucion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dr[2] = "V";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoInstitucion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    //public int GeneraCodProy(int CodInstitucion)
    //{
    //    /* Database db = new Database(objconn); */
    //    Conexiones con = new Conexiones();
    //    DbParameter[] parametros = {
    //        con.parametros("@CodInstitucionIn", SqlDbType.Int, 4, CodInstitucion),
    //        con.parametrosSalida("@CodInstitucionOut", SqlDbType.Int, 4)
    //    };
    //    //db.neooutprms("ReturnValue",SqlDbType.Int,4)};

    //    con.ejecutarProcedimiento("sp_ObtieneCodigoInstitucion", parametros);

    //    int Codigo = Convert.ToInt32(parametros[1].Value);

    //    con.Desconectar();
    //    return Codigo;
    //}

    public int GeneraCodProy(int CodInstitucion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
            con.parametros("@CodInstitucionIn", SqlDbType.Int, 4, CodInstitucion)
        };
        con.ejecutarProcedimiento("sp_ObtieneCodigoInstitucion", parametros, out datareader);

        int Codigo = 0;
        while (datareader.Read())
        {
            try
            {
                Codigo = (int)datareader["nuevo_id"];
            }
            catch { }
        }

        con.Desconectar();
        return Codigo;
    }

    public DataTable GetTransferencia(int CodInstitucion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        String SQL = "Select CODINSTITUCION,FECHATRANSACCION,MONTOTRANSACCION from transferencias where CodInstitucion = " + CodInstitucion;
        con.ejecutar(SQL, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CODINSTITUCION", typeof(int)));
        dt.Columns.Add(new DataColumn("FECHATRANSACCION", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("MONTOTRANSACCION", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CODINSTITUCION"];
                dr[1] = (DateTime)datareader["FECHATRANSACCION"];
                dr[2] = (int)datareader["MONTOTRANSACCION"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    # region METODOS REPORTES
    ////////Metodos Sgallegos
    public DataTable GetInstitucionReporte() //sgf reporteNino
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetInstitucion_reporte, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(string)));

        dr = dt.NewRow();
        dr[0] = -1;
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Nombre"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }
        con.Desconectar();

        return dt;
    }

    public DataTable GetInstitucionReportexRgn(int CodRegion) //sgf reporteNino
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetInstitucion_reportexrgn + CodRegion + " Order by T1.Nombre", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(string)));

        dr = dt.NewRow();
        dr[0] = -1;
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Nombre"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }
        con.Desconectar();

        return dt;
    }

    public DataTable GetparTipoInstitucion_reporte()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoInstitucion_reporte, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = -1;
        dr[1] = "Seleccionar";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoInstitucion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetDataxRgn(int userid, int region)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_InstitucionesxRgn_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@region", SqlDbType.Int, 4).Value = region;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0"; dr[1] = "0"; dr[5] = " Seleccionar "; dr[6] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }

    public DataTable GetDataxRgnConProyectos(int userid, int region)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_InstitucionesxRgnConProyectos_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@region", SqlDbType.Int, 4).Value = region;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0"; dr[1] = "0"; dr[5] = " Seleccionar "; dr[6] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }
    # endregion
}