<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Encuesta_Digitadores.aspx.cs"
    Inherits="Encuesta_Digitadores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Panel ID="pnlHeader" runat="server" Width="100%">
                    <table style="width: 80%">
                        <tr>
                            <td>
                            </td>
                            <td style="text-align: justify" class="texto_form">
                                <p align="center" class="MsoNormal" style="margin: 0cm 0cm 0pt; text-align: center">
                                    <b style="mso-bidi-font-weight: normal"><span lang="ES" style="font-size: 14pt; color: #1f497d">
                                        <span><span style="font-family: Arial"><span style="color: #000000"></span></span></span>
                                    </span></b>
                                </p>
                                <p align="center" class="MsoNormal" style="margin: 0cm 0cm 0pt; text-align: center">
                                    <table style="width: 100%; height: 64px">
                                        <tr>
                                            <td style="text-align: center; height: 25px;">
                                                <strong><span style="font-size: 14pt">CUESTIONARIO PARA USUARIOS QUE REGISTRAN DATOS
                                                    EN SENAINFO</span></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <table style="width: 100%; height: 69px; text-align: center">
                                                    <tr>
                                                        <td style="width: 540px">
                                                            Con el fin de conocer el perfil de las personas que ingresan información a la Base
                                                            de Datos, se ha elaborado esta encuesta para realizar un diagnóstico y así poder
                                                            estudiar las mejoras necesarias, por lo que se agradece responderla ya que su información
                                                            es valiosa para este fin.</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </p>
                                <p align="center" class="MsoNormal" style="margin: 0cm 0cm 0pt; text-align: center">
                                    &nbsp;</p>
                                <p align="center" class="MsoNormal" style="margin: 0cm 0cm 0pt; text-align: center">
                                    <b style="mso-bidi-font-weight: normal"><span lang="ES" style="font-size: 14pt; color: #1f497d">
                                        <span><span style="font-family: Arial">
                                            <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?>
                                            <?xml namespace="" prefix="o" ?>
                                            <o:p></o:p>
                                        </span></span></span></b>&nbsp;</p>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table style="width: 45%">
                    <tr>
                        <td align="right">
                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAnterior" runat="server" BackColor="RoyalBlue" ForeColor="White"
                                Height="29px" Text="Anterior" Visible="False" Width="90px" OnClick="btnAnterior_Click" />&nbsp;
                        </td>
                        <td align="center">
                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnSiguiente" runat="server" BackColor="RoyalBlue" ForeColor="White"
                                Height="29px" OnClick="btnSiguiente_Click" Text="Siguiente" Width="90px" />&nbsp;
                        </td>
                        <td>
                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGrabar" runat="server" BackColor="RoyalBlue" ForeColor="White"
                                Height="29px" Text="Grabar" Visible="False" Width="90px" OnClick="btnGrabar_Click" />&nbsp;
                        </td>
                    </tr>
                </table>
                <b></b>
                <br />
                <table id="TABLE2" rules="all" style="width: 80%">
                    <tr>
                        <td class="texto_form">
                            <asp:Label ID="lblPregunta" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="17px"></asp:Label></td>
                    </tr>
                </table>
                <asp:Panel ID="pnlPregunta01" runat="server" Visible="true" Width="100%" Wrap="False"
                    Font-Names="Arial" Font-Size="9pt">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                        Visible="False">1. Hace cuánto tiempo que tiene entre sus funciones digitar en SENAINFO.</asp:Label><br />
                    <br />
                    <table rules="all" border="1">
                        <tr>
                            <td style="width: 53px">
                            </td>
                            <td style="width: 212px">
                                Responda en Número de Meses</td>
                            <td align="center">
                                <input id="txt_1" runat="server" atomicselection="true" maxlength="2" style="width: 52px"
                                    type="text" /></td>
                        </tr>
                    </table>
                    <br />
                    &nbsp;</asp:Panel>
                <asp:Panel ID="pnlPregunta02" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="TABLE3" rules="none" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">2. Generalmente cuantos días al mes digita en SENAINFO</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 223px">
                                            Responda en Número de Días al mes</td>
                                        <td align="center">
                                            &nbsp;<input id="txt_2a" runat="server" atomicselection="true" maxlength="2" style="width: 52px"
                                                type="text" /></td>
                                        <td align="center">
                                            ¿Generalmente cuántas horas diarias?</td>
                                        <td align="center">
                                            <input id="txt_2b" runat="server" atomicselection="true" maxlength="2" style="width: 52px"
                                                type="text" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta03" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="TABLE4" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">3. Usted está dedicado exclusivamente a esta función</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 261px">
                                                a. Sí, exclusivamente</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_3a" runat="server" atomicselection="true" contenteditable="true" name="rdb_3"
                                                    type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 261px">
                                                b. Comparto la función con otras tareas</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_3b" runat="server" atomicselection="true" contenteditable="true" name="rdb_3"
                                                    type="radio" value="2" />
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta04" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="TABLE5" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">4. Para digitar SENAINFO Usted recibió capacitación.</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. SI</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_4a" runat="server" atomicselection="true" contenteditable="true" name="rdb_4"
                                                    type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. NO</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_4b" runat="server" atomicselection="true" contenteditable="true" name="rdb_4"
                                                    type="radio" value="2" />
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta05" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="TABLE1" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">5. Si su respuesta es afirmativa ¿Cómo evalúa la capacitación?</asp:Label><br />
                                <table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. Suficiente</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_5a" runat="server" atomicselection="true" contenteditable="true" name="rdb_5"
                                                type="radio" value="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. Insuficiente</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_5b" runat="server" atomicselection="true" contenteditable="true" name="rdb_5"
                                                type="radio" value="2" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta06" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="TABLE6" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">6. Siente que actualmente sería adecuado recibir una capacitación en SENAINFO</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. Sí, es necesario</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_6a" runat="server" atomicselection="true" contenteditable="true" name="rdb_6"
                                                type="radio" value="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. No</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_6b" runat="server" atomicselection="true" contenteditable="true" name="rdb_6"
                                                type="radio" value="2" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta07" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table7" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">7. Cuál de las siguientes afirmaciones lo representa (Puede marcar más de una)</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. La tarea de Digitación es muy rutinaria</td>
                                        <td align="center" style="width: 87px">
                                            <input id="chk_7a" runat="server" type="checkbox" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. La Digitación No se me hace rutinaria porque a través de ella conozco la situación
                                            de los niños(as)</td>
                                        <td align="center" style="width: 87px">
                                            <input id="chk_7b" runat="server" type="checkbox" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            c. Considero que esta labor es importante para el funcionamiento del centro (o proyecto)</td>
                                        <td align="center" style="width: 87px">
                                            <input id="chk_7c" runat="server" type="checkbox" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            d. En el centro (o proyecto) valoran esta labor</td>
                                        <td align="center" style="width: 87px">
                                            <input id="chk_7d" runat="server" type="checkbox" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            e. Me gustaría mucho que me cambiaran de función aquí en el centro (o proyecto)</td>
                                        <td align="center" style="width: 87px">
                                            <input id="chk_7e" runat="server" type="checkbox" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            f. Me siento cómodo(a) en esta labor</td>
                                        <td align="center" style="width: 87px">
                                            <input id="chk_7f" runat="server" type="checkbox" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta08" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table8" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">8. El equipo computacional que usted utiliza para la digitación es:</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. De uso exclusivo</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_8a" runat="server" atomicselection="true" contenteditable="true" name="rdb_8"
                                                type="radio" value="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. Lo comparte con algunas personas (2 o menos)</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_8b" runat="server" atomicselection="true" contenteditable="true" name="rdb_8"
                                                type="radio" value="2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            c. Lo comparte con muchas personas</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_8c" runat="server" atomicselection="true" contenteditable="true" name="rdb_8"
                                                type="radio" value="3" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta09" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table9" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">9. El equipo computacional que usted utiliza para la digitación es:</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. Rápido siempre</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_9a" runat="server" atomicselection="true" contenteditable="true" name="rdb_9"
                                                type="radio" value="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. Rápido a veces</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_9b" runat="server" atomicselection="true" contenteditable="true" name="rdb_9"
                                                type="radio" value="2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            c. Lento</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_9c" runat="server" atomicselection="true" contenteditable="true" name="rdb_9"
                                                type="radio" value="3" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta10" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table10" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">10. La Conexión a Internet Ud. cómo la evalúa</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. Rápida</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_10a" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_10" type="radio" value="1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. Rápida a veces</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_10b" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_10" type="radio" value="2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            c. Lenta</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_10c" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_10" type="radio" value="3" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta11" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table11" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">11. El lugar que existe en el Centro o Proyecto para Digitar es:</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                        </td>
                                        <td align="center" class="texto_form" style="width: 87px">
                                            SI</td>
                                        <td align="center" class="texto_form" style="width: 87px">
                                            MEDIANAMENTE</td>
                                        <td align="center" class="texto_form" style="width: 87px">
                                            NO</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. Tiene la Luz necesaria</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11a1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11a" type="radio" value="1" />
                                        </td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11a2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11a" type="radio" value="2" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11a3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11a" type="radio" value="3" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. Tiene el silencio necesario</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11b1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11b" type="radio" value="1" />
                                        </td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11b2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11b" type="radio" value="2" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11b3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11b" type="radio" value="3" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            c. Tiene la amplitud necesaria</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11c1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11c" type="radio" value="1" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11c2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11c" type="radio" value="2" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11c3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11c" type="radio" value="3" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            d. Es limpio</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11d1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11d" type="radio" value="1" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11d2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11d" type="radio" value="2" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11d3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11d" type="radio" value="3" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            e. Permite concentrarse en la tarea</td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11e1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11e" type="radio" value="1" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11e2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11e" type="radio" value="2" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="rdb_11e3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_11e" type="radio" value="3" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta12" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table12" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">12. Indique el tipo de información que digita en SENAINFO y evalúe la facilidad de la pantalla.</asp:Label><br />
                                &nbsp;<table rules="all" border="1">
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            Indique si ingresa la siguiente información</td>
                                        <td align="center" style="width: 87px">
                                        </td>
                                        <td align="center" class="texto_form" style="width: 325px">
                                            Evalúe la facilidad que otorga SENAINFO en estos Módulos</td>
                                        <td align="center" class="texto_form" style="width: 87px">
                                            &nbsp;Observaciones</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            a. Ingresos y Egresos de niños</td>
                                        <td align="center" style="width: 87px" title="SI">
                                            SI
                                            <input id="rdb_12a1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12a1" type="radio" value="1" />
                                            NO
                                            <input id="rdb_12a2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12a1" type="radio" value="0" /></td>
                                        <td align="center" style="width: 325px" title="SI">
                                            <span style="font-size: 9pt; line-height: 115%; font-family: 'Tahoma','sans-serif';
                                                mso-fareast-font-family: Calibri; mso-ansi-language: ES-CL; mso-fareast-language: EN-US;
                                                mso-bidi-language: AR-SA"></span>Fácil
                                            <input id="rdb_12a3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12a2" type="radio" value="1" />
                                            Difícil a veces
                                            <input id="rdb_12a4" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12a2" type="radio" value="2" />
                                            Difícil siempre
                                            <input id="rdb_12a5" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12a2" type="radio" value="3" /></td>
                                        <td align="center" style="width: 87px">
                                            <input id="txt_12a" runat="server" maxlength="400" type="text" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            b. Diagnósticos del niño (escolar, social y otros)</td>
                                        <td align="center" style="width: 87px">
                                            SI
                                            <input id="rdb_12b1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12b1" type="radio" value="1" />
                                            NO
                                            <input id="rdb_12b2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12b1" type="radio" value="0" /></td>
                                        <td align="center" style="width: 325px">
                                            Fácil
                                            <input id="rdb_12b3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12b2" type="radio" value="1" />
                                            Difícil a veces
                                            <input id="rdb_12b4" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12b2" type="radio" value="2" />
                                            Difícil siempre
                                            <input id="rdb_12b5" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12b2" type="radio" value="3" />&nbsp;</td>
                                        <td align="center" style="width: 87px">
                                            <input id="txt_12b" runat="server" maxlength="400" type="text" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            c. Datos de Gestión (Diligencias, salud, personas relacionadas y otros)</td>
                                        <td align="center" style="width: 87px">
                                            SI
                                            <input id="rdb_12c1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12c1" type="radio" value="1" />
                                            NO
                                            <input id="rdb_12c2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12c1" type="radio" value="0" /></td>
                                        <td align="center" style="width: 325px">
                                            Fácil
                                            <input id="rdb_12c3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12c2" type="radio" value="1" />
                                            Difícil a veces
                                            <input id="rdb_12c4" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12c2" type="radio" value="2" />
                                            Difícil siempre
                                            <input id="rdb_12c5" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12c2" type="radio" value="3" />&nbsp;</td>
                                        <td align="center" style="width: 87px">
                                            <input id="txt_12c" runat="server" maxlength="400" type="text" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            d. Planes de Intervención</td>
                                        <td align="center" style="width: 87px">
                                            SI
                                            <input id="rdb_12d1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12d1" type="radio" value="1" />
                                            NO
                                            <input id="rdb_12d2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12d1" type="radio" value="0" /></td>
                                        <td align="center" style="width: 325px">
                                            Fácil
                                            <input id="rdb_12d3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12d2" type="radio" value="1" />
                                            Difícil a veces
                                            <input id="rdb_12d4" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12d2" type="radio" value="2" />
                                            Difícil siempre
                                            <input id="rdb_12d5" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12d2" type="radio" value="3" />&nbsp;</td>
                                        <td align="center" style="width: 87px">
                                            <input id="txt_12d" runat="server" maxlength="400" type="text" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            e. Diligencias</td>
                                        <td align="center" style="width: 87px">
                                            SI
                                            <input id="rdb_12e1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12e1" type="radio" value="1" />
                                            NO
                                            <input id="rdb_12e2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12e1" type="radio" value="0" /></td>
                                        <td align="center" style="width: 325px">
                                            Fácil
                                            <input id="rdb_12e3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12e2" type="radio" value="1" />
                                            Difícil a veces
                                            <input id="rdb_12e4" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12e2" type="radio" value="2" />
                                            Difícil siempre
                                            <input id="rdb_12e5" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12e2" type="radio" value="3" />&nbsp;</td>
                                        <td align="center" style="width: 87px">
                                            <input id="txt_12e" runat="server" maxlength="400" type="text" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                        </td>
                                        <td style="width: 260px">
                                            f. Rendición de Cuentas</td>
                                        <td align="center" style="width: 87px">
                                            SI
                                            <input id="rdb_12f1" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12f1" type="radio" value="1" />
                                            NO
                                            <input id="rdb_12f2" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12f1" type="radio" value="0" /></td>
                                        <td align="center" style="width: 325px">
                                            Fácil
                                            <input id="rdb_12f3" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12f2" type="radio" value="1" />
                                            Difícil a veces
                                            <input id="rdb_12f4" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12f2" type="radio" value="2" />
                                            Difícil siempre
                                            <input id="rdb_12f5" runat="server" atomicselection="true" contenteditable="true"
                                                name="rdb_12f2" type="radio" value="3" />&nbsp;</td>
                                        <td align="center" style="width: 87px">
                                            <input id="txt_12f" runat="server" maxlength="400" type="text" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta13" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table13" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">13. Las Causales de ingreso del Área de PROTECCIÓN  ¿representan adecuadamente la situación de ingreso de los niños(as) y adolescentes?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. SI</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_13a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_13" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. NO</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_13b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_13" type="radio" value="2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                c. NO SABE</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_13c" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_13" type="radio" value="3" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                d. NO ES APLICABLE</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_13d" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_13" type="radio" value="4" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta14" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table14" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">14. Las Causales de ingreso (o delito) del Área de JUSTICIA JUVENIL  ¿representan adecuadamente la situación de ingreso de los adolescentes?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. SI</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_14a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_14" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. NO</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_14b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_14" type="radio" value="2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                c. NO SABE</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_14c" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_14" type="radio" value="3" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                d. NO ES APLICABLE</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_14d" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_14" type="radio" value="4" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta15" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table15" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">15. Cuándo llega un niño(a) o adolescente llega al centro o proyecto ¿encuentra DIFICIL o FACIL determinar cuál es la Causal de INGRESO de la SENAINFO a asignarle?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. Fácil</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_15a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_15" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. Difícil a veces</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_15b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_15" type="radio" value="2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                c. Difícil siempre</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_15c" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_15" type="radio" value="3" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta16" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table16" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">16. Las Causales de EGRESO del Área de PROTECCIÓN  ¿representan adecuadamente la situación de egreso de los niños(as) y adolescentes?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. SI</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_16a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_16" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. NO</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_16b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_16" type="radio" value="2" />
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta17" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table17" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">17. Las Causales de EGRESO del área de JUSTICIA JUVENIL  ¿representan adecuadamente la situación de egreso de los adolescentes?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. SI</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_17a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_17" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. NO</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_17b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_17" type="radio" value="2" />
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta18" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table18" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">18. Cuándo se va un niño(a) o adolescente del centro o proyecto ¿encuentra DIFICIL o FACIL determinar cuál es la Causal de EGRESO de la SENAINFO a asignarle?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. Fácil</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_18a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_18" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. Difícil a veces</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_18b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_18" type="radio" value="2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                c. Difícil siempre</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_18c" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_18" type="radio" value="3" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta19" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table19" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">19. Los antecedentes que usted recibe para digitar la información de un niño(a) en SENAINFO, encuentra que:</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. Son Completos y Claros</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_19a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_19" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. Relativamente completos y claros</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_19b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_19" type="radio" value="2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                c. Incompletos y poco claros</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_19c" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_19" type="radio" value="3" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta20" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table20" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">20. ¿Generalmente quién le hace llegar los antecedentes de un niño(a) para digitarlo en SENAINFO?</asp:Label>&nbsp;<table
                                        rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                <input id="txt_20" runat="server" maxlength="400" type="text" style="width: 523px" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPregunta21" runat="server" Visible="False" Width="100%" Font-Names="Arial"
                    Font-Size="9pt">
                    <table id="Table21" rules="all" style="width: 80%">
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                                    Visible="False">21. Cuál es su escolaridad</asp:Label>&nbsp;<table rules="all" border="1">
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                a. Enseñanza Media o Técnica Incompleta</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_21a" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_21" type="radio" value="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                b. Enseñanza Media o Técnica Completa</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_21b" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_21" type="radio" value="2" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                c. Estudios Superiores Incompletos</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_21c" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_21" type="radio" value="3" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                d. Estudios Superiores Completos</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_21d" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_21" type="radio" value="4" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 53px">
                                            </td>
                                            <td style="width: 260px">
                                                e. Otros ¿Cuál?</td>
                                            <td align="center" style="width: 87px">
                                                <input id="rdb_21e" runat="server" atomicselection="true" contenteditable="true"
                                                    name="rdb_21" type="radio" value="4" /></td>
                                            <td align="center" style="width: 87px">
                                                <input id="txt_21" runat="server" maxlength="400" type="text" /></td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
