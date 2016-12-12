<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_index.aspx.cs" EnableEventValidation="false" Inherits="ninos_index" Culture="es-CL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<%@ Register Src="ninos_busqueda.ascx" TagName="ninos_busqueda" TagPrefix="uc2" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>




<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Búsqueda de Niños/as :: Senainfo :: Servicio Nacional de Menores</title>

    <%--<script src="../js/jquery-1.10.2.js"></script>--%>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <%--    <script src="../js/ventanas-modales.js"></script>--%>
    <!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>
    <%--       <script src="../js/jquery.session.js"></script>--%>

    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/notify.js"></script>
    <script src="../js/moment.js"></script>




    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>


    <script type="text/javascript">

        $(function () {
            moment.locale('es');
        });

        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }


        function agregarMaxLength() {

        }
        function CerrarModalPopUp() {
            parent.location.reload();
        }

        $(window).load(function () {
            var TxtFechaInicio = document.getElementById('txt_FechaInicioSancionLRPA').value;
            if (TxtFechaInicio != "") {
                //ObtenerFechaTerminoSancion();
            }
        });


        window.cerrarModal = function () {

        }




        function validaFecha() {
            var fechainicio = $("#txt_FechaInicioSancionLRPA").val().replace(/-/g, '/');
            var fechaTermino = $("#txt003LRPA").val().replace(/-/g, '/');

            var valueStart = fechainicio.split("/");
            var valueEnd = fechaTermino.split("/");

            var dateStart = new Date(valueStart[2], (valueStart[1] - 1), valueStart[0]);
            var dateEnd = new Date(valueEnd[2], (valueEnd[1] - 1), valueEnd[0]);

            if (dateEnd <= dateStart) {
                $("#btnsaveingreso2").attr("disabled", "disabled");
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
                $("#btnsaveingreso2").removeAttr("disabled");
            }
        }


        function ObtenerFechaTerminoSancion(BotonPresionado) {
            moment.locale('es');
            if (document.getElementById('txt_FechaInicioSancionLRPA').value != "") {

                var TxtFechaInicioSancionLRPA = moment(document.getElementById('txt_FechaInicioSancionLRPA').value, "DD-MM-YYYY");
                var TxtFechaInicioSancionLRPAOriginal = moment(document.getElementById('txt_FechaInicioSancionLRPA').value, "DD-MM-YYYY");

                var TxtAnos = document.getElementById('txt001LRPA').value;
                var TxtMeses = document.getElementById('txt002LRPA').value;
                var TxtDias = document.getElementById('txt007LRPA').value;
                var TxtAbono = document.getElementById('txt009LRPA').value;
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

                document.getElementById('txt003LRPA').value = dia + '-' + mes + '-' + anio;
                //$('#txt003LRPA').attr('value', moment(TxtFechaInicioSancionLRPA).get('date') + '-' + (moment(TxtFechaInicioSancionLRPA).get('month') + 1) + '-' + moment(TxtFechaInicioSancionLRPA).get('year'));
                //$('#txt003LRPA').val(moment(TxtFechaInicioSancionLRPA).get('date') + '-' + (moment(TxtFechaInicioSancionLRPA).get('month') + 1) + '-' + moment(TxtFechaInicioSancionLRPA).get('year'));
                //$('#txt003LRPA').text(moment(TxtFechaInicioSancionLRPA).get('date') + '-' + (moment(TxtFechaInicioSancionLRPA).get('month') + 1) + '-' + moment(TxtFechaInicioSancionLRPA).get('year'));

                var FechaTerminoSancion = $("#txt003LRPA");
                var delay = 350;
                FechaTerminoSancion.animate({ backgroundColor: "#F59806" }, delay, function () {
                    //revert after completing
                    FechaTerminoSancion.animate({ backgroundColor: "#EEE" }, delay);
                });

                if (document.getElementById('Chk002LRPAMixta').checked != false) {
                    ObtenerFechaTerminoSancionMixta(1);

                    var FechaInicioSancionMixta = $("#ddown009LRPA");
                    var delay = 350;
                    FechaInicioSancionMixta.animate({ backgroundColor: "#F59806" }, delay, function () {
                        //revert after completing
                        FechaInicioSancionMixta.animate({ backgroundColor: "#EEE" }, delay);
                    });
                }



                //var now = moment().format('L');
                //var fechaTermino = $("#txt003LRPA").val().replace(/-/g, '/');


                //if (fechaTermino >= now ) {
                //    $("#btnsaveingreso2").removeAttr("disabled");
                //} else {
                //    $("#btnsaveingreso2").attr("disabled", "disabled");
                //}

                validaFecha();
            }
        }

        function ObtenerFechaTerminoSancionMixta(BotonPresionado) {
            var TxtFechaTerminoSancion = moment(document.getElementById('txt003LRPA').value, "DD-MM-YYYY");
            var TxtFechaTerminoSancionOriginal = moment(document.getElementById('txt003LRPA').value, "DD-MM-YYYY");

            TxtFechaTerminoSancion = TxtFechaTerminoSancion.add(1, 'days');

            //document.getElementById('ddown009LRPA').value = moment(TxtFechaTerminoSancion).get('date') + '-' + (moment(TxtFechaTerminoSancion).get('month') + 1) + '-' + moment(TxtFechaTerminoSancion).get('year');

            var diaTerminoSancion = moment(TxtFechaTerminoSancion).get('date');
            var mesTerminoSancion = (moment(TxtFechaTerminoSancion).get('month') + 1);
            var anioTerminoSancion = moment(TxtFechaTerminoSancion).get('year');

            if (diaTerminoSancion < 10) {
                diaTerminoSancion = "0" + diaTerminoSancion;
            }

            if (mesTerminoSancion < 10) {
                mesTerminoSancion = "0" + mesTerminoSancion;
            }

            $('#ddown009LRPA').val(diaTerminoSancion + '-' + mesTerminoSancion + '-' + anioTerminoSancion);
            $('#ddown009LRPA').attr('value', diaTerminoSancion + '-' + mesTerminoSancion + '-' + anioTerminoSancion);

            var TxtFechaInicioSancionMixta = moment(document.getElementById('ddown009LRPA').value, "DD-MM-YYYY");

            var TxtAnos = document.getElementById('txt004LRPA').value;
            var TxtMeses = document.getElementById('txt005LRPA').value;
            var TxtDias = document.getElementById('txt008LRPA').value;
            if (TxtAnos != "") {
                TxtFechaInicioSancionMixta = TxtFechaInicioSancionMixta.add(TxtAnos, 'years');
            }



            if (TxtMeses != "") {
                TxtFechaInicioSancionMixta = TxtFechaInicioSancionMixta.add(TxtMeses, 'months');
            }
            if (TxtDias != "") {
                TxtFechaInicioSancionMixta = TxtFechaInicioSancionMixta.add(TxtDias, 'days');
            }

            if (TxtFechaTerminoSancion != TxtFechaTerminoSancionOriginal) {

                var dia = moment(TxtFechaInicioSancionMixta).get('date');
                var mes = (moment(TxtFechaInicioSancionMixta).get('month') + 1);
                var anio = moment(TxtFechaInicioSancionMixta).get('year');

                if (dia < 10) {
                    dia = "0" + dia;
                }

                if (mes < 10) {
                    mes = "0" + mes;
                }

                //$('#txt006LRPA').val(moment(TxtFechaInicioSancionMixta).get('date') + '-' + (moment(TxtFechaInicioSancionMixta).get('month') + 1) + '-' + moment(TxtFechaInicioSancionMixta).get('year'));
                $('#txt006LRPA').attr('value', dia + '-' + mes + '-' + anio);
                var FechaTerminoSancion = $("#txt006LRPA");
                var delay = 350;
                FechaTerminoSancion.animate({ backgroundColor: "#F59806" }, delay, function () {
                    //revert after completing
                    FechaTerminoSancion.animate({ backgroundColor: "#EEE" }, delay);
                });

            }
        }


        function ChangeCalendarView(sender, args) {
            sender._switchMode("years", true);
        }

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
        };


        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }





        function MostrarModalIngresoNuevo() {
            var objIframe = document.getElementById('iframe_ingreso_nuevo');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_ninos/ninos_ingresonuevo.aspx?rut=" + document.getElementById('txt001').value;
            objIframe.height = "600px";
            objIframe.width = "1024px";
            $find("mpe1a").show();
            return false;
        }

        function MostrarModalListaEspera() {
            var objIframe = document.getElementById('iframe_lista_espera');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_ninos/Ingresoninolistaespera.aspx";
            objIframe.height = "600px";
            objIframe.width = "1024px";
            $find("mpe2a").show();
            return false;
        }

        function MostrarModalGestacion() {
            var objIframe = document.getElementById('iframe_solo_gestacion');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_ninos/ninos_ingresonuevo.aspx?eg=si";
            objIframe.height = "600px";
            objIframe.width = "1024px";
            $find("mpe3a").show();
            return false;
        }



        //window.cerrarModalInfoDiag = function () {
        //    $("#btnCerrarModal_utab3a").delay(1000).click();
        //    $("#refrescarDiag").click();
        //}


        //window.cerrarModalListaEspera = function () {
        //    $("#btnCerrarModal2").delay(1000).click();
        //}


        //function LimpiarModalIngresoNuevo() {
        //    var objIframe = document.getElementById('iframe_ingreso_nuevo');
        //    objIframe.src = "";
        //    return false;
        //}

        function LimpiarModalListaEspera() {
            var objIframe = document.getElementById('iframe_lista_espera');
            objIframe.src = "";
            return false;
        }

        function LimpiarModalGestacion() {
            var objIframe = document.getElementById('iframe_solo_gestacion');
            objIframe.src = "";
            return false;
        }

        //function LimpiarModalInstitucion() {
        //    var objIframe = document.getElementById('iframe_bsc_institucion');
        //    objIframe.src = "";
        //    return false;
        //}



        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#collapser").click(function () {
                    if ($("#SpanCollapse").hasClass("glyphicon glyphicon-triangle-bottom")) { //mostrado
                        $("#SpanCollapse").removeClass();
                        $("#SpanCollapse").addClass("glyphicon glyphicon-triangle-top");
                        $("#lbl_acordeon").text('Ocultar Búsqueda Avanzada');
                        $("#ChkCollapse").prop('checked', true);
                        ocultarlbl_resumen();
                        $("#resumenBusqueda").hide();


                    }
                    else {
                        $("#SpanCollapse").removeClass(); // oculto
                        $("#SpanCollapse").addClass("glyphicon glyphicon-triangle-bottom");
                        $("#lbl_acordeon").text('Mostrar Búsqueda Avanzada');
                        $("#ChkCollapse").prop('checked', false);
                        mostrarlbl_resumen();
                        $("#resumenBusqueda").show();

                    }
                });

                $('#txt001').Rut({
                    on_error: function () { alert('El rut ingresado no es válido'); $('#txt001').val(""); },
                    format_on: 'keyup'
                });

                //$("#iframe_lista_espera").contents().find("#txt_rut").Rut({
                //    on_error: function () {
                //        alert("El rut ingresado no es valido");
                //        $("#iframe_lista_espera").val("");
                //    },
                //    format_on: 'keyup'
                //});


                //window.cerrarModalModificar = function () {
                //    $("#btnCerrarModal6").click();
                //    //$("#iframe_modificar_listaespera").hide();
                //    //$("#modal_modificar_listaespera").hide();
                //    //$("#mpe6a_backgroundElement").hide();
                //}
                //    $.notify(
                //        "Se han actualizado correctamente los datos!",
                //        {
                //            // whether to hide the notification on click
                //            clickToHide: true,
                //            // whether to auto-hide the notification
                //            autoHide: true,
                //            // if autoHide, hide after milliseconds
                //            autoHideDelay: 5000,
                //            // show the arrow pointing at the element
                //            arrowShow: true,
                //            // arrow size in pixels
                //            arrowSize: 5,
                //            // position defines the notification position though uses the defaults below
                //            //position: '...',
                //            // default positions
                //            //elementPosition: 'bottom left',
                //            globalPosition: 'top center',
                //            // default style
                //            style: 'bootstrap',
                //            // default class (string or [string])
                //            className: 'error',
                //            // show animation
                //            showAnimation: 'slideDown',
                //            // show animation duration
                //            showDuration: 400,
                //            // hide animation
                //            hideAnimation: 'slideUp',
                //            // hide animation duration
                //            hideDuration: 200,
                //            // padding between element and notification
                //            gap: 2
                //        });
                //}

            });
        };


        //$("#iframe_lista_espera").contents().find("#txt_rut").Rut({
        //    on_error: function () {
        //        alert("El rut ingresado no es valido");
        //        $("#iframe_lista_espera").val("");
        //    },
        //    format_on: 'keyup'
        //});


        $(document).keypress(function (e) {
            //numeros del 0 al 9
            if (e.keyCode >= 48 && e.keyCode <= 57) {
                ObtenerFechaTerminoSancion(1);
            }

            if (e.which == 13) {
                //alert('You pressed enter!');
                document.getElementById("btnsearch").click();
                return false;
            }
        });
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


        function mostrarlbl_resumen() {
            $("#lbl_resumen_filtro").show();
            $("#lbl_resumen_proyecto").show();
        }

        function ocultarlbl_resumen() {
            $("#lbl_resumen_filtro").hide();
            $("#lbl_resumen_proyecto").hide();
        }

        function LoadScript() {
            function pageLoad(sender, args) {
                $(document).ready(function () {
                    $("#collapser").click(function () {
                        if ($("#SpanCollapse").hasClass("glyphicon glyphicon-triangle-bottom")) { //mostrado
                            $("#SpanCollapse").removeClass();
                            $("#SpanCollapse").addClass("glyphicon glyphicon-triangle-top");
                            $("#lbl_acordeon").text('Ocultar Búsqueda Avanzada');
                            $("#ChkCollapse").prop('checked', true);
                            ocultarlbl_resumen();
                            $("#resumenBusqueda").hide();


                        }
                        else {
                            $("#SpanCollapse").removeClass(); // oculto
                            $("#SpanCollapse").addClass("glyphicon glyphicon-triangle-bottom");
                            $("#lbl_acordeon").text('Mostrar Búsqueda Avanzada');
                            $("#ChkCollapse").prop('checked', false);
                            mostrarlbl_resumen();
                            $("#resumenBusqueda").show();

                        }
                    });

                    $('#txt001').Rut({
                        on_error: function () { alert('El rut ingresado no es válido'); $('#txt001').val(""); },
                        format_on: 'keyup'
                    });

                    //window.cerrarModalModificar = function () {
                    //    $("#btnCerrarModal6").click();
                    //    //$("#iframe_modificar_listaespera").hide();
                    //    //$("#modal_modificar_listaespera").hide();
                    //    //$("#mpe6a_backgroundElement").hide();
                    //}
                    //    $.notify(
                    //        "Se han actualizado correctamente los datos!",
                    //        {
                    //            // whether to hide the notification on click
                    //            clickToHide: true,
                    //            // whether to auto-hide the notification
                    //            autoHide: true,
                    //            // if autoHide, hide after milliseconds
                    //            autoHideDelay: 5000,
                    //            // show the arrow pointing at the element
                    //            arrowShow: true,
                    //            // arrow size in pixels
                    //            arrowSize: 5,
                    //            // position defines the notification position though uses the defaults below
                    //            //position: '...',
                    //            // default positions
                    //            //elementPosition: 'bottom left',
                    //            globalPosition: 'top center',
                    //            // default style
                    //            style: 'bootstrap',
                    //            // default class (string or [string])
                    //            className: 'error',
                    //            // show animation
                    //            showAnimation: 'slideDown',
                    //            // show animation duration
                    //            showDuration: 400,
                    //            // hide animation
                    //            hideAnimation: 'slideUp',
                    //            // hide animation duration
                    //            hideDuration: 200,
                    //            // padding between element and notification
                    //            gap: 2
                    //        });
                    //}

                });
            };
        }

        $("#iframe_lista_espera").contents().find("#txt_rut").Rut({
            on_error: function () {
                alert("El rut ingresado no es valido");
                $("#iframe_lista_espera").val("");
            },
            format_on: 'keyup'
        });




    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)">

    <style>
        .avoid-clicks {
            pointer-events: none;
        }
    </style>

    <form id="form1" runat="server" action="#">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsaveingreso" />
                <asp:PostBackTrigger ControlID="btnsaveingreso2" />
                <asp:PostBackTrigger ControlID="btnsaveingreso3" />
                <asp:PostBackTrigger ControlID="btn_ingresoNinoModEX" />
                <%--<asp:PostBackTrigger ControlID="lk_nino_adulto" />--%>
            </Triggers>
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(LoadScript);
                </script>

                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="lbtn004"
                    PopupControlID="modal_ingreso_nuevo"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                    TargetControlID="lk_lista_espera"
                    PopupControlID="modal_lista_espera"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe3" BehaviorID="mpe3a" runat="server"
                    TargetControlID="lbtn006"
                    PopupControlID="modal_solo_gestacion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal3">
                </ajax:ModalPopupExtender>
                <ajax:ModalPopupExtender ID="mpe4" BehaviorID="mpe4a" runat="server"
                    TargetControlID="imb_lupaproyecto"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal4">
                </ajax:ModalPopupExtender>
                <ajax:ModalPopupExtender ID="mpe5" BehaviorID="mpe5a" runat="server"
                    TargetControlID="imb_lupainstitucion"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal5">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe6" BehaviorID="mpe6a" runat="server"
                    TargetControlID="btnGatillompe6"
                    PopupControlID="modal_modificar_listaespera"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal6">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe7" BehaviorID="mpe7a" runat="server"
                    TargetControlID="btnGatillompe7"
                    PopupControlID="modal_ingreso_adulto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal7">
                </ajax:ModalPopupExtender>


                <asp:Button ID="btnGatillompe7" runat="server" Style="display: none" />
                <asp:Button ID="btnGatillompe6" runat="server" Style="display: none" />
                <div class="popupConfirmation" id="modal_modificar_listaespera" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="btnCerrarModal6" role="button" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                    <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">LISTA ESPERA</h4>
                    </div>
                    <div>
                        <iframe id="iframe_modificar_listaespera" runat="server" frameborder="0"></iframe>
                    </div>
                </div>

                <input type="hidden" id="Buscando" value="0" />
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Búsqueda Niños(as)</li>

                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lblbmsg" runat="server" Text="" Visible="False"></asp:Label><br />
                        <asp:Label ID="lblpestana1" runat="server" Text=" 1- Ingreso " Visible="False"></asp:Label>
                        <asp:Label ID="lblpestana2" runat="server" Text=" 2- Datos del ingreso " Visible="False"></asp:Label>
                        <asp:Label ID="lblpestana3" runat="server" Text=" 3- Ordenes del tribunal " Visible="False"></asp:Label>
                        <asp:Label ID="lblpestana4" runat="server" Text=" 4- Causales del ingreso " Visible="False"></asp:Label>
                        <%-- <asp:Label ID="lblpestana5" CssClass="subtitulo-form" runat="server"  Text=" 5- Detalle de lesiones al ingreso " Visible="False"></asp:Label>--%>
                        <asp:Label ID="lblpestana6" runat="server" Text=" 6- Medida o sanción " Visible="False"></asp:Label>
                        <asp:Label ID="errorFecha" runat="server" Text=" Error Fecha de Inicio de Sancion es mayor que la Fecha de Termino" Visible="false"></asp:Label>

                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alerts2" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label ID="lblmsgSuccess" runat="server" Text="" Visible="False"></asp:Label><br />
                    </div>

                    <div class="alert alert-success text-center" role="alert" id="ModificarSuccessLE" style="display: none;">
                        <span class="glyphicon glyphicon-ok"></span>
                        <label>Se han actualizado los datos</label>
                    </div>

                    <div class="alert alert-info text-center" role="alert" style="display: none;">
                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp; <span id="NNAIngresadoEstaEnOtrosProyectos"></span>
                    </div>

                    <div class="alert alert-success text-center" role="alert" style="display: none;">
                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp; <span id="NNaIngresadoCorrectamente"></span>
                        <asp:Label runat="server" ID="msgAlertSuccess"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" style="display: none;">
                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp; <span id="NNAActualizadoCorrectamente"></span>
                        <asp:Label runat="server" ID="msgAlertInfo"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Ingreso del Niño</h4>
                        <asp:CheckBox ID="ChkCollapse" runat="server" Style="display: none" Checked="false" />

                        <%--<br />--%>
                        <%--<asp:label ID="lbl_resumen_filtro" runat="server" Visible ="false" Text=""></asp:label><br />
                        <asp:label ID="lbl_resumen_proyecto" runat="server" Visible ="false"></asp:label>--%>

                        <hr>

                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Institución:</label>
                                        </th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddl_Institucion" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupainstitucion" runat="server" CssClass="input-group-addon btn btn-primary btn-sm " OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion', '../mod_ninos/ninos_index.aspx','mpe5a')" CausesValidation="False">
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
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddl_Proyecto" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="imb_lupaproyecto" runat="server" CssClass="input-group-addon btn btn-primary btn-sm " OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_ninos/ninos_index.aspx','mpe4a')" CausesValidation="False">
                                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                            </asp:LinkButton>
                                                        </div>

                                                    </td>
                                                    <td>

                                                        <label for="rut">&nbsp;RUN&nbsp; </label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt001" CssClass="form-control form-control-fecha input-sm" placeholder="RUN Niño(a)" runat="server" MaxLength="12" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt001" ValidChars="kK.-0123456789" />


                                                    </td>
                                                </tr>
                                            </table>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:CheckBox ID="chk002F2" runat="server" AutoPostBack="True" Text="Mostrar sólo proyectos caducados" ForeColor="Black" OnCheckedChanged="chk002F2_CheckedChanged" OnDataBinding="chk002F2_DataBinding" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                                <!--gfontbrevis modal institucion -->
                                <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton ID="btnCerrarModal5" CssClass="close" aria-label="Close" OnClientClick="LimpiarModalInstitucion()" runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                        <h4 class="modal-title">INSTITUCION</h4>
                                    </div>
                                    <div>
                                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                    </div>
                                </div>
                                <!--gfontbrevis modal proyecto -->
                                <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton ID="btnCerrarModal4" CssClass="close" aria-label="Close" OnClientClick="LimpiarModalInstitucion()" runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                        <h4 class="modal-title">PROYECTO</h4>
                                    </div>
                                    <div>
                                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                    </div>
                                </div>
                                <!-- busqueda avanzada -->
                                <a id="collapser" data-toggle="collapse" runat="server" data-parent="#accordion" href="#collapse_Busqueda" aria-expanded="true" aria-controls="collapse_Busqueda">
                                    <h5>
                                        <asp:Label ID="lbl_acordeon" runat="server" Visible="true"></asp:Label>
                                        <span id="SpanCollapse" class="glyphicon glyphicon-triangle-top" runat="server"></span>
                                        <asp:Label ID="resumenBusqueda" runat="server"></asp:Label>
                                    </h5>

                                </a>
                                <div id="collapse_Form" runat="server" visible="false"></div>
                                <a id="collapse" runat="server" visible="false"></a>
                                <div id="collapse_Busqueda" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">

                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Código Niño(a):</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt002" CssClass="form-control input-sm" placeholder="Código Niño(a)" runat="server" MaxLength="15" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txt002" ValidChars="0123456789" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Paterno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt003" CssClass="form-control input-sm" placeholder="Ingresar Apellido" runat="server" AutoCompleteType="LastName" MaxLength="20"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txt003" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Materno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt004" CssClass="form-control input-sm" placeholder="Ingresar Apellido" runat="server" AutoCompleteType="LastName" MaxLength="20"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txt004" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Nombre del Niño(a):</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt005" CssClass="form-control input-sm" placeholder="Ingresar nombre" runat="server" AutoCompleteType="FirstName" MaxLength="20"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txt005" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label>
                                                    Sexo:
                                                </label>
                                            </th>
                                            <td colspan="2">
                                                <label>
                                                    <asp:RadioButton ID="rdo_Sexo_F" runat="server" GroupName="rdossexo" Text=" Femenino" OnDataBinding="rdo001_DataBinding" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                </label>
                                                <label>
                                                    <asp:RadioButton ID="rdo_Sexo_M" runat="server" GroupName="rdossexo" Text=" Masculino" />
                                                </label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbl004" runat="server" Visible="False"></asp:Label>
                                            </td>
                                        </tr>

                                    </table>
                                </div>

                                <!--gfontbrevis nuevo estandar de botones -->
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th></th>
                                        <td>

                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnsearch" runat="server" Text="Buscar" OnClick="Button1_Click2" ValidationGroup="grupo1" AutoPostback="true">
                                        <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                            <asp:Button runat="server" ID="cargarDatosNuevos" OnClick="cargarDatosNuevos_Click" CssClass="invisible" />
                                            <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button pull-right" ID="Button2" runat="server" Text="Limpiar" OnClick="Button2_Click" CausesValidation="false">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>

                                        </td>
                                    </tr>
                                </table>

                                 <div class="alert alert-warning text-center" color-text="red" role="alert" id="alertaFemenino" runat="server" visible="false">
                                 <h5>El Proyecto seleccionado es exclusivamente para ingresar un NNA con sexo </h5>  <h4>"Femenino" </h4> <span class="glyphicon glyphicon-exclamation-sign"></span>
                                                     
                                 </div>

                                 <div class="alert alert-warning text-center" color-text="red" role="alert" id="alertaMasculino" runat="server" visible="false">
                                 <h5>El Proyecto seleccionado es exclusivamente para ingresar un NNA con sexo </h5>  <h4>  "Masculino" </h4> <span class="glyphicon glyphicon-exclamation-sign"></span>
                                                     
                                 </div>


                            </div>
                            <!--cierra col-md-8-->
                            <div class="col-md-3">

                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="LblSubtitulo" CssClass="subtitulo-form-info" runat="server" Text="Para ingresar a un niño, primero se deben ingresar sus datos para verificar que no este registrado en el sistema."></asp:Label><br />
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Si conoce el RUN del niño o niña, regístrelo y haga click en el botón buscar."></asp:Label><br />
                                        <asp:Label ID="Lbl_Info2" CssClass="subtitulo-form-info" runat="server" Text="En caso de sólo conocer nombres o apellidos, seleccionar Búsqueda Avanzada."></asp:Label>
                                    </div>
                                </asp:Panel>


                                <div class="caja-despliegue" id="DivCoincidencias" runat="server">
                                    <h4>
                                        <asp:Label ID="lbl001" CssClass="subtitulo-form" runat="server" Text="0" Visible="False"></asp:Label>
                                    </h4>
                                    <h4>
                                        <asp:Label ID="lbl002" runat="server" CssClass="subtitulo-form" Text="Coincidencias" Visible="False"></asp:Label>
                                    </h4>
                                </div>
                                <div class="caja-despliegue" id="DivBotones" runat="server">
                                    <div>
                                        <asp:Label ID="Label1" runat="server" Text="Desplegar:" Visible="False"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="lbtn005" runat="server" OnClick="lbtn005_Click" Visible="False">Ver todos los niños(as) vigentes del Proyecto</asp:LinkButton>
                                    </div>
                                    <div>
                                        <asp:LinkButton ID="lbtn003" runat="server" OnClick="lnkbtnver_Click" Visible="False">Resultado búsqueda (coincidencias)</asp:LinkButton>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="chk001" runat="server" OnDataBinding="chk001_DataBinding" Text="Incluir todos los Niños(as) vigentes del proyecto en el resultado" Visible="False" AutoPostBack="true" />
                                    </div>
                                    <div>
                                        <asp:Label ID="lbl002F2" runat="server" CssClass="mensajeRUT"></asp:Label>
                                    </div>
                                </div>


                                <%--MOOOOOOODALES --%>
                                <div>
                                    <asp:Label ID="lbl003F2" runat="server" CssClass="mensajeRUT" Text="Si no se encuentra el niño en la red" Visible="False"></asp:Label>
                                </div>

                                <div>

                                    <asp:LinkButton CssClass="btn btn-primary btn-sm  btn-margen btn-block" ID="lk_lista_espera" runat="server" OnClientClick="return MostrarModalListaEspera()" Visible="False" CausesValidation="false">
                                        <span class="glyphicon glyphicon-hourglass"></span>&nbsp;Lista de Espera
                                    </asp:LinkButton>

                                    <div class="popupConfirmation" id="modal_lista_espera" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal2" runat="server" OnClientClick="return LimpiarModalListaEspera()" CausesValidation="false">
                                                       <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">LISTA DE ESPERA</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_lista_espera" runat="server" frameborder="0"></iframe>
                                        </div>
                                    </div>
                                </div>
                                <div>

                                    <asp:LinkButton ID="lbtn006" CssClass="btn btn-primary btn-sm btn-block btn-margen" runat="server" OnClientClick="return MostrarModalGestacion()" Visible="False" CausesValidation="False">
                                        <span class="glyphicon glyphicon-record"></span>&nbsp;Sólo en Gestación
                                    </asp:LinkButton>
                                    <div class="popupConfirmation" id="modal_solo_gestacion" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal3" OnClientClick="return LimpiarModalGestacion()" runat="server" CausesValidation="false">
                                                       <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">SOLO GESTACIÓN</h4>
                                        </div>

                                        <div>
                                            <iframe id="iframe_solo_gestacion" runat="server" frameborder="0"></iframe>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:LinkButton ID="lk_nino_adulto" runat="server" CssClass="btn btn-primary btn-sm btn-block btn-margen" Visible="False" OnClick="LinkButton1_Click1" AutoPostback="true">
                                        <span class="glyphicon glyphicon-user"></span>&nbsp;Flia Origen y Solicitante
                                    </asp:LinkButton>
                                    <%--<asp:label ID="lblIngresoAdulto" text="PAG Sólo Flia Origen y Solicitante" runat="server" Visible="true" ></asp:label>--%>
                                    <div class="popupConfirmation" id="modal_ingreso_adulto" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton ID="btnCerrarModal7" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                        <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">Ingreso Adulto</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_ingreso_adulto" runat="server" frameborder="0"></iframe>
                                        </div>
                                    </div>
                                </div>
                                <div>

                                    <asp:LinkButton ID="lbtn004" runat="server" Visible="False" OnClientClick="return MostrarModalIngresoNuevo()" CausesValidation="False" CssClass="btn btn-danger btn-sm btn-margen  btn-block">
                                        <span class="glyphicon glyphicon-log-in"></span>&nbsp;Ingresar Nuevo Niño(a)
                                    </asp:LinkButton>
                                    <div class="popupConfirmation" id="modal_ingreso_nuevo" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" OnClientClick="return LimpiarModalIngresoNuevo()" runat="server" CausesValidation="false">
                                                        <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">INGRESO NIÑO(A)</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_ingreso_nuevo" runat="server" frameborder="0"></iframe>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <asp:TextBox ID="txt_ICodIngresoLE" runat="server" Visible="False"></asp:TextBox>


                        <div class="row">

                            <div id="div_panel" runat="server" visible="False">
                                </table> 
                                        <div>
                                            <h4>
                                                <asp:Label ID="titulo_datos_nino" class="subtitulo-form" runat="server" Text="Datos del Niño en el Proyecto"></asp:Label></h4>
                                        </div>
                                <div>
                                    <asp:Label ID="lbl003" runat="server"></asp:Label>
                                </div>


                                <div>
                                    <asp:Panel ID="utab_nino" runat="server" Visible="true" OnDataBinding="utab_nino_DataBinding">
                                        <div>
                                            <!--gfontbrevis <ul id="myTabs" class="nav nav-utab nav-tabs " role="tablist">-->
                                            <ul id="myTabs" class="nav nav-tabs tab-fixed-height nav-justified " role="tablist">
                                                <li id="li_nav1" runat="server" role="presentation" class="active">
                                                    <a id="link_tab1" runat="server" href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab">1 - INGRESO   
                                                    </a>
                                                </li>
                                                <li id="li_nav2" runat="server" role="presentation">
                                                    <a id="link_tab2" runat="server" href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab">2 - DATOS DEL INGRESO   
                                                    </a>
                                                </li>
                                                <li id="li_nav3" runat="server" role="presentation">
                                                    <a id="link_tab3" runat="server" href="#tab3" aria-controls="tab3" role="tab" data-toggle="tab">3 - ORDENES DEL TRIBUNAL   
                                                    </a>
                                                </li>
                                                <li id="li_nav4" runat="server" role="presentation">
                                                    <a id="link_tab4" runat="server" href="#tab4" aria-controls="tab4" role="tab" data-toggle="tab">4 - CAUSALES DEL INGRESO
                                                    </a>
                                                </li>
                                                <li id="li_nav5" runat="server" role="presentation">
                                                    <a id="link_tab5" runat="server" href="#tab5" aria-controls="tab5" role="tab" data-toggle="tab">5 - DETALLE DE LESIONES AL INGRESO
                                                    </a>
                                                </li>
                                                <li id="li_nav6" runat="server" role="presentation">
                                                    <a id="link_tab6" runat="server" href="#tab6" aria-controls="tab6" role="tab" data-toggle="tab">6 - MEDIDA O SANCION
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab1" runat="server">

                                                <asp:Panel ID="pnl_utab1" runat="server" Visible="true">

                                                    <div class="alert alert-warning text-center" color-text="red" role="alert" id="alertaLRPAmayor18" runat="server" visible="false">
                                                        <span class="glyphicon glyphicon-alert"></span>&nbsp;&nbsp;Se está ingresando a un NNA de edad mayor a 18 años, a un proyecto LRPA.                                                        
                                                    </div>

                                                    <table class="table table-bordered  table-condensed tabla-tabs">
                                                        <tbody>
                                                            <tr>
                                                                <th class="titulo-tabla-centrado col-md-3" scope="row">Fecha de ingreso *</th>
                                                                <th class="titulo-tabla-centrado" scope="row">Inmueble *</th>
                                                                <th class="titulo-tabla-centrado" scope="row">Tipo de Atención *</th>
                                                            </tr>
                                                            <tr>

                                                                <td>
                                                                    <asp:TextBox ID="txt_FechaIngreso" onkeypress="return false;" CssClass="form-control form-control-fecha-large input-sm" runat="server" AutoPostBack="True" OnTextChanged="WebDateChooser1_TextChanged" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txt_FechaIngreso" ValidChars="0123456789-/" />
                                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende903" runat="server" Format="dd-MM-yyyy" TargetControlID="txt_FechaIngreso" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende903" />

                                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" Text="Fecha Invalida" ControlToValidate="txt_FechaIngreso" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />
                                                                    <asp:Label ID="lbl002b" CssClass="help-block" runat="server" Font-Bold="True" ForeColor="Red" Visible="False">ESTE MES ESTA CERRADO</asp:Label>
                                                                </td>

                                                                <td>
                                                                    <asp:DropDownList ID="ddl_Inmueble" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                        <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>


                                                                <td>
                                                                    <asp:DropDownList ID="ddl_TipoAtencion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                        <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab2" runat="server">
                                                <asp:Panel ID="pnl_utab2" runat="server" Visible="true">
                                                    <h4>
                                                        <label class="subtitulo-form">&nbsp;Escolaridad </label>
                                                    </h4>
                                                    <table class="table table-bordered table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Calidad Jurídica *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_CalidadJuridica" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered  table-condensed ">
                                                        <tr>

                                                            <th class="titulo-tabla col-md-2" scope="row">Edad</th>
                                                            <td class="col-md-3">

                                                                <div class="input-group">
                                                                    <asp:TextBox ID="WebNumericEdit1" runat="server" AutoPostBack="True" CssClass="form-control form-control-20 " MaxLength="3" OnTextChanged="txt001_ValueChange" placeholder="Años" />
                                                                    <span class="input-group-addon-telefono" id="basic-addon-anio">Años</span>

                                                                    <asp:TextBox ID="WebNumericEdit2" runat="server" AutoPostBack="True" CssClass="form-control form-control-20" OnTextChanged="txt001_ValueChange" placeholder="Meses"></asp:TextBox>
                                                                    <span class="input-group-addon-telefono" id="basic-addon-mes">Meses</span>
                                                                </div>
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender74" runat="server" BehaviorID="_content_FilteredTextBoxExtender74" FilterType="Numbers" TargetControlID="WebNumericEdit1" />
                                                                <asp:RangeValidator ID="RangeValidator74" Visible="false" runat="server" ControlToValidate="WebNumericEdit1" MaximumValue="100" MinimumValue="0" Text="Numero Fuera De Rango" Type="Integer" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender77" runat="server" BehaviorID="_content_FilteredTextBoxExtender77" FilterType="Numbers" TargetControlID="WebNumericEdit2" />
                                                                <asp:RangeValidator ID="RangeValidator77" Visible="false" runat="server" ControlToValidate="WebNumericEdit2" MaximumValue="12" MinimumValue="0" Text="Numero Fuera De Rango" Type="Integer"></asp:RangeValidator>
                                                            </td>
                                                            <th class="titulo-tabla col-md-2">Escolaridad *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Escolaridad" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Año Último Curso</th>
                                                            <td>
                                                                <asp:TextBox ID="txt003a" CssClass="form-control form-control input-sm" runat="server" OnTextChanged="txt003a_ValueChange1" MaxLength="4" AutoPostBack="true" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt003a" ValidChars="0123456789" BehaviorID="_content_FilteredTextBoxExtender1" />
                                                                <%-- <asp:rangevalidator id="rv_año" CssClass="help-block" runat="server" Display="Dynamic" ControlToValidate="txt003a" ErrorMessage=" Año fuera de rango" Type="Double"  OnInit="rv_año_Init" />--%>
                                                                <asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />
                                                                <asp:Label ID="lbl_avisoano" CssClass="help-block" runat="server" Visible="False"></asp:Label>
                                                            </td>

                                                            <th class="titulo-tabla" scope="row">Tipo Asistencia Escolar *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_TipoAsistenciaEscolar" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True"></asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                    <h4>
                                                        <label class="subtitulo-form">&nbsp;Datos Específicos </label>
                                                    </h4>
                                                    <table class="table table-bordered  table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Domicilio</th>
                                                            <td>
                                                                <asp:TextBox ID="txt003b" CssClass="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered  table-condensed ">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Región *</th>
                                                            <td class="col-md-3">
                                                                <asp:DropDownList ID="ddown007a" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown007a_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <th class="titulo-tabla col-md-2" scope="row">Comuna *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown007" CssClass="form-control input-sm" runat="server">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Tipo Relación con Quien Vive</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown008" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>

                                                            <th class="titulo-tabla" scope="row">Persona Contacto</th>
                                                            <td>
                                                                <asp:TextBox ID="WebTextEdit1" CssClass="form-control form-control-80 input-sm" runat="server" MaxLength="49"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Teléfono Contacto</th>
                                                            <td>
                                                                <asp:TextBox ID="TextBox1" CssClass="form-control input-sm" runat="server" />
                                                            </td>

                                                            <th class="titulo-tabla" scope="row">Tipo Relación Contacto</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown009" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                    <h4>
                                                        <label class="subtitulo-form">&nbsp;Datos Internos </label>
                                                    </h4>
                                                    <table class="table table-bordered table-condensed">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Entrevistador *</th>
                                                            <td class="col-md-3">
                                                                <asp:DropDownList ID="ddl_Entrevistador" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Selected="True" Value="0">
                                                                                
                                                                    </asp:ListItem>
                                                                </asp:DropDownList></td>

                                                            <th class="titulo-tabla col-md-2" scope="row">Revisor</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown011" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Selected="True" Value="0">
                                                                                
                                                                    </asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered table-col-fix table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla-centrado" scope="row">Ingreso Comunicado Familia u Otro</th>
                                                            <th class="titulo-tabla-centrado" scope="row">Tipo Solicitante Ingreso *</th>
                                                            <th class="titulo-tabla-centrado" scope="row">Solicitante Ingreso *</th>
                                                        </tr>
                                                        <tr>
                                                            <td class="text-center">
                                                                <asp:CheckBox ID="chk002" runat="server" /></td>


                                                            <td>
                                                                <asp:DropDownList ID="ddl_TipoSolicitanteIngreso" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown012_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True" Value="0">
                                                                                
                                                                                Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>


                                                            <td>
                                                                <asp:DropDownList ID="ddown013" CssClass="form-control input-sm" runat="server">
                                                                    <asp:ListItem Selected="True" Value="0">
                                                                                
                                                                                Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>

                                                    </table>
                                                    <div class="botonera pull-right">
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btnsaveingreso3" runat="server" OnClick="btnsaveingreso3_Click" Visible="False" AutoPostback="true">
                                                                    <span class="glyphicon glyphicon-ok" id="Span13"></span>&nbsp;Realizar Ingreso
                                                        </asp:LinkButton>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab3" runat="server">
                                                <asp:GridView ID="grd001" CssClass="table  table-bordered table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" OnRowCommand="grd001_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="CodTribunal" Visible="False"></asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Tribunal"></asp:BoundField>
                                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha Orden"></asp:BoundField>
                                                        <asp:BoundField DataField="expediente" HeaderText="Expediente"></asp:BoundField>
                                                        <asp:BoundField DataField="RUC" HeaderText="RUC"></asp:BoundField>
                                                        <asp:BoundField DataField="RIT" HeaderText="RIT"></asp:BoundField>
                                                        <asp:ButtonField Text="Quitar" HeaderText="Quitar"></asp:ButtonField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="titulo-tabla" />
                                                    <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                </asp:GridView>
                                                <asp:Label ID="lbl_mensajeOT" runat="server" CssClass="help-block" Visible="False" Width="100%"></asp:Label></td>
                                                                
                                                            <asp:Panel ID="pnl_utab3" runat="server" Visible="true">
                                                                <table id="tbl_orden_tribunal" class="table table-bordered  table-condensed tabla-tabs" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <th class="titulo-tabla col-md-2" scope="row">Tiene Orden del Tribunal *</th>
                                                                            <td>
                                                                                <asp:Panel ID="pnl_rdo_orden_tribunal" runat="server" CssClass="text-center">
                                                                                    <asp:RadioButton ID="rdo_OrdenTribunal_SI" runat="server" AutoPostBack="True" GroupName="rdoorden" OnCheckedChanged="rdo001_CheckedChanged" Text="&nbsp;Si" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:RadioButton ID="rdo_OrdenTribunal_EnTramite" runat="server" AutoPostBack="True" GroupName="rdoorden" Text="&nbsp;En Tramite" OnCheckedChanged="rdo002_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:RadioButton ID="rdo_OrdenTribunal_NO" runat="server" AutoPostBack="True" GroupName="rdoorden" OnCheckedChanged="rdo003_CheckedChanged" Text="&nbsp;No" />
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">

                                                                    <table class="table table-bordered  table-condensed tabla-tabs">

                                                                        <tr>


                                                                            <th class="titulo-tabla col-md-2" scope="row">Región *</th>


                                                                            <td>
                                                                                <asp:DropDownList ID="ddown014" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown014_SelectedIndexChanged"></asp:DropDownList>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="table table-bordered  table-condensed tabla-tabs">
                                                                        <tr>
                                                                            <th class="titulo-tabla col-md-2" scope="row">Tipo de Tribunal *</th>
                                                                            <td class="col-md-3">
                                                                                <asp:DropDownList ID="ddown015" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown015_SelectedIndexChanged"></asp:DropDownList></td>

                                                                            <th class="titulo-tabla col-md-2" scope="row">Tribunal *</th>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddown016" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown016_SelectedIndexChanged"></asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">Expediente</th>
                                                                            <td>
                                                                                <asp:TextBox ID="WebTextEdit2" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>

                                                                            <th class="titulo-tabla" scope="row">RUC *</th>
                                                                            <td>

                                                                                <asp:TextBox ID="txt006F2" CssClass="form-control input-sm" runat="server" MaxLength="12" placeholder="YYONNNNNNN-D Ejemplo 1010083505-6" />
                                                                                <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt006F2" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />

                                                                                <asp:CustomValidator ID="cv_txt006F2" runat="server" ControlToValidate="txt006F2" Display="Dynamic" CssClass="help-block" ErrorMessage="RUC inválido. Nuevo formato RUC: YYONNNNNNN-D" ClientValidationFunction="ValidaRuc" />

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="titulo-tabla" scope="row">RIT</th>
                                                                            <td>
                                                                                <asp:TextBox ID="txt007F2" CssClass="form-control input-sm" runat="server" />
                                                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt007F2" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-"></ajax:FilteredTextBoxExtender>
                                                                            </td>

                                                                            <th class="titulo-tabla" scope="row">Fecha</th>
                                                                            <td>

                                                                                <asp:TextBox ID="ddown017" onkeypress="return false;" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                                                <ajax:FilteredTextBoxExtender ID="fte29" runat="server" TargetControlID="ddown017" ValidChars="0123456789-/" />
                                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende916" runat="server" Format="dd-MM-yyyy" TargetControlID="ddown017" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende916" />

                                                                                <asp:RangeValidator ID="RangeValidator916" CssClass="help-block" Display="Dynamic" runat="server" ErrorMessage=" Fecha Invalida" ControlToValidate="ddown017" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="table table-bordered table-col-fix table-condensed tabla-tabs">
                                                                        <tr>
                                                                            <th>
                                                                                <asp:LinkButton ID="btn001" CssClass="btn btn-danger btn-sm fixed-width-button pull-right" runat="server" OnClick="btn001_Click">
                                                                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Orden
                                                                                </asp:LinkButton>
                                                                            </th>
                                                                        </tr>
                                                                    </table>

                                                                    <div id="informacion_80BIS" runat="server" visible="false" class="panel-info panel-primary-info text-center nopadding">
                                                                        <div class="panel-heading ">
                                                                            Información
                                                                        </div>
                                                                        <div class="panel-footer">
                                                                            <p>
                                                                                <strong>Nota 1: </strong>
                                                                                <asp:Label ID="lbl_nota80" CssClass="subtitulo-form-info" runat="server" Text="Solo uno de los dos campos son requeridos (Expendiente o RIT)."></asp:Label>
                                                                            </p>
                                                                        </div>
                                                                    </div>



                                                                </asp:Panel>
                                                                <div>
                                                                    <!--gfontbrevis lbl_mensajefecha cambiado a visible false... no se llama desde servidor -->
                                                                    <asp:Label ID="lbl_mensajefecha" runat="server" CssClass="help-block" Visible="false" Width="100%"></asp:Label>
                                                                </div>
                                                                <div class="botonera pull-right">
                                                                    <asp:DropDownList ID="dd_focus6" CssClass="form-control input-sm" runat="server" Visible="False" OnSelectedIndexChanged="ddown016_SelectedIndexChanged"></asp:DropDownList>
                                                                </div>
                                                            </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab4" runat="server">
                                                <asp:Panel ID="pnl_utab4" runat="server" Visible="true">
                                                    <div class="table-condensed">
                                                        <asp:GridView ID="grd002" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grd002_RowCommand">
                                                            <HeaderStyle CssClass="titulo-tabla" />
                                                            <Columns>
                                                                <asp:BoundField DataField="CodTipoCausalIngreso" Visible="False"></asp:BoundField>
                                                                <asp:BoundField DataField="CodCausalIngreso" HeaderText="CodCausalIngreso" Visible="False"></asp:BoundField>
                                                                <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo Causal de Ingreso"></asp:BoundField>
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Causal de Ingreso"></asp:BoundField>
                                                                <asp:BoundField DataField="coddelito" HeaderText="Codigo Delito" />
                                                                <asp:BoundField DataField="entidad" HeaderText="Entidad que Asigna"></asp:BoundField>
                                                                <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
                                                                <asp:ButtonField CommandName="SUBIR" Text="Subir" HeaderText="Subir"></asp:ButtonField>
                                                                <asp:ButtonField CommandName="BAJAR" Text="Bajar" HeaderText="Bajar"></asp:ButtonField>
                                                                <asp:ButtonField Text="Quitar" CommandName="QUITAR" HeaderText="Quitar"></asp:ButtonField>
                                                            </Columns>
                                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lbl_causales" runat="server" CssClass="help-block" Text="Label" Visible="False" Width="100%"></asp:Label>

                                                        <div class="alert alert-warning text-center" color-text="red" role="alert" id="alertaPeores" runat="server" visible="false">
                                                            <h5>Debe Registrar un Diagnóstico en Peores Formas de Trabajo</h5>
                                                            <br />- La causal de ingreso seleccionada esta relacionada con la explotación sexual o comercial del NNA.
                                                            <span class="glyphicon glyphicon-exclamation-sign"></span>
                                                        </div>

                                                        <div class="alert alert-warning text-center" color-text="red" role="alert" id="alertaEmbarazo" runat="server" visible="false">
                                                            <h5>Debe Registrar un Diagnóstico Social por posible embarazo</h5>
                                                            <br />- La causal de ingreso seleccionada se relaciona con la Explotación Sexual del NNA.
                                                            <span class="glyphicon glyphicon-exclamation-sign"></span>                                                    
                                                        </div>

                                                        <div class="alert alert-warning text-center" color-text="red" role="alert" id="alertaDrogas" runat="server" visible="false">
                                                            <h5>Debe Registrar un " Diagnóstico de Droga "</h5>
                                                            <br />- La causal de ingreso seleccionada se relaciona con el consumo de Drogas del NNA.
                                                            <span class="glyphicon glyphicon-exclamation-sign"></span>
                                                        </div>

                                                    </div>

                                                    <table class="table table-bordered table-condensed tabla-tabs" id="tabla_OrdenTribunal" runat="server" visible="false">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">
                                                                <asp:Label ID="lbl_otc" runat="server" Text="Orden de Tribunal"></asp:Label></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown_otc" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown018_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered table-condensed tabla-tabs">
                                                        <tbody>
                                                            <tr>
                                                                <th class="titulo-tabla col-md-2" scope="row">Tipo Causal de Ingreso *</th>
                                                                <td class="col-md-3">
                                                                    <asp:DropDownList ID="ddl_TipoCausalIngreso" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown018_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>

                                                                <th class="titulo-tabla col-md-2" scope="row">Causal de Ingreso *</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddl_CausalIngreso" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown019_SelectedIndexChanged1" AutoPostBack="True">
                                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Código Delito</th>
                                                                <td>
                                                                    <asp:TextBox ID="txt006" runat="server" CssClass="form-control form-control-60 input-sm" Enabled="False"></asp:TextBox></td>

                                                                <th class="titulo-tabla" scope="row">Entidad que Asigna *</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown020" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                                        <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                        <asp:ListItem Value="E">ESTABLECIMIENTO</asp:ListItem>
                                                                        <asp:ListItem Value="P">POLICIA</asp:ListItem>
                                                                        <asp:ListItem Value="T">TRIBUNAL</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="table table-bordered table-condensed tabla-tabs">
                                                        <tr>
                                                            <th>
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right" ID="btn002" runat="server" OnClick="btn002_Click" CausesValidation="False">
                                                          <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Causal
                                                                </asp:LinkButton>
                                                            </th>
                                                        </tr>
                                                    </table>

                                                    <div class="panel-info panel-primary-info text-center nopadding">
                                                        <div class="panel-heading ">
                                                            Información
                                                        </div>
                                                        <div class="panel-footer">
                                                            <p>
                                                                <strong>Nota 1: </strong>
                                                                <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Debe agregar de 1 a 3 causales de Ingreso."></asp:Label>
                                                                <strong>Nota 2: </strong>
                                                                <asp:Label CssClass="subtitulo-form-info" runat="server" Text="Las prioridades están dadas por el orden en que se registren, si es necesario corregir, puede utilizarse &quot;subir&quot; o &quot;bajar&quot; para cambiar el orden"> </asp:Label>
                                                                <strong>Nota 3: </strong><a target="_blank" id="A4" runat="server" class="ifancybox" href="https://cdn.senainfo.cl/pdf/cd/orientaciones/Causales_ingreso_2015.pdf">
                                                                    <asp:Label ID="lnkbtn_pdfVulneracion" runat="server">Ver definiciones de Tipo Causal de Ingreso</asp:Label>
                                                                </a>

                                                            </p>
                                                        </div>
                                                    </div>


                                                    <!-- gfontbrevis: txt_descripcionTCI en desuso visible=false -->
                                                    <asp:TextBox ID="txt_descripcionTCI" CssClass="form-control input-sm" runat="server" TextMode="MultiLine" placeholder="Seleccione Tipo Causal De Ingreso" Visible="false">Seleccione Tipo Causal De Ingreso</asp:TextBox>
                                                </asp:Panel>
                                            </div>

                                            <div role="tabpanel" class="tab-pane fade in active" id="tab5" runat="server">
                                                <div class="table-condensed">
                                                    <asp:GridView ID="grd003" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="grd003_RowCommand" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="TipoLesiones" Visible="False"></asp:BoundField>
                                                            <asp:BoundField DataField="CodQuienOcasionaLesion" HeaderText="CodQuienOcasionaLesion" Visible="False"></asp:BoundField>
                                                            <asp:BoundField DataField="descripciontipo" HeaderText="Tipo de Lesion"></asp:BoundField>
                                                            <asp:BoundField DataField="descripcion" HeaderText="Lesion"></asp:BoundField>
                                                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones"></asp:BoundField>
                                                            <asp:ButtonField Text="Quitar" HeaderText="Quitar"></asp:ButtonField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                </div>


                                                <asp:Panel ID="pnl_utab5" runat="server" Visible="true">
                                                    <table class="table table-col-fix table-condensed tabla-tabs">
                                                        <tbody>
                                                            <tr>
                                                                <th class="titulo-tabla col-md-3" scope="row">Presenta Lesiones *</th>
                                                                <td class="text-center">
                                                                    <asp:RadioButton ID="rdo004" runat="server" OnCheckedChanged="rdo004_CheckedChanged" AutoPostBack="True" Visible="True" GroupName="rdolesiones" Text="Si" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:RadioButton ID="rdo005" runat="server" OnCheckedChanged="rdo005_CheckedChanged" AutoPostBack="True" Visible="True" GroupName="rdolesiones" Text="No" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                    <asp:Panel ID="pnl002" runat="server" Visible="False" Width="100%" BackColor="White" CssClass="texto_form_sancion">
                                                        <div>
                                                            <table class="table table-bordered table-col-fix table-condensed tabla-tabs">
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="titulo-tabla col-md-3" scope="row">Tipo de Lesión *</th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddown021" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                                <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr id="tr_responsable_lesion" runat="server">
                                                                        <th class="titulo-tabla" scope="row">Quien ocacionó la Lesi&oacute;n</th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddown022" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th class="titulo-tabla" scope="row">Observaciones</th>
                                                                        <td>
                                                                            <asp:TextBox ID="txt007" CssClass="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table id="tbl_informa_fiscalia" class="table table-bordered table-col-fix table-condensed tabla-tabs" runat="server">
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="titulo-tabla" scope="row">Se informa a la fiscal&iacute;a correspondiente</th>
                                                                        <td>
                                                                            <asp:CheckBox ID="chk001Fiscalia_RPA" runat="server" Enabled="False" /></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table class="table table-bordered table-col-fix table-condensed tabla-tabs">
                                                                <tr>
                                                                    <th>
                                                                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btn003" runat="server" OnClick="btn003_Click" CausesValidation="False">
                                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Detalle
                                                                        </asp:LinkButton>
                                                                    </th>
                                                                </tr>
                                                            </table>

                                                        </div>
                                                    </asp:Panel>


                                                    <div class="botonera pull-right">
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnsaveingreso" runat="server" OnClick="btnsaveingreso_Click">
                                                            <span class="glyphicon glyphicon-ok" id="Span14"></span>&nbsp;Realizar Ingreso
                                                        </asp:LinkButton>
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_ingresoNinoModEX" runat="server" OnClick="btnsaveingreso2_Click" Visible="False">
                                                            <span class="glyphicon glyphicon-ok" id="Span15"></span>&nbsp;Realizar Ingreso
                                                        </asp:LinkButton>
                                                        <asp:Label ID="lblOT_Ingreso" CssClass="help-block" runat="server" Font-Names="Arial" HText="**Debe Ingresar Orden de Tribunal" Visible="False"></asp:Label>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab6" runat="server">
                                                <div>
                                                    <asp:Label ID="lbl_avisoLRPA" runat="server" CssClass="help-block" Visible="False" Width="100%"></asp:Label>
                                                </div>
                                                <asp:GridView ID="grd001LRPA" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="grd003_RowCommand" CellPadding="4" Visible="False">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Descripci&#243;n (Tipo de Sanci&#243;n)" DataField="CodSancion"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Cod.Tipo Sanci&#243;n Accesoria" DataField="CodTipoSancionAccesoria"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Cod. Sanci&#243;n" DataField="Descripcion"></asp:BoundField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="titulo-tabla" />
                                                    <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                </asp:GridView>
                                                <asp:Panel ID="pnl_utab6" runat="server" Visible="true">
                                                    <asp:GridView ID="grd_LRPA02" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="grd003_RowCommand" CellPadding="4">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Cod. Condici&#243;n Ingreso" DataField="Descripcion"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Descripci&#243;n (Condici&#243;n Ingreso)" DataField="CodCondicionIngreso"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Cod. Sanci&#243;n" DataField="Nemotecnico"></asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                    <table class="table table-bordered  table-condensed tabla-tabs">

                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">
                                                                <asp:Label ID="lbl_otm" runat="server" Text="Orden de Tribunal *"></asp:Label></th>
                                                            <td colspan="3">
                                                                <asp:DropDownList ID="ddl_OrdenDeTribunal_MedidaSancion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddown_otm_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="tabla-item" colspan="4">
                                                                <h4>
                                                                    <label class="subtitulo-form">MCA, CIP indicar tiempo investigación. SBC, PSA indicar duración medida. PLA, PLE, CRC, CSC indicar duración sanción.</label>
                                                                </h4>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Inicio Sanción *</th>
                                                            <td class="col-md-1">

                                                                <asp:TextBox ID="txt_FechaInicioSancionLRPA" AutoPostBack="true" CssClass="form-control form-control-fecha-large input-sm" runat="server" ONVALUECHANGED="ddown001LRPA_ValueChanged" MaxLength="10" placeholder="dd-mm-aaaa" OnTextChanged="txt_FechaInicioSancionLRPA_TextChanged" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_FechaInicioSancionLRPA" ValidChars="0123456789-" />
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende930" runat="server" Format="dd-MM-yyyy" TargetControlID="txt_FechaInicioSancionLRPA" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende930" />

                                                                <asp:RangeValidator ID="RangeValidator930" runat="server" Display="Dynamic" ErrorMessage="Fecha Invalida" ValidationGroup="FechaInicioSancionLRPA" ControlToValidate="txt_FechaInicioSancionLRPA" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" CssClass="help-block" />
                                                                <asp:Label ID="lblfechaini1LRPA" runat="server" Visible="false" CssClass="help-block"></asp:Label>

                                                            </td>




                                                            <th class="titulo-tabla col-md-2" scope="row">Duración *</th>
                                                            <td>

                                                                <div id="DatosSancion">
                                                                    <div class="input-group">

                                                                        <asp:TextBox ID="txt001LRPA" CssClass="form-control form-control-decena input-sm" onChange="ObtenerFechaTerminoSancion(0)" runat="server" MaxLength="2" Enabled="False" />
                                                                        <span class="input-group-addon-telefono" id="Span1">Años</span>

                                                                        <asp:TextBox ID="txt002LRPA" CssClass="form-control form-control-decena input-sm" onChange="ObtenerFechaTerminoSancion(0)" runat="server" MaxLength="2" Enabled="False" />
                                                                        <span class="input-group-addon-telefono" id="Span2">Meses</span>

                                                                        <asp:TextBox ID="txt007LRPA" CssClass="form-control input-sm" runat="server" onChange="ObtenerFechaTerminoSancion(0)" MaxLength="4" Enabled="False" />
                                                                        <span class="input-group-addon-telefono" id="Span3">Días</span>

                                                                        <asp:TextBox ID="txt009LRPA" CssClass="form-control input-sm" runat="server" onChange="ObtenerFechaTerminoSancion(0)" MaxLength="5" Enabled="False" />
                                                                        <span class="input-group-addon-telefono" id="Span4">Abono</span>
                                                                        <asp:LinkButton ID="lnk001" Visible="false" CssClass="input-group-addon btn btn-danger fixed-width-button" runat="server" OnClick="lnk001_Click"> 
                                                                                                    <span class="glyphicon glyphicon-calendar" id="Span5"></span>&nbsp;Calcular Fecha
                                                                        </asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                                <asp:Label ID="lbl_avisoDuracionLRPA" CssClass="help-block" runat="server" Display="Dynamic" Visible="false"></asp:Label>
                                                                <ajax:FilteredTextBoxExtender ID="fte4" runat="server" TargetControlID="txt001LRPA" ValidChars="0123456789" />
                                                                <ajax:FilteredTextBoxExtender ID="fte5" runat="server" TargetControlID="txt002LRPA" ValidChars="0123456789" />
                                                                <ajax:FilteredTextBoxExtender ID="fte6" runat="server" TargetControlID="txt007LRPA" ValidChars="0123456789" />
                                                                <ajax:FilteredTextBoxExtender ID="fte7" runat="server" TargetControlID="txt009LRPA" ValidChars="0123456789" />


                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <th class="titulo-tabla " scope="row">Fecha Termino Sanción</th>
                                                            <td>
                                                                <asp:TextBox ID="txt003LRPA" CssClass="form-control form-control-fecha-large input-sm avoid-clicks" runat="server"></asp:TextBox></td>

                                                            <th class="titulo-tabla" scope="row">Sanción Mixta PLA, PLE, CRC, CSC</th>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CheckBox ID="Chk002LRPAMixta" runat="server" AutoPostBack="True" OnCheckedChanged="Chk002LRPAMixta_CheckedChanged" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="LblfechaLRPA" CssClass="help-block" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <asp:Panel ID="pnlLRPAmixta" runat="server" Visible="False">
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Fecha Inicio Sanción: *</th>
                                                                <td>

                                                                    <asp:TextBox ID="ddown009LRPA" CssClass="form-control form-control-fecha-large input-sm avoid-clicks" runat="server" />
                                                                    <%--<ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="ddown009LRPA" ValidChars="0123456789-/" />
                                                                                                <ajax:CalendarExtender ID="CalendarExtende943" runat="server" Format="dd-MM-yyyy" TargetControlID="ddown009LRPA" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende943" />
                                                                                            
                                                                                                <asp:RangeValidator ID="RangeValidator943" runat="server" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="ddown009LRPA" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />--%>
                                                                    <asp:Label ID="lblfechaIni2LRPA" Visible="false" runat="server" CssClass="help-block"></asp:Label>

                                                                </td>

                                                                <th class="titulo-tabla" scope="row">Duración *</th>
                                                                <td>
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="txt004LRPA" CssClass="form-control form-control-decena input-sm" onChange="ObtenerFechaTerminoSancion()" runat="server" MaxLength="2" />
                                                                        <span class="input-group-addon-telefono" id="Span6">Años</span>

                                                                        <asp:TextBox ID="txt005LRPA" CssClass="form-control form-control-decena input-sm" onChange="ObtenerFechaTerminoSancion()" runat="server" MaxLength="2" />
                                                                        <span class="input-group-addon-telefono" id="Span7">Meses</span>

                                                                        <asp:TextBox ID="txt008LRPA" CssClass="form-control form-control-90 input-sm" onChange="ObtenerFechaTerminoSancion()" runat="server" MaxLength="4" />
                                                                        <span class="input-group-addon-telefono" id="Span8">Días</span>

                                                                        <asp:LinkButton ID="lnk002" Visible="false" runat="server" CssClass="input-group-addon btn btn-danger fixed-width-button" OnClick="lnk002_Click1">
                                                                                                    <span class="glyphicon glyphicon-calendar" id="Span9"></span>&nbsp;Calcular Fecha</asp:LinkButton>


                                                                    </div>
                                                                    <asp:Label ID="lbl_avisoDuracion2LRPA" runat="server" CssClass="help-block" Display="Dynamic" Visible="false"></asp:Label>
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt004LRPA" ValidChars="0123456789" />
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt005LRPA" ValidChars="0123456789" />
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt008LRPA" ValidChars="0123456789" />

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Fecha Termino Sanción:</th>
                                                                <td>
                                                                    <asp:TextBox ID="txt006LRPA" CssClass="form-control form-control-fecha-large input-sm avoid-clicks" runat="server"></asp:TextBox></td>

                                                                <th class="titulo-tabla" scope="row">Modelo Sanción Mixta</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown011LRPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged">
                                                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:LinkButton ID="lnk_limpiaFechas" CssClass=" btn btn-info fixed-width-button pull-right" runat="server" OnClick="lnk_limpiaFechas_Click">
                                                                                        <span class="glyphicon glyphicon-remove" id="Span10"></span>&nbsp;Resetear Fechas

                                                                    </asp:LinkButton></td>
                                                            </tr>
                                                        </asp:Panel>
                                                    </table>
                                                    <table class="table table-bordered  table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="tabla-item" colspan="4">
                                                                <h4>
                                                                    <label class="subtitulo-form">Tribunal de Seguimiento de la Medida o Sanción</label></h4>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Región *</th>
                                                            <td colspan="3">
                                                                <asp:DropDownList ID="ddown003LRPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged">
                                                                    <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla col-md-2" scope="row">Tipo Tribunal *</th>
                                                            <td class="col-md-3">
                                                                <asp:DropDownList ID="ddown004LRPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>

                                                            <th class="titulo-tabla col-md-2" scope="row">Tribunal *</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddown005LRPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList><asp:DropDownList ID="dd_focus1" CssClass="form-control input-sm" runat="server" Visible="False">
                                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="tabla-item" colspan="4">
                                                                <h4>
                                                                    <label class="subtitulo-form">Sanción Accesoria PLA, PLE, CRC, CSC</label></h4>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Sanción Accesoria (Sí)</th>
                                                            <td colspan="3">
                                                                <asp:CheckBox ID="chk001LRPA" runat="server" AutoPostBack="True" OnCheckedChanged="chk001LRPA_CheckedChanged" /></td>
                                                        </tr>

                                                    </table>
                                                    <table id="pnl1LRPA" visible="false" runat="server" class="table table-bordered  table-condensed tabla-tabs">
                                                        <tbody>
                                                            <tr id="tr_tipo_sancion_accesoria" runat="server">
                                                                <th class="titulo-tabla col-md-2" scope="row">Tipo(s) de Sanción Accesoria</th>
                                                                <td class="col-md-5">
                                                                    <asp:DropDownList ID="ddown006LRPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" Visible="False">
                                                                    </asp:DropDownList></td>

                                                                <td colspan="2">
                                                                    <asp:LinkButton CssClass="btn btn-info btn-sm pull-right " ID="btnAgregarTsancionLRPA" runat="server" OnClick="btnAgregarTsancionLRPA_Click" Visible="False">
                                                                                        <span class="glyphicon glyphicon-ok" id="Span11"></span>&nbsp;Agregar Sanción Accesoria
                                                                    </asp:LinkButton>

                                                                </td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                    <table id="tabla_sbs_psa" runat="server" class="table table-bordered table-condensed tabla-tabs">
                                                        <tbody>
                                                            <tr>
                                                                <th class="tabla-item" colspan="4">
                                                                    <h4>
                                                                        <label class="subtitulo-form">Servicio en Beneficio a la Comunidad (SBC) y Programa Salidas Alternativas (PSA)</label></h4>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla col-md-2" scope="row">Tipo de Sanción (SBC) o Vía Ingreso *</th>
                                                                <td class="col-md-3">
                                                                    <asp:DropDownList ID="ddown_tsancion" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>

                                                                <th class="titulo-tabla col-md-2" scope="row">Horas Servicio a la Comunidad</th>
                                                                <td>
                                                                    <asp:TextBox ID="txt_hservi" CssClass="form-control form-control input-sm" runat="server" MaxLength="3"></asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="fte8" runat="server" TargetControlID="txt_hservi" ValidChars="0123456789" />
                                                                    <asp:Label ID="lbl_mensaje002" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Tipo Actividad en Beneficio a la Comunidad *</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown_tipoBC" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>

                                                                <th class="titulo-tabla" scope="row">Tipo Institución en la que presta Servicio</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown_IPSER" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Área de Trabajo en la Institución</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown_areaTI" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>

                                                                <th class="titulo-tabla" scope="row">Tipo Reparación Daño</th>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown_repdaño" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_repdaño_SelectedIndexChanged">
                                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <th class="tabla-item" colspan="4">
                                                                    <h4>
                                                                        <label class="subtitulo-form">Condiciones de Ingreso (PSA)</label></h4>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th class="titulo-tabla" scope="row">Solicitante Ingreso</th>
                                                                <td colspan="3">
                                                                    <asp:DropDownList ID="ddown_conIng" CssClass="form-control input-sm" runat="server">
                                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                                    </asp:DropDownList><asp:Label ID="lbl_mensaje003" runat="server" CssClass="help-block" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" visible="false">
                                                                    <asp:Label ID="Lbl_mensaje001" runat="server" CssClass="help-block" Visible="False"></asp:Label>

                                                                    <asp:TextBox ID="txt_foco" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" Visible="False" ReadOnly="True"></asp:TextBox>
                                                                    <asp:TextBox ID="txt0010LRPA" runat="server" Width="50px" Text="0" Visible="False" />
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender90" runat="server" FilterType="Numbers" TargetControlID="txt0010LRPA" BehaviorID="_content_FilteredTextBoxExtender90" />
                                                                    <asp:RangeValidator ID="RangeValidator90" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt0010LRPA" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                                                </td>
                                                            </tr>
                                                    </table>
                                                    <div class="botonera pull-right">
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btn_coning" runat="server" Text="Agregar Condición Ingreso" OnClick="btnAgregar_coning_click" />
                                                        <asp:DropDownList ID="dd_focus2" runat="server" Visible="False">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="botonera pull-right">
                                                        <asp:LinkButton CssClass="btn btn-danger fixed-width-button" ID="btnsaveingreso2" runat="server" OnClick="btnsaveingreso2_Click">
                                                        <span class="glyphicon glyphicon-ok" id="Span12"></span>&nbsp;Realizar Ingreso
                                                        </asp:LinkButton>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>

                                <uc2:ninos_busqueda ID="Ninos_busqueda1" runat="server" />
                                <asp:LinkButton ID="btnbind" runat="server" OnClick="btnbind_Click1"></asp:LinkButton>

                                <asp:DropDownList ID="dd_focus5" runat="server" CssClass="form-control input-sm" Visible="False">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>
                <footer class="footer" aria-hidden="False">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                            <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
            <ProgressTemplate>

                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>

            </ProgressTemplate>
        </asp:UpdateProgress>

    </form>
    <script>
        $(document).ready(function () {
            var body = $("html, body");
            window.cerrarModalModificar = function (msj) {
                cerrarModalModificar();

                $("#NNAActualizadoCorrectamente").append(msj);

                body.stop().animate({ scrollTop: 0 }, '500', 'swing', function () {
                    $("#NNAActualizadoCorrectamente").parent().fadeIn(750, function () {
                        $("#NNAActualizadoCorrectamente").parent().delay(10000).fadeOut(2000);
                    });
                });
                $("#cargarDatosNuevos").click();
            }

            window.cerrarModalListaEspera = function (msj) {
                cerrarModalLE();

                $("#NNaIngresadoCorrectamente").append(msj);

                body.stop().animate({ scrollTop: 0 }, '500', 'swing', function () {
                    $("#NNaIngresadoCorrectamente").parent().fadeIn(750, function () {
                        $("#NNaIngresadoCorrectamente").parent().delay(10000).fadeOut(2000);
                    });
                });
                $("#cargarDatosNuevos").click();
            }

            window.cerrarModalLENNAEnOtroProyecto = function (msj) {
                cerrarModalLE();

                $("#NNAIngresadoEstaEnOtrosProyectos").append(msj);

                body.stop().animate({ scrollTop: 0 }, '500', 'swing', function () {
                    $("#NNAIngresadoEstaEnOtrosProyectos").parent().fadeIn(750, function () {
                        $("#NNAIngresadoEstaEnOtrosProyectos").parent().delay(10000).fadeOut(2000);
                    });
                });

                $("#cargarDatosNuevos").click();
            }

            function cerrarModalModificar() {
                $("#iframe_modificar_listaespera").delay(1500).hide();
                $("#modal_modificar_listaespera").hide();
                $("#mpe6a_backgroundElement").hide();
            }

            function cerrarModalLE() {
                $("#modal_lista_espera").delay(1500).hide();
                $("#mpe2a_backgroundElement").hide();
            }

        });
    </script>
</body>


</html>
