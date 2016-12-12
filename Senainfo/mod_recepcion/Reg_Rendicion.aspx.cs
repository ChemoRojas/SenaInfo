/*
 * 
 * GMP
 * 20/05/2015
 * Revisión windows.open, agregué reloj de espera, validación de fecha, no hay descargas excel
 * 
 */
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

public partial class mod_instituciones_Reg_Rendicion : System.Web.UI.Page
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

    public DataTable dtRendicionCuentas
    {
        get { return (DataTable)Session["dtRendicionCuentas"]; }
        set { Session["dtRendicionCuentas"] = value; }
    }

    public void GetRendicionCuentas()
    {
        dtRendicionCuentas = new DataTable();

        dtRendicionCuentas.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("Institucion", typeof(string)));
        dtRendicionCuentas.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("Proyecto", typeof(string)));
        dtRendicionCuentas.Columns.Add(new DataColumn("AnoMes", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("Codbanco", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("Banco", typeof(string)));
        dtRendicionCuentas.Columns.Add(new DataColumn("CuentaCorrienteNumero", typeof(string)));
        dtRendicionCuentas.Columns.Add(new DataColumn("NumeroPlazas", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("NumChequeReintegro", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("MontoReintegro", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("AnoPptoReintegro", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("SaldoAnterior", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("SaldoMes", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("FechaRendicion", typeof(DateTime)));
        dtRendicionCuentas.Columns.Add(new DataColumn("Cerrado", typeof(Boolean)));
        dtRendicionCuentas.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dtRendicionCuentas.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("RutNumeroProyecto", typeof(string)));
        dtRendicionCuentas.Columns.Add(new DataColumn("DeudaAnterior", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("DeudaMes", typeof(int)));
        //GMP
        dtRendicionCuentas.Columns.Add(new DataColumn("ProvisionIndemnizacion", typeof(int)));
        dtRendicionCuentas.Columns.Add(new DataColumn("SaldoReal", typeof(int)));
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
                if (!window.existetoken("127ED738-05E2-4843-96DD-827002DD8237"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                txtAno.Text = DateTime.Now.Year.ToString();
                GetInstituciones();
                GetProyectos();
                GetRendicionCuentas();
                GetIngresosGr();
                GetEgresosGr();
                GetObjetivos(2);
                GetUsos(2);
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
                    ddlProyecto.SelectedValue = Request.QueryString["codinst"];
                    BuscaDatosBanco();
                }
                validatescurity();
            }
        }
    }
    private void validatescurity()
    {
        //7B284FF9-AF22-420B-A402-F7F0C9D8DE97 1.9.3_INGRESAR
        if (!window.existetoken("7B284FF9-AF22-420B-A402-F7F0C9D8DE97"))
        {
            btnNueva.Visible = false;
            btnCerrar.Visible = false;
            btnCierreSinMovimiento.Visible = false;
            btnGuardar.Visible = false;
            btnGuardaDeuda.Visible = false;
        }
        //4C5E2268-221F-4E78-96FC-D6B15091B4DF 1.9.1_MODIFICAR
        if (!window.existetoken("4C5E2268-221F-4E78-96FC-D6B15091B4DF"))
        {
            grdDeudas.Columns[4].Visible = false;
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

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddlInstitucion.SelectedValue));
        ddlProyecto.DataSource = dtproy;
        ddlProyecto.DataTextField = "Nombre";
        ddlProyecto.DataValueField = "CodProyecto";
        ddlProyecto.DataBind();
    }
    protected void ddlInstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProyectos();
        BuscaDatosBanco();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Buscar_Click();
    }
    protected void Buscar_Click()
    {
        int iAnoMes;
        string strProyecto = "";

        if (txtCodProyecto.Text != "")
        {
            strProyecto = txtProyecto.Text.Trim();
            txtProyecto.Text = "";
        }

        if (txtAnoMes.Text.Trim() != "")
            iAnoMes = Convert.ToInt32(txtAnoMes.Text.Trim());
        else
            iAnoMes = 0;
        RendicionCuentasColl rC = new RendicionCuentasColl();
        dtRendicionCuentas.Rows.Clear();
        dtRendicionCuentas = rC.GetData(txtInstitucion.Text.Trim(), txtCodProyecto.Text.Trim(), txtProyecto.Text.Trim(), iAnoMes, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));

        grdBuscador.DataSource = dtRendicionCuentas;
        grdBuscador.DataBind();
        txtProyecto.Text = strProyecto;
    }
    protected void btnBuscaRendicion_Click(object sender, EventArgs e)
    {
        BuscaRendicion(sender, e, 0);
    }
    protected void BuscaRendicion(object sender, EventArgs e, int Busca)
    {
        pnlHeader.Visible = (Busca == 1);
        pnlBody.Visible = (Busca == 1);
        pnlSearch.Visible = (Busca == 0);

        txtInstitucion.Text = ddlInstitucion.SelectedItem.Text;

        if (Convert.ToUInt32(ddlProyecto.SelectedValue) == 0)
        {
            txtCodProyecto.Text = "";
            txtProyecto.Text = "";
        }
        else
        {
            txtCodProyecto.Text = ddlProyecto.SelectedValue;
            txtProyecto.Text = ddlProyecto.SelectedItem.Text;
        }

        if (txtAno.Text == "")
            txtAnoMes.Text = "";
        else
            txtAnoMes.Text = Convert.ToString(Convert.ToInt16(txtAno.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue));

        Buscar_Click();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Cancelar();
    }
    protected void Cancelar()
    {
        HabilitaDeshabilitaHeaderFrame(false);
        LimpiaBusqueda();
        dtRendicionCuentas.Rows.Clear();
        dtIngresos.Rows.Clear();
        dtEgresos.Rows.Clear();

        grdBuscador.DataSource = "";
        grdBuscador.DataBind();

        grdIngresoDetalles.Visible = false;
        grdIngresoDetalles.DataSource = "";
        grdIngresoDetalles.DataBind();
        btnIngresos.Text = "Ver Detalle";

        grdIngresoResumen.Visible = true;
        grdIngresoResumen.DataSource = "";
        grdIngresoResumen.DataBind();

        grdEgresoDetalles.Visible = false;
        grdEgresoDetalles.DataSource = "";
        grdEgresoDetalles.DataBind();
        btnEgresos.Text = "Ver Detalle";

        grdEgresoResumen.Visible = true;
        grdEgresoResumen.DataSource = "";
        grdEgresoResumen.DataBind();

        grdDeudas.DataSource = "";
        grdDeudas.DataBind();
        pnlDetalleDeudas.Visible = false;

        lblInformacion.Visible = false;
        txtNumeroCheque.ReadOnly = lblInformacion.Visible;
        txtMonto.ReadOnly = lblInformacion.Visible;
        txtAnoPresupuestario.ReadOnly = lblInformacion.Visible;

        btnImprimir.Visible = false;
        btnCierreSinMovimiento.Visible = true;
        txtBanco.Text = "";
        txtCuentaCorriente.Text = "";
        txtRutNumeroProyecto.Text = "";
        txtPlazas.Text = "";
        txtSaldoAnterior.Text = "0";
        txtTotalIngresos.Text = "0";
        txtTotalDisponible.Text = "0";
        txtTotalEgresos.Text = "0";
        txtSaldoDisponible.Text = "0";
        txtNumeroCheque.Text = "";
        txtMonto.Text = "0";
        txtAnoPresupuestario.Text = "";
        txtMontoDeuda.Text = "0";
        txtNuevo.Text = "0";
        validatescurity();
    }
    protected void HabilitaDeshabilitaHeaderFrame(Boolean Habilita)
    {
        ddlInstitucion.Enabled = !Habilita;
        ddlProyecto.Enabled = !Habilita;
        ddlMeses.Enabled = !Habilita;
        txtAno.Enabled = !Habilita;
        btnBuscaRendicion.Visible = !Habilita;
        btnNueva.Visible = !Habilita;
        btnBuscaInstitucion.Enabled = !Habilita;
        btnBuscaProyecto.Enabled = !Habilita;

        btnCierreSinMovimiento.Visible = !Habilita;
        pnlBody.Visible = Habilita;
        pnlSearch.Visible = Habilita;
        pnlDeudas.Visible = Habilita;
        btnCancelar.Visible = Habilita;
    }
    protected void LimpiaBusqueda()
    {
        txtInstitucion.Text = "";
        txtCodProyecto.Text = "";
        txtProyecto.Text = "";
        txtAnoMes.Text = "";
        lblInformacion.Visible = false;
        btnGuardar.Visible = false;
        btnCerrar.Visible = false;
        dtRendicionCuentas.Rows.Clear();
        grdBuscador.DataSource = "";
        grdBuscador.DataBind();
    }
    protected void btnLimpiaBusqueda_Click(object sender, EventArgs e)
    {
        LimpiaBusqueda();
    }
    protected void btnCancelarBusqueda_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlHeader.Visible = true;
        LimpiaBusqueda();
    }
    protected void grdBuscador_RowEditing(object sender, GridViewEditEventArgs e)
    {
        HabilitaDeshabilitaHeaderFrame(true);
        pnlHeader.Visible = true;
        pnlBody.Visible = true;
        pnlSearch.Visible = false;

        int i = e.NewEditIndex;
        System.Web.UI.WebControls.CheckBox chkCerrado;

        ddlInstitucion.SelectedValue = grdBuscador.Rows[i].Cells[0].Text;
        GetProyectos();
        ddlProyecto.SelectedValue = grdBuscador.Rows[i].Cells[2].Text;
        txtProyecto.Text = grdBuscador.Rows[i].Cells[3].Text;
        txtCodProyecto.Text = grdBuscador.Rows[i].Cells[2].Text;

        ddlMeses.SelectedValue = Convert.ToInt16(grdBuscador.Rows[i].Cells[4].Text.Substring(4, 2)).ToString();
        txtAno.Text = grdBuscador.Rows[i].Cells[4].Text.Substring(0, 4);
        CalendarExtende1289.EndDate = Convert.ToDateTime("01-" + ddlMeses.SelectedValue + "-" + txtAno.Text).AddMonths(1).AddDays(-1);

        LlenaHeader(i, false);
        int iAnoMes = Convert.ToInt32(grdBuscador.Rows[i].Cells[4].Text);

        chkCerrado = (System.Web.UI.WebControls.CheckBox)grdBuscador.Rows[i].Cells[6].FindControl("chkCerrado");
        if (!ObtieneIngresosEgresos(iAnoMes, true,false))
            if(chkCerrado.Checked.ToString().ToLower() == "false")
                return;

        lblInformacion.Text = "La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios.";
        lblInformacion.Visible = (chkCerrado.Checked.ToString().ToLower() == "true");
        btnImprimir.Visible = lblInformacion.Visible;
        btnIngresoDeudas.Visible = !lblInformacion.Visible;
        grdDeudas.Columns[4].Visible = !lblInformacion.Visible;

        if (lblInformacion.Visible) txtCerrado.Text = "1"; else txtCerrado.Text = "0";
        btnGuardar.Visible = !lblInformacion.Visible;
        btnCerrar.Visible = !lblInformacion.Visible;
        btnIngresoDeudas.Visible = !lblInformacion.Visible;

        txtNumeroCheque.ReadOnly = lblInformacion.Visible;
        txtMonto.ReadOnly = lblInformacion.Visible;
        txtAnoPresupuestario.ReadOnly = lblInformacion.Visible;
        txtDeudaAnterior.Text = Convert.ToInt32(dtRendicionCuentas.Rows[e.NewEditIndex]["DeudaAnterior"]).ToString();
        txtTotalDeudas.Text = Convert.ToInt32(dtRendicionCuentas.Rows[e.NewEditIndex]["DeudaMes"]).ToString();
        RendicionCuentasColl rC = new RendicionCuentasColl();
        if (chkCerrado.Checked.ToString().ToLower() == "false")
        {
            dtRendicionCuentas.Rows.Clear();
            dtRendicionCuentas = rC.GetRendicionAnterior(ddlProyecto.SelectedValue, iAnoMes, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));

            if (dtRendicionCuentas.Rows.Count == 0)
                dtRendicionCuentas = rC.GetData("", ddlProyecto.SelectedValue, "", -1, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));
            else
            {
                if (dtRendicionCuentas.Rows[0]["Cerrado"].ToString().ToLower() == "false")
                {
                    Cancelar();
                    lblInformacion.Visible = true;
                    lblInformacion.Text = "Debe cerrar la rendición del mes anterior";
                    return;
                }
            }
            LlenaHeader(0, true);
        }
        int iDeudaAnterior = Convert.ToInt32(txtDeudaAnterior.Text);

        LlenaIE(iAnoMes);
        if (txtCerrado.Text == "0")
        {
            DataTable dt = rC.GetDataDeuda(ddlProyecto.SelectedValue, iAnoMes, 0);
            grdDeudas.DataSource = dt;
            grdDeudas.DataBind();

            DataTable dt2 = dtRendicionCuentas;
            dt2.Rows.Clear();
            dt2 = rC.GetRendicionAnterior(ddlProyecto.SelectedValue, iAnoMes, dt2, Convert.ToInt32(Session["IdUsuario"]));
            if (dt2.Rows.Count != 0)
                txtDeudaAnterior.Text = Convert.ToInt32(dt2.Rows[0]["DeudaMes"]).ToString();

            txtTotalDeudas.Text = SumaTotales(dt, iAnoMes).ToString();
        }
        txtNuevo.Text = "0";
        validatescurity();
    }

    protected Boolean ObtieneIngresosEgresos(int iAnoMes, Boolean AsignaGrilla, Boolean MesAnterior)
    {
        if (MesAnterior)
        {
            int iAno = Convert.ToInt32(iAnoMes.ToString().Substring(0, 4));
            int iMes = Convert.ToInt32(iAnoMes.ToString().Substring(4, 2));

            if (iMes == 1)
            {
                iMes = 12;
                iAno = iAno - 1;
            }
            else
                iMes = iMes - 1;

            iAnoMes = (iAno * 100) + iMes;
        }

        RendicionIngresoColl rI = new RendicionIngresoColl();
        dtIngresos.Rows.Clear();
        dtIngresos = rI.GetData("", txtCodProyecto.Text, "", iAnoMes, dtIngresos, 0, Convert.ToInt32(Session["IdUsuario"]));

        if (AsignaGrilla)
        {
            txtTotalIngresos.Text = SumaTotales(dtIngresos).ToString();
            grdIngresoDetalles.DataSource = dtIngresos;
            grdIngresoDetalles.DataBind();
        }
        RendicionEgresoColl rE = new RendicionEgresoColl();
        dtEgresos.Rows.Clear();
        dtEgresos = rE.GetData("", txtCodProyecto.Text, "", iAnoMes, dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));

        if (AsignaGrilla)
        {
            txtTotalEgresos.Text = SumaTotales(dtEgresos).ToString();
            grdEgresoDetalles.DataSource = dtEgresos;
            grdEgresoDetalles.DataBind();
        }
        lblInformacion.Visible = (dtIngresos.Rows.Count == 0 && dtEgresos.Rows.Count == 0);
        lblInformacion.Text = "No se puede hacer una Rendición sin tener registros de Ingreso o Egreso";

        return (!lblInformacion.Visible);
    }
    protected int SumaTotales(DataTable dt)
    {
        int iSuma = 0;
        foreach (DataRow row in dt.Rows)
        {
            if (row["Nulo"].ToString().ToLower() == "false")
                iSuma = iSuma + Convert.ToInt32(row["Monto"]);
        }
        return iSuma;
    }

    private void LlenaHeader(int i, Boolean MesAnterior)
    {
        txtBanco.Text = dtRendicionCuentas.Rows[i]["Banco"].ToString();
        txtCuentaCorriente.Text = dtRendicionCuentas.Rows[i]["CuentaCorrienteNumero"].ToString();
        txtPlazas.Text = dtRendicionCuentas.Rows[i]["NumeroPlazas"].ToString();
        txtRutNumeroProyecto.Text = dtRendicionCuentas.Rows[i]["RutNumeroProyecto"].ToString();
        if (MesAnterior)
            txtSaldoAnterior.Text = dtRendicionCuentas.Rows[i]["SaldoMes"].ToString();
        else
        {
            txtSaldoAnterior.Text = dtRendicionCuentas.Rows[i]["SaldoAnterior"].ToString();
            txtNumeroCheque.Text = dtRendicionCuentas.Rows[i]["NumChequeReintegro"].ToString();
            txtMonto.Text = dtRendicionCuentas.Rows[i]["MontoReintegro"].ToString();
            txtAnoPresupuestario.Text = dtRendicionCuentas.Rows[i]["AnoPptoReintegro"].ToString();
        }
    }
    private void LlenaIE(int iAnoMes)
    {
        RendicionCuentasColl rC = new RendicionCuentasColl();
        DataTable dtResumenIngreso = rC.GetDataResumen(txtCodProyecto.Text, iAnoMes, 1);
        DataTable dtResumenEgreso = rC.GetDataResumen(txtCodProyecto.Text, iAnoMes, 0);

        grdIngresoResumen.DataSource = dtResumenIngreso;
        grdIngresoResumen.DataBind();
        grdEgresoResumen.DataSource = dtResumenEgreso;
        grdEgresoResumen.DataBind();

        txtTotalDisponible.Text = (Convert.ToInt32(txtSaldoAnterior.Text) + Convert.ToInt32(txtTotalIngresos.Text)).ToString();
        txtSaldoDisponible.Text =  (Convert.ToInt32(txtTotalDisponible.Text) - Convert.ToInt32(txtTotalEgresos.Text)).ToString();
        dtRendicionCuentas.Rows.Clear();
    }
    public DataTable dtEgresos
    {
        get { return (DataTable)Session["dtEgresos"]; }
        set { Session["dtEgresos"] = value; }
    }
    public void GetEgresosGr()
    {
        dtEgresos = new DataTable();

        dtEgresos.Columns.Add(new DataColumn("IdRendicionEgreso", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("Institucion", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("Proyecto", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("AnoMes", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("FechaRegistro", typeof(DateTime)));
        dtEgresos.Columns.Add(new DataColumn("NroComprobante", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("Correlativo", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("FechaComprobante", typeof(DateTime)));
        dtEgresos.Columns.Add(new DataColumn("Monto", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("Glosa", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("Nulo", typeof(Boolean)));
        dtEgresos.Columns.Add(new DataColumn("CodUso", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("Uso", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("CodObjetivo", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("Objetivo", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("CodMedioDePago", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("MedioDePago", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("Destino", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("NumeroCheque", typeof(string)));
        dtEgresos.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dtEgresos.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dtEgresos.Columns.Add(new DataColumn("Cerrado", typeof(Boolean)));
    }
    public DataTable dtIngresos
    {
        get { return (DataTable)Session["dtIngresos"]; }
        set { Session["dtIngresos"] = value; }
    }
    public void GetIngresosGr()
    {
        dtIngresos = new DataTable();

        dtIngresos.Columns.Add(new DataColumn("IdRendicionIngreso", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("Institucion", typeof(string)));
        dtIngresos.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("Proyecto", typeof(string)));
        dtIngresos.Columns.Add(new DataColumn("AnoMes", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("FechaRegistro", typeof(DateTime)));
        dtIngresos.Columns.Add(new DataColumn("NroComprobante", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("Correlativo", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("FechaComprobante", typeof(DateTime)));
        dtIngresos.Columns.Add(new DataColumn("Monto", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("Glosa", typeof(string)));
        dtIngresos.Columns.Add(new DataColumn("Nulo", typeof(Boolean)));
        dtIngresos.Columns.Add(new DataColumn("CodDetalleIngreso", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("DetalleIngreso", typeof(string)));
        dtIngresos.Columns.Add(new DataColumn("CodTipoIngreso", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("TipoIngreso", typeof(string)));
        dtIngresos.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));
        dtIngresos.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        dtIngresos.Columns.Add(new DataColumn("Cerrado", typeof(Boolean)));
    }
    protected void btnIngreso_Click(object sender, EventArgs e)
    {
        grdIngresoResumen.Visible = grdIngresoDetalles.Visible;
        grdIngresoDetalles.Visible = !grdIngresoResumen.Visible;
        if (grdIngresoResumen.Visible) btnIngresos.Text = "Ver Detalle"; else btnIngresos.Text = "Ver Resumen";
    }
    protected void btnEgresos_Click(object sender, EventArgs e)
    {
        grdEgresoResumen.Visible = grdEgresoDetalles.Visible;
        grdEgresoDetalles.Visible = !grdEgresoResumen.Visible;
        if (grdEgresoResumen.Visible) btnEgresos.Text = "Ver Detalle"; else btnEgresos.Text = "Ver Resumen";
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        GuardaRendicion();
    }
    protected void GuardaRendicion()
    {
        RendicionCuentasColl rC = new RendicionCuentasColl();

        int CodProyecto = Convert.ToInt32(txtCodProyecto.Text);
        int AnoMes = Convert.ToInt16(txtAno.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
        int NumChequeReintegro = 0;
        int AnoPresupuestario = 0;
        int Cerrado = Convert.ToInt32(txtCerrado.Text);

        if (txtNumeroCheque.Text.Trim() == "") NumChequeReintegro = 0; else NumChequeReintegro = Convert.ToInt32(txtNumeroCheque.Text);
        if (txtAnoPresupuestario.Text.Trim() == "") AnoPresupuestario = 0; else AnoPresupuestario = Convert.ToInt32(txtAnoPresupuestario.Text);

        //rC.InsertUpdate(CodProyecto, AnoMes, NumChequeReintegro, txtMonto.ValueInt, AnoPresupuestario, txtSaldoAnterior.ValueInt, txtSaldoDisponible.ValueInt, DateTime.Now, Cerrado, txtDeudaAnterior.ValueInt,txtTotalDeudas.ValueInt, 1);
        //rC.InsertUpdate(CodProyecto, AnoMes, NumChequeReintegro, txtMonto.ValueInt, AnoPresupuestario, txtSaldoAnterior.ValueInt, txtSaldoDisponible.ValueInt, DateTime.Now, Cerrado, txtDeudaAnterior.ValueInt, txtTotalDeudas.ValueInt, Convert.ToInt32(Session["IdUsuario"]));

        
        btnGuardar.Visible = Cerrado == 0;
        btnCerrar.Visible = Cerrado == 0;
        btnIngresoDeudas.Visible = Cerrado == 0;
        grdDeudas.Columns[4].Visible = Cerrado == 0;
        txtNuevo.Text = "0";
    }
    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        string strMessage = "Está seguro de cerrar la rendición de " + ddlMeses.SelectedItem + " de " + txtAno.Text + "?";
        SetMessageBox(true, 5, strMessage);
    }
    protected void CierraRendiciones()
    {
        txtCerrado.Text = "1";
        GuardaRendicion();
        btnImprimir.Visible = true;
        lblInformacion.Text = "La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios.";
        lblInformacion.Visible = true;
        txtNumeroCheque.ReadOnly = true;
        txtMonto.ReadOnly = true;
        txtAnoPresupuestario.ReadOnly = true;
    }
    protected Boolean ValidaNuevaRendicion()
    {
        if (ddlMeses.SelectedValue == "0")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar el mes de la Rendición de Cuentas";
            ddlMeses.Focus();
            return false;
        }
        if (txtAno.Text.Length != 4 || txtAno.Text.Trim() == "")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe Ingresar el año de la Rendición de Cuentas";
            txtAno.Focus();
            return false;
        }
        if (Convert.ToInt32(ddlInstitucion.SelectedValue) == 0 || Convert.ToInt32(ddlProyecto.SelectedValue) == 0)
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar una Institución y un Proyecto";
            ddlInstitucion.Focus();
            return false;
        }

        if (Convert.ToInt32(txtAno.Text) > DateTime.Now.Year ||
            (Convert.ToInt32(txtAno.Text) == DateTime.Now.Year &&
            Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "No puede crear una rendición de meses futuros";
            return false;
        }

        txtAnoMes.Text = Convert.ToString(Convert.ToInt32(txtAno.Text) * 100 + Convert.ToInt32(ddlMeses.SelectedValue));
        txtCodProyecto.Text = ddlProyecto.SelectedValue;
        Buscar_Click();
        HabilitaDeshabilitaHeaderFrame(dtRendicionCuentas.Rows.Count == 0);
        lblInformacion.Visible = (dtRendicionCuentas.Rows.Count != 0);
        pnlSearch.Visible = false;
        return true;
    }
    protected void btnNueva_Click(object sender, EventArgs e)
    {
        if (!ValidaNuevaRendicion())
            return;

        bool ExisteRendicion = lblInformacion.Visible;
        int iAnoMes = Convert.ToInt16(txtAno.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
        bool blTieneIngresosEgresosAnteriores = ObtieneIngresosEgresos(iAnoMes, false, true);
        bool blTieneIngresosEgresos = ObtieneIngresosEgresos(iAnoMes, true, false);

        if (dtRendicionCuentas.Rows.Count != 0 || !blTieneIngresosEgresos)
        {
            HabilitaDeshabilitaHeaderFrame(false);
            if (ExisteRendicion)
            {
                lblInformacion.Visible = true;
                lblInformacion.Text = "Ya existe una rendición para el proyecto y periodo indicado";
            }
            return;
        }

        dtRendicionCuentas.Rows.Clear();
        RendicionCuentasColl rC = new RendicionCuentasColl();
        dtRendicionCuentas = rC.GetRendicionAnterior(ddlProyecto.SelectedValue, iAnoMes, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));

        if (dtRendicionCuentas.Rows.Count == 0)         // No hay Rendición al mes Anterior
        {
            if (blTieneIngresosEgresosAnteriores)
            {
                lblInformacion.Visible = true;
                lblInformacion.Text = "Existen Ingresos o Egreso en el mes anterior, asegúrece de cerrar la rendición";
                return;
            }
            dtRendicionCuentas = rC.GetData("", ddlProyecto.SelectedValue, "", -1, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));
        }
        else
        {
            if (dtRendicionCuentas.Rows[0]["Cerrado"].ToString().ToLower() == "false")
            {
                lblInformacion.Visible = true;
                lblInformacion.Text = "Debe cerrar la rendición del mes anterior";
                HabilitaDeshabilitaHeaderFrame(false);
                return;
            }
            txtDeudaAnterior.Text = Convert.ToInt32(dtRendicionCuentas.Rows[0]["DeudaMes"]).ToString();
        }

        LlenaHeader(0, true);
        DataTable dt = rC.GetDataDeuda(ddlProyecto.SelectedValue, iAnoMes, 0);
        grdDeudas.DataSource = dt;
        grdDeudas.DataBind();
        txtTotalDeudas.Text = SumaTotales(dt, iAnoMes).ToString();
        LlenaIE(iAnoMes);

        btnGuardar.Visible = true;
        btnCerrar.Visible = true;
        btnIngresoDeudas.Visible = true;
        btnNueva.Visible = false;
        btnCierreSinMovimiento.Visible = false;
        pnlSearch.Visible = false;
        CalendarExtende1289.EndDate = Convert.ToDateTime("01-" + ddlMeses.SelectedValue + "-" + txtAno.Text).AddMonths(1).AddDays(-1);
        txtNuevo.Text = "1";
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        DTingresoResumen = new DataTable();
        DTegresoResumen = new DataTable();
        DTingresoResumen.Columns.Add("DescTipoIngreso", typeof(string));
        DTingresoResumen.Columns.Add("Monto", typeof(int));

        DTegresoResumen.Columns.Add("Descripcion", typeof(string));
        DTegresoResumen.Columns.Add("Monto", typeof(int));

        DataRow dr;
        for (int i = 0; i < grdIngresoResumen.Rows.Count; i++)
        {
            dr = DTingresoResumen.NewRow();
            dr[0] = Server.HtmlDecode(grdIngresoResumen.Rows[i].Cells[0].Text + " " + grdIngresoResumen.Rows[i].Cells[1].Text).ToUpper();
            dr[1] = Convert.ToInt32(grdIngresoResumen.Rows[i].Cells[2].Text.Replace(".", ""));
            DTingresoResumen.Rows.Add(dr);
        }

        for (int i = 0; i < grdEgresoResumen.Rows.Count; i++)
        {
            dr = DTegresoResumen.NewRow();
            dr[0] = Server.HtmlDecode(grdEgresoResumen.Rows[i].Cells[0].Text).ToUpper();
            dr[1] = Convert.ToInt32(grdEgresoResumen.Rows[i].Cells[1].Text.Replace(".", ""));

            DTegresoResumen.Rows.Add(dr);
        }
        window.open(this.Page,
            "Reg_Reportes.aspx?AnoPresupuestario=" + txtAnoPresupuestario.Text.Trim() +
            "&Monto=" + txtMonto.Text.Trim() +
            "&NumeroCheque=" + txtNumeroCheque.Text.Trim() +
            "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() +
            "&Proyecto=" + txtProyecto.Text.Trim() +
            "&CodProyecto=" + txtCodProyecto.Text.Trim() +
            "&RutNumeroProyecto=" + txtRutNumeroProyecto.Text.Trim() +
            "&Banco=" + txtBanco.Text.Trim() +
            "&CuentaCorriente=" + txtCuentaCorriente.Text.Trim() +
            "&Plazas=" + txtPlazas.Text.Trim() +
            "&SaldoAnterior=" + txtSaldoAnterior.Text.Trim() +
            "&TotalDisponible=" + txtTotalDisponible.Text.Trim() +
            "&SaldoDisponible=" + txtSaldoDisponible.Text.Trim() +
            "&Meses=" + ddlMeses.SelectedItem.Text +
            "&Ano=" + txtAno.Text +
            "&param001=1", "Reportes", false, true, 800, 600, false, false, true);
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        btnCancelar_Click(sender, e);
        Response.Redirect("rendicion_cuentas.aspx");
    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Rendicion.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Rendicion.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btn_MessageBox(object sender, CommandEventArgs e)
    {
        SetMessageBox(false, 0, "");
        if (e.CommandName == "6")
            CierraRendiciones();
    }
    protected void SetMessageBox(bool Habilita, int intBotones, string strMessage)
    {
        pnlHeader.Visible = !Habilita;
        pnlBody.Visible = !Habilita;
        pnlDeudas.Visible = !Habilita;
        pnlMessageBox.Visible = Habilita;
        if (!Habilita)
            return;

        lblMessage.Text = strMessage;
        switch (intBotones)
        {
            case 1:
                btnAnular.Visible = true;
                btnReintentar.Visible = true;
                btnOmitir.Visible = true;
                break;
            case 2:
                btnAceptar.Visible = true;
                break;
            case 3:
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
                break;
            case 4:
                btnReintentar.Visible = true;
                btnCancelar.Visible = true;
                break;
            case 5:
                btnSi.Visible = true;
                btnNo.Visible = true;
                break;
            case 6:
                btnSi.Visible = true;
                btnNo.Visible = true;
                btnCancelar.Visible = true;
                break;
        }
    }
    protected void grdDeudas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pnlDetalleDeudas.Visible = true;
        ddlFechaDeuda.Text = grdDeudas.Rows[e.NewEditIndex].Cells[0].Text;
        ddlFechaDeuda.ReadOnly = grdDeudas.Rows[e.NewEditIndex].BackColor == System.Drawing.Color.SandyBrown;
        ddlObjetivo.SelectedValue = grdDeudas.Rows[e.NewEditIndex].Cells[5].Text;
        ddlObjetivo.Enabled = grdDeudas.Rows[e.NewEditIndex].BackColor != System.Drawing.Color.SandyBrown;
        GetUsos(2);
        ddlUso.SelectedValue = grdDeudas.Rows[e.NewEditIndex].Cells[6].Text;
        ddlUso.Enabled = grdDeudas.Rows[e.NewEditIndex].BackColor != System.Drawing.Color.SandyBrown;
        txtMontoDeuda.Text = grdDeudas.Rows[e.NewEditIndex].Cells[3].Text.Replace(".", "");
        txtMontoDeuda.ReadOnly = grdDeudas.Rows[e.NewEditIndex].BackColor == System.Drawing.Color.SandyBrown;
        txtIdRendicionDeudas.Text = grdDeudas.Rows[e.NewEditIndex].Cells[7].Text;
        grdDeudas.Focus();
    }
    protected void ddlObjetivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo);
        GetUsos(1);
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
    private void GetObjetivos(int iVigente)
    {
        ObjetivosColl tObjetivosColl = new ObjetivosColl();
        DataView dv1 = new DataView(tObjetivosColl.GetObjetivos(iVigente));
        ddlObjetivo.DataSource = dv1;
        ddlObjetivo.DataTextField = "Descripcion";
        ddlObjetivo.DataValueField = "CodObjetivo";
        dv1.Sort = "CodObjetivo";
        ddlObjetivo.DataBind();
    }
    protected Boolean ValidaTipoDetalleEgreso(System.Web.UI.WebControls.DropDownList ddl, System.Web.UI.WebControls.Label lbl)
    {
        if (ddl.SelectedItem.Text.Substring(0, 3) == "(V)" && Convert.ToInt32(ddl.SelectedValue) != 0)
        {
            lbl.Visible = false;
            ddl.Focus();
            return true;
        }
        else
        {
            lbl.Visible = true;
            if (ddl.SelectedItem.Text.Substring(1, 1) != "V")
                lbl.Text = "No puede seleccionar un dato caducado";
            else
                lbl.Text = "Debe seleccionar un dato";

            ddl.Focus();
            return false;
        }
    }
    protected void ddlUso_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleEgreso(ddlUso, lblUso);
    }
    protected void btnGuardaDeuda_Click(object sender, EventArgs e)
    {
        if (txtMontoDeuda.Text == "0")
        {
            lblMontoDeuda.Visible = true;
            grdDeudas.Focus();
            return;
        }
        if (!ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo) || !ValidaTipoDetalleEgreso(ddlUso, lblUso))
            return;
        if (txtNuevo.Text == "1")
        {
            if (rbPagada.SelectedValue=="0")
                txtTotalDeudas.Text = txtMontoDeuda.Text;
            GuardaRendicion();
            txtNuevo.Text = "1";
        }

        int iAnoMes = Convert.ToInt32(txtAno.Text) * 100 + Convert.ToInt32(ddlMeses.SelectedValue);
        RendicionCuentasColl rC = new RendicionCuentasColl();
        //rC.InsertUpdate(Convert.ToInt32(txtIdRendicionDeudas.Text), Convert.ToInt32(ddlProyecto.SelectedValue), iAnoMes, Convert.ToDateTime(ddlFechaDeuda.Text), Convert.ToInt32(ddlUso.SelectedValue), txtMontoDeuda.ValueInt, System.DateTime.Now, Convert.ToInt32(rbPagada.SelectedValue));
        rC.InsertUpdate(Convert.ToInt32(txtIdRendicionDeudas.Text), Convert.ToInt32(ddlProyecto.SelectedValue), iAnoMes, Convert.ToDateTime(ddlFechaDeuda.Text), Convert.ToInt32(ddlUso.SelectedValue), Convert.ToInt32(txtMontoDeuda.Text), System.DateTime.Now, Convert.ToInt32(rbPagada.SelectedValue));

        DataTable dt = rC.GetDataDeuda(ddlProyecto.SelectedValue, iAnoMes, 0);
        grdDeudas.DataSource = dt;
        grdDeudas.DataBind();
        int iAnoMesDeuda = Convert.ToDateTime(ddlFechaDeuda.Text).Year * 100 + Convert.ToDateTime(ddlFechaDeuda.Text).Month;

        txtTotalDeudas.Text = SumaTotales(dt, iAnoMes).ToString();
        if(txtNuevo.Text == "0")
            GuardaRendicion();
        btnCancelaDeuda_Click(sender, e);
    }
    protected void btnCancelaDeuda_Click(object sender, EventArgs e)
    {
        txtIdRendicionDeudas.Text = "0";
        ddlObjetivo.SelectedValue = "0";
        GetUsos(2);
        txtMontoDeuda.Text = "0";
        rbPagada.SelectedIndex = 1;
        pnlDetalleDeudas.Visible = false;
        lblUso.Visible = false;
        lblObjetivo.Visible = false;
        lblMontoDeuda.Visible = false;
        ddlFechaDeuda.ReadOnly = false;
        txtMontoDeuda.ReadOnly = false;
        ddlObjetivo.Enabled = true;
        ddlUso.Enabled = true;
        grdDeudas.Focus();
    }
    protected int SumaTotales(DataTable dt, int iAnoMes)
    {
        int x = 0;
        int iSuma = 0;
        foreach (DataRow row in dt.Rows)
        {
            iSuma += Convert.ToInt32(row["Monto"]);
            if (Convert.ToInt32(row["AnoMes"]) != iAnoMes)
                grdDeudas.Rows[x].BackColor = System.Drawing.Color.SandyBrown;
            x++;
        }
        return iSuma;
    }
    protected void btnIngresoDeudas_Click(object sender, EventArgs e)
    {
        btnCancelaDeuda_Click(sender, e);
        pnlDetalleDeudas.Visible = (!pnlDetalleDeudas.Visible);
        ddlFechaDeuda.Text = Convert.ToDateTime("01-" + ddlMeses.SelectedValue + '-' + txtAno.Text).ToShortDateString();
        btnIngresoDeudas.Focus();
    }
    protected void btnCierreSinMovimiento_Click(object sender, EventArgs e)
    {
        if (!ValidaNuevaRendicion())
            return;

        bool ExisteRendición = lblInformacion.Visible;
        int iAnoMes = Convert.ToInt16(txtAno.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
        bool blTieneIngresosEgresos = ObtieneIngresosEgresos(iAnoMes, true, false);
        lblInformacion.Visible = false;

        if (dtRendicionCuentas.Rows.Count != 0 || blTieneIngresosEgresos)
        {
            HabilitaDeshabilitaHeaderFrame(false);
            lblInformacion.Visible = true;
            if (ExisteRendición)
                lblInformacion.Text = "Ya existe una rendición para el proyecto y periodo indicado";
            else
                lblInformacion.Text = "Existen ingresos o egresos para este mes, por favor realice la rendición con el botón 'Nueva Rendición'";
            
            return;
        }

        dtRendicionCuentas.Rows.Clear();
        RendicionCuentasColl rC = new RendicionCuentasColl();
        dtRendicionCuentas = rC.GetRendicionAnterior(ddlProyecto.SelectedValue, iAnoMes, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));

        blTieneIngresosEgresos = ObtieneIngresosEgresos(iAnoMes, false, true);
        lblInformacion.Visible = false;

        if (dtRendicionCuentas.Rows.Count == 0)
        {
            if (blTieneIngresosEgresos)
            {
                lblInformacion.Visible = true;
                lblInformacion.Text = "Existen Ingresos o Egreso en el mes anterior, asegúrece de cerrar la rendición";
                return;
            }
            dtRendicionCuentas = rC.GetData("", ddlProyecto.SelectedValue, "", -1, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));
        }
        else
        {
            if (dtRendicionCuentas.Rows[0]["Cerrado"].ToString().ToLower() == "false")
            {
                lblInformacion.Visible = true;
                lblInformacion.Text = "Debe cerrar la rendición del mes anterior";
                HabilitaDeshabilitaHeaderFrame(false);
                return;
            }
            txtDeudaAnterior.Text = Convert.ToInt32(dtRendicionCuentas.Rows[0]["DeudaMes"]).ToString();
        }

        LlenaHeader(0, true);
        txtTotalDeudas.Text = txtDeudaAnterior.Text;
        LlenaIE(iAnoMes);
        btnCerrar.Visible = true;
        btnNueva.Visible = false;
        btnCierreSinMovimiento.Visible = false;
        pnlSearch.Visible = false;
    }
    protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        BuscaDatosBanco();
    }
    protected void BuscaDatosBanco()
    {
        RendicionCuentasColl rC = new RendicionCuentasColl();
        dtRendicionCuentas = rC.GetData("", ddlProyecto.SelectedValue, "", -1, dtRendicionCuentas, Convert.ToInt32(Session["IdUsuario"]));
        if (dtRendicionCuentas.Rows.Count != 0)
            LlenaHeader(0, true);
        else
        {
            txtBanco.Text = "";
            txtCuentaCorriente.Text = "";
            txtPlazas.Text = "";
        }
        dtRendicionCuentas.Rows.Clear();
    }
}