using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Data.Objects;
using System.IO;
using System.Drawing;

public partial class mod_instituciones_AnalisisCasos : System.Web.UI.Page
{
    public int UserId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }

    public string Rol
    {
        get { return Session["contrasena"].ToString(); }
        //set { Session["contrasena"] = value; }
        set { Session["contrasena"] = (value != null) ? value : "0"; }
    }


    //int rol = Convert.ToInt32(Session["contrasena"]); 
    int codRegion;
    int icodie;
    int codProyecto;
    DateTime fechaReunion;
    string comentario;
    int codTipoEvento;
    int mesFechaReunionAnterior;
    DateTime bloqueaCalendario;

    
    private void validatesecurity()
    {
        if (!window.existetoken("7204D523-8221-4D3B-B07D-21DB8B886975"))
        {
            Response.Redirect("~/e403.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        Session["ultimoTab"] = ultimoTab.Value.ToString();

        if (Rol == "0") {
            Response.Redirect("~/e403.aspx");
        }
        //Session["IdUsuario"] = 44707;

        //Rol = Session["contrasena"];

        //Se obtiene el código de región del usuario, para cargar las instituciones
        DataView dvRegionUsuario = getRegionUsuario();

        codRegion = Convert.ToInt16(dvRegionUsuario.Table.Rows[0][0]);
        //codRegion = Convert.ToInt16(dvRegionUsuario.Table.Rows[14][0]);

        //AlertaSuccess.Style.Add("display", "none");

        if (!IsPostBack)
        {
            if (Rol != "252")
            {
                cargaInstitucionesxRegion();
                cargaProyectosxRegion();
                //getproyectos();
            }
            else
            {
                getinstituciones();
                getproyectos();
            }


            if (Request.QueryString["sw"] == "3")
            {
                if (Session["ultimoTab"] == "0")
                {
                    getinstituciones();
                    DDInstituciones.SelectedValue = Request.QueryString["codinst"];
                    DDInstituciones_SelectedIndexChanged(sender, e);
                    DDProyectos.SelectedValue = "0";
                    getinstituciones();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "marcarIngresos();", true);
                }
                else
                {
                    DDInstitucionConsulta.SelectedValue = Request.QueryString["codinst"];
                    DDInstituciones_SelectedIndexChanged(sender, e);
                    DDProyectos.SelectedValue = "0";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "marcarConsultas();", true);
                }
            }

            if (Request.QueryString["sw"] == "4")
            {
                if (Session["ultimoTab"] == "0")
                {
                    getinstituciones();
                    DDInstituciones.SelectedValue = Request.QueryString["codproy"];
                    getproyectos();
                    DDProyectos.SelectedValue = Request.QueryString["codinst"];
                    DDProyectos_SelectedIndexChanged(sender, e);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "marcarIngresos();", true);
                }
                else
                {
                    getinstituciones();
                    DDInstitucionConsulta.SelectedValue = Request.QueryString["codproy"];
                    getproyectos();
                    DDProyectoConsulta.SelectedValue = Request.QueryString["codinst"];
                    DDProyectos_SelectedIndexChanged(sender, e);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "marcarConsultas();", true);
                }

            }

            #region GenerarTablaManual
            //CEFechaEvento.EndDate = DateTime.Now;
            //getAtendidos();

            //if (DDProyectos.Items.Count == 0)
            //    cargaProyectosxRegion();

            //DataTable dtAtendidosMensual = new DataTable();

            //DataColumn ICODIE = dtAtendidosMensual.Columns.Add("ICODIE");
            //DataColumn Apellido_Paterno = dtAtendidosMensual.Columns.Add("Apellido_Paterno");
            //DataColumn Apellido_Materno = dtAtendidosMensual.Columns.Add("Apellido_Materno");
            //DataColumn Nombres = dtAtendidosMensual.Columns.Add("Nombres");
            //DataColumn Seleccionado = dtAtendidosMensual.Columns.Add("Seleccionado");

            //DataRow r = dtAtendidosMensual.NewRow();

            //r["ICODIE"] = this.GridAtendidosMensual.Rows.Count + 1;
            //r["Apellido_Paterno"] = "Villaseca";
            //r["Apellido_Materno"] = "Riquelme";
            //r["Nombres"] = "Jorge Antonio";
            //r["Seleccionado"] = 1;

            //dtAtendidosMensual.Rows.Add(r);
            //dtAtendidosMensual.AcceptChanges();

            //GridAtendidosMensual.DataSource = dtAtendidosMensual;
            //GridAtendidosMensual.DataBind();
            #endregion

            validatesecurity();
        }   
        
    }

    private void asignarTab(int ultimoTab){
        Session["ultimoTab"] = ultimoTab;
    }

    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        // DataTable dtinst = icoll.GetData(UserId);
        DataTable dtinst = icoll.GetData_DataSet((DataSet)Session["dsParametricas"]);
        DataView dv1 = new DataView(dtinst);
        dv1.Sort = "Nombre";

        DDInstituciones.DataSource = dv1;
        DDInstituciones.DataTextField = "Nombre";
        DDInstituciones.DataValueField = "CodInstitucion";

        DDInstituciones.SelectedValue = "0";

        DDInstituciones.DataBind();

        DDInstitucionConsulta.DataSource = dv1;
        DDInstitucionConsulta.DataTextField = "Nombre";
        DDInstitucionConsulta.DataValueField = "CodInstitucion";

        DDInstitucionConsulta.SelectedValue = "0";

        DDInstitucionConsulta.DataBind();


        // <---------- DPL ---------->  09-08-2010
        if (dtinst.Rows.Count == 2)
        {
            DDInstituciones.SelectedIndex = 1;
            DDInstitucionConsulta.SelectedIndex = 1;
        }
        else
        {
            DDInstituciones.SelectedIndex = 0;
            DDInstitucionConsulta.SelectedIndex = 0;
        }
        
        // <---------- DPL ---------->  09-08-2010

        
    }

    private void getproyectos()
    {
        proyectocoll pcoll = new proyectocoll();
        string estado = "V";

        DataTable dtproy = new DataTable();
        DataTable dtproy2 = new DataTable();

        dtproy = pcoll.GetData(Convert.ToInt32(UserId), estado, Convert.ToInt32(DDInstituciones.SelectedValue));
        dtproy2 = pcoll.GetData(Convert.ToInt32(UserId), estado, Convert.ToInt32(DDInstitucionConsulta.SelectedValue));
        DataView dv1 = new DataView(dtproy);
        DataView dv2 = new DataView(dtproy2);
        // <---------- DPL ---------->  09-08-2010
        dv1.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        dv2.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";   
        // <---------- DPL ---------->  09-08-2010

        DDProyectos.SelectedIndex = 0;
        DDProyectos.DataSource = dv1;
        DDProyectos.DataTextField = "Nombre";
        DDProyectos.DataValueField = "CodProyecto";//"Codigo Proyecto";
        dv1.Sort = "CodProyecto";
        DDProyectos.DataBind();

        DDProyectoConsulta.SelectedIndex = 0;
        DDProyectoConsulta.DataSource = dv2;
        DDProyectoConsulta.DataTextField = "Nombre";
        DDProyectoConsulta.DataValueField = "CodProyecto";
        dv1.Sort = "CodProyecto";
        DDProyectoConsulta.DataBind();

    }

    private DataView getRegionUsuario()
    {
        parcoll p = new parcoll();
        DataView dv1 = new DataView(p.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));

        return dv1;
    }

    private void cargaInstitucionesxRegion()
    {
        institucioncoll i = new institucioncoll();
        DataView dv = new DataView(i.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), codRegion));

        DDInstituciones.DataSource = dv;
        DDInstituciones.DataTextField = "Nombre";
        DDInstituciones.DataValueField = "CodInstitucion";
        dv.Sort = "Nombre";
        DDInstituciones.DataBind();

        DDInstitucionConsulta.DataSource = dv;
        DDInstitucionConsulta.DataTextField = "Nombre";
        DDInstitucionConsulta.DataValueField = "CodInstitucion";
        dv.Sort = "Nombre";
        DDInstitucionConsulta.DataBind();

        if (dv.Count == 2)
        {
            DDInstituciones.SelectedIndex = 1;
            DDInstitucionConsulta.SelectedIndex = 1;
            //cargaProyectosxRegion();
        }

    }

    private void cargaProyectosxRegion()
    {
        if (DDInstituciones.SelectedValue != "0")
        {
            proyectocoll proy = new proyectocoll();
            DataView dv1 = new DataView(proy.GetProyectos_Region_Institucion(codRegion, Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(DDInstituciones.SelectedValue)));


            //DataView dvX = new DataView(proy.GetProyectoxInst(Convert.ToInt32(DDInstituciones.SelectedValue)));

            DDProyectos.DataSource = dv1;
            DDProyectos.DataTextField = "Nombre";
            DDProyectos.DataValueField = "CodProyecto";
            dv1.Sort = "CodProyecto";
            dv1.RowFilter = "CodRegion = " + codRegion;
            DDProyectos.DataBind();

            DDProyectoConsulta.DataSource = dv1;
            DDProyectoConsulta.DataTextField = "Nombre";
            DDProyectoConsulta.DataValueField = "CodProyecto";
            dv1.Sort = "CodProyecto";
            dv1.RowFilter = "CodRegion = " + codRegion;
            DDProyectoConsulta.DataBind();

            DDProyectos.Items.Add(new ListItem("Seleccionar", "0"));
            DDProyectoConsulta.Items.Add(new ListItem("Seleccionar", "0"));
            //DDProyectos.SelectedValue = "0";

            DDProyectos.SelectedIndex = dv1.Count;
            DDProyectoConsulta.SelectedIndex = dv1.Count;

            //if (dv1.Count == 2){
            //    DDProyectos.SelectedIndex = 1;
            //    DDProyectoConsulta.SelectedIndex = 1;
            //}
        }
        else
        {
            proyectocoll proy = new proyectocoll();
            DataView dv1 = new DataView(proy.GetProyectos_Region_Institucion(codRegion, Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(DDInstitucionConsulta.SelectedValue)));

            DDProyectos.DataSource = dv1;
            DDProyectos.DataTextField = "Nombre";
            DDProyectos.DataValueField = "CodProyecto";
            dv1.Sort = "CodProyecto";
            dv1.RowFilter = "CodRegion = " + codRegion;

            DDProyectos.DataBind();
            DDProyectos.Items.Add(new ListItem("Seleccionar", "0"));

            //DDProyectos.SelectedValue = "0";
            DDProyectos.SelectedIndex = dv1.Count;

            DDProyectoConsulta.SelectedIndex = 0;

            //if (dv1.Count == 2)
            //    DDProyectos.SelectedIndex = 1;
        }
    }

    protected void DDInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rol != "252")
        {
            cargaProyectosxRegion();
        }
        else
        {
            getproyectos();
        }
        asignarTab(0);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarProyecto", "$('#thproyecto').fadeIn('slow');$('#tdproyecto').fadeIn('slow');", true);
    }

    private void getTipoEvento()
    {
        //parcoll p = new parcoll();
        //DataView dvTipoEventosAnalisisCasos = new DataView(p.getTipoEventosAnalisisCasos());

        //dvTipoEventosAnalisisCasos.Sort = "CodEventosAnalisisCaso";
        //DDTiposEventos.DataSource = dvTipoEventosAnalisisCasos;
        //DDTiposEventos.DataTextField = "Descripcion";
        //DDTiposEventos.DataValueField = "CodEventosAnalisisCaso";
        //DDTiposEventos.DataBind();
    }

    private void getConsultaAtendidos()
    {
        string comentario;
        ninocoll n = new ninocoll();
        DataTable dtConsultaAnalisisCaso = new DataTable();

        DataView dv = new DataView(dtConsultaAnalisisCaso);

        dtConsultaAnalisisCaso = getConsultaAtendidos(Convert.ToInt32(DDProyectoConsulta.SelectedValue), txtFechaConsulta.Text);

        try
        {
            comentario = dtConsultaAnalisisCaso.Rows[0][15].ToString();
        }
        catch
        {
            comentario = "No existe comentario asociado";
        }

        DescripcionConsulta.Text = comentario;
        DescripcionConsulta.Enabled = false;

        gridConsultaAtendidos.DataSource = dtConsultaAnalisisCaso;
        gridConsultaAtendidos.DataBind();

        if (gridConsultaAtendidos.Rows.Count > 0)
            gridConsultaAtendidos.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid


        foreach (GridViewRow grow in gridConsultaAtendidos.Rows)
        {
            try
            {
                int tipoEvento = Convert.ToInt16(grow.Cells[13].Text);

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
        //gridConsultaAtendidos.Style.Add("display", "none");
        lblTituloGridConsulta.Text = "Atendidos en reunion del día " + txtFechaConsulta.Text;
        //lblTituloGridConsulta.Style.Add("display", "none");


        //ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarGrid", "mostrarGridConsultaAtendidosMensual();", true);
        //mostrarGridAtendidosMensual

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarGrid", "mostrarGridAtendidosMensual();", true); //$('#tituloGrid').fadeIn('slow');
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "GridToDatatable2", "gridConsultaAsistenciaDatatable();", true);
        
    }

    private void getAtendidos()
    {
        //parcoll p = new parcoll();
        ninocoll n = new ninocoll();
        DataTable dtTipoAnalisisCasos = new DataTable();

        DataView dv = new DataView(dtTipoAnalisisCasos);

        //DataTable dtTipoAnalisisFiltered = dv.ToTable(true);

        //dtTipoAnalisisCasos = n.getAtendidos(Convert.ToInt32(DDProyectos.SelectedValue));
        dtTipoAnalisisCasos = getAtendidos(Convert.ToInt32(DDProyectos.SelectedValue));
        GridAtendidosMensual.DataSource = dtTipoAnalisisCasos;
        GridAtendidosMensual.DataBind();

        if (GridAtendidosMensual.Rows.Count > 0)
            GridAtendidosMensual.HeaderRow.TableSection = TableRowSection.TableHeader; //Se añade la seccion theader al grid
        
        

        CEFechaEvento.EndDate = DateTime.Now;
        CEFechaEvento.StartDate = Convert.ToDateTime("01-01-2007");
        lblMesAtendido.Text = "";

        foreach (GridViewRow grow in GridAtendidosMensual.Rows)
        {
            try // Evita que no se caiga el formulario al cargar la grilla al tener campos vacios
            {
                int tipoEvento = Convert.ToInt16(grow.Cells[13].Text);

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

                int anio;
                //lblMesAtendido.Text = "";

                if (grow.Cells[18].Text.ToString() != null && grow.Cells[18].Text != "&nbsp;")
                {
                    lblMesAtendido.Visible = true;
                    lblMesAtendido.Text = Convert.ToString(Convert.ToDateTime(grow.Cells[18].Text.ToString()).ToShortDateString());
                    //mesFechaReunionAnterior = Convert.ToDateTime(grow.Cells[18].Text.ToString()).Month;

                    //anio = Convert.ToInt32(Convert.ToDateTime((grow.Cells[18].Text.ToString())).Year);

                    //if (mesFechaReunionAnterior == 12)
                    //{
                    //    mesFechaReunionAnterior = 1;
                    //}
                    //else
                    //{
                    //    mesFechaReunionAnterior += 1;
                    //}

                    //if (mesFechaReunionAnterior < 10)
                    //{
                    //    mesFechaReunionAnterior = Convert.ToInt32("0" + Convert.ToString(mesFechaReunionAnterior));
                    //}

                    //bloqueaCalendario = Convert.ToDateTime("01-" + mesFechaReunionAnterior + "-" + anio);

                    //CEFechaEvento.StartDate = bloqueaCalendario;
                    //CEFechaEvento.EndDate = bloqueaCalendario.AddDays(30);
                }
                GridAtendidosMensual.Visible = true;
                //GridAtendidosMensual.Style.Add("display", "none");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarGrid", "mostrarGridAtendidosMensual();", true);

                
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarGrid", "$('#GridAtendidosMensual').fadeIn('slow');$('#tituloGrid').fadeIn('slow');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "GridToDatatable", "gridAsistenciaDatatable();", true);
            }
            catch
            {  }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        int ingresoCorrecto;
        int iCodAnalisisCaso;

        codProyecto = Convert.ToInt32(DDProyectos.SelectedValue);
        fechaReunion = Convert.ToDateTime(TxtFechaReunion.Text.Trim().Substring(0, 10));

        comentario = DescripcionAnalisisCasos.Text.Trim();

        ninocoll n = new ninocoll();

        //Metodo Insert de Encabezado (datos de reunion, fecha y proyecto)
        //iCodAnalisisCaso = n.guardarDatosReunionAtendidos(codProyecto, fechaReunion, comentario, Convert.ToInt32(Session["idUsuario"]));

        iCodAnalisisCaso = guardarDatosReunionAtendidos(codProyecto, fechaReunion, comentario, Convert.ToInt32(Session["IdUsuario"]));

        if (iCodAnalisisCaso > 0)
        {
            //Despues de registrar los datos de la reunión, se recorre la grilla para insertar los niños
            foreach (GridViewRow grow in GridAtendidosMensual.Rows)
            {
                icodie = Convert.ToInt32(grow.Cells[0].Text);

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

                if (codEventoAnalisisCaso != 0){
                    //n.guardarNiñosTratadosReunionAtendidos(iCodAnalisisCaso, icodie, codEventoAnalisisCaso);
                    guardarNiñosTratadosReunionAtendidos(iCodAnalisisCaso, icodie, codEventoAnalisisCaso);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarAlerta", "mostrarAlertaSuccess();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ocultarDivSuccess", "ocultarAlertaSuccess();", true);
                    //AlertaSuccess.Style.Add("display", "");
                    //lblAlertaSuccess.Style.Add("display", "");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ocultarDivSuccess", "$('#AlertaSuccess').delay(4000).fadeOut('slow');", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarAlerta", "mostrarAlertaSuccess();", true);    
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ocultarDivSuccess", "ocultarAlertaSuccess();", true);
                }
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "destruirDataTable", "destroyGridConsultaAtendidosMensual();", true);
            limpiar();
            asignarTab(0);
        }
        else
        {
        }
    }
    protected void btnModificar_Click(object sender, System.EventArgs e)
    {
        codProyecto = Convert.ToInt32(DDProyectoConsulta.SelectedValue);
        //fechaReunion = Convert.ToDateTime(txtFechaConsulta.Text.Trim().Substring(0, 10));

        ninocoll n = new ninocoll();

        foreach (GridViewRow grow in gridConsultaAtendidos.Rows)
        {
            int icodie = Convert.ToInt32(grow.Cells[0].Text);
            int iCodAnalisisCasoModif = Convert.ToInt32(grow.Cells[20].Text);
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
            chk_quitaEvento = grow.FindControl("quitaEvento") as CheckBox;

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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarAlerta", "mostrarAlertaSuccess();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ocultarDivSuccess", "ocultarAlertaSuccess();", true);
            }
            else
            {
                //Elimina
                deleteNiñoAtendido(icodie, iCodAnalisisCasoModif);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarAlerta", "mostrarAlertaSuccess();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ocultarDivSuccess", "ocultarAlertaSuccess();", true);
            }

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "destruirDataTable", "destroyGridConsultaAtendidosMensual();", true);
            limpiarConsulta();
            asignarTab(1);
        }
    }
         

    private void limpiar()
    {
        DDProyectos.SelectedValue = "0";
        DDInstituciones.SelectedValue = "0";
        TxtFechaReunion.Text = "";
        DescripcionAnalisisCasos.Text = "";
        GridAtendidosMensual.Visible = false;
        lblMesAtendido.Visible = false;

    }

    private void limpiarConsulta()
    {
        DDInstitucionConsulta.SelectedValue = "0";
        DDProyectoConsulta.SelectedValue = "0";
        txtFechaConsulta.Text = "";
        DescripcionConsulta.Text = "";
        gridConsultaAtendidos.Style.Add("display", "none");
        DescripcionConsulta.Enabled = true;
        btnModificar.Style.Add("display", "");
        gridConsultaAtendidos.Visible = false;
    }

    protected void DerivacionFAEPROaFAEAADD_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ReunificacionFamiliar_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void DerovacionUnidadAdopcion_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void SeMantieneAnalisisCaso_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void quitaEvento_CheckedChanged(object sender, System.EventArgs e)
    {

    }

    protected void DDProyectos_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        getAtendidos();
        asignarTab(0);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarLblultimaReunion", "$('#complementoLblmesAtendido').fadeOut('slow');", true);
    }
    protected void btnLimpiar_Click(object sender, System.EventArgs e)
    {
        limpiar();
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
                deleteReunion(icodAnalisisCaso);
            }
        }
        catch
        {
            return 0;
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
        catch {
            DataTable dt = new DataTable();
            dt = null;
            return dt;
        }
        
        
    }

    protected void btnExcel_Click(object sender, System.EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("Content-Disposition", "attachment;filename=ConsultaAnalisisCaso.xls");
        Response.ContentType = "application/vnd,ms-excel";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        DataTable dt = new DataTable();
        DataGrid d1 = new DataGrid();
        
        dt = getReporteAnalisisCasos(Convert.ToInt32(DDProyectoConsulta.SelectedValue));
        
        d1.DataSource = dt;
        d1.DataBind();
        
        d1.RenderControl(htw);
        
        Response.Write(sw.ToString());
        Response.End();

    }

    public DataTable getReporteAnalisisCasos(int codProyecto)
    {
        DataTable dt = new DataTable();

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 10).Value = codProyecto;
        sqlc.CommandText = "getAtendidos_ReporteAnalisisCaso";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt;
    }
    protected void DDInstitucionConsulta_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (Rol != "252")
        {
            cargaProyectosxRegion();
        }
        else
        {
            getproyectos();
        }
        asignarTab(1);
        //DDProyectoConsulta.SelectedValue = "0";

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarProyecto", "$('#thproyecto').fadeIn('slow');$('#tdproyecto').fadeIn('slow');", true);
    }
    protected void txtFechaConsulta_TextChanged(object sender, System.EventArgs e)
    {
        getConsultaAtendidos();
        if (gridConsultaAtendidos.Rows.Count == 0)
        {
            btnModificar.Visible = false;
            btnExcel.Style.Add("display", "none");
        }
        else
        {
            btnModificar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarBtnExcel", "mostrarBotonExcel();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarBtnModif", "mostrarBotonModificar();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarGridConsultas", "mostrarGridConsultas();", true);

            
        }
        asignarTab(1);
    }
    
    protected void btnLimpiarConsulta_Click(object sender, System.EventArgs e)
    {
        limpiarConsulta();
    }

    protected void DDProyectoConsulta_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        //limpiar();
        asignarTab(1);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarBtnExcel", "mostrarBotonExcel();", true);
    }


    protected void btnExportar_Click(object sender, System.EventArgs e)
    {
        ExportToExcel();
    }
    protected void btnExcel_Click1(object sender, System.EventArgs e)
    {
        ExportToExcel();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ExportToExcel()
    {
        GridView miGrd = new GridView();
        DataTable dtReporte = new DataTable();

        dtReporte = ReporteAnalisisDeCaso(Convert.ToInt32(DDProyectos.SelectedValue));
        miGrd.DataSource = dtReporte;
        miGrd.DataBind();

        #region código eliminado
        /*
        foreach (GridViewRow grow in miGrd.Rows)
        {
            try
            {
                CheckBox chk = grow.FindControl("ReunificacionFamiliar") as CheckBox;
                if (chk.Checked)
                    grow.Cells[14].Text = "1";
                else
                    grow.Cells[14].Text = "0";

                chk = grow.FindControl("DerivacionFAEPROaFAEAADD") as CheckBox;
                if (chk.Checked)
                    grow.Cells[15].Text = "1";
                else
                    grow.Cells[15].Text = "0";

                chk = grow.FindControl("DerovacionUnidadAdopcion") as CheckBox;
                if (chk.Checked)
                    grow.Cells[16].Text = "1";
                else
                    grow.Cells[16].Text = "0";

                chk = grow.FindControl("SeMantieneAnalisisCaso") as CheckBox;
                if (chk.Checked)
                    grow.Cells[17].Text = "1";
                else
                    grow.Cells[17].Text = "0";
            }
            catch
            { }
        }
        */
        #endregion

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=AsistenciaMensual.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);


        miGrd.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();  
      
        //Response.Clear();

        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", "attachment;filename=AtendidosMensual.xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);

        //this.GridAtendidosMensual.AllowPaging = false;



        //this.GridAtendidosMensual.HeaderRow.BackColor = Color.White;
        //foreach (TableCell cell in GridAtendidosMensual.HeaderRow.Cells)
        //{
        //    cell.BackColor = GridAtendidosMensual.HeaderStyle.BackColor;
        //}
        //foreach (GridViewRow row in GridAtendidosMensual.Rows)
        //{
        //    row.BackColor = Color.White;
        //    foreach (TableCell cell in row.Cells)
        //    {
        //        if (row.RowIndex % 2 == 0)
        //            cell.BackColor = GridAtendidosMensual.AlternatingRowStyle.BackColor;
        //        else
        //            cell.BackColor = GridAtendidosMensual.RowStyle.BackColor;

        //        cell.CssClass = "textmode";
        //    }
        //}

        //miGrd.RenderControl(hw);

        //string style = "<style> .textmode { } </style>";
        //Response.Write(style);
        //Response.Output.Write(sw.ToString());
        //Response.Flush();
        //Response.End();
    }

    protected void test(){

    }

    protected void cargarUltimoTabSession_Click(object sender, System.EventArgs e)
    {
    }
    protected void mostrarProyectosConsultasPopup_Click(object sender, System.EventArgs e)
    {
        asignarTab(1);
    }
    protected void mostrarInstitucionesConsultaPopup_Click(object sender, System.EventArgs e)
    {
        asignarTab(0);
    }
}