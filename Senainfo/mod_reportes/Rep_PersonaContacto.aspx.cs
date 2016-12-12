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

public partial class mod_reportes_Rep_PersonaContacto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                getinstituciones();
                getproyectos();
                getanos();

                if (Request.QueryString["sw"] == "3")
                {

                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    getproyectos();
                }
                else if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                }
            }
        }
    }
    private void getanos()
    {
        for (int i = 0; i < 11; i++)
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
        }


    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_PersonaContacto.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_PersonaContacto.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown002.SelectedValue == ""
            || ddown_MesCierre.SelectedValue == "0")
        {
            if (ddown001.SelectedValue == "0")
            { ddown001.BackColor = colorCampoObligatorio; }   
            else { ddown001.BackColor = System.Drawing.Color.White; }

            if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
            { ddown002.BackColor = colorCampoObligatorio; }
            else { ddown002.BackColor = System.Drawing.Color.White; }

            if (ddown_MesCierre.SelectedValue == "0")
            { ddown_MesCierre.BackColor = colorCampoObligatorio; }
            else { ddown_MesCierre.BackColor = System.Drawing.Color.White; }

        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;
            ddown002.BackColor = System.Drawing.Color.White;
            ddown_MesCierre.BackColor = System.Drawing.Color.White;

            buscar();

        }
    }
    private void buscar()
    {
        int anomes = Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue);

        ReporteNinoColl rp = new ReporteNinoColl();
        DataTable dt = rp.callto_reporte_persona_contacto(Convert.ToInt32(ddown002.SelectedValue),
            anomes);

        if (dt.Rows.Count > 0)
        {
            grd001.DataSource = dt;
            grd001.DataBind();
            grd001.Visible = true;
            lbl_error.Visible = false;
        }
        else
        {
            lbl_error.Visible = true;
            grd001.Visible = false;
        }

    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        ddown_AnoCierre.SelectedIndex = -1;
        ddown_MesCierre.SelectedIndex = -1;

        ddown002.BackColor = System.Drawing.Color.White;
        ddown_MesCierre.BackColor = System.Drawing.Color.White;
        lbl_error.Visible = false;
        grd001.Visible = false;
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

    //    if (ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown002.SelectedValue == ""
    //        || ddown_MesCierre.SelectedValue == "0")
    //    {
    //        if (ddown001.SelectedValue == "0")
    //        { ddown001.BackColor = colorCampoObligatorio; }
    //        else { ddown001.BackColor = System.Drawing.Color.White; }

    //        if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
    //        { ddown002.BackColor = colorCampoObligatorio; }
    //        else { ddown002.BackColor = System.Drawing.Color.White; }

    //        if (ddown_MesCierre.SelectedValue == "0")
    //        { ddown_MesCierre.BackColor = colorCampoObligatorio; }
    //        else { ddown_MesCierre.BackColor = System.Drawing.Color.White; }

    //    }
    //    else
    //    {
    //        ddown001.BackColor = System.Drawing.Color.White;
    //        ddown002.BackColor = System.Drawing.Color.White;
    //        ddown_MesCierre.BackColor = System.Drawing.Color.White;

    //        ReporteNinoColl rp = new ReporteNinoColl();
    //        int anomes = Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue);
    //        DataTable dt = rp.callto_reporte_persona_contacto(Convert.ToInt32(ddown002.SelectedValue),
    //            anomes);
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.ContentType = "application/vnd.ms-excel";
    //        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Personas_Contacto.xls");

    //        this.EnableViewState = false;

    //        System.IO.StringWriter tw = new System.IO.StringWriter();
    //        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

    //        dt.Columns[0].ColumnName = "COD. NINO";
    //        dt.Columns[1].ColumnName = "ICODIE";
    //        dt.Columns[2].ColumnName = "APELLIDO PATERNO";
    //        dt.Columns[3].ColumnName = "APELLIDO MATERNO";
    //        dt.Columns[4].ColumnName = "NOMBRES NIÑO";
    //        dt.Columns[5].ColumnName = "RUT";
    //        dt.Columns[6].ColumnName = "SEXO";
    //        dt.Columns[7].ColumnName = "FECHA NACIMIENTO";
    //        dt.Columns[8].ColumnName = "FECHA INGRESO";
    //        dt.Columns[9].ColumnName = "FECHA EGRESO";
    //        dt.Columns[10].ColumnName = "PERSONA CONTACTO";
    //        dt.Columns[11].ColumnName = "TIPO RELACION PERSONA CONTACTO";
    //        dt.Columns[12].ColumnName = "PERMANENCIA";

    //        DataView dv = new DataView(dt);

    //        GridView grd002 = new GridView();
    //        grd002.DataSource = dv;
    //        grd002.DataBind();
    //        grd002.RenderControl(hw);
    //        Response.ContentEncoding = System.Text.Encoding.Default;
    //        Response.Write(tw.ToString());
    //        Response.End();
           

    //    }
        
    //}
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        buscar();
    }
    protected void ImageButton1_Click1(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown002.SelectedValue == ""
           || ddown_MesCierre.SelectedValue == "0")
        {
            if (ddown001.SelectedValue == "0")
            { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }

            if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
            { ddown002.BackColor = colorCampoObligatorio; }
            else { ddown002.BackColor = System.Drawing.Color.White; }

            if (ddown_MesCierre.SelectedValue == "0")
            { ddown_MesCierre.BackColor = colorCampoObligatorio; }
            else { ddown_MesCierre.BackColor = System.Drawing.Color.White; }

        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;
            ddown002.BackColor = System.Drawing.Color.White;
            ddown_MesCierre.BackColor = System.Drawing.Color.White;

            ReporteNinoColl rp = new ReporteNinoColl();
            int anomes = Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue);
            DataTable dt = rp.callto_reporte_persona_contacto(Convert.ToInt32(ddown002.SelectedValue),
                anomes);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Personas_Contacto.xls");

            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            dt.Columns[0].ColumnName = "COD. NINO";
            dt.Columns[1].ColumnName = "ICODIE";
            dt.Columns[2].ColumnName = "APELLIDO PATERNO";
            dt.Columns[3].ColumnName = "APELLIDO MATERNO";
            dt.Columns[4].ColumnName = "NOMBRES NIÑO";
            dt.Columns[5].ColumnName = "RUT";
            dt.Columns[6].ColumnName = "SEXO";
            dt.Columns[7].ColumnName = "FECHA NACIMIENTO";
            dt.Columns[8].ColumnName = "FECHA INGRESO";
            dt.Columns[9].ColumnName = "FECHA EGRESO";
            dt.Columns[10].ColumnName = "PERSONA CONTACTO";
            dt.Columns[11].ColumnName = "TIPO RELACION PERSONA CONTACTO";
            dt.Columns[12].ColumnName = "PERMANENCIA";

            DataView dv = new DataView(dt);

            GridView grd002 = new GridView();
            grd002.DataSource = dv;
            grd002.DataBind();
            grd002.RenderControl(hw);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();


        }
    }
}
