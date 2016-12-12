<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IngresoPlandeIntervenciones.aspx.cs" Inherits="mod_ninos_IngresoPlandeIntervenciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>


    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function TABLE1_onclick() {

        }

        // ]]>
    </script>
</head>


<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="1" cellspacing="1" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td class="titulo_form" colspan="2">Eventos del Área de Intervención</td>
            </tr>
            <tr>
                <td class="texto_form">Plan de Intervención</td>
                <td bgcolor="#FFFFFF">
                    <asp:DropDownList ID="ddown001" runat="server" AppendDataBoundItems="True" Width="350px" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True" Font-Size="11px">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="texto_form">Niño(a)</td>
                <td bgcolor="#FFFFFF">
                    <asp:TextBox ID="txt001" runat="server" Width="350px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="texto_form">Proyecto</td>
                <td bgcolor="#FFFFFF">
                    <asp:TextBox ID="txt002" runat="server" Width="350px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="texto_form">Rut Técnico</td>
                <td>
                    <asp:TextBox ID="txt003" runat="server" Width="100px" Enabled="False"> </asp:TextBox>
                    <asp:TextBox ID="txt004" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="texto_form">Fecha Elaboración PII</td>
                <td>
                    <asp:TextBox ID="cal001" runat="server" Width="150px" />
                    <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende545" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                </td>
            </tr>
            <tr>
                <td class="texto_form">Fecha de Inicio PII</td>
                <td>
                    <asp:TextBox ID="cal002" runat="server" Width="150px" />
                    <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende556" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true"  ControlToValidate="cal002" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                </td>
            </tr>
            <tr>
                <td class="texto_form">Fecha de Término Estimada PII</td>
                <td>
                    <asp:TextBox ID="cal003" runat="server" Width="150px" />
                    <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende567" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal003" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Enabled="true"  ControlToValidate="cal003" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                </td>
            </tr>
            <tr>
                <td class="texto_form">Descripción</td>
                <td>
                    <asp:TextBox ID="txt005" runat="server" Height="50px" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="titulo_form" colspan="2">Área de Intervención</td>
            </tr>
            <tr>
                <td class="titulo_form" colspan="2">Áreas de Intervención ya definidas</td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color: #ff3300"><span id="rvAreasIntervencion" class="TextoError" controltovalidate="txtNroAreasIntervencion" errormessage="Ingrese Área de Intervención" isvalid="false" maximumvalue="100" minimumvalue="1" style="color: red" type="Integer">Ingrese Área de Intervención</span></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span id="Span2" class="TextoError" controltovalidate="txtNroAreasIntervencion" errormessage="Ingrese Área de Intervención" isvalid="false" maximumvalue="100" minimumvalue="1" style="color: red" type="Integer">
                        <asp:GridView ID="grd001" runat="server" AllowSorting="True" AutoGenerateColumns="False" Font-Size="Small" Width="100%" OnRowCommand="grd001_RowCommand1" CellPadding="4" ForeColor="#333333">
                            <Columns>
                                <asp:BoundField DataField="Tipo de Intervenci&#243;n" HeaderText="Tipo de Intervenci&#243;n">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Nivel de Intervenci&#243;n" HeaderText="Nivel de Intervenci&#243;n">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="# Eventos" DataField="# Eventos">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:ButtonField Text="Quitar">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                            <RowStyle BackColor="White" BorderColor="SteelBlue" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                        </asp:GridView>
                    </span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color: #ff3300"><span id="Span4" class="TextoError" controltovalidate="txtNroAreasIntervencion" errormessage="Ingrese Área de Intervención" isvalid="false" maximumvalue="100" minimumvalue="1" style="color: red" type="Integer">&nbsp;<span style="color: black">Tipo de Intervención</span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
			<span style="color: black">Nivel de Intervención</span></span></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="ddown003" runat="server" AppendDataBoundItems="True" Width="350px" Font-Size="11px">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:DropDownList ID="ddown004" runat="server" AppendDataBoundItems="True" Width="350px" Font-Size="11px">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <br>
                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn001" runat="server" Text="Agregar" Width="100px" OnClick="btn001_Click"  />


                </td>
            </tr>
            <tr>
                <td class="titulo_form" colspan="2">Seguimiento del Plan de Intervención</td>
            </tr>
            <tr>
                <td class="texto_form">Estado Intervención</td>
                <td>
                    <asp:DropDownList ID="ddown005" runat="server" AppendDataBoundItems="True" Width="350px" Font-Size="11px">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="texto_form">Colaboración Niño(a)</td>
                <td>
                    <asp:CheckBox ID="Chk001" runat="server" Font-Size="11px" /></td>
            </tr>
            <tr>
                <td class="texto_form">Participación Familia</td>
                <td>
                    <asp:CheckBox ID="Chk002" runat="server" Font-Size="11px" /></td>
            </tr>
            <tr>
                <td class="texto_form">Observaciones</td>
                <td>
                    <asp:TextBox ID="txt006" runat="server" Height="50px" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="titulo_form" colspan="2">Con Quien puede Trabajar el Egreso
                </td>
            </tr>
            <tr>
                <td class="titulo_form" colspan="2">Personas relacionadas con las que se puede trabajar el egreso</td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color: #ff3300"><span id="Span1" class="TextoError" controltovalidate="txtNroAreasIntervencion" errormessage="Ingrese Área de Intervención" isvalid="false" maximumvalue="100" minimumvalue="1" style="color: red" type="Integer"></span></span></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span id="Span3" class="TextoError" controltovalidate="txtNroAreasIntervencion" errormessage="Ingrese Área de Intervención" isvalid="false" maximumvalue="100" minimumvalue="1" style="color: red" type="Integer">
                        <asp:GridView ID="grd002" runat="server" AllowSorting="True" AutoGenerateColumns="False" Font-Size="Small" Width="100%" OnRowCommand="grd002_RowCommand2">
                            <Columns>
                                <asp:BoundField DataField="Persona Relacionada" HeaderText="Persona Relacionada">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Tipo de Relaci&#243;n" HeaderText="Tipo de Relaci&#243;n">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Relaci&#243;n" DataField="Fecha Relaci&#243;n">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Relaci&#243;n Vigente" DataField="Relaci&#243;n Vigente">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="T&#233;rmino Relaci&#243;n" DataField="T&#233;rmino Relaci&#243;n">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:ButtonField Text="Quitar">
                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                            <RowStyle BackColor="White" BorderColor="SteelBlue" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                        </asp:GridView>
                    </span></td>
            </tr>
            <tr>
                <td colspan="2">Persona Relacionada</td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <span style="color: #ff3300">
                        <asp:DropDownList ID="ddown006" runat="server" AppendDataBoundItems="True" Width="350px" Font-Size="11px">
                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn004" runat="server" Text="Agregar" Width="100px" OnClick="btn004_Click"  />


                    </span></td>
            </tr>
            <tr>
                <td class="titulo_form" colspan="2">Término de la Intervención</td>
            </tr>
            <tr>
                <td class="texto_form">Intervención Completa</td>
                <td>
                    <asp:DropDownList ID="ddown007" runat="server" AppendDataBoundItems="True" Width="100px" Font-Size="11px">
                        <asp:ListItem Value="true">Si</asp:ListItem>
                        <asp:ListItem Value="false">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="texto_form">Habilitado Para Egreso</td>
                <td>
                    <asp:DropDownList ID="ddown008" runat="server" AppendDataBoundItems="True" Width="100px" Font-Size="11px">
                        <asp:ListItem Value="True">Si</asp:ListItem>
                        <asp:ListItem Value="false">No</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="texto_form">Grado de Cumplimiento</td>
                <td>
                    <asp:TextBox ID="txt007" runat="server" Width="350px"></asp:TextBox>
                    <asp:Label ID="lbl001" runat="server" Text="Label" Visible="False" Width="100px" Font-Size="11px"></asp:Label></td>
            </tr>
            <tr>
                <td class="texto_form">Fecha Término Real </td>
                <td>
                    <asp:TextBox ID="cal004" runat="server" Width="150px" />
                    <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende578" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal004" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Enabled="true"  ControlToValidate="cal004" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <span style="color: #ff3300">&nbsp;</span></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <span style="color: #ff3300"><span id="Span5" class="TextoError" controltovalidate="txtNroAreasIntervencion" errormessage="Ingrese Área de Intervención" isvalid="false" maximumvalue="100" minimumvalue="1" style="color: red" type="Integer">
                        <br />
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn003" runat="server" Text="Guardar" Width="150px" OnClick="btn003_Click"  />


                    </span></span></td>
            </tr>

        </table>
    </form>
</body>
</html>
