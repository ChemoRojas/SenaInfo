<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ActualizacionProyectos.aspx.cs"  Inherits="ActualizacionProyectos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>

<script language="javascript">
function f_SoloNumeros()
{
    var key=window.event.keyCode;
    if (key < 48 || key > 57)
    {
        window.event.keyCode=0;
    }
}

function f_suma()
{
    var vFemenino = eval(document.getElementById("txtFemenino2").value)
    var vMasculino = eval(document.getElementById("txtMasculino2").value)
    var vTotal = eval(vFemenino + vMasculino)
    if (isNaN(vTotal))
    {
        if (isNaN(vFemenino))
        {
            vFemenino = 0
        }
        if (isNaN(vMasculino))
        {
            vMasculino = 0
        }
        vTotal= eval(vFemenino + vMasculino);
    }
    document.getElementById("txtTotal2").value = vTotal
    document.getElementById("txtFemenino2").value = vFemenino
    document.getElementById("txtMasculino2").value = vMasculino
}
</script>

<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table align="center" border="2">
                <tr>
                    <td class="texto_form" style="height: 17px; text-align: center">
                        <span lang="ES" style="font-size: 12pt; color: white; font-family: 'Times New Roman';
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES; mso-fareast-language: ES;
                            mso-bidi-language: AR-SA">SE SOLICITA ACTUALIZAR LOS DATOS DEL PROYECTO</span></td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Institución</td>
                                <td>
                                    <asp:TextBox ID="txtInstitucion" runat="server" Width="573px" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px; width: 138px;" class="texto_form">
                                    Proyecto</td>
                                <td>
                                    <asp:TextBox ID="txtProyecto" runat="server" Width="573px" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Modelo</td>
                                <td>
                                    <asp:TextBox ID="txtModelo" runat="server" Width="573px" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Número Plazas</td>
                                <td>
                                    <asp:TextBox ID="txtPlazas" runat="server" Width="76px" ReadOnly="True"></asp:TextBox></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    ¿Puede actualizar los datos del proyecto en este momento?</td>
                                <td>
                                    <br />
                                    <asp:RadioButton ID="rbSi" runat="server" GroupName="rbPregunta" Text="SI" /><br />
                                    <asp:RadioButton ID="rbEnOtraOpotunidad" runat="server" GroupName="rbPregunta" Text="ACTUALIZAR EN UNA PRÓXIMA OPORTUNIDAD" /><br />
                                    <br />
                                    <asp:Label ID="lblFechaObligatoria" runat="server" Font-Bold="True" ForeColor="Red"
                                        Text="lblFechaObligatoria" Width="446px"></asp:Label></td>
                                <td>
                                         <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnContinuar" runat="server" Text="Continuar" OnClick="btnContinuar_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table align="center" border="2">
                <tr>
                    <td style="width: 953px">
                        <asp:Panel ID="pnlDatos" runat="server" Visible="False">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr valign="top">
                                    <td height="22" colspan="2" class="titulo_form">
                                        &nbsp;
                                        <asp:Label ID="lbl000" runat="server" Text="Datos del Proyecto."></asp:Label></td>
                                </tr>
                                <tr valign="top">
                                    <td colspan="2">
                                        <table border="0" cellpadding="1" cellspacing="1" onclick="return TABLE1_onclick()"
                                            id="Table1">
                                            <tr>
                                                <td class="texto_form">
                                                    Dirección</td>
                                                <td bgcolor="#ffffff">
                         
                                                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="txtDireccionValidator" runat="server" ErrorMessage="Formato Inválido en Dirección"
                                                        ControlToValidate="txtDireccion" Font-Bold="True" ValidationExpression="CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"></asp:RegularExpressionValidator>
                                                </td>
                                                <td bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">
                                                    Teléfono</td>
                                                <td bgcolor="#ffffff">
                                   
                                                    <asp:TextBox ID="txtTelefono" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="txtTelefonoValidator" runat="server" ErrorMessage="Formato Inválido en Teléfono"
                                                        ControlToValidate="txtTelefono" Font-Bold="True" ValidationExpression="CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"></asp:RegularExpressionValidator>
                                                </td>
                                                <td bgcolor="#ffffff">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">
                                                    e-Mail</td>
                                                <td bgcolor="#ffffff">
                                                    <asp:TextBox ID="txtMail" runat="server" Width="350px" MaxLength="50"></asp:TextBox></td>
                                                <td bgcolor="#ffffff">
                                         
                                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGuarda" runat="server" Text="Guardar Datos" OnClick="btnGuarda_Click" />
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">
                                                    Fax</td>
                                                <td bgcolor="#ffffff">
                
                                                    <asp:TextBox ID="txtFax" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="txtFaxValidator" runat="server" ErrorMessage="Formato Inválido en Fax"
                                                        ControlToValidate="txtFax" Font-Bold="True" ValidationExpression="CCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"></asp:RegularExpressionValidator>
                                                        
                                                </td>
                                                <td bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">
                                                    Director</td>
                                                <td bgcolor="#ffffff">
                  
                                                     <asp:TextBox ID="txtDirector" runat="server" Width="740px"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="txtDirectorValidator" runat="server" ErrorMessage="Formato Inválido en Direcctor"
                                                        ControlToValidate="txtDirector" Font-Bold="True" ValidationExpression="CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC"></asp:RegularExpressionValidator>
                                                    
                                                </td>
                                                <td bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="texto_form">
                                                    Rut Director</td>
                                                <td bgcolor="#ffffff">
                                          
                                                     <asp:TextBox ID="txtRutDirector" runat="server" Width="150px" AutoPostBack="true" OnTextChanged="txt011_ValueChange"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="txtRutDirectorValidator" runat="server" ErrorMessage="Formato Inválido en Rut Director"
                                                        ControlToValidate="txtRutDirector" Font-Bold="True" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)"></asp:RegularExpressionValidator>
                                                    
                                                    <asp:Panel ID="pnl002" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px"
                                                        Height="1px" HorizontalAlign="Center" Visible="False" Width="250px">
                                                        <asp:Label ID="lbl002" runat="server" Font-Size="11px"></asp:Label>&nbsp;</asp:Panel>
                                                </td>
                                                <td bgcolor="#ffffff">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
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
