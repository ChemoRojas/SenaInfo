<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="~/mod_ninos/DatosdeGestion.aspx.cs" Inherits="mod_ninos_DatosdeGestion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="ninos_busqueda.ascx" TagName="ninos_busqueda" TagPrefix="uc2" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc2" TagName="menu_colgante" %>
<%@ Register Src="~/mod_ninos/ninos_MedidaOSancion.ascx" TagPrefix="uc2" TagName="ninos_MedidaOSancion" %>
<%@ Register Src="~/mod_ninos/niños_migracion.ascx" TagPrefix="uc2" TagName="niños_migracion" %>

<%--<%@ Register Src="~/mod_ninos/DatosdeGestion_condicionesLeyRPA_Art134bis.ascx" TagPrefix="clrpa1" TagName="DatosdeGestion_condicionesLeyRPA_Art134bis" %>
<%@ Register Src="~/mod_ninos/DatosdeGestion_condicionesLeyRPA_PlanMotivacional.ascx" TagPrefix="clrpa2" TagName="DatosdeGestion_condicionesLeyRPA_PlanMotivacional" %>
<%@ Register Src="~/mod_ninos/DatosdeGestion_condicionesLeyRPA_DerivacionPRE.ascx" TagPrefix="clrpa3" TagName="DatosdeGestion_condicionesLeyRPA_DerivacionPRE" %>
<%@ Register Src="~/mod_ninos/DatosdeGestion_condicionesLeyRPA_Flexibilizacion.ascx" TagPrefix="clrpa4" TagName="DatosdeGestion_condicionesLeyRPA_Flexibilizacion" %>--%>

<!DOCTYPE html>
<script runat="server">

</script>

<html lang="es">
<head id="Head1" runat="server">
    <!--====Librerias nuevas====-->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Datos de Gestión :: Senainfo :: Servicio Nacional de Menores</title>

    <%--  Javascript Sources --%>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/bootstrap3.3.4.min.js"></script>
    <script src="../js/moment.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/dataTables.bootstrap.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.plugin.js"></script>
    <script src="../js/jquery.maxlength.js"></script>
    <script src="../js/jquery.Rut.min.js"></script>
    <script src="../js/notify.js"></script>


    <%-- CSS Sources --%>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <%--<link href="../css/dataTables.bootstrap.css" rel="stylesheet" />--%>
    <link href="../css/theme.css" rel="stylesheet" />


    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                //generateDataTable("#Ninos_busqueda1_grd002", "datosdegestion");


                //if ($("#Ninos_busqueda1_grd002").length > 0) {
                //    //$("#Ninos_busqueda1_grd002").DataTable({ paging: false, ordering: false, sorting: false, searching: true })
                //    if (new $.fn.dataTable.Api("#grd001").init() == null) {
                //        $("#Ninos_busqueda1_grd002").DataTable({
                //            paging: false,
                //            ordering: false,
                //            sorting: false,
                //            searching: true,
                //            scrollY: 400
                //        });
                //        $(".dataTables_scrollHead").css("height", "50px");
                //    }
                //}

                ////$("#Ninos_busqueda1_grd002 thead tr th").css("text-align", "center")
                //if ($("#Ninos_busqueda1_grd002 tr").length == 2) {
                //    $(".dataTables_scrollHead").css("height", "35px");
                //}
            });
            //$("#Ninos_busqueda1_grd002");
            //$("#Ninos_busqueda1_grd002 tr");

            //$(".dataTables_scrollHead").css("height", "35px");
        }

      
        function LoadScript() {
            $(document).ready(function () {
                //if ($("#Ninos_busqueda1_grd002 tr").length == 2) {
                //    $(".dataTables_scrollHead").css("height", "35px");
                //}
                //you code gose here 

                //$('#collapse').click(function () {
                //    collapseFixHeader('#Ninos_busqueda1_grd002');
                //});

                if (("#Ninos_busqueda1_grd002").length > 0) {
                    generateDataTable($("#Ninos_busqueda1_grd002"));
                    //$("#Ninos_busqueda1_grd002 thead th").removeAttr("style");
                    //$("#Ninos_busqueda1_grd002 th").addClass("text-center");
                    //$("#Ninos_busqueda1_grd002_filter").width($("#Ninos_busqueda1_grd002_filter").parent().width())
                }

                pageLoad();


                $("input[name^='RadioDoc_1_']").click(function () {
                    if ($(this).val() == "0") {
                        $("input[name^='Doc_datos_1']").attr("readonly", "readonly");
                        $("input[name^='Doc_datos_1']").val("");
                    } else {
                        $("input[name^='Doc_datos_1']").removeAttr("readonly");
                    }
                });

                $("input[name^='RadioDoc_7_']").click(function () {
                    if ($(this).val() == "0") {
                        $("input[name^='Doc_datos_7']").attr("readonly", "readonly");
                        $("input[name^='Doc_datos_7']").val("");
                    } else {
                        $("input[name^='Doc_datos_7']").removeAttr("readonly");
                    }
                });

                $("input[name^='niños_migracion$paso_fronterizo']").click(function () {
                    if ($("input[name^='niños_migracion$paso_fronterizo']").filter(":checked").val() == "rb_paso_fronterizo_si") {
                        $("#niños_migracion_txt_paso_fronterizo").removeAttr("readonly");
                    } else {
                        $("#niños_migracion_txt_paso_fronterizo").attr("readonly", "readonly");
                    }
                });

                if ($("input[name^='niños_migracion$paso_fronterizo']").filter(":checked").val() == "rb_paso_fronterizo_si") {
                    $("#niños_migracion_txt_paso_fronterizo").removeAttr("readonly");
                } else {
                    $("#niños_migracion_txt_paso_fronterizo").attr("readonly", "readonly");
                    $("#niños_migracion_txt_ingreso_chile").val("");
                }


                $("input[name^='niños_migracion$ingresos_chile']").click(function () {
                    if ($("input[name^='niños_migracion$ingresos_chile']").filter(":checked").val() == "rb_ingresos_chile_si") {
                        $("#niños_migracion_txt_ingreso_chile").removeAttr("readonly");
                    } else {
                        $("#niños_migracion_txt_ingreso_chile").attr("readonly", "readonly");
                        $("#niños_migracion_txt_ingreso_chile").val("");
                    }
                });

                if ($("input[name^='niños_migracion$ingresos_chile']").filter(":checked").val() == "rb_ingresos_chile_si") {
                    $("#niños_migracion_txt_ingreso_chile").removeAttr("readonly");
                } else {
                    $("#niños_migracion_txt_ingreso_chile").attr("readonly", "readonly");
                    $("#niños_migracion_txt_ingreso_chile").val("");
                }

                $("input[name^='niños_migracion$otros_paises']").click(function () {
                    if ($("input[name^='niños_migracion$otros_paises']").filter(":checked").val() == "rb_otros_paises_si") {
                        $("#niños_migracion_txt_otros_paises").removeAttr("readonly");
                    } else {
                        $("#niños_migracion_txt_otros_paises").attr("readonly", "readonly");
                        $("#niños_migracion_txt_otros_paises").val("");
                    }
                });

                if ($("input[name^='niños_migracion$otros_paises']").filter(":checked").val() == "rb_otros_paises_si") {
                    $("#niños_migracion_txt_otros_paises").removeAttr("readonly");
                } else {
                    $("#niños_migracion_txt_otros_paises").attr("readonly", "readonly");
                    $("#niños_migracion_txt_otros_paises").val("");
                }

                $("#link_tab11_1").click(function () {
                    $("#li_articulo134bis").removeClass("active");
                    //$("#li_articulo134bis").css("background-color", "white !important");
                });
               

                $("#link_tab11_4").click(function () {
                    $("#li_flexibilizacion").removeClass("active");
                    //$("#li_flexibilizacion").css("background-color", "white !important");
                });

            });
        }

        function limpiarColor() {
            $("#li_articulo134bis").removeAttr("class");
        }

        LoadScript();

        $(document).ready(function () {
           

        });

        $(document).on('shown.bs.tab', 'a[data-toggle="tab"]', function (e) {
            $("#lbl0055").hide();
            $("#alert").hide();
            $("#lbl00552").hide();
            $("#alert2").hide();
        })

        function MostrarModalProyecto() {

            var objIframe = document.getElementById('iframe_bsc_proyecto');
            limpiaiframe(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/DatosdeGestion.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe4aProyecto").show();
            return false;
        }


        //function mostrarX() {

        //    var objIframe = document.getElementById('iframe_bsc_proyecto');
        //    limpiaiframe(objIframe);
        //    //objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/DatosdeGestion.aspx";
        //    objIframe.src = "../mod_ninos/ninos_solicituddiligencias.aspx?ICodDiligencia=902878";
        //    objIframe.height = "300px";
        //    objIframe.width = "760px";
        //    $find("mpeX").show();
        //    return false;
        //}

        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            var oddown001 = document.getElementById('ddl_Proyectos');

            //objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Instituciones&dir=reg_eventosproy.aspx" + "&codproy=" + oddown001.options[oddown001.selectedIndex].value;
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/DatosdeGestion.aspx";
            objIframe.height = "600px";
            objIframe.width = "900px";
            $find("mpe4aInstitucion").show();
            return false;
        }
        function MuestraTab() {
            PestañaActual(9);
        }

        function CerrarModalPopUp() {
            parent.location.reload();
        }

        function cleanIDiagnostico() {
            //$("#ddown003").each(function () { this.selectedIndex = 0 });
            //$("#ddown006").each(function () { this.selectedIndex = 0 });
            //$("#cal003").val("Seleccione Fecha");
            //$("#ddl_EtapasRealizadas").each(function () { this.selectedIndex = 0 });
            $("#divDetalleDiag").hide();
        }

        //$('#link_tab2').on('shown.bs.tab', function (e) { alert('TAB CHANGED'); }) – 
        //itemid="1"
        $(document).on('shown.bs.tab', 'a[data-toggle="tab"]', function (e) {
            var target = $(e.target).attr("itemid");
            PestañaActual(target);
        })

        function PestañaActual(n) {
            $("#CurrentPage").val(n);

        }

        //
        function isNumeric(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        function ValidaRuc(source, arguments) {

            var rut = arguments.Value;
            rut = rut.trim();
            if (rut.length < 12) { arguments.IsValid = false; return }

            var strGuionDigito = rut.substring(rut.length - 2);
            var strCuerpo = rut.substring(0, rut.length - 2);

            if (!isNumeric(strCuerpo)) { arguments.IsValid = false; return }

            if (strGuionDigito.substring(0, 1) != '-') { arguments.IsValid = false; return }
            var aux = "2765432765432";
            var ruc = "123456789K0";
            var ns = rut.length;
            var i = ns - 2;
            var a = 12;
            var sum = 0;
            while (i >= 0) {
                if (rut.substring(i, i + 1) != '-') {
                    sum = sum + (parseInt(rut.substring(i, i + 1)) * parseInt(aux.substring(a, a + 1)));
                    a = a - 1;
                    if (a == 0) a = 12;
                }
                i = i - 1;
            }
            sum = 11 - (sum % 11);
            if (rut.substring(ns - 1, ns) == ruc.substring(sum - 1, sum))
                arguments.IsValid = true;
            else
                arguments.IsValid = false;
        }

        function VolverLista() {
            var link = document.getElementById("lnk001");
            link.click();
        }

        function LlamaSesiones() {
            var objeto = window.frames[7].document.getElementById('lnb001');
            objeto.click();
        }

        //borra el contenido del iframe antes de cargar el siguiente
        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }

        //------------------------------------------------------------------DISCAPACIDAD -----------------------------------------------------------------------------
        // esta se llama al guardar en la ventana modal
        window.MFref_AgrDis = function () {
            PestañaActual(2);
            $find("mpe2a").hide();
            //refresca solo el grid afectado
            document.getElementById('BtnFun_AgrDis').click();
        }

        //Boton "Agregar Discapacidad"
        function MostrarModalDatosSaludAgregarDiscapacidad() {
            PestañaActual(2);

            var objIframe = document.getElementById('iframe_Datos_Salud_Agregar_Discapacidad');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_discapacidad.aspx';

            objIframe.height = "400px";
            objIframe.width = "800px";
            $find("mpe2a").show();
            return false;
        }
        // BOTON INVISIBLE bntEscondido_utab2a
        function MostrarModalDiscapacidad_Utab2a() {
            PestañaActual(2);
            var objIframe = document.getElementById('iframe_discapacidad_utab2a');
            objIframe.height = "400px";
            objIframe.width = "800px";
            $find("mpe_utab2a").show();
            return false;
        }
        // LINKBUTTON "Modificar"
        function Llama_Utab2a(ICodDiscapacidad) {
            var objIframe = document.getElementById('iframe_discapacidad_utab2a');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_discapacidad.aspx?ICodDiscapacidad=' + ICodDiscapacidad;
            document.getElementById('bntEscondido_utab2a').click();
            return false;
        }

        //--------------------------------------------------------------------HECHO DE SALUD ---------------------------------------------------------------------------

        window.MFref_HecSal = function () {
            $find("mpe3a").hide();
            document.getElementById('BtnFun_HecSal').click();  //refresca solo el grid afectado
        }

        // Boton "Agregar Hechos de Salud"
        function MostrarModalDatosSaludAgregarHechosSalud() {
            PestañaActual(2);

            var objIframe = document.getElementById('iframe_Datos_Salud_Agregar_Hechos_Salud');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_hechosdesalud.aspx';

            objIframe.height = "400px";
            objIframe.width = "800px";
            $find("mpe3a").show();
            return false;
        }
        //BOTON ESCONDIDO bntEscondido_utab2b
        function MostrarModalHechosSalud_Utab2b() {
            PestañaActual(2);
            var objIframe = document.getElementById('iframe_hechossalud_utab2b');
            objIframe.height = "400px";
            objIframe.width = "800px";
            $find("mpe_utab2b").show();
            return false;
        }

        // LINKBUTTON "Modificar"
        function Llama_Utab2b(ICodHechosdeSalud) {
            var objIframe = document.getElementById('iframe_hechossalud_utab2b');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_hechosdesalud.aspx?ICodHechosdeSalud=' + ICodHechosdeSalud;
            document.getElementById('bntEscondido_utab2b').click();
            return false;
        }
        //--------------------------------------------------------------------SOLICITUD DE DILIGENCIA ---------------------------------------------------------------------------

        window.MFref_SolDil = function () {
            $find("mpe1a").hide();
            document.getElementById('BtnFun_SolDil').click();
        }
        // Boton "Agregar Nueva Solicitud" (de diligencia)
        function MostrarModalSolicitudDiligencia() {

            PestañaActual(1);
            var objIframe = document.getElementById('iframe_Solicitud_Diligencia');
            objIframe.height = "400px";
            objIframe.width = "800px";
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_solicituddiligencias.aspx';
            $find("mpe1a").show();
            return false;
        }

        // BOTON INVISIBLE btn0012
        function MostrarModalUtab1() {
            var objIframe = document.getElementById('iframe_Solicitud_Diligencia2');
            objIframe.height = "400px";
            objIframe.width = "800px";
            $find("mpe1a2").show();
            return false;
        }

        // LINKBUTTON "Modificar"
        function LlamaUtab1(ICodDiligencia) {
            PestañaActual(1);
            var objIframe = document.getElementById('iframe_Solicitud_Diligencia2');
            objIframe.src = 'ninos_solicituddiligencias.aspx?ICodDiligencia=' + ICodDiligencia;
            limpiaiframe(objIframe);
            document.getElementById('btn0012').click();
            return true;
        }

        //--------------------------------------------------------------------ACCIONES INFORME DIAGNOSTICO  ---------------------------------------------------------------------------

        window.MFref_AccInf = function () {
            document.getElementById('BtnFun_AccInf').click(); //refresca solo el grid afectado
        }

        // Boton "Agregar Nueva Accion al Diagnostico"
        function MostrarModalAgregarNuevaAccionalDiagnostico() {
            PestañaActual(3);

            var objIframe = document.getElementById('iframeAgregarNuevaAccioNalDiagnostico');
            limpiaiframe(objIframe);
            objIframe.src = 'accionesinformediagnostico.aspx?&dir=DatosdeGestion.aspx';

            objIframe.height = "600px";
            objIframe.width = "800px";
            $find("mpeANAD").show();
            return false;
        }


        //--------------------------------------------------------------------ENFERMEDADES CRONICAS ---------------------------------------------------------------------------
        window.MFref_EnfCro = function () {
            $find("mpe4a").hide();
            $find("mpe_utab2c").hide();
            document.getElementById('BtnFun_EnfCro').click(); //refresca solo el grid afectado
        }

        // Boton "Agregar Enfermedad Cronica"
        function MostrarModalDatosSaludAgregarEnfermedadCronica() {
            PestañaActual(2);

            var objIframe = document.getElementById('iframe_Datos_Salud_Agregar_Enfermedad_Cronica');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_enfermedadescronicas.aspx';

            objIframe.height = "400px";

            objIframe.width = "800px";
            $find("mpe4a").show();
            return false;
        }
        // BOTN INVISIBLE bntEscondido_utab2c
        function MostrarModalEnfermedadCronica_Utab2c() {
            PestañaActual(2);
            var objIframe = document.getElementById('iframe_enfermedadcronica_utab2c');
            objIframe.height = "400px";
            objIframe.width = "800px";
            $find("mpe_utab2c").show();
            return false;
        }
        // LINKBUTTON "Modificar"
        function Llama_Utab2c(ICodEnfermedadCronica) {
            var objIframe = document.getElementById('iframe_enfermedadcronica_utab2c');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_enfermedadescronicas.aspx?ICodEnfermedadCronica=' + ICodEnfermedadCronica;
            document.getElementById('bntEscondido_utab2c').click();
            return false;
        }



        //--------------------------------------------------------------------PERSONAS RELACIONADAS---------------------------------------------------------------------------
        window.MFref_PerRel = function () {

            $find("mpe5a").hide();
            $find("mpe_utab4a").hide();
            document.getElementById('BtnFun_PerRel').click(); //refresca solo el grid afectado
        }

        // Boton "Agregar Persona Relacionada"
        function MostrarModalModificarPersonasRelacionadas() {
            PestañaActual(4);

            var objIframe = document.getElementById('iframe_Datos_Modificar_Personas_Relacionadas');

            objIframe.height = "600px";
            objIframe.width = "800px";
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_nuevapersonarel.aspx';
            $find("mpe5a").show();
            return false;
        }
        //BOTON INVISIBLE bntEscondido_utab4a
        function MostrarModalPersonaRelacionada_Utab4a() {
            PestañaActual(4);
            var objIframe = document.getElementById('iframe_personarelacionada_utab4a');
            objIframe.height = "600px";
            objIframe.width = "800px";
            $find("mpe_utab4a").show();
            return false;
        }
        // LINKBUTTON "Modificar"
        function Llama_Utab4a(CodPersonaRelacionada) {
            var objIframe = document.getElementById('iframe_personarelacionada_utab4a');
            limpiaiframe(objIframe);
            objIframe.src = 'ninos_nuevapersonarel.aspx?CodPersonaRelacionada=' + CodPersonaRelacionada + '&sw=1';
            document.getElementById('bntEscondido_utab4a').click();
            return false;
        }

        //------------------------------------------------------------------------ETAPAS DIAGNOSTICO -----------------------------------------------------------------------

        //BOTON INVISIBLE bntEscondido_utab3a
        function MostrarModalEtapasDiagnostico_Utab3a() {
            PestañaActual(3);
            var objIframe = document.getElementById('iframe_etapasdiagnostico_utab3a');
            objIframe.height = "600px";
            objIframe.width = "800px";
            $find("mpe_utab3a").show();
            return false;
        }
        // LINKBUTTON "Modificar"
        function Llama_Utab3a(Icodaccion) {
            PestañaActual(3);
            var objIframe = document.getElementById('iframe_etapasdiagnostico_utab3a');
            limpiaiframe(objIframe);
            objIframe.src = 'accionesinformediagnostico.aspx?icodaccion=' + Icodaccion;
            document.getElementById('bntEscondido_utab3a').click();
            return false;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        function MostrarIframeUtab1() {
            var objIframetab1 = document.getElementById('iframe_utab1');
            if (objIframetab1.src == "") {
                objIframetab1.src = "../mod_ninos/ninos_DiagnisticoEscolar.aspx";
                objIframetab1.height = "600px";
                objIframetab1.width = "1130px";
            }
            return false;
        }

        window.closemodal = function () {
            $("#myModal").modal("hide");
            $("#refrescarDiligencias").click();
        }

        window.cerrarModalInfoDiag = function () {
            $("#btnCerrarModal_utab3a").delay(1000).click();
            $("#refrescarDiag").click();
        };

        window.cerrarModalDiscapacidad = function () {
            $("#btnCerrarModal2").delay(1000).click()
            $("#triggerUpdateDiscapacidad").click();
        }

        window.cerrarModalHechosSalud = function () {
            $("#btnCerrarModal3").delay(1000).click();
            $("#triggerHechosSalud").click();
        }

        window.cerrarModalEnfermedadesCronicas = function () {
            $("#btnCerrarModal4").delay(1000).click();
            $("#triggerUpdateEnfermedadesCronicas").click();
        }

        window.agregarMaxLength = function () {
            //$("#iframe_Datos_Salud_Agregar_Discapacidad").contents().find("#txt001").maxlength({ max: 100 });
            $("#iframe_Datos_Salud_Agregar_Discapacidad").contents().find("#txt001").maxlength({
                max: 100,
                feedbackText: 'Número de caracteres {c}/{m}'
            });
        }

        window.agregarMaxLengthObservacionHechosSalud = function () {
            $("#iframe_Datos_Salud_Agregar_Hechos_Salud").contents().find("#txt001").maxlength({
                max: 100,
                feedbackText: 'Numero de caracteres {c}/{m}'
            });
        }

        window.agregarMaxLengthObservacionEC = function () {
            $("#iframe_Datos_Salud_Agregar_Enfermedad_Cronica").contents().find("#txt001").maxlength({
                max: 100,
                feedbackText: 'Numero de caracteres {c}/{m}'
            });
        }

        window.agregarValidaRutPersonaRelacionada = function () {
            $("#iframe_Datos_Modificar_Personas_Relacionadas").contents().find("#txtb001").Rut({
                format_on: 'keyup',
                on_error: function () {
                    alert("Rut incorrecto, por favor vuelva a ingresarlo");
                    $("#iframe_Datos_Modificar_Personas_Relacionadas").contents().find("#txtb001").val("");
                }
            });
        }


        $(function () {
            $("#refrescarDiag").click(function () {
                // your logic here
            });
        });


        //function myFunction() {
        //    //some code here
        //    alert('Function called successfully!');
        //}


        //'ninos_MedidaOSancion_txt001LRPA'


        $(document).keyup(function (e) {

            //numeros del 0 al 9
            if (e.keyCode >= 96 && e.keyCode <= 105) {
                ObtenerFechaTerminoSancion(1);
            }

        });
        $(document).keydown(function (e) {
            //numeros del 0 al 9
            if (e.keyCode >= 96 && e.keyCode <= 105) {
                ObtenerFechaTerminoSancion(1);
            }

        });


        function validaFecha() {
            $(function () {
                var fechainicio = $("#ninos_MedidaOSancion_txt_FechaInicioSancionLRPA").val().replace(/-/g, '/');
                var fechaTermino = $("#ninos_MedidaOSancion_txt003LRPA").val().replace(/-/g, '/');

                var valueStart = fechainicio.split("/");
                var valueEnd = fechaTermino.split("/");

                var dateStart = new Date(valueStart[2], (valueStart[1] - 1), valueStart[0]);
                var dateEnd = new Date(valueEnd[2], (valueEnd[1] - 1), valueEnd[0]);

                if (dateEnd <= dateStart) {
                    $("#ninos_MedidaOSancion_btn_GuardarLRPA").attr("disabled", "disabled");
                    $("#DatosSancion").notify(
                        "El termino de sancion no puede ser una fecha inferior a la de inicio de sanción",
                        {
                            autoHideDelay: 3000,
                            position: "bottom",
                            className: "info",
                            elementPosition: 'right',
                            style: 'bootstrap',
                            showAnimation: 'slideDown',
                            showDuration: 400,
                            hideAnimation: 'slideUp',
                            hideDuration: 200,
                            gap: 2
                        });
                } else {
                    $("#ninos_MedidaOSancion_btn_GuardarLRPA").removeAttr("disabled");
                }

            });
        }

        function ObtenerFechaTerminoSancion(BotonPresionado) {

            if (document.getElementById('ninos_MedidaOSancion_txt_FechaInicioSancionLRPA').value != "") {

                var TxtFechaInicioSancionLRPA = moment(document.getElementById('ninos_MedidaOSancion_txt_FechaInicioSancionLRPA').value, "DD-MM-YYYY");
                var TxtFechaInicioSancionLRPAOriginal = moment(document.getElementById('ninos_MedidaOSancion_txt_FechaInicioSancionLRPA').value, "DD-MM-YYYY");

                var TxtAnos = document.getElementById('ninos_MedidaOSancion_txt001LRPA').value;
                var TxtMeses = document.getElementById('ninos_MedidaOSancion_txt002LRPA').value;
                var TxtDias = document.getElementById('ninos_MedidaOSancion_txt007LRPA').value;
                var TxtAbono = document.getElementById('ninos_MedidaOSancion_txt009LRPA').value;
                if (TxtAnos != "") {
                    TxtFechaInicioSancionLRPA = TxtFechaInicioSancionLRPA.add(TxtAnos, 'years');
                }
                if (TxtMeses != "") {
                    TxtFechaInicioSancionLRPA = TxtFechaInicioSancionLRPA.add(TxtMeses, 'months');
                }
                if (TxtDias != "") {
                    TxtFechaInicioSancionLRPA = TxtFechaInicioSancionLRPA.add(TxtDias, 'days');
                }
                if (TxtAbono != "") {
                    TxtFechaInicioSancionLRPA = TxtFechaInicioSancionLRPA.subtract(TxtAbono, 'days');
                }

                var dia = moment(TxtFechaInicioSancionLRPA).get('date');
                var mes = (moment(TxtFechaInicioSancionLRPA).get('month') + 1);
                var anio = moment(TxtFechaInicioSancionLRPA).get('year');

                if (dia < 10) {
                    dia = "0" + dia;
                }

                if (mes < 10) {
                    mes = "0" + mes;
                }


                document.getElementById('ninos_MedidaOSancion_txt003LRPA').value = dia + '-' + mes + '-' + anio;
                var FechaTerminoSancion = $("#ninos_MedidaOSancion_txt003LRPA");
                var delay = 350;
                FechaTerminoSancion.animate({ backgroundColor: "#F59806" }, delay, function () {
                    //revert after completing
                    FechaTerminoSancion.animate({ backgroundColor: "#EEE" }, delay);
                });

                //if (document.getElementById('ninos_MedidaOSancion_Chk002LRPAMixta').checked != false) {
                //    ObtenerFechaTerminoSancionMixta(1);
                //}
                //$.session.set("ValorCambiado", "1");
                //}

                //}
                //else { // onChange

                //if ($.session.get("ValorCambiado") == "0" || $.session.get("ValorCambiado") == null) {
                //document.getElementById('ninos_MedidaOSancion_txt003LRPA').value = moment(TxtFechaInicioSancionLRPA).get('date') + '-' + (moment(TxtFechaInicioSancionLRPA).get('month') + 1) + '-' + moment(TxtFechaInicioSancionLRPA).get('year');
                //var FechaTerminoSancion = $("#ninos_MedidaOSancion_txt003LRPA");
                //var delay = 350;
                //FechaTerminoSancion.animate({ backgroundColor: "#F59806" }, delay, function () {
                //    //revert after completing
                //    FechaTerminoSancion.animate({ backgroundColor: "#EEE" }, delay);
                //});

                if (document.getElementById('ninos_MedidaOSancion_Chk002LRPAMixta').checked != false) {
                    ObtenerFechaTerminoSancionMixta(0);
                }

                //var now = moment().format('L');

                validaFecha();



            }
        }

        function ObtenerFechaTerminoSancionMixta() {


            var TxtFechaTerminoSancion = moment(document.getElementById('ninos_MedidaOSancion_txt003LRPA').value, "DD-MM-YYYY");
            var TxtFechaTerminoSancionOriginal = moment(document.getElementById('ninos_MedidaOSancion_txt003LRPA').value, "DD-MM-YYYY");

            TxtFechaTerminoSancion = TxtFechaTerminoSancion.add(1, 'days');

            var diaTerminoSancion = moment(TxtFechaTerminoSancion).get('date');
            var mesTerminoSancion = (moment(TxtFechaTerminoSancion).get('month') + 1);
            var anioTerminoSancion = moment(TxtFechaTerminoSancion).get('year');


            if (diaTerminoSancion < 10) {
                diaTerminoSancion = "0" + diaTerminoSancion;
            }

            if (mesTerminoSancion < 10) {
                mesTerminoSancion = "0" + mesTerminoSancion;
            }

            //document.getElementById('ddown009LRPA').value = moment(TxtFechaTerminoSancion).get('date') + '-' + (moment(TxtFechaTerminoSancion).get('month') + 1) + '-' + moment(TxtFechaTerminoSancion).get('year');
            document.getElementById('ninos_MedidaOSancion_ddown009LRPA').value = (diaTerminoSancion + '-' + mesTerminoSancion + '-' + anioTerminoSancion);


            var TxtFechaInicioSancionMixta = moment(document.getElementById('ninos_MedidaOSancion_ddown009LRPA').value, "DD-MM-YYYY");

            var TxtAnos = document.getElementById('ninos_MedidaOSancion_txt004LRPA').value;
            var TxtMeses = document.getElementById('ninos_MedidaOSancion_txt005LRPA').value;
            var TxtDias = document.getElementById('ninos_MedidaOSancion_txt008LRPA').value;
            if (TxtAnos != "") {
                TxtFechaInicioSancionMixta = TxtFechaInicioSancionMixta.add(TxtAnos, 'years');
            }
            if (TxtMeses != "") {
                TxtFechaInicioSancionMixta = TxtFechaInicioSancionMixta.add(TxtMeses, 'months');
            }
            if (TxtDias != "") {
                TxtFechaInicioSancionMixta = TxtFechaInicioSancionMixta.add(TxtDias, 'days');
            }

            var diaInicioSancionMixta = moment(TxtFechaInicioSancionMixta).get('date');
            var mesinicioSancionMixta = (moment(TxtFechaInicioSancionMixta).get('month') + 1);
            var anioInicioSancionMixta = moment(TxtFechaInicioSancionMixta).get('year');

            if (diaInicioSancionMixta < 10) {
                diaInicioSancionMixta = "0" + diaInicioSancionMixta;
            }

            if (mesinicioSancionMixta < 10) {
                mesinicioSancionMixta = "0" + mesinicioSancionMixta;
            }

            document.getElementById('ninos_MedidaOSancion_txt006LRPA').value = (diaInicioSancionMixta + '-' + mesinicioSancionMixta + '-' + anioInicioSancionMixta);

            var FechaTerminoSancion = $("#ninos_MedidaOSancion_txt006LRPA");
            var delay = 350;
            FechaTerminoSancion.animate({ backgroundColor: "#F59806" }, delay, function () {
                //revert after completing
                FechaTerminoSancion.animate({ backgroundColor: "#EEE" }, delay);

            });

            if ($("#ninos_MedidaOSancion_txt006LRPA").val() != "") {
                $("#ninos_MedidaOSancion_ddown007LRPA").val(FechaTerminoSancion.val());
            }

        }

        



    </script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">

    <style>
        .avoid-clicks {
            pointer-events: none;
        }

        .btn-large {
            width: 200px !important;
        }

        .nav .open > a,
        .nav .open > a:hover,
        .nav .open > a:focus {
            background-color: #F59806;
            border-color: #337ab7;
        }
    </style>

    <form id="form1" runat="server">
        <uc2:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager_datosGestion" ScriptMode="Release" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:Button ID="BtnFun_HecSal" runat="server" Text="Button" CausesValidation="False" OnClick="BtnFun_Click" CssClass="invisible" />
        <asp:Button ID="BtnFun_SolDil" runat="server" Text="Button" CausesValidation="False" OnClick="BtnFun_Click" CssClass="invisible" />
        <asp:Button ID="BtnFun_AgrDis" runat="server" Text="Button" CausesValidation="False" OnClick="BtnFun_Click" CssClass="invisible" />
        <asp:Button ID="BtnFun_AccInf" runat="server" Text="Button" CausesValidation="False" OnClick="BtnFun_Click" CssClass="invisible" />
        <asp:Button ID="BtnFun_EnfCro" runat="server" Text="Button" CausesValidation="False" OnClick="BtnFun_Click" CssClass="invisible" />
        <asp:Button ID="BtnFun_PerRel" runat="server" Text="Button" CausesValidation="False" OnClick="BtnFun_Click" CssClass="invisible" />
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <%-- <Triggers>
                <asp:PostBackTrigger ControlID="grd002" />
            </Triggers>--%>
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(LoadScript);
                </script>


                <asp:HiddenField runat="server" ID="ecVal" Value="0" />

                <ajax:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe4aProyecto" runat="server"
                    TargetControlID="imb_lupaproyecto"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="LinkButton3">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="mpe4aInstitucion" runat="server"
                    TargetControlID="imb_lupa_institucion"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="LinkButton4">
                </ajax:ModalPopupExtender>


                <!-- Large modal -->
                <asp:Panel runat="server" ID="modal" Visible="false">
                    <%--<button type="button" id="myButtonModalWorks" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-lg">Large modal</button>

                <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
                  <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                      
                    </div>
                  </div>
                </div>--%>


                    <div class="modal fade bs-example-modal-lg" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog modal-lg" role="document">
                            <asp:UpdatePanel ID="upModal" runat="server">
                                <ContentTemplate>
                                    <div class="modal-content" style="width: 1100px; right: 100px;">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton ID="LinkButtonX" Visible="false" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                            <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="$('#modalElement').data('modal', null);"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title text-center">MODIFICAR DILIGENCIAS</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframeModificarDiligencias" runat="server" width="100%" height="500px" frameborder="0"></iframe>
                                        </div>
                                        <div class="modal-footer">
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <button type="button" runat="server" visible="true" id="myButtonModal" class="" data-toggle="modal" data-target=".bs-example-modal-lg" style="background-color: transparent; border: 0;">
                    </button>







                </asp:Panel>


                <!-- modal estilo SENAINFO  -->


                <%--<asp:LinkButton ID="imb_lupaX" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return mostrarX()" CausesValidation="False">
                        <span class="glyphicon glyphicon-question-sign"></span>
                </asp:LinkButton>

                <ajax:ModalPopupExtender ID="ModalPopupExtenderX" 
                    BehaviorID="mpeX" runat="server"
                    TargetControlID="imb_lupaX"
                    PopupControlID="modal_bsc_x"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="LinkButtonX">
                </ajax:ModalPopupExtender>

                <div class="popupConfirmation" id="modal_bsc_x" style="display: none">
                    
                </div>--%>


                <!-- src="ninos_solicituddiligencias.aspx?ICodDiligencia=902878"-->
                <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="LinkButton3" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">PROYECTO</h4>
                    </div>
                    <div>
                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                    </div>
                </div>
                <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="LinkButton4" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">INSTITUCION</h4>
                    </div>
                    <div>
                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                    </div>
                </div>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Datos de Gestión</li>
                    </ol>

                    <%-- Alertas --%>
                    <div class="alert alert-warning text-center" role="alert" id="alert" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lbl0055" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alert2" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-ok"></span>

                        <asp:Label ID="lbl00552" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>


                    <div class="well">
                        <h4 class="subtitulo-form">Datos de Gestión</h4>
                        <hr />

                        <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                            <asp:Label ID="lbl_acordeon" runat="server" Visible="true" Text="Ocultar Detalles de la Búsqueda"></asp:Label>
                            <span id="icon-collapse" class="glyphicon glyphicon-triangle-top"></span>
                            <asp:Label ID="lbl_resumen_filtro" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="lbl_resumen_proyecto" runat="server" Visible="false"></asp:Label>
                        </a>

                        <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Institución:</label>
                                            </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()" CausesValidation="False">
                                                     <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Proyecto:</label>
                                            </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddl_Proyectos" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupaproyecto" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto()" CausesValidation="False">
                                                            <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>

                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Nombre del Niño(a):</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt005" runat="server" CssClass="form-control input-sm " placeholder="Ingresar nombre"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt005" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü " />
                                            </td>

                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Paterno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt003" runat="server" CssClass="form-control input-sm " placeholder="Ingresar Apellido"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt003" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü " />
                                            </td>

                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Apellido Materno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt004" runat="server" CssClass="form-control input-sm " placeholder="Ingresar Apellido" type="text"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt004" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü´ " />
                                            </td>
                                        </tr>
                                        <tr id="tr_fecha_nacimiento" runat="server" visible="false">
                                            <th>
                                                <label for="">
                                                    Fecha de Nacimiento:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="lbl004" runat="server" CssClass="form-control form-control-fecha-large input-sm" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr_fecha_ingreso" runat="server" visible="false">
                                            <th>
                                                <label for="">
                                                    Fecha de Ingreso:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="lbl003" runat="server" CssClass="form-control form-control-fecha-large input-sm" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rdo001" runat="server" GroupName="rdossexo" OnDataBinding="rdo001_DataBinding" Text="Femenino" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chk002F2" runat="server" AutoPostBack="True" OnCheckedChanged="chk002F2_CheckedChanged" OnDataBinding="chk002F2_DataBinding" Text="Mostrar sólo proyectos caducados" Visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <div>
                                                    <asp:LinkButton ID="btnbuscar" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btnbuscar_Click">
                                        <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnlimpiar" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btnlimpiar_Click1">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                    </asp:LinkButton>
                                                </div>

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!--fu 2015 hidden field value current page -->
                                <asp:HiddenField runat="server" ID="CurrentPage" />

                                <div class="col-md-3">
                                    <div class="panel-info panel-primary-info">
                                        <div class="panel-heading">
                                            Información
                                        </div>
                                        <div class="panel-footer">
                                            <asp:Label ID="lbl001F2" CssClass="subtitulo-form-info" runat="server" Text="El Tiempo de Carga de la información dependerá de la cantidad de registros."></asp:Label>
                                        </div>
                                    </div>

                                    <p></p>
                                    <div class="caja-despliegue">
                                        <div>
                                            <asp:Label ID="lblbmsg" runat="server" Text="Coincidencias" Visible="False"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:LinkButton ID="lnk001" runat="server" OnClick="lnk001_Click1" Width="1px"></asp:LinkButton>
                                        </div>
                                        <div>
                                            <asp:LinkButton ID="lbtn005" runat="server" OnClick="lbtn005_Click" Visible="False">Ver niños(as) vigentes del Proyecto</asp:LinkButton>
                                        </div>
                                        <div>
                                            <asp:CheckBox ID="chk001" runat="server" OnDataBinding="chk001_DataBinding" Text="Incluir todos los Niños(as) vigentes del proyecto en el resultado" Visible="False" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div id="pnl001" runat="server" visible="false">
                                    <div>
                                        <h4>
                                            <asp:Label ID="titulo_tab" class="subtitulo-form" Text="Datos del Niño en el Proyecto" runat="server" /></h4>
                                    </div>
                                    <asp:Panel ID="utab2_nino" runat="server" Visible="true">
                                        <div>
                                            <ul id="myTabs" class="nav nav-tabs tab-fixed-height nav-justified" role="tablist">
                                                <li id="li_nav1" runat="server" role="presentation" class="active">
                                                    <a id="link_tab1" runat="server" href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab" itemid="1">SOLICITUD DE DILIGENCIAS
                                                    </a>
                                                </li>
                                                <li id="li_nav2" runat="server" role="presentation">
                                                    <a id="link_tab2" runat="server" href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab" itemid="2">DATOS DE SALUD
                                                    </a>
                                                </li>
                                                <li id="li_nav3" runat="server" role="presentation">
                                                    <a id="link_tab3" runat="server" href="#tab3" aria-controls="tab3" role="tab" data-toggle="tab" itemid="3">INFORME DIAGNÓSTICO
                                                    </a>
                                                </li>
                                                <li id="li_nav4" runat="server" role="presentation">
                                                    <a id="link_tab4" runat="server" href="#tab4" aria-controls="tab4" role="tab" data-toggle="tab" itemid="4">PERSONAS RELACIONADAS
                                                    </a>
                                                </li>
                                                <li id="li_nav5" runat="server" role="presentation">
                                                    <a id="link_tab5" runat="server" href="#tab5" aria-controls="tab5" role="tab" data-toggle="tab" itemid="5">CONTACTO
                                                    </a>
                                                </li>
                                                <li id="li_nav6" runat="server" role="presentation">
                                                    <a id="link_tab6" runat="server" href="#tab6" aria-controls="tab6" role="tab" data-toggle="tab" itemid="6">CALIDAD
                                                        JURIDICA</a>
                                                </li>
                                                <li id="li_nav7" runat="server" role="presentation">
                                                    <a id="link_tab7" runat="server" href="#tab7" aria-controls="tab7" role="tab" data-toggle="tab" itemid="7">ÓRDENES DEL TRIBUNAL
                                                    </a>
                                                </li>
                                                <li id="li_nav8" runat="server" role="presentation">
                                                    <a id="link_tab8" runat="server" href="#tab8" aria-controls="tab8" role="tab" data-toggle="tab" itemid="8">CAUSALES DE INGRESO
                                                    </a>
                                                </li>
                                                <li id="li_nav9" runat="server" role="presentation">
                                                    <a id="link_tab9" runat="server" href="#tab9" aria-controls="tab9" role="tab" data-toggle="tab" itemid="9">MEDIDA O SANCION
                                                    </a>
                                                </li>
                                                <li id="li_nav10" runat="server" role="presentation">
                                                    <a id="link_tab10" runat="server" href="#tab10" aria-controls="tab10" role="tab" data-toggle="tab" itemid="10">SITUACION MIGRATORIA
                                                    </a>
                                                </li>
                                                <%--<li id="li_nav11" runat="server" role="presentation">
                                                    <a id="link_tab11" runat="server" href="#tab11" aria-controls="tab11" role="tab" data-toggle="tab" itemid="11" visible="true">CONDICIONES LEY RPA
                                                    </a>
                                                </li>--%>
                                                <li id="li_nav11" runat="server" role="presentation" class="dropdown" visible="true">
                                                    <asp:LinkButton ID="link_tab11" runat="server" href="#tab15" role="tab" data-toggle="dropdown" itemid="15" ControlID="btn_auxiliar">CONDICIONES LEY RPA
                                                    </asp:LinkButton>
                                                    <ul class="dropdown-menu" role="menu">
                                                        <li id="li_articulo134bis" runat="server" visible="true">
                                                            <asp:LinkButton ID="link_tab11_1" runat="server" href="#tab11" aria-controls="tab11" data-toggle="tab" OnClick="link_tab11_1_Click">Artículo 134-bis
                                                            </asp:LinkButton>
                                                        </li>
                                                        <li id="li_planmotivacional" runat="server">
                                                            <asp:LinkButton ID="link_tab11_2" runat="server" href="#tab12" aria-controls="tab12" data-toggle="tab">Plan Motivacional
                                                            </asp:LinkButton>
                                                        </li>
                                                        <%--  <li id="li_derivacionpre" runat="server">
                                                            <asp:LinkButton ID="link_tab11_3" runat="server" href="#tab13" aria-controls="tab13" data-toggle="tab">Derivación PRE
                                                            </asp:LinkButton>
                                                        </li>--%>
                                                        <li id="li_flexibilizacion" runat="server">
                                                            <asp:LinkButton ID="link_tab11_4" runat="server" href="#tab14" aria-controls="tab14" data-toggle="tab">Flexibilización
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>

                                        <div class="tab-content">

                                            <%-- Solicitud Diligencias --%>
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab1" runat="server">

                                                <asp:Panel ID="pnl_utab1" runat="server" Visible="true">
                                                    <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                                                        TargetControlID="btn001"
                                                        PopupControlID="modal_ingreso_nuevo"
                                                        DropShadow="True"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal1">
                                                    </ajax:ModalPopupExtender>
                                                    <ajax:ModalPopupExtender ID="mpe12" BehaviorID="mpe1a2" runat="server"
                                                        TargetControlID="btn0012"
                                                        PopupControlID="modal_ingreso_nuevo2b"
                                                        DropShadow="True"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal12">
                                                    </ajax:ModalPopupExtender>



                                                    <div class="subtitulo-form">
                                                        <h4>Solicitud de Diligencias</h4>
                                                    </div>
                                                    <asp:UpdatePanel runat="server" ID="upDiligencias" UpdateMode="Conditional">
                                                        <ContentTemplate>

                                                            <div class="table-condensed">
                                                                <div class="pull-right">
                                                                    <%--<asp:LinkButton runat="server" ID="refrescarDiligencias" OnClick="refrescarDiligencias_Click" CssClass="btn btn-info input-sm" CausesValidation="false" style="display:none;" ><span>Refrescar Tabla</span></asp:LinkButton>--%>
                                                                    <asp:Button runat="server" ID="refrescarDiligencias" OnClick="refrescarDiligencias_Click" CausesValidation="false" Text="refrescar tabla" Style="display: none;" />
                                                                </div>
                                                                <asp:Label ID="lbl001" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                                                                <asp:GridView ID="grd002" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd002_RowCommand1">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ICodDiligencia" HeaderText="Código"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha Solicitud" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Solicitante"></asp:BoundField>
                                                                        <asp:BoundField DataField="NombreCompleto" HeaderText="Profesional / Técnico "></asp:BoundField>
                                                                        <asp:BoundField DataField="DescripcionTipo" HeaderText="Diligencias"></asp:BoundField>
                                                                        <asp:BoundField DataField="Realizada" HeaderText="Fue Realizada"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaRealizada" DataFormatString="{0:d}" HeaderText="Fecha Realizaci&#243;n" HtmlEncode="False"></asp:BoundField>
                                                                        <%--<asp:TemplateField Visible="false" ControlStyle-CssClass="rut">
                                                                            <ItemTemplate>



                                                                                <asp:LinkButton ID="LBL1" Text="Modificar" OnClientClick='<%# string.Concat("return LlamaUtab1(", Eval("ICodDiligencia")   ,");")%>' CommandName="M" runat="server" />
                                                                                <div class="popupConfirmation" id="modal_utab1" style="display: none">
                                                                                    <div class="botonera pull-right">
                                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrarModalU1" runat="server" Text="Cerrar" CausesValidation="False" />
                                                                                    </div>
                                                                                </div>

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:ButtonField Text="Modificar" CommandName="M" HeaderText="Seleccionar" />
                                                                        <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>

                                                                    </Columns>
                                                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                                                </asp:GridView>

                                                            </div>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <table class="table table-borderless tabla-tabs">
                                                        <tr>
                                                            <td>
                                                                <div class="botonera pull-right">
                                                                    <asp:LinkButton ID="btn001" runat="server" CssClass="btn btn-info btn-sm " OnClientClick="return MostrarModalSolicitudDiligencia();" CausesValidation="False">
                                                                                    <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Nueva Solicitud
                                                                    </asp:LinkButton>
                                                                    <asp:Button ID="btn0012" runat="server" CssClass="invisible" OnClientClick="return MostrarModalUtab1();" CausesValidation="False" />
                                                                    <asp:Label ID="lb_guardar_datos" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div class="popupConfirmation" id="modal_ingreso_nuevo" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <%--botonera pull-right--%>
                                                            <div class="pull-right">
                                                                <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                     <span aria-hidden="true">&times;</span>
                                                                </asp:LinkButton>
                                                            </div>
                                                            <h4 class="modal-title text-center">SOLICITUD DILIGENCIAS</h4>

                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_Solicitud_Diligencia" frameborder="0" runat="server"></iframe>
                                                        </div>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_nuevo2b" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal12" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">SOLICITUD DILIGENCIAS</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_Solicitud_Diligencia2" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>

                                                </asp:Panel>

                                            </div>

                                            <%-- Datos de Salud --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab2" runat="server">
                                                <asp:Panel ID="pnl_utab2" runat="server" Visible="true">
                                                    <%--modal botones de modal--%>
                                                    <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                                                        TargetControlID="btn002ds"
                                                        PopupControlID="modal_ingreso_nuevo2"
                                                        DropShadow="true"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal2">
                                                    </ajax:ModalPopupExtender>

                                                    <ajax:ModalPopupExtender ID="mpe3" BehaviorID="mpe3a" runat="server"
                                                        TargetControlID="btn003ds"
                                                        PopupControlID="modal_ingreso_nuevo3"
                                                        DropShadow="true"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal3">
                                                    </ajax:ModalPopupExtender>

                                                    <ajax:ModalPopupExtender ID="mpe4" BehaviorID="mpe4a" runat="server"
                                                        TargetControlID="btn004"
                                                        PopupControlID="modal_ingreso_nuevo4"
                                                        DropShadow="true"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal4">
                                                    </ajax:ModalPopupExtender>

                                                    <%--modal que ejecuta los modificar--%>
                                                    <ajax:ModalPopupExtender ID="mpeutab2a" BehaviorID="mpe_utab2a" runat="server"
                                                        TargetControlID="bntEscondido_utab2a"
                                                        PopupControlID="modal_ingreso_utab2a"
                                                        DropShadow="True"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal_utab2a">
                                                    </ajax:ModalPopupExtender>

                                                    <ajax:ModalPopupExtender ID="mpeutab2b" BehaviorID="mpe_utab2b" runat="server"
                                                        TargetControlID="bntEscondido_utab2b"
                                                        PopupControlID="modal_ingreso_utab2b"
                                                        DropShadow="True"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal_utab2b">
                                                    </ajax:ModalPopupExtender>

                                                    <ajax:ModalPopupExtender ID="mpeutab2c" BehaviorID="mpe_utab2c" runat="server"
                                                        TargetControlID="bntEscondido_utab2c"
                                                        PopupControlID="modal_ingreso_utab2c"
                                                        DropShadow="True"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal_utab2c">
                                                    </ajax:ModalPopupExtender>


                                                    <h4 class="subtitulo-form">
                                                        <asp:Label ID="Label1" runat="server" Text="Discapacidad" /></h4>





                                                    <asp:Button runat="server" ID="triggerUpdateDiscapacidad" OnClick="triggerUpdateDiscapacidad_Click" CausesValidation="false" CssClass="invisible" />

                                                    <asp:UpdatePanel runat="server" ID="updateDiscapacidad" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grd003" CssClass="table table-bordered table-hover tabla-tabs" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd003_RowCommand1" EmptyDataText="No Existen Datos">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ICodDiscapacidad" HeaderText="Codigo"></asp:BoundField>
                                                                    <asp:BoundField DataField="FechaDiagnostico" HeaderText="Fecha Diagnostico" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                                    <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo discapacidad">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DescripcionNivel" HeaderText="Nivel"></asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="T&#233;cnico">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Seleccionar">
                                                                        <ItemTemplate>
                                                                            <%--<a id="aaa" runat="server" class="ifancybox_SolDil" href='<%# string.Concat("ninos_discapacidad.aspx?ICodDiscapacidad=", Eval("ICodDiscapacidad"),"&dir=DatosdeGestion.aspx")%>'>Modificar</a>--%>

                                                                            <asp:LinkButton ID="btnModal2a" Text="Modificar" OnClientClick='<%# string.Concat("return Llama_Utab2a(", Eval("ICodDiscapacidad")   ,");")%>' runat="server" />

                                                                            <div class="popupConfirmation" id="modal_utab2a" style="display: none">
                                                                                <div class="botonera pull-right">
                                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrarModalUtab2a" runat="server" Text="Cerrar" CausesValidation="False" />
                                                                                </div>
                                                                            </div>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:ButtonField CommandName="E" Text="Eliminar" HeaderText="Seleccionar"></asp:ButtonField>
                                                                </Columns>
                                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="botonera pull-right">
                                                        <asp:LinkButton ID="btn002ds" runat="server" CssClass="btn btn-info btn-sm btn-large" OnClientClick="return MostrarModalDatosSaludAgregarDiscapacidad();" CausesValidation="False">
                                                                     <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Discapacidad
                                                        </asp:LinkButton>
                                                    </div>




                                                    <asp:TextBox ID="txtpos003" runat="server" CssClass="invisible"></asp:TextBox>
                                                    <h4 class="subtitulo-form">
                                                        <asp:Label ID="lbl002" runat="server" Text="Hechos de Salud" /></h4>




                                                    <asp:Button runat="server" ID="triggerHechosSalud" OnClick="triggerHechosSalud_Click" CausesValidation="false" CssClass="invisible" />
                                                    <asp:UpdatePanel runat="server" ID="updateHechosSalud" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grd004" CssClass="table table-bordered table-hover tabla-tabs" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd004_RowCommand" EmptyDataText="No Existen Datos">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ICodHechosdeSalud" HeaderText="Codigo"></asp:BoundField>
                                                                    <asp:BoundField DataField="FechaDiagnostico" HeaderText="Fecha Diagnostico" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                                    <asp:BoundField DataField="DescripcionHecho" HeaderText="Hecho de Salud"></asp:BoundField>
                                                                    <asp:BoundField DataField="DescripcionTipo" HeaderText="Atenci&#243;n">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DescripcionLugar" HeaderText="Lugar">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="T&#233;cnico">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Seleccionar">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnModal2b" Text="Modificar" OnClientClick='<%# string.Concat("return Llama_Utab2b(", Eval("ICodHechosdeSalud")   ,");")%>' runat="server" />
                                                                            <div class="popupConfirmation" id="modal_utab2b" style="display: none">
                                                                                <div class="botonera pull-right">
                                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrarModalUtab2b" runat="server" Text="Cerrar" CausesValidation="False" />
                                                                                </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:ButtonField CommandName="E" Text="Eliminar" HeaderText="Seleccionar"></asp:ButtonField>
                                                                </Columns>
                                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                <RowStyle CssClass="caja-tabla table-bordered" />

                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="botonera pull-right">
                                                        <asp:LinkButton ID="btn003ds" runat="server" CssClass="btn btn-info btn-sm btn-large " OnClientClick="return MostrarModalDatosSaludAgregarHechosSalud();" CausesValidation="False">
                                                                   <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Hechos de Salud
                                                        </asp:LinkButton>
                                                    </div>

                                                    <asp:TextBox ID="txtpos004" runat="server" CssClass="invisible"></asp:TextBox>
                                                    <asp:Button runat="server" ID="triggerUpdateEnfermedadesCronicas" OnClick="triggerUpdateEnfermedadesCronicas_Click" CssClass="invisible" CausesValidation="false" />
                                                    <h4 class="subtitulo-form">
                                                        <asp:Label ID="Label3" runat="server" Text="Enfermedades Crónicas" /></h4>





                                                    <asp:UpdatePanel runat="server" ID="updateEnfermedadesCronicas" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grd005" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd005_RowCommand" EmptyDataText="No Existen Datos">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ICodEnfermedadCronica" HeaderText="Codigo"></asp:BoundField>
                                                                    <asp:BoundField DataField="FechaInicioDiagnostico" HeaderText="Fecha Inicio Diagnostico" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                                    <asp:BoundField DataField="FechaTerminoDiagnostico" HeaderText="Fecha Termino Diagnostico" DataFormatString="{0:d}" HtmlEncode="False" Visible="False"></asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Enfermedad"></asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="T&#233;cnico">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Seleccionar">
                                                                        <ItemTemplate>
                                                                            <%--<a id="aaa" runat="server" class="ifancybox_SolDil" href='<%# string.Concat("ninos_enfermedadescronicas.aspx?ICodEnfermedadCronica=", Eval("ICodEnfermedadCronica"),"&dir=DatosdeGestion.aspx")%>'>Modificar</a>--%>
                                                                            <asp:LinkButton ID="btnModal2c" Text="Modificar" OnClientClick='<%# string.Concat("return Llama_Utab2c(", Eval("ICodEnfermedadCronica")   ,");")%>' runat="server" />
                                                                            <div class="popupConfirmation" id="modal_utab2c" style="display: none">
                                                                                <div class="botonera pull-right">
                                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrarModalUtab2c" runat="server" Text="Cerrar" CausesValidation="False" />
                                                                                </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:ButtonField CommandName="E" Text="Eliminar" HeaderText="Seleccionar"></asp:ButtonField>
                                                                </Columns>
                                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="botonera pull-right">
                                                        <asp:LinkButton ID="btn004" runat="server" OnClientClick="return MostrarModalDatosSaludAgregarEnfermedadCronica();" CssClass="btn btn-info btn-sm btn-large">
                                                                    <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Enfermedad Crónica
                                                        </asp:LinkButton>
                                                    </div>
                                                    <asp:TextBox ID="txtpos005" runat="server" CssClass="invisible"></asp:TextBox>
                                                    <table class="table table-borderless table-condensed table-col-fix">
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="lblError" runat="server" CssClass="help-block" Text="No puede eliminar una discapacidad en un mes cerrado" Visible="False" Width="100%"></asp:Label>
                                                                <asp:Button ID="Button3" runat="server" Text="Volver" CssClass="btn btn-info btn-sm btn-ancho-100" CausesValidation="False" OnClick="btn005_Click" Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <%--boton invisible que lanza el modal--%>
                                                    <div class="botonera pull-right">
                                                        <asp:Button ID="bntEscondido_utab2a" runat="server" CssClass="invisible" OnClientClick="return MostrarModalDiscapacidad_Utab2a();" CausesValidation="False" />
                                                    </div>
                                                    <div class="botonera pull-right">
                                                        <asp:Button ID="bntEscondido_utab2b" runat="server" CssClass="invisible" OnClientClick="return MostrarModalHechosSalud_Utab2b();" CausesValidation="False" />
                                                    </div>
                                                    <div class="botonera pull-right">
                                                        <asp:Button ID="bntEscondido_utab2c" runat="server" CssClass="invisible" OnClientClick="return MostrarModalEnfermedadCronica_Utab2c();" CausesValidation="False" />
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_utab2a" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal_utab2a" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">DISCAPACIDAD</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_discapacidad_utab2a" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_utab2b" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal_utab2b" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">HECHOS DE SALUD</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_hechossalud_utab2b" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_utab2c" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal_utab2c" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">ENFERMEDAD CRÓNICA</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_enfermedadcronica_utab2c" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_nuevo2" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">DISCAPACIDAD</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_Datos_Salud_Agregar_Discapacidad" src="ninos_discapacidad.aspx?&dir=DatosdeGestion.aspx" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_nuevo3" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal3" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">HECHOS SALUD</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_Datos_Salud_Agregar_Hechos_Salud" src="ninos_hechosdesalud.aspx?&dir=DatosdeGestion.aspx" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_nuevo4" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal4" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">ENFERMEDAD CRONICA</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_Datos_Salud_Agregar_Enfermedad_Cronica" src="ninos_enfermedadescronicas.aspx?dir=DatosdeGestion.aspx" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>

                                            <%-- Informe Diagnóstico --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab3" runat="server">
                                                <asp:Panel ID="pnl_utab3" runat="server" Visible="true">

                                                    <asp:UpdatePanel runat="server" ID="upTabInformeDiag" UpdateMode="Conditional">
                                                        <ContentTemplate>


                                                            <%--modal que ejecuta los modificar--%>
                                                            <ajax:ModalPopupExtender ID="mpeutab3a" BehaviorID="mpe_utab3a" runat="server"
                                                                TargetControlID="bntEscondido_utab3a"
                                                                PopupControlID="modal_ingreso_utab3a"
                                                                DropShadow="True"
                                                                BackgroundCssClass="modalBackground"
                                                                CancelControlID="btnCerrarModal_utab3a">
                                                            </ajax:ModalPopupExtender>

                                                            <%--tabla encabezado de diagnostico (agregar)--%>
                                                            <asp:GridView ID="grd0012f" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="grd0012f_RowCommand" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ICodInformeDiagnostico" HeaderText="Nº Diagnóstico"></asp:BoundField>
                                                                    <asp:BoundField DataField="FechaInicioInforme" DataFormatString="{0:d}" HeaderText="Fecha Inicio" HtmlEncode="False"></asp:BoundField>
                                                                    <asp:BoundField DataField="DescripcionTipodiag" HeaderText="Tipo Diagnóstico"></asp:BoundField>
                                                                    <asp:BoundField DataField="descripTermino" HeaderText="Término Diagnóstico"></asp:BoundField>
                                                                    <asp:BoundField DataField="fechaTerminoInforme" DataFormatString="{0:d}" HeaderText="Fecha Término" HtmlEncode="False"></asp:BoundField>
                                                                    <asp:ButtonField Text="Ver" HeaderText="Seleccionar"></asp:ButtonField>
                                                                </Columns>
                                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                                            </asp:GridView>

                                                            <table class="table table-bordered table-condensed tabla-tabs" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="titulo-tabla col-md-1" scope="row">Fecha de Inicio del Informe *</th>
                                                                        <td class="col-md-4">
                                                                            <asp:TextBox ID="cal001" CssClass="form-control form-control-fecha-large input-sm" runat="server" Text="Seleccione Fecha" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2_cal001" runat="server" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtender2_cal001" />
                                                                            <asp:RangeValidator ID="RangeValidator328" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ControlToValidate="cal001" Type="Date" MaximumValue="31-12-2020" MinimumValue="1000-01-01" ValidationGroup="grupo1" />
                                                                            <asp:Label ID="lbl004_2f" runat="server" CssClass="help-block" Visible="false"></asp:Label>
                                                                        </td>

                                                                        <th class="titulo-tabla col-md-1" scope="row">Tipo de Diagnóstico *</th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server">
                                                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                                                <asp:ListItem Value="1">Ambulatoria</asp:ListItem>
                                                                                <asp:ListItem Value="2">Residencial</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <div class="botonera pull-right">
                                                                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger btn-sm fixed-width-button" runat="server" OnClick="lnk001_Click" Visible="False"> 
                                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Nuevo</asp:LinkButton>
                                                                <asp:LinkButton ID="btn008" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn008_Click" Text="" CausesValidation="False">
                                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Informe
                                                                </asp:LinkButton>


                                                            </div>
                                                            <br />


                                                            <%--boton invisible que lanza el modal--%>
                                                            <div class="botonera pull-right">
                                                                <asp:Button ID="bntEscondido_utab3a" runat="server" CssClass="invisible" OnClientClick="return MostrarModalEtapasDiagnostico_Utab3a();" CausesValidation="False" />
                                                            </div>
                                                            <div class="popupConfirmation" id="modal_ingreso_utab3a" style="display: none">
                                                                <div class="modal-header header-modal">
                                                                    <asp:LinkButton ID="btnCerrarModal_utab3a" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                                    </asp:LinkButton>
                                                                    <h4 class="modal-title">ETAPA DIAGNOSTICO</h4>
                                                                </div>
                                                                <div>
                                                                    <asp:UpdatePanel runat="server" ID="upInformeDiag">
                                                                        <ContentTemplate>
                                                                            <iframe id="iframe_etapasdiagnostico_utab3a" runat="server" frameborder="0"></iframe>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <br />



                                                            <asp:Panel ID="divDetalleDiag" Width="100%" runat="server">

                                                                <asp:Panel ID="Panel1" Width="100%" runat="server">



                                                                    <asp:Panel ID="divEtapasDiag" runat="server">
                                                                        <hr />
                                                                        <h4 class="subtitulo-form">Etapas Realizadas del Diagnóstico</h4>
                                                                        <asp:GridView ID="grd007" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="grd007_RowCommand" Width="100%">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="IcodEtapa" HeaderText="CodEtapasIntervencion"></asp:BoundField>
                                                                                <asp:BoundField DataField="Descripcion" HeaderText="Etapas de Intervencion"></asp:BoundField>
                                                                                <asp:BoundField DataField="FechaEtapa" DataFormatString="{0:d}" HeaderText="Fecha" HtmlEncode="False"></asp:BoundField>
                                                                                <asp:ButtonField CommandName="M" Text="Modificar" Visible="False" HeaderText="Seleccionar"></asp:ButtonField>
                                                                                <asp:ButtonField CommandName="E" Text="Eliminar" Visible="False" HeaderText="Seleccionar"></asp:ButtonField>
                                                                            </Columns>
                                                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                            <RowStyle CssClass="table-bordered caja-tabla" />
                                                                        </asp:GridView>
                                                                        <table class="table table-bordered table-condensed">
                                                                            <tbody>

                                                                                <tr>
                                                                                    <th class="titulo-tabla col-md-1">
                                                                                        <label for="">Etapa:</label>
                                                                                    </th>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddl_EtapasRealizadas" Visible="true" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:LinkButton ID="btn006" runat="server" AutoPostback="true" CssClass="btn btn-warning btn-sm fixed-width-button pull-right" Visible="true" CausesValidation="false" OnClick="btn006_Click">
                                                                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar Etapa
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>

                                                                        <asp:Label ID="lbl0032f" runat="server" CssClass="help-block"></asp:Label>
                                                                    </asp:Panel>

                                                                    <asp:Panel ID="divAccionesDiag" runat="server">
                                                                        <div>
                                                                            <hr />
                                                                            <h4 class="subtitulo-form">Acciones del Diagnóstico</h4>
                                                                            <asp:GridView ID="grd008" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" OnRowCommand="grd008_RowCommand1">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Icodaccion" HeaderText="Icodaccion"></asp:BoundField>
                                                                                    <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo de Intervencion"></asp:BoundField>
                                                                                    <asp:BoundField DataField="FechaAccion" DataFormatString="{0:d}" HeaderText="Fecha" HtmlEncode="False"></asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <%--<a id="aaa4" runat="server" class="ifancybox" href='<%# string.Concat("accionesinformediagnostico.aspx?icodaccion=", Eval("Icodaccion"),"&sw=true&dir=DatosdeGestion.aspx")%>'>Modificar</a>--%>
                                                                                            <asp:LinkButton ID="btnModal3a" Text="Modificar" OnClientClick='<%# string.Concat("return Llama_Utab3a(", Eval("Icodaccion")   ,");")%>' runat="server" />
                                                                                            <div class="popupConfirmation" id="modal_utab3a" style="display: none">
                                                                                                <div class="botonera pull-right">
                                                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrarModalUtab3a" runat="server" Text="Cerrar" CausesValidation="False" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:ButtonField CommandName="E" Text="Eliminar" HeaderText="Seleccionar"></asp:ButtonField>
                                                                                </Columns>
                                                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                                <RowStyle CssClass="table-bordered caja-tabla" />
                                                                            </asp:GridView>



                                                                            <div>
                                                                                <asp:Label ID="lbl0022f" runat="server" CssClass="help-block" Width="617px"></asp:Label>
                                                                            </div>
                                                                            <div class="pull-right">
                                                                                <asp:LinkButton ID="btn007" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" CausesValidation="false" OnClientClick="return MostrarModalAgregarNuevaAccionalDiagnostico();">
                                                                                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Nueva
                                                                                </asp:LinkButton>

                                                                                <%--<asp:LinkButton runat="server" ID="refrescarDiag" OnClick="refrescarDiag_Click" Text="Refrescar Tabla" CssClass="btn btn-info input-sm" CausesValidation="false"></asp:LinkButton>--%>
                                                                                <asp:LinkButton runat="server" ID="refrescarDiag" OnClick="refrescarDiag_Click" CssClass="btn btn-info input-sm fixed-width-button" CausesValidation="false" Style="display: none;">
                                                                                         <span class="glyphicon glyphicon-plus"></span>&nbsp;Refrescar Tabla
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                            <br />

                                                                            <br />
                                                                            <div class="popupConfirmation" id="divAgregarNuevaAccioNalDiagnostico" style="display: none">
                                                                                <div class="modal-header header-modal">
                                                                                    <asp:LinkButton ID="Button1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                                                    </asp:LinkButton>
                                                                                    <h4 class="modal-title">NUEVA ACCION</h4>
                                                                                </div>
                                                                                <div>
                                                                                    <iframe id="iframeAgregarNuevaAccioNalDiagnostico" runat="server" frameborder="0"></iframe>
                                                                                </div>
                                                                            </div>

                                                                            <ajax:ModalPopupExtender ID="mpeANAD" BehaviorID="mpeANAD" runat="server"
                                                                                TargetControlID="btn007"
                                                                                PopupControlID="divAgregarNuevaAccioNalDiagnostico"
                                                                                DropShadow="true"
                                                                                BackgroundCssClass="modalBackground"
                                                                                CancelControlID="Button1">
                                                                            </ajax:ModalPopupExtender>
                                                                        </div>

                                                                    </asp:Panel>

                                                                    <asp:Panel ID="TblTerminoDiag" runat="server">
                                                                        <hr />
                                                                        <h4 class="subtitulo-form">Término del Diagnóstico</h4>
                                                                        <table class="table table-bordered  table-condensed">
                                                                            <tbody>

                                                                                <tr>
                                                                                    <th class="titulo-tabla col-md-1" scope="row">Término del Diagnóstico *</th>
                                                                                    <td class="col-md-4">
                                                                                        <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm">
                                                                                        </asp:DropDownList>
                                                                                    </td>


                                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha de Término *</th>
                                                                                    <td>
                                                                                        <asp:TextBox ID="cal003" runat="server" CssClass="form-control input-sm form-control-fecha-large" OnTextChanged="cal003_ValueChanged1" Text="" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" BehaviorID="_content_CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="cal003" EndDate="<%# DateTime.Now.AddDays(1) %>" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal003" ErrorMessage="Fecha Requerida" CssClass="help-block" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="cal003" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo1"></asp:RegularExpressionValidator>
                                                                                        <asp:Label ID="lbl0012f" runat="server" CssClass="help-block"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <asp:LinkButton ID="btn0010" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button pull-right" CausesValidation="false" OnClientClick="cleanIDiagnostico(); return true;" OnClick="WebImageButton2_Click">
                                                                                                  <span class="glyphicon glyphicon-ok"></span>&nbsp;Finalizar Diagnóstico
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>

                                                                        </table>
                                                                    </asp:Panel>

                                                                    <asp:LinkButton ID="btn0062f" OnClientClick="cleanIDiagnostico(); return false;" OnClick="btn0062f_Click1" runat="server" class="btn btn-info btn-sm fixed-width-button pull-right">
                                                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                                    </asp:LinkButton>

                                                                    <br />
                                                                    <br />

                                                                    <br />

                                                                </asp:Panel>

                                                            </asp:Panel>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </asp:Panel>
                                            </div>

                                            <%-- Persona Relacionada --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab4" runat="server">
                                                <asp:Panel ID="pnl_utab4" runat="server" Visible="true">
                                                    <ajax:ModalPopupExtender ID="mpe5" BehaviorID="mpe5a" runat="server"
                                                        TargetControlID="btn005pr"
                                                        PopupControlID="modal_ingreso_nuevo5"
                                                        DropShadow="true"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal5">
                                                    </ajax:ModalPopupExtender>

                                                    <%--modal que ejecuta los modificar--%>
                                                    <ajax:ModalPopupExtender ID="mpeutab4a" BehaviorID="mpe_utab4a" runat="server"
                                                        TargetControlID="bntEscondido_utab4a"
                                                        PopupControlID="modal_ingreso_utab4a"
                                                        DropShadow="True"
                                                        BackgroundCssClass="modalBackground"
                                                        CancelControlID="btnCerrarModal_utab4a">
                                                    </ajax:ModalPopupExtender>

                                                    <h4>
                                                        <asp:Label ID="lbl005" CssClass="subtitulo-form" runat="server" Text="Personas Relacionadas con Niño(a)"></asp:Label></h4>
                                                    <asp:GridView ID="grd006" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd006_RowCommand" EmptyDataText="No Existen Datos">
                                                        <Columns>
                                                            <asp:BoundField DataField="CodPersonaRelacionada" HeaderText="CodPersonaRelacionada"></asp:BoundField>
                                                            <asp:BoundField DataField="RUT" HeaderText="RUT" Visible="False"></asp:BoundField>
                                                            <asp:BoundField DataField="Nombres" HeaderText="Nombre" Visible="False"></asp:BoundField>
                                                            <asp:BoundField DataField="DescrSitiacion" HeaderText="Situaci&#243;n 1"></asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Relación"></asp:BoundField>
                                                            <asp:BoundField DataField="FechaRelacion" HeaderText="Fecha de Relación" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Seleccionar">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnModal4a" Text="Modificar" OnClientClick='<%# string.Concat("return Llama_Utab4a(", Eval("CodPersonaRelacionada")   ,");")%>' runat="server" />
                                                                    <div class="popupConfirmation" id="modal_utab4a" style="display: none">
                                                                        <div class="botonera pull-right">
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrarModalUtab4a" runat="server" Text="Cerrar" CausesValidation="False" />
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                                    </asp:GridView>
                                                    <div class="text-right">
                                                        <asp:LinkButton ID="btn005pr" runat="server" OnClientClick=" return MostrarModalModificarPersonasRelacionadas();" class="text-right btn btn-info btn-sm " CausesValidation="False">
                                                                <span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar Persona Relacionada
                                                        </asp:LinkButton>
                                                    </div>
                                                    <div class="popupConfirmation" id="modal_ingreso_nuevo5" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal5" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">PERSONAS RELACIONADAS</h4>
                                                        </div>
                                                        <div id="gmphider" style="display: none"></div>

                                                        <div>
                                                            <iframe id="iframe_Datos_Modificar_Personas_Relacionadas" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>

                                                    <asp:Button ID="WebImageButton1" class="btn btn-info btn-sm btn-ancho-100" runat="server" Text="Volver" OnClick="btn005_Click" CausesValidation="False" Visible="False" />
                                                    <asp:LinkButton ID="lnkrefresca" runat="server" Font-Size="1px" OnClick="LinkButton1_Click"></asp:LinkButton>


                                                    <div class="botonera pull-right">
                                                        <asp:Button ID="bntEscondido_utab4a" runat="server" CssClass="invisible" OnClientClick="return MostrarModalPersonaRelacionada_Utab4a();" CausesValidation="False" />
                                                    </div>

                                                    <div class="popupConfirmation" id="modal_ingreso_utab4a" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal_utab4a" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">PERSONAS RELACIONADAS</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_personarelacionada_utab4a" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>


                                                </asp:Panel>
                                            </div>

                                            <%-- Contacto --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab5" runat="server">
                                                <asp:Panel ID="pnl_utab5" runat="server" Visible="true">

                                                    <div>
                                                        <asp:Label ID="lbl_percontacto" runat="server" CssClass="help-block"></asp:Label>
                                                    </div>
                                                    <table class="table table-bordered table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-1" scope="row">Persona Contacto *</th>
                                                            <td class="col-md-4">
                                                                <asp:TextBox ID="txt001_E" CssClass="form-control input-sm" runat="server" MaxLength="60"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt001_E" CssClass="help-block" Display="Dynamic" ErrorMessage="Ingrese Persona Contacto" ValidationGroup="gcontacto1"></asp:RequiredFieldValidator>
                                                            </td>

                                                            <th class="titulo-tabla col-md-1" scope="row">Tipo Relación Contacto *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown001_E" CssClass="form-control input-sm" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <div class="botonera pull-right">
                                                                    <asp:LinkButton ID="btn005aa" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn005aa_Click1" ValidationGroup="gcontacto1">
                                                                                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Cambiar
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton ID="Button5" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btn005_Click" Text="Volver" Visible="False"></asp:LinkButton>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>

                                            <%-- Calidad Juridica --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab6" runat="server">
                                                <asp:Panel ID="pnl_utab6" runat="server" Visible="true">
                                                    <div>
                                                        <asp:Label ID="lblLRPA_Virtual" runat="server" CssClass="help-block" Text="S-DERIVACION SIN CONTACTO CON EL ADOLESCENTE" Visible="False"></asp:Label>
                                                    </div>
                                                    <table class="table table-bordered tabla-tabs table-condensed">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-1" scope="row">Calidad Jurídica *</th>
                                                            <td class="col-md-4">
                                                                <asp:DropDownList ID="ddown_cj" CssClass="form-control  input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown_cj_SelectedIndexChanged2">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>

                                                            <th class="titulo-tabla col-md-1" scope="row">Fecha de Cambio *</th>
                                                            <td>
                                                                <asp:TextBox ID="calFechaCambio" onkeypress="return false;" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa">
                                                                </asp:TextBox>
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3_calFechaCambio" runat="server" ViewStateMode="Enabled" TargetControlID="calFechaCambio" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="calFechaCambio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>--%>

                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="calFechaCambio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />--%>

                                                                <asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right" ID="btn008aa" runat="server" OnClick="btn008aa_Click">
                                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                                                </asp:LinkButton>
                                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="Button6" runat="server" OnClick="btn005_Click" CausesValidation="False" Visible="False">
                                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Volver
                                                                </asp:LinkButton>

                                                            </td>
                                                        </tr>
                                                    </table>

                                                </asp:Panel>
                                            </div>

                                            <%-- Ordenes de Tribunal --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab7" runat="server">
                                                <br />
                                                <asp:Panel ID="pnl_utab7" runat="server" Visible="true">

                                                     <div class="alert alert-warning text-center" role="alert" id="alertOTObligatoria" runat="server" visible="false">
                                                        <span class="glyphicon glyphicon-warning-sign"></span>
                                                        <asp:Label ID="lblAlert" runat="server" Text="Es obligatorio el ingreso de una Orden de Tribunal" ></asp:Label><br />
                                                    </div>

                                                    <asp:GridView ID="grd001U2" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Tribunal" HeaderText="Tribunal"></asp:BoundField>
                                                            <asp:BoundField DataField="FechaOrden" HeaderText="Fecha Orden" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                            <asp:BoundField DataField="Expediente" HeaderText="Expediente"></asp:BoundField>
                                                            <asp:BoundField DataField="RUC" HeaderText="RUC"></asp:BoundField>
                                                            <asp:BoundField DataField="RIT" HeaderText="RIT"></asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                                    </asp:GridView>

                                                    <table id="tbl_ingreso_orden_tribunal" class="table-sinmargen table-bordered  table-condensed" runat="server">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-1" scope="row">Región *</th>
                                                            <td class="col-md-4">
                                                                <asp:DropDownList ID="ddown014" CssClass="form-control form-control-80 input-sm" OnClientClick="return false;" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Selected="True" Value="-2">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>

                                                            <th class="titulo-tabla col-md-1" scope="row">Tipo de Tribunal *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown015" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown015M_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Tribunal *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown016" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown016_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>

                                                            <th class="titulo-tabla" scope="row">Expediente</th>
                                                            <td>
                                                                <asp:TextBox ID="TextBox4" CssClass="form-control input-sm col-md-5" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">RUC</th>
                                                            <td>

                                                                <asp:TextBox ID="txt006F2" CssClass="form-control input-sm" runat="server" placeholder="YYONNNNNNN-D" MaxLength="12" />
                                                                <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt006F2" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />

                                                                <asp:Label ID="lblFormatoRUC" Visible="false" runat="server" Display="Dynamic" CssClass="help-block" Text="NUEVO Formato del RUC: YYONNNNNNN-D,  ejemplo  1010083505-6"></asp:Label>

                                                                <asp:CustomValidator ID="cv_txt006F2" runat="server" ControlToValidate="txt006F2" Display="Dynamic" CssClass="help-block" ErrorMessage="El RUC ingresado no es válido" ClientValidationFunction="ValidaRucLRPA" />

                                                            </td>


                                                            <th class="titulo-tabla" scope="row">RIT</th>
                                                            <td>
                                                                <asp:TextBox ID="txt007F2" CssClass="form-control  input-sm" runat="server" />
                                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt007F2" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Fecha</th>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="ddown017" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3_ddown017" runat="server" ViewStateMode="Enabled" TargetControlID="ddown017" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_ddown017"></ajax:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddown017" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Requerida" ValidationGroup="gfecha">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="ddown017" runat="server" ErrorMessage="Fecha Inv&aacute;lida" Display="Dynamic" CssClass="help-block" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gfecha" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <div class="botonera pull-right">
                                                                    <asp:Label ID="lblnointerviene" runat="server" CssClass="help-block" Text="Calidad Jurídica: NO INTERVIENE TRIBUNAL" Visible="false">
                                                                    </asp:Label>
                                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnOrdenesTribunal" runat="server" OnClick="btn005aa_Click2" ValidationGroup="gfecha">
                                                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Orden
                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="Button7" runat="server" OnClick="btn005_Click" CausesValidation="False" Visible="False">
                                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Volver
                                                                    </asp:LinkButton>
                                                                </div>

                                                            </td>
                                                        </tr>
                                                    </table>






                                                </asp:Panel>
                                            </div>

                                            <%-- Causales de Ingreso --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab8" runat="server">
                                                <br />
                                                <asp:Panel ID="pnl_utab8" runat="server" Visible="true">

                                                    <asp:GridView ID="grd002_2f" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="TipoCausal" HeaderText="Tipo Causal de Ingreso"></asp:BoundField>
                                                            <asp:BoundField DataField="Causal" HeaderText="Causal de Ingreso"></asp:BoundField>
                                                            <asp:BoundField DataField="CodNumCausal" HeaderText="Código Delito"></asp:BoundField>
                                                            <asp:BoundField DataField="CodEntidadAsigna" HeaderText="Entidad que Asigna"></asp:BoundField>
                                                            <asp:BoundField DataField="ICodTribunalIngreso" HeaderText="Código Tribunal" />
                                                        </Columns>
                                                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                    </asp:GridView>

                                                    <div>
                                                        <asp:Label ID="lbl_causales" runat="server" CssClass="help-block" Text="Label" Visible="False" Width="100%"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lbl_nota1" CssClass="help-block" runat="server" Text="Debe agregar de 1 a 3 causales de Ingreso."></asp:Label>
                                                    </div>
                                                    <table class="table table-bordered tabla-tabs table-condensed">
                                                        <tbody>
                                                            <tr id="tr_orden_tribunal" runat="server" visible="False">
                                                                <th class="titulo-tabla col-md-1" scope="row">
                                                                    <asp:Label ID="lbl_otc" runat="server" Text="Orden de Tribunal" Visible="True"></asp:Label>
                                                                </th>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="ddown_otc" runat="server" AppendDataBoundItems="True" CssClass="form-control form-control-80 input-sm" Visible="True">
                                                                        <asp:ListItem Value="0">Seleccionar </asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla col-md-1" scope="row">Tipo Causal de Ingreso *</th>
                                                                <td class="col-md-4">
                                                                    <asp:DropDownList ID="ddown018" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control form-control-80 input-sm" OnSelectedIndexChanged="ddown018M_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>

                                                                <th class="titulo-tabla col-md-1" scope="row">Causal de Ingreso *</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown019" runat="server" AutoPostBack="True" CssClass="form-control form-control-80 input-sm" OnSelectedIndexChanged="ddown019_SelectedIndexChanged1">
                                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Código del Delito</th>
                                                                <td>
                                                                    <asp:TextBox ID="txt006" runat="server" CssClass="form-control input-sm form-control-30" ReadOnly="True"></asp:TextBox>
                                                                    <ajax:MaskedEditExtender ID="txt006_MaskedEditExtender1" runat="server" BehaviorID="_content_txt006_MaskedEditExtender1" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" InputDirection="RightToLeft" Mask="9999999" MaskType="Number" TargetControlID="txt006" />
                                                                    <ajax:MaskedEditValidator ID="MaskedEditValidator6" runat="server" ControlExtender="txt006_MaskedEditExtender1" ControlToValidate="txt006" Display="Dynamic" EmptyValueMessage="Ingrese Código Delito" ErrorMessage="MaskedEditValidator6" InvalidValueMessage="Código Delito inválido" IsValidEmpty="False" MinimumValue="1111111" MinimumValueMessage="Código Delito Debe Ser Mayor a Cero" TooltipMessage="Código Delito"></ajax:MaskedEditValidator>
                                                                </td>

                                                                <th class="titulo-tabla" scope="row">Entidad que Asigna *</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown020" runat="server" AppendDataBoundItems="True" CssClass="form-control form-control-80 input-sm">
                                                                        <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                        <asp:ListItem Value="E">ESTABLECIMIENTO</asp:ListItem>
                                                                        <asp:ListItem Value="P">POLICIA</asp:ListItem>
                                                                        <asp:ListItem Value="T">TRIBUNAL</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="botonera pull-right">
                                                                        <asp:LinkButton ID="btnback003" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btnback003_Click">
                                                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Causal
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>






                                                </asp:Panel>
                                            </div>

                                            <%-- Medida o Sancion --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab9" runat="server">
                                                <asp:Panel ID="pnl_utab9" runat="server" Visible="true">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <uc2:ninos_MedidaOSancion runat="server" ID="ninos_MedidaOSancion" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </asp:Panel>
                                            </div>

                                            <%-- Situación Migratoria --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab10" runat="server">

                                                <asp:Panel ID="pnl_utab10" runat="server" Visible="true">
                                                    <asp:HiddenField ID="icod_situacion_migratoria" runat="server" Value="0" />
                                                    <%--aqui va ascx migracion--%>
                                                    <uc2:niños_migracion runat="server" ID="niños_migracion" />
                                                    <%--<uc2:niños_migracion2 runat="server" ID="niños_migracion2" />--%>
                                                    <%--<table class="table table-bordered table-col-fix table-condensed">
                                                        <tbody>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Situación Migratoria</th>
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_situacion_si" runat="server" GroupName="sm" Text="Si" Visible="True" AutoPostBack="true" OnCheckedChanged="control_controles" />
                                                                                <asp:RadioButton ID="rb_situacion_no" runat="server" GroupName="sm" Text="No" Visible="True" AutoPostBack="true" Checked="true" OnCheckedChanged="control_controles" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="dd_situacion_migratoria" CssClass="form-control input-sm" runat="server" Enabled="false">
                                                                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Con regularización migratoria</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Refugiado</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Solicitante de refugio</asp:ListItem>
                                                                                    <asp:ListItem Value="4">En proceso de retorno protegido</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Desplazado (conflicto bélico/económico)</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Víctima trafico de personas</th>
                                                                <td>
                                                                    <asp:RadioButton ID="rb_victima_trafico_si" runat="server" GroupName="vtp" Text="Si" Visible="True" Enabled="true" />
                                                                    <asp:RadioButton ID="rb_victima_trafico_no" runat="server" GroupName="vtp" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Documentacón migratoria</th>
                                                                <td>
                                                                    <table class="table table-bordered table-col-fix table-condensed">
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Cuenta con documentos de extranjero residente</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_extranjero_residente_si" runat="server" GroupName="documentos_extranjero" Text="Si" Visible="True" Enabled="true" AutoPostBack="true" OnCheckedChanged="control_extranjero" />
                                                                                <asp:RadioButton ID="rb_extranjero_residente_no" runat="server" GroupName="documentos_extranjero" Text="No" Visible="True" Enabled="true" AutoPostBack="true" Checked="true" OnCheckedChanged="control_extranjero" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_n_documento_extranjero" runat="server" placeholder="N° Documento" Enabled="false" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Partida de nacimiento de pais de origen</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_partida_nacimiento_si" runat="server" GroupName="partida_nacimiento" Text="Si" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_partida_nacimiento_no" runat="server" GroupName="partida_nacimiento" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Pasaporte o cédula de identidad del pais de origen</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_pasaporte_cedula_si" runat="server" GroupName="pasaporte_cedula" Text="Si" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_pasaporte_cedula_no" runat="server" GroupName="pasaporte_cedula" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Tarjeta de turismo (entregada por PDI)</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_tarjeta_turismo_si" runat="server" GroupName="tarjeta_turismo" Text="Si" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_tarjeta_turismo_no" runat="server" GroupName="tarjeta_turismo" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Autorización de viaje entregada por padres (notarial o judicial)</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_autorizacion_viaje_si" runat="server" GroupName="autorizacion_viaje" Text="Si" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_autorizacion_viaje_no" runat="server" GroupName="autorizacion_viaje" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Autorización de residencia entregada por padres (notarial o judicial)</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_autorizacion_viaje2_si" runat="server" GroupName="autorizacion_viaje2" Text="Si" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_autorizacion_viaje2_no" runat="server" GroupName="autorizacion_viaje2" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Documento de escolaridad del pais de origen</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_documento_escolaridad_si" runat="server" GroupName="documento_escolaridad" Text="Si" Visible="True" Enabled="true" AutoPostBack="true" OnCheckedChanged="control_escolaridad" />
                                                                                <asp:RadioButton ID="rb_documento_escolaridad_no" runat="server" GroupName="documento_escolaridad" Text="No" Visible="True" Enabled="true" AutoPostBack="true" Checked="true" OnCheckedChanged="control_escolaridad" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_nivel_escolaridad" runat="server" placeholder="Nivel de escolaridad" Enabled="false" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Documento de salud de país de origen</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_documento_salud_si" runat="server" GroupName="documento_salud" Text="Si" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_documento_salud_no" runat="server" GroupName="documento_salud" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <tr>
                                                                        <th class="titulo-tabla" scope="row">Proceso de migración</th>
                                                                        <td>
                                                                            <table class="table table-bordered table-col-fix table-condensed">
                                                                                <tr>
                                                                                    <th class="titulo-tabla" scope="row">Fecha ingreso actual a chile</th>
                                                                                    <td>
                                                                                    <asp:TextBox ID="cal_ingreso_chile" runat="server" VALUE="" class="form-control form-control-40 input-sm" />
                                                                                    <ajax:CalendarExtender ID="CalendarExtende1041" runat="server" Enabled="true" Format="MM-yyyy" TargetControlID="cal_ingreso_chile" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                                    <asp:RangeValidator ID="RangeValidator1041" runat="server" Text="Fecha Invalida" ControlToValidate="cal_ingreso_chile" Type="Date" MaximumValue="2010-01-01" MinimumValue="1900-01-01" />
                                                                                        <asp:TextBox ID="txt_mes" runat="server" placeholder="Mes" MaxLength="2" Enabled="true" />
                                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_mes" ValidChars="0123456789" />
                                                                                        <asp:TextBox ID="txt_ano" runat="server" placeholder="Año" MaxLength="4" Enabled="true" />
                                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_ano" ValidChars="0123456789" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th class="titulo-tabla" scope="row">Paso fronterizo por el cual ingresa a chile</th>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rb_paso_fronterizo_si" runat="server" GroupName="paso_fronterizo" Text="Habilitado" Visible="True" Enabled="true" />
                                                                                                    <asp:RadioButton ID="rb_paso_fronterizo_no" runat="server" GroupName="paso_fronterizo" Text="No Habilitado" Visible="True" Enabled="true" Checked="true" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_paso_fronterizo" runat="server" placeholder="¿Cual?" Enabled="true" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th class="titulo-tabla" scope="row">NNA ¿Ha tenido ingresos anteriores a Chile?</th>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rb_ingresos_chile_si" runat="server" GroupName="ingresos_chile" Text="Si" Visible="True" Enabled="true" />
                                                                                                    <asp:RadioButton ID="rb_ingresos_chile_no" runat="server" GroupName="ingresos_chile" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_ingreso_chile" runat="server" placeholder="¿Cuántos?" Enabled="true" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th class="titulo-tabla" scope="row">NNA ¿Ha transitado con anterioridad en otros países?</th>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:RadioButton ID="rb_otros_paises_si" runat="server" GroupName="otros_paises" Text="Si" Visible="True" Enabled="true" />
                                                                                                    <asp:RadioButton ID="rb_otros_paises_no" runat="server" GroupName="otros_paises" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txt_otros_paises" runat="server" placeholder="¿Cuántos?" Enabled="true" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th class="titulo-tabla" scope="row">Ciudad de origen o residencia</th>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txt_ciudad_origen" runat="server" placeholder="Ingrese la ciudad" Enabled="true" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th class="titulo-tabla" scope="row">Motivo de ingreso a Chile del NNA</th>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="dd_motivo_ingreso" CssClass="form-control input-sm" runat="server" Enabled="true">
                                                                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Reunificación familiar</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Búsqueda de trabajo</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Estudios</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Turismo</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Traslado familiar (familia inmigrante)</asp:ListItem>
                                                                                            <asp:ListItem Value="6">Comercio (familia comerciante)</asp:ListItem>
                                                                                            <asp:ListItem Value="7">Bienestar familiar</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Dominio de idiomas</th>
                                                                <td>
                                                                    <table class="table table-bordered table-col-fix table-condensed">
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Español</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_01_0" runat="server" GroupName="espanol" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_01_1" runat="server" GroupName="espanol" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_01_2" runat="server" GroupName="espanol" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_01_3" runat="server" GroupName="espanol" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_01_4" runat="server" GroupName="espanol" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Mapudungun</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_02_0" runat="server" GroupName="mapudungun" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_02_1" runat="server" GroupName="mapudungun" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_02_2" runat="server" GroupName="mapudungun" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_02_3" runat="server" GroupName="mapudungun" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_02_4" runat="server" GroupName="mapudungun" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Aimara</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_03_0" runat="server" GroupName="aimara" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_03_1" runat="server" GroupName="aimara" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_03_2" runat="server" GroupName="aimara" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_03_3" runat="server" GroupName="aimara" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_03_4" runat="server" GroupName="aimara" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Quechua</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_04_0" runat="server" GroupName="quechua" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_04_1" runat="server" GroupName="quechua" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_04_2" runat="server" GroupName="quechua" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_04_3" runat="server" GroupName="quechua" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_04_4" runat="server" GroupName="quechua" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Guaraní</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_05_0" runat="server" GroupName="guarani" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_05_1" runat="server" GroupName="guarani" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_05_2" runat="server" GroupName="guarani" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_05_3" runat="server" GroupName="guarani" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_05_4" runat="server" GroupName="guarani" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Creole (Haití)</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_06_0" runat="server" GroupName="creole" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_06_1" runat="server" GroupName="creole" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_06_2" runat="server" GroupName="creole" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_06_3" runat="server" GroupName="creole" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_06_4" runat="server" GroupName="creole" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Náhuatl</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_07_0" runat="server" GroupName="nahualt" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_07_1" runat="server" GroupName="nahualt" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_07_2" runat="server" GroupName="nahualt" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_07_3" runat="server" GroupName="nahualt" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_07_4" runat="server" GroupName="nahualt" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Inglés</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_08_0" runat="server" GroupName="ingles" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_08_1" runat="server" GroupName="ingles" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_08_2" runat="server" GroupName="ingles" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_08_3" runat="server" GroupName="ingles" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_08_4" runat="server" GroupName="ingles" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Francés</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_09_0" runat="server" GroupName="frances" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_09_1" runat="server" GroupName="frances" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_09_2" runat="server" GroupName="frances" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_09_3" runat="server" GroupName="frances" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_09_4" runat="server" GroupName="frances" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Portugués</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_10_0" runat="server" GroupName="portugues" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_10_1" runat="server" GroupName="portugues" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_10_2" runat="server" GroupName="portugues" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_10_3" runat="server" GroupName="portugues" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_10_4" runat="server" GroupName="portugues" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Chino Mandarín</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_11_0" runat="server" GroupName="chino_mandarin" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_11_1" runat="server" GroupName="chino_mandarin" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_11_2" runat="server" GroupName="chino_mandarin" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_11_3" runat="server" GroupName="chino_mandarin" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_11_4" runat="server" GroupName="chino_mandarin" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Árabe</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_12_0" runat="server" GroupName="arabe" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_12_1" runat="server" GroupName="arabe" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_12_2" runat="server" GroupName="arabe" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_12_3" runat="server" GroupName="arabe" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_12_4" runat="server" GroupName="arabe" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Sueca</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_13_0" runat="server" GroupName="sueca" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_13_1" runat="server" GroupName="sueca" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_13_2" runat="server" GroupName="sueca" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_13_3" runat="server" GroupName="sueca" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_13_4" runat="server" GroupName="sueca" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Noruega</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_14_0" runat="server" GroupName="noruega" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_14_1" runat="server" GroupName="noruega" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_14_2" runat="server" GroupName="noruega" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_14_3" runat="server" GroupName="noruega" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_14_4" runat="server" GroupName="noruega" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Sirio</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_15_0" runat="server" GroupName="sirio" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_15_1" runat="server" GroupName="sirio" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_15_2" runat="server" GroupName="sirio" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_15_3" runat="server" GroupName="sirio" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_15_4" runat="server" GroupName="sirio" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Romané</th>
                                                                            <td>
                                                                                <asp:RadioButton ID="rb_16_0" runat="server" GroupName="romane" Text="Nada" Visible="True" Enabled="true" Checked="true" />
                                                                                <asp:RadioButton ID="rb_16_1" runat="server" GroupName="romane" Text="Bajo" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_16_2" runat="server" GroupName="romane" Text="Medio" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_16_3" runat="server" GroupName="romane" Text="Alto" Visible="True" Enabled="true" />
                                                                                <asp:RadioButton ID="rb_16_4" runat="server" GroupName="romane" Text="Nativo" Visible="True" Enabled="true" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                                                                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                                                                        <asp:Label ID="lb_situacion_migratoria" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lb_documentacion_migratoria" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lb_proceso_migracion" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lb_dominio_idiomas" runat="server" Visible="false"></asp:Label>
                                                                    </div>
                                                                    <div class="botonera pull-right">
                                                                        <asp:Button ID="bt_situacion_migratoria" runat="server" Text="Button" Enabled="false" OnClick="bt_situacion_migratoria_Click" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>--%>
                                                </asp:Panel>

                                            </div>

                                            <%-- Condiciones Ley RPA / Articulo 134-bis --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab11" runat="server" >
                                                <asp:Panel ID="pnl_utab11" runat="server" Visible="true" OnDataBinding="pnl_utab11_DataBinding" >
                                                    <asp:HiddenField runat="server" ID="Articulo134" Value="0" />
                                                    <%--<clrpa1:DatosdeGestion_condicionesLeyRPA_Art134bis runat="server" ID="DatosdeGestion_condicionesLeyRPA_Art134bis" />--%>
                                                    <div class="row">
                                                        <div class="col-md-12">

                                                            <%-- INICIO: Atículo 134-bis --%>
                                                            <table class="table table-bordered tabla-tabs table-condensed">
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Registro N°</th>
                                                                    <td class="col-md-4">
                                                                        <asp:Label ID="lbl_registro" runat="server" Text="Registro"></asp:Label>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Laboral</th>
                                                                    <td class="col-md-4">
                                                                        <asp:CheckBox ID="chk_laboral" runat="server" />
                                                                    </td>

                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio *</th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_fechaInicio_134bis" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaInicio_134bis" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_fechaInicio_134bis" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_fechaInicio_134bis" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                                                        <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Capacitación</th>
                                                                    <td class="col-md-4">
                                                                        <asp:CheckBox ID="chk_capacitacion" runat="server" />
                                                                    </td>

                                                                    <th class="titulo-tabla col-md-1" scope="row">&nbsp;</th>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Educación</th>
                                                                    <td class="col-md-4">
                                                                        <asp:CheckBox ID="chk_educacion" runat="server" />
                                                                    </td>

                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Término *</th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_fechatermino_134bis" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechatermino_134bis" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_TextBox2"></ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_fechatermino_134bis" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_fechatermino_134bis" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                                                        <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Cese del Permiso *</th>
                                                                    <td class="col-md-4">
                                                                        <asp:DropDownList ID="ddl_cesePermiso" CssClass="form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_cesePermiso_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Descripción</th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_descripcion_134bis" runat="server" MaxLength="100" TextMode="MultiLine" CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Cumple Estandar</th>
                                                                    <td class="col-md-4" style="margin-left: 40px">
                                                                        <asp:CheckBox ID="chk_cumpleestandar" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="Small">Implica la formalización del compromiso del joven y la existencia del acta de análisis de caso relacionado al permiso</asp:Label>
                                                            <div class="botonera pull-right">

                                                                <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="btn_Art134bis_guardar" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="btn_Art134bis_guardar_Click">
                                                                    <span class="glyphicon glyphicon-ok"></span>Guardar 
                                                                   &nbsp;<asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btn_Art134bis_limpiar" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="btn_Art134bis_limpiar_Click">
                                                                        <span class="glyphicon glyphicon-plus"></span>Agregar Nueva Solicitud

                                                                   </asp:LinkButton>
                                                                </asp:LinkButton>
                                                            </div>

                                                            <tr>

                                                                <asp:GridView ID="grd_articulo134" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grd_articulo134_RowCommand">
                                                                    <Columns>
                                                                        <%--<asp:TemplateField HeaderText="IcodArticuloBis">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IcodArticuloBis") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("IcodArticuloBis") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>--%>
                                                                        <asp:BoundField DataField="iCodArticuloBis" HeaderText="Registro" />
                                                                        <asp:BoundField DataField="Icodie" HeaderText="IcodIE"></asp:BoundField>
                                                                        <asp:BoundField DataField="Laboral" HeaderText="Laboral"></asp:BoundField>
                                                                        <asp:BoundField DataField="Capacitacion" HeaderText="Capacitación"></asp:BoundField>
                                                                        <asp:BoundField DataField="Educacion" HeaderText="Educación"></asp:BoundField>
                                                                        <asp:BoundField DataField="Fechainicio" HeaderText="Fecha Inicio"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Término"></asp:BoundField>
                                                                        <asp:BoundField DataField="CumpleEstandar" HeaderText="Cumple Estandar"></asp:BoundField>
                                                                        <asp:BoundField DataField="CesePermiso" HeaderText="Cese Permiso"></asp:BoundField>
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción"></asp:BoundField>
                                                                        <asp:ButtonField Text="Seleccionar" CommandName="ver" />
                                                                    </Columns>
                                                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                                                </asp:GridView>

                                                            </tr>
                                                            <%-- FIN: Atículo 134-bis --%>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <%-- Condiciones Ley RPA / Plan Motivacional --%>

                                            <div role="tabpanel" class="tab-pane fade" id="tab12" runat="server">
                                                <asp:Panel ID="pnl_utab12" runat="server" Visible="true" OnDataBinding="pnl_utab12_DataBinding">
                                                    <%--<clrpa2:DatosdeGestion_condicionesLeyRPA_PlanMotivacional runat="server" ID="DatosdeGestion_condicionesLeyRPA_PlanMotivacional" />--%>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <%-- INICIO: Plan Motivacional --%>
                                                            <table class="table table-bordered tabla-tabs table-condensed">
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Categoria </th>
                                                                    <td class="col-md-4">
                                                                        <asp:DropDownList ID="ddl_categoria" CssClass="form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_categoria_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio</th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_fechaInicio_PM" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender4" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaInicio_PM" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_fechaInicio_PM" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt_fechaInicio_PM" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                                                        <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Tipo falta</th>
                                                                    <td class="col-md-4">
                                                                        <asp:DropDownList ID="ddl_condicion1" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_condicion1_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                    <th class="titulo-tabla col-md-1" scope="row">Compromiso de Cumplimiento</th>
                                                                    <td>
                                                                        <asp:CheckBox ID="chk_comproDeCumplimiento" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Pernocta</th>
                                                                    <td class="col-md-4">
                                                                        <asp:RadioButton ID="rbt_pernotaSiempre" runat="server" Text="Siempre" GroupName="pernocta" />
                                                                        <asp:RadioButton ID="rbt_pernoctaAveces" runat="server" Text="A veces" GroupName="pernocta" />
                                                                    </td>

                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Término</th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt_fechaTermino_PM" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender5" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaTermino_PM" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_TextBox2"></ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_fechaTermino_PM" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt_fechaTermino_PM" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                                                        <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Cantidad Días</th>
                                                                    <td class="col-md-4">
                                                                        <asp:TextBox ID="txt_cantidadDiasPernocta" runat="server" CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="fte" runat="server" TargetControlID="txt_cantidadDiasPernocta" FilterType="Custom, Numbers" ValidChars="" />
                                                                        <asp:Label ID="Label4" runat="server" Text="Se entenderá que la cantidad de días está alrededor de la cifra indicada"></asp:Label>
                                                                    </td>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Certificado de Constancia No Continuidad</th>
                                                                    <td class="col-md-4">
                                                                        <asp:CheckBox ID="chk_certificadoConstanciaContinuidad" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Reiteración </th>
                                                                    <td class="col-md-4">
                                                                        <asp:DropDownList ID="ddl_condicion3" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_condicion3_SelectedIndexChanged" >
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Resultado</th>
                                                                    <td class="col-md-4">
                                                                        <asp:RadioButton ID="rdb_positivo" runat="server" Text="Positivo" GroupName="resultado" />
                                                                        <asp:RadioButton ID="rdb_negativo" runat="server" Text="Negativo" GroupName="resultado" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Frecuencia</th>
                                                                    <td class="col-md-4">
                                                                        <asp:RadioButton ID="rdb_continuo" runat="server" Text="Continuo" GroupName="condicion_4" />
                                                                        <asp:RadioButton ID="rdb_discontinuo" runat="server" Text="Discontinuo" GroupName="condicion_4" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Cantidad de Días</th>
                                                                    <td class="col-md-4">
                                                                        <asp:TextBox ID="txt_cantidaddeDias" runat="server" CssClass="form-control form-control-fecha-large input-sm" MaxLength="3"></asp:TextBox>
                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_cantidaddeDias" FilterType="Custom, Numbers" ValidChars="" />
                                                                        <asp:Label ID="Label5" runat="server" Text="Si es continuo serán considerados días seguidos. Si es discontinuo serán oportunidades en el periodo"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Descripción</th>
                                                                    <td class="col-md-4">
                                                                        <asp:TextBox ID="txt_descripcion" runat="server" CssClass="form-control form-control-fecha-large input-sm" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                            <div class="botonera pull-right">
                                                                <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="lnk_guardarPlanMotivacional" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="lnk_guardarPlanMotivacional_Click">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                                                                </asp:LinkButton>
                                                               
                                                                <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="lnk_limpiarPlanMotivacional" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="lnk_limpiarPlanMotivacional_Click">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar Nueva Solicitud
                                                                </asp:LinkButton>
                                                            </div>
                                                            <tr>
                                                                  <asp:GridView ID="grv_planMotivacional" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grv_planMotivacional_RowCommand">
                                                                    <Columns>
                                                                       
                                                                        <asp:BoundField DataField="iCodPlanMotivacional" HeaderText="Registro" />
                                                                        <asp:BoundField DataField="Icodie" HeaderText="IcodIE"></asp:BoundField>
                                                                        <asp:BoundField DataField="CodCategoria" HeaderText="Categoria"></asp:BoundField>
                                                                        <asp:BoundField DataField="CodCondicion1" HeaderText="Condicion"></asp:BoundField>
                                                                        <asp:BoundField DataField="Pernocta" HeaderText="Pernocta"></asp:BoundField>
                                                                        <asp:BoundField DataField="DiasPernocta" HeaderText="Días Pernocta"></asp:BoundField>
                                                                        <asp:BoundField DataField="CodCondicion3" HeaderText="Condición3"></asp:BoundField>
                                                                        <asp:BoundField DataField="Condicion4" HeaderText="Condicion"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Término"></asp:BoundField>
                                                                        <asp:BoundField DataField="CompromisoCumplimiento" HeaderText="Compromiso Cumplimiento"></asp:BoundField>
                                                                        <asp:BoundField DataField="Certificado" HeaderText="Certificado"></asp:BoundField>
                                                                        <asp:BoundField DataField="Resultado" HeaderText="Resultado"></asp:BoundField>
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>
                                                                        <asp:ButtonField Text="Seleccionar" CommandName="ver" />
                                                                    </Columns>
                                                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                                                </asp:GridView>

                                                            </tr> 
                                                            <%-- FIN: Plan Motivacional --%>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>

                                            <%-- Condiciones Ley RPA / Derivación PRE --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab13" runat="server" visible="false">
                                                <asp:Panel ID="pnl_utab13" runat="server" Visible="true">
                                                 <%--   <clrpa3:DatosdeGestion_condicionesLeyRPA_DerivacionPRE runat="server" ID="DatosdeGestion_condicionesLeyRPA_DerivacionPRE" />--%>
                                                </asp:Panel>
                                            </div>

                                            <%-- Condiciones Ley RPA / Flexibilización --%>
                                            <div role="tabpanel" class="tab-pane fade" id="tab14" runat="server">
                                                <asp:Panel ID="pnl_utab14" runat="server" Visible="true" OnDataBinding="pnl_utab14_DataBinding">
                                                    <%--<clrpa4:DatosdeGestion_condicionesLeyRPA_Flexibilizacion runat="server" ID="DatosdeGestion_condicionesLeyRPA_Flexibilizacion" />--%>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <%-- INICIO: Flexibilización --%>
                                                            <table class="table table-bordered tabla-tabs table-condensed">
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Tipo</th>
                                                                    <td class="col-md-4">
                                                                        <asp:DropDownList ID="ddl_tipoParflexibilidad" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipoParflexibilidad_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio</th>
                                                                    <td class="col-md-4">
                                                                        <asp:TextBox ID="txt_fechaInicio_fle" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender6" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaInicio_fle" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_fechaInicio_fle" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txt_fechaInicio_fle" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                                                        <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="col-md-1">&nbsp;</td>
                                                                    <td class="col-md-4">&nbsp;</td>
                                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Término</th>
                                                                    <td class="col-md-4">
                                                                        <asp:TextBox ID="txt_fechaTermino_fle" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender7" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaTermino_fle" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_fechaTermino_fle" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txt_fechaTermino_fle" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                                                        <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                            <div class="botonera pull-right">
                                                                <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="lnk_guardar_Flexibilizacion" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="lnk_guardar_Flexibilizacion_Click">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                                                                </asp:LinkButton>
                                                                <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="lnk_limpiar_Flexibilizacion" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="lnk_limpiar_Flexibilizacion_Click">
                            <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Nueva Solicitud
                                                                </asp:LinkButton>
                                                            </div>
                                                               <tr>
                                                                  <asp:GridView ID="grv_flexibilizacion" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grv_flexibilizacion_RowCommand">
                                                                    <Columns>
                                                                       
                                                                        <asp:BoundField DataField="IcodFlexibilizado" HeaderText="Registro" />
                                                                        <asp:BoundField DataField="CodFlexibilizado" HeaderText="Tipo"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Término"></asp:BoundField>
                                                              
                                                                        <asp:ButtonField Text="Seleccionar" CommandName="ver" />
                                                                    </Columns>
                                                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                                                </asp:GridView>

                                                            </tr> 
                                                            <%-- FIN: Flexibilización --%>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>

                                        </div>

                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:Panel ID="pnl003" runat="server" Width="100%" Visible="False"></asp:Panel>
                        </div>
                        <uc2:ninos_busqueda ID="Ninos_busqueda1" runat="server" OnLoad="Ninos_busqueda1_Load" />
                        <asp:LinkButton ID="btnbind" runat="server" OnClick="btnbind_Click1"></asp:LinkButton>
                    </div>
                </div>
                </div>
                <footer class="footer">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:<br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" Visible="true">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <script type="text/javascript">
            //function actualizaFecha() {
            //    CalculaFecha1();
            //}

            $(document).ready(function () {
                function SetProgressPosition(e) {
                    var posx = 0;
                    var posy = 0;
                    if (!e) var e = window.event;
                    if (e.pageX || e.pageY) {
                        posx = e.pageX;
                        posy = e.pageY;
                    }
                    else if (e.clientX || e.clientY) {
                        posx = e.clientX + document.documentElement.scrollLeft;
                        posy = e.clientY + document.documentElement.scrollTop;
                    }

                    document.getElementById('divProgress').style.top = posy + "px";
                }
            });

            //function SetProgressPosition(e) {
            //    var posx = 0;
            //    var posy = 0;
            //    if (!e) var e = window.event;
            //    if (e.pageX || e.pageY) {
            //        posx = e.pageX;
            //        posy = e.pageY;
            //    }
            //    else if (e.clientX || e.clientY) {
            //        posx = e.clientX + document.documentElement.scrollLeft;
            //        posy = e.clientY + document.documentElement.scrollTop;
            //    }

            //    document.getElementById('divProgress').style.top = posy + "px";
            //}
        </script>
    </form>
</body>
</html>
