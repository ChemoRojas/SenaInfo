<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_InstrumentoMedicion.aspx.cs" Inherits="Default3" %>




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
                    <td class="titulo_form">Mantenedor de Instrumento de Medición </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="350">
                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Descripcion" DataValueField="CodInstrumentoDiagnostico" Font-Size="11px" Width="350px"></asp:DropDownList></td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1"
                                        runat="server" ImageUrl="~/Images/Botones/buscar2.gif" OnClick="ImageButton1_Click" />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            DataKeyNames="CodInstrumentoDiagnostico,CodMedicionesDiagnosticas" DataSourceID="SqlDataSource1"
                            EmptyDataText="No hay registros de datos para mostrar." Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:CommandField ShowDeleteButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="CodInstrumentoDiagnostico" HeaderText="CodInstrumentoDiagnostico"
                                    ReadOnly="True" SortExpression="CodInstrumentoDiagnostico" Visible="False">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodMedicionesDiagnosticas" HeaderText="CodMedicionesDiagnosticas"
                                    ReadOnly="True" SortExpression="CodMedicionesDiagnosticas" Visible="False">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="InstrumentoDiagonstico">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2"
                                            DataTextField="Descripcion" DataValueField="CodInstrumentoDiagnostico" Enabled="False"
                                            SelectedValue='<%# Bind("CodInstrumentoDiagnostico") %>' Font-Size="11px">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle Font-Size="11px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MedicionesDiagnosticas">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3"
                                            DataTextField="Descripcion" DataValueField="CodMedicionesDiagnosticas" Enabled="False"
                                            SelectedValue='<%# Bind("CodMedicionesDiagnosticas") %>' Font-Size="11px">
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
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [IntrumentoMedicion] WHERE [CodInstrumentoDiagnostico] = @CodInstrumentoDiagnostico AND [CodMedicionesDiagnosticas] = @CodMedicionesDiagnosticas"
                            InsertCommand="INSERT INTO [IntrumentoMedicion] ([CodInstrumentoDiagnostico], [CodMedicionesDiagnosticas]) VALUES (@CodInstrumentoDiagnostico, @CodMedicionesDiagnosticas)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodInstrumentoDiagnostico], [CodMedicionesDiagnosticas] FROM [IntrumentoMedicion] WHERE ([CodInstrumentoDiagnostico] = @CodInstrumentoDiagnostico)">
                            <DeleteParameters>
                                <asp:Parameter Name="CodInstrumentoDiagnostico" Type="Int16" />
                                <asp:Parameter Name="CodMedicionesDiagnosticas" Type="Int16" />
                            </DeleteParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="CodInstrumentoDiagnostico"
                                    PropertyName="SelectedValue" Type="Int16" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CodInstrumentoDiagnostico" Type="Int16" />
                                <asp:Parameter Name="CodMedicionesDiagnosticas" Type="Int16" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parInstrumentosDiagnosticos] WHERE [CodInstrumentoDiagnostico] = @CodInstrumentoDiagnostico"
                            InsertCommand="INSERT INTO [parInstrumentosDiagnosticos] ([Descripcion], [IndVigencia]) VALUES (@Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodInstrumentoDiagnostico], [Descripcion], [IndVigencia] FROM [parInstrumentosDiagnosticos]"
                            UpdateCommand="UPDATE [parInstrumentosDiagnosticos] SET [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodInstrumentoDiagnostico] = @CodInstrumentoDiagnostico">
                            <DeleteParameters>
                                <asp:Parameter Name="CodInstrumentoDiagnostico" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodInstrumentoDiagnostico" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parMedicionesDiagnosticas] WHERE [CodMedicionesDiagnosticas] = @CodMedicionesDiagnosticas"
                            InsertCommand="INSERT INTO [parMedicionesDiagnosticas] ([Descripcion], [IndVigencia]) VALUES (@Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodMedicionesDiagnosticas], [Descripcion], [IndVigencia] FROM [parMedicionesDiagnosticas]"
                            UpdateCommand="UPDATE [parMedicionesDiagnosticas] SET [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodMedicionesDiagnosticas] = @CodMedicionesDiagnosticas">
                            <DeleteParameters>
                                <asp:Parameter Name="CodMedicionesDiagnosticas" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodMedicionesDiagnosticas" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parInstrumentosDiagnosticos] WHERE [CodInstrumentoDiagnostico] = @CodInstrumentoDiagnostico"
                            InsertCommand="INSERT INTO [parInstrumentosDiagnosticos] ([Descripcion], [IndVigencia]) VALUES (@Descripcion, @IndVigencia)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodInstrumentoDiagnostico], [Descripcion], [IndVigencia] FROM [parInstrumentosDiagnosticos] WHERE ([IndVigencia] = @IndVigencia)"
                            UpdateCommand="UPDATE [parInstrumentosDiagnosticos] SET [Descripcion] = @Descripcion, [IndVigencia] = @IndVigencia WHERE [CodInstrumentoDiagnostico] = @CodInstrumentoDiagnostico">
                            <DeleteParameters>
                                <asp:Parameter Name="CodInstrumentoDiagnostico" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="CodInstrumentoDiagnostico" Type="Int16" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="V" Name="IndVigencia" Type="String" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT CodMedicionesDiagnosticas, Descripcion, IndVigencia FROM parMedicionesDiagnosticas WHERE ((IndVigencia = @IndVigencia) AND 
CodMedicionesDiagnosticas not in (select CodMedicionesDiagnosticas from IntrumentoMedicion where CodInstrumentoDiagnostico = @CodInstrumentoDiagnostico))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="V" Name="IndVigencia" />
                                <asp:ControlParameter ControlID="DropDownList4" DefaultValue="" Name="CodInstrumentoDiagnostico"
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
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
                                                <td width="225" class="texto_form">Instrumento Diagnóstico</td>
                                                <td class="linea_inferior">
                                                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4"
                                                        DataTextField="Descripcion" DataValueField="CodInstrumentoDiagnostico" Font-Size="11px" Width="350px">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">Mediciones Diagnósticas</td>
                                                <td class="linea_inferior">
                                                    <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource5" DataTextField="Descripcion" DataValueField="CodMedicionesDiagnosticas" Font-Size="11px" Width="650px"></asp:DropDownList></td>
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
