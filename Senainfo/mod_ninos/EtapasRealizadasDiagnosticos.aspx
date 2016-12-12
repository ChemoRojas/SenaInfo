<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtapasRealizadasDiagnosticos.aspx.cs" Inherits="mod_ninos_EtapasRealizadasDiagnosticos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css">
        <!--
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
        -->
    </style>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                <tr>
                    <td height="25" class="titulo_form">&nbsp;Etapas Realizadas Diagn&oacute;sticos </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                            <tr>
                                <td width="200" class="texto_form">Fecha</td>
                                <td>

                                    <asp:TextBox ID="cal001" runat="server" Width="150px" />
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende456" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                    <asp:RangeValidator ID="RangeValidator456" runat="server" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />


                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form">Etapas del Diagn&oacute;stico  </td>
                                <td>
                                    <asp:DropDownList ID="ddown001" runat="server" Font-Size="11px" Width="150px">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">

                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_modificar" runat="server" Text="Modificar" OnClick="btn_modificar_Click"  />


                        &nbsp;
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_limpiar" runat="server" Text="Limpiar" OnClick="btn_limpiar_Click"  />


                        &nbsp;
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_cerrar" runat="server" Text="Cerrar" OnClick="btn_cerrar_Click"  />
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
