<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reg_Rendicion.aspx.cs" Inherits="mod_instituciones_Reg_Rendicion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.fancybox-1.3.4.js"></script>

    <script language="javascript" type="text/javascript">
        function pageLoad() {
            $(".ifancybox").fancybox({
                'width': '75%',
                'height': '75%',
                'autoScale': false,
                'transitionIn': 'none',
                'transitionOut': 'none',
                'type': 'iframe'
            });
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <Triggers>
                <asp:PostBackTrigger ControlID="btnVolver" />
            </Triggers>
            <ContentTemplate>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="25" class="titulo_form">Rendicion de Cuentas</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlHeader" runat="server" Visible="true" Width="100%">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td width="225" class="texto_form">Institución</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:DropDownList ID="ddlInstitucion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged"
                                                    Width="560px" Font-Size="11px">
                                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                                </asp:DropDownList>&nbsp;
                                              <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_recepcion/Reg_Rendicion.aspx">  <asp:ImageButton ID="btnBuscaInstitucion" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaInstitucion_Click" /></a></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Proyecto</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:DropDownList ID="ddlProyecto" runat="server" Width="560px" Font-Size="11px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged">
                                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                                </asp:DropDownList>&nbsp;
                                               <a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=Reg_Rendicion.aspx"> <asp:ImageButton ID="btnBuscaProyecto" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaProyecto_Click" /></a></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Banco</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:TextBox ID="txtBanco" runat="server" ReadOnly="True" Width="450px" Font-Size="11px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Cuenta Corriente</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:TextBox ID="txtCuentaCorriente" runat="server" MaxLength="150" ReadOnly="True"
                                                    Font-Size="11px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Plazas</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:TextBox ID="txtPlazas" runat="server" ReadOnly="True" Font-Size="11px" />
                                                &nbsp; &nbsp;
                                                <asp:TextBox ID="txtCerrado" runat="server" Visible="False" Width="30px" Font-Size="11px">0</asp:TextBox>
                                                <asp:TextBox ID="txtRutNumeroProyecto" runat="server" Visible="False" Font-Size="11px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Periodo a Rendir</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <span style="font-size: 11px">Mes: </span>
                                                <asp:DropDownList ID="ddlMeses" runat="server" Width="150px" Font-Size="11px">
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
                                                <asp:TextBox ID="txtAno" runat="server" Width="48px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender282" runat="server" TargetControlID="txtAno" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />
                                                <asp:TextBox ID="txtNuevo" runat="server" Visible="False" Width="40px">0</asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Saldo Anterior</td>
                                            <td bgcolor="#ffffff" class="linea_inferior">
                                                <asp:TextBox ID="txtSaldoAnterior" runat="server" ReadOnly="True" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender108" runat="server" FilterType="Numbers" TargetControlID="txtSaldoAnterior" />
                                                <asp:RangeValidator ID="RangeValidator108" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoAnterior" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" style="width: 150px; height: 197px">
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnNueva" runat="server" Text="Nueva Rendición" OnClick="btnNueva_Click" Width="160px"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCierreSinMovimiento" runat="server" Text="Cierre sin movimientos" OnClick="btnCierreSinMovimiento_Click" Width="160px"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGuardar" runat="server" Text="Guardar Rendición" OnClick="btnGuardar_Click" Visible="False" Width="160px"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCerrar" runat="server" Text="Cerrar Rendición" OnClick="btnCerrar_Click" Visible="False" Width="160px"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnBuscaRendicion" runat="server" Text="Buscar Rendición" OnClick="btnBuscaRendicion_Click" Width="160px"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCancelar" runat="server" Text="Limpiar Rendición" OnClick="btnCancelar_Click" Width="160px" Visible="False"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" Width="160px"  />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Text="Imprimir Rendición" Visible="False" Width="160px"  />
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblInformacion" runat="server" CssClass="texto_rojo_peque" Text="La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios."
                            Visible="False" Width="100%" Font-Size="Small"></asp:Label><br />
                        &nbsp;
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlBody" runat="server" Width="100%" Visible="False">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="titulo_form">Detalle Ingreso del Mes &nbsp;
                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnIngresos" runat="server" Text="Ver Detalle" OnClick="btnIngreso_Click"  />
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
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
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
                                                <asp:CheckBox ID="chkNulo" runat="server" Checked='<%# Eval("Nulo") %>' Enabled="False"
                                                    ForeColor="Black" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
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
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td width="225" class="texto_form">Total Ingresos</td>
                                <td class="linea_inferior">
                                    <asp:TextBox ID="txtTotalIngresos" runat="server" ReadOnly="True" Width="120px" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender111" runat="server" FilterType="Numbers" TargetControlID="txtTotalIngresos" />
                                    <asp:RangeValidator ID="RangeValidator111" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalIngresos" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form">Total Disponible</td>
                                <td class="linea_inferior">
                                    <asp:TextBox ID="txtTotalDisponible" runat="server" ReadOnly="True" Width="120px" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender114" runat="server" FilterType="Numbers" TargetControlID="txtTotalDisponible" />
                                    <asp:RangeValidator ID="RangeValidator114" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalDisponible" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="25" class="titulo_form">Detalle Egresos del Mes &nbsp;
                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnEgresos" runat="server" Text="Ver Detalle" OnClick="btnEgresos_Click"  />
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
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
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
                                            <asp:BoundField DataField="Objetivo" HeaderText="Objetivo">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Uso" HeaderText="Uso">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Monto" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MedioDePago" HeaderText="Medio de Pago">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Glosa" HeaderText="Glosa">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Destino" HeaderText="Destino">
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
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
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
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td width="225" class="texto_form">Total Egresos</td>
                                <td class="linea_inferior">
                                    <asp:TextBox ID="txtTotalEgresos" runat="server" ReadOnly="True" Width="120px" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender117" runat="server" FilterType="Numbers" TargetControlID="txtTotalEgresos" />
                                    <asp:RangeValidator ID="RangeValidator117" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalEgresos" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form">Saldo Disponible en Cta. Cte</td>
                                <td class="linea_inferior">
                                    <asp:TextBox ID="txtSaldoDisponible" runat="server" ReadOnly="True" Width="120px" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender120" runat="server" FilterType="Numbers" TargetControlID="txtSaldoDisponible" />
                                    <asp:RangeValidator ID="RangeValidator120" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoDisponible" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="titulo_form">Reintegro (Solo Término de Proyecto o Etapa)</td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td height="20" class="texto_form">Numero Cheque</td>
                                            <td class="texto_form">Monto</td>
                                            <td class="texto_form">Año Presupuestario</td>
                                        </tr>
                                        <tr>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtNumeroCheque" runat="server" Width="250px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender285" runat="server" TargetControlID="txtNumeroCheque" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999" />
                                            </td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtMonto" runat="server" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender122" runat="server" FilterType="Numbers" TargetControlID="txtMonto" />
                                                <asp:RangeValidator ID="RangeValidator122" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtMonto" Type="Integer" MinimumValue="0" MaximumValue="999999999" />
                                            </td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtAnoPresupuestario" runat="server" Width="50px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender288" runat="server" TargetControlID="txtAnoPresupuestario" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlSearch" runat="server" Height="8px" Width="100%" Visible="False">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td width="225" class="texto_form">Institución</td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtInstitucion" runat="server" Width="600px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender291" runat="server" TargetControlID="txtInstitucion" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Código Proyecto</td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtCodProyecto" runat="server" Width="150px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender294" runat="server" TargetControlID="txtCodProyecto" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999999999" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Proyecto</td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtProyecto" runat="server" Width="600px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender297" runat="server" TargetControlID="txtProyecto" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">AñoMes (aaaamm)</td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtAnoMes" runat="server" Width="150px" Font-Size="11px" /><cc1:MaskedEditExtender ID="MaskedEditExtender300" runat="server" TargetControlID="txtAnoMes" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center" style="width: 135px">
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="88px"  />
                                    <br />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnLimpiaBusqueda" runat="server" OnClick="btnLimpiaBusqueda_Click" Text="Limpiar" Width="88px"  />
                                    <br />
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCancelarBusqueda" runat="server" OnClick="btnCancelarBusqueda_Click" Text="Cancelar" Width="88px"  />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grdBuscador" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" EmptyDataText="No hay Información" ForeColor="#333333" GridLines="None"
                            Width="100%" OnRowEditing="grdBuscador_RowEditing">
                            <Columns>
                                <asp:BoundField DataField="CodInstitucion" HeaderText="CodInstitucion">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Institucion" HeaderText="Nombre Institucion">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodProyecto" HeaderText="CodProyecto">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Proyecto" HeaderText="Nombre Proyecto">
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
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar"
                                    EditText="Modificar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" HorizontalAlign="Right" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlDeudas" runat="server" Height="50px" Width="100%" Visible="False">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="titulo_form">
                                    <span style="text-decoration: underline">ANEXO</span>: Deudas por pagar</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlDetalleDeudas" runat="server" Visible="False" Width="100%">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <table id="tblEditar" runat="server" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td class="texto_form" width="225">Fecha</td>
                                                                        <td class="linea_inferior">
                                                                            <asp:TextBox ID="ddlFechaDeuda" runat="server" EDITABLE="False" Width="150px" />
                                                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1289" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="ddlFechaDeuda" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="ddlFechaDeuda" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                                            <asp:TextBox ID="txtIdRendicionDeudas" runat="server" Visible="False">0</asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Objetivo</td>
                                                                        <td class="linea_inferior">
                                                                            <asp:DropDownList ID="ddlObjetivo" runat="server" AutoPostBack="True" Font-Names="Arial"
                                                                                Font-Size="11px" OnSelectedIndexChanged="ddlObjetivo_SelectedIndexChanged" Width="350px">
                                                                            </asp:DropDownList>
                                                                            &nbsp;
                                                                        <asp:Label ID="lblObjetivo" runat="server" ForeColor="Red" Text="*" Visible="False"
                                                                            Width="150px"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Uso</td>
                                                                        <td class="linea_inferior">
                                                                            <asp:DropDownList ID="ddlUso" runat="server" AutoPostBack="True" Font-Names="Arial"
                                                                                Font-Size="11px" OnSelectedIndexChanged="ddlUso_SelectedIndexChanged" Width="350px">
                                                                            </asp:DropDownList>
                                                                            &nbsp;
                                                                        <asp:Label ID="lblUso" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Monto</td>
                                                                        <td class="linea_inferior">
                                                                            <asp:TextBox ID="txtMontoDeuda" runat="server" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender124" runat="server" FilterType="Numbers" TargetControlID="txtMontoDeuda" />
                                                                            <asp:RangeValidator ID="RangeValidator124" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtMontoDeuda" Type="Integer" MinimumValue="0" MaximumValue="999999999" />
                                                                            &nbsp; &nbsp;
                                                                        <asp:Label ID="lblMontoDeuda" runat="server" ForeColor="Red" Text="Debe Ingresar un valor mayor a cero"
                                                                            Visible="False" Width="216px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Pagada?</td>
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
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGuardaDeuda" runat="server" Text="Guardar Deuda" Width="128px" OnClick="btnGuardaDeuda_Click"  />
                                                                <br />
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCancelaDeuda" runat="server" OnClick="btnCancelaDeuda_Click" Text="Cancelar" Width="128px"  />
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
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnIngresoDeudas" runat="server" Text="Ingresar Deudas" OnClick="btnIngresoDeudas_Click"  />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdDeudas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" OnRowEditing="grdDeudas_RowEditing" Width="70%">
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
                                                <ItemStyle Font-Size="0pt" ForeColor="White" Width="0%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodUso">
                                                <ItemStyle Font-Size="0pt" ForeColor="White" Width="0%" />
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
                                    <table width="70%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td width="225" class="texto_form">Total Deudas por pagar</td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtTotalDeudas" runat="server" ReadOnly="True" Width="120px" Font-Size="11px" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender127" runat="server" FilterType="Numbers" TargetControlID="txtTotalDeudas" />
                                                <asp:RangeValidator ID="RangeValidator127" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalDeudas" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                                <asp:TextBox ID="txtDeudaAnterior" runat="server" ReadOnly="True" Width="120px" Font-Size="11px" Visible="False" /><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender130" runat="server" FilterType="Numbers" TargetControlID="txtDeudaAnterior" />
                                                <asp:RangeValidator ID="RangeValidator130" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtDeudaAnterior" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlMessageBox" runat="server" Height="50px" Visible="False" Width="100%">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="center">
                                    <table border="0" cellpadding="2" cellspacing="0" width="30%">
                                        <tr>
                                            <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 50px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Text="Label" Width="98%"
                                                    ForeColor="Black"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table border="0" cellpadding="2" cellspacing="0" width="30%">
                                        <tr>
                                            <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 53px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAnular" runat="server" OnCommand="btn_MessageBox" Text="Anular" Visible="False" Width="88px"  />
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnReintentar" runat="server" OnCommand="btn_MessageBox" Text="Reintentar" Visible="False" Width="88px"  />
                                                &nbsp;<asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnOmitir" runat="server" OnCommand="btn_MessageBox" Text="Omitir" Visible="False" Width="88px"  />
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAceptar" runat="server" OnCommand="btn_MessageBox" Text="Aceptar" Visible="False" Width="88px"  />
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Webimagebutton1" runat="server" OnCommand="btn_MessageBox" Text="Cancelar" Visible="False" Width="88px"  />
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnSi" runat="server" OnCommand="btn_MessageBox" Text="Si" Visible="False" Width="88px"  />
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnNo" runat="server" OnCommand="btn_MessageBox" Text="No" Visible="False" Width="88px"  />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
         <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="UpdateProgress">
                    <img alt="Cargando" height="70" src="../images/Cursors/ajax-loader.gif" width="70" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
