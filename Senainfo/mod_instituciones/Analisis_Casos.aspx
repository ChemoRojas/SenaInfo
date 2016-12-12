<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Analisis_Casos.aspx.cs" Inherits="mod_instituciones_Analisis_Casos" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc2" TagName="menu_colgante" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro de Analisis de Casos :: Senainfo :: Servicio Nacional de Menores</title>

    <link rel="icon" href="../images/favicon.ico">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />

    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap3.3.4.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.plugin.js"></script>
    <script src="../js/jquery.maxlength.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/dataTables.bootstrap.js"></script>

    <script type="text/javascript">

        $(function () {
            SetProgressPosition();
            validation();
        });

        function limpiarDatos() {
            $("#ddlInstitucion").val(0);
            $("#ddlProyecto").val(0);
            $("#txtFechaReunion").val("");
            $("#txtFechaConsulta").val("");
            $("#txtDescripcionIngreso").val("");
            $("#txtDescripcionConsulta").val("");
            ocultarIngreso();
            ocultarConsulta();
            ocultarExportar();
        }

        function ocultarIngreso() {
            $("#divFechaReunion").css("display", "none");
            $("#divDescripcionIngreso").fadeOut("fast");
            $("#botones").fadeOut("fast");
            $("#gridAtendidos").fadeOut("fast");
        }

        function mostrarDatosIngreso() {
            $("#btnModificar").css("display", "none");
            $("#btnExportar").css("display", "none");
            $("#divFechaReunion").fadeIn("fast");
            $("#divDescripcionIngreso").fadeIn("fast");
            $("#botones").fadeIn("fast");
            $("#gridAtendidos").fadeIn("fast");
            gridAtendidostoDatatable();
        }

        function ocultarConsulta() {
            $("#divFechaReunionConsulta").css("display", "none");
            $("#divDescripcíonConsulta").css("display", "None");
            $("#botones").fadeOut("fast");
            $("#gridConsultaAtendidos").fadeOut("fast");
        }

        function mostrarDatosConsulta() {
            $("#btnGuardar").css("display", "none");
            $("#btnExportar").css("display", "none");
            $("#divFechaReunionConsulta").fadeIn("fast");
            $("#divDescripcíonConsulta").fadeIn("fast");
            $("#botones").fadeIn("fast");
            $("#gridConsultaAtendidos").fadeIn("fast");
            gridConsultaAtendidostoDatatable();
        }

        function ocultarExportar() {
            $("#botones").fadeOut("fast");
            $("#btnExportar").fadeOut("fast");
        }

        function mostrarExportar() {
            $("#botones").fadeIn("fast");
            $("#btnExportar").fadeIn("fast");
            $("#btnGuardar").css("display", "none");
            $("#btnModificar").css("display", "none");
        }

        function gridAtendidostoDatatable() {
            if ($("#gridAtendidos").length > 0) {
                if ($("#gridAtendidos tr").length > 1) {
                    if (new $.fn.dataTable.Api("#gridAtendidos").init() == null) {
                        generateDataTable($("#gridAtendidos"));
                    }
                }
            }
        }

        function gridConsultaAtendidostoDatatable() {
            if ($("#gridConsultaAtendidos").length > 0) {
                if ($("#gridConsultaAtendidos tr").length > 1) {
                    if (new $.fn.dataTable.Api("#gridConsultaAtendidos").init() == null) {
                        generateDataTable($("#gridConsultaAtendidos"));
                    }
                }
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

        function validation() {
            var validaIngreso;

            validaIngreso = ($("#ddlinstitucion").val() == "0" || $("#ddlProyecto").val() == "0" || $("#txtFechaReunion").val() == "" || $("#txtDescripcionIngreso").val() == "");

            if (validaIngreso == true) {
                $("#btnGuardar").attr("disabled", true);
            } else {
                $("#btnGuardar").attr("disabled", false);
            }

            validaConsulta = ($("#ddlinstitucion").val() == "0" || $("#ddlProyecto").val() == "0" || $("#txtFechaConsulta").val() == "" || $("#txtDescripcionConsulta").val() == "");

            if (validaConsulta == true) {
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

        function LoadScript() {
            validation();
        }
    </script>


</head>
<body role="document" onmousemove="SetProgressPosition(event)">

    <style type="text/css">
        .ocultar-columna {
            display: none;
        }

        .titulos-largos {
            white-space: pre-line;
        }
    </style>

    <form id="AnalisisCasos" runat="server" class="form-horizontal">
        <header id="Header1" runat="server">
            <uc2:menu_colgante runat="server" ID="menu_colgante" />
        </header>

        <div class="container">

            <!-- Breadcrumb -->
            <nav class="breadcrumb">
                <li>Inicio</li>
                <li class="active">Registro de Análisis de Casos</li>
            </nav>

            <article class="alert alert-success text-center" role="alert" id="AlertaSuccess" style="display: none;">
                <span class="glyphicon glyphicon-ok"></span>
                <asp:Label ID="lblAlertaSuccess" Text="Datos Actualizados">Datos Actualizados</asp:Label>
            </article>


            <h3 class="subtitulo-form">Registro de Analisis de Casos</h3>
            <hr />


            <div class="theme-showcase" role="main">
                <section class="well">

                    <asp:UpdatePanel runat="server" ID="updateAnalisisCasos">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExportar" />
                        </Triggers>
                        <ContentTemplate>
                            <script type="text/javascript">
                                Sys.Application.add_load(LoadScript);
                            </script>

                            <asp:ScriptManager runat="server" ID="SM_AnalisisCasos" ScriptMode="Release" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>



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


                            <!-- Mensajes de Blockquote -->
                            <blockquote class="text-center">
                                <p>
                                    Para poder ingresar datos, debe llenar todos los campos que se muestran en el formulario
                                <br />
                                    Ahora puede realizar consultas sobre Reuniones anteriores y modificar eventos de NNA <span class="badge">Nuevo</span>
                                </p>
                            </blockquote>

                            <!-- Institución -->
                            <div class="form-group">
                                <label for="ddlInstitucion" class="col-sm-2 control-label text-left">Institución</label>
                                <div class="col-sm-10 input-group">
                                    <asp:DropDownList runat="server" ID="ddlInstitucion" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" onchange="validation();">
                                        <asp:ListItem Value="0" Text="Seleccionar"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton runat="server" ID="imb_lupa_institucion" CausesValidation="false" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion', '../mod_instituciones/analisis_casos.aspx','mpe4aInstitucion')">
                                        <span class="glyphicon glyphicon-question-sign"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <!-- Proyecto -->
                            <div class="form-group">
                                <label for="ddlProyecto" class="col-sm-2 control-label text-left">Proyecto</label>
                                <div class="col-sm-10 input-group">
                                    <asp:DropDownList runat="server" ID="ddlProyecto" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" onchange="validation();">
                                        <asp:ListItem Value="0" Text="Seleccionar"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton runat="server" ID="imb_lupaproyecto" CausesValidation="false" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca%20Proyectos', '../mod_instituciones/analisis_casos.aspx','mpe4aProyecto')">
                                        <span class="glyphicon glyphicon-question-sign"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <!-- Acción -->
                            <div class="form-group">
                                <label for="rdoAccion" class="col-md-2 control-label text-left">Acción</label>
                                <div class="col-md-10 text-center radio">
                                    <asp:RadioButton runat="server" Text="&nbsp;Ingreso" Enabled="false" CssClass="col-md-4" GroupName="AccionRadio" ID="Ingreso" OnCheckedChanged="Ingreso_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton runat="server" Text="&nbsp;Consulta" Enabled="false" CssClass="col-md-4" GroupName="AccionRadio" ID="Consulta" OnCheckedChanged="Consulta_CheckedChanged" AutoPostBack="true" />
                                    <asp:RadioButton runat="server" Text="&nbsp;Reporte" Enabled="false" CssClass="col-md-4" GroupName="AccionRadio" ID="Reporte" OnCheckedChanged="Reporte_CheckedChanged" AutoPostBack="true" />
                                </div>
                            </div>

                            <!-- Fecha Reunión -->
                            <div class="form-group" id="divFechaReunion" style="display: none;">
                                <label for="txtFechaReunion" class="col-sm-2 control-label text-left">Fecha Reunión</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" onkeypress="return false;" ID="txtFechaReunion" CssClass="form-control" placeholder="Fecha de Reunión" onchange="validation();"></asp:TextBox>
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="calendarFechaReunion" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaReunion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CEFechaEvento_TxtFechaReunion" />
                                </div>
                            </div>

                            <!-- Fecha Consulta -->
                            <div class="form-group" id="divFechaReunionConsulta" style="display: none;">
                                <label for="txtFechaConsulta" class="col-sm-2 control-label text-left">Fecha Consulta</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" onkeypress="return false;" ID="txtFechaConsulta" CssClass="form-control" OnTextChanged="txtFechaConsulta_TextChanged" AutoPostBack="true" placeholder="Fecha de Reunion a Consultar"></asp:TextBox>
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="calendarFechaConsulta" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaConsulta" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CEFechaEvento_TxtFechaConsulta" />
                                </div>
                            </div>

                            <!-- Descripcion en Ingreso -->
                            <div class="form-group" id="divDescripcionIngreso" style="display: none;">
                                <label for="txtDescripcionIngreso" class="col-sm-2 control-label text-left">Descripción Reunion</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="txtDescripcionIngreso" TextMode="MultiLine" CssClass="form-control" placeholder="Ingrese descripción de la Reunión" onkeydown="validation();" onblur="validation();" onchange="validation();"></asp:TextBox>

                                </div>
                            </div>

                            <!-- Descripcion en Consulta -->
                            <div class="form-group" id="divDescripcíonConsulta" style="display: none;">
                                <label for="txtDescripcionConsulta" class="col-sm-2 control-label text-left">Descripción Consulta</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="txtDescripcionConsulta" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>


                            <br />

                            <!-- Botones -->
                            <div class="row">
                                <div class="col-md-6 col-md-offset-8" id="botones" style="display: none;">
                                    <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" CausesValidation="true">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Exportar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" CausesValidation="true">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnModificar" runat="server" OnClick="btnModificar_Click" CssClass="btn btn-danger btn-sm fixed-width-button">
                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiar" OnClick="btnLimpiar_Click" runat="server" CssClass="btn btn-info btn-sm fixed-width-button">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                </div>

                                <br />
                                <br />
                                <br />
                                <br />

                                <!-- GirdView Ingreso -->

                                    <%--<div class="table-responsive" id="GridViewContainer">--%>
                                    <asp:GridView runat="server" ID="gridAtendidos" data-name="gridAtendidos" CssClass="table table-bordered table-condensed" AutoGenerateColumns="false" Style="display: none;">
                                        <RowStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="titulo-tabla-centrado" />
                                        <Columns>
                                            <asp:BoundField HeaderText="codEventosAnalisisCaso" DataField="codEventosAnalisisCaso" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" HeaderStyle-CssClass="alinearTitulos text-center" />
                                            <asp:BoundField HeaderText="APELLIDO PATERNO" DataField="Apellido_Paterno" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="APELLIDO MATERNO" DataField="Apellido_Materno" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="NOMBRES" DataField="Nombres" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-nowrap" />
                                            <asp:BoundField HeaderText="FECHA ULTIMA REUNION" DataField="FechaReunion" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}" />
                                            <asp:TemplateField HeaderText="REUNIFICACIÓN FAMILIAR" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ReunificacionFamiliar" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DERIVACIÓN A FAE PRO – FAE AA.DD." HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="DerivacionFAEPROaFAEAADD" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DERIVACIÓN A UNIDAD DE ADOPCIÓN" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="DerovacionUnidadAdopcion" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SEGUIMIENTO Y CONTINUIDAD DEL PROCESO DE INTERVENCIÓN" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SeMantieneAnalisisCaso" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                <%--</div>--%>

                                <!-- GridView Consulta -->
                                <%--<div class="table-responsive">--%>
                                    <asp:GridView runat="server" ID="gridConsultaAtendidos" data-name="gridConsultaAtendidos" AutoGenerateColumns="false" EmptyDataText="No se encuentran Coincidencias" CssClass="table table-bordered table-condensed" Style="display: none;">
                                        <RowStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="titulo-tabla-centrado" />
                                        <Columns>
                                            <asp:BoundField HeaderText="codEventosAnalisisCaso" DataField="codEventosAnalisisCaso" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="ICodAnalisisCaso_Atendido" DataField="ICodAnalisisCaso" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                            <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="APELLIDO PATERNO" DataField="Apellido_Paterno" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="APELLIDO MATERNO" DataField="Apellido_Materno" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField HeaderText="NOMBRES" DataField="Nombres" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-nowrap" />
                                            <asp:BoundField HeaderText="FECHA ULTIMA REUNIÓN" DataField="FechaReunion" DataFormatString="{0:d}" HeaderStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="REUNIFICACIÓN FAMILIAR" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ReunificacionFamiliar" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DERIVACIÓN A FAE PRO  -  FAE AA.DD." HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="DerivacionFAEPROaFAEAADD" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DERIVACIÓN A UNIDAD DE ADOPCIÓN" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="DerovacionUnidadAdopcion" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SEGUIMIENTO Y CONTINUIDAD DEL PROCESO DE INTERVENCIÓN" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="SeMantieneAnalisisCaso" runat="server" onclick="CheckOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="QUITAR EVENTO" HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="quitarEvento" runat="server" onClick="checkOne(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                <%--</div>--%>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="updateProgressAnalisisCasos" runat="server" Visible="true">
                        <ProgressTemplate>
                            <div id="divProgress" class="ajax_cargando">
                                <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                                Cargando...       
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </section>
            </div>
        </div>
    </form>


</body>
</html>
