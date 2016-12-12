<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="coord_HistoricoNino_modifica.aspx.cs" Inherits="mod_mesa_mesa_HistoricoNino" %>

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


                       
                        <asp:GridView ID="ugrd001" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="fecha" HeaderText="FECHA" />
                                <asp:BoundField DataField="nombre" HeaderText="NOMBRE Y APELLIDOS" />
                                <asp:BoundField DataField="rut" HeaderText="RUT" />
                                <asp:BoundField DataField="edad" HeaderText="EDAD" />
                                <asp:BoundField DataField="sexo" HeaderText="SEXO" />
                                <asp:BoundField DataField="comuna" HeaderText="COMUNA" />
                                <asp:BoundField DataField="delito" HeaderText="DESCRIPCION DELITO" />
                                <asp:BoundField DataField="codcausalingreso" HeaderText="CÓDIGO DELITO" />
                                <asp:BoundField DataField="ruc" HeaderText="RUC" />
                                <asp:BoundField DataField="rit" HeaderText="RIT" />
                                <asp:BoundField DataField="proyecto" HeaderText="DERIVACIÓN A CENTRO O PROGRAMA SENAME" />
                                <asp:BoundField DataField="modelointervencion" HeaderText="CENTRO O PROGRAMA DE ORIGEN" />
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
                      
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Webimagebutton2" runat="server" Text="Exportar a Excel" OnClick="Webimagebutton2_Click" />

                        &nbsp;&nbsp;&nbsp; &nbsp;
                        
                     
                         <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="Cerrar" OnClick="WebImageButton1_Click" />
                    </td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
