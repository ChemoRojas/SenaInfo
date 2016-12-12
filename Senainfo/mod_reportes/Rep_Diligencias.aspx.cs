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

public partial class mod_reportes_Rep_Diligencias : System.Web.UI.Page
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
                if (Session["CodInstitucion"] != null)
                    ddown001.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectos();
                if (Session["CodProyecto"] != null)
                    ddown002.SelectedValue = Session["CodProyecto"].ToString();

                getanos();

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

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_Diligencias.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_Diligencias.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    private void buscar()
    {
        ReporteNinoColl rpn = new ReporteNinoColl();
        DataTable dt = rpn.callto_reporte_diligencias(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_MesCierre.SelectedValue),
            Convert.ToInt32(ddown_AnoCierre.SelectedValue), Convert.ToInt32(rdo_tipo.SelectedValue));
        if (dt.Rows.Count > 0)
        {
            grd001.DataSource = dt;
            grd001.DataBind();
            grd001.Visible = true;
            lbl_error.Visible = false;
            lbl_mensaje.Visible = false;
            div_encabezado1.Visible = true;
        }
        else
        {
            lbl_error.Text = "No se han encontrado registros coincidentes.";
            lbl_error.Visible = true;
            lbl_mensaje.Visible = true;
            div_encabezado1.Visible = false;
        }
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown002.SelectedValue != "0" && ddown002.SelectedValue != "" && ddown_MesCierre.SelectedValue != "0" && rdo_tipo.SelectedValue != "")
        {
            buscar();
            ddown002.BackColor = System.Drawing.Color.White;
            ddown_MesCierre.BackColor = System.Drawing.Color.White;
            rdo_tipo.BackColor = System.Drawing.Color.Empty;

        }
        else
        {
            if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
            {
                ddown002.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown002.BackColor = System.Drawing.Color.White;
            }

            if (ddown_MesCierre.SelectedValue == "0" )
            {
                ddown_MesCierre.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_MesCierre.BackColor = System.Drawing.Color.White;
            }

            if (rdo_tipo.SelectedValue == "")
            {
                rdo_tipo.BackColor = colorCampoObligatorio;
            }
            else
            {
                rdo_tipo.BackColor = System.Drawing.Color.Empty;
            }

            lbl_error.Text = "Ingrese todos los parametros solicitados.";
            lbl_error.Visible = true;
            lbl_mensaje.Visible = true;
            div_encabezado1.Visible = false;
        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        //ddown001.SelectedIndex = -1;
        ddown_AnoCierre.SelectedIndex = -1;
        ddown_MesCierre.SelectedIndex = -1;
        rdo_tipo.SelectedIndex = -1;
        ddown002.BackColor = System.Drawing.Color.White;
        ddown_MesCierre.BackColor = System.Drawing.Color.White;
        rdo_tipo.BackColor = System.Drawing.Color.Empty;
        lbl_error.Visible = false;
        lbl_mensaje.Visible = false;
        div_encabezado1.Visible = false;

        grd001.DataSource = null;
        grd001.Visible = false;

        ddown002.SelectedIndex = -1;
        
        ddown001.SelectedIndex = -1;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown002.SelectedValue != "0" && ddown002.SelectedValue != "" && ddown_MesCierre.SelectedValue != "0" && rdo_tipo.SelectedValue != "")
        {
            ReporteNinoColl rpn = new ReporteNinoColl();
            DataTable dt = rpn.callto_reporte_diligencias(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_MesCierre.SelectedValue),
                Convert.ToInt32(ddown_AnoCierre.SelectedValue), Convert.ToInt32(rdo_tipo.SelectedValue));
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Diligencias.xls");

            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            dt.Columns[0].ColumnName = "COD. NINO";
            dt.Columns[1].ColumnName = "ICODIE";
            dt.Columns[2].ColumnName = "APELLIDO PATERNO";
            dt.Columns[3].ColumnName = "APELLIDO MATERNO";
            dt.Columns[4].ColumnName = "NOMBRES";
            dt.Columns[5].ColumnName = "FECHA INGRESO";
            dt.Columns[6].ColumnName = "FECHA EGRESO";
            dt.Columns[7].ColumnName = "RUT";
            dt.Columns[8].ColumnName = "SEXO";
            dt.Columns[9].ColumnName = "FECHA NACIMIENTO";
            dt.Columns[10].ColumnName = "CODIGO DILIGENCIA";
            dt.Columns[11].ColumnName = "FECHA SOLICITUD";
            dt.Columns[12].ColumnName = "COD. SOLICITANTE";
            dt.Columns[13].ColumnName = "SOLICITANTE";
            dt.Columns[14].ColumnName = "COD. DILIGENCIA";
            dt.Columns[15].ColumnName = "DILIGENCIA";
            dt.Columns[16].ColumnName = "FUE REALIZADA";
            dt.Columns[17].ColumnName = "FECHA REALIZADA";
            dt.Columns[18].ColumnName = "TRABAJADOR";
            // dt.Columns[19].ColumnName = "FECHA ACTUALIZACION";

            DataView dv = new DataView(dt);
            //DataGrid d1 = new DataGrid();
            GridView grd002 = new GridView();
            grd002.DataSource = dv;
            grd002.DataBind();
            grd002.RenderControl(hw);
            //grd002.Columns.
            //d1.DataSource = dv;
            //d1.DataBind();
            //d1.RenderControl(hw);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();
            ddown002.BackColor = System.Drawing.Color.White;
            ddown_MesCierre.BackColor = System.Drawing.Color.White;
            rdo_tipo.BackColor = System.Drawing.Color.Empty;

        }
        else
        {
            if (ddown002.SelectedValue == "0" || ddown002.SelectedValue == "")
            {
                ddown002.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown002.BackColor = System.Drawing.Color.White;
            }

            if (ddown_MesCierre.SelectedValue == "0")
            {
                ddown_MesCierre.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_MesCierre.BackColor = System.Drawing.Color.White;
            }

            if (rdo_tipo.SelectedValue == "")
            {
                rdo_tipo.BackColor = colorCampoObligatorio;
            }
            else
            {
                rdo_tipo.BackColor = System.Drawing.Color.Empty;
            }

            lbl_error.Text = "Ingrese todos los parametros solicitados.";
            lbl_error.Visible = true;
            lbl_mensaje.Visible = true;
            div_encabezado1.Visible = false;
        }


        
    }

    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        buscar();
    }
}
