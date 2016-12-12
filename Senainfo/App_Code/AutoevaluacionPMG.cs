using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AutoevaluacionPMG
/// </summary>
public class AutoevaluacionPMG : proyecto
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

    #region Propiedades 
    #region Datos Generales del Proyecto 1
    private string _colaboradorAcreditado;

    public string ColaboradorAcreditado
    {
        get { return _colaboradorAcreditado; }
        set { _colaboradorAcreditado = value; }
    }

    private string _cobertura;

    public string Cobertura
    {
        get { return _cobertura; }
        set { _cobertura = value; }
    }

    private string _lineaDeAccion;

    public string LineaDeAccion
    {
        get { return _lineaDeAccion; }
        set { _lineaDeAccion = value; }
    }

    private string modalidadAtencion;

    public string ModalidadAtencion
    {
        get { return modalidadAtencion; }
        set { modalidadAtencion = value; }
    }

    private string _coberturaTerritorial;

    public string CoberturaTerritorial
    {
        get { return _coberturaTerritorial; }
        set { _coberturaTerritorial = value; }
    }

    private DateTime _periodoEvaluadoDesde;

    public DateTime PeriodoEvaluadoDesde
    {
        get { return _periodoEvaluadoDesde; }
        set { _periodoEvaluadoDesde = value; }
    }

    private DateTime _periodoEvaluadoHasta;

    public DateTime PeriodoEvaluadoHasta
    {
        get { return _periodoEvaluadoHasta; }
        set { _periodoEvaluadoHasta = value; }
    }

    private DateTime _fechaPresentacionInforme;

    public DateTime FechaPresentacionInforme
    {
        get { return _fechaPresentacionInforme; }
        set { _fechaPresentacionInforme = value; }
    }

    private string _objetivoGeneral;

    public string ObjetivoGeneral
    {
        get { return _objetivoGeneral; }
        set { _objetivoGeneral = value; }
    }
    #endregion

    

    #region Datos Generales del Proyecto 2
    private string _objetivosEspecificosRespuesta1;

    public string ObjetivosEspecificosRespuesta1
    {
        get { return _objetivosEspecificosRespuesta1; }
        set { _objetivosEspecificosRespuesta1 = value; }
    }

    private string _objetivosEspecificosRespuesta2;

    public string ObjetivosEspecificosRespuesta2
    {
        get { return _objetivosEspecificosRespuesta2; }
        set { _objetivosEspecificosRespuesta2 = value; }
    }

    private string _objetivosEspecificosRespuesta3;

    public string ObjetivosEspecificosRespuesta3
    {
        get { return _objetivosEspecificosRespuesta3; }
        set { _objetivosEspecificosRespuesta3 = value; }
    }

    private string _objetivosEspecificosRespuesta4;

    public string ObjetivosEspecificosRespuesta4
    {
        get { return _objetivosEspecificosRespuesta4; }
        set { _objetivosEspecificosRespuesta4 = value; }
    }

    private string _objetivosEspecificosRespuesta5;

    public string ObjetivosEspecificosRespuesta5
    {
        get { return _objetivosEspecificosRespuesta5; }
        set { _objetivosEspecificosRespuesta5 = value; }
    }

    private string _resultadoEsperadoRespuesta1;

    public string ResultadoEsperadoRespuesta1
    {
        get { return _resultadoEsperadoRespuesta1; }
        set { _resultadoEsperadoRespuesta1 = value; }
    }

    private string _resultadoEsperadoRespuesta2;

    public string ResultadoEsperadoRespuesta2
    {
        get { return _resultadoEsperadoRespuesta2; }
        set { _resultadoEsperadoRespuesta2 = value; }
    }

    private string _resultadoEsperadoRespuesta3;

    public string ResultadoEsperadoRespuesta3
    {
        get { return _resultadoEsperadoRespuesta3; }
        set { _resultadoEsperadoRespuesta3 = value; }
    }

    private string _resultadoEsperadoRespuesta4;

    public string ResultadoEsperadoRespuesta4
    {
        get { return _resultadoEsperadoRespuesta4; }
        set { _resultadoEsperadoRespuesta4 = value; }
    }

    private string _resultadoEsperadoRespuesta5;

    public string ResultadoEsperadoRespuesta5
    {
        get { return _resultadoEsperadoRespuesta5; }
        set { _resultadoEsperadoRespuesta5 = value; }
    }

    private double _indicadorMetaRespuesta1;

    public double IndicadorMetaRespuesta1
    {
        get { return _indicadorMetaRespuesta1; }
        set { _indicadorMetaRespuesta1 = value; }
    }

    private double _indicadorMetaRespuesta2;

    public double IndicadorMetaRespuesta2
    {
        get { return _indicadorMetaRespuesta2; }
        set { _indicadorMetaRespuesta2 = value; }
    }

    private double _indicadorMetaRespuesta3;

    public double IndicadorMetaRespuesta3
    {
        get { return _indicadorMetaRespuesta3; }
        set { _indicadorMetaRespuesta3 = value; }
    }

    private double _indicadorMetaRespuesta4;

    public double IndicadorMetaRespuesta4
    {
        get { return _indicadorMetaRespuesta4; }
        set { _indicadorMetaRespuesta4 = value; }
    }

    private string _indicadorMetaRespuesta5;

    public string IndicadorMetaRespuesta5
    {
        get { return _indicadorMetaRespuesta5; }
        set { _indicadorMetaRespuesta5 = value; }
    }

    private double _gradoCumplimientoRespuesta1;

    public double GradoCumplimientoRespuesta1
    {
        get { return _gradoCumplimientoRespuesta1; }
        set { _gradoCumplimientoRespuesta1 = value; }
    }

    private double _gradoCumplimientoRespuesta2;

    public double GradoCumplimientoRespuesta2
    {
        get { return _gradoCumplimientoRespuesta2; }
        set { _gradoCumplimientoRespuesta2 = value; }
    }

    private double _gradoCumplimientoRespuesta3;

    public double GradoCumplimientoRespuesta3
    {
        get { return _gradoCumplimientoRespuesta3; }
        set { _gradoCumplimientoRespuesta3 = value; }
    }

    private double _gradoCumplimientoRespuesta4;

    public double GradoCumplimientoRespuesta4
    {
        get { return _gradoCumplimientoRespuesta4; }
        set { _gradoCumplimientoRespuesta4 = value; }
    }

    private double _gradoCumplimientoRespuesta5;

    public double GradoCumplimientoRespuesta5
    {
        get { return _gradoCumplimientoRespuesta5; }
        set { _gradoCumplimientoRespuesta5 = value; }
    }

    private string _mediosDeVerificacionRespusta1;

    public string MediosDeVerificacionRespuesta1
    {
        get { return _mediosDeVerificacionRespusta1; }
        set { _mediosDeVerificacionRespusta1 = value; }
    }

    private string _mediosDeVerificacionRespusta2;

    public string MediosDeVerificacionRespuesta2
    {
        get { return _mediosDeVerificacionRespusta2; }
        set { _mediosDeVerificacionRespusta2 = value; }
    }

    private string _mediosDeVerificacionRespusta3;

    public string MediosDeVerificacionRespuesta3
    {
        get { return _mediosDeVerificacionRespusta3; }
        set { _mediosDeVerificacionRespusta3 = value; }
    }

    private string _mediosDeVerificacionRespusta4;

    public string MediosDeVerificacionRespuesta4
    {
        get { return _mediosDeVerificacionRespusta4; }
        set { _mediosDeVerificacionRespusta4 = value; }
    }

    private string _mediosDeVerificacionRespusta5;

    public string MediosDeVerificacionRespuesta5
    {
        get { return _mediosDeVerificacionRespusta5; }
        set { _mediosDeVerificacionRespusta5 = value; }
    }

    private string _observaciones1;

    public string Observaciones1
    {
        get { return _observaciones1; }
        set { _observaciones1 = value; }
    }

    private string _observaciones2;

    public string Observaciones2
    {
        get { return _observaciones2; }
        set { _observaciones2 = value; }
    }

    private string _observaciones3;

    public string Observaciones3
    {
        get { return _observaciones3; }
        set { _observaciones3 = value; }
    }

    private string _observaciones4;

    public string Observaciones4
    {
        get { return _observaciones4; }
        set { _observaciones4 = value; }
    }

    private string _observaciones5;

    public string Observaciones5
    {
        get { return _observaciones5; }
        set { _observaciones5 = value; }
    }

    private string _hitosAccionesComprometidasNoRealizadas1;

    public string HitosAccionesComprometidasNoRealizadas1
    {
        get { return _hitosAccionesComprometidasNoRealizadas1; }
        set { _hitosAccionesComprometidasNoRealizadas1 = value; }
    }

    private string _hitosAccionesComprometidasNoRealizadas2;

    public string HitosAccionesComprometidasNoRealizadas2
    {
        get { return _hitosAccionesComprometidasNoRealizadas2; }
        set { _hitosAccionesComprometidasNoRealizadas2 = value; }
    }

    private string _hitosAccionesComprometidasNoRealizadas3;

    public string HitosAccionesComprometidasNoRealizadas3
    {
        get { return _hitosAccionesComprometidasNoRealizadas3; }
        set { _hitosAccionesComprometidasNoRealizadas3 = value; }
    }

    private string _hitosAccionesComprometidasNoRealizadas4;

    public string HitosAccionesComprometidasNoRealizadas4
    {
        get { return _hitosAccionesComprometidasNoRealizadas4; }
        set { _hitosAccionesComprometidasNoRealizadas4 = value; }
    }

    private string _hitosAccionesComprometidasNoRealizadas5;

    public string HitosAccionesComprometidasNoRealizadas5
    {
        get { return _hitosAccionesComprometidasNoRealizadas5; }
        set { _hitosAccionesComprometidasNoRealizadas5 = value; }
    }

    private string _hitosAccionesComprometidasNoRealizadas6;

    public string HitosAccionesComprometidasNoRealizadas6
    {
        get { return _hitosAccionesComprometidasNoRealizadas6; }
        set { _hitosAccionesComprometidasNoRealizadas6 = value; }
    }

    private string _observacionesSobreActividades1;

    public string ObservacionesSobreActividades1
    {
        get { return _observacionesSobreActividades1; }
        set { _observacionesSobreActividades1 = value; }
    }

    private string _observacionesSobreActividades2;

    public string ObservacionesSobreActividades2
    {
        get { return _observacionesSobreActividades2; }
        set { _observacionesSobreActividades2 = value; }
    }

    private string _observacionesSobreActividades3;

    public string ObservacionesSobreActividades3
    {
        get { return _observacionesSobreActividades3; }
        set { _observacionesSobreActividades3 = value; }
    }

    private string _observacionesSobreActividades4;

    public string ObservacionesSobreActividades4
    {
        get { return _observacionesSobreActividades4; }
        set { _observacionesSobreActividades4 = value; }
    }

    private string _observacionesSobreActividades5;

    public string ObservacionesSobreActividades5
    {
        get { return _observacionesSobreActividades5; }
        set { _observacionesSobreActividades5 = value; }
    }

    private string _observacionesSobreActividades6;

    public string ObservacionesSobreActividades6
    {
        get { return _observacionesSobreActividades6; }
        set { _observacionesSobreActividades6 = value; }
    }
    
    #endregion

    #region Sujeto de Atención
    private string _causalesDeIngreso1;

    public string CausalesDeIngreso1
    {
        get { return _causalesDeIngreso1; }
        set { _causalesDeIngreso1 = value; }
    }

    private double _porcentajeCausal1;

    public double PorcentajeCausal1
    {
        get { return _porcentajeCausal1; }
        set { _porcentajeCausal1 = value; }
    }
    

    private string _causalesDeIngreso2;

    public string CausalesDeIngreso2
    {
        get { return _causalesDeIngreso2; }
        set { _causalesDeIngreso2 = value; }
    }

    private double _porcentajeCausal2;

    public double PorcentajeCausal2
    {
        get { return _porcentajeCausal2; }
        set { _porcentajeCausal2 = value; }
    }

    private string _causalesDeIngreso3;

    public string CausalesDeIngreso3
    {
        get { return _causalesDeIngreso3; }
        set { _causalesDeIngreso3 = value; }
    }

    private double _porcentajeCausal3;

    public double PorcentajeCausal3
    {
        get { return _porcentajeCausal3; }
        set { _porcentajeCausal3 = value; }
    }

    private string _causalesDeIngreso4;

    public string CausalesDeIngreso4
    {
        get { return _causalesDeIngreso4; }
        set { _causalesDeIngreso4 = value; }
    }

    private double _porcentajeCausal4;

    public double PorcentajeCausal4
    {
        get { return _porcentajeCausal4; }
        set { _porcentajeCausal4 = value; }
    }

    private string _viasDeIngreso1;

    public string ViasDeIngreso1
    {
        get { return _viasDeIngreso1; }
        set { _viasDeIngreso1 = value; }
    }

    private string _viasDeIngreso2;

    public string ViasDeIngreso2
    {
        get { return _viasDeIngreso2; }
        set { _viasDeIngreso2 = value; }
    }

    private string _viasDeIngreso3;

    public string ViasDeIngreso3
    {
        get { return _viasDeIngreso3; }
        set { _viasDeIngreso3 = value; }
    }

    //Archivos Adjuntos
    private string _rutaArchivoResumenMensualDeListaEspera;

    public string RutaArchivoResumenMensualDeListaEspera
    {
        get { return _rutaArchivoResumenMensualDeListaEspera; }
        set { _rutaArchivoResumenMensualDeListaEspera = value; }
    }

    private string _rutaArchivoNumeroNNAEgresadosAño;

    public string RutaArchivoNumeroNNAEgresadosAño
    {
        get { return _rutaArchivoNumeroNNAEgresadosAño; }
        set { _rutaArchivoNumeroNNAEgresadosAño = value; }
    }

    private string _rutaArchivoNominaMayores18Años;

    public string RutaArchivoNominaMayores18Años
    {
        get { return _rutaArchivoNominaMayores18Años; }
        set { _rutaArchivoNominaMayores18Años = value; }
    }
    
    
    
    
    
    #endregion

    #region Diseño de Intervención 1
    private string _descripcionMetodologia;

    public string DescripcionMetodologia
    {
        get { return _descripcionMetodologia; }
        set { _descripcionMetodologia = value; }
    }

    private string _rutaArchivoDescripcionMetodologia;

    public string RutaArchivoDescripcionMetodologia
    {
        get { return _rutaArchivoDescripcionMetodologia; }
        set { _rutaArchivoDescripcionMetodologia = value; }
    }

    private string _enfoquesTranversalesDeTrabajo1;

    public string EnfoquesTranversalesDeTrabajo1
    {
        get { return _enfoquesTranversalesDeTrabajo1; }
        set { _enfoquesTranversalesDeTrabajo1 = value; }
    }

    private string _accionesTecnicasEstrategiasEnfoques1;

    public string AccionesTecnicasEstrategiasEnfoques1
    {
        get { return _accionesTecnicasEstrategiasEnfoques1; }
        set { _accionesTecnicasEstrategiasEnfoques1 = value; }
    }
    

    private string _enfoquesTranversalesDeTrabajo2;

    public string EnfoquesTranversalesDeTrabajo2
    {
        get { return _enfoquesTranversalesDeTrabajo2; }
        set { _enfoquesTranversalesDeTrabajo2 = value; }
    }

    private string _accionesTecnicasEstrategiasEnfoques2;

    public string AccionesTecnicasEstrategiasEnfoques2
    {
        get { return _accionesTecnicasEstrategiasEnfoques2; }
        set { _accionesTecnicasEstrategiasEnfoques2 = value; }
    }

    private string _enfoquesTranversalesDeTrabajo3;

    public string EnfoquesTranversalesDeTrabajo3
    {
        get { return _enfoquesTranversalesDeTrabajo3; }
        set { _enfoquesTranversalesDeTrabajo3 = value; }
    }

    private string _accionesTecnicasEstrategiasEnfoques3;

    public string AccionesTecnicasEstrategiasEnfoques3
    {
        get { return _accionesTecnicasEstrategiasEnfoques3; }
        set { _accionesTecnicasEstrategiasEnfoques3 = value; }
    }

    private string _enfoquesTranversalesDeTrabajo4;

    public string EnfoquesTranversalesDeTrabajo4
    {
        get { return _enfoquesTranversalesDeTrabajo4; }
        set { _enfoquesTranversalesDeTrabajo4 = value; }
    }

    private string _accionesTecnicasEstrategiasEnfoques4;

    public string AccionesTecnicasEstrategiasEnfoques4
    {
        get { return _accionesTecnicasEstrategiasEnfoques4; }
        set { _accionesTecnicasEstrategiasEnfoques4 = value; }
    }

    private bool _cuentaConInstrumentosPropiosEnfoquesPlanteados;

    public bool CuentaConInstrumentosPropiosEnfoquesPlanteados
    {
        get { return _cuentaConInstrumentosPropiosEnfoquesPlanteados; }
        set { _cuentaConInstrumentosPropiosEnfoquesPlanteados = value; }
    }

    private string _instrumentosPropiosEnfoquesPlanteados;

    public string InstrumentosPropiosEnfoquesPlanteados
    {
        get { return _instrumentosPropiosEnfoquesPlanteados; }
        set { _instrumentosPropiosEnfoquesPlanteados = value; }
    }
    
    
    #endregion

    #region Diseño de Intervención 2
    private string _flujoDeAtencion;

    public string FlujoDeAtencion
    {
        get { return _flujoDeAtencion; }
        set { _flujoDeAtencion = value; }
    }

    private string _rutaArchivoFlujoDeAtencion;

    public string RutaArchivoFlujoDeAtencion
    {
        get { return _rutaArchivoFlujoDeAtencion; }
        set { _rutaArchivoFlujoDeAtencion = value; }
    }

    private string _vrMencionaActoresyProcedimientos;

    public string VRMencionActoresyProcedimientos
    {
        get { return _vrMencionaActoresyProcedimientos; }
        set { _vrMencionaActoresyProcedimientos = value; }
    }


    private string _rutaArchivoVRMencionaActoresyProcedimientosDeDerivacion;

    public string RutaArchivoVRMencionaActoresyProcedimientosDeDerivacion
    {
        get { return _rutaArchivoVRMencionaActoresyProcedimientosDeDerivacion; }
        set { _rutaArchivoVRMencionaActoresyProcedimientosDeDerivacion = value; }
    }

    private string _vrDescripcionEstrategiasTrabajo;

    public string VRDescripcionEstrategiasTrabajo
    {
        get { return _vrDescripcionEstrategiasTrabajo; }
        set { _vrDescripcionEstrategiasTrabajo = value; }
    }

    private string _rutaArchivoVRDescripcionEstrategiasTrabajo;

    public string RutaArchivoVRDescripcionEstrategiasTrabajo
    {
        get { return _rutaArchivoVRDescripcionEstrategiasTrabajo; }
        set { _rutaArchivoVRDescripcionEstrategiasTrabajo = value; }
    }

    private string _describaVREstrategiasCoordinacionTribunalesFamilia;

    public string VRDescribaEstrategiasCoordinacionEfectivaTribunalesFamilia
    {
        get { return _describaVREstrategiasCoordinacionTribunalesFamilia; }
        set { _describaVREstrategiasCoordinacionTribunalesFamilia = value; }
    }

    private string _rutaArchivoDescribaEstrategiasCoordinacionEfectivaTribunalesFamilia;

    public string RutaArchivoDescribaEstrategiasCoordinacionEfectivaTribunalesFamilia
    {
        get { return _rutaArchivoDescribaEstrategiasCoordinacionEfectivaTribunalesFamilia; }
        set { _rutaArchivoDescribaEstrategiasCoordinacionEfectivaTribunalesFamilia = value; }
    }
    
    #endregion

    #region Integración de Variables Transversales
    private string _planCoordinacionConGarantesArticulacionTerritorial1;

    public string PlanCoordinacionConGarantesArticulacionTerritorial1
    {
        get { return _planCoordinacionConGarantesArticulacionTerritorial1; }
        set { _planCoordinacionConGarantesArticulacionTerritorial1 = value; }
    }

    private string _planCoordinacionConGarantesArticulacionTerritorial2;

    public string PlanCoordinacionConGarantesArticulacionTerritorial2
    {
        get { return _planCoordinacionConGarantesArticulacionTerritorial2; }
        set { _planCoordinacionConGarantesArticulacionTerritorial2 = value; }
    }

    private string _autoevaluacion;

    public string AutoEvaluacion
    {
        get { return _autoevaluacion; }
        set { _autoevaluacion = value; }
    }

    private string _capacitacion;

    public string Capacitacion
    {
        get { return _capacitacion; }
        set { _capacitacion = value; }
    }

    private string _autoCuidadoDeEquipo;

    public string AutoCuidadoDeEquipo
    {
        get { return _autoCuidadoDeEquipo; }
        set { _autoCuidadoDeEquipo = value; }
    }



    
    #endregion

    #region Recursos Humanos
    private bool _dotacionPermaneceIgualComprometida;

    public bool DotacionPermaneceIgualComprometida
    {
        get { return _dotacionPermaneceIgualComprometida; }
        set { _dotacionPermaneceIgualComprometida = value; }
    }

    private string _dotacionJustificacionRespuesta;

    public string DotacionJustificacionRespuesta
    {
        get { return _dotacionJustificacionRespuesta; }
        set { _dotacionJustificacionRespuesta = value; }
    }

    private bool _jornadaHorasProfesionalesIgualComprometida;

    public bool JornadaHorasProfesionalesIgualComprometida
    {
        get { return _jornadaHorasProfesionalesIgualComprometida; }
        set { _jornadaHorasProfesionalesIgualComprometida = value; }
    }


    private string _jornadaJustificacionRespuesta;

    public string JornadaJustificacionRespuesta
    {
        get { return _jornadaJustificacionRespuesta; }
        set { _jornadaJustificacionRespuesta = value; }
    }


    private bool _rotacion;

    public bool Rotacion
    {
        get { return _rotacion; }
        set { _rotacion = value; }
    }

    private string _rotacionJustificacion;

    public string RotacionJustificacion
    {
        get { return _rotacionJustificacion; }
        set { _rotacionJustificacion = value; }
    }

    private string _descripcionOrganizacionEquipoDistrubucionFunciones;

    public string DescripcionOrganizacionEquipoDistribucionFunciones
    {
        get { return _descripcionOrganizacionEquipoDistrubucionFunciones; }
        set { _descripcionOrganizacionEquipoDistrubucionFunciones = value; }
    }

    private string _RRHHobservaciones;

    public string RRHHObservaciones
    {
        get { return _RRHHobservaciones; }
        set { _RRHHobservaciones = value; }
    }
    

    
    #endregion

    #region Recursos Materiales e Infraestructura

    private bool _checkSuperiorRM;

    public bool CheckSuperiorRM
    {
        get { return _checkSuperiorRM; }
        set { _checkSuperiorRM = value; }
    }

    private string _justificacionSuperiorRM;

    public string JustificacionSuperiorRM
    {
        get { return _justificacionSuperiorRM; }
        set { _justificacionSuperiorRM = value; }
    }

    private bool _checkInferiorRM;

    public bool CheckInferiorRM
    {
        get { return _checkInferiorRM; }
        set { _checkInferiorRM = value; }
    }

    private string _justificacionInferiorRM;

    public string JustificacionInferiorRM
    {
        get { return _justificacionInferiorRM; }
        set { _justificacionInferiorRM = value; }
    }

    private bool _checkIgualRM;

    public bool CheckIgualRM
    {
        get { return _checkIgualRM; }
        set { _checkIgualRM = value; }
    }

    private string _justificacionIgualRM;

    public string JustificacionIgualRM
    {
        get { return _justificacionIgualRM; }
        set { _justificacionIgualRM = value; }
    }

    private string _observacionesRMI;

    public string ObservacionesRMI
    {
        get { return _observacionesRMI; }
        set { _observacionesRMI = value; }
    }
    
    
    


    #endregion

    #region Propuesta para el siguiente año de ejecución
    private string _metodologiaProximoAño;

    public string MetodologiaProximoAño
    {
        get { return _metodologiaProximoAño; }
        set { _metodologiaProximoAño = value; }
    }
    
    
    
    #endregion

    #endregion
    public AutoevaluacionPMG()
	{
   
	}


    //private int guardarAutoevaluacionPMG(List<SqlParameter> parametros)
    //{
    //    int resultado = 0;
    //    SqlCommand sqlc = new SqlCommand("InsertUpdateAutoevaluacionPMG", conn);

    //    foreach (SqlParameter par in parametros)
    //    {
    //        sqlc.Parameters.Add(par.ParameterName, par.SqlDbType).Value = par.Value;
    //    }

    //    resultado = Convert.ToInt32(sqlc.ExecuteScalar());

    //    return resultado;
    //}

    //private int guardarRespuestasAutoevaluacionPMG(List<SqlParameter> parametros)
    //{
    //    int resultado = 0;

    //    SqlCommand sqlc = new SqlCommand("InsertUpdateRespuestasAutoevaluacionPMG", conn);

    //    foreach (SqlParameter par in parametros)
    //    {
    //        sqlc.Parameters.Add(par.ParameterName, par.SqlDbType).Value = par.Value;
    //    }

    //    return resultado;
    //}
}   