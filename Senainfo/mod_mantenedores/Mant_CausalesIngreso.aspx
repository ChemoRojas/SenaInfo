<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_CausalesIngreso.aspx.cs" Inherits="Mant_CausalesIngreso" %>




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
                    <td class="titulo_form">Mantenedor de Causal Ingreso </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="350">
                                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="11px" Width="350px"></asp:TextBox></td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Botones/buscar2.gif" OnClick="ImageButton1_Click" />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                        <tr>
                                            <td width="225" class="texto_form">Tipo Causal Ingreso</td>
                                            <td class="linea_inferior">
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource4"
                                                    DataTextField="Descripcion" DataValueField="CodTipoCausalIngreso" AutoPostBack="True" Font-Size="11px" Width="350px">
                                                </asp:DropDownList></td>
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
                            AutoGenerateColumns="False" DataKeyNames="CodCausalIngreso" DataSourceID="SqlDataSource1"
                            EmptyDataText="No hay registros de datos para mostrar." Visible="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="CodTipoCausalIngreso">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Text='<%# Bind("CodTipoCausalIngreso") %>'
                                            Width="40px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("CodTipoCausalIngreso") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CodCausalIngreso" HeaderText="CodCausalIngreso" ReadOnly="True"
                                    SortExpression="CodCausalIngreso">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IndVigencia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3"
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
                            <EditRowStyle BackColor="#2461BF" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parCausalesIngreso] WHERE [CodCausalIngreso] = @CodCausalIngreso"
                            InsertCommand="INSERT INTO [parCausalesIngreso] ([CodTipoCausalIngreso], [Descripcion], [IndVigencia]) VALUES (@CodTipoCausalIngreso, @Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodCausalIngreso], [CodTipoCausalIngreso], [Descripcion], [IndVigencia] FROM [parCausalesIngreso] WHERE (([CodTipoCausalIngreso] = @CodTipoCausalIngreso) AND ([Descripcion] LIKE '%' + @Descripcion + '%'))"
                            UpdateCommand="UPDATE [parCausalesIngreso] SET [CodTipoCausalIngreso] = @CodTipoCausalIngreso, [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodCausalIngreso] = @CodCausalIngreso">
                            <DeleteParameters>
                                <asp:Parameter Name="CodCausalIngreso" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodCausalIngreso" Type="Int16" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="CodTipoCausalIngreso" PropertyName="SelectedValue"
                                    Type="Int16" />
                                <asp:ControlParameter ControlID="TextBox1" Name="Descripcion" PropertyName="Text"
                                    Type="String" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CodCausalIngreso" DataSourceID="SqlDataSource2"
                            EmptyDataText="No hay registros de datos para mostrar." Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="CodTipoCausalIngreso">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Enabled="False" Text='<%# Bind("CodTipoCausalIngreso") %>'
                                            Width="40px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("CodTipoCausalIngreso") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CodCausalIngreso" HeaderText="CodCausalIngreso" ReadOnly="True"
                                    SortExpression="CodCausalIngreso">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IndVigencia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3"
                                            DataTextField="Tabla_Descripcion" DataValueField="Tabla_Valor" SelectedValue='<%# Bind("IndVigencia") %>'>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("IndVigencia") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                            <EditRowStyle BackColor="#2461BF" Font-Size="11px" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parCausalesIngreso] WHERE [CodCausalIngreso] = @CodCausalIngreso"
                            InsertCommand="INSERT INTO [parCausalesIngreso] ([CodTipoCausalIngreso], [Descripcion], [IndVigencia]) VALUES (@CodTipoCausalIngreso, @Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodCausalIngreso], [CodTipoCausalIngreso], [Descripcion], [IndVigencia] FROM [parCausalesIngreso] WHERE ([CodTipoCausalIngreso] = @CodTipoCausalIngreso)"
                            UpdateCommand="UPDATE [parCausalesIngreso] SET [CodTipoCausalIngreso] = @CodTipoCausalIngreso, [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodCausalIngreso] = @CodCausalIngreso">
                            <DeleteParameters>
                                <asp:Parameter Name="CodCausalIngreso" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodCausalIngreso" Type="Int16" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="CodTipoCausalIngreso" PropertyName="SelectedValue"
                                    Type="Int16" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parCausalesIngreso] WHERE [CodCausalIngreso] = @CodCausalIngreso"
                            InsertCommand="INSERT INTO [parCausalesIngreso] ([CodTipoCausalIngreso], [Descripcion], [IndVigencia]) VALUES (@CodTipoCausalIngreso, @Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT DISTINCT pD.Tabla_Descripcion, pD.Tabla_Valor FROM dbo.parCausalesIngreso AS p RIGHT OUTER JOIN dbo.parDominios AS pD ON p.IndVigencia = pD.Tabla_Valor WHERE (pD.IdTabla = 'ESTADO')"
                            UpdateCommand="UPDATE [parCausalesIngreso] SET [CodTipoCausalIngreso] = @CodTipoCausalIngreso, [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodCausalIngreso] = @CodCausalIngreso">
                            <DeleteParameters>
                                <asp:Parameter Name="CodCausalIngreso" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodCausalIngreso" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parTipoCausalIngreso] WHERE [CodTipoCausalIngreso] = @CodTipoCausalIngreso"
                            InsertCommand="INSERT INTO [parTipoCausalIngreso] ([Descripcion], [IndVigencia], [EdadMinima]) VALUES (@Descripcion, @IndVigencia, @EdadMinima)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodTipoCausalIngreso], [Descripcion], [IndVigencia], [EdadMinima] FROM [parTipoCausalIngreso]"
                            UpdateCommand="UPDATE [parTipoCausalIngreso] SET [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia, [EdadMinima] = @EdadMinima WHERE [CodTipoCausalIngreso] = @CodTipoCausalIngreso">
                            <DeleteParameters>
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="EdadMinima" Type="Int16" />
                                <asp:Parameter Name="CodTipoCausalIngreso" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="EdadMinima" Type="Int16" />
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
                                            OnClick="ImageButton3_Click" />
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Botones/Cancelar2.gif"
                                            OnClick="ImageButton4_Click" /></td>
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
