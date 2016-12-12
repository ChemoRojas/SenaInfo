<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="coord_historiconino_audiencia .aspx.cs" Inherits="mod_coordinadores_coord_historiconino_audiencia_" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Historico de Niños(as) y/o Jovenes</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <link href="../css/Estilo.css" rel="stylesheet" type="text/css" />
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

                    </td>

                </tr>

                <tr>

                            <asp:GridView ID="ugrd001" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="ugrd001_PageIndexChanging" OnRowDataBound="ugrd001_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="CodTipoAudiencia" HeaderText="COD. TIPO AUDIENCIA" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" />
                                    <asp:BoundField DataField="ResolucionTribunal" HeaderText="RESOLUCION TRIBUNAL" />
                                    <asp:BoundField DataField="FechaAudiencia" HeaderText="FECHA AUDIENCIA" />
                                </Columns>
                                 <PagerTemplate>
                Página 
                <asp:DropDownList ID="paginasDropDownList" Font-Size="12px" AutoPostBack="true" OnSelectedIndexChanged="GoPage" runat="server"></asp:DropDownList>
                de
                <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                &nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" CommandName="Page" ToolTip="Prim. Pag"  CommandArgument="First" CssClass="pagfirst" />                    
                <asp:Button ID="Button1" runat="server" CommandName="Page" ToolTip="Pág. anterior"  CommandArgument="Prev" CssClass="pagprev" />
                <asp:Button ID="Button2" runat="server" CommandName="Page" ToolTip="Sig. página" CommandArgument="Next" CssClass="pagnext" />                    
                <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="Últ. Pag"  CommandArgument="Last" CssClass="paglast" />
           </PagerTemplate>
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

