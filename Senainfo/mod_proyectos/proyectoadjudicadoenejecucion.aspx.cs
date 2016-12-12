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

public partial class Proyectos_Default : System.Web.UI.Page
{
    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set { Session["neo_SSnino"] = value; }
    }

    public Boolean val2
    {
        get { return (Boolean)Session["val2"]; }
        set { Session["val2"] = value; }
    }

    public Boolean val
    {
        get { return (Boolean)Session["val"]; }
        set { Session["val"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Session["codProyecto"] = ddown002.SelectedValue.ToString();
       
        if (!IsPostBack)
        {
            val = false; val2 = false;

            if (rdo001.Checked)
            {
                val = rdo001.Checked;
            }
            else
            {
                val2 = rdo002.Checked;
            }

            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("49795519-1868-467C-8225-AFD99F8D2C27"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                getinstituciones();
                getdiasatencion();
                generaAno();
                //getproyectos();
                if (Request.QueryString["sw"] == "3")
                {
                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    if (val == true)
                    {
                        rdo001.Checked = val;
                        rdo002.Checked = false;
                    }
                    else if (val2 == true)
                    {
                        rdo001.Checked = false;
                        rdo002.Checked = val2;
                    }
                    getproyectos();
                }

                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    Resolucionescoll rcoll = new Resolucionescoll();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    int EstadoProyecto = rcoll.GetEstadoProyecto( Convert.ToInt32(Request.QueryString["codinst"]));
                    if (EstadoProyecto == 1)
                    {
                        rdo001.Checked = false;
                        rdo002.Checked = true;
                    }
                    else
                    {
                        rdo001.Checked = true;
                        rdo002.Checked = false;
                    }
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    funcion_cargaresolucion();
                }
                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }
    }

    private void validatescurity()
    {
        //0DBEB613-6AA1-4E68-BC00-2C836BEA6404 1.5_INGRESAR
        if (!window.existetoken("0DBEB613-6AA1-4E68-BC00-2C836BEA6404"))
        {
            btnGuardar_NEW.Visible = false;
            lnb001.Visible = false;
        }
        //304DAF27-8B43-4CFA-88C3-321A1A693562 1.5_MODIFICAR
        if (!window.existetoken("304DAF27-8B43-4CFA-88C3-321A1A693562"))
        {
           
        }
    }

    private void generaAno()
    {
        ddown010.Items.Clear();
        ListItem oItem = new ListItem(Convert.ToString(DateTime.Now.Year), Convert.ToString(DateTime.Now.Year));
        ListItem oItem2 = new ListItem(Convert.ToString(DateTime.Now.AddYears(-1).Year),Convert.ToString(DateTime.Now.AddYears(-1).Year));
        ddown010.Items.Add(oItem);
        ddown010.Items.Add(oItem2);
    }
  
    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        DataView dv1 = new DataView(icoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();
    }

    private Boolean adjudicado()
    {
        if (rdo001.Checked)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void getproyectos()
    {
        ddown002.Items.Clear();
        int estado;

        if (rdo001.Checked == true)
        {
            estado = 0;
        }
        else
        {
            estado = 1;
        }

        proyectocoll pcoll = new proyectocoll();
        // DataTable dtproy = pcoll.GetProyectoEstado(Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(adjudicado()));
        DataTable dtproy = pcoll.GetProyectoEstado(Convert.ToInt32(Session["IdUsuario"]), "V",Convert.ToInt32(ddown001.SelectedValue),estado);
        DataView dv;
        dv = new DataView(dtproy);
        dv.Sort = "CodProyecto";
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();

        
    }

    private void getdiasatencion()
    {
        parcoll pcoll = new parcoll();
        DataTable dtproy = pcoll.GetparDiasAtencion();

        ddown006.DataSource = dtproy;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "CodDiasAtencion";
        ddown006.DataBind();
    }

    //protected void btn001_Click(object sender, EventArgs e)
    //{

    //}

    protected void btn002_Click(object sender, EventArgs e)
    {
        Resolucionescoll rcoll = new Resolucionescoll();
        lblMsgSuccess.Visible = false;
        alertS.Visible = false;
        alertW.Visible = false;
        lblMsgWarning.Visible = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (txtNumResol.Text.Trim() == "" || ddown003.SelectedValue == "0" ||
           txtFecResol.Text == "" || txtFecConvenio.Text == "" || txtFecInicio.Text == "" ||
           txtFecTermino.Text == "" || txtCoberturas.Text.Trim() == "" || ddown001.SelectedValue == "0" || ddown002.SelectedValue=="0"||ddown002.SelectedValue=="" ||
            (txtMonto.Visible == true && txtMonto.Text.Trim() == "" ))
        {
            if (txtNumResol.Text.Trim() == "") { txtNumResol.BackColor = colorCampoObligatorio; }
            else { txtNumResol.BackColor = System.Drawing.Color.White; }
            if (ddown003.SelectedValue == "0") { ddown003.BackColor = colorCampoObligatorio; }
            else { ddown003.BackColor = System.Drawing.Color.White; }
            if (txtFecResol.Text == "") { txtFecResol.BackColor = colorCampoObligatorio; }
            else { txtFecResol.BackColor = System.Drawing.Color.White; }
            if (txtFecConvenio.Text == "") { txtFecConvenio.BackColor = colorCampoObligatorio; }
            else { txtFecConvenio.BackColor = System.Drawing.Color.White; }
            if (txtFecInicio.Text == "") { txtFecInicio.BackColor = colorCampoObligatorio; }
            else { txtFecInicio.BackColor = System.Drawing.Color.White; }
            if (txtFecTermino.Text == "") { txtFecTermino.BackColor = colorCampoObligatorio; }
            else { txtFecTermino.BackColor = System.Drawing.Color.White; }
            if (txtCoberturas.Text.Trim() == "") { txtCoberturas.BackColor = colorCampoObligatorio; }
            else { txtCoberturas.BackColor = System.Drawing.Color.White; }
            if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }
            if (ddown002.SelectedValue == "0") { ddown002.BackColor = colorCampoObligatorio; }
            else { ddown002.BackColor = System.Drawing.Color.White; }
            if (txtMonto.Text.Trim() == "") { txtMonto.BackColor = colorCampoObligatorio; }
            else { txtMonto.BackColor = System.Drawing.Color.White; }
            
            alertW.Visible = true;
            lblMsgWarning.Visible = true;
           
        }
        else
        {
            int nplazasad = 0;
            if (txtPlazasAdic.Text.Trim() != "") { nplazasad = Convert.ToInt32(txtPlazasAdic.Text); }
            int perplazas = 0;
            if(txtPorcPlazasAsignadas.Text.Trim() !=""){ perplazas=Convert.ToInt32(txtPorcPlazasAsignadas.Text); }
            int monto = 0;
            if(txtMonto.Text.Trim() != "") {monto = Convert.ToInt32(txtMonto.Text);}
            int msubatencion = 0;
            if (txtMesSubAtencion.Text.Trim() != "") { msubatencion = Convert.ToInt32(txtMesSubAtencion.Text); }
            int netapas = 0;
            if (txtNumEtapas.Text.Trim() != "") { netapas = Convert.ToInt32(txtNumEtapas.Text); }

            DateTime FechaTermino = Convert.ToDateTime("01-01-1900").Date;
            if (txtFecTermino.Text != "")
            {
                FechaTermino = Convert.ToDateTime(txtFecTermino.Text);
            }
            int CodProyecto = Convert.ToInt32(ddown002.SelectedValue);

            rcoll.Insert_Resoluciones(CodProyecto, Convert.ToInt32(ddown010.SelectedValue), txtNumResol.Text.ToUpper(),
                Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown006.SelectedValue), Convert.ToDateTime(txtFecResol.Text),
                txtMateria.Text.ToUpper(), Convert.ToDateTime(txtFecConvenio.Text), Convert.ToDateTime(txtFecInicio.Text), Convert.ToDateTime(txtFecTermino.Text),netapas,
                Convert.ToInt32(txtCoberturas.Text.Trim()),nplazasad,perplazas, ddown003.SelectedValue,
                ddown004.SelectedValue, msubatencion, ddown008.SelectedValue, monto, "V", DateTime.Now, Convert.ToInt32(Session["IdUsuario"])/*usr*/);


            rcoll.update_proyecto_resolucion(CodProyecto, FechaTermino, Convert.ToInt32(txtCoberturas.Text));
            
            if (rdo001.Checked == true)
            {
                rcoll.Update_EstadoProyecto( CodProyecto);
                rdo002.Checked = true;
                rdo001.Checked = false;
                funcion_cargaresolucion();
            }
            lblMsgSuccess.Visible = true;
            alertS.Visible = true;
            
            funcion_limpiar();
        }
    }

    private string vigencia()
    {
        string dtime;

        if (Convert.ToDateTime(txtFecTermino.Text).Date <= DateTime.Now.Date)
        {
            dtime = Convert.ToString('V');
        }
        else
        {
            dtime = Convert.ToString('C');
        }
        return dtime;
    }

    private string sexo()
    {
        string sexo;
        sexo = Convert.ToString('M');
        
        return sexo;
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();

        if (Session["codProyecto"] != null && Session["codProyecto"] != "")
        {
            ddown002.SelectedValue = Session["codProyecto"].ToString();
        }
    }

    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnGuardar_NEW.Visible = true;
    }

    protected void rdo001_CheckedChanged(object sender, EventArgs e)
    {
        string dd1value = ddown001.SelectedValue;
        funcion_limpiar();
        ddown001.SelectedValue = dd1value;
        if (ddown001.SelectedValue != "0")
        {
            getproyectos();
        }
    }

    protected void rdo002_CheckedChanged(object sender, EventArgs e)
    {
        string dd1value = ddown001.SelectedValue;
        funcion_limpiar();
        ddown001.SelectedValue = dd1value;
        if (ddown001.SelectedValue != "0")
        {
            getproyectos();
        }
    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        funcion_cargaresolucion();
    }

    private void funcion_cargaresolucion()
    {
        Resolucionescoll rcoll = new Resolucionescoll();
        int tiposubvencion = rcoll.GetTipoSubvencionxProyecto( Convert.ToInt32(ddown002.SelectedValue));
        if (tiposubvencion == 12)
        {
            lbl002.Visible = true;
            txtMonto.Visible = true;
            trlbl002.Visible = true;
        }
        else
        {
            lbl002.Visible = false;
            txtMonto.Visible = false;
            trlbl002.Visible = false;
        }

        ddown003.Items.Clear();
        if (rdo001.Checked == true)
        {
            ddown003.Items.Add(new ListItem("Seleccionar","0"));
            ddown003.Items.Add(new ListItem("Apertura", "A"));
        }
        else
        {
            ddown003.Items.Add(new ListItem("Seleccionar", "0"));
            ddown003.Items.Add(new ListItem("Modificación", "M"));
            ddown003.Items.Add(new ListItem("Término", "T"));
            ddown003.Items.Add(new ListItem("Urgencia", "U"));
        }
       
        DataView dv1 = new DataView(rcoll.GetTipoResolucionxProyInst(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue)));

        if (dv1.Table.Rows.Count > 0)
        {
            txtNumResol.Visible = false;
            ddown007.Visible = true;
            //dv1.Sort = 
            ddown007.DataSource = dv1;
            ddown007.DataTextField = "NumeroResolucion";
            ddown007.DataValueField = "ICodResolucion";
            //dv1.Sort = "NumeroResolucion";
            ddown007.DataBind();

            buscaresolucion();

            btnGuardar_NEW.Visible = false;
        }
        bloquea_dias();
    }

    private void bloquea_dias()
    {
        proyectocoll pcol = new proyectocoll();
        DataTable dt = pcol.GetProyectos( ddown002.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][10].ToString() == "15")
            {
                ddown006.SelectedValue = "1";
                ddown006.Enabled = false;
            }
            else
            {
                ddown006.Enabled = true;
            }
        }
    }

    protected void ddown007_SelectedIndexChanged(object sender, EventArgs e)
    {
        buscaresolucion();
    }

    private void buscaresolucion()
    {
        ddown003.Items.Clear();
        ddown003.Items.Add(new ListItem("Seleccionar", "0"));
        ddown003.Items.Add(new ListItem("Apertura", "A"));
        ddown003.Items.Add(new ListItem("Modificación", "M"));
        ddown003.Items.Add(new ListItem("Término", "T"));
        ddown003.Items.Add(new ListItem("Urgencia", "U"));

        Resolucionescoll rcoll = new Resolucionescoll();
        DataTable dt = rcoll.GetResolucionxIcod(Convert.ToInt32(ddown007.SelectedValue));

        if (dt.Rows.Count > 0)
        {
            lnb001.Visible = true;

            ddown010.Items.Clear();
            ListItem oItem = new ListItem(Convert.ToString(dt.Rows[0][2]), Convert.ToString(dt.Rows[0][2]));
            ddown010.Items.Add(oItem);

        ddown003.SelectedValue = Convert.ToString(dt.Rows[0][15]);
        txtFecResol.Text = Convert.ToString(dt.Rows[0][6]).Substring(0,10);
        //txtFecResol.Text = txtFecResol.Text.Remove(11);
        //txtFecResol.Text.Replace(" ", "");

        txtMateria.Text = Convert.ToString(dt.Rows[0][7]);
        txtFecConvenio.Text = Convert.ToString(dt.Rows[0][8]).Substring(0,10);
        //txtFecConvenio.Text = txtFecConvenio.Text.Remove(11);
        //txtFecConvenio.Text.Replace(" ", "");

        txtFecInicio.Text = Convert.ToString(dt.Rows[0][9]).Substring(0,10);
        //txtFecInicio.Text = txtFecInicio.Text.Remove(11);
        //txtFecInicio.Text.Replace(" ", "");
        try
        {
            txtFecTermino.Text = Convert.ToString(dt.Rows[0][10]).Substring(0,10);
        }
        catch
        {
            txtFecTermino.Text = null;
        }
        //txtFecTermino.Text = txtFecTermino.Text.Remove(11);
        //txtFecTermino.Text.Replace(" ", "");

        txtCoberturas.Text = Convert.ToString(dt.Rows[0][12]);
        txtPlazasAdic.Text = Convert.ToString(dt.Rows[0][13]);
        txtPorcPlazasAsignadas.Text = Convert.ToString(dt.Rows[0][14]);
        ddown006.SelectedValue = Convert.ToString(dt.Rows[0][5]);
        txtMonto.Text = Convert.ToString(dt.Rows[0][19]);
        ddown004.SelectedValue = Convert.ToString(dt.Rows[0][16]);
        ddown008.SelectedValue = Convert.ToString(dt.Rows[0][18]);
        txtNumEtapas.Text = Convert.ToString(dt.Rows[0][11]);
        txtMesSubAtencion.Text = Convert.ToString(dt.Rows[0][17]);

        ddown001.Enabled = false;
        ddown002.Enabled = false;
        rdo001.Enabled = false;
        rdo002.Enabled = false;

        btnGuardar_NEW.Visible = true;

        btnLimpiar_NEW.Visible = true;

        ddown010.Enabled = false;
        txtNumResol.ReadOnly = true;
        txtMateria.ReadOnly = true;
        txtCoberturas.ReadOnly = true;
        txtPlazasAdic.ReadOnly = true;
        txtPorcPlazasAsignadas.ReadOnly = true;
        txtMonto.ReadOnly = true;
        txtNumEtapas.ReadOnly = true;

        ddown003.Enabled = false;
        ddown004.Enabled = false;
        ddown006.Enabled = false;
        ddown008.Enabled = false;

        txtFecResol.ReadOnly = true;
        txtFecConvenio.ReadOnly = true;
        txtFecInicio.ReadOnly = true;
        txtFecTermino.ReadOnly = true;
        
         if (Convert.ToInt32(dt.Rows[0][11]) > 0)
                {
                    grv001.Visible = true;
                    lbl001.Visible = true;
                    trlbl001.Visible = true;

                    DataTable DT2 = rcoll.GetEtapasResolucionxCod(Convert.ToInt32(dt.Rows[0][0]));

                    grv001.DataSource = DT2;
                    grv001.DataBind();
                }
                else
                {
                    grv001.Visible = false;
                    lbl001.Visible = false;
                    trlbl001.Visible = false;
                }
        }
        validatescurity();
    }

    private void funcion_limpiar()
    {
        rdo001.Enabled = true;
        rdo002.Enabled = true;
        ddown002.Items.Clear();
        //btnGuardar_NEW.Visible = false;
        btnLimpiar_NEW.Visible = true;
        txtNumResol.Visible = true;
        ddown007.Visible = false;

        ddown010.Enabled = true;
        txtNumResol.ReadOnly = false;
        txtMateria.ReadOnly = false;
        txtCoberturas.ReadOnly = false;
        txtPlazasAdic.ReadOnly = false;
        txtPorcPlazasAsignadas.ReadOnly = false;
        txtMonto.ReadOnly = false;
        txtNumEtapas.ReadOnly = false;

        ddown001.Enabled = true;
        ddown002.Enabled = true;
        ddown003.Enabled = true;
        ddown004.Enabled = true;
       
        ddown006.Enabled = true;
        ddown008.Enabled = true;

        txtFecResol.ReadOnly = false;
        txtFecConvenio.ReadOnly = false;
        txtFecInicio.ReadOnly = false;
        txtFecTermino.ReadOnly = false;

        
        txtNumResol.Text = "";
        txtMateria.Text = "";
        txtCoberturas.Text = "";
        txtPlazasAdic.Text = "";
        txtPorcPlazasAsignadas.Text = "";
        txtMonto.Text = "";
        txtNumEtapas.Text = "";
        txtMesSubAtencion.Text = "";
        txtMonto.Visible = false;
        lbl002.Visible = false;
        lbl003.Visible = false;
        trlbl002.Visible = false;
        ddown001.SelectedIndex = 0;

        if (ddown002.SelectedIndex > -1)
        {
            ddown002.SelectedIndex = 0;
        }
        if (ddown003.SelectedIndex > -1)
        {
            ddown003.SelectedIndex = 0;
        }
        ddown004.SelectedIndex = 0;
       
        ddown006.SelectedIndex = 0;
        if (ddown007.SelectedIndex > -1)
        {
            ddown007.SelectedIndex = 0;
        }
        ddown008.SelectedIndex = 0;

        grv001.Visible = false;
        lbl001.Visible = false;
        trlbl001.Visible = false;

        txtFecResol.Text = string.Empty;
        txtFecConvenio.Text = string.Empty;
        txtFecInicio.Text = string.Empty;
        txtFecTermino.Text = string.Empty;

        ddown010.BackColor = System.Drawing.Color.White; 
        txtNumResol.BackColor = System.Drawing.Color.White; 
        ddown003.BackColor = System.Drawing.Color.White; 
        txtFecResol.BackColor = System.Drawing.Color.White; 
        txtFecConvenio.BackColor = System.Drawing.Color.White; 
        txtFecInicio.BackColor = System.Drawing.Color.White; 
        txtFecTermino.BackColor = System.Drawing.Color.White; 
        txtCoberturas.BackColor = System.Drawing.Color.White; 

        ddown001.BackColor = System.Drawing.Color.White;
        ddown002.BackColor = System.Drawing.Color.White;
    }

    //protected void WebImageButton3_Click(object sender, EventArgs e)
    //{
    //    nuevaresolucion();
    //}

    private void nuevaresolucion()
    {
        generaAno();
        ddown003.Items.Clear();
        ddown003.Items.Add(new ListItem("Seleccionar", "0"));
        ddown003.Items.Add(new ListItem("Modificación", "M"));
        ddown003.Items.Add(new ListItem("Término", "T"));
        ddown003.Items.Add(new ListItem("Urgencia", "U"));

        lnb001.Visible = false;
        btnLimpiar_NEW.Visible = true;
        btnGuardar_NEW.Visible = false;
        txtNumResol.Visible = true;
        ddown007.Visible = false;
        ddown010.Enabled = true;
        txtNumResol.ReadOnly = false;
        txtMateria.ReadOnly = false;
        txtCoberturas.ReadOnly = false;
        txtPlazasAdic.ReadOnly = false;
        txtPorcPlazasAsignadas.ReadOnly = false;
        txtMonto.ReadOnly = false;
        txtNumEtapas.ReadOnly = false;
       
        ddown003.Enabled = true;
        ddown004.Enabled = true;
        
        ddown006.Enabled = true;
        ddown008.Enabled = true;

        txtFecResol.ReadOnly = false;
        txtFecConvenio.ReadOnly = false;
        txtFecInicio.ReadOnly = true;
        txtFecTermino.ReadOnly = false;
        grv001.Visible = false;
        lbl001.Visible = false;
            trlbl001.Visible=false;

        // JOVM - 19/01/2015
        //cal004.MinDate = Convert.ToDateTime(txtFecInicio.Text).AddDays(1);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ddown007.SelectedIndex = 0;
        buscaresolucion();
        nuevaresolucion();
        bloquea_dias();
    }

    //protected void lbn_buscar_institucion_Click(object sender, EventArgs e)
    //{
    //    val = false;
    //    val2 = false;
    //    if (rdo001.Checked)
    //    {
    //        val = rdo001.Checked;
    //    }
    //    else
    //    {
    //        val2 = rdo002.Checked;
    //    }

    //    iframe_bsc_institucion.Src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx";
    //    iframe_bsc_institucion.Attributes.Add("height", "300px");
    //    iframe_bsc_institucion.Attributes.Add("width", "760px");
    //    iframe_bsc_institucion.Visible = true;
    //    mpe1.Show();
    //}

    //protected void WebImageButton3_Click1(object sender, EventArgs e)
    //{
    //    Response.Redirect("../mod_instituciones/index_instituciones.aspx");
    //}

    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    val = false;
    //    val2 = false;
    //    if (rdo001.Checked)
    //    {
    //        val = rdo001.Checked;
    //    }
    //    else
    //    {
    //        val2 = rdo002.Checked;
    //    }
    //    string etiqueta = "Plan de Intervencion";
    //    string cadena = string.Empty;
    //    cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}

    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    string cadena = string.Empty;
    //    cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
    
    /*-----------------------------------------------------------------------------------------
    // 15/01/2015
    // Se agregan las siguientes VOID que reemplazarán a los originales que se encuentran 
    // asociados a Infragistics.
    // Se usa el mismo nombre de las VOID originales y se agrega el sufijo "NEW"
    // para su diferenciación.
    //-----------------------------------------------------------------------------------------*/

    //protected void btnVolver_Click_NEW(object sender, EventArgs e)
    //{
    //    Response.Redirect("../mod_instituciones/index_instituciones.aspx");
    //}

    protected void btnLimpiar_Click_NEW(object sender, EventArgs e)
    {
        //Response.Redirect("proyectoadjudicadoenejecucion.aspx");
        funcion_limpiar();
    }

    private bool rangoFechas()
    {
        DateTime FecInicio = DateTime.Parse(txtFecInicio.Text);
        DateTime FecTermino = DateTime.Parse(txtFecTermino.Text);
        int result = DateTime.Compare(FecInicio, FecTermino);

        if (result < 0)
        {
            //f1 es anterior a f2
            return true;
        }
        else if (result == 0)
        {
            //f1 es igual que f2
            return true;
        }
        else
        {
            //f1 es posterior a f2
            return false;
        }
    }

    protected void btnGuardar_Click_NEW(object sender, EventArgs e)
    {
        Resolucionescoll rcoll = new Resolucionescoll();
        lblMsgSuccess.Visible = false;
        alertS.Visible = false;
        alertW.Visible = false;
        lblMsgWarning.Visible = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (txtNumResol.Text.Trim() == "" || ddown003.SelectedValue == "0" ||
           txtFecResol.Text.Trim() == "" || txtFecConvenio.Text.Trim()== "" || txtFecInicio.Text.Trim() == "" ||
           txtFecTermino.Text.Trim() == "" || txtCoberturas.Text.Trim() == "" || ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown002.SelectedValue == "" ||
            (txtMonto.Visible == true && txtMonto.Text.Trim() == "")  || lb_fi.Visible == true)
        {
            if (txtNumResol.Text.Trim() == "") { txtNumResol.BackColor = colorCampoObligatorio; }
            else { txtNumResol.BackColor = System.Drawing.Color.White; }
            if (ddown003.SelectedValue == "0") { ddown003.BackColor = colorCampoObligatorio; }
            else { ddown003.BackColor = System.Drawing.Color.White; }
            if (txtFecResol.Text.Trim()== "") { txtFecResol.BackColor = colorCampoObligatorio; }
            else { txtFecResol.BackColor = System.Drawing.Color.White; }
            if (txtFecConvenio.Text.Trim() == "") { txtFecConvenio.BackColor = colorCampoObligatorio; }
            else { txtFecConvenio.BackColor = System.Drawing.Color.White; }
            if (txtFecInicio.Text.Trim() == "") { txtFecInicio.BackColor = colorCampoObligatorio; }
            else { txtFecInicio.BackColor = System.Drawing.Color.White; }
            if (txtFecTermino.Text.Trim() == "") { txtFecTermino.BackColor = colorCampoObligatorio; }
            else { txtFecTermino.BackColor = System.Drawing.Color.White; }
            if (txtCoberturas.Text.Trim() == "") { txtCoberturas.BackColor = colorCampoObligatorio; }
            else { txtCoberturas.BackColor = System.Drawing.Color.White; }
            if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }
            if (ddown002.SelectedValue == "0") { ddown002.BackColor = colorCampoObligatorio; }
            else { ddown002.BackColor = System.Drawing.Color.White; }
            if (txtMonto.Text.Trim() == "") { txtMonto.BackColor = colorCampoObligatorio; }
            else { txtMonto.BackColor = System.Drawing.Color.White; }
            
            alertW.Visible = true;
            lblMsgWarning.Visible = true;
        }
        else
        {
            int nplazasad = 0;
            if (txtPlazasAdic.Text.Trim() != "") { nplazasad = Convert.ToInt32(txtPlazasAdic.Text); }
            int perplazas = 0;
            if (txtPorcPlazasAsignadas.Text.Trim() != "") { perplazas = Convert.ToInt32(txtPorcPlazasAsignadas.Text); }
            int monto = 0;
            if (txtMonto.Text.Trim() != "") { monto = Convert.ToInt32(txtMonto.Text); }
            int msubatencion = 0;
            if (txtMesSubAtencion.Text.Trim() != "") { msubatencion = Convert.ToInt32(txtMesSubAtencion.Text); }
            int netapas = 0;
            if (txtNumEtapas.Text.Trim() != "") { netapas = Convert.ToInt32(txtNumEtapas.Text); }

            DateTime FechaTermino = Convert.ToDateTime("01-01-1900").Date;
            if (txtFecTermino.Text != "")
            {
                FechaTermino = Convert.ToDateTime(txtFecTermino.Text);
            }
            int CodProyecto = Convert.ToInt32(ddown002.SelectedValue);

            rcoll.Insert_Resoluciones(CodProyecto, Convert.ToInt32(ddown010.SelectedValue), txtNumResol.Text.ToUpper(),
                Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown006.SelectedValue), Convert.ToDateTime(txtFecResol.Text),
                txtMateria.Text.ToUpper(), Convert.ToDateTime(txtFecConvenio.Text), Convert.ToDateTime(txtFecInicio.Text), Convert.ToDateTime(txtFecTermino.Text), netapas,
                Convert.ToInt32(txtCoberturas.Text.Trim()), nplazasad, perplazas, ddown003.SelectedValue,
                ddown004.SelectedValue, msubatencion, ddown008.SelectedValue, monto, "V", DateTime.Now, Convert.ToInt32(Session["IdUsuario"])/*usr*/);

            rcoll.update_proyecto_resolucion(CodProyecto, FechaTermino, Convert.ToInt32(txtCoberturas.Text));

            if (rdo001.Checked == true)
            {
                rcoll.Update_EstadoProyecto(CodProyecto);
                rdo002.Checked = true;
                rdo001.Checked = false;
                funcion_cargaresolucion();
            }
            lblMsgSuccess.Visible = true;
            alertS.Visible = true;
            
            funcion_limpiar();
        }
    }

    protected void txtNumResol_TextChanged(object sender, EventArgs e)
    {
        Resolucionescoll rcol = new Resolucionescoll();

        lbl003.Visible = false;
        if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "" || txtNumResol.Text.Trim() == "")
        {
            if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
            {
                lbl003.Text = "- Debe seleccionar un proyecto.<br>";
            }
            if (txtNumResol.Text.Trim() == "")
            {
                lbl003.Text += "- Debe ingresar número de Resolución.";
            }
            lbl003.Visible = true;
        }
        else
        {
            lbl003.Visible = false;
            int val = rcol.CheckResolExiste(txtNumResol.Text.Trim(), Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown010.SelectedValue));

            if (val > 0)
            {
                lbl003.Text = "El número de resolución ingresado ya existe.";
                lbl003.Visible = true;
                btnGuardar_NEW.Visible = false;
            }
            else
            {
                lbl003.Visible = false;
                btnGuardar_NEW.Visible = true;
            }

        }
    }

    protected void txtFecInicio_TextChanged(object sender, EventArgs e)
    {
        if (txtFecInicio.Text != "" && txtFecTermino.Text != "")
        {
            if (!comparaFechas())
            {
                lb_fi.Visible = true;
            }
            else
            {
                lb_fi.Visible = false;
            }
        }
        if (txtFecInicio.Text != "")
        {
            //// JOVM - 19/01/2015
            ////cal004.MinDate = Convert.ToDateTime(cal003.Value).AddDays(1);
            ////cal003.BackColor = System.Drawing.Color.White;
        }
    }

    protected void txtFecTermino_TextChanged(object sender, EventArgs e)
    {
        lblMsgSuccess.Visible = false;
        alertS.Visible = false;
        alertW.Visible = false;
        lblMsgWarning.Visible = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (txtFecInicio.Text != "" && txtFecTermino.Text != "")
        {
            if (!comparaFechas())
            {
                lb_fi.Visible = true;
            }
            else
            {
                lb_fi.Visible = false;
            }
        }

        if (txtFecInicio.Text != "")
        {
            txtFecInicio.BackColor = System.Drawing.Color.White;
            btnGuardar_NEW.Visible = true;
        }
        else
        {
            txtFecInicio.BackColor = colorCampoObligatorio;
            btnGuardar_NEW.Visible = false;
            txtFecTermino.Text = null;
            alertW.Visible = true;
            lblMsgWarning.Visible = true;
        }
    }

    public bool comparaFechas()
    {
        string fi_text = txtFecInicio.Text;
        DateTime fi = Convert.ToDateTime(fi_text);
        string ft_text = txtFecTermino.Text;
        DateTime ft = Convert.ToDateTime(ft_text);

        if (fi > ft)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}