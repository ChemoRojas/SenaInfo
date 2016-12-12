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
using regfaltas2TableAdapters;
using Argentis.Regmen;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.Common;

using System.Collections.Generic;

public partial class mod_ninos_Ingresoninolistaespera : System.Web.UI.Page
{
    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set {
            if (Session["neo_SSnino"] == null)
            {
                Session["neo_SSnino"] = new nino();
            }
            Session["neo_SSnino"] = value; 
        }

    }
    public string CodProy
    {
        get { return (string)Session["CodProy"]; }
        set { Session["CodProy"] = value; }
    }

    public string NomProy
    {
        get { return (string)Session["NomProy"]; }
        set { Session["NomProy"] = value; }
    }
    public DataTable DTBusqueda
    {
        get { return (DataTable)Session["DTBusqueda"]; }
        set { Session["DTBusqueda"] = value; }
    }

    public int UserId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }


    private string pagllamante = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        pagllamante = Request.QueryString["dir"];

        if (!IsPostBack)
        {
            //Fecha Ingreso Lista de Espera
            CalendarExtende510.EndDate = DateTime.Now;

            CalendarExtende522.EndDate = DateTime.Now;

            CalendarExtende498.EndDate = DateTime.Now;

            //Fecha Egreso
            CalendarExtende534.EndDate = DateTime.Now;

            txtRutTest.Attributes.Add("onchange", "Valida_Rut();");


            if (Request.QueryString["IngresoLE"] != null)
            {
                btn_agregar.Text = "Modificar";
                CargoDropDowns();
                ddown_Institucion.SelectedValue = Convert.ToString(SSnino.CodInst);
                //CargaProyectos();
                getproyectos();
                ddown_Proyecto.SelectedValue = Convert.ToString(SSnino.CodProyecto);
                HabilitoControles();
                txt_rut.Text = SSnino.rut;

                parListaEsperaTableAdapter parLE = new parListaEsperaTableAdapter();
                DataTable dt_data = parLE.Get_listaespera_x_codLE(Convert.ToInt32(Request.QueryString["IngresoLE"]));
                lbl_ICodIngresoLE.Text = Request.QueryString["IngresoLE"].ToString();



                if (dt_data.Rows.Count > 0)
                {
                    Function_ConsultaLE(Convert.ToInt32(dt_data.Rows[0]["CodNino"]));

                    parRegion_by_comunaTableAdapter reg_com = new parRegion_by_comunaTableAdapter();
                    DataTable dt_com = reg_com.GetRegiones_PorComuna(Convert.ToInt32(dt_data.Rows[0]["CodComuna"]));
                    if (dt_com.Rows.Count > 0)
                    {
                        ddown_region.SelectedValue = dt_com.Rows[0][0].ToString();
                        CargoComunas();
                    }
                    ddown_comuna.SelectedValue = dt_data.Rows[0]["CodComuna"].ToString();

                    par_Tribunales_tipo_regTableAdapter trib_tipo_reg = new par_Tribunales_tipo_regTableAdapter();
                    DataTable dt_tr_tp = trib_tipo_reg.GetTribunales_Tipo_Region(Convert.ToInt32(dt_data.Rows[0]["CodTribunal"]));
                    if (dt_tr_tp.Rows.Count > 0)
                    {
                        ddown_RegionTribunal.SelectedValue = dt_tr_tp.Rows[0]["CodRegion"].ToString();
                        ddown_TipoTribunal.SelectedValue = dt_tr_tp.Rows[0]["TipoTribunal"].ToString();
                        GetTribunales();
                        ddown_Tribunal.SelectedValue = dt_tr_tp.Rows[0]["CodTribunal"].ToString();
                    }

                    //par_Tipos_CausalTableAdapter p_tipos = new par_Tipos_CausalTableAdapter();
                    //DataTable dt_tipos_causal = p_tipos.GetTipo_CausalIngreso(Convert.ToInt32(dt_data.Rows[0]["CodCausalIngreso"]));
                    //if (dt_tipos_causal.Rows.Count > 0)
                    //{
                    //    ddown_TipoCausal.SelectedValue = dt_tipos_causal.Rows[0][0].ToString();
                    //    cargocausal();
                    //    ddown_Causal.SelectedValue = dt_data.Rows[0]["CodCausalIngreso"].ToString();
                    //}


                    parcoll par = new parcoll();
                    DataView dv15 = new DataView(par.GetparTipoCausalIngresoSingle(Convert.ToInt32(dt_data.Rows[0]["CodCausalIngreso"])));
                    if (dv15.Count > 0)
                    {
                        ddown_TipoCausal.DataSource = dv15;
                        ddown_TipoCausal.DataTextField = "Descripcion";
                        ddown_TipoCausal.DataValueField = "CodTipoCausalIngreso";
                        ddown_TipoCausal.DataBind();
                        cargocausal(Convert.ToInt32(dt_data.Rows[0]["CodCausalIngreso"]));
                        //ddown_Causal.SelectedValue = dt_data.Rows[0]["CodCausalIngreso"].ToString();

                        ddown_TipoCausal.Enabled = false;
                        ddown_Causal.Enabled = false;
                        //ddown_TipoCausal_SelectedIndexChanged(sender, e);
                    }

                    ddown_solicitante.SelectedValue = dt_data.Rows[0]["CodSolicitante"].ToString();
                    wdc_Flistaespera.Text = dt_data.Rows[0]["FechaIngresoLE"].ToString().Substring(0, 10); ;
                    if (wdc_Flistaespera.Text != "")
                    {
                        CalendarExtende534.StartDate = Convert.ToDateTime(wdc_Flistaespera.Text);
                    }
                    txt_ruc.Text = dt_data.Rows[0]["RUC"].ToString();
                    txt_rit.Text = dt_data.Rows[0]["RIT"].ToString();
                    wdc_fecha.Text = dt_data.Rows[0]["FechaOrden"].ToString().Substring(0, 10);
                    tr_fecha_egreso.Visible = true;
                    tr_estado.Visible = true;
                    lbl_egreso.Visible = true;
                    lbl_estado.Visible = true;
                    wdc_F_egreso.Visible = true;
                    //wdc_F_egreso.Text = DateTime.Now.ToShortDateString();
                    wdc_F_egreso.Text = "";
                    ddown_estado.Visible = true;
                    ddown_region.Enabled = false;
                    wdc_Flistaespera.Enabled = false;
                    wdc_fecha.Enabled = false;

                    DataTable dtEstadoLE = GetData_EstadoLE();
                    if (dtEstadoLE.Rows.Count > 0)
                    {
                        ddown_estado.DataSource = dtEstadoLE;
                        ddown_estado.DataTextField = "Descripcion";
                        ddown_estado.DataValueField = "CodEstado";
                        ddown_estado.DataBind();
                    }



                    if ((SSnino.CodProyecto != 0 && SSnino.CodProyecto != null) && (SSnino.CodNino != 0 && SSnino.CodNino != null))
                    {
                        DataTable dt = getNinoEnProyecto(SSnino.CodProyecto, SSnino.CodNino);
                        if (dt.Rows.Count > 0)
                        {
                            lbl_error.Text = "El NNA Seleccionado ya se encuentra en este proyecto";
                            lbl_error.Visible = true;
                            btn_agregar.Enabled = false;
                        }

                    }
                    else
                    {
                        lbl_error.Visible = false;
                        btn_agregar.Enabled = true;
                    }
                }
                if (txt_rut.Text.Trim() != "")
                {
                    tblBusquedaRut.Visible = true;
                    tblDatos.Visible = true;
                    //ImageButton1_Click(new object(), new ImageClickEventArgs(0, 0));
                    ImageButton1.Attributes.Add("disabled", "disabled");
                }


            }
            else
            {

                ddown_TipoCausal.Enabled = true;
                ddown_Causal.Enabled = true;

                tr_fecha_egreso.Visible = false;
                tr_estado.Visible = false;
                lbl_egreso.Visible = false;
                lbl_estado.Visible = false;
                wdc_F_egreso.Visible = false;
                ddown_estado.Visible = false;
                btn_agregar.Text = "Agregar";
                CargoDropDowns();
                //CargaProyectos();
                ddown_Institucion.SelectedValue = Convert.ToString(SSnino.CodInst);
                getproyectos(); // se modifica por cargaproyectos ya que era lo mas lento de la carga
                ddown_Proyecto.SelectedValue = Convert.ToString(SSnino.CodProyecto);
                txt_rut.Text = SSnino.rut;
                if (txt_rut.Text.Trim() != "")
                {
                    tblBusquedaRut.Visible = true;
                    ImageButton1_Click(new object(), new ImageClickEventArgs(0, 0));
                }


                if (SSnino.rut != null)
                {
                    ninocoll n = new ninocoll();
                    DataTable dtNino = new DataTable();
                    dtNino = n.callto_get_ninoxrut(SSnino.rut.Trim().Replace(".", ""));

                    if (dtNino.Rows.Count > 0)
                    {
                        int codnino = 0;
                        if (int.TryParse(dtNino.Rows[0]["CodNino"].ToString(), out codnino))
                        {
                            SSnino.CodNino = codnino;
                        }
                    }

                    if ((SSnino.CodProyecto != 0 && SSnino.CodProyecto != null) && (SSnino.CodNino != 0 && SSnino.CodNino != null))
                    {
                        DataTable dt = getNinoEnProyecto(SSnino.CodProyecto, SSnino.CodNino);
                        if (dt.Rows.Count > 0)
                        {
                            lbl_error.Text = "El NNA Seleccionado ya se encuentra en este proyecto";
                            lbl_error.Visible = true;
                            btn_agregar.Enabled = false;
                        }

                    }
                    else
                    {
                        lbl_error.Visible = false;
                        btn_agregar.Enabled = true;
                    }
                }


                try
                {
                    parCustomRegionTableAdapter regiontribunal = new parCustomRegionTableAdapter();
                    DataTable dt1 = regiontribunal.GetRegion_by_Proyecto(SSnino.CodProyecto);
                    if (dt1.Rows.Count > 0)
                    {
                        ddown_RegionTribunal.SelectedValue = dt1.Rows[0][1].ToString();
                        ddown_region.SelectedValue = dt1.Rows[0][1].ToString();
                        CargoComunas();
                    }
                }
                catch
                {

                }
            }
        }



        //rdblist_rut_SelectedIndexChanged(sender, e);
    }

    public DataTable GetData_EstadoLE()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();

        string tsql = tsql = "SELECT * ";

        tsql += "FROM parEstadoListaEspera ";
        tsql += "WHERE IndVigencia = 'V'";
        con.ejecutar(tsql, out datareader);
        ninoslist nlist = new ninoslist();

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodEstado"));
        dt.Columns.Add(new DataColumn("Descripcion"));

        dr = dt.NewRow();
        dr[0] = 0;
        dr[1] = "Seleccionar";
        dt.Rows.Add(dr);

        while (datareader.Read())
        {
            try
            {

                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodEstado"];
                dr[1] = (System.String)datareader["Descripcion"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;

    }

    public void GetDropdownInstituciones()
    {

    }

    public void getDropdownRegionTribunal()
    {

    }

    public string formatearRut(string rut)
    {
        int cont = 0;
        string format;
        if (rut.Length == 0)
        {
            return "";
        }
        else
        {
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            format = "-" + rut.Substring(rut.Length - 1);
            for (int i = rut.Length - 2; i >= 0; i--)
            {
                format = rut.Substring(i, 1) + format;
                cont++;
                if (cont == 3 && i != 0)
                {
                    format = "." + format;
                    cont = 0;
                }
            }
            return format;
        }
    }

    public void CargoDropDowns()
    {

        #region Instituciones
        DataSet ds = (DataSet)Session["dsParametricas"];
        institucioncoll icoll = new institucioncoll();

        //        DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));  DPL 14-08-2015
        //        DataTable dtinst = icoll.GetData_DataSet((DataSet)Session["dsParametricas"]);
        DataTable dtinst = ds.Tables["dtInstituciones"];

        DataView dv1 = new DataView(dtinst);
        dv1.Sort = "Nombre ASC";
        ddown_Institucion.DataSource = dv1;
        ddown_Institucion.DataTextField = "Nombre";
        ddown_Institucion.DataValueField = "CodInstitucion";

        ddown_Institucion.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dtinst.Rows.Count > 0)
            ddown_Institucion.SelectedIndex = 1;

        // <---------- DPL ---------->  09-08-2010

        #endregion

        #region RegionTribunal
        LRPAcoll LRPA = new LRPAcoll();
        parcoll par = new parcoll();
        coordinador cr = new coordinador();
        string sqlu = "Select codregion,coddireccionregional From usuarios WHERE idusuario =" + Session["IdUsuario"].ToString();
        DataTable dt = cr.ejecuta_SQL(sqlu, null);

        //DataView dv13 = new DataView(par.GetparRegion());
        DataView dv13 = new DataView(ds.Tables["dtparRegion"]);
        dv13.Sort = "CodigoRegion ASC";

        //llenando el primer dropdown que usa region
        ddown_RegionTribunal.DataSource = dv13;
        ddown_RegionTribunal.DataTextField = "Descripcion";
        ddown_RegionTribunal.DataValueField = "CodRegion";
        ddown_RegionTribunal.DataBind();
        #endregion

        //hasta aqui

        //aqui seleccionare la region dependiendo del ID del usuario conectado (para ambos casos anteriores)
        //ddown_RegionTribunal.SelectedValue = dt.Rows[0][0].ToString();

        //hasta aqui


        //llenando dropdown de Tipo de Tribunal
        //ddown_TipoTribunal.Items.Clear();
        //DataView dv15 = new DataView(LRPA.GetparTipoTribunalLRPA());


        //ddown_TipoTribunal.DataSource = dtpttta;
        //ddown_TipoTribunal.DataTextField = "Descripcion";
        //ddown_TipoTribunal.DataValueField = "TipoTribunal";
        //dv15.Sort = "Descripcion";
        //ddown_TipoTribunal.DataBind();


        //parTipoTribunalesTableAdapter pttta = new parTipoTribunalesTableAdapter();

        //DataTable dtpttta = pttta.GetTipo_Tribunales_LE();

        // DPL 17-08-2015
        #region TipoTribunal
        DataTable dtparTipoTribunal = ds.Tables["dtparTipoTribunal"];
        dtparTipoTribunal.Select("Descripcion <> 'SIN INFORMACION'");
        ddown_TipoTribunal.DataSource = ds.Tables["dtparTipoTribunal"];
        ddown_TipoTribunal.DataTextField = "Descripcion";
        ddown_TipoTribunal.DataValueField = "TipoTribunal";
        ddown_TipoTribunal.DataBind();
        #endregion


        #region Código Eliminado TipoTribunal
        //string strSQL = Resources.Procedures.GetparTipoTribunal + "and  Descripcion <> 'SIN INFORMACION'";

        //DataTable dtpttta = cr.ejecuta_SQL(strSQL);

        //DataTable dtTemp_tipo = new DataTable();
        //dtTemp_tipo.Columns.Add("TipoTribunal");
        //dtTemp_tipo.Columns.Add("Descripcion");

        //DataRow drTemp_Tipo;
        //drTemp_Tipo = dtTemp_tipo.NewRow();
        //drTemp_Tipo[0] = "0";
        //drTemp_Tipo[1] = "Seleccionar";
        //dtTemp_tipo.Rows.Add(drTemp_Tipo);

        //for (int n = 0; n <= dtpttta.Rows.Count; n++)
        //{
        //    try
        //    {
        //        drTemp_Tipo = dtTemp_tipo.NewRow();
        //        drTemp_Tipo[0] = Convert.ToString(dtpttta.Rows[n]["TipoTribunal"]);
        //        drTemp_Tipo[1] = Convert.ToString(dtpttta.Rows[n]["Descripcion"]);
        //        dtTemp_tipo.Rows.Add(drTemp_Tipo);
        //    }
        //    catch
        //    {
        //    }
        //}

        //if (dtTemp_tipo.Rows.Count > 0)
        //{
        //    ddown_TipoTribunal.DataSource = dtTemp_tipo;
        //    ddown_TipoTribunal.DataTextField = "Descripcion";
        //    ddown_TipoTribunal.DataValueField = "TipoTribunal";
        //    ddown_TipoTribunal.DataBind();
        //}
        #endregion
        // DPL 17-08-2015

        //llenando dropdown de Tipo de Causal de Ingreso
        #region Código eliminado TipoCausalIngreso
        //parTipoCausalesIngresoTableAdapter tipoCausal = new parTipoCausalesIngresoTableAdapter();
        //DataTable dtTipoCausal = tipoCausal.GetData();
        //DataTable dtTemp1 = new DataTable();
        //dtTemp1.Columns.Add("CodTipoCausalIngreso");
        //dtTemp1.Columns.Add("Descripcion");

        //DataRow drTemp1;
        //drTemp1 = dtTemp1.NewRow();
        //drTemp1[0] = "0";
        //drTemp1[1] = "Seleccionar";
        //dtTemp1.Rows.Add(drTemp1);

        //for (int i = 0; i <= dtTipoCausal.Rows.Count; i++)
        //{
        //    try
        //    {
        //        drTemp1 = dtTemp1.NewRow();
        //        drTemp1[0] = Convert.ToString(dtTipoCausal.Rows[i]["CodTipoCausalIngreso"]);
        //        drTemp1[1] = Convert.ToString(dtTipoCausal.Rows[i]["Descripcion"]);
        //        dtTemp1.Rows.Add(drTemp1);
        //    }
        //    catch
        //    {
        //    }
        //}
        #endregion
        //if (dtTipoCausal.Rows.Count > 0)
        //DataTable dtparTipoCausal = ds.Tables["parTipoCausalIngreso"];


        #region TipoCausal
        if (Request.QueryString["IngresoLE"] == null)
        {
            DataView dv15 = new DataView(par.GetparTipoCausalIngreso(SSnino.CodProyecto));

            if (dv15.Count > 0)
            {
                ddown_TipoCausal.DataSource = dv15;
                ddown_TipoCausal.DataTextField = "Descripcion";
                ddown_TipoCausal.DataValueField = "CodTipoCausalIngreso";
                ddown_TipoCausal.DataBind();
                cargocausal(Convert.ToInt32(ddown_TipoCausal.SelectedValue));

            }
        }
        else
        {
            DataView dv15 = new DataView(par.GetparTipoCausalIngreso(SSnino.CodProyecto));

            if (dv15.Count > 0)
            {
                ddown_TipoCausal.DataSource = dv15;
                ddown_TipoCausal.DataTextField = "Descripcion";
                ddown_TipoCausal.DataValueField = "CodTipoCausalIngreso";
                ddown_TipoCausal.DataBind();
                cargocausal(Convert.ToInt32(ddown_TipoCausal.SelectedValue));
            }
        }
        #endregion


        parCausalesIngresoTableAdapter caulrpa = new parCausalesIngresoTableAdapter();
        DataTable dtcausal = caulrpa.Get_PorTipo(Convert.ToInt32(ddown_TipoCausal.SelectedValue));

        if (dtcausal.Rows.Count == 0)
        {
            DataRow dr = dtcausal.NewRow();

            dr[0] = "0";
            dr[1] = "0";
            dr[2] = "Seleccionar";
            dr[3] = "V";
            dr[4] = "0";
            dr[5] = "0";

            dtcausal.Rows.Add(dr);

            ddown_Causal.Items.Clear();
            ddown_Causal.DataSource = dtcausal;
            ddown_Causal.DataValueField = "CodCausalIngreso";
            ddown_Causal.DataTextField = "Descripcion";
            ddown_Causal.DataBind();
        }
        else
        {
            ddown_Causal.Items.Clear();
            ddown_Causal.DataSource = dtcausal;
            ddown_Causal.DataValueField = "CodCausalIngreso";
            ddown_Causal.DataTextField = "Descripcion";
            ddown_Causal.DataBind();
        }



        #region TipoSolicitante
        //llenando dropdown del Tipo Solicitante
        parSolicitantesTableAdapter solicitante = new parSolicitantesTableAdapter();
        DataTable dtsolicitante = solicitante.GetParSolicitante();

        DataTable dtTempSolicitante = new DataTable();
        dtTempSolicitante.Columns.Add("CodSolicitanteIngreso");
        dtTempSolicitante.Columns.Add("Descripcion");

        DataRow drTempSolicitante;
        drTempSolicitante = dtTempSolicitante.NewRow();
        drTempSolicitante[0] = "0";
        drTempSolicitante[1] = "Seleccionar";
        dtTempSolicitante.Rows.Add(drTempSolicitante);

        for (int l = 0; l <= dtsolicitante.Rows.Count; l++)
        {
            try
            {
                drTempSolicitante = dtTempSolicitante.NewRow();
                drTempSolicitante[0] = Convert.ToString(dtsolicitante.Rows[l]["CodSolicitanteIngreso"]);
                drTempSolicitante[1] = Convert.ToString(dtsolicitante.Rows[l]["Descripcion"]);
                dtTempSolicitante.Rows.Add(drTempSolicitante);
            }
            catch
            {
            }
        }

        if (dtsolicitante.Rows.Count > 0)
        {
            ddown_solicitante.DataSource = dtTempSolicitante;
            ddown_solicitante.DataTextField = "Descripcion";
            ddown_solicitante.DataValueField = "CodSolicitanteIngreso";
            ddown_solicitante.DataBind();
        }
        #endregion


        //hasta aqui dropdown tipo solicitante


        //llenando dropdown de las regiones
        #region Código eliminado DPL 14-08-2015
        //parRegionTableAdapter region = new parRegionTableAdapter();
        //DataTable dtregion = region.GetRegiones();

        //DataTable dtTempRegion = new DataTable();
        //dtTempRegion.Columns.Add("CodRegion");
        //dtTempRegion.Columns.Add("Descripcion");

        //DataRow drTempRegion;
        //drTempRegion = dtTempRegion.NewRow();
        //drTempRegion[0] = "0";
        //drTempRegion[1] = "Seleccionar";
        //dtTempRegion.Rows.Add(drTempRegion);

        //for (int m = 0; m <= dtregion.Rows.Count; m++)
        //{
        //    try
        //    {
        //        drTempRegion = dtTempRegion.NewRow();
        //        drTempRegion[0] = Convert.ToString(dtregion.Rows[m]["CodRegion"]);
        //        drTempRegion[1] = Convert.ToString(dtregion.Rows[m]["Descripcion"]);
        //        dtTempRegion.Rows.Add(drTempRegion);
        //    }
        //    catch
        //    {
        //    }
        //}
        #endregion

        #region Region
        if (dv13.Count > 0)
        {
            ddown_region.DataSource = dv13;
            ddown_region.DataTextField = "Descripcion";
            ddown_region.DataValueField = "CodRegion";
            ddown_region.DataBind();
        }
        #endregion

        //hasta aqui dropdown Region

        // parNacionalidades
        //parNacionalidadesTableAdapter nac = new parNacionalidadesTableAdapter();
        //DataTable dtNac = nac.GetData();

        #region Nacionalidad

        DataView dtNac = new DataView(par.GetparNacionalidades());
        ddown_nacionalidad.DataSource = dtNac;
        ddown_nacionalidad.DataTextField = "Descripcion";
        ddown_nacionalidad.DataValueField = "CodNacionalidad";
        dtNac.Sort = "CodNacionalidad";
        ddown_nacionalidad.DataBind();

        for (int i = 1; i <= ddown_nacionalidad.Items.Count - 1; i++)
        {
            if (ddown_nacionalidad.Items[i] != null) // el 8 no existe
            {
                ddown_nacionalidad.Items[i].Enabled = false;
                //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
            }
        }
        ddown_nacionalidad.SelectedValue = "0";



        //DataTable dtNac = ds.Tables["dtparNacionalidades"];
        //if (dtNac.Rows.Count > 0)
        //{
        //    ddown_nacionalidad.Items.Clear();
        //    ddown_nacionalidad.Items.Add(new ListItem("SELECCIONAR", "0"));
        //    ddown_nacionalidad.DataSource = dtNac;
        //    ddown_nacionalidad.DataValueField = "CodNacionalidad";
        //    ddown_nacionalidad.DataTextField = "Descripcion";
        //    ddown_nacionalidad.DataBind();

        //}
        #endregion

        #region TipoNacionalidad
        DataView dv2 = new DataView((GetParTipoNacionalidad()));
        ddown_tipo_nacionalidad.DataSource = dv2;
        ddown_tipo_nacionalidad.DataTextField = "Descripcion";
        ddown_tipo_nacionalidad.DataValueField = "CodTipoNacionalidad";
        dv2.Sort = "CodTipoNacionalidad";
        ddown_tipo_nacionalidad.DataBind();
        #endregion
        // parNacionalidades

        #region Tribunal
        parTribunalesTableAdapter trib = new parTribunalesTableAdapter();
        DataTable dtTrib = trib.GetTribunales(Convert.ToInt32(ddown_TipoTribunal.SelectedValue), Convert.ToInt32(ddown_RegionTribunal.SelectedValue));

        DataTable dtTempTribunal = new DataTable();
        dtTempTribunal.Columns.Add("CodTribunal");
        dtTempTribunal.Columns.Add("Descripcion");

        DataRow drTempTribunal;
        drTempTribunal = dtTempTribunal.NewRow();
        drTempTribunal[0] = "0";
        drTempTribunal[1] = "Seleccionar";
        dtTempTribunal.Rows.Add(drTempTribunal);

        for (int i = 0; i <= dtTrib.Rows.Count; i++)
        {
            try
            {
                drTempTribunal = dtTempTribunal.NewRow();
                drTempTribunal[0] = Convert.ToString(dtTrib.Rows[i]["CodTribunal"]);
                drTempTribunal[1] = Convert.ToString(dtTrib.Rows[i]["Descripcion"]);
                dtTempTribunal.Rows.Add(drTempTribunal);
            }
            catch
            {
            }
        }
        if (dtTrib.Rows.Count > 0)
        {
            ddown_Tribunal.Items.Clear();
            ddown_Tribunal.DataSource = dtTempTribunal;
            ddown_Tribunal.DataValueField = "CodTribunal";
            ddown_Tribunal.DataTextField = "Descripcion";
            ddown_Tribunal.DataBind();
        }
        #endregion

        getparLugarFallecimiento();
        getparRegion();

    }

    private void getparLugarFallecimiento()
    {
        ninocoll ncoll = new ninocoll();
        DataView dv = new DataView(ncoll.GetparLugarFallecimiento());
        ddlLugarFallecimiento.Items.Clear();
        ddlLugarFallecimiento.DataSource = dv;
        ddlLugarFallecimiento.DataTextField = "Descripcion";
        ddlLugarFallecimiento.DataValueField = "CodLugarFallecimiento";
        dv.Sort = "CodLugarFallecimiento";
        ddlLugarFallecimiento.DataBind();
    }

    private void getparRegion()
    {
        parcoll pcoll = new parcoll();
        DataView dv = new DataView(pcoll.GetparRegion());
        ddlRegionFallecimiento.Items.Clear();
        ddlRegionFallecimiento.DataSource = dv;
        ddlRegionFallecimiento.DataTextField = "Descripcion";
        ddlRegionFallecimiento.DataValueField = "CodRegion";
        dv.Sort = "CodRegion";
        ddlRegionFallecimiento.DataBind();
    }

    private DataTable GetParTipoNacionalidad()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataReader reader;

            string consulta = "select CodTipoNacionalidad, Descripcion from parTipoNacionalidad where IndVigencia = 'V'";
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            dt.Load(reader);

            // Data is accessible through the DataReader object here.
            sqlConnection1.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;

    }

    public void cargocausal(int CodCausalIngreso)
    {
        ddown_Causal.Items.Clear();
        parCausalesIngresoTableAdapter caulrpa = new parCausalesIngresoTableAdapter();
        DataTable dtcausal = caulrpa.Get_PorTipo(Convert.ToInt32(CodCausalIngreso));
        DataRow dr = dtcausal.NewRow();

        if (dtcausal.Rows.Count == 0)
        {

            dr[0] = "0";
            dr[1] = "0";
            dr[2] = "Seleccionar";
            dr[3] = "V";
            dr[4] = "0";
            dr[5] = "0";

            dtcausal.Rows.Add(dr);
        }

        ddown_Causal.DataSource = dtcausal;
        ddown_Causal.DataValueField = "CodCausalIngreso";
        ddown_Causal.DataTextField = "Descripcion";
        ddown_Causal.DataBind();



        //DataTable dtTemp1 = new DataTable();
        //dtTemp1.Columns.Add("CodCausalIngreso");
        //dtTemp1.Columns.Add("Descripcion");

        //DataRow drTemp1;
        //drTemp1 = dtTemp1.NewRow();
        //drTemp1[0] = "0";
        //drTemp1[1] = "Seleccionar";
        //dtTemp1.Rows.Add(drTemp1);

        //if (dtcausal.Rows.Count > 0)
        //{
        //    for (int i = 1; i <= dtcausal.Rows.Count; i++)
        //    {
        //        try
        //        {
        //            drTemp1 = dtTemp1.NewRow();
        //            drTemp1[0] = Convert.ToString(dtcausal.Rows[i]["CodCausalIngreso"]);
        //            drTemp1[1] = Convert.ToString(dtcausal.Rows[i]["Descripcion"]);
        //            dtTemp1.Rows.Add(drTemp1);
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}
        //if (dtTemp1.Rows.Count > 1)
        //{
        //    try
        //    {
        //        ddown_Causal.Items.Clear();
        //        ddown_Causal.DataSource = dtTemp1;
        //        ddown_Causal.DataValueField = "CodCausalIngreso";
        //        ddown_Causal.DataTextField = "Descripcion";
        //        ddown_Causal.DataBind();

        //        //parCausalesIngresoLRPA1TableAdapter traigocausales = new parCausalesIngresoLRPA1TableAdapter();
        //        //DataTable dtcausales = traigocausales.Get_Xcodcausal(Convert.ToInt32(ddown_TipoCausal.SelectedValue));
        //        //if (dtcausales.Rows.Count > 0)
        //        //{
        //        //    //txt_codDelito.Text = dtcausales.Rows[0]["CodNumCausal"].ToString();
        //        //}
        //        ////CargoDelito();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //else
        //{
        //    ddown_Causal.Items.Clear();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("CodCausalIngreso");
        //    dt.Columns.Add("Descripcion");
        //    DataRow dr = dt.NewRow();

        //    dr[0] = "0";
        //    dr[1] = "No disponible";

        //    dt.Rows.Add(dr);

        //    ddown_Causal.DataSource = dt;
        //    ddown_Causal.DataValueField = "CodCausalIngreso";
        //    ddown_Causal.DataTextField = "Descripcion";
        //    ddown_Causal.DataBind();
        //}
    }
    //protected void txt_rut_ValueChange(object sender, EventArgs e)
    //{
    //    if (txt_rut.Text.Trim() != "")
    //    {
    //        txt_rut.BackColor = System.Drawing.Color.Empty;
    //        lblErrorRut.Visible = false;
    //        btn_agregar.Visible = true;
    //        try
    //        {
    //            if (txt_rut.Text.Length > 3)
    //            {
    //                string rutsinnada = txt_rut.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1); //aca comienso a buscar usuario

    //                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //                {
    //                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                    txt_rut.Text = rcompleto;
    //                    lbl_exito.Visible = false;
    //                    Function_Consulta();
    //                }
    //                else
    //                {
    //                    txt_rut.Text = "";
    //                    lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
    //                    lblErrorRut.Visible = true;
    //                    btn_agregar.Visible = false;
    //                }
    //            }
    //            else
    //            {
    //                txt_rut.Text = "";
    //                lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
    //                lblErrorRut.Visible = true;
    //                btn_agregar.Visible = false;
    //            }
    //        }
    //        catch
    //        {
    //            lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
    //            lblErrorRut.Visible = true;
    //            btn_agregar.Visible = false;
    //        }
    //    }
    //    else
    //    {
    //        if (rdblist_nacionalidad.SelectedValue == "Chileno")
    //        {
    //            lblErrorRut.Text = "EL INGRESO DEL RUT ES OBLIGATORIO";
    //            txt_rut.BackColor = Color.Pink;
    //            lblErrorRut.Visible = true;
    //            btn_agregar.Visible = false;
    //        }
    //    }
    //}
    private string digitoVerificador(int rut)
    {
        int Digito;
        int Contador;
        int Multiplo;
        int Acumulador;
        string RutDigito;

        Contador = 2;
        Acumulador = 0;

        while (rut != 0)
        {
            Multiplo = (rut % 10) * Contador;
            Acumulador = Acumulador + Multiplo;
            rut = rut / 10;
            Contador = Contador + 1;
            if (Contador == 8)
            {
                Contador = 2;
            }

        }

        Digito = 11 - (Acumulador % 11);
        RutDigito = Digito.ToString().Trim();
        if (Digito == 10)
        {
            RutDigito = "K";
        }
        if (Digito == 11)
        {
            RutDigito = "0";
        }
        return (RutDigito);
    }
    protected void grd004_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd004.PageIndex = e.NewPageIndex;
        carga_grilla();
    }
    public void carga_grilla()
    {
        DataView dv = new DataView(DTBusqueda);
        dv.Sort = "Apellido_paterno, Apellido_Materno, Nombres";
        grd004.DataSource = dv;
        grd004.DataBind();
        grd004.Visible = true;
    }
    protected void txt_ruc_ValueChange(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
        if ((String)txt_ruc.Text == "") return;

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
            txt_ruc.BackColor = System.Drawing.Color.Empty;
        }
    }
    protected void grd004_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ver")
        {
            try
            {
                lbl_CodNino.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                txt_rut.Text = (grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
                txt_ap_paterno.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                txt_ap_materno.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                rdbl_sexo.SelectedValue = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                txt_nombres.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                wdc_Fnacimiento.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text.Substring(0, 10);
                grd004.Visible = false;

                NinosTableAdapter busconino = new NinosTableAdapter();
                DataTable dtnino = busconino.Get_nino_xcod(Convert.ToInt32(lbl_CodNino.Text));
                ddown_nacionalidad.SelectedValue = dtnino.Rows[0]["CodNacionalidad"].ToString();

                DeshabilitoCajas();
                HabilitoControles();
                tblDatos.Visible = true;

                txt_rut.Enabled = false;
                //if (txt_rut.Text == "0" && grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text != "")
                //{
                //    txt_rut.Enabled = true;
                //}
                //else
                //{
                //    txt_rut.Enabled = false;
                //}

            }
            catch (Exception ex)
            {

            }
        }
    }
    public void HabilitoCajas()
    {
        txt_rut.Enabled = true;
        txt_nombres.Enabled = true;
        txt_ap_paterno.Enabled = true;
        txt_ap_materno.Enabled = true;
        rdbl_sexo.Enabled = true;
        wdc_Fnacimiento.Enabled = true;
        ddown_nacionalidad.Enabled = true;
        ddown_tipo_nacionalidad.Enabled = true;
    }

    public void DeshabilitoCajas()
    {
        //txt_rut.Enabled = false;
        txt_nombres.Enabled = false;
        txt_ap_paterno.Enabled = false;
        txt_ap_materno.Enabled = false;
        rdbl_sexo.Enabled = false;
        wdc_Fnacimiento.Enabled = false;
        ddown_nacionalidad.Enabled = false;
        ddown_tipo_nacionalidad.Enabled = false;
    }
    private void Function_Consulta()
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sParametrosConsulta = string.Empty;
        if (txt_rut.Text.Trim() != string.Empty)
        {
            sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                                   "T2.FechaNacimiento, T2.CodNacionalidad, T2.CodTipoNacionalidad From Ninos T2 ";

            if (txt_rut.Text.Trim() != "" || txt_ap_paterno.Text.Trim() != "" ||
                    txt_ap_materno.Text.Trim() != "" || txt_nombres.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + "Where ";
            }

            sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt_rut.Text.Trim().Replace(".", "")));

        }
        else
        {
            sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                                   "T2.FechaNacimiento, T2.CodNacionalidad, T2.CodTipoNacionalidad From Ninos T2 ";

            if (txt_rut.Text.Trim() != "" || txt_ap_paterno.Text.Trim() != "" ||
                    txt_ap_materno.Text.Trim() != "" || txt_nombres.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + "Where ";
            }

            if (txt_ap_paterno.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt_ap_paterno.Text + "%"));
            }
            if (txt_ap_materno.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt_ap_materno.Text + "%"));
            }
            if (txt_nombres.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt_nombres.Text + "%"));
            }
            if (txt_rut.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

                listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt_rut.Text.Trim().Replace(".", "")));
            }

            if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            {
                sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
            }
        }

        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, listDbParameter);

        if (dt.Rows.Count == 1)
        {
            lnk_resultados.Visible = false;
            lnk_resultados.Visible = false;
            lbl_encontrados.Visible = false;
            lbl001.Visible = false;
            lbl_error.Visible = false;

            //if (dt.Rows[0]["Rut"].ToString() == "0")
            //{
            //    txt_rut.Text = string.Empty;
            //    rdblist_nacionalidad.SelectedValue = "Extranjero";
            //}
            //else
            //{
            //    txt_rut.Text = Convert.ToString(dt.Rows[0]["Rut"]);
            //    rdblist_nacionalidad.SelectedValue = "Chileno";
            //}

            txt_nombres.Text = Convert.ToString(dt.Rows[0]["Nombres"]);
            txt_ap_paterno.Text = Convert.ToString(dt.Rows[0]["Apellido_paterno"]);
            txt_ap_materno.Text = Convert.ToString(dt.Rows[0]["Apellido_materno"]);
            rdbl_sexo.SelectedValue = Convert.ToString(dt.Rows[0]["Sexo"]);
            wdc_Fnacimiento.Text = Convert.ToString(dt.Rows[0]["FechaNacimiento"]).Substring(0, 10);
            ddown_tipo_nacionalidad.SelectedValue = Convert.ToString(dt.Rows[0]["CodTipoNacionalidad"]);
            //CargaNacionalidad();
            CargarNacionalidad();
            ddown_nacionalidad.SelectedValue = Convert.ToString(dt.Rows[0]["CodNacionalidad"]);
            lbl_CodNino.Text = dt.Rows[0]["CodNino"].ToString();
            grd004.Visible = false;
            DeshabilitoCajas();
            HabilitoControles();
            tblDatos.Visible = true;
            tblBusquedaRut.Visible = true;
            txt_rut.Enabled = false;
            ImageButton1.Attributes.Add("disabled", "disabled");
        }

        else if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            HabilitoCajas();
            //lnk_resultados.Visible = true;
            //lbl_encontrados.Text = dt.Rows.Count.ToString();
            //lbl_encontrados.Visible = true;
            //lbl001.Visible = true;
            lbl_error.Visible = false;
            DTBusqueda = dt;
            carga_grilla();
        }
        else if (dt.Rows.Count == 0)
        {
            HabilitoCajas();
            lnk_resultados.Visible = false;
            lnk_resultados.Visible = false;
            lbl_encontrados.Visible = false;
            lbl001.Visible = false;
            lbl_error.Visible = true;
            lbl_error.Text = "No se encontraron coincidencias, sin embargo, puede ingresar al niño(a)";
            grd004.Visible = false;
            HabilitoControles();
            tblDatos.Visible = true;
            ImageButton1.Attributes.Add("disabled", "disabled");
            ImageButton1.Visible = false;

        }
        else if (dt.Rows.Count > 200)
        {
            HabilitoCajas();
            lnk_resultados.Visible = false;
            lnk_resultados.Visible = false;
            lbl_encontrados.Visible = false;
            lbl001.Visible = false;
            lbl_error.Visible = true;
            lbl_error.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
            grd004.Visible = false;
        }
    }

    private void Function_ConsultaLE(int cod_nino)
    {
        string sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                               "T2.FechaNacimiento, T2.CodNacionalidad, T2.CodTipoNacionalidad From Ninos T2 Where T2.CodNino = " + cod_nino.ToString();

        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, null);

        if (dt.Rows.Count == 1)
        {
            lnk_resultados.Visible = false;
            lnk_resultados.Visible = false;
            lbl_encontrados.Visible = false;
            lbl001.Visible = false;
            lbl_error.Visible = false;

            if (dt.Rows[0]["Rut"].ToString() == "0")
            {
                txt_rut.Text = string.Empty;
                rdblist_nacionalidad.SelectedValue = "Extranjero";
                txt_rut.Enabled = false;
                rdblist_nacionalidad.Enabled = false;
            }
            else
            {
                txt_rut.Text = Convert.ToString(dt.Rows[0]["Rut"]);
                rdblist_nacionalidad.SelectedValue = "Chileno";
                txt_rut.Enabled = false;
                rdblist_nacionalidad.Enabled = false;
            }

            txt_nombres.Text = Convert.ToString(dt.Rows[0]["Nombres"]);
            txt_ap_paterno.Text = Convert.ToString(dt.Rows[0]["Apellido_paterno"]);
            txt_ap_materno.Text = Convert.ToString(dt.Rows[0]["Apellido_materno"]);
            rdbl_sexo.SelectedValue = Convert.ToString(dt.Rows[0]["Sexo"]);
            if (Convert.ToString(dt.Rows[0]["FechaNacimiento"]) != string.Empty)
            {
                wdc_Fnacimiento.Text = Convert.ToString(dt.Rows[0]["FechaNacimiento"]).Substring(0, 10);
            }
            else
            {
                wdc_Fnacimiento.Text = "1900/01/01";
            }
            ddown_tipo_nacionalidad.SelectedValue = Convert.ToString(dt.Rows[0]["CodTipoNacionalidad"]);
            //CargaNacionalidad();
            CargarNacionalidad();
            ddown_nacionalidad.SelectedValue = Convert.ToString(dt.Rows[0]["CodNacionalidad"]);
            lbl_CodNino.Text = dt.Rows[0]["CodNino"].ToString();
            grd004.Visible = false;
            DeshabilitoCajas();
        }
    }

    public void HabilitoControles()
    {
        if (rdblist_nacionalidad.SelectedValue == "Chileno")
        {
            ddown_nacionalidad.Enabled = false;
        }
        else
        {
            ddown_nacionalidad.Enabled = true;
        }
        ddown_region.Enabled = true;
        ddown_comuna.Enabled = true;
        ddown_solicitante.Enabled = true;
        wdc_Flistaespera.Enabled = true;
        ddown_RegionTribunal.Enabled = true;
        ddown_TipoTribunal.Enabled = true;
        ddown_Tribunal.Enabled = true;
        txt_ruc.Enabled = true;
        txt_rit.Enabled = true;
        wdc_fecha.Enabled = true;
        ddown_TipoCausal.Enabled = true;
        ddown_Causal.Enabled = true;
        btn_agregar.Enabled = true;
    }


    protected void rdblist_rut_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblist_nacionalidad.SelectedValue == "Extranjero")
        {
            txt_rut.Text = string.Empty;
            txt_rut.Enabled = false;
            ddown_nacionalidad.Enabled = true;
            ddown_nacionalidad.Items.FindByValue("1").Enabled = false;

            if (ddown_nacionalidad.Items.FindByValue("2").Enabled == false)
            {
                for (int i = 2; i <= 40; i++)
                {
                    if (i != 8)
                    {
                        ddown_nacionalidad.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                    }
                }
            }
        }
        if (rdblist_nacionalidad.SelectedValue == "Chileno")
        {
            if (ddown_nacionalidad.Items.FindByValue("2").Enabled == true)
            {
                for (int i = 2; i <= 40; i++)
                {
                    if (i != 8)
                    {
                        ddown_nacionalidad.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                    }
                }
            }
            txt_rut.Enabled = true;
            ddown_nacionalidad.Enabled = false;
            ddown_nacionalidad.Items.FindByValue("1").Enabled = true;
            ddown_nacionalidad.Items.FindByValue("1").Selected = true;
        }
    }
    protected void ddown_TipoTribunal_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GetTribunales();
    }
    protected void ddown_TipoCausal_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cargocausal();

        parcoll par = new parcoll();
        DataView dv16 = new DataView(par.GetparCausalesIngreso((ddown_TipoCausal.SelectedValue).ToString(), SSnino.CodProyecto));

        ddown_Causal.Items.Clear();
        ddown_Causal.DataSource = dv16;
        ddown_Causal.DataValueField = "CodCausalIngreso";
        ddown_Causal.DataTextField = "Descripcion";
        ddown_Causal.DataBind();


    }


    public void GetTribunales()
    {
        parTribunalesTableAdapter trib = new parTribunalesTableAdapter();
        DataTable dtTrib = trib.GetTribunales(Convert.ToInt32(ddown_TipoTribunal.SelectedValue), Convert.ToInt32(ddown_RegionTribunal.SelectedValue));

        DataTable dtTempTribunal = new DataTable();
        dtTempTribunal.Columns.Add("CodTribunal");
        dtTempTribunal.Columns.Add("Descripcion");

        DataRow drTempTribunal;
        drTempTribunal = dtTempTribunal.NewRow();
        drTempTribunal[0] = "0";
        drTempTribunal[1] = "Seleccionar";
        dtTempTribunal.Rows.Add(drTempTribunal);

        for (int i = 0; i <= dtTrib.Rows.Count; i++)
        {
            try
            {
                drTempTribunal = dtTempTribunal.NewRow();
                drTempTribunal[0] = Convert.ToString(dtTrib.Rows[i]["CodTribunal"]);
                drTempTribunal[1] = Convert.ToString(dtTrib.Rows[i]["Descripcion"]);
                dtTempTribunal.Rows.Add(drTempTribunal);
            }
            catch
            {
            }
        }
        if (dtTrib.Rows.Count > 0)
        {
            ddown_Tribunal.Items.Clear();
            ddown_Tribunal.DataSource = dtTempTribunal;
            ddown_Tribunal.DataValueField = "CodTribunal";
            ddown_Tribunal.DataTextField = "Descripcion";
            ddown_Tribunal.DataBind();
        }
    }
    protected void ddown_RegionTribunal_SelectedIndexChanged1(object sender, EventArgs e)
    {
        parTribunalesTableAdapter trib = new parTribunalesTableAdapter();
        DataTable dtTrib = trib.GetTribunales(Convert.ToInt32(ddown_TipoTribunal.SelectedValue), Convert.ToInt32(ddown_RegionTribunal.SelectedValue));

        DataTable dtTempTribunal = new DataTable();
        dtTempTribunal.Columns.Add("CodTribunal");
        dtTempTribunal.Columns.Add("Descripcion");

        DataRow drTempTribunal;
        drTempTribunal = dtTempTribunal.NewRow();
        drTempTribunal[0] = "0";
        drTempTribunal[1] = "Seleccionar";
        dtTempTribunal.Rows.Add(drTempTribunal);

        for (int i = 0; i <= dtTrib.Rows.Count; i++)
        {
            try
            {
                drTempTribunal = dtTempTribunal.NewRow();
                drTempTribunal[0] = Convert.ToString(dtTrib.Rows[i]["CodTribunal"]);
                drTempTribunal[1] = Convert.ToString(dtTrib.Rows[i]["Descripcion"]);
                dtTempTribunal.Rows.Add(drTempTribunal);
            }
            catch
            {
            }
        }
        if (dtTrib.Rows.Count > 0)
        {
            ddown_Tribunal.Items.Clear();
            ddown_Tribunal.DataSource = dtTempTribunal;
            ddown_Tribunal.DataValueField = "CodTribunal";
            ddown_Tribunal.DataTextField = "Descripcion";
            ddown_Tribunal.DataBind();
        }
    }
    private DataTable callto_guardo_listaespera(int CodNino, int ICodIE, DateTime FechaIngresoLE, DateTime FechaEgresoLE, int CodTribunal, string RUC, string RIT, DateTime FechaOrden,
        int CodCausalIngreso, int CodProyecto, int IdUsuarioActualizacion, DateTime FechaActualizacion, int Estado, int CodComuna, int CodSolicitante)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_Ninos_Lista_Espera";
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@FechaIngresoLE", SqlDbType.DateTime).Value = FechaIngresoLE;
        sqlc.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = FechaEgresoLE;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = CodTribunal;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int).Value = CodComuna;
        sqlc.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = CodSolicitante;
        sqlc.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = RUC;
        sqlc.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = RIT;
        sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = FechaOrden;
        sqlc.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = CodCausalIngreso;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = FechaActualizacion;
        sqlc.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private int guardaListaEspera(NinoListaEspera ninoLE)
    {
        int resultado = 0;
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("Insert_Ninos_Lista_Espera", sqlc);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "Insert_Ninos_Lista_Espera";
        command.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = ninoLE.CodNino;
        command.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ninoLE.ICodIE;
        command.Parameters.Add("@FechaIngresoLE", SqlDbType.DateTime).Value = ninoLE.FechaIngresoListaEspera;
        command.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = ninoLE.FechaEgresoListaEspera;
        command.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = ninoLE.CodTribunal;
        command.Parameters.Add("@CodComuna", SqlDbType.Int).Value = ninoLE.CodComuna;
        command.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = ninoLE.CodSolicitanteIngreso;
        command.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = ninoLE.RUC;
        command.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = ninoLE.RIT;
        command.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = ninoLE.FechaOrden;
        command.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = ninoLE.CodCausalIngreso;
        command.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = ninoLE.CodProyecto;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = ninoLE.IdUsuarioActualizacion;
        command.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = ninoLE.FechaActualizacion;
        command.Parameters.Add("@Estado", SqlDbType.Int).Value = ninoLE.CodEstado;

        command.Connection.Open();

        resultado = Convert.ToInt32(command.ExecuteScalar());

        command.Connection.Close();

        return resultado;
    }

    //private int guardaListaEspera(SqlTransaction sqlt, SqlConnection sqlc, int CodNino, int ICodIE, DateTime FechaIngresoLE, DateTime FechaEgresoLE, int CodTribunal, string RUC, string RIT, DateTime FechaOrden,
    //    int CodCausalIngreso, int CodProyecto, int IdUsuarioActualizacion, DateTime FechaActualizacion, int Estado, int CodComuna, int CodSolicitante)
    //{
    //    int IngresoCorrecto = 0;

    //    SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
    //    sqlc.Connection = sconn;
    //    sqlc.CommandType = System.Data.CommandType.StoredProcedure;
    //    sqlc.CommandText = "Insert_Ninos_Lista_Espera";
    //    sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
    //    sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
    //    sqlc.Parameters.Add("@FechaIngresoLE", SqlDbType.DateTime).Value = FechaIngresoLE;
    //    sqlc.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = FechaEgresoLE;
    //    sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = CodTribunal;
    //    sqlc.Parameters.Add("@CodComuna", SqlDbType.Int).Value = CodComuna;
    //    sqlc.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = CodSolicitante;
    //    sqlc.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = RUC;
    //    sqlc.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = RIT;
    //    sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = FechaOrden;
    //    sqlc.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = CodCausalIngreso;
    //    sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
    //    sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = IdUsuarioActualizacion;
    //    sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = FechaActualizacion;
    //    sqlc.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;

    //    IngresoCorrecto = Convert.ToInt32(sqlc.ExecuteScalar());

    //    return IngresoCorrecto;
    //}

    private int guardaListaEsperaT(SqlTransaction sqlt, SqlConnection sqlc, NinoListaEspera ninoLE)
    {
        int ingresoCorrecto = 0;

        SqlCommand command = new SqlCommand("Insert_Ninos_Lista_Espera", sqlc, sqlt);


        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = ninoLE.CodNino;
        command.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ninoLE.ICodIE;
        command.Parameters.Add("@FechaIngresoLE", SqlDbType.DateTime).Value = ninoLE.FechaIngresoListaEspera;
        command.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = ninoLE.FechaEgresoListaEspera;
        command.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = ninoLE.CodTribunal;
        command.Parameters.Add("@CodComuna", SqlDbType.Int).Value = ninoLE.CodComuna;
        command.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = ninoLE.CodSolicitanteIngreso;
        command.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = ninoLE.RUC;
        command.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = ninoLE.RIT;
        command.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = ninoLE.FechaOrden;
        command.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = ninoLE.CodCausalIngreso;
        command.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = ninoLE.CodProyecto;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = ninoLE.IdUsuarioActualizacion;
        command.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = ninoLE.FechaActualizacion;
        command.Parameters.Add("@Estado", SqlDbType.Int).Value = ninoLE.CodEstado;

        ingresoCorrecto = Convert.ToInt32(command.ExecuteScalar());

        return ingresoCorrecto;
    }

    private int insertNinoDesdeListaEspera(SqlTransaction sqlt, SqlConnection sqlc, DateTime FechaAdoptabilidad, bool IdentidadConfirmada, string Rut, string Sexo, string Nombres,
        string ApellidoPaterno, string ApellidoMaterno, DateTime FechaNacimiento, int CodNacionalidad, int CodEtnia, string OficinaInscripcion, int AnoInscripcion,
        int NumeroinscripcionCivil, string AlergiasConocidas, bool InscritoFONADIS, bool InscritoFONASA, bool NinoSuceptibleAdopcion,
        string EstadoGestacion, DateTime FechaActualizacion, int IdUsuarioActualizacion, int MuestraADN, int CodTipousuario, int CodTipoNacionalidad)
    {
        int resultado = 0;

        //SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("Insert_NinoDesdeListaEspera", sqlc, sqlt);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;

        command.Parameters.Add("@FechaAdoptabilidad", SqlDbType.DateTime).Value = FechaAdoptabilidad;
        command.Parameters.Add("@IdentidadConfirmada", SqlDbType.Int).Value = IdentidadConfirmada;
        command.Parameters.Add("@Rut", SqlDbType.Int).Value = Rut;
        command.Parameters.Add("@Sexo", SqlDbType.Int).Value = Sexo;
        command.Parameters.Add("@Nombres", SqlDbType.Int).Value = Nombres;
        command.Parameters.Add("@@Apellido_Paterno", SqlDbType.Int).Value = ApellidoPaterno;
        command.Parameters.Add("@Apellido_Materno", SqlDbType.Int).Value = ApellidoMaterno;
        command.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = FechaNacimiento;
        command.Parameters.Add("@CodNacionalidad", SqlDbType.Int).Value = CodNacionalidad;
        command.Parameters.Add("@CodEtnia", SqlDbType.Int).Value = CodEtnia;
        command.Parameters.Add("@OficinaInscripcion", SqlDbType.Int).Value = OficinaInscripcion;
        command.Parameters.Add("@AnoInscripcion", SqlDbType.Int).Value = AnoInscripcion;
        command.Parameters.Add("@NumeroInscripcionCivil", SqlDbType.Int).Value = NumeroinscripcionCivil;
        command.Parameters.Add("@AlergiasConocidas", SqlDbType.Int).Value = AlergiasConocidas;
        command.Parameters.Add("@InscritoFONADIS", SqlDbType.Int).Value = InscritoFONADIS;
        command.Parameters.Add("@InscritoFONASA", SqlDbType.Int).Value = InscritoFONASA;
        command.Parameters.Add("@NinoSuceptibleAdopcion", SqlDbType.Int).Value = NinoSuceptibleAdopcion;
        command.Parameters.Add("@EstadoGestacion", SqlDbType.Int).Value = EstadoGestacion;
        command.Parameters.Add("@FechaActualizacion", SqlDbType.Int).Value = FechaActualizacion;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int).Value = IdUsuarioActualizacion;
        command.Parameters.Add("@MuestraADN", SqlDbType.Int).Value = MuestraADN;
        command.Parameters.Add("@CodTipoUsuario", SqlDbType.Int).Value = CodTipousuario;
        command.Parameters.Add("@CodTipoNacionalidad", SqlDbType.Int).Value = CodTipoNacionalidad;

        resultado = Convert.ToInt32(command.ExecuteScalar());

        return resultado;
    }

    private int insertNinoDesdeListaEsperaT(SqlTransaction sqlt, SqlConnection sqlc, nino nino)
    {
        int resultado = 0;

        SqlCommand command = new SqlCommand("Insert_NinoDesdeListaEspera", sqlc, sqlt);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;

        command.Parameters.Add("@FechaAdoptabilidad", SqlDbType.DateTime).Value = nino.FechaAdoptabilidad;
        command.Parameters.Add("@IdentidadConfirmada", SqlDbType.Int).Value = nino.IdentidadConfirmada;
        command.Parameters.Add("@Rut", SqlDbType.VarChar).Value = nino.rut;
        command.Parameters.Add("@Sexo", SqlDbType.Char).Value = nino.sexo;
        command.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = nino.Nombres;
        command.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar).Value = nino.Apellido_Paterno;
        command.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar).Value = nino.Apellido_Materno;
        command.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = nino.FechaNacimiento;
        command.Parameters.Add("@CodNacionalidad", SqlDbType.Int).Value = nino.CodNacionalidad;
        command.Parameters.Add("@CodEtnia", SqlDbType.Int).Value = nino.CodEtnia;
        command.Parameters.Add("@OficinaInscripcion", SqlDbType.VarChar).Value = nino.OficinaInscripcion;
        command.Parameters.Add("@AnoInscripcion", SqlDbType.Int).Value = nino.AnoInscripcion;
        command.Parameters.Add("@NumeroInscripcionCivil", SqlDbType.VarChar).Value = nino.NumeroInscripcionCivil;
        command.Parameters.Add("@AlergiasConocidas", SqlDbType.VarChar).Value = nino.AlergiasConocidas;
        command.Parameters.Add("@InscritoFONADIS", SqlDbType.Bit).Value = nino.InscritoFONADIS;
        command.Parameters.Add("@InscritoFONASA", SqlDbType.Bit).Value = nino.InscritoFONASA;
        command.Parameters.Add("@NinoSuceptibleAdopcion", SqlDbType.Bit).Value = nino.NinoSuceptibleAdopcion;
        command.Parameters.Add("@EstadoGestacion", SqlDbType.Char).Value = nino.EstadoGestacion;
        command.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = DateTime.Now;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int).Value = nino.IdUsuarioActualizacion;
        command.Parameters.Add("@MuestraADN", SqlDbType.Int).Value = nino.MuestraADN;
        command.Parameters.Add("@CodTipoUsuario", SqlDbType.Int).Value = nino.CodTipoUsuario;
        command.Parameters.Add("@CodTipoNacionalidad", SqlDbType.Int).Value = nino.CodTipoNacionalidad;

        resultado = Convert.ToInt32(command.ExecuteScalar());

        return resultado;
    }

    private DataTable callto_actualizo_listaespera(int ICodIngresoLE, int CodNino, int ICodIE, DateTime FechaEgresoLE, int CodTribunal, string RUC, string RIT, DateTime FechaOrden,
        int CodCausalIngreso, int CodProyecto, int IdUsuarioActualizacion, DateTime FechaActualizacion, int Estado, int CodComuna, int CodSolicitante)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_ListaEspera2";

        sqlc.Parameters.Add("@ICodIngresoLE", SqlDbType.Int, 10).Value = ICodIngresoLE;
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = FechaEgresoLE;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = CodTribunal;
        sqlc.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = RUC;
        sqlc.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = RIT;
        sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = FechaOrden;
        sqlc.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = CodCausalIngreso;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = FechaActualizacion;
        sqlc.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;
        sqlc.Parameters.Add("@CodComuna", SqlDbType.Int).Value = CodComuna;
        sqlc.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = CodSolicitante;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private int UpdateListaEspera(NinoListaEspera nino)
    {
        int resultado = 0;

        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("Update_ListaEspera2", sqlc);

        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 10000000;

        command.Parameters.Add("@ICodIngresoLE", SqlDbType.Int, 10).Value = nino.CodIngresoLE;
        command.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = nino.CodNino;
        command.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = nino.ICodIE;
        command.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = nino.FechaEgresoListaEspera;
        command.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = nino.CodTribunal;
        command.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = nino.RUC;
        command.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = nino.RIT;
        command.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = nino.FechaOrden;
        command.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = nino.CodCausalIngreso;
        command.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = nino.CodProyecto;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = nino.IdUsuarioActualizacion;
        command.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = nino.FechaActualizacion;
        command.Parameters.Add("@Estado", SqlDbType.Int).Value = nino.CodEstado;
        command.Parameters.Add("@CodComuna", SqlDbType.Int).Value = nino.CodComuna;
        command.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = nino.CodSolicitanteIngreso;

        command.Connection.Open();

        resultado = Convert.ToInt32(command.ExecuteScalar());
        //command.ExecuteNonQuery();

        command.Connection.Close();

        return resultado;

    }

    private int UpdateListaEsperaT(SqlConnection sqlc, SqlTransaction sqlt, NinoListaEspera ninoUpdate)
    {
        int resultado = 0;

        DataTable dt = new DataTable();
        SqlCommand command = new SqlCommand("Update_ListaEspera2", sqlc, sqlt);


        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;

        command.Parameters.Add("@ICodIngresoLE", SqlDbType.Int, 10).Value = ninoUpdate.CodIngresoLE;
        command.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = ninoUpdate.CodNino;
        command.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ninoUpdate.ICodIE;
        command.Parameters.Add("@FechaEgresoLE", SqlDbType.DateTime).Value = ninoUpdate.FechaEgresoListaEspera;
        command.Parameters.Add("@CodTribunal", SqlDbType.Int, 6).Value = ninoUpdate.CodTribunal;
        command.Parameters.Add("@RUC", SqlDbType.NVarChar, 20).Value = ninoUpdate.RUC;
        command.Parameters.Add("@RIT", SqlDbType.NVarChar, 30).Value = ninoUpdate.RIT;
        command.Parameters.Add("@FechaOrden", SqlDbType.DateTime).Value = ninoUpdate.FechaOrden;
        command.Parameters.Add("@CodCausalIngreso", SqlDbType.Int, 4).Value = ninoUpdate.CodCausalIngreso;
        command.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = ninoUpdate.CodProyecto;
        command.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 10).Value = ninoUpdate.IdUsuarioActualizacion;
        command.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = ninoUpdate.FechaActualizacion;
        command.Parameters.Add("@Estado", SqlDbType.Int).Value = ninoUpdate.CodEstado;
        command.Parameters.Add("@CodComuna", SqlDbType.Int).Value = ninoUpdate.CodComuna;
        command.Parameters.Add("@CodSolicitante", SqlDbType.Int).Value = ninoUpdate.CodSolicitanteIngreso;

        //command.Connection.Open();

        resultado = Convert.ToInt32(command.ExecuteScalar());

        //command.Connection.Close();

        return resultado;
    }

    protected bool DatosValidos()
    {
        Color colorCampoObligatorio = ColorTranslator.FromHtml("#F2F5A9");

        bool datos_validos = true;

        int codNacionalidad = 0, codTipoNacionalidad = 0, codRegionNino = 0, codComuna = 0, codSolicitanteIngreso = 0, codRegionTribunal = 0, codTipoTribunal = 0,
            codTribunal = 0, codTipoCausal = 0, codCausalIngreso = 0, codInstitucion = 0, codProyecto = 0;

        string nombres, apellidoPaterno, apellidoMaterno, RUC, RIT;

        DateTime fechaNacimiento, fechaIngresoListaEspera, FechaOrden;

        if (int.TryParse(ddown_tipo_nacionalidad.SelectedValue, out codTipoNacionalidad))
        {
            if (codTipoNacionalidad == 0)
            {
                datos_validos = false;
                ddown_tipo_nacionalidad.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_tipo_nacionalidad.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_nacionalidad.SelectedValue, out codNacionalidad))
        {
            if (codNacionalidad == 0)
            {
                ddown_nacionalidad.BackColor = colorCampoObligatorio;
                datos_validos = false;
            }
            else
            {
                ddown_nacionalidad.BackColor = Color.Empty;
            }
        }

        if (ddown_tipo_nacionalidad.SelectedValue == "1" ||
            ddown_tipo_nacionalidad.SelectedValue == "3" ||
            ((ddown_tipo_nacionalidad.SelectedValue == "4" || ddown_tipo_nacionalidad.SelectedValue == "5") && ddown_nacionalidad.SelectedValue == "1"))
        {
            if (string.IsNullOrEmpty(txt_rut.Text.Trim().Replace(".", "")))
            {
                datos_validos = false;
                txt_rut.BackColor = colorCampoObligatorio;
                lblErrorRut.Text = "El Ingreso del RUT es obligatorio";
                lblErrorRut.Visible = true;
                txt_rut.Focus();
            }
            else
            {
                txt_rut.BackColor = Color.Empty;
                lblErrorRUC.Visible = false;
            }
        }
        else
        {
            if (string.IsNullOrEmpty(txt_rut.Text.Trim()))
            {
                txt_rut.Text = "0";
            }
        }

        if (string.IsNullOrEmpty(txt_nombres.Text))
        {
            datos_validos = false;
            txt_nombres.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_nombres.BackColor = Color.Empty;
        }

        if (string.IsNullOrEmpty(txt_ap_materno.Text))
        {
            datos_validos = false;
            txt_ap_materno.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_ap_materno.BackColor = Color.Empty;
        }

        if (string.IsNullOrEmpty(txt_ap_paterno.Text))
        {
            datos_validos = false;
            txt_ap_paterno.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_ap_paterno.BackColor = Color.Empty;
        }

        if (string.IsNullOrEmpty(wdc_Fnacimiento.Text))
        {
            datos_validos = false;
            wdc_Fnacimiento.BackColor = colorCampoObligatorio;
        }
        else
        {
            if (DateTime.TryParse(wdc_Fnacimiento.Text, out fechaNacimiento))
            {
                wdc_Fnacimiento.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_region.SelectedValue, out codRegionNino))
        {
            if (codRegionNino == 0)
            {
                datos_validos = false;
                ddown_region.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_region.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_comuna.SelectedValue, out codComuna))
        {
            if (codComuna == 0)
            {
                datos_validos = false;
                ddown_comuna.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_comuna.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_Tribunal.SelectedValue, out codTribunal))
        {
            if (codTribunal == 0)
            {
                datos_validos = false;
                ddown_comuna.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_comuna.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_solicitante.SelectedValue, out codSolicitanteIngreso))
        {
            if (codSolicitanteIngreso == 0)
            {
                datos_validos = false;
                ddown_solicitante.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_solicitante.BackColor = Color.Empty;
            }
        }

        if (string.IsNullOrEmpty(wdc_Flistaespera.Text))
        {
            datos_validos = false;
            wdc_Flistaespera.BackColor = colorCampoObligatorio;
        }
        else
        {
            if (DateTime.TryParse(wdc_Flistaespera.Text, out fechaIngresoListaEspera))
            {
                wdc_Flistaespera.BackColor = Color.Empty;
            }
        }


        if (int.TryParse(ddown_RegionTribunal.SelectedValue, out codRegionTribunal))
        {
            if (codRegionTribunal == 0)
            {
                datos_validos = false;
                ddown_RegionTribunal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_RegionTribunal.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_Tribunal.SelectedValue, out codTribunal))
        {
            if (codTribunal == 0)
            {
                datos_validos = false;
                ddown_Tribunal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_Tribunal.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_TipoTribunal.SelectedValue, out codTipoTribunal))
        {
            if (codTipoTribunal == 0)
            {
                datos_validos = false;
                ddown_TipoTribunal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_TipoTribunal.BackColor = Color.Empty;
            }
        }

        if (string.IsNullOrEmpty(txt_ruc.Text))
        {
            datos_validos = false;
            txt_ruc.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_ruc.BackColor = Color.Empty;
            RUC = txt_ruc.Text.Trim();
        }

        if (string.IsNullOrEmpty(txt_rit.Text))
        {
            datos_validos = false;
            txt_rit.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_rit.BackColor = Color.Empty;
            RIT = txt_rit.Text.Trim();
        }

        if (string.IsNullOrEmpty(wdc_fecha.Text))
        {
            datos_validos = false;
            wdc_fecha.BackColor = colorCampoObligatorio;
        }
        else
        {
            if (DateTime.TryParse(wdc_fecha.Text, out FechaOrden))
            {
                wdc_fecha.BackColor = Color.White;
            }
        }

        if (int.TryParse(ddown_TipoCausal.SelectedValue, out codTipoCausal))
        {
            if (codTipoCausal == 0)
            {
                datos_validos = false;
                ddown_TipoCausal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_TipoCausal.BackColor = Color.Empty;
            }

        }

        if (int.TryParse(ddown_Causal.SelectedValue, out codCausalIngreso))
        {
            if (codCausalIngreso == 0)
            {
                datos_validos = false;
                ddown_Causal.BackColor = colorCampoObligatorio;
            }
        }

        if (int.TryParse(ddown_Institucion.SelectedValue, out codInstitucion))
        {
            if (codInstitucion == 0)
            {
                datos_validos = false;
                ddown_Institucion.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_Institucion.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_Proyecto.SelectedValue, out codProyecto))
        {
            if (codProyecto == 0)
            {
                datos_validos = false;
                ddown_Proyecto.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_Proyecto.BackColor = Color.Empty;
            }
        }


        return datos_validos;
    }

    protected DataTable getNinoEnListaEspera(int CodNino)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("GET_ListaDeEspera", sqlc);

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.CommandTimeout = 1000000;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@CodNino", SqlDbType.Int).Value = CodNino;

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();

        return dt;
    }

    protected bool getPermisoDuplicado()
    {
        bool permiso;
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("get_PermisoDuplicado", sqlc);

        //SqlDataAdapter sqlda = new SqlDataAdapter();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;

        command.Connection.Open();

        permiso = Convert.ToBoolean(command.ExecuteScalar());

        command.Connection.Close();

        return permiso;
    }

    protected DataTable getNinoEnProyecto(int CodProyecto, int CodNino)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("GET_NinoEnProyecto", sqlc);

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.CommandTimeout = 1000000;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = CodProyecto;
        command.Parameters.Add("@CodNino", SqlDbType.Int).Value = CodNino;

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();

        return dt;
    }

    protected DataTable getNinoxDatos(string Rut, string Nombres, string ApellidoPaterno, string ApellidoMaterno)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("GET_NinoxDatos", sqlc);

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.CommandTimeout = 1000000;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@Rut", SqlDbType.VarChar).Value = Rut;
        command.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = Nombres;
        command.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = ApellidoPaterno;
        command.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = ApellidoMaterno;

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();

        return dt;
    }


    public bool NNAEnMismoProyecto(int CodNino, int CodProyecto)
    {
        bool existe = false;

        //bool MismoProyecto = false;

        DataTable NinoEnListaEspera;

        NinoEnListaEspera = getNinoEnListaEspera(CodNino);

        for (int i = 0; i < NinoEnListaEspera.Rows.Count; i++)
        {

            if (NinoEnListaEspera.Rows[i]["CodProyecto"].ToString().Equals(CodProyecto.ToString()))
            {
                //MismoProyecto = true;
                existe = true;
                lbl_warning.Text += "NNA ya se encuentra en lista de espera para este proyecto. <br />";
                btn_agregar.Enabled = false;
                if (existe)
                {
                    break;
                }

            }
            else
            {
                existe = false;
            }
        }

        return existe;
    }


    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        #region NuevoIngresoListaEspera

        NinoListaEspera ninoLE = new NinoListaEspera();
        nino nino = new nino();

        nino.FechaActualizacion = DateTime.Now;
        nino.IdUsuarioActualizacion = Convert.ToInt32(Session["IdUsuario"].ToString());

        ninoLE.FechaActualizacion = DateTime.Now;
        ninoLE.IdUsuarioActualizacion = Convert.ToInt32(Session["IdUsuario"].ToString());

        Color colorCampoObligatorio = ColorTranslator.FromHtml("#F2F5A9");

        #region Validaciones Lista Espera

        bool datos_validos = true;

        int codNino = 0, ICodIE = 0, codNacionalidad = 0, codTipoNacionalidad = 0, codRegionNino = 0, codComuna = 0, codSolicitanteIngreso = 0, codRegionTribunal = 0, codTipoTribunal = 0,
            codTribunal = 0, codTipoCausal = 0, codCausalIngreso = 0, codInstitucion = 0, codProyecto = 0;

        string nombres, apellidoPaterno, apellidoMaterno, RUC, RIT, RUT, ProyectosNNA;

        DateTime fechaNacimiento, fechaIngresoListaEspera, fechaOrden, fechaEgresoListaEspera;

        //fechaEgresoListaEspera = new DateTime(1900, 01, 01);

        if (int.TryParse(ddown_tipo_nacionalidad.SelectedValue, out codTipoNacionalidad))
        {
            if (codTipoNacionalidad == 0)
            {
                if (ddown_nacionalidad.SelectedValue == "1")
                {
                    codTipoNacionalidad = 1;
                }
                else
                {
                    datos_validos = false;
                    ddown_tipo_nacionalidad.BackColor = colorCampoObligatorio;
                }
            }
            else
            {
                ddown_tipo_nacionalidad.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_nacionalidad.SelectedValue, out codNacionalidad))
        {
            if (codNacionalidad == 0)
            {
                ddown_nacionalidad.BackColor = colorCampoObligatorio;
                datos_validos = false;
            }
            else
            {
                ddown_nacionalidad.BackColor = Color.Empty;
            }
        }

        //if (ddown_tipo_nacionalidad.SelectedValue == "1" ||
        //    ddown_tipo_nacionalidad.SelectedValue == "3" ||
        //    ((ddown_tipo_nacionalidad.SelectedValue == "4" || ddown_tipo_nacionalidad.SelectedValue == "5") && ddown_nacionalidad.SelectedValue == "1"))
        //{
        //    if (string.IsNullOrEmpty(txt_rut.Text.Trim().Replace(".", "")))
        //    {
        //        datos_validos = false;
        //        txt_rut.BackColor = colorCampoObligatorio;
        //        lblErrorRut.Text = "El Ingreso del RUT es obligatorio";
        //        lblErrorRut.Visible = true;
        //        txt_rut.Focus();
        //    }
        //    else
        //    {
        //        txt_rut.BackColor = Color.Empty;
        //        lblErrorRut.Visible = false;
        //    }
        //}
        //else
        //{
        //    if (string.IsNullOrEmpty(txt_rut.Text.Trim()))
        //    {
        //        txt_rut.Text = "0";
        //    }
        //}

        if (string.IsNullOrEmpty(txt_rut.Text.Trim().Replace(".", "")))
        {
            datos_validos = false;
            txt_rut.BackColor = colorCampoObligatorio;
            lblErrorRut.Text = "El ingreso del rut es obligatorio";
            lblErrorRut.Visible = true;
            txt_rut.Focus();
        }
        else
        {
            txt_rut.BackColor = Color.Empty;
            lblErrorRut.Visible = false;
        }

        if (string.IsNullOrEmpty(txt_nombres.Text))
        {
            datos_validos = false;
            txt_nombres.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_nombres.BackColor = Color.Empty;
        }

        if (string.IsNullOrEmpty(txt_ap_materno.Text))
        {
            datos_validos = false;
            txt_ap_materno.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_ap_materno.BackColor = Color.Empty;
        }

        if (string.IsNullOrEmpty(txt_ap_paterno.Text))
        {
            datos_validos = false;
            txt_ap_paterno.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_ap_paterno.BackColor = Color.Empty;
        }


        if (string.IsNullOrEmpty(wdc_Fnacimiento.Text))
        {
            datos_validos = false;
            wdc_Fnacimiento.BackColor = colorCampoObligatorio;
        }

        if (DateTime.TryParse(wdc_Fnacimiento.Text, out fechaNacimiento))
        {
            wdc_Fnacimiento.BackColor = Color.Empty;
        }

        if (int.TryParse(ddown_region.SelectedValue, out codRegionNino))
        {
            if (codRegionNino == 0)
            {
                datos_validos = false;
                ddown_region.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_region.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_comuna.SelectedValue, out codComuna))
        {
            if (codComuna == 0)
            {
                datos_validos = false;
                ddown_comuna.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_comuna.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_Tribunal.SelectedValue, out codTribunal))
        {
            if (codTribunal == 0)
            {
                datos_validos = false;
                ddown_comuna.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_comuna.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_solicitante.SelectedValue, out codSolicitanteIngreso))
        {
            if (codSolicitanteIngreso == 0)
            {
                datos_validos = false;
                ddown_solicitante.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_solicitante.BackColor = Color.Empty;
            }
        }



        if (int.TryParse(ddown_RegionTribunal.SelectedValue, out codRegionTribunal))
        {
            if (codRegionTribunal == 0)
            {
                datos_validos = false;
                ddown_RegionTribunal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_RegionTribunal.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_Tribunal.SelectedValue, out codTribunal))
        {
            if (codTribunal == 0)
            {
                datos_validos = false;
                ddown_Tribunal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_Tribunal.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_TipoTribunal.SelectedValue, out codTipoTribunal))
        {
            if (codTipoTribunal == 0)
            {
                datos_validos = false;
                ddown_TipoTribunal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_TipoTribunal.BackColor = Color.Empty;
            }
        }

        if (string.IsNullOrEmpty(txt_ruc.Text))
        {
            datos_validos = false;
            txt_ruc.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_ruc.BackColor = Color.Empty;
            RUC = txt_ruc.Text.Trim();
        }

        if (string.IsNullOrEmpty(txt_rit.Text))
        {
            datos_validos = false;
            txt_rit.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_rit.BackColor = Color.Empty;
            RIT = txt_rit.Text.Trim();
        }



        if (string.IsNullOrEmpty(wdc_Flistaespera.Text))
        {
            datos_validos = false;
            wdc_Flistaespera.BackColor = colorCampoObligatorio;
        }

        if (DateTime.TryParse(wdc_Flistaespera.Text, out fechaIngresoListaEspera))
        {
            wdc_Flistaespera.BackColor = Color.Empty;
        }

        if (string.IsNullOrEmpty(wdc_fecha.Text))
        {
            datos_validos = false;
            wdc_fecha.BackColor = colorCampoObligatorio;
        }

        if (DateTime.TryParse(wdc_fecha.Text, out fechaOrden))
        {
            wdc_fecha.BackColor = Color.Empty;
        }

        if (int.TryParse(ddown_TipoCausal.SelectedValue, out codTipoCausal))
        {
            if (codTipoCausal == 0)
            {
                datos_validos = false;
                ddown_TipoCausal.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_TipoCausal.BackColor = Color.Empty;
            }

        }

        if (int.TryParse(ddown_Causal.SelectedValue, out codCausalIngreso))
        {
            if (codCausalIngreso == 0)
            {
                datos_validos = false;
                ddown_Causal.BackColor = colorCampoObligatorio;
            }
        }

        if (int.TryParse(ddown_Institucion.SelectedValue, out codInstitucion))
        {
            if (codInstitucion == 0)
            {
                datos_validos = false;
                ddown_Institucion.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_Institucion.BackColor = Color.Empty;
            }
        }

        if (int.TryParse(ddown_Proyecto.SelectedValue, out codProyecto))
        {
            if (codProyecto == 0)
            {
                datos_validos = false;
                ddown_Proyecto.BackColor = colorCampoObligatorio;
            }
            else
            {
                ddown_Proyecto.BackColor = Color.Empty;
            }
        }
        #endregion


        int.TryParse(lbl_CodNino.Text, out codNino);
        int.TryParse(ddown_Proyecto.SelectedValue, out codProyecto);

        //datos_validos = NNAEnMismoProyecto(codNino, codProyecto);


        if (datos_validos)
        {
            bool PermisoDuplicado = false;
            bool ExisteEnListaEsperaOtrosProyectos = false,
                ExisteEnMismoProyecto = false,
                ExisteIngresadoEnOtroProyecto = false;
            //int CodProyecto = 0, CodNino = 0;

            DataTable NinoEnProyecto, NinoEnListaEspera;//, NinoEnListaEspera;




            #region Carga Obj Nino
            nino.CodNino = codNino;
            nino.CodProyecto = codProyecto;
            nino.rut = txt_rut.Text.Trim().Replace(".", "");
            nino.Nombres = txt_nombres.Text.Trim();
            nino.Apellido_Paterno = txt_ap_paterno.Text.Trim();
            nino.Apellido_Materno = txt_ap_materno.Text.Trim();
            nino.sexo = rdbl_sexo.SelectedValue;
            nino.CodNacionalidad = codNacionalidad;
            nino.CodTipoNacionalidad = codTipoNacionalidad;
            nino.FechaNacimiento = fechaNacimiento;
            #endregion

            #region Carga obj NinoListaEspera
            ninoLE.CodCausalIngreso = codCausalIngreso;
            ninoLE.CodComuna = codComuna;
            ninoLE.CodNino = codNino;
            ninoLE.FechaOrden = fechaOrden;
            ninoLE.FechaIngresoListaEspera = fechaIngresoListaEspera;
            ninoLE.RIT = txt_rit.Text.Trim();
            ninoLE.RUC = txt_ruc.Text.Trim();
            ninoLE.CodTribunal = codTribunal;
            ninoLE.CodProyecto = codProyecto;
            ninoLE.CodInstitucion = codInstitucion;
            ninoLE.CodCausalIngreso = codCausalIngreso;
            ninoLE.CodSolicitanteIngreso = codSolicitanteIngreso;

            #endregion

            #region Carga Datatables con informacion del NNA a ingresar
            PermisoDuplicado = getPermisoDuplicado();

            NinoEnProyecto = getNinoEnProyecto(codProyecto, codNino);
            #endregion

            NinoEnListaEspera = getNinoEnListaEspera(codNino);

            if (PermisoDuplicado)
            {
                ProyectosNNA = string.Empty;
                lbl_existe.Text = string.Empty;
                #region Valida si existe en el mismo proyecto
                //bool MismoProyecto = false;

                //lbl_warning.Text = string.Empty;


                //for (int i = 0; i < NinoEnListaEspera.Rows.Count; i++)
                //{
                //    if (NinoEnListaEspera.Rows[i]["CodProyecto"].ToString().Equals(codProyecto.ToString()))
                //    {
                //        MismoProyecto = true;
                //    }
                //}

                //if (MismoProyecto)
                //{
                //    ExisteEnMismoProyecto = true;
                //    lbl_warning.Text += "NNA ya se encuentra en lista de espera para este proyecto. <br />";
                //    //lbl_warning.Visible = true;
                //}

                #endregion

                #region Valida si existe en alguna lista de espera

                bool MismoProyecto = false;

                if (NinoEnListaEspera.Rows.Count > 0)
                {
                    for (int i = 0; i < NinoEnListaEspera.Rows.Count; i++)
                    {
                        if (i == NinoEnListaEspera.Rows.Count - 1)
                        {
                            if (NinoEnListaEspera.Rows[i]["CodProyecto"].ToString() != codProyecto.ToString())
                            {
                                ProyectosNNA += NinoEnListaEspera.Rows[i]["CodProyecto"].ToString();
                            }
                        }
                        else
                        {
                            //MismoProyecto = true;
                            ProyectosNNA += NinoEnListaEspera.Rows[i]["CodProyecto"].ToString() + ", ";
                        }
                    }
                    //lbl_warning.Text += "NNA no puede ser ingresado ya que existe en otro(s) proyecto(s) vigente en lista de espera (" + ProyectosNNA + ") <br />";
                    if (string.IsNullOrEmpty(ProyectosNNA))
                    {
                        ExisteEnListaEsperaOtrosProyectos = false;
                    }
                    else
                    {
                        //if (!MismoProyecto)
                        //{
                        ExisteEnListaEsperaOtrosProyectos = true;
                        lbl_warning.Text += "Considerar que el NNA que ha ingresado se encuentra en lista de espera en otros proyectos (" + ProyectosNNA + ") <br />";
                        //}
                    }

                }
                #endregion

                #region Valida si existe ingresado en algún proyecto
                if (NinoEnProyecto.Rows.Count > 0)
                {
                    ExisteIngresadoEnOtroProyecto = true;
                    lbl_existe.Text += "El(la) niño(a) ya se encuentra en lista de espera, o bien ya fue ingresado al proyecto. <br />";
                }
                #endregion


                if (btn_agregar.Text == "Agregar")
                {
                    if (ExisteIngresadoEnOtroProyecto == false)// && ExisteEnMismoProyecto == false) // && ExisteEnListaEsperaOtrosProyectos == false)
                    {
                        if (insertarNinoAListaDeEspera(ninoLE, nino))
                        {
                            if (ExisteEnListaEsperaOtrosProyectos)
                            {
                                cerrarModalEnOtroProyecto("NNA ha sido ingresado correctamente a Lista de Espera <br />" + lbl_warning.Text);
                            }
                            else
                            {
                                cerrarModalIngreso("NNA Ha sido ingresado correctamente a Lista de Espera");
                            }
                        }
                        else
                        {
                            lbl_warning.Text = "Ha ocurrido un error al momento de insertar los datos, vuelva a intentarlo";
                            lbl_warning.Visible = true;
                        }
                    }
                    else
                    {
                        lbl_warning.Visible = true;
                        lbl_existe.Visible = true;
                    }
                }
                else if (btn_agregar.Text == "Modificar")
                {
                    int CodLugarDefuncion = 0, CodRegionDefuncion = 0, CodComunaDefuncion = 0, CodEstadoLEmodif = 0;
                    DateTime FechaDefuncion, FechaEgreso;

                    #region Valida Datos para Modificacion
                    bool datos_validos_fallecimiento = true, datos_validos_modificacion = true;

                    if (int.TryParse(ddown_estado.SelectedValue, out CodEstadoLEmodif))
                    {
                        if (CodEstadoLEmodif == 10)
                        {
                            #region Validacion de Estado Fallecimiento
                            if (string.IsNullOrEmpty(wdc_F_egreso.Text))
                            {
                                datos_validos_fallecimiento = false;
                                wdc_F_egreso.BackColor = colorCampoObligatorio;
                            }
                            else
                            {
                                wdc_F_egreso.BackColor = Color.Empty;
                            }

                            if (DateTime.TryParse(wdc_F_egreso.Text, out FechaEgreso))
                            {
                                wdc_F_egreso.BackColor = Color.Empty;
                            }


                            if (int.TryParse(ddown_estado.SelectedValue, out CodEstadoLEmodif))
                            {
                                ddown_estado.BackColor = Color.Empty;

                            }
                            else
                            {
                                ddown_estado.BackColor = colorCampoObligatorio;
                                datos_validos_fallecimiento = false;
                            }


                            if (string.IsNullOrEmpty(txtCausalFallecimiento.Text))
                            {
                                txtCausalFallecimiento.BackColor = colorCampoObligatorio;
                                datos_validos_fallecimiento = false;
                            }
                            else
                            {
                                txtCausalFallecimiento.BackColor = Color.Empty;
                            }

                            if (string.IsNullOrEmpty(txtFechaDefuncion.Text))
                            {
                                txtFechaDefuncion.BackColor = colorCampoObligatorio;
                                datos_validos_fallecimiento = false;
                            }
                            else
                            {
                                txtFechaDefuncion.BackColor = Color.Empty;
                            }

                            if (DateTime.TryParse(txtFechaDefuncion.Text, out FechaDefuncion))
                            {
                                txtFechaDefuncion.BackColor = Color.Empty;
                            }
                            else
                            {
                                txtFechaDefuncion.BackColor = colorCampoObligatorio;

                            }

                            if (int.TryParse(ddlLugarFallecimiento.SelectedValue, out CodLugarDefuncion))
                            {
                                if (CodLugarDefuncion > 0)
                                {
                                    ddlLugarFallecimiento.BackColor = Color.Empty;
                                }
                                else
                                {
                                    ddlLugarFallecimiento.BackColor = colorCampoObligatorio;
                                    datos_validos_fallecimiento = false;
                                }
                            }

                            if (int.TryParse(ddlRegionFallecimiento.SelectedValue, out CodRegionDefuncion))
                            {
                                if (CodRegionDefuncion > 0)
                                {
                                    ddlRegionFallecimiento.BackColor = Color.Empty;
                                }
                                else
                                {
                                    ddlRegionFallecimiento.BackColor = colorCampoObligatorio;
                                    datos_validos_fallecimiento = false;
                                }
                            }

                            if (int.TryParse(ddlComunaFallecimiento.SelectedValue, out CodComunaDefuncion))
                            {
                                if (CodComunaDefuncion > 0)
                                {
                                    ddlComunaFallecimiento.BackColor = Color.Empty;
                                }
                                else
                                {
                                    ddlComunaFallecimiento.BackColor = colorCampoObligatorio;
                                    datos_validos_fallecimiento = false;
                                }
                            }
                            #endregion

                            ninoLE.FechaEgresoListaEspera = FechaEgreso;
                            ninoLE.CodEstado = CodEstadoLEmodif;
                            ninoLE.CodIngresoLE = Convert.ToInt32(lbl_ICodIngresoLE.Text);

                            nino.CausalDefuncion = txtCausalFallecimiento.Text;
                            nino.FechaDefuncion = FechaDefuncion;
                            nino.CodLugarDefuncion = CodLugarDefuncion;
                            nino.CodRegionDefuncion = CodRegionDefuncion;
                            nino.CodComunaDefuncion = CodComunaDefuncion;


                            if (datos_validos_fallecimiento)
                            {
                                int ingresoCorrecto = ActualizarNinoListaEspera(nino, ninoLE);
                                if (ingresoCorrecto > 0)
                                {
                                    cerrarModalModificar("NNA actualizado correctamente");
                                }
                                else
                                {
                                    lbl_warning.Text = "Ha ocurrido un error al momento de insertar los datos, vuelva a intentarlo";
                                    lbl_warning.Visible = true;
                                }
                            }
                        }
                        else if (CodEstadoLEmodif != 0)
                        {
                            #region Validacion de Modificados de Lista de Espera
                            if (string.IsNullOrEmpty(wdc_F_egreso.Text))
                            {
                                datos_validos_modificacion = false;
                                wdc_F_egreso.BackColor = colorCampoObligatorio;
                            }
                            else
                            {
                                wdc_F_egreso.BackColor = Color.Empty;
                            }

                            if (DateTime.TryParse(wdc_F_egreso.Text, out FechaEgreso))
                            {
                                wdc_F_egreso.BackColor = Color.Empty;
                            }


                            if (int.TryParse(ddown_estado.SelectedValue, out CodEstadoLEmodif))
                            {
                                ddown_estado.BackColor = Color.Empty;
                            }
                            else
                            {
                                ddown_estado.BackColor = colorCampoObligatorio;
                                datos_validos_modificacion = false;
                            }
                            #endregion

                            ninoLE.FechaEgresoListaEspera = FechaEgreso;
                            ninoLE.CodEstado = CodEstadoLEmodif;
                            ninoLE.CodIngresoLE = Convert.ToInt32(lbl_ICodIngresoLE.Text);


                            if (datos_validos_modificacion)
                            {
                                int ingresoCorrecto = UpdateListaEspera(ninoLE);
                                if (ingresoCorrecto > 0)
                                {
                                    cerrarModalModificar("NNA ha sido actualizado y egresado de Lista de Espera");
                                }
                                else
                                {
                                    lbl_warning.Text = "Ha ocurrido un error al momento de insertar los datos, vuelva a intentarlo";
                                    lbl_warning.Visible = true;
                                }

                            }
                        }
                        else if (CodEstadoLEmodif == 0 && ninoLE.FechaEgresoListaEspera == Convert.ToDateTime(new DateTime(1900, 01, 01)))
                        {
                            ninoLE.CodEstado = CodEstadoLEmodif;
                            ninoLE.CodIngresoLE = Convert.ToInt32(lbl_ICodIngresoLE.Text);

                            int ingresoCorrecto = UpdateListaEspera(ninoLE);
                            if (ingresoCorrecto > 0)
                            {
                                cerrarModalModificar("NNA ha sido actualizado correctamente");
                            }
                            else
                            {
                                lbl_warning.Text = "Ha ocurrido un error al momento de insertar los datos, vuelva a intentarlo";
                                lbl_warning.Visible = true;
                            }

                        }
                    }
                    #endregion
                }
            }
        }
        else
        {
            lbl_warning.Visible = true;
        }

        #endregion

        #region IngresoListaEsperaOld
        //System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
        //lbl_exito.Visible = false;
        //bool datos_vacios = false;
        //lbl_error.Visible = false;
        //DateTime fechaorden;
        //int region = 0;

        //if (btn_agregar.Text == "Agregar")
        //{
        //    if (txt_rut.Text == "")
        //    {

        //        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3" || ((ddown_tipo_nacionalidad.SelectedValue == "4" || ddown_tipo_nacionalidad.SelectedValue == "5") && ddown_nacionalidad.SelectedValue == "1"))
        //        {
        //            lblErrorRut.Text = "EL INGRESO DEL RUT ES OBLIGATORIO";
        //            txt_rut.BackColor = colorCampoObligatorio;
        //            lblErrorRut.Visible = true;
        //            btn_agregar.Visible = false;
        //            txt_rut.Focus();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        lblErrorRut.Visible = false;
        //    }

        //    Ninos1TableAdapter nino1 = new Ninos1TableAdapter();
        //    DataTable dtninoencontrado = new DataTable();

        //    if (lbl_CodNino.Text != string.Empty)
        //    {
        //        parListaEsperaTableAdapter Lespera = new parListaEsperaTableAdapter();
        //        DataTable dtespera = Lespera.Get_ListaDeEspera(Convert.ToInt32(lbl_CodNino.Text));
        //        lbl_existe.Text = "Ingreso no válido, ya se encontraron registros para este niño(a).";
        //        lbl_existe.Visible = false;
        //        ParConfiguracionTableAdapter ConfiguracionAdmiteDuplicados = new ParConfiguracionTableAdapter();

        //        DataTable dtDuplicados = ConfiguracionAdmiteDuplicados.Get_PermiteDuplicado();

        //        if (dtespera.Rows.Count > 0)
        //        {


        //            if (dtDuplicados.Rows.Count > 0) // siempre deberia traer un dato, pero de todas maneras se valida, de no existir el dato, NO permitirá cambios.
        //            {
        //                if (dtDuplicados.Rows[0]["Valor"].ToString() == "no")
        //                {
        //                    string proyectosdelNNA = string.Empty;
        //                    for (int h = 0; h < dtespera.Rows.Count; h++)
        //                    {
        //                        if (h == dtespera.Rows.Count - 1) // ultimo registro
        //                        {
        //                            proyectosdelNNA += dtespera.Rows[h]["CodProyecto"].ToString();
        //                        }
        //                        else
        //                        {
        //                            proyectosdelNNA += dtespera.Rows[h]["CodProyecto"].ToString() + ", ";
        //                        }
        //                    }

        //                    datos_vacios = true;
        //                    //lbl_existe.Text = "NNA no puede ser ingresado ya que existe en otro(s) proyecto(s) vigente en lista de espera (" + proyectosdelNNA + ")";
        //                    //lbl_existe.Visible = true;
        //                    lbl_warning.Text = "NNA no puede ser ingresado ya que existe en otro(s) proyecto(s) vigente en lista de espera (" + proyectosdelNNA + ")";
        //                    lbl_warning.Visible = true;
        //                }
        //                else
        //                {
        //                    bool MismoProyecto = false;
        //                    string proyectosdelNNA = string.Empty;
        //                    for (int h = 0; h < dtespera.Rows.Count; h++)
        //                    {
        //                        if (dtespera.Rows[h]["CodProyecto"].ToString() == ddown_Proyecto.SelectedValue.ToString())
        //                        {
        //                            MismoProyecto = true;
        //                        }
        //                        if (h == dtespera.Rows.Count - 1) // ultimo registro
        //                        {
        //                            proyectosdelNNA += dtespera.Rows[h]["CodProyecto"].ToString();
        //                        }
        //                        else
        //                        {
        //                            proyectosdelNNA += dtespera.Rows[h]["CodProyecto"].ToString() + ", ";
        //                        }
        //                    }
        //                    if (MismoProyecto)
        //                    {
        //                        datos_vacios = true;
        //                        lbl_warning.Text = "NNA ya se encuentra en lista de espera para este proyecto.";
        //                        lbl_warning.Visible = true;
        //                    }
        //                    else
        //                    {
        //                        datos_vacios = false;
        //                        lbl_warning.Text = "</br>ADVERTENCIA: </br> NNA ingresado, aunque se encuentra en lista de espera en otro proyecto (" + proyectosdelNNA + ")";
        //                        lbl_warning.Visible = true;
        //                    }
        //                }
        //            }
        //        }
        //        parProyecto_NinoTableAdapter ppnta = new parProyecto_NinoTableAdapter();
        //        DataTable dtninoenproyecto = ppnta.Get_Nino_Proyecto(Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(lbl_CodNino.Text));

        //        if (dtninoenproyecto.Rows.Count > 0)
        //        {
        //            datos_vacios = true;
        //            lbl_existe.Text = "El(la) niño(a) ya se encuentra en lista de espera, o bien ya fue ingresado al proyecto.";
        //            lbl_existe.Visible = true;
        //        }
        //    }
        //    if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3" || ((ddown_tipo_nacionalidad.SelectedValue == "4" || ddown_tipo_nacionalidad.SelectedValue == "5") && ddown_nacionalidad.SelectedValue == "1"))
        //    {
        //        if (txt_rut.Text.Trim() != string.Empty)
        //        {
        //            dtninoencontrado = nino1.Get_nino_by_data(txt_rut.Text.Trim().Replace(",", ""), txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());
        //            txt_rut.BackColor = System.Drawing.Color.Empty;
        //        }
        //        else
        //        {
        //            dtninoencontrado = nino1.Get_nino_by_data("0", txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());
        //            datos_vacios = true;
        //            txt_rut.BackColor = colorCampoObligatorio;
        //        }
        //    }
        //    else
        //    {
        //        if (txt_rut.Text.Trim() != string.Empty)
        //        {
        //            dtninoencontrado = nino1.Get_nino_by_data(txt_rut.Text.Trim().Replace(".", ""), txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());
        //        }
        //        else
        //        {
        //            dtninoencontrado = nino1.Get_nino_by_data("0", txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());
        //        }
        //    }

        //    if (ddown_nacionalidad.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_nacionalidad.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_nacionalidad.BackColor = System.Drawing.Color.Empty;
        //    }
        //    if (ddown_RegionTribunal.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        if (ddown_region.SelectedItem.ToString().Trim() == "Seleccionar")
        //        {
        //            ddown_region.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            ddown_region.BackColor = System.Drawing.Color.Empty;
        //            region = Convert.ToInt32(ddown_region.SelectedValue);
        //        }
        //    }
        //    else
        //    {
        //        region = Convert.ToInt32(ddown_RegionTribunal.SelectedValue);
        //    }

        //    try
        //    {
        //        lbl_errorFecha1.Text = "No puede ingresar una fecha futura";
        //        if (wdc_fecha.Text != "")
        //        {
        //            if (Convert.ToDateTime(wdc_fecha.Text) > DateTime.Now)
        //            {
        //                lbl_errorFecha2.Visible = true;
        //                datos_vacios = true;
        //            }
        //            else
        //            {
        //                lbl_errorFecha2.Visible = false;
        //            }
        //        }

        //        if (wdc_Flistaespera.Text != "")
        //        {
        //            if (Convert.ToDateTime(wdc_Flistaespera.Text) > DateTime.Now)
        //            {
        //                lbl_errorFecha1.Visible = true;
        //                datos_vacios = true;
        //            }
        //            else
        //            {
        //                if (Convert.ToDateTime(wdc_Flistaespera.Text) < DateTime.Now.AddMonths(-1))
        //                {
        //                    lbl_errorFecha1.Visible = true;
        //                    lbl_errorFecha1.Text = "La Fecha de ingreso no puede superar un mes hacia atras.";
        //                    wdc_Flistaespera.BackColor = colorCampoObligatorio;
        //                    datos_vacios = true;
        //                }
        //                else
        //                {
        //                    wdc_Flistaespera.BackColor = System.Drawing.Color.Empty;
        //                    lbl_errorFecha1.Visible = false;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            wdc_Flistaespera.BackColor = colorCampoObligatorio;
        //            lbl_errorFecha1.Text = "Seleccione una Fecha de ingreso a Lista de Espera";
        //            lbl_errorFecha1.Visible = true;
        //            datos_vacios = true;
        //        }
        //    }
        //    catch { }


        //    if (ddown_Causal.SelectedItem.ToString().Trim() == "No disponible" || ddown_Causal.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_Causal.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_Causal.BackColor = System.Drawing.Color.Empty;
        //    }


        //    if (ddown_solicitante.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_solicitante.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_solicitante.BackColor = System.Drawing.Color.Empty;
        //    }

        //    if (ddown_Proyecto.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_Proyecto.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_Proyecto.BackColor = System.Drawing.Color.Empty;
        //    }

        //    if (ddown_TipoTribunal.SelectedItem.Text.Trim() == "Seleccionar" || ddown_Tribunal.SelectedItem.Text.Trim() == "Seleccionar")
        //    {
        //        if (wdc_fecha.Text == "")
        //        {
        //            fechaorden = Convert.ToDateTime("1900/01/01");
        //        }
        //        else
        //        {
        //            fechaorden = Convert.ToDateTime(wdc_fecha.Text);
        //        }
        //    }
        //    else
        //    {
        //        if (wdc_fecha.Text.Trim() == "")
        //        {
        //            datos_vacios = true;
        //            wdc_fecha.BackColor = colorCampoObligatorio;
        //            fechaorden = Convert.ToDateTime("1900/01/01");
        //        }
        //        else
        //        {
        //            wdc_fecha.ForeColor = Color.Empty;
        //            fechaorden = Convert.ToDateTime(wdc_fecha.Text);
        //        }
        //    }
        //    if (dtninoencontrado.Rows.Count > 0 && datos_vacios == false) // encontro a un niño
        //    {
        //        //if (!datos_vacios) // guardar
        //        //{
        //        try
        //        {
        //            callto_guardo_listaespera(Convert.ToInt32(lbl_CodNino.Text), 0, Convert.ToDateTime(wdc_Flistaespera.Text),
        //                Convert.ToDateTime("01/01/1900"), Convert.ToInt32(ddown_Tribunal.SelectedValue), txt_ruc.Text.Trim(), txt_rit.Text.Trim(), fechaorden,
        //                Convert.ToInt32(ddown_Causal.SelectedValue), Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(Session["IdUsuario"]),
        //                DateTime.Now, 0, Convert.ToInt32(ddown_comuna.SelectedValue),
        //                Convert.ToInt32(ddown_solicitante.SelectedValue));
        //            lbl_exito.Visible = true;
        //            lbl_error.Visible = false;
        //            window.alert(this, "Ingreso exitoso");
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "", "CerrarModalPopUp();", true);
        //            //Limpiar();
        //        }
        //        catch (Exception ex)
        //        {
        //            lbl_exito.Visible = false;
        //            lbl_error.Text = "Error al guardar";
        //            lbl_error.Visible = true;
        //        }
        //        finally
        //        {

        //        }
        //    }
        //    else if (dtninoencontrado.Rows.Count == 0 && datos_vacios == false)// no encontro niño, por lo cual no solo registramos en lista de espera, sino que agregamos al niño en la tabla ninos
        //    {
        //        if (txt_rut.Text.Trim() != string.Empty)
        //        {
        //            dtninoencontrado = nino1.Get_nino_by_data(txt_rut.Text.Trim().Replace(".", ""), txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());
        //        }
        //        else
        //        {
        //            dtninoencontrado = nino1.Get_nino_by_data("0", txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());
        //        }

        //        if (dtninoencontrado.Rows.Count == 0)
        //        {
        //            try
        //            {
        //                string rut = string.Empty;
        //                if (txt_rut.Text.Trim() == string.Empty)
        //                {
        //                    rut = "0";
        //                }
        //                else
        //                {
        //                    rut = txt_rut.Text.Trim();


        //                    rut = txt_rut.Text.Trim().Replace(".", "");
        //                }
        //                DateTime nacimiento = Convert.ToDateTime("01-01-1900");

        //                if (wdc_Fnacimiento.Text == "")
        //                {
        //                    nacimiento = Convert.ToDateTime("01-01-1900");
        //                }
        //                else
        //                {
        //                    nacimiento = Convert.ToDateTime(wdc_Fnacimiento.Text);
        //                }
        //                Ninos1TableAdapter ingresonuevo = new Ninos1TableAdapter();
        //                ingresonuevo.Insert_nino(
        //                    Convert.ToDateTime("1900-01-01 00:00:00.000"),
        //                    false,
        //                    rut,
        //                    Convert.ToString(rdbl_sexo.SelectedValue),
        //                    txt_nombres.Text.Trim().ToUpper(),
        //                    txt_ap_paterno.Text.Trim().ToUpper(),
        //                    txt_ap_materno.Text.Trim().ToUpper(),
        //                    nacimiento,
        //                    Convert.ToInt32(ddown_nacionalidad.SelectedValue),
        //                    0,
        //                    "0",
        //                    0,
        //                    "0",
        //                    "0",
        //                    false,
        //                    false,
        //                    false,
        //                    "N",
        //                    DateTime.Now,
        //                    Convert.ToInt32(Session["IdUsuario"]),
        //                    0,
        //                    null, Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue));

        //                Ninos1TableAdapter nino2 = new Ninos1TableAdapter();
        //                DataTable dtninoencontrado2 = nino1.Get_nino_by_data(rut, txt_nombres.Text.Trim(), txt_ap_paterno.Text.Trim(), txt_ap_materno.Text.Trim());

        //                if (dtninoencontrado2.Rows.Count > 0)
        //                {
        //                    lbl_CodNino.Text = dtninoencontrado2.Rows[0]["CodNino"].ToString();
        //                }
        //            }
        //            catch
        //            {

        //            }
        //        }

        //        try
        //        {
        //            callto_guardo_listaespera(Convert.ToInt32(lbl_CodNino.Text), 0, Convert.ToDateTime(wdc_Flistaespera.Text),
        //                Convert.ToDateTime("01/01/1900"), Convert.ToInt32(ddown_Tribunal.SelectedValue), txt_ruc.Text.Trim(), txt_rit.Text.Trim(), fechaorden,
        //                Convert.ToInt32(ddown_Causal.SelectedValue), Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(Session["IdUsuario"]),
        //                DateTime.Now, 0, Convert.ToInt32(ddown_comuna.SelectedValue),
        //                Convert.ToInt32(ddown_solicitante.SelectedValue));

        //            lbl_exito.Visible = true;
        //            lbl_error.Visible = false;
        //            window.alert(this, "Ingreso exitoso");
        //            //Limpiar();
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "", "CerrarModalPopUp();", true);
        //        }
        //        catch (Exception ex)
        //        {
        //            lbl_exito.Visible = false;
        //            lbl_error.Text = "Error al guardar";
        //            lbl_error.Visible = true;
        //        }
        //        finally
        //        {

        //        }
        //    }
        //}
        //else if (btn_agregar.Text == "Modificar")
        //{

        //    if (ddown_estado.SelectedValue == "10")
        //    {
        //        if (txtCausalFallecimiento.Text == "")
        //        {
        //            txtCausalFallecimiento.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            txtCausalFallecimiento.BackColor = System.Drawing.Color.Empty;
        //        }


        //        if (txtFechaDefuncion.Text == "")
        //        {
        //            txtFechaDefuncion.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            txtFechaDefuncion.BackColor = System.Drawing.Color.Empty;
        //        }

        //        if (ddlLugarFallecimiento.SelectedValue == "0")
        //        {
        //            ddlLugarFallecimiento.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            ddlLugarFallecimiento.BackColor = System.Drawing.Color.Empty;
        //        }

        //        if (ddlRegionFallecimiento.SelectedValue == "-2")
        //        {
        //            ddlRegionFallecimiento.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            ddlRegionFallecimiento.BackColor = System.Drawing.Color.Empty;
        //        }

        //        if (ddlComunaFallecimiento.SelectedValue == "0")
        //        {
        //            ddlComunaFallecimiento.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            ddlComunaFallecimiento.BackColor = System.Drawing.Color.Empty;
        //        }



        //    }


        //    DateTime fechaegreso;
        //    if (ddown_RegionTribunal.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        if (ddown_region.SelectedItem.ToString().Trim() == "Seleccionar")
        //        {
        //            ddown_region.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            ddown_region.BackColor = System.Drawing.Color.Empty;
        //            region = Convert.ToInt32(ddown_region.SelectedValue);
        //        }
        //    }
        //    else
        //    {
        //        region = Convert.ToInt32(ddown_RegionTribunal.SelectedValue);
        //    }
        //    if (wdc_F_egreso.Text != "")
        //    {
        //        if (Convert.ToDateTime(wdc_fecha.Text) > DateTime.Now)
        //        {
        //            tr_fecha_egreso.Visible = true;
        //            lbl_errorFecha3.Visible = true;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            tr_fecha_egreso.Visible = false;
        //            lbl_errorFecha3.Visible = false;
        //        }
        //    }

        //    if (ddown_TipoTribunal.SelectedItem.Text.Trim() == "Seleccionar" || ddown_Tribunal.SelectedItem.Text.Trim() == "Seleccionar")
        //    {
        //        if (wdc_fecha.Text == "")
        //        {
        //            fechaorden = Convert.ToDateTime("1900/01/01");
        //        }
        //        else
        //        {
        //            fechaorden = Convert.ToDateTime(wdc_fecha.Text);
        //        }
        //    }
        //    else
        //    {
        //        if (wdc_fecha.Text == "")
        //        {
        //            //datos_vacios = true;
        //            wdc_fecha.BackColor = colorCampoObligatorio;
        //            fechaorden = Convert.ToDateTime("1900/01/01");
        //        }
        //        else
        //        {
        //            wdc_fecha.ForeColor = Color.Empty;
        //            fechaorden = Convert.ToDateTime(wdc_fecha.Text);
        //        }
        //    }

        //    if (wdc_F_egreso.Text == "")
        //    {
        //        fechaegreso = Convert.ToDateTime("1900/01/01");
        //    }
        //    else
        //    {
        //        fechaegreso = Convert.ToDateTime(wdc_F_egreso.Text);
        //    }

        //    if (ddown_Causal.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_Causal.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_Causal.BackColor = System.Drawing.Color.Empty;
        //    }
        //    if (ddown_Causal.SelectedItem.ToString().Trim() == "No disponible")
        //    {
        //        ddown_Causal.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_Causal.BackColor = System.Drawing.Color.Empty;
        //    }


        //    if (ddown_solicitante.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_solicitante.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_solicitante.BackColor = System.Drawing.Color.Empty;
        //    }

        //    if (ddown_Proyecto.SelectedItem.ToString().Trim() == "Seleccionar")
        //    {
        //        ddown_Proyecto.BackColor = colorCampoObligatorio;
        //        datos_vacios = true;
        //    }
        //    else
        //    {
        //        ddown_Proyecto.BackColor = System.Drawing.Color.Empty;
        //    }

        //    if (ddown_TipoTribunal.SelectedItem.Text.Trim() == "Seleccionar" || ddown_Tribunal.SelectedItem.Text.Trim() == "Seleccionar")
        //    {
        //        if (wdc_fecha.Text == "")
        //        {
        //            fechaorden = Convert.ToDateTime("1900/01/01");
        //        }
        //        else
        //        {
        //            fechaorden = Convert.ToDateTime(wdc_fecha.Text);
        //        }
        //    }
        //    else
        //    {
        //        if (wdc_fecha.Text == "")
        //        {
        //            datos_vacios = true;
        //            wdc_fecha.BackColor = colorCampoObligatorio;
        //            fechaorden = Convert.ToDateTime("1900/01/01");
        //        }
        //        else
        //        {
        //            wdc_fecha.ForeColor = Color.Empty;
        //            fechaorden = Convert.ToDateTime(wdc_fecha.Text);
        //        }
        //    }

        //    if (ddown_estado.SelectedValue != "0")
        //    {
        //        if (wdc_F_egreso.Text == "")
        //        {
        //            wdc_F_egreso.BackColor = colorCampoObligatorio;
        //            datos_vacios = true;
        //        }
        //        else
        //        {
        //            wdc_F_egreso.BackColor = colorCampoObligatorio;
        //        }
        //    }

        //    if (datos_vacios == false) // actualizar Lista de Espera
        //    {
        //        try
        //        {
        //            if (fechaegreso.ToString() == "1900/01/01" && Convert.ToInt32(ddown_estado.SelectedValue) == 0)
        //            {


        //                callto_actualizo_listaespera(Convert.ToInt32(lbl_ICodIngresoLE.Text), Convert.ToInt32(lbl_CodNino.Text), 0, Convert.ToDateTime("1900/01/01"),
        //                        Convert.ToInt32(ddown_Tribunal.SelectedValue), txt_ruc.Text.Trim(), txt_rit.Text.Trim(), fechaorden,
        //                        Convert.ToInt32(ddown_Causal.SelectedValue), Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(Session["IdUsuario"]),
        //                        DateTime.Now, Convert.ToInt32(ddown_estado.SelectedValue), Convert.ToInt32(ddown_comuna.SelectedValue),
        //                        Convert.ToInt32(ddown_solicitante.SelectedValue));

        //                lbl_exito2.Visible = true;
        //                lbl_error.Visible = false;
        //                //window.alert(this, "Actualización exitosa.");
        //                //Limpiar();

        //                //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "mostrarAlerta();", true);
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "window.parent.cerrarModalModificar();", true);

        //            }
        //            else
        //            {

        //                callto_actualizo_listaespera(Convert.ToInt32(lbl_ICodIngresoLE.Text), Convert.ToInt32(lbl_CodNino.Text), 0, fechaegreso,
        //                        Convert.ToInt32(ddown_Tribunal.SelectedValue), txt_ruc.Text.Trim(), txt_rit.Text.Trim(), fechaorden,
        //                        Convert.ToInt32(ddown_Causal.SelectedValue), Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(Session["IdUsuario"]),
        //                        DateTime.Now, Convert.ToInt32(ddown_estado.SelectedValue), Convert.ToInt32(ddown_comuna.SelectedValue),
        //                        Convert.ToInt32(ddown_solicitante.SelectedValue));

        //                Alerta alerta = new Alerta();

        //                alerta.CodNino = Convert.ToInt32(lbl_CodNino.Text);
        //                alerta.CodRol = Session["contrasena"].ToString();
        //                alerta.IdUsrTermino = Convert.ToInt32(Session["IdUsuario"].ToString());

        //                cerrarAlerta(alerta);

        //                if (ddown_estado.SelectedValue == "10")
        //                {
        //                    ninocoll ncoll = new ninocoll();
        //                    ncoll.Update_ninos_F(Convert.ToInt32(lbl_CodNino.Text),
        //                        txtCausalFallecimiento.Text,
        //                        Convert.ToDateTime(txtFechaDefuncion.Text),
        //                        Convert.ToInt32(ddlLugarFallecimiento.SelectedValue),
        //                        Convert.ToInt32(ddlComunaFallecimiento.SelectedValue),
        //                        Convert.ToDateTime("01-01-1900"),
        //                        Convert.ToDateTime("01-01-1900"),
        //                        0,
        //                        Convert.ToDateTime("01-01-1900"),
        //                        "0");
        //                }

        //                lbl_exito2.Visible = true;
        //                lbl_error.Visible = false;
        //                window.alert(this, "Egreso Exitoso.");
        //                ///Limpiar();
        //                //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "mostrarAlerta();", true);
        //                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "window.parent.cerrarModalModificar();", true);
        //                //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "window.parent.cerrarModalModificar();", true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            lbl_exito2.Visible = false;
        //        }
        //        finally
        //        {

        //        }
        //    }
        //}

        #endregion
    }

    private void cerrarModalModificar(string msj)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "", "CerrarModalPopUp();", true);°
        ScriptManager.RegisterStartupScript(this, this.GetType(), "x", "window.parent.cerrarModalModificar('" + msj + "');", true);
    }

    private void cerrarModalIngreso(string msj)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "y", "window.parent.cerrarModalListaEspera('" + msj + "');", true);
    }

    private void cerrarModalEnOtroProyecto(string msj)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "z", "window.parent.cerrarModalLENNAEnOtroProyecto('" + msj + "');", true);
    }

    private int ActualizarNinoListaEspera(nino datosNino, NinoListaEspera datosNinoLE)
    {
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlTransaction sqlt;


        int resultadoUpdateListaEspera = 0, resultadoUpdateNino = 0, resultado = 0;

        ninocoll ncoll = new ninocoll();


        sqlc.Open();

        sqlt = sqlc.BeginTransaction();

        resultadoUpdateListaEspera = UpdateListaEsperaT(sqlc, sqlt, datosNinoLE);

        resultadoUpdateNino = ncoll.Update_ninos_F_T(sqlc, sqlt, datosNino);

        if (resultadoUpdateListaEspera > 0 && resultadoUpdateNino > 0)
        {
            sqlt.Commit();
            sqlc.Close();
            resultado = 1;
        }
        else
        {
            sqlt.Rollback();
            sqlc.Close();
            resultado = 0;
        }

        return resultado;
    }


    private void insertarNinoAListaDeEspera(string RutNino, string Nombres, string ApellidoPaterno, string ApellidoMaterno, DateTime fechaNacimiento,
        int CodNacionalidad, int CodTipoNacionalidad)
    {
        DataTable NinoEncontrado;
        NinoEncontrado = getNinoxDatos(RutNino, Nombres, ApellidoPaterno, ApellidoMaterno);

        if (NinoEncontrado.Rows.Count > 0)
        {
            callto_guardo_listaespera(Convert.ToInt32(lbl_CodNino.Text), 0, Convert.ToDateTime(wdc_Flistaespera.Text),
                        Convert.ToDateTime("01/01/1900"), Convert.ToInt32(ddown_Tribunal.SelectedValue), txt_ruc.Text.Trim(), txt_rit.Text.Trim(), Convert.ToDateTime(wdc_fecha.Text),
                        Convert.ToInt32(ddown_Causal.SelectedValue), Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(Session["IdUsuario"]),
                        DateTime.Now, 0, Convert.ToInt32(ddown_comuna.SelectedValue),
                        Convert.ToInt32(ddown_solicitante.SelectedValue));
        }
        else
        {
            return;
        }
    }


    private bool insertarNinoAListaDeEspera(NinoListaEspera ninoAListaEspera, nino datosNino)
    {
        bool ingresoCorrecto = false;
        int resultado = 0;
        DataTable NinoEncontrado;
        NinoEncontrado = getNinoxDatos(datosNino.rut, datosNino.Nombres, datosNino.Apellido_Paterno, datosNino.Apellido_Materno);

        if (NinoEncontrado.Rows.Count > 0)
        {
            //callto_guardo_listaespera(ninoAListaEspera);
            resultado = guardaListaEspera(ninoAListaEspera);
        }
        else
        {
            resultado = InsertNinoYListaEsperaTransact(ninoAListaEspera, datosNino);
        }

        if (resultado > 0)
        {
            ingresoCorrecto = true;
        }

        return ingresoCorrecto;
    }

    //private int insertNinoyListaEsperaTransact()
    //{
    //    int resultado = 0;

    //    SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

    //    SqlTransaction sqlt;

    //    sqlc.Open();

    //    sqlt = sqlc.BeginTransaction();

    //    int resultadoInsertNino = insertNinoDesdeListaEspera(sqlt, Convert.ToDateTime("1900-01-01 00:00:00.000"),
    //                                                            false,
    //                                                            txt_rut.Text.Replace(".", "").Trim(),
    //                                                            Convert.ToString(rdbl_sexo.SelectedValue),
    //                                                            txt_nombres.Text.Trim().ToUpper(),
    //                                                            txt_ap_paterno.Text.Trim().ToUpper(),
    //                                                            txt_ap_materno.Text.Trim().ToUpper(),
    //                                                            Convert.ToDateTime(wdc_Fnacimiento.Text),
    //                                                            Convert.ToInt32(ddown_nacionalidad.SelectedValue),
    //                                                            0,
    //                                                            "0",
    //                                                            0,
    //                                                            0,
    //                                                            "0",
    //                                                            false,
    //                                                            false,
    //                                                            false,
    //                                                            "N",
    //                                                            DateTime.Now,
    //                                                            Convert.ToInt32(Session["IdUsuario"]),
    //                                                            0,
    //                                                            0,
    //                                                            Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue));

    //    int resultadoInsertListaEspera = guardaListaEspera(sqlt, Convert.ToInt32(lbl_CodNino.Text), 0, Convert.ToDateTime(wdc_Flistaespera.Text),
    //                    Convert.ToDateTime("01/01/1900"), Convert.ToInt32(ddown_Tribunal.SelectedValue), txt_ruc.Text.Trim(), txt_rit.Text.Trim(), Convert.ToDateTime(wdc_fecha.Text),
    //                    Convert.ToInt32(ddown_Causal.SelectedValue), Convert.ToInt32(ddown_Proyecto.SelectedValue), Convert.ToInt32(Session["IdUsuario"]),
    //                    DateTime.Now, 0, Convert.ToInt32(ddown_comuna.SelectedValue),
    //                    Convert.ToInt32(ddown_solicitante.SelectedValue));

    //    if (resultadoInsertListaEspera > 0 && resultadoInsertNino > 0)
    //    {
    //        sqlt.Commit();
    //        resultado = 1;
    //    }
    //    else
    //    {
    //        sqlt.Rollback();
    //        resultado = 0;
    //    }

    //    return resultado;
    //}

    private int InsertNinoYListaEsperaTransact(NinoListaEspera datosninoLE, nino datosNino)
    {
        int resultado = 0;
        int resultadoInsertNino = 0;
        int resultadoInsertListaEspera = 0;

        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlTransaction sqlt;

        sqlc.Open();

        sqlt = sqlc.BeginTransaction();

        try
        {
            resultadoInsertNino = insertNinoDesdeListaEsperaT(sqlt, sqlc, datosNino);

            datosninoLE.CodNino = resultadoInsertNino;

            resultadoInsertListaEspera = guardaListaEsperaT(sqlt, sqlc, datosninoLE);

            if (resultadoInsertNino > 0 && resultadoInsertListaEspera > 0)
            {
                sqlt.Commit();
                sqlc.Close();
                resultado = 1;
            }
            else
            {
                sqlt.Rollback();
                sqlc.Close();
                resultado = 0;
            }

            return resultado;
        }
        catch
        {
            sqlt.Rollback();
            sqlc.Close();
            resultado = 0;

            return resultado;
        }
    }

    protected void cerrarAlerta(Alerta a)
    {
        IAlertas AlertaListaEspera = new AlertaListaEsperaPorAbuso();

        AlertaListaEspera.ActualizarAlerta(a);
    }
    public void Limpiar()
    {
        CargoDropDowns();
        CargoComunas();
        txt_rut.Text = string.Empty;
        txt_nombres.Text = string.Empty;
        txt_ap_paterno.Text = string.Empty;
        txt_ap_materno.Text = string.Empty;
        txt_nombres.Enabled = true;
        txt_ap_materno.Enabled = true;
        txt_ap_paterno.Enabled = true;
        rdbl_sexo.SelectedValue = "F";
        wdc_Fnacimiento.Text = "";
        wdc_fecha.Text = "";
        wdc_Flistaespera.Text = "";
        ddown_Tribunal.SelectedValue = "0";
        ddown_TipoCausal.SelectedValue = "0";
        ddown_Causal.SelectedValue = "0";
        txt_rit.Text = string.Empty;
        txt_ruc.Text = string.Empty;
        grd004.Visible = false;
        rdbl_sexo.Enabled = true;
        ddown_nacionalidad.Enabled = true;
        ddown_tipo_nacionalidad.Enabled = true;
        wdc_Fnacimiento.Enabled = true;

        try
        {
            ddown_Institucion.SelectedValue = Convert.ToString(SSnino.CodInst);
        }
        catch
        {

        }
    }
    public void CargaProyectos()
    {
        Proyectos2TableAdapter proy = new Proyectos2TableAdapter();
        DataTable dtProyectos = proy.GetData();

        DataTable dtProy = new DataTable();
        dtProy.Columns.Add("CodNombre");
        dtProy.Columns.Add("CodProyecto");

        DataRow drProyecto;
        drProyecto = dtProy.NewRow();
        drProyecto[0] = "Seleccione";
        drProyecto[1] = "0";
        dtProy.Rows.Add(drProyecto);
        for (int i = 0; i <= dtProyectos.Rows.Count; i++)
        {
            try
            {
                drProyecto = dtProy.NewRow();
                drProyecto[0] = "(" + dtProyectos.Rows[i]["Codproyecto"].ToString() + ") " + dtProyectos.Rows[i]["Nombre"].ToString();
                drProyecto[1] = dtProyectos.Rows[i]["Codproyecto"].ToString();
                dtProy.Rows.Add(drProyecto);
            }
            catch
            {

            }
        }

        if (dtProy.Rows.Count > 0)
        {
            try
            {
                ddown_Proyecto.Items.Clear();
                ddown_Proyecto.DataSource = dtProy;
                ddown_Proyecto.DataValueField = "Codproyecto";
                ddown_Proyecto.DataTextField = "CodNombre";
                ddown_Proyecto.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }

    private void getproyectos()
    {
        proyectocoll pcoll = new proyectocoll();
        string estado = "V";

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(UserId), estado, Convert.ToInt32(ddown_Institucion.SelectedValue));
        DataView dv1 = new DataView(dtproy);
        ddown_Proyecto.DataSource = dv1;
        ddown_Proyecto.DataTextField = "Nombre";
        ddown_Proyecto.DataValueField = "CodProyecto";
        dv1.Sort = "CodProyecto";
        ddown_Proyecto.DataBind();
    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
        HabilitoCajas();
    }
    protected void lnk_resultados_Click(object sender, EventArgs e)
    {
        carga_grilla();
    }
    protected void ddown_Proyecto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown_comuna_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargoComunas();
    }

    public void CargoComunas()
    {
        parComunasTableAdapter comunas = new parComunasTableAdapter();
        DataTable dtcomunas = comunas.GetComunas_by_Region(Convert.ToInt32(ddown_region.SelectedValue));

        if (dtcomunas.Rows.Count > 0)
        {
            ddown_comuna.DataSource = dtcomunas;
            ddown_comuna.DataTextField = "Descripcion";
            ddown_comuna.DataValueField = "CodComuna";
            ddown_comuna.DataBind();
        }
        else
        {
            DataTable dtTemp1 = new DataTable();
            dtTemp1.Columns.Add("CodComuna");
            dtTemp1.Columns.Add("Descripcion");

            DataRow drTemp1;
            drTemp1 = dtTemp1.NewRow();
            drTemp1[0] = "0";
            drTemp1[1] = "Seleccionar";
            dtTemp1.Rows.Add(drTemp1);

            ddown_comuna.DataSource = dtTemp1;
            ddown_comuna.DataTextField = "Descripcion";
            ddown_comuna.DataValueField = "CodComuna";
            ddown_comuna.DataBind();
        }
    }
    protected void imb003_Click(object sender, EventArgs e)
    {
        //window.close(this.Page);
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);
    }

    protected void Buscar()
    {
        lbl_exito.Visible = false;
        Function_Consulta();

        try
        {
            int codnino = 0, codproyecto = 0;

            codproyecto = Convert.ToInt32(ddown_Proyecto.SelectedValue);
            codnino = Convert.ToInt32(lbl_CodNino.Text);

            bool existe = NNAEnMismoProyecto(codnino, codproyecto);

            if (existe)
            {
                lbl_warning.Visible = true;
            }
        }
        catch
        {
        }
    }

    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        Buscar();
    }
    protected void rv_año_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("yyyy");
        ((RangeValidator)sender).MinimumValue = "1900";

    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    private void mostrarBusquedaxRut(bool mostrar)
    {
        if (mostrar)
        {
            tblBusquedaRut.Visible = true;
            thRut.Visible = true;
            tdRut.Visible = true;
        }
        else
        {
            if (tblBusquedaRut.Visible)
            {
                tblBusquedaRut.Visible = true; thRut.Visible = true; tdRut.Visible = true;
            }
            else
            {
                tblBusquedaRut.Visible = false; thRut.Visible = false; tdRut.Visible = false;
            }
        }

    }

    private void mostrarTablaDatos(bool mostrar)
    {
        if (mostrar)
            tblDatos.Visible = true;
        else
            tblDatos.Visible = false;
    }


    private void CargaNacionalidad()
    {
        //if (lbl_error.Visible)
        //    lbl_error.Visible = true;
        //else
        //    lbl_error.Visible = false;

        //ImageButton1.Attributes.Remove("disabled");
        //txt_rut.Enabled = true;

        if (ddown_nacionalidad.Items.FindByValue("0") == null)
        {
            ddown_nacionalidad.Items.Add(new ListItem("SELECCIONAR", "0"));
        }

        ddown_nacionalidad.Items.FindByValue("1").Enabled = true;

        //CHILENO
        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno(1) o nacionalizado(3) 
        {
            //QUITAR TODAS LAS NACIONALIDADES EXCEPTO CHILENA
            if (ddown_nacionalidad.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
            {
                for (int i = 2; i <= ddown_nacionalidad.Items.Count - 1; i++)
                {
                    if (ddown_nacionalidad.Items[i] != null) // el 8 no existe
                    {
                        ddown_nacionalidad.Items[i].Enabled = false;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                    }
                }
            }
            //ddown_nacionalidad.SelectedValue = "1";
            //ddown_nacionalidad.Enabled = false;
        }
        else // TODAS LAS DEMAS
        {
            //AGREGAR TODAS LAS NACIONALIDADES
            if (ddown_nacionalidad.Items.FindByValue("2").Enabled == false) //verifica si las nacionalidades que no son chilenas estan ocultas
            {
                for (int i = 2; i <= ddown_nacionalidad.Items.Count - 1; i++)
                {
                    if (ddown_nacionalidad.Items[i] != null) // el 8 no existe
                    {
                        ddown_nacionalidad.Items[i].Enabled = true;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                    }
                }

                //ddown_nacionalidad.Enabled = true;
                //tblBusquedaRut.Visible = false;
                //tblBusquedaRut.Visible = true;
                //tblDatos.Visible = true;
            }

            //EXTRANJERO
            if (ddown_tipo_nacionalidad.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
            {
                ddown_nacionalidad.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena
                //tblBusquedaRut.Visible = true;
                //thRut.Visible = true;
                //tdRut.Visible = true;
                //tblDatos.Visible = false;
                //ddown_nacionalidad.Enabled = true;
            }


            ddown_nacionalidad.SelectedValue = "0";
            ddown_nacionalidad.Enabled = true;

            if (ddown_tipo_nacionalidad.SelectedValue == "0") // restaura los valores por defecto para un nueva lista de espera
            {
                tblBusquedaRut.Visible = false;
                tblDatos.Visible = false;
                ddown_nacionalidad.Enabled = false;
            }

            Buscar();

            //if (ddown_tipo_nacionalidad.SelectedValue == "4" || ddown_tipo_nacionalidad.SelectedValue == "5")
            //{
            //tblBusquedaRut.Visible = false;
            //}
        }
    }

    private void CargarNacionalidad()
    {
        if (ddown_nacionalidad.Items.FindByValue("0") == null)
        {
            ddown_nacionalidad.Items.Add(new ListItem("SELECCIONAR", "0"));
        }

        //CHILENO
        // verifica si se selecciona tipo de nacionalidad chileno(1) o nacionalizado(3) 
        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3")
        {
            //QUITAR TODAS LAS NACIONALIDADES EXCEPTO CHILENA
            for (int i = 0; i < ddown_nacionalidad.Items.Count; i++)
            {
                if (ddown_nacionalidad.Items[i] != null) // el 8 no existe
                {
                    if (ddown_nacionalidad.Items[i].Value != "1")
                        ddown_nacionalidad.Items[i].Enabled = false;
                    else
                        ddown_nacionalidad.Items[i].Enabled = true;

                }
            }
            ddown_nacionalidad.SelectedValue = "1";
            ddown_nacionalidad.Enabled = false;
        }
        else // TODAS LAS DEMAS
        {
            for (int i = 0; i < ddown_nacionalidad.Items.Count; i++)
            {
                if (ddown_nacionalidad.Items[i] != null)
                {
                    if (ddown_nacionalidad.Items[i].Value == "1")
                        ddown_nacionalidad.Items[i].Enabled = false;
                    else
                        ddown_nacionalidad.Items[i].Enabled = true;

                }
            }
            ddown_nacionalidad.SelectedValue = "0";
            ddown_nacionalidad.Enabled = true;
        }

        mostrarBusquedaxRut((ddown_nacionalidad.SelectedValue != "0" && ddown_tipo_nacionalidad.SelectedValue != "0") ? true : false);
        ////AGREGAR TODAS LAS NACIONALIDADES
        ////verifica si las nacionalidades que no son chilenas estan ocultas
        //if (ddown_nacionalidad.Items.FindByValue("2").Enabled == false)
        //{
        //    for (int i = 2; i <= ddown_nacionalidad.Items.Count - 1; i++)
        //    {
        //        if (ddown_nacionalidad.Items[i] != null) // el 8 no existe
        //        {
        //            ddown_nacionalidad.Items[i].Enabled = true;
        //            //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = true;
        //        }
        //    }
        //}

        ////EXTRANJERO
        //if (ddown_tipo_nacionalidad.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
        //{
        //    ddown_nacionalidad.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena
        //    ddown_nacionalidad.SelectedValue = "0";
        //}

        //ddown_nacionalidad.Enabled = true;

        //if (ddown_tipo_nacionalidad.SelectedValue == "0") // restaura los valores por defecto para un nueva lista de espera
        //{
        //    tblBusquedaRut.Visible = false;
        //    tblDatos.Visible = false;
        //    ddown_nacionalidad.Enabled = false;
        //}

    }

    protected void ddown_tipo_nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarNacionalidad();
    }
    protected void ddown_nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        //CargarNacionalidad();
        mostrarBusquedaxRut((ddown_nacionalidad.SelectedValue != "0" && ddown_tipo_nacionalidad.SelectedValue != "0") ? true : false);
    }
    protected void ddown_estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown_estado.SelectedValue == "10")
        {
            trCausalFallecimiento.Visible = true;
            trFechaDefuncion.Visible = true;
            trLugarFallecimiento.Visible = true;
            trRegionFallecimiento.Visible = true;
            trComunaFallecimiento.Visible = true;
        }
        else
        {
            trCausalFallecimiento.Visible = false;
            trFechaDefuncion.Visible = false;
            trLugarFallecimiento.Visible = false;
            trRegionFallecimiento.Visible = false;
            trComunaFallecimiento.Visible = false;
        }
    }
    protected void ddlRegionFallecimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegionFallecimiento.SelectedValue != "0") ;
        {
            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddlRegionFallecimiento.SelectedValue));
            ddlComunaFallecimiento.Items.Clear();
            ddlComunaFallecimiento.DataSource = dv6;
            ddlComunaFallecimiento.DataTextField = "Descripcion";
            ddlComunaFallecimiento.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddlComunaFallecimiento.DataBind();
        }
    }
    protected void txtFechaDefuncion_TextChanged(object sender, EventArgs e)
    {

        RVFechaDefuncion.MinimumValue = wdc_Flistaespera.Text;
        RVFechaDefuncion.Validate();
    }
}
