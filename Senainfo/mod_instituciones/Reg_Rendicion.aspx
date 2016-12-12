<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Reg_Rendicion.aspx.cs" Inherits="mod_instituciones_Reg_Rendicion" %>

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
    <title>Rendición de Cuentas :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
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
            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A3" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Rendición de Cuentas</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Rendición de Cuentas</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlHeader" runat="server" Visible="true" Width="100%" Wrap="False">
                                                    <table class="table table-borderless table-condensed table-col-fix">
                                                        <tr>
                                                            <td>
                                                                <table class="table table-borderless table-condensed table-col-fix">
                                                                    <tr>
                                                                        <td width="225" class="texto_form">Institución</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlInstitucion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged" CssClass="form-control input-sm">
                                                                                <asp:ListItem>Seleccionar</asp:ListItem>
                                                                            </asp:DropDownList>&nbsp;
                                                                            <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=Reg_Rendicion.aspx">
                                                                                <asp:ImageButton ID="btnBuscaInstitucion" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaInstitucion_Click" /></a></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Proyecto</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged">
                                                                                <asp:ListItem>Seleccionar</asp:ListItem>
                                                                            </asp:DropDownList>&nbsp;
                                                                            <a id="A2" runat="server" class="ifancybox" href="bsc_institucion.aspx?param001=Busca Proyectos&dir=Reg_Rendicion.aspx">
                                                                                <asp:ImageButton ID="btnBuscaProyecto" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaProyecto_Click" /></a></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Banco</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtBanco" runat="server" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Cuenta Corriente</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCuentaCorriente" runat="server" MaxLength="150" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Plazas</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPlazas" runat="server" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <asp:TextBox ID="txtCerrado" runat="server" Visible="False" Width="30px" Font-Size="11px">0</asp:TextBox>
                                                                            <asp:TextBox ID="txtRutNumeroProyecto" runat="server" Visible="False" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Periodo a Rendir</td>
                                                                        <td><span style="font-size: 11px">Mes: </span>
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
                                                                            <asp:TextBox ID="txtAno" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                            <ajax:MaskedEditExtender ID="MaskedEditExtender60" runat="server" TargetControlID="txtAno" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />
                                                                            <asp:TextBox ID="txtNuevo" runat="server" Visible="False" CssClass="form-control input-sm">0</asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="texto_form">Saldo Anterior</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSaldoAnterior" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers" TargetControlID="txtSaldoAnterior" />
                                                                            <asp:RangeValidator ID="RangeValidator2" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoAnterior" Type="Integer" MaximumValue="999999999" MinimumValue="0" Font-Bold="True" ForeColor="Red" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="center" style="width: 150px; height: 197px">
                                                                <table class="table table-borderless table-condensed table-col-fix">
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
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnBuscaRendicion" runat="server" Text="Buscar Rendición" OnClick="btnBuscaRendicion_Click" Width="190px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td rowspan="" width="190" align="center">
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnGuardar" runat="server" Text="Guardar Rendición" OnClick="btnGuardar_Click" Visible="False" Width="190px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblCierre" runat="server" CssClass="texto_rojo_peque" Font-Size="Small"
                                                                                Text="Usted cerrará y Firmará<br />esta Rendición de<br />Cuentas, Confirme los<br />Datos en Pantalla"
                                                                                Visible="False" Width="191px" Height="78px" EnableTheming="True"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnCerrar" runat="server" Text="Cerrar/Firmar Rendición" OnClick="btnCerrar_Click" Visible="False" Width="190px" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelar" runat="server" Text="Limpiar Rendición" OnClick="btnCancelar_Click" Width="190px" Visible="False" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Text="Imprimir Rendición" Visible="False" Width="190px" />
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr>
                                                                        <td>
                                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" Width="190px" />
                                                                        </td>
                                                                    </tr>--%>
                                                                </table>
                                                                &nbsp;
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
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers" TargetControlID="txtTotalIngresos" />
                                                <asp:RangeValidator ID="RangeValidator5" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalIngresos" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Total Disponible</td>
                                            <td class="linea_inferior">
                                                <asp:TextBox ID="txtTotalDisponible" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers" TargetControlID="txtTotalDisponible" />
                                                <asp:RangeValidator ID="RangeValidator8" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalDisponible" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
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
                                                         <asp:CheckBox ID="chkNulo" runat="server" Checked='<%# Eval("Nulo") %>' Enabled="False" Font-Size="11px" ForeColor="Black" />
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
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterType="Numbers" TargetControlID="txtTotalEgresos" />
                                                <asp:RangeValidator ID="RangeValidator11" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalEgresos" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form" style="width: 284px">Saldo Disponible en Cta. Cte</td>
                                            <td class="linea_inferior">

                                                <asp:TextBox ID="txtSaldoDisponible" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" FilterType="Numbers" TargetControlID="txtSaldoDisponible" />
                                                <asp:RangeValidator ID="RangeValidator14" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoDisponible" Type="Integer" MaximumValue="999999999" MinimumValue="0" />


                                            </td>
                                        </tr>
                                    </table>
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <td class="titulo_form">Provisión por Indemnización</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                                    <tr>
                                                        <td class="texto_form" style="width: 284px">Monto</td>
                                                        <td class="linea_inferior">

                                                            <asp:TextBox ID="txtProvisionIndemnizacion" runat="server" AutoPostBack="True" OnTextChanged="txtProvisionIndemnizacion_ValueChange" CssClass="form-control input-sm" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" FilterType="Numbers" TargetControlID="txtProvisionIndemnizacion" />
                                                            <asp:RangeValidator ID="RangeValidator16" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtProvisionIndemnizacion" Type="Integer" MinimumValue="0" MaximumValue="999999999" />


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form" style="width: 284px; height: 45px">
                                                            Saldo Real<br />
                                                            (Saldo Disponible - Provisión por Indemnización)</td>
                                                        <td class="linea_inferior" style="height: 45px">
                                                            <asp:TextBox ID="txtSaldoReal" runat="server" ReadOnly="True" CssClass="form-control input-sm" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" FilterType="Numbers" TargetControlID="txtSaldoReal" />
                                                            <asp:RangeValidator ID="RangeValidator19" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtSaldoReal" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
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
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td height="20" class="texto_form">Numero Cheque</td>
                                                        <td class="texto_form">Monto</td>
                                                        <td class="texto_form">Año Presupuestario</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtNumeroCheque" runat="server" CssClass="form-control input-sm" />
                                                            <ajax:MaskedEditExtender ID="MaskedEditExtender61" runat="server" TargetControlID="txtNumeroCheque" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999" />
                                                        </td>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control input-sm" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" FilterType="Numbers" TargetControlID="txtMonto" />
                                                            <asp:RangeValidator ID="RangeValidator21" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtMonto" Type="Integer" MinimumValue="0" MaximumValue="999999999" />
                                                        </td>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtAnoPresupuestario" runat="server" CssClass="form-control input-sm" />
                                                            <ajax:MaskedEditExtender ID="MaskedEditExtender62" runat="server" TargetControlID="txtAnoPresupuestario" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999" />
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
                                                        <td width="225" class="texto_form">Institución</td>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtInstitucion" runat="server" CssClass="form-control input-sm" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Código Proyecto</td>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtCodProyecto" runat="server" CssClass="form-control input-sm" />
                                                            <ajax:MaskedEditExtender ID="MaskedEditExtender66" runat="server" TargetControlID="txtCodProyecto" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999999999" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">Proyecto</td>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtProyecto" runat="server" CssClass="form-control input-sm" />
                                                            <ajax:MaskedEditExtender ID="MaskedEditExtender68" runat="server" TargetControlID="txtProyecto" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="texto_form">AñoMes (aaaamm)</td>
                                                        <td class="linea_inferior">
                                                            <asp:TextBox ID="txtAnoMes" runat="server" CssClass="form-control input-sm" />
                                                            <ajax:MaskedEditExtender ID="MaskedEditExtender70" runat="server" TargetControlID="txtAnoMes" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999" />
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
                                                                                        <asp:TextBox ID="ddlFechaDeuda" runat="server" Text="Seleccione Fecha" Font-Bold="False" Font-Italic="False" Font-Overline="False" ont-Strikeout="False" TextMode="SingleLine" ReadOnly="false" CssClass="form-control input-sm"></asp:TextBox>
                                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender_ddlFechaDeuda" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="ddlFechaDeuda" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="ddlFechaDeuda" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />

                                                                                        <asp:TextBox ID="txtIdRendicionDeudas" runat="server" Visible="False" CssClass="form-control input-sm">0</asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="texto_form">Objetivo</td>
                                                                                    <td class="linea_inferior">
                                                                                        <asp:DropDownList ID="ddlObjetivo" runat="server" AutoPostBack="True" Font-Names="Arial" OnSelectedIndexChanged="ddlObjetivo_SelectedIndexChanged" CssClass="form-control input-sm">
                                                                                        </asp:DropDownList>
                                                                                        &nbsp;
                                                                                          <asp:Label ID="lblObjetivo" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="texto_form">Uso</td>
                                                                                    <td class="linea_inferior">
                                                                                        <asp:DropDownList ID="ddlUso" runat="server" AutoPostBack="True" Font-Names="Arial" OnSelectedIndexChanged="ddlUso_SelectedIndexChanged" CssClass="form-control input-sm">
                                                                                        </asp:DropDownList>
                                                                                        &nbsp;
                                                                                      <asp:Label ID="lblUso" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="texto_form">Monto</td>
                                                                                    <td class="linea_inferior">

                                                                                        <asp:TextBox ID="txtMontoDeuda" runat="server" CssClass="form-control input-sm" />
                                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" FilterType="Numbers" TargetControlID="txtMontoDeuda" />
                                                                                        <asp:RangeValidator ID="RangeValidator23" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtMontoDeuda" Type="Integer" MinimumValue="0" MaximumValue="999999999" />


                                                                                        &nbsp; &nbsp;
                                                                                        <asp:Label ID="lblMontoDeuda" runat="server" ForeColor="Red" Text="Debe Ingresar un valor mayor a cero" Visible="False" Width="216px"></asp:Label></td>
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
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" FilterType="Numbers" TargetControlID="txtTotalDeudas" />
                                                            <asp:RangeValidator ID="RangeValidator26" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtTotalDeudas" Type="Integer" MaximumValue="999999999" MinimumValue="0" />



                                                            <asp:TextBox ID="txtDeudaAnterior" runat="server" ReadOnly="True" CssClass="form-control input-sm" Visible="False" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server" FilterType="Numbers" TargetControlID="txtDeudaAnterior" />
                                                            <asp:RangeValidator ID="RangeValidator29" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtDeudaAnterior" Type="Integer" MaximumValue="999999999" MinimumValue="0" />


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
                                            <td align="center" style="width: 1851px">
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 50px; background-color: #066CB7; border-right-color: gray; border-bottom-style: double">
                                                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Text="Label" Width="98%" ForeColor="White"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 1851px">
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 53px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnAnular" runat="server" OnCommand="btn_MessageBox" Text="Anular" Visible="False" Width="88px" />
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnReintentar" runat="server" OnCommand="btn_MessageBox" Text="Reintentar" Visible="False" Width="88px" />
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnOmitir" runat="server" OnCommand="btn_MessageBox" Text="Omitir" Visible="False" Width="88px" />
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnAceptar" runat="server" Text="Aceptar" Visible="False" Width="88px" OnClick="btnAceptar_Click" />
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnCancelar2" runat="server" OnCommand="btn_MessageBox" Text="Cancelar" Visible="False" Width="88px" />
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnSi" runat="server" OnCommand="btn_MessageBox" Text="Si" Visible="False" Width="88px" />
                                                            <asp:Button CssClass="btn btn-info btn-sm" ID="btnNo" runat="server" OnCommand="btn_MessageBox" Text="No" Visible="False" Width="88px" />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 20px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                            <asp:Panel ID="pnlFirma" runat="server" Visible="False" Width="100%">
                                                                <table class="table table-borderless table-condensed table-col-fix">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:Label ID="lblFirma" runat="server" ForeColor="Red" Text="Debe seleccionar Quien Firma el Documento"
                                                                                Visible="False" Width="216px"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Seleccione quien firma el Documento</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlFirma" runat="server" Font-Names="Arial" CssClass="form-control input-sm">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </asp:Panel>
                                                            &nbsp;</td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="2" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 20px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                            <asp:Panel ID="pnlPreguntaCGR" runat="server" Width="100%">
                                                                <table class="table table-borderless table-condensed table-col-fix">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblPreguntaCGR" runat="server" Text="¿En el mes de <...> su proyecto está siendo objeto de revisión por parte de la Contraloría u otro ente fiscalizador?"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rdb_contraloria" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="border-left-color: gray; border-bottom-color: gray; border-top-style: double; border-top-color: gray; border-right-style: double; border-left-style: double; height: 20px; background-color: #eeeeee; border-right-color: gray; border-bottom-style: double">
                                                            <asp:Panel ID="pnlProvisionIndemnizacion" runat="server" Visible="False" Width="100%">
                                                                Si el monto de la Provisión por Indemnización no corresponde lo puede modificar aquí:
                                                                <asp:TextBox ID="txtProvisionIndemnizacionCierre" runat="server" AutoPostBack="True" OnTextChanged="txtProvisionIndemnizacionCierre_ValueChange" CssClass="form-control input-sm" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server" FilterType="Numbers" TargetControlID="txtProvisionIndemnizacionCierre" />
                                                                <asp:RangeValidator ID="RangeValidator31" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtProvisionIndemnizacionCierre" Type="Integer" MinimumValue="0" MaximumValue="999999999" />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
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