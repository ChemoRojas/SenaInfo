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



public partial class mod_ninos_adn : System.Web.UI.Page
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
             # region VALIDACION USUARIO

            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>parent.location.href='../autenticacion.aspx';</script>");
            }
            else
            {
                //B0803670-B908-4301-B01A-7B0FA6F360B9 ingresar a muestra adn
                //46593F2C-2172-4E75-88A7-853347549AA4 agregar, modificar, eliminar muestra adn

                if (window.existetoken("B0803670-B908-4301-B01A-7B0FA6F360B9") || window.existetoken("46593F2C-2172-4E75-88A7-853347549AA4"))
                {
                    int v = 0;
                }
                else
                {
                    Response.Write("<script>parent.location.href='../autenticacion.aspx';</script>"); ;
                }
            }

            #endregion

            getinstituciones();

            //GMP temporal
            //try
            //{
            //    ddown001_Inst.SelectedValue = Session["GMPinst"].ToString();
            //    getproyectos();
            //    ddown002_Proy.SelectedValue = Session["GMPproy"].ToString();
            //}
            //catch { };
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

    protected void ddown001_Inst_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (window.existetoken("B0803670-B908-4301-B01A-7B0FA6F360B9") || window.existetoken("46593F2C-2172-4E75-88A7-853347549AA4"))
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


                //cadena = "ninos_AgregarTomaADN.aspx?&CodNino=" + EAdnNino + "&delta=" + ICodIE + "&codp=" + codp + "&codi=" + codi + "&vdir=" + "~/mod_ninos/ninos_adn.aspx" + "&sExpresa=" + SentenciaExpresa;
                //cadena = "darClick2('" + cadena + "');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);


                iframe_adn.Src = "ninos_AgregarTomaADN.aspx?&CodNino=" + EAdnNino + "&delta=" + ICodIE + "&codp=" + codp + "&codi=" + codi + "&vdir=" + "ninos_adn.aspx" + "&sExpresa=" + SentenciaExpresa;
                iframe_adn.Attributes.Add("height", "600px");
                iframe_adn.Attributes.Add("width", "800px");
                mpe3.Show();

            }
        }
        

        

    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        //CargaGrilla();
        funcion_carga_pag();
    }
    protected void grd001_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void grd002_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd002.PageIndex = e.NewPageIndex;
        funcion_carga_pag2();
       // CargaGrilla2();
    }

    private void funcion_carga_pag()
    {
        DataView dv = new DataView(dt_busqueda2);
        

        dv.Sort = "Apellido_paterno";
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;
    
    
    }
    private void funcion_carga_pag2()
    {
        DataView dv = new DataView(dt_busqueda);


        dv.Sort = "Apellido_paterno";
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;


    }



    ///////////////MICHAEL TRAE INSTITUCION///////////

    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001_Inst.DataSource = dv1;
        ddown001_Inst.DataTextField = "Nombre";
        ddown001_Inst.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001_Inst.DataBind();

        if (dv1.Count == 2)
        {
            ddown001_Inst.SelectedIndex = 1;
            ddown001_Inst_SelectedIndexChanged(new object(), new EventArgs());
        }

    }
    ////////////FIN TRAE INSTITUCION/////////////////////



    private void getproyectos()
    {
        //gmp temporal
        //Session["GMPinst"] = ddown001_Inst.SelectedValue;

        proyectocoll pcoll = new proyectocoll();
        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001_Inst.SelectedValue)));
        dv.Sort = "Nombre";
        ddown002_Proy.Items.Clear();
        ddown002_Proy.DataSource = dv;
        ddown002_Proy.DataTextField = "Nombre";
        ddown002_Proy.DataValueField = "CodProyecto";
        ddown002_Proy.DataBind();

        if (dv.Count == 2)
        {
            ddown002_Proy.SelectedIndex = 1;
            ddown002_Proy_SelectedIndexChanged(new object(), new EventArgs());
        }

    }


    protected void ddown002_Proy_SelectedIndexChanged(object sender, EventArgs e)
    {
        //funcion_cargadatos();
        funcion_ninos();


    }
    public void funcion_cargadatos()
    {
        int CODN = SSnino.CodNino;
        codProy = Convert.ToInt32(ddown002_Proy.SelectedValue);
        adncolls adn = new adncolls();
        //kvega
        //DataTable dt = adn.GetMuestraADN(Convert.ToInt32(ddown002_Proy.SelectedValue));
        DataTable dt = adn.GetMuestraADN(Convert.ToInt32(ddown002_Proy.SelectedValue), 0);

        DVNinos = new DataSet();
        DVNinos.Tables.Add(dt);
        CargaGrilla();

        if (grd001.Rows.Count > 0)
        {

            grd001.Visible = true;
            
            div_encabezado1.Visible = true;
            LBLNO.Visible = false;
            lbl_mensaje.Visible = false;

        }
        else
        {
            if (ddown002_Proy.SelectedValue != "0")
            {
                LBLNO.Visible = true;
                lbl_mensaje.Visible = true;
                grd001.Visible = true;
            }
            else
            {
                lbl_mensaje.Visible = false;
            }
        }


    }
    public void funcion_cargadatos2()
    {
        int CODN = SSnino.CodNino;
        codProy = Convert.ToInt32(ddown002_Proy.SelectedValue);
        adncolls adn = new adncolls();
        DataTable dt2 = adn.GetADNSI(Convert.ToInt32(ddown002_Proy.SelectedValue));

        DVNinos = new DataSet();
        DVNinos.Tables.Add(dt2);


        if (grd002.Rows.Count > 0)
        {

            grd002.Visible = true;
            div_encabezado2.Visible = true;


        }
        else
        {
            grd002.Visible = true;

        }


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
        //grd002.Page.Items.Clear();

        dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;

    }

    private void funcion_ninos()
    {
        //gmp temporal
        //Session["GMPproy"] = ddown002_Proy.SelectedValue;

        int CODN = SSnino.CodNino;
        codProy = Convert.ToInt32(ddown002_Proy.SelectedValue);
        adncolls adn = new adncolls();
        int sw = 0;

        if (RadioButtonList1.SelectedValue=="0")
            {
             sw=0;
            }
        else
            {
            sw = 1;
            }

        DataTable dt = adn.GetMuestraADN(Convert.ToInt32(ddown002_Proy.SelectedValue), sw);
        DVNinos2 = new DataSet();
        DVNinos2.Tables.Add(dt);

        

        CargaGrilla();
        

        if (grd001.Rows.Count > 0)
        {
            grd001.Visible = true;
            ddown002_Proy.Enabled = false;
            ddown001_Inst.Enabled = false;
            div_encabezado1.Visible = true;
            LBLNO.Visible = false;
            lbl_mensaje.Visible = false;
            dt_busqueda2 = dt;

            //imb_lupainstitucion.Visible = false;
            imb_lupainstitucion.Attributes.Add("disabled", "disabled");
            
            //imb_lupaproyecto.Visible = false;
            imb_lupaproyecto.Attributes.Add("disabled", "disabled");

        }
        else
        {
            if (ddown002_Proy.SelectedValue != "0")
            {
                LBLNO.Visible = true;
                lbl_mensaje.Visible = true;
                grd001.Visible = true;
                div_encabezado1.Visible = false;
                
            }
            else
            {
                lbl_mensaje.Visible = false;
            }

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
            div_encabezado2.Visible = true;
        }
        else
        {
        }
        dt_busqueda = dt2;
    }


    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_adn.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void lnk002_Click(object sender, EventArgs e)
    {
        funcion_ninos();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_adn.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void ImageButton5_Click(object sender, EventArgs e)
    {
        funcion_ninos();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Nino_Con_ADN.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        dt_busqueda.Columns.Remove(dt_busqueda.Columns[6]);
        dt_busqueda.Columns.Remove(dt_busqueda.Columns[6]);
        dt_busqueda.Columns.Remove(dt_busqueda.Columns[7]);
        dt_busqueda.Columns.Remove(dt_busqueda.Columns[6]);
        
        DataTable dt = dt_busqueda;


        dt.Columns[0].ColumnName = "Codigo Proyecto";
        dt.Columns[1].ColumnName = "ICodIE";
        dt.Columns[2].ColumnName = "Nombres";
        dt.Columns[3].ColumnName = "Apellido Paterno";
        dt.Columns[4].ColumnName = "Apellido Materno";
        dt.Columns[5].ColumnName = "NUE";
        dt.Columns[6].ColumnName = "Tribunal";
        dt.Columns[7].ColumnName = "Responsable";
        dt.Columns[8].ColumnName = "Muestra ADN";
        dt.Columns[9].ColumnName = "Muestra Dactilar";
        dt.Columns[10].ColumnName = "Fecha Muestra";
        dt.Columns[11].ColumnName = "Fecha Ingreso";
        



        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();

    }



    protected void btnExcelNinosSinADN_Click(object sender, EventArgs e)
    {
        funcion_ninos();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Nino_Sin_ADN.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        dt_busqueda2.Columns.Remove(dt_busqueda2.Columns[4]);
        dt_busqueda2.Columns.Remove(dt_busqueda2.Columns[4]);
        dt_busqueda2.Columns.Remove(dt_busqueda2.Columns[6]);
        dt_busqueda2.Columns.Remove(dt_busqueda2.Columns[7]);
        dt_busqueda2.Columns.Remove(dt_busqueda2.Columns[4]);

        DataTable dt = dt_busqueda2;

        dt.Columns[2].ColumnName = "Apellido Paterno";
        dt.Columns[3].ColumnName = "Apellido Materno";
        dt.Columns[4].ColumnName = "Fecha Ingreso";

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown002_Proy.SelectedValue != "Seleccionar")
            {
            funcion_ninos();
        }
        
    }
    protected void imb_limpiar_Click(object sender, EventArgs e)
    {
        ddown001_Inst.Enabled = true;

        //imb_lupainstitucion.Visible = true;
        imb_lupainstitucion.Attributes.Remove("disabled");

        //imb_lupaproyecto.Visible = true;
        imb_lupaproyecto.Attributes.Remove("disabled");

        ddown002_Proy.SelectedValue = "0";
        ddown002_Proy.Enabled = true;

        
        lbl_mensaje.Visible = false;

        grd001.DataSource = null;
        grd001.DataBind();
        grd002.DataSource = null;
        grd002.DataBind();

        div_encabezado1.Visible = false;
        div_encabezado2.Visible = false;
    }
}
    
    
    

