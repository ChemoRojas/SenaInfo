<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_menu_colganteOld.ascx.cs" Inherits="SenainfoSdk.UI.C_menu_colganteOld" %>

<script>
    (function ($) {
        $(document).ready(function () {
            $('ul.dropdown-menu [data-toggle=dropdown]').on('click', function (event) {
                event.preventDefault();
                event.stopPropagation();
                $(this).parent().siblings().removeClass('open');
                $(this).parent().toggleClass('open');
            });
        });
    })(jQuery);
    </script>
    <style>

.dropdown-submenu{position:relative;}
.dropdown-submenu>.dropdown-menu{top:0;left:100%;margin-top:-6px;margin-left:-1px;-webkit-border-radius:0 6px 6px 6px;-moz-border-radius:0 6px 6px 6px;border-radius:0 6px 6px 6px;}
.dropdown-submenu>a:after{display:block;content:" ";float:right;width:0;height:0;border-color:transparent;border-style:solid;border-width:5px 0 5px 5px;border-left-color:#cccccc;margin-top:5px;margin-right:-10px;}
.dropdown-submenu:hover>a:after{border-left-color:#555;}
.dropdown-submenu.pull-left{float:none;}.dropdown-submenu.pull-left>.dropdown-menu{left:-100%;margin-left:10px;-webkit-border-radius:6px 0 6px 6px;-moz-border-radius:6px 0 6px 6px;border-radius:6px 0 6px 6px;}

    </style>

    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a id="A1" runat="server" class="navbar-brand" href="~/index.aspx">
            <img id="Img1" src="~/images/logo-sename-cdn_163x55.png" runat="server" alt="">
          </a>
        </div>

        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
          <!-- Home: Siempre se muestra -->
            <li class="active" id="home" runat="server"><a id="A2" href="~/index.aspx" runat="server"><span class="glyphicon glyphicon-home" aria-hidden="true"></span> Inicio</a></li>

            <li class="dropdown" id="menu_menu" runat="server">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Menu <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span></a>
              <ul class="dropdown-menu" role="menu">
                <%--<li><a href="#"></a></li>--%>

                <!-- MODULO: Institución/Proyecto -->
                <li id="i_institucion_proyecto" runat="server" visible="true" class="dropdown dropdown-submenu">
                  <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Institución/Proyecto</a>
                  <ul class="dropdown-menu">
                    <li id="ii_instituciones" runat="server" visible="true"><a id="A3" runat="server" href="~/mod_instituciones/reg_instituciones.aspx">Instituciones</a></li>
                    <li id="ii_trabajadores" runat="server" visible="true"><a id="A4" runat="server" href="~/mod_instituciones/reg_trabajadores.aspx">Trabajadores</a></li>
                    <li id="ii_inmuebles" runat="server" visible="true"><a id="A5" runat="server" href="~/mod_instituciones/reg_inmuebles.aspx">Inmuebles</a></li>
                    <li class="dropdown dropdown-submenu">
                        <a id="ii_proyectos" runat="server" visible="true" tabindex="-1" href="#"  class="dropdown-toggle" data-toggle="dropdown">Proyectos</a>
                        <ul class="dropdown-menu">
                            <li id="iii_relacionar_trabajador_proyecto" runat="server" visible="true"><a id="A6" runat="server" href="~/mod_instituciones/reg_trabajadoresproy.aspx">Relacionar Trabajador al Proyecto</a></li>
                            <li id="iii_relacionar_inmueble_proyecto" runat="server" visible="true"><a id="A7" runat="server" href="~/mod_instituciones/reg_inmueblesproy.aspx">Relacionar Inmueble al Proyecto</a></li>
                            <li id="iii_eventos_del_proyecto" runat="server" visible="true"><a id="A8" runat="server" href="~/mod_instituciones/reg_eventosproy.aspx">Eventos del Proyecto</a></li>
                            <li class="dropdown dropdown-submenu">
                                <a id="iii_rendicion_de_cuentas" runat="server" visible="true" tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Rendición de Cuentas</a>
                                <ul class="dropdown-menu">
                                    <%--<li id="iv_registro_ingreso" runat="server" visible="true"><a runat="server" href="~/mod_instituciones/Reg_Ingresos.aspx">Registro Ingreso</a></li>
                                    <li id="iv_registro_egreso" runat="server" visible="true"><a runat="server" href="~/mod_instituciones/Reg_egresos.aspx">Registro Egreso</a></li>
                                    <li id="iv_rendicion_cuentas" runat="server" visible="true"><a runat="server" href="~/mod_instituciones/Reg_Rendicion.aspx">Rendición de Cuentas</a></li>
                                    <li id="iv_registro_ingreso_instituciones" runat="server" visible="true"><a runat="server" href="~/mod_instituciones/Reg_Ingresos_Instituciones.aspx">Registro Ingresos Instituciones</a></li>
                                    <li id="iv_registro_egresos_instituciones" runat="server" visible="true"><a runat="server" href="~/mod_instituciones/Reg_Egresos_Instituciones.aspx">Registro Egresos Instituciones</a></li>
                                    <li id="iv_rendicion_cuentas_instituciones" runat="server" visible="true"><a runat="server" href="~/mod_instituciones/Reg_Rendicion_Instituciones.aspx">Rendición de Cuentas de Instituciones</a></li>--%>
                                    <li id="iv_registro_ingreso" runat="server" visible="true"><a id="A9" runat="server" href="~/mod_instituciones/RendicionDeCuenta.aspx?f=UmVnX0luZ3Jlc29z">Registro Ingreso</a></li>
                                    <li id="iv_registro_egreso" runat="server" visible="true"><a id="A10" runat="server" href="~/mod_instituciones/RendicionDeCuenta.aspx?f=UmVnX2VncmVzb3M=">Registro Egreso</a></li>
                                    <li id="iv_rendicion_cuentas" runat="server" visible="true"><a id="A11" runat="server" href="~/mod_instituciones/RendicionDeCuenta.aspx?f=UmVnX1JlbmRpY2lvbg==">Rendición de Cuentas</a></li>
                                    <li id="iv_registro_ingreso_instituciones" runat="server" visible="true"><a id="A12" runat="server" href="~/mod_instituciones/RendicionDeCuenta.aspx?f=UmVnX0luZ3Jlc29zX0luc3RpdHVjaW9uZXM=">Registro Ingresos Instituciones</a></li>
                                    <li id="iv_registro_egresos_instituciones" runat="server" visible="true"><a id="A13" runat="server" href="~/mod_instituciones/RendicionDeCuenta.aspx?f=UmVnX0VncmVzb3NfSW5zdGl0dWNpb25lcw==">Registro Egresos Instituciones</a></li>
                                    <li id="iv_rendicion_cuentas_instituciones" runat="server" visible="true"><a id="A14" runat="server" href="~/mod_instituciones/RendicionDeCuenta.aspx?f=UmVnX1JlbmRpY2lvbl9JbnN0aXR1Y2lvbmVz">Rendición de Cuentas de Instituciones</a></li>
                                </ul>
                            </li>
							<li id="iii_proyectos" runat="server" visible="true"><a id="A15" runat="server" href="~/mod_proyectos/proyectoreferente.aspx">Proyectos</a></li>
                        </ul>
                    </li>
                    <li id="ii_resoluciones" runat="server" visible="true"><a id="A16" runat="server" href="~/mod_proyectos/proyectoadjudicadoenejecucion.aspx">Resoluciones</a></li>
                  </ul>
                </li>

                <!-- MODULO: Niños -->
                <li id="i_ninos" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Niños</a>
                    <ul class="dropdown-menu">
                        <li id="ii_ingreso_del_nino" runat="server" visible="true"><a id="A17" runat="server" href="~/mod_ninos/ninos_index.aspx">Ingreso del Niño</a></li>
                        <li id="ii_datos_de_gestion" runat="server" visible="true"><a id="A18" runat="server" href="~/mod_ninos/DatosdeGestion.aspx">Datos de Gestión</a></li>
                        <li id="ii_diagnostico_del_nino" runat="server" visible="true"><a id="A19" runat="server" href="~/mod_ninos/ninos_diagnosticoninos.aspx">Diagnóstico del Niño</a></li>
                        <li class="dropdown dropdown-submenu">
                            <a id="ii_planes_de_intervencion" runat="server" visible="true" tabindex="-1" class="dropdown-toggle" data-toggle="dropdown">Planes de Intervención</a>
                            <ul class="dropdown-menu">
                                <li id="iii_nuevo_plan_intervencion" runat="server" visible="true"><a id="A20" runat="server" href="~/mod_ninos/plan_intervencion_new.aspx">Nuevo Plan de Intervención</a></li>
                                <li id="iii_gestionar_plan_intervencion" runat="server" visible="true"><a id="A21" runat="server" href="~/mod_ninos/pi_gestion.aspx">Gestionar Plan de Intervención</a></li>
                            </ul>
                        </li>
                        <li id="ii_egresos" runat="server" visible="true"><a id="A22" runat="server" href="~/mod_ninos/ninos_egreso.aspx">Egresos</a></li>
                        <li id="ii_cierre_mes_informacion_ninos" runat="server" visible="true"><a id="A23" runat="server" href="~/mod_ninos/cierre_movmensual.aspx">Cierre de Mes, Información de Niños</a></li>
                        <li id="ii_ninos_relacionados" runat="server" visible="false"><a id="A24" runat="server" href="~/mod_ninos/ninos_relacionados.aspx">Niños Relacionados</a></li>
                        <li id="ii_ninos_visitados" runat="server" visible="true"><a id="A25" runat="server" href="~/mod_ninos/ninos_visitados.aspx">Niños Visitados</a></li>
                        <li id="ii_direccion_ninos" runat="server" visible="true"><a id="A26" runat="server" href="~/mod_ninos/ninos_direccionnino.aspx">Dirección Niños</a></li>
                        <li id="ii_muestra_adn" runat="server" visible="true"><a id="A27" runat="server" href="~/mod_ninos/ninos_adn.aspx">Muestra ADN</a></li>
                        <li id="ii_infracciones_disciplinarias" runat="server" visible="true"><a id="A28" runat="server" href="~/mod_faltas/registro_faltas.aspx">Infracciones Disciplinarias</a></li>
                    </ul>
                </li>

                <!-- MODULO: Consultar Información Reportes -->
                <li id="i_consultar_informacion_reportes" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Consultar Información Reportes</a>
                    <ul class="dropdown-menu">
                        <li id="ii_rpt_instituciones" runat="server" visible="true"><a id="A29" runat="server" href="~/mod_reportes/Rep_instituciones.aspx">Instituciones</a></li>
                        <li id="ii_rpt_proyectos" runat="server" visible="true"><a id="A30" runat="server" href="~/mod_reportes/Rep_proyectos.aspx">Proyectos</a></li>
                        <li id="ii_rpt_resoluciones" runat="server" visible="true"><a id="A31" runat="server" href="~/mod_reportes/Rep_resoluciones.aspx">Resoluciones</a></li>
                        <li id="ii_rpt_catastro" runat="server" visible="true"><a id="A32" runat="server" href="~/mod_reportes/Rep_Catastro.aspx">Catastro</a></li>
                        <li id="ii_rpt_eventos_proyecto" runat="server" visible="true"><a id="A33" runat="server" href="~/mod_reportes/Rep_EvProyecto.aspx">Eventos del Proyecto</a></li>
                        <li id="ii_rpt_ninos" runat="server" visible="true"><a id="A34" runat="server" href="~/mod_reportes/Rep_ninos.aspx">Niños</a></li>
                        <li id="ii_rpt_caracteristicas_adoptabilidad" runat="server" visible="false"><a id="A35" runat="server" href="~/mod_reportes/Rep_ninosAdoptabilidad.aspx">Caracteristicas de Adoptabilidad</a></li>
                        <li id="ii_rpt_plan_intervencion" runat="server" visible="true"><a id="A36" runat="server" href="~/mod_reportes/Rep_eventos.aspx">Plan de Intervención</a></li>
                        <li id="ii_rpt_lrpa" runat="server" visible="true"><a id="A37" runat="server" href="~/mod_reportes/Rep_ReportesLRPA.aspx">LRPA</a></li>
                        <li id="ii_rpt_ninos_visitados" runat="server" visible="true"><a id="A38" runat="server" href="~/mod_reportes/Rep_ninosvisitados.aspx">Niños Visitados</a></li>
                        <li id="ii_rpt_datos_gestion_ninos" runat="server" visible="true"><a id="A39" runat="server" href="~/mod_reportes/Index_ReporteDatosGestion.aspx">Datos de Gestión Niños</a></li>
                        <li id="ii_rpt_diagnosticos_ninos" runat="server" visible="true"><a id="A40" runat="server" href="~/mod_reportes/Rep_Diag_Ninos.aspx">Diagnósticos Niños</a></li>
                        <li id="ii_rpt_ninos_deteccion_precoz" runat="server" visible="true"><a id="A41" runat="server" href="~/mod_reportes/Rep_NinosDeteccionPrecoz.aspx">Niños Detección Precoz</a></li>
                        <li id="ii_rpt_monitoreo_indicadores" runat="server" visible="true"><a id="A42" runat="server" href="~/mod_reportes/Rep_MonitoreoIndicadores.aspx">Monitoreo de Indicadores</a></li>
                        <li id="ii_rpt_lista_espera" runat="server" visible="true"><a id="A43" runat="server" href="~/mod_reportes/Rep_ListadeEspera.aspx">Lista de Espera</a></li>
                        <li id="ii_rpt_reporte_estadisticos_cdc" runat="server" visible="true"><a id="A44" runat="server" href="~/mod_reportes/Rep_Estadistico.aspx">Reporte Estadisticos (CDC)</a></li>
                        <li id="ii_rpt_historial_nino" runat="server" visible="true"><a id="A45" runat="server" href="~/mod_reportes/Rep_historial.aspx">Historial del Niño</a></li>
                        <li id="ii_rpt_trabajadores_usuarios" runat="server" visible="true"><a id="A46" runat="server" href="~/mod_reportes/Rep_TrabajadorUsuario.aspx">Trabajadores - Usuarios</a></li>
                        <li id="ii_rpt_reporte_trabajadores" runat="server" visible="true"><a id="A47" runat="server" href="~/mod_reportes/Rep_TrabajadoresRut.aspx">Reporte Trabajadores</a></li>
                    </ul>
                </li>

                <!-- MODULO: Recepción Documentos -->
                <li id="i_recepcion_documentos" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Recepción Documentos</a>
                    <ul class="dropdown-menu">
                        <li id="ii_recepcion_resumen_atencion" runat="server" visible="true"><a id="A48" runat="server" href="~/mod_recepcion/recep_resatencion.aspx">Recepción Resumen de Atención</a></li>
                        <li id="ii_recepcion_rendiciones_cuentas" runat="server" visible="true"><a id="A49" runat="server" href="~/mod_recepcion/Recep_RendCuenta.aspx">Recepción Rendiciones de Cuentas</a></li>
                        <li id="ii_retencion_pago_subvencion" runat="server" visible="false"><a id="A50" runat="server" href="#">Retención de Pago de Subvención</a></li>
                        <li id="ii_listar_liquidaciones_pago" runat="server" visible="false"><a id="A51" runat="server" href="#">Listar Liquidaciones de Pago</a></li>
                    </ul>
                </li>

                <!-- MODULO: Manuales -->
                <li id="i_manuales" runat="server" visible="false"><a id="A52" runat="server" href="~/manuales/index.htm">Manuales</a></li>

                <!-- MODULO: Mesa de Ayuda -->
                <li id="i_mesa_de_ayuda" runat="server" visible="false" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Mesa de Ayuda</a>
                    <ul class="dropdown-menu">
                        <li id="ii_trabajadores_obtencion_usuarios_claves" runat="server" visible="false"><a id="A53" runat="server" href="#">Trabajadores Obtención Usuarios y Claves</a></li>
                        <li id="ii_rectificacion_de_identidad" runat="server" visible="true"><a id="A54" runat="server" href="~/mod_mesa/mesa_rectificacionidentidad.aspx">Rectificación de Identidad</a></li>
                        <li id="ii_regenerar_cierre" runat="server" visible="false"><a id="A55" runat="server" href="~/mod_ninos/cierre_registroatencion.aspx">Regenerar Cierre</a></li>
                        <li id="ii_mantenedor_ninos" runat="server" visible="false"><a id="A56" runat="server" href="#">Mantenedor de Niños</a></li>
                    </ul>
                </li>

                <!-- MODULO: Mantendores -->
                <li id="i_mantenedores" runat="server" visible="false"><a id="A57" runat="server" href="~/mod_mantenedores/index_mantenedores.aspx">Mantendores</a></li>

                <!-- MODULO: Coordinador Judicial -->
                <li id="i_coordinador_judicial" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Coordinador Judicial</a>
                    <ul class="dropdown-menu">
                        <li id="ii_coorjud_ingresar" runat="server" visible="true"><a id="A58" runat="server" href="~/mod_coordinadores/coordinadores_ingreso.aspx">Ingresar</a></li>
                        <li id="ii_coorjud_modificar" runat="server" visible="true"><a id="A59" runat="server" href="~/mod_coordinadores/New_CoordinadoresModif.aspx">Modificar</a></li>
                        <li id="ii_coorjud_reportes" runat="server" visible="true"><a id="A60" runat="server" href="~/mod_reportes/Rep_Informes_Coordinador.aspx">Reportes</a></li>
                        <li class="divider"></li>
                        <li><a id="A61" runat="server" target="_blank" href="~/links/INSTRUCTIVO-COORDINADORES.pdf">Instructivo</a></li>
                    </ul>
                </li>

             <!-- MODULO: SENAME Justicia Juvenil -->
                <li id="i_sename_lrpa" runat="server" visible="false"><a id="A62" runat="server" href="~/mod_jueces/Historial_Ninos_Jueces.aspx">SENAME LRPA</a></li>
                <li id="sename_justicia_juvenil" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">SENAME Justicia Juvenil</a>
                    <ul class="dropdown-menu">
                        <li id="ii_historico_lrpa" runat="server" visible="true"><a id="A63" runat="server" href="~/mod_jueces/Historial_Ninos_Jueces.aspx">Historico LRPA</a></li>
                        <li id="ii_defensoria" runat="server" visible="true"><a id="A64" runat="server" href="~/mod_jueces/Defensoria.aspx">Defensoría</a></li>
                        <li id="ii_nna_vigentes_djj" runat="server" visible="true"><a id="A65" runat="server" href="~/mod_jueces/NNAVigentesDJJ.aspx">NNA Vigentes DJJ</a></li>
                    </ul>
                </li>

                <!-- MODULO: SENAME PROTECCIÓN -->
                <li id="i_sename_proteccion" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">SENAME PROTECCIÓN</a>
                    <ul class="dropdown-menu">
                        <li id="ii_sename_proteccion" runat="server" visible="true"><a id="A74" runat="server" href="~/mod_jueces/Historial_Ninos_Jueces.aspx?Param01=1">Historico Protección</a></li>
                        <li id="ii_nna_vigentes_deprode" runat="server" visible="true"><a id="A75" runat="server" href="~/mod_jueces/NNAVigentesDEPRODE.aspx">NNA Vigentes DEPRODE</a></li>
                    </ul>
                </li>


                <!-- MODULO: REPORTE VACANTES -->
                <li id="i_reporte_vacantes" runat="server" visible="true"><a id="A66" runat="server" href="~/mod_reportes/Rep_ProyectosJueces.aspx">REPORTE VACANTES</a></li>

                <!-- MODULO: Mesa de Ayuda UPLAE -->
                <li id="i_mesa_de_ayuda_uplae" runat="server" visible="true"><a id ="A67" runat="server" href="~/mod_mesa/mesa_excepciones.aspx">Mesa de Ayuda UPLAE</a></li>

                <!-- MODULO: Analisis Casos -->
                <li id="li_analisiscasos" runat="server" visible="true"><a id ="A76" runat="server" href="~/mod_instituciones/AnalisisCasos.aspx">Analisis Casos</a></li>

                <!-- MODULO: SENAME Reporte Justicia Juvenil KVG-->
                <li id="i_reporte_lrpa" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Reporte Plan RPA</a>
                    <ul class="dropdown-menu">
                        <li id="ii_reporte_lrpa1" runat="server" visible="true"><a id="A80" target = "_blank" runat="server" href="https://cdn.senainfo.cl/pdf/cd/PlanRPA/reportabilidaddiaria_minju.pdf">Informe diario de intervenciones por cada joven por cada sanción</a></li>
                        <li id="ii_reporte_lrpa2" runat="server" visible="true"><a id="A81" target = "_blank" runat="server" href="https://cdn.senainfo.cl/pdf/cd/PlanRPA/reportabilidadegresos_minju.pdf">Informe quincenal de egreso</a></li>
                        <li id="ii_reporte_lrpa3" runat="server" visible="true"><a id="A82" target = "_blank" runat="server" href="https://cdn.senainfo.cl/pdf/cd/PlanRPA/reportabilidadeducacion_minju.pdf">Informe quincenal de incorporación y mantención escolar</a></li>
                        <li id="ii_reporte_lrpa4" runat="server" visible="true"><a id="A83" target = "_blank" runat="server" href="https://cdn.senainfo.cl/pdf/cd/PlanRPA/reportabilidadpii_minju.pdf">Informe quincenal de resultados y logros de planes</a></li>
                    </ul>
                </li>

                <!-- MODULO: Reporte RPA -->
                <li id="i_reporte_rpa" runat="server" visible="true" class="dropdown dropdown-submenu">
                    <a tabindex="-1" href="#" class="dropdown-toggle" data-toggle="dropdown">Reporte RPA</a>
                    <ul class="dropdown-menu">
                        <li id="iii_uno" runat="server" visible="true"><a id="A77" runat="server" href="~/mod_reportes/Infografias.aspx?i=MQ==">Vista global: Reingresos. Enfoque regional y evolución en el tiempo</a></li>
                        <li id="iii_dos" runat="server" visible="true"><a id="A70" runat="server" href="~/mod_reportes/Infografias.aspx?i=Mg==">Análisis detallado: Reingresos. Tiempo promedio de reingresos y las causas de egresos previos</a></li>
                        <li id="iii_tres" runat="server" visible="true"><a id="A78" runat="server" href="~/mod_reportes/Infografias.aspx?i=Mw==">Análisis detallado: Reingresos. Enfoque regional según modalidad del programa</a></li>
                        <li id="iii_cuatro" runat="server" visible="true"><a id="A79" runat="server" href="~/mod_reportes/Infografias.aspx?i=NA==">Análisis detallado: Reingresos según delito. Enfoque en jóvenes con múltiples reingresos</a></li>
                    </ul>
                </li>

                <!-- MODULO: Mantenedores de Seguridad -->
                <li id="i_mantenedores_seguridad" runat="server" visible="true" class="dropdown-submenu">
                    <a tabindex="-1" href="#">Mantenedores de Seguridad</a>
                    <ul class="dropdown-menu">
                        <li id="ii_mantenedor_roles" runat="server" visible="true"><a id="A68" runat="server" href="~/mod_seguridad/MantenedorDeRoles.aspx">Mantenedor de Roles</a></li>
                        <li id="ii_mantenedor_tokens" runat="server" visible="true"><a id="A69" runat="server" href="~/mod_seguridad/MantenedorDeTokens.aspx">Mantenedor de Tokens</a></li>
                        <li id="ii_mantenedor_relacion_roles_tokens" runat="server" visible="true"><a id="A71" runat="server" href="~/mod_seguridad/MantenedorRelacionRolesTokens.aspx">Mantenedor Relacion Roles Tokens</a></li>
                        <%--<li id="ii_mantenedor_relacion_roles_usuarios" runat="server" visible="true"><a id="A70" runat="server" href="~/mod_seguridad/MantenedorRelacionRolesUsuarios.aspx">Mantenedor Relacion Roles Usuarios</a></li>--%>
                        <li id="ii_mantenedor_relacion_usuarios_tokens" runat="server" visible="true"><a id="A72" runat="server" href="~/mod_seguridad/MantenedorRelacionUsuariosTokens.aspx">Mantenedor Relacion Usuarios Tokens</a></li>
                    </ul>
                </li>
              </ul>
            </li>

            <li><a id="A73" runat="server" href="~/mod_ninos/NNAVigentes.aspx"><span class="glyphicon glyphicon-search" aria-hidden="true"></span> Niños, Niñas y Adolescentes Vigentes</a></li>

            <li><a id="A84" target = "_blank" runat="server" href="https://www.senainfo.cl/centro-de-documentacion/"><span class="glyphicon glyphicon-file" aria-hidden="true"></span> Centro de Documentación</a></li>

            <%--<li><a runat="server" href="#"><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span> Mesa de Ayuda</a></li>--%>

            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false" title="Pinche Aquí Para Ver Opciones del Usuario">
                <span class="glyphicon glyphicon-user" aria-hidden="true"></span> <asp:Label ID="lbl_name" runat="server" ForeColor="White" Text="Label"></asp:Label>
                <%--<span class="badge">42</span>--%>
              </a>
              <ul class="dropdown-menu" role="menu">
                <li class="dropdown-submenu">
                  <a tabindex="-1" href="#"><span class="glyphicon glyphicon-refresh" aria-hidden="true"></span> Cambiar de Sistema</a>
                  <ul class="dropdown-menu">
                    <li><a href="http://historico.senainfo.cl" target="_blank">Historico</a></li>
                    <li><a href="http://financiero.senainfo.cl" target="_blank">Financiero</a></li>
                  </ul>
                </li>
                <%--<li><a href="#"><span class="glyphicon glyphicon-time" aria-hidden="true"></span> Pendientes <span class="badge">42</span></a></li>--%>
                <%--<li><a href="#"><span class="glyphicon glyphicon-cog" aria-hidden="true"></span> Cambiar Clave</a></li>--%>
                <li class="divider"></li>
                <li><asp:LinkButton ID="lnk_CerrarSesion" runat="server" OnClick="lnk_CerrarSesion_Click" ForeColor="Black">
                        <span class="glyphicon glyphicon-off" aria-hidden="true"></span> Cerrar Sesión
                    </asp:LinkButton>
                </li>
              </ul>
            </li>

          </ul>
        </div>
      </div>
    </nav>


