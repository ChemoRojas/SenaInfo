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
using System.Drawing;

public partial class mod_ninos_HechosJudiciales : System.Web.UI.Page
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
    public int VICodhjudiciales
    {
        get
        {
            if (ViewState["VICodhjudiciales"] == null)
            { ViewState["VICodhjudiciales"] = -1; }
            return Convert.ToInt32(ViewState["VICodhjudiciales"]);
        }
        set { ViewState["VICodhjudiciales"] = value; }
    }

    # endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial

        RangeValidator1.Validate();
        //mostrar_collapse(true);

        if (!IsPostBack)
        {
            CalendarExtende486.StartDate = SSninoDiag.fchingdesde;
            //cal001g.MinDate = SSninoDiag.fchingdesde;
            //btnGatilloCancelar.Style.Add("display", "none");
            CalendarExtende486.EndDate = DateTime.Now;
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
                imb_002g.Visible = false;
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
            
            imb_002g.Visible = false;
            grd001g.Columns[5].Visible = false;
        }

        //E2C81AB9-0504-4916-9CFB-798EA900151D 2.3_INGRESAR
        if (!window.existetoken("E2C81AB9-0504-4916-9CFB-798EA900151D"))
        {
            imb_001g.Visible = false;
        }

        //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER
        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            imb_004g.Visible = false;
        }

        #endregion
    }

    # region inserta diagnostico

    protected void imb_001g_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

  
        int tribunal;
        string Ruc;
        string Rit;
        string Observaciones;

        if (ddown001g.SelectedValue == "")
        {
            tribunal = 0;
        }
        else
        {
            tribunal = Convert.ToInt32(ddown001g.SelectedValue);
        }


        if (validatejudiciales() == true)
        {




            if (txt004g.Text.Trim() == "")
            {
                Ruc = "0";
            }
            else
            {
                Ruc = txt004g.Text.Trim();
            }
            if (txt005g.Text.Trim() == "")
            {
                Rit = "0";
            }
            else
            {
                Rit = txt005g.Text.Trim();
            }


            if (txt002g.Text.Trim() == "")
            {
                Observaciones = "SIN OBSERVACIONES";
            }
            else
            {
                Observaciones = txt002g.Text.Trim().ToUpper();
            }

            int inden = ncoll.Insert_DiagnosticoGeneral(9, SSninoDiag.CodNino,
                SSninoDiag.ICodIE, DateTime.Now);

            dcoll.Insert_HechosJudiciales(inden
                , Convert.ToDateTime(cal001g.Text)
                , tribunal
                , Convert.ToInt32(ddown002g.SelectedValue)
                , Convert.ToString(txt001g.Text.Trim())
                , Convert.ToInt32(chk001g.Checked)
                , Observaciones
                , Convert.ToInt32(chk002g.Checked)
                , Convert.ToInt32(chk003g.Checked)
                , Convert.ToInt32(chk004g.Checked)
                , Convert.ToString(ddown003g.SelectedValue)
                , SSninoDiag.CodInst
                , Convert.ToInt32(ddown003g.SelectedValue)
                , DateTime.Now
                , Convert.ToInt32(Session["IdUsuario"])
                , Ruc
                , Rit);

            clean_form();
            mostrar_collapse(false);
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);
        }
        else {
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
        
        
        }

        
        DataTable dt7 = dcoll.GetHechosJudiciales(SSninoDiag.ICodIE);
        DataView dv7 = new DataView(dt7);
        dv7.Sort = "FechaHechoJudicial DESC";
        grd001g.DataSource = dv7;
        grd001g.DataBind();
        grd001g.Visible = true;

       

        if (dv7.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis

        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis

        }


        //grd001g.Focus();

    }
    # endregion

    # region ActualizaDiagnostico

    protected void grd001g_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        diagnosticoscoll dcoll = new diagnosticoscoll();


        string ICodHJ = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VICodhjudiciales = Convert.ToInt32(ICodHJ);


        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
        VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);

        DataTable dt = dcoll.GetDiagnosticoHechosJudiciales(Convert.ToInt32(ICodHJ));




        if (dt.Rows.Count > 0)
        {


            cal001g.Text = Convert.ToDateTime(dt.Rows[0][0].ToString()).ToShortDateString();
            

            ddown005g.Items.FindByValue(ddown005g.SelectedValue).Selected = false;
            ddown005g.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;

            ddown006g.Items.FindByValue(ddown006g.SelectedValue).Selected = false;
            ddown006g.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;

            parcoll par = new parcoll();
            DataView dv39 = new DataView(par.GetparTribunalesHechosJudiciales(Convert.ToInt32(dt.Rows[0][1]), Convert.ToInt32(dt.Rows[0][2])));
            ddown001g.DataSource = dv39;
            ddown001g.DataTextField = "Descripcion";
            ddown001g.DataValueField = "CodTribunal";
            dv39.Sort = "CodTribunal";
            ddown001g.DataBind();

            ddown001g.Items.FindByValue(ddown001g.SelectedValue).Selected = false;
            ddown001g.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;

            ddown001g_2f.Items.FindByValue(ddown001g_2f.SelectedValue).Selected = false;
            ddown001g_2f.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;

            DataView dv40 = new DataView(par.GetparCausalesIngreso(ddown001g_2f.SelectedValue,SSninoDiag.CodProyecto));
            ddown002g.Items.Clear();
            ddown002g.DataSource = dv40;
            ddown002g.DataTextField = "Descripcion";
            ddown002g.DataValueField = "CodCausalIngreso";
            dv40.Sort = "Descripcion";
            ddown002g.DataBind();

            try
            {
                ddown002g.Items.FindByValue(ddown002g.SelectedValue).Selected = false;
                ddown002g.Items.FindByValue(dt.Rows[0][5].ToString()).Selected = true;
            }
            catch
            {
                ddown002g.SelectedIndex = 0;
            }

            txt001g.Text = Convert.ToString(dt.Rows[0][6]);

            txt004g.Text = dt.Rows[0][7].ToString();
            txt005g.Text = dt.Rows[0][8].ToString();

            if (Convert.ToBoolean(dt.Rows[0][9]) == true)
            {
                chk001g.Checked = true;
            }
            else
            {
                chk001g.Checked = false;
            }

            if (Convert.ToBoolean(dt.Rows[0][11]) == true)
            {
                chk002g.Checked = true;
            }
            else
            {
                chk002g.Checked = false;
            }
            if (Convert.ToBoolean(dt.Rows[0][12]) == true)
            {
                chk003g.Checked = true;
            }
            else
            {
                chk003g.Checked = false;
            }
            if (Convert.ToBoolean(dt.Rows[0][13]) == true)
            {
                chk004g.Checked = true;
            }
            else
            {
                chk004g.Checked = false;
            }

            txt002g.Text = dt.Rows[0][10].ToString();


            ddown003g.Items.FindByValue(ddown003g.SelectedValue).Selected = false;
            try
            {
                ddown003g.Items.FindByValue(dt.Rows[0][14].ToString()).Selected = true;
            }
            catch { }

            imb_001g.Visible = false;
            imb_002g.Visible = true;

        }
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide('fast');$('#btnGatilloCancelar').show('fast');", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        //grd001g.Focus();
    }
    protected void imb_002g_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

     
        int tribunal;
        string Ruc;
        string Rit;
        string Observaciones;

        if (ddown001g.SelectedValue == "")
        {
            tribunal = 0;
        }
        else
        {
            tribunal = Convert.ToInt32(ddown001g.SelectedValue);
        }


        if (validatejudiciales() == true)
        {


            if (txt002g.Text.Trim() == "")
            {
                txt002g.Text = "SIN OBSERVACION";
            }

            if (Convert.ToString(tribunal) == "")
            {
                tribunal = 0;
            }
            if (txt004g.Text.Trim() == "")
            {
                Ruc = "0";
            }
            else
            {
                Ruc = txt004g.Text.Trim();
            }
            if (txt005g.Text.Trim() == "")
            {
                Rit = "0";
            }
            else
            {
                Rit = txt005g.Text.Trim();
            }


            if (txt002g.Text.Trim() == "")
            {
                Observaciones = "SIN OBSERVACIONES";
            }
            else
            {
                Observaciones = txt002g.Text.Trim().ToUpper();
            }


            dcoll.Update_HechosJudiciales(VICodhjudiciales
                , VCod_diagnostico
                , Convert.ToDateTime(cal001g.Text)
                , tribunal
                , Convert.ToInt32(ddown002g.SelectedValue)
                , Convert.ToString(txt001g.Text.Trim())
                , Convert.ToBoolean(chk001g.Checked)
                , Observaciones
                , Convert.ToBoolean(chk002g.Checked)
                , Convert.ToBoolean(chk003g.Checked)
                , Convert.ToBoolean(chk004g.Checked)
                , Convert.ToInt32(ddown003g.SelectedValue)
                , SSninoDiag.CodInst
                , -1
                , DateTime.Now
                , Convert.ToInt32(Session["IdUsuario"])
                , Ruc
                , Rit);


            imb_001g.Visible = true;
            imb_002g.Visible = false;
            clean_form();
            mostrar_collapse(false);
            //gfontbrevis
            btnGatillo.Attributes.Remove("disabled");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 500 }, 500);", true);



        }
        else {
            mostrar_collapse(true);
            //gfontbrevis
            btnGatillo.Attributes.Add("disabled", "disabled");
        
        }

  
        DataTable dt7 = dcoll.GetHechosJudiciales(SSninoDiag.ICodIE);
        DataView dv7 = new DataView(dt7);
        dv7.Sort = "FechaHechoJudicial DESC";
        grd001g.DataSource = dv7;
        grd001g.DataBind();
        grd001g.Visible = true;

        
        if (dv7.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis

        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis

        }


        //grd001g.Focus();

    }

    # endregion

    # region Historico de Diagnosticos
    protected void imb_004g_Click(object sender, EventArgs e)
    {
        //window.open(this.Page, "ninos_HistoricoDiagnosticoHechosJudiciales.aspx", 770, 420);

    }
 

    # endregion

    #region volver

    protected void imb_005g_Click(object sender, EventArgs e)
    {
        //clean_form();

        //Response.Redirect("ninos_diagnosticoninos.aspx?param001=1");
    }

   
    # endregion

    #region validaciones

    protected void ddown006g_SelectedIndexChanged(object sender, EventArgs e)
    {
       


        int TipoTribunal = Convert.ToInt32(ddown005g.SelectedValue);
        int CodRegion = Convert.ToInt32(ddown006g.SelectedValue);

        parcoll par = new parcoll();
        DataView dv39 = new DataView(par.GetparTribunalesHechosJudiciales(TipoTribunal, CodRegion));
        ddown001g.DataSource = dv39;
        ddown001g.DataTextField = "Descripcion";
        ddown001g.DataValueField = "CodTribunal";
        dv39.Sort = "CodTribunal";
        ddown001g.DataBind();

        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
        
        //grd001g.Focus();
    }


    protected void ddown001g_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown001g_2f_SelectedIndexChanged(object sender, EventArgs e)
    {
        parcoll par = new parcoll();


        DataView dv40 = new DataView(par.GetparCausalesIngreso(ddown001g_2f.SelectedValue, SSninoDiag.CodProyecto));
        ddown002g.Items.Clear();
        ddown002g.DataSource = dv40;
        ddown002g.DataTextField = "Descripcion";
        ddown002g.DataValueField = "CodCausalIngreso";
        dv40.Sort = "Descripcion";
        ddown002g.DataBind();
        //grd001g.Focus();
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


     
        //cal001g.MaxDate = DateTime.Now;

        DataTable dt7 = dcoll.GetHechosJudiciales(SSninoDiag.ICodIE);
        DataView dv7 = new DataView(dt7);
        dv7.Sort = "FechaHechoJudicial DESC";
        grd001g.DataSource = dv7;
        grd001g.DataBind();
        grd001g.Visible = true;

        if (dv7.Count == 0)
        {
            lbl_nota2.Visible = true;//gfontbrevis
        }
        else
        {
            lbl_nota2.Visible = false;//gfontbrevis

        }


        
        DataView dv43 = new DataView(par.GetparTipoTribunal());
        ddown005g.Items.Clear();
        ddown005g.DataSource = dv43;
        ddown005g.DataTextField = "Descripcion";
        ddown005g.DataValueField = "TipoTribunal";
        dv43.Sort = "Descripcion";
        ddown005g.DataBind();

        DataView dv44 = new DataView(par.GetparRegion());
        ddown006g.Items.Clear();
        ddown006g.DataSource = dv44;
        ddown006g.DataTextField = "Descripcion";
        ddown006g.DataValueField = "Codregion";
        dv44.Sort = "Codregion";
        ddown006g.DataBind();


     
        DataView dv40_2f = new DataView(par.GetTipoCausal());

        ddown001g_2f.Items.Clear();
        ddown001g_2f.DataSource = dv40_2f;
        ddown001g_2f.DataTextField = "Descripcion";
        ddown001g_2f.DataValueField = "CodTipoCausalIngreso";
        dv40_2f.Sort = "Descripcion";
        ddown001g_2f.DataBind();


        
        DataView dv41 = new DataView(tcoll.GetTrabajadoresProyecto(Convert.ToString(SSninoDiag.CodProyecto)));
        ddown003g.Items.Clear();
        ddown003g.DataSource = dv41;
        ddown003g.DataTextField = "NombreCompleto";
        ddown003g.DataValueField = "ICodTrabajador";
        dv41.Sort = "NombreCompleto";
        ddown003g.DataBind();


    }

    #endregion

    # region Limpia Formulario
    protected void imb_003g_Click(object sender, EventArgs e)
    {
        clean_form();
        imb_002g.Visible = false;
        imb_001g.Visible = true;
        //grd001g.Focus();
        mostrar_collapse(true);
        //gfontbrevis
        btnGatillo.Attributes.Add("disabled", "disabled");
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowCancelar", "$('#btnGatillo').hide();$('#btnGatilloCancelar').show();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
    }

    private void clean_form()
    {
       
       ddown001g.SelectedIndex = 0;
       ddown001g_2f.SelectedValue = "0";
       ddown002g.SelectedValue = "0";
       ddown003g.SelectedValue = "0";
       ddown005g.SelectedValue = "0";
       ddown006g.SelectedValue = "-2";
          
    
       
          
        txt001g.Text = "";
        txt002g.Text = "";
        txt004g.Text = "";
        txt005g.Text = "";

        cal001g.Text = "";

        chk001g.Checked = false;
        chk002g.Checked = false;
        chk003g.Checked = false;
        chk004g.Checked = false;

        
        ddown005g.BackColor = System.Drawing.Color.Empty;
        ddown001g.BackColor = System.Drawing.Color.Empty;
        ddown001g_2f.BackColor = System.Drawing.Color.Empty;
        ddown002g.BackColor = System.Drawing.Color.Empty;
        ddown003g.BackColor = System.Drawing.Color.Empty;

    }

    # endregion

    #region Funciones del Formulario

    private bool validatejudiciales()
    {
        bool n = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (cal001g.Text == "Seleccione Fecha" || cal001g.Text == "")
        {

            cal001g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001g.BackColor = System.Drawing.Color.White;

        }




        if ((ddown005g.SelectedValue == "") || (ddown005g.SelectedValue == "0"))
        {
            ddown005g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown005g.BackColor = System.Drawing.Color.White;

        }

        if ((ddown006g.SelectedValue == "") || (ddown006g.SelectedValue == "0"))
        {
            ddown006g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown006g.BackColor = System.Drawing.Color.White;

        }




        if ((ddown001g.SelectedValue == "") || (ddown001g.SelectedValue == "0"))
        {
            ddown001g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001g.BackColor = System.Drawing.Color.White;

        }


        if ((ddown001g_2f.SelectedValue == "") || (ddown001g_2f.SelectedValue == "0"))
        {
            ddown001g_2f.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001g_2f.BackColor = System.Drawing.Color.White;

        }

        if ((ddown002g.SelectedValue == "") || (ddown002g.SelectedValue == "0"))
        {
            ddown002g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002g.BackColor = System.Drawing.Color.White;

        }


        if (ddown002g.SelectedValue == "0" || ddown002g.SelectedValue == "")
        {
            ddown002g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002g.BackColor = System.Drawing.Color.White;

        }

      

        if (Convert.ToInt32(ddown003g.SelectedValue) == 0)
        {
            ddown003g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003g.BackColor = System.Drawing.Color.White;

        }





        if (ddown005g.SelectedValue == "0" || ddown005g.SelectedValue == "")
        {
            ddown005g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown005g.BackColor = System.Drawing.Color.White;

        }



        if (ddown006g.SelectedValue == "0" || ddown006g.SelectedValue == "")
        {
            ddown006g.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown006g.BackColor = System.Drawing.Color.White;

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
