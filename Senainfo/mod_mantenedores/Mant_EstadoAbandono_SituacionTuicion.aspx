<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_EstadoAbandono_SituacionTuicion.aspx.cs" Inherits="Default6" %>






<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="titulo_form">Mantenedor de Estado Abandonos y Situación Tuición </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="350">
                                    <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2"
                                        DataTextField="Descripcion" DataValueField="CodEstadoAbandono" Font-Size="11px" Width="650px">
                                        <asp:ListItem Selected="True" Value="0">&lt;Seleccione&gt;</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:ImageButton ID="ImageButton4"
                                        runat="server" ImageUrl="~/Images/Botones/buscar2.gif" OnClick="ImageButton4_Click" />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CodSituacionTuicion,CodEstadoAbandono"
                            DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." AllowPaging="True" AllowSorting="True" Visible="False" Width="100%">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="CodEstadoAbandono" HeaderText="CodEstadoAbandono" ReadOnly="True"
                                    SortExpression="CodEstadoAbandono" Visible="False">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodSituacionTuicion" HeaderText="CodSituacionTuicion"
                                    ReadOnly="True" SortExpression="CodSituacionTuicion" Visible="False">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="EstadoAbandono">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                            DataTextField="Descripcion" DataValueField="CodEstadoAbandono" SelectedValue='<%# Bind("CodEstadoAbandono") %>' Enabled="False" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" ForeColor="WindowText" EnableTheming="True" Font-Italic="False" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SituacionTuicion">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource4"
                                            DataTextField="Descripcion" DataValueField="CodSituacionTuicion" SelectedValue='<%# Bind("CodSituacionTuicion") %>' Enabled="False" ForeColor="ControlText" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="TituloColumna" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parEstadoAbandono_SituacionTuicion] WHERE [CodSituacionTuicion] = @CodSituacionTuicion AND [CodEstadoAbandono] = @CodEstadoAbandono"
                            InsertCommand="INSERT INTO [parEstadoAbandono_SituacionTuicion] ([CodSituacionTuicion], [CodEstadoAbandono]) VALUES (@CodSituacionTuicion, @CodEstadoAbandono)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodSituacionTuicion], [CodEstadoAbandono] FROM [parEstadoAbandono_SituacionTuicion] WHERE ([CodEstadoAbandono] = @CodEstadoAbandono)">
                            <DeleteParameters>
                                <asp:Parameter Name="CodSituacionTuicion" Type="Int16" />
                                <asp:Parameter Name="CodEstadoAbandono" Type="Int16" />
                            </DeleteParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList5" Name="CodEstadoAbandono" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CodSituacionTuicion" Type="Int16" />
                                <asp:Parameter Name="CodEstadoAbandono" Type="Int16" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="CodSituacionTuicion,CodEstadoAbandono"
                            DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." AllowPaging="True" AllowSorting="True" Width="100%">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="CodEstadoAbandono" HeaderText="CodEstadoAbandono" ReadOnly="True"
                                    SortExpression="CodEstadoAbandono" Visible="False">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodSituacionTuicion" HeaderText="CodSituacionTuicion"
                                    ReadOnly="True" SortExpression="CodSituacionTuicion" Visible="False">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="EstadoAbandono">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                                            DataTextField="Descripcion" DataValueField="CodEstadoAbandono" SelectedValue='<%# Bind("CodEstadoAbandono") %>' Enabled="False" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" ForeColor="ControlText" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SituacionTuicion">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource4"
                                            DataTextField="Descripcion" DataValueField="CodSituacionTuicion" SelectedValue='<%# Bind("CodSituacionTuicion") %>' Enabled="False" ForeColor="ControlText" Font-Size="11px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="TituloColumna" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parEstadoAbandono_SituacionTuicion] WHERE [CodSituacionTuicion] = @CodSituacionTuicion AND [CodEstadoAbandono] = @CodEstadoAbandono"
                            InsertCommand="INSERT INTO [parEstadoAbandono_SituacionTuicion] ([CodSituacionTuicion], [CodEstadoAbandono]) VALUES (@CodSituacionTuicion, @CodEstadoAbandono)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodSituacionTuicion], [CodEstadoAbandono] FROM [parEstadoAbandono_SituacionTuicion]" OnSelecting="SqlDataSource5_Selecting">
                            <DeleteParameters>
                                <asp:Parameter Name="CodSituacionTuicion" Type="Int16" />
                                <asp:Parameter Name="CodEstadoAbandono" Type="Int16" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CodSituacionTuicion" Type="Int16" />
                                <asp:Parameter Name="CodEstadoAbandono" Type="Int16" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parEstadoAbandono] WHERE [CodEstadoAbandono] = @CodEstadoAbandono"
                            InsertCommand="INSERT INTO [parEstadoAbandono] ([Descripcion], [Nemotecnico], [IndVigencia]) VALUES (@Descripcion, @Nemotecnico, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodEstadoAbandono], [Descripcion], [Nemotecnico], [IndVigencia] FROM [parEstadoAbandono] WHERE ([IndVigencia] = @IndVigencia)"
                            UpdateCommand="UPDATE [parEstadoAbandono] SET [Descripcion] = @Descripcion, [Nemotecnico] = @Nemotecnico, [IndVigencia] = @IndVigencia WHERE [CodEstadoAbandono] = @CodEstadoAbandono">
                            <DeleteParameters>
                                <asp:Parameter Name="CodEstadoAbandono" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodEstadoAbandono" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="V" Name="IndVigencia" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parSituacionTuicion] WHERE [CodSituacionTuicion] = @CodSituacionTuicion"
                            InsertCommand="INSERT INTO [parSituacionTuicion] ([Descripcion], [IndVigencia]) VALUES (@Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodSituacionTuicion], [Descripcion], [IndVigencia] FROM [parSituacionTuicion] WHERE (([IndVigencia] = @IndVigencia) AND 
CodSituacionTuicion not in (select CodSituacionTuicion from parEstadoAbandono_SituacionTuicion where CodEstadoAbandono = @CodEstadoAbandono))"
                            UpdateCommand="UPDATE [parSituacionTuicion] SET [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodSituacionTuicion] = @CodSituacionTuicion">
                            <DeleteParameters>
                                <asp:Parameter Name="CodSituacionTuicion" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodSituacionTuicion" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="V" Name="IndVigencia" Type="String" />
                                <asp:ControlParameter ControlID="DropDownList3" DefaultValue="" Name="CodEstadoAbandono"
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodSituacionTuicion], [Descripcion], [IndVigencia] FROM [parSituacionTuicion]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Botones/Agregar2.gif" OnClick="ImageButton2_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False" Wrap="False">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                            <tr>
                                                <td width="225" class="texto_form">Estado de Abandono</td>
                                                <td class="linea_inferior">
                                                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2"
                                                        DataTextField="Descripcion" DataValueField="CodEstadoAbandono" AutoPostBack="True" Font-Size="11px" Width="650px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">Situación Tuición</td>
                                                <td class="linea_inferior">
                                                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3"
                                                        DataTextField="Descripcion" DataValueField="CodSituacionTuicion" Font-Size="11px" Width="650px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Botones/guardar2.gif"
                                            OnClick="ImageButton2_Click1" />
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Botones/Cancelar2.gif"
                                            OnClick="ImageButton3_Click" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
