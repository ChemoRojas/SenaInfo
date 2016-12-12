<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="ninos_ingresonuevo.aspx.cs" Inherits="mod_coordinador_ingresonuevo" %>

<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="sbtb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

     
        <asp:Panel ID="pnl005" runat="server" Width="100%">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="titulo_form">&nbsp;Ingreso de Nuevo Niño</td>
                </tr>
                <tr>
                    <td style="height: 265px">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="150" class="texto_form">Rut</td>
                                <td align="left" bgcolor="#ffffff" style="color: red">
                        
                                    <asp:TextBox ID="txt001" runat="server" AutoPostBack="true" OnTextChanged="txt001_ValueChange"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt001" Mask="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" />


                                    <asp:CheckBox ID="chk001" runat="server" AutoPostBack="True" OnCheckedChanged="chk001_CheckedChanged" Text="Sin Run" Font-Size="11px" />
                                    <br />
                                    <asp:Panel ID="pnl003" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px" Height="1px" HorizontalAlign="Center" Visible="False" Width="250px">
                                        <asp:Label ID="lbl004" runat="server" Font-Size="11px"></asp:Label>
                                    </asp:Panel>
                                    <asp:Label ID="lblexrut" runat="server" Font-Size="11px" ForeColor="Red" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="150" class="texto_form">Nombres</td>
                                <td bgcolor="#ffffff" align="left">
                                    <asp:TextBox ID="txt002" runat="server" Width="350px" Font-Size="11px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="150" class="texto_form">Apellido&nbsp; Paterno</td>
                                <td align="left" bgcolor="#ffffff">
                                    <asp:TextBox ID="txt003" runat="server" Width="350px" Font-Size="11px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="150" class="texto_form">Apellido Materno</td>
                                <td align="left" bgcolor="#ffffff">
                                    <asp:TextBox ID="txt004" runat="server" Width="350px" Font-Size="11px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="150" class="texto_form">Sexo</td>
                                <td bgcolor="#ffffff">
                                    <asp:RadioButton ID="rdo001" runat="server" GroupName="rdosexo" Text="Femenino" Font-Size="11px" Checked="True" />
                                    <asp:RadioButton ID="rdo002" runat="server" GroupName="rdosexo" Text="Masculino" Font-Size="11px" /></td>
                            </tr>
                            <tr>
                                <td width="150" class="texto_form">Fecha de Nacimiento</td>
                                <td bgcolor="#ffffff">
                         
                                    <asp:TextBox ID="cal001" runat="server" Text="Seleccione Fecha" Font-Size="11px"  Width="250px" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                                    <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="cal001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" /> 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />

                                </td>
                            </tr>
                            <tr>
                                <td width="150" class="texto_form">Nacionalidad</td>
                                <td bgcolor="#ffffff">
                                    <span class="texto_rojo_peque">
                                        <asp:DropDownList ID="ddown001" runat="server" AppendDataBoundItems="True" Width="350px" Font-Size="11px">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList></span></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lbl002" runat="server" CssClass="texto_rojo_peque"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                       
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn001" runat="server" Text="Agregar Niño" OnClick="btn001_Click" />

                    </td>
                </tr>
            </table>
        </asp:Panel>
                       </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel ID="pnl006" runat="server" Width="100%" Visible="False">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">&nbsp;<br />
                                    <br />
                                    <asp:Label ID="Label2" runat="server" BorderColor="Red" ForeColor="Red" Text="EL RUT INGRESADO YA EXISTE Y CORRESPONDE A ESTE NIÑO(A), SI DESEA CONTINUAR CON EL INGRESO HAGA CLIC EN CONTINUAR. SI ESTA IDENTIDAD NO CORRESPONDE AL RUT, NO LO INGRESE  Y LLAME A LA MESA DE AYUDA."
                                        Width="550px" Font-Bold="True"></asp:Label><br />
                                    &nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="grd003" runat="server" AutoGenerateColumns="False"
                                        CellPadding="2" ForeColor="#333333" GridLines="None">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaAdoptabilidad" HeaderText="FECHA ADOPTABILIDAD" />
                                            <asp:BoundField DataField="IdentidadConfirmada" HeaderText="IDENTIDAD CONFIRMADA" />
                                            <asp:BoundField DataField="Rut" HeaderText="RUT">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Right" Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sexo" HeaderText="SEXO">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="NOMBRES">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Apellido_paterno" HeaderText="APELLIDO PATERNO">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="APELLIDO MATERNO">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO"
                                                HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nacionalidad" HeaderText="NACIONALIDAD" />
                                            <asp:BoundField DataField="Etnia" HeaderText="ETNIA" />
                                            <asp:BoundField DataField="OficinaInscripcion" HeaderText="OFICINA INSCRIP." />
                                            <asp:BoundField DataField="AnoInscripcion" HeaderText="A&#209;O INSCRIP." />
                                            <asp:BoundField DataField="NumeroInscripcionCivil" HeaderText="NUM. INSCRIP. CIVIL" />
                                            <asp:BoundField DataField="AlergiasConocidas" HeaderText="ALERGIAS CONOCIDAS" />
                                            <asp:BoundField DataField="InscritoFONADIS" HeaderText="INSCRITO FONADIS" />
                                            <asp:BoundField DataField="InscritoFONASA" HeaderText="INSCRITO FONASA" />
                                            <asp:BoundField HeaderText="NI&#209;O SUSEPTIBLE ADOPCION" />
                                            <asp:BoundField DataField="EstadoGestacion" HeaderText="ESTADO GESTACION" />
                                        </Columns>
                                        <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                            ForeColor="White" HorizontalAlign="Left" />
                                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table width="550px" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center">&nbsp;<br />
                                    <br />
                                  
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn004" runat="server" Text="Continuar" OnClick="btn004_Click" />

                                    &nbsp;
                 
                                     <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn005" runat="server" Text="Cancelar" OnClick="btn005_Click" />

                                </td>
                            </tr>
                            <tr>

                                <td>&nbsp;</td>

                            </tr>

                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
