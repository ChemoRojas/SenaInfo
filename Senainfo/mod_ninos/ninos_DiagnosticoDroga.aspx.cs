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

public partial class mod_ninos_ninos_DiagnosticoDroga : System.Web.UI.Page
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

    public int ICodDroga
    {
        get
        {
            if (ViewState["ICodDroga"] == null)
            { ViewState["ICodDroga"] = -1; }
            return Convert.ToInt32(ViewState["ICodDroga"]);
        }
        set { ViewState["ICodDroga"] = value; }
    }
    # endregion

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

    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial
        CalendarExtender328.StartDate = SSninoDiag.fchingdesde;
        CalendarExtender328.EndDate = System.DateTime.Now;
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
                BtnModificarDiagnostico.Visible = false;
                //btnGatilloCancelar.Style.Add("display", "none");//gfontbrevis
                validatescurity();
                bool swLrpa = FiltroLRPA();
                if (swLrpa == true)
                {
                    chk001DrogaLRPA.Enabled = true;
                    tblSENDA_1.Visible = true;//gfontbrevis
                    tblSENDA_2.Visible = true;

                }
                else 
                {
                    chk001DrogaLRPA.Enabled = false;
                    tblSENDA_1.Visible = false;//gfontbrevis
                    tblSENDA_2.Visible = false;

                }

            
            }


            #endregion 

        }
        # endregion
    }


    private bool FiltroLRPA()
    {
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(SSninoDiag.CodProyecto);

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

    private void validatescurity()
    {
        #region Validacion


        //357AB123-05D6-4F6F-93E9-C8007A403079 2.3_MODIFICAR
        if (!window.existetoken("357AB123-05D6-4F6F-93E9-C8007A403079"))
        {
            BtnModificarDiagnostico.Visible = false;
            grd001b.Columns[6].Visible = false;
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


    

    // selecciona niño de la grilla de diagnosticos
    protected void grd001b_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        diagnosticoscoll dcoll = new diagnosticoscoll();


        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
        VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);


        string VICodDroga = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        ICodDroga = Convert.ToInt32(VICodDroga);

        DataTable dt = dcoll.GetDiagnosticoDrogaMostrar(VCod_diagnostico);



        CalDiagnostico.Text = Convert.ToDateTime(dt.Rows[0][1]).ToShortDateString();

        try
        {
            ddown001b.Items.FindByValue(ddown001b.SelectedValue).Selected = false;
            ddown001b.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;
        }
        catch
        {
            ddown001b.SelectedIndex = 0;
        }

        ddown001b_SelectedIndexChanged(sender, e);

        try
        {
            ddown002b.Items.FindByValue(ddown002b.SelectedValue).Selected = false;
            ddown002b.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;
        }
        catch
        {
            ddown002b.SelectedIndex = 0;
        }
        ddown003b.Items.FindByValue(ddown003b.SelectedValue).Selected = false;
        try
        {
            ddown003b.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;
        }
        catch
        {
            ddown003b.Items.FindByValue("-1").Selected = true;
        }

        txt002b.Text = Convert.ToString(dt.Rows[0][5]);

        try
        {
            if (Convert.ToInt32(dt.Rows[0][6]) == 1)
            {
                chk001DrogaLRPA.Checked = true;
            }
            else
            {
                chk001DrogaLRPA.Checked = false;
            }
        }
        catch { }

        BtnAgregarDiagnostico.Visible = false;
        BtnModificarDiagnostico.Visible = true;
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        btnGatilloCancelar.Visible = true;
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);


        //grd001b.Focus();
    }
    


    // inserta diagnostico en la tabla
    protected void imb_001b_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();
        
        Boolean sw = false;


        for (int i = 0; i < grd001b.Rows.Count; i++)
        {


            DateTime fecha;

            if (CalDiagnostico.Text.ToUpper().Trim() == "")
            {
                fecha = Convert.ToDateTime("01-01-1900");
            }
            else
            {
                fecha = Convert.ToDateTime(CalDiagnostico.Text);
            }

            if (Convert.ToDateTime(Convert.ToDateTime(Server.HtmlDecode((grd001b.Rows[i].Cells[2]).Text.ToUpper().Trim())).ToShortDateString()) == fecha  /*Convert.ToDateTime(Server.HtmlDecode(tcal001b.Text.ToUpper().Trim())).ToShortDateString()*/ &&
                Server.HtmlDecode((grd001b.Rows[i].Cells[3]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown001b.SelectedItem.Text.ToUpper().Trim()))
            {
                lbl001b.Text = "El menor ya posee diagnostico igual, Intentelo nuevamente";
                sw = true;
                //gfontbrevis
                btnGatillo.Attributes.Add("disabled","disabled");
                mostrar_collapse(true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowAgregar", "$('#btnGatillo').show();$('#btnGatilloCancelar').hide();", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
            }


        }




        if (validateDiagDroga() == true && sw == false)
        {



            //utab4.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
            if (txt002b.Text == null)
            {
                txt002b.Text = "SIN OBSERVACION";
            }



            int inden = ncoll.Insert_DiagnosticoGeneral(3, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(CalDiagnostico.Text));
            dcoll.Insert_DiagnosticosDroga(inden, Convert.ToInt32(ddown001b.SelectedValue),
                Convert.ToDateTime(CalDiagnostico.Text), Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddown002b.SelectedValue), SSninoDiag.CodInst,
                txt002b.Text.ToUpper(), Convert.ToInt32(ddown003b.SelectedValue), DateTime.Now,Convert.ToInt32(chk001DrogaLRPA.Checked));

            clean_form();
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            mostrar_collapse(false);
            //btnGatilloCancelar.Visible = true;
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowAgregar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 800 }, 500);", true);
            lbl001b.Text = "";

        }
        else
        {
            mostrar_collapse(true);
            btnGatillo.Attributes.Add("disabled", "disabled");
          //  utab4.Tabs[2].Style.ForeColor = System.Drawing.Color.Red;

        }



        DataTable dt2 = dcoll.GetDiagnosticoDroga(SSninoDiag.ICodIE);
        DataView dv2 = new DataView(dt2);
        dv2.Sort = "FechaDiagnostico DESC";
        grd001b.DataSource = dv2;
        grd001b.DataBind();
        grd001b.Visible = true;
        //utab4.Visible = true;


        if (dv2.Count == 0)
        {
            lbl001a.Visible = true;//gfontbrevis 
        }

        //grd001b.Focus();
    }
    
    # endregion

    #region Actualiza Diagnosticos

    protected void imb_002b_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();

        Boolean sw = false;

        if (validateDiagDroga() == true && sw == false)
        {

//            utab4.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
            if (txt002b.Text == null)
            {
                txt002b.Text = "SIN OBSERVACION";
            }



            dcoll.Update_DiagnosticosDroga(ICodDroga, VCod_diagnostico,
                Convert.ToInt32(ddown001b.SelectedValue),
                    Convert.ToDateTime(CalDiagnostico.Text), Convert.ToInt32(Session["IdUsuario"]),
                    Convert.ToInt32(ddown002b.SelectedValue),
                    Convert.ToInt32(ddown003b.SelectedValue),
                    SSninoDiag.CodInst,
                    txt002b.Text.ToUpper(),
                    Convert.ToInt32(ddown003b.SelectedValue),
                    DateTime.Now,Convert.ToInt32(chk001DrogaLRPA.Checked));



            //WebImageButton timb_001b = (WebImageButton)utab4.FindControl("imb_001b");
            //WebImageButton timb_002b = (WebImageButton)utab4.FindControl("imb_002b");

            BtnAgregarDiagnostico.Visible = true;
            BtnModificarDiagnostico.Visible = false;

            clean_form();

            lbl001b.Text = "";
            //gfontbrevis
            mostrar_collapse(false);
            btnGatillo.Attributes.Remove("disabled");



        }
        else
        {

            //utab4.Tabs[0].Style.ForeColor = System.Drawing.Color.Red;

        }
        DataTable dt = dcoll.GetDiagnosticoDroga(SSninoDiag.ICodIE);
        DataView dv = new DataView(dt);
        dv.Sort = "FechaDiagnostico DESC";
        grd001b.DataSource = dv;
        grd001b.DataBind();
        grd001b.Visible = true;
        //utab4.Visible = true;



        if (dv.Count == 0)
        {
            lbl001a.Visible = true;//gfontbrevis
        }

        //grd001b.Focus();

    }

    #endregion

    # region Historico de Diagnosticos
    
    protected void imb_004b_Click(object sender, EventArgs e)
    {
        //window.open(this.Page, "ninos_HistoricoDiagnosticoDroga.aspx", 770, 420);
    }
    
    # endregion

    #region volver

    protected void imb_005b_Click(object sender, EventArgs e)
    {

    }

    # endregion

    #region validaciones

       
    protected void ddown001b_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList tddown001b = (DropDownList)utab4.FindControl("ddown001b");
        //DropDownList tddown002b = (DropDownList)utab4.FindControl("ddown002b");

        if (Convert.ToInt32(ddown001b.SelectedValue) == 44 || Convert.ToInt32(ddown001b.SelectedValue) == 65)
        {

            ddown002b.SelectedValue = Convert.ToString(1);
            ddown002b.Enabled = false;
            ddown002b.BackColor = System.Drawing.Color.Empty;

        }
        else
        {
            ddown002b.SelectedValue = "0";
            ddown002b.Enabled = true;
        }


       // GridView tgrd001b = (GridView)utab4.FindControl("grd001b");
        //grd001b.Focus();


        mostrar_collapse(true);
        btnGatillo.Attributes.Add("disabled", "disabled");
        btnGatilloCancelar.Visible = true;
    }




    #endregion

    # region Carga Inicial de controles del formulario

    private void GetData()
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();



       // Label lbl_fechaingresoD = (Label)utab4.FindControl("lbl_fechaD");
        //lbl_fechaD.Text = SSninoDiag.fchingdesde.ToShortDateString();
        
       // WebDateChooser tcal001b = (TextBox)utab4.FindControl("cal001b");
        //cal001b.MinDate = SSninoDiag.fchingdesde;
        //cal001b.MaxDate = DateTime.Now;

        //GridView tgrd001b = (GridView)utab4.FindControl("grd001b");
        //Label tlbl001b = (Label)utab4.FindControl("lbl001b");
        DataTable dt2 = dcoll.GetDiagnosticoDroga(SSninoDiag.ICodIE);
        DataView dv2 = new DataView(dt2);
        dv2.Sort = "FechaDiagnostico DESC";
        grd001b.DataSource = dv2;


        if (dv2.Count == 0)
        {
            lbl001a.Visible = true;
        }
        else
        {
            lbl001b.Text = "";
            lbl001a.Visible = false;//gfontbrevis
        }


        // DropDownList  Droga
        //DropDownList tddown001b = (DropDownList)utab4.FindControl("ddown001b");
        DataView dv20 = new DataView(par.GetparDrogas());
        ddown001b.Items.Clear();
        ddown001b.DataSource = dv20;
        ddown001b.DataTextField = "Descripcion";
        ddown001b.DataValueField = "CodDroga";
        dv20.Sort = "Descripcion";

        bool swLrpa = FiltroLRPA();
        if (swLrpa)
        {
           // ddown001b.SelectedValue = "44";
           // ddown001b.Enabled = false;           
        }
        
        //DropDownList tddown002b = (DropDownList)utab4.FindControl("ddown002b");
        DataView dv21 = new DataView(par.GetparTipoConsumoDroga());
        dv21.Sort = "TipoConsumoDroga ASC";
        ddown002b.Items.Clear();
        ddown002b.DataSource = dv21;
        ddown002b.DataTextField = "Descripcion";
        ddown002b.DataValueField = "TipoConsumoDroga";



        //DropDownList tddown003b = (DropDownList)utab4.FindControl("ddown003b");
        DataView dv22 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
        dv22.Sort = "NombreCompleto";
        ddown003b.Items.Clear();
        ddown003b.DataSource = dv22;
        ddown003b.DataTextField = "NombreCompleto";
        ddown003b.DataValueField = "ICodTrabajador";



        ddown001b.DataBind();
        ddown002b.DataBind();
        ddown003b.DataBind();

        grd001b.Visible = true;
        //utab4.Visible = true;
        grd001b.DataBind();

        // Datos niño
        DataTable dtNino = ncoll.SQL_NinoII(ninocoll.querytype.inproyect, "", "", "", SSninoDiag.CodNino.ToString(), "", "", "", "");
        IFechaNac = Convert.ToDateTime(dtNino.Rows[0]["FechadeNacimiento"]);

        TimeSpan difFecha = DateTime.Now - IFechaNac;

        if (difFecha.TotalDays < 2190) //Si el NNA tiene menos de 6 años de edad
        {
            alertaEditar.Visible = true;
            lblFechaNac.Text = IFechaNac.ToString("dd-MM-yyyy");
        }
    }

    #endregion

    # region Limpia Formulario
 
    protected void imb_003b_Click(object sender, EventArgs e)
    {

        clean_form();
        BtnModificarDiagnostico.Visible = false;
        BtnAgregarDiagnostico.Visible = true;
        //grd001b.Focus();
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        btnGatilloCancelar.Visible = true;
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);

    }


    private void clean_form()
    {
        CalDiagnostico.Text= "";

 //       ddown001b.SelectedValue = "65";     // SIN CONSUMO DE DROGAS
 //       ddown002b.SelectedValue = "1";
        ddown001b.SelectedValue = "0";
        ddown002b.SelectedValue = "0";
        ddown002b.Enabled = true;
        ddown003b.SelectedValue = "0";
        chk001DrogaLRPA.Checked = false;

        txt002b.Text = "";


        CalDiagnostico.BackColor = System.Drawing.Color.Empty;
        ddown001b.BackColor = System.Drawing.Color.Empty;
        ddown002b.BackColor = System.Drawing.Color.Empty;
        ddown003b.BackColor = System.Drawing.Color.Empty;

    }

    # endregion

    # region Funciones del formulario

    private bool validateDiagDroga()
    {
        bool n = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
       // WebDateChooser tcal001b = (TextBox)utab4.FindControl("cal001b");
        if (CalDiagnostico.Text == "")
        {

            CalDiagnostico.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            CalDiagnostico.BackColor = System.Drawing.Color.Empty;

        }
        //DropDownList tddown001b = (DropDownList)utab4.FindControl("ddown001b");
        if (Convert.ToInt32(ddown001b.SelectedValue) == 0)
        {
            ddown001b.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001b.BackColor = System.Drawing.Color.Empty;

        }

        //DropDownList tddown002b = (DropDownList)utab4.FindControl("ddown002b");

        if (Convert.ToInt32(ddown002b.SelectedValue) == 0)
        {
            ddown002b.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002b.BackColor = System.Drawing.Color.Empty;

        }

        //DropDownList tddown003b = (DropDownList)utab4.FindControl("ddown003b");
        if (Convert.ToInt32(ddown003b.SelectedValue) == 0)
        {
            ddown003b.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003b.BackColor = System.Drawing.Color.Empty;

        }

        return n;

    }

    #endregion




    protected void ddown002b_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown002b.SelectedValue == "1")
        {   
            ddown001b.SelectedValue = "65";     // SIN CONSUMO DE DROGAS
            ddown002b.Enabled = false;
            ddown001b.BackColor = System.Drawing.Color.Empty;

        }
        else
        {
            ddown002b.Enabled = true;
        }
        
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        btnGatilloCancelar.Visible = true;
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
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
