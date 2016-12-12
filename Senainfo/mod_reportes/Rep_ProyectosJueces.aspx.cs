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
using System.Data.Common;
using System.Drawing;

public partial class Reportes_Rep_ProyectosJueces : System.Web.UI.Page
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
                if (!window.existetoken("26592D4D-A6D3-4370-8A6C-D91636CBD24E"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                btn_buscar.Attributes.Add("onclick", "f_MuestraEspera();");
                txtAnos.Attributes.Add("OnKeyPress", "f_SoloNumeros()");
                txtMeses.Attributes.Add("OnKeyPress", "f_SoloNumeros()");

                ddproyecto.Items.Add(new ListItem(" Seleccionar", "-1"));
                ddComuna.Items.Add(new ListItem(" Seleccionar", "-1"));

                getparregion();
                getinstituciones();
                getTematica();
                getModeloIntervencion();
                //getproyectoxinst();

                btn_excel.Visible = false;
                if (Request.QueryString["sw"] == "3")
                {
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddinstitucion_SelectIndex_changed(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codreg = bsc.GetCodRegionxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddregion.SelectedValue = Convert.ToString(codreg);
                    ddregion_SelectIndexChanged(sender, e);
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    getproyectoxinst();
                   
                    // aca cargar la region
                    ddproyecto.SelectedValue = Request.QueryString["codinst"]; //este es codigo del proyecto porque esta al reves
                }
                //lblPeriodo.Text = System.DateTime.Today.ToString("dd/MM/yyyy");
                lblPeriodo.Text = System.DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                cal_inicio.Text = System.DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                if (System.DateTime.Today.Month != System.DateTime.Today.AddDays(-1).Month)
                {
                    CalendarExtende1619.StartDate = System.DateTime.Today.AddDays(-1);
                    CalendarExtende1619.EndDate = System.DateTime.Today.AddDays(-1);
                }
                else
                {
                    CalendarExtende1619.StartDate = System.DateTime.Today.AddDays(System.DateTime.Today.AddDays(-1).Day * -1);
                    CalendarExtende1619.EndDate = System.DateTime.Today.AddDays(-1);
                }

                grd001.Columns[7].HeaderText = grd001.Columns[7].HeaderText + System.Environment.NewLine + Convert.ToDateTime(lblPeriodo.Text).AddMonths(-1).ToString("dd/MM/yyyy").Substring(3);
                grd001.Columns[8].HeaderText = grd001.Columns[8].HeaderText + System.Environment.NewLine + Convert.ToDateTime(lblPeriodo.Text).AddMonths(-1).ToString("dd/MM/yyyy").Substring(3);
                grd001.Columns[9].HeaderText = grd001.Columns[9].HeaderText + System.Environment.NewLine + Convert.ToDateTime(lblPeriodo.Text).AddMonths(-1).ToString("dd/MM/yyyy").Substring(3);

                grd001.Columns[10].HeaderText = grd001.Columns[10].HeaderText + "  " + System.Environment.NewLine + lblPeriodo.Text;
                grd001.Columns[11].HeaderText = grd001.Columns[11].HeaderText + "  " + System.Environment.NewLine + lblPeriodo.Text;
                grd001.Columns[12].HeaderText = grd001.Columns[12].HeaderText + "  " + System.Environment.NewLine + lblPeriodo.Text;
            }
        }
    }

    public DataTable DTVacantes
    {
        get { return (DataTable)Session["DTVacantes"]; }
        set { Session["DTVacantes"] = value; }
    }
    
    private void getModeloIntervencion()
    {
        parcoll par = new parcoll();
        DataTable dt1 = new DataTable();
        if (ddDepartamentosSename.SelectedValue.ToString() == "0" && ddTematica.SelectedValue.ToString() == "-1")
            dt1 = par.GetparModeloIntervencion();
        else
        {
            string strDepartamentosSename = string.Empty;
            string strTematica = ddTematica.SelectedValue.ToString();

            if (ddDepartamentosSename.SelectedValue.ToString() == "1")
                strDepartamentosSename = "6, 9, 8";
            if (ddDepartamentosSename.SelectedValue.ToString() == "2")
                strDepartamentosSename = "7";

            string strSQL = string.Empty;
            strSQL += "select distinct t4.*, t4.IndVigencia ";
            strSQL += "from parTematicaProyecto t1 ";
            strSQL += "inner join parModeloIntervencion_Tematica t2 ON t1.CodTematicaProyecto = t2.CodTematicaProyecto ";
            strSQL += "inner join parTematicaProyecto t3 ON t1.CodTematicaProyecto = t3.CodTematicaProyecto ";
            strSQL += "inner join parModeloIntervencion t4 ON t2.CodModeloIntervencion = t4.CodModeloIntervencion ";

            if ((ddDepartamentosSename.SelectedValue.ToString() != "0" && ddTematica.SelectedValue.ToString() != "-1"))
            {
                strSQL += "where t2.CodDepartamentosSENAME in (" + strDepartamentosSename + ") and t3.IndVigencia= 'V' and t4.IndVigencia = 'V' ";
                strSQL += "and t3.CodTematicaProyecto = " + strTematica;

            }
            else
            {
                if (ddDepartamentosSename.SelectedValue.ToString() != "0")
                    strSQL += "where t2.CodDepartamentosSENAME in (" + strDepartamentosSename + ") and t3.IndVigencia= 'V' ";
                else
                    strSQL += "where t3.CodTematicaProyecto = " + strTematica;
            }
            dt1 = par.ejecuta_SQL(strSQL);
        }

        DataRow dr; dr = dt1.NewRow(); dr[0] = -1; dr[1] = " Seleccionar"; dr[7] = 0;  dt1.Rows.Add(dr);
        DataView dv1 = new DataView(dt1);
        # region modificación 14-06-2011 <<DPL>>
        //dv1.RowFilter = "(IndVigencia = 'V' or CodModeloIntervencion = -1) and LRPA <= 0 and CodModeloIntervencion not in (10, 19, 21, 32, 37, 38, 76, 94)";
        # endregion
        dv1.RowFilter = "(IndVigencia = 'V' or CodModeloIntervencion = -1) and CodModeloIntervencion not in (10, 19, 21, 32, 37, 38, 76, 94, 111, 113)";
        dv1.Sort = "Descripcion";
        ddModeloIntervencion.DataSource = dv1;
        ddModeloIntervencion.DataTextField = "Descripcion";
        ddModeloIntervencion.DataValueField = "CodModeloIntervencion";
        ddModeloIntervencion.DataBind();
        ddModeloIntervencion.SelectedValue = "-1";      // Seleccionar
        getproyectoxinst();
    }

    private void getparregion()
    {
        parcoll par = new parcoll();
         DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddregion.DataBind();
        ddregion.SelectedValue = "-3";      // Seleccionar

       if (dv1.Count == 2)
            ddregion.SelectedIndex = 1;
    }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.Get_DataConProyectos_byUserId(Convert.ToInt32(Session["IdUsuario"])));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();
    }
    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetDataxRgnConProyectos(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();
    }
    private void getproyectoxinst()
    {
        proyectocoll proy = new proyectocoll();
        //proy.GetProyectos_Region_Institucion
        DataView dv3 = new DataView(proy.GetDataII(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        if (Convert.ToInt32(ddregion.SelectedValue) > 0)
            dv3.RowFilter = "(CodRegion = " + ddregion.SelectedValue.ToString() + " OR CodProyecto = 0)";

        if (Convert.ToInt32(ddModeloIntervencion.SelectedValue) > 0 && Convert.ToInt32(ddregion.SelectedValue) > 0)
            dv3.RowFilter = dv3.RowFilter + " and (CodModeloIntervencion = " + ddModeloIntervencion.SelectedValue.ToString() + " OR CodProyecto = 0)";
        else 
            if (Convert.ToInt32(ddModeloIntervencion.SelectedValue) > 0)
                dv3.RowFilter = "(CodModeloIntervencion = " + ddModeloIntervencion.SelectedValue.ToString() + " OR CodProyecto = 0)";
        if (dv3.RowFilter != "")
        {
            dv3.RowFilter = dv3.RowFilter + " and (CodModeloIntervencion not in (10, 19, 21, 32, 37, 38, 76, 94, 111, 113) OR CodProyecto = 0)";
            //-- 10	COM - CENTRO DE DIAGNÓSTICO PARA MAYORES COMISARÍAS
            //-- 19	EVA - PROGRAMA DE EVALUACIÓN Y ESTUDIO
            //-- 21	GEN - SECCIONES DE MENORES DE GENCHI
            //-- 32	OPD - OFICINA DE PROTECCIÓN DE DERECHOS
            //-- 37	CAP - PROGRAMA DE CAPACITACIÓN
            //-- 38	COD - CENTROS DE OBSERVACIÓN Y DIÁGNOSTICOS
            //-- 76	DIF - PROGRAMA DE DIFUSIÓN
            //-- 94	EMG - PROGRAMA DE EMERGENCIA	p.CodDepartamentosSENAME IN (6, 9) AND 
            # region modificación 14-06-2011 <<DPL>>
            //dv3.RowFilter = dv3.RowFilter + " and (CodCausalTerminoProyecto <> 20084 OR CodProyecto = 0)";
            ////10	CERRADA
            ////11	SEMICERRADA
            ////12	MEDIO LIBRE
            ////13	REESCOLARIZACION
            # endregion
        }
        else
        {
            dv3.RowFilter = "(CodModeloIntervencion not in (10, 19, 21, 32, 37, 38, 76, 94, 111, 113) OR CodProyecto = 0)";
            # region modificación 14-06-2011 <<DPL>>
            //dv3.RowFilter = dv3.RowFilter + " and (CodCausalTerminoProyecto <> 20084 OR CodProyecto = 0)";
            # endregion
        }

        if (dv3.RowFilter != "" && Convert.ToInt32(ddComuna.SelectedValue) > 0)
            dv3.RowFilter = dv3.RowFilter + " and (CodComuna = " + ddComuna.SelectedValue.ToString() + "OR CodProyecto = 0)";

        string strDepartamentosSename = string.Empty;
        if (ddDepartamentosSename.SelectedValue.ToString() == "1")
            strDepartamentosSename = "6, 9, 8";
        if (ddDepartamentosSename.SelectedValue.ToString() == "2")
            strDepartamentosSename = "7";
        if (dv3.RowFilter != "" && Convert.ToInt32(ddDepartamentosSename.SelectedValue) > 0)
            dv3.RowFilter = dv3.RowFilter + " and (CodDepartamentosSENAME in(" + strDepartamentosSename + ") OR CodProyecto = 0) ";

        if (dv3.RowFilter != "" && Convert.ToInt32(ddTematica.SelectedValue) > 0)
            dv3.RowFilter = dv3.RowFilter + " and (CodTematicaProyecto = " + ddTematica.SelectedValue.ToString() + " OR CodProyecto = 0) ";

        ddproyecto.DataSource = dv3;
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();
    }
    private int validatesecurity()
    {
        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
        int val = 0;

        if (rol == "267" || rol == "265")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }

            if (ddproyecto.SelectedValue == "0")
            {
                ddproyecto.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddproyecto.BackColor = System.Drawing.Color.White; }
        }
        if (rol == "251")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }
        }

        return val;
    }
    private void limpiar()
    {
        grd001.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        pnlAlert.Visible = false;
        
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../index.aspx");
    }

    private void bloqueaCampos()
    {
        ddregion.Enabled = false;
        ddComuna.Enabled = false;
        ddinstitucion.Enabled = false;
        ddDepartamentosSename.Enabled = false;
        ddTematica.Enabled = false;
        ddModeloIntervencion.Enabled = false;
        ddproyecto.Enabled = false;
        ddSexo.Enabled = false;
        txtAnos.Enabled = false;
        txtMeses.Enabled = false;
    }

    private void activaCampos()
    {
        ddregion.Enabled = true;
        ddComuna.Enabled = true;
        ddinstitucion.Enabled = true;
        ddDepartamentosSename.Enabled = true;
        ddTematica.Enabled = true;
        ddModeloIntervencion.Enabled = true;
        ddproyecto.Enabled = true;
        ddSexo.Enabled = true;
        txtAnos.Enabled = true;
        txtMeses.Enabled = true;
    }


    protected void btn_buscar_Click(object sender, EventArgs e)
    {

        int val = validatesecurity();
         if (val == 0)
         {
             if (Convert.ToInt32(ddregion.SelectedValue) < 1 && Convert.ToInt32(ddModeloIntervencion.SelectedValue) < 1 && Convert.ToInt32(ddinstitucion.SelectedValue) < 1 && Convert.ToInt32(ddproyecto.SelectedValue) < 1 && Convert.ToInt32(ddregion.SelectedValue) != -2)
             {
                 lbl_error.Visible = true;
                 pnlAlert.Visible = true;
                 lbl_error.Text = "Debe seleccionar un Modelo de Intervención, Institución o Proyecto";
                 ddregion.Focus();
                 return;
             }
             else
             {
                 //if (Convert.ToInt32(ddregion.SelectedValue) < 1) old
                 if (Convert.ToInt32(ddregion.SelectedValue) < -1 && Convert.ToInt32(ddregion.SelectedValue) != -2)//toda las regiones
                 {
                     lbl_error.Visible = true;
                     pnlAlert.Visible = true;
                     lbl_error.Text = "Debe seleccionar una Región";
                     ddregion.Focus();
                     return;
                 }
                 //cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(lblPeriodo.Text), Convert.ToDateTime(lblPeriodo.Text), 1, -1);
                 //cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_inicio.Text), 3, -1);
                 cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(lblPeriodo.Text), Convert.ToDateTime(lblPeriodo.Text), 3, -1);
             }
         }
    }
    private void cargaDTG(int region,int codinstitucion,int codproyecto, DateTime fechainicio, DateTime fechatermino,int reporte,int tipo)
    {
        try
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
            DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                 con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@codproyecto",SqlDbType.Int ,4, codproyecto),
                                 con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
                                 con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino),
                                 con.parametros("@reporte",SqlDbType.Int,4,reporte),
                                 con.parametros("@tipo",SqlDbType.Int,4,tipo)
										};
            con.ejecutarProcedimiento("reporte_proyectos", parametros, out datareader);

            DataTable dt = new DataTable();
            dt.Columns.Add("CodInstitucion");
            dt.Columns.Add("NombreInstitucion");
            dt.Columns.Add("CodRegion");
            dt.Columns.Add("CodProyecto");
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("NombreSistemaAsistencial");
            dt.Columns.Add("Tematica");
            dt.Columns.Add("nModelo");
            dt.Columns.Add("nTipoProyecto");
            dt.Columns.Add("NumeroPlazas");
            dt.Columns.Add("NombreDepartamentosSename");
            dt.Columns.Add("EdadMinima");
            dt.Columns.Add("EdadMaxima");
            dt.Columns.Add("nsexo");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Comuna");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Mail");
            dt.Columns.Add("Director");
            dt.Columns.Add("FechaInicio");
            dt.Columns.Add("FechaTermino");
            dt.Columns.Add("IndVigencia");
            dt.Columns.Add("reporte");
            dt.Columns.Add("PlazasOcupadas");
            dt.Columns.Add("Vacantes");
            dt.Columns.Add("NumeroPlazasMesAnterior");
            dt.Columns.Add("PlazasOcupadasMesAnterior");
            dt.Columns.Add("VacantesMesAnterior");
            dt.Columns.Add("CodComuna");
            dt.Columns.Add("ListasDeEspera");
            dt.Columns.Add("CodDepartamentosSENAME");
            dt.Columns.Add("CodTematicaProyecto");

            DataRow dr;
            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (System.Int32)datareader["CodInstitucion"];
                    dr[1] = (System.String)datareader["NombreInstitucion"];
                    dr[2] = (System.Int32)datareader["CodRegion"];
                    dr[3] = (System.Int32)datareader["CodProyecto"];
                    dr[4] = (System.String)datareader["Nombre"];
                    dr[5] = (System.String)datareader["NombreSistemaAsistencial"];
                    dr[6] = (System.String)datareader["Tematica"];
                    dr[7] = (System.String)datareader["nModelo"];
                    dr[8] = (System.String)datareader["nTipoProyecto"];
                    dr[9] = (System.Int32)datareader["NumeroPlazas"];
                    dr[10] = (System.String)datareader["NombreDepartamentosSename"];
                    dr[11] = (System.Int32)datareader["EdadMinima"];
                    dr[12] = (System.Int32)datareader["EdadMaxima"];
                    dr[13] = (System.String)datareader["nsexo"];
                    dr[14] = (System.String)datareader["Direccion"];
                    dr[15] = (System.String)datareader["Comuna"];
                    dr[16] = (System.String)datareader["Telefono"];
                    dr[17] = (System.String)datareader["Mail"];
                    dr[18] = (System.String)datareader["Director"];
                    dr[19] = (System.String)datareader["FechaInicio"];
                    dr[20] = (System.String)datareader["FechaTermino"];
                    dr[21] = (System.String)datareader["IndVigencia"];
                    dr[22] = (System.String)datareader["reporte"];
                    dr[23] = (System.Int32)datareader["PlazasOcupadas"];
                    dr[24] = Convert.ToInt32(dr[9]) - Convert.ToInt32(dr[23]);
                    if (Convert.ToInt32(dr[24]) < 0)
                        dr[24] = 0;
                    dr[25] = (System.Int32)datareader["NumeroPlazasMesAnterior"];
                    dr[26] = (System.Int32)datareader["PlazasOcupadasMesAnterior"];
                    dr[27] = Convert.ToInt32(dr[25]) - Convert.ToInt32(dr[26]);
                    if (Convert.ToInt32(dr[27]) < 0)
                        dr[27] = 0;
                    dr[28] = (System.Int32)datareader["CodComuna"];
                    dr[29] = (System.Int32)datareader["ListasDeEspera"];
                    dr[30] = (System.Int32)datareader["CodDepartamentosSENAME"];
                    dr[31] = (System.Int32)datareader["CodTematicaProyecto"];
                    dt.Rows.Add(dr);
                }
                catch
                {
                }
            }
            con.Desconectar();

            DataView dv = new DataView(dt);

            string strDepartamentosSename = string.Empty;
            if (ddDepartamentosSename.SelectedValue.ToString() == "1") strDepartamentosSename = "6, 9, 8";
            if (ddDepartamentosSename.SelectedValue.ToString() == "2") strDepartamentosSename = "7";

            if (Convert.ToInt32(ddDepartamentosSename.SelectedValue) > 0)
                dv.RowFilter = dv.RowFilter + "CodDepartamentosSENAME in(" + strDepartamentosSename + ") ";

            if (dv.RowFilter != "" && Convert.ToInt32(ddTematica.SelectedValue) > 0)
                dv.RowFilter = dv.RowFilter + " and CodTematicaProyecto = " + ddTematica.SelectedValue.ToString() + " ";
            else
                if (Convert.ToInt32(ddTematica.SelectedValue) > 0)
                    dv.RowFilter = dv.RowFilter + "CodTematicaProyecto = " + ddTematica.SelectedValue.ToString() + " ";

            if (dv.RowFilter != "" && Convert.ToInt32(ddModeloIntervencion.SelectedValue) > 0)
                dv.RowFilter = dv.RowFilter + " and nModelo = '" + ddModeloIntervencion.SelectedItem.ToString() + "'";

            else
                if (Convert.ToInt32(ddModeloIntervencion.SelectedValue) > 0)
                    dv.RowFilter = dv.RowFilter + "nModelo = '" + ddModeloIntervencion.SelectedItem.ToString() + "'";

            if (dv.RowFilter != "" && Convert.ToInt32(ddproyecto.SelectedValue) > 0)
                dv.RowFilter = dv.RowFilter + " and CodProyecto = " + ddproyecto.SelectedValue.ToString() + " ";
            else
                if (Convert.ToInt32(ddproyecto.SelectedValue) > 0)
                    dv.RowFilter = dv.RowFilter + "CodProyecto = " + ddproyecto.SelectedValue.ToString() + " ";

            if (Convert.ToInt32(ddComuna.SelectedValue) > 0)
                if (dv.RowFilter != "")
                    dv.RowFilter = dv.RowFilter + " and CodComuna = " + ddComuna.SelectedValue.ToString();
                else
                    dv.RowFilter = dv.RowFilter + "CodComuna = " + ddComuna.SelectedValue.ToString();

            if (txtAnos.Text == "") txtAnos.Text = "0";
            if (txtMeses.Text == "") txtMeses.Text = "0";

            int Tramo = Convert.ToInt32(txtAnos.Text) + Convert.ToInt32(txtMeses.Text);
            if (Tramo > 0)
            {
                Tramo = ((Convert.ToInt32(txtAnos.Text) * 12) + Convert.ToInt32(txtMeses.Text)) / 12;
                if (dv.RowFilter != "")
                    dv.RowFilter = dv.RowFilter + " and (EdadMinima <= " + Tramo.ToString() + " and " + Tramo.ToString() + " <= EdadMaxima)";
                else
                    dv.RowFilter = dv.RowFilter + "(EdadMinima <= " + Tramo.ToString() + " and " + Tramo.ToString() + " <= EdadMaxima";
            }

            if (ddSexo.SelectedValue.ToString() != "-1")
                if (dv.RowFilter != "")
                    dv.RowFilter = dv.RowFilter + " and nSexo in ('" + ddSexo.SelectedValue.ToString() + "', '', '0', 'A')";
                else
                    dv.RowFilter = dv.RowFilter + "nSexo in ('" + ddSexo.SelectedValue.ToString() + "', '', '0', 'A')";

            if (dv.Count > 0)
            {
                DTVacantes = dt;
                grd001.DataSource = dv;
                grd001.DataBind();
                btn_excel.Visible = true;
                pnlAlert.Visible = false;
                lbl_error.Visible = false;
                pnlAlert.Visible = false;
                pnl001.Visible = true;
                grd001.Visible = true;
                bloqueaCampos();
            }
            else
            {
                btn_excel.Visible = false;
                pnlAlert.Visible = true;
                lbl_error.Text = "No se han encontrado registros coincidentes.";
                lbl_error.Visible = true;
                grd001.Visible = false;
            }
        }
        catch
        {
            pnlAlert.Visible = true;
            lbl_error.Visible = true;
            lbl_error.Text = "Error al procesar su solicitud, Favor vuelva a Intentar"; }
    }
    protected void ddregion_SelectIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddregion.SelectedValue) < 1)
        {
            getinstituciones();
            ddproyecto.Items.Clear();
            ddproyecto.Items.Add(new ListItem(" Seleccionar", "-1"));
        }
        else
        {
            if (Convert.ToInt32(ddinstitucion.SelectedValue) < 1)
                getinstitucionesxRgn();
            getproyectoxinst();
            parcoll pc = new parcoll();
            DataView dv = new DataView(pc.GetparComunas(ddregion.SelectedValue.ToString()));
            ddComuna.DataSource = dv;
            ddComuna.DataTextField = "Descripcion";
            ddComuna.DataValueField = "CodComuna";
            dv.Sort = "Descripcion";
            ddComuna.DataBind();
        }
    }
    protected void ddinstitucion_SelectIndex_changed(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        pnl001.Visible = false;
        grd001.Visible = false;
        grd001.DataSource = null;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        pnlAlert.Visible = false;


        activaCampos();

        ddregion.SelectedIndex = -1;
        ddDepartamentosSename.SelectedIndex = -1;
        getTematica();
        ddTematica.SelectedIndex = -1;
        getModeloIntervencion();
        ddModeloIntervencion.SelectedIndex = -1;
        getinstituciones();
        //getModeloIntervencion();

        ddproyecto.Items.Clear();
        ddproyecto.Items.Add(new ListItem(" Seleccionar", "-1"));
        ddproyecto.DataBind();
        ddComuna.Items.Clear();
        ddComuna.Items.Add(new ListItem(" Seleccionar", "-1"));
        ddComuna.DataBind();
        txtAnos.Text = "0";
        txtMeses.Text = "0";
        ddSexo.SelectedIndex = 0;
        //getproyectoxinst();
    }

    // Ahora se usa el evento de click del linkButton, esto es un respaldo del contenido del boton anterior.

    //protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    //{
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.ContentType = "application/vnd.ms-excel";
    //    Response.AddHeader("Content-Disposition", "attachment;filename=Vacantes_Proyectos_" + lblPeriodo.Text + ".xls");
    //    Response.Charset = "";
    //    this.EnableViewState = false;

    //    System.IO.StringWriter tw = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("CodInstitucion");
    //    dt.Columns.Add("NombreInstitucion");
    //    dt.Columns.Add("CodRegion");
    //    dt.Columns.Add("Comuna");
    //    dt.Columns.Add("CodProyecto");
    //    dt.Columns.Add("Nombre", typeof(String));
    //    //dt.Columns.Add("NombreSistemaAsistencial");
    //    dt.Columns.Add("nModelo");
    //    dt.Columns.Add("NumeroPlazasMesAnterior");
    //    dt.Columns.Add("PlazasOcupadasMesAnterior");
    //    dt.Columns.Add("VacantesMesAnterior");
    //    dt.Columns.Add("NumeroPlazas");
    //    dt.Columns.Add("PlazasOcupadas");
    //    dt.Columns.Add("Vacantes");
    //    //dt.Columns.Add("NombreDepartamentosSename");
    //    dt.Columns.Add("ListasDeEspera");
    //    dt.Columns.Add("EdadMinima");
    //    dt.Columns.Add("EdadMaxima");
    //    dt.Columns.Add("nsexo");
    //    dt.Columns.Add("Telefono");
    //    dt.Columns.Add("Director");
    //    dt.Columns.Add("Mail");
    //    DataRow dr;

    //    for (int i = 0; i < grd001.Rows.Count; i++)
    //    {
    //        dr = dt.NewRow();
    //        dr[0] = grd001.Rows[i].Cells[0].Text;
    //        dr[1] = grd001.Rows[i].Cells[1].Text;
    //        dr[2] = grd001.Rows[i].Cells[2].Text;
    //        dr[3] = grd001.Rows[i].Cells[3].Text;
    //        dr[4] = grd001.Rows[i].Cells[4].Text;
    //        dr[5] = grd001.Rows[i].Cells[5].Text;
    //        dr[6] = grd001.Rows[i].Cells[6].Text;
    //        dr[7] = grd001.Rows[i].Cells[7].Text;
    //        dr[8] = grd001.Rows[i].Cells[8].Text;
    //        dr[9] = grd001.Rows[i].Cells[9].Text;
    //        dr[10] = grd001.Rows[i].Cells[10].Text;
    //        dr[11] = grd001.Rows[i].Cells[11].Text;
    //        dr[12] = grd001.Rows[i].Cells[12].Text;
    //        dr[13] = grd001.Rows[i].Cells[13].Text;
    //        dr[14] = grd001.Rows[i].Cells[14].Text;
    //        dr[15] = grd001.Rows[i].Cells[15].Text;
    //        dr[16] = grd001.Rows[i].Cells[16].Text;
    //        dr[17] = grd001.Rows[i].Cells[17].Text;
    //        dr[18] = grd001.Rows[i].Cells[18].Text;
    //        dr[19] = grd001.Rows[i].Cells[19].Text;
    //        dt.Rows.Add(dr);
    //    }
    //    DataView dv = new DataView(dt);
    //    DataGrid d1 = new DataGrid();
    //    d1.DataSource = dv;
    //    d1.DataBind();
    //    d1.RenderControl(hw);
    //    Response.Write(tw.ToString());
    //    Response.End();
    //}


    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ProyectosJueces.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ProyectosJueces.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void ddModeloIntervencion_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void ddComuna_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddproyecto.SelectedValue == "0" || ddproyecto.SelectedValue == "-1" || ddproyecto.SelectedValue == "-2")
            getproyectoxinst();
    }
    protected void ddDepartamentosSename_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddproyecto.SelectedValue == "0" || ddproyecto.SelectedValue == "-1" || ddproyecto.SelectedValue == "-2")
            getTematica();
    }
    private void getTematica()
    {
        string strDepartamentosSename = string.Empty;
        if (ddDepartamentosSename.SelectedValue.ToString() == "0")
            strDepartamentosSename = "";
        if (ddDepartamentosSename.SelectedValue.ToString() == "1")
            strDepartamentosSename = "6, 9, 8";
        if (ddDepartamentosSename.SelectedValue.ToString() == "2")
            strDepartamentosSename = "7";

        string strSQL = string.Empty;
        strSQL += "select distinct t1.*, t3.IndVigencia ";
        strSQL += "from parTematicaProyecto t1 ";
        strSQL += "inner join parModeloIntervencion_Tematica t2 ON t1.CodTematicaProyecto = t2.CodTematicaProyecto and t1.IndVigencia = 'V' ";
        strSQL += "inner join parTematicaProyecto t3 ON t1.CodTematicaProyecto = t3.CodTematicaProyecto ";
        strSQL += "inner join parModeloIntervencion t4 ON t2.CodModeloIntervencion = t4.CodModeloIntervencion ";
        strSQL += "where t2.CodDepartamentosSENAME in (" + strDepartamentosSename + ") ";
        strSQL += "and t3.IndVigencia= 'V' and t4.IndVigencia = 'V' ";
        strSQL += "and t4.CodModeloIntervencion not in (10, 19, 21, 32, 37, 38, 76, 94, 111, 113)";
        
        parcoll pc = new parcoll();
        DataTable dt = new DataTable();
        if (strDepartamentosSename == string.Empty)
            dt = pc.GetparTematicaProyecto();
        else
            dt = pc.ejecuta_SQL(strSQL);

        DataRow dr; dr = dt.NewRow(); dr[0] = -1; dr[1] = " Seleccionar"; dr[2] = "V"; dt.Rows.Add(dr);
        DataView dv = new DataView(dt);

        dv.Sort = "Descripcion";
        dv.RowFilter = "IndVigencia = 'V'";
        ddTematica.DataSource = dv;
        ddTematica.DataTextField = "Descripcion";
        ddTematica.DataValueField = "CodTematicaProyecto";
        ddTematica.DataBind();
        ddTematica.SelectedValue = "-1";      // Seleccionar
        getModeloIntervencion();
    }
    protected void ddTematica_SelectedIndexChanged(object sender, EventArgs e)
    {
        getModeloIntervencion();
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Vacantes_Proyectos_" + lblPeriodo.Text + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        DataSet dts = new DataSet();
        dt.Columns.Add("CodInstitucion");
        dt.Columns.Add("NombreInstitucion");
        dt.Columns.Add("CodRegion");
        dt.Columns.Add("Comuna");
        dt.Columns.Add("CodProyecto");
        dt.Columns.Add("Nombre", typeof(String));
        //dt.Columns.Add("NombreSistemaAsistencial");
        dt.Columns.Add("nModelo");
        dt.Columns.Add("NumeroPlazasMesAnterior");
        dt.Columns.Add("PlazasOcupadasMesAnterior");
        dt.Columns.Add("VacantesMesAnterior");
        dt.Columns.Add("NumeroPlazas");
        dt.Columns.Add("PlazasOcupadas");
        dt.Columns.Add("Vacantes");
        //dt.Columns.Add("NombreDepartamentosSename");
        dt.Columns.Add("ListasDeEspera");
        dt.Columns.Add("EdadMinima");
        dt.Columns.Add("EdadMaxima");
        dt.Columns.Add("nsexo");
        dt.Columns.Add("Telefono");
        dt.Columns.Add("Director");
        dt.Columns.Add("Mail");

        DataRow dr;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            dr = dt.NewRow();
            dr[0] = grd001.Rows[i].Cells[0].Text;
            dr[1] = grd001.Rows[i].Cells[1].Text;
            dr[2] = grd001.Rows[i].Cells[2].Text;
            dr[3] = grd001.Rows[i].Cells[3].Text;
            dr[4] = grd001.Rows[i].Cells[4].Text;
            dr[5] = grd001.Rows[i].Cells[5].Text;
            dr[6] = grd001.Rows[i].Cells[6].Text;
            dr[7] = grd001.Rows[i].Cells[7].Text;
            dr[8] = grd001.Rows[i].Cells[8].Text;
            dr[9] = grd001.Rows[i].Cells[9].Text;
            dr[10] = grd001.Rows[i].Cells[10].Text;
            dr[11] = grd001.Rows[i].Cells[11].Text;
            dr[12] = grd001.Rows[i].Cells[12].Text;
            dr[13] = grd001.Rows[i].Cells[13].Text;
            dr[14] = grd001.Rows[i].Cells[14].Text;
            dr[15] = grd001.Rows[i].Cells[15].Text;
            dr[16] = grd001.Rows[i].Cells[16].Text;
            dr[17] = grd001.Rows[i].Cells[17].Text;
            dr[18] = grd001.Rows[i].Cells[18].Text;
            dr[19] = grd001.Rows[i].Cells[19].Text;
            dt.Rows.Add(dr);
        }
        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = DTVacantes;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void btnBuscaProyecto_Click(object sender, EventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ProyectosJueces.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        DataTable dvNinos = DTVacantes;

        grd001.DataSource = DTVacantes;
        grd001.DataBind();
    }
}
