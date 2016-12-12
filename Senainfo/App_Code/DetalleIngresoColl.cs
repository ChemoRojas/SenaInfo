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
//////using neocsharp.NeoDatabase;

/// <summary>
/// Descripción breve de DetalleIngresoColl
/// </summary>
public class DetalleIngresoColl
{
	public DetalleIngresoColl()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    private string SQL_Instruccion(string CodTipoIngreso, int iVigente)
    {
        string tSql = string.Empty;
        tSql = tSql + "SELECT CodDetalleIngreso, CodTipoIngreso, '(' + IndVigencia + ') ' + Descripcion as Descripcion ";
        tSql = tSql + "FROM parDetalleIngreso ";
        tSql = tSql + "WHERE CodTipoIngreso = " + Convert.ToInt32(CodTipoIngreso) + " ";

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

    public DataTable GetData(string CodTipoIngreso, int iVigente)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        con.ejecutar(SQL_Instruccion(CodTipoIngreso, iVigente), out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodDetalleIngreso", typeof(int)));
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
                dr[0] = (System.Int32)datareader["CodDetalleIngreso"];
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
