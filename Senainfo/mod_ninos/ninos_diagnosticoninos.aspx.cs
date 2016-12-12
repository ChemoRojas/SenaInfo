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

using Argentis.Regmen;


using CustomWebControls;
using System.Text;
using System.Data.SqlClient;

public partial class mod_ninos_ninos_diagnosticoninos : System.Web.UI.Page
{
    public int VCod_diagnostico
    {

        get
        {
            if (ViewState["Cod_diagnostico"] == null)
            { ViewState["Cod_diagnostico"] = -1; }
            return Convert.ToInt32(ViewState["Cod_diagnostico"]);
        }
        set { ViewState["Cod_diagnostico"] = value; }
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

    public DataSet DVfiltro
    {
        get { return (DataSet)Session["DVfiltro"]; }
        set { Session["DVfiltro"] = value; }
    }


    public DateTime VFecha_diagnostico
    {
        get
        {
            if (ViewState["Fecha_diagnostico"] == null)
            { ViewState["Fecha_diagnostico"] = -1; }
            return Convert.ToDateTime(ViewState["Fecha_diagnostico"]);
        }
        set { ViewState["Fecha_diagnostico"] = value; }
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



    public nino SSninoDiag
    {
        get
        {
            if (Session["neo_SSninoDiag"] == null)
            { Session["neo_SSninoDiag"] = new nino(); }
            return (nino)Session["neo_SSninoDiag"];
        }
        set { Session["neo_SSninoDiag"] = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        //Mostrar u Ocultar formulario de busqueda
        mostrar_collapse(true);

        if (!IsPostBack)
        {

            // mantiene abierto el acordeon para visualizar la información

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



                validatescurity(); //LO ULTIMO DEL LOAD



            #endregion


                GetData();
                imb_limpiardiag.Visible = true;
                if (Request.QueryString["param001"] == "1")
                {
                    utab_diag.Visible = false;
                    grd001.Visible = true;

                }


                if (Request.QueryString["sw"] == "3")
                {

                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    GetProyectos();
                }

                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    GetProyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];

                }

            }

            //-----------------------------------------------------------------------------------------------
            // JOVM - 03/02/2015
            // Se obtiene información desde Session en el caso de contener datos.
            //-----------------------------------------------------------------------------------------------
            if (Session["NNA"] != null)
            {
                oNNA NNA = (oNNA)Session["NNA"];

                // JOVM - 05/02/2015
                //Verifica si viene de otro formulario y no tiene la Fecha de Ingreso. 
                //Este dato es necesario para cargar los tabs de este formulario.
                //Si no viene la Fecha de Ingreso, sigue el flujo normal.

                //JRV se añade validación para que cuando vengan en blanco les asigne cero y evite la caida por no encontrarse en el indice
                if (NNA.NNACodInstitucion == "")
                {
                    ddown001.SelectedValue = "0";
                }
                else
                {
                    ddown001.SelectedValue = NNA.NNACodInstitucion;
                }

                GetProyectos();

                if (NNA.NNACodProyecto == "")
                {
                    NNA.NNACodProyecto = "0";
                }
                else
                {
                    ddown002.SelectedValue = NNA.NNACodProyecto;
                }



                if (NNA.NNACodIE != 0)
                {
                    txt003.Text = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
                    txt005.Text = HttpUtility.HtmlDecode(NNA.NNANombres);
                    txt004.Text = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
                    SSninoDiag.ICodIE = NNA.NNACodIE;
                    SSninoDiag.fchingdesde = Convert.ToDateTime(NNA.NNAFechaIngreso);
                    SSninoDiag.CodNino = NNA.NNACodNino;
                    SSninoDiag.rut = NNA.NNARut;
                    SSninoDiag.Nombres = HttpUtility.HtmlDecode(NNA.NNANombres);
                    SSninoDiag.CodInst = Convert.ToInt32(NNA.NNACodInstitucion);
                    SSninoDiag.CodProyecto = Convert.ToInt32(NNA.NNACodProyecto);
                    SSninoDiag.FechaNacimiento = Convert.ToDateTime(NNA.NNAFechaNacimiento);
                    VerDiagnosticosSession();

                    //guarda en dos label los datos resumen del niño sin mostrarlos
                    lbl_resumen_filtro.Text = SSninoDiag.Nombres + " " + SSninoDiag.Apellido_Paterno;
                    lbl_resumen_filtro.Visible = true;
                    lbl_resumen_proyecto.Visible = true;
                    lbl_resumen_proyecto.Text = " / " + ddown002.SelectedItem.Text;
                    lbl_resumen_proyecto.Style.Add("display", "none");
                    lbl_resumen_filtro.Style.Add("display", "none");

                }
            }
            //-----------------------------------------------

        }

        //if (utab_diag.Visible == true)
        //{
        //    ValidaFichaSaludInicial();
        //}
    }


    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        GetProyectos();

    }

    #region buscador Niños en Proyectos
    //Se elimino por un fancybox
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_diagnosticoninos.aspx", "Buscador", false, true, 770, 420, false, false, true);

    //}

    //se elimino por fancybox
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_diagnosticoninos.aspx", "Buscador", false, true, 770, 420, false, false, true);

    //}

    protected void imb_buscar_Click(object sender, EventArgs e)
    {
        
        //imb_buscar.Visible = false;
       
        imb_limpiardiag.Visible = true;

        if (Convert.ToInt32(ddown001.SelectedValue) != 0)
        {
            if (Convert.ToInt32(ddown002.SelectedValue) != 0)
            {
                lbl001_aviso.Text = "";
                Getninos();
                
               
            }
            else
            {
                lbl001_aviso.Text = "Debe ingresar un proyecto";
                lbl001_aviso.Visible = true;
            }
        }
        else
        {
            lbl001_aviso.Text = "Debe ingresar una institución";
            lbl001_aviso.Visible = true;
        }
        

      
    }


    #endregion

    #region Seleccion de ninos

    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grd001.PageIndex = e.NewPageIndex;
        Getninos();


    }
    protected void grd001_rowcommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "VerDiagnosticos")
        {
            VerDiagnosticos(e);

            
            //lbl_resumen_filtro.Style.Add("display", "none");
            //gfontbrevis
           mostrar_collapse(false);
           ScriptManager.RegisterStartupScript(Page, Page.GetType(), "A", "$('#collapse').addClass('collapsed');$('#icon-collapse').removeClass();$('#icon-collapse').addClass('glyphicon glyphicon-triangle-bottom');$('#lbl_acordeon').text('Mostrar Detalles de la Búsqueda');", true);
           
            
        }

        if (e.CommandName == "Historicos")
        {
            VerHistoricos(e);
        }
        
    }

    protected void VerDiagnosticos(GridViewCommandEventArgs e)
    {
       
        //utab4.Visible = true;
        utab_diag.Visible = true;
        grd001.Visible = false;

        ninocoll ncoll = new ninocoll();

        //grilla diagnostico escolar
        try
        {
            SSninoDiag.FechaNacimiento = Convert.ToDateTime(Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text).ToShortDateString());
        }
        catch { }
        SSninoDiag.ICodIE = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
        SSninoDiag.fchingdesde = Convert.ToDateTime(Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text).ToShortDateString());
        SSninoDiag.CodNino = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        SSninoDiag.rut = Convert.ToString(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
        SSninoDiag.Nombres = Convert.ToString(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
        SSninoDiag.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        SSninoDiag.CodProyecto = Convert.ToInt32(ddown002.SelectedValue);
        SSninoDiag.Apellido_Paterno = Convert.ToString(HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text));
        SSninoDiag.Apellido_Materno = Convert.ToString(HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text));
        SSninoDiag.NombreInst = ddown001.SelectedItem.ToString();
        SSninoDiag.NombreProy = ddown002.SelectedItem.ToString();

        lbl_resumen_filtro.Text =  SSninoDiag.Nombres + " " + SSninoDiag.Apellido_Paterno;
        lbl_resumen_proyecto.Text = " / " + ddown002.SelectedItem.Text;
        lbl_resumen_filtro.Visible = true;
        lbl_resumen_proyecto.Visible = true;
        //lbl_resumen_proyecto.Style.Add("display", "none");//gfontbrevis
        //lbl_resumen_filtro.Style.Add("display", "none");

        //Lbl_Nombre.Text = "Nombre:" + " " + SSninoDiag.Nombres;
        //lbl_FechaNacimiento.Text = "Fecha de Nacimiento:" + " " + SSninoDiag.FechaNacimiento.ToShortDateString();
        //Lbl_fechaingreso.Text = "Fecha de Ingreso:" + " " + SSninoDiag.fchingdesde.ToShortDateString();
        //lbl_FechaNacimiento.Visible = true;
        txt006.Text =  SSninoDiag.FechaNacimiento.ToShortDateString();
        txt007.Text =  SSninoDiag.fchingdesde.ToShortDateString();

        ddown001.Enabled = false;
        ddown002.Enabled = false;
        txt005.Enabled = false;
        txt003.Enabled = false;

        //imb_institucion.Visible = false;
        //imb_proyecto.Visible = false;
        imb_institucion.Attributes.Add("disabled", "disabled");
        imb_proyecto.Attributes.Add("disabled", "disabled");

        txt004.Enabled = false;
        tr_fecha_nacimiento.Visible = true;
        tr_fecha_ingreso.Visible = true;
        


        //  lnk_DiagEscolar.Visible = true;
        //-----------------------------------------------------------------------------------------------
        // JOVM - 05/02/2015
        // Se asigna información a la Session en caso de estar sin datos.
        //-----------------------------------------------------------------------------------------------
        //SSninoDiag.Apellido_Paterno = Convert.ToString(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
        //SSninoDiag.Apellido_Materno = Convert.ToString(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
        //txt005.Text = SSninoDiag.Nombres.ToString();
        //txt003.Text = SSninoDiag.Apellido_Paterno.ToString();
        //txt004.Text = SSninoDiag.Apellido_Materno.ToString();
        /*RPA MODIFICA POR QUE NO SE MUESTRAN LAS ACENTUACIONES*/
        txt005.Text = Convert.ToString(HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text));//gfontbrevis
        txt003.Text = Convert.ToString(HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text));//gfontbrevis
        txt004.Text = Convert.ToString(HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text));//gfontbrevis
        if (Session["NNA"] == null)
        {

            string cinst = SSninoDiag.CodInst.ToString();
            string cproy = SSninoDiag.CodProyecto.ToString();
            string rut = SSninoDiag.rut;
            Int32 codie = SSninoDiag.ICodIE;
            Int32 cnino = SSninoDiag.CodNino;

            oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, SSninoDiag.Nombres, SSninoDiag.Apellido_Paterno, SSninoDiag.Apellido_Materno, Convert.ToString(SSninoDiag.fchingdesde), Convert.ToString(SSninoDiag.FechaNacimiento));
            Session["NNA"] = NNA;
        }
        //-----------------------------------------------

        proyectocoll proyectoc = new proyectocoll();
        DataTable DTProyecto = proyectoc.GetProyectos(SSnino.CodProyecto.ToString());

        

        int y = 0;
        if (SSninoDiag.FechaNacimiento.Year != 1)
        {
            DateTime itime = DateTime.Now;
            TimeSpan compare = itime.Date - SSninoDiag.FechaNacimiento.Date;
            y = Convert.ToInt32(compare.Days / 365);
        }
        else
        {
            
        }


        imb_buscar.Visible = false;
        

        if (y < 14)
        {
            //utab_diag.Tabs[6].Visible = false;
            link_tab7.Attributes.Add("style", "display: none");
            li_nav7.Attributes.Add("style", "display: none");
            //link_tab7.Attributes.Add("style", "display: none");
        }
        else
        {
            //utab_diag.Tabs[6].Visible = true;
            //link_tab6.Attributes.Add("style", "display: block");
            link_tab7.Attributes.Add("style", "display: block");
            li_nav7.Attributes.Remove("style");
        }
        if (y < 12)
        {
            link_tab6.Attributes.Add("style", "display: none");
            li_nav6.Attributes.Add("style", "display: none");
        }
        else
        {
            link_tab6.Attributes.Add("style", "display: block");
            li_nav6.Attributes.Remove("style");
        }

        MuestraFichaSalud();
        MuestraAntecedenteJudicial(Convert.ToInt32(DTProyecto.Rows[0]["CodModeloIntervencion"].ToString()));
    }
    private void MuestraAntecedenteJudicial(int CodModeloIntervencion)
    {
        if (CodModeloIntervencion == 81) // PRJ
        {
            link_tab8.Text = "ANTECEDENTES JUDICIALES";
            link_tab8.OnClientClick = "return MostrarIframeUtab12()";
            link_tab8.Attributes.Add("href", "#tab12");
            link_tab1.Attributes.Add("aria-controls", "tab112");
        }
        else
        {
            link_tab8.Text = "HECHOS JUDICIALES";
            link_tab8.OnClientClick = "return MostrarIframeUtab8()";
            link_tab8.Attributes.Add("href", "#tab8");
            link_tab1.Attributes.Add("aria-controls", "tab18");
        }        
    }

    private void MuestraFichaSalud()
    {
        if (Convert.ToInt32(SSninoDiag.CodInst) == 6050)
        {
            if (window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B") || window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
            {
                li_nav10.Visible = true;
            }

            else
            {
                li_nav10.Visible = false;
            }
        }
        else
        {
            li_nav10.Visible = false;
        }
    }

    private void ValidaFichaSaludInicial()
    {
        int CodDiagnosticoFichaSalud = GetCodDiagnostico();
        int CodFichaSaludInicial = GetCodDiagnosticoSaludFichaInicial(CodDiagnosticoFichaSalud);

        if (CodFichaSaludInicial > 0)
        {
            li_FichaSaludPosterior.Attributes.Add("style", "display:block;");
        }
        else
        {
            li_FichaSaludPosterior.Attributes.Add("style", "display:none;");
        }
    }


    public int GetCodDiagnostico()
    {
        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodDiagnostico from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = (SELECT CodDiagnostico FROM DiagnosticoGeneral where ICodIE = @ICodIE and CodTipoDiagnosticoGlosa = 11)";
        sqlc.Parameters.AddWithValue("@ICodIE", SSninoDiag.ICodIE);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();

        if (dt.Rows.Count == 1)
        {
            returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        }
        if (dt.Rows.Count > 1)
        {
            returnvalue = -1;
        }
        return returnvalue;
    }


    public int GetCodDiagnosticoSaludFichaInicial(int CodDiagnostico)
    {
        int returnvalue = 0;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodFichaSaludInicial from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = @CodDiagnostico";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();

        if (dt.Rows.Count == 1)
        {
            returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        }
        if (dt.Rows.Count > 1)
        {
            returnvalue = -1;
        }
        return returnvalue;
    }
                
    protected void VerHistoricos(GridViewCommandEventArgs e)
    {
        try
        {
            SSninoDiag.FechaNacimiento = Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
        }
        catch { }
        SSninoDiag.ICodIE = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
        SSninoDiag.fchingdesde = Convert.ToDateTime(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
        SSninoDiag.CodNino = Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        SSninoDiag.rut = Convert.ToString(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
        SSninoDiag.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        SSninoDiag.CodProyecto = Convert.ToInt32(ddown002.SelectedValue);
        
                   
        iframe_historicos.Src = "../mod_ninos/ninos_HistoricodeDiagnosticos.aspx";
        iframe_historicos.Attributes.Add("height", "400px");
        iframe_historicos.Attributes.Add("width", "650px");
        mpe3.Show();
    }

    protected void VerDiagnosticosSession()
    {


        utab_diag.Visible = true;
        grd001.Visible = false;
        ninocoll ncoll = new ninocoll();

        //Lbl_Nombre.Text = "Nombre:" + " " + SSninoDiag.Nombres;
        //lbl_FechaNacimiento.Text = "Fecha de Nacimiento:" + " " + SSninoDiag.FechaNacimiento.ToShortDateString();
        //Lbl_fechaingreso.Text = "Fecha de Ingreso:" + " " + SSninoDiag.fchingdesde.ToShortDateString();
        //lbl_FechaNacimiento.Visible = true; 
        txt006.Text =  SSninoDiag.FechaNacimiento.ToShortDateString();
        txt007.Text =  SSninoDiag.fchingdesde.ToShortDateString();

        //imb_institucion.Visible = false;
        //imb_proyecto.Visible = false;
        imb_institucion.Attributes.Add("disabled", "disabled");
        imb_proyecto.Attributes.Add("disabled", "disabled");


        ddown001.Enabled = false;
        ddown002.Enabled = false;
        txt005.Enabled = false;
        txt003.Enabled = false;
        txt004.Enabled = false;
        tr_fecha_nacimiento.Visible = true;
        tr_fecha_ingreso.Visible = true;


        proyectocoll proyectoc = new proyectocoll();
        DataTable DTProyecto = proyectoc.GetProyectos(SSnino.CodProyecto.ToString());

        MuestraAntecedenteJudicial(Convert.ToInt32(DTProyecto.Rows[0]["CodModeloIntervencion"].ToString()));

        int y = 0;
        if (SSninoDiag.FechaNacimiento.Year != 1)
        {
            DateTime itime = DateTime.Now;
            TimeSpan compare = itime.Date - SSninoDiag.FechaNacimiento.Date;
            y = Convert.ToInt32(compare.Days / 365);
        }
        else
        {
           
        }


        imb_buscar.Visible = false;
        

        if (y < 14)
        {
            //utab_diag.Tabs[6].Visible = false;
            link_tab7.Attributes.Add("style", "display: none");
            li_nav7.Attributes.Add("style", "display: none");
        }
        else
        {
            //utab_diag.Tabs[6].Visible = true;
            link_tab7.Attributes.Add("style", "display: block");
            li_nav7.Attributes.Remove("style");
        }
        if (y < 12)
        {
            //utab_diag.Tabs[5].Visible = false;
            link_tab6.Attributes.Add("style", "display: none");
            li_nav6.Attributes.Add("style", "display: none");
        }
        else
        {
            //utab_diag.Tabs[5].Visible = true;
            link_tab6.Attributes.Add("style", "display: block");
            li_nav6.Attributes.Remove("style");
        }


    }

    #endregion

    # region Funciones del Formulario




    private void GetProyectos()
    {
        proyectocoll proy = new proyectocoll();



        DataTable dtproy = proy.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue));
        DataView dv = new DataView(dtproy);



        //DataView dv = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddown001.SelectedValue), ASP.global_asax.globaconn));
        ddown002.Items.Clear();
        // <---------- DPL ---------->  09-08-2010
        dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddown002.DataSource = (dv);
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        dv.Sort = "Nombre";
        DataBind();

        if (dv.Count == 2)
            ddown002.SelectedIndex = 1;
    }

    private void GetData()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];
        // << --- DPL 20-08-2015 --- >
        // institucioncoll ncoll = new institucioncoll();
        //DataView dv = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));     
        // << --- DPL 20-08-2015 --- >
        DataView dv = new DataView(ds.Tables["dtInstituciones"]);
        ddown001.Items.Clear();
        ddown001.DataSource = (dv);
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv.Sort = "Nombre ASC";
        DataBind();

        // <---------- JVR ---------->  06-01-2016
        if (dv.Count > 0)
        {
            ddown001.SelectedIndex = 1;
            ddown001_SelectedIndexChanged(new object(), new EventArgs());
        }
        // <---------- JVR ---------->  06-01-2016

    }


    private void Getninos()
    {
        //if (Convert.ToInt32(ddown002.SelectedValue) != 0 || ddown002.SelectedValue != "")
        //{
        //    ninocoll ncoll = new ninocoll();
        //    DataTable dt = ncoll.callto_getninosxproyectos(Convert.ToInt32(ddown002.SelectedValue), ASP.global_asax.globaconn);
        //    if (dt.Rows.Count > 0)
        //    {
        //        DataView dv = new DataView(dt);
        //        grd001.Page.Items.Clear();
        //        if (txt002.Text.Trim() != "")
        //        {
        //            dv.RowFilter = "NombreCompleto like '%*" + txt002.Text.Trim()+"*%'";
        //        }

        //        dv.Sort = "NombreCompleto";
        //        grd001.DataSource = dv;
        //        grd001.DataBind();
        //        grd001.Visible = true;
        //    }
        //    else
        //    {

        //        lbl001_aviso.Text = "No existen niños vigentes en para este proyecto";
        //        grd001.Visible = false;

        //    }
        //}
        //else 
        //{
        //    lbl001_aviso.Text = "Debe seleccionar un proyecto";
        //}

        SSnino.CodInst = Convert.ToInt32(ddown001.SelectedValue);
        SSnino.CodProyecto = Convert.ToInt32(ddown002.SelectedValue);
        SSnino.Apellido_Paterno = Convert.ToString(txt003.Text.Trim());
        SSnino.Apellido_Materno = Convert.ToString(txt004.Text.Trim());
        SSnino.Nombres = Convert.ToString(txt005.Text.Trim());
        //SSnino.CodNino = Convert.ToInt32(txt002.Text.Trim());
        DataTable dt = getgridinproyect();
        if (dt.Rows.Count > 0)
        {
            lbl001_aviso.Text = "";
            DataView dv = new DataView(dt);
            dv.Sort = "ApellidoPaterno";
            grd001.DataSource = dv;
            grd001.DataBind();
            grd001.Visible = true;
            //gfontbrevis

            //ejecutar javascript para fijar header de tabla si supera 15 filas
            if (grd001.Rows.Count > 15)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader','#tableContainer',1);", true);
            }
            
        }
        else
        {

            lbl001_aviso.Text = "No existen niños vigentes en para este proyecto";
            grd001.Visible = false;

        }

        if (dt.Rows.Count <= 0)              //&& txt005.Text.Length > 0 || txt003.Text.Length > 0 || txt004.Text.Length > 0
        {
            lbl001_aviso.Text = "Los valores ingresados no poseen registros";
        }
        else {
            lbl001_aviso.Text ="";
        }
    }
    # endregion


    protected void lnk_DiagEscolar_Click(object sender, EventArgs e)
    {

        //window.open(this.Page, "ninos_DiagnisticoEscolar.aspx", 800, 600);
        ////Response.Redirect("ninos_DiagnisticoEscolar.aspx");
    }


    protected void btn_volverdiag_Click(object sender, EventArgs e)
    {
        Getninos();
        imb_buscar.Visible = true;
        imb_limpiardiag.Visible = true;
       

         
        utab_diag.Visible = false;

    }

    protected void imb_limpiardiag_Click(object sender, EventArgs e)
    {
       
        //ddown001.SelectedValue = Convert.ToString(0);
        //ddown002.SelectedValue = Convert.ToString(0);
        //txt002.Text = "";

        // JOVM - 05/02/2015
        // Se limpian datos de la Session
        Session["NNA"] = null;
        txt005.Text = "";
        txt004.Text = "";
        txt003.Text = "";
        txt006.Text = "";
        txt007.Text = "";

        ddown001.Enabled = true;
        ddown002.Enabled = true;
        txt005.Enabled = true;
        txt003.Enabled = true;
        txt004.Enabled = true;
        tr_fecha_nacimiento.Visible = false;
        tr_fecha_ingreso.Visible = false;

        //imb_institucion.Visible = true;
        //imb_proyecto.Visible = true;
        imb_institucion.Attributes.Remove("disabled");
        imb_proyecto.Attributes.Remove("disabled");


        //----------------------------
       
        imb_buscar.Visible = true;
        lbl001_aviso.Text = "";
        lbl001_aviso.Visible = false;
        grd001.DataSource = null;
        grd001.DataBind();
        grd001.Visible = false;

        utab_diag.Visible = false;

        link_tab5.Attributes.Add("style", "display: block");
        link_tab6.Attributes.Add("style", "display: block");

        lbl_resumen_filtro.Text = "";
        lbl_resumen_proyecto.Text = "";
        lbl_resumen_filtro.Attributes.Add("style", "display: none");
        lbl_resumen_proyecto.Attributes.Add("style", "display: none");
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


        if (!window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
        {
            grd001.Columns[6].Visible = false;
        }


        // si tengo los token puedo ver la pestaña ficha de salud

        MuestraFichaSalud();

        ////B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
        //if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36"))
        //{
        //    utab2.Visible = false;
        //}

        ////169A2222-0D01-4B62-A224-41B67BAD0387 2.4_INGRESAR
        //if (!window.existetoken("169A2222-0D01-4B62-A224-41B67BAD0387"))
        //{
        //    //SOLICITUD DE DILIGENCIAS
        //    WebImageButton tbtn001 = (WebImageButton)utab2.FindControl("btn001");
        //    tbtn001.Visible = false;

        //    //DATOS DE SALUD
        //    WebImageButton tbtn002 = (WebImageButton)utab2.FindControl("btn002");
        //    WebImageButton tbtn003 = (WebImageButton)utab2.FindControl("btn003");
        //    WebImageButton tbtn004 = (WebImageButton)utab2.FindControl("btn004");
        //    tbtn002.Visible = false;
        //    tbtn003.Visible = false;
        //    tbtn004.Visible = false;

        //    //INFORME DE DIAGNOSTICO
        //    LinkButton tlnk001 = (LinkButton)utab2.FindControl("lnk001");
        //    WebImageButton tbtn008 = (WebImageButton)utab2.FindControl("btn008");
        //    WebImageButton tbtn006 = (WebImageButton)utab2.FindControl("btn006");
        //    WebImageButton tbtn007 = (WebImageButton)utab2.FindControl("btn007");
        //    WebImageButton tbtn0010 = (WebImageButton)utab2.FindControl("btn0010");

        //    tlnk001.Visible = false;
        //    tbtn008.Visible = false;
        //    tbtn006.Visible = false;
        //    tbtn007.Visible = false;
        //    tbtn0010.Visible = false;

        //    //PERSONA RELACIONADA
        //    WebImageButton tbtn005 = (WebImageButton)utab2.FindControl("btn005");
        //    tbtn005.Visible = false;


        //}

        ////21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        //if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        //{
        //    //SOLICITUD DE DILIGENCIAS
        //    GridView tgrd002 = (GridView)utab2.FindControl("grd002"); //7
        //    tgrd002.Columns[7].Visible = false;

        //    //DATOS DE SALUD
        //    GridView tgrd003 = (GridView)utab2.FindControl("grd003"); //5
        //    GridView tgrd004 = (GridView)utab2.FindControl("grd004"); //6
        //    GridView tgrd005 = (GridView)utab2.FindControl("grd005"); //4
        //    tgrd003.Columns[5].Visible = false;
        //    tgrd004.Columns[6].Visible = false;
        //    tgrd005.Columns[4].Visible = false;

        //    //INFORME DE DIAGNOSTICO
        //    GridView tgrd008 = (GridView)utab2.FindControl("grd008"); //3
        //    tgrd008.Columns[3].Visible = false;

        //    //PERSONA RELACIONADA
        //    GridView tgrd006 = (GridView)utab2.FindControl("grd006"); //6
        //    tgrd006.Columns[6].Visible = false;

        //}

        ////9273FC38-331B-4E54-B78E-1E7CB41CB0B5 2.4_ELIMINAR
        //if (!window.existetoken("9273FC38-331B-4E54-B78E-1E7CB41CB0B5"))
        //{

        //    //SOLICITUD DE DILIGENCIAS
        //    GridView tgrd002 = (GridView)utab2.FindControl("grd002"); //8
        //    tgrd002.Columns[8].Visible = false;

        //    //DATOS DE SALUD
        //    GridView tgrd003 = (GridView)utab2.FindControl("grd003"); //6
        //    GridView tgrd004 = (GridView)utab2.FindControl("grd004"); //7
        //    GridView tgrd005 = (GridView)utab2.FindControl("grd005"); //5
        //    tgrd003.Columns[6].Visible = false;
        //    tgrd004.Columns[7].Visible = false;
        //    tgrd005.Columns[5].Visible = false;

        //    //INFORME DE DIAGNOSTICO
        //    GridView tgrd008 = (GridView)utab2.FindControl("grd008"); //4
        //    tgrd008.Columns[4].Visible = false;

        //    //PERSONA RELACIONADA
        //    // No se eliminan personas relacionadas




        //}


        #endregion


    }

    #endregion



    public DataTable getgridinproyect()
    {
        int counter = 0;
        DataTable dtproy = null;
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
        ninocoll ncoll = new ninocoll();
        dtproy = ncoll.GetData(ninocoll.querytype.inproyect, apepat, apemat, string.Empty, string.Empty, string.Empty
                   , SSnino.CodInst.ToString(), nombres, SSnino.CodProyecto.ToString(), out counter);
        return dtproy;

    }




    protected void utab_diag_TabClick(object sender, EventArgs e)
    {

    }
    protected void IraFormulario_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (IraFormulario.SelectedValue == "1")
        //{
        //    Response.Redirect("DatosdeGestion.aspx");

        //}
        //if (IraFormulario.SelectedValue == "2")
        //{
        //    Response.Redirect("ninos_diagnosticoninos.aspx");
        //}
    }
    protected void BtnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_ninos/index_ninos.aspx");
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

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        grd001.DataSource = null;
        grd001.DataBind();
        grd001.Visible = false;
    }
  
}



