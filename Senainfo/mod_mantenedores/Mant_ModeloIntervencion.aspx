﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_ModeloIntervencion.aspx.cs" Inherits="Mant_ModeloIntervencion" %>




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
                    <td class="titulo_form">Mantenedor de Medio de Pago </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="350">
                                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="11px" Width="350px"></asp:TextBox></td>
                                <td>
                                    <asp:ImageButton ID="ImageButton4"
                                        runat="server" ImageUrl="~/Images/Botones/buscar2.gif" OnClick="ImageButton4_Click" />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CodModeloIntervencion" DataSourceID="SqlDataSource1"
                            EmptyDataText="No hay registros de datos para mostrar." Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="CodModeloIntervencion" HeaderText="CodModeloIntervencion"
                                    ReadOnly="True" SortExpression="CodModeloIntervencion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="CreaPlanIntervencion" HeaderText="PlanInterv"
                                    SortExpression="CreaPlanIntervencion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="CreaInformeDiagnostico" HeaderText="InfDiagnos"
                                    SortExpression="CreaInformeDiagnostico">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:BoundField DataField="Nemotecnico" HeaderText="Nemotecnico" SortExpression="Nemotecnico">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CantidadIntervenciones" HeaderText="CantidadIntervenciones"
                                    SortExpression="CantidadIntervenciones">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IndVigencia">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3"
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
                            DeleteCommand="DELETE FROM [parModeloIntervencion] WHERE [CodModeloIntervencion] = @CodModeloIntervencion"
                            InsertCommand="INSERT INTO [parModeloIntervencion] ([Descripcion], [CreaPlanIntervencion], [CreaInformeDiagnostico], [IndVigencia], [Nemotecnico], [CantidadIntervenciones]) VALUES (@Descripcion, @CreaPlanIntervencion, @CreaInformeDiagnostico, @IndVigencia, @Nemotecnico, @CantidadIntervenciones)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodModeloIntervencion], [Descripcion], [CreaPlanIntervencion], [CreaInformeDiagnostico], [IndVigencia], [Nemotecnico], [CantidadIntervenciones] FROM [parModeloIntervencion] WHERE ([Descripcion] LIKE '%' + @Descripcion + '%')"
                            UpdateCommand="UPDATE [parModeloIntervencion] SET [Descripcion] = @Descripcion, [CreaPlanIntervencion] = @CreaPlanIntervencion, [CreaInformeDiagnostico] = @CreaInformeDiagnostico, [IndVigencia] = @IndVigencia, [Nemotecnico] = @Nemotecnico, [CantidadIntervenciones] = @CantidadIntervenciones WHERE [CodModeloIntervencion] = @CodModeloIntervencion">
                            <DeleteParameters>
                                <asp:Parameter Name="CodModeloIntervencion" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="CreaPlanIntervencion" Type="Boolean" />
                                <asp:Parameter Name="CreaInformeDiagnostico" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="CantidadIntervenciones" Type="Byte" />
                                <asp:Parameter Name="CodModeloIntervencion" Type="Int16" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBox1" Name="Descripcion" PropertyName="Text"
                                    Type="String" />
                            </SelectParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="CreaPlanIntervencion" Type="Boolean" />
                                <asp:Parameter Name="CreaInformeDiagnostico" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="CantidadIntervenciones" Type="Byte" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CodModeloIntervencion" DataSourceID="SqlDataSource2"
                            EmptyDataText="No hay registros de datos para mostrar." CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar" InsertText="Insertar" NewText="Nuevo" SelectText="Seleccionar" UpdateText="Actualizar">
                                    <ItemStyle Font-Size="11px" ForeColor="Red" />
                                </asp:CommandField>
                                <asp:BoundField DataField="CodModeloIntervencion" HeaderText="CodModeloIntervencion"
                                    ReadOnly="True" SortExpression="CodModeloIntervencion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="CreaPlanIntervencion" HeaderText="PlanInterv"
                                    SortExpression="CreaPlanIntervencion">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="CreaInformeDiagnostico" HeaderText="InfDiagnos"
                                    SortExpression="InfDiagnos">
                                    <ItemStyle Font-Size="11px" />
                                </asp:CheckBoxField>
                                <asp:BoundField DataField="Nemotecnico" HeaderText="Nemotecnico" SortExpression="Nemotecnico">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CantidadIntervenciones" HeaderText="CantidadIntervenciones"
                                    SortExpression="CantidadIntervenciones">
                                    <ItemStyle Font-Size="11px" />
                                </asp:BoundField>
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
                            DeleteCommand="DELETE FROM [parModeloIntervencion] WHERE [CodModeloIntervencion] = @CodModeloIntervencion"
                            InsertCommand="INSERT INTO [parModeloIntervencion] ([Descripcion], [CreaPlanIntervencion], [CreaInformeDiagnostico], [IndVigencia], [Nemotecnico], [CantidadIntervenciones]) VALUES (@Descripcion, @CreaPlanIntervencion, @CreaInformeDiagnostico, @IndVigencia, @Nemotecnico, @CantidadIntervenciones)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT [CodModeloIntervencion], [Descripcion], [CreaPlanIntervencion], [CreaInformeDiagnostico], [IndVigencia], [Nemotecnico], [CantidadIntervenciones] FROM [parModeloIntervencion]"
                            UpdateCommand="UPDATE [parModeloIntervencion] SET [Descripcion] = @Descripcion, [CreaPlanIntervencion] = @CreaPlanIntervencion, [CreaInformeDiagnostico] = @CreaInformeDiagnostico, [IndVigencia] = @IndVigencia, [Nemotecnico] = @Nemotecnico, [CantidadIntervenciones] = @CantidadIntervenciones WHERE [CodModeloIntervencion] = @CodModeloIntervencion">
                            <DeleteParameters>
                                <asp:Parameter Name="CodModeloIntervencion" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="CreaPlanIntervencion" Type="Boolean" />
                                <asp:Parameter Name="CreaInformeDiagnostico" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="CantidadIntervenciones" Type="Byte" />
                                <asp:Parameter Name="CodModeloIntervencion" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="CreaPlanIntervencion" Type="Boolean" />
                                <asp:Parameter Name="CreaInformeDiagnostico" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="CantidadIntervenciones" Type="Byte" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RegMenMigracionConnectionString1 %>"
                            DeleteCommand="DELETE FROM [parModeloIntervencion] WHERE [CodModeloIntervencion] = @CodModeloIntervencion"
                            InsertCommand="INSERT INTO [parModeloIntervencion] ([Descripcion], [CreaPlanIntervencion], [CreaInformeDiagnostico], [IndVigencia], [Nemotecnico], [CantidadIntervenciones]) VALUES (@Descripcion, @CreaPlanIntervencion, @CreaInformeDiagnostico, @IndVigencia, @Nemotecnico, @CantidadIntervenciones)"
                            ProviderName="<%$ ConnectionStrings:RegMenMigracionConnectionString1.ProviderName %>"
                            SelectCommand="SELECT DISTINCT pD.Tabla_Descripcion, pD.Tabla_Valor FROM dbo.parModeloIntervencion AS p RIGHT OUTER JOIN dbo.parDominios AS pD ON p.IndVigencia = pD.Tabla_Valor WHERE (pD.IdTabla = 'ESTADO')"
                            UpdateCommand="UPDATE [parModeloIntervencion] SET [Descripcion] = @Descripcion, [CreaPlanIntervencion] = @CreaPlanIntervencion, [CreaInformeDiagnostico] = @CreaInformeDiagnostico, [IndVigencia] = @IndVigencia, [Nemotecnico] = @Nemotecnico, [CantidadIntervenciones] = @CantidadIntervenciones WHERE [CodModeloIntervencion] = @CodModeloIntervencion">
                            <DeleteParameters>
                                <asp:Parameter Name="CodModeloIntervencion" Type="Int16" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="CreaPlanIntervencion" Type="Boolean" />
                                <asp:Parameter Name="CreaInformeDiagnostico" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="CantidadIntervenciones" Type="Byte" />
                                <asp:Parameter Name="CodModeloIntervencion" Type="Int16" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Descripcion" Type="String" />
                                <asp:Parameter Name="CreaPlanIntervencion" Type="Boolean" />
                                <asp:Parameter Name="CreaInformeDiagnostico" Type="Boolean" />
                                <asp:Parameter Name="IndVigencia" Type="String" />
                                <asp:Parameter Name="Nemotecnico" Type="String" />
                                <asp:Parameter Name="CantidadIntervenciones" Type="Byte" />
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
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False" Wrap="False">
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
                                                <td class="texto_form">CreaPlanIntervencion</td>
                                                <td class="linea_inferior">
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Font-Size="11px" /></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">CreaInformeDiagnostico</td>
                                                <td class="linea_inferior">
                                                    <asp:CheckBox ID="CheckBox2" runat="server" Font-Size="11px" /></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">Nemotecnico</td>
                                                <td class="linea_inferior">
                                                    <asp:TextBox ID="TextBox5" runat="server" Width="50px" MaxLength="3" Font-Size="11px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">CantidadIntervenciones</td>
                                                <td class="linea_inferior">
                                                    <asp:TextBox ID="TextBox6" runat="server" Width="50px" MaxLength="3" Font-Size="11px"></asp:TextBox></td>
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
