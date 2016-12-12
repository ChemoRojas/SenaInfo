<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_Diligencias.aspx.cs" Inherits="mod_reportes_Rep_Diligencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Reporte Diligencias :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

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
                <asp:PostBackTrigger ControlID="ImageButton1" />

            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_institucion"
                    PopupControlID="modal_buscar_institucion"
                    CancelControlID="bt_cerrar_buscar_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                    TargetControlID="imb_proyecto"
                    PopupControlID="modal_buscar_proyecto"
                    CancelControlID="bt_cerrar_buscar_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>


                <div class="alert alert-warning text-center" role="alert" id="lbl_mensaje" runat="server" visible="false">
                    <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

                    <asp:Label ID="lbl_error" runat="server" Visible="False">No se han encontrado registros coincidentes.</asp:Label>
                </div>
                <h5 class="subtitulo-form">Reporte Diligencias</h5>
                <div class="row">
                    <div class="col-md-9">
                        <table class="table table-borderless table-condensed table-col-fix">
                            <tr>
                                <th>
                                    <label for="">Institución:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddown001" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:LinkButton ID="imb_institucion" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion','../mod_reportes/Rep_Diligencias.aspx','mpe1a')" runat="server" CausesValidation="False">
                                            <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </td>
                                <td>
                                    <div id="divContenido">
                                        <div class="popupConfirmation" id="modal_buscar_institucion" style="display: none">
                                            <div class="modal-header header-modal">
                                                <asp:LinkButton CssClass="close" aria-label="Close" ID="bt_cerrar_buscar_institucion" runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                                </asp:LinkButton>
                                                <h4 class="modal-title">INSTITUCION</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label for="">Proyecto:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="imb_proyecto" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_Diligencias.aspx','mpe2a')" runat="server" CausesValidation="False">
                                            <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </td>
                                <td>
                                    <div id="divContenido2">
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
                                    </div>
                                </td>
                            </tr>


                            <tr>
                                <th>
                                    <label for="">Período:</label>
                                </th>
                                <td>
                                    <div class="col-md-6 no-padding">
                                        <asp:DropDownList ID="ddown_MesCierre" runat="server" CssClass="form-control input-sm">
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

                                        <asp:DropDownList ID="ddown_AnoCierre" CssClass="form-control input-sm" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label for="">Tipo:</label>
                                </th>
                                <td>
                                    <asp:RadioButtonList align="center" RepeatDirection="Horizontal" ID="rdo_tipo" runat="server">
                                        <asp:ListItem Value="1">Diligencias Realizadas en el Mes</asp:ListItem>
                                        <asp:ListItem Value="0">Diligencias Pendientes (sin fecha realización)</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click" AutoPostback="true">
                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <%--   <asp:LinkButton ID="ImageButton1" runat="server" CssClass="btn btn-success btn-sm" Text="Exportar" OnClick="ImageButton1_Click"  CausesValidation="False" Visible="true" >
                                        <span class="glyphicon glyphicon-floppy-save"></span>
                           </asp:LinkButton>--%>
                                    <asp:LinkButton ID="ImageButton1" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="ImageButton1_Click"><span class="glyphicon glyphicon-floppy-save"></span> Exportar</asp:LinkButton>


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
                                <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Seleccione el tipo de reporte. Luego ingrese los parámetros solicitados para generar el reporte específico"></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>



                <div class="row">
                    <div id="div_encabezado1" runat="server" visible="false">
                        <%--aqui iba boton--%>
                        <asp:Label ID="lblsin" runat="server" Text="Reporte Niños con diligencias" Visible="true"></asp:Label>
                    </div>
                    <asp:GridView ID="grd001" runat="server" CssClass="table  table-bordered table-hover " AutoGenerateColumns="False" CellPadding="2" AllowPaging="True" OnPageIndexChanging="grd001_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="codnino" HeaderText="Cod. Ni&#241;o"></asp:BoundField>
                            <asp:BoundField DataField="icodie" HeaderText="Icodie"></asp:BoundField>
                            <asp:BoundField DataField="apellido_paterno" HeaderText="Ap. Paterno"></asp:BoundField>
                            <asp:BoundField DataField="apellido_materno" HeaderText="Ap. Materno"></asp:BoundField>
                            <asp:BoundField DataField="nombres" HeaderText="Nombres"></asp:BoundField>
                            <asp:BoundField DataField="fechaingreso" HeaderText="F. Ingreso" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="fechaegreso" HeaderText="F. Egreso" DataFormatString="{0:d}"></asp:BoundField>
                            <asp:BoundField DataField="rut" HeaderText="Rut"></asp:BoundField>
                            <asp:BoundField DataField="sexo" HeaderText="Sexo"></asp:BoundField>
                            <asp:BoundField DataField="fechanacimiento" HeaderText="F. Nacim." DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="CodigoDiligencia" HeaderText="Cod. Diligencia"></asp:BoundField>
                            <asp:BoundField DataField="FechaSolicitud" HeaderText="F. Solicitud" DataFormatString="{0:d}"></asp:BoundField>
                            <asp:BoundField DataField="CodSolicitante" HeaderText="Cod. Solicitante"></asp:BoundField>
                            <asp:BoundField DataField="Solicitante" HeaderText="Solicitante"></asp:BoundField>
                            <asp:BoundField DataField="CodDiligencia" HeaderText="Cod. Diligencia"></asp:BoundField>
                            <asp:BoundField DataField="Diligencia" HeaderText="Diligencia"></asp:BoundField>
                            <asp:BoundField DataField="FueRealizada" HeaderText="Fue Realizada" DataFormatString="{0:d}"></asp:BoundField>
                            <asp:BoundField DataField="FechaRealizada" HeaderText="F. Realizada" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="Trabajador" HeaderText="Trabajador"></asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                        <PagerStyle CssClass="pagination-ys" />
                        <RowStyle CssClass="caja-tabla table-bordered" />
                    </asp:GridView>
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
