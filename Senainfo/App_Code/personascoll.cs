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
/// Summary description for personascoll
/// </summary>
public class personascoll
{
    public personascoll()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetpersonaRelacionadatrabajar(int CodNino)
    {
        //Sacar Codigo en duro

        // CodPlanIntervencion = 275;

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetPersonasRelacionadas + CodNino, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodPersonaRelacionada"];
                dr[1] = (String)datareader["NombreCompleto"];


                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }


    public DataTable GetGrillaPerRel(int ICodIE)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetGrillaPerRel + ICodIE, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        //dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        //dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        //dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        //dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaRelacion", typeof(DateTime)));


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                // dr[0] = (int)datareader["NombreCompleto"];
                dr[0] = (String)datareader["NombreCompleto"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (DateTime)datareader["FechaRelacion"];
                //dr[4] = (String)datareader["Descripcion"];
                //dr[5] = (DateTime)datareader["FechaRelacion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

}
