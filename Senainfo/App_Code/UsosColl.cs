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
/// Descripción breve de UsosColl
/// </summary>
public class UsosColl
{
	public UsosColl()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    private string SQL_Instruccion(string CodObjetivo, int iVigente, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();

        string tSql = string.Empty;
        tSql = tSql + "SELECT CodUso, '(' + IndVigencia + ') ' + Descripcion as Descripcion ";
        tSql = tSql + "FROM parUso ";
        tSql = tSql + "WHERE CodObjetivo =@pCodObjetivo ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodObjetivo", SqlDbType.Int, 4, Convert.ToInt32(CodObjetivo)));

        switch (iVigente)
        {
            case 0:
                tSql = tSql + "AND IndVigencia = 'C'";
                break;
            case 1:
                tSql = tSql + "AND IndVigencia = 'V'";
                break;
            case 2:
                tSql = tSql + "";
                break;
        }

        return tSql;
    }

    public DataTable GetData( string CodObjetivo, int iVigente)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        string sql = SQL_Instruccion(CodObjetivo, iVigente, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodUso", typeof(int)));
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
                dr[0] = (System.Int32)datareader["CodUso"];
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
