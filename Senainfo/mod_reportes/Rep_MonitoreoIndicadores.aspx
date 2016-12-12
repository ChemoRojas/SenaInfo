<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_MonitoreoIndicadores.aspx.cs" Inherits="mod_reportes_Rep_MonitoreoIndicadores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>


<!DOCTYPE html>

<html lang="es">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">


    <title>Reportes :: SenaInfo :: Servicion Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>



</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form2" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_buscar" />
                </Triggers>
                <ContentTemplate>

                    <Ajax:ModalPopupExtender ID="mpe4" BehaviorID="mpe4a" runat="server"
                        TargetControlID="imb_lupa_modal"
                        PopupControlID="modal_bsc_institucion"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal1">
                    </Ajax:ModalPopupExtender>

                    <!--popup de proyecto-->
                    <Ajax:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe4b" runat="server"
                        TargetControlID="imb_lupa_modal2"
                        PopupControlID="modal_bsc_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal3">
                    </Ajax:ModalPopupExtender>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A3" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes</a>            </li>
                            <li class="active">Reporte de Monitoreo de Indicadores</li>
                        </ol>
                        <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

                            <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reporte de Monitoreo de Indicadores</h4>
                            <hr />
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">
                                                Región:</label> </th>
                                            <td>
                                                <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="form-control input-sm" EnableViewState="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                Institución:</label> </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_MonitoreoIndicadores.aspx','mpe1a')">
                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                </div>
                                                <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                                                    <div class="modal-header header-modal">
                                                        <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                <span aria-hidden="true">×</span>
                                                            </asp:LinkButton>
                                                        <h4 class="modal-title">REPORTES</h4>
                                                    </div>
                                                    <div>
                                                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                    </div>
                                                    <div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                Proyectos:</label> </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_MonitoreoIndicadores.aspx','mpe1b')">
                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                </div>
                                                <!--popup proyecto-->
                                                <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                                                    <div class="modal-header header-modal">
                                                        <asp:LinkButton ID="btnCerrarModal3" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                <span aria-hidden="true">×</span>
                                                            </asp:LinkButton>
                                                        <h4 class="modal-title">REPORTES</h4>
                                                    </div>
                                                    <div>
                                                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                                    </div>
                                                    <!--fin popup-->
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                Periodo:</label></th>
                                            <td>
                                                <div class="col-md-6 no-padding">
                                                    <asp:DropDownList ID="ddown_MesCierre" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="0">Seleccione mes</asp:ListItem>
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
                                                </div>
                                                <div class="col-md-6 no-padding">
                                                    <asp:DropDownList ID="ddown_AnoCierre" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="">
                                                Tipo de Reporte:</label> </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_indicadores" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                               
                                                <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                                <Ajax:ConfirmButtonExtender ID="btn_buscar_ConfirmButtonExtender" runat="server" TargetControlID="btn_buscar" />
                                                <asp:LinkButton ID="hlInstructivo" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" href="../links/Instructivo-Reporte-ICI-IGR.pdf" target="_blank"><span class="glyphicon glyphicon-eye-open"></span>&nbsp;Instructivo</asp:LinkButton>
                                                <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!--fin col-md-9 -->
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
                            </div>
                            <!--cierra Row-->
                            <!--Row para desplegar tabla con datos-->


                            <div class="col-md-12 table-responsive">
                                <br />
                                <asp:Label ID="lbl_warningvacios" runat="server"></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <%--<footer class="footer">
            <div class="container">
                <p>
                    Para tus dudas y consultas, escribe a:
                   <br>
                    mesadeayuda@sename.cl
                </p>
            </div>
        </footer>--%>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>

                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </form>
    <%--aqui termina--%>
</body>
</html>
