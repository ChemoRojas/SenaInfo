<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mesa_HistoricoNino.aspx.cs" Inherits="mod_mesa_mesa_HistoricoNino" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Historico de Niños(as) y/o Jovenes</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="25" class="titulo_form">Historico de Niños(as) y/o Jovenes</td>

                </tr>
                <tr>
                    <td>
                        <%--GRILLA NUEVA JVB--%>
                        <asp:GridView ID="ugrd001" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="icodie" HeaderText="icodie">
                                <ControlStyle Height="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo" HeaderText="Código">
                                <ControlStyle Height="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Causal_Ingreso_1" HeaderText="Causal Ingreso 1">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Causal_Ingreso_2" HeaderText="Causal Ingreso 2">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Causal_Ingreso_3" HeaderText="Causal Ingreso 3">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="rut" HeaderText="Rut">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="paterno" HeaderText="Aprellido Paterno">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="materno" HeaderText="Apellido Materno">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codproyecto" HeaderText="Código Proyecto">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="proyecto" HeaderText="Proyecto">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codinst" HeaderText="Cod. Instit.">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombreints" HeaderText="Nombre Institución">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Modelo" HeaderText="Modelo">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaEgreso" HeaderText="Fecha Egreso">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Causal_Egreso" HeaderText="Causal Egreso">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Con_Quien_Egresa" HeaderText="Con Quien Egresa">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tribunal" HeaderText="Tribunal">
                                <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Expediente" HeaderText="Expediente">
                                <ControlStyle Height="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Ruc" HeaderText="Ruc"></asp:BoundField>
                                <asp:BoundField DataField="Rit" HeaderText="Rit" />
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                <asp:BoundField DataField="Comuna" HeaderText="Comuna" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>





                    </td>

                </tr>
                <tr>
                    <td align="center">&nbsp;<br />
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Webimagebutton2" runat="server" OnClick="Webimagebutton2_Click" Text="Exportar a Excel"  />


                        &nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" OnClick="WebImageButton1_Click" Text="Cerrar"  />


                    </td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
