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

public partial class mod_rendiciones_Reg_Egresos : System.Web.UI.Page 
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
                if (!window.existetoken("E73B1051-C725-4C6C-A226-0D069582367C"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                // 17/12/2014
                // Juan Valenzuela M.
                // ddlFechaRegistro.Value = DateTime.Now;
                txtFechaRegistro.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                                
                // 15/12/2014
                // Juan Valenzuela M.
                // Se modifica mención a textbox txtAno y se cambia por txtAno_NEW
                //txtAno.Value = DateTime.Now.Year;
                txtAno_NEW.Text = Convert.ToString( DateTime.Now.Year);
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
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]) );
                    ddlInstitucion.SelectedValue = Convert.ToString(codinst);
                    GetProyectos();
                    ddlProyecto.SelectedValue = Request.QueryString["codinst"];
                }
                validatescurity();
            }
            }
    }
    private void validatescurity()
    {
        //F25E6CFD-234C-4777-8FA8-797057DF3089 1.9.1_INGRESAR
        if (!window.existetoken("F25E6CFD-234C-4777-8FA8-797057DF3089"))
        {
            // 15/12/2014
            // Juan Valenzuela M.
            // Se comenta esta linea para reaparecer el boton NUEVO EGRESO
            // btnNuevoEgreso.Visible = false;
            btnEgreso_NEW.Visible = false;
        }
        //8C4A371E-572D-4265-9A04-EC66F6A90A6D 1.9.1_MODIFICAR
        if (!window.existetoken("8C4A371E-572D-4265-9A04-EC66F6A90A6D"))
        {
            grdEgresoDetalles.Columns[11].Visible = false;
            grdEgresoDetalles.Columns[12].Visible = false;
            grdEgresoDetalles.Columns[13].Visible = false;
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

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddlInstitucion.SelectedValue) );
        DataView dv = new DataView(dtproy);
        dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(121, 122, 123, 124, 125, 126)";
        dv.Sort = "CodProyecto";
        ddlProyecto.DataSource = dv;
        ddlProyecto.DataTextField = "Nombre";
        ddlProyecto.DataValueField = "CodProyecto";
        ddlProyecto.DataBind();

    }
    private void GetObjetivos(int iVigente)
    {
        ObjetivosColl tObjetivosColl = new ObjetivosColl();
        DataView dv1 = new DataView(tObjetivosColl.GetObjetivos( iVigente));
        ddlObjetivo.DataSource = dv1;
        ddlObjetivo.DataTextField = "Descripcion";
        ddlObjetivo.DataValueField = "CodObjetivo";
        dv1.Sort = "CodObjetivo";
        ddlObjetivo.DataBind();
    }
    private void GetUsos(int iVigente)
    {
        UsosColl tUsosColl = new UsosColl();

        DataView dv1 = new DataView(tUsosColl.GetData( ddlObjetivo.SelectedValue, iVigente));
        ddlUso.DataSource = dv1;
        ddlUso.DataTextField = "Descripcion";
        ddlUso.DataValueField = "CodUso";
        dv1.Sort = "CodUso";
        ddlUso.DataBind();
    }
    private void GetMedioDePago(int iVigente)
    {
        MedioDePago tMedioDePagoColl = new MedioDePago();
        DataView dv1 = new DataView(tMedioDePagoColl.GetData( iVigente));
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
        // 17/12/2014
        // Juan Valenzuela M.
        //ddlFechaComprobante.Value       = grdEgresoDetalles.Rows[i].Cells[0].Text;
        txtFechaComprobante.Text = grdEgresoDetalles.Rows[i].Cells[0].Text;

        txtNumeroComprobante.Text = grdEgresoDetalles.Rows[i].Cells[1].Text;
        txtCorrelativo_NEW.Text             = grdEgresoDetalles.Rows[i].Cells[2].Text;
        GetObjetivos(2);
        ddlObjetivo.SelectedValue       = grdEgresoDetalles.Rows[i].Cells[14].Text;
        GetUsos(2);
        ddlUso.SelectedValue            = grdEgresoDetalles.Rows[i].Cells[15].Text;
        txtMonto_NEW.Text                  = grdEgresoDetalles.Rows[i].Cells[5].Text.Replace(".", "").Replace("-", "");
        GetMedioDePago(2);
        ddlMedioDePago.SelectedValue    = grdEgresoDetalles.Rows[i].Cells[16].Text;
        txtGlosa.Text                   = Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[7].Text.Trim());
        txtDestino.Text                 = Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[8].Text.Trim());
        txtNumeroDeCheque.Text          = Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[9].Text.Trim());
        if (chkNulo.Checked)
            rbAnular.SelectedValue = "1";
        else
            rbAnular.SelectedValue = "0";

        ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo);
        ValidaTipoDetalleEgreso(ddlUso, lblUso);
    }
    protected void ddlInstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProyectos();
    }
    
    private void HabilitaEgresos()
    {
        pnlDetail.Visible = true;
        btnGuardaEgreso_NEW.Visible = true;
        btnCancelaEgreso_NEW.Visible = true;
        btnEgreso_NEW.Visible = false;
        //btnImprimir_NEW.Enabled = false;
        //btnExcel_NEW.Enabled = false;

        // 17/12/2014
        // Juan Valenzuela M.
        //ddlFechaComprobante.Value = DateTime.Now;
        txtFechaComprobante.Text = Convert.ToString(DateTime.Now);

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

    //    // 17/12/2014
    //    // Juan Valenzuela M.
    //    //ddlFechaComprobante.ReadOnly = false;

    //    tblEditar.Rows[1].Visible = true;
    //    tblEditar.Rows[2].Visible = true;

    //}
    protected void HabilitaDeshabilitaHeaderFrame(Boolean Habilita)
    {
        ddlInstitucion.Enabled      = !Habilita;
        ddlProyecto.Enabled         = !Habilita;
        ddlMeses.Enabled            = !Habilita;
        // 15/12/2014
        // Juan Valenzuela M.
        // Se modifica mención a textbox txtAno y se cambia por txtAno_NEW
        //txtAno.Enabled = !Habilita;
        txtAno_NEW.Enabled = !Habilita;

        //ddlFechaRegistro.Enabled    = !Habilita;
        // 12/12/2014
        // Se modifica nombre de botones para utilizar los nuevos controles
        //btnBuscaRendicion.Visible   = !Habilita;
        //btnNuevo.Visible            = !Habilita;
        //btnEgreso.Visible           = Habilita;
        BtnBuscarEgresos.Visible = !Habilita;
        btnNuevoEgreso.Visible      = !Habilita;
        btnEgreso_NEW.Visible = Habilita;

        pnlBody.Visible             = Habilita;
        pnlSearch.Visible           = Habilita;
        btnImprimir_NEW.Visible         = Habilita;
        btnExcel_NEW.Visible            = Habilita;
    }
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
                lbl.Text = "No puede seleccionar un dato caducado";
            else
                lbl.Text = "Debe seleccionar un dato";

            ddl.Focus();
            return false;
        }
    }
    //protected void btnLimpiaBusqueda_Click(object sender, EventArgs e)
    //{
    //    LimpiaBusqueda();
    //}
    protected void LimpiaBusqueda()
    {
        txtInstitucion_NEW.Text     = "";
        txtCodProyecto_NEW.Text     = "";
        txtProyecto_NEW.Text        = "";
        txtTotal_NEW.Text = "0";
        txtAnoMes_NEW.Text          = "";
        lblInformacion.Visible      = false;
        dtEgresos.Rows.Clear();
        grdBuscador.DataSource  = "";
        grdBuscador.DataBind();
    }
    //protected void btnCancelarBusqueda_Click(object sender, EventArgs e)
    //{
    //    pnlSearch.Visible = false;
    //    pnlHeader.Visible = true;
    //    LimpiaBusqueda();
    //}
    //protected void btnBuscar_Click(object sender, EventArgs e)
    //{
    //    int iAnoMes;
    //    string strProyecto = "";

    //    if (txtCodProyecto_NEW.Text != "")
    //    {
    //        strProyecto = txtProyecto_NEW.Text.Trim();
    //        txtProyecto_NEW.Text = "";
    //    }


    //    if (txtAnoMes_NEW.Text.Trim() != "")
    //        iAnoMes = Convert.ToInt32(txtAnoMes_NEW.Text.Trim());
    //    else
    //        iAnoMes = 0;
    //    RendicionEgresoColl rE = new RendicionEgresoColl();
    //    dtEgresos.Rows.Clear();
    //    txtIdRendicionEgreso.Text = "";
    //    dtEgresos = rE.GetData(txtInstitucion_NEW.Text, txtCodProyecto_NEW.Text, txtProyecto_NEW.Text, iAnoMes , dtEgresos, 1, Convert.ToInt32(Session["IdUsuario"]));

    //    grdBuscador.DataSource = dtEgresos;
    //    grdBuscador.DataBind();
    //    txtProyecto_NEW.Text = strProyecto.Trim();
    //}
    protected void grdBuscador_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int i = e.NewEditIndex;
        int iSuma = 0;
        System.Web.UI.WebControls.CheckBox chkCerrado;

        txtIdRendicionEgreso.Text       = grdBuscador.Rows[i].Cells[0].Text;
        ddlInstitucion.SelectedValue    = grdBuscador.Rows[i].Cells[1].Text;
        GetProyectos();
        ddlProyecto.SelectedValue       = grdBuscador.Rows[i].Cells[3].Text;
        txtCodProyecto_NEW.Text = grdBuscador.Rows[i].Cells[3].Text;
        txtProyecto_NEW.Text = grdBuscador.Rows[i].Cells[4].Text;
        ddlMeses.SelectedValue          = Convert.ToInt16(grdBuscador.Rows[i].Cells[5].Text.Substring(4, 2)).ToString();
        // 15/12/2014
        // Juan Valenzuela M.
        // Se modifica mención a textbox txtAno y se cambia por txtAno_NEW
        //txtAno.Text = grdBuscador.Rows[i].Cells[5].Text.Substring(0, 4);
        txtAno_NEW.Text = grdBuscador.Rows[i].Cells[5].Text.Substring(0, 4);
        
        // 17/12/2014
        // Juan Valenzuela M.
        //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);

        // 17/12/2014
        // Juan Valenzuela M.
        //ddlFechaComprobante.MinDate     = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
        //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text);

        // 15/12/2014
        // Juan Valenzuela M.
        //ddlFechaRegistro.Value = grdBuscador.Rows[i].Cells[6].Text;
        txtFechaRegistro.Text = (Convert.ToDateTime(grdBuscador.Rows[i].Cells[6].Text).ToShortDateString());

        chkCerrado                      = (System.Web.UI.WebControls.CheckBox)grdBuscador.Rows[i].Cells[7].FindControl("chkCerrado");
        lblInformacion.Text = "La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios.";
        lblInformacion.Visible          = (chkCerrado.Checked.ToString().ToLower() == "true");
        
        int iAnoMes = Convert.ToInt32(grdBuscador.Rows[i].Cells[5].Text);

        RendicionEgresoColl ri = new RendicionEgresoColl();
        dtEgresos.Rows.Clear();
        dtEgresos = ri.GetData(txtInstitucion_NEW.Text, txtCodProyecto_NEW.Text, txtProyecto_NEW.Text, iAnoMes , dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));

        grdEgresoDetalles.DataSource = dtEgresos;
        HabilitaDeshabilitaHeaderFrame(dtEgresos.Rows.Count != 0);
        pnlHeader.Visible = true;
        pnlDetail.Visible = false;
        pnlBody.Visible = true;
        pnlSearch.Visible = false;
        //btnVolver_NEW.Visible = true;
        grdEgresoDetalles.DataBind();
        iSuma = SumaTotales(iSuma);
        // 17/12/2014
        // Juan Valenzuela M.
        // Se da formato al campo total.
        //txtTotal_NEW.Text = iTotal.ToString();
        txtTotal_NEW.Text = iSuma.ToString("N0", new System.Globalization.CultureInfo("es-ES"));
        /*------------------------------------------------*/

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
                iSuma = iSuma + Convert.ToInt32(row["Monto"]);

            x++;
            System.Web.UI.WebControls.CheckBox chkNulo;
            chkNulo = (System.Web.UI.WebControls.CheckBox)grdEgresoDetalles.Rows[x].Cells[10].FindControl("chkNulo");

            if (chkNulo.Checked)
                grdEgresoDetalles.Rows[x].BackColor = System.Drawing.Color.SandyBrown;
        }
        return iSuma;
    }
    
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

            // 17/12/2014
            // Juan Valenzuela M.
            //ddlFechaComprobante.Value = DateTime.Now;
            //ddlFechaComprobante.ReadOnly = true;
            txtFechaComprobante.ReadOnly = true;
            txtFechaComprobante.Text = Convert.ToString(DateTime.Now);
            /*------------------------------------------*/
            tblEditar.Rows[2].Visible = false;
        }
        if (e.CommandName.ToLower() == "eliminar")
        {
            int iCodProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
            int iAnoMes = Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
            int iNumeroComprobante = Convert.ToInt32(grdEgresoDetalles.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            int iCorrelativo = Convert.ToInt32(grdEgresoDetalles.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
            int iSuma = 0;

            RendicionEgresoColl rE = new RendicionEgresoColl();
            rE.Delete( iCodProyecto, iAnoMes, iNumeroComprobante, iCorrelativo);

            dtEgresos.Rows.Clear();
            dtEgresos = rE.GetData("", iCodProyecto.ToString(), "", iAnoMes , dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));

            grdEgresoDetalles.DataSource = dtEgresos;
            HabilitaDeshabilitaHeaderFrame(dtEgresos.Rows.Count != 0);
            pnlHeader.Visible = true;
            pnlDetail.Visible = false;
            pnlBody.Visible = true;
            pnlSearch.Visible = false;
            //btnVolver_NEW.Visible = true;
            btnImprimir_NEW.Visible = true;
            btnExcel_NEW.Visible = true;
            tblTotal.Visible = true;
            grdEgresoDetalles.DataBind();

            iSuma = SumaTotales(iSuma);
            // 17/12/2014
            // Juan Valenzuela M.
            // Se da formato al campo total.
            //txtTotal_NEW.Text = iTotal.ToString();
            txtTotal_NEW.Text = iSuma.ToString("N0", new System.Globalization.CultureInfo("es-ES"));
            /*------------------------------------------------*/

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
    //protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";     
    //    string cadena = string.Empty;

    //    cadena = @" window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Egresos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
    //protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Egresos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
    
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
                dr[6] = 0;
            else
                dr[6] = Convert.ToInt32(grdEgresoDetalles.Rows[i].Cells[5].Text.Replace(".", ""));
            dr[7] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[6].Text));
            dr[8] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[7].Text));
            dr[9] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[8].Text));
            dr[10] = Convert.ToString(Server.HtmlDecode(grdEgresoDetalles.Rows[i].Cells[9].Text));
            dr[11] = chkNulo.Checked;

            dtEgresosRPT.Rows.Add(dr);
        }
    }

    /*-----------------------------------------------------------------------------------------
    // 11/12/2014
    // Se agregan las siguientes VOID que reemplazarán a los originales que se encuentran 
    // asociados a Infragistics.
    // Se usa el mismo nombre de las VOID originales y se agrega el sufijo "NEW"
    // para su diferenciación.
    //-----------------------------------------------------------------------------------------
    //
    //-----------------------------------------------------------------------------------------
    // 11/12/2014
    // Juan Valenzuela.
    // Se agrega botón para buscar rendición.
    //-----------------------------------------------------------------------------------------*/
    protected void btnBuscaRendicion_Click_NEW(object sender, EventArgs e)
    {
        BuscaRendicion_NEW(sender, e, 0);
    }
    protected void BuscaRendicion_NEW(object sender, EventArgs e, int Busca)
    {
        pnlHeader.Visible = (Busca == 1);
        pnlBody.Visible = (Busca == 1);
        pnlSearch.Visible = (Busca == 0);

        if (Convert.ToUInt32(ddlInstitucion.SelectedValue) == 0)
            txtInstitucion_NEW.Text = "";
        else
            txtInstitucion_NEW.Text = ddlInstitucion.SelectedItem.Text;

        if (Convert.ToUInt32(ddlProyecto.SelectedValue) == 0)
        {
            txtCodProyecto_NEW.Text = "";
            txtProyecto_NEW.Text = "";
        }
        else
        {
            txtCodProyecto_NEW.Text = ddlProyecto.SelectedValue;
            txtProyecto_NEW.Text = ddlProyecto.SelectedItem.Text;
        }


        // 16/12/2014
        // Juan Valenzuela M.
        // Se cambia txtAno por txtAno_NEW
        //if (txtAno.RawText == "")
        //    txtAnoMes.Text = "";
        //else
        //    txtAnoMes.Text = Convert.ToString(Convert.ToInt16(txtAno.RawText) * 100 + Convert.ToInt16(ddlMeses.SelectedValue));

        if (txtAno_NEW.Text == "")
            txtAnoMes_NEW.Text = "";
        else
            txtAnoMes_NEW.Text = Convert.ToString(Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue));
        /*--------------------------------------------------------------------------*/

        btnBuscar_Click_NEW(sender, e);
    }
    protected void btnBuscar_Click_NEW(object sender, EventArgs e)
    {
        int iAnoMes;
        string strProyecto = "";

        if (txtCodProyecto_NEW.Text != "")
        {
            strProyecto = txtProyecto_NEW.Text.Trim();
            txtProyecto_NEW.Text = "";
        }


        if (txtAnoMes_NEW.Text.Trim() != "")
            iAnoMes = Convert.ToInt32(txtAnoMes_NEW.Text.Trim());
        else
            iAnoMes = 0;
        RendicionEgresoColl rE = new RendicionEgresoColl();
        dtEgresos.Rows.Clear();
        txtIdRendicionEgreso.Text = "";
        dtEgresos = rE.GetData(txtInstitucion_NEW.Text, txtCodProyecto_NEW.Text, txtProyecto_NEW.Text, iAnoMes , dtEgresos, 1, Convert.ToInt32(Session["IdUsuario"]));

        grdBuscador.DataSource = dtEgresos;
        grdBuscador.DataBind();
        txtProyecto_NEW.Text = strProyecto.Trim();
    }

    /*-----------------------------------------------------------------------------------------
    // 12/12/2014
    // Juan Valenzuela.
    // Se agrega botón para insertar nueva rendición.
    //-----------------------------------------------------------------------------------------*/
    protected void btnNuevo_Click_NEW(object sender, EventArgs e)
    {
        //MuestraMensaje lblInformacion_NEW = new MuestraMensaje();


        ObjetoTexto txtobjeto = new ObjetoTexto();
        int valortexto;
        bool Convertido = Int32.TryParse(txtAno_NEW.Text, out valortexto);


        // 16/12/2014
        // Juan Valenzuela M.
        // Se pospone el uso de la Clase para la siguiente etapa.
        //------------------------------------------------------------
        //txtobjeto.CajaDeTexto = txtAno_NEW;
        //if (false == Convertido)
        //{
        //    txtobjeto.ResaltaFondo();
        //    txtAno_NEW = txtobjeto.CajaDeTexto;
        //    lblInformacion.Text = "Debe ingresar números";
        //    lblInformacion.Visible = true;
        //}
        //else
        //{
        //    txtobjeto.ApagaFondo();
        //    txtAno_NEW = txtobjeto.CajaDeTexto;
        //    txtAno_NEW.Text = string.Format("{0:#,##0.00}", txtAno_NEW.Text);
        //}
        //------------------------------------------------------------


        if (ddlMeses.SelectedValue == "0")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar el mes del Egreso de Cuentas";
            ddlMeses.Focus();
            return;
        }
        //if (txtAno.RawText.Length != 4 || txtAno.RawText.Trim() == "")
        if ((txtAno_NEW.Text.Length)!=4 || txtAno_NEW.Text.Trim() =="")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text="Debe Ingresar el año del registro de Egreso";
            //txtAno.Focus();
            txtAno_NEW.Focus();
            return;
        }
        else
        {
            // ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
            // ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);

            // 18/12/2014
            // Juan Valenzuela M.
            //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text);
            //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text);
            //ddlFechaComprobante.Value = ddlFechaComprobante.MinDate;
            txtFechaComprobante.Text = "01-" + ddlMeses.SelectedItem + "-" + txtAno_NEW.Text;
        }

        if (Convert.ToInt32(ddlInstitucion.SelectedValue) == 0 || Convert.ToInt32(ddlProyecto.SelectedValue) == 0)
        {
            lblInformacion.Visible = true;
            lblInformacion.Text="Debe seleccionar una Institución y un Proyecto";
            ddlInstitucion.Focus();
            return;
        }
        // 17/12/2014
        // Juan Valenzuela M.
        //if (ddlFechaRegistro.Text.Trim() == "")
        if (txtFechaRegistro.Text.Trim() == "")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text="Debe Ingresar la fecha de Registro";
            // 17/12/2014
            // Juan Valenzuela M.
            //ddlFechaRegistro.Focus();
            txtFechaRegistro.Focus();
            return;
        }
        //if (Convert.ToInt32(txtAno.Text) > DateTime.Now.Year ||
        //    (Convert.ToInt32(txtAno.Text) == DateTime.Now.Year &&
        //    Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
        if (Convert.ToInt32(txtAno_NEW.Text) > DateTime.Now.Year ||
            (Convert.ToInt32(txtAno_NEW.Text) == DateTime.Now.Year &&
            Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
        {
            lblInformacion.Visible = true;
            lblInformacion.Text="No puede crear Egresos de meses futuros";
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
        //btnVolver_NEW.Visible = true;
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


    //protected void btnVolver_Click_NEW(object sender, EventArgs e)
    //{
    //    btnCancelarNEW_Click(sender, e);
    //    Response.Redirect("rendicion_cuentas.aspx");
    //}

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
        // 18/12/2014
        // Juan Valenzuela M.
        //ddlFechaComprobante.ReadOnly = false;
        txtFechaComprobante.ReadOnly = false;

        tblEditar.Rows[1].Visible = true;
        tblEditar.Rows[2].Visible = true;
    
    }
    protected void btnGuardaIngresoNEW_Click(object sender, EventArgs e)
    {
        if (ValidaTipoDetalleEgreso(ddlObjetivo, lblObjetivo) && ValidaTipoDetalleEgreso(ddlUso, lblUso) && ValidaTipoDetalleEgreso(ddlMedioDePago, lblMedioPago))
        {
            int iIdRendicionEgreso = 0;
            int iAnoMes;
            int iNumeroComprobante = 0;
            int iCorrelativo = 0;
            int iNulo = 0;
            int iCodProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
            int iMonto = 0;
            int iTotal = 0;
            int iCodUso = Convert.ToInt32(ddlUso.SelectedValue);
            int iCodMedioDePago = Convert.ToInt32(ddlMedioDePago.SelectedValue);

            // 17/12/2014
            // Juan Valenzuela M.
            //DateTime dFechaRegistro = Convert.ToDateTime(ddlFechaRegistro.Value);
            DateTime dFechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text);

            if (txtIdRendicionEgreso.Text.Trim() != "") iIdRendicionEgreso = Convert.ToInt32(txtIdRendicionEgreso.Text);
            if (txtNumeroComprobante.Text.Trim() != "") iNumeroComprobante = Convert.ToInt32(txtNumeroComprobante.Text);
            if (txtCorrelativo_NEW.Text.Trim() != "") iCorrelativo = Convert.ToInt32(txtCorrelativo_NEW.Text);
            if (ddlObjetivo.SelectedValue.Trim() == "10") iMonto = iMonto * -1;
            if (rbAnular.SelectedValue != "0") iNulo = 1;

            iMonto = Convert.ToInt32(txtMonto_NEW.Text);
            if (iMonto == 0)
            {
                lblMonto.Visible = true;
                lblMonto.Text = "El monto del Egreso debe ser distinto de cero";
                txtMonto_NEW.Focus();
                return;
            }
            else
                lblMonto.Text = "";

            iAnoMes = Convert.ToInt16(txtAno_NEW.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);

            if (ddlObjetivo.SelectedValue == "10")
                iMonto *= -1;

            RendicionEgresoColl rI = new RendicionEgresoColl();
            //rI.InsertUpdate( iIdRendicionEgreso, iNumeroComprobante, iCorrelativo, iCodUso, Convert.ToDateTime(ddlFechaComprobante.Text), iCodMedioDePago, iMonto, txtNumeroDeCheque.Text.ToUpper(), txtGlosa.Text.ToUpper(), txtDestino.Text.ToUpper(), iNulo, 1, iCodProyecto, iAnoMes, dFechaRegistro);

            // 18/12/2014
            // Juan Valenzuela M.
            //rI.InsertUpdate( iIdRendicionEgreso, iNumeroComprobante, iCorrelativo, iCodUso, Convert.ToDateTime(ddlFechaComprobante.Text), iCodMedioDePago, iMonto, txtNumeroDeCheque.Text.ToUpper(), txtGlosa.Text.ToUpper(), txtDestino.Text.ToUpper(), iNulo, Convert.ToInt32(Session["IdUsuario"]), iCodProyecto, iAnoMes, dFechaRegistro);
            rI.InsertUpdate( iIdRendicionEgreso, iNumeroComprobante, iCorrelativo, iCodUso, Convert.ToDateTime( txtFechaComprobante.Text), iCodMedioDePago, iMonto, txtNumeroDeCheque.Text.ToUpper(), txtGlosa.Text.ToUpper(), txtDestino.Text.ToUpper(), iNulo, Convert.ToInt32(Session["IdUsuario"]), iCodProyecto, iAnoMes, dFechaRegistro);

            GetEgresosGr();
            dtEgresos = rI.GetData("", ddlProyecto.SelectedValue, "", iAnoMes , dtEgresos, 0, Convert.ToInt32(Session["IdUsuario"]));
            grdEgresoDetalles.DataSource = dtEgresos;
            grdEgresoDetalles.DataBind();
            txtIdRendicionEgreso.Text = dtEgresos.Rows[0]["IdRendicionEgreso"].ToString();
            iTotal = SumaTotales(iTotal);
            // 17/12/2014
            // Juan Valenzuela M.
            // Se da formato al campo total.
            //txtTotal_NEW.Text = iTotal.ToString();
            txtTotal_NEW.Text = iTotal.ToString("N0", new System.Globalization.CultureInfo("es-ES"));
            /*------------------------------------------------*/
            tblTotal.Visible = true;
            btnCancelaEgreso_Click_NEW(sender, e);
        }
    }

    protected void btnBuscar_NEW_Click(object sender, EventArgs e)
    {
        int iAnoMes;
        string strProyecto = "";

        if (txtCodProyecto_NEW.Text != "")
        {
            strProyecto = txtProyecto_NEW.Text.Trim();
            txtProyecto_NEW.Text = "";
        }


        if (txtAnoMes_NEW.Text.Trim() != "")
            iAnoMes = Convert.ToInt32(txtAnoMes_NEW.Text.Trim());
        else
            iAnoMes = 0;
        RendicionEgresoColl rE = new RendicionEgresoColl();
        dtEgresos.Rows.Clear();
        txtIdRendicionEgreso.Text = "";
        dtEgresos = rE.GetData(txtInstitucion_NEW.Text, txtCodProyecto_NEW.Text, txtProyecto_NEW.Text, iAnoMes , dtEgresos, 1, Convert.ToInt32(Session["IdUsuario"]));

        grdBuscador.DataSource = dtEgresos;
        grdBuscador.DataBind();
        txtProyecto_NEW.Text = strProyecto.Trim();

    }
    protected void btnLimpiaBusqueda_NEW_Click(object sender, EventArgs e)
    {
        LimpiaBusqueda();
    }
    protected void btnCancelarBusqueda_NEW_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlHeader.Visible = true;
        LimpiaBusqueda();
    }
    protected void btnImprimir_NEW_Click(object sender, EventArgs e)
    {
        PreparaReporte();
        string cadena = string.Empty;

        cadena = @"window.open(this.Page,'Reg_Reportes.aspx?Impresora_Excel=1" + "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Proyecto=" + txtProyecto_NEW.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno_NEW.Text + "&param001=5', 'Reportes', false, true, '800', '600', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnExcel_NEW_Click(object sender, EventArgs e)
    {
        PreparaReporte();
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'Reg_Reportes.aspx?Impresora_Excel=2" + "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Proyecto=" + txtProyecto_NEW.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno_NEW.Text + "&param001=5', 'Reportes', false, true, '800', '600', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void txtAno_NEW_TextChanged(object sender, EventArgs e)
    {
        ObjetoTexto txtobjeto  = new ObjetoTexto();
        int valortexto;
        bool Convertido = Int32.TryParse(txtAno_NEW.Text, out valortexto);

        txtobjeto.CajaDeTexto = txtAno_NEW;
        if (false == Convertido)
        {
            txtobjeto.ResaltaFondo();
            txtAno_NEW=txtobjeto.CajaDeTexto;
            lblInformacion.Text="Debe ingresar números";
            lblInformacion.Visible = true;
        }
        else
        {
            txtobjeto.ApagaFondo();
            txtAno_NEW=txtobjeto.CajaDeTexto;
            txtAno_NEW.Text = string.Format("{0:#,##0.00}", txtAno_NEW.Text);
            //lblInformacion.Text = "La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios.";

        }
        
    }
    
    protected void txtMonto_NEW_TextChanged(object sender, EventArgs e)
    {
        //int monto = Convert.ToInt32(txtMonto_NEW.Text);
        //txtMonto_NEW.Text = monto.ToString("N0",new System.Globalization.CultureInfo("es-ES"));
    }
    protected void imbBuscaRendicion_Click_NEW(object sender, ImageClickEventArgs e)
    {
        btnBuscaRendicion_Click_NEW(sender, e);
    }
    protected void imbCancelarNEW_Click(object sender, ImageClickEventArgs e)
    {
        btnCancelarNEW_Click(sender, e);
    }

    //protected void imbVolver_Click_NEW(object sender, ImageClickEventArgs e)
    //{
    //    btnVolver_Click_NEW(sender, e);
    //}

    protected void imbNuevo_Click_NEW(object sender, ImageClickEventArgs e)
    {
        btnNuevo_Click_NEW(sender, e);
    }
}
