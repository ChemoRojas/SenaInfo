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
/// Descripción breve de MedioDePago
/// </summary>
public class MedioDePago
{
	public MedioDePago()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    private string SQL_Instruccion(int iVigente)
    {
        string tSql = string.Empty;
        tSql = "SELECT CodMedioDePago, '(' + IndVigencia + ') ' + Descripcion as Descripcion FROM parMedioDePago ";
        switch (iVigente)
        {
            case 0:
                tSql = tSql + "WHERE IndVigencia = 'C'";
                break;
            case 1:
                tSql = tSql + "WHERE IndVigencia = 'V'";
                break;
            case 2:
                tSql = tSql + "";
                break;
        }

        return tSql;
    }

    public DataTable GetData( int iVigente)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_Instruccion(iVigente), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodMedioDePago", typeof(int)));
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
                dr[0] = (System.Int32)datareader["CodMedioDePago"];
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
