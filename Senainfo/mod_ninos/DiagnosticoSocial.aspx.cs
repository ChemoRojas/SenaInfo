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

public partial class mod_ninos_DiagnosticoSocial : System.Web.UI.Page
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
    public DateTime VFechaFonasa
    {
        get
        {
            if (ViewState["FechaFonasa"] == null)
            { ViewState["FechaFonasa"] = Convert.ToDateTime("01-01-1900"); }
            return Convert.ToDateTime(ViewState["FechaFonasa"]);
        }
        set { ViewState["FechaFonasa"] = value; }
    }
    public DateTime VFechaChileSolidario
    {
        get
        {
            if (ViewState["FechaChileSolidario"] == null)
            { ViewState["FechaChileSolidario"] = Convert.ToDateTime("01-01-1900"); }
            return Convert.ToDateTime(ViewState["FechaChileSolidario"]);
        }
        set { ViewState["FechaChileSolidario"] = value; }
    }
    public DateTime VFechaChileCreceContigo
    {
        get
        {
            if (ViewState["FechaChileCreceContigo"] == null)
            { ViewState["FechaChileCreceContigo"] = Convert.ToDateTime("01-01-1900"); }
            return Convert.ToDateTime(ViewState["FechaChileCreceContigo"]);
        }
        set { ViewState["FechaChileCreceContigo"] = value; }
    }
    
    
    public String VFonasa
    {
        get
        {
            if (ViewState["Fonasa"] == null)
            { ViewState["Fonasa"] = -1; }
            return Convert.ToString(ViewState["Fonasa"]);
        }
        set { ViewState["Fonasa"] = value; }
    }
    public String VChileSolidario
    {
        get
        {
            if (ViewState["ChileSolidario"] == null)
            { ViewState["ChileSolidario"] = -1; }
            return Convert.ToString(ViewState["ChileSolidario"]);
        }
        set { ViewState["ChileSolidario"] = value; }
    }
    public String VChileCreceContigo
    {
        get
        {
            if (ViewState["ChileCreceContigo"] == null)
            { ViewState["ChileCreceContigo"] = -1; }
            return Convert.ToString(ViewState["ChileCreceContigo"]);
        }
        set { ViewState["ChileCreceContigo"] = value; }
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
    
    public int VICodSocial
    {
        get
        {
            if (ViewState["VICodSocial"] == null)
            { ViewState["VICodSocial"] = -1; }
            return Convert.ToInt32(ViewState["VICodSocial"]);
        }
        set { ViewState["VICodSocial"] = value; }
    }

    public DateTime IFechaNac
    {
        get
        {
            if (ViewState["Fecha_nacimiento"] == null)
            { ViewState["Fecha_nacimiento"] = -1; }
            return Convert.ToDateTime(ViewState["Fecha_nacimiento"]);
        }
        set { ViewState["Fecha_nacimiento"] = value; }
    }

    # endregion




    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial
        CalendarExtende391.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende391.EndDate = System.DateTime.Now;
        
        RangeValidator1.Validate();
        rv_año.Validate();
        RangeValidator3.Validate();
        RangeValidator2.Validate();
        RangeValidator4.Validate();
        RangeValidator5.Validate();


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
                imb_002d.Visible = false;
                validatescurity();
                CalendarExtende416.EndDate = DateTime.Now;
                CalendarExtende429.EndDate = DateTime.Now;
                CalendarExtende442.EndDate = DateTime.Now;
                //btnGatilloCancelar.Style.Add("display", "none");//gfontbrevis

            }
            #endregion
        }
        else
        {
            if (txtNumeroSemanasGestacion.Text != "")
            {
                RVNumeroSemanasGestacion.Validate();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "var txt006d = document.getElementById('txt006d');max(txt006d);CharLimit(txt006d, 100);", true);            
        }
        # endregion
    }

    private void validatescurity()
    {
        #region Validacion


        //357AB123-05D6-4F6F-93E9-C8007A403079 2.3_MODIFICAR
        if (!window.existetoken("357AB123-05D6-4F6F-93E9-C8007A403079"))
        {
            imb_002d.Visible = false;
            grd001d.Columns[8].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            imb_001d.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            imb_004d.Visible = false;
        }

        #endregion
    }
    # region inserta diagnostico

    protected void imb_001d_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();


        
        Boolean sw = false;
        DateTime fecha_aux;


        for (int i = 0; i < grd001d.Rows.Count; i++)
        {
            if (Convert.ToDateTime((grd001d.Rows[i].Cells[2]).Text.ToUpper().Trim()).ToShortDateString() == Server.HtmlDecode(cal001d.Text.Trim()))
            {
                lbl001d.Text = "Sólo se puede ingresar un diagnóstico social por día. Por favor comprobar la fecha de diagnóstico";
                lbl001d.Visible = true;
                sw = true;

                mostrar_collapse(true);
                //gfontbrevis
                btnGatillo.Attributes.Add("disabled", "disabled");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);
            }


        }


        if (validateSocial() == true && sw == false)
        {

           // utab4.Tabs[4].Style.ForeColor = System.Drawing.Color.Black;
            if (txt006d.Text.Trim() == "")
            {
                txt006d.Text = "SIN OBSERVACION";
            }


            if (txt001d.Text.Trim() == "")
            {
                txt001d.Text = "0";
            }
            if (txt002d.Text.Trim() == "")
            {
                txt002d.Text = "0";
            }
            if (txt003d.Text.Trim() == "")
            {
                txt003d.Text = "0";
            }
            if (txt004d.Text.Trim() == "")
            {
                txt004d.Text = "0";
            }
            if (txt005d.Text.Trim() == "")
            {
                txt005d.Text = "0";
            }
            if (txt007d.Text.Trim() == "")
            {
                txt007d.Text = "0";
            }
            if (cal002d.Text.Trim() == "")
            {
                fecha_aux = Convert.ToDateTime("01-01-1900");

            }

            else
            {

                fecha_aux = Convert.ToDateTime(cal002d.Text);
            }


            if (cal003d.Text == "")
            {
                VFechaFonasa = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaFonasa = Convert.ToDateTime(cal003d.Text);
            }

            if (cal004d.Text == "")
            {
                VFechaChileSolidario = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaChileSolidario = Convert.ToDateTime(cal004d.Text);
            }

            if (cal005d.Text == "")
            {
                VFechaChileCreceContigo = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaChileCreceContigo = Convert.ToDateTime(cal005d.Text);
            }

            
            string NumeroSemanasGestacion = "0";
            string NumeroHijos = "0";
            
            if (SSninoDiag.sexo.ToString() == "F")
            {
                if (RbtnEmbarazadaSi.Checked == true)
                {
                    NumeroSemanasGestacion = txtNumeroSemanasGestacion.Text;
                }
                else
                {
                    rbtnEmbarazoAbusoViolacionSi.Checked = false;
                }
            }

            if (rbtnAdolescentePadreMadreSi.Checked == true)
            {
                NumeroHijos = txtNumeroHijos.Text;
            }
            else
            {
                rbtnHijosViolacionSi.Checked = false;
            }
            
            //WebMaskEdit ttxt001d = (TextBox)utab4.FindControl("txt001d");

            string Mes = ddown004d.SelectedValue;
            string ano = txt001d.Text.Trim();
            string anomes = ano + Mes;
            diagnosticoscoll dcoll2 = new diagnosticoscoll();

            if (chk001d.Checked)
            {
                dcoll2.Update_InsFonasa(SSninoDiag.CodNino);
            }
            else
            {
                dcoll2.Update_noInsFonasa(SSninoDiag.CodNino);
            }
            dcoll2.Update_Etnia(SSninoDiag.CodNino, Convert.ToInt32(ddown009d.SelectedValue));
            int inden = ncoll.Insert_DiagnosticoGeneral(5, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(cal001d.Text));

            dcoll.Insert_DiagnosticosSocial(inden
                , Convert.ToDateTime(cal001d.Text)
                , 10
                , Convert.ToInt32(ddown001d.SelectedValue)
                , Convert.ToInt32(ddown002d.SelectedValue)
                , Convert.ToInt32(ddown005d.SelectedValue)
                , SSninoDiag.CodInst
                , Convert.ToInt32(ddown005d.SelectedValue)
                , Convert.ToInt32(ddown003d.SelectedValue)
                , Convert.ToString(txt006d.Text).ToUpper()
                , Convert.ToInt32(anomes)
                , Convert.ToInt32(txt002d.Text.Trim())
                , Convert.ToInt32(txt003d.Text.Trim())
                , Convert.ToInt32(txt004d.Text.Trim())
                , Convert.ToInt32(txt005d.Text.Trim())
                , Convert.ToInt32(txt007d.Text.Trim())
                , fecha_aux
                , Convert.ToInt32(ddown007d.SelectedValue)
                , Convert.ToInt32(ddown006d.SelectedValue)
                , 0
                , DateTime.Now
                , Convert.ToInt32(Session["IdUsuario"])
                , Convert.ToInt32(ddown009d.SelectedValue)
                , VFonasa.ToUpper()
                , VChileSolidario.ToUpper()
                , VChileCreceContigo.ToUpper()
                , VFechaFonasa
                , VFechaChileSolidario
                , VFechaChileCreceContigo
                , RbtnEmbarazadaSi.Checked
                , Convert.ToInt32(NumeroSemanasGestacion)
                , rbtnEmbarazoAbusoViolacionSi.Checked
                , rbtnAdolescentePadreMadreSi.Checked
                , Convert.ToInt32(NumeroHijos)
                , rbtnHijosViolacionSi.Checked);

            clean_form();


             CalendarExtende391.EndDate = DateTime.Now;
            CalendarExtende391.StartDate = SSninoDiag.fchingdesde;

            CalendarExtende403.EndDate = DateTime.Now;
            lbl001d.Text = "";

            //mostrar_collapse(true);
            //gfontbrevis
            //btnGatillo.Attributes.Add("disabled", "disabled");//TODO: es al reves
            btnGatillo.Attributes.Remove("disabled");
            mostrar_collapse(false);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        }
        else
        {

            //utab4.Tabs[4].Style.ForeColor = System.Drawing.Color.Red;
          mostrar_collapse(true);
          //gfontbrevis
          btnGatillo.Attributes.Add("disabled", "disabled");
          //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
          //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

        }

        DataTable dt4 = dcoll.GetDiagnosticoSocial(SSninoDiag.ICodIE);
        DataView dv4 = new DataView(dt4);
        dv4.Sort = "FechaDiagnostico DESC";
        grd001d.DataSource = dv4;
        grd001d.DataBind();
        grd001d.Visible = true;
        //utab4.Visible = true;



        if (dv4.Count == 0)
        {
            //lbl001d.Text = "Este Niño(a) no Posee Diagnostico Social";
            lbl001da.Visible = true;//gfontbrevis
        }

        //grd001d.Focus();

    }
    # endregion

    # region ActualizaDiagnostico


    protected void grd001d_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        
        diagnosticoscoll dcoll = new diagnosticoscoll();


        string ICodSocial = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VICodSocial = Convert.ToInt32(ICodSocial);

        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
        VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);


        DataTable dt = dcoll.GetDiagnosticoSocialMostrar(VCod_diagnostico);

        cal001d.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToShortDateString();


        try
        {
            ddown001d.Items.FindByValue(ddown001d.SelectedValue).Selected = false;
            ddown001d.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;
        }
        catch
        {
            ddown001d.SelectedValue = "0";
        }
        try
        {
            ddown002d.Items.FindByValue(ddown002d.SelectedValue).Selected = false;
            ddown002d.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;
        }
        catch
        {
            ddown002d.SelectedValue = "0";
        }
        try
        {
            ddown003d.Items.FindByValue(ddown003d.SelectedValue).Selected = false;
            ddown003d.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;
        }
        catch
        {
            ddown003d.SelectedValue = "0";
        }
        try
        {
            ddown009d.Items.FindByValue(ddown009d.SelectedValue).Selected = false;
            ddown009d.Items.FindByValue(dt.Rows[0][15].ToString()).Selected = true;
        }
        catch
        {
            ddown009d.SelectedValue = "0";
        }

        string anomes = dt.Rows[0][4].ToString();
        string ano = "0";
        string mes = "0";

        if (dt.Rows[0][16].ToString() == "SI")
        {
            chk001d.Checked = true;
            if (dt.Rows[0][19].ToString() == "" || Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString() == "01-01-1900" || Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString() == "01/01/1900")
            {
                cal003d.Text = "";
                cal003d.Enabled = true;
            }
            else
            {
                cal003d.Text = Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString();
                cal003d.Enabled = true;
            }
        }
        else 
        {
            chk001d.Checked = false;
        }

        if (dt.Rows[0][17].ToString() == "SI")
        {
            chk002d.Checked = true;
            if (dt.Rows[0][20].ToString() == "" || Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString() == "01-01-1900" || Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString() == "01/01/1900")
            {
                cal004d.Text = "";
                cal004d.Enabled = true;
            }
            else
            {
                cal004d.Text = Convert.ToDateTime(dt.Rows[0][20].ToString()).ToShortDateString();
                cal004d.Enabled = true;
            }
        }
        else
        {
            chk002d.Checked = false;
        }

        if (dt.Rows[0][18].ToString() == "SI")
        {
            chk003d.Checked = true;
            if (dt.Rows[0][21].ToString() == "" || Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString() == "01-01-1900" || Convert.ToDateTime(dt.Rows[0][19].ToString()).ToShortDateString() == "01/01/1900")
            {
                cal005d.Text = "";
                cal005d.Enabled = true;
            }
            else
            {
                cal005d.Text = Convert.ToDateTime(dt.Rows[0][21].ToString()).ToShortDateString();
                cal005d.Enabled = true;
            }
        }
        else
        {
            chk003d.Checked = false;
        }
       
       
        

        try
        {
            ano = anomes.Substring(0, 4);
        }
        catch { }
        try
        {
            mes = anomes.Substring(4, 2);
        }
        catch { }

        ddown004d.SelectedValue = mes;
        txt001d.Text = ano;


        ddown005d.Items.FindByValue(ddown005d.SelectedValue).Selected = false;
        try
        {
            ddown005d.Items.FindByValue(dt.Rows[0][11].ToString()).Selected = true;
        }
        catch
        {
            ddown005d.Items.FindByValue("-1").Selected = true;
        }

        //txt001d.Text = Convert.ToString(dt.Rows[0][4]);
        txt002d.Text = Convert.ToString(dt.Rows[0][5]);
        txt003d.Text = Convert.ToString(dt.Rows[0][6]);
        txt004d.Text = Convert.ToString(dt.Rows[0][7]);
        txt005d.Text = Convert.ToString(dt.Rows[0][8]);
        txt007d.Text = Convert.ToString(dt.Rows[0][9]);

        cal002d.Text = Convert.ToDateTime(dt.Rows[0][10].ToString()).ToShortDateString();
        
        if (Convert.ToDateTime(dt.Rows[0][19]).ToShortDateString() == "01-01-1900" || Convert.ToDateTime(dt.Rows[0][19]).ToShortDateString() == "01/01/1900")
        {
            cal003d.Text = "";
        }
        else 
        {
            cal003d.Text = Convert.ToDateTime(dt.Rows[0][19]).ToShortDateString();
        }
        if (Convert.ToDateTime(dt.Rows[0][20]).ToShortDateString() == "01-01-1900" || Convert.ToDateTime(dt.Rows[0][20]).ToShortDateString() == "01/01/1900")
        {
            cal004d.Text = "";
        }
        else
        {
            cal003d.Text = Convert.ToDateTime(dt.Rows[0][20]).ToShortDateString();
        }
        if (Convert.ToDateTime(dt.Rows[0][21]).ToShortDateString() == "01-01-1900" || Convert.ToDateTime(dt.Rows[0][21]).ToShortDateString() == "01/01/1900")
        {
            cal005d.Text = "";
        }
        else
        {
            cal003d.Text = Convert.ToDateTime(dt.Rows[0][21]).ToShortDateString();
        }



        txt006d.Text = Convert.ToString(dt.Rows[0][12]);        


        try
        {
            ddown006d.Items.FindByValue(ddown006d.SelectedValue).Selected = false;
            ddown006d.Items.FindByValue(dt.Rows[0][13].ToString()).Selected = true;
        }
        catch
        {
            ddown006d.SelectedIndex = 0;
        }

        parcoll par = new parcoll();

         bool swLrpa = FiltroLRPA();

         if (swLrpa)
         {
             LRPAcoll LRPA = new LRPAcoll();
             ddown007d.Items.Clear();
             DataView dv31 = new DataView(LRPA.GetparSituacionTuicionLRPA(Convert.ToInt32(dt.Rows[0][13].ToString())));
             ddown007d.DataSource = dv31;
             ddown007d.DataTextField = "Descripcion";
             ddown007d.DataValueField = "CodSituacionTuicion";
             dv31.Sort = "Descripcion";
             ddown007d.DataBind();
             ddown007d.Focus();
         }
         else
         {
             ddown007d.Items.Clear();
             DataView dv31 = new DataView(par.GetparSituacionTuicion(Convert.ToInt32(dt.Rows[0][13].ToString())));
             ddown007d.DataSource = dv31;
             ddown007d.DataTextField = "Descripcion";
             ddown007d.DataValueField = "CodSituacionTuicion";
             dv31.Sort = "Descripcion";
             ddown007d.DataBind();
             ddown007d.Focus();
         
         }

         try
         {
             ddown007d.Items.FindByValue(ddown007d.SelectedValue).Selected = false;
             ddown007d.Items.FindByValue(dt.Rows[0][14].ToString()).Selected = true;
         }
         catch
         {
             ddown007d.SelectedIndex = 0;
         }


        imb_001d.Visible = false;
        imb_002d.Visible = true;

        if (SSninoDiag.sexo == "F")
        {
            if (dt.Rows[0][22].ToString() == "True")
            {
                RbtnEmbarazadaSi.Checked = true;
                RbtnEmbarazadaNo.Checked = false;
                trEmbarazadarbtn.Visible = true;
                trEmbarazadaSi.Visible = true;
                txtNumeroSemanasGestacion.Text = dt.Rows[0][23].ToString();

                if (dt.Rows[0][24].ToString() == "True")
                {
                    rbtnEmbarazoAbusoViolacionSi.Checked = true;
                    rbtnEmbarazoAbusoViolacionNo.Checked = false;
                }
                else
                {
                    rbtnEmbarazoAbusoViolacionSi.Checked = false;
                    rbtnEmbarazoAbusoViolacionNo.Checked = true;
                }

            }
        }
        else
        {
            RbtnEmbarazadaSi.Checked = false;
            RbtnEmbarazadaNo.Checked = true;
            trEmbarazadarbtn.Visible = false;
            trEmbarazadaSi.Visible = false;
            txtNumeroSemanasGestacion.Text = "";
            rbtnEmbarazoAbusoViolacionSi.Checked = false;
            rbtnEmbarazoAbusoViolacionNo.Checked = false;
        }

        if (dt.Rows[0][25].ToString() == "True")
        {
            rbtnAdolescentePadreMadreSi.Checked = true;
            rbtnAdolescentePadreMadreNo.Checked = false;
            trPadreMadre.Visible = true;
            txtNumeroHijos.Text = dt.Rows[0][26].ToString();

            if (dt.Rows[0][27].ToString() == "True")
            {
                rbtnHijosViolacionSi.Checked = true;
                rbtnHijosViolacionNo.Checked = false;
            }
            else
            {
                rbtnHijosViolacionSi.Checked = false;
                rbtnHijosViolacionNo.Checked = true;
            }
        }
        else
        {
            rbtnAdolescentePadreMadreSi.Checked = false;
            rbtnAdolescentePadreMadreNo.Checked = true;
            trPadreMadre.Visible = false;
            txtNumeroHijos.Text = "";
            rbtnHijosViolacionSi.Checked = false;
            rbtnHijosViolacionNo.Checked = false;
        }




        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    }

    private bool FiltroLRPA()
    {
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(Convert.ToInt32(SSninoDiag.CodProyecto));

        if (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
        {
            swLrpa = true;
        }
        else
        {
            swLrpa = false;
        }

        return (swLrpa);


        #endregion

    }
    
    
    
    
    
    
    protected void imb_002d_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();
        //if (validate())
        //{

       
        Boolean sw = false;


    


        if (validateSocial() == true && sw == false)
        {
            DateTime fecha;
       //     utab4.Tabs[4].Style.ForeColor = System.Drawing.Color.Black;
            if (txt006d.Text.Trim() == "")
            {
                txt006d.Text = "SIN OBSERVACION";
            }


            if (txt001d.Text.Trim() == "")
            {
                txt001d.Text = "0";
            }
            if (txt002d.Text.Trim() == "")
            {
                txt002d.Text = "0";
            }
            if (txt003d.Text.Trim() == "")
            {
                txt003d.Text = "0";
            }
            if (txt004d.Text.Trim() == "")
            {

                txt004d.Text = "0";
            }
            if (txt005d.Text.Trim() == "")
            {
                txt005d.Text = "0";
            }
            if (txt007d.Text.Trim() == "")
            {
                txt007d.Text = "0";
            }
            if (cal002d.Text.Trim() == "")
            {
                fecha = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                fecha = Convert.ToDateTime(cal002d.Text.Trim());
            }

            if (cal003d.Text == "")
            {
                VFechaFonasa = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaFonasa = Convert.ToDateTime(cal003d.Text);
            }
            
            if (cal004d.Text == "")
            {
                VFechaChileSolidario = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaChileSolidario = Convert.ToDateTime(cal004d.Text);
            }
            
            if (cal005d.Text == "")
            {
                VFechaChileCreceContigo = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaChileCreceContigo = Convert.ToDateTime(cal005d.Text);
            }


            string NumeroSemanasGestacion = "0";
            string NumeroHijos = "0";

            
            if (SSninoDiag.sexo.ToString() == "F")
            {
                if (RbtnEmbarazadaSi.Checked == true)
                {
                    NumeroSemanasGestacion = txtNumeroSemanasGestacion.Text;
                }
                else
                {
                    rbtnEmbarazoAbusoViolacionSi.Checked = false;
                }
            }

            if (rbtnAdolescentePadreMadreSi.Checked == true)
            {
                NumeroHijos = txtNumeroHijos.Text;
            }
            else
            {
                rbtnHijosViolacionSi.Checked = false;
            }


            if (rbtnAdolescentePadreMadreSi.Checked == true)
            {
                NumeroHijos = txtNumeroHijos.Text;
            }
            else
            {
                rbtnHijosViolacionSi.Checked = false;
            }           

            string Mes = ddown004d.SelectedValue;
            string ano = txt001d.Text.Trim();
            string anomes = ano + Mes;

            diagnosticoscoll dcoll2 = new diagnosticoscoll();
            if (chk001d.Checked)
            {
                dcoll2.Update_InsFonasa(SSninoDiag.CodNino);
            }
            else
            {
                dcoll2.Update_noInsFonasa(SSninoDiag.CodNino);
            }

            dcoll2.Update_Etnia(SSninoDiag.CodNino, Convert.ToInt32(ddown009d.SelectedValue));
            dcoll.Update_DiagnosticosSocial(VICodSocial
                , VCod_diagnostico
                , Convert.ToDateTime(cal001d.Text)
                , 10
                , Convert.ToInt32(ddown001d.SelectedValue)
                , Convert.ToInt32(ddown002d.SelectedValue)
                , Convert.ToInt32(ddown005d.SelectedValue)
                , SSninoDiag.CodInst
                , Convert.ToInt32(ddown005d.SelectedValue)
                , Convert.ToInt32(ddown003d.SelectedValue)
                , Convert.ToString(txt006d.Text).ToUpper()
                , Convert.ToInt32(anomes)
                , Convert.ToInt32(txt002d.Text)
                , Convert.ToInt32(txt003d.Text)
                , Convert.ToInt32(txt004d.Text)
                , Convert.ToInt32(txt005d.Text)
                , Convert.ToInt32(txt007d.Text)
                , fecha
                , Convert.ToInt32(ddown007d.SelectedValue)
                , Convert.ToInt32(ddown006d.SelectedValue)
                , 0
                , DateTime.Now
                , Convert.ToInt32(Session["IdUsuario"])
                , Convert.ToInt32(ddown009d.SelectedValue)
                , VFonasa.ToUpper()
                , VChileSolidario.ToUpper()
                , VChileCreceContigo.ToUpper()
                , VFechaFonasa
                , VFechaChileSolidario
                , VFechaChileCreceContigo
                , RbtnEmbarazadaSi.Checked
                , Convert.ToInt32(NumeroSemanasGestacion)
                , rbtnEmbarazoAbusoViolacionSi.Checked
                , rbtnAdolescentePadreMadreSi.Checked
                , Convert.ToInt32(NumeroHijos)
                , rbtnHijosViolacionSi.Checked);


            imb_001d.Visible = true;
            imb_002d.Visible = false;
            clean_form();
            lbl001d.Text = "";
            lbl001da.Visible = false;//gfontbrevis

            CalendarExtende391.StartDate = SSninoDiag.fchingdesde;
            CalendarExtende391.EndDate = DateTime.Now;

            CalendarExtende403.EndDate = DateTime.Now;

            //mostrar_collapse(true);
            //gfontbrevis
            //btnGatillo.Attributes.Add("disabled", "disabled");
            mostrar_collapse(false);
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        }
        else
        {
            mostrar_collapse(true);
            btnGatillo.Attributes.Add("disabled", "disabled");
           // utab4.Tabs[4].Style.ForeColor = System.Drawing.Color.Red;

        }



        DataTable dt4 = dcoll.GetDiagnosticoSocial(SSninoDiag.ICodIE);
        DataView dv4 = new DataView(dt4);
        dv4.Sort = "FechaDiagnostico DESC";
        grd001d.DataSource = dv4;
        grd001d.DataBind();
        grd001d.Visible = true;
        //utab4.Visible = true;



        if (dv4.Count == 0)
        {
            //lbl001d.Text = "Este Niño(a) no Posee Diagnostico Social";
            lbl001da.Visible = true;//gfontbrevis
        }

    }

    # endregion

    # region Historico de Diagnosticos

    protected void imb_004d_Click(object sender, EventArgs e)
    {
        //window.open(this.Page, "ninos_HistoricoDiagnosticoSocial.aspx", 770, 420);
    }

    # endregion

    #region volver

    protected void imb_005d_Click(object sender, EventArgs e)
    {
        //clean_form();

        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");
    }

    
    # endregion

    #region validaciones

    
   
    protected void ddown006d_SelectedIndexChanged(object sender, EventArgs e)
    {
        parcoll par = new parcoll();

        //DropDownList tddown006d = (DropDownList)utab4.FindControl("ddown006d");
        //DropDownList tddown007d = (DropDownList)utab4.FindControl("ddown007d");
        bool swLrpa = FiltroLRPA();

        if (swLrpa)
        {
            LRPAcoll LRPA = new LRPAcoll();
            ddown007d.Items.Clear();
            DataView dv31 = new DataView(LRPA.GetparSituacionTuicionLRPA(Convert.ToInt32(ddown006d.SelectedValue)));
            ddown007d.DataSource = dv31;
            ddown007d.DataTextField = "Descripcion";
            ddown007d.DataValueField = "CodSituacionTuicion";
            dv31.Sort = "Descripcion";
            ddown007d.DataBind();
            //   GridView tgrd001d = (GridView)utab4.FindControl("grd001d");
            //grd001d.Focus();
        }
        else
        {
            //DropDownList tddown006d = (DropDownList)utab4.FindControl("ddown006d");
            //DropDownList tddown007d = (DropDownList)utab4.FindControl("ddown007d");
            ddown007d.Items.Clear();
            DataView dv31 = new DataView(par.GetparSituacionTuicion(Convert.ToInt32(ddown006d.SelectedValue)));
            ddown007d.DataSource = dv31;
            ddown007d.DataTextField = "Descripcion";
            ddown007d.DataValueField = "CodSituacionTuicion";
            dv31.Sort = "Descripcion";
            ddown007d.DataBind();
            //   GridView tgrd001d = (GridView)utab4.FindControl("grd001d");
            //grd001d.Focus();


        }
        //gfontbrevis
        mostrar_collapse(true);
        btnGatillo.Attributes.Add("disabled", "disabled");

        //grd001d.Focus();
        
       
    }




    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        //Label lbl_fechaingresoS = (Label)utab4.FindControl("lbl_fechaS");
        //lbl_fechaingresoS.Text = SSninoDiag.fchingdesde.ToShortDateString();

        //WebDateChooser tcal001d = (TextBox)utab4.FindControl("cal001d");
        //WebDateChooser tcal002d = (TextBox)utab4.FindControl("cal002d");

        VFecha_diagnostico = Convert.ToDateTime("01-01-1900");
        VFechaChileSolidario = Convert.ToDateTime("01-01-1900");
        VFechaChileCreceContigo = Convert.ToDateTime("01-01-1900");

        VFonasa = "NO";
        VChileSolidario = "NO";
        VChileCreceContigo = "NO";
        
        CalendarExtende391.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende391.EndDate = DateTime.Now;


   //     cal002d.MinDate = SSninoDiag.fchingdesde;
        CalendarExtende403.EndDate = DateTime.Now;

        //GridView tgrd001d = (GridView)utab4.FindControl("grd001d");
        //Label tlbl001d = (Label)utab4.FindControl("lbl001d");
        DataTable dt4 = dcoll.GetDiagnosticoSocial(SSninoDiag.ICodIE);
        DataView dv4 = new DataView(dt4);
        dv4.Sort = "FechaDiagnostico DESC";
        grd001d.DataSource = dv4;
        grd001d.DataBind();
        grd001d.Visible = true;
        //utab4.Visible = true;
        if (dv4.Count == 0)
        {
            //lbl001d.Text = "Este Niño(a) no Posee Diagnostico Social";
            lbl001da.Visible = true;//gfontbrevis
        }
        else
        {
            //lbl001d.Text = "";
            lbl001da.Visible = false;//gfontbrevis
        }

        // DropDownList  Diagnostico Social

        //opDownList tddown001d = (DropDownList)utab4.FindControl("ddown001d");
        DataView dv26 = new DataView(par.GetparSituacionesEspeciales());
        ddown001d.Items.Clear();
        ddown001d.DataSource = dv26;
        ddown001d.DataTextField = "Descripcion";
        ddown001d.DataValueField = "CodSituacionEspecial";
        dv26.Sort = "Descripcion";
        ddown001d.DataBind();

        //DropDownList tddown002d = (DropDownList)utab4.FindControl("ddown002d");
        DataView dv27 = new DataView(par.GetparSituacionSocioEconomica());
        ddown002d.Items.Clear();
        ddown002d.DataSource = dv27;
        ddown002d.DataTextField = "Descripcion";
        ddown002d.DataValueField = "CodSituacionSocioEconomica";
        dv27.Sort = "Descripcion";
        ddown002d.DataBind();

        //DropDownList tddown003d = (DropDownList)utab4.FindControl("ddown003d");
        DataView dv28 = new DataView(par.GetparSituacionCalle());
        ddown003d.Items.Clear();
        ddown003d.DataSource = dv28;
        ddown003d.DataTextField = "Descripcion";
        ddown003d.DataValueField = "CodSituacionCalle";
        dv28.Sort = "Descripcion";
        ddown003d.DataBind();

        //DropDownList tddown005d = (DropDownList)utab4.FindControl("ddown005d");
        DataView dv29 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
        ddown005d.Items.Clear();
        ddown005d.DataSource = dv29;
        ddown005d.DataTextField = "NombreCompleto";
        ddown005d.DataValueField = "ICodTrabajador";
        dv29.Sort = "NombreCompleto";
        ddown005d.DataBind();

        DataView dv31 = new DataView(par.GetparEtnias());


        ddown009d.Items.Clear();
        ddown009d.DataSource = dv31;
        ddown009d.DataTextField = "Descripcion";
        ddown009d.DataValueField = "CodEtnia";
        dv31.Sort = "Descripcion";
        ddown009d.DataBind();

        //DropDownList tddown006d = (DropDownList)utab4.FindControl("ddown006d");
         bool swLrpa = FiltroLRPA();

         if (swLrpa)
         {

             LRPAcoll LRPA = new LRPAcoll();
             DataView dv30 = new DataView(LRPA.GetparEstadoAbandonoLRPA());
             ddown006d.Items.Clear();
             ddown006d.DataSource = dv30;
             ddown006d.DataTextField = "Descripcion";
             ddown006d.DataValueField = "CodEstadoAbandono";
             dv30.Sort = "Descripcion";
             ddown006d.DataBind();

         }
         else
         {
             DataView dv30 = new DataView(par.GetparEstadoAbandono());
             ddown006d.Items.Clear();
             ddown006d.DataSource = dv30;
             ddown006d.DataTextField = "Descripcion";
             ddown006d.DataValueField = "CodEstadoAbandono";
             dv30.Sort = "Descripcion";
             ddown006d.DataBind();
         }

        SqlTransaction sqlt;
               
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {

        nino n = ncoll.GetDataTransactional(sqlt, SSninoDiag.CodNino.ToString(), "0");
        string sexo = n.sexo;
        if (SSninoDiag != null)
        {
            SSninoDiag.sexo = n.sexo;
        }

        if (sexo == "M")
        {
            trEmbarazadarbtn.Visible = false;
            pMaternidad.Visible = false;
            thAdolescenteMadre.Visible = false;
            pPaternidad.Visible = true;
            thAdolescentePadre.Visible = true;
        }
        else
        {
            trEmbarazadarbtn.Visible = true;
            pMaternidad.Visible = true;
            thAdolescenteMadre.Visible = true;
            pPaternidad.Visible = false;
            thAdolescentePadre.Visible = false;
        }

        sqlt.Commit();
        sconn.Close(); 
        }
        catch (Exception ex)
        {
            // Handle the exception if the transaction fails to commit.            
            Console.WriteLine(ex.Message);

            try
            {
                // Attempt to roll back the transaction.
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                // Throws an InvalidOperationException if the connection 
                // is closed or the transaction has already been rolled 
                // back on the server.                
                Console.WriteLine(exRollback.Message);
            }
        }

        // Datos niño
        DataTable dtNino = ncoll.SQL_NinoII(ninocoll.querytype.inproyect, "", "", "", SSninoDiag.CodNino.ToString(), "", "", "", "");
        IFechaNac = Convert.ToDateTime(dtNino.Rows[0]["FechadeNacimiento"]);         
       
    }

    #endregion

    # region Limpia Formulario

    protected void imb_003d_Click(object sender, EventArgs e)
    {

        clean_form();
        imb_002d.Visible = false;
        imb_001d.Visible = true;

        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    }

    private void clean_form()
    {
        ddown001d.SelectedValue = "0";
        ddown002d.SelectedValue = "0";
        ddown003d.SelectedValue = "0";
        ddown004d.SelectedValue = "0";
        ddown005d.SelectedValue = "0";
        ddown006d.SelectedValue = "0";
        ddown007d.SelectedValue = "0";
        ddown009d.SelectedValue = "0";

        ddown001d.BackColor = System.Drawing.Color.Empty;
        ddown006d.BackColor = System.Drawing.Color.Empty;
        ddown007d.BackColor = System.Drawing.Color.Empty;
        ddown009d.BackColor = System.Drawing.Color.Empty;
        ddown005d.BackColor = System.Drawing.Color.Empty;
       
        txt001d.Text = "";
        txt002d.Text = "";
        txt003d.Text = "";
        txt004d.Text = "";
        txt005d.Text = "";
        txt006d.Text = "";
        txt007d.Text = "";

        
        cal001d.Text = "";
        cal002d.Text = "";
        cal003d.Text = "";
        cal004d.Text = "";
        cal005d.Text = "";
        cal003d.BackColor = System.Drawing.Color.Empty;
        cal004d.BackColor = System.Drawing.Color.Empty;
        cal005d.BackColor = System.Drawing.Color.Empty;


        chk001d.Checked = false;
        chk002d.Checked = false;
        chk003d.Checked = false;


        RbtnEmbarazadaSi.Checked = false;
        RbtnEmbarazadaNo.Checked = true;
        trEmbarazadaSi.Visible = false;
        txtNumeroSemanasGestacion.Text = "";
        rbtnEmbarazoAbusoViolacionSi.Checked = false;
        rbtnEmbarazoAbusoViolacionNo.Checked = false;
        rbtnAdolescentePadreMadreSi.Checked = false;
        rbtnAdolescentePadreMadreNo.Checked = true;
        trPadreMadre.Visible = false;
        txtNumeroHijos.Text = "";
        rbtnHijosViolacionSi.Checked = false;
        rbtnHijosViolacionSi.Checked = false;

    }

    # endregion

    #region Funciones del Formulario

    private bool validateSocial()
    {

        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (chk001d.Checked)
        {
            if (cal003d.Text == "")
            {
                cal003d.BackColor = colorCampoObligatorio;
                n = false;
            }
            else 
            {
                VFechaFonasa = Convert.ToDateTime(cal003d.Text);
                cal003d.BackColor = System.Drawing.Color.Empty;

            }
        }
        else
        {
            VFechaFonasa = Convert.ToDateTime("01-01-1900");
            cal003d.BackColor = System.Drawing.Color.Empty;
        }


        if (chk002d.Checked)
        {
            if (cal004d.Text == "")
            {
                //cal004d.BackColor = colorCampoObligatorio;
                //n = false;
                VFechaFonasa = Convert.ToDateTime("01-01-1900");

            }
            else
            {
                VFechaFonasa = Convert.ToDateTime(cal004d.Text);
                cal004d.BackColor = System.Drawing.Color.Empty;

            }
        }
        else
        {
            VFechaFonasa = Convert.ToDateTime("01-01-1900");
            cal004d.BackColor = System.Drawing.Color.Empty;
        }


        if (chk003d.Checked)
        {
            if (cal005d.Text == "")
            {
                //cal005d.BackColor = colorCampoObligatorio;
                //n = false;
                VFechaFonasa = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                VFechaFonasa = Convert.ToDateTime(cal005d.Text);
                cal005d.BackColor = System.Drawing.Color.Empty;

            }
        }
        else
        {
            VFechaFonasa = Convert.ToDateTime("01-01-1900");
            cal005d.BackColor = System.Drawing.Color.Empty;
        }        
        
        
        
        
        //  WebDateChooser tcal001d = (TextBox)utab4.FindControl("cal001d");
        if (cal001d.Text == "")
        {

            cal001d.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001d.BackColor = System.Drawing.Color.Empty;

        }



      //  DropDownList tddown001d = (DropDownList)utab4.FindControl("ddown001d");
        if (Convert.ToInt32(ddown001d.SelectedValue) == 0)
        {
            ddown001d.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001d.BackColor = System.Drawing.Color.Empty;

        }

      //  DropDownList tddown005d = (DropDownList)utab4.FindControl("ddown005d");
        if (Convert.ToInt32(ddown005d.SelectedValue) == 0)
        {
            ddown005d.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown005d.BackColor = System.Drawing.Color.Empty;

        }

        //DropDownList tddown006d = (DropDownList)utab4.FindControl("ddown006d");
        if (Convert.ToInt32(ddown006d.SelectedValue) == 0)
        {
            ddown006d.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown006d.BackColor = System.Drawing.Color.Empty;
 
        }

        //DropDownList tddown007d = (DropDownList)utab4.FindControl("ddown007d");
        if (ddown007d.SelectedValue == "0" || ddown007d.SelectedValue == "")
        {  
            ddown007d.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown007d.BackColor = System.Drawing.Color.Empty;

        }
       // DropDownList tddown008d = (DropDownList)utab4.FindControl("ddown007d");
        if (ddown009d.SelectedValue == "0" || ddown007d.SelectedValue == "")
        {
              ddown009d.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
             ddown009d.BackColor = System.Drawing.Color.Empty;

        }

        if (SSninoDiag != null)
        {
            if (SSninoDiag.sexo.ToString() == "F")
            {
                if (RbtnEmbarazadaSi.Checked == true)
                {
                    if (txtNumeroSemanasGestacion.Text == "" || txtNumeroSemanasGestacion.Text == "0" || txtNumeroSemanasGestacion.Text == "00")
                    {
                        txtNumeroSemanasGestacion.BackColor = colorCampoObligatorio;
                        n = false;
                    }
                    else
                    {
                        txtNumeroSemanasGestacion.BackColor = System.Drawing.Color.Empty;
                    }
                    if (rbtnEmbarazoAbusoViolacionSi.Checked == false && rbtnEmbarazoAbusoViolacionNo.Checked == false)
                    {
                        rbtnEmbarazoAbusoViolacionSi.BackColor = colorCampoObligatorio;
                        rbtnEmbarazoAbusoViolacionNo.BackColor = colorCampoObligatorio;
                        n = false;
                    }
                    else
                    {
                        rbtnEmbarazoAbusoViolacionSi.BackColor = System.Drawing.Color.Empty;
                        rbtnEmbarazoAbusoViolacionNo.BackColor = System.Drawing.Color.Empty;
                    }
                }
            }
        }

        if (rbtnAdolescentePadreMadreSi.Checked == true)
        {
            if (txtNumeroHijos.Text == "" || txtNumeroHijos.Text == "0" || txtNumeroHijos.Text == "00")
            {
                txtNumeroHijos.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                txtNumeroHijos.BackColor = System.Drawing.Color.Empty;
            }

            if (rbtnHijosViolacionSi.Checked == false && rbtnHijosViolacionNo.Checked == false)
            {
                rbtnHijosViolacionSi.BackColor = colorCampoObligatorio;
                rbtnHijosViolacionNo.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                rbtnHijosViolacionSi.BackColor = System.Drawing.Color.Empty;
                rbtnHijosViolacionNo.BackColor = System.Drawing.Color.Empty;
            }
        }



        return n;



    }


    #endregion









    protected void ddown008d_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chk001d_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        if (chk001d.Checked)
        {
            cal003d.Enabled = true;
            VFonasa = "SI";
        }
        else 
        {
            cal003d.Enabled = false;
            cal003d.Text = "";
            VFonasa = "NO";
            
        }

        VFechaFonasa = Convert.ToDateTime("01-01-1900");
    }
    protected void chk002d_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
       
        if (chk002d.Checked)
        {
            cal004d.Enabled = true;
            VChileSolidario = "SI";           
        }
        else
        {
            cal004d.Enabled = false;
            cal004d.Text = "";
            VChileSolidario = "NO";
        }
        VFechaChileSolidario = Convert.ToDateTime("01-01-1900");
    }
    protected void chk003d_CheckedChanged(object sender, EventArgs e)
    {
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        if (chk003d.Checked)
        {
            cal005d.Enabled = true;
            VChileCreceContigo = "SI";
        }
        else
        {
            cal005d.Enabled = false;
            cal005d.Text = "";
            VChileCreceContigo = "NO";
        }
        VFechaChileCreceContigo = Convert.ToDateTime("01-01-1900");
    }
    protected void cal003d_ValueChanged(object sender, EventArgs e)
    {
        VFechaFonasa = Convert.ToDateTime(cal003d.Text);
        //grd001d.Focus();
    }
    protected void cal004d_ValueChanged(object sender, EventArgs e)
    {
       VFechaChileSolidario = Convert.ToDateTime(cal004d.Text);
        //grd001d.Focus();
    }
    protected void cal005d_ValueChanged(object sender, EventArgs e)
    {
       VFechaChileCreceContigo = Convert.ToDateTime(cal005d.Text);
        //grd001d.Focus();
    }

    protected void rv_año_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("yyyy");
        ((RangeValidator)sender).MinimumValue = "1900";

    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        //((RangeValidator)sender).MinimumValue = DateTime.Today.AddYears(-100).ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

        

    }



    
    protected void txt001d_TextChanged(object sender, EventArgs e)
    {
        if (txt001d.Text != "")
        {
            if (Convert.ToInt32(txt001d.Text.Trim()) > DateTime.Now.Year)
            {
                txt001d.Text = Convert.ToString(DateTime.Now.Year);

            }
            if (Convert.ToInt32(txt001d.Text.Trim()) < DateTime.Now.Year - 100)
            {
                txt001d.Text = Convert.ToString(DateTime.Now.Year - 100);
            }
        }

        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
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
    protected void RbtnEmbarazadaSi_CheckedChanged(object sender, EventArgs e)
    {
        if (RbtnEmbarazadaSi.Checked == true)
        {
            trEmbarazadaSi.Visible = true;

        }
        else
        {
            trEmbarazadaSi.Visible = false;
        }
        mostrar_collapse(true);
    }
    protected void RbtnEmbarazadaNo_CheckedChanged(object sender, EventArgs e)
    {
        if (RbtnEmbarazadaNo.Checked == true)
        {
            trEmbarazadaSi.Visible = false;

            txtNumeroSemanasGestacion.Text = "";
            rbtnEmbarazoAbusoViolacionSi.Checked = false;
            rbtnEmbarazoAbusoViolacionNo.Checked = false;
        }
        else
        {
            trEmbarazadaSi.Visible = true;
        }
        mostrar_collapse(true);
    }
    protected void rbtnAdolescentePadreMadreSi_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnAdolescentePadreMadreSi.Checked == true)
        {
            trPadreMadre.Visible = true;

        }
        else
        {
            trPadreMadre.Visible = false;
        }
        mostrar_collapse(true);
    }
    protected void rbtnAdolescentePadreMadreNo_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnAdolescentePadreMadreNo.Checked == true)
        {
            trPadreMadre.Visible = false;

            txtNumeroHijos.Text = "";
            rbtnHijosViolacionSi.Checked = false;
            rbtnHijosViolacionNo.Checked = false;
        }
        else
        {
            trPadreMadre.Visible = true;
        }
        mostrar_collapse(true);
    }
    protected void ddown001d_SelectedIndexChanged(object sender, EventArgs e)
    {
        TimeSpan difFecha = DateTime.Now - IFechaNac;
        lblFechaNac.Text = IFechaNac.ToString("dd-MM-yyyy");

        mostrar_collapse(true);

        if (difFecha.TotalDays < 4380 && (ddown001d.SelectedValue == "2" || ddown001d.SelectedValue == "3" || ddown001d.SelectedValue == "4" || ddown001d.SelectedValue == "12")) 
            //Si el NNA tiene menos de 12 años de edad, y presenta embarazo o matrimonio
            alertaEditar.Visible = true;
        else
            alertaEditar.Visible = false;
    }
}
