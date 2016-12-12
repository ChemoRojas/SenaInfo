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

public partial class mod_ninos_PeoresFormas : System.Web.UI.Page
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
    public int VICodPFTI
    {
        get
        {
            if (ViewState["VICodPFTI"] == null)
            { ViewState["VICodPFTI"] = -1; }
            return Convert.ToInt32(ViewState["VICodPFTI"]);
        }
        set { ViewState["VICodPFTI"] = value; }
    }
   

    # endregion




    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial

        RangeValidator1.Validate();
        RangeValidator2.Validate();

        //mostrar_collapse(true);

        if (!IsPostBack)
        {
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
                getcomuna();
                btn002h.Visible = false;
                //btnGatilloCancelar.Style.Add("display", "none");gfontbrevis
                validatescurity();
            }
             #endregion
        }
        # endregion
    }

    private void getcomuna()
    {        
        parcoll par = new parcoll();
        DataView dv101 = new DataView(par.GetparComunas(ddown_region.SelectedValue));
        ddown_Comuna.Items.Clear();
        ddown_Comuna.DataSource = dv101;
        ddown_Comuna.DataTextField = "Descripcion";
        ddown_Comuna.DataValueField = "CodComuna";
        dv101.Sort = "Descripcion";
        ddown_Comuna.DataBind();

        //DataView dv101 = new DataView(par.GetparComunas(ddown_region.DataValueField));
        ////dv100.Sort = "Descripcion";
        //ddown_Comuna.Items.Clear();
        //ddown_Comuna.DataSource = dv101;
        //ddown_Comuna.DataTextField = "Descripcion";
        //ddown_Comuna.DataValueField = "CodComuna";
        //dv100.Sort = "Descripcion  ";
        //ddown_Comuna.DataBind();
    }

    private void validatescurity()
    {
        #region Validacion


        //357AB123-05D6-4F6F-93E9-C8007A403079 2.3_MODIFICAR
        if (!window.existetoken("357AB123-05D6-4F6F-93E9-C8007A403079"))
        {
            btn002h.Visible = false;
            grd001h.Columns[5].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            btn001h.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            btn004h.Visible = false;
        }

        #endregion
    }

    # region inserta diagnostico


    protected void imb_001h_Click(object sender, EventArgs e)
    {
        int comuna = 0;
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();
        
        if (txt001_wth.Text.Trim() == "")
        {
            txt001_wth.Text = "";
        }

        if (ddown002h.SelectedValue == Convert.ToString(0))
        {
            ddown002h.SelectedValue = Convert.ToString(0);
        }

        if (ddown_Comuna.SelectedValue == Convert.ToString(0))
        {
            comuna = -1;
        }
        else
        {
            comuna = Convert.ToInt32(ddown_Comuna.SelectedValue); 
        }


        if (ddown_relacion.SelectedValue.Equals("Seleccionar"))
        {
            ddown_relacion.SelectedValue = Convert.ToString(null);
        }

      

        if (validatePFT() == true)
        {

            if (rdo001h.Checked == true)
            {
                int inden = ncoll.Insert_DiagnosticoGeneral(8, SSninoDiag.CodNino,
                    SSninoDiag.ICodIE, Convert.ToDateTime(cal001h.Text));

                dcoll.Insert_DiagnosticosPeoresFormaTrabajo
                    (
                    inden,
                    Convert.ToInt32(ddown001h.SelectedValue),
                    Convert.ToDateTime(cal001h.Text),
                    PresentaAgrecionPF(),
                    Convert.ToInt32(ddown002h.SelectedValue),
                    chk001h.Checked,
                    Convert.ToString(txt001_wth.Text).ToUpper(),
                    Convert.ToInt32(ddown003h.SelectedValue),
                    SSninoDiag.CodInst,
                    Convert.ToInt32(ddown003h.SelectedValue),
                    DateTime.Now,
                    Convert.ToInt32(Session["IdUsuario"]),
                    comuna,
                    Convert.ToDateTime(cal002h.Text),
                    Convert.ToInt32(ddown_relacion.SelectedValue));

                lbl_nota2.Visible = false;//gfontbrevis

                clean_form();
                ddown001h.Enabled = true;
                ddown002h.Enabled = true;
                ddown003h.Enabled = true;
                chk001h.Enabled = true;

                mostrar_collapse(false);
                //gfontbrevis
                btnGatillo.Attributes.Remove("disabled");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);

            }
            else
            {

                int inden = ncoll.Insert_DiagnosticoGeneral(8, SSninoDiag.CodNino,
                        SSninoDiag.ICodIE, Convert.ToDateTime(cal001h.Text));

                dcoll.Insert_DiagnosticosPeoresFormaTrabajo(
                    inden,
                    34,
                    Convert.ToDateTime(cal001h.Text),
                    PresentaAgrecionPF(),
                    0,
                    false,
                    Convert.ToString(txt001_wth.Text).ToUpper(),
                    -1,
                    SSninoDiag.CodInst,
                    -1,
                    DateTime.Now, Convert.ToInt32(Session["IdUsuario"]),
                    comuna,
                    Convert.ToDateTime(cal002h.Text),
                    Convert.ToInt32(ddown_relacion.SelectedValue)
               
                    );


                clean_form();
                ddown001h.Enabled = true;
                ddown002h.Enabled = true;
                ddown003h.Enabled = true;
                chk001h.Enabled = true;

                mostrar_collapse(false);
                //gfontbrevis
                btnGatillo.Attributes.Remove("disabled");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);

            }
        }
        else {
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);

        }

        
        DataTable dt6 = dcoll.GetDiagnosticoPeoresFormasMostrar(SSninoDiag.ICodIE);
        DataView dv6 = new DataView(dt6);
        dv6.Sort = "FechaDiagnostico DESC";
        grd001h.DataSource = dv6;
        grd001h.DataBind();
        grd001h.Visible = true;
        grd001h.Visible = true;
        
        if (dv6.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis

        }

        //grd001h.Focus();
    }
    
    # endregion 
     
    # region ActualizaDiagnostico

    protected void grd001h_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();

        string ICodPFTI = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VICodPFTI = Convert.ToInt32(ICodPFTI);
        
        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
        VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);
        
        DataTable dt = dcoll.GetPeoresFormasdeTrabajo(VCod_diagnostico);

        cal001h.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToShortDateString();
        string maltrato = dt.Rows[0][2].ToString();

        if (Convert.ToBoolean(dt.Rows[0][1]) == true)
        {
            rdo001h.Checked = true;
            rdo002h.Checked = false;
            ddown001h.Enabled = true;
            ddown002h.Enabled = true;
            ddown003h.Enabled = true;
            chk001h.Enabled = true;
        }
        else
        {
            rdo001h.Checked = false;
            rdo002h.Checked = true;
            ddown001h.Enabled = false;
            ddown002h.Enabled = false;
            ddown003h.Enabled = false;
            chk001h.Enabled = false;
        }
        
        if (Convert.ToInt32(maltrato) != 0)
        {
            
        }

        //F.Urrutia 12-05-2014
        if (dt.Rows[0][10].ToString() != "0")
        {
            ddown_region.SelectedValue = Convert.ToString(dt.Rows[0][10]);
            ddown_Comuna.Items.Clear();
            getcomuna();
        }

        if (dt.Rows[0][7].ToString() != "0")
        {
            if (Convert.ToString(dt.Rows[0][7]).ToString().Equals("-1"))
            {
                ddown_Comuna.SelectedValue = Convert.ToString(0);
            }
            else
            {
                ddown_Comuna.SelectedValue = Convert.ToString(dt.Rows[0][7]);
            }
        }
        if (dt.Rows[0][8] != null)
        {
            cal002h.Text = Convert.ToDateTime(dt.Rows[0][8].ToString()).ToShortDateString();
            
        }
        if (dt.Rows[0][9] != null)
        {
            ddown_relacion.SelectedValue = Convert.ToString(dt.Rows[0][9]);
        }
        //Fin Actualizacion

        

        ddown001h.Items.FindByValue(ddown001h.SelectedValue).Selected = false;
        ddown001h.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;

        ddown002h.Items.FindByValue(ddown002h.SelectedValue).Selected = false;
        ddown002h.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;

        if (Convert.ToBoolean(dt.Rows[0][4]) == true)
        {
            chk001h.Checked = true;
        }
        else
        {
            chk001h.Checked = false;
        }

        ddown003h.Items.FindByValue(ddown003h.SelectedValue).Selected = false;

        try
        {
            ddown003h.Items.FindByValue(dt.Rows[0][5].ToString()).Selected = true;
        }
        catch
        {
            ddown003h.Items.FindByValue("-1").Selected = true;
        }

        txt001_wth.Text = Convert.ToString(dt.Rows[0][6]);
        btn001h.Visible = false;
        btn002h.Visible = true;
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }

    protected void imb_002h_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();     
        if (txt001_wth.Text == null)
        {
            txt001_wth.Text = "SIN OBSERVACION";
        }
        if (validatePFT())
        {
            if (rdo001h.Checked)
            {
                dcoll.Update_DiagnosticosPeoresFormaTrabajo(VICodPFTI,
                VCod_diagnostico,
                Convert.ToInt32(ddown001h.SelectedValue),
                Convert.ToDateTime(cal001h.Text),
                PresentaAgrecionPF(),
                Convert.ToInt32(ddown002h.SelectedValue),
                chk001h.Checked,
                txt001_wth.Text.ToUpper(),
                Convert.ToInt32(ddown003h.SelectedValue),
                SSninoDiag.CodInst,
                Convert.ToInt32(ddown003h.SelectedValue),
                DateTime.Now,
                Convert.ToInt32(Session["IdUsuario"]),
                Convert.ToDateTime(cal002h.Text),
                Convert.ToInt32(ddown_region.SelectedValue),
                Convert.ToInt32(ddown_Comuna.SelectedValue),
                Convert.ToInt32(ddown_relacion.SelectedValue));
                btn001h.Visible = true;
                btn002h.Visible = false;

                clean_form();

            }
            else
            {

                dcoll.Update_DiagnosticosPeoresFormaTrabajo(VICodPFTI,
                 VCod_diagnostico, 34,
                 Convert.ToDateTime(cal001h.Text),
                 PresentaAgrecionPF(), 0, false,
                 Convert.ToString(txt001_wth.Text).ToUpper(), -1,
                 SSninoDiag.CodInst, -1,
                 DateTime.Now, Convert.ToInt32(Session["IdUsuario"]),
                 Convert.ToDateTime(cal002h.Text),
                 Convert.ToInt32(ddown_region.SelectedValue),
                 Convert.ToInt32(ddown_Comuna.SelectedValue),
                 Convert.ToInt32(ddown_relacion.SelectedValue));

                btn001h.Visible = true;
                btn002h.Visible = false;
                clean_form();
                mostrar_collapse(false);
                //gfontbrevis
                btnGatillo.Attributes.Remove("disabled");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);
            }
        }
        else {
            //gfontbrevis
            mostrar_collapse(true);
            btnGatillo.Attributes.Add("disabled", "disabled");
        }
        DataTable dt6 = dcoll.GetDiagnosticoPeoresFormasMostrar(SSninoDiag.ICodIE);
        DataView dv6 = new DataView(dt6);
        dv6.Sort = "FechaDiagnostico DESC";
        grd001h.DataSource = dv6;
        grd001h.DataBind();
        grd001h.Visible = true;
        grd001h.Visible = true;        
        if (dv6.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis

        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis

        }
        
    }

    # endregion

    # region Historico de Diagnosticos

    protected void btn004h_Click(object sender, EventArgs e)
    {
        //window.open(this.Page, "ninos_HistoricoDiagnosticoPeoresFormas.aspx", 770, 420);
    }

    # endregion

    #region volver

    protected void btn005h_Click(object sender, EventArgs e)
    {
        //clean_form();

        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");

    }
   
    # endregion

    #region validaciones

    protected void rdo001h_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        ddown001h.SelectedValue = "0";
        ddown002h.SelectedValue = "0";
        ddown003h.SelectedValue = "0";
        chk001h.Checked = false;

        ddown001h.Enabled = true;
        ddown002h.Enabled = true;
        ddown003h.Enabled = true;
        chk001h.Enabled = true;      


    }
    protected void rdo002h_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        if (rdo002h.Checked == true)
        {
            ddown001h.BackColor = System.Drawing.Color.Empty;
            ddown002h.BackColor = System.Drawing.Color.Empty;
            ddown003h.BackColor = System.Drawing.Color.Empty;
        }


        ddown001h.SelectedValue = "34";
        ddown002h.SelectedValue = "0";
        ddown003h.SelectedValue = "-1";
        chk001h.Checked = false;

        ddown001h.Enabled = true;
        ddown002h.Enabled = true;
        ddown003h.Enabled = true;
        chk001h.Enabled = true;

    }


  

    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();




        //Label lbl_fechaingresoPFT = (Label)utab4.FindControl("lbl_fechaPFT");
        //lbl_fechaingresoPFT.Text = SSninoDiag.fchingdesde.ToShortDateString();

        //cal001h.MinDate = SSninoDiag.fchingdesde;
        //cal001h.MaxDate = DateTime.Now;
        CalendarExtende1104.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende1104.EndDate = DateTime.Now;

        //GridView tgrd001h = (GridView)utab4.FindControl("grd001h");
        //Label tlbl001h = (Label)utab4.FindControl("lbl001h");
        DataTable dt8 = dcoll.GetDiagnosticoPeoresFormasMostrar(SSninoDiag.ICodIE);
        DataView dv8 = new DataView(dt8);
        dv8.Sort = "FechaDiagnostico DESC";
        grd001h.DataSource = dv8;
        grd001h.DataBind();
        grd001h.Visible = true;
        //utab4.Visible = true;

        if (dv8.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis

        }

        //Diagnostico PeoresFormasDeTrabajo
        //Cambiar PeoresFormas.aspx.cs

        DataView dv100 = new DataView(par.GetparRegion());
        //dv100.Sort = "Descripcion";
        ddown_region.Items.Clear();
        ddown_region.DataSource = dv100;
        ddown_region.DataTextField = "Descripcion";
        ddown_region.DataValueField = "CodRegion";
        dv100.Sort = "Descripcion";
        ddown_region.DataBind();

        

        DataView dv102 = new DataView(par.GetparTipoRelacion());
        //dv100.Sort = "Descripcion";
        ddown_relacion.Items.Clear();
        ddown_relacion.Items.Add("Seleccionar");        
        ddown_relacion.DataSource = dv102;
        ddown_relacion.DataTextField = "Descripcion";
        ddown_relacion.DataValueField = "TipoRelacion";
        dv102.Sort = "Descripcion";
        ddown_relacion.DataBind();
        
        //DropDownList tddown001h = (DropDownList)utab4.FindControl("ddown001h");
        DataView dv45 = new DataView(par.GetparCategoriasPFMI());
        ddown001h.Items.Clear();
        ddown001h.DataSource = dv45;
        ddown001h.DataTextField = "Nombre";
        ddown001h.DataValueField = "CodCategoria";
        dv45.Sort = "Nombre";
        ddown001h.DataBind();

        //DropDownList tddown002h = (DropDownList)utab4.FindControl("ddown002h");
        DataView dv46 = new DataView(ncoll.GetPersonasRelacionadas(SSninoDiag.ICodIE.ToString()));
        ddown002h.Items.Clear();
        ddown002h.DataSource = dv46;
        ddown002h.DataTextField = "Agresor";
        ddown002h.DataValueField = "CodPersonaRelacionada";
        dv46.Sort = "Agresor";
        ddown002h.DataBind();

        //DropDownList tddown003h = (DropDownList)utab4.FindControl("ddown003h");
        DataView dv47 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
        ddown003h.Items.Clear();
        ddown003h.DataSource = dv47;
        ddown003h.DataTextField = "NombreCompleto";
        ddown003h.DataValueField = "ICodTrabajador";
        dv47.Sort = "NombreCompleto";
        ddown003h.DataBind();


    }

    #endregion

    # region Limpia Formulario

    protected void btn003h_Click(object sender, EventArgs e)
    {
        clean_form();

        btn002h.Visible = false;
        btn001h.Visible = true;
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    }
     
   

    private void clean_form()
    {
        ddown_Comuna.SelectedIndex = 0;
        ddown_relacion.SelectedIndex =0;
        ddown_region.SelectedIndex = 0;
        ddown001h.SelectedValue = "0";

        ddown002h.SelectedValue = "0";
        ddown003h.SelectedValue = "0";
       

        txt001_wth.Text = "";

        cal001h.Text = "";
        cal002h.Text = "";

        chk001h.Checked = false;
        rdo001h.Checked = true;
        rdo002h.Checked = false;

        ddown001h.Enabled = true;
        ddown002h.Enabled = true;
        chk001h.Enabled = true;
        ddown003h.Enabled = true;


        ddown_Comuna.BackColor = System.Drawing.Color.Empty;
        ddown001h.BackColor = System.Drawing.Color.Empty;
        ddown003h.BackColor = System.Drawing.Color.Empty;
        cal001h.BackColor = System.Drawing.Color.Empty;//gfontbrevis
    }

    # endregion

    #region Funciones del Formulario

    private bool validatePFT()
    {
        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (cal001h.Text == "")
        {
            cal001h.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001h.BackColor = System.Drawing.Color.White;
        }


        // Habilitar cuando Isabel Farias envíe los instructivos DPL 18-03-2015
        if (cal002h.Text == "")
        {
            cal002h.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal002h.BackColor = System.Drawing.Color.White;
        }

        if (ddown_region.SelectedValue == Convert.ToString(-2))
        {
            ddown_region.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown_region.BackColor = System.Drawing.Color.White;
        }


        if (ddown_Comuna.SelectedValue == Convert.ToString(0))
        {
            ddown_Comuna.BackColor = colorCampoObligatorio;
            //lbl001h.Text = "Debe registrar comuna de Ocurrencia";//gfontbrevis
            n = false;
        }
        else
        {


            ddown_Comuna.BackColor = System.Drawing.Color.White;
        }



        if (ddown_relacion.SelectedValue ==Convert.ToString("Seleccionar"))
        {
            ddown_relacion.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown_relacion.BackColor = System.Drawing.Color.White;
        }

        if (rdo002h.Checked == false)
        {
            if (Convert.ToInt32(ddown001h.SelectedValue) == 0)
            {
                ddown001h.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                ddown001h.BackColor = System.Drawing.Color.White;
            }

            if (Convert.ToInt32(ddown003h.SelectedValue) == 0)
            {
                ddown003h.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                ddown003h.BackColor = System.Drawing.Color.White;
            }



        }
        else
        {

            ddown001h.BackColor = System.Drawing.Color.Transparent;
            ddown002h.BackColor = System.Drawing.Color.Transparent;
            ddown003h.BackColor = System.Drawing.Color.Transparent;
        }


        return n;


    }

    private Boolean PresentaAgrecionPF()
    {

        if (rdo001h.Checked)
        {
            return true;
        }
        else if (rdo002h.Checked)
        {
            return false;
        }
        else
        {
            return false;
        }

    }





    #endregion

    protected void ddown_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddown_Comuna.Items.Clear();
        getcomuna();
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
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
    protected void ddown_relacion_SelectedIndexChanged(object sender, EventArgs e)
    {
      mostrar_collapse(true);
      //gfontbrevis
      btnGatillo.Attributes.Add("disabled", "disabled");
      //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
      //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }
}
