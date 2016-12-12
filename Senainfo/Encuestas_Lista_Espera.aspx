<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Encuestas_Lista_Espera.aspx.cs"
    Inherits="Encuestas_Lista_Espera" %>

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
            <table align="center" border="2" style="width: 70%">
                <tr>
                    <td class="texto_form" style="height: 17px; text-align: justify">
                        <span lang="ES" style="font-size: 12pt; color: white; font-family: 'Times New Roman';
                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES; mso-fareast-language: ES;
                            mso-bidi-language: AR-SA">Se agradece responder esta encuesta, relacionada con Lista
                            de Espera de niños(as): Si tiene Lista de Espera, indique SI y haga clic en Continuar,
                            luego registre las cantidades y haga clic en Guardar Encuesta. Si no tiene lista
                            de Espera, responda NO y haga clic en Continuar. Si en el momento no tiene los datos
                            a mano, responda ‘Contestar en una próxima oportunidad y haga clic en Continuar,
                            con lo cual se le preguntará la próxima vez que ingrese a la SENAINFO.<br />
                            <br />
                            Gracias por su colaboración.</span></td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 70%;">
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Institucion</td>
                                <td style="width: 411px">
                                    <asp:TextBox ID="txtInstitucion" runat="server" Width="362px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 86px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 19px; width: 138px;" class="texto_form">
                                    Proyecto</td>
                                <td style="height: 19px; width: 411px;">
                                    <asp:TextBox ID="txtProyecto" runat="server" Width="362px" ReadOnly="True"></asp:TextBox></td>
                                <td style="height: 19px; width: 86px;">
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Modelo</td>
                                <td style="width: 411px">
                                    <asp:TextBox ID="txtModelo" runat="server" Width="362px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 86px">
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Número Plazas</td>
                                <td style="width: 411px">
                                    <asp:TextBox ID="txtPlazas" runat="server" Width="76px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 86px">
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    <asp:Label ID="lblPregunta" runat="server" Text="Su Proyecto tiene Lista de Espera?"></asp:Label></td>
                                <td style="width: 411px">
                                    <asp:RadioButton ID="rbNo" runat="server" GroupName="rbPregunta" Text="NO" Checked="True" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbSi" runat="server" GroupName="rbPregunta" Text="SI" />
                                    &nbsp;
                                    <asp:RadioButton ID="rbEnOtraOpotunidad" runat="server" GroupName="rbPregunta" Text="CONTESTAR EN UNA PRÓXIMA OPORTUNIDAD" /><br />
                                    <asp:Label ID="lblFechaObligatoria" runat="server" Font-Bold="True" ForeColor="Red"
                                        Text="lblFechaObligatoria" Width="446px"></asp:Label></td>
                                <td style="width: 86px">
                            
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnContinuar" runat="server" Text="Continuar" OnClick="btnContinuar_Click" />
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table align="center" style="width: 70%">
                <tr>
                    <td style="width: 953px">
                        <asp:Panel ID="pnlDatos" runat="server" Visible="False" Width="70%">
                            <table style="width: 70%;" align="center" border="2">
                                <tr>
                                    <td style="width: 123px">
                                    </td>
                                    <td style="height: 152px">
                                        <table style="width: 784px">
                                            <tr>
                                                <td style="text-align: center" class="texto_form">
                                                    Niños(as) y adolescentes en Lista de Espera</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 768px">
                                                        <tr>
                                                            <td class="texto_form">
                                                                Femenino</td>
                                                            <td class="texto_form" style="width: 79px">
                                                                Masculino</td>
                                                            <td class="texto_form">
                                                                Total</td>
                                                            <td class="texto_form">
                                                                De estos, cuantos provienen de Tribunales y Fiscalías? Digite nº</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input id="txtFemenino2" runat="server" maxlength="3" style="width: 57px; text-align: right"
                                                                    type="text" value="0" onchange="javascript:f_suma()" name="txtFemenino2" /></td>
                                                            <td style="width: 79px">
                                                                <input id="txtMasculino2" runat="server" maxlength="3" style="width: 57px; text-align: right"
                                                                    type="text" value="0" onkeypress="f_SoloNumeros()" onchange="javascript:f_suma()"
                                                                    name="txtMasculino2" /></td>
                                                            <td>
                                                                <input id="txtTotal2" name="txtTotal2" runat="server" style="width: 61px; text-align: right"
                                                                    type="text" value="0" hidefocus="hideFocus" maxlength="4" readonly="readOnly" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtTribunales2" runat="server" Style="text-align: right" Width="97px"
                                                                    MaxLength="4">0</asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" Text="Debe ingresar algún valor"
                                                        Visible="False" Width="100%"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 3px; height: 152px">
                               
                                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGuarda" runat="server" Text="Guardar Encuesta" OnClick="btnGuarda_Click" /> 
                                        
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
