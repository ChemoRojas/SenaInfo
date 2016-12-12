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

public partial class mod_instituciones_Reg_Ingresos : System.Web.UI.Page
{
    public DataTable dtIngresos
    {
        get { return (DataTable)Session["dtIngresos"]; }
        set { Session["dtIngresos"] = value; }
    }
    public DataTable dtIngresosRPT
    {
        get { return (DataTable)Session["dtIngresosRPT"]; }
        set { Session["dtIngresosRPT"] = value; }
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
                if (!window.existetoken("F5E94FD8-7C0D-475C-81AB-D30159E5C8FE"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                

                ddlFechaRegistro.Text = DateTime.Now.ToShortDateString();
                txtAno.Text = DateTime.Now.Year.ToString();
                GetInstituciones();
                GetProyectos();
                GetTipoIngreso(2);
                GetDetalleIngreso(2);
                GetIngresosGr();


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
                }
                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }
       
    }
    private void validatescurity()
    {
        //BF6CD5DC-CA02-44D3-A8AF-06B19026044F 1.9.2_INGRESAR
        if (!window.existetoken("BF6CD5DC-CA02-44D3-A8AF-06B19026044F"))
        {
            btnNuevo.Visible = false;
            btnIngreso.Visible = false;
        }
        //4C50B363-077F-48ED-83D4-789EEFC5BD45 1.9.2_MODIFICAR
        if (!window.existetoken("4C50B363-077F-48ED-83D4-789EEFC5BD45"))
        {
            grdIngresoDetalles.Columns[8].Visible = false;
            grdIngresoDetalles.Columns[9].Visible = false;
            grdIngresoDetalles.Columns[10].Visible = false;
        }
       
    }
    private void GetInstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddlInstitucion.DataSource = dv1;
        ddlInstitucion.DataTextField = "Nombre";
        ddlInstitucion.DataValueField = "CodInstitucion";
        dv1.Tables[0].DefaultView.Sort = "Nombre";
        ddlInstitucion.DataBind();
    }
    private void GetProyectos()
    {
        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddlInstitucion.SelectedValue));
        DataSet dv = new DataSet();
        dv.Tables.Add(dtproy);
        dv.Tables[0].DefaultView.RowFilter = "isnull(CodModeloIntervencion, 0) not in(121, 122, 123, 124, 125, 126)";
        dv.Tables[0].DefaultView.Sort = "CodProyecto";
        ddlProyecto.DataSource = dv;
        ddlProyecto.DataTextField = "Nombre";
        ddlProyecto.DataValueField = "CodProyecto";
        ddlProyecto.DataBind();

    }
    private void GetTipoIngreso(int iVigente)
    {
        TipoIngresoColl tIColl = new TipoIngresoColl();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(tIColl.GetData(iVigente));
        ddlTipoIngreso.DataSource = dv1;
        ddlTipoIngreso.DataTextField = "Descripcion";
        ddlTipoIngreso.DataValueField = "CodTipoIngreso";
        dv1.Tables[0].DefaultView.Sort = "CodTipoIngreso";
        ddlTipoIngreso.DataBind();
    }
    private void GetDetalleIngreso(int iVigente)
    {
        DetalleIngresoColl tDColl = new DetalleIngresoColl();

        DataSet dv1 = new DataSet();
        dv1.Tables.Add(tDColl.GetData(ddlTipoIngreso.SelectedValue, iVigente));
        ddlDetalleIngreso.DataSource = dv1;
        ddlDetalleIngreso.DataTextField = "Descripcion";
        ddlDetalleIngreso.DataValueField = "CodDetalleIngreso";
        dv1.Tables[0].DefaultView.Sort = "CodDetalleIngreso";
        ddlDetalleIngreso.DataBind();
    }

    protected void grdIgresoDetalles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        EditaRegistro(sender, e.NewEditIndex);
    }
    protected void EditaRegistro(object sender, int i)
    {
        //int i = e.NewEditIndex;
        System.Web.UI.WebControls.CheckBox chkNulo;

        chkNulo = (System.Web.UI.WebControls.CheckBox)grdIngresoDetalles.Rows[i].Cells[7].FindControl("chkNulo");
        if (chkNulo.Checked)
            return;

        HabilitaIngresos();
        ddlFechaComprobante.Text = grdIngresoDetalles.Rows[i].Cells[0].Text;
        txtNumeroComprobante.Text = grdIngresoDetalles.Rows[i].Cells[1].Text;
        txtCorrelativo.Text = grdIngresoDetalles.Rows[i].Cells[2].Text;
        GetTipoIngreso(2);
        ddlTipoIngreso.SelectedValue = grdIngresoDetalles.Rows[i].Cells[11].Text;
        GetDetalleIngreso(2);
        ddlDetalleIngreso.SelectedValue = grdIngresoDetalles.Rows[i].Cells[12].Text;
        txtMonto.Text = grdIngresoDetalles.Rows[i].Cells[5].Text.Replace(".", "");

        txtGlosa.Text = Server.HtmlDecode(grdIngresoDetalles.Rows[i].Cells[6].Text.Trim());
        if (chkNulo.Checked)
            rbAnular.SelectedValue = "1";
        else
            rbAnular.SelectedValue = "0";

        ValidaTipoDetalleIngreso(ddlTipoIngreso, lblTipoIngreso);
        ValidaTipoDetalleIngreso(ddlDetalleIngreso, lblDetalleIngreso);
    }
    protected void ddlInstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProyectos();
    }
    protected void ddlTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleIngreso(ddlTipoIngreso, lblTipoIngreso);
        GetDetalleIngreso(1);
    }
   

    private void HabilitaIngresos()
    {
        pnlDetail.Visible = true;
        btnGuardaIngreso.Visible = true;
        btnCancelaIngreso.Visible = true;
        btnIngreso.Visible = false;
        ddlFechaComprobante.Text = Convert.ToDateTime("01-" + ddlMeses.SelectedValue + "-" + txtAno.Text).ToShortDateString();
        txtNumeroComprobante.Text = "";
        txtCorrelativo.Text = "";
        txtMonto.Text = "0";
        txtGlosa.Text = "";
        rbAnular.SelectedValue = "0";
        ddlTipoIngreso.SelectedValue = "0";
        ddlDetalleIngreso.SelectedValue = "0";
    }
    
    protected void HabilitaDeshabilitaHeaderFrame(Boolean Habilita)
    {
        ddlInstitucion.Enabled = !Habilita;
        ddlProyecto.Enabled = !Habilita;
        ddlMeses.Enabled = !Habilita;
        txtAno.Enabled = !Habilita;
        ddlFechaRegistro.Enabled = !Habilita;
        btnBuscaRendicion.Visible = !Habilita;
        btnNuevo.Visible = !Habilita;
        //btnBuscaInstitucion.Enabled = !Habilita;
        lbn_buscar_institucion.Enabled = !Habilita;
        //btnBuscaProyecto.Enabled = !Habilita;
        lbn_buscar_proyecto.Enabled = !Habilita;

        pnlBody.Visible = Habilita;
        pnlSearch.Visible = Habilita;
        btnIngreso.Visible = Habilita;
    }
    protected void ddlDetalleIngreso_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidaTipoDetalleIngreso(ddlDetalleIngreso, lblDetalleIngreso);
    }
    protected Boolean ValidaTipoDetalleIngreso(System.Web.UI.WebControls.DropDownList ddl, System.Web.UI.WebControls.Label lbl)
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
 
    protected void LimpiaBusqueda()
    {
        txtInstitucion.Text = "";
        txtCodProyecto.Text = "";
        txtProyecto.Text = "";
        txtTotal.Text = "0";
        txtAnoMes.Text = "";
        lblInformacion.Visible = false;
        dtIngresos.Rows.Clear();
        grdBuscador.DataSource = "";
        grdBuscador.DataBind();
    }


    protected void grdBuscador_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int i = e.NewEditIndex;
        int iSuma = 0;
        System.Web.UI.WebControls.CheckBox chkCerrado;

        txtIdRendicionIngreso.Text = grdBuscador.Rows[i].Cells[0].Text;
        ddlInstitucion.SelectedValue = grdBuscador.Rows[i].Cells[1].Text;
        GetProyectos();
        ddlProyecto.SelectedValue = grdBuscador.Rows[i].Cells[3].Text;
        txtProyecto.Text = grdBuscador.Rows[i].Cells[4].Text;
        txtCodProyecto.Text = grdBuscador.Rows[i].Cells[3].Text;
        ddlMeses.SelectedValue = Convert.ToInt16(grdBuscador.Rows[i].Cells[5].Text.Substring(4, 2)).ToString();
        txtAno.Text = grdBuscador.Rows[i].Cells[5].Text.Substring(0, 4);
        ddlFechaRegistro.Text = grdBuscador.Rows[i].Cells[6].Text;
        //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
        //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
        //CalendarExtender1.EndDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text); JLBL
        //CalendarExtender1.StartDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text); JLBL

        chkCerrado = (System.Web.UI.WebControls.CheckBox)grdBuscador.Rows[i].Cells[7].FindControl("chkCerrado");
        lblInformacion.Text = "La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios.";
        lblInformacion.Visible = (chkCerrado.Checked.ToString().ToLower() == "true");
        int iAnoMes = Convert.ToInt32(grdBuscador.Rows[i].Cells[5].Text);

        RendicionIngresoColl ri = new RendicionIngresoColl();
        dtIngresos.Rows.Clear();
        dtIngresos = ri.GetData(txtInstitucion.Text, txtCodProyecto.Text, txtProyecto.Text, iAnoMes, dtIngresos, 0, Convert.ToInt32(Session["IdUsuario"]));

        grdIngresoDetalles.DataSource = dtIngresos;
        HabilitaDeshabilitaHeaderFrame(dtIngresos.Rows.Count != 0);
        pnlHeader.Visible = true;
        pnlDetail.Visible = false;
        pnlBody.Visible = true;
        pnlSearch.Visible = false;
        btnCancelar.Visible = true;
        btnImprimir.Visible = true;
        btnExcel.Visible = true;
        tblTotal.Visible = true;
        grdIngresoDetalles.DataBind();

        iSuma = SumaTotales(iSuma);
        txtTotal.Text = iSuma.ToString();

        grdIngresoDetalles.Columns[8].Visible = (!lblInformacion.Visible);
        grdIngresoDetalles.Columns[9].Visible = (!lblInformacion.Visible);
        grdIngresoDetalles.Columns[10].Visible = (!lblInformacion.Visible);
        btnIngreso.Visible = (!lblInformacion.Visible);

        validatescurity();
    }
    protected int SumaTotales(int iSuma)
    {
        int x = -1;
        foreach (DataRow row in dtIngresos.Rows)
        {
            if (row["Nulo"].ToString().ToLower() == "false")
                iSuma = iSuma + Convert.ToInt32(row["Monto"]);

            x++;
            System.Web.UI.WebControls.CheckBox chkNulo;
            chkNulo = (System.Web.UI.WebControls.CheckBox)grdIngresoDetalles.Rows[x].Cells[7].FindControl("chkNulo");

            if (chkNulo.Checked)
                grdIngresoDetalles.Rows[x].BackColor = System.Drawing.Color.SandyBrown;
        }
        return iSuma;
    }

    //protected void btnNuevo_Click(object sender, EventArgs e)
    //{
    //    if (ddlMeses.SelectedValue == "0")
    //    {
    //        lblInformacion.Visible = true;
    //        lblInformacion.Text = "Debe seleccionar el mes del Ingreso de Cuentas";
    //        ddlMeses.Focus();
    //        return;
    //    }
    //    if (txtAno.RawText.Length != 4 || txtAno.RawText.Trim() == "")
    //    {
    //        lblInformacion.Visible = true;
    //        lblInformacion.Text = "Debe Ingresar el año del registro de Ingreso";
    //        txtAno.Focus();
    //        return;
    //    }
    //    else
    //    {
    //        ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
    //        ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
    //        ddlFechaComprobante.Value = ddlFechaComprobante.MinDate;
    //    }

    //    if (Convert.ToInt32(ddlInstitucion.SelectedValue) == 0 || Convert.ToInt32(ddlProyecto.SelectedValue) == 0)
    //    {
    //        lblInformacion.Visible = true;
    //        lblInformacion.Text = "Debe seleccionar una Institución y un Proyecto";
    //        ddlInstitucion.Focus();
    //        return;
    //    }
    //    if (ddlFechaRegistro.Text.Trim() == "")
    //    {
    //        lblInformacion.Visible = true;
    //        lblInformacion.Text = "Debe Ingresar la fecha de Registro";
    //        ddlFechaRegistro.Focus();
    //        return;
    //    }

    //    if (Convert.ToInt32(txtAno.Text) > DateTime.Now.Year ||
    //        (Convert.ToInt32(txtAno.Text) == DateTime.Now.Year &&
    //        Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
    //    {
    //        lblInformacion.Visible = true;
    //        lblInformacion.Text = "No puede crear Ingresos de meses futuros";
    //        return;
    //    }
    //    BuscaRendicion(sender, e, 1);
    //    HabilitaDeshabilitaHeaderFrame(dtIngresos.Rows.Count == 0);
    //    lblInformacion.Visible = (dtIngresos.Rows.Count != 0);
    //    tblTotal.Visible = (dtIngresos.Rows.Count != 0);
    //    btnIngreso_Click(sender, e);
    //    btnIngreso.Visible = false;
    //    btnCancelar.Visible = true;
    //    lblInformacion.Text = "Ya existe una rendición registrada para el proyecto y periodo indicado";
    //    pnlSearch.Visible = false;
    //}
    protected DateTime FechaMaxima(string strFecha)
    { 
        DateTime dFecha = Convert.ToDateTime(strFecha);
        dFecha = dFecha.AddMonths(1);
        dFecha = dFecha.AddDays(-1);
        return dFecha;
    }

    protected void BuscaRendicion(object sender, EventArgs e, int Busca)
    {
        pnlHeader.Visible = (Busca == 1);
        pnlBody.Visible = (Busca == 1);
        pnlSearch.Visible = (Busca == 0);

        if (Convert.ToUInt32(ddlInstitucion.SelectedValue) == 0)
            txtInstitucion.Text = "";
        else
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

        btnBuscar_Click(sender, e);
    }
    protected void grdIgresoDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.ToLower() == "correlativo")
        {
            int i = Convert.ToInt32(e.CommandArgument);
            EditaRegistro(sender, i);
            txtCorrelativo.Text = "";
            txtMonto.Text = "";
            txtGlosa.Text = "";
            rbAnular.SelectedValue = "0";
            ddlFechaComprobante.Text = DateTime.Now.ToShortDateString();
            ddlFechaComprobante.ReadOnly = true;
            tblEditar.Rows[2].Visible = false;
        }

        if (e.CommandName.ToLower() == "eliminar")
        {
            int iCodProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
            int iAnoMes = Convert.ToInt16(txtAno.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
            int iNumeroComprobante = Convert.ToInt32(grdIngresoDetalles.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            int iCorrelativo = Convert.ToInt32(grdIngresoDetalles.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
            int iSuma = 0;

            RendicionIngresoColl rI = new RendicionIngresoColl();
            rI.Delete(iCodProyecto, iAnoMes, iNumeroComprobante, iCorrelativo);

            dtIngresos.Rows.Clear();
            dtIngresos = rI.GetData("", iCodProyecto.ToString(), "", iAnoMes, dtIngresos, 0, Convert.ToInt32(Session["IdUsuario"]));

            grdIngresoDetalles.DataSource = dtIngresos;
            HabilitaDeshabilitaHeaderFrame(dtIngresos.Rows.Count != 0);
            pnlHeader.Visible = true;
            pnlDetail.Visible = false;
            pnlBody.Visible = true;
            pnlSearch.Visible = false;
            btnCancelar.Visible = true;
            btnImprimir.Visible = true;
            btnExcel.Visible = true;
            tblTotal.Visible = true;
            grdIngresoDetalles.DataBind();

            iSuma = SumaTotales(iSuma);
            txtTotal.Text = iSuma.ToString();

            grdIngresoDetalles.Columns[8].Visible = (!lblInformacion.Visible);
            grdIngresoDetalles.Columns[9].Visible = (!lblInformacion.Visible);
            grdIngresoDetalles.Columns[10].Visible = (!lblInformacion.Visible);
            btnIngreso.Visible = (!lblInformacion.Visible);

            validatescurity();
        }
    }

    //protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Ingresos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}

    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=Reg_Ingresos.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

    
    private void PreparaReporte()
    {
        System.Web.UI.WebControls.CheckBox chkNulo;
        dtIngresosRPT = new DataTable();

        dtIngresosRPT.Columns.Add(new DataColumn("FechaComprobante", typeof(DateTime)));
        dtIngresosRPT.Columns.Add(new DataColumn("NroComprobante", typeof(int)));
        dtIngresosRPT.Columns.Add(new DataColumn("Correlativo", typeof(int)));
        dtIngresosRPT.Columns.Add(new DataColumn("TipoIngreso", typeof(string)));
        dtIngresosRPT.Columns.Add(new DataColumn("DetalleIngreso", typeof(string)));
        dtIngresosRPT.Columns.Add(new DataColumn("Monto", typeof(int)));
        dtIngresosRPT.Columns.Add(new DataColumn("MontoNoNulo", typeof(int)));
        dtIngresosRPT.Columns.Add(new DataColumn("Glosa", typeof(string)));
        dtIngresosRPT.Columns.Add(new DataColumn("Nulo", typeof(Boolean)));

        DataRow dr;
        for (int i = 0; i < grdIngresoDetalles.Rows.Count; i++)
        {
            chkNulo = (System.Web.UI.WebControls.CheckBox)grdIngresoDetalles.Rows[i].Cells[7].FindControl("chkNulo");

            dr = dtIngresosRPT.NewRow();
            dr[0] = Convert.ToDateTime(grdIngresoDetalles.Rows[i].Cells[0].Text);
            dr[1] = Convert.ToInt32(grdIngresoDetalles.Rows[i].Cells[1].Text);
            dr[2] = Convert.ToInt32(grdIngresoDetalles.Rows[i].Cells[2].Text);
            dr[3] = Convert.ToString(Server.HtmlDecode(grdIngresoDetalles.Rows[i].Cells[3].Text));
            dr[4] = Convert.ToString(Server.HtmlDecode(grdIngresoDetalles.Rows[i].Cells[4].Text));
            dr[5] = Convert.ToInt32(grdIngresoDetalles.Rows[i].Cells[5].Text.Replace(".", ""));
            if (chkNulo.Checked)
                dr[6] = 0;
            else
                dr[6] = Convert.ToInt32(grdIngresoDetalles.Rows[i].Cells[5].Text.Replace(".", ""));
            dr[7] = Convert.ToString(Server.HtmlDecode(grdIngresoDetalles.Rows[i].Cells[6].Text));
            dr[8] = chkNulo.Checked;

            dtIngresosRPT.Rows.Add(dr);
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        if (ddlMeses.SelectedValue == "0")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar el mes del Ingreso de Cuentas";
            ddlMeses.Focus();
            return;
        }
        if (txtAno.Text.Length != 4 || txtAno.Text.Trim() == "")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe Ingresar el año del registro de Ingreso";
            txtAno.Focus();
            return;
        }
        else
        {
            //ddlFechaComprobante.MaxDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
            //ddlFechaComprobante.MinDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text);
            //ddlFechaComprobante.Value = ddlFechaComprobante.MinDate;

            //CalendarExtender1.StartDate = Convert.ToDateTime("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text); JLBL
            //CalendarExtender1.EndDate = FechaMaxima("01-" + ddlMeses.SelectedItem + "-" + txtAno.Text); JLBL
            //ddlFechaComprobante.Text = CalendarExtender1.StartDate.ToString(); JLBL
            ddlFechaComprobante.Text = "01-01-1900";
        }

        if (Convert.ToInt32(ddlInstitucion.SelectedValue) == 0 || Convert.ToInt32(ddlProyecto.SelectedValue) == 0)
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe seleccionar una Institución y un Proyecto";
            ddlInstitucion.Focus();
            return;
        }
        if (ddlFechaRegistro.Text.Trim() == "")
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "Debe Ingresar la fecha de Registro";
            ddlFechaRegistro.Focus();
            return;
        }

        if (Convert.ToInt32(txtAno.Text) > DateTime.Now.Year ||
            (Convert.ToInt32(txtAno.Text) == DateTime.Now.Year &&
            Convert.ToInt32(ddlMeses.SelectedValue) > DateTime.Now.Month))
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = "No puede crear Ingresos de meses futuros";
            return;
        }
        BuscaRendicion(sender, e, 1);
        HabilitaDeshabilitaHeaderFrame(dtIngresos.Rows.Count == 0);
        lblInformacion.Visible = (dtIngresos.Rows.Count != 0);
        tblTotal.Visible = (dtIngresos.Rows.Count != 0);
        btnIngreso_Click(sender, e);
        btnIngreso.Visible = false;
        btnCancelar.Visible = true;
        lblInformacion.Text = "Ya existe una rendición registrada para el proyecto y periodo indicado";
        pnlSearch.Visible = false;
        pnlBody.Visible = true;
    }
    protected void btnBuscaRendicion_Click(object sender, EventArgs e)
    {
        BuscaRendicion(sender, e, 0);
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        HabilitaDeshabilitaHeaderFrame(false);
        LimpiaBusqueda();
        dtIngresos.Rows.Clear();
        grdBuscador.DataSource = "";
        grdBuscador.DataBind();
        grdIngresoDetalles.DataSource = "";
        grdIngresoDetalles.DataBind();
        lblInformacion.Visible = false;
        btnCancelar.Visible = false;
        btnImprimir.Visible = false;
        btnExcel.Visible = false;
        validatescurity();
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        btnCancelar_Click(sender, e);
        Response.Redirect("rendicion_cuentas.aspx");
    }
    protected void btnGuardaIngreso_Click(object sender, EventArgs e)
    {
        if (ValidaTipoDetalleIngreso(ddlTipoIngreso, lblTipoIngreso) && ValidaTipoDetalleIngreso(ddlDetalleIngreso, lblDetalleIngreso))
        {
            int iIdRendicionIngreso = 0;
            int iAnoMes;
            int iNumeroComprobante = 0;
            int iCorrelativo = 0;
            int iNulo = 0;
            int iCodProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
            int iMonto = 0;
            int iTotal = 0;
            DateTime dFechaRegistro = Convert.ToDateTime(ddlFechaRegistro.Text);



            if (txtIdRendicionIngreso.Text.Trim() != "") iIdRendicionIngreso = Convert.ToInt32(txtIdRendicionIngreso.Text);
            if (txtNumeroComprobante.Text.Trim() != "") iNumeroComprobante = Convert.ToInt32(txtNumeroComprobante.Text);
            if (txtCorrelativo.Text.Trim() != "") iCorrelativo = Convert.ToInt32(txtCorrelativo.Text);
            if (rbAnular.SelectedValue != "0") iNulo = 1;

            iMonto = Convert.ToInt32(txtMonto.Text);
            if (iMonto == 0)
            {
                lblMonto.Visible = true;
                lblMonto.Text = "El monto de Ingreso debe ser distinto de cero";
                txtMonto.Focus();
                return;
            }
            else
                lblMonto.Text = "";

            iAnoMes = Convert.ToInt16(txtAno.Text) * 100 + Convert.ToInt16(ddlMeses.SelectedValue);
            pnlDetail.Visible = false;
            btnGuardaIngreso.Visible = false;
            btnIngreso.Visible = true;
            btnImprimir.Visible = true;
            btnExcel.Visible = true;

            RendicionIngresoColl rI = new RendicionIngresoColl();

            //rI.InsertUpdate(iIdRendicionIngreso, iNumeroComprobante, iCorrelativo, Convert.ToDateTime(ddlFechaComprobante.Text), Convert.ToInt32(ddlDetalleIngreso.SelectedValue), iMonto, txtGlosa.Text.ToUpper(), iNulo, 1, iCodProyecto, iAnoMes, dFechaRegistro);
            rI.InsertUpdate(iIdRendicionIngreso, iNumeroComprobante, iCorrelativo, Convert.ToDateTime(ddlFechaComprobante.Text), Convert.ToInt32(ddlDetalleIngreso.SelectedValue), iMonto, txtGlosa.Text.ToUpper(), iNulo, Convert.ToInt32(Session["IdUsuario"]), iCodProyecto, iAnoMes, dFechaRegistro);

            GetIngresosGr();
            dtIngresos = rI.GetData("", ddlProyecto.SelectedValue, "", iAnoMes, dtIngresos, 0, Convert.ToInt32(Session["IdUsuario"]));
            grdIngresoDetalles.DataSource = dtIngresos;
            grdIngresoDetalles.DataBind();
            txtIdRendicionIngreso.Text = dtIngresos.Rows[0]["IdRendicionIngreso"].ToString();
            iTotal = SumaTotales(iTotal);
            tblTotal.Visible = true;
            txtTotal.Text = iTotal.ToString();
        }
    }
    protected void btnCancelaIngreso_Click(object sender, EventArgs e)
    {
        pnlDetail.Visible = false;
        btnGuardaIngreso.Visible = false;
        btnIngreso.Visible = true;
        btnCancelaIngreso.Visible = false;
        lblTipoIngreso.Visible = false;
        lblDetalleIngreso.Visible = false;
        lblMonto.Visible = false;
        ddlFechaComprobante.ReadOnly = false;
        tblEditar.Rows[1].Visible = true;
        tblEditar.Rows[2].Visible = true;
    }
    protected void btnIngreso_Click(object sender, EventArgs e)
    {
        HabilitaIngresos();
        GetTipoIngreso(1);
        GetDetalleIngreso(1);
        tblEditar.Rows[1].Visible = false;
        tblEditar.Rows[2].Visible = false;
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        PreparaReporte();
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'Reg_Reportes.aspx?Impresora_Excel=1" + "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Proyecto=" + txtProyecto.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno.Text + "&param001=2', 'Reportes', false, true, '800', '600', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        PreparaReporte();
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'Reg_Reportes.aspx?Impresora_Excel=2" + "&Institucion=" + ddlInstitucion.SelectedItem.Text.Trim() + "&Proyecto=" + txtProyecto.Text.Trim() + "&Meses=" + ddlMeses.SelectedItem.Text + "&Ano=" + txtAno.Text + "&param001=2', 'Reportes', false, true, '800', '600', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
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
        RendicionIngresoColl ri = new RendicionIngresoColl();
        dtIngresos.Rows.Clear();
        txtIdRendicionIngreso.Text = "";
        dtIngresos = ri.GetData(txtInstitucion.Text, txtCodProyecto.Text, txtProyecto.Text, iAnoMes, dtIngresos, 2, Convert.ToInt32(Session["IdUsuario"]));

        grdBuscador.DataSource = dtIngresos;
        grdBuscador.DataBind();
        txtProyecto.Text = strProyecto.Trim();
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
}
