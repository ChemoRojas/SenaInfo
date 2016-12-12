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
/// Summary description for mastercoll
/// </summary>
public class trabajadorescoll
{
    public trabajadorescoll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetTrabajadoresProyecto(string CodProyecto)
    {
        DbDataReader datareader = null;
        List<DbParameter> listDbParameter = new List<DbParameter>();

        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        string sql = Resources.Procedures.GetTrabajadoresProyecto + "@pCodProyecto" ;

        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodProyecto)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodCargo", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoCargo", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProfesion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodCausalEgresoTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("ResponsableIngreso", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaEgreso", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("ResponsableEgreso", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaUltimoIngresoEgreso", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));

        dr = dt.NewRow();
        dr[0] = -1;
        dr[14] = "No Asignado";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr[0] = 0;
        dr[14] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dr[1] = (int)datareader["CodProyecto"];
                dr[2] = (DateTime)datareader["FechaIngreso"];
                dr[3] = (int)datareader["CodCargo"];
                dr[4] = (int)datareader["TipoCargo"];
                dr[5] = (int)datareader["CodProfesion"];
                dr[6] = (int)datareader["CodCausalEgresoTrabajador"];
                dr[7] = (String)datareader["ResponsableIngreso"];
                //if (Convert.ToString((DateTime)datareader["FechaEgreso"]).Trim() == "")
                //{
                //    dr[8] = "01-01-1900";
                //}
                //else 
                //{
                dr[8] = (DateTime)datareader["FechaEgreso"];
                //}

                dr[9] = (String)datareader["ResponsableEgreso"];
                dr[10] = (DateTime)datareader["FechaUltimoIngresoEgreso"];
                dr[11] = (String)datareader["IndVigencia"];
                dr[12] = (DateTime)datareader["FechaActualizacion"];
                dr[13] = (int)datareader["IdUsuarioActualizacion"];
                dr[14] = (String)datareader["NombreCompleto"];
                dt.Rows.Add(dr);
            }




            catch
            {
                dr[8] = "01-01-1900";
                dr[9] = (String)datareader["ResponsableEgreso"];
                dr[10] = (DateTime)datareader["FechaUltimoIngresoEgreso"];
                dr[11] = (String)datareader["IndVigencia"];
                dr[12] = (DateTime)datareader["FechaActualizacion"];
                dr[13] = (int)datareader["IdUsuarioActualizacion"];
                dr[14] = (String)datareader["NombreCompleto"];
                dt.Rows.Add(dr);
            }
        }
        con.Desconectar();
        return dt;
    }





    // formazabal

    public DataTable GetTrabajadores()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTrabajadores, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProfesion", typeof(int)));
        dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("RutTrabajador", typeof(String)));
        dt.Columns.Add(new DataColumn("Telefono", typeof(String)));
        dt.Columns.Add(new DataColumn("Mail", typeof(String)));
        dt.Columns.Add(new DataColumn("Fax", typeof(String)));
        dt.Columns.Add(new DataColumn("CodigoPostal", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Codtrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        
        dr = dt.NewRow();
        dr[0] = 0;
        dr[15] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dr[1] = (int)datareader["CodInstitucion"];
                dr[2] = (int)datareader["CodProfesion"];
                dr[3] = (String)datareader["Paterno"];
                dr[4] = (String)datareader["Materno"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["RutTrabajador"];
                dr[7] = (String)datareader["Telefono"];
                dr[8] = (String)datareader["Mail"];
                dr[9] = (String)datareader["Fax"];
                dr[10] = (int)datareader["CodigoPostal"];
                dr[11] = (String)datareader["IndVigencia"];
                dr[12] = (DateTime)datareader["FechaActualizacion"];
                dr[13] = (int)datareader["IdUsuarioActualizacion"];
                dr[14] = (int)datareader["Codtrabajador"];
                dr[15] = (String)datareader["NombreCompleto"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetTrabajadores2(string CodInstitucion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = "Select T3.ICodTrabajador, T3.Nombres,T3.Paterno,T3.Materno " +
                     "From Trabajadores T3 left join TrabajadorProyecto T1 On T1.ICodTrabajador = T3.ICodTrabajador Where T3.CodInstitucion=@pCodInstitucion";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Materno", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dr[1] = (String)datareader["Nombres"] + " " + (String)datareader["Paterno"] + " " + (String)datareader["Materno"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

     public DataTable GetTrabajadoresProyectoddl(string CodInstitucion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = " Select T1.ICodTrabajador,T1.Nombres,T1.Paterno,T1.Materno " +
        "From Trabajadores T1 inner join TrabajadorProyecto T3 on T1.ICodTrabajador = T3.ICodTrabajador " +
        "inner join Proyectos T2 On T2.CodProyecto = T3.CodProyecto Where T2.CodProyecto=@pCodProyecto ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion)));
        
        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Materno", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar";
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

    public DataTable GetTrabajadoresProyectoInst(string CodInstitucion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = Resources.Procedures.GetTrabajadoresProyectoInst + "@pCodInstitucion";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProfesion", typeof(int)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[3] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dr[1] = (int)datareader["CodInstitucion"];
                dr[2] = (int)datareader["CodProfesion"];
                dr[3] = (String)datareader["NombreCompleto"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetRutTrab( String Rut,int CodInstitucion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = "Select ICodTrabajador,CodInstitucion,CodProfesion,Nombres,Paterno,Materno,RutTrabajador,IndVigencia " +
        "From Trabajadores Where RutTrabajador =@pRutTrabajador  and CodInstitucion =@pCodInstitucion";

        listDbParameter.Add(Conexiones.CrearParametro("@pRutTrabajador", SqlDbType.VarChar, 11, Rut));
        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, CodInstitucion));

        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Nombres",typeof(String)));
        dt.Columns.Add(new DataColumn("Paterno",typeof(String)));
        dt.Columns.Add(new DataColumn("Materno",typeof(String)));
        dt.Columns.Add(new DataColumn("RutTrabajador", typeof(String)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (String)datareader["Nombres"];
                dr[1] = (String)datareader["Paterno"];
                dr[2] = (String)datareader["Materno"];
                dr[3] = (String)datareader["RutTrabajador"];
                dr[4] = (int)datareader["ICodTrabajador"];
                dr[5] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public int CheckExistTrab( int ICodTrabajador, int CodProyecto)
    {
        int existe=0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        string sql = "Select Count(IcodTrabajador)as existe from TrabajadorProyecto "+ 
                     "Where ICodTrabajador = "+ICodTrabajador+" and CodProyecto ="+CodProyecto;
        con.ejecutar(sql, out datareader);
        while (datareader.Read())
        {
            try
            {
                existe = (int)datareader["existe"];
            }
            catch
            { }
        }

        con.Desconectar();

        return existe;
    }
    public DataTable GetTrabInstitucionV( String Rut)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = "Select t2.Nombre,t1.Nombres,t1.Paterno,t1.Materno, "+ 
                     "vigencia =(case when t1.IndVigencia = 'V' then 'Vigente' else 'Caducado' end) "+
                     "From Trabajadores t1 inner join instituciones t2 on t1.codinstitucion = t2.codinstitucion "+
                     "Where t1.IndVigencia = 'V' and t1.RutTrabajador=@pRutTrabajador";

        listDbParameter.Add(Conexiones.CrearParametro("@pRutTrabajador", SqlDbType.VarChar, 11, Rut.Trim()));

        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("vigencia", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Nombre"];
                dr[1] = (String)datareader["Nombres"];
                dr[2] = (String)datareader["Paterno"];
                dr[3] = (String)datareader["Materno"];
                dr[4] = (String)datareader["vigencia"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
  public DataTable update_trabajadoresproyecto_vigencia(int icodtrabajador, string indvigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_TrabajadoresProyecto_Vigencia";
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.VarChar, 1).Value = indvigencia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }

    public string get_rol(int userid)
    {
        string rol = "0";
        string sParametrosConsulta =  "Select T3.Usuario,T3.CodRegion,T3.CodDireccionRegional,T3.Contrasena " +
                                      "From usuarios T3 " +
                                      "Where T3.IdUsuario =" + userid;

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);
        while (datareader.Read())
        {
            try
            {
                rol = (String)datareader["Contrasena"];
            }
            catch { }
        }

        return rol;
    }
}
