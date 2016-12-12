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

public partial class mod_reportes_Rep_Diag_Ninos : System.Web.UI.Page
{
    public DataTable dt_busqueda
    {
        get { return (DataTable)Session["dt_busqueda"]; }
        set { Session["dt_busqueda"] = value; }
    }   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            alerts.Visible = false;
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                getinstituciones();
                if (Session["CodInstitucion"] != null)
                    ddown001.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectos();
                if (Session["CodProyecto"] != null)
                    ddown002.SelectedValue = Session["CodProyecto"].ToString();

                getanos();
                tipo();
                if (Request.QueryString["sw"] == "3")
                {
                    limpiaSession();
                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    getproyectos();
                }
                else if (Request.QueryString["sw"] == "4")
                {
                    limpiaSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                }
            }
        }

        Session["CodInstitucion"] = ddown001.SelectedValue;
        Session["CodProyecto"] = ddown002.SelectedValue;
    }

    private void limpiaSession()
    {
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }

    private void getanos()
    {
        for (int i = 0; i < 4; i++)
        {
            ddown_AnoCierre.Items.Add(Convert.ToString(DateTime.Now.Year - i));

        }

    }
    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre";
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "Codinstitucion";
        ddown001.DataBind();

        if (dv.Count == 2)
            ddown001.SelectedIndex = 1;

    }
    private void getproyectos()
    {
        if (ddown001.Items.Count > 0 && Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            proyectocoll pcoll = new proyectocoll();

            DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue));
            DataView dv = new DataView(dtproy);
            dv.Sort = "Nombre";
            ddown002.DataSource = dv;
            ddown002.DataTextField = "Nombre";
            ddown002.DataValueField = "CodProyecto";
            ddown002.DataBind();

            if (dv.Count == 2)
                ddown002.SelectedIndex = 1;
        }


    }


    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";

        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_Diag_Ninos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_Diag_Ninos.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    private void tipo()
    {
        ReporteNinoColl rep = new ReporteNinoColl();
        DataTable dt = rep.GetparTipoDiagnosticoGlosaxRep();
        DataRow dr;

        dr = dt.NewRow();
        dr[0] = "10";
        dr[1] = "DIAGNOSTICO DISCAPACIDAD";
        dt.Rows.Add(dr);

        dr = dt.NewRow(); 
        dr[0] = "11";
        dr[1] = "HECHOS DE SALUD";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr[0] = "12";
        dr[1] = "NINOS ENFERMEDADES CRONICAS";

        dt.Rows.Add(dr);
        if (dt.Rows.Count > 0)
        {
            ddown_tipo.DataSource = dt;
            ddown_tipo.DataValueField = "codtipodiagnosticoglosa";
            ddown_tipo.DataTextField = "descripcion";
            ddown_tipo.DataBind();
        }
    }
    private void buscar()
    {
        ReporteNinoColl rpn = new ReporteNinoColl();
        DataTable dt = rpn.callto_reporte_diagnosticos_ninos(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue+ddown_MesCierre.SelectedValue),
            Convert.ToInt32(ddown_tipo.SelectedValue));

        BuscarII(dt);

        if (dt.Rows.Count > 0)
        {
            ddown001.Enabled = false;
            ddown002.Enabled = false;
            ddown_AnoCierre.Enabled = false;
            ddown_MesCierre.Enabled = false;
            ddown_tipo.Enabled = false;

            dt_busqueda = dt;

            if (Convert.ToInt32(ddown_tipo.SelectedValue) == 1)
            {
                GridView grd001 = (GridView)DIAG_ESCOLAR1.FindControl("grd001");
                grd001.PageIndex = 0;
                grd001.DataSource = dt;
                grd001.DataBind();
                
                DIAG_ESCOLAR1.Visible = true;
                DIAG_DROGA1.Visible = false;
                DIAG_MALTRATO1.Visible = false;
                DIAG_PEORES_FORMA1.Visible = false;
                DIAG_PSICOLOGICO1.Visible = false;
                DIAG_SOCIAL1.Visible = false;
            }
            else if(Convert.ToInt32(ddown_tipo.SelectedValue) == 2)
            {
                GridView grd001 = (GridView)DIAG_MALTRATO1.FindControl("grd001");
                grd001.PageIndex = 0;
                grd001.DataSource = dt;
                grd001.DataBind();
                
                DIAG_MALTRATO1.Visible = true;
                DIAG_ESCOLAR1.Visible = false;
                DIAG_DROGA1.Visible = false;
                DIAG_PEORES_FORMA1.Visible = false;
                DIAG_PSICOLOGICO1.Visible = false;
                DIAG_SOCIAL1.Visible = false;
            }
            else if (Convert.ToInt32(ddown_tipo.SelectedValue) == 3)
            {
                GridView grd001 = (GridView)DIAG_DROGA1.FindControl("grd001");
                grd001.PageIndex = 0;
                grd001.DataSource = dt;
                grd001.DataBind();
                
                DIAG_DROGA1.Visible = true;
                DIAG_ESCOLAR1.Visible = false;              
                DIAG_MALTRATO1.Visible = false;
                DIAG_PEORES_FORMA1.Visible = false;
                DIAG_PSICOLOGICO1.Visible = false;
                DIAG_SOCIAL1.Visible = false;
            }
            else if (Convert.ToInt32(ddown_tipo.SelectedValue) == 4)
            {
                GridView grd001 = (GridView)DIAG_PSICOLOGICO1.FindControl("grd001");
                grd001.PageIndex = 0;
                grd001.DataSource = dt;
                grd001.DataBind();
                
                DIAG_PSICOLOGICO1.Visible = true;
                DIAG_ESCOLAR1.Visible = false;
                DIAG_DROGA1.Visible = false;
                DIAG_MALTRATO1.Visible = false;
                DIAG_PEORES_FORMA1.Visible = false;
                DIAG_SOCIAL1.Visible = false;
            }
            else if (Convert.ToInt32(ddown_tipo.SelectedValue) == 5)
            {
                GridView grd001 = (GridView)DIAG_SOCIAL1.FindControl("grd001");
                grd001.PageIndex = 0;
                grd001.DataSource = dt;
                grd001.DataBind();
                lbl_error.Visible = false;
                alerts.Visible = false;


                DIAG_SOCIAL1.Visible = true;
                DIAG_DROGA1.Visible = false;
                DIAG_MALTRATO1.Visible = false;
                DIAG_PEORES_FORMA1.Visible = false;
                DIAG_PSICOLOGICO1.Visible = false;
                DIAG_ESCOLAR1.Visible = false;
            }
            else if (Convert.ToInt32(ddown_tipo.SelectedValue) == 8)
            {
                
                GridView grd001 = (GridView)DIAG_PEORES_FORMA1.FindControl("grd001");
                grd001.PageIndex = 0;
                grd001.DataSource = dt;
                grd001.DataBind();
                
                DIAG_PEORES_FORMA1.Visible = true;
                DIAG_DROGA1.Visible = false;
                DIAG_MALTRATO1.Visible = false;
                DIAG_ESCOLAR1.Visible = false;
                DIAG_PSICOLOGICO1.Visible = false;
                DIAG_SOCIAL1.Visible = false;
            }
            lbl_error.Visible = false;
            alerts.Visible = false;

            
        }
        else
        {
            alerts.Visible = true;
            lbl_error.Text = "No se han encontrado registros coincidentes.";
            lbl_error.Visible = true;
            alerts.Visible = true;



            DIAG_PEORES_FORMA1.Visible = false;
            DIAG_DROGA1.Visible = false;
            DIAG_MALTRATO1.Visible = false;
            DIAG_ESCOLAR1.Visible = false;
            DIAG_PSICOLOGICO1.Visible = false;
            DIAG_SOCIAL1.Visible = false;
        }
    }

    private void BuscarII(DataTable dt)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Diagnostico.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataView dv = new DataView(dt);

        GridView grd002 = new GridView();
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        lbl_error.Visible = false;
        alerts.Visible = false;
        
        if (ddown001.SelectedValue !="0" && ddown002.SelectedValue != "0" && ddown002.SelectedValue != "" && ddown_MesCierre.SelectedValue != "0" && ddown_tipo.SelectedValue != "0")
        {
            buscar();
            ddown002.BackColor = System.Drawing.Color.White;
            ddown_MesCierre.BackColor = System.Drawing.Color.White;
            ddown_tipo.BackColor = System.Drawing.Color.White;
            

        }
        else
        {
            Boolean faltanCampos = false;
            if (ddown001.SelectedValue == "0" )
            {
                ddown001.BackColor = colorCampoObligatorio;
                faltanCampos = true;
            }
            else
            {
                ddown001.BackColor = System.Drawing.Color.White;
            }

            if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
            {
                ddown002.BackColor = colorCampoObligatorio;
                faltanCampos = true;
            }
            else
            {
                ddown002.BackColor = System.Drawing.Color.White;
            }

            if (ddown_MesCierre.SelectedValue == "0")
            {
                ddown_MesCierre.BackColor = colorCampoObligatorio;
                faltanCampos = true;
            }
            else
            {
                ddown_MesCierre.BackColor = System.Drawing.Color.White;
            }

            if (ddown_tipo.SelectedValue == "0")
            {
                ddown_tipo.BackColor = colorCampoObligatorio;
                faltanCampos = true;
            }
            else
            {
                ddown_tipo.BackColor = System.Drawing.Color.White;
            }
            if (faltanCampos) {
                lbl_error.Text = "Ingrese todos los parametros solicitados.";
                lbl_error.Visible = true;
                alerts.Visible = true;
            }
            
        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        try
        {
            getinstituciones();
            ddown002.SelectedIndex = 0;
            getanos();
            tipo();
            ddown_MesCierre.SelectedIndex = 0;
            ddown_AnoCierre.SelectedIndex = 0;
            ddown_tipo.SelectedIndex = 0;
            alerts.Visible = false;
            lbl_error.Text = string.Empty;
        //    ddown001.Items.Clear();
        //    ddown001.DataSource = null;
        //    ddown001.DataBind();
        //    ddown002.Items.Clear();
        //    ddown002.DataSource = null;
        //    ddown002.DataBind();

            ddown001.BackColor = System.Drawing.Color.White;
            ddown002.BackColor = System.Drawing.Color.White;
            ddown_AnoCierre.BackColor = System.Drawing.Color.White;
            ddown_MesCierre.BackColor = System.Drawing.Color.White;
            ddown_tipo.BackColor = System.Drawing.Color.White;
            DIAG_PEORES_FORMA1.Visible = false;
            DIAG_DROGA1.Visible = false;
            DIAG_MALTRATO1.Visible = false;
            DIAG_ESCOLAR1.Visible = false;
            DIAG_PSICOLOGICO1.Visible = false;
            DIAG_SOCIAL1.Visible = false;
            lbl_error.Visible = false;
            alerts.Visible = false;


            ddown001.Enabled = true;
            ddown002.Enabled = true;
            ddown_AnoCierre.Enabled = true;
            ddown_MesCierre.Enabled = true;
            ddown_tipo.Enabled = true;
        }
        catch (Exception ex)
        { }

    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }

    protected void lnk001_Click(object sender, EventArgs e)
    {
        buscar();
    }
    protected void DIAG_DROGA1_Load(object sender, EventArgs e)
    {

    }
    protected void DIAG_MALTRATO1_Load(object sender, EventArgs e)
    {

    }
}
