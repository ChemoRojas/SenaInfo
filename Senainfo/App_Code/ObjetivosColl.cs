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


/// <summary>
/// Descripción breve de ObjetivosColl
/// </summary>
public class ObjetivosColl
{
	public ObjetivosColl()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    private string SQL_Instruccion(int iVigente)
    {
        string tSql = string.Empty;
        tSql = "SELECT CodObjetivo, '(' + IndVigencia + ') ' + Descripcion as Descripcion FROM parObjetivo ";
        switch (iVigente)
        {
            case 0:
                tSql = tSql + "WHERE IndVigencia = 'C' AND swInstitucion = 0";
                break;
            case 1:
                tSql = tSql + "WHERE IndVigencia = 'V' AND swInstitucion = 0";
                break;
            case 2:
                tSql = tSql + "WHERE swInstitucion = 0";
                break;
        }

        return tSql;
    }
    private string SQL_InstruccionIstituciones(int iVigente)
    {
        string tSql = string.Empty;
        tSql = "SELECT CodObjetivo, '(' + IndVigencia + ') ' + Descripcion as Descripcion FROM parObjetivo ";
        switch (iVigente)
        {
            case 0:
                tSql = tSql + "WHERE IndVigencia = 'C' AND swInstitucion = 1";
                break;
            case 1:
                tSql = tSql + "WHERE IndVigencia = 'V' AND swInstitucion = 1";
                break;
            case 2:
                tSql = tSql + "WHERE swInstitucion = 1";
                break;
        }

        return tSql;
    }

    public DataTable GetObjetivos( int iVigente)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_Instruccion(iVigente), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodObjetivo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion"));

        dr = dt.NewRow();
        dr[0] = (System.Int32)0;
        dr[1] = (System.String)"Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodObjetivo"];
                dr[1] = (System.String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public DataTable GetObjetivosInstituciones( int iVigente)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_InstruccionIstituciones(iVigente), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodObjetivo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion"));

        dr = dt.NewRow();
        dr[0] = (System.Int32)0;
        dr[1] = (System.String)"Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodObjetivo"];
                dr[1] = (System.String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

}
