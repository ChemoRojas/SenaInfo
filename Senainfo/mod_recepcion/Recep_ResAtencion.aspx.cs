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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Drawing;

public partial class mod_recepcion_Recep_ResAtencion : System.Web.UI.Page
{
    private DataSet DVproy
    {
        get { return (DataSet)ViewState["DVproy"]; }
        set { ViewState["DVproy"] = value; }
    }
    private DataSet DvReliquidaciones
    {
        get { return (DataSet)ViewState["DvReliquidaciones"]; }
        set { ViewState["DvReliquidaciones"] = value; }
    }
    private int eproy
    {
        get { return (int)Session["eproy"]; }
        set { Session["eproy"] = value; }
    }

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
                if (!window.existetoken("BA3BC7A2-9F8E-4683-954E-94C38B0521B6"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                getregion();
                getAnos();

                pnlAlert.Style.Add("display", "none");
                //getinstitucion();
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codregion = bsc.GetCodRegionxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codregion);
                }

                validatescurity();

                if (grd001.Rows.Count > 0)
                {
                    grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
                    grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grd001')); });", true);
                }
            }
        }
    }
    private void validatescurity()
    {
        //E681BCEC-7ACA-44AC-915D-7478ACC87545 4.2_INGRESAR
        if (!window.existetoken("E681BCEC-7ACA-44AC-915D-7478ACC87545"))
        {
            btn_guardar.Visible = false;
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                grd001.Rows[i].Cells[5].Enabled = false;
            }

        }

    }
    private void getregion()
    {


        parcoll par = new parcoll();
        //DataView dv = new DataView(par.GetparRegion());
        DataView dv = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodRegion";
        dv.Sort = "CodRegion";

        //ddown001.Items.Remove("SIN INFORMACION");

        //ddown001.Items.Remove("NO CORRESPONDE");
        ddown001.DataBind();
        //ddown001.Items.RemoveAt(1);
        //ddown001.Items.RemoveAt(16);


    }
    private void getAnos()
    {
        for (int i = 0; i < 7; i++)
        {
            ddownAno.Items.Add(Convert.ToString(DateTime.Now.Year - i));
        }
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        //Response.Redirect("index_recepcion.aspx");
        Response.Redirect("../index.aspx");
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown001.SelectedValue == "-2" || ddownAno.SelectedValue == "0" || ddown004.SelectedValue == "0")
        {
            pnl001.Visible = false;
            grd001.Visible = false;
            if (ddown001.SelectedValue == "-2") { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }
            if (ddownAno.Text.Trim() == "") { ddownAno.BackColor = colorCampoObligatorio; }
            else { ddownAno.BackColor = System.Drawing.Color.White; }
            if (ddown004.SelectedValue == "0") { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }

            tituloGrid.Visible = false;
            btn_Reliquidaciones.Visible = false;
            btn_excel.Visible = false;

        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;
            ddownAno.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;

            recepcion_estadistica();
            string mesano = lblano.Text + lblnromes.Text;
            Recepcioncoll rcol = new Recepcioncoll();
            DVproy = new DataSet();
            DVproy.Tables.Add(rcol.cierre_recepcion_movimientomensual(Convert.ToInt32(mesano), 0, Convert.ToInt32(ddown005.SelectedValue),
              Convert.ToInt32(ddown001.SelectedValue), 1));
            funcion_proyectos();
        }
    }
    private void recepcion_estadistica()
    {
        string mesano = lblano.Text + lblnromes.Text;
        Recepcioncoll rcol = new Recepcioncoll();
        DataView dv = new DataView(rcol.cierre_recepcion_estadistica(Convert.ToInt32(mesano), Convert.ToInt32(ddown001.SelectedValue)));
        if (dv.Table.Rows.Count > 0)
        {
            txt002.Text = Convert.ToString(dv.Table.Rows[0][0]);
            txt005.Text = Convert.ToString(dv.Table.Rows[0][1]);
            txt003.Text = Convert.ToString(dv.Table.Rows[0][2]);
            txt004.Text = Convert.ToString(dv.Table.Rows[0][3]);

            pnl001.Visible = true;
        }
        else
        {
            pnl001.Visible = false;
        }
    }
    private void funcion_proyectos()
    {
        CheckBox tchkRetencionPago = new CheckBox();
        CheckBox tchkFES = new CheckBox();
        CheckBox tchkEnvioFinanciero = new CheckBox();

        grd001.DataSource = DVproy;
        grdResAtencionExcel.DataSource = DVproy;

        grd001.DataBind();

        tituloGrid.Text = "Resumen de Atención";
        tituloGrid.Visible = true;

        grdResAtencionExcel.DataBind();



        int valver = 0;
        btn_excel.Visible = (DVproy.Tables[0].Rows.Count > 0);
        btn_Reliquidaciones.Visible = (DVproy.Tables[0].Rows.Count > 0);
        btn_Imprimir.Visible = (DVproy.Tables[0].Rows.Count > 0);
        btn_MarcaTodo.Visible = (DVproy.Tables[0].Rows.Count > 0);
        btn_DesmarcarTodo.Visible = (DVproy.Tables[0].Rows.Count > 0);
        btn_ResumenAtencion.Visible = false;
        grdReliquidaciones.Visible = false;
        grdReliquidacionesExcel.Visible = false;
        if (DVproy.Tables[0].Rows.Count > 0)
        {
            //Label1.Visible = false;
            pnl003.Visible = true;
            grd001.Visible = true;
            for (int i = 0; i < grd001.Rows.Count; i++)
            {

                if (grd001.Rows[i].Cells[5].Text.Substring(0, 10) == "01-01-1900")
                    grd001.Rows[i].Cells[5].Text = "";
                else
                    grd001.Rows[i].Cells[5].Text = grd001.Rows[i].Cells[5].Text.Substring(0, 10);

                if (grd001.Rows[i].Cells[7].Text.Substring(0, 10) == "01-01-1900")
                    grd001.Rows[i].Cells[7].Text = "";
                else
                    grd001.Rows[i].Cells[7].Text = grd001.Rows[i].Cells[7].Text.Substring(0, 10);

                if (grd001.Rows[i].Cells[9].Text.Substring(0, 10) == "01-01-1900")
                    grd001.Rows[i].Cells[9].Text = "";
                else
                    grd001.Rows[i].Cells[9].Text = grd001.Rows[i].Cells[9].Text.Substring(0, 10);

                //if (grd001.Rows[i].Cells[11].Text.Substring(0, 10) == "01-01-1900")
                //    grd001.Rows[i].Cells[11].Text = "";
                //else
                //    grd001.Rows[i].Cells[11].Text = grd001.Rows[i].Cells[11].Text.Substring(0, 10);

                tchkRetencionPago = (CheckBox)grd001.Rows[i].Cells[10].FindControl("chkRetencionPago");
                tchkRetencionPago.Attributes.Add("ROWIDEN", i.ToString());
                tchkRetencionPago.Attributes.Add("INITIALVALUE", grd001.Rows[i].Cells[10].Text);

                tchkFES = (CheckBox)grd001.Rows[i].Cells[6].FindControl("chkFES");
                tchkEnvioFinanciero = (CheckBox)grd001.Rows[i].Cells[8].FindControl("chkEnvioFinanciero");

                # region comentario
                //if (Convert.ToInt32(DVproy.Table.Rows[i][3]) == 0)
                //{
                //    //tchk001.Enabled = false;
                //    valver++;
                //}
                //if (Convert.ToInt32(DVproy.Table.Rows[i][3]) == 1)
                //    //tchk001.Checked = false;

                //if (Convert.ToInt32(DVproy.Table.Rows[i][3]) == 2)
                //    //tchk001.Checked = true;
                #endregion

                if (Convert.ToInt32(DVproy.Tables[0].Rows[i][9]) == 1)
                    tchkFES.Checked = true;

                if (Convert.ToInt32(DVproy.Tables[0].Rows[i][11]) == 1)
                    tchkEnvioFinanciero.Checked = true;

                if (Convert.ToInt32(DVproy.Tables[0].Rows[i][13]) == 1)
                    tchkRetencionPago.Checked = true;

                if (tchkFES.Checked || tchkEnvioFinanciero.Checked)
                    tchkRetencionPago.Enabled = false;
            }

            // Llenando gridView ResAtencionExcel
            for (int i = 0; i < grdResAtencionExcel.Rows.Count; i++)
            {

                if (grdResAtencionExcel.Rows[i].Cells[5].Text.Substring(0, 10) == "01-01-1900")
                    grdResAtencionExcel.Rows[i].Cells[5].Text = "";
                else
                    grdResAtencionExcel.Rows[i].Cells[5].Text = grdResAtencionExcel.Rows[i].Cells[5].Text.Substring(0, 10);

                if (grdResAtencionExcel.Rows[i].Cells[7].Text.Substring(0, 10) == "01-01-1900")
                    grdResAtencionExcel.Rows[i].Cells[7].Text = "";
                else
                    grdResAtencionExcel.Rows[i].Cells[7].Text = grdResAtencionExcel.Rows[i].Cells[7].Text.Substring(0, 10);

                if (grdResAtencionExcel.Rows[i].Cells[9].Text.Substring(0, 10) == "01-01-1900")
                    grdResAtencionExcel.Rows[i].Cells[9].Text = "";
                else
                    grdResAtencionExcel.Rows[i].Cells[9].Text = grdResAtencionExcel.Rows[i].Cells[9].Text.Substring(0, 10);

                if (grdResAtencionExcel.Rows[i].Cells[11].Text.Substring(0, 10) == "01-01-1900")
                    grdResAtencionExcel.Rows[i].Cells[11].Text = "";
                else
                    grdResAtencionExcel.Rows[i].Cells[11].Text = grdResAtencionExcel.Rows[i].Cells[11].Text.Substring(0, 10);

                tchkRetencionPago = (CheckBox)grdResAtencionExcel.Rows[i].Cells[10].FindControl("chkRetencionPago");
                tchkRetencionPago.Attributes.Add("ROWIDEN", i.ToString());
                tchkRetencionPago.Attributes.Add("INITIALVALUE", grdResAtencionExcel.Rows[i].Cells[10].Text);

                tchkFES = (CheckBox)grdResAtencionExcel.Rows[i].Cells[6].FindControl("chkFES");
                tchkEnvioFinanciero = (CheckBox)grdResAtencionExcel.Rows[i].Cells[8].FindControl("chkEnvioFinanciero");

                # region comentario
                //if (Convert.ToInt32(DVproy.Table.Rows[i][3]) == 0)
                //{
                //    //tchk001.Enabled = false;
                //    valver++;
                //}
                //if (Convert.ToInt32(DVproy.Table.Rows[i][3]) == 1)
                //    //tchk001.Checked = false;

                //if (Convert.ToInt32(DVproy.Table.Rows[i][3]) == 2)
                //    //tchk001.Checked = true;
                #endregion

                if (Convert.ToInt32(DVproy.Tables[0].Rows[i][9]) == 1)
                    tchkFES.Checked = true;

                if (Convert.ToInt32(DVproy.Tables[0].Rows[i][11]) == 1)
                    tchkEnvioFinanciero.Checked = true;

                if (Convert.ToInt32(DVproy.Tables[0].Rows[i][13]) == 1)
                    tchkRetencionPago.Checked = true;

                if (tchkFES.Checked || tchkEnvioFinanciero.Checked)
                    tchkRetencionPago.Enabled = false;
            }

            grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
            grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

            ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grd001')); });", true);
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Informacion", "window.alert(' INFORMACIÓN')", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#pnlAlert').fadeIn();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "quitarAlert  ", "$('#pnlAlert').delay(4000).fadeOut();", true);
            tituloGrid.Visible = false;
            //Label1.Visible = true;
            pnl003.Visible = false;
            grd001.Visible = false;
            pnl001.Visible = false;
        }

        if (valver == grd001.Rows.Count)
            btn_guardar.Visible = false;
        //else
        //    btn_guardar.Visible  = true; 

        validatescurity();

        grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grd001')); });", true);

        //Esto es lo que se debe añadir para formatear la tabla

    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        lblano.Visible = false;
        lblmes.Visible = false;
        lblmsj.Visible = false;
        pnl001.Visible = false;
        grd001.Visible = false;
        grdReliquidaciones.Visible = false;
        btn_excel.Visible = false;
        btn_Reliquidaciones.Visible = false;
        btn_Imprimir.Visible = false;
        btn_MarcaTodo.Visible = false;
        btn_DesmarcarTodo.Visible = false;
        btn_ResumenAtencion.Visible = false;
        pnl003.Visible = false;
        ddown001.SelectedIndex = 0;
        ddown004.SelectedIndex = 0;
        ddown005.SelectedIndex = 0;
        ddownAno.SelectedIndex = 0;
        //txt001.Text = "";
        btn_guardar.Visible = false;
        tituloGrid.Visible = false;
    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        funcion_guardar();
        btn_buscar_Click(sender, e);
    }
    private void funcion_guardar()
    {
        Recepcioncoll rcol = new Recepcioncoll();
        CheckBox tchkRetencion = new CheckBox();
        DateTime FechaRecepcion;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            int estado;
            tchkRetencion = (CheckBox)grd001.Rows[i].Cells[8].FindControl("chkRetencionPago");

            if (tchkRetencion.Enabled)
            {
                if (tchkRetencion.Checked)
                {
                    estado = 1;
                    FechaRecepcion = Convert.ToDateTime(grd001.Rows[i].Cells[11].Text);
                }
                else
                {
                    estado = 0;
                    FechaRecepcion = Convert.ToDateTime("01-01-1900");
                }
                Int32 CodProyecto = Convert.ToInt32(grd001.Rows[i].Cells[2].Text);
                int AnoMes = Convert.ToInt32(lblano.Text + lblnromes.Text);
                Int32 Correlativo;
                if (grd001.Rows[i].Cells[4].Text.Trim() != "0")
                {
                    Correlativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);
                    rcol.Cierre_Retencion_Guardar(CodProyecto, AnoMes, Correlativo, FechaRecepcion, estado, Convert.ToInt32(Session["IdUsuario"]));
                }
            }
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (grd001.Visible)
            CargaFiltro(txt006.Text.Trim());
        else
        {
            DataSet dv = DvReliquidaciones;

            if (txt006.Text.Trim() != "")
                dv.Tables[0].DefaultView.RowFilter = "CodProyecto = " + txt006.Text.Trim();
            else
                dv.Tables[0].DefaultView.RowFilter = "";

            grdReliquidaciones.DataSource = dv;
            grdReliquidaciones.DataBind();
            tituloGrid.Text = "Reliquidaciones y Otros";
            tituloGrid.Visible = true;

            grdReliquidaciones.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
            grdReliquidaciones.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

            ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grdReliquidaciones')); });", true);

        }
    }
    private void CargaFiltro(String Filtro)
    {
        CheckBox tchk001 = new CheckBox();
        DataSet dv = DVproy;
        int valver = 0;
        grd001.Page.Items.Clear();
        if (txt006.Text.Trim() != "")
        {
            dv.Tables[0].DefaultView.RowFilter = "CodProyecto = " + Filtro.ToUpper();
        }
        else
        {
            dv.Tables[0].DefaultView.RowFilter = "CodProyecto = CodProyecto";
        }
        grd001.DataSource = dv;
        grd001.DataBind();
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            if (grd001.Rows[i].Cells[4].Text == "01/01/1900")
            {
                grd001.Rows[i].Cells[4].Text = "";

            }
            tchk001 = (CheckBox)grd001.Rows[i].Cells[5].FindControl("chk001");

            if (Convert.ToInt32(dv.Tables[0].Rows[i][5]) == 0)
            {
                tchk001.Enabled = false;

                valver++;
            }
            if (Convert.ToInt32(dv.Tables[0].Rows[i][5]) == 1)
            {
                tchk001.Checked = false;
            }
            if (Convert.ToInt32(dv.Tables[0].Rows[i][5]) == 2)
            {
                tchk001.Checked = true;
            }

        }

        if (valver == grd001.Rows.Count)
        {
            btn_guardar.Visible = false;
        }
        //else
        //{

        //    btn_guardar.Visible  = true; 
        //}
        validatescurity();

        grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grd001')); });", true);
    }
    protected void chk001_CheckedChanged1(object sender, EventArgs e)
    {

        try
        {
            CheckBox chk = (CheckBox)sender;
            int ri = Convert.ToInt32(chk.Attributes["ROWIDEN"]);
            if (chk.Checked)
                grd001.Rows[ri].Cells[4].Text = DateTime.Now.Date.ToShortDateString();
            else
                grd001.Rows[ri].Cells[4].Text = string.Empty;
        }
        catch
        { }


    }

    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddownAno.Text.Trim() == "")
        {
            ddownAno.BackColor = colorCampoObligatorio;
            ddown004.SelectedIndex = 0;
            lblano.Visible = false;
            lblmes.Visible = false;
            lblmsj.Visible = false;
        }
        else
        {
            ddownAno.BackColor = System.Drawing.Color.White;
            switch (Convert.ToInt32(ddown004.SelectedValue))
            {
                case 1:
                    lblano.Text = Convert.ToString(Convert.ToInt32(ddownAno.Text) - 1);
                    lblmes.Text = "Diciembre";
                    lblnromes.Text = "12";
                    break;
                case 2:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Enero";
                    lblnromes.Text = "01";
                    break;
                case 3:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Febrero";
                    lblnromes.Text = "02";
                    break;
                case 4:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Marzo";
                    lblnromes.Text = "03";
                    break;
                case 5:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Abril";
                    lblnromes.Text = "04";
                    break;
                case 6:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Mayo";
                    lblnromes.Text = "05";
                    break;
                case 7:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Junio";
                    lblnromes.Text = "06";
                    break;
                case 8:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Julio";
                    lblnromes.Text = "07";
                    break;
                case 9:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Agosto";
                    lblnromes.Text = "08";
                    break;
                case 10:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Septiembre";
                    lblnromes.Text = "09";
                    break;
                case 11:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Octubre";
                    lblnromes.Text = "10";
                    break;
                case 12:
                    lblano.Text = Convert.ToString(ddownAno.Text);
                    lblmes.Text = "Noviembre";
                    lblnromes.Text = "11";
                    break;
            }

            lblmsj.Text = "Fecha Atención (mes/año): ";
            lblano.Visible = true;
            lblmes.Visible = true;
            lblmsj.Visible = true;

        }
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        //CargaGrilla();
        // funcion_carga_pag();
        DataSet dv = DVproy;

        grd001.DataSource = dv;
        grd001.DataBind();


    }
    protected void grdReliquidaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdReliquidaciones.PageIndex = e.NewPageIndex;
        //CargaGrilla();
        // funcion_carga_pag();
        DataSet dv = DvReliquidaciones;

        grdReliquidaciones.DataSource = dv;
        grdReliquidaciones.DataBind();

        grdReliquidaciones.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grdReliquidaciones.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grdReliquidaciones')); });", true);
    }

    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {
        if (grdReliquidaciones.Visible)
        {
            ExportaExcelReliquidaciones();
            return;
        }

        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=RecepcionResumenAtencion.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodInstitucion");       //0
        dt.Columns.Add("Institucion");          //1
        dt.Columns.Add("CodProyecto");	        //2
        dt.Columns.Add("Proyecto");		        //3
        dt.Columns.Add("Correlativo");          //4
        dt.Columns.Add("FechaCierre");          //5
        dt.Columns.Add("FES");                  //6
        dt.Columns.Add("FechaEnvioFES");        //7
        // -----------------------------------------
        dt.Columns.Add("EnvioFinanciero");      //8
        dt.Columns.Add("FechaEnvioFinanciero"); //9
        // -----------------------------------------
        dt.Columns.Add("RetencionPago");        //10
        dt.Columns.Add("FechaRetencionPago");   //11
        // -----------------------------------------
        dt.Columns.Add("AnoMesAtencion");       //12

        DataRow dr;

        // Get the HTML for the control.
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            dr = dt.NewRow();
            for (int j = 0; j < grd001.Columns.Count - 2; j++)
            {
                if (j == 6 || j == 8 || j == 10)
                {
                    if (grd001.Rows[i].Cells[j + 1].Text != string.Empty)
                        dr[j] = "SI";
                    else
                        dr[j] = "NO";
                }
                else
                    dr[j] = grd001.Rows[i].Cells[j].Text;
            }
            dr[12] = lblano.Text + "-" + lblnromes.Text;
            dt.Rows.Add(dr);
        }
        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        //Write the HTML back to the browser.
        Response.Write(tw.ToString());
        // End the response.
        Response.End();
    }

    private void ExportaExcelReliquidaciones()
    {
        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=ReliquidacionesOtros.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodInstitucion");       //0
        dt.Columns.Add("Institucion");          //1
        dt.Columns.Add("CodProyecto");	        //2
        dt.Columns.Add("Proyecto");		        //3
        dt.Columns.Add("AnoMes");               //4
        dt.Columns.Add("Correlativo");          //5
        dt.Columns.Add("FechaCierre");          //6

        DataRow dr;

        // Get the HTML for the control. OLD
        //for (int i = 0; i < grdReliquidaciones.Rows.Count; i++)
        //{
        //    dr = dt.NewRow();
        //    for (int j = 0; j < grdReliquidaciones.Columns.Count; j++)
        //    {
        //        dr[j] = grdReliquidaciones.Rows[i].Cells[j].Text;
        //    }
        //    dt.Rows.Add(dr);
        //}

        // Get the HTML for the control.
        for (int i = 0; i < grdReliquidacionesExcel.Rows.Count; i++)
        {
            dr = dt.NewRow();
            for (int j = 0; j < grdReliquidacionesExcel.Columns.Count; j++)
            {
                dr[j] = grdReliquidacionesExcel.Rows[i].Cells[j].Text;
            }
            dt.Rows.Add(dr);
        }


        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        //Write the HTML back to the browser.
        Response.Write(tw.ToString());
        // End the response.
        Response.End();
    }
    protected void btn_Reliquidaciones_Click(object sender, EventArgs e)
    {
        string MesAno = lblano.Text + lblnromes.Text;
        Recepcioncoll rcol = new Recepcioncoll();
        DvReliquidaciones = new DataSet();
        DvReliquidaciones.Tables.Add(rcol.Cierre_Recepcion_MovimientoMensual_Reliquidaciones(Convert.ToInt32(MesAno), 0, Convert.ToInt32(ddown001.SelectedValue)));
        grdReliquidaciones.DataSource = DvReliquidaciones;
        grdReliquidacionesExcel.DataSource = DvReliquidaciones;
        grdReliquidaciones.DataBind();
        grdReliquidacionesExcel.DataBind();
        grd001.Visible = false;
        grdReliquidaciones.Visible = true;
        btn_ResumenAtencion.Visible = true;
        btn_Reliquidaciones.Visible = false;
        btn_Imprimir.Visible = false;
        btn_MarcaTodo.Visible = false;
        btn_DesmarcarTodo.Visible = false;
        //if (DvReliquidaciones.Table.Rows.Count > 0)
        //{
        //    CheckBox tchkFES;
        //    for (int i = 0; i < grdReliquidaciones.Rows.Count; i++)
        //    {
        //        tchkFES = (CheckBox)grdReliquidaciones.Rows[i].Cells[5].FindControl("chkFES");
        //        if (Convert.ToInt32(DvReliquidaciones.Table.Rows[i][9]) == 1)
        //            tchkFES.Checked = true;
        //    }
        //}
        for (int i = 0; i < grdReliquidaciones.Rows.Count; i++)
        {

            if (grdReliquidaciones.Rows[i].Cells[6].Text.Substring(0, 10) == "01-01-1900")
                grdReliquidaciones.Rows[i].Cells[6].Text = "";
            else
                grdReliquidaciones.Rows[i].Cells[6].Text = grdReliquidaciones.Rows[i].Cells[6].Text.Substring(0, 10);
        }
        tituloGrid.Text = "Reliquidaciones y Otros";
        grdReliquidaciones.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grdReliquidaciones.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grdReliquidaciones')); });", true);
    }
    protected void btn_ResumenAtencion_Click(object sender, EventArgs e)
    {
        btn_ResumenAtencion.Visible = false;
        btn_Reliquidaciones.Visible = true;
        btn_Imprimir.Visible = true;
        btn_MarcaTodo.Visible = true;
        btn_DesmarcarTodo.Visible = true;
        grd001.Visible = true;
        grdReliquidaciones.Visible = false;
        tituloGrid.Text = "Resumen de Atención";
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grd001')); });", true);
    }
    protected void chkRetencionPago_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (CheckBox)sender;
            int ri = Convert.ToInt32(chk.Attributes["ROWIDEN"]);
            if (chk.Checked)
                grd001.Rows[ri].Cells[11].Text = DateTime.Now.Date.ToShortDateString();
            else
                grd001.Rows[ri].Cells[11].Text = string.Empty;
        }
        catch
        { }
    }
    protected void grd001_RowVer(object sender, GridViewEditEventArgs e)
    {
        #region antiguo
        //string strAnoMes = lblano.Text + lblnromes.Text;
        //string CodProyecto = grd001.Rows[e.NewEditIndex].Cells[2].Text;

        //Int32 intCorrelativo = Convert.ToInt32(grd001.Rows[e.NewEditIndex].Cells[4].Text);
        //string url = "CodProyecto=" + CodProyecto + "&AnoMes=" + strAnoMes + "&IdUsr=" + Session["IdUsuario"].ToString();
        ////
        //string strURL = @"Reporte.aspx?" + url;
        ////string strURL = @"..\mod_ninos\Cierre_ResumenAtencionReporte.aspx?" + url;
        ////        Response.Redirect(strURL);

        ////window.open(Page, "\\ARGENTIS.SENAINFO\\mod_ninos\\Cierre_ResumenAtencionReporte.aspx?" + url, 600, 800);
        ////window.open(Page, strURL, 600, 800);
        ////String aa = "<a href='" + strURL + "' target='_blank'>new Window</a>";
        ////Response.Write(aa);
        ////Response.Redirect("", 
        //window.open(Page, strURL, 600, 800);
        #endregion

        Int32 intCorrelativo = Convert.ToInt32(grd001.Rows[e.NewEditIndex].Cells[4].Text);
        if (intCorrelativo > 0)
        {
            string strAnoMes = lblano.Text + lblnromes.Text;
            string CodProyecto = grd001.Rows[e.NewEditIndex].Cells[2].Text;

            string url = "CodProyecto=" + CodProyecto + "&AnoMes=" + strAnoMes + "&IdUsr=" + Session["IdUsuario"].ToString() + "&TipoDocumento=1";
            url = "Reporte.aspx?" + url;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "darClick('" + url + "');", true);
            iframe_Ver.Src = url;
            mp_Ver.Show();

        }
        e.Cancel = true;

        //Esto es lo que se debe añadir para formatear la tabla
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { formatearTabla($('#grd001')); });", true);

    }


    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {
        string strAnoMes = String.Empty;
        string CodProyecto = String.Empty;

        CheckBox tchkImprimir = new CheckBox();
        Int32 intCorrelativo = 0;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            tchkImprimir = (CheckBox)grd001.Rows[i].Cells[13].FindControl("chkImprimir");
            intCorrelativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);

            if (tchkImprimir.Checked && intCorrelativo > 0)
            {
                strAnoMes = lblano.Text + lblnromes.Text;
                CodProyecto = grd001.Rows[i].Cells[2].Text;
                Imprime(CodProyecto, strAnoMes);
            }
        }
    }
    protected void Imprime(String CodProyecto, String AnoMes)
    {
        DataTable dt = getImpresionResumen(Convert.ToInt32(CodProyecto), Convert.ToInt32(AnoMes));

        ExportOptions crExportOptions = new ExportOptions();
        DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ReportDocument reportDocument = new ReportDocument();

        ninocoll ncoll = new ninocoll();
        int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(CodProyecto));
        string rptName = "";

        if (CodModeloIntervencion == 83) rptName = "crResumenAtencionMensual_PAD.rpt"; else rptName = "crResumenAtencionMensual.rpt";

        string rptPath = ConfigurationManager.AppSettings["PathReportes"].ToString();
        reportDocument.Load(@rptPath + rptName);
        reportDocument.SetDataSource(dt);
        reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
        reportDocument.PrintToPrinter(1, false, 0, 0);
        reportDocument.Dispose();
        reportDocument.Close();
    }
    public DataTable getImpresionResumen(int CodProyecto, int MesAno)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_resumenatencionmensual_Firma_impresion";


        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = MesAno;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    protected void btn_MarcaTodo_Click(object sender, EventArgs e)
    {
        CheckBox tchkImprimir = new CheckBox();
        Int32 intCorrelativo = 0;
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            intCorrelativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);
            tchkImprimir = (CheckBox)grd001.Rows[i].Cells[13].FindControl("chkImprimir");
            tchkImprimir.Checked = intCorrelativo != 0;
        }
    }
    protected void btn_DesmarcarTodo_Click(object sender, EventArgs e)
    {
        CheckBox tchkImprimir = new CheckBox();
        Int32 intCorrelativo = 0;
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            intCorrelativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);
            tchkImprimir = (CheckBox)grd001.Rows[i].Cells[13].FindControl("chkImprimir");
            tchkImprimir.Checked = false;
        }
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        if (grdReliquidaciones.Visible)
        {
            ExportaExcelReliquidaciones();
            return;
        }

        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=RecepcionResumenAtencion.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodInstitucion");       //0
        dt.Columns.Add("Institucion");          //1
        dt.Columns.Add("CodProyecto");	        //2
        dt.Columns.Add("Proyecto");		        //3
        dt.Columns.Add("Correlativo");          //4
        dt.Columns.Add("FechaCierre");          //5
        dt.Columns.Add("FES");                  //6
        dt.Columns.Add("FechaEnvioFES");        //7
        // -----------------------------------------
        dt.Columns.Add("EnvioFinanciero");      //8
        dt.Columns.Add("FechaEnvioFinanciero"); //9
        // -----------------------------------------
        dt.Columns.Add("RetencionPago");        //10
        dt.Columns.Add("FechaRetencionPago");   //11
        // -----------------------------------------
        dt.Columns.Add("AnoMesAtencion");       //12

        DataRow dr;

        // Get the HTML for the control. OLD
        //for (int i = 0; i < grd001.Rows.Count; i++)
        //{
        //    dr = dt.NewRow();
        //    for (int j = 0; j < grd001.Columns.Count - 2; j++)
        //    {
        //        if (j == 6 || j == 8 || j == 10)
        //        {
        //            if (grd001.Rows[i].Cells[j + 1].Text != string.Empty)
        //                dr[j] = "SI";
        //            else
        //                dr[j] = "NO";
        //        }
        //        else
        //            dr[j] = grd001.Rows[i].Cells[j].Text;
        //    }
        //    dr[12] = lblano.Text + "-" + lblnromes.Text;
        //    dt.Rows.Add(dr);
        //}

        //Get the HTML for the control. O

        for (int i = 0; i < grdResAtencionExcel.Rows.Count; i++)
        {
            dr = dt.NewRow();
            for (int j = 0; j < grdResAtencionExcel.Columns.Count - 2; j++)
            {
                if (j == 6 || j == 8 || j == 10)
                {
                    if (grdResAtencionExcel.Rows[i].Cells[j + 1].Text != string.Empty)
                        dr[j] = "SI";
                    else
                        dr[j] = "NO";
                }
                else
                    dr[j] = grdResAtencionExcel.Rows[i].Cells[j].Text;
            }
            dr[12] = lblano.Text + "-" + lblnromes.Text;
            dt.Rows.Add(dr);
        }

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        //Write the HTML back to the browser.
        Response.Write(tw.ToString());
        // End the response.
        Response.End();
    }

    protected void ddownAno_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddownAno.BackColor = System.Drawing.Color.White;
        switch (Convert.ToInt32(ddown004.SelectedValue))
        {
            case 1:
                lblano.Text = Convert.ToString(Convert.ToInt32(ddownAno.Text) - 1);
                lblmes.Text = "Diciembre";
                lblnromes.Text = "12";
                break;
            case 2:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Enero";
                lblnromes.Text = "01";
                break;
            case 3:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Febrero";
                lblnromes.Text = "02";
                break;
            case 4:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Marzo";
                lblnromes.Text = "03";
                break;
            case 5:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Abril";
                lblnromes.Text = "04";
                break;
            case 6:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Mayo";
                lblnromes.Text = "05";
                break;
            case 7:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Junio";
                lblnromes.Text = "06";
                break;
            case 8:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Julio";
                lblnromes.Text = "07";
                break;
            case 9:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Agosto";
                lblnromes.Text = "08";
                break;
            case 10:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Septiembre";
                lblnromes.Text = "09";
                break;
            case 11:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Octubre";
                lblnromes.Text = "10";
                break;
            case 12:
                lblano.Text = Convert.ToString(ddownAno.Text);
                lblmes.Text = "Noviembre";
                lblnromes.Text = "11";
                break;
        }

        lblmsj.Text = "Fecha Atención (mes/año): ";
        lblano.Visible = true;
        lblmes.Visible = true;
        lblmsj.Visible = true;

    }
}
