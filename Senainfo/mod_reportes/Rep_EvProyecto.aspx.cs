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
//////using neocsharp.NeoDatabase;

public partial class mod_reportes_Rep_EvProyecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else if (!window.existetoken("20A45A43-8077-4D06-BCAB-4B7B1BDF29D2"))
            {
                Response.Redirect("~/e403.aspx");
            }
            else
            {
                getinstituciones();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString(); 


                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();

                ImageButton1.Visible = false;
                if (Request.QueryString["sw"] == "3")
                {
                    limpiarDatosSession();
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                }

                if (Request.QueryString["sw"] == "4")
                {
                    limpiarDatosSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                }
                if (txtAno.Text == "") txtAno.Text = DateTime.Now.Year.ToString();
            }

            // si los datos de session poseen datos, estos se asignan a los controles que correspondan
        }

        //Se cargan en Session los datos utilizados
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
        Session["CodProyecto"] = ddproyecto.SelectedValue;

        if (cal_inicio.Text != "")
        {
            Consulto_x_Fecha();
        }
    }

    private void limpiarDatosSession()
    {
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetData(Convert.ToInt32(Session["IdUsuario"])));
        //DataView dv2 = new DataView(inst.GetInstitucionReporte());
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;
        else
            if (Session["CodInstitucion"] != null)
                ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();
    }
    private void getproyectoxinst()
    {
       proyectocoll proy = new proyectocoll();
       DataView dv3 = new DataView(proy.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
       ddproyecto.DataSource = dv3;
       ddproyecto.DataTextField = "Nombre";
       ddproyecto.DataValueField = "CodProyecto";
       dv3.Sort = "CodProyecto";
       ddproyecto.DataBind();

       if (dv3.Count == 2)
           ddproyecto.SelectedIndex = 1;
       else
           if (Session["CodProyecto"] != null)
               ddproyecto.SelectedValue = Session["CodProyecto"].ToString();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
            {
                if (ddproyecto.SelectedValue != "0" && txtAno.Text != "" && ddown_Mes.SelectedValue != "0")
                {
                    string Ano = txtAno.Text;
                    string Mes = ddown_Mes.SelectedValue;
                    string AnoMes = Ano + Mes;

                    DataTable dt = callto_reporte_evproyecto(ddproyecto.SelectedValue, AnoMes, "01-01-1900");
                    if (dt.Rows.Count > 0)
                    {
                        ninocoll ncoll = new ninocoll();
                        int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddproyecto.SelectedValue));
                        grd001.Columns[11].Visible = (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 127 || CodModeloIntervencion == 101 || CodModeloIntervencion == 100);   // PPC - PROGRAMA PREVENCION COMUNITARIA - CRC - CSC - CIP

                        grd001.DataSource = dt;
                        grd001.DataBind();
                        grd001.Visible = true;

                        alerts.Visible = false;
                        lbl_tipo.Visible = false;
                        cal_inicio.Visible = true;
                        lbl_fechaEvento.Visible = true;
                        lbl_error.Visible = false;
                        ImageButton1.Visible = true;
                        pnlAsistencia.Visible = false;

                    }
                    else
                    {
                        alerts.Visible = true;
                        lbl_error.Visible = true;
                        lbl_fechaEvento.Visible = false;
                        lbl_error.Text = "No se han encontrado registros coincidentes";
                        cal_inicio.Visible = false;
                        grd001.Visible = false;

                        ImageButton1.Visible = false;
                    }

                }
                else

                {
                    lbl_error.Text = "Debe completar los datos de busqueda...";
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                }
    
    }
   
    private DataTable callto_reporte_evproyecto(string param_codproyecto, string param_anomes, string param_fechaevento)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Reporte_EvProyecto";
        sqlc.Parameters.Add("@param_CodProyecto", SqlDbType.VarChar, 50).Value = param_codproyecto;
        sqlc.Parameters.Add("@param_anomes", SqlDbType.VarChar, 50).Value = param_anomes;
        sqlc.Parameters.Add("@param_fechaEvento", SqlDbType.VarChar, 50).Value = param_fechaevento;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        ddown_Mes.SelectedIndex = -1;
        txtAno.Text = "";
        grd001.Visible = false;
        pnlAsistencia.Visible = false;
        alerts.Visible = false; 
        lbl_tipo.Visible = false;
        cal_inicio.Visible = false;

    }
    protected void ddlproyecto_SelectIndex_changed(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void cal_inicio_ValueChanged(object sender, EventArgs e)
    {
        if (ddproyecto.SelectedValue != "0" && cal_inicio.Text.ToString() != "SELECCIONE FECHA")
        {
            string FechaEvento = Convert.ToDateTime(cal_inicio.Text).ToShortDateString();
            string AnoMes = "0";
            DataTable dt = callto_reporte_evproyecto(ddproyecto.SelectedValue, AnoMes, FechaEvento);
            if (dt.Rows.Count > 0)
            {
                grd001.DataSource = dt;
                grd001.DataBind();
                grd001.Visible = true;

                ImageButton1.Visible = true;
            }
            else
            {
                lbl_error.Visible = true;
                grd001.Visible = false;
                ImageButton1.Visible = false;
            }
        }
    }
    protected void Consulto_x_Fecha()
    {
        try
        {
            if (ddproyecto.SelectedValue != "0" && cal_inicio.Text.ToString() != "")
            {
                string FechaEvento = Convert.ToDateTime(cal_inicio.Text).ToShortDateString();
                string AnoMes = "0";
                DataTable dt = callto_reporte_evproyecto(ddproyecto.SelectedValue, AnoMes, FechaEvento);
                if (dt.Rows.Count > 0)
                {
                    grd001.DataSource = dt;
                    grd001.DataBind();
                    grd001.Visible = true;

                    ImageButton1.Visible = true;
                }
                else
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text = "No se encontraron coincidencias... ";
                    grd001.Visible = false;
                    ImageButton1.Visible = false;
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_EvProyecto.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void grd001_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Institucion");
        dt.Columns.Add("Proyecto");
        dt.Columns.Add("TipoEvento");
        dt.Columns.Add("FechaEvento");
        dt.Columns.Add("Region");
        dt.Columns.Add("Comuna");
        dt.Columns.Add("ICodIE");
        dt.Columns.Add("ApellidoPaterno");
        dt.Columns.Add("ApellidoMaterno");
        dt.Columns.Add("Nombres");
        dt.Columns.Add("Presente");

        ListadoAsistencia(Convert.ToInt32(ddproyecto.SelectedItem.Value), Convert.ToInt32(grd001.Rows[e.NewEditIndex].Cells[12].Text), Convert.ToDateTime(grd001.Rows[e.NewEditIndex].Cells[2].Text));
        pnlAsistencia.Visible = true;
        grd001.Visible = false;
        ImageButton1.Visible = false;

        txtTipoEvento.Text = Server.HtmlDecode(grd001.Rows[e.NewEditIndex].Cells[1].Text);

        txtFechaEvento.Text = Server.HtmlDecode(grd001.Rows[e.NewEditIndex].Cells[2].Text);
        txtRegion.Text = Server.HtmlDecode(grd001.Rows[e.NewEditIndex].Cells[3].Text);
        txtComuna.Text = Server.HtmlDecode(grd001.Rows[e.NewEditIndex].Cells[4].Text);
        txtDescripcion.Text = Server.HtmlDecode(grd001.Rows[e.NewEditIndex].Cells[5].Text);

    }
    private void ListadoAsistencia(int CodProyecto, int ICodEventosProyectos, DateTime FechaVigencia)
    {
        ninocoll ncoll = new ninocoll();
        // = ASP.global_asax.globaconn;
        int CodModeloIntervencion = 0;

        CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(CodProyecto);

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinosEventoProyecto_PPC";
        sqlc.Parameters.Add("@ICodEventosProyectos", SqlDbType.Int, 4).Value = ICodEventosProyectos;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@FechaVigencia", SqlDbType.DateTime, 16).Value = (DateTime)FechaVigencia;
        sqlc.Parameters.Add("@MesCerrado", SqlDbType.Int, 4).Value = cierre_mes(CodProyecto, FechaVigencia);

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataView dv = new DataView(dt);
        dv.RowFilter = "Presente = 1";
        //if (dt.Rows.Count > 0)
        //{
            grdAsistencia.DataSource = dv;
            grdAsistencia.DataBind();
            lblCantidadAsistentes.Text = dv.Count.ToString() + " Niños/as Asistentes";
        //}

    }

    private int cierre_mes(int CodProyecto, DateTime Fecha)
    {
        diagnosticoscoll dgcol = new diagnosticoscoll();
        string mes = "";


        if (Fecha.Month.ToString().Length == 1)
        {
            mes = "0" + Fecha.Month.ToString();
        }
        else
        {
            mes = Fecha.Month.ToString();
        }

        int anomes = Convert.ToInt32(Fecha.Year.ToString() + mes);
        int cta = dgcol.callto_consulta_cierremes(CodProyecto, anomes);

        return cta;
    }
    protected void btn_VolverListadoEventos_Click(object sender, EventArgs e)
    {
        pnlAsistencia.Visible = false;
        grd001.Visible = true;
        ImageButton1.Visible = true;
    }
    protected void btnExportaExcelAsistencia_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void btnExportaExcelAsistencia_Click1(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Asistencia Ninos.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        dt.Columns.Add("Institucion");
        dt.Columns.Add("Proyecto");
        dt.Columns.Add("TipoEvento");
        dt.Columns.Add("FechaEvento");
        dt.Columns.Add("Region");
        dt.Columns.Add("Comuna");
        dt.Columns.Add("ICodIE");
        dt.Columns.Add("ApellidoPaterno");
        dt.Columns.Add("ApellidoMaterno");
        dt.Columns.Add("Nombres");

        DataRow dr;

        for (int i = 0; i < grdAsistencia.Rows.Count; i++)
        {
            dr = dt.NewRow();
            dr[0] = Server.HtmlEncode(ddinstitucion.SelectedItem.Text);
            dr[1] = Server.HtmlEncode(ddproyecto.SelectedItem.Text);
            dr[2] = Server.HtmlEncode(txtTipoEvento.Text);
            dr[3] = Server.HtmlEncode(txtFechaEvento.Text);
            dr[4] = Server.HtmlEncode(txtRegion.Text);
            dr[5] = Server.HtmlEncode(txtComuna.Text);

            for (int j = 1; j < grdAsistencia.Columns.Count - 2; j++)
            {
                if (j < 5)
                    dr[j + 5] = grdAsistencia.Rows[i].Cells[j].Text;
                //else
                //{
                //    CheckBox chkPresente = (CheckBox)grdAsistencia.Rows[i].Cells[j].FindControl("chkPresente");
                //    if (chkPresente.Checked)
                //        dr[j + 5] = "SI";
                //    else
                //        dr[j + 5] = "NO";
                //}
            }
            dt.Rows.Add(dr);
        }
        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();

    }
    protected void ImageButton1_Click1(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_EventosProyecto.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodProyecto");	//0
        dt.Columns.Add("DescTipoEvento");			//1
        dt.Columns.Add("FechaEvento");		//2
        dt.Columns.Add("Region");		    //3
        dt.Columns.Add("Comuna");	    //4
        dt.Columns.Add("Descripcion");	        //5
        dt.Columns.Add("CantAsistNinosAdolecentesFemenino");	        //6
        dt.Columns.Add("CantAsistNinosAdolecentesMasculino");	//7
        dt.Columns.Add("CantAsistAdultoFemenino");	//8
        dt.Columns.Add("CantAsistAdultoMasculino");	        //9
        dt.Columns.Add("CantidadAsistentes");	//10
        dt.Columns.Add("fld1");	//11
        dt.Columns.Add("ICodEventosProyectos");	//12
        dt.Columns.Add("FechaActualizacion");	//13

        DataRow dr;

        // Get the HTML for the control.
        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            dr = dt.NewRow();
            for (int j = 0; j < grd001.Columns.Count; j++)
            {
                dr[j] = grd001.Rows[i].Cells[j].Text;
            }
            dt.Rows.Add(dr);
        }
        dt.Columns.Remove("fld1");
        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        //Write the HTML back to the browser.
        Response.Write(tw.ToString());
        // End the response.
        Response.End();
    }
}
