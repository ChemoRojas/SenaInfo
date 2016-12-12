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
using System.Text.RegularExpressions;

public partial class mod_ninos_DiagnosticoSalud_FichaSaludPosterior : System.Web.UI.Page
{
    public int CodFichaSaludInicial
    {
        get
        {
            if (ViewState["CodFichaSaludInicial"] == null)
            { ViewState["CodFichaSaludInicial"] = -1; }
            return Convert.ToInt32(ViewState["CodFichaSaludInicial"]);
        }
        set { ViewState["CodFichaSaludInicial"] = value; }
    }

    public int CodFichaSaludPosterior
    {
        get
        {
            if (ViewState["CodFichaSaludPosterior"] == null)
            { ViewState["CodFichaSaludPosterior"] = -1; }
            return Convert.ToInt32(ViewState["CodFichaSaludPosterior"]);
        }
        set { ViewState["CodFichaSaludPosterior"] = value; }
    }

    public int CodDiagnostico
    {
        get
        {
            if (ViewState["CodDiagnostico"] == null)
            { ViewState["CodDiagnostico"] = -1; }
            return Convert.ToInt32(ViewState["CodDiagnostico"]);
        }
        set { ViewState["CodDiagnostico"] = value; }
    }
    
    public enum querytype
    {        
        PA,
        Pulso,
        FR,
        T,
        FichaSaludInicial
    }

    public nino SSninoDiag
    {
        get
        {
            if (Session["neo_SSninoDiag"] == null)
            { Session["neo_SSninoDiag"] = new nino(); }
            return (nino)Session["neo_SSninoDiag"];
        }
        set { Session["neo_SSninoDiag"] = value; }
    }

    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set { Session["neo_SSnino"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", " if ($('#txtDiagnosticoMedicoIngreso').length > 0) {max(txtDiagnosticoMedicoIngreso); }", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", " if ($('#txtMotivoConsulta').length > 0) { max(txtMotivoConsulta);}", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", " if ($('#txtExamenFisico').length > 0) { max(txtExamenFisico);}", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", " if ($('#txtDiagnosticoEgreso').length > 0) { max(txtDiagnosticoEgreso);}", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", " if ($('#txtTratamiento').length > 0) { max(txtTratamiento);}", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", " if ($('#txtDerivacion').length > 0) { max(txtDerivacion);}", true);
        RangeValidator1.Validate();


        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "RedirectScript", "window.parent.location = '~/logout.aspx'", true);
            //Response.Write("<script language='javascript'>parent.location.reload();</script>"); // carga la pagina padre para que verifique el padre si perdio la sesión y no el hijo 
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RedirectScript", "parent.location.reload();", true);
            //Response.Redirect("~/logout.aspx");

        }
        else
        {
            if (!IsPostBack)
            {
                GetData();
                ObtenerFichaSaludPosterior();

                //if (window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                //{
                //    btnGatillo.Visible = true;
                //}
            }

            if (ViewState["FechaFinalSeteadaDiagPost"] != null)
            {
                if (ViewState["FechaFinalSeteadaDiagPost"].ToString() != "")
                {
                    String FechaFinalSeteadaDiagPost = ViewState["FechaFinalSeteadaDiagPost"].ToString();
                    tdHorasRestantes.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('" + FechaFinalSeteadaDiagPost + "', 'countdownDiagPosterior');", true);
                }
            }
        }
        
    }

    private void ObtenerFichaSaludPosterior()
    {
        
        CodDiagnostico = GetCodDiagnostico();
        CodFichaSaludInicial = GetCodDiagnosticoSaludFichaInicial(CodDiagnostico);

        if (CodFichaSaludInicial > 0)
        {
            divAlertaSinDiagnosticoInicial.Visible = false;
            DataTable dtFichaSaludPosterior = GetFichaSaludPosteriorGeneral(CodFichaSaludInicial);

            if (dtFichaSaludPosterior.Rows.Count > 0)
            {
                grdFichaPosterior.Columns[0].Visible = true;
                grdFichaPosterior.DataSource = dtFichaSaludPosterior;
                grdFichaPosterior.DataBind();
                grdFichaPosterior.Columns[0].Visible = false;

                for (int i = 0; i < dtFichaSaludPosterior.Rows.Count; i++)
			    {
                    DateTime FechaIngresoFichaPosteriorParticular = Convert.ToDateTime(dtFichaSaludPosterior.Rows[i]["FechaIngresoFichaPosterior"].ToString());
                    int IdUsuarioIngresoFicha = Convert.ToInt32(dtFichaSaludPosterior.Rows[i]["IdUsuarioIngresoFicha"]);
                    int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

                    if ((DateTime.Now - FechaIngresoFichaPosteriorParticular).TotalHours <= 24)
                    {
                        if (UsuarioActual == IdUsuarioIngresoFicha)
                        {
                            //1 es ver
                            //2 es modificar

                            grdFichaPosterior.Rows[i].Cells[3].Style.Add("display", "none");
                            grdFichaPosterior.Rows[i].Cells[4].Style.Add("display", "block");
                            
                        }
                        else
                        {
                            grdFichaPosterior.Rows[i].Cells[3].Style.Add("display", "block");
                            grdFichaPosterior.Rows[i].Cells[4].Style.Add("display", "none");
                            
                        }
                    }
                    else
                    {
                        grdFichaPosterior.Rows[i].Cells[3].Style.Add("display", "block");
                        grdFichaPosterior.Rows[i].Cells[4].Style.Add("display", "none");
                       
                    }
                   
			    }
               
                grdFichaPosterior.Visible = true;
                GrillaFichaPosterior.Visible = true;
                DatosFichaPosterior.Visible = false;

                divAlertaSinDiagnostiposterior.Visible = false;

                ScriptManager.RegisterStartupScript(this, GetType(), "deletecellempty", "document.getElementById('grdFichaPosterior').rows[0].deleteCell(3);", true);
            }

            else
            {
                DataTable dt = null;
                grdFichaPosterior.DataSource = dt;
                grdFichaPosterior.DataBind();
                grdFichaPosterior.Visible = false;
                GrillaFichaPosterior.Visible = false;
                DatosFichaPosterior.Visible = true;

                if (window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                {
                    btnGatillo.Visible = true;
                }
                btnCancelar.Visible = false;                
                DatosFichaPosterior.Visible = false;

                divAlertaSinDiagnostiposterior.Visible = true;
            }
        }
        else
        {
            divAlertaSinDiagnosticoInicial.Visible = true;
            btnGatillo.Visible = false;
            btnCancelar.Visible = false;
            GrillaFichaPosterior.Visible = false;
            DatosFichaPosterior.Visible = false;
            divAlertaSinDiagnostiposterior.Visible = false;
        }
            
    }

    public string RemoverAcentos(string inputString)
    {
        Regex a = new Regex("[á|à|ä|â|Á]", RegexOptions.Compiled);
        Regex e = new Regex("[é|è|ë|ê|É]", RegexOptions.Compiled);
        Regex i = new Regex("[í|ì|ï|î|Í]", RegexOptions.Compiled);
        Regex o = new Regex("[ó|ò|ö|ô|Ó]", RegexOptions.Compiled);
        Regex u = new Regex("[ú|ù|ü|û|Ú]", RegexOptions.Compiled);
        Regex n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
        inputString = a.Replace(inputString, "A");
        inputString = e.Replace(inputString, "E");
        inputString = i.Replace(inputString, "I");
        inputString = o.Replace(inputString, "O");
        inputString = u.Replace(inputString, "U");
        inputString = n.Replace(inputString, "N");
        return inputString;
    }

    private bool ValidaRadioButton(RadioButton rbtnSi, RadioButton rbtnNo)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (rbtnSi.Checked == false && rbtnNo.Checked == false)
        {
            rechazo = true;
            rbtnSi.BackColor = colorCampoObligatorio;
            rbtnNo.BackColor = colorCampoObligatorio;
        }
        else
        {
            rbtnSi.BackColor = System.Drawing.Color.Empty;
            rbtnNo.BackColor = System.Drawing.Color.Empty;
        }

        return rechazo;
    }

    private bool ValidaDropDownList(DropDownList ddl)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (ddl.SelectedValue == "0")
        {
            rechazo = true;
            ddl.BackColor = colorCampoObligatorio;
        }
        else
        {
            ddl.BackColor = System.Drawing.Color.Empty;
        }
        return rechazo;
    }

    private bool ValidaTextBox(TextBox txt)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (txt.Text == "")
        {
            rechazo = true;
            txt.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt.BackColor = System.Drawing.Color.Empty;
        }

        return rechazo;
    }

    private bool ValidaFichaSaludPosterior()
    {
        bool rechazo = false;        

        if (ValidaTextBox(txtFechaDiagnostico))
        { rechazo = true; }

        if (ValidaTextBox(txtDiagnosticoMedicoIngreso))
        { rechazo = true; }

        if (ValidaTextBox(txtMotivoConsulta))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnRinaSi,rbtnRinaNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnTrastornoSuenoSi, rbtnTrastornoSuenoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnAutoagresionSi, rbtnAutoagresionNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnAlgiaBucalSi, rbtnAlgiaBucalNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnIntentoSuicidioSi, rbtnIntentoSuicidioNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnTranquiloSi, rbtnTranquiloNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnExcitadoSi, rbtnExcitadoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnAngustiadoSi, rbtnAngustiadoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnDecaidoSi, rbtnDecaidoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnIrritableSi, rbtnIrritableNo))
        { rechazo = true; }

        if (ValidaTextBox(txtExamenFisico))
        { rechazo = true; }

        if (ValidaTextBox(txtDiagnosticoEgreso))
        { rechazo = true; }

        if (ValidaTextBox(txtTratamiento))
        { rechazo = true; }

        if (ValidaTextBox(txtDerivacion))
        { rechazo = true; }

        if (ValidaDropDownList(ddlPA))
        { rechazo = true; }

        if (ValidaDropDownList(ddlPulso))
        { rechazo = true; }

        if (ValidaDropDownList(ddlFR))
        { rechazo = true; }

        if (ValidaDropDownList(ddlTemperatura))
        { rechazo = true; }
        return rechazo;
    }


    private void GetData()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];

        if (SSnino != null)
        {
            int edad = 0;
            txtPrimerApellido.Text = HttpUtility.HtmlDecode(SSninoDiag.Apellido_Paterno.ToString());
            txtSegundoApellido.Text = HttpUtility.HtmlDecode(SSninoDiag.Apellido_Materno.ToString());
            txtNombre.Text = HttpUtility.HtmlDecode(SSninoDiag.Nombres.ToString());
            txtRut.Text = SSninoDiag.rut.ToString();
            txtFechaNacimiento.Text = Convert.ToString(SSninoDiag.FechaNacimiento.Day + "-" + SSninoDiag.FechaNacimiento.Month + "-" + SSninoDiag.FechaNacimiento.Year);
            edad = Convert.ToInt32((DateTime.Now.Year - SSninoDiag.FechaNacimiento.Year).ToString());
            txtEdad.Text = edad.ToString();
            txtFechaIngreso.Text = SSninoDiag.fchingdesde.ToShortDateString();

            String PrimerApellido = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Apellido_Paterno.ToString())).Trim());
            String SegundoApellido = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Apellido_Materno.ToString())).Trim());
            String Nombre = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Nombres.ToString())).Trim());
            String FecNac = (Convert.ToString(SSninoDiag.FechaNacimiento.Day)).Trim() + (Convert.ToString(SSninoDiag.FechaNacimiento.Month)).Trim() + (Convert.ToString(SSninoDiag.FechaNacimiento.Year)).Trim();
            String Rut = (SSninoDiag.rut.ToString()).Trim();

            try
            {
                if ((PrimerApellido != null || PrimerApellido != "") && (SegundoApellido != null || SegundoApellido != "") && (Nombre != null || Nombre != "") && (Rut != null || Rut != "") && (FecNac != null || FecNac != ""))
                {
                    txtNIdentificacion.Text = Nombre.Substring(0, 1) + PrimerApellido.Substring(0, 1) + SegundoApellido.Substring(0, 1) + FecNac + Rut.Substring((Rut.Length - 5), 5);
                }
                else
                {
                    txtNIdentificacion.Text = "Faltan Datos Para Generar el N° de Identificación ";
                }

            }
            catch
            {
                txtNIdentificacion.Text = "Datos Erroneos Para Generar el N° de Identificación";
            }


            DataView dvPA = new DataView(GetparParametricasFichaSalud(querytype.PA));
            ddlPA.DataSource = dvPA;
            ddlPA.DataTextField = "Descripcion";
            ddlPA.DataValueField = "CodParametrica";
            dvPA.Sort = "CodParametrica";
            ddlPA.DataBind();

            DataView dvPulso = new DataView(GetparParametricasFichaSalud(querytype.Pulso));
            ddlPulso.DataSource = dvPulso;
            ddlPulso.DataTextField = "Descripcion";
            ddlPulso.DataValueField = "CodParametrica";
            dvPulso.Sort = "CodParametrica";
            ddlPulso.DataBind();

            DataView dvFR = new DataView(GetparParametricasFichaSalud(querytype.FR));
            ddlFR.DataSource = dvFR;
            ddlFR.DataTextField = "Descripcion";
            ddlFR.DataValueField = "CodParametrica";
            dvFR.Sort = "CodParametrica";
            ddlFR.DataBind();

            DataView dvTemperatura = new DataView(GetparParametricasFichaSalud(querytype.T));
            ddlTemperatura.DataSource = dvTemperatura;
            ddlTemperatura.DataTextField = "Descripcion";
            ddlTemperatura.DataValueField = "CodParametrica";
            dvTemperatura.Sort = "CodParametrica";
            ddlTemperatura.DataBind();
        }
    }

    public int GetCodDiagnostico()
    {
        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        
        sqlc.CommandText = "select T1.CodDiagnostico from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = (SELECT CodDiagnostico FROM DiagnosticoGeneral where ICodIE = @ICodIE and CodTipoDiagnosticoGlosa = 11)";    
        sqlc.Parameters.AddWithValue("@ICodIE", SSninoDiag.ICodIE);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();

        if (dt.Rows.Count == 1)
        {
            returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        }
        if (dt.Rows.Count > 1)
        {
            returnvalue = -1;
        }
        return returnvalue;
    }

    public DataTable GetparParametricasFichaSalud(querytype TipoParametrica)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodParametrica, T1.descripcion from parParametricasFichaSalud T1 inner join parTipoParametricaFichaSalud T2 on T1.CodTipoParametrica = T2.CodTipoParametrica where T1.vigencia = 'V' and T2.descripcion = @TipoParametrica";

        sqlc.Parameters.Add("@TipoParametrica", SqlDbType.VarChar, 50).Value = Convert.ToString(TipoParametrica);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }


    public int GetCodDiagnosticoSaludFichaInicial(int CodDiagnostico)
    {
        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodFichaSaludInicial from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = @CodDiagnostico";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();

        if (dt.Rows.Count == 1)
        {
            returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        }
        if (dt.Rows.Count > 1)
        {
            returnvalue = -1;
        }
        return returnvalue;
    }

    public DataTable GetFichaSaludPosteriorGeneral(int CodFichaSaludInicial)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodFichaSaludPosterior, T2.CodDiagnostico as CodDiagnostico, T1.FechaDiagnostico, T1.FechaIngresoFichaPosterior, T1.IdUsuarioIngresoFicha " +
                            "from DiagnosticoSaludFichaSaludPosterior T1 INNER JOIN DiagnosticoSaludFichaSaludInicial T2 ON T1.CodFichaSaludInicial = T2.CodFichaSaludInicial where T1.CodFichaSaludInicial = @CodFichaSaludInicial";
        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetFichaSaludPosteriorParticular(int CodFichaSaludPosterior)
    {      
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select CodFichaSaludPosterior, FechaDiagnostico, DiagnosticoMedicoIngreso, MotivoConsulta, Riña, TrastornoDelSueño, Autoagresion, " +
                                "AlgiaBucal, IntentoSuicidio, PA, Pulso, FR, Temperatura, Tranquilo, Excitado, Angustiado, Decaido, Irritable, ExamenFisico, DiagnosticoEgreso, Tratamiento, Derivacion, IdUsuarioIngresoFicha, FechaIngresoFichaPosterior " +
                                "from DiagnosticoSaludFichaSaludPosterior where CodFichaSaludPosterior = @CodFichaSaludPosterior";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludPosterior", SqlDbType.Int, 4, CodFichaSaludPosterior));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private void InsertFichaSaludPosterior(SqlTransaction sqlt,
        int CodFichaSaludInicial,
        DateTime FechaDiagnostico,
        string DiagnosticoMedicoIngreso,
        string MotivoConsulta,
        int Riña,
        int TrastornoDelSueño,
        int Autoagresion,
        int AlgiaBucal,
        int IntentoSuicidio,
        int PA,
        int Pulso,
        int FR,
        int Temperatura,
        int Tranquilo,
        int Excitado,
        int Angustiado,
        int Decaido,
        int Irritable,
        string ExamenFisico,
        string DiagnosticoEgreso,
        string Tratamiento,
        string Derivacion,
        DateTime FechaActualizacion,
        int IdUsuarioIngresoFicha,
        DateTime FechaIngresoFichaPosterior
        )
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT DiagnosticoSaludFichaSaludPosterior (CodFichaSaludInicial, FechaDiagnostico, DiagnosticoMedicoIngreso, MotivoConsulta, Riña, TrastornoDelSueño, Autoagresion, AlgiaBucal, IntentoSuicidio, "+
                           " PA, Pulso, FR, Temperatura, Tranquilo, Excitado, Angustiado, Decaido, Irritable, ExamenFisico, DiagnosticoEgreso, Tratamiento, Derivacion, FechaActualizacion, IdUsuarioIngresoFicha, FechaIngresoFichaPosterior ) " +
                            "values (@CodFichaSaludInicial, @FechaDiagnostico, @DiagnosticoMedicoIngreso, @MotivoConsulta, @Riña, @TrastornoDelSueño, @Autoagresion, @AlgiaBucal, @IntentoSuicidio, " +
                           " @PA, @Pulso, @FR, @Temperatura, @Tranquilo, @Excitado, @Angustiado, @Decaido, @Irritable, @ExamenFisico, @DiagnosticoEgreso, @Tratamiento, @Derivacion, @FechaActualizacion, @IdUsuarioIngresoFicha, @FechaIngresoFichaPosterior )";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DiagnosticoMedicoIngreso", SqlDbType.VarChar, 140, DiagnosticoMedicoIngreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@MotivoConsulta", SqlDbType.VarChar, 140, MotivoConsulta));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Riña", SqlDbType.Int, 1, Riña));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@TrastornoDelSueño", SqlDbType.Int, 1, TrastornoDelSueño));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Autoagresion", SqlDbType.Int, 1, Autoagresion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@AlgiaBucal", SqlDbType.Int, 1, AlgiaBucal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IntentoSuicidio", SqlDbType.Int, 1, IntentoSuicidio)); 
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PA", SqlDbType.Int, 4, PA));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Pulso", SqlDbType.Int, 4, Pulso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FR", SqlDbType.Int, 4, FR));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Temperatura", SqlDbType.Int, 4, Temperatura));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tranquilo", SqlDbType.Int, 1, Tranquilo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Excitado", SqlDbType.Int, 1, Excitado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Angustiado", SqlDbType.Int, 1, Angustiado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Decaido", SqlDbType.Int, 1, Decaido));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Irritable", SqlDbType.Int, 1, Irritable));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ExamenFisico", SqlDbType.VarChar, 140, ExamenFisico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DiagnosticoEgreso", SqlDbType.VarChar, 140, DiagnosticoEgreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tratamiento", SqlDbType.VarChar, 250, Tratamiento));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Derivacion", SqlDbType.VarChar, 250, Derivacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioIngresoFicha", SqlDbType.Int, 4, IdUsuarioIngresoFicha));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaIngresoFichaPosterior", SqlDbType.DateTime, 16, FechaIngresoFichaPosterior));
        

        sqlc.ExecuteNonQuery();
        //returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        //return returnvalue;

    }

    private void UpdateFichaSaludPosterior(SqlTransaction sqlt,
       int CodFichaSaludPosterior,
       DateTime FechaDiagnostico,
       string DiagnosticoMedicoIngreso,
       string MotivoConsulta,
       int Riña,
       int TrastornoDelSueño,
       int Autoagresion,
       int AlgiaBucal,
       int IntentoSuicidio,
       int PA,
       int Pulso,
       int FR,
       int Temperatura,
       int Tranquilo,
       int Excitado,
       int Angustiado,
       int Decaido,
       int Irritable,
       string ExamenFisico,
       string DiagnosticoEgreso,
       string Tratamiento,
       string Derivacion,
       DateTime FechaActualizacion
        //int IdUsuarioIngresoFicha
        )
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "UPDATE  DiagnosticoSaludFichaSaludPosterior SET FechaDiagnostico = @FechaDiagnostico, DiagnosticoMedicoIngreso = @DiagnosticoMedicoIngreso, " +
                            "MotivoConsulta =  @MotivoConsulta,Riña = @Riña, TrastornoDelSueño= @TrastornoDelSueño, Autoagresion = @Autoagresion, AlgiaBucal = @AlgiaBucal, IntentoSuicidio = @IntentoSuicidio, " +
                           " PA = @PA, Pulso = @Pulso, FR = @FR, Temperatura = @Temperatura, Tranquilo = @Tranquilo, Excitado = @Excitado, Angustiado = @Angustiado, Decaido = @Decaido, Irritable = @Irritable, ExamenFisico =@ExamenFisico, " +
                           "DiagnosticoEgreso = @DiagnosticoEgreso, Tratamiento =  @Tratamiento, Derivacion = @Derivacion, FechaActualizacion = @FechaActualizacion " +
                           " WHERE CodFichaSaludPosterior = @CodFichaSaludPosterior ";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludPosterior", SqlDbType.Int, 4, CodFichaSaludPosterior));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DiagnosticoMedicoIngreso", SqlDbType.VarChar, 140, DiagnosticoMedicoIngreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@MotivoConsulta", SqlDbType.VarChar, 140, MotivoConsulta));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Riña", SqlDbType.Int, 1, Riña));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@TrastornoDelSueño", SqlDbType.Int, 1, TrastornoDelSueño));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Autoagresion", SqlDbType.Int, 1, Autoagresion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@AlgiaBucal", SqlDbType.Int, 1, AlgiaBucal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IntentoSuicidio", SqlDbType.Int, 1, IntentoSuicidio));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PA", SqlDbType.Int, 4, PA));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Pulso", SqlDbType.Int, 4, Pulso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FR", SqlDbType.Int, 4, FR));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Temperatura", SqlDbType.Int, 4, Temperatura));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tranquilo", SqlDbType.Int, 1, Tranquilo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Excitado", SqlDbType.Int, 1, Excitado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Angustiado", SqlDbType.Int, 1, Angustiado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Decaido", SqlDbType.Int, 1, Decaido));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Irritable", SqlDbType.Int, 1, Irritable));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ExamenFisico", SqlDbType.VarChar, 140, ExamenFisico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DiagnosticoEgreso", SqlDbType.VarChar, 140, DiagnosticoEgreso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tratamiento", SqlDbType.VarChar, 250, Tratamiento));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Derivacion", SqlDbType.VarChar, 250, Derivacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        //sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioIngresoFicha", SqlDbType.Int, 4, IdUsuarioIngresoFicha));

        sqlc.ExecuteNonQuery();
        //returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        //return returnvalue;

    }

    private int GetRadioButton(RadioButton rbtnSi, RadioButton rbtnNo)
    {
        if (rbtnSi.Checked == true || rbtnNo.Checked == true)
        {
            if (rbtnSi.Checked == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return -1;
        }
    }

    private string GetTexBox(TextBox txt)
    {
        if (txt.Text == "")
        {

            return "-1";
        }
        else
        {
            return txt.Text;
        }

    }


    private string GetDateTime(TextBox txt)
    {
        if (txt.Text == "")
        {
            return "01-01-1900";
        }
        else
        {
            return txt.Text;
        }

    }

    private void GuardarFicha()
    {
        SqlTransaction sqlt;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        int Guardado = 0;
        bool Insert = false;
        try
        {

            if (CodFichaSaludPosterior < 1)
            {
                InsertFichaSaludPosterior(sqlt, CodFichaSaludInicial, Convert.ToDateTime(txtFechaDiagnostico.Text), GetTexBox(txtDiagnosticoMedicoIngreso), GetTexBox(txtMotivoConsulta),
                                GetRadioButton(rbtnRinaSi, rbtnRinaNo), GetRadioButton(rbtnTrastornoSuenoSi, rbtnTrastornoSuenoNo), GetRadioButton(rbtnAutoagresionSi, rbtnAutoagresionNo),
                                GetRadioButton(rbtnAlgiaBucalSi, rbtnAlgiaBucalNo), GetRadioButton(rbtnIntentoSuicidioSi, rbtnIntentoSuicidioNo), Convert.ToInt32(ddlPA.SelectedValue),
                                Convert.ToInt32(ddlPulso.SelectedValue), Convert.ToInt32(ddlFR.SelectedValue), Convert.ToInt32(ddlTemperatura.SelectedValue), GetRadioButton(rbtnTranquiloSi, rbtnTranquiloNo),
                                GetRadioButton(rbtnExcitadoSi, rbtnExcitadoNo), GetRadioButton(rbtnAngustiadoSi, rbtnAngustiadoNo), GetRadioButton(rbtnDecaidoSi, rbtnDecaidoNo), GetRadioButton(rbtnIrritableSi, rbtnIrritableNo),
                                GetTexBox(txtExamenFisico), GetTexBox(txtDiagnosticoEgreso), GetTexBox(txtTratamiento), GetTexBox(txtDerivacion), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);
                Guardado = 1;
                Insert = true;

            }


            if (CodFichaSaludPosterior > 0)
            {
                if ((ViewState["FechaIngresoFichaPosterior"] != null && Convert.ToString(ViewState["FechaIngresoFichaPosterior"]) != "") && (ViewState["IdUsuarioIngresoFicha"] != null && Convert.ToString(ViewState["IdUsuarioIngresoFicha"]) != ""))
                {
                    DateTime FechaIngresoFichaPosterior = Convert.ToDateTime(ViewState["FechaIngresoFichaPosterior"]);
                    int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
                    int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

                    if ((DateTime.Now - FechaIngresoFichaPosterior).TotalHours <= 24)
                    {

                        if (UsuarioActual == IdUsuarioIngresoFicha)
                        {
                            UpdateFichaSaludPosterior(sqlt, CodFichaSaludPosterior, Convert.ToDateTime(txtFechaDiagnostico.Text), GetTexBox(txtDiagnosticoMedicoIngreso), GetTexBox(txtMotivoConsulta),
                                GetRadioButton(rbtnRinaSi, rbtnRinaNo), GetRadioButton(rbtnTrastornoSuenoSi, rbtnTrastornoSuenoNo), GetRadioButton(rbtnAutoagresionSi, rbtnAutoagresionNo),
                                GetRadioButton(rbtnAlgiaBucalSi, rbtnAlgiaBucalNo), GetRadioButton(rbtnIntentoSuicidioSi, rbtnIntentoSuicidioNo), Convert.ToInt32(ddlPA.SelectedValue),
                                Convert.ToInt32(ddlPulso.SelectedValue), Convert.ToInt32(ddlFR.SelectedValue), Convert.ToInt32(ddlTemperatura.SelectedValue), GetRadioButton(rbtnTranquiloSi, rbtnTranquiloNo),
                                GetRadioButton(rbtnExcitadoSi, rbtnExcitadoNo), GetRadioButton(rbtnAngustiadoSi, rbtnAngustiadoNo), GetRadioButton(rbtnDecaidoSi, rbtnDecaidoNo), GetRadioButton(rbtnIrritableSi, rbtnIrritableNo),
                                GetTexBox(txtExamenFisico), GetTexBox(txtDiagnosticoEgreso), GetTexBox(txtTratamiento), GetTexBox(txtDerivacion), DateTime.Now);

                            Guardado = 1;
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('La ficha no puede ser modificada por un usuario distinto.');</script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('La ficha no puede ser modificada despues de 24 hora de ser ingresada.');</script>");
                    }
                }
            }

            sqlt.Commit();
            sconn.Close();
            CleanForm();
            DatosFichaPosterior.Visible = false;
            btnGatillo.Visible = true;
            btnCancelar.Visible = false;

            if (Guardado == 1)
            {
                Response.Write("<script language='javascript'>alert('Guardado de Ficha realizado de forma exitosa');</script>");
            }

            //if (Insert == true)
            //{
            //    DateTime FechaFinal = DateTime.Now.AddDays(1);
            //    String FechaFinalSeteadaDiagPost = FechaFinal.Month + "/" + FechaFinal.Day + "/" + FechaFinal.Year + " " + FechaFinal.TimeOfDay;
            //    ViewState["FechaFinalSeteadaDiagPost"] = FechaFinalSeteadaDiagPost;
            //    tdHorasRestantes.Visible = true;
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('" + FechaFinalSeteadaDiagPost + "', 'countdownDiagPosterior');", true);
            //    ViewState["IdUsuarioIngresoFicha"] = Convert.ToInt32(Session["IdUsuario"]);
            //    ViewState["FechaIngresoFichaInicial"] = Convert.ToDateTime(DateTime.Now);
            //}
           
        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript'>alert('Hay problemas con la ficha de salud, intentar nuevamene.');</script>");
            Console.WriteLine(ex.Message);
            try
            {
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                Response.Write("<script language='javascript'>alert('Hay problemas con la ficha de salud, por favor contactarse con mesa de ayuda. ');</script>");
                Console.WriteLine(exRollback.Message);
            }
        }
    }
    protected void lnkGuardarFichaPosterior_Click(object sender, EventArgs e)
    {
        RangeValidator1.Validate();

        if (RangeValidator1.IsValid)
        {
            if (!ValidaFichaSaludPosterior())
            {
                alerts.Visible = false;
                lbl_nota1.Visible = false;
                GuardarFicha();
                ObtenerFichaSaludPosterior();
            }
            else
            {
                alerts.Visible = true;
                lbl_nota1.Visible = true;
            }
        }

        
    }

    private void CleanForm()
    {
        txtDiagnosticoMedicoIngreso.Text = "";
        txtMotivoConsulta.Text = "";
        rbtnRinaSi.Checked = false;
        rbtnRinaNo.Checked = false;
        rbtnTrastornoSuenoSi.Checked = false;
        rbtnTrastornoSuenoNo.Checked = false;
        rbtnAutoagresionSi.Checked = false;
        rbtnAutoagresionNo.Checked = false;
        rbtnAlgiaBucalSi.Checked = false;
        rbtnAlgiaBucalNo.Checked = false;
        rbtnIntentoSuicidioSi.Checked = false;
        rbtnIntentoSuicidioNo.Checked = false;
        ddlPA.SelectedValue = "0";
        ddlPulso.SelectedValue = "0";
        ddlFR.SelectedValue = "0";
        ddlTemperatura.SelectedValue = "0";
        rbtnTranquiloSi.Checked = false;
        rbtnTranquiloNo.Checked = false;
        rbtnExcitadoSi.Checked = false;
        rbtnExcitadoNo.Checked = false;
        rbtnAngustiadoSi.Checked = false;
        rbtnAngustiadoNo.Checked = false;
        rbtnDecaidoSi.Checked = false;
        rbtnDecaidoNo.Checked = false;
        rbtnIrritableSi.Checked = false;
        rbtnIrritableNo.Checked = false;
        txtExamenFisico.Text = "";
        txtDiagnosticoEgreso.Text = "";
        txtTratamiento.Text = "";
        txtDerivacion.Text = "";

    }

    private void SetRadioButton(int Valor, RadioButton rbtnSi, RadioButton rbtnNo)
    {
        if (Valor == 1)
        {
            rbtnSi.Checked = true;
            rbtnNo.Checked = false;
        }
        if (Valor == 0)
        {
            rbtnSi.Checked = false;
            rbtnNo.Checked = true;
        }
    }


    private void SetTextBox(string valor, TextBox txt)
    {
        try
        {
            if (Convert.ToInt32(valor) == -1)
            {
                txt.Text = "";
            }
            else
            {
                txt.Text = valor.ToString();
            }
        }
        catch
        {
            txt.Text = valor.ToString();
        }
    }

    protected void grdFichaPosterior_RowCommand(object sender, GridViewCommandEventArgs e)
    {        

        CodFichaSaludPosterior = Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

        ViewState["CodFichaSaludPosterior"] = CodFichaSaludPosterior;

        DataTable dtFichaSaludPosteriorParticular = GetFichaSaludPosteriorParticular(CodFichaSaludPosterior);

        CleanForm();
        btnGatillo.Visible = false;
        btnCancelar.Visible = true;

        ViewState["FechaIngresoFichaPosterior"] = dtFichaSaludPosteriorParticular.Rows[0]["FechaIngresoFichaPosterior"];
        ViewState["IdUsuarioIngresoFicha"] = dtFichaSaludPosteriorParticular.Rows[0]["IdUsuarioIngresoFicha"];

        if ((ViewState["FechaIngresoFichaPosterior"] != null && Convert.ToString(ViewState["FechaIngresoFichaPosterior"]) != "") && (ViewState["IdUsuarioIngresoFicha"] != null && Convert.ToString(ViewState["IdUsuarioIngresoFicha"]) != ""))
        {
            DateTime FechaIngresoFichaPosterior = Convert.ToDateTime(ViewState["FechaIngresoFichaPosterior"]);
            int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
            int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

            if ((DateTime.Now - FechaIngresoFichaPosterior).TotalHours <= 24)
            {
                if (UsuarioActual == IdUsuarioIngresoFicha)
                {
                    if (window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                    {
                        lnkGuardarFichaPosterior.Visible = true;
                    }
                    DateTime FechaFinal = FechaIngresoFichaPosterior.AddDays(1);
                    String FechaFinalSeteadaDiagPost = FechaFinal.Month + "/" + FechaFinal.Day + "/" + FechaFinal.Year + " " + FechaFinal.TimeOfDay;                   

                    ViewState["FechaFinalSeteadaDiagPost"] = FechaFinalSeteadaDiagPost;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('04/13/2016 6:30 PM', 'countdown');", true);  
                    
                    tdHorasRestantes.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('" + FechaFinalSeteadaDiagPost + "', 'countdownDiagPosterior', false);", true);
                }
                else
                {
                    tdHorasRestantes.Visible = false;
                    lnkGuardarFichaPosterior.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblDatosFichaPosterior", " $('#tblDatosFichaPosterior').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
                }
            }
            else
            {
                tdHorasRestantes.Visible = false;
                lnkGuardarFichaPosterior.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblDatosFichaPosterior", " $('#tblDatosFichaPosterior').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            }
        }


        txtFechaDiagnostico.Text = Convert.ToDateTime(dtFichaSaludPosteriorParticular.Rows[0]["FechaDiagnostico"]).ToShortDateString();

        try
        {
            SetTextBox(dtFichaSaludPosteriorParticular.Rows[0]["DiagnosticoMedicoIngreso"].ToString(), txtDiagnosticoMedicoIngreso);
        }
        catch { }


        try
        {
            SetTextBox(dtFichaSaludPosteriorParticular.Rows[0]["MotivoConsulta"].ToString(), txtMotivoConsulta);
        }
        catch { }


        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Riña"]), rbtnRinaSi, rbtnRinaNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["TrastornoDelSueño"]), rbtnTrastornoSuenoSi, rbtnTrastornoSuenoNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Autoagresion"]), rbtnAutoagresionSi, rbtnAutoagresionNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["AlgiaBucal"]), rbtnAlgiaBucalSi, rbtnAlgiaBucalNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["IntentoSuicidio"]), rbtnIntentoSuicidioSi, rbtnIntentoSuicidioNo);
        }
        catch { }

        try
        {
            ddlPA.Items.FindByValue(ddlPA.SelectedValue).Selected = false;
            ddlPA.Items.FindByValue(dtFichaSaludPosteriorParticular.Rows[0]["PA"].ToString()).Selected = true;
        }
        catch { }

        try
        {
            ddlPulso.Items.FindByValue(ddlPulso.SelectedValue).Selected = false;
            ddlPulso.Items.FindByValue(dtFichaSaludPosteriorParticular.Rows[0]["Pulso"].ToString()).Selected = true;
        }
        catch { }

        try
        {
            ddlFR.Items.FindByValue(ddlFR.SelectedValue).Selected = false;
            ddlFR.Items.FindByValue(dtFichaSaludPosteriorParticular.Rows[0]["FR"].ToString()).Selected = true;
        }
        catch { }

        try
        {
            ddlTemperatura.Items.FindByValue(ddlTemperatura.SelectedValue).Selected = false;
            ddlTemperatura.Items.FindByValue(dtFichaSaludPosteriorParticular.Rows[0]["Temperatura"].ToString()).Selected = true;
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Tranquilo"]), rbtnTranquiloSi, rbtnTranquiloNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Excitado"]), rbtnExcitadoSi, rbtnExcitadoNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Angustiado"]), rbtnAngustiadoSi, rbtnAngustiadoNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Decaido"]), rbtnDecaidoSi, rbtnDecaidoNo);
        }
        catch { }

        try
        {
            SetRadioButton(Convert.ToInt32(dtFichaSaludPosteriorParticular.Rows[0]["Irritable"]), rbtnIrritableSi, rbtnIrritableNo);
        }
        catch { }

        try
        {
            SetTextBox(dtFichaSaludPosteriorParticular.Rows[0]["ExamenFisico"].ToString(),txtExamenFisico);
        }
        catch { }

        try
        {
            SetTextBox(dtFichaSaludPosteriorParticular.Rows[0]["DiagnosticoEgreso"].ToString(), txtDiagnosticoEgreso);
        }
        catch { }

        try
        {
            SetTextBox(dtFichaSaludPosteriorParticular.Rows[0]["Tratamiento"].ToString(), txtTratamiento);
        }
        catch { }

        try
        {
            SetTextBox(dtFichaSaludPosteriorParticular.Rows[0]["Derivacion"].ToString(), txtDerivacion);
        }
        catch { }

        DatosFichaPosterior.Visible = true;

    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
    protected void btnGatillo_Click(object sender, EventArgs e)
    {
        CleanForm();
        ViewState["FechaFinalSeteadaDiagPost"] = "";
        tdHorasRestantes.Visible = false;

        DatosFichaPosterior.Visible = true;
        btnGatillo.Visible = false;
        btnCancelar.Visible = true;

        if (window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
        {
            lnkGuardarFichaPosterior.Visible = true;
        }
        divAlertaSinDiagnostiposterior.Visible = false;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        DatosFichaPosterior.Visible = false;
        
        btnCancelar.Visible = false;

        if (grdFichaPosterior.Rows.Count == 0)
        {
            divAlertaSinDiagnostiposterior.Visible = true;
        }

        if (window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
        {
            btnGatillo.Visible = true;
        }
    }    
}