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

public partial class mod_ninos_Egreso_Direccion : System.Web.UI.Page
{



    private int ICODIE
    {
        get { return (int)ViewState["ICODIE"]; }
        set { ViewState["ICODIE"] = value; }
    }
    public int CODNINOG
    {
        get { return (int)ViewState["CODNINOG"]; }
        set { ViewState["CODNINOG"] = value; }
    }

    public int codProy
    {
        get { return (int)ViewState["codProy"]; }
        set { ViewState["codProy"] = value; }
    }

    private DateTime FechaIngresoNino
    {
        get { return (DateTime)ViewState["FechaIngresoNino"]; }
        set { ViewState["FechaIngresoNino"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        //    {
        //        Response.Redirect("~/logout.aspx");
        //    }
        //else
        //{
        if (!IsPostBack)
        {
            //    if (!window.existetoken("6F447A62-BF21-4ADA-A29D-FC485AA5CE70"))
            //    {
            //        Response.Redirect("~/logout.aspx");
            //    }
            //lbl003.Text = NNA.NNAFechaIngreso;
            //lbl004.Text = NNA.NNAFechaNacimiento;
            //CargaTabs();

            if (Session["NNA"] != null)
            {
                oNNA NNA = (oNNA)Session["NNA"];



                ICODIE = Convert.ToInt32(NNA.NNACodIE);
                CODNINOG = Convert.ToInt32(NNA.NNACodNino);
                codProy = Convert.ToInt32(NNA.NNACodProyecto);
                FechaIngresoNino = Convert.ToDateTime(NNA.NNAFechaIngreso);


                //ICODIE = Convert.ToInt32(Request.QueryString["V1"]);
                //CODNINOG = Convert.ToInt32(Request.QueryString["V2"]);
                //codProy = Convert.ToInt32(Request.QueryString["V3"]);
                //FechaIngresoNino = Convert.ToDateTime(Request.QueryString["V4"]);               

                //Button agregar

                GetData();
                pnl003.Visible = true;
                pnl002.Visible = false;
            }
        }
        //}
    }
    private void validatescurity()
    {
        //3A094373-D07C-4400-9718-F1840C8B6B27 2.11_INGRESAR
        //if (!window.existetoken("3A094373-D07C-4400-9718-F1840C8B6B27"))
        //{
        //    btn_guardar.Visible = false;
        //    WebImageButton1.Visible = false;
        //}
        ////5130E3E3-AA03-4F0E-AFB5-0EA1941A9A87 2.11_MODIFICAR
        //if (!window.existetoken("5130E3E3-AA03-4F0E-AFB5-0EA1941A9A87"))
        //{
        //    btn_actualizar.Visible = false;
        //}
    }


    private void getregion()
    {
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

    private void GetData()
    {
        ninocoll nic = new ninocoll();

        //CODNINOG = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        //FechaIngresoNino = Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
        DataTable dt = nic.GetDireccionNinos(ICODIE);

        grd002.DataSource = dt;
        grd002.DataBind();
        pnl003.Visible = true;
        grd002.Visible = true;

        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i][11]) == 1)
            {
                grd002.Rows[i].Cells[11].Enabled = false;
            }


        }
        if (grd002.Rows.Count > 10)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader", "fixHeader('#grd002', '#tableHeader');", true);
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
            nic.update_direccionninos(Convert.ToInt32(lbl001.Text), ICODIE, Convert.ToDateTime(cal001.Text), txt007.Text.ToUpper(), txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(),
                txt005.Text.ToUpper(), Convert.ToInt32(txt006.Text), Convert.ToInt32(ddown004.SelectedValue));
            cal001.BackColor = System.Drawing.Color.White;
            txt007.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            funcion_limpiar();


            pnl002.Visible = false;
            pnl003.Visible = false;

            GetData();
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
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_DireccionNino.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //}
    protected void imb_cancelar_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);
        //window.close(Page);
    }
    protected void ddown006_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcomuna();
    }
    // GMP (22/05/2015): no se utiliza 
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_DireccionNino.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            CalendarExtende856.StartDate = FechaIngresoNino;
            //cal001.MinDate = FechaIngresoNino;
            CalendarExtende856.EndDate = DateTime.Now;
            //cal001.MaxDate = DateTime.Now;
            cal001.Text = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
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


            pnl003.Visible = false;
            pnl002.Visible = true;

            btn_actualizar.Visible = true;
            btn_guardar.Visible = false;
            validatescurity();

        }

    }
    private void funcion_check_ob()
    {

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis similar a #F3E12A con 60% de opacidad

        if (cal001.Text == "Seleccione Fecha")
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
            nic.insert_direccionninos(ICODIE, codProy, CODNINOG, Convert.ToDateTime(cal001.Text), txt007.Text.ToUpper(), txt002.Text.ToUpper(),
                txt003.Text.ToUpper(), txt004.Text.ToUpper(), txt005.Text.ToUpper(), Convert.ToInt32(txt006.Text), Convert.ToInt32(ddown004.SelectedValue), 0, DateTime.Now,
                1/*usr*/, "V");

            cal001.BackColor = System.Drawing.Color.White;
            txt007.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            funcion_limpiar();


            pnl002.Visible = false;
            pnl003.Visible = false;

            GetData();
        }
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        getregion();
        getcomuna();
        GetData();

        btn_actualizar.Visible = false;
        btn_guardar.Visible = true;
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
        CalendarExtende856.StartDate = FechaIngresoNino;
        //cal001.MinDate = FechaIngresoNino;
        CalendarExtende856.EndDate = DateTime.Now;
        //cal001.MaxDate = DateTime.Now;

        pnl002.Visible = true;
        pnl003.Visible = false;
        WebImageButton1.Visible = false;

    }

    protected void ddown006_SelectedIndexChanged1(object sender, EventArgs e)
    {
        getcomuna();
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();


        pnl002.Visible = false;
        pnl003.Visible = false;

        ICODIE = Convert.ToInt32(Request.QueryString["V1"]);
        CODNINOG = Convert.ToInt32(Request.QueryString["V2"]);
        codProy = Convert.ToInt32(Request.QueryString["V3"]);
        FechaIngresoNino = Convert.ToDateTime(Request.QueryString["V4"]);

        getregion();
        getcomuna();
        GetData();

    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
}
