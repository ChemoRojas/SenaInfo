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
using System.Drawing.Printing;
using System.Drawing;
using System.Data.SqlClient;

public partial class mod_recepcion_Recep_RendCuenta : System.Web.UI.Page
{
    public DataTable DTingresoResumen
    {
        get { return (DataTable)Session["DTingresoResumen"]; }
        set { Session["DTingresoResumen"] = value; }
    }
    public DataTable DTegresoResumen
    {
        get { return (DataTable)Session["DTegresoResumen"]; }
        set { Session["DTegresoResumen"] = value; }
    }

    public DataSet DVfiltro
    {
        get { return (DataSet)Session["DVfiltro"]; }
        set { Session["DVfiltro"] = value; }
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
                if (!window.existetoken("A1403397-FF92-48F1-A3CB-123DBEB7064F"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                getregion();
                getAnos();
                UpdateProgress1.EnableViewState = true;
               // getinstitucion();
               
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codregion = bsc.GetCodRegionxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codregion);
                }
                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }
    }
    private void validatescurity()
    {
        //E681BCEC-7ACA-44AC-915D-7478ACC87545 4.1_INGRESAR
        if (!window.existetoken("C5034C6A-727B-4903-B71A-726FB6974D4F"))
        {
            btn_confirmar.Visible = false;
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                grd001.Rows[i].Cells[6].Enabled = false;
            }

        }
        //6F89B8C7-B911-4F0F-9A21-3A407CE419B4 4.1_MODIFICAR
        if (!window.existetoken("2AF9A778-66AA-4C3A-BC8B-842E9BDB1AE0"))
        {
           
        }
    }
    private void getregion()
    {


        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        //DataView dv = new DataView(par.GetparRegion());
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodRegion";
        dv.Sort = "CodRegion";
        ddown001.DataBind();


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
        Response.Redirect("index_recepcion.aspx");
    }
    
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        
        //if (ddown001.SelectedValue == "-2" || txt001.Text.Trim() == "" || ddown004.SelectedValue == "0")
        if (ddown001.SelectedValue == "-2" || ddownAno.SelectedValue == "0" || ddown004.SelectedValue == "0")
        {
            if (ddown001.SelectedValue == "-2") { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }
            if (ddownAno.Text.Trim() == "") { ddownAno.BackColor = colorCampoObligatorio; }
            else { ddownAno.BackColor = System.Drawing.Color.White; }
            if (ddown004.SelectedValue == "0") { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;
            ddownAno.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            funcion_buscar();
        }
    }
    private void funcion_buscar()
    {
        CheckBox tchk001 = new CheckBox(); CheckBox tchkFES = new CheckBox(); CheckBox tchkEnAuditoria = new CheckBox();
        Recepcioncoll rcol = new Recepcioncoll();
        DataTable dt = rcol.rendicion_recepcionrendicioncuentas("S", 0, Convert.ToInt32(ddown001.SelectedValue),
            Convert.ToInt32(ddownAno.Text + ddown004.SelectedValue), Convert.ToInt32(ddown005.SelectedValue), 0, Convert.ToDateTime("01-01-1900"),
            0, 0);
        DVfiltro = new DataSet();
        DVfiltro.Tables.Add(dt);
        int valver = 0;
        if (dt.Rows.Count > 0)
        {
            btn_excel.Visible = true;
            //Label1.Visible = false;
            grd001.DataSource = dt;
            grd001.DataBind();
              
            grd001.Visible = true;
            
            //btn_confirmar.Visible = true;
            btn_MarcaTodo.Visible = true;
            btn_DesmarcarTodo.Visible = true;
            btn_Imprimir.Visible = true;

            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                if (grd001.Rows[i].Cells[5].Text.Substring(0, 10) == "01-01-1900")
                    grd001.Rows[i].Cells[5].Text = "";

                if (grd001.Rows[i].Cells[10].Text.Substring(0, 10) == "01-01-1900")
                    grd001.Rows[i].Cells[10].Text = "";

                if (grd001.Rows[i].Cells[12].Text.Substring(0, 10) == "01-01-1900")
                   grd001.Rows[i].Cells[12].Text = "";
                

                tchk001 = (CheckBox)grd001.Rows[i].Cells[9].FindControl("chk001");
                tchk001 = (CheckBox)grd001.Rows[i].Cells[9].FindControl("chk001");

                tchk001.Attributes.Add("ROWIDEN", i.ToString());
                tchk001.Attributes.Add("INITIALVALUE", grd001.Rows[i].Cells[10].Text);

                tchkFES = (CheckBox)grd001.Rows[i].Cells[11].FindControl("chkFES");
                tchkEnAuditoria = (CheckBox)grd001.Rows[i].Cells[15].FindControl("chkEnAuditoria");

                if (Convert.ToInt32(dt.Rows[i][14]) == 1)   // Si está retenido
                {
                    tchk001.Checked = true;
                    valver++;
                }
                //if (Convert.ToInt32(dt.Rows[i][9]) == 1)
                //    tchk001.Enabled = true;
                //if (Convert.ToInt32(dt.Rows[i][10]) == 0)
                //    tchk001.Checked = false;
                //if (Convert.ToInt32(dt.Rows[i][10]) == 1)
                //    tchk001.Checked = true;

                if (Convert.ToInt32(dt.Rows[i][10]) == 1)
                    tchkFES.Checked = true;
               
                if (Convert.ToInt32(dt.Rows[i]["EnAuditoria"]) == 1)
                    tchkEnAuditoria.Checked = true;
            }

            //for (int i = 0; i < grdExcel.Rows.Count; i++)
            //{
            //    if (grdExcel.Rows[i].Cells[5].Text.Substring(0, 10) == "01-01-1900")
            //        grdExcel.Rows[i].Cells[5].Text = "";

            //    if (grdExcel.Rows[i].Cells[10].Text.Substring(0, 10) == "01-01-1900")
            //        grdExcel.Rows[i].Cells[10].Text = "";

            //    if (grdExcel.Rows[i].Cells[12].Text.Substring(0, 10) == "01-01-1900")
            //        grdExcel.Rows[i].Cells[12].Text = "";


            //    tchk001 = (CheckBox)grdExcel.Rows[i].Cells[9].FindControl("chk001");
            //    tchk001 = (CheckBox)grdExcel.Rows[i].Cells[9].FindControl("chk001");

            //    tchk001.Attributes.Add("ROWIDEN", i.ToString());
            //    tchk001.Attributes.Add("INITIALVALUE", grdExcel.Rows[i].Cells[10].Text);

            //    tchkFES = (CheckBox)grdExcel.Rows[i].Cells[11].FindControl("chkFES");
            //    tchkEnAuditoria = (CheckBox)grdExcel.Rows[i].Cells[15].FindControl("chkEnAuditoria");

            //    if (Convert.ToInt32(dt.Rows[i][14]) == 1)   // Si está retenido
            //    {
            //        tchk001.Checked = true;
            //        valver++;
            //    }
            //    //if (Convert.ToInt32(dt.Rows[i][9]) == 1)
            //    //    tchk001.Enabled = true;
            //    //if (Convert.ToInt32(dt.Rows[i][10]) == 0)
            //    //    tchk001.Checked = false;
            //    //if (Convert.ToInt32(dt.Rows[i][10]) == 1)
            //    //    tchk001.Checked = true;

            //    if (Convert.ToInt32(dt.Rows[i][10]) == 1)
            //        tchkFES.Checked = true;

            //    if (Convert.ToInt32(dt.Rows[i]["EnAuditoria"]) == 1)
            //        tchkEnAuditoria.Checked = true;
            //}
            
        }
        else
        {
            //Label1.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Informacion", "window.alert('NO REGISTRA INFORMACIÓN')", true);
            grd001.Visible = false;
            btn_confirmar.Visible = false;
            btn_MarcaTodo.Visible = false;
            btn_DesmarcarTodo.Visible = false;
            btn_Imprimir.Visible = false;
        }
        if (valver == grd001.Rows.Count)
        {
            btn_confirmar.Visible = false;
            btn_MarcaTodo.Visible = false;
            btn_DesmarcarTodo.Visible = false;
            btn_Imprimir.Visible = false;
        }
        else
        {

            //btn_confirmar.Visible = true;
            btn_MarcaTodo.Visible = true;
            btn_DesmarcarTodo.Visible = true;
            btn_Imprimir.Visible = true;
        }

        validatescurity();


        //LLenando Grid Excel
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { $('#grd001').DataTable({ searching: true, sort: false, paging: true }); });", true);

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CargaFiltro(txt002.Text);
    }
    private void CargaFiltro(String Filtro)
    {
        CheckBox tchk001 = new CheckBox();
        int valver = 0;
        DataSet dv = DVfiltro;
        grd001.Page.Items.Clear();
        if (txt002.Text.Trim() != "")
        {
            dv.Tables[0].DefaultView.RowFilter = "CodProyecto = " + Filtro.Trim();
        }
        else
        {
            dv.Tables[0].DefaultView.RowFilter = "CodProyecto = CodProyecto";
        }
       
        grd001.DataSource = dv;
        grd001.DataBind();

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
           
            tchk001 = (CheckBox)grd001.Rows[i].Cells[8].FindControl("chk001");

            if (Convert.ToInt32(dv.Tables[0].Rows[i][9]) == 0)
            {
                tchk001.Enabled = false;
                valver++;
            }
            if (Convert.ToInt32(dv.Tables[0].Rows[i][9]) == 1)
            {
                tchk001.Enabled = true;
            }
            if (Convert.ToInt32(dv.Tables[0].Rows[i][10]) == 0)
            {
                tchk001.Checked = false;
            }
            if (Convert.ToInt32(dv.Tables[0].Rows[i][10]) == 1)
            {
                tchk001.Checked = true;
            }

        }

        if (valver == grd001.Rows.Count)
        {
            btn_confirmar.Visible = false;
            btn_MarcaTodo.Visible = false;
            btn_DesmarcarTodo.Visible = false;
            btn_Imprimir.Visible = false;
        }
        else
        {

            //btn_confirmar.Visible = true;
            btn_MarcaTodo.Visible = true;
            btn_DesmarcarTodo.Visible = true;
            btn_Imprimir.Visible = true;
        }
        validatescurity();
    }
    protected void chk001_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (CheckBox)sender;
            int ri = Convert.ToInt32(chk.Attributes["ROWIDEN"]);
            if (chk.Checked)
                grd001.Rows[ri].Cells[10].Text = DateTime.Now.Date.ToShortDateString();
            else
                grd001.Rows[ri].Cells[10].Text = string.Empty;
        }
        catch
        { }
    }
    protected void btn_confirmar_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    private void funcion_guardar()
    {
        Recepcioncoll rcol = new Recepcioncoll();
        CheckBox tchkRetencion = new CheckBox();
        DateTime FechaRecepcion;
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            int estado;
            tchkRetencion = (CheckBox)grd001.Rows[i].Cells[9].FindControl("chk001");

            if (tchkRetencion.Enabled)
            {
                if (tchkRetencion.Checked)
                {
                    estado = 1;
                    FechaRecepcion = Convert.ToDateTime(grd001.Rows[i].Cells[10].Text);
                }
                else
                {
                    estado = 0;
                    FechaRecepcion = Convert.ToDateTime("01-01-1900");
                }
                Int32 CodProyecto = Convert.ToInt32(grd001.Rows[i].Cells[2].Text);
                int AnoMes = Convert.ToInt32(ddownAno.SelectedValue + ddown004.SelectedValue );
                Int32 Correlativo;
                //rcol.Cierre_Retencion_Guardar(CodProyecto, AnoMes, Correlativo, FechaRecepcion, estado, Convert.ToInt32(Session["IdUsuario"]));
                DataTable dt;
                if (grd001.Rows[i].Cells[4].Text.Trim() != "")
                {
                    Correlativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);
                    dt = rcol.rendicion_RetencionCuentas(CodProyecto, AnoMes, Correlativo, FechaRecepcion, estado, Convert.ToInt32(Session["IdUsuario"]));
                }
            }
        }

#region codigo antiguo
        //DateTime FechaRecepcion;
        // Recepcioncoll rcol = new Recepcioncoll();
        // CheckBox tchk001 = new CheckBox();
        // for (int i = 0; i < grd001.Rows.Count; i++)
        // {
        //     tchk001 = (CheckBox)grd001.Rows[i].Cells[6].FindControl("chk001");
        //     if (tchk001.Enabled == true)
        //     {
        //         if (tchk001.Checked == true)
        //         {
                    
        //             if (grd001.Rows[i].Cells[7].Text.Trim() == "")
        //             {
        //                 FechaRecepcion = Convert.ToDateTime("01-01-1900");
        //             }
        //             else
        //             {
        //                 FechaRecepcion = Convert.ToDateTime(grd001.Rows[i].Cells[7].Text);
        //             }
        //             int Ipago=0;
        //             if (Server.HtmlDecode(grd001.Rows[i].Cells[2].Text).Trim() != "")
        //             {
        //                 Ipago = Convert.ToInt32(grd001.Rows[i].Cells[2].Text);
        //             }
        //             DataTable dt = rcol.rendicion_recepcionrendicioncuentas("I", Convert.ToInt32(grd001.Rows[i].Cells[0].Text),
        //             Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(txt001.Text + ddown004.SelectedValue),1,Ipago,
        //             FechaRecepcion, Convert.ToInt32(Session["IdUsuario"])/*USR*/, 0);
        //         }
        //         else
        //         {
        //             FechaRecepcion = Convert.ToDateTime("01-01-1900");
        //             DataTable dt = rcol.rendicion_recepcionrendicioncuentas("D", 0, 0, 0, 0, Convert.ToInt32(grd001.Rows[i].Cells[2].Text), FechaRecepcion, Convert.ToInt32(Session["IdUsuario"])/*USR*/, 0);
                 
                 
        //         }
        //     }
        // }
        #endregion
     }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        btn_confirmar.Visible = false;
        btn_MarcaTodo.Visible = false;
        btn_DesmarcarTodo.Visible = false;
        btn_Imprimir.Visible = false;
        grd001.Visible = false;
        btn_excel.Visible = false;
        ddown001.SelectedIndex = 0;
        ddown004.SelectedIndex = 0;
        ddown005.SelectedIndex = 0; 
        ddownAno.SelectedIndex = 0;
        //txt001.Text = "";
        //txt002.Text = "";
    }
   
    protected void txt001_ValueChange(object sender, EventArgs e)
    {
        //ddown004.SelectedIndex = 0;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_recepcion/Recep_RendCuenta.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=CertificacionDeRendicionDeCuenta.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        
        DataTable dt = new DataTable();
        dt.Columns.Add("CodInstitucion");   //0
        dt.Columns.Add("Institucion");      //1
        dt.Columns.Add("CodProyecto");	    //2
        dt.Columns.Add("Proyecto");		    //3
        dt.Columns.Add("Correlativo");      //4
        dt.Columns.Add("FechaCierre");	    //5
        dt.Columns.Add("IPago");		    //6
        dt.Columns.Add("AnoMes");		    //7
        dt.Columns.Add("FechaFin"); 		//8
        dt.Columns.Add("RetencionPago");    //9
        dt.Columns.Add("FechaRetencionPago");   //10
        dt.Columns.Add("FES");              //11
        dt.Columns.Add("FechaEnvioFES");    //12
        dt.Columns.Add("EnAuditoria");      //13

        DataRow dr;


        // Get the HTML for the control. OLD
        CheckBox tchkEnAuditoria = new CheckBox();
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
          dr = dt.NewRow();
          for (int j = 0; j < grd001.Columns.Count; j++)
          {
            if (j == 9 || j == 11 || j == 15)
            {
              if (j == 15)
              {
                tchkEnAuditoria = (CheckBox)grd001.Rows[i].Cells[15].FindControl("chkEnAuditoria");
                if (tchkEnAuditoria.Checked)
                  dr[j - 2] = "SI";
                else
                  dr[j - 2] = "NO";
              }
              else
              {
                if (grd001.Rows[i].Cells[j + 1].Text != string.Empty)
                  dr[j] = "SI";
                else
                  dr[j] = "NO";
              }
            }
            else
            {
              if (j != 13 && j != 14)
                dr[j] = grd001.Rows[i].Cells[j].Text;
            }
          }
          dt.Rows.Add(dr);
        }


        // Get the HTML for the control.
        // CheckBox tchkEnAuditoria = new CheckBox();
        //for (int i = 0; i < grdExcel.Rows.Count; i++)
        //{
        //    dr = dt.NewRow();
        //    for (int j = 0; j < grdExcel.Columns.Count; j++)
        //    {
        //        if (j == 9 || j == 11 || j == 15)
        //        {
        //            if (j == 15)
        //            {
        //                tchkEnAuditoria = (CheckBox)grdExcel.Rows[i].Cells[15].FindControl("chkEnAuditoria");
        //                if (tchkEnAuditoria.Checked)
        //                    dr[j - 2] = "SI";
        //                else
        //                    dr[j - 2] = "NO";
        //            }
        //            else
        //            {
        //                if (grdExcel.Rows[i].Cells[j + 1].Text != string.Empty)
        //                    dr[j] = "SI";
        //                else
        //                    dr[j] = "NO";
        //            }
        //        }
        //        else
        //        {
        //            if (j != 13 && j != 14)
        //                dr[j] = grdExcel.Rows[i].Cells[j].Text;
        //        }
        //    }
        //    dt.Rows.Add(dr);
        //}




        dt.Columns.Remove("IPago");
        dt.Columns.Remove("FechaFin");
        //dt.Columns.Remove("CierreRendCta");
        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dt;
        d1.DataBind();
        d1.RenderControl(hw);
        //Write the HTML back to the browser.
        Response.Write(tw.ToString());
        // End the response.
        Response.End();
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        //CargaGrilla();
        // funcion_carga_pag();
        DataSet dv = DVfiltro;

        grd001.DataSource = dv;
        grd001.DataBind();
    }

    protected void grd001_RowEditing(object sender, GridViewEditEventArgs e)
    {


        Int32 intCorrelativo = Convert.ToInt32(grd001.Rows[e.NewEditIndex].Cells[4].Text);
        if (intCorrelativo > 0)
        {
            string strAnoMes = ddownAno.Text + ddown004.SelectedValue;
            string CodProyecto = grd001.Rows[e.NewEditIndex].Cells[2].Text;

            string url = "CodProyecto=" + CodProyecto + "&AnoMes=" + strAnoMes + "&IdUsr=" + Session["IdUsuario"].ToString() + "&TipoDocumento=0";
            url = "Reporte.aspx?" + url;
            
            iframe_Ver.Src = url;
            mp_Ver.Show();
           
        }
        e.Cancel = true;
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { $('#grd001').DataTable({ searching: true, sort: false, paging: true }); });", true);
    }

    protected void btn_Imprimir_Click(object sender, EventArgs e)
    {
        string strAnoMes = String.Empty;
        string CodProyecto = String.Empty;

        CheckBox tchkImprimir = new CheckBox();
        Int32 intCorrelativo = 0;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            tchkImprimir = (CheckBox)grd001.Rows[i].Cells[14].FindControl("chkImprimir");
            intCorrelativo = intCorrelativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);

            if (tchkImprimir.Checked && intCorrelativo > 0)
            {
                strAnoMes = ddownAno.Text + ddown004.SelectedValue;
                CodProyecto = grd001.Rows[i].Cells[2].Text;
                Imprime(CodProyecto, strAnoMes);
            }
        }
    }
    protected void Imprime(String CodProyecto, String AnoMes)
    {
        DTingresoResumen = new DataTable();
        DTegresoResumen = new DataTable();
        DTingresoResumen.Columns.Add("DescTipoIngreso", typeof(string));
        DTingresoResumen.Columns.Add("Monto", typeof(int));

        DTegresoResumen.Columns.Add("Descripcion", typeof(string));
        DTegresoResumen.Columns.Add("Monto", typeof(int));

        RendicionCuentasColl rC = new RendicionCuentasColl();

        DataTable dtResumenRendicionMensualFirma = new DataTable();
        dtResumenRendicionMensualFirma = rC.GetResumenRendicionMensualFirma(CodProyecto, Convert.ToInt32(AnoMes));
        LlenaTablaIE(dtResumenRendicionMensualFirma, 1);
        
        //imp_reportes(dtResumenRendicionMensualFirma);
        string rptPath = ConfigurationManager.AppSettings["PathReportes"].ToString();
        DataTable dtIngresosResumen = new DataTable();
        dtIngresosResumen = DTingresoResumen;
        DataTable dtEgresosResumen = new DataTable();
        dtEgresosResumen = DTegresoResumen;

        DataSet dS = new DataSet();
        dS.Tables.Add(dtEgresosResumen);
        dS.Tables.Add(dtIngresosResumen);

        dS.Tables[0].TableName = "DatosEgreso";
        dS.Tables[1].TableName = "DatosIngreso";
        dS.DataSetName = "dsRendicionCuentas";

        ReportDocument crReportDocument = new ReportDocument();

        crReportDocument.Load(@rptPath + "crRendicionCuentasV03.rpt");

        string strSiNo = "";
        crReportDocument.SetDataSource(dtResumenRendicionMensualFirma);
        crReportDocument.Subreports["srptRendicionIngresos"].SetDataSource(dS);
        if (dS.Tables[1].Rows.Count == 0) strSiNo = "S"; else strSiNo = "N";
        crReportDocument.Subreports["srptRendicionIngresos"].DataDefinition.FormulaFields["bMostrarRendicionIngreso"].Text = "'" + strSiNo + "'";
        crReportDocument.Subreports["srptRendicionEgresos"].SetDataSource(dS);
        if (dS.Tables[0].Rows.Count == 0) strSiNo = "S"; else strSiNo = "N";
        crReportDocument.Subreports["srptRendicionEgresos"].DataDefinition.FormulaFields["bMostrarRendicionEgresos"].Text = "'" + strSiNo + "'";
        crReportDocument.Refresh();

        crReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
        crReportDocument.PrintToPrinter(1, false, 0, 0);
        crReportDocument.Dispose();
        crReportDocument.Close();

        #region RAM
        //DataTable dt = getImpresionResumen(Convert.ToInt32(CodProyecto), Convert.ToInt32(AnoMes));

        //ExportOptions crExportOptions = new ExportOptions();
        //DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        //ReportDocument reportDocument = new ReportDocument();

        //ninocoll ncoll = new ninocoll();
        //int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(CodProyecto));
        //string rptName = "";

        //if (CodModeloIntervencion == 83) rptName = "crResumenAtencionMensual_PAD.rpt"; else rptName = "crResumenAtencionMensual.rpt";

        //string rptPath = ConfigurationManager.AppSettings["PathReportes"].ToString();
        //reportDocument.Load(@rptPath + rptName);
        //reportDocument.SetDataSource(dt);
        //reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
        //reportDocument.PrintToPrinter(1, false, 0, 0);
        //reportDocument.Dispose();
        //reportDocument.Close();
        #endregion
    }
    protected void LlenaTablaIE(DataTable dtResumenRendicionMensualFirma, int AsignaTablas)
    {
        DataTable dtIngresos = new DataTable();
        DataTable dtEgresos = new DataTable();

        dtIngresos.Columns.Add("DescTipoIngreso", typeof(string));
        dtIngresos.Columns.Add("Monto", typeof(int));

        dtEgresos.Columns.Add("Descripcion", typeof(string));
        dtEgresos.Columns.Add("Monto", typeof(int));

        DataRow dr;
        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Subvencion"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "TRANSFERENCIA SUBVENCION";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Subvencion"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Remesa"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "TRANSFERENCIA REMESA";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Transferencia_Remesa"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Aguinaldos"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "OTROS APORTE SENAME AGUINALDOS";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Aguinaldos"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Otros"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "OTROS APORTE SENAME OTROS";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["OtrosAportesSename_Otros"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_AportesInstituciones"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "INGRESOS DISTINTOS A SENAME APORTES INSTITUCIONES";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_AportesInstituciones"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Donaciones"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "INGRESOS DISTINTOS A SENAME DONACIONES";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Donaciones"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Otros"]) != 0)
        {
            dr = dtIngresos.NewRow();
            dr[0] = "INGRESOS DISTINTOS A SENAME OTROS";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["IngresosDistintosSename_Otros"]);
            dtIngresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosPersonal"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "GASTOS PERSONAL";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosPersonal"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosOperacion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "GASTOS OPERACIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosOperacion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosInversion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "GASTOS INVERSIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["GastosInversion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Devolucion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "DEVOLUCIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["Devolucion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["PagoProvisionPorIndemnizacion"]) != 0)
        {
            dr = dtEgresos.NewRow();
            dr[0] = "PAGO PROVISIÓN POR INDEMNIZACIÓN";
            dr[1] = Convert.ToInt32(dtResumenRendicionMensualFirma.Rows[0]["PagoProvisionPorIndemnizacion"]);
            dtEgresos.Rows.Add(dr);
        }

        if (AsignaTablas == 1)
        {
            DTingresoResumen = dtIngresos;
            DTegresoResumen = dtEgresos;
        }
    }
    protected void btn_MarcaTodo_Click(object sender, EventArgs e)
    {
        CheckBox tchkImprimir = new CheckBox();
        Int32 intCorrelativo = 0;
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            intCorrelativo = Convert.ToInt32(grd001.Rows[i].Cells[4].Text);
            tchkImprimir = (CheckBox)grd001.Rows[i].Cells[14].FindControl("chkImprimir");
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
            tchkImprimir = (CheckBox)grd001.Rows[i].Cells[14].FindControl("chkImprimir");
            tchkImprimir.Checked = false;
        }
    }
    protected void txtBuscar_TextChanged(object sender, EventArgs e)
    {
      
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
