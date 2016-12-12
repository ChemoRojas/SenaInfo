<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_eventosareaintervencion.aspx.cs" Inherits="mod_ninos_ninos_eventosareaintervencion" %>

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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

        
            <table style="width: 551px; height: 138px">
                <tr>
                    <td class="titulo_form" colspan="2" style="height: 25px">Eventos del Área de Intervención</td>
                </tr>
                <tr>
                    <td class="texto_form" style="width: 234px">Plan de Intervención</td>
                    <td style="width: 10px">
                        <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" Width="129px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="texto_form" style="width: 234px">Fecha Inicio</td>
                    <td style="width: 10px">
                        <strong><span style="font-size: 6pt; color: #ff0033; font-family: Verdana">
                            <asp:TextBox ID="txt_002" runat="server"></asp:TextBox></span></strong></td>
                </tr>
                <tr>
                    <td class="texto_form" style="width: 234px">Fecha Término</td>
                    <td style="width: 10px">
                        <asp:TextBox ID="txt_003" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="texto_form" style="width: 234px">Niño (a)</td>
                    <td style="width: 10px">
                        <strong><span style="font-size: 6pt; color: #ff0033; font-family: Verdana">
                            <asp:TextBox ID="txt_004" runat="server" Width="350px"></asp:TextBox></span></strong></td>
                </tr>
                <tr>
                    <td class="texto_form" style="width: 234px">Proyecto</td>
                    <td style="width: 10px">
                        <strong><span style="font-size: 6pt; color: #ff0033; font-family: Verdana">
                            <asp:TextBox ID="txt_005" runat="server"></asp:TextBox></span></strong></td>
                </tr>
                <tr>
                    <td class="titulo_form" colspan="2">Área de Intervención</td>
                </tr>
                <tr>
                    <td class="texto_form" colspan="1" style="width: 234px">Tipo y Nivel de Intervención</td>
                    <td>
                        <asp:DropDownList ID="ddown002" runat="server" Width="275px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="texto_form" style="width: 234px; height: 50px">Detalle Área Intervención</td>
                    <td style="width: 10px; height: 50px">
                        <asp:TextBox ID="txt_006" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="titulo_form" colspan="2">Lista de Eventos</td>
                </tr>
                <tr>
                    <td class="titulo_form" colspan="2">Eventos que se han asignado al área de Intervención</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span id="rvEventos" class="TextError" controltovalidate="txtNroEventosAreaIntervencion"
                            errormessage="Debe ingresar algún evento de intervención" isvalid="false" maximumvalue="500"
                            minimumvalue="1" style="color: red" type="Integer">
                            <asp:Label ID="lbl001" runat="server" Text="Debe ingresar algún evento de intervención"></asp:Label></span></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grd001" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            Font-Size="Medium" OnRowCommand="grd001_RowCommand1" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Fecha de Evento" HeaderText="Fecha de Evento">
                                    <ItemStyle Font-Size="Smaller" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tipo de evento" HeaderText="Tipo de evento" />
                                <asp:BoundField DataField="T&#233;cnico" HeaderText="T&#233;cnico" />
                                <asp:BoundField DataField="Descripci&#243;n" HeaderText="Descripci&#243;n" />
                                <asp:ButtonField Text="Quitar" />
                            </Columns>
                            <RowStyle BackColor="White" BorderColor="SteelBlue" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Fecha Evento &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    Tipo de Evento &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Técnico
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Descripción</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table style="width: 535px">
                            <tr>
                                <td style="width: 5px">

                                    <asp:TextBox ID="cal001" runat="server" Width="150px" />
                                    <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende878" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                                </td>
                                <td>
                                    <asp:DropDownList ID="ddown003" runat="server" Width="180px">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddown004" runat="server" Width="250px">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="txt_007" runat="server" TextMode="MultiLine"></asp:TextBox></td>

                            </tr>
                        </table>
                        <br />
                        <table align="center" border="0" cellpadding="0" cellspacing="3" width="50%">
                            <tr align="middle">
                                <td align="center" style="height: 28px; width: 348px;">&nbsp;
                                
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn001" runat="server" Text="Agregar" OnClick="btn001_Click"  />


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px" align="center">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 52px" align="center">
                        <table align="center" border="0" cellpadding="0" cellspacing="3" width="50%">
                            <tr align="middle">
                                <td align="center" style="height: 28px; width: 348px;">&nbsp;
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn002" runat="server" Text="Guardar" OnClick="btn002_Click"  />
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                            </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
