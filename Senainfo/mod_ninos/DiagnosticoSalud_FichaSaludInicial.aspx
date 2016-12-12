<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiagnosticoSalud_FichaSaludInicial.aspx.cs" Inherits="mod_ninos_DiagnosticoSalud_FichaSalud" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>

<html lang="es">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Ficha de salud (Primera atención)</title>

    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>


    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">


    <script type="text/javascript">


        function CerrarModalPopUp() {
            parent.location.reload();
        }

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $('#txtPeso').on('input propertychange', function () {
                    calculaIMC();
                    calculaPesoTalla();
                    calculaPesoEdad();
                });

                $('#txtTalla').on('input propertychange', function () {
                    calculaIMC();
                    calculaPesoTalla();
                });

                $('#txtHistoriaClinicaEvolutiva').on('input propertychange', function () {
                    max(txtHistoriaClinicaEvolutiva);
                    CharLimit(this, 1000);
                });
                $('#txtAntecedentesQuirurgicosyH').on('input propertychange', function () {
                    max2(txtAntecedentesQuirurgicosyH);
                    CharLimit2(this, 140);
                });
                $('#txtOtrosFarmacos').on('input propertychange', function () {
                    max3();
                    CharLimit3(30);
                });
                $('#txtOtrasAlergias').on('input propertychange', function () {
                    max4();
                    CharLimit4(30);
                });

                $('#txtFO').on('input propertychange', function () {
                    setFO();
                });

                $(function () {
                    $('[data-toggle="tooltip"]').tooltip()
                })
            });
        };


        function calculaIMC() {

            var txtPeso = document.getElementById('txtPeso');
            //btnGuardar.setAttribute("disabled", true);

            var txtPeso = document.getElementById('txtPeso');
            var txtTalla = document.getElementById('txtTalla');
            var txtEdad = document.getElementById('txtEdad');

            //var txtIMC = document.getElementById('txtIMC');            
            if (txtPeso.value.length > 0 && txtTalla.value.length > 0 && txtPeso.value > 0 && txtTalla.value > 0 && txtEdad.value >= 14) {
                var IMC = (txtPeso.value / ((txtTalla.value / 100) * (txtTalla.value / 100)));

                
                $('#txtIMC').attr('value', IMC.toFixed(1));
                $('#txtIMC').val(IMC.toFixed(1));
                var IMCReducido = IMC.toFixed(2);

                $('#ddlEstadoNutricional [value="0"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="65"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="66"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="67"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="68"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="69"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="70"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="2166"]').attr('selected', false);
                $('#ddlEstadoNutricional [value="2167"]').attr('selected', false);

               

                if (IMCReducido < 16) {
                    //document.getElementById('thIMC').innerHTML = "IMC Delgadez Severa"
                    //document.getElementById('ddlEstadoNutricional').value = 65;
                    $('#ddlEstadoNutricional').val(65).change();
                    $('#ddlEstadoNutricional [value="65"]').attr('selected', true);
                }
                if (IMCReducido >= 16 && IMCReducido <= 16.99) {
                    //document.getElementById('thIMC').innerHTML = "IMC Delgadez Moderada"
                    //document.getElementById('ddlEstadoNutricional').value = 66;
                    $('#ddlEstadoNutricional').val(66).change();
                    $('#ddlEstadoNutricional [value="66"]').attr('selected', true);
                }
                if (IMCReducido >= 17 && IMCReducido <= 18.49) {
                    //document.getElementById('thIMC').innerHTML = "IMC Delgadez Aceptable"
                    //document.getElementById('ddlEstadoNutricional').value = 67;
                    
                    $('#ddlEstadoNutricional').val(67).change();
                    $('#ddlEstadoNutricional [value="67"]').attr('selected', true);
                }
                if (IMCReducido >= 18.5 && IMCReducido <= 24.99) {
                    //document.getElementById('thIMC').innerHTML = "IMC Peso Normal"
                    //document.getElementById('ddlEstadoNutricional').value = 68;
                    
                    $('#ddlEstadoNutricional').val(68).change();
                    $('#ddlEstadoNutricional [value="68"]').attr('selected', true);
                }
                if (IMCReducido >= 25 && IMCReducido <= 29.99) {
                    //document.getElementById('thIMC').innerHTML = "IMC Sobrepeso"
                    //document.getElementById('ddlEstadoNutricional').value = 69;
                    
                    $('#ddlEstadoNutricional').val(69).change();
                    $('#ddlEstadoNutricional [value="69"]').attr('selected', true);
                }
                if (IMCReducido >= 30 && IMCReducido <= 34.99) {
                    //document.getElementById('thIMC').innerHTML = "IMC Obeso: Tipo I"
                    //ocument.getElementById('ddlEstadoNutricional').value = 70;
                    $('#ddlEstadoNutricional').val(70).change();
                    $('#ddlEstadoNutricional [value="70"]').attr('selected', true);
                }
                if (IMCReducido >= 35 && IMCReducido <= 40) {
                    //document.getElementById('thIMC').innerHTML = "IMC Obeso: Tipo II"
                    //document.getElementById('ddlEstadoNutricional').value = 2166;
                    
                    $('#ddlEstadoNutricional').val(2166).change();
                    $('#ddlEstadoNutricional [value="2166"]').attr('selected', true);
                }
                if (IMCReducido > 40) {
                    //document.getElementById('thIMC').innerHTML = "IMC Obeso: Tipo III"
                    //document.getElementById('ddlEstadoNutricional').value = 2167;
                                     
                    $('#ddlEstadoNutricional').val(2167).change();
                    $('#ddlEstadoNutricional [value="2167"]').attr('selected', true);
                }
            }
            else {
                $('#txtIMC').val('');
                //document.getElementById('ddlEstadoNutricional').value = 0;
                //$('#ddlEstadoNutricional').val(0).change();
                //$('#ddlEstadoNutricional [value="0"]').attr('selected', true);
            }
        }

        function setFO() {
            var txtFO = document.getElementById('txtFO');
            if (txtFO.value.length > 0 && txtFO.value.length < 9) {

                var long = txtFO.value.length;
                if (long % 2 == 1) {
                    txtFO.value = txtFO.value + "-";
                }

                //$(document).keypress(function (e) {    
                //    if (e.which == 8) {
                //        txtFO.value = "";
                //        return false;
                //    }
                //});
            }
        }

        function calculaPesoTalla() {

            var txtPeso = document.getElementById('txtPeso');
            var txtTalla = document.getElementById('txtTalla');
            //var txtPesoTalla = document.getElementById('txtPesoTalla');
            if (txtPeso.value.length > 0 && txtTalla.value.length > 0 && txtPeso.value > 0 && txtTalla.value > 0) {
                var PesoTalla = (txtPeso.value / txtTalla.value) * 100
                $('#txtPesoTalla').attr('value', PesoTalla.toFixed(2));
                $('#txtPesoTalla').val(PesoTalla.toFixed(2));
            }
        }

        function calculaPesoEdad() {

            var txtPeso = document.getElementById('txtPeso');
            var txtEdad = document.getElementById('txtEdad');
            //var txtPesoEdad = document.getElementById('txtPesoEdad');
            if (txtPeso.value.length > 0 && txtEdad.value.length > 0 && txtPeso.value > 0 && txtEdad.value > 0) {
                var PesoEdad = (txtPeso.value / txtEdad.value)
                $('#txtPesoEdad').attr('value', PesoEdad.toFixed(2));
                $('#txtPesoEdad').val(PesoEdad.toFixed(2));

            }
        }

        function max(textbox) {
            total = 1000;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado.innerHTML = str;
            Restante.innerHTML = total - str;

            if (tam > total) {
                //aux = PItxt002.value;
                //PItxt002.value = aux.substring(0, total);
                //Digitado.innerHTML = total
                Restante.innerHTML = 0
            }
        }

        function CharLimit(input, maxChar) {
            var len = $(input).val().length;
            var btnGuardar = document.getElementById('btnGuardar');
            var btnGuardar2 = document.getElementById('btnGuardar2');
            var btnGuardar3 = document.getElementById('btnGuardar3');
            var Digitado = document.getElementById('Digitado');
            var lblEscritos = document.getElementById('lblEscritos');

            if (len > maxChar) {

                $("#divCaracteres").css({ display: "block" });
                btnGuardar.setAttribute("disabled", true);
                btnGuardar2.setAttribute("disabled", true);
                btnGuardar3.setAttribute("disabled", true);

                Digitado.setAttribute("style", "color:red");
                lblEscritos.setAttribute("style", "color:red");
            }
            else {
                $("#divCaracteres").css({ display: "none" });

                if ($('#btnGuardar').is(':disabled') || $('#btnGuardar2').is(':disabled') || $('#btnGuardar3').is(':disabled')) {

                    btnGuardar.removeAttribute("disabled");
                    btnGuardar2.removeAttribute("disabled");
                    btnGuardar3.removeAttribute("disabled");
                }


                Digitado.setAttribute("style", "color:lead");
                lblEscritos.setAttribute("style", "color:lead");
            }
        }


        function max2(textbox) {
            total = 140;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado2.innerHTML = str;
            Restante2.innerHTML = total - str;

            if (tam > total) {
                //aux = PItxt002.value;
                //PItxt002.value = aux.substring(0, total);
                //Digitado.innerHTML = total
                Restante2.innerHTML = 0
            }
        }

        function CharLimit2(input, maxChar) {
            var len = $(input).val().length;

            var Digitado2 = document.getElementById('Digitado2');
            var lblEscritos2 = document.getElementById('lblEscritos2');

            if (len > maxChar) {

                Digitado2.setAttribute("style", "color:red");
                lblEscritos2.setAttribute("style", "color:red");
            }
            else {

                Digitado2.setAttribute("style", "color:lead");
                lblEscritos2.setAttribute("style", "color:lead");
            }
        }

        function max3() {

            var e = document.getElementById("ddlFarmacos");
            var txtOtrosFarmacos = document.getElementById("txtOtrosFarmacos");

            var ddlFarmacos = e.options[e.selectedIndex].text;

            if (ddlFarmacos == "Otros") {
                total = 30;
                tam = txtOtrosFarmacos.value.length;
                str = "";
                str = str + tam;
                Digitado3.innerHTML = str;
                Restante3.innerHTML = total - str;

                if (tam > total) {
                    //aux = PItxt002.value;
                    //PItxt002.value = aux.substring(0, total);
                    //Digitado.innerHTML = total
                    Restante3.innerHTML = 0
                }
            }
        }

        function CharLimit3(maxChar) {

            var e = document.getElementById("ddlFarmacos");
            var value = e.options[e.selectedIndex].text;
            var txtOtrosFarmacos = document.getElementById("txtOtrosFarmacos");

            if (value == "Otros") {
                var len = $(txtOtrosFarmacos).val().length;

                var Digitado3 = document.getElementById('Digitado3');
                var lblEscritos3 = document.getElementById('lblEscritos3');

                if (len > maxChar) {

                    Digitado3.setAttribute("style", "color:red");
                    lblEscritos3.setAttribute("style", "color:red");
                }
                else {

                    Digitado3.setAttribute("style", "color:lead");
                    lblEscritos3.setAttribute("style", "color:lead");
                }
            }
        }


        function max4() {

            var e = document.getElementById("ddlAlergias");
            var txtOtrasAlergias = document.getElementById("txtOtrasAlergias");

            var ddlAlergias = e.options[e.selectedIndex].text;

            if (ddlAlergias == "Otros") {

                total = 30;
                tam = txtOtrasAlergias.value.length;
                str = "";
                str = str + tam;
                Digitado4.innerHTML = str;
                Restante4.innerHTML = total - str;

                if (tam > total) {
                    //aux = PItxt002.value;
                    //PItxt002.value = aux.substring(0, total);
                    //Digitado.innerHTML = total
                    Restante4.innerHTML = 0
                }
            }
        }

        function CharLimit4(maxChar) {

            var e = document.getElementById("ddlAlergias");
            var txtOtrasAlergias = document.getElementById("txtOtrasAlergias");

            var ddlAlergias = e.options[e.selectedIndex].text;

            if (ddlAlergias == "Otros") {

                var len = $(txtOtrasAlergias).val().length;

                var Digitado4 = document.getElementById('Digitado4');
                var lblEscritos4 = document.getElementById('lblEscritos4');

                if (len > maxChar) {

                    Digitado4.setAttribute("style", "color:red");
                    lblEscritos4.setAttribute("style", "color:red");
                }
                else {

                    Digitado4.setAttribute("style", "color:lead");
                    lblEscritos4.setAttribute("style", "color:lead");
                }
            }
        }


        //window.closemodal() = function () {
        //    $("#btnCerrarModalAudicion").delay(1000).click();
        //}


    </script>

    <style>
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td
        {
            padding: 5px;
            line-height: 1.42857143;
            vertical-align: middle;
            border-top: 1px solid #dddddd;
        }

        .avoid-clicks
        {
            pointer-events: none;
        }

        .btnIguales
        {
            width: 100%;
        }


        tp
        {
            color: red;
        }

        .body-form-salud
        {
            padding-top: 5px;
            padding-bottom: 10px;
            margin-bottom: 0px;
            background-color: #fff;
        }
    </style>
</head>
<body class="body-form-salud well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <%--<Triggers>
                <asp:PostBackTrigger ControlID="btnGuardar" />
                <asp:PostBackTrigger ControlID="btnGuardar2" />
                <asp:PostBackTrigger ControlID="btnGuardar3" />
                <asp:PostBackTrigger ControlID="lnkMostrarDerivacionVision" />
                <asp:PostBackTrigger ControlID="lnkMostrarDerivacionAudicion" />
                <asp:PostBackTrigger ControlID="lnkMostrarDerivacionSaludBucal" />
                <asp:PostBackTrigger ControlID="lnkMostrarDerivacionColumna" />
            </Triggers> --%>

        <div class="row" id="divFichaSalud" runat="server" visible="false">
            <img src="../images/BannerFichaSaludInicial.jpg" class="img-responsive" alt="Cinque Terre">           

            
            <div class="alert alert-warning text-center" role="alert" id="divAlertaFicha" runat="server" visible="false">
                <asp:Label ID="lblAlertaFicha" CssClass="subtitulo-form-info" runat="server" Text="Faltan campos obligatorios. "></asp:Label>
            </div>
            <div class="alert alert-warning text-center" role="alert" id="divAlertaGuardado" runat="server" style="display: none">
                <asp:Label ID="lblGuardadoExitoso" CssClass="subtitulo-form-info" runat="server" Text="Guardado Exitoso. "></asp:Label>
            </div>
            <div  id="divContenidoFicha" runat="server">   
              
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    
                    <ContentTemplate>
            <table id="tblEncabezado" class="table table-bordered table-condensed">
                <tbody>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">N° Identificación</th>
                        <td>
                            <asp:TextBox ID="txtNIdentificacion" runat="server" CssClass="form-control input-sm avoid-clicks" placeholder="Ingresar"></asp:TextBox>
                        </td>
                        <th class="titulo-tabla" scope="row">1. Fecha de Diagnóstico *</th>
                        <td>
                            <asp:TextBox ID="txtFechaDiagnostico" CssClass="form-control form-control-fecha-large input-sm" OnTextChanged="txtFechaDiagnostico_TextChanged" AutoPostBack="true" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtFechaDiagnostico" ValidChars="0123456789-/" />
                            <ajax:CalendarExtender ID="CalendarExtende353" FirstDayOfWeek="Monday" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaDiagnostico" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaDiagnostico" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla" scope="row">2. Fecha de Intervención *</th>
                        <td>
                            <asp:TextBox ID="txtFechaIntervencion" CssClass="form-control form-control-fecha-large input-sm" OnTextChanged="txtFechaIntervencion_TextChanged" AutoPostBack="true" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txtFechaIntervencion" ValidChars="0123456789-/" />
                            <ajax:CalendarExtender ID="CalendarExtender5" FirstDayOfWeek="Monday" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaIntervencion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                            <asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaIntervencion" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />

                        </td>
                        <th class="titulo-tabla" scope="row">3. Fecha de Evaluación *</th>
                        <td>
                            <asp:TextBox ID="txtFechaEvaluacion" CssClass="form-control form-control-fecha-large input-sm" runat="server" OnTextChanged="txtFechaEvaluacion_TextChanged" AutoPostBack="true" MaxLength="10" placeholder="dd-mm-aaaa" />
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txtFechaEvaluacion" ValidChars="0123456789-/" />
                            <ajax:CalendarExtender ID="CalendarExtender6" FirstDayOfWeek="Monday" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaEvaluacion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                            <asp:RangeValidator ID="RangeValidator9" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaEvaluacion" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="tdHorasRestantes" visible="false" runat="server" class="alert alert-success text-center">
                                <asp:Label ID="lblHorasRestantes" CssClass="subtitulo-form-info" runat="server" Text="Tiempo Restante Para ser Modificada la Ficha de Salud Inicial: "></asp:Label>
                                <div id="countdownDiagInicial" class="subtitulo-form-info">_ Dias __ Horas __ Minutos __ Segundos</div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
                        </ContentTemplate>
                 </asp:UpdatePanel>

            <a id="aCollapseDatosPersonales" data-toggle="collapse" data-parent="#accordion" href="#divCollapseDatosPersonales" aria-expanded="true" aria-controls="divCollapseDatosPersonales">
                <table id="tblTituloDatosPersonales" class="table table-bordered table-condensed">
                    <tr class="titulo-form-fichasalud">
                        <td colspan="8" style="text-align: center;">
                            <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                <label>Datos Personales </label>&nbsp;&nbsp;<span id="iconDatosPersonales" runat="server" class="glyphicon glyphicon-triangle-bottom"></span>
                            </h4>
                        </td>
                    </tr>
                </table>
            </a>
            <div id="divCollapseDatosPersonales" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <table id="tblDatosPersonales" class="table table-bordered table-condensed">
                    <tbody>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla col-md-ficha" scope="row">Primer Apellido</th>
                            <td>
                                <asp:TextBox ID="txtPrimerApellido" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Segundo Apellido</th>
                            <td>
                                <asp:TextBox ID="txtSegundoApellido" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Nombre</th>
                            <td>
                                <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla col-md-ficha" scope="row">RUN</th>
                            <td>
                                <asp:TextBox ID="txtRut" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Fecha de Nacimiento</th>
                            <td>
                                <asp:TextBox ID="txtFechaNacimiento" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FTE3" runat="server" TargetControlID="txtFechaNacimiento" ValidChars="0123456789-/" />
                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaNacimiento" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Edad</th>
                            <td>
                                <asp:TextBox ID="txtEdad" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla col-md-ficha" scope="row">Sexo</th>
                            <td>
                                <asp:TextBox ID="txtSexo" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Domicilio</th>
                            <td>
                                <asp:TextBox ID="txtDomicilio" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Nacionalidad</th>
                            <td>
                                <asp:TextBox ID="txtNacionalidad" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla col-md-ficha" scope="row">Fecha Ingreso</th>
                            <td>
                                <asp:TextBox ID="txtFechaIngreso" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFechaIngreso" ValidChars="0123456789-/" />
                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende391" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaIngreso" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Etnia</th>
                            <td>
                                <asp:TextBox ID="txtEtnia" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Estado Civil</th>
                            <td colspan="2">
                                <asp:TextBox ID="txtEstadoCivil" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla col-md-ficha" scope="row">Región</th>
                            <td>
                                <asp:TextBox ID="txtRegion" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                            <th class="titulo-tabla col-md-ficha" scope="row">Comuna</th>
                            <td>
                                <asp:TextBox ID="txtComuna" Enabled="false" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <a id="aCollapseDatosRelevantes" data-toggle="collapse" data-parent="#accordion" href="#divCollapseDatosRelevantes" aria-expanded="true" aria-controls="divCollapseDatosRelevantes">
                <table id="tblTituloDatosRelevantes" class="table table-bordered table-condensed">
                    <tr class="titulo-form-fichasalud">
                        <td style="text-align: center;">
                            <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                <label>Datos Relevantes</label>&nbsp;&nbsp;<span id="iconDatosRelevantes" runat="server" class="glyphicon glyphicon-triangle-bottom"></span>
                            </h4>
                        </td>
                    </tr>
                </table>
            </a>

                <div id="divCollapseDatosRelevantes" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnGuardarDatosRelevantes" />
                        </Triggers>
                        <ContentTemplate>
                            <table id="tblDatosRelevantes" class="table table-bordered table-condensed">
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Inscrito en Atención Primaria</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnInscritoAtencionPrimariaSi" runat="server" GroupName="rbtnInscritoAtencionPrimaria" Text="Si" />&nbsp;
                                <asp:RadioButton ID="rbtnInscritoAtencionPrimariaNo" runat="server" GroupName="rbtnInscritoAtencionPrimaria" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Región Establecimiento</th>
                                    <td>
                                        <asp:DropDownList ID="ddlRegionEstablecimiento" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlRegionEstablecimiento_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Establecimiento</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlEstablecimiento" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="botonera pull-right">
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button btnIguales" Visible="false" ID="btnGuardarDatosRelevantes" OnClick="btnGuardarDatosRelevantes_Click" ValidationGroup="ValidaFicha" CausesValidation="true" runat="server" Text="Guardar" AutoPostback="true">
                                        <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Datos Relevantes
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                

            <a id="aCollapseAnamnesis" data-toggle="collapse" data-parent="#accordion" href="#divCollapseAnamnesis" aria-expanded="true" aria-controls="divCollapseAnamnesis">
                <table id="tblTituloAnamnesisRemota" class="table table-bordered table-condensed">
                    <tr class="titulo-form-fichasalud">
                        <td style="text-align: center;">
                            <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                <label>Anamnesis Remota</label>&nbsp;&nbsp;<span id="iconAnamnesis" runat="server" class="glyphicon glyphicon-triangle-bottom"></span>
                            </h4>
                        </td>
                    </tr>
                </table>
            </a>
            <div id="divCollapseAnamnesis" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardar" />
                    </Triggers>
                    <ContentTemplate>
                        
                        <table id="tblAntecedenteMorbido" class="table table-bordered table-condensed">
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">1. Antecedentes Mórbidos</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlAntecedentesMorbidos" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-1" scope="row">1.1 Tratamiento</th>
                                    <td colspan="3">
                                        <asp:RadioButton ID="rbtnTratamientoSi" runat="server" GroupName="rbtnTratamiento" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnTratamientoNo" runat="server" GroupName="rbtnTratamiento" Text="No" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7"></td>
                                    <td>
                                        <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right " ID="btnAgregarAntecedentesMorbidos" OnClick="btnAgregarAntecedentesMorbidos_Click" AutoPostback="true" runat="server" Visible="true">
                                        <span class="glyphicon glyphicon-ok" id="Span11"></span>&nbsp;Agregar Antecedente Mórbido
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr id="trAntecedentesMorbidos" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grd00AntecedentesMorbidos" Width="100%" OnRowDataBound="grd00AntecedentesMorbidos_OnRowDataBound" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="grd00AntecedentesMorbidos_RowCommand" CellPadding="4" Visible="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Antecedente Mórbido" DataField="DescripcionAntecedenteMorbido"></asp:BoundField>
                                                <%--<asp:BoundField HeaderText="Cod. AntecedenteMorbido" DataField="CodAntecedenteMorbido"></asp:BoundField>      --%>
                                                <asp:BoundField HeaderText="Tratamiento" DataField="Tratamiento"></asp:BoundField>
                                                <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trAvisoAntecedentesMorbidos" runat="server" visible="false">
                                    <td colspan="8">
                                        <asp:Label ID="lbl_avisoAntecedentesMorbidos" Class="help-block" runat="server" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                     </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardar" />
                    </Triggers>
                    <ContentTemplate>
                        <table id="tblAnamnesis" class="table table-bordered table-condensed">
                            <tbody>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>

                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">2. Antecedentes Quirúrgicos y Hospitalización</th>
                                    <td colspan="7">
                                        <asp:TextBox ID="txtAntecedentesQuirurgicosyH" runat="server" MaxLength="140" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                        <asp:Label ID="lblNumeroMaximo2" runat="server" Text="Máximo 140 caracteres:"></asp:Label>
                                        <asp:Label ID="lblEscritos2" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="Digitado2" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                    <asp:Label ID="lblRestantes2" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="Restante2" runat="server" Text="140"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">3.1 Fármacos</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlFarmacos" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlFarmacos_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="true">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th id="thOtrosFarmacos" visible="false" runat="server" class="titulo-tabla col-md-1" scope="row">3.1 Cual</th>
                                    <td colspan="3" id="tdOtrosFarmacos" visible="false" runat="server">
                                        <asp:TextBox ID="txtOtrosFarmacos" runat="server" CssClass="form-control input-sm" MaxLength="30" placeholder="Ingresar"></asp:TextBox>
                                        <asp:Label ID="lblNumeroMaximo3" runat="server" Text="Máximo 30 caracteres:"></asp:Label>
                                        <asp:Label ID="lblEscritos3" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="Digitado3" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                    <asp:Label ID="lblRestantes3" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="Restante3" runat="server" Text="30"></asp:Label>
                                    </td>
                                    <th id="thRellenoFarmacosOtros" runat="server"></th>
                                    <td colspan="3" id="tdRellenoFarmacosOtros" runat="server"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">3.3 Presentación</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlPresentacionFarmaco" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th></th>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <th rowspan="3" class="titulo-tabla col-md-1" scope="row">3.4 Horario y Cantidad</th>

                                    <td>
                                        <asp:CheckBox ID="chkManana" Text="Mañana" runat="server" OnCheckedChanged="chkManana_CheckedChanged" AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtManana" runat="server" MaxLength="3" CssClass="form-control form-control-fecha input-sm" placeholder="Cantidad" Enabled="false"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtManana" ValidChars="0123456789," />
                                    </td>
                                    <td>
                                        <asp:RangeValidator ID="RangeValidator5" runat="server" CssClass="help-block" ControlToValidate="txtManana" ErrorMessage="Número Inválido" MaximumValue="99" MinimumValue="0,1" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkTarde" Text="Tarde" runat="server" OnCheckedChanged="chkTarde_CheckedChanged" AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTarde" runat="server" MaxLength="3" CssClass="form-control form-control-fecha input-sm" placeholder="Cantidad" Enabled="false"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtTarde" ValidChars="0123456789," />
                                    </td>
                                    <td>
                                        <asp:RangeValidator ID="RangeValidator6" runat="server" CssClass="help-block" ControlToValidate="txtTarde" ErrorMessage="Número Inválido" MaximumValue="99" MinimumValue="0,1" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkNoche" Text="Noche" runat="server" OnCheckedChanged="chkNoche_CheckedChanged" AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoche" runat="server" MaxLength="3" CssClass="form-control form-control-fecha input-sm" placeholder="Cantidad" Enabled="false"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtNoche" ValidChars="0123456789," />
                                    </td>
                                    <td>
                                        <asp:RangeValidator ID="RangeValidator7" runat="server" CssClass="help-block" ControlToValidate="txtNoche" ErrorMessage="Número Inválido" MaximumValue="99" MinimumValue="0,1" SetFocusOnError="True" Type="Double"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7"></td>
                                    <td>
                                        <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right " ID="btnAgregarFarmacos" OnClick="btnAgregarFarmacos_Click" AutoPostback="true" runat="server" Visible="true">
                                        <span class="glyphicon glyphicon-ok" ></span>&nbsp;Agregar Fármaco
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr id="trFarmacos" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdFarmacos" Width="100%" CssClass="table table table-bordered table-hover" runat="server" OnRowDataBound="grdFarmacos_RowDataBound" OnRowCommand="grdFarmacos_RowCommand" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Fármaco" DataField="DescripcionFarmaco"></asp:BoundField>
                                                <asp:BoundField HeaderText="Presentación" DataField="DescripcionPresentacion"></asp:BoundField>
                                                <asp:BoundField HeaderText="Dosis Mañana" DataField="Manana"></asp:BoundField>
                                                <asp:BoundField HeaderText="Cantidad Mañana" DataField="CantidadManana"></asp:BoundField>
                                                <asp:BoundField HeaderText="Dosis Tarde" DataField="Tarde"></asp:BoundField>
                                                <asp:BoundField HeaderText="Cantidad Tarde" DataField="CantidadTarde"></asp:BoundField>
                                                <asp:BoundField HeaderText="Dosis Noche" DataField="Noche"></asp:BoundField>
                                                <asp:BoundField HeaderText="Cantidad Noche" DataField="CantidadNoche"></asp:BoundField>
                                                <asp:BoundField HeaderText="Descripción otros" DataField="DescripcionOtros"></asp:BoundField>
                                                <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trAvisoFarmaco" runat="server" visible="false">
                                    <td colspan="8">
                                        <asp:Label ID="lbl_avisoFarmaco" runat="server" Class="help-block" /></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th colspan="8" class="titulo-tabla col-md-1" scope="row">4. Consumo Drogas</th>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Se Presume Consumo de Droga</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnPresumeConsumoSi" runat="server" GroupName="rbtnPresumeConsumo" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnPresumeConsumoNo" runat="server" GroupName="rbtnPresumeConsumo" Text="No" />
                                    </td>
                                </tr>
                                <tr id="trAlertaSinConsumoDroga" runat="server" visible="false">
                                    <td colspan="8">
                                        <div class="alert alert-warning text-center" role="alert" id="divAlertaSinConsumoDroga" runat="server">
                                            <asp:Label ID="lblAlertaSinConsumoDroga" CssClass="subtitulo-form-info" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trGridConsumoDrogas" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdConsumoDroga" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None">
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <Columns>
                                                <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnóstico" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Droga"></asp:BoundField>
                                                <asp:BoundField DataField="TipoConsumo" HeaderText="Tipo Consumo"></asp:BoundField>
                                                <asp:BoundField DataField="NombreCompleto" HeaderText="T&#233;cnico"></asp:BoundField>
                                                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones">
                                                    <ItemStyle Width="20px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">5. Alergias</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlAlergias" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlAlergias_SelectedIndexChanged" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th id="thOtrasAlergias" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">5.1 Otros</th>
                                    <td colspan="2" id="tdOtrasAlergias" runat="server" visible="false">
                                        <asp:TextBox ID="txtOtrasAlergias" runat="server" CssClass="form-control input-sm" MaxLength="30" placeholder="Ingresar"></asp:TextBox>
                                        <asp:Label ID="lblNumeroMaximo4" runat="server" Text="Máximo 30 caracteres:"></asp:Label>
                                        <asp:Label ID="lblEscritos4" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="Digitado4" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                    <asp:Label ID="lblRestantes4" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="Restante4" runat="server" Text="30"></asp:Label>
                                    </td>
                                    <th id="threllenoAlergiasOtros" runat="server"></th>
                                    <td colspan="2" id="tdrellenoAlergiasOtros" runat="server"></td>
                                    <td id="tdAgregarAlergia" runat="server">
                                        <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right" OnClick="lnkAgregarAlergia_Click" ID="lnkAgregarAlergia" AutoPostback="true" runat="server" Visible="true">
                                        <span class="glyphicon glyphicon-ok" ></span>&nbsp;Agregar Alergia
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr id="trAlergias" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdAlergias" Width="100%" CssClass="table table table-bordered table-hover" runat="server" OnRowCommand="grdAlergias_RowCommand" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Alergia" DataField="DescripcionAlergia"></asp:BoundField>
                                                <asp:BoundField HeaderText="Descripción Otros" DataField="DescripcionOtros"></asp:BoundField>
                                                <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trAvisoAlergias" runat="server" visible="false">
                                    <td colspan="8">
                                        <asp:Label ID="lbl_avisoAlergias" Class="help-block" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th id="thVacunasAlDia" runat="server" class="titulo-tabla col-md-1" scope="row">6. Vacunas al Día</th>
                                    <td colspan="3" id="tdVacunasAlDia" runat="server">
                                        <asp:RadioButton ID="rbtnVacunasAlDiaSi" runat="server" GroupName="rbtnVacunasAlDia" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnVacunasAlDiaNo" runat="server" GroupName="rbtnVacunasAlDia" Text="No" />&nbsp;&nbsp;&nbsp;
                                    <a href="http://cdn.senainfo.cl/pdf/links/CALENDARIO-VACUNACION-2016.pdf" target="_blank">Calendario Vacunación 2016 Pinche Aquí</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">7. Transfusiones</th>
                                    <td colspan="3">
                                        <asp:RadioButton ID="rbtnTransfusionesSi" runat="server" GroupName="Transfusiones" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnTransfusionesNo" runat="server" GroupName="Transfusiones" Text="No" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">8. Antecedentes Gineco-Obstétricos</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlAntecedentesGinecoO" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Dismenorrea" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Hipermenorrea o menorragia" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Hipomenorrea" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Polimenorrea" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Oligomenorrea" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Amenorrea" Value="6"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">9. Antecedentes Familiares</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlAntecedentesFamiliares" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Otros" Value="1"></asp:ListItem>
                                            <%--<asp:ListItem Text="Hipertensión Arterial" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Diabetes Mellitus" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Enfermedades coronarias" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Dislipidemias" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Cánceres " Value="6"></asp:ListItem>
                                        <asp:ListItem Text="Tuberculosis" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="Enfermedades cerebrovasculares" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="Alergias" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="Trastornos psiquiátricos " Value="10"></asp:ListItem>
                                        <asp:ListItem Text="Hemofilia" Value="11"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th colspan="8" class="titulo-tabla col-md-1" scope="row">10. Discapacidad</th>
                                </tr>
                                <tr id="trAlertaSinDiscapacidad" runat="server" visible="false">
                                    <td colspan="8">
                                        <div class="alert alert-warning text-center" role="alert" id="divAlertaSinDiscapacidad" runat="server">
                                            <asp:Label ID="lblAlertaSinDiscapacidad" CssClass="subtitulo-form-info" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trGridDiscapacidad" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdDiscapacidad" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None">
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <Columns>
                                                <asp:BoundField DataField="FechaDiagnostico" HeaderText="Fecha Diagnóstico" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="DescripcionTipo" HeaderText="Tipo Discapacidad">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DescripcionNivel" HeaderText="Nivel"></asp:BoundField>
                                                <asp:BoundField DataField="Nombres" HeaderText="T&#233;cnico">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Observacion" HeaderText="Observaciones">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">11. Trastornos</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTrastornos" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>                                            
                                        </asp:DropDownList>
                                    </td>
                                    <th></th>
                                    <td colspan="2"></td>
                                    <td id="tdAgregarTrastorno" runat="server">
                                        <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right" ID="lnkAgregarTrastorno" OnClick="lnkAgregarTrastorno_Click" AutoPostback="true" runat="server" Visible="true">
                                        <span class="glyphicon glyphicon-ok" ></span>&nbsp;Agregar Trastorno
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr id="trTrastornos" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdTrastornos" Width="100%" CssClass="table table table-bordered table-hover" runat="server" OnRowCommand="grdTrastornos_RowCommand" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Trastornos" DataField="DescripcionTrastornos"></asp:BoundField>                                              
                                                <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trAvisoTrastornos" runat="server" visible="false">
                                    <td colspan="8">
                                        <asp:Label ID="lbl_avisoTrastornos" runat="server" Class="help-block" /></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">12. Síndromes</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlSindromes" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>                                          
                                        </asp:DropDownList>
                                    </td>
                                    <th></th>
                                    <td colspan="2"></td>
                                    <td id="tdAgregarSindrome" runat="server">
                                        <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right" ID="lnkAgregarSindrome" OnClick="lnkAgregarSindrome_Click" AutoPostback="true" runat="server" Visible="true">
                                        <span class="glyphicon glyphicon-ok" ></span>&nbsp;Agregar Síndrome
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr id="trSindrome" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdSindrome" Width="100%" CssClass="table table table-bordered table-hover" OnRowCommand="grdSindrome_RowCommand" runat="server" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Síndrome" DataField="DescripcionSindrome"></asp:BoundField>                                              
                                                <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>

                                    </td>
                                </tr>
                                <tr id="trAvisoSindrome" runat="server" visible="false">
                                    <td colspan="8">
                                        <asp:Label ID="lbl_avisoSindrome" runat="server" Class="help-block" /></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th colspan="8" class="titulo-tabla col-md-ficha" scope="row">13. Suicidio</th>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Ideación Suicida</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnIdeacionSuicidaSi" runat="server" GroupName="rbtnIdeacionSuicida" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnIdeacionSuicidaNo" runat="server" GroupName="rbtnIdeacionSuicida" Text="No" />
                                    </td>
                                </tr>
                                <tr id="trAlertaSinSuicidio" runat="server" visible="false">
                                    <td colspan="8">
                                        <div class="alert alert-warning text-center" role="alert" id="divAlertaSinSuicidio" runat="server">
                                            <asp:Label ID="lblAlertaSinSuicidio" CssClass="subtitulo-form-info" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trIntentoSuicida" runat="server" visible="false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdIntentoSuicida" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No Se Encontraron Registros">
                                            <Columns>                                           
                                                <asp:BoundField DataField="FechaDiagnostico" HeaderText="Fecha Diagnóstico" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
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
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th id="thMaternidadAdolescente" visible="false" runat="server" colspan="8" class="titulo-tabla col-md-ficha" scope="row">14. Antecedentes de Maternidad Adolescente </th>
                                    <th id="thPaternidadAdolescente" visible="false" runat="server" colspan="8" class="titulo-tabla col-md-ficha" scope="row">14. Antecedentes de Paternidad Adolescente </th>
                                </tr>
                                <tr id="trAlertaSinPMaternidad" runat="server" visible="false">
                                    <td colspan="8">
                                        <div class="alert alert-warning text-center" role="alert" id="divAlertaSinPMaternidad" runat="server">
                                            <asp:Label ID="lblAlertaSinPMaternidad" CssClass="subtitulo-form-info" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trPMaternidadAdolescente" runat="server">
                                    <td colspan="8">
                                        <asp:GridView ID="grdPMaternidadAdolescente" OnRowDataBound="grdPMaternidadAdolescente_RowDataBound" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No Existen Datos">
                                            <Columns>
                                                <asp:BoundField DataField="FechaDiagnostico" HeaderText="Fecha Diagnóstico" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="AdolescenteEmbarazada" HeaderText="Adolescente Embarazada">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NumeroSemanasGestacion" HeaderText="N° de Semanas de Gestación">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EmbarazoAbusoViolacion" HeaderText="Embarazo Producto de Abuso Sexual o Violación">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AdolescentePadreMadre" HeaderText="Adolescente Padre o Madre">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NumeroHijos" HeaderText="Numero de Hijos">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="HijosAbusoViolacion" HeaderText="Hijos/as Producto de Abuso Sexual o Violación">
                                                    <ItemStyle Wrap="False" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <div class="botonera pull-right">
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button btnIguales" Visible="false" ID="btnGuardar" OnClick="btnGuardar_Click" ValidationGroup="ValidaFicha" CausesValidation="true" runat="server" Text="Guardar" AutoPostback="true">
                                        <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Anamnesis Remota
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <a id="aCollapseExamenFisicoConciencia" data-toggle="collapse" data-parent="#accordion" href="#divCollapseExamenFisicoConciencia" aria-expanded="true" aria-controls="divCollapseExamenFisicoConciencia">
                <table id="tblTituloExamenFisicoConciencia" class="table table-bordered table-condensed">
                    <tr class="titulo-form-fichasalud">
                        <td style="text-align: center;">
                            <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                <label>Examen Físico Estado de conciencia</label>&nbsp;&nbsp;<span id="iconExamenFisicoConciencia" runat="server" class="glyphicon glyphicon-triangle-bottom"></span>
                            </h4>
                        </td>
                    </tr>
                </table>
            </a>

            <div id="divCollapseExamenFisicoConciencia" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table id="tblExamenFisicoEstadoConciencia1" class="table table-bordered table-condensed">
                            <tbody>
                                <tr>
                                    <td colspan="10"></td>
                                </tr>
                                <%--<tr>
                                    <td colspan="10">
                                        <label class="subtitulo-form">Estado de conciencia</label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Tranquilo</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnTranquiloSi" runat="server" GroupName="rbtnTranquilo" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnTranquiloNo" runat="server" GroupName="rbtnTranquilo" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Excitado</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnExcitadoSi" runat="server" GroupName="rbtnExcitado" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnExcitadoNo" runat="server" GroupName="rbtnExcitado" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Angustiado</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnAngustiadoSi" runat="server" GroupName="rbtnAngustiado" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnAngustiadoNo" runat="server" GroupName="rbtnAngustiado" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Decaído</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnDecaidoSi" runat="server" GroupName="rbtnDecaido" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnDecaidoNo" runat="server" GroupName="rbtnDecaido" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Irritable</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnIrritableSi" runat="server" GroupName="rbtnIrritable" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnIrritableNo" runat="server" GroupName="rbtnIrritable" Text="No" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardar2" />
                    </Triggers>
                    <ContentTemplate>
                        <table id="tblExamenFisicoEstadoConciencia2" class="table table-bordered table-condensed">
                            <tbody>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">PA</th>
                                    <td>
                                        <asp:DropDownList ID="ddlPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="1"></asp:ListItem> 
                                             <asp:ListItem Text="Pre Hipertensión" Value="2"></asp:ListItem> 
                                             <asp:ListItem Text="Hipertensión Arterial" Value="3"></asp:ListItem>  --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Pulso</th>
                                    <td>
                                        <asp:DropDownList ID="ddlPulso" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Bradicárdico" Value="1"></asp:ListItem>   
                                             <asp:ListItem Text="Normal" Value="2"></asp:ListItem>   
                                             <asp:ListItem Text="Taquicárdico" Value="3"></asp:ListItem>   --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">FR</th>
                                    <td>
                                        <asp:DropDownList ID="ddlFR" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Bradipnea" Value="1"></asp:ListItem>
                                             <asp:ListItem Text="Normal" Value="2"></asp:ListItem>
                                             <asp:ListItem Text="Hipernea" Value="3"></asp:ListItem>  --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">T°</th>
                                    <td>
                                        <asp:DropDownList ID="ddlTemperatura" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Subfrebil" Value="1"></asp:ListItem>      
                                            <asp:ListItem Text="Hiportemia" Value="2"></asp:ListItem>      
                                            <asp:ListItem Text="Normal" Value="3"></asp:ListItem>     --%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Movilidad</th>
                                    <td>
                                        <asp:DropDownList ID="ddlMovilidad" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Autónomo" Value="1"></asp:ListItem> 
                                             <asp:ListItem Text="Dependiente" Value="2"></asp:ListItem>   --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Peso (kg)</th>
                                    <td>
                                        <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control input-sm" MaxLength="3" placeholder="Kg"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtPeso" ValidChars="0123456789" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Talla (cm)</th>
                                    <td>
                                        <asp:TextBox ID="txtTalla" runat="server" CssClass="form-control input-sm" MaxLength="3" placeholder="Cm"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtTalla" ValidChars="0123456789" />
                                    </td>
                                    <th id="thIMC" class="titulo-tabla col-md-ficha" scope="row">IMC</th>
                                    <td>
                                        <asp:TextBox ID="txtIMC" runat="server" MaxLength="5" CssClass="form-control input-sm avoid-clicks" placeholder="Ingresar"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtIMC" ValidChars="0123456789." />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Perímetro Cintura (cm)</th>
                                    <td>
                                        <asp:DropDownList ID="ddlPerimetroCintura" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Perímetro Craneano (cm)</th>
                                    <td>
                                        <asp:DropDownList ID="ddlPerimetroCraneano" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <th class="titulo-tabla col-md-ficha" scope="row">Talla/Edad</th>
                                    <td>
                                        <asp:DropDownList ID="ddlTallaEdad" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Alta" Value="1"></asp:ListItem>    
                                            <asp:ListItem Text="Normal" Value="2"></asp:ListItem>    
                                            <asp:ListItem Text="Baja" Value="3"></asp:ListItem>    --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Peso/Talla</th>
                                    <td>
                                        <asp:TextBox ID="txtPesoTalla" runat="server" CssClass="form-control input-sm avoid-clicks" MaxLength="5" placeholder="Ingresar"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPesoTalla" ValidChars="0123456789." />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Peso/Edad</th>
                                    <td>
                                        <asp:TextBox ID="txtPesoEdad" runat="server" CssClass="form-control input-sm avoid-clicks" MaxLength="5" placeholder="Ingresar"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtPesoEdad" ValidChars="0123456789." />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Estado Nutricional</th>
                                    <td>
                                        <asp:DropDownList ID="ddlEstadoNutricional" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Desarrollo Cognitivo</th>
                                    <td>
                                        <asp:DropDownList ID="ddlDesarrolloCognitivo" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Anormal" Value="2"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Comunicación</th>
                                    <td>
                                        <asp:DropDownList ID="ddlComunicacion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Anormal" Value="2"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Desarrollo Socio Emocional</th>
                                    <td>
                                        <asp:DropDownList ID="ddlDesarrolloSocioEmocional" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Anormal" Value="2"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Próximo Control</th>
                                    <td>
                                        <asp:TextBox ID="txtProximoControl" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtProximoControl" ValidChars="0123456789-/" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender4" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtProximoControl" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="txtProximoControl" Type="Date" OnInit="rv_fecha_Init2" ValidationGroup="ValidaFicha" Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th id="thGradoTunner" runat="server" class="titulo-tabla col-md-ficha" scope="row">Grados de Tanner</th>
                                    <td id="tdGradoTunner" runat="server">
                                        <asp:DropDownList ID="ddlGradosTunner" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="I" Value="1"></asp:ListItem> 
                                            <asp:ListItem Text="II" Value="2"></asp:ListItem> 
                                            <asp:ListItem Text="III" Value="3"></asp:ListItem> 
                                            <asp:ListItem Text="IV" Value="4"></asp:ListItem>   
                                            <asp:ListItem Text="V" Value="5"></asp:ListItem>   
                                            <asp:ListItem Text="VI" Value="6"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Evaluación Ortopédica</th>
                                    <td>
                                        <asp:DropDownList ID="ddlEvaluacionOrtopedica" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="1"></asp:ListItem>  
                                            <asp:ListItem Text="Alterado" Value="2"></asp:ListItem> --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Displacia de Cadera</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlDisplaciaCadera" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Leve" Value="1"></asp:ListItem> 
                                            <asp:ListItem Text="Grave" Value="2"></asp:ListItem> 
                                            <asp:ListItem Text="Sin Displasia" Value="3"></asp:ListItem> --%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                            </tbody>
                        </table>

                        <div class="botonera pull-right">
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button btnIguales" ID="btnGuardar2" Visible="false" OnClick="btnGuardar2_Click" runat="server" Text="Guardar" ValidationGroup="ValidaFicha" CausesValidation="true" AutoPostback="true">
                                        <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Estado de Conciencia
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <a id="aCollapseExamenFisicoPiel" data-toggle="collapse" data-parent="#accordion" href="#divCollapseExamenFisicoPiel" aria-expanded="true" aria-controls="divCollapseExamenFisicoPiel">
                <table class="table table-bordered table-condensed">
                    <tr class="titulo-form-fichasalud">
                        <td colspan="8" style="text-align: center;">
                            <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                <label>Examen Físico Piel y Mucosas</label>&nbsp;&nbsp;<span id="iconExamenFisicoPiel" runat="server" class="glyphicon glyphicon-triangle-bottom"></span>
                            </h4>
                        </td>
                    </tr>
                </table>
            </a>

            <div id="divCollapseExamenFisicoPiel" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGuardar3" />
                        <asp:PostBackTrigger ControlID="lnkMostrarDerivacionVision" />
                        <asp:PostBackTrigger ControlID="lnkMostrarDerivacionAudicion" />
                        <asp:PostBackTrigger ControlID="lnkMostrarDerivacionSaludBucal" />
                        <asp:PostBackTrigger ControlID="lnkMostrarDerivacionColumna" />
                    </Triggers>
                    <ContentTemplate>

                        <ajax:ModalPopupExtender
                            ID="mpe1"
                            BehaviorID="mpe1a"
                            runat="server"
                            TargetControlID="RellenoDerivacionVision"
                            PopupControlID="modal_derivacion_Vision"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModalVision"
                            RepositionMode="RepositionOnWindowResize"
                            PopupDragHandleControlID="divheadVision">
                        </ajax:ModalPopupExtender>

                        <ajax:ModalPopupExtender
                            ID="mpe2"
                            BehaviorID="mpe2a"
                            runat="server"
                            TargetControlID="RellenoDerivacionAudicon"
                            PopupControlID="modal_derivacion_audicion"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModalAudicion"
                            RepositionMode="RepositionOnWindowResize"
                            PopupDragHandleControlID="divheadAudicion">
                        </ajax:ModalPopupExtender>

                        <ajax:ModalPopupExtender
                            ID="mpe3"
                            BehaviorID="mpe3a"
                            runat="server"
                            TargetControlID="RellenoDerivacionSaludBucal"
                            PopupControlID="modal_derivacion_saludbucal"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModalSaludBucal"
                            RepositionMode="RepositionOnWindowResize"
                            PopupDragHandleControlID="divheadSaludBucal">
                        </ajax:ModalPopupExtender>

                        <ajax:ModalPopupExtender
                            ID="mpe4"
                            BehaviorID="mpe4a"
                            runat="server"
                            TargetControlID="RellenoDerivacionColumna"
                            PopupControlID="modal_derivacion_columna"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModalColumna"
                            RepositionMode="RepositionOnWindowResize"
                            PopupDragHandleControlID="divheadColumna">
                        </ajax:ModalPopupExtender>

                        <table id="tblExamenFisicoPielMucosas" class="table table-bordered table-condensed">
                            <tbody>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <%--<tr>
                                <td colspan="8">
                                    <label class="subtitulo-form">Piel y Mucosas</label>
                                </td>
                            </tr>--%>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Color</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlColor" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Pálida" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Rubicunda" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Cianótica" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Vitíligo" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Ictericia" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Albinismo" Value="6"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Humedad</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlHumedad" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Normal" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Hiperhidrosis" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Hipohidrosis" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Bromhidrosis" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Anhidrosis" Value="5"></asp:ListItem> --%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Cabeza</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlCabeza" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Microcefalo" Value="1"></asp:ListItem> 
                                        <asp:ListItem Text="Normotenso" Value="2"></asp:ListItem> 
                                        <asp:ListItem Text="Macrocefalo" Value="3"></asp:ListItem> --%>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Cuello</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlCuello" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Tórax</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTorax" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Abdomen</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlAbdomen" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Extremidades</th>
                                    <td>
                                        <asp:DropDownList ID="ddlExtremidades" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Síntoma</th>
                                    <td>
                                        <asp:DropDownList ID="ddlSintomaExtremidades" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th id="thGenitales" runat="server" class="titulo-tabla col-md-ficha" scope="row">Genitales</th>
                                    <td id="tdGenitales" runat="server" colspan="3">
                                        <asp:DropDownList ID="ddlGenitales" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Genu Valgo</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnGenuValgoSi" runat="server" GroupName="rbtnGenuValgo" Text="Si"  />&nbsp;
                                    <asp:RadioButton ID="rbtnGenuValgoNo" runat="server" GroupName="rbtnGenuValgo" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Genu Varo</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnGenuVaroSi" runat="server" GroupName="rbtnGenuVaro" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnGenuVaroNo" runat="server" GroupName="rbtnGenuVaro" Text="No" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Pie Plano</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnPiePlanoSi" runat="server" GroupName="rbtnPiePlano" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnPiePlanoNo" runat="server" GroupName="rbtnPiePlano" Text="No" />
                                    </td>
                                    <th></th>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th id="thEvaluacionGenitales" runat="server" class="titulo-tabla col-md-ficha" scope="row">Evaluación Genitales</th>
                                    <td colspan="3" id="tdEvaluacionGenitales" runat="server">
                                        <asp:DropDownList ID="ddlEvaluacionGenitales" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Marcha</th>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlMarcha" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Visión</th>
                                    <td>
                                        <asp:DropDownList ID="ddlVision" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Lentes</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnLentesSi" runat="server" GroupName="rbtnLentes" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnLentesNo" runat="server" GroupName="rbtnLentes" Text="No" />
                                    </td>
                                    <th colspan="2" class="titulo-tabla col-md-ficha" scope="row">Derivación Visión</th>
                                    <td colspan="2">
                                        <asp:LinkButton ID="RellenoDerivacionVision" runat="server" />
                                        <asp:LinkButton ID="RellenoDerivacionAudicon" runat="server" />
                                        <asp:LinkButton ID="RellenoDerivacionSaludBucal" runat="server" />
                                        <asp:LinkButton ID="RellenoDerivacionColumna" runat="server" />

                                        <asp:LinkButton ID="lnkMostrarDerivacionVision" runat="server" OnClick="lnkMostrarDerivacionVision_Click" ValidationGroup="ValidaFicha" AutoPostBack="true" CssClass="btnIguales btn btn-info btn-sm pull-right fixed-width-button">
                                            <span id="spanDerivacionVision" runat="server" class="glyphicon glyphicon-plus"></span>&nbsp;<asp:Label ID="lblDerivacionVision" runat="server" Text="Agregar Derivación" />
                                        </asp:LinkButton><asp:Label ID="lblSinDerivacionVision" CssClass="subtitulo-form-info" Visible="false" runat="server" Text="No existe derivación registrada"></asp:Label><div id="modal_derivacion_vision" runat="server" class="popupConfirmation" style="display: none">
                                            <div id="divheadVision" class="modal-header header-modal">
                                                <asp:LinkButton ID="btnCerrarModalVision" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                                   <span aria-hidden="true">×</span>
                                                </asp:LinkButton><h4 class="modal-title">Derivación Visión</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframevision" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Audición</th>
                                    <td>
                                        <asp:DropDownList ID="ddlAudicion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Audífonos</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnAudifonosSi" runat="server" GroupName="rbtnAudifonos" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnAudifonosNo" runat="server" GroupName="rbtnAudifonos" Text="No" />
                                    </td>
                                    <th colspan="2" class="titulo-tabla col-md-ficha" scope="row">Derivación Audición</th>
                                    <td colspan="2">
                                        <asp:LinkButton ID="lnkMostrarDerivacionAudicion" runat="server" OnClick="lnkMostrarDerivacionAudicion_Click" ValidationGroup="ValidaFicha" AutoPostBack="true" CssClass="btnIguales btn btn-info btn-sm pull-right fixed-width-button">
                                            <span id="spanDerivacionAudicion" runat="server" class="glyphicon glyphicon-plus"></span>&nbsp;<asp:Label ID="lblDerivacionAudicion" runat="server" Text="Agregar Derivación" />
                                        </asp:LinkButton><asp:Label ID="lblSinDerivacionAudicion" CssClass="subtitulo-form-info" Visible="false" runat="server" Text="No existe derivación registrada"></asp:Label><div id="modal_derivacion_audicion" runat="server" class="popupConfirmation" style="display: none">
                                            <div id="divheadAudicion" class="modal-header header-modal">
                                                <asp:LinkButton ID="btnCerrarModalAudicion" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                               <span aria-hidden="true">×</span>
                                                </asp:LinkButton><h4 class="modal-title">Derivación Audición</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframeaudicion" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Salud Bucal</th>
                                    <td>
                                        <asp:DropDownList ID="ddlSaludBucal" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Ortodoncia</th>
                                    <td>
                                        <asp:RadioButton ID="rbtnOrtodonciaSi" runat="server" GroupName="rbtnOrtodoncia" Text="Si" />&nbsp;
                                        <asp:RadioButton ID="rbtnOrtodonciaNo" runat="server" GroupName="rbtnOrtodoncia" Text="No" />
                                    </td>
                                    <th colspan="2" class="titulo-tabla col-md-ficha" scope="row">Derivación Salud Bucal</th>
                                    <td colspan="2">
                                        <asp:LinkButton ID="lnkMostrarDerivacionSaludBucal" runat="server" OnClick="lnkMostrarDerivacionSaludBucal_Click" ValidationGroup="ValidaFicha" AutoPostBack="true" CssClass="btnIguales btn btn-info btn-sm pull-right fixed-width-button">
                                            <span id="spanDerivacionSaludBucal" runat="server" class="glyphicon glyphicon-plus"></span>&nbsp;<asp:Label ID="lblDerivacionSaludBucal" runat="server" Text="Agregar Derivación" />
                                        </asp:LinkButton><asp:Label ID="lblSinDerivacionSaludBucal" CssClass="subtitulo-form-info" Visible="false" runat="server" Text="No existe derivación registrada"></asp:Label><div id="modal_derivacion_saludbucal" runat="server" class="popupConfirmation" style="display: none">
                                            <div id="divheadSaludBucal" class="modal-header header-modal">
                                                <asp:LinkButton ID="btnCerrarModalSaludBucal" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                               <span aria-hidden="true">×</span>
                                                </asp:LinkButton><h4 class="modal-title">Derivación Salud Bucal</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframesaludbucal" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Columna</th>
                                    <td>
                                        <asp:DropDownList ID="ddlColumna" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <th></th>
                                    <td></td>
                                    <th colspan="2" class="titulo-tabla col-md-ficha" scope="row">Derivación Columna</th>
                                    <td colspan="2">
                                        <asp:LinkButton ID="lnkMostrarDerivacionColumna" runat="server" OnClick="lnkMostrarDerivacionColumna_Click" ValidationGroup="ValidaFicha" AutoPostBack="true" CssClass="btnIguales btn btn-info btn-sm pull-right fixed-width-button">
                                            <span id="spanDerivacionColumna" runat="server" class="glyphicon glyphicon-plus"></span>&nbsp;<asp:Label ID="lblDerivacionColumna" runat="server" Text="Agregar Derivación" />
                                        </asp:LinkButton><asp:Label ID="lblSinDerivacionColumna" CssClass="subtitulo-form-info" Visible="false" runat="server" Text="No existe derivación registrada"></asp:Label><div id="modal_derivacion_columna" runat="server" class="popupConfirmation" style="display: none">
                                            <div id="divheadColumna" class="modal-header header-modal">
                                                <asp:LinkButton ID="btnCerrarModalColumna" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                               <span aria-hidden="true">×</span>
                                                </asp:LinkButton><h4 class="modal-title">Derivación Columna</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframecolumna" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>

                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Conducta Sexual</th>
                                    <td>
                                        <asp:DropDownList ID="ddlConductaSexual" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <th id="thMenarquia" runat="server" class="titulo-tabla col-md-ficha" scope="row">Menarquía</th>
                                    <td id="tdMenarquia" runat="server">
                                        <asp:TextBox ID="txtMenarquia" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMenarquia" ValidChars="0123456789-/" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtMenarquia" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="txtMenarquia" Type="Date" OnInit="rv_fecha_Init2" ValidationGroup="ValidaFicha" Display="Dynamic" />
                                    </td>
                                    <th id="thCiclos" runat="server" class="titulo-tabla col-md-ficha" scope="row">Ciclos</th>
                                    <td id="tdCiclos" runat="server">
                                        <asp:TextBox ID="txtCiclos" runat="server" CssClass="form-control input-sm" MaxLength="3" placeholder="Ingresar"></asp:TextBox><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtCiclos" ValidChars="0123456789" />
                                    </td>
                                    <th id="thFO" runat="server" class="titulo-tabla col-md-ficha" scope="row">FO</th>
                                    <td id="tdFO" runat="server" data-container="body" data-toggle="tooltip" data-placement="top" title="Partos de término - Partos de pretérmino - Abortos espontáneos - Abortos provocados - Número de hijos vivos.">
                                        <asp:TextBox ID="txtFO" runat="server" CssClass="form-control input-sm" MaxLength="9" placeholder="N-N-N-N-N"></asp:TextBox><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtFO" ValidChars="0123456789-" />
                                    </td>
                                </tr>
                                <tr>
                                    <th id="thAbortos" runat="server" class="titulo-tabla col-md-ficha" scope="row">Abortos</th>
                                    <td id="tdAbortos" runat="server">
                                        <asp:RadioButton ID="rbtnAbortosSi" runat="server" GroupName="rbtnAbortos" Text="Si" AutoPostBack="true" />&nbsp;
                                        <asp:RadioButton ID="rbtnAbortosNo" runat="server" GroupName="rbtnAbortos" Text="No" AutoPostBack="true" />
                                    </td>
                                    <th id="thFur" runat="server" class="titulo-tabla col-md-ficha" scope="row">FUR</th>
                                    <td id="tdFur" runat="server">
                                        <asp:TextBox ID="txtFUR" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFUR" ValidChars="0123456789-/" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFUR" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                        <asp:RangeValidator ID="RangeValidator3" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="txtFUR" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="ValidaFicha" Display="Dynamic" />
                                    </td>
                                    <%--<th class="titulo-tabla col-md-ficha" scope="row">Intento Suicida</th>
                                <td>
                                     <asp:RadioButton ID="rbtnIntentoSuicidaSi" runat="server" GroupName="rbtnIntentoSuicida" Text="Si"  AutoPostBack="true" />&nbsp;
                                     <asp:RadioButton ID="rbtnIntentoSuicidaNo" runat="server"  GroupName="rbtnIntentoSuicida" Text="No"  AutoPostBack="true" />
                                </td> --%>
                                </tr>
                                <tr>
                                    <td colspan="8"></td>
                                </tr>
                                <tr>
                                    <th colspan="8" class="titulo-tabla col-md-1" scope="row">Examen de Laboratorio e Imagenología</th>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Tipo Examen</th>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlTipoExamen" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlTipoExamen_SelectedIndexChanged" runat="server" AutoPostBack="true" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Examen</th>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlExamen" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td colspan="2">
                                        <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right" ID="btnAgregarExamen" OnClick="btnAgregarExamen_Click" AutoPostback="true" runat="server" Visible="true">
                                        <span class="glyphicon glyphicon-ok" ></span>&nbsp;Agregar Examen
                                        </asp:LinkButton></td>
                                </tr>
                                <tr id="trExamenes" runat="server" visible=" false">
                                    <td colspan="8">
                                        <asp:GridView ID="grdExamenes" Width="100%" CssClass="table table table-bordered table-hover" OnRowCommand="grdExamenes_RowCommand" runat="server" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="Tipo de examen" DataField="DescripcionTipoExamen"></asp:BoundField>
                                                <asp:BoundField HeaderText="Examen" DataField="DescripcionExamen"></asp:BoundField>
                                                <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:Label ID="lbl_avisoExamen" Class="help-block" runat="server" Visible="false" /></td>
                                </tr>
                            </tbody>
                        </table>

                        <div class="botonera pull-right">
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button btnIguales" ID="btnGuardar3" Visible="false" runat="server" OnClick="btnGuardar3_Click" ValidationGroup="ValidaFicha" CausesValidation="true" Text="Guardar" AutoPostback="true">
                                    <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Piel y Mucosas
                            </asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <table id="tblHistoriaClinica" runat="server" class="table table-bordered table-condensed">
                <tr class="titulo-form-fichasalud">
                    <td style="text-align: center;" colspan="8">
                        <h4 style="margin-top: 0px; margin-bottom: 0px;">
                            <label>Historia Clínica Evolutiva</label>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:TextBox ID="txtHistoriaClinicaEvolutiva" TextMode="MultiLine" MaxLength="1000" runat="server" CssClass="form-control input-sm"></asp:TextBox><asp:Label ID="lblNumeroMaximo" runat="server" Text="Máximo 1000 caracteres:"></asp:Label><asp:Label ID="lblEscritos" runat="server" Text="Escritos "></asp:Label><asp:Label ID="Digitado" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="lblRestantes" runat="server" Text="Restantes ">
                        </asp:Label><asp:Label ID="Restante" runat="server" Text="1000"></asp:Label><div class="alert alert-warning text-center" role="alert" id="divCaracteres" runat="server" style="display: none">
                            <span class="glyphicon glyphicon-warning-sign"></span>
                            <asp:Label ID="lblbmsg" runat="server" Text="Se han sobrepasado el límite de 1000 caracteres"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="8"></td>
                </tr>
            </table>

            <div class="botonera pull-right">
                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button btnIguales" ID="btnGuardarFinal" Visible="false" runat="server" OnClick="btnGuardarFinal_Click" ValidationGroup="ValidaFicha" CausesValidation="true" Text="Guardar" AutoPostback="true">
                                    <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Ficha de salud Inicial
                </asp:LinkButton>
            </div>
        </div>
         </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>