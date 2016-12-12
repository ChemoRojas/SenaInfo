<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_InfraccionDisciplinaria.aspx.cs" Inherits="mod_reportes_Rep_InfraccionDisciplinaria" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Nómina de infracciones disciplinarias :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <%--<script src="../js/jquery-1.9.1.js"></script>--%>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>




</head>
<body class="body-iframe-reportes" onmousemove="SetProgressPosition(event)" onkeydown="return (event.keyCode!=13)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="imb001" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                    TargetControlID="imb_proyecto"
                    PopupControlID="modal_buscar_proyecto"
                    CancelControlID="bt_cerrar_buscar_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                    <strong>
                        <asp:Label runat="server" ID="lblError"></asp:Label></strong>

                    <asp:Label ID="Label1" runat="server"></asp:Label>

                    <asp:Label ID="lblaviso" runat="server" Text="Label" Visible="False"></asp:Label>

                </div>
                <h5 class="subtitulo-form">NÓMINA DE INFRACCIONES DISCIPLINARIAS</h5>
                <div class="row">
                    <div class="col-md-9">
                        <table class="table table-borderless table-condensed table-col-fix">
                            <tr style="border-bottom:1px solid white;">
                                <th class="titulo-tabla">
                                    <label for="ddown001">Institución:</label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" Enabled="False">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="border-bottom:1px solid white;">
                                <th class="titulo-tabla">
                                    <label for="">Proyecto:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:TextBox ID="txt001" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="fte29" runat="server" TargetControlID="txt001" ValidChars="0123456789" />
                                        <asp:LinkButton ID="imb_proyecto" CssClass="input-group-addon btn btn-info btn-sm" AutoPostback="true" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_InfraccionDisciplinaria.aspx','mpe2a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </td>
                                <td>
                                    <div class="popupConfirmation" id="modal_buscar_proyecto" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="bt_cerrar_buscar_proyecto" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">PROYECTO</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="border-bottom:1px solid white;">
                                <th class="titulo-tabla">
                                    <label for="">Detalle por</label>
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" align="center" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Selected="True">Infracciones por Tipo de Listado</asp:ListItem>
                                        <asp:ListItem Value="1">Infracciones por Fechas </asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr style="border-bottom:1px solid white;">
                                <th class="titulo-tabla">
                                    <label for="">Tipo Listado</label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                        <asp:ListItem Value="1">Ingresos</asp:ListItem>
                                        <asp:ListItem Value="2">Egresos</asp:ListItem>
                                        <asp:ListItem Value="3">Vigentes</asp:ListItem>
                                        <asp:ListItem Value="4">Atendidos</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla">
                                    <asp:Label ID="lbl_periodo" runat="server" Text="Período" Visible="true"></asp:Label>
                                </th>
                                <td>
                                    <table class="tabla-para-fechas">
                                        <tr>
                                            <td>
                                                <%--<asp:TextBox ID="txtFecha" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" ReadOnly="True" Visible="False"></asp:TextBox>--%>
                                                
                                            <%--    <ajax:FilteredTextBoxExtender ID="fte4" runat="server" TargetControlID="txtFecha" ValidChars="0123456789" />--%>
                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control form-control-fecha-large input-sm" MaxLength="10" placeholder="dd-mm-aaaa"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txtFecha" ValidChars="0123456789-/" />
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txtFecha" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                    <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="txtFecha" Type="Date" OnInit="rv_fecha_Init" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>&nbsp;<asp:Label ID="lblmes" runat="server" Text="Mes:"></asp:Label>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" Visible="False">
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;<asp:Label ID="lblano" runat="server" Text="Año:"></asp:Label>
                                                &nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="wne001" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="wne001_SelectedIndexChanged" Visible="False">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    <asp:ListItem>2007</asp:ListItem>
                                                    <asp:ListItem>2008</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btnLimpiar_NEW" runat="server" OnClick="btnLimpiar_NEW_Click" CausesValidation="False">
                                           <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar

                                    </asp:LinkButton>
                                    <asp:LinkButton ID="imb001" runat="server" CssClass="btn btn-success btn-sm fixed-width-button"  OnClick="imb001_Click">
                                 <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnproy" runat="server" OnClick="btnproy_Click"></asp:LinkButton>

                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-3">
                        <div class="panel-info panel-primary-info">
                                        <div class="panel-heading">
                                            Información
                                        </div>
                                        <div class="panel-footer">
                                            <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados para generar el reporte."></asp:Label>
                                        </div>
                                    </div>
                        
                    </div>
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
