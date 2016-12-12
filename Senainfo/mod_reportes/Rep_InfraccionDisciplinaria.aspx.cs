using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class mod_reportes_Rep_InfraccionDisciplinaria : System.Web.UI.Page
{

    public string FechaConsulta
    {
        get { return (string)Session["FechaConsulta"]; }
        set { Session["FechaConsulta"] = value; }
    }

    public string CodInst
    {
        get { return (string)Session["CodInst"]; }
        set { Session["CodInst"] = value; }
    }

    public string CodProy
    {
        get { return (string)Session["CodProy"]; }
        set { Session["CodProy"] = value; }
    }
    public string NomProy
    {
        get { return (string)Session["NomProy"]; }
        set { Session["NomProy"] = value; }
    }
    public DataTable DTAno
    {
        get { return (DataTable)Session["DTAno"]; }
        set { Session["DTAno"] = value; }
    }
    public DataTable dtReporte
    {
        get { return (DataTable)Session["dtReporte"]; }
        set { Session["dtReporte"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            txtFecha.Visible = false;
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
   
                lblmes.Visible = false;
                lblano.Visible = false;
                ddown004.Visible = false;
                wne001.Visible = false;
                
                //cal001.Visible = true;
                //txtFecha.Visible = true;
                //ImbCalFecha.Visible = true;

                getinstituciones();

                wne001.Items.Clear();

                ListItem oItem = new ListItem("Seleccionar", "0");
                wne001.Items.Add(oItem);
                int iAno;

                for (int i = 0; i <= (System.DateTime.Now.Year - 2007); i++)
                {
                    iAno = 2007 + i;
                    oItem = new ListItem(iAno.ToString(), iAno.ToString());
                    wne001.Items.Add(oItem);
                }


                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    //GetProyectos();
                    //ddown002.SelectedValue = Request.QueryString["codinst"];
                    txt001.Text = Request.QueryString["codinst"];

                }
            }
        }
    }
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown003.SelectedValue == "0")
        {
            lblaviso.Text = "Ingrese un Tipo de Listado";
            lblaviso.Visible = true;
        }
        else if (ddown003.SelectedValue == "1" || ddown003.SelectedValue == "2" || ddown003.SelectedValue == "4")
        {


            ddown004.Visible = true;
            wne001.Visible = true;
            lblano.Visible = true;
            lblmes.Visible = true;
            
            //cal001.Visible = false;
            txtFecha.Visible = false;
            //ImbCalFecha.Visible = false;
            
            lblaviso.Visible = false;
            alerts.Visible = false;

        }
        else
        {
            ddown004.Visible = false;
            wne001.Visible = false;
            lblano.Visible = false;
            lblmes.Visible = false;
            
            //cal001.Visible = true;
            txtFecha.Visible = true;
            txtFecha.Enabled = true;
            //ImbCalFecha.Visible = true;

            lblaviso.Visible = false;
            alerts.Visible = false;

        }

        

    }
    protected void wne001_ValueChange(object sender, EventArgs e)
    {
        if (Convert.ToInt32(wne001.Text) < 2.007)
        {
            wne001.SelectedValue = "0";
            lblaviso.Text = "Ingrese un Año Mayor a 2007";
            lblaviso.Visible = true;
        }
        else
        {
            alerts.Visible = false;
            lblaviso.Text = "";
            lblaviso.Visible = false;
        }
    }
    protected void imb_003_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
    }
    protected void imb_002_Click(object sender, EventArgs e)
    {
        Limpiaformulario();
    }
    private void Limpiaformulario()
    {
        alerts.Visible = false;
        lblError.Visible = false;
        lblmes.Visible = false;
        lblano.Visible = false;
        ddown001.SelectedValue = "0";
        ddown003.SelectedValue = "0";
        ddown004.SelectedValue = "0";
        wne001.SelectedValue = "0";
        txt001.Text = "";
        ddown004.Visible = true;
        
        //cal001.Visible = false;
        txtFecha.Visible = false;
        //ImbCalFecha.Visible = false;
        txtFecha.Visible = false;
        ddown004.Visible = false;
        wne001.Visible = false;
        
        lbl_periodo.Visible = true;

        lblaviso.Visible = false;

        txt001.BackColor = System.Drawing.Color.White;
        ddown003.BackColor = System.Drawing.Color.White;
        ddown004.BackColor = System.Drawing.Color.White;
        wne001.BackColor = System.Drawing.Color.White;
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Get_Nomina_LPRA

        ReporteNinoColl rpn = new ReporteNinoColl();
       
        //DateTime fecha = Convert.ToDateTime(cal001.Value);
        DateTime fecha = Convert.ToDateTime(txtFecha.Text);

        String MesAno = "0";
        if (Convert.ToInt32(Convert.ToString(fecha.Month).Length) < 10)
        {
            MesAno = Convert.ToString(fecha.Year) + "0" + Convert.ToString(fecha.Month);
        }
        else
        {
            MesAno = Convert.ToString(fecha.Year) + Convert.ToString(fecha.Month);
        }
        string CodProyecto = txt001.Text.Substring(1, 7);
        //DataTable dt = rpn.Reporte_Nomina_LPRA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto), Convert.ToDateTime(cal001.Value), Convert.ToInt32(MesAno) );
        DataTable dt = rpn.Reporte_Nomina_LPRA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto), Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(MesAno) );
        if (dt.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=NOMINA_LRPA.xls");

            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


            dt.Columns[0].ColumnName = "CodProyecto";
            dt.Columns[1].ColumnName = "NombreProyecto";
            dt.Columns[2].ColumnName = "CodRegion";
            dt.Columns[3].ColumnName = "Region";
            dt.Columns[4].ColumnName = "Medio";
            dt.Columns[5].ColumnName = "icodie";
            dt.Columns[6].ColumnName = "FechaIngreso";
            dt.Columns[7].ColumnName = "FechaEgreso";
            dt.Columns[8].ColumnName = "Nombres";
            dt.Columns[9].ColumnName = "Apellido_Materno";
            dt.Columns[10].ColumnName = "Apellido_Paterno";
            dt.Columns[11].ColumnName = "rut";
            dt.Columns[12].ColumnName = "FechaNacimineto";
            dt.Columns[13].ColumnName = "sexo";
            dt.Columns[14].ColumnName = "EdadAlIngreso";
            dt.Columns[15].ColumnName = "RegionOrigen";
            dt.Columns[16].ColumnName = "CausalEgreso";
            dt.Columns[17].ColumnName = "RegionTribunal";
            dt.Columns[18].ColumnName = "RUC";
            dt.Columns[19].ColumnName = "RIT";
            dt.Columns[20].ColumnName = "FechaInicio";
            dt.Columns[21].ColumnName = "AnoDuracion";
            dt.Columns[22].ColumnName = "MesDuracion";
            dt.Columns[23].ColumnName = "DiaDuracion";
            dt.Columns[24].ColumnName = "FechaTermino";
            dt.Columns[25].ColumnName = "Abono";
            dt.Columns[26].ColumnName = "Horas";
            dt.Columns[27].ColumnName = "SancionAccesoria";
            dt.Columns[28].ColumnName = "escolaridadIngreso";
            dt.Columns[29].ColumnName = "anoescolar";
            dt.Columns[30].ColumnName = "FechaElaboracionPII";
            dt.Columns[31].ColumnName = "codmodelointervencion";
            dt.Columns[32].ColumnName = "ModeloIntervencion";
            dt.Columns[33].ColumnName = "Nemotecnico";


            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();
        }
        else
        {
            alerts.Visible = true;
            lblError.Visible = true;
            lblError.Text = "NO SE ENCONTRARON COINCIDENCIAS";
        }
    }
    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"]) ));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();

    }
    private void getproyecto()
    {

        proyectocoll pcoll = new proyectocoll();
        LRPAcoll lrpac = new LRPAcoll();

        DataTable dtproy = lrpac.callto_get_ProyectosLRPAxCodProyecto(Convert.ToInt32(ddown001.SelectedValue) );


    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyecto();
    }

    private bool validacion()
    {
        bool sw = true;

        if (txt001.Text.Trim() == "")
        {
            txt001.BackColor = System.Drawing.Color.Pink;
            sw = false;
        }
        else
        {
            txt001.BackColor = System.Drawing.Color.White;
        }

        if (ddown003.SelectedValue != "0") 
        {
            
                {
                    ddown003.BackColor = System.Drawing.Color.White;
                }
         }
        else
             if  (RadioButtonList2.SelectedValue == "1")
            {
                sw = true;
            }
             else
                {
                    ddown003.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
        if (ddown003.SelectedValue == "3")
        {
            if ( txtFecha.Text == "")
            {
                //cal001.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
            {
                //cal001.BackColor = System.Drawing.Color.White;
                //FechaConsulta = cal001.Text;
                FechaConsulta = txtFecha.Text;
                //sw = true;        
            }
        }
        else
        {
            if ((ddown004.SelectedValue == "0" || wne001.SelectedValue == "0" ) && (RadioButtonList2.SelectedValue == "0"))
            {
                if (ddown004.SelectedValue == "0")
                {
                    ddown004.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                if (wne001.SelectedValue == "0")
                {
                    wne001.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
            }
            

            else
            {
                ddown004.BackColor = System.Drawing.Color.White;
                wne001.BackColor = System.Drawing.Color.White;
                sw = true;
                FechaConsulta = "01-01-1900";
            }
            if (Convert.ToInt32(ddown004.SelectedValue) < 9 && RadioButtonList2.SelectedValue == "0")
            {
                FechaConsulta = Convert.ToString("01-" + "0" + ddown004.SelectedValue + "-" + wne001.SelectedValue);
            }
            else
                if (RadioButtonList2.SelectedValue == "0")
                {
                    FechaConsulta = Convert.ToString("01-" + ddown004.SelectedValue + "-" + wne001.SelectedValue);
                }
                else
                {
                    //FechaConsulta = cal001.Text;
                    FechaConsulta = txtFecha.Text;
                }

        }
        return (sw);

    }

    protected DataTable getReporteNominaInfraccionLRPA(int TipoListado, int CodProyecto, DateTime FechaIngreso, int AnoMes)
    {
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand("Get_Nomina_LPRA_InfracionesDisciplinarias", sqlc);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.Add("@TipoListado" , SqlDbType.Int).Value = TipoListado;
        cmd.Parameters.Add("@CodProyecto" , SqlDbType.Int).Value = CodProyecto;
        cmd.Parameters.Add("@FechaIngreso" , SqlDbType.DateTime).Value = FechaIngreso;
        cmd.Parameters.Add("@AnoMes" , SqlDbType.Int).Value = AnoMes;

        SqlDataAdapter sqlda = new SqlDataAdapter(cmd);

        cmd.Connection.Open();

        sqlda.Fill(dt);

        cmd.Connection.Close();


        //foreach (DataRow dr in dt.Rows)
        //{
        //    if (dr["FechaIngreso"].ToString().Substring(0,10) == "02-07-2013")
        //    {
        //        dr["FechaIngreso"] = default(DateTime);
        //    }

        //}
        

        return dt;
    }

    protected void imb001_Click(object sender, EventArgs e)
    {
        bool sw = validacion();


        if (sw == true)
        {
            lblaviso.Visible = false;
            alerts.Visible = false;
            ReporteNinoColl rpn = new ReporteNinoColl();

            //FechaConsulta = cal001.Text;
            FechaConsulta = txtFecha.Text;
            String MesAno = "0";
            if (Convert.ToDateTime(FechaConsulta).Month < 9)
            {
                MesAno = Convert.ToString(Convert.ToDateTime(FechaConsulta).Year) + "0" + Convert.ToString(Convert.ToDateTime(FechaConsulta).Month);
            }
            else
            {
                MesAno = Convert.ToString(Convert.ToDateTime(FechaConsulta).Year) + Convert.ToString(Convert.ToDateTime(FechaConsulta).Month);
            }

            if (RadioButtonList2.SelectedValue == "0")
            {
            //String CodProyecto2 = txt001.Text.Substring(1, 7);
            String CodProyecto2 = txt001.Text;
            DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(CodProyecto2) );
            if (dt0.Rows[0][0].ToString() == "1")
            {
                //Get_Nomina_LRPA
                DataTable dt = getReporteNominaInfraccionLRPA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()));
                //DataTable dt = rpn.Reporte_Nomina_InfraccionLPRA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()));


                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_" + ddown003.SelectedItem.Text + ".xls");

                        this.EnableViewState = false;

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


                        #region Comentado
                        //dt.Columns[0].ColumnName = "CodProyecto";                    //0
                        //dt.Columns[1].ColumnName = "Nombre";              //1
                        //dt.Columns[2].ColumnName = "CodModeloIntervencion";                       //2
                        //dt.Columns[3].ColumnName = "ModeloIntervencion";                      //3
                        //dt.Columns[4].ColumnName = "Nemotecnico";                  //4
                        //dt.Columns[5].ColumnName = "ICodIE";                       //5
                        //dt.Columns[6].ColumnName = "CodNino";                         //6
                        //dt.Columns[7].ColumnName = "FechaIngreso";                         //7
                        //dt.Columns[8].ColumnName = "FechaEgreso";                      //8
                        //dt.Columns[9].ColumnName = "Nombres";             //9
                        //dt.Columns[10].ColumnName = "Apellido_Paterno";             //10   
                        //dt.Columns[11].ColumnName = "Apellido_Materno";                          //11
                        //dt.Columns[12].ColumnName = "FechaNacimiento";              //12
                        //dt.Columns[13].ColumnName = "Rut";                         //13
                        //dt.Columns[14].ColumnName = "Sexo";                //14
                        //dt.Columns[15].ColumnName = "FechaEventoFalta";                 //15
                        //dt.Columns[16].ColumnName = "PresentaDenunciaFalta_Afirmacion";                //16    
                        //dt.Columns[17].ColumnName = "PresentaDenuncia";              //17    
                        //dt.Columns[18].ColumnName = "AmeritaFalta_Afirmacion";               //18
                        //dt.Columns[19].ColumnName = "AmeritaInfraccionDisciplinaria";                //19
                        //dt.Columns[20].ColumnName = "DescripcionEvento";               //20
                        //dt.Columns[21].ColumnName = "N°Acta";                          //21
                        //dt.Columns[22].ColumnName = "FechaSesion";                          //22
                        //dt.Columns[23].ColumnName = "AplicaSancionCD_Afirmacion";                     //23
                        //dt.Columns[24].ColumnName = "SeAplicaSancion";     //24
                        //dt.Columns[25].ColumnName = "CodTipoFaltaCF";                  //25
                        //dt.Columns[26].ColumnName = "TipoInfraccionDisciplinaria";                  //26 
                        //dt.Columns[27].ColumnName = "InfraccionDisciplinaria1";                  //27 
                        //dt.Columns[28].ColumnName = "CodFalta1CF";                  //28 
                        //dt.Columns[29].ColumnName = "InfraccionDisciplinaria2";                 //29 
                        //dt.Columns[30].ColumnName = "CodFalta2CF";                        //30 
                        //dt.Columns[31].ColumnName = "InfraccionDisciplinaria3";                        //31 
                        //dt.Columns[32].ColumnName = "CodFalta3CF";             //32
                        //dt.Columns[33].ColumnName = "InfraccionDisciplinaria4";         //33
                        //dt.Columns[34].ColumnName = "CodFalta4CF";           //34
                        //dt.Columns[35].ColumnName = "Sancion1";                  //35
                        //dt.Columns[36].ColumnName = "CodSancionFalta1CF";        //36
                        //dt.Columns[37].ColumnName = "Sancion2";          //37    
                        //dt.Columns[38].ColumnName = "CodSancionFalta2CF";                 //38 
                        //dt.Columns[39].ColumnName = "Sancion3";                  //39
                        //dt.Columns[40].ColumnName = "CodSancionFalta3CF";                  //40
                        //dt.Columns[41].ColumnName = "Sancion4";                  //41
                        //dt.Columns[42].ColumnName = "CodSancionFalta4CF";                  //42
                        //dt.Columns[43].ColumnName = "NdeDias";     //24
                        //dt.Columns[44].ColumnName = "CodDiasDS";                  //25
                        //dt.Columns[45].ColumnName = "NdeSemanas";                  //26 
                        //dt.Columns[46].ColumnName = "CodSemanaDS";                  //27 
                        //dt.Columns[47].ColumnName = "NdeMeses";                  //28 
                        //dt.Columns[48].ColumnName = "CodMesDS";                //29 
                        //dt.Columns[49].ColumnName = "RatificacionDirector-a";                        //30 
                        //dt.Columns[50].ColumnName = "RatificaDirectorDS_Afirmacion";                        //31 
                        //dt.Columns[51].ColumnName = "MediodDeNotificacionAlTribunal";             //32
                        //dt.Columns[52].ColumnName = "CodMedioNotificacionTribunalFRS";         //33
                        //dt.Columns[53].ColumnName = "NotificacionTribunal";           //34
                        //dt.Columns[54].ColumnName = "NotificacionTribunalFRS_Afirmacion";                  //35
                        //dt.Columns[55].ColumnName = "NotificacionJoven";        //36
                        //dt.Columns[56].ColumnName = "CodNotificacionJovenFRS";          //37    
                        //dt.Columns[57].ColumnName = "RegistroExpediente";                 //38 
                        //dt.Columns[58].ColumnName = "RegistroExpedienteFRS_Afirmacion";                  //39
                        //dt.Columns[59].ColumnName = "ConsideraReporteJoven";                  //40
                        //dt.Columns[60].ColumnName = "ConsideraReporteJovenEDP_Afirmacion";                  //41
                        //dt.Columns[61].ColumnName = "RevisionCircunstanciasResponsabilidad";                  //42
                        //dt.Columns[62].ColumnName = "RevisionCircunstanciasEDP_Afirmacion";     //24
                        //dt.Columns[63].ColumnName = "GestionComprobacionHecho";                  //25
                        //dt.Columns[64].ColumnName = "GestionesComprobacionEDP_Afirmacion";                  //26 
                        //dt.Columns[65].ColumnName = "QuienApela";                  //27 
                        //dt.Columns[66].ColumnName = "CodQuienApelaRRS";                  //28 
                        //dt.Columns[67].ColumnName = "SeAcogeApelacion";                 //29 
                        //dt.Columns[68].ColumnName = "CodSeAcogeApelacionRRS";                        //30 
                        //dt.Columns[69].ColumnName = "SeAplicaSeparacion";                        //31 
                        //dt.Columns[70].ColumnName = "SeAplicaSeparacionPS_Afirmacion";             //32
                        //dt.Columns[71].ColumnName = "Duracion";         //33
                        //dt.Columns[72].ColumnName = "CodDuracionSeparacionPS";           //34
                        //dt.Columns[73].ColumnName = "EspacioDeSeparacion";                  //35
                        //dt.Columns[74].ColumnName = "CodEspacioSeparacionPS";        //36
                        //dt.Columns[75].ColumnName = "SeAplicaIntervencion";          //37    
                        //dt.Columns[76].ColumnName = "CodAplicacionIntervencionISRN";                 //38 
                        //dt.Columns[77].ColumnName = "DescripcionIntervencionSocioeducativa";                  //39
                        //dt.Columns[78].ColumnName = "RefuerzoNegativo";                  //40
                        //dt.Columns[79].ColumnName = "CodRefuerzoNegativoAdicionalISRN";                  //41
                        //dt.Columns[80].ColumnName = "OtroRefuerzoNegativo";                  //42
                        //dt.Columns[81].ColumnName = "Constituye";                  //39
                        //dt.Columns[82].ColumnName = "ConstituyeCC_Afirmacion";                  //40
                        //dt.Columns[83].ColumnName = "ProcedimientoGenchi";                  //41
                        //dt.Columns[84].ColumnName = "CodConflictoCriticoCC";                  //42

                        //DataView dv = new DataView(dt);

                        #endregion
                        
                        GridView grd001 = new GridView();

                        grd001.DataSource = dt;
                        
                        grd001.DataBind();

                        foreach (GridViewRow grow in grd001.Rows)
                        {
                            //Fecha Ingreso
                            if (grow.Cells[7].Text == "01-01-1900 0:00:00")
                            {
                                grow.Cells[7].Text = "";
                            }

                            //Fecha Egreso
                            if (grow.Cells[8].Text == "01-01-1900 0:00:00")
                            {
                                grow.Cells[8].Text = "";
                            }

                            //Fecha Nacimiento
                            if (grow.Cells[12].Text == "01-01-1900 0:00:00")
                            {
                                grow.Cells[12].Text = "";
                            }

                            //Fecha Evento Falta
                            if (grow.Cells[15].Text == "01-01-1900 0:00:00")
                            {
                                grow.Cells[15].Text = "";
                            }

                            //Fecha Sesion
                            if (grow.Cells[22].Text == "01-01-1900 0:00:00")
                            {
                                grow.Cells[22].Text = "";
                            }
                        }

                        grd001.RenderControl(hw);

                        Response.ContentEncoding = System.Text.Encoding.Default;
                        Response.Write(tw.ToString());
                        Response.End();
                    }
                    catch (Exception ex)
                    {
                        lblError.Visible = true;
                        lblError.Text = "Se produjo un error inesperado" + " " + ex.Message;
                        alerts.Visible = true;
                    }
                }
                else
                {
                    alerts.Visible = true;
                    lblError.Visible = true;
                    lblError.Text = "NO SE ENCONTRARON COINCIDENCIAS";
                }
            }
            else if (dt0.Rows[0][0].ToString() == "2")
            {
                //Get_Nomina_LRPA_II
                DataTable dt = rpn.Reporte_Nomina_LPRAII(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()));

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_LRPA.xls");

                this.EnableViewState = false;

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                dt.Columns[0].ColumnName = "CodProyecto";                    //0
                dt.Columns[1].ColumnName = "Nombre";              //1
                dt.Columns[2].ColumnName = "CodModeloIntervencion";                       //2
                dt.Columns[3].ColumnName = "ModeloIntervencion";                      //3
                dt.Columns[4].ColumnName = "Nemotecnico";                  //4
                dt.Columns[5].ColumnName = "ICodIE";                       //5
                dt.Columns[6].ColumnName = "CodNino";                         //6
                dt.Columns[7].ColumnName = "FechaIngreso";                         //7
                dt.Columns[8].ColumnName = "FechaEgreso";                      //8
                dt.Columns[9].ColumnName = "Nombres";             //9
                dt.Columns[10].ColumnName = "Apellido_Paterno";             //10   
                dt.Columns[11].ColumnName = "Apellido_Materno";                          //11
                dt.Columns[12].ColumnName = "FechaNacimiento";              //12
                dt.Columns[13].ColumnName = "Rut";                         //13
                dt.Columns[14].ColumnName = "Sexo";                //14
                dt.Columns[15].ColumnName = "FechaEventoFalta";                 //15
                dt.Columns[16].ColumnName = "PresentaDenunciaFalta_Afirmacion";                //16    
                dt.Columns[17].ColumnName = "PresentaDenuncia";              //17    
                dt.Columns[18].ColumnName = "AmeritaFalta_Afirmacion";               //18
                dt.Columns[19].ColumnName = "AmeritaInfraccionDisciplinaria";                //19
                dt.Columns[20].ColumnName = "DescripcionEvento";               //20
                dt.Columns[21].ColumnName = "N°Acta";                          //21
                dt.Columns[22].ColumnName = "FechaSesion";                          //22
                dt.Columns[23].ColumnName = "AplicaSancionCD_Afirmacion";                     //23
                dt.Columns[24].ColumnName = "SeAplicaSancion";     //24
                dt.Columns[25].ColumnName = "CodTipoFaltaCF";                  //25
                dt.Columns[26].ColumnName = "TipoInfraccionDisciplinaria";                  //26 
                dt.Columns[27].ColumnName = "InfraccionDisciplinaria1";                  //27 
                dt.Columns[28].ColumnName = "CodFalta1CF";                  //28 
                dt.Columns[29].ColumnName = "InfraccionDisciplinaria2";                 //29 
                dt.Columns[30].ColumnName = "CodFalta2CF";                        //30 
                dt.Columns[31].ColumnName = "InfraccionDisciplinaria3";                        //31 
                dt.Columns[32].ColumnName = "CodFalta3CF";             //32
                dt.Columns[33].ColumnName = "InfraccionDisciplinaria4";         //33
                dt.Columns[34].ColumnName = "CodFalta4CF";           //34
                dt.Columns[35].ColumnName = "Sancion1";                  //35
                dt.Columns[36].ColumnName = "CodSancionFalta1CF";        //36
                dt.Columns[37].ColumnName = "Sancion2";          //37    
                dt.Columns[38].ColumnName = "CodSancionFalta2CF";                 //38 
                dt.Columns[39].ColumnName = "Sancion3";                  //39
                dt.Columns[40].ColumnName = "CodSancionFalta3CF";                  //40
                dt.Columns[41].ColumnName = "Sancion4";                  //41
                dt.Columns[42].ColumnName = "CodSancionFalta4CF";                  //42
                dt.Columns[43].ColumnName = "NdeDias";     //24
                dt.Columns[44].ColumnName = "CodDiasDS";                  //25
                dt.Columns[45].ColumnName = "NdeSemanas";                  //26 
                dt.Columns[46].ColumnName = "CodSemanaDS";                  //27 
                dt.Columns[47].ColumnName = "NdeMeses";                  //28 
                dt.Columns[48].ColumnName = "CodMesDS";                //29 
                dt.Columns[49].ColumnName = "RatificacionDirector-a";                        //30 
                dt.Columns[50].ColumnName = "RatificaDirectorDS_Afirmacion";                        //31 
                dt.Columns[51].ColumnName = "MediodDeNotificacionAlTribunal";             //32
                dt.Columns[52].ColumnName = "CodMedioNotificacionTribunalFRS";         //33
                dt.Columns[53].ColumnName = "NotificacionTribunal";           //34
                dt.Columns[54].ColumnName = "NotificacionTribunalFRS_Afirmacion";                  //35
                dt.Columns[55].ColumnName = "NotificacionJoven";        //36
                dt.Columns[56].ColumnName = "CodNotificacionJovenFRS";          //37    
                dt.Columns[57].ColumnName = "RegistroExpediente";                 //38 
                dt.Columns[58].ColumnName = "RegistroExpedienteFRS_Afirmacion";                  //39
                dt.Columns[59].ColumnName = "ConsideraReporteJoven";                  //40
                dt.Columns[60].ColumnName = "ConsideraReporteJovenEDP_Afirmacion";                  //41
                dt.Columns[61].ColumnName = "RevisionCircunstanciasResponsabilidad";                  //42
                dt.Columns[62].ColumnName = "RevisionCircunstanciasEDP_Afirmacion";     //24
                dt.Columns[63].ColumnName = "GestionComprobacionHecho";                  //25
                dt.Columns[64].ColumnName = "GestionesComprobacionEDP_Afirmacion";                  //26 
                dt.Columns[65].ColumnName = "QuienApela";                  //27 
                dt.Columns[66].ColumnName = "CodQuienApelaRRS";                  //28 
                dt.Columns[67].ColumnName = "SeAcogeApelacion";                 //29 
                dt.Columns[68].ColumnName = "CodSeAcogeApelacionRRS";                        //30 
                dt.Columns[69].ColumnName = "SeAplicaSeparacion";                        //31 
                dt.Columns[70].ColumnName = "SeAplicaSeparacionPS_Afirmacion";             //32
                dt.Columns[71].ColumnName = "Duracion";         //33
                dt.Columns[72].ColumnName = "CodDuracionSeparacionPS";           //34
                dt.Columns[73].ColumnName = "EspacioDeSeparacion";                  //35
                dt.Columns[74].ColumnName = "CodEspacioSeparacionPS";        //36
                dt.Columns[75].ColumnName = "SeAplicaIntervencion";          //37    
                dt.Columns[76].ColumnName = "CodAplicacionIntervencionISRN";                 //38 
                dt.Columns[77].ColumnName = "DescripcionIntervencionSocioeducativa";                  //39
                dt.Columns[78].ColumnName = "RefuerzoNegativo";                  //40
                dt.Columns[79].ColumnName = "CodRefuerzoNegativoAdicionalISRN";                  //41
                dt.Columns[80].ColumnName = "OtroRefuerzoNegativo";                  //42
                dt.Columns[81].ColumnName = "Constituye";                  //39
                dt.Columns[82].ColumnName = "ConstituyeCC_Afirmacion";                  //40
                dt.Columns[83].ColumnName = "ProcedimientoGenchi";                  //41
                dt.Columns[84].ColumnName = "CodConflictoCriticoCC";                  //42

                DataView dv = new DataView(dt);

                GridView grd001 = new GridView();
                grd001.DataSource = dv;
                grd001.DataBind();
                grd001.RenderControl(hw);

                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(tw.ToString());
                Response.End();

            }
        //else
          //      {
            //        dtReporte = rpn.Reporte_Nomina_InfraccionLPRA_Fecha(Convert.ToInt32(CodProyecto2), Convert.ToInt32(MesAno.Trim()) );
            //        ReportePII_Excel();
           //     }
            }
            // aca
            else
                {
               // String CodProyecto2 = txt001.Text.Substring(1, 7);
                    String CodProyecto2 = txt001.Text;
                dtReporte = rpn.Reporte_Nomina_InfraccionLPRA_Fecha(Convert.ToInt32(CodProyecto2), Convert.ToInt32(MesAno.Trim()) );
                ReportePII_Excel();
                }
        }
        else
        {
            alerts.Visible = true;
            lblaviso.Text = "Debe Ingresar los datos requeridos";
            lblaviso.Visible = true;
        }
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        window.open(this.Page, "../mod_reportes/busca_proyectosNuevaLeyRep.aspx", "Buscador", false, false, 750, 300, false, false, true);
    }
    protected void btnproy_Click(object sender, EventArgs e)
    {
        txt001.Text = "(" + CodProy + ") " + Server.HtmlDecode(NomProy);

        ddown001.SelectedValue = CodInst;
        ddown001.Enabled = false;
    }
    private void ReportePII_Excel()
    {
        if (dtReporte.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=AreasIntervencion.xls");
            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataView dv = new DataView(dtReporte);

            GridView grd002 = new GridView();
            grd002.DataSource = dv;
            grd002.DataBind();
            grd002.RenderControl(hw);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();

        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
            {
                txtFecha.Visible = true;
                ddown003.Enabled = false;
                ddown004.Visible = true;
                wne001.Visible = true;
                lblmes.Visible = true;
                lblano.Visible = true;
                lbl_periodo.Visible = true;
            }
        else
            {
                ddown003.Enabled =true;
            }
    }

    /*-----------------------------------------------------------------------------------------
    // 26/12/2014
    // Se agregan las siguientes VOID que reemplazarán a los originales que se encuentran 
    // asociados a Infragistics.
    // Se usa el mismo nombre de las VOID originales y se agrega el sufijo "NEW"
    // para su diferenciación.
    //-----------------------------------------------------------------------------------------*/
    protected void btnLimpiar_NEW_Click(object sender, EventArgs e)
    {
        Limpiaformulario();
    }
    protected void btnVolver_NEW_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
    }
    //protected void ImbCalFecha_Click(object sender, ImageClickEventArgs e)
    //{
    //    CalFecha.Visible = !(CalFecha.Visible);
    //}
    //protected void CalFecha_SelectionChanged(object sender, EventArgs e)
    //{
    //    txtFecha.Text = CalFecha.SelectedDate.ToString();
    //    txtFecha.Text = txtFecha.Text.Substring(0, 10);
    //    CalFecha.Visible = false;
    //}
    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFecha.Text = ddown004.SelectedValue.ToString() + "/" + wne001.SelectedValue.ToString();
        txtFecha.Visible = false;
    }
    protected void wne001_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFecha.Text = ddown004.SelectedValue.ToString() + "/" + wne001.SelectedValue.ToString();
        txtFecha.Visible = false;
    }


    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
}
