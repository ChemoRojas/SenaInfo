<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="proyectoadjudicadoenejecucion.aspx.cs" Inherits="Proyectos_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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
    <title>Proyecto Adjudicado / En ejecución :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-ui.js"></script>--%>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe1a").show();
            return false;
        }

        function MostrarModalProyecto() {
            var objIframe = document.getElementById('iframe_bsc_proyecto');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe2a").show();
            return false;
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }

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

        function limpiarForm() {
            window.location = "proyectoadjudicadoenejecucion.aspx"
        }

        //function rangoFechas() {
        //    var fech1 = document.getElementById("txtFecInicio").value;
        //    var aux = fech1.split();
        //    aux = aux.reverse();
        //    var fech1 = aux.join('-');

        //    alert(fech1);
        //    //var fech2 = document.getElementById("txtFecTermino").value;

        //    //if((Date.parse(fech1)) > (Date.parse(fech2))){
        //    //    alert("La \"Fecha Inicio Proyecto\" no puede ser mayor a la \"Fecha Término Proyeto\"");
        //    //}

        //    //if (!$("#txtFecInicio").val() || !$("#txtFecTermino").val()) {
        //    //    var startDate = document.getElementById("txtFecInicio").value;
        //    //    var startDate_parts = startDate.split("-");
        //    //    var inicio = new Date(startDate_parts[1], startDate_parts[0], startDate_parts[2]);

        //    //    var endDate = document.getElementById("txtFecTermino").value;
        //    //    var endDate_parts = startDate.split("-");
        //    //    var fin = new Date(endDate_parts[1], endDate_parts[0], endDate_parts[2]);

        //    //    alert(Date.parse(inicio) + " - " + Date.parse(fin));

        //    //    //if (Date.parse(inicio) > Date.parse(fin)) {
        //    //    //    alert("La \"Fecha Inicio Proyecto\" no puede ser mayor a la \"Fecha Término Proyeto\"");
        //    //    //    $("#txtFecTermino").focus();
        //    //    //}
        //    //}

        //    //if (!$("#txtFecInicio").val() || !$("#txtFecTermino").val()) {
        //    //    if (Date.parse($("#txtFecInicio").val()) > Date.parse("d-m-Y", $("#txtFecTermino").val())) {
        //    //        alert("La \"Fecha Inicio Proyecto\" no puede ser mayor a la \"Fecha Término Proyeto\"");
        //    //        $("#txtFecTermino").focus();
        //    //    }
        //    //}
        //}

        //$(function () {
        //    //var startDate = $("#txtFecInicio").val().replace('-', '/');
        //    //var endDate = $("#txtFecTermino").val().replace('-', '/');
        //    //var xxx = $.datepicker.parseDate("d/m/Y", $("#txtFecInicio").val());
        //    alert($.datepicker.parseDate("d-m-Y", $("#txtFecInicio").val()));

        //    if ($.datepicker.parseDate("d-m-Y", $("#txtFecInicio").val()) > $.datepicker.parseDate("d-m-Y", $("#txtFecTermino").val())) {
        //        alert("La \"Fecha Inicio Proyecto\" no puede ser mayor a la \"Fecha Término Proyeto\"");
        //        $("#txtFecTermino").focus();
        //    }
        //});
    </script>

</head>

<body role="document" onmousemove="SetProgressPosition(event)">

    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="txtFecInicio" />
            </Triggers>--%>
            <ContentTemplate>

                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="lbn_buscar_institucion"
                    PopupControlID="modal_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_institucion">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="mpe2"
                    BehaviorID="mpe2a"
                    runat="server"
                    TargetControlID="lbn_buscar_proyecto"
                    PopupControlID="modal_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_proyecto">
                </ajax:ModalPopupExtender>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A3" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Proyecto Adjudicado / En ejecución</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos guardados satisfactoriamente." Visible="false"></asp:Label>
                    </div>
                    <div class="popupConfirmation" id="modal_institucion" style="display: none">
                        <div class="modal-header header-modal">
                            <asp:LinkButton ID="lnb_close_buscar_institucion" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                        <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">INSTITUCION</h4>
                        </div>
                        <div>
                            <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                        </div>
                    </div>
                    <div class="popupConfirmation" id="modal_proyecto" style="display: none">
                        <div class="modal-header header-modal">
                            <asp:LinkButton ID="lnb_close_buscar_proyecto" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                        <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">PROYECTO</h4>
                        </div>
                        <div>
                            <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                        </div>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Proyecto Adjudicado / En ejecución</h4>

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-bordered  table-condensed">
                                    <tr>
                                        <th class="titulo-tabla col-md-1">Estado Proyecto *</th>
                                        <td>
                                            <div class="text-center">
                                                <asp:RadioButton ID="rdo001" runat="server" GroupName="gr1" Text="Adjudicado" OnCheckedChanged="rdo001_CheckedChanged" Checked="True" AutoPostBack="True" />
                                                <asp:RadioButton ID="rdo002" runat="server" GroupName="gr1" Text="En Ejecución" OnCheckedChanged="rdo002_CheckedChanged" AutoPostBack="True" />
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Institución *</th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()">
                                                <%--<asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClick="lbn_buscar_institucion_Click">--%>
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <th class="titulo-tabla">Institución</th>
                                        <td>
                                            <asp:DropDownList ID="ddown001" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton2_Click" />
                                            </a>
                                        </td>
                                    </tr>--%>

                                    <tr>
                                        <th class="titulo-tabla" scope="row">Proyecto *</th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lbn_buscar_proyecto" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto()">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>

                                    <%--<tr>
                                        <th class="titulo-tabla">Proyecto</th>
                                        <td>
                                            <asp:DropDownList ID="ddown002" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0" Selected="True">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_proyectos/proyectoadjudicadoenejecucion.aspx">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton1_Click" />
                                            </a>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server">
                            <h4 class="subtitulo-form">Resoluciones</h4>
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="table table-bordered  table-condensed">
                                        <tr>
                                            <th class="titulo-tabla col-md-1">Año</th>
                                            <td class="col-md-4">
                                                <asp:DropDownList ID="ddown010" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla col-md-1">Número de Resolución *</th>
                                            <td>
                                                <asp:TextBox ID="txtNumResol" runat="server" OnTextChanged="txtNumResol_TextChanged" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:DropDownList ID="ddown007" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown007_SelectedIndexChanged" Visible="False" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lnb001" runat="server" OnClick="LinkButton1_Click" Visible="False">Nueva</asp:LinkButton>
                                                <asp:Label ID="lbl003" runat="server" CssClass="texto_rojo_peque" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">Tipo de Resolución</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla">Fecha de Resolución *</th>
                                            <td>
                                                <asp:TextBox ID="txtFecResol" runat="server" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="cale_txtFecResol" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFecResol" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_cale_txtFecResol" />
                                                <asp:RegularExpressionValidator ID="rev_txtFecResol" ControlToValidate="txtFecResol" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">Materia</th>
                                            <td>
                                                <asp:TextBox ID="txtMateria" runat="server" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>

                                            <th class="titulo-tabla">Fecha Convenio *</th>
                                            <td>
                                                <asp:TextBox ID="txtFecConvenio" runat="server" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="cale_txtFecConvenio" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFecConvenio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_cale_txtFecConvenio" />
                                                <asp:RegularExpressionValidator ID="rev_txtFecConvenio" ControlToValidate="txtFecConvenio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">Fecha Inicio Proyecto *</th>
                                            <td>
                                                <asp:TextBox ID="txtFecInicio" runat="server" MaxLength="10" OnTextChanged="txtFecInicio_TextChanged" AutoPostBack="true" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="cale_txtFecInicio" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFecInicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_cale_txtFecInicio" />
                                                <asp:RegularExpressionValidator ID="rev_txtFecInicio" ControlToValidate="txtFecInicio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                <asp:Label ID="lb_fi" runat="server" Visible="false" ErrorMessage="La fecha de Inicio no puede ser mayor a la fecha de Termino" CssClass="help-block" Display="Dynamic"></asp:Label>
                                            </td>

                                            <th class="titulo-tabla">Fecha Término Proyeto *</th>
                                            <td>
                                                <asp:TextBox ID="txtFecTermino" runat="server" MaxLength="10" OnTextChanged="txtFecTermino_TextChanged" AutoPostBack="true" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="cale_txtFecTermino" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFecTermino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_cale_txtFecTermino" />
                                                <asp:RegularExpressionValidator ID="rev_txtFecTermino" ControlToValidate="txtFecTermino" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">Cobertura (Nº Plazas) *</th>
                                            <td>
                                                <asp:TextBox ID="txtCoberturas" runat="server" MaxLength="4" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rev_txtCoberturas" ControlToValidate="txtCoberturas" runat="server" ErrorMessage="Solo Puede Ingresar Números" CssClass="help-block" Display="Dynamic" ValidationExpression="\d+" />
                                                <%--<ajax:MaskedEditExtender ID="mee_txtCoberturas" runat="server" TargetControlID="txtCoberturas" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />--%>
                                            </td>

                                            <th class="titulo-tabla">Nº Plazas Adicionales</th>
                                            <td>
                                                <asp:TextBox ID="txtPlazasAdic" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rev_txtPlazasAdic" ControlToValidate="txtPlazasAdic" runat="server" ErrorMessage="Solo Puede Ingresar Números" CssClass="help-block" Display="Dynamic" ValidationExpression="\d+" />
                                                <%--<ajax:MaskedEditExtender ID="mee_txtPlazasAdic" runat="server" TargetControlID="txtPlazasAdic" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">% Plazas Asignadas Tribunal</th>
                                            <td>
                                                <asp:TextBox ID="txtPorcPlazasAsignadas" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rev_txtPorcPlazasAsignadas" ControlToValidate="txtPorcPlazasAsignadas" runat="server" ErrorMessage="Solo Puede Ingresar Números" CssClass="help-block" Display="Dynamic" ValidationExpression="\d+" />
                                                <%--<ajax:MaskedEditExtender ID="mee_txtPorcPlazasAsignadas" runat="server" TargetControlID="txtPorcPlazasAsignadas" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />--%>
                                            </td>

                                            <th class="titulo-tabla">Días Atención</th>
                                            <td>
                                                <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="trlbl002" runat="server" visible="false">
                                            <th class="titulo-tabla">
                                                <asp:Label ID="lbl002" runat="server" Text="Monto" Visible="False"></asp:Label></th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtMonto" runat="server" Visible="False" CssClass="form-control input-sm"></asp:TextBox>
                                                <ajax:MaskedEditExtender ID="mee_txtMonto" runat="server" TargetControlID="txtMonto" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="99999999" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">Tipo de Término</th>
                                            <td>
                                                <asp:DropDownList ID="ddown004" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    <asp:ListItem Value="A">Bilateral</asp:ListItem>
                                                    <asp:ListItem Value="U">Unilateral</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla">Sexo de la Población Atendida</th>
                                            <td>
                                                <asp:DropDownList ID="ddown008" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                    <asp:ListItem Value="A">Ambos Sexos</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">Meses SubAtención</th>
                                            <td>
                                                <asp:TextBox ID="txtMesSubAtencion" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rev_txtMesSubAtencion" ControlToValidate="txtMesSubAtencion" runat="server" ErrorMessage="Solo Puede Ingresar Números" CssClass="help-block" Display="Dynamic" ValidationExpression="\d+" />
                                                <%--<ajax:MaskedEditExtender ID="mee_txtMesSubAtencion" runat="server" TargetControlID="txtMesSubAtencion" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999" />--%>
                                            </td>

                                            <th class="titulo-tabla">Nº de Etapas</th>
                                            <td>
                                                <asp:TextBox ID="txtNumEtapas" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rev_txtNumEtapas" ControlToValidate="txtNumEtapas" runat="server" ErrorMessage="Solo Puede Ingresar Números" CssClass="help-block" Display="Dynamic" ValidationExpression="\d+" />
                                                <%--<ajax:MaskedEditExtender ID="mee_txtNumEtapas" runat="server" TargetControlID="txtNumEtapas" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999" />--%>
                                            </td>
                                        </tr>
                                        <tr id="trlbl001" runat="server" visible="false">
                                            <th class="titulo-tabla">
                                                <asp:Label ID="lbl001" runat="server" Text="Montos Por Etapa" Visible="False"></asp:Label></th>
                                            <td colspan="3">
                                                <asp:GridView ID="grv001" runat="server" AutoGenerateColumns="False" Visible="False">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Etapa" DataField="Etapa" />
                                                        <asp:BoundField HeaderText="Fecha Inicio" DataField="FechaInicio" DataFormatString="{0:d}" HtmlEncode="False" />
                                                        <asp:BoundField HeaderText="Fecha Fin" DataField="FechaTermino" DataFormatString="{0:d}" HtmlEncode="False" />
                                                        <asp:BoundField HeaderText="Monto Inversi&#243;n" DataField="MontoInversion" />
                                                        <asp:BoundField HeaderText="Monto Operaci&#243;n" DataField="MontoOperacion" />
                                                        <asp:BoundField HeaderText="Monto Personal" DataField="MontoPersonal" />
                                                        <asp:BoundField HeaderText="Factor" DataField="FactorEtapa" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>

                                    </table>
                                    <div class="pull-right">
                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnGuardar_NEW" runat="server" OnClick="btnGuardar_Click_NEW"  >
                                               <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                        </asp:LinkButton>
                                        <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="btnLimpiar_NEW" runat="server" OnClick="btnLimpiar_Click_NEW" Text="Limpiar" />--%>
                                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnLimpiar_NEW" runat="server" OnClientClick="limpiarForm();"  >
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                        </asp:LinkButton>
                                        <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="btnVolver_NEW" runat="server" OnClick="btnVolver_Click_NEW" Text="Volver" />--%>
                                    </div>
                                    <asp:TextBox ID="txtFecha" runat="server" Visible="false" MaxLength="10"></asp:TextBox>

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
            </ContentTemplate>
        </asp:UpdatePanel>
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
