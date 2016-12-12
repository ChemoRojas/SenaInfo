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
public class diagnosticoscoll
{
    public diagnosticoscoll()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    // Consultas Grillas Diagnosticos

    

    #region historicodiagnosticos

   
    public DataTable Historico_diag_escolar( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_escolar",parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("Codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("escolaridad", typeof(String)));
        dt.Columns.Add(new DataColumn("ultimo", typeof(int)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));
        dt.Columns.Add(new DataColumn("asistencia", typeof(String)));
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["Codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["escolaridad"];
                dr[4] = (int)datareader["ultimo"];
                dr[5] = (String)datareader["fecha"];
                dr[6] = (String)datareader["asistencia"];
              
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_droga( int CodNino)
    {
      //  DbDataReader datareader = null;
      //  Conexiones con = new Conexiones();

      //  DbParameter[] parametros = {
      //  con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

      //  con.ejecutarProcedimiento("Historico_diag_droga", parametros, out datareader);
      //  DataTable dt = new DataTable();
      //  DataRow dr;
      //  dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
      //  dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
      //  dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
      //  dt.Columns.Add(new DataColumn("droga", typeof(String)));
      //  dt.Columns.Add(new DataColumn("tipo", typeof(String)));
      //  dt.Columns.Add(new DataColumn("fecha", typeof(String)));
      ////  dt.Columns.Add(new DataColumn("asistencia", typeof(String)));

      //  while (datareader.Read())
      //  {
      //      try
      //      {
      //          dr = dt.NewRow();
      //          dr[0] = (String)datareader["Institucion"];
      //          dr[1] = (int)datareader["codproyecto"];
      //          dr[2] = (String)datareader["proyecto"];
      //          dr[3] = (String)datareader["droga"];
      //          dr[4] = (String)datareader["tipo"];
      //          dr[5] = (String)datareader["fecha"];
      //        //  dr[5] = (String)datareader["asistencia"];

      //          dt.Rows.Add(dr);
      //      }
      //      catch { }
      //  }
      //  con.Desconectar();


        DataTable dt = new DataTable();
        Conexiones con = new Conexiones();
        con.Autenticar();
        dt = con.TraerDataTable("Historico_diag_droga", CodNino);
        con.CerrarConexion();
        con.Desconectar();

        return dt;
    }
    public DataTable Historico_diag_psicologico( int CodNino)
    {
          DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_psicologico", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("instrumento", typeof(String)));
        dt.Columns.Add(new DataColumn("medicion", typeof(String)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));
        //dt.Columns.Add(new DataColumn("asistencia", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["instrumento"];
                dr[4] = (String)datareader["medicion"];
                dr[5] = (String)datareader["fecha"];
              //  dr[5] = (String)datareader["asistencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_social( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_social", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("calle", typeof(String)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));
        dt.Columns.Add(new DataColumn("especial", typeof(String)));
        dt.Columns.Add(new DataColumn("tuicion", typeof(String)));
        dt.Columns.Add(new DataColumn("estado", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["calle"];
                dr[4] = (String)datareader["fecha"];
                dr[5] = (String)datareader["especial"];
                dr[6] = (String)datareader["tuicion"];
                dr[7] = (String)datareader["estado"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_capacitacion( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_capacitacion", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("area", typeof(String)));
        dt.Columns.Add(new DataColumn("tipo", typeof(String)));
        dt.Columns.Add(new DataColumn("estado", typeof(String)));
        dt.Columns.Add(new DataColumn("organismo", typeof(String)));
        dt.Columns.Add(new DataColumn("inicio", typeof(String)));
        dt.Columns.Add(new DataColumn("termino", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["area"];
                dr[4] = (String)datareader["tipo"];
                dr[5] = (String)datareader["estado"];
                dr[6] = (String)datareader["organismo"];
                dr[7] = (String)datareader["inicio"];
                dr[8] = (String)datareader["termino"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_laboral( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_laboral", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("ingreso", typeof(String)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));
        dt.Columns.Add(new DataColumn("area", typeof(String)));
        dt.Columns.Add(new DataColumn("situacion", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["ingreso"];
                dr[4] = (String)datareader["fecha"];
                dr[5] = (String)datareader["area"];
                dr[6] = (String)datareader["situacion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_peoresformas( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_pfti", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("agresor", typeof(String)));
        dt.Columns.Add(new DataColumn("relacion", typeof(String)));
        dt.Columns.Add(new DataColumn("categoria", typeof(String)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["agresor"];
                dr[4] = (String)datareader["relacion"];
                dr[5] = (String)datareader["categoria"];
                dr[6] = (String)datareader["fecha"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_maltrato( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_maltrato", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("agresor", typeof(String)));
        dt.Columns.Add(new DataColumn("relacion", typeof(String)));
        dt.Columns.Add(new DataColumn("maltrato", typeof(String)));
        dt.Columns.Add(new DataColumn("tipo", typeof(String)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] =  (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["agresor"];
                dr[4] = (String)datareader["relacion"];
                dr[5] = (String)datareader["maltrato"];
                dr[6] = (String)datareader["tipo"];
                dr[7] = (String)datareader["fecha"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Historico_diag_judiciales( int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        DbParameter[] parametros = {
        con.parametros("@Codnino", SqlDbType.Int, 4, CodNino)};

        con.ejecutarProcedimiento("Historico_diag_hechosjudiciales", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Institucion", typeof(String)));
        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("proyecto", typeof(String)));
        dt.Columns.Add(new DataColumn("tribunal", typeof(String)));
        dt.Columns.Add(new DataColumn("materia", typeof(String)));
        dt.Columns.Add(new DataColumn("fecha", typeof(String)));
        //dt.Columns.Add(new DataColumn("asistencia", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Institucion"];
                dr[1] = (int)datareader["codproyecto"];
                dr[2] = (String)datareader["proyecto"];
                dr[3] = (String)datareader["tribunal"];
                dr[4] = (String)datareader["materia"];
                dr[5] = (String)datareader["fecha"];
              //  dr[5] = (String)datareader["asistencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }





    #endregion 
    
    public DataTable GetDiagnosticoMaltrato(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetDiagnosticoMaltrato + ICodIE + " Order by T2.FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodMaltrato", typeof(int)));
       // dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoMaltratoDes", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("NombreCompletoPR", typeof(String)));
        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodMaltrato"];
               // dr[1] = (String)datareader["NombreCompleto"];   
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (String)datareader["TipoMaltratoDes"];
                dr[3] = (String)datareader["Descripcion"];
                dr[4] = (String)datareader["NombreCompleto"];
                dr[5] = (DateTime)datareader["FechaDiagnostico"];
                dr[6] = (String)datareader["NombreCompletoPR"];
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }


    public DataTable GetDiagnosticoEscolar(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetDiagnosticoEscolar + ICodIE + " Order by FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("AlIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("AnoUltimoCursoAprobado", typeof(int)));
        dt.Columns.Add(new DataColumn("AsistenciaEscolar", typeof(String)));
        dt.Columns.Add(new DataColumn("ICodEscolar", typeof(int)));

     

        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["AlIngreso"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = ((String)datareader["Descripcion"]).ToUpper();
                dr[3] = ((DateTime)datareader["FechaDiagnostico"]).ToShortDateString();
                dr[4] = (int)datareader["AnoUltimoCursoAprobado"];
                dr[5] = ((String)datareader["AsistenciaEscolar"]).ToUpper();
                dr[6] = (int)datareader["ICodEscolar"];
                dt.Rows.Add(dr);
            
            
            }
            catch {}
        }
        con.Desconectar();
        
        return dt;

    }

    public DataTable GetDiagnosticoDroga(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetDiagnosticoDroga + ICodIE + " Order by T2.FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodDroga", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("TipoConsumo", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        
        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodDroga"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dr[3] = (String)datareader["Descripcion"];
                dr[4] = (String)datareader["TipoConsumo"];
                dr[5] = (String)datareader["NombreCompleto"];

               
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    public DataTable GetDiagnosticoPsicologico(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetDiagnosticoPsicologico + ICodIE + " Order by T2.FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodPsicologico", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodTipoDiagnosticoPsi", typeof(String)));
        dt.Columns.Add(new DataColumn("DescInstrumentoMedicion", typeof(String)));
        dt.Columns.Add(new DataColumn("DescMediciones", typeof(String)));
        dt.Columns.Add(new DataColumn("CodTranstornoMental", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));

        while (datareader.Read())
        {

            try
            {
                dr = dt.NewRow(); 
                dr[0] = (int)datareader["ICodPsicologico"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dr[3] = (String)datareader["CodTipoDiagnosticoPsi"];
                dr[4] = (String)datareader["DescInstrumentoMedicion"];
                dr[5] = (String)datareader["DescMediciones"];
                dr[6] = (String)datareader["CodTrastornoMental"];
                dr[7] = (String)datareader["NombreCompleto"];
               
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetDiagnosticoSocial(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetDiagnosticoSocial + ICodIE + " Order by T2.FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("ICodSocial", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("SituacionEspecial",typeof(String)));
        dt.Columns.Add(new DataColumn("SituacionCalle",typeof(String)));
        dt.Columns.Add(new DataColumn("EstadodeAbandono",typeof(String)));
        dt.Columns.Add(new DataColumn("SituacionTuicion",typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
       // dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodSocial"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dr[3] = (String)datareader["SituacionEspecial"];
                dr[4] = (String)datareader["SituacionCalle"];
                dr[5] = (String)datareader["EstadodeAbandono"];
                dr[6] = (String)datareader["SituacionTuicion"];
                dr[7] = (String)datareader["NombreCompleto"];
                
               // dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetDiagnosticoCapacitacion(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetCapacitacionNino + ICodIE + " Order by T1.FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodCapacitacionNino", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Area", typeof(String)));
        dt.Columns.Add(new DataColumn("Termino", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaInicioCapacitacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaTerminoCapacitacion", typeof(DateTime)));


        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodCapacitacionNino"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (String)datareader["Descripcion"];
                dr[3] = (DateTime)datareader["FechaDiagnostico"];
                dr[4] = (String)datareader["Area"];
                
                
                if((String)datareader["Termino"] == "*")
                {
                    dr[4] = "";
                }
                if ((String)datareader["Termino"] == "A")
                {
                    dr[5] = "Aprobado";
                }
                if ((String)datareader["Termino"] == "I")
                {
                    dr[5] = "Interrumpe Deserción";
                }
                if ((String)datareader["Termino"] == "E")
                {
                    dr[5] = "Egresado sin Titulo";
                }
                if ((String)datareader["Termino"] == "R")
                {
                    dr[5] = "Reprobado";
                }
                //if ((String)datareader["Termino"] == "")
                //{

                //    dr[4] = "";
                //}



                //dr[4] = (String)datareader["Termino"];
                dr[6] = (DateTime)datareader["FechaInicioCapacitacion"];

             //   if (Convert.ToString(((DateTime)datareader["FechaTerminoCapacitacion"]).ToShortDateString()) == "30-12-1899")
                //{
                //    dr[6] = "";
                //}
                //else
                //{
                //    dr[6] = (DateTime)datareader["FechaTerminoCapacitacion"];
                //}


                try
                {
                    if (Convert.ToDateTime(((DateTime)datareader["FechaTerminoCapacitacion"]).ToShortDateString()) == Convert.ToDateTime("01-01-1900"))
                    {
                        dr[7] = "-";
                    }
                    else
                    {
                        dr[7] = (DateTime)datareader["FechaTerminoCapacitacion"];
                    }
                }
                catch { }
                //dr[7] = (DateTime)datareader["FechaTerminoCapacitacion"];
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetSituacionLaboral(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetSituacionLaboral + ICodIE + " Order by T2.FechaSituacionLaboral desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("IcodSituacionLaboral", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaSituacionLaboral", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("SituacionLaboral", typeof(String)));
       
        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["IcodSituacionLaboral"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (DateTime)datareader["FechaSituacionLaboral"];
                dr[3] = (String)datareader["Descripcion"];
                dr[4] = (String)datareader["SituacionLaboral"];
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    //Actualizacion Fabian Urrutia 24-09-2014
    public DataTable GetDescripcionTipoCausal(int CodTipoCausal)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "PA_Get_TipocausalIngreso";
        sqlc.Parameters.Add("@CodTipoCausalIngreso", SqlDbType.Int, 4).Value = CodTipoCausal;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }
    //Actualizacion Fabian Urrutia 12-05-2014  
    public DataTable GetPeoresFormasdeTrabajo(int CodDiagnostico)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetPeoresFormasdeTrabajo + CodDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("PresentaAgresion", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("CodCategoria", typeof(int)));
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("ViveConExplotador", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String))); 
        dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaSituacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (DateTime)datareader["FechaDiagnostico"];
                dr[1] = (Boolean)datareader["PresentaAgresion"];
                dr[2] = (int)datareader["CodCategoria"];
                dr[3] = (int)datareader["CodPersonaRelacionada"];
                dr[4] = (Boolean)datareader["ViveConExplotador"];
                dr[5] = (int)datareader["CodTrabajador"];
                dr[6] = (String)datareader["Observacion"];
                dr[7] = (int)datareader["CodComuna"];
                dr[8] = (DateTime)datareader["FechaSituacion"];
                dr[10] = (int)datareader["CodRegion"];
                if (datareader["TipoRelacion"].ToString().Equals(""))
                {
                    dr[9] = 0;
                }
                else
                {
                    dr[9] = (int)datareader["TipoRelacion"];
                }
                dt.Rows.Add(dr);                        
            }
            catch{}
        }
        con.Desconectar();
        return dt;

        }
    public DataTable GetPeoresFormas(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetPeoresFormasTrabajo + ICodIE, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Definicion", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDiagnostico"];
                dr[1] = (DateTime)datareader["FechaDiagnostico"];
                dr[2] = (String)datareader["Definicion"];
                dt.Rows.Add(dr);                        
            }
            catch{}
        }
        con.Desconectar();
        return dt;

        }


    public DataTable GetHechosJudiciales(int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetHechosJudiciales + ICodIE + " Order by T2.FechaHechoJudicial desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodHechosJudiciales", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("MateriaCausa", typeof(String)));
        dt.Columns.Add(new DataColumn("Tribunal", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaHechoJudicial", typeof(DateTime)));
        while (datareader.Read())
        {

            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodHechosJudiciales"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (String)datareader["MateriaCausa"];
                dr[3] = (String)datareader["Tribunal"];
                dr[4] = (DateTime)datareader["FechaHechoJudicial"];
                dt.Rows.Add(dr);


            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    //  Fin Glillas Diagnosticos


    public DataTable GetDiagnosticoGeneral(string codproyecto, int ICodIE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
      
        con.ejecutar(Resources.Procedures.GetDiagnosticoGeneral + ICodIE, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTipoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDiagnostico"];
                dr[1] = (int)datareader["CodTipoDiagnosticoGlosa"];
                dr[2] = (int)datareader["CodNino"];
                dr[3] = (int)datareader["ICodIE"];
                dr[4] = (String)datareader["Descripcion"];
                dr[5] = (DateTime)datareader["FechaDiagnostico"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    /////////////////////////////////////////////MICHAEL INICIO INSCRITO FONADIS

    public DataTable GetInscritoFonadis(int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetInscritoFonadis + CodNino, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaAdoptabilidad", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdentidadConfirmada", typeof(bool)));
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        dt.Columns.Add(new DataColumn("Sexo", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEtnia", typeof(int)));
        dt.Columns.Add(new DataColumn("OficinaInscripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("AnoInscripcion", typeof(int)));
        dt.Columns.Add(new DataColumn("NumeroInscripcionCivil", typeof(String)));
        dt.Columns.Add(new DataColumn("AlergiasConocidas", typeof(String)));
        dt.Columns.Add(new DataColumn("InscritoFONADIS", typeof(bool)));
        dt.Columns.Add(new DataColumn("InscritoFONASA", typeof(bool)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];

                dr[1] = (DateTime)datareader["FechaAdoptabilidad"];
                dr[2] = (bool)datareader["IdentidadConfirmada"];
                dr[3] = (String)datareader["Rut"];
                dr[4] = (String)datareader["Sexo"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["Apellido_Paterno"];
                dr[7] = (String)datareader["Apellido_Materno"];
                dr[8] = (DateTime)datareader["FechaNacimiento"];
                dr[9] = (int)datareader["CodNacionalidad"];
                dr[10] = (int)datareader["CodEtnia"];
                dr[11] = (String)datareader["OficinaInscripcion"];
                dr[12] = (int)datareader["AnoInscripcion"];
                dr[13] = (String)datareader["NumeroInscripcionCivil"];
                dr[14] = (String)datareader["AlergiasConocidas"];
                dr[15] = (bool)datareader["InscritoFONADIS"];
                dr[16] = (bool)datareader["InscritoFONASA"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }




    /////////////////////////////////////FIN INSCRITO FONADIS




    public DataTable GetDiagnosticosDiscapacidad(string ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetDiagnosticosDiscapacidad + "@pICodIE";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        
        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("CodNivelDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionNivel", typeof(String)));
        //dt.Columns.Add(new DataColumn("FechaInscripcion", typeof(DateTime)));
        //dt.Columns.Add(new DataColumn("InscritoFonadis", typeof (int)));
        //dt.Columns.Add(new DataColumn("ICodDiagnosticoDiscapacidad", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();

                
                dr[0] = (int)datareader["ICodIE"];
                dr[1] = (int)datareader["ICodDiscapacidad"];
                dr[2] = (int)datareader["TipoDiscapacidad"];
                dr[3] = (DateTime)datareader["FechaDiagnostico"];
                dr[4] = (String)datareader["Observacion"];
                dr[5] = (int)datareader["CodNivelDiscapacidad"];
                dr[6] = (int)datareader["CodInstitucion"];
                dr[7] = (int)datareader["CodTrabajador"];
                dr[8] = (String)datareader["IndVigencia"];
                dr[9] = (DateTime)datareader["FechaActualizacion"];
                dr[10] = (int)datareader["IdUsuarioActualizacion"];
                dr[11] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dr[12] = (String)datareader["DescripcionTipo"];
                dr[13] = (String)datareader["DescripcionNivel"];
               // dr[14] = (DateTime)datareader["FechaInscripcion"];
               // dr[15] = (int)datareader["InscritoFonadis"];
               // dr[13] = (int)datareader["ICodDiagnosticoDiscapacidad"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetDiagnosticosDiscapacidadById(string ICodDiscapacidad/*ICodDiagnosticoDiscapacidad*/)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetDiagnosticosDiscapacidadById + "@pICodDiscapacidad";/*ICodDiagnosticoDiscapacidad*/
        listDbParameter.Add(Conexiones.CrearParametro("@pICodDiscapacidad", SqlDbType.Int, 4, Convert.ToInt32(ICodDiscapacidad)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodDiscapacidad"/*"ICodDiagnosticoDiscapacidad"*/, typeof(int)));
        //dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("CodNivelDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInscripcion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("InscritoFonadis", typeof (int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodDiscapacidad"/*"ICodDiagnosticoDiscapacidad"*/];
                //dr[1] = (int)datareader["CodDiagnostico"];
                dr[1] = (int)datareader["TipoDiscapacidad"];
                dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dr[3] = (String)datareader["Observacion"];
                dr[4] = (int)datareader["CodNivelDiscapacidad"];
                dr[5] = (int)datareader["CodInstitucion"];
                dr[6] = (int)datareader["CodTrabajador"];
                dr[7] = (String)datareader["IndVigencia"];
                dr[8] = (DateTime)datareader["FechaActualizacion"];
                dr[9] = (int)datareader["IdUsuarioActualizacion"];
                dr[10] = (DateTime)datareader["FechaInscripcion"];
                dr[11] = (int) datareader ["InscritoFonadis"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable callto_update_diagnosticosdiscapacidad_2f(int icoddiscapacidad, int icodie, int tipodiscapacidad, DateTime fechadiagnostico, string observacion, int codniveldiscapacidad, int icodtrabajador, int codinstitucion, int codtrabajador, string indvigencia, DateTime fechaactualizacion, int idusuarioactualizacion, DateTime fechainscripcion, int InscritoFonadis)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_DiagnosticosDiscapacidad_2F";
        sqlc.Parameters.Add("@ICodDiscapacidad", SqlDbType.Int, 4).Value = icoddiscapacidad;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@TipoDiscapacidad", SqlDbType.Int, 4).Value = tipodiscapacidad;
        sqlc.Parameters.Add("@FechaDiagnostico", SqlDbType.DateTime, 16).Value = fechadiagnostico;
        sqlc.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = observacion;
        sqlc.Parameters.Add("@CodNivelDiscapacidad", SqlDbType.Int, 4).Value = codniveldiscapacidad;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@FechaInscripcion", SqlDbType.DateTime, 16).Value = fechainscripcion;
        sqlc.Parameters.Add("@InscritoFonadis", SqlDbType.Int, 4).Value = InscritoFonadis;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }







    public void Update_DiagnosticosDiscapacidad(
    int ICodDiagnosticoDiscapacidad, int CodDiagnostico, int TipoDiscapacidad, DateTime FechaDiagnostico, 
        String Observacion, int CodNivelDiscapacidad, int CodInstitucion, int CodTrabajador, 
        String IndVigencia, DateTime FechaActualizacion, DateTime Fechainscripcion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodDiagnosticoDiscapacidad", SqlDbType.Int, 4, ICodDiagnosticoDiscapacidad) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@TipoDiscapacidad", SqlDbType.Int, 4, TipoDiscapacidad) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@CodNivelDiscapacidad", SqlDbType.Int, 4, CodNivelDiscapacidad) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion), 
        con.parametros("@Fechainscripcion", SqlDbType.DateTime, 16, Fechainscripcion) 
		};
        con.ejecutarProcedimiento("Update_DiagnosticosDiscapacidad", parametros, out datareader);
        con.Desconectar();

    }



    public void Update_Etnia(int CodNino, int Etnia)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@Etnia", SqlDbType.Int, 4, Etnia) , 
		
		};
        con.ejecutarProcedimiento("Update_Etnianino", parametros, out datareader);
        con.Desconectar();

    }
    
    public void Update_InsFonasa(int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		
		
		};
        con.ejecutarProcedimiento("Update_InsFonasanino", parametros, out datareader);
        con.Desconectar();

    }

    public void Update_noInsFonasa(int CodNino)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		
		
		};
        con.ejecutarProcedimiento("Update_noInsFonasanino", parametros, out datareader);
        con.Desconectar();

    }



    public DataTable GetHechosSalud(string ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetHechosSalud + "@pICodIE";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodHechosdeSalud", typeof(int)));
       // dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("CodAtencionHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("CodLugarHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("DescripcionHecho", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionLugar", typeof(String))); 
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodHechosdeSalud"];
               // dr[1] = (int)datareader["CodDiagnostico"];
                dr[1] = (DateTime)datareader["FechaDiagnostico"];
                dr[2] = (int)datareader["CodHechoSalud"];
                dr[3] = (int)datareader["CodAtencionHechoSalud"];
                dr[4] = (int)datareader["CodLugarHechoSalud"];
                dr[5] = (int)datareader["CodInstitucion"];
                dr[6] = (int)datareader["CodTrabajador"];
                dr[7] = (String)datareader["Observacion"];
                dr[8] = (String)datareader["IndVigencia"];
                dr[9] = (DateTime)datareader["FechaActualizacion"];
                dr[10] = (int)datareader["IdUsuarioActualizacion"];
                dr[11] = (String)datareader["DescripcionHecho"];
                dr[12] = (String)datareader["DescripcionTipo"];
                dr[13] = (String)datareader["DescripcionLugar"];
                dr[14] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetHechosSaludById(string ICodHechosdeSalud)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetHechosSaludById + "@pICodHechosdeSalud";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodHechosdeSalud", SqlDbType.Int, 4, Convert.ToInt32(ICodHechosdeSalud)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodHechosdeSalud", typeof(int)));
        //dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE",typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("CodAtencionHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("CodLugarHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionHecho", typeof(String)));
        dt.Columns.Add(new DataColumn("DescripcionLugar", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodHechosdeSalud"];
                //dr[1] = (int)datareader["CodDiagnostico"];
                dr[1] = (int)datareader["ICodIE"];
                dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dr[3] = (int)datareader["CodHechoSalud"];
                dr[4] = (int)datareader["CodAtencionHechoSalud"];
                dr[5] = (int)datareader["CodLugarHechoSalud"];
                dr[6] = (int)datareader["CodInstitucion"];
                dr[7] = (int)datareader["CodTrabajador"];
                dr[8] = (String)datareader["Observacion"];
                dr[9] = (String)datareader["IndVigencia"];
                dr[10] = (DateTime)datareader["FechaActualizacion"];
                dr[11] = (int)datareader["IdUsuarioActualizacion"];
                dr[12] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dr[13] = (String)datareader["DescripcionTipo"];
                dr[14] = (String)datareader["DescripcionHecho"];
                dr[15] = (String)datareader["DescripcionLugar"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable callto_update_hechossalud_2f(int icodhechosdesalud, int icodie, DateTime fechadiagnostico, int codhechosalud, int codatencionhechosalud, int codlugarhechosalud, int icodtrabajador, int codinstitucion, int codtrabajador, string observacion, string indvigencia, DateTime fechaactualizacion, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_HechosSalud_2F";
        sqlc.Parameters.Add("@ICodHechosdeSalud", SqlDbType.Int, 4).Value = icodhechosdesalud;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@FechaDiagnostico", SqlDbType.DateTime, 16).Value = fechadiagnostico;
        sqlc.Parameters.Add("@CodHechoSalud", SqlDbType.Int, 4).Value = codhechosalud;
        sqlc.Parameters.Add("@CodAtencionHechoSalud", SqlDbType.Int, 4).Value = codatencionhechosalud;
        sqlc.Parameters.Add("@CodLugarHechoSalud", SqlDbType.Int, 4).Value = codlugarhechosalud;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = observacion;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public void Update_HechosSalud(
    int ICodHechosdeSalud, /*int CodDiagnostico*/ int ICodIE, DateTime FechaDiagnostico, int CodHechoSalud, int CodAtencionHechoSalud, int CodLugarHechoSalud, int CodInstitucion, int CodTrabajador, String Observacion, String IndVigencia, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodHechosdeSalud", SqlDbType.Int, 4, ICodHechosdeSalud) , 
		//con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) ,
        con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@CodHechoSalud", SqlDbType.Int, 4, CodHechoSalud) , 
		con.parametros("@CodAtencionHechoSalud", SqlDbType.Int, 4, CodAtencionHechoSalud) , 
		con.parametros("@CodLugarHechoSalud", SqlDbType.Int, 4, CodLugarHechoSalud) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_HechosSalud", parametros, out datareader);
        con.Desconectar();

    }

    public DataTable GetNinosEnfermedadesCronicas(string ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetNinosEnfermedadesCronicas + "@pICodIE";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodEnfermedadCronica", typeof(int)));
       // dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE",typeof(int)));
        dt.Columns.Add(new DataColumn("CodEnfermedadCronica", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioDiagnostico", typeof(DateTime)));
       // dt.Columns.Add(new DataColumn("FechaTerminoDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodEnfermedadCronica"];
              //  dr[1] = (int)datareader["CodDiagnostico"];
                dr[1] = (int)datareader["ICodIE"];
                dr[2] = (int)datareader["CodEnfermedadCronica"];
                dr[3] = (DateTime)datareader["FechaInicioDiagnostico"];
              //  dr[4] = (DateTime)datareader["FechaTerminoDiagnostico"];
                dr[4] = (String)datareader["Observacion"];
                dr[5] = (String)datareader["IndVigencia"];
                dr[6] = (int)datareader["CodInstitucion"];
                dr[7] = (int)datareader["CodTrabajador"];
                dr[8] = (DateTime)datareader["FechaActualizacion"];
                dr[9] = (int)datareader["IdUsuarioActualizacion"];
                dr[10] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dr[11] = (String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetNinosEnfermedadesCronicasById(string ICodEnfermedadCronica)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetNinosEnfermedadesCronicasById + "@pICodEnfermedadCronica";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodEnfermedadCronica", SqlDbType.Int, 4, Convert.ToInt32(ICodEnfermedadCronica)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodEnfermedadCronica", typeof(int)));
       // dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("CodEnfermedadCronica", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioDiagnostico", typeof(DateTime)));
        //dt.Columns.Add(new DataColumn("FechaTerminoDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodEnfermedadCronica"];
                dr[1] = (int)datareader["ICodIE"];
                dr[2] = (int)datareader["CodEnfermedadCronica"];
                dr[3] = (DateTime)datareader["FechaInicioDiagnostico"];
               // dr[4] = (DateTime)datareader["FechaTerminoDiagnostico"];
                dr[4] = (String)datareader["Observacion"];
                dr[5] = (String)datareader["IndVigencia"];
                dr[6] = (int)datareader["CodInstitucion"];
                dr[7] = (int)datareader["CodTrabajador"];
                dr[8] = (DateTime)datareader["FechaActualizacion"];
                dr[9] = (int)datareader["IdUsuarioActualizacion"];
                dr[10] = (String)datareader["Paterno"] + " " + (String)datareader["Materno"] + " " + (String)datareader["Nombres"];
                dr[11] = (String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable callto_update_ninosenfermedadescronicas_2f(int icodenfermedadcronica, int icodie, int codenfermedadcronica, DateTime fechainiciodiagnostico,/* DateTime fechaterminodiagnostico,*/ string observacion, string indvigencia, int icodtrabajador, int codinstitucion, int codtrabajador, DateTime fechaactualizacion, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_NinosEnfermedadesCronicas_2F";
        sqlc.Parameters.Add("@ICodEnfermedadCronica", SqlDbType.Int, 4).Value = icodenfermedadcronica;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodEnfermedadCronica", SqlDbType.Int, 4).Value = codenfermedadcronica;
        sqlc.Parameters.Add("@FechaInicioDiagnostico", SqlDbType.DateTime, 16).Value = fechainiciodiagnostico;
        //sqlc.Parameters.Add("@FechaTerminoDiagnostico", SqlDbType.DateTime, 16).Value = fechaterminodiagnostico;
        sqlc.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = observacion;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }




    public void Update_NinosEnfermedadesCronicas(
    int ICodEnfermedadCronica, int CodDiagnostico, int CodEnfermedadCronica, DateTime FechaInicioDiagnostico, 
    DateTime FechaTerminoDiagnostico, String Observacion, String IndVigencia, int CodInstitucion,
    int CodTrabajador, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodEnfermedadCronica", SqlDbType.Int, 4, ICodEnfermedadCronica) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodEnfermedadCronica", SqlDbType.Int, 4, CodEnfermedadCronica) , 
		con.parametros("@FechaInicioDiagnostico", SqlDbType.DateTime, 16, FechaInicioDiagnostico) , 
		con.parametros("@FechaTerminoDiagnostico", SqlDbType.DateTime, 16, FechaTerminoDiagnostico) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_NinosEnfermedadesCronicas", parametros, out datareader);
        con.Desconectar();

    }



        public int Insert_DiagnosticosDiscapacidad(
        int ICodIE,
        int TipoDiscapacidad,
        DateTime FechaDiagnostico,
        String Observacion,
        int CodNivelDiscapacidad,
        int ICodTrabajador,
        int CodInstitucion,
        int CodTrabajador,
        String IndVigencia,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion,
        DateTime Fechainscripcion,
        int InscritoFonadis)
        {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		
        con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE),
        con.parametros("@TipoDiscapacidad",SqlDbType.Int, 4, TipoDiscapacidad),
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@CodNivelDiscapacidad", SqlDbType.Int, 4, CodNivelDiscapacidad) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion), 
        con.parametros("@Fechainscripcion", SqlDbType.DateTime, 16, Fechainscripcion), 
        con.parametros("@InscritoFonadis", SqlDbType.Int, 4, InscritoFonadis) 
		};
        con.ejecutarProcedimiento("Insert_DiagnosticosDiscapacidad", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }


    //public int Insert_fonad( byte InscritoFonadis)
    //{
        
    //    byte returnvalue = 0;
    //    DbDataReader datareader = null;
    //     Conexiones con = new Conexiones();
    //    DbParameter[] parametros = {
        
    //    con.parametros("@InscritoFonadis", SqlDbType.Bit, 1, InscritoFonadis) 
		
    //    };
    //    con.ejecutarProcedimiento("Insert_fonad", parametros, out datareader);
    //    if (datareader.Read())
    //    {
    //        returnvalue = Convert.ToByte(datareader["identidad"]);
    //    }
    //    con.Desconectar();
    //    return returnvalue;
    //}

    public void Insert_Fonad( int InscritoFonadis, int CodNino)
    {
        Convert.ToByte(InscritoFonadis);
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@InscritoFonadis", SqlDbType.Bit, 1, InscritoFonadis) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) ,
		
		};
        con.ejecutarProcedimiento("Insert_Fonad", parametros, out datareader);
        con.Desconectar();

    }





    public int Insert_DiagnosticoGeneral(
    int CodTipoDiagnostico, int CodNino, int ICodIE, DateTime FechaDiagnostico)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodTipoDiagnosticoGlosa", SqlDbType.Int, 4, CodTipoDiagnostico) , 
		con.parametros("@CodNino", SqlDbType.Int, 4, CodNino) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) 
		};
        con.ejecutarProcedimiento("Insert_DiagnosticoGeneral", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_DiagnosticoGeneralTransaccional(SqlTransaction sqlt,int CodTipoDiagnostico, int CodNino, int ICodIE, DateTime FechaDiagnostico)
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_DiagnosticoGeneral", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTipoDiagnosticoGlosa", SqlDbType.Int, 4, CodTipoDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTipoDiagnosticoGlosa", SqlDbType.Int, 4, CodTipoDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodNino", SqlDbType.Int, 4, CodNino));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodIE", SqlDbType.Int, 4, ICodIE));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        sqlc.Transaction = sqlt;

        DbDataReader datareader = null;
        //Convert
        datareader = sqlc.ExecuteReader();

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        return returnvalue;
    }

    public int Insert_HechosSalud(
    /*int CodDiagnostico,*/ DateTime FechaDiagnostico,int ICodIE, int CodHechoSalud,
        int CodAtencionHechoSalud, int CodLugarHechoSalud,int ICodTrabajador, int CodInstitucion,
        int CodTrabajador, String Observacion, String IndVigencia, DateTime FechaActualizacion,
        int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		//con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
        con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE),
		con.parametros("@CodHechoSalud", SqlDbType.Int, 4, CodHechoSalud) , 
		con.parametros("@CodAtencionHechoSalud", SqlDbType.Int, 4, CodAtencionHechoSalud) , 
		con.parametros("@CodLugarHechoSalud", SqlDbType.Int, 4, CodLugarHechoSalud) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_HechosSalud", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_NinosEnfermedadesCronicas(
    /*int CodDiagnostico,*/ int CodEnfermedadCronica, int ICodIE, DateTime FechaInicioDiagnostico, /*DateTime FechaTerminoDiagnostico,*/
        String Observacion, String IndVigencia, int ICodTrabajador, int CodInstitucion, int CodTrabajador,
        DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		//con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodEnfermedadCronica", SqlDbType.Int, 4, CodEnfermedadCronica) , 
        con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE),
		con.parametros("@FechaInicioDiagnostico", SqlDbType.DateTime, 16, FechaInicioDiagnostico) , 
		//con.parametros("@FechaTerminoDiagnostico", SqlDbType.DateTime, 16, FechaTerminoDiagnostico) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_NinosEnfermedadesCronicas", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    //Felipe Ormzabal

    
    public int Insert_DelitosHechosJudiciales(int CodDelito, DateTime FechaHechoJudicial)
    {
    
    int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		//con.parametros("@IcodHechosJudiciales", SqlDbType.Int, 4, IcodHechosJudiciales) , 
		con.parametros("@CodDelito", SqlDbType.Int, 4, CodDelito) , 
        con.parametros("@FechaHechoJudicial", SqlDbType.DateTime, 4, FechaHechoJudicial),
		
		};
        con.ejecutarProcedimiento("Insert_Delitoshechosjudiciales", parametros, out datareader);
        //if (datareader.Read())
        //{
        //    returnvalue = Convert.ToInt32(datareader["identidad"]);
        //}
        con.Desconectar();
        return returnvalue;
     
    
    }
    
   
    public int Insert_CapacitacionNino( 
        int CodDiagnostico  
        ,int CodAreaCapacitacion 
        ,int TipoCapacitacion 
        ,int CodEstadoCapacitacion ,
        int CodOrganismoCapacitador
        ,String Descripcion  
        ,int HorasCurso 
        ,DateTime FechaInicioCapacitacion ,
        DateTime FechaTerminoCapacitacion 
        ,String Termino 
        ,DateTime FechaActualizacion 
        , int IdUsuarioActualizacion) 
           
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodAreaCapacitacion", SqlDbType.Int, 4, CodAreaCapacitacion) , 
		con.parametros("@TipoCapacitacion", SqlDbType.Int, 4, TipoCapacitacion) , 
		con.parametros("@CodEstadoCapacitacion", SqlDbType.Int, 4, CodEstadoCapacitacion) , 
		con.parametros("@CodOrganismoCapacitador", SqlDbType.Int, 4, CodOrganismoCapacitador) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 100, Descripcion) , 
		con.parametros("@HorasCurso", SqlDbType.Int, 4, HorasCurso),
        con.parametros("@FechaInicioCapacitacion", SqlDbType.DateTime, 16, FechaInicioCapacitacion),
        con.parametros("@FechaTerminoCapacitacion", SqlDbType.DateTime, 16, FechaTerminoCapacitacion) ,
        con.parametros("@Termino", SqlDbType.Char, 1, Termino), 
        con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion),
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
        


		};
        con.ejecutarProcedimiento("Insert_CapacitacionNino", parametros, out datareader);
        //if (datareader.Read())
        //{
        //    returnvalue = Convert.ToInt32(datareader["identidad"]);
        //}
        con.Desconectar();
        return returnvalue;
        
    }




    public int Insert_SituacionLaboralNino(/*int ICodSituacionLaboral ,*/ int CodDiagnostico ,			
                DateTime FechaSituacionLaboral ,int	CodAreaInsercionLaboral, int CodSituacionLaboral, String DireccionLaboral,	
                String TelefonoLaboral ,String PersonaReferencia ,int CodigoPostal,String Email, DateTime FechaActualizacion,
                int IdUsuarioActualizacion, int DiagnosticoOcupacional)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		//con.parametros("@ICodSituacionLaboral", SqlDbType.Int, 4, ICodSituacionLaboral) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaSituacionLaboral", SqlDbType.DateTime, 16, FechaSituacionLaboral) , 
		con.parametros("@CodAreaInsercionLaboral", SqlDbType.Int, 4, CodAreaInsercionLaboral) , 
		con.parametros("@CodSituacionLaboral", SqlDbType.Int, 4, CodSituacionLaboral) , 
		con.parametros("@DireccionLaboral", SqlDbType.VarChar, 100, DireccionLaboral) , 
		con.parametros("@TelefonoLaboral", SqlDbType.VarChar, 30, TelefonoLaboral) , 
		con.parametros("@PersonaReferencia", SqlDbType.VarChar, 100, PersonaReferencia) , 
		con.parametros("@CodigoPostal", SqlDbType.Int, 4, CodigoPostal),
        con.parametros("@Email", SqlDbType.VarChar, 100, Email),
        con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) ,
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@DiagnosticoOcupacional", SqlDbType.Int, 4, DiagnosticoOcupacional) 

		};
        con.ejecutarProcedimiento("Insert_SituacionLaboralNino", parametros, out datareader);
        con.Desconectar();
        return returnvalue;
    }


    public int Insert_DiagnosticosDroga(
        int CodDiagnostico, int CodDroga, DateTime FechaDiagnostico,
        int IdUsuarioActualizacion, int TipoConsumoDroga, int CodInstitucion,
        String Observacion, int ICodTrabajador, DateTime FechaActualizacion, int SeAtiendeCONACE)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodDroga", SqlDbType.Int, 4, CodDroga) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@TipoConsumoDroga", SqlDbType.Int, 4, TipoConsumoDroga) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion), 
        con.parametros("@SeAtiendeCONACE",SqlDbType.Int,4,SeAtiendeCONACE)

		};
        con.ejecutarProcedimiento("Insert_DiagnosticosDroga", parametros, out datareader);
        con.Desconectar();
        return returnvalue;
    }

    // Felipe Ormazabal.
    public int Insert_DiagnosticosEscolar(
    int CodDiagnostico, 
        DateTime FechaCreacion, 
        int CodEscolaridad, 
        DateTime FechaDiagnostico,
        int ICodTrabajador, 
        int CodInstitucion_Entrevistador, 
        int CodTrabajador_Entrevistador, 
        int TipoAsistenciaEscolar, 
        int AnoUltimoCursoAprobado, 
        String Observaciones, 
        bool AlIngreso, 
        DateTime FechaActualizacion, 
        int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion) , 
		con.parametros("@CodEscolaridad", SqlDbType.Int, 4, CodEscolaridad) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion_Entrevistador", SqlDbType.Int, 4, CodInstitucion_Entrevistador) , 
		con.parametros("@CodTrabajador_Entrevistador", SqlDbType.Int, 4, CodTrabajador_Entrevistador) , 
		con.parametros("@TipoAsistenciaEscolar", SqlDbType.Int, 4, TipoAsistenciaEscolar) , 
		con.parametros("@AnoUltimoCursoAprobado", SqlDbType.Int, 4, AnoUltimoCursoAprobado) , 
		con.parametros("@Observaciones", SqlDbType.VarChar, 200, Observaciones) , 
		con.parametros("@AlIngreso", SqlDbType.Int, 1, AlIngreso) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_DiagnosticosEscolar", parametros, out datareader);
        con.Desconectar();
        return returnvalue;
    }

    public void Insert_DiagnosticosEscolarTransaccional(SqlTransaction sqlt,int CodDiagnostico, DateTime FechaCreacion,int CodEscolaridad, DateTime FechaDiagnostico,
        int ICodTrabajador,int CodInstitucion_Entrevistador,int CodTrabajador_Entrevistador, int TipoAsistenciaEscolar, 
        int AnoUltimoCursoAprobado, String Observaciones, bool AlIngreso, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {

        //int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_DiagnosticosEscolar", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;
        //DbDataReader datareader = null;

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaCreacion", SqlDbType.DateTime, 16, FechaCreacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodEscolaridad", SqlDbType.Int, 4, CodEscolaridad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodInstitucion_Entrevistador", SqlDbType.Int, 4, CodInstitucion_Entrevistador));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTrabajador_Entrevistador", SqlDbType.Int, 4, CodTrabajador_Entrevistador));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@TipoAsistenciaEscolar", SqlDbType.Int, 4, TipoAsistenciaEscolar));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@AnoUltimoCursoAprobado", SqlDbType.Int, 4, AnoUltimoCursoAprobado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Observaciones", SqlDbType.VarChar, 200, Observaciones));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@AlIngreso", SqlDbType.Int, 4, AlIngreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion));

        //datareader = sqlc.ExecuteReader();

        //if (datareader.Read())
        //{
        //    returnvalue = Convert.ToInt32(datareader["identidad"]);
        //}

        sqlc.ExecuteNonQuery();
        //sqlc.Connection.Close();
    }

    //Felipe Ormazabal
    public int Insert_DiagnosticosMaltrato(
int CodDiagnostico, DateTime FechaDiagnostico, bool PresentaMaltrato, int CodMaltrato, bool ConoceMaltratador, int CodPersonaRelacionada, bool ViveConAgresor, bool ExisteQuerellaSENAME, int ICodTrabajador, int CodInstitucion, int CodTrabajador, String Observacion, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		
        con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@PresentaMaltrato", SqlDbType.Int, 1, PresentaMaltrato) , 
		con.parametros("@CodMaltrato", SqlDbType.Int, 4, CodMaltrato) , 
		con.parametros("@ConoceMaltratador", SqlDbType.Int, 1, ConoceMaltratador) , 
		con.parametros("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada) , 
		con.parametros("@ViveConAgresor", SqlDbType.Int, 1, ViveConAgresor) , 
		con.parametros("@ExisteQuerellaSENAME", SqlDbType.Int, 1, ExisteQuerellaSENAME) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_DiagnosticosMaltrato", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }


    //Felipe Ormazabal - Actualizacion Fabian Urrutia 12-05-2014
    public int Insert_DiagnosticosPeoresFormaTrabajo(
    int CodDiagnostico, 
        int CodCategoria, 
        DateTime FechaDiagnostico, 
        bool PresentaAgresion, 
        int CodPersonaRelacionada, 
        bool ViveConExplotador, 
        String Observacion, 
        int ICodTrabajador, 
        int CodInstitucion, 
        int CodTrabajador, 
        DateTime FechaActualizacion, 
        int IdUsuarioActualizacion, 
        int CodComuna, 
        DateTime FechaSituacion, 
        int TipoRelacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodCategoria", SqlDbType.Int, 4, CodCategoria) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@PresentaAgresion", SqlDbType.Int, 1, PresentaAgresion) , 
		con.parametros("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada) , 
		con.parametros("@ViveConExplotador", SqlDbType.Int, 1, ViveConExplotador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@CodComuna", SqlDbType.Int, 4, CodComuna),
        con.parametros("@FechaSituacion", SqlDbType.DateTime, 16, FechaSituacion),
        con.parametros("@TipoRelacion", SqlDbType.Int, 4, TipoRelacion)
		};      
        con.ejecutarProcedimiento("Insert_DiagnosticosPeoresFormaTrabajo", parametros, out datareader);
        con.Desconectar();
        return returnvalue;
    }

    //Felipe Ormazabal

    //comienzo update Diagnosticos

    public void Update_DiagnosticosMaltrato(
    int ICodMaltrato, int CodDiagnostico, DateTime FechaDiagnostico, bool PresentaMaltrato, 
    int CodMaltrato, bool ConoceMaltratador, int CodPersonaRelacionada, bool ViveConAgresor, 
    bool ExisteQuerellaSENAME, int ICodTrabajador, int CodInstitucion, int CodTrabajador, 
    String Observacion, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodMaltrato", SqlDbType.Int, 4, ICodMaltrato) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@PresentaMaltrato", SqlDbType.Int, 1, PresentaMaltrato) , 
		con.parametros("@CodMaltrato", SqlDbType.Int, 4, CodMaltrato) , 
		con.parametros("@ConoceMaltratador", SqlDbType.Int, 1, ConoceMaltratador) , 
		con.parametros("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada) , 
		con.parametros("@ViveConAgresor", SqlDbType.Int, 1, ViveConAgresor) , 
		con.parametros("@ExisteQuerellaSENAME", SqlDbType.Int, 1, ExisteQuerellaSENAME) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_DiagnosticosMaltrato", parametros, out datareader);
        con.Desconectar();

    }

    
    public void Update_DiagnosticosDroga(
    int ICodDroga, int CodDiagnostico, int CodDroga, DateTime FechaDiagnostico, int IdUsuarioActualizacion, 
    int TipoConsumoDroga, int ICodTrabajador, int CodInstitucion, String Observacion, int CodTrabajador,
    DateTime FechaActualizacion, int SeAtiendeCONACE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodDroga", SqlDbType.Int, 4, ICodDroga) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodDroga", SqlDbType.Int, 4, CodDroga) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@TipoConsumoDroga", SqlDbType.Int, 4, TipoConsumoDroga) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion),
        con.parametros("@SeAtiendeCONACE", SqlDbType.Int, 4, SeAtiendeCONACE)
		};
        con.ejecutarProcedimiento("Update_DiagnosticosDroga", parametros, out datareader);
        con.Desconectar();

    }

    public void Update_DiagnosticosPsicologico(int ICodPsicologico,
    int CodDiagnostico, int CodInstrumentoDiagnostico, int CodMedicionesDiagnosticas, 
    DateTime FechaDiagnostico, int ICodTrabajador, int CodInstitucion, int CodTrabajador, int ValorMedicion,
    String Observaciones, DateTime FechaActualizacion, int IdUsuarioActualizacion, int CodTipoDiagnostico, int CodTrastornoMental)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodPsicologico", SqlDbType.Int, 4, ICodPsicologico) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodInstrumentoDiagnostico", SqlDbType.Int, 4, CodInstrumentoDiagnostico) , 
		con.parametros("@CodMedicionesDiagnosticas", SqlDbType.Int, 4, CodMedicionesDiagnosticas) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@ValorMedicion", SqlDbType.Int, 4, ValorMedicion) , 
		con.parametros("@Observaciones", SqlDbType.VarChar, 200, Observaciones) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@CodTipoDiagnosticoPsi", SqlDbType.Int, 4, CodTipoDiagnostico),
        con.parametros("@CodTranstornoMental", SqlDbType.Int, 4, CodTrastornoMental)
		};
        con.ejecutarProcedimiento("Update_DiagnosticosPsicologico", parametros, out datareader);
        con.Desconectar();

    }

    public void Update_DiagnosticosSocial(
    int ICodSocial, int CodDiagnostico, DateTime FechaDiagnostico, int NumeroDiagnostico, 
    int CodSituacionEspecial, int CodSituacionSocioEconomica, int ICodTrabajador, int CodInstitucion, 
    int CodTrabajador, int CodSituacionCalle, String Observacion, int AnoMesInicioVivirCalle, 
    int NumeroPersonasHogar, int NumeroPersonasSitio, int NumeroHermanosVivenConEl, int NumeroHermanos, 
    int PuntajeCAS, DateTime FechaPuntajeCAS, int CodSituacionTuicion, int CodEstadoAbandono,
    int CodUltimoEstadoAbandono, DateTime FechaActualizacion, int IdUsuarioActualizacion, int Etnia, 
    String Fonasa, String ChileSolidario, String ChileCreceContigo, DateTime FechaFonasa, 
    DateTime FechaChileSolidario, DateTime FechaChileCreceContigo,
    bool AdolescenteEmbarazada ,
    int NumeroMesesGestacion ,
    bool EmbarazoAbusoViolacion ,
    bool AdolescentePadreMadre ,
    int NumeroHijos ,
    bool HijosAbusoViolacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodSocial", SqlDbType.Int, 4, ICodSocial) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@NumeroDiagnostico", SqlDbType.Int, 4, NumeroDiagnostico) , 
		con.parametros("@CodSituacionEspecial", SqlDbType.Int, 4, CodSituacionEspecial) , 
		con.parametros("@CodSituacionSocioEconomica", SqlDbType.Int, 4, CodSituacionSocioEconomica) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@CodSituacionCalle", SqlDbType.Int, 4, CodSituacionCalle) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@AnoMesInicioVivirCalle", SqlDbType.Int, 4, AnoMesInicioVivirCalle) , 
		con.parametros("@NumeroPersonasHogar", SqlDbType.Int, 4, NumeroPersonasHogar) , 
		con.parametros("@NumeroPersonasSitio", SqlDbType.Int, 4, NumeroPersonasSitio) , 
		con.parametros("@NumeroHermanosVivenConEl", SqlDbType.Int, 4, NumeroHermanosVivenConEl) , 
		con.parametros("@NumeroHermanos", SqlDbType.Int, 4, NumeroHermanos) , 
		con.parametros("@PuntajeCAS", SqlDbType.Int, 4, PuntajeCAS) , 
		con.parametros("@FechaPuntajeCAS", SqlDbType.DateTime, 16, FechaPuntajeCAS) , 
		con.parametros("@CodSituacionTuicion", SqlDbType.Int, 4, CodSituacionTuicion) , 
		con.parametros("@CodEstadoAbandono", SqlDbType.Int, 4, CodEstadoAbandono) , 
		con.parametros("@CodUltimoEstadoAbandono", SqlDbType.Int, 4, CodUltimoEstadoAbandono) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion), 
        con.parametros("@Etnia", SqlDbType.Int, 4, Etnia),
        con.parametros("@Fonasa", SqlDbType.VarChar, 50, Fonasa),
        con.parametros("@ChileSolidario", SqlDbType.VarChar, 50, ChileSolidario),
        con.parametros("@ChileCreceContigo", SqlDbType.VarChar, 50, ChileCreceContigo),
        con.parametros("@FechaFonasa", SqlDbType.DateTime, 16, FechaFonasa),
        con.parametros("@FechaChileSolidario", SqlDbType.DateTime, 16, FechaChileSolidario),
        con.parametros("@FechaChileCreceContigo", SqlDbType.DateTime, 16, FechaChileCreceContigo),

        con.parametros("@AdolescenteEmbarazada", SqlDbType.Int, 1, AdolescenteEmbarazada) ,
        con.parametros("@NumeroMesesGestacion", SqlDbType.Int, 2, NumeroMesesGestacion) , 
        con.parametros("@EmbarazoAbusoViolacion", SqlDbType.Int, 1, EmbarazoAbusoViolacion) , 
        con.parametros("@AdolescentePadreMadre", SqlDbType.Int, 1, AdolescentePadreMadre) , 
        con.parametros("@NumeroHijos", SqlDbType.Int, 2, NumeroHijos) , 
        con.parametros("@HijosAbusoViolacion", SqlDbType.Int, 1, HijosAbusoViolacion) 
		};


        con.ejecutarProcedimiento("Update_DiagnosticosSocial", parametros, out datareader);
        con.Desconectar();

    } 

    public void Update_CapacitacionNino(
    int ICodCapacitacionNino, 
        int CodDiagnostico, 
        int CodAreaCapacitacion, 
    int TipoCapacitacion, 
        int CodEstadoCapacitacion, 
        int CodOrganismoCapacitador, 
        String Descripcion, 
    int HorasCurso, 
        DateTime FechaInicioCapacitacion, 
        DateTime FechaTerminoCapacitacion, 
        String Termino, 
    DateTime FechaActualizacion, 
        int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodCapacitacionNino", SqlDbType.Int, 4, ICodCapacitacionNino) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodAreaCapacitacion", SqlDbType.Int, 4, CodAreaCapacitacion) , 
		con.parametros("@TipoCapacitacion", SqlDbType.Int, 4, TipoCapacitacion) , 
		con.parametros("@CodEstadoCapacitacion", SqlDbType.Int, 4, CodEstadoCapacitacion) , 
		con.parametros("@CodOrganismoCapacitador", SqlDbType.Int, 4, CodOrganismoCapacitador) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 100, Descripcion) , 
		con.parametros("@HorasCurso", SqlDbType.Int, 4, HorasCurso) , 
		con.parametros("@FechaInicioCapacitacion", SqlDbType.DateTime, 16, FechaInicioCapacitacion) , 
		con.parametros("@FechaTerminoCapacitacion", SqlDbType.DateTime, 16, FechaTerminoCapacitacion) , 
		con.parametros("@Termino", SqlDbType.Char, 1, Termino) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion)
		};
        con.ejecutarProcedimiento("Update_CapacitacionNino", parametros, out datareader);
        con.Desconectar();

    }


    public void Update_SituacionLaboralNino(
    int ICodSituacionLaboral, int CodDiagnostico, DateTime FechaSituacionLaboral, 
    int CodAreaInsercionLaboral, int CodSituacionLaboral, String DireccionLaboral, 
    String TelefonoLaboral, String PersonaReferencia, int CodigoPostal, String Email,
    DateTime FechaActualizacion, int IdUsuarioActualizacion, int DiagnosticoOcupacional)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodSituacionLaboral", SqlDbType.Int, 4, ICodSituacionLaboral) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaSituacionLaboral", SqlDbType.DateTime, 16, FechaSituacionLaboral) , 
		con.parametros("@CodAreaInsercionLaboral", SqlDbType.Int, 4, CodAreaInsercionLaboral) , 
		con.parametros("@CodSituacionLaboral", SqlDbType.Int, 4, CodSituacionLaboral) , 
		con.parametros("@DireccionLaboral", SqlDbType.VarChar, 100, DireccionLaboral) , 
		con.parametros("@TelefonoLaboral", SqlDbType.VarChar, 30, TelefonoLaboral) , 
		con.parametros("@PersonaReferencia", SqlDbType.VarChar, 100, PersonaReferencia) , 
		con.parametros("@CodigoPostal", SqlDbType.Int, 4, CodigoPostal) , 
		con.parametros("@Email", SqlDbType.VarChar, 100, Email) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) ,
        con.parametros("@DiagnosticoOcupacional", SqlDbType.Int, 4, DiagnosticoOcupacional) 
		};
        con.ejecutarProcedimiento("Update_SituacionLaboralNino", parametros, out datareader);
        con.Desconectar();

    }

    public int Insert_HechosJudiciales( int CodDiagnostico, DateTime FechaHechoJudicial,
       int CodTribunal,/*int CodMateriaCausa*/int CodCausalIngreso, String RolCausa, int TieneQuerellaSename, String Descripcion,
       int Victima, int Acusado, int TieneDefensor, String ICodTrabajador, int CodInstitucion,
       int CodTrabajador, DateTime FechaActualizacion, int IdUsuarioActualizacion, String Ruc, String Rit)
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaHechoJudicial", SqlDbType.DateTime, 8, FechaHechoJudicial) , 
		con.parametros("@CodTribunal", SqlDbType.Int, 4, CodTribunal) , 
		con.parametros("@CodCausalIngreso", SqlDbType.Int, 4, CodCausalIngreso) , 
		con.parametros("@RolCausa", SqlDbType.VarChar, 50, RolCausa) , 
		con.parametros("@TieneQuerellaSename", SqlDbType.Bit, 1, TieneQuerellaSename) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 100, Descripcion) , 
		con.parametros("@Victima", SqlDbType.Bit, 1, Victima),
        con.parametros("@Acusado", SqlDbType.Bit, 1, Acusado),
        con.parametros("@TieneDefensor", SqlDbType.Bit, 1, TieneDefensor) ,
        con.parametros("@ICodTrabajador", SqlDbType.Char, 10, ICodTrabajador), 
        con.parametros("@CodInstitucion", SqlDbType.Int, 16, CodInstitucion),
        con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador),
        con.parametros("@FechaActualizacion", SqlDbType.DateTime, 8, FechaActualizacion),
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@Ruc", SqlDbType.VarChar, 50, Ruc),
        con.parametros("@Rit", SqlDbType.VarChar, 50, Rit)
     };
        con.ejecutarProcedimiento("Insert_HechosJudiciales", parametros, out datareader);
        con.Desconectar();
        return returnvalue;
    }

    public void Update_HechosJudiciales(
    int ICodHechosJudiciales
   , int CodDiagnostico
   , DateTime FechaHechoJudicial
   , int CodTribunal
   , int CodCausalIngreso
   , String RolCausa
   , bool TieneQuerellaSename
   , String Descripcion
   , bool Victima
   , bool Acusado
   , bool TieneDefensor
   , int ICodTrabajador
   , int CodInstitucion
   , int CodTrabajador
   , DateTime FechaActualizacion
   , int IdUsuarioActualizacion
   , String Ruc
   , String Rit)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodHechosJudiciales", SqlDbType.Int, 4, ICodHechosJudiciales) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaHechoJudicial", SqlDbType.DateTime, 16, FechaHechoJudicial) , 
		con.parametros("@CodTribunal", SqlDbType.Int, 4, CodTribunal) , 
        con.parametros("@CodCausalIngreso", SqlDbType.Int, 4, CodCausalIngreso) , 
		con.parametros("@RolCausa", SqlDbType.VarChar, 50, RolCausa) , 
		con.parametros("@TieneQuerellaSename", SqlDbType.Int, 1, TieneQuerellaSename) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 100, Descripcion) , 
		con.parametros("@Victima", SqlDbType.Int, 1, Victima) , 
		con.parametros("@Acusado", SqlDbType.Int, 1, Acusado) , 
		con.parametros("@TieneDefensor", SqlDbType.Int, 1, TieneDefensor) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 10, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion), 
		con.parametros("@Ruc", SqlDbType.VarChar, 50, Ruc),
        con.parametros("@Rit", SqlDbType.VarChar, 50, Rit)
        
        
        };
        con.ejecutarProcedimiento("Update_HechosJudiciales", parametros, out datareader);
        con.Desconectar();

    }

    //Actualizacion Fabian Urrutia 12-05-2014
    public void Update_DiagnosticosPeoresFormaTrabajo(
    int ICodPFTI, 
    int CodDiagnostico, 
    int CodCategoria, 
    DateTime FechaDiagnostico, 
    bool PresentaAgresion, 
    int CodPersonaRelacionada, 
    bool ViveConExplotador, 
    String Observacion, 
    int ICodTrabajador, 
    int CodInstitucion,
    int CodTrabajador, 
    DateTime FechaActualizacion, 
    int IdUsuarioActualizacion,
    DateTime FechaOcurrencia,
    int CodRegion,
    int CodComuna,
    int TipoRel)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodPFTI", SqlDbType.Int, 4, ICodPFTI) , 
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodCategoria", SqlDbType.Int, 4, CodCategoria) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@PresentaAgresion", SqlDbType.Int, 1, PresentaAgresion) , 
		con.parametros("@CodPersonaRelacionada", SqlDbType.Int, 4, CodPersonaRelacionada) , 
		con.parametros("@ViveConExplotador", SqlDbType.Int, 1, ViveConExplotador) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@FechaOcurrencia", SqlDbType.DateTime, 16, FechaOcurrencia),
        con.parametros("@CodRegion", SqlDbType.Int, 4, CodRegion),
        con.parametros("@CodComuna", SqlDbType.Int, 4, CodComuna),
        con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion),
        con.parametros("@TipoRel", SqlDbType.Int, 4, TipoRel)
		};
        con.ejecutarProcedimiento("Update_DiagnosticosPeoresFormaTrabajo", parametros, out datareader);
        con.Desconectar();

    }


    //fin Update Diagnosticos

    
    public DataTable GetDiagnosticoMaltratoMostrar( int ICodMaltrato)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        
        con.ejecutar(Resources.Procedures.GetMostrarDiagnosticoMaltrato + ICodMaltrato, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        
  


   

	dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));   //0
	dt.Columns.Add(new DataColumn("PresentaMaltrato", typeof(bool)));       //1
    dt.Columns.Add(new DataColumn("TipoMaltrato", typeof(int)));            //2
	dt.Columns.Add(new DataColumn("CodMaltrato", typeof(int)));             //3
	dt.Columns.Add(new DataColumn("ConoceMaltratador", typeof(bool)));      //4
	dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int)));   //5
	dt.Columns.Add(new DataColumn("ViveConAgresor", typeof(bool)));         //6
	dt.Columns.Add(new DataColumn("ExisteQuerellaSENAME", typeof(bool)));   //7
	dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));           //8
	dt.Columns.Add(new DataColumn("Observacion", typeof(String)));          //9
	while (datareader.Read())
	{
		try
		{
			dr = dt.NewRow();
		dr[0] = (DateTime) datareader["FechaDiagnostico"];
        dr[1] = (bool) datareader["PresentaMaltrato"];
        dr[2] = (int)datareader["TipoMaltrato"]; 
        dr[3] = (int) datareader["CodMaltrato"];    
        dr[4] = (bool) datareader["ConoceMaltratador"];
		dr[5] = (int) datareader["TipoRelacion"];
		dr[6] = (bool) datareader["ViveConAgresor"];
		dr[7] = (bool) datareader["ExisteQuerellaSENAME"]; 
        dr[8] = (int) datareader["ICodTrabajador"];
		dr[9] = (String) datareader["Observacion"];    
        dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    
    }

    public DataTable GetDiagnosticoDrogaMostrar( int CodDiagnostico)
    {

        DbDataReader datareader = null;
         Conexiones con = new Conexiones();



        con.ejecutar(Resources.Procedures.GetMostrarDiagnosticoDroga + CodDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("ICodDroga", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodDroga", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoConsumoDroga", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));
        dt.Columns.Add(new DataColumn("SeAtiendeConace", typeof(int)));
      
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodDroga"];
                dr[1] = (DateTime)datareader["FechaDiagnostico"];
                dr[2] = (int)datareader["CodDroga"];
                dr[3] = (int)datareader["TipoConsumoDroga"];
                dr[4] = (int)datareader["ICodTrabajador"];
                dr[5] = (String)datareader["Observacion"];
                try
                {
                    dr[6] = (int)datareader["SeAtiendeConace"];
                }
                catch { }
                
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetDiagnosticoPsicologicoMostrar( int CodDiagnostico)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetMostrarDiagnosticoPsicologico + CodDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodPsicologico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodTipoDiagnosticoPsi", typeof(int)));
        dt.Columns.Add(new DataColumn("CodInstrumentoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("CodMedicionesDiagnosticas", typeof(int)));
        dt.Columns.Add(new DataColumn("ValorMedicion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrastornoMental", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Observaciones", typeof(String)));
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodPsicologico"];
                dr[1] = (DateTime)datareader["FechaDiagnostico"];
                dr[2] = (int)datareader["CodTipoDiagnosticoPsi"];
                dr[3] = (int)datareader["CodInstrumentoDiagnostico"];
                dr[4] = (int)datareader["CodMedicionesDiagnosticas"];
                dr[5] = (int)datareader["ValorMedicion"];
                dr[6] = (int)datareader["CodTrastornoMental"];
                dr[7] = (int)datareader["ICodTrabajador"];
                dr[8] = (String)datareader["Observaciones"];
                
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    
    }
    public DataTable GetDiagnosticoSocialMostrar( int CodDiagnostico)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();



        con.ejecutar(Resources.Procedures.GetDiagnosticosSocialMostrar + CodDiagnostico, out datareader);
       // con.ejecutar(Resources.Procedures.GetDiagnosticosSocialMostrar + ICodSocial, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

       // dt.Columns.Add(new DataColumn("ICodSocial", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));       //0
        dt.Columns.Add(new DataColumn("CodSituacionEspecial", typeof(int)));        //1
        dt.Columns.Add(new DataColumn("CodSituacionSocioEconomica", typeof(int)));  //2
        dt.Columns.Add(new DataColumn("CodSituacionCalle", typeof(int)));           //3
        dt.Columns.Add(new DataColumn("AnoMesInicioVivirCalle", typeof(int)));      //4
        dt.Columns.Add(new DataColumn("NumeroPersonasHogar", typeof(int)));         //5
        dt.Columns.Add(new DataColumn("NumeroPersonasSitio", typeof(int)));         //6
        dt.Columns.Add(new DataColumn("NumeroHermanosVivenConEl", typeof(int)));    //7 
        dt.Columns.Add(new DataColumn("NumeroHermanos", typeof(int)));              //8
        dt.Columns.Add(new DataColumn("PuntajeCAS", typeof(int)));                  //9
        dt.Columns.Add(new DataColumn("FechaPuntajeCAS", typeof(DateTime)));        //10
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));  //11
        dt.Columns.Add(new DataColumn("Observacion", typeof(String)));              //12
        dt.Columns.Add(new DataColumn("CodEstadoAbandono", typeof(int)));           //13
        dt.Columns.Add(new DataColumn("CodSituacionTuicion", typeof(int)));         //14
        dt.Columns.Add(new DataColumn("CodEtnia", typeof(int)));                    //15
        dt.Columns.Add(new DataColumn("Fonasa", typeof(String)));                   //16
        dt.Columns.Add(new DataColumn("ChileSolidario", typeof(String)));           //17
        dt.Columns.Add(new DataColumn("ChileCreceContigo", typeof(String)));        //18
        dt.Columns.Add(new DataColumn("FechaFonasa", typeof(DateTime)));            //19
        dt.Columns.Add(new DataColumn("FechaChileSolidario", typeof(DateTime)));    //20
        dt.Columns.Add(new DataColumn("FechaChileCreceContigo", typeof(DateTime)));    //21

        
        dt.Columns.Add(new DataColumn("AdolescenteEmbarazada", typeof(bool)));            //22
        dt.Columns.Add(new DataColumn("NumeroMesesGestacion", typeof(int)));       //23
        dt.Columns.Add(new DataColumn("EmbarazoAbusoViolacion", typeof(bool)));            //24
        dt.Columns.Add(new DataColumn("AdolescentePadreMadre", typeof(bool)));            //25
        dt.Columns.Add(new DataColumn("NumeroHijos", typeof(int)));            //26
        dt.Columns.Add(new DataColumn("HijosAbusoViolacion", typeof(bool)));            //27
        
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
               // dr[0] = (int)datareader["ICodSocial"];
                dr[0] = (DateTime)datareader["FechaDiagnostico"];
                dr[1] = (int)datareader["CodSituacionEspecial"];
                dr[2] = (int)datareader["CodSituacionSocioEconomica"];
                dr[3] = (int)datareader["CodSituacionCalle"];
                dr[4] = (int)datareader["AnoMesInicioVivirCalle"];
                dr[5] = (int)datareader["NumeroPersonasHogar"];
                dr[6] = (int)datareader["NumeroPersonasSitio"];
                dr[7] = (int)datareader["NumeroHermanosVivenConEl"];
                dr[8] = (int)datareader["NumeroHermanos"];
                dr[9] = (int)datareader["PuntajeCAS"];
                dr[10] = (DateTime)datareader["FechaPuntajeCAS"];
                dr[11] = (int)datareader["CodTrabajador"];
                dr[12] = (String)datareader["Observacion"];
                dr[13] = (int)datareader["CodEstadoAbandono"];
                dr[14] = (int)datareader["CodSituacionTuicion"];
                dr[15] = (int)datareader["CodEtnia"];
                dr[16] =(String)datareader["Fonasa"];
                dr[17] = (String)datareader["ChileSolidario"];
                dr[18] = (String)datareader["ChileCreceContigo"];
                dr[19] = (DateTime)datareader["FechaFonasa"];
                dr[20] = (DateTime)datareader["FechaChileSolidario"];
                dr[21] = (DateTime)datareader["FechaChileCreceContigo"];

                dr[22] = (bool)datareader["AdolescenteEmbarazada"];
                dr[23] = (int)datareader["NumeroMesesGestacion"];
                dr[24] = (bool)datareader["EmbarazoAbusoViolacion"];
                dr[25] = (bool)datareader["AdolescentePadreMadre"];
                dr[26] = (int)datareader["NumeroHijos"];
                dr[27] = (bool)datareader["HijosAbusoViolacion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    

    }



    public DataTable GetDiagnosticoCapacitacionMostrar( int CodDiagnostico)
    {

        DbDataReader datareader = null;
         Conexiones con = new Conexiones();



        con.ejecutar(Resources.Procedures.GetDiagnosticoCApacitacionMostrar + CodDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("TipoCapacitacion", typeof(int)));       //0
        dt.Columns.Add(new DataColumn("CodAreaCapacitacion", typeof(int)));        //1
        dt.Columns.Add(new DataColumn("CodOrganismoCapacitador", typeof(int)));  //2
        dt.Columns.Add(new DataColumn("CodEstadoCapacitacion", typeof(int)));           //3
        dt.Columns.Add(new DataColumn("FechaInicioCapacitacion", typeof(DateTime)));      //4
        dt.Columns.Add(new DataColumn("HorasCurso", typeof(int)));         //5
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));         //6
        dt.Columns.Add(new DataColumn("Termino", typeof(String)));    //7 
        dt.Columns.Add(new DataColumn("FechaTerminoCapacitacion", typeof(DateTime)));              //8
        
      


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoCapacitacion"];
                dr[1] = (int)datareader["CodAreaCapacitacion"];
                dr[2] = (int)datareader["CodOrganismoCapacitador"];
                dr[3] = (int)datareader["CodEstadoCapacitacion"];
                dr[4] = (DateTime)datareader["FechaInicioCapacitacion"];
                dr[5] = (int)datareader["HorasCurso"];
                dr[6] = (String)datareader["Descripcion"];
                dr[7] = (String)datareader["Termino"];

                //if (Convert.ToString((DateTime)datareader["FechaTerminoCapacitacion"]) == "30-12-1899")
                //{
                //    dr[8] = "";
                //}
                //else 
                //{
                    dr[8] = (DateTime)datareader["FechaTerminoCapacitacion"];
                //}

                    
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetDiagnosticoSituacionLaboral( int CodDiagnostico)
    {

        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

        con.ejecutar(Resources.Procedures.GetSituacionLabralMostrar + CodDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

       


        dt.Columns.Add(new DataColumn("FechaSituacionLaboral",typeof(DateTime)));       //0
        dt.Columns.Add(new DataColumn("CodAreaInsercionLaboral",typeof(int)));          //1
        dt.Columns.Add(new DataColumn("CodSituacionLaboral", typeof(int)));             //2
        dt.Columns.Add(new DataColumn("DireccionLaboral", typeof(String)));             //3
        dt.Columns.Add(new DataColumn("CodigoPostal", typeof(int)));                    //4
        dt.Columns.Add(new DataColumn("TelefonoLaboral", typeof(String)));              //5    
        dt.Columns.Add(new DataColumn("PersonaReferencia", typeof(String)));            //6
        dt.Columns.Add(new DataColumn("Email", typeof(String)));                        //7    
        dt.Columns.Add(new DataColumn("DiagnosticoOcupacional", typeof(int)));          //8
       
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (DateTime)datareader["FechaSituacionLaboral"];
                dr[1] = (int)datareader["CodAreaInsercionLaboral"];
                dr[2] = (int)datareader["CodSituacionLaboral"];
                dr[3] = (String)datareader["DireccionLaboral"];
                dr[4] = (int)datareader["CodigoPostal"];
                dr[5] = (String)datareader["TelefonoLaboral"];
                dr[6] = (String)datareader["PersonaReferencia"];
                dr[7] = (String)datareader["Email"];
                dr[8] = (int)datareader["DiagnosticoOcupacional"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    }

    public DataTable GetDiagnosticoHechosJudiciales( int ICodHJ)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetDiagnosticosHechosJudicialesMostrar + ICodHJ, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("FechaHechoJudicial", typeof(DateTime))); //0
        dt.Columns.Add(new DataColumn("TipoTribunal", typeof(int)));        //1
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));           //2
        dt.Columns.Add(new DataColumn("CodTribunal", typeof(int)));             //3
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));        //4
        dt.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));            //5
        dt.Columns.Add(new DataColumn("RolCausa", typeof(String)));                 //6
        dt.Columns.Add(new DataColumn("Ruc", typeof(String)));                      //7
        dt.Columns.Add(new DataColumn("Rit", typeof(String)));                      //8
        dt.Columns.Add(new DataColumn("TieneQuerellaSename", typeof(Boolean)));         //9    
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));                 //10
        dt.Columns.Add(new DataColumn("Victima", typeof(Boolean)));                     //11
        dt.Columns.Add(new DataColumn("Acusado", typeof(Boolean)));                     //12
        dt.Columns.Add(new DataColumn("TieneDefensor", typeof(Boolean)));               //13
        dt.Columns.Add(new DataColumn("ICodTrabajador",typeof(int)));               //14

        /* Mira Karina lo numeritos comentados del lado son solo para giiarce con el data reader*/



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();

                dr[0] = (DateTime)datareader["FechaHechoJudicial"];
                dr[1] = (int)datareader["TipoTribunal"];
                dr[2] = (int)datareader["CodRegion"];
                dr[3] = (int)datareader["CodTribunal"];
                dr[4] = (int)datareader["CodTipoCausalIngreso"];
                dr[5] = (int)datareader["CodCausalIngreso"];
                dr[6] = (String)datareader["RolCausa"];
                dr[7] = (String)datareader["Ruc"];
                dr[8] = (String)datareader["Rit"];
                dr[9] = (Boolean)datareader["TieneQuerellaSename"];
                dr[10] = (String)datareader["Descripcion"];
                dr[11] = (Boolean)datareader["victima"];
                dr[12] = (Boolean)datareader["acusado"];
                dr[13] = (Boolean)datareader["TieneDefensor"];
                dr[14] = (int)datareader["ICodTrabajador"];
  

               dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    
    
    }

    
    public DataTable GetDiagnosticoPeoresFormasMostrar( int Icodie)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        
        con.ejecutar(Resources.Procedures.GetDiagnosticosPeoresFormasMostrar + Icodie + " Order by T2.FechaDiagnostico desc", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodPFTI", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaDiagnostico", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("NombreCompleto", typeof(String)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        //dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));
        //dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        //dt.Columns.Add(new DataColumn("FechaSituacion", typeof(DateTime)));
        //dt.Columns.Add(new DataColumn("Especificacion", typeof(String)));
        //dt.Columns.Add(new DataColumn("Especificacion2", typeof(String)));



        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();

                dr[0] = (int)datareader["ICodPFTI"];
                dr[1] = (int)datareader["CodDiagnostico"];
                dr[2] = (DateTime)datareader["FechaDiagnostico"];
                dr[3] = (String)datareader["NombreCompleto"];
                dr[4] = (String)datareader["Nombre"];
                //dr[5] = (int)datareader["CodRegion"];
                //dr[6] = (int)datareader["CodComuna"];
                //dr[7] = (DateTime)datareader["FechaSituacion"];
                //dr[8] = (String)datareader["Especificacion"];
                //dr[9] = (String)datareader["Especificacion2"];
                              
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    }

    public DataTable GetDiagnosticoEscolarMostrar( int CodDiagnostico)
       {

        DbDataReader datareader = null;
         Conexiones con = new Conexiones();

           con.ejecutar(Resources.Procedures.GetMostrarDiagnosticoEscolar + CodDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

       
            dt.Columns.Add(new DataColumn("FechaDiagnostico"));         //0
            dt.Columns.Add(new DataColumn("AnoUltimoCursoAprobado"));         //1
            dt.Columns.Add(new DataColumn("Observaciones"));             //2
            dt.Columns.Add(new DataColumn("Descolar"));              //3
            dt.Columns.Add(new DataColumn("IcodTrabajador"));       //4
            //dt.Columns.Add(new DataColumn("NombreCompleto"));        
            dt.Columns.Add(new DataColumn("Descripcion"));    //5    
            dt.Columns.Add(new DataColumn("CodEscolaridad"));           //6
            dt.Columns.Add(new DataColumn("TipoAsistenciaEscolar"));     //7    
            dt.Columns.Add(new DataColumn("CodTrabajador"));            //8
       
        
        


        while (datareader.Read())
        {
            dr = dt.NewRow();
            try
            {
                dr = dt.NewRow();
                dr[0] = (DateTime)datareader["FechaDiagnostico"];
                dr[1] = (int)datareader["AnoUltimoCursoAprobado"];
                dr[2] = (String)datareader["Observaciones"];
                dr[3] = (String)datareader["Descolar"];
                dr[4] = (int)datareader["IcodTrabajador"];
                //dr[4] = (String)datareader["NombreCompleto"];
                dr[5] = (String)datareader["Descripcion"];
                dr[6] = (int)datareader["CodEscolaridad"];
                dr[7] = (int)datareader["TipoAsistenciaEscolar"];
                dr[8] = (int)datareader["CodTrabajador"];

                dt.Rows.Add(dr);
            }
            catch 
            {
                if ((int)datareader["IcodTrabajador"] == null)
                    dr[4] = -1;
            }
        }
        con.Desconectar();
        return dt;
    
    
    
    
    }
    
    
    
    
    public int Insert_DiagnosticosPsicologico(
        int CodDiagnostico, 
        int CodInstrumentoDiagnostico, 
        int CodMedicionesDiagnosticas, 
        DateTime FechaDiagnostico, 
        int ICodTrabajador, 
        int CodInstitucion, 
        int CodTrabajador, 
        int ValorMedicion, 
        String Observaciones, 
        DateTime FechaActualizacion, 
        int IdUsuarioActualizacion,
        int CodTipoDiagnostico,
        int CodTipoTranstornoMental)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@CodInstrumentoDiagnostico", SqlDbType.Int, 4, CodInstrumentoDiagnostico) , 
		con.parametros("@CodMedicionesDiagnosticas", SqlDbType.Int, 4, CodMedicionesDiagnosticas) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@ValorMedicion", SqlDbType.Int, 4, ValorMedicion) , 
		con.parametros("@Observaciones", SqlDbType.VarChar, 200, Observaciones) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@CodTipoDiagnosticoPsi", SqlDbType.Int, 4, CodTipoDiagnostico),
        con.parametros("@CodTranstornoMental", SqlDbType.Int, 4, CodTipoTranstornoMental)
		};
        con.ejecutarProcedimiento("Insert_DiagnosticosPsicologico", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    //Felipe Ormazabal
    public int Insert_DiagnosticosSocial(
         int CodDiagnostico
        , DateTime FechaDiagnostico
        , int NumeroDiagnostico
        , int CodSituacionEspecial
        , int CodSituacionSocioEconomica
        , int ICodTrabajador
        , int CodInstitucion
        , int CodTrabajador
        , int CodSituacionCalle
        , String Observacion
        , int AnoMesInicioVivirCalle
        , int NumeroPersonasHogar
        , int NumeroPersonasSitio
        , int NumeroHermanosVivenConEl
        , int NumeroHermanos
        , int PuntajeCAS
        , DateTime FechaPuntajeCAS
        , int CodSituacionTuicion
        , int CodEstadoAbandono
        , int CodUltimoEstadoAbandono
        , DateTime FechaActualizacion
        , int IdUsuarioActualizacion
        , int Etnia
        , String Fonasa
        , String ChileSolidario
        , String ChileCreceContigo
        , DateTime FechaFonasa
        , DateTime FechaChileSolidario
        , DateTime FechaChileCreceContigo

        , bool AdolescenteEmbarazada 
        , int NumeroMesesGestacion 
        , bool EmbarazoAbusoViolacion 
        , bool AdolescentePadreMadre 
        , int NumeroHijos 
        , bool HijosAbusoViolacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico) , 
		con.parametros("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico) , 
		con.parametros("@NumeroDiagnostico", SqlDbType.Int, 4, NumeroDiagnostico) , 
		con.parametros("@CodSituacionEspecial", SqlDbType.Int, 4, CodSituacionEspecial) , 
		con.parametros("@CodSituacionSocioEconomica", SqlDbType.Int, 4, CodSituacionSocioEconomica) , 
        con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador),
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@CodSituacionCalle", SqlDbType.Int, 4, CodSituacionCalle) , 
		con.parametros("@Observacion", SqlDbType.VarChar, 100, Observacion) , 
		con.parametros("@AnoMesInicioVivirCalle", SqlDbType.Int, 4, AnoMesInicioVivirCalle) , 
		con.parametros("@NumeroPersonasHogar", SqlDbType.Int, 4, NumeroPersonasHogar) , 
		con.parametros("@NumeroPersonasSitio", SqlDbType.Int, 4, NumeroPersonasSitio) , 
		con.parametros("@NumeroHermanosVivenConEl", SqlDbType.Int, 4, NumeroHermanosVivenConEl) , 
		con.parametros("@NumeroHermanos", SqlDbType.Int, 4, NumeroHermanos) , 
		con.parametros("@PuntajeCAS", SqlDbType.Int, 4, PuntajeCAS) , 
		con.parametros("@FechaPuntajeCAS", SqlDbType.DateTime, 16, FechaPuntajeCAS) , 
		con.parametros("@CodSituacionTuicion", SqlDbType.Int, 4, CodSituacionTuicion) , 
		con.parametros("@CodEstadoAbandono", SqlDbType.Int, 4, CodEstadoAbandono) , 
		con.parametros("@CodUltimoEstadoAbandono", SqlDbType.Int, 4, CodUltimoEstadoAbandono) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@Etnia", SqlDbType.Int, 4, Etnia),
        con.parametros("@Fonasa", SqlDbType.VarChar, 50, Fonasa),
        con.parametros("@ChileSolidario", SqlDbType.VarChar, 50, ChileSolidario),
        con.parametros("@ChileCreceContigo", SqlDbType.VarChar, 50, ChileCreceContigo),
        con.parametros("@FechaFonasa", SqlDbType.DateTime, 16, FechaFonasa),
        con.parametros("@FechaChileSolidario", SqlDbType.DateTime, 16, FechaChileSolidario),
        con.parametros("@FechaChileCreceContigo", SqlDbType.DateTime, 16, FechaChileCreceContigo),

        con.parametros("@AdolescenteEmbarazada", SqlDbType.Int, 1, AdolescenteEmbarazada) ,
        con.parametros("@NumeroMesesGestacion", SqlDbType.Int, 2, NumeroMesesGestacion) , 
        con.parametros("@EmbarazoAbusoViolacion", SqlDbType.Int, 1, EmbarazoAbusoViolacion) , 
        con.parametros("@AdolescentePadreMadre", SqlDbType.Int, 1, AdolescentePadreMadre) , 
        con.parametros("@NumeroHijos", SqlDbType.Int, 2, NumeroHijos) , 
        con.parametros("@HijosAbusoViolacion", SqlDbType.Int, 1, HijosAbusoViolacion)

		};
        con.ejecutarProcedimiento("Insert_DiagnosticosSocial", parametros, out datareader);
        //if (datareader.Read())
        //{
        //    returnvalue = Convert.ToInt32(datareader["identidad"]);
        //}
        con.Desconectar();
        return returnvalue;
    }
    public DataTable GetInformesDiagnosticos( string ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetInformesDiagnosticos + "@pICodIE";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("ICodInformeDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioInforme", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodTerminoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaTerminoInforme", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["ICodInformeDiagnostico"];
                dr[1] = (int)datareader["ICodIE"];
                dr[2] = (DateTime)datareader["FechaInicioInforme"];
                dr[3] = (int)datareader["CodTerminoDiagnostico"];
                dr[4] = (int)datareader["TipoDiagnostico"];
                dr[5] = (DateTime)datareader["FechaTerminoInforme"];
                dr[6] = (DateTime)datareader["FechaActualizacion"];
                dr[7] = (int)datareader["IdUsuarioActualizacion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetEtapasInformeDiagnostico( string ICodinformediagnostico)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetEtapasInformeDiagnostico + "@pICodinformediagnostico";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodinformediagnostico", SqlDbType.Int, 4, Convert.ToInt32(ICodinformediagnostico)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("IcodEtapa", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodInformeDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaEtapa", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodEtapasIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["IcodEtapa"];
                dr[1] = (int)datareader["ICodInformeDiagnostico"];
                dr[2] = (DateTime)datareader["FechaEtapa"];
                dr[3] = (int)datareader["CodEtapasIntervencion"];
                dr[4] = datareader["Descripcion"].ToString();
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable callto_update_accionesinformediagnostico_2f(int icodaccion, int icodinformediagnostico, int tipoeventointervencion, DateTime fechaaccion, DateTime fechainicioinforme, int icodtrabajaor, int codinstitucion, int codtrabajador, string observaciones, DateTime fechaactualizacion, int icodaccionesinformediagnostico)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_AccionesInformeDiagnostico_2f";
        sqlc.Parameters.Add("@ICodAccion", SqlDbType.Int, 4).Value = icodaccion;
        sqlc.Parameters.Add("@ICodInformeDiagnostico", SqlDbType.Int, 4).Value = icodinformediagnostico;
        sqlc.Parameters.Add("@TipoEventoIntervencion", SqlDbType.Int, 4).Value = tipoeventointervencion;
        sqlc.Parameters.Add("@FechaAccion", SqlDbType.DateTime, 16).Value = fechaaccion;
        sqlc.Parameters.Add("@FechaInicioInforme", SqlDbType.DateTime, 16).Value = fechainicioinforme;
        sqlc.Parameters.Add("@ICodTrabajaor", SqlDbType.Int, 4).Value = icodtrabajaor;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = observaciones;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@ICodAccionesInformeDiagnostico", SqlDbType.Int, 4).Value = icodaccionesinformediagnostico;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }




    public void Update_AccionesInformeDiagnostico(
    int ICodAccionesInformeDiagnostico, int ICodInformeDiagnostico, DateTime FechaInicioInforme, int TipoEventoIntervencion, DateTime FechaAccion, int CodInstitucion, int CodTrabajador, String Observaciones, DateTime FechaActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodAccionesInformeDiagnostico", SqlDbType.Int, 4, ICodAccionesInformeDiagnostico) , 
		con.parametros("@ICodInformeDiagnostico", SqlDbType.Int, 4, ICodInformeDiagnostico) , 
		con.parametros("@FechaInicioInforme", SqlDbType.DateTime, 16, FechaInicioInforme) , 
		con.parametros("@TipoEventoIntervencion", SqlDbType.Int, 2, TipoEventoIntervencion) , 
		con.parametros("@FechaAccion", SqlDbType.DateTime, 16, FechaAccion) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observaciones", SqlDbType.VarChar, 500, Observaciones) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Update_AccionesInformeDiagnostico", parametros, out datareader);
        con.Desconectar();

    }


    public int callto_insert_accionesinformediagnostico_2f(int icodinformediagnostico, int tipoeventointervencion, DateTime fechaaccion, DateTime fechainicioinforme, int icodtrabajaor, int codinstitucion, int codtrabajador, string observaciones, DateTime fechaactualizacion, int icodaccionesinformediagnostico)
    {

        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_AccionesInformeDiagnostico_2F";
        sqlc.Parameters.Add("@ICodInformeDiagnostico", SqlDbType.Int, 4).Value = icodinformediagnostico;
        sqlc.Parameters.Add("@TipoEventoIntervencion", SqlDbType.Int, 4).Value = tipoeventointervencion;
        sqlc.Parameters.Add("@FechaAccion", SqlDbType.DateTime, 16).Value = fechaaccion;
        sqlc.Parameters.Add("@FechaInicioInforme", SqlDbType.DateTime, 16).Value = fechainicioinforme;
        sqlc.Parameters.Add("@ICodTrabajaor", SqlDbType.Int, 4).Value = icodtrabajaor;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodTrabajador", SqlDbType.Int, 4).Value = codtrabajador;
        sqlc.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = observaciones;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@ICodAccionesInformeDiagnostico", SqlDbType.Int, 4).Value = icodaccionesinformediagnostico;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        return returnvalue;
    }

    public int callto_consulta_cierremes(int codproyecto, int anomes)
    {

        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Consulta_CierreMes";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = anomes;
        sqlc.Parameters.Add("@Returns", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        return returnvalue;
    }




    public DataTable callto_cierre_cabeceraproyecto(int codproyecto, int mesano)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + ";Database= " + objconn.DatabaseName + "; User ID= " + objconn.User + " ;Password= " + objconn.Password + ";Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_cabeceraproyecto";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }








    public int Insert_AccionesInformeDiagnostico(
    int ICodInformeDiagnostico, int TipoEventoIntervencion, DateTime FechaAccion, 
        DateTime FechaInicioInforme, int CodInstitucion, 
        int CodTrabajador, String Observaciones, DateTime FechaActualizacion, 
        int ICodAccionesInformeDiagnostico)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodInformeDiagnostico", SqlDbType.Int, 4, ICodInformeDiagnostico) , 
		con.parametros("@TipoEventoIntervencion", SqlDbType.Int, 4, TipoEventoIntervencion) , 
		con.parametros("@FechaAccion", SqlDbType.DateTime, 16, FechaAccion) , 
		con.parametros("@FechaInicioInforme", SqlDbType.DateTime, 16, FechaInicioInforme) , 
		//con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@Observaciones", SqlDbType.VarChar, 500, Observaciones) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@ICodAccionesInformeDiagnostico", SqlDbType.Int, 4, ICodAccionesInformeDiagnostico) 
		};
        con.ejecutarProcedimiento("Insert_AccionesInformeDiagnostico", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    
    public void Update_InformesDiagnosticos(
    int ICodInformeDiagnostico, int ICodIE, DateTime FechaInicioInforme, int CodTerminoDiagnostico, int TipoDiagnostico, DateTime FechaTerminoInforme, DateTime FechaActualizacion, int IdUsuarioActualizacion)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodInformeDiagnostico", SqlDbType.Int, 4, ICodInformeDiagnostico) , 
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@FechaInicioInforme", SqlDbType.DateTime, 16, FechaInicioInforme) , 
		con.parametros("@CodTerminoDiagnostico", SqlDbType.Int, 4, CodTerminoDiagnostico) , 
		con.parametros("@TipoDiagnostico", SqlDbType.Int, 4, TipoDiagnostico) , 
		con.parametros("@FechaTerminoInforme", SqlDbType.DateTime, 16, FechaTerminoInforme) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Update_InformesDiagnosticos", parametros, out datareader);
        con.Desconectar();

    }


    public DataTable GetTerminoInforme( int ICodInformeDiagnostico)
    { 
    
    
     DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTerminoInfDiagnosticos + ICodInformeDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
     
        dt.Columns.Add(new DataColumn("TipoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioInforme", typeof(DateTime)));
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();

                dr[0] = (int)datareader["TipoDiagnostico"];
                dr[1] = (DateTime)datareader["FechaInicioInforme"];
                
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    }



    public int Insert_InformesDiagnosticos(
    int ICodIE, DateTime FechaInicioInforme, int CodTerminoDiagnostico, 
    int TipoDiagnostico, DateTime FechaTerminoInforme, DateTime FechaActualizacion, 
    int IdUsuarioActualizacion, int CodProyecto, int CodNino, DateTime FechaIngreso)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodIE", SqlDbType.Int, 4, ICodIE) , 
		con.parametros("@FechaInicioInforme", SqlDbType.DateTime, 16, FechaInicioInforme) , 
		con.parametros("@CodTerminoDiagnostico", SqlDbType.Int, 4, CodTerminoDiagnostico) , 
		con.parametros("@TipoDiagnostico", SqlDbType.Int, 4, TipoDiagnostico) , 
		con.parametros("@FechaTerminoInforme", SqlDbType.DateTime, 16, FechaTerminoInforme) , 
		con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto),
        con.parametros("@CodNino", SqlDbType.Int, 4, CodNino),
        con.parametros("@FechaIngreso", SqlDbType.DateTime, 16, FechaIngreso)
		};
        con.ejecutarProcedimiento("Insert_InformesDiagnosticos", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public DataTable GetAccionesInformeDiagnosticoModifica( string Icodaccion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetAccionesInformeDiagnosticoModifica + "@pIcodaccion";
        listDbParameter.Add(Conexiones.CrearParametro("@pIcodaccion", SqlDbType.Int, 4, Convert.ToInt32(Icodaccion)));


        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        //  dt.Columns.Add(new DataColumn("ICodAccionesInformeDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Icodaccion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodtrabajaor", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaAccion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoEventoIntervencion",typeof(int)));
        dt.Columns.Add(new DataColumn("Observaciones", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                //   dr[0] = (int)datareader["ICodAccionesInformeDiagnostico"];
                dr[0] = (int)datareader["Icodaccion"];
                dr[1] = (int)datareader["ICodtrabajaor"];
                dr[2] = (DateTime)datareader["FechaAccion"];
                dr[3] = (int)datareader["TipoEventoIntervencion"];
                dr[4] = (String)datareader["Observaciones"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }




    public DataTable GetAccionesInformeDiagnostico( string ICodinformediagnostico)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql = Resources.Procedures.GetAccionesInformeDiagnostico + "@pICodinformediagnostico";
        listDbParameter.Add(Conexiones.CrearParametro("@pICodinformediagnostico", SqlDbType.Int, 4, Convert.ToInt32(ICodinformediagnostico)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
      //  dt.Columns.Add(new DataColumn("ICodAccionesInformeDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Icodaccion", typeof(int)));
        dt.Columns.Add(new DataColumn("ICodInformeDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaInicioInforme", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoEventoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaAccion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Observaciones", typeof(String)));
        dt.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));//DescripcionTipo
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
             //   dr[0] = (int)datareader["ICodAccionesInformeDiagnostico"];
                dr[0] = (int)datareader["Icodaccion"]; 
                dr[1] = (int)datareader["ICodInformeDiagnostico"];
                dr[2] = (DateTime)datareader["FechaInicioInforme"];
                dr[3] = (int)datareader["TipoEventoIntervencion"];
                dr[4] = (DateTime)datareader["FechaAccion"];
                dr[5] = (int)datareader["CodInstitucion"];
                dr[6] = (int)datareader["CodTrabajador"];
                dr[7] = (String)datareader["Observaciones"];
                dr[8] = (DateTime)datareader["FechaActualizacion"];
                dr[9] = (String)datareader["DescripcionTipo"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable callto_delete_accionesinformediagnostico_1(int icodaccion_1)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "delete_AccionesInformeDiagnostico_1";
        sqlc.Parameters.Add("@ICodAccion_1", SqlDbType.Int, 4).Value = icodaccion_1;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable callto_delete_etapasinformediagnostico_1(int icodetapa_1)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "delete_EtapasInformeDiagnostico_1";
        sqlc.Parameters.Add("@ICodEtapa_1", SqlDbType.Int, 4).Value = icodetapa_1;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetEtapasDeIntervencionModifica(int IcodEtapa)
    {

        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetEtapasDeIntervencionModifica + IcodEtapa, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        
        dt.Columns.Add(new DataColumn("CodEtapasIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaEtapa ", typeof(DateTime)));
       
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                
                dr[0] = (int)datareader["CodEtapasIntervencion"];
                dr[1] = (DateTime)datareader["FechaEtapa"];
               
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    }
    
    
    
    public DataTable callto_update_etapasinformediagnostico(int icodetapa, int icodinformediagnostico, int codetapasintervencion, DateTime fechaetapa)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_EtapasInformeDiagnostico";
        sqlc.Parameters.Add("@ICodEtapa", SqlDbType.Int, 4).Value = icodetapa;
        sqlc.Parameters.Add("@ICodInformeDiagnostico", SqlDbType.Int, 4).Value = icodinformediagnostico;
        sqlc.Parameters.Add("@CodEtapasIntervencion", SqlDbType.Int, 4).Value = codetapasintervencion;
        sqlc.Parameters.Add("@FechaEtapa", SqlDbType.DateTime, 16).Value = fechaetapa;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    
    public void Insert_EtapasInformeDiagnostico(
    int ICodInformeDiagnostico, DateTime FechaEtapa, int CodEtapasIntervencion)
    {
       // int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodInformeDiagnostico", SqlDbType.Int, 4, ICodInformeDiagnostico) , 
		con.parametros("@FechaEtapa", SqlDbType.DateTime, 16, FechaEtapa) , 
		con.parametros("@CodEtapasIntervencion", SqlDbType.Int, 4, CodEtapasIntervencion) 
		};
        con.ejecutarProcedimiento("Insert_EtapasInformeDiagnostico", parametros, out datareader);
        
        con.Desconectar();
        
    }
    public DataTable callto_delete_solicituddiligencias_1(int icoddiligencia_1)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "delete_SolicitudDiligencias_1";
        sqlc.Parameters.Add("@ICodDiligencia_1", SqlDbType.Int, 4).Value = icoddiligencia_1;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_delete_diagnosticosdiscapacidad_1(int icoddiscapacidad_1)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "delete_DiagnosticosDiscapacidad_1";
        sqlc.Parameters.Add("@ICodDiscapacidad_1", SqlDbType.Int, 4).Value = icoddiscapacidad_1;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_delete_ninosenfermedadescronicas_1(int icodenfermedadcronica_1)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "delete_NinosEnfermedadesCronicas_1";
        sqlc.Parameters.Add("@ICodEnfermedadCronica_1", SqlDbType.Int, 4).Value = icodenfermedadcronica_1;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_delete_hechossalud_1(int icodhechosdesalud_1)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "delete_HechosSalud_1";
        sqlc.Parameters.Add("@ICodHechosdeSalud_1", SqlDbType.Int, 4).Value = icodhechosdesalud_1;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetDiagnosticos(int ICodIE, int TipoDiagnostico)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_Diagnosticos_Ninos_Historial";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@TipoDiagnostico", SqlDbType.Int, 4).Value = TipoDiagnostico;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    //furrutia 10-10-2014

    public DataTable GetRepTrabajadoresxProyecto(int CodProyecto, string Vigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "sp_GetRepTrabajadoresxProyecto";
        sqlc.Parameters.Add("@value", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.VarChar, 10).Value = Vigencia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetRepTrabajadoresxInstitucion(int CodInstitucion, string Vigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "sp_GetRepTrabajadoresxInstitucion";
        sqlc.Parameters.Add("@Vigencia", SqlDbType.VarChar, 10).Value = Vigencia;
        sqlc.Parameters.Add("@value", SqlDbType.Int, 4).Value = CodInstitucion;        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetRepTrabajadoresxRegion(int CodRegion, string Vigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "sp_GetRepTrabajadoresxRegion";
        sqlc.Parameters.Add("@value", SqlDbType.Int, 4).Value = CodRegion;
        sqlc.Parameters.Add("@Vigencia", SqlDbType.VarChar, 10).Value = Vigencia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetRepTrabajadoresxTodo()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "sp_GetRepTrabajadoresxTodo";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_update_ReporteTrabajadores(int IcodNombre, string Nombre, string APaterno, string AMaterno, string Rut, int CodProfesion, string OtraProfesion, int CodCargo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "update_ReporteTrabajadores";
        sqlc.Parameters.Add("@IcodNombre", SqlDbType.Int, 4).Value = IcodNombre;
        sqlc.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = Nombre;
        sqlc.Parameters.Add("@APaterno", SqlDbType.VarChar, 100).Value = APaterno;
        sqlc.Parameters.Add("@AMaterno", SqlDbType.VarChar, 100).Value = AMaterno;
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 100).Value = Rut;
        sqlc.Parameters.Add("@CodProfesion", SqlDbType.Int, 4).Value = CodProfesion;
        sqlc.Parameters.Add("@OtraProfesion", SqlDbType.VarChar, 100).Value = OtraProfesion;
        sqlc.Parameters.Add("@CodCargo", SqlDbType.Int, 4).Value = CodCargo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

     public DataTable Caducar_EncuestaTrabajadoresDetalle(int IcodNombre)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Caducar_EncuestaTrabajadoresDetalle";
        sqlc.Parameters.Add("@IcodNombre", SqlDbType.Int, 4).Value = IcodNombre;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Insert_ReporteTrabajadores(int CodUsuario, string Nombre, string APaterno, string AMaterno, string Rut, int CodProfesion, string OtraProfesion, int CodCargo, 
        string IndVigencia, int IdUsuario, DateTime FechaActualizacion, int CodProyecto)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_ReporteTrabajadores";
        sqlc.Parameters.Add("@CodUsuario", SqlDbType.Int, 4).Value = CodUsuario;
        sqlc.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = Nombre;
        sqlc.Parameters.Add("@ApellidoP", SqlDbType.VarChar, 100).Value = APaterno;
        sqlc.Parameters.Add("@ApellidoM", SqlDbType.VarChar, 100).Value = AMaterno;
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 100).Value = Rut;
        sqlc.Parameters.Add("@CodProfesion", SqlDbType.Int, 4).Value = CodProfesion;
        sqlc.Parameters.Add("@OtraProfesion", SqlDbType.VarChar, 100).Value = OtraProfesion;
        sqlc.Parameters.Add("@CodCargo", SqlDbType.Int, 4).Value = CodCargo;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = IndVigencia;
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = IdUsuario;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = FechaActualizacion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetTrabajadoresPorRut(string Rut)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "sp_GetTrabajadoresPorRut";
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 100).Value = Rut;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }    

}