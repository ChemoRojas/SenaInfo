<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_PersonaContacto.aspx.cs" Inherits="mod_reportes_Rep_PersonaContacto" %>

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
    <title>Reporte Persona Contacto :: Senainfo :: Servicio Nacional de Menores</title>

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
                <div id="divContenido">
                    <div id="modal_buscar_institucion" class="popupConfirmation" style="display: none">
                        <div class="modal-header header-modal">
                            <asp:LinkButton ID="bt_cerrar_buscar_institucion" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                                            <span aria-hidden="true">×</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">Senainfo/ Institución</h4>
                        </div>
                        <div>
                            <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                        </div>
                    </div>
                </div>
                <div id="divContenido2">
                    <div id="modal_buscar_proyecto" class="popupConfirmation" style="display: none">
                        <div class="modal-header header-modal">
                            <asp:LinkButton ID="bt_cerrar_buscar_proyecto" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                                            <span aria-hidden="true">×</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">Senainfo/ Proyecto</h4>
                        </div>
                        <div>
                            <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                        </div>
                    </div>
                </div>


                <div class="alert alert-warning text-center" role="alert" id="lbl_error" runat="server" visible="false">
                    <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

                    <asp:Label ID="LBLNO" runat="server" Text="No se han encontrado registros coincidentes." Visible="true"></asp:Label>
                </div>
                <h5 class="subtitulo-form">Reporte Persona Contacto</h5>
                <div class="row">
                    <div class="col-md-9">
                        <table class="table table-borderless table-condensed table-col-fix">
                            <tr>
                                <th>
                                    <label for="">Institución:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="imb_institucion" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_PersonaContacto.aspx','mpe1a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </td>

                            </tr>
                            <tr>
                                <th>
                                    <label for="">Proyecto:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="imb_proyecto" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_PersonaContacto.aspx','mpe2a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label for="">Período</label>
                                </th>
                                <td>
                                    <div class="col-md-6 no-padding">
                                        <asp:DropDownList ID="ddown_MesCierre" runat="server" CssClass="form-control input-sm">
                                            <asp:ListItem Value="0">Seleccione mes</asp:ListItem>
                                            <asp:ListItem Value="01">Enero</asp:ListItem>
                                            <asp:ListItem Value="02">Febrero</asp:ListItem>
                                            <asp:ListItem Value="03">Marzo</asp:ListItem>
                                            <asp:ListItem Value="04">Abril</asp:ListItem>
                                            <asp:ListItem Value="05">Mayo</asp:ListItem>
                                            <asp:ListItem Value="06">Junio</asp:ListItem>
                                            <asp:ListItem Value="07">Julio</asp:ListItem>
                                            <asp:ListItem Value="08">Agosto</asp:ListItem>
                                            <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 no-padding">
                                        <asp:DropDownList ID="ddown_AnoCierre" runat="server" CssClass="form-control input-sm">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:LinkButton ID="btn_buscar" CssClass="btn btn-danger btn-sm fixed-width-button" runat="server" OnClick="btn_buscar_Click">
                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn_limpiar" CssClass="btn btn-info btn-sm fixed-width-button pull-right" runat="server" OnClick="btn_limpiar_Click">
                             <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>

                                    <%-- <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Excel1.bmp" OnClick="ImageButton1_Click" />--%>
                                    <asp:LinkButton ID="ImageButton1" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="ImageButton1_Click1"><span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar</asp:LinkButton>


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

                    <asp:GridView ID="grd001" CssClass="table table-bordered table-hover " runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grd001_PageIndexChanging">
                        <HeaderStyle CssClass="titulo-tabla" />
                        <Columns>
                            <asp:BoundField DataField="CodNino" HeaderText="Cod. Ni&#241;o"></asp:BoundField>
                            <asp:BoundField DataField="ICodIE" HeaderText="Icodie"></asp:BoundField>
                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Ap. Paterno"></asp:BoundField>
                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Ap. Materno"></asp:BoundField>
                            <asp:BoundField DataField="NombresNino" HeaderText="Nombres"></asp:BoundField>
                            <asp:BoundField DataField="Rut" HeaderText="Rut"></asp:BoundField>
                            <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                            <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="F. Nacim." HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="F. Ingreso" HtmlEncode="False"></asp:BoundField>
                            <asp:BoundField DataField="FechaEgreso" DataFormatString="{0:d}" HeaderText="F. Egreso"></asp:BoundField>
                            <asp:BoundField DataField="PersonaContacto" HeaderText="Persona Contacto"></asp:BoundField>
                            <asp:BoundField DataField="TipoRelacionPersonaContacto" HeaderText="Tipo Relacion Persona Contacto"></asp:BoundField>
                            <asp:BoundField DataField="Permanencia" HeaderText="Permanencia"></asp:BoundField>
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
