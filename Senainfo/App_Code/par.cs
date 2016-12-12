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
//////using neocsharp.NeoDatabase;

using System.Collections.Generic; 

/// <summary>
/// Summary description for mastercoll
/// </summary>
public class parcoll
{
	public parcoll()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable ejecuta_SQL(string sql)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = sql;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable(); 
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

     
    public DataTable GetParmantenedores()
    { 
    
     DbDataReader datareader = null;
     Conexiones con = new Conexiones();
     con.ejecutar(Resources.Procedures.GetMantenedores, out datareader);
     DataTable dt = new DataTable();
     DataRow dr;
     dt.Columns.Add(new DataColumn("IdTabla", typeof(int)));
     dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));

     while (datareader.Read())
     {
         try
         {
             dr = dt.NewRow();
             dr[0] = (int)datareader["IdTabla"];
             dr[1] = (String)datareader["Descripcion"];
             dt.Rows.Add(dr);
         }
         catch { }
     }
        con.Desconectar();
        return dt;

    }

    public DataTable GetparCalidadJuridica()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar( Resources.Procedures.GetparCalidadJuridica, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCalidadJuridica", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCalidadJuridica"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparTribunalesHechosJudiciales(int Tipotribunal, int Codregion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        //" Select * from parTribunales where CodRegion= '" + CodRegion + "' AND TipoTribunal= '" + TipoTribunal + "'", out datareader);
        //con.ejecutar(Resources.Procedures.GetParTribunales + Tipotribunal  + Codregion , out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dr = dt.NewRow();
        //dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTribunal"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;




    }



    public DataTable GetparEscolaridad(int y)//, int EdadNivel)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEscolaridad , out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEscolaridad", typeof(int)));
        dt.Columns.Add(new DataColumn("Tipo", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CursoNivel", typeof(int)));
        dt.Columns.Add(new DataColumn("EdadNivel", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[2] = " Seleccionar ";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
           

                try
                {
                    if ((int)datareader["EdadNivel"] <= y)
                    {
                        dr = dt.NewRow();

                        //if ((int)datareader["EdadNivel"] >= EdadNivel)
                        //{
                            dr[0] = (int)datareader["CodEscolaridad"];
                            dr[1] = (String)datareader["Tipo"];
                            dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                            dr[3] = (int)datareader["CursoNivel"];
                            dr[4] = (int)datareader["EdadNivel"];
                            dr[5] = (String)datareader["IndVigencia"];
                            dt.Rows.Add(dr);
                        //}
                    }
                }

                catch { }
            
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparSituacionPerRel()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSituacionPerRel, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetAreasObjetivo()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetAreasObjetivos";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

 
        return dt;
    }

    public DataTable GetObjetivoModulos()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetObjetivosModulos";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);


        return dt;
    }


    public DataTable Profesionales(int instId)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Trabajadores_byinstitucion";
        sqlc.Parameters.Add("@instId", SqlDbType.Int, 4).Value = instId;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "0";
        dr[5] = " Seleccionar ";
        dr[6] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }


    public DataTable GetModulosActividades()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetModulosActividades";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);


        return dt;
    }


    public DataTable GetCalendariosModulos(String CodModulo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Calendarios_bymodulos";
        sqlc.Parameters.Add("@CodModulo", SqlDbType.Int, 4).Value = CodModulo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
     
        //dr[0] = "0";
        //dt.Rows.Add(dr);

        return dt;


    }



    public DataTable GetparSituacionPerRel(Int32 FasFae)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparSituacionPersonaRelacionada";
        sqlc.Parameters.Add("@FasFae", SqlDbType.Int, 4).Value = FasFae;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);

        return dt;
    }
    // AGREGADO POR GONZALO MANZUR 14-06-2006
    public DataTable GetparSistemaAdministrativo()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSistemaAdministrativo, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("codSistemaAdministrativo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["codSistemaAdministrativo"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    // HASTA AQUI //


    public DataTable GetparEscolaridadAdulto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEscolaridadAdulto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEscolaridadAdulto", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
       

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                //if ((int)datareader["EdadNivel"] >= EdadNivel)
                //{

                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEscolaridadAdulto"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
               
                dt.Rows.Add(dr);
                //}

            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparEscolaridad()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEscolaridad, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEscolaridad", typeof(int)));
        dt.Columns.Add(new DataColumn("Tipo", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CursoNivel", typeof(int)));
        dt.Columns.Add(new DataColumn("EdadNivel", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar ";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                //if ((int)datareader["EdadNivel"] >= EdadNivel)
                //{

                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodEscolaridad"];
                    dr[1] = (String)datareader["Tipo"];
                    dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                    dr[3] = (int)datareader["CursoNivel"];
                    dr[4] = (int)datareader["EdadNivel"];
                    dr[5] = (String)datareader["IndVigencia"];
                    dt.Rows.Add(dr);
                //}

            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoCargo()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoCargo, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoCargo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
         dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoCargo"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);

            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparCargo()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparCargos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCargo", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
	dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCargo"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);

            }
            catch { }
        }
        con.Desconectar();
        return dt;
    } 
    public DataTable GetparTipoAsistenciaEscolar()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoAsistenciaEscolar , out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoAsistenciaEscolar", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));


        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoAsistenciaEscolar"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetparComunas(string CodRegion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparComunas + CodRegion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodComuna", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProvincia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("PorcentajeAsignacion", typeof(int)));
        dt.Columns.Add(new DataColumn("PorcentajeAsignacionNL", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar ";

        dt.Rows.Add(dr);
        

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodComuna"];
                dr[1] = (int)datareader["CodProvincia"];
                dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[3] = (int)datareader["PorcentajeAsignacion"];
                dr[4] = (int)datareader["PorcentajeAsignacionNL"];
                dr[5] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
 
    public DataTable GetparRegion()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parRegion";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);

        #region Código Eliminado
        //DbDataReader datareader = null;
        //Conexiones con = new Conexiones();
        //con.ejecutar(Resources.Procedures.GetparRegion, out datareader);
        //DataTable dt = new DataTable();
        //DataRow dr;
        //dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));
        //dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        //dt.Columns.Add(new DataColumn("PorcentajeAsignacionNL", typeof(int)));
        //dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        //dt.Columns.Add(new DataColumn("TipoFlujo", typeof(String)));
        //dr = dt.NewRow();
        //dr[0] = -2;
        //dr[1] = " Seleccionar ";
        //dt.Rows.Add(dr);
        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (int)datareader["CodRegion"];
        //        dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
        //        dr[2] = (int)datareader["PorcentajeAsignacionNL"];
        //        dr[3] = (String)datareader["IndVigencia"];
        //        dr[4] = (String)datareader["TipoFlujo"];
        //        dt.Rows.Add(dr);
        //    }
        //    catch { }
        //}
        //con.Desconectar();
    #endregion
        return dt;
    }
    public DataTable GetparRegion_DataSet(DataSet ds)
    {
        DataTable dt = ds.Tables["dtparRegion"];
        return dt;
    }

    public DataTable GetDataRegion(int userid) //Reportes sgf
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Region_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
       dt.Rows.Add(dr);
       
        //dr =dt.NewRow();
        //dr[0] = "78965";
        //dr[1] = " Todas";
        //dt.Rows.Add(dr);

        return dt;
    }
    public DataTable GetDataRegion2(int userid) //Reportes sgf
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Region_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = -2;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Todas";
        dt.Rows.Add(dr);

        return dt;
    }

    public DataTable GetparDiasAtencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDiasAtencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDiasAtencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodNemotecnico", typeof(String)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("DiasSemana", typeof(String)));
        dt.Columns.Add(new DataColumn("Feriado", typeof(Boolean)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
 	dr = dt.NewRow();
        dr[0] = "0";
        dr[2] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDiasAtencion"];
                dr[1] = (String)datareader["CodNemotecnico"];
                dr[2] = (String)datareader["Descripcion"];
                dr[3] = (String)datareader["DiasSemana"];
                dr[4] = (Boolean)datareader["Feriado"];
                dr[5] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoRelacionConQuienVive()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoRelacionConQuienVive, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoRelacionConQuienVive", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoRelacionConQuienVive"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoRelacionPersonaContacto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoRelacionPersonaContacto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoRelacionPersonaContacto", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoRelacionPersonaContacto"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


      public DataTable GetparTipoRelacion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoRelacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoRelacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoRelacion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    

    public DataTable GetparTipoSolicitanteIngreso()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoSolicitanteIngreso , out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoSolicitanteIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoSolicitanteIngreso"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparSolicitanteIngreso(int TipoSolicitanteIngreso)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSolicitanteIngreso + TipoSolicitanteIngreso.ToString(), out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSolicitanteIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoSolicitanteIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSolicitanteIngreso"];
                dr[1] = (int)datareader["TipoSolicitanteIngreso"];
                dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[3] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

   
  //////////////////////// FELIPE ORMAZABAL PINEDA////////////////////////

    public DataTable GetparSolicitanteIngreso()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTerminoDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTerminoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTerminoDiagnostico"];
                dr[1] = (String)datareader[""].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



 /////////////////////////////////////////////FIN/////////////////////////////////////



    public DataTable GetparProfesionOficio()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparProfesionOficio, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodProfesion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("ProfesionOficio", typeof(int)));
        
	dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "Seleccionar";
        dt.Rows.Add(dr);
	while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodProfesion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dr[3] = (int)datareader["ProfesionOficio"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparActividad()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparActividad, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodActividad", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodActividad"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparActividad(Int32 CodModeloIntervencion)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparActividad";
        sqlc.Parameters.Add("@CodModeloIntervencion", SqlDbType.Int, 4).Value = CodModeloIntervencion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetparTipoTribunal()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parTipoTribunal";
        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        DataRow dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;    
    #region Código Eliminado
    //    DbDataReader datareader = null;
    //    Conexiones con = new Conexiones();
    //    con.ejecutar(Resources.Procedures.GetparTipoTribunal, out datareader);
    //    DataTable dt = new DataTable();
    //    DataRow dr;
    //    dt.Columns.Add(new DataColumn("TipoTribunal", typeof(int)));
    //    dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
    //    dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

    //    dr = dt.NewRow();
    //    dr[0] = 0;
    //    dr[1] = " Seleccionar ";

    //    dt.Rows.Add(dr);
    //    while (datareader.Read())
    //    {
    //        try
    //        {
    //            dr = dt.NewRow();
    //            dr[0] = (int)datareader["TipoTribunal"];
    //            dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
    //            dr[2] = (String)datareader["IndVigencia"];
    //            dt.Rows.Add(dr);
    //        }
    //        catch { }
    //    }
    //    con.Desconectar();
    //    return dt;
    #endregion
    }


    public DataTable GetparTipoTribunalADN()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(" Select * from ParTipoTribunal where  LRPA = 1", out datareader);//con.ejecutar(Resources.Procedures.GetparTipoTribunal, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoTribunal", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoTribunal"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }






    public DataTable GetparTribunales(string CodRegion, string TipoTribunal)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = " Select * from parTribunales where CodRegion=@pCodRegion AND TipoTribunal=@pTipoTribunal";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(CodRegion)));
        listDbParameter.Add(Conexiones.CrearParametro("@pTipoTribunal", SqlDbType.Int, 4, Convert.ToInt32(TipoTribunal)));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoTribunal", typeof(int)));
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodCorteApelacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[4] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTribunal"];
                dr[1] = (int)datareader["TipoTribunal"];
                dr[2] = (int)datareader["CodRegion"];
                dr[3] = (int)datareader["CodCorteApelacion"];
                dr[4] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[5] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public int Getregionxcomuna(int CodComuna)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(" SELECT T1.CodComuna, T1.CodProvincia, T2.CodRegion "+
                   "FROM parComunas T1 "+
                   "INNER JOIN parProvincia T2 ON T1.CodProvincia = T2.CodProvincia "+
                   "WHERE T1.CodComuna ="+CodComuna, out datareader);
        int codregion=0;
        while (datareader.Read())
        {
            try
            {
                codregion = (int)datareader["CodRegion"];
               
            }
            catch { }
        }
        con.Desconectar();
        return codregion;
    }

    public DataTable GetparTipoCausalIngresoSingle(int CodCausalIngreso)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        string consulta = "select CodTipoCausalIngreso, Descripcion, IndVigencia, EdadMinima, LRPA from parTipoCausalIngreso t1 where CodTipoCausalIngreso= (SELECT parTipoCausalIngreso.CodTipoCausalIngreso "
                           + "FROM parCausalesIngreso INNER JOIN "
                            + " parTipoCausalIngreso ON parCausalesIngreso.CodTipoCausalIngreso = parTipoCausalIngreso.CodTipoCausalIngreso "
                            + " WHERE (parCausalesIngreso.CodCausalIngreso = @CodCausalIngreso)) order by Descripcion ";
        sqlc.CommandText = consulta;
        sqlc.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = CodCausalIngreso;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable GetparTipoCausalIngreso(int CodProyecto)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoCausalIngreso";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetparTipoCausalIngreso()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoCausalIngreso, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("EdadMinima", typeof(int)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoCausalIngreso"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dr[3] = (int)datareader["EdadMinima"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparCausalEgresoTrabajador()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparCausalEgresoTrabajador, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCausalEgresoTrabajador", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
	     dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCausalEgresoTrabajador"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparCausalesIngreso(string CodTipoCausalIngreso,int codProyecto)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sql;
        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt001 = new DataTable();
        dt001 = LRPA.callto_get_proyectoslrpa(codProyecto);
        if (dt001.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt001.Rows[0][0]) > 0 && dt001.Rows[0][1].ToString() == "20084")
                swLrpa = true;
            else
                swLrpa = false;
        }
        else
        {
            swLrpa = false;
        }

        ///////

        if (CodTipoCausalIngreso == "46")
        //if (CodTipoCausalIngreso == "70") --> Requerimiento 197
        { 
           // con.ejecutar(" Select * from parCausalesIngreso where CodTipoCausalIngreso= '" + CodTipoCausalIngreso + "' AND IndVigencia = 'V'", out datareader);

            ////////
            if (swLrpa)
                sql = " Select * from parCausalesIngreso where CodTipoCausalIngreso= '" + CodTipoCausalIngreso + "' AND IndVigencia = 'V'";
            else

                sql = " SELECT CodCausalIngreso,CodTipoCausalIngreso,Descripcion,IndVigencia,CodNumCausal ,ADN FROM parCausalesIngreso  where codtipocausalingreso =@pcodtipocausalingreso AND IndVigencia = 'V'" +
                            " union " +
                            " SELECT CodCausalIngreso,CodTipoCausalIngreso,Descripcion,IndVigencia,CodNumCausal ,ADN   FROM parCausalesIngreso " +
                            " where codtipocausalingreso in ((select codtipocausalingreso from parTipoCausalIngreso where lrpa=1)) " +
                            " and indvigencia ='V' " +
                            " order by descripcion ";

            listDbParameter.Add(Conexiones.CrearParametro("@pcodtipocausalingreso", SqlDbType.Int, 4, Convert.ToInt32(CodTipoCausalIngreso)));

            
            con.ejecutar(sql, listDbParameter, out datareader);

        }
        else
        {
            //sql = " Select * from parCausalesIngreso where CodTipoCausalIngreso=@pCodTipoCausalIngreso AND IndVigencia = 'V'";
            if (CodTipoCausalIngreso != "67")
            {
                if (swLrpa)
                    sql = " Select * from parCausalesIngreso where CodTipoCausalIngreso= '" + CodTipoCausalIngreso + "' AND IndVigencia = 'V'";
                else
                    sql = " select t3.CodCausalIngreso,t3.CodTipoCausalIngreso,t3.Descripcion,t3.IndVigencia,t3.CodNumCausal " +
                            " from  Proyectos P " +
                            " inner join parCausalIngreso_ModeloIntervencion t2  on t2.CodModeloIntervencion = p.CodModeloIntervencion " +
                            " inner join parCausalesIngreso t3 on t2.CodCausalIngreso=t3.CodCausalIngreso " +
                            " inner join parTipoCausalIngreso t1   on t1.CodTipoCausalIngreso=t3.CodTipoCausalIngreso " +
                            " where t1.IndVigencia  = 'V' and LRPA = 0 and p.codProyecto= @codProyecto" +
                            " and t1.CodTipoCausalIngreso = @pCodTipoCausalIngreso " +
                            " order by 2,1 ";

                listDbParameter.Add(Conexiones.CrearParametro("@codProyecto", SqlDbType.Int, 4, Convert.ToInt32(codProyecto)));

            }
            else
            {
                sql = " select t3.CodCausalIngreso,t3.CodTipoCausalIngreso,t3.Descripcion,t3.IndVigencia,t3.CodNumCausal " +
                        " from  parCausalesIngreso t3 " +
                        " where t3.IndVigencia  = 'V' "+
                        " and t3.CodTipoCausalIngreso = @pCodTipoCausalIngreso" +
                        " order by 2,1 ";
            }

            
            
            listDbParameter.Add(Conexiones.CrearParametro("@pCodTipoCausalIngreso", SqlDbType.Int, 4, Convert.ToInt32(CodTipoCausalIngreso)));

            con.ejecutar(sql, listDbParameter, out datareader);
        }
        //con.ejecutar(" Select * from parCausalesIngreso where CodTipoCausalIngreso= '" + CodTipoCausalIngreso + "' AND IndVigencia = 'V'", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion"));//, typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia"));//, typeof(String)));
        dt.Columns.Add(new DataColumn("CodNumCausal"));//, typeof(String)));

        

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar";
        
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCausalIngreso"];
                dr[1] = (int)datareader["CodTipoCausalIngreso"];
                if (((int)datareader["CodNumCausal"] > 0) && (CodTipoCausalIngreso != "46"))
                {
                    dr[2] = "(" + Convert.ToString((int)datareader["CodNumCausal"])+ ") " + (String)datareader["Descripcion"].ToString().ToUpper();
                }
                else
                 {
                    if (CodTipoCausalIngreso == "46") //&& ((int)datareader["CodNumCausal"] > 0)))
                    {
                        dr[2] = (String)datareader["Descripcion"].ToString().ToUpper() + " (" + Convert.ToString((int)datareader["CodNumCausal"])+ ")" ;
                    }
                    else
                    {
                        dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                    }
                }
                dr[3] = (String)datareader["IndVigencia"];
                dr[1] = (int)datareader["CodNumCausal"];
                

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    
    public int GetparCausalesIngresoCodNumCausal(int CodCausalIngreso)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(" Select CodNumCausal from parCausalesIngreso where CodCausalIngreso= " + CodCausalIngreso + " AND IndVigencia = 'V'", out datareader);
        int codcausal = 0;
        if (datareader.Read())
        {
            try
            {
                codcausal = (int)datareader["CodNumCausal"];
            }
            catch { }
        }
        con.Desconectar();
        return codcausal; 
    }

    
    public DataTable GetparTipoLesiones()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(" Select * from parTipoLesiones", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoLesiones", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoLesiones"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparQuienOcasionaLesion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(" Select * from parQuienOcasionaLesion", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodQuienOcasionaLesion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodQuienOcasionaLesion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparDrogas()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDrogas, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDroga", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDroga"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoConsumoDroga()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoConsumoDroga, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoConsumoDroga", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));


        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoConsumoDroga"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    #region Fabian
    public DataTable GetparTipoDiagnosticosPsicologico()
    {        
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoDiagnosticosPsicologico";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetparInstrumentosDiagnosticosPsicologico(int cod)
    {
        //DataRow dr;
        //dt.Columns.Add(new DataColumn("CodTipoDiagnosticoPsi", typeof(int)));
        //dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        //dr = dt.NewRow();
        //dr[0] = 0;
        //dr[1] = " Seleccionar ";
        //dt.Rows.Add(dr);
        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (int)datareader["CodTipoDiagnosticoPsi"];
        //        dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
        //        dt.Rows.Add(dr);
        //    }
        //    catch { }
        //}
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparInstrumentosDiagnosticosPsicologico";        
        sqlc.Parameters.Add("@Valor_Combo", SqlDbType.Int).Value = cod;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetparMedicionesDiagnosticasPsicologico(int cod)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparMedicionesDiagnosticasPsicologico";
        sqlc.Parameters.Add("@Valor_Combo", SqlDbType.Int).Value = cod;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetparTipoDeTranstornoMentalPsicologico(int cod)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoTranstornoMental";
        sqlc.Parameters.Add("@Valor_Combo", SqlDbType.Int).Value = cod;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }    
    #endregion

    public DataTable GetparInstrumentosDiagnosticos()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparInstrumentosDiagnosticos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodInstrumentoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodInstrumentoDiagnostico"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparMedicionesDiagnosticas(int instrumento)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparMedicionesDiagnosticas + instrumento, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodMedicionesDiagnosticas", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        // dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodMedicionesDiagnosticas"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                // dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
 
    public DataTable GetparSituacionesEspeciales()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSituacionesEspeciales, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacionEspecial", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacionEspecial"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparSituacionSocioEconomica()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSituacionSocioEconomica, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacionSocioEconomica", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacionSocioEconomica"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparSituacionCalle()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSituacionCalle, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacionCalle", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacionCalle"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparEstadoAbandono()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEstadoAbandono, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEstadoAbandono", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("Nemotecnico", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEstadoAbandono"];
                dr[1] = "(" + datareader["Nemotecnico"].ToString().ToUpper() + ") " +  datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["Nemotecnico"];
                dr[3] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparTipoMaltrato()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoMaltrato, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoMaltrato", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));


        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoMaltrato"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparMaltrato(int TipoMaltrato)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparMaltrato + TipoMaltrato, out datareader);
        
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodMaltrato", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoMaltrato", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodMaltrato"];
                dr[1] = (int)datareader["TipoMaltrato"];
                dr[2] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[3] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    

   public DataTable GetparNivelMaltrato(int CodTipoMaltrato)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparNivelMaltrato";

        //sqlc.parAdd(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        sqlc.Parameters.AddWithValue("@CodTipoMaltrato", CodTipoMaltrato);
        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        DataRow dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }

   public DataTable GetparFrecuenciaMaltrato()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparFrecuenciaMaltrato";

        //sqlc.parAdd(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        //sqlc.Parameters.AddWithValue("@CodTipoMaltrato", CodTipoMaltrato);
        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        DataRow dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
}

   public DataTable GetparRespuestaDevelacion()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparRespuestaDevelacion";

        //sqlc.parAdd(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(ICodIE)));
        //sqlc.Parameters.AddWithValue("@CodTipoMaltrato", CodTipoMaltrato);
        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        DataRow dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        return dt;
    }


    public DataTable GetparCategoriasPFMI()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparCategoriasPFMI, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCategoria", typeof(int)));
        dt.Columns.Add(new DataColumn("CodClase", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("Definicion", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCategoria"];
                dr[1] = (int)datareader["CodClase"];
                dr[2] = (String)datareader["Nombre"].ToString().ToUpper();
                dr[3] = (String)datareader["Definicion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetparTipoSolicitanteDiligencia()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoSolicitanteDiligencia, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoSolicitanteDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoSolicitanteDiligencia"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparDiligencia()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDiligencia, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("PropuestaTecnica", typeof(bool)));
        dt.Columns.Add(new DataColumn("ResultadoDiscernimiento", typeof(bool)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDiligencia"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dr[3] = (bool)datareader["PropuestaTecnica"];
                dr[4] = (bool)datareader["ResultadoDiscernimiento"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparDiligencia_FiltroPago()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDiligencia+" and Pago=111", out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDiligencia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("PropuestaTecnica", typeof(bool)));
        dt.Columns.Add(new DataColumn("ResultadoDiscernimiento", typeof(bool)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDiligencia"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dr[3] = (bool)datareader["PropuestaTecnica"];
                dr[4] = (bool)datareader["ResultadoDiscernimiento"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparNivelDiscapacidad()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparNivelDiscapacidad, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNivelDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNivelDiscapacidad"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoDiscapacidad()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoDiscapacidad, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoDiscapacidad", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoDiscapacidad"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparLugarHechoSalud()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparLugarHechoSalud, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodLugarHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodLugarHechoSalud"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    #region felipe 
    public DataTable GetparTipoCapacitacion(int LRPA)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoCapacitacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoCapacitacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("LRPA", typeof(int)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                if ((int)datareader["LRPA"] == LRPA || (int)datareader["LRPA"] == -1)
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["TipoCapacitacion"];
                    dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                    dr[2] = (String)datareader["IndVigencia"];
                    dr[3] = (int)datareader["LRPA"];
                    dt.Rows.Add(dr);
                }                
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoCapacitacion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoCapacitacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoCapacitacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));


        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoCapacitacion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparEstadoCapacitacion(int LRPA)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEstadoCapacitacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEstadoCapacitacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("LRPA", typeof(int)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                if ((int)datareader["LRPA"] == LRPA || (int)datareader["LRPA"] == -1)
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodEstadoCapacitacion"];
                    dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                    dr[2] = (String)datareader["IndVigencia"];
                    dr[3] = (int)datareader["LRPA"];
                    dt.Rows.Add(dr);
                }                
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparEstadoCapacitacion()
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEstadoCapacitacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEstadoCapacitacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEstadoCapacitacion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }




    public DataTable GetparQuienGestionoCapacitacion()
    {        
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parQuienGestionoCapacitacion";
        //sqlc.Parameters.Add("@FasFae", SqlDbType.Int, 4).Value = FasFae;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);

        return dt;
    }


    public DataTable GetparAreaCapacitacion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparAreaCapacitacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodAreaCapacitacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodAreaCapacitacion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparOrganismoCapacitador()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparOrganismoCapacitador, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodOrganismoCapacitador", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodOrganismoCapacitador"];
                dr[1] = (String)datareader["Nombre"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    
    public DataTable GetparTipoTermino()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoTermino, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTerminoDiagnostico", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTerminoDiagnostico"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }      
    public DataTable GetparInsercionLaboral()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparAreaInsercionLAboral, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodAreaInsercionLaboral", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodAreaInsercionLaboral"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    }
    public DataTable GetparSituaciónLaboral()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSituacionLaboral, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacionLaboral", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacionLaboral"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    #endregion


    public DataTable GetparHechosSalud()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparHechosSalud, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodHechoSalud"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparAtencionHechoSalud()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparAtencionHechoSalud, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodAtencionHechoSalud", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodAtencionHechoSalud"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparEnfermedadesCronicas()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEnfermedadesCronicas, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEnfermedadCronica", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEnfermedadCronica"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparNacionalidades()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_parNacionalidad";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        

        #region Código Eliminado
        //DbDataReader datareader = null;
        //Conexiones con = new Conexiones();
        //con.ejecutar(Resources.Procedures.GetparNacionalidades, out datareader);
        //DataTable dt = new DataTable();
        //DataRow dr;
        //dt.Columns.Add(new DataColumn("CodNacionalidad", typeof(int)));
        //dt.Columns.Add(new DataColumn("CodIntenacional", typeof(String)));
        //dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        //dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (int)datareader["CodNacionalidad"];
        //        dr[1] = (String)datareader["CodIntenacional"];
        //        dr[2] = (String)datareader["Descripcion"];
        //        dr[3] = (String)datareader["IndVigencia"];
        //        dt.Rows.Add(dr);
        //    }
        //    catch { }
        //}
        //con.Desconectar();
        #endregion
        return dt;
    }
   


    public DataTable GetparSituacionTuicion(int CodSituacion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
       // conexiones
        con.ejecutar(Resources.Procedures.GetparSituacionTuicion + CodSituacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodSituacionTuicion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodSituacionTuicion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparDiagnosticos()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDiagnosticoGlosa, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoDiagnosticoGlosa", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoDiagnosticoGlosa"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



    public DataTable GetparTerminoDiagnostico()
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTerminoDiagnostico, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEtapasIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);        
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTerminoDiagnostico"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    }

    public DataTable GetparEtapasIntervencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEtapasIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEtapasIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEtapasIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



    public DataTable GetparTipoProyecto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoProyecto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodAreaProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("EsApoyo", typeof(bool)));
        dt.Columns.Add(new DataColumn("Es1385", typeof(bool)));
        dt.Columns.Add(new DataColumn("EsAdmDirecta", typeof(bool)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "0";
        dr[2] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoProyecto"];
                dr[1] = (int)datareader["CodAreaProyecto"];
                dr[2] = (String)datareader["Descripcion"];
                dr[3] = (bool)datareader["EsApoyo"];
                dr[4] = (bool)datareader["Es1385"];
                dr[5] = (bool)datareader["EsAdmDirecta"];
                dr[6] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }



    public DataTable GetparLocalidad(string CodRegion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = Resources.Procedures.GetparLocalidad + "@pCodRegion";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(CodRegion)));

        con.ejecutar(sql, listDbParameter , out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodLocalidad", typeof(int)));
        dt.Columns.Add(new DataColumn("CodProvincia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("PorcentajeAsignacion", typeof(int)));
        dt.Columns.Add(new DataColumn("PorcentajeAsignacionNL", typeof(int)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[2] = "Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodLocalidad"];
                dr[1] = (int)datareader["CodProvincia"];
                dr[2] = (String)datareader["Descripcion"];
                dr[3] = (int)datareader["PorcentajeAsignacion"];
                dr[4] = (int)datareader["PorcentajeAsignacionNL"];
                dr[5] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
        
    }


    public DataTable GetparBancos()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparBancos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodBanco", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("DescCorta", typeof(String)));
        dt.Columns.Add(new DataColumn("Convenio", typeof(bool)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodBanco"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["DescCorta"];
                dr[3] = (bool)datareader["Convenio"];
                dr[4] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetparTematicaProyecto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTematicaProyecto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTematicaProyecto"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparDepartamentosSENAME()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDepartamentosSENAME, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDepartamentosSENAME", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCorto", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDepartamentosSENAME"];
                dr[1] = (String)datareader["Nombre"];
                dr[2] = (String)datareader["NombreCorto"];
                dr[3] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparTipoAtencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoAtencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoAtencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoAtencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparModeloIntervencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparModeloIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CreaPlanIntervencion", typeof(bool)));
        dt.Columns.Add(new DataColumn("CreaInformeDiagnostico", typeof(bool)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("Nemotecnico", typeof(String)));
        dt.Columns.Add(new DataColumn("CantidadIntervenciones", typeof(int)));
        dt.Columns.Add(new DataColumn("LRPA", typeof(int)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodModeloIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (bool)datareader["CreaPlanIntervencion"];
                dr[3] = (bool)datareader["CreaInformeDiagnostico"];
                dr[4] = (String)datareader["IndVigencia"];
                dr[5] = (String)datareader["Nemotecnico"];
                dr[6] = (int)datareader["CantidadIntervenciones"];
                dr[7] = (int)datareader["LRPA"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public int GetModeloIntevencion_ProyectosDAM(int codproyecto)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetModeloIntevencion_ProyectosDAM + " T2.CodProyecto ="+codproyecto, out datareader);
        int codmodelointervencion = 0;

        while (datareader.Read())
        {
            try
            {
                codmodelointervencion = (int)datareader["CodModeloIntervencion"];
            }
            catch { }
        }
        con.Desconectar();
        return codmodelointervencion;
    }
    public DataTable GetparModeloIntervencionxProyecto(int TipoProyecto)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparModeloIntervencionxProyecto + TipoProyecto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CreaPlanIntervencion", typeof(bool)));
        dt.Columns.Add(new DataColumn("CreaInformeDiagnostico", typeof(bool)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dt.Columns.Add(new DataColumn("Nemotecnico", typeof(String)));
        dt.Columns.Add(new DataColumn("CantidadIntervenciones", typeof(int)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodModeloIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (bool)datareader["CreaPlanIntervencion"];
                dr[3] = (bool)datareader["CreaInformeDiagnostico"];
                dr[4] = (String)datareader["IndVigencia"];
                dr[5] = (String)datareader["Nemotecnico"];
                dr[6] = (int)datareader["CantidadIntervenciones"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparModeloIntervecion_Tematica(int CodModeloIntervencion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparModeloIntervencion_Tematica + CodModeloIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("CodDepartamentosSENAME", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion",typeof(String)));
        dr = dt.NewRow();
        dr[1] = "0";
        dr[4] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodModeloIntervencion"];
                dr[1] = (int)datareader["CodTematicaProyecto"];
                dr[2] = (int)datareader["TipoProyecto"];
                dr[3] = (int)datareader["CodDepartamentosSENAME"];
                dr[4] = (String)datareader["Descripcion"];
               
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable parDepartamentosSENAMExModeloIntervencion(int CodModeloIntervencion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDepartamentosSENAMExModeloIntervencion + CodModeloIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDepartamentosSENAME", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCorto", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                if ((int)datareader["CodDepartamentosSENAME"] == 0)
                {
                    dt =  GetparDepartamentosSENAME();
                    break;
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodDepartamentosSENAME"];
                    dr[1] = (String)datareader["Nombre"];
                    dr[2] = (String)datareader["NombreCorto"];
                    dr[3] = (String)datareader["IndVigencia"];


                    dt.Rows.Add(dr);
                }
             }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable getDepartamentosSENAMExModeloIntervencion(int CodModeloIntervencion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDepartamentosSENAMExModeloIntervencion + CodModeloIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDepartamentosSENAME", typeof(int)));
        dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
        dt.Columns.Add(new DataColumn("NombreCorto", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        
        while (datareader.Read())
        {
            try
            {
                if ((int)datareader["CodDepartamentosSENAME"] == 0)
                {
                    dt = GetparDepartamentosSENAME();
                    break;
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodDepartamentosSENAME"];
                    dr[1] = (String)datareader["Nombre"];
                    dr[2] = (String)datareader["NombreCorto"];
                    dr[3] = (String)datareader["IndVigencia"];


                    dt.Rows.Add(dr);
                }
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    
    public DataTable GetparTipoSubvencionxModeloIntervencion(int CodModeloIntervencion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoSubvencionxModeloIntervencion + CodModeloIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("CodModeloIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoSubvencion", typeof(int)));
        dt.Columns.Add(new DataColumn("VidaFamiliar", typeof(String)));
        dr = dt.NewRow();
        dr[0] = " Seleccionar ";
        dr[2] = 0;
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dr[1] = (int)datareader["CodModeloIntervencion"];
                dr[2] = (int)datareader["TipoSubvencion"];
                dr[3] = (String)datareader["VidaFamiliar"];
                

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetparCausalTerminoProyecto()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparCausalTerPro, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCausalTerminoProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCausalTerminoProyecto"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable GetparTipoSubvencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoSubvencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoSubvencion", typeof(int)));
        dt.Columns.Add(new DataColumn("TipoProyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoSubvencion"];
                dr[1] = (int)datareader["TipoProyecto"];
                dr[2] = (String)datareader["Descripcion"];
                dr[3] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparTipoEventoIntervencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoEventoIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoEventoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoEventoIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoEvento(string filtro, List<DbParameter> listDbParameter)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoEventos + filtro, listDbParameter, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoEventos", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoEventos"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparGradoCumplimiento(int CodGradoCumplimiento)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparGradoCumplimiento + CodGradoCumplimiento.ToString(), out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodGradoCumplimiento", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        // dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodGradoCumplimiento"];
                dr[1] = (String)datareader["Descripcion"];
                //    dr[2] = (String)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;


    }

    public DataTable GetparEStadoIntervencion(int CodPlanIntervencion)
    {
        //Sacar Parametro en duro

        CodPlanIntervencion = 275;

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEStadoIntervencion + CodPlanIntervencion.ToString(), out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEstadoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        // dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEstadoIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                //    dr[2] = (String)datareader["IndVigencia"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    public DataTable GetparNivelIntervencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparNivelIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNivelIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
	dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNivelIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparTipoIntervencion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparTipoIntervencion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
	dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    // AGREGADO POR GONZALO MANZUR    //
    public DataTable GetparSituacionLegalInmueble()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparSituacionLegalInmueble, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodsituacionLegalInmueble", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
	dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodsituacionLegalInmueble"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparAreaEspecializacion()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparAreaEspecializacion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodAreaEspecializacion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
	while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodAreaEspecializacion"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable GetparDelitos()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparDelitos, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDelito", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDelito"];
                dr[1] = (String)datareader["Descripcion"].ToString().ToUpper();
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetParCausalesIngreso(int CodTipoCausalIngreso)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetCausalIngreso, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));


        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodCausalIngreso"];
                dr[1] = (String)datareader["Descripcion"];

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    }

    public DataTable GetTipoCausal()
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoCausal, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoCausalIngreso"];
                dr[1] = (String)datareader["Descripcion"];
               
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    
    
    
    }
    public DataTable GetParMateriaCausa()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparMateriaCausa, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodMateriaCausa", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar ";

        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodMateriaCausa"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

 public DataTable GetparTipoAtencionxProyectoUno()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoAtencionxProyectoUno, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodTipoAtencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt.Columns.Add(new DataColumn("IndVigencia", typeof(String)));
        dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodTipoAtencion"];
                dr[1] = (String)datareader["Descripcion"];
                dr[2] = (String)datareader["IndVigencia"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }
    
   public DataTable GetparEventosIntervencionCantidadxModelo(int CodProyecto)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEventosIntervencionCantidadxModelo + CodProyecto, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("TipoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
         dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar ";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["TipoIntervencion"];
                dr[1] = (String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

   public DataTable GetparEtnias()
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetparEtnias, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodEtnia", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodEtnia"];
                dr[1] = (String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetParDireccionRegional(int codregion)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetParDireccionRegional +" and CodRegion= "+codregion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDireccionRegional", typeof(int)));
        dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
       
        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDireccionRegional"];
                dr[1] = (String)datareader["Descripcion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetparEncuestaRespuesta(int CodEncuesta)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + " ;Database= " + objconn.DatabaseName + " ; User ID= " + objconn.User + " ;Password= " + objconn.Password + " ;Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparEncuestaRespuesta";
        sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = CodEncuesta;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);

        return dt;
    }

    public DataTable getTipoEventosAnalisisCasos()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "getTipoEventosAnalisisCasos";
        //sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = CodEncuesta;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = "Seleccionar";
        dt.Rows.Add(dr);


        return dt;
    }

    public DataTable getAtendidos()
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "getAtendidos";
        //sqlc.Parameters.Add("@CodEncuesta", SqlDbType.Int, 4).Value = CodEncuesta;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }
    public DataTable getparTerminoSalida()
    {
        DataTable dt = new DataTable();
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "getparTerminoSalida";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;


    }
    public DataTable getparCategoriaPM()
    {
       
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparCategoriaPM";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetParCondicionPM1()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetParCondicionPM1";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetParCondicionPM3()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetParCondicionPM3";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetParFlexibilizacion()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetParFlexibilizacion";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;  
    }
    public DataTable GetParTalleres()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetParTalleres";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
        
    }
    public DataTable GetNombreTalleres(int codTaller)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNombreTalleres";
        sqlc.Parameters.Add("@codTipoTaller", SqlDbType.Int).Value = codTaller;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;        
    }
    public DataTable GetParAmbito()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetParAmbito";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
         sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable GetparModulo()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetParModulo";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable ConsultoTaller()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Consulta_Taller";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable ConsultoTaller2(int codtaller)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn; 
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Consulta_Taller2";
        sqlc.Parameters.Add("@IcodTaller", SqlDbType.Int).Value = codtaller;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable ObtengoArticulo134bis(int icodie)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "ObtenerArticulo134bis";
        sqlc.Parameters.Add("@Icodie", SqlDbType.Int).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;

    }
  
    
    
}
