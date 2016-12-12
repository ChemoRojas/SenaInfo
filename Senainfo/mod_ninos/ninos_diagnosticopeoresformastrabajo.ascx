<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ninos_diagnosticopeoresformastrabajo.ascx.cs" Inherits="mod_ninos_ninos_diagnosticopeoresformastrabajo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
<table style="width: 572px; height: 86px">    
    <tr>
        <td class="titulo_form" colspan="2">
            Diagnóstico Peores Formas de Trabajo</td>
    </tr>
    <tr>
        <td class="texto_form" style="height: 45px; width: 225px;" >
            Fecha Diagnóstico</td>
        <td style="height: 45px"> 
            <asp:TextBox ID="cal001" RUNAT="server" WIDTH="150px" />
            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1635" runat="server"  Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled"/>
            <asp:RangeValidator ID="RangeValidator1635" runat="server" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01"/>
        </td>
    </tr>
    <tr>
                <td class="texto_form" style="width: 225px">
                    Región</td>
                <td bgcolor="#ffffff">
                    &nbsp;<asp:DropDownList ID="ddown_region" runat="server" AppendDataBoundItems="True" Font-Size="11px" Width="650px" AutoPostBack="True">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>            
                <td class="texto_form" style="width: 225px">
                    Comuna

                </td>
                <td bgcolor="#ffffff">
                    &nbsp;<asp:DropDownList ID="ddown_Comuna" runat="server" AppendDataBoundItems="True" Font-Size="11px" Width="650px">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList>

                </td>
              
            </tr>    
            <tr>
                <td class="texto_form" style="width: 225px">
                    Fecha Ocurrencia</td>
                <td bgcolor="#ffffff">
                    <asp:TextBox ID="cal002h" Text="" RUNAT="server" WIDTH="150px" /><cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1648" runat="server"  Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002h" ValidateRequestMode="Enabled" ViewStateMode="Enabled"/><asp:RangeValidator ID="RangeValidator1648" runat="server" Text="Fecha Invalida" ControlToValidate="cal002h" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01"/>
                </td>

                <td>
                <div class="alert alert-danger text-left" color-text="red" role="alert" id="alertaObligatorio" runat="server" visible="false">
                       Campo Fecha Ocurrencia es Obligatorio<span class=""></span>
                      <asp:Label ID="lblMsgSuccess" runat="server" Text=" Campo Fecha Ocurrencia es Obligatorio" Visible="false"> Campo Fecha Ocurrencia es Obligatorio</asp:Label>
                                                         
                </div>
                </td>
            </tr>
    <tr>    
        <td class="texto_form" style="width: 225px" >
            Presenta Agresión</td>
        <td style="height: 20px">
            <asp:RadioButton ID="rdo001" runat="server" GroupName="gr1" Text="SI" Width="42px" /><asp:RadioButton
                ID="rdo002" runat="server" GroupName="gr1" Text="NO" Width="45px" /></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 225px">
            Categoría Forma de Trabajo</td>
        <td style="height: 20px">
            <asp:DropDownList ID="ddown001" runat="server" Width="300px" AppendDataBoundItems="True">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 225px">
            Agresor</td>
        <td style="height: 20px">
            <asp:DropDownList ID="ddown002" runat="server" Width="300px" AppendDataBoundItems="True">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 225px">
            Vive con el Agresor</td>
        <td style="height: 20px">
            <asp:CheckBox ID="chk001" runat="server" Text="SI" /></td>
    </tr>
    <tr>
                <td class="texto_form" style="width: 225px">
                    Relacion Presunto Explotador Laboral</td>
                <td bgcolor="#ffffff">
                    &nbsp;<asp:DropDownList ID="ddown_relacion" runat="server" AppendDataBoundItems="True" Font-Size="11px" Width="650px" AutoPostBack="True">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>            
                <td class="texto_form" style="width: 225px;">
                    Especificación Relacion</td>
                <td bgcolor="#ffffff">
                    <asp:TextBox ID="txtbox_relac" runat="server" height="50px" width="300px"></asp:TextBox>
                </td>
            </tr>   
            <tr>
                <td class="texto_form" style="width: 225px">
                    Categoría Forma de Trabajo</td>
                <td bgcolor="#ffffff">
                    <asp:DropDownList ID="ddown001h" runat="server" AppendDataBoundItems="True" Font-Size="11px"
                        Width="650px">
                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                    </asp:DropDownList></td>
            </tr> 
            <tr>            
                <td class="texto_form" style="width: 225px;">
                    Especificación PFTI</td>
                <td bgcolor="#ffffff"><asp:TextBox ID="txtbox_PreExpl" runat="server"  height="50px" width="300px"></asp:TextBox></td>
            </tr>   
    <tr>
        <td class="texto_form" style="width: 225px; height: 12px">
            Técnico</td>
        <td style="height: 12px">
            <asp:DropDownList ID="ddown003" runat="server" Width="300px" AppendDataBoundItems="True">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="texto_form" style="width: 225px; height: 33px">
            Observaciones</td>
        <td>
            <asp:TextBox ID="txt001_wt" runat="server" height="50px" width="300px"></asp:TextBox>            
        </td>
    </tr>
    <tr>
        
        <td colspan ="2">
            <table align="center" border="0" cellpadding="0" cellspacing="3" width="50%">
                <tr align="middle">
                    <td align="center">
                        &nbsp;<asp:Button ID="btn001" RUNAT="server" ONCLICK="btn001_Click" TEXT="Agregar Nuevo Diagnostico"  />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
