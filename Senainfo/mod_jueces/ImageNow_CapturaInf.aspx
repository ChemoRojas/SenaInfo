<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageNow_CapturaInf.aspx.cs" Inherits="mod_jueces_ImageNow_CapturaInf" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Captura datos</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;
            if (arguments.Value != '0') {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <table style="width: 687px; height: 646px">
                <tr>
                    <td bgcolor="#ffffff" colspan="4" style="text-align: center; width: 1000px;">&nbsp; &nbsp;
                    </td>

                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 23px"></td>
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">ICODIE</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtICodIE" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="width: 100px" class="texto_form">CodNino</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtCodNino" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>


                    <td style="width: 100px" class="texto_form">Rut</td>

                    <td colspan="3">
                        <asp:TextBox ID="txt_rut" runat="server" Width="250px" AutoPostBack="True" Font-Size="11px" ONVALUECHANGE="txt_rut_ValueChange" Enabled="False" /><cc1:MaskedEditExtender ID="MaskedEditExtender94" runat="server" TargetControlID="txt_rut" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="99999999$$" />

                        <asp:RadioButtonList ID="rdblist_nacionalidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdblist_rut_SelectedIndexChanged"
                            RepeatDirection="Horizontal" Enabled="False">
                            <asp:ListItem Selected="True">Chileno</asp:ListItem>
                            <asp:ListItem>Extranjero</asp:ListItem>
                        </asp:RadioButtonList>
                 
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Apellido Paterno</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_ap_paterno" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Apellido Materno</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_ap_materno" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Nombres</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_nombres" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Sexo</td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rdbl_sexo" runat="server" RepeatDirection="Horizontal" Font-Size="11px" Enabled="False">
                            <asp:ListItem Selected="True" Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Fecha de Nacimiento</td>
                    <td colspan="3">

                        <asp:TextBox ID="wdc_Fnacimiento" runat="server" Font-Size="11px" Enabled="False" />
                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende286" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="wdc_Fnacimiento" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="wdc_Fnacimiento" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />


                    </td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 23px;" class="texto_form">Nacionalidad</td>
                    <td colspan="3" style="height: 23px">
                        <asp:TextBox ID="txt_nacionalidad" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>

                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Región Tribunal</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtRegionTribunal" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>

                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Tipo de Tribunal</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtTipoTribunal" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 24px" class="texto_form">Tribunal</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtTribunal" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 24px;" class="texto_form">RUC</td>
                    <td style="width: 100px; height: 24px;">


                        <asp:TextBox ID="txt_ruc" runat="server" Width="250px" ONVALUECHANGE="txt_ruc_ValueChange" AutoPostBack="True" Font-Size="11px" Enabled="False" /><cc1:MaskedEditExtender ID="MaskedEditExtender95" runat="server" TargetControlID="txt_ruc" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="$$$$$$$$$$$$" /></td>
                        <td style="width: 100px; height: 24px;" class="texto_form">RIT</td>
                        <td style="width: 100px; height: 24px;">
                            <asp:TextBox ID="txt_rit" runat="server" Font-Size="11px" Enabled="False"></asp:TextBox></td>
                       
                </tr>
                <tr>
                   
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Tipo de Delito</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtTipoDelito" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>

                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Delito</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtDelito" runat="server" Width="95%" Font-Size="11px" Enabled="False"></asp:TextBox></td>

                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Código Delito</td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_codDelito" runat="server" Enabled="False" Font-Size="11px"></asp:TextBox></td>
                  
                </tr>
                <tr>
                    <td style="width: 100px" class="texto_form">Región Proyecto</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtRegionProyecto" runat="server" Enabled="False" Font-Size="11px" Width="553px"></asp:TextBox></td>

                </tr>
                <tr>
                    <td style="width: 100px; height: 24px;" class="texto_form">Proyecto</td>
                    <td colspan="3">
                        <asp:TextBox ID="TxtProyecto" runat="server" Enabled="False" Font-Size="11px" Width="553px"></asp:TextBox></td>

                </tr>
              




                <tr>
                    <td colspan="4" align="center">
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_Cerrar" runat="server" Text="Cerrar" OnClick="btn_Cerrar_Click"  />


                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
