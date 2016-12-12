using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


enum Meses
{
    Enero = 1,
    Febrero = 2,
    Marzo = 3,
    Abril = 4,
    Mayo = 5,
    Junio = 6,
    Julio = 7,
    Agosto = 8,
    Septiembre = 9,
    Octubre = 10,
    Noviembre = 11,
    Diciembre = 12
}

enum TiposRespuesta
{
    grdRespuestasObjetivosEspecificos = 1,
    grdRespuestasResultadosEsperados = 2,
    grdRespuestasMetaAñoQueCorresponda = 3,
    grdRespuestasIndicadorMeta = 4,
    grdRespuestasGradoCumplimiento = 5,
    grdRespuestasMediosVerificacion = 6,
    grdRespuestasObservaciones = 7,
    grdRespuestasHitosAcciones = 8,
    grdCausalIngreso = 9,
    grdViasIngreso = 10,
    grdAccionesTecnicasEstrategias = 11,
    grdIntervencionConNNA = 12,
    grdHitosAccionesPlanCoordinacion = 13,
    grdHitosAccionesAutoevaluacion = 14,
    grdHitosAccionesCapacitacion = 15,
    grdHitosAccionesAutoCuidado = 16,
    grdObjetivosEspecificosProximoAño = 17,
    grdResultadosEsperadosProximoAño = 18,
    grdMetaProximoAño = 19,
    grdIndicadorMetaProximoAño = 20,
    grdMediosVerificacionProximoAño = 21,
    grdHitosAccionesProximoAño = 22
}

public partial class mod_instituciones_AutoevaluacionPMG : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AñoSiguiente.Text = DateTime.Now.AddYears(1).Year.ToString();
            ProximoAño.Text = DateTime.Now.AddYears(1).Year.ToString();
            CEtxtPeriodoEvaluadoDesde.EndDate = DateTime.Now.AddDays(366 - DateTime.Now.DayOfYear);
            CEtxtPeriodoEvaluadoDesde.StartDate = DateTime.Now.AddDays(-(DateTime.Now.DayOfYear) + 1);
            CEtxtPeriodoEvaluadoHasta.EndDate = DateTime.Now.AddDays(366 - DateTime.Now.DayOfYear);
            CEtxtPeriodoEvaluadoHasta.StartDate = DateTime.Now.AddDays(-(DateTime.Now.DayOfYear) + 1);
            //institucioncoll i = new institucioncoll();

            //DataTable dtInstitucionesProyecto = new DataTable(); 

            //dtInstitucionesProyecto = i.Get_DataConProyectos_byUserId(65165);

        }
    }

    private void copiarGridViewEnDatatable(GridView grid)
    {
        DataTable dt = new DataTable();

        for (int i = 0; i < grid.Columns.Count; i++)
        {
            dt.Columns.Add("column" + i.ToString());
        }
        foreach (GridViewRow row in grid.Rows)
        {
            DataRow dr = dt.NewRow();
            for (int j = 0; j < grid.Columns.Count; j++)
            {
                dr["column" + j.ToString()] = row.Cells[j].Text;
            }

            dt.Rows.Add(dr);
        }
    }

    private void agregarFilaGridView(GridView grid, TextBox txt)
    {
        DataTable dt = new DataTable();

        for (int i = 0; i < grid.Columns.Count; i++)
        {
            if (i == 0)
            {
                dt.Columns.Add("NroRespuesta");
            }

            if (i == 1)
            {
                dt.Columns.Add("Respuesta");
            }
        }

        if (grid.Rows.Count > 0)
        {
            for (int j = 0; j < grid.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                dr["NroRespuesta"] = j + 1;
                dr["Respuesta"] = grid.Rows[j].Cells[1].Text;
                dt.Rows.Add(dr);
            }
        }


        DataRow drnew = dt.NewRow();
        drnew["NroRespuesta"] = dt.Rows.Count + 1;
        drnew["Respuesta"] = txt.Text;

        dt.Rows.Add(drnew);

        grid.DataSource = dt;
        grid.DataBind();

    }

    private void agregarFilaGridView(GridView grid, TextBox txt1, TextBox txt2)
    {
        DataTable dt = new DataTable();

        for (int i = 0; i < grid.Columns.Count; i++)
        {
            if (i == 0)
            {
                dt.Columns.Add("NroRespuesta");
            }

            if (i == 1)
            {
                dt.Columns.Add("Respuesta");
            }

            if (i==2)
            {
                dt.Columns.Add("Respuesta2");
            }
        }

        if (grid.Rows.Count > 0)
        {
            for (int j = 0; j < grid.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                dr["NroRespuesta"] = j + 1;
                dr["Respuesta"] = grid.Rows[j].Cells[1].Text;
                dr["Respuesta2"] = grid.Rows[j].Cells[2].Text;
                dt.Rows.Add(dr);
            }
        }


        DataRow drnew = dt.NewRow();
        drnew["NroRespuesta"] = dt.Rows.Count + 1;
        drnew["Respuesta"] = txt1.Text;
        drnew["Respuesta2"] = txt2.Text;

        dt.Rows.Add(drnew);

        grid.DataSource = dt;
        grid.DataBind();
    }

    private void agregarFilaGridView(GridView grid, TextBox txt1, TextBox txt2, RadioButtonList radio)
    {
        DataTable dt = new DataTable();

        for (int i = 0; i < grid.Columns.Count; i++)
        {
            if (i == 0)
            {
                dt.Columns.Add("NroRespuesta");
            }

            if (i == 1)
            {
                dt.Columns.Add("Respuesta");
            }

            if (i == 2)
            {
                dt.Columns.Add("RespuestaBool");
            }

            if (i == 3)
            {
                dt.Columns.Add("Respuesta2");
            }
        }

        if (grid.Rows.Count > 0)
        {
            for (int j = 0; j < grid.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                dr["NroRespuesta"] = j + 1;
                dr["Respuesta"] = grid.Rows[j].Cells[1].Text;
                dr["RespuestaBool"] = grid.Rows[j].Cells[2].Text;
                dr["Respuesta2"] = grid.Rows[j].Cells[3].Text;
                dt.Rows.Add(dr);
            }
        }


        DataRow drnew = dt.NewRow();
        drnew["NroRespuesta"] = dt.Rows.Count + 1;
        drnew["Respuesta"] = txt1.Text;
        drnew["RespuestaBool"] = radio.SelectedValue;
        drnew["Respuesta2"] = txt2.Text;

        dt.Rows.Add(drnew);

        grid.DataSource = dt;
        grid.DataBind();
    }

    private void agregarFilaGridView(GridView grid, TextBox txt1, CheckBoxList checkboxs)
    {
        DataTable dt = new DataTable();

        for (int i = 0; i < grid.Columns.Count; i++)
        {
            if (i == 0)
            {
                dt.Columns.Add("NroRespuesta");
            }

            if (i == 1)
            {
                dt.Columns.Add("Respuesta");
            }

            if (i == 2)
            {
                dt.Columns.Add("Meses");
            }
        }

        if (grid.Rows.Count > 0)
        {
            for (int j = 0; j < grid.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                dr["NroRespuesta"] = j + 1;
                dr["Respuesta"] = grid.Rows[j].Cells[1].Text;
                dr["Meses"] += grid.Rows[j].Cells[2].Text;
                               
                dt.Rows.Add(dr);
            }
        }

        DataRow drnew = dt.NewRow();
        drnew["NroRespuesta"] = dt.Rows.Count + 1;
        drnew["Respuesta"] = txt1.Text;

        string mesesAplicados;
        mesesAplicados = string.Empty;

        List<ListItem> nuevoMes = new List<ListItem>();
        foreach (ListItem item in checkboxs.Items)
        {
            if (item.Selected)
            {
                Meses m = (Meses)Enum.Parse(typeof(Meses), item.Value, true);
                mesesAplicados += m + ", ";
            }
        }
        //drnew["Meses"] = drnew["Meses"].ToString().Substring(0, drnew["Meses"].ToString().Length - 1);
        drnew["Meses"] = mesesAplicados.Substring(0, mesesAplicados.Length - 2);

        dt.Rows.Add(drnew);

        grid.DataSource = dt;
        grid.DataBind();
    }

    private void guardar()
    {
        AutoevaluacionPMG autoevaluacion;
        autoevaluacion = cargarDatosPMG();
        cargarRespuestasPMG();

    }

    private void cargarRespuestasPMG()
    {
        

        #region RespuestasPMG
        var c = GetAllGridViews(this, typeof(GridView));

        DataTable dtRespuestas = new DataTable();

        dtRespuestas.Columns.Add("TipoRespuesta");
        dtRespuestas.Columns.Add("NroRespuesta");
        dtRespuestas.Columns.Add("Respuesta");
        dtRespuestas.Columns.Add("Respuesta2");
        dtRespuestas.Columns.Add("Porcentaje");
        dtRespuestas.Columns.Add("RespuestaBool");
        dtRespuestas.Columns.Add("Meses");


        foreach (GridView grid in c)
        {
            if (grid.Rows.Count > 0)
            {
                //TiposRespuesta TR = (TiposRespuesta)Enum.Parse(typeof(TiposRespuesta), grid.ID, true);
                int TipoRespuesta = (int)Enum.Parse(typeof(TiposRespuesta), grid.ID, true);

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    int NroRespuesta = Convert.ToInt32(grid.Rows[i].Cells[0].Text);
                    string Respuesta = grid.Rows[i].Cells[1].Text;

                    DataRow drow = dtRespuestas.NewRow();
                    drow["TipoRespuesta"] = TipoRespuesta;
                    drow["NroRespuesta"] = NroRespuesta;
                    drow["Respuesta"] = Respuesta;

                    if (TipoRespuesta == 8 || TipoRespuesta == 11)
                    {
                        string Respuesta2 = grid.Rows[i].Cells[2].Text;  
                        drow["Respuesta2"] = Respuesta2;                
                    }

                    if (TipoRespuesta == 9)
                    {
                        double porcentaje = Convert.ToDouble(grid.Rows[i].Cells[2].Text);
                        drow["Porcentaje"] = porcentaje;
                    }

                    if (TipoRespuesta == 13 || TipoRespuesta == 14 || TipoRespuesta == 15 || TipoRespuesta == 16)
                    {
                        int RespuestaSiNo = Convert.ToInt32(grid.Rows[i].Cells[2].Text);
                        drow["RespuestaBool"] = RespuestaSiNo;
                    }

                    if (TipoRespuesta == 22)
                    {
                        string meses = grid.Rows[i].Cells[2].Text;
                        drow["meses"] = meses;
                    }

                    dtRespuestas.Rows.Add(drow);
                }
            }
        }
        #endregion
    }

    private AutoevaluacionPMG cargarDatosPMG()
    {
        AutoevaluacionPMG pmg = new AutoevaluacionPMG();

        #region Datos PMG
        //Tab1 - Datos Generales del Proyecto
        pmg.NombreCorto = txtNombreProyecto.Text;
        pmg.CodProyecto = (txtCodigo.Text == string.Empty) ? 0 : Convert.ToInt32(txtCodigo.Text);
        pmg.CodRegionProyecto = Convert.ToInt32(ddlRegiones.SelectedValue);
        pmg.ColaboradorAcreditado = txtColaboradorAcreditado.Text;
        pmg.Cobertura = txtCobertura.Text;
        pmg.LineaDeAccion = txtLineaAccion.Text;
        pmg.ModalidadAtencion = txtModalidadAtencion.Text;
        pmg.CoberturaTerritorial = txtCoberturaTerritorial.Text;
        pmg.PeriodoEvaluadoDesde = Convert.ToDateTime(txtPeriodoEvaluadoDesde.Text);
        pmg.PeriodoEvaluadoHasta = Convert.ToDateTime(txtPeriodoEvaluadoHasta.Text);
        pmg.FechaPresentacionInforme = Convert.ToDateTime(txtFechaPresentacionInforme.Text);
        pmg.ObjetivoGeneral = txtObjetivoGeneral.Text;

        //Tab 4
        pmg.DescripcionMetodologia = txtDescripcionMetodologia.Text;
        pmg.RutaArchivoDescripcionMetodologia = "";
        pmg.CuentaConInstrumentosPropiosEnfoquesPlanteados = (RadioButtonList1.SelectedValue == "1") ? true : false;
        pmg.InstrumentosPropiosEnfoquesPlanteados = txtCualesInstrumentos.Text;

        ////Tab 5
        pmg.FlujoDeAtencion = txtFlujoAtencion.Text;
        pmg.RutaArchivoFlujoDeAtencion = "";
        pmg.VRMencionActoresyProcedimientos = txtVinculacionRedesComunitarias.Text;
        pmg.RutaArchivoVRDescripcionEstrategiasTrabajo = txtDescripcionEstrategiasDelTrabajo.Text;
        pmg.VRDescribaEstrategiasCoordinacionEfectivaTribunalesFamilia = txtDescribaEstrategiasCoordinacion.Text;

        ////Tab 7
        pmg.DotacionPermaneceIgualComprometida = (rdblDotacionRecursosHumanos.SelectedValue == "1") ? true : false;
        pmg.DotacionJustificacionRespuesta = txtJustificaciónRespuestaDotación.Text;
        pmg.JornadaHorasProfesionalesIgualComprometida = (rdblJornada.SelectedValue == "1") ? true : false;
        pmg.JornadaJustificacionRespuesta = txtJustificacionRespuestaJornada.Text;
        pmg.Rotacion = (rdblRotacion.SelectedValue == "1") ? true : false;
        pmg.RotacionJustificacion = txtJustificacionRespuestaRotacion.Text;
        pmg.DescripcionOrganizacionEquipoDistribucionFunciones = txtDescribaRecursosHumanos.Text;
        pmg.RRHHObservaciones = txtObservacionesRecursosHumanos.Text;

        //Tab 8
        pmg.CheckSuperiorRM = chkSuperiorRM.Checked;
        pmg.CheckInferiorRM = chkInferiorRM.Checked;
        pmg.CheckIgualRM = chkIgualRM.Checked;
        pmg.JustificacionSuperiorRM = txtJustificacionSuperiorRM.Text;
        pmg.JustificacionInferiorRM = txtJustificacionInferiorRM.Text;
        pmg.JustificacionIgualRM = txtJustificacionigualRM.Text;
        pmg.ObservacionesRMI = txtObservacionesRMI.Text;


        //Tab 9
        pmg.MetodologiaProximoAño = txtMetodologiaProximoAño.Text;

        #endregion
        return pmg;
    }

    public IEnumerable<Control> GetAllGridViews(Control control, Type type)
    {
        var controls = control.Controls.Cast<Control>();

        return controls.SelectMany(ctrl => GetAllGridViews(ctrl, type))
            .Concat(controls)
            .Where(c => c.GetType() == type);
    }

    protected void btnAgregarRespuestaObjetivosEspecificos_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasObjetivosEspecificos, txtRespuestaObjetivosEspecificos);
    }
    protected void btnAgregarRespuestaResultadosEsperados_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasResultadosEsperados, txtRespuestaResultadosEsperados);
    }
    protected void btnAgregarRespuestaMetaAñoQueCorresponda_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasMetaAñoQueCorresponda, txtRespuestaMetaAñoQueCorresponda);
    }
    protected void btnAgregarRespuestaIndicadorMeta_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasIndicadorMeta, txtRespuestaIndicadorMeta);
    }
    protected void btnAgregarRespuestaGradoCumplimiento_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasGradoCumplimiento, txtRespuestaGradoCumplimiento);
    }
    protected void btnAgregarRespuestasMediosVerificacion_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasMediosVerificacion, txtRespuestaMediosVerificacion);
    }
    protected void btnAgregarRespuestasObservaciones_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasObservaciones, txtRespuestaObservaciones);
    }
    protected void btnAgregarRespuesta_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdRespuestasHitosAcciones, txtRespuestaHitosAcciones, txtRespuestaObservacionesActividades);
    }
    protected void btnAgregarCausalIngreso_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdCausalIngreso, txtCausalIngreso, txtPorcentajeCausalIngreso);
    }
    protected void btnAgregarViasIngreso_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdViasIngreso, txtViasIngreso);
    }
    protected void btnAgregarAccionesTecnicasEstrategias_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdAccionesTecnicasEstrategias, txtEnfoquesTransversalesTrabajo, txtAccionesTecnicasEstrategias);
    }
    protected void btnAgregarRespuestaHitosAccionesPlanCoordinacion_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdHitosAccionesPlanCoordinacion, txtHitosAccionesPlanCoordinacion, txtObservacionesHitosAccionesPlanCoordinacion, rblHitosAccionesPlanCoordinacion);
    }
    protected void btnAgregarRespuestaHitosAccionesAutoevaluacion_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdHitosAccionesAutoevaluacion, txtHitosAccionesAutoevaluacion, txtObservacionesHitosAccionesAutoevaluacion, rdblHitosAccionesAutoevaluacion);
    }
    protected void btnAgregarHitosAccionesCapacitacion_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdHitosAccionesCapacitacion, txtHitosAccionesCapacitacion, txtObservacionesHitosAccionesCapacitacion, rdblHitosAccionesCapacitacion);
    }
    protected void btnAgregarHitosAccionesAutocuidado_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdHitosAccionesAutoCuidado, txtHitosAccionesAutoCuidado, txtObservacionesHitosAccionesAutoCuidado, rdblHitosAccionesAutoCuidado);
    }
    protected void btnAgregarObjetivosEspecificosProximoAño_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdObjetivosEspecificosProximoAño, txtObjetivosEspecificosProximoAño);
    }
    protected void btnAgregarResultadosEsperadosProximoAño_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdResultadosEsperadosProximoAño, txtResultadosEsperadosProximoAño);
    }
    protected void btnAgregarMetaProximoAño_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdMetaProximoAño, txtMetaProximoAño);
    }
    protected void btnAgregarIndicadorMetaProximoAño_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdIndicadorMetaProximoAño, txtIndicadorMetaProximoAño);
    }
    protected void btnAgregarMediosVerificacionProximoAño_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdMediosVerificacionProximoAño, txtMediosVerificacionProximoAño);
    }
    protected void btnAgregarHitosAccionesProximoAño_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdHitosAccionesProximoAño, HitosAccionesProximoAño, chklistMeses);
    }
    protected void btnAgregarIntervencionConNNA_Click(object sender, EventArgs e)
    {
        agregarFilaGridView(grdIntervencionConNNA, txtIntervencionConNNA);
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        guardar();
    }
}