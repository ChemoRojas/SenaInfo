<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_ListadeEspera.aspx.cs" Inherits="mod_reportes_Rep_ListadeEspera" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>



<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Reportes :: SenaInfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_excel" />
                <asp:PostBackTrigger ControlID="btn_buscar" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <ajax:ModalPopupExtender
                    ID="ModalPopupExtender1"
                    BehaviorID="mpe1b"
                    runat="server"
                    TargetControlID="imb_lupa_modal2"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>


                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li><a href="#">Reportes</a></li>
                        <li class="active">Reporte Lista de Espera</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

                        <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertOk" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>&nbsp;

                        <asp:Label ID="lbl_ok" runat="server" Visible="False"></asp:Label>
                    </div>
                    


                    <div class="well">
                        <h4 class="subtitulo-form">Reporte Lista de Espera</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Región:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Institución:</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_ListadeEspera.aspx','mpe1a')">
                                    <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Proyecto:</label>
                                        </th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddproyecto" runat="server" AutoPostBack="True" CssClass="form-control input-sm" Width="523px">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_ListadeEspera.aspx','mpe1b')">
                                   <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Periodo:</label></th>
                                        <td>
                                            <div class="col-md-2">
                                                <label for="">
                                                    Inicio:
                                                </label>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="cal_inicio" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ControlToValidate="cal_inicio" CssClass="help-block" Display="Dynamic" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal_inicio" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2">
                                                <label for="">
                                                    Término:
                                                </label>
                                            </div>
                                            <div class="col-md-4 no-padding">
                                                <asp:TextBox ID="cal_Termino" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_Termino" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_Termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="cal_Termino" CssClass="help-block" Display="Dynamic" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal_Termino" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag">
                                                </asp:RequiredFieldValidator>
                                            </div>


                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Tipo:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddtipo" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="1">Vigentes</asp:ListItem>
                                                <asp:ListItem Value="2">Egresos</asp:ListItem>
                                                <asp:ListItem Value="3">Ingresos</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>

                                            <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click">  <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                            <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click">  <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar</asp:LinkButton>
                                            <asp:LinkButton ID="btn_excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click1">  <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar</asp:LinkButton>


                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--<asp:Label ID="lbl_error" runat="server" Font-Size="11px" ForeColor="Red" Visible="False">No se han encontrado registros coincidentes.</asp:Label>--%>
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
                        <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	            <span aria-hidden="true">×</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">REPORTE LISTA DE ESPERA</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                        <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal2" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	            <span aria-hidden="true">×</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">REPORTE LISTA DE ESPERA</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
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
        <footer class="footer">
            <div class="container">
                <p>
                    Para tus dudas y consultas, escribe a:
                <br>
                    mesadeayuda@sename.cl
                </p>
            </div>
        </footer>
    </form>
</body>
</html>
