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
using CustomWebControls;
using AjaxControlToolkit;
using System.Data.Common;

using System.Collections.Generic;
using System.Data.SqlClient;

public partial class mod_ninos_DatosdeGestion : System.Web.UI.Page
{
    #region Variables_Sesion
    public int ICodCurrentPage
    {
        get
        {
            if (ViewState["ICodCurrentPage"] == null)
            { ViewState["ICodCurrentPage"] = 0; }
            return Convert.ToInt32(ViewState["ICodCurrentPage"]);
        }
        set { ViewState["ICodCurrentPage"] = value; }
    }

    public int VICodInfDiagnostico
    {
        get
        {
            if (ViewState["ICodInfDiagnostico"] == null)
            { ViewState["ICodInfDiagnostico"] = -1; }
            return Convert.ToInt32(ViewState["ICodInfDiagnostico"]);
        }
        set { ViewState["ICodInfDiagnostico"] = value; }
    }
    public int VEstado_InfDiag
    {
        get
        {
            if (ViewState["VEstado_InfDiag"] == null)
            { ViewState["VEstado_InfDiag"] = -1; }
            return Convert.ToInt32(ViewState["VEstado_InfDiag"]);
        }
        set { ViewState["VEstado_InfDiag"] = value; }
    }

    public int VICodPFTI
    {
        get
        {
            if (ViewState["VICodPFTI"] == null)
            { ViewState["VICodPFTI"] = -1; }
            return Convert.ToInt32(ViewState["VICodPFTI"]);
        }
        set { ViewState["VICodPFTI"] = value; }
    }

    public int AuxEscolar
    {
        get
        {
            if (ViewState["AuxEscolar"] == null)
            { ViewState["AuxEscolar"] = -1; }
            return Convert.ToInt32(ViewState["AuxEscolar"]);
        }
        set { ViewState["AuxEscolar"] = value; }
    }
    public int Vnino_Nuevo
    {
        get
        {
            if (ViewState["Vnino_Nuevo"] == null)
            { ViewState["Vnino_Nuevo"] = -1; }
            return Convert.ToInt32(ViewState["Vnino_Nuevo"]);
        }
        set { ViewState["Vnino_Nuevo"] = value; }
    }
    public DateTime FechaIngreso
    {
        get
        {
            if (ViewState["FechaIngreso"] == null)
            { ViewState["FechaIngreso"] = -1; }
            return Convert.ToDateTime(ViewState["FechaIngreso"]);
        }
        set { ViewState["FechaIngreso"] = value; }
    }
    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set { Session["neo_SSnino"] = value; }
    }
    public String Inst
    {
        get { return (String)Session["Inst"]; }
        set { Session["Inst"] = value; }
    }
    public String Proy
    {
        get { return (String)Session["Proy"]; }
        set { Session["Proy"] = value; }
    }
    public DataTable DTordentribunales
    {
        get { return (DataTable)Session["DTordentribunales"]; }
        set { Session["DTordentribunales"] = value; }
    }
    public DataTable DTcausales
    {
        get { return (DataTable)Session["DTcausales"]; }
        set { Session["DTcausales"] = value; }
    }
    public DataTable DTlesiones
    {
        get { return (DataTable)Session["DTlesiones"]; }
        set { Session["DTlesiones"] = value; }
    }
    public ListItem OtItem
    {
        get { return (ListItem)Session["OtItem"]; }
        set { Session["OtItem"] = value; }
    }
    public int UserId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }
    public int Icodie
    {
        get { return (int)Session["SS_IcodIE"]; }
        set { Session["SS_IcodIE"] = value; }
    }

    public int ControlPostbackddl
    {
        get
        {
            if (ViewState["ControlPostbackddl"] == null)
            { ViewState["ControlPostbackddl"] = -1; }
            return Convert.ToInt32(ViewState["ControlPostbackddl"]);
        }
        set { ViewState["ControlPostbackddl"] = value; }
    }
    public int ControlPostbackddl_Motivacional
    {
        get
        {
            if (ViewState["ControlPostbackddl_Motivacional"] == null)
            { ViewState["ControlPostbackddl_Motivacional"] = -1; }
            return Convert.ToInt32(ViewState["ControlPostbackddl_Motivacional"]);
        }
        set { ViewState["ControlPostbackddl_Motivacional"] = value; }
    }

    public DataTable DTProyecto
    {
        get { return (DataTable)Session["DTProyecto"]; }
        set { Session["DTProyecto"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        /*------------*/
        //tab11.Visible = false;
        //tab12.Visible = false;
        //tab13.Visible = false;
        //tab14.Visible = false;
        //li_nav11.Visible = false;
        //li_articulo134bis.Visible = false;
        //li_planmotivacional.Visible = false;
        //li_derivacionpre.Visible = false;
        //li_flexibilizacion.Visible = false;
        /*------------*/
        /*RPA PESTAÑAS MIGRATORIO*/


        // identificoExtranjero();
        /*RPA FIN */
        //Se esconden alertas y labels
        alert.Attributes.Add("style", "display:none");
        lbl0055.Attributes.Add("style", "display:none");
        alert2.Attributes.Add("style", "display:none");
        lbl00552.Attributes.Add("style", "display:none");

        //ddl_EtapasRealizadas.Visible = false;
        //ddown006.Visible = false;

        //Muestra o oculta Formulario

        mostrar_collapse(true);

        if (CurrentPage.Value != null && CurrentPage.Value != "")
        {

            muestra_pestaña(int.Parse(CurrentPage.Value));
            lbl_resumen_filtro.Text = "<br>";
            lbl_resumen_filtro.Text += "<strong>Busqueda:</strong>";
            lbl_resumen_filtro.Text += " " + ddl_Proyectos.SelectedItem.Text.Trim() + " ";
            if (txt003.Text != "")
            {
                lbl_resumen_filtro.Text += "//" + " " + txt003.Text.Trim() + " ";
            }

            if (txt004.Text != "")
            {
                lbl_resumen_filtro.Text += txt004.Text.Trim() + " ";
            }
            if (txt005.Text != "")
            {
                lbl_resumen_filtro.Text += " " + txt005.Text.Trim() + " ";
            }
        }

        btn002ds.Click += btn002ds_Click;
        //limpiagestion();
        #region Ispostback
        if (!IsPostBack)
        {

            # region VALIDACION USUARIO


            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                //053760A4-E027-40D6-8F8A-3F8A64DD075C 2.1 
                //79270734-C383-487D-8EAB-BC63F1521932 2.2
                //3FE17A39-80A0-4F7A-9A46-EC2BB934697D 2.3
                //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
                //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5
                if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                {
                    int v = 0;
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }

            #endregion



                CalendarExtender3_calFechaCambio.StartDate = SSnino.fchingdesde;
                CalendarExtender3_calFechaCambio.EndDate = DateTime.Now;

                CalendarExtender1.StartDate = SSnino.fchingdesde;
                CalendarExtender1.EndDate = DateTime.Now;

                ddown017.Text = DateTime.Now.ToShortDateString();
                grd007.Visible = false;
                grd008.Visible = false;
                ddl_Proyectos.Visible = true;
                // btn006.Visible = false;
                btn007.Visible = false;
                btn0010.Visible = false;

                Ninos_busqueda1.Visible = false;

                getinstituciones();
                getproyectos();

                if (Request.QueryString["CODNUEVO"] != null)
                {
                    SSnino.CodNino = Convert.ToInt32(Request.QueryString["CODNUEVO"]);
                    Vnino_Nuevo = 1;
                    getninonuevo();


                    #region BloqueoNinoEnGestacion



                    #endregion
                }

                if (Request.QueryString["param001"] == "S2")
                {
                    GetSelectedInfo();
                    muestra_pestaña(1);

                }
                if (Request.QueryString["param001"] == "S1")
                {
                    GetIngreso();

                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos2();
                    ddl_Proyectos.SelectedValue = Request.QueryString["codinst"];
                    SSnino.CodProyecto = Convert.ToInt32(Request.QueryString["codinst"]);
                    getintitucionesver();
                }
                else if (Session["NNA"] != null)
                {
                    oNNA NNA = (oNNA)Session["NNA"];



                    //    string cinst = ddown001.SelectedValue.ToString();
                    //    string cproy = ddl_Proyectos.SelectedValue.ToString();
                    //    Int32 codie = SSnino.ICodIE;
                    //    Int32 cnino = SSnino.CodNino;
                      
                    SSnino.Apellido_Paterno = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
                    SSnino.Apellido_Materno = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
                    SSnino.Nombres = HttpUtility.HtmlDecode(NNA.NNANombres);
                    SSnino.rut = NNA.NNARut;
                    if (NNA.NNACodProyecto == "")
                    {
                        SSnino.CodProyecto = 0;
                    }
                    else
                    {
                        SSnino.CodProyecto = Convert.ToInt32(NNA.NNACodProyecto);
                    }

                    SSnino.CodNino = NNA.NNACodNino;
                    SSnino.ICodIE = NNA.NNACodIE;

                    //RPA
                    Session["SS_ICodIE"] = SSnino.ICodIE = NNA.NNACodIE;

                    txt003.Text = NNA.NNAApePaterno;
                    txt005.Text = NNA.NNANombres;
                    txt004.Text = NNA.NNAApeMaterno;

                    ddown001.SelectedValue = NNA.NNACodInstitucion;
                    getproyectos();
                    ddl_Proyectos.SelectedValue = NNA.NNACodProyecto;

                    //int icodiee = NNA.NNACodIE;
                    lbl004.Text = NNA.NNAFechaNacimiento;
                    lbl003.Text = NNA.NNAFechaIngreso;
                    if (NNA.NNACodIE != 0)
                    {
                        //imb_lupaproyecto.Visible = false;
                        imb_lupaproyecto.Attributes.Add("disabled", "true");
                        imb_lupa_institucion.Attributes.Add("disabled", "true");



                        btnbuscar.Visible = false;
                        CargaTabs();
                    
                    }
                    else
                    {
                        //imb_lupaproyecto.Visible = true;
                        imb_lupaproyecto.Attributes.Remove("disabled");
                        imb_lupa_institucion.Attributes.Remove("disabled");
                        btnbuscar.Visible = true;
                    }
                    //JVB al cargar ONN y buscar se pega, para evitar eso se desabilita buscar hasta que se limpie
                    //btnbuscar.Visible = true;
                    tr_fecha_ingreso.Visible = true;
                    tr_fecha_nacimiento.Visible = true;

                    lbl_resumen_filtro.Text = "<br>";
                    lbl_resumen_filtro.Text += "<strong>Busqueda:</strong>";
                    lbl_resumen_filtro.Text += " " + ddl_Proyectos.SelectedItem.Text.Trim() + " ";
                    if (txt003.Text != "")
                    {
                        lbl_resumen_filtro.Text += "//" + " " + txt003.Text.Trim() + " ";
                    }

                    if (txt004.Text != "")
                    {
                        lbl_resumen_filtro.Text += txt004.Text.Trim() + " ";
                    }
                    if (txt005.Text != "")
                    {
                        lbl_resumen_filtro.Text += " " + txt005.Text.Trim() + " ";
                    }

                    lbl_resumen_filtro.Visible = true;
                    lbl_resumen_filtro.Style.Add("display", "none");
                    lbl004.Text = NNA.NNAFechaNacimiento;
                    lbl003.Text = NNA.NNAFechaIngreso;
                }
            }
            //carga parametricas djj
            //getcesepermiso();
            //ObtenerArticulo134();
            //getcategoria();
            //GetParCondicionPM1();
            //GetParCondicionPM3();
            //gettipoflexibilidad();
            //ObtenerFlexibilizacion();
            //fin carga parametricas

            //ObtenerPlanMotivacional();
            //getcesepermiso();
            //ObtenerArticulo134();
            //getcategoria();
            //GetParCondicionPM1();
            //GetParCondicionPM3();
            //gettipoflexibilidad();
            //ObtenerFlexibilizacion();

            validatescurity(); //LO ULTIMO DEL LOAD

            //--------------------------------------------------------------------  
            // JOVM - 03/02/2015
            // Se obtiene información desde Session en el caso de contener datos.

            //-----------------------------------------------
        }
        #endregion
        CalendarExtender2_cal001.EndDate = DateTime.Now;
        CalendarExtender2_cal001.StartDate = SSnino.fchingdesde;

        //jvb correccion al ONN cuando ONN no trae CodProyecto
        //------------------------------------------------------
        //RPA - 12/07/2016
        //if (ControlPostbackddl != -1)
        //{
        //    muestra_pestaña(0);
        //    muestra_pestaña(11);
        //    ControlPostbackddl = -1;
        //}
        //if (ddl_condicion1.SelectedValue != "" && ddl_condicion3.SelectedValue != "" && ddl_categoria.SelectedValue != "")
        //{ pnl_utab12.Visible = true; }

        //if (ddl_tipoParflexibilidad.SelectedValue != "")
        //{ pnl_utab14.Visible = true; }
        //if (ControlPostbackddl_Motivacional != -1)
        //{
        //    muestra_pestaña(0);
        //    muestra_pestaña(11);
        //    pnl_utab14.Visible = false;
        //    pnl_utab11.Visible = false;
        //    pnl_utab12.Visible = true;
        //}
        //--------------------------------------------------
    }


    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        #region Ingreso

        //79270734-C383-487D-8EAB-BC63F1521932 2.2
        //if (!window.existetoken("79270734-C383-487D-8EAB-BC63F1521932"))
        //{

        //    lbtn004.Visible = false;

        //}
        #endregion


        #region VALIDA DATOS DE GESTION


        //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
        if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36"))
        {
            utab2_nino.Visible = false;
        }

        //169A2222-0D01-4B62-A224-41B67BAD0387 2.4_INGRESAR
        if (!window.existetoken("169A2222-0D01-4B62-A224-41B67BAD0387"))
        {
            //SOLICITUD DE DILIGENCIAS
            btn001.Visible = false;

            ////DATOS DE SALUD
            grd003.Columns[5].Visible = false;
            grd004.Columns[6].Visible = false;
            grd005.Columns[5].Visible = false;

            btn002ds.Visible = false;
            btn003ds.Visible = false;
            btn004.Visible = false;

            //INFORME DE DIAGNOSTICO


            lnk001.Visible = false;
            //btn008.Visible = false;
            btn008.Attributes.Add("disabled", "disabled");
            // btn006.Visible = false;
            btn007.Visible = false;
            btn0010.Visible = false;

            //PERSONA RELACIONADA
            btn005pr.Visible = false;

            //Contacto
            btn005aa.Visible = false;

            //Ordenes de tribunal
            btnOrdenesTribunal.Visible = false;

            //CAUSALES DE INGRESO
            btnback003.Visible = false;
        }

        //21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        {
            //SOLICITUD DE DILIGENCIAS
            grd002.Columns[7].Visible = false;

            //DATOS DE SALUD
            grd003.Columns[5].Visible = false;
            grd004.Columns[6].Visible = false;
            grd005.Columns[4].Visible = false;

            //INFORME DE DIAGNOSTICO
            grd008.Columns[3].Visible = false;

            //PERSONA RELACIONADA
            grd006.Columns[6].Visible = false;

            //Calidad Juridica
            btn008aa.Visible = false;
        }

        //9273FC38-331B-4E54-B78E-1E7CB41CB0B5 2.4_ELIMINAR
        if (!window.existetoken("9273FC38-331B-4E54-B78E-1E7CB41CB0B5"))
        {

            //SOLICITUD DE DILIGENCIAS
            grd002.Columns[8].Visible = false;

            //DATOS DE SALUD
            grd003.Columns[6].Visible = false;
            grd004.Columns[7].Visible = false;
            grd005.Columns[5].Visible = false;

            //INFORME DE DIAGNOSTICO
            grd008.Columns[4].Visible = false;

            //PERSONA RELACIONADA
            // No se eliminan personas relacionadas




        }


        #endregion


    }

    #endregion


    #region buscador principal
    private int searchgrid()
    {

        ninocoll ncoll = new ninocoll();

        int counter = 0;

        SSnino.Apellido_Paterno = txt003.Text;
        SSnino.Apellido_Materno = txt004.Text;
        SSnino.Nombres = txt005.Text;

        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);

        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);



        if (counter < 200 && counter > 0)
        {

            if (ddl_Proyectos.SelectedIndex > 0)
            {


            }
            lbtn005.Visible = false;


        }
        else
        {
            lbtn005.Visible = true;

        }



        return counter;


    }

    public void getninonuevo()
    {


        ninocoll ncoll = new ninocoll();
        nino n = ncoll.GetData(SSnino.CodNino.ToString(), "0");


        txt003.Text = n.Apellido_Paterno.ToUpper();
        txt004.Text = n.Apellido_Materno.ToUpper();
        txt005.Text = n.Nombres.ToUpper();
        lbl004.Text = n.FechaNacimiento.ToShortDateString();

        ddown001.SelectedValue = Inst;

        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(UserId), "V", Convert.ToInt32(Inst));
        DataView dv1 = new DataView(dtproy);
        ddl_Proyectos.DataSource = dv1;
        ddl_Proyectos.DataTextField = "Nombre";
        ddl_Proyectos.DataValueField = "CodProyecto";
        dv1.Sort = "CodProyecto";
        ddl_Proyectos.DataBind();

        ddl_Proyectos.SelectedValue = Proy;

        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);

        txt003.ReadOnly = true;
        txt004.ReadOnly = true;
        txt005.ReadOnly = true;

        ddown001.Enabled = true;
        ddl_Proyectos.Enabled = true;
    }

    public void GetIngreso()
    {
        txt003.Text = SSnino.Apellido_Paterno;
        txt004.Text = SSnino.Apellido_Materno;
        txt005.Text = SSnino.Nombres;

        lbl003.Text = SSnino.fchingdesde.ToShortDateString();



        Ninos_busqueda1.Visible = false;
    }

    protected void lnkbsearch_Click(object sender, EventArgs e)
    {
        lblbmsg.ForeColor = System.Drawing.Color.Red;
        lblbmsg.Visible = false;
        searchgrid();
        Ninos_busqueda1.Visible = false;

        pnl001.Visible = false;
        utab2_nino.Visible = false;
        if (ddl_Proyectos.SelectedIndex > 0)
        {
            //lbtn004.Visible = true;
        }
    }

    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        // DataTable dtinst = icoll.GetData(UserId);
        DataTable dtinst = icoll.GetData_DataSet((DataSet)Session["dsParametricas"]);
        DataView dv1 = new DataView(dtinst);
        dv1.Sort = "Nombre";
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";

        ddown001.DataBind();

        // <---------- DPL ---------->  09-08-2010
        if (dtinst.Rows.Count == 2)
            ddown001.SelectedIndex = 1;
        else
            ddown001.SelectedIndex = 0;
        // <---------- DPL ---------->  09-08-2010
    }

    protected void lnkbtnver_Click(object sender, EventArgs e)
    {

        if (searchgrid() < 200)
        {
            SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
            SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
            Ninos_busqueda1.Visible = true;

            pnl001.Visible = false;
            utab2_nino.Visible = false;



        }
        else
        {
            pnl001.Visible = false;
            utab2_nino.Visible = false;
            Ninos_busqueda1.Visible = false;



        }


    }

    protected void UltraWebGrid1_InitializeLayout(object sender, EventArgs e)
    {

    }

    protected void grd001_InitializeLayout(object sender, EventArgs e)
    {

    }

    protected void pnl001_ExpandedStateChanging(object sender, EventArgs e)
    {

    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null) NNA = new oNNA();

        NNA.NNACodInstitucion = ddown001.SelectedValue;
        Session["NNA"] = NNA;

        getproyectos();

        lbtn005.Visible = false;

    }
    protected void chk002F2_CheckedChanged(object sender, EventArgs e)
    {
        getproyectos();
    }

    private void getproyectos()
    {
        proyectocoll pcoll = new proyectocoll();
        string estado = "V";

        if (chk002F2.Checked == false)
        {
            estado = "V";
        }
        else
        {
            estado = "C";
        }


        DataTable dtproy = pcoll.GetData(Convert.ToInt32(UserId), estado, Convert.ToInt32(ddown001.SelectedValue));
        DataView dv1 = new DataView(dtproy);
        // <---------- DPL ---------->  09-08-2010
        dv1.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddl_Proyectos.SelectedIndex = 0;
        ddl_Proyectos.DataSource = dv1;
        ddl_Proyectos.DataTextField = "Nombre";
        ddl_Proyectos.DataValueField = "CodProyecto";//"Codigo Proyecto";
        dv1.Sort = "CodProyecto";
        ddl_Proyectos.DataBind();

        if (dv1.Count == 2)
        {
            ddl_Proyectos.SelectedIndex = 1;
            ddown002_SelectedIndexChanged(new object(), new EventArgs());
        }

        if (dtproy.Rows.Count > 0)
        {
            SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
        }
    }
    private void getproyectos2()
    {
        proyectocoll pcoll = new proyectocoll();
        string estado = "V";

        if (chk002F2.Checked == false)
        {
            estado = "V";
        }
        else
        {
            estado = "C";
        }


        DataTable dtproy = pcoll.GetData(Convert.ToInt32(UserId), estado, Convert.ToInt32(ddown001.SelectedValue));
        DataView dv1 = new DataView(dtproy);
        ddl_Proyectos.DataSource = dv1;
        ddl_Proyectos.DataTextField = "Nombre";
        ddl_Proyectos.DataValueField = "CodProyecto";//"Codigo Proyecto"; 
        dv1.Sort = "CodProyecto";
        ddl_Proyectos.DataBind();


    }
    private void getintitucionesver()
    {

        Ninos_busqueda1.Visible = false;
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
        if (ddl_Proyectos.SelectedIndex > 0)
        {

            btnbuscar.Visible = true;


        }
        else
        {

            lbtn005.Visible = false;
            btnbuscar.Visible = true;

        }

    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        if (NNA == null) NNA = new oNNA();

        NNA.NNACodInstitucion = ddown001.SelectedValue;
        NNA.NNACodProyecto = ddl_Proyectos.SelectedValue;
        Session["NNA"] = NNA;

        getintitucionesver();
    }

    protected void mnu001_MenuItemClicked(object sender, EventArgs e)
    {

    }
    protected void grd001btn001_Click(object sender, EventArgs e)
    {

    }
    public void changeuc()
    {
        Ninos_busqueda1.Visible = false;

    }

    private void clean_tab()
    {
    }

    private void clean_form()
    {

        Ninos_busqueda1.Visible = false;

        lbtn005.Visible = true;
        btnbuscar.Visible = true;


        lbtn005.Visible = false;
        btnbuscar.Visible = true;

        txt003.Text = string.Empty;
        txt004.Text = string.Empty;
        txt005.Text = string.Empty;

        txt003.ReadOnly = false;
        txt004.ReadOnly = false;
        txt005.ReadOnly = false;


        lblbmsg.Visible = false;

        ddown001.Enabled = true;
        ddl_Proyectos.Enabled = true;


        lbl004.Text = string.Empty;


        pnl001.Visible = false;
        utab2_nino.Visible = false;

        ddown001.SelectedIndex = 0;
        ddl_Proyectos.SelectedIndex = 0;

        SSnino = new nino();
    }
    protected void lbtn002_Click(object sender, EventArgs e)
    {
        clean_form();
    }

    #endregion

    #region selected info

    public void GetSelectedInfo()
    {
        utab2_nino.Visible = true;
        pnl001.Visible = true;


        niños_migracion.carga_situacion_migratoria();
        //txt001.Text = SSnino.rut;
        //txt002.Text = SSnino.CodNino.ToString();

        lbl003.Text = SSnino.fchingdesde.ToShortDateString();

        /*
        * CET 06-08-2015 SE COMENTA YA QUE ESTÁ EN EL LOAD
         * 
         * 
        * Verifica si tiene datos la SESSION
        */
        //if (Session["NNA"] == null)
        //{
        //    txt003.Text = SSnino.Apellido_Paterno;
        //    txt004.Text = SSnino.Apellido_Materno;
        //    txt005.Text = SSnino.Nombres;   
        string cinst = ddown001.SelectedValue.ToString();
        string cproy = ddl_Proyectos.SelectedValue.ToString();
        //    string rut = SSnino.rut;
        //    Int32 codie = SSnino.ICodIE;
        //    Int32 cnino = SSnino.CodNino;

        //    oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, txt005.Text, txt003.Text, txt004.Text, lbl003.Text, lbl004.Text);
        //    Session["NNA"] = NNA;
        //    //valida session
        //}

        identificoExtranjero(SSnino.CodNino);//; RPA

        //-----------------------------------------------------------------------------------------
        //lbl000.Text = Resources.lblmessages.Solicitud_de_Diligencias;
        lbl001.Text = Resources.lblmessages.Discapacidad;
        lbl002.Text = Resources.lblmessages.Hechos_de_Salud;
        Label3.Text = Resources.lblmessages.Enfermedades_Cronicas;

        Ninos_busqueda1.Visible = false;

        diagnosticoscoll dcoll = new diagnosticoscoll();
        dilegenciascoll dicoll = new dilegenciascoll();
        ninocoll ncoll = new ninocoll();


        DataTable dt2 = dicoll.GetDiligencias(SSnino.ICodIE.ToString());
        DataView dv2 = new DataView(dt2);
        dv2.Sort = "FechaSolicitud";
        grd002.DataSource = dv2;
        grd002.DataBind();


        if (grd002.Rows.Count == 0)
        {
            lbl001.Text = "";
        }
        else
        {
            //lbl000.Text = "Solicitud de Diligencias";
        }

        if (SSnino.Estado == -1)
        {
            lbl001.Text = "La Solicitud Ingresada ya existe";
        }
        else if (SSnino.Estado == 2)
        {
            lbl001.Text = "No puede agregar otra diligencia por, ya que el mes esta Cerrado";
        }
        else
        {
            lbl001.Text = "";
        }
        //if (dt2.Rows.Count == 0)
        //{
        //    //lbl000.Text += Resources.lblmessages.No_Data;
        //}



        DataTable dt3 = dcoll.GetDiagnosticosDiscapacidad(SSnino.ICodIE.ToString());

        DataView dv3 = new DataView(dt3);
        grd003.DataSource = dv3;
        grd003.DataBind();

        //lbl001.Text = (dt3.Rows.Count == 0) ? Resources.lblmessages.No_Data : Resources.lblmessages.Discapacidad;

        DataTable dt4 = dcoll.GetHechosSalud(SSnino.ICodIE.ToString());
        DataView dv4 = new DataView(dt4);
        grd004.DataSource = dv4;
        grd004.DataBind();

        //lbl002.Text = (dt4.Rows.Count == 0) ? Resources.lblmessages.No_Data : Resources.lblmessages.Hechos_de_Salud;

        DataTable dt5 = dcoll.GetNinosEnfermedadesCronicas(SSnino.ICodIE.ToString());
        DataView dv5 = new DataView(dt5);
        grd005.DataSource = dv5;
        grd005.DataBind();

        //Label3.Text = (dt5.Rows.Count == 0) ? Resources.lblmessages.No_Data : Resources.lblmessages.Enfermedades_Cronicas;

        DataTable dt6 = ncoll.GetIngresoPersonaRelacionada(SSnino.ICodIE.ToString());
        DataView dv6 = new DataView(dt6);
        grd006.DataSource = dv6;
        grd006.DataBind();
        //if (dt6.Rows.Count == 0)
        //{
        //    lbl005.Text += Resources.lblmessages.No_Data;
        //}
        //else
        //{
        //    lbl005.Visible = false;
        //}


        parcoll pcoll = new parcoll();

        DataTable dt7 = pcoll.GetparEtapasIntervencion();
        DataView dv7 = new DataView(dt7);
        //----------------------------------------------------------------
        // JOVM - 16/03/2015
        // Se cambia el nombre del DDL para evitar caída del programa.
        //ddown002.Items.Clear();
        //ddown002.ClearSelection();
        //ddown002.DataSource = dv7;
        //ddown002.DataValueField = "CodEtapasIntervencion";
        //ddown002.DataTextField = "Descripcion";
        //ddown002.DataBind();
        //ddown001.Items.Clear();
        ddl_EtapasRealizadas.ClearSelection();
        ddl_EtapasRealizadas.DataSource = dv7;
        ddl_EtapasRealizadas.DataValueField = "CodEtapasIntervencion";
        ddl_EtapasRealizadas.DataTextField = "Descripcion";
        ddl_EtapasRealizadas.DataBind();
        //try
        //{
        //    //Response.Redirect("DatosdeGestion.aspx");
        //    ddown001.DataBind(); 
        //}
        //catch (Exception ex)
        //{

        //    //ScriptManager.RegisterStartupScript(this, GetType(), "", "volverAtras()", true);

        //    ddown001.SelectedValue = Convert.ToString(0);
        //    ddown002.SelectedValue = Convert.ToString(0);
        //    txt004.Text = ""; txt004.ReadOnly = false;
        //    txt005.Text = ""; txt005.ReadOnly = false;
        //    txt003.Text = ""; txt003.ReadOnly = false;
        //    utab2.Visible = false;
        //    pnl001.Visible = false;
        //    utab2.Visible = false;
        //    // JOVM - 03/02/2015
        //    // Se habilitan DDWList de Instituciones y Proyectos
        //    // y se limpian datos de la SESSION["NNA"]
        //    ddown001.Enabled = true;
        //    ddown002.Enabled = true;
        //    Session["NNA"] = null;
        //    //----------------------------
        //    //JVB
        //    btnbuscar.Visible = true;
        //    lbl004.Text = "";
        //};
        //ddown001.DataBind();


        DataTable dt12 = pcoll.GetparTerminoDiagnostico();
        DataView dv12 = new DataView(dt12);
        ddown006.Items.Clear();
        ddown006.ClearSelection();
        ddown006.DataSource = dv12;
        ddown006.DataValueField = "CodEtapasIntervencion";
        ddown006.DataTextField = "Descripcion";
        dv12.Sort = "Descripcion";
        ddown006.DataBind();


        DataTable dt9 = dcoll.GetInformesDiagnosticos(SSnino.ICodIE.ToString());
        if (dt9.Rows.Count >= 1)
        {
            SSnino.ICodinformediagnostico = Convert.ToInt32(dt9.Rows[0][0]);
            SSnino.InicioInformeDiagnostico = Convert.ToDateTime(dt9.Rows[0][2]);
            cal001.Text = Convert.ToDateTime(dt9.Rows[0][2].ToString()).ToString("dd-MM-yyyy");

            if (SSnino.Estado == -1)
            {
                lbl0022f.Text = "La Accion ya fue registrada";
            }
            else
            {
                lbl0022f.Text = "";
            }



            cal003.Text = "";



            DataTable dt10 = dcoll.GetAccionesInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));//Convert.ToString(SSnino.ICodinformediagnostico));
            DataView dv10 = new DataView(dt10);
            grd008.DataSource = dv10;
            //dv10.Sort = "FechaAccion";
            grd008.DataBind();


            DataTable dt8 = dcoll.GetEtapasInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));
            DataView dv8 = new DataView(dt8);
            grd007.DataSource = dv8;
            dv8.Sort = "FechaEtapa";
            grd007.DataBind();

            DataTable dt77 = ncoll.callto_get_informediagnostico(Convert.ToInt32(SSnino.ICodIE.ToString()));


            DataView dv77 = new DataView(dt77);
            grd0012f.DataSource = dv77;
            dv77.Sort = "ICodInformeDiagnostico";
            grd0012f.DataBind();


            for (int i = 0; i < grd0012f.Rows.Count; i++)
            {
                try
                {

                    if (grd0012f.Rows[i].Cells[4].Text == "01-01-1900")
                    {
                        grd0012f.Rows[i].Cells[4].Text = "-";

                    }
                }
                catch { }



            }

            cal001.Enabled = true;
            ddown003.Enabled = true;
            btn008.Attributes.Remove("disabled");

            for (int i = 0; i < grd0012f.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dt77.Rows[i][2].ToString()).ToShortDateString() == "01-01-1900") // si esta abierto
                {
                    cal001.Enabled = false;
                    ddown003.Enabled = false;
                    //btn008.Enabled = false;
                    btn008.Attributes.Add("disabled", "disabled");


                    VEstado_InfDiag = 1;
                    break;
                }
                else
                {
                    divDetalleDiag.Visible = false;
                }
            }
        }
        else
        {
            cal001.Text = "";
            lbl0022f.Text = "";
            cal003.Text = "";
            grd008.DataSource = null;
            grd008.DataBind();
            grd007.DataSource = null;
            grd007.DataBind();
            grd0012f.DataSource = null;
            grd0012f.DataBind();
            cal001.Enabled = true;
            ddown003.Enabled = true;
            //btn008.Enabled = false;
            btn008.Attributes.Remove("disabled");

        }

        #region ModificacionIngresonino

        #region PersonaContacto

        parcoll par = new parcoll();

        DataView dvPC = new DataView(par.GetparTipoRelacionPersonaContacto());

        ddown001_E.DataSource = dvPC;
        ddown001_E.DataTextField = "Descripcion";
        ddown001_E.DataValueField = "CodTipoRelacionPersonaContacto";
        dvPC.Sort = "Descripcion";
        ddown001_E.DataBind();

        DataTable dt88 = ncoll.callto_getingresos_egresos(SSnino.ICodIE);
        txt001_E.Text = dt88.Rows[0]["PersonaContacto"].ToString();

        try
        {
            ddown001_E.Items.FindByValue(dt88.Rows[0]["CodTipoRelacionPersonaContacto"].ToString()).Selected = true;
        }
        catch { }
        #endregion

        #region Ordenes de tribunal

        //  ninocoll ncoll = new ninocoll();


        //tddown017.MinDate = SSnino.fchingdesde;
        //tddown017.MaxDate = DateTime.Now;
        CalendarExtender3_ddown017.EndDate = DateTime.Now;
        //CalendarExtender3_ddown017.StartDate = SSnino.fchingdesde;


        DataTable dtGetTribunal = ncoll.callto_get_tribunalingreso(SSnino.ICodIE);
        DataView dvTribunal = new DataView(dtGetTribunal);
        grd001U2.DataSource = dvTribunal;
        dvTribunal.Sort = "Tribunal";
        grd001U2.DataBind();

        proyectocoll proyectoc = new proyectocoll();
        DTProyecto = proyectoc.GetProyectos(ddl_Proyectos.SelectedValue.ToString());


        if (DTProyecto.Rows.Count > 0)
        {
            if (DTProyecto.Rows[0]["TipoProyecto"].ToString() == "7" || Convert.ToInt32(DTProyecto.Rows[0]["OTObligatorio"]) == 1)
            {
                if (dtGetTribunal.Rows.Count == 0)
                {
                    verificaOTribunal(true);
                }
                else
                {
                    verificaOTribunal(false);
                }
            }
        }        

        // ninocoll ncoll = new ninocoll();
        DataTable dtOT = new DataTable();
        dtOT = ncoll.callto_consulta_calidajuridica(SSnino.ICodIE);

        // carga combos

        DataView dv13 = new DataView(par.GetparRegion());
        ddown014.Items.Clear();
        ddown014.DataSource = dv13;
        ddown014.DataTextField = "Descripcion";
        ddown014.DataValueField = "CodRegion";
        dv13.Sort = "Descripcion";
        ddown014.DataBind();




        bool swLrpa = FiltroLRPA();
        if (swLrpa == true)
        {
            LRPAcoll LRPA = new LRPAcoll();
            DataView dv14 = new DataView(LRPA.GetparTipoTribunalLRPA());
            ddown015.DataSource = dv14;
            ddown015.Items.Clear();
            ddown015.DataTextField = "Descripcion";
            ddown015.DataValueField = "TipoTribunal";
            dv14.Sort = "Descripcion";
            ddown015.DataBind();
        }
        else
        {
            DataView dv14 = new DataView(par.GetparTipoTribunal());
            ddown015.Items.Clear();
            ddown015.DataSource = dv14;
            ddown015.DataTextField = "Descripcion";
            ddown015.DataValueField = "TipoTribunal";
            dv14.Sort = "Descripcion";
            ddown015.DataBind();
        }

        if (dtOT.Rows[0][0].ToString() == "9") // si no interviene tribunal ...
        {
            btnOrdenesTribunal.Visible = false;
            lblnointerviene.Visible = true;
            //alert.Attributes.Add("style", "");
            //lbl0055.Text = "Calidad Jurídica: NO INTERVIENE TRIBUNAL.";
            //lbl0055.Attributes.Add("style", "");
            //utab2.Tabs[5].Visible = true;
            link_tab6.Attributes.Add("style", "display: block");
            tbl_ingreso_orden_tribunal.Visible = false;
        }
        else
        {
            btnOrdenesTribunal.Enabled = true;
            btnOrdenesTribunal.Visible = true;
            lblnointerviene.Visible = false;
            //utab2.Tabs[5].Visible = true;
            link_tab6.Attributes.Add("style", "display: block");
            tbl_ingreso_orden_tribunal.Visible = true;
        }


        #endregion

        #region Causales de Ingreso


        ddown018.Items.Clear();
        bool swLrpaCausales = FiltroLRPA();
        if (swLrpaCausales)
        {
            LRPAcoll LRPA = new LRPAcoll();
            DataView dv15 = new DataView(LRPA.GetparTipoCausalIngresoLRPA());
            ddown018.DataSource = dv15;
            ddown018.DataTextField = "Descripcion";
            ddown018.DataValueField = "CodTipoCausalIngreso";
            dv15.Sort = "Descripcion";
            ddown018.DataBind();

        }
        else
        {

            DataView dv15 = new DataView(par.GetparTipoCausalIngreso(SSnino.CodProyecto));
            ddown018.Items.Clear();
            ddown018.DataSource = dv15;
            ddown018.DataTextField = "Descripcion";
            ddown018.DataValueField = "CodTipoCausalIngreso";
            dv15.Sort = "Descripcion";
            ddown018.DataBind();
        }




        leeyllenagrilla();



        #endregion

        #region Medida o Sancion
        ninos_MedidaOSancion.CargaTodo();
        ninos_MedidaOSancion.CargaSeleccion();
        ninos_MedidaOSancion.CargaOT();
        #endregion

        #endregion

    }



    #endregion


    private void verificaOTribunal(bool valida)
    {
        if (valida)
        {
            link_tab7.Attributes.Add("Class", "pestana-roja");
            alertOTObligatoria.Visible = true;
        }
        else
        {
            link_tab7.Attributes.Remove("Class");
            alertOTObligatoria.Visible = false;
        }

    }

    private void leeyllenagrilla()
    {
        ninocoll ncoll = new ninocoll();

        LRPAcoll LRPA = new LRPAcoll();
        bool swlrpa = FiltroLRPA();

        if (swlrpa == false)
        {
            //utab2.Tabs[8].Visible = false; +1
            link_tab9.Attributes.Add("style", "display: none");
            grd002_2f.Columns[4].Visible = false;
            //ddown_otc.Visible = false;
            tr_orden_tribunal.Visible = false;
        }
        else
        {
            //utab2.Tabs[8].Visible = true; 
            tr_orden_tribunal.Visible = true;
            link_tab9.Attributes.Add("style", "display: block");
            grd002_2f.Columns[4].Visible = true;
            DataTable dtOT = LRPA.GetICodTribunalIngreso_LRPA(SSnino.ICodIE);
            if (dtOT.Rows.Count > 0)
            {
                ddown_otc.Items.Clear();
                ddown_otc.DataSource = dtOT;
                ddown_otc.DataTextField = "Descripcion";
                ddown_otc.DataValueField = "ICodTribunalIngreso";
                ddown_otc.DataBind();
            }
            //  ddown_otc.Visible = true;

            LRPAcoll lrpa = new LRPAcoll();
            int cta = lrpa.Get_LRPAModeloIntervencion(SSnino.CodProyecto);
            if (cta > 0)
            {
                //utab2.Tabs[8].Visible = false;
                link_tab9.Attributes.Add("style", "display: none");
            }
            ddown020.SelectedValue = "T";
            ddown020.Enabled = false;
        }


        DataTable dtCausales = ncoll.callto_get_causalesingreso(SSnino.ICodIE);

        DataView dvCausales = new DataView(dtCausales);
        grd002_2f.DataSource = dtCausales;
        dvCausales.Sort = "TipoCausal";
        grd002_2f.DataBind();

        if (grd002_2f.Rows.Count > 0)
        {
            for (int i = 0; i < grd002_2f.Rows.Count; i++)
            {
                if (dtCausales.Rows[i][2].ToString() == "1" || dtCausales.Rows[i][2].ToString() == "E")
                {
                    grd002_2f.Rows[i].Cells[2].Text = "ESTABLECIMIENTO";
                }

                if (dtCausales.Rows[i][2].ToString() == "2" || dtCausales.Rows[i][2].ToString() == "P")
                {
                    grd002_2f.Rows[i].Cells[2].Text = "POLICIA";
                }
                if (dtCausales.Rows[i][2].ToString() == "3" || dtCausales.Rows[i][2].ToString() == "T")
                {
                    grd002_2f.Rows[i].Cells[2].Text = "TRIBUNAL";
                }
            }
        }
        int n = 2;
        if (swlrpa)
            n = 9;

        if (grd002_2f.Rows.Count > n)
        {
            if (n == 2)
                lbl_causales.Text = "El niño posee tres causales";
            else
                lbl_causales.Text = "El niño posee diez causales";

            ddown018.Enabled = false;
            ddown019.Enabled = false;
            ddown020.Enabled = false;
            btnback003.Enabled = false;
        }
        else if (grd002_2f.Rows.Count < 2)
        {
            lbl_causales.Text = "";
            btnback003.Enabled = true;
            ddown018.Enabled = true;
            ddown019.Enabled = true;
            ddown020.Enabled = true;

        }

        if (FiltroLRPA())
        {
            ddown020.SelectedValue = "T";
            ddown020.Enabled = false;
        }

    }

    protected void UltraWebMenu1_MenuItemClicked(object sender, EventArgs e)
    {

    }
    protected void ddownt3001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void chk001_DataBinding(object sender, EventArgs e) //LO USAMOS PARA GATILLAR DATOS DESPUES DE LA BUSQUEDA
    {
        //imb_lupaproyecto.Visible = false;
        //imb_lupa_institucion.Visible = false;
        imb_lupa_institucion.Attributes.Add("disabled", "true");
        imb_lupaproyecto.Attributes.Add("disabled", "true");
        btnbuscar.Visible = false;
        CargaTabs();
    }

    private void CargaTabs()
    {
        ninocoll ncoll = new ninocoll();
        nino n = ncoll.GetData(SSnino.CodNino.ToString(), SSnino.ICodIE.ToString());
        if (n == null) return;

        #region session ssninos-NNA

        oNNA NNA = (Session["NNA"] != null) ? (oNNA)Session["NNA"] : new oNNA();
        NNA.NNAApePaterno = n.Apellido_Paterno;
        NNA.NNAApeMaterno = n.Apellido_Materno;
        NNA.NNANombres = n.Nombres;
        NNA.NNARut = n.rut;
        NNA.NNACodProyecto = n.CodProyecto.ToString();
        NNA.NNACodInstitucion = n.CodInst.ToString();
        NNA.NNACodNino = n.CodNino;
        NNA.NNACodIE = n.ICodIE;
        NNA.NNAFechaNacimiento = n.FechaNacimiento.Date.ToShortDateString();
        NNA.NNAFechaIngreso = n.fchingdesde.ToShortDateString();
        Session["NNA"] = NNA;

        SSnino.Apellido_Paterno = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
        SSnino.Apellido_Materno = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
        SSnino.Nombres = HttpUtility.HtmlDecode(NNA.NNANombres);
        SSnino.rut = NNA.NNARut;
        SSnino.CodProyecto = Convert.ToInt32(NNA.NNACodProyecto);
        SSnino.CodNino = NNA.NNACodNino;
        Session["SS_ICodIE"] = SSnino.ICodIE = NNA.NNACodIE;
        niños_migracion.carga_situacion_migratoria();
        #endregion

        txt003.Text = n.Apellido_Paterno.ToUpper(); txt003.ReadOnly = true;
        txt004.Text = n.Apellido_Materno.ToUpper(); txt004.ReadOnly = true;
        txt005.Text = n.Nombres.ToUpper(); txt005.ReadOnly = true;
        lbl004.Text = n.FechaNacimiento.Date.ToShortDateString();
        if (lbl004.Text == "01-01-0001")
        {
            lbl004.Text = "";
        }

        ddown001.Attributes.Add("disabled", "disabled");
        ddl_Proyectos.Attributes.Add("disabled", "disabled");

        GetSelectedInfo();

        bool sw = FiltroLRPA();
        if (sw)
        {
            LRPAcoll lrpa = new LRPAcoll();

            int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(SSnino.CodProyecto);

            ddown_cj.Items.Clear();
            DataView dv3 = new DataView(lrpa.GetparCalidadJuridicaLRPA_II(CodModeloIntervencion));
            dv3.RowFilter = "CodCalidadJuridica <> 25"; // Se excluye S-DERIVACION SIN CONTACTO CON EL ADOLESCENTE
            ddown_cj.DataSource = dv3;
            ddown_cj.DataTextField = "Descripcion";
            ddown_cj.DataValueField = "CodCalidadJuridica";
            dv3.Sort = "Descripcion";
            ddown_cj.DataBind();

            //utab2.Tabs[5].Visible = true;
            link_tab6.Attributes.Add("style", "display: block");

            String CalidadJuridica = lrpa.GetCalidadJuridica_IcodIE(SSnino.ICodIE).ToString();
            //tddown004.SelectedValue = lrpa.GetCalidadJuridica_IcodIE(SSnino.ICodIE, ASP.global_asax.globaconn).ToString();
            if (CalidadJuridica != "25")        //S-DERIVACION SIN CONTACTO CON EL ADOLESCENTE
            {
                ddown_cj.AutoPostBack = false;
                ddown_cj.SelectedValue = CalidadJuridica;
            }
            else
            {
                lblLRPA_Virtual.Visible = true;
                ddown_cj.AutoPostBack = true;
            }

            if (CalidadJuridica == "9")       //<option value="9">B-NO INTERVIENE TRIBUNAL
            {
                link_tab7.Attributes.Add("style", "display: none");
            }
            else
            {
                link_tab7.Attributes.Add("style", "display: block");
            }



            lbl_nota1.Text = "Debe agregar de 1 a 10 causales de Ingreso.";

            ddown020.SelectedValue = "T";
            ddown020.Enabled = false;


            int cta = lrpa.Get_LRPAModeloIntervencion(SSnino.CodProyecto);
            if (cta > 0)
            {
                //utab2.Tabs[8].Visible = false;
                link_tab9.Attributes.Add("style", "display: none");
            }

            //Ocultar Tabs LRPA
            //li_nav3.Attributes.Add("style", "display:none");
            //link_tab3.Attributes.Add("style", "display:none");
            btn008.Attributes.Add("style", "display:none");

            li_nav5.Attributes.Add("style", "display:none");
            link_tab5.Attributes.Add("style", "display:none");
        }
        //karina
        else
        {
            LRPAcoll lrpa = new LRPAcoll();
            parcoll pcoll = new parcoll();
            ddown_cj.Items.Clear();
            DataView dv3 = new DataView(pcoll.GetparCalidadJuridica());
            ddown_cj.DataSource = dv3;
            ddown_cj.DataTextField = "Descripcion";
            ddown_cj.DataValueField = "CodCalidadJuridica";
            dv3.Sort = "Descripcion";
            ddown_cj.DataBind();
            //utab2.Tabs[5].Visible = true;
            link_tab6.Attributes.Add("style", "display: block");
            ddown_cj.SelectedValue = lrpa.GetCalidadJuridica_IcodIE(SSnino.ICodIE).ToString();

            //Volver a visualizar NO LRPA
            li_nav3.Attributes.Remove("style");
            link_tab3.Attributes.Remove("style");

            li_nav5.Attributes.Remove("style");
            link_tab5.Attributes.Remove("style");
        }
        muestra_pestaña(1);

    }
    private bool FiltroReescolarizacion()
    {
        LRPAcoll LRPA = new LRPAcoll();
        DataTable dt = LRPA.callto_get_proyectoreescolarizacion(SSnino.CodProyecto);

        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private bool FiltroLRPA()
    {
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        if (SSnino.CodProyecto > 0)
        {
            dt = LRPA.callto_get_proyectoslrpa(SSnino.CodProyecto);
            if (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
            {
                if (dt.Rows[0][2].ToString().Substring(0, 3) == "CRC")
                {
                    
                    //li_nav11.Visible = true;
                    pnl_utab11.Visible = true;
                    pnl_utab12.Visible = false;
                    pnl_utab14.Visible = true;
                    link_tab11_1.Visible = true;
                    link_tab11_2.Visible = false;
                    link_tab11_4.Visible = true;
                }
                if (dt.Rows[0][2].ToString().Substring(0, 3) == "CSC")
                {
                 
                    //li_nav11.Visible = true;
                    pnl_utab11.Visible = false;
                    pnl_utab12.Visible = true;
                    pnl_utab14.Visible = true;
                    link_tab11_1.Visible = false;
                    link_tab11_2.Visible = true;
                    link_tab11_4.Visible = true;
                }
                if (dt.Rows[0][2].ToString().Substring(0, 3) == "PLE")
                {
                    li_nav11.Visible = false;
                    pnl_utab11.Visible = false;
                    pnl_utab12.Visible = false;
                    pnl_utab14.Visible = true;
                    link_tab11_1.Visible = false;
                    link_tab11_2.Visible = false;
                    link_tab11_4.Visible = true;
                }
                if (dt.Rows[0][2].ToString().Substring(0, 3) == "PLA")
                {
                    li_nav11.Visible = false;
                    pnl_utab11.Visible = false;
                    pnl_utab12.Visible = false;
                    pnl_utab14.Visible = true;
                    link_tab11_1.Visible = false;
                    link_tab11_2.Visible = false;
                    link_tab11_4.Visible = true;
                }
                
                swLrpa = true;
            }
            else
            {
                swLrpa = false;
                li_nav11.Visible = false;
                pnl_utab11.Visible = false;
                pnl_utab12.Visible = false;
                pnl_utab14.Visible = false;
                //solo abierto para flexibilizacion TEMPORAL
                li_nav11.Visible = false;
                pnl_utab14.Visible = false;
                link_tab11_1.Visible = false;
                link_tab11_2.Visible = false;

            }
        }
        else
        {
            swLrpa = false;
        }

        return (swLrpa);


        #endregion

    }






    protected void ddown012_SelectedIndexChanged(object sender, EventArgs e)
    {




    }
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    //boton desactivado por estar dentro de un modal
    protected void lbtn005_Click(object sender, EventArgs e)
    {




    }


    protected void btnbind_Click1(object sender, EventArgs e)
    {
        GetSelectedInfo();
    }
    protected void grd002_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(1);
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt = new DataTable();


        int Estado_cierre = 0;

        if (ConfigurationSettings.AppSettings["cierre_mes"].ToString() == "1")//parametro WebConfig
        {
            string fecha = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
            if (((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text != "-")
            {
                string ano = Convert.ToDateTime(fecha).Year.ToString();
                string mes = Convert.ToDateTime(fecha).Month.ToString();

                if (mes.Length <= 1)
                {
                    mes = 0 + mes;
                }
                int Periodo = Convert.ToInt32(ano + mes);

                Estado_cierre = dcoll.callto_consulta_cierremes(SSnino.CodProyecto, Periodo);
            }

        }

        ecVal.Value = Convert.ToString(Estado_cierre);

        if (Estado_cierre != 1)
        {


            string ICodDiligencia;

            switch (e.CommandName)
            {
                //GMP fue cambioado por funcybox
                case "M":
                    ICodDiligencia = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    modal.Visible = true;
                    iframeModificarDiligencias.Src = "ninos_solicituddiligencias.aspx?ICodDiligencia=" + ICodDiligencia + "";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyFunction", "$('#myButtonModal').click();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MyFunction", "$('#imb_lupaX').click()" , true);
                    //    //ICodDiligencia = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    //    ICodDiligencia = grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    //    string cadena = string.Empty;

                    //    //cadena = "ninos_solicituddiligencias.aspx?ICodDiligencia=" + ICodDiligencia + "";
                    //    cadena = "LlamaUtab1(" + ICodDiligencia + ");";
                    //    //cadena = "MostrarModalUtab1();";
                    //    //cadena = @"window.open(Page, 'ninos_solicituddiligencias.aspx?ICodDiligencia=" + ICodDiligencia;
                    //    //cadena = "var objIframe = document.getElementById('iframe_Solicitud_Diligencia2');objIframe.src = 'ninos_solicituddiligencias.aspx?ICodDiligencia='" + ICodDiligencia + "';limpiaiframe(objIframe);document.getElementById('btn0012').click();return false;";

                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ninos_solicituddiligencias", cadena, true);
                    //    // ScriptManager.RegisterStartupScript(this, this.GetType(), "myFunction", "myFunction()", true);
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyFunction", cadena , true);
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyFunction", "$('#btn0012').click();", true);
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyFunction", "MostrarModalUtab1();", true);
                    break;


                case "E":

                    ICodDiligencia = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                    dilegenciascoll dicoll = new dilegenciascoll();
                    //  diagnosticoscoll dcoll = new diagnosticoscoll();
                    dcoll.callto_delete_solicituddiligencias_1(Convert.ToInt32(ICodDiligencia));

                    DataTable dt3 = dicoll.GetDiligencias(SSnino.ICodIE.ToString());
                    DataView dv3 = new DataView(dt3);
                    dv3.Sort = "FechaSolicitud";
                    grd002.DataSource = dv3;
                    grd002.DataBind();
                    //tlbl001.Text = "";
                    break;

            }
        }
        else
        {

            lbl001.Text = "El mes esta cerrado";
            alert.Style.Remove("display");
            lbl0055.Style.Remove("display");
            lbl0055.Text = "El mes se encuentra cerrado";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 1250);", true);

        }
    }

    protected void grd003_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(2);
        string ICodDiscapacidad;
        lblError.Visible = false;

        switch (e.CommandName)
        {
            case "M":
                ICodDiscapacidad = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                string cadena = string.Empty;

                string url = "ninos_discapacidad.aspx?ICodDiscapacidad=" + ICodDiscapacidad;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirVentana('" + url + "');", true);
                break;

            case "E":
                ninocoll ncoll = new ninocoll();
                int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(SSnino.CodProyecto);

                if (CodModeloIntervencion == 83 && cierre_mes(sender, e) == 1)    // PAD - PROGRAMA DE PROTECCIÓN AMBULATORIA PARA NIÑOS(AS) Y ADOLESC. CON DISCAPACIDAD GRAVE O PROFUNDA 
                {
                    lblError.Visible = true;
                    break;
                }

                ICodDiscapacidad = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                diagnosticoscoll dcoll = new diagnosticoscoll();
                dcoll.callto_delete_diagnosticosdiscapacidad_1(Convert.ToInt32(ICodDiscapacidad));

                DataTable dt3 = dcoll.GetDiagnosticosDiscapacidad(SSnino.ICodIE.ToString());
                DataView dv3 = new DataView(dt3);
                grd003.DataSource = dv3;
                grd003.DataBind();
                break;
        }
    }
    private int cierre_mes(object sender, GridViewCommandEventArgs e)
    {
        diagnosticoscoll dgcol = new diagnosticoscoll();
        DateTime FechaDiscapacidad = Convert.ToDateTime(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
        int AnoMes = FechaDiscapacidad.Year * 100 + FechaDiscapacidad.Month;
        int MesCerrado = dgcol.callto_consulta_cierremes(SSnino.CodProyecto, AnoMes);
        return MesCerrado;
    }

    protected void grd004_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(2);
        string ICodHechosdeSalud;
        switch (e.CommandName)
        {
            //GMP fue cambiado por funcybox
            //case "M":
            //    ICodHechosdeSalud = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            //    string cadena = string.Empty;
            //    cadena = @"window.open(this.Page, 'ninos_hechosdesalud.aspx?ICodHechosdeSalud=" + ICodHechosdeSalud + "', '550', '450')";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);

            //    break;

            case "E":
                ICodHechosdeSalud = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                diagnosticoscoll dcoll = new diagnosticoscoll();
                dcoll.callto_delete_hechossalud_1(Convert.ToInt32(ICodHechosdeSalud));

                DataTable dt4 = dcoll.GetHechosSalud(SSnino.ICodIE.ToString());
                DataView dv4 = new DataView(dt4);
                grd004.DataSource = dv4;
                grd004.DataBind();


                break;
        }
    }
    protected void grd005_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(2);
        string ICodEnfermedadCronica;
        switch (e.CommandName)
        {
            //GMP fue cambiado por funcybox
            //case "M":
            //    ICodEnfermedadCronica = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            //    string cadena = string.Empty;

            //    cadena = @"window.open(this.Page, 'ninos_enfermedadescronicas.aspx?ICodEnfermedadCronica=" + ICodEnfermedadCronica + "', '550', '450')";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ninos_enfermedadescronicas", cadena, true);

            //    break;
            case "E":
                ICodEnfermedadCronica = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                diagnosticoscoll dcoll = new diagnosticoscoll();
                dcoll.callto_delete_ninosenfermedadescronicas_1(Convert.ToInt32(ICodEnfermedadCronica));

                DataTable dt5 = dcoll.GetNinosEnfermedadesCronicas(SSnino.ICodIE.ToString());
                DataView dv5 = new DataView(dt5);
                grd005.DataSource = dv5;
                grd005.DataBind();


                break;
        }


    }

    private bool validate_EtapasDiagnostico()
    {
        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddl_Proyectos.SelectedValue == "0")
        {
            ddl_Proyectos.BackColor = colorCampoObligatorio;
            n = false;

        }
        else
        {
            ddl_Proyectos.BackColor = System.Drawing.Color.White;
        }
        return n;

    }

    private bool validateID()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        bool n = true;
        if (ddown003.SelectedValue == "0")
        {
            ddown003.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.White;
        }
        if (cal001.Text.Trim().ToUpper() == "")
        {
            cal001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001.BackColor = System.Drawing.Color.White;
        }

        return n;

    }
    private int utab2_ninogetvalue(string ddown)
    {
        try
        {
            return Convert.ToInt32(((DropDownList)utab2_nino.FindControl(ddown)).SelectedValue);
        }
        catch
        {
            return 0;
        }
    }
    protected void lbtn001_DataBinding(object sender, EventArgs e)
    {

    }
    //////////////////// FELIPE ORMAZABAL ///////////////////// 
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private bool validate1()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        bool v = true;

        if (ddown001.SelectedValue == "0")
        {

            ddown001.BackColor = colorCampoObligatorio;

            v = false;

        }

        if (ddl_Proyectos.SelectedValue == "0")
        {

            ddl_Proyectos.BackColor = colorCampoObligatorio;

            v = false;

        }


        return v;

    }

    protected void rdo002_CheckedChanged(object sender, EventArgs e)
    {
        //RadioButton urdo003 = (RadioButton)utab.FindControl("rdo003");
        //urdo003.Enabled = false;
    }

    protected void grd006_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(4);

        //GMP cambiado por funcybox
        //string CodPersonaRelacionada = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        //string cadena = string.Empty;

        //cadena = @"window.open(Page, 'ninos_nuevapersonarel.aspx?CodPersonaRelacionada=" + CodPersonaRelacionada + "&sw=true', '', '600', '600', true)";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ninos_nuevapersonarel", cadena, true);
    }

    protected void ddown016_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList tddown016 = (DropDownList)utab.FindControl("ddown016");
        //tddown016.Focus();
    }
    protected void ddown019_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList tddown020 = (DropDownList)utab.FindControl("ddown020");
        //tddown020.Focus();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //GMP cambiado por funcybox
        //string etiqueta = "Busca Proyectos";
        //string cadena = string.Empty;
        //cadena = @"window.open('../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/pi_gestion.aspx', 'Buscador' , 'width=770,height=420,scrollbars=NO')";

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    }
    protected void chk002F2_DataBinding(object sender, EventArgs e)
    {
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;
    }

    protected void rdo001_DataBinding(object sender, EventArgs e)
    {
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;
        //pnl001.Visible = false;
    }
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

    protected void grd007_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(3);
        //GMP los botones M y E NO estan visibles y no encontré que cambiaran por código
        // este código se puede eliminar
        switch (e.CommandName)
        {
            case "M":
                string IcodEtapa = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                string cadena = string.Empty;

                cadena = @"window.open(Page, 'EtapasRealizadasDiagnosticos.aspx?IcodEtapa=" + IcodEtapa + "&sw=true', '', '560', '400')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);

                break;
            case "E":

                int icodetapa = Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

                dilegenciascoll dicoll = new dilegenciascoll();
                diagnosticoscoll dcoll = new diagnosticoscoll();
                dcoll.callto_delete_etapasinformediagnostico_1(icodetapa);


                DataTable dt8 = dcoll.GetEtapasInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));

                DataView dv8 = new DataView(dt8);

                grd007.DataSource = dv8;
                dv8.Sort = "FechaEtapa";
                grd007.DataBind();
                break;

        }
    }


    //    protected void grd008_RowEditing(object sender, GridViewEditEventArgs e)
    //    {
    //            int icodaccion = Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.NewEditIndex)].Cells[0].Text);
    //            SSnino.ICodinformediagnostico = VICodInfDiagnostico;
    //            string cadena = string.Empty;

    //            cadena = "accionesinformediagnostico.aspx?icodaccion=" + icodaccion + "&sw=true";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "darCarga('" + cadena + "');", true);
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "darClick();", true);

    //            e.Cancel = true;

    ////         <asp:HyperLinkField NavigateUrl="laurl" Text="Modifiocar" />

    ////<a id="A4" runat="server" class="ifancybox" href="<%# string.Concat("accionesinformediagnostico.aspx?icodaccion=", Eval("icodaccion"),"&sw=true")%>" visible="true"><asp:ButtonField Text="Modificar" /></a>

    ////        <asp:TemplateField HeaderText="" ><ItemTemplate><a id="aaa4"  runat="server" class="ifancybox"  href='<%# string.Concat("accionesinformediagnostico.aspx?icodaccion=", Eval("icodaccion"),"&sw=true")%>' >Modificar</a></ItemTemplate></asp:TemplateField>

    //    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        muestra_pestaña(4);
        ninocoll ncoll = new ninocoll();
        DataTable dt6 = ncoll.GetIngresoPersonaRelacionada(SSnino.ICodIE.ToString());
        DataView dv6 = new DataView(dt6);
        grd006.DataSource = dv6;
        grd006.DataBind();
    }
    protected void grd0012f_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Session["termino"] = "X";
        muestra_pestaña(3);
        divDetalleDiag.Attributes.Add("class", "active");
        divDetalleDiag.Visible = true;

        ddl_EtapasRealizadas.Visible = true;
        ddown006.Visible = true;

        VICodInfDiagnostico = Convert.ToInt32(grd0012f.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.Trim());

        SSnino.ICodinformediagnostico = VICodInfDiagnostico;

        if (grd0012f.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text.Trim() == "01-01-1900" || grd0012f.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text == "-")
        {
            // btn006.Enabled = true;
            btn006.Attributes.Remove("disabled");
            btn007.Enabled = true;
            ddown006.Enabled = true;
            cal003.Enabled = true;
            btn0010.Enabled = true;
            //btn008.Enabled = false;
            btn008.Attributes.Add("disabled", "disabled");
            lnk001.Visible = false;
            VEstado_InfDiag = 1;
            lbl004_2f.Text = "";

        }
        else
        {
            //btn006.Enabled = false;
            btn006.Attributes.Add("disabled", "disabled");
            btn007.Enabled = false;
            ddown006.Enabled = false;
            cal003.Enabled = false;
            btn0010.Enabled = false;
            btn008.Enabled = false;
            btn008.Attributes.Add("disabled", "disabled");  //DEHABILITO POR QUE ESTOY TRABAJANDO
            lnk001.Visible = true;

        }
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt10 = dcoll.GetAccionesInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));
        DataView dv10 = new DataView(dt10);
        grd008.DataSource = dv10;
        //dv10.Sort = "FechaAccion";
        grd008.DataBind();


        DataTable dt8 = dcoll.GetEtapasInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));
        DataView dv8 = new DataView(dt8);
        grd007.DataSource = dv8;
        dv8.Sort = "FechaEtapa";
        grd007.DataBind();
        ninocoll ncoll = new ninocoll();

        DataTable dt2_2f = dcoll.GetTerminoInforme(VICodInfDiagnostico);

        cal001.Text = Convert.ToDateTime(dt2_2f.Rows[0][1].ToString()).ToString("dd-MM-yyyy");
        ddown003.SelectedValue = dt2_2f.Rows[0][0].ToString();

        grd007.Visible = true;
        grd008.Visible = true;

        btn007.Visible = true;
        btn007.Visible = true;
        btn0010.Visible = true;

        DataTable dtTermino = ncoll.GetTermino(Convert.ToString(SSnino.ICodinformediagnostico));

        if (dtTermino.Rows.Count != 0)
        {
            try
            {
                ddown006.SelectedValue = dtTermino.Rows[1][0].ToString();
            }
            catch { }
            try
            {
                if (Convert.ToDateTime(dtTermino.Rows[1][1]).ToShortDateString() == "01-01-1900")
                {
                    cal003.Text = "";
                }
                else
                {
                    cal003.Text = dtTermino.Rows[1][1].ToString();
                }
            }
            catch { }
        }

        //tcal003.MaxDate = DateTime.Now;
        //tcal003.MinDate = Convert.ToDateTime(tcal001.Text);
        CalendarExtender1.EndDate = DateTime.Now;
        CalendarExtender1.StartDate = Convert.ToDateTime(cal001.Text);
        cal003.Text = DateTime.Now.ToShortDateString();
        //ddown003.Focus();

        validatescurity();

    }
    protected void ddown001g_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void limpiatodo()
    {
        //solicitud de diligencias
        grd002.DataSource = null;
        grd002.DataBind();
        //discapcidad
        grd003.DataSource = null;

        grd003.DataBind();
        //hechos de asli
        grd004.DataSource = null;
        grd004.DataBind();
        //enf cronica
        grd005.DataSource = null;
        grd005.DataBind();

        cal001.Text = "";
        ddown003.SelectedValue = "0"; // =  Value="0">Seleccione<
        grd0012f.DataSource = null;
        grd0012f.DataBind();

        ddl_EtapasRealizadas.SelectedIndex = -1;
        grd007.DataSource = null;
        grd007.DataBind();

        grd008.DataSource = null;
        grd008.DataBind();

        ddown006.SelectedIndex = -1;
        cal003.Text = "";

        grd006.DataSource = null;
        grd006.DataBind();

        txt001_E.Text = "";
        ddown001_E.SelectedIndex = -1;



        calFechaCambio.Text = "";
        ddown_cj.SelectedIndex = 0;

        ddown014.SelectedIndex = 0;
        ddown015.SelectedIndex = -1;
        TextBox4.Text = "";
        txt006F2.Text = "";
        txt007F2.Text = "";
        ddown017.Text = "";


        grd001U2.DataSource = null;
        grd001U2.DataBind();

        ddown_otc.SelectedIndex = 0;

        ddown018.SelectedIndex = 0;
        ddown019.SelectedIndex = 0;
        txt006.Text = "";
        ddown020.SelectedIndex = 0;
        lbl_resumen_filtro.Text = "";

        grd002_2f.DataSource = null;
        grd002_2f.DataBind();

        //falta implementar ninos_MedidaOSancion.limpia();
    }
    private void limpiagestion()
    {
        ddown003.SelectedValue = Convert.ToString(0);
        ddown006.SelectedValue = Convert.ToString(0);
        //ddl_Proyectos.SelectedValue = Convert.ToString(0);
        cal001.Text = "";
        cal003.Text = "";
    }
    private bool ValidateTermino()
    {
        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown006.SelectedValue == "0")
        {
            ddown006.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown006.BackColor = System.Drawing.Color.White;
        }
        if (cal003.Text.Trim().ToUpper() == "SELECCIONE")
        {
            cal003.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal003.BackColor = System.Drawing.Color.White;
        }

        return n;

    }

    protected void lnk001_Click(object sender, EventArgs e)
    {
        muestra_pestaña(3);

        ddown006.SelectedValue = "0";
        DataTable dtClear = new DataTable();
        DataView dVClear = new DataView(dtClear);
        grd007.DataSource = dVClear;
        grd008.DataSource = dVClear;

        cal003.Text = "";
        lnk001.Visible = false;

        if (VEstado_InfDiag != 1)
        {
            //btn008.Enabled = false;
            btn008.Attributes.Add("disabled", "disabled");
            lbl004_2f.Text = "Existe un Informe abierto";
        }
        else
        {
            //btn008.Enabled = true;
            btn008.Attributes.Remove("disabled");
            lbl004_2f.Text = "";
        }



    }
    #region Guarda y valida personaContacto Modifica


    private bool validatePerCont()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        bool n = true;


        if (txt001_E.Text.Trim() == "")
        {
            txt001_E.BackColor = colorCampoObligatorio;
            n = false;

        }
        else
        {
            txt001_E.BackColor = System.Drawing.Color.White;
        }
        if (ddown001_E.SelectedValue == "0")
        {
            ddown001_E.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001_E.BackColor = System.Drawing.Color.White;
        }

        return n;
    }
    #endregion

    #region Guarda y valida Ordenes tribunal Modifica

    private void limpiarOrdenes()
    {

        ddown014.SelectedValue = "-2"; //region
        ddown015.SelectedValue = Convert.ToString(0); //tipo tribunal
        ddown016.SelectedValue = Convert.ToString(0); //tribunal
        TextBox4.Text = ""; //expediente

        ddown017.Text = ""; //Fehc 

        txt006F2.Text = ""; //RUC
        txt007F2.Text = ""; //RIT


    }


    private bool validateOT()
    {



        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        bool n = true;

        if (ddown014.SelectedValue == "0")
        {
            ddown014.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown014.BackColor = System.Drawing.Color.White;
        }

        if (ddown015.SelectedValue == "0")
        {
            ddown015.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown015.BackColor = System.Drawing.Color.White;
        }

        if (ddown016.SelectedValue == "0")
        {
            ddown016.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown016.BackColor = System.Drawing.Color.White;
        }
        if (ddown017.Text.Trim().ToUpper() == "")
        {
            ddown017.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown017.BackColor = System.Drawing.Color.White;
        }

        if (ddown_cj.SelectedValue == "28")        //28: A2-MEDIDA DE PROTECCION - 80 BIS
        {
            if (TextBox4.Text.Trim() == "")
            {
                TextBox4.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                TextBox4.BackColor = System.Drawing.Color.White;
            }
        }

        //if (txt006F2.Text.Trim() == "")
        //{
        //    txt006F2.BackColor = colorCampoObligatorio;
        //    n = false;
        //}
        //else
        //{
        //    txt006F2.BackColor = System.Drawing.Color.White;

        //}

        return n;


    }
    #endregion

    protected void ddown018M_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(8);
        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();

        DataView dv16 = new DataView(par.GetparCausalesIngreso(ddown018.SelectedValue, SSnino.CodProyecto));

        ddown019.Items.Clear();
        ddown019.DataSource = dv16;
        ddown019.DataTextField = "Descripcion";
        ddown019.DataValueField = "CodCausalIngreso";
        dv16.Sort = "Descripcion";
        ddown019.DataBind();

    }

    #region Guarda y valida Causales de Ingreso Modifica


    private void Limpiacausales()
    {

        ddown018.SelectedValue = Convert.ToString(0);
        ddown019.SelectedValue = Convert.ToString(0);
        ddown020.SelectedValue = Convert.ToString(0);
        txt006.Text = string.Empty;

    }

    private bool validateCI()
    {


        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        bool sw = FiltroLRPA();


        bool n = true;

        if (sw)
        {
            if (ddown_otc.SelectedValue == "0")
            {
                ddown_otc.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                ddown_otc.BackColor = System.Drawing.Color.White;
            }
        }

        if (ddown018.SelectedValue == "0")
        {
            ddown018.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown018.BackColor = System.Drawing.Color.White;
        }

        if (ddown019.SelectedValue == "0")
        {
            ddown019.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown019.BackColor = System.Drawing.Color.White;
        }
        if (ddown020.SelectedValue == "0")
        {
            ddown020.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown020.BackColor = System.Drawing.Color.White;
        }

        return n;
    }
    # endregion
    protected void ddown015M_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(7);
        parcoll par = new parcoll();


        DataView dv15 = new DataView(par.GetparTribunales(ddown014.SelectedValue, ddown015.SelectedValue));
        ddown016.Items.Clear();
        ddown016.DataSource = dv15;
        ddown016.DataTextField = "Descripcion";
        ddown016.DataValueField = "CodTribunal";
        dv15.Sort = "Descripcion";
        ddown016.DataBind();
    }
    protected void grd002_2f_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    private void Limpiarcabecera()
    {
        //txt001.Text = "";
        //txt002.Text = "";
        txt003.Text = "";
        txt004.Text = "";
        txt005.Text = "";
        lbl004.Text = "";
        //lbl005.Text = "";
        //ddown001.SelectedValue = Convert.ToString(0);
        //ddown002.SelectedValue = Convert.ToString(0);
        rdo001.Checked = false;
    }
    protected void BuscarNinos()
    {
        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
        SSnino.Apellido_Paterno = Convert.ToString(txt003.Text.Trim());
        SSnino.Apellido_Materno = Convert.ToString(txt004.Text.Trim());
        SSnino.Nombres = Convert.ToString(txt005.Text.Trim());
        SSnino.tipobusqueda = 2;
        //SSnino.CodNino = Convert.ToInt32(txt002.Text.Trim());
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;


        bool swLrpa = FiltroLRPA();

        if (swLrpa == true)
        {
            //utab2.Tabs[4].Visible = false;
            link_tab5.Attributes.Add("style", "display: none");
        }
        else
        {
            //utab2.Tabs[4].Visible = true;
            link_tab5.Attributes.Add("style", "display: block");
        }
    }


    protected void ddown019_SelectedIndexChanged1(object sender, EventArgs e)
    {
        muestra_pestaña(8);


        parcoll pcoll = new parcoll();

        int codcausal = pcoll.GetparCausalesIngresoCodNumCausal(Convert.ToInt32(ddown019.SelectedValue));

        txt006.Text = codcausal.ToString();
    }

    protected void Ninos_busqueda1_Load(object sender, EventArgs e)
    {

    }


    protected void lnk001_Click1(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        grd007.DataSource = dt;
        grd008.DataSource = dt;

        Limpiarcabecera();

        utab2_nino.Visible = false;

        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        rdo001.DataBind();
        clean_tab();

        grd007.Visible = false;
        grd008.Visible = false;

        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
        SSnino.Apellido_Paterno = Convert.ToString(txt003.Text.Trim());
        SSnino.Apellido_Materno = Convert.ToString(txt004.Text.Trim());
        SSnino.Nombres = Convert.ToString(txt005.Text.Trim());
        SSnino.tipobusqueda = 2;
        //SSnino.CodNino = Convert.ToInt32(txt002.Text.Trim());
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;


        bool swLrpa = FiltroLRPA();

        if (swLrpa == true)
        {
            //utab2.Tabs[4].Visible = false;
            link_tab5.Attributes.Add("style", "display: none");
        }
        else
        {
            //utab2.Tabs[4].Visible = true;
            link_tab5.Attributes.Add("style", "display: block");
        }

        pnl001.Visible = false;
        //utab2.Visible = false;
        utab2_nino.Visible = false;

    }

    protected void ddown_cj_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    protected void grd004_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown014_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown_cj_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void ddown_cj_SelectedIndexChanged2(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        ViewState["cj"] = ddown_cj.SelectedValue;
        lblLRPA_Virtual.Visible = false;
    }

    protected void lnkbtn_pdfVulneracion_Click(object sender, EventArgs e)
    {
        string cadena = string.Empty;
        cadena = @"window.open(this.Page, '../mod_reportes/Reg_Reportes.aspx?param001=8', 'Reportes', false, true, '800', '600', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Reportes", cadena, true);
    }


    protected void cal003_ValueChanged1(object sender, EventArgs e)
    {
        muestra_pestaña(3);

        try
        {

            if (Convert.ToDateTime(cal003.Text) < Convert.ToDateTime(cal001.Text))
            {
                lbl0012f.Text = "La Fecha de término debe ser mayor o igual a la fecha de creación";
                cal003.Text = "";
            }
            else
            {
                lbl0012f.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btn001_Click(object sender, EventArgs e)
    {
        //string cadena = string.Empty;

        //cadena = @"window.open(page, '../mod_instituciones/bsc_institucion.aspx', '560', '400')";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ninos_solicituddiligencias", cadena, true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "mostrarNuevaDiligencia();", true);
        //Response.Redirect("ninos_solicituddiligencias.aspx");
    }

    protected void btn003_Click(object sender, EventArgs e)
    {
        Limpiarcabecera();
        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;
        utab2_nino.Visible = false;
        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        rdo001.DataBind();

        lbl001.Text = "";
    }

    protected void btn008_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        muestra_pestaña(3);
        diagnosticoscoll dcoll = new diagnosticoscoll();
        ninocoll ncoll = new ninocoll();
        bool sw = true;

        if ((cal001.Text.ToUpper() != "SELECCIONE") && (cal001.Text.Trim() != ""))
        {
            SSnino.InicioInformeDiagnostico = Convert.ToDateTime(cal001.Text);
        }
        else
        {
            cal001.BackColor = colorCampoObligatorio;
            sw = false;
        }

        string fechatermino;
        if (cal003.Text.Trim().ToUpper() == "")
        {
            fechatermino = "01-01-1900";

        }
        else
        {
            fechatermino = cal003.Text;
        }


        if (validateID() == true && sw == true)
        {
            SSnino.ICodinformediagnostico = dcoll.Insert_InformesDiagnosticos(SSnino.ICodIE, Convert.ToDateTime(cal001.Text), Convert.ToInt32(ddown006.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), Convert.ToDateTime(fechatermino) /*(DateTime)((TextBox)utab2.FindControl("cal003")).Value*/, DateTime.Now, Convert.ToInt32(UserId), SSnino.CodProyecto, SSnino.CodNino, Convert.ToDateTime(cal001.Text));
        }

        DataTable dt77 = ncoll.callto_get_informediagnostico(Convert.ToInt32(SSnino.ICodIE.ToString()));
        DataView dv77 = new DataView(dt77);
        grd0012f.DataSource = dv77;
        dv77.Sort = "ICodInformeDiagnostico";
        grd0012f.DataBind();

        for (int i = 0; i < grd0012f.Rows.Count; i++)
        {
            try
            {

                if (grd0012f.Rows[i].Cells[4].Text == "01-01-1900")
                {
                    grd0012f.Rows[i].Cells[4].Text = "-";

                }
            }
            catch { }
        }
        cal001.Enabled = true;
        ddown003.Enabled = true;
        btn008.Attributes.Remove("disabled");

        for (int i = 0; i < grd0012f.Rows.Count; i++)
        {


            if (Convert.ToDateTime(dt77.Rows[i][2].ToString()).ToShortDateString() == "01-01-1900")
            {

                cal001.Enabled = false;
                ddown003.Enabled = false;
                //btn008.Enabled = false;
                btn008.Attributes.Add("disabled", "disabled");
                break;

            }
        }
    }
    protected void btn006_Click(object sender, EventArgs e)
    {
        muestra_pestaña(3);

        SSnino.ICodinformediagnostico = VICodInfDiagnostico;


        if (validate_EtapasDiagnostico() == true)
        {

            if (SSnino.ICodinformediagnostico > 0)
            {
                diagnosticoscoll dcoll = new diagnosticoscoll();
                dcoll.Insert_EtapasInformeDiagnostico(SSnino.ICodinformediagnostico, DateTime.Now, utab2_ninogetvalue("ddl_EtapasRealizadas")); //marca         
                ActualizaEtapIntervencion();
                ddl_EtapasRealizadas.SelectedValue = "0";
                ddl_EtapasRealizadas.Visible = true;

            }

            else
            {
                alert.Attributes.Add("style", "");
                lbl0055.Text = "Primero debe guardar el diagnostico.";
                lbl0055.Attributes.Add("style", "");
                //window.alert(Page, "");
            }
        }
        //ddown002.Focus();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        ninocoll ncoll = new ninocoll();


        if (ValidateTermino() == true)
        {
            dcoll.Update_InformesDiagnosticos(VICodInfDiagnostico, SSnino.ICodIE, Convert.ToDateTime(cal001.Text), utab2_ninogetvalue("ddown006"), Convert.ToInt32(ddown003.SelectedValue), Convert.ToDateTime(cal003.Text), DateTime.Now, Convert.ToInt32(UserId));

            //btn008.Enabled = true;
            btn008.Attributes.Remove("disabled");

            cal001.Enabled = true;
            cal001.Text = "";
            ddown003.Enabled = true;
            ddown003.SelectedValue = "0";
            ddown006.SelectedValue = "0";
            DataTable dt = new DataTable();
            grd007.DataSource = dt;
            grd007.DataSource = dt;
            cal003.Text = "";
            grd007.Visible = false;
            grd007.Visible = false;
            //tcal001.MinDate = SSnino.fchingdesde;
            //tcal001.MaxDate = DateTime.Now;

            CalendarExtender2_cal001.EndDate = DateTime.Now;
            CalendarExtender2_cal001.StartDate = SSnino.fchingdesde;

            limpiagestion();
        }

        DataTable dt77 = ncoll.callto_get_informediagnostico(Convert.ToInt32(SSnino.ICodIE.ToString()));
        DataView dv77 = new DataView(dt77);
        grd0012f.DataSource = dv77;
        dv77.Sort = "ICodInformeDiagnostico";
        grd0012f.DataBind();
        for (int i = 0; i < grd0012f.Rows.Count; i++)
        {
            try
            {

                if (grd0012f.Rows[i].Cells[4].Text == "01-01-1900")
                {
                    grd0012f.Rows[i].Cells[4].Text = "-";

                }
            }
            catch { }

        }
    }
    protected void btn0062f_Click(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        ddown006.SelectedValue = "0";

        cal003.Text = "";
        limpiagestion();
    }
    protected void btn005aa_Click1(object sender, EventArgs e)
    {
        muestra_pestaña(5);

        if (validatePerCont() == true)
        {
            ninocoll ncoll = new ninocoll();
            ncoll.callto_update_ingresos_egresos(SSnino.ICodIE, txt001_E.Text.Trim().ToUpper(), Convert.ToInt32(ddown001_E.SelectedValue));
            alert2.Attributes.Add("style", "");
            lbl00552.Text = "La persona de contacto fue cambiada.";
            lbl00552.Attributes.Add("style", "");
            //lbl_percontacto.Text = "La persona de contacto fue cambiada";
        }
        else
        {
            //lbl_percontacto.Text = "";

        }
    }
    protected void btn008aa_Click(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        DateTime FechaCambio = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        LRPAcoll LRPA = new LRPAcoll();
        int CodCalidadJuridica = LRPA.GetCalidadJuridica_IcodIE(SSnino.ICodIE), CodCalidadJuridicaNuevo = Convert.ToInt32(ddown_cj.SelectedValue);
        if (ddown_cj.SelectedValue != "0")
        {
            parcoll par = new parcoll();
            LRPA.callto_update_calidadjuridica_ingresosegresos(SSnino.ICodIE, Convert.ToInt32(ddown_cj.SelectedValue));
            ddown_cj.BackColor = System.Drawing.Color.White;


            //karina

            DataView dv13 = new DataView(par.GetparRegion());
            ddown014.Items.Clear();
            ddown014.DataSource = dv13;
            ddown014.DataTextField = "Descripcion";
            ddown014.DataValueField = "CodRegion";
            dv13.Sort = "Descripcion";
            ddown014.DataBind();

            alert2.Attributes.Add("style", "");
            lbl00552.Text = "Actualizacion realizada con exito.";
            lbl00552.Attributes.Add("style", "");


            bool swLrpa = FiltroLRPA();
            if (swLrpa)
            {
                // LRPAcoll LRPA = new LRPAcoll();
                DataView dv14 = new DataView(LRPA.GetparTipoTribunalLRPA());
                ddown015.DataSource = dv14;
                ddown015.Items.Clear();
                ddown015.DataTextField = "Descripcion";
                ddown015.DataValueField = "TipoTribunal";
                dv14.Sort = "Descripcion";
                ddown015.DataBind();
                //Fabian Urrutia
                if (CodCalidadJuridica == 25 && CodCalidadJuridicaNuevo == 5)
                {
                    if (calFechaCambio.Text != "")
                    {
                        FechaCambio = Convert.ToDateTime(Convert.ToDateTime(calFechaCambio.Text).ToShortDateString());
                    }
                    LRPA.callto_update_calidadjuridica_ingresos_CalidadJuridica(SSnino.ICodIE, CodCalidadJuridica, FechaCambio, Convert.ToDateTime(DateTime.Now.ToShortDateString()), UserId);
                    alert2.Attributes.Add("style", "");
                    lbl00552.Text = "Actualizacion realizada con exito.";
                    lbl00552.Attributes.Add("style", "");
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizacion", "alert('Actualizacion realizada con exito.');", true);
                }
                //GMP y si no?
            }
            else
            {
                DataView dv14 = new DataView(par.GetparTipoTribunal());
                ddown015.DataSource = dv14;
                ddown015.Items.Clear();
                ddown015.DataTextField = "Descripcion";
                ddown015.DataValueField = "TipoTribunal";
                dv14.Sort = "Descripcion";
                ddown015.DataBind();
                //Mr F
                if (CodCalidadJuridica == 28 || CodCalidadJuridicaNuevo == 28)
                {
                    if (calFechaCambio.Text != "")
                    {
                        FechaCambio = Convert.ToDateTime(Convert.ToDateTime(calFechaCambio.Text).ToShortDateString());
                    }
                    LRPA.callto_update_calidadjuridica_ingresos_CalidadJuridica(SSnino.ICodIE, CodCalidadJuridica, FechaCambio, Convert.ToDateTime(DateTime.Now.ToShortDateString()), UserId);
                    alert2.Attributes.Add("style", "");
                    lbl00552.Text = "Actualizacion realizada con exito.";
                    lbl00552.Attributes.Add("style", "");
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizacion", "alert('Actualizacion realizada con exito.');", true);
                }
                //y si no?
            }

        }
        else
        {
            ddown_cj.BackColor = colorCampoObligatorio;
            alert.Attributes.Add("style", "");
            lbl0055.Text = "No se actualizo.";
            lbl0055.Attributes.Add("style", "");
        }
        if (CodCalidadJuridicaNuevo == 9)
        {
            alert.Attributes.Add("style", "");
            lbl0055.Text = "Calidad Jurídica: NO INTERVIENE TRIBUNAL.";
            lbl0055.Attributes.Add("style", "");
            btnOrdenesTribunal.Visible = true;
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('test')", true);

    }
    protected void btn005aa_Click2(object sender, EventArgs e)
    {
        muestra_pestaña(7);
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        bool swLrpa = FiltroLRPA();
        bool filtroRepetido = false;
        if (swLrpa)
        {
            for (int i = 0; i < grd001U2.Rows.Count; i++)
            {
                if (grd001U2.Rows[i].Cells[3].Text.Trim() == txt006F2.Text.Trim())
                {
                    filtroRepetido = true;
                }
            }
        }
        if (validateOT())
        {


            string expediente;
            string RUC = "0";
            string RIT;
            bool chk_RucLRPA = false;

            expediente = (TextBox4.Text.Trim() == "") ? "0" : TextBox4.Text.Trim();

            RIT = (txt007F2.Text.Trim() == "") ? "0" : txt007F2.Text.Trim();

            if (swLrpa)
            {
                if (txt006F2.Text.Trim() == "")
                {
                    chk_RucLRPA = true;
                }
                else
                {
                    RUC = txt006F2.Text.Trim();
                }
            }
            else
            {
                RUC = (txt006F2.Text.Trim() == "") ? "0" : txt006F2.Text.Trim();
            }

            DateTime dtmFecha;
            if (ddown017.Text != null)
            {
                if (ddown017.Text.ToString() != "")
                { dtmFecha = Convert.ToDateTime(ddown017.Text.ToString()); }
                else
                { dtmFecha = Convert.ToDateTime(DateTime.Now.ToShortDateString()); }
            }
            else
            {
                dtmFecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            }

            if (!chk_RucLRPA && !filtroRepetido)
            {
                txt006F2.BackColor = System.Drawing.Color.White;

                ninocoll ncoll = new ninocoll();
                int codTribunal = ncoll.Insert_OrdenTribunalIngreso(SSnino.ICodIE, Convert.ToInt32(ddown016.SelectedValue), dtmFecha, Convert.ToInt32(UserId), expediente, RUC, RIT);

                DataTable dtGetTribunal = ncoll.callto_get_tribunalingreso(SSnino.ICodIE);
                DataView dvTribunal = new DataView(dtGetTribunal);
                grd001U2.DataSource = dvTribunal;
                dvTribunal.Sort = "Tribunal";
                grd001U2.DataBind();

                if (dtGetTribunal.Rows.Count == 0)
                {
                    verificaOTribunal(true);
                }
                else
                {
                    verificaOTribunal(false);
                }

                if (swLrpa)
                {
                    ListItem oItem = new ListItem("(" + txt006F2.Text.Trim() + ")" + "-" + ddown016.SelectedItem.Text.Trim(), codTribunal.ToString());
                    OtItem = oItem;
                    ddown_otc.Items.Add(oItem);

                    tr_orden_tribunal.Visible = true;
                    ddown_otc.DataBind();

                    // Response.Write("<script language='javascript'> var objeto = window.frames[7].document.getElementById('lnb001');" +
                    //              " objeto.click(); </script>");
                }

                limpiarOrdenes();

                //LRPAcoll LRPA = new LRPAcoll();
                //DataTable dtOT = LRPA.GetICodTribunalIngreso_LRPA(SSnino.ICodIE);
                //if (dtOT.Rows.Count > 0)
                //{
                //    ddown_otc.Items.Clear();
                //    ddown_otc.DataSource = dtOT;
                //    ddown_otc.DataTextField = "Descripcion";
                //    ddown_otc.DataValueField = "ICodTribunalIngreso";
                //    ddown_otc.DataBind();
                //}   
            }
            else
            {
                txt006F2.BackColor = colorCampoObligatorio;

            }
        }
    }
    protected void btnback003_Click(object sender, EventArgs e)
    {
        muestra_pestaña(8);


        bool sw = FiltroLRPA();


        if (validateCI() == true)
        {
            ninocoll ncoll = new ninocoll();

            int codTribunal = 0;
            if (sw)
            {
                codTribunal = Convert.ToInt32(ddown_otc.SelectedValue);
            }

            leeyllenagrilla();

            bool swf = false;

            if (grd002_2f.Rows.Count != 0)
            {


                if (grd002_2f.Rows.Count == 2)
                {
                    if ((grd002_2f.Rows[1].Cells[1].Text) == Convert.ToString(ddown019.SelectedItem))
                    {
                        lbl_causales.Text = "Esta Causal ya existe, Ingrese una distinta";
                        lbl_causales.Visible = true;
                        swf = true;
                    }

                }
                for (int j = 0; j < grd002_2f.Rows.Count; j++)
                {

                    if (Server.HtmlDecode((grd002_2f.Rows[j].Cells[1].Text)) != Convert.ToString(ddown019.SelectedItem) && swf == false) //|| (grd002.Rows[1].Cells[2].Text) != Convert.ToString(tddown018.SelectedItem))
                    {
                        int fila = grd002_2f.Rows.Count;
                        ncoll.Insert_CausalesIngreso(SSnino.ICodIE, Convert.ToInt32(ddown019.SelectedValue), fila + 1, ddown020.SelectedValue, DateTime.Now, Convert.ToInt32(UserId), codTribunal);
                        ordenarCausalesIngreso(SSnino.ICodIE, Convert.ToInt32(Session["IdUsuario"].ToString()));
                        Limpiacausales();

                    }
                    else
                    {
                        lbl_causales.Text = "Esta Causal ya existe, Ingrese una distinta";
                        lbl_causales.Visible = true;
                    }
                    break;

                }

            }
            else
            {

                ncoll.Insert_CausalesIngreso(SSnino.ICodIE, Convert.ToInt32(ddown019.SelectedValue), 2, ddown020.SelectedValue, DateTime.Now, Convert.ToInt32(UserId), codTribunal);
                ordenarCausalesIngreso(SSnino.ICodIE, Convert.ToInt32(Session["IdUsuario"].ToString()));
                Limpiacausales();
            }
        }

        leeyllenagrilla();
    }

    protected bool ordenarCausalesIngreso(int ICodIE, int IdusuarioActualizacion)
    {
        int actualizadoCorrecto = 0;
        DataTable dt = new DataTable();
        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand command = new SqlCommand("OrdenarPrioridadCausalesIngreso", sqlc);

        command.CommandTimeout = 1000000;
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@ICodIE", SqlDbType.Int).Value = ICodIE;
        command.Parameters.Add("@IdusuarioActualizacion", SqlDbType.Int).Value = IdusuarioActualizacion;

        command.Connection.Open();

        actualizadoCorrecto = Convert.ToInt32(command.ExecuteScalar());

        command.Connection.Close();

        return actualizadoCorrecto > 0;
    }
    //protected void txt006F2_ValueChange(object sender, EventArgs e)
    //{

    //    if (txt006F2.Text == "") return;

    //    String sConsulta = "select dbo.f_tmpValidaRuc('" + txt006F2.Text + "')";
    //    parcoll pc = new parcoll();
    //    DataTable dt = pc.ejecuta_SQL(sConsulta);
    //    if (!(dt.Rows.Count > 0 && (bool)dt.Rows[0][0]))
    //    {
    //        lblErrorRUC.Visible = true;
    //        txt006F2.BackColor = colorCampoObligatorio;
    //        txt006F2.Text = "";
    //    }
    //    else
    //    {
    //        lblErrorRUC.Visible = false;
    //        txt006F2.BackColor = System.Drawing.Color.White;
    //    }
    //}
    protected void utab_TabClick(object sender, EventArgs e)
    {
        // validatedata(Convert.ToInt32(e.PreviousSelectedTab.AccessKey), false);
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        ninocoll ncoll = new ninocoll();

        if (ValidateTermino() == true)
        {
            dcoll.Update_InformesDiagnosticos(VICodInfDiagnostico, SSnino.ICodIE, Convert.ToDateTime(cal001.Text), Convert.ToInt32(ddown006.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), Convert.ToDateTime(cal003.Text), DateTime.Now, Convert.ToInt32(UserId));

            //btn008.Enabled = true;
            btn008.Attributes.Remove("disabled");

            cal001.Enabled = true;
            cal001.Text = "";
            ddown003.Enabled = true;
            ddown003.SelectedValue = "0";
            ddown006.SelectedValue = "0";



            DataTable dt = new DataTable();
            grd007.DataSource = dt;
            grd008.DataSource = dt;
            cal003.Text = "";
            grd007.Visible = false;
            grd008.Visible = false;
            //tcal001.MinDate = SSnino.fchingdesde;
            //tcal001.MaxDate = DateTime.Now;

            CalendarExtender2_cal001.StartDate = SSnino.fchingdesde;
            CalendarExtender2_cal001.EndDate = DateTime.Now;


            limpiagestion();
            //divDetalleDiag.Attributes.Remove("class");
            divDetalleDiag.Visible = false;

            RevisaPosibleNuevoInforme();

            grd0012f.Focus();
        }

        DataTable dt77 = ncoll.callto_get_informediagnostico(Convert.ToInt32(SSnino.ICodIE.ToString()));
        DataView dv77 = new DataView(dt77);
        grd0012f.DataSource = dv77;
        dv77.Sort = "ICodInformeDiagnostico";
        grd0012f.DataBind();
        for (int i = 0; i < grd0012f.Rows.Count; i++)
        {
            try
            {

                if (grd0012f.Rows[i].Cells[4].Text == "01-01-1900")
                {
                    grd0012f.Rows[i].Cells[4].Text = "-";

                }
            }
            catch { }

        }
    }

    /// <summary>
    /// GMP
    /// Boton "Volver" de los tabs
    /// Puse invisible los botones "btn005"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn005_Click(object sender, EventArgs e)
    {
        /*    DataTable dt = new DataTable();
            grd007.DataSource = dt;
            grd008.DataSource = dt;

            Limpiarcabecera();

            utab2.Visible = false;

            SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
            rdo001.DataBind();
            clean_tab();

            grd007.Visible = false;
            grd008.Visible = false;


            SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
            SSnino.CodProyecto = Convert.ToInt32(ddown002.SelectedValue);
            SSnino.Apellido_Paterno = Convert.ToString(txt003.Text.Trim());
            SSnino.Apellido_Materno = Convert.ToString(txt004.Text.Trim());
            SSnino.Nombres = Convert.ToString(txt005.Text.Trim());
            SSnino.tipobusqueda = 2;
            //SSnino.CodNino = Convert.ToInt32(txt002.Text.Trim());
            Ninos_busqueda1.getgridinproyect(true, false, 0);
            Ninos_busqueda1.Visible = true;


            bool swLrpa = FiltroLRPA();btnlimpiar_Click1

            if (swLrpa == true)
            {
                utab2.Tabs[4].Visible = false;
            }
            else
            {
                utab2.Tabs[4].Visible = true;
            }

            pnl001.Visible = false;
            utab2.Visible = false;
         */
    }
    //protected void btn001_Click1(object sender, EventArgs e)
    //{
    //    string cadena = string.Empty;

    //    cadena = @"window.open(Page, 'ninos_solicituddiligencias.aspx', '560', '400')";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);

    //}
    protected void btnlimpiar_Click1(object sender, EventArgs e)
    {

        //ddown001.SelectedValue = Convert.ToString(0);
        //ddl_Proyectos.SelectedValue = Convert.ToString(0);
        //muestra_pestaña(1);
        Ninos_busqueda1.Visible = false;
        txt004.Text = ""; txt004.ReadOnly = false;
        txt005.Text = ""; txt005.ReadOnly = false;
        txt003.Text = ""; txt003.ReadOnly = false;
        utab2_nino.Visible = false;
        pnl001.Visible = false;
        limpiatodo();
        //utab2.Visible = false;
        // JOVM - 03/02/2015
        // Se habilitan DDWList de Instituciones y Proyectos
        // y se limpian datos de la SESSION["NNA"]
        ddown001.Enabled = true;
        ddl_Proyectos.Enabled = true;
        Session["NNA"] = null;
        //----------------------------

        lbl004.Text = "";
        tr_fecha_nacimiento.Visible = false;
        tr_fecha_ingreso.Visible = false;
        ddown001.Attributes.Remove("disabled");
        ddl_Proyectos.Attributes.Remove("disabled");
        //ddl_Proyectos.SelectedIndex = 0;

        tr_fecha_nacimiento.Visible = false;
        tr_fecha_ingreso.Visible = false;

        //imb_lupaproyecto.Visible = true;
        imb_lupaproyecto.Attributes.Remove("disabled");
        //imb_lupa_institucion.Visible = true;
        imb_lupa_institucion.Attributes.Remove("disabled");
        btnbuscar.Visible = true;
        cal001.Enabled = true;
        ddown003.Enabled = true;
        //btn008.Enabled = false;
        btn008.Attributes.Remove("disabled");

    }
    protected void btnvolver_Click1(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("../mod_ninos/index_ninos.aspx");
            Response.Redirect("~/index.aspx");
        }
        catch (Exception)
        {
        }

    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        try
        {
            limpiatodo();
            SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
            SSnino.CodProyecto = Convert.ToInt32(ddl_Proyectos.SelectedValue);
            SSnino.Apellido_Paterno = Convert.ToString(txt003.Text.Trim());
            SSnino.Apellido_Materno = Convert.ToString(txt004.Text.Trim());
            SSnino.Nombres = Convert.ToString(txt005.Text.Trim());
            SSnino.tipobusqueda = 2;
            pnl001.Visible = false;
            Ninos_busqueda1.getgridinproyect(true, false, 0);
            Ninos_busqueda1.Visible = true;

            lbl_resumen_filtro.Text = "<br>";
            lbl_resumen_filtro.Text += "<strong>Busqueda:</strong>";
            lbl_resumen_filtro.Text += " " + ddl_Proyectos.SelectedItem.Text.Trim() + " ";
            if (txt003.Text != "")
            {
                lbl_resumen_filtro.Text += "//" + " " + txt003.Text.Trim() + " ";
            }

            if (txt004.Text != "")
            {
                lbl_resumen_filtro.Text += txt004.Text.Trim() + " ";
            }
            if (txt005.Text != "")
            {
                lbl_resumen_filtro.Text += " " + txt005.Text.Trim() + " ";
            }

            lbl_resumen_filtro.Visible = true;
            lbl_resumen_filtro.Style.Add("display", "none");
        }
        catch (Exception ex)
        { }

    }


    protected void btn002ds_Click(object sender, EventArgs e)
    {
        clean_tab();
        lbl001.Text = "";
        ViewState["ICodCurrentPage"] = 2;


    }


    //protected void btn007_Click1(object sender, EventArgs e)
    //{
    //    clean_tab();
    //    //SSnino.ICodinformediagnostico = VICodInfDiagnostico;
    //    //string cadena = string.Empty;

    //    //cadena = @"window.open(this.Page, 'accionesinformediagnostico.aspx', '1000', '450')";
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "accionesinformediagnostico", cadena, true);
    //}

    protected void grd008_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(3);
        int icodaccion;
        switch (e.CommandName)
        {

            case "M":
                //int icodaccion = Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
                //SSnino.ICodinformediagnostico = VICodInfDiagnostico;
                //string cadena = string.Empty;

                //cadena = @"window.open(Page, 'accionesinformediagnostico.aspx?icodaccion=" + icodaccion + "&sw=true', 'Acciones_Informe_Diagnostico', '560', '400')";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Acciones_Informe_Diagnostico", cadena, true);

                break;
            case "E":

                icodaccion = Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

                dilegenciascoll dicoll = new dilegenciascoll();
                diagnosticoscoll dcoll = new diagnosticoscoll();
                dcoll.callto_delete_accionesinformediagnostico_1(icodaccion);

                DataTable dt10 = dcoll.GetAccionesInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));//SSnino.ICodIE.ToString());
                DataView dv10 = new DataView(dt10);
                grd008.DataSource = dv10;
                //dv10.Sort = "FechaAccion";
                grd008.DataBind();
                break;

        }
    }
    protected void BtnFun_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();

        Button btn = (Button)sender;

        switch (btn.ClientID)
        {
            case "BtnFun_HecSal":
                DataTable dt4 = dcoll.GetHechosSalud(SSnino.ICodIE.ToString());
                DataView dv4 = new DataView(dt4);
                grd004.DataSource = dv4;
                grd004.DataBind();
                txtpos004.Focus();

                //lbl002.Text = (dt4.Rows.Count == 0) ? Resources.lblmessages.No_Data : Resources.lblmessages.Hechos_de_Salud;
                break;
            case "BtnFun_SolDil":
                dilegenciascoll dicoll = new dilegenciascoll();
                DataTable dt2 = dicoll.GetDiligencias(SSnino.ICodIE.ToString());
                DataView dv2 = new DataView(dt2);
                dv2.Sort = "FechaSolicitud";
                grd002.DataSource = dv2;
                grd002.DataBind();
                //upDiligencias.Update();
                break;
            case "BtnFun_AgrDis":
                DataTable dt3 = dcoll.GetDiagnosticosDiscapacidad(SSnino.ICodIE.ToString());
                DataView dv3 = new DataView(dt3);
                grd003.DataSource = dv3;
                grd003.DataBind();
                //updateDiscapacidad.Update();
                //lbl001.Text = (dt3.Rows.Count == 0) ? Resources.lblmessages.No_Data : Resources.lblmessages.Discapacidad;

                break;
            case "BtnFun_AccInf":
                DataTable dt10 = dcoll.GetAccionesInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));//Convert.ToString(SSnino.ICodinformediagnostico));
                DataView dv10 = new DataView(dt10);
                grd008.DataSource = dv10;
                grd008.DataBind();


                break;
            case "BtnFun_EnfCro":
                DataTable dt5 = dcoll.GetNinosEnfermedadesCronicas(SSnino.ICodIE.ToString());
                DataView dv5 = new DataView(dt5);
                grd005.DataSource = dv5;
                grd005.DataBind();
                //updateEnfermedadesCronicas.Update();
                //Label3.Text = (dt5.Rows.Count == 0) ? Resources.lblmessages.No_Data : Resources.lblmessages.Enfermedades_Cronicas;

                break;
            case "BtnFun_PerRel":
                ninocoll ncoll = new ninocoll();
                DataTable dt6 = ncoll.GetIngresoPersonaRelacionada(SSnino.ICodIE.ToString());
                DataView dv6 = new DataView(dt6);
                grd006.DataSource = dv6;
                grd006.DataBind();
                //if (dt6.Rows.Count == 0)
                //{
                //    lbl005.Text += Resources.lblmessages.No_Data;
                //}
                //else
                //{
                //    lbl005.Visible = false;
                //}

                break;
        }
    }

    private void muestra_pestaña(int num_tab)
    {
        string rutaux = SSnino.rut;
        //Comprueba en que pestaña se encuentra haciendo postback y la mantiene.
        switch (num_tab)
        {
            case 1:
                tab1.Attributes.Add("class", "tab-pane fade in active");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Add("class", "active");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 2:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade in active");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Add("class", "active");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 3:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade in active");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Add("class", "active");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 4:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade in active");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Add("class", "active");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 5:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade in active");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Add("class", "active");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 6:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade  in active");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Add("class", "active");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 7:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade  in active");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Add("class", "active");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 8:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade  in active");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Add("class", "active");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                CurrentPage.Value = "8";
                break;
            case 9: // medida o sancion
                CurrentPage.Value = "9";
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade  in active");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Add("class", "active");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Remove("class");
                break;
            case 10:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade  in active");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Add("class", "active");
                li_nav11.Attributes.Remove("class");
                break;
            case 11:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade  in active");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Add("class", "active");
                break;
            case 12:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade  in active");
                tab14.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Add("class", "active");
    
                //carga_situacion_migratoria();

                break;
            case 14:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade  in active");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Add("class", "active");
                break;
                case 15:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                tab7.Attributes.Add("class", "tab-pane fade");
                tab8.Attributes.Add("class", "tab-pane fade");
                tab9.Attributes.Add("class", "tab-pane fade");
                tab10.Attributes.Add("class", "tab-pane fade");
                tab11.Attributes.Add("class", "tab-pane fade");
                tab12.Attributes.Add("class", "tab-pane fade");
                tab14.Attributes.Add("class", "tab-pane fade  in active");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                li_nav7.Attributes.Remove("class");
                li_nav8.Attributes.Remove("class");
                li_nav9.Attributes.Remove("class");
                li_nav10.Attributes.Remove("class");
                li_nav11.Attributes.Add("class", "active");
              
                break;
        }
    }


    protected void identificoExtranjero(int codnino)
    {
        coordinador cr = new coordinador();
        List<DbParameter> listDbParameter = new List<DbParameter>();
        int CodTipoNacionalidad_ = 0;
        try
        {
            Conexiones con = new Conexiones();
            DataTable dt_get = (DataTable)con.TraerDataTable("GetNino",codnino);
            foreach (DataRow dt in dt_get.Rows)
            {
                int nacionalidad = Convert.ToInt32(dt["CodNacionalidad"].ToString());
                if (nacionalidad != 0 && nacionalidad != 1)
                {
       
                    li_nav10.Visible = true;
                    tab10.Visible = true;
                    li_nav9.Visible = false;
                    link_tab9.Visible = false;

                }
                else
                {
                    li_nav10.Visible = false;
                    li_nav9.Visible = true;
                    link_tab9.Visible = true;
                    tab10.Visible = false;
                }
            }
        } 
        catch (Exception ex)
        { }
    }
    private void ActualizaEtapIntervencion()
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();

        DataTable dt8 = dcoll.GetEtapasInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));
        DataView dv8 = new DataView(dt8);
        grd007.DataSource = dv8;
        dv8.Sort = "FechaEtapa";
        grd007.DataBind();
    }
    private void RevisaPosibleNuevoInforme()
    {
        ninocoll ncoll = new ninocoll();
        DataTable dt77 = ncoll.callto_get_informediagnostico(Convert.ToInt32(SSnino.ICodIE.ToString()));
        cal001.Enabled = true;
        ddown003.Enabled = true;
        btn008.Attributes.Remove("disabled");

        for (int i = 0; i < grd0012f.Rows.Count; i++)
        {
            if (Convert.ToDateTime(dt77.Rows[i][2].ToString()).ToShortDateString() == "01-01-1900") // SI HAY UNO SIN FINALIZAR: DESHABIILITO EL AGREGAR
            {
                cal001.Enabled = false;
                ddown003.Enabled = false;
                btn008.Attributes.Add("disabled", "disabled");
                VEstado_InfDiag = 1;
                break;
            }
        }
    }


    protected void btn0062f_Click1(object sender, EventArgs e)
    {
        RevisaPosibleNuevoInforme();
    }

    private void mostrar_collapse(bool valor)
    {
        if (valor)
        {
            collapse_Form.Attributes.Remove("Class");
            collapse_Form.Attributes.Add("Class", "panel-collapse collapse in");
        }
        if (!valor)
        {
            collapse_Form.Attributes.Remove("Class");
            collapse_Form.Attributes.Add("Class", "panel-collapse collapse out");
        }
    }

    protected void refrescarDiag_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt10 = dcoll.GetAccionesInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));
        DataView dv10 = new DataView(dt10);
        grd008.DataSource = dv10;
        //dv10.Sort = "FechaAccion";
        grd008.DataBind();
        upTabInformeDiag.Update();
    }
    protected void refrescarDiligencias_Click(object sender, EventArgs e)
    {
        dilegenciascoll dicoll = new dilegenciascoll();
        DataTable dt2 = dicoll.GetDiligencias(SSnino.ICodIE.ToString());
        DataView dv2 = new DataView(dt2);
        dv2.Sort = "FechaSolicitud";
        grd002.DataSource = dv2;
        grd002.DataBind();
        upDiligencias.Update();
        muestra_pestaña(1);
    }
    protected void triggerUpdateDiscapacidad_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt3 = dcoll.GetDiagnosticosDiscapacidad(SSnino.ICodIE.ToString());
        DataView dv3 = new DataView(dt3);
        grd003.DataSource = dv3;
        grd003.DataBind();
        updateDiscapacidad.Update();

    }
    protected void triggerHechosSalud_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt4 = dcoll.GetHechosSalud(SSnino.ICodIE.ToString());
        DataView dv4 = new DataView(dt4);
        grd004.DataSource = dv4;
        grd004.DataBind();
        updateHechosSalud.Update();
    }
    protected void triggerUpdateEnfermedadesCronicas_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt5 = dcoll.GetNinosEnfermedadesCronicas(SSnino.ICodIE.ToString());
        DataView  dv5 = new DataView(dt5);
        grd005.DataSource = dv5;
        grd005.DataBind();
        updateEnfermedadesCronicas.Update();
    }
    public void Log(string mensaje)
    {
        using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(@"C:\website\Prueba.txt"))
        { 

            escritor.WriteLine(mensaje);

        }
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
    }
    #region Articulo 134 bis
    private void getcesepermiso()
    {
        try
        {
            parcoll par = new parcoll();
            DataView dv = new DataView(par.getparTerminoSalida());
            ddl_cesePermiso.DataSource = dv;
            ddl_cesePermiso.DataTextField = "Descripcion";
            ddl_cesePermiso.DataValueField = "CodTerminoSalida";
            dv.Sort = "";
            ddl_cesePermiso.DataBind();

            ControlPostbackddl = 1; 
        }
        catch (Exception ex)
        {  }
    }
    protected void ObtenerAllArticulo134(DataTable dt_grd)
    {
        foreach (DataRow dt in dt_grd.Rows)
        {
            ViewState["vs_IcodArticuloBis"] = dt["IcodArticuloBis"].ToString();
            int laboral = Convert.ToInt32(dt["Laboral"]);
            int capacitacion = Convert.ToInt32(dt["Capacitacion"]);
            int educacion = Convert.ToInt32(dt["Educacion"]);
            string cesePermiso = dt["CesePermiso"].ToString();
            int cumpleestandar = Convert.ToInt32(dt["CumpleEstandar"]);
            DateTime fechaInicio = Convert.ToDateTime(dt["Fechainicio"].ToString());
            DateTime fechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
            string getdescripcion = dt["Descripcion"].ToString();

            if (laboral == 1)
                chk_laboral.Checked = true;
            else chk_laboral.Checked = false;
            if (capacitacion == 1)
                chk_capacitacion.Checked = true;
            else chk_capacitacion.Checked = false;
            if (educacion == 1)
                chk_educacion.Checked = true;
            else chk_educacion.Checked = false;
            ddl_cesePermiso.SelectedValue = cesePermiso;
            if (cumpleestandar == 1)
                chk_cumpleestandar.Checked = true;
            else chk_cumpleestandar.Checked = false;
            txt_fechaInicio_134bis.Text = fechaInicio.ToShortDateString();
            txt_fechatermino_134bis.Text = fechaTermino.ToShortDateString();
            txt_descripcion_134bis.Text = getdescripcion;

        }
        lbl_registro.Text = ViewState["vs_IcodArticuloBis"].ToString();
        Conexiones con = new Conexiones();
        DataTable dt_get = new DataTable();
        dt_get = (DataTable)con.TraerDataTable("Consulta_Articulo134bis", SSnino.ICodIE);
        grd_articulo134.DataSource = dt_get;
        grd_articulo134.DataBind();        
    }
    protected void ObtenerArticulo134()
     {
        //Convert.ToInt32(Session["SS_ICodIE"].ToString())
         DataTable dt_get = new DataTable();
        try
        {
            Conexiones con = new Conexiones();
            // DataTable dtgrd = (DataTable)con.TraerDataTable("ObtenerArticulo134bis", SSnino.ICodIE);
            dt_get = (DataTable)con.TraerDataTable("Consulta_Articulo134bis", SSnino.ICodIE);
            ObtenerAllArticulo134(dt_get);
        }
        catch (Exception ex)
        { }
        finally
        {
            grd_articulo134.DataSource = dt_get;
            grd_articulo134.DataBind();
        }
      
    }

    protected void btn_Art134bis_limpiar_Click(object sender, EventArgs e)
    {
        //SenainfoSdk.UI.Util.CleanControl(this.Controls);
        chk_laboral.Checked = false;
        txt_fechaInicio_134bis.Text = string.Empty;
        chk_capacitacion.Checked = false;
        chk_educacion.Checked = false;
        txt_fechatermino_134bis.Text = string.Empty;
        ddl_cesePermiso.SelectedValue = "0";
        chk_cumpleestandar.Checked = false;
        ViewState["vs_IcodArticuloBis"] = null;
        txt_descripcion_134bis.Text = string.Empty;
        lbl_registro.Text = string.Empty;
        muestra_pestaña(11);
    }
    protected void btn_Art134bis_guardar_Click(object sender, EventArgs e)
    {
        guardarRegistroArticulo134Bis();
        //ControlPostbackddl = 1;
    }
    protected void guardarRegistroArticulo134Bis()
    {
        Conexiones con = new Conexiones();
        int icodarticulo = 0;
        if (ViewState["vs_IcodArticuloBis"] != null)
        { icodarticulo = Convert.ToInt32(ViewState["vs_IcodArticuloBis"].ToString()); }
        int icodie = int.Parse(Session["SS_ICodIE"].ToString());
        Boolean laboral = chk_laboral.Checked;
        Boolean capacitacion = chk_capacitacion.Checked;
        Boolean educacion = chk_educacion.Checked;
        string cesePermiso = ddl_cesePermiso.SelectedValue;
        DateTime fechaInicio = Convert.ToDateTime(txt_fechaInicio_134bis.Text);
        DateTime fechaTermino = Convert.ToDateTime(txt_fechatermino_134bis.Text);
        Boolean CumpleEstandar = chk_cumpleestandar.Checked;
        DateTime fechaActualizacion = DateTime.Now;
        int idUsuario = int.Parse(Session["IdUsuario"].ToString());
        string descricpcion134bis = txt_descripcion_134bis.Text;
     


        SqlCommand cmd = new SqlCommand();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "InsertUpdate_Articulo134bis";
        cmd.Parameters.Add("IcodArticuloBis", SqlDbType.Int).Value = icodarticulo;
        cmd.Parameters.Add("ICodie", SqlDbType.Int).Value = icodie;
        cmd.Parameters.Add("laboral", SqlDbType.Bit).Value = laboral;
        cmd.Parameters.Add("capacitacion", SqlDbType.Bit).Value = capacitacion;
        cmd.Parameters.Add("educacion", SqlDbType.Bit).Value = educacion;
        cmd.Parameters.Add("cesePermiso", SqlDbType.VarChar).Value = cesePermiso;
        cmd.Parameters.Add("fechaInicio", SqlDbType.DateTime).Value = fechaInicio;
        cmd.Parameters.Add("fechaTermino", SqlDbType.DateTime).Value = fechaTermino;
        cmd.Parameters.Add("CumpleEstandar", SqlDbType.Bit).Value = CumpleEstandar;
        cmd.Parameters.Add("FechaActualizacion", SqlDbType.DateTime).Value = fechaActualizacion;
        cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = idUsuario;
        cmd.Parameters.Add("Descripcion", SqlDbType.VarChar).Value = descricpcion134bis;


        cmd.Connection = conex;

        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();
            cmd.Connection.Close();
            Retornodata.Close();
            alert2.Attributes.Add("style", "");
            lbl00552.Text = "Registro realizada con exito.";
            lbl00552.Attributes.Add("style", "");
        }
        catch (Exception ex)
        {
            alert.Style.Remove("display");
            lbl0055.Style.Remove("display");
            lbl0055.Text = "Error al procesar la información...";
        }
        finally
        {
            muestra_pestaña(11);
            DataTable dt_get2 = new DataTable();
            if (ViewState["vs_IcodArticuloBis"] != null)
            {
                dt_get2 = (DataTable)con.TraerDataTable("Consulta_Articulo134bis2", ViewState["vs_IcodArticuloBis"].ToString());
                ObtenerAllArticulo134(dt_get2);
            }
            else
            {
                ObtenerArticulo134();
            }
        }
    }
    protected void pnl_utab11_DataBinding(object sender, EventArgs e)
    {
        //Icodie = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        getcesepermiso();
        ObtenerArticulo134();

    }
    protected void grd_articulo134_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Conexiones con = new Conexiones();
        DataTable dt_get = new DataTable();
        string x = grd_articulo134.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        dt_get = (DataTable)con.TraerDataTable("Consulta_Articulo134bis2", x);
        
        foreach (DataRow dt in dt_get.Rows)
        {
            ViewState["vs_IcodArticuloBis"] = dt["IcodArticuloBis"].ToString();
            int laboral = Convert.ToInt32(dt["Laboral"]);
            int capacitacion = Convert.ToInt32(dt["Capacitacion"]);
            int educacion = Convert.ToInt32(dt["Educacion"]);
            string cesePermiso = dt["CesePermiso"].ToString();
            int cumpleestandar = Convert.ToInt32(dt["CumpleEstandar"]);
            DateTime fechaInicio = Convert.ToDateTime(dt["Fechainicio"].ToString());
            DateTime fechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
            string getdescripcion = dt["Descripcion"].ToString();

            if (laboral == 1)
                chk_laboral.Checked = true;
            else chk_laboral.Checked = false;
            if (capacitacion == 1)
                chk_capacitacion.Checked = true;
            else chk_capacitacion.Checked = false;
            if (educacion == 1)
                chk_educacion.Checked = true;
            else chk_educacion.Checked = false;
            ddl_cesePermiso.SelectedValue = cesePermiso;
            if (cumpleestandar == 1)
                chk_cumpleestandar.Checked = true;
            else chk_cumpleestandar.Checked = false;
            txt_fechaInicio_134bis.Text = fechaInicio.ToShortDateString();
            txt_fechatermino_134bis.Text = fechaTermino.ToShortDateString();
            txt_descripcion_134bis.Text = getdescripcion;
            lbl_registro.Text = ViewState["vs_IcodArticuloBis"].ToString();
        }
        muestra_pestaña(11);
    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {

    }
  
    #endregion

    protected void pnl_utab12_DataBinding(object sender, EventArgs e)
    {
        //ControlPostbackddl_Motivacional = 1;
        getcategoria();
        GetParCondicionPM1();
        GetParCondicionPM3();
        ObtenerPlanMotivacional();
    }
    protected void pnl_utab14_DataBinding(object sender, EventArgs e)
    {
        gettipoflexibilidad();
        ObtenerFlexibilizacion();

    }

    #region PlanMotivacional
    private void getcategoria()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.getparCategoriaPM());
        ddl_categoria.DataSource = dv;
        ddl_categoria.DataTextField = "Descripcion";
        ddl_categoria.DataValueField = "CodCategoria";
        dv.Sort = "";
        ddl_categoria.DataBind();

    }
    private void GetParCondicionPM1()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParCondicionPM1());
        ddl_condicion1.DataSource = dv;
        ddl_condicion1.DataTextField = "Descripcion";
        ddl_condicion1.DataValueField = "CodCondicion";
        dv.Sort = "";
        ddl_condicion1.DataBind();
    }
    private void GetParCondicionPM3()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParCondicionPM3());
        ddl_condicion3.DataSource = dv;
        ddl_condicion3.DataTextField = "Descripcion";
        ddl_condicion3.DataValueField = "CodCondicion";
        dv.Sort = "";
        ddl_condicion3.DataBind();
    }

    protected void lnk_guardarPlanMotivacional_Click(object sender, EventArgs e)
    {
        int pernocta = 0;
        int diaspernocta = 0;
        int condicion4 = 0;
        int resultado = 0;
        int IcodPlanMotivacional = 0;
        if (ViewState["vs_IcodPlanMotivacional"] != null)
        { IcodPlanMotivacional = Convert.ToInt32(ViewState["vs_IcodPlanMotivacional"].ToString());}
       
        int icodie = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        int codcategoria = int.Parse(ddl_categoria.SelectedValue);
        int CodCondicion1 = int.Parse(ddl_condicion1.SelectedValue);
        if (rbt_pernotaSiempre.Checked)
            pernocta = 1;
        if (rbt_pernoctaAveces.Checked)
            pernocta = 1;
        int diasPernocta = int.Parse(txt_cantidadDiasPernocta.Text);
        int codcondicion3 = int.Parse(ddl_condicion3.SelectedValue);
        if (rdb_continuo.Checked)
            condicion4 = 1;
        if (rdb_discontinuo.Checked)
            condicion4 = 1;
        int cantidaddiasCondicion4 = int.Parse(txt_cantidaddeDias.Text);
        DateTime fechaIncio = DateTime.Parse(txt_fechaInicio_PM.Text);
        DateTime fechaTermino = DateTime.Parse(txt_fechaTermino_PM.Text);
        bool compromisoCumplimiento = chk_comproDeCumplimiento.Checked;
        bool certificado = chk_certificadoConstanciaContinuidad.Checked;
        if (rdb_positivo.Checked)
            resultado = 1;
        if (rdb_negativo.Checked)
            resultado = 1;
        string descripcionPlanmotivacional = txt_descripcion.Text;
        DateTime FechaActualizacion = DateTime.Now;
        int idUsuario = Convert.ToInt32(Session["IdUsuario"]);
        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_planMotivacional";
        cmd.Parameters.Add("IcodPlanMotivacional", SqlDbType.Int).Value = IcodPlanMotivacional;
        cmd.Parameters.Add("Icodie", SqlDbType.Int).Value = icodie;
        cmd.Parameters.Add("CodCategoria", SqlDbType.Int).Value = codcategoria;
        cmd.Parameters.Add("CodCondicion1", SqlDbType.Int).Value = CodCondicion1;
        cmd.Parameters.Add("pernocta", SqlDbType.Int).Value = pernocta;
        cmd.Parameters.Add("DiasPernocta", SqlDbType.Int).Value = diasPernocta;
        cmd.Parameters.Add("CodCondicion3", SqlDbType.Int).Value = codcondicion3;
        cmd.Parameters.Add("Condicion4", SqlDbType.Int).Value = condicion4;
        cmd.Parameters.Add("DiasCondicion4", SqlDbType.Int).Value = cantidaddiasCondicion4;
        cmd.Parameters.Add("FechaInicio", SqlDbType.DateTime).Value = fechaIncio;
        cmd.Parameters.Add("FechaTermino", SqlDbType.DateTime).Value = fechaTermino;
        cmd.Parameters.Add("CompromisoCumplimiento", SqlDbType.Bit).Value = compromisoCumplimiento;
        cmd.Parameters.Add("Certificado", SqlDbType.Bit).Value = certificado;
        cmd.Parameters.Add("Resultado", SqlDbType.Int).Value = resultado;
        cmd.Parameters.Add("Descripcion", SqlDbType.VarChar).Value = descripcionPlanmotivacional;
        cmd.Parameters.Add("FechaActualizacion", SqlDbType.DateTime).Value = FechaActualizacion;
        cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = idUsuario;



        cmd.Connection = conex;

        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();
            cmd.Connection.Close();
            Retornodata.Close();
            alert2.Attributes.Add("style", "");
            lbl00552.Text = "Registro realizada con exito.";
            lbl00552.Attributes.Add("style", "");
        }
        catch (Exception ex)
        {
            alert.Style.Remove("display");
            lbl0055.Style.Remove("display");
            lbl0055.Text = "Error al procesar la información...";
        }
        muestra_pestaña(12);
        ObtenerPlanMotivacional();
        //ControlPostbackddl = 1;
    }
    protected void ObtenerPlanMotivacional()
    {
        try
        {
            DataTable dt_consulta = new DataTable();
            Conexiones con = new Conexiones();
            DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_PlanMotivacional", Session["SS_Icodie"]);
            foreach (DataRow dt in dt_get.Rows)
            {
                //tipo falta
                ViewState["vs_IcodPlanMotivacional"] = dt["IcodPlanMotivacional"].ToString();
                string categoria = dt["CodCategoria"].ToString();
                string condicion = dt["CodCondicion1"].ToString();
                int pernocta = Convert.ToInt32(dt["Pernocta"]);
                string cantDiasPer = dt["DiasPernocta"].ToString();
                string Condicion3 = dt["CodCondicion3"].ToString();
                int Condicion4 = Convert.ToInt32(dt["Condicion4"]);
                string cantDias = dt["DiasCondicion4"].ToString();
                DateTime fechaInicio = Convert.ToDateTime(dt["FechaInicio"].ToString());
                int CompromisoCumplimiento = Convert.ToInt32(dt["CompromisoCumplimiento"]);
                DateTime FechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
                int Certificado = Convert.ToInt32(dt["Certificado"]);
                int resultado = Convert.ToInt32(dt["Resultado"]);
                string descripcionPlanMotivacional = dt["Descripcion"].ToString();

                ddl_categoria.SelectedValue = categoria;
                ddl_condicion1.SelectedValue = condicion;
                if (pernocta == 1)
                    rbt_pernotaSiempre.Checked = true; 
                else rbt_pernotaSiempre.Checked = false;
                txt_cantidadDiasPernocta.Text = cantDiasPer;
                ddl_condicion3.SelectedValue = Condicion3;
                if (Condicion4 == 1)
                    rdb_continuo.Checked = true;
                else rdb_discontinuo.Checked = false;
                txt_cantidaddeDias.Text = cantDias;
                txt_fechaInicio_PM.Text = fechaInicio.ToShortDateString();
                if (CompromisoCumplimiento == 1)
                    chk_comproDeCumplimiento.Checked = true;
                else chk_comproDeCumplimiento.Checked = false;
                txt_fechaTermino_PM.Text = FechaTermino.ToShortDateString();
                if (Certificado == 1)
                    chk_certificadoConstanciaContinuidad.Checked = true;
                else chk_certificadoConstanciaContinuidad.Checked = false;
                if (resultado == 1)
                    rdb_positivo.Checked = true;
                else rdb_negativo.Checked = false;
                txt_descripcion.Text = descripcionPlanMotivacional;
            }
     
            //dt_consulta = (DataTable)con.TraerDataTable("Consulta_PlanMotivacional2");
            grv_planMotivacional.DataSource = dt_get;
            grv_planMotivacional.DataBind();
        }
        catch (Exception ex)
        { }

    }
    protected void grv_planMotivacional_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Conexiones con = new Conexiones();
         string x = grv_planMotivacional.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
         DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_PlanMotivacionalByCodPlan", x);
        foreach (DataRow dt in dt_get.Rows)
        {
            //tipo falta
            getcategoria();
            GetParCondicionPM3();
            string categoria = dt["CodCategoria"].ToString();
            string condicion = dt["CodCondicion1"].ToString();
            int pernocta = Convert.ToInt32(dt["Pernocta"]);
            string cantDiasPer = dt["DiasPernocta"].ToString();
            string Condicion3 = dt["CodCondicion3"].ToString();
            int Condicion4 = Convert.ToInt32(dt["Condicion4"]);
            string cantDias = dt["DiasCondicion4"].ToString();
            DateTime fechaInicio = Convert.ToDateTime(dt["FechaInicio"].ToString());
            int CompromisoCumplimiento = Convert.ToInt32(dt["CompromisoCumplimiento"]);
            DateTime FechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
            int Certificado = Convert.ToInt32(dt["Certificado"]);
            int resultado = Convert.ToInt32(dt["Resultado"]);
            string descripcionPlanMotivacional = dt["Descripcion"].ToString();

            ddl_categoria.SelectedValue = categoria;
            ddl_condicion1.SelectedValue = condicion;
            if (pernocta == 1)
                rbt_pernotaSiempre.Checked = true;
            else rbt_pernotaSiempre.Checked = false;
            txt_cantidadDiasPernocta.Text = cantDiasPer;
            ddl_condicion3.SelectedValue = Condicion3;
            if (Condicion4 == 1)
                rdb_continuo.Checked = true;
            else rdb_discontinuo.Checked = false;
            txt_cantidaddeDias.Text = cantDias;
            txt_fechaInicio_PM.Text = fechaInicio.ToShortDateString();
            if (CompromisoCumplimiento == 1)
                chk_comproDeCumplimiento.Checked = true;
            else chk_comproDeCumplimiento.Checked = false;
            txt_fechaTermino_PM.Text = FechaTermino.ToShortDateString();
            if (Certificado == 1)
                chk_certificadoConstanciaContinuidad.Checked = true;
            else chk_certificadoConstanciaContinuidad.Checked = false;
            if (resultado == 1)
                rdb_positivo.Checked = true;
            else rdb_negativo.Checked = false;
            txt_descripcion.Text = descripcionPlanMotivacional;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "x", "$('#link_tab11_2').click();", true);
            muestra_pestaña(12);
        }

    }
    protected void lnk_limpiarPlanMotivacional_Click(object sender, EventArgs e)
    {
        ViewState["vs_IcodPlanMotivacional"] = null;
        ddl_categoria.SelectedValue = "0";
        txt_fechaInicio_PM.Text = string.Empty;
        ddl_condicion1.SelectedValue = "0";
        chk_comproDeCumplimiento.Checked = false;
        txt_fechaTermino_PM.Text = string.Empty;
        txt_cantidadDiasPernocta.Text = string.Empty;
        chk_certificadoConstanciaContinuidad.Checked = false;
        ddl_condicion3.SelectedValue = "0";
        txt_cantidaddeDias.Text = string.Empty;
        txt_descripcion.Text = string.Empty;
        muestra_pestaña(12);
    }
    #endregion
    #region Flexibilizacion
    private void gettipoflexibilidad()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParFlexibilizacion());
        ddl_tipoParflexibilidad.DataSource = dv;
        ddl_tipoParflexibilidad.DataTextField = "Descripcion";
        ddl_tipoParflexibilidad.DataValueField = "CodFlexibilizacion";
        dv.Sort = "";
        ddl_tipoParflexibilidad.DataBind();

    }
    protected void ObtenerFlexibilizacion()
    {
        try
        {

            Conexiones con = new Conexiones();
            DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_Flexibilizacion", Session["SS_Icodie"]);
            foreach (DataRow dt in dt_get.Rows)
            {
                ViewState["vs_IcodFlexibilizado"] = dt["IcodFlexibilizado"].ToString(); 
                string tipoFlexibilidad = dt["CodFlexibilizado"].ToString();
                DateTime fechaInicio = Convert.ToDateTime(dt["Fechainicio"].ToString());
                DateTime fechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
                ddl_tipoParflexibilidad.SelectedValue = tipoFlexibilidad;
                txt_fechaInicio_fle.Text = fechaInicio.ToShortDateString();
                txt_fechaTermino_fle.Text = fechaTermino.ToShortDateString();
              // muestra_pestaña(14); 
            }
            grv_flexibilizacion.DataSource = dt_get;
            grv_flexibilizacion.DataBind();
        }
        catch (Exception ex)
        { }
     
    }
    protected void lnk_guardar_Flexibilizacion_Click(object sender, EventArgs e)
    {
        int IcodFlexibilizado = 0;
        if (ViewState["vs_IcodFlexibilizado"] != null)
        { IcodFlexibilizado = Convert.ToInt32(ViewState["vs_IcodFlexibilizado"].ToString()); }
       
        int CodFlexibilizado = int.Parse(ddl_tipoParflexibilidad.SelectedValue);
        int icodie = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        DateTime fechainicio = DateTime.Parse(txt_fechaInicio_fle.Text);
        DateTime fechatermino = DateTime.Parse(txt_fechaTermino_fle.Text);
        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insertar_Flexibilizacion";
        cmd.Parameters.Add("IcodFlexibilizado", SqlDbType.Int).Value = IcodFlexibilizado;
        cmd.Parameters.Add("CodFlexibilizado", SqlDbType.Int).Value = CodFlexibilizado;
        cmd.Parameters.Add("Icodie", SqlDbType.Int).Value = icodie;
        cmd.Parameters.Add("Fechainicio", SqlDbType.DateTime).Value = fechainicio;
        cmd.Parameters.Add("FechaTermino", SqlDbType.DateTime).Value = fechatermino;
        cmd.Connection = conex;

        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();
            cmd.Connection.Close();
            Retornodata.Close();
        }
        catch (Exception ex)
        {
        }
        muestra_pestaña(14);
        ControlPostbackddl = 1;
        ObtenerFlexibilizacion();
    }
    protected void lnk_limpiar_Flexibilizacion_Click(object sender, EventArgs e)
    {
        ViewState["vs_IcodFlexibilizado"] = null;
        ddl_tipoParflexibilidad.SelectedValue = "0";
        txt_fechaInicio_fle.Text = string.Empty;
        txt_fechaTermino_fle.Text = string.Empty;
        muestra_pestaña(14);
    }
    #endregion
    protected void ddl_cesePermiso_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(11);

    }
    protected void ddl_categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(12);

    }

    protected void ddl_condicion1_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(12);
    }
    protected void ddl_tipoParflexibilidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(14);
    }
    protected void grv_flexibilizacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         Conexiones con = new Conexiones();
         string x = grv_flexibilizacion.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
         DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_FlexibilizacionbyCodFlex", x);
         foreach (DataRow dt in dt_get.Rows)
         {
             gettipoflexibilidad();
             ViewState["vs_IcodFlexibilizado"] = dt["IcodFlexibilizado"].ToString();
             string tipoFlexibilidad = dt["CodFlexibilizado"].ToString();
             DateTime fechaInicio = Convert.ToDateTime(dt["Fechainicio"].ToString());
             DateTime fechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
             ddl_tipoParflexibilidad.SelectedValue = tipoFlexibilidad;
             txt_fechaInicio_fle.Text = fechaInicio.ToShortDateString();
             txt_fechaTermino_fle.Text = fechaTermino.ToShortDateString();
             muestra_pestaña(14);
         }
   
    }
    protected void ddl_condicion3_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(12);
    }
 
    protected void link_tab11_1_Click(object sender, EventArgs e)
    {
    }

}
