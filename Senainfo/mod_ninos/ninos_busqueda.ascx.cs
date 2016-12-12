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
using System.IO;
using System.Drawing;
using AjaxControlToolkit;

public partial class mod_ninos_ninos_busqueda : System.Web.UI.UserControl
{
    
    public nino SSnino
    {
        get { return (nino)Session["neo_SSnino"]; }
        set { Session["neo_SSnino"] = value; }
    }
    public bool VISFull
    {
        get { return (bool)Session["VISFull"]; }
        set { Session["VISFull"] = value; }
    }
    public bool Vonlyinproyect
    {
        get { return (bool)Session["Vonlyinproyect"]; }
        set { Session["Vonlyinproyect"] = value; }
    }
    public DataTable dt_listaespera_principal
    {
        get { return (DataTable)Session["dt_listaespera_principal"]; }
        set { Session["dt_listaespera_principal"] = value; }
    }

    public string CodigoIngresoLE
    {
        get { return (string)Session["iCodIngresoLE"]; }
        set { Session["iCodIngresoLE"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(grd001);
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(grd_listaespera);


        


        if (!IsPostBack)
        {
            lbl_error_ingreso.Visible = false;
            # region VALIDACION USUARIO


            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {

                if (Session["NNA"] == null)
                {
                    ResetTodo();

                }
                else
                {
                    oNNA NNA = (oNNA)Session["NNA"];

                    if (NNA.NNACodProyecto != "0" && NNA.NNACodInstitucion != "0" && NNA.NNACodIE == 0)
                    {
                        mostrarIngresoDirecto("Ingresar");
                    }
                }

                //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5_VER

                //if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                //{
                //    Response.Redirect("~/logout.aspx"); ;
                //}



                //LO ULTIMO DEL LOAD
            }


            #endregion
            validatescurity();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "maxLength", "window.parent.agregarMaxLength();", true);
        }

        
      
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


    protected void mostrarIngresoDirecto(string tipoOpcion)
    {
        if (tipoOpcion == "Ingresar")
        {
            DataTable dt_data = new DataTable();
            ninocoll ncoll = new ninocoll();
            nino n;
            try
            {
                lbl_error_ingreso.Visible = false;
                
                
                
                //string codingresoLE = Session["iCodIngresoLE"].ToString();

                int counter = 0;
                DataTable dtespera = ncoll.GetData(ninocoll.querytype.inlista, HttpUtility.HtmlDecode(SSnino.Apellido_Paterno), HttpUtility.HtmlDecode(SSnino.Apellido_Materno), SSnino.rut.Replace(".", ""), SSnino.CodNino.ToString(), SSnino.sexo, SSnino.CodInst.ToString(), SSnino.Nombres, SSnino.CodProyecto.ToString(), out counter);

                CodigoIngresoLE = dtespera.Rows[0][0].ToString();
            }
            catch (Exception e)
            {

            }
            

            //Infragistics.WebUI.UltraWebTab.UltraWebTab utab = (Infragistics.WebUI.UltraWebTab.UltraWebTab)this.Parent.FindControl("utab");
            try
            {
                //codingresoLE = grd_listaespera.Rows[0].Cells[12].Text; //e.CommandName.ToString();
                TextBox ICodILE = new TextBox();
                //ICodILE = (TextBox)utab.Parent.FindControl("txt_ICodIngresoLE");
                ICodILE.Text = CodigoIngresoLE;
                //Session["ICodIngresoLE"] = codingresoLE;
                //GridViewRow gridViewRow = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                dt_data = ncoll.GetDataLE_Ingreso(CodigoIngresoLE);

                n = ncoll.GetData(SSnino.CodNino.ToString(), "0", CodigoIngresoLE);
                SSnino = n;
                SSnino.rut = formatearRut(SSnino.rut);
                SSnino.ctrlload = 2;
            }
            catch (Exception ex)
            {

            }
            

            try
            {
                if (Convert.ToInt32(dt_data.Rows[0]["CodTribunal"]) == 0)
                {
                    //TextBox t_txt006F2 = (TextBox)utab.Parent.FindControl("txt006F2");
                    TextBox t_txt006F2 = new TextBox();
                    t_txt006F2.Text = dt_data.Rows[0]["RUC"].ToString();

                    //Control tpnl001 = utab.Parent.FindControl("pnl001");
                    //tpnl001.Visible = false;

                    //RadioButton trdo003 = (RadioButton)utab.Parent.FindControl("rdo003");
                    RadioButton trdo003 = new RadioButton();
                    trdo003.Checked = true;
                    //rdo003
                }
                else
                {
                    //TextBox t_txt006F2 = (TextBox)utab.Parent.FindControl("txt006F2");
                    TextBox t_txt006F2 = new TextBox();
                    t_txt006F2.Text = dt_data.Rows[0]["RUC"].ToString();
                }
            }
            catch (Exception e)
            {

            }

            //utab.DataBind();

            //utab.Visible = true;
            this.Parent.FindControl("Ninos_busqueda1").Visible = false;
            Session["listadeespera"] = "true";

            var div_panel = this.Parent.FindControl("div_panel");
            div_panel.Visible = true;

            Panel utab_nino = (Panel)this.Parent.FindControl("utab_nino");
            utab_nino.DataBind();
            utab_nino.Visible = true;

            LinkButton lbtn004 = (LinkButton)this.Parent.FindControl("lbtn004");//gfontbrevis Button->LinkButton
            LinkButton lk_lista_espera = (LinkButton)this.Parent.FindControl("lk_lista_espera");
            LinkButton lbtn006 = (LinkButton)this.Parent.FindControl("lbtn006");
            lbtn004.Visible = false;
            lk_lista_espera.Visible = false;
            lbtn006.Visible = false;

            Label lbl003F2 = (Label)this.Parent.FindControl("lbl003F2");
            lbl003F2.Visible = false;
            Label lbl001 = (Label)this.Parent.FindControl("lbl001");
            lbl001.Visible = false;
            Label lbl002 = (Label)this.Parent.FindControl("lbl002");
            lbl002.Visible = false;

            LinkButton lbtn003 = (LinkButton)this.Parent.FindControl("lbtn003");
            lbtn003.Visible = false;
            Label Label1 = (Label)this.Parent.FindControl("Label1");
            Label1.Visible = false;

            TextBox txtRut = (TextBox)this.Parent.FindControl("txt001");
            txtRut.Text = SSnino.rut;

            

            //Label lbl_informacion_coincidencias = (Label)this.Parent.FindControl("lbl_informacion_coincidencias");
            //lbl_informacion_coincidencias.Visible = false;

        }
    }


    protected void ResetTodo()
    {
        lbl003.Visible = false;
        lbl_error_ingreso.Visible = false;

        //grd001.DataSource = null;
        //grd001.DataBind();
        grd001.Visible = false;


        lbl005.Visible = false;
        //grd002.DataSource = null;
        //grd002.DataBind();
        grd002.Visible = false;

        //grd003.DataSource = null;
        //grd003.DataBind();
        grd003.Visible = false;

        lbl006.Visible = false;
        //grd_listaespera.DataSource = null;
        //grd_listaespera.DataBind();
        grd_listaespera.Visible = false;

    }



    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        ////79270734-C383-487D-8EAB-BC63F1521932    Ingreso de NNA en la Grilla
        if (!window.existetoken("79270734-C383-487D-8EAB-BC63F1521932"))
            grd001.Columns[9].Visible = false; //9

        //C6A64B2F-C14E-43CC-89B7-A2DA2EE4DDB2 2.12
        if (window.existetoken("C6A64B2F-C14E-43CC-89B7-A2DA2EE4DDB2"))
        {
            grd001.Columns[7].Visible = false; //9
        }
        //B8549126-72BE-4463-A01F-1BAF60C6977F 2.2_ingresar
        if (!window.existetoken("B8549126-72BE-4463-A01F-1BAF60C6977F"))
        {
            grd001.Columns[7].Visible = false;
        }
        ////B122B56F-15E0-4488-B5FE-FEADD035CF36
        //if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36"))
        //{
        //    grd001.Columns[9].Visible = false;
        //}


        //Se añaden validaciones de tokens para mejorar el funcionamiento de Situación Migratoria (Módulo de Datos de Gestión)

        //Validando Permisos de datos de gestión, para poder mostrar la data total o parcial de documentación e idiomas

        //21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarDocumentacionActiva1", "mostrarDocumentacionActiva();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarIdiomasActivos1", "mostrarIdiomasActivos();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosDocumentos1", "mostrarTodosDocumentacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosIdiomas1", "mostrarTodosIdiomas();", true);
            //ScriptManager.RegisterClientScriptResource(, GetType(), "mostrarOcultarDocDatos1", "$('input[name^='RadioDoc_1_']').click(function () {if ($(this).val() == '0') {$('input[name^='Doc_datos_1']').attr('readonly', 'readonly');} else { $('input[name^='Doc_datos_1']').removeAttr('readonly');}}); };", true);
        }
            //9273FC38-331B-4E54-B78E-1E7CB41CB0B5 2.4_ELIMINAR
        if (!window.existetoken("9273FC38-331B-4E54-B78E-1E7CB41CB0B5"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarDocumentacionActiva", "mostrarTodosDocumentacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarIdiomasActivos", "mostrarTodosIdiomas  ();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosDocumentos2", "mostrarTodosDocumentacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosIdiomas2", "mostrarTodosIdiomas();", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "mostrarOcultarDocDatos1", "$('input[name^='RadioDoc_1_']').click(function () {if ($(this).val() == '0') {$('input[name^='Doc_datos_1']').attr('readonly', 'readonly');} else { $('input[name^='Doc_datos_1']').removeAttr('readonly');}}); };", true);
            //Parent.FindControl("UpdatePanel11").DataBind();
        }
    }
    #endregion



    // modificado felipe ormazabal 07 11 2006

    public void getgrid(bool ISFull)
    {
        Vonlyinproyect = true;
        VISFull = ISFull;


        if (SSnino.CodProyecto > 0)
        {
            getgridinproyect(VISFull, Vonlyinproyect, 0);
        }
        getgridinred(0);
        getgridinlistaespera(0);

    }

    // modificado felipe 08-11-2006
    public void getgridinproyect(bool ISFull)
    {
        Vonlyinproyect = true;
        VISFull = ISFull;
        if (SSnino.CodProyecto > 0)
        {
            getgridinproyect(VISFull, Vonlyinproyect, 0);
        }
    }

    //modificado Felipe Ormazabal 07 11 2006

    public void getgridinproyect(bool ISFull, bool onlypry, int pageindex)
    {
        int counter = 0;
        ninocoll ncoll = new ninocoll();
        Vonlyinproyect = onlypry;
        VISFull = ISFull;


        //FELIPE
        //EN PROYECTO
        DataTable dtproy = null;
        DataTable dtproy2 = null;
        if (ISFull)
        {
            string apepat, apemat, nombres;


            if (SSnino.Apellido_Paterno.ToString() == "")
            {
                apepat = string.Empty;
            }
            else
            {
                apepat = SSnino.Apellido_Paterno;
            }
            if (SSnino.Apellido_Materno.ToString() == "")
            {
                apemat = string.Empty;
            }
            else
            {
                apemat = SSnino.Apellido_Materno;
            }
            if (SSnino.Nombres.ToString() == "")
            {
                nombres = string.Empty;
            }
            else
            {
                nombres = SSnino.Nombres;
            }
            //if (SSnino.CodNino.ToString() == "")
            //{
            //    codigo = string.Empty;
            //}
            //else
            //{
            //    codigo = SSnino.CodNino.ToString();
            //}

            dtproy = ncoll.GetData(ninocoll.querytype.inproyect, apepat, apemat, string.Empty, string.Empty, string.Empty
                       , SSnino.CodInst.ToString(), nombres, SSnino.CodProyecto.ToString(), out counter);

            if (onlypry)
            {
                dtproy2 = ncoll.GetData(ninocoll.querytype.inproyect, SSnino.Apellido_Paterno, SSnino.Apellido_Materno, SSnino.rut.Trim().Replace(".",""), SSnino.CodNino.ToString(), SSnino.sexo
                              , SSnino.CodInst.ToString(), SSnino.Nombres, SSnino.CodProyecto.ToString(), out counter);
            }

        }
        else
        {
            dtproy = ncoll.GetData(ninocoll.querytype.inproyect, SSnino.Apellido_Paterno, SSnino.Apellido_Materno, SSnino.rut.Trim().Replace(".",""), SSnino.CodNino.ToString(), SSnino.sexo
                          , SSnino.CodInst.ToString(), SSnino.Nombres, SSnino.CodProyecto.ToString(), out counter);

        }

        DataView dvproy = new DataView(dtproy);

        if (SSnino.tipobusqueda == 1)
        {

            grd003.DataSource = dvproy;
            dvproy.Sort = "ApellidoPaterno";
            lbl005.Text = "Niños en Proyecto :" + dtproy.Rows.Count.ToString();

            grd003.DataBind();
            grd003.PageIndex = pageindex;
            grd003.Visible = true;
            lbl005.Visible = true;


            if (grd003.Rows.Count > 0)
            {
                if (ISFull && onlypry && dtproy2.Rows.Count > 0)
                {
                    for (int j = 0; j < grd003.Rows.Count; j++)
                    {
                        for (int i = 0; i < dtproy2.Rows.Count; i++)
                        {
                            if (dtproy2.Rows[i][0].ToString() == grd003.Rows[j].Cells[0].Text)
                            {
                                grd003.Rows[j].BackColor = System.Drawing.Color.GreenYellow;

                            }
                        }

                    }
                }
            }
            //ejecutar javascript para fijar header de tabla si supera 15 filas
            if (grd003.Rows.Count > 15)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#Ninos_busqueda1_grd003', '#tableHeader3','#tableContainer3',1 );", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#Ninos_busqueda1_grd003', '1' );", true);
            }

        }
        else
        {

            grd002.DataSource = dvproy;
            dvproy.Sort = "ApellidoPaterno";
            lbl005.Text = "Niños en Proyecto :" + dtproy.Rows.Count.ToString();

            grd002.DataBind();
            grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
            //grd002.PageIndex = pageindex;//gfontbrevis
            grd002.Visible = true;
            lbl005.Visible = true;



            if (ISFull && onlypry && dtproy2.Rows.Count > 0)
            {
                for (int j = 0; j < grd002.Rows.Count; j++)
                {
                    for (int i = 0; i < dtproy2.Rows.Count; i++)
                    {
                        if (dtproy2.Rows[i][0].ToString() == grd002.Rows[j].Cells[0].Text)
                        {
                            grd002.Rows[j].BackColor = System.Drawing.Color.GreenYellow;

                        }
                    }

                }
            }

            

            //ejecutar javascript para fijar header de tabla si supera 15 filas
            if (grd002.Rows.Count > 15)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#Ninos_busqueda1_grd002', '#tableHeader2', '#tableContainer2',1);", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#Ninos_busqueda1_grd002', '1' );", true);
            }

        }


    }

    public void getgridinred(int pageindex)
    {

        // EN RED
        
        int counter = 0;
        ninocoll ncoll = new ninocoll();

        DataTable dtred = ncoll.GetData(ninocoll.querytype.inred, SSnino.Apellido_Paterno, SSnino.Apellido_Materno, SSnino.rut.Trim().Replace(".", ""), SSnino.CodNino.ToString(), SSnino.sexo
                           , SSnino.CodInst.ToString(), SSnino.Nombres, SSnino.CodProyecto.ToString(), out counter);

        for (int i = 0; i < dtred.Rows.Count; i++)
        {

            for (int j = 0; j < grd003.Rows.Count; j++)
            {
                if (dtred.Rows[i][0].ToString() == grd003.Rows[j].Cells[0].Text)
                {
                    dtred.Rows.RemoveAt(i);
                    j = grd003.Rows.Count;
                    i = -1; 
                }
            }
        }        

        DataView dvred = new DataView(dtred);
        grd001.DataSource = dvred;
        dvred.Sort = "Nombres";

        lbl003.Text = "Niños en la RED : " + dtred.Rows.Count.ToString();

        grd001.DataBind();
        //grd001.PageIndex = pageindex;//gfontbrevis
        grd001.Visible = true;
        lbl003.Visible = true;

        for (int i = 0; i < dtred.Rows.Count; i++)
        {
            if (dtred.Rows[i]["FechaDefuncion"].ToString() != "01-01-1900 0:00:00") 
            {
                grd001.Rows[i].Cells[9].Style.Add("display", "none");
                grd001.Rows[i].Cells[10].Style.Add("display", "block");                

                ninocoll nin = new ninocoll();

                int codmodelo = nin.callto_get_codmodelointervencion(Convert.ToInt32(SSnino.CodProyecto));

                if (codmodelo != 81) //PRJ
                {
                    grd001.Rows[i].Cells[10].Text = "Niño Fallecido";
                }
            }

            else
            {
                grd001.Rows[i].Cells[9].Style.Add("display", "block");
                grd001.Rows[i].Cells[10].Style.Add("display", "none");
            }            
        }        

        //ScriptManager.RegisterStartupScript(this, GetType(), "deletecellempty", "document.getElementById('Ninos_busqueda1_grd001').rows[0].deleteCell(10);", true);

        //gfontbrevis

        //ejecutar javascript para fijar header de tabla si supera 15 filas
        //if (grd001.Rows.Count > 15)
        //{
        //    //se utiliza el primero ya que necesita un scroll independiente y pequeño en la búsqueda del niño en el ingreso
        //    ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#Ninos_busqueda1_grd001', '#tableHeader1', '#tableContainer1',1);", true);
        //    //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#Ninos_busqueda1_grd001', '1' );", true);
        //}


    }

    public void getgridinlistaespera(int pageindex)
    {

        // EN LISTA DE ESPERA
        int counter = 0;
        ninocoll ncoll = new ninocoll();

        DataTable dtespera = ncoll.GetData(ninocoll.querytype.inlista, SSnino.Apellido_Paterno, SSnino.Apellido_Materno, SSnino.rut.Replace(".",""), SSnino.CodNino.ToString(), SSnino.sexo
                           , SSnino.CodInst.ToString(), SSnino.Nombres, SSnino.CodProyecto.ToString(), out counter);
        //DataTable dtProyectosUser = new DataTable();
        //if (Session["IdUsuario"] != null && Session["codinstitucion"] != null)
        //{
        //   dtProyectosUser  = ncoll.SQL_ProyectosByUser(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(Session["codinstitucion"]));
        //}

        //DataTable dt = new DataTable();
        //DataRow dr;


        //dt.Columns.Add(new DataColumn("CodigoNino"));
        //dt.Columns.Add(new DataColumn("Rut"));
        //dt.Columns.Add(new DataColumn("Sexo"));
        //dt.Columns.Add(new DataColumn("Nombres"));
        //dt.Columns.Add(new DataColumn("Apellido Paterno"));
        //dt.Columns.Add(new DataColumn("Apellido Materno"));
        //dt.Columns.Add(new DataColumn("Fecha de Nacimiento"));
        //dt.Columns.Add(new DataColumn("FechaIngresoLE"));
        //dt.Columns.Add(new DataColumn("CodProyecto"));
        //dt.Columns.Add(new DataColumn("Ingresar"));
        //dt.Columns.Add(new DataColumn("Seleccionar"));
        //dt.Columns.Add(new DataColumn("ICodIngresoLE"));

        //if (Session["CodProyecto"] != null)
        //{
        //    //for (int i = 0; i < dtProyectosUser.Rows.Count; i++)
        //    //{
        //        for (int j = 0; j < dtespera.Rows.Count; j++)
        //        { 
        //            //if (Session["CodProyecto"].ToString() == dtespera.Rows[j]["CodProyecto"].ToString())
        //            //{
        //                try
        //                {

        //                dr = dt.NewRow();
        //                dr[0] = dtespera.Rows[j]["CodigoNino"];
        //                dr[1] = dtespera.Rows[j]["Rut"];
        //                dr[2] = dtespera.Rows[j]["Sexo"];
        //                dr[3] = dtespera.Rows[j]["Nombres"];
        //                dr[4] = dtespera.Rows[j]["Apellido Paterno"];
        //                dr[5] = dtespera.Rows[j]["Apellido Materno"];
        //                dr[6] = dtespera.Rows[j]["Fecha de Nacimiento"];
        //                dr[7] = dtespera.Rows[j]["FechaIngresoLE"];
        //                dr[8] = dtespera.Rows[j]["CodProyecto"];
        //                dr[9] = dtespera.Rows[j]["Ingresar"];
        //                dr[10] = dtespera.Rows[j]["Seleccionar"];
        //                dr[11] = dtespera.Rows[j]["ICodIngresoLE"];
        //                dt.Rows.Add(dr);
        //                }
        //                catch
        //                { }
        //            //}
        //        }
        //    //}
        //}

        dt_listaespera_principal = dtespera;
        DataView dvespera = new DataView(dtespera);
        grd_listaespera.DataSource = dvespera;
        dvespera.Sort = "Nombres";
        lbl006.Text = "Niños en lista de Espera : " + dtespera.Rows.Count.ToString();
        grd_listaespera.DataBind();
        //grd_listaespera.PageIndex = pageindex;
        grd_listaespera.Visible = true;
        
        lbl006.Visible = true;
        //gfontbrevis
        //ejecutar javascript para fijar header de tabla si supera 15 filas
        if (grd_listaespera.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#Ninos_busqueda1_grd_listaespera', '#tableHeader4', '#tableContainer4',1);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#Ninos_busqueda1_grd_listaespera', '1' );", true);
        }

        //Session["ICodIngresoLE"] = dtespera.Rows[0][0].ToString();

    }

    private bool FiltroLRPA(int CodProyecto)
    {
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(CodProyecto);
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


    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        nino n;

        if (e.CommandName == "INGRESAR")
        {
            int edad = 0;
            DateTime FechaNacimientoNIno = Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
            CalendarExtender calendarIngresoNino = (CalendarExtender)this.Parent.FindControl("CalendarExtende903");
            DropDownList ddl_Proyecto = (DropDownList)this.Parent.FindControl("ddl_Proyecto");

            if (FechaNacimientoNIno.Year != 1)
            {
                DateTime itime = DateTime.Now;
                TimeSpan compare = itime.Date - FechaNacimientoNIno.Date;
                edad = Convert.ToInt32(compare.Days / 365);                

                calendarIngresoNino.StartDate = FechaNacimientoNIno;
                
            }

            ninocoll nc = new ninocoll();
            int CodNino = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            DataTable dtIR = nc.ingresoRelacion(CodNino);

            DateTime fechaIngresoMadre = new DateTime();
            String centroMadre = "";

            foreach (DataRow dr in dtIR.Rows)
            {
                fechaIngresoMadre = Convert.ToDateTime(dr["FechaIngreso"].ToString());
                centroMadre = dr["codProyecto"].ToString();
            }


            if (ddl_Proyecto.SelectedValue == centroMadre)
            {

                calendarIngresoNino.StartDate = fechaIngresoMadre;
                //CalendarExtende903.EndDate = DateTime.Now;

            }

            int CodProyecto = Convert.ToInt32(Session["CodProyecto"]);
            if ((FiltroLRPA(CodProyecto) && edad >= 14) || (!FiltroLRPA(CodProyecto) )) // verifica si el proyecto ingresado del niño está en la ley y su el niño cumple con la edad mínima
            {

                if (dt_listaespera_principal.Rows.Count > 0)
                {
                    bool existe_lista_espera = false;
                    for (int i = 0; i < dt_listaespera_principal.Rows.Count; i++)
                    {
                        if (dt_listaespera_principal.Rows[i]["CodigoNino"].ToString() == grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text)
                        {
                            existe_lista_espera = true;
                        }
                    }
                    if (existe_lista_espera)
                    {
                        lbl_error_ingreso.Text = "El niño(a) se encuentra en Lista de Espera, debe ingresarlo desde dicha opción.";
                        lbl_error_ingreso.Visible = true;
                    }
                    else
                    {
                        lbl_error_ingreso.Visible = false;
                        n = ncoll.GetData(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, "0");
                        SSnino = n;
                        SSnino.ctrlload = 2;
                        //Infragistics.WebUI.UltraWebTab.UltraWebTab utab = (Infragistics.WebUI.UltraWebTab.UltraWebTab)this.Parent.FindControl("utab");

                        //TabContainer utab = (TabContainer)this.Parent.FindControl("utab");
                        //utab.DataBind();
                        //utab.Visible = true;

                        Panel utab_nino = (Panel)this.Parent.FindControl("utab_nino");
                        utab_nino.DataBind();
                        utab_nino.Visible = true;

                        this.Parent.FindControl("Ninos_busqueda1").Visible = false;
                        Session["listadeespera"] = null;

                        

                        LinkButton lbtn004 = (LinkButton)this.Parent.FindControl("lbtn004");//gfontbrevis Button->LinkButton
                        LinkButton lk_lista_espera = (LinkButton)this.Parent.FindControl("lk_lista_espera");
                        LinkButton lbtn006 = (LinkButton)this.Parent.FindControl("lbtn006");
                        lbtn004.Visible = false;
                        lk_lista_espera.Visible = false;
                        lbtn006.Visible = false;

                        Label lbl003F2 = (Label)this.Parent.FindControl("lbl003F2");
                        lbl003F2.Visible = false;
                        Label lbl001 = (Label)this.Parent.FindControl("lbl001");
                        lbl001.Visible = false;
                        Label lbl002 = (Label)this.Parent.FindControl("lbl002");
                        lbl002.Visible = false;

                        LinkButton lbtn003 = (LinkButton)this.Parent.FindControl("lbtn003");
                        lbtn003.Visible = false;
                        Label Label1 = (Label)this.Parent.FindControl("Label1");
                        Label1.Visible = false;

                        //Label lbl_informacion_coincidencias = (Label)this.Parent.FindControl("lbl_informacion_coincidencias");
                        //lbl_informacion_coincidencias.Visible = false;


                    }
                }
                else
                {
                    lbl_error_ingreso.Visible = false;
                    n = ncoll.GetData(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, "0");
                    SSnino = n;
                    SSnino.ctrlload = 2;
                    //Infragistics.WebUI.UltraWebTab.UltraWebTab utab = (Infragistics.WebUI.UltraWebTab.UltraWebTab)this.Parent.FindControl("utab");

                    //TabContainer utab = (TabContainer)this.Parent.FindControl("utab");
                    //utab.DataBind();
                    //utab.Visible = true;

                    Panel utab_nino = (Panel)this.Parent.FindControl("utab_nino");
                    utab_nino.DataBind();
                    utab_nino.Visible = true;

                    

                    this.Parent.FindControl("Ninos_busqueda1").Visible = false;
                    Session["listadeespera"] = null;


                    LinkButton lbtn004 = (LinkButton)this.Parent.FindControl("lbtn004");//gfontbrevis Button->LinkButton
                    LinkButton lk_lista_espera = (LinkButton)this.Parent.FindControl("lk_lista_espera");
                    LinkButton lbtn006 = (LinkButton)this.Parent.FindControl("lbtn006");
                    lbtn004.Visible = false;
                    lk_lista_espera.Visible = false;
                    lbtn006.Visible = false;

                    Label lbl003F2 = (Label)this.Parent.FindControl("lbl003F2");
                    lbl003F2.Visible = false;
                    Label lbl001 = (Label)this.Parent.FindControl("lbl001");
                    lbl001.Visible = false;
                    Label lbl002 = (Label)this.Parent.FindControl("lbl002");
                    lbl002.Visible = false;

                    LinkButton lbtn003 = (LinkButton)this.Parent.FindControl("lbtn003");
                    lbtn003.Visible = false;
                    Label Label1 = (Label)this.Parent.FindControl("Label1");
                    Label1.Visible = false;

                    //Label lbl_informacion_coincidencias = (Label)this.Parent.FindControl("lbl_informacion_coincidencias");
                    //lbl_informacion_coincidencias.Visible = false;
                }
            }
            else
            {
                window.alert(this.Page, "El niño no cumple la edad mínima para ser ingresado en un proyecto LRPA.");
                
            }
        }

        if (e.CommandName == "LINK")
        {
            String strCodNino = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            DataTable dt = ncoll.Get_NinosEnOtrosProyectos(strCodNino, SSnino.CodProyecto.ToString());

            if (dt.Rows.Count > 0)
            {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=NinosEnOtrosProyectos.xls");
            Response.ContentType = "application/vnd.ms-excel";
            
            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();
            dg.RenderControl(hw);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();
            }
            
        }
    }
    
   
    
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getgridinred(e.NewPageIndex);
        grd001.DataBind();

    }

    // modificado felipe ormazabal 07 11 2006

    protected void grd002_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getgridinproyect(VISFull, Vonlyinproyect, e.NewPageIndex);
        grd002.DataBind();
        grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "SELECCIONAR")
        {
            ninocoll ncoll = new ninocoll();
            nino n = ncoll.GetData(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            n.ICodIE = Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            int codinst = SSnino.CodInst;
            /*RPA*/
            Session["SS_ICodIE"] = Convert.ToInt32(grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);           
            /*fin RPA*/
            SSnino = n;
            SSnino.CodInst = codinst;
            var  pnl001 = this.Parent.FindControl("pnl001");
            pnl001.Visible = true;
            this.Parent.FindControl("Ninos_busqueda1").Visible = false;
           
            this.Parent.FindControl("chk001").DataBind();

            this.Parent.FindControl("tr_fecha_ingreso").Visible = true;
            this.Parent.FindControl("tr_fecha_nacimiento").Visible = true;

            //this.Parent.FindControl("utab").Visible = true;
            //mostrar el panel para pruebas
            
            try
            { this.Parent.FindControl("btnbuscar").Visible = false; }
                //se modifico el nombre ya que no existia
            catch { }
            validatescurity();
            //RPA
            //UserControl cform = (UserControl)Page.LoadControl("DatosdeGestion_condicionesLeyRPA_Flexibilizacion.ascx");
            //Page.Controls.Add(cform);

            Panel pnl_utab11 = (Panel)this.Parent.FindControl("pnl_utab11");
            pnl_utab11.DataBind();

            Panel pnl_utab12 = (Panel)this.Parent.FindControl("pnl_utab12");
            pnl_utab12.DataBind();

            Panel pnl_utab14 = (Panel)this.Parent.FindControl("pnl_utab14");
            pnl_utab14.DataBind();
            //UserControl control = (UserControl)Page.LoadControl(string.Format("~/UserControls/{0}.ascx", controlName));
            //Page.Controls.Add(control);

        }
    }



    protected void grd001_PageIndexChanged(object sender, EventArgs e)
    {



    }


    protected void grd_listaespera_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() != "Page")
        {
            string TipoOpcion = ((LinkButton)e.CommandSource).Text.ToString();
            if (TipoOpcion == "Ingresar")
            {
                lbl_error_ingreso.Visible = false;
                ninocoll ncoll = new ninocoll();
                nino n;
                DataTable dt_data = new DataTable();
                string codingresoLE = string.Empty;
                //Infragistics.WebUI.UltraWebTab.UltraWebTab utab = (Infragistics.WebUI.UltraWebTab.UltraWebTab)this.Parent.FindControl("utab");
                try
                {
                    codingresoLE = e.CommandName.ToString();
                    TextBox ICodILE = new TextBox();
                    //ICodILE = (TextBox)utab.Parent.FindControl("txt_ICodIngresoLE");
                    ICodILE.Text = codingresoLE;

                    Session["ICodIngresoLE"] = codingresoLE;
                    GridViewRow gridViewRow = ((Control)e.CommandSource).BindingContainer as GridViewRow;
                    dt_data = ncoll.GetDataLE_Ingreso(codingresoLE);
                }
                catch (Exception ex)
                {

                }
                n = ncoll.GetData(e.CommandArgument.ToString(), "0", codingresoLE);
                SSnino = n;
                SSnino.ctrlload = 2;

                if (Convert.ToInt32(dt_data.Rows[0]["CodTribunal"]) == 0)
                {
                    //TextBox t_txt006F2 = (TextBox)utab.Parent.FindControl("txt006F2");
                    TextBox t_txt006F2 = new TextBox();
                    t_txt006F2.Text = dt_data.Rows[0]["RUC"].ToString();

                    //Control tpnl001 = utab.Parent.FindControl("pnl001");
                    //tpnl001.Visible = false;

                    //RadioButton trdo003 = (RadioButton)utab.Parent.FindControl("rdo003");
                    RadioButton trdo003 = new RadioButton();
                    trdo003.Checked = true;
                    //rdo003
                }
                else
                {
                    //TextBox t_txt006F2 = (TextBox)utab.Parent.FindControl("txt006F2");
                    TextBox t_txt006F2 = new TextBox();
                    t_txt006F2.Text = dt_data.Rows[0]["RUC"].ToString();
                }

                //utab.DataBind();

                //utab.Visible = true;
                this.Parent.FindControl("Ninos_busqueda1").Visible = false;
                Session["listadeespera"] = "true";

                var div_panel = this.Parent.FindControl("div_panel");
                div_panel.Visible = true;

                Panel utab_nino = (Panel)this.Parent.FindControl("utab_nino");
                utab_nino.DataBind();
                utab_nino.Visible = true;

                LinkButton lbtn004 = (LinkButton)this.Parent.FindControl("lbtn004");//gfontbrevis Button->LinkButton
                LinkButton lk_lista_espera = (LinkButton)this.Parent.FindControl("lk_lista_espera");
                LinkButton lbtn006 = (LinkButton)this.Parent.FindControl("lbtn006");
                lbtn004.Visible = false;
                lk_lista_espera.Visible = false;
                lbtn006.Visible = false;

                Label lbl003F2 = (Label)this.Parent.FindControl("lbl003F2");
                lbl003F2.Visible = false;
                Label lbl001 = (Label)this.Parent.FindControl("lbl001");
                lbl001.Visible = false;
                Label lbl002 = (Label)this.Parent.FindControl("lbl002");
                lbl002.Visible = false;

                LinkButton lbtn003 = (LinkButton)this.Parent.FindControl("lbtn003");
                lbtn003.Visible = false;
                Label Label1 = (Label)this.Parent.FindControl("Label1");
                Label1.Visible = false;

                //Label lbl_informacion_coincidencias = (Label)this.Parent.FindControl("lbl_informacion_coincidencias");
                //lbl_informacion_coincidencias.Visible = false;

                

            }
            else if(TipoOpcion == "Modificar")
            {
                //window.open(this.Page, "ingresoninolistaespera.aspx?IngresoLE=" + e.CommandName, "", 800, 600, true);

                //Button btn_modal_listaespera_modificar = (Button)this.Parent.FindControl("btn_modal_listaespera_modificar");
                ////btn_modal_listaespera_modificar.Attributes.Add("OnClientClick", "return MostrarModalIngresoNuevo(" + e.CommandName + ")");
                //btn_modal_listaespera_modificar.OnClientClick = "return MostrarModalIngresoNuevo(" + e.CommandName + ")";                        
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Presionarbtn_modal(" + e.CommandName + ");", true);


                HtmlIframe iframe_modificar_listaespera = (HtmlIframe)this.Parent.FindControl("iframe_modificar_listaespera");
                iframe_modificar_listaespera.Src = "../mod_ninos/ingresoninolistaespera.aspx?IngresoLE=" + e.CommandName;
                iframe_modificar_listaespera.Visible = true;
                iframe_modificar_listaespera.Attributes.Add("height", "600px");
                iframe_modificar_listaespera.Attributes.Add("width", "800px");
                ModalPopupExtender mpe6 = (ModalPopupExtender)this.Parent.FindControl("mpe6");
                mpe6.Show();
                
                
            }
        }
        
    }
    protected void grd_listaespera_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        getgridinlistaespera(e.NewPageIndex);
        grd_listaespera.DataBind();
    }

    protected void grd001_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    TableCell FechaDefuncion = e.Row.Cells[10];
        //    TableCell Ingresar = e.Row.Cells[9];
        //    if (FechaDefuncion.Text != "01-01-1900")
        //    {
        //        Ingresar.Text = "IngresarPrueba";
        //    }

        //}
    }
}
