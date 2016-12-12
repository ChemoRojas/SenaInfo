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

public partial class mod_instituciones_Reg_Egresos_Instituciones : System.Web.UI.Page
{
    public DataTable dtEgresos
    {
        get { return (DataTable)Session["dtEgresos"]; }
        set { Session["dtEgresos"] = value; }
    }
    public DataTable dtEgresosRPT
    {
        get { return (DataTable)Session["dtEgresosRPT"]; }
        set { Session["dtEgresosRPT"] = value; }
    }
    public void GetEgresosGr()
    {
        dtEgresos = new DataTable();

        dtEgresos.Columns.Add(new DataColumn("IdRendicionEgreso", typeof(int))); //0
        dtEgresos.Columns.Add(new DataColumn("AnoMes", typeof(int))); //1
        dtEgresos.Columns.Add(new DataColumn("FechaRegistro", typeof(DateTime)));//2
        dtEgresos.Columns.Add(new DataColumn("Nombre", typeof(string)));//3
        dtEgresos.Columns.Add(new DataColumn("NroComprobante", typeof(int)));//4
        dtEgresos.Columns.Add(new DataColumn("FechaComprobante", typeof(DateTime)));//5
        dtEgresos.Columns.Add(new DataColumn("Monto", typeof(int)));//6
        dtEgresos.Columns.Add(new DataColumn("Correlativo", typeof(int)));//7
        dtEgresos.Columns.Add(new DataColumn("Glosa", typeof(string)));//8
        dtEgresos.Columns.Add(new DataColumn("Nulo", typeof(Boolean)));//9
        dtEgresos.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));//10
        dtEgresos.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));//11
        dtEgresos.Columns.Add(new DataColumn("CodUso", typeof(int)));//12
        dtEgresos.Columns.Add(new DataColumn("Uso", typeof(string)));//13
        dtEgresos.Columns.Add(new DataColumn("CodObjetivo", typeof(int)));//14
        dtEgresos.Columns.Add(new DataColumn("Objetivo", typeof(string)));//15
        dtEgresos.Columns.Add(new DataColumn("Destino", typeof(string)));//16
        dtEgresos.Columns.Add(new DataColumn("NumeroCheque", typeof(string)));//17
        dtEgresos.Columns.Add(new DataColumn("CodMedioDePago", typeof(int)));//18
        dtEgresos.Columns.Add(new DataColumn("MedioDePago", typeof(string)));//19
        dtEgresos.Columns.Add(new DataColumn("Cerrado", typeof(Boolean)));    //20  
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
                if (!window.existetoken("9DDBB7ED-19CB-4962-A2FE-DE4D6C5B8C32"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                txtFechaRegistro.Text = DateTime.Now.ToString();
                txtAno_NEW.Text= DateTime.Now.Year.ToString();
                GetInstituciones();
                GetProyectos();
                GetObjetivos(2);
                GetUsos(2);
                GetMedioDePago(2);
                GetEgresosGr();
                if (Request.QueryString["sw"] == "3")
                {
                    ddlInstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddlInstitucion_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddlInstitucion.SelectedValue = Convert.ToString(codinst);
                    GetProyectos();
                }
                validatescurity();
            }
        }
    }
    private void GetInstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddlInstitucion.DataSource = dv1;
        ddlInstitucion.DataTextField = "Nombre";
        ddlInstitucion.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddlInstitucion.DataBind();
    }
    private void GetProyectos()
    {
        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddlInstitucion.SelectedValue));
    }
    private void GetObjetivos(int iVigente)
    {
        ObjetivosColl tObjetivosColl = new ObjetivosColl();
//        DataView dv1 = new DataView(tObjetivosColl.GetObjetivos(ASP.global_asax.globaconn, iVigente));
        DataView dv1 = new DataView(tObjetivosColl.GetObjetivosInstituciones(iVigente));
        ddlObjetivo.DataSource = dv1;
        ddlObjetivo.DataTextField = "Descripcion";
        ddlObjetivo.DataValueField = "CodObjetivo";
        dv1.Sort = "CodObjetivo";
        ddlObjetivo.DataBind();
    }
    private void GetUsos(int iVigente)
    {
        UsosColl tUsosColl = new UsosColl();

        DataView dv1 = new DataView(tUsosColl.GetData(ddlObjetivo.SelectedValue, iVigente));
        ddlUso.DataSource = dv1;
        ddlUso.DataTextField = "Descripcion";
        ddlUso.DataValueField = "CodUso";
        dv1.Sort = "CodUso";
        ddlUso.DataBind();
    }
    private void GetMedioDePago(int iVigente)
    {
        MedioDePago tMedioDePagoColl = new MedioDePago();
        DataView dv1 = new DataView(tMedioDePagoColl.GetData(iVigente));
        ddlMedioDePago.DataSource = dv1;
        ddlMedioDePago.DataTextField = "Descripcion";
        ddlMedioDePago.DataValueField = "CodMedioDePago";
        dv1.Sort = "CodMedioDePago";
        ddlMedioDePago.DataBind();
    }
    protected void grdEgresoDetalles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        EditaRegistro(sender, e.NewEditIndex);
    }
    protected void EditaRegistro(object sender, int i)
    {
        System.Web.UI.WebControls.CheckBox chkNulo;

        chkNulo = (System.Web.UI.WebControls.CheckBox)grdEgresoDetalles.Rows[i].Cells[10].FindControl("chkNulo");
        if (chkNulo.Checked)
            return;

        HabilitaEgresos();
        txtFechaComprobante.Text= grdEgresoDetalles.Rows[i].Cells[0].Text;
        txtNumeroComprobante.Text = grdEgresoDetalles.Rows[i].Cells[1].Text;
        txtCorrelativo_NEW.Text = grdEgresoDetalles.Rows[i].Cells[2].Text;
        GetObjetivos(2);
        ddlObjetivo.SelectedValue = grdEgresoDetalles.Rows[i].Cells[14].Text;
        GetUsos(2);
        ddlUso.SelectedValue = grdEgresoDetalles.Rows[i].Cells[15].Text;
        txtMonto_NEW.Text = grdEgresoDetalles.Rows[i].Cells[5].Text.Replace(".", "").Replace("-", "");
        GetMedioDePago(2);
        ddlMedioDePago.SelectedValue = grdEgresoDetalles.Rows[i].Cells[16].Text;
        txtGlosa.Text = Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[7].Text.Trim());
        txtDestino.Text = Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[8].Text.Trim());
        txtNumeroDeCheque.Text = Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[9].Text.Trim());
        if (chkNulo.Checked)
        {
            rbAnular.SelectedValue = "1";
        }
        else
        {
            rbAnular.SelectedValue = "0";
        }
        ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo);
        ValidaTipoDetalleEgreso(ddlUso, lblUso);
    }
    protected void ddlInstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProyectos();
    }
    //protected void btnGuardaIngreso_Click(object sender, EventArgs e)
    //{
    //    if (ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo) && ValidaTipoDetalleEgreso(ddlUso, lblUso) && ValidaTipoDetalleEgreso(ddlMedioDePago, lblMedioPago))
    //    {
    //        int iIdRendicionEgreso = 0;
    //        int iAnoMes;
    //        int iNumeroComprobante = 0;
    //        int iCorrelativo = 0;
    //        int iNulo = 0;
    //        int iCodInstitucion = Convert.ToInt32(ddlInstitucion.SelectedValue);
    //        int iMonto = 0;
    //        int iTotal = 0;
    //        int iCodUso = Convert.ToInt32(ddlUso.SelectedValue);
    //        int iCodMedioDePago = Convert.ToInt32(ddlMedioDePago.SelectedValue);
    //        DateTime dFechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);

    //        if (txtIdRendicionEgreso.Text.Trim() != "")
    //        {
    //            iIdRendicionEgreso = Convert.ToInt32(txtIdRendicionEgreso.Text);
    //        }
    //        if (txtNumeroComprobante.Text.Trim() != "")
    //        {
    //            iNumeroComprobante = Convert.ToInt32(txtNumeroComprobante.Text);
    //        }
    //        if (txtCorrelativo_NEW.Text.Trim() != "")
    //        {
    //            iCorrelativo = Convert.ToInt32(txtCorrelativo_NEW.Text);
    //        }
    //        if (ddlObjetivo.SelectedValue.Trim() == "10")
    //        {
    //            iMonto = iMonto * -1;
    //        }
    //        if (rbAnular.SelectedValue != "0")
    //        {
    //            iNulo = 1;
    //        }

    //        iMonto = Convert.ToInt32(txtMonto_NEW.Text);
    //        if (iMonto == 0)
    //        {
    //            lblMonto.Visible = true;
    //            lblMonto.Text = "El monto del Egreso debe ser distinto de cero";
    //            txtMonto_NEW.Focus();
    //            return;
    //        }
    //        else
    //        {
    //            lblMonto.Text = string.Empty;
    //        }

    //        iAnoMes = Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);

    //        if (ddlObjetivo.SelectedValue == "16")
    //        {
    //            iMonto *= -1;
    //        }

    //        RendicionEgresoColl rI = new RendicionEgresoColl();
    //        rI.InsertUpdateInstitucion(iIdRendicionEgreso, iNumeroComprobante, iCorrelativo, iCodUso, Convert.ToDateTime(txtFechaComprobante.Text), iCodMedioDePago, iMonto, txtNumeroDeCheque.Text.ToUpper(), txtGlosa.Text.ToUpper(), txtDestino.Text.ToUpper(), iNulo, Convert.ToInt32(Session["IdUsuario"]), iAnoMes, iCodInstitucion, dFechaRegistro);

    //        GetEgresosGr();
    //        dtEgresos = rI.GetDataInstituciones(ddlInstitucion.SelectedValue.ToString(), iAnoMes, dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));
    //        grdEgresoDetalles.DataSource = dtEgresos;
    //        grdEgresoDetalles.DataBind();
    //        txtIdRendicionEgreso.Text = dtEgresos.Rows[0]["IdRendicionEgreso"].ToString();
    //        iTotal = SumaTotales(iTotal);
    //        txtTotal_NEW.Text=Convert.ToString(iTotal);
    //        tblTotal.Visible = true;
    //        btnCancelaEgreso_Click(sender, e);
    //    }
    //}
    //protected void btnEgreso_Click(object sender, EventArgs e)
    //{
    //    HabilitaEgresos();
    //    GetObjetivos(1);
    //    GetUsos(1);
    //    GetMedioDePago(1);
    //    tblEditar.Rows[1].Visible = false;
    //    tblEditar.Rows[2].Visible = false;
    //}
    private void HabilitaEgresos()
    {
        pnlDetail.Visible = true;
        btnGuardaEgreso_NEW.Visible = true;
        btnCancelaEgreso_NEW.Visible = true;
        btnEgreso_NEW.Visible = false;
        txtFechaComprobante.Text = DateTime.Now.ToString();
        txtNumeroComprobante.Text = "";
        txtCorrelativo_NEW.Text = "";
        txtMonto_NEW.Text = "0";
        txtGlosa.Text = "";
        rbAnular.SelectedValue = "0";
        txtDestino.Text = "";
        txtNumeroDeCheque.Text = "";
    }
    //protected void btnCancelaEgreso_Click(object sender, EventArgs e)
    //{
    //    ////HabilitaDeshabilitaHeaderFrame(false);
    //    ////LimpiaBusqueda();
    //    ////dtEgresos.Rows.Clear();
    //    ////grdBuscador.DataSource = "";
    //    ////grdBuscador.DataBind();
    //    ////grdEgresoDetalles.DataSource = "";
    //    ////grdEgresoDetalles.DataBind();
    //    ////lblInformacion.Visible = false;
    //    ////validatescurity();

    //    pnlDetail.Visible = false;
    //    btnGuardaEgreso_NEW.Visible = false;
    //    btnEgreso_NEW.Visible = true;
    //    btnImprimir_NEW.Visible = true;
    //    btnExcel_NEW.Visible = true;
    //    btnCancelaEgreso_NEW.Visible = false;
    //    lblObjetivo.Visible = false;
    //    lblUso.Visible = false;
    //    lblMedioPago.Visible = false;
    //    lblMonto.Visible = false;
    //    txtFechaComprobante.ReadOnly = false;
    //    tblEditar.Rows[1].Visible = true;
    //    tblEditar.Rows[2].Visible = true;

    //    //pnlDetail.Visible = false;
    //    //btnGuardaEgreso.Visible = false;
    //    //btnEgreso.Visible = true;
    //    //btnImprimir.Visible = true;
    //    //btnExcel.Visible = true;
    //    //btnCancelaEgreso.Visible = false;
    //    //lblObjetivo.Visible = false;
    //    //lblUso.Visible = false;
    //    //lblMedioPago.Visible = false;
    //    //lblMonto.Visible = false;
    //    //ddlFechaComprobante.ReadOnly = false;
    //    //tblEditar.Rows[1].Visible = true;
    //    //tblEditar.Rows[2].Visible = true;
    //    //LimpiaBusqueda();
    //}
    protected void ddlDetalleEgreso_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleEgreso(ddlUso, lblUso);
    }
    protected Boolean ValidaTipoDetalleEgreso(System.Web.UI.WebControls.DropDownList ddl, System.Web.UI.WebControls.Label lbl)
    {
        if (ddl.SelectedItem.Text.Substring(0, 3) == "(V)" && Convert.ToInt32(ddl.SelectedValue) != 0)
        {
            lbl.Visible = false;
            return true;
        }
        else
        {
            lbl.Visible = true;
            if (ddl.SelectedItem.Text.Substring(1, 1) != "V")
            {
                lbl.Text = "No puede seleccionar un dato caducado";
            }
            else
            {
                lbl.Text = "Debe seleccionar un dato";
            }

            ddl.Focus();
            return false;
        }
    }
    //protected void btnLimpiaBusqueda_Click(object sender, EventArgs e)
    //{
    //    LimpiaBusqueda();
    //}
    //protected void btnCancelarBusqueda_Click(object sender, EventArgs e)
    //{
    //    pnlSearch.Visible = false;
    //    pnlHeader.Visible = true;
    //    LimpiaBusqueda();
    //}
    //protected void btnBuscar_Click(object sender, EventArgs e)
    //{
    //    int iAnoMes;

    //    if (txtAnoMes_NEW.Text.Trim() != "")
    //    {
    //        iAnoMes = Convert.ToInt32(txtAnoMes_NEW.Text.Trim());
    //    }
    //    else
    //    {
    //        iAnoMes = 0;
    //    }
    //    string mes = iAnoMes.ToString();
    //    if (mes.Length > 4)
    //    {
    //        mes = mes.Substring(4, 2).ToString();
    //    }
    //    if (mes == "00")
    //    {
    //        iAnoMes = 0;
    //    }
    //    RendicionEgresoColl rE = new RendicionEgresoColl();
    //    dtEgresos.Rows.Clear();
    //    txtIdRendicionEgreso.Text = "";
    //    dtEgresos = rE.GetDataInstituciones(ddlInstitucion.SelectedValue.ToString(), iAnoMes,dtEgresos, 1, Convert.ToInt32(Session["IdUsuario"]));
    //    if (dtEgresos.Rows.Count > 0)
    //    {
    //        grdBuscador.DataSource = dtEgresos;
    //        grdBuscador.DataBind();
    //        lbl_notFound.Visible = false;
    //    }
    //    else
    //    {
    //        lbl_notFound.Visible = true;
    //    }
    //}
    protected void grdBuscador_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int i = e.NewEditIndex;
        int iSuma = 0;
        System.Web.UI.WebControls.CheckBox chkCerrado;

        txtIdRendicionEgreso.Text = grdBuscador.Rows[i].Cells[0].Text;
        //ddlInstitucion.SelectedValue = grdBuscador.Rows[i].Cells[1].Text;

        ddlMeses.SelectedValue = Convert.ToInt16(grdBuscador.Rows[i].Cells[2].Text.Substring(4, 2)).ToString();
        txtAno_NEW.Text = grdBuscador.Rows[i].Cells[2].Text.Substring(0, 4);
        //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
        //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
        txtFechaRegistro.Text= grdBuscador.Rows[i].Cells[3].Text;
        chkCerrado = (System.Web.UI.WebControls.CheckBox)grdBuscador.Rows[i].Cells[4].FindControl("chkCerrado");
        lblInformacion.Text = "La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios.";
        lblInformacion.Visible = (chkCerrado.Checked.ToString().ToLower() == "true");
        int iAnoMes = Convert.ToInt32(grdBuscador.Rows[i].Cells[2].Text);

        RendicionEgresoColl ri = new RendicionEgresoColl();
        dtEgresos.Rows.Clear();
        dtEgresos = ri.GetDataInstituciones(ddlInstitucion.SelectedValue.ToString(), iAnoMes, dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));

        grdEgresoDetalles.DataSource = dtEgresos;
        HabilitaDeshabilitaHeaderFrame(dtEgresos.Rows.Count != 0);
        pnlHeader.Visible = true;
        pnlDetail.Visible = false;
        pnlBody.Visible = true;
        divbotonera.Visible = true;
        pnlSearch.Visible = false;
        btnCancelarNEW.Visible = true;
        grdEgresoDetalles.DataBind();
        iSuma = SumaTotales(iSuma);
        txtTotal_NEW.Text =Convert.ToString(iSuma);

        grdEgresoDetalles.Columns[11].Visible = (!lblInformacion.Visible);
        grdEgresoDetalles.Columns[12].Visible = (!lblInformacion.Visible);
        grdEgresoDetalles.Columns[13].Visible = (!lblInformacion.Visible);
        btnEgreso_NEW.Visible = (!lblInformacion.Visible);
        validatescurity();
    }
    protected int SumaTotales(int iSuma)
    {
        int x = -1;
        foreach (DataRow row in dtEgresos.Rows)
        {
            if (row["Nulo"].ToString().ToLower() == "false")
            {
                iSuma = iSuma + Convert.ToInt32(row["Monto"]);
            }

            x++;
            System.Web.UI.WebControls.CheckBox chkNulo;
            chkNulo = (System.Web.UI.WebControls.CheckBox)grdEgresoDetalles.Rows[x].Cells[10].FindControl("chkNulo");

            if (chkNulo.Checked)
            {
                grdEgresoDetalles.Rows[x].BackColor = System.Drawing.Color.SandyBrown;
            }
        }
        return iSuma;
    }
    //protected void btnCancelar_Click(object sender, EventArgs e)
    //{
    //    HabilitaDeshabilitaHeaderFrame(false);
    //    LimpiaBusqueda();
    //    dtEgresos.Rows.Clear();
    //    grdBuscador.DataSource = "";
    //    grdBuscador.DataBind();
    //    grdEgresoDetalles.DataSource = "";
    //    grdEgresoDetalles.DataBind();
    //    lblInformacion.Visible = false;
    //    validatescurity();
    //}
    //protected void btnNuevo_Click(object sender, EventArgs e)
    //{
    //    if (ddlMeses.SelectedValue == "0")
    //    {
    ////        lblInformacion.Visible = true;
    ////        lblInformacion.Text = "Debe seleccionar el mes del Egreso de Cuentas";
    ////        ddlMeses.Focus();
    ////        return;
    ////    }
    ////    if (txtAno_NEW.Text.Length != 4 || txtAno_NEW.Text.Trim() == "")
    ////    {
    ////        lblInformacion.Visible = true;
    ////        lblInformacion.Text = "Debe Ingresar el año del registro de Egreso";
    ////        txtAno_NEW.Focus();
    ////        return;
    ////    }
    ////    else
    ////    {
    ////        //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
    ////        //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
    ////        //ddlFechaComprobante.Value = ddlFechaComprobante.MinDate;
    ////    }

    ////    if (Convert.ToInt32(ddlInstitucion.SelectedValue) == 0)
    ////    {
    ////        lblInformacion.Visible = true;
    ////        lblInformacion.Text = "Debe seleccionar una Institución";
    ////        ddlInstitucion.Focus();
    ////        return;
    ////    }
    ////    if (txtFechaRegistro.Text.Trim() == "")
    ////    {
    ////        lblInformacion.Visible = true;
    ////        lblInformacion.Text = "Debe Ingresar la fecha de Registro";
    ////        txtFechaRegistro.Focus();
    ////        return;
    ////    }
    ////    if (Convert.ToInt32(txtAno_NEW.Text) > DateTime.Now.Year ||
    ////        (Convert.ToInt32(txtAno_NEW.Text) == DateTime.Now.Year &&
    ////        Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
    ////    {
    ////        lblInformacion.Visible = true;
    ////        lblInformacion.Text = "No puede crear Egresos de meses futuros";
    ////        return;
    ////    }
    ////    BuscaRendicion(sender, e, 1);
    ////    HabilitaDeshabilitaHeaderFrame(dtEgresos.Rows.Count == 0);
    ////    lblInformacion.Visible = (dtEgresos.Rows.Count != 0);
    ////    tblTotal.Visible = (dtEgresos.Rows.Count != 0);
    ////    btnEgreso_Click(sender, e);
    ////    btnEgreso_NEW.Visible = false;
    ////    btnImprimir_NEW.Visible = false;
    ////    btnExcel_NEW.Visible = false;
    ////    btnCancelarNEW.Visible = true;

    ////    lblInformacion.Text = "Ya existe una rendición registrada para el proyecto y periodo indicado";
    ////    pnlSearch.Visible = false;
    ////}
    //protected void btnBuscaRendicion_Click(object sender, EventArgs e)
    //{
    //    BuscaRendicion(sender, e, 0);
    //}
    //protected void BuscaRendicion(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e, int Busca)
    //{
    //    pnlHeader.Visible = (Busca == 1);
    //    pnlBody.Visible = (Busca == 1);
    //    pnlSearch.Visible = (Busca == 0);

    //    if (Convert.ToUInt32(ddlInstitucion.SelectedValue) == 0)
    //    {
    //        txtInstitucion_NEW.Text = "";
    //    }
    //    else
    //    {
    //        txtInstitucion_NEW.Text = ddlInstitucion.SelectedItem.Text;
    //    }

    //    if (txtAno_NEW.Text == "")
    //    {
    //        txtAnoMes_NEW.Text = "";
    //    }
    //    else
    //    {
    //        txtAnoMes_NEW.Text = Convert.ToString(Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue));
    //    }

    //    btnBuscar_Click(sender, e);
    //}
    protected void grdEgresoDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.ToLower() == "correlativo")
        {
            int i = Convert.ToInt32(e.CommandArgument);
            EditaRegistro(sender, i);
            txtNumeroComprobante.Text = grdEgresoDetalles.Rows[i].Cells[1].Text;
            txtCorrelativo_NEW.Text = "";
            txtMonto_NEW.Text = "";
            txtGlosa.Text = "";
            txtDestino.Text = "";
            txtNumeroDeCheque.Text = "";
            rbAnular.SelectedValue = "0";
            txtFechaComprobante.Text = DateTime.Now.ToString();
            txtFechaComprobante.ReadOnly = true;
            tblEditar.Rows[2].Visible = false;
        }
        if (e.CommandName.ToLower() == "eliminar")
        {
            int iCodInstitucion = Convert.ToInt32(ddlInstitucion.SelectedValue);
            int iAnoMes = Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
            int iNumeroComprobante = Convert.ToInt32(grdEgresoDetalles.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            int iCorrelativo = Convert.ToInt32(grdEgresoDetalles.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
            int iSuma = 0;

            RendicionEgresoColl rE = new RendicionEgresoColl();
            rE.DeleteInstitucion(iCodInstitucion, iAnoMes, iNumeroComprobante, iCorrelativo);

            dtEgresos.Rows.Clear();
            dtEgresos = rE.GetDataInstituciones(ddlInstitucion.SelectedValue.ToString(), iAnoMes, dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));

            grdEgresoDetalles.DataSource = dtEgresos;
            HabilitaDeshabilitaHeaderFrame(dtEgresos.Rows.Count != 0);
            pnlHeader.Visible = true;
            pnlDetail.Visible = false;
            pnlBody.Visible = true;
            divbotonera.Visible = true;
            pnlSearch.Visible = false;
            btnCancelarNEW.Visible = true;
            btnImprimir_NEW.Visible = true;
            btnExcel_NEW.Visible = true;
            tblTotal.Visible = true;
            grdEgresoDetalles.DataBind();

            iSuma = SumaTotales(iSuma);
            txtTotal_NEW.Text=Convert.ToString(iSuma);

            grdEgresoDetalles.Columns[8].Visible = (!lblInformacion.Visible);
            grdEgresoDetalles.Columns[9].Visible = (!lblInformacion.Visible);
            btnEgreso_NEW.Visible = (!lblInformacion.Visible);

            validatescurity();
        }

    }
    protected void ddlObjetivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo);
        GetUsos(1);
    }
    protected void ddlUso_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleEgreso(ddlUso, lblUso);
    }
    protected void ddlMedioDePago_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleEgreso(ddlMedioDePago, lblMedioPago);
    }
    //protected void btnVolver_Click(object sender, EventArgs e)
    //{
    //    btnCancelar_Click(sender, e);
    //    Response.Redirect("rendicion_cuentas.aspx");
    //}
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Egresos_Instituciones.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Egresos.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    
    protected DateTime FechaMaxima(string strFecha)
    {
        DateTime dFecha = Convert.ToDateTime(strFecha);
        dFecha = dFecha.AddMonths(1);
        dFecha = dFecha.AddDays(-1);
        return dFecha;
    }

    private void PreparaReporte()
    {
        System.Web.UI.WebControls.CheckBox chkNulo;
        dtEgresosRPT = new DataTable();

        dtEgresosRPT.Columns.Add(new DataColumn("FechaComprobante", typeof(DateTime)));
        dtEgresosRPT.Columns.Add(new DataColumn("NroComprobante", typeof(int)));
        dtEgresosRPT.Columns.Add(new DataColumn("Correlativo", typeof(int)));
        dtEgresosRPT.Columns.Add(new DataColumn("Objetivo", typeof(string)));
        dtEgresosRPT.Columns.Add(new DataColumn("Uso", typeof(string)));
        dtEgresosRPT.Columns.Add(new DataColumn("Monto", typeof(int)));
        dtEgresosRPT.Columns.Add(new DataColumn("MontoNoNulo", typeof(int)));
        dtEgresosRPT.Columns.Add(new DataColumn("MedioDePago", typeof(string)));
        dtEgresosRPT.Columns.Add(new DataColumn("Glosa", typeof(string)));
        dtEgresosRPT.Columns.Add(new DataColumn("Destino", typeof(string)));
        dtEgresosRPT.Columns.Add(new DataColumn("NumeroCheque", typeof(string)));
        dtEgresosRPT.Columns.Add(new DataColumn("Nulo", typeof(Boolean)));

        DataRow dr;
        for (int i = 0; i < grdEgresoDetalles.Rows.Count; i++)
        {
            chkNulo = (System.Web.UI.WebControls.CheckBox)grdEgresoDetalles.Rows[i].Cells[10].FindControl("chkNulo");

            dr = dtEgresosRPT.NewRow();
            dr[0] = Convert.ToDateTime(grdEgresoDetalles.Rows[i].Cells[0].Text);
            dr[1] = Convert.ToInt32(grdEgresoDetalles.Rows[i].Cells[1].Text);
            dr[2] = Convert.ToInt32(grdEgresoDetalles.Rows[i].Cells[2].Text);
            dr[3] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[3].Text));
            dr[4] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[4].Text));
            dr[5] = Convert.ToInt32(grdEgresoDetalles.Rows[i].Cells[5].Text.Replace(".", ""));
            if (chkNulo.Checked)
            {
                dr[6] = 0;
            }
            else
            {
                dr[6] = Convert.ToInt32(grdEgresoDetalles.Rows[i].Cells[5].Text.Replace(".", ""));
            }
            dr[7] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[6].Text));
            dr[8] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[7].Text));
            dr[9] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[8].Text));
            dr[10] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[9].Text));
            dr[11] = chkNulo.Checked;

            dtEgresosRPT.Rows.Add(dr);
        }
    }

    /*-----------------------------------------------------------------------------------------
    // 22/12/2014
    // Se agregan las siguientes VOID que reemplazarán a los originales que se encuentran 
    // asociados a Infragistics.
    // Se usa el mismo nombre de las VOID originales y se agrega el sufijo "NEW"
    // para su diferenciación.
    //-----------------------------------------------------------------------------------------
    //*/
    protected void btnBuscaRendicion_Click_NEW(object sender, EventArgs e)
    {
        BuscaRendicion_NEW(sender, e, 0);
    }
    protected void BuscaRendicion_NEW(object sender, EventArgs e, int Busca)
    {
        pnlHeader.Visible = (Busca == 1);
        pnlBody.Visible = (Busca == 1);
        divbotonera.Visible = (Busca == 1);
        pnlSearch.Visible = (Busca == 0);

        if (Convert.ToUInt32(ddlInstitucion.SelectedValue) == 0)
        {
            txtInstitucion_NEW.Text = "";
        }
        else
        {
            txtInstitucion_NEW.Text = ddlInstitucion.SelectedItem.Text;
        }

        if (txtAno_NEW.Text == "")
        {
            txtAnoMes_NEW.Text = "";
        }
        else
        {
            txtAnoMes_NEW.Text = Convert.ToString(Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue));
        }

        btnBuscar_Click_NEW(sender, e);
    }
    protected void btnBuscar_Click_NEW(object sender, EventArgs e)
    {
        int iAnoMes;

        if (txtAnoMes_NEW.Text.Trim() != "")
        {
            iAnoMes = Convert.ToInt32(txtAnoMes_NEW.Text.Trim());
        }
        else
        {
            iAnoMes = 0;
        }
        string mes = iAnoMes.ToString();
        if (mes.Length > 4)
        {
            mes = mes.Substring(4, 2).ToString();
        }
        if (mes == "00")
        {
            iAnoMes = 0;
        }
        RendicionEgresoColl rE = new RendicionEgresoColl();
        dtEgresos.Rows.Clear();
        txtIdRendicionEgreso.Text = "";
        dtEgresos = rE.GetDataInstituciones(ddlInstitucion.SelectedValue.ToString(), iAnoMes, dtEgresos, 1, Convert.ToInt32(Session["IdUsuario"]));
        if (dtEgresos.Rows.Count > 0)
        {
            grdBuscador.DataSource = dtEgresos;
            grdBuscador.DataBind();
            lbl_notFound.Visible = false;
        }
        else
        {
            lbl_notFound.Visible = true;
        }
    }
    protected void btnNuevo_Click_NEW(object sender, EventArgs e)
    {
        if (ddlMeses.SelectedValue == "0")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar el mes del Egreso de Cuentas";
            ddlMeses.Focus();
            return;
        }
        if (txtAno_NEW.Text.Length != 4 || txtAno_NEW.Text.Trim() == "")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe Ingresar el año del registro de Egreso";
            txtAno_NEW.Focus();
            return;
        }
        else
        {
            //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text);
            //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text);
            //ddlFechaComprobante.Value = ddlFechaComprobante.MinDate;
            //ddlFechaComprobante.Text = ("01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text);
            //txtFechaComprobante.Text = ("01-" + ddlMeses.SelectedValue + "-" + txtAno_NEW.Text);
            txtFechaComprobante.Text = txtFechaRegistro.Text;
        }

        if (Convert.ToInt32(ddlInstitucion.SelectedValue) == 0)
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar una Institución";
            ddlInstitucion.Focus();
            return;
        }
        //if (ddlFechaRegistro.Text.Trim() == "")
        if (txtFechaRegistro.Text.Trim() == "")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe Ingresar la fecha de Registro";
            txtFechaRegistro.Focus();
            return;
        }
        if (Convert.ToInt32(txtAno_NEW.Text) > DateTime.Now.Year ||
            (Convert.ToInt32(txtAno_NEW.Text) == DateTime.Now.Year &&
            Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "No puede crear Egresos de meses futuros";
            return;
        }
        BuscaRendicion_NEW(sender, e, 1);
        HabilitaDeshabilitaHeaderFrame(dtEgresos.Rows.Count == 0);
        lblInformacion.Visible = (dtEgresos.Rows.Count != 0);
        tblTotal.Visible = (dtEgresos.Rows.Count != 0);
        btnEgreso_Click_NEW(sender, e);
        btnEgreso_NEW.Visible = false;
        btnImprimir_NEW.Visible = false;
        btnExcel_NEW.Visible = false;
        btnCancelarNEW.Visible = true;

        lblInformacion.Text = "Ya existe una rendición registrada para el proyecto y periodo indicado";
        pnlSearch.Visible = false;
    }
    protected void btnEgreso_Click_NEW(object sender, EventArgs e)
    {
        HabilitaEgresos();
        GetObjetivos(1);
        GetUsos(1);
        GetMedioDePago(1);
        tblEditar.Rows[1].Visible = false;
        tblEditar.Rows[2].Visible = false;
    }
    private void HabilitaEgresos_NEW()
    {
        pnlDetail.Visible = true;
        btnGuardaEgreso_NEW.Visible = true;
        btnCancelaEgreso_NEW.Visible = true;
        btnEgreso_NEW.Visible = false;
        txtFechaComprobante.Text= DateTime.Now.ToString();
        txtNumeroComprobante.Text = "";
        txtCorrelativo_NEW.Text = "";
        txtMonto_NEW.Text = "0";
        txtGlosa.Text = "";
        rbAnular.SelectedValue = "0";
        txtDestino.Text = "";
        txtNumeroDeCheque.Text = "";
    }
    protected void btnImprimir_Click_NEW(object sender, EventArgs e)
    {
        PreparaReporte();
        window.open(this.Page, "Reg_Reportes.aspx?Impresora_Excel=1" + "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno_NEW.Text + "&param001=5", "Reportes", false, true, 800, 600, false, false, true);
    }
    protected void btnExcel_Click_NEW(object sender, EventArgs e)
    {
        PreparaReporte();


        window.open(this.Page, "Reg_Reportes.aspx?Impresora_Excel=2" + "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno_NEW.Text + "&param001=5", "Reportes", false, true, 800, 600, false, false, true);
    }
    protected void btnGuardaIngreso_Click_NEW(object sender, EventArgs e)
    {
        if (ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo) && ValidaTipoDetalleEgreso(ddlUso, lblUso) && ValidaTipoDetalleEgreso(ddlMedioDePago, lblMedioPago))
        {
            int iIdRendicionEgreso = 0;
            int iAnoMes;
            int iNumeroComprobante = 0;
            int iCorrelativo = 0;
            int iNulo = 0;
            int iCodInstitucion = Convert.ToInt32(ddlInstitucion.SelectedValue);
            int iMonto = 0;
            int iTotal = 0;
            int iCodUso = Convert.ToInt32(ddlUso.SelectedValue);
            int iCodMedioDePago = Convert.ToInt32(ddlMedioDePago.SelectedValue);
            DateTime dFechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);

            if (txtIdRendicionEgreso.Text.Trim() != "")
            {
                iIdRendicionEgreso = Convert.ToInt32(txtIdRendicionEgreso.Text);
            }
            if (txtNumeroComprobante.Text.Trim() != "")
            {
                iNumeroComprobante = Convert.ToInt32(txtNumeroComprobante.Text);
            }
            if (txtCorrelativo_NEW.Text.Trim() != "")
            {
                iCorrelativo = Convert.ToInt32(txtCorrelativo_NEW.Text);
            }
            if (ddlObjetivo.SelectedValue.Trim() == "10")
            {
                iMonto = iMonto * -1;
            }
            if (rbAnular.SelectedValue != "0")
            {
                iNulo = 1;
            }

            iMonto = Convert.ToInt32(txtMonto_NEW.Text);
            if (iMonto == 0)
            {
                lblMonto.Visible = true;
                lblMonto.Text = "El monto del Egreso debe ser distinto de cero";
                txtMonto_NEW.Focus();
                return;
            }
            else
            {
                lblMonto.Text = string.Empty;
            }

            iAnoMes = Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);

            if (ddlObjetivo.SelectedValue == "16")
            {
                iMonto *= -1;
            }

            RendicionEgresoColl rI = new RendicionEgresoColl();
            rI.InsertUpdateInstitucion(iIdRendicionEgreso, iNumeroComprobante, iCorrelativo, iCodUso, Convert.ToDateTime(txtFechaComprobante.Text), iCodMedioDePago, iMonto, txtNumeroDeCheque.Text.ToUpper(), txtGlosa.Text.ToUpper(), txtDestino.Text.ToUpper(), iNulo, Convert.ToInt32(Session["IdUsuario"]), iAnoMes, iCodInstitucion, dFechaRegistro);

            GetEgresosGr();
            dtEgresos = rI.GetDataInstituciones(ddlInstitucion.SelectedValue.ToString(), iAnoMes, dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));
            Session["dtEgresosRPT"] = dtEgresos;
            grdEgresoDetalles.DataSource = dtEgresos;
            grdEgresoDetalles.DataBind();
            txtIdRendicionEgreso.Text = dtEgresos.Rows[0]["IdRendicionEgreso"].ToString();
            iTotal = SumaTotales(iTotal);
            txtTotal_NEW.Text = Convert.ToString(iTotal);
            tblTotal.Visible = true;
            btnCancelaEgreso_Click_NEW(sender, e);
            A2.HRef = "Reg_Reportes.aspx?Impresora_Excel=2&dir=Reg_Egresos_Instituciones.aspx&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno_NEW.Text + "&param001=5";
            A3.HRef = "Reg_Reportes.aspx?Impresora_Excel=1&dir=Reg_Egresos_Instituciones.aspx&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno_NEW.Text + "&param001=5";
        }        
    }

    protected void btnCancelaEgreso_Click_NEW(object sender, EventArgs e)
    {

        pnlDetail.Visible = false;
        btnGuardaEgreso_NEW.Visible = false;
        btnEgreso_NEW.Visible = true;
        btnImprimir_NEW.Visible = true;
        btnExcel_NEW.Visible = true;
        btnCancelaEgreso_NEW.Visible = false;
        lblObjetivo.Visible = false;
        lblUso.Visible = false;
        lblMedioPago.Visible = false;
        lblMonto.Visible = false;
        //ddlFechaComprobante.ReadOnly = false;
        tblEditar.Rows[1].Visible = true;
        tblEditar.Rows[2].Visible = true;

    }

    protected void btnLimpiaBusqueda_Click_NEW(object sender, EventArgs e)
    {
        LimpiaBusqueda();
    }
    protected void btnCancelarBusqueda_Click_NEW(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlHeader.Visible = true;
        LimpiaBusqueda();
    }
    protected void btnCancelarNEW_Click(object sender, EventArgs e)
    {
        HabilitaDeshabilitaHeaderFrame(false);
        LimpiaBusqueda();
        dtEgresos.Rows.Clear();
        grdBuscador.DataSource = "";
        grdBuscador.DataBind();
        grdEgresoDetalles.DataSource = "";
        grdEgresoDetalles.DataBind();
        lblInformacion.Visible = false;
        validatescurity();
    }
    protected void btnVolver_NEW_Click(object sender, EventArgs e)
    {
        btnCancelarNEW_Click(sender, e);
        Response.Redirect("rendicion_cuentas.aspx");
    }
    //protected void ImbCalFechaRegistro_Click(object sender, ImageClickEventArgs e)
    //{
    //    CalFechaRegistro.Visible = !(CalFechaRegistro.Visible);
    //}
    //protected void CalFechaRegistro_SelectionChanged(object sender, EventArgs e)
    //{
    //    txtFechaRegistro.Text = CalFechaRegistro.SelectedDate.ToString();
    //    txtFechaRegistro.Text = txtFechaRegistro.Text.Substring(0, 10);
    //    CalFechaRegistro.Visible = false;
    //}
    //protected void ImbCalFechaComprobante_Click(object sender, ImageClickEventArgs e)
    //{
    //    CalFechaComprobante.Visible = !(CalFechaComprobante.Visible);
    //}
    //protected void CalFechaComprobante_SelectionChanged(object sender, EventArgs e)
    //{
    //    txtFechaComprobante.Text = CalFechaComprobante.SelectedDate.ToString();
    //    txtFechaComprobante.Text = txtFechaComprobante.Text.Substring(0, 10);
    //    CalFechaComprobante.Visible = false;
    //}
    protected void HabilitaDeshabilitaHeaderFrame(Boolean Habilita)
    {
        ddlInstitucion.Enabled = !Habilita;
        ddlMeses.Enabled = !Habilita;
        txtAno_NEW.Enabled = !Habilita;
        //ddlFechaRegistro.Enabled = !Habilita;
        btnBuscaRendicion_NEW.Visible = !Habilita;
        btnNuevo_NEW.Visible = !Habilita;

        pnlBody.Visible = Habilita;
        divbotonera.Visible = Habilita;
        pnlSearch.Visible = Habilita;
        btnEgreso_NEW.Visible = Habilita;
        btnImprimir_NEW.Visible = Habilita;
        btnExcel_NEW.Visible = Habilita;
    }
    private void validatescurity()
    {
        //23C24062-9E9C-44BE-8AA4-5A3AF6121452 1.9.4_INGRESAR
        if (!window.existetoken("23C24062-9E9C-44BE-8AA4-5A3AF6121452"))
        {
            btnNuevo_NEW.Visible = false;
            btnEgreso_NEW.Visible = false;
        }
        ////D8299046-01C7-4DFB-B35A-47A61A64315E 1.9.4_MODIFICAR
        if (!window.existetoken("D8299046-01C7-4DFB-B35A-47A61A64315E"))
        {
            grdEgresoDetalles.Columns[11].Visible = false;
            grdEgresoDetalles.Columns[12].Visible = false;
            grdEgresoDetalles.Columns[13].Visible = false;
        }
    }
    protected void LimpiaBusqueda()
    {
        txtInstitucion_NEW.Text = "";
        txtTotal_NEW.Text = "0";
        txtAnoMes_NEW.Text = "";
        lblInformacion.Visible = false;
        dtEgresos.Rows.Clear();
        grdBuscador.DataSource = "";
        grdBuscador.DataBind();
        lbl_notFound.Visible = false;
    }
}

