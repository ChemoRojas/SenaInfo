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

public partial class mod_ninos_CapacitacionNino : System.Web.UI.Page
{

    # region nino SSninoDiag
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
    # endregion

    #region ViewState
    public int VICodCapacitacionNino
    {
        get
        {
            if (ViewState["VICodCapacitacionNino"] == null)
            { ViewState["VICodCapacitacionNino"] = -1; }
            return Convert.ToInt32(ViewState["VICodCapacitacionNino"]);
        }
        set { ViewState["VICodCapacitacionNino"] = value; }
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
    //public DateTime VFecha_diagnostico
    //{
    //    get
    //    {
    //        if (ViewState["Fecha_diagnostico"] == null)
    //        { ViewState["Fecha_diagnostico"] = -1; }
    //        return Convert.ToDateTime(ViewState["Fecha_diagnostico"]);
    //    }
    //    set { ViewState["Fecha_diagnostico"] = value; }
    //}
    //public int VICodPsicologico
    //{
    //    get
    //    {
    //        if (ViewState["VICodPsicologico"] == null)
    //        { ViewState["VICodPsicologico"] = -1; }
    //        return Convert.ToInt32(ViewState["VICodPsicologico"]);
    //    }
    //    set { ViewState["VICodPsicologico"] = value; }
    //}

    # endregion

    # region Page_load
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
                imb_002e.Visible = false;
                //btnGatilloCancelar.Style.Add("display", "none");//gfontbrevis
                validatescurity();
            }
             #endregion
        }
        # endregion
    }
    # endregion

    # region validatesecurity
    private void validatescurity()
    {
        #region Validacion


        //357AB123-05D6-4F6F-93E9-C8007A403079 2.3_MODIFICAR
        if (!window.existetoken("357AB123-05D6-4F6F-93E9-C8007A403079"))
        {
            imb_002e.Visible = false;
            grd001e.Columns[8].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            imb_001e.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            imb_004e.Visible = false;
        }

        #endregion
    }
    #endregion

    # region inserta diagnostico

    protected void imb_001e_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

           


        if (validateCapacitacion() == true)
        {

            DateTime fecha;
          // utab4.Tabs[5].Style.ForeColor = System.Drawing.Color.Black;
            if (txt002e.Text.Trim() == "")
            {
                txt002e.Text = "SIN OBSERVACION";
            }
            if (cal002e.Text == null)
            {
                cal002e.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
            }

            if (txt001e.Text.Trim() == "")
            {
                txt001e.Text = "0";
            }



            if (cal002e.Text == "")
            {
                fecha = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                fecha = Convert.ToDateTime(cal002e.Text);
            }



            int inden = ncoll.Insert_DiagnosticoGeneral(6, SSninoDiag.CodNino,
                SSninoDiag.ICodIE, Convert.ToDateTime(cal001e.Text));

            dcoll.Insert_CapacitacionNino(inden
            , Convert.ToInt32(ddown002e.SelectedValue)
            , Convert.ToInt32(ddown001e.SelectedValue)
            , Convert.ToInt32(ddown004e.SelectedValue)
            , Convert.ToInt32(ddown003e.SelectedValue)
            , Convert.ToString(txt002e.Text.Trim()).ToUpper()
            , Convert.ToInt32(txt001e.Text.Trim())
            , Convert.ToDateTime(cal001e.Text)
            , fecha
            , Convert.ToString(ddown005e.SelectedValue)
            , DateTime.Now
            , Convert.ToInt32(Session["IdUsuario"]));

            clean_form();
            mostrar_collapse(false);
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        }
        else
        {
           // utab4.Tabs[5].Style.ForeColor = System.Drawing.Color.Red;
          mostrar_collapse(true);
          //gfontbrevis
          btnGatillo.Attributes.Add("disabled", "disabled");
          //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
          //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        }

        //GridView tgrd001e = (GridView)utab4.FindControl("grd001e");
        DataTable dt5 = dcoll.GetDiagnosticoCapacitacion(SSninoDiag.ICodIE);
        //Label tlbl001e = (Label)utab4.FindControl("lbl001e");
        DataView dv5 = new DataView(dt5);
        dv5.Sort = "FechaDiagnostico DESC";
        grd001e.DataSource = dv5;
        grd001e.DataBind();
        grd001e.Visible = true;
        //utab4.Visible = true;



        if (dv5.Count == 0)
        {
            //lbl001e.Text = "Este Niño(a) no Posee Diagnostico de Capacitación";
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            //lbl001e.Text = "";
            lbl_nota2.Visible = false;//gfontbrevis
        }



        //grd001e.Focus();
    }
    
    # endregion

    # region ActualizaDiagnostico

   
    protected void grd001e_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        diagnosticoscoll dcoll = new diagnosticoscoll();


        string ICodCapacitacionNino = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VICodCapacitacionNino = Convert.ToInt32(ICodCapacitacionNino);

        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        DataTable dt = dcoll.GetDiagnosticoCapacitacionMostrar(VCod_diagnostico);

        try
        {
            ddown001e.Items.FindByValue(ddown001e.SelectedValue).Selected = false;
            ddown001e.Items.FindByValue(dt.Rows[0][0].ToString()).Selected = true;
        }
        catch
        {
            ddown001e.SelectedIndex = 0;
        }

        try
        {
            ddown002e.Items.FindByValue(ddown002e.SelectedValue).Selected = false;
            ddown002e.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;
        }
        catch
        {
            ddown002e.SelectedIndex = 0;
        }


        try
        {
            ddown003e.Items.FindByValue(ddown003e.SelectedValue).Selected = false;
            ddown003e.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;
        }
        catch
        {
            ddown003e.SelectedIndex = 0;
        }

        try
        {
            ddown004e.Items.FindByValue(ddown004e.SelectedValue).Selected = false;
            ddown004e.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;
        }
        catch
        {
            ddown004e.SelectedIndex = 0;
        }

            ddown005e.Items.FindByValue(ddown005e.SelectedValue).Selected = false;
            ddown005e.Items.FindByValue(dt.Rows[0][7].ToString()).Selected = true;

        cal001e.Text = Convert.ToDateTime(dt.Rows[0][4].ToString()).ToShortDateString();
        
        txt001e.Text = dt.Rows[0][5].ToString();

        txt002e.Text = Convert.ToString(dt.Rows[0][6]);

        

        if (Convert.ToString(dt.Rows[0][8]).ToString() == "-")
        {
            cal002e.Text = "";
        }
        else
        {
            cal002e.Text = Convert.ToDateTime(dt.Rows[0][8].ToString()).ToShortDateString();
            
        }




        imb_001e.Visible = false;
        imb_002e.Visible = true;


        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }


    protected void imb_002e_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

      

        if (validateCapacitacionM() == true)
        {


      //      utab4.Tabs[5].Style.ForeColor = System.Drawing.Color.Black;
            if (txt002e.Text == null)
            {
                txt002e.Text = "SIN OBSERVACION";
            }

            if (cal002e.Text.Trim() == "")
            {
                cal002e.Text = "01-01-1900";
            }
            if (txt001e.Text.Trim() == "")
            {
                txt001e.Text = "0";
            }

            dcoll.Update_CapacitacionNino(VICodCapacitacionNino, VCod_diagnostico, Convert.ToInt32(ddown002e.SelectedValue),
            Convert.ToInt32(ddown001e.SelectedValue), Convert.ToInt32(ddown004e.SelectedValue),
            Convert.ToInt32(ddown003e.SelectedValue), Convert.ToString(txt002e.Text).ToUpper(), Convert.ToInt32(txt001e.Text),
            Convert.ToDateTime(cal001e.Text), Convert.ToDateTime(cal002e.Text),
            Convert.ToString(ddown005e.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));


          

            imb_001e.Visible = true;
            imb_002e.Visible = false;

            clean_form();
            mostrar_collapse(false);
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        }
        else
        {
           // utab4.Tabs[5].Style.ForeColor = System.Drawing.Color.Red;
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
        }

      //  GridView tgrd001e = (GridView)utab4.FindControl("grd001e");
        DataTable dt5 = dcoll.GetDiagnosticoCapacitacion(SSninoDiag.ICodIE);
      //  Label tlbl001e = (Label)utab4.FindControl("lbl001e");
        DataView dv5 = new DataView(dt5);
        dv5.Sort = "FechaDiagnostico DESC";
        grd001e.DataSource = dv5;
        grd001e.DataBind();
        grd001e.Visible = true;
        //utab4.Visible = true;



        if (dv5.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis
        }



        //grd001e.Focus();


    }



    # endregion

    # region Historico de Diagnosticos
    //FGLL se reemplazo por el fancybox
    //protected void imb_004e_Click(object sender, EventArgs e)
    //{
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'ninos_HistoricoDiagnosticoCapacitacion.aspx', '770', '420')";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
  
    # endregion
    
    #region volver

    protected void imb_005e_Click(object sender, EventArgs e)
    {
        //clean_form();

        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");
    }
    
    
    # endregion

    #region validaciones


    protected void ddown005e_SelectedIndexChanged(object sender, EventArgs e)
    {
        //WebDateChooser tcal002e = (TextBox)utab4.FindControl("cal002e");

        //GridView tgrd001e = (GridView)utab4.FindControl("grd001e");
      mostrar_collapse(true);
      //gfontbrevis
      btnGatillo.Attributes.Add("disabled", "disabled");
      //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
      //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }





    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();


      //  Label lbl_fechaingresoCapa = (Label)utab4.FindControl("lbl_fechaCapa");
        //lbl_fechaingresoCapa.Text = SSninoDiag.fchingdesde.ToShortDateString();

        //cal001e.MinDate = SSninoDiag.fchingdesde;
        //cal001e.MaxDate = DateTime.Now;
        CalendarExtende353.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende353.EndDate = DateTime.Now;

        //cal002e.MinDate = SSninoDiag.fchingdesde;
        //cal002e.MaxDate = DateTime.Now;
        CalendarExtende366.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende366.EndDate = DateTime.Now;

        DataTable dt5 = dcoll.GetDiagnosticoCapacitacion(SSninoDiag.ICodIE);
        DataView dv5 = new DataView(dt5);
        dv5.Sort = "FechaDiagnostico DESC";
        grd001e.DataSource = dv5;
        grd001e.DataBind();
        grd001e.Visible = true;

        if (dv5.Count == 0)
        {
            //lbl001e.Text = "Este Niño(a) no Posee Diagnostico de Capacitación";
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            //lbl001e.Text = "";
            lbl_nota2.Visible = false;//gfontbrevis
        }



        DataView dv32 = new DataView(par.GetparTipoCapacitacion());
        ddown001e.Items.Clear();
        ddown001e.DataSource = dv32;
        ddown001e.DataTextField = "Descripcion";
        ddown001e.DataValueField = "TipoCapacitacion";
        dv32.Sort = "Descripcion";
        ddown001e.DataBind();

        DataView dv33 = new DataView(par.GetparAreaCapacitacion());
        ddown002e.Items.Clear();
        ddown002e.DataSource = dv33;
        ddown002e.DataTextField = "Descripcion";
        ddown002e.DataValueField = "CodAreaCapacitacion";
        dv33.Sort = "Descripcion";
        ddown002e.DataBind();

        DataView dv34 = new DataView(par.GetparOrganismoCapacitador());
        ddown003e.Items.Clear();
        ddown003e.DataSource = dv34;
        ddown003e.DataTextField = "Nombre";
        ddown003e.DataValueField = "CodOrganismoCapacitador";
        dv34.Sort = "Nombre";
        ddown003e.DataBind();

        DataView dv35 = new DataView(par.GetparEstadoCapacitacion());
        ddown004e.Items.Clear();
        ddown004e.DataSource = dv35;
        ddown004e.DataTextField = "Descripcion";
        ddown004e.DataValueField = "CodEstadoCapacitacion";
        dv35.Sort = "Descripcion";
        ddown004e.DataBind();


        

    }

    #endregion

    # region Limpia Formulario


    protected void imb_003e_Click(object sender, EventArgs e)
    {
        clean_form();
        imb_002e.Visible = false;
        imb_001e.Visible = true;
        //grd001e.Focus();
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }

  
    private void clean_form()
    {
        ddown001e.SelectedValue = "0";
        ddown002e.SelectedValue = "0";
        ddown003e.SelectedValue = "0";
        ddown004e.SelectedValue = "0";
        ddown005e.SelectedValue = "0";

        txt001e.Text = "";
        txt002e.Text = "";

        cal001e.Text = "";
        cal002e.Text = "";


        cal001e.BackColor = System.Drawing.Color.Empty;
        ddown001e.BackColor = System.Drawing.Color.Empty;
        ddown002e.BackColor = System.Drawing.Color.Empty;
        ddown003e.BackColor = System.Drawing.Color.Empty;
        ddown004e.BackColor = System.Drawing.Color.Empty;


    }

    # endregion

    #region Funciones del Formulario

    private bool validateCapacitacion()
    {

        bool n = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (cal001e.Text == "")
        {

            cal001e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001e.BackColor = System.Drawing.Color.White;

        }



        if (Convert.ToInt32(ddown001e.SelectedValue) == 0)
        {
            ddown001e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001e.BackColor = System.Drawing.Color.White;

        }


        if (Convert.ToInt32(ddown002e.SelectedValue) == 0)
        {
            ddown002e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002e.BackColor = System.Drawing.Color.White;

        }


        if (Convert.ToInt32(ddown003e.SelectedValue) == 0)
        {
            ddown003e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003e.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToInt32(ddown004e.SelectedValue) == 0)
        {
            ddown004e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown004e.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToString(ddown005e.SelectedValue) == Convert.ToString(0))
        {

            ddown005e.BackColor = System.Drawing.Color.White;


        }
        else
        {




            if (cal002e.Text == "")
            {

                cal002e.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                cal002e.BackColor = System.Drawing.Color.White;

            }

        }



        return n;

    }


    private bool validateCapacitacionM()
    {

        bool n = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (cal001e.Text == "")
        {

            cal001e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001e.BackColor = System.Drawing.Color.White;

        }



        if (Convert.ToInt32(ddown001e.SelectedValue) == 0)
        {
            ddown001e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001e.BackColor = System.Drawing.Color.White;

        }


        if (Convert.ToInt32(ddown002e.SelectedValue) == 0)
        {
            ddown002e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002e.BackColor = System.Drawing.Color.White;

        }


        if (Convert.ToInt32(ddown003e.SelectedValue) == 0)
        {
            ddown003e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003e.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToInt32(ddown004e.SelectedValue) == 0)
        {
            ddown004e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown004e.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToString(ddown005e.SelectedValue) == Convert.ToString(0))
        {

            ddown005e.BackColor = colorCampoObligatorio;
            n = false;


        }
        else
        {
            ddown005e.BackColor = System.Drawing.Color.White;

        }
        if (cal002e.Text == "")
        {
            cal002e.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal002e.BackColor = System.Drawing.Color.White;

        }




        return n;

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


    protected void cal001e_TextChanged(object sender, EventArgs e)
    {
        if (cal001e.Text != "")
        {
            RangeValidator1.Validate();
            if (RangeValidator1.IsValid)
            {
                if (cal002e.Text != "")
                {
                    RangeValidator2.MinimumValue = cal001e.Text;
                    RangeValidator2.MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
                    RangeValidator2.Validate();
                }
            }
        }
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }
    protected void cal002e_TextChanged(object sender, EventArgs e)
    {
        if (cal001e.Text == "")
        {
            RangeValidator2.MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
            RangeValidator2.MinimumValue = DateTime.Today.AddYears(-100).ToString("dd-MM-yyyy");
        }

        if (cal002e.Text != "")
        {
            RangeValidator2.Validate();
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
}
