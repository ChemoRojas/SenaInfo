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


public partial class mod_ninos_DiagnosticoSalud_FichaSalud : System.Web.UI.Page
{

    public enum guardadotype
    {
        DatosRelevantes,
        Derivacion,
        Anamnesis,
        ExamenFisicoConciencia,
        ExamenFisicoPiel,
        Completo
    }

    public enum collapsetype
    {
        DatosPersonales,
        DatosRelevantes,
        Anamnesis,
        ExamenFisicoConciencia,
        ExamenFisicoPiel,
        Ninguno
    }

    public enum querytype
    {
        Otros,
        Presentacion_Farmacos,
        Unidad_Farmacos,
        Antecedentes_Gineco_Obstetricos,
        Antecedentes_Familiares,        
        Trastornos,
        Sindromes,
        PA,
        Pulso,
        FR,
        T,
        Movilidad,
        Talla_Edad,
        Estado_Nutricional,
        Desarrollo_Cognitivo,
        Comunicacion,
        Desarrollo_Socio_Emocional,
        Grados_de_Tunner,
        Evaluación_Ortopedica,
        Displacia_de_Cadera,
        Color,
        Humedad,
        Cabeza,
        Cuello,
        Torax,
        Abdomen,
        Extremidades,
        Sintoma_Extremidades,
        Genitales,
        Marcha,
        Eval_Genitales,
        Vision,
        Audicion,
        Salud_Bucal,
        Columna,
        Tipo_Examen,
        Examen,
        Conducta_Sexual,
        DiagnosticoGeneral,
        FichaSaludInicial,
        AntecedentesMorbidos,
        Farmacos,        
        Alergias
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

    public DataTable DTAntecedentesMorbidos
    {
        get { return (DataTable)Session["DTAntecedentesMorbidos"]; }
        set { Session["DTAntecedentesMorbidos"] = value; }
    }

    public DataTable DTFarmacos
    {
        get { return (DataTable)Session["DTFarmacos"]; }
        set { Session["DTFarmacos"] = value; }
    }    

    public DataTable DTAlergias
    {
        get { return (DataTable)Session["DTAlergias"]; }
        set { Session["DTAlergias"] = value; }
    }
       

    public DataTable DTTrastornos
    {
        get { return (DataTable)Session["DTTrastornos"]; }
        set { Session["DTTrastornos"] = value; }
    }

    public DataTable DTSindromes
    {
        get { return (DataTable)Session["DTSindromes"]; }
        set { Session["DTSindromes"] = value; }
    }

    public DataTable DTExamenes
    {
        get { return (DataTable)Session["DTExamenes"]; }
        set { Session["DTExamenes"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "max", "max(txtHistoriaClinicaEvolutiva);CharLimit(txtHistoriaClinicaEvolutiva, 1000);", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "max2", "max2(txtAntecedentesQuirurgicosyH);CharLimit2(txtAntecedentesQuirurgicosyH, 140);", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "max3", "max3();CharLimit3(30);", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "max4", "max4();CharLimit4(30);", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "calculaIMC", "calculaIMC();", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblDatosPersonales", " $('#tblDatosPersonales').find('input,button,textarea,select').attr('disabled', 'disabled');", true);

        if (ViewState["FechaFinalSeteadaDiagInicial"] != null)
        {
            if (ViewState["FechaFinalSeteadaDiagInicial"].ToString() != "")
            {
                String FechaFinalSeteadaDiagInicial = ViewState["FechaFinalSeteadaDiagInicial"].ToString();
                tdHorasRestantes.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('" + FechaFinalSeteadaDiagInicial + "', 'countdownDiagInicial');", true);
            }
        }

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
                if (window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B") || window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                {
                    if (window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B"))
                    {
                        ModificaFicha(false);
                    }

                    GetDefaultData();
                    SetAllDT();
                    GuardarObtenerDiagGeneral();
                }                
            }
        }

        if (IsPostBack)
        {
            RangeValidator1.Validate();
            RangeValidator2.Validate();
            RangeValidator3.Validate();
            RangeValidator4.Validate();
            RangeValidator8.Validate();
            RangeValidator9.Validate();
        }

        VerificaDerivaciones();
       
    }


    private void VerificaDerivaciones()
    {
        if (Session["lblDerivacionVision"] != null)
        {
            if (Session["lblDerivacionVision"].ToString() != "")
            {
                if (Session["lblDerivacionVision"].ToString() == "VerModificar" || Session["lblDerivacionVision"].ToString() == "Ver")
                {
                    if (Session["lblDerivacionVision"].ToString() == "VerModificar")
                    {
                        lblDerivacionVision.Text = "Ver o Modificar Derivación";
                    }
                    if (Session["lblDerivacionVision"].ToString() == "Ver")
                    {
                        lblDerivacionVision.Text = "Ver Derivación";
                    }
                    spanDerivacionVision.Attributes.Remove("class");
                    spanDerivacionVision.Attributes.Add("class", "glyphicon glyphicon-eye-open");
                }
            }
        }
        if (Session["lblDerivacionAudicion"] != null)
        {
            if (Session["lblDerivacionAudicion"].ToString() != "")
            {
                if (Session["lblDerivacionAudicion"].ToString() == "VerModificar" || Session["lblDerivacionAudicion"].ToString() == "Ver")
                {
                    if (Session["lblDerivacionAudicion"].ToString() == "VerModificar")
                    {
                        lblDerivacionAudicion.Text = "Ver o Modificar Derivación";
                    }
                    if (Session["lblDerivacionAudicion"].ToString() == "Ver")
                    {
                        lblDerivacionAudicion.Text = "Ver Derivación";
                    }
                    spanDerivacionAudicion.Attributes.Remove("class");
                    spanDerivacionAudicion.Attributes.Add("class", "glyphicon glyphicon-eye-open");
                }
            }
        }

        if (Session["lblDerivacionSaludBucal"] != null)
        {
            if (Session["lblDerivacionSaludBucal"].ToString() != "")
            {
                if (Session["lblDerivacionSaludBucal"].ToString() == "VerModificar" || Session["lblDerivacionSaludBucal"].ToString() == "Ver")
                {
                    if (Session["lblDerivacionSaludBucal"].ToString() == "VerModificar")
                    {
                        lblDerivacionSaludBucal.Text = "Ver o Modificar Derivación";
                    }
                    if (Session["lblDerivacionSaludBucal"].ToString() == "Ver")
                    {
                        lblDerivacionSaludBucal.Text = "Ver Derivación";
                    }
                    spanDerivacionSaludBucal.Attributes.Remove("class");
                    spanDerivacionSaludBucal.Attributes.Add("class", "glyphicon glyphicon-eye-open");
                }
            }
        }

        if (Session["lblDerivacionColumna"] != null)
        {
            if (Session["lblDerivacionColumna"].ToString() != "")
            {
                if (Session["lblDerivacionColumna"].ToString() == "VerModificar" || Session["lblDerivacionColumna"].ToString() == "Ver")
                {
                    if (Session["lblDerivacionColumna"].ToString() == "VerModificar")
                    {
                        lblDerivacionColumna.Text = "Ver o Modificar Derivación";
                    }
                    if (Session["lblDerivacionColumna"].ToString() == "Ver")
                    {
                        lblDerivacionColumna.Text = "Ver Derivación";
                    }
                    spanDerivacionColumna.Attributes.Remove("class");
                    spanDerivacionColumna.Attributes.Add("class", "glyphicon glyphicon-eye-open");
                }
            }
        }
    }

    private void SetAllDT()
    {
        DTAntecedentesMorbidos = new DataTable();
        DTAntecedentesMorbidos.Columns.Add(new DataColumn("DescripcionAntecedenteMorbido", typeof(string)));
        DTAntecedentesMorbidos.Columns.Add(new DataColumn("CodAntecedenteMorbido", typeof(int)));
        DTAntecedentesMorbidos.Columns.Add(new DataColumn("Tratamiento", typeof(int)));
        DTAntecedentesMorbidos.Clear();

        DTFarmacos = new DataTable();
        DTFarmacos.Columns.Add(new DataColumn("DescripcionFarmaco", typeof(string)));
        DTFarmacos.Columns.Add(new DataColumn("CodFarmaco", typeof(int)));
        //DTFarmacos.Columns.Add(new DataColumn("DescripcionUnidad", typeof(string)));
        //DTFarmacos.Columns.Add(new DataColumn("CodUnidad", typeof(int)));
        DTFarmacos.Columns.Add(new DataColumn("DescripcionPresentacion", typeof(string)));
        DTFarmacos.Columns.Add(new DataColumn("CodPresentacion", typeof(int)));
        DTFarmacos.Columns.Add(new DataColumn("Manana", typeof(bool)));
        DTFarmacos.Columns.Add(new DataColumn("CantidadManana", typeof(string)));
        DTFarmacos.Columns.Add(new DataColumn("Tarde", typeof(bool)));
        DTFarmacos.Columns.Add(new DataColumn("CantidadTarde", typeof(string)));
        DTFarmacos.Columns.Add(new DataColumn("Noche", typeof(bool)));
        DTFarmacos.Columns.Add(new DataColumn("CantidadNoche", typeof(string)));
        DTFarmacos.Columns.Add(new DataColumn("DescripcionOtros", typeof(string)));
        DTFarmacos.Clear();          
        
        DTAlergias = new DataTable();
        DTAlergias.Columns.Add(new DataColumn("DescripcionAlergia", typeof(string)));
        DTAlergias.Columns.Add(new DataColumn("CodAlergia", typeof(int)));
        DTAlergias.Columns.Add(new DataColumn("DescripcionOtros", typeof(string)));
        DTAlergias.Clear();
       
        DTTrastornos = new DataTable();
        DTTrastornos.Columns.Add(new DataColumn("DescripcionTrastornos", typeof(string)));
        DTTrastornos.Columns.Add(new DataColumn("CodTrastorno", typeof(int)));
        DTTrastornos.Clear();
        
        DTSindromes = new DataTable();
        DTSindromes.Columns.Add(new DataColumn("DescripcionSindrome", typeof(string)));
        DTSindromes.Columns.Add(new DataColumn("CodSindrome", typeof(int)));
        DTSindromes.Clear();

        DTExamenes = new DataTable();
        DTExamenes.Columns.Add(new DataColumn("DescripcionTipoExamen", typeof(string)));
        DTExamenes.Columns.Add(new DataColumn("CodTipoExamen", typeof(int)));
        DTExamenes.Columns.Add(new DataColumn("DescripcionExamen", typeof(string)));
        DTExamenes.Columns.Add(new DataColumn("CodExamen", typeof(int)));
        DTExamenes.Clear();
    }

    private DataTable GetAmmamnesisRemota(SqlTransaction sqlt, querytype Tipo, int CodFichaSaludInicial)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        if (Tipo == querytype.AntecedentesMorbidos)
        {
            sqlc.CommandText = "select (select Descripcion from parAntecedentesMorbidos where CodAntecedenteMorbido = T1.CodAntecedenteMorbido) as DescripcionAntecedenteMorbido, T1.CodAntecedenteMorbido, " +
                                "Tratamiento from AntecedentesMorbidos T1 where T1.CodFichaSaludInicial = @CodFichaSaludInicial";
        }

        if (Tipo == querytype.Farmacos)
        {
            sqlc.CommandText = "select T2.Descripcion as DescripcionFarmaco, T1.CodFarmaco, " +
                               "(select Descripcion from parParametricasFichaSalud where CodParametrica = T1.CodPresentacion) as DescripcionPresentacion, T1.CodPresentacion, " +
                                "T1.Manana, T1.CantidadManana, T1.Tarde, T1.CantidadTarde, T1.Noche, T1.CantidadNoche, Otros as DescripcionOtros " +
                                "from Farmacos T1 INNER JOIN parFarmacos T2 on T1.CodFarmaco = T2.CodFarmaco where T1.CodFichaSaludInicial = @CodFichaSaludInicial";
        }
        

        if (Tipo == querytype.Alergias)
        {
            sqlc.CommandText = "Select (select Descripcion from parAlergias where CodAlergia = T1.CodAlergia) as DescripcionAlergia, T1.CodAlergia, Otros as DescripcionOtros from Alergias T1 where CodFichaSaludInicial = @CodFichaSaludInicial";
        }        

        if (Tipo == querytype.Trastornos)
        {
            sqlc.CommandText = "Select (select Descripcion from parParametricasFichaSalud where CodParametrica = T1.CodTrastorno) as DescripcionTrastornos, T1.CodTrastorno "+
                                "from Trastornos T1 where CodFichaSaludInicial = @CodFichaSaludInicial";
        }

        if (Tipo == querytype.Sindromes)
        {
            sqlc.CommandText = "Select (select Descripcion from parParametricasFichaSalud where CodParametrica = T1.CodSindrome) as DescripcionSindrome, T1.CodSindrome " +
                                "from Sindromes T1 where CodFichaSaludInicial = @CodFichaSaludInicial";
        }


        sqlc.Parameters.AddWithValue("@CodFichaSaludInicial", CodFichaSaludInicial);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);


        return dt;
    }

    private DataTable GetExamenes(SqlTransaction sqlt, int CodFichaSaludInicial)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select T3.Descripcion as DescripcionTipoExamen, T3.CodTipoExamen, T2.Descripcion as DescripcionExamen, T2.CodExamen " +
                           "From Examenes T1 inner join parExamen T2 on T1.CodExamen = T2.CodExamen Inner join parTipoExamen T3 on T2.CodTipoExamen = T3.CodTipoExamen " +
                           "where T1.CodFichaSaludInicial = @CodFichaSaludInicial";
        sqlc.Parameters.AddWithValue("@CodFichaSaludInicial", CodFichaSaludInicial);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
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

    private void GetDefaultData()
    {

        DataSet ds = (DataSet)Session["dsParametricas"];

        if (SSnino != null)
        {

            int edad = 0;
            txtPrimerApellido.Text = HttpUtility.HtmlDecode(SSninoDiag.Apellido_Paterno.ToString());
            txtSegundoApellido.Text = HttpUtility.HtmlDecode(SSninoDiag.Apellido_Materno.ToString());
            txtNombre.Text = HttpUtility.HtmlDecode(SSninoDiag.Nombres.ToString());
            txtRut.Text = SSninoDiag.rut.ToString();
            txtFechaNacimiento.Text = SSninoDiag.FechaNacimiento.ToShortDateString();
            //txtFechaNacimiento.Text = Convert.ToString(SSninoDiag.FechaNacimiento.Day + "-" + SSninoDiag.FechaNacimiento.Month + "-" + SSninoDiag.FechaNacimiento.Year);
            edad = Convert.ToInt32((DateTime.Now.Year - SSninoDiag.FechaNacimiento.Year).ToString());
            txtEdad.Text = edad.ToString();
            txtFechaIngreso.Text = SSninoDiag.fchingdesde.ToShortDateString();

            String PrimerApellido = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Apellido_Paterno.ToString())).Trim());
            String SegundoApellido = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Apellido_Materno.ToString())).Trim());
            String Nombre = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Nombres.ToString())).Trim());
            String FecNac =  SSninoDiag.FechaNacimiento.ToShortDateString().Replace("-","");
            //String FecNac = (Convert.ToString(SSninoDiag.FechaNacimiento.Day)).Trim() + (Convert.ToString(SSninoDiag.FechaNacimiento.Month)).Trim() + (Convert.ToString(SSninoDiag.FechaNacimiento.Year)).Trim();
            String Rut = (SSninoDiag.rut.ToString()).Trim();

            if ((PrimerApellido != null && PrimerApellido != "") && (SegundoApellido != null && SegundoApellido != "") && (Nombre != null && Nombre != "") && (Rut != null && Rut != "" && Rut.Length > 8) && (FecNac != null && FecNac != ""))
            {
                txtNIdentificacion.Text = Nombre.Substring(0, 1) + PrimerApellido.Substring(0, 1) + SegundoApellido.Substring(0, 1) + FecNac + Rut.Substring((Rut.Length - 5), 5);
            }
            else
            {
                txtNIdentificacion.Text = "Faltan Datos para generar el N° de identificación ";
            }

            //Para Mayores de 14 años, habilitar IMC y bloquear talla/edad peso/talla peso/edad y perímetro craneano.
            //Para Menores de 14 años, habilitar talla/edad peso/talla peso/edad y perímetro craneano y bloquear IMC.

            if (edad >= 14)
            {
                ddlPerimetroCraneano.Enabled = false;
                ddlTallaEdad.Enabled = false;
                txtPesoTalla.Enabled = false;
                txtPesoEdad.Enabled = false;
            }
            if (edad < 14)
            {
                txtIMC.Enabled = false;
            }            

            DataTable dtHechoSaludIntentoSuicida = GetIntentoSuicidaHechosSalud(Convert.ToInt32(SSninoDiag.ICodIE));

            if (dtHechoSaludIntentoSuicida.Rows.Count > 0)
            {
                trIntentoSuicida.Visible = true;
                grdIntentoSuicida.DataSource = dtHechoSaludIntentoSuicida;
                grdIntentoSuicida.DataBind();
                trAlertaSinSuicidio.Visible = false;
            }
            else
            {
                trIntentoSuicida.Visible = false;
                lblAlertaSinSuicidio.Text = "No se Encontraron Registros de Intento de Suicidio";
                trAlertaSinSuicidio.Visible = true;
            }

            DataTable dtDiscapacidadHechosSalud = GetDiscapacidadHechosSalud(Convert.ToInt32(SSninoDiag.ICodIE));

            if (dtDiscapacidadHechosSalud.Rows.Count > 0)
            {
                trGridDiscapacidad.Visible = true;
                grdDiscapacidad.DataSource = dtDiscapacidadHechosSalud;
                grdDiscapacidad.DataBind();
                trAlertaSinDiscapacidad.Visible = false;
            }
            else
            {
                trGridDiscapacidad.Visible = false;
                lblAlertaSinDiscapacidad.Text = "No se Encontraron Registros de Discapacidad";
                trAlertaSinDiscapacidad.Visible = true;
            }


            DataTable dtConsumoDroga = GetDiagnosticoDroga(SSninoDiag.ICodIE);

            if (dtConsumoDroga.Rows.Count > 0)
            {
                trAlertaSinConsumoDroga.Visible = false;
                DataView dvConsumoDroga = new DataView(dtConsumoDroga);
                dvConsumoDroga.Sort = "FechaDiagnostico DESC";
                grdConsumoDroga.DataSource = dvConsumoDroga;
                grdConsumoDroga.DataBind();
                trGridConsumoDrogas.Visible = true;
            }
            else
            {
                trAlertaSinConsumoDroga.Visible = true;
                lblAlertaSinConsumoDroga.Text = "No se Encontraron Registros de Diagnóstico de Droga";
            }


            if (edad < 6)
            {
                thVacunasAlDia.Visible = true;
                tdVacunasAlDia.Visible = true;
                thGradoTunner.Visible = true;
                tdGradoTunner.Visible = true;
                thEvaluacionGenitales.Visible = true;
                tdEvaluacionGenitales.Visible = true;

            }
            else
            {
                thVacunasAlDia.Visible = false;
                tdVacunasAlDia.Visible = false;
                thGradoTunner.Visible = false;
                tdGradoTunner.Visible = false;
                thEvaluacionGenitales.Visible = false;
                tdEvaluacionGenitales.Visible = false;
            }
            

            parcoll par = new parcoll();
            DataView dvNacionalidad = new DataView(par.GetparNacionalidades());
            DataView dvEtnia = new DataView(par.GetparEtnias());
            DataView dvRegiones = new DataView(ds.Tables["dtparRegion"]);
            //dvRegiones.Sort = "CodRegion";
            //dvRegiones.Table.Rows[0].Delete();
            
            DataView dvEstadoCivil = new DataView(GetparEstadoCivil());
            DataView dt = new DataView(SQL_GetDatosPersonalesNino(SSninoDiag.CodNino.ToString()));
            DataView dtDireccionNino = new DataView(SQL_GetDireccionNino(SSninoDiag.CodNino.ToString()));

           

            for (int i = 0; i < dvNacionalidad.Count; i++)
            {
                if (dvNacionalidad.Table.Rows[i]["CodNacionalidad"].ToString() == dt.Table.Rows[0]["CodNacionalidad"].ToString())
                {
                    txtNacionalidad.Text = dvNacionalidad.Table.Rows[i]["Descripcion"].ToString();

                }
            }


            ViewState["Sexo"] = dt.Table.Rows[0]["Sexo"].ToString();

            if (dt.Table.Rows[0]["Sexo"].ToString() == "F")
            {
                txtSexo.Text = "Femenino";

                thGenitales.Visible = false;
                tdGenitales.Visible = false;

                thEvaluacionGenitales.Visible = false;
                tdEvaluacionGenitales.Visible = false;

                thAbortos.Visible = true;
                tdAbortos.Visible = true;

                thFur.Visible = true;
                tdFur.Visible = true;

                thFO.Visible = true;
                tdFO.Visible = true;

                thCiclos.Visible = true;
                tdCiclos.Visible = true;

                thMenarquia.Visible = true;
                tdMenarquia.Visible = true;

                lblAlertaSinPMaternidad.Text = "No se Encontraron Registros de Maternidad Adolescente";

                thMaternidadAdolescente.Visible = true;

            }
            if (dt.Table.Rows[0]["Sexo"].ToString() == "M")
            {
                txtSexo.Text = "Masculino";

                thGenitales.Visible = true;
                tdGenitales.Visible = true;

                thEvaluacionGenitales.Visible = true;
                tdEvaluacionGenitales.Visible = true;

                thAbortos.Visible = false;
                tdAbortos.Visible = false;

                thFur.Visible = false;
                tdFur.Visible = false;

                thFO.Visible = false;
                tdFO.Visible = false;

                thCiclos.Visible = false;
                tdCiclos.Visible = false;

                thMenarquia.Visible = false;
                tdMenarquia.Visible = false;

                lblAlertaSinPMaternidad.Text = "No se Encontraron Registros de Paternidad Adolescente";

                thPaternidadAdolescente.Visible = true;
            }

            DataTable dtAntecedentesMaternidad = GetAntecedentesMaternidad(Convert.ToInt32(SSninoDiag.ICodIE));

            if (dtAntecedentesMaternidad.Rows.Count > 0)
            {
                trPMaternidadAdolescente.Visible = true;
                grdPMaternidadAdolescente.DataSource = dtAntecedentesMaternidad;
                grdPMaternidadAdolescente.DataBind();
                trAlertaSinPMaternidad.Visible = false;
            }
            else
            {
                trPMaternidadAdolescente.Visible = false;
                trAlertaSinPMaternidad.Visible = true;
            }



            for (int i = 0; i < dvEtnia.Count; i++)
            {
                if (dvEtnia.Table.Rows[i]["CodEtnia"].ToString() == dt.Table.Rows[0]["CodEtnia"].ToString())
                {
                    if (dvEtnia.Table.Rows[i]["CodEtnia"].ToString() != "0")
                    {
                        txtEtnia.Text = dvEtnia.Table.Rows[i]["Descripcion"].ToString();
                    }
                }
            }



            for (int i = 0; i < dvEstadoCivil.Count; i++)
            {
                if (dvEstadoCivil.Table.Rows[i]["CodEstadoCivil"].ToString() == dt.Table.Rows[0]["CodEstadoCivil"].ToString())
                {
                    if (dvEstadoCivil.Table.Rows[i]["CodEstadoCivil"].ToString() != "0")
                    {
                        txtEstadoCivil.Text = dvEstadoCivil.Table.Rows[i]["Descripcion"].ToString();
                    }
                }
            }

            if (dtDireccionNino.Count > 0)
            {

                txtDomicilio.Text = dtDireccionNino.Table.Rows[0]["Direccion"].ToString();

                if (dtDireccionNino.Table.Rows[0]["Direccion"].ToString() == "")
                {
                    txtDomicilio.Text = "NO TIENE DOMICILIO REGISTRADO";
                }

                txtComuna.Text = dtDireccionNino.Table.Rows[0]["DescripcionComuna"].ToString();


                for (int i = 1; i < dvRegiones.Count; i++)
                {
                    if (dvRegiones.Table.Rows[i]["CodRegion"].ToString() == dtDireccionNino.Table.Rows[0]["CodRegion"].ToString())
                    {
                        if (dvRegiones.Table.Rows[i]["CodRegion"].ToString() != "0")
                        {
                            txtRegion.Text = dvRegiones.Table.Rows[i]["Descripcion"].ToString();
                        }
                    }
                }

            }            
            
            ddlRegionEstablecimiento.DataSource = dvRegiones;
            ddlRegionEstablecimiento.DataTextField = "Descripcion";
            ddlRegionEstablecimiento.DataValueField = "CodRegion";
            dvRegiones.Sort = "Descripcion";
            dvRegiones.RowFilter = "CodRegion <> -2 and CodRegion <> -1 and CodRegion <> 16 ";
            ddlRegionEstablecimiento.DataBind();

            DataView dvAntecedentesMorbidos = new DataView(GetparAntecedentesMorbidos());
            ddlAntecedentesMorbidos.DataSource = dvAntecedentesMorbidos;
            ddlAntecedentesMorbidos.DataTextField = "Descripcion";
            ddlAntecedentesMorbidos.DataValueField = "CodAntecedenteMorbido";
            dvAntecedentesMorbidos.Sort = "Descripcion";
            ddlAntecedentesMorbidos.DataBind();

            DataView dvFarmacos = new DataView(GetparFarmacos());
            ddlFarmacos.DataSource = dvFarmacos;
            ddlFarmacos.DataTextField = "Descripcion";
            ddlFarmacos.DataValueField = "CodFarmaco";
            dvFarmacos.Sort = "Descripcion";
            ddlFarmacos.DataBind();

            //for (int i = 1; i < 51; i++)
            //{
            //    ListItem Dosis = new ListItem(i.ToString(), i.ToString());
            //    ddlDosisFarmacos.Items.Add(Dosis);
            //}

            //DataView dvUnidadFarmacos = new DataView(GetparParametricasFichaSalud(querytype.Unidad_Farmacos));
            //ddlUnidadFarmacos.DataSource = dvUnidadFarmacos;
            //ddlUnidadFarmacos.DataTextField = "Descripcion";
            //ddlUnidadFarmacos.DataValueField = "CodParametrica";
            //dvUnidadFarmacos.Sort = "CodParametrica";
            //ddlUnidadFarmacos.DataBind();

            DataView dvPresentacionFarmacos = new DataView(GetparParametricasFichaSalud(querytype.Presentacion_Farmacos));
            ddlPresentacionFarmaco.DataSource = dvPresentacionFarmacos;
            ddlPresentacionFarmaco.DataTextField = "Descripcion";
            ddlPresentacionFarmaco.DataValueField = "CodParametrica";
            dvPresentacionFarmacos.Sort = "CodParametrica";
            ddlPresentacionFarmaco.DataBind();

            for (int i = 31; i < 161; i++)
            {
                ListItem PerimetroCintura = new ListItem(i.ToString(), i.ToString());
                ddlPerimetroCintura.Items.Add(PerimetroCintura);
            }


            for (int i = 31; i < 71; i++)
            {
                ListItem PerimetroCraneo = new ListItem(i.ToString(), i.ToString());
                ddlPerimetroCraneano.Items.Add(PerimetroCraneo);
            }

            DataView dvAlergias = new DataView(GetparAlergias());
            ddlAlergias.DataSource = dvAlergias;
            ddlAlergias.DataTextField = "Descripcion";
            ddlAlergias.DataValueField = "CodAlergia";
            dvAlergias.Sort = "Descripcion";
            ddlAlergias.DataBind();

            DataView dvAntecedentesGinecoO = new DataView(GetparParametricasFichaSalud(querytype.Antecedentes_Gineco_Obstetricos));
            ddlAntecedentesGinecoO.DataSource = dvAntecedentesGinecoO;
            ddlAntecedentesGinecoO.DataTextField = "Descripcion";
            ddlAntecedentesGinecoO.DataValueField = "CodParametrica";
            dvAntecedentesGinecoO.Sort = "CodParametrica";
            ddlAntecedentesGinecoO.DataBind();

            DataView dvAntecedentesFamiliares = new DataView(GetparParametricasFichaSalud(querytype.Antecedentes_Familiares));
            ddlAntecedentesFamiliares.DataSource = dvAntecedentesFamiliares;
            ddlAntecedentesFamiliares.DataTextField = "Descripcion";
            ddlAntecedentesFamiliares.DataValueField = "CodParametrica";
            dvAntecedentesFamiliares.Sort = "CodParametrica";
            ddlAntecedentesFamiliares.DataBind();


            DataView dvTrastornos = new DataView(GetparParametricasFichaSalud(querytype.Trastornos));
            ddlTrastornos.DataSource = dvTrastornos;
            ddlTrastornos.DataTextField = "Descripcion";
            ddlTrastornos.DataValueField = "CodParametrica";
            dvTrastornos.Sort = "CodParametrica";
            ddlTrastornos.DataBind();

            DataView dvSindromes = new DataView(GetparParametricasFichaSalud(querytype.Sindromes));
            ddlSindromes.DataSource = dvSindromes;
            ddlSindromes.DataTextField = "Descripcion";
            ddlSindromes.DataValueField = "CodParametrica";
            dvSindromes.Sort = "CodParametrica";
            ddlSindromes.DataBind();

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
            dvTemperatura.Sort = "Descripcion ASC";
            ddlTemperatura.DataBind();

            DataView dvMovilidad = new DataView(GetparParametricasFichaSalud(querytype.Movilidad));
            ddlMovilidad.DataSource = dvMovilidad;
            ddlMovilidad.DataTextField = "Descripcion";
            ddlMovilidad.DataValueField = "CodParametrica";
            dvMovilidad.Sort = "CodParametrica";
            ddlMovilidad.DataBind();

            DataView dvTallaEdad = new DataView(GetparParametricasFichaSalud(querytype.Talla_Edad));
            ddlTallaEdad.DataSource = dvTallaEdad;
            ddlTallaEdad.DataTextField = "Descripcion";
            ddlTallaEdad.DataValueField = "CodParametrica";
            dvTallaEdad.Sort = "CodParametrica";
            ddlTallaEdad.DataBind();

            DataView dvDesarrolloCognitivo = new DataView(GetparParametricasFichaSalud(querytype.Desarrollo_Cognitivo));
            ddlDesarrolloCognitivo.DataSource = dvDesarrolloCognitivo;
            ddlDesarrolloCognitivo.DataTextField = "Descripcion";
            ddlDesarrolloCognitivo.DataValueField = "CodParametrica";
            dvDesarrolloCognitivo.Sort = "CodParametrica";
            ddlDesarrolloCognitivo.DataBind();

            DataView dvComunicacion = new DataView(GetparParametricasFichaSalud(querytype.Comunicacion));
            ddlComunicacion.DataSource = dvComunicacion;
            ddlComunicacion.DataTextField = "Descripcion";
            ddlComunicacion.DataValueField = "CodParametrica";
            dvComunicacion.Sort = "CodParametrica";
            ddlComunicacion.DataBind();

            DataView dvDesarrolloSocioEmocional = new DataView(GetparParametricasFichaSalud(querytype.Desarrollo_Socio_Emocional));
            ddlDesarrolloSocioEmocional.DataSource = dvDesarrolloSocioEmocional;
            ddlDesarrolloSocioEmocional.DataTextField = "Descripcion";
            ddlDesarrolloSocioEmocional.DataValueField = "CodParametrica";
            dvDesarrolloSocioEmocional.Sort = "CodParametrica";
            ddlDesarrolloSocioEmocional.DataBind();

            DataView dvGradosTunner = new DataView(GetparParametricasFichaSalud(querytype.Grados_de_Tunner));
            ddlGradosTunner.DataSource = dvGradosTunner;
            ddlGradosTunner.DataTextField = "Descripcion";
            ddlGradosTunner.DataValueField = "CodParametrica";
            dvGradosTunner.Sort = "CodParametrica";
            ddlGradosTunner.DataBind();

            DataView dvEvaluacionOrtopedica = new DataView(GetparParametricasFichaSalud(querytype.Evaluación_Ortopedica));
            ddlEvaluacionOrtopedica.DataSource = dvEvaluacionOrtopedica;
            ddlEvaluacionOrtopedica.DataTextField = "Descripcion";
            ddlEvaluacionOrtopedica.DataValueField = "CodParametrica";
            dvEvaluacionOrtopedica.Sort = "CodParametrica";
            ddlEvaluacionOrtopedica.DataBind();

            DataView dvDisplaciaCadera = new DataView(GetparParametricasFichaSalud(querytype.Displacia_de_Cadera));
            ddlDisplaciaCadera.DataSource = dvDisplaciaCadera;
            ddlDisplaciaCadera.DataTextField = "Descripcion";
            ddlDisplaciaCadera.DataValueField = "CodParametrica";
            dvDisplaciaCadera.Sort = "CodParametrica";
            ddlDisplaciaCadera.DataBind();

            DataView dvColor = new DataView(GetparParametricasFichaSalud(querytype.Color));
            ddlColor.DataSource = dvColor;
            ddlColor.DataTextField = "Descripcion";
            ddlColor.DataValueField = "CodParametrica";
            dvColor.Sort = "CodParametrica";
            ddlColor.DataBind();

            DataView dvHumedad = new DataView(GetparParametricasFichaSalud(querytype.Humedad));
            ddlHumedad.DataSource = dvHumedad;
            ddlHumedad.DataTextField = "Descripcion";
            ddlHumedad.DataValueField = "CodParametrica";
            dvHumedad.Sort = "CodParametrica";
            ddlHumedad.DataBind();

            DataView dvCabeza = new DataView(GetparParametricasFichaSalud(querytype.Cabeza));
            ddlCabeza.DataSource = dvCabeza;
            ddlCabeza.DataTextField = "Descripcion";
            ddlCabeza.DataValueField = "CodParametrica";
            dvCabeza.Sort = "CodParametrica";
            ddlCabeza.DataBind();

            DataView dvEstadoNutricional = new DataView(GetparParametricasFichaSalud(querytype.Estado_Nutricional));
            ddlEstadoNutricional.DataSource = dvEstadoNutricional;
            ddlEstadoNutricional.DataTextField = "Descripcion";
            ddlEstadoNutricional.DataValueField = "CodParametrica";
            dvEstadoNutricional.Sort = "CodParametrica";
            ddlEstadoNutricional.DataBind();

            DataView dvCuello = new DataView(GetparParametricasFichaSalud(querytype.Cuello));
            ddlCuello.DataSource = dvCuello;
            ddlCuello.DataTextField = "Descripcion";
            ddlCuello.DataValueField = "CodParametrica";
            dvCuello.Sort = "CodParametrica";
            ddlCuello.DataBind();

            DataView dvTorax = new DataView(GetparParametricasFichaSalud(querytype.Torax));
            ddlTorax.DataSource = dvTorax;
            ddlTorax.DataTextField = "Descripcion";
            ddlTorax.DataValueField = "CodParametrica";
            dvTorax.Sort = "CodParametrica";
            ddlTorax.DataBind();

            DataView dvAbdomen = new DataView(GetparParametricasFichaSalud(querytype.Abdomen));
            ddlAbdomen.DataSource = dvAbdomen;
            ddlAbdomen.DataTextField = "Descripcion";
            ddlAbdomen.DataValueField = "CodParametrica";
            dvAbdomen.Sort = "CodParametrica";
            ddlAbdomen.DataBind();

            DataView dvExtremidades = new DataView(GetparParametricasFichaSalud(querytype.Extremidades));
            ddlExtremidades.DataSource = dvExtremidades;
            ddlExtremidades.DataTextField = "Descripcion";
            ddlExtremidades.DataValueField = "CodParametrica";
            dvExtremidades.Sort = "CodParametrica";
            ddlExtremidades.DataBind();

            DataView dvSintomaExtremidades = new DataView(GetparParametricasFichaSalud(querytype.Sintoma_Extremidades));
            ddlSintomaExtremidades.DataSource = dvSintomaExtremidades;
            ddlSintomaExtremidades.DataTextField = "Descripcion";
            ddlSintomaExtremidades.DataValueField = "CodParametrica";
            dvSintomaExtremidades.Sort = "CodParametrica";
            ddlSintomaExtremidades.DataBind();

            DataView dvGenitales = new DataView(GetparParametricasFichaSalud(querytype.Genitales));
            ddlGenitales.DataSource = dvGenitales;
            ddlGenitales.DataTextField = "Descripcion";
            ddlGenitales.DataValueField = "CodParametrica";
            dvGenitales.Sort = "CodParametrica";
            ddlGenitales.DataBind();

            DataView dvMarcha = new DataView(GetparParametricasFichaSalud(querytype.Marcha));
            ddlMarcha.DataSource = dvMarcha;
            ddlMarcha.DataTextField = "Descripcion";
            ddlMarcha.DataValueField = "CodParametrica";
            dvMarcha.Sort = "CodParametrica";
            ddlMarcha.DataBind();

            DataView dvEvaluacionGenitales = new DataView(GetparParametricasFichaSalud(querytype.Eval_Genitales));
            ddlEvaluacionGenitales.DataSource = dvEvaluacionGenitales;
            ddlEvaluacionGenitales.DataTextField = "Descripcion";
            ddlEvaluacionGenitales.DataValueField = "CodParametrica";
            dvEvaluacionGenitales.Sort = "CodParametrica";
            ddlEvaluacionGenitales.DataBind();

            DataView dvVision = new DataView(GetparParametricasFichaSalud(querytype.Vision));
            ddlVision.DataSource = dvVision;
            ddlVision.DataTextField = "Descripcion";
            ddlVision.DataValueField = "CodParametrica";
            dvVision.Sort = "CodParametrica";
            ddlVision.DataBind();

            DataView dvAudicion = new DataView(GetparParametricasFichaSalud(querytype.Audicion));
            ddlAudicion.DataSource = dvAudicion;
            ddlAudicion.DataTextField = "Descripcion";
            ddlAudicion.DataValueField = "CodParametrica";
            dvAudicion.Sort = "CodParametrica";
            ddlAudicion.DataBind();

            DataView dvSaludBucal = new DataView(GetparParametricasFichaSalud(querytype.Salud_Bucal));
            ddlSaludBucal.DataSource = dvSaludBucal;
            ddlSaludBucal.DataTextField = "Descripcion";
            ddlSaludBucal.DataValueField = "CodParametrica";
            dvSaludBucal.Sort = "CodParametrica";
            ddlSaludBucal.DataBind();

            DataView dvColumna = new DataView(GetparParametricasFichaSalud(querytype.Columna));
            ddlColumna.DataSource = dvColumna;
            ddlColumna.DataTextField = "Descripcion";
            ddlColumna.DataValueField = "CodParametrica";
            dvColumna.Sort = "CodParametrica";
            ddlColumna.DataBind();

            DataView dvTipoExamen = new DataView(GetparTipoExamen());
            ddlTipoExamen.DataSource = dvTipoExamen;
            ddlTipoExamen.DataTextField = "Descripcion";
            ddlTipoExamen.DataValueField = "CodTipoExamen";
            dvTipoExamen.Sort = "CodTipoExamen";
            ddlTipoExamen.DataBind();

            DataView dvConductaSexual = new DataView(GetparParametricasFichaSalud(querytype.Conducta_Sexual));
            ddlConductaSexual.DataSource = dvConductaSexual;
            ddlConductaSexual.DataTextField = "Descripcion";
            ddlConductaSexual.DataValueField = "CodParametrica";
            dvConductaSexual.Sort = "CodParametrica";
            ddlConductaSexual.DataBind();
        }
    }


    public DataTable GetDiagnosticoDroga(int ICodIE)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select T2.FechaDiagnostico,T3.Descripcion, T4.Descripcion as TipoConsumo, (Paterno +' '+ Materno +' '+ Nombres) AS NombreCompleto, T2.Observacion as Observaciones " +
                            "From DiagnosticoGeneral T1 Inner Join DiagnosticosDroga T2 On  T1.CodDiagnostico = T2.CodDiagnostico Inner Join parDrogas T3 On T2.CodDroga = T3.CodDroga " +
                            "inner join parTipoConsumoDroga T4 on T4.TipoConsumoDroga = T2.TipoConsumoDroga inner join Trabajadores T5 On T5.IcodTrabajador = T2.IcodTrabajador " +
                            "WHERE T1.CodTipoDiagnosticoGlosa = 3 And T1.ICodIE = @IcodIE Order by T2.FechaDiagnostico desc";
  
        sqlc.Parameters.AddWithValue("@ICodIE", ICodIE);       
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();        
        return dt;
    }

    public bool ExisteDerivacionFichaSalud(SqlTransaction sqlt, int CodFichaSaludInicial, string TipoDerivacion)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        //sqlc.CommandText = "select InstitucionQueDeriva, CodRegionInstitucionQueDeriva, InstitucionALaQueDeriva, CodRegionInstitucionALaQueDeriva, PrimerApellido, SegundoApellido, " +
        //                        "Nombre, Rut, Cargo, Telefono, CorreoElectronico from FichaDerivacion where CodFichaSaludInicial = @CodFichaSaludInicial ";

        sqlc.CommandText = "select CodFichaSaludInicialDerivacion from FichaDerivacion where CodFichaSaludInicial = @CodFichaSaludInicial ";

        if (TipoDerivacion == "Vision")
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 1";
        }

        if (TipoDerivacion == "Audicion")
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 2";
        }
        if (TipoDerivacion == "SaludBucal")
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 3";
        }
        if (TipoDerivacion == "Columna")
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 4";
        }

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }


    public int GetRegionEstablecimiento(int CodEstablecimiento)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodRegion FROM parEstablecimientosSalud where CodEstablecimiento = @CodEstablecimiento";

        sqlc.Parameters.AddWithValue("@CodEstablecimiento", CodEstablecimiento);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();

        if (dt.Rows.Count > 0)
        {
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        else
            return 0;
    }


    public DataTable SQL_GetDatosPersonalesNino(string codnino)
    {       

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodNino, FechaAdoptabilidad, IdentidadConfirmada, Rut, Sexo, Nombres, Apellido_Paterno, Apellido_Materno, FechaNacimiento, CodNacionalidad," + 
                            "CodEtnia, OficinaInscripcion, AnoInscripcion, NumeroInscripcionCivil, AlergiasConocidas, InscritoFONADIS, InscritoFONASA, NinoSuceptibleAdopcion," +
                            "EstadoGestacion, FechaActualizacion, IdUsuarioActualizacion , MuestraADN, CodTipoUsuario, CodConfirmaSRCEI, CodEstadoCivil, FechaDefuncion," +
                            "CodTipoNacionalidad FROM Ninos where CodNino = @CodNino";    
  
        sqlc.Parameters.AddWithValue("@CodNino", codnino);       
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();        
        return dt;
    }


    public DataTable SQL_GetDireccionNino(string codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT TOP (1) T1.ICodDireccion, T1.ICodIE, T1.CodProyecto, T1.CodNino, T1.FechaIngresoDireccion, T1.Direccion, T1.Telefono, T1.TelefonoRecado, T1.Mail, T1.Fax, T1.CodigoPostal," +
                            "T1.CodComuna, (select Descripcion from parComunas where CodComuna =  T1.CodComuna) as DescripcionComuna," +
                            "(select CodRegion from parProvincia where CodProvincia = (select CodProvincia from parComunas where CodComuna =  T1.CodComuna)) as CodRegion, AlIngreso, FechaActualizacion, " +
                            " IdUsuarioActualizacion, IndVigencia FROM DireccionNinos T1 WHERE CodNino = @CodNino order by FechaActualizacion DESC ";
        sqlc.Parameters.AddWithValue("@CodNino", codnino);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }
    
    public DataTable GetparEstadoCivil()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodEstadoCivil, Descripcion FROM parEstadoCivil WHERE (IndVigencia = 'V')";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparAntecedentesMorbidos()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodAntecedenteMorbido, Descripcion + ' - ' + Codigo  as Descripcion FROM parAntecedentesMorbidos WHERE (IndVigencia = 'V')";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparEstablecimientosSalud(int CodRegionEstablecimiento)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodEstablecimiento, Descripcion FROM parEstablecimientosSalud WHERE CodRegion = @CodRegionEstablecimiento and IndVigencia = 'V'";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodRegionEstablecimiento", SqlDbType.Int, 4, CodRegionEstablecimiento));

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparFarmacos()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodFarmaco, Descripcion FROM parFarmacos WHERE (IndVigencia = 'V')";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparAlergias()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodAlergia, Descripcion FROM parAlergias WHERE (IndVigencia = 'V')";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }


    public DataTable GetparTipoExamen()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodTipoExamen, Descripcion FROM parTipoExamen WHERE (IndVigencia = 'V')";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparExamen(int codTipoExamen)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodExamen, Descripcion FROM parExamen WHERE (IndVigencia = 'V') and CodTipoExamen = @codTipoExamen";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@codTipoExamen", SqlDbType.Int, 4, codTipoExamen));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparParametricasFichaSalud(querytype TipoParametrica)
    {        
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodParametrica, T1.descripcion from parParametricasFichaSalud T1 inner join parTipoParametricaFichaSalud T2 on T1.CodTipoParametrica = T2.CodTipoParametrica where T1.vigencia = 'V' and T2.descripcion = @TipoParametrica";
        
        if (TipoParametrica == querytype.Estado_Nutricional)
        {
            int edad = Convert.ToInt32((DateTime.Now.Year - SSninoDiag.FechaNacimiento.Year).ToString());
            if (edad < 14)
            {
                sqlc.CommandText = sqlc.CommandText + " and T1.CodParametrica between 61 and 64";
            }
            else if (edad >= 14)
            {
                sqlc.CommandText = sqlc.CommandText + " and T1.CodParametrica > 64";
            }
        }
        sqlc.Parameters.Add("@TipoParametrica", SqlDbType.VarChar, 50).Value = Convert.ToString(TipoParametrica);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    private void UpdateFichaSalud(SqlTransaction sqlt,
        int CodDiagnostico,
        DateTime FechaDiagnostico,
        DateTime FechaIntervencion,
        DateTime FechaEvaluacion,
        string Antecedentes_Quirurgicos_Hospitalizacion,
        int Transfusiones,
        int Antecedentes_Gineco_Obstetricos,
        int Antecedentes_Familiares,
        int PA,
        int Pulso,
        int FR,
        int T,
        int Tranquilo,
        int Excitado,
        int Angustiado,
        int Decaido,
        int Irritable,
        int Movilidad,
        int Peso,
        int Talla,
        string IMC,
        int PerimetroCintura,
        int PerimetroCraneano,
        int TallaEdad,
        string PesoTalla,
        string PesoEdad,
        int EstadoNutricional,
        int DesarrolloCognitivo,
        int Comunicacion,
        int DesarrolloSocioEmocional,
        DateTime ProximoControl,
        int GradosTunner,
        int EvaluacionOrtopedica,
        int DisplaciaCadera,
        int Color,
        int Humedad,
        int Cabeza,
        int Cuello,
        int Torax,
        int Abdomen,
        int Extremidades,
        int Sintoma,
        int Genitales,
        int GenuValgo,
        int GenuVaro,
        int PiePlano,
        int Marcha,
        int Vision,
        int Lentes,
        int Audicion,
        int Audifonos,
        int SaludBucal,
        int Ortodoncia,
        int Columna,
        //int TipoExamen,
        //string Examen,
        int ConductaSexual,
        DateTime Menarquia,
        int Ciclos,
        string FO,
        int Abortos,
        DateTime FUR,
        //int IntentoSuicida,
        int IdeacionSuicida,
        string HistoriaClinicaEvolutiva,
        DateTime FechaActualizacion,
        //int IdUsuarioIngresoFicha
        int PresumeConsumoDroga,
        bool FichaCompleta,
        int VacunasAlDia,
        int InscritoAtencionPrimaria,
        int CodEstablecimiento
        ) 

    {        
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Update_FichaSaludInicial", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;          

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaIntervencion", SqlDbType.DateTime, 16, FechaIntervencion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaEvaluacion", SqlDbType.DateTime, 16, FechaEvaluacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Antecedentes_Quirurgicos_Hospitalizacion", SqlDbType.VarChar, 140, Antecedentes_Quirurgicos_Hospitalizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Transfusiones", SqlDbType.Int, 1, Transfusiones));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Antecedentes_Gineco_Obstetricos", SqlDbType.Int, 4, Antecedentes_Gineco_Obstetricos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Antecedentes_Familiares", SqlDbType.Int, 4, Antecedentes_Familiares));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PA", SqlDbType.Int, 4, PA));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Pulso", SqlDbType.Int, 4, Pulso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FR", SqlDbType.Int, 4, FR));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@T", SqlDbType.Int, 4, T));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tranquilo", SqlDbType.Int, 1, Tranquilo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Excitado", SqlDbType.Int, 1, Excitado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Angustiado", SqlDbType.Int, 1, Angustiado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Decaido", SqlDbType.Int, 1, Decaido));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Irritable", SqlDbType.Int, 1, Irritable));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Movilidad", SqlDbType.Int, 4, Movilidad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Peso", SqlDbType.Int, 4, Peso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Talla", SqlDbType.Int, 4, Talla));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IMC", SqlDbType.VarChar,8, IMC));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PerimetroCintura", SqlDbType.Int, 4, PerimetroCintura));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PerimetroCraneano", SqlDbType.Int, 4, PerimetroCraneano));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@TallaEdad", SqlDbType.Int, 4, TallaEdad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PesoTalla", SqlDbType.VarChar, 8, PesoTalla));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PesoEdad", SqlDbType.VarChar, 5, PesoEdad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@EstadoNutricional", SqlDbType.Int, 4, EstadoNutricional));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DesarrolloCognitivo", SqlDbType.Int, 4, DesarrolloCognitivo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Comunicacion", SqlDbType.Int, 4, Comunicacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DesarrolloSocioEmocional", SqlDbType.Int, 4, DesarrolloSocioEmocional));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ProximoControl", SqlDbType.DateTime, 16, ProximoControl));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@GradosTunner", SqlDbType.Int, 4, GradosTunner));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@EvaluacionOrtopedica", SqlDbType.Int, 4, EvaluacionOrtopedica));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DisplaciaCadera", SqlDbType.Int, 4, DisplaciaCadera));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Color", SqlDbType.Int, 4, Color));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Humedad", SqlDbType.Int, 4, Humedad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Cabeza", SqlDbType.Int, 4, Cabeza));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Cuello", SqlDbType.Int, 4, Cuello));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Torax", SqlDbType.Int, 4, Torax));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Abdomen", SqlDbType.Int, 4, Abdomen));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Extremidades", SqlDbType.Int, 4, Extremidades));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Sintoma", SqlDbType.Int, 4, Sintoma));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Genitales", SqlDbType.Int, 4, Genitales));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@GenuValgo", SqlDbType.Int, 1, GenuValgo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@GenuVaro", SqlDbType.Int, 1, GenuVaro));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PiePlano", SqlDbType.Int, 1, PiePlano));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Marcha", SqlDbType.Int, 4, Marcha));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Vision", SqlDbType.Int, 4, Vision));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Lentes", SqlDbType.Int, 1, Lentes));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Audicion", SqlDbType.Int, 4, Audicion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Audifonos", SqlDbType.Int, 1, Audifonos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@SaludBucal", SqlDbType.Int, 4, SaludBucal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Ortodoncia", SqlDbType.Int, 1, Ortodoncia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Columna", SqlDbType.Int, 4, Columna));        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ConductaSexual", SqlDbType.Int, 4, ConductaSexual));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Menarquia", SqlDbType.DateTime, 16, Menarquia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Ciclos", SqlDbType.Int, 4, Ciclos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FO", SqlDbType.VarChar, 9, FO));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Abortos", SqlDbType.Int, 1, Abortos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FUR", SqlDbType.DateTime, 16, FUR));        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdeacionSuicida", SqlDbType.Int, 1, IdeacionSuicida));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@HistoriaClinicaEvolutiva", SqlDbType.VarChar, 1000, HistoriaClinicaEvolutiva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PresumeConsumoDroga", SqlDbType.Int, 1, PresumeConsumoDroga));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FichaCompleta", SqlDbType.Bit, 1, FichaCompleta));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@VacunasAlDia", SqlDbType.Int, 1, VacunasAlDia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InscritoAtencionPrimaria", SqlDbType.Int, 1, InscritoAtencionPrimaria));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodEstablecimiento", SqlDbType.Int, 1, CodEstablecimiento));  
        
        sqlc.ExecuteNonQuery();
        
        
    }

    private int InsertFichaSaludInicial(SqlTransaction sqlt,
        int CodDiagnostico,
        DateTime FechaDiagnostico,
        DateTime FechaIntervencion,
        DateTime FechaEvaluacion,
        string Antecedentes_Quirurgicos_Hospitalizacion,
        int Transfusiones,
        int Antecedentes_Gineco_Obstetricos,
        int Antecedentes_Familiares,
        int PA,
        int Pulso,
        int FR,
        int T,
        int Tranquilo,
        int Excitado,
        int Angustiado,
        int Decaido,
        int Irritable,
        int Movilidad,
        int Peso,
        int Talla,
        string IMC,
        int PerimetroCintura,
        int PerimetroCraneano,
        int TallaEdad,
        string PesoTalla,
        string PesoEdad,
        int EstadoNutricional,
        int DesarrolloCognitivo,
        int Comunicacion,
        int DesarrolloSocioEmocional,
        DateTime ProximoControl,
        int GradosTunner,
        int EvaluacionOrtopedica,
        int DisplaciaCadera,
        int Color,
        int Humedad,
        int Cabeza,
        int Cuello,
        int Torax,
        int Abdomen,
        int Extremidades,
        int Sintoma,
        int Genitales,
        int GenuValgo,
        int GenuVaro,
        int PiePlano,
        int Marcha,
        int Vision,
        int Lentes,
        int Audicion,
        int Audifonos,
        int SaludBucal,
        int Ortodoncia,
        int Columna,        
        int ConductaSexual,
        DateTime Menarquia,
        int Ciclos,
        string FO,
        int Abortos,
        DateTime FUR,
        //int IntentoSuicida,
        int IdeacionSuicida,
        string HistoriaClinicaEvolutiva,
        DateTime FechaActualizacion,
        int IdUsuarioIngresoFicha,
        DateTime FechaIngresoFicha,
        int PresumeConsumoDroga,
        bool FichaCompleta,
        int VacunasAlDia,
        int InscritoAtencionPrimaria,
        int CodEstablecimiento
        ) 
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_FichaSaludInicial", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;  

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaDiagnostico", SqlDbType.DateTime, 16, FechaDiagnostico));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaIntervencion", SqlDbType.DateTime, 16, FechaIntervencion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaEvaluacion", SqlDbType.DateTime, 16, FechaEvaluacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Antecedentes_Quirurgicos_Hospitalizacion", SqlDbType.VarChar, 140, Antecedentes_Quirurgicos_Hospitalizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Transfusiones", SqlDbType.Int, 1, Transfusiones));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Antecedentes_Gineco_Obstetricos", SqlDbType.Int, 4, Antecedentes_Gineco_Obstetricos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Antecedentes_Familiares", SqlDbType.Int, 4, Antecedentes_Familiares));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PA", SqlDbType.Int, 4, PA));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Pulso", SqlDbType.Int, 4, Pulso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FR", SqlDbType.Int, 4, FR));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@T", SqlDbType.Int, 4, T));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tranquilo", SqlDbType.Int, 1, Tranquilo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Excitado", SqlDbType.Int, 1, Excitado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Angustiado", SqlDbType.Int, 1, Angustiado));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Decaido", SqlDbType.Int, 1, Decaido));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Irritable", SqlDbType.Int, 1, Irritable));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Movilidad", SqlDbType.Int, 4, Movilidad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Peso", SqlDbType.Int, 4, Peso));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Talla", SqlDbType.Int, 4, Talla));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IMC", SqlDbType.VarChar,9, IMC));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PerimetroCintura", SqlDbType.Int, 4, PerimetroCintura));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PerimetroCraneano", SqlDbType.Int, 4, PerimetroCraneano));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@TallaEdad", SqlDbType.Int, 4, TallaEdad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PesoTalla", SqlDbType.VarChar, 8, PesoTalla));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PesoEdad", SqlDbType.VarChar, 5, PesoEdad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@EstadoNutricional", SqlDbType.Int, 4, EstadoNutricional));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DesarrolloCognitivo", SqlDbType.Int, 4, DesarrolloCognitivo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Comunicacion", SqlDbType.Int, 4, Comunicacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DesarrolloSocioEmocional", SqlDbType.Int, 4, DesarrolloSocioEmocional));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ProximoControl", SqlDbType.DateTime, 16, ProximoControl));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@GradosTunner", SqlDbType.Int, 4, GradosTunner));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@EvaluacionOrtopedica", SqlDbType.Int, 4, EvaluacionOrtopedica));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@DisplaciaCadera", SqlDbType.Int, 4, DisplaciaCadera));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Color", SqlDbType.Int, 4, Color));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Humedad", SqlDbType.Int, 4, Humedad));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Cabeza", SqlDbType.Int, 4, Cabeza));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Cuello", SqlDbType.Int, 4, Cuello));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Torax", SqlDbType.Int, 4, Torax));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Abdomen", SqlDbType.Int, 4, Abdomen));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Extremidades", SqlDbType.Int, 4, Extremidades));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Sintoma", SqlDbType.Int, 4, Sintoma));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Genitales", SqlDbType.Int, 4, Genitales));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@GenuValgo", SqlDbType.Int, 1, GenuValgo));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@GenuVaro", SqlDbType.Int, 1, GenuVaro));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PiePlano", SqlDbType.Int, 1, PiePlano));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Marcha", SqlDbType.Int, 4, Marcha));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Vision", SqlDbType.Int, 4, Vision));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Lentes", SqlDbType.Int, 1, Lentes));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Audicion", SqlDbType.Int, 4, Audicion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Audifonos", SqlDbType.Int, 1, Audifonos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@SaludBucal", SqlDbType.Int, 4, SaludBucal));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Ortodoncia", SqlDbType.Int, 1, Ortodoncia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Columna", SqlDbType.Int, 4, Columna));       
        sqlc.Parameters.Add(Conexiones.CrearParametro("@ConductaSexual", SqlDbType.Int, 4, ConductaSexual));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Menarquia", SqlDbType.DateTime, 16, Menarquia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Ciclos", SqlDbType.Int, 4, Ciclos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FO", SqlDbType.VarChar, 9, FO));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Abortos", SqlDbType.Int, 1, Abortos));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FUR", SqlDbType.DateTime, 16, FUR));        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdeacionSuicida", SqlDbType.Int, 1, IdeacionSuicida));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@HistoriaClinicaEvolutiva", SqlDbType.VarChar, 1000, HistoriaClinicaEvolutiva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuarioIngresoFicha", SqlDbType.Int, 4, IdUsuarioIngresoFicha));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaIngresoFicha", SqlDbType.DateTime, 16, FechaIngresoFicha));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@PresumeConsumoDroga", SqlDbType.Int, 1, PresumeConsumoDroga));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FichaCompleta", SqlDbType.Bit, 1, FichaCompleta));  
        sqlc.Parameters.Add(Conexiones.CrearParametro("@VacunasAlDia", SqlDbType.Int, 1, VacunasAlDia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InscritoAtencionPrimaria", SqlDbType.Int, 1, InscritoAtencionPrimaria));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodEstablecimiento", SqlDbType.Int, 1, CodEstablecimiento));  
        
        returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());

        return returnvalue;
        
        
    }

    private void InsertAntecedentesMorbidos(SqlTransaction sqlt, int CodFichaSaludInicial, int CodAntecedenteMorbido, bool Tratamiento)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT AntecedentesMorbidos (CodFichaSaludInicial, CodAntecedenteMorbido, Tratamiento) values (@CodFichaSaludInicial, @CodAntecedenteMorbido, @Tratamiento )";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodAntecedenteMorbido", SqlDbType.Int, 4, CodAntecedenteMorbido));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tratamiento", SqlDbType.Int, 1, Tratamiento));
        sqlc.ExecuteNonQuery();
    }

    private DataTable SQLGetDiagosticoFichaSaludInicial(SqlTransaction sqlt, int CodFichaSaludInicial)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select CodFichaSaludInicial, CodDiagnostico, FechaDiagnostico, Antecedentes_Quirurgicos_Hospitalizacion,Transfusiones,Antecedentes_Gineco_Obstetricos,Antecedentes_Familiares,PA,Pulso,FR,T," +
        "Tranquilo,Excitado,Angustiado,Decaido,Irritable,Movilidad,Peso,Talla,IMC,PerimetroCintura,PerimetroCraneano,TallaEdad,PesoTalla,PesoEdad,EstadoNutricional," +
        "DesarrolloCognitivo,Comunicacion,DesarrolloSocioEmocional,ProximoControl,GradosTunner,EvaluacionOrtopedica,DisplaciaCadera,Color,Humedad,Cabeza,Cuello,Torax," +
        "Abdomen,Extremidades,Sintoma,Genitales,GenuValgo,GenuVaro,PiePlano,Marcha,Vision,Lentes,Audicion,Audifonos,SaludBucal,Ortodoncia,Columna,ConductaSexual," +
        "Menarquia,Ciclos,FO,Abortos,FUR,IdeacionSuicida,HistoriaClinicaEvolutiva,FechaIngresoFicha,IdUsuarioIngresoFicha, FechaIntervencion, FechaEvaluacion, PresumeConsumoDroga, VacunasAlDia, InscritoAtencionPrimaria, " +
        "CodEstablecimiento from DiagnosticoSaludFichaSaludInicial  where CodFichaSaludInicial = @CodFichaSaludInicial";
        sqlc.Parameters.AddWithValue("@CodFichaSaludInicial", CodFichaSaludInicial);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    private void InsertFarmacos
        (SqlTransaction sqlt, int CodFichaSaludInicial, int CodFarmaco, int CodPresentacion, int Manana, string CantidadManana, int Tarde, string CantidadTarde, int Noche, string CantidadNoche)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = " INSERT Farmacos (CodFichaSaludInicial, CodFarmaco, CodPresentacion, Manana, CantidadManana, Tarde, CantidadTarde, Noche, CantidadNoche)" +
                           " values (@CodFichaSaludInicial, @CodFarmaco, @CodPresentacion, @Manana, @CantidadManana, @Tarde, @CantidadTarde, @Noche, @CantidadNoche)";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFarmaco", SqlDbType.Int, 4, CodFarmaco));          
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPresentacion", SqlDbType.Int, 4, CodPresentacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Manana", SqlDbType.Int, 4, Manana));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CantidadManana", SqlDbType.VarChar, 5, CantidadManana));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tarde", SqlDbType.Int, 4, Tarde));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CantidadTarde", SqlDbType.VarChar, 5, CantidadTarde));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Noche", SqlDbType.Int, 4, Noche));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CantidadNoche", SqlDbType.VarChar, 5, CantidadNoche));        
        sqlc.ExecuteNonQuery();
    }

    private void InsertFarmacos
        (SqlTransaction sqlt, int CodFichaSaludInicial, int CodFarmaco, int CodPresentacion, int Manana, string CantidadManana, int Tarde, string CantidadTarde, int Noche, string CantidadNoche, string otros)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = " INSERT Farmacos (CodFichaSaludInicial, CodFarmaco, CodPresentacion, Manana, CantidadManana, Tarde, CantidadTarde, Noche, CantidadNoche, Otros)" +
                           " values (@CodFichaSaludInicial, @CodFarmaco, @CodPresentacion, @Manana, @CantidadManana, @Tarde, @CantidadTarde, @Noche, @CantidadNoche, @otros)";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFarmaco", SqlDbType.Int, 4, CodFarmaco));          
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodPresentacion", SqlDbType.Int, 4, CodPresentacion));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Manana", SqlDbType.Int, 1, Manana));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CantidadManana", SqlDbType.VarChar, 5, CantidadManana));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Tarde", SqlDbType.Int, 1, Tarde));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CantidadTarde", SqlDbType.VarChar, 5, CantidadTarde));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Noche", SqlDbType.Int, 1, Noche));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CantidadNoche", SqlDbType.VarChar, 5, CantidadNoche));    
        sqlc.Parameters.Add(Conexiones.CrearParametro("@otros", SqlDbType.VarChar, 30, otros));
        sqlc.ExecuteNonQuery();
    }


    private void InsertAlergias(SqlTransaction sqlt, int CodFichaSaludInicial, int CodAlergia)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT Alergias (CodFichaSaludInicial, CodAlergia) values (@CodFichaSaludInicial, @CodAlergia)";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodAlergia", SqlDbType.Int, 4, CodAlergia));
        sqlc.ExecuteNonQuery();
    }

    private void InsertAlergias(SqlTransaction sqlt, int CodFichaSaludInicial, int CodAlergia, string Otros)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT Alergias (CodFichaSaludInicial, CodAlergia, Otros) values (@CodFichaSaludInicial, @CodAlergia, @Otros)";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodAlergia", SqlDbType.Int, 4, CodAlergia));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@Otros", SqlDbType.VarChar, 30, Otros));
        sqlc.ExecuteNonQuery();
    }

    private void InsertTrastornos(SqlTransaction sqlt, int CodFichaSaludInicial, int CodTrastorno)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT Trastornos (CodFichaSaludInicial, CodTrastorno) values (@CodFichaSaludInicial, @CodTrastorno)";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTrastorno", SqlDbType.Int, 4, CodTrastorno));
        sqlc.ExecuteNonQuery();
    }

    private void InsertSindromes(SqlTransaction sqlt, int CodFichaSaludInicial, int CodSindrome)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT Sindromes (CodFichaSaludInicial, CodSindrome) values (@CodFichaSaludInicial, @CodSindrome)";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodSindrome", SqlDbType.Int, 4, CodSindrome));
        sqlc.ExecuteNonQuery();
    }

    private void InsertExamenes(SqlTransaction sqlt, int CodFichaSaludInicial, int CodExamen)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT Examenes (CodFichaSaludInicial, CodExamen) values (@CodFichaSaludInicial, @CodExamen)";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodExamen", SqlDbType.Int, 4, CodExamen));
        sqlc.ExecuteNonQuery();
    }

    public int GetCodDiagnosticoSaludFichaInicial(SqlTransaction sqlt, querytype tipo )
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        if (tipo == querytype.DiagnosticoGeneral)
        {
            sqlc.CommandText = "SELECT CodDiagnostico FROM DiagnosticoGeneral where ICodIE = @ICodIE and CodTipoDiagnosticoGlosa = 11";
        }
        if (tipo == querytype.FichaSaludInicial)
        {
            sqlc.CommandText = "select T1.CodFichaSaludInicial from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = (SELECT CodDiagnostico FROM DiagnosticoGeneral where ICodIE = @ICodIE and CodTipoDiagnosticoGlosa = 11)";
        }

        sqlc.Parameters.AddWithValue("@ICodIE", SSninoDiag.ICodIE);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();        
        da.Fill(dt);

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

    public int GetBoolFichaCompletaSaludFichaInicial()
    {

        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        
        sqlc.CommandText = "select T1.FichaCompleta from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = (SELECT CodDiagnostico FROM DiagnosticoGeneral where ICodIE = @ICodIE and CodTipoDiagnosticoGlosa = 11)";        

        sqlc.Parameters.AddWithValue("@ICodIE", SSninoDiag.ICodIE);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);

        if (dt.Rows.Count == 1)
        {
            returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        }
        if (dt.Rows.Count > 1)
        {
            returnvalue = -1;
        }

        sconn.Close();
        sconn.Dispose();
        return returnvalue;
    }


    public int Insert_DiagnosticoGeneral(SqlTransaction sqlt, int CodTipoDiagnosticoGlosa, int CodNino, int ICodIE, DateTime FechaDiagnostico)
    {
        int returnvalue = 0;

        SqlDataReader datareader = null;
        
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_DiagnosticoGeneral", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.Add("@CodTipoDiagnosticoGlosa", SqlDbType.Int, 4).Value = CodTipoDiagnosticoGlosa;
		sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
		sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE; 
		sqlc.Parameters.Add("@FechaDiagnostico", SqlDbType.DateTime, 16).Value = FechaDiagnostico;

        datareader = sqlc.ExecuteReader();
        
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        datareader.Close();
        datareader.Dispose();

        return returnvalue;        

    }


    public int ExisteAntecedenteMorbido(SqlTransaction sqlt, int CodFichaSaludInicial, int CodAntecedenteMorbido)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodAntecedenteMorbido FROM AntecedentesMorbidos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAntecedenteMorbido = @CodAntecedenteMorbido ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAntecedenteMorbido", SqlDbType.Int, 4).Value = CodAntecedenteMorbido;        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public int ExisteAntecedenteMorbido(int CodFichaSaludInicial, int CodAntecedenteMorbido)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodAntecedenteMorbido FROM AntecedentesMorbidos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAntecedenteMorbido = @CodAntecedenteMorbido ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAntecedenteMorbido", SqlDbType.Int, 4).Value = CodAntecedenteMorbido;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public void EliminaAntecedenteMorbido(int CodFichaSaludInicial, int CodAntecedenteMorbido)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM AntecedentesMorbidos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAntecedenteMorbido = @CodAntecedenteMorbido ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAntecedenteMorbido", SqlDbType.Int, 4).Value = CodAntecedenteMorbido;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public void EliminaFarmaco(int CodFichaSaludInicial, int CodFarmaco)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "Delete FROM Farmacos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodFarmaco = @CodFarmaco ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodFarmaco", SqlDbType.Int, 4).Value = CodFarmaco;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public void EliminaFarmacoOtros(int CodFichaSaludInicial, int CodFarmaco, string Otros)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM Farmacos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodFarmaco = @CodFarmaco and Otros = @Otros ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodFarmaco", SqlDbType.Int, 4).Value = CodFarmaco;
        sqlc.Parameters.Add("@Otros", SqlDbType.VarChar, 30).Value = Otros;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public int ExisteFarmaco(int CodFichaSaludInicial, int CodFarmaco)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodFarmaco FROM Farmacos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodFarmaco = @CodFarmaco ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodFarmaco", SqlDbType.Int, 4).Value = CodFarmaco;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public int ExisteFarmacoOtros(int CodFichaSaludInicial, int CodFarmaco, string Otros)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodFarmaco FROM Farmacos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodFarmaco = @CodFarmaco and Otros = @Otros ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodFarmaco", SqlDbType.Int, 4).Value = CodFarmaco;
        sqlc.Parameters.Add("@Otros", SqlDbType.VarChar, 30).Value = Otros;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public int ExisteFarmaco(SqlTransaction sqlt, int CodFichaSaludInicial, int CodFarmaco)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodFarmaco FROM Farmacos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodFarmaco = @CodFarmaco ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodFarmaco", SqlDbType.Int, 4).Value = CodFarmaco;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public int ExisteFarmacoOtros(SqlTransaction sqlt, int CodFichaSaludInicial, int CodFarmaco, string Otros)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodFarmaco FROM Farmacos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodFarmaco = @CodFarmaco and Otros = @Otros ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodFarmaco", SqlDbType.Int, 4).Value = CodFarmaco;
        sqlc.Parameters.Add("@Otros", SqlDbType.VarChar, 30).Value = Otros;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public void EliminaAlergia(int CodFichaSaludInicial, int CodAlergia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM Alergias WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAlergia = @CodAlergia ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAlergia", SqlDbType.Int, 4).Value = CodAlergia;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public int ExisteAlergia(int CodFichaSaludInicial, int CodAlergia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodAlergia FROM Alergias WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAlergia = @CodAlergia ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAlergia", SqlDbType.Int, 4).Value = CodAlergia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public void EliminaAlergiaOtros(int CodFichaSaludInicial, int CodAlergia, string Otros)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM Alergias WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAlergia = @CodAlergia and Otros = @Otros ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAlergia", SqlDbType.Int, 4).Value = CodAlergia;
        sqlc.Parameters.Add("@Otros", SqlDbType.VarChar, 30).Value = Otros;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public int ExisteAlergiaOtros(int CodFichaSaludInicial, int CodAlergia, string Otros)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodAlergia FROM Alergias WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAlergia = @CodAlergia and Otros = @Otros ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAlergia", SqlDbType.Int, 4).Value = CodAlergia;
        sqlc.Parameters.Add("@Otros", SqlDbType.VarChar, 30).Value = Otros;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public int ExisteAlergia(SqlTransaction sqlt, int CodFichaSaludInicial, int CodAlergia)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodAlergia FROM Alergias WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAlergia = @CodAlergia ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAlergia", SqlDbType.Int, 4).Value = CodAlergia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public int ExisteAlergiaOtros(SqlTransaction sqlt, int CodFichaSaludInicial, int CodAlergia, string Otros)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodAlergia FROM Alergias WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodAlergia = @CodAlergia and Otros = @Otros ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodAlergia", SqlDbType.Int, 4).Value = CodAlergia;
        sqlc.Parameters.Add("@Otros", SqlDbType.VarChar, 30).Value = Otros;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public void EliminaTrastornos(int CodFichaSaludInicial, int CodTrastorno)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM Trastornos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodTrastorno = @CodTrastorno ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodTrastorno", SqlDbType.Int, 4).Value = CodTrastorno;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public int ExisteTrastornos(int CodFichaSaludInicial, int CodTrastorno)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodTrastorno FROM Trastornos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodTrastorno = @CodTrastorno ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodTrastorno", SqlDbType.Int, 4).Value = CodTrastorno;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public int ExisteTrastornos(SqlTransaction sqlt, int CodFichaSaludInicial, int CodTrastorno)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodTrastorno FROM Trastornos WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodTrastorno = @CodTrastorno ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodTrastorno", SqlDbType.Int, 4).Value = CodTrastorno;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public void EliminaSindrome(int CodFichaSaludInicial, int CodSindrome)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM Sindromes WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodSindrome = @CodSindrome ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodSindrome", SqlDbType.Int, 4).Value = CodSindrome;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public int ExisteSindrome(int CodFichaSaludInicial, int CodSindrome)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodSindrome FROM Sindromes WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodSindrome = @CodSindrome ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodSindrome", SqlDbType.Int, 4).Value = CodSindrome;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public int ExisteSindrome(SqlTransaction sqlt, int CodFichaSaludInicial, int CodSindrome)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodSindrome FROM Sindromes WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodSindrome = @CodSindrome ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodSindrome", SqlDbType.Int, 4).Value = CodSindrome;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public void EliminaExamen(int CodFichaSaludInicial, int CodExamen)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "DELETE FROM Examenes WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodExamen = @CodExamen ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodExamen", SqlDbType.Int, 4).Value = CodExamen;
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
        sconn.Dispose();
    }

    public int ExisteExamen(int CodFichaSaludInicial, int CodExamen)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodExamen FROM Examenes WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodExamen = @CodExamen ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodExamen", SqlDbType.Int, 4).Value = CodExamen;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt.Rows.Count;
    }

    public int ExisteExamen(SqlTransaction sqlt, int CodFichaSaludInicial, int CodExamen)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT CodFichaSaludInicial, CodExamen FROM Examenes WHERE CodFichaSaludInicial = @CodFichaSaludInicial and CodExamen = @CodExamen ";
        sqlc.Parameters.Add("@CodFichaSaludInicial", SqlDbType.Int, 4).Value = CodFichaSaludInicial;
        sqlc.Parameters.Add("@CodExamen", SqlDbType.Int, 4).Value = CodExamen;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt.Rows.Count;
    }

    public DataTable GetIntentoSuicidaHechosSalud(int ICodIE)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT T1.ICodHechosdeSalud,/* T1.CodDiagnostico,*/ T1.FechaDiagnostico, T1.CodHechoSalud,T1.CodAtencionHechoSalud, T1.CodLugarHechoSalud, T1.CodInstitucion, T1.CodTrabajador, " +
                           "T1.Observacion, T1.IndVigencia, T1.FechaActualizacion, T1.IdUsuarioActualizacion, T3.Descripcion as DescripcionHecho, T4.Descripcion as DescripcionTipo, " +
                           "T5.Descripcion as DescripcionLugar, T6.Nombres + ' ' + T6.Paterno as Nombre FROM HechosSalud T1 INNER JOIN Ingresos_Egresos T2 ON  T1.IcodIe = T2.IcodIE " +
                           "INNER JOIN parHechosSalud T3 ON T1.CodHechoSalud = T3.CodHechoSalud INNER JOIN parAtencionHechoSalud T4 ON T1.CodAtencionHechoSalud = T4.CodAtencionHechoSalud AND rtrim(T4.IndVigencia) = 'V' " +
                           "INNER JOIN parLugarHechoSalud T5 ON T1.CodLugarHechoSalud = T5.CodLugarHechoSalud AND rtrim(T5.IndVigencia) = 'V' INNER JOIN Trabajadores T6 ON T1.ICodTrabajador = T6.ICodTrabajador " +
                           "WHERE T2.ICodIE = @ICodIE and T1.CodHechoSalud= 5 ";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetAntecedentesMaternidad(int ICodIE)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "Select T2.ICodSocial, T2.FechaDiagnostico, T2.AdolescenteEmbarazada, T2.NumeroMesesGestacion as NumeroSemanasGestacion, T2.EmbarazoAbusoViolacion, T2.AdolescentePadreMadre, T2.NumeroHijos, T2.HijosAbusoViolacion, " +
                           "(T7.Nombres  +' '+ T7.Paterno) AS Nombre From DiagnosticoGeneral T1 Inner Join DiagnosticosSocial T2 On  T1.CodDiagnostico = T2.CodDiagnostico inner Join Trabajadores T7 On " +
                           "T7.ICodTrabajador = T2.ICodTrabajador WHERE T1.ICodIE = @ICodIE and (T2.AdolescenteEmbarazada <> 0 or T2.AdolescentePadreMadre <> 0)";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }


    public DataTable GetDiscapacidadHechosSalud(int ICodIE)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "SELECT T1.ICodIE,T1.IcodDiscapacidad,T1.TipoDiscapacidad, T1.FechaDiagnostico, T1.Observacion, T1.CodNivelDiscapacidad, T1.CodInstitucion, T1.CodTrabajador, T1.IndVigencia, T1.FechaActualizacion, " +
                            "T1.IdUsuarioActualizacion, T4.Nombres + ' ' + T4.Paterno as nombres, T3.Descripcion as DescripcionTipo, T5.Descripcion as DescripcionNivel FROM DiagnosticosDiscapacidad T1 INNER JOIN parTipoDiscapacidad  T3 ON " +
                            "T1.TipoDiscapacidad  = T3.TipoDiscapacidad INNER JOIN Trabajadores T4 ON T1.ICodTrabajador = T4.ICodTrabajador INNER JOIN parNivelDiscapacidad T5 ON T1.CodNivelDiscapacidad = T5.CodNivelDiscapacidad " +
                            "WHERE T1.ICodIE = @ICodIE";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    protected void grd00AntecedentesMorbidos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]); 
        int codAntecedenteMorbido = Convert.ToInt32(DTAntecedentesMorbidos.Rows[Convert.ToInt32(e.CommandArgument)][1]);
        int AntecedenteMorbido = ExisteAntecedenteMorbido(CodFichaSaludInicial, codAntecedenteMorbido);

        if (AntecedenteMorbido == 1)
        {
            EliminaAntecedenteMorbido(CodFichaSaludInicial, codAntecedenteMorbido);
        }
        
        DTAntecedentesMorbidos.Rows.Remove(DTAntecedentesMorbidos.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTAntecedentesMorbidos);
        grd00AntecedentesMorbidos.DataSource = dv;
        dv.Sort = "CodAntecedenteMorbido";
        grd00AntecedentesMorbidos.DataBind();        
    }

    protected void grdFarmacos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]);
        int codFarmaco = Convert.ToInt32(DTFarmacos.Rows[Convert.ToInt32(e.CommandArgument)]["codFarmaco"]);
        int Farmaco = -1;

        if (codFarmaco == 1)
        {
            string OtrosFarmacos = (DTFarmacos.Rows[Convert.ToInt32(e.CommandArgument)]["DescripcionOtros"]).ToString();
            Farmaco = ExisteFarmacoOtros(CodFichaSaludInicial, codFarmaco, OtrosFarmacos);
            if (Farmaco == 1)
            {
                EliminaFarmacoOtros(CodFichaSaludInicial, codFarmaco, OtrosFarmacos);
            }
        }
        if (codFarmaco > 1)
        {
            Farmaco = ExisteFarmaco(CodFichaSaludInicial, codFarmaco);

            if (Farmaco == 1)
            {
                EliminaFarmaco(CodFichaSaludInicial, codFarmaco);
            }
        }

        DTFarmacos.Rows.Remove(DTFarmacos.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTFarmacos);
        grdFarmacos.DataSource = dv;
        dv.Sort = "codFarmaco";
        grdFarmacos.DataBind();      
    }

    protected void grdAlergias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]);
        int CodAlergia = Convert.ToInt32(DTAlergias.Rows[Convert.ToInt32(e.CommandArgument)]["CodAlergia"]);
        int Alergia = -1;

        if (CodAlergia == 1)
        {
            string OtrasAlergias = (DTAlergias.Rows[Convert.ToInt32(e.CommandArgument)]["DescripcionOtros"]).ToString();
            Alergia = ExisteAlergiaOtros(CodFichaSaludInicial, CodAlergia, OtrasAlergias);

            if (Alergia == 1)
            {
                EliminaAlergiaOtros(CodFichaSaludInicial, CodAlergia, OtrasAlergias);
            }
        }

        if (CodAlergia > 1)
        {
            Alergia = ExisteAlergia(CodFichaSaludInicial, CodAlergia);

            if (Alergia == 1)
            {
                EliminaAlergia(CodFichaSaludInicial, CodAlergia);
            }
        }

        DTAlergias.Rows.Remove(DTAlergias.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTAlergias);
        grdAlergias.DataSource = dv;
        dv.Sort = "DescripcionAlergia";
        grdAlergias.DataBind();

    }

    protected void grdTrastornos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]);
        int CodTrastorno = Convert.ToInt32(DTTrastornos.Rows[Convert.ToInt32(e.CommandArgument)]["CodTrastorno"]);
        int Trastorno = ExisteTrastornos(CodFichaSaludInicial, CodTrastorno);

        if (Trastorno == 1)
        {
            EliminaTrastornos(CodFichaSaludInicial, CodTrastorno);
        }

        DTTrastornos.Rows.Remove(DTTrastornos.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTTrastornos);
        grdTrastornos.DataSource = dv;
        dv.Sort = "DescripcionTrastornos";
        grdTrastornos.DataBind();


    }

    protected void grdSindrome_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]);
        int CodSindrome = Convert.ToInt32(DTSindromes.Rows[Convert.ToInt32(e.CommandArgument)]["CodSindrome"]);
        int Sindrome = ExisteSindrome(CodFichaSaludInicial, CodSindrome);

        if (Sindrome == 1)
        {
            EliminaSindrome(CodFichaSaludInicial, CodSindrome);
        }

        DTSindromes.Rows.Remove(DTSindromes.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTSindromes);
        grdSindrome.DataSource = dv;
        dv.Sort = "DescripcionSindrome";
        grdSindrome.DataBind();
    }

    protected void grdExamenes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]);
        int CodExamen = Convert.ToInt32(DTExamenes.Rows[Convert.ToInt32(e.CommandArgument)]["CodExamen"]);
        int Examen = ExisteExamen(CodFichaSaludInicial, CodExamen);

        if (Examen == 1)
        {
            EliminaExamen(CodFichaSaludInicial, CodExamen);
        }

        DTExamenes.Rows.Remove(DTExamenes.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTExamenes);
        grdExamenes.DataSource = dv;
        dv.Sort = "CodExamen";
        grdExamenes.DataBind();
    }

    protected void grd00AntecedentesMorbidos_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell Tratamiento = e.Row.Cells[1];
            if (Tratamiento.Text == "1")
            {
                Tratamiento.Text = "Si";
            }
            if (Tratamiento.Text == "0")
            {
                Tratamiento.Text = "No";
            }
            if (Tratamiento.Text == "-1")
            {
                Tratamiento.Text = "";
            }

        }
    }

    protected void ddlFarmacos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFarmacos.SelectedValue == "1")
        {
            thOtrosFarmacos.Visible = true;
            tdOtrosFarmacos.Visible = true;
            thRellenoFarmacosOtros.Visible = false;
            tdRellenoFarmacosOtros.Visible = false;
        }
        else
        {
            thOtrosFarmacos.Visible = false;
            tdOtrosFarmacos.Visible = false;
            thRellenoFarmacosOtros.Visible = true;
            tdRellenoFarmacosOtros.Visible = true;
            txtOtrosFarmacos.Text = "";
        }
    }
    protected void ddlAlergias_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAlergias.SelectedValue == "1")
        {
            thOtrasAlergias.Visible = true;
            tdOtrasAlergias.Visible = true;
            threllenoAlergiasOtros.Visible = false;
            tdrellenoAlergiasOtros.Visible = false;
        }
        else
        {
            thOtrasAlergias.Visible = false;
            tdOtrasAlergias.Visible = false;
            threllenoAlergiasOtros.Visible = true;
            tdrellenoAlergiasOtros.Visible = true;
            txtOtrasAlergias.Text = "";
        }
    }

    protected void btnAgregarAntecedentesMorbidos_Click(object sender, EventArgs e)
    {
        
        DataRow dr = DTAntecedentesMorbidos.NewRow();
        bool chk_rep = false;

        if (ddlAntecedentesMorbidos.SelectedValue != Convert.ToString(0) && (rbtnTratamientoSi.Checked == true || rbtnTratamientoNo.Checked == true || ddlAntecedentesMorbidos.SelectedValue == "1" ))
        {
            for (int i = 0; i < DTAntecedentesMorbidos.Rows.Count; i++)
            {
                if (DTAntecedentesMorbidos.Rows[i]["CodAntecedenteMorbido"].ToString() == ddlAntecedentesMorbidos.SelectedValue)
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                if (grd00AntecedentesMorbidos.Rows.Count < 7)
                {
                    dr[0] = ddlAntecedentesMorbidos.SelectedItem;
                    dr[1] = ddlAntecedentesMorbidos.SelectedValue;

                    if (ddlAntecedentesMorbidos.SelectedValue != "1")
                    {
                        if (rbtnTratamientoSi.Checked == true)
                        {
                            dr[2] = Convert.ToInt32(1);
                        }
                        else
                        {
                            dr[2] = Convert.ToInt32(0);
                        }
                    }
                    else
                    {
                        dr[2] = Convert.ToInt32(-1);
                    }
                    DTAntecedentesMorbidos.Rows.Add(dr);
                    DataView dv = new DataView(DTAntecedentesMorbidos);
                    grd00AntecedentesMorbidos.DataSource = dv;
                    dv.Sort = "CodAntecedenteMorbido";
                    grd00AntecedentesMorbidos.DataBind();

                    rbtnTratamientoSi.Checked = false;
                    rbtnTratamientoNo.Checked = false;

                    grd00AntecedentesMorbidos.Visible = true;
                    trAntecedentesMorbidos.Visible = true;

                    ddlAntecedentesMorbidos.SelectedValue = Convert.ToString(0);
                    ddlAntecedentesMorbidos.BackColor = System.Drawing.Color.Empty;
                    trAvisoAntecedentesMorbidos.Visible = false;
                }
                else 
                {
                    lbl_avisoAntecedentesMorbidos.Text = "Sólo se pueden registrar un maximo de 7 Antecedentes Mórbidos";
                    trAvisoAntecedentesMorbidos.Visible = true;
                }
            }
            else
            {
                lbl_avisoAntecedentesMorbidos.Text = "El antecedente seleccionado ya ha sido ingresado";
                trAvisoAntecedentesMorbidos.Visible = true;
            }
        }
        else
        {

            lbl_avisoAntecedentesMorbidos.Text = "Faltan campos para el ingreso de antecedente mórbido.";
            trAvisoAntecedentesMorbidos.Visible = true;

        }
    }
    protected void btnAgregarFarmacos_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        DataRow dr = DTFarmacos.NewRow();
        bool chk_requerido = false;
        bool chk_repetido = false;
        

        if (ddlFarmacos.SelectedValue == "1")
        {
            if (ddlFarmacos.SelectedValue != Convert.ToString(0) && ddlPresentacionFarmaco.SelectedValue != Convert.ToString(0) && 
                txtOtrosFarmacos.Text != "" && (chkManana.Checked || chkTarde.Checked || chkNoche.Checked))
            {
                if (chkManana.Checked)
                {
                    if (txtManana.Text == "")
                    {
                        txtManana.BackColor = colorCampoObligatorio;
                        chk_requerido = true;
                    }
                    else
                    {
                        txtManana.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {
                    txtManana.BackColor = System.Drawing.Color.Empty;
                }

                if (chkTarde.Checked)
                {
                    if (txtTarde.Text == "")
                    {
                        txtTarde.BackColor = colorCampoObligatorio;
                        chk_requerido = true;
                    }
                    else
                    {
                        txtTarde.BackColor = System.Drawing.Color.Empty;
                    }
                }

                else
                {
                    txtTarde.BackColor = System.Drawing.Color.Empty;
                }


                if (chkNoche.Checked)
                {
                    if (txtNoche.Text == "")
                    {
                        txtNoche.BackColor = colorCampoObligatorio;
                        chk_requerido = true;
                    }
                    else
                    {
                        txtNoche.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {
                    txtNoche.BackColor = System.Drawing.Color.Empty;
                }
               
                
                if (!chk_requerido)
                {
                    dr[0] = ddlFarmacos.SelectedItem;
                    dr[1] = ddlFarmacos.SelectedValue;                    
                                       
                    dr[2] = ddlPresentacionFarmaco.SelectedItem;
                    dr[3] = ddlPresentacionFarmaco.SelectedValue;

                    dr[4] = chkManana.Checked;

                    if (chkManana.Checked == true) { dr[5] = txtManana.Text; } else { dr[5] = "";}

                    dr[6] = chkTarde.Checked;

                    if (chkTarde.Checked == true) { dr[7] = txtTarde.Text; } else { dr[7] = ""; }

                    dr[8] = chkNoche.Checked;

                    if (chkNoche.Checked == true) { dr[9] = txtNoche.Text; } else { dr[9] = ""; }

                    dr[10] = txtOtrosFarmacos.Text.ToString();

                    DTFarmacos.Rows.Add(dr);
                    DataView dv = new DataView(DTFarmacos);
                    grdFarmacos.DataSource = dv;
                    dv.Sort = "CodFarmaco";
                    grdFarmacos.DataBind();
                    grdFarmacos.Visible = true;
                    trFarmacos.Visible = true;
                    ddlFarmacos.SelectedValue = Convert.ToString(0);
                    thOtrosFarmacos.Visible = false;
                    tdOtrosFarmacos.Visible = false;
                    thRellenoFarmacosOtros.Visible = true;
                    tdRellenoFarmacosOtros.Visible = true;
                    txtOtrosFarmacos.Text = "";
                    ddlPresentacionFarmaco.SelectedValue = Convert.ToString(0);                   
                    trAvisoFarmaco.Visible = false;
                    chkManana.Checked = false;
                    chkTarde.Checked = false;
                    chkNoche.Checked = false;
                    txtManana.Enabled = false;
                    txtTarde.Enabled = false;
                    txtNoche.Enabled = false;
                    txtManana.Text = "";
                    txtTarde.Text = "";
                    txtNoche.Text = "";

                }
                else
                {
                    lbl_avisoFarmaco.Text = "Faltan campos para el ingreso de farmaco.";                    
                    trAvisoFarmaco.Visible = true;
                }
            }
            else
            {
                lbl_avisoFarmaco.Text = "Faltan campos para el ingreso de farmaco.";                
                trAvisoFarmaco.Visible = true;
            }
        }
        else
        {
            if (ddlFarmacos.SelectedValue != Convert.ToString(0) && ddlPresentacionFarmaco.SelectedValue != Convert.ToString(0) &&
               (chkManana.Checked || chkTarde.Checked || chkNoche.Checked))
            {
                for (int i = 0; i < grdFarmacos.Rows.Count; i++)
                {
                    if (DTFarmacos.Rows[i]["CodFarmaco"].ToString() == ddlFarmacos.SelectedValue.ToString())
                    {
                         chk_repetido = true;
                    }
                }

                if (chkManana.Checked)
                {
                    if (txtManana.Text == "")
                    {
                        txtManana.BackColor = colorCampoObligatorio;
                        chk_requerido = true;
                    }
                    else
                    {
                        txtManana.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {
                    txtManana.BackColor = System.Drawing.Color.Empty;
                }

                if (chkTarde.Checked)
                {
                    if (txtTarde.Text == "")
                    {
                        txtTarde.BackColor = colorCampoObligatorio;
                        chk_requerido = true;
                    }
                    else
                    {
                        txtTarde.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {
                    txtTarde.BackColor = System.Drawing.Color.Empty;
                }

                if (chkNoche.Checked)
                {
                    if (txtNoche.Text == "")
                    {
                        txtNoche.BackColor = colorCampoObligatorio;
                        chk_requerido = true;
                    }
                    else
                    {
                        txtNoche.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {
                    txtNoche.BackColor = System.Drawing.Color.Empty;
                }

                if (!chk_repetido)
                {
                    if (!chk_requerido)
                    {
                        dr[0] = ddlFarmacos.SelectedItem;
                        dr[1] = ddlFarmacos.SelectedValue;                        

                        dr[2] = ddlPresentacionFarmaco.SelectedItem;
                        dr[3] = ddlPresentacionFarmaco.SelectedValue;

                        dr[4] = chkManana.Checked;

                        if (chkManana.Checked == true) { dr[5] = txtManana.Text; } else { dr[5] = ""; }

                        dr[6] = chkTarde.Checked;

                        if (chkTarde.Checked == true) { dr[7] = txtTarde.Text; } else { dr[7] = ""; }

                        dr[8] = chkNoche.Checked;

                        if (chkNoche.Checked == true) { dr[9] = txtNoche.Text; } else { dr[9] = ""; }

                        dr[10] = "";

                        DTFarmacos.Rows.Add(dr);
                        DataView dv = new DataView(DTFarmacos);
                        grdFarmacos.DataSource = dv;
                        dv.Sort = "CodFarmaco";
                        grdFarmacos.DataBind();
                        grdFarmacos.Visible = true;
                        trFarmacos.Visible = true;
                        ddlFarmacos.SelectedValue = Convert.ToString(0);
                        thOtrosFarmacos.Visible = false;
                        tdOtrosFarmacos.Visible = false;
                        thRellenoFarmacosOtros.Visible = true;
                        tdRellenoFarmacosOtros.Visible = true;
                        txtOtrosFarmacos.Text = "";
                        ddlPresentacionFarmaco.SelectedValue = Convert.ToString(0);                        
                        trAvisoFarmaco.Visible = false;
                        chkManana.Checked = false;
                        chkTarde.Checked = false;
                        chkNoche.Checked = false;
                        txtManana.Enabled = false;
                        txtTarde.Enabled = false;
                        txtNoche.Enabled = false;
                        txtManana.Text = "";
                        txtTarde.Text = "";
                        txtNoche.Text = "";
                    }
                }
                else
                {
                    lbl_avisoFarmaco.Text = "El Farmaco seleccionado ya ha sido ingresado";                    
                    trAvisoFarmaco.Visible = true;
                }
            }
            else
            {
                lbl_avisoFarmaco.Text = "Faltan campos para el ingreso de farmaco";                
                trAvisoFarmaco.Visible = true;
            }
        }


        
    }
    
    protected void lnkAgregarAlergia_Click(object sender, EventArgs e)
    {
        DataRow dr = DTAlergias.NewRow();
        bool chk_rep = false;

        if (ddlAlergias.SelectedValue == "1")
        {
            if (ddlAlergias.SelectedValue != Convert.ToString(0) && txtOtrasAlergias.Text != "")
            {
                    dr[0] = ddlAlergias.SelectedItem;
                    dr[1] = ddlAlergias.SelectedValue;
                    dr[2] = txtOtrasAlergias.Text.ToString();
                    DTAlergias.Rows.Add(dr);
                    DataView dv = new DataView(DTAlergias);
                    grdAlergias.DataSource = dv;
                    dv.Sort = "DescripcionAlergia";
                    grdAlergias.DataBind();
                    grdAlergias.Visible = true;
                    trAlergias.Visible = true;
                    ddlAlergias.SelectedValue = Convert.ToString(0);
                    txtOtrasAlergias.Text = "";
                    thOtrasAlergias.Visible = false;
                    tdOtrasAlergias.Visible = false;
                    threllenoAlergiasOtros.Visible = true;
                    tdrellenoAlergiasOtros.Visible = true;
                    trAvisoAlergias.Visible = false;
            }
            else
            {
                lbl_avisoAlergias.Text = "Faltan campos para el ingreso de alergia";
                trAvisoAlergias.Visible = true;
            }
        }
        else
        {
            if (ddlAlergias.SelectedValue != Convert.ToString(0))
            {
                for (int i = 0; i < DTAlergias.Rows.Count; i++)
                {
                    if (DTAlergias.Rows[i]["CodAlergia"].ToString() == ddlAlergias.SelectedValue)
                    {
                        chk_rep = true;
                    }
                }
                if (!chk_rep)
                {
                    dr[0] = ddlAlergias.SelectedItem;
                    dr[1] = ddlAlergias.SelectedValue;
                    dr[2] = "";

                    DTAlergias.Rows.Add(dr);
                    DataView dv = new DataView(DTAlergias);
                    grdAlergias.DataSource = dv;
                    dv.Sort = "DescripcionAlergia";
                    grdAlergias.DataBind();
                    grdAlergias.Visible = true;
                    trAlergias.Visible = true;
                    ddlAlergias.SelectedValue = Convert.ToString(0);
                    txtOtrasAlergias.Text = "";
                    thOtrasAlergias.Visible = false;
                    tdOtrasAlergias.Visible = false;
                    threllenoAlergiasOtros.Visible = true;
                    tdrellenoAlergiasOtros.Visible = true;
                    trAvisoAlergias.Visible = false;
                }
                else
                {
                    lbl_avisoAlergias.Text = "La alergia seleccionada ya ha sido ingresada";
                    trAvisoAlergias.Visible = true;
                }
            }
            else
            {
                lbl_avisoAlergias.Text = "Faltan campos para el ingreso de alergia";
                trAvisoAlergias.Visible = true;
            }
        }

        
    }
   
    protected void lnkAgregarTrastorno_Click(object sender, EventArgs e)
    {
        DataRow dr = DTTrastornos.NewRow();
        bool chk_rep = false;

        if (ddlTrastornos.SelectedValue != Convert.ToString(0))
        {
            for (int i = 0; i < DTTrastornos.Rows.Count; i++)
            {
                if (DTTrastornos.Rows[i]["CodTrastorno"].ToString() == ddlTrastornos.SelectedValue)
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                dr[0] = ddlTrastornos.SelectedItem;
                dr[1] = ddlTrastornos.SelectedValue;

                DTTrastornos.Rows.Add(dr);
                DataView dv = new DataView(DTTrastornos);
                grdTrastornos.DataSource = dv;
                dv.Sort = "DescripcionTrastornos";
                grdTrastornos.DataBind();

                grdTrastornos.Visible = true;
                trTrastornos.Visible = true;

                ddlTrastornos.SelectedValue = Convert.ToString(0);

                trAvisoTrastornos.Visible = false;

            }
            else
            {
                lbl_avisoTrastornos.Text = "El trastorno seleccionado ya ha sido ingresado";
                trAvisoTrastornos.Visible = true;
            }
        }
        else
        {

            lbl_avisoTrastornos.Text = "Faltan campos para el ingreso de un trastorno";
            trAvisoTrastornos.Visible = true;

        }
    }
    protected void lnkAgregarSindrome_Click(object sender, EventArgs e)
    {

        DataRow dr = DTSindromes.NewRow();
        bool chk_rep = false;

        if (ddlSindromes.SelectedValue != Convert.ToString(0))
        {
            for (int i = 0; i < DTSindromes.Rows.Count; i++)
            {
                if (DTSindromes.Rows[i]["CodSindrome"].ToString() == ddlSindromes.SelectedValue)
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                dr[0] = ddlSindromes.SelectedItem;
                dr[1] = ddlSindromes.SelectedValue;

                DTSindromes.Rows.Add(dr);
                DataView dv = new DataView(DTSindromes);
                grdSindrome.DataSource = dv;
                dv.Sort = "DescripcionSindrome";
                grdSindrome.DataBind();
                grdSindrome.Visible = true;
                trSindrome.Visible = true;
                ddlSindromes.SelectedValue = Convert.ToString(0);
                trAvisoSindrome.Visible = false;
            }
            else
            {
                lbl_avisoSindrome.Text = "El Síndrome seleccionado ya ha sido ingresado";
                trAvisoSindrome.Visible = true;
            }
        }
        else
        {

            lbl_avisoSindrome.Text = "Faltan campos para el ingreso de un síndrome";
            trAvisoSindrome.Visible = true;
        }

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

    private void ModificaFicha(bool modificar)
    {
        if (modificar == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblEncabezado", " $('#tblEncabezado').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblDatosRelevantes", " $('#tblDatosRelevantes').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblAnamnesis", " $('#tblAnamnesis').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblExamenFisicoEstadoConciencia1", " $('#tblExamenFisicoEstadoConciencia1').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblExamenFisicoEstadoConciencia2", " $('#tblExamenFisicoEstadoConciencia2').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblExamenFisicoPielMucosas", " $('#tblExamenFisicoPielMucosas').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblHistoriaClinica", " $('#tblHistoriaClinica').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "disabletblAntecedenteMorbido", " $('#tblAntecedenteMorbido').find('input,button,textarea,select').attr('disabled', 'disabled');", true);

            


            btnGuardarDatosRelevantes.Visible = false;
            btnGuardar.Visible = false;
            btnGuardar2.Visible = false;
            btnGuardar3.Visible = false;
            btnGuardarFinal.Visible = false;

            btnAgregarAntecedentesMorbidos.Visible = false;
            btnAgregarFarmacos.Visible = false;
            lnkAgregarAlergia.Visible = false;
            lnkAgregarTrastorno.Visible = false;
            lnkAgregarSindrome.Visible = false;
            btnAgregarExamen.Visible = false;

            grd00AntecedentesMorbidos.Columns[2].Visible = false;
            grdFarmacos.Columns[9].Visible = false;
            grdAlergias.Columns[2].Visible = false;
            grdTrastornos.Columns[1].Visible = false;
            grdSindrome.Columns[1].Visible = false;
            grdExamenes.Columns[2].Visible = false;
        }
    }

    private void GetDatosDiagosticoFichaSaludInicial(SqlTransaction sqlt, int CodFichaSaludInicial)
    {
        DataTable dt = SQLGetDiagosticoFichaSaludInicial(sqlt, CodFichaSaludInicial);
        diagnosticoscoll dcoll = new diagnosticoscoll();

        ViewState["FechaIngresoFichaInicial"] = dt.Rows[0]["FechaIngresoFicha"];
        ViewState["IdUsuarioIngresoFicha"] = dt.Rows[0]["IdUsuarioIngresoFicha"];
        
        bool ModificarFicha = false;
        if ((ViewState["FechaIngresoFichaInicial"] != null && Convert.ToString(ViewState["FechaIngresoFichaInicial"]) != "") && (ViewState["IdUsuarioIngresoFicha"] != null && Convert.ToString(ViewState["IdUsuarioIngresoFicha"]) != ""))
        {
            DateTime FechaIngresoFichaInicial = Convert.ToDateTime(ViewState["FechaIngresoFichaInicial"]);
            int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
            int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

            if ((DateTime.Now - FechaIngresoFichaInicial).TotalHours <= 24)
            {
                if (UsuarioActual == IdUsuarioIngresoFicha)
                {
                    if (!window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B") && window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                    {
                        ModificarFicha = true;
                        btnGuardarDatosRelevantes.Visible = true;
                        btnGuardar.Visible = true;
                        btnGuardar2.Visible = true;
                        btnGuardar3.Visible = true;
                        btnGuardarFinal.Visible = true;
                    }

                    
                    divAlertaFicha.Visible = false;
                    lblAlertaFicha.Text = "";

                    DateTime FechaFinal = FechaIngresoFichaInicial.AddDays(1);
                    String FechaFinalSeteadaDiagInicial = FechaFinal.Month + "/" + FechaFinal.Day + "/" + FechaFinal.Year + " " + FechaFinal.TimeOfDay;

                    ViewState["FechaFinalSeteadaDiagInicial"] = FechaFinalSeteadaDiagInicial;
                                             
                    tdHorasRestantes.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('" + FechaFinalSeteadaDiagInicial + "', 'countdownDiagInicial');", true);
                    
                }
                else
                {
                    //btnGuardar.Visible = false;
                    //btnGuardar2.Visible = false;
                    //btnGuardar3.Visible = false;
                    ModificarFicha = false;

                    divAlertaFicha.Visible = true;
                    lblAlertaFicha.Text = "La ficha solo puede ser modificada por la persona que la ingresó.  ";

                //    btnAgregarAntecedentesMorbidos.Visible = false;
                //    btnAgregarFarmacos.Visible = false;                   
                //    lnkAgregarAlergia.Visible = false;                    
                //    lnkAgregarTrastorno.Visible = false;
                //    lnkAgregarSindrome.Visible = false;
                //    btnAgregarExamen.Visible = false;

                //    grd00AntecedentesMorbidos.Columns[2].Visible = false;
                //    grdFarmacos.Columns[10].Visible = false;
                //    grdAlergias.Columns[2].Visible = false;
                //    grdTrastornos.Columns[1].Visible = false;
                //    grdSindrome.Columns[1].Visible = false;
                //    grdExamenes.Columns[2].Visible = false;
                }
            }
            else
            {
                
                ModificarFicha = false;

                divAlertaFicha.Visible = true;
                lblAlertaFicha.Text = "Tiempo de modificación expirado. La ficha solo puede ser modificada 24 horas desde la fecha de ingreso.  ";

                //btnGuardar.Visible = false;
                //btnGuardar2.Visible = false;
                //btnGuardar3.Visible = false;

                //btnAgregarAntecedentesMorbidos.Visible = false;
                //btnAgregarFarmacos.Visible = false;                
                //lnkAgregarAlergia.Visible = false;                
                //lnkAgregarTrastorno.Visible = false;
                //lnkAgregarSindrome.Visible = false;
                //btnAgregarExamen.Visible = false;

                //grd00AntecedentesMorbidos.Columns[2].Visible = false;
                //grdFarmacos.Columns[10].Visible = false;
                //grdAlergias.Columns[2].Visible = false;
                //grdTrastornos.Columns[1].Visible = false;
                //grdSindrome.Columns[1].Visible = false;
                //grdExamenes.Columns[2].Visible = false;

            }
        }

        ModificaFicha(ModificarFicha);

        bool ExisteDerivacionVision = ExisteDerivacionFichaSalud(sqlt, CodFichaSaludInicial, "Vision");
        bool ExisteDerivacionAudicion = ExisteDerivacionFichaSalud(sqlt, CodFichaSaludInicial, "Audicion");
        bool ExisteDerivacionSaludSaludBucal = ExisteDerivacionFichaSalud(sqlt, CodFichaSaludInicial, "SaludBucal");
        bool ExisteDerivacionColumna = ExisteDerivacionFichaSalud(sqlt, CodFichaSaludInicial, "Columna");

        if (ExisteDerivacionVision == true) // existe la ficha de derivación Visión
        {
            if (ModificarFicha == true)
            {
                lblDerivacionVision.Text = "Ver o Modificar Derivación";
                Session["lblDerivacionVision"] = "VerModificar";
            }
            else
            {
                lblDerivacionVision.Text = "Ver Derivación";
                Session["lblDerivacionVision"] = "Ver";
            }

            spanDerivacionVision.Attributes.Remove("class");
            spanDerivacionVision.Attributes.Add("class", "glyphicon glyphicon-eye-open");
        }
        else
        {
            if (ModificarFicha == true)
            {
                lblDerivacionVision.Text = "Agregar Derivación";
                Session["lblDerivacionVision"] = "Agregar"; 
            }
            else
            {
                lnkMostrarDerivacionVision.Visible = false;
                lblDerivacionVision.Visible = false;
                lblSinDerivacionVision.Visible = true;
            }
        }

        if (ExisteDerivacionAudicion == true) // existe la ficha de derivación Visión
        {
            if (ModificarFicha == true)
            {
                lblDerivacionAudicion.Text = "Ver o Modificar Derivación";
                Session["lblDerivacionAudicion"] = "VerModificar";
            }
            else
            {
                lblDerivacionAudicion.Text = "Ver Derivación";
                Session["lblDerivacionAudicion"] = "Ver";
            }

            spanDerivacionAudicion.Attributes.Remove("class");
            spanDerivacionAudicion.Attributes.Add("class", "glyphicon glyphicon-eye-open");
        }
        else
        {
            if (ModificarFicha == true)
            {
                lblDerivacionAudicion.Text = "Agregar Derivación";
                Session["lblDerivacionAudicion"] = "Agregar";
            }
            else
            {
                lnkMostrarDerivacionAudicion.Visible = false;
                lblDerivacionAudicion.Visible = false;
                lblSinDerivacionAudicion.Visible = true;
            }
        }

        if (ExisteDerivacionSaludSaludBucal == true) // existe la ficha de derivación Visión
        {
            if (ModificarFicha == true)
            {
                lblDerivacionSaludBucal.Text = "Ver o Modificar Derivación";
                Session["lblDerivacionSaludBucal"] = "VerModificar";
            }
            else
            {
                lblDerivacionSaludBucal.Text = "Ver Derivación";
                Session["lblDerivacionSaludBucal"] = "Ver";
            }

            spanDerivacionSaludBucal.Attributes.Remove("class");
            spanDerivacionSaludBucal.Attributes.Add("class", "glyphicon glyphicon-eye-open");
        }
        else
        {
            if (ModificarFicha == true)
            {
                lblDerivacionSaludBucal.Text = "Agregar Derivación";
                Session["lblDerivacionSaludBucal"] = "Agregar";
            }
            else
            {
                lnkMostrarDerivacionSaludBucal.Visible = false;
                lblDerivacionSaludBucal.Visible = false;
                lblSinDerivacionSaludBucal.Visible = true;
            }
        }

        if (ExisteDerivacionColumna == true) // existe la ficha de derivación Visión
        {
            if (ModificarFicha == true)
            {
                lblDerivacionColumna.Text = "Ver o Modificar Derivación";
                Session["lblDerivacionColumna"] = "VerModificar";
            }
            else
            {
                lblDerivacionColumna.Text = "Ver Derivación";
                Session["lblDerivacionColumna"] = "Ver";
            }

            spanDerivacionColumna.Attributes.Remove("class");
            spanDerivacionColumna.Attributes.Add("class", "glyphicon glyphicon-eye-open");
        }
        else
        {
            if (ModificarFicha == true)
            {
                lblDerivacionColumna.Text = "Agregar Derivación";
                Session["lblDerivacionColumna"] = "Agregar";
            }
            else
            {
                lnkMostrarDerivacionColumna.Visible = false;
                lblDerivacionColumna.Visible = false;
                lblSinDerivacionColumna.Visible = true;
            }
        }

        int numero;
        bool AntecedentesQuirurgicosyH = Int32.TryParse(dt.Rows[0]["Antecedentes_Quirurgicos_Hospitalizacion"].ToString(), out numero);

        if (AntecedentesQuirurgicosyH)
        {
            txtAntecedentesQuirurgicosyH.Text = "";
        }
        else
        {
            txtAntecedentesQuirurgicosyH.Text = dt.Rows[0]["Antecedentes_Quirurgicos_Hospitalizacion"].ToString();
        }

        DateTime fecha;
        bool FechaDiagnostico = DateTime.TryParse(dt.Rows[0]["FechaDiagnostico"].ToString(), out fecha);

        if (FechaDiagnostico)
        {
            if (fecha.ToShortDateString() == "01-01-1900")
            {
                txtFechaDiagnostico.Text = "";
            }
            else
            {
                txtFechaDiagnostico.Text = Convert.ToDateTime(dt.Rows[0]["FechaDiagnostico"].ToString()).ToShortDateString();
            }
        }

        bool FechaIntervencion = DateTime.TryParse(dt.Rows[0]["FechaIntervencion"].ToString(), out fecha);

        if (FechaIntervencion)
        {
            if (fecha.ToShortDateString() == "01-01-1900")
            {
                txtFechaIntervencion.Text = "";
            }
            else
            {
                txtFechaIntervencion.Text = Convert.ToDateTime(dt.Rows[0]["FechaIntervencion"].ToString()).ToShortDateString();
            }
        }

        bool FechaEvaluacion = DateTime.TryParse(dt.Rows[0]["FechaEvaluacion"].ToString(), out fecha);

        if (FechaEvaluacion)
        {
            if (fecha.ToShortDateString() == "01-01-1900")
            {
                txtFechaEvaluacion.Text = "";
            }
            else
            {
                txtFechaEvaluacion.Text = Convert.ToDateTime(dt.Rows[0]["FechaEvaluacion"].ToString()).ToShortDateString();
            }
        }

        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Transfusiones"]), rbtnTransfusionesSi, rbtnTransfusionesNo);
        ddlAntecedentesGinecoO.Items.FindByValue(ddlAntecedentesGinecoO.SelectedValue).Selected = false;
        ddlAntecedentesGinecoO.Items.FindByValue(dt.Rows[0]["Antecedentes_Gineco_Obstetricos"].ToString()).Selected = true;
        ddlAntecedentesFamiliares.Items.FindByValue(ddlAntecedentesFamiliares.SelectedValue).Selected = false;
        ddlAntecedentesFamiliares.Items.FindByValue(dt.Rows[0]["Antecedentes_Familiares"].ToString()).Selected = true;            
        ddlPA.Items.FindByValue(ddlPA.SelectedValue).Selected = false;
        ddlPA.Items.FindByValue(dt.Rows[0]["PA"].ToString()).Selected = true;  
        ddlPulso.Items.FindByValue(ddlPulso.SelectedValue).Selected = false;
        ddlPulso.Items.FindByValue(dt.Rows[0]["Pulso"].ToString()).Selected = true;
        ddlFR.Items.FindByValue(ddlFR.SelectedValue).Selected = false;
        ddlFR.Items.FindByValue(dt.Rows[0]["FR"].ToString()).Selected = true;
        ddlTemperatura.Items.FindByValue(ddlTemperatura.SelectedValue).Selected = false;
        ddlTemperatura.Items.FindByValue(dt.Rows[0]["T"].ToString()).Selected = true;
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Tranquilo"]), rbtnTranquiloSi, rbtnTranquiloNo);
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Excitado"]),rbtnExcitadoSi,rbtnExcitadoNo);
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Angustiado"]), rbtnAngustiadoSi, rbtnAngustiadoNo);
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Decaido"]), rbtnDecaidoSi, rbtnDecaidoNo);
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Irritable"]),rbtnIrritableSi,rbtnIrritableNo);
        ddlMovilidad.Items.FindByValue(ddlMovilidad.SelectedValue).Selected = false;
        ddlMovilidad.Items.FindByValue(dt.Rows[0]["Movilidad"].ToString()).Selected = true;
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["PresumeConsumoDroga"]), rbtnPresumeConsumoSi, rbtnPresumeConsumoNo);
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["VacunasAlDia"]), rbtnVacunasAlDiaSi, rbtnVacunasAlDiaNo);
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["InscritoAtencionPrimaria"]), rbtnInscritoAtencionPrimariaSi, rbtnInscritoAtencionPrimariaNo);

        int CodRegionEstablecimiento = GetRegionEstablecimiento(Convert.ToInt32(dt.Rows[0]["CodEstablecimiento"]));

        ddlRegionEstablecimiento.SelectedValue = CodRegionEstablecimiento.ToString();

        CargaddlEstablecimiento();       

        ddlEstablecimiento.Items.FindByValue(ddlEstablecimiento.SelectedValue).Selected = false;
        ddlEstablecimiento.Items.FindByValue(dt.Rows[0]["CodEstablecimiento"].ToString()).Selected = true;
        
        bool Peso = Int32.TryParse(dt.Rows[0]["Peso"].ToString(), out numero);

        if (Peso)
        {
            if (numero == -1)
            {
                txtPeso.Text = "";
            }
            else
            {
                txtPeso.Text = dt.Rows[0]["Peso"].ToString();
            }
        }
        else
        {
            txtPeso.Text = dt.Rows[0]["Peso"].ToString();
        }
        
        bool talla = Int32.TryParse(dt.Rows[0]["Talla"].ToString(), out numero);

        if (talla)
        {
            if (numero == -1)
            {
                txtTalla.Text = "";
            }
            else
            {
                txtTalla.Text = dt.Rows[0]["Talla"].ToString();
            }
        }
        else
        {
            txtTalla.Text = dt.Rows[0]["Talla"].ToString();
        }

        bool IMC = Int32.TryParse(dt.Rows[0]["IMC"].ToString(), out numero);
        if (IMC)
        {
            if (numero == -1)
            {
                txtIMC.Text = "";
            }
            else
            {
                txtIMC.Text = dt.Rows[0]["IMC"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "calculaIMC", "calculaIMC();", true);
            }
        }
        else
        {
            txtIMC.Text = dt.Rows[0]["IMC"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "calculaIMC", "calculaIMC();", true);
        }

        ddlPerimetroCintura.Items.FindByValue(ddlPerimetroCintura.SelectedValue).Selected = false;
        ddlPerimetroCintura.Items.FindByValue(dt.Rows[0]["PerimetroCintura"].ToString()).Selected = true;
        ddlPerimetroCraneano.Items.FindByValue(ddlPerimetroCraneano.SelectedValue).Selected = false;
        ddlPerimetroCraneano.Items.FindByValue(dt.Rows[0]["PerimetroCraneano"].ToString()).Selected = true;
        ddlTallaEdad.Items.FindByValue(ddlTallaEdad.SelectedValue).Selected = false;
        ddlTallaEdad.Items.FindByValue(dt.Rows[0]["TallaEdad"].ToString()).Selected = true;

        bool PesoTalla = Int32.TryParse(dt.Rows[0]["PesoTalla"].ToString(), out numero);
        if (PesoTalla)
        {
            if (numero == -1)
            {
                txtPesoTalla.Text = "";
            }
            else
            {
                txtPesoTalla.Text = dt.Rows[0]["PesoTalla"].ToString();   
            }
        }
        else
        {
            txtPesoTalla.Text = dt.Rows[0]["PesoTalla"].ToString();   
        }

        bool PesoEdad = Int32.TryParse(dt.Rows[0]["PesoEdad"].ToString(), out numero);

        if (PesoEdad)
        {
            if (numero == -1)
            {
                txtPesoEdad.Text = "";
            }
            else
            {
                txtPesoEdad.Text = dt.Rows[0]["PesoEdad"].ToString();
            }
        }
        else
        {
            txtPesoEdad.Text = dt.Rows[0]["PesoEdad"].ToString();
        }
       
        ddlEstadoNutricional.Items.FindByValue(ddlEstadoNutricional.SelectedValue).Selected = false;
        ddlEstadoNutricional.Items.FindByValue(dt.Rows[0]["EstadoNutricional"].ToString()).Selected = true;        
        ddlDesarrolloCognitivo.Items.FindByValue(ddlDesarrolloCognitivo.SelectedValue).Selected = false;
        ddlDesarrolloCognitivo.Items.FindByValue(dt.Rows[0]["DesarrolloCognitivo"].ToString()).Selected = true;        
        ddlComunicacion.Items.FindByValue(ddlComunicacion.SelectedValue).Selected = false;
        ddlComunicacion.Items.FindByValue(dt.Rows[0]["Comunicacion"].ToString()).Selected = true;        
        ddlDesarrolloSocioEmocional.Items.FindByValue(ddlDesarrolloSocioEmocional.SelectedValue).Selected = false;
        ddlDesarrolloSocioEmocional.Items.FindByValue(dt.Rows[0]["DesarrolloSocioEmocional"].ToString()).Selected = true;       

        if (dt.Rows[0]["ProximoControl"].ToString() != "01-01-1900 0:00:00")
        {
            txtProximoControl.Text = Convert.ToDateTime(dt.Rows[0]["ProximoControl"].ToString()).ToShortDateString();
        }
        else
        {
            txtProximoControl.Text = "";
        }
        
        ddlGradosTunner.Items.FindByValue(ddlGradosTunner.SelectedValue).Selected = false;
        ddlGradosTunner.Items.FindByValue(dt.Rows[0]["GradosTunner"].ToString()).Selected = true;
       
        ddlEvaluacionOrtopedica.Items.FindByValue(ddlEvaluacionOrtopedica.SelectedValue).Selected = false;
        ddlEvaluacionOrtopedica.Items.FindByValue(dt.Rows[0]["EvaluacionOrtopedica"].ToString()).Selected = true;
       
        ddlDisplaciaCadera.Items.FindByValue(ddlDisplaciaCadera.SelectedValue).Selected = false;
        ddlDisplaciaCadera.Items.FindByValue(dt.Rows[0]["DisplaciaCadera"].ToString()).Selected = true;
        
        ddlColor.Items.FindByValue(ddlColor.SelectedValue).Selected = false;
        ddlColor.Items.FindByValue(dt.Rows[0]["Color"].ToString()).Selected = true;
        
        ddlHumedad.Items.FindByValue(ddlHumedad.SelectedValue).Selected = false;
        ddlHumedad.Items.FindByValue(dt.Rows[0]["Humedad"].ToString()).Selected = true;
        
        ddlCabeza.Items.FindByValue(ddlCabeza.SelectedValue).Selected = false;
        ddlCabeza.Items.FindByValue(dt.Rows[0]["Cabeza"].ToString()).Selected = true;
        
        ddlCuello.Items.FindByValue(ddlCuello.SelectedValue).Selected = false;
        ddlCuello.Items.FindByValue(dt.Rows[0]["Cuello"].ToString()).Selected = true;
        
        ddlTorax.Items.FindByValue(ddlTorax.SelectedValue).Selected = false;
        ddlTorax.Items.FindByValue(dt.Rows[0]["Torax"].ToString()).Selected = true;
        
        ddlAbdomen.Items.FindByValue(ddlAbdomen.SelectedValue).Selected = false;
        ddlAbdomen.Items.FindByValue(dt.Rows[0]["Abdomen"].ToString()).Selected = true;
        
        ddlExtremidades.Items.FindByValue(ddlExtremidades.SelectedValue).Selected = false;
        ddlExtremidades.Items.FindByValue(dt.Rows[0]["Extremidades"].ToString()).Selected = true;
        
        ddlSintomaExtremidades.Items.FindByValue(ddlSintomaExtremidades.SelectedValue).Selected = false;
        ddlSintomaExtremidades.Items.FindByValue(dt.Rows[0]["Sintoma"].ToString()).Selected = true;
        
        ddlGenitales.Items.FindByValue(ddlGenitales.SelectedValue).Selected = false;
        ddlGenitales.Items.FindByValue(dt.Rows[0]["Genitales"].ToString()).Selected = true;
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["GenuValgo"]), rbtnGenuValgoSi, rbtnGenuValgoNo);
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["GenuVaro"]), rbtnGenuVaroSi, rbtnGenuVaroNo);
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["PiePlano"]), rbtnPiePlanoSi, rbtnPiePlanoNo);
        
        ddlMarcha.Items.FindByValue(ddlMarcha.SelectedValue).Selected = false;
        ddlMarcha.Items.FindByValue(dt.Rows[0]["Marcha"].ToString()).Selected = true;
        
        ddlVision.Items.FindByValue(ddlVision.SelectedValue).Selected = false;
        ddlVision.Items.FindByValue(dt.Rows[0]["Vision"].ToString()).Selected = true;
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Lentes"]), rbtnLentesSi, rbtnLentesNo);        
        
        ddlAudicion.Items.FindByValue(ddlAudicion.SelectedValue).Selected = false;
        ddlAudicion.Items.FindByValue(dt.Rows[0]["Audicion"].ToString()).Selected = true;            
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Audifonos"]), rbtnAudifonosSi, rbtnAudifonosNo);
        
        ddlSaludBucal.Items.FindByValue(ddlSaludBucal.SelectedValue).Selected = false;
        ddlSaludBucal.Items.FindByValue(dt.Rows[0]["SaludBucal"].ToString()).Selected = true;
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Ortodoncia"]), rbtnOrtodonciaSi, rbtnOrtodonciaNo);
        
        ddlColumna.Items.FindByValue(ddlColumna.SelectedValue).Selected = false;
        ddlColumna.Items.FindByValue(dt.Rows[0]["Columna"].ToString()).Selected = true;
        
        ddlConductaSexual.Items.FindByValue(ddlConductaSexual.SelectedValue).Selected = false;
        ddlConductaSexual.Items.FindByValue(dt.Rows[0]["ConductaSexual"].ToString()).Selected = true;
        
        if (dt.Rows[0]["Menarquia"].ToString() != "01-01-1900 0:00:00")
        {
            txtMenarquia.Text = Convert.ToDateTime(dt.Rows[0]["Menarquia"].ToString()).ToShortDateString();
        }
        else
        {
            txtMenarquia.Text = "";
        }

        bool Ciclos = Int32.TryParse(dt.Rows[0]["Ciclos"].ToString(), out numero);

        if (Ciclos)
        {
            if (numero == -1)
            {
                txtCiclos.Text = "";
            }
            else
            {
                txtCiclos.Text = dt.Rows[0]["Ciclos"].ToString();
            }
        }
        else
        {
            txtCiclos.Text = dt.Rows[0]["Ciclos"].ToString();
        }

        bool FO = Int32.TryParse(dt.Rows[0]["FO"].ToString(), out numero);

        if (FO)
        {
            if(numero == -1)
            {
                txtFO.Text = "";
            }
            else
            {
                txtFO.Text = dt.Rows[0]["FO"].ToString();
            }
        }
        else
        {
            txtFO.Text = dt.Rows[0]["FO"].ToString();
        }
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["Abortos"]), rbtnAbortosSi, rbtnAbortosNo);
        
        if (dt.Rows[0]["FUR"].ToString() != "01-01-1900 0:00:00") 		

        {
            txtFUR.Text = Convert.ToDateTime(dt.Rows[0]["FUR"].ToString()).ToShortDateString();
        }
        else
        {
            txtFUR.Text = "";
        }
        
        SetRadioButton(Convert.ToInt32(dt.Rows[0]["IdeacionSuicida"]), rbtnIdeacionSuicidaSi, rbtnIdeacionSuicidaNo);

        bool HistoriaClinicaEvolutiva = Int32.TryParse(dt.Rows[0]["HistoriaClinicaEvolutiva"].ToString(), out numero);

        if (HistoriaClinicaEvolutiva)
        {
            if (numero == -1)
            {
                txtHistoriaClinicaEvolutiva.Text = "";
            }
            else
            {
                txtHistoriaClinicaEvolutiva.Text = dt.Rows[0]["HistoriaClinicaEvolutiva"].ToString();
            }
        }
        else
        {
            txtHistoriaClinicaEvolutiva.Text = dt.Rows[0]["HistoriaClinicaEvolutiva"].ToString();
        }

        //DTExamenes.Columns.Add(new DataColumn("DescripcionTipoExamen", typeof(string)));
        //DTExamenes.Columns.Add(new DataColumn("CodTipoExamen", typeof(int)));
        //DTExamenes.Columns.Add(new DataColumn("DescripcionExamen", typeof(string)));
        //DTExamenes.Columns.Add(new DataColumn("CodExamen", typeof(int)));

        DataTable DatatableExamenes = GetExamenes(sqlt, CodFichaSaludInicial);

        if (DatatableExamenes.Rows.Count > 0)
        {
            for (int i = 0; i < DatatableExamenes.Rows.Count; i++)
            {
                DataRow dr = DTExamenes.NewRow();
                dr[0] = DatatableExamenes.Rows[i][0].ToString();
                dr[1] = Convert.ToInt32(DatatableExamenes.Rows[i][1]);
                dr[2] = DatatableExamenes.Rows[i][2].ToString();
                dr[3] = Convert.ToInt32(DatatableExamenes.Rows[i][3]);
                DTExamenes.Rows.Add(dr);
            }
            DataView dv = new DataView(DTExamenes);
            grdExamenes.DataSource = dv;
            dv.Sort = "CodExamen";
            grdExamenes.DataBind();

            grdExamenes.Visible = true;
            trExamenes.Visible = true;
            lbl_avisoExamen.Visible = false;

        }



        DataTable DataTableAntecedentesMorbidos = (GetAmmamnesisRemota(sqlt, querytype.AntecedentesMorbidos, CodFichaSaludInicial));

        if (DataTableAntecedentesMorbidos.Rows.Count > 0)
        {
            for (int i = 0; i < DataTableAntecedentesMorbidos.Rows.Count; i++)
            {
                DataRow dr = DTAntecedentesMorbidos.NewRow();
                dr[0] = DataTableAntecedentesMorbidos.Rows[i][0].ToString();
                dr[1] = DataTableAntecedentesMorbidos.Rows[i][1].ToString();
                dr[2] = Convert.ToInt32(DataTableAntecedentesMorbidos.Rows[i][2]);                 
                DTAntecedentesMorbidos.Rows.Add(dr);
            }

            DataView dv = new DataView(DTAntecedentesMorbidos);
            grd00AntecedentesMorbidos.DataSource = dv;
            dv.Sort = "CodAntecedenteMorbido";
            grd00AntecedentesMorbidos.DataBind();

            rbtnTratamientoSi.Checked = false;
            rbtnTratamientoNo.Checked = false;
            grd00AntecedentesMorbidos.Visible = true;
            trAntecedentesMorbidos.Visible = true;
            ddlAntecedentesMorbidos.SelectedValue = Convert.ToString(0);
            ddlAntecedentesMorbidos.BackColor = System.Drawing.Color.Empty;
            trAvisoAntecedentesMorbidos.Visible = false;
        }

        DataTable DataTableFarmacos = GetAmmamnesisRemota(sqlt, querytype.Farmacos, CodFichaSaludInicial);

        if (DataTableFarmacos.Rows.Count > 0)
        {
            for (int i = 0; i < DataTableFarmacos.Rows.Count; i++)
            {
                DataRow dr = DTFarmacos.NewRow();
                dr[0] = DataTableFarmacos.Rows[i][0].ToString();
                dr[1] = DataTableFarmacos.Rows[i][1].ToString();
                dr[2] = DataTableFarmacos.Rows[i][2].ToString();
                dr[3] = DataTableFarmacos.Rows[i][3].ToString();
                dr[4] = DataTableFarmacos.Rows[i][4].ToString();
                dr[5] = DataTableFarmacos.Rows[i][5].ToString();
                dr[6] = DataTableFarmacos.Rows[i][6].ToString();
                dr[7] = DataTableFarmacos.Rows[i][7].ToString();
                dr[8] = DataTableFarmacos.Rows[i][8].ToString();
                dr[9] = DataTableFarmacos.Rows[i][9].ToString();
                dr[10] = DataTableFarmacos.Rows[i][10].ToString();                

                DTFarmacos.Rows.Add(dr);
            }
            
            DataView dv = new DataView(DTFarmacos);
            grdFarmacos.DataSource = dv;
            dv.Sort = "CodFarmaco";
            grdFarmacos.DataBind();
            grdFarmacos.Visible = true;
            trFarmacos.Visible = true;
            ddlFarmacos.SelectedValue = Convert.ToString(0);
            thOtrosFarmacos.Visible = false;
            tdOtrosFarmacos.Visible = false;
            thRellenoFarmacosOtros.Visible = true;
            tdRellenoFarmacosOtros.Visible = true;
            txtOtrosFarmacos.Text = "";
            ddlPresentacionFarmaco.SelectedValue = Convert.ToString(0);            
            trAvisoFarmaco.Visible = false;
            chkManana.Checked = false;
            chkTarde.Checked = false;
            chkNoche.Checked = false;
            txtManana.Enabled = false;
            txtTarde.Enabled = false;
            txtNoche.Enabled = false;
            txtManana.Text = "";
            txtTarde.Text = "";
            txtNoche.Text = "";
        }

        DataTable DataTableAlergias = GetAmmamnesisRemota(sqlt, querytype.Alergias, CodFichaSaludInicial);

        if (DataTableAlergias.Rows.Count > 0)
        {
            for (int i = 0; i < DataTableAlergias.Rows.Count; i++)
            {
                DataRow dr = DTAlergias.NewRow();
                dr[0] = DataTableAlergias.Rows[i][0].ToString();
                dr[1] = DataTableAlergias.Rows[i][1].ToString();
                dr[2] = DataTableAlergias.Rows[i][2].ToString();

                DTAlergias.Rows.Add(dr);
            }

            DataView dv = new DataView(DTAlergias);
            grdAlergias.DataSource = dv;
            dv.Sort = "DescripcionAlergia";
            grdAlergias.DataBind();
            grdAlergias.Visible = true;
            trAlergias.Visible = true;
            ddlAlergias.SelectedValue = Convert.ToString(0);
            txtOtrasAlergias.Text = "";
            thOtrasAlergias.Visible = false;
            tdOtrasAlergias.Visible = false;
            threllenoAlergiasOtros.Visible = true;
            tdrellenoAlergiasOtros.Visible = true;
            trAvisoAlergias.Visible = false;
        }

        DataTable DataTableTrastornos = GetAmmamnesisRemota(sqlt, querytype.Trastornos, CodFichaSaludInicial);
        
        if (DataTableTrastornos.Rows.Count > 0)
        {
            for (int i = 0; i < DataTableTrastornos.Rows.Count; i++)
            {
			    DataRow dr = DTTrastornos.NewRow();
                dr[0] = DataTableTrastornos.Rows[i][0].ToString();
                dr[1] = DataTableTrastornos.Rows[i][1].ToString();

                DTTrastornos.Rows.Add(dr);
		    }
                DataView dv = new DataView(DTTrastornos);
                grdTrastornos.DataSource = dv;
                dv.Sort = "DescripcionTrastornos";
                grdTrastornos.DataBind();
                grdTrastornos.Visible = true;
                trTrastornos.Visible = true;
                ddlTrastornos.SelectedValue = Convert.ToString(0);
                trAvisoTrastornos.Visible = false;
        }

        DataTable DataTableSindromes = GetAmmamnesisRemota(sqlt, querytype.Sindromes, CodFichaSaludInicial);

        if ( DataTableSindromes.Rows.Count > 0)
        {
            for (int i = 0; i < DataTableSindromes.Rows.Count; i++)
			{
			    DataRow dr = DTSindromes.NewRow();
                dr[0] = DataTableSindromes.Rows[i][0].ToString();
                dr[1] = DataTableSindromes.Rows[i][1].ToString();

                DTSindromes.Rows.Add(dr);
			}
                DataView dv = new DataView(DTSindromes);
                grdSindrome.DataSource = dv;
                dv.Sort = "DescripcionSindrome";
                grdSindrome.DataBind();
                grdSindrome.Visible = true;
                trSindrome.Visible = true;
                ddlSindromes.SelectedValue = Convert.ToString(0);
                lbl_avisoSindrome.Visible = false;
        }
        

    }
    private void GuardarObtenerDiagGeneral()
    {
        ninocoll ncoll = new ninocoll();

        SqlTransaction sqlt;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {
            int CodDiagnostico = GetCodDiagnosticoSaludFichaInicial(sqlt, querytype.DiagnosticoGeneral);             

            if (CodDiagnostico == 0) // no existe diagnostico general por lo que se guarda uno nuevo
            {
                if (!window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B") && window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                {
                    int inden = Insert_DiagnosticoGeneral(sqlt, 11, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(DateTime.Now));
                    Session["CodDiagnostico"] = inden;

                    btnGuardarDatosRelevantes.Visible = true;
                    btnGuardar.Visible = true;
                    btnGuardar2.Visible = true;
                    btnGuardar3.Visible = true;
                    btnGuardarFinal.Visible = true;

                    CodDiagnostico = inden;
                }

                else
                {
                    divContenidoFicha.Visible = false;
                    divAlertaFicha.Visible = true;
                    lblAlertaFicha.Text = "No Existe Ficha de Salud Inicial.";

                }

            }

            if (CodDiagnostico > 0)//  verifica que existe o se generó de forma correcta
            {
                int CodFichaSaludInicial = GetCodDiagnosticoSaludFichaInicial(sqlt, querytype.FichaSaludInicial);

                Session["CodDiagnostico"] = CodDiagnostico;
                Session["CodFichaSaludInicial"] = CodFichaSaludInicial;                

                if (CodFichaSaludInicial > 0) // verifica que existe la ficha de salud inicial
                {
                    GetDatosDiagosticoFichaSaludInicial(sqlt, CodFichaSaludInicial);
                }

                if (CodFichaSaludInicial == 0)
                {
                    if (!window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B") && window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
                    {
                        btnGuardarDatosRelevantes.Visible = true;
                        btnGuardar.Visible = true;
                        btnGuardar2.Visible = true;
                        btnGuardar3.Visible = true;
                        btnGuardarFinal.Visible = true;  
                    }

                    ViewState["FechaIngresoFichaInicial"] = DateTime.Now;
                    ViewState["IdUsuarioIngresoFicha"] = Session["IdUsuario"];
                }               
                
            }

            if (CodDiagnostico == -1)// ERROR hay mas de un diagnóstico de ficha de salud Inicial por niño 
            {
                Response.Write("<script language='javascript'>alert('ERROR, hay mas de un diagnóstico de ficha de salud Inicial. Por favor contactarse con mesa de ayuda. ');</script>");
            }            
            
            sqlt.Commit();
            sconn.Close();
            divFichaSalud.Visible = true;
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

    private bool ValidaExamenFisicoPielMucosas()
    {
        string sexo = txtSexo.Text;
        bool rechazo = false;

        if (ValidaDropDownList(ddlColor))
        { rechazo = true; }

        if (ValidaDropDownList(ddlHumedad))
        { rechazo = true; }

        if (ValidaDropDownList(ddlCabeza))
        { rechazo = true; }

        if (ValidaDropDownList(ddlCuello))
        { rechazo = true; }

        if (ValidaDropDownList(ddlTorax))
        { rechazo = true; }

        if (ValidaDropDownList(ddlAbdomen))
        { rechazo = true; }

        if (ValidaDropDownList(ddlExtremidades))
        { rechazo = true; }

        if (ValidaDropDownList(ddlSintomaExtremidades))
        { rechazo = true; }

        if (sexo != "")
        {
            if (sexo == "Masculino")
            {
                if (ValidaDropDownList(ddlGenitales))
                { rechazo = true; }

                if (ValidaDropDownList(ddlEvaluacionGenitales))
                { rechazo = true; }
            }

            //if (sexo == "Femenino")
            //{
            //    if (ValidaTextBox(txtMenarquia))
            //    { rechazo = true; }

            //    if (ValidaTextBox(txtCiclos))
            //    { rechazo = true; }

            //    if (ValidaTextBox(txtFO))
            //    { rechazo = true; }

            //    if (ValidaRadioButton(rbtnAbortosSi, rbtnAbortosNo))
            //    { rechazo = true; }

            //    if (ValidaTextBox(txtFUR))
            //    { rechazo = true; }
            //}
        }

        if (ValidaRadioButton(rbtnGenuValgoSi, rbtnGenuValgoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnGenuVaroSi, rbtnGenuVaroNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnPiePlanoSi, rbtnPiePlanoNo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlMarcha))
        { rechazo = true; }

        if (ValidaDropDownList(ddlVision))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnLentesSi, rbtnLentesNo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlAudicion))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnAudifonosSi, rbtnAudifonosNo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlSaludBucal))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnOrtodonciaSi, rbtnOrtodonciaNo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlColumna))
        { rechazo = true; }

        if (ValidaDropDownList(ddlConductaSexual))
        { rechazo = true; }

        if (rechazo)
        {
            iconExamenFisicoPiel.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
        }
        else
        {
            iconExamenFisicoPiel.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
        }

        return rechazo;
    }

    private bool ValidaExamenFisicoConciencia()
    {
        int edad = Convert.ToInt32(txtEdad.Text);

        bool rechazo = false;        

        if (ValidaRadioButton(rbtnTranquiloSi, rbtnTranquiloNo))
        {  rechazo = true;  }

        if (ValidaRadioButton(rbtnExcitadoSi, rbtnExcitadoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnAngustiadoSi,rbtnAngustiadoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnDecaidoSi, rbtnDecaidoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnIrritableSi, rbtnIrritableNo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlPA))
        { rechazo = true; }

        if (ValidaDropDownList(ddlPulso))
        { rechazo = true; }

        if (ValidaDropDownList(ddlFR))
        { rechazo = true; }

        if (ValidaDropDownList(ddlTemperatura))
        { rechazo = true; }

        if (ValidaDropDownList(ddlMovilidad))
        { rechazo = true; }

        if (ValidaTextBox(txtPeso))
        { rechazo = true; }

        if (ValidaTextBox(txtTalla))
        { rechazo = true; }

        if (ValidaDropDownList(ddlPerimetroCintura))
        { rechazo = true; }

        if (edad >= 14)
        {
            if (ValidaTextBox(txtIMC))
            { rechazo = true; }
        }

        if (edad < 14)
        {
            if (ValidaDropDownList(ddlPerimetroCraneano))
            { rechazo = true; }

            if (ValidaDropDownList(ddlTallaEdad))
            { rechazo = true; }

            if (ValidaTextBox(txtPesoTalla))
            { rechazo = true; }

            if (ValidaTextBox(txtPesoEdad))
            { rechazo = true; }
        }

        if (ValidaDropDownList(ddlEstadoNutricional))
        { rechazo = true; }

        if (ValidaDropDownList(ddlDesarrolloCognitivo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlComunicacion))
        { rechazo = true; }

        if (ValidaDropDownList(ddlDesarrolloSocioEmocional))
        { rechazo = true; }

        if (ValidaTextBox(txtProximoControl))
        { rechazo = true; }

        if (edad < 6)
        {
            if (ValidaDropDownList(ddlGradosTunner))
            { rechazo = true; }
        }

        if (ValidaDropDownList(ddlEvaluacionOrtopedica))
        { rechazo = true; }

        if (ValidaDropDownList(ddlDisplaciaCadera))
        { rechazo = true; }

        if (rechazo)
        {
            iconExamenFisicoConciencia.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
        }
        else
        {
            iconExamenFisicoConciencia.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
        }

        return rechazo;
    }


    private bool ValidaDatosRelevantes()
    {
        bool rechazo = false;
        if (ValidaRadioButton(rbtnInscritoAtencionPrimariaSi, rbtnInscritoAtencionPrimariaNo))
        { rechazo = true; }

        if (ValidaDropDownList(ddlRegionEstablecimiento))
        { rechazo = true; }

        if (ValidaDropDownList(ddlEstablecimiento))
        { rechazo = true; }        

        if (rechazo)
        {
            iconDatosRelevantes.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
        }
        else
        {
            iconDatosRelevantes.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
        }

        return rechazo;
    }

    private bool ValidaAnamnesis()
    {
        bool rechazo = false;
        int edad = Convert.ToInt32(txtEdad.Text);

        if (ValidaRadioButton(rbtnPresumeConsumoSi, rbtnPresumeConsumoNo))
        { rechazo = true; }

        if (ValidaRadioButton(rbtnIdeacionSuicidaSi, rbtnIdeacionSuicidaNo))
        { rechazo = true; }


        if (edad < 6)
        {
            if (ValidaRadioButton(rbtnVacunasAlDiaSi, rbtnVacunasAlDiaNo))
            { rechazo = true; }
        }

        if (ValidaRadioButton(rbtnTransfusionesSi, rbtnTransfusionesNo))
        { rechazo = true; }

        if (rechazo)
        {
            iconAnamnesis.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
        }
        else
        {
            iconAnamnesis.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
        }

        return rechazo;
    }

    private bool ValidaFechas()
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (txtFechaDiagnostico.Text == "" || !RangeValidator4.IsValid)
        {
            txtFechaDiagnostico.BackColor = colorCampoObligatorio;
            rechazo = true;
        }
        else
        {
            txtFechaDiagnostico.BackColor = System.Drawing.Color.Empty;
        }

        if (txtFechaIntervencion.Text == "" || !RangeValidator8.IsValid)
        {
            txtFechaIntervencion.BackColor = colorCampoObligatorio;
            rechazo = true;
        }
        else
        {
            txtFechaIntervencion.BackColor = System.Drawing.Color.Empty;
        }

        if (txtFechaEvaluacion.Text == "" || !RangeValidator9.IsValid)
        {
            txtFechaEvaluacion.BackColor = colorCampoObligatorio;
            rechazo = true;
        }
        else
        {
            txtFechaEvaluacion.BackColor = System.Drawing.Color.Empty;
        }

        return rechazo;
    }
    private void GuardarFichaSaludInicial(guardadotype Tipo)
    {
        DateTime FechaDiagnostico;
        DateTime FechaIntervencion;
        DateTime FechaEvaluacion;

        bool GuardadoFinal = false;
        bool RechazoGuardadoFicha = true;

        if (Tipo == guardadotype.DatosRelevantes || Tipo == guardadotype.Anamnesis || Tipo == guardadotype.ExamenFisicoConciencia || Tipo == guardadotype.ExamenFisicoPiel)
        {
            int GuardadoCompleto = GetBoolFichaCompletaSaludFichaInicial();

            if (GuardadoCompleto == 1)
            {                
                bool validafechas = ValidaFechas();
                bool validadatosrelevantes = ValidaDatosRelevantes();
                bool validaAnamnesis = ValidaAnamnesis();
                bool validaExamenFisicoConciencia = ValidaExamenFisicoConciencia();
                bool validaExamenFisicoPielMucosas = ValidaExamenFisicoPielMucosas();

                if (!validafechas && !validadatosrelevantes && !validaAnamnesis && !validaExamenFisicoConciencia && !validaExamenFisicoPielMucosas)
                {
                    RechazoGuardadoFicha = false;
                    GuardadoFinal = true;
                }
            }
            else
            {
                if (Tipo == guardadotype.DatosRelevantes)
                {
                    if (!ValidaDatosRelevantes())
                    {                        
                        RechazoGuardadoFicha = false;
                    }
                }

                if (Tipo == guardadotype.Anamnesis)
                {
                    if (!ValidaAnamnesis())
                    {
                        RechazoGuardadoFicha = false;
                    }
                }

                if (Tipo == guardadotype.ExamenFisicoConciencia)
                {
                    if (!ValidaExamenFisicoConciencia())
                    {
                        RechazoGuardadoFicha = false;
                    }
                }

                if (Tipo == guardadotype.ExamenFisicoPiel)
                {
                    if (!ValidaExamenFisicoPielMucosas())
                    {
                        RechazoGuardadoFicha = false;
                    }
                }
            }
        }
        else
        {
            if (Tipo == guardadotype.Completo)
            {
                bool validafechas = ValidaFechas();
                bool validadatosrelevantes = ValidaDatosRelevantes();
                bool validaAnamnesis = ValidaAnamnesis();
                bool validaExamenFisicoConciencia = ValidaExamenFisicoConciencia();
                bool validaExamenFisicoPielMucosas = ValidaExamenFisicoPielMucosas();

                if (!validafechas && !validadatosrelevantes && !validaAnamnesis && !validaExamenFisicoConciencia && !validaExamenFisicoPielMucosas)
                {
                    RechazoGuardadoFicha = false;
                    GuardadoFinal = true;
                }
            }
        }

        if (RechazoGuardadoFicha == false || Tipo == guardadotype.Derivacion)
        {

            if (txtFechaDiagnostico.Text == "")
            {
                FechaDiagnostico = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                FechaDiagnostico = Convert.ToDateTime(txtFechaDiagnostico.Text);
            }

            if (txtFechaIntervencion.Text == "")
            {
                FechaIntervencion = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                FechaIntervencion = Convert.ToDateTime(txtFechaIntervencion.Text);
            }


            if (txtFechaEvaluacion.Text == "")
            {
                FechaEvaluacion = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                FechaEvaluacion = Convert.ToDateTime(txtFechaEvaluacion.Text);
            }


            bool Insert = false;
            bool Update = false;


            divAlertaFicha.Visible = false;
            lblAlertaFicha.Text = "";

            int CodDiagnostico = Convert.ToInt32(Session["CodDiagnostico"]);

            SqlTransaction sqlt;
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            sconn.Open();
            sqlt = sconn.BeginTransaction();
            try
            {
                int ExisteFichaSalud = GetCodDiagnosticoSaludFichaInicial(sqlt, querytype.FichaSaludInicial);

                if (ExisteFichaSalud == 0)
                {
                    int CodFichaSaludInicial = InsertFichaSaludInicial(
                    sqlt,
                    CodDiagnostico,
                    FechaDiagnostico,
                    FechaIntervencion,
                    FechaEvaluacion,
                    GetTexBox(txtAntecedentesQuirurgicosyH),
                    GetRadioButton(rbtnTransfusionesSi, rbtnTransfusionesNo),
                    Convert.ToInt32(ddlAntecedentesGinecoO.SelectedValue),
                    Convert.ToInt32(ddlAntecedentesFamiliares.SelectedValue),
                    Convert.ToInt32(ddlPA.SelectedValue),
                    Convert.ToInt32(ddlPulso.SelectedValue),
                    Convert.ToInt32(ddlFR.SelectedValue),
                    Convert.ToInt32(ddlTemperatura.SelectedValue),
                    GetRadioButton(rbtnTranquiloSi, rbtnTranquiloNo),
                    GetRadioButton(rbtnExcitadoSi, rbtnExcitadoNo),
                    GetRadioButton(rbtnAngustiadoSi, rbtnAngustiadoNo),
                    GetRadioButton(rbtnDecaidoSi, rbtnDecaidoNo),
                    GetRadioButton(rbtnIrritableSi, rbtnIrritableNo),
                    Convert.ToInt32(ddlMovilidad.SelectedValue),
                    Convert.ToInt32(GetTexBox(txtPeso)),
                    Convert.ToInt32(GetTexBox(txtTalla)),
                    Convert.ToString(GetTexBox(txtIMC)),
                    Convert.ToInt32(ddlPerimetroCintura.SelectedValue),
                    Convert.ToInt32(ddlPerimetroCraneano.SelectedValue),
                    Convert.ToInt32(ddlTallaEdad.SelectedValue),
                    GetTexBox(txtPesoTalla),
                    GetTexBox(txtPesoEdad),
                    Convert.ToInt32(ddlEstadoNutricional.SelectedValue),
                    Convert.ToInt32(ddlDesarrolloCognitivo.SelectedValue),
                    Convert.ToInt32(ddlComunicacion.SelectedValue),
                    Convert.ToInt32(ddlDesarrolloSocioEmocional.SelectedValue),
                    Convert.ToDateTime(GetDateTime(txtProximoControl)),
                    Convert.ToInt32(ddlGradosTunner.SelectedValue),
                    Convert.ToInt32(ddlEvaluacionOrtopedica.SelectedValue),
                    Convert.ToInt32(ddlDisplaciaCadera.SelectedValue),
                    Convert.ToInt32(ddlColor.SelectedValue),
                    Convert.ToInt32(ddlHumedad.SelectedValue),
                    Convert.ToInt32(ddlCabeza.SelectedValue),
                    Convert.ToInt32(ddlCuello.SelectedValue),
                    Convert.ToInt32(ddlTorax.SelectedValue),
                    Convert.ToInt32(ddlAbdomen.SelectedValue),
                    Convert.ToInt32(ddlExtremidades.SelectedValue),
                    Convert.ToInt32(ddlSintomaExtremidades.SelectedValue),
                    Convert.ToInt32(ddlGenitales.SelectedValue),
                    GetRadioButton(rbtnGenuValgoSi, rbtnGenuValgoNo),
                    GetRadioButton(rbtnGenuVaroSi, rbtnGenuVaroNo),
                    GetRadioButton(rbtnPiePlanoSi, rbtnPiePlanoNo),
                    Convert.ToInt32(ddlMarcha.SelectedValue),
                    Convert.ToInt32(ddlVision.SelectedValue),
                    GetRadioButton(rbtnLentesSi, rbtnLentesNo),
                    Convert.ToInt32(ddlAudicion.SelectedValue),
                    GetRadioButton(rbtnAudifonosSi, rbtnAudifonosNo),
                    Convert.ToInt32(ddlSaludBucal.SelectedValue),
                    GetRadioButton(rbtnOrtodonciaSi, rbtnOrtodonciaNo),
                    Convert.ToInt32(ddlColumna.SelectedValue),
                    Convert.ToInt32(ddlConductaSexual.SelectedValue),
                    Convert.ToDateTime(GetDateTime(txtMenarquia)),
                    Convert.ToInt32(GetTexBox(txtCiclos)),
                    GetTexBox(txtFO),
                    GetRadioButton(rbtnAbortosSi, rbtnAbortosNo),
                    Convert.ToDateTime(GetDateTime(txtFUR)),
                        //GetRadioButton(rbtnIntentoSuicidaSi, rbtnIntentoSuicidaNo),
                    GetRadioButton(rbtnIdeacionSuicidaSi, rbtnIdeacionSuicidaNo),
                    GetTexBox(txtHistoriaClinicaEvolutiva),
                    Convert.ToDateTime(DateTime.Now),
                    Convert.ToInt32(Session["IdUsuario"]),
                    Convert.ToDateTime(DateTime.Now),
                    GetRadioButton(rbtnPresumeConsumoSi, rbtnPresumeConsumoNo),
                    GuardadoFinal,
                    GetRadioButton(rbtnVacunasAlDiaSi, rbtnVacunasAlDiaNo),
                    GetRadioButton(rbtnInscritoAtencionPrimariaSi, rbtnInscritoAtencionPrimariaNo),
                    Convert.ToInt32(ddlEstablecimiento.SelectedValue));
                    

                    // inserta farmacos, alergias, trastorno y sindromes

                    if (DTAntecedentesMorbidos.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTAntecedentesMorbidos.Rows.Count; i++)
                        {
                            int CodAntecedenteMorbido = Convert.ToInt32(DTAntecedentesMorbidos.Rows[i]["CodAntecedenteMorbido"]);
                            int Tratamiento = Convert.ToInt32(DTAntecedentesMorbidos.Rows[i]["Tratamiento"]);
                            InsertAntecedentesMorbidos(sqlt, CodFichaSaludInicial, CodAntecedenteMorbido, Convert.ToBoolean(Tratamiento));
                        }
                    }
                    if (DTFarmacos.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTFarmacos.Rows.Count; i++)
                        {
                            int CodFarmaco = Convert.ToInt32(DTFarmacos.Rows[i]["CodFarmaco"]);
                            int CodPresentacion = Convert.ToInt32(DTFarmacos.Rows[i]["CodPresentacion"]);
                            int Manana = Convert.ToInt32(DTFarmacos.Rows[i]["Manana"]);

                            string CantidadManana = "0";
                            if (Manana == 1 && DTFarmacos.Rows[i]["CantidadManana"].ToString() != "")
                            {
                                CantidadManana = Convert.ToString(DTFarmacos.Rows[i]["CantidadManana"]);
                            }

                            int Tarde = Convert.ToInt32(DTFarmacos.Rows[i]["Tarde"]);

                            string CantidadTarde = "0";
                            if (Tarde == 1 && DTFarmacos.Rows[i]["CantidadTarde"].ToString() != "")
                            {
                                CantidadTarde = Convert.ToString(DTFarmacos.Rows[i]["CantidadTarde"]);
                            }

                            int Noche = Convert.ToInt32(DTFarmacos.Rows[i]["Noche"]);

                            string CantidadNoche = "0";
                            if (Noche == 1 && DTFarmacos.Rows[i]["CantidadNoche"].ToString() != "")
                            {
                                CantidadNoche = Convert.ToString(DTFarmacos.Rows[i]["CantidadNoche"]);
                            }

                            if (CodFarmaco == 1)
                            {
                                string OtrosFarmacos = (DTFarmacos.Rows[i]["DescripcionOtros"]).ToString();
                                InsertFarmacos(sqlt, CodFichaSaludInicial, CodFarmaco, CodPresentacion, Manana, CantidadManana, Tarde, CantidadTarde, Noche, CantidadNoche, OtrosFarmacos);
                            }
                            else if (CodFarmaco > 1)
                            {
                                InsertFarmacos(sqlt, CodFichaSaludInicial, CodFarmaco, CodPresentacion, Manana, CantidadManana, Tarde, CantidadTarde, Noche, CantidadNoche);
                            }
                        }
                    }

                    if (DTAlergias.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTAlergias.Rows.Count; i++)
                        {
                            int CodAlergia = Convert.ToInt32(DTAlergias.Rows[i]["CodAlergia"]);

                            if (CodAlergia == 1)
                            {
                                string OtrasAlergias = (DTAlergias.Rows[i]["DescripcionOtros"]).ToString();
                                InsertAlergias(sqlt, CodFichaSaludInicial, CodAlergia, OtrasAlergias);
                            }
                            else if (CodAlergia > 1)
                            {
                                InsertAlergias(sqlt, CodFichaSaludInicial, CodAlergia);
                            }
                        }
                    }

                    if (DTTrastornos.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTTrastornos.Rows.Count; i++)
                        {
                            int CodTrastorno = Convert.ToInt32(DTTrastornos.Rows[i]["CodTrastorno"]);
                            InsertTrastornos(sqlt, CodFichaSaludInicial, CodTrastorno);
                        }
                    }

                    if (DTSindromes.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTSindromes.Rows.Count; i++)
                        {
                            int CodSindrome = Convert.ToInt32(DTSindromes.Rows[i]["CodSindrome"]);
                            InsertSindromes(sqlt, CodFichaSaludInicial, CodSindrome);
                        }
                    }

                    if (DTExamenes.Rows.Count > 0)
                    {
                        for (int i = 0; i < DTExamenes.Rows.Count; i++)
                        {
                            int CodTipoExamen = Convert.ToInt32(DTExamenes.Rows[i]["CodTipoExamen"]);
                            int CodExamen = Convert.ToInt32(DTExamenes.Rows[i]["CodExamen"]);
                            InsertExamenes(sqlt, CodFichaSaludInicial, CodExamen);
                        }
                    }

                    Insert = true;
                }

                if (ExisteFichaSalud > 0)
                {
                    int CodFichaSaludInicial = ExisteFichaSalud;

                    if ((ViewState["FechaIngresoFichaInicial"] != null && ViewState["FechaIngresoFichaInicial"] != "") && (ViewState["IdUsuarioIngresoFicha"] != null && ViewState["IdUsuarioIngresoFicha"] != ""))
                    {
                        DateTime FechaIngresoFichaInicial = Convert.ToDateTime(ViewState["FechaIngresoFichaInicial"]);
                        int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
                        int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

                        if ((DateTime.Now - FechaIngresoFichaInicial).TotalHours <= 24)
                        {
                            if (UsuarioActual == IdUsuarioIngresoFicha)
                            {
                                UpdateFichaSalud(
                                   sqlt,
                                   CodDiagnostico,
                                   FechaDiagnostico,
                                   FechaIntervencion,
                                   FechaEvaluacion,
                                   GetTexBox(txtAntecedentesQuirurgicosyH),
                                   GetRadioButton(rbtnTransfusionesSi, rbtnTransfusionesNo),
                                   Convert.ToInt32(ddlAntecedentesGinecoO.SelectedValue),
                                   Convert.ToInt32(ddlAntecedentesFamiliares.SelectedValue),
                                   Convert.ToInt32(ddlPA.SelectedValue),
                                   Convert.ToInt32(ddlPulso.SelectedValue),
                                   Convert.ToInt32(ddlFR.SelectedValue),
                                   Convert.ToInt32(ddlTemperatura.SelectedValue),
                                   GetRadioButton(rbtnTranquiloSi, rbtnTranquiloNo),
                                   GetRadioButton(rbtnExcitadoSi, rbtnExcitadoNo),
                                   GetRadioButton(rbtnAngustiadoSi, rbtnAngustiadoNo),
                                   GetRadioButton(rbtnDecaidoSi, rbtnDecaidoNo),
                                   GetRadioButton(rbtnIrritableSi, rbtnIrritableNo),
                                   Convert.ToInt32(ddlMovilidad.SelectedValue),
                                   Convert.ToInt32(GetTexBox(txtPeso)),
                                   Convert.ToInt32(GetTexBox(txtTalla)),
                                   Convert.ToString(GetTexBox(txtIMC)),
                                   Convert.ToInt32(ddlPerimetroCintura.SelectedValue),
                                   Convert.ToInt32(ddlPerimetroCraneano.SelectedValue),
                                   Convert.ToInt32(ddlTallaEdad.SelectedValue),
                                   GetTexBox(txtPesoTalla),
                                   GetTexBox(txtPesoEdad),
                                   Convert.ToInt32(ddlEstadoNutricional.SelectedValue),
                                   Convert.ToInt32(ddlDesarrolloCognitivo.SelectedValue),
                                   Convert.ToInt32(ddlComunicacion.SelectedValue),
                                   Convert.ToInt32(ddlDesarrolloSocioEmocional.SelectedValue),
                                   Convert.ToDateTime(GetDateTime(txtProximoControl)),
                                   Convert.ToInt32(ddlGradosTunner.SelectedValue),
                                   Convert.ToInt32(ddlEvaluacionOrtopedica.SelectedValue),
                                   Convert.ToInt32(ddlDisplaciaCadera.SelectedValue),
                                   Convert.ToInt32(ddlColor.SelectedValue),
                                   Convert.ToInt32(ddlHumedad.SelectedValue),
                                   Convert.ToInt32(ddlCabeza.SelectedValue),
                                   Convert.ToInt32(ddlCuello.SelectedValue),
                                   Convert.ToInt32(ddlTorax.SelectedValue),
                                   Convert.ToInt32(ddlAbdomen.SelectedValue),
                                   Convert.ToInt32(ddlExtremidades.SelectedValue),
                                   Convert.ToInt32(ddlSintomaExtremidades.SelectedValue),
                                   Convert.ToInt32(ddlGenitales.SelectedValue),
                                   GetRadioButton(rbtnGenuValgoSi, rbtnGenuValgoNo),
                                   GetRadioButton(rbtnGenuVaroSi, rbtnGenuVaroNo),
                                   GetRadioButton(rbtnPiePlanoSi, rbtnPiePlanoNo),
                                   Convert.ToInt32(ddlMarcha.SelectedValue),
                                   Convert.ToInt32(ddlVision.SelectedValue),
                                   GetRadioButton(rbtnLentesSi, rbtnLentesNo),
                                   Convert.ToInt32(ddlAudicion.SelectedValue),
                                   GetRadioButton(rbtnAudifonosSi, rbtnAudifonosNo),
                                   Convert.ToInt32(ddlSaludBucal.SelectedValue),
                                   GetRadioButton(rbtnOrtodonciaSi, rbtnOrtodonciaNo),
                                   Convert.ToInt32(ddlColumna.SelectedValue),
                                   Convert.ToInt32(ddlConductaSexual.SelectedValue),
                                   Convert.ToDateTime(GetDateTime(txtMenarquia)),
                                   Convert.ToInt32(GetTexBox(txtCiclos)),
                                   GetTexBox(txtFO),
                                   GetRadioButton(rbtnAbortosSi, rbtnAbortosNo),
                                   Convert.ToDateTime(GetDateTime(txtFUR)),
                                    //GetRadioButton(rbtnIntentoSuicidaSi, rbtnIntentoSuicidaNo),
                                   GetRadioButton(rbtnIdeacionSuicidaSi, rbtnIdeacionSuicidaNo),
                                   GetTexBox(txtHistoriaClinicaEvolutiva),
                                   Convert.ToDateTime(DateTime.Now),
                                   GetRadioButton(rbtnPresumeConsumoSi, rbtnPresumeConsumoNo),
                                   GuardadoFinal,
                                   GetRadioButton(rbtnVacunasAlDiaSi, rbtnVacunasAlDiaNo),
                                   GetRadioButton(rbtnInscritoAtencionPrimariaSi, rbtnInscritoAtencionPrimariaNo),
                                   Convert.ToInt32(ddlEstablecimiento.SelectedValue));

                                // agrega solo los nuevos farmacos, alergias, trastorno y sindromes

                                if (DTAntecedentesMorbidos.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTAntecedentesMorbidos.Rows.Count; i++)
                                    {
                                        int CodAntecedenteMorbido = Convert.ToInt32(DTAntecedentesMorbidos.Rows[i]["CodAntecedenteMorbido"]);
                                        int Tratamiento = Convert.ToInt32(DTAntecedentesMorbidos.Rows[i]["Tratamiento"]);

                                        int ExistentecedenteMorbido = ExisteAntecedenteMorbido(sqlt, CodFichaSaludInicial, CodAntecedenteMorbido);
                                        if (ExistentecedenteMorbido == 0)
                                        {
                                            InsertAntecedentesMorbidos(sqlt, CodFichaSaludInicial, CodAntecedenteMorbido, Convert.ToBoolean(Tratamiento));
                                        }
                                    }
                                }

                                if (DTFarmacos.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTFarmacos.Rows.Count; i++)
                                    {
                                        int CodFarmaco = Convert.ToInt32(DTFarmacos.Rows[i]["CodFarmaco"]);
                                        int CodPresentacion = Convert.ToInt32(DTFarmacos.Rows[i]["CodPresentacion"]);
                                        int Manana = Convert.ToInt32(DTFarmacos.Rows[i]["Manana"]);

                                        string CantidadManana = "0";
                                        if (Manana == 1 && (DTFarmacos.Rows[i]["CantidadManana"]).ToString() != "")
                                        {
                                            CantidadManana = Convert.ToString(DTFarmacos.Rows[i]["CantidadManana"]);
                                        }

                                        int Tarde = Convert.ToInt32(DTFarmacos.Rows[i]["Tarde"]);

                                        string CantidadTarde = "0";
                                        if (Tarde == 1 && (DTFarmacos.Rows[i]["CantidadTarde"]).ToString() != "")
                                        {
                                            CantidadTarde = Convert.ToString(DTFarmacos.Rows[i]["CantidadTarde"]);
                                        }

                                        int Noche = Convert.ToInt32(DTFarmacos.Rows[i]["Noche"]);

                                        string CantidadNoche = "0";
                                        if (Noche == 1 && (DTFarmacos.Rows[i]["CantidadNoche"]).ToString() != "")
                                        {
                                            CantidadNoche = Convert.ToString(DTFarmacos.Rows[i]["CantidadNoche"]);
                                        }


                                        if (CodFarmaco == 1)
                                        {
                                            string OtrosFarmacos = (DTFarmacos.Rows[i]["DescripcionOtros"]).ToString();
                                            int ExisteF = ExisteFarmacoOtros(sqlt, CodFichaSaludInicial, CodFarmaco, OtrosFarmacos);
                                            if (ExisteF == 0)
                                            {
                                                InsertFarmacos(sqlt, CodFichaSaludInicial, CodFarmaco, CodPresentacion, Manana, CantidadManana, Tarde, CantidadTarde, Noche, CantidadNoche, OtrosFarmacos);
                                            }
                                        }
                                        else if (CodFarmaco > 1)
                                        {
                                            int ExisteF = ExisteFarmaco(sqlt, CodFichaSaludInicial, CodFarmaco);

                                            if (ExisteF == 0)
                                            {
                                                InsertFarmacos(sqlt, CodFichaSaludInicial, CodFarmaco, CodPresentacion, Manana, CantidadManana, Tarde, CantidadTarde, Noche, CantidadNoche);
                                            }
                                        }
                                    }
                                }

                                if (DTAlergias.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTAlergias.Rows.Count; i++)
                                    {
                                        int CodAlergia = Convert.ToInt32(DTAlergias.Rows[i]["CodAlergia"]);
                                        if (CodAlergia == 1)
                                        {
                                            string OtrasAlergias = (DTAlergias.Rows[i]["DescripcionOtros"]).ToString();
                                            int ExisteA = ExisteAlergiaOtros(sqlt, CodFichaSaludInicial, CodAlergia, OtrasAlergias);
                                            if (ExisteA == 0)
                                            {
                                                InsertAlergias(sqlt, CodFichaSaludInicial, CodAlergia, OtrasAlergias);
                                            }
                                        }
                                        else if (CodAlergia > 1)
                                        {
                                            int ExisteA = ExisteAlergia(sqlt, CodFichaSaludInicial, CodAlergia);
                                            if (ExisteA == 0)
                                            {
                                                InsertAlergias(sqlt, CodFichaSaludInicial, CodAlergia);
                                            }
                                        }
                                    }
                                }

                                if (DTTrastornos.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTTrastornos.Rows.Count; i++)
                                    {
                                        int CodTrastorno = Convert.ToInt32(DTTrastornos.Rows[i]["CodTrastorno"]);
                                        int ExisteT = ExisteTrastornos(sqlt, CodFichaSaludInicial, CodTrastorno);
                                        if (ExisteT == 0)
                                        {
                                            InsertTrastornos(sqlt, CodFichaSaludInicial, CodTrastorno);
                                        }
                                    }
                                }

                                if (DTSindromes.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTSindromes.Rows.Count; i++)
                                    {
                                        int CodSindrome = Convert.ToInt32(DTSindromes.Rows[i]["CodSindrome"]);
                                        int ExisteS = ExisteSindrome(sqlt, CodFichaSaludInicial, CodSindrome);
                                        if (ExisteS == 0)
                                        {
                                            InsertSindromes(sqlt, CodFichaSaludInicial, CodSindrome);
                                        }
                                    }
                                }

                                if (DTExamenes.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTExamenes.Rows.Count; i++)
                                    {
                                        int CodExamen = Convert.ToInt32(DTExamenes.Rows[i]["CodExamen"]);
                                        int ExisteE = ExisteExamen(sqlt, CodFichaSaludInicial, CodExamen);

                                        if (ExisteE == 0)
                                        {
                                            InsertExamenes(sqlt, CodFichaSaludInicial, CodExamen);
                                        }
                                    }
                                }

                                Update = true;
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

                if (ExisteFichaSalud == -1)
                {
                    Response.Write("<script language='javascript'>alert('ERROR, hay mas de un diagnóstico de ficha de salud Inicial. Por favor contactarse con mesa de ayuda. ');</script>");

                }

                if (Tipo != guardadotype.Derivacion)
                {
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "fadeOutAlert1", "$('#divAlertaGuardado').fadeIn();", true);
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "fadeOutAlert2", "$('#divAlertaGuardado').delay(4000).fadeOut();", true);
                    Response.Write("<script language='javascript'>alert('Guardado de Ficha realizado de forma exitosa');</script>");
                }

                if (Insert == true)
                {
                    DateTime FechaFinal = DateTime.Now.AddDays(1);
                    String FechaFinalSeteadaDiagInicial = FechaFinal.Month + "/" + FechaFinal.Day + "/" + FechaFinal.Year + " " + FechaFinal.TimeOfDay;
                    ViewState["FechaFinalSeteadaDiagInicial"] = FechaFinalSeteadaDiagInicial;
                    tdHorasRestantes.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CountDown", "CountDownTimer('" + FechaFinalSeteadaDiagInicial + "', 'countdownDiagInicial');", true);
                    ViewState["IdUsuarioIngresoFicha"] = Convert.ToInt32(Session["IdUsuario"]);
                    ViewState["FechaIngresoFichaInicial"] = Convert.ToDateTime(DateTime.Now);
                }
                if (Update == true)
                {

                }



            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>alert('Guardado no realizado, intentar nuevamene.');</script>");
                Console.WriteLine(ex.Message);
                try
                {
                    sqlt.Rollback();
                }
                catch (Exception exRollback)
                {
                    Response.Write("<script language='javascript'>alert('Guardado de ficha Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                    Console.WriteLine(exRollback.Message);
                }


            }

        }
        else
        {
            divAlertaFicha.Visible = true;
            lblAlertaFicha.Text = "Guardado no Realizado, Faltan Campos Obligatorios. ";
        }
        
    }
    

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }


    //protected void rv_fecha_Init_FechaIntervencion(object sender, EventArgs e)
    //{
    //    if (txtFechaDiagnostico.Text != "")
    //    {
    //        ((RangeValidator)sender).MinimumValue = txtFechaDiagnostico.Text;
    //    }
    //    else
    //    {
    //        ((RangeValidator)sender).MinimumValue = "01-01-1900";
    //    }

    //    if (txtFechaEvaluacion.Text != "")
    //    {
    //        ((RangeValidator)sender).MaximumValue = txtFechaEvaluacion.Text;
    //    }
    //    else
    //    {
    //        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
    //    }
    //}

    protected void rv_fecha_Init2(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = "31-12-" + (Convert.ToInt32(DateTime.Now.Year) + 1);
        ((RangeValidator)sender).MinimumValue =  DateTime.Today.ToString("dd-MM-yyyy");

    }

    private void MostrarDerivacion(string Tipo, string Modificar)
    {
        if (Tipo == "Vision")
        {
            iframevision.Src = "../mod_ninos/DerivacionFichaSalud.aspx?sw=" + Tipo + "&mdf=" + Modificar ;
            iframevision.Attributes.Add("height", "560px");
            iframevision.Attributes.Add("width", "900px");
            mpe1.Show();          
            
        }

        if (Tipo == "Audicion")
        {
            iframeaudicion.Src = "../mod_ninos/DerivacionFichaSalud.aspx?sw=" + Tipo + "&mdf=" + Modificar;
            iframeaudicion.Attributes.Add("height", "560px");
            iframeaudicion.Attributes.Add("width", "900px");
            mpe2.Show();
        }

        if (Tipo == "SaludBucal")
        {
            iframesaludbucal.Src = "../mod_ninos/DerivacionFichaSalud.aspx?sw=" + Tipo + "&mdf=" + Modificar;
            iframesaludbucal.Attributes.Add("height", "560px");
            iframesaludbucal.Attributes.Add("width", "900px");
            mpe3.Show();
        }

        if (Tipo == "Columna")
        {
            iframecolumna.Src = "../mod_ninos/DerivacionFichaSalud.aspx?sw=" + Tipo + "&mdf=" + Modificar;
            iframecolumna.Attributes.Add("height", "560px");
            iframecolumna.Attributes.Add("width", "900px");
            mpe4.Show();
        }
    }

    protected void lnkMostrarDerivacionVision_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.ExamenFisicoPiel);
        if ((ViewState["FechaIngresoFichaInicial"] != null && Convert.ToString(ViewState["FechaIngresoFichaInicial"]) != "") && (ViewState["IdUsuarioIngresoFicha"] != null && Convert.ToString(ViewState["IdUsuarioIngresoFicha"]) != ""))
        {
            DateTime FechaIngresoFichaInicial = Convert.ToDateTime(ViewState["FechaIngresoFichaInicial"]);
            int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
            int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

            if ((DateTime.Now - FechaIngresoFichaInicial).TotalHours <= 24)
            {
                if (UsuarioActual == IdUsuarioIngresoFicha)
                {
                    //if (!ValidaFechas())
                    //{
                    GuardarFichaSaludInicial(guardadotype.Derivacion);
                    MostrarDerivacion("Vision", "si");
                        
                    //}
                }
                else
                {
                    MostrarDerivacion("Vision", "no");
                }
            }
            else
            {
                MostrarDerivacion("Vision", "no");
            }
        }
        
    }
    protected void lnkMostrarDerivacionAudicion_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.ExamenFisicoPiel);
        if ((ViewState["FechaIngresoFichaInicial"] != null && ViewState["FechaIngresoFichaInicial"] != "") && (ViewState["IdUsuarioIngresoFicha"] != null && ViewState["IdUsuarioIngresoFicha"] != ""))
        {
            DateTime FechaIngresoFichaInicial = Convert.ToDateTime(ViewState["FechaIngresoFichaInicial"]);
            int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
            int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

            if ((DateTime.Now - FechaIngresoFichaInicial).TotalHours <= 24)
            {
                if (UsuarioActual == IdUsuarioIngresoFicha)
                {
                    //if (!ValidaFechas())
                    //{
                    GuardarFichaSaludInicial(guardadotype.Derivacion);
                        MostrarDerivacion("Audicion", "si");
                    //}
                }
                else
                {
                    MostrarDerivacion("Audicion", "no");
                }
            }
            else
            {
                MostrarDerivacion("Audicion", "no");
            }
        }
    }
    protected void lnkMostrarDerivacionSaludBucal_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.ExamenFisicoPiel);
        if ((ViewState["FechaIngresoFichaInicial"] != null && ViewState["FechaIngresoFichaInicial"] != "") && (ViewState["IdUsuarioIngresoFicha"] != null && ViewState["IdUsuarioIngresoFicha"] != ""))
        {
            DateTime FechaIngresoFichaInicial = Convert.ToDateTime(ViewState["FechaIngresoFichaInicial"]);
            int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
            int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

            if ((DateTime.Now - FechaIngresoFichaInicial).TotalHours <= 24)
            {
                if (UsuarioActual == IdUsuarioIngresoFicha)
                {
                    //if (!ValidaFechas())
                    //{
                    GuardarFichaSaludInicial(guardadotype.Derivacion);
                        MostrarDerivacion("SaludBucal", "si");
                    //}
                }
                else
                {
                    MostrarDerivacion("SaludBucal", "no");
                }
            }
            else
            {
                MostrarDerivacion("SaludBucal", "no");
            }

        }
    }
    protected void lnkMostrarDerivacionColumna_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.ExamenFisicoPiel);
        if ((ViewState["FechaIngresoFichaInicial"] != null && ViewState["FechaIngresoFichaInicial"] != "") && (ViewState["IdUsuarioIngresoFicha"] != null && ViewState["IdUsuarioIngresoFicha"] != ""))
        {
            DateTime FechaIngresoFichaInicial = Convert.ToDateTime(ViewState["FechaIngresoFichaInicial"]);
            int IdUsuarioIngresoFicha = Convert.ToInt32(ViewState["IdUsuarioIngresoFicha"]);
            int UsuarioActual = Convert.ToInt32(Session["IdUsuario"]);

            if ((DateTime.Now - FechaIngresoFichaInicial).TotalHours <= 24)
            {
                if (UsuarioActual == IdUsuarioIngresoFicha)
                {
                    //if (!ValidaFechas())
                    //{
                    GuardarFichaSaludInicial(guardadotype.Derivacion);
                        MostrarDerivacion("Columna", "si");
                    //}
                }
                else
                {
                    MostrarDerivacion("Columna", "no");
                }
            }
            else
            {
                MostrarDerivacion("Columna", "no");
            }

        }
    }
    protected void chkManana_CheckedChanged(object sender, EventArgs e)
    {
        if (chkManana.Checked == true)
        {
            txtManana.Text = "";
            txtManana.Enabled = true;
        }
        else
        {
            txtManana.Enabled = false;
            txtManana.Text = "";
        }
    }


    protected void chkTarde_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTarde.Checked == true)
        {
            txtTarde.Text = "";
            txtTarde.Enabled = true;
        }
        else
        {
            txtTarde.Enabled = false;
            txtTarde.Text = "";
        } 
    }
    protected void chkNoche_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNoche.Checked == true)
        {
            txtNoche.Text = "";
            txtNoche.Enabled = true;
        }
        else
        {
            txtNoche.Enabled = false;
            txtNoche.Text = "";
        } 
    }
    protected void grdFarmacos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 2; i <= 7; i++)
            {
                if (i % 2 == 0)
                {
                    

                    if (e.Row.Cells[i].Text == "True")
                    {
                        e.Row.Cells[i].Text = "Si";
                    }
                    if (e.Row.Cells[i].Text == "False")
                    {
                        e.Row.Cells[i].Text = "No";
                    }
                }
                else
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                }
            }
        }
    }
    protected void grdPMaternidadAdolescente_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Sexo"] != null)
                if (ViewState["Sexo"].ToString() != "")
                {
                    if (ViewState["Sexo"].ToString() == "F")
                    {
                        if (e.Row.Cells[1].Text == "True")
                        {
                            e.Row.Cells[1].Text = "Si";

                            if (e.Row.Cells[3].Text == "True")
                            {
                                e.Row.Cells[3].Text = "Si";
                            }
                            else
                            {
                                e.Row.Cells[3].Text = "No";
                            }
                        }
                        else
                        {
                            e.Row.Cells[1].Text = "No";
                            e.Row.Cells[2].Text = "No corresponde"; 
                            e.Row.Cells[3].Text = "No";
                        }
                    }
                    if (ViewState["Sexo"].ToString() == "M")
                    {
                        e.Row.Cells[1].Text = "No Corresponde";
                        e.Row.Cells[2].Text = "No Corresponde";
                        e.Row.Cells[3].Text = "No Corresponde";
                    }

                    if (e.Row.Cells[4].Text == "True")
                    {
                        e.Row.Cells[4].Text = "Si";


                        if (e.Row.Cells[6].Text == "True")
                        {
                            e.Row.Cells[6].Text = "Si";
                        }
                        else
                        {
                            e.Row.Cells[6].Text = "No";
                        }
                    }
                    else
                    {
                        e.Row.Cells[4].Text = "No";
                        e.Row.Cells[5].Text = "No corresponde";
                        e.Row.Cells[6].Text = "No";
                    }
                }
        }
    }
    protected void ddlTipoExamen_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoExamen.SelectedValue != "0")
        {
            ddlExamen.Items.Clear();
            DataView dvExamen = new DataView(GetparExamen(Convert.ToInt32(ddlTipoExamen.SelectedValue)));
            ddlExamen.DataSource = dvExamen;
            ddlExamen.DataTextField = "Descripcion";
            ddlExamen.DataValueField = "CodExamen";
            dvExamen.Sort = "CodExamen";
            ddlExamen.Items.Add(new ListItem ("Seleccione","0"));
            ddlExamen.DataBind();


        }
    }
    protected void btnAgregarExamen_Click(object sender, EventArgs e)
    {
        DataRow dr = DTExamenes.NewRow();
        bool chk_rep = false;

        if (ddlTipoExamen.SelectedValue != Convert.ToString(0) && ddlExamen.SelectedValue != Convert.ToString(0))
        {
            for (int i = 0; i < grdExamenes.Rows.Count; i++)
            {
                if (grdExamenes.Rows[i].Cells[1].Text == ddlExamen.SelectedValue)
                {
                    chk_rep = true;
                }
            }
            if (!chk_rep)
            {
                if (grdExamenes.Rows.Count < 10)
                {
                    dr[0] = ddlTipoExamen.SelectedItem;
                    dr[1] = ddlTipoExamen.SelectedValue;
                    dr[2] = ddlExamen.SelectedItem;
                    dr[3] = ddlExamen.SelectedValue;

                    DTExamenes.Rows.Add(dr);
                    DataView dv = new DataView(DTExamenes);
                    grdExamenes.DataSource = dv;
                    dv.Sort = "CodExamen";
                    grdExamenes.DataBind();
                    grdExamenes.Visible = true;
                    trExamenes.Visible = true;
                    ddlTipoExamen.SelectedValue = Convert.ToString(0);
                    ddlExamen.SelectedValue = Convert.ToString(0);
                    lbl_avisoExamen.Visible = false;
                }
                else
                {
                    lbl_avisoExamen.Text = "Sólo se pueden registrar un maximo de 10 Exámenes";
                    lbl_avisoExamen.Visible = true;
                }
            }
            else
            {
                lbl_avisoExamen.Text = "El examen seleccionado ya ha sido ingresado";
                lbl_avisoExamen.Visible = true;
            }
        }
        else
        {
            lbl_avisoExamen.Text = "Faltan campos para el ingreso del Exámen.";
            lbl_avisoExamen.Visible = true;
        }
    }

    protected void btnGuardarDatosRelevantes_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.DatosRelevantes);

        GuardarFichaSaludInicial(guardadotype.DatosRelevantes);

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.Anamnesis);

        GuardarFichaSaludInicial(guardadotype.Anamnesis);
        
    }

    protected void btnGuardar2_Click(object sender, EventArgs e)
    {
        
        GuardarFichaSaludInicial(guardadotype.ExamenFisicoConciencia);
        
        
        muestra_collapse(collapsetype.ExamenFisicoConciencia);       

    }
    protected void btnGuardar3_Click(object sender, EventArgs e)
    {
        
        GuardarFichaSaludInicial(guardadotype.ExamenFisicoPiel);
        
        muestra_collapse(collapsetype.ExamenFisicoPiel);        
    }

    protected void btnGuardarFinal_Click(object sender, EventArgs e)
    {
        muestra_collapse(collapsetype.Ninguno);

        GuardarFichaSaludInicial(guardadotype.Completo);
        
    }

    private void Alerta_collapse(collapsetype tipo)
    {
        switch (tipo)
        {
            case collapsetype.DatosPersonales:
                iconDatosPersonales.Attributes.Add("class", "glyphicon glyphicon-warning-sign");     
                break;
            case collapsetype.DatosRelevantes:
                iconDatosRelevantes.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
                break;
            case collapsetype.Anamnesis:
                iconAnamnesis.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
                break;
            case collapsetype.ExamenFisicoConciencia:
                iconExamenFisicoConciencia.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
                break;
            case collapsetype.ExamenFisicoPiel:
                iconExamenFisicoPiel.Attributes.Add("class", "glyphicon glyphicon-warning-sign");
                break;
            case collapsetype.Ninguno:
                iconDatosPersonales.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
                iconDatosRelevantes.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
                iconAnamnesis.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
                iconExamenFisicoConciencia.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
                iconExamenFisicoPiel.Attributes.Add("class", "glyphicon glyphicon-triangle-bottom");
                break;
        }
    }

    private void muestra_collapse(collapsetype tipo)
    {        
        //Comprueba en que collapse se encuentra haciendo postback y la mantiene.
        switch (tipo)
        {
            case collapsetype.DatosPersonales:
                divCollapseDatosPersonales.Attributes.Add("class", "panel-collapse collapse in");
                divCollapseDatosRelevantes.Attributes.Add("class", "panel-collapse collapse");
                divCollapseAnamnesis.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoPiel.Attributes.Add("class", "panel-collapse collapse");
                break;
            case collapsetype.DatosRelevantes:
                divCollapseDatosPersonales.Attributes.Add("class", "panel-collapse collapse");
                divCollapseDatosRelevantes.Attributes.Add("class", "panel-collapse collapse in");
                divCollapseAnamnesis.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoPiel.Attributes.Add("class", "panel-collapse collapse");
                break;
            case collapsetype.Anamnesis:
                divCollapseDatosPersonales.Attributes.Add("class", "panel-collapse collapse");
                divCollapseDatosRelevantes.Attributes.Add("class", "panel-collapse collapse");
                divCollapseAnamnesis.Attributes.Add("class", "panel-collapse collapse in");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoPiel.Attributes.Add("class", "panel-collapse collapse");
                break;
            case collapsetype.ExamenFisicoConciencia:
                divCollapseDatosPersonales.Attributes.Add("class", "panel-collapse collapse");
                divCollapseDatosRelevantes.Attributes.Add("class", "panel-collapse collapse");
                divCollapseAnamnesis.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse in");
                divCollapseExamenFisicoPiel.Attributes.Add("class", "panel-collapse collapse");
                break;
            case collapsetype.ExamenFisicoPiel:
                divCollapseDatosPersonales.Attributes.Add("class", "panel-collapse collapse");
                divCollapseDatosRelevantes.Attributes.Add("class", "panel-collapse collapse");
                divCollapseAnamnesis.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoPiel.Attributes.Add("class", "panel-collapse collapse in");
                break;
            case collapsetype.Ninguno:
                divCollapseDatosPersonales.Attributes.Add("class", "panel-collapse collapse");
                divCollapseDatosRelevantes.Attributes.Add("class", "panel-collapse collapse");
                divCollapseAnamnesis.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse");
                divCollapseExamenFisicoConciencia.Attributes.Add("class", "panel-collapse collapse");
                break; 
        }
    }
    protected void txtFechaDiagnostico_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaIntervencion.Text != "")
        {
            if (RangeValidator8.IsValid)
            {
                RangeValidator4.MaximumValue = txtFechaIntervencion.Text;
                RangeValidator4.Validate();
            }
            else
            {
                RangeValidator8.MinimumValue = txtFechaEvaluacion.Text;

                if (txtFechaEvaluacion.Text != "")
                {
                    if (RangeValidator9.IsValid)
                    {                        
                        RangeValidator9.MaximumValue = txtFechaEvaluacion.Text;                        
                    }
                }

                RangeValidator8.Validate();
            }
        }
        else
        {
            if (txtFechaEvaluacion.Text != "")
            {
                if (RangeValidator9.IsValid)
                {
                    RangeValidator4.MaximumValue = txtFechaEvaluacion.Text;
                    RangeValidator4.Validate();
                }
            }
        }

        RangeValidator4.Validate();
        RangeValidator8.Validate();
        RangeValidator9.Validate();

        
    }
    protected void txtFechaIntervencion_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaDiagnostico.Text != "")
        {
            if (RangeValidator4.IsValid)
            {
                RangeValidator8.MinimumValue = txtFechaDiagnostico.Text;
                RangeValidator8.Validate();
            }
        }

        if (txtFechaEvaluacion.Text != "")
        {
            if (RangeValidator9.IsValid)
            {
                RangeValidator8.MaximumValue = txtFechaEvaluacion.Text;
                RangeValidator8.Validate();
            }
        }

        RangeValidator4.Validate();
        RangeValidator8.Validate();
        RangeValidator9.Validate();

    }
    protected void txtFechaEvaluacion_TextChanged(object sender, EventArgs e)
    {
        if (txtFechaIntervencion.Text != "")
        {
            if (RangeValidator8.IsValid)
            {
                RangeValidator9.MinimumValue = txtFechaIntervencion.Text;
                RangeValidator9.Validate();
            }
        }
        else
        {
            if (txtFechaDiagnostico.Text != "")
            {
                if (RangeValidator4.IsValid)
                {
                    RangeValidator9.MinimumValue = txtFechaDiagnostico.Text;
                    RangeValidator9.Validate();
                }                

            }
        }

        RangeValidator4.Validate();
        RangeValidator8.Validate();
        RangeValidator9.Validate();
    }

    private void CargaddlEstablecimiento()
    {
        if (ddlRegionEstablecimiento.SelectedValue != "0")
        {
            DataView dvEstablecimientosSalud = new DataView(GetparEstablecimientosSalud(Convert.ToInt32(ddlRegionEstablecimiento.SelectedValue)));
            ddlEstablecimiento.Items.Clear();
            ddlEstablecimiento.Items.Add(new ListItem("Seleccione", "0"));
            ddlEstablecimiento.DataSource = dvEstablecimientosSalud;
            ddlEstablecimiento.DataTextField = "Descripcion";
            ddlEstablecimiento.DataValueField = "CodEstablecimiento";
            dvEstablecimientosSalud.Sort = "Descripcion";
            ddlEstablecimiento.DataBind();
        }
    }

    protected void ddlRegionEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        CargaddlEstablecimiento();       

        muestra_collapse(collapsetype.DatosRelevantes);

        
    }
    
}