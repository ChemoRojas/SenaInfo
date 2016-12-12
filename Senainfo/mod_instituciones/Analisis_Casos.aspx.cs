using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_instituciones_Analisis_Casos : System.Web.UI.Page
{
    #region Variables
    public int userId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }

    public string rol
    {
        get { return Session["contrasena"].ToString(); }
        set { Session["contrasena"] = (value != null) ? value : "0"; }
    }

    public int codRegion
    {
        get { return Convert.ToInt32(Session["CodRegionUsuario"].ToString()); }
        set { Session["CodRegionUsuario"] = (value != null) ? value : 0; }
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["CodRegionUsuario"] = 13;
        validatesecurity();

        //Si el rol viene en cero por alguna causa, sera derivado a una página de error.
        if (rol == "0")
        {
            Response.Redirect("~/e403.aspx");
        }


        //Asigna fecha actual a los calendarios del formulario
        calendarFechaConsulta.EndDate = DateTime.Now;
        calendarFechaReunion.EndDate = DateTime.Now;
        calendarFechaReunion.StartDate = DateTime.Now.AddMonths(-2);


        //rol = "253";
        if (!IsPostBack)
        {
            if (rol != "252")
            {
                //instituciones x region
                getInstitucionesxRegion(codRegion);
                // proyectos x region
            }
            else
            {
                //get todas las Instituciones
                getInstituciones();
                //get todos los proyectos
            }


            if (Request.QueryString["sw"] == "3")
            {
                if (rol != "252")
                {
                    getInstitucionesxRegion(codRegion);
                }
                else
                {
                    getInstituciones();
                }

                ddlInstitucion.SelectedValue = Request.QueryString["codinst"];
                ddlInstitucion_SelectedIndexChanged(sender, e);
                ddlProyecto.SelectedValue = "0";
            }

            if (Request.QueryString["sw"] == "4")
            {
                if (rol != "252")
                {
                    getInstitucionesxRegion(codRegion);

                }
                else
                {
                    getInstituciones();
                }

                ddlInstitucion.SelectedValue = Request.QueryString["codproy"];
                ddlInstitucion_SelectedIndexChanged(sender, e);
                ddlProyecto.SelectedValue = Request.QueryString["codinst"];
                ddlProyecto_SelectedIndexChanged(sender, e);
            }

        }
        else
        {
            if (Ingreso.Checked == true)
            {
                mostrarDatosIngreso();
            }
            else if (Consulta.Checked == true)
            {
                mostrarDatosConsulta();
            }
            else if (Reporte.Checked == true)
            {
                mostrarExportarDatos();
            }
            else
            {
                validaDropdowns();
            }
        }

    }
    #endregion
    
    #region Seguridad
    private void validatesecurity()
    {
        if (!window.existetoken("7204D523-8221-4D3B-B07D-21DB8B886975"))
        {
            Response.Redirect("~/e403.aspx");
        }
    }
    #endregion

    #region getData
    private void getInstituciones()
    {
        DataTable dtInstituciones = new DataTable();

        institucioncoll i = new institucioncoll();

        dtInstituciones = i.GetData_DataSet((DataSet)Session["dsParametricas"]);

        DataView dv1 = new DataView(dtInstituciones);

        dv1.Sort = "Nombre";

        ddlInstitucion.DataSource = dv1;
        ddlInstitucion.DataTextField = "Nombre";
        ddlInstitucion.DataValueField = "CodInstitucion";
        ddlInstitucion.DataBind();
    }
    private void getInstitucionesxRegion(int codRegion)
    {
        institucioncoll i = new institucioncoll();
        DataView dv = new DataView(i.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), codRegion));

        ddlInstitucion.DataSource = dv;
        ddlInstitucion.DataTextField = "Nombre";
        ddlInstitucion.DataValueField = "CodInstitucion";
        dv.Sort = "Nombre";
        ddlInstitucion.DataBind();
        
    }
    private void getProyectosxInstitucion()
    {
        proyectocoll p = new proyectocoll();

        string estado = "V";

        DataTable dtproy = new DataTable();

        dtproy = p.GetData(Convert.ToInt32(userId), estado, Convert.ToInt32(ddlInstitucion.SelectedValue));

        DataView dv1 = new DataView(dtproy);

        dv1.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";  // Excluye a los PER (programas de Residencias), PDC y PDE
        dv1.Sort = "CodProyecto";

        ddlProyecto.DataSource = dv1;
        ddlProyecto.DataTextField = "Nombre";
        ddlProyecto.DataValueField = "CodProyecto";
        ddlProyecto.DataBind();
    }
    private void getProyectosxInstitucionxRegion(int codregion)
    {

        if (ddlInstitucion.SelectedValue != "0")
        {
            proyectocoll proy = new proyectocoll();
            DataView dv1 = new DataView(GetProyectos_Region_Institucion(codRegion, Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddlInstitucion.SelectedValue)));

            dv1.Sort = "CodProyecto";
            dv1.RowFilter = "CodRegion = " + codRegion;
            ddlProyecto.DataSource = dv1;
            ddlProyecto.DataTextField = "Nombre";
            ddlProyecto.DataValueField = "CodProyecto";
            
            ddlProyecto.DataBind();
        }
    }

    #endregion

    #region ConsultasaBD
    public DataTable getAtendidos(int codProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
        sqlc.CommandText = "getAtendidos";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }
    public DataTable getConsultaAtendidos(int codProyecto, string fechaConsulta)
    {
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand sqlc = new SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
            sqlc.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = fechaConsulta;
            sqlc.CommandText = "getAtendidos_ReporteAnalisisCaso_Fecha";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();
            return dt;
        }
        catch
        {
            DataTable dt = new DataTable();
            dt = null;
            return dt;
        }


    }
    public DataTable ReporteAnalisisDeCaso(int codProyecto)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
        sqlc.CommandText = "getAtendidos_ReporteAnalisisCaso";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }
    public DataTable GetProyectos_Region_Institucion(int CodRegion, int userid, string indvigencia, int codinstitucion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Proyectos_Region_Inst_byuserid";
        sqlc.Parameters.Add("@userid", SqlDbType.Int, 4).Value = userid;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = codinstitucion;
        sqlc.Parameters.Add("@Region", SqlDbType.Int, 4).Value = CodRegion;
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();

        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[2] = codRegion;
        dr[15] = " Seleccionar";
        dt.Rows.Add(dr);

        return dt;
    }
    public void guardarNiñosTratadosReunionAtendidos(int iCodAnalisisCaso, int iCodIE, int CodEventoAnalisisCaso)
    {
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand sqlc = new SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.Add("@icodanalisiscaso", SqlDbType.Int, 10).Value = iCodAnalisisCaso;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int, 10).Value = iCodIE;
            sqlc.Parameters.Add("@codeventosanalisiscaso", SqlDbType.Int, 10).Value = CodEventoAnalisisCaso;
            sqlc.CommandText = "Insert_AnalisisCaso_Atendidos";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            sconn.Open();
            sqlc.ExecuteNonQuery();
            sconn.Close();
        }
        catch
        { }
    }
    public void updateNiñoAtendido(int iCodAnalisisCaso, int IcodIE, int CodEventoAnalisisCaso)
    {
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand sqlc = new SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int, 10).Value = IcodIE;
            sqlc.Parameters.Add("@icodanalisiscaso_atendido", SqlDbType.Int, 10).Value = iCodAnalisisCaso;
            sqlc.Parameters.Add("@codeventoanalisiscaso", SqlDbType.Int, 10).Value = CodEventoAnalisisCaso;
            sqlc.CommandText = "Update_AnalisisCaso_Atendidos";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            sconn.Open();
            sqlc.ExecuteNonQuery();
            sconn.Close();
        }
        catch
        {

        }
    }
    public void deleteReunion(int icodanalisiscaso)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();

        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@icodanalisiscaso", SqlDbType.Int, 10).Value = icodanalisiscaso;
        sqlc.CommandText = "Delete_ReunionAnalisisCaso";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
    }
    public int guardarDatosReunionAtendidos(int codProyecto, DateTime fechaReunion, string comentario, int idUsuario)
    {
        int iCodAnalisisCaso;
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
            sqlc.Parameters.Add("@fechareunion", SqlDbType.DateTime).Value = fechaReunion;
            sqlc.Parameters.Add("@comentario", SqlDbType.VarChar, 200).Value = comentario;
            sqlc.Parameters.Add("@idUsuario", SqlDbType.Int, 8).Value = idUsuario;

            SqlParameter iCodAnalisisCasoReturn = new SqlParameter();
            iCodAnalisisCasoReturn.ParameterName = "@ICodAnalisisCaso";
            iCodAnalisisCasoReturn.SqlDbType = SqlDbType.Int;
            iCodAnalisisCasoReturn.Direction = ParameterDirection.Output;
            sqlc.Parameters.Add(iCodAnalisisCasoReturn);

            sqlc.CommandText = "Insert_AnalisisCasos";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            sconn.Open();
            sqlc.ExecuteNonQuery();
            iCodAnalisisCaso = Int32.Parse(sqlc.Parameters["@iCodAnalisisCaso"].Value.ToString());
            sconn.Close();

            return iCodAnalisisCaso;
        }
        catch
        {
            return 0;
        }
    }
    public int deleteNiñoAtendido(int ICodIE, int icodAnalisisCaso)
    {
        try
        {
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand sqlc = new SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = CommandType.StoredProcedure;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int, 10).Value = ICodIE;
            sqlc.Parameters.Add("@icodanalisiscaso_atendido", SqlDbType.Int, 10).Value = icodAnalisisCaso;

            SqlParameter contadorNinosrestantes = new SqlParameter();
            contadorNinosrestantes.ParameterName = "@contadorNinosRestantes";
            contadorNinosrestantes.SqlDbType = SqlDbType.Int;
            contadorNinosrestantes.Direction = ParameterDirection.Output;
            sqlc.Parameters.Add(contadorNinosrestantes);

            sqlc.CommandText = "Delete_AnalisisCaso_Atendidos";
            SqlDataAdapter da = new SqlDataAdapter(sqlc);
            sconn.Open();
            sqlc.ExecuteNonQuery();

            int contador = Int32.Parse(sqlc.Parameters["@contadorNinosrestantes"].Value.ToString());

            sconn.Close();

            return contador;

            if (contador == 0)
            {
                //deleteReunion(icodAnalisisCaso);
            }
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region Botones
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        int codProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";

        Response.AddHeader("Content-Disposition", "attachment;filename=AnalisisCasos_" + codProyecto + ".xls");

        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView gridReporte = new GridView();
        DataTable dt = new DataTable();

        dt = ReporteAnalisisDeCaso(codProyecto);

        gridReporte.DataSource = dt;
        gridReporte.DataBind();

        gridReporte.RenderControl(htw);

        Response.Write(sw.ToString());
        Response.End();

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        int ingresoCorrecto = 0, iCodAnalisisCaso = 0, codProyecto = 0, idUsuario = 0, icodie = 0;
        string comentario;
        DateTime fechaReunion;

        codProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
        fechaReunion = Convert.ToDateTime(txtFechaReunion.Text);
        comentario = txtDescripcionIngreso.Text.Trim();
        idUsuario = Convert.ToInt32(Session["idUsuario"]);

        iCodAnalisisCaso = guardarDatosReunionAtendidos(codProyecto, fechaReunion, comentario, idUsuario);

        if (iCodAnalisisCaso > 0)
        {
            foreach (GridViewRow grow in gridAtendidos.Rows)
            {
                icodie = Convert.ToInt32(grow.Cells[1].Text);

                int codEventoAnalisisCaso = 0;

                CheckBox chk_ReunificacionFamiliar = new CheckBox();
                CheckBox chk_DerivacionFAEPROaFAEAADD = new CheckBox();
                CheckBox chk_DerovacionUnidadAdopcion = new CheckBox();
                CheckBox chk_SeMantieneAnalisisCaso = new CheckBox();

                chk_ReunificacionFamiliar = grow.FindControl("ReunificacionFamiliar") as CheckBox;
                chk_DerivacionFAEPROaFAEAADD = grow.FindControl("DerivacionFAEPROaFAEAADD") as CheckBox;
                chk_DerovacionUnidadAdopcion = grow.FindControl("DerovacionUnidadAdopcion") as CheckBox;
                chk_SeMantieneAnalisisCaso = grow.FindControl("SeMantieneAnalisisCaso") as CheckBox;

                if (chk_ReunificacionFamiliar.Checked)
                {
                    codEventoAnalisisCaso = 1;
                }

                if (chk_DerivacionFAEPROaFAEAADD.Checked)
                {
                    codEventoAnalisisCaso = 2;
                }

                if (chk_DerovacionUnidadAdopcion.Checked)
                {
                    codEventoAnalisisCaso = 3;
                }

                if (chk_SeMantieneAnalisisCaso.Checked)
                {
                    codEventoAnalisisCaso = 4;
                }

                if (codEventoAnalisisCaso != 0)
                {
                    guardarNiñosTratadosReunionAtendidos(iCodAnalisisCaso, icodie, codEventoAnalisisCaso);
                    gridAtendidos.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "e", "mostrarAlertaSuccess();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "ocultarAlertaSuccess();", true);
                    limpiar();
                }
            }
        }

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        limpiar();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        int codProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);

        foreach(GridViewRow grow in gridConsultaAtendidos.Rows)
        {
            int iCodAnalisisCasoModif = Convert.ToInt32(grow.Cells[1].Text);
            int icodie = Convert.ToInt32(grow.Cells[2].Text);
            int CodEventoAnalisisCasoModif = 0;

            CheckBox chk_ReunificacionFamiliar = new CheckBox();
            CheckBox chk_DerivacionFAEPROaFAEAADD = new CheckBox();
            CheckBox chk_DerovacionUnidadAdopcion = new CheckBox();
            CheckBox chk_SeMantieneAnalisisCaso = new CheckBox();
            CheckBox chk_quitaEvento = new CheckBox();

            chk_ReunificacionFamiliar = grow.FindControl("ReunificacionFamiliar") as CheckBox;
            chk_DerivacionFAEPROaFAEAADD = grow.FindControl("DerivacionFAEPROaFAEAADD") as CheckBox;
            chk_DerovacionUnidadAdopcion = grow.FindControl("DerovacionUnidadAdopcion") as CheckBox;
            chk_SeMantieneAnalisisCaso = grow.FindControl("SeMantieneAnalisisCaso") as CheckBox;
            chk_quitaEvento = grow.FindControl("quitarEvento") as CheckBox;

            if (chk_ReunificacionFamiliar.Checked)
            {
                CodEventoAnalisisCasoModif = 1;
            }

            if (chk_DerivacionFAEPROaFAEAADD.Checked)
            {
                CodEventoAnalisisCasoModif = 2;
            }

            if (chk_DerovacionUnidadAdopcion.Checked)
            {
                CodEventoAnalisisCasoModif = 3;
            }

            if (chk_SeMantieneAnalisisCaso.Checked)
            {
                CodEventoAnalisisCasoModif = 4;
            }

            if (chk_quitaEvento.Checked)
            {
                CodEventoAnalisisCasoModif = -1;
            }

            if (CodEventoAnalisisCasoModif > 0)
            {
                //Actualiza
                updateNiñoAtendido(iCodAnalisisCasoModif, icodie, CodEventoAnalisisCasoModif);
                gridConsultaAtendidos.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "e", "mostrarAlertaSuccess();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "ocultarAlertaSuccess();", true);
                limpiar();
                
            }
            else
            {
                //Elimina
                deleteNiñoAtendido(icodie, iCodAnalisisCasoModif);
                gridConsultaAtendidos.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "e", "mostrarAlertaSuccess();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "f", "ocultarAlertaSuccess();", true);
                limpiar();
            }
        }

        limpiar();
    }
    #endregion

    #region cambiosdevaloresInputs
    protected void ddlInstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rol != "252")
        {
            getProyectosxInstitucionxRegion(codRegion);
            validaDropdowns();
        }
        else
        {
            getProyectosxInstitucion();
            validaDropdowns();
        }
    }
    protected void txtFechaConsulta_TextChanged(object sender, EventArgs e)
    {
        getGridConsultaAtendidos();
    }
    protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        validaDropdowns();
    }
    #endregion

    #region CheckboxChanged
    protected void Ingreso_CheckedChanged(object sender, EventArgs e)
    {
        mostrarDatosIngreso();
        getGridAtendidos();
        bloquearDropdowns();
    }
    protected void Consulta_CheckedChanged(object sender, EventArgs e)
    {
        mostrarDatosConsulta();
        txtFechaConsulta_TextChanged(sender, e);
        bloquearDropdowns();
    }
    protected void Reporte_CheckedChanged(object sender, EventArgs e)
    {
        mostrarExportarDatos();
        bloquearDropdowns();
    }
    #endregion

    #region mostrarDatos
    private void mostrarDatosIngreso()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "mostrarDatosIngreso();", true);
    }
    private void mostrarDatosConsulta()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "mostrarDatosConsulta();", true);
    }
    private void mostrarExportarDatos()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "mostrarExportar();", true);
    }
    #endregion

    #region GetGrids
    private void getGridAtendidos()
    {
        int codProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
        DataTable dtGridAtendidos = new DataTable();

        dtGridAtendidos = getAtendidos(codProyecto);

        gridAtendidos.DataSource = dtGridAtendidos;
        gridAtendidos.DataBind();

        if (gridAtendidos.Rows.Count > 0)
            gridAtendidos.HeaderRow.TableSection = TableRowSection.TableHeader;

        gridAtendidos.Visible = true;
    }

    private void getGridConsultaAtendidos()
    {
        string comentario;
        int codProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);

        DataTable dtConsultaAtendidos = new DataTable();

        dtConsultaAtendidos = getConsultaAtendidos(codProyecto, txtFechaConsulta.Text);

        //DataView dv = new DataView(dtConsultaAtendidos);

        try
        {
            comentario = dtConsultaAtendidos.Rows[0][15].ToString();
        }
        catch (Exception e)
        {
            comentario = "No existe comentario asociado a esta fecha";
        }

        txtDescripcionConsulta.Text = comentario;
        txtDescripcionConsulta.Enabled = false;

        gridConsultaAtendidos.DataSource = dtConsultaAtendidos;
        gridConsultaAtendidos.DataBind();

        if (gridConsultaAtendidos.Rows.Count > 0)
            gridConsultaAtendidos.HeaderRow.TableSection = TableRowSection.TableHeader;


        //Recorremos el Grid, para marcar los eventos de los NNA
        foreach (GridViewRow grow in gridConsultaAtendidos.Rows)
        {
            try
            {
                int tipoEvento = Convert.ToInt16(grow.Cells[0].Text);

                if (tipoEvento == 1)
                {
                    CheckBox chk = grow.FindControl("ReunificacionFamiliar") as CheckBox;
                    chk.Checked = true;
                }
                else if (tipoEvento == 2)
                {
                    CheckBox chk = grow.FindControl("DerivacionFAEPROaFAEAADD") as CheckBox;
                    chk.Checked = true;
                }
                else if (tipoEvento == 3)
                {
                    CheckBox chk = grow.FindControl("DerovacionUnidadAdopcion") as CheckBox;
                    chk.Checked = true;
                }
                else if (tipoEvento == 4)
                {
                    CheckBox chk = grow.FindControl("SeMantieneAnalisisCaso") as CheckBox;
                    chk.Checked = true;
                }
                else
                {
                    grow.Style.Add("display", "none");
                }
            }
            catch
            {

            }
        }

        gridConsultaAtendidos.Visible = true;

    }
    #endregion

    #region limpiar
    private void limpiar()
    {
        ddlInstitucion.Enabled = true;
        ddlProyecto.Enabled = true;

        Ingreso.Checked = false;
        Reporte.Checked = false;
        Consulta.Checked = false;

        Ingreso.Enabled = false;
        Consulta.Enabled = false;
        Reporte.Enabled = false;

        ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "limpiarDatos();", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "ocultarIngreso();", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "c", "ocultarConsulta();", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "d", "ocultarExportar();", true);
        
    }
    #endregion

    #region validadoresYbloqueos
    private void validaDropdowns()
    {
        if (ddlInstitucion.SelectedValue != "0" && ddlProyecto.SelectedValue != "0")
        {
            Ingreso.Enabled = true;
            Consulta.Enabled = true;
            Reporte.Enabled = true;
        }
        else
        {
            Ingreso.Enabled = false;
            Consulta.Enabled = false;
            Reporte.Enabled = false;
        }
    }
    private void bloquearDropdowns()
    {
        ddlInstitucion.Enabled = false;
        ddlProyecto.Enabled = false;
    }
    #endregion
}