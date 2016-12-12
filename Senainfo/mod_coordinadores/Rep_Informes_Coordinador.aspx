<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_Informes_Coordinador.aspx.cs" Inherits="mod_reportes_Rep_Informes_Coordinador" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="sbtb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

 
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body style="height: 94%">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <div>
                <table id="Table2" border="0" cellpadding="1" cellspacing="1" onclick="return TABLE1_onclick()
            "
                    style="width: 94%">
                    <tr>
                        <td class="titulo_form" colspan="6" style="height: 20px; width: 799px;">Nómina de adolescentes / Certificado de Ingreso</td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>

                    <tr>
                        <td class="texto_form" style="width: 21px; height: 16px">Tipo Listado</td>

                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddown001" runat="server" Width="150px" AppendDataBoundItems="True" Font-Size="11px">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                        <asp:ListItem Value="1">Nomina</asp:ListItem>
                                        <asp:ListItem Value="2">Certificado Ingreso</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="texto_form" style="width: 21px; height: 16px">Institución</td>
                        <td colspan="2" style="width: 227px">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddown002" runat="server" Width="469px" AppendDataBoundItems="True" Font-Size="11px" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 12px">
                            <asp:ImageButton ID="btnBuscaInstitucion" runat="server" ImageUrl="~/images/lupa.jpg" /></td>
                        <td>&nbsp;
         
                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb_1" runat="server" Text="Limpiar" Width="87px" />

                        </td>
                    </tr>

                    <tr>
                        <td class="texto_form" style="width: 21px; height: 18px">Proyecto  </td>
                        <td colspan="2" style="width: 227px">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddown003" runat="server" AppendDataBoundItems="True"
                                        Font-Size="11px" Width="469px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 12px">
                            <asp:ImageButton ID="btnBuscaProyecto" runat="server" ImageUrl="~/images/lupa.jpg" /></td>
                        <td>&nbsp;
                           
                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="imb_2" runat="server" Text="Volver" Width="88px" OnClick="imb_2_Click" />


                        </td>

                    </tr>
                    <tr>
                        <td class="texto_form" style="width: 21px; height: 16px">Medida </td>
                        <td colspan="2" style="width: 227px">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddown004" runat="server" AppendDataBoundItems="True"
                                        Font-Size="11px" Width="316px">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>


                    </tr>
                    <tr>
                        <td class="texto_form" style="width: 21px; height: 16px">Medio </td>
                        <td colspan="2" style="width: 227px">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddown005" runat="server" Width="317px" AppendDataBoundItems="True" Font-Size="11px">
                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                        <asp:ListItem Value="1">Medio Libre</asp:ListItem>
                                        <asp:ListItem Value="2">Privado Libertad</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>


                    </tr>

                    <tr>
                        <td class="texto_form" style="width: 21px; height: 27px">Fecha Desde </td>
                        <td colspan="2" style="height: 27px">

                            <asp:TextBox ID="cal001" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="cal001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />

                        </td>
                        <td class="texto_form" style="width: 12px; height: 27px">Fecha hasta </td>

                        <td colspan="2" style="height: 27px">

                            <asp:TextBox ID="WebDateChooser1" runat="server" Text="Seleccione Fecha" Font-Size="11px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="WebDateChooser1" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="WebDateChooser1" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />

                        </td>
                    </tr>

                </table>
                <br />
            </div>
        </div>



        <br />
        <br />
        <table style="width: 94%">
        </table>
    </form>
</body>
</html>
