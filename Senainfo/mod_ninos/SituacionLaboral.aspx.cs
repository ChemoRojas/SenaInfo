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

public partial class mod_ninos_SituacionLaboral : System.Web.UI.Page
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
    public int IcodSituacionLaboral
    {
        get
        {
            if (ViewState["IcodSituacionLaboral"] == null)
            { ViewState["IcodSituacionLaboral"] = -1; }
            return Convert.ToInt32(ViewState["IcodSituacionLaboral"]);
        }
        set { ViewState["IcodSituacionLaboral"] = value; }
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
    

    # endregion




    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial

        RangeValidator1.Validate();
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
                imb_002f.Visible = false;
                //btnGatilloCancelar.Style.Add("display", "none");
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
            imb_002f.Visible = false;
            grd001f.Columns[5].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            imb_001f.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            imb_004f.Visible = false;
        }

        #endregion
    }
    # region inserta diagnostico

    protected void imb_001f_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();


        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);

        if (validateLaboral() == true)
        {
            if (txt001f.Text.Trim() == "")
            {
                txt001f.Text = "SIN OBSERVACION";
            }
            if (txt002f.Text.Trim() == "")
            {
                txt002f.Text = Convert.ToString(0);
            }
            if (txt003f.Text.Trim() == "")
            {
                txt003f.Text = Convert.ToString(0);
            }
            if (txt004f.Text.Trim() == "")
            {
                txt004f.Text = Convert.ToString(0);
            }
            if (txt005f.Text.Trim() == "")
            {
                txt005f.Text = Convert.ToString(0);
            }
            
            
            int inden = ncoll.Insert_DiagnosticoGeneral(7, SSninoDiag.CodNino,
                SSninoDiag.ICodIE, Convert.ToDateTime(cal_001f.Text));

            dcoll.Insert_SituacionLaboralNino(/*Convert.ToInt32(ddown002.SelectedValue),*/inden,
            Convert.ToDateTime(cal_001f.Text), Convert.ToInt32(ddown001f.SelectedValue),
            Convert.ToInt32(ddown002f.SelectedValue), Convert.ToString(txt001f.Text).ToUpper(), Convert.ToString(txt003f.Text),
            Convert.ToString(txt004f.Text).ToUpper(), Convert.ToInt32(txt002f.Text), Convert.ToString(txt005f.Text).ToUpper(),
            DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(chk001OcupacionLaboral.Checked));
            
            clean_form();
            //gfontbrevis
            mostrar_collapse(false);
            btnGatillo.Attributes.Remove("disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowAgregar", "$('#btnGatillo').show();$('#btnGatilloCancelar').hide();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);
        }
        else
        {
           // utab4.Tabs[6].Style.ForeColor = System.Drawing.Color.Red;
            //gfontbrevis
            mostrar_collapse(true);
            btnGatillo.Attributes.Add("disabled", "disabled");
        }

        //    }

       //GridView tgrd001f = (GridView)utab4.FindControl("grd001f");

        DataTable dt6 = dcoll.GetSituacionLaboral(SSninoDiag.ICodIE);
        DataView dv6 = new DataView(dt6);
        dv6.Sort = "FechaSituacionLaboral DESC";
        grd001f.DataSource = dv6;
        grd001f.DataBind();
        grd001f.Visible = true;
        grd001f.Visible = true;
        //utab4.Visible = true;



        if (dv6.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis
        }



        grd001f.Focus();

    }

    # endregion

    # region ActualizaDiagnostico

    protected void grd001f_RowCommand(object sender, GridViewCommandEventArgs e)
    {     

        diagnosticoscoll dcoll = new diagnosticoscoll();


        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
        VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);

        string IcodSitLaboral = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

        IcodSituacionLaboral = Convert.ToInt32(IcodSitLaboral);

        DataTable dt = dcoll.GetDiagnosticoSituacionLaboral(IcodSituacionLaboral);



        cal_001f.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToShortDateString();


        try
        {
            ddown001f.Items.FindByValue(ddown001f.SelectedValue).Selected = false;
            ddown001f.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;
        }
        catch
        {
            ddown001f.SelectedIndex = 0;
        }

        try
        {
            ddown002f.Items.FindByValue(ddown002f.SelectedValue).Selected = false;
            ddown002f.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;
        }
        catch
        {
            ddown002f.SelectedIndex = 0;
        }


        if (dt.Rows[0][3].ToString() == Convert.ToString(0))
        {
            txt001f.Text = "";
        }
        else
        {

            txt001f.Text = Convert.ToString(dt.Rows[0][3]);
        }



        if (dt.Rows[0][4].ToString() == Convert.ToString(0))
        {
            txt001f.Text = "";
        }
        else
        {

            txt002f.Text = Convert.ToString(dt.Rows[0][4]);
        }


        if (dt.Rows[0][5].ToString() == Convert.ToString(0))
        {
            txt001f.Text = "";
        }
        else
        {
            txt003f.Text = Convert.ToString(dt.Rows[0][5]);
        }


        if (dt.Rows[0][6].ToString() == Convert.ToString(0))
        {
            txt001f.Text = "";
        }
        else
        {
            txt004f.Text = Convert.ToString(dt.Rows[0][6]);
        }


        if (dt.Rows[0][7].ToString() == Convert.ToString(0))
        {
            txt001f.Text = "";
        }
        else
        {
            txt005f.Text = Convert.ToString(dt.Rows[0][7]);
        }


        try
        {
            if (Convert.ToInt32(dt.Rows[0][8]) == 1)
            {
                chk001OcupacionLaboral.Checked = true;
            }
            else
            {
                chk001OcupacionLaboral.Checked = false;
            }
        }
        catch { }

        
        imb_001f.Visible = false;
        imb_002f.Visible = true;

        //GridView tgrd001h = (GridView)utab4.FindControl("grd001h");
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }

    

    protected void  imb_002f_Click(object sender, EventArgs e)
    {
    ninocoll ncoll = new ninocoll();
    diagnosticoscoll dcoll = new diagnosticoscoll();



    
    if (validateLaboral() == true)
    {
    //    utab4.Tabs[6].Style.ForeColor = System.Drawing.Color.Black;
        if (txt001f.Text.Trim() == "")
        {
            txt001f.Text = "SIN OBSERVACION";
        }
        if (txt002f.Text.Trim() == "")
        {
            txt002f.Text = Convert.ToString(0);
        }
        if (txt003f.Text.Trim() == "")
        {
            txt003f.Text = Convert.ToString(0);
        }
        if (txt004f.Text.Trim() == "")
        {
            txt004f.Text = "NN";
        }
        if (txt005f.Text.Trim() == "")
        {
            txt005f.Text = "NN@NN.cl";
        }


        dcoll.Update_SituacionLaboralNino(IcodSituacionLaboral, VCod_diagnostico,
        Convert.ToDateTime(cal_001f.Text), Convert.ToInt32(ddown001f.SelectedValue),
        Convert.ToInt32(ddown002f.SelectedValue), Convert.ToString(txt001f.Text).ToUpper(), Convert.ToString(txt003f.Text).ToUpper(),
        Convert.ToString(txt004f.Text).ToUpper(), Convert.ToInt32(txt002f.Text), Convert.ToString(txt005f.Text).ToUpper(),
        DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(chk001OcupacionLaboral.Checked));

       

        imb_001f.Visible = true;
        imb_002f.Visible = false;

        clean_form();
        //gfontbrevis
        mostrar_collapse(false);
        btnGatillo.Attributes.Remove("disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }
    else
    {
        //ab4.Tabs[6].Style.ForeColor = System.Drawing.Color.Red;
        //gfontbrevis
        mostrar_collapse(true);
        btnGatillo.Attributes.Add("disabled", "disabled");

    }



    DataTable dt6 = dcoll.GetSituacionLaboral(SSninoDiag.ICodIE);
    DataView dv6 = new DataView(dt6);
    dv6.Sort = "FechaSituacionLaboral DESC";
    grd001f.DataSource = dv6;
    grd001f.DataBind();
    grd001f.Visible = true;
    grd001f.Visible = true;
    //utab4.Visible = true;



    if (dv6.Count == 0)
    {
        lbl_nota2.Visible = true;//gfontbrevis
    }
    else
    {
        lbl_nota2.Visible = false;//gfontbrevis
    }


    grd001f.Focus();


    }


    # endregion

    # region Historico de Diagnosticos

    protected void imb_004f_Click(object sender, EventArgs e)
    {
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'ninos_HistoricoDiagnosticoSituacionLaboral.aspx', '770', '420')";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

    # endregion

    #region volver

    protected void imb_005f_Click(object sender, EventArgs e)
    {
        //clean_form();

        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");
    }

   


    # endregion

    #region validaciones


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }





    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();

      //  Label lbl_fechaingresoL = (Label)utab4.FindControl("lbl_fechaL");
        //lbl_fechaingresoL.Text = SSninoDiag.fchingdesde.ToShortDateString();

        //Label tlbl002f = (Label)utab4.FindControl("lbl002f");

        int edad = Convert.ToInt32((DateTime.Now.Year) - (SSninoDiag.FechaNacimiento.Year));





        //WebDateChooser tcal001f = (TextBox)utab4.FindControl("cal_001f");
        //cal_001f.MinDate = SSninoDiag.fchingdesde;
        //cal_001f.MaxDate = DateTime.Now;
        CalendarExtende1130.StartDate = SSninoDiag.fchingdesde;
        CalendarExtende1130.EndDate = DateTime.Now;


        //GridView tgrd001f = (GridView)utab4.FindControl("grd001f");
        DataTable dt6 = dcoll.GetSituacionLaboral(SSninoDiag.ICodIE);
        DataView dv6 = new DataView(dt6);
        dv6.Sort = "FechaSituacionLaboral DESC";
        grd001f.DataSource = dv6;
        grd001f.DataBind();
        grd001f.Visible = true;
        grd001f.Visible = true;
        //utab4.Visible = true;

        if (dv6.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis
        }
        //}

        // DropDownList  Diagnostico Situacion Laboral

        //DropDownList tddown001f = (DropDownList)utab4.FindControl("ddown001f");
        DataView dv37 = new DataView(par.GetparInsercionLaboral());
        ddown001f.Items.Clear();
        ddown001f.DataSource = dv37;
        ddown001f.DataTextField = "Descripcion";
        ddown001f.DataValueField = "CodAreaInsercionLaboral";
        dv37.Sort = "Descripcion";
        ddown001f.DataBind();

        //DropDownList tddown002f = (DropDownList)utab4.FindControl("ddown002f");
        DataView dv38 = new DataView(par.GetparSituaciónLaboral());
        ddown002f.Items.Clear();
        ddown002f.DataSource = dv38;
        ddown002f.DataTextField = "Descripcion";
        ddown002f.DataValueField = "CodSituacionLaboral";
        dv38.Sort = "Descripcion";
        ddown002f.DataBind();
        

    }

    #endregion

    # region Limpia Formulario


    protected void imb_003f_Click(object sender, EventArgs e)
    {

        clean_form();
        imb_002f.Visible = false;
        imb_001f.Visible = true;
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }
       
    private void clean_form()
    {
        ddown001f.SelectedValue = "0";
        ddown002f.SelectedValue = "0";
        
        txt001f.Text = "";
        txt002f.Text = "";
        txt003f.Text = "";
        txt004f.Text = "";
        txt005f.Text = "";

        cal_001f.Text = "";


        cal_001f.BackColor = System.Drawing.Color.Empty;
        ddown001f.BackColor = System.Drawing.Color.Empty;
        ddown002f.BackColor = System.Drawing.Color.Empty;
    }

    # endregion

    #region Funciones del Formulario
    
    
    private bool validateLaboral()
    {
        bool n = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

       // WebDateChooser tcal001f = (TextBox)utab4.FindControl("cal_001f");
        if (cal_001f.Text == "")
        {

            cal_001f.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal_001f.BackColor = System.Drawing.Color.White;

        }


        //DropDownList tddown001f = (DropDownList)utab4.FindControl("ddown001f");
        if (Convert.ToInt32(ddown001f.SelectedValue) == 0)
        {
            ddown001f.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001f.BackColor = System.Drawing.Color.White;

        }

        //DropDownList tddown002f = (DropDownList)utab4.FindControl("ddown002f");

        if (Convert.ToInt32(ddown002f.SelectedValue) == 0)
        {
            ddown002f.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002f.BackColor = System.Drawing.Color.White;

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
