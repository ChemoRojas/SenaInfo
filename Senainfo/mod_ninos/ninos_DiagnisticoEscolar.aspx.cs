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

using Argentis.Regmen;


using CustomWebControls;

public partial class mod_ninos_ninos_DiagnisticoEscolar : System.Web.UI.Page
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
  public int AuxEscolar
  {
    get
    {
      if (ViewState["AuxEscolar"] == null)
      { ViewState["AuxEscolar"] = -1; }
      return Convert.ToInt32(ViewState["AuxEscolar"]);
    }
    set { ViewState["AuxEscolar"] = value; }
  }
  # endregion




  protected void Page_Load(object sender, EventArgs e)
  {
    # region CargaInicial

    CalendarExtender328.EndDate = DateTime.Now;
    RangeValidator903.Validate();

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
        //btn002aa.Visible = false;
        CalendarExtender328.StartDate = SSninoDiag.fchingdesde;
        CalendarExtender328.EndDate = System.DateTime.Now;
        BtnModificarDiagnostico.Visible = false;
        //btnMostrarForm.InnerText = "Agregar Nuevo Diagnostico Escolar";
        //btnGatilloCancelar.Style.Add("display", "none");//gfontbrevis
        validatescurity(); //LO ULTIMO DEL LOAD
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
      //btn002aa.Visible = false;
      BtnModificarDiagnostico.Visible = false;
      grd001aa.Columns[7].Visible = false;
    }

    //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
    if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
    {
      //btn001aa.Visible = false;
      BtnAgregarDiagnostico.Visible = false;
    }

    //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
    if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
    {
      //btn004aa.Visible = false;
      BtnVerHistorico.Visible = false;
    }

    #endregion
  }


  #region Validaciones
  protected void txt001_wn_ValueChange(object sender, EventArgs e)
  {


    if (TxtAnoEscolaridad.Text.Trim().Length > 0 && Convert.ToInt32(TxtAnoEscolaridad.Text) > DateTime.Now.Year)
    {
      TxtAnoEscolaridad.Text = Convert.ToString(DateTime.Now.Year);
      lbl001aa.Text = "El año Ingresado es mayor al año actual";


    }
    else if (Convert.ToInt32(TxtAnoEscolaridad.Text.Trim()) < 1990)
    {
      TxtAnoEscolaridad.Text = "";
      lbl001aa.Text = "El año de ingreso debe ser mayor a 1990";
    }
    else
    {
      lbl001aa.Text = "";
    }


    grd001aa.Focus();
  }
  #endregion

  # region inserta diagnostico
  protected void imb_001aa_Click(object sender, EventArgs e)
  {



    bool sw = false;

    ninocoll ncoll = new ninocoll();
    diagnosticoscoll dcoll = new diagnosticoscoll();

    // verifica que no se repita el diagnostico

    for (int i = 0; i < grd001aa.Rows.Count; i++)
    {
        //if (Server.HtmlDecode((grd001aa.Rows[i].Cells[3]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown001.SelectedItem.Text.ToUpper().Trim()) &&
        //    Server.HtmlDecode((grd001aa.Rows[i].Cells[5]).Text.ToUpper().Trim()) == Server.HtmlDecode(txt001_wn.Text.ToUpper().Trim()) &&
        //    Server.HtmlDecode((grd001aa.Rows[i].Cells[6]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown003.SelectedItem.Text.ToUpper().Trim()))
        if (Server.HtmlDecode((grd001aa.Rows[i].Cells[4]).Text.Trim()) == Server.HtmlDecode(CalDiagnostico.Text.Trim()))
        {
        lbl002aa.Text = "Para realizar este ingreso, Debe cambiar la fecha de Diagnóstico";
        //lbl002aa.Text = "El menor ya posee diagnostico, Intentelo nuevamente";
        sw = true;
        //mostrar_collapse(true);

        
        }


    }

    if (validateDE() == true && sw == false)
    {


        if (txt002_te.Text == null)
        {
        txt002_te.Text = "SIN OBSERVACION";
        }

        // int inden = ncoll.Insert_DiagnosticoGeneral(1, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(cal001.Text));
        // dcoll.Insert_DiagnosticosEscolar(inden, DateTime.Now, Convert.ToInt32(ddown001.SelectedValue)
        //     , Convert.ToDateTime(cal001.Value), Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue),
        //     Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(txt001_wn.Text),
        //     Convert.ToString(txt002_te.Text).ToUpper(), false, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

        int inden = ncoll.Insert_DiagnosticoGeneral(1, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(CalDiagnostico.Text));
        dcoll.Insert_DiagnosticosEscolar(inden, DateTime.Now, Convert.ToInt32(ddown001.SelectedValue)
            , Convert.ToDateTime(CalDiagnostico.Text), Convert.ToInt32(ddown002.SelectedValue), SSninoDiag.CodInst, Convert.ToInt32(ddown002.SelectedValue),
            Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(TxtAnoEscolaridad.Text),
            Convert.ToString(txt002_te.Text).ToUpper(), false, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));



        //SSninoDiag.CodInst,
        lbl002aa.Text = "";
        clean_form();
        //gfontbrevis
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowAgregar", "$('#btnGatillo').show();$('#btnGatilloCancelar').hide();", true);
        //btnGatilloCancelar.Visible = false;
        btnGatillo.Attributes.Remove("disabled");
        mostrar_collapse(false);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    

        // actualiza la grilla diagnostico

        DataTable dt = dcoll.GetDiagnosticoEscolar(SSninoDiag.ICodIE);
        DataView dv = new DataView(dt);
        dv.Sort = "FechaDiagnostico DESC";
        grd001aa.DataSource = dv;

        grd001aa.DataBind();
        grd001aa.Visible = true;


        // inhabilita la modificacion del diagnostico escolar hecho al ingreso

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int indicador = Convert.ToInt32(dt.Rows[i]["AlIngreso"].ToString());
                if (indicador == 1)
                {
                    //grd001aa.Rows[i].Cells[7].Enabled = false;
                    grd001aa.Rows[i].Cells[7].Visible = false;

                }

            }
        }


        //for (int i = 0; i < grd001aa.Rows.Count; i++)
        //{
        //  int ALING = Convert.ToInt32(grd001aa.Rows[i].Cells[0].Text);
        //  if (ALING == 1)
        //  {
        //    //grd001aa.Rows[i].Cells[7].Enabled = false;
        //    grd001aa.Rows[i].Cells[7].Visible = false;

        //  }

        //}

        if (dv.Count == 0)
        {
            lbl001aa.Text = "Este Niño(a) no Posee Diagnostico Escolar";
        }
        else
        {
            lbl001aa.Text = "";

        }
    }
    else
    {
        mostrar_collapse(true);
        //gfontbrevis
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        btnGatillo.Attributes.Add("disabled", "disabled");
        btnGatilloCancelar.Visible = true;
    }

    
    //grd001aa.Focus();
    
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "hidingForm", "$('#btnGatilloCancelar').click();", true);
  }
  # endregion

  # region ActualizaDiagnostico

  // selecciona niño de la grilla de diagnosticos

  protected void grd001aa_RowCommand(object sender, GridViewCommandEventArgs e)
  {

    diagnosticoscoll dcoll = new diagnosticoscoll();

    string ICodEscolar = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
    AuxEscolar = Convert.ToInt32(ICodEscolar);

    string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
    VCod_diagnostico = Convert.ToInt32(codDiagnostico);

    string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
    VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);

    DataTable dt = dcoll.GetDiagnosticoEscolarMostrar(VCod_diagnostico);

    CalDiagnostico.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToShortDateString();

    try
    {
      ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
      ddown001.Items.FindByValue(dt.Rows[0][6].ToString()).Selected = true;
    }
    catch { }

    ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
    try
    {
      ddown002.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;
    }
    catch
    {
      ddown002.Items.FindByValue("-1").Selected = true;
    }

    ddown003.Items.FindByValue(ddown003.SelectedValue).Selected = false;
    ddown003.Items.FindByValue(dt.Rows[0][7].ToString()).Selected = true;

    TxtAnoEscolaridad.Text = Convert.ToString(dt.Rows[0][1]);

    txt002_te.Text = Convert.ToString(dt.Rows[0][2]);

    //btn001aa.Visible = false;
    //btn002aa.Visible = true;
    BtnAgregarDiagnostico.Visible = false;
    BtnModificarDiagnostico.Visible = true;
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#btnMostrarForm').click();", true);
    mostrar_collapse(true);
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "focusToIframes", "$('#iframe_utab1').contents().find('.titulo_form').focus()", true);
    
      //gfontbrevis
      //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
    btnGatillo.Attributes.Add("disabled", "disabled");
    btnGatilloCancelar.Visible = true;
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    //grd001aa.Focus();
    //grd001aa.Rows[Convert.ToInt32(e.CommandArgument)].BackColor = System.Drawing.Color.SkyBlue;
  }


  // inserta diagnostico en la tabla
  protected void imb_002aa_Click(object sender, EventArgs e)
  {

    bool sw = false;

    ninocoll ncoll = new ninocoll();
    diagnosticoscoll dcoll = new diagnosticoscoll();


    //// verifica que no se ha ingresado el mismo diagnostico
    //for (int i = 0; i < grd001aa.Rows.Count; i++)
    //{
    //    if (Server.HtmlDecode((grd001aa.Rows[i].Cells[2]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown001a.SelectedItem.Text.ToUpper().Trim()) &&
    //        Server.HtmlDecode((grd001aa.Rows[i].Cells[4]).Text.ToUpper().Trim()) == Server.HtmlDecode(txt001_wna.Text.ToUpper().Trim()) &&
    //        Server.HtmlDecode((grd001aa.Rows[i].Cells[5]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown003a.SelectedItem.Text.ToUpper().Trim()))
    //    {
    //        lbl002aa.Text = "El menor ya posee diagnostico, Intentelo nuevamente";
    //        sw = true;
    //    }
    //    else
    //    {
    //        sw = false;
    //        lbl002aa.Text = "";
    //    }

    //}

    if (validateDE() == true && sw == false)
    {

        if (txt002_te.Text == null)
        {
            txt002_te.Text = "SIN OBSERVACION";
        }

        ncoll.Update_DiagnosticosEscolar(AuxEscolar,
        VCod_diagnostico, Convert.ToDateTime(CalDiagnostico.Text),
        Convert.ToInt32(ddown001.SelectedValue), VFecha_diagnostico,
        Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue),
        Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(TxtAnoEscolaridad.Text),
        Convert.ToString(txt002_te.Text).ToUpper(), Convert.ToInt32(false), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

        clean_form();
        lbl002aa.Text = "";

        //btn001aa.Visible = true;
        //btn002aa.Visible = false;
        btnGatillo.Attributes.Remove("disabled");
        mostrar_collapse(false);
        BtnAgregarDiagnostico.Visible = true;
        BtnModificarDiagnostico.Visible = false;

        DataTable dt = dcoll.GetDiagnosticoEscolar(SSninoDiag.ICodIE);
        DataView dv = new DataView(dt);

        grd001aa.DataSource = dv;

        grd001aa.DataBind();
        grd001aa.Visible = true;

        //Deja desabilitado el diagnostico hecho al ingreso

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int indicador = Convert.ToInt32(dt.Rows[i]["AlIngreso"].ToString());
                if (indicador == 1)
                {
                    //grd001aa.Rows[i].Cells[7].Enabled = false;
                    grd001aa.Rows[i].Cells[7].Visible = false;

                }

            }
        }


        //for (int i = 0; i < grd001aa.Rows.Count; i++)
        //{
        //  int ALING = Convert.ToInt32(grd001aa.Rows[i].Cells[0].Text);
        //  if (ALING == 1)
        //  {
        //    //grd001aa.Rows[i].Cells[7].Enabled = false;
        //    grd001aa.Rows[i].Cells[7].Visible = false;

        //  }

        //}

        if (dv.Count == 0)
        {
            lbl001aa.Text = "Este Niño(a) no Posee Diagnostico Escolar";
        }

        grd001aa.Focus();

    }
    else { 
          //gfontbrevis
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        btnGatillo.Attributes.Add("disabled", "disabled");
        btnGatilloCancelar.Visible = true;
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }
  }

  # endregion

  # region Historico de Diagnosticos
  protected void btn004aa_Click(object sender, EventArgs e)
  {
    window.open(this.Page, "ninos_HistoricoDiagnosticoEscolar.aspx", 770, 420);
  }
  # endregion

  #region volver
  protected void btn005aa_Click(object sender, EventArgs e)
  {

    //clean_form();

    //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");

  }
  # endregion

  #region validaciones

  private bool validateDE()
  {
    bool n = true;
    System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

    if (CalDiagnostico.Text == "")
    {
      CalDiagnostico.BackColor = colorCampoObligatorio;
      n = false;
    }
    else
    {
      CalDiagnostico.BackColor = System.Drawing.Color.White;
    }


    if (Convert.ToInt32(ddown001.SelectedValue) == 0)
    {
      ddown001.BackColor = colorCampoObligatorio;
      n = false;
    }
    else
    {
      ddown001.BackColor = System.Drawing.Color.White;

    }

    if (Convert.ToInt32(ddown002.SelectedValue) == 0)//|| Convert.ToInt32(ddown002.SelectedValue) == -1)
    {
      ddown002.BackColor = colorCampoObligatorio;
      n = false;
    }
    else
    {
      ddown002.BackColor = System.Drawing.Color.White;

    }

    if (Convert.ToInt32(ddown003.SelectedValue) == 0)
    {
      ddown003.BackColor = colorCampoObligatorio;
      n = false;
    }
    else
    {
      ddown003.BackColor = System.Drawing.Color.White;

    }

    if (TxtAnoEscolaridad.Text.Trim() == "")
    {
      TxtAnoEscolaridad.BackColor = colorCampoObligatorio;
      n = false;
    }
    else
    {
      TxtAnoEscolaridad.BackColor = System.Drawing.Color.White;

    }
    if (lbl001aa.Text == "El año Ingresado es mayor al año actual")
    {
      lbl001aa.BackColor = colorCampoObligatorio;
      n = false;
    }
    else
    {
      lbl001aa.BackColor = System.Drawing.Color.White;

    }


    return n;

  }

  #endregion

  # region Carga Inicial de controles del formulario

  private void GetData()
  {

    diagnosticoscoll dcoll = new diagnosticoscoll();
    parcoll par = new parcoll();
    ninocoll ncoll = new ninocoll();
    trabajadorescoll tcoll = new trabajadorescoll();


    //cal001.MinDate = SSninoDiag.fchingdesde;
    //cal001.MaxDate = DateTime.Now;

    DataTable dt = dcoll.GetDiagnosticoEscolar(SSninoDiag.ICodIE);
    DataView dv = new DataView(dt);

    //dv.Sort = "Alingreso";
    dv.Sort = "FechaDiagnostico DESC";
    grd001aa.DataSource = dv;
    grd001aa.DataBind();
    grd001aa.Visible = true;

    if (dt.Rows.Count > 0)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int indicador = Convert.ToInt32(dt.Rows[i]["AlIngreso"].ToString());
            if (indicador == 1)
            {
                //grd001aa.Rows[i].Cells[7].Enabled = false;
                grd001aa.Rows[i].Cells[7].Visible = false;

            }

        }
    }
    
    //for (int i = 0; i < grd001aa.Rows.Count; i++)
    //{
    //  int ALING = Convert.ToInt32(grd001aa.Rows[i].Cells[0].Text);
    //  if (ALING == 1 )
    //  {
    //    //grd001aa.Rows[i].Cells[7].Enabled = false;
    //    grd001aa.Rows[i].Cells[7].Visible = false;

    //  }

    //}
    if (dv.Count == 0)
    {  
        lbl001aa.Text = "Este Niño(a) no Posee Diagnostico Escolar";
    }
    else
    {
        string anoActual = DateTime.Now.ToString("yyyy");
        int mesActual = Convert.ToInt32(DateTime.Now.ToString("MM"));

        DataTable dtTemp = dv.ToTable();

        string fechaUltimoDiagEscolar = Convert.ToDateTime(dtTemp.Rows[0]["FechaDiagnostico"].ToString()).ToString("yyyy"); // dtTemp.Rows[0]["AnoUltimoCursoAprobado"].ToString(); //

        if (anoActual != fechaUltimoDiagEscolar && mesActual >= 4) // Si no posee diagnóstico en el año actual, se muestra alerta a contar de abril
        {
            alertaEditar.Visible = true;
            lblAnoActual.Text = anoActual;
        } 
        
        lbl001aa.Text = "";
    }

    int Edad = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(SSninoDiag.FechaNacimiento.Year);

    DateTime itime = DateTime.Now;
    TimeSpan compare = itime.Date - SSninoDiag.FechaNacimiento.Date;
    int y = Convert.ToInt32(compare.Days / 365);



    DataView dv13 = new DataView(par.GetparEscolaridad(y));//, Edad));
    ddown001.Items.Clear();
    ddown001.DataSource = dv13;
    ddown001.DataTextField = "Descripcion";
    ddown001.DataValueField = "CodEscolaridad";
    dv13.Sort = "CodEscolaridad";
    ddown001.DataBind();

    DataView dv14 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
    ddown002.Items.Clear();
    ddown002.DataSource = dv14;
    ddown002.DataTextField = "NombreCompleto";
    ddown002.DataValueField = "ICodTrabajador";
    dv14.Sort = "NombreCompleto";
    ddown002.DataBind();

    DataView dv15 = new DataView(par.GetparTipoAsistenciaEscolar());
    ddown003.Items.Clear();
    ddown003.DataSource = dv15;
    ddown003.DataTextField = "Descripcion";
    ddown003.DataValueField = "TipoAsistenciaEscolar";
    dv15.Sort = "Descripcion";
    ddown003.DataBind();

  }

  #endregion

  # region Limpia Formulario


  protected void imb_003aa_Click(object sender, EventArgs e)
  {
    clean_form();
    //btn002aa.Visible = false;
    //btn001aa.Visible = true;
    BtnModificarDiagnostico.Visible = false;
    BtnAgregarDiagnostico.Visible = true;
    mostrar_collapse(true);
      //gfontbrevis
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
    btnGatillo.Attributes.Add("disabled", "disabled");
    btnGatilloCancelar.Visible = true;
  }

  private void clean_form()
  {
    ddown001.SelectedValue = "0";
    ddown002.SelectedValue = "0";
    ddown003.SelectedValue = "0";

    TxtAnoEscolaridad.Text = "";
    txt002_te.Text = "";

    //cal001.Value = "Seleccione Fecha";
    CalDiagnostico.Text = "";

    CalDiagnostico.BackColor = System.Drawing.Color.Empty;
    ddown001.BackColor = System.Drawing.Color.Empty;
    ddown003.BackColor = System.Drawing.Color.Empty;
    TxtAnoEscolaridad.BackColor = System.Drawing.Color.Empty;
    ddown002.BackColor = System.Drawing.Color.Empty;
  }

  # endregion

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
  protected void TxtAnoEscolaridad_TextChanged(object sender, EventArgs e)
  {
    RangeValidator903.Validate();

    if (TxtAnoEscolaridad.Text != "")
    {
      if (Convert.ToInt32(TxtAnoEscolaridad.Text.Trim()) > DateTime.Now.Year)
      {
        TxtAnoEscolaridad.Text = Convert.ToString(DateTime.Now.Year);

      }
      if (Convert.ToInt32(TxtAnoEscolaridad.Text.Trim()) < DateTime.Now.Year - 100)
      {
        TxtAnoEscolaridad.Text = Convert.ToString(DateTime.Now.Year - 100);
      }
    }
    mostrar_collapse(true);
      //gfontbrevis
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('');$('#btnGatilloCancelar').show('');", true);
    btnGatillo.Attributes.Add("disabled", "disabled");
    btnGatilloCancelar.Visible = true;
    
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

  protected void btnGatillo_Click(object sender, EventArgs e)
  {
    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#btnMostrarForm').click();", true);
  }
 
  protected void grd001aa_RowDataBound(object sender, GridViewRowEventArgs e)
  {
     

      if (e.Row.RowType == DataControlRowType.DataRow)
      {

          switch (Convert.ToInt32(e.Row.Cells[0].Text))
          {

              case 0:
                  e.Row.Cells[0].Text = "No";
                  break;

              case 1:
                  e.Row.Cells[0].Text = "Si";
                  break;
          }
      }
  }
  
  
 
}
