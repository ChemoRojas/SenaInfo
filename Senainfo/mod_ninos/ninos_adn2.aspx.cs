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

public partial class mod_ninos_ninos_adn2 : System.Web.UI.Page
{
    private DataTable dt_busqueda2
    {
        get { return (DataTable)Session["dt_busqueda2"]; }
        set { Session["dt_busqueda2"] = value; }
    }
    private DataTable dt_busqueda
    {
        get { return (DataTable)Session["dt_busqueda"]; }
        set { Session["dt_busqueda"] = value; }
    }
    public DataSet DVNinos2
    {
        get { return (DataSet)Session["DVNinos2"]; }
        set { Session["DVNinos2"] = value; }
    }

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

    public DataTable DtBusqueda
    {
        get { return (DataTable)Session["DtBusqueda"]; }
        set { Session["DtBusqueda"] = value; }
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


    protected void Page_Load(object sender, EventArgs e)      
    {
        if (!IsPostBack)
        {
            getinstituciones();
            //GMP temporal
            try
            {
                ddown001_Inst.SelectedValue = Session["GMPinst"].ToString();
                getproyectos();
                ddown002_Proy.SelectedValue = Session["GMPproy"].ToString();
            }
            catch { };
            // hasta aqui
            if (Request.QueryString["sw"] == "3")
            {
                ddown001_Inst.SelectedValue = Request.QueryString["codinst"];
                getproyectos();
            }
            else if (Request.QueryString["sw"] == "4")
            {
                buscador_institucion bsc = new buscador_institucion();
                int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                ddown001_Inst.SelectedValue = Convert.ToString(codinst);
                getproyectos();
                ddown002_Proy.SelectedValue = Request.QueryString["codinst"];
                funcion_ninos();
                //lnk002.Visible = true;
            }
            grd001.Columns[7].Visible = false;
            if (!window.existetoken("46593F2C-2172-4E75-88A7-853347549AA4"))
            {

                grd001.Columns[7].Visible = true;
            }
        }
    }
    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001_Inst.DataSource = dv1;
        ddown001_Inst.DataTextField = "Nombre";
        ddown001_Inst.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001_Inst.DataBind();
    }
    private void getproyectos()
    {
        //gmp temporal
        Session["GMPinst"] = ddown001_Inst.SelectedValue;

        proyectocoll pcoll = new proyectocoll();
        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001_Inst.SelectedValue)));
        dv.Sort = "Nombre";
        ddown002_Proy.Items.Clear();
        ddown002_Proy.DataSource = dv;
        ddown002_Proy.DataTextField = "Nombre";
        ddown002_Proy.DataValueField = "CodProyecto";
        ddown002_Proy.DataBind();

    }
    private void funcion_ninos()
    {
        //gmp temporal
        Session["GMPproy"] = ddown002_Proy.SelectedValue;

        int CODN = SSnino.CodNino;
        codProy = Convert.ToInt32(ddown002_Proy.SelectedValue);
        adncolls adn = new adncolls();
        int sw = 0;

        //if (RadioButtonList1.SelectedValue == "0")
        //{
        //    sw = 0;
        //}
        //else
        //{
        //    sw = 1;
        //}

        DataTable dt = adn.GetMuestraADN(Convert.ToInt32(ddown002_Proy.SelectedValue), sw);
        DVNinos2 = new DataSet();
        DVNinos2.Tables.Add(dt);



        CargaGrilla();

        if (grd001.Rows.Count > 0)
        {
            grd001.Visible = true;
            ddown002_Proy.Enabled = false;
            ddown001_Inst.Enabled = false;
            lblsin.Visible = true;
            btnExcelNinosSinADN.Visible = true;
            LBLNO.Visible = false;
            dt_busqueda2 = dt;

        }
        else
        {
            LBLNO.Visible = true;
            grd001.Visible = true;
            btnExcelNinosSinADN.Visible = false;
        }


        int CODN2 = SSnino.CodNino;
        int codProy2 = Convert.ToInt32(ddown002_Proy.SelectedValue);
        adncolls adn2 = new adncolls();
        DataTable dt2 = adn.GetADNSI(Convert.ToInt32(ddown002_Proy.SelectedValue));
        DVNinos = new DataSet();
        DVNinos.Tables.Add(dt2);

        CargaGrilla2();

        if (grd002.Rows.Count > 0)
        {
            grd002.Visible = true;
            ddown002_Proy.Enabled = false;
            ddown001_Inst.Enabled = false;
            lblcon.Visible = true;
            //ImageButton5.Visible = true;
        }
        else
        {
        }
        dt_busqueda = dt2;
    }
    private void CargaGrilla()
    {
        DataSet dv = DVNinos2;
        //grd001.Page.Items.Clear();

        dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;

    }
    private void CargaGrilla2()
    {
        DataSet dv = DVNinos;
        grd002.Page.Items.Clear();

        dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;

    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        //CargaGrilla();
        funcion_carga_pag();
    }
    private void funcion_carga_pag()
    {
        DataView dv = new DataView(dt_busqueda2);


        dv.Sort = "Apellido_paterno";
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;


    }
    protected void grd001_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void ddown001_Inst_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }

    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Agregar")
        {
            //GMP no hace nada
            //DataTable dt = new DataTable();
            //DataRow dr;
            //dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
            //dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
            //dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
            //dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
            //dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //8
            //dr = dt.NewRow();
            //for (int i = 0; i < grd001.Columns.Count - 1; i++)
            //{
            //    try
            //    {
            //        dr[i] = Server.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[i].Text);
            //    }
            //    catch { }
            //}
            string ICodIE = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            adncolls adn3 = new adncolls();
            DataTable dtn = adn3.GetADNNinos(Convert.ToInt32(ICodIE));
            int EAdnNino = Convert.ToInt32(dtn.Rows[0][0]); /// Trae el Codigo NINO, y lo lleva al request "?CodNino="
            adncolls adnIE2 = new adncolls();
            DataTable dtmIE = adnIE2.GetMuestraADNIECOD(codProy, EAdnNino);
            int IECODD = (Convert.ToInt32(dtmIE.Rows[0][0]));
            //int IECODDnino = (Convert.ToInt32(dtmIE.Rows[0][1]));

            int codp = Convert.ToInt32(ddown002_Proy.Text);
            int codi = Convert.ToInt32(ddown001_Inst.Text);
            string SentenciaExpresa = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
            if (SentenciaExpresa == "&nbsp;") SentenciaExpresa = string.Empty;
            string cadena = string.Empty;
            //window.open(Page, "ninos_AgregarTomaADN.aspx?CodNino=" + EAdnNino + "&delta=" + ICodIE + "&codp=" + codp + "&codi=" + codi + "&vdir=" + "../mod_ninos/ninos_adn.aspx" + "&sExpresa=" + SentenciaExpresa, 600, 700);
            //cadena = @"window.open(this.Page, '~/mod_ninos/ninos_AgregarTomaADN.aspx?CodNino=" + EAdnNino + "&delta=" + ICodIE + "&codp=" + codp + "&codi=" + codi + "&vdir=" + "~/mod_ninos/ninos_adn.aspx" + "&sExpresa=" + SentenciaExpresa + "', 600, 700);";
            //cadena = @"window.open(this.Page, '../mod_reportes/busca_proyectosNuevaLeyRep.aspx', 'Buscador', false, false, '750', '300', false, false, true)";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Ventana", cadena, true);

            cadena = "ninos_AgregarTomaADN.aspx?&CodNino=" + EAdnNino + "&delta=" + ICodIE + "&codp=" + codp + "&codi=" + codi + "&vdir=" + "~/mod_ninos/ninos_adn.aspx" + "&sExpresa=" + SentenciaExpresa;
            cadena = "darClick2('" + cadena + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);

        }

    }

    protected void grd002_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd002.PageIndex = e.NewPageIndex;
        funcion_carga_pag2();
        // CargaGrilla2();
    }
    protected void ddown002_Proy_SelectedIndexChanged(object sender, EventArgs e)
    {
        //funcion_cargadatos();
        funcion_ninos();
    }
    protected void btnExcelNinosSinADN_Click(object sender, ImageClickEventArgs e)
    {

    }
    private void funcion_carga_pag2()
    {
        DataView dv = new DataView(dt_busqueda);


        dv.Sort = "Apellido_paterno";
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            CargaGrilla();
            CargaGrilla2();
        }
        catch { }
    }
}