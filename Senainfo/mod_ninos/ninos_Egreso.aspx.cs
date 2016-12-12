/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, agregué reloj de espera, descarga excel
 * 
 *  R E V I S A R    L O G I C A
 * 
 * 
 * 
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
using System.Data.SqlClient;
using System.Globalization;

public partial class mod_ninos_ninos_Egreso : System.Web.UI.Page
{
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
    public String msgEgreso
    {
        get { return (String)Session["msgEgreso"]; }
        set { Session["msgEgreso"] = value; }
    }
    public String nombreNinoEgreso
    {
        get { return (String)Session["nombreNinoEgreso"]; }
        set { Session["nombreNinoEgreso"] = value; }
    }
    private bool lnkValidateRut
    {
        get { return (bool)Session["lnkValidateRut"]; }
        set { Session["lnkValidateRut"] = value; }
    }   

    protected void Page_Load(object sender, EventArgs e)
    {
        //SM001.RegisterAsyncPostBackControl(imb001);
        //SM001.RegisterAsyncPostBackControl(A1);
      mostrar_collapse(true);

        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {

            if (!IsPostBack)
            {
                if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    if (!window.existetoken("8A25E23A-114B-4CDE-9C26-A0567B2A4D77"))
                    {
                        Response.Redirect("~/logout.aspx");
                    }

                    getinstituciones();

                    try
                    {
                        if (Request.QueryString["sw"] == "4")
                        {
                            buscador_institucion bsc = new buscador_institucion();
                            int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                            ddl_Institucion.SelectedValue = Convert.ToString(codinst);
                            getproyectos();
                            ddl_Proyecto.SelectedValue = Request.QueryString["codinst"];

                        }
                    }
                    catch { }
                    validatescurity();
                    //--------------------------------------------------------------------
                    // JOVM - 25/02/2015
                    // Se obtiene información desde Session en el caso de contener datos.
                    if (Session["NNA"] != null && Request.QueryString["sw"] == null)
                    {
                        oNNA NNA = (oNNA)Session["NNA"];
                        ddl_Institucion.SelectedValue = NNA.NNACodInstitucion;
                        getproyectos();
                        ddl_Proyecto.SelectedValue = NNA.NNACodProyecto;

                        if (NNA.NNACodIE != null || NNA.NNACodIE != 0)
                        {
                            txt_apaterno.Text = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
                            txt_nombres.Text = HttpUtility.HtmlDecode(NNA.NNANombres);
                            txt_amaterno.Text = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
                            SSnino.CodNino = NNA.NNACodNino;
                            SSnino.ICodIE = NNA.NNACodIE;
                            SSnino.Cua = NNA.NNACua;
                            //lbl003.Text = NNA.NNAFechaIngreso;
                            //lbl004.Text = NNA.NNAFechaNacimiento; 
                            //CargaTabs();

                            lbl_resumen_filtro.Text = "<br>";
                            lbl_resumen_filtro.Text += "<strong>Busqueda: </strong>";

                            try
                            {
                                lbl_resumen_filtro.Text += "" + ddl_Proyecto.SelectedItem.Text + " ";
                            }
                            catch
                            {
                                lbl_resumen_filtro.Text += "";
                            }
                           
                            if (txt_apaterno.Text != "")
                            {
                                lbl_resumen_filtro.Text += "// " + txt_apaterno.Text + "";
                            }

                            if (txt_amaterno.Text != "")
                            {
                                lbl_resumen_filtro.Text += " " + txt_amaterno.Text + " ";
                            }

                            if (txt_nombres.Text != "")
                            {
                                lbl_resumen_filtro.Text += "" + txt_nombres.Text + "";
                            }

                            lbl_resumen_filtro.Text += "<br>";

                            lbl_resumen_filtro.Visible = true;
                            lbl_resumen_filtro.Style.Add("display", "none");
                            


                        }




                    }
                    else
                    {
                        getproyectos();
                    }
                    //-----------------------------------------------

                    fn_buscar();

                    
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#grd001_wrapper #grd001_filter input').val('" + SSnino.ICodIE + "')", true);

                }
            }
        }
    }

    private void validatescurity()
    {
        //A638709F-43F2-4319-B1CA-2D675EC5C5C4 2.7_INGRESAR (EGRESAR)
        if (!window.existetoken("A638709F-43F2-4319-B1CA-2D675EC5C5C4"))
        {

        }
        //ECA2B3FC-B8CB-4E4D-AF27-0A8842AAA0C7 2.7_MODIFICAR (MODIFICAR)
        if (!window.existetoken("ECA2B3FC-B8CB-4E4D-AF27-0A8842AAA0C7"))
        {

        }

    }
    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre";
        ddl_Institucion.DataSource = dv;
        ddl_Institucion.DataTextField = "Nombre";
        ddl_Institucion.DataValueField = "Codinstitucion";
        ddl_Institucion.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dtinst.Rows.Count > 0)
            ddl_Institucion.SelectedIndex = 1;
        // <---------- DPL ---------->  09-08-2010

    }
    private void getproyectos()
    {
        if (ddl_Institucion.Items.Count > 0 && Convert.ToInt32(ddl_Institucion.SelectedValue) > 0)
        {
            try
            {
                proyectocoll pcoll = new proyectocoll();
                ddl_Proyecto.Items.Clear();


                DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddl_Institucion.SelectedValue));
                DataView dv = new DataView(dtproy);
                dv.Sort = "Nombre";
                // <---------- DPL ---------->  09-08-2010
                dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
                // <---------- DPL ---------->  09-08-2010
                ddl_Proyecto.DataSource = dv;
                ddl_Proyecto.DataTextField = "Nombre";
                ddl_Proyecto.DataValueField = "CodProyecto";
                ddl_Proyecto.DataBind();
                if (dv.Count == 2)
                {
                    ddl_Proyecto.SelectedIndex = 1;
                    ddown002_SelectedIndexChanged(new object(), new EventArgs());
                }
            }
            catch (Exception)
            {
                
             
            }
           
        }


    }
    protected void imb001_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/ninos_egreso.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void imb_buscar_Click(object sender, EventArgs e)
    {
        call001.BackColor = System.Drawing.Color.Empty;
        call002.BackColor = System.Drawing.Color.Empty;
        cal003.BackColor = System.Drawing.Color.Empty;
        ddown006.BackColor = System.Drawing.Color.Empty;
        ddow011.BackColor = System.Drawing.Color.Empty;
        txt003.BackColor = System.Drawing.Color.Empty;
        txt004.BackColor = System.Drawing.Color.Empty;
        txt005.BackColor = System.Drawing.Color.Empty;
        txt006.BackColor = System.Drawing.Color.Empty;
        txt007.BackColor = System.Drawing.Color.Empty;
        //lnkfiltrar.Visible = false;
        chk001.Checked = false;
        call001.Text = null;
        call002.Text = null;
        cal003.Text = "";
        rdo002.Checked = true;
        rdo001.Checked = false;
        rdo005.Checked = false;
        fn_buscar();
        lbl_resumen_filtro.Text = "<br>";
        lbl_resumen_filtro.Text += "<strong>Busqueda: </strong>";
        lbl_resumen_filtro.Text += "" + ddl_Proyecto.SelectedItem.Text + " ";
        if (txt_apaterno.Text != "")
        {
            lbl_resumen_filtro.Text += "// " + txt_apaterno.Text + "";
        }

        if (txt_amaterno.Text != "")
        {
            lbl_resumen_filtro.Text += " " + txt_amaterno.Text + " ";
        }

        if (txt_nombres.Text != "")
        {
            lbl_resumen_filtro.Text += "" + txt_nombres.Text + "";
        }

        lbl_resumen_filtro.Text += "<br>";

        lbl_resumen_filtro.Visible = true;
        lbl_resumen_filtro.Style.Add("display", "none");
    }

    private void fn_buscar()
    {
        try
        {

            SSnino.CodInst = Convert.ToInt32(ddl_Institucion.SelectedValue);
            SSnino.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
            SSnino.Apellido_Paterno = Convert.ToString(txt_apaterno.Text);
            SSnino.Apellido_Materno = Convert.ToString(txt_amaterno.Text);
            SSnino.Nombres = Convert.ToString(txt_nombres.Text);
        }
        catch
        { 
        }
        /*
        * JOVM - 25/02/2015
        * Si tiene la SESSION no tiene datos, entonces la carga con información
        */
        if (Session["NNA"] == null)
        {
            string cinst = ddl_Institucion.SelectedValue.ToString();
            string cproy = ddl_Proyecto.SelectedValue.ToString();
            string rut = "";
            Int32 codie = 0;
            Int32 cnino = 0;

            oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, txt_nombres.Text, txt_apaterno.Text, txt_amaterno.Text, "", "");
            Session["NNA"] = NNA;
        }
        
        //-----------------------------------------------------------------------------------------


        DataTable dt = getgridinproyect();

        try
        {
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("Seleccionar", typeof(String));

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    dt.Rows[k]["Seleccionar"] = "";

                    if (dt.Rows[k]["CodCausalIngreso"].ToString().Length != 0 && dt.Rows[k]["Seleccionar"].ToString().Trim().Length == 0)
                    {
                        dt.Rows[k]["Seleccionar"] = "ENGESTACION";
                    }
                    if (Convert.ToInt32(dt.Rows[k]["EstadoIE"]) == 1 && dt.Rows[k]["Seleccionar"].ToString().Trim().Length == 0)
                    {
                        dt.Rows[k]["Seleccionar"] = "EGRESADO";
                    }

                    //formatear fecha nac.
                    //dt.Rows[k]["FechaNacimiento"] = Convert.ToDateTime(dt.Rows[k]["FechaNacimiento"]).ToShortDateString();
                    ////formatear fechaingreso
                    //dt.Rows[k]["Fechaingreso"] = Convert.ToDateTime(dt.Rows[k]["Fechaingreso"]).ToShortDateString();

                }
                DataView dv = new DataView(dt);

                grd001.DataSource = dv;

                grd001.DataBind();
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
                //grd001.Height = 300;
                grd001.Visible = true;

                if (grd001.Rows.Count > 15)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
                    //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
                }

                btnexcel.Visible = true;
                //lnkfiltrar.Visible = true;
                pnl001.Visible = false;
                pnl002.Visible = false;
                Pnl_Orden.Visible = false;
                //lbl_detalle.Visible = false;
                imb_guardar.Visible = false;
                txt003.Text = "";
                txt004.Text = "";
                txt002.Text = "";
                txt005.Text = "";
                txt006.Text = "";
                txt007.Text = "";

                ddown008.SelectedIndex = 0;
                ddown007.SelectedIndex = 0;
                ddown003.SelectedIndex = 0;
                ddown004.SelectedIndex = 0;
                ddown009.SelectedIndex = 0;
                txtproyecto.Text = "";// gfontbrevis
                txtproyecto.Enabled = false;// gfontbrevis
                ddlProyectoConQuienEgresa.Enabled = false;
                imb_lupa_modal2.Attributes.Add("disabled", "disabled");// gfontbrevis



                int IndiceColumnaSeleccionar = 0;
                foreach (DataControlField column in grd001.Columns)
                {
                    if (column.AccessibleHeaderText == "Seleccionar")
                    {
                        IndiceColumnaSeleccionar = grd001.Columns.IndexOf(column);
                        break;
                    }
                }

                int IndiceColumnaICODIE = 0;
                foreach (DataControlField column in grd001.Columns)
                {
                    if (column.AccessibleHeaderText == "ICODIE")
                    {
                        IndiceColumnaICODIE = grd001.Columns.IndexOf(column);
                        break;
                    }
                }

                for (int i = 0; i < grd001.Rows.Count; i++)
                {
                    if (grd001.Rows[i].Cells[8].Text == null || grd001.Rows[i].Cells[8].Text.IndexOf("01-01-1900") != -1 || grd001.Rows[i].Cells[8].Text.IndexOf("1-1-1900") != -1 || grd001.Rows[i].Cells[8].Text.IndexOf("1/1/1900") != -1)
                    {
                        grd001.Rows[i].Cells[8].Text = null;
                    }

                    GridViewRow ci = ((GridViewRow)grd001.Rows[i]); //.Columns[IndiceColumna]);
                    //if (grd001.Rows[i].Cells[IndiceColumnaSeleccionar].Text == "")
                    if (Convert.ToString(dt.Rows[i]["Seleccionar"]) == "")
                    {

                        LinkButton lnkegresar = (LinkButton)ci.FindControl("lnkegresar");


                        lnkegresar.CommandArgument = grd001.Rows[i].Cells[IndiceColumnaICODIE].ToString();
                        if (window.existetoken("A638709F-43F2-4319-B1CA-2D675EC5C5C4"))
                        {
                            lnkegresar.Visible = true;
                        }
                        HtmlTable tblges = (HtmlTable)ci.FindControl("tblges");
                        tblges.Visible = false;
                    }

                    //else if (grd001.Rows[i].Cells[IndiceColumnaSeleccionar].ToString() == "ENGESTACION")
                    else if (Convert.ToString(dt.Rows[i]["Seleccionar"]) == "ENGESTACION")
                    {
                        //grd001.Rows[i].Cells[IndiceColumnaSeleccionar].Text = "";
                        //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[i];
                        //GridViewRow ci = ((GridViewRow)grd001.Rows[i]);

                        LinkButton lnkegresarg = (LinkButton)ci.FindControl("lnkegresarg");

                        lnkegresarg.CommandArgument = grd001.Rows[i].Cells[IndiceColumnaICODIE].Text;
                        if (window.existetoken("A638709F-43F2-4319-B1CA-2D675EC5C5C4"))
                        {
                            lnkegresarg.Visible = true;
                            LinkButton lnkegresar2g = (LinkButton)ci.FindControl("lnkegresar2g");
                            lnkegresar2g.CommandArgument = grd001.Rows[i].Cells[IndiceColumnaICODIE].Text;
                            lnkegresar2g.Visible = true;
                            Label lbltitle = (Label)ci.FindControl("lbltitle");
                            lbltitle.Visible = true;
                            HtmlTable tblges = (HtmlTable)ci.FindControl("tblges");
                            tblges.Visible = true;
                        }
                    }//EGRESADO
                    //else if (grd001.Rows[i].Cells[IndiceColumnaSeleccionar].Text == "EGRESADO")
                    else if (Convert.ToString(dt.Rows[i]["Seleccionar"]) == "EGRESADO")
                    {


                        //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[i];

                        //GridViewRow ci = ((GridViewRow)grd001.Rows[i]);

                        LinkButton lnkegresarg = (LinkButton)ci.FindControl("lnkegresarg");
                        //grd001.Rows[i].Cells[IndiceColumnaSeleccionar].Text = "";
                        //lnkbtn.CommandArgument = grd001.Rows[i].Cells[IndiceColumnaICODIE].Text;
                        string valor = Convert.ToString(dt.Rows[i]["ICodIE"]);
                        lnkegresarg.CommandArgument = valor;
                        lnkegresarg.Visible = true;

                        LinkButton lnkegresar3g = (LinkButton)ci.FindControl("lnkegresar3g");
                        //lnkbtn1.CommandArgument = grd001.Rows[i].Cells[IndiceColumnaICODIE].Text;
                        lnkegresar3g.CommandArgument = Convert.ToString(dt.Rows[i]["ICodIE"]);

                        lnkegresar3g.Attributes["IE"] = "1";

                        if (window.existetoken("ECA2B3FC-B8CB-4E4D-AF27-0A8842AAA0C7"))
                        {
                            lnkegresar3g.Visible = true;
                        }

                        Label lbltitle = (Label)ci.FindControl("lbltitle");
                        lbltitle.Visible = true;                        
                        HtmlTable tblges = (HtmlTable)ci.FindControl("tblges");
                        tblges.Visible = false;
                        
                    }
                    else
                    {
                        //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[i];
                        //GridViewRow ci = ((GridViewRow)grd001.Rows[i]);
                        Label lblegreso = (Label)ci.FindControl("lblegreso");
                        lblegreso.Text = ""; // ci.Text;
                        lblegreso.Visible = true;
                        HtmlTable tblges = (HtmlTable)ci.FindControl("tblges");
                        tblges.Visible = false;
                    }

                }
                //gfontbrevis

                //ejecutar javascript para fijar header de tabla si supera 15 filas
                if (grd001.Rows.Count > 15)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader", "fixHeader('#grd001', '#tableHeader');", true);
                }
                //TODO: revisar cuando despues de una busqueda se agrega otro filtro: que avise cuando no hay resultados.


                //Esto es lo que se debe añadir para formatear la tabla
                
                //grd001.FooterRow.TableSection = TableRowSection.TableFooter; //Se añade la sección tfooter al grid

                Session["ICODIE"] = SSnino.ICodIE;
                sessionICODIE.Value = Convert.ToString(Session["ICODIE"]);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$(document).ready(function () { $('#grd001').DataTable({ searching: true, sort: false, paging: false }); });", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$(document).ready(function() { x = $('#sessionICODIE').val()  });", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "c", "$(document).ready(function () { $('#grd001_wrapper #grd001_filter input').val(x) });", true);
            }
        }
        catch
        {
            ddl_Proyecto.Items.Add(new ListItem("Seleccionar", "0"));
        }   
    }

    #region base de datos
    

    private DataTable callto_getparmedidassugeridas()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparMedidasSugeridas";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_getparmedidassugeridasLRPA()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparMedidasSugeridasLRPA";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_getparconquienegresa()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparConQuienEgresa";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();

        dr[0] = "0";
        dr[1] = "SELECCIONAR";
        dr[2] = "V";

        dt.Rows.Add(dr);
        
        return dt;
    }

    public DataTable callto_update_egresos(int icodie, DateTime fechaegreso, string glosa, int codcausalegreso, string tieneordentribunal, int codmedidaaplicadatribunal, int codmedidasugeridatribunal, int codconquienegresa, int codproyectoegresa, int idusuarioactualizacion, DateTime fechaactualizacion, int codcalidadjuridica)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Update_Egresos";
        //sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Text = icodie;
        //sqlc.Parameters.Add("@FechaEgreso", SqlDbType.DateTime, 16).Text = fechaegreso;
        //sqlc.Parameters.Add("@Glosa", SqlDbType.VarChar, 200).Text = glosa;
        //sqlc.Parameters.Add("@CodCausalEgreso", SqlDbType.Int, 4).Text = codcausalegreso;
        //sqlc.Parameters.Add("@TieneOrdenTribunal", SqlDbType.Char, 2).Text = tieneordentribunal;
        //sqlc.Parameters.Add("@CodMedidaAplicadaTribunal", SqlDbType.Int, 4).Text = codmedidaaplicadatribunal; 
        //sqlc.Parameters.Add("@CodMedidaSugeridaTribunal", SqlDbType.Int, 4).Text = codmedidasugeridatribunal;
        //sqlc.Parameters.Add("@CodConQuienEgresa", SqlDbType.Int, 4).Text = codconquienegresa;
        //sqlc.Parameters.Add("@CodProyectoEgresa", SqlDbType.Int, 4).Text = codproyectoegresa;
        //sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Text = idusuarioactualizacion;
        //sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Text = fechaactualizacion;
        //sqlc.Parameters.Add("@CodCalidadJuridica", SqlDbType.Int, 4).Text = codcalidadjuridica;
        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        DataTable dt = new DataTable();
        Conexiones con = new Conexiones();
        con.Autenticar();
        dt = con.TraerDataTable("Update_Egresos", icodie, fechaegreso, glosa, codcausalegreso, tieneordentribunal, codmedidaaplicadatribunal, codmedidasugeridatribunal, codconquienegresa, codproyectoegresa, idusuarioactualizacion, fechaactualizacion, codcalidadjuridica);
        con.CerrarConexion();
        con.Desconectar(); //x seaca
        
        //sconn.Open();
        //da.Fill(dt);
        //sconn.Close();
        return dt;
    }
    private DataTable callto_sp_ninosdelproyecto(int codinstitucion, int codproyecto)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "sp_ninosdelproyecto";
        //sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Text = codinstitucion;
        //sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Text = codproyecto;
        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        Conexiones con = new Conexiones();
        con.Autenticar();
        DataTable dt = new DataTable();
        dt = con.TraerDataTable("sp_ninosdelproyecto", codinstitucion, codproyecto);
        con.CerrarConexion();
        con.Desconectar();

        
        //sconn.Open();
        //da.Fill(dt);
        //sconn.Close();
        return dt;
    }

    private DataTable sp_ninosdelproyectoEgresos(int codinstitucion, int codproyecto, string appaterno, string apmaterno, string Nombres)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "sp_ninosdelproyectoEgresos";
        //sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Text = codinstitucion;
        //sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Text = codproyecto;
        //sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.NVarChar, 255).Text = appaterno;
        //sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.NVarChar, 255).Text = apmaterno;
        //sqlc.Parameters.Add("@Nombres", SqlDbType.NVarChar, 255).Text = Nombres;
        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        Conexiones con = new Conexiones();
        con.Autenticar();
        DataTable dt = new DataTable();
        dt = con.TraerDataTable("sp_ninosdelproyectoEgresos", codinstitucion, codproyecto, appaterno, apmaterno, Nombres);
        con.CerrarConexion();
        con.Desconectar();

        
        //sconn.Open();
        //da.Fill(dt);
        //sconn.Close();
        return dt;
    }
    private DataTable callto_cierre_egreso(int icodie, DateTime fechaegreso, int idusuarioactualizacion)
    {
        DataTable dt = new DataTable();
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_Egreso";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@FechaEgreso", SqlDbType.DateTime, 16).Value = fechaegreso;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        //Conexiones con = new Conexiones();
        //con.Autenticar();
        
        //dt = con.TraerDataTable("cierre_Egreso", icodie, fechaegreso.ToShortDateString(), idusuarioactualizacion);
        //con.CerrarConexion();
        //con.Desconectar();

        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_get_nino_ingreso(int icodie)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Get_Nino_Ingreso";
        //sqlc.Parameters.Add("@IcodIE", SqlDbType.Int, 4).Text = icodie;
        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        Conexiones con = new Conexiones();
        con.Autenticar();
        DataTable dt = new DataTable();
        dt = con.TraerDataTable("Get_Nino_Ingreso", icodie);
        con.CerrarConexion();
        con.Desconectar();
                
        //sconn.Open();
        //da.Fill(dt);
        //sconn.Close();
        return dt;

        if (Convert.ToInt32(ddow011.SelectedValue) > 0)
        {
            int nacionalidad = 0;
            nacionalidad = Convert.ToInt32(ddow011.SelectedValue);
        }
    }
    private DataTable callto_get_ordentribunalegreso(int icodie)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Get_OrdenTribunalEgreso";
        //sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Text = icodie;
        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        Conexiones con = new Conexiones();
        con.Autenticar();
        DataTable dt = new DataTable();
        dt = con.TraerDataTable("Get_OrdenTribunalEgreso", icodie);
        con.CerrarConexion();
        con.Desconectar();
        
        //sconn.Open();
        //da.Fill(dt);
        //sconn.Close();
        return dt;
    }

    private DataTable callto_getpartipoegreso()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoEgreso";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private DataTable callto_getparcausalegreso(int codtipoegreso)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparCausalEgreso";
        sqlc.Parameters.Add("@CodTipoEgreso", SqlDbType.Int, 4).Value = codtipoegreso;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTableCollection callto_get_antecedentesegreso(int codproyecto, int icodie)
    {
        /*
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_AntecedentesEgreso";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Text = codproyecto;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataSet ds = new DataSet();
        sconn.Open();
        da.Fill(ds);
        sconn.Close();
        return ds.Tables;*/

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_AntecedentesEgreso";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@icodie", SqlDbType.Int, 4).Value = icodie;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataSet ds = new DataSet();
        sconn.Open();
        da.Fill(ds);
        sconn.Close();
        return ds.Tables;
    }
    #endregion
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grd001_ClickCellButton(object sender, EventArgs e)
    {


    }
    private DataTable callto_insert_ordentribunalegreso(int icodie, int codtribunal, DateTime fechaorden, string numeroexpediente, DateTime fechaactualizacion, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_OrdenTribunalEgreso";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = codtribunal;
        sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime, 16).Value = fechaorden;
        sqlc.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar, 100).Value = numeroexpediente;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_update_ordentribunalegreso(int icodie, int codtribunal, DateTime fechaorden, string numeroexpediente, int idusuarioactualizacion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_OrdenTribunalEgreso";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = codtribunal;
        sqlc.Parameters.Add("@FechaOrden", SqlDbType.DateTime, 16).Value = fechaorden;
        sqlc.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar, 100).Value = numeroexpediente;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    private DataTable callto_getpartipoegresoLRPA()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetparTipoEgresoLRPA";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private void getpartipo()
    {
        ddown003.Items.Clear();
        DataTable dt = new DataTable();
        bool swLrpa = FiltroLRPA();

        if (swLrpa)
        {

            dt = callto_getpartipoegresoLRPA();

        }
        else
        {

            dt = callto_getpartipoegreso();
        }
        DataRow dr = dt.NewRow();
        dr[0] = "-1";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        DataView dv = new DataView(dt);
        dv.Sort = "Descripcion";

        ddown003.DataSource = dv;
        ddown003.DataValueField = "CodTipoEgreso";
        ddown003.DataTextField = "Descripcion";
        ddown003.DataBind();

    }

    private void getparcausal()
    {
       
            ddown004.Items.Clear();
            DataTable dt = callto_getparcausalegreso(Convert.ToInt32(ddown003.SelectedValue));

            DataRow dr = dt.NewRow();
            dr[0] = "-1";
            dr[2] = " Seleccionar";
            dt.Rows.Add(dr);
            DataView dv = new DataView(dt);
            dv.Sort = "Descripcion";
            ddown004.DataSource = dv;
            ddown004.DataValueField = "CodCausalEgreso";
            ddown004.DataTextField = "Descripcion";
            ddown004.DataBind();
        

    }

    private void getparconquien()
    {
        ddown009.Items.Clear();
        DataView dv = new DataView(callto_getparconquienegresa());

        dv.Sort = "CodConQuienEgresa ASC";

        ddown009.DataSource = dv;
        ddown009.DataValueField = "CodConQuienEgresa";
        ddown009.DataTextField = "Descripcion";
        ddown009.DataBind();

    }
    private void getregiones()
    {
        parcoll pcoll = new parcoll();
        DataTable dt = pcoll.GetparRegion();
        ddown012.DataValueField = "CodRegion";
        ddown012.DataTextField = "Descripcion";
        ddown012.DataSource = dt;
        ddown012.DataBind();

    }
    private void gettipotribunales()
    {
        parcoll pcoll = new parcoll();
        DataTable dt = pcoll.GetparTipoTribunal();
        ddown013.DataValueField = "TipoTribunal";
        ddown013.DataTextField = "Descripcion";
        ddown013.DataSource = dt;
        ddown013.DataBind();

    }
    private void gettribunales()
    {
        parcoll pcoll = new parcoll();
        DataTable dt = pcoll.GetparTribunales(ddown012.SelectedValue, ddown013.SelectedValue);
        ddown006.DataValueField = "CodTribunal";
        ddown006.DataTextField = "Descripcion";
        ddown006.DataSource = dt;
        ddown006.DataBind();


    }
    private bool FiltroLRPA()
    {
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(Convert.ToInt32(ddl_Proyecto.SelectedValue));

        if (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
        {
            swLrpa = true;
        }
        else
        {
            swLrpa = false;
        }

        return (swLrpa);


        #endregion

    }
    private void getparmedidassugeridas()
    {
        parcoll pcoll = new parcoll();
        DataTable dt = new DataTable();
        bool swLrpa = FiltroLRPA();

        if (swLrpa)
        {
            dt = callto_getparmedidassugeridasLRPA();
        }
        else
        {
            dt = callto_getparmedidassugeridas();
        }
        ddown008.Items.Clear();
        ddown007.Items.Clear();
        DataRow dr = dt.NewRow();
        dr[0] = "-1";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        DataView dv = new DataView(dt);


        ddown007.DataValueField = "CodMedidasSugeridas";
        ddown007.DataTextField = "Descripcion";
        ddown007.DataSource = dv;
        dv.Sort = "CodMedidasSugeridas";
        ddown007.DataBind();


        ddown008.DataValueField = "CodMedidasSugeridas";
        ddown008.DataTextField = "Descripcion";
        ddown008.DataSource = dv;
        dv.Sort = "CodMedidasSugeridas";
        ddown008.DataBind();



    }
    private void getcalidad()
    {


        parcoll pcoll = new parcoll();

        DataTable dt = pcoll.GetparCalidadJuridica();

        ddown010.Items.Clear();
        DataRow dr = dt.NewRow();
        dr[0] = "-1";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        DataView dv = new DataView(dt);



        ddown010.DataValueField = "CodCalidadJuridica";
        ddown010.DataTextField = "Descripcion";
        dv.Sort = "CodCalidadJuridica";
        ddown010.DataSource = dv;
        ddown010.DataBind();
    }

    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        getparcausal();
        //ddown004_SelectedIndexChanged(sender, e);
        activarDesactivarProyectoConQuienEgresa();
    }
    protected void rdo001_CheckedChanged(object sender, EventArgs e)
    {
        Pnl_Orden.Visible = true;
        if (rdo001.Checked)
        {
            txt003.Visible = false;
            tr_expediente.Visible = false;
        }
        else
        {
            txt003.Visible = true;
            tr_expediente.Visible = true;
        }
        getpanelordenes();
        imb_guardar.Focus();
        activarDesactivarProyectoConQuienEgresa();
    }
    protected void rdo005_CheckedChanged(object sender, EventArgs e)
    {
        Pnl_Orden.Visible = true;
        if (rdo001.Checked)
        {
            txt003.Visible = false;
            tr_expediente.Visible = false;
        }
        else
        {
            txt003.Visible = true;
            tr_expediente.Visible = true;
        }
        getpanelordenes();
        imb_guardar.Focus();

        activarDesactivarProyectoConQuienEgresa();
    }

    private void mostrar_modal_egreso()
    {
        iframe_egreso.Src = "../mod_ninos/MensajeEgreso.aspx?&dir=../mod_ninos/ninos_Egreso.aspx";
        iframe_egreso.Attributes.Add("height", "220px");
        iframe_egreso.Attributes.Add("width", "650px");
        //iframe_egreso.Attributes.Add("height", "320px");
        //iframe_egreso.Attributes.Add("width", "420px");
        mpe4.Show();
        
    }

    protected void lnkegresarg_Click(object sender, EventArgs e)
    {
        //DataTable dt = callto_sp_ninosdelproyecto(Convert.ToInt32(ddown001.SelectedValue),Convert.ToInt32(ddown002.SelectedValue));
        string msg = "";
        GridViewRow grvr = (GridViewRow)((LinkButton)sender).NamingContainer;

        string cinst = ddl_Institucion.SelectedValue.ToString();
        string cproy = ddl_Proyecto.SelectedValue.ToString();
        string rut = grvr.Cells[2].Text;
        Int32 codie = Convert.ToInt32(grvr.Cells[1].Text);
        Int32 cnino = Convert.ToInt32(grvr.Cells[0].Text);
        SSnino.CodNino = Convert.ToInt32(grvr.Cells[0].Text);
        SSnino.ICodIE = Convert.ToInt32(grvr.Cells[1].Text);

        oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, grvr.Cells[4].Text, grvr.Cells[5].Text, grvr.Cells[6].Text, grvr.Cells[7].Text, grvr.Cells[8].Text);
        Session["NNA"] = NNA;

        DataTable dt = callto_sp_ninosdelproyecto(Convert.ToInt32(ddl_Institucion.SelectedValue), Convert.ToInt32(ddl_Proyecto.SelectedValue));
        DataTableCollection dtc = callto_get_antecedentesegreso(Convert.ToInt32(ddl_Proyecto.SelectedValue), Convert.ToInt32(grvr.Cells[1].Text));
        //DataTableCollection dtc = callto_get_antecedentesegreso(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(((LinkButton)sender).CommandArgument));

        if (dtc[0].Rows.Count > 0 || dtc[1].Rows.Count > 0 || dtc[2].Rows.Count > 0 || dtc[3].Rows.Count > 0 || dtc[4].Rows.Count > 0)
        {
            for (int i = 0; i < dtc.Count; i++)
            {
                for (int j = 0; j < dtc[i].Rows.Count; j++)
                {
                    //msg += "(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " <br>";//Environment.NewLine;
                    //msg += "<input type=\"button\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" Value=\"(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "\" /> <br>";//Environment.NewLine;

                    //msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                    switch (i)
                    {
                        case 0:
                            if (window.existetoken("6F360136-E048-44FA-828E-E62CE3BDE05F"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                            break;

                        case 1:
                        case 2:
                        case 4:

                            if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                            break;

                        case 3:
                            if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                            break;
                    }
                }
            }
            msgEgreso = msg;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;

                //if (dt.Rows[i]["ICODIE"].ToString() == ((LinkButton)sender).CommandArgument)
                if (dt.Rows[i]["ICODIE"].ToString() == fila.Cells[1].Text)
                {
                    nombreNinoEgreso = dt.Rows[i]["Nombres"].ToString() + " " + dt.Rows[i]["Apellido_Paterno"].ToString() + " " + dt.Rows[i]["Apellido_Materno"].ToString();
                }
            }

            mostrar_modal_egreso();
        }
        else
        {
            txt_nombres.Text = grvr.Cells[4].Text;
            txt_apaterno.Text = grvr.Cells[5].Text;
            txt_amaterno.Text = grvr.Cells[6].Text;
            bloquear_busqueda();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Seleccionar"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;
                    //if (dt.Rows[i]["ICODIE"].ToString() != ((LinkButton)sender).CommandArgument)
                    if (dt.Rows[i]["ICODIE"].ToString() != fila.Cells[1].Text)
                    {
                        dt.Rows[i].Delete();
                    }
                    else
                    {
                        if (((LinkButton)sender).CommandName == "G")
                        {
                            dt.Rows[i]["Seleccionar"] = "NIÑO EN GESTACION";
                        }
                        else
                        {
                            dt.Rows[i]["Seleccionar"] = "EGRESO NORMAL";
                        }
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                grd001.DataSource = dt;
                grd001.DataBind();
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
                //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[0];
                GridViewRow ci = ((GridViewRow)grd001.Rows[0]);

                Label lbl = (Label)ci.FindControl("lblcomment");
                lbl.Text = "Niño en Gestación";
                lbl.Visible = true;

                //JOVM 23/03/2015
                //grd001.Height = 70;

                getdatapanel1();

               

                pnl001.Visible = true;
                ddown003.Enabled = false;
                ddown004.Enabled = false;
                rdo001.Enabled = false;
                rdo002.Enabled = false;
                rdo005.Enabled = false;
                Pnl_Orden.Visible = false;
                pnl002.Visible = false;
                imb_guardar.Text = "<span class='glyphicon glyphicon-arrow-right'></span>&nbsp;Egresar";//gfontbrevis agrega icono ->
                imb_guardar.Visible = true; 
                

                lnkValidateRut = true;

                LRPAcoll lrpa = new LRPAcoll();
                GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;
                //int icodie = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                int icodie = Convert.ToInt32(fila.Cells[1].Text);
                int codcalidadjuridica = lrpa.GetCalidadJuridica_IcodIE(icodie);

                bool sw = FiltroLRPA();
                if (sw)
                {
                    ddown010.SelectedValue = codcalidadjuridica.ToString();
                    ddown010.Enabled = false;
                    ddown009.SelectedValue = "12";
                    ddown009.Enabled = false;
                }
                else
                {
                    ddown009.SelectedValue = "0";
                    ddown009.Enabled = true;
                }

                if (ddown009.SelectedValue == "1")
                {
                    txtproyecto.Enabled = true;
                    ddlProyectoConQuienEgresa.Enabled = true;
                    imb_lupa_modal2.Attributes.Remove("disabled");
                }
                else
                {
                    txtproyecto.Enabled = false;
                    ddlProyectoConQuienEgresa.Enabled = false;
                    imb_lupa_modal2.Attributes.Add("disabled", "disabled");
                }
            }
        }
    }
    protected void lnkegresar3g_Click(object sender, EventArgs e)
    {
        DataTable dt = callto_sp_ninosdelproyecto(Convert.ToInt32(ddl_Institucion.SelectedValue), Convert.ToInt32(ddl_Proyecto.SelectedValue));
        GridViewRow grvr = (GridViewRow)((LinkButton)sender).NamingContainer;

        string cinst = ddl_Institucion.SelectedValue.ToString();
        string cproy = ddl_Proyecto.SelectedValue.ToString();
        string rut = grvr.Cells[2].Text;
        Int32 codie = Convert.ToInt32(grvr.Cells[1].Text);
        Int32 cnino = Convert.ToInt32(grvr.Cells[0].Text);
        SSnino.CodNino = Convert.ToInt32(grvr.Cells[0].Text);
        SSnino.ICodIE = Convert.ToInt32(grvr.Cells[1].Text);
        SSnino.FechaNacimiento = Convert.ToDateTime(grvr.Cells[8].Text.ToString());
        

        oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, grvr.Cells[4].Text, grvr.Cells[5].Text, grvr.Cells[6].Text, grvr.Cells[7].Text, grvr.Cells[8].Text);
        Session["NNA"] = NNA;

        if (dt.Rows.Count > 0)
        {
            dt.Columns.Add(new DataColumn("Seleccionar"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;

                //if (dt.Rows[i]["ICODIE"].ToString() != ((LinkButton)sender).CommandArgument)
                if (dt.Rows[i]["ICODIE"].ToString() != fila.Cells[1].Text)
                {
                    dt.Rows[i].Delete();
                }
                else
                {
                    dt.Rows[i]["Seleccionar"] = "NIÑO EGRESADO";
                }
            }
        }

        if (dt.Rows.Count > 0)
        {
            
            txt_nombres.Text = grvr.Cells[4].Text;
            txt_apaterno.Text = grvr.Cells[5].Text;
            txt_amaterno.Text = grvr.Cells[6].Text;
            bloquear_busqueda();


            LRPAcoll lrpa = new LRPAcoll();
            grd001.DataSource = dt;
            grd001.DataBind();
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
            //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[0];
            GridViewRow ci = ((GridViewRow)grd001.Rows[0]);

            Label lbl = (Label)ci.FindControl("lblcomment");
            lbl.Text = "Niño Egresado";
            lbl.Visible = true;
            // JOVM 23/03/2015
            //grd001.Height = 70;
            pnl001.Visible = true;

            getdatapanel1();

            DataTable dt3 = callto_get_nino_ingreso(Convert.ToInt32(grd001.Rows[0].Cells[1].Text));

            call001.Text = (Convert.ToDateTime(dt3.Rows[0]["FechaEgreso"])).ToString("dd/MM/yyyy");
            txt002.Text = dt3.Rows[0]["Glosa"].ToString();
            
            getpartipo();

            ddown003.SelectedItem.Selected = false;
            ddown004.SelectedItem.Selected = false;
            ddown009.SelectedItem.Selected = false;

            ddown010.SelectedItem.Selected = false;

            try
            {
                ddown003.Items.FindByValue(dt3.Rows[0]["CodTipoEgreso"].ToString()).Selected = true;
            }
            catch
            {
                DataTable dtTipoEgreso = lrpa.GetTipoEgreso_bycod(Convert.ToInt32(dt3.Rows[0]["CodTipoEgreso"]));
                ddown003.Items.Add(new ListItem(dtTipoEgreso.Rows[0]["Descripcion"].ToString(), dtTipoEgreso.Rows[0]["CodTipoEgreso"].ToString()));
                ddown003.Items.FindByValue(dt3.Rows[0]["CodTipoEgreso"].ToString()).Selected = true;
            }

            getparcausal();


            try
            {
                ddown004.Items.FindByValue(dt3.Rows[0]["CodCausalEgreso"].ToString()).Selected = true;
            }
            catch
            {

                ddown004.Items.Add(new ListItem(dt3.Rows[0]["CodCausalEgreso"].ToString(), dt3.Rows[0]["Descripcion"].ToString()));
                ddown004.Items.FindByValue(dt3.Rows[0]["CodCausalEgreso"].ToString()).Selected = true;
            }

            if (ddown004.SelectedValue == "65" || ddown004.SelectedValue == "26")
            {
                ninocoll ncoll = new ninocoll();
                trFechaDefuncion.Visible = true;
                trLugarFallecimiento.Visible = true;
                trRegionFallecimiento.Visible = true;
                trComunaFallecimiento.Visible = true;
                
                txtCausalFallecimiento.Text = dt3.Rows[0]["CausalFallecimiento"].ToString();

                txtFechaDefuncion.Text = (Convert.ToDateTime(dt3.Rows[0]["FechaDefuncion"])).ToShortDateString();
                ddlLugarFallecimiento.Items.FindByValue(dt3.Rows[0]["CodLugarFallecimiento"].ToString()).Selected = true;

                int CodComunaFallecimiento = Convert.ToInt32(dt3.Rows[0]["CodComunaFallecimiento"]);
                int CodRegionFallecimiento = ncoll.GetCodRegion(CodComunaFallecimiento);

                ddlRegionFallecimiento.SelectedValue = CodRegionFallecimiento.ToString();
                ddlRegionFallecimiento_SelectedIndexChanged(sender, e);
                ddlComunaFallecimiento.SelectedValue = CodComunaFallecimiento.ToString();
                trCausalFallecimiento.Visible = true;

                ///
                trExisteDenunciaMinisterio.Visible = true;
                trExisteQuerella.Visible = true;
                trSeActivoCircular.Visible = true;
                ///
                trFechaCertificado.Visible = true;
                trNumeroCertificado.Visible = true;
                //
                trRellenoDefuncion.Visible = true;
                trTituloDetallesDefuncion.Visible = true;

                if (Convert.ToDateTime(dt3.Rows[0]["FechaDenunciaMP"]).ToShortDateString() != "01-01-1900")
                {
                    rbtnExisteDenunciaMinisterioSi.Checked = true;
                    rbtnExisteDenunciaMinisterioNo.Checked = false;
                    trFechaDenunciaMinisterio.Visible = true;
                    txtFechaDenunciaMinisterio.Text = Convert.ToDateTime(dt3.Rows[0]["FechaDenunciaMP"]).ToShortDateString();
                }
                else
                {
                    rbtnExisteDenunciaMinisterioNo.Checked = true;
                    rbtnExisteDenunciaMinisterioSi.Checked = false;
                    trFechaDenunciaMinisterio.Visible = false;
                    txtFechaDenunciaMinisterio.Text = "";
                }

                if (Convert.ToDateTime(dt3.Rows[0]["FechaQuerella"]).ToShortDateString() != "01-01-1900")
                {
                    rbtnExisteQuerellaSi.Checked = true;
                    rbtnExisteQuerellaNo.Checked = false;
                    trFechaQuerella.Visible = true;
                    txtFechaQuerella.Text = Convert.ToDateTime(dt3.Rows[0]["FechaQuerella"]).ToShortDateString();
                }
                else
                {
                    rbtnExisteQuerellaNo.Checked = true;
                    rbtnExisteQuerellaSi.Checked = false;
                    trFechaQuerella.Visible = false;
                    txtFechaQuerella.Text = "";
                }

                if (Convert.ToInt32(SSnino.CodInst) == 6050)
                {
                    thCircular2309.Visible = true;
                    tdCircular2309.Visible = true;
                    thCircular2308.Visible = false;
                    tdCircular2308.Visible = false;

                    if (dt3.Rows[0]["SeActivaCircular"].ToString() == "1")
                    {
                        rbtnSeActivoCircular2309Si.Checked = true;
                        rbtnSeActivoCircular2309No.Checked = false;
                    }
                    else
                    {
                        rbtnSeActivoCircular2309Si.Checked = false;
                        rbtnSeActivoCircular2309No.Checked = true;
                    }
                }
                else
                {
                    thCircular2308.Visible = true;
                    tdCircular2308.Visible = true;
                    thCircular2309.Visible = false;
                    tdCircular2309.Visible = false;

                    if (dt3.Rows[0]["SeActivaCircular"].ToString() == "1")
                    {
                        rbtnSeActivoCircular2308Si.Checked = true;
                        rbtnSeActivoCircular2308No.Checked = false;
                    }
                    else
                    {
                        rbtnSeActivoCircular2308Si.Checked = false;
                        rbtnSeActivoCircular2308No.Checked = true;
                    }
                }

                if (Convert.ToDateTime(dt3.Rows[0]["FechaCertificado"]).ToShortDateString() != "01-01-1900")
                {
                    txtFechaCertificado.Text = Convert.ToDateTime(dt3.Rows[0]["FechaCertificado"]).ToShortDateString();
                }
                else
                {                    
                    txtFechaCertificado.Text = "";
                }

                if (dt3.Rows[0]["NumeroCertificado"].ToString().Trim() != "0")
                {
                    txtNumeroCertificado.Text = dt3.Rows[0]["NumeroCertificado"].ToString();
                }
                else
                {
                    txtNumeroCertificado.Text = "";
                }



            }
            else
            {
                trFechaDefuncion.Visible = false;
                trLugarFallecimiento.Visible = false;
                trRegionFallecimiento.Visible = false;
                trComunaFallecimiento.Visible = false;

                trCausalFallecimiento.Visible = false;

                ///
                trExisteDenunciaMinisterio.Visible = false;
                trExisteQuerella.Visible = false;
                trSeActivoCircular.Visible = false;
                thCircular2309.Visible = false;
                tdCircular2309.Visible = false;
                thCircular2308.Visible = false;
                tdCircular2308.Visible = false;                
                ///

                trFechaCertificado.Visible = false;
                trNumeroCertificado.Visible = false;
                //

                trRellenoDefuncion.Visible = false;
                trTituloDetallesDefuncion.Visible = false;
            }

            try
            {
                ddown009.Items.FindByValue(dt3.Rows[0]["CodConQuienEgresa"].ToString()).Selected = true;
            }
            catch
            {
                ddown009.Items.Add(new ListItem(dt3.Rows[0]["ConQuienEgresa"].ToString(), dt3.Rows[0]["CodConQuienEgresa"].ToString()));
                ddown009.Items.FindByValue(dt3.Rows[0]["CodConQuienEgresa"].ToString()).Selected = true;
            }

            chk001.Checked = true;
            try
            {
                ddown008.SelectedItem.Selected = false;
                ddown008.Items.FindByValue(dt3.Rows[0]["CodMedidaSugeridaTribunal"].ToString()).Selected = true;
            }
            catch
            {
            }
            ddown010.Items.FindByValue(dt3.Rows[0]["CodCalidadJuridica"].ToString()).Selected = true;

            if (dt3.Rows[0]["TieneOrdenTribunal"].ToString() == "SI")
            {
                rdo002.Checked = false;
                rdo001.Checked = true;

                getpanelordenes();
                Pnl_Orden.Visible = true;

                DataTable dt4 = callto_get_ordentribunalegreso(Convert.ToInt32(grd001.Rows[0].Cells[1].Text));
                if (dt4.Rows.Count == 1)
                {
                    //call002.Text = dt4.Rows[0]["FechaOrden"].ToString();
                    call002.Text = (Convert.ToDateTime(dt4.Rows[0]["FechaOrden"])).ToString("dd/MM/yyyy");
                    txt003.Text = dt4.Rows[0]["NumeroExpediente"].ToString();
                    ddown012.SelectedItem.Selected = false;
                    ddown012.Items.FindByValue(dt4.Rows[0]["CodRegion"].ToString()).Selected = true;
                    ddown013.SelectedItem.Selected = false;
                    ddown013.Items.FindByValue(dt4.Rows[0]["TipoTribunal"].ToString()).Selected = true;
                    gettribunales();
                    try
                    {
                        ddown006.SelectedItem.Selected = false;
                        ddown006.Items.FindByValue(dt4.Rows[0]["CodTribunal"].ToString()).Selected = true;
                    }
                    catch
                    { }
                    ddown007.SelectedItem.Selected = false;
                    ddown007.Items.FindByValue(dt3.Rows[0]["CodMedidaAplicadaTribunal"].ToString()).Selected = true;
                    imb_guardar.Focus();
                }

            }
            else if (dt3.Rows[0]["TieneOrdenTribunal"].ToString() == "NO")
            {
                rdo002.Checked = true;
                rdo001.Checked = false;
                Pnl_Orden.Visible = false;
            }
            else if (dt3.Rows[0]["TieneOrdenTribunal"].ToString() == "ET")
            {
                rdo002.Checked = false;
                rdo005.Checked = true;
                getpanelordenes();
                Pnl_Orden.Visible = true;
            }
            //rdo001.Enabled = false;
            //rdo002.Enabled = false;
            //rdo005.Enabled = false;

            GridViewRow Fila = (GridViewRow)((LinkButton)sender).NamingContainer;
            //int icodie = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            int icodie = Convert.ToInt32(Fila.Cells[1].Text);
            int codcalidadjuridica = lrpa.GetCalidadJuridica_IcodIE(icodie);

            
            imb_guardar.Text = "Actualizar";
            imb_guardar.Visible = true;
            lnkValidateRut = true;

            lbl_resumen_filtro.Text = "<br>";
            lbl_resumen_filtro.Text += "<strong>Busqueda: </strong>";
            lbl_resumen_filtro.Text += "" + ddl_Proyecto.SelectedItem.Text + " ";
            if (txt_apaterno.Text != "")
            {
                lbl_resumen_filtro.Text += "// " + txt_apaterno.Text + "";
            }

            if (txt_amaterno.Text != "")
            {
                lbl_resumen_filtro.Text += " " + txt_amaterno.Text + " ";
            }

            if (txt_nombres.Text != "")
            {
                lbl_resumen_filtro.Text += "" + txt_nombres.Text + "";
            }

            lbl_resumen_filtro.Text += "<br>";


            lbl_resumen_filtro.Style.Add("display", "none");
            lbl_resumen_filtro.Visible = true;
            

            ValidacionDeEgresado();

            if (ddown009.SelectedValue == "1" || ddown009.SelectedValue == "15")
            {
                int codProyecto = 0, codInstitucion = 0;
                txtproyecto.Text = dt3.Rows[0]["CodProyectoEgresa"].ToString();
                txtproyecto.Enabled = true;
                ddlProyectoConQuienEgresa.Enabled = true;

                codProyecto = Convert.ToInt32(txtproyecto.Text);

                cargaProyConQuienEgresa(codProyecto);

                

                imb_lupa_modal2.Attributes.Remove("disabled");
            }
            else
            {
                txtproyecto.Enabled = false;
                ddlProyectoConQuienEgresa.Enabled = false;
                imb_lupa_modal2.Attributes.Add("disabled", "disabled");
            }

            bool sw = FiltroLRPA();
            if (sw)
            {
                ddown010.SelectedValue = codcalidadjuridica.ToString();
                ddown010.Enabled = false;
                ddown009.SelectedValue = "12";
                ddown009.Enabled = false;
            }
            else
            {
                ddown009.SelectedValue = "0";
                ddown009.Enabled = true;
            }

            if (ddown004.SelectedValue == "26")
            {
                //ddown009.SelectedValue = "16";
                ddown009.Enabled = false;
            }

        }
    }

    private void cargaProyConQuienEgresa(int codProyecto)
    {
        DataTable dtproy = new DataTable();

        dtproy = getProyectoxCodigo(codProyecto);

        DataView dv = new DataView(dtproy);
        dv.Sort = "CodProyecto";
        ddlProyectoConQuienEgresa.DataSource = dv;
        ddlProyectoConQuienEgresa.DataTextField = "CodProyNombre";
        ddlProyectoConQuienEgresa.DataValueField = "CodProyecto";
        ddlProyectoConQuienEgresa.DataBind();

        ddlProyectoConQuienEgresa.SelectedValue = codProyecto.ToString();
    }
    protected void lnkegresar2g_Click(object sender, EventArgs e)
    {
        //DataTable dt = callto_sp_ninosdelproyecto(Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue));
        string msg = "";

        DataTable dt = callto_sp_ninosdelproyecto(Convert.ToInt32(ddl_Institucion.SelectedValue), Convert.ToInt32(ddl_Proyecto.SelectedValue));

        GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;

        string cinst = ddl_Institucion.SelectedValue.ToString();
        string cproy = ddl_Proyecto.SelectedValue.ToString();
        string rut = fila.Cells[2].Text;
        Int32 codie = Convert.ToInt32(fila.Cells[1].Text);
        Int32 cnino = Convert.ToInt32(fila.Cells[0].Text);
        SSnino.CodNino = Convert.ToInt32(fila.Cells[0].Text);
        SSnino.ICodIE = Convert.ToInt32(fila.Cells[1].Text);

        oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, fila.Cells[4].Text, fila.Cells[5].Text, fila.Cells[6].Text, fila.Cells[7].Text, fila.Cells[8].Text);
        Session["NNA"] = NNA;

        //DataTableCollection dtc = callto_get_antecedentesegreso(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(((LinkButton)sender).CommandArgument));
        DataTableCollection dtc = callto_get_antecedentesegreso(Convert.ToInt32(ddl_Proyecto.SelectedValue), Convert.ToInt32(fila.Cells[1].Text));

        if (dtc[0].Rows.Count > 0 || dtc[1].Rows.Count > 0 || dtc[2].Rows.Count > 0 || dtc[3].Rows.Count > 0 || dtc[4].Rows.Count > 0)
        {
            for (int i = 0; i < dtc.Count; i++)
            {
                for (int j = 0; j < dtc[i].Rows.Count; j++)
                {
                    //msg += "(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " <br>";//Environment.NewLine;
                    //msg += "<input type=\"button\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" Value=\"(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "\" /> <br>";//Environment.NewLine;

                    //msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;

                    switch (i)
                    {
                        case 0:
                            if (window.existetoken("6F360136-E048-44FA-828E-E62CE3BDE05F"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                            break;

                        case 1:
                        case 2:
                        case 4:

                            if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                            break;

                        case 3:
                            if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                            break;
                    }
                }
            }

            msgEgreso = msg;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GridViewRow grFila = (GridViewRow)((LinkButton)sender).NamingContainer;
                //if (dt.Rows[i]["ICODIE"].ToString() == ((LinkButton)sender).CommandArgument)
                if (dt.Rows[i]["ICODIE"].ToString() == grFila.Cells[1].Text)
                {
                    nombreNinoEgreso = dt.Rows[i]["Nombres"].ToString() + " " + dt.Rows[i]["Apellido_Paterno"].ToString() + " " + dt.Rows[i]["Apellido_Materno"].ToString();
                }
            }

            mostrar_modal_egreso();
        }
        else
        {
            

            txt_nombres.Text = fila.Cells[4].Text;
            txt_apaterno.Text = fila.Cells[5].Text;
            txt_amaterno.Text = fila.Cells[6].Text;
            bloquear_busqueda();

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Seleccionar"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GridViewRow fila2g = (GridViewRow)((LinkButton)sender).NamingContainer;
                    //if (dt.Rows[i]["ICODIE"].ToString() != ((LinkButton)sender).CommandArgument)
                    if (dt.Rows[i]["ICODIE"].ToString() != fila2g.Cells[1].Text)
                    {
                        dt.Rows[i].Delete();
                    }
                    else
                    {
                        dt.Rows[i]["Seleccionar"] = "NIÑO EN GESTACION";
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                grd001.DataSource = dt;
                grd001.DataBind();
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
                //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[0];
                GridViewRow ci = ((GridViewRow)grd001.Rows[0]);
                Label lbl = (Label)ci.FindControl("lblcomment");
                lbl.Text = "Niño en Gestación";
                lbl.Visible = true;
                // JOVM 23/03/2015
                //grd001.Height = 70;

                getdatapanel1();

                pnl001.Visible = true;

                ddown003.Enabled = false;
                ddown004.Enabled = false;
                rdo001.Enabled = false;
                rdo002.Enabled = false;
                rdo005.Enabled = false;

                getdatapanel2();
                pnl002.Visible = true;
                imb_guardar.Text = "<span class='glyphicon glyphicon-arrow-right'></span>&nbsp;Egresar";//gfontbrevis agrega icono ->
                imb_guardar.Visible = true;
                lnkValidateRut = false;

                getdata();

                LRPAcoll lrpa = new LRPAcoll();
                GridViewRow grfila = (GridViewRow)((LinkButton)sender).NamingContainer;

                int icodie = Convert.ToInt32(grfila.Cells[1].Text);
                int codcalidadjuridica = lrpa.GetCalidadJuridica_IcodIE(icodie);

                bool sw = FiltroLRPA();
                if (sw)
                {
                    ddown010.SelectedValue = codcalidadjuridica.ToString();
                    ddown010.Enabled = false;
                    ddown009.SelectedValue = "12";
                    ddown009.Enabled = false;
                }
                else
                {
                    ddown009.SelectedValue = "0";
                    ddown009.Enabled = true;
                }

                if (ddown009.SelectedValue == "1")
                {
                    txtproyecto.Enabled = true;
                    ddlProyectoConQuienEgresa.Enabled = true;
                    imb_lupa_modal2.Attributes.Remove("disabled");
                }
                else
                {
                    txtproyecto.Enabled = false;
                    ddlProyectoConQuienEgresa.Enabled = false;
                    imb_lupa_modal2.Attributes.Add("disabled", "disabled");
                }
            }
        }
    }
    private void getdatapanel1()
    {
        getpartipo();
        getparcausal();
        getparconquien();
        getparmedidassugeridas();
        getcalidad();
        getparRegion();
        getparLugarFallecimiento();
        //call001.MinDate = Convert.ToDateTime(grd001.Rows[0].Cells.FromKey("FechaIngreso").Text).Date;
        //call001.MaxDate = DateTime.Now.Date;

        int IndiceColumna = 0;
        foreach (DataControlField column in grd001.Columns)
        {
            if (column.AccessibleHeaderText == "FechaIngreso")
            {
                IndiceColumna = grd001.Columns.IndexOf(column);
                break;
            }
        }
        
        string fechainistr = grd001.Rows[0].Cells[IndiceColumna].Text;
        DateTime fechaini = DateTime.Parse(fechainistr);
        CalendarExtende810.StartDate = fechaini;
        CalendarExtende810.EndDate = DateTime.Now.Date;
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

    private void getdatapanel2()
    {
        parcoll pcoll = new parcoll();
        DataTable dt = pcoll.GetparNacionalidades();
        getparRegion();
        getparLugarFallecimiento();
        //cal003.MinDate = Convert.ToDateTime(grd001.Rows[0].Cells.FromKey("FechaIngreso").Text).Date;
        //cal003.MaxDate = DateTime.Now.Date;

        int IndiceColumna = 0;
        foreach (DataControlField column in grd001.Columns)
        {
            if (column.AccessibleHeaderText == "FechaIngreso")
            {
                IndiceColumna = grd001.Columns.IndexOf(column);
                break;
            }
        }
        CalendarExtende840.StartDate = Convert.ToDateTime(grd001.Rows[0].Cells[IndiceColumna].Text).Date;
        CalendarExtende840.EndDate = DateTime.Now.Date;

        ddow011.DataSource = dt;
        ddow011.DataTextField = "Descripcion";
        ddow011.DataValueField = "CodNacionalidad";
        ddow011.DataBind();


     
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

    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        proyectocoll pcP = new proyectocoll();
        DataTable dtProyecto = pcP.GetProyectos(SSnino.CodProyecto.ToString());
        int CodModeloIntervencion = Convert.ToInt32(dtProyecto.Rows[0]["CodModeloIntervencion"].ToString());

        DataView dv1 = new DataView(par.GetparNacionalidades());
        ddow011.DataSource = dv1;
        ddow011.DataTextField = "Descripcion";
        ddow011.DataValueField = "CodNacionalidad";
        dv1.Sort = "CodNacionalidad";
        ddow011.DataBind();


        for (int i = 1; i <= ddow011.Items.Count - 1; i++)
        {
            if (ddow011.Items[i] != null) // el 8 no existe
            {
                ddow011.Items[i].Enabled = false;
                //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
            }
        }
        ddow011.SelectedValue = "0";


        DataView dv2 = new DataView(GetParTipoNacionalidad());
        ddown_tipo_nacionalidad.DataSource = dv2;
        ddown_tipo_nacionalidad.DataTextField = "Descripcion";
        ddown_tipo_nacionalidad.DataValueField = "CodTipoNacionalidad";
        dv2.Sort = "CodTipoNacionalidad";
        ddown_tipo_nacionalidad.DataBind();
    }

    private void getpanelordenes()
    {
        //call002.MaxDate = DateTime.Now.Date;
        CalendarExtende825.EndDate = DateTime.Now.Date;

        getregiones();
        gettipotribunales();
        gettribunales();
    }

    private void ValidacionDeEgresado()
    {
        if (ConfigurationSettings.AppSettings["Cierre_mes"].ToString() == "1")
        {
            DateTime fecha = Convert.ToDateTime(call001.Text);
            string ano = Convert.ToDateTime(fecha).Year.ToString();// fecha.Year.ToString();
            string mes = Convert.ToDateTime(fecha).Month.ToString();  //DateTime.Now.Month.ToString();

            if (mes.Length <= 1)
            {
                mes = 0 + mes;
            }

            diagnosticoscoll dcoll = new diagnosticoscoll();

            int Periodo = Convert.ToInt32(ano + mes);
            int proyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);
            int Estado_cierre = dcoll.callto_consulta_cierremes(proyecto, Periodo);

            if (Estado_cierre != 1)
            {
                call001.Enabled = true;
                txt002.Enabled = true;
                ddown003.Enabled = true;
                ddown004.Enabled = true;
                ddown009.Enabled = true;
                
                txtproyecto.Enabled = true;
                ddlProyectoConQuienEgresa.Enabled = true;
                ddown008.Enabled = true;
                rdo001.Enabled = true;
                rdo002.Enabled = true;
                rdo005.Enabled = true;
                chk001.Enabled = true;
                call002.Enabled = true;
                ddown012.Enabled = true;
                ddown013.Enabled = true;
                ddown006.Enabled = true;
                txt003.Enabled = true;
                ddown007.Enabled = true;
                ddow011.Enabled = true;

            }
            else
            {
                call001.Enabled = false;
                txt002.Enabled = false;
                ddown003.Enabled = false;
                ddown004.Enabled = false;
                ddown009.Enabled = false;
                txtproyecto.Enabled = false;
                ddlProyectoConQuienEgresa.Enabled = false;
                ddown008.Enabled = false;
                rdo001.Enabled = false;
                rdo002.Enabled = false;
                rdo005.Enabled = false;
                chk001.Enabled = false;
                call002.Enabled = false;
                ddown012.Enabled = false;
                ddown013.Enabled = false;
                ddown006.Enabled = false;
                txt003.Enabled = false;
                ddown007.Enabled = false;
            }
        }
    }
    protected void lnkegresar_Click(object sender, EventArgs e)
    {

        string msg = "";

        DataTable dt = callto_sp_ninosdelproyecto(Convert.ToInt32(ddl_Institucion.SelectedValue), Convert.ToInt32(ddl_Proyecto.SelectedValue));
        GridViewRow grvr = (GridViewRow)((LinkButton)sender).NamingContainer;

            string cinst = ddl_Institucion.SelectedValue.ToString();
            string cproy = ddl_Proyecto.SelectedValue.ToString();
            string rut = grvr.Cells[2].Text;
            Int32 codie = Convert.ToInt32(grvr.Cells[1].Text);
            Int32 cnino = Convert.ToInt32(grvr.Cells[0].Text);
            SSnino.CodNino = Convert.ToInt32(grvr.Cells[0].Text);
            SSnino.ICodIE = Convert.ToInt32(grvr.Cells[1].Text);

            oNNA NNA = new oNNA(cinst, cproy, codie, cnino, rut, grvr.Cells[4].Text, grvr.Cells[5].Text, grvr.Cells[6].Text, grvr.Cells[7].Text, grvr.Cells[8].Text);
            Session["NNA"] = NNA;
        
        DataTableCollection dtc = callto_get_antecedentesegreso(Convert.ToInt32(ddl_Proyecto.SelectedValue), Convert.ToInt32(grvr.Cells[1].Text));
        //DataTableCollection dtc = callto_get_antecedentesegreso(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(((LinkButton)sender).CommandArgument));

        if (dtc[0].Rows.Count > 0 || dtc[1].Rows.Count > 0 || dtc[2].Rows.Count > 0 || dtc[3].Rows.Count > 0 || dtc[4].Rows.Count > 0)
        {
            for (int i = 0; i < dtc.Count; i++)
            {
                for (int j = 0; j < dtc[i].Rows.Count; j++)
                {
                    //msg += "(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " <br>";//Environment.NewLine;
                    //msg += "<input type=\"button\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" Value=\"(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "\" /> <br>";//Environment.NewLine;

                    //msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                 
                    switch (i)
                    {
                        case 0:
                            if (window.existetoken("6F360136-E048-44FA-828E-E62CE3BDE05F"))
                            {
                             msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                              msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                        break;
                            
                        case 1:
                        case 2:
                        case 4:
                        
                            if ( window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                        break;                       

                        case 3:
                            if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                            {
                                msg += "<li><a href=\"#\" OnClick= \"AbrirURLModalPopUp('" + dtc[i].Rows[j][3].ToString() + "')\" >(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + "</a></li>";//Environment.NewLine;
                            }
                            else
                                msg += "<li>(" + dtc[i].Rows[j][1].ToString() + ")" + dtc[i].Rows[j][0].ToString() + " \"No tiene permisos para ingresar al formulario\"</li>";//Environment.NewLine;
                        break;
                    }
                }
            }
            msgEgreso = msg;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;
                //if (dt.Rows[i][11].ToString() == ((LinkButton)sender).CommandArgument)
                if (dt.Rows[i][11].ToString() == fila.Cells[1].Text)
                {
                    nombreNinoEgreso = dt.Rows[i]["Nombres"].ToString() + " " + dt.Rows[i]["Apellido_Paterno"].ToString() + " " + dt.Rows[i]["Apellido_Materno"].ToString();
                }
            }
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;

            mostrar_modal_egreso();
        }

          
        else
        {
            txt_nombres.Text = grvr.Cells[4].Text;
            txt_apaterno.Text = grvr.Cells[5].Text;
            txt_amaterno.Text = grvr.Cells[6].Text;
            bloquear_busqueda();
                        
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add(new DataColumn("Seleccionar"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;
                    //if (dt.Rows[i]["ICODIE"].ToString() != ((LinkButton)sender).CommandArgument)
                    if (dt.Rows[i]["ICODIE"].ToString() != fila.Cells[1].Text)
                    {
                        dt.Rows[i].Delete();
                    }
                    else
                    {
                        if (((LinkButton)sender).CommandName == "G")
                        {
                            dt.Rows[i]["Seleccionar"] = "NIÑO EN GESTACION";
                        }
                        else
                        {
                            dt.Rows[i]["Seleccionar"] = "EGRESO NORMAL";
                        }
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {

                grd001.DataSource = dt;
                grd001.DataBind();
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
                //CellItem ci = (CellItem)((Infragistics.WebUI.UltraWebGrid.TemplatedColumn)grd001.Columns.FromKey("Seleccionar")).CellItems[0];
                GridViewRow ci = ((GridViewRow)grd001.Rows[0]);
                Label lbl = (Label)ci.FindControl("lblcomment");
                lbl.Text = "Egreso Normal";
                lbl.Visible = true;
                // JOVM - 23/03/2015
                //grd001.Height = 70;
                getdatapanel1();

                pnl001.Visible = true;
                //aqui
                //      = "ninos_Egreso_Direccion.aspx?V1=" + grd001.Rows[0].Cells[1].Text + "&V2=" + grd001.Rows[0].Cells[0].Text + "&V3=" + ddown002.SelectedValue + "&V4=" + grd001.Rows[0].Cells[7].Text;
                //iframe_validar_direccion.src = "ninos_Egreso_Direccion.aspx?V1=" + grd001.Rows[0].Cells[1].Text + "&V2=" + grd001.Rows[0].Cells[0].Text + "&V3=" + ddown002.SelectedValue + "&V4=" + grd001.Rows[0].Cells[7].Text;
                ddown003.Enabled = true;
                ddown004.Enabled = true;
                rdo001.Enabled = true;
                rdo002.Enabled = true;


                Pnl_Orden.Visible = false;
                pnl002.Visible = false;
                lnkValidateRut = true;
                imb_guardar.Text = "<span class='glyphicon glyphicon-arrow-right'></span>&nbsp;Egresar";//gfontbrevis agrega icono ->
                imb_guardar.Visible = true;
                

                LRPAcoll lrpa = new LRPAcoll();
                GridViewRow fila = (GridViewRow)((LinkButton)sender).NamingContainer;

                int icodie = Convert.ToInt32(fila.Cells[1].Text);
                //int icodie = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                int codcalidadjuridica = lrpa.GetCalidadJuridica_IcodIE(icodie);

                bool sw = FiltroLRPA();
                if (sw)
                {
                    ddown010.SelectedValue = codcalidadjuridica.ToString();
                    ddown010.Enabled = false;
                    try
                    {
                        ddown009.SelectedValue = "12";
                    }
                    catch
                    {
                        ddown009.Items.Add(new ListItem("NO CORRESPONDE (LRPA y FALLECIMIENTO)", "12"));
                        ddown009.SelectedValue = "12";
                    }
                    ddown009.Enabled = false;
                }
                else
                {
                    try
                    {
                        ddown010.SelectedValue = codcalidadjuridica.ToString();
                        tr_calidadJuridica.Visible = false;
                        ddown010.Enabled = false;
                    }
                    catch
                    {
                        ddown010.SelectedValue = "0";
                        tr_calidadJuridica.Visible = true;
                        ddown010.Enabled = true;
                    }
                    //ddown009.SelectedValue = "12";
                    //ddown009.Enabled = false;
                }

                if (ddown009.SelectedValue == "1")
                {
                    txtproyecto.Enabled = true;
                    ddlProyectoConQuienEgresa.Enabled = true;
                    imb_lupa_modal2.Attributes.Remove("disabled");
                }
                else
                {
                    txtproyecto.Enabled = false;
                    ddlProyectoConQuienEgresa.Enabled = false;
                    imb_lupa_modal2.Attributes.Add("disabled", "disabled");
                }
            }
            lbl_resumen_filtro.Text = "<br>";
            lbl_resumen_filtro.Text += "<strong>Busqueda: </strong>";
            lbl_resumen_filtro.Text += "" + ddl_Proyecto.SelectedItem.Text + " ";
            if (txt_apaterno.Text != "")
            {
                lbl_resumen_filtro.Text += "// " + txt_apaterno.Text + "";
            }

            if (txt_amaterno.Text != "")
            {
                lbl_resumen_filtro.Text += " " + txt_amaterno.Text + " ";
            }

            if (txt_nombres.Text != "")
            {
                lbl_resumen_filtro.Text += "" + txt_nombres.Text + "";
            }

            lbl_resumen_filtro.Text += "<br>";

            lbl_resumen_filtro.Visible = true;
            lbl_resumen_filtro.Style.Add("display", "none");

            

        }
    }
    protected void rdo002_CheckedChanged(object sender, EventArgs e)
    {
        Pnl_Orden.Visible = false;
        if (rdo001.Checked)
        {
            txt003.Visible = false;
            tr_expediente.Visible = false;
        }
        else
        {
            txt003.Visible = true;
            tr_expediente.Visible = true;
        }
        imb_guardar.Focus();
    }
    protected void ddown013_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettribunales();
        imb_guardar.Focus();
        activarDesactivarProyectoConQuienEgresa();
    }
    protected void ddown012_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettribunales();
        imb_guardar.Focus();
        activarDesactivarProyectoConQuienEgresa();
    }
    protected void imb_guardar_Click(object sender, EventArgs e)
    {
        if (validatedata())
        {
            string OT = "NO";
            int codproyecto = 0;

            int SeActivaCircular = 0;

            if (Convert.ToInt32(SSnino.CodInst) == 6050)
            {
                if (rbtnSeActivoCircular2309Si.Checked == true)
                {
                    SeActivaCircular = 1;
                }
                else
                {
                    SeActivaCircular = 0;
                }
            }
            else
            {
                if (rbtnSeActivoCircular2308Si.Checked == true)
                {
                    SeActivaCircular = 1;
                }
                else
                {
                    SeActivaCircular = 0;
                } 
            }
            string FechaCertificado = "01-01-1900";
            string NumeroCertificado =  "0";

            if (txtFechaCertificado.Text != "")
            {
                FechaCertificado = txtFechaCertificado.Text;
            }

            if (txtNumeroCertificado.Text != "")
            {
                NumeroCertificado = txtNumeroCertificado.Text;
            }

            try
            {
                if (Convert.ToInt32(txtproyecto.Text) > 0)
                {
                    codproyecto = Convert.ToInt32(txtproyecto.Text);
                }
            }
            catch { }

            if (rdo001.Checked)
            { OT = "SI"; }
            else if (rdo005.Checked)
            { OT = "ET"; }

            bool validaRut = false;
            if (txt004.Text.Trim() != "")
            {
                ninocoll ncoll = new ninocoll();
                validaRut = ncoll.ConsultaRutnino(txt004.Text.Trim().Replace(".", "").ToUpper());
            }
            else
            {
                validaRut = false;
                txt004.Text = "0";
            }

            Label lblTipoEgreso= (Label)grd001.Rows[0].Cells[9].Controls[0].FindControl("lblcomment");
            lblTipoEgreso.Text = lblTipoEgreso.Text.ToUpper();

            if (!validaRut)
            {
                ninocoll ncoll = new ninocoll();
                if (lblTipoEgreso.Text == "EGRESO NORMAL")
                {
                    if (rdo002.Checked)
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), Convert.ToInt32(ddown004.SelectedValue), OT, 68, Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                    }
                    else if (rdo001.Checked)
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), Convert.ToInt32(ddown004.SelectedValue), OT, Convert.ToInt32(ddown007.SelectedValue), Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                        callto_insert_ordentribunalegreso(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToInt32(ddown006.SelectedValue), Convert.ToDateTime(call002.Text), txt003.Text, DateTime.Now, 1);
                    }
                    else if (rdo005.Checked)
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), Convert.ToInt32(ddown004.SelectedValue), OT, Convert.ToInt32(ddown007.SelectedValue), Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                        if (validateET())
                        {
                            callto_insert_ordentribunalegreso(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToInt32(ddown006.SelectedValue), Convert.ToDateTime(call002.Text), txt003.Text, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));
                        }
                    }
                }
                else if (lblTipoEgreso.Text == "NIÑO EGRESADO")
                {
                    if (rdo002.Checked)
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), Convert.ToInt32(ddown004.SelectedValue), OT, 68, Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                    }
                    else if (rdo001.Checked)
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), Convert.ToInt32(ddown004.SelectedValue), OT, Convert.ToInt32(ddown007.SelectedValue), Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                        callto_update_ordentribunalegreso(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToInt32(ddown006.SelectedValue), Convert.ToDateTime(call002.Text), txt003.Text, Convert.ToInt32(Session["IdUsuario"]));
                    }

                }
                else
                {
                    if (!pnl002.Visible)
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), 40, OT, 68, Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, 1, DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                    }
                    else
                    {
                        callto_update_egresos(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), txt002.Text.ToUpper(), 40, OT, 68, Convert.ToInt32(ddown008.SelectedValue), Convert.ToInt32(ddown009.SelectedValue), codproyecto, 1, DateTime.Now, Convert.ToInt32(ddown010.SelectedValue));
                        
                        nino n = ncoll.GetNinos(Convert.ToInt32(grd001.Rows[0].Cells[0].Text));
                        if (n.OficinaInscripcion == null)
                        {
                            n.OficinaInscripcion = "";
                        }
                        if (n.NumeroInscripcionCivil == null)
                        {
                            n.NumeroInscripcionCivil = "";
                        }
                        if (n.AlergiasConocidas == null)
                        {
                            n.AlergiasConocidas = "";
                        }
                        if (n.EstadoGestacion == null)
                        {
                            n.EstadoGestacion = "";
                        }
                        ncoll.Update_Ninos(Convert.ToInt32(grd001.Rows[0].Cells[0].Text), n.FechaAdoptabilidad, n.IdentidadConfirmada, txt004.Text.Trim().Replace(".", "").ToUpper(), getsexo(), txt005.Text.ToUpper(), txt006.Text.ToUpper(), txt007.Text.ToUpper(), Convert.ToDateTime(cal003.Text), Convert.ToInt32(ddow011.SelectedValue), n.CodEtnia,
                                            n.OficinaInscripcion, n.AnoInscripcion, n.NumeroInscripcionCivil, n.AlergiasConocidas, n.InscritoFONADIS, n.InscritoFONASA, n.NinoSuceptibleAdopcion, n.EstadoGestacion, DateTime.Now, 1);
                    }

                }

                if (ddown004.SelectedValue == "65" || ddown004.SelectedValue == "26")
                {
                    ncoll.Update_ninos_F(Convert.ToInt32(grd001.Rows[0].Cells[0].Text), 
                        txtCausalFallecimiento.Text, 
                        Convert.ToDateTime(txtFechaDefuncion.Text), 
                        Convert.ToInt32(ddlLugarFallecimiento.SelectedValue), 
                        Convert.ToInt32(ddlComunaFallecimiento.SelectedValue),
                        SetTxtFecha(txtFechaDenunciaMinisterio),
                        SetTxtFecha(txtFechaQuerella),
                        SeActivaCircular,
                        Convert.ToDateTime(FechaCertificado),
                        NumeroCertificado);
                    // Envío e-mail
                    EnviaEMail();
                }


                callto_cierre_egreso(Convert.ToInt32(grd001.Rows[0].Cells[1].Text), Convert.ToDateTime(call001.Text), 1);
                
                Response.Write("<script language='javascript'>alert('Egreso Realizado Satisfactoriamente. ');</script>");

                #region Código eliminado
                // Código validado para las alertas
                //Alerta a = new Alerta();
                //a.ICodIE = SSnino.ICodIE;
                //a.CodNino = SSnino.CodNino;
                //a.FechaTermino = DateTime.Now;
                //a.IdUsrTermino = Convert.ToInt32(Session["IdUsuario"].ToString());
                //a.CodRol = Session["contrasena"].ToString();
                //a.CodProyecto = Convert.ToInt32(ddl_Proyecto.SelectedValue);

                //cerrarAlerta(a);
                #endregion
                grd001.Visible = false;
                pnl001.Visible = false;
                Pnl_Orden.Visible = false;
                imb_guardar.Visible = false;
                
                imb_limpiar_Click(sender, e);//gfontbrevis
                if (pnl002.Visible)
                {
                    pnl002.Visible = false;

                    Response.Redirect("ninos_index.aspx?ICODIE=" + grd001.Rows[0].Cells[1].Text);
                }

            }
            else
            {
                Response.Write("<script language='javascript'>alert('ERROR AL VALIDAR EL RUT DEL NIÑO. ');</script>");
                //lbl_detalle.Text = "ERROR AL INGRESO RUT NIÑO INGRESADO";
                //lbl_detalle.ForeColor = System.Drawing.Color.Red;
                //lbl_detalle.Visible = true;
                imb_guardar.Focus();
            }



        }
        else
        {
            Response.Write("<script language='javascript'>alert('Faltan campos obligatorios, por favor revisar. ');</script>");
            //lbl_detalle.Text = "ERROR AL INGRESO DE CAMPOS REQUERIDOS";
            //lbl_detalle.ForeColor = System.Drawing.Color.Red;
            //lbl_detalle.Visible = true;
            imb_guardar.Focus();
        }

    }

    private void EnviaEMail()
    {
        String strHTML = ""; String strTo = ""; String strCCO = ""; String strCC = ""; String strBody = ""; String strDepartamento = ""; String strCodDepartamento = ""; String strSubject = "";

        oNNA oNino = new oNNA();
        oNino = (oNNA)Session["NNA"];
        strTo = TraeTo(50, "");
        strCCO = TraeTo(51, "");
        strCodDepartamento = TraeTo(Convert.ToInt32(ddl_Proyecto.SelectedValue.ToString()), "select CodDepartamentosSENAME as Valor from Proyectos where CodProyecto = ");
        strDepartamento = TraeTo(Convert.ToInt32(ddl_Proyecto.SelectedValue.ToString()), "select CASE WHEN t1.CodDepartamentosSENAME in (6, 9) then 'PROTECCIÓN DE DERECHOS Y PRIMERA INFANCIA' else t2.Nombre END as Valor from Proyectos t1 inner join parDepartamentosSENAME t2 ON t1.CodDepartamentosSENAME = t2.CodDepartamentosSENAME where t1.CodProyecto = ");
        strBody = TraeTo(52, "");

        switch (strCodDepartamento)
        {
            case "6":
            case "9":
                strCC = TraeTo(54, "");
                break;
            case "7":
                strCC = TraeTo(55, "");
                break;
            case "8":
                strCC = TraeTo(56, "");
                break;
        }
        strSubject = TraeTo(53, "");
        //strBody = TraeTo(52, "");

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        SqlParameter paramRetorno = new SqlParameter("@strHTML", SqlDbType.NVarChar, 10000);
        paramRetorno.Direction = ParameterDirection.Output;

        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GeneraHTML_email";
        sqlc.Parameters.Add(paramRetorno);
        sqlc.Parameters.AddWithValue("@TipoEnvio", strBody);
        sconn.Open();
        sqlc.CommandTimeout = 300;
        sqlc.ExecuteReader();
        sconn.Close();
        strHTML = sqlc.Parameters["@strHTML"].Value.ToString();

        String NombreNino = oNino.NNAApePaterno.ToUpper().ToString().Trim() + " " + oNino.NNAApeMaterno.ToUpper().ToString().Trim() + " " + oNino.NNANombres.ToUpper().ToString().Trim();

        oNino.NNACodProyecto.ToString();
        strHTML = strHTML.Replace("_xXFechaEgresoXx_", call001.Text.Trim());
        strHTML = strHTML.Replace("_xXNNAXx_", NombreNino);
        strHTML = strHTML.Replace("_xXProyectoXx_", ddl_Proyecto.SelectedItem.Text.ToUpper().Trim());
        strHTML = strHTML.Replace("_xXInstitucionXx_", ddl_Institucion.SelectedItem.Text.ToUpper().Trim());
        strHTML = strHTML.Replace("_xXDepartamentoXx_", strDepartamento.Trim().ToUpper());
        strHTML = strHTML.Replace("_xXCausalXx_", txtCausalFallecimiento.Text.Trim());
        strHTML = strHTML.Replace("_xXFechaFallecimientoXx_", txtFechaDefuncion.Text.Trim());
        strHTML = strHTML.Replace("_xXComunaXx_", ddlComunaFallecimiento.SelectedItem.Text.ToUpper().Trim());
        strHTML = strHTML.Replace("_xXRegionXx_", ddlRegionFallecimiento.SelectedItem.Text.ToUpper().Trim());

        SenainfoSdk.Net.SendMail EnviaMail = new SenainfoSdk.Net.SendMail();
        EnviaMail.Enviar("Senainfo", strTo, strCC, strCCO, strSubject, strHTML);
    }

    private DateTime SetTxtFecha(TextBox fecha)
    {
        if (fecha.Text == "")
        {
            return Convert.ToDateTime("01-01-1900");
        }
        else
        {
            return Convert.ToDateTime(fecha.Text);
        }       
    }
    private bool validatedata()
    {
        bool v = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis similar a #F3E12A con 60% de opacidad
        if (pnl001.Visible && !pnl002.Visible && ddown003.Enabled)
        {
            if (call001.Text.ToUpper() == "")
            {
                call001.BackColor = colorCampoObligatorio; v = false;
            }
            else { call001.BackColor = System.Drawing.Color.Empty; }

            if (ddown003.SelectedIndex == 0)
            { ddown003.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown003.BackColor = System.Drawing.Color.Empty; }

            if (ddown004.SelectedIndex == 0)
            { ddown004.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown004.BackColor = System.Drawing.Color.Empty; }

            if (ddown008.SelectedIndex == 0)
            { ddown008.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown008.BackColor = System.Drawing.Color.Empty; }

            if (ddown009.SelectedIndex == 0)
            { ddown009.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown009.BackColor = System.Drawing.Color.Empty; }


            if (ddown010.Enabled == true)
            {
                if (ddown010.SelectedIndex == 0)
                { ddown010.BackColor = colorCampoObligatorio; v = false; }
                else
                { ddown010.BackColor = System.Drawing.Color.Empty; }
            }

            if (!chk001.Checked)
            { chk001.BackColor = colorCampoObligatorio; v = false; }
            else
            { chk001.BackColor = System.Drawing.Color.Empty; }
        }
        if (pnl001.Visible && Pnl_Orden.Visible && !pnl002.Visible && rdo001.Checked) //ORDEN SI
        {
            if (!chk001.Checked)
            { chk001.BackColor = colorCampoObligatorio; v = false; }
            else
            { chk001.BackColor = System.Drawing.Color.Empty; }

            if (call001.Text.ToUpper() == "")
            { call001.BackColor = colorCampoObligatorio; v = false; }
            else
            { call001.BackColor = System.Drawing.Color.Empty; }

            if (call002.Text.ToUpper() == "")
            { call002.BackColor = colorCampoObligatorio; v = false; }
            else
            { call002.BackColor = System.Drawing.Color.Empty; }
            if (ddown003.SelectedIndex == 0)
            { ddown003.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown003.BackColor = System.Drawing.Color.Empty; }
            if (ddown004.SelectedIndex == 0)
            { ddown004.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown004.BackColor = System.Drawing.Color.Empty; }

            if (ddown006.SelectedIndex == 0)
            { ddown006.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown006.BackColor = System.Drawing.Color.Empty; }
            if (ddown007.SelectedIndex == 0)
            { ddown007.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown007.BackColor = System.Drawing.Color.Empty; }



            if (ddown008.SelectedIndex == 0)
            { ddown008.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown008.BackColor = System.Drawing.Color.Empty; }

            if (ddown009.SelectedIndex == 0)
            { ddown009.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown009.BackColor = System.Drawing.Color.Empty; }

            if (ddown010.Enabled == true)
            {
                if (ddown010.SelectedIndex == 0)
                { ddown010.BackColor = colorCampoObligatorio; v = false; }
                else
                { ddown010.BackColor = System.Drawing.Color.Empty; }
            }
            if (!txt003.Visible)
            {
                txt003.Text = "0";
            }
            if (txt003.Text.Trim().Length == 0)
            { txt003.BackColor = colorCampoObligatorio; v = false; }
            else
            { txt003.BackColor = System.Drawing.Color.Empty; }

        }

        //if (pnl001.Visible && !Pnl_Orden.Visible && !ddown003.Enabled) // EN GESTACION
        if (grd001.Rows[0].Cells[5].Text.Trim() == "N.N. EN GESTACION") // EN GESTACION
        {
            if (call001.Text.ToUpper() == "")
            { call001.BackColor = colorCampoObligatorio; v = false; }
            else
            { call001.BackColor = System.Drawing.Color.Empty; }

            if (ddown008.SelectedIndex == 0)
            { ddown008.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown008.BackColor = System.Drawing.Color.Empty; }

            if (ddown009.SelectedIndex == 0)
            { ddown009.BackColor = colorCampoObligatorio; v = false; }
            else
            { ddown009.BackColor = System.Drawing.Color.Empty; }

            if (ddown010.Enabled == true)
            {
                if (ddown010.SelectedIndex == 0)
                { ddown010.BackColor = colorCampoObligatorio; v = false; }
                else
                { ddown010.BackColor = System.Drawing.Color.Empty; }
            }
            if (pnl002.Visible)
            {
                if (cal003.Text.ToUpper() == "")
                { cal003.BackColor = colorCampoObligatorio; v = false; }
                else if (Convert.ToDateTime(grd001.Rows[0].Cells[7].Text) > Convert.ToDateTime(cal003.Text))
                {   cal003.BackColor = colorCampoObligatorio; 
                    v = false;
                    lblAvisoFechaNacimiento.Text = " La fecha de nacimiento no puede ser menor a la fecha de ingreso";
                    lblAvisoFechaNacimiento.Visible = true;
                }
                else
                { 
                    cal003.BackColor = System.Drawing.Color.Empty;
                    lblAvisoFechaNacimiento.Text = "";
                    lblAvisoFechaNacimiento.Visible = false;
                }
                
                if (ddow011.SelectedValue == "0")
                { ddow011.BackColor = colorCampoObligatorio; v = false; }
                else
                { ddow011.BackColor = System.Drawing.Color.Empty; }




                if (ddown_tipo_nacionalidad.SelectedValue == "0")
                { ddown_tipo_nacionalidad.BackColor = colorCampoObligatorio; v = false; }
                else
                { ddown_tipo_nacionalidad.BackColor = System.Drawing.Color.Empty; }



                if (!lnkValidateRut)
                {
                    if (txt004.Text.Trim().Length == 0)
                    { txt004.BackColor = colorCampoObligatorio; v = false; }
                    else
                    { txt004.BackColor = System.Drawing.Color.Empty; }
                }
                if (txt005.Text.Trim().Length == 0)
                { txt005.BackColor = colorCampoObligatorio; v = false; }
                else
                { txt005.BackColor = System.Drawing.Color.Empty; }

                if (txt006.Text.Trim().Length == 0)
                { txt006.BackColor = colorCampoObligatorio; v = false; }
                else
                { txt006.BackColor = System.Drawing.Color.Empty; }

                if (txt007.Text.Trim().Length == 0)
                { txt007.BackColor = colorCampoObligatorio; v = false; }
                else
                { txt007.BackColor = System.Drawing.Color.Empty; }
            }
        }

        if (ddown004.SelectedValue == "65" || ddown004.SelectedValue == "26") // fallecimiento
        {

            if (txtCausalFallecimiento.Text == "")
            {
                txtCausalFallecimiento.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                txtCausalFallecimiento.BackColor = System.Drawing.Color.Empty;
            }


            if (txtFechaDefuncion.Text == "")
            {
                txtFechaDefuncion.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                txtFechaDefuncion.BackColor = System.Drawing.Color.Empty;
            }

            if (ddlLugarFallecimiento.SelectedValue == "0")
            {
                ddlLugarFallecimiento.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                ddlLugarFallecimiento.BackColor = System.Drawing.Color.Empty;
            }

            if (ddlRegionFallecimiento.SelectedValue == "-2")
            {
                ddlRegionFallecimiento.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                ddlRegionFallecimiento.BackColor = System.Drawing.Color.Empty;
            }

            if (ddlComunaFallecimiento.SelectedValue == "0")
            {
                ddlComunaFallecimiento.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                ddlComunaFallecimiento.BackColor = System.Drawing.Color.Empty;
            }


            ////////////
            if (rbtnExisteDenunciaMinisterioSi.Checked == true)
            {
                if (txtFechaDenunciaMinisterio.Text == "")
                {
                    txtFechaDenunciaMinisterio.BackColor = colorCampoObligatorio;
                    v = false;
                }
                else
                {
                    txtFechaDenunciaMinisterio.BackColor = System.Drawing.Color.Empty;
                }
            }


            if (rbtnExisteQuerellaSi.Checked == true)
            {
                if (txtFechaQuerella.Text == "")
                {
                    txtFechaQuerella.BackColor = colorCampoObligatorio;
                    v = false;
                }
                else
                {
                    txtFechaQuerella.BackColor = System.Drawing.Color.Empty;
                }
            }


            if (Convert.ToInt32(SSnino.CodInst) == 6050)
            {
                if (rbtnSeActivoCircular2309Si.Checked == false && rbtnSeActivoCircular2309No.Checked == false)
                {
                    rbtnSeActivoCircular2309Si.BackColor = colorCampoObligatorio;
                    rbtnSeActivoCircular2309No.BackColor = colorCampoObligatorio;
                    v = false;
                }
                else
                {
                    rbtnSeActivoCircular2309Si.BackColor = System.Drawing.Color.Empty;
                    rbtnSeActivoCircular2309No.BackColor = System.Drawing.Color.Empty;
                }

            }
            else
            {
                if (rbtnSeActivoCircular2308Si.Checked == false && rbtnSeActivoCircular2308No.Checked == false)
                {
                    rbtnSeActivoCircular2308Si.BackColor = colorCampoObligatorio;
                    rbtnSeActivoCircular2308No.BackColor = colorCampoObligatorio;
                    v = false;
                }
                else
                {
                    rbtnSeActivoCircular2308Si.BackColor = System.Drawing.Color.Empty;
                    rbtnSeActivoCircular2308No.BackColor = System.Drawing.Color.Empty;
                }
            }
        }
        return v;
    }

    private string getsexo()
    {
        if (rdo003.Checked)
        {
            return "F";
        }
        else
        {
            return "M";
        }
    }
    protected void imb_limpiar_Click(object sender, EventArgs e)
    {

        imb_buscar.Visible = true;
        ddl_Institucion.Enabled = true;
        ddl_Proyecto.Enabled = true;
        imb_lupa_modal.Visible = true;
        imb_lupa_modal.Attributes.Remove("disabled");//gfontbrevis
        imb_institucion.Attributes.Remove("disabled");//gfontbrevis
        txt_nombres.Enabled = true;
        txt_apaterno.Enabled = true;
        txt_amaterno.Enabled = true;


        //lbl_detalle.Visible = false;
        txt_nombres.Text = "";
        txt_apaterno.Text = "";
        txt_amaterno.Text = "";
        //if (ddl_Proyecto.Items.Count >0)
        //ddl_Proyecto.SelectedIndex = 0;

        //if (ddl_Institucion.Items.Count > 0)
        //    ddl_Institucion.SelectedIndex = 0;

        pnl001.Visible = false;
        pnl002.Visible = false;
        Pnl_Orden.Visible = false;
        grd001.Visible = false;
        imb_guardar.Visible = false;
        btnexcel.Visible = false;
        //lnkfiltrar.Visible = false;
        // JOVM - 03/02/2015
        // Se habilitan DDWList de Instituciones y Proyectos
        // y se limpian datos de la SESSION["NNA"]
        ddl_Institucion.Enabled = true;
        ddl_Proyecto.Enabled = true;
        Session["NNA"] = null;
        SSnino.ICodIE = 0;
        Session["ICODIE"] = SSnino.ICodIE;
        txtproyecto.Text = "";
        ddlProyectoConQuienEgresa.SelectedValue = "0";
        //----------------------------

    }
    protected void txt001_TextChanged(object sender, EventArgs e)
    {
        fn_buscar();
    }

    protected void lnkfiltrar_Click(object sender, EventArgs e)
    {
        if (grd001.Visible)
        {
            fn_buscar();
        }
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

    protected void chk001_CheckedChanged(object sender, EventArgs e)
    {
        string pagina = "ninos_Egreso_Direccion.aspx?V1=" + grd001.Rows[0].Cells[1].Text + "&V2=" + grd001.Rows[0].Cells[0].Text + "&V3=" + ddl_Proyecto.SelectedValue + "&V4=" + grd001.Rows[0].Cells[7].Text;
        window.open(Page, pagina, "DIRECCION", 950, 500, true);
    }
    protected void ddown009_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown009.SelectedValue == "1" || ddown009.SelectedValue == "15")
        {
            txtproyecto.Enabled = true;//gfontbrevis
            ddlProyectoConQuienEgresa.Enabled = true;
            imb_lupa_modal2.Attributes.Remove("disabled");
        }
        else
        {
            txtproyecto.Enabled = false;//gfontbrevis
            ddlProyectoConQuienEgresa.Enabled = false;
            imb_lupa_modal2.Attributes.Add("disabled", "disabled");
        }
    }

    //protected void imb_lupa_modal2_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    window.open(this.Page, "bsc_egreso_institucion.aspx?param001=" + etiqueta + "&dir=reg_inmueblesproy.aspx", "Buscador", true, true, 770, 420, false, true, true);

    //}

    private bool validateET()
    {
        bool v = true;

        if (pnl001.Visible && Pnl_Orden.Visible && !pnl002.Visible)
        {

            if (call002.Text.ToUpper() == "")
            { v = false; }
            if (ddown006.SelectedIndex == 0)
            { v = false; }
            if (ddown007.SelectedIndex == 0)
            { v = false; }
            if (ddown008.SelectedIndex == 0)
            { v = false; }
            if (ddown010.SelectedIndex == 0)
            { v = false; }
            if (txt003.Text.Trim().Length == 0)
            { v = false; }

        }
        return v;
    }

    protected void imb_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/logout.aspx");
    }
    protected void imb_guardarEI_Click(object sender, EventArgs e)
    {

    }
    protected void call001_ValueChanged(object sender, EventArgs e)
    {

        if (call001.Text != "")
        {
            RangeValidator903.Validate();
            if (RangeValidator903.IsValid)
            {
                diagnosticoscoll diacoll = new diagnosticoscoll();
                string ano = Convert.ToString(Convert.ToDateTime(call001.Text).Year);//DateTime.Now.Year.ToString();
                string mes = Convert.ToString(Convert.ToDateTime(call001.Text).Month);//DateTime.Now.Month.ToString();
                if (mes.Length <= 1)
                {
                    mes = 0 + mes;
                }

                int Periodo = Convert.ToInt32(ano + mes);
                int estado = diacoll.callto_consulta_cierremes(Convert.ToInt32(ddl_Proyecto.SelectedValue), Periodo);
                int Estado_cierre = estado;

                if (Estado_cierre == 1)
                {
                    call001.Text = "";
                    lbl001.Text = "El mes seleccionado no debe estar cerrado";

                }
                else
                {
                    lbl001.Text = "";
                }
            }
        }

        activarDesactivarProyectoConQuienEgresa();
    }
  

    public DataTable getgridinproyect()
    {
        
        DataTable dtproy = null;
        string apepat, apemat, nombres;


        if ((SSnino.Apellido_Paterno == null) || (SSnino.Apellido_Paterno.ToString() == ""))
        {
            apepat = string.Empty;
        }
        else
        {
            apepat = SSnino.Apellido_Paterno;
        }
        if ((SSnino.Apellido_Materno == null) || (SSnino.Apellido_Materno.ToString() == ""))
        {
            apemat = string.Empty;
        }
        else
        {
            apemat = SSnino.Apellido_Materno;
        }

        if ((SSnino.Nombres == null) || (SSnino.Nombres.ToString() == ""))
        {
            nombres = string.Empty;
        }
        else
        {
            nombres = SSnino.Nombres;
        }

        ninocoll ncoll = new ninocoll();
        try
        {
            dtproy = sp_ninosdelproyectoEgresos(Convert.ToInt32(ddl_Institucion.SelectedValue), Convert.ToInt32(ddl_Proyecto.SelectedValue), apepat, apemat, nombres);
        }
        catch
        {
        }
        return dtproy;

    }

    private void ExportarExcel()
    {
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=Ninos_Egreso.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        grd001.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    // no eliminar! debe estar para la exportación a excel
    public override void VerifyRenderingInServerForm(Control control)
    {

    } 

    //protected void txt004_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txt004.Text.Length > 3)
    //        {
    //            string rutsinnada = txt004.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //            string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //            string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //            if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //            {
    //                this.Form.FindControl("pnl005").Visible = false;
    //                string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                //txt001.Text = rcompleto;
    //            }
    //            else
    //            {
    //                txt004.Text = "";
    //                ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
    //                this.Form.FindControl("pnl005").Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            txt004.Text = "";
    //            ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
    //            this.Form.FindControl("pnl005").Visible = true;
    //        }
    //    }
    //    catch
    //    {
    //        ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
    //        this.Form.FindControl("pnl005").Visible = true;
    //    }
    //}

    

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

  


    protected void btnexcel_Click(object sender, EventArgs e)
    {
        ExportarExcel();
    }


    private void bloquear_busqueda()
    {
        imb_buscar.Visible = false;
        imb_institucion.Attributes.Add("disabled", "disabled");//gfontbrevis
        ddl_Institucion.Enabled = false;
        ddl_Proyecto.Enabled = false;
        imb_lupa_modal.Attributes.Add("disabled", "disabled");//gfontbrevis
        txt_nombres.Enabled = false;
        txt_apaterno.Enabled = false;
        txt_amaterno.Enabled = false;
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

    protected void refresher_Click(object sender, EventArgs e)
    {
        //fn_buscar();
        //UpdatePanel1.Update();
    }
    protected void txtFechaDefuncion_TextChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];       
        RVFechaDefuncion.MinimumValue = NNA.NNAFechaIngreso;        
        RVFechaDefuncion.Validate();       
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
    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddown004.SelectedValue == "26")
        {
            ddown009.SelectedValue = "16";
        }

        if (ddown004.SelectedValue == "65" || ddown004.SelectedValue == "26")
        {
            ddown009.Enabled = false;
            trFechaDefuncion.Visible = true;
            trLugarFallecimiento.Visible = true;
            trRegionFallecimiento.Visible = true;
            trComunaFallecimiento.Visible = true;
            //getparconquien();
            trCausalFallecimiento.Visible = true;

            ///
            trExisteDenunciaMinisterio.Visible = true;
            trExisteQuerella.Visible = true;
            trSeActivoCircular.Visible = true;
            ///
            trFechaCertificado.Visible = true;
            trNumeroCertificado.Visible = true;
            //
            trRellenoDefuncion.Visible = true;
            trTituloDetallesDefuncion.Visible = true;

            if (Convert.ToInt32(SSnino.CodInst) == 6050)
            {
                thCircular2309.Visible = true;
                tdCircular2309.Visible = true;
                thCircular2308.Visible = false;
                tdCircular2308.Visible = false;
            }
            else
            {
                thCircular2308.Visible = true;
                tdCircular2308.Visible = true;
                thCircular2309.Visible = false;
                tdCircular2309.Visible = false;
            }
        }
        else
        {
            bool sw = FiltroLRPA();
            if (!sw)
            {
                ddown009.SelectedValue = "0";
                ddown009.Enabled = true;
            }
            
            trFechaDefuncion.Visible = false;
            trLugarFallecimiento.Visible = false;
            trRegionFallecimiento.Visible = false;
            trComunaFallecimiento.Visible = false;
            trCausalFallecimiento.Visible = false;

            ///
            trExisteDenunciaMinisterio.Visible = false;
            trFechaDenunciaMinisterio.Visible = false;
            trExisteQuerella.Visible = false;
            trFechaQuerella.Visible = false;
            trSeActivoCircular.Visible = false;
            thCircular2309.Visible = false;
            tdCircular2309.Visible = false;
            thCircular2308.Visible = false;
            tdCircular2308.Visible = false;
            ///

            trFechaCertificado.Visible = false;
            trNumeroCertificado.Visible = false;

            //
            trRellenoDefuncion.Visible = false;
            trTituloDetallesDefuncion.Visible = false;
        }


        activarDesactivarProyectoConQuienEgresa();
    }

    private void cerrarAlerta(Alerta alerta)
    {
        IAlertas alertaEgresoPendiente = new AlertaEgresoPendiente();

        alertaEgresoPendiente.ActualizarAlerta(alerta);

    }
    protected void chk001_CheckedChanged1(object sender, EventArgs e)
    {
        activarDesactivarProyectoConQuienEgresa();
    }

    private void activarDesactivarProyectoConQuienEgresa()
    {
        if (ddown009.SelectedValue == "1" || ddown009.SelectedValue == "15")
        {
            txtproyecto.Enabled = true;
            ddlProyectoConQuienEgresa.Enabled = true;
            imb_lupa_modal2.Attributes.Remove("disabled");
        }
        
    }
    protected void ddlProyectoConQuienEgresa_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private DataTable getProyectoxCodigo(int codProyecto)
    {
        DataTable dt = new DataTable();

        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        SqlCommand command = new SqlCommand("Get_Proyectos", sqlc);

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.CommandTimeout = 1000;
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = codProyecto;

        command.Connection.Open();
        sqlda.Fill(dt);
        command.Connection.Close();

        DataRow dr = dt.NewRow();

        dr[0] = 0;
        dr[3] = "Seleccionar";
        dr[4] = "Seleccionar";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void cargaddlProyConQuienEgresa_Click(object sender, EventArgs e)
    {
        cargaProyConQuienEgresa(Convert.ToInt32(txtproyecto.Text));
        activarDesactivarProyectoConQuienEgresa();
    }
    protected void txtproyecto_TextChanged(object sender, EventArgs e)
    {
        //cargaProyConQuienEgresa(Convert.ToInt32(txtproyecto.Text));
    }
    protected void rbtnExisteDenunciaMinisterio_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnExisteDenunciaMinisterioSi.Checked == true)
        {
            trFechaDenunciaMinisterio.Visible = true;            
        }
        else
        {
            trFechaDenunciaMinisterio.Visible = false;
            txtFechaDenunciaMinisterio.Text = "";
        }
    }
    
    protected void rbtnExisteQuerella_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnExisteQuerellaSi.Checked == true)
        {
            trFechaQuerella.Visible = true;            
        }
        else
        {
            trFechaQuerella.Visible = false;
            txtFechaQuerella.Text = "";
        }
    }

    private static string TraeTo(Int32 aQuienEnvia, String strQUERY)
    {
        if (strQUERY == "")
            strQUERY = "select Valor from parConfiguracion where Item = @aQuienEnvia";
        else
            strQUERY += "@aQuienEnvia";

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.Parameters.AddWithValue("@aQuienEnvia", aQuienEnvia);
        sqlc.CommandText = strQUERY;
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        if (dt.Rows.Count > 0)
            return dt.Rows[0]["Valor"].ToString();
        else
            return "";
    }

    protected void ddown_tipo_nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddow011.Items.FindByValue("1").Enabled = true;
        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno o nacionalizado 
        {
            if (ddow011.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
            {
                for (int i = 2; i <= ddow011.Items.Count - 1; i++)
                {
                    if (ddow011.Items[i] != null) // el 8 no existe
                    {
                        ddow011.Items[i].Enabled = false;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                    }
                }
            }
            ddow011.SelectedValue = "1";
        }
        else // todas las demas
        {
            if (ddow011.Items.FindByValue("2").Enabled == false) //verifica si las nacionalidades que no son chilenas estan ocultas
            {
                for (int i = 2; i <= ddow011.Items.Count - 1; i++)
                {
                    if (ddow011.Items[i] != null) // el 8 no existe
                    {
                        ddow011.Items[i].Enabled = true;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                    }
                }
            }
            if (ddown_tipo_nacionalidad.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
            {
                ddow011.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena


            }

            if (ddown_tipo_nacionalidad.SelectedValue == "0")
            {
                for (int i = 1; i <= ddow011.Items.Count - 1; i++)
                {
                    if (ddow011.Items[i] != null) // el 8 no existe
                    {
                        ddow011.Items[i].Enabled = false;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;

                    }
                }
                ddow011.SelectedValue = "0";
            }
        }
    }
    protected void ddown011_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
