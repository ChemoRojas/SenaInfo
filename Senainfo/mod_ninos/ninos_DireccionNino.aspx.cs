/*
 * GMP 
 * 22/05/2015
 * no tiene windows.open, agregué reloj, validaciones de fecha, no exporta a excel, validaciones de formato de teléfonos
 * 
 * 
 * 
 */
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


public partial class mod_ninos_ninos_DireccionNino : System.Web.UI.Page
{
    public DataSet DVNinos
    {
        get { return (DataSet)Session["DVNinos"]; }
        set { Session["DVNinos"] = value; }
    }
    public int ICodIEG
    {
        get { return (int)Session["ICodIEG"]; }
        set { Session["ICodIEG"] = value; }
    }
    public int CODNINOG
    {
        get { return (int)Session["CODNINOG"]; }
        set { Session["CODNINOG"] = value; }
    }

    public int codProy
    {
        get { return (int)Session["codProy"]; }
        set { Session["codProy"] = value; }
    }

    private DateTime FechaIngresoNino
    {
        get { return (DateTime)Session["FechaIngresoNino"]; }
        set { Session["FechaIngresoNino"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        RangeValidator1.MinimumValue = DateTime.Today.AddYears(-100).ToShortDateString();
        RangeValidator1.MaximumValue = DateTime.Today.ToShortDateString();

        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                if (!window.existetoken("6F447A62-BF21-4ADA-A29D-FC485AA5CE70"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                getinstituciones();
                getproyectosxcod();
                getregion();
                getcomuna();
                if (Request.QueryString["sw"] == "3")
                {
                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    getproyectosxcod();
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectosxcod();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    funcion_cargadatos();
                    Session["NNA"] = null;
                }
                if (Session["NNA"] != null)
                {
                    oNNA NNA = (oNNA)Session["NNA"];

                    ddown001.SelectedValue = NNA.NNACodInstitucion;
                    getproyectosxcod();
                    ddown002.SelectedValue = NNA.NNACodProyecto;
                    funcion_cargadatos();
                }
                validatescurity();
            }
        }
    }
    private void validatescurity()
    {
        //3A094373-D07C-4400-9718-F1840C8B6B27 2.11_INGRESAR
        if (!window.existetoken("3A094373-D07C-4400-9718-F1840C8B6B27"))
        {
            btn_guardar.Visible = false;
            WebImageButton1.Visible = false;
        }
        //5130E3E3-AA03-4F0E-AFB5-0EA1941A9A87 2.11_MODIFICAR
        if (!window.existetoken("5130E3E3-AA03-4F0E-AFB5-0EA1941A9A87"))
        {
            btn_actualizar.Visible = false;
        }
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null)
        {
            NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
        }
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        Session["NNA"] = NNA;

        getproyectosxcod();
    }
    private void getproyectosxcod()
    {
        proyectocoll pcoll = new proyectocoll();
        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        dv.Sort = "Nombre";
        // <---------- DPL ---------->  09-08-2010
        //dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        try
        {
            ddown002.DataBind();
            if (dv.Count == 2)
            {
                ddown002.SelectedIndex = 1;
                ddown002_SelectedIndexChanged(new object(), new EventArgs());
            }
        }
        catch
        {
            lblError.Visible = true;
            txt001.Text = "";
            ddown001.SelectedIndex = 0;
            ddown002.SelectedIndex = 0;
            txt001.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
        }
    }
    private void getregion()
    {


        //parcoll par = new parcoll();
        // DataView dv1000 = new DataView(par.GetparRegion());
        // ddown004.DataSource = dv1000;
        // ddown004.DataTextField = "Descripcion";
        // ddown004.DataValueField = "CodRegion";
        // dv1000.Sort = "CodRegion";
        // ddown004.DataBind();




        parcoll par = new parcoll();
        DataView dv1001 = new DataView(par.GetparRegion());
        ddown006.DataSource = dv1001;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "CodRegion";
        dv1001.Sort = "CodRegion";
        ddown006.DataBind();


    }
    private void getcomuna()
    {
        if (Convert.ToInt32(ddown006.SelectedValue) != 0)
        {

            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddown006.SelectedValue));
            ddown004.Items.Clear();
            ddown004.DataSource = dv6;
            ddown004.DataTextField = "Descripcion";
            ddown004.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddown004.DataBind();


        }
        else
        {
            //ddown006.Items.Clear();
        }
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

        funcion_cargadatos();
    }
    private void funcion_cargadatos()
    {
        try
        {
            codProy = Convert.ToInt32(ddown002.SelectedValue);
            pintervencion pii = new pintervencion();
            DataTable dt = pii.GetNinosProyecto(Convert.ToInt32(ddown002.SelectedValue));

            DVNinos = new DataSet();
            DVNinos.Tables.Add(dt);


            CargaGrilla(txt001.Text.Trim(), TextBox1.Text.Trim(), TextBox2.Text.Trim());

            if (grd001.Rows.Count > 0)
            {

                grd001.Visible = true;
                txt001.Enabled = true;
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                pnl003.Visible = false;
                pnl004.Visible = true;

                //ddown002.Enabled = false;
                //ddown001.Enabled = false;
            }
            else
            {

                //ddown002.Enabled = true;
                //ddown001.Enabled = true;
                txt001.Enabled = false;
            }
        }
        catch
        {
            lbl001.Visible = true;
        }

    }
    //Nuevo filtro con 3 campos (Filtro -> Apellido Paterno, Filtro1 -> Nombres, Filtro2 -> Apellido Materno)
    private void CargaGrilla(String Filtro, String Filtro1, String Filtro2)
    {

        //DataSet dv = DVNinos;
        ////grd001.Page.Items.Clear();
        //if (Filtro.Trim() != "")
        //{
        //  dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '" + Filtro.ToUpper() + "%'";
        //}
        //else
        //{
        //  dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '%'";
        //}
        //dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        //grd001.DataSource = dv.Tables[0].DefaultView;
        //grd001.DataBind();  
        //lblTitNinVigentes.Visible = (dv.Tables[0].Rows.Count > 0);

        DataSet dv = DVNinos;

        String rowFilterQuery;

        rowFilterQuery = "";


        if (Filtro.Trim() != "" || Filtro1.Trim() != "" || Filtro2.Trim() != "")
        {
            if (Filtro.Trim() != "")
            {
                rowFilterQuery = "Apellido_paterno LIKE '%" + Filtro.ToUpper().Trim() + "%'";
            }

            if (Filtro2.Trim() != "")
            {
                if (rowFilterQuery.Length > 0)
                    rowFilterQuery = rowFilterQuery + " and ";

                rowFilterQuery = "Apellido_materno LIKE '%" + Filtro2.ToUpper().Trim() + "%'";
            }

            if (Filtro1.Trim() != "")
            {
                if (rowFilterQuery.Length > 0)
                    rowFilterQuery = rowFilterQuery + " and ";

                rowFilterQuery = "Nombres LIKE '%" + Filtro1.ToUpper().Trim() + "%'";
            }
            dv.Tables[0].DefaultView.RowFilter = rowFilterQuery;
        }
        else
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '%'";
            dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        }

        grd001.DataSource = dv.Tables[0].DefaultView;
        grd001.DataBind();

        ////Esto es lo que se debe añadir para formatear la tabla
        //grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        //grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        if (grd001.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "reflowHeader", "$('#grd001').floatThead('reflow');", true);
            
            
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#grd001').dataTable();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { $('#grd001').DataTable({ searching: true, sort: false, paging: false, fixedHeader: true }); });", true);


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
        ddown001.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dv1.Count > 0)
            ddown001.SelectedIndex = 0;
        // <---------- DPL ---------->  09-08-2010
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        funcion_cargadatos();
        //CargaGrilla(txt001.Text.Trim(), TextBox1.Text.Trim(), TextBox2.Text.Trim());
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla(txt001.Text.Trim(), TextBox1.Text.Trim(), TextBox2.Text.Trim());
    }
    private void CargaDirecciones(int ICodIEG)
    {
        ninocoll nic = new ninocoll();
        DataTable dt = nic.GetDireccionNinos(ICodIEG);


        if (dt.Rows.Count > 0)
        {

            grd002.DataSource = dt;
            grd002.DataBind();
            pnl003.Visible = true;
            grd002.Visible = true;
            ddown001.Enabled = false;
            imb_lupa_modal_proyecto.Enabled = false;
            ddown002.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            txt001.Enabled = false;
            //gfontbrevis: ocultar  columnas telefono, fax, mail para evitar overflow (ojo despues de databind)
            grd002.Columns[2].Visible = false;
            grd002.Columns[3].Visible = false;
            grd002.Columns[4].Visible = false;
            grd002.Columns[5].Visible = false;




            for (int i = 0; i < grd002.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i][11]) == 1)
                    //grd002.Rows[i].Cells[11].Enabled = false;
                    grd002.Rows[i].Cells[11].Enabled = true;

                for (int j = 0; j < grd002.Columns.Count; j++)
                {
                    if (grd002.Rows[i].Cells[j].Text == "0") grd002.Rows[i].Cells[j].Text = "";
                }
            }
        }
        else
        {
            grd002.Visible = false;
            pnl003.Visible = true;
        }

    }
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //int index = Convert.ToInt32(e.CommandArgument);
        //GridViewRow gvRow = grd001.Rows[index];
        //int icodieg = Convert.ToInt32(gvRow.Cells[1].Text);
        //int cod_nino_g = Convert.ToInt32(gvRow.Cells[0].Text);
        //DateTime fechaing = Convert.ToDateTime(gvRow.Cells[7].Text);

        if (e.CommandName == "Seleccionar")
        {
            CargaGrilla(txt001.Text.Trim(), TextBox1.Text.Trim(), TextBox2.Text.Trim());

            pnlCorrecto.Visible = false;
            lblCorrecto.Visible = false;
            pnlError.Visible = false;
            lblAlertError.Visible = false;

            ICodIEG = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            CODNINOG = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            FechaIngresoNino = Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
            grd001.Rows[Convert.ToInt32(e.CommandArgument)].BackColor = System.Drawing.Color.SkyBlue;
            LinkButton1.Enabled = false;
            imb_lupa_modal_proyecto.Enabled = false;
            imb_lupa_modal_proyecto.Attributes.Add("disabled", "true");
            imb_lupa_modal.Attributes.Add("disabled", "true");

            //LinkButton1.Attributes.Add("disabled", "true");
            LinkButton1.Visible = false;


            CargaDirecciones(ICodIEG);
            //
            //Ejecuta Modal con los datos cargados
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#myButton').click();", true);
            pnl002.Visible = false;
            cal001.BackColor = Color.White;
            txt007.BackColor = Color.White;
            ddown004.BackColor = Color.White;



        }
    }
    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (cal001.Text == "Seleccione Fecha" || txt007.Text == "" || ddown006.SelectedValue == "0" || ddown004.SelectedValue == "0")
        {
            funcion_check_ob();
        }
        else
        {
            if (txt002.Text.Trim() == "")
            {
                txt002.Text = "0";
            }
            if (txt003.Text.Trim() == "")
            {
                txt003.Text = "0";
            }
            if (txt004.Text == "")
            {
                txt004.Text = "0";
            }
            if (txt005.Text.Trim() == "")
            {
                txt005.Text = "0";
            }
            if (txt006.Text.Trim() == "")
            {
                txt006.Text = "0";
            }
            ninocoll nic = new ninocoll();
            nic.update_direccionninos(Convert.ToInt32(lbl001.Text), ICodIEG, Convert.ToDateTime(cal001.Text), txt007.Text.ToUpper(), txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(),
                txt005.Text.ToUpper(), Convert.ToInt32(txt006.Text), Convert.ToInt32(ddown004.SelectedValue));
            cal001.BackColor = System.Drawing.Color.White;
            txt007.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            funcion_limpiar();
            //imb_cancelar.Visible = true;
            pnl001.Visible = true;
            pnl002.Visible = false;
            CargaDirecciones(ICodIEG);
            btnLimpiar.Visible = true;
            LinkButton1.Visible = true;
            pnl004.Visible = true;
            btn_guardarDireccion.Visible = false;
            pnlError.Visible = false;
            lblAlertError.Visible = false;
            pnlCorrecto.Visible = true;
            lblCorrecto.Visible = true;
            lblCorrecto.Text = "Se ha actualizado correctamente";
            tituloModal.Text = "Agregar o Actualizar Direcciones";
            //imb_lupa_modal.Style.Remove("disabled");

        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }
    private void funcion_limpiar()
    {
        cal001.Text = null;
        txt007.Text = String.Empty;
        ddown004.SelectedIndex = 0;
        ddown006.SelectedIndex = 0;
        txt002.Text = String.Empty;
        txt003.Text = String.Empty;
        txt004.Text = String.Empty;
        txt005.Text = String.Empty;
        txt006.Text = String.Empty;


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_DireccionNino.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void ddown006_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcomuna();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_DireccionNino.aspx", "Buscador", false, true, 770, 420, false, false, true);

    }
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {

            pnlError.Visible = false;
            lblAlertError.Visible = false;
            pnlCorrecto.Visible = false;
            lblCorrecto.Visible = false;
            CalendarExtende771.StartDate = FechaIngresoNino;
            CalendarExtende771.EndDate = DateTime.Now;

            cal001.Text = Convert.ToDateTime(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text).ToShortDateString();
            txt007.Text = Server.HtmlDecode(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            txt002.Text = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
            txt003.Text = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
            txt004.Text = Server.HtmlDecode(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
            txt005.Text = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            txt006.Text = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
            lbl001.Text = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;
            parcoll par = new parcoll();
            getregion();
            int codRegion = par.Getregionxcomuna(Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text));
            if (ddown006.Items.FindByValue(Convert.ToString(codRegion)) != null)
            {
                ddown006.SelectedValue = Convert.ToString(codRegion);

                getcomuna();

            }
            if (ddown004.Items.FindByValue(Convert.ToString(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text)) != null)
            {
                ddown004.SelectedValue = Convert.ToString(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
            }

            pnl001.Visible = true;
            pnl003.Visible = false;
            pnl002.Visible = true;
            pnl004.Visible = true;
            LinkButton1.Visible = false;
            //btnLimpiar.Visible = false;
            btn_actualizar.Visible = true;
            btn_guardar.Visible = false;
            btn_guardarDireccion.Visible = false;
            validatescurity();
            //imb_cancelar.Visible = false;
            tituloModal.Text = "Actualizar Direcciones";
        }

    }
    private void funcion_check_ob()
    {

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (cal001.Text == "")
        { cal001.BackColor = colorCampoObligatorio; }
        else { cal001.BackColor = System.Drawing.Color.White; }
        if (txt007.Text == "")
        { txt007.BackColor = colorCampoObligatorio; }
        else { txt007.BackColor = System.Drawing.Color.White; }
        if (ddown006.SelectedValue == "0")
        { ddown006.BackColor = colorCampoObligatorio; }
        else { ddown006.BackColor = System.Drawing.Color.White; }
        if (ddown004.SelectedValue == "0")
        { ddown004.BackColor = colorCampoObligatorio; }
        else { ddown004.BackColor = System.Drawing.Color.White; }

        pnlError.Visible = true;
        lblAlertError.Visible = true;
        lblAlertError.Text = "Faltan datos para continuar";




    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (cal001.Text == "Seleccione Fecha" || txt007.Text == "" || ddown006.SelectedValue == "0" || ddown004.SelectedValue == "0")
        {
            funcion_check_ob();
        }
        else
        {
            if (txt002.Text.Trim() == "")
            {
                txt002.Text = "0";
            }
            if (txt003.Text.Trim() == "")
            {
                txt003.Text = "0";
            }
            if (txt004.Text == "")
            {
                txt004.Text = "0";
            }
            if (txt005.Text.Trim() == "")
            {
                txt005.Text = "0";
            }
            if (txt006.Text.Trim() == "")
            {
                txt006.Text = "0";
            }

            ninocoll nic = new ninocoll();
            nic.insert_direccionninos(ICodIEG, codProy, CODNINOG, Convert.ToDateTime(cal001.Text), txt007.Text.ToUpper(), txt002.Text.ToUpper(),
                txt003.Text.ToUpper(), txt004.Text.ToUpper(), txt005.Text.ToUpper(), Convert.ToInt32(txt006.Text), Convert.ToInt32(ddown004.SelectedValue), 0, DateTime.Now,
                Convert.ToInt32(Session["IdUsuario"])/*usr*/, "V");

            cal001.BackColor = System.Drawing.Color.White;
            txt007.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            funcion_limpiar();
            //imb_cancelar.Visible = true;
            pnl001.Visible = true;
            pnl002.Visible = false;
            CargaDirecciones(ICodIEG);
            pnl004.Visible = true;
            tituloModal.Text = "Agregar o Actualizar Direcciones";

        }
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        //imb_cancelar.Visible = false;
        pnl001.Visible = true;
        pnl003.Visible = false;
        pnl002.Visible = true;
        pnl004.Visible = true;
        btn_actualizar.Visible = false;
        btn_guardarDireccion.Visible = true;
        btn_guardar.Visible = false;
        //btnLimpiar.Visible = false;
        LinkButton1.Visible = false;
        validatescurity();
        cal001.Text = null;
        txt007.Text = "";
        ddown004.SelectedIndex = 0;
        ddown006.SelectedIndex = 0;
        txt002.Text = "";
        txt003.Text = "";
        txt004.Text = "";
        txt005.Text = "";
        txt006.Text = "";
        txt007.Text = "";
        pnlCorrecto.Visible = false;
        pnlError.Visible = false;
        lblAlertError.Visible = false;
        lblCorrecto.Visible = false;
        CalendarExtende771.StartDate = FechaIngresoNino;
        CalendarExtende771.EndDate = DateTime.Now;
        tituloModal.Text = "Ingreso de Nueva Dirección";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
    }

    protected void ddown006_SelectedIndexChanged1(object sender, EventArgs e)
    {
        getcomuna();
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
        //imb_cancelar.Visible = true;
        pnl001.Visible = true;
        pnl002.Visible = false;
        pnl003.Visible = false;
        pnl004.Visible = true;
        btnLimpiar.Visible = true;
        LinkButton1.Visible = true;
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        grd001.Visible = false;
        txt001.Text = "";
        //ddown001.SelectedIndex = 0;
        //ddown002.SelectedIndex = 0;
        ddown001.Enabled = true;
        ddown002.Enabled = true;
        txt001.Enabled = false;
        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        lblError.Visible = false;
        pnl003.Visible = false;
        imb_lupa_modal_proyecto.Attributes.Remove("disabled"); imb_lupa_modal.Attributes.Remove("disabled");
        //LinkButton1.Attributes.Remove("disabled");
        LinkButton1.Visible = true;
        LinkButton1.Enabled = true;

    }

    protected void imb_lupa_modal_proyecto_Click(object sender, EventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_Direccionnino.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
        //imb_cancelar.Visible = true;
        pnl001.Visible = true;
        pnl002.Visible = false;
        pnl003.Visible = true;
        pnl004.Visible = true;
        btnLimpiar.Visible = true;
        LinkButton1.Visible = true;
        btn_guardarDireccion.Visible = true;
    }
    protected void btn_guardarDireccion_Click(object sender, EventArgs e)
    {
        if (cal001.Text == "Seleccione Fecha" || txt007.Text == "" || ddown006.SelectedValue == "0" || ddown004.SelectedValue == "0")
        {
            funcion_check_ob();
        }
        else
        {
            if (txt002.Text.Trim() == "")
            {
                txt002.Text = "0";
            }
            if (txt003.Text.Trim() == "")
            {
                txt003.Text = "0";
            }
            if (txt004.Text == "")
            {
                txt004.Text = "0";
            }
            if (txt005.Text.Trim() == "")
            {
                txt005.Text = "0";
            }
            if (txt006.Text.Trim() == "")
            {
                txt006.Text = "0";
            }

            pnlError.Visible = false;
            lblAlertError.Visible = false;

            ninocoll nic = new ninocoll();
            nic.insert_direccionninos(ICodIEG, codProy, CODNINOG, Convert.ToDateTime(cal001.Text), txt007.Text.ToUpper(), txt002.Text.ToUpper(),
                txt003.Text.ToUpper(), txt004.Text.ToUpper(), txt005.Text.ToUpper(), Convert.ToInt32(txt006.Text), Convert.ToInt32(ddown004.SelectedValue), 0, DateTime.Now,
                Convert.ToInt32(Session["IdUsuario"])/*usr*/, "V");

            cal001.BackColor = System.Drawing.Color.White;
            txt007.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            funcion_limpiar();
            //imb_cancelar.Visible = true;
            pnl001.Visible = true;
            pnl002.Visible = false;
            CargaDirecciones(ICodIEG);
            pnl004.Visible = true;
            
        }
    }

    //protected void btnSeleccionar_Click1(object sender, EventArgs e)
    //{
    //  GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
    //  int index = gvRow.RowIndex;
    //  ICodIEG = Convert.ToInt32(gvRow.Cells[1].Text);
    //  CODNINOG = Convert.ToInt32(gvRow.Cells[0].Text);
    //  FechaIngresoNino = Convert.ToDateTime(gvRow.Cells[7].Text);

    //  CargaDirecciones(ICodIEG);
    //}
}