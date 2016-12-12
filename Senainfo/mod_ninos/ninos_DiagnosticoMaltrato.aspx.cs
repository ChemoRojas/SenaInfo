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

public partial class mod_instituciones_ninos_DiagnosticoMaltrato : System.Web.UI.Page
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
    
     public int VCodMaltrato
    {
        get
        {
            if (ViewState["VCodMaltrato"] == null)
            { ViewState["VCodMaltrato"] = -1; }
            return Convert.ToInt32(ViewState["VCodMaltrato"]);
        }
        set { ViewState["VCodMaltrato"] = value; }
    }

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
    # endregion




    protected void Page_Load(object sender, EventArgs e)
    {
        
        # region CargaInicial
        mostrar_collapse(true);
        RangeValidator903.Validate();

        if (!IsPostBack)
        {
            CalendarExtender328.StartDate = SSninoDiag.fchingdesde;
            CalendarExtender328.EndDate = DateTime.Now;
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
                BtnModificarDiagnostico.Visible = false;
                //btnGatilloCancelar.Style.Add("display", "none");//gfontbrevis
                mostrar_collapse(false);
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
            BtnModificarDiagnostico.Visible = false;
            grd001a.Columns[7].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            BtnAgregarDiagnostico.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            BtnVerHistorico.Visible = false;
        }

        #endregion
    }
    # region inserta diagnostico


    protected void imb_001a_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

        
        
        DateTime fecha;


        bool sw = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

          try{
        for (int i = 0; i < grd001a.Rows.Count; i++)
        {
            if (CalDiagnostico.Text == "")
            {
              
                fecha = Convert.ToDateTime("01-01-1950");

            }
            else
            {

                fecha = Convert.ToDateTime(CalDiagnostico.Text);
            }

            if ((Convert.ToDateTime((grd001a.Rows[i].Cells[6]).Text.Trim())).ToShortDateString() == fecha.ToShortDateString())
            {
                lbl002a.Text = "Para realizar este ingreso, debe cambiar la fecha de Diagnóstico";
                sw = true;
                mostrar_collapse(true);
                
            }


        }
          }
          catch (Exception)
          {
              CalDiagnostico.BackColor = colorCampoObligatorio;
              CalDiagnostico.Focus();
          }


        if (rdo002a.Checked == false && sw == false)
        {
          if (validateMaltrato() == true)
          {
            int inden = ncoll.Insert_DiagnosticoGeneral(2, SSninoDiag.CodNino,
            SSninoDiag.ICodIE, Convert.ToDateTime(CalDiagnostico.Text));

            dcoll.Insert_DiagnosticosMaltrato(inden, Convert.ToDateTime(CalDiagnostico.Text), Diag_PresentaMaltrato(),
            Convert.ToInt32(ddown002a.SelectedValue),
            Diag_ConoceMaltratador(), Convert.ToInt32(ddown003a.SelectedValue), Diag_ViveConAgresor(),
            Diag_ExisteQuerellaSename(), Convert.ToInt32(ddown004a.SelectedValue), SSninoDiag.CodInst,
            Convert.ToInt32(ddown004a.SelectedValue), Convert.ToString(txt_003a.Text).ToUpper(), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

            lbl002a.Text = "";
            lbl001a.Visible = false;//gfontbrevis

            clean_form();
              //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            mostrar_collapse(false);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Showcancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            grd001a.Focus();
          }
          else
          {
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
          }
        }
        else
        {

          if (validateMaltrato2() == true && sw == false)
          {
            int inden = ncoll.Insert_DiagnosticoGeneral(2, SSninoDiag.CodNino,
                    SSninoDiag.ICodIE, DateTime.Now);

            dcoll.Insert_DiagnosticosMaltrato(inden, Convert.ToDateTime(CalDiagnostico.Text), false,
            Convert.ToInt32(ddown002a.SelectedValue),
            false, 0, false,
            false, Convert.ToInt32(ddown004a.SelectedValue), SSninoDiag.CodInst,
            -1, Convert.ToString(txt_003a.Text).ToUpper(), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));
            clean_form();
            lbl002a.Text = "";
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Showcancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            grd001a.Focus();
          }
          else
          {
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
          }
        }


        DataTable dt1 = dcoll.GetDiagnosticoMaltrato(SSninoDiag.ICodIE);
        DataView dv1 = new DataView(dt1);
        dv1.Sort = "FechaDiagnostico DESC";
        grd001a.DataSource = dv1;
        grd001a.DataBind();
        grd001a.Visible = true;
        //utab4.Visible = true;
        if (dv1.Count == 0)
        {
            lbl001a.Visible = true;//gfontbrevis
        }

        //grd001a.Focus();
    }


    # endregion

    # region ActualizaDiagnostico

    // selecciona niño de la grilla de diagnosticos

    protected void grd001a_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();

        string codMaltrato = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VCodMaltrato = Convert.ToInt32(codMaltrato);


        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);



        DataTable dt1 = dcoll.GetDiagnosticoMaltratoMostrar(VCodMaltrato);




        CalDiagnostico.Text = Convert.ToDateTime(dt1.Rows[0][0].ToString()).ToShortDateString();
        

        if (Convert.ToBoolean(dt1.Rows[0][1]) == true)
        {
            rdo001a.Checked = true;
        }
        else if (Convert.ToBoolean(dt1.Rows[0][1]) == false)
        {
            rdo002a.Checked = true;
        }
        else
        {
            rdo002a.Checked = false;
        }



        try
        {
            ddown001a.Items.FindByValue(ddown001a.SelectedValue).Selected = false;
            ddown001a.Items.FindByValue(dt1.Rows[0][2].ToString()).Selected = true;
        }
        catch
        {
            ddown001a.SelectedIndex = 0;
        }

        ddown002a.Items.Clear();
        DataView dv17 = new DataView(par.GetparMaltrato(Convert.ToInt32(dt1.Rows[0][2].ToString())));
        ddown002a.DataSource = dv17;
        ddown002a.DataTextField = "Descripcion";
        ddown002a.DataValueField = "CodMaltrato";
        dv17.Sort = "Descripcion";
        ddown002a.DataBind();
        try
        {
            ddown002a.Items.FindByValue(ddown002a.SelectedValue).Selected = false;
            ddown002a.Items.FindByValue(dt1.Rows[0][3].ToString()).Selected = true;
        }
        catch { }

        if (Convert.ToBoolean(dt1.Rows[0][4]) == true)
        {
            rdo003a.Checked = true;
        }
        else if (Convert.ToBoolean(dt1.Rows[0][4]) == false)
        {
            rdo004a.Checked = true;
        }
        else
        {
            rdo004a.Checked = false;
        }

        ddown003a.Items.FindByValue(ddown003a.SelectedValue).Selected = false;
        try
        {
            ddown003a.Items.FindByValue(dt1.Rows[0][5].ToString()).Selected = true;
        }
        catch { }
        ddown004a.Items.FindByValue(ddown004a.SelectedValue).Selected = false;


        try
        {
            ddown004a.Items.FindByValue(dt1.Rows[0][8].ToString()).Selected = true;
        }
        catch
        {
            ddown004a.Items.FindByValue("-1").Selected = true;
        }


        if (Convert.ToBoolean(dt1.Rows[0][6]) == true)
        {
            chk001a.Checked = true;
        }

        if (Convert.ToBoolean(dt1.Rows[0][7]) == true)
        {
            chk002a.Checked = true;
        }

        txt_003a.Text = Convert.ToString(dt1.Rows[0][9]);

        BtnAgregarDiagnostico.Visible = false;
        BtnModificarDiagnostico.Visible = true;

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "$('#collapse_diagMaltrato').click();", true);
        //mostrar_collapse(false);
        //lblAvisoCargaDatos.Visible = true;

        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);


    }


    // inserta diagnostico en la tabla
    protected void imb_002a_Click(object sender, EventArgs e)
    {


        bool sw = false;

        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();




        if (rdo002a.Checked == false && sw == false)
        {
            if (validateMaltrato() == true)
            {


                ncoll.Update_DiagnosticosMaltrato(VCodMaltrato, VCod_diagnostico,
                Convert.ToDateTime(CalDiagnostico.Text), Diag_PresentaMaltrato(),
                Convert.ToInt32(ddown002a.SelectedValue),
                Diag_ConoceMaltratador(), Convert.ToInt32(ddown003a.SelectedValue), Diag_ViveConAgresor(),
                Diag_ExisteQuerellaSename(), Convert.ToInt32(ddown004a.SelectedValue), SSninoDiag.CodInst,
                Convert.ToInt32(ddown004a.SelectedValue), Convert.ToString(txt_003a.Text).ToUpper(), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

                clean_form();
                lbl002a.Text = "";
                lbl001a.Visible=false;//gfontbrevis
                //gfontbrevis
                BtnAgregarDiagnostico.Visible = true;
                BtnModificarDiagnostico.Visible = false;
                btnGatillo.Attributes.Remove("disabled");
                mostrar_collapse(false);
            }
        }
        else
        {

            if (validateMaltrato2() == true)
            {


                dcoll.Update_DiagnosticosMaltrato(VCodMaltrato, VCod_diagnostico, Convert.ToDateTime(CalDiagnostico.Text), false,
                -1,
                false, 0, false,
                false, Convert.ToInt32(ddown004a.SelectedValue), SSninoDiag.CodInst,
                -1, Convert.ToString(txt_003a.Text).ToUpper(), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

                clean_form();
                lbl002a.Text = "";
                lbl001a.Visible = false;//gfontbrevis
                //gfontbrevis
                BtnAgregarDiagnostico.Visible = true;
                BtnModificarDiagnostico.Visible = false;
                btnGatillo.Attributes.Remove("disabled");
                mostrar_collapse(false);


            }
        }


        DataTable dt = dcoll.GetDiagnosticoMaltrato(SSninoDiag.ICodIE);

        DataView dv = new DataView(dt);
        dv.Sort = "FechaDiagnostico DESC";
        grd001a.DataSource = dv;
        grd001a.DataBind();
        grd001a.Visible = true;
        //utab4.Visible = true;
        if (dv.Count == 0)
        {
            lbl001a.Visible = true;//gfontbrevis
        }
        else
        {
            lbl001a.Visible = false;//gfontbrevis


        }

        //WebImageButton timb_001a = (WebImageButton)utab4.FindControl("imb_001a");
        //WebImageButton timb_002a = (WebImageButton)utab4.FindControl("imb_002a");
        //gfontbrevis        
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }
    # endregion

    # region Historico de Diagnosticos

    protected void imb_004a_Click(object sender, EventArgs e)
    {
        //window.open(this.Page, "ninos_HistoricoDiagnosticoMaltrato.aspx", 770, 420);
    }

    # endregion

    #region volver
    
    protected void imb_005a_Click(object sender, EventArgs e)
    {
        //clean_form();
        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");
    }

    # endregion

    #region validaciones
    protected void rdo001a_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        ddown001a.Enabled = true;
        ddown002a.Enabled = true;
        ddown001a.SelectedValue = "0"; 
        ddown002a.SelectedValue = "0";

        rdo003a.Enabled = true;
        rdo004a.Enabled = true;
        rdo003a.Checked = true;
        rdo004a.Checked = false;
        rdo003a_CheckedChanged(sender, e);
        
        chk002a.Enabled = true;
        
    }

    protected void rdo002a_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        
        ddown001a.Enabled = false;
        ddown002a.Enabled = false;
        ddown001a.SelectedValue = "8";      // NO SE TIENEN ANTECEDENTES DE MALTRATO
        ddown001a_SelectedIndexChanged(new object(), new EventArgs());
        ddown002a.SelectedValue = "36";     // NO PRESENTA MALTRATO

        rdo003a.Enabled = false;
        rdo004a.Enabled = false;
        rdo003a.Checked = false;
        rdo004a.Checked = true;
        rdo004a_CheckedChanged(sender, e);

        
        chk002a.Enabled = false;
        chk002a.Checked = false;

    }

    protected void rdo003a_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        ddown003a.Enabled = true;
        chk001a.Enabled = true;

    }
    protected void rdo004a_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);

        ddown003a.Enabled = false;
        ddown003a.SelectedValue = "0";

        chk001a.Checked = false;
        chk001a.Enabled = false;
        
    }

    protected void ddown001a_SelectedIndexChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('');$('#btnGatilloCancelar').show('');", true);

        parcoll par = new parcoll();
        ddown002a.Items.Clear();
        DataView dv17 = new DataView(par.GetparMaltrato(Convert.ToInt32(ddown001a.SelectedValue)));
        ddown002a.DataSource = dv17;
        ddown002a.DataTextField = "Descripcion";
        ddown002a.DataValueField = "CodMaltrato";
        dv17.Sort = "Descripcion";
        ddown002a.DataBind();

        //GridView tgrd001a = (GridView)utab4.FindControl("grd001a");
        //grd001a.Focus();
    }
    

    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        
        //lbl_fechaM.Text = SSninoDiag.fchingdesde.ToShortDateString();



        
        //cal001a.MinDate = SSninoDiag.fchingdesde;
        //cal001a.MaxDate = DateTime.Now;

        
        DataTable dt1 = dcoll.GetDiagnosticoMaltrato(SSninoDiag.ICodIE);
        DataView dv1 = new DataView(dt1);
        dv1.Sort = "FechaDiagnostico DESC";
        grd001a.DataSource = dv1;
        grd001a.DataBind();
        grd001a.Visible = true;
       // utab4.Visible = true;
        if (dv1.Count == 0)
        {
            lbl001a.Visible = true;//gfontbrevis
        }
        else
        {
            lbl001a.Visible = false;//gfontbrevis
        }
        
        //DropDownList  Maltrato
        
        DataView dv16 = new DataView(par.GetparTipoMaltrato());
        ddown001a.Items.Clear();
        ddown001a.DataSource = dv16;
        ddown001a.DataTextField = "Descripcion";
        ddown001a.DataValueField = "TipoMaltrato";
        dv16.Sort = "Descripcion";
        ddown001a.DataBind();


       
        DataView dv18 = new DataView(ncoll.Get_TipoRelacionMaltrato());
        ddown003a.Items.Clear();
        ddown003a.DataSource = dv18;
        ddown003a.DataTextField = "Descripcion";
        ddown003a.DataValueField = "TipoRelacion";
        dv18.Sort = "Descripcion";
        ddown003a.DataBind();
        ddown003a.Items.Insert(0, new ListItem("Seleccionar", "0"));


        //DataView dv18 = new DataView(ncoll.Get_TipoRelacionMaltrato());
        //ddown003a.Items.Clear();
        //ddown003a.DataSource = dv18;
        //ddown003a.DataTextField = "Agresor";
        //ddown003a.DataValueField = "CodPersonaRelacionada";
        //dv18.Sort = "Agresor";
        //ddown003a.DataBind();
        //ddown003a.Items.Insert(0, "Seleccionar");

       
        DataView dv19 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
        ddown004a.Items.Clear();
        ddown004a.DataSource = dv19;
        ddown004a.DataTextField = "NombreCompleto";
        ddown004a.DataValueField = "ICodTrabajador";
        dv19.Sort = "NombreCompleto";
        ddown004a.DataBind();

    }

    #endregion

    # region Limpia Formulario
    protected void imb_003a_Click(object sender, EventArgs e)
    {
        clean_form();
        BtnModificarDiagnostico.Visible = false;
        BtnAgregarDiagnostico.Visible = true;
        //lblAvisoCargaDatos.Visible = false;

        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    }

    
    private void clean_form()
    {
        //cal001a.Value = "Seleccione Fecha";
        CalDiagnostico.Text = "";

        ddown001a.SelectedValue = "0";
        ddown002a.SelectedValue = "0";
        ddown003a.SelectedValue = "0";
        ddown004a.SelectedValue = "0";

        txt_003a.Text = "";

        chk001a.Checked = false;
        chk002a.Checked = false;

        rdo001a.Checked = true;
        rdo002a.Checked = false;
        rdo003a.Checked = true;
        rdo004a.Checked = false;

        ddown001a.Enabled = true;
        ddown002a.Enabled = true;
        ddown003a.Enabled = true;

        rdo003a.Enabled = true;
        rdo004a.Enabled = true;

        chk001a.Enabled = true;
        chk002a.Enabled = true;

        CalDiagnostico.BackColor = System.Drawing.Color.Empty;
        ddown001a.BackColor = System.Drawing.Color.Empty;
        ddown003a.BackColor = System.Drawing.Color.Empty;
        ddown004a.BackColor = System.Drawing.Color.Empty;
                
    }

    # endregion

    # region Funciones del formulario

    private bool validateMaltrato()
    {
        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        //WebDateChooser tcal001a = (TextBox)utab4.FindControl("cal001a");
        if (CalDiagnostico.Text == "")
        {
            CalDiagnostico.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            CalDiagnostico.BackColor = System.Drawing.Color.White;
        }



        //DropDownList tddown001a = (DropDownList)utab4.FindControl("ddown001a");

        if (Convert.ToInt32(ddown001a.SelectedValue) == 0)
        {
            ddown001a.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001a.BackColor = System.Drawing.Color.White;
           // DropDownList tddown002a = (DropDownList)utab4.FindControl("ddown002a");

            if (Convert.ToInt32(ddown002a.SelectedValue) == 0)
            {
                ddown002a.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                ddown002a.BackColor = System.Drawing.Color.White;
            }
        }

        if (rdo003a.Checked == true)
        {
            if (Convert.ToInt32(ddown003a.SelectedValue) == 0)
            {
                ddown003a.BackColor = colorCampoObligatorio;
                n = false;
            }
            else 
            {
                ddown003a.BackColor = System.Drawing.Color.Empty;
            }
        }




        
        if (Convert.ToInt32(ddown003a.SelectedValue) == 0 && rdo004a.Checked == false)
        {
            ddown003a.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003a.BackColor = System.Drawing.Color.Empty;

        }
        //DropDownList tddown004a = (DropDownList)utab4.FindControl("ddown004a");

        if (Convert.ToInt32(ddown004a.SelectedValue) == 0)
        {
            ddown004a.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown004a.BackColor = System.Drawing.Color.White;

        }


        return n;


    }
    private bool validateMaltrato2()
    {
        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        //WebDateChooser tcal001a = (TextBox)utab4.FindControl("cal001a");
        if (CalDiagnostico.Text == "")
        {

            CalDiagnostico.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            CalDiagnostico.BackColor = System.Drawing.Color.White;

        }

        //DropDownList tddown004a = (DropDownList)utab4.FindControl("ddown004a");

        if (Convert.ToInt32(ddown004a.SelectedValue) == 0)
        {
            ddown004a.BackColor = colorCampoObligatorio;
            n = false;
        }
        
        if (rdo003a.Checked == true)
        {
            if (Convert.ToInt32(ddown003a.SelectedValue) == 0 && !rdo002a.Checked)
            {
                ddown003a.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                ddown003a.BackColor = System.Drawing.Color.White;
            }
        }
        

        if (Convert.ToInt32(ddown004a.SelectedValue) == 0)
        {
            ddown004a.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown004a.BackColor = System.Drawing.Color.White;

        }
        

        ddown001a.BackColor = System.Drawing.Color.Empty;
        ddown003a.BackColor = System.Drawing.Color.Empty;

        return n;




    }



    private Boolean Diag_PresentaMaltrato()
    {
      

        if (rdo001a.Checked)
        {
            return true;
        }
        else if (rdo002a.Checked)
        {
            return false;
        }
        else
        {
            return false;
        }

    }

    private Boolean Diag_ConoceMaltratador()
    {
        

        if (rdo003a.Checked)
        {
            return true;
        }
        else if (rdo004a.Checked)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    private Boolean Diag_ViveConAgresor()
    {

        if (chk001a.Checked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private Boolean Diag_ExisteQuerellaSename()
    {
        if (chk002a.Checked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }





    #endregion


    protected void ddown003a_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

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
