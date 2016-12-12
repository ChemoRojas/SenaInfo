<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Reg_Rendicion_Instituciones.aspx.cs" Inherits="mod_instituciones_Reg_Rendicion_Instituciones" %>

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
    <title>Rendición de Cuentas de Instituciones :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=Reg_Rendicion_Instituciones.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe1a").show();

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

    <form id="Reg_Rendicion" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnBuscaRendicion" />
                <asp:PostBackTrigger ControlID="btnCancelar" />
                <asp:PostBackTrigger ControlID="btnImprimir" />
                <asp:PostBackTrigger ControlID="btnBuscar" />
                <asp:PostBackTrigger ControlID="btnLimpiaBusqueda" />
                <asp:PostBackTrigger ControlID="btnCancelarBusqueda" />
                <asp:PostBackTrigger ControlID="btnAceptar" />
                <asp:PostBackTrigger ControlID="btnEgresos" />
            </Triggers>
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

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A4" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Rendición de Cuentas de Instituciones</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Rendición de Cuentas de Instituciones</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-12">

                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlHeader" runat="server" Visible="true" Width="100%" Wrap="False">
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td>
                                                            <table class="table table-borderless table-condensed table-col-fix">
                                                                <tr>
                                                                    <td width="225">Institución</td>
                                                                    <%--<td class="linea_inferior">
                                                                        <asp:DropDownList ID="ddlInstitucion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged" CssClass="form-control input-sm">
                                                                            <asp:ListItem>Seleccionar</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=Reg_Rendicion_Instituciones.aspx">
                                                                        <asp:ImageButton ID="btnBuscaInstitucion" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaInstitucion_Click" /></a>
                                                                    </td>--%>
                                                                    <td>
                                                                            <div class="input-group">
                                                                                <asp:DropDownList ID="ddlInstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()">
                                                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                            <div class="popupConfirmation" id="modal_institucion" style="display: none">
                                                                                <div class="modal-header header-modal">
                                                                                    <asp:LinkButton ID="lnb_close_buscar_institucion" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                                        <span aria-hidden="true">&times;</span>
                                                                                    </asp:LinkButton>
                                                                                    <h4 class="modal-title">Senainfo / Institución</h4>
                                                                                </div>
                                                                                <div>
                                                                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Banco</td>
                                                                    <td class="linea_inferior">
                                                                        <asp:TextBox ID="txtBanco" runat="server" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Cuenta Corriente</td>
                                                                    <td class="linea_inferior">
                                                                        <asp:TextBox ID="txtCuentaCorriente" runat="server" MaxLength="150" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                </tr>
                                                                <tr height="0">
                                                                    <td></td>
                                                                    <td class="linea_inferior">
                                                                        <asp:TextBox ID="txtPlazas" runat="server" ReadOnly="True" CssClass="form-control input-sm" Visible="False"></asp:TextBox>
                                                                        <asp:TextBox ID="txtCerrado" runat="server" Visible="False" CssClass="form-control input-sm">0</asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Periodo a Rendir</td>
                                                                    <td class="linea_inferior"><span style="font-size: 11px">Mes: </span>
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
                                                                        &nbsp;<span style="font-size: 11px">Año:&nbsp;</span>
                                                                        <asp:TextBox ID="txtAno" runat="server" CssClass="form-control input-sm" />
                                                                        <ajax:MaskedEditExtender ID="MaskedEditExtender75" runat="server" TargetControlID="txtAno" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />
                                                                        <asp:TextBox ID="txtNuevo" runat="server" Visible="False" CssClass="form-control input-sm">0</asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Saldo Anterior</td>
                                                                    <td class="linea_inferior">
                                                                        <asp:TextBox ID="txtSaldoAnterior" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server" FilterType="Numbers" TargetControlID="txtSaldoAnterior" />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSaldoAnterior" runat="server" ErrorMessage="Saldo Inválido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d*$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td align="center" style="width: 150px; height: 197px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnNueva" runat="server" Text="Nueva Rendición" OnClick="btnNueva_Click" Width="190px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnCierreSinMovimiento" runat="server" Text="Cierre sin movimientos" OnClick="btnCierreSinMovimiento_Click" Width="190px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnGuardar" runat="server" Text="Guardar Rendición" OnClick="btnGuardar_Click" Visible="False" Width="190px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCierre" runat="server" CssClass="texto_rojo_peque" Font-Size="Small"
                                                                            Text="Usted cerrará y Firmará<br />esta Rendición de<br />Cuentas, Confirme los<br />Datos en Pantalla"
                                                                            Visible="False" Width="190px"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrar" runat="server" Text="Cerrar/Firmar Rendición" OnClick="btnCerrar_Click" Visible="False" Width="190px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnBuscaRendicion" runat="server" Text="Buscar Rendición" OnClick="btnBuscaRendicion_Click" Width="190px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelar" runat="server" Text="Limpiar Rendición" OnClick="btnCancelar_Click" Width="190px" Visible="False" />
                                                                    </td>
                                                                </tr>
                                                               <%--<tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" Width="190px" />
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Text="Imprimir Rendición" Visible="False" Width="190px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            &nbsp;&nbsp;<br />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblInformacion" runat="server" CssClass="texto_rojo_peque" Text="La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios." Visible="False" Width="100%" Font-Size="Small"></asp:Label><br />
                                                &nbsp;
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel ID="pnlBody" runat="server" Width="100%" Visible="False" Wrap="False">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td class="titulo_form">Detalle Ingreso del Mes &nbsp;
                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnIngresos" runat="server" Text="Ver Detalle" OnClick="btnIngreso_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdIngresoResumen" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" EmptyDataText="No hay Información" ForeColor="#333333" GridLines="None"
                                                Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="TipoIngreso" HeaderText="Tipo Ingreso">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="250px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DetalleIngreso" HeaderText="Detalle Ingreso">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="350px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Total" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
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
                                            <asp:GridView ID="grdIngresoDetalles" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" EmptyDataText="No hay Información" ForeColor="#333333" GridLines="None"
                                                Visible="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaComprobante" DataFormatString="{0:d}" HeaderText="Fecha"
                                                        HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NroComprobante" HeaderText="N&#186; Comprobante">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Correlativo" HeaderText="#">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
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
                                                        <EditItemTemplate>
                                                            &nbsp;
                                                      <asp:CheckBox ID="chkNulo" runat="server" Enabled="False" ForeColor="Black" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;
                                                      <asp:CheckBox ID="chkNulo" runat="server" Checked='<%# Eval("Nulo") %>' Enabled="False" ForeColor="Black" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                                <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td width="225" class="texto_form" style="width: 284px">Total Ingresos</td>
                                        <td class="linea_inferior">
                                            <asp:TextBox ID="txtTotalIngresos" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" runat="server" FilterType="Numbers" TargetControlID="txtTotalIngresos" />
                                            <asp:RangeValidator ID="RangeValidator36" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalIngresos" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Total Disponible</td>
                                        <td class="linea_inferior">
                                            <asp:TextBox ID="txtTotalDisponible" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" runat="server" FilterType="Numbers" TargetControlID="txtTotalDisponible" />
                                            <asp:RangeValidator ID="RangeValidator39" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalDisponible" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td height="25" class="titulo_form">Detalle Egresos del Mes &nbsp;
                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnEgresos" runat="server" Text="Ver Detalle" OnClick="btnEgresos_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdEgresoResumen" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" EmptyDataText="No hay Información" Font-Names="Arial" Font-Size="11px"
                                                ForeColor="#333333" GridLines="None" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Objetivo" HeaderText="Objetivo">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="600px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Total" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
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
                                            <asp:GridView ID="grdEgresoDetalles" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" EmptyDataText="No hay Información" Font-Names="Arial" Font-Size="11px"
                                                ForeColor="#333333" GridLines="None" Visible="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaComprobante" DataFormatString="{0:d}" HeaderText="Fecha"
                                                        HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NroComprobante" HeaderText="N&#186; Comprobante">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Correlativo" HeaderText="#">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Monto" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Uso">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Uso") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Uso") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Destino">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Destino") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Destino") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Glosa" HeaderText="Glosa">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NumeroCheque" HeaderText="N&#186; Cheque">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Nulo">
                                                        <EditItemTemplate>
                                                            &nbsp;
                                        <asp:CheckBox ID="chkNulo" runat="server" Enabled="False" Font-Size="11px" ForeColor="Black" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;
                                        <asp:CheckBox ID="chkNulo" runat="server" Checked='<%# Eval("Nulo") %>' Enabled="False"
                                            Font-Size="11px" ForeColor="Black" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                                <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td width="225" class="texto_form">Total Egresos</td>
                                        <td class="linea_inferior">
                                            <asp:TextBox ID="txtTotalEgresos" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" runat="server" FilterType="Numbers" TargetControlID="txtTotalEgresos" />
                                            <asp:RangeValidator ID="RangeValidator42" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalEgresos" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form" style="width: 284px">Saldo Disponible en Cta. Cte</td>
                                        <td class="linea_inferior">
                                            <asp:TextBox ID="txtSaldoDisponible" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender45" runat="server" FilterType="Numbers" TargetControlID="txtSaldoDisponible" />
                                            <asp:RangeValidator ID="RangeValidator45" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoDisponible" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td class="titulo_form">Provisión por Indemnización</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td class="texto_form" style="width: 284px">Monto</td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtProvisionIndemnizacion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnTextChanged="txtProvisionIndemnizacion_ValueChange" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="txtProvisionIndemnizacion" runat="server" ErrorMessage="Monto Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="texto_form" style="width: 284px; height: 45px">Saldo Real<br />
                                                        (Saldo Disponible - Provisión por Indemnización)</td>
                                                    <td class="linea_inferior" style="height: 45px">
                                                        <asp:TextBox ID="txtSaldoReal" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender50" runat="server" FilterType="Numbers" TargetControlID="txtSaldoReal" />
                                                        <asp:RangeValidator ID="RangeValidator50" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoReal" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td class="titulo_form">Reintegro (Solo Término de Proyecto o Etapa)</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                                <tr>
                                                    <td height="20" class="texto_form">Numero Cheque</td>
                                                    <td>Monto</td>
                                                    <td>Año Presupuestario</td>
                                                </tr>
                                                <tr>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtNumeroCheque" runat="server" CssClass="form-control input-sm" />
                                                        <ajax:MaskedEditExtender ID="MaskedEditExtender76" runat="server" TargetControlID="txtNumeroCheque" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999" />
                                                    </td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control input-sm" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender52" runat="server" FilterType="Numbers" TargetControlID="txtMonto" />
                                                        <asp:RangeValidator ID="RangeValidator52" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtMonto" Type="Integer" MinimumValue="0" MaximumValue="999999999" />
                                                    </td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtAnoPresupuestario" runat="server" CssClass="form-control input-sm" />
                                                        <ajax:MaskedEditExtender ID="MaskedEditExtender77" runat="server" TargetControlID="txtAnoPresupuestario" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlSearch" runat="server" Height="8px" Width="100%" Visible="False" Wrap="False">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td>
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td class="texto_form" width="225">Código Institución</td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtCodInstitucion" runat="server" CssClass="form-control input-sm" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="225" class="texto_form">Institución</td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtInstitucion" runat="server" CssClass="form-control input-sm" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>AñoMes (aaaamm)</td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtAnoMes" runat="server" CssClass="form-control input-sm" />
                                                        <ajax:MaskedEditExtender ID="MaskedEditExtender84" runat="server" TargetControlID="txtAnoMes" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="center" style="width: 135px">
                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="88px" />
                                            <br />
                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnLimpiaBusqueda" runat="server" OnClick="btnLimpiaBusqueda_Click" Text="Limpiar" Width="88px" />
                                            <br />
                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelarBusqueda" runat="server" OnClick="btnCancelarBusqueda_Click" Text="Cancelar" Width="88px" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="grdBuscador" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No hay Información" ForeColor="#333333" GridLines="None" Width="100%" OnRowEditing="grdBuscador_RowEditing">
                                    <Columns>
                                        <asp:BoundField DataField="CodInstitucion" HeaderText="CodInstitucion">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Institucion" HeaderText="Nombre Institucion">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AnoMes" HeaderText="A&#241;o Mes (aaaamm)">
                                            <ItemStyle Font-Bold="False" Font-Size="11px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MontoReintegro" HeaderText="Monto Reintegro">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Cerrado">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCerrado" runat="server" Checked='<%# Eval("Cerrado") %>' Enabled="False" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar">
                                            <ItemStyle Font-Size="11px" ForeColor="Red" HorizontalAlign="Right" />
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
                            </asp:Panel>
                            <asp:Panel ID="pnlDeudas" runat="server" Height="50px" Width="100%" Visible="False">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td class="titulo_form">
                                            <span style="text-decoration: underline">ANEXO</span>:
                                            Deudas por pagar</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlDetalleDeudas" runat="server" Visible="False" Width="100%"
                                                Wrap="False">
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td>
                                                            <table class="table table-borderless table-condensed table-col-fix">
                                                                <tr>
                                                                    <td>
                                                                        <table class="table table-borderless table-condensed table-col-fix" id="tblEditar" runat="server">
                                                                            <tr>
                                                                                <td class="texto_form" width="225">Fecha</td>
                                                                                <td class="linea_inferior">
                                                                                    <asp:TextBox ID="ddlFechaDeuda" runat="server" Text="Seleccione Fecha" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" TextMode="SingleLine" ReadOnly="false" CssClass="form-control input-sm"></asp:TextBox>
                                                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender_ddlFechaDeuda" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddlFechaDeuda" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                                                    <asp:TextBox ID="txtIdRendicionDeudas" runat="server" Visible="False" CssClass="form-control input-sm">0</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Objetivo</td>
                                                                                <td class="linea_inferior">
                                                                                    <asp:DropDownList ID="ddlObjetivo" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlObjetivo_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                    <asp:Label ID="lblObjetivo" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Uso</td>
                                                                                <td class="linea_inferior">
                                                                                    <asp:DropDownList ID="ddlUso" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlUso_SelectedIndexChanged" >
                                                                                    </asp:DropDownList>
                                                                                    &nbsp;
                                                                                    <asp:Label ID="lblUso" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Monto</td>
                                                                                <td class="linea_inferior">

                                                                                    <asp:TextBox ID="txtMontoDeuda" runat="server" CssClass="form-control input-sm" />
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator22" Enabled="true" ControlToValidate="txtMontoDeuda" runat="server" ErrorMessage="Monto Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                <asp:Label ID="lblMontoDeuda" runat="server" ForeColor="Red" Text="Debe Ingresar un valor mayor a cero"
                                                                    Visible="False" Width="216px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Pagada?</td>
                                                                                <td class="linea_inferior">
                                                                                    <asp:RadioButtonList ID="rbPagada" runat="server" Font-Size="11px" Height="8px" RepeatDirection="Horizontal"
                                                                                        Width="128px">
                                                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                                    </asp:RadioButtonList></td>
                                                                            </tr>
                                                                        </table>
                                                                        <br />
                                                                    </td>
                                                                    <td align="center" style="width: 133px">
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnGuardaDeuda" runat="server" Text="Guardar Deuda" Width="128px" OnClick="btnGuardaDeuda_Click" />
                                                                        <br />
                                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelaDeuda" runat="server" OnClick="btnCancelaDeuda_Click" Text="Cancelar" Width="128px" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnIngresoDeudas" runat="server" Text="Ingresar Deudas" OnClick="btnIngresoDeudas_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdDeudas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="grdDeudas_RowEditing"
                                                Width="70%">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="FechaDeuda" DataFormatString="{0:d}" HeaderText="Fecha"
                                                        HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Objetivo" HeaderText="Objetivo">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Uso" HeaderText="Uso" />
                                                    <asp:BoundField DataField="Monto" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="5px" />
                                                    </asp:BoundField>
                                                    <asp:CommandField DeleteText="Borrar" EditText="Modificar" InsertVisible="False"
                                                        ShowEditButton="True" ShowHeader="True">
                                                        <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                    </asp:CommandField>
                                                    <asp:BoundField DataField="CodObjetivo">
                                                        <ItemStyle Font-Size="0pt" ForeColor="White" Width="0%" Wrap="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CodUso">
                                                        <ItemStyle Font-Size="0pt" ForeColor="White" Width="0%" Wrap="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdRendicionDeudas">
                                                        <ItemStyle Font-Size="0pt" ForeColor="White" Width="0%" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                                    ForeColor="White" HorizontalAlign="Left" />
                                                <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                            </asp:GridView>
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td width="225" class="texto_form">Total Deudas por pagar</td>
                                                    <td class="linea_inferior">
                                                        <asp:TextBox ID="txtTotalDeudas" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender57" runat="server" FilterType="Numbers" TargetControlID="txtTotalDeudas" />
                                                        <asp:RangeValidator ID="RangeValidator57" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalDeudas" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                                        <asp:TextBox ID="txtDeudaAnterior" runat="server" ReadOnly="True" CssClass="form-control input-sm" Visible="False" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" FilterType="Numbers" TargetControlID="txtDeudaAnterior" />
                                                        <asp:RangeValidator ID="RangeValidator60" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtDeudaAnterior" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlMessageBox" runat="server" Height="50px" Visible="False" Width="100%">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td align="center">
                                           <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 50px; background-color: #066CB7; border-right-color: gray; border-bottom-style: double">
                                                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Text="Label" Width="98%" ForeColor="White"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 53px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnAnular" runat="server" OnCommand="btn_MessageBox" Text="Anular" Visible="False" Width="88px" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnReintentar" runat="server" OnCommand="btn_MessageBox" Text="Reintentar" Visible="False" Width="88px" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnOmitir" runat="server" OnCommand="btn_MessageBox" Text="Omitir" Visible="False" Width="88px" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnAceptar" runat="server" Text="Aceptar" Visible="False" Width="88px" OnClick="btnAceptar_Click" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelar2" runat="server" OnCommand="btn_MessageBox" Text="Cancelar" Visible="False" Width="88px" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnSi" runat="server" OnCommand="btn_MessageBox" Text="Si" Visible="False" Width="88px" OnClick="btnSi_Click" />
                                                        <asp:Button CssClass="btn btn-info btn-sm" ID="btnNo" runat="server" OnCommand="btn_MessageBox" Text="No" Visible="False" Width="88px" />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 53px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td></td>
                                                                <td>
                                                                    <asp:Label ID="lblFirma" runat="server" ForeColor="Red" Text="Debe seleccionar Quien Firma el Documento"
                                                                        Visible="False" Width="216px"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Seleccione quien firma el Documento</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlFirma" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                        Width="350px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 53px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblPreguntaCGR" runat="server" Text="¿En el mes de <...> su Institución está siendo objeto de revisión por parte de la Contraloría u otro ente fiscalizador?"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rdb_contraloria" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 53px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                        <asp:Panel ID="pnlProvisionIndemnizacion" runat="server" Visible="False" Width="100%">
                                                            Si el monto de la Provisión por Indemnización no corresponde lo puede modificar aquí:
                                                            <asp:TextBox ID="txtProvisionIndemnizacionCierre" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnTextChanged="txtProvisionIndemnizacionCierre_ValueChange" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender62" runat="server" FilterType="Numbers" TargetControlID="txtProvisionIndemnizacionCierre" />
                                                              <asp:RangeValidator ID="RangeValidator62" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtProvisionIndemnizacionCierre" Type="Integer" MinimumValue="0" MaximumValue="999999999" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
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