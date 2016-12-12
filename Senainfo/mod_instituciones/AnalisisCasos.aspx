<%@ Page Language="C#" AutoEventWireup="true" UICulture="es" CodeFile="AnalisisCasos.aspx.cs" Inherits="mod_instituciones_AnalisisCasos" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc2" TagName="menu_colgante" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <meta http-equiv="content-type" content="application/xhtml+xml; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico" />
    <title>Registro Análisis de Casos :: Senainfo :: Servicio Nacional de Menores</title>


    <%-- JS --%>
    <script type="text/javascript" src="../js/jquery-2.1.4.js"></script>
    <script type="text/javascript" src="../js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../js/senainfoTools.js"></script>
    <script type="text/javascript" src="../js/bootstrap3.3.4.min.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/dataTables.bootstrap.js"></script>
    <%--<script type="text/javascript" src="../js/dataTables.responsive.min.js"></script>--%>
    <%--<script type="text/javascript" src="../js/responsive.bootstrap.min.js"></script>--%>
    <%--<script type="text/javascript" src="../js/dataTables.fixedHeader.js"></script>--%>
    <%--<script type="text/javascript" src="../js/dataTables.fixedHeader.min.js"></script>--%>
    <%--<script type="text/javascript" src="../js/notify.js"></script>--%>
    <%--<script type="text/javascript" src="../js/moment.js"></script>--%>
    <script type="text/javascript" src="../js/jquery.plugin.js"></script>
    <script type="text/javascript" src="../js/jquery.maxlength.js"></script>

    <%-- JS --%>


    <%-- CSS Stylesheets --%>

    <%--<link href="../css/bootstrap-theme.min.css" rel="stylesheet" />--%>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/jquery.maxlength.css">
    <%--<link type="text/css" href="../css/dataTables.bootstrap.css" rel="stylesheet" />--%>
    <%--<link type="text/css" href="../css/responsive.dataTables.css" rel="stylesheet" />--%>
    <%--<link type="text/css" href="../css/responsive.bootstrap.css" rel="stylesheet" />--%>
    <%--<link type="text/css" href="../css/responsive.bootstrap.min.css" rel="stylesheet" />--%>
    <%--<link type="text/css" href="../css/fixedHeader.dataTables.css" />
    <link type="text/css" href="../css/fixedHeader.bootstrap.css" />--%>

    <%-- CSS Stylesheets     --%>

    <script type="text/javascript">
        // Code

        $(document).ready(function () {
            //function
            SetProgressPosition();

            $("#DescripcionAnalisisCasos").maxlength({ max: 200 });
            $("#DescripcionConsulta").maxlength({ max: 200 });

            validation();
            validationConsulta();

        });

        function mostrarGridConsultas() {
            $("#gridConsultaAtendidos").fadeIn("slow");
        }

        function marcarConsultas() {
            $("#consulta a").click();
        }

        function marcarIngresos() {
            $("#ingreso a").click();
        }

        function pageLoad(sender, args) {
            $(document).ready(function () {
                //new $.fn.dataTable.Api("#gridConsultaAtendidos").destroy();
                //new $.fn.dataTable.Api("#GridAtendidosMensual").destroy();
                if ($("#GridAtendidosMensual").length > 0) {
                    if ($("#GridAtendidosMensual tr").length > 1) {
                        if (new $.fn.dataTable.Api("#GridAtendidosMensual").init() == null) {
                            generateDataTable($("#GridAtendidosMensual"));
                        }
                    }
                }

                if ($("#gridConsultaAtendidos").length > 0) {
                    if ($("#gridConsultaAtendidos tr").length > 1) {
                        if (new $.fn.dataTable.Api("#gridConsultaAtendidos").init() == null) {
                            generateDataTable($("#gridConsultaAtendidos"));
                        }
                    }
                }
            });

            //new $.fn.dataTable.Api("#gridConsultaAtendidos").destroy();
            //new $.fn.dataTable.Api("#GridAtendidosMensual").destroy();
            //Pregunta si existe este grid
            //if ($("#gridConsultaAtendidos").length > 0) {
            //    //Pregunta si el grid contiene más de un elemento, esto por que si esta vacío entrega un mensaje de error
            //    //el cual cuenta como una fila de la grilla
            //    if ($("#gridConsultaAtendidos tr").length > 1) {
            //        //Evalua si existe una tabla que posea configuraciones de DataTable
            //        if (new $.fn.dataTable.Api("#gridConsultaAtendidos").init() == null) {
            //            //Generamos Jquery Datatable al selector
            //            $("#gridConsultaAtendidos").DataTable({
            //                ordering: false,
            //                paging: false,
            //                searching: false,
            //                scrollY: 400,
            //                sorting: false,
            //            });
            //        }
            //    }
            //}

            //Pregunta si existe este grid
            //if ($("#GridAtendidosMensual").length > 0) {
            //    //Pregunta si existe más de un registro en el grid
            //    if ($("#GridAtendidosMensual tr").length > 1) {
            //        //Evalua si existe una tabla que posea configuraciones de DataTable
            //        if (new $.fn.dataTable.Api("#GridAtendidosMensual").init() == null) {
            //            //Generamos Jquery Datatable al selector
            //            $("#GridAtendidosMensual").DataTable({
            //                ordering: false,
            //                paging: false,
            //                searching: true,
            //                scrollY: 400,
            //                sorting: false,
            //            });
            //            $(".dataTables_scrollHead").css("height", "50px");
            //            $("#GridAtendidosMensual_filter").removeAttr("class");
            //        }
            //    }
            //}

            $(function () { 
                $('#Tabs a').click(function (e) {
                    e.preventDefault()
                })
            });
        }

        function validation() {
            var validation;

            validation = ($("#TxtFechaReunion").val() == "" || $("#DescripcionAnalisisCasos").val() == "" || $("#DDProyectos").val() == "0" || $("#DDInstituciones").val() == "0")

            if (validation == true) {
                $("#btnGuardar").attr("disabled", true)

            } else {
                $("#btnGuardar").attr("disabled", false)
            }
        }

        function CheckOne(obj) {
            var grid = obj.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }

        function validationConsulta() {
            var validationConsulta;

            validationConsulta = ($("#txtFechaConsulta").val() == "" || $("DDInstitucionConsulta").val() == "0" || $("#DDProyectoConsulta").val() == "0");

            if (validationConsulta == true) {
                $("#btnModificar").attr("disabled", true);
            } else {
                $("#btnModificar").attr("disabled", false);
            }
        }



        function ocultarAlertaSuccess() {
            $("#AlertaSuccess").delay(4000).fadeOut('slow', function () {
                $("#AlertaSuccess").css('display', 'none');
            });
        }

        function mostrarAlertaSuccess() {
            $("#AlertaSuccess").fadeIn('slow', function () {
                $("#lblAlertaSuccess").fadeIn('fast');
                $("#AlertasSuccess").css('display', '');
            });
        }

        function mostrarBotonExcel() {
            $("#btnExcel").fadeIn('slow');
        }

        function mostrarBotonModificar() {
            $("#btnModificar").fadeIn('slow');
        }

        //function ocultarBotonModificar() {
        //    $("#btnModificar").fadeOut('slow');
        //}

        //function mostrarGridAtendidosMensual() {
        //    $('#GridAtendidosMensual').fadeIn('slow', function () {
        //        $("#tituloGrid").fadeIn('fast');
        //    });
        //    table = $("#GridAtendidosMensual").DataTable({
        //        paging: false,
        //        ordering: false,
        //        scrollY: 500,
        //        scrollCollapse: true,
        //        fixedHeader: true,
        //        searching: false
        //    });
        //    $("#contenedorTabla table").first().css("opacity", "1");

        //}
        function mostrarGridConsultaAtendidosMensual() {
            $("#gridConsultaAtendidos").fadeIn('slow');
            $("#lblTituloGridConsulta").fadeIn('slow');
            //table = $("#gridConsultaAtendidos").DataTable({
            //    paging: false,
            //    ordering: false,
            //    scrollY: 500,
            //    scrollCollapse: true,
            //    searching: false,
            //});
            //$("#contenedorTablaConsulta table").first().css("opacity", "1");

        }

        //function destroyGridConsultaAtendidosMensual() {
        //    var table = $("#gridConsultaAtendidos").DataTable();
        //    table.destroy();
        //}

        //function destroyGridAtendidosMensual() {
        //    var table = $("#gridAtendidosMensual").dataTable();
        //    table.destroy();
        //}

        ////Para recargar metodos al hacer autopostback
        function LoadScript() {
            $(document).ready(function () {
                SetProgressPosition();
                $("#DescripcionAnalisisCasos").maxlength({ max: 200 });
                $("#DescripcionConsulta").maxlength({ max: 200 });
                validation();
            });

            function mostrarGridConsultas() {
                $("#gridConsultaAtendidos").css("display", "");
            }

            function validation() {
                var validation;

                validation = ($("#TxtFechaReunion").val() == "" || $("#DescripcionAnalisisCasos").val() == "" || $("#DDProyectos").val() == "0" || $("#DDInstituciones").val() == "0");

                if (validation == true) {
                    $("#btnGuardar").attr("disabled", true);

                } else {
                    $("#btnGuardar").attr("disabled", false);
                }
            }

            function CheckOne(obj) {
                var grid = obj.parentNode.parentNode;
                var inputs = grid.getElementsByTagName("input");
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type == "checkbox") {
                        if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                            inputs[i].checked = false;
                        }
                    }
                }
            }

            function mostrarAlertaSuccess() {
                $("#AlertaSuccess").fadeIn('slow', function () {
                    $("#lblAlertaSuccess").fadeIn('fast');
                    $("#AlertasSuccess").css('display', '');
                });
            }

            function ocultarAlertaSuccess() {
                $("#AlertaSuccess").delay(4000).fadeOut('slow', function () {
                    $("#AlertaSuccess").css('display', 'none');
                });
            }


            function marcarConsultas() {
                $("#consulta a").click();
            }

            function marcarIngresos() {
                $("#ingreso a").click();
            }

        }


        //function LoadScript() {
        //    $(document).ready(function () {
        //        //function
        //        SetProgressPosition();

        //        $("#DescripcionAnalisisCasos").maxlength({ max: 200 });
        //        $("#DescripcionConsulta").maxlength({ max: 200 });

        //        validation();
        //        validationConsulta();
        //        //mostrarGridAtendidosMensual();
        //        //mostrarGridConsultaAtendidosMensual();

        //        //if ($.fn.dataTable.isDataTable('#GridAtendidosMensual')) {
        //        //    table = $('#GridAtendidosMensual').DataTable();
        //        //} else {
        //        //    table = $("#GridAtendidosMensual").DataTable({
        //        //        paging: false,
        //        //        ordering: false,
        //        //        scrollY: 500,
        //        //        scrollCollapse: true,
        //        //        fixedHeader: true,
        //        //        searching: false
        //        //    });
        //        //    $("#contenedorTabla table").first().css("opacity", "1");
        //        //}

        //        //if ($.fn.dataTable.isDataTable('#gridConsultaAtendidos')) {
        //        //    table = $('#gridConsultaAtendidos').DataTable();
        //        //} else {
        //        //    table = $("#gridConsultaAtendidos").DataTable({
        //        //        paging: false,
        //        //        ordering: false,
        //        //        scrollY: 500,
        //        //        scrollCollapse: true,
        //        //        fixedHeader: true,
        //        //        searching: false
        //        //    });
        //        //    $("#contenedorTablaConsulta table").first().css("opacity", "1");
        //        //}


        //    });


        //    function mostrarGridAtendidosMensual() {
        //        $('#GridAtendidosMensual').fadeIn('slow', function () {
        //            $("#tituloGrid").fadeIn('fast');
        //        });
        //    }

        function mostrarGridConsultaAtendidosMensual() {
            //var table = $("#gridConsultaAtendidos").DataTable();
            //paging: false,
            //ordering: false,
            //scrollY: 300
            //scrollCollapse: true,
            //fixedHeader: true,
            //searching: false,
            //});
            $("#gridConsultaAtendidos").fadeIn('slow');
            $("#lblTituloGridConsulta").fadeIn('slow');
        }


        //    function validation() {
        //        var validation;

        //        validation = ($("#TxtFechaReunion").val() == "" || $("#DescripcionAnalisisCasos").val() == "" || $("#DDProyectos").val() == "0" || $("#DDInstituciones").val() == "0");

        //        if (validation == true) {
        //            $("#btnGuardar").attr("disabled", true);

        //        } else {
        //            $("#btnGuardar").attr("disabled", false);
        //        }
        //    }

        //    function validationConsulta() {
        //        var validationConsulta;

        //        validationConsulta = ($("#txtFechaConsulta").val() == "" || $("DDInstitucionConsulta").val() == "0" || $("#DDProyectoConsulta").val() == "0");

        //        if (validationConsulta == true) {
        //            $("#btnModificar").attr("disabled", true);
        //        } else {
        //            $("#btnModificar").attr("disabled", false);
        //        }
        //    }

        //    function CheckOne(obj) {
        //        var grid = obj.parentNode.parentNode;
        //        var inputs = grid.getElementsByTagName("input");
        //        for (var i = 0; i < inputs.length; i++) {
        //            if (inputs[i].type == "checkbox") {
        //                if (obj.checked && inputs[i] != obj && inputs[i].checked) {
        //                    inputs[i].checked = false;
        //                }
        //            }
        //        }
        //    }

        //    function ocultarAlertaSuccess() {
        //        $("#AlertaSuccess").delay(4000).fadeOut('slow', function () {
        //            $("#AlertaSuccess").css('display', 'none');
        //        });
        //    }
        //}
        //function LoadScript() {
        //}


        //function ultimoTab() {
        //    $(function () {
        //        var x = $("#Tabs .active a").data("id");
        //        debugger;
        //        if (x = 0) {
        //            console.log(x);
        //        }
        //        else if (x = 1) {
        //            console.log(x);
        //        }
        //    });
        //}

        

    </script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <style>
        /* Code */
        .ocultar-columna {
            display: none;
        }

        .alinearTitulos {
            white-space: pre-line;
            text-align: center;
        }

        .comentario {
        }
    </style>

    <form runat="server" id="AnalisisCasos">
        <%-- Referencia a Menu Colgante --%>
        <header>
            <uc2:menu_colgante runat="server" ID="menu_colgante" />
        </header>

        <%-- Carga de ScriptManager --%>
        <asp:ScriptManager runat="server" ID="SM_AnalisisCasos" ScriptMode="Release" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>




        <div class="container">
            <%-- Alerta Success --%>

            <nav class="breadcrumb">
                <li>Inicio</li>
                <li class="active">Registro de Analisis de Casos</li>
            </nav>
            <h3 class="subtitulo-form">Registro de Análisis de Casos</h3>
            <hr />

            <article class="alert alert-success text-center" role="alert" id="AlertaSuccess" style="display: none;">
                <span class="glyphicon glyphicon-ok"></span>
                <asp:Label ID="lblAlertaSuccess" Text="Datos Actualizados">Datos Actualizados</asp:Label>
            </article>

            <%-- Alerta Warning --%>
            <%--<article class="alert alert-warning text-center" role="alert" id="AlertaWarning" runat="server" style="margin-top: 10px; display: none">
                <span class="glyphicon glyphicon-warning-sign"></span>
                <asp:Label ID="lblAlertaWarning" runat="server" Text="Asistencia Confirmada"></asp:Label>
            </article>--%>

            <!-- Nav tabs -->

            <asp:HiddenField runat="server" ID="ultimoTab" Value="" />

            <ul id="Tabs" class="nav nav-tabs nav-justified" role="tablist">
                <li runat="server" onclick="return $('#ultimoTab').val('0');" role="presentation" id="ingreso" class="active"><a href="#Ingreso" runat="server" aria-controls="Ingreso" role="tab" data-toggle="tab" data-id="0">Ingreso</a></li>
                <li runat="server" onclick="return $('#ultimoTab').val('1');" role="presentation" id="consulta"><a href="#Consulta" aria-controls="Consulta" role="tab" data-toggle="tab" data-id="1">Consulta</a></li>
            </ul>

            <!-- Tab panes -->
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="Ingreso">
                    <asp:UpdatePanel runat="server" ID="updateAnalisisCasos" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExcel" />
                            <asp:PostBackTrigger ControlID="btnExportar" />
                        </Triggers>
                        <ContentTemplate>
                            <script type="text/javascript">
                                Sys.Application.add_load(LoadScript);
                            </script>

                            <%-- En caso de querer actualizar o cargar metodos javascript al actualizar el updatepanel --%>

                            <%--<script type="text/javascript">
                                    Sys.Application.add_load(LoadScript);
                                </script>--%>

                            <%-- Ajax Popup Proyecto --%>

                            <ajax:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe4aProyecto" runat="server"
                                TargetControlID="imb_lupaproyecto"
                                PopupControlID="modal_bsc_proyecto"
                                DropShadow="true"
                                BackgroundCssClass="modalBackground"
                                CancelControlID="LinkButton3">
                            </ajax:ModalPopupExtender>

                            <%-- Ajax Popup instituciones --%>

                            <ajax:ModalPopupExtender ID="ModalPopupExtender2" BehaviorID="mpe4aInstitucion" runat="server"
                                TargetControlID="imb_lupa_institucion"
                                PopupControlID="modal_bsc_institucion"
                                DropShadow="true"
                                BackgroundCssClass="modalBackground"
                                CancelControlID="LinkButton4">
                            </ajax:ModalPopupExtender>

                            <%-- Div Popup Proyecto --%>

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

                            <%-- Div Popup Proyecto --%>

                            <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="LinkButton4" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">INSTITUCIÓN</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>

                            <div class="theme-showcase" role="main">
                                <section class="well">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <table class="table">
                                                <blockquote>
                                                    <p>Para poder ingresar datos, debe llenar todos los campos que se muestran en el formulario</p>
                                                </blockquote>
                                                <%--<blockquote><footer><cite title="Source Title">Para poder ingresar datos, debe llenar todos los campos que se muestran en el formulario</cite></footer></blockquote>--%>
                                                <tr>
                                                    <th class="titulo-tabla col-sm-1">Institución*</th>
                                                    <td class="col-sm-4">
                                                        <div class="input-group">
                                                            <asp:DropDownList runat="server" ID="DDInstituciones" OnSelectedIndexChanged="DDInstituciones_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm" onchange="validation();"></asp:DropDownList>

                                                            <asp:LinkButton runat="server" ID="imb_lupa_institucion" CausesValidation="false" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion', '../mod_instituciones/analisiscasos.aspx','mpe4aInstitucion')">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <th class="titulo-tabla col-sm-1" id="thproyecto">Proyecto*</th>
                                                <td class="col-sm-4" id="tdproyecto">
                                                    <div class="input-group">
                                                        <asp:DropDownList runat="server" ID="DDProyectos" OnSelectedIndexChanged="DDProyectos_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm" onchange="validation();">
                                                            <%--onchange="validation();"--%>
                                                            <%--<asp:ListItem Value="-2">Seleccionar</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                        <asp:LinkButton runat="server" ID="imb_lupaproyecto" CausesValidation="false" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca%20Proyectos', '../mod_instituciones/analisiscasos.aspx','mpe4aProyecto')">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                </tr>
                                    <tr>
                                        <%--<th class="titulo-tabla col-md-1">Tipo de Evento*</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList runat="server" ID="DDTiposEventos" CausesValidation="false" CssClass="form-control input-sm"></asp:DropDownList>
                                        </td>--%>
                                        <th class="titulo-tabla col-sm-1">Fecha Reunión*</th>
                                        <td class="col-md-4">
                                            <asp:TextBox runat="server" ID="TxtFechaReunion" ValidationGroup="v1" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa" MaxLength="10" onchange="validation();"></asp:TextBox>
                                            <%--onchange="validation();"--%>
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CEFechaEvento" runat="server" Format="dd-MM-yyyy" TargetControlID="TxtFechaReunion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CEFechaEvento_TxtFechaReunion" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TxtFechaReunion" ValidChars="1234567890-/" />
                                            <asp:RangeValidator ID="RVFechaEvento" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ControlToValidate="TxtFechaReunion" Type="Date" MaximumValue="31-12-2020" MinimumValue="1000-01-01" ValidationGroup="grupo1" />

                                            <asp:Label ID="lblFechaEvento" runat="server" CssClass="help-block" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                                <tr>
                                                    <th class="titulo-tabla col-sm-1">Descripción</th>
                                                    <td>
                                                        <asp:TextBox ID="DescripcionAnalisisCasos" ValidationGroup="v1" runat="server" CssClass="form-control input-md" placeholder="Ingrese una descripción" MaxLength="200" TextMode="MultiLine" onkeydown="validation();" onblur="validation();" onchange="validation();"></asp:TextBox>
                                                        <%--onkeydown="validation();" onblur="validation();" onchange="validation();"--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>


                                    <table class="table table-borderless tabla-tabs">
                                        <tr>
                                            <td>
                                                <div class="botonera pull-right">
                                                    <asp:LinkButton ID="btnExportar" runat="server" OnClick="btnExportar_Click" CssClass="btn btn-success btn-sm fixed-width-button" CausesValidation="true">
                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Exportar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" CssClass="btn btn-danger btn-sm fixed-width-button" CausesValidation="true">
                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnLimpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btnLimpiar_Click">
                                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>

                                    <br />
                                    <h4 class="subtitulo-form" id="complementoLblmesAtendido" style="display: none;">Atendidos a última reunión (<asp:Label runat="server" ID="lblMesAtendido" Visible="false"></asp:Label>)</h4>

                                    <h4 class="subtitulo-form" id="tituloGrid" style="display: none;">Atendidos año 2016 a la Fecha</h4>
                                    <br />
                                    <asp:GridView runat="server" ID="GridAtendidosMensual" data-name="GridAtendidosMensual" EmptyDataText="No hay registros disponibles" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField HeaderText="ICodIE" DataField="ICODIE" HeaderStyle-CssClass="alinearTitulos text-center" />
                                            <asp:BoundField HeaderText="FechaIngreso" DataField="FechaIngreso" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="FechaEgreso" DataField="FechaEgreso" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="CodProyecto" DataField="CodProyecto" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="Proyecto" DataField="Proyecto" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="CodNino" DataField="CodNino" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="Rut" DataField="Rut" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="Sexo" DataField="Sexo" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="Apellido Paterno" DataField="Apellido_Paterno" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="Apellido Materno" DataField="Apellido_Materno" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="Nombres" DataField="Nombres" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="FechaNacimiento" DataField="FechaNacimiento" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="EdadAno" DataField="EdadAno" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="codEventosAnalisisCaso" DataField="codEventosAnalisisCaso" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                            <asp:TemplateField HeaderText="REUNIFICACIÓN FAMILIAR" HeaderStyle-CssClass="alinearTitulos text-center" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ReunificacionFamiliar" OnCheckedChanged="ReunificacionFamiliar_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DERIVACIÓN A FAE PRO – FAE AA.DD." HeaderStyle-CssClass="alinearTitulos text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="DerivacionFAEPROaFAEAADD" OnCheckedChanged="DerivacionFAEPROaFAEAADD_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DERIVACIÓN A UNIDAD DE ADOPCIÓN" HeaderStyle-CssClass="alinearTitulos text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="DerovacionUnidadAdopcion" OnCheckedChanged="DerovacionUnidadAdopcion_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SEGUIMIENTO Y CONTINUIDAD DEL PROCESO DE INTERVENCIÓN" HeaderStyle-CssClass="alinearTitulos text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SeMantieneAnalisisCaso" OnCheckedChanged="SeMantieneAnalisisCaso_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="fechaReunion" DataField="FechaReunion" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                            <%--<asp:BoundField HeaderText="icodanalisiscaso" DataField="icodanalisiscaso" />--%>
                                        </Columns>
                                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                        <RowStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    </asp:GridView>

                                    <%--<div class="botonera pull-right">
                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnMarcarTodo" Text="Marcar Todos" runat="server" Visible="true">
                        <span class="glyphicon glyphicon-check"></span>&nbsp;
                        </asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnDesmarcarTodo" Text="Desmarcar todos" runat="server" Visible="true">
                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;
                        </asp:LinkButton>
                        <asp:LinkButton ID="btn_Excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" Text="Exportar" Visible="true">
                        <span class="glyphicon glyphicon-save-file"></span>&nbsp;
                        </asp:LinkButton>
                    </div>--%>
                                </section>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div role="tabpanel" class="tab-pane" id="Consulta">
                    <asp:UpdatePanel runat="server" ID="UpdateConsulta" UpdateMode="Conditional">
                        <ContentTemplate>
                            <%--<script type="text/javascript">
                                Sys.Application.add_load(LoadScript);
                            </script>--%>

                            <%-- Ajax Popup Proyecto --%>

                            <ajax:ModalPopupExtender ID="ModalPopupExtender3" BehaviorID="mpeProyectoConsultas" runat="server"
                                TargetControlID="mostrarProyectosConsultasPopup"
                                PopupControlID="modal_bsc_proyecto2"
                                DropShadow="true"
                                BackgroundCssClass="modalBackground"
                                CancelControlID="LinkButton3">
                            </ajax:ModalPopupExtender>

                            <%-- Ajax Popup instituciones --%>

                            <ajax:ModalPopupExtender ID="ModalPopupExtender4" BehaviorID="mpeInstitucionConsultas" runat="server"
                                TargetControlID="mostrarInstitucionesConsultaPopup"
                                PopupControlID="modal_bsc_institucion2"
                                DropShadow="true"
                                BackgroundCssClass="modalBackground"
                                CancelControlID="LinkButton4">
                            </ajax:ModalPopupExtender>

                            <%-- Div Popup Proyecto --%>

                            <div class="popupConfirmation" id="modal_bsc_proyecto2" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="cerrarModalBscProyecto2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">PROYECTO</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_proyecto2" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>

                            <%-- Div Popup Proyecto --%>

                            <div class="popupConfirmation" id="modal_bsc_institucion2" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="cerrarModalBscInstitucion2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">INSTITUCIÓN</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_institucion2" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>


                            <div class="theme-showcase" role="main">
                                <div class="well">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <table class="table">
                                                <blockquote>
                                                    <p>Ingrese Institución, Proyecto y Fecha para obtener los datos de la reunión y poder modificar eventos de NNA</p>
                                                </blockquote>
                                                <tr>
                                                    <th class="titulo-tabla col-sm-1">Institución*</th>
                                                    <td class="col-sm-4">
                                                        <div class="input-group">
                                                            <asp:DropDownList runat="server" ID="DDInstitucionConsulta" OnSelectedIndexChanged="DDInstitucionConsulta_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm" onchange="validationConsulta();"></asp:DropDownList>
                                                            <asp:LinkButton runat="server" ID="mostrarInstitucionesConsultaPopup" OnClick="mostrarInstitucionesConsultaPopup_Click" CausesValidation="false" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return mostrarModalInstitucion2('Plan%20de%20Intervencion', '../mod_instituciones/analisiscasos.aspx','mpeInstitucionConsultas')">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <th class="titulo-tabla col-sm-1" id="th1">Proyecto*</th>
                                                <td class="col-sm-4" id="td1">
                                                    <div class="input-group">
                                                        <asp:DropDownList runat="server" ID="DDProyectoConsulta" OnSelectedIndexChanged="DDProyectoConsulta_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-sm" onchange="validationConsulta();">
                                                            <%--<asp:ListItem Value="-2">Seleccionar</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                        <asp:LinkButton runat="server" ID="mostrarProyectosConsultasPopup" OnClick="mostrarProyectosConsultasPopup_Click" CausesValidation="false" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return mostrarModalProyecto2('Busca%20Proyectos', '../mod_instituciones/analisiscasos.aspx','mpeProyectoConsultas')">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                </tr>
                                    <tr>
                                        <%--<th class="titulo-tabla col-md-1">Tipo de Evento*</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList runat="server" ID="DDTiposEventos" CausesValidation="false" CssClass="form-control input-sm"></asp:DropDownList>
                                        </td>--%>
                                        <th class="titulo-tabla col-sm-1">Fecha Consulta*</th>
                                        <td class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtFechaConsulta" ValidationGroup="v1" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa" MaxLength="10" AutoPostBack="true" OnTextChanged="txtFechaConsulta_TextChanged" onchange="validationConsulta();"></asp:TextBox>
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaConsulta" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CEFechaEvento_TxtFechaReunion" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFechaConsulta" ValidChars="1234567890-/" />
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ControlToValidate="TxtFechaReunion" Type="Date" MaximumValue="31-12-2020" MinimumValue="1000-01-01" ValidationGroup="grupo1" />

                                            <asp:Label ID="Label1" runat="server" CssClass="help-block" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                                <tr>
                                                    <th class="titulo-tabla col-sm-1">Descripción</th>
                                                    <td>
                                                        <asp:TextBox ID="DescripcionConsulta" ValidationGroup="v1" runat="server" CssClass="form-control input-md" placeholder="Ingrese una descripción" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>

                                    <table class="table table-borderless tabla-tabs">
                                        <tr>
                                            <td>
                                                <div class="botonera pull-right">
                                                    <%--<asp:LinkButton ID="btnExportar" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btnExcel_Click">
                                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Exportar
                                                    </asp:LinkButton>--%>
                                                    <asp:LinkButton ID="btnExcel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btnExcel_Click1" Style="display: none;">
                                                        <span class="glyphicon glyphicon-floppy-disk"></span>&nbsp;Exportar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnModificar" runat="server" OnClick="btnModificar_Click" CssClass="btn btn-danger btn-sm fixed-width-button">
                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnLimpiarConsulta" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btnLimpiarConsulta_Click">
                                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>

                                    <h4 class="subtitulo-form">
                                        <asp:Label runat="server" ID="lblTituloGridConsulta" Style="display: none;"></asp:Label></h4>
                                    <div class="table-condensed" id="contenedorTablaConsulta">
                                        <asp:GridView runat="server" ID="gridConsultaAtendidos" data-name="gridConsultaAtendidos" EmptyDataText="No hay registros disponibles" CssClass="table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                <asp:BoundField HeaderText="ICodIE" DataField="ICODIE" HeaderStyle-CssClass="alinearTitulos text-center" />
                                                <asp:BoundField HeaderText="FechaIngreso" DataField="FechaIngreso" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="FechaEgreso" DataField="FechaEgreso" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodProyecto" DataField="CodProyecto" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="Proyecto" DataField="Proyecto" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodNino" DataField="CodNino" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="Rut" DataField="Rut" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="Sexo" DataField="Sexo" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="Apellido Paterno" DataField="Apellido_Paterno" HeaderStyle-CssClass="text-center" />
                                                <asp:BoundField HeaderText="Apellido Materno" DataField="Apellido_Materno" HeaderStyle-CssClass="text-center" />
                                                <asp:BoundField HeaderText="Nombres" DataField="Nombres" HeaderStyle-CssClass="text-center" />
                                                <asp:BoundField HeaderText="FechaNacimiento" DataField="FechaNacimiento" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="EdadAno" DataField="EdadAno" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="codEventosAnalisisCaso" DataField="codEventosAnalisisCaso" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:TemplateField HeaderText="REUNIFICACIÓN FAMILIAR" HeaderStyle-CssClass="alinearTitulos text-center" ItemStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ReunificacionFamiliar" OnCheckedChanged="ReunificacionFamiliar_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="DERIVACIÓN A FAE PRO – FAE AA.DD." HeaderStyle-CssClass="alinearTitulos text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="DerivacionFAEPROaFAEAADD" OnCheckedChanged="DerivacionFAEPROaFAEAADD_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="DERIVACIÓN A UNIDAD DE ADOPCIÓN" HeaderStyle-CssClass="alinearTitulos text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="DerovacionUnidadAdopcion" OnCheckedChanged="DerovacionUnidadAdopcion_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SEGUIMIENTO Y CONTINUIDAD DEL PROCESO DE INTERVENCIÓN" HeaderStyle-CssClass="alinearTitulos text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="SeMantieneAnalisisCaso" OnCheckedChanged="SeMantieneAnalisisCaso_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="QUITAR EVENTO" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="quitaEvento" OnCheckedChanged="quitaEvento_CheckedChanged" runat="server" onclick="CheckOne(this)" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="fechaReunion" DataField="FechaReunion" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="ICodAnalisisCaso_Atendido   " DataField="ICodAnalisisCaso" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <%--<asp:BoundField HeaderText="icodanalisiscaso" DataField="icodanalisiscaso" />--%>
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <RowStyle CssClass="text-center" />
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>


            <asp:UpdateProgress ID="updateProgressAnalisisCasos" runat="server" Visible="true">
                <ProgressTemplate>
                    <div id="divProgress" class="ajax_cargando">
                        <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                        Cargando...       
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

        </div>

    </form>
</body>
</html>
