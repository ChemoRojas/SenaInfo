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
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Summary description for mastercoll
/// </summary>
public class inmueblecoll
{
    public inmueblecoll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetparTipoInmueble()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoInmueble, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("Indvigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoInmueble"];
                dr[1] = datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["Indvigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetInmueble(string CodProyecto)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string tsql = Resources.Procedures.Getinmueble + "@pCodProyecto";
        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodProyecto)));

        con.ejecutar(tsql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

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
        dt.Columns.Add(new DataColumn("ICodInmueble", typeof(int)));
        dr = dt.NewRow();
        dr[20] = 0;
        dr[6] = " Seleccionar";

        dt.Rows.Add(dr);
        
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstitucion"];
                dr[1] = (int)datareader["CodInmueble"];
                dr[2] = (int)datareader["IdUsuarioActualizacion"];
                dr[3] = (int)datareader["CodsituacionLegalInmueble"];
                dr[4] = (int)datareader["CodComuna"];
                dr[5] = (int)datareader["TipoInmueble"];
                dr[6] = (String)datareader["Nombre"];
                dr[7] = (String)datareader["Direccion"];
                dr[8] = (String)datareader["Telefono"];
                dr[9] = (String)datareader["Fax"];
                dr[10] = (int)datareader["CodigoPostal"];
                dr[11] = (int)datareader["m2Construidos"];
                dr[12] = (int)datareader["m2totales"];
                dr[13] = (int)datareader["NumeroDormitorios"];
                dr[14] = (int)datareader["CapacidadNinos"];
                dr[15] = (int)datareader["NumeroBanos"];
                dr[16] = (int)datareader["CantidadPisos"];
                dr[17] = (String)datareader["AreasVerdes"];
                dr[18] = (String)datareader["IndVigencia"];
                dr[19] = (DateTime)datareader["FechaActualizacion"];
                dr[20] = (int)datareader["ICodInmueble"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetInmuebleProy(string CodInstitucion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string tsql = Resources.Procedures.GetInmuebleProy + "@pCodInstitucion";
        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion)));


        con.ejecutar(tsql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar";

        dt.Rows.Add(dr);


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodInmueble"];
                dr[1] = (String)datareader["Nombre"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    //AGREGADO POR GONZALO MANZUR 08-06-2006
    public void Insert_Inmueble( int CodProyecto, int ICodInmueble, DateTime FechaInicioVigencia,
                                int IdUsuarioActualizacion, DateTime FechaFinVigencia, string Indvigencia, DateTime FechaActualizacion)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto), 
        con.parametros("@ICodInmueble", SqlDbType.Int, 4, ICodInmueble), 
        con.parametros("@FechaInicioVigencia", SqlDbType.DateTime, 8, FechaInicioVigencia), 
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int,4, IdUsuarioActualizacion),
        con.parametros("@FechaFinVigencia", SqlDbType.DateTime,8, FechaFinVigencia),
        con.parametros("@Indvigencia", SqlDbType.Char,1, FechaFinVigencia),
        con.parametros("@FechaActualizacion", SqlDbType.DateTime,8, FechaActualizacion)
        };

        con.ejecutarProcedimiento("Insert_Inmueble", parametros, out datareader);
        con.Desconectar();
    }
    // HASTA AQUI

}
