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


using System.IO;
using System.Text;

using System.Collections.Generic;
using System.Data.Common;

public partial class mod_jueces_Historial_Ninos_Jueces : System.Web.UI.Page
{
    public DataTable DTBusqueda
    {
        get { return (DataTable)Session["DTBusqueda"]; }
        set { Session["DTBusqueda"] = value; }
    }
    public Int16 iLRPA_Familia
    {
        get { return (Int16)Session["iLRPA_Familia"]; }
        set { Session["iLRPA_Familia"] = value; }
    }
    public DataTable dtHistorico
    {
        get { return (DataTable)Session["dtHistorico"]; }
        set { Session["dtHistorico"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblDescripcionNino.Width = grdNinos_Historial.Width;
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                //if (!window.existetoken("258DE3AD-DA5D-4CAA-B2C5-6417241CD761"))
                if (Request.QueryString["Param01"] != null)
                {
                    if (!window.existetoken("2D32A6EE-6BD0-4052-B148-73E315EBCE1F"))
                    {
                        Response.Redirect("~/e403.aspx");
                    }
                }
                else if (Request.QueryString["Param01"] == null)
                {
                    if (!window.existetoken("258DE3AD-DA5D-4CAA-B2C5-6417241CD761"))
                    {
                        Response.Redirect("~/e403.aspx");
                    }

                }


                if (Request.QueryString["Param01"] != null)
                    iLRPA_Familia = Convert.ToInt16(Request.QueryString["Param01"]);
                else
                    iLRPA_Familia = 0;

                if (iLRPA_Familia == 0)
                {
                    lblTitulo.Text = lblTitulo.Text + " / LRPA";
                    //hlInstructivo.NavigateUrl = "~/links/INSTRUCTIVO_JUECES_LRPA.pdf";
                    hlInstructivo.Attributes.Add("href", "../links/INSTRUCTIVO_JUECES_LRPA.pdf");

                }
                else
                {
                    //hlInstructivo.NavigateUrl = "~/links/INSTRUCTIVO_modulo_historial_proteccion_v2.pdf";
                    hlInstructivo.Attributes.Add("href", "../links/INSTRUCTIVO_modulo_historial_proteccion_v2.pdf");
                    lblTitulo.Text = lblTitulo.Text + " / Protección";
                }
                if (!window.existetoken("196A62E3-1539-47C1-9431-12F3BDEC4310"))
                    grdHistorialProteccion.Columns[24].Visible = false;

                grdHistorialProteccion.Columns[0].Visible = true;
                grdNinos_Historial.Columns[0].Visible = true;
            }
        }
    }
    //protected void btn_Buscar_Click(object sender, EventArgs e)
    //{
    //    LimpiaPantalla(0);
    //    fncBusca_Nino();

    //}

    private void buscaNNA()
    {
        ninocoll n = new ninocoll();
        DataTable dtResultado = new DataTable();

        int codnino = 0;

        int.TryParse(txtCodNino.Text.Trim(), out codnino);


        dtResultado = n.getNinoRelacionadoJuez(codnino,
            Convert.ToBoolean(iLRPA_Familia),
            txtApellido_Paterno.Text.Trim(),
            txtApellido_Materno.Text.Trim(),
            txtNombres.Text.Trim(),
            txtRUN.Text,
            txt_ruc.Text, 
            txt_rit.Text);

        lblCantidadResultado.Text = dtResultado.Rows.Count.ToString();
        lblCantidadResultado.Visible = true;
        lblCoincidencias.Visible = true;
        pnlAlert.Visible = true;

        if (dtResultado.Rows.Count > 0 && dtResultado.Rows.Count < 200)
        {
            //lnkResultados.Visible = true;
            DTBusqueda = dtResultado;
            bloqueaCampos();
            carga_grilla();

        }
        else if (dtResultado.Rows.Count > 200)
        {
            lblCantidadResultado.Text = "Por favor precise más la búsqueda.";
        }

    }


    private void fncBusca_Nino()
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string strSQL = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                               "T2.FechaNacimiento, T2.CodNacionalidad , isnull(T4.RUC, '') as RUC, isnull(T4.RIT, '') as RIT From Ninos T2 " +
                               " inner join Ingresos_Egresos T1 ON T1.CodNino = T2.CodNino inner join Proyectos T3 ON T1.CodProyecto = T3.CodProyecto " +
                               " left join OrdenTribunalIngreso T4 ON T1.ICodIE = t4.ICodIE ";
        if (iLRPA_Familia == 0)
            strSQL = strSQL + "Where (T3.CodCausalTerminoProyecto = 20084 or t1.CodCalidadJuridica = 13) And t3.CodModeloIntervencion <> 105 And";
        else
            strSQL = strSQL + "Where (T3.CodDepartamentosSENAME in (6, 8, 9) or t3.CodModeloIntervencion = 10) And";        // DEPRODE, PRIMERA INFANCIA, ADOPCION Y COMISARIAS


        //strSQL = strSQL + "Where (T3.CodCausalTerminoProyecto = 20084 or t1.CodCalidadJuridica = 13) And t3.CodModeloIntervencion <> 105 And";
        //if (txtRUN.Text.Trim() != "" || txtCodNino.Text.Trim() != "" || txtApellido_Paterno.Text.Trim() != "" || txtApellido_Materno.Text.Trim() != "" || txtNombres.Text.Trim() != "")
        //    strSQL = strSQL + "Where ";

        if (txtCodNino.Text.Trim() != "")
        {
            strSQL = strSQL + " T2.CodNino =@pCodNino And";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txtCodNino.Text.Trim())));
        }

        if (txtApellido_Paterno.Text.Trim() != "")
        {
            strSQL = strSQL + " T2.Apellido_Paterno like @pApellido_Paterno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txtApellido_Paterno.Text.Trim() + "%"));
        }

        if (txtApellido_Materno.Text.Trim() != "")
        {
            strSQL = strSQL + " T2.Apellido_Materno like @pApellido_Materno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txtApellido_Materno.Text.Trim() + "%"));
        }

        if (txtNombres.Text.Trim() != "")
        {
            strSQL = strSQL + " T2.Nombres like @pNombres And";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txtNombres.Text.Trim() + "%"));
        }

        if (txtRUN.Text.Trim() != "")
        {

            strSQL = strSQL + " T2.Rut =@pRut And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txtRUN.Text.Trim()));
        }
        if (txt_ruc.Text.Trim() != "")
        {
            lblCantidadResultado.Visible = false;
            strSQL = strSQL + " T4.RUC =@pRUC And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRUC", SqlDbType.VarChar, 100, txt_ruc.Text.Trim()));
        }
        if (txt_rit.Text.Trim() != "")
        {
            lblCantidadResultado.Visible = false;
            strSQL = strSQL + " T4.RIT =@pRIT And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRIT", SqlDbType.VarChar, 100, txt_rit.Text.Trim()));
        }
        if (strSQL.Substring(strSQL.Length - 3, 3) == "And")
            strSQL = strSQL.Substring(0, strSQL.Length - 3);

        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado_juez(strSQL, listDbParameter);

        lblCantidadResultado.Text = dt.Rows.Count.ToString();
        lblCantidadResultado.Visible = true;
        lblCoincidencias.Visible = true;
        pnlAlert.Visible = true;

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            //lnkResultados.Visible = true;
            DTBusqueda = dt;
            bloqueaCampos();
            carga_grilla();

        }
        else if (dt.Rows.Count > 200)
        {
            lblCantidadResultado.Text = "Por favor precise más la búsqueda.";
        }

        //ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Hello World');", true);
    }

    private void bloqueaCampos()
    {
        txtRUN.Enabled = false;
        txtCodNino.Enabled = false;
        txtApellido_Paterno.Enabled = false;
        txtApellido_Materno.Enabled = false;
        txtNombres.Enabled = false;
        txt_ruc.Enabled = false;
        txt_rit.Enabled = false;
        btn_Buscar.Visible = false;

    }

    private void activaCampos()
    {
        txtRUN.Enabled = true;
        txtCodNino.Enabled = true;
        txtApellido_Paterno.Enabled = true;
        txtApellido_Materno.Enabled = true;
        txtNombres.Enabled = true;
        txt_ruc.Enabled = true;
        txt_rit.Enabled = true;
        btn_Buscar.Visible = true;

    }

    private void carga_grilla()
    {
        DataView dv = new DataView(DTBusqueda);
        dv.Sort = "Apellido_paterno, Apellido_Materno, Nombres";
        grdNinosLista.DataSource = dv;
        grdNinosLista.DataBind();
        grdNinosLista.Visible = true;
    }

    protected void lnkResultados_Click(object sender, EventArgs e)
    {
        carga_grilla();
        lnkResultados.Visible = false;
        lblCoincidencias.Visible = false;
        lblCantidadResultado.Visible = false;
    }

    //protected void btn_Limpiar_Click(object sender, EventArgs e)
    //{
    //    LimpiaPantalla(1);
    //}

    public class WorkbookEngine
    {
        //public WorkbookEngine()
        //{
        // //
        // // TODO: Add constructor logic here
        // //
    }
    protected void grdHistorialProteccion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Diagnosticos")
        {
            int ICodIE = Convert.ToInt32(grdHistorialProteccion.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            diagnosticoscoll dc = new diagnosticoscoll();

            DataTable dtEscolar = dc.GetDiagnosticos(ICodIE, 1);
            DataTable dtMaltrato = dc.GetDiagnosticos(ICodIE, 2);
            DataTable dtDroga = dc.GetDiagnosticos(ICodIE, 3);
            DataTable dtpSicologico = dc.GetDiagnosticos(ICodIE, 4);
            DataTable dtSocial = dc.GetDiagnosticos(ICodIE, 5);
            DataTable dtCapacitacion = dc.GetDiagnosticos(ICodIE, 6);
            //DataTable dtSituacionLaboral = dc.GetDiagnosticos(ICodIE, 7);
            DataTable dtPFTI = dc.GetDiagnosticos(ICodIE, 8);
            //DataTable dtHechosJudiciales = dc.GetDiagnosticos(ICodIE, 9);
            DataTable dtDiscapacidad = dc.GetDiagnosticos(ICodIE, 10);
            DataTable dtHechosSalud = dc.GetDiagnosticos(ICodIE, 11);
            DataTable dtEnfermedadesCronicas = dc.GetDiagnosticos(ICodIE, 12);


            DataSet ds = new DataSet();
            ds.Tables.Add(dtEscolar);
            ds.Tables[ds.Tables.Count - 1].TableName = "Escolar";
            ds.Tables.Add(dtMaltrato);
            ds.Tables[ds.Tables.Count - 1].TableName = "Maltrato";
            ds.Tables.Add(dtDroga);
            ds.Tables[ds.Tables.Count - 1].TableName = "Droga";
            ds.Tables.Add(dtpSicologico);
            ds.Tables[ds.Tables.Count - 1].TableName = "PSicologico";
            ds.Tables.Add(dtSocial);
            ds.Tables[ds.Tables.Count - 1].TableName = "Social";
            ds.Tables.Add(dtCapacitacion);
            ds.Tables[ds.Tables.Count - 1].TableName = "Capacitacion";
            //ds.Tables.Add(dtSituacionLaboral);
            //ds.Tables[ds.Tables.Count - 1].TableName = "SituacionLaboral";
            ds.Tables.Add(dtPFTI);
            ds.Tables[ds.Tables.Count - 1].TableName = "PFTI";
            //ds.Tables.Add(dtHechosJudiciales);
            //ds.Tables[ds.Tables.Count - 1].TableName = "HechosJudiciales";
            ds.Tables.Add(dtDiscapacidad);
            ds.Tables[ds.Tables.Count - 1].TableName = "Discapacidad";
            ds.Tables.Add(dtHechosSalud);
            ds.Tables[ds.Tables.Count - 1].TableName = "HechosSalud";
            ds.Tables.Add(dtEnfermedadesCronicas);
            ds.Tables[ds.Tables.Count - 1].TableName = "EnfermedadesCronicas";

            Boolean TieneDiagnostico = false;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].Rows[0][14].ToString() != "")      // tiene Diagnóstico
                {
                    TieneDiagnostico = true;
                    break;
                }
            }

            if (!TieneDiagnostico)
            {
                window.alert(Page, "El niño(a) no registra diagnósticos");
                return;
            }
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Diagnosticos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;

            try
            {
                DataGrid dg = new DataGrid();

                //set the datagrid datasource to the dataset passed in
                DataSet littleDsI = new DataSet();
                DataTable dataTableI = new DataTable(ds.Tables[0].TableName);
                DataColumn columnI = new DataColumn();
                columnI.DataType = System.Type.GetType("System.String");
                columnI.ColumnName = "Niño";
                dataTableI.Columns.Add(columnI);
                littleDsI.Tables.Add(dataTableI);
                String[] arrI = { "" };
                littleDsI.Tables[0].Rows.Add(arrI);
                StringWriter stringWriteI = new StringWriter();
                HtmlTextWriter htmlWriteI = new System.Web.UI.HtmlTextWriter(stringWriteI);
                dg.DataSource = littleDsI.Tables[0];
                dg.DataBind();
                dg.RenderControl(htmlWriteI);
                Response.Write(stringWriteI.ToString());
                //////////////////////////////////////////////
                dataTableI = ds.Tables[0].Copy();
                for (int i = dataTableI.Columns.Count - 1; dataTableI.Columns.Count > 14; i--)
                {
                    dataTableI.Columns.Remove(dataTableI.Columns[i].ColumnName);
                }

                if (dataTableI.Rows.Count > 1)
                    for (int i = dataTableI.Rows.Count; dataTableI.Rows.Count > 1; i--)
                        dataTableI.Rows.RemoveAt(i - 1);

                stringWriteI = new System.IO.StringWriter();
                htmlWriteI = new System.Web.UI.HtmlTextWriter(stringWriteI);
                dg.DataSource = dataTableI;
                dg.BackColor = System.Drawing.ColorTranslator.FromHtml("#507CD1");
                dg.ForeColor = System.Drawing.Color.White;
                dg.DataBind();
                dg.RenderControl(htmlWriteI);
                Response.Write(stringWriteI.ToString());
                //////////////////////////////////////////////

                dg.BackColor = System.Drawing.Color.White;
                dg.ForeColor = System.Drawing.Color.Black;
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    DataSet littleDs = new DataSet();
                    DataTable dataTable = new DataTable(ds.Tables[i].TableName);
                    if (ds.Tables[i].Rows[0][14].ToString() != "")      // Si no tiene Diagnóstico no se incluye en el archivo
                    {
                        DataColumn column = new DataColumn();
                        column.DataType = System.Type.GetType("System.String");
                        column.ColumnName = "Diagnostico";
                        dataTable.Columns.Add(column);
                        littleDs.Tables.Add(dataTable);
                        String[] arr = { ds.Tables[i].TableName + " - " + ds.Tables[i].Rows.Count.ToString() + " diagnosticos" };
                        littleDs.Tables[0].Rows.Add(arr);
                        StringWriter stringWrite = new StringWriter();
                        HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                        dg.DataSource = littleDs.Tables[0];
                        dg.Font.Bold = true;
                        dg.DataBind();
                        dg.RenderControl(htmlWrite);
                        Response.Write(stringWrite.ToString());

                        stringWrite = new System.IO.StringWriter();
                        htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                        for (int ii = 13; ii >= 0; ii--)
                        {
                            ds.Tables[i].Columns.Remove(ds.Tables[i].Columns[ii].ColumnName);
                        }
                        dg.DataSource = ds.Tables[i];
                        dg.Font.Bold = false;
                        dg.DataBind();
                        dg.RenderControl(htmlWrite);
                        Response.Write(stringWrite.ToString());
                    }
                }
                Response.End();
                Response.Write(""); //prevents "thread aborted" message
            }

            catch (Exception ex)
            {
                string x = ex.ToString();
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //Throw ex
            }


            if (e.CommandName == "PII")
            {
                window.alert(Page, "PII");
            }
        }
    }
    protected void grdNinosLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Historico")
        {
            pnl_Historico.Visible = true;
            grdNinosLista.Visible = false;

            int CodNino = Convert.ToInt32(grdNinosLista.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            ninocoll nic = new ninocoll();
            if (iLRPA_Familia == 0)
                dtHistorico = nic.callto_getNinoLRPA_Jueces(CodNino);
            else
                dtHistorico = nic.callto_getNinoProteccion_Jueces(CodNino);

            //BoundField lobColumnBound;
            ////Crear Columna:
            //lobColumnBound = new BoundField();
            //lobColumnBound.DataField = "ConQuienEgresa";  // del Origen de datos
            //lobColumnBound.HeaderText = "Con Quien Egresa";
            //grdNinos_Historial.Columns.Add(lobColumnBound);

            if (dtHistorico.Rows.Count != 0)
            {
                DataView dv = new DataView(dtHistorico);
                lblDescripcionNino.Text = "RUN: " + dv[0].Row[1].ToString() + " /  " + dv[0].Row[4].ToString() + " " + dv[0].Row[2].ToString() + " " + dv[0].Row[3].ToString() + "  /  FECHA NACIMIENTO: " + dv[0].Row[5].ToString().Substring(0, 10) + "  /  EDAD: " + dv[0].Row[7].ToString();

                if (iLRPA_Familia == 0)
                {
                    grdNinos_Historial.DataSource = dv;
                    grdNinos_Historial.DataBind();
                }
                else
                {
                    grdHistorialProteccion.DataSource = dv;
                    grdHistorialProteccion.DataBind();
                }

                lblCantidadResultado.Text = dtHistorico.Rows.Count.ToString();
                btnExcel.Visible = true;
                grdHistorialProteccion.Visible = true;
                grdNinos_Historial.Visible = true;
            }
            else
            {
                pnl_Historico.Visible = false;
                grdNinosLista.Visible = true;
            }
        }

    }
    protected void grdNinosHistorial_PageIndexChanged(object sender, GridViewPageEventArgs e)
    {
        if (iLRPA_Familia == 0)
            grdNinos_Historial.PageIndex = e.NewPageIndex;
        else
            grdHistorialProteccion.PageIndex = e.NewPageIndex;
        carga_grilla();
    }


    //protected void btn_Volver_Click(object sender, EventArgs e)
    //{
    //    if (grdNinosLista.Visible)
    //        Response.Redirect("../index.aspx");
    //    else
    //    {
    //        LimpiaPantalla(0);
    //        grdNinosLista.Visible = true;
    //    }
    //}
    protected void LimpiaPantalla(int LimpiaFiltros)
    {
        if (LimpiaFiltros == 1)
        {
            txtApellido_Materno.Text = "";
            txtApellido_Paterno.Text = "";
            txtNombres.Text = "";
            txtRUN.Text = "";
            txtCodNino.Text = "";
            txt_ruc.Text = "";
            txt_rit.Text = "";
        }
        grdNinos_Historial.Visible = false;
        grdNinosLista.Visible = false;
        lblCantidadResultado.Visible = false;
        lblCoincidencias.Visible = false;
        pnl_Historico.Visible = false;
        btnExcel.Visible = false;
        lblError.Visible = false;
        pnlAlert.Visible = false;
        grdHistorialProteccion.Visible = false;

    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        string NombreArchivo = "Reporte_Ninos";
        if (iLRPA_Familia == 0)
            NombreArchivo = NombreArchivo + "LRPA";
        else
            NombreArchivo = NombreArchivo + "Proteccion";

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo + ".xls");

        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataView dv = new DataView(dtHistorico);
        GridView grdTMP = new GridView();
        grdTMP.DataSource = dv;
        grdTMP.DataBind();
        grdTMP.RenderControl(hw);

        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void txt_ruc_ValueChange(object sender, EventArgs e)
    {
        if ((String)txt_ruc.Text == "") return;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        String sConsulta = "select dbo.f_tmpValidaRuc('" + txt_ruc.Text + "')";
        parcoll pc = new parcoll();
        DataTable dt = pc.ejecuta_SQL(sConsulta);
        if (!(dt.Rows.Count > 0 && (bool)dt.Rows[0][0]))
        {
            lblErrorRUC.Visible = true;
            txt_ruc.BackColor = colorCampoObligatorio;
            txt_ruc.Text = "";
        }
        else
        {
            lblErrorRUC.Visible = false;
            txt_ruc.BackColor = System.Drawing.Color.White;
        }
    }
    protected void link_ruc_Click(object sender, EventArgs e)
    {
        LinkButton ructext = sender as LinkButton;
        string ruc = ructext.Text;

        pnl_Historico.Visible = true;
        grdNinosLista.Visible = false;

        //int CodNino = Convert.ToInt32(grdNinosLista.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        ninocoll nic = new ninocoll();
        if (iLRPA_Familia == 0)
            dtHistorico = nic.callto_getRUC_LRPA_Jueces(ruc);
        else
            dtHistorico = nic.callto_getNinoProteccion_RUC_Jueces(ruc);

        //BoundField lobColumnBound;
        ////Crear Columna:
        //lobColumnBound = new BoundField();
        //lobColumnBound.DataField = "ConQuienEgresa";  // del Origen de datos
        //lobColumnBound.HeaderText = "Con Quien Egresa";
        //grdNinos_Historial.Columns.Add(lobColumnBound);

        if (dtHistorico.Rows.Count != 0)
        {
            DataView dv = new DataView(dtHistorico);
            //lblDescripcionNino.Text = "RUN: " + dv[0].Row[1].ToString() + " /  " + dv[0].Row[4].ToString() + " " + dv[0].Row[2].ToString() + " " + dv[0].Row[3].ToString() + "  /  FECHA NACIMIENTO: " + dv[0].Row[5].ToString().Substring(0, 10) + "  /  EDAD: " + dv[0].Row[7].ToString();
            lblDescripcionNino.Text = "";
            if (iLRPA_Familia == 0)
            {
                grdNinos_Historial.DataSource = dv;
                grdNinos_Historial.DataBind();
            }
            else
            {
                grdHistorialProteccion.DataSource = dv;
                grdHistorialProteccion.DataBind();
            }

            lblCantidadResultado.Text = dtHistorico.Rows.Count.ToString();
            btnExcel.Visible = true;
            grdNinos_Historial.Visible = true;
            pnl_Historico.Visible = true;
        }
        else
        {
            pnl_Historico.Visible = false;
            grdNinosLista.Visible = true;
        }
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    //protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_jueces/Historial_Ninos_Jueces.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //}
    //protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_jueces/Historial_Ninos_Jueces.aspx", "Buscador", false, true, 770, 420, false, false, true);
    //}
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
    protected void grdNinos_Historial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ruc")
        {
            string icodie = grdNinos_Historial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            string ruc = grdNinos_Historial.Rows[Convert.ToInt32(e.CommandArgument)].Cells[32].Text;


            window.open(this.Page, "../mod_jueces/ImageNow_CapturaInf.aspx?icodie=" + icodie + "&RUC=" + ruc, "Captura", false, false, 700, 700, false, false, true);
            pnl_Historico.Visible = true;
            //window.open(this.Page, "../mod_coordinadores/coord_historiconino_audiencia .aspx?CODNINO=" + icodie + "&RUC=" + ruc, "Historicos", true, 600, 400, false, false, true);
        }
    }

    protected void btnBuscaInstitucion_Click(object sender, EventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_jueces/Historial_Ninos_Jueces.aspx", "Buscador", false, true, 500, 650, false, false, true);

    }
    protected void btnBuscaProyecto_Click(object sender, EventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_jueces/Historial_Ninos_Jueces.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        LimpiaPantalla(0);
        //fncBusca_Nino();
        buscaNNA();
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        LimpiaPantalla(1);
        activaCampos();
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        string NombreArchivo = "Reporte_Ninos";
        if (iLRPA_Familia == 0)
            NombreArchivo = NombreArchivo + "LRPA";
        else
            NombreArchivo = NombreArchivo + "Proteccion";

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo + ".xls");

        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataView dv = new DataView(dtHistorico);
        GridView grdTMP = new GridView();
        grdTMP.DataSource = dv;
        grdTMP.DataBind();
        grdTMP.RenderControl(hw);

        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void grdNinosLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grd001.PageIndex = e.NewPageIndex;
        ////CargaGrilla();
        //// funcion_carga_pag();
        //DataSet dv = DVfiltro;

        //grd001.DataSource = dv;
        //grd001.DataBind();


        grdNinosLista.PageIndex = e.NewPageIndex;
        DataTable dvNinos = DTBusqueda;

        grdNinosLista.DataSource = DTBusqueda;
        grdNinosLista.DataBind();
    }
}

