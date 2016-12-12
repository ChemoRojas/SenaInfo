<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ninos_identificacionninooadolecente.ascx.cs" Inherits="mod_ninos_ninos_identificacionninooadolecente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
<table style="width: 719px; height: 86px">
    <tr>
        <td class="titulo_form" colspan="2">
            Identificación del Niño(a) y/o Adolecente</td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Nombres</td>
        <td style="height: 20px; width: 365px;">
            <table border="0" cellspacing="2" style="width: 72%">
                <tr>
                    <td style="height: 25px" width="1">
                        <asp:TextBox ID="txt_001" runat="server"></asp:TextBox></td>
                    <td style="height: 25px" width="2">
                        <span class="texto_rojo_peque"><strong>*</strong></span>
                    </td>
                    <td style="height: 25px" width="3">
                        <img height="16" src="../images/lupa.jpg" width="16" /></td>
                    <td style="width: 63px; height: 25px">
                        <span class="buscador">
                            <img height="16" src="../images/cancelar.jpg" width="16" /></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Apellido Paterno</td>
        <td style="height: 20px; width: 365px;">
            <asp:TextBox ID="txt_002" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Apellido Materno</td>
        <td style="height: 20px; width: 365px;">
            <asp:TextBox ID="txt_003" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form">
            Rut</td>
        <td style="height: 9px; width: 365px;">
            &nbsp;<table border="0" cellspacing="2" style="width: 60%">
                <tr>
                    <td style="width: 1px; height: 24px">
                        <asp:TextBox ID="txt_004" runat="server"></asp:TextBox></td>
                    <td style="height: 24px">
                        sin rut&nbsp;</td>
                    <td style="height: 24px">
                        <asp:CheckBox ID="chk_001" runat="server" Width="84px" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Sexo</td>
        <td style="height: 20px; width: 365px;">
            &nbsp;<asp:DropDownList ID="ddown_001" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            <span>Fecha Nacimiento </span>
        </td>
        <td style="font-size: 6pt; color: #ff0000; height: 20px; width: 365px;">
             <asp:TextBox ID="cal_001" runat="server" Font-Names="Arial" Font-Size="11px" Width="150px" ONVALUECHANGED="call001_ValueChanged" />
             <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende_cal_001" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
             <asp:RangeValidator ID="RangeValidator810" runat="server" Text="Fecha Invalida" ControlToValidate="cal_001" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />

        </td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Edad Actual</td>
        <td style="height: 20px; width: 365px;">
            &nbsp;<asp:TextBox ID="txt_005" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form">
                    Nacionalidad</td>
        <td style="height: 12px; width: 365px;">
            <table border="0" cellspacing="2" style="width: 72%">
                <tr>
                    <td  >
                        <asp:TextBox ID="txt_006" runat="server"></asp:TextBox></td>
                    <td >
                        <span class="texto_rojo_peque"><strong>*</strong></span>
                    </td>
                    <td >
                        <img height="16" src="../images/lupa.jpg" width="16" /></td>
                    <td >
                        <span class="buscador">
                            <img height="16" src="../images/cancelar.jpg" width="16" /></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Identidad Confirmada</td>
        <td style="height: 20px; width: 365px;">
            <asp:CheckBox ID="chk_002" runat="server" /></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 20px">
            Etnia</td>
        <td style="height: 20px; width: 365px;">
            &nbsp;<table border="0" cellspacing="2" style="width: 72%">
                <tr>
                    <td >
                        <asp:TextBox ID="txt_007" runat="server"></asp:TextBox></td>
                    <td >
                        <span class="texto_rojo_peque"><strong>*</strong></span>
                    </td>
                    <td >
                        <img height="16" src="../images/lupa.jpg" width="16" /></td>
                    <td >
                        <span class="buscador">
                            <img height="16" src="../images/cancelar.jpg" width="16" /></span></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 24px">
            Oficina Inscripción</td>
        <td style="height: 24px; width: 365px;">
            <asp:TextBox ID="txt_008" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 24px">
            Año Inscripción</td>
        <td style="height: 24px; width: 365px;">
            <asp:TextBox ID="txt_009" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 24px">
            Nº Inscripción Civil</td>
        <td style="height: 24px; width: 365px;">
                        <input id="txt_010" name="textfield" style="width: 100px; height: 20px" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 24px">
            Alergias Conocidas</td>
        <td style="height: 24px; width: 365px;">
            <input id="txt_011" name="textfield" style="width: 278px; height: 56px" />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 24px">
            Inscrito Registro Nac. de Discapacidad&nbsp;</td>
        <td style="height: 24px; width: 365px;">
            <asp:DropDownList ID="ddown_002" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 166px; height: 24px">
            Inscrito en FONASA</td>
        <td style="height: 24px; width: 365px;">
            <asp:DropDownList ID="ddown_003" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        
        <td colspan ="2" style="height: 24px" align="center">
            <asp:ImageButton ID="imb_001" runat="server" ImageUrl="~/images/bt_actualizar.gif" /></td>
    </tr>
</table>
