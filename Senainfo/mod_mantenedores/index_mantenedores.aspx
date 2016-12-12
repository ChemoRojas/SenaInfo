<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index_mantenedores.aspx.cs" Inherits="Mantenedores_index_mantenedores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="titulo_form">&nbsp;Mantenedores</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="350">
                                    <asp:TextBox ID="txt_buscar" runat="server" Width="350px"></asp:TextBox>&nbsp;&nbsp;              </td>
                                <td>
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_buscar" runat="server" Text="Buscar" OnClick="btn_buscar_Click"  />
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grd001" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="15" OnPageIndexChanging="grd001_PageIndexChanging" OnRowCommand="grd001_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="IdTabla" HeaderText="Id">
                                    <ItemStyle Font-Size="11px" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Nombre Mantenedor">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:ButtonField Text="Ver" CommandName="Ver">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" HorizontalAlign="Center" Width="50px" />
                                </asp:ButtonField>
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
        </div>
    </form>
</body>
</html>
