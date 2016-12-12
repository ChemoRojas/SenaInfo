/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, validación de fecha, no hay descargas excel
 * validación de RUC en js
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
using System.Threading;
using Argentis.Regmen;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;


using CustomWebControls;


public partial class ninos_index : System.Web.UI.Page
{
    #region Variables_Globales
    public int horas
    {
        get
        {
            if (ViewState["horas"] == null)
            { ViewState["horas"] = -1; }
            return Convert.ToInt32(ViewState["horas"]);
        }
        set { ViewState["horas"] = value; }
    }
    public int ICodIngresoLE
    {
        get
        {
            if (ViewState["ICodIngresoLE"] == null)
            { ViewState["ICodIngresoLE"] = -1; }
            return Convert.ToInt32(ViewState["ICodIngresoLE"]);
        }
        set { ViewState["ICodIngresoLE"] = value; }
    }
    public string repdaño
    {
        get
        {
            if (ViewState["repdaño"] == null)
            { ViewState["repdaño"] = -1; }
            return Convert.ToString(ViewState["repdaño"]);
        }
        set { ViewState["repdaño"] = value; }
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
    public bool val5
    {
        get { return (bool)Session["val5"]; }
        set { Session["val5"] = value; }
    }
    public int Cod_Interv
    {
        get { return (int)Session["Cod_Interv"]; }
        set { Session["Cod_Interv"] = value; }
    }
    public bool grd_val
    {
        get { return (bool)Session["grd_val"]; }
        set { Session["grd_val"] = value; }
    }
    public bool valgr
    {
        get { return (bool)Session["valgr"]; }
        set { Session["valgr"] = value; }
    }
    public bool opc
    {
        get { return (bool)Session["opc"]; }
        set { Session["opc"] = value; }
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
    public DataTable dt_coning
    {
        get { return (DataTable)Session[" dt_coning"]; }
        set { Session[" dt_coning"] = value; }
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
    public DataTable DTTipoSancionAccesoria
    {
        get { return (DataTable)Session["DTTipoSancionAccesoria"]; }
        set { Session["DTTipoSancionAccesoria"] = value; }
    }

    public string tipo
    {
        get { return (string)Session["tipo"]; }
        set { Session["tipo"] = value; }
    }

    public int UserId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }

    public DataTable DTProyecto
    {
        get { return (DataTable)Session["DTProyecto"]; }
        set { Session["DTProyecto"] = value; }
    }

    public int AlertaLE
    {
        get { return (int)Session["CodAlertaLE"]; }
        set { Session["CodAlertaLE"] = value; }
    }

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        string[] lstAlertaPeores = { "62", "63", "104", "329", "330", "331", "332", "333" };
        //string[] lstAlertaViolacion = { "50" };

        alertaPeores.Visible = false;
        //ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;

        foreach(string val in lstAlertaPeores)
        {
            if (val == ddl_CausalIngreso.SelectedValue)
            {
                alertaPeores.Visible = true;
            }
        
        }

        string[] lstAlertaDrogas = { "34", "35", "88", "90", "154", "155", "156", "157", "158", "162", "243", "244" };
        //string[] lstAlertaViolacion = { "50" };

        //string[] lstProyectosLRPA = { "77", "99", "100", "101", "102", "103", "104", "108", "121", "122", "123", "124", "126", "127", "128", "134", "137" };

        alertaDrogas.Visible = false;
        //ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;

        foreach (string val in lstAlertaDrogas)
        {
            if (val == ddl_CausalIngreso.SelectedValue)
            {
                alertaDrogas.Visible = true;
            }

        }



        if (ddl_CausalIngreso.SelectedValue == "50")
        {
            alertaEmbarazo.Visible = true;
        }
        else
        {
            alertaEmbarazo.Visible = false;
                //ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;
        }


        string[] lstAlertaFemenino = { "1130669", "1130675", "1130672", "1080119","1130675" };
        //string[] lstAlertaViolacion = { "50" };

        alertaFemenino.Visible = false;
        //ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;

        foreach (string val in lstAlertaFemenino)
        {
            if (val == ddl_Proyecto.SelectedValue)
            {
                alertaFemenino.Visible = true;
            }

        }

        string[] lstAlertaMasculino = {"1070158", "1130668", "1130667","1080143","1131210","1130676","1130674","1130671"};
        //string[] lstAlertaViolacion = { "50" };

        alertaMasculino.Visible = false;
        //ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;

        foreach (string val in lstAlertaMasculino)
        {
            if (val == ddl_Proyecto.SelectedValue)
            {
                alertaMasculino.Visible = true;
            }

        }



        string[] lstGestacion = { };

        // Muestra o Oculta el lbl según corresponda
        if (ChkCollapse.Checked == true)
        {
            mostrar_collapse(true);
            SpanCollapse.Attributes.Add("Class", "glyphicon glyphicon-triangle-top");
            lbl_acordeon.Text = "Ocultar Búsqueda Avanzada";
        }
        else
        {
            mostrar_collapse(false);
            SpanCollapse.Attributes.Add("Class", "glyphicon glyphicon-triangle-bottom");
            lbl_acordeon.Text = "Mostrar Búsqueda Avanzada";
        }

        if (Session["codproyecto"] != null)
        {
            LRPAcoll lrpa = new LRPAcoll();

            int ProyectoLRPA = lrpa.Get_IsLRPA(Convert.ToInt32(Session["codproyecto"].ToString()));
            if (ProyectoLRPA == 1)
            {
                if (SSnino.rut != null && SSnino.rut != "")
                {
                    ninocoll ncoll = new ninocoll();
                    DataTable dtNino = ncoll.SQL_NinoII(ninocoll.querytype.inred, "", "", SSnino.rut.Replace(".", ""), "", "", "", "", Session["codproyecto"].ToString());
                    DateTime IFechaNac = Convert.ToDateTime(dtNino.Rows[0]["FechadeNacimiento"]);

                    if (DateTime.Today.AddTicks(-IFechaNac.Ticks).Year - 1 >= 18) //Si el NNA tiene más de 18 años de edad
                        alertaLRPAmayor18.Visible = true;
                }
            }
        }
        
        if (Session["res"] != null)
        {
            if (Session["res"].ToString() == "si")
            {
                Session["res"] = "";

            }

            if (Session["res"].ToString() == "no")
            {

                ddl_TipoCausalIngreso.SelectedValue = "0";

                Session["res"] = "";
            }
        }

        //ddown017.MaxDate = DateTime.Now;
        CalendarExtende916.EndDate = DateTime.Now;

        //Session["vsdir"] = null;
        Session["vsdir"] = "../mod_ninos/ninos_index.aspx";


        #region !Ispostback
        if (!IsPostBack)
        {

            opc = false;
            //ddown001LRPA.MaxDate = DateTime.Now;
            //CalendarExtende930.EndDate = DateTime.Now;

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
                    Response.Redirect("~/logout.aspx"); ;
                }

                ddown017.Text = DateTime.Now.ToShortDateString();
                validatescurity(); //LO ULTIMO DEL LOAD
            #endregion

                lbl001.Text = "0";

                Ninos_busqueda1.Visible = false;

                //Carga Instituciones
                getinstituciones();
                //Carga Proyectos
                getproyectos();
                

                if (Request.QueryString["CODNUEVO"] != null)
                {
                    //SSnino.FechaNacimiento = Convert.ToDateTime("01-01-2010");
                    //Proy
                    int edad = 0;
                    DateTime itime = DateTime.Now;
                    TimeSpan compare = itime.Date - SSnino.FechaNacimiento.Date;
                    edad = Convert.ToInt32(compare.Days / 365);

                    if ((FiltroLRPA() && edad >= 14) || (!(FiltroLRPA()))) // verifica si el proyecto ingresado del niño está en la ley y si el niño cumple con la edad mínima
                    {
                        SSnino.CodNino = Convert.ToInt32(Request.QueryString["CODNUEVO"]);
                        Vnino_Nuevo = 1;
                        getninonuevo();

                        //ClientScript.RegisterStartupScript(this.GetType(), "", "__doPostBack('UpdatePanel7', '');", true);
                        utab_nino.DataBind();
                        utab_nino.Visible = true;
                        div_panel.Visible = true;
                        titulo_datos_nino.Visible = true;
                    }
                    else
                    {
                        window.alert(this.Page, "El niño no cumple la edad mínima para ser ingresado en un proyecto LRPA.");

                    }
                    
                } 

                           

                //if (Request.QueryString["CODNUEVO"] != null)
                //{
                //    SSnino.CodNino = Convert.ToInt32(Request.QueryString["CODNUEVO"]);
                //    Vnino_Nuevo = 1;
                //    getninonuevo();
                //    //ClientScript.RegisterStartupScript(this.GetType(), "", "__doPostBack('UpdatePanel7', '');", true);
                //    utab_nino.DataBind();
                //    utab_nino.Visible = true;
                //    div_panel.Visible = true;
                //    titulo_datos_nino.Visible = true;
                //}

                if (Request.QueryString["param001"] == "S2")
                {
                    //GetSelectedInfo();
                }
                if (Request.QueryString["param001"] == "S1")
                {
                    GetIngreso();
                }

                if (Request.QueryString["sw"] == "3") // busca con el código de la institucion
                {
                    ddl_Institucion.SelectedValue = Request.QueryString["codinst"];
                    getproyectos();
                }

                if (Request.QueryString["sw"] == "4") // busca con el código del proyecto
                {
                    //QueryString["codinst"] ---> es el código del proyecto
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddl_Institucion.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddl_Proyecto.SelectedValue = Request.QueryString["codinst"];
                    getintitucionesver();
                    SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
                    SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
                }


                if (Session["NNA"] != null && Request.QueryString["sw"] == null)
                {
                    oNNA NNA = (oNNA)Session["NNA"];
                    ddl_Institucion.SelectedValue = NNA.NNACodInstitucion;
                    ddown001_SelectedIndexChanged(sender, e);
                    ddl_Proyecto.SelectedValue = NNA.NNACodProyecto;
                    ddown002_SelectedIndexChanged(sender, e);
                    txt001.Text = NNA.NNARut; // RUT
                    txt002.Text = NNA.NNACodNino.ToString();  //codnino
                    txt003.Text = NNA.NNAApePaterno;
                    txt004.Text = NNA.NNAApeMaterno;
                    txt005.Text = NNA.NNANombres;

                    btnsearch.Attributes.Remove("disabled");

                    Button1_Click2(sender, e);
                    //mostrar_collapse(true);

                    


                }

            }
            Session["codinstitucion"] = ddl_Institucion.SelectedValue;
            if (ddl_Proyecto.SelectedValue != "0")
                Session["CodProyecto"] = ddl_Proyecto.SelectedValue;

            if (ddl_Proyecto.SelectedIndex == 0)
            {
                chk001.Visible = false;
                chk001.Checked = false;

                btnsearch.Attributes.Add("disabled", "disabled");

                lbtn004.Enabled = false;
            }
        }//cierrapostback

        
        
        #endregion
    }




    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        #region Ingreso


        ////45442D35-CC14-45C6-89F8-C7F6892D919A 2.2_ver
        //if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        //    lbtn004.Visible = false;

        //79270734-C383-487D-8EAB-BC63F1521932 2.2
        if (!window.existetoken("79270734-C383-487D-8EAB-BC63F1521932"))
        {
            lbtn004.Visible = false;
            lbtn006.Visible = false;
            lk_lista_espera.Visible = false;
            lbl003F2.Visible = false;
            utab_nino.Visible = false;
            titulo_datos_nino.Visible = false;

        }
        #endregion


        #region VALIDA DATOS DE GESTION


        //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
        if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36"))
        {
            //   utab2.Visible = false;
        }

        //169A2222-0D01-4B62-A224-41B67BAD0387 2.4_INGRESAR
        if (!window.existetoken("169A2222-0D01-4B62-A224-41B67BAD0387"))
        {
            ////SOLICITUD DE DILIGENCIAS
            //WebImageButton tbtn001 = (WebImageButton)utab2.FindControl("btn001");
            //tbtn001.Visible = false;

            ////DATOS DE SALUD
            //WebImageButton tbtn002 = (WebImageButton)utab2.FindControl("btn002");
            //WebImageButton tbtn003 = (WebImageButton)utab2.FindControl("btn003");
            //WebImageButton tbtn004 = (WebImageButton)utab2.FindControl("btn004");
            //tbtn002.Visible = false;
            //tbtn003.Visible = false;
            //tbtn004.Visible = false;

            ////INFORME DE DIAGNOSTICO
            //LinkButton tlnk001 = (LinkButton)utab2.FindControl("lnk001");
            //WebImageButton tbtn008 = (WebImageButton)utab2.FindControl("btn008");
            //WebImageButton tbtn006 = (WebImageButton)utab2.FindControl("btn006");
            //WebImageButton tbtn007 = (WebImageButton)utab2.FindControl("btn007");
            //WebImageButton tbtn0010 = (WebImageButton)utab2.FindControl("btn0010");

            //tlnk001.Visible = false;
            //tbtn008.Visible = false;
            //tbtn006.Visible = false;
            //tbtn007.Visible = false;
            //tbtn0010.Visible = false;

            ////PERSONA RELACIONADA
            //WebImageButton tbtn005 = (WebImageButton)utab2.FindControl("btn005");
            //tbtn005.Visible = false;


        }

        //21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        {
            ////SOLICITUD DE DILIGENCIAS
            //GridView tgrd002 = (GridView)utab2.FindControl("grd002"); //7
            //tgrd002.Columns[7].Visible = false;

            ////DATOS DE SALUD
            //GridView tgrd003 = (GridView)utab2.FindControl("grd003"); //5
            //GridView tgrd004 = (GridView)utab2.FindControl("grd004"); //6
            //GridView tgrd005 = (GridView)utab2.FindControl("grd005"); //4
            //tgrd003.Columns[5].Visible = false;
            //tgrd004.Columns[6].Visible = false;
            //tgrd005.Columns[4].Visible = false;

            ////INFORME DE DIAGNOSTICO
            //GridView tgrd008 = (GridView)utab2.FindControl("grd008"); //3
            //tgrd008.Columns[3].Visible = false;

            ////PERSONA RELACIONADA
            //GridView tgrd006 = (GridView)utab2.FindControl("grd006"); //6
            //tgrd006.Columns[6].Visible = false;

        }

        //9273FC38-331B-4E54-B78E-1E7CB41CB0B5 2.4_ELIMINAR
        if (!window.existetoken("9273FC38-331B-4E54-B78E-1E7CB41CB0B5"))
        {

            ////SOLICITUD DE DILIGENCIAS
            //GridView tgrd002 = (GridView)utab2.FindControl("grd002"); //8
            //tgrd002.Columns[8].Visible = false;

            ////DATOS DE SALUD
            //GridView tgrd003 = (GridView)utab2.FindControl("grd003"); //6
            //GridView tgrd004 = (GridView)utab2.FindControl("grd004"); //7
            //GridView tgrd005 = (GridView)utab2.FindControl("grd005"); //5
            //tgrd003.Columns[6].Visible = false;
            //tgrd004.Columns[7].Visible = false;
            //tgrd005.Columns[5].Visible = false;

            ////INFORME DE DIAGNOSTICO
            //GridView tgrd008 = (GridView)utab2.FindControl("grd008"); //4
            //tgrd008.Columns[4].Visible = false;

            ////PERSONA RELACIONADA
            //// No se eliminan personas relacionadas




        }


        #endregion


    }

    #endregion


    #region buscador principal

    private int searchgrid()
    {
        chk001.Visible = false;
        ninocoll ncoll = new ninocoll();
        string sex = "";
        if (rdo_Sexo_F.Checked)
        {
            sex = "F";
        }
        else if (rdo_Sexo_M.Checked)
        {
            sex = "M";
        }

        int counter = 0;
        //string rn = txt001.Text.Replace(" ", "");
        //rn = txt001.Text.Replace(".", "");

        if (txt001.Text.Trim().Length < 5)
        {
            SSnino.rut = "";
        }
        else
        {
            SSnino.rut = txt001.Text.Trim();
        }
        try
        {
            if (txt002.Text != "")
                SSnino.CodNino = Convert.ToInt32(txt002.Text);
            else
                SSnino.CodNino = 0;
        }
        catch
        {
            SSnino.CodNino = 0;
        }
        SSnino.Apellido_Paterno = txt003.Text;
        SSnino.Apellido_Materno = txt004.Text;
        SSnino.Nombres = txt005.Text;
        SSnino.sexo = sex;
        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);


        ncoll.GetData(ninocoll.querytype.onlycount, txt003.Text, txt004.Text, SSnino.rut.Trim().Replace(".",""), txt002.Text.Trim(),
                           sex, ddl_Institucion.SelectedValue, txt005.Text, ddl_Proyecto.SelectedValue, out counter);

        //if (counter < 200 && counter > 0)
        //{

        //    if (ddown002.SelectedIndex > 0)
        //    {
        //        chk001.Visible = false;//true;        

        //    }

        //}
        //else
        //{
        //    lbtn003.Visible = false;
        //    chk001.Visible = false;
        //}

        //jvb
        if (counter > 0)
        {
            //lbtn005.Visible = true;
            lbtn003.Visible = true;

            Label1.Visible = true;
            if (ddl_Proyecto.SelectedIndex > 0)
            {
                chk001.Visible = false;

            }

        }
        else
        {
            lbtn005.Visible = false;
            lbtn003.Visible = false;
        }

        lbl001.Visible = true;
        lbl002.Visible = true;
        lbl001.Text = counter.ToString();

        if (ddl_Proyecto.SelectedIndex > 0)
            lbtn005.Visible = false;
        //estaba en true cuando se presionaba buscar 29-05-2015
        else
            lbtn005.Visible = false;

        return counter;


    }

    public void getninonuevo()
    {

        ///////////SEMICOMPLETA////////////////////////////
        ninocoll ncoll = new ninocoll();
        nino n = ncoll.GetData(SSnino.CodNino.ToString(), "0");


        txt001.Text = n.rut.ToString().ToUpper();
        txt002.Text = n.CodNino.ToString().ToUpper();
        txt003.Text = n.Apellido_Paterno.ToUpper();
        txt004.Text = n.Apellido_Materno.ToUpper();
        txt005.Text = n.Nombres.ToUpper();
        lbl004.Text = n.FechaNacimiento.ToShortDateString();

        ddl_Institucion.SelectedValue = Inst;


        //////////////LISTA//////////////////////////////////
        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(UserId), "V", Convert.ToInt32(Inst));
        DataView dv1 = new DataView(dtproy);
        ddl_Proyecto.DataSource = dv1;
        ddl_Proyecto.DataTextField = "Nombre";
        ddl_Proyecto.DataValueField = "CodProyecto";
        dv1.Sort = "CodProyecto";
        ddl_Proyecto.DataBind();

        ddl_Proyecto.SelectedValue = Proy;


        ////////inmueblecoll incoll = new inmueblecoll();

        ////////DropDownList tddown002 = (DropDownList)utab.FindControl("ddown002");
        ////////tddown002.Items.Clear();
        ////////DataTable dt = incoll.GetInmueble(Proy);
        ////////DataView dv = new DataView(dt);
        ////////tddown002.DataSource = dv;
        ////////tddown002.DataTextField = "Nombre";
        ////////tddown002.DataValueField = "ICodInmueble";
        ////////dv.Sort = "Nombre";
        // tddown002.DataBind();
        // Fin modificacion felipe nino nuevo

        if (n.sexo == "F")
        {
            rdo_Sexo_F.Checked = true;
        }
        else
        {
            rdo_Sexo_M.Checked = true;
        }
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);

        txt001.ReadOnly = true;
        txt002.ReadOnly = true;
        txt003.ReadOnly = true;
        txt004.ReadOnly = true;
        txt005.ReadOnly = true;

        rdo_Sexo_F.Enabled = false;
        rdo_Sexo_M.Enabled = false;

        //ddown001.Enabled = false;
        //ddown002.Enabled = false;
        ddl_Institucion.Enabled = true;
        ddl_Proyecto.Enabled = true;


        getdefaultdata();



    }

    public void GetIngreso()
    {
        txt001.Text = SSnino.rut;
        txt002.Text = SSnino.CodNino.ToString();
        txt003.Text = SSnino.Apellido_Paterno;
        txt004.Text = SSnino.Apellido_Materno;
        txt005.Text = SSnino.Nombres;

        lbl003.Text = SSnino.fchingdesde.ToShortDateString();

        Ninos_busqueda1.Visible = false;

    }

    protected void lnkbsearch_Click(object sender, EventArgs e)
    {
        //lblbmsg.ForeColor = System.Drawing.Color.Red;
        //lblbmsg.Visible = false;
        ////searchgrid();
        //if (searchgrid() <= 1000)
        //{
        //    Ninos_busqueda1.Visible = false;
        //    utab.Visible = false;
        //    pnl001.Visible = false;


        //    if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        //    {
        //        lbtn004.Visible = false;
        //    }
        //    else
        //    {

        //        lbl001F2.Visible = false;
        //        lbl003F2.Visible = true;

        //        if (lbl001.Text == "0")
        //        {
        //            lbtn004.Visible = true;
        //            lbl003F2.Visible = true;

        //        }
        //        else
        //        {
        //            lbtn004.Visible = false;
        //        }
        //    }

        //}
        //else
        //{
        //    lbtn003.Visible = false;
        //}
    }

    private void getinstituciones()
    {

        // <---------- DPL ---------->  18-08-2015
        //institucioncoll icoll = new institucioncoll();
        //DataTable dtinst = icoll.GetData(Convert.ToInt32(UserId));
        // <---------- DPL ---------->  18-08-2015
        DataSet ds = (DataSet)Session["dsParametricas"];
        DataTable dtinst = ds.Tables["dtInstituciones"];
        DataView dv1 = new DataView(dtinst);
        dv1.Sort = "Nombre ASC";
        ddl_Institucion.DataSource = dv1;
        ddl_Institucion.DataTextField = "Nombre";
        ddl_Institucion.DataValueField = "CodInstitucion";

        ddl_Institucion.DataBind();
        // <---------- JVR ---------->  08-01-2016
        if (dtinst.Rows.Count == 2)
            ddl_Institucion.SelectedIndex = 1;
        else
            ddl_Institucion.SelectedIndex = 0;
        // <---------- JVR ---------->  08-01-2016

    }

    protected void lnkbtnver_Click(object sender, EventArgs e)
    {
        int counter = Convert.ToInt32(Session["count_seachgrid"]);
        if (counter <= 1000)
            if (ddl_Institucion.SelectedValue == "0" || ddl_Proyecto.SelectedValue == "0")
            {
                Response.Write("<script language='javascript'>alert('Debe escoger Institución y Código de Proyecto. ');</script>");
            }
            else
            {

                Inst = ddl_Institucion.SelectedValue;
                Proy = ddl_Proyecto.SelectedValue;
                SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
                SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);

                Session["CodProyecto"] = ddl_Proyecto.SelectedValue;
                SSnino.tipobusqueda = 1;

                if (counter > 0)
                {
                    SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
                    SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
                    Ninos_busqueda1.Visible = true;
                    div_panel.Visible = true;
                    Ninos_busqueda1.getgrid(chk001.Checked);
                    utab_nino.Visible = false;
                    titulo_datos_nino.Visible = false;



                    //  LRPAcoll();
                    if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                    {
                        lbtn004.Visible = false;
                    }
                    else
                    {
                        lbtn004.Visible = true;
                        if (counter > 0 && SSnino.rut != "")
                        {
                            lbtn004.Visible = false; // oculta el boton ingresar nuevo niño cuando encuentra un registro por rut
                        }

                        //lbl003F2.Visible = true;
                        //lbl_resumen_filtro.Text = "<br>";
                        //lbl_resumen_filtro.Text += "<strong>Has filtrado utilizando los siguientes datos: </strong>";
                        //lbl_resumen_filtro.Text += "<br>";
                        //lbl_resumen_filtro.Text += "- Institución: " + ddl_Institucion.SelectedItem.Text + "<br>";
                        //lbl_resumen_filtro.Text += "- Proyecto: " + ddl_Proyecto.SelectedItem.Text + " " + "<br>";


                        //if (txt001.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Rut niño: " + txt001.Text.Trim() + "<br>";
                        //}

                        //if (txt002.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Codigo niño: " + txt002.Text.Trim() + "<br>";
                        //}

                        //if (txt003.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Apellido Paterno: " + txt003.Text.Trim() + "<br>";
                        //}

                        //if (txt004.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Apellido Materno: " + txt004.Text.Trim() + "<br>";
                        //}

                        //if (txt005.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Nombres: " + txt005.Text.Trim() + "<br>";
                        //}

                        //if (rdo_Sexo_F.Checked)
                        //{
                        //  lbl_resumen_filtro.Text += "- Sexo: Femenino";
                        //}

                        //if (rdo_Sexo_M.Checked)
                        //{
                        //  lbl_resumen_filtro.Text += "- Sexo: Masculino";
                        //}

                        //lbl_resumen_filtro.Visible = true;
                        //lbl_resumen_filtro.Style.Add("display", "none");
                    }
                }
                else
                {
                    Ninos_busqueda1.Visible = false;
                    utab_nino.Visible = false;
                    titulo_datos_nino.Visible = false;
                    //lbtn004.Visible = false;
                }
            }
    }
    protected void verResultadoBusqueda()
    {
        /* gfontbrevis
         * Esta es una copia de lnkbtnver_Click() para mostrar tablas automaticamente al hacer la búsqueda.
         */
        int counter = Convert.ToInt16(Session["count_seachgrid"]);
        if (counter <= 1000)
            if (ddl_Institucion.SelectedValue == "0" || ddl_Proyecto.SelectedValue == "0")
            {
                Response.Write("<script language='javascript'>alert('Debe escoger Institución y Código de Proyecto. ');</script>");
            }
            else
            {

                Inst = ddl_Institucion.SelectedValue;
                Proy = ddl_Proyecto.SelectedValue;
                SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
                SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);

                Session["CodProyecto"] = ddl_Proyecto.SelectedValue;
                SSnino.tipobusqueda = 1;

                if (counter > 0)
                {
                    SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
                    SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
                    Ninos_busqueda1.Visible = true;
                    div_panel.Visible = true;
                    Ninos_busqueda1.getgrid(chk001.Checked);
                    utab_nino.Visible = false;
                    titulo_datos_nino.Visible = false;



                    //  LRPAcoll();
                    if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                    {
                        lbtn004.Visible = false;
                    }
                    else
                    {
                        lbtn004.Visible = true;
                        if (counter > 0 && SSnino.rut != "")
                        {
                            lbtn004.Visible = false; // oculta el boton ingresar nuevo niño cuando encuentra un registro por rut
                        }

                        //lbl003F2.Visible = true;
                        //lbl_resumen_filtro.Text = "<br>";
                        //lbl_resumen_filtro.Text += "<strong>Has filtrado utilizando los siguientes datos: </strong>";
                        //lbl_resumen_filtro.Text += "<br>";
                        //lbl_resumen_filtro.Text += "- Institución: " + ddl_Institucion.SelectedItem.Text + "<br>";
                        //lbl_resumen_filtro.Text += "- Proyecto: " + ddl_Proyecto.SelectedItem.Text + " " + "<br>";


                        //if (txt001.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Rut niño: " + txt001.Text.Trim() + "<br>";
                        //}

                        //if (txt002.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Codigo niño: " + txt002.Text.Trim() + "<br>";
                        //}

                        //if (txt003.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Apellido Paterno: " + txt003.Text.Trim() + "<br>";
                        //}

                        //if (txt004.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Apellido Materno: " + txt004.Text.Trim() + "<br>";
                        //}

                        //if (txt005.Text.Trim() != "")
                        //{
                        //  lbl_resumen_filtro.Text += "- Nombres: " + txt005.Text.Trim() + "<br>";
                        //}

                        //if (rdo_Sexo_F.Checked)
                        //{
                        //  lbl_resumen_filtro.Text += "- Sexo: Femenino";
                        //}

                        //if (rdo_Sexo_M.Checked)
                        //{
                        //  lbl_resumen_filtro.Text += "- Sexo: Masculino";
                        //}

                        //lbl_resumen_filtro.Visible = true;
                        //lbl_resumen_filtro.Style.Add("display", "none");
                    }
                }
                else
                {
                    Ninos_busqueda1.Visible = false;
                    utab_nino.Visible = false;
                    titulo_datos_nino.Visible = false;
                    //lbtn004.Visible = false;
                }
            }
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();

        if (ddl_Proyecto.SelectedIndex == 0)
        {
            chk001.Visible = false;
            chk001.Checked = false;

            btnsearch.Attributes.Add("disabled", "disabled");

            lbtn004.Enabled = false;
        }
        Session["codinstitucion"] = ddl_Institucion.SelectedValue;
        lbtn003.Visible = false;
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


        DataTable dtproy = pcoll.GetData(Convert.ToInt32(UserId), estado, Convert.ToInt32(ddl_Institucion.SelectedValue));
        DataView dv1 = new DataView(dtproy);
        // <---------- DPL ---------->  09-08-2010
        dv1.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddl_Proyecto.DataSource = dv1;
        ddl_Proyecto.DataTextField = "Nombre";
        ddl_Proyecto.DataValueField = "CodProyecto";//"Codigo Proyecto";
        dv1.Sort = "CodProyecto";
        ddl_Proyecto.DataBind();


        if (dv1.Count == 2)
        {
            ddl_Proyecto.SelectedIndex = 1;
            ddown002_SelectedIndexChanged(new object(), new EventArgs());
        }
        if (dtproy.Rows.Count > 0 && ddl_Proyecto.SelectedValue != "0")
        {
            SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        }

        if (lbtn003.Visible)
        {
            if (Ninos_busqueda1.Visible)
            {
                Ninos_busqueda1.Visible = true;
                Ninos_busqueda1.getgrid(chk001.Checked);
            }
            //if (utab_nino.Visible)
            //{
            //    getinmuble();
            //    gettrabajadores();
            //}
        }



    }

    private void getintitucionesver()
    {
        /////PAG
        Ninos_busqueda1.Visible = false;
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        ninocoll cons = new ninocoll();
        DataTable dt = cons.filtro_ingreso_adulto(SSnino.CodProyecto);        

        //DataTable dt2 = cons.consulta_DATOSPROYECTO_Adulto(SSnino.CodProyecto, codModelo);

        if (dt.Rows.Count > 0)
        {
            int codModelo = Convert.ToInt32(dt.Rows[0][1]);
            //tipo = Convert.ToString(dt.Rows[0][0]);

            if (codModelo == 110 || codModelo == 132) // 110 PAG y 132 FPA
            {
                lk_nino_adulto.Visible = true;

                //if (codModelo == 132)
                //{
                //    lblIngresoAdulto.Text = "FPA Solicitante";
                //}
                //else
                //{
                //    lblIngresoAdulto.Text = "PAG Sólo Flia Origen y Solicitante";
                //    lblIngresoAdulto.Visible = true;
                //}
            }
            else
            {
                lk_nino_adulto.Visible = false;
            }
        }


        if (!window.existetoken("79270734-C383-487D-8EAB-BC63F1521932"))
        {
            lbtn006.Visible = false;
            lk_lista_espera.Visible = false;
            lbl003F2.Visible = false;
        }
        else
        {
            lbl003F2.Visible = true;
            lbtn006.Visible = true;
            lk_lista_espera.Visible = true;
        }

        if (ddl_Proyecto.SelectedIndex > 0)
        {
            chk001.Visible = false;
            chk001.Checked = false;

            btnsearch.Attributes.Remove("disabled");
            lbtn004.Enabled = true;
            lk_lista_espera.Visible = lbtn006.Visible;

            lbl001.Text = "0";
            lbl001.Visible = false;
            lbl002.Visible = false;
            //lbtn005.Visible = true;
        }
        else
        {

            btnsearch.Attributes.Add("disabled", "disabled");

            chk001.Visible = false;
            chk001.Checked = false;
            lbtn004.Enabled = false;
            lk_lista_espera.Visible = false;
            lbtn005.Visible = false;
        }

        if (lbtn003.Visible)
        {
            if (Ninos_busqueda1.Visible)
            {
                Ninos_busqueda1.Visible = true;
                Ninos_busqueda1.getgrid(chk001.Checked);
            }
            //if (utab_nino.Visible)
            //{
            //    getinmuble();
            //    gettrabajadores();
            //}
        }



    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        Inst = ddl_Institucion.SelectedValue;
        Proy = ddl_Proyecto.SelectedValue;

        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);

        getintitucionesver();

        lbtn003.Visible = false;
    }

    private void CargaInmueble()
    {
        //proyectocoll pcoll = new proyectocoll();
        //DataTable dtproyInmueble = pcoll.GetData(Convert.ToInt32(UserId), "V", Convert.ToInt32(Inst));

        //for (int i = 0; i <= dtproyInmueble.Rows.Count - 1; i++)
        //{
        //    if (dtproyInmueble.Rows[i]["CodProyecto"].ToString() != Proy)
        //    {
        //        dtproyInmueble.Rows[i].Delete();
        //    }
        //}
        //dtproyInmueble.AcceptChanges();

        //ddl_Inmueble.Items.Clear();
        //DataView dv2 = new DataView(dtproyInmueble);
        //ddl_Inmueble.DataSource = dv2;
        //ddl_Inmueble.DataTextField = "Nombre";
        //ddl_Inmueble.DataValueField = "CodProyecto";

        /////listo//////
        inmueblecoll incoll = new inmueblecoll();


        ddl_Inmueble.Items.Clear();
        DataTable dt = incoll.GetInmueble(ddl_Proyecto.SelectedValue);
        DataView dv = new DataView(dt);
        ddl_Inmueble.DataSource = dv;
        ddl_Inmueble.DataTextField = "Nombre";
        ddl_Inmueble.DataValueField = "ICodInmueble";
        dv.Sort = "Nombre";

        dv.Sort = "ICodInmueble";
        ddl_Inmueble.DataBind();
        ddl_Inmueble.AppendDataBoundItems = false;
        ddl_Inmueble.SelectedIndex = 0;


        //if (dt.Rows.Count == 1)
        //{
            

        //}
        //else
        //{
        //    ListItem oItem = new ListItem("Seleccionar", "0");
        //    ddl_Inmueble.Items.Add(oItem);
        //    dv.Sort = "ICodInmueble";
        //    ddl_Inmueble.DataBind();
        //    ddl_Inmueble.SelectedIndex = 0;
        //}



    }

    public void changeuc()
    {
        Ninos_busqueda1.Visible = false;
    }

    private void clean_tab()
    {
        for (int j = 0; j < utab_nino.Controls.Count; j++)
        {
            for (int i = 0; i < utab_nino.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((TextBox)utab_nino.Controls[j].Controls[i]).Text = "";
                }
                catch { }


                try
                {
                    ((DropDownList)utab_nino.Controls[j].Controls[i]).SelectedIndex = 0;
                }
                catch { }


                try
                {
                    ((TextBox)utab_nino.Controls[j].Controls[i]).Text = null;

                }
                catch { }
                try
                {
                    ((SenameTextBox)utab_nino.Controls[j].Controls[i]).Text = "";
                }
                catch { }


            }

        }

    }

    private void clean_form()
    {
        DataTable dt = new DataTable();

        Ninos_busqueda1.Visible = false;
        imb_lupaproyecto.Attributes.Remove("disabled");
        imb_lupainstitucion.Attributes.Remove("disabled");
        panelInfoBusqueda.Visible = true;
        resumenBusqueda.Text = "";
        resumenBusqueda.Visible = false;


        //oculta el div de los resultados de busqueda
        div_panel.Visible = false;


        //lbl001F2.Visible = true;

        lbtn004.Visible = false;

        utab_nino.Visible = false;
        titulo_datos_nino.Visible = false;





        // Limpia datos de busqueda del niño
        btnsearch.Attributes.Remove("disabled");
        lbtn003.Visible = false;

        txt001.Text = string.Empty;
        //lbl005.Visible = false;
        txt002.Text = string.Empty;
        txt003.Text = string.Empty;
        txt004.Text = string.Empty;
        txt005.Text = string.Empty;
        txt001.Enabled = true;
        txt002.Enabled = true;
        txt003.Enabled = true;
        txt004.Enabled = true;
        txt005.Enabled = true;
        txt001.ReadOnly = false;
        txt002.ReadOnly = false;
        txt003.ReadOnly = false;
        txt004.ReadOnly = false;
        txt005.ReadOnly = false;

        tbl_orden_tribunal.Visible = true;

        rdo_Sexo_F.Enabled = true;
        rdo_Sexo_M.Enabled = true;
        lblbmsg.Visible = false;
        alerts.Visible = false;
        lblmsgSuccess.Visible = false;
        alerts2.Visible = false;

        ddl_Institucion.Enabled = true;
        ddl_Proyecto.Enabled = true;

        lbl001.Visible = false;
        lbl002.Visible = false;
        lbl004.Text = "";

        rdo_Sexo_F.Checked = false;
        rdo_Sexo_M.Checked = false;

        chk001.Visible = false;

        //lbl_resumen_filtro.Text = "";
        //lbl_resumen_filtro.Style.Add("display", "none");


        //SSnino = new nino();

        ddown_otc.Items.Clear();
        ddl_OrdenDeTribunal_MedidaSancion.Items.Clear();

        // carga denuevo los botones y cosas que se ocultaron cuando se ingresó un niño a un proyecto.
        if (ddl_Institucion.SelectedValue != null && ddl_Proyecto.SelectedValue != null)
        {
            getintitucionesver();
        }
        Session["neo_SSnino"] = null;
    }

    protected void lbtn002_Click(object sender, EventArgs e)
    {
        //clean_form();
        //if (ddown002.SelectedValue != "")
        //{
        //    lbtn002.Enabled = true;
        //}

    }

    #endregion

    #region selected info
    public void GetSelectedInfo()
    {
        //  pnl001.Visible = true;
        //  utab2.Visible = true;
        //  GridView tgrd001 = (GridView)utab2.FindControl("grd001");
        //  txt001.Text = SSnino.rut;
        //  txt002.Text = SSnino.CodNino.ToString();
        //  txt003.Text = SSnino.Apellido_Paterno;
        //  txt004.Text = SSnino.Apellido_Materno;
        //  txt005.Text = SSnino.Nombres;

        //  lbl003.Text = SSnino.fchingdesde.ToShortDateString();

        //  ((Label)utab2.FindControl("lbl000")).Text = Resources.lblmessages.Solicitud_de_Diligencias;
        //  ((Label)utab2.FindControl("lbl001")).Text = Resources.lblmessages.Discapacidad;
        //  ((Label)utab2.FindControl("lbl002")).Text = Resources.lblmessages.Hechos_de_Salud;
        //  ((Label)utab2.FindControl("lbl003")).Text = Resources.lblmessages.Enfermedades_Cronicas;

        //  Ninos_busqueda1.Visible = false;

        //  diagnosticoscoll dcoll = new diagnosticoscoll();
        //  dilegenciascoll dicoll = new dilegenciascoll();
        //  ninocoll ncoll = new ninocoll();

        //  Label tlbl001 = (Label)utab2.FindControl("lbl001");
        //  Label tlbl000 = (Label)utab2.FindControl("lbl000");
        //  GridView tgrd002 = (GridView)utab2.FindControl("grd002");
        //  DataTable dt2 = dicoll.GetDiligencias(SSnino.ICodIE.ToString());
        //  DataView dv2 = new DataView(dt2);
        //  dv2.Sort = "FechaSolicitud";
        //  tgrd002.DataSource = dv2;
        //  tgrd002.DataBind();



        //  if (tgrd002.Rows.Count == 0)
        //  {
        //      tlbl001.Text = "";
        //  }
        //  else 
        //  {
        //      tlbl000.Text = "Solicitud de Diligencias";
        //  }

        //  if (SSnino.Estado == -1)
        //  {
        //      tlbl001.Text = "La Solicitud Ingresada ya existe";
        //  }
        //  else if (SSnino.Estado == 2)
        //  {
        //      tlbl001.Text = "No puede agregar otra diligencia por, ya que el mes esta Cerrado";
        //  }
        //  else
        //  {
        //      tlbl001.Text = "";
        //  }
        //  if (dt2.Rows.Count == 0)
        //  {
        //      ((Label)utab2.FindControl("lbl000")).Text += Resources.lblmessages.No_Data;
        //  }


        //  GridView tgrd003 = (GridView)utab2.FindControl("grd003");
        //  DataTable dt3 = dcoll.GetDiagnosticosDiscapacidad(SSnino.ICodIE.ToString());
        //  DataView dv3 = new DataView(dt3);
        //  tgrd003.DataSource = dv3;
        //  tgrd003.DataBind();

        //  if (dt3.Rows.Count == 0)
        //  {
        //      ((Label)utab2.FindControl("lbl001")).Text += Resources.lblmessages.No_Data;
        //  }

        //  GridView tgrd004 = (GridView)utab2.FindControl("grd004");
        //  DataTable dt4 = dcoll.GetHechosSalud(SSnino.ICodIE.ToString());
        //  DataView dv4 = new DataView(dt4);
        //  tgrd004.DataSource = dv4;
        //  tgrd004.DataBind();

        //  if (dt4.Rows.Count == 0)
        //  {
        //      ((Label)utab2.FindControl("lbl002")).Text += Resources.lblmessages.No_Data;
        //  }

        //  GridView tgrd005 = (GridView)utab2.FindControl("grd005");
        //  DataTable dt5 = dcoll.GetNinosEnfermedadesCronicas(SSnino.ICodIE.ToString());
        //  DataView dv5 = new DataView(dt5);
        //  tgrd005.DataSource = dv5;
        //  tgrd005.DataBind();

        //  if (dt5.Rows.Count == 0)
        //  {
        //      ((Label)utab2.FindControl("lbl003")).Text += Resources.lblmessages.No_Data;
        //  }

        //  GridView tgrd006 = (GridView)utab2.FindControl("grd006");
        //  DataTable dt6 = ncoll.GetIngresoPersonaRelacionada(SSnino.ICodIE.ToString() );
        //  DataView dv6 = new DataView(dt6);
        //  tgrd006.DataSource = dv6;
        //  tgrd006.DataBind();
        //  if (dt6.Rows.Count == 0)
        //  {
        //      ((Label)utab2.FindControl("lbl005")).Text += Resources.lblmessages.No_Data;
        //  }
        //  else
        //  {
        //      ((Label)utab2.FindControl("lbl005")).Text = ((Label)utab2.FindControl("lbl005")).Text;        
        //  }


        //  parcoll pcoll = new parcoll();
        //  DropDownList uddown002 = (DropDownList)utab2.FindControl("ddown002");
        //  DataTable dt7 = pcoll.GetparEtapasIntervencion();
        //  DataView dv7 = new DataView(dt7);
        //  uddown002.DataSource = dv7;
        //  uddown002.DataValueField = "CodEtapasIntervencion";
        //  uddown002.DataTextField = "Descripcion";
        //  uddown002.DataBind();



        //  DropDownList uddown006 = (DropDownList)utab2.FindControl("ddown006");
        //  DataTable dt12 = pcoll.GetparTerminoDiagnostico();
        //  DataView dv12 = new DataView(dt12);
        //  uddown006.DataSource = dv12;
        //  uddown006.DataValueField = "CodEtapasIntervencion";
        //  uddown006.DataTextField = "Descripcion";
        //  dv12.Sort = "Descripcion";
        //  uddown006.DataBind();

        //  DataTable dt9 = dcoll.GetInformesDiagnosticos(SSnino.ICodIE.ToString());
        //  if(dt9.Rows.Count >= 1)
        //  {
        //      SSnino.ICodinformediagnostico = Convert.ToInt32(dt9.Rows[0][0]);
        //      SSnino.InicioInformeDiagnostico = Convert.ToDateTime(dt9.Rows[0][2]);
        //      ((TextBox)utab2.FindControl("cal001")).Value = Convert.ToDateTime(dt9.Rows[0][2]);


        //      Label tlbl0022f = (Label)utab2.FindControl("lbl0022f");
        //      if (SSnino.Estado == -1)
        //      {
        //          tlbl0022f.Text = "La Accion ya fue registrada";
        //      }
        //      else
        //      {
        //          tlbl0022f.Text = "";
        //      }


        //      WebDateChooser tcal003 = (TextBox)utab2.FindControl("cal003");
        //      tcal003.Value = "Seleccione Fecha";


        //      GridView tgrd008 = (GridView)utab2.FindControl("grd008");
        //      DataTable dt10 = dcoll.GetAccionesInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));//Convert.ToString(SSnino.ICodinformediagnostico));
        //      DataView dv10 = new DataView(dt10);
        //      tgrd008.DataSource = dv10;
        //      //dv10.Sort = "FechaAccion";
        //      tgrd008.DataBind();

        //      GridView tgrd007 = (GridView)utab2.FindControl("grd007");
        //      DataTable dt8 = dcoll.GetEtapasInformeDiagnostico(Convert.ToString(VICodInfDiagnostico));
        //      DataView dv8 = new DataView(dt8);
        //      tgrd007.DataSource = dv8;
        //      dv8.Sort = "FechaEtapa";
        //      tgrd007.DataBind();

        //      GridView tgrd0012f = (GridView)utab2.FindControl("grd0012f");
        //      DataTable dt77 = ncoll.callto_get_informediagnostico(Convert.ToInt32(SSnino.ICodIE.ToString()));


        //      DataView dv77 = new DataView(dt77);
        //      tgrd0012f.DataSource = dv77;
        //      dv77.Sort = "ICodInformeDiagnostico";
        //      tgrd0012f.DataBind();

        //      for (int i = 0; i < tgrd0012f.Rows.Count; i++)
        //      {
        //          try
        //          {

        //              if (tgrd0012f.Rows[i].Cells[4].Text == "01-01-1900")
        //              {
        //                  tgrd0012f.Rows[i].Cells[4].Text = "-";

        //              }
        //          }
        //          catch { }



        //      }

        //      for (int i = 0; i < tgrd0012f.Rows.Count; i++)
        //      {
        //          int contador = 0;

        //          if (Convert.ToDateTime(dt77.Rows[i][2].ToString()).ToShortDateString() == "01-01-1900")
        //          {
        //              WebDateChooser tcal001 = (TextBox)utab2.FindControl("cal001");
        //              tcal001.Enabled = false;
        //              DropDownList tddown003 = (DropDownList)utab2.FindControl("ddown003");
        //              tddown003.Enabled = false;
        //              WebImageButton tbtn008 = (WebImageButton)utab2.FindControl("btn008");
        //              tbtn008.Enabled = false;

        //              contador = contador + 1;
        //              VEstado_InfDiag = 1;
        //          }
        //          else if (contador == 0)
        //          {

        //              WebDateChooser tcal001 = (TextBox)utab2.FindControl("cal001");
        //              tcal001.Enabled = true;
        //              DropDownList tddown003 = (DropDownList)utab2.FindControl("ddown003");
        //              tddown003.Enabled = true;
        //              WebImageButton tbtn008 = (WebImageButton)utab2.FindControl("btn008");
        //              tbtn008.Enabled = true;


        //          }
        //      }
        //  }

        //  #region ModificacionIngresonino

        //  #region PersonaContacto

        //  parcoll par = new parcoll();

        //  DataView dvPC = new DataView(par.GetparTipoRelacionPersonaContacto());
        //  DropDownList tddown001_E = (DropDownList)utab2.FindControl("ddown001_E");
        //  tddown001_E.DataSource = dvPC;
        //  tddown001_E.DataTextField = "Descripcion";
        //  tddown001_E.DataValueField = "CodTipoRelacionPersonaContacto";
        //  dvPC.Sort = "Descripcion";
        //  tddown001_E.DataBind();

        //  DataTable dt88 = ncoll.callto_getingresos_egresos(SSnino.ICodIE);
        //  ((TextBox)utab2.FindControl("txt001_E")).Text = dt88.Rows[0]["PersonaContacto"].ToString();
        //  try
        //  { tddown001_E.Items.FindByValue(dt88.Rows[0]["CodTipoRelacionPersonaContacto"].ToString()).Selected = true; }
        //  catch { }
        //  #endregion

        //  #region Ordenes de tribunal

        ////  ninocoll ncoll = new ninocoll();

        //   WebDateChooser tddown017 = (TextBox)utab2.FindControl("ddown017");

        //   tddown017.MinDate = SSnino.fchingdesde;
        //   tddown017.MaxDate = DateTime.Now;

        //  GridView tgrd001U2 = (GridView)utab2.FindControl("grd001U2");

        //  DataTable dtGetTribunal = ncoll.callto_get_tribunalingreso(SSnino.ICodIE);
        //  DataView dvTribunal = new DataView(dtGetTribunal);
        //  tgrd001U2.DataSource = dvTribunal;
        //  dvTribunal.Sort = "Tribunal";
        //  tgrd001U2.DataBind();



        // // ninocoll ncoll = new ninocoll();
        //  DataTable dtOT = new DataTable();
        //  dtOT = ncoll.callto_consulta_calidajuridica(SSnino.ICodIE);
        //  if (dtOT.Rows[0][0].ToString() == "9")
        //  {
        //      utab2.Tabs[5].Visible = false;

        //  }
        //  else
        //  {
        //      DropDownList tddown014 = (DropDownList)utab2.FindControl("ddown014");
        //      DropDownList tddown015 = (DropDownList)utab2.FindControl("ddown015");
        //      DataView dv13 = new DataView(par.GetparRegion());
        //      tddown014.Items.Clear();
        //      tddown014.DataSource = dv13;
        //      tddown014.DataTextField = "Descripcion";
        //      tddown014.DataValueField = "CodRegion";
        //      dv13.Sort = "Descripcion";
        //      tddown014.DataBind();

        //      DataView dv14 = new DataView(par.GetparTipoTribunal());
        //      tddown015.DataSource = dv14;
        //      tddown015.Items.Clear();
        //      tddown015.DataTextField = "Descripcion";
        //      tddown015.DataValueField = "TipoTribunal";
        //      dv14.Sort = "Descripcion";
        //      tddown015.DataBind();


        //  }


        //  #endregion

        //  #region Causales de Ingreso



        //  DataView dv15 = new DataView(par.GetparTipoCausalIngreso());
        //  DropDownList tddown018 = (DropDownList)utab2.FindControl("ddown018");
        //  tddown018.DataSource = dv15;
        //  tddown018.DataTextField = "Descripcion";
        //  tddown018.DataValueField = "CodTipoCausalIngreso";
        //  dv15.Sort = "Descripcion";
        //  tddown018.DataBind();

        //  leeyllenagrilla();



        //  #endregion


        //  #endregion

    }




    #endregion

    #region ingreso

    //private void getinmuble()
    //{

    //    /////listo//////
    //    inmueblecoll incoll = new inmueblecoll();


    //    //ddown002.Items.Clear();

    //    if (ddown002.SelectedValue =="")
    //        ddown002.SelectedValue = "0";

    //    DataTable dt = incoll.GetInmueble(ddown002.SelectedValue);


    //    DataView dv = new DataView(dt);
    //    ddown002.DataSource = dv;
    //    ddown002.DataTextField = "Nombre";
    //    ddown002.DataValueField = "ICodInmueble";
    //    dv.Sort = "Nombre";


    //}

    private void gettrabajadores()
    {
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv9 = new DataView(tcoll.GetTrabajadoresProyecto(ddl_Proyecto.SelectedValue));

        ddl_Entrevistador.Items.Clear();
        ddown011.Items.Clear();

        ddl_Entrevistador.DataSource = dv9;
        ddl_Entrevistador.DataTextField = "NombreCompleto";
        ddl_Entrevistador.DataValueField = "ICodTrabajador";

        ddown011.DataSource = dv9;
        ddown011.DataTextField = "NombreCompleto";
        ddown011.DataValueField = "ICodTrabajador";
        dv9.Sort = "NombreCompleto";


    }


    //////////////////////////////////////////TRAE DATOS PARA SBC Y PSA///////////////////////////
    public void getIngresoRelacion(int codnino)
    {
        ninocoll nc = new ninocoll();
        DataTable dtIR = nc.ingresoRelacion(codnino);

        DateTime fechaIngresoMadre = new DateTime();
        String centroMadre = "";

        foreach (DataRow dr in dtIR.Rows)
        {
            fechaIngresoMadre = Convert.ToDateTime(dr["FechaIngreso"].ToString());
            centroMadre = dr["ICodInmueble"].ToString();
        }


        if (ddl_Proyecto.SelectedValue == centroMadre)
        {

            CalendarExtende903.StartDate = fechaIngresoMadre;
            //CalendarExtende903.EndDate = DateTime.Now;

        }

   }


    public void getdatossbcypsa()
    {

        int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        LRPAcoll codmod = new LRPAcoll();
        DataTable dt2 = codmod.GetCodModIntervencion(codproy);

        int codemod = 0;
        if (dt2.Rows.Count > 0)
            codemod = Convert.ToInt32(dt2.Rows[0][0]);

        if (codemod == 103 || codemod == 108)
        {

            LRPAcoll cons = new LRPAcoll();
            DataView dv = new DataView(cons.GetPartiposancion());
            ddown_tsancion.Items.Clear();
            ddown_tsancion.DataSource = dv;
            ddown_tsancion.DataTextField = "Descripcion";
            ddown_tsancion.DataValueField = "CodTipoSancion";
            dv.Sort = "Descripcion";
            ddown_tsancion.DataBind();
            if (codemod == 103)
            {

                ddown_tsancion.Items.RemoveAt(1);
            }

            LRPAcoll lrpa2 = new LRPAcoll();
            DataView dvconi = new DataView(lrpa2.callto_getpartipoConIngreso());
            ddown_conIng.DataSource = dvconi;
            ddown_conIng.DataTextField = "Nemotecnico";
            ddown_conIng.DataValueField = "CodCondicionIngreso";
            dvconi.Sort = "CodCondicionIngreso";
            ddown_conIng.DataBind();

            dt_coning = new DataTable();

            dt_coning.Columns.Add(new DataColumn("CodCondicionIngreso", typeof(string)));
            dt_coning.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt_coning.Columns.Add(new DataColumn("NemoTecnico", typeof(string)));


            LRPAcoll cons1 = new LRPAcoll();
            DataView dv1 = new DataView(cons1.GetParActividad());
            ddown_tipoBC.Items.Clear();
            ddown_tipoBC.DataSource = dv1;
            ddown_tipoBC.DataTextField = "Descripcion";
            ddown_tipoBC.DataValueField = "CodTipoActividad";
            dv1.Sort = "Descripcion";
            ddown_tipoBC.DataBind();


            LRPAcoll cons4 = new LRPAcoll();
            DataView dv4 = new DataView(cons4.GetParTipoInstitucion());
            ddown_IPSER.Items.Clear();
            ddown_IPSER.DataSource = dv4;
            ddown_IPSER.DataTextField = "Descripcion";
            ddown_IPSER.DataValueField = "TipoInstitucion";
            dv4.Sort = "Descripcion";
            ddown_IPSER.DataBind();


            LRPAcoll cons2 = new LRPAcoll();
            DataView dv2 = new DataView(cons2.GetAreaTrabajo());
            ddown_areaTI.Items.Clear();
            ddown_areaTI.DataSource = dv2;
            ddown_areaTI.DataTextField = "Descripcion";
            ddown_areaTI.DataValueField = "CodTipoAreaTrabajo";
            dv2.Sort = "Descripcion";
            ddown_areaTI.DataBind();


            LRPAcoll cons3 = new LRPAcoll();
            DataView dv3 = new DataView(cons3.GetReparacion());
            ddown_repdaño.Items.Clear();
            ddown_repdaño.DataSource = dv3;
            ddown_repdaño.DataTextField = "Descripcion";
            ddown_repdaño.DataValueField = "CodTipoReparacion";
            dv3.Sort = "Descripcion";
            ddown_repdaño.DataBind();


        }
        else
        {
            ddown_tsancion.Enabled = false;
            txt_hservi.Enabled = false;
            ddown_tipoBC.Enabled = false;
            ddown_IPSER.Enabled = false;
            ddown_areaTI.Enabled = false;
            ddown_repdaño.Enabled = false;
            ddown_conIng.Enabled = false;

            btn_coning.Visible = false;

            tabla_sbs_psa.Visible = false;
        }




        if (codemod == 103)////habilitacion de controles nuevos
        {

            ddown_conIng.Enabled = false;
            btn_coning.Visible = false;


        }


    }
    public void restart_utab()
    {

        // limpia variable de bloqueo de pestañas por ley

        ViewState["bloqueo_ley_pestañas"] = "";

        // comienza con la pestaña numero 1
        muestra_pestaña(1);

        //limpiar pestaña 1 (ingreso)
        txt_FechaIngreso.Text = "";
        txt_FechaIngreso.BackColor = System.Drawing.Color.Empty;


        //limpiar pestaña 2 (datos de ingreso)
        WebNumericEdit1.Text = "";
        WebNumericEdit2.Text = "";
        WebNumericEdit2.BackColor = System.Drawing.Color.Empty;
        txt003a.Text = "";
        txt003a.BackColor = System.Drawing.Color.Empty;
        txt003b.Text = "";
        txt003b.BackColor = System.Drawing.Color.Empty;

        ddown007.Items.Clear();
        ddown007.BackColor = System.Drawing.Color.Empty;
        ddown007.Items.Insert(0, new ListItem("Seleccione", "0"));

        WebTextEdit1.Text = "";
        WebTextEdit1.BackColor = System.Drawing.Color.Empty;
        TextBox1.Text = "";
        TextBox1.BackColor = System.Drawing.Color.Empty;
        chk002.Checked = false;

        ddown013.Items.Clear();
        ddown013.Items.Insert(0, new ListItem("Seleccione", "0"));

        //limpiar pestaña 3 (ordenes del tribunal)

        ddown015.BackColor = System.Drawing.Color.Empty;
        ddown016.BackColor = System.Drawing.Color.Empty;
        WebTextEdit2.BackColor = System.Drawing.Color.Empty;
        Panel1.Visible = false;
        rdo_OrdenTribunal_SI.Enabled = true;
        rdo_OrdenTribunal_SI.BackColor = System.Drawing.Color.Transparent;
        rdo_OrdenTribunal_EnTramite.Enabled = true;
        rdo_OrdenTribunal_EnTramite.BackColor = System.Drawing.Color.Transparent;
        rdo_OrdenTribunal_NO.Enabled = true;

        tabla_OrdenTribunal.Visible = false;

        // mostrar nuevamente cuando  se presiona el radiobutton "SI" y se oculta la tabla 
        tbl_orden_tribunal.Visible = true;

        // limpiar causal de ingreso
        txt006.Text = "";


        ddown020.SelectedValue = "0";
        ddown020.BackColor = System.Drawing.Color.Empty;
        ddown020.Enabled = true;



        txt_descripcionTCI.Text = "";
        txt_descripcionTCI.BackColor = System.Drawing.Color.Empty;
        pnl002.Visible = false;

        //Limpia Lesiones

        ddown021.BackColor = System.Drawing.Color.Empty;
        ddown022.BackColor = System.Drawing.Color.Empty;
        ddown022.BackColor = System.Drawing.Color.Empty;

        txt007.Text = "";
        txt007.BackColor = System.Drawing.Color.Empty;
        chk001Fiscalia_RPA.Checked = false;
        pnl002.Visible = false;
        rdo004.Checked = false;
        rdo004.Enabled = true;
        rdo005.Checked = false;
        rdo005.Enabled = true;
        ddown022.Enabled = true;
        tr_responsable_lesion.Visible = true;


        tabla_sbs_psa.Visible = true;
        ddown_tsancion.Enabled = true;
        txt_hservi.Enabled = true;
        ddown_tipoBC.Enabled = true;
        ddown_IPSER.Enabled = true;
        ddown_areaTI.Enabled = true;
        ddown_repdaño.Enabled = true;
        ddown_conIng.Enabled = true;
        btn_coning.Visible = true;




        //limpia medida o sansión

        if (ddl_OrdenDeTribunal_MedidaSancion.Items.Count > 0)
        {
            ddl_OrdenDeTribunal_MedidaSancion.SelectedIndex = 0;
        }

        ddown_otc.Items.Insert(0, new ListItem("Seleccionar", "0"));
        ddl_OrdenDeTribunal_MedidaSancion.Items.Insert(0, new ListItem("Seleccionar", "0"));

        txt_FechaInicioSancionLRPA.Text = "";
        txt001LRPA.Text = "";
        txt002LRPA.Text = "";
        txt007LRPA.Text = "";
        txt009LRPA.Text = "";
        txt003LRPA.Text = "";
        ddown011LRPA.Items.Clear();
        ddown005LRPA.Items.Clear();
        chk001LRPA.Checked = false;
        btnAgregarTsancionLRPA.Visible = false;
        ddown006LRPA.Visible = false;
        tr_tipo_sancion_accesoria.Visible = false;
        ddown009LRPA.Text = "";
        txt004LRPA.Text = "";
        txt005LRPA.Text = "";
        txt008LRPA.Text = "";
        txt006LRPA.Text = "";
        lbl_avisoLRPA.Visible = false;


        // Cambia de color los controles a blanco
        ddl_Inmueble.BackColor = System.Drawing.Color.Empty;
        ddl_TipoAtencion.BackColor = System.Drawing.Color.Empty;
        ddl_CalidadJuridica.BackColor = System.Drawing.Color.Empty;
        ddl_Escolaridad.BackColor = System.Drawing.Color.Empty;
        ddl_TipoAsistenciaEscolar.BackColor = System.Drawing.Color.Empty;
        ddl_Entrevistador.BackColor = System.Drawing.Color.Empty;
        ddl_TipoSolicitanteIngreso.BackColor = System.Drawing.Color.Empty;
        ddl_TipoCausalIngreso.BackColor = System.Drawing.Color.Empty;
        ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;
        ddown004LRPA.BackColor = System.Drawing.Color.Empty;
        ddl_OrdenDeTribunal_MedidaSancion.BackColor = System.Drawing.Color.Empty;

        txt001LRPA.BackColor = System.Drawing.Color.Empty;
        txt002LRPA.BackColor = System.Drawing.Color.Empty;
        txt007LRPA.BackColor = System.Drawing.Color.Empty;


        //cambia el color de los textos a negro
        pnl_utab1.ForeColor = System.Drawing.Color.Black;
        pnl_utab2.ForeColor = System.Drawing.Color.Black;
        pnl_rdo_orden_tribunal.ForeColor = System.Drawing.Color.Black;
        pnl_utab4.ForeColor = System.Drawing.Color.Black;
        pnl_utab5.ForeColor = System.Drawing.Color.Black;
        pnl_utab6.ForeColor = System.Drawing.Color.Black;



        //agrega nuevamente la ruta hacia el tab correspondiente (desbloquea los tab)        


        link_tab3.Attributes.Add("data-toggle", "tab");
        link_tab4.Attributes.Add("data-toggle", "tab");
        link_tab5.Attributes.Add("data-toggle", "tab");
        link_tab6.Attributes.Add("data-toggle", "tab");

        link_tab2.Attributes.Add("style", "display: block");
        link_tab3.Attributes.Add("style", "display: block");
        link_tab4.Attributes.Add("style", "display: block");
        link_tab5.Attributes.Add("style", "display: block");
        link_tab6.Attributes.Add("style", "display: block");

        link_tab1.Attributes.Remove("Class");
        link_tab2.Attributes.Remove("Class");
        link_tab3.Attributes.Remove("Class");
        link_tab4.Attributes.Remove("Class");
        link_tab5.Attributes.Remove("Class");
        link_tab6.Attributes.Remove("Class");


    }

    public void getdefaultdata()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];
        ///// PARA PSA /////////////// REVISAR
        getdatossbcypsa();
        CargaInmueble();

 

        int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        LRPAcoll codmod = new LRPAcoll();
        DataTable dt2 = codmod.GetCodModIntervencion(codproy);
        
        CalendarExtende903.EndDate = DateTime.Now;
        rdo_OrdenTribunal_SI.Checked = false;
        rdo_OrdenTribunal_EnTramite.Checked = false;
        rdo_OrdenTribunal_NO.Checked = false;

        int codemod = 0;

        if (dt2.Rows.Count > 0)
            codemod = Convert.ToInt32(dt2.Rows[0][0]);

        if (ddl_Proyecto.SelectedItem.Text.IndexOf("(C)") == -1)
        {
            CalendarExtende916.EndDate = DateTime.Now;
        }
        else
        {
            proyectocoll pc = new proyectocoll();
            DataTable dtproy = pc.GetProyectos(SSnino.CodProyecto.ToString());
            CalendarExtende916.StartDate = Convert.ToDateTime(dtproy.Rows[0]["FechaCreacion"]);
            CalendarExtende916.EndDate = Convert.ToDateTime(dtproy.Rows[0]["FechaTermino"]);

            ddown017.Text = Convert.ToDateTime(dtproy.Rows[0]["FechaCreacion"]).ToShortDateString();
        }

        LRPAcoll LRPA = new LRPAcoll();
        atencioncoll acoll = new atencioncoll();
        parcoll pcoll = new parcoll();
        parcoll par = new parcoll();

        ddl_TipoAtencion.Items.Clear();
        ddl_CalidadJuridica.Items.Clear();
        ddown003LRPA.Items.Clear();
        ddown004LRPA.Items.Clear();

        //DataView dv = new DataView(pcoll.GetparRegion());
        DataView dv = new DataView(ds.Tables["dtparRegion"]);
        ddown003LRPA.DataSource = dv;
        ddown003LRPA.DataTextField = "Descripcion";
        ddown003LRPA.DataValueField = "CodRegion";
        dv.Sort = "CodigoRegion ASC";

        bool swLrpa = FiltroLRPA();  ////  hacer filtro  ////
        if (swLrpa)
        {
            DataView dv0 = new DataView(LRPA.GetparTipoTribunalLRPA());
            ddown004LRPA.DataSource = dv0;
            ddown004LRPA.DataTextField = "Descripcion";
            ddown004LRPA.DataValueField = "TipoTribunal";
            dv0.Sort = "Descripcion";

            DataView dv2 = new DataView(LRPA.GetparTipoAtencionLRPA());
            ddl_TipoAtencion.DataSource = dv2;
            ddl_TipoAtencion.DataTextField = "Descripcion";
            ddl_TipoAtencion.DataValueField = "CodTipoAtencion";
            dv2.Sort = "Descripcion";

            DataView dv3 = new DataView(LRPA.GetparCalidadJuridicaLRPA_II(codemod));
            ddl_CalidadJuridica.DataSource = dv3;
            ddl_CalidadJuridica.DataTextField = "Descripcion";
            ddl_CalidadJuridica.DataValueField = "CodCalidadJuridica";
            dv3.Sort = "Descripcion";
        }
        else
        {            
            DataView dv3 = new DataView(pcoll.GetparCalidadJuridica());
           
            proyectocoll proyectoc = new proyectocoll();
            DTProyecto = proyectoc.GetProyectos(SSnino.CodProyecto.ToString());
            

            if (DTProyecto.Rows.Count > 0)
            {
                if (DTProyecto.Rows.Count > 0 && (DTProyecto.Rows[0]["TipoProyecto"].ToString() == "7" || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "92" || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "142")
               || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "81")
                {
                    dv3.RowFilter = "CodCalidadJuridica <> 9";
                } 
            }

            ddl_CalidadJuridica.DataSource = dv3;
            ddl_CalidadJuridica.DataTextField = "Descripcion";
            ddl_CalidadJuridica.DataValueField = "CodCalidadJuridica";
            dv3.Sort = "Descripcion";

            DataView dv1 = new DataView(pcoll.GetparTipoTribunal());
            ddown004LRPA.DataSource = dv1;
            ddown004LRPA.DataTextField = "Descripcion";
            ddown004LRPA.DataValueField = "TipoTribunal";
            dv1.Sort = "Descripcion";

            DataView dv2 = new DataView(acoll.GetparTipoAtencion());
            ddl_TipoAtencion.DataSource = dv2;
            ddl_TipoAtencion.DataTextField = "Descripcion";
            ddl_TipoAtencion.DataValueField = "CodTipoAtencion";
            dv2.Sort = "Descripcion";

        }

        DateTime itime = DateTime.Now;
        TimeSpan compare = itime.Date - Convert.ToDateTime(lbl004.Text).Date; //SSnino.FechaNacimiento.Date;
        int y = Convert.ToInt32(compare.Days / 365);
        float n_dias = compare.Days;
        n_dias = n_dias - (365 * y);
        int meses = Convert.ToInt32(n_dias / 30);

        //TextBox ttxt001 = (TextBox)utab.FindControl("txt001");
        ddl_Escolaridad.Items.Clear();

        WebNumericEdit1.Text = Convert.ToString(y);
        WebNumericEdit2.Text = Convert.ToString(meses);
        if (WebNumericEdit1.Text == "")
        {
            DataView dv4 = new DataView(pcoll.GetparEscolaridad(y));

            ddl_Escolaridad.DataSource = dv4;
            ddl_Escolaridad.DataTextField = "Descripcion";
            ddl_Escolaridad.DataValueField = "CodEscolaridad";
            dv4.Sort = "CodEscolaridad";

        }
        else
        {
            DataView dv42F = new DataView(pcoll.GetparEscolaridad(y));

            ddl_Escolaridad.DataSource = dv42F;
            ddl_Escolaridad.DataTextField = "Descripcion";
            ddl_Escolaridad.DataValueField = "CodEscolaridad";
            dv42F.Sort = "CodEscolaridad";
        }

        getlesionesall();

        ddl_TipoAsistenciaEscolar.Items.Clear();
        DataView dv5 = new DataView(pcoll.GetparTipoAsistenciaEscolar());
        ddl_TipoAsistenciaEscolar.DataSource = dv5;
        ddl_TipoAsistenciaEscolar.DataTextField = "Descripcion";
        ddl_TipoAsistenciaEscolar.DataValueField = "TipoAsistenciaEscolar";
        dv5.Sort = "Descripcion";

        ddown007a.Items.Clear();
        //DataView dv6 = new DataView(pcoll.GetparRegion());
        ddown007a.DataSource = dv;
        ddown007a.DataTextField = "Descripcion";
        ddown007a.DataValueField = "CodRegion";
        //dv6.Sort = "Descripcion";

        ddown008.Items.Clear();
        DataView dv7 = new DataView(pcoll.GetparTipoRelacionConQuienVive());
        ddown008.DataSource = dv7;
        ddown008.DataTextField = "Descripcion";
        ddown008.DataValueField = "CodTipoRelacionConQuienVive";
        dv7.Sort = "Descripcion";

        ddown009.Items.Clear();
        DataView dv8 = new DataView(pcoll.GetparTipoRelacionPersonaContacto());
        ddown009.DataSource = dv8;
        ddown009.DataTextField = "Descripcion";
        ddown009.DataValueField = "CodTipoRelacionPersonaContacto";
        dv8.Sort = "Descripcion";

        gettrabajadores();

        ddl_TipoSolicitanteIngreso.Items.Clear();
        DataView dv11 = new DataView(pcoll.GetparTipoSolicitanteIngreso());
        ddl_TipoSolicitanteIngreso.DataSource = dv11;
        ddl_TipoSolicitanteIngreso.DataTextField = "Descripcion";
        ddl_TipoSolicitanteIngreso.DataValueField = "TipoSolicitanteIngreso";
        dv11.Sort = "Descripcion";

        getcausalesall();

        #region BLOQUEO LRPA
        swLrpa = FiltroLRPA();
        if (swLrpa == true)
        {

            ddl_TipoSolicitanteIngreso.Items.Clear();
            DataTable dtlrpa1 = new DataTable();
            DataRow drlrpa1;

            dtlrpa1.Columns.Add(new DataColumn("TipoSolicitanteIngreso", typeof(int)));
            dtlrpa1.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            drlrpa1 = dtlrpa1.NewRow();
            drlrpa1[0] = "4";
            drlrpa1[1] = "ORGANOS DE ADMINISTRACIÓN DE JUSTICIA";
            dtlrpa1.Rows.Add(drlrpa1);

            DataView dvlrpa1 = new DataView(dtlrpa1);
            ddl_TipoSolicitanteIngreso.DataSource = dvlrpa1;
            ddl_TipoSolicitanteIngreso.DataTextField = "Descripcion";
            ddl_TipoSolicitanteIngreso.DataValueField = "TipoSolicitanteIngreso";

            ddl_TipoSolicitanteIngreso.Enabled = false;
            // tddown013.Items.Clear();
            DataTable dtlrpa2 = new DataTable();
            DataRow drlrpa2;

            dtlrpa2.Columns.Add(new DataColumn("CodSolicitanteIngreso", typeof(int)));
            dtlrpa2.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            drlrpa2 = dtlrpa2.NewRow();
            drlrpa2[0] = "19";
            drlrpa2[1] = "TRIBUNAL";
            dtlrpa2.Rows.Add(drlrpa2);

            DataView dvlrpa2 = new DataView(dtlrpa2);
            ddown013.DataSource = dvlrpa2;
            ddown013.DataTextField = "Descripcion";
            ddown013.DataValueField = "CodSolicitanteIngreso";

            ddown013.Enabled = false;

            btnsaveingreso.Visible = false;
            
            txt003.Enabled = false;
            txt004.Enabled = false;
            ddown009.Enabled = false;
            ddown022.Enabled = false;
            tr_responsable_lesion.Visible = false;

            ddown020.SelectedValue = "T";
            ddown020.Enabled = false;

            WebTextEdit1.Enabled = false;
            TextBox1.Enabled = false;

            WebTextEdit1.Text = "";
            TextBox1.Text = "";
        }
        else
        {
            btnsaveingreso.Visible = true;
        }
        #endregion
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
        dt = LRPA.callto_get_proyectoslrpa(SSnino.CodProyecto);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
            {
                swLrpa = true;
            }
            else
            {
                swLrpa = false;
            }
        }
        else
        {
            swLrpa = false;
        }

        return (swLrpa);


        #endregion

    }


    public void getcausalesall()
    {
        DTcausales = new DataTable();
        DTcausales.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("entidad", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("prioridad", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("coddelito", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("Ruc", typeof(string)));

        grd002.Visible = false;

        ddl_TipoCausalIngreso.Items.Clear();
        bool swLrpa = FiltroLRPA();
        if (swLrpa == true)
        {
            LRPAcoll LRPA = new LRPAcoll();
            DataView dv15 = new DataView(LRPA.GetparTipoCausalIngresoLRPA());
            ddl_TipoCausalIngreso.DataSource = dv15;
            ddl_TipoCausalIngreso.DataTextField = "Descripcion";
            ddl_TipoCausalIngreso.DataValueField = "CodTipoCausalIngreso";
            dv15.Sort = "Descripcion";
        }
        else
        {
            parcoll par = new parcoll();
            //            DataView dv15 = new DataView(par.GetparTipoCausalIngreso());
            DataView dv15 = new DataView(par.GetparTipoCausalIngreso(SSnino.CodProyecto));
            ddl_TipoCausalIngreso.DataSource = dv15;
            ddl_TipoCausalIngreso.DataTextField = "Descripcion";
            ddl_TipoCausalIngreso.DataValueField = "CodTipoCausalIngreso";
            dv15.Sort = "Descripcion";
        }
        //getcausales();
    }

    private void getcausales()
    {
        parcoll par = new parcoll();

        DataView dv16 = new DataView(par.GetparCausalesIngreso(ddl_TipoCausalIngreso.SelectedValue,SSnino.CodProyecto));
        ddl_CausalIngreso.Items.Clear();
        ddl_CausalIngreso.DataSource = dv16;
        ddl_CausalIngreso.DataTextField = "Descripcion";
        ddl_CausalIngreso.DataValueField = "CodCausalIngreso";
        dv16.Sort = "Descripcion";
        ddl_CausalIngreso.DataBind();
    }


    protected void ddown007a_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(2);
        if (Convert.ToInt32(ddown007a.SelectedValue) > 0 || Convert.ToInt32(ddown007a.SelectedValue) == -1)
        {


            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddown007a.SelectedValue));
            ddown007.Items.Clear();
            ddown007.DataSource = dv6;
            ddown007.DataTextField = "Descripcion";
            ddown007.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddown007.DataBind();

            if (Convert.ToInt32(ddown007a.SelectedValue) == -1)
            {
                ddown007.SelectedValue = Convert.ToString(-1);
            }
        }


        else
        {
            ddown007.Items.Clear();
        }
    }

    protected void rdo001_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        Panel1.Visible = true;
        gettribunalesall();
        rdo_OrdenTribunal_SI.Checked = true;
        ddown017.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
    }
    protected void rdo002_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        Panel1.Visible = true;
        gettribunalesall();
        ddown017.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
    }

    protected void rdo003_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        Panel1.Visible = false;


    }

    public void gettribunalesall()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];
        parcoll par = new parcoll();


        DTordentribunales = new DataTable();

        DTordentribunales.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        DTordentribunales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("Fecha", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("Expediente", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("RUC", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("RIT", typeof(string)));

        DTordentribunales.Clear();
        grd001.Visible = false;

        ddown014.Items.Clear();
        //DataView dv13 = new DataView(par.GetparRegion());
        DataView dv13 = new DataView(ds.Tables["dtparRegion"]);
        ddown014.DataSource = dv13;
        ddown014.DataTextField = "Descripcion";
        ddown014.DataValueField = "CodRegion";
        dv13.Sort = "CodigoRegion ASC";
        ddown014.DataBind();



        bool swLrpa = FiltroLRPA();

        if (swLrpa)
        {
            LRPAcoll LRPA = new LRPAcoll();

            ddown015.Items.Clear();
            DataView dv14 = new DataView(LRPA.GetparTipoTribunalLRPA());
            ddown015.DataSource = dv14;
            ddown015.DataTextField = "Descripcion";
            ddown015.DataValueField = "TipoTribunal";
            dv14.Sort = "Descripcion";
            ddown015.DataBind();
        }
        else
        {
            ddown015.Items.Clear();
            DataView dv14 = new DataView(par.GetparTipoTribunal());
            ddown015.DataSource = dv14;
            ddown015.DataTextField = "Descripcion";
            ddown015.DataValueField = "TipoTribunal";
            dv14.Sort = "Descripcion";
            ddown015.DataBind();
        }

        WebTextEdit2.Text = "";
        txt006F2.Text = "";
        txt007F2.Text = "";
        ddown017.Text = "";
        gettribunales();
    }
    public void gettribunales()
    {
        parcoll par = new parcoll();

        DataView dv15 = new DataView(par.GetparTribunales(ddown014.SelectedValue, ddown015.SelectedValue));
        ddown016.Items.Clear();
        ddown016.DataSource = dv15;
        ddown016.DataTextField = "Descripcion";
        ddown016.DataValueField = "CodTribunal";
        dv15.Sort = "Descripcion";
        ddown016.DataBind();
    }
    protected void ddown015_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        gettribunales();

    }
    protected void ddown014_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        gettribunales();

    }
    protected void btn001_Click(object sender, EventArgs e)
    {
        muestra_pestaña(3);
        bool swLrpa = FiltroLRPA();
        bool filtroRepetido = false;

        tabla_OrdenTribunal.Visible = swLrpa;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            if (grd001.Rows[i].Cells[4].Text.Trim() == txt006F2.Text.Trim())
            {
                filtroRepetido = true;
            }
        }
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (ddown014.SelectedValue == "0" || ddown015.SelectedValue == "0" || ddown016.SelectedValue == "0")
        {
            if (ddown014.SelectedValue == "0")
            { ddown014.BackColor = colorCampoObligatorio; }
            else { ddown014.BackColor = System.Drawing.Color.Empty; }

            if (ddown015.SelectedValue == "0")
            { ddown015.BackColor = colorCampoObligatorio; }
            else { ddown015.BackColor = System.Drawing.Color.Empty; }

            if (ddown016.SelectedValue == "0")
            { ddown016.BackColor = colorCampoObligatorio; }
            else { ddown016.BackColor = System.Drawing.Color.Empty; }
        }
        else
        {
            if (DTProyecto.Rows.Count > 0)
            {               

                if (DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "81") // Valida si es prj 
                {
                    if (txt006F2.Text == "" || txt007F2.Text == "")  // exige el ruc y el rit
                    {
                        txt006F2.BackColor = colorCampoObligatorio;
                        txt007F2.BackColor = colorCampoObligatorio;
                        lbl_nota80.Text = "Los campos RUC y RIT son requeridos.";
                        informacion_80BIS.Visible = true;
                    }
                    else if (utabgetvalue(ddl_CalidadJuridica) == 28 && WebTextEdit2.Text == "")
                    {
                        lbl_nota80.Text = "Todos los campos son requeridos.";
                        informacion_80BIS.Visible = true;
                        WebTextEdit2.BackColor = colorCampoObligatorio;
                    }
                    else
                    {
                        txt006F2.BackColor = System.Drawing.Color.Empty;
                        txt007F2.BackColor = System.Drawing.Color.Empty;
                        WebTextEdit2.BackColor = System.Drawing.Color.Empty;
                        informacion_80BIS.Visible = false;

                        AgregaOrdenTribunal(swLrpa, filtroRepetido);
                    }
                }
                else
                {
                    if (utabgetvalue(ddl_CalidadJuridica) == 28 && (WebTextEdit2.Text == "" && txt007F2.Text == ""))  // valida el expendiente o el RUC si la calidad juridica se encuentra en 80 bis
                    {
                        WebTextEdit2.BackColor = colorCampoObligatorio;
                        txt007F2.BackColor = colorCampoObligatorio;
                        lbl_nota80.Text = "Solo uno de los dos campos son requeridos (Expendiente o RIT).";
                        informacion_80BIS.Visible = true;
                    }
                    else
                    {
                        txt006F2.BackColor = System.Drawing.Color.Empty;
                        txt007F2.BackColor = System.Drawing.Color.Empty;
                        WebTextEdit2.BackColor = System.Drawing.Color.Empty;
                        informacion_80BIS.Visible = false;

                        AgregaOrdenTribunal(swLrpa, filtroRepetido);
                    }
                }

            }
        }

        chequea_OT();

    }

    private void AgregaOrdenTribunal(bool swLrpa, bool filtroRepetido)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        informacion_80BIS.Visible = false;

        WebTextEdit2.BackColor = System.Drawing.Color.Empty;
        txt007F2.BackColor = System.Drawing.Color.Empty;

        if (!filtroRepetido)
        {
            DataRow dr = DTordentribunales.NewRow();

            dr[0] = Convert.ToInt32(ddown016.SelectedValue);
            dr[1] = ddown016.SelectedItem.Text;

            if (ddown017.Text != null)
            {
                if (ddown017.Text.ToString() != "")
                {
                    dr[2] = ddown017.Text.ToString();
                }
                else
                {
                    dr[2] = DateTime.Now.ToShortDateString();
                }
            }
            else
            {
                dr[2] = DateTime.Now.ToShortDateString();
            }
            dr[3] = WebTextEdit2.Text;
            dr[4] = txt006F2.Text;
            dr[5] = txt007F2.Text;

            if (swLrpa)
            {
                if (txt006F2.Text.Trim() != "")
                {

                    DTordentribunales.Rows.Add(dr);
                    DataView dv = new DataView(DTordentribunales);
                    grd001.DataSource = dv;
                    grd001.DataBind();
                    grd001.Visible = true;

                    rdo_OrdenTribunal_SI.Enabled = false;
                    rdo_OrdenTribunal_EnTramite.Enabled = false;
                    rdo_OrdenTribunal_NO.Enabled = false;

                    ListItem oItem = new ListItem("(" + txt006F2.Text + ")" + "-" + ddown016.SelectedItem.Text, txt006F2.Text.Trim());
                    ddown_otc.Items.Add(oItem);
                    ddl_OrdenDeTribunal_MedidaSancion.Items.Add(oItem);


                    ddl_OrdenDeTribunal_MedidaSancion.Visible = true;
                    tabla_OrdenTribunal.Visible = true;



                    //agrega nuevamente la ruta hacia el tab correspondiente para desplegar los dos tab
                    link_tab4.Attributes.Add("data-toggle", "tab");
                    link_tab6.Attributes.Add("data-toggle", "tab");
                    //gfontbrevis: vuelve al estilo original
                    link_tab4.Attributes.Remove("class");
                    link_tab6.Attributes.Remove("class");
                    ViewState["bloqueo_ley_pestañas"] = ""; // recuerda pestañas desbloqueadas

                    lbl_otm.Visible = true;

                    txt006F2.BackColor = System.Drawing.Color.Empty;

                    WebTextEdit2.Text = "";
                    txt006F2.Text = "";
                    txt007F2.Text = "";
                    ddown014.SelectedIndex = -1;
                    ddown016.SelectedIndex = -1;
                    ddown015.SelectedIndex = -1;
                    ddown017.Text = "";
                    txt006F2.BackColor = System.Drawing.Color.Empty;
                }
                else
                {
                    txt006F2.BackColor = colorCampoObligatorio;
                }
            }
            else
            {
                tabla_OrdenTribunal.Visible = false;


                DTordentribunales.Rows.Add(dr);
                DataView dv = new DataView(DTordentribunales);
                grd001.DataSource = dv;
                grd001.DataBind();
                grd001.Visible = true;

                //rdo002.Enabled = false;
                rdo_OrdenTribunal_SI.Enabled = false;
                rdo_OrdenTribunal_EnTramite.Enabled = false;
                rdo_OrdenTribunal_NO.Enabled = false;



                WebTextEdit2.Text = "";
                txt006F2.Text = "";
                txt007F2.Text = "";
                ddown014.SelectedIndex = -1;
                ddown016.SelectedIndex = -1;
                ddown015.SelectedIndex = -1;
                ddown017.Text = "";
                txt006F2.BackColor = System.Drawing.Color.Empty;
            }


        }
        else
        {
            txt006F2.BackColor = colorCampoObligatorio;

        }
    }

    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(3);

        bool swLrpa = FiltroLRPA();

        if (swLrpa)
        {
            bool existe = false;

            for (int i = 0; i < grd002.Rows.Count; i++)
            {
                if (DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)][4].ToString().Trim() == grd002.Rows[i].Cells[6].Text.Trim())
                {
                    existe = true;
                }
            }
            if (existe)
            {
                lbl_mensajeOT.Text = "Error, primero debe eliminar la Causal de Ingreso que esta relacionada con la Orden de Tribunal que desea quitar";
                lbl_mensajeOT.Visible = true;
            }
            else
            {
                DTordentribunales.Rows.Remove(DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)]);
                DataView dv = new DataView(DTordentribunales);
                grd001.DataSource = dv;
                grd001.DataBind();
                grd001.Visible = true;
                //if (tgrd001.Rows.Count == 0)
                //{
                //    trdo002.Enabled = true;
                //    trdo003.Enabled = true;
                //}

                #region elimina_ddownOT

                ddown_otc.Items.Clear();
                ddl_OrdenDeTribunal_MedidaSancion.Items.Clear();

                DataTable dt = DTordentribunales;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][1] = "(" + dt.Rows[i][4].ToString() + ") - " + dt.Rows[i][1].ToString();
                }

                //DataRow dr;
                //dr = dt.NewRow();
                //dr[4] = 0;
                //dr[1] = " Seleccionar ";
                //dt.Rows.Add(dr);

                ddown_otc.DataSource = dt;
                ddown_otc.DataTextField = "Descripcion";
                ddown_otc.DataValueField = "Ruc";
                ddown_otc.DataBind();

                ddl_OrdenDeTribunal_MedidaSancion.DataSource = dt;
                ddl_OrdenDeTribunal_MedidaSancion.DataTextField = "Descripcion";
                ddl_OrdenDeTribunal_MedidaSancion.DataValueField = "Ruc";
                ddl_OrdenDeTribunal_MedidaSancion.DataBind();

                //tddown_otc.SelectedValue = "0";
                //tddown_otm.SelectedValue = "0";
                #endregion
                lbl_mensajeOT.Visible = false;

            }

        }
        else
        {
            DTordentribunales.Rows.Remove(DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)]);
            DataView dv = new DataView(DTordentribunales);
            grd001.DataSource = dv;
            grd001.DataBind();
            grd001.Visible = true;
            if (grd001.Rows.Count == 0)
            {
                if (utabgetvalue(ddl_CalidadJuridica) == 28)  // si la calidad juridica se encuentra en 80 bis
                {
                    rdo_OrdenTribunal_SI.Enabled = false;
                    rdo_OrdenTribunal_EnTramite.Enabled = false;
                    rdo_OrdenTribunal_NO.Enabled = false;

                    rdo_OrdenTribunal_SI.Checked = true;
                    rdo_OrdenTribunal_EnTramite.Checked = false;
                    rdo_OrdenTribunal_NO.Checked = false;

                }
                else
                {
                    rdo_OrdenTribunal_SI.Enabled = true;
                    rdo_OrdenTribunal_SI.Enabled = true;
                    rdo_OrdenTribunal_NO.Enabled = true;
                }
            }

        }

        chequea_OT();
    }

    protected void rdo004_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(5);
        getlesionesall();
        pnl002.Visible = true;
        rdo004.Checked = true;

    }

    protected void rdo005_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(5);
        pnl002.Visible = false;

    }

    public void getlesionesall()
    {


        DTlesiones = new DataTable();

        DTlesiones.Columns.Add(new DataColumn("TipoLesiones", typeof(int)));
        DTlesiones.Columns.Add(new DataColumn("CodQuienOcasionaLesion", typeof(int)));
        DTlesiones.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
        DTlesiones.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTlesiones.Columns.Add(new DataColumn("observaciones", typeof(string)));
        DTlesiones.Columns.Add(new DataColumn("InformeFiscalia", typeof(int)));

        DTlesiones.Clear();

        grd003.Visible = false;

        parcoll par = new parcoll();

        DataView dv16 = new DataView(par.GetparTipoLesiones());
        ddown021.DataSource = dv16;
        ddown021.DataTextField = "Descripcion";
        ddown021.DataValueField = "TipoLesiones";
        ddown021.DataBind();
        ddown021.AppendDataBoundItems = false;
        ddown021.Items.Insert(0, new ListItem("Seleccione", "0"));
        dv16.Sort = "Descripcion";
        ddown021.SelectedIndex = 0;

        DataView dv17 = new DataView(par.GetparQuienOcasionaLesion());
        ddown022.DataSource = dv17;
        ddown022.DataTextField = "Descripcion";
        ddown022.DataValueField = "CodQuienOcasionaLesion";
        ddown022.DataBind();
        ddown022.AppendDataBoundItems = false;
        ddown022.Items.Insert(0, new ListItem("Seleccione", "0"));
        dv17.Sort = "Descripcion";
        ddown022.SelectedIndex = 0;







        bool swLrpa = FiltroLRPA();

        if (swLrpa == true)
        {
            chk001Fiscalia_RPA.Enabled = true;
            tbl_informa_fiscalia.Visible = true;
        }
        else
        {
            chk001Fiscalia_RPA.Enabled = false;
            tbl_informa_fiscalia.Visible = false;
        }

        //limpia para una nueva carga 


    }

    protected void btn003_Click(object sender, EventArgs e)
    {
        muestra_pestaña(5);



        bool sw = FiltroLRPA();
        bool chk = true;
        ///// VALIDADOR /////////
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (!sw)
        {
            if (ddown021.SelectedValue == "0" || ddown022.SelectedValue == "0")
            {
                if (ddown021.SelectedValue == "0")
                {
                    ddown021.BackColor = colorCampoObligatorio;
                    chk = false;
                }
                else
                {
                    ddown021.BackColor = System.Drawing.Color.Empty;
                }

                if (ddown022.SelectedValue == "0")
                {
                    ddown022.BackColor = colorCampoObligatorio;
                    chk = false;
                }
                else
                {
                    ddown022.BackColor = System.Drawing.Color.Empty;
                }
            }
        }
        else
        {

            if (ddown021.SelectedValue == "0")
            {
                ddown021.BackColor = colorCampoObligatorio;
                chk = false;
            }
            else
            {
                ddown021.BackColor = System.Drawing.Color.Empty;
            }



        }

        if (chk)
        {
            DataRow dr = DTlesiones.NewRow();
            dr[0] = Convert.ToInt32(ddown021.SelectedValue);
            dr[1] = Convert.ToInt32(ddown022.SelectedValue);
            dr[2] = ddown021.SelectedItem.Text;
            dr[3] = ddown022.SelectedItem.Text;
            dr[4] = txt007.Text;
            dr[5] = Convert.ToInt32(chk001Fiscalia_RPA.Checked);



            DTlesiones.Rows.Add(dr);
            DataView dv = new DataView(DTlesiones);
            grd003.DataSource = dv;
            grd003.DataBind();

            if (ddown022.SelectedValue == "0")
            {
                grd003.Columns[3].Visible = false;

            }
            else
            {
                grd003.Columns[3].Visible = true;
            }

            grd003.Visible = true;


            ddown021.SelectedIndex = 0;
            ddown022.SelectedIndex = 0;
            txt007.Text = "";
            chk001Fiscalia_RPA.Checked = false;

            ddown021.BackColor = System.Drawing.Color.Empty;
            ddown022.BackColor = System.Drawing.Color.Empty;
            rdo004.Enabled = false;
            rdo005.Enabled = false;
        }
    }
    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        muestra_pestaña(5);
        DTlesiones.Rows.Remove(DTlesiones.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTlesiones);
        grd003.DataSource = dv;
        grd003.DataBind();
        grd003.Visible = true;
        rdo004.Enabled = true;
        rdo005.Enabled = true;
    }
    protected void utab_nino_DataBinding(object sender, EventArgs e)
    {
        //        
        // AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        // trigger.ControlID = ddown004.UniqueID;
        // // trigger.EventName = "Click";
        // UpdatePanel7.Triggers.Add(trigger);

        proyectocoll proyectoc = new proyectocoll();
        DTProyecto = proyectoc.GetProyectos(ddl_Proyecto.SelectedValue.ToString());
       

        ninocoll ncoll = new ninocoll();
        nino n = null;
        if (Session["ICodIngresoLE"] == null)
        {
            n = ncoll.GetData(SSnino.CodNino.ToString(), "0");
        }
        else
        {
            n = ncoll.GetData(SSnino.CodNino.ToString(), "0", Convert.ToString(Session["ICodIngresoLE"]));

            if (n.RUC != null && n.RUC != string.Empty)
            {
                try
                {
                    RadioButton t_rdo001 = new RadioButton();

                    t_rdo001.Checked = true;


                    gettribunalesall();

                    DropDownList t_ddown014 = new DropDownList();

                    t_ddown014.SelectedValue = n.CodRegion.ToString();
                    gettribunales();

                    DropDownList t_ddown015 = new DropDownList();

                    t_ddown015.SelectedValue = n.Tipo_Tribunal.ToString();
                    gettribunales();

                    TextBox t_txt006F2 = new TextBox();

                    t_txt006F2.Text = n.RUC.ToString();

                    TextBox t_txt007F2 = new TextBox();

                    t_txt007F2.Text = n.RIT.ToString();

                    TextBox t_ddown017 = new TextBox();

                    t_ddown017.Text = n.FechaOrden.ToLongDateString();

                    DropDownList t_ddown016 = new DropDownList();

                    t_ddown016.SelectedValue = n.Tribunal.ToString();


                }
                catch (Exception ex)
                {

                }
            }
            else
            {

                try
                {
                    RadioButton t_rdo003 = new RadioButton();

                    t_rdo003.Checked = true;
                    gettribunalesall();
                }
                catch (Exception ex)
                {

                }
            }




        }
        txt001.Text = n.rut.ToString().ToUpper();
        txt002.Text = n.CodNino.ToString().ToUpper();
        txt003.Text = n.Apellido_Paterno.ToUpper();
        txt004.Text = n.Apellido_Materno.ToUpper();
        txt005.Text = n.Nombres.ToUpper();
        lbl004.Text = n.FechaNacimiento.ToShortDateString();

        if (n.sexo == "F")
        {
            rdo_Sexo_F.Checked = true;
        }
        else
        {
            rdo_Sexo_M.Checked = true;
        }
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);

        txt001.ReadOnly = true;
        txt002.ReadOnly = true;
        txt003.ReadOnly = true;
        txt004.ReadOnly = true;
        txt005.ReadOnly = true;

        rdo_Sexo_F.Enabled = false;
        rdo_Sexo_M.Enabled = false;

        ddl_Institucion.Enabled = false;
        ddl_Proyecto.Enabled = false;

        restart_utab();
        getdefaultdata();
        btnsearch.Attributes.Add("disabled", "disabled"); 
        titulo_datos_nino.Visible = true;
        imb_lupaproyecto.Attributes.Add("disabled", "disabled");// gfontbrevis
        imb_lupainstitucion.Attributes.Add("disabled", "disabled");// gfontbrevis
        //gfontbrevis: ocultar bloque informacion y busqueda avanzada.
        panelInfoBusqueda.Visible = false;
        mostrar_collapse(false);
        SpanCollapse.Attributes.Add("Class", "glyphicon glyphicon-triangle-bottom");
        lbl_acordeon.Text = "Mostrar Búsqueda Avanzada";
        //gfontbrevis: mostrar resumen de busqueda
        resumenBusqueda.Text = "Resumen Búsqueda: "+ txt002.Text + " " + txt003.Text + " " + txt004.Text + " " + txt005.Text;
        resumenBusqueda.Visible = true;

        ////comienzo del filto para LRPA
        bool swLrpa = FiltroLRPA();
        if (!swLrpa)
        {//false

            //oculta en link hacia el tab6
            link_tab6.Attributes.Add("style", "display: none");
            //li_nav6.Attributes.Add("style", "display: none");//gfontbrevis li_nav6 tambien oculto para ocupar ancho completo

        }
        else
        {//true            

            //li_nav6.Attributes.Add("style", "display: block"); // despues de ingresar un niño con un proyecto en la ley hay q volver a mostrar el tab
            link_tab6.Attributes.Add("style", "display: block");

            lbl_nota1.Text = "Debe agregar de 1 a 10 causales de Ingreso.";
            bool res = false;
            res = FiltroReescolarizacion();

            if (res)
            {

                //utab.Tabs[2].Visible = false;
                //utab.Tabs[3].Visible = false;
                //utab.Tabs[4].Visible = false;
                //utab.Tabs[5].Visible = false;

                //oculta los links de los tab siguientes
                //link_tab2.Attributes.Add("style", "display: none");
                //link_tab3.Attributes.Add("style", "display: none");
                //link_tab4.Attributes.Add("style", "display: none");
                //link_tab5.Attributes.Add("style", "display: none");
                //gfontbrevis: TODO: hacer que tabs tengan hover disabled


                // se modifica para solo mostrar las pestañas 1 y 2
                
                link_tab3.Attributes.Add("style", "display: none");
                link_tab4.Attributes.Add("style", "display: none");
                link_tab5.Attributes.Add("style", "display: none");
                link_tab6.Attributes.Add("style", "display: none");
                //btnnext002.Visible = false;
                btnsaveingreso3.Visible = true;

            }
            else
            {


                rdo_OrdenTribunal_SI.Checked = true;
                rdo_OrdenTribunal_SI.Enabled = true;
                rdo_OrdenTribunal_EnTramite.Enabled = false;
                rdo_OrdenTribunal_NO.Enabled = false;

                tbl_orden_tribunal.Visible = false;
                rdo001_CheckedChanged(sender, e);

                //t3.Enabled = false;
                //t5.Enabled = false;
                //t5.Visible = true;

                //remueve el data-toggle para dejar bloqueado el link hacia el tab
                link_tab4.Attributes.Remove("data-toggle");
                link_tab6.Attributes.Remove("data-toggle");
                //gfontbrevis: pestañas deshabilitadas
                link_tab4.Attributes.Add("class", "disabled-nav-tabs");
                link_tab6.Attributes.Add("class", "disabled-nav-tabs");


                link_tab5.Attributes.Add("style", "display: block");
                ViewState["bloqueo_ley_pestañas"] = "1";


                gettribunalesall();
            }
            // vtab5 = true;


            LRPAcoll lrpa = new LRPAcoll();
            int cta = lrpa.Get_LRPAModeloIntervencion(SSnino.CodProyecto);
            if (cta > 0)
            {


                //t5.Visible = false;//controlado

                link_tab5.Attributes.Add("style", "display: none");
                btn_ingresoNinoModEX.Visible = true;
                btn_ingresoNinoModEX.Enabled = false;
                lblOT_Ingreso.Visible = true;
                //btnnext005.Visible = false;
            }
            int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
            LRPAcoll codmod = new LRPAcoll();
            DataTable dt2 = codmod.GetCodModIntervencion(codproy);
            int codemod = Convert.ToInt32(dt2.Rows[0][0]);
            if (codemod == 102 || codemod == 100)///////cambiar
            {
                //utab.Tabs[5].Visible = true;

                link_tab5.Attributes.Add("style", "display: block");
            }



        }
        if (Session["ICodIngresoLE"] != null)
        {
            try
            {
                DropDownList t_ddown018 = new DropDownList();

                t_ddown018.SelectedValue = n.CodTipoCausalIngreso.ToString();

                getparcausales(Convert.ToInt32(n.CodTipoCausalIngreso));

                DropDownList t_ddown019 = new DropDownList();

                t_ddown019.SelectedValue = n.CodCausal.ToString();

                TextBox T_txt006 = new TextBox();

                T_txt006.Text = n.CodNumCausal.ToString();
            }
            catch (Exception ex)
            {

            }
            txt_ICodIngresoLE.Text = Convert.ToString(Session["ICodIngresoLE"]);
            Session["ICodIngresoLE"] = null;
        }

        if (DTProyecto.Rows.Count > 0)
        {
            if (DTProyecto.Rows[0]["TipoProyecto"].ToString() == "7" || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "92" || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "142"
                || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "81")
            {
                rdo_OrdenTribunal_SI.Checked = true;
                rdo_OrdenTribunal_SI.Enabled = true;
                tbl_orden_tribunal.Visible = false;
                rdo001_CheckedChanged(sender, e);
            }
        }

        muestra_pestaña(1);
    }
    private void chequea_OT()
    {

        if (FiltroLRPA())
        {



            if (grd001.Rows.Count > 0)
            {

                //t3.Enabled = true;
                //t5.Enabled = true;


                link_tab3.Attributes.Add("data-toggle", "tab");
                link_tab5.Attributes.Add("data-toggle", "tab");
                link_tab3.Attributes.Remove("Class");
                link_tab5.Attributes.Remove("Class");


                lblOT_Ingreso.Visible = false;
                btn_ingresoNinoModEX.Enabled = true;
            }
            else
            {
                //t3.Enabled = false;
                //t5.Enabled = false;



                link_tab3.Attributes.Remove("data-toggle");
                link_tab5.Attributes.Remove("data-toggle");
                //gfontbrevis mostrar tipo disabled
                link_tab3.Attributes.Add("class", "disabled-nav-tabs");
                link_tab3.Attributes.Add("class", "disabled-nav-tabs");


                lblOT_Ingreso.Visible = true;
                btn_ingresoNinoModEX.Enabled = false;
            }

        }
    }

    //protected void btnnext(object sender, EventArgs e)
    //{
    //    chequea_OT();

    //    validatedata(utab.ActiveTabIndex, false);
    //    utab.ActiveTabIndex += 1;
    //}
    //protected void btnback(object sender, EventArgs e)
    //{
    //    utab.ActiveTabIndex -= 1;
    //}

    private bool validarTab1()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        bool vtab1 = false;

        if (txt_FechaIngreso.Text == "")
        {
            txt_FechaIngreso.BackColor = colorCampoObligatorio;
            vtab1 = true;
        }
        else
        {
            txt_FechaIngreso.BackColor = System.Drawing.Color.Empty;
        }


        if (ddl_Inmueble.SelectedValue == null || ddl_Inmueble.SelectedValue == "0")
        {
            ddl_Inmueble.BackColor = colorCampoObligatorio;
            vtab1 = true;
        }
        else
        {
            ddl_Inmueble.BackColor = System.Drawing.Color.Empty;
        }

        if (ddl_TipoAtencion.SelectedValue == Convert.ToString('0') || ddl_TipoAtencion.SelectedValue == null)
        {
            ddl_TipoAtencion.BackColor = colorCampoObligatorio;
            vtab1 = true;
        }
        else
        {
            ddl_TipoAtencion.BackColor = System.Drawing.Color.Empty;
        }

        if (!validamescerrado())
        {
            vtab1 = true;
        }
        return vtab1;
    }

    private bool validatedata2(int tabindex, bool full)
    {

        //   validacion de datos obligatorios en tabs
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        bool fullbool = false;
        bool vtab1 = false;
        bool vtab2 = false;
        bool vtab3 = false;
        bool vtab4 = false;
        bool vtab5 = false;
        val5 = false;
        valgr = false;

        //primer tabs
        if (tabindex == 0 || full)
        {
            vtab1 = validarTab1();
        }

        // segundo tabs
        if (tabindex == 1 || full)
        {

            bool vtab2_1 = validateddownutab(ddl_CalidadJuridica);
            bool vtab2_2 = validateddownutab(ddl_Escolaridad);
            bool vtab2_3 = validateddownutab(ddl_TipoAsistenciaEscolar);
            bool vtab2_4 = validateddownutab(ddown007a);
            bool vtab2_5 = validateddownutab(ddown007);
            bool vtab2_6 = validateddownutab(ddl_Entrevistador);
            bool vtab2_7 = validateddownutab(ddl_TipoSolicitanteIngreso);
            bool vtab2_8 = validateddownutab(ddown013);


            if (vtab2_1 || vtab2_2 || vtab2_3 || vtab2_4 || vtab2_5 || vtab2_6 || vtab2_7 || vtab2_8)
            {
                vtab2 = true;
                //utab.Tabs[1].ForeColor = System.Drawing.Color.Red;
                //pnl_utab2.ForeColor = System.Drawing.Color.Red;

                link_tab2.Attributes.Add("Class", "pestana-roja");

            }
            else
            {
                vtab2 = false;
                //utab.Tabs[1].ForeColor = System.Drawing.Color.Black;
                pnl_utab2.ForeColor = System.Drawing.Color.Black;
                link_tab2.Attributes.Remove("Class");

            }

        }
        // tercer tabs
        if (tabindex == 2 || full)
        {


            if (!validate_rdo_utab(rdo_OrdenTribunal_SI, false) && !validate_rdo_utab(rdo_OrdenTribunal_EnTramite, false) && !validate_rdo_utab(rdo_OrdenTribunal_NO, false))
            {

                rdo_OrdenTribunal_SI.BackColor = colorCampoObligatorio;
                rdo_OrdenTribunal_EnTramite.BackColor = colorCampoObligatorio;
                rdo_OrdenTribunal_NO.BackColor = colorCampoObligatorio;
                //utab.Tabs[2].ForeColor = System.Drawing.Color.Red;
                pnl_rdo_orden_tribunal.ForeColor = System.Drawing.Color.Red;
                link_tab3.Attributes.Add("Class", "pestana-roja");

                vtab3 = true;
            }
            else
            {
                rdo_OrdenTribunal_SI.BackColor = System.Drawing.Color.Transparent;
                rdo_OrdenTribunal_EnTramite.BackColor = System.Drawing.Color.Transparent;
                rdo_OrdenTribunal_NO.BackColor = System.Drawing.Color.Transparent;
                //utab.Tabs[2].ForeColor = System.Drawing.Color.Black;
                pnl_rdo_orden_tribunal.ForeColor = System.Drawing.Color.Black;
                link_tab3.Attributes.Remove("Class");
                vtab3 = false;
            }
            if (rdo_OrdenTribunal_SI.Checked && grd001.Rows.Count == 0)
            {
                //utab.Tabs[2].ForeColor = System.Drawing.Color.Red;
                pnl_rdo_orden_tribunal.ForeColor = System.Drawing.Color.Red;
                link_tab3.Attributes.Add("Class", "pestana-roja");
                vtab3 = false;

            }

        }

        // cuarto tabs
        if (tabindex == 3 || full)
        {

            if (FiltroLRPA())
            {


                if (grd002.Rows.Count > 0 && grd002.Rows.Count < 11)
                {
                    vtab4 = false;
                    //utab.Tabs[3].ForeColor = System.Drawing.Color.Black;
                    pnl_utab4.ForeColor = System.Drawing.Color.Black;
                    link_tab4.Attributes.Remove("Class");
                }
                else
                {
                    vtab4 = true;
                    //utab.Tabs[3].ForeColor = System.Drawing.Color.Red;
                    //pnl_utab4.ForeColor = System.Drawing.Color.Red;
                    link_tab4.Attributes.Add("Class", "pestana-roja");
                }
            }
            else
            {

                if (grd002.Rows.Count > 0 && grd002.Rows.Count < 4)
                {
                    vtab4 = false;
                    //utab.Tabs[3].ForeColor = System.Drawing.Color.Black;
                    pnl_utab4.ForeColor = System.Drawing.Color.Black;
                    link_tab4.Attributes.Remove("Class");
                }
                else
                {
                    vtab4 = true;
                    //utab.Tabs[3].ForeColor = System.Drawing.Color.Red;
                    //pnl_utab4.ForeColor = System.Drawing.Color.Red;
                    link_tab4.Attributes.Add("Class", "pestana-roja");
                }

            }
        }
        if (tabindex == 5 || full)
        {
            int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
            LRPAcoll codmod = new LRPAcoll();
            DataTable dt2 = codmod.GetCodModIntervencion(codproy);
            int codemod = Convert.ToInt32(dt2.Rows[0][0]);

            if ((codemod != 100) & (codemod != 102) || (opc == true))
            {
                #region validacion LRPA
                ///////////////////////

                ///////////////////////

                #region LRPA_Mixta
                if (Chk002LRPAMixta.Checked == true)
                {
                    if (ddown011LRPA.SelectedValue == "-1")
                    {
                        ddown011LRPA.BackColor = colorCampoObligatorio;
                        vtab5 = false;
                    }
                    else
                    {
                        ddown011LRPA.BackColor = System.Drawing.Color.Empty;
                    }

                    if (txt004LRPA.Text == "")
                    {
                        txt004LRPA.BackColor = colorCampoObligatorio;
                        vtab5 = false;
                    }
                    else
                    {
                        txt004LRPA.BackColor = System.Drawing.Color.Empty;
                    }

                    if (txt006LRPA.Text == "")
                    {
                        txt006LRPA.BackColor = colorCampoObligatorio;
                        vtab5 = false;
                    }
                    else
                    {
                        txt006LRPA.BackColor = System.Drawing.Color.Empty;
                    }

                    if (ddown009LRPA.Text.ToUpper() == "")
                    {
                        ddown009LRPA.BackColor = colorCampoObligatorio;
                        vtab5 = false;
                    }
                    else
                    {
                        ddown009LRPA.BackColor = System.Drawing.Color.Empty;
                    }

                }
                #endregion


                ninocoll nin = new ninocoll();
                int codmodelo = nin.callto_get_codmodelointervencion(SSnino.CodProyecto);
                bool chk = false;

                /////////////////////////VALIDACIONES PARA HORAS DE SERVICIO COMUNITARIO (108)//////////////

                ////////FIN VALIDACION (103)/////////////////////////////////////////////////////////////////////////

                if (ddl_CalidadJuridica.SelectedValue == "5")
                {
                    if (txt003LRPA.Text != "" && codmodelo == 103)
                    {
                        if (txt001LRPA.Text.Trim() != "" || txt002LRPA.Text.Trim() != "" || txt007LRPA.Text.Trim() != "" || txt_FechaInicioSancionLRPA.Text != "" ||
                    ddown003LRPA.SelectedValue != Convert.ToString(-2) || ddown004LRPA.SelectedValue != Convert.ToString(0) ||
                    ddown005LRPA.SelectedValue != Convert.ToString(0) || chk001LRPA.Checked == true || ddl_OrdenDeTribunal_MedidaSancion.SelectedValue != "0")
                        {
                            chk = true;
                        }
                        else
                        {

                            chk = false;
                            txt007LRPA.Text = "0";
                            txt001LRPA.Text = "0";
                            txt002LRPA.Text = "0";
                            txt_FechaInicioSancionLRPA.Text = Convert.ToString("01-01-1900");
                            txt003LRPA.Text = "01-01-1900";
                        }
                    }
                    else
                    {
                        chk = true;
                    }
                }
                else
                {

                    if (txt001LRPA.Text.Trim() != "" ||
                        txt002LRPA.Text.Trim() != "" ||
                        txt007LRPA.Text.Trim() != "" ||
                        txt_FechaInicioSancionLRPA.Text != "" ||
                        ddown003LRPA.SelectedValue != Convert.ToString(-2) ||
                        ddown004LRPA.SelectedValue != Convert.ToString(0) ||
                        ddown005LRPA.SelectedValue != Convert.ToString(0) ||
                        chk001LRPA.Checked == true ||
                        ddl_OrdenDeTribunal_MedidaSancion.SelectedValue != "0")
                    {
                        chk = true;
                    }
                    else
                    {
                        chk = false;
                    }

                }

                if (chk)
                {
                    //////////primer
                    if (codemod == 108)
                    {

                        if (txt_hservi.Text == "")//|| txt_hservi.Text == "0")///horas
                        {
                            txt_hservi.BackColor = colorCampoObligatorio;
                            vtab5 = true;

                        }
                        else
                        {
                            txt_hservi.BackColor = System.Drawing.Color.Empty;

                        }



                        if (ddown_tipoBC.SelectedValue == "0")///Area Trabajo
                        {
                            ddown_tipoBC.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown_tipoBC.BackColor = System.Drawing.Color.Empty;

                        }

                        if (grd_LRPA02.Rows.Count == 0)///Area Trabajo
                        {

                            ddown_conIng.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown_conIng.BackColor = System.Drawing.Color.Empty;

                        }
                        if (ddown_tsancion.SelectedValue == "0")///Area Trabajo
                        {
                            ddown_tsancion.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown_tsancion.BackColor = System.Drawing.Color.Empty;

                        }
                    }

                    ////////FIN VALIDACION (108)/////////////////////////////////////////////////////////////////////////
                    ////////VALIDACION (103)/////////////////////////////////////////////////////////////////////////////
                    if (codemod == 103)
                    {
                        if (ddown_tsancion.SelectedValue == "0")///Area Trabajo
                        {
                            ddown_tsancion.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown_tsancion.BackColor = System.Drawing.Color.Empty;

                        }
                        if (ddown_tipoBC.SelectedValue == "0")///Area Trabajo
                        {
                            ddown_tipoBC.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown_tipoBC.BackColor = System.Drawing.Color.Empty;

                        }

                        if (ddown_tsancion.SelectedValue == "1")
                        {
                            if (txt_hservi.Text == "" || txt_hservi.Text == "0")  ///Area Trabajo
                            {
                                txt_hservi.BackColor = colorCampoObligatorio;
                                vtab5 = true;
                            }
                            else
                            {
                                txt_hservi.BackColor = System.Drawing.Color.Empty;

                            }
                        }
                        else
                        {
                            txt_hservi.Text = "";
                        }

                    }

                    if (codemod == 108)//////aqui////
                    {

                        DataRow dr = dt_coning.NewRow();

                        if (grd_LRPA02.Rows.Count != 0)
                        {
                            grd_val = false;
                            for (int i = 0; i < grd_LRPA02.Rows.Count; i++)
                            {

                                if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(8))
                                { grd_val = true; }
                                if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(4))
                                { grd_val = true; }
                                if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(3))
                                { grd_val = true; }

                            }


                            if (grd_val == false)
                            {
                                ddown_conIng.BackColor = colorCampoObligatorio;
                                lbl_mensaje003.Visible = true;
                                lbl_mensaje003.Text = "Debe Ingresar a lo menos una de las siguientes opciones (C, D, H)";
                                vtab5 = true;

                            }
                            else
                            {
                                ddown_conIng.BackColor = System.Drawing.Color.Empty;
                                lbl_mensaje003.Visible = false;
                            }
                        }
                        else
                        {
                            ddown_conIng.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }


                    }
                    //////////////fin
                    //if ((codmodelo == 108) || (codmodelo ==103))
                    if ((codmodelo != 108) & (codmodelo != 103))
                    {
                        if (txt007LRPA.Text.Trim() == "")
                        {
                            txt007LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            txt007LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue == "0")
                        {
                            ddl_OrdenDeTribunal_MedidaSancion.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddl_OrdenDeTribunal_MedidaSancion.BackColor = System.Drawing.Color.Empty;
                        }
                        if (txt001LRPA.Text.Trim() == "")
                        {
                            txt001LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            txt001LRPA.BackColor = System.Drawing.Color.Empty;
                        }

                        if (txt002LRPA.Text.Trim() == "")
                        {
                            txt002LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            txt002LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        if (ddown003LRPA.SelectedValue == Convert.ToString(0))
                        {
                            ddown003LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown003LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        if (ddown004LRPA.SelectedValue == Convert.ToString(0))
                        {
                            ddown004LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown004LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        if (ddown005LRPA.SelectedValue == Convert.ToString(0))
                        {
                            ddown005LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown005LRPA.BackColor = System.Drawing.Color.Empty;
                        }

                    }
                    else
                    {
                        //ttxt003LRPA.Text = "01-01-1900";
                        //ttxt007LRPA.Text = "0";
                        //ttxt001LRPA.Text = "0";
                        //ttxt002LRPA.Text = "0";
                    }
                    if (txt_FechaInicioSancionLRPA.Text.Trim() == "")
                    {
                        txt_FechaInicioSancionLRPA.BackColor = colorCampoObligatorio;
                        vtab5 = true;
                    }
                    else
                    {
                        txt_FechaInicioSancionLRPA.BackColor = System.Drawing.Color.Empty;
                    }


                    if (chk001LRPA.Checked == true && DTTipoSancionAccesoria.Rows.Count == 0)
                    {
                        if (ddown006LRPA.SelectedValue == Convert.ToString(0))
                        {
                            ddown006LRPA.BackColor = colorCampoObligatorio;
                            vtab5 = true;
                        }
                        else
                        {
                            ddown006LRPA.BackColor = System.Drawing.Color.Empty;
                        }

                        try
                        {
                            if (DTTipoSancionAccesoria.Rows.Count >= 0)
                            {
                                lbl_avisoLRPA.Text = "";

                            }
                            else
                            {
                                if (chk001LRPA.Checked == true)
                                {

                                    lbl_avisoLRPA.Text = "Debe ingresar una sanción accesoria";
                                    lbl_avisoLRPA.Visible = true;
                                    vtab5 = true;
                                }
                                else
                                {
                                    lbl_avisoLRPA.Text = "";
                                    lbl_avisoLRPA.Visible = false;
                                }
                            }
                        }
                        catch
                        {
                            lbl_avisoLRPA.Text = "Debe ingresar una sación accesoria";
                            lbl_avisoLRPA.Visible = true;
                            vtab5 = true;

                        }
                    }
                }
                if (vtab5 == true)
                {
                    val5 = vtab5;
                    //utab.Tabs[5].ForeColor = System.Drawing.Color.Red;
                    //pnl_utab6.ForeColor = System.Drawing.Color.Red;
                    link_tab6.Attributes.Add("Class", "pestana-roja");

                }
                else
                {

                    //utab.Tabs[5].ForeColor = System.Drawing.Color.Black;
                    pnl_utab6.ForeColor = System.Drawing.Color.Black;
                    link_tab6.Attributes.Remove("Class");
                }


                #endregion
            }
            else
            {

                vtab5 = false;
                bool validar = false;
                int count = 0;

                if ((codemod == 102 && ddl_CalidadJuridica.SelectedValue == "8") || (codemod == 100 && ddl_CalidadJuridica.SelectedValue == "7"))
                {

                    #region validar informacion basica

                    if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue != "0" || txt_FechaInicioSancionLRPA.Text != "" || txt003LRPA.Text.Trim() != "" || ddown003LRPA.SelectedValue != "0" || ddown004LRPA.SelectedValue != "0" ||
                        ddown005LRPA.SelectedValue != "0")
                    {
                        validar = true;
                    }

                    if (validar)
                    {

                        //---1
                        if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue == "0")
                        {
                            ddl_OrdenDeTribunal_MedidaSancion.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            ddl_OrdenDeTribunal_MedidaSancion.BackColor = System.Drawing.Color.Empty;
                        }

                        //----2
                        if (txt_FechaInicioSancionLRPA.Text == "")
                        {
                            txt_FechaInicioSancionLRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            txt_FechaInicioSancionLRPA.BackColor = System.Drawing.Color.Empty;

                        }
                        //----3
                        if (txt003LRPA.Text == "")
                        {
                            txt003LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            txt003LRPA.BackColor = System.Drawing.Color.Empty;

                        }
                        //----4
                        if (ddown003LRPA.SelectedValue == "0")
                        {
                            ddown003LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            ddown003LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        //----5
                        if (ddown004LRPA.SelectedValue == "0")
                        {
                            ddown004LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            ddown004LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        //-----6
                        if (ddown005LRPA.SelectedValue == "0")
                        {
                            ddown005LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            ddown005LRPA.BackColor = System.Drawing.Color.Empty;
                        }


                    }
                    #endregion

                    #region LRPA_Mixta
                    if (Chk002LRPAMixta.Checked == true)
                    {
                        if (ddown009LRPA.Text.ToUpper() == "")
                        {
                            ddown009LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            ddown009LRPA.BackColor = System.Drawing.Color.Empty;
                        }
                        if (txt006LRPA.Text == "")
                        {
                            txt006LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            txt006LRPA.BackColor = System.Drawing.Color.Empty;
                        }

                        if (ddown011LRPA.SelectedValue == "-1")
                        {
                            ddown011LRPA.BackColor = colorCampoObligatorio;
                            count = count + 1;
                        }
                        else
                        {
                            ddown011LRPA.BackColor = System.Drawing.Color.Empty;
                        }


                    }
                    #endregion

                    #region Sancion Accesoria
                    if (chk001LRPA.Checked == true && DTTipoSancionAccesoria.Rows.Count == 0)
                    {
                        if (ddown006LRPA.SelectedValue == "0")
                        {
                            ddown006LRPA.BackColor = colorCampoObligatorio;
                        }

                        lbl_avisoLRPA.Text = "Debe ingresar una sanción accesoria";
                        lbl_avisoLRPA.Visible = true;
                        count = count + 1;
                    }
                    else
                    {
                        lbl_avisoLRPA.Text = "";
                        lbl_avisoLRPA.Visible = false;
                        ddown006LRPA.BackColor = System.Drawing.Color.Empty;
                    }
                    #endregion

                    if (count > 0)
                    {
                        vtab5 = true;
                    }
                }
            }
        }


        // verificacion de Tabs total OK

        if (vtab1 || vtab2 || vtab3 || vtab4 || vtab5)
        {
            fullbool = true;

        }

        if (vtab1)
        {
            link_tab1.Attributes.Add("Class", "pestana-roja");
            lblpestana1.Visible = vtab1;
        }
        else
        {
            lblpestana1.Visible = vtab1;
            link_tab1.Attributes.Remove("Class");
        }

        if (vtab2)
        {
            lblpestana2.Visible = vtab2;
        }
        else
        {
            lblpestana2.Visible = vtab2;
        }
        if (vtab3)
        {
            lblpestana3.Visible = vtab3;
        }
        else
        {
            lblpestana3.Visible = vtab3;
        }
        if (vtab4)
        {
            lblpestana4.Visible = vtab1;
        }
        else
        {
            lblpestana4.Visible = vtab4;
        }

        if (vtab5)
        {
            lblpestana6.Visible = vtab5;
        }
        else
        {
            lblpestana6.Visible = vtab5;
        }



        return fullbool;

    }



    private bool validatedata3(int tabindex, bool full)
    {

        //   validacion de datos obligatorios en tabs

        bool fullbool = false;
        bool vtab1 = false;
        bool vtab2 = false;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        //primer tabs
        if (tabindex == 0 || full)
        {
            vtab1 = validarTab1();

        }

        // segundo tabs
        if (tabindex == 1 || full)
        {

            bool vtab2_1 = validateddownutab(ddl_CalidadJuridica);
            bool vtab2_2 = validateddownutab(ddl_Escolaridad);
            bool vtab2_3 = validateddownutab(ddl_TipoAsistenciaEscolar);
            bool vtab2_4 = validateddownutab(ddown007a);
            bool vtab2_5 = validateddownutab(ddown007);
            bool vtab2_6 = validateddownutab(ddl_Entrevistador);
            bool vtab2_7 = validateddownutab(ddl_TipoSolicitanteIngreso);
            bool vtab2_8 = validateddownutab(ddown013);


            if (vtab2_1 || vtab2_2 || vtab2_3 || vtab2_4 || vtab2_5 || vtab2_6 || vtab2_7 || vtab2_8)
            {
                vtab2 = true;
                
            }
            else
            {
                vtab2 = false;
                
            }

            if (txt003b.Text == "")
            {
                txt003b.BackColor = colorCampoObligatorio;                
                vtab2 = true;
            }
            else
            {
                txt003b.BackColor = System.Drawing.Color.Empty;                
            }

            if (ddown008.SelectedValue == null || ddown008.SelectedValue == "0")
            {
                ddown008.BackColor = colorCampoObligatorio;                
                vtab2 = true;
            }
            else
            {
                ddown008.BackColor = System.Drawing.Color.Empty;
            }

            bool swLrpa = FiltroLRPA();
            if (swLrpa == false)
            {

                if (WebTextEdit1.Text == "")
                {
                    WebTextEdit1.BackColor = colorCampoObligatorio;
                    vtab2 = true;
                }
                else
                {
                    WebTextEdit1.BackColor = System.Drawing.Color.Empty;
                }

                if (TextBox1.Text == "")
                {
                    TextBox1.BackColor = colorCampoObligatorio;
                    vtab2 = true;
                }
                else
                {
                    TextBox1.BackColor = System.Drawing.Color.Empty;
                }
            }

        }

        if (vtab1 || vtab2)
        {
            fullbool = true;
        }

        if (vtab1)
        {
            lblpestana1.Visible = vtab1;
            link_tab1.Attributes.Add("Class", "pestana-roja");
        }
        else
        {
            lblpestana1.Visible = vtab1;
            link_tab1.Attributes.Remove("Class");
        }

        if (vtab2)
        {
            lblpestana2.Visible = vtab2;
            link_tab2.Attributes.Add("Class", "pestana-roja");
        }
        else
        {
            lblpestana2.Visible = vtab2;
            link_tab2.Attributes.Remove("Class");
        }

        return fullbool;

    }



    private bool validatedata(int tabindex, bool full)
    {

        //   validacion de datos obligatorios en tabs

        bool fullbool = false;
        bool vtab1 = false;
        bool vtab2 = false;
        bool vtab3 = false;
        bool vtab4 = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        //primer tabs
        if (tabindex == 0 || full)
        {
            vtab1 = validarTab1();
        }


        // segundo tabs
        if (tabindex == 1 || full)
        {

            bool vtab2_1 = validateddownutab(ddl_CalidadJuridica);
            bool vtab2_2 = validateddownutab(ddl_Escolaridad);
            bool vtab2_3 = validateddownutab(ddl_TipoAsistenciaEscolar);
            bool vtab2_4 = validateddownutab(ddown007a);
            bool vtab2_5 = validateddownutab(ddown007);
            bool vtab2_6 = validateddownutab(ddl_Entrevistador);
            bool vtab2_7 = validateddownutab(ddl_TipoSolicitanteIngreso);
            bool vtab2_8 = validateddownutab(ddown013);


            if (vtab2_1 || vtab2_2 || vtab2_3 || vtab2_4 || vtab2_5 || vtab2_6 || vtab2_7 || vtab2_8)
            {
                vtab2 = true;         
            }
            else
            {
                vtab2 = false;                        
            }

        }
        // tercer tabs
        if (tabindex == 2 || full)
        {

            if (rdo_OrdenTribunal_SI.Checked == false && rdo_OrdenTribunal_EnTramite.Checked == false && rdo_OrdenTribunal_NO.Checked == false)
            {
                rdo_OrdenTribunal_SI.BackColor = colorCampoObligatorio;
                rdo_OrdenTribunal_EnTramite.BackColor = colorCampoObligatorio;
                rdo_OrdenTribunal_NO.BackColor = colorCampoObligatorio;                
                vtab3 = true;
            }
            else if (rdo_OrdenTribunal_SI.Checked == true && rdo_OrdenTribunal_NO.Checked == false)
            {

                bool vtab3_1 = validateddownutab(ddown014);
                bool vtab3_2 = validateddownutab(ddown015);
                bool vtab3_3 = validateddownutab(ddown016);

                

                if (grd001.Rows.Count == 0 && (vtab3_1 || vtab3_2 || vtab3_3 || ddown017.Text == null))
                {
                    rdo_OrdenTribunal_SI.BackColor = colorCampoObligatorio;
                    rdo_OrdenTribunal_EnTramite.BackColor = colorCampoObligatorio;
                    rdo_OrdenTribunal_NO.BackColor = colorCampoObligatorio;
                    vtab3 = true;
                }
                else
                {
                    rdo_OrdenTribunal_SI.BackColor = System.Drawing.Color.Empty;
                    rdo_OrdenTribunal_EnTramite.BackColor = System.Drawing.Color.Empty;
                    rdo_OrdenTribunal_NO.BackColor = System.Drawing.Color.Empty;
                    vtab3 = false;
                }

            }
            else if (rdo_OrdenTribunal_SI.Checked == false && rdo_OrdenTribunal_EnTramite.Checked == false  && rdo_OrdenTribunal_NO.Checked == true)
            {
                rdo_OrdenTribunal_SI.BackColor = System.Drawing.Color.Empty;
                rdo_OrdenTribunal_EnTramite.BackColor = System.Drawing.Color.Empty;
                rdo_OrdenTribunal_NO.BackColor = System.Drawing.Color.Empty;   
                vtab3 = false;

            }

            if (rdo_OrdenTribunal_SI.Checked && grd001.Rows.Count == 0)
            {
                vtab3 = true;

            }

        }

        // cuarto tabs
        if (tabindex == 3 || full)
        {

            if (grd002.Rows.Count > 0 && grd002.Rows.Count < 4)
            {
                ddl_TipoCausalIngreso.BackColor = System.Drawing.Color.Empty;
                ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;
                ddown020.BackColor = System.Drawing.Color.Empty;
                vtab4 = false;
            }
            else
            {
                bool vtab4_1 = validateddownutab(ddl_TipoCausalIngreso);
                bool vtab4_2 = validateddownutab(ddl_CausalIngreso);
                bool vtab4_3 = validateddownutab(ddown020);
                vtab4 = true;
            }
        }

        // verificacion de Tabs total OK

        if (vtab1 || vtab2 || vtab3 || vtab4)
        {
            fullbool = true;

        }

        if (vtab1)
        {
            lblpestana1.Visible = vtab1;
            link_tab1.Attributes.Add("Class", "pestana-roja");
        }
        else
        {
            lblpestana1.Visible = vtab1;
            link_tab1.Attributes.Remove("Class");
        }

        if (vtab2)
        {
            lblpestana2.Visible = vtab2;
            link_tab2.Attributes.Add("Class", "pestana-roja");
        }
        else
        {
            lblpestana2.Visible = vtab2;
            link_tab2.Attributes.Remove("Class");
        }
        if (vtab3)
        {
            lblpestana3.Visible = vtab3;
            link_tab3.Attributes.Add("Class", "pestana-roja");
        }
        else
        {
            lblpestana3.Visible = vtab3;
            link_tab3.Attributes.Remove("Class");
        }
        if (vtab4)
        {
            lblpestana4.Visible = vtab1;
            link_tab4.Attributes.Add("Class", "pestana-roja");
        }
        else
        {
            lblpestana4.Visible = vtab4;
            link_tab4.Attributes.Remove("Class");
        }

        return fullbool;

    }
    private bool validateddownutab(DropDownList ddown)
    {
        return validateddown(ddown);
    }
    private bool validateddown(DropDownList ddown)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (ddown.SelectedValue == null || ddown.SelectedValue == "0")
        {
            ddown.BackColor = colorCampoObligatorio;
            return true;

        }
        else
        {
            ddown.BackColor = System.Drawing.Color.Empty;
            return false;

        }

    }
    private bool validate_rdo_utab(RadioButton rdo, bool required)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (!rdo.Checked && required)
        {
            rdo.BackColor = colorCampoObligatorio;

        }
        else
        {
            rdo.BackColor = System.Drawing.Color.Empty;

        }
        return rdo.Checked;
    }
    private int utabgetvalue(DropDownList ddown)
    {
        try
        {
            return Convert.ToInt32(ddown.SelectedValue);
        }
        catch
        {
            return 0;
        }
    }


    #endregion



    protected void chk001_DataBinding(object sender, EventArgs e) //LO USAMOS PARA GATILLAR DATOS DESPUES DE LA BUSQUEDA
    {

        ninocoll ncoll = new ninocoll();
        nino n = ncoll.GetData(SSnino.CodNino.ToString(), SSnino.ICodIE.ToString());

        txt001.Text = n.rut.ToString().ToUpper();
        txt002.Text = n.CodNino.ToString().ToUpper();
        txt003.Text = n.Apellido_Paterno.ToUpper();
        txt004.Text = n.Apellido_Materno.ToUpper();
        txt005.Text = n.Nombres.ToUpper();
        lbl004.Text = n.FechaNacimiento.Date.ToShortDateString();
        if (SSnino.sexo == "F")
        {
            rdo_Sexo_F.Checked = true;

        }
        else
        {
            rdo_Sexo_M.Checked = true;

        }

        ddl_Institucion.Enabled = false;
        ddl_Proyecto.Enabled = false;
        //GetSelectedInfo();

    }

    protected void btnsaveingreso2_Click(object sender, EventArgs e)
    {
        muestra_pestaña(6);

        ninocoll ncoll = new ninocoll();
        int cuenta = ncoll.callto_get_ninoingresado(SSnino.CodProyecto, 0, SSnino.CodNino);

        if (cuenta == 0 && SSnino.CodProyecto != 0 && SSnino.CodNino != 0)
        {
            string Expediente;
            string ruc;
            string rit;

            btnsaveingreso.Visible = false;

            if (txt_FechaInicioSancionLRPA.Text != "")
            {
                if (txt001LRPA.Text == "")
                {
                    txt001LRPA.Text = "";
                }
                if (txt002LRPA.Text == "")
                {
                    txt002LRPA.Text = "";
                }
                if (txt007LRPA.Text == "")
                {
                    txt007LRPA.Text = "";
                }
                if (txt009LRPA.Text == "")
                {
                    txt009LRPA.Text = "";
                }

            }
            if (ddown009LRPA.Text != "")
            {
                if (txt004LRPA.Text == "")
                {
                    txt004LRPA.Text = "";
                }
                if (txt005LRPA.Text == "")
                {
                    txt005LRPA.Text = "";
                }
                if (txt008LRPA.Text == "")
                {
                    txt008LRPA.Text = "";
                }

            }
            

           if (validatedata2(0, true))
           {
               lblbmsg.Text = "Faltan datos para completar el Ingreso en las siguentes pestañas:";
               lblbmsg.Visible = true;
               alerts.Visible = true;
               

           }

           else // Valida todo los tab en validatedata2 ya que el bool esta en true
            {
                lblbmsg.Visible = false;
                alerts.Visible = false;

                string lesiones = "SI";
                if (rdo005.Checked)
                {
                    lesiones = "NO";
                }
                string ordenenesdeltribunal = "SI";
                if (rdo_OrdenTribunal_NO.Checked)
                {
                    ordenenesdeltribunal = "NO";
                }
                if (rdo_OrdenTribunal_EnTramite.Checked)
                {
                    ordenenesdeltribunal = "ET";
                }
                if (txt005.Text.Trim() == "")
                {
                    Expediente = Convert.ToString(0);
                }
                else
                {
                    Expediente = txt005.Text.Trim();
                }

                if (txt006F2.Text.Trim() == "")
                {
                    ruc = Convert.ToString(0);
                }
                else
                {
                    ruc = txt006F2.Text.Trim();
                }

                if (txt006F2.Text.Trim() == "")
                {
                    rit = Convert.ToString(0);
                }
                else
                {
                    rit = txt007F2.Text.Trim();
                }



                # region InsertNino

                ///OK///

                SqlTransaction sqlt;
               
                SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                sconn.Open();
                sqlt = sconn.BeginTransaction();
               try
               {

                int CodIE = ncoll.SetIngresos_Egresos(sqlt,
                        SSnino.CodProyecto,
                        SSnino.CodNino,
                        Convert.ToDateTime(txt_FechaIngreso.Text),
                        utabgetvalue(ddown013),
                        chk001.Checked,
                        utabgetvalue(ddl_TipoAtencion),
                        utabgetvalue(ddl_CalidadJuridica),
                        0,
                        utabgetvalue(ddl_Inmueble),

                        Convert.ToInt32(WebNumericEdit1.Text),
                        Convert.ToInt32(WebNumericEdit2.Text),

                        utabgetvalue(ddown008),
                        WebTextEdit1.Text.ToString(),
                        TextBox1.Text.ToString(),
                        utabgetvalue(ddown009),
                        utabgetvalue(ddown008),
                        utabgetvalue(ddl_Entrevistador),
                        utabgetvalue(ddown011),
                        chk002.Checked,
                        string.Empty,
                        lesiones,
                        ordenenesdeltribunal,
                        DateTime.Now,
                        Convert.ToInt32(UserId),
                        Convert.ToDateTime("01-01-1900"),
                        "0", 0, "0", 0, 0, 0, 0, 0);

                if (Session["listadeespera"] != null)
                {
                    ActualizoListaEspera(CodIE, Convert.ToInt32(txt_ICodIngresoLE.Text));
                }

                diagnosticoscoll dcoll = new diagnosticoscoll();
                
                ///OK///

                int iden = dcoll.Insert_DiagnosticoGeneralTransaccional(sqlt,1, SSnino.CodNino, CodIE
                    , Convert.ToDateTime(txt_FechaIngreso.Text));

                int ultimoanocursado;
                if (txt003a.Text.Trim() == "")
                {
                    ultimoanocursado = 0;
                }
                else
                {
                    ultimoanocursado = Convert.ToInt32(txt003a.Text);
                }

                dcoll.Insert_DiagnosticosEscolarTransaccional(sqlt,
                        iden,
                        DateTime.Now,
                        utabgetvalue(ddl_Escolaridad),
                        Convert.ToDateTime(txt_FechaIngreso.Text),
                        utabgetvalue(ddl_Entrevistador),
                        Convert.ToInt32(ddown008.SelectedValue),
                        utabgetvalue(ddl_Entrevistador),
                        utabgetvalue(ddl_TipoAsistenciaEscolar),
                        ultimoanocursado,
                        txt003b.Text,
                        Convert.ToBoolean(1),
                        DateTime.Now,
                        Convert.ToInt32(UserId));


                ncoll.Insert_DireccionNinosTransaccional(sqlt,
                        CodIE,
                        Convert.ToInt32(ddl_Proyecto.SelectedValue)
                        , SSnino.CodNino,
                        Convert.ToDateTime(txt_FechaIngreso.Text)
                        , txt003b.Text,
                        TextBox1.Text.Trim()
                        , Convert.ToString("0"),
                        Convert.ToString("0")
                        , Convert.ToString("0"),
                        Convert.ToInt32("0"),
                        utabgetvalue(ddown007), Convert.ToBoolean(1), DateTime.Now
                        , Convert.ToInt32(UserId), "V");



                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
                dt.Columns.Add(new DataColumn("Ruc", typeof(string)));

                DataRow dr;

                if (grd001.Rows.Count != 0)
                {
                    for (int i = 0; i < DTordentribunales.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr[0] = ncoll.Insert_OrdenTribunalIngresoTransaccional(sqlt,
                            CodIE,
                            Convert.ToInt32(DTordentribunales.Rows[i][0]),
                            Convert.ToDateTime(DTordentribunales.Rows[i][2]),
                            Convert.ToInt32(UserId),
                            Convert.ToString(DTordentribunales.Rows[i][3]),
                            Convert.ToString(DTordentribunales.Rows[i][4]),
                            Convert.ToString(DTordentribunales.Rows[i][5]));
                        dr[1] = Convert.ToString(DTordentribunales.Rows[i][4]);
                        dt.Rows.Add(dr);
                    }
                }

                int ICodTribunalIngreso = 0;
                if (grd002.Rows.Count != 0)
                {
                    for (int j = 0; j < DTcausales.Rows.Count; j++)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (DTcausales.Rows[j][7].ToString().Trim() == dt.Rows[i][1].ToString().Trim())
                            {
                                ICodTribunalIngreso = Convert.ToInt32(dt.Rows[i][0]);
                            }
                        }

                        ncoll.Insert_CausalesIngresoTransaccional(sqlt,
                            CodIE,
                            Convert.ToInt32(DTcausales.Rows[j][1]),
                            Convert.ToInt32(DTcausales.Rows[j][5]),
                            Convert.ToString(DTcausales.Rows[j][4]),
                            DateTime.Now,
                            Convert.ToInt32(UserId),
                            ICodTribunalIngreso);
                    }
                }

                if (grd003.Rows.Count != 0)
                {

                    for (int k = 0; k < DTlesiones.Rows.Count; k++)
                    {

                        ncoll.Insert_DetalleLesionesTransaccional(sqlt,
                            CodIE,
                            Convert.ToInt32(DTlesiones.Rows[k][0]),
                            Convert.ToInt32(DTlesiones.Rows[k][1]),
                            Convert.ToString(DTlesiones.Rows[k][3]),
                            DateTime.Now,
                            Convert.ToInt32(UserId),
                            Convert.ToInt32(DTlesiones.Rows[k][5]));

                    }
                }
                ///************************************SOLO PARA TAB (6)**************************************//


                #region LRPA
                //////////////////////////////////////////////DDOWN PARA SBC Y PSA//////////

                if (txt001LRPA.Text.Trim() != "" || txt002LRPA.Text.Trim() != "" || txt_FechaInicioSancionLRPA.Text.ToUpper() != "" ||
                    ddown003LRPA.SelectedValue != Convert.ToString(-2) || ddown004LRPA.SelectedValue != Convert.ToString(0) ||
                    ddown005LRPA.SelectedValue != Convert.ToString(0) || ddl_OrdenDeTribunal_MedidaSancion.SelectedValue != "0")
                {


                    int inden;

                    int MesDuracionMix = 0;
                    int AnoDuracionMix = 0;
                    int DiaDuracionMix = 0;
                    DateTime FechaTerminoMix = Convert.ToDateTime("01-01-1900");
                    DateTime FechaInicioMix = Convert.ToDateTime("01-01-1900");

                
                    if (txt006LRPA.Text.Trim() == "")
                    {
                        FechaTerminoMix = Convert.ToDateTime("01-01-1900");
                    }
                    else
                    {
                        FechaTerminoMix = Convert.ToDateTime(txt006LRPA.Text.Trim());
                    }
                    if (ddown009LRPA.Text.ToUpper() != "")
                    {
                        FechaInicioMix = Convert.ToDateTime(ddown009LRPA.Text.Trim());
                    }

                    DateTime FechaTerminoSansion = Convert.ToDateTime("01-01-1900");

                    if (ddown_repdaño.SelectedValue == Convert.ToString(3))
                    {
                        if (txt_hservi.Text != "")
                        {
                            lbl_mensaje002.Visible = false;
                        }
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue.Trim() == dt.Rows[i][1].ToString().Trim())
                        {
                            ICodTribunalIngreso = Convert.ToInt32(dt.Rows[i][0]);
                        }
                    }
                    int codmodelosansionmixta = 0;

                    if ((ddown011LRPA.SelectedValue) != "")
                    {
                        if (Convert.ToInt32(ddown011LRPA.SelectedValue) > 0)
                        {
                            codmodelosansionmixta = Convert.ToInt32(ddown011LRPA.SelectedValue);
                        }
                    }

                    ///////////////////////////INSERTAR MEDIDA DE SANCION///////////////////////////////

                    int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
                    LRPAcoll codmod = new LRPAcoll();
                    DataTable dt2 = codmod.GetCodModIntervencion(codproy);
                    int codemod = Convert.ToInt32(dt2.Rows[0][0]);
                    if (codemod == 108)
                    {
                        if (ddown_repdaño.SelectedValue == "3")///////solo es obligatorio para valor 3
                        {
                            horas = Convert.ToInt32(txt_hservi.Text);
                            repdaño = Convert.ToString(ddown_repdaño.SelectedValue);

                        }
                        else
                        {
                            horas = 0;
                            repdaño = ddown_repdaño.SelectedValue;
                        }

                    }
                    if (codemod == 103)
                    {

                        horas = Convert.ToInt32(txt_hservi.Text);
                        repdaño = "0";

                    }

                    if (val5 == false)
                    {
                        if (codemod == 103 || codemod == 108)
                        {
                            LRPAcoll LRPA = new LRPAcoll();
                            inden = LRPA.callto_insert_tipomedidassanciones2Transaccional
                                (sqlt, CodIE,
                                Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text),
                                Convert.ToDateTime(txt003LRPA.Text),
                                Convert.ToInt32(txt002LRPA.Text),
                                Convert.ToInt32(txt001LRPA.Text),
                                Convert.ToInt32(ddown005LRPA.SelectedValue),
                                Convert.ToInt32(chk001LRPA.Checked),
                                Convert.ToInt32(UserId),
                                DateTime.Now,
                                -1,
                                Convert.ToInt32(ddown003LRPA.SelectedValue),
                                Convert.ToInt32(ddown004LRPA.SelectedValue),
                                MesDuracionMix,
                                AnoDuracionMix,
                                FechaTerminoMix,
                                FechaInicioMix,
                                FechaTerminoSansion,
                                ICodTribunalIngreso,
                                Convert.ToInt32(txt007LRPA.Text.Trim()),
                                DiaDuracionMix,
                                codmodelosansionmixta,
                                Convert.ToInt32(txt009LRPA.Text),

                                Convert.ToInt32(horas),              //Horas solo para PSA y Con Rep Daño
                                Convert.ToInt32(ddown_tsancion.SelectedValue),//SBC Y PSA
                                Convert.ToInt32(ddown_tipoBC.SelectedValue),  //SBC
                                Convert.ToInt32(ddown_IPSER.SelectedValue),   //SBC
                                Convert.ToInt32(ddown_areaTI.SelectedValue),  //SBC
                                Convert.ToInt32(repdaño));

                            
                            if (chk001LRPA.Checked)
                            {
                                for (int i = 0; i < DTTipoSancionAccesoria.Rows.Count; i++)
                                {
                                    LRPAcoll LRPA3 = new LRPAcoll();
                                    LRPA3.callto_insert_tiposancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][1]), inden);
                                }
                            }
                            if (codemod == 108)
                            {
                                for (int i = 0; i < dt_coning.Rows.Count; i++)
                                {
                                    LRPAcoll LRPA2 = new LRPAcoll();
                                    LRPA2.Insert_NemoTecnicoLRPA(Convert.ToString(dt_coning.Rows[i][1]), inden);
                                }

                            }


                        }
                        else
                        {
                            LRPAcoll LRPA = new LRPAcoll();
                            inden = LRPA.callto_insert_tipomedidassanciones2Transaccional(sqlt,CodIE,
                                Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text),
                                Convert.ToDateTime(txt003LRPA.Text),
                                Convert.ToInt32(txt002LRPA.Text),
                                Convert.ToInt32(txt001LRPA.Text),
                                Convert.ToInt32(ddown005LRPA.SelectedValue),
                                Convert.ToInt32(chk001LRPA.Checked),
                                Convert.ToInt32(UserId),
                                DateTime.Now,
                                -1,
                                Convert.ToInt32(ddown003LRPA.SelectedValue),
                                Convert.ToInt32(ddown004LRPA.SelectedValue),
                                MesDuracionMix,
                                AnoDuracionMix,
                                FechaTerminoMix,
                                FechaInicioMix,
                                FechaTerminoSansion,
                                ICodTribunalIngreso,
                                Convert.ToInt32(txt007LRPA.Text.Trim()),
                                DiaDuracionMix,
                                codmodelosansionmixta,
                                Convert.ToInt32(txt009LRPA.Text),
                                horas,
                                0,
                                0,
                                0,
                                0,
                                0);

                            if (chk001LRPA.Checked)
                            {
                                for (int i = 0; i < DTTipoSancionAccesoria.Rows.Count; i++)
                                {
                                    LRPAcoll LRPA3 = new LRPAcoll();
                                    //LRPA3.callto_insert_tiposancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][1]), inden);
                                    LRPA3.callto_insert_tiposancionaccesoriaTransaccional(sqlt, Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][1]), inden);
                                }
                            }
                            if (codemod == 108)
                            {
                                for (int i = 0; i < dt_coning.Rows.Count; i++)
                                {
                                    LRPAcoll LRPA2 = new LRPAcoll();
                                    LRPA2.Insert_NemoTecnicoLRPA(Convert.ToString(dt_coning.Rows[i][1]), inden);
                                }

                            }



                        }


                    }
                    else
                    {
                        //Label tlbl_mensajeLRPA02 = (Label)utab.FindControl("lbl_mensajeLRPA02");
                        //tlbl_mensajeLRPA02.Text = "Debe ingresar todos los caracters";
                    }

                }
                # endregion

                ///************************************ FIN (6)**************************************//

                # endregion

                #region INSERT PII

                ninocoll cons33 = new ninocoll();
                DataTable dt33 = cons33.trae_tipousuario_Ninos(Convert.ToInt32(SSnino.CodNino));
                int tusuario = Convert.ToInt32(dt33.Rows[0][0]);

                if ((tipo == "PAG"))
                {
                    try
                    {

                        if (tusuario != -1 || tusuario == 0)
                        {
                            DateTime fechaact = DateTime.Now;
                            ninocoll cons44 = new ninocoll();
                            DataTable dt44 = cons44.trae_codinstitucion_inmueble(SSnino.ICodIE);
                            int codinst_inmu = Convert.ToInt32(dt44.Rows[0][0]);


                            ninocoll cons55 = new ninocoll();

                            DataTable dt55 = cons55.trae_codTrabajador(Convert.ToInt32(UserId));
                            int cod_tra = Convert.ToInt32(dt55.Rows[0][0]);


                            ninocoll ins9 = new ninocoll();
                            Cod_Interv = ins9.Insert_Plan_intervencion_PAG(
                                Convert.ToInt32(SSnino.ICodIE),
                                Convert.ToInt32(SSnino.CodProyecto),
                                Convert.ToInt32(SSnino.CodNino),

                                Convert.ToDateTime(txt_FechaIngreso.Text),
                                Convert.ToInt32(codinst_inmu),
                                Convert.ToInt32(cod_tra),
                                Convert.ToInt32(UserId),

                                Convert.ToDateTime(fechaact),
                                Convert.ToInt32(cod_tra), 
                                0                                
                            );                            

                        }
                    }
                    catch
                    {
                        Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Plan Intervencion PAG. ');</script>");
                    }

                    try
                    {
                        ninocoll ins11 = new ninocoll();
                        ins11.Insert_Intervenciones_PAG(
                            Convert.ToInt32(Cod_Interv),
                            Convert.ToInt32(40),
                            Convert.ToDateTime(DateTime.Now)
                        );
                    }
                    catch
                    {
                        Response.Write("<script language='javascript'>alert('Se produjo un error al intentar Grabar Intervenciones. ');</script>");
                    }

                    try
                    {
                        ninocoll ins12 = new ninocoll();
                        ins12.Insert_Estados_Intervenciones_PAG(
                            Convert.ToInt32(Cod_Interv),
                            Convert.ToDateTime(DateTime.Now)
                        );
                    }
                    catch
                    {
                        Response.Write("<script language='javascript'>alert('Se produjo un error al intentar Grabar Estados plan intervencion. ');</script>");
                    }

                }

                #endregion

                   ////////////////////////////////////////////////
                if (val5 == false)
                {
                    if (SSnino.sexo == null)
                    {
                        SSnino.sexo = Convert.ToString('A');
                    }

                    ncoll.Cierre_ingresoTransaccional(sqlt,
                        CodIE,
                        SSnino.CodProyecto,
                        Convert.ToDateTime(txt_FechaIngreso.Text),
                        SSnino.CodNino,
                        SSnino.sexo,
                        Convert.ToInt32(UserId));



                    //Agrega al niño a la variable global
                    if (Session["NNA"] == null)
                    {
                        nino n = ncoll.GetDataTransactional(sqlt, SSnino.CodNino.ToString(), "0");

                        string cinst = SSnino.CodInst.ToString();
                        string cproy = SSnino.CodProyecto.ToString();
                        string rut = n.rut;
                        Int32 codie = CodIE;
                        Int32 cnino = n.CodNino;

                        oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, Convert.ToString(txt_FechaIngreso.Text), Convert.ToString(n.FechaNacimiento));
                        Session["NNA"] = NNA;


                    }

                    lblmsgSuccess.Text = "Ingreso Realizado Satisfactoriamente";
                    lblmsgSuccess.Visible = true;
                    alerts2.Visible = true;

                    Response.Write("<script language='javascript'>alert('Ingreso Realizado Satisfactoriamente. ');</script>");
                    clean_form();
                    clean_tab();


                    LimpiaControles();

                }

                #region Generar PII AUTOMATICO





                #endregion


                  
               sqlt.Commit();
               sconn.Close(); 
               }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Response.Write("<script language='javascript'>alert('Ingreso no realizado, intentar nuevamene.');</script>");
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlt.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection 
                        // is closed or the transaction has already been rolled 
                        // back on the server.
                        Response.Write("<script language='javascript'>alert('Ingreso Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                        Console.WriteLine(exRollback.Message);
                    }
                }

            }
            
            

        }
        else
        {
            Response.Write("<script language='javascript'>alert('Ingreso Realizado');</script>");
        }
    }

    protected void btnsaveingreso3_Click(object sender, EventArgs e)
    {
        muestra_pestaña(2);

        ninocoll ncoll = new ninocoll();
        int cuenta = ncoll.callto_get_ninoingresado(SSnino.CodProyecto, 0, SSnino.CodNino);

        if (cuenta == 0 && SSnino.CodProyecto != 0 && SSnino.CodNino != 0)
        {

            if (validatedata3(0, true))
            {
                lblbmsg.Visible = true;
                lblbmsg.Text = "Faltan datos para completar el Ingreso en las siguentes pestañas:";
                alerts.Visible = true;
            }
            else
            {
                lblbmsg.Visible = false;
                alerts.Visible = false;
                FechaIngreso = Convert.ToDateTime(txt_FechaIngreso.Text);
                lblpestana3.Visible = false;

                string lesiones = "NO";
                string ordenenesdeltribunal = "NO";

                # region InsertNino
                SqlTransaction sqlt;
               
                SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                sconn.Open();
                sqlt = sconn.BeginTransaction();
               try
               {

                int CodIE = ncoll.SetIngresos_Egresos(sqlt,SSnino.CodProyecto, SSnino.CodNino,
                Convert.ToDateTime(txt_FechaIngreso.Text),
                utabgetvalue(ddown013), chk001.Checked, utabgetvalue(ddl_TipoAtencion),
                utabgetvalue(ddl_CalidadJuridica),
                0,
                utabgetvalue(ddl_Inmueble),
                Convert.ToInt32(WebNumericEdit1.Text),
                Convert.ToInt32(WebNumericEdit2.Text), utabgetvalue(ddown008),
                WebTextEdit1.Text.ToString(),
                TextBox1.Text.ToString(),
                utabgetvalue(ddown009), utabgetvalue(ddown008),
                utabgetvalue(ddl_Entrevistador), utabgetvalue(ddown011), chk002.Checked,
                string.Empty,
                lesiones, ordenenesdeltribunal, DateTime.Now, Convert.ToInt32(UserId),
                Convert.ToDateTime("01-01-1900"), "0", 0, "0", 0, 0, 0, 0, 0);

                if (Session["listadeespera"] != null)
                {
                    ActualizoListaEspera(CodIE, Convert.ToInt32(txt_ICodIngresoLE.Text));
                }

                diagnosticoscoll dcoll = new diagnosticoscoll();

                int iden = dcoll.Insert_DiagnosticoGeneralTransaccional(sqlt,1, SSnino.CodNino, CodIE
                    , Convert.ToDateTime(txt_FechaIngreso.Text));

                int ultimoanocursado;
                if (txt003a.Text.Trim() == "")
                {
                    ultimoanocursado = 0;
                }
                else
                {
                    ultimoanocursado = Convert.ToInt32(txt003a.Text);
                }

                dcoll.Insert_DiagnosticosEscolarTransaccional(sqlt, iden, DateTime.Now,
                utabgetvalue(ddl_Escolaridad), Convert.ToDateTime(txt_FechaIngreso.Text), utabgetvalue(ddl_Entrevistador),
                Convert.ToInt32(ddl_Institucion.SelectedValue), utabgetvalue(ddl_Entrevistador), utabgetvalue(ddl_TipoAsistenciaEscolar), ultimoanocursado,
                txt003b.Text, Convert.ToBoolean(1), DateTime.Now, Convert.ToInt32(UserId));


                ncoll.Insert_DireccionNinosTransaccional(sqlt, CodIE, Convert.ToInt32(ddl_Proyecto.SelectedValue)
                , SSnino.CodNino, Convert.ToDateTime(txt_FechaIngreso.Text)
                , txt003b.Text, TextBox1.Text.Trim()
                , Convert.ToString("0"), Convert.ToString("0")
                , Convert.ToString("0"), Convert.ToInt32("0"), utabgetvalue(ddown007), Convert.ToBoolean(1), DateTime.Now
                , Convert.ToInt32(UserId), "V");

                # endregion


                if (SSnino.sexo == null)
                {
                    SSnino.sexo = Convert.ToString('A');
                }

                ncoll.Cierre_ingresoTransaccional(sqlt, CodIE, SSnino.CodProyecto,
                Convert.ToDateTime(txt_FechaIngreso.Text), SSnino.CodNino, SSnino.sexo, Convert.ToInt32(UserId));


                //Agrega al niño a la variable global
                if (Session["NNA"] == null)
                {
                    nino n = ncoll.GetDataTransaccional(sqlt, SSnino.CodNino.ToString(), "0");

                    string cinst = SSnino.CodInst.ToString();
                    string cproy = SSnino.CodProyecto.ToString();
                    string rut = n.rut;
                    Int32 codie = CodIE;
                    Int32 cnino = n.CodNino;

                    oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, Convert.ToString(txt_FechaIngreso.Text), Convert.ToString(n.FechaNacimiento));
                    Session["NNA"] = NNA;


                }

                lblmsgSuccess.Text = "Ingreso Realizado Satisfactoriamente";
                lblmsgSuccess.Visible = true;
                alerts2.Visible = true;
                Response.Write("<script language='javascript'>alert('Ingreso Realizado Satisfactoriamente. ');</script>");
                clean_form();
                clean_tab();



                sqlt.Commit();
                sconn.Close();
               }
               catch (Exception ex)
               {
                   // Handle the exception if the transaction fails to commit.
                   Response.Write("<script language='javascript'>alert('Ingreso no realizado, intentar nuevamene.');</script>");
                   Console.WriteLine(ex.Message);

                   try
                   {
                       // Attempt to roll back the transaction.
                       sqlt.Rollback();
                   }
                   catch (Exception exRollback)
                   {
                       // Throws an InvalidOperationException if the connection 
                       // is closed or the transaction has already been rolled 
                       // back on the server.
                       Response.Write("<script language='javascript'>alert('Ingreso Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                       Console.WriteLine(exRollback.Message);
                   }
               }
            }

        }
        else
        {
            Response.Write("<script language='javascript'>alert('Ingreso Realizado');</script>");
        }


    }

    public void ActualizoListaEspera(int ICodIE, int ICodIngresoListaEspera)
    {
        try
        {
            ninocoll ncoll = new ninocoll();
            DataTable dt = ncoll.callto_update_ListaEspera(ICodIE, ICodIngresoListaEspera);
            if (txt_ICodIngresoLE.Text != string.Empty)
            {
                txt_ICodIngresoLE.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnsaveingreso_Click(object sender, EventArgs e)
    {
        muestra_pestaña(5);
        //////uno////

        ninocoll ncoll = new ninocoll();
        int cuenta = ncoll.callto_get_ninoingresado(SSnino.CodProyecto, 0, SSnino.CodNino);

        if (cuenta == 0 && SSnino.CodProyecto != 0 && SSnino.CodNino != 0)
        {
            string Expediente;
            string ruc;
            string rit;

            //tbtnsaveingreso.Visible = false;
            

            if (validatedata(0, true))// && comuna == true)
            {
                lblbmsg.Text = "Faltan datos para completar el Ingreso en las siguentes pestañas:";
                lblbmsg.Visible = true;                
                alerts.Visible = true;
            }
            else
            {
                lblbmsg.Visible = false;
                lblpestana1.Visible = false;
                alerts.Visible = false;

                string lesiones = "SI";
                if (rdo005.Checked)
                {
                    lesiones = "NO";
                }

                string ordenenesdeltribunal = "SI";
                if (rdo_OrdenTribunal_SI.Checked)
                {
                    ordenenesdeltribunal = "SI";
                }
                else if (rdo_OrdenTribunal_EnTramite.Checked)
                {
                    ordenenesdeltribunal = "ET";
                }
                else if (rdo_OrdenTribunal_NO.Checked)
                {
                    ordenenesdeltribunal = "NO";
                }

                if (WebTextEdit2.Text.Trim() == "")
                {
                    Expediente = Convert.ToString(0);
                }
                else
                {
                    Expediente = WebTextEdit2.Text.Trim();
                }

                if (txt006F2.Text.Trim() == "")
                {
                    ruc = Convert.ToString(0);
                }
                else
                {
                    ruc = txt006F2.Text.Trim();
                }

                if (txt006F2.Text.Trim() == "")
                {
                    rit = Convert.ToString(0);
                }
                else
                {
                    rit = txt006F2.Text.Trim();
                }

                

                # region InsertNino

                SqlTransaction sqlt;
               
                SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                sconn.Open();
                sqlt = sconn.BeginTransaction();
                try
                {


                    ////// ICODIE 
                    int CodIE = ncoll.SetIngresos_Egresos(sqlt,
                    SSnino.CodProyecto,
                    SSnino.CodNino,
                    Convert.ToDateTime(txt_FechaIngreso.Text),  // fecha ingreso
                    utabgetvalue(ddown013),                     // cod solicitante ingreso
                    CheckBox1.Checked,                          //identidad confirmada             
                    utabgetvalue(ddl_TipoAtencion),                     //cod tipo atencion
                    utabgetvalue(ddl_CalidadJuridica),                     //cod calidad juridica
                    0,                                          //Codinstitucioninmueble
                    utabgetvalue(ddl_Inmueble),                //ICodInmueble

                    Convert.ToInt32(WebNumericEdit1.Text),      //edad año                 
                    Convert.ToInt32(WebNumericEdit2.Text),      //edad meses               

                    utabgetvalue(ddown008),                     // cod tipo relacion con quien vive
                    WebTextEdit1.Text.ToString(),               //13 PersonaContacto,
                    TextBox1.Text.ToString(),                   //14 TelefonoContacto, 
                    utabgetvalue(ddown009),                     //15 CodTipoRelacionPersonaContacto,/*nuevo*/
                    utabgetvalue(ddown008),                    //16 CodInstitucion_Entreveistador,   

                    utabgetvalue(ddl_Entrevistador),                     //17 CodTrabajador_Entrevistador,     
                    utabgetvalue(ddown011),                     //18 CodTrabajador_Revisador,         
                    chk002.Checked,                             //IngresoComunicadoFamiliaUOtro,  
                    string.Empty,                               //HuellaDigital,                
                    lesiones,                                   //PresentaLesiones, 
                    ordenenesdeltribunal,                       //OrdenesTribunal, 
                    DateTime.Now,                               //FechaActualizacion, 
                    Convert.ToInt32(UserId),         //IdUsuarioActualizacion, 
                    Convert.ToDateTime("01-01-1900"),           //FechaEgreso, 
                    "0", 0, "0", 0, 0, 0, 0, 0);                //


                   


                    if (Session["listadeespera"] != null)
                    {
                        ActualizoListaEspera(CodIE, Convert.ToInt32(txt_ICodIngresoLE.Text));
                    }

                    diagnosticoscoll dcoll = new diagnosticoscoll();

                    int iden = dcoll.Insert_DiagnosticoGeneralTransaccional(sqlt, 1, SSnino.CodNino, CodIE
                        , Convert.ToDateTime(txt_FechaIngreso.Text));

                    int ultimoanocursado;
                    if (txt003a.Text.Trim() == "")
                    {
                        ultimoanocursado = 0;
                    }
                    else
                    {
                        ultimoanocursado = Convert.ToInt32(txt003a.Text);
                    }

                    dcoll.Insert_DiagnosticosEscolarTransaccional(sqlt,
                        iden,                                   //CodDiagnostico, 
                        DateTime.Now,                           //FechaCreacion, 
                        utabgetvalue(ddl_Escolaridad),                 //CodEscolaridad, 
                        Convert.ToDateTime(txt_FechaIngreso.Text),      //FechaDiagnostico,
                        utabgetvalue(ddl_Entrevistador),                 //ICodTrabajador, 
                        Convert.ToInt32(ddown008.SelectedValue),    //CodInstitucion_Entrevistador, 
                        utabgetvalue(ddl_Entrevistador),                 //CodTrabajador_Entrevistador, 
                        utabgetvalue(ddl_TipoAsistenciaEscolar),                 //TipoAsistenciaEscolar, 
                        ultimoanocursado,                       //AnoUltimoCursoAprobado, 

                        txt003b.Text,                           //Observaciones, 
                        Convert.ToBoolean(1),                   //AlIngreso, 
                        DateTime.Now,                           //FechaActualizacion, 
                        Convert.ToInt32(UserId));    //IdUsuarioActualizacion)



                    ncoll.Insert_DireccionNinosTransaccional(sqlt,
                        CodIE,
                        Convert.ToInt32(ddl_Proyecto.SelectedValue) //CodProyecto, 
                        , SSnino.CodNino
                        , Convert.ToDateTime(txt_FechaIngreso.Text)     //FechaIngresoDireccion, 
                        , txt003b.Text                          //Direccion, 
                        , TextBox1.Text.Trim()                    //Telefono, 
                        , Convert.ToString("0")                 //TelefonoRecado, 
                        , Convert.ToString("0")                 //Mail, 
                        , Convert.ToString("0")                 //Fax, 
                        , Convert.ToInt32("0")                  //CodigoPostal, 
                        , utabgetvalue(ddown007)                //CodComuna, 
                        , Convert.ToBoolean(1)
                        , DateTime.Now
                        , Convert.ToInt32(UserId)
                        , "V");



                    if (grd001.Rows.Count != 0)
                    {
                        ////////////////////LISTO

                        for (int i = 0; i < DTordentribunales.Rows.Count; i++)
                        {
                            ncoll.Insert_OrdenTribunalIngresoTransaccional(sqlt,
                            CodIE,
                            Convert.ToInt32(DTordentribunales.Rows[i][0]),
                            Convert.ToDateTime(DTordentribunales.Rows[i][2]),
                            Convert.ToInt32(UserId),
                            Convert.ToString(DTordentribunales.Rows[i][3]),
                            Convert.ToString(DTordentribunales.Rows[i][4]),
                            Convert.ToString(DTordentribunales.Rows[i][5]));
                        }

                    }




                    if (grd002.Rows.Count != 0)
                    {
                        for (int j = 0; j < DTcausales.Rows.Count; j++)
                        {

                            ncoll.Insert_CausalesIngresoTransaccional(sqlt,
                                CodIE,
                                Convert.ToInt32(DTcausales.Rows[j][1]),
                                Convert.ToInt32(DTcausales.Rows[j][5]),
                                Convert.ToString(DTcausales.Rows[j][4]),
                                DateTime.Now,
                                Convert.ToInt32(UserId),
                                0);

                        }
                    }

                    if (grd003.Rows.Count != 0)
                    {

                        for (int k = 0; k < DTlesiones.Rows.Count; k++)
                        {

                            ncoll.Insert_DetalleLesionesTransaccional(sqlt,
                                CodIE,
                                Convert.ToInt32(DTlesiones.Rows[k][0]),
                                Convert.ToInt32(DTlesiones.Rows[k][1]),
                                Convert.ToString(DTlesiones.Rows[k][4]),
                                DateTime.Now,
                                Convert.ToInt32(UserId),
                                Convert.ToInt32(DTlesiones.Rows[k][5]));

                        }
                    }
                    FechaIngreso = Convert.ToDateTime(txt_FechaIngreso.Text);
                    ninocoll cons33 = new ninocoll();
                    DataTable dt33 = cons33.trae_tipousuario_Ninos(Convert.ToInt32(SSnino.CodNino));
                    int tusuario = Convert.ToInt32(dt33.Rows[0][0]);


                    ////*************************** SECCION NO LISTA *****************************///

                    if ((tipo == "PAG"))
                    {
                        try
                        {

                            if (tusuario != -1 || tusuario == 0)
                            {
                                DateTime fechaact = DateTime.Now;
                                ninocoll cons44 = new ninocoll();
                                DataTable dt44 = cons44.trae_codinstitucion_inmueble(CodIE);
                                int codinst_inmu = Convert.ToInt32(dt44.Rows[0][0]);

                                ninocoll cons55 = new ninocoll();

                                DataTable dt55 = cons55.trae_codTrabajador(Convert.ToInt32(UserId));
                                int cod_tra = Convert.ToInt32(dt55.Rows[0][0]);


                                ninocoll ins9 = new ninocoll();
                                Cod_Interv = ins9.Insert_Plan_intervencion_PAG(
                                    Convert.ToInt32(CodIE),
                                    Convert.ToInt32(SSnino.CodProyecto),
                                    Convert.ToInt32(SSnino.CodNino),

                                    Convert.ToDateTime(txt_FechaIngreso.Text),
                                    Convert.ToInt32(codinst_inmu),
                                    Convert.ToInt32(cod_tra),
                                    Convert.ToInt32(UserId),

                                    Convert.ToDateTime(fechaact),
                                    Convert.ToInt32(cod_tra),
                                    0
                                );                                


                            }
                        }
                        catch
                        {
                            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Plan Intervencion PAG. ');</script>");
                        }

                        try
                        {
                            ninocoll ins11 = new ninocoll();
                            ins11.Insert_Intervenciones_PAG(
                                Convert.ToInt32(Cod_Interv),
                                Convert.ToInt32(40),
                                Convert.ToDateTime(DateTime.Now)
                            );

                        }
                        catch
                        {
                            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Intervenciones. ');</script>");
                        }

                        try
                        {

                            ninocoll ins12 = new ninocoll();
                            ins12.Insert_Estados_Intervenciones_PAG(
                                Convert.ToInt32(Cod_Interv),
                                Convert.ToDateTime(DateTime.Now)
                            );
                        }
                        catch
                        {
                            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Estados plan intervencion. ');</script>");
                        }

                    }
                # endregion

                    ////*************************** SECCION NO LISTA *****************************///





                    if (SSnino.sexo == null)
                    {
                        SSnino.sexo = Convert.ToString('A');
                    }

                    ncoll.Cierre_ingresoTransaccional(sqlt,
                        CodIE,
                        SSnino.CodProyecto,
                        Convert.ToDateTime(txt_FechaIngreso.Text),
                        SSnino.CodNino,
                        SSnino.sexo,
                        Convert.ToInt32(UserId));

                    if (Session["NNA"] == null)
                    {
                        nino n = ncoll.GetDataTransactional(sqlt, SSnino.CodNino.ToString(), "0");

                        string cinst = SSnino.CodInst.ToString();
                        string cproy = SSnino.CodProyecto.ToString();
                        string rut = n.rut;
                        Int32 codie = CodIE;
                        Int32 cnino = n.CodNino;

                        oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, Convert.ToString(txt_FechaIngreso.Text), Convert.ToString(n.FechaNacimiento));
                        Session["NNA"] = NNA;

                        
                    }


                    lblmsgSuccess.Text = "Ingreso Realizado Satisfactoriamente";
                    lblmsgSuccess.Visible = true;
                    alerts2.Visible = true;
                    Response.Write("<script language='javascript'>alert('Ingreso Realizado Satisfactoriamente. ');</script>");

                    sqlt.Commit();
                    sconn.Close();

                    Alerta a = new Alerta();

                    a.CodNino = SSnino.CodNino;
                    a.ICodIE = CodIE;
                    a.IdUsrTermino = Convert.ToInt32(Session["IdUsuario"]);
                    a.CodRol = Session["contrasena"].ToString();
                    a.CodProyecto = SSnino.CodProyecto;

                    cerrarAlerta(a);

                    clean_form();
                    clean_tab();
                    LimpiaControles();



                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Response.Write("<script language='javascript'>alert('Ingreso no realizado, intentar nuevamene.');</script>");
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlt.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection 
                        // is closed or the transaction has already been rolled 
                        // back on the server.
                        Response.Write("<script language='javascript'>alert('Ingreso Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('Ingreso Realizado. ');</script>");

        }
    }

    private void cerrarAlerta(Alerta alerta)
    {
        
        IAlertas alertaListaEsperaPorAbuso = new AlertaListaEsperaPorAbuso();
        IAlertas alertasEgresoxTraslado = new AlertaEgresoxTraslado();

        alertaListaEsperaPorAbuso.ActualizarAlerta(alerta);
        alertasEgresoxTraslado.ActualizarAlerta(alerta);
    }

    private void LimpiaControles()
    {

        txt_FechaInicioSancionLRPA.Text = null;
        txt001LRPA.Text = "";
        txt002LRPA.Text = "";
        txt007LRPA.Text = "";
        txt003LRPA.Text = "";
        Chk002LRPAMixta.Checked = false;
        txt004LRPA.Text = "";
        txt005LRPA.Text = "";
        txt008LRPA.Text = "";
        txt006LRPA.Text = "";
        ddown009LRPA.Text = null;
        if (ddown011LRPA.Items.Count > 0)
        {
            ddown011LRPA.SelectedIndex = 0;
        }
        ddown003LRPA.SelectedValue = "-2";
        ddown004LRPA.SelectedValue = "0";
        ddown005LRPA.SelectedValue = "0";
        ddown006LRPA.SelectedValue = "0";

        chk001LRPA.Checked = false;

        ddown006LRPA.Visible = false;
        tr_tipo_sancion_accesoria.Visible = false;
        btnAgregarTsancionLRPA.Visible = false;

        if (DTcausales != null)
        { DTcausales.Clear(); }
        if (DTlesiones != null)
        { DTlesiones.Clear(); }
        if (DTordentribunales != null)
        { DTordentribunales.Clear(); }
        if (DTTipoSancionAccesoria != null)
        { DTTipoSancionAccesoria.Clear(); }
        if (dt_coning != null)
        { dt_coning.Clear(); }

        DataTable dtCL = new DataTable();
        dtCL.Rows.Clear();
        grd001LRPA.DataSource = dtCL;
        grd_LRPA02.DataSource = dtCL;
        grd001.DataSource = dtCL;
        grd002.DataSource = dtCL;
        grd003.DataSource = dtCL;
        grd003.DataBind();
        grd002.DataBind();
        grd001.DataBind();
        grd001LRPA.DataBind();
        grd_LRPA02.DataBind();

        ddown_otc.Items.Clear();
        ddl_OrdenDeTribunal_MedidaSancion.Items.Clear();

        ListItem oItem = new ListItem("Seleccionar", "0");
        ddown_otc.Items.Add(oItem);
        ddl_OrdenDeTribunal_MedidaSancion.Items.Add(oItem);

        ddl_OrdenDeTribunal_MedidaSancion.Visible = false;
        tabla_OrdenTribunal.Visible = false;
        

        lbl_otm.Visible = false;

        rdo_OrdenTribunal_SI.Checked = false;
        rdo_OrdenTribunal_EnTramite.Checked = false;
        rdo_OrdenTribunal_NO.Checked = false;
        rdo004.Checked = false;
        rdo005.Checked = false;

        rdo_OrdenTribunal_SI.Enabled = true;
        rdo_OrdenTribunal_EnTramite.Enabled = true;
        rdo_OrdenTribunal_NO.Enabled = true;
        rdo004.Enabled = true;
        rdo005.Enabled = true;

        titulo_datos_nino.Visible = false;
        pnl002.Visible = false;
        pnl1LRPA.Visible = false;
        pnlLRPAmixta.Visible = false;
        chk002.Checked = false;

        //utab.ActiveTabIndex = 0;

        //btnpanel1.Visible = true;
        //btnpanel1.Enabled = true;

        link_tab1.Attributes.Add("style", "display: block");

        link_tab1.Attributes.Add("data-toggle", "tab");
        link_tab1.Attributes.Remove("Class");




    }

    public void getparcausales(int codtipocausal)
    {
        parcoll par = new parcoll();
        DataView dv16 = new DataView(par.GetparCausalesIngreso(codtipocausal.ToString(),SSnino.CodProyecto));

        ddl_CausalIngreso.Items.Clear();
        ddl_CausalIngreso.DataSource = dv16;
        ddl_CausalIngreso.DataTextField = "Descripcion";
        ddl_CausalIngreso.DataValueField = "CodCausalIngreso";
        dv16.Sort = "Descripcion";
        ddl_CausalIngreso.DataBind();

        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        ninocoll cons = new ninocoll();
        DataTable dt = cons.filtro_DEPRODE_ADOPCION(SSnino.CodProyecto);
        if (codtipocausal.ToString() != "9" && codtipocausal.ToString() != "0")
        {
            if (dt.Rows.Count > 0)
            {

                int codsan = codtipocausal;
                ninocoll cons2 = new ninocoll();
                DataTable dt2 = cons2.filtro_LPRA_SANCION2(codsan);

                if (Convert.ToInt32(dt2.Rows[0][0]) == 1)
                {

                    tipo = Convert.ToString(dt.Rows[0][0]);
                    int est = 0;
                    int res;
                    int n1;
                    int n2;
                    DateTime a1;
                    ninocoll cons03 = new ninocoll();
                    DataTable dt03 = cons03.consulta_LPRA_ADOPCION(Convert.ToString(txt001.Text), Convert.ToString(SSnino.CodNino));

                    a1 = Convert.ToDateTime(dt03.Rows[0][0]);

                    DateTime a2 = DateTime.Now;
                    n1 = Convert.ToInt32(a1.Year);
                    n2 = Convert.ToInt32(a2.Year);
                    res = (n2 - n1);
                    if ((Convert.ToDateTime(dt03.Rows[0][0])).Year == 1800)
                    {
                        est = 1;
                    }

                    if ((res < 14) || (est == 1))
                    {
                        window.open(Page, "../filtro_lrpa.aspx", 450, 230);
                    }

                }
            }

        }
        else
        {
            //tddown018.SelectedValue = "9";
        }

        //DropDownList tddown_123 = (DropDownList)utab.FindControl("ddown_tsancion");
        //tddown021.Items.Clear();
        //tddown021.DataSource = dv16;
        //tddown021.DataTextField = "CodCausalIngreso";
        //tddown021.DataValueField = "CodCausalIngreso";
        //dv16.Sort = "CodCausalIngreso";
        //tddown021.DataBind();


    }


    protected void ddown018_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(4);
        diagnosticoscoll dcoll = new diagnosticoscoll();

        int codtipocausal = Convert.ToInt32(ddl_TipoCausalIngreso.SelectedValue);
        getparcausales(codtipocausal);
        //Fabian Requerimiento Ingreso de Niño y Datos de Gestion
        // Habilitar cuando se liberen las nuevas causales de ingreso, no olvidar crear el procedimiento almacenado
        //DataTable dt = dcoll.GetDescripcionTipoCausal(codtipocausal);

        //if (dt.Rows.Count == 0)
        //{
        //    txt_descripcionTCI.Text = "Ingrese Tipo Causal De Ingreso";
        //}
        //else
        //{
        //    //antes de agregar verifica si hay datos para no mostrar el 0
        //    if (Convert.ToString(dt.Rows[0][0]) == "0" || Convert.ToString(dt.Rows[0][0]) == "")
        //    {
        //        txt_descripcionTCI.Text = "Sin datos";
        //    }
        //    else
        //    {
        //        txt_descripcionTCI.Text = Convert.ToString(dt.Rows[0][0]);
        //    }
        //}
    }
    protected void btn002_Click(object sender, EventArgs e)
    {
        muestra_pestaña(4);
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        DataRow dr = DTcausales.NewRow();
        bool sw = FiltroLRPA();
        lbl_causales.Text = "";
        int n = 3;
        if (sw)
            n = 10;

        bool validaOT = false;
        if (sw && rdo_OrdenTribunal_SI.Checked)
        {
            if (ddown_otc.SelectedValue == "0")
            {
                validaOT = true;
            }
            else
            {
                validaOT = false;
            }
        }
        else
        {
            validaOT = false;
        }

        if (ddl_CausalIngreso.SelectedIndex == 0)
        {
            lbl_causales.Text = "Debe seleccionar una causal de ingreso";
            lbl_causales.Visible = true;
            ddl_CausalIngreso.BackColor = colorCampoObligatorio;
            return;
        }
        else
            ddl_CausalIngreso.BackColor = System.Drawing.Color.Empty;


        if (!validaOT)
        {
            ddown_otc.BackColor = System.Drawing.Color.Empty;
            if (grd002.Rows.Count != 0)
            {

                bool swf = false;

                if (grd002.Rows.Count == 2)
                {
                    if ((grd002.Rows[1].Cells[3].Text) == Convert.ToString(ddl_CausalIngreso.SelectedItem))
                    {
                        lbl_causales.Text = "Esta Causal ya existe, Ingrese una distinta";
                        lbl_causales.Visible = true;
                        swf = true;

                    }
                }


                for (int j = 0; j < grd002.Rows.Count; j++)
                {
                    if (Server.HtmlDecode((grd002.Rows[j].Cells[3].Text)) != Convert.ToString(ddl_CausalIngreso.SelectedItem) && swf == false) //|| (grd002.Rows[1].Cells[2].Text) != Convert.ToString(tddown018.SelectedItem))
                    {
                        dr[0] = Convert.ToInt32(ddl_TipoCausalIngreso.SelectedValue);
                        dr[1] = Convert.ToInt32(ddl_CausalIngreso.SelectedValue);
                        dr[2] = ddl_TipoCausalIngreso.SelectedItem.Text;
                        dr[3] = ddl_CausalIngreso.SelectedItem.Text;
                        dr[4] = ddown020.SelectedItem.Text;
                        dr[5] = DTcausales.Rows.Count + 1;
                        dr[6] = txt006.Text.Trim();
                        if ((sw) && rdo_OrdenTribunal_SI.Checked)
                        {
                            dr[7] = ddown_otc.SelectedValue;
                        }
                        else
                        {
                            dr[7] = "0";
                        }
                        if (DTcausales.Rows.Count < n)
                        {
                            DTcausales.Rows.Add(dr);
                        }
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
                lbl_causales.Text = "";
                dr[0] = Convert.ToInt32(ddl_TipoCausalIngreso.SelectedValue);
                dr[1] = Convert.ToInt32(ddl_CausalIngreso.SelectedValue);
                dr[2] = ddl_TipoCausalIngreso.SelectedItem.Text;
                dr[3] = ddl_CausalIngreso.SelectedItem.Text;
                dr[4] = ddown020.SelectedItem.Text;
                dr[5] = DTcausales.Rows.Count + 1;
                dr[6] = txt006.Text.Trim();
                if ((sw) && rdo_OrdenTribunal_SI.Checked)
                {
                    dr[7] = ddown_otc.SelectedValue;
                }
                else
                {
                    dr[7] = "0";
                }

                if (DTcausales.Rows.Count < n)
                {
                    DTcausales.Rows.Add(dr);
                }
            }

            if (!sw || !rdo_OrdenTribunal_SI.Checked)
            {
                grd001.Columns[6].Visible = false;
            }
            DataView dv = new DataView(DTcausales);
            grd002.DataSource = dv;
            dv.Sort = "prioridad";
            grd002.DataBind();
            grd002.Visible = true;


            ddl_TipoCausalIngreso.SelectedValue = Convert.ToString(0);
            ddl_CausalIngreso.SelectedValue = Convert.ToString(0);
            if (!sw)
            { ddown020.SelectedValue = Convert.ToString(0); }
            txt006.Text = String.Empty;
        }
        else
        {
            ddown_otc.BackColor = colorCampoObligatorio;
        }

    }


    protected void lbtn004_Click(object sender, EventArgs e)
    {
        Inst = ddl_Institucion.SelectedValue;
        Proy = ddl_Proyecto.SelectedValue;

        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        //window.open(this.Page, "ninos_ingresonuevo.aspx", "", 550, 650, true);
    }



    protected void ddown001_ValueChanged(object sender, EventArgs e)
    {

        DateTime itime = Convert.ToDateTime(ddl_Institucion.SelectedValue);
        TimeSpan compare = itime.Date - SSnino.FechaNacimiento.Date;
        int y = Convert.ToInt32(compare.Days / 365);
        int m = (compare.Days - (y * 365)) / 30;

        txt001.Text = y.ToString();
        txt002.Text = m.ToString();

    }




    # region LEY DE RESPONSABILIDAD PENAL ADOLESCENTE (LRPA)

    private void LRPAcoll()
    {
        LRPAcoll LRPA = new LRPAcoll();
        parcoll pcoll = new parcoll();
        DataView dv = new DataView(pcoll.GetparRegion());
        ddown003LRPA.Items.Clear();
        ddown003LRPA.DataSource = dv;
        ddown003LRPA.DataTextField = "Descripcion";
        ddown003LRPA.DataValueField = "CodRegion";
        dv.Sort = "CodRegion";
        ddown003LRPA.DataBind();



        bool swLrpa = FiltroLRPA();

        if (swLrpa == true)
        {
            DataView dv0 = new DataView(LRPA.GetparTipoTribunalLRPA());
            ddown004LRPA.Items.Clear();
            ddown004LRPA.DataSource = dv0;
            ddown004LRPA.DataTextField = "Descripcion";
            ddown004LRPA.DataValueField = "TipoTribunal";
            dv0.Sort = "Descripcion";
            ddown004LRPA.DataBind();


        }
        else
        {
            DataView dv1 = new DataView(pcoll.GetparTipoTribunal());
            ddown004LRPA.Items.Clear();
            ddown004LRPA.DataSource = dv1;
            ddown004LRPA.DataTextField = "Descripcion";
            ddown004LRPA.DataValueField = "TipoTribunal";
            dv1.Sort = "Descripcion";
            ddown004LRPA.DataBind();


        }


    }

    protected void chk001LRPA_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        if (chk001LRPA.Checked)
        {

            LRPAcoll lrpa = new LRPAcoll();
            DataView dv2 = new DataView(lrpa.callto_getpartiposancionaccesoria());
            ddown006LRPA.DataSource = dv2;
            ddown006LRPA.DataTextField = "Descripcion";
            ddown006LRPA.DataValueField = "CodTipoSancionAccesoria";
            dv2.Sort = "Descripcion";
            ddown006LRPA.DataBind();
            ddown006LRPA.AppendDataBoundItems = false;

            DTTipoSancionAccesoria = new DataTable();
            DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodSancion", typeof(string)));
            DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodTipoSancionAccesoria", typeof(int)));
            DTTipoSancionAccesoria.Columns.Add(new DataColumn("Descripcion", typeof(int)));


            pnl1LRPA.Visible = true;
            btnAgregarTsancionLRPA.Visible = true;
            grd001LRPA.Visible = true;
            ddown006LRPA.Visible = true;
            tr_tipo_sancion_accesoria.Visible = true;
        }
        else
        {
            pnl1LRPA.Visible = false;
            btnAgregarTsancionLRPA.Visible = false;
            grd001LRPA.Visible = false;
            ddown006LRPA.Visible = false;
            tr_tipo_sancion_accesoria.Visible = false;
        }





    }


    protected void ddown004LRPA_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        parcoll pcoll = new parcoll();
        DataView dv2 = new DataView(pcoll.GetparTribunales(ddown003LRPA.SelectedValue, ddown004LRPA.SelectedValue));
        ddown005LRPA.Items.Clear();
        ddown005LRPA.DataSource = dv2;
        ddown005LRPA.DataTextField = "Descripcion";
        ddown005LRPA.DataValueField = "CodTribunal";
        dv2.Sort = "Descripcion";
        ddown005LRPA.DataBind();



    }




    protected void btnAgregarTsancionLRPA_Click(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        DataRow dr = DTTipoSancionAccesoria.NewRow();
        bool chk_rep = false;

        if (ddown006LRPA.SelectedValue != Convert.ToString(0))
        {
            for (int i = 0; i < grd001LRPA.Rows.Count; i++)
            {
                if (grd001LRPA.Rows[i].Cells[1].Text == ddown006LRPA.SelectedValue)
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                dr[0] = ddown006LRPA.SelectedItem;
                dr[1] = Convert.ToInt32(ddown006LRPA.SelectedValue);
                dr[2] = 3;

                DTTipoSancionAccesoria.Rows.Add(dr);
                DataView dv = new DataView(DTTipoSancionAccesoria);
                grd001LRPA.DataSource = dv;
                dv.Sort = "CodSancion";
                grd001LRPA.DataBind();
                grd001LRPA.Visible = true;

                ddown006LRPA.SelectedValue = Convert.ToString(0);
                ddown006LRPA.BackColor = System.Drawing.Color.Empty;
                lbl_avisoLRPA.Visible = false;
            }
            else
            {
                lbl_avisoLRPA.Text = "La sanción seleccionada ya ha sido ingresada";
                lbl_avisoLRPA.Visible = true;
            }
        }
        else
        {
            //ddown006LRPA.BackColor = colorCampoObligatorio;
            lbl_avisoLRPA.Text = "Seleccione una opción válida";
            lbl_avisoLRPA.Visible = true;

        }



    }

    protected void txt001LRPA_ValueChange(object sender, EventArgs e)
    {

        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");
        int mesfin = 0;
        int anofin = 0;

        if (txt_FechaInicioSancionLRPA.Text.ToUpper() != "")
        {
            fechainiciosancion = Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text);
            lblfechaini1LRPA.Text = "";
            lblfechaini1LRPA.Visible = false; 


            if ((txt001LRPA.Text.Trim() == "" || txt001LRPA.Text.Trim() == "0") && txt002LRPA.Text.Trim() != "")
            {
                txt003LRPA.Text = fechainiciosancion.AddMonths(Convert.ToInt32(txt002LRPA.Text)).ToShortDateString();
                txt001LRPA.Text = "0";
                lbl_avisoDuracionLRPA.Text = "";
            }
            else if (txt002LRPA.Text.Trim() != "" && txt001LRPA.Text.Trim() != "")
            {
                //fechainiciosancion = Convert.ToDateTime(tddown001LRPA.Text);
                anofin = Convert.ToInt32(fechainiciosancion.AddYears(Convert.ToInt32(txt001LRPA.Text)).Year);//Convert.ToDateTime(txt001LRPA.Text));
                mesfin = Convert.ToInt32(fechainiciosancion.AddMonths(Convert.ToInt32(txt002LRPA.Text)).Month);//Convert.ToInt32(txt002LRPA.Text));

            }
            else if (txt001LRPA.Text.Trim() != "")
            {
                //fechainiciosancion = Convert.ToDateTime(tddown001LRPA.Text);
                anofin = Convert.ToInt32(fechainiciosancion.AddYears(Convert.ToInt32(txt001LRPA.Text)).Year);
                mesfin = Convert.ToInt32(fechainiciosancion.Month);
                lbl_avisoDuracionLRPA.Text = "";
            }
            else
            {
                lbl_avisoDuracionLRPA.Text = "Ingrese el periodo de la sanción";
            }
            try
            {
                // fechainiciosancion = Convert.ToDateTime(tddown001LRPA.Text);
                DateTime fechaterminosancion = Convert.ToDateTime(fechainiciosancion.Day + " - " + mesfin + " - " + anofin);
                txt003LRPA.Text = fechaterminosancion.ToShortDateString();
                //  tddown009LRPA.Text = fechaterminosancion.ToString();
                txt003LRPA.Enabled = false;
            }
            catch
            {
                txt003LRPA.Enabled = false;
            }

        }
        else
        {
            lblfechaini1LRPA.Text = "Ingrese Fecha de Inicio";
            lblfechaini1LRPA.Visible = true;
            txt001LRPA.Text = "";
            txt002LRPA.Text = "";
        }



    }







    protected void ddown001LRPA_ValueChanged(object sender, EventArgs e)
    {
        Calcula_Dias();
        SetFocus(dd_focus1);

    }

    protected void ddown009LRPA_ValueChanged(object sender, EventArgs e)
    {
        Calcula_Dias_Mix();

    }
    #endregion



    //protected void utab_TabClick(object sender, EventArgs e)
    //{
    //    DropDownList tdd_focus1 = (DropDownList)utab.FindControl("dd_focus1");
    //    try
    //    {
    //        SetFocus(tdd_focus1);

    //    }
    //    catch { };
    //}


    protected void ddown012_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(2);
        parcoll par = new parcoll();
        DataView dv12 = new DataView(par.GetparSolicitanteIngreso(utabgetvalue(ddl_TipoSolicitanteIngreso)));
        ddown013.Items.Clear();
        ddown013.DataSource = dv12;
        ddown013.DataTextField = "Descripcion";
        ddown013.DataValueField = "CodSolicitanteIngreso";
        dv12.Sort = "Descripcion";
        ddown013.DataBind();




    }
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = Convert.ToInt32(e.CommandArgument);
        DataRow dr01 = DTcausales.NewRow();
        DataRow dr02 = DTcausales.NewRow();
        DataRow dr03 = DTcausales.NewRow();
        DataRow dr04 = DTcausales.NewRow();

        for (int j = 0; j < DTcausales.Rows.Count; j++)
        {
            switch (Convert.ToInt32(DTcausales.Rows[j][5]))
            {
                case 1:
                    dr01 = DTcausales.Rows[j];
                    break;

                case 2:
                    dr02 = DTcausales.Rows[j];
                    break;

                case 3:
                    dr03 = DTcausales.Rows[j];
                    break;

                case 4:
                    dr04 = DTcausales.Rows[j];
                    break;


            }


        }

        switch (e.CommandName)
        {
            case "QUITAR":
                DTcausales.Rows.Remove(DTcausales.Rows[i]);

                break;
            case "SUBIR":
                if (i == 1)
                {
                    dr02[5] = 1;
                    dr01[5] = 2;
                }
                else if (i == 2)
                {
                    dr03[5] = 2;
                    dr02[5] = 3;
                }
                else if (i == 3)
                {
                    dr04[5] = 3;
                    dr03[5] = 4;
                }

                break;
            case "BAJAR":
                if (i == 0)
                {
                    dr01[5] = 2;
                    dr02[5] = 1;
                }
                else if (i == 1)
                {
                    dr02[5] = 3;
                    dr03[5] = 2;
                }
                else if (i == 2)
                {
                    dr03[5] = 4;
                    dr04[5] = 3;
                }

                break;

        }
        DataView dv = new DataView(DTcausales);
        grd002.DataSource = dv;
        dv.Sort = "prioridad";
        grd002.DataBind();
        grd002.Visible = true;
    }

    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(2);

        rdo_OrdenTribunal_SI.BackColor = System.Drawing.Color.Transparent;
        rdo_OrdenTribunal_EnTramite.BackColor = System.Drawing.Color.Transparent;
        rdo_OrdenTribunal_NO.BackColor = System.Drawing.Color.Transparent;
        //utab.Tabs[2].ForeColor = System.Drawing.Color.Black;
        pnl_rdo_orden_tribunal.ForeColor = System.Drawing.Color.Black;
        link_tab3.Attributes.Remove("Class");

        //proyectocoll pcoll = new proyectocoll();
        //DataTable dtproyecto = pcoll.GetProyectos(SSnino.CodProyecto.ToString());

        if (DTProyecto.Rows.Count > 0)
        {
            if (DTProyecto.Rows[0]["TipoProyecto"].ToString() == "7" || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "92" ||
                DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "142" || DTProyecto.Rows[0]["CodModeloIntervencion"].ToString() == "81") // 81 prj solicitado el 29-06-2016
            {
                rdo_OrdenTribunal_SI.Checked = true;
                rdo_OrdenTribunal_SI.Enabled = true;
                tbl_orden_tribunal.Visible = false;
                rdo001_CheckedChanged(sender, e);
            }
            else
            {
                if (utabgetvalue(ddl_CalidadJuridica) == 9) // no interviene tribunal
                {
                    Panel1.Visible = false;  // rdo_ordentribunal_no checked

                    rdo_OrdenTribunal_SI.Checked = false;
                    rdo_OrdenTribunal_EnTramite.Checked = false;
                    rdo_OrdenTribunal_NO.Checked = true;

                    rdo_OrdenTribunal_SI.Enabled = false;
                    rdo_OrdenTribunal_EnTramite.Enabled = false;
                    rdo_OrdenTribunal_NO.Enabled = false;
                }
                else
                {
                    if (utabgetvalue(ddl_CalidadJuridica) == 28) // 80 bis
                    {

                        rdo001_CheckedChanged(sender, e);  // rdo_ordentribunal_no checked
                        muestra_pestaña(2);
                        rdo_OrdenTribunal_SI.Enabled = false;
                        rdo_OrdenTribunal_EnTramite.Enabled = false;
                        rdo_OrdenTribunal_NO.Enabled = false;
                    }

                    else
                    {
                        bool swLrpa = FiltroLRPA();
                        if (!swLrpa)
                        {
                            tbl_orden_tribunal.Visible = true;

                            rdo_OrdenTribunal_SI.Checked = false;
                            rdo_OrdenTribunal_EnTramite.Checked = false;
                            rdo_OrdenTribunal_NO.Checked = false;

                            rdo_OrdenTribunal_SI.Enabled = true;
                            rdo_OrdenTribunal_EnTramite.Enabled = true;
                            rdo_OrdenTribunal_NO.Enabled = true;

                            Panel1.Visible = false;
                        }
                    }
                }
            }
        }       


        LRPAcoll codmod = new LRPAcoll();
        DataTable dt2 = codmod.GetCodModIntervencion(SSnino.CodProyecto);
        int codemod = Convert.ToInt32(dt2.Rows[0][0]);

        if (codemod == 103)
        {
            ddown_tsancion.Items.RemoveAt(1);
        }

        muestra_pestaña(2);

    }
    protected void lbtn005_Click(object sender, EventArgs e)
    {
        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        SSnino.Apellido_Paterno = Convert.ToString(txt003.Text.Trim());
        SSnino.Apellido_Materno = Convert.ToString(txt004.Text.Trim());
        SSnino.Nombres = Convert.ToString(txt005.Text.Trim());

        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;


        lbl001.Text = "";
        lbl001.Visible = false;
        lbl002.Visible = false;




    }


    protected void btnbind_Click1(object sender, EventArgs e)
    {
        //GetSelectedInfo();
    }


    protected void btn007_Click(object sender, EventArgs e)
    {
        SSnino.ICodinformediagnostico = VICodInfDiagnostico;
        window.open(this.Page, "accionesinformediagnostico.aspx", 550, 450);
    }

    protected void btn005_Click(object sender, EventArgs e)
    {

        window.open(this.Page, "ninos_nuevapersonarel.aspx", "", 550, 550, true);
    }


    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        parcoll par = new parcoll();
        DataView dv12 = new DataView(par.GetparSolicitanteIngreso());

        ddl_TipoAsistenciaEscolar.DataSource = dv12;
        ddl_TipoAsistenciaEscolar.DataTextField = "Descripcion";
        ddl_TipoAsistenciaEscolar.DataValueField = "CodTerminoDiagnostico";
        dv12.Sort = "Descripcion";
        ddl_TipoAsistenciaEscolar.DataBind();
    }



    private bool validate1()
    {
        bool v = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (ddl_Institucion.SelectedValue == "0")
        {

            ddl_Institucion.BackColor = colorCampoObligatorio;
            v = false;
        }

        if (ddl_Proyecto.SelectedValue == "0")
        {
            ddl_Proyecto.BackColor = colorCampoObligatorio;
            v = false;
        }
        return v;
    }



    protected void txt001_ValueChange(object sender, EventArgs e)
    {
        muestra_pestaña(2);
        parcoll par = new parcoll();
        DateTime itime = DateTime.Now;
        TimeSpan compare = itime.Date - SSnino.FechaNacimiento.Date;
        int y = Convert.ToInt32(compare.Days / 365);

        ddl_Escolaridad.Items.Clear();
        if (txt001.Text == "")
        {
            y = 0;

            DataView dv4 = new DataView(par.GetparEscolaridad(y));//, EdadNivel));

            ddl_Escolaridad.DataSource = dv4;
            ddl_Escolaridad.DataTextField = "Descripcion";
            ddl_Escolaridad.DataValueField = "CodEscolaridad";
            dv4.Sort = "CodEscolaridad";
            ddl_Escolaridad.DataBind();
        }
        else
        {

            DataView dv42F = new DataView(par.GetparEscolaridad(y));// Convert.ToInt32(ttxt001.Text)));

            ddl_Escolaridad.DataSource = dv42F;
            ddl_Escolaridad.DataTextField = "Descripcion";
            ddl_Escolaridad.DataValueField = "CodEscolaridad";
            dv42F.Sort = "CodEscolaridad";
            ddl_Escolaridad.DataBind();
        }


    }

    protected void txt003a_ValueChange(object sender, EventArgs e)
    {
        txt003a.Text = DateTime.Now.Year.ToString();
    }

    protected void btn004aa_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoEscolar.aspx", 770, 420);
    }


    protected void imb_004a_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoMaltrato.aspx", 770, 420);
    }
    protected void imb_004b_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoDroga.aspx", 770, 420);
    }
    protected void imb_005c_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoPsicologico.aspx", 770, 420);
    }
    protected void imb_004d_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoSocial.aspx", 770, 420);
    }
    protected void imb_004e_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoCapacitacion.aspx", 770, 420);
    }
    protected void imb_004f_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoSituacionLaboral.aspx", 770, 420);
    }
    protected void imb_004g_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoHechosJudiciales.aspx", 770, 420);
    }
    protected void btn004h_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoPeoresFormas.aspx", 770, 420);
    }

    protected void grd006_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string CodPersonaRelacionada = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        window.open(Page, "ninos_nuevapersonarel.aspx?CodPersonaRelacionada=" + CodPersonaRelacionada + "&sw=true", "", 550, 550, true);
    }



    protected void ddown019_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txt003a_ValueChange1(object sender, EventArgs e)
    {
        muestra_pestaña(2);
        if (txt003a.Text != "")
        {
            if (Convert.ToInt32(txt003a.Text.Trim()) > DateTime.Now.Year)
            {
                txt003a.Text = Convert.ToString(DateTime.Now.Year);

                //lbl_avisoano.Visible = true;
                //lbl_avisoano.Text = "El año no puede ser mayor al año en curso ";
            }
            if (Convert.ToInt32(txt003a.Text.Trim()) < DateTime.Now.Year - 100)
            {
                txt003a.Text = Convert.ToString(DateTime.Now.Year - 100);

                //lbl_avisoano.Visible = true;
                //lbl_avisoano.Text = "El año no puede ser mayor al año en curso ";
            }
        }
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_index.aspx", "Buscador", false, true, 770, 420, false, false, true);

    //}
    protected void chk002F2_DataBinding(object sender, EventArgs e)
    {
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;
    }

    protected void rdo001_DataBinding(object sender, EventArgs e)
    {
        Ninos_busqueda1.getgridinproyect(true, false, 0);
        Ninos_busqueda1.Visible = true;
    }



    // NO SE UTILIZA YA QUE NO VALIDA EL BOTON BUSCAR, SE COMPRUEBA MEDIANTE UNA VALIDACION

    //protected void txt001_ValueChange1(object sender, EventArgs e)
    //{
    //    if (txt001.Text.Trim() != "")
    //    {
    //        try
    //        {
    //            if (txt001.Text.Length > 3)
    //            {
    //                string rutsinnada = txt001.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1); //aca comienso a buscar usuario

    //                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //                {
    //                    lbl005.Visible = false;
    //                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                    txt001.Text = rcompleto;
    //                }
    //                else
    //                {
    //                    //txt001.Text = "";

    //                    lbl005.Text = "EL RUT INGRESADO NO ES VALIDO";
    //                    lbl005.Visible = true;
    //                }
    //            }
    //            else
    //            {
    //                //txt001.Text = "";
    //                lbl005.Text = "EL RUT INGRESADO NO ES VALIDO";
    //                lbl005.Visible = true;
    //            }
    //        }
    //        catch
    //        {
    //            lbl005.Text = "EL RUT INGRESADO NO ES VALIDO";
    //            lbl005.Visible = true;
    //        }
    //    }
    //    else
    //    {
    //        lbl005.Text = "";
    //        lbl005.Visible = false;
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

    protected void btnvolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_ninos/index_ninos.aspx", false);
    }


    #region Guarda y valida personaContacto Modifica
    protected void btn005aa_Click1(object sender, EventArgs e)
    {

    }


    #endregion

    #region Guarda y valida Ordenes tribunal Modifica
    protected void btn005aa_Click2(object sender, EventArgs e)
    {


    }

    #endregion


    #region Guarda y valida Causales de Ingreso Modifica
    protected void btnback003_Click(object sender, EventArgs e)
    {


    }


    # endregion

    private bool validamescerrado()
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        //if (WebDateChooser1.Text == "") 
        //    WebDateChooser1.Text = "01-01-1900";
        DateTime fecha = Convert.ToDateTime("01-01-1900");
        if (txt_FechaIngreso.Text != "")
            fecha = Convert.ToDateTime(txt_FechaIngreso.Text);
        string ano = Convert.ToDateTime(fecha).Year.ToString();
        string mes = Convert.ToDateTime(fecha).Month.ToString();

        if (mes.Length <= 1)
        {
            mes = 0 + mes;
        }


        int Periodo = Convert.ToInt32(ano + mes);
        int Estado_cierre = dcoll.callto_consulta_cierremes(Convert.ToInt32(ddl_Proyecto.SelectedValue), Periodo);

        if (Estado_cierre != 1)
        {
            lbl002b.Visible = false;
            return true;
        }
        else
        {

            lbl002b.Visible = true;
            return false;
        }
    }

    protected void ddown019_SelectedIndexChanged1(object sender, EventArgs e)
    {
        muestra_pestaña(4);
        parcoll pcoll = new parcoll();
        int codcausal = pcoll.GetparCausalesIngresoCodNumCausal(Convert.ToInt32(ddl_CausalIngreso.SelectedValue));
        txt006.Text = codcausal.ToString();


    }

    protected void Chk002LRPAMixta_CheckedChanged(object sender, EventArgs e)
    {
        muestra_pestaña(6);


        //if (Chk002LRPAMixta.Checked)
        //{
        //    ddown011LRPA.Items.Clear();
        //    LRPAcoll lrpa = new LRPAcoll();
        //    DataTable dt = lrpa.callto_get_parmodelosancionmixta();
        //    ddown011LRPA.DataSource = dt;
        //    ddown011LRPA.DataTextField = "Descripcion";
        //    ddown011LRPA.DataValueField = "CodModeloSancionMixta";
        //    ddown011LRPA.DataBind();

        //    if (txt003LRPA.Text.Trim() != "")
        //    {

        //        ddown009LRPA.Text = (Convert.ToDateTime(txt003LRPA.Text).AddDays(1)).ToString("dd/MM/yyyy");
        //        ddown009LRPA.Enabled = false;
        //        LblfechaLRPA.Text = "";
        //    }
        //    else
        //    {
        //        LblfechaLRPA.Text = "Ingrese fecha de primera sanción";
        //    }
        //    pnlLRPAmixta.Visible = true;
        //}
        //else
        //{
        //    pnlLRPAmixta.Visible = false;
        //}

        if (Chk002LRPAMixta.Checked)
        {
            if (txt003LRPA.Text.Trim() != "")
            {
                LblfechaLRPA.Text = "";
                ddown011LRPA.Items.Clear();
                LRPAcoll lrpa = new LRPAcoll();
                DataTable dt = lrpa.callto_get_parmodelosancionmixta(); 
                ddown011LRPA.DataSource = dt;
                ddown011LRPA.DataTextField = "Descripcion";
                ddown011LRPA.DataValueField = "CodModeloSancionMixta";
                ddown011LRPA.DataBind();

                //ddown009LRPA.Text = (Convert.ToDateTime(txt003LRPA.Text).AddDays(1)).ToString("dd/MM/yyyy");
                //ddown009LRPA.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ObtenerFechaTerminoSancionMixta()", true);

                pnlLRPAmixta.Visible = true;
            }
            else
            {
                LblfechaLRPA.Text = "Ingrese fecha de primera sanción";
                Chk002LRPAMixta.Checked = false;

                pnlLRPAmixta.Visible = false;
                txt004LRPA.Text = "";
                txt005LRPA.Text = "";
                txt008LRPA.Text = "";
                txt006LRPA.Text = "";
            }
        }
        else
        {
            pnlLRPAmixta.Visible = false;
            txt004LRPA.Text = "";
            txt005LRPA.Text = "";
            txt008LRPA.Text = "";
            txt006LRPA.Text = "";
        }

    }

    protected void imb005_Click1(object sender, ImageClickEventArgs e)
    {
        string Expediente;
        string ruc;
        string rit;

        

        if (validatedata(0, true))// && comuna == true)
        {

            lblbmsg.Text = "Faltan datos para completar el Ingreso en las siguentes pestañas:";
            lblbmsg.Visible = true;
            alerts.Visible = true;
        }
        else
        {
            lblbmsg.Visible = false;
            alerts.Visible = false;
            

            string lesiones = "SI";
            if (rdo005.Checked)
            {
                lesiones = "NO";
            }
            string ordenenesdeltribunal = "SI";
            if (rdo_OrdenTribunal_NO.Checked)
            {
                ordenenesdeltribunal = "NO";
            }
            if (rdo_OrdenTribunal_EnTramite.Checked)
            {
                ordenenesdeltribunal = "ET";
            }
            if (txt005.Text.Trim() == "")
            {
                Expediente = Convert.ToString(0);
            }
            else
            {
                Expediente = txt005.Text.Trim();
            }

            if (txt006F2.Text.Trim() == "")
            {
                ruc = Convert.ToString(0);
            }
            else
            {
                ruc = txt006F2.Text.Trim();
            }

            if (txt006F2.Text.Trim() == "")
            {
                rit = Convert.ToString(0);
            }
            else
            {
                rit = txt006F2.Text.Trim();
            }



            # region InsertNino

            SqlTransaction sqlt;

            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            sconn.Open();
            sqlt = sconn.BeginTransaction();

            try
            {
                ninocoll ncoll = new ninocoll();
                int CodIE = ncoll.SetIngresos_Egresos(sqlt,SSnino.CodProyecto, SSnino.CodNino,
                Convert.ToDateTime(ddl_Institucion.SelectedValue),
                utabgetvalue(ddown013), chk001.Checked, utabgetvalue(ddl_TipoAtencion),
                utabgetvalue(ddl_CalidadJuridica),
               0,
                utabgetvalue(ddl_Inmueble),

                Convert.ToInt32(txt001.Text),
                Convert.ToInt32(txt002.Text), utabgetvalue(ddown008),
                txt003.Text.ToString(),
                txt004.Text.ToString(),
                utabgetvalue(ddown009), utabgetvalue(ddown008),
                utabgetvalue(ddl_Entrevistador), utabgetvalue(ddown011), chk002.Checked,
                string.Empty,
                lesiones, ordenenesdeltribunal, DateTime.Now, Convert.ToInt32(UserId),
                Convert.ToDateTime("01-01-1900"), "0", 0, "0", 0, 0, 0, 0, 0);


                diagnosticoscoll dcoll = new diagnosticoscoll();

                int iden = dcoll.Insert_DiagnosticoGeneral(1, SSnino.CodNino, CodIE
                    , Convert.ToDateTime(ddl_Institucion.SelectedValue));

                int ultimoanocursado;
                if (txt003a.Text.Trim() == "")
                {
                    ultimoanocursado = 0;
                }
                else
                {
                    ultimoanocursado = Convert.ToInt32(txt003a.Text);
                }

                dcoll.Insert_DiagnosticosEscolar(iden, DateTime.Now,
                utabgetvalue(ddl_Escolaridad), Convert.ToDateTime(ddl_Institucion.SelectedValue), utabgetvalue(ddl_Entrevistador),
                Convert.ToInt32(ddl_Institucion.SelectedValue), utabgetvalue(ddl_Entrevistador), utabgetvalue(ddl_TipoAsistenciaEscolar), ultimoanocursado,
                txt003b.Text, Convert.ToBoolean(1), DateTime.Now, Convert.ToInt32(UserId));


                ncoll.Insert_DireccionNinos(CodIE, Convert.ToInt32(ddl_Proyecto.SelectedValue)
                , SSnino.CodNino, Convert.ToDateTime(ddl_Institucion.SelectedValue)
                , txt003b.Text, txt004.Text.Trim()
                , Convert.ToString("0"), Convert.ToString("0")
                , Convert.ToString("0"), Convert.ToInt32("0"), utabgetvalue(ddown007), Convert.ToBoolean(1), DateTime.Now
                , Convert.ToInt32(UserId), "V");



                if (grd001.Rows.Count != 0)
                {


                    for (int i = 0; i < DTordentribunales.Rows.Count; i++)
                    {
                        ncoll.Insert_OrdenTribunalIngreso(
                        CodIE,
                        Convert.ToInt32(DTordentribunales.Rows[i][0]),
                        Convert.ToDateTime(DTordentribunales.Rows[i][2]),
                        Convert.ToInt32(UserId),
                        Convert.ToString(DTordentribunales.Rows[i][3]),
                        Convert.ToString(DTordentribunales.Rows[i][4]),
                        Convert.ToString(DTordentribunales.Rows[i][5]));
                    }

                }




                if (grd002.Rows.Count != 0)
                {
                    for (int j = 0; j < DTcausales.Rows.Count; j++)
                    {

                        ncoll.Insert_CausalesIngreso(
                            CodIE,
                            Convert.ToInt32(DTcausales.Rows[j][1]),
                            Convert.ToInt32(DTcausales.Rows[j][5]),
                            Convert.ToString(DTcausales.Rows[j][4]),
                            DateTime.Now,
                            Convert.ToInt32(UserId), 0);

                    }
                }


                if (grd003.Rows.Count != 0)
                {

                    for (int k = 0; k < DTlesiones.Rows.Count; k++)
                    {

                        ncoll.Insert_DetalleLesiones(
                            CodIE,
                            Convert.ToInt32(DTlesiones.Rows[k][0]),
                            Convert.ToInt32(DTlesiones.Rows[k][1]),
                            Convert.ToString(DTlesiones.Rows[k][4]),
                            DateTime.Now,
                            Convert.ToInt32(UserId),
                            Convert.ToInt32(DTlesiones.Rows[k][5]));

                    }
                }

            # endregion


                if (SSnino.sexo == null)
                {
                    SSnino.sexo = Convert.ToString('A');
                }

                ncoll.Cierre_ingreso(CodIE, SSnino.CodProyecto,
                Convert.ToDateTime(ddl_Institucion.Text), SSnino.CodNino, SSnino.sexo, Convert.ToInt32(UserId));

                lblmsgSuccess.Text = "Ingreso Realizado Satisfactoriamente";
                lblmsgSuccess.Visible = true;
                alerts2.Visible = true;
                Response.Write("<script language='javascript'>alert('Ingreso Realizado Satisfactoriamente. ');</script>");
                clean_form();
                clean_tab();

            }
            catch (Exception ex)
            {
                // Handle the exception if the transaction fails to commit.
                Console.WriteLine(ex.Message);

                try
                {
                    // Attempt to roll back the transaction.
                    sqlt.Rollback();
                }
                catch (Exception exRollback)
                {
                    // Throws an InvalidOperationException if the connection 
                    // is closed or the transaction has already been rolled 
                    // back on the server.
                    Console.WriteLine(exRollback.Message);
                }
            }

        }
        
            
    }

    protected void lnk001_Click1(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        Calcula_Dias();
    }
    private void Calcula_Dias()
    {
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");

        if (txt_FechaInicioSancionLRPA.Text.ToUpper() != "")
        {
            fechainiciosancion = Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text);
            lblfechaini1LRPA.Text = "";
            lblfechaini1LRPA.Visible = false;

            if (txt001LRPA.Text.Trim() == "" && txt002LRPA.Text.Trim() == "" && txt007LRPA.Text.Trim() == "")
            {
                lbl_avisoDuracionLRPA.Text = "Ingrese al menos un parametro";
                lbl_avisoDuracionLRPA.Visible = true;

            }
            else
            {
                lbl_avisoDuracionLRPA.Visible = false;
                if (txt001LRPA.Text.Trim() == "")
                { txt001LRPA.Text = "0"; }
                if (txt002LRPA.Text.Trim() == "")
                { txt002LRPA.Text = "0"; }
                if (txt007LRPA.Text.Trim() == "")
                { txt007LRPA.Text = "0"; }
                if (txt009LRPA.Text.Trim() == "")
                { txt009LRPA.Text = "0"; }
                DateTime fechatermino = Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text).AddYears(Convert.ToInt32(txt001LRPA.Text.Trim()));
                fechatermino = fechatermino.AddMonths(Convert.ToInt32(txt002LRPA.Text.Trim()));
                fechatermino = fechatermino.AddDays(Convert.ToInt32(txt007LRPA.Text.Trim()));
                try
                {
                    fechatermino = fechatermino.AddDays(-Convert.ToInt32(txt009LRPA.Text.Trim()));
                }
                catch
                {
                    fechatermino = fechatermino.AddDays(0);
                }

                txt003LRPA.Text = fechatermino.ToShortDateString();

                if (ddown009LRPA.Text.ToUpper() != "")
                {
                    ddown009LRPA.Text = Convert.ToDateTime(txt003LRPA.Text).AddDays(1).ToShortDateString();
                    Calcula_Dias_Mix();
                }
            }


        }
        else
        {
            lblfechaini1LRPA.Text = "Ingrese Fecha de Inicio";
            lblfechaini1LRPA.Visible = true;
            txt001LRPA.Text = "";
            txt002LRPA.Text = "";

        }



    }
    protected void lnk002_Click(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        if (txt004LRPA.Text.Trim() == "" && txt005LRPA.Text.Trim() == "" && txt008LRPA.Text.Trim() == "")
        {
            lbl_avisoDuracion2LRPA.Text = "Ingrese al menos un parametro";
            lbl_avisoDuracion2LRPA.Visible = true;

        }
        else
        {
            Calcula_Dias_Mix();
        }
    }


    private void Calcula_Dias_Mix()
    {
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");

        if (ddown009LRPA.Text.ToUpper() != "")
        {
            fechainiciosancion = Convert.ToDateTime(ddown009LRPA.Text);
            lblfechaIni2LRPA.Text = "";
            lblfechaIni2LRPA.Visible = false;

            if (txt004LRPA.Text.Trim() == "" && txt005LRPA.Text.Trim() == "" && txt008LRPA.Text.Trim() == "")
            {
                //lbl_avisoDuracion2LRPA.Text = "Ingrese al menos un parametro";
                //lbl_avisoDuracion2LRPA.Visible = true;

            }
            else
            {
                lbl_avisoDuracion2LRPA.Visible = false;
                if (txt004LRPA.Text.Trim() == "")
                { txt004LRPA.Text = ""; }
                if (txt005LRPA.Text.Trim() == "")
                { txt005LRPA.Text = ""; }
                if (txt008LRPA.Text == "")

                { txt008LRPA.Text = ""; }

                DateTime fechatermino = Convert.ToDateTime(ddown009LRPA.Text).AddYears(Convert.ToInt32(txt004LRPA.Text.Trim()));
                fechatermino = fechatermino.AddMonths(Convert.ToInt32(txt005LRPA.Text.Trim()));
                try
                {
                    fechatermino = fechatermino.AddDays(Convert.ToInt32(txt008LRPA.Text.Trim()));
                }
                catch
                {
                    fechatermino = fechatermino.AddDays(0);
                }
                txt006LRPA.Text = fechatermino.ToShortDateString();

            }


        }
        else
        {
            lblfechaIni2LRPA.Text = "Ingrese Fecha de Inicio";
            lblfechaIni2LRPA.Visible = true;
            txt004LRPA.Text = "";
            txt005LRPA.Text = "";
            txt008LRPA.Text = "";

        }



    }

    protected void lnk_limpiaFechas_Click(object sender, EventArgs e)
    {

        txt001LRPA.Text = "";
        txt002LRPA.Text = "";
        txt003LRPA.Text = "";
        txt004LRPA.Text = "";
        txt005LRPA.Text = "";
        txt006LRPA.Text = "";
        txt007LRPA.Text = "";
        txt008LRPA.Text = "";
        txt009LRPA.Text = "";
        txt_FechaInicioSancionLRPA.Text = null;
        ddown009LRPA.Text = null;

        Chk002LRPAMixta.Checked = false;
        pnlLRPAmixta.Visible = false;
    }
    protected void imb005_Click(object sender, ImageClickEventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        int cuenta = ncoll.callto_get_ninoingresado(SSnino.CodProyecto, 0, SSnino.CodNino);

        if (cuenta == 0 && SSnino.CodProyecto != 0 && SSnino.CodNino != 0)
        {
            string Expediente;
            string ruc;
            string rit;


            if (validatedata(0, true))// && comuna == true)
            {

                lblbmsg.Text = "Faltan datos para completar el Ingreso en las siguentes pestañas:";
                lblbmsg.Visible = true;
                alerts.Visible = true;
                
            }
            else
            {
                lblbmsg.Visible = false;
                alerts.Visible = false;
                

                string lesiones = "SI";
                if (rdo005.Checked == true)
                {
                    lesiones = "NO";
                }
                string ordenenesdeltribunal = "SI";

                if (rdo_OrdenTribunal_NO.Checked == true)
                {
                    ordenenesdeltribunal = "NO";
                }
                if (rdo_OrdenTribunal_EnTramite.Checked)
                {
                    ordenenesdeltribunal = "ET";
                }
                if (txt005.Text.Trim() == "")
                {
                    Expediente = Convert.ToString(0);
                }
                else
                {
                    Expediente = (txt005.Text.Trim());
                }

                if (txt006F2.Text.Trim() == "")
                {
                    ruc = Convert.ToString(0);
                }
                else
                {
                    ruc = (txt007F2.Text.Trim());
                }

                if (txt007F2.Text.Trim() == "")
                {
                    rit = Convert.ToString(0);
                }
                else
                {
                    rit = (txt007F2.Text.Trim());
                }



                # region InsertNino
                 SqlTransaction sqlt;

            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            sconn.Open();
            sqlt = sconn.BeginTransaction();

            try
            {

                int CodIE = ncoll.SetIngresos_Egresos(sqlt,SSnino.CodProyecto, SSnino.CodNino,
                 Convert.ToDateTime(ddl_Institucion.SelectedValue),
                utabgetvalue(ddown013), chk001.Checked, utabgetvalue(ddl_TipoAtencion),
                utabgetvalue(ddl_CalidadJuridica),
               0,
                utabgetvalue(ddl_Inmueble),

                Convert.ToInt32(txt001.Text),
                Convert.ToInt32(txt002.Text), utabgetvalue(ddown008),
                txt003.Text.ToString(),
                txt004.Text.ToString(),
                utabgetvalue(ddown009), utabgetvalue(ddown008),
                utabgetvalue(ddl_Entrevistador), utabgetvalue(ddown011), chk002.Checked,
                string.Empty,
                lesiones, ordenenesdeltribunal, DateTime.Now, Convert.ToInt32(UserId),
                Convert.ToDateTime("01-01-1900"), "0", 0, "0", 0, 0, 0, 0, 0);


                diagnosticoscoll dcoll = new diagnosticoscoll();

                int iden = dcoll.Insert_DiagnosticoGeneral(1, SSnino.CodNino, CodIE
                    , Convert.ToDateTime(ddl_Institucion.Text));

                int ultimoanocursado;
                if (txt003a.Text.Trim() == "")
                {
                    ultimoanocursado = 0;
                }
                else
                {
                    ultimoanocursado = Convert.ToInt32(txt003a.Text);
                }

                dcoll.Insert_DiagnosticosEscolar(iden, DateTime.Now,
                utabgetvalue(ddl_Escolaridad), Convert.ToDateTime(ddl_Institucion.SelectedValue), utabgetvalue(ddl_Entrevistador),
                Convert.ToInt32(ddl_Institucion.SelectedValue), utabgetvalue(ddl_Entrevistador), utabgetvalue(ddl_TipoAsistenciaEscolar), ultimoanocursado,
                txt003b.Text, Convert.ToBoolean(1), DateTime.Now, Convert.ToInt32(UserId));


                ncoll.Insert_DireccionNinos(CodIE, Convert.ToInt32(ddl_Proyecto.SelectedValue)
                , SSnino.CodNino, Convert.ToDateTime(ddl_Institucion.SelectedValue)
                , txt003b.Text, txt004.Text.Trim()
                , Convert.ToString("0"), Convert.ToString("0")
                , Convert.ToString("0"), Convert.ToInt32("0"), utabgetvalue(ddown007), Convert.ToBoolean(1), DateTime.Now
                , Convert.ToInt32(UserId), "V");



                if (grd001.Rows.Count != 0)
                {


                    for (int i = 0; i < DTordentribunales.Rows.Count; i++)
                    {
                        ncoll.Insert_OrdenTribunalIngreso(
                        CodIE,
                        Convert.ToInt32(DTordentribunales.Rows[i][0]),
                        Convert.ToDateTime(DTordentribunales.Rows[i][2]),
                        Convert.ToInt32(UserId),
                        Convert.ToString(DTordentribunales.Rows[i][3]),
                        Convert.ToString(DTordentribunales.Rows[i][4]),
                        Convert.ToString(DTordentribunales.Rows[i][5]));
                    }

                }




                if (grd002.Rows.Count != 0)
                {
                    for (int j = 0; j < DTcausales.Rows.Count; j++)
                    {

                        ncoll.Insert_CausalesIngreso(
                            CodIE,
                            Convert.ToInt32(DTcausales.Rows[j][1]),
                            Convert.ToInt32(DTcausales.Rows[j][5]),
                            Convert.ToString(DTcausales.Rows[j][4]),
                            DateTime.Now,
                            Convert.ToInt32(UserId), 0);

                    }
                }

                if (grd003.Rows.Count != 0)
                {

                    for (int k = 0; k < DTlesiones.Rows.Count; k++)
                    {

                        ncoll.Insert_DetalleLesiones(
                            CodIE,
                            Convert.ToInt32(DTlesiones.Rows[k][0]),
                            Convert.ToInt32(DTlesiones.Rows[k][1]),
                            Convert.ToString(DTlesiones.Rows[k][4]),
                            DateTime.Now,
                            Convert.ToInt32(UserId),
                            Convert.ToInt32(DTlesiones.Rows[k][5]));

                    }
                }


                # endregion


                if (SSnino.sexo == null)
                {
                    SSnino.sexo = Convert.ToString('A');
                }


                ncoll.Cierre_ingreso(CodIE, SSnino.CodProyecto,
                Convert.ToDateTime(ddl_Institucion.Text), SSnino.CodNino, SSnino.sexo, Convert.ToInt32(UserId));

                lblmsgSuccess.Text = "Ingreso Realizado Satisfactoriamente";
                lblmsgSuccess.Visible = true;
                alerts2.Visible = true;
                Response.Write("<script language='javascript'>alert('Ingreso Realizado Satisfactoriamente. ');</script>");
                clean_form();
                clean_tab();

            }
            catch (Exception ex)
            {
                // Handle the exception if the transaction fails to commit.
                Console.WriteLine(ex.Message);

                try
                {
                    // Attempt to roll back the transaction.
                    sqlt.Rollback();
                }
                catch (Exception exRollback)
                {
                    // Throws an InvalidOperationException if the connection 
                    // is closed or the transaction has already been rolled 
                    // back on the server.
                    Console.WriteLine(exRollback.Message);
                }
            }

            }


        }
        else
        {
            Response.Write("<script language='javascript'>alert('Ingreso Realizado');</script>");
        }
    }

    protected void lbtn006_Click(object sender, EventArgs e)
    {
        Inst = ddl_Institucion.SelectedValue;
        Proy = ddl_Proyecto.SelectedValue;

        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        //window.open(this.Page, "ninos_ingresonuevo.aspx?eg=si", "", 550, 650, true);


        //string cadena = string.Empty;
        //cadena = @"window.open(this.Page, '../mod_ninos/ninos_ingresonuevo.aspx?eg=si,'', false, true, '770', '420', false, false, true)";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }


    protected void btnAgregar_coning_click(object sender, EventArgs e)
    {
        muestra_pestaña(6);
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        DataRow dr = dt_coning.NewRow();
        bool chk_rep = false;

        if (ddown_conIng.SelectedValue != Convert.ToString(-1))
        {
            for (int i = 0; i < grd_LRPA02.Rows.Count; i++)
            {
                if (grd_LRPA02.Rows[i].Cells[0].Text == ddown_conIng.SelectedValue)
                {
                    chk_rep = true;

                }
            }

            if (!chk_rep)
            {
                LRPAcoll lrp2 = new LRPAcoll();
                DataTable dt2 = lrp2.Get_traenemotec(Convert.ToString(ddown_conIng.SelectedItem));
                string desc = Convert.ToString(dt2.Rows[0][0]);

                dr[0] = "(" + ddown_conIng.SelectedItem + ")" + " - " + desc;
                dr[1] = ddown_conIng.SelectedValue;
                dr[2] = 3;

                dt_coning.Rows.Add(dr);
                DataView dv = new DataView(dt_coning);
                grd_LRPA02.DataSource = dv;
                dv.Sort = "CodCondicionIngreso";
                grd_LRPA02.DataBind();
                grd_LRPA02.Visible = true;

                ddown_conIng.SelectedValue = Convert.ToString(0);
                ddown_conIng.BackColor = System.Drawing.Color.Empty;
                Lbl_mensaje001.Visible = false;

            }
            else
            {
                Lbl_mensaje001.Text = "La Condición de Ingreso ya ha sido Ingresada";
                Lbl_mensaje001.Visible = true;
            }
        }
        else
        {
            ddown_conIng.BackColor = colorCampoObligatorio;
            ddown_conIng.Visible = true;

        }




    }

    protected void ddown_repdaño_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(6);


        if (ddown_repdaño.SelectedValue == "3")
        {

            lbl_mensaje002.Text = "Debe Ingresar Horas de Servicio Comunitario";

        }



    }
    protected void ddown_otm_SelectedIndexChanged(object sender, EventArgs e)
    {
        muestra_pestaña(6);

        opc = false;


        int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        LRPAcoll codmod = new LRPAcoll();
        DataTable dt2 = codmod.GetCodModIntervencion(codproy);
        int codemod = Convert.ToInt32(dt2.Rows[0][0]);
        if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue != Convert.ToString(0))
        {
            if (codemod == 100 || codemod == 102)
            {
                opc = true;
            }
            else
            {
                opc = false;
            }
        }
        else
        {
            opc = false;
        }



    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Inst = ddl_Institucion.SelectedValue;
        Proy = ddl_Proyecto.SelectedValue;

        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        //window.open(this.Page, "ingreso_adulto.aspx?codproy=" + SSnino.CodProyecto, "", 594, 700, true);


        iframe_ingreso_adulto.Src = "../mod_ninos/ingreso_adulto.aspx?codproy=" + SSnino.CodProyecto;
        iframe_ingreso_adulto.Attributes.Add("height", "600px");
        iframe_ingreso_adulto.Attributes.Add("width", "800px");
        //iframe_egreso.Attributes.Add("height", "320px");
        //iframe_egreso.Attributes.Add("width", "420px");
        mpe7.Show();
    }


    //protected void txt006F2_ValueChange(object sender, EventArgs e)
    //{   
    //    if ((String)txt006F2.Text == "") return;

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
    //        txt006F2.BackColor = System.Drawing.Color.Empty;
    //    }
    //}
    protected void lk_lista_espera_Click1(object sender, EventArgs e)
    {
        Inst = ddl_Institucion.SelectedValue;
        Proy = ddl_Proyecto.SelectedValue;

        SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
        SSnino.rut = txt001.Text;

        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "A3", "$('../mod_ninos/ingresoninolistaespera.aspx').modal('show');", true);




        //string cadena = string.Empty;
        //string etiqueta = "ninos_index.aspx";

        //cadena = @"window.open(this.Page, '../mod_ninos/Ingresoninolistaespera.aspx?dir=" + etiqueta + "', 'Buscador', false, true, '770', '420', false, false, true)";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);


        //window.open(this.Page, "ingresoninolistaespera.aspx", "", 710, 670, true);
        //string url = string.Empty;
        //url = "Ingresoninolistaespera.aspx?dir=ninos_index.aspx";
        //ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "')", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "AbrirURLFancybox('" + url + "');", true);
    }

    //protected void lnkbtn_pdfVulneracion_Click(object sender, EventArgs e)
    //{
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, '../mod_reportes/Reg_Reportes.aspx?param001=8', 'Reportes', false, true, '800', '600', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}


    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(8000);
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        lblbmsg.Visible = false;
        alerts.Visible = false;
        lblmsgSuccess.Visible = false;
        alerts2.Visible = false;
        searchgrid();
        Ninos_busqueda1.Visible = false;


        //utab.Visible = false;
        utab_nino.Visible = false;
        titulo_datos_nino.Visible = false;





        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            lbtn004.Visible = false;
        }
        else
        {

            //lbl001F2.Visible = false;
            lbl003F2.Visible = true;

            if (lbl001.Text == "0")
            {
                lbtn004.Visible = true;
                lbl003F2.Visible = true;

            }
            else
            {
                lbtn004.Visible = false;
            }
        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        lblbmsg.Visible = false;
        alerts.Visible = false;
        lblmsgSuccess.Visible = false;
        alerts2.Visible = false;
        searchgrid();
        Ninos_busqueda1.Visible = false;

        //utab.Visible = false;
        utab_nino.Visible = false;
        titulo_datos_nino.Visible = false;





        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            lbtn004.Visible = false;
        }
        else
        {

            //lbl001F2.Visible = false;
            lbl003F2.Visible = true;

            if (lbl001.Text == "0")
            {
                lbtn004.Visible = true;
                lbl003F2.Visible = true;

            }
            else
            {
                lbtn004.Visible = false;
            }
        }


    }
    protected void Button1_Click2(object sender, EventArgs e)
    {
        cargarGrid(sender, e);
    }

    private void cargarGrid(object sender, EventArgs e)
    {
        lblbmsg.Visible = false;
        alerts.Visible = false;
        lblmsgSuccess.Visible = false;
        alerts2.Visible = false;

        Session["count_seachgrid"] = searchgrid();
        int count_seachgrid = Convert.ToInt32(Session["count_seachgrid"]);

        //searchgrid();


        if (lbl001.Text == "0" || count_seachgrid == 0)
        {

            lbtn004.Visible = true;
            lbl003F2.Visible = true;

        }
        else
        {
            lbtn004.Visible = false;
        }

        if (count_seachgrid <= 1000 && count_seachgrid > 0)
        {

            Ninos_busqueda1.Visible = false;
            //utab.Visible = false;
            utab_nino.Visible = false;
            titulo_datos_nino.Visible = false;

            if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
            {
                lbtn004.Visible = false;
            }
            else
            {

                //lbl001F2.Visible = false;
                lbl003F2.Visible = true;


            }
            if (count_seachgrid <= 70)
            {
                lnkbtnver_Click(sender, e);
                lbtn003.Visible = false;
                Label1.Visible = false;
            }

            //verResultadoBusqueda();//gfontbrevis  
            //lbtn003.Visible = false;//gfontbrevis
            //Label1.Visible = false; //gfontbrevis

        }
        else
        {
            lbtn003.Visible = false;
            Label1.Visible = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        clean_form();
       
        if (ddl_Proyecto.SelectedValue != "")
        {
            Button2.Enabled = true;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(GetType(), "", "mostrarOcultarTablas('tabla_OrdenTribunal′,true)", true);
    }

    protected void ddown016_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void WebDateChooser1_TextChanged(object sender, EventArgs e)
    {
        muestra_pestaña(1);

        if (RangeValidator903.IsValid)
        {
            validamescerrado();
        }

    }



    private void VerificaCollapse()
    {


        collapser.Attributes.CssStyle.Value = "s";


    }


    private void muestra_pestaña(int num_tab)
    {
        if (Convert.ToString(ViewState["bloqueo_ley_pestañas"]) != "")
        {
            if (Convert.ToString(ViewState["bloqueo_ley_pestañas"]) == "1")
            {
                link_tab4.Attributes.Remove("data-toggle");
                link_tab6.Attributes.Remove("data-toggle");
                //gfontbrevis: pestañas deshabilitadas
                link_tab4.Attributes.Add("class", "disabled-nav-tabs");
                link_tab6.Attributes.Add("class", "disabled-nav-tabs");


            }
        }
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
                li_nav1.Attributes.Add("class", "active");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");
                break;
            case 2:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade in active");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Add("class", "active");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");

                break;
            case 3:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade in active");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Add("class", "active");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");

                break;
            case 4:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade in active");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Add("class", "active");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Remove("class");

                break;
            case 5:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade in active");
                tab6.Attributes.Add("class", "tab-pane fade");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Add("class", "active");
                li_nav6.Attributes.Remove("class");

                break;
            case 6:
                tab1.Attributes.Add("class", "tab-pane fade");
                tab2.Attributes.Add("class", "tab-pane fade");
                tab3.Attributes.Add("class", "tab-pane fade");
                tab4.Attributes.Add("class", "tab-pane fade");
                tab5.Attributes.Add("class", "tab-pane fade");
                tab6.Attributes.Add("class", "tab-pane fade  in active");
                li_nav1.Attributes.Remove("class");
                li_nav2.Attributes.Remove("class");
                li_nav3.Attributes.Remove("class");
                li_nav4.Attributes.Remove("class");
                li_nav5.Attributes.Remove("class");
                li_nav6.Attributes.Add("class", "active");

                break;
        }
    }

    protected void rv_año_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("yyyy");
        ((RangeValidator)sender).MinimumValue = DateTime.Today.AddYears(-100).ToString("yyyy");

    }

    private void mostrar_collapse(bool valor)
    {
        if (valor)
        {
            collapse_Busqueda.Attributes.Remove("Class");
            collapse_Busqueda.Attributes.Add("Class", "panel-collapse collapse in");
        }
        if (!valor)
        {
            collapse_Busqueda.Attributes.Remove("Class");
            collapse_Busqueda.Attributes.Add("Class", "panel-collapse collapse out");

        }

    }

    protected void txt_FechaInicioSancionLRPA_TextChanged(object sender, EventArgs e)
    {
        RangeValidator930.Validate();

        if (RangeValidator930.IsValid)
        {
            txt001LRPA.Enabled = true;
            txt002LRPA.Enabled = true;
            txt007LRPA.Enabled = true;
            txt009LRPA.Enabled = true;
            //lnk001.Enabled = true;

            //if (txt001LRPA.Text != "" || txt002LRPA.Text != "" || txt007LRPA.Text != "" || txt009LRPA.Text != "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ObtenerFechaTerminoSancion()", true);
            //}
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ObtenerFechaTerminoSancion()", true);
            //Chk002LRPAMixta.Checked = false;
            //Chk002LRPAMixta_CheckedChanged(sender, e);

            //if (Chk002LRPAMixta.Checked == true)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ObtenerFechaTerminoSancionMixta()", true);
            //}
            
        }
        else
        {
            txt001LRPA.Enabled = false;
            txt002LRPA.Enabled = false;
            txt007LRPA.Enabled = false;
            txt009LRPA.Enabled = false;
            //lnk001.Enabled = false;
        }

        if (txt_FechaInicioSancionLRPA.Text == "")
        {
            txt001LRPA.Text = "";
            txt002LRPA.Text = "";
            txt007LRPA.Text = "";
            txt009LRPA.Text = "";
            txt003LRPA.Text = "";
            txt001LRPA.Enabled = false;
            txt002LRPA.Enabled = false;
            txt007LRPA.Enabled = false;
            txt009LRPA.Enabled = false;
        }

        muestra_pestaña(6);
    }
    protected void lnk002_Click1(object sender, EventArgs e)
    {
        muestra_pestaña(6);
    }
    protected void lnk001_Click(object sender, EventArgs e)
    {
        muestra_pestaña(6);
    }
    //protected void buscarNNA_Click(object sender, EventArgs e)
    //{
    //    Button1_Click2(sender, e);
    //}
    protected void cargarDatosNuevos_Click(object sender, EventArgs e)
    {
        cargarGrid(sender, e);
    }
}

