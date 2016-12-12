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
using regfaltas2TableAdapters;

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
    public int ICodIEGfalta
    {
        get { return (int)Session["ICodIEGfalta"]; }
        set { Session["ICodIEGfalta"] = value; }
    }
    public int icodfalta
    {
        get { return (int)Session["icodfalta"]; }
        set { Session["icodfalta"] = value; }
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
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    if (!window.existetoken("80B8FE09-8BC5-4738-90AB-A1C38DE50063"))
                    {
                        Response.Redirect("~/logout.aspx"); 
                    }
                    getinstituciones();
                    ddown001.SelectedValue = "6050";
                    ddown001.Enabled = false;
                    imb_lupainstitucion.Attributes.Add("disabled", "disabled");
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
                    }
                    if (Request.QueryString["icodie"] != null)
                    {
                        int IdCodiE = Convert.ToInt32(Request.QueryString["icodie"]);
                        CargoFaltas(IdCodiE);
                        CargaGrilla(txt001.Text.Trim());
                        grd001.Visible = true;
                        if (Session["proyecto_seleccionado"] != null)
                        {
                            ddown002.SelectedValue = Session["proyecto_seleccionado"].ToString();
                        }
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
        getproyectosxcod();
    }
    private void cargoProyectos()
    {
        ProyectosTableAdapter CargoProy = new ProyectosTableAdapter();
        DataTable DTproy = CargoProy.ProyectosLRPA(Convert.ToInt32(ddown001.SelectedValue));
        if (DTproy.Rows.Count > 0)
        {
            ddown002.DataSource = DTproy;
            ddown002.DataValueField = "CodProyecto";
            ddown002.DataTextField = "Nombre";
            ddown002.DataBind();
        }
        else
        {

        }
    }
    private void getproyectosxcod()
    {
        proyectocoll pcoll = new proyectocoll();
        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        dv.Sort = "Nombre";
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();

        if (dv.Count == 2)
        {
            ddown002.SelectedIndex = 1;
            ddown002_SelectedIndexChanged(new object(), new EventArgs());
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
        funcion_cargadatos();
    }
    private void funcion_cargadatos()
    {
        codProy = Convert.ToInt32(ddown002.SelectedValue);
        pintervencion pii = new pintervencion();
        DataTable dt = pii.GetNinosProyecto(Convert.ToInt32(ddown002.SelectedValue));
        DVNinos = new DataSet();
        DVNinos.Tables.Add(dt);
        CargaGrilla(txt001.Text.Trim());
        Session["proyecto_seleccionado"] = codProy;

        Proyectos1TableAdapter AnalizoProy = new Proyectos1TableAdapter();
        DataTable dtproy = AnalizoProy.GetDataBy_codProy(codProy);

        if (dtproy.Rows[0]["CodModeloIntervencion"].ToString() == "104" || dtproy.Rows[0]["CodModeloIntervencion"].ToString() == "100" || dtproy.Rows[0]["CodModeloIntervencion"].ToString() == "101")
        {
            if (grd001.Rows.Count > 0)
            {
                grd001.Visible = true;
                txt001.Enabled = true;
                LinkButton1.Attributes.Remove("disabled");

                grd002.Visible = false;
                pnl003.Visible = false;
                pnl004.Visible = true;
                lbl_Error.Text = "";
                lbl_Error.Visible = false;
                alert_lbl_error.Visible = false;
            }
            else
            {
                txt001.Enabled = false;
                LinkButton1.Attributes.Add("disabled", "disabled");

                grd001.Visible = false;
                grd002.Visible = false;
                pnl003.Visible = false;
                pnl004.Visible = false;
                lbl_Error.Text = "No existen datos para esta búsqueda";
                lbl_Error.Visible = true;
                alert_lbl_error.Visible = true;
            }
        }
        else
        {
            grd001.Visible = false;
            txt001.Enabled = false;
            LinkButton1.Attributes.Add("disabled", "disabled");
            grd002.Visible = false;
            pnl003.Visible = false;
            pnl004.Visible = false;
            lbl_Error.Text = "No existen datos para esta búsqueda";
            lbl_Error.Visible = true;
            alert_lbl_error.Visible = true;
        }



    }
    private void CargaGrilla(String Filtro)
    {
        DataSet dv = DVNinos;
        DataView dv2;

        if (Filtro.Trim() != "")
        {
            dv2 = new DataView(dv.Tables[0], "Apellido_Paterno = '" + Filtro.ToUpper() + "'", "Apellido_Paterno asc", DataViewRowState.CurrentRows);
            grd001.DataSource = dv2;
            //dv.Tables[0].DefaultView.RowFilter = "Apellido_Paterno LIKE '%" + Filtro.ToUpper() + "%'";
            //dv.Tables[0].Select("Apellido_Paterno LIKE '%" + Filtro.ToUpper() + "%'");
        }
        else
        {
            grd001.DataSource = dv;
            dv.Tables[0].DefaultView.Sort = "Apellido_Paterno";

            //dv.Tables[0].DefaultView.RowFilter = "Apellido_Paterno LIKE '%'";
        }
        grd001.DataBind();
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CargaGrilla(txt001.Text.Trim());
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla(txt001.Text.Trim());
    }
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Seleccionar")
        {
            CargaGrilla(txt001.Text.Trim());
            ninocoll nic = new ninocoll();
            ICodIEG = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            CODNINOG = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            FechaIngresoNino = Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
            CargoFaltas(ICodIEG);

            GridViewRow selectedRow = grd001.Rows[Convert.ToInt32(e.CommandArgument)];
            selectedRow.BackColor = System.Drawing.Color.LightGreen;
            ddown002.Enabled = false;
            txt001.Enabled = false;
            LinkButton1.Attributes.Add("disabled", "disabled");

            imb_lupaproyecto.Attributes.Add("disabled", "disabled");

        }
    }

    public void CargoFaltas(int codie)
    {
        Faltas1TableAdapter BuscarFalta = new Faltas1TableAdapter();
        //regfaltas BuscarFalta = new regfaltas();
        DataTable DTfaltas = BuscarFalta.GetData_By_icodie(codie);
        //DataTable DTfaltas2 = BuscarFalta.GetDataBy(ICodIEG);

        if (DTfaltas.Rows.Count > 0)
        {
            lbl_Error.Visible = false;
            alert_lbl_error.Visible = false;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ICodFalta");
            dt2.Columns.Add("ICodIE");
            dt2.Columns.Add("FechaEventoFalta");
            dt2.Columns.Add("EventoDescripcionFalta");
            dt2.Columns.Add("PresentaDenuncia");
            dt2.Columns.Add("FaltaCF");
            dt2.Columns.Add("Falta1");
            dt2.Columns.Add("Falta2");
            dt2.Columns.Add("Falta3");
            dt2.Columns.Add("Falta4");
            dt2.Columns.Add("Sancion1");
            dt2.Columns.Add("Sancion2");
            dt2.Columns.Add("Sancion3");
            dt2.Columns.Add("Sancion4");
            dt2.Columns.Add("Conflicto");

            for (int x = 0; x < DTfaltas.Rows.Count; x++)
            {
                DataRow dr = dt2.NewRow();
                dr[0] = DTfaltas.Rows[x][0].ToString();
                dr[1] = DTfaltas.Rows[x][1].ToString();
                dr[2] = DTfaltas.Rows[x][2].ToString().Substring(0, 10);
                dr[3] = DTfaltas.Rows[x][3].ToString();
                dr[4] = DTfaltas.Rows[x][4].ToString();
                dr[5] = DTfaltas.Rows[x][5].ToString();
                dr[6] = DTfaltas.Rows[x][6].ToString();
                dr[7] = DTfaltas.Rows[x][7].ToString();
                dr[8] = DTfaltas.Rows[x][8].ToString();
                dr[9] = DTfaltas.Rows[x][9].ToString();
                dr[10] = DTfaltas.Rows[x][10].ToString();
                dr[11] = DTfaltas.Rows[x][11].ToString();
                dr[12] = DTfaltas.Rows[x][12].ToString();
                dr[13] = DTfaltas.Rows[x][13].ToString();
                dr[14] = DTfaltas.Rows[x][14].ToString();
                dt2.Rows.Add(dr);
            }

            grd002.DataSource = dt2;
            grd002.DataBind();
            grd002.Visible = true;
            pnl003.Visible = true;
        }
        else
        {
            lbl_Error.Text = "No registra Infracciones Disciplinarias";
            lbl_Error.Visible = true;
            alert_lbl_error.Visible = true;
            grd002.Visible = false;
            pnl003.Visible = true;
            WebImageButton1.Visible = true;
            window.open(this.Page, "../mod_faltas/edit_falta.aspx?icodie=" + ICodIEG + "&codnino=" + CODNINOG + "&Existe=no&dir=../mod_faltas/registro_faltas.aspx", "Modificar", false, true, 680, 650, false, false, true);
        }
    }


    //protected void btn_actualizar_Click(object sender, EventArgs e)
    //{
    //    if (cal001.Text == "Seleccione Fecha" || txt007.Text == "" || ddown006.SelectedValue == "0" || ddown004.SelectedValue == "0")
    //    {
    //        funcion_check_ob();
    //    }
    //    else
    //    {
    //        if (txt002.Text.Trim() == "")
    //        {
    //            txt002.Text = "0";
    //        }
    //        if (txt003.Text.Trim() == "")
    //        {
    //            txt003.Text = "0";
    //        }
    //        if (txt004.Text == "")
    //        {
    //            txt004.Text = "0";
    //        }
    //        if (txt005.Text.Trim() == "")
    //        {
    //            txt005.Text = "0";
    //        }
    //        if (txt006.Text.Trim() == "")
    //        {
    //            txt006.Text = "0";
    //        }
    //        ninocoll nic = new ninocoll();
    //        nic.update_direccionninos(Convert.ToInt32(lbl001.Text) ,ICodIEG, Convert.ToDateTime(cal001.Value), txt007.Text.ToUpper(), txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(),
    //            txt005.Text.ToUpper(), Convert.ToInt32(txt006.Text), Convert.ToInt32(ddown004.SelectedValue));
    //        cal001.BackColor = System.Drawing.Color.White;
    //        txt007.BackColor = System.Drawing.Color.White;
    //        ddown006.BackColor = System.Drawing.Color.White; 
    //        ddown004.BackColor = System.Drawing.Color.White;
    //        funcion_limpiar();
    //        imb_cancelar.Visible = true;
    //        pnl001.Visible = true;
    //        pnl002.Visible = false;
    //        pnl003.Visible = false;
    //        pnl004.Visible = true;
    //    }        
    //}
    //protected void btn_limpiar_Click(object sender, EventArgs e)
    //{
    //    funcion_limpiar();
    //}
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
        string cadena = string.Empty;
        cadena = @" window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_faltas/registro_faltas.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    //protected void imb_cancelar_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../mod_ninos/index_ninos.aspx");
    //}
    protected void ddown006_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcomuna();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_faltas/registro_faltas.aspx", "Buscador", false, true, 770, 420, false, false, true);

    }
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //GridViewRow selectedRow = grd002.Rows[Convert.ToInt32(e.CommandArgument)];
        //selectedRow.BackColor = System.Drawing.Color.LightGreen;

        if (e.CommandName == "Modificar")
        {
            icodfalta = Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            ICodIEGfalta = Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);


            //window.open(this.Page, "../mod_faltas/edit_falta.aspx?icodfalta=" + icodfalta + "&icodie=" + ICodIEGfalta + "&codnino="+CODNINOG+"&Existe=si&dir=../mod_faltas/registro_faltas.aspx", "Modificar", false, true, 680, 650, false, false, true);

            iframe_agregar_infraccion.Src = "../mod_faltas/edit_falta.aspx?icodfalta=" + icodfalta + "&icodie=" + ICodIEGfalta + "&codnino=" + CODNINOG + "&Existe=si&dir=../mod_faltas/registro_faltas.aspx";
            iframe_agregar_infraccion.Attributes.Add("height", "600px");
            iframe_agregar_infraccion.Attributes.Add("width", "800px");

            mpe3.Show();
        }
        if (e.CommandName == "Eliminar")
        {
            icodfalta = Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            ICodIEGfalta = Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            //window.open(this.Page, "../mod_faltas/elimina_falta.aspx?icodfalta=" + icodfalta + "&icodie=" + ICodIEGfalta + "&codnino=" + CODNINOG + "&Existe=no&dir=../mod_faltas/registro_faltas.aspx", "Eliminar", false, true, 300, 170, false, false, true);

            iframe_agregar_infraccion.Src = "../mod_faltas/elimina_falta.aspx?icodfalta=" + icodfalta + "&icodie=" + ICodIEGfalta + "&codnino=" + CODNINOG + "&Existe=no&dir=../mod_faltas/registro_faltas.aspx";
            iframe_agregar_infraccion.Attributes.Add("height", "190px");
            iframe_agregar_infraccion.Attributes.Add("width", "400px");
            mpe3.Show();
        }

    }
    private void funcion_check_ob()
    {


        if (cal001.Text == "Seleccione Fecha")
        { cal001.BackColor = System.Drawing.Color.Pink; }
        else { cal001.BackColor = System.Drawing.Color.White; }
        if (txt007.Text == "")
        { txt007.BackColor = System.Drawing.Color.Pink; }
        else { txt007.BackColor = System.Drawing.Color.White; }
        if (ddown006.SelectedValue == "0")
        { ddown006.BackColor = System.Drawing.Color.Pink; }
        else { ddown006.BackColor = System.Drawing.Color.White; }
        if (ddown004.SelectedValue == "0")
        { ddown004.BackColor = System.Drawing.Color.Pink; }
        else { ddown004.BackColor = System.Drawing.Color.White; }




    }


    protected void ddown006_SelectedIndexChanged1(object sender, EventArgs e)
    {
        getcomuna();
    }
    //protected void WebImageButton2_Click(object sender, EventArgs e)
    //{
    //    funcion_limpiar();
    //    imb_cancelar.Visible = true;
    //    pnl001.Visible = true;
    //    pnl002.Visible = false;
    //    pnl003.Visible = false;
    //    pnl004.Visible = true;
    //}

    protected void grd002_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd002.PageIndex = e.NewPageIndex;
        CargoFaltas(ICodIEG);
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        iframe_agregar_infraccion.Src = "../mod_faltas/edit_falta.aspx?icodie=" + ICodIEG + "&codnino=" + CODNINOG + "&dir=../mod_faltas/registro_faltas.aspx&Existe=no";
        iframe_agregar_infraccion.Attributes.Add("height", "600px");
        iframe_agregar_infraccion.Attributes.Add("width", "800px");
        mpe3.Show();

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

            pnl001.Visible = true;
            pnl002.Visible = false;
            pnl003.Visible = false;
            pnl004.Visible = true;
        }
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

            pnl001.Visible = true;
            pnl002.Visible = false;
            pnl003.Visible = false;
            pnl004.Visible = true;

        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        funcion_limpiar();

        pnl001.Visible = true;
        pnl002.Visible = false;
        pnl003.Visible = false;
        pnl004.Visible = false;

        grd001.DataSource = null;
        grd001.DataBind();

        grd002.DataSource = null;
        grd002.DataBind();

        txt001.Text = "";
        txt001.Enabled = false;
        LinkButton1.Attributes.Add("disabled", "disabled");

        ddown002.SelectedValue = "0";
        alert_lbl_error.Visible = false;
        lbl_Error.Text = "";


        ddown002.Enabled = true;
        imb_lupaproyecto.Attributes.Remove("disabled");


    }   

    

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
}
