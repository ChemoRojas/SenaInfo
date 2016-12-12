using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.Common;
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Summary description for Intitucion
/// </summary>
public class dilegenciascoll
{

    public void Update_Diligencias(
        int ICodDiligencia,                     //1
        int CodDiligencia, /*int CodNino,*/     //2
        int ICodIE,                             //3        
        DateTime FechaSolicitud,                //4
        int TipoSolicitanteDiligencia,          //5
        String Realizada,                       //6
        DateTime FechaRealizada,                //7
        int CodInstitucion,                     //8 
        int ICodTrabajador,                      //9
        String PropuestaTecnica,                //10
        String ResultadoDiscernimiento,         //11    
        int IdUsuarioActualizacion,             //12
        DateTime FechaActualizacion)            //13
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
	    con.parametros("@ICodDiligencia", SqlDbType.Int, 4, ICodDiligencia) ,                       //1
        con.parametros("@CodDiligencia", SqlDbType.Int, 4, CodDiligencia) ,                         //2
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) ,                                       //3
        //con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) ,                                   //--
		con.parametros("@FechaSolicitud", SqlDbType.DateTime, 16, FechaSolicitud) ,                 //4
		con.parametros("@TipoSolicitanteDiligencia", SqlDbType.Int, 4, TipoSolicitanteDiligencia) , //5
		con.parametros("@Realizada", SqlDbType.Char, 1, Realizada) ,                                //6
		con.parametros("@FechaRealizada", SqlDbType.DateTime, 16, FechaRealizada) ,                 //7
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) ,                       //8 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) ,                         //9 
		con.parametros("@PropuestaTecnica", SqlDbType.Char, 2, PropuestaTecnica) ,                  //10
		con.parametros("@ResultadoDiscernimiento", SqlDbType.Char, 2, ResultadoDiscernimiento),     //11
        con.parametros("@IdUsuarioActualizacion",SqlDbType.Int, 4, IdUsuarioActualizacion),         //12    
        con.parametros("@FechaActualizacion", SqlDbType.DateTime, 4, FechaActualizacion)            //13
		};
        con.ejecutarProcedimiento("Update_Diligencias", parametros, out datareader);
        con.Desconectar();

    }


        public int Insert_Diligencias(
        int CodDiligencia, int ICodIE, /*int ICodDiligencia, *//*int CodNino,*/ DateTime FechaSolicitud, 
        int TipoSolicitanteDiligencia,String Realizada, DateTime FechaRealizada, int CodInstitucion, 
        int ICodTrabajador,int CodTrabajador, String PropuestaTecnica, String ResultadoDiscernimiento, 
        int IdUsuarioActualizacion, DateTime FechaActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiligencia", SqlDbType.Int, 4, CodDiligencia) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
        //con.parametros("@ICodDiligencia", SqlDbType.Int, 4, ICodDiligencia) ,
		//con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@FechaSolicitud", SqlDbType.DateTime, 16, FechaSolicitud) , 
		con.parametros("@TipoSolicitanteDiligencia", SqlDbType.Int, 4, TipoSolicitanteDiligencia) , 
		con.parametros("@Realizada", SqlDbType.Char, 1, Realizada) , 
		con.parametros("@FechaRealizada", SqlDbType.DateTime, 16, FechaRealizada) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
        con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@PropuestaTecnica", SqlDbType.Char, 2, PropuestaTecnica) , 
		con.parametros("@ResultadoDiscernimiento", SqlDbType.Char, 2,  ResultadoDiscernimiento) ,
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@FechaAtualizacion", SqlDbType.DateTime, 16, FechaActualizacion)
		};
        con.ejecutarProcedimiento("Insert_Diligencias", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }
    public DataTable GetDiligencias(string ICodIE)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetDiligencias + "@pICodIE";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
       // dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaSolicitud", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoSolicitanteDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("Realizada", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaRealizada", typeof(String)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("PropuestaTecnica", typeof(String)));
        dt.Columns.Add(new DataColumn("ResultadoDiscernimiento", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodDiligencia"];
                dr[1] = (int)datareader["CodDiligencia"];
                dr[2] = (int)datareader["ICodIE"];
              //  dr[3] = (int)datareader["CodNino"];
                dr[3] = (DateTime)datareader["FechaSolicitud"];
                dr[4] = (int)datareader["TipoSolicitanteDiligencia"];
                dr[5] = (String)datareader["Realizada"];
                if ((String)datareader["Realizada"].ToString() == "S")
                {
                    dr[5] = "SI";
                }
                if ((String)datareader["Realizada"].ToString() == "N")
                {
                    dr[5] = "NO";
                }
                if ((String)datareader["Realizada"].ToString() == "I")
                {
                    dr[5] = "NO FUE";
                }
                if ((String)datareader["Realizada"].ToString() == "0")
                {
                    dr[5] = "-";
                }

                if (((DateTime)datareader["FechaRealizada"]).ToShortDateString().Trim() == Convert.ToString("01-01-1900") || ((DateTime)datareader["FechaRealizada"]).ToShortDateString().Trim() == Convert.ToString("30-12-1899"))
                {
                    dr[6] = "-";
                }
                else
                {
                    dr[6] = Convert.ToString(((DateTime)datareader["FechaRealizada"]).ToShortDateString());
                }
                
                
                dr[7] = (int)datareader["CodInstitucion"];
                dr[8] = (int)datareader["ICodTrabajador"];
                dr[9] = (String)datareader["PropuestaTecnica"];
                dr[10] = (String)datareader["ResultadoDiscernimiento"];
                dr[11] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dr[12] = (String)datareader["Descripcion"];
                dr[13] = (String)datareader["DescripcionTipo"];
                dr[14] = (String)datareader["NombreCompleto"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetDiligenciasBycCode(string /*ICodIE*/ICodDiligencia)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetDiligenciaBycode + "@pICodDiligencia";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodDiligencia", SqlDbType.Int, 4, Convert.ToInt32(/*ICodIE*/ICodDiligencia)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        //dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaSolicitud", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoSolicitanteDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("Realizada", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaRealizada", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("PropuestaTecnica", typeof(String)));
        dt.Columns.Add(new DataColumn("ResultadoDiscernimiento", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodDiligencia"];
                dr[1] = (int)datareader["CodDiligencia"];
                dr[2] = (int)datareader["ICodIE"];
                //dr[3] = (int)datareader["CodNino"];
                dr[3] = (DateTime)datareader["FechaSolicitud"];
                dr[4] = (int)datareader["TipoSolicitanteDiligencia"];
                dr[5] = (String)datareader["Realizada"];
                dr[6] = (DateTime)datareader["FechaRealizada"];
                dr[7] = (int)datareader["CodInstitucion"];
                dr[8] = (int)datareader["ICodTrabajador"];
                dr[9] = (String)datareader["PropuestaTecnica"];
                dr[10] = (String)datareader["ResultadoDiscernimiento"];
                dr[11] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dr[12] = (String)datareader["Descripcion"];
                dr[13] = (String)datareader["DescripcionTipo"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


}
