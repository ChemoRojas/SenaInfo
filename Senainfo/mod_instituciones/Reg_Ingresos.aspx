<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg_Ingresos.aspx.cs" Inherits="mod_instituciones_Reg_Ingresos" %>

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
    <title>Registro de Ingresos :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=Reg_Ingresos.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe1a").show();

            return false;
        }

        function MostrarModalProyecto() {
            var objIframe = document.getElementById('iframe_bsc_proyecto');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=Reg_Ingresos.aspx";
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
    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)">

    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="btnNuevo" />
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
                        <li class="active">Registro de Ingresos</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Ingresos</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <asp:Panel ID="pnlHeader" runat="server" Width="100%" Visible="true" Wrap="False">
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <td class="titulo_form">Registro de Ingresos</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table table-borderless table-condensed table-col-fix">
                                                        <tr>
                                                            <td>
                                                                <table class="table table-borderless table-condensed table-col-fix">
                                                                    <tr>
                                                                        <td>Institución</td>
                                                                        <td>
                                                                            <div class="input-group">
                                                                                <asp:DropDownList ID="ddlInstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()"> <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                                                            </div>
                                                                            <div class="popupConfirmation" id="modal_institucion" style="display: none">
                                                                                <div class="modal-header header-modal">
                                                                                    <asp:LinkButton ID="lnb_close_buscar_institucion" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false"> <span aria-hidden="true">&times;</span> </asp:LinkButton>
                                                                                    <h4 class="modal-title">Buscar Institución</h4>
                                                                                </div>
                                                                                <div>
                                                                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Proyecto</td>
                                                                        <td>
                                                                            <div class="input-group">
                                                                                <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="form-control input-sm">
                                                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:LinkButton ID="lbn_buscar_proyecto" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto()"> <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                                                            </div>
                                                                            <div class="popupConfirmation" id="modal_proyecto" style="display: none">
                                                                                <div class="modal-header header-modal">
                                                                                    <asp:LinkButton ID="lnb_close_buscar_proyecto" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false"> <span aria-hidden="true">&times;</span> </asp:LinkButton>
                                                                                    <h4 class="modal-title">Buscar Proyecto</h4>
                                                                                </div>
                                                                                <div>
                                                                                    <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Periodo a Rendir</td>
                                                                        <td>
                                                                            <table class="table table-borderless table-condensed table-col-fix">
                                                                                <tr>
                                                                                    <td>Mes:</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlMeses" runat="server" CssClass="form-control input-sm">
                                                                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                                                            <asp:ListItem Value="1">ENERO</asp:ListItem>
                                                                                            <asp:ListItem Value="2">FEBRERO</asp:ListItem>
                                                                                            <asp:ListItem Value="3">MARZO</asp:ListItem>
                                                                                            <asp:ListItem Value="4">ABRIL</asp:ListItem>
                                                                                            <asp:ListItem Value="5">MAYO</asp:ListItem>
                                                                                            <asp:ListItem Value="6">JUNIO</asp:ListItem>
                                                                                            <asp:ListItem Value="7">JULIO</asp:ListItem>
                                                                                            <asp:ListItem Value="8">AGOSTO</asp:ListItem>
                                                                                            <asp:ListItem Value="9">SEPTIEMBRE</asp:ListItem>
                                                                                            <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                                                                            <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                                                                            <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>Año:</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtAno" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                                        <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAno" Mask="9999" MaskType="Number" InputDirection="RightToLeft" ErrorTooltipEnabled="True" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Fecha Registro de Ingreso</td>
                                                                        <td>
                                                                            <asp:TextBox ID="ddlFechaRegistro" runat="server" Text="Seleccione Fecha" EnableTheming="True" TextMode="SingleLine" ReadOnly="false" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                            <%--<ajax:CalendarExtender ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddlFechaRegistro" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>--%>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="ddlFechaRegistro" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div class="pull-right">
                                                                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnNuevo" runat="server" Text="Nuevo Ingreso" OnClick="btnNuevo_Click" />
                                                                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnBuscaRendicion" runat="server" Text="Buscar Ingresos" OnClick="btnBuscaRendicion_Click" />
                                                                                <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelar" runat="server" Text="Limpiar Ingreso" Visible="False" OnClick="btnCancelar_Click" />
                                                                                <%--<asp:Button CssClass="btn btn-info btn-sm" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />--%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Label ID="lblInformacion" runat="server" Text="La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios." Visible="False"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="txtIdRendicionIngreso" runat="server" Visible="False" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                   
                                    <asp:Panel ID="pnlBody" runat="server" Width="100%" Visible="False" Wrap="False">
                                        <asp:Panel ID="pnlDetail" runat="server" Width="100%" Visible="False" Wrap="False">
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td>
                                                        <table class="table table-borderless table-condensed table-col-fix">
                                                            <tr>
                                                                <td>
                                                                    <table class="table table-borderless table-condensed table-col-fix" id="tblEditar" runat="server">
                                                                        <tr>
                                                                            <td>Fecha</td>
                                                                            <td>
                                                                                <asp:TextBox ID="ddlFechaComprobante" runat="server" Text="Seleccione Fecha" EnableTheming="True" Font-Bold="False" Font-Italic="False" Font-Overline="False" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                                                                <%--<ajax:CalendarExtender ID="CalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddlFechaComprobante" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>--%>
                                                                                <%--<ajax:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="ddlFechaComprobante"/>--%>  
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Enabled="true" ControlToValidate="ddlFechaComprobante" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Nro Comprobante</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNumeroComprobante" runat="server" ReadOnly="True"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator51" Enabled="true" ControlToValidate="txtNumeroComprobante" runat="server" ErrorMessage="N&uacute;mero Comprobante Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Correlativo</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCorrelativo" runat="server" Text="Agregar" EnableTheming="True" ReadOnly="True" />
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Enabled="true" ControlToValidate="txtCorrelativo" runat="server" ErrorMessage="Correlativo Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\d{7})$" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Tipo Ingreso</td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlTipoIngreso" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoIngreso_SelectedIndexChanged"></asp:DropDownList>
                                                                                <asp:Label ID="lblTipoIngreso" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Detalle Ingreso</td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlDetalleIngreso" runat="server" OnSelectedIndexChanged="ddlDetalleIngreso_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                                <asp:Label ID="lblDetalleIngreso" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Monto</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtMonto" runat="server" Text="0"></asp:TextBox>
                                                                                <%--<ajax:MaskedEditExtender ID="txtMonto_MaskedEditExtender1" runat="server"
                                                                                    Enabled="True" TargetControlID="txtMonto"
                                                                                    MaskType="Number"
                                                                                    ClearMaskOnLostFocus="true"
                                                                                    InputDirection="RightToLeft"
                                                                                    AcceptNegative="None"
                                                                                    MessageValidatorTip="true"></ajax:MaskedEditExtender>
                                                                                <ajax:MaskedEditValidator ID="MaskedEditValidator1" ControlExtender="txtMonto_MaskedEditExtender1" runat="server" ControlToValidate="txtMonto" IsValidEmpty="False" EmptyValueMessage="Ingrese Monto" InvalidValueMessage="Monto invalido" MinimumValueMessage="Monto Minimo 0" MinimumValue="0" EmptyValueBlurredText="*" MaximumValueBlurredMessage="*" MinimumValueBlurredText="*" Display="Dynamic" TooltipMessage="Montos Superiores a Cero" />--%>
                                                                                <asp:Label ID="lblMonto" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Glosa</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGlosa" runat="server" MaxLength="20"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Anular</td>
                                                                            <td>
                                                                                <asp:RadioButtonList ID="rbAnular" runat="server" Height="8px" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="pull-right">
                                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnGuardaIngreso" runat="server" Text="Guardar Ingreso" Visible="False" OnClick="btnGuardaIngreso_Click" />
                                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelaIngreso" runat="server" Text="Cancelar" Visible="False" OnClick="btnCancelaIngreso_Click" />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <td>
                                                    <div class="pull-right">
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnIngreso" runat="server" Text="Agregar Ingreso" Visible="False" OnClick="btnIngreso_Click" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" OnClick="btnImprimir_Click" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnExcel" runat="server" Text="Exportar a Excel" Visible="False" OnClick="btnExcel_Click" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grdIngresoDetalles" runat="server" AllowSorting="True"
                                                        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No hay Información"
                                                        ForeColor="#333333" GridLines="None" OnRowEditing="grdIgresoDetalles_RowEditing" Width="100%" OnRowCommand="grdIgresoDetalles_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="FechaComprobante" DataFormatString="{0:d}" HeaderText="Fecha" HtmlEncode="False">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NroComprobante" HeaderText="N&#186; Comprob.">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Correlativo" HeaderText="#">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TipoIngreso" HeaderText="Tipo Ingreso">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DetalleIngreso" HeaderText="Detalle Ingreso">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Monto" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Glosa" HeaderText="Glosa">
                                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Nulo">
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                            <asp:CheckBox ID="chkNulo" runat="server" Enabled="False" ForeColor="Black" Checked='<%# Eval("Nulo") %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    &nbsp;
                                                            <asp:CheckBox ID="chkNulo" runat="server" Enabled="False" ForeColor="Black" />
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField InsertVisible="False" ShowEditButton="True" ShowHeader="True" DeleteText="Borrar" EditText="Modificar">
                                                                <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                            </asp:CommandField>
                                                            <asp:ButtonField CommandName="Correlativo" Text="Dividir Comprobante">
                                                                <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                            </asp:ButtonField>
                                                            <asp:ButtonField CommandName="Eliminar" Text="Eliminar">
                                                                <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                            </asp:ButtonField>
                                                            <asp:BoundField DataField="CodTipoIngreso">
                                                                <ItemStyle Font-Size="0px" HorizontalAlign="Left" ForeColor="White" Width="1px" />
                                                                <ControlStyle ForeColor="White" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CodDetalleIngreso">
                                                                <ItemStyle Font-Size="0pt" HorizontalAlign="Left" ForeColor="White" Width="1px" />
                                                                <ControlStyle ForeColor="White" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table table-borderless table-condensed table-col-fix" id="tblTotal" runat="server">
                                                        <tr>
                                                            <td>Monto Total de Ingreso </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTotal" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                                               
                                                               <%-- <ajax:MaskedEditValidator ID="MaskedEditValidator2" ControlExtender="MaskedEditExtender_txtTotal" runat="server" ControlToValidate="txtTotal" IsValidEmpty="False" EmptyValueMessage="Ingrese Monto Total de Ingreso" InvalidValueMessage="Monto Total de Ingreso Inválido" MinimumValueMessage="Monto Minimo 0" MinimumValue="0" EmptyValueBlurredText="*" MaximumValueBlurredMessage="*" MinimumValueBlurredText="*" Display="Dynamic" TooltipMessage="Montos Superiores a Cero" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlSearch" runat="server" Width="100%" Visible="False" Wrap="False">
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <td>Ingresos</td>
                                            </tr>
                                        </table>
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <td>
                                                    <table class="table table-borderless table-condensed table-col-fix">
                                                        <tr>
                                                            <th>IdRendicion Ingreso</th>
                                                            <td>
                                                                <asp:TextBox ID="txtIdrendicionIngreso2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtIdrendicionIngreso2" runat="server" ErrorMessage="IdRendicion Inválido" ValidationExpression="^\d+$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Institución</th>
                                                            <td>
                                                                <asp:TextBox ID="txtInstitucion" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Código Proyecto</th>
                                                            <td>
                                                                <asp:TextBox ID="txtCodProyecto" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtCodProyecto" runat="server" ErrorMessage="Código Proyecto Inválido" ValidationExpression="^\d+$" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Proyecto</th>
                                                            <td>
                                                                <asp:TextBox ID="txtProyecto" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>AñoMes (aaaamm)</th>
                                                            <td>
                                                                <asp:TextBox ID="txtAnoMes" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtAnoMes" runat="server" ErrorMessage="Año Mes Inválido" ValidationExpression="^\d{4}((0[1-9])|(1[012]))" Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div class="pull-right">
                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnLimpiaBusqueda" runat="server" Text="Limpiar" OnClick="btnLimpiaBusqueda_Click" />
                                                                    <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelarBusqueda" runat="server" Text="Cancelar" OnClick="btnCancelarBusqueda_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:GridView ID="grdBuscador" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CellPadding="4" EmptyDataText="No hay Información" ForeColor="#333333" GridLines="None"
                                            OnRowEditing="grdBuscador_RowEditing" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="IdRendicionIngreso" HeaderText="IdRendicionIngreso">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CodInstitucion" HeaderText="CodInstitucion">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Nombre Institucion" DataField="Institucion">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CodProyecto" HeaderText="CodProyecto">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Nombre Proyecto" DataField="Proyecto">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="A&#241;o Mes (aaaamm)" DataField="AnoMes">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Fecha de Registro" DataField="FechaRegistro" DataFormatString="{0:d}" HtmlEncode="False">
                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Cerrado">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkCerrado" runat="server" Checked='<%# Eval("Cerrado") %>' Enabled="False" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar">
                                                    <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                </asp:CommandField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                        <br />
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
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