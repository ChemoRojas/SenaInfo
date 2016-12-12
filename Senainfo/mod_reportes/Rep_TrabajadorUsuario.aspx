<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_TrabajadorUsuario.aspx.cs" Inherits="Reportes_Rep_TrabajadorUsuario" %>

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
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="ImageButton1" />
            </Triggers>
            <ContentTemplate>
                <Ajax:ModalPopupExtender ID="mpe4" BehaviorID="mpe4a" runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </Ajax:ModalPopupExtender>

                <Ajax:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe4b" runat="server"
                    TargetControlID="imb_lupa_modal2"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal3">
                </Ajax:ModalPopupExtender>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Reportes</li>
                        <li class="active">Reportes de Instituciones</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

	                            <asp:Label ID="lbl_error_estile" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Trabajador Usuario</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                            <table class="table table-borderless table-condensed table-col-fix">
                                <tr>
                                    <th class="auto-style1">
                                        <label for="">
                                            Instituci�n:</label>
                                    </th>
                                    <td class="auto-style1">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddInstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddInstitucion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_TrabajadorUsuario.aspx','mpe1a')">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
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
                                            <asp:DropDownList ID="ddProyecto" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_TrabajadorUsuario.aspx','mpe1b')">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click" ValidationGroup="valError"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                        <asp:LinkButton ID="btn_limpiar" runat="server" CausesValidation="false" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>
                                        <asp:LinkButton ID="ImageButton1" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="ImageButton1_Click1" Visible="false"><span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar</asp:LinkButton>

                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--fin col-md-9 -->
                        <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                                          <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">REPORTE DE INSTITUCIONES</h4>
                            </div>
                            <div>
                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                        <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal3" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                                            <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">REPORTE DE INSTITUCIONES</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                            </div>
                            <!--fin popup-->
                        </div>
                        <div class="col-md-3">


                            <div class="panel-info panel-primary-info">
                                        <div class="panel-heading">
                                            Informaci�n
                                        </div>
                                        <div class="panel-footer">
                                            <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los par�metros solicitados para generar el reporte."></asp:Label>
                                        </div>
                                    </div>

                        </div>
                    </div>
                </div>
                <!--cierra Row-->


                        <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">
                            <Columns>
                                <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                <asp:BoundField DataField="Institucion" HeaderText="Nombre Inst."></asp:BoundField>
                                <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                <asp:BoundField DataField="Proyecto" HeaderText="Nombre Proyecto"></asp:BoundField>
                                <asp:BoundField DataField="ICodTrabajador" HeaderText="Cod. Trabajador" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                <asp:BoundField DataField="Paterno" HeaderText="Ap. Paterno"></asp:BoundField>
                                <asp:BoundField DataField="Materno" HeaderText="Ap. Materno"></asp:BoundField>
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                <asp:BoundField DataField="RutTrabajador" HeaderText="RUN"></asp:BoundField>
                                <asp:BoundField DataField="Cargo" HeaderText="Cargo"></asp:BoundField>
                                <asp:BoundField DataField="FechaActualizacion" HeaderText="F. Actualizaci&#243;n" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                <asp:BoundField DataField="Rol" HeaderText="Rol"></asp:BoundField>
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario"></asp:BoundField>
                                <asp:BoundField DataField="VigenciaTrabajador" HeaderText="Vig. Trabajador" />
                                <asp:BoundField DataField="VigenciaTrabajadorProyecto" HeaderText="Vig. Trab-Proy" />
                            </Columns>
                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                            <RowStyle CssClass="caja-tabla table-bordered" />
                        </asp:GridView>
                </div>

                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valError" ShowModelStateErrors="False" />
                <footer class="footer" aria-hidden="False">
                    <div class="container">

                        <p>
                            Para tus dudas y consultas, escribe a:<br>
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