<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_TipoProyecto.aspx.cs" Inherits="Default3" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Página sin título</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="titulo_form">Mantenedor de Tipo Proyecto </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="350">
                                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="11px" Width="350px"></asp:TextBox></td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Botones/buscar2.gif" OnClick="ImageButton1_Click" />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                        <tr>
                                            <td width="225" class="texto_form">Area Proyecto</td>
                                            <td class="linea_inferior">
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource4" DataTextField="Descripcion" DataValueField="CodAreaProyecto" AutoPostBack="True" Font-Size="11px" Width="350px"></asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="TipoProyecto" DataSourceID="SqlDataSource1"
                            EmptyDataText="No hay registros de datos para mostrar." Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="TipoProyecto" HeaderText="TipoProyecto" ReadOnly="True"
                                    SortExpression="TipoProyecto">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="EsApoyo" HeaderText="EsApoyo" SortExpression="EsApoyo">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="Es1385" HeaderText="Es1385" SortExpression="Es1385">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="EsAdmDirecta" HeaderText="EsAdmDirecta" SortExpression="EsAdmDirecta">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="IndVigencia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3"
                                            DataTextField="Tabla_Descripcion" DataValueField="Tabla_Valor" SelectedValue='<%# Bind("IndVigencia") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("IndVigencia") %>'></asp:Label>
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
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parTipoProyecto] WHERE [TipoProyecto] = @TipoProyecto"
                            InsertCommand="INSERT INTO [parTipoProyecto] ([TipoProyecto], [CodAreaProyecto], [Descripcion], [EsApoyo], [Es1385], [EsAdmDirecta], [IndVigencia]) VALUES (@TipoProyecto, @CodAreaProyecto, @Descripcion, @EsApoyo, @Es1385, @EsAdmDirecta, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [TipoProyecto], [CodAreaProyecto], [Descripcion], [EsApoyo], [Es1385], [EsAdmDirecta], [IndVigencia] FROM [parTipoProyecto] WHERE (([CodAreaProyecto] = @CodAreaProyecto) AND ([Descripcion] LIKE '%' + @Descripcion + '%'))"
                            UpdateCommand="UPDATE [parTipoProyecto] SET [CodAreaProyecto] = @CodAreaProyecto, [Descripcion] = @Descripcion, [EsApoyo] = @EsApoyo, [Es1385] = @Es1385, [EsAdmDirecta] = @EsAdmDirecta, [IndVigencia] = @IndVigencia WHERE [TipoProyecto] = @TipoProyecto">
                            <DeleteParameters>
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="EsApoyo" Type="Boolean" />
                                <asp:Parameter Name="Es1385" Type="Boolean" />
                                <asp:Parameter Name="EsAdmDirecta" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="CodAreaProyecto" PropertyName="SelectedValue"
                                    Type="Int16" />
                                <asp:ControlParameter ControlID="TextBox1" Name="Descripcion" PropertyName="Text"
                                    Type="String" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="EsApoyo" Type="Boolean" />
                                <asp:Parameter Name="Es1385" Type="Boolean" />
                                <asp:Parameter Name="EsAdmDirecta" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="TipoProyecto" DataSourceID="SqlDataSource2"
                            EmptyDataText="No hay registros de datos para mostrar." CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="TipoProyecto" HeaderText="TipoProyecto" ReadOnly="True"
                                    SortExpression="TipoProyecto">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="EsApoyo" HeaderText="EsApoyo" SortExpression="EsApoyo">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="Es1385" HeaderText="Es1385" SortExpression="Es1385">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="EsAdmDirecta" HeaderText="EsAdmDirecta" SortExpression="EsAdmDirecta">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="IndVigencia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3"
                                            DataTextField="Tabla_Descripcion" DataValueField="Tabla_Valor" SelectedValue='<%# Bind("IndVigencia") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("IndVigencia") %>'></asp:Label>
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
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parTipoProyecto] WHERE [TipoProyecto] = @TipoProyecto"
                            InsertCommand="INSERT INTO [parTipoProyecto] ([TipoProyecto], [CodAreaProyecto], [Descripcion], [EsApoyo], [Es1385], [EsAdmDirecta], [IndVigencia]) VALUES (@TipoProyecto, @CodAreaProyecto, @Descripcion, @EsApoyo, @Es1385, @EsAdmDirecta, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [TipoProyecto], [CodAreaProyecto], [Descripcion], [EsApoyo], [Es1385], [EsAdmDirecta], [IndVigencia] FROM [parTipoProyecto] WHERE ([CodAreaProyecto] = @CodAreaProyecto)"
                            UpdateCommand="UPDATE [parTipoProyecto] SET [CodAreaProyecto] = @CodAreaProyecto, [Descripcion] = @Descripcion, [EsApoyo] = @EsApoyo, [Es1385] = @Es1385, [EsAdmDirecta] = @EsAdmDirecta, [IndVigencia] = @IndVigencia WHERE [TipoProyecto] = @TipoProyecto">
                            <DeleteParameters>
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="EsApoyo" Type="Boolean" />
                                <asp:Parameter Name="Es1385" Type="Boolean" />
                                <asp:Parameter Name="EsAdmDirecta" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="CodAreaProyecto" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="EsApoyo" Type="Boolean" />
                                <asp:Parameter Name="Es1385" Type="Boolean" />
                                <asp:Parameter Name="EsAdmDirecta" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parTipoProyecto] WHERE [TipoProyecto] = @TipoProyecto"
                            InsertCommand="INSERT INTO [parTipoProyecto] ([TipoProyecto], [CodAreaProyecto], [Descripcion], [EsApoyo], [Es1385], [EsAdmDirecta], [IndVigencia]) VALUES (@TipoProyecto, @CodAreaProyecto, @Descripcion, @EsApoyo, @Es1385, @EsAdmDirecta, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT DISTINCT pD.Tabla_Descripcion, pD.Tabla_Valor FROM dbo.parTipoProyecto AS p RIGHT OUTER JOIN dbo.parDominios AS pD ON p.IndVigencia = pD.Tabla_Valor WHERE (pD.IdTabla = 'ESTADO')"
                            UpdateCommand="UPDATE [parTipoProyecto] SET [CodAreaProyecto] = @CodAreaProyecto, [Descripcion] = @Descripcion, [EsApoyo] = @EsApoyo, [Es1385] = @Es1385, [EsAdmDirecta] = @EsAdmDirecta, [IndVigencia] = @IndVigencia WHERE [TipoProyecto] = @TipoProyecto">
                            <DeleteParameters>
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="EsApoyo" Type="Boolean" />
                                <asp:Parameter Name="Es1385" Type="Boolean" />
                                <asp:Parameter Name="EsAdmDirecta" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="TipoProyecto" Type="Int16" />
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="EsApoyo" Type="Boolean" />
                                <asp:Parameter Name="Es1385" Type="Boolean" />
                                <asp:Parameter Name="EsAdmDirecta" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parAreasProyecto] WHERE [CodAreaProyecto] = @CodAreaProyecto"
                            InsertCommand="INSERT INTO [parAreasProyecto] ([Descripcion], [IndVigencia]) VALUES (@Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodAreaProyecto], [Descripcion], [IndVigencia] FROM [parAreasProyecto]"
                            UpdateCommand="UPDATE [parAreasProyecto] SET [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodAreaProyecto] = @CodAreaProyecto">
                            <DeleteParameters>
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodAreaProyecto" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Botones/Agregar2.gif" OnClick="ImageButton2_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" Height="88px" Width="100%" Visible="False" Wrap="False">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                            <tr>
                                                <td width="225" class="texto_form">Descripción</td>
                                                <td class="linea_inferior">
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="650px" MaxLength="200" Font-Names="Arial" Font-Size="11px" TextMode="MultiLine"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">Es Apoyo</td>
                                                <td class="linea_inferior">
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Font-Size="11px" /></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">Es 1385</td>
                                                <td class="linea_inferior">
                                                    <asp:CheckBox ID="CheckBox2" runat="server" Font-Size="11px" /></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">Es Administración Directa</td>
                                                <td class="linea_inferior">
                                                    <asp:CheckBox ID="CheckBox3" runat="server" Font-Size="11px" /></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">IndVigencia</td>
                                                <td class="linea_inferior">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" Font-Size="11px" Width="350px">
                                                        <asp:ListItem Value="V">Vigente</asp:ListItem>
                                                        <asp:ListItem Value="C">Caducado</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Botones/guardar2.gif"
                                            OnClick="ImageButton2_Click1" />
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Botones/Cancelar2.gif"
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
