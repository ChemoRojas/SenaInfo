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
/// Summary description for CargaDDL
/// </summary>
public class CargaDDL
{
	public CargaDDL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable TipoMaltrato()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar("Select * From ParTipoMaltrato Where IndVigencia ='V'", out datareader);


        DataTable dt = new DataTable();
        dt.Columns.Add("TipoMaltrato");
        dt.Columns.Add("Descripcion");
        
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
               
                dr = dt.NewRow();
                dr[0] = Convert.ToString(datareader["TipoMaltrato"]);
                dr[1] = "(" + Convert.ToString(datareader["TipoMaltrato"]) + ") " + Convert.ToString(datareader["Descripcion"]);
                dt.Rows.Add(dr);

            }
            catch
            {
            }

        }

        con.Desconectar();

        return dt;
    }
}
