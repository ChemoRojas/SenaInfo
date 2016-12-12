/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, no hay descargas excel
 * 
 */

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
using System.Data.Common;
using System.Data.SqlClient;

public partial class mod_ninos_pi_gestion : System.Web.UI.Page
{

    #region Variables_Sesion
    public int ICodCurrentPage
    {
        get
        {
            if (ViewState["ICodCurrentPage"] == null)
            { ViewState["ICodCurrentPage"] = 0; }
            return Convert.ToInt32(ViewState["ICodCurrentPage"]);
        }
        set { ViewState["ICodCurrentPage"] = value; }
    }
    public string tipoPlan
    {
        get { return (string)Session["tipoPlan"]; }
        set { Session["tipoPlan"] = value; }
    }
    public string codplanintervencion
    {
        get { return (string)Session["codplanintervencion"]; }
        set { Session["codplanintervencion"] = value; }
    }
    public int codInstitucion
    {
        get { return (int)Session["codInstitucion"]; }
        set { Session["codInstitucion"] = value; }
    }
    public int codProyecto
    {
        get { if (Session["codProyecto"] == null) { return 0; } else  return Convert.ToInt32(Session["codProyecto"]); }
        set { Session["codProyecto"] = value; }
    }

    public int codgrupo
    {
        get { return (int)Session["codgrupo"]; }
        set { Session["codgrupo"] = value; }
    }
    public int codplaninterv
    {
        get
        {
            if (Session["codplaninterv"] != null)
                return (int)Session["codplaninterv"];
            else

                return 0;
        }
        set { Session["codplaninterv"] = value; }
    }
    public int icodie
    {
        get { return (int)Session["icodie"]; }
        set { Session["icodie"] = value; }
    }
    public string icodie_2
    {
        get { return (string)Session["icodie_2"]; }
        set { Session["icodie_2"] = value; }
    }
    public string bscq
    {
        get { return (string)Session["bscq"]; }
        set { Session["bscq"] = value; }
    }

    public string CodModelo
    {
        get { return (string)Session["CodModeloIntervencion"]; }
        set { Session["CodModeloIntervencion"] = value; }
    }

    #region Tab1
    //Tab 1 Sessiones
    public DateTime fechainicioplan
    {
        get { return (DateTime)Session["fechainicioplan"]; }
        set { Session["fechainicioplan"] = value; }

    }
    public DateTime fechaelaboracionplan
    {
        get { return (DateTime)Session["fechaelaboracionplan"]; }
        set { Session["fechaelaboracionplan"] = value; }

    }
    public int Modificado_DatosPlan
    {
        get { return (int)Session["Modificado_DatosPlan"]; }
        set { Session["Modificado_DatosPlan"] = value; }
    }
    public DataTable DtBusqueda
    {
        get { return (DataTable)Session["DtBusqueda"]; }
        set { Session["DtBusqueda"] = value; }
    }
    #endregion
    #region Tab3
    public string codestadosplan
    {
        get { return (string)Session["codestadosplan"]; }
        set { Session["codestadosplan"] = value; }
    }
    #endregion
    #endregion


    public DataTable resultadoNiveles
    {
        get { return (DataTable)Session["resultadoNiveles"]; }
        set { Session["resultadoNiveles"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
        if (CurrentPage.Value != null && CurrentPage.Value != "")
        {
            muestra_pestaña(int.Parse(CurrentPage.Value));
        }



        if (!IsPostBack)
        {


            //modificacion 31-07-2015
            //if (Request.QueryString["grupo"] != null)
            //{
            //    if (Request.QueryString["grupo"] != "0")
            //        bscq = "EGRUPO";
            //    else
            //        bscq = "NGRUPO";
            //}

            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("DCCD0FF4-D3DF-4578-95FC-159BFD8EFF90"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    getinstituciones();
                    getproyectosxcod();
                    #region busquedas


                    //    if (Request.QueryString["sw"] == "1")
                    //    {
                    //        if (Request.QueryString["planinterv"] != null)
                    //        {
                    //            codgrupo = 0;
                    //            tipoPlan = "I";

                    //            ddown001.SelectedValue = codInstitucion.ToString();
                    //            getproyectosxcod();
                    //            ddown002.SelectedValue = codProyecto.ToString();
                    //            codplaninterv = Convert.ToInt32(Request.QueryString["planinterv"]);
                    //            A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv;
                    //            Get_Resultado_Busqueda_individual();

                    //        }
                    //    }
                    //    else if (Request.QueryString["sw"] == "2")
                    //    {
                    //        if (Request.QueryString["grupo"] != null)
                    //        {
                    //            codplaninterv = 0;
                    //            tipoPlan = "G";
                    //            ddown001.SelectedValue = codInstitucion.ToString();
                    //            getproyectosxcod();
                    //            ddown002.SelectedValue = codProyecto.ToString();
                    //            codgrupo = Convert.ToInt32(Request.QueryString["grupo"]);
                    //            //Revisar/utab.Tabs[3].Visible = false;
                    //            //A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv; // no importa, el boton se esconde
                    //            Get_Resultado_Busqueda_grupal(Convert.ToInt32(Request.QueryString["grupo"]));
                    //        }
                    //    }else 
                    if (Request.QueryString["sw"] == "3")
                    {
                        ddown001.SelectedValue = Request.QueryString["codinst"];
                        getproyectosxcod();
                    }
                    else if (Request.QueryString["sw"] == "4")
                    {
                        buscador_institucion bsc = new buscador_institucion();
                        int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                        ddown001.SelectedValue = Convert.ToString(codinst);
                        getproyectosxcod();
                        ddown002.SelectedValue = Request.QueryString["codinst"];
                        Session["codProyecto"] = codProyecto;
                    }
                    #endregion
                    //--------------------------------------------------------------------
                    // JOVM - 03/02/2015
                    // Se obtiene información desde Session en el caso de contener datos.
                    //revisar
                    if (Session["NNA"] != null)
                    {
                        oNNA NNA = (oNNA)Session["NNA"];

                        //NNA.nnacod

                        if (NNA.NNACodInstitucion != null && NNA.NNACodInstitucion != "")
                        {
                            codInstitucion = Convert.ToInt32(NNA.NNACodInstitucion);
                            if (NNA.NNACodProyecto != null && NNA.NNACodProyecto != "")
                            {
                                codProyecto = Convert.ToInt32(NNA.NNACodProyecto);

                                ddown001.SelectedValue = NNA.NNACodInstitucion;
                                getproyectosxcod();
                                ddown002.SelectedValue = NNA.NNACodProyecto;
                                btnbuscar.Visible = true;
                                //btnbuscar.Attributes.Add("style", "margin-top: 10px");
                                //SeleccionaUno(0);
                                SeleccionaUnoSession(0);

                                if (bscq != null)
                                {
                                    txt_patern.Text = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
                                    txt_name.Text = HttpUtility.HtmlDecode(NNA.NNANombres);
                                    txt_matern.Text = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
                                    btnbuscar_Click(sender, e);
                                }
                                else
                                {
                                    txt_patern.Text = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
                                    txt_name.Text = HttpUtility.HtmlDecode(NNA.NNANombres);
                                    txt_matern.Text = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
                                    btnbuscar_Click(null, null);
                                }


                                preperarboton(); //no hace nada
                            }
                        }
                        //BuscaPlanIntervencion();
                        //Get_Resultado_Busqueda_individual();
                    }
                    if (Request.QueryString["planinterv"] != null)
                    {
                        codgrupo = 0;
                        tipoPlan = "I";

                        ddown001.SelectedValue = codInstitucion.ToString();
                        getproyectosxcod();
                        ddown002.SelectedValue = codProyecto.ToString();
                        codplaninterv = Convert.ToInt32(Request.QueryString["planinterv"]);
                        //gmp A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv;
                        Get_Resultado_Busqueda_individual();
                    }
                    if (Request.QueryString["grupo"] != null)
                    {
                        codplaninterv = 0;
                        tipoPlan = "G";
                        ddown001.SelectedValue = codInstitucion.ToString();
                        getproyectosxcod();
                        ddown002.SelectedValue = codProyecto.ToString();
                        codgrupo = Convert.ToInt32(Request.QueryString["grupo"]);
                        //Revisar/utab.Tabs[3].Visible = false;
                        //A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv; // no importa, el boton se esconde
                        Get_Resultado_Busqueda_grupal(Convert.ToInt32(Request.QueryString["grupo"]));
                    }
                    try
                    {
                        if (bscq == "EGRUPO")
                        {
                            wib004.Visible = false;
                        }
                        //wib004.Visible = true;
                        //A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv;
                    }
                    catch { }

                }

            }
        }
    }


    #region Lupas
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;
        //window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/pi_gestion.aspx", "Buscador", false, true, 500, 650, false, false, true);
        cadena = @"window.open('../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/pi_gestion.aspx', 'Buscador' , 'width=770,height=420,scrollbars=NO')";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;
        //window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/pi_gestion.aspx", "Buscador", false, true, 770, 420, false, false, true);
        cadena = @"window.open('../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/pi_gestion.aspx', 'Buscador' , 'width=120,height=300,scrollbars=NO')";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    }
    #endregion
    #region cargas
    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dv1.Count == 2)
            ddown001.SelectedIndex = 1;
        // <---------- DPL ---------->  09-08-2010

    }
    private void getproyectosxcod()
    {
        proyectocoll pcoll = new proyectocoll();
        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        dv.Sort = "Nombre";
        // <---------- DPL ---------->  09-08-2010
        dv.RowFilter = "isnull(CodModeloIntervencion, 0) <> 115";       // Excluye a los PER (programas de Residencias)
        // <---------- DPL ---------->  09-08-2010
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
        if (dv.Count == 2)
            ddown002.SelectedIndex = 1;

    }
    private void getTrabajadores()
    {
        DropDownList tddown001b = (DropDownList)utab.FindControl("ddown001b");
        trabajadorescoll tcoll = new trabajadorescoll();
        DataView dv1 = new DataView(tcoll.GetTrabajadoresProyecto(codProyecto.ToString()));
        tddown001b.DataSource = dv1;
        tddown001b.DataTextField = "NombreCompleto";
        tddown001b.DataValueField = "ICodTrabajador";
        dv1.Sort = "NombreCompleto";
        tddown001b.DataBind();


    }
    #endregion

    protected string marcarRadio(object oValor, int valorSiNo)
    {
        int valor = -1;
        if (int.TryParse(oValor.ToString(), out valor))
        {
            return valor == valorSiNo ? "checked" : "";
        }
        return "";
    }

    protected string HabilitarHdn(object iCodparResultado)
    {
        int _iCodparResultado = 0;
        if (int.TryParse(iCodparResultado.ToString(), out _iCodparResultado))
        {

            if (_iCodparResultado == 14)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x1", "$('#div_rdo_PRM_14').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 19)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x2", "$('#div_rdo_PRM_19').css('display', 'none');", true);
                return "";

            }

            if (_iCodparResultado == 32)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x3", "$('#div_rdo_PAS_32').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 36)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x4", "$('#div_rdo_PAS_36').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 42)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x5", "$('#div_rdo_PAS_42').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 43)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x6", "$('#div_rdo_PAS_43').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 64)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x7", "$('#div_rdo_PEE_64').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 85)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x8", "$('#div_rdo_PEC_85').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 120)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x9", "$('#div_rdo_PAD_120').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 134)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x10", "$('#div_rdo_PPF_134').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 136)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x11", "$('#div_rdo_PPF_136').css('display', 'none');", true);
                return "";
            }

            if (_iCodparResultado == 137)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "x12", "$('#div_rdo_PPF_137').css('display', 'none');", true);
                return "";
            }
        }

        return "disabled";
    }

    protected string getValorDropdown(object Valor, object iCodparResultado)
    {
        string _valor = "0";

        if (Valor.ToString() != "0" && Convert.ToInt32(iCodparResultado) < 20)
        {
            _valor = Valor.ToString();
            return _valor;
        }
        else
        {
            return _valor;
        }

    }

    protected bool getModelo(object codModelo)
    {
        bool _visible = false;

        if (CodModelo == codModelo.ToString())
        {
            _visible = true;
            return _visible = false;
        }

        return _visible;
    }

    protected string getValorDropdownPAS(object Valor, object iCodparResultado)
    {
        string _valor = "0";
        if (iCodparResultado.ToString() == "32")
        {
            if (Convert.ToInt32(Valor) >= 4)
            {
                _valor = Valor.ToString();
                return _valor;
            }
            else if (Valor.ToString() == "0")
            {
                _valor = "6";
                return _valor;
            }
            else if (Convert.ToInt32(Valor) > 0 && Convert.ToInt32(Valor) < 4)
            {
                _valor = "6";
                return _valor;
            }
        }

        if (iCodparResultado.ToString() == "36")
        {
            if (Convert.ToInt32(Valor) == 0)
            {
                _valor = "4";
                return _valor;
            }
            else if (Convert.ToInt32(Valor) > Convert.ToInt32(_valor) && Convert.ToInt32(Valor) < 5)
            {
                _valor = Valor.ToString();
                return _valor;
            }
        }

        if (iCodparResultado.ToString() == "42")
        {
            if (Convert.ToInt32(Valor) == 0)
            {
                _valor = "9";
                return _valor;
            }
            else if (Convert.ToInt32(Valor) > Convert.ToInt32(_valor) && Convert.ToInt32(Valor) < 10 && Convert.ToInt32(Valor) > 6)
            {
                _valor = Valor.ToString();
                return _valor;
            }
        }

        if (iCodparResultado.ToString() == "43")
        {
            if (Convert.ToInt32(Valor) == 0)
            {
                _valor = "12";
                return _valor;
            }
            else if (Convert.ToInt16(Valor) > Convert.ToInt32(_valor) && Convert.ToInt32(Valor) < 13 && Convert.ToInt32(Valor) > 9)
            {
                _valor = Valor.ToString();
                return _valor;
            }
        }

        return _valor;

    }

    protected string HabilitarHdnNNAPorEgresoPIIPAS(object iCodparResultado)
    {
        int _icodParResultado = 0;
        if (int.TryParse(iCodparResultado.ToString(), out _icodParResultado))
        {
            if (_icodParResultado == 36)
            {
                return "";
            }
        }
        return "disabled";
    }


    #region Busquedas
    private void Get_Resultado_Busqueda_grupal(int grupo)
    {
        codplanintervencion = "";
        icodie_2 = "";
        pintervencion pin = new pintervencion();
        #region CargaNiño_PlanGrupal
        DataView dv = new DataView(pin.get_ninos_grupo(grupo));
        if (dv.Count > 0)
        {
            for (int i = 0; i < dv.Count; i++)
            {
                codplanintervencion += dv.Table.Rows[i][0].ToString() + ",";
                icodie_2 += dv.Table.Rows[i][2].ToString() + ",";
            }

            grd002.DataSource = dv;
            grd002.DataBind();
            grd002.Visible = true;
            utab.Visible = true;
            titulo_tab.Visible = true;
            wib004.Visible = true;

            //grd002.Attributes.Add("style", "");
            //utab.Attributes.Add("style", "");
            //titulo_tab.Attributes.Add("style", "");
            //wib004.Attributes.Add("style", "");

            //pnl002.Visible = false;
            ddown001.Enabled = false;
            txt_name.Enabled = false;
            txt_patern.Enabled = false;
            txt_matern.Enabled = false;
            ddown002.Enabled = false;
            //lbl001.Visible = false;
        }
        #endregion



    }
    private DateTime SetFecha(string fecha)
    {
        DateTime salida;
        try
        {
            salida = Convert.ToDateTime(fecha);
        }
        catch
        {
            salida = Convert.ToDateTime("01-01-1900");
        }
        return salida;
    }
    private void Get_Resultado_Busqueda_individual()
    {

        codplanintervencion = "";
        pintervencion pin = new pintervencion();
        #region CargaNiño_PlanIndividual
        // JOVM - 05/03/2015
        // Se comenta esta línea y se copia más abajo para recibir el DT
        //DataView dv = new DataView(pin.get_nino_solo(codplaninterv));


        //--------------------------------------------------------------------
        // JOVM - 03/02/2015
        // Se obtiene información desde Session en el caso de contener datos.
        if (Session["NNA"] != null)
        {
            oNNA NNA = (oNNA)Session["NNA"];

            //txt003.Text = NNA.NNAApePaterno;
            //txt005.Text = NNA.NNANombres;
            //txt004.Text = NNA.NNAApeMaterno;
            //ddown001.SelectedValue = NNA.NNACodInstitucion;
            //ddown002.SelectedValue = NNA.NNACodProyecto;
            //SSnino.CodNino = NNA.NNACodNino;
            //SSnino.ICodIE = NNA.NNACodIE;
            //lbl003.Text = NNA.NNAFechaIngreso;
            //lbl004.Text = NNA.NNAFechaNacimiento;
            //CargaTabs();

            DbDataReader datareader = null;
            Conexiones con = new Conexiones();

            string sql = "Select T3.CodPlanIntervencion,T1.CodNino,T1.ICodIE,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                         "T1.FechaIngreso,isnull(T2.FechaNacimiento, '') as FechaNacimiento From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino " +
                         "INNER Join PlanIntervencion T3 On T1.CodNino=T3.CodNino and T1.CodProyecto = T3.CodProyecto " +
                         "Where T1.FechaEgreso is null and T1.EstadoIE=0 and T3.CodPlanIntervencion =" + codplaninterv;
            con.ejecutar(sql, out datareader);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
            dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
            dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
            dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
            dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
            dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
            dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
            dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
            dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //7
            dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8

            while (datareader.Read())
            {
                dr = dt.NewRow();
                //dr[0] = codplaninterv;
                //dr[1] = NNA.NNACodNino;
                //dr[2] = NNA.NNACodIE;
                //dr[3] = NNA.NNARut;
                //dr[4] = (String)datareader["Sexo"];
                //dr[5] = NNA.NNANombres;
                //dr[6] = NNA.NNAApePaterno;
                //dr[7] = NNA.NNAApeMaterno;
                //dr[8] = SetFecha(NNA.NNAFechaIngreso);
                //dr[9] = SetFecha(NNA.NNAFechaNacimiento);
                dr[0] = (int)datareader["CodPlanIntervencion"];
                dr[1] = (int)datareader["CodNino"];
                dr[2] = (int)datareader["ICodIE"];
                dr[3] = (String)datareader["Rut"];
                dr[4] = (String)datareader["Sexo"];
                dr[5] = (String)datareader["Nombres"];
                dr[6] = (String)datareader["Apellido_paterno"];
                dr[7] = (String)datareader["Apellido_Materno"];

                txt_name.Text = (String)datareader["Nombres"];
                txt_patern.Text = (String)datareader["Apellido_paterno"];
                txt_matern.Text = (String)datareader["Apellido_Materno"];

                dr[8] = (DateTime)datareader["FechaIngreso"];
                dr[9] = (DateTime)datareader["FechaNacimiento"];
                dt.Rows.Add(dr);
            }
            con.Desconectar();
            //return dt;
            DataView dv = new DataView(dt);

            if (dv.Count > 0)
            {
                icodie = Convert.ToInt32(dv.Table.Rows[0][2]);

                codplanintervencion = dv.Table.Rows[0][0].ToString();
                grd002.DataSource = dv;
                grd002.DataBind();
                grd002.Visible = true;
                utab.Visible = true;
                titulo_tab.Visible = true;
                wib004.Visible = true;

                //grd002.Attributes.Add("style", "");
                //utab.Attributes.Add("style", "");
                //titulo_tab.Attributes.Add("style", "");
                //wib004.Attributes.Add("style", "");

                //pnl002.Visible = false;
                ddown001.Enabled = false;
                txt_name.Enabled = false;
                txt_patern.Enabled = false;
                txt_matern.Enabled = false;
                ddown002.Enabled = false;
                //lbl001.Visible = false;

            }


        }
        //-----------------------------------------------
        else
        {

            // JOVM - 05/03/2015
            // Se trae la búsqueda desde la Clase

            DbDataReader datareader = null;
            // Database db = new Database(objconn)
            Conexiones con = new Conexiones();

            string sql = "Select T3.CodPlanIntervencion,T1.CodNino,T1.ICodIE,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                         "T1.FechaIngreso, isnull(T2.FechaNacimiento, '') as FechaNacimiento From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino " +
                         "INNER Join PlanIntervencion T3 On T1.CodNino=T3.CodNino and T1.CodProyecto = T3.CodProyecto " +
                         "Where T1.FechaEgreso is null and T1.EstadoIE=0 and T3.CodPlanIntervencion =" + codplaninterv;
            con.ejecutar(sql, out datareader);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("CodPlanIntervencion", typeof(int)));
            dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
            dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
            dt.Columns.Add(new DataColumn("Rut", typeof(String))); //2
            dt.Columns.Add(new DataColumn("Sexo", typeof(String)));       //3
            dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
            dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
            dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
            dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //7
            dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8

            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodPlanIntervencion"];
                    dr[1] = (int)datareader["CodNino"];
                    dr[2] = (int)datareader["ICodIE"];
                    dr[3] = (String)datareader["Rut"];
                    dr[4] = (String)datareader["Sexo"];
                    txt_name.Text = (String)datareader["Nombres"];
                    txt_patern.Text = (String)datareader["Apellido_paterno"];
                    txt_matern.Text = (String)datareader["Apellido_Materno"];
                    dr[5] = (String)datareader["Nombres"];
                    dr[6] = (String)datareader["Apellido_paterno"];
                    dr[7] = (String)datareader["Apellido_Materno"];
                    dr[8] = (DateTime)datareader["FechaIngreso"];
                    dr[9] = (DateTime)datareader["FechaNacimiento"];

                    dt.Rows.Add(dr);

                    //--------------------------------------------------------------------------------------
                    // JOVM - 05/03/2015
                    // Verifica si la SESSION tiene datos y sino, asigna información.

                    if (Session["NNA"] == null)
                    {
                        string txt003 = dr[6].ToString();
                        string txt004 = dr[7].ToString();
                        string txt005 = dr[5].ToString();

                        string cinst = ddown001.SelectedValue.ToString();
                        string cproy = ddown002.SelectedValue.ToString();
                        string rut = dr[3].ToString();
                        Int32 codie = Convert.ToInt32(dr[2].ToString());
                        Int32 cnino = Convert.ToInt32(dr[1].ToString());

                        oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, txt005, txt003, txt004, dr[8].ToString(), dr[9].ToString());
                        Session["NNA"] = NNA;
                    }
                    //-----------------------------------------------------------------------------------------

                }
                catch { }
            }
            con.Desconectar();
            //return dt;
            DataView dv = new DataView(dt);

            if (dv.Count > 0)
            {
                icodie = Convert.ToInt32(dv.Table.Rows[0][2]);

                codplanintervencion = dv.Table.Rows[0][0].ToString();
                grd002.DataSource = dv;
                grd002.DataBind();
                grd002.Visible = true;
                utab.Visible = true;
                titulo_tab.Visible = true;
                wib004.Visible = true;

                //grd002.Attributes.Add("style", "");
                //utab.Attributes.Add("style", "");
                //titulo_tab.Attributes.Add("style", "");
                //wib004.Attributes.Add("style", "");

                //pnl002.Visible = false;
                ddown001.Enabled = false;
                txt_name.Enabled = false;
                txt_patern.Enabled = false;
                txt_matern.Enabled = false;
                ddown002.Enabled = false;
                //lbl001.Visible = false;

            }
        }
        #endregion



    }
    #endregion

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectosxcod();
        preperarboton();
    }

    protected void lbtValidar_Click(object sender, EventArgs e)
    {
        //utab.ActiveTab.ForeColor = System.Drawing.Color.Red;
    }
    protected void lbtCerrar_Click(object sender, EventArgs e)
    {
        //grd002.Attributes.Add("style", "display:none");
        //utab.Attributes.Add("style", "display:none");
        //titulo_tab.Attributes.Add("style", "display:none");
        //wib004.Attributes.Add("style", "display:none");
        grd002.Visible = false;
        utab.Visible = false;
        titulo_tab.Visible = false;
        wib004.Visible = false;

    }


    private void limpiar()
    {
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");

        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
        //alerts.Visible = false;
        //lbl005.Visible = false;
        grd002.Visible = false;
        utab.Visible = false;
        titulo_tab.Visible = false;
        wib004.Visible = false;
        btnbuscar.Visible = true;
        //ddown001.SelectedValue = "0";
        //ddown002.SelectedValue = "0";
        txt_name.Text = "";
        txt_patern.Text = "";
        txt_matern.Text = "";
        grd001.Visible = false;

        lbl_resumen_filtro.Style.Add("display", "none");

        //grd002.Attributes.Add("style", "display:none");
        //utab.Attributes.Add("style", "display:none");
        //titulo_tab.Attributes.Add("style", "display:none");
        //wib004.Attributes.Add("style", "display:none");

        //pnl002.Visible = true;
        ddown001.Enabled = true;
        txt_name.Enabled = true;
        txt_patern.Enabled = true;
        txt_matern.Enabled = true;
        ddown002.Enabled = true;
        //lbl001.Visible = true;



        //------------------------------------------------------------------
        // JOVM - 09/03/2015
        // Se limpian datos de la Session
        Session["NNA"] = null;



    }

    protected void lbtlimpiar_Click(object sender, EventArgs e)
    {
        limpiar();
    }
    protected void wib001_Click(object sender, EventArgs e)
    {
        String CodInstitucion = ddown001.SelectedValue;
        String Institucion = ddown001.SelectedItem.Text;
        String CodProyecto = ddown002.SelectedValue;
        String Proyecto = ddown002.SelectedItem.Text.Trim();

        codInstitucion = Convert.ToInt32(CodInstitucion);
        codProyecto = Convert.ToInt32(CodProyecto);

        if (ddown001.SelectedValue != "0" && ddown002.SelectedValue != "0")
        {
            //window.open(this.Page, "bsc_PII.aspx?param001=" + CodInstitucion + "&param002=" +
            //            Institucion + "&param003=" + CodProyecto + "&param004=" + Proyecto, "Buscador", false, true, 750, 400, false, false, true);

            //A3.HRef = "bsc_PII.aspx?param003=" + CodInstitucion + "&dir=pi_gestion.aspx&param004=" + Proyecto;
            //A3.HRef = "bsc_PII.aspx?param001=" + CodInstitucion + "&param002=" + Institucion + "&param003=" + CodProyecto + "&param004=" + Proyecto;

            string cadena = string.Empty;
            //cadena = "hacerclickboton('" + A3.HRef + "')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);

            //lbl002.Visible = false;
        }
        else
        {
            //lbl002.Text = "* Seleccione Institucion y Proyecto";
            //lbl002.Visible = true;
        }
    }

    private void preperarboton()
    {
        String CodInstitucion = ddown001.SelectedValue;
        String Institucion = ddown001.SelectedItem.Text;
        String CodProyecto = ddown002.SelectedValue;
        String Proyecto = ddown002.SelectedItem.Text.Trim();

        codInstitucion = Convert.ToInt32(CodInstitucion);
        codProyecto = Convert.ToInt32(CodProyecto);

        Session["codProyecto"] = codProyecto;
        Session["codInstitucion"] = codInstitucion;

        if (ddown001.SelectedValue != "0" && ddown002.SelectedValue != "0")
        {
            //window.open(this.Page, "bsc_PII.aspx?param001=" + CodInstitucion + "&param002=" +
            //            Institucion + "&param003=" + CodProyecto + "&param004=" + Proyecto, "Buscador", false, true, 750, 400, false, false, true);

            //A3.HRef = "bsc_PII.aspx?param001=" + CodInstitucion + "param002=" + Institucion + "&dir=pi_gestion.aspx&param004=" + Proyecto + "&param003=" + CodProyecto + "&param004=" + Proyecto;
            //lbl002.Visible = false;
        }
        else
        {
            //lbl002.Text = "* Seleccione Institucion y Proyecto";
            //lbl002.Visible = true;
        }

        

    }




    protected void wib004_Click(object sender, EventArgs e)
    {
        int grupo = 0;
        int plan = 0;
        try
        {
            grupo = codgrupo;
        }
        catch { }
        try
        {
            plan = codplaninterv;
        }
        catch { };

        //window.open(this.Page, "eventos_intervencion.aspx?sw=1&param002=" + grupo + "&param003=" + plan, "Buscador", false, false, 800, 600, false, false, true);
        //aqui hacerclickboton
        string cadena = "hacerclickboton('eventos_intervencion.aspx?sw=1&param002=" + grupo + "&param003=" + plan + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "algo();", true);

    }
    //boton Limpiar
    protected void wib002_Click(object sender, EventArgs e)
    {
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");

        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
        //alerts.Visible = false;
        //lbl005.Visible = false;
        grd002.Visible = false;
        utab.Visible = false;
        titulo_tab.Visible = false;
        wib004.Visible = false;
        btnbuscar.Visible = true;
        //ddown001.SelectedValue = "0";
        //ddown002.SelectedValue = "0";
        txt_name.Text = "";
        txt_patern.Text = "";
        txt_matern.Text = "";
        grd001.Visible = false;

        lbl_resumen_filtro.Style.Add("display", "none");

        //grd002.Attributes.Add("style", "display:none");
        //utab.Attributes.Add("style", "display:none");
        //titulo_tab.Attributes.Add("style", "display:none");
        //wib004.Attributes.Add("style", "display:none");

        //pnl002.Visible = true;
        ddown001.Enabled = true;
        txt_name.Enabled = true;
        txt_patern.Enabled = true;
        txt_matern.Enabled = true;
        ddown002.Enabled = true;
        //lbl001.Visible = true;

        limpiarListviews();

        //------------------------------------------------------------------
        // JOVM - 09/03/2015
        // Se limpian datos de la Session
        Session["NNA"] = null;
        //------------------------------------------------------------------
    }
    //boton Volver
    protected void wib003_Click(object sender, EventArgs e)
    {
        Response.Redirect("../index.aspx");
    }

    private void limpiarListviews()
    {
        DescripcionesEvaluacionDelLogro.Visible = false;
        DescripcionesImplementacionMedida.Visible = false;
        DescripcionesIntervencionNNA.Visible = false;
        DescripcionesNivelIntervencion.Visible = false;
        DescripcionesTrabajoConFamilia.Visible = false;
        getDescripcionTrabajoGarantesDerecho.Visible = false;
        getDescripcionSintomatología.Visible = false;
        DescripcionesGestionRedes24Horas.Visible = false;
        DescripcionesRedes.Visible = false;
        DescripcionesNivelIntervencionPsicosocial.Visible = false;

        DescripcionesEvaluacionDelLogro.Items.Clear();
        DescripcionesImplementacionMedida.Items.Clear();
        DescripcionesIntervencionNNA.Items.Clear();
        DescripcionesNivelIntervencion.Items.Clear();
        DescripcionesTrabajoConFamilia.Items.Clear();
        getDescripcionTrabajoGarantesDerecho.Items.Clear();
        getDescripcionSintomatología.Items.Clear();
        DescripcionesGestionRedes24Horas.Items.Clear();
        DescripcionesRedes.Items.Clear();
        DescripcionesNivelIntervencionPsicosocial.Items.Clear();

        DescripcionesEvaluacionDelLogro.DataBind();
        DescripcionesImplementacionMedida.DataBind();
        DescripcionesIntervencionNNA.DataBind();
        DescripcionesNivelIntervencion.DataBind();
        DescripcionesTrabajoConFamilia.DataBind();
        getDescripcionTrabajoGarantesDerecho.DataBind();
        getDescripcionSintomatología.DataBind();
        DescripcionesGestionRedes24Horas.DataBind();
        DescripcionesRedes.DataBind();
        DescripcionesNivelIntervencionPsicosocial.Items.Clear();
        

        updateDescripcionesPII.DataBind();
        updateDescripcionesPII.Update();
    }

    protected void BuscaPlanIntervencion()
    {
        oNNA NNA = (oNNA)Session["NNA"];

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        string consulta = "Select distinct T1.CodPlanIntervencion, T1.CodProyecto, T1.CodInstitucion, T1.CodGrupo From PlanIntervencion T1 " +
                        "Inner Join NINOS T2 On T1.CodNino = T2.CodNino " +
                        "Inner Join EstadosPlanIntervencion T3 On T1.CodPlanIntervencion = T3.CodPlanIntervencion " +
                        "Inner Join PlanIntervencionGrupo T6 on T1.CodGrupo = T6.CodGrupo " +
                        "Inner Join Trabajadores T5 ON T1.Icodtrabajador = T5.IcodTrabajador " +
                        "Inner Join Ingresos_Egresos T7 ON T2.CodNino = T7.CodNino " +
                        "Where  T1.FechaTerminoRealPII='01/01/1900' and T1.CodGradoCumplimiento=-1 and T1.HabilitadoParaEgreso=-1 and " +
                        "T1.IntervencionCompleta=-1 and  T7.FechaEgreso is null and T7.EstadoIE=0 and T1.codnino=" + NNA.NNACodNino;

        con.ejecutar(consulta, out datareader);
        DataTable dt = new DataTable();
        //DataRow dr;
        while (datareader.Read())
        {
            codplaninterv = (int)datareader["CodPlanIntervencion"];
            codgrupo = (int)datareader["CodGrupo"];
            codProyecto = (int)datareader["CodProyecto"];
            codInstitucion = (int)datareader["CodInstitucion"];
        }
        con.Desconectar();
    }
    protected void A3_ServerClick(object sender, EventArgs e)
    {

    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnbuscar.Visible = true;
        //btnbuscar.Attributes.Add("style", "margin-top: 10px");
        preperarboton();

        grd001.Visible = false;
        
    }

    //modificaciones 29-07-2015

    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        int ICodTrabajador = 0, CodGrupo = 0, CodPlanIntervencion = 0, CodNino = 0;
        int proyecto = Convert.ToInt32(ddown002.SelectedValue.ToString());
        pintervencion bsc_int = new pintervencion();
        DataTable dt = bsc_int.Get_PII_Ninos(proyecto, CodPlanIntervencion, CodNino, "", ICodTrabajador, txt_patern.Text.Trim(), txt_matern.Text.Trim(), txt_name.Text.Trim(), CodGrupo);

        DtBusqueda = dt;

        DataView dv = new DataView(dt);
        dv.Sort = "Apellido_Paterno";
        grd001.DataSource = dv;
        grd001.DataBind();


        //pnl001.Visible = false;
        if (grd001.Rows.Count > 0)
        {
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                if (grd001.Rows[i].Cells[14].Text == "0")
                {
                    //grd001.Rows[i].Cells[17].Visible = true;
                    grd001.Rows[i].Cells[16].Enabled = false;
                    //grd001.Rows[i].Cells[16].Visible = false;

                }
                else
                {
                    //grd001.Rows[i].Cells[17].Visible = false;
                    //grd001.Rows[i].Cells[16].Visible = true;
                }
            }
            //grd001.Attributes.Add("style", "");

            lbl_resumen_filtro.Text = "<br>";
            lbl_resumen_filtro.Text += "- <strong>Busqueda: </strong> " + ddown002.SelectedItem.Text + " ";

            if (txt_patern.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += "//" + " " + txt_patern.Text.Trim() + "";
            }

            if (txt_matern.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += " " + txt_matern.Text.Trim() + " ";
            }
            if (txt_name.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += "" + txt_name.Text.Trim() + " ";
            }

            lbl_resumen_filtro.Visible = true;
            lbl_resumen_filtro.Style.Add("display", "none");
            grd001.Visible = true;
            if (grd001.Rows.Count > 15)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
            }
            alerts.Attributes.Add("style", "display:none");
            lbl005.Attributes.Add("style", "display:none");
            btnbuscar.Visible = false;
        }
        else
        {
            btnbuscar.Visible = true;
            lbl005.Text = "El niño no posee plan de intervención asignado, por favor asignar un plan o realizar una nueva busqueda";
            //alerts.Visible = true;
            lbl005.Attributes.Add("style", "display:inline");
            alerts.Attributes.Add("style", "display:block");

        }
    }
    private void CargaGrilla()
    {

        DataTable dt = DtBusqueda;
        DataView dv = new DataView(dt);
        dv.Sort = "";
        grd001.DataSource = dv;
        grd001.DataBind();

        //pnl001.Visible = false;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            if (grd001.Rows[i].Cells[14].Text == "0")
            {
                //grd001.Rows[i].Cells[17].Visible = true;
                grd001.Rows[i].Cells[16].Enabled = false;
                //grd001.Rows[i].Cells[16].Visible = false;
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                //grd001.Rows[i].Cells[17].Visible = false;
                //grd001.Rows[i].Cells[16].Visible = true;
            }
        }
        //grd001.Attributes.Add("style", "");
        grd001.Visible = true;
        if (grd001.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
        }


    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla();
    }


    public DataTable parSeguimientoxModeloIntervencion(int CodModelo, int Opc)
    {
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("getParSeguimientoxModeloIntervencion", sqlc);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 10000000;
        command.Parameters.Add("@CodModelo", SqlDbType.Int).Value = CodModelo;
        command.Parameters.Add("@OPC", SqlDbType.Int).Value = Opc;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);
        DataTable dt = new DataTable();

        command.Connection.Open();
        sqlda.Fill(dt);
        command.Connection.Close();

        return dt;

    }

    public DataSet parSeguimientoxModeloIntervencionDataset(int CodModelo, int Opc)
    {
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("getParSeguimientoxModeloIntervencion", sqlc);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 10000000;
        command.Parameters.Add("@CodModelo", SqlDbType.Int).Value = CodModelo;
        command.Parameters.Add("@OPC", SqlDbType.Int).Value = Opc;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        DataSet ds = new DataSet();

        command.Connection.Open();
        sqlda.Fill(ds);
        command.Connection.Close();

        return ds;
    }

    public DataTable getICodparResultado(int CodModelo, int CodSeguimiento)
    {
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("getiCodparResultado", sqlc);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;

        command.Parameters.Add("@CodModelo", SqlDbType.Int).Value = CodModelo;
        command.Parameters.Add("@CodSeguimiento", SqlDbType.Int).Value = CodSeguimiento;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        DataTable dt = new DataTable();

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();

        return dt;
    }
    public DataTable getPonderacionesxResultado(int CodModelo, int CodSeguimiento, int iCodparResultado)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("get_PonderacionResultados", sqlc);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;

        command.Parameters.Add("@CodModelo", SqlDbType.Int).Value = CodModelo;
        command.Parameters.Add("@CodSeguimiento", SqlDbType.Int).Value = CodSeguimiento;
        command.Parameters.Add("@iCodparResultado", SqlDbType.Int).Value = iCodparResultado;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();


        return dt;
    }

    private void SeleccionaUno(int iFilaSeleccionada)
    {

        //int codModelo;

        //codModelo = 98;

        //DataTable dtCodSeguimientoPII = parSeguimientoxModeloIntervencion(codModelo, 1);



        btnbuscar.Visible = false;
        //btnbuscar.Attributes.Add("style", "display:none; margin-top: 10px;");
        //if (iFilaSeleccionada != 0)
        //{

        if (grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[14].Text != "0")
        {
            bscq = "NGRUPO";
        }
        else
        {
            bscq = "NGRUPO";
            // original bscq = "EGRUPO";
        }


        if (grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[14].Text != null && ddown002.SelectedValue.ToString() == grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[14].Text)
        {
            codInstitucion = Convert.ToInt32(ddown001.SelectedValue.ToString());
            codProyecto = Convert.ToInt32(ddown002.SelectedValue.ToString());
        }


        codInstitucion = Convert.ToInt32(ddown001.SelectedValue.ToString());
        codProyecto = Convert.ToInt32(ddown002.SelectedValue.ToString());

        proyectocoll proyecto = new proyectocoll();

        DataTable dt = new DataTable();
        dt = proyecto.GetProyectos2(codProyecto);

        CodModelo = dt.Rows[0]["CodModeloIntervencion"].ToString();

        codgrupo = 0;
        tipoPlan = "I";

        //ddown001.SelectedValue = codInstitucion.ToString();
        //getproyectosxcod();
        //ddown002.SelectedValue = codProyecto.ToString();
        codplaninterv = Convert.ToInt32(grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[0].Text);
        //A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv;
        piiinter.Value = codplaninterv.ToString();
        pigrupo.Value = codgrupo.ToString();
        Get_Resultado_Busqueda_individual();
        //grd001.Attributes.Add("style", "display:none");
        grd001.Visible = false;
        refillTabs();


        if (grd002.Rows[0].Cells[8].Text == "01-01-1900")
        {
            grd002.Rows[0].Cells[8].Text = "";
        }


        lbl_resumen_filtro.Text = "";
        lbl_resumen_filtro.Text += "- <strong>Busqueda: </strong> " + ddown002.SelectedItem.Text + " ";

        if (txt_patern.Text.Trim() != "")
        {
            lbl_resumen_filtro.Text += "//" + " " + txt_patern.Text.Trim() + "";
        }

        if (txt_matern.Text.Trim() != "")
        {
            lbl_resumen_filtro.Text += " " + txt_matern.Text.Trim() + " ";
        }
        if (txt_name.Text.Trim() != "")
        {
            lbl_resumen_filtro.Text += "" + txt_name.Text.Trim() + " ";
        }
        //}
    }
    private void SeleccionaUnoSession(int iFilaSeleccionada)
    {
        btnbuscar.Visible = false;
        //btnbuscar.Attributes.Add("style", "display:none; margin-top: 10px;");
        if (iFilaSeleccionada != 0)
        {

            if (grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[14].Text != "0")
            {
                bscq = "NGRUPO";
            }
            else
            {
                bscq = "NGRUPO";
                // original bscq = "EGRUPO";
            }


            if (grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[14].Text != null && ddown002.SelectedValue.ToString() == grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[14].Text)
            {
                codInstitucion = Convert.ToInt32(ddown001.SelectedValue.ToString());
                codProyecto = Convert.ToInt32(ddown002.SelectedValue.ToString());
            }

            codgrupo = 0;
            tipoPlan = "I";

            //ddown001.SelectedValue = codInstitucion.ToString();
            //getproyectosxcod();
            //ddown002.SelectedValue = codProyecto.ToString();
            codplaninterv = Convert.ToInt32(grd001.Rows[Convert.ToInt32(iFilaSeleccionada)].Cells[0].Text);
            //A4.HRef = "eventos_intervencion.aspx?sw=1&param002=" + codgrupo + "&param003=" + codplaninterv;
            piiinter.Value = codplaninterv.ToString();
            pigrupo.Value = codgrupo.ToString();
            Get_Resultado_Busqueda_individual();
            //grd001.Attributes.Add("style", "display:none");
            grd001.Visible = false;
            refillTabs();

            lbl_resumen_filtro.Text = "";
            lbl_resumen_filtro.Text += "- <strong>Busqueda: </strong> " + ddown002.SelectedItem.Text + " ";

            if (txt_patern.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += "//" + " " + txt_patern.Text.Trim() + "";
            }

            if (txt_matern.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += " " + txt_matern.Text.Trim() + " ";
            }
            if (txt_name.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += "" + txt_name.Text.Trim() + " ";
            }
        }
    }

    private bool ModeloIntervencionConNuevasVariables()
    {
        if (this.CodModelo == "16" || //CTL
            this.CodModelo == "17" || //CTD
            this.CodModelo == "44" ||
            this.CodModelo == "46" ||
            this.CodModelo == "83" ||
            this.CodModelo == "86" || //PRM
            this.CodModelo == "91" || //FAS
            this.CodModelo == "92" ||
            this.CodModelo == "98" ||
            this.CodModelo == "100" || //CIP
            this.CodModelo == "101" || //CSC
            this.CodModelo == "104" || //CRC
            this.CodModelo == "106" || //PAS
            this.CodModelo == "111" ||
            this.CodModelo == "112" ||
            this.CodModelo == "113" ||
            this.CodModelo == "129" ||
            this.CodModelo == "138" ||
            this.CodModelo == "139" ||
            this.CodModelo == "141" ||
            this.CodModelo == "142")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SELECCIONAR")
        {
            SeleccionaUno(Convert.ToInt32(e.CommandArgument));

            //Carga la informacion de Resultado de seguimiento del plan de intervención según el modelo
            #region Validacion Trasladada
            //if (CodModelo == "44" ||
            //    CodModelo == "46" ||
            //    CodModelo == "83" ||
            //    CodModelo == "86" ||
            //    CodModelo == "92" ||
            //    CodModelo == "98" ||
            //    CodModelo == "106" || 
            //    CodModelo == "129" ||
            //    CodModelo == "142")
            #endregion

            if (ModeloIntervencionConNuevasVariables())
            {
                getInformacionResultadoSeguimientoPII(Convert.ToInt32(this.CodModelo));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openCollapse", "$('#SeguimientoPII').click();", true);
            }
            else
            {
                DescripcionesEvaluacionDelLogro.Visible = false;
                DescripcionesImplementacionMedida.Visible = false;
                DescripcionesIntervencionNNA.Visible = false;
                DescripcionesNivelIntervencion.Visible = false;
                DescripcionesTrabajoConFamilia.Visible = false;
                getDescripcionTrabajoGarantesDerecho.Visible = false;
                getDescripcionSintomatología.Visible = false;
                DescripcionesGestionRedes24Horas.Visible = false;

                updateDescripcionesPII.Update();
            }
        }
    }


    public void getInformacionResultadoSeguimientoPII(int CodModelo)
    {
        int codSeguimiento = 0;

        //DataTable dtCodSeguimientoPII = parSeguimientoxModeloIntervencion(CodModelo, 1);
        DataSet dsSeguimientoPII = new DataSet();
        dsSeguimientoPII = parSeguimientoxModeloIntervencionDataset(CodModelo, 1);

        DataTable dtCodSeguimientoPII = dsSeguimientoPII.Tables[0];
        DataTable dtCodseguimientoNoEnModelo = dsSeguimientoPII.Tables[1];

        #region Codigo Refactorizado
        if (ModeloIntervencionConNuevasVariables())
        {
            if (ObtenerNivelesPlanIntervencion(codplaninterv).Rows.Count > 0)
            {
                for (int i = 0; i < resultadoNiveles.Rows.Count; i++)
                {
                    int CodNivelIntervencion = Convert.ToInt32(resultadoNiveles.Rows[i]["CodNivelIntervencion"]);

                    if (CodNivelIntervencion > 0)
                    {
                        if (CodNivelIntervencion == 1) //Individual
                        {
                            DescripcionesIntervencionNNA.Visible = true;
                        }

                        if (CodNivelIntervencion == 2) //Familiar
                        {
                            DescripcionesTrabajoConFamilia.Visible = true;
                        }

                        if (CodNivelIntervencion == 5) //Judicial
                        {
                            DescripcionesNivelIntervencion.Visible = true;
                        }

                        if (CodNivelIntervencion == 6) //Redes
                        {
                            DescripcionesRedes.Visible = true;
                        }
                        if (CodNivelIntervencion == 7) //Capacitación
                        {
                            DescripcionesCapacitacion.Visible = true;
                        }

                        if (CodNivelIntervencion == 8) //Trabajo Garantes de Derecho
                        {
                            getDescripcionTrabajoGarantesDerecho.Visible = true;
                        }

                        if (CodNivelIntervencion == 9) //Psicosocial
                        {
                            DescripcionesNivelIntervencionPsicosocial.Visible = true;
                        }
                        // En ciertos modelos se pide evaluacion de sintomatología, que no posee nivel de intervención, asi que lo seguire cargando por modelos por ahora.
                        if (CodModelo == 129) 
                        {
                            getDescripcionSintomatología.Visible = true;
                        }

                        #region ValidacionAntigua
                        //if (CodNivelIntervencion == 1) // Individual
                        //{
                        //    DescripcionesIntervencionNNA.Visible = true;
                        //}
                        //else if (CodNivelIntervencion == 2) //Familiar
                        //{
                        //    DescripcionesTrabajoConFamilia.Visible = true;

                        //}
                        //else if (CodNivelIntervencion == 3) //Grupal
                        //{
                        //    //N/A
                        //}
                        //else if (CodNivelIntervencion == 4) //Comunitaria
                        //{
                        //    //N/A
                        //}
                        //else if (CodNivelIntervencion == 5) //Judicial
                        //{
                        //    DescripcionesNivelIntervencion.Visible = true;
                        //}
                        //else if (CodNivelIntervencion == 6) //Redes
                        //{

                        //}
                        //else if (CodNivelIntervencion == 7) //Capacitación
                        //{

                        //}
                        //else if (CodNivelIntervencion == 8) //Garantes de Derecho
                        //{
                        //    getDescripcionTrabajoGarantesDerecho.Visible = true;
                        //}
                        //else
                        //{

                        //}
                        #endregion
                       
                    }
                }

                foreach (DataRow drow in dtCodSeguimientoPII.Rows)
                {
                    codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
                    cargaOrigenes(CodModelo, codSeguimiento);
                }

                foreach (DataRow drow in dtCodseguimientoNoEnModelo.Rows)
                {
                    codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
                    cargaOrigenesEnBlanco(codSeguimiento);
                }



                //for (int i = 0; i < resultadoNiveles.Rows.Count; i++)
                //{
                //    ocultarListViewSinNivel(Convert.ToInt32(resultadoNiveles.Rows[i]["CodNivelIntervencion"]));
                //}
            }
            updateDescripcionesPII.DataBind();
            updateDescripcionesPII.Update();

            //LimpiarDescripciones();



        }
        #endregion

        #region Codigo a Refactorizar
        //if (CodModelo == 16)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}
        //if (CodModelo == 17)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 44)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 46)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 83)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 86)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 92)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 98)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 100)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 101)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 104)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 106)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 111)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 112)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 113)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 129)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 138)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 139)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 141)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}

        //if (CodModelo == 142)
        //{
        //    foreach (DataRow drow in dtCodSeguimientoPII.Rows)
        //    {
        //        codSeguimiento = Convert.ToInt32(drow["CodSeguimientoPII"]);
        //        cargaOrigenes(CodModelo, codSeguimiento);
        //    }
        //}
        #endregion

    }

    private void ocultarListViewSinNivel(int codNivelIntervencion)
    {

    }

    protected DataTable ObtenerNivelesPlanIntervencion(int codplanintervencion)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("getNivelesIntervencionDelPII", sqlc);



        command.CommandTimeout = 1000000;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@codplanintervencion", SqlDbType.Int).Value = codplanintervencion;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);
        command.Connection.Open();
        sqlda.Fill(dt);
        command.Connection.Close();

        resultadoNiveles = dt;

        return dt;
    }

    private void cargaOrigenesEnBlanco(int codSeguimiento)
    {
        if (codSeguimiento == 1)
        {
            getDescripcionesNivelIntervencion.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesNivelIntervencion.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesNivelIntervencion.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }

        if (codSeguimiento == 2)
        {
            getDescripcionesImplementacionMedida.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesImplementacionMedida.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesImplementacionMedida.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 3)
        {
            getDescripcionesIntervencionNNA.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesIntervencionNNA.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesIntervencionNNA.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 4)
        {
            getDescripcionesTrabajoConFamilia.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesTrabajoConFamilia.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesTrabajoConFamilia.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 5)
        {
            getDescripcionesEvaluacionDelLogro.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesEvaluacionDelLogro.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesEvaluacionDelLogro.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 6)
        {
            getDescripcionesSintomatologia.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesSintomatologia.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesSintomatologia.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 7)
        {
            getDescripcionesTrabajoGarantesDerecho.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesTrabajoGarantesDerecho.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesTrabajoGarantesDerecho.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 8)
        {
            getDescripcionesGestionRedes24Horas.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesGestionRedes24Horas.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesGestionRedes24Horas.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }

        if (codSeguimiento == 9)
        {
            getDescripcionesRedes.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesRedes.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesRedes.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }

        if (codSeguimiento == 10)
        {
            getDescripcionesPsicosocial.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesPsicosocial.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesPsicosocial.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }
        if (codSeguimiento == 11)
        {
            getDescripcionesCapacitacion.SelectParameters["CodModelo"].DefaultValue = "0";
            getDescripcionesCapacitacion.SelectParameters["CodSeguimiento"].DefaultValue = "0";
            getDescripcionesCapacitacion.SelectParameters["CodPlanIntervencion"].DefaultValue = "0";
        }

    }

    private void LimpiarDescripciones()
    {
        DescripcionesNivelIntervencion.Items.Clear();
        DescripcionesNivelIntervencion.DataBind();
        DescripcionesNivelIntervencion.Visible = false;

        DescripcionesImplementacionMedida.Items.Clear();
        DescripcionesImplementacionMedida.DataBind();
        DescripcionesImplementacionMedida.Visible = false;

        DescripcionesIntervencionNNA.Items.Clear();
        DescripcionesIntervencionNNA.DataBind();
        DescripcionesIntervencionNNA.Visible = false;

        DescripcionesTrabajoConFamilia.Items.Clear();
        DescripcionesTrabajoConFamilia.DataBind();
        DescripcionesTrabajoConFamilia.Visible = false;

        DescripcionesEvaluacionDelLogro.Items.Clear();
        DescripcionesEvaluacionDelLogro.DataBind();
        DescripcionesEvaluacionDelLogro.Visible = false;

        getDescripcionTrabajoGarantesDerecho.Items.Clear();
        getDescripcionTrabajoGarantesDerecho.DataBind();
        getDescripcionTrabajoGarantesDerecho.Visible = false;

        getDescripcionSintomatología.Items.Clear();
        getDescripcionSintomatología.DataBind();
        getDescripcionSintomatología.Visible = false;

        DescripcionesGestionRedes24Horas.Items.Clear();
        DescripcionesGestionRedes24Horas.DataBind();
        DescripcionesGestionRedes24Horas.Visible = false;

        DescripcionesRedes.Items.Clear();
        DescripcionesRedes.DataBind();
        DescripcionesRedes.Visible = false;

        updateDescripcionesPII.Update();

    }

    protected void cargaOrigenes(int codModelo, int codSeguimiento)
    {
        if (codSeguimiento == 1)
        {
            getDescripcionesNivelIntervencion.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesNivelIntervencion.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesNivelIntervencion.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();
        }

        if (codSeguimiento == 2)
        {
            getDescripcionesImplementacionMedida.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesImplementacionMedida.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesImplementacionMedida.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();

        }
        if (codSeguimiento == 3)
        {
            getDescripcionesIntervencionNNA.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesIntervencionNNA.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesIntervencionNNA.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();

            cargaDropdowns(codModelo, codSeguimiento);

        }
        if (codSeguimiento == 4)
        {
            getDescripcionesTrabajoConFamilia.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesTrabajoConFamilia.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesTrabajoConFamilia.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();

            cargaDropdowns(codModelo, codSeguimiento);

        }
        if (codSeguimiento == 5)
        {
            getDescripcionesEvaluacionDelLogro.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesEvaluacionDelLogro.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesEvaluacionDelLogro.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();

            cargaDropdowns(codModelo, codSeguimiento);
        }
        if (codSeguimiento == 6)
        {
            getDescripcionesSintomatologia.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesSintomatologia.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesSintomatologia.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();

            cargaDropdowns(codModelo, codSeguimiento);

        }
        if (codSeguimiento == 7)
        {
            getDescripcionesTrabajoGarantesDerecho.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesTrabajoGarantesDerecho.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesTrabajoGarantesDerecho.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();

        }
        if (codSeguimiento == 8)
        {
            getDescripcionesGestionRedes24Horas.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesGestionRedes24Horas.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesGestionRedes24Horas.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();
        }

        if (codSeguimiento == 9)
        {
            getDescripcionesRedes.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesRedes.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesRedes.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();
        }

        if (codSeguimiento == 10)
        {
            getDescripcionesPsicosocial.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesPsicosocial.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesPsicosocial.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();
        }

        if (codSeguimiento == 11)
        {
            getDescripcionesCapacitacion.SelectParameters["CodModelo"].DefaultValue = codModelo.ToString();
            getDescripcionesCapacitacion.SelectParameters["CodSeguimiento"].DefaultValue = codSeguimiento.ToString();
            getDescripcionesCapacitacion.SelectParameters["CodPlanIntervencion"].DefaultValue = codplaninterv.ToString();
        }

    }

    protected void cargaDropdowns(int codModelo, int CodSeguimiento)
    {
        DataTable dt = new DataTable();

        dt = parSeguimientoxModeloIntervencion(codModelo, 2);

        foreach (DataRow drow in dt.Rows)
        {
            DataTable dtPonderacionResultados = new DataTable();

            int iCodparResultado = Convert.ToInt32(drow["iCodparResultado"].ToString());

            dt = getPonderacionesxResultado(codModelo, CodSeguimiento, iCodparResultado);

            if (dt.Rows.Count > 0)
            {
                if (iCodparResultado == 14 && codModelo == 86) //PRM
                {
                    getPonderacionesNNAEgresoporPII.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesNNAEgresoporPII.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesNNAEgresoporPII.SelectParameters["ICodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 19 && codModelo == 86) //PRM
                {
                    getPonderacionesEvaluaciondelLogro.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesEvaluaciondelLogro.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesEvaluaciondelLogro.SelectParameters["ICodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 32 && codModelo == 106) //PAS
                {
                    getPonderacionesInterrumpeConductas.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesInterrumpeConductas.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesInterrumpeConductas.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 36 && codModelo == 106) //PAS
                {
                    getPonderacionesNNAEgresoporPIIPAS.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesNNAEgresoporPIIPAS.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesNNAEgresoporPIIPAS.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 42 && codModelo == 106) //PAS
                {
                    getPonderacionAdultosaCargo.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionAdultosaCargo.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionAdultosaCargo.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 43 && codModelo == 106) //PAS
                {
                    getPonderacionesSintomatologia.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesSintomatologia.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesSintomatologia.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 64 && codModelo == 46) //PEE
                {
                    getPonderacionAdultosaCargoPEE.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionAdultosaCargoPEE.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionAdultosaCargoPEE.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 85 && codModelo == 44) //PEC
                {
                    getPonderacionAdultosaCargoPEC.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionAdultosaCargoPEC.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionAdultosaCargoPEC.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 120 && codModelo == 83) //PAD
                {
                    getPonderacionesEvaluaciondelLogroPAD.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesEvaluaciondelLogroPAD.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesEvaluaciondelLogroPAD.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 134 && codModelo == 129) //PPF
                {
                    getPonderacionAdultosaCargoPPF.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionAdultosaCargoPPF.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionAdultosaCargoPPF.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 136 && codModelo == 129)//PPF
                {
                    getPonderacionesEvaluaciondelLogroPPF.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesEvaluaciondelLogroPPF.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesEvaluaciondelLogroPPF.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }

                if (iCodparResultado == 137 && codModelo == 129)//PPF
                {
                    getPonderacionesSintomatologiaPPF.SelectParameters["CodModelo"].DefaultValue = CodModelo.ToString();
                    getPonderacionesSintomatologiaPPF.SelectParameters["CodSeguimiento"].DefaultValue = CodSeguimiento.ToString();
                    getPonderacionesSintomatologiaPPF.SelectParameters["iCodparResultado"].DefaultValue = iCodparResultado.ToString();
                }
            }
        }
    }


    public void refillTabs()
    {
        refillTab1();
        refillTab2();
        refillTab3();
        refillTab4();
        refillTab5();
    }

    #region Tab1
    //******************************************************//
    //**<!-- Tab 1 Datos Plan de Intervencion  FUO -->******//
    //******************************************************//

    //Si el niño fue seleccionado:
    public void refillTab1()
    {
        Modificado_DatosPlan = 0;
        getTrabajadores2();
        if (tipoPlan == "I")
        {
            //Label1.Visible = false;
            //txt_idg.Visible = false;            
            Get_Datos_Plan_Individual();
        }
        else if (tipoPlan == "G")
        {
            Get_Datos_Plan_Grupal();
        }

        try
        {
            if (bscq == "EGRUPO")
            {

                //txt_idg.ReadOnly = true;
                txt_fep.Enabled = false;
                txt_fip.Enabled = false;
                txt_ftp.Enabled = false;
                ddl_tecnico.Enabled = false;
                txt_dsc.ReadOnly = true;
            }
        }
        catch { }
    }
    private void getTrabajadores2()
    {

        trabajadorescoll tcoll = new trabajadorescoll();
        DataView dv1 = new DataView(tcoll.GetTrabajadoresProyecto(codProyecto.ToString()));
        ddl_tecnico.Items.Clear();
        ddl_tecnico.DataSource = dv1;
        ddl_tecnico.DataTextField = "NombreCompleto";
        ddl_tecnico.DataValueField = "ICodTrabajador";
        dv1.Sort = "NombreCompleto";
        ddl_tecnico.DataBind();


    }
    private void Get_Datos_Plan_Grupal()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = pin.GetPlanIntervencionxGrupo(codgrupo);
        if (dt.Rows.Count > 0)
        {
            //txt_idg.Text = dt.Rows[0][15].ToString();
            txt_fep.Text = Convert.ToDateTime(dt.Rows[0][1]).ToShortDateString();
            fechaelaboracionplan = Convert.ToDateTime(dt.Rows[0][1]);
            txt_fip.Text = Convert.ToDateTime(dt.Rows[0][8]).ToShortDateString();
            txt_ftp.Text = Convert.ToDateTime(dt.Rows[0][9]).ToShortDateString();
            try
            {
                ddl_tecnico.SelectedValue = dt.Rows[0][5].ToString();
            }
            catch (Exception e)
            {
                ddl_tecnico.SelectedValue = "0";
            }
            txt_dsc.Text = dt.Rows[0][11].ToString();

            CalendarExtender1.StartDate = Convert.ToDateTime(txt_fep.Text);
            CalendarExtender3.StartDate = Convert.ToDateTime(txt_fip.Text).AddDays(1);
            fechainicioplan = Convert.ToDateTime(txt_fip.Text);
        }
    }
    private void Get_Datos_Plan_Individual()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = pin.GetPlanIntervencionxNino(codplaninterv);
        if (dt.Rows.Count > 0)
        {
            txt_fep.Text = Convert.ToDateTime(dt.Rows[0][3]).ToShortDateString();
            fechaelaboracionplan = Convert.ToDateTime(dt.Rows[0][3]);
            txt_fip.Text = Convert.ToDateTime(dt.Rows[0][10]).ToShortDateString();
            txt_ftp.Text = Convert.ToDateTime(dt.Rows[0][11]).ToShortDateString();
            try
            {
                ddl_tecnico.SelectedValue = dt.Rows[0][7].ToString();
            }
            catch (Exception e)
            {
                ddl_tecnico.SelectedValue = "0";
            }

            txt_dsc.Text = dt.Rows[0][13].ToString();

            CalendarExtender1.StartDate = Convert.ToDateTime(txt_fep.Text);
            CalendarExtender3.StartDate = Convert.ToDateTime(txt_fip.Text).AddDays(1);
            fechainicioplan = Convert.ToDateTime(txt_fip.Text);
        }
    }
    protected void txt_fip_ValueChanged(object sender, EventArgs e)
    {
        CalendarExtender3.StartDate = Convert.ToDateTime(txt_fip.Text).AddDays(1);
        Modificado_DatosPlan = 1;
    }
    private void update_datos_plan()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if ((txt_fep.Text == null || txt_fep.Text.Trim() == "" || txt_fip.Text == null || txt_fip.Text.Trim() == "" || txt_ftp.Text == null || txt_ftp.Text.Trim() == "" || ddl_tecnico.SelectedValue == "0") && tipoPlan == "G")
        {
            if (txt_fep.Text.Trim() == "")
            { txt_fep.BackColor = colorCampoObligatorio; }
            else { txt_fep.BackColor = System.Drawing.Color.White; }
            if (txt_fip.Text.Trim() == "")
            { txt_fip.BackColor = colorCampoObligatorio; }
            else { txt_fip.BackColor = System.Drawing.Color.White; }
            if (txt_ftp.Text.Trim() == "")
            { txt_ftp.BackColor = colorCampoObligatorio; }
            else { txt_ftp.BackColor = System.Drawing.Color.White; }
            if (ddl_tecnico.SelectedValue == "0")
            { ddl_tecnico.BackColor = colorCampoObligatorio; }
            else { ddl_tecnico.BackColor = System.Drawing.Color.White; }
            //Response.Write("<script>window.parent.LlamaValidacion();</script>");
            alerts.Attributes.Add("style", "");
            lbl005.Text = "Faltan datos para actualizar Plan de Intervención";
            lbl005.Attributes.Add("style", "");

        }
        else if ((txt_fep.Text == null || txt_fep.Text.Trim() == "" || txt_fip.Text == null || txt_fip.Text.Trim() == "" || txt_ftp.Text == null || txt_ftp.Text.Trim() == "" || ddl_tecnico.SelectedValue == "0") && tipoPlan == "I")
        {
            if (txt_fep.Text == null || txt_fep.Text.Trim() == "")
            { txt_fep.BackColor = colorCampoObligatorio; }
            else { txt_fep.BackColor = System.Drawing.Color.White; }
            if (txt_fip.Text == null || txt_fip.Text.Trim() == "")
            { txt_fip.BackColor = colorCampoObligatorio; }
            else { txt_fip.BackColor = System.Drawing.Color.White; }
            if (txt_ftp.Text == null || txt_ftp.Text.Trim() == "")
            { txt_ftp.BackColor = colorCampoObligatorio; }
            else { txt_ftp.BackColor = System.Drawing.Color.White; }
            if (ddl_tecnico.SelectedValue == "0")
            { ddl_tecnico.BackColor = colorCampoObligatorio; }
            else { ddl_tecnico.BackColor = System.Drawing.Color.White; }
            //Response.Write("<script>window.parent.LlamaValidacion();</script>");
            alerts.Attributes.Add("style", "");
            lbl005.Text = "Faltan datos para actualizar Plan de Intervención";
            lbl005.Attributes.Add("style", "");


        }
        else
        {
            alerts2.Attributes.Add("style", "");
            lbl0052.Text = "Datos Plan de Intervención Actualizado con éxito";
            lbl0052.Attributes.Add("style", "");
            //txt_idg.BackColor = System.Drawing.Color.White;
            txt_fep.BackColor = System.Drawing.Color.White;
            txt_fip.BackColor = System.Drawing.Color.White;
            txt_ftp.BackColor = System.Drawing.Color.White;
            ddl_tecnico.BackColor = System.Drawing.Color.White;

            pintervencion pin = new pintervencion();
            if (tipoPlan == "G")
            {
                char[] splitter = { ',' };
                string[] codplan = codplanintervencion.Split(splitter);
                for (int i = 0; i < codplan.Length; i++)
                {
                    if (codplan[i].Trim() != "")
                    {
                        pin.callto_update_planintervencion_datosplan(Convert.ToInt32(codplan[i]), Convert.ToInt32(ddl_tecnico.SelectedValue),
                            Convert.ToDateTime(txt_fip.Text), Convert.ToDateTime(txt_ftp.Text), txt_dsc.Text, Convert.ToInt32(Session["IdUsuario"]),
                            codgrupo);
                    }
                }
                pin.Insert_Update_PlanIntervencionGrupo(codgrupo, "", "V");
            }
            else if (tipoPlan == "I")
            {
                pin.callto_update_planintervencion_datosplan(codplaninterv, Convert.ToInt32(ddl_tecnico.SelectedValue),
                Convert.ToDateTime(txt_fip.Text), Convert.ToDateTime(txt_ftp.Text), txt_dsc.Text, Convert.ToInt32(Session["IdUsuario"]),
                0);
            }


        }
    }

    protected void lbtActualizar_Click(object sender, EventArgs e)
    {
        muestra_pestaña(1);
        //consolaErrores.Text = "clicked";
        //consolaErrores.Visible = true;
        update_datos_plan();
        //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "alert('Actualizar, Se actualizo.');", true);

    }
    protected void txt_ftp_ValueChanged(object sender, EventArgs e)
    {
        Modificado_DatosPlan = 1;
    }
    protected void ddl_tecnico_SelectedIndexChanged(object sender, EventArgs e)
    {
        Modificado_DatosPlan = 1;
    }
    protected void txt_dsc_TextChanged(object sender, EventArgs e)
    {
        Modificado_DatosPlan = 1;
    }
    #endregion

    #region Tab2
    //******************************************************//
    //**<!-- Tab 2 Datos Plan de Intervencion  FUO -->******//
    //******************************************************//

    //Si el niño fue seleccionado:
    public void refillTab2()
    {
        gettipointervencion(codProyecto);
        getnivelintervencion();
        Carga_Areas_Intervencion();
        try
        {
            if (bscq == "EGRUPO")
            {
                btn_add.Visible = false;
                grdv_adp.Columns[2].Visible = false;

            }
        }
        catch { }
    }
    private void gettipointervencion(int CodProy)
    {
        parcoll pcoll = new parcoll();
        DataView dv1 = new DataView(pcoll.GetparEventosIntervencionCantidadxModelo(CodProy));
        ddl_tti.Items.Clear();
        ddl_tti.DataSource = dv1;
        ddl_tti.DataTextField = "Descripcion";
        ddl_tti.DataValueField = "TipoIntervencion";
        dv1.Sort = "Descripcion";
        ddl_tti.DataBind();


    }
    private void getnivelintervencion()
    {
        parcoll pcoll = new parcoll();
        DataView dv1 = new DataView(pcoll.GetparNivelIntervencion());
        if (tipoPlan == "G")
        {
            dv1.RowFilter = "CodNivelIntervencion <>'1'";
        }
        else
        {
            dv1.RowFilter = "CodNivelIntervencion <>'3'";
        }
        ddl_ndi.Items.Clear();
        ddl_ndi.DataSource = dv1;
        ddl_ndi.DataTextField = "Descripcion";
        ddl_ndi.DataValueField = "CodNivelIntervencion";
        dv1.Sort = "Descripcion";
        ddl_ndi.DataBind();


    }
    private void Carga_Areas_Intervencion()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = new DataTable();
        if (tipoPlan == "G")
        {

            //dt = pin.get_areaintervencion_grupo(codgrupo);
            dt = pin.get_areaintervencion_grupoII(codgrupo, codProyecto);
        }
        else if (tipoPlan == "I")
        {
            // dt = pin.get_areaintervencion_Nino(codplaninterv);
            dt = pin.get_areaintervencion_NinoII(codplaninterv, codProyecto);
        }

        if (dt.Rows.Count > 0 && dt.Rows[0]["ActualizaAreas"].ToString() == "0")
        {
            btn_add.Visible = false;
            grdv_adp.Columns[2].Visible = false;
        }

        if (dt.Rows.Count > 0)
        {
            grdv_adp.DataSource = dt;
            grdv_adp.DataBind();
            grdv_adp.Visible = true;


        }



    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        muestra_pestaña(2);
        pintervencion pin = new pintervencion();
        int CodModeloIntervencion = pin.get_CodModeloInterv(codProyecto);
        int CantidadMaximaAreas = 6;
        if (CodModeloIntervencion == 112)    // PIE COORDINADO
            CantidadMaximaAreas = 7;

        if (grdv_adp.Rows.Count < CantidadMaximaAreas)
        {
            if (ddl_tti.SelectedValue != "0" && ddl_ndi.SelectedValue != "0")
            {
                //lbl006.Visible = false;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add(new DataColumn("TipoIntervencion", typeof(String)));
                dt.Columns.Add(new DataColumn("NivelIntervencion", typeof(String)));
                dt.Columns.Add(new DataColumn("IdGrupoIntervenciones", typeof(String)));

                for (int i = 0; i < grdv_adp.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = Server.HtmlDecode(grdv_adp.Rows[i].Cells[0].Text);
                    dr[1] = Server.HtmlDecode(grdv_adp.Rows[i].Cells[1].Text);
                    dr[2] = grdv_adp.Rows[i].Cells[3].Text;
                    dt.Rows.Add(dr);
                }

                int check = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == ddl_tti.SelectedItem.Text &&
                        dt.Rows[i][1].ToString() == ddl_ndi.SelectedItem.Text)
                    {
                        check = 1;

                    }
                }
                if (check == 0)
                {
                    string iden = Guid.NewGuid().ToString();
                    char[] splitter = { ',' };
                    string[] codplan = codplanintervencion.Split(splitter);
                    for (int i = 0; i < codplan.Length; i++)
                    {
                        if (codplan[i].Trim() != "")
                        {
                            pin.Insert_Intervenciones(Convert.ToInt32(codplan[i]),
                            Convert.ToInt32(ddl_tti.SelectedValue), Convert.ToInt32(ddl_ndi.SelectedValue),
                            DateTime.Now, iden);
                        }
                    }

                    Carga_Areas_Intervencion();

                    if (grdv_adp.Rows.Count > 0)
                    {
                        getInformacionResultadoSeguimientoPII(Convert.ToInt32(CodModelo));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "x", "LoadScript();", true);
                    }


                }
                else
                {
                    alerts.Attributes.Add("style", "");
                    lbl005.Text = "No se pudo agregar, Ingrese una combinacion diferente.";
                    lbl005.Attributes.Add("style", "");
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('No se pudo agregar, Ingrese una combinacion diferente.');", true);
                    //lbl006.Text = "Ingrese una combinacion diferente.";
                    //lbl006.Visible = true;
                }

            }
            else
            {
                alerts.Attributes.Add("style", "");
                lbl005.Text = "No se pudo agregar, Debe seleccionar Tipo Intervención y Nivel de Intervención.";
                lbl005.Attributes.Add("style", "");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('No se pudo agregar, Debe seleccionar Tipo Intervención y Nivel de Intervención.');", true);
                //lbl006.Text = "* Debe seleccionar Tipo Intervención y Nivel de Intervención.";
                // lbl006.Visible = true;
            }
        }
        else
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "No se pudo agregar, excede la máxima cantidad de áreas de Intervención.";
            lbl005.Attributes.Add("style", "");
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('No se pudo agregar, excede la maxima cantidad de areas de intervencion.');", true);
            //lbl006.Text = "* Existe la maxima cantidad de requerimientos.";
            // lbl006.Visible = true;
        }
    }
    protected void grdv_adp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(2);
        pintervencion pin = new pintervencion();
        int cod_interv = pin.chek_interv_evento(grdv_adp.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
        if (grdv_adp.Rows.Count > 1)
        {
            if (cod_interv == 0)
            {
                pin.delete_intervenciones(grdv_adp.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
                Carga_Areas_Intervencion();
                //lbl006.Visible = false;
            }
            else
            {
                alerts.Attributes.Add("style", "");
                lbl005.Text = "La intervención seleccionada no puede ser eliminada, posee un evento relacionado.";
                lbl005.Attributes.Add("style", "");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Eliminar", "alert('La intervención seleccionada no puede ser eliminada, posee un evento relacionado.');", true);
                //lbl006.Text = "La intervención seleccionada no puede ser eliminada, posee un evento relacionado.";
                //lbl006.Visible = true;
            }
        }
        else
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "Error, el plan debe poseer al menos un Area de Intervención, agrege un área antes de eliminar.";
            lbl005.Attributes.Add("style", "");
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Eliminar", "alert('Error, el plan debe poseer al menos un Area de Intervención, agrege un área antes de eliminar.');", true);
            //lbl006.Text = "Error, el plan debe poseer al menos un Area de Intervención, agrege un área antes de eliminar.";
            //lbl006.Visible = true;
        }
    }
    protected void ddl_tti_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(2);
    }
    protected void ddl_ndi_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(2);
    }

    #endregion

    #region Tab3
    //******************************************************//
    //**<!-- Tab 3 Datos Plan de Intervencion  FUO -->******//
    //******************************************************//

    //Si el niño fue seleccionado:
    public void refillTab3()
    {
        getEstadoIntervencion();
        if (tipoPlan == "G")
        {
            carga_plan_grupal();
        }
        else
        {
            carga_plan_individual();
        }

        try
        {
            if (bscq == "EGRUPO")
            {
                ddl_edi.Enabled = false;
                rb_colaboracion_nino_si.Enabled = false;
                rb_colaboracion_nino_no.Enabled = false;
                rb_colaboracion_familia_si.Enabled = false;
                rb_colaboracion_familia_no.Enabled = false;
                txt_obvs.Enabled = false;
            }
        }
        catch { }

    }
    private void getEstadoIntervencion()
    {
        pintervencion pcoll = new pintervencion();
        DataView dv = new DataView(pcoll.GetparEStadoIntervencion());
        ddl_edi.Items.Clear();
        ddl_edi.DataSource = dv;
        ddl_edi.DataTextField = "Descripcion";
        ddl_edi.DataValueField = "CodEstadoIntervencion";
        dv.Sort = "CodEstadoIntervencion";
        ddl_edi.DataBind();
    }
    private void carga_plan_grupal()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = pin.GetEstadoIntervencionxGrupo(codgrupo);
        try
        {
            ddl_edi.SelectedValue = Convert.ToString(dt.Rows[0][2]);
        }
        catch (Exception e)
        {
            ddl_edi.SelectedIndex = 0;
        }

        codestadosplan = Convert.ToString(dt.Rows[0][2]);

        dt = pin.GetPlanIntervencionxGrupo(codgrupo);
        if (Convert.ToBoolean(dt.Rows[0][3]) == true)
        {
            rb_colaboracion_nino_si.Checked = true;
            rb_colaboracion_nino_no.Checked = false;
        }
        else
        {
            rb_colaboracion_nino_si.Checked = false;
            rb_colaboracion_nino_no.Checked = true;
        }

        //rb_colaboracion_nino_si.Checked = Convert.ToBoolean(dt.Rows[0][3]);

        if (Convert.ToBoolean(dt.Rows[0][4]) == true)
        {
            rb_colaboracion_nino_si.Checked = true;
            rb_colaboracion_nino_no.Checked = false;
        }
        else
        {
            rb_colaboracion_familia_si.Checked = false;
            rb_colaboracion_familia_no.Checked = true;
        }
        //rb_colaboracion_familia_si.Checked = Convert.ToBoolean(dt.Rows[0][4]);
        txt_obvs.Text = dt.Rows[0][12].ToString();

        char[] splitter = { ',' };
        string[] codplan = codplanintervencion.Split(splitter);
        dt = pin.GetEstadosPlanIntevencion(Convert.ToInt32(codplan[0]));
        if (dt.Rows.Count > 0)
        {
            ggdv_pdi.DataSource = dt;
            ggdv_pdi.DataBind();
            ggdv_pdi.Visible = true;

        }
    }
    private void carga_plan_individual()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = pin.GetEstadoIntervencionxNino(codplaninterv);

        if (dt.Rows.Count > 0)
        {

            ddl_edi.SelectedValue = Convert.ToString(dt.Rows[0][2]);
            codestadosplan = Convert.ToString(dt.Rows[0][2]);
            dt = pin.GetPlanIntervencionxNino(codplaninterv);

            if (Convert.ToBoolean(dt.Rows[0][5]) == true)
            {
                rb_colaboracion_nino_si.Checked = true;
                rb_colaboracion_nino_no.Checked = false;
            }
            else
            {
                rb_colaboracion_nino_si.Checked = false;
                rb_colaboracion_nino_no.Checked = true;
            }


            if (Convert.ToBoolean(dt.Rows[0][6]) == true)
            {
                rb_colaboracion_nino_si.Checked = true;
                rb_colaboracion_nino_no.Checked = false;
            }
            else
            {
                rb_colaboracion_familia_si.Checked = false;
                rb_colaboracion_familia_no.Checked = true;
            }

            //rb_colaboracion_nino_si.Checked = Convert.ToBoolean(dt.Rows[0][5]);
            //rb_colaboracion_familia_si.Checked = Convert.ToBoolean(dt.Rows[0][6]);
            txt_obvs.Text = dt.Rows[0][14].ToString();

            dt = pin.GetEstadosPlanIntevencion(codplaninterv);
            if (dt.Rows.Count > 0)
            {
                ggdv_pdi.DataSource = dt;
                ggdv_pdi.DataBind();
                ggdv_pdi.Visible = true;
            }
        }
    }
    protected void ddl_edi_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(3);
    }
    private void update_seguimientoPlan3()
    {
        pintervencion pin = new pintervencion();
        if (tipoPlan == "G")
        {
            char[] splitter = { ',' };
            string[] codplan = codplanintervencion.Split(splitter);
            for (int i = 0; i < codplan.Length; i++)
            {
                if (codplan[i].Trim() != "")
                {
                    pin.callto_insert_update_planintervencion_seguimientoplan(Convert.ToInt32(codplan[i]),
                    Convert.ToInt32(rb_colaboracion_nino_si.Checked), Convert.ToInt32(rb_colaboracion_familia_si.Checked), txt_obvs.Text);
                    pin.Insert_Update_EstadosPlanIntervencion(Convert.ToInt32(codestadosplan),
                    Convert.ToInt32(codplan[i]), Convert.ToInt32(ddl_edi.SelectedValue));
                }
            }
        }
        else if (tipoPlan == "I")
        {
            pin.callto_insert_update_planintervencion_seguimientoplan(codplaninterv,
            Convert.ToInt32(rb_colaboracion_nino_si.Checked), Convert.ToInt32(rb_colaboracion_familia_si.Checked), txt_obvs.Text);
            pin.Insert_Update_EstadosPlanIntervencion(Convert.ToInt32(codestadosplan),
                    codplaninterv, Convert.ToInt32(ddl_edi.SelectedValue));
        }
    }
    protected void lbtActualizar3_Click(object sender, EventArgs e)
    {
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");

        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
        muestra_pestaña(3);
        if (ddl_edi.SelectedIndex != 0)
        {
            update_seguimientoPlan3();
            CargarGridview();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "alert('Se actualizo.');", true);
            alerts2.Attributes.Add("style", "");
            lbl0052.Text = "Seguimiento de Intervención Actualizado con éxito";
            lbl0052.Attributes.Add("style", "");
            ddl_edi.BackColor = System.Drawing.Color.White;
        }
        else
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "Debe agregar un estado de Intervención";
            lbl005.Attributes.Add("style", "");
            System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
            ddl_edi.BackColor = colorCampoObligatorio;

        }

    }
    private void CargarGridview()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = pin.GetEstadoIntervencionxNino(codplaninterv);
        dt = pin.GetEstadosPlanIntevencion(codplaninterv);
        if (dt.Rows.Count > 0)
        {
            ggdv_pdi.DataSource = dt;
            ggdv_pdi.DataBind();
            ggdv_pdi.Visible = true;
        }
    }
    protected void ggdv_pdi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        muestra_pestaña(3);
        ggdv_pdi.PageIndex = e.NewPageIndex;
        CargarGridview();
    }
    #endregion

    #region Tab4
    //******************************************************//
    //**<!-- Tab 4 Datos Plan de Intervencion  FUO -->******//
    //******************************************************//

    //Si el niño fue seleccionado:
    public void refillTab4()
    {
        if (tipoPlan == "I")
        {
            getPersonaRelacionada();
            carga_persona_relacionada();
        }
    }


    private void getPersonaRelacionada()
    {
        pintervencion pcoll = new pintervencion();
        DataView dv1 = new DataView(pcoll.GetPersonaRelacionadaNinos(icodie));
        ddl_pplr.Items.Clear();
        ddl_pplr.DataSource = dv1;
        ddl_pplr.DataTextField = "nombres";
        ddl_pplr.DataValueField = "CodPersonaRelacionada";
        dv1.Sort = "nombres";
        ddl_pplr.DataBind();


    }
    private void carga_persona_relacionada()
    {
        pintervencion pin = new pintervencion();
        DataTable dt = pin.GetTrabajaEgreso(codplaninterv, icodie);

        if (dt.Rows.Count > 0)
        {
            grdv_prelac.DataSource = dt;
            grdv_prelac.DataBind();
            grdv_prelac.Visible = true;
        }

    }
    protected void ddl_pplr_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(4);
        pintervencion pcoll = new pintervencion();
        DataView dv1 = new DataView(pcoll.GetPersonaRelacionadaNinos(icodie));

        if (dv1.Count > 0)
        {
            dv1.RowFilter = "nombres = '" + ddl_pplr.SelectedItem.Text + "'";
            grdv_pplr.DataSource = dv1;
            grdv_pplr.DataBind();
            grdv_pplr.Visible = true;

        }
    }
    protected void lbtn_addpplr_Click(object sender, EventArgs e)
    {
        muestra_pestaña(4);
        if (ddl_pplr.SelectedValue != "0")
        {
            //lbl001.Visible = false;
            int check = 0;
            for (int i = 0; i < grdv_prelac.Rows.Count; i++)
            {
                if (grdv_prelac.Rows[i].Cells[0].Text == grdv_pplr.Rows[0].Cells[0].Text &&
                    grdv_prelac.Rows[i].Cells[1].Text == grdv_pplr.Rows[0].Cells[1].Text)
                {
                    check = 1;
                }
            }

            if (check == 0)
            {
                //lbl001.Visible = false;
                pintervencion pin = new pintervencion();
                pin.Insert_Update_TrabajaEgreso(-1, codplaninterv,
                           Convert.ToInt32(ddl_pplr.SelectedValue), DateTime.Now, Convert.ToDateTime("01-01-1900"), "V");
                carga_persona_relacionada();
            }
            else
            {
                alerts.Attributes.Add("style", "");
                lbl005.Text = "Error, La persona que desea agregar ya esta relacionada.";
                lbl005.Attributes.Add("style", "");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('Error, La persona que desea agregar ya esta relacionada.');", true);
                //lbl001.Text = "Error, La persona que desea agregar ya esta relacionada.";
                //lbl001.Visible = true;
            }
            ddl_pplr.BackColor = System.Drawing.Color.White;


        }
        else
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "Error, Debe seleccionar una persona para relacionar.";
            lbl005.Attributes.Add("style", "");
            System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

            ddl_pplr.BackColor = colorCampoObligatorio;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('Error, Debe seleccionar una persona para relacionar.');", true);
            //lbl001.Text = "Error, Debe seleccionar una persona para relacionar.";
            //lbl001.Visible = true;
        }
    }

    protected void grdv_prelac_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(4);
        if (e.CommandName == "Cambiar")
        {
            if (ddl_pplr.SelectedValue != "0")
            {
                //lbl001.Visible = false;
                int check = 0;
                for (int i = 0; i < grdv_prelac.Rows.Count; i++)
                {
                    if (grdv_prelac.Rows[i].Cells[0].Text == grdv_pplr.Rows[0].Cells[0].Text &&
                        grdv_prelac.Rows[i].Cells[1].Text == grdv_pplr.Rows[0].Cells[1].Text)
                    {
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    pintervencion pin = new pintervencion();
                    pin.Insert_Update_TrabajaEgreso(Convert.ToInt32(grdv_prelac.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text),
                        codplaninterv, Convert.ToInt32(ddl_pplr.SelectedValue), DateTime.Now, Convert.ToDateTime("01-01-1900"), "V");
                    carga_persona_relacionada();
                }
                else
                {
                    alerts.Attributes.Add("style", "");
                    lbl005.Text = "Error, la relación que trata de cambiar ya existe.";
                    lbl005.Attributes.Add("style", "");
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "Cambiar", "alert('Error, la relación que trata de cambiar ya existe.');", true);
                    //lbl001.Text = "Error, la relación que trata de cambiar ya existe.";
                    //lbl001.Visible = true;
                }
            }
            else
            {
                alerts.Attributes.Add("style", "");
                lbl005.Text = "Error, debe seleccionar una Persona.";
                lbl005.Attributes.Add("style", "");
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Cambiar", "alert('Error, debe seleccionar una Persona.');", true);
                //lbl001.Text = "Error, debe seleccionar una Persona.";
                //lbl001.Visible = true;
            }
        }
    }

    #endregion

    #region Tab5
    //******************************************************//
    //**<!-- Tab 5 Datos Plan de Intervencion FUO -->*******//
    //******************************************************//

    //Si el niño fue seleccionado:
    public void refillTab5()
    {
        try
        {
            Calendartxtfrt.StartDate = fechainicioplan;
        }
        catch { }
        getGradoCumplimiento();
    }

    private void getGradoCumplimiento()
    {
        pintervencion pin = new pintervencion();
        //        DataView dv = new DataView(pin.GetparGradoCumplimiento());
        DataView dv = new DataView(pin.GetparGradoCumplimiento(Convert.ToInt32(this.CodModelo)));
        ddl_gdc.Items.Clear();
        ddl_gdc.DataSource = dv;
        ddl_gdc.DataTextField = "Descripcion";
        ddl_gdc.DataValueField = "CodGradoCumplimiento";
        dv.Sort = "CodGradoCumplimiento";
        ddl_gdc.DataBind();
    }
    public void update_TerminoPlan()
    {
        int rdolist1 = -1, rdolist2 = -1;
        txt_frt.BackColor = System.Drawing.Color.White;
        ddl_gdc.BackColor = System.Drawing.Color.White;
        if (rb_intervencion_completa_si.Checked == true)
        {
            rdolist1 = 1;
        }
        else
        {
            rdolist1 = 0;
        }
        if (rb_habilitado_egreso_si.Checked == true)
        {
            rdolist2 = 1;
        }
        else
        {
            rdolist2 = 0;
        }

        if (ddl_gdc.SelectedValue == "-1" && txt_frt.Text == "Seleccione Fecha" && rdolist1 == -1 && rdolist2 == -1)
        {
            grabar_TerminoPlan();
            //  Response.Write("<script>window.parent.LimpiarPlan();</script>");
        }
        else if (ddl_gdc.SelectedValue != "-1" && txt_frt.Text != "Seleccione Fecha")
        {
            grabar_TerminoPlan();
            // Response.Write("<script>window.parent.LimpiarPlan();</script>");
        }
        else
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "Para cerrar un plan debe ingresar Grado de Cumplimiento y Fecha de Término. El plan no ha sido grabado.";
            lbl005.Attributes.Add("style", "");
            //gfontbrevis
            System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
            txt_frt.BackColor = colorCampoObligatorio;
            ddl_gdc.BackColor = colorCampoObligatorio;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "x", "$('#SeguimientoPII').click();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ToTopError", "var body = $('html, body');body.stop().animate({scrollTop:0}, '500', 'swing');", true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Cerrar", "alert('Para cerrar un plan debe ingresar Grado de Cumplimiento y Fecha de Término. El plan no ha sido grabado.');", true);
            //Label4.Text = "Para cerrar un plan debe ingresar Grado de Cumplimiento y Fecha de Término. <br>El plan no ha sido grabado.";
            //Label4.Visible = true;

        }
    }



    private void grabar_TerminoPlan()
    {
        int rdolist1 = -1, rdolist2 = -1;
        if (rb_intervencion_completa_si.Checked == true)
        {
            rdolist1 = 1;
        }
        else
        {
            rdolist1 = 0;
        }
        if (rb_habilitado_egreso_si.Checked == true)
        {
            rdolist2 = 1;
        }
        else
        {
            rdolist2 = 0;
        }

        pintervencion pin = new pintervencion();

        int IntervencionCompleta = 0;
        if (rdolist1 == 1)
            IntervencionCompleta = 1;
        else if (rdolist1 == 0) //|| rdolist001.SelectedValue == "")
            IntervencionCompleta = 0;
        else
            IntervencionCompleta = -1;


        int HabilitadoEgreso = 0;
        if (rdolist2 == 1)
            HabilitadoEgreso = 1;
        else if (rdolist2 == 0)//|| rdolist002.SelectedValue == "")
            HabilitadoEgreso = 0;
        else
            HabilitadoEgreso = -1;

        string fechaterminoreal = "";
        if (txt_frt.Text == "Seleccione Fecha")
            fechaterminoreal = "01-01-1900";
        else
            fechaterminoreal = txt_frt.Text;

        if (tipoPlan == "G")
        {
            char[] splitter = { ',' };
            string[] codplan = codplanintervencion.Split(splitter);
            for (int i = 0; i < codplan.Length; i++)
            {
                if (codplan[i].Trim() != "")
                {
                    pin.callto_update_planintervencion_terminoplan(Convert.ToInt32(codplan[i]), Convert.ToDateTime(fechaterminoreal),
                    HabilitadoEgreso, IntervencionCompleta, Convert.ToInt32(ddl_gdc.SelectedValue));
                }
            }
        }
        else if (tipoPlan == "I")
        {
            pin.callto_update_planintervencion_terminoplan(codplaninterv, Convert.ToDateTime(fechaterminoreal), HabilitadoEgreso,
            IntervencionCompleta, Convert.ToInt32(ddl_gdc.SelectedValue));
        }


        limpiar();

        alerts2.Attributes.Add("style", "");
        lbl0052.Text = "Se actualizó con éxito.";
        lbl0052.Attributes.Add("style", "");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ToTopSuccess", "var body = $('html, body');body.stop().animate({scrollTop:0}, '500', 'swing');", true);


        //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "alert('Se Actualizo.');", true);

    }

    protected void lnkbtntab5_Click(object sender, EventArgs e)
    {
        muestra_pestaña(5);

        if (ModeloIntervencionConNuevasVariables())
        {
            saveVariablesPII();
        }
        update_TerminoPlan();

        mostrar_collapse(true);



    }

    #endregion

    private void muestra_pestaña(int num_tab)
    {
        //Comprueba en que pestaña se encuentra haciendo postback y la mantiene.
        switch (num_tab)
        {
            case 1:
                tab1.Attributes.Add("class", "tab-pane fade in active");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Add("class", "active");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                break;
            case 2:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade in active");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Add("class", "active");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                break;
            case 3:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade in active");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Add("class", "active");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                break;
            case 4:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade in active");
                tab5.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Add("class", "active");
                li_nav5.Attributes.Remove("class");
                break;
            case 5:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade in active");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Add("class", "active");
                break;
        }
    }

    private void mostrar_collapse(bool valor)
    {
        if (valor)
        {

            collapse_Form.Attributes.Remove("Class");
            collapse_Form.Attributes.Add("Class", "panel-collapse collapse in");

        }
        if (!valor)
        {
            collapse_Form.Attributes.Remove("Class");
            collapse_Form.Attributes.Add("Class", "panel-collapse collapse out");
        }

    }

    protected void guardarVariablesPII_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "d", "$('#rdo_ddlEvaluacionLogro').val($('#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogro').val())", true);

        saveVariablesPII();

        getInformacionResultadoSeguimientoPII(Convert.ToInt32(CodModelo));

        DescripcionesNivelIntervencion.DataBind();
        DescripcionesIntervencionNNA.DataBind();
        DescripcionesTrabajoConFamilia.DataBind();
        DescripcionesEvaluacionDelLogro.DataBind();
        getDescripcionesSintomatologia.DataBind();
        DescripcionesImplementacionMedida.DataBind();
        DescripcionesGestionRedes24Horas.DataBind();
        updateDescripcionesPII.Update();

        //alerts.Attributes.Add("style", "");
        //lbl005.Attributes.Add("style", "");
        alerts2.Attributes.Add("style", "");
        lbl0052.Text = "Seguimiento PII Actualizado";
        lbl0052.Attributes.Add("style", "");

    }

    protected void saveVariablesPII()
    {

        int iCodResultadoSeguimiento = 0,
            CodPlanIntervencion = 0,
            iCodparResultado = 0,
            valor = 0,
            iCodparNiveles = 0,
            idusuarioActualizacion = 0;

        //CodPlanIntervencion = 120323;
        idusuarioActualizacion = Convert.ToInt32(Session["IdUsuario"]);

        foreach (string input in Request.Form.AllKeys)
        {
            try
            {
                if (input.StartsWith("rdo_")) //Radios
                {
                    try
                    {
                        valor = int.Parse(Request.Form[input]);
                    }
                    catch
                    {
                        string[] datoshdn = Request.Form[input].Split(',');
                        valor = Convert.ToInt32(datoshdn[1]);
                    }

                    string[] datos = input.Split('_');

                    if (datos[0] == "rdo")
                    {
                        iCodparResultado = Convert.ToInt32(datos[2]);
                        iCodparNiveles = Convert.ToInt32(datos[3]);

                        iCodResultadoSeguimiento = getResultadoSeguimientoPII(iCodparResultado, codplaninterv);
                    }
                    else if (datos[0] == "hdn")
                    {
                        iCodparResultado = Convert.ToInt32(datos[2]);
                        iCodparNiveles = Convert.ToInt32(datos[3]);

                        iCodResultadoSeguimiento = getResultadoSeguimientoPII(iCodparResultado, codplaninterv);
                    }

                    insertarSeguimiento(iCodResultadoSeguimiento, codplaninterv, iCodparResultado, valor, iCodparNiveles, idusuarioActualizacion);
                }
            }
            catch (Exception)
            {

            }
        }

        esconderRadios();
    }

    protected void esconderRadios()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderRadiosPRM", "$('#div_rdo_PRM_14').css('display', 'none');$('#div_rdo_PRM_19').css('display', 'none');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderRadiosPAS", "$('#div_rdo_PAS_32').css('display', 'none');$('#div_rdo_PAS_36').css('display', 'none');$('#div_rdo_PAS_42').css('display', 'none');$('#div_rdo_PAS_43').css('display', 'none');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderRadiosPAD", "", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderRadiosPPF", "$('#div_rdo_PPF_134').css('display', 'none');$('#div_rdo_PPF_136').css('display', 'none');$('#div_rdo_PPF_137').css('display', 'none');", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "actualizarDatos", "window.actualizarDescripciones();", true);


    }

    protected void insertarSeguimiento(int iCodResultadoSeguimiento, int CodPlanIntervencion, int iCodparResultado, int valor, int iCodparNiveles, int idusuarioActualizacion)
    {

        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("Insert_Update_ResultadoSeguimientoPII", sqlc);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 10000000;

        command.Parameters.Add("@ICodResultadoSeguimiento", SqlDbType.Int).Value = iCodResultadoSeguimiento;
        command.Parameters.Add("@CodPlanintervencion", SqlDbType.Int).Value = CodPlanIntervencion;
        command.Parameters.Add("@ICodparResultado", SqlDbType.Int).Value = iCodparResultado;
        command.Parameters.Add("@Valor", SqlDbType.Int).Value = valor;
        command.Parameters.Add("@ICodparNiveles", SqlDbType.Int).Value = iCodparNiveles;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int).Value = idusuarioActualizacion;

        command.Connection.Open();

        command.ExecuteNonQuery();

        command.Connection.Close();
    }

    public int getResultadoSeguimientoPII(int iCodparResultado, int CodPlanIntervencion)
    {
        int iCodResultadoSeguimiento;

        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("getResultadoSeguimientoPII", sqlc);

        command.CommandTimeout = 100000000;
        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.Add("@ICodparResultado", SqlDbType.Int).Value = iCodparResultado;
        command.Parameters.Add("@CodPlanIntervencion", SqlDbType.Int).Value = CodPlanIntervencion;

        command.Connection.Open();

        iCodResultadoSeguimiento = Convert.ToInt32(command.ExecuteScalar());

        command.Connection.Close();


        return iCodResultadoSeguimiento;
    }
    protected void refrescarDescripciones_Click(object sender, EventArgs e)
    {

    }

    protected void cargaValor()
    {

    }
    protected void prueba_Click(object sender, EventArgs e)
    {
        DescripcionesEvaluacionDelLogro.Items.Clear();
        DescripcionesEvaluacionDelLogro.DataBind();
    }
}