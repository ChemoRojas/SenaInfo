using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Common;
////////using neocsharp.NeoDatabase;

/// <summary>
/// Descripción breve de RendicionIngresoColl
/// </summary>
public class ReporteNinoColl
{
	public ReporteNinoColl()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable callto_reporte_deteccionprecoz(int region, int codproyecto, DateTime fechainicio, DateTime fechatermino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "reporte_DeteccionPrecoz";
        sqlc.Parameters.Add("@region", SqlDbType.Int, 4).Value = region;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@fechainicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@fechatermino", SqlDbType.DateTime, 16).Value = fechatermino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable ejecuta_SQL(string sql)
    {
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
    public  DataTable callto_reporte_persona_contacto(int codproyecto, int anomes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_Persona_Contacto";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = anomes;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable Reporte_Nomina_InfraccionLPRA_Fecha(int codproyecto, int anomes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Nomina_LPRA_InfracionesDisciplinariasII";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = anomes;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable Reporte_Nomina_InfraccionLPRA(int TipoListado, int CodProyecto, DateTime FechaIngreso, int AnoMes)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        //DbParameter[] parametros = {
        //    con.parametros("@TipoListado",SqlDbType.Int,4,TipoListado),
        //    con.parametros("@CodProyecto",SqlDbType.Int,4, CodProyecto),
        //    con.parametros("@FechaIngreso",SqlDbType.DateTime ,8, FechaIngreso.ToShortDateString().ToString().Replace("-","/")),
        //    con.parametros("@AnoMes",SqlDbType.Int,6, AnoMes)
        //};

        DataTable dt = new DataTable();
        con.Autenticar();
        dt = con.TraerDataTable("Get_Nomina_LPRA_InfracionesDisciplinarias", TipoListado, CodProyecto, FechaIngreso, AnoMes);
        if (dt.Rows.Count == 0)
        {
            DataRow fila = dt.NewRow();
            dt.Rows.Add(fila);
        }
        datareader = dt.CreateDataReader();
        //con.ejecutarProcedimiento("Get_Nomina_LPRA_InfracionesDisciplinarias", parametros, out datareader);

        
        //dt.Columns.Add("CodProyecto", typeof(int));                    //0
        //dt.Columns.Add("Nombre", typeof(String));              //1
        //dt.Columns.Add("CodModeloIntervencion", typeof(int));                       //2
        //dt.Columns.Add("ModeloIntervencion", typeof(String));                      //3
        //dt.Columns.Add("Nemotecnico", typeof(String));                  //4
        //dt.Columns.Add("ICodIE", typeof(int));                       //5
        //dt.Columns.Add("CodNino", typeof(int));                         //6
        //dt.Columns.Add("FechaIngreso", typeof(String));                         //7
        //dt.Columns.Add("FechaEgreso", typeof(String));                      //8
        //dt.Columns.Add("Nombres", typeof(String));             //9
        //dt.Columns.Add("Apellido_Paterno", typeof(String));             //10   
        //dt.Columns.Add("Apellido_Materno", typeof(String));                          //11
        //dt.Columns.Add("FechaNacimiento", typeof(String));              //12
        //dt.Columns.Add("Rut", typeof(String));                         //13
        //dt.Columns.Add("Sexo", typeof(String));                //14
        //dt.Columns.Add("FechaEventoFalta", typeof(String));                 //15
        //dt.Columns.Add("PresentaDenunciaFalta_Afirmacion", typeof(int));                //16    
        //dt.Columns.Add("PresentaDenuncia", typeof(String));              //17    
        //dt.Columns.Add("AmeritaFalta_Afirmacion", typeof(int));               //18
        //dt.Columns.Add("AmeritaInfraccionDisciplinaria", typeof(String));                //19
        //dt.Columns.Add("DescripcionEvento", typeof(String));               //20
        //dt.Columns.Add("N°Acta", typeof(String));                          //21
        //dt.Columns.Add("FechaSesion", typeof(String));                          //22
        //dt.Columns.Add("AplicaSancionCD_Afirmacion", typeof(int));                     //23
        //dt.Columns.Add("SeAplicaSancion", typeof(String));     //24
        //dt.Columns.Add("CodTipoFaltaCF", typeof(int));                  //25
        //dt.Columns.Add("TipoInfraccionDisciplinaria", typeof(String));                  //26 
        //dt.Columns.Add("InfraccionDisciplinaria1", typeof(String));                  //27 
        //dt.Columns.Add("CodFalta1CF", typeof(int));                  //28 
        //dt.Columns.Add("InfraccionDisciplinaria2", typeof(String));                 //29 
        //dt.Columns.Add("CodFalta2CF", typeof(int));                        //30 
        //dt.Columns.Add("InfraccionDisciplinaria3", typeof(String));                        //31 
        //dt.Columns.Add("CodFalta3CF", typeof(int));             //32
        //dt.Columns.Add("InfraccionDisciplinaria4", typeof(String));         //33
        //dt.Columns.Add("CodFalta4CF", typeof(int));           //34
        //dt.Columns.Add("Sancion1", typeof(String));                  //35
        //dt.Columns.Add("CodSancionFalta1CF", typeof(int));        //36
        //dt.Columns.Add("Sancion2", typeof(String));          //37    
        //dt.Columns.Add("CodSancionFalta2CF", typeof(int));                 //38 
        //dt.Columns.Add("Sancion3", typeof(String));                  //39
        //dt.Columns.Add("CodSancionFalta3CF", typeof(int));                  //40
        //dt.Columns.Add("Sancion4", typeof(String));                  //41
        //dt.Columns.Add("CodSancionFalta4CF", typeof(int));                  //42
        //dt.Columns.Add("NdeDias", typeof(String));     //24
        //dt.Columns.Add("CodDiasDS", typeof(int));                  //25
        //dt.Columns.Add("NdeSemanas", typeof(String));                  //26 
        //dt.Columns.Add("CodSemanaDS", typeof(int));                  //27 
        //dt.Columns.Add("NdeMeses", typeof(String));                  //28 
        //dt.Columns.Add("CodMesDS", typeof(int));                //29 
        //dt.Columns.Add("RatificacionDirector-a", typeof(String));                        //30 
        //dt.Columns.Add("RatificaDirectorDS_Afirmacion", typeof(int));                        //31 
        //dt.Columns.Add("MediodDeNotificacionAlTribunal", typeof(String));             //32
        //dt.Columns.Add("CodMedioNotificacionTribunalFRS", typeof(int));         //33
        //dt.Columns.Add("NotificacionTribunal", typeof(String));           //34
        //dt.Columns.Add("NotificacionTribunalFRS_Afirmacion", typeof(int));                  //35
        //dt.Columns.Add("NotificacionJoven", typeof(String));        //36
        //dt.Columns.Add("CodNotificacionJovenFRS", typeof(int));          //37    
        //dt.Columns.Add("RegistroExpediente", typeof(String));                 //38 
        //dt.Columns.Add("RegistroExpedienteFRS_Afirmacion", typeof(int));                  //39
        //dt.Columns.Add("ConsideraReporteJoven", typeof(String));                  //40
        //dt.Columns.Add("ConsideraReporteJovenEDP_Afirmacion", typeof(int));                  //41
        //dt.Columns.Add("RevisionCircunstanciasResponsabilidad", typeof(String));                  //42
        //dt.Columns.Add("RevisionCircunstanciasEDP_Afirmacion", typeof(int));     //24
        //dt.Columns.Add("GestionComprobacionHecho", typeof(String));                  //25
        //dt.Columns.Add("GestionesComprobacionEDP_Afirmacion", typeof(int));                  //26 
        //dt.Columns.Add("QuienApela", typeof(String));                  //27 
        //dt.Columns.Add("CodQuienApelaRRS", typeof(int));                  //28 
        //dt.Columns.Add("SeAcogeApelacion", typeof(String));                 //29 
        //dt.Columns.Add("CodSeAcogeApelacionRRS", typeof(int));                        //30 
        //dt.Columns.Add("SeAplicaSeparacion", typeof(String));                        //31 
        //dt.Columns.Add("SeAplicaSeparacionPS_Afirmacion", typeof(int));             //32
        //dt.Columns.Add("Duracion", typeof(String));         //33
        //dt.Columns.Add("CodDuracionSeparacionPS", typeof(int));           //34
        //dt.Columns.Add("EspacioDeSeparacion", typeof(String));                  //35
        //dt.Columns.Add("CodEspacioSeparacionPS", typeof(int));        //36
        //dt.Columns.Add("SeAplicaIntervencion", typeof(String));          //37    
        //dt.Columns.Add("CodAplicacionIntervencionISRN", typeof(int));                 //38 
        //dt.Columns.Add("DescripcionIntervencionSocioeducativa", typeof(String));                  //39
        //dt.Columns.Add("RefuerzoNegativo", typeof(String));                  //40
        //dt.Columns.Add("CodRefuerzoNegativoAdicionalISRN", typeof(int));                  //41
        //dt.Columns.Add("OtroRefuerzoNegativo", typeof(String));                  //42
        //dt.Columns.Add("Constituye", typeof(String));                  //39
        //dt.Columns.Add("ConstituyeCC_Afirmacion", typeof(int));                  //40
        //dt.Columns.Add("ProcedimientoGenchi", typeof(String));                  //41
        //dt.Columns.Add("CodConflictoCriticoCC", typeof(int));                  //42

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();

                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = (System.String)datareader["Nombre"];
                dr[2] = (System.Int32)datareader["CodModeloIntervencion"];
                dr[3] = (System.String)datareader["ModeloIntervencion"];
                dr[4] = (System.String)datareader["Nemotecnico"];
                dr[5] = (System.Int32)datareader["ICodIE"];
                dr[6] = (System.Int32)datareader["CodNino"];

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaIngreso"]).ToShortDateString()) == "01-01-1900")
                {
                    dr[7] = "-";
                }
                else
                {
                    dr[7] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaIngreso"]).ToShortDateString());
                }

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString()) == "01-01-1900")
                {
                    dr[8] = "-";
                }
                else
                {
                    dr[8] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString());
                }

                //if ((System.DBNull)datareader["FechaEgreso"] != null)
                //{
                //    dr[8] = "01-01-1900";
                //}
                //else
                //{
                //    dr[8] = (System.DateTime)datareader["FechaEgreso"];
                //}            

                dr[9] = (System.String)datareader["Nombres"];
                dr[10] = (System.String)datareader["Apellido_Paterno"];
                dr[11] = (System.String)datareader["Apellido_Materno"];

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString()) == "01-01-1900")
                {
                    dr[12] = "-";
                }
                else
                {
                    dr[12] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString());
                }

                dr[13] = (System.String)datareader["Rut"];
                dr[14] = (System.String)datareader["Sexo"];

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEventoFalta"]).ToShortDateString()) == "01-01-1900")
                {
                    dr[15] = "-";
                }
                else
                {
                    dr[15] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEventoFalta"]).ToShortDateString());
                }


                dr[16] = (System.Int32)datareader["PresentaDenunciaFalta_Afirmacion"];
                dr[17] = (System.String)datareader["PresentaDenuncia"];
                dr[18] = (System.Int32)datareader["AmeritaFalta_Afirmacion"];
                dr[19] = (System.String)datareader["AmeritaInfraccionDisciplinaria"];
                dr[20] = (System.String)datareader["DescripcionEvento"];
                dr[21] = Convert.ToString((System.Int32)datareader["N°Acta"]);

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaSesion"]).ToShortDateString()) == "01-01-1900")
                {
                    dr[22] = "-";
                }
                else
                {
                    dr[22] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaSesion"]).ToShortDateString());
                }

                dr[23] = (System.Int32)datareader["AplicaSancionCD_Afirmacion"];
                dr[24] = (System.String)datareader["SeAplicaSancion"];
                dr[25] = (System.Int32)datareader["CodTipoFaltaCF"];
                dr[26] = (System.String)datareader["TipoInfraccionDisciplinaria"];
                dr[27] = (System.String)datareader["InfraccionDisciplinaria1"];
                dr[28] = (System.Int32)datareader["CodFalta1CF"];
                dr[29] = (System.String)datareader["InfraccionDisciplinaria2"];
                dr[30] = (System.Int32)datareader["CodFalta2CF"];
                dr[31] = (System.String)datareader["InfraccionDisciplinaria3"];
                dr[32] = (System.Int32)datareader["CodFalta3CF"];
                dr[33] = (System.String)datareader["InfraccionDisciplinaria4"];
                dr[34] = (System.Int32)datareader["CodFalta4CF"];
                dr[35] = (System.String)datareader["Sancion1"];
                dr[36] = (System.Int32)datareader["CodSancionFalta1CF"];
                dr[37] = (System.String)datareader["Sancion2"];
                dr[38] = (System.Int32)datareader["CodSancionFalta2CF"];
                dr[39] = (System.String)datareader["Sancion3"];
                dr[40] = (System.Int32)datareader["CodSancionFalta3CF"];
                dr[41] = (System.String)datareader["Sancion4"];
                dr[42] = (System.Int32)datareader["CodSancionFalta4CF"];
                dr[43] = (System.String)datareader["NdeDias"];
                dr[44] = (System.Int32)datareader["CodDiasDS"];
                dr[45] = (System.String)datareader["NdeSemanas"];
                dr[46] = (System.Int32)datareader["CodSemanaDS"];
                dr[47] = (System.String)datareader["NdeMeses"];
                dr[48] = (System.Int32)datareader["CodMesDS"];
                dr[49] = (System.String)datareader["RatificacionDirector-a"];
                dr[50] = (System.Int32)datareader["RatificaDirectorDS_Afirmacion"];
                dr[51] = (System.String)datareader["MediodDeNotificacionAlTribunal"];
                dr[52] = (System.Int32)datareader["CodMedioNotificacionTribunalFRS"];
                dr[53] = (System.String)datareader["NotificacionTribunal"];
                dr[54] = (System.Int32)datareader["NotificacionTribunalFRS_Afirmacion"];
                dr[55] = (System.String)datareader["NotificacionJoven"];
                dr[56] = (System.Int32)datareader["CodNotificacionJovenFRS"];
                dr[57] = (System.String)datareader["RegistroExpediente"];
                dr[58] = (System.Int32)datareader["RegistroExpedienteFRS_Afirmacion"];
                dr[59] = (System.String)datareader["ConsideraReporteJoven"];
                dr[60] = (System.Int32)datareader["ConsideraReporteJovenEDP_Afirmacion"];
                dr[61] = (System.String)datareader["RevisionCircunstanciasResponsabilidad"];
                dr[62] = (System.Int32)datareader["RevisionCircunstanciasEDP_Afirmacion"];
                dr[63] = (System.String)datareader["GestionComprobacionHecho"];
                dr[64] = (System.Int32)datareader["GestionesComprobacionEDP_Afirmacion"];
                dr[65] = (System.String)datareader["QuienApela"];
                dr[66] = (System.Int32)datareader["CodQuienApelaRRS"];
                dr[67] = (System.String)datareader["SeAcogeApelacion"];
                dr[68] = (System.Int32)datareader["CodSeAcogeApelacionRRS"];
                dr[69] = (System.String)datareader["SeAplicaSeparacion"];
                dr[70] = (System.Int32)datareader["SeAplicaSeparacionPS_Afirmacion"];
                dr[71] = (System.String)datareader["Duracion"];
                dr[72] = (System.Int32)datareader["CodDuracionSeparacionPS"];
                dr[73] = (System.String)datareader["EspacioDeSeparacion"];
                dr[74] = (System.Int32)datareader["CodEspacioSeparacionPS"];
                dr[75] = (System.String)datareader["SeAplicaIntervencion"];
                dr[76] = (System.Int32)datareader["CodAplicacionIntervencionISRN"];
                dr[77] = (System.String)datareader["DescripcionIntervencionSocioeducativa"];
                dr[78] = (System.String)datareader["RefuerzoNegativo"];
                dr[79] = (System.Int32)datareader["CodRefuerzoNegativoAdicionalISRN"];
                dr[80] = (System.String)datareader["OtroRefuerzoNegativo"];
                dr[81] = (System.String)datareader["Constituye"];
                dr[82] = (System.Int32)datareader["ConstituyeCC_Afirmacion"];
                dr[83] = (System.String)datareader["ProcedimientoGenchi"];
                dr[84] = (System.Int32)datareader["CodConflictoCriticoCC"];

                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        con.CerrarConexion();
        return dt;
    }
    public DataTable callto_reporte_personas_relacionadas(int codproyecto, int anomes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_Personas_Relacionadas";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = anomes;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_reporte_personas_relacionadasGuardadoras(int TipoListado, int CodProyecto, DateTime FechaInicio, DateTime FechaTermino, int anomes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Nomina_Guardadoras ";
        sqlc.Parameters.Add("@TipoListado", SqlDbType.Int, 4).Value = TipoListado;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 4).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 4).Value = FechaTermino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_reporte_personas_relacionadasDetalle(int TipoListado, int CodProyecto, DateTime FechaInicio, DateTime FechaTermino, int anomes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Nomina_Personas "; //sgf 02Nov2010
        sqlc.Parameters.Add("@TipoListado", SqlDbType.Int, 4).Value = TipoListado;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 4).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 4).Value = FechaTermino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_reporte_Lista_Espera(int TipoListado, int CodProyecto, DateTime FechaInicio, DateTime FechaTermino, int CodInstitucion, int CodRegion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_ListaEspera"; //sgf 02Nov2010
        sqlc.Parameters.Add("@TipoListado", SqlDbType.Int, 4).Value = TipoListado;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 4).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 4).Value = FechaTermino;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = CodRegion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_reporte_susceptibleabandono(int region, DateTime fechainicio, DateTime fechatermino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "reporte_SusceptibleAbandono";
        sqlc.Parameters.Add("@region", SqlDbType.Int, 4).Value = region;
        sqlc.Parameters.Add("@fechainicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@fechatermino", SqlDbType.DateTime, 16).Value = fechatermino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_indicador_abandono(int region, DateTime fechainicio, DateTime fechatermino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "indicador_abandono";
        sqlc.Parameters.Add("@region", SqlDbType.Int, 4).Value = region;
        sqlc.Parameters.Add("@fechainicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@fechatermino", SqlDbType.DateTime, 16).Value = fechatermino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_reporte_diagnosticos_ninos(int codproyecto, int anomes, int tipodiagnostico)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_Diagnosticos_Ninos";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = anomes;
        sqlc.Parameters.Add("@TipoDiagnostico", SqlDbType.Int, 4).Value = tipodiagnostico;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public DataTable callto_reporte_diligencias(int codproyecto, int mes, int año, int tiporeporte)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "reporte_diligencias";
        sqlc.Parameters.Add("@Codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mes", SqlDbType.Int, 4).Value = mes;
        sqlc.Parameters.Add("@año", SqlDbType.Int, 4).Value = año;
        sqlc.Parameters.Add("@TipoReporte", SqlDbType.Int, 4).Value = tiporeporte;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable callto_reporte_monitoreo_indicadores(int codproyecto, DateTime aniomes, string reporte, int codinstitucion, int codregion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = reporte;
        sqlc.Parameters.Add("@Region", SqlDbType.Int, 4).Value = codregion;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 7).Value = codproyecto;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 10).Value = aniomes;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Get_ReporteNino( Int32 region, Int32 codinstitucion, Int32 codproyecto, DateTime fechainicio, DateTime fechatermino, int PII, int userid)//, //DataTable dt)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandTimeout = 120;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_intervenciones";
        sqlc.Parameters.Add("@region", SqlDbType.Int, 4).Value = region;
        sqlc.Parameters.Add("@codinstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@fechainicio", SqlDbType.DateTime, 16).Value = fechainicio;
        sqlc.Parameters.Add("@fechatermino", SqlDbType.DateTime, 16).Value = fechatermino;
        sqlc.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int, 4).Value = PII;
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Get_ReportePII(Int32 CodRegion, Int32 CodInstitucion, Int32 CodProyecto, Int32 CodPII, DateTime FechaInicio, DateTime FechaTermino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_PII";
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = CodRegion;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@CodPII", SqlDbType.Int, 4).Value = CodPII;
        sqlc.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 16).Value = FechaInicio;
        sqlc.Parameters.Add("@FechaTermino", SqlDbType.DateTime, 16).Value = FechaTermino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Get_HisIngreso(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@codnino",SqlDbType.Int,4,codnino)};
        con.ejecutarProcedimiento("historico_ingresos", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("codigo"); dt.Columns.Add("FechaIngreso");
        dt.Columns.Add("causal1"); dt.Columns.Add("causal2"); dt.Columns.Add("causal3");
        dt.Columns.Add("Causal_Ingreso_1");dt.Columns.Add("Causal_Ingreso_2"); dt.Columns.Add("Causal_Ingreso_3");
        dt.Columns.Add("rut");  dt.Columns.Add("paterno");dt.Columns.Add("materno"); dt.Columns.Add("Nombres");
        dt.Columns.Add("codproyecto"); dt.Columns.Add("proyecto");
        dt.Columns.Add("codinst");    dt.Columns.Add("Nombreints");
        dt.Columns.Add("modelo_cod");  dt.Columns.Add("Modelo");
        dt.Columns.Add("FechaEgreso"); dt.Columns.Add("CodCausalEgreso"); dt.Columns.Add("Causal_Egreso");
        dt.Columns.Add("CodConQuienEgresa"); dt.Columns.Add("Con_Quien_Egresa");
        DataRow dr;
        while (datareader.Read())
        {   try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["codigo"];
                dr[1] = (System.String)datareader["FechaIngreso"];
                dr[2] = (System.Int32)datareader["causal1"];
                dr[3] = (System.Int32)datareader["causal2"];
                dr[4] = (System.Int32)datareader["causal3"];
                dr[5] = (System.String)datareader["Causal_Ingreso_1"];
                dr[6] = (System.String)datareader["Causal_Ingreso_2"];
                dr[7] = (System.String)datareader["Causal_Ingreso_3"];
                dr[8] = (System.String)datareader["rut"];
                dr[9] = (System.String)datareader["paterno"];
                dr[10] = (System.String)datareader["materno"];
                dr[11] = (System.String)datareader["Nombres"];
                dr[12] = (System.Int32)datareader["codproyecto"];
                dr[13] = (System.String)datareader["proyecto"];
                dr[14] = (System.Int32)datareader["codinst"];
                dr[15] = (System.String)datareader["Nombreints"];
                dr[16] = (System.Int32)datareader["modelo_cod"];
                dr[17] = (System.String)datareader["Modelo"];
                dr[18] = (System.String)datareader["FechaEgreso"];
                dr[19] = (System.Int32)datareader["CodCausalEgreso"];
                dr[20] = (System.String)datareader["Causal_Egreso"];
                dr[21] = (System.Int32)datareader["CodConQuienEgresa"];
                dr[22] = (System.String)datareader["Con_Quien_Egresa"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisEscolar(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_escolar", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion"); 
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto"); 
        dt.Columns.Add("escolaridad");
        dt.Columns.Add("ultimo");
        dt.Columns.Add("fecha");
        dt.Columns.Add("asistencia");

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["escolaridad"];
                dr[4] = (System.Int32)datareader["ultimo"];
                dr[5] = (System.String)datareader["fecha"];
                dr[6] = (System.String)datareader["asistencia"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisMaltrato(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_maltrato", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("agresor");
        dt.Columns.Add("relacion");
        dt.Columns.Add("maltrato");
        dt.Columns.Add("tipo");
        dt.Columns.Add("fecha");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["agresor"];
                dr[4] = (System.String)datareader["relacion"];
                dr[5] = (System.String)datareader["maltrato"];
                dr[6] = (System.String)datareader["tipo"];
                dr[7] = (System.String)datareader["fecha"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisDroga(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_droga", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("droga");
        dt.Columns.Add("tipo");
        dt.Columns.Add("fecha");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["droga"];
                dr[4] = (System.String)datareader["tipo"];
                dr[5] = (System.String)datareader["fecha"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisPsicologico(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_psicologico", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("instrumento");
        dt.Columns.Add("medicion");
        dt.Columns.Add("fecha");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["instrumento"];
                dr[4] = (System.String)datareader["medicion"];
                dr[5] = (System.String)datareader["fecha"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisSocial(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_social", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("calle");
        dt.Columns.Add("fecha");
        dt.Columns.Add("tuicion");
        dt.Columns.Add("especial");
        dt.Columns.Add("estado");

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["calle"];
                dr[4] = (System.String)datareader["fecha"];
                dr[5] = (System.String)datareader["tuicion"];
                dr[6] = (System.String)datareader["especial"];
                dr[7] = (System.String)datareader["estado"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisCapacitacion(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_capacitacion", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("area");
        dt.Columns.Add("tipo");
        dt.Columns.Add("estado");
        dt.Columns.Add("organismo");
        dt.Columns.Add("inicio");
        dt.Columns.Add("termino");

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["area"];
                dr[4] = (System.String)datareader["tipo"];
                dr[5] = (System.String)datareader["estado"];
                dr[6] = (System.String)datareader["organismo"];
                dr[7] = (System.String)datareader["inicio"];
                dr[8] = (System.String)datareader["termino"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisLaboral(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_laboral", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("ingreso");
        dt.Columns.Add("fecha");
        dt.Columns.Add("area");
        dt.Columns.Add("situacion");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["ingreso"];
                dr[4] = (System.String)datareader["fecha"];
                dr[5] = (System.String)datareader["area"];
                dr[6] = (System.String)datareader["situacion"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisJudiciales(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_hechosjudiciales", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("tribunal");
        dt.Columns.Add("materia");
        dt.Columns.Add("fecha");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["tribunal"];
                dr[4] = (System.String)datareader["materia"];
                dr[5] = (System.String)datareader["fecha"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisPfti(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_pfti", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("agresor");
        dt.Columns.Add("relacion");
        dt.Columns.Add("categoria");
        dt.Columns.Add("fecha");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["agresor"];
                dr[4] = (System.String)datareader["relacion"];
                dr[5] = (System.String)datareader["categoria"];
                dr[6] = (System.String)datareader["fecha"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisDiscapacidad(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_discapacidad", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("FechaDiagnostico");
        dt.Columns.Add("discapacidad");
        dt.Columns.Add("nivel");
        dt.Columns.Add("Observacion");
        dt.Columns.Add("ICodIE");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["FechaDiagnostico"];
                dr[4] = (System.String)datareader["discapacidad"];
                dr[5] = (System.String)datareader["nivel"];
                dr[6] = (System.String)datareader["Observacion"];
                dr[7] = (System.Int32)datareader["ICodIE"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
  
    public DataTable Get_HisSalud(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_hechosalud", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("FechaDiagnostico");
        dt.Columns.Add("hecho");
        dt.Columns.Add("atencion");
        dt.Columns.Add("lugar");
        dt.Columns.Add("ICodIE");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["codproyecto"];
                dr[2] = (System.String)datareader["proyecto"];
                dr[3] = (System.String)datareader["FechaDiagnostico"];
                dr[4] = (System.String)datareader["hecho"];
                dr[5] = (System.String)datareader["atencion"];
                dr[6] = (System.String)datareader["lugar"];
                dr[7] = (System.Int32)datareader["ICodIE"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisEnfermedades(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("historico_diag_enfermedadescronicas", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("institucion");
        dt.Columns.Add("ICodIE");
        dt.Columns.Add("codproyecto");
        dt.Columns.Add("proyecto");
        dt.Columns.Add("FechaDiagnostico");
        dt.Columns.Add("enfermedad");
        dt.Columns.Add("Observacion");       
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["institucion"];
                dr[1] = (System.Int32)datareader["ICodIE"];
                dr[2] = (System.Int32)datareader["codproyecto"];
                dr[3] = (System.String)datareader["proyecto"];
                dr[4] = (System.String)datareader["FechaDiagnostico"];
                dr[5] = (System.String)datareader["enfermedad"];
                dr[6] = (System.String)datareader["Observacion"];             
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_HisPersonas(Int32 codnino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@codnino", SqlDbType.Int, 4, codnino) };
        con.ejecutarProcedimiento("reporte_persona_relacionada", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("codigo");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("relacion");
        dt.Columns.Add("Situacion_1");
        dt.Columns.Add("Situacion_2");
        dt.Columns.Add("Situacion_3");
        dt.Columns.Add("comentario");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["codigo"];
                dr[1] = (System.String)datareader["Nombre"];
                dr[2] = (System.String)datareader["relacion"];
                dr[3] = (System.String)datareader["Situacion_1"];
                dr[4] = (System.String)datareader["Situacion_2"];
                dr[5] = (System.String)datareader["Situacion_3"];
                dr[6] = (System.String)datareader["comentario"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }
    public DataTable Get_CatastroColl(DateTime fecvigencia)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@FechaVigencia", SqlDbType.DateTime,16,fecvigencia)
                                             };

        con.ejecutarProcedimiento("CatastroJueces", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodRegion");
        dt.Columns.Add("nCodRegion");
        dt.Columns.Add("CodComuna");
        dt.Columns.Add("nComuna");
        dt.Columns.Add("CodProvincia");
        dt.Columns.Add("nCodProvincia");
        dt.Columns.Add("CodProyecto");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Direccion");
        dt.Columns.Add("Telefono");
        dt.Columns.Add("Mail");
        dt.Columns.Add("Fax");
        dt.Columns.Add("Director");
        dt.Columns.Add("TipoProyecto");
        dt.Columns.Add("nTipoProyecto");
        dt.Columns.Add("TipoSubvencion");
        dt.Columns.Add("nTipoSubvencion");
        dt.Columns.Add("CodTematicaProyecto");
        dt.Columns.Add("nCodTematica");
        dt.Columns.Add("CodModeloIntervencion");
        dt.Columns.Add("nModelo");
        dt.Columns.Add("NumeroPlazas");
        dt.Columns.Add("Sexo");
        dt.Columns.Add("CodDiasAtencion");
        dt.Columns.Add("IndVigencia");
        dt.Columns.Add("TerminoProyecto");
        dt.Columns.Add("FechaInicio");
        dt.Columns.Add("FechaTermino");
        dt.Columns.Add("NemoTecnico");
        dt.Columns.Add("CodDepartamentosSename");
        dt.Columns.Add("FechaCreacion");
        dt.Columns.Add("Tematica");
        dt.Columns.Add("Peso");
        dt.Columns.Add("VigenciaTematica");
        dt.Columns.Add("FechaConvenio");
        dt.Columns.Add("FechaConvenio2");
        dt.Columns.Add("CodInstitucion");
        dt.Columns.Add("NombreInstitucion");
        dt.Columns.Add("CodSistemaAsistencial");
        dt.Columns.Add("NombreSistemaAsistencial");
        dt.Columns.Add("NombreDepartamentosSename");
        dt.Columns.Add("EdadMinima");
        dt.Columns.Add("EdadMaxima");
        dt.Columns.Add("FechaVigenciaMes");
        dt.Columns.Add("FechaVigenciaAgno");
        dt.Columns.Add("NomRegion");
        dt.Columns.Add("Monto");
        dt.Columns.Add("Criterio");
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodRegion"];
                dr[1] = (System.String)datareader["nCodRegion"];
                dr[2] = (System.Int32)datareader["CodComuna"];
                dr[3] = (System.String)datareader["nComuna"];
                dr[4] = (System.Int32)datareader["CodProvincia"];
                dr[5] = (System.String)datareader["nCodProvincia"];
                dr[6] = (System.Int32)datareader["CodProyecto"];
                dr[7] = (System.String)datareader["Nombre"];
                dr[8] = (System.String)datareader["Direccion"];
                dr[9] = (System.String)datareader["Telefono"];
                dr[10] = (System.String)datareader["Mail"];
                dr[11] = (System.String)datareader["Fax"];
                dr[12] = (System.String)datareader["Director"];
                dr[13] = (System.Int32)datareader["TipoProyecto"];
                dr[14] = (System.String)datareader["nTipoProyecto"];
                dr[15] = (System.Int32)datareader["TipoSubvencion"];
                dr[16] = (System.String)datareader["nTipoSubvencion"];
                dr[17] = (System.Int32)datareader["CodTematicaProyecto"];
                dr[18] = (System.String)datareader["nCodTematica"];
                dr[19] = (System.Int32)datareader["CodModeloIntervencion"];
                dr[20] = (System.String)datareader["nModelo"];
                dr[21] = (System.Int32)datareader["NumeroPlazas"];
                dr[22] = (System.String)datareader["Sexo"];
                dr[23] = (System.Int32)datareader["CodDiasAtencion"];
                dr[24] = (System.String)datareader["IndVigencia"];
                dr[25] = (System.DateTime)datareader["TerminoProyecto"];
                dr[26] = (System.DateTime)datareader["FechaInicio"];
                dr[27] = (System.DateTime)datareader["FechaTermino"];
                dr[28] = (System.String)datareader["NemoTecnico"];
                dr[29] = (System.Int32)datareader["CodDepartamentosSename"];
                dr[30] = (System.DateTime)datareader["FechaCreacion"];
                dr[31] = (System.String)datareader["Tematica"];
                dr[32] = (System.Int32)datareader["Peso"];
                dr[33] = (System.String)datareader["VigenciaTematica"];
                dr[34] = (System.DateTime)datareader["FechaConvenio"];
                dr[35] = (System.DateTime)datareader["FechaConvenio2"];
                dr[36] = (System.Int32)datareader["CodInstitucion"];
                dr[37] = (System.String)datareader["NombreInstitucion"];
                dr[38] = (System.Int32)datareader["CodSistemaAsistencial"];
                dr[39] = (System.String)datareader["NombreSistemaAsistencial"];
                dr[40] = (System.String)datareader["NombreDepartamentosSename"];
                dr[41] = (System.Int32)datareader["EdadMinima"];
                dr[42] = (System.Int32)datareader["EdadMaxima"];
                dr[43] = (System.Int32)datareader["FechaVigenciaMes"];
                dr[44] = (System.Int32)datareader["FechaVigenciaAgno"];
                dr[45] = (System.String)datareader["NomRegion"];
                dr[46] = (System.Int32)datareader["Monto"];
                dr[47] = (System.String)datareader["Criterio"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable GetparTipoDiagnosticoGlosaxRep()
    { 
         DbDataReader datareader = null;
         /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
         con.ejecutar(Resources.Procedures.GetparTipoDiagnosticoGlosaxRep, out datareader);
         DataTable dt = new DataTable();
         DataRow dr;
         dt.Columns.Add(new DataColumn("codtipodiagnosticoglosa", typeof(int)));
         dt.Columns.Add(new DataColumn("descripcion", typeof(String)));
         dt.Columns.Add(new DataColumn("reporte", typeof(int)));
         dt.Columns.Add(new DataColumn("indvigencia", typeof(String)));

         while (datareader.Read())
         {
             try
             {
                 dr = dt.NewRow();
                 dr[0] = (int)datareader["codtipodiagnosticoglosa"];
                 dr[1] = (String)datareader["descripcion"];
                 dt.Rows.Add(dr);
             }
             catch { }
         }
            con.Desconectar();
            return dt;
    }



    public DataTable Reporte_AsistenciaDiariaAADD(DateTime Consulta, int UserID)
    {

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@FechaAsistencia", SqlDbType.DateTime,8,Convert.ToDateTime(Consulta.ToShortDateString())),
                                   con.parametros("@UserID",SqlDbType.Int,4, UserID)};

        con.ejecutarProcedimiento("AsistenciaDiariaAADD_2", parametros, out datareader);

        DataTable dt = new DataTable();
        //dt.Columns.Add("FechaAsistencia", typeof(String));        //0 DateTime
        dt.Columns.Add("CodRegion", typeof(int));                    //1
        dt.Columns.Add("Proyecto", typeof(String));                 //2
        dt.Columns.Add("CodProyecto", typeof(int));                 //3 
        dt.Columns.Add("Presentes", typeof(int));                   //4
        dt.Columns.Add("Ausentes", typeof(String));                    //5
        dt.Columns.Add("Permisos", typeof(String));      //6    

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                //dr[0] = "";//(System.DateTime)datareader["FechaAsistencia"];
                //dr[0] = (System.DateTime)datareader["FechaAsistencia"];
                dr[0] = (System.Int32)datareader["CodRegion"];
                dr[1] = (System.String)datareader["Proyecto"];
                dr[2] = (System.Int32)datareader["CodProyecto"];
                dr[3] = (System.Int32)datareader["Presentes"];
                if (Convert.ToString((System.Int32)datareader["Ausentes"]) == "-2")
                {
                    dr[4] = "-";
                }
                else
                {
                    dr[4] = (System.Int32)datareader["Ausentes"];
                }

                if (Convert.ToString((System.Int32)datareader["Permisos"]) == "-2")
                {
                    dr[5] = "-";
                }
                else
                {
                    dr[5] = (System.Int32)datareader["Permisos"];
                }


                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }


    /// ////////

    public DataTable Reporte_Nomina_LPRA(int TipoListado, int CodProyecto, DateTime FechaIngreso, int AnoMes)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@TipoListado",SqlDbType.Int,4,TipoListado),
                                 con.parametros("@CodProyecto",SqlDbType.Int,4, CodProyecto),
                                 con.parametros("@FechaIngreso",SqlDbType.DateTime ,8, FechaIngreso),
                                 con.parametros("@AnoMes",SqlDbType.Int,4, AnoMes)};

        con.ejecutarProcedimiento("Get_Nomina_LPRA", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodProyecto", typeof(int));                    //0
        dt.Columns.Add("NombreProyecto", typeof(String));              //1
        dt.Columns.Add("CodRegion", typeof(int));                       //2
        dt.Columns.Add("Region", typeof(String));                      //3
        dt.Columns.Add("Nemotecnico", typeof(String));                  //4
        dt.Columns.Add("Medio", typeof(String));                       //5
        dt.Columns.Add("icodie", typeof(int));                         //6
        dt.Columns.Add("codnino", typeof(int));                         //7
        dt.Columns.Add("Nombres", typeof(String));                      //8
        dt.Columns.Add("Apellido_Paterno", typeof(String));             //9
        dt.Columns.Add("Apellido_Materno", typeof(String));             //10   
        dt.Columns.Add("rut", typeof(String));                          //11
        dt.Columns.Add("FechaNacimiento", typeof(String));              //12
        dt.Columns.Add("sexo", typeof(String));                         //13
        dt.Columns.Add("EdadAlIngreso", typeof(String));                //14
        dt.Columns.Add("RegionOrigen", typeof(String));                 //15
        dt.Columns.Add("FechaIngreso", typeof(String));                //16    
        dt.Columns.Add("codcalidadjuridica", typeof(int));              //17    
        dt.Columns.Add("CalidadJuridica", typeof(String));               //18
        dt.Columns.Add("TribunalOrden", typeof(String));                //19
        dt.Columns.Add("RegionTribunal", typeof(String));               //20
        dt.Columns.Add("RUC", typeof(String));                          //21
        dt.Columns.Add("RIT", typeof(String));                          //22
        dt.Columns.Add("CodTribunal", typeof(int));                     //23
        dt.Columns.Add("TribunalSeguimientoCausa", typeof(String));     //24
        dt.Columns.Add("FechaInicio", typeof(String));                  //25
        dt.Columns.Add("AnoDuracion", typeof(String));                  //26 
        dt.Columns.Add("MesDuracion", typeof(String));                  //27 
        dt.Columns.Add("DiaDuracion", typeof(String));                  //28 
        dt.Columns.Add("FechaTermino", typeof(String));                 //29 
        dt.Columns.Add("Abono", typeof(String));                        //30 
        dt.Columns.Add("Horas", typeof(String));                        //31 
        dt.Columns.Add("SancionAccesoria", typeof(String));             //32
        dt.Columns.Add("TipoSancionAccesoria", typeof(String));         //33
        dt.Columns.Add("escolaridadIngreso", typeof(String));           //34
        dt.Columns.Add("AnoEscolaridad", typeof(String));                  //35
        dt.Columns.Add("TipoAsistenciaEscolar", typeof(String));        //36
        dt.Columns.Add("FechaElaboracionPII", typeof(String));          //37    
        dt.Columns.Add("FechaEgreso", typeof(String));                 //38 
        dt.Columns.Add("CausalEgreso", typeof(String));                  //39
        dt.Columns.Add("Delito", typeof(String));                  //40
        dt.Columns.Add("CodigoDelito", typeof(int));                  //41
        dt.Columns.Add("MuestraADN", typeof(String));                  //42

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();


                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = (System.String)datareader["NombreProyecto"];
                dr[2] = (System.Int32)datareader["CodRegion"];
                dr[3] = (System.String)datareader["Region"];
                dr[4] = (System.String)datareader["Nemotecnico"];
                dr[5] = (System.String)datareader["Medio"];
                dr[6] = (System.Int32)datareader["icodie"];
                dr[7] = (System.Int32)datareader["codnino"];
                dr[8] = (System.String)datareader["Nombres"];
                dr[9] = (System.String)datareader["Apellido_Paterno"];
                dr[10] = (System.String)datareader["Apellido_Materno"];
                dr[11] = (System.String)datareader["rut"];
                dr[12] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString());
                dr[13] = (System.String)datareader["sexo"];
                dr[14] = (System.String)datareader["EdadAlIngreso"];
                dr[15] = (System.String)datareader["RegionOrigen"];
                dr[16] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaIngreso"]).ToShortDateString());
                dr[17] = (System.Int32)datareader["codcalidadjuridica"];
                dr[18] = (System.String)datareader["CalidadJuridica"];
                dr[19] = (System.String)datareader["TribunalOrden"];
                dr[20] = (System.String)datareader["RegionTribunal"];
                dr[21] = (System.String)datareader["RUC"];
                dr[22] = (System.String)datareader["RIT"];
                dr[23] = (System.Int32)datareader["CodTribunal"];
                if ((System.String)datareader["CausalEgreso"].ToString() == "-2")
                {
                    dr[24] = "-";
                }
                else
                {
                    dr[24] = (System.String)datareader["CausalEgreso"];
                }

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaInicio"]).ToShortDateString()) == "01/01/1900")
                {
                    dr[25] = "-";
                }
                else
                {
                    dr[25] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaInicio"]).ToShortDateString());
                }
                if (Convert.ToString((System.Int32)datareader["AnoDuracion"]) == "-2")
                {
                    dr[26] = "-";
                }
                else
                {
                    dr[26] = (System.Int32)datareader["AnoDuracion"];
                }

                if (Convert.ToString((System.Int32)datareader["MesDuracion"]) == "-2")
                {
                    dr[27] = "-";
                }
                else
                {
                    dr[27] = (System.Int32)datareader["MesDuracion"];
                }

                if (Convert.ToString((System.Int32)datareader["DiaDuracion"]) == "-2")
                {
                    dr[28] = "-";
                }
                else
                {
                    dr[28] = (System.Int32)datareader["DiaDuracion"];
                }

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaTermino"]).ToShortDateString()) == "01/01/1900")
                {
                    dr[29] = "-";
                }
                else
                {
                    dr[29] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaTermino"]).ToShortDateString());
                }

                if (Convert.ToString((System.Int32)datareader["Abono"]) == "-2")
                {
                    dr[30] = "-";
                }
                else
                {
                    dr[30] = (System.Int32)datareader["Abono"];
                }

                if (Convert.ToString((System.Int32)datareader["Horas"]) == "-2")
                {
                    dr[31] = "-";
                }
                else
                {
                    dr[31] = (System.Int32)datareader["Horas"];
                }


                if ((System.String)datareader["TipoSancionAccesoria"].ToString() == "-2")
                {
                    dr[32] = "-";
                }
                else
                {
                    dr[32] = (System.String)datareader["SancionAccesoria"];
                }
                if ((System.String)datareader["TipoSancionAccesoria"].ToString() == "-2")
                {
                    dr[33] = "-";
                }
                else
                {
                    dr[33] = (System.String)datareader["TipoSancionAccesoria"];
                }
                if ((System.String)datareader["escolaridadIngreso"].ToString() == "-2")
                {
                    dr[34] = "-";
                }
                else
                {
                    dr[34] = (System.String)datareader["escolaridadIngreso"];
                }
                if (Convert.ToString((System.Int32)datareader["AnoEscolaridad"]) == "-2")
                {
                    dr[35] = "-";
                }
                else
                {
                    dr[35] = (System.Int32)datareader["AnoEscolaridad"];
                }


                dr[36] = (System.String)datareader["TipoAsistenciaEscolar"];

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaElaboracionPII"]).ToShortDateString()) == "01/01/1900")
                {
                    dr[37] = "-";
                }
                else
                {
                    dr[37] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaElaboracionPII"]).ToShortDateString());
                }

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString()) == "01-01-1900" || Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString()) == "01/01/1900")
                {
                    dr[38] = "-";
                }
                else
                {
                    dr[38] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString());
                }


                dr[39] = (System.String)datareader["CausalEgreso"];
                dr[40] = (System.String)datareader["Delito"];
                dr[41] = (System.Int32)datareader["CodigoDelito"];
                dr[42] = (System.String)datareader["MuestraADN"];

                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }

    //Reporte_Nomina_LPRAII
    public DataTable Reporte_Nomina_LPRAII(int TipoListado, int CodProyecto, DateTime FechaIngreso, int AnoMes)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@TipoListado",SqlDbType.Int,4,TipoListado),
                                 con.parametros("@CodProyecto",SqlDbType.Int,4, CodProyecto),
                                 con.parametros("@FechaIngreso",SqlDbType.DateTime ,8, FechaIngreso),
                                 con.parametros("@AnoMes",SqlDbType.Int,4, AnoMes)};

        con.ejecutarProcedimiento("Get_Nomina_LPRA", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodProyecto", typeof(int));                    //0
        dt.Columns.Add("NombreProyecto", typeof(String));              //1
        dt.Columns.Add("CodRegion", typeof(int));                      //2
        dt.Columns.Add("Region", typeof(String));                      //3
        dt.Columns.Add("Nemotecnico", typeof(String));                 //4
        dt.Columns.Add("Medio", typeof(String));                       //5
        dt.Columns.Add("icodie", typeof(int));                         //6
        dt.Columns.Add("codnino", typeof(int));                        //7
        dt.Columns.Add("Nombres", typeof(String));                     //8
        dt.Columns.Add("Apellido_Paterno", typeof(String));            //9
        dt.Columns.Add("Apellido_Materno", typeof(String));            //10   
        dt.Columns.Add("rut", typeof(String));                         //11
        dt.Columns.Add("FechaNacimiento", typeof(String));             //12
        dt.Columns.Add("sexo", typeof(String));                        //13
        dt.Columns.Add("EdadAlIngreso", typeof(String));               //14
        dt.Columns.Add("RegionOrigen", typeof(String));                //15
        dt.Columns.Add("FechaIngreso", typeof(String));                //16    
        dt.Columns.Add("codcalidadjuridica", typeof(int));             //17    
        dt.Columns.Add("CalidadJuridica", typeof(String));             //18
        dt.Columns.Add("TribunalOrden", typeof(String));               //19
        dt.Columns.Add("RegionTribunal", typeof(String));              //20
        dt.Columns.Add("RUC", typeof(String));                         //21
        dt.Columns.Add("RIT", typeof(String));                         //22
        dt.Columns.Add("escolaridadIngreso", typeof(String));          //23
        dt.Columns.Add("AnoEscolaridad", typeof(String));              //24
        dt.Columns.Add("TipoAsistenciaEscolar", typeof(String));       //25
        dt.Columns.Add("FechaElaboracionPII", typeof(String));         //26    
        dt.Columns.Add("FechaEgreso", typeof(String));                 //27
        dt.Columns.Add("CausalEgreso", typeof(String));                //28
        dt.Columns.Add("Delito", typeof(String));                //29
        dt.Columns.Add("CodigoDelito", typeof(int));                //30

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();


                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = (System.String)datareader["NombreProyecto"];
                dr[2] = (System.Int32)datareader["CodRegion"];
                dr[3] = (System.String)datareader["Region"];
                dr[4] = (System.String)datareader["Nemotecnico"];
                dr[5] = (System.String)datareader["Medio"];
                dr[6] = (System.Int32)datareader["icodie"];
                dr[7] = (System.Int32)datareader["codnino"];
                dr[8] = (System.String)datareader["Nombres"];
                dr[9] = (System.String)datareader["Apellido_Paterno"];
                dr[10] = (System.String)datareader["Apellido_Materno"];
                dr[11] = (System.String)datareader["rut"];
                dr[12] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaNacimiento"]).ToShortDateString());
                dr[13] = (System.String)datareader["sexo"];
                dr[14] = (System.String)datareader["EdadAlIngreso"];
                dr[15] = (System.String)datareader["RegionOrigen"];
                dr[16] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaIngreso"]).ToShortDateString());
                dr[17] = (System.Int32)datareader["codcalidadjuridica"];
                dr[18] = (System.String)datareader["CalidadJuridica"];
                dr[19] = (System.String)datareader["TribunalOrden"];
                dr[20] = (System.String)datareader["RegionTribunal"];
                dr[21] = (System.String)datareader["RUC"];
                dr[22] = (System.String)datareader["RIT"];

                if ((System.String)datareader["escolaridadIngreso"].ToString() == "-2")
                {
                    dr[23] = "-";
                }
                else
                {
                    dr[23] = (System.String)datareader["escolaridadIngreso"];
                }
                if (Convert.ToString((System.Int32)datareader["AnoEscolaridad"]) == "-2")
                {
                    dr[24] = "-";
                }
                else
                {
                    dr[24] = (System.Int32)datareader["AnoEscolaridad"];
                }


                dr[25] = (System.String)datareader["TipoAsistenciaEscolar"];

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaElaboracionPII"]).ToShortDateString()) == "01/01/1900")
                {
                    dr[26] = "-";
                }
                else
                {
                    dr[26] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaElaboracionPII"]).ToShortDateString());
                }

                if (Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString()) == "01-01-1900" || Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString()) == "01/01/1900")
                {
                    dr[27] = "-";
                }
                else
                {
                    dr[27] = Convert.ToString(Convert.ToDateTime((System.DateTime)datareader["FechaEgreso"]).ToShortDateString());
                }


                dr[28] = (System.String)datareader["CausalEgreso"];
                dr[29] = (System.String)datareader["Delito"];
                dr[30] = (System.Int32)datareader["CodigoDelito"];


                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable Reporte_GetProyectosLPRA(int CodProyecto)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = { con.parametros("@CodProyecto",SqlDbType.Int,4,CodProyecto)};

        con.ejecutarProcedimiento("Get_ProyectosLRPA", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("LRPA", typeof(int));                                  //0
        dt.Columns.Add("CodCausalTerminoProyecto", typeof(int));              //1
      
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["LRPA"];
                dr[1] = (System.Int32)datareader["CodCausalTerminoProyecto"];
                

                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        return dt;
    }

    public DataTable callto_asistenciadiariaaadd_2(DateTime fecha, int idusuario)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "AsistenciaDiariaAADD_A";
        sqlc.Parameters.Add("@FechaVigente", SqlDbType.DateTime, 16).Value = fecha;
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = idusuario;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
}
