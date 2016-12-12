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

public partial class mod_institucion_reg_trabajadoresproy : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public int vCodPaso2
    {
        get { return (int)Session["vCodPaso2"]; }
        set { Session["vCodPaso2"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        //getprofesion();
        //se carga href para ventana modal
        //if ((lbl001.Text != "") && (Convert.ToInt16(ddown001.SelectedValue) > 0))
        //{
        //    A3.HRef = "../mod_instituciones/bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadoresproy.aspx" + "&codinst=" + ddown001.SelectedValue;
        //    imb001.Visible = true;
        //}
        //else
        //{
        //    imb001.Visible = false;
        //}

        //Session["vsParametro"] = "Registro de Trabajadores-Proyecto";
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("75E2E6CF-C6A2-4C32-A406-A862BCA719F8"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                getinstituciones();
                getproyecto();
                gettrabajadoresproyecto();
                getcargos();
                getprofesion();
                gettipocargo();
                getcausalegreso();

                if (Request.QueryString["sw"] == "1") // cuando llega desde el boton de búsqueda
                {
                    Get_Resultado_Busqueda(vCodPaso, vCodPaso2);
                    imb001.Visible = false;
                    imb_lupa_modal.Enabled = false;
                    LinkButton1.Enabled = false;
                }
                if (Request.QueryString["sw"] == "3")
                {

                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    getproyecto();
                    gettrabajadoresproyecto();
                }
                if (Request.QueryString["sw"] == "4")   
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyecto();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    gettrabajadoresproyecto();
                }
                if (Request.QueryString["sw"] == "5")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    if (Convert.ToInt32(Request.QueryString["codinst"]) == 0)
                    {
                        getinstituciones();
                        ddown001.SelectedValue = Request.QueryString["codinstitucion"];
                        getproyecto();
                        gettrabajadores();
                        ddown003.SelectedValue = Request.QueryString["codtrab"];


                    }
                    else
                    {

                        int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                        ddown001.SelectedValue = Convert.ToString(codinst);
                        getproyecto();
                        ddown002.SelectedValue = Request.QueryString["codinst"];
                        gettrabajadores();
                        ddown003.SelectedValue = Request.QueryString["codtrab"];
                    }
                    ddown001.Enabled = false;
                    ddown003.Enabled = false;
                }

                if ((wdc001.Text == "" || wdc001.Text == "Seleccione Fecha") && Request.QueryString["sw"] == "1") wdc001.Text = DateTime.Now.ToShortDateString();

                if ((Session["NNA"] != null) && (Request.QueryString["sw"] == null))
                {
                    oNNA NNA = (oNNA)Session["NNA"];

                    ddown001.SelectedValue = NNA.NNACodInstitucion;
                    getproyecto();
                    gettrabajadoresproyecto();
                    ddown002.SelectedValue = NNA.NNACodProyecto;
                    if (ddown003.SelectedValue != "" && ddown003.SelectedValue != "0")
                    {
                        funcion_check();
                    }
                }
                validatescurity();
            }

        }
    }
    private void validatescurity()
    {
        //46ADD4E0-BD61-49B8-802E-112A10A4724B 1.6_INGRESAR
        if (!window.existetoken("46ADD4E0-BD61-49B8-802E-112A10A4724B"))
        {

            WebImageButton1.Visible = false;
            //block();

        }
        //FA9FE7DD-EE09-4A0E-890C-8E1109B2009D 1.6_MODIFICAR
        if (!window.existetoken("FA9FE7DD-EE09-4A0E-890C-8E1109B2009D"))
        {

            WebImageButton4.Visible = false;
            //block();

        }

    }
    private void getinstituciones()
    {

        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();


    }
    private void getproyecto()
    {

        proyectocoll pcoll = new proyectocoll();

        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        dv.Sort = "CodProyecto";
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
    }
    private void gettrabajadoresproyecto()
    {

        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv = new DataView(tcoll.GetTrabajadoresProyectoInst(ddown001.SelectedValue));
        dv.Sort = "NombreCompleto";
        ddown003.DataSource = dv;
        ddown003.DataTextField = "NombreCompleto";
        ddown003.DataValueField = "ICodTrabajador";
        ddown003.DataBind();
    }

    private void gettrabajadores()
    {

        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv = new DataView(tcoll.GetTrabajadores2(ddown001.SelectedValue));
        dv.Sort = "Nombres";
        ddown003.DataSource = dv;
        ddown003.DataTextField = "NombreS";
        ddown003.DataValueField = "ICodTrabajador";
        ddown003.DataBind();
    }
    private void getcargos()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparCargo();
        ddown004.DataSource = dtproy;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "CodCargo";
        ddown004.DataBind();
    }
    private void gettipocargo()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparTipoCargo();
        ddown005.DataSource = dtproy;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "TipoCargo";
        ddown005.DataBind();
    }
    private void getprofesion()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparProfesionOficio();
        ddown006.DataSource = dtproy;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "CodProfesion";
        ddown006.DataBind();
    }
    private void getcausalegreso()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparCausalEgresoTrabajador();
        ddown007.DataSource = dtproy;
        ddown007.DataTextField = "Descripcion";
        ddown007.DataValueField = "CodCausalEgresoTrabajador";
        ddown007.DataBind();
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        //se carga href para ventana modal
        //if ((lbl001.Text != "") && (Convert.ToInt16(ddown001.SelectedValue) > 0))
        //{
        //    A3.HRef = "../mod_instituciones/bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadoresproy.aspx" + "&codinst=" + ddown001.SelectedValue;
        //    imb001.Visible = true;
        //}
        //else
        //{
        //    imb001.Visible = false;
        //}
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null)
        {
            NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
        }
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        Session["NNA"] = NNA;

        getproyecto();
        gettrabajadoresproyecto();
    }
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        funcion_check();
    }
    private void funcion_check()
    {
        trabajadorescoll tcoll = new trabajadorescoll();
        int val = tcoll.CheckExistTrab(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(ddown002.SelectedValue));
        if (val == 1)
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "La relación Trabajador-Proyecto en la Institución seleccionada ya existe.";
            lbl005.Attributes.Add("style", "");  
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Relacion", "alert('La relación Trabajador-Proyecto en la Institución seleccionada ya existe.');", true);
            //pnl003.Visible = true;
            //lbl004.Text = "La relación Trabajador-Proyecto en la Institución seleccionada ya existe";
            WebImageButton1.Visible = false;
        }
        else
        {
            //pnl003.Visible = false;
            WebImageButton1.Visible = true;

        }
        DataTable dtproy = tcoll.GetTrabajadoresProyectoInst(ddown001.SelectedValue);

        for (int i = 0; i < dtproy.Rows.Count; i++)
        {
            if (Convert.ToInt32(dtproy.Rows[i][0]) == Convert.ToInt32(ddown003.SelectedValue))
            {
                try
                {
                    ddown006.SelectedValue = Convert.ToString(dtproy.Rows[i][2]);
                }
                catch (Exception e)
                {
                    ddown006.SelectedValue = "0";
                }
            }

        }
        validatescurity();
    }


    public void Get_Resultado_Busqueda(int codtrabajador, int codproyecto)
    {
        string sParametrosConsulta = "Select T2.CodInstitucion,T1.IcodTrabajador,T1.CodProyecto,T1.FechaIngreso,T1.CodCargo,T1.TipoCargo," +
                              "T1.CodProfesion,T1.CodCausalEgresoTrabajador,T1.ResponsableIngreso,T1.FechaEgreso,T1.FechaUltimoIngresoEgreso," +
                              "T1.IndVigencia,T1.FechaActualizacion,T1.IdUsuarioActualizacion,T1.ResponsableEgreso " +
                              "From TrabajadorProyecto T1 inner join Proyectos T2 On T1.CodProyecto=T2.CodProyecto " +
                              "inner join  Trabajadores T3 On T1.ICodTrabajador = T3.ICodTrabajador Where " +
                              "T1.IcodTrabajador = " + codtrabajador + " and T1.CodProyecto = " + codproyecto;

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);
        while (datareader.Read())
        {
            try
            {
                ddown001.SelectedValue = Convert.ToString((int)datareader["CodInstitucion"]);
                ddown002.SelectedValue = "0";
                getproyecto();
                ddown002.SelectedValue = Convert.ToString((int)datareader["CodProyecto"]);
                gettrabajadores();
                ddown003.SelectedValue = Convert.ToString((int)datareader["ICodTrabajador"]);
                ddown004.SelectedValue = Convert.ToString((int)datareader["CodCargo"]);
                ddown005.SelectedValue = Convert.ToString((int)datareader["TipoCargo"]);
                ddown006.SelectedValue = Convert.ToString((int)datareader["CodProfesion"]);
                wdc001.Text = Convert.ToString((DateTime)datareader["FechaIngreso"]).Substring(0, 10);
                txt001.Text = (String)datareader["ResponsableIngreso"];
                if (!datareader["FechaEgreso"].Equals(System.DBNull.Value))
                {
                  wdc002.Text = Convert.ToString((DateTime)datareader["FechaEgreso"]).Substring(0, 10);
                }
                txt002.Text = (String)datareader["ResponsableEgreso"];
                ddown007.SelectedValue = Convert.ToString((int)datareader["CodCausalEgresoTrabajador"]);
                ddown008.SelectedValue = (String)datareader["IndVigencia"];

                WebImageButton1.Visible = false;
                WebImageButton4.Visible = true;
                validatescurity();
                ddown001.Enabled = false;
                ddown002.Enabled = false;
                ddown003.Enabled = false;
                ddown006.Enabled = false;
            }
            catch { }
        }
        con.Desconectar();

    }

    private void funcion_guardar()
        {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        try
        {
            if (ddown006.SelectedValue == "")
            {
                ddown006.SelectedValue = "0";
            }
        }
        catch (Exception)
        {
            ddown006.SelectedValue = "0";
        }

        if (ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown003.SelectedValue == "0" ||
           ddown004.SelectedValue == "0" || ddown005.SelectedValue == "0" || ddown006.SelectedValue == "0" ||
           wdc001.Text == null || txt001.Text == "")
        {
            if (ddown001.SelectedValue == "0")
            { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }
            if (ddown002.SelectedValue == "0")
            { ddown002.BackColor = colorCampoObligatorio; }
            else { ddown002.BackColor = System.Drawing.Color.White; }
            if (ddown003.SelectedValue == "0")
            { ddown003.BackColor = colorCampoObligatorio; }
            else { ddown003.BackColor = System.Drawing.Color.White; }
            if (ddown004.SelectedValue == "0")
            { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }
            if (ddown005.SelectedValue == "0")
            { ddown005.BackColor = colorCampoObligatorio; }
            else { ddown005.BackColor = System.Drawing.Color.White; }
            if (ddown006.SelectedValue == "0")
            { ddown006.BackColor = colorCampoObligatorio; }
            else { ddown006.BackColor = System.Drawing.Color.White; }
            if (wdc001.Text == null)
            { wdc001.BackColor = colorCampoObligatorio; }
            else { wdc001.BackColor = System.Drawing.Color.White; }
            if (txt001.Text == "")
            { txt001.BackColor = colorCampoObligatorio; }
            else { txt001.BackColor = System.Drawing.Color.White; }



        }

        else
        {
            //Añadir Try Catch en el ddown006

            int CodProfesion;
            int CodInstitucion = Convert.ToInt32(ddown001.SelectedValue);
            int CodProyecto = Convert.ToInt32(ddown002.SelectedValue);
            int ICodTrabajador = Convert.ToInt32(ddown003.SelectedValue);
            int CodCargo = Convert.ToInt32(ddown004.SelectedValue);
            int TipoCargo = Convert.ToInt32(ddown005.SelectedValue);
            try
            {
                CodProfesion = Convert.ToInt32(ddown006.SelectedValue);
            }
            catch (Exception ex)
            {
                CodProfesion = 0;
            }
            
            DateTime FechaIngreso = Convert.ToDateTime(wdc001.Text);
            string ResponsableIngreso = txt001.Text.ToUpper();
            DateTime FechaEgreso = Convert.ToDateTime("01-01-1900");
            if ((wdc002.Text != null) && (wdc002.Text != ""))
            {
                FechaEgreso = Convert.ToDateTime(wdc002.Text);
            }

            string ResponsableEgreso = "";
            if (txt002.Text != "")
            {
                ResponsableEgreso = txt002.Text.ToUpper();
            }
            int CodCausalEgreso = 0;
            if (ddown007.SelectedValue != "0")
            {
                CodCausalEgreso = Convert.ToInt32(ddown007.SelectedValue);
            }

            DateTime FechaUltimoIngresoEgreso = Convert.ToDateTime("01-01-1900");

            insert_instproy insup = new insert_instproy();
            int retorno = insup.Insert_Update_TrabajadorProyecto(ICodTrabajador, CodProyecto, FechaIngreso,
                          CodCargo, TipoCargo, CodProfesion, CodCausalEgreso, ResponsableIngreso, FechaEgreso, ResponsableEgreso, FechaUltimoIngresoEgreso,
                          ddown008.SelectedValue, Convert.ToInt32(Session["IdUsuario"]) /*USR*/);
            //int retorno = 0;
            if (retorno == 0)
              alerts2.Attributes.Add("style", "");
              lbl0052.Text = "Actualizado Correctamente.";
              lbl0052.Attributes.Add("style", "");  
              //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('Grabacion Correcta')", true);

            ddown001.BackColor = System.Drawing.Color.White;
            ddown002.BackColor = System.Drawing.Color.White;
            ddown003.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            ddown005.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            wdc001.BackColor = System.Drawing.Color.White;
            txt001.BackColor = System.Drawing.Color.White;
            
            funcion_limpiar2();
        }
    }

    private void funcion_limpiar2()
    {
      for (int j = 0; j < this.Controls.Count; j++)
      {
        for (int i = 0; i < this.Controls[j].Controls.Count; i++)
        {
          try
          {
            ((TextBox)this.Controls[j].Controls[i]).Text = "";
          }
          catch { }

        }

      }
      txt001.Text = null;
      //ddown002.Items.Clear();
      //ListItem item = new ListItem("Seleccionar","0");
      //ddown002.Items.Add(item);
      ddown001.SelectedValue = "0";
      ddown002.SelectedValue = "0";
      txt002.Text = "";
      wdc001.Text = null;
      wdc002.Text = null;
      ddown001.Enabled = true;
      ddown002.Enabled = true;
      ddown003.Enabled = true;
      ddown006.Enabled = true;
      WebImageButton1.Visible = true;
      WebImageButton4.Visible = false;
      //ddown003.SelectedIndex = 0;
      ddown003.SelectedValue = "0";
      ddown004.SelectedIndex = 0;
      ddown005.SelectedIndex = 0;
      try
      {
          ddown006.SelectedIndex = 0;
      }
      catch (Exception)
      {
          ddown006.SelectedValue = "0";
      }
      ddown007.SelectedIndex = 0;
      imb001.Visible = true;
      imb_lupa_modal.Enabled = true;
      LinkButton1.Enabled = true;
      //pnl003.Visible = false;
      validatescurity();

    }

    private void funcion_limpiar()
    {
        for (int j = 0; j < this.Controls.Count; j++)
        {
            for (int i = 0; i < this.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }

            }

        }
        txt001.Text = null;
        //ddown002.Items.Clear();
        //ListItem item = new ListItem("Seleccionar","0");
        //ddown002.Items.Add(item);
        ddown001.SelectedValue = "0";
        ddown002.SelectedValue = "0";
        txt002.Text = "";
        wdc001.Text = null;
        wdc002.Text = null;
        ddown001.Enabled = true;
        ddown002.Enabled = true;
        ddown003.Enabled = true;
        ddown006.Enabled = true;
        WebImageButton1.Visible = true;
        WebImageButton4.Visible = false;
        //ddown003.SelectedIndex = 0;
        ddown003.SelectedValue = "0";
        ddown004.SelectedIndex = 0;
        ddown005.SelectedIndex = 0;
        ddown006.SelectedIndex = 0;
        ddown007.SelectedIndex = 0;
        imb001.Visible = true;
        imb_lupa_modal.Enabled = true;
        LinkButton1.Enabled = true;
        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        //pnl003.Visible = false;
        validatescurity();

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_trabajadoresproy.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_trabajadoresproy.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null)
        {
            NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
        }
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        NNA.NNACodProyecto = ddown002.SelectedValue;
        Session["NNA"] = NNA; 

        if (ddown003.SelectedValue != "" && ddown003.SelectedValue != "0")
        {
            funcion_check();
        }
    }

    //protected void imb001_Click(object sender, EventArgs e)
    //{
    //    string etiqueta = lbl001.Text;
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&codinst=" + ddown001.SelectedValue + "', 'Buscador', false, false, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    //}
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }
   
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

    }
}
