<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="busca_proyectosNuevaLey.aspx.cs"
    Inherits="mod_coordinadores_busca_proyectosNuevaLey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buscador Proyectos</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <table width="755px" border="0" cellpadding="1" cellspacing="1">
                <tr>
                    <td class="titulo_form" height="22px">&nbsp;Buscador Proyectos</td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>


                                <asp:Panel ID="pnl001" runat="server" Width="100%">
                                    <table width="100%" border="0" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <td width="200" class="texto_form">
                                                <asp:Label ID="lbl002" runat="server" Text="Código Institución"></asp:Label></td>
                                            <td bgcolor="#ffffff">
                                                <asp:TextBox ID="txt001" runat="server" Width="150px" Font-Size="11px"></asp:TextBox>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton1_Click" />
                                                <br />
                                                <asp:DropDownList ID="ddown003" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged"
                                                    Visible="False" Width="500px" Font-Size="11px">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">
                                                <asp:Label ID="lbl0016" runat="server" Text="Nombre del Proyecto"></asp:Label></td>
                                            <td bgcolor="#ffffff">
                                                <asp:TextBox ID="txt0011" runat="server" Width="490px" Font-Size="11px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">
                                                <asp:Label ID="lbl0017" runat="server" Text="Código del Proyecto"></asp:Label></td>
                                            <td bgcolor="#ffffff">
                                                <asp:TextBox ID="txt0012" runat="server" Width="150px" Font-Size="11px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">
                                                <asp:Label ID="lbl0018" runat="server" Text="Medida"></asp:Label></td>
                                            <td bgcolor="#ffffff">
                                                <asp:DropDownList ID="ddown002" runat="server" Width="350px" Font-Size="11px">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center">

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb001" runat="server" Text="Buscar" OnClick="imb001_Click"  />
                                    &nbsp;
                                 
                                     <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb002" runat="server" Text="Limpiar" OnClick="imb002_Click"  />
                                    &nbsp;
                                    
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb003" runat="server" Text="Cerrar" OnClick="imb003_Click"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lbl0013" runat="server" Font-Size="XX-Large" ForeColor="#0253B7" Text="0"
                                        Visible="False"></asp:Label><br />
                                    <asp:Label ID="lbl0014" runat="server" Font-Size="Small" ForeColor="#0253B7" Text="Coincidencias"
                                        Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 15px">
                                    <asp:LinkButton ID="lbl0015" runat="server" OnClick="lnkbtnver_Click" Visible="False">Ver Resultados</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" Visible="False"
                                        AllowPaging="True" Width="100%" OnRowCommand="grd001_rowcommand" OnPageIndexChanging="grd001_PageIndexChanging"
                                        CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:BoundField DataField="CodInstitucion" HeaderText="C&#243;digo Instituci&#243;n">
                                                <ItemStyle HorizontalAlign="Center" Font-Size="11px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto">
                                                <ItemStyle HorizontalAlign="Center" Font-Size="11px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TipoProyecto" HeaderText="Tipo Proyecto">
                                                <ItemStyle HorizontalAlign="Center" Font-Size="11px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Proyecto">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="11px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodSistemaAsistencial" HeaderText="Sistema Asistencial"
                                                Visible="False"></asp:BoundField>
                                            <asp:ButtonField Text="Ver" CommandName="V">
                                                <ItemStyle HorizontalAlign="Center" Font-Size="11px" ForeColor="Red"></ItemStyle>
                                            </asp:ButtonField>
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
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
