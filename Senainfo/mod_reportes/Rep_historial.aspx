<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_historial.aspx.cs" Inherits="Reportes_Rep_historial" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

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

            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="titulo_form">Reporte de Historial del Niño</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                        <tr>
                                            <td width="225" class="texto_form">Código del
                      Niño</td>
                                            <td colspan="3" class="linea_inferior">&nbsp;
                                                <asp:TextBox ID="Wcodnino" runat="server" Font-Size="11px" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="texto_form">Tipo Reportes</td>
                                            <td colspan="3" class="linea_inferior">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:CheckBox ID="chIngreso" runat="server" Font-Size="11px" Text="Ingresos" Checked="True" Enabled="False" Width="255px" meta:resourcekey="chMaltratoResource1" /><br />
                                                            <asp:CheckBox ID="chEscolar" runat="server" Font-Size="11px" Text="Diagnóstico Escolar" meta:resourcekey="chEscolarResource1" Width="239px" /><br />
                                                            <asp:CheckBox ID="chMaltrato" runat="server" Font-Size="11px" Text="Diagnóstico de Maltrato" meta:resourcekey="chk002Resource1" Width="256px" /><br />
                                                            <asp:CheckBox ID="chDrogas" runat="server" Font-Size="11px" Text="Diagnóstico de Drogas" meta:resourcekey="chDrogasResource1" Width="253px" /><br />
                                                            <asp:CheckBox ID="chPsicologico" runat="server" Font-Size="11px" Text="Diagnóstico Psicológico" meta:resourcekey="chPsicologicoResource1" Width="257px" /><br />
                                                            <asp:CheckBox ID="chSocial" runat="server" Font-Size="11px" Text="Diagnóstico Social" meta:resourcekey="chSocialResource1" Width="140px" /><br />
                                                            <asp:CheckBox ID="chCapacitacion" runat="server" Font-Size="11px" Text="Diagnóstico Capacitación" meta:resourcekey="chCapacitacionResource1" Width="173px" /><br />
                                                            <asp:CheckBox ID="chLaboral" runat="server" Font-Size="11px" Text="Diagnóstico Laboral" meta:resourcekey="chLaboralResource1" /><br />
                                                            <asp:CheckBox ID="chJudiciales" runat="server" Font-Size="11px" Text="Hechos Judiciales" meta:resourcekey="chJudicialesResource1" /><br />
                                                            <asp:CheckBox ID="chPfti" runat="server" Font-Size="11px" Text="Peores Formas de Trabajo Infantil" meta:resourcekey="chPftiResource1" Width="272px" /><br />
                                                            <asp:CheckBox ID="chDiscapacidad" runat="server" Font-Size="11px" Text="Diagnóstico Discapacidad" meta:resourcekey="chSaludResource1" Width="272px" /><br />
                                                            <asp:CheckBox ID="chHechosSalud" runat="server" Font-Size="11px" Text="Hechos de Salud" meta:resourcekey="chHechosSaludResource1" Width="271px" /><br />
                                                            <asp:CheckBox ID="chEnfermedades" runat="server" Font-Size="11px" Text="Enfermedades Crónicas" meta:resourcekey="chEnfermedadesResource1" Width="177px" /><br />
                                                            <asp:CheckBox ID="chPersonasRelacionadas" runat="server" Font-Size="11px" Text="Personas Relacionadas" meta:resourcekey="chPersonasRelacionadasResource1" /></td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lbl_error" runat="server" Font-Size="11px" ForeColor="Red" Visible="False">No se han encontrado registros coincidentes.</asp:Label></td>
                                <td width="150" align="center">&nbsp;<br />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_imprimir" runat="server" Text="Imprimir" Width="100px" OnClick="btn_imprimir_Click"  />


                                    &nbsp;<br />

                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click" Text="Limpiar" Width="100px"  />



                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" OnClick="btn_volver_Click" Text="Volver" Width="100px"  />


                                </td>
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
