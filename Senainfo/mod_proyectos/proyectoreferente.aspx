<%@ Page Language="C#" AutoEventWireup="true" CodeFile="proyectoreferente.aspx.cs" Inherits="Proyectos_proyectoreferente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>



<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Proyecto Adjudicado / En Ejecución :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/senainfoTools.js"></script>

    <%--<link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />--%>
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <%--<script src="../js/ie-emulation-modes-warning.js"></script>--%>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <%--    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.1.1.min.js"></script>--%>
    <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <!--<script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script> -->

    <!-- originales -->
    <!--<script src="../Script/jquery.min.js"></script> 
    <script src="../Script/jquery-1.4.3.min.js"></script>-->


    <script type="text/javascript">


        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;
            var txt;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;

            }

        };

        $(function () {

            $("#txt004").Rut({
                format_on: 'keyup',
                on_error: function () {
                    $("#next").addClass("disabled");
                    $("#btn001").addClass("disabled");
                    $("#msjRutInvalido").removeAttr("style");
                },
                on_success: function () {
                    $("#next").removeClass("disabled");
                    $("#btn001").removeClass("disabled");
                    $("#msjRutInvalido").attr("style", "display:none;");
                },
            });
        });

        
        function pageLoad(sender, args) {
            $(function () {

                $("#txt004").Rut({
                    format_on: 'keyup',
                    on_error: function () {
                        $("#next").addClass("disabled");
                        $("#btn001").addClass("disabled");
                        $("#msjRutInvalido").removeAttr("style");
                        $("#txt004").css("background-color", "#F2F5A9");
                        $("#txt004").val("");
                    },
                    on_success: function () {
                        $("#next").removeClass("disabled");
                        $("#btn001").removeClass("disabled");
                        $("#msjRutInvalido").attr("style", "display:none;");
                        $("#txt004").css("background-color", "white");
                    },
                    validation: true
                });
            });
        }
        

        function bloquearTabs() {
            $("#tabs").css('pointer-events', 'none')
        }

        function desbloquearTabs() {
            $("#tabs").css('pointer-events', '');
        }

        function bloquearInputs() {
            $("#utab3 input").attr("disabled", true);
            $("#utab3 select").attr("disabled", true);
            $("#calAniversario").css("pointer-events", "none");
        }

        function habilitarInputsModificar() {
            $("#txt003").removeAttr("disabled");
            $("#txt005").removeAttr("disabled");
            $("#txt006").removeAttr("disabled");
            $("#txt007").removeAttr("disabled");
            $("#txt008").removeAttr("disabled");
            $("#txt010").removeAttr("disabled");
            $("#txt011").removeAttr("disabled");
        }


        function siguienteTab2() {

            //var errores = 0;

            //var errRut = 0;

            //if ($("#ddown005").val() == "-2") {
            //    alert("entre");
            //    //$("#ddown005").addClass("modificaBackground");
            //    //$(".col-sm-10 #ddown001").css({ "background-color": "pink" });
            //    errores++;
            //}
            //if ($("#ddown001").val() == 0) {
            //    //$(".col-sm-10 #ddown001").addClass("modificaBackground");
            //    errores++;
            //}

            //if ($("#txt014").val() == "") {
            //  errores++;
            //}

            //if ($("#txt013").val() == "") {
            //  errores++;
            //}

            //if ($("#txt003").val() == "") {
            //  errores++;
            //}

            //if ($("#ddown004").val() == "0") {
            //  errores++;
            //}

            //if ($("#cal001").val() == "") {
            //  errores++;
            //}

            //if ($("txt005").val() == "") {
            //  errores++;
            //}

            ////if ($("#customvalidatorR").length > 0 || $("#CustomValidator2").length > 0 ) {
            ////  errores++;
            ////}

            //if ($("#CustomValidatorR").is(":visible")) {
            //  errRut++;
            //  //alert("El rut de proyecto esta incorrecto");
            //}

            //if ($("#CustomValidator2").is(":visible")) {
            //  errRut++;
            //  //alert("el rut de director esta incorrecto");
            //}

            ////if (errores > 0) {
            ////  alert("Debe llenar todos los campos obligatorios");
            ////} else if (errRut > 0) {
            ////  alert("Hay errores en los campos de Rut Proyecto o Rut Director, favor Revisar");
            ////} else {
            ////  $("#opt2").click();
            ////  $("#opt1").css('color', '#337ab7');
            //  //}
            //return true;
        };

        function siguienteTab3() {
            //  var errores = 0;

            //  if ($("#txt001a").val() == "") {
            //    errores++;
            //  }

            //  if ($("#txt002a").val() == "") {
            //    errores++;
            //  }

            //  if ($("#txt003a").val() == "") {
            //    errores++;
            //  }

            //  if ($("#ddown003a").val() == 0) {
            //    errores++;
            //  }

            //  if ($("#ddown006a").val() == 0) {
            //    errores++;
            //  }

            //  if ($("#ddown005a").val() == 0  ) {
            //    errores++;
            //  }

            //  if ($("#ddown004a").val() == 0) {
            //    errores++;
            //  }

            //  if ($("#ddown007a").val() == 0) {
            //    errores++;
            //  }

            //  if (errores > 0) {
            //    alert("Debe llenar los campos obligatorios");
            //  } else {
            //    $("#opt3").click();
            //    $("#opt2").css('color', '#337ab7');
            //  }
            //};
        }

        function siguienteTab4() {
            var errores = 0;

            //if ($("#txt005b").val() == "") {
            //  errores++;
            //}

            //if (errores > 0) {
            //  alert("Debe llenar los campos obligatorios");
            //} else {
            //  $("#opt4").click();
            //  $("#opt3").css('color', '#337ab7');
            //}

        }

        //$(document).ready(function () {
        //  if ($("#divAlert").length > 0) {
        //    $("#divAlert").fadeOut(10000, "linear");
        //  }
        //});


    </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <style>
        modificaBackground
        {
            background-color: pink;
        }

        .pestaña-roja {
            background-color: red;
        }

    </style>
    <!-- Fixed navbar onmousemove="SetProgressPosition(event)" -->
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div class="container theme-showcase" role="main">
            <ol class="breadcrumb">
                <li><a href="../index.aspx">Inicio</a></li>
                <li class="active">Proyecto Adjudicado / En Ejecución</li>
            </ol>

            <div runat="server" class=" alert alert-warning text-center" role="alert" id="alertaFactores" visible="false">
                <span class="glyphicon glyphicon-warning-sign"></span>
                <asp:Label ID="lbl031" runat="server" Text=""></asp:Label>
            </div>

            <asp:Panel runat="server" ID="pnlAlert">
                <div id="divAlert" class=" alert alert-warning text-center" runat="server">
                    <span class="glyphicon glyphicon-warning-sign"></span>Ingrese todos los datos obligatorios
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlCorrecto">
                <div class=" alert alert-success alert-dismissible text-center" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><strong>&times;</strong></span></button>
                    <span class="glyphicon glyphicon-ok"></span>El proyecto ha sido creado correctamente.
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlActualizado">
                <div class=" alert alert-success alert-dismissible text-center" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><strong>&times;</strong></span></button>
                    <span class="glyphicon glyphicon-ok"></span>El proyecto ha sido actualizado correctamente.
                </div>
            </asp:Panel>

            <div class="well">

                <h4 class="subtitulo-form">Proyecto Adjudicado / En Ejecución</h4>


                <asp:HiddenField ID="tabSelected" runat="server" Value="0" />


                <asp:Panel ID="utab3" runat="server">
                    <div id="tabs">
                        <ul class="nav nav-tabs tab-fixed-height nav-justified" role="tablist">
                            <li role="presentation" class="active" id="tab1">
                                <a href="#home" aria-controls="home" id="opt1" runat="server" role="tab" data-toggle="tab">DATOS DEL PROYECTO
                                </a></li>
                            <li role="presentation" id="tab2">
                                <a href="#profile" aria-controls="profile" id="opt2" runat="server" role="tab" data-toggle="tab">DATOS TECNICOS</a></li>
                            <li role="presentation" id="tab3">
                                <a href="#messages" aria-controls="messages" role="tab" runat="server" id="opt3" data-toggle="tab">MONTOS Y FACTORES</a></li>
                            <li role="presentation" id="tab4">
                                <a href="#settings" aria-controls="settings" role="tab" runat="server" id="opt4" data-toggle="tab">TERMINO DEL PROYECTO</a></li>
                        </ul>
                    </div>

                    <!-- Tab panes -->

                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane fade in active" id="home">
                            <asp:UpdatePanel ID="updatePanelTab1" runat="server">
                                <ContentTemplate>

                                    <!-- Modal Institución -->
                                    <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" ID="btnCerrarModal4" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                  <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">INSTITUCION</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_bsc_institucion" runat="server"></iframe>
                                        </div>
                                    </div>
                                    <cc1:ModalPopupExtender ID="mpe4a" runat="server" BackgroundCssClass="modalBackground" BehaviorID="mpe4a" CancelControlID="btnCerrarModal4" DropShadow="true" PopupControlID="modal_bsc_institucion" TargetControlID="imb_lupa_modal">
                                    </cc1:ModalPopupExtender>
                                    <!-- fin Modal -->

                                    <%-- Modal Proyecto --%>
                                    <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" ID="btnCerrarModalProyecto" aria-label="close" runat="server" Text="Cerrar" CausesValidation="false">
                                                <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">PROYECTO</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_bsc_proyecto" runat="server"></iframe>
                                        </div>
                                    </div>
                                    <cc1:ModalPopupExtender ID="mpeProy" runat="server" BackgroundCssClass="modalBackground" BehaviorID="mpeProy" CancelControlID="btnCerrarModalProyecto" DropShadow="true" PopupControlID="modal_bsc_proyecto" TargetControlID="imb_lupa_modal_proyecto">
                                    </cc1:ModalPopupExtender>

                                    <%-- Fin Modal --%>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <h4 class="subtitulo-form">Datos del Proyecto</h4>

                                            <table class="table table-bordered table-condensed">
                                                <tr>
                                                    <th class="titulo-tabla col-md-1">Región *</th>
                                                    <td class="col-md-4">
                                                        <asp:DropDownList ID="ddown005" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown005_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                    <th class="titulo-tabla col-md-1">Institución *</th>
                                                    <td>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddown001" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                            </asp:DropDownList>
                                                            <asp:LinkButton ID="imb_lupa_modal" ToolTip="Buscar Institución" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion','../mod_proyectos/proyectoreferente.aspx', 'mpe4a' )" CausesValidation="False">
                                                    <span class="glyphicon glyphicon-question-sign" aria-label="Busca Instituciones"></span>
                                                            </asp:LinkButton>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Código Proyecto *</th>
                                                    <td>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txt014" runat="server" AutoPostBack="True" placeholder="Seleccione + para generar código" CssClass="form-control input-sm" ONVALUECHANGE="txt014_ValueChange" ReadOnly="true"></asp:TextBox>
                                                            <asp:LinkButton ID="ImageButton3" ToolTip="Nuevo Código" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClick="ImageButton3_Click1">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="imb_lupa_modal_proyecto" ToolTip="Buscar Proyecto" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca%20Proyectos','../mod_proyectos/proyectoreferente.aspx','mpeProy' )" CausesValidation="false">
                                                                <span class="glyphicon glyphicon-question-sign" aria-label="Busca Proyectos"></span>
                                                            </asp:LinkButton>
                                                            <%--<cc1:MaskedEditExtender ID="MaskedEditExtender234" runat="server" TargetControlID="txt014" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999999" BehaviorID="_content_MaskedEditExtender234" Century="2000" />--%>
                                                            <asp:ImageButton ID="ex" runat="server" ImageUrl="~/images/UpdateItem.gif" OnClick="ImageButton3_Click" Visible="false" />

                                                        </div>
                                                        <asp:Panel ID="pnl001" runat="server" HorizontalAlign="Center" Visible="False">
                                                            <asp:Label ID="lbl003" runat="server"></asp:Label>

                                                            <asp:Button ID="imb001" runat="server" CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" OnClick="WebImageButton4_Click" Text="Sugerir" />

                                                        </asp:Panel>
                                                    </td>
                                                    <th class="titulo-tabla">Estado Proyecto</th>
                                                    <td class="text-center">
                                                        <div class="text-center">
                                                            <asp:RadioButtonList ID="rdolist001" align="center" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Enabled="False" Selected="True" Value="0">Adjudicado</asp:ListItem>
                                                                <asp:ListItem Enabled="False" Value="1">En Ejecución</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Nombre Proyecto *</th>
                                                    <td>
                                                        <asp:TextBox ID="txt013" runat="server" CssClass="form-control input-sm col-md-5" placeholder="Ingrese Nombre del proyecto" />
                                                    </td>
                                                    <th class="titulo-tabla">Nombre Corto *</th>
                                                    <td>
                                                        <asp:TextBox ID="txt003" runat="server" CssClass="form-control input-sm col-md-5" placeholder="Ingrese Nombre como lo conoce" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Línea de Acción(Tipo de Proyecto) *</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown004" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown004_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                    <th class="titulo-tabla">Fecha Inicio *</th>
                                                    <td>
                                                        <asp:TextBox ID="cal001" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" ONVALUECHANGED="cal001_ValueChanged" placeholder="dd-mm-aaaa" MaxLength="10" OnTextChanged="cal001_TextChanged" AutoPostBack="true" />
                                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1260" runat="server" BehaviorID="_content_CalendarExtende1260" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="cal001" ErrorMessage="Fecha Inválida" Display="Dynamic" CssClass="help-block" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Fecha Término *</th>
                                                    <td>
                                                        <asp:TextBox ID="cal003" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" ONVALUECHANGED="cal003_ValueChanged" placeholder="dd-mm-aaaa" MaxLength="10" />
                                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1272" runat="server" BehaviorID="_content_CalendarExtende1272" Format="dd-MM-yyyy" TargetControlID="cal003" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="cal003" ErrorMessage="Fecha Inválida" Display="Dynamic" CssClass="help-block" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="cal003" ValidChars="0123456789-/" />
                                                    </td>
                                                    <th class="titulo-tabla">Rut Proyecto *</th>
                                                    <td>
                                                        <asp:TextBox ID="txt004" runat="server" AutoPostBack="false" MaxLength="12" CssClass="form-control  input-sm" ONVALUECHANGE="txt004_ValueChange" placeholder="Ingrese rut" OnTextChanged="txt004_TextChanged" />
                                                        <span id="msjRutInvalido" class="text-warning text-uppercase" style="display:none;"><strong>Rut Invalido</strong></span>
                                                        <cc1:FilteredTextBoxExtender ID="filteredTxt004" TargetControlID="txt004" runat="server" ValidChars="0123456789-Kk." />
                                                        <%--<cc1:MaskedEditExtender ID="MaskedEditExtender240" runat="server" TargetControlID="txt004" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$" BehaviorID="_content_MaskedEditExtender240" Century="2000" />--%>
                                                        <%--<asp:CustomValidator ID="CustomValidatorR" runat="server" CssClass="help-block" ControlToValidate="txt004" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />--%>
                                                        <asp:Panel ID="pnl003" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px" Height="1px" HorizontalAlign="Center" Visible="False" Width="250px">
                                                            <asp:Label ID="lbl004" runat="server" Display="Dynamic" CssClass="help-block" Visible="false"></asp:Label>
                                                            &nbsp;
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Dirección *</th>
                                                    <td>
                                                        <asp:TextBox ID="txt005" runat="server" CssClass="form-control  input-sm" placeholder="Ingrese Direccion" />
                                                    </td>
                                                    <th class="titulo-tabla">Comuna *</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown006" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Localidad</th>
                                                    <td>
                                                        <asp:TextBox ID="txt0015" runat="server" CssClass="form-control  input-sm" MaxLength="30" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt0015" ValidChars="abcdefghijklmnñoprstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ " />
                                                    </td>
                                                    <th class="titulo-tabla">Teléfono</th>
                                                    <td>
                                                        <asp:TextBox ID="txt006" runat="server" CssClass="form-control  input-sm" placeholder="Ingrese Telefono" />
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt006" ErrorMessage="Teléfono Inválido"  Display="Dynamic" CssClass="help-block"  ValidationExpression="^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$"></asp:RegularExpressionValidator>--%>
                                                        <cc1:FilteredTextBoxExtender ID="ftbe1" runat="server" ValidChars="+1234567890 " TargetControlID="txt006" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">E-Mail</th>
                                                    <td>
                                                        <asp:TextBox ID="txt007" runat="server" CssClass="form-control  input-sm" MaxLength="50" placeholder="Ingrese E-mail" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt007" ErrorMessage="Correo inválido" Display="Dynamic" CssClass="help-block" ValidationExpression="^[_a-z0-9-_A-Z0-9-]+(\.[_a-z0-9-_A-Z0-9-]+)*@[a-z0-9-A-Z0-9-]+(\.[a-z0-9-A-Z0-9-]+)*(\.[a-zA-Z]{2,3})$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <th class="titulo-tabla">Fax</th>
                                                    <td>
                                                        <asp:TextBox ID="txt008" runat="server" CssClass="form-control  input-sm" placeholder="Ingrese Fax" />
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt008" ErrorMessage="Fax Inválido"  Display="Dynamic" CssClass="help-block"  ValidationExpression="^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$"></asp:RegularExpressionValidator>--%>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="+1234567890 " TargetControlID="txt008" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Director</th>
                                                    <td>
                                                        <asp:TextBox ID="txt010" runat="server" CssClass="form-control  input-sm" placeholder="Ingrese Nombre del Director" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txt010" ValidChars="abcdefghijklmnñoprstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ " />
                                                    </td>
                                                    <th class="titulo-tabla">Rut Director</th>
                                                    <td>
                                                        <asp:TextBox ID="txt011" runat="server" CssClass="form-control  input-sm" ONVALUECHANGE="txt011_ValueChange" placeholder="Ingrese Rut del Director" MaxLength="10" />
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txt011" ErrorMessage="Rut Inválido"  Display="Dynamic" CssClass="help-block"  ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)"></asp:RegularExpressionValidator>--%>
                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" CssClass="help-block" ControlToValidate="txt011" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />
                                                        <cc1:FilteredTextBoxExtender ID="ftrutDirector" runat="server" TargetControlID="txt011" ValidChars="1234567890-Kk" />
                                                        <%--<asp:CustomValidator id="cv_rut" runat="server" CssClass="help-block"  ControlToValidate="txt011" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />--%>
                                                        <%--<asp:Panel ID="pnl002" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px" Height="1px" HorizontalAlign="Center" Visible="False" Width="250px">
                                                  <asp:Label ID="lbl002" runat="server" Font-Size="11px"></asp:Label>
                                                  &nbsp;
                                                </asp:Panel>--%>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Fecha de Aniversario</th>
                                                    <td>
                                                        <asp:TextBox ID="calAniversario" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" MaxLength="10"></asp:TextBox>
                                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" BehaviorID="_content_CalendarExtende1" Format="dd-MM-yyyy" TargetControlID="calAniversario" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="calAniversario" ErrorMessage="Fecha Inválida" Display="Dynamic" CssClass="help-block" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="calAniversario" ValidChars="0123456789-/" />
                                                    </td>
                                                    <th class="titulo-tabla">Banco</th>
                                                    <td>
                                                        <div class="input-group">
                                                            <asp:DropDownList ID="ddown008" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span class="input-group-addon-telefono">C.C.</span>
                                                            <asp:TextBox ID="txt012" runat="server" CssClass="form-control  input-sm" placeholder="N° cuenta corriente" />
                                                        </div>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txt012" ErrorMessage="Cuenta Corriente Inválida" Display="Dynamic" CssClass="help-block" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                            </table>
                                            <h4>
                                                <label class="subtitulo-form">Sólo si es un proyecto de continuidad, registre el proyecto que lo antecede:</label></h4>
                                            <table class="table table-bordered table-condensed">
                                                <tr>
                                                    <th class="titulo-tabla col-md-1">Institución Origen</th>
                                                    <td class="col-md-4">
                                                        <asp:DropDownList ID="ddwlist001" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddwlist001_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                    <th class="titulo-tabla col-md-1">Proyecto Origen</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddwlist002" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddwlist002_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                            <div class="botonera pull-right">
                                                <asp:LinkButton ID="btnnext" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_nexttab1_click" Visible="false">
                                                        <span class="glyphicon glyphicon-arrow-right"></span>&nbsp;Siguiente
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="limpiarTab1" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="limpiarTab1_Click" CausesValidation="false">
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="next" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClientClick="return siguienteTab2();" OnClick="next_Click" CausesValidation="false">
                                              <span class="glyphicon glyphicon-arrow-right"></span>&nbsp;Siguiente
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="profile">
                            <asp:UpdatePanel ID="updatePanelTab2" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnl_utab2" runat="server" Visible="true">
                                                <h4 class="subtitulo-form">Datos Técnicos</h4>
                                                <table class="table table-bordered table-condensed">
                                                    <tr>
                                                        <th class="titulo-tabla col-md-1">Edad máxima de permanencia *</th>
                                                        <td class="col-md-4">
                                                            <asp:TextBox ID="txt001a" MaxLength="2" runat="server" CssClass="form-control  input-sm" />
                                                            <cc1:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt001a" ValidChars="0123456789-/" />
                                                        </td>
                                                        <th class="titulo-tabla col-md-1">Edad mínima *</th>
                                                        <td>
                                                            <asp:TextBox ID="txt002a" MaxLength="99" runat="server" CssClass="form-control  input-sm" />
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt002a" ValidChars="0123456789-/" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla">Edad máxima ingreso *</th>
                                                        <td>
                                                            <asp:TextBox ID="txt003a" MaxLength="2" runat="server" CssClass="form-control  input-sm" />
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt003a" ValidChars="0123456789-/" />
                                                        </td>
                                                        <th class="titulo-tabla">Tipo de Atención *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddown003a" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla">Modelo intervención *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddown006a" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown006a_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <th class="titulo-tabla">Modalidad de atención(Temática) *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddown005a" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown005a_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla">Sistema Asistencial</th>
                                                        <td>
                                                            <asp:TextBox ID="txt005a" runat="server" CssClass="form-control input-sm col-md-5" ReadOnly="">Ley 20.032</asp:TextBox></td>
                                                        <th class="titulo-tabla">Depto. SENAME que depende *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddown004a" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla">Tipo de pago *</th>
                                                        <td colspan="3">
                                                            <asp:DropDownList ID="ddown007a" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm" Visible="true">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>

                                                <div class="botonera pull-right">
                                                    <asp:LinkButton ID="btnnext1" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_nexttab2_click" Visible="false">
                                                   <span class="glyphicon glyphicon-arrow-right"></span>&nbsp;Siguiente
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="limpiarTab2" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="limpiarTab2_Click">
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClientClick="siguienteTab3();" OnClick="LinkButton1_Click">
                                              Siguiente&nbsp;<span class="glyphicon glyphicon-arrow-right"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="messages">
                            <asp:UpdatePanel ID="updatePanelTab3" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h4 class="subtitulo-form">Montos y Factores</h4>
                                            <table class="table table-bordered table-condensed">
                                                <tr>
                                                    <th class="titulo-tabla col-md-1">N° de Etapas</th>
                                                    <td class="col-md-4">
                                                        <asp:TextBox ID="txt001b" runat="server" CssClass="form-control  input-sm" MaxLength="3" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txt001b" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                    </td>
                                                    <th class="titulo-tabla col-md-1">Monto de inversión</th>
                                                    <td>
                                                        <asp:TextBox ID="txt002b" runat="server" CssClass="form-control  input-sm" MaxLength="14" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txt002b" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Monto de operación</th>
                                                    <td>
                                                        <asp:TextBox ID="txt003b" runat="server" CssClass="form-control  input-sm" MaxLength="14" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txt003b" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                    </td>
                                                    <th class="titulo-tabla">Monto personal</th>
                                                    <td>
                                                        <asp:TextBox ID="txt004b" runat="server" CssClass="form-control  input-sm" MaxLength="14" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txt004b" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla">Número Plaza *</th>
                                                    <td>
                                                        <asp:TextBox ID="txt005b" runat="server" CssClass="form-control  input-sm" MaxLength="4" />
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txt005b" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                    </td>
                                                    <th class="titulo-tabla">Factor vida familiar</th>
                                                    <td class="text-center">
                                                        <asp:RadioButton ID="rdo001b" runat="server" Font-Size="11px" GroupName="gr3" Text="Si" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="rdo002b" runat="server" Font-Size="11px" GroupName="gr3" Text="No" />
                                                    </td>
                                                </tr>

                                            </table>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <!-- Monto FIjo -->
                                            <div class="col-sm-6">
                                                <table class="table table-bordered">
                                                    <tr>
                                                        <td colspan="4" class="titulo-tabla-centrado">
                                                            <asp:Label ID="Label1" runat="server" Text="MONTO FIJO"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="titulo-tabla-centrado">
                                                            <asp:Label ID="Label2" runat="server" Text="Factores Asociados"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl005" runat="server" Text="Factor USS"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl006" runat="server" Text="Cobertura"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="LBL" runat="server" Text="Calidad Vida Familiar"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl008" runat="server" Text="Asig. Zona Ley 20032"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl027" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl028" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl029" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl030" runat="server">---</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="titulo-tabla-centrado" colspan="4">
                                                            <asp:Label ID="lbl017" runat="server" Text="Factor USS"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text-center" colspan="4">
                                                            <asp:Label ID="lbl019" runat="server">---</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <!-- Monto Variable -->
                                            <div class="col-sm-6">
                                                <table class="table table-bordered">
                                                    <tr>
                                                        <td colspan="5" class="titulo-tabla-centrado">
                                                            <asp:Label ID="Label3" runat="server" Text="MONTO VARIABLE"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" class="titulo-tabla-centrado">
                                                            <asp:Label ID="Label4" runat="server" Text="Factores Asociados" Width="150px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl009" runat="server" Text="Factor Ley"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl010" runat="server" Text="Edad"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl012" runat="server" Text="Complejidad"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl013" runat="server" Text="Discapacidad"></asp:Label>
                                                        </td>
                                                        <td class="titulo-tabla-centrado">
                                                            <asp:Label ID="lbl014" runat="server" Text="Asig. Zona Ley 20032"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl021" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl022" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl023" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl024" runat="server">---</asp:Label>
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lbl025" runat="server">---</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="titulo-tabla-centrado" colspan="5">
                                                            <asp:Label ID="lbl018" runat="server" Text="USS"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text-center" colspan="5">
                                                            <asp:Label ID="lbl020" runat="server">---</asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="botonera pull-right">
                                                <asp:LinkButton ID="WebImageButton4" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="WebImageButton4_Click2">
                                                  <span class="glyphicon glyphicon-stats"></span>&nbsp;Calcular Factores
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_nexttab3_click" Visible="false">
                                               <span class="glyphicon glyphicon-arrow-right"></span>&nbsp;Siguiente
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="limpiarTab3" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="limpiarTab3_Click">
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClientClick="siguienteTab4();" OnClick="LinkButton2_Click">
                                              <span class="glyphicon glyphicon-arrow-right"></span>&nbsp;Siguiente
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div role="tabpanel" class="tab-pane fade" id="settings">
                            <asp:UpdatePanel ID="updatePanelTab4" runat="server">
                                <ContentTemplate>
                                    <%--<asp:Panel ID="pnl_utab4" runat="server" Visible="true">--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h4 class="subtitulo-form">Término del Proyecto</h4>

                                            <asp:Panel ID="infoTerminoProyecto" runat="server" CssClass="panel-info panel-primary-info text-center nopadding" Visible="true">
                                                <div class="panel-heading ">
                                                    Información
                                                </div>
                                                <div class="panel-footer">
                                                    <p>
                                                        No aplica seleccionar causal de término de proyecto.
                                                    </p>
                                                </div>
                                            </asp:Panel>
                                            <table class="table table-bordered" id="tblCausalTerminoProyecto" runat="server" visible="false">
                                                <tr>
                                                    <td class="titulo-tabla col-md-1">
                                                        <asp:Label runat="server" ID="lblCausalTerminoProyecto" Text="Causal Término del Proyecto" Visible="false"></asp:Label>
                                                    </td>

                                                    <td>
                                                        <asp:DropDownList ID="ddown001d" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm" Visible="false">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>

                                            <div class="botonera pull-right">
                                                <%--<asp:Button ID="WebImageButton5" runat="server" CssClass="btn btn-info btn-sm btn-ancho-100" OnClick="WebImageButton5_Click1" Text="Actualizar" Visible="false" />--%>
                                                <%--<asp:LinkButton ID="WebImageButton5" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="WebImageButton5_Click1" Visible="false">
                                                    <span class="glyphicon glyphicon-refresh"></span>&nbsp;Actualizar
                                                </asp:LinkButton>--%>
                                                <%--<asp:Button ID="btn001" runat="server" CssClass="btn btn-info btn-sm btn-ancho-100" OnClick="btn001_Click" Text="Guardar Datos Del Proyecto" />--%>
                                                <asp:LinkButton ID="limpiaTab4" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="limpiaTab4_Click" Visible="false">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btn001" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btn001_Click" autopostback="true">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;<asp:Label ID="lblBtn" runat="server" Text="Guardar Datos del Proyecto"></asp:Label>
                                                </asp:LinkButton>

                                            </div>

                                        </div>
                                    </div>
                                    <%--<div class="subtitulo-form" style="padding-bottom: 5px; padding-top: 5px;">
                                          Término del Proyecto</div>
                                        <table id="Table2" runat="server" class="table-sinmargen table-bordered table-col-fix table-condensed">
                                          <tr>
                                            <th class="titulo-tabla" scope="row" visible="False">Causal Término del Proyecto</th>
                                            <td>
                                              
                                            </td>
                                          </tr>
                                          </table>
                                        <div class="botonera pull-right">
                                          
                                        </div>--%>

                                    <%--</asp:Panel>--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <br />
                        </div>
                    </div>

                </asp:Panel>
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

        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <%--<script src="../js/ie10-viewport-bug-workaround.js"></script>--%>
        <!-- Latest compiled and minified JavaScript -->
    </form>
</body>

</html>