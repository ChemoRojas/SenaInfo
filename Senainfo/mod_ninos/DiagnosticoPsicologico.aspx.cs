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

public partial class mod_ninos_DiagnosticoPsicologico : System.Web.UI.Page
{
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

    #region ViewState
    public int VCod_diagnostico
    {
        get
        {
            if (ViewState["Cod_diagnostico"] == null)
            { ViewState["Cod_diagnostico"] = -1; }
            return Convert.ToInt32(ViewState["Cod_diagnostico"]);
        }
        set { ViewState["Cod_diagnostico"] = value; }
    }
    public DateTime VFecha_diagnostico
    {
        get
        {
            if (ViewState["Fecha_diagnostico"] == null)
            { ViewState["Fecha_diagnostico"] = -1; }
            return Convert.ToDateTime(ViewState["Fecha_diagnostico"]);
        }
        set { ViewState["Fecha_diagnostico"] = value; }
    }
    public int VICodPsicologico
    {
        get
        {
            if (ViewState["VICodPsicologico"] == null)
            { ViewState["VICodPsicologico"] = -1; }
            return Convert.ToInt32(ViewState["VICodPsicologico"]);
        }
        set { ViewState["VICodPsicologico"] = value; }
    }
    
    # endregion




    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial

        RangeValidator1.Validate();

        //mostrar_collapse(true);

        if (!IsPostBack)
        {
            string strCodProyecto = Request.QueryString["codinst"];
            # region Valida Usuraio
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                //Response.Redirect("~/logout.aspx");
                string script = "AbrirURLModalPopUp('../logout.aspx')";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", script, true);
            }
            else
            {
                GetData();
                imb_003c.Visible = false;
                //btnGatilloCancelar.Style.Add("display", "none");//gfontbrevis
                validatescurity();
            }
            #endregion
        }

        # endregion
    }

    private void validatescurity()
    {
        #region Validacion


        //357AB123-05D6-4F6F-93E9-C8007A403079 2.3_MODIFICAR
        if (!window.existetoken("357AB123-05D6-4F6F-93E9-C8007A403079"))
        {
            imb_003c.Visible = false;
            grd001c.Columns[6].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            imb_002c.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            imb_005c.Visible = false;
        }

        #endregion
    }

    # region inserta diagnostico

    protected void grd001c_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        ddown001c.Enabled = true;
        ddown002c.Enabled = true;
        ddl_TipoTransMent.Enabled = true;    
        diagnosticoscoll dcoll = new diagnosticoscoll();
        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);
        string ICodPsicologico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VICodPsicologico = Convert.ToInt32(ICodPsicologico);
        DataTable dt = dcoll.GetDiagnosticoPsicologicoMostrar(VCod_diagnostico);


        cal001c.Text = Convert.ToDateTime(dt.Rows[0][1].ToString()).ToShortDateString();

        parcoll par = new parcoll();

        try
        {
            DataView dv26 = new DataView(par.GetparTipoDiagnosticosPsicologico());
            ddl_TipoDiag.Items.Clear();
            ddl_TipoDiag.DataSource = dv26;
            ddl_TipoDiag.DataTextField = "Descripcion";
            ddl_TipoDiag.DataValueField = "CodTipoDiagnosticoPsi";
            dv26.Sort = "Descripcion";
            ddl_TipoDiag.DataBind();

            try
            {
                ddl_TipoDiag.Items.FindByValue(ddl_TipoDiag.SelectedValue).Selected = false;
                ddl_TipoDiag.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;
            }
            catch
            {
                ddl_TipoDiag.SelectedIndex = 0;
            }


            try
            {
                DataView dv1 = new DataView(par.GetparInstrumentosDiagnosticosPsicologico(Convert.ToInt32(ddl_TipoDiag.SelectedValue)));
                ddown001c.DataSource = dv1;
                ddown001c.DataTextField = "Descripcion";
                ddown001c.DataValueField = "CodInstrumentoDiagnostico";
                dv1.Sort = "Descripcion";
                ddown001c.DataBind();

                ddown001c.Items.FindByValue(ddown001c.SelectedValue).Selected = false;
                ddown001c.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;
            }
            catch(Exception ex)
            {
                ddown001c.Items.Clear();
                ddown001c.Enabled = false;
            }

            try
            {
                DataView dv0 = new DataView(par.GetparMedicionesDiagnosticasPsicologico(Convert.ToInt32(ddown001c.SelectedValue)));
                ddown002c.DataSource = dv0;
                ddown002c.DataTextField = "Descripcion";
                ddown002c.DataValueField = "CodMedicionesDiagnosticas";
                dv0.Sort = "Descripcion";
                ddown002c.DataBind();

                ddown002c.Items.FindByValue(ddown002c.SelectedValue).Selected = false;
                ddown002c.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;
            }
            catch (Exception ex1)
            {
                ddown002c.Items.Clear();
                ddown002c.Enabled = false;
            }


            //DataView dv0 = new DataView(par.GetparInstrumentosDiagnosticosPsicologico(Convert.ToInt32(ddl_TipoDiag.SelectedValue)));
            //ddown001c.Items.Clear();
            //ddown001c.DataSource = dv0;
            //ddown001c.DataTextField = "Descripcion";
            //ddown001c.DataValueField = "CodInstrumentoDiagnostico";
            //dv0.Sort = "Descripcion";
            //ddown001c.DataBind();



            try
            {
                DataView dv2 = new DataView(par.GetparTipoDeTranstornoMentalPsicologico(Convert.ToInt32(ddown002c.SelectedValue)));
                ddl_TipoTransMent.DataSource = dv2;
                ddl_TipoTransMent.DataTextField = "Descripcion";
                ddl_TipoTransMent.DataValueField = "CodTrastornoMental";
                dv2.Sort = "Descripcion";
                ddl_TipoTransMent.DataBind();

                ddl_TipoTransMent.Items.FindByValue(ddl_TipoTransMent.SelectedValue).Selected = false;
                ddl_TipoTransMent.Items.FindByValue(dt.Rows[0][6].ToString()).Selected = true;
            }
            catch(Exception ex)
            {
                ddl_TipoTransMent.Items.Clear();
                ddl_TipoTransMent.Enabled = false;
            }

        }
        catch(Exception ex)
        {
        }

        txt001c.Text = dt.Rows[0][5].ToString();

        ddown003c.Items.FindByValue(ddown003c.SelectedValue).Selected = false;
        try
        {
            ddown003c.Items.FindByValue(dt.Rows[0][7].ToString()).Selected = true;
        }
        catch
        {
            ddown003c.Items.FindByValue("-1").Selected = true;
        }


        txt002_wtc.Text = Convert.ToString(dt.Rows[0][8]);

        imb_002c.Visible = false;
        imb_003c.Visible = true;
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    }
    protected void imb_002c_Click(object sender, EventArgs e)
    {      
        int TipoDiag = 0, TipoTrans = 0, ddo001 = 0, ddo002 = 0, ddo003 = 0;
        DateTime fecha;
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();
        bool sw = false, bs = validate();
        if (bs == false)
        {
            for (int i = 0; i < grd001c.Rows.Count; i++)
            {
                if (cal001c.Text == "")
                {
                    fecha = Convert.ToDateTime("01-01-1950");
                }
                else
                {
                    fecha = Convert.ToDateTime(cal001c.Text);
                }

                if (Convert.ToDateTime(Server.HtmlDecode((grd001c.Rows[i].Cells[2]).Text.ToUpper().Trim())).ToShortDateString() == Convert.ToString(fecha.ToShortDateString()) &&
                    Server.HtmlDecode(((grd001c.Rows[i].Cells[4]).Text.ToUpper().Trim())) == Server.HtmlDecode(ddown002c.SelectedItem.Text.ToUpper().Trim()) &&
                    Server.HtmlDecode((grd001c.Rows[i].Cells[3]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown001c.SelectedItem.Text.ToUpper().Trim()))
                {
                    lbl001c.Text = "El menor ya posee diagnostico, Intentelo nuevamente";
                    sw = true;
                    //gfontbrevis
                    btnGatillo.Attributes.Add("disabled", "disabled");
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
                }
            }
        }        
        if (validatePsicologico() == true && sw == false && bs == false)
        {
            if (txt002_wtc.Text.Trim() == "")
            {
                txt002_wtc.Text = "SIN OBSERVACION";
            }
            if (txt001c.Text.Trim() == "")
            {
                txt001c.Text = Convert.ToString(0);
            }
            if (ddl_TipoDiag.SelectedValue.Equals("") || ddl_TipoDiag.SelectedValue.Equals("Seleccionar"))
            {
                TipoDiag = 0;
            }
            else
            {
                TipoDiag = Convert.ToInt32(ddl_TipoDiag.SelectedValue);
            }
            if (ddl_TipoTransMent.SelectedValue.Equals("") || ddl_TipoTransMent.SelectedValue.Equals("Seleccionar"))
            {
                TipoTrans = 0;
            }
            else
            {
                TipoTrans = Convert.ToInt32(ddl_TipoTransMent.SelectedValue);
            }
            if (ddown001c.SelectedValue.Equals("") || ddl_TipoTransMent.SelectedValue.Equals("Seleccionar"))
            {
                ddo001 = 0;
            }
            else
            {
                ddo001 = Convert.ToInt32(ddown001c.SelectedValue);
            }
            if (ddown002c.SelectedValue.Equals("") || ddl_TipoTransMent.SelectedValue.Equals("Seleccionar"))
            {
                ddo002 = 0;
            }
            else
            {
                ddo002 = Convert.ToInt32(ddown002c.SelectedValue);
            }
            if (ddown003c.SelectedValue.Equals("") || ddl_TipoTransMent.SelectedValue.Equals("Seleccionar"))
            {
                ddo003 = 0;
            }
            else
            {
                ddo003 = Convert.ToInt32(ddown003c.SelectedValue);
            }

            int inden = ncoll.Insert_DiagnosticoGeneral(4, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(cal001c.Text));


             dcoll.Insert_DiagnosticosPsicologico(inden,
                    Convert.ToInt32(ddo001),
                    Convert.ToInt32(ddo002),
                    Convert.ToDateTime(cal001c.Text),
                    Convert.ToInt32(ddo003),
                    SSninoDiag.CodInst,
                    1,
                    Convert.ToInt32(txt001c.Text),
                    Convert.ToString(txt002_wtc.Text).ToUpper(),
                    DateTime.Now, Convert.ToInt32(Session["IdUsuario"]),
                    Convert.ToInt32(TipoDiag),
                    Convert.ToInt32(TipoTrans));

            lbl001c.Text = "";

            clean_form();
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            mostrar_collapse(false);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowAgregar", "$('#btnGatillo').show();$('#btnGatilloCancelar').hide();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);

        }

        else
        {

            //utab4.Tabs[3].Style.ForeColor = System.Drawing.Color.Red;
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('#collapse_Form').animate({ scrollTop: 0 }, 500);", true);

        }

        
        DataTable dt3 = dcoll.GetDiagnosticoPsicologico(SSninoDiag.ICodIE);
        DataView dv3 = new DataView(dt3);
        dv3.Sort = "FechaDiagnostico DESC";
        grd001c.DataSource = dv3;
        grd001c.DataBind();
        grd001c.Visible = true;


        //cal001c.MinDate = SSninoDiag.fchingdesde;
        //cal001c.MaxDate = DateTime.Now;
        CalendarExtende379.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende379.EndDate = DateTime.Now;

        if (dv3.Count == 0 && bs == false)
        {
            //lbl001c.Text = "Este Niño(a) no Posee Diagnostico Psicologico";
            lbl001cinfo.Visible = true; //gfontbrevis
        }

        //grd001c.Focus();

    }

    # endregion

    protected bool validate()
    {
        bool sw = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (ddl_TipoDiag.SelectedValue.Equals("") || ddl_TipoDiag.SelectedValue.Equals("Seleccionar") || ddl_TipoDiag.SelectedValue.Equals("0"))
        {
            sw = true;
            //lbl001c.Text = "Seleccione un Tipo Diagnostico";
            ddl_TipoDiag.BackColor = colorCampoObligatorio;
        }
        else
        {
            ddl_TipoDiag.BackColor = System.Drawing.Color.White;

        }
        if (ddown001c.SelectedValue.Equals("") || ddown001c.SelectedValue.Equals("Seleccionar") || ddown001c.SelectedValue.Equals("0"))
        {
            sw = true;
            //lbl001c.Text = "Seleccione un Instrumento Diagnostico";
            ddown001c.BackColor = colorCampoObligatorio;
        }
        else
        {
            ddown001c.BackColor = System.Drawing.Color.White;

        }

        if (ddown002c.SelectedValue.Equals("")  || ddown002c.SelectedValue.Equals("Seleccionar") )
        {
            sw = true;
            //lbl001c.Text = "Seleccione una Medición Diagnóstica";
            ddown002c.BackColor = colorCampoObligatorio;
        }
        else
        {
            ddown002c.BackColor = System.Drawing.Color.White;

        }
        if (ddown003c.SelectedValue.Equals("")  || ddown003c.SelectedValue.Equals("Seleccionar")  || ddown003c.SelectedValue.Equals("0") )
        {
            sw = true;
            //lbl001c.Text = "Seleccione un Tecnico";
            ddown003c.BackColor = colorCampoObligatorio;
        }
        else
        {
            ddown003c.BackColor = System.Drawing.Color.White;

        }
        if (ddown001c.SelectedItem != null)
        {
            if (ddown001c.SelectedItem.Text.Equals("TRASTORNOS MENTALES CIE 10")  && ddown001c.SelectedValue.Equals(""))
            {
                sw = true;
                //lbl001c.Text = "Seleccione un Tipo Transtorno Mental";
                ddown001c.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown001c.BackColor = System.Drawing.Color.White;

            }
        }

        return sw;
    }

    # region ActualizaDiagnostico

   

    protected void imb_003c_Click(object sender, EventArgs e)
    {
        int transmen = 0;
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();
        bool sw = false, bs = validate();        
        if (validatePsicologico() == true && sw == false && bs == false)
        {
            if (txt002_wtc.Text.Trim() == "")
            {
                txt002_wtc.Text = "SIN OBSERVACION";
            }

            if (txt001c.Text.Trim() == "")
            {

                txt001c.Text = Convert.ToString(0);
            }
            if (ddl_TipoTransMent.SelectedValue.Equals("") || ddl_TipoTransMent.SelectedValue.Equals("Seleccionar"))
            {
                transmen = 0;
            }
            else
            {
                transmen = Convert.ToInt32(ddl_TipoTransMent.SelectedValue);
            }
            dcoll.Update_DiagnosticosPsicologico(VICodPsicologico, VCod_diagnostico,
            Convert.ToInt32(ddown001c.SelectedValue), Convert.ToInt32(ddown002c.SelectedValue),
            Convert.ToDateTime(cal001c.Text), Convert.ToInt32(ddown003c.SelectedValue),SSninoDiag.CodInst, 1,
            Convert.ToInt32(txt001c.Text), Convert.ToString(txt002_wtc.Text).ToUpper(), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddl_TipoDiag.SelectedValue),
            transmen);
            clean_form();
            lbl001c.Text = "";
            lbl001cinfo.Visible = false;//gfontbrevis
            imb_002c.Visible = true;
            imb_003c.Visible = false;
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            mostrar_collapse(false);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);  

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('#collapse_Form').animate({ scrollTop: 0 }, 500);", true);
            mostrar_collapse(true);
            btnGatillo.Attributes.Add("disabled", "disabled");
        }


        DataTable dt3 = dcoll.GetDiagnosticoPsicologico(SSninoDiag.ICodIE);
        DataView dv3 = new DataView(dt3);
        dv3.Sort = "FechaDiagnostico DESC";
        grd001c.DataSource = dv3;
        grd001c.DataBind();
        grd001c.Visible = true;

        //cal001c.MinDate = SSninoDiag.fchingdesde;
        //cal001c.MaxDate = DateTime.Now;
        CalendarExtende379.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende379.EndDate = DateTime.Now;

        if (dv3.Count == 0 && bs == false)
        {
            //lbl001c.Text = "Este Niño(a) no Posee Diagnostico Psicologico";
            lbl001cinfo.Visible = true;//gfontbrevis
        }
        //grd001c.Focus();
        


    }
   

    # endregion

    # region Historico de Diagnosticos

    protected void imb_005c_Click(object sender,EventArgs e)
    {
        //window.open(this.Page, "ninos_HistoricoDiagnosticoPsicologico.aspx", 770, 420);

    }

    # endregion

    #region volver
    protected void imb_006c_Click(object sender, EventArgs e)
    {

        //clean_form();

        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");
    }
    # endregion

    #region validaciones

    protected void cal001c_ValueChanged(object sender, EventArgs e)
    {
        //cal001c.MinDate = DateTime.Now;
        CalendarExtende379.StartDate = DateTime.Now;
        grd001c.Focus();
    }
    
    protected void ddl_TipoDiag_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddown002c.Items.Clear();
        ddown002c.Enabled = false;
        ddl_TipoTransMent.Items.Clear();
        ddl_TipoTransMent.Enabled = false;
        if (ddl_TipoDiag.SelectedValue.Equals("Seleccionar"))
        {
            ddown001c.Items.Clear();
            ddown001c.Enabled = false;
        }
        else
        {
            ddown001c.Enabled = true;
            ddown001c.Items.Clear();
            ddown001c.Items.Add("Seleccionar");
            parcoll par = new parcoll();
            DataView dv0 = new DataView(par.GetparInstrumentosDiagnosticosPsicologico(Convert.ToInt32(ddl_TipoDiag.SelectedValue)));            
            ddown001c.DataSource = dv0;
            ddown001c.DataTextField = "Descripcion";
            ddown001c.DataValueField = "CodInstrumentoDiagnostico";
            dv0.Sort = "Descripcion";
            ddown001c.DataBind();
            //grd001c.Focus();
            
        }
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('#collapse_Form').animate({ scrollTop: 0 }, 500);", true);
    }

    protected void ddown001c_SelectedIndexChanged(object sender, EventArgs e)
    {        
        ddl_TipoTransMent.Items.Clear();
        ddl_TipoTransMent.Enabled = false;
        if (ddown001c.SelectedValue.Equals("Seleccionar"))
        {
            ddown002c.Items.Clear();
            ddown002c.Enabled = false;
        }
        else
        {
            ddown002c.Enabled = true;
            ddown002c.Items.Clear();
            ddown002c.Items.Add("Seleccionar");
            parcoll par = new parcoll();
            DataView dv1 = new DataView(par.GetparMedicionesDiagnosticasPsicologico(Convert.ToInt32(ddown001c.SelectedValue)));
            ddown002c.DataSource = dv1;
            ddown002c.DataTextField = "Descripcion";
            ddown002c.DataValueField = "CodMedicionesDiagnosticas";
            dv1.Sort = "Descripcion";
            ddown002c.DataBind();
            //grd001c.Focus();
        }
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('#collapse_Form').animate({ scrollTop: 0 }, 500);", true);
    }


    protected void ddown002c_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_TipoTransMent.Enabled = false;
        if (ddown001c.SelectedItem.Text.Equals("TRASTORNOS MENTALES CIE 10"))
        {
            ddl_TipoTransMent.Enabled = true;
            ddl_TipoTransMent.Items.Clear();
            ddl_TipoTransMent.Items.Add("Seleccionar");
            parcoll par = new parcoll();
            DataView dv2 = new DataView(par.GetparTipoDeTranstornoMentalPsicologico(Convert.ToInt32(ddown002c.SelectedValue)));
            ddl_TipoTransMent.DataSource = dv2;
            ddl_TipoTransMent.DataTextField = "Descripcion";
            ddl_TipoTransMent.DataValueField = "CodTrastornoMental";
            dv2.Sort = "Descripcion";
            ddl_TipoTransMent.DataBind();
            //grd001c.Focus();
        }
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('#collapse_Form').animate({ scrollTop: 0 }, 500);", true);
    }

  
    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();


        //cal001c.MinDate = SSninoDiag.fchingdesde;
        //cal001c.MaxDate = DateTime.Now;
        CalendarExtende379.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende379.EndDate = DateTime.Now;

        DataTable dt3 = dcoll.GetDiagnosticoPsicologico(SSninoDiag.ICodIE);
        DataView dv3 = new DataView(dt3);
        dv3.Sort = "FechaDiagnostico DESC";
        grd001c.DataSource = dv3;
        grd001c.DataBind();
        grd001c.Visible = true;
        if (dv3.Count == 0)
        {
            //lbl001c.Text = "Este Niño(a) no Posee Diagnostico Psicologico";
            lbl001cinfo.Visible = true;//gfontbrevis
        }
        else
        {
            //lbl001c.Text = "";
            lbl001cinfo.Visible = false;//gfontbrevis
        }
                
        DataView dv25 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
        ddown003c.Items.Clear();
        ddown003c.DataSource = dv25;
        ddown003c.DataTextField = "NombreCompleto";
        ddown003c.DataValueField = "ICodTrabajador";
        dv25.Sort = "NombreCompleto";
        ddown003c.DataBind();

        ddl_TipoTransMent.Items.Clear();
        ddl_TipoTransMent.Enabled = false;

        ddown001c.Items.Clear();
        ddown001c.Enabled = false;

        ddown002c.Items.Clear();
        ddown002c.Enabled = false;


        //Fabian 23-06-2014
        ddl_TipoDiag.Items.Clear();
        ddl_TipoDiag.Items.Add("Seleccionar");
        DataView dv26 = new DataView(par.GetparTipoDiagnosticosPsicologico());        
        ddl_TipoDiag.DataSource = dv26;
        ddl_TipoDiag.DataTextField = "Descripcion";
        ddl_TipoDiag.DataValueField = "CodTipoDiagnosticoPsi";
        dv26.Sort = "Descripcion";
        ddl_TipoDiag.DataBind();

        //Modificado
        /*
        DataView dv23 = new DataView(par.GetparInstrumentosDiagnosticos());
        ddown001c.Items.Clear();
        ddown001c.DataSource = dv23;
        ddown001c.DataTextField = "Descripcion";
        ddown001c.DataValueField = "CodInstrumentoDiagnostico";
        dv23.Sort = "Descripcion";
        ddown001c.DataBind();
         */

    }

    #endregion

    # region Limpia Formulario

    protected void imb_004c_Click(object sender, EventArgs e)
    {
        clean_form();
        imb_003c.Visible = false;
        imb_002c.Visible = true;
        //grd001c.Focus();
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('#collapse_Form').animate({ scrollTop: 0 }, 500);", true);
    }
    
    private void clean_form()
    {        
        ddown003c.SelectedValue = "0";               
        txt002_wtc.Text = "";
        txt001c.Text = "";      
        cal001c.Text = "";
        ddl_TipoDiag.Items.Clear();
        ddl_TipoDiag.Enabled = true;
        ddl_TipoDiag.Items.Clear();
        ddl_TipoDiag.Items.Insert(0, new ListItem("Seleccionar", "0"));
        parcoll par = new parcoll();
        DataView dv26 = new DataView(par.GetparTipoDiagnosticosPsicologico());
        ddl_TipoDiag.DataSource = dv26;
        ddl_TipoDiag.DataTextField = "Descripcion";
        ddl_TipoDiag.DataValueField = "CodTipoDiagnosticoPsi";
        dv26.Sort = "Descripcion";
        ddl_TipoDiag.DataBind();
        ddl_TipoTransMent.Items.Clear();
        ddl_TipoTransMent.Enabled = false;
        ddown001c.Items.Clear(); 
        ddown001c.Enabled = false;
        ddown002c.Items.Clear();        
        ddown002c.Enabled = false;
    }

    # endregion

    #region Funciones del Formulario

    private bool validatePsicologico()
    {

        bool n = true;


        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (cal001c.Text == "")
        {

            cal001c.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001c.BackColor = System.Drawing.Color.White;

        }
        //if (ddown001c.SelectedValue.Equals(""))
        //{
        //    ddown001c.BackColor = colorCampoObligatorio;
        //    n = false;
        //}
        //else
        //{
        //    ddown001c.BackColor = System.Drawing.Color.White;

        //}


        //if (ddown002c.SelectedValue.Equals(""))
        //{
        //    ddown002c.BackColor = colorCampoObligatorio;
        //    n = false;
        //}
        //else
        //{
        //    ddown002c.BackColor = System.Drawing.Color.White;

        //}


        if (ddown003c.SelectedValue.Equals(""))
        {
            ddown003c.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003c.BackColor = System.Drawing.Color.White;

        }

        #region FabianUrrutia       

        if (ddl_TipoDiag.SelectedValue.Equals(""))
        {
            ddown003c.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003c.BackColor = System.Drawing.Color.White;

        }
#endregion


        ninocoll ncoll = new ninocoll();
        int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(SSninoDiag.CodProyecto);

        if (CodModeloIntervencion == 83 && cierre_mes()==1)    // PAD - PROGRAMA DE PROTECCIÓN AMBULATORIA PARA NIÑOS(AS) Y ADOLESC. CON DISCAPACIDAD GRAVE O PROFUNDA 
        {
            lbl001c.Text = "No puede agregar diagnosticos en meses cerrados";
            n = false;
        }

        return n;

    }
    private int cierre_mes()
    {
        diagnosticoscoll dgcol = new diagnosticoscoll();
        int AnoMes = Convert.ToDateTime(cal001c.Text).Year * 100 + Convert.ToDateTime(cal001c.Text).Month;
        int MesCerrado = dgcol.callto_consulta_cierremes(SSninoDiag.CodProyecto, AnoMes);
        return MesCerrado;
    }



    #endregion

    protected void rv_año_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("yyyy");
        ((RangeValidator)sender).MinimumValue = "1900";

    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

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
}
