<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="EncuestaSenHistorico.aspx.cs" Inherits="EncuestaSenHistorico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <link href="css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlHeader" runat="server" Width=100%>
        <table style="width: 80%">
            <tr>
                <td>
                </td>
                <td style="text-align: justify">
                    <p align="center" class="MsoNormal" style="margin: 0cm 0cm 0pt; text-align: center">
                        <b style="mso-bidi-font-weight: normal"><span lang="ES" style="font-size: 14pt; color: #1f497d">
                            <span><span style="font-family: Arial">ENCUESTA EVALUACIÓN USO DEL SITIO HISTÓRICO
                                <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></span></span></b></p>
                    <p class="MsoNormal" style="margin: 0cm 0cm 0pt; text-align: justify">
                        <b style="mso-bidi-font-weight: normal"><span lang="ES" style="font-size: 12pt; color: #1f497d;">
                            <span style="font-family: Arial">
                            <o:p>&nbsp;</o:p>
                            &nbsp; </span>
                        </span></b>
                    </p>
                    <b style="mso-bidi-font-weight: normal"><span lang="ES" style="font-size: 11pt; color: #1f497d;
                        font-family: Arial; mso-fareast-font-family: Calibri; mso-bidi-font-family: 'Times New Roman';
                        mso-ansi-language: ES; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span
                            style="font-size: 14pt; color: #1f497d; line-height: 115%; font-family: 'Calibri','sans-serif';
                            mso-fareast-font-family: Calibri; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: ES-CL;
                            mso-fareast-language: EN-US; mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin;
                            mso-fareast-theme-font: minor-latin; mso-hansi-theme-font: minor-latin; mso-bidi-theme-font: minor-bidi;
                            mso-themecolor: text2">Agradecemos contestar esta encuesta que nos permitirá evaluar
                            el uso y utilidad que presta el Sitio Histórico con sus dos módulos <b style="mso-bidi-font-weight: normal">
                                Información para Supervisión</b> e <b style="mso-bidi-font-weight: normal">Información
                                    Histórica</b>.</span></span></b></td>
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
        <b>
        </b>
            <table style="width: 80%" id="TABLE2" rules="all">
                <tr>
                    <td class="texto_form">
                        <asp:Label ID="lblPregunta" runat="server" Font-Names="Arial" Font-Bold="True" Font-Size="12px"></asp:Label></td>
                </tr>
            </table>
        <asp:Panel ID="pnlPregunta01" runat="server" Width = 100% Visible="true" Wrap="False">
            <table rules="all">
                <tr>
                    <td style="width: 53px">
                    </td>
                    <td style="width: 212px">
                    </td>
                    <td class="texto_form" align=center>
                        Indique si corresponde</td>
                </tr>
                <tr>
                    <td style="width: 53px">
                    </td>
                    <td style="width: 212px">
                        a. Nunca lo he utilizado</td>
                    <td align=center>
                        <input id="rdb_1a" atomicselection="true" name="rdb_1" type="radio"
                            value="1" contenteditable="true" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td style="width: 53px">
                    </td>
                    <td style="width: 212px">
                        b. Lo utilizo</td>
                    <td align=center>
                        <input id="rdb_1b" atomicselection="true" name="rdb_1" type="radio"
                            value="2" contenteditable="true" runat="server" />
                        </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPregunta02" runat="server" Width = 100% Visible="False">
            <table style="width: 80%" id="TABLE3" rules="none">
                <tr>
                    <td>
                        &nbsp;<table rules="all">
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                </td>
                                <td class="texto_form" align=center>
                                    Indique si corresponde</td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    a. Desconocía la existencia del SENHISTÓRICO</td>
                                <td align=center><input id="rdb_2a" atomicselection="true" name="rdb_2" type="radio"
                            value="1" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    b. Es muy difícil de manejar</td>
                                <td align=center><input id="rdb_2b" atomicselection="true" name="rdb_2" type="radio"
                            value="2" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    c. Desconozco el manejo necesario del Excel</td>
                                <td align="center"><input id="rdb_2c" atomicselection="true" name="rdb_2" type="radio"
                            value="3" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    d. No me sirve</td>
                                <td align="center"><input id="rdb_2d" atomicselection="true" name="rdb_2" type="radio"
                            value="4" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    e. No tengo acceso a un computador</td>
                                <td align="center"><input id="rdb_2e" atomicselection="true" name="rdb_2" type="radio"
                            value="5" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    f. Me falta capacitación para su uso</td>
                                <td align="center"><input id="rdb_2f" atomicselection="true" name="rdb_2" type="radio"
                            value="6" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 449px">
                                    g. Otros explicite:<br />
                                    <table style="width: 441px; height: 115px">
                                        <tr>
                                            <td style="width: 183px">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtObservacionPregunta02" runat="server" Height="101px" Width="334px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center"><input id="rdb_2g" atomicselection="true" name="rdb_2" type="radio"
                            value="7" contenteditable="true" runat="server" />
                                    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPregunta03" runat="server" Width = 100% Visible="False">
            <table style="width: 80%" id="TABLE4" rules="all">
                <tr>
                    <td>
                        &nbsp;<table rules="all">
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 261px">
                                </td>
                                <td class="texto_form" align=center style="width: 87px">
                                    Accedo al sitio con mi clave</td>
                                <td align="center" class="texto_form" style="width: 87px">
                                    Solicito el reporte a otro cuando lo requiero</td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 261px">
                                    a. Sólo esporádicamente</td>
                                <td align=center style="width: 87px"><input id="rdb_3a1" atomicselection="true" name="rdb_3a" type="radio"
                            value="1" contenteditable="true" runat="server" />
                                </td>
                                <td align="center" style="width: 87px"><input id="rdb_3a2" atomicselection="true" name="rdb_3a" type="radio"
                            value="2" contenteditable="true" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 261px">
                                    b. Siempre que requiero información</td>
                                <td align=center style="width: 87px"><input id="rdb_3b1" atomicselection="true" name="rdb_3b" type="radio"
                            value="3" contenteditable="true" runat="server" />
                                </td>
                                <td align="center" style="width: 87px"><input id="rdb_3b2" atomicselection="true" name="rdb_3b" type="radio"
                            value="4" contenteditable="true" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPregunta04" runat="server" Width = 100% Visible="False">
            <table style="width: 80%" id="TABLE5" rules="all">
                <tr>
                    <td>
                        &nbsp;<table rules="all">
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 260px">
                                </td>
                                <td class="texto_form" align=center>
                                    Indique si corresponde</td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 260px">
                                    a. Sólo Información Histórica</td>
                                <td align=center><input id="rdb_4a" atomicselection="true" name="rdb_4" type="radio"
                            value="1" contenteditable="true" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 260px">
                                    b. Sólo Información para Supervisión</td>
                                <td align=center><input id="rdb_4b" atomicselection="true" name="rdb_4" type="radio"
                            value="2" contenteditable="true" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 260px">
                                    c. Ambos Módulos según lo que necesite</td>
                                <td align="center"><input id="rdb_4c" atomicselection="true" name="rdb_4" type="radio"
                            value="3" contenteditable="true" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPregunta05" runat="server" Width = 100% Visible="False">
            <table style="width: 80%" id="TABLE1" rules="all">
                <tr>
                    <td>
                        &nbsp;<table rules="all">
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                </td>
                                <td class="texto_form" align=center style="width: 88px">
                                    Muy útil y completo</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    Demasiada información</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    Le falta información</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    Muy complejo</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    No me sirve</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    No lo uso</td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    <strong>Protección y Primera Infancia</strong></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                            </tr>
                            <tr>
                                <td style="width: 53px; height: 2px;">
                                </td>
                                <td style="width: 554px; height: 2px;">
                                    Excel: Nomina</td>
                                <td align=center style="width: 88px;"><input id="rdb_5a1" atomicselection="true" name="rdb_5a" type="radio"
                            value="1" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px;">
                                    <input id="rdb_5a2" atomicselection="true" name="rdb_5a" type="radio"
                            value="2" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px;"><input id="rdb_5a3" atomicselection="true" name="rdb_5a" type="radio"
                            value="3" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px;"><input id="rdb_5a4" atomicselection="true" name="rdb_5a" type="radio"
                            value="4" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px;"><input id="rdb_5a5" atomicselection="true" name="rdb_5a" type="radio"
                            value="5" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px;"><input id="rdb_5a6" atomicselection="true" name="rdb_5a" type="radio"
                            value="6" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Eventos de Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_5b1" atomicselection="true" name="rdb_5b" type="radio"
                            value="7" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5b2" atomicselection="true" name="rdb_5b" type="radio"
                            value="8" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5b3" atomicselection="true" name="rdb_5b" type="radio"
                            value="9" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5b4" atomicselection="true" name="rdb_5b" type="radio"
                            value="10" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5b5" atomicselection="true" name="rdb_5b" type="radio"
                            value="11" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5b6" atomicselection="true" name="rdb_5b" type="radio"
                            value="12" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Edad y Sexo</td>
                                <td align=center style="width: 88px"><input id="rdb_5c1" atomicselection="true" name="rdb_5c" type="radio"
                            value="13" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5c2" atomicselection="true" name="rdb_5c" type="radio"
                            value="14" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5c3" atomicselection="true" name="rdb_5c" type="radio"
                            value="15" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5c4" atomicselection="true" name="rdb_5c" type="radio"
                            value="16" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5c5" atomicselection="true" name="rdb_5c" type="radio"
                            value="17" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5c6" atomicselection="true" name="rdb_5c" type="radio"
                            value="18" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Permanencias</td>
                                <td align=center style="width: 88px"><input id="rdb_5d1" atomicselection="true" name="rdb_5d" type="radio"
                            value="19" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5d2" atomicselection="true" name="rdb_5d" type="radio"
                            value="20" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5d3" atomicselection="true" name="rdb_5d" type="radio"
                            value="21" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5d4" atomicselection="true" name="rdb_5d" type="radio"
                            value="22" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5d5" atomicselection="true" name="rdb_5d" type="radio"
                            value="23" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5d6" atomicselection="true" name="rdb_5d" type="radio"
                            value="24" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Causales Ingreso, Quien solicita Ingreso</td>
                                <td align=center style="width: 88px"><input id="rdb_5e1" atomicselection="true" name="rdb_5e" type="radio"
                            value="25" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5e2" atomicselection="true" name="rdb_5e" type="radio"
                            value="26" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5e3" atomicselection="true" name="rdb_5e" type="radio"
                            value="27" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5e4" atomicselection="true" name="rdb_5e" type="radio"
                            value="28" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5e5" atomicselection="true" name="rdb_5e" type="radio"
                            value="29" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5e6" atomicselection="true" name="rdb_5e" type="radio"
                            value="30" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Egresos</td>
                                <td align=center style="width: 88px"><input id="rdb_5f1" atomicselection="true" name="rdb_5f" type="radio"
                            value="31" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5f2" atomicselection="true" name="rdb_5f" type="radio"
                            value="32" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5f3" atomicselection="true" name="rdb_5f" type="radio"
                            value="33" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5f4" atomicselection="true" name="rdb_5f" type="radio"
                            value="34" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5f5" atomicselection="true" name="rdb_5f" type="radio"
                            value="35" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5f6" atomicselection="true" name="rdb_5f" type="radio"
                            value="36" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Eventos de Proyectos</td>
                                <td align=center style="width: 88px"><input id="rdb_5g1" atomicselection="true" name="rdb_5g" type="radio"
                            value="37" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5g2" atomicselection="true" name="rdb_5g" type="radio"
                            value="38" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5g3" atomicselection="true" name="rdb_5g" type="radio"
                            value="39" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5g4" atomicselection="true" name="rdb_5g" type="radio"
                            value="40" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5g5" atomicselection="true" name="rdb_5g" type="radio"
                            value="41" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5g6" atomicselection="true" name="rdb_5g" type="radio"
                            value="42" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Niños/as 80 bis</td>
                                <td align=center style="width: 88px"><input id="rdb_5h1" atomicselection="true" name="rdb_5h" type="radio"
                            value="43" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5h2" atomicselection="true" name="rdb_5h" type="radio"
                            value="44" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5h3" atomicselection="true" name="rdb_5h" type="radio"
                            value="45" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5h4" atomicselection="true" name="rdb_5h" type="radio"
                            value="46" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5h5" atomicselection="true" name="rdb_5h" type="radio"
                            value="47" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5h6" atomicselection="true" name="rdb_5h" type="radio"
                            value="48" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Egresos Favorables PRF</td>
                                <td align=center style="width: 88px"><input id="rdb_5i1" atomicselection="true" name="rdb_5i" type="radio"
                            value="49" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5i2" atomicselection="true" name="rdb_5i" type="radio"
                            value="50" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5i3" atomicselection="true" name="rdb_5i" type="radio"
                            value="51" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5i4" atomicselection="true" name="rdb_5i" type="radio"
                            value="52" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5i5" atomicselection="true" name="rdb_5i" type="radio"
                            value="53" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5i6" atomicselection="true" name="rdb_5i" type="radio"
                            value="54" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Diagnósticos PIE</td>
                                <td align=center style="width: 88px"><input id="rdb_5j1" atomicselection="true" name="rdb_5j" type="radio"
                            value="55" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5j2" atomicselection="true" name="rdb_5j" type="radio"
                            value="56" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5j3" atomicselection="true" name="rdb_5j" type="radio"
                            value="57" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5j4" atomicselection="true" name="rdb_5j" type="radio"
                            value="58" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5j5" atomicselection="true" name="rdb_5j" type="radio"
                            value="59" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5j6" atomicselection="true" name="rdb_5j" type="radio"
                            value="60" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Nomina - Atendidos PIE y LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_5k1" atomicselection="true" name="rdb_5k" type="radio"
                            value="61" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5k2" atomicselection="true" name="rdb_5k" type="radio"
                            value="62" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5k3" atomicselection="true" name="rdb_5k" type="radio"
                            value="63" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5k4" atomicselection="true" name="rdb_5k" type="radio"
                            value="64" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5k5" atomicselection="true" name="rdb_5k" type="radio"
                            value="65" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5k6" atomicselection="true" name="rdb_5k" type="radio"
                            value="66" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Atenciones SIMULTANEAS en la RED SENAME ( Sólo último mes)</td>
                                <td align=center style="width: 88px"><input id="rdb_5l1" atomicselection="true" name="rdb_5l" type="radio"
                            value="67" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5l2" atomicselection="true" name="rdb_5l" type="radio"
                            value="68" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5l3" atomicselection="true" name="rdb_5l" type="radio"
                            value="69" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5l4" atomicselection="true" name="rdb_5l" type="radio"
                            value="70" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5l5" atomicselection="true" name="rdb_5l" type="radio"
                            value="71" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5l6" atomicselection="true" name="rdb_5l" type="radio"
                            value="72" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Nómina Casos Inimputables</td>
                                <td align=center style="width: 88px"><input id="rdb_5ll1" atomicselection="true" name="rdb_5ll" type="radio"
                            value="73" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5ll2" atomicselection="true" name="rdb_5ll" type="radio"
                            value="74" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5ll3" atomicselection="true" name="rdb_5ll" type="radio"
                            value="75" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5ll4" atomicselection="true" name="rdb_5ll" type="radio"
                            value="76" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5ll5" atomicselection="true" name="rdb_5ll" type="radio"
                            value="77" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5ll6" atomicselection="true" name="rdb_5ll" type="radio"
                            value="78" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Historial Casos Inimputables</td>
                                <td align=center style="width: 88px"><input id="rdb_5m1" atomicselection="true" name="rdb_5m" type="radio"
                            value="79" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5m2" atomicselection="true" name="rdb_5m" type="radio"
                            value="80" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5m3" atomicselection="true" name="rdb_5m" type="radio"
                            value="81" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5m4" atomicselection="true" name="rdb_5m" type="radio"
                            value="82" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5m5" atomicselection="true" name="rdb_5m" type="radio"
                            value="83" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5m6" atomicselection="true" name="rdb_5m" type="radio"
                            value="84" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Diligencias Realizadas en el Periodo</td>
                                <td align=center style="width: 88px"><input id="rdb_5n1" atomicselection="true" name="rdb_5n" type="radio"
                            value="85" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5n2" atomicselection="true" name="rdb_5n" type="radio"
                            value="86" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5n3" atomicselection="true" name="rdb_5n" type="radio"
                            value="87" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5n4" atomicselection="true" name="rdb_5n" type="radio"
                            value="0" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5n5" atomicselection="true" name="rdb_5n" type="radio"
                            value="88" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5n6" atomicselection="true" name="rdb_5n" type="radio"
                            value="89" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Datos Plan de Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_5o1" atomicselection="true" name="rdb_5o" type="radio"
                            value="90" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5o2" atomicselection="true" name="rdb_5o" type="radio"
                            value="91" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5o3" atomicselection="true" name="rdb_5o" type="radio"
                            value="92" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5o4" atomicselection="true" name="rdb_5o" type="radio"
                            value="93" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5o5" atomicselection="true" name="rdb_5o" type="radio"
                            value="94" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5o6" atomicselection="true" name="rdb_5o" type="radio"
                            value="95" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    <strong>Justicia Juvenil</strong></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Nomina de Jóvenes LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_5p1" atomicselection="true" name="rdb_5p" type="radio"
                            value="96" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5p2" atomicselection="true" name="rdb_5p" type="radio"
                            value="97" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5p3" atomicselection="true" name="rdb_5p" type="radio"
                            value="98" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5p4" atomicselection="true" name="rdb_5p" type="radio"
                            value="99" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5p5" atomicselection="true" name="rdb_5p" type="radio"
                            value="100" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5p6" atomicselection="true" name="rdb_5p" type="radio"
                            value="101" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Sanciones Nomina de Jóvenes  LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_5q1" atomicselection="true" name="rdb_5q" type="radio"
                            value="102" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5q2" atomicselection="true" name="rdb_5q" type="radio"
                            value="103" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5q3" atomicselection="true" name="rdb_5q" type="radio"
                            value="104" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5q4" atomicselection="true" name="rdb_5q" type="radio"
                            value="105" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5q5" atomicselection="true" name="rdb_5q" type="radio"
                            value="106" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5q6" atomicselection="true" name="rdb_5q" type="radio"
                            value="107" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Nomina - Eventos de Intervención LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_5r1" atomicselection="true" name="rdb_5r" type="radio"
                            value="108" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5r2" atomicselection="true" name="rdb_5r" type="radio"
                            value="109" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5r3" atomicselection="true" name="rdb_5r" type="radio"
                            value="110" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5r4" atomicselection="true" name="rdb_5r" type="radio"
                            value="112" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5r5" atomicselection="true" name="rdb_5r" type="radio"
                            value="113" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5r6" atomicselection="true" name="rdb_5r" type="radio"
                            value="114" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Nomina - Atendidos LRPA SIMULTANEAMENTE</td>
                                <td align=center style="width: 88px"><input id="rdb_5s1" atomicselection="true" name="rdb_5s" type="radio"
                            value="115" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5s2" atomicselection="true" name="rdb_5s" type="radio"
                            value="116" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5s3" atomicselection="true" name="rdb_5s" type="radio"
                            value="117" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5s4" atomicselection="true" name="rdb_5s" type="radio"
                            value="118" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5s5" atomicselection="true" name="rdb_5s" type="radio"
                            value="119" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5s6" atomicselection="true" name="rdb_5s" type="radio"
                            value="120" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    <strong>Financiero y otras generales</strong></td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Rendición Cuentas</td>
                                <td align=center style="width: 88px"><input id="rdb_5t1" atomicselection="true" name="rdb_5t" type="radio"
                            value="121" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_5t2" atomicselection="true" name="rdb_5t" type="radio"
                            value="122" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_5t3" atomicselection="true" name="rdb_5t" type="radio"
                            value="123" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_5t4" atomicselection="true" name="rdb_5t" type="radio"
                            value="124" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_5t5" atomicselection="true" name="rdb_5t" type="radio"
                            value="125" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_5t6" atomicselection="true" name="rdb_5t" type="radio"
                            value="126" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Rendición de Cuentas - Saldos</td>
                                <td align=center style="width: 88px"><input id="rdb_5u1" atomicselection="true" name="rdb_5u" type="radio"
                            value="127" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5u2" atomicselection="true" name="rdb_5u" type="radio"
                            value="128" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5u3" atomicselection="true" name="rdb_5u" type="radio"
                            value="129" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5u4" atomicselection="true" name="rdb_5u" type="radio"
                            value="130" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5u5" atomicselection="true" name="rdb_5u" type="radio"
                            value="131" contenteditable="true" runat="server" /></td>
                                <td align="center" style="width: 88px"><input id="rdb_5u6" atomicselection="true" name="rdb_5u" type="radio"
                            value="132" contenteditable="true" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel:  Atenciones, Sobre Atención, Factores de Pago, Montos</td>
                                <td align=center style="width: 88px"><input id="rdb_5v1" atomicselection="true" name="rdb_5v" type="radio"
                            value="133" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5v2" atomicselection="true" name="rdb_5v" type="radio"
                            value="134" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5v3" atomicselection="true" name="rdb_5v" type="radio"
                            value="135" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5v4" atomicselection="true" name="rdb_5v" type="radio"
                            value="136" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5v5" atomicselection="true" name="rdb_5v" type="radio"
                            value="137" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5v6" atomicselection="true" name="rdb_5v" type="radio"
                            value="138" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel:  Atenciones, Sub Atención, Sobre Atención - por Mes</td>
                                <td align=center style="width: 88px"><input id="rdb_5w1" atomicselection="true" name="rdb_5w" type="radio"
                            value="139" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5w2" atomicselection="true" name="rdb_5w" type="radio"
                            value="140" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5w3" atomicselection="true" name="rdb_5w" type="radio"
                            value="141" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5w4" atomicselection="true" name="rdb_5w" type="radio"
                            value="142" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5w5" atomicselection="true" name="rdb_5w" type="radio"
                            value="143" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5w6" atomicselection="true" name="rdb_5w" type="radio"
                            value="144" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Reporte niños/as - 80 BIS</td>
                                <td align=center style="width: 88px"><input id="rdb_5x1" atomicselection="true" name="rdb_5x" type="radio"
                            value="145" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5x2" atomicselection="true" name="rdb_5x" type="radio"
                            value="146" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5x3" atomicselection="true" name="rdb_5x" type="radio"
                            value="147" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5x4" atomicselection="true" name="rdb_5x" type="radio"
                            value="148" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5x5" atomicselection="true" name="rdb_5x" type="radio"
                            value="149" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5x6" atomicselection="true" name="rdb_5x" type="radio"
                            value="150" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Proyectos Vigentes en el periodo</td>
                                <td align=center style="width: 88px"><input id="rdb_5y1" atomicselection="true" name="rdb_5y" type="radio"
                            value="151" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5y2" atomicselection="true" name="rdb_5y" type="radio"
                            value="152" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5y3" atomicselection="true" name="rdb_5y" type="radio"
                            value="153" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5y4" atomicselection="true" name="rdb_5y" type="radio"
                            value="154" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5y5" atomicselection="true" name="rdb_5y" type="radio"
                            value="155" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5y6" atomicselection="true" name="rdb_5y" type="radio"
                            value="156" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 554px">
                                    Excel: Resoluciones de los Proyectos Vigentes en el periodo</td>
                                <td align=center style="width: 88px"><input id="rdb_5z1" atomicselection="true" name="rdb_5z" type="radio"
                            value="157" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5z2" atomicselection="true" name="rdb_5z" type="radio"
                            value="158" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5z3" atomicselection="true" name="rdb_5z" type="radio"
                            value="159" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5z4" atomicselection="true" name="rdb_5z" type="radio"
                            value="160" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5z5" atomicselection="true" name="rdb_5z" type="radio"
                            value="161" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_5z6" atomicselection="true" name="rdb_5z" type="radio"
                            value="162" contenteditable="true" runat="server"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPregunta06" runat="server" Width = 100% Visible="False">
            <table style="width: 80%" id="TABLE6" rules="all">
                <tr>
                    <td>
                        &nbsp;<table rules="all">
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                </td>
                                <td class="texto_form" align=center style="width: 88px">
                                    Muy útil y completo</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    Demasiada información</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    Le falta información</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    Muy complejo</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    No me sirve</td>
                                <td align="center" class="texto_form" style="width: 88px">
                                    No lo uso</td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    <strong>Protección y Primera Infancia</strong></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                                <td align="center" style="width: 88px"></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Residencia Cuadros</td>
                                <td align=center style="width: 88px"><input id="rdb_6a1" atomicselection="true" name="rdb_6a" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6a2" atomicselection="true" name="rdb_6a" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6a3" atomicselection="true" name="rdb_6a" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6a4" atomicselection="true" name="rdb_6a" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6a5" atomicselection="true" name="rdb_6a" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6a6" atomicselection="true" name="rdb_6a" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Residencia Eventos Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_6b1" atomicselection="true" name="rdb_6b" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6b2" atomicselection="true" name="rdb_6b" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6b3" atomicselection="true" name="rdb_6b" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6b4" atomicselection="true" name="rdb_6b" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6b5" atomicselection="true" name="rdb_6b" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6b6" atomicselection="true" name="rdb_6b" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Residencia Nómina</td>
                                <td align=center style="width: 88px"><input id="rdb_6c1" atomicselection="true" name="rdb_6c" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6c2" atomicselection="true" name="rdb_6c" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6c3" atomicselection="true" name="rdb_6c" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6c4" atomicselection="true" name="rdb_6c" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6c5" atomicselection="true" name="rdb_6c" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6c6" atomicselection="true" name="rdb_6c" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión DAM - CTD</td>
                                <td align=center style="width: 88px"><input id="rdb_6d1" atomicselection="true" name="rdb_6d" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_6d2" atomicselection="true" name="rdb_6d" type="radio"
                            value="21" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_6d3" atomicselection="true" name="rdb_6d" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_6d4" atomicselection="true" name="rdb_6d" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_6d5" atomicselection="true" name="rdb_6d" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px">
                                    <input id="rdb_6d6" atomicselection="true" name="rdb_6d" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Nómina DAM - CTD</td>
                                <td align=center style="width: 88px"><input id="rdb_6e1" atomicselection="true" name="rdb_6e" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6e2" atomicselection="true" name="rdb_6e" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6e3" atomicselection="true" name="rdb_6e" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6e4" atomicselection="true" name="rdb_6e" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6e5" atomicselection="true" name="rdb_6e" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6e6" atomicselection="true" name="rdb_6e" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión OPD</td>
                                <td align=center style="width: 88px"><input id="rdb_6f1" atomicselection="true" name="rdb_6f" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6f2" atomicselection="true" name="rdb_6f" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6f3" atomicselection="true" name="rdb_6f" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6f4" atomicselection="true" name="rdb_6f" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6f5" atomicselection="true" name="rdb_6f" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6f6" atomicselection="true" name="rdb_6f" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión OPD Eventos Proyectos</td>
                                <td align=center style="width: 88px"><input id="rdb_6g1" atomicselection="true" name="rdb_6g" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6g2" atomicselection="true" name="rdb_6g" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6g3" atomicselection="true" name="rdb_6g" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6g4" atomicselection="true" name="rdb_6g" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6g5" atomicselection="true" name="rdb_6g" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6g6" atomicselection="true" name="rdb_6g" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión PPC</td>
                                <td align=center style="width: 88px"><input id="rdb_6h1" atomicselection="true" name="rdb_6h" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6h2" atomicselection="true" name="rdb_6h" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6h3" atomicselection="true" name="rdb_6h" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6h4" atomicselection="true" name="rdb_6h" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6h5" atomicselection="true" name="rdb_6h" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6h6" atomicselection="true" name="rdb_6h" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión PPC - Eventos Proyectos</td>
                                <td align=center style="width: 88px"><input id="rdb_6i1" atomicselection="true" name="rdb_6i" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6i2" atomicselection="true" name="rdb_6i" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6i3" atomicselection="true" name="rdb_6i" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6i4" atomicselection="true" name="rdb_6i" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6i5" atomicselection="true" name="rdb_6i" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6i6" atomicselection="true" name="rdb_6i" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Programas</td>
                                <td align=center style="width: 88px"><input id="rdb_6j1" atomicselection="true" name="rdb_6j" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6j2" atomicselection="true" name="rdb_6j" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6j3" atomicselection="true" name="rdb_6j" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6j4" atomicselection="true" name="rdb_6j" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6j5" atomicselection="true" name="rdb_6j" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6j6" atomicselection="true" name="rdb_6j" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Programas Eventos Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_6k1" atomicselection="true" name="rdb_6k" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6k2" atomicselection="true" name="rdb_6k" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6k3" atomicselection="true" name="rdb_6k" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6k4" atomicselection="true" name="rdb_6k" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6k5" atomicselection="true" name="rdb_6k" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6k6" atomicselection="true" name="rdb_6k" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión Programas  Nómina</td>
                                <td align=center style="width: 88px"><input id="rdb_6l1" atomicselection="true" name="rdb_6l" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6l2" atomicselection="true" name="rdb_6l" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6l3" atomicselection="true" name="rdb_6l" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6l4" atomicselection="true" name="rdb_6l" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6l5" atomicselection="true" name="rdb_6l" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6l6" atomicselection="true" name="rdb_6l" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Nomina</td>
                                <td align=center style="width: 88px"><input id="rdb_6ll1" atomicselection="true" name="rdb_6ll" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6ll2" atomicselection="true" name="rdb_6ll" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6ll3" atomicselection="true" name="rdb_6ll" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6ll4" atomicselection="true" name="rdb_6ll" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6ll5" atomicselection="true" name="rdb_6ll" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6ll6" atomicselection="true" name="rdb_6ll" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Eventos de Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_6m1" atomicselection="true" name="rdb_6m" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6m2" atomicselection="true" name="rdb_6m" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6m3" atomicselection="true" name="rdb_6m" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6m4" atomicselection="true" name="rdb_6m" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6m5" atomicselection="true" name="rdb_6m" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6m6" atomicselection="true" name="rdb_6m" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Edad y Sexo</td>
                                <td align=center style="width: 88px"><input id="rdb_6n1" atomicselection="true" name="rdb_6n" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6n2" atomicselection="true" name="rdb_6n" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6n3" atomicselection="true" name="rdb_6n" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6n4" atomicselection="true" name="rdb_6n" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6n5" atomicselection="true" name="rdb_6n" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6n6" atomicselection="true" name="rdb_6n" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Permanencias</td>
                                <td align=center style="width: 88px"><input id="rdb_6o1" atomicselection="true" name="rdb_6o" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6o2" atomicselection="true" name="rdb_6o" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6o3" atomicselection="true" name="rdb_6o" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6o4" atomicselection="true" name="rdb_6o" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6o5" atomicselection="true" name="rdb_6o" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6o6" atomicselection="true" name="rdb_6o" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Causales Ingreso, Quien solicita Ingreso</td>
                                <td align=center style="width: 88px"><input id="rdb_6p1" atomicselection="true" name="rdb_6p" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6p2" atomicselection="true" name="rdb_6p" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6p3" atomicselection="true" name="rdb_6p" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6p4" atomicselection="true" name="rdb_6p" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6p5" atomicselection="true" name="rdb_6p" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6p6" atomicselection="true" name="rdb_6p" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Egresos</td>
                                <td align=center style="width: 88px"><input id="rdb_6q1" atomicselection="true" name="rdb_6q" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6q2" atomicselection="true" name="rdb_6q" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6q3" atomicselection="true" name="rdb_6q" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6q4" atomicselection="true" name="rdb_6q" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6q5" atomicselection="true" name="rdb_6q" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6q6" atomicselection="true" name="rdb_6q" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Eventos de Proyectos</td>
                                <td align=center style="width: 88px"><input id="rdb_6r1" atomicselection="true" name="rdb_6r" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6r2" atomicselection="true" name="rdb_6r" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6r3" atomicselection="true" name="rdb_6r" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6r4" atomicselection="true" name="rdb_6r" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6r5" atomicselection="true" name="rdb_6r" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6r6" atomicselection="true" name="rdb_6r" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Diligencias Realizadas</td>
                                <td align=center style="width: 88px"><input id="rdb_6s1" atomicselection="true" name="rdb_6s" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6s2" atomicselection="true" name="rdb_6s" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6s3" atomicselection="true" name="rdb_6s" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6s4" atomicselection="true" name="rdb_6s" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6s5" atomicselection="true" name="rdb_6s" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6s6" atomicselection="true" name="rdb_6s" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Datos Plan de Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_6t1" atomicselection="true" name="rdb_6t" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6t2" atomicselection="true" name="rdb_6t" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6t3" atomicselection="true" name="rdb_6t" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6t4" atomicselection="true" name="rdb_6t" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6t5" atomicselection="true" name="rdb_6t" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6t6" atomicselection="true" name="rdb_6t" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    <strong>Justicia Juvenil</strong></td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_6u1" atomicselection="true" name="rdb_6u" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6u2" atomicselection="true" name="rdb_6u" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6u3" atomicselection="true" name="rdb_6u" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6u4" atomicselection="true" name="rdb_6u" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6u5" atomicselection="true" name="rdb_6u" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6u6" atomicselection="true" name="rdb_6u" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión LRPA - Eventos Intervención</td>
                                <td align=center style="width: 88px"><input id="rdb_6v1" atomicselection="true" name="rdb_6v" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6v2" atomicselection="true" name="rdb_6v" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6v3" atomicselection="true" name="rdb_6v" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6v4" atomicselection="true" name="rdb_6v" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6v5" atomicselection="true" name="rdb_6v" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6v6" atomicselection="true" name="rdb_6v" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Supervisión LRPA - Sanciones, ADN y Tribunales</td>
                                <td align=center style="width: 88px"><input id="rdb_6w1" atomicselection="true" name="rdb_6w" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6w2" atomicselection="true" name="rdb_6w" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6w3" atomicselection="true" name="rdb_6w" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6w4" atomicselection="true" name="rdb_6w" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6w5" atomicselection="true" name="rdb_6w" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6w6" atomicselection="true" name="rdb_6w" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Nomina de Jóvenes Atendidos LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_6x1" atomicselection="true" name="rdb_6x" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6x2" atomicselection="true" name="rdb_6x" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6x3" atomicselection="true" name="rdb_6x" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6x4" atomicselection="true" name="rdb_6x" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6x5" atomicselection="true" name="rdb_6x" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6x6" atomicselection="true" name="rdb_6x" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Sanciones Nomina de Jóvenes Atendidos LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_6y1" atomicselection="true" name="rdb_6y" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6y2" atomicselection="true" name="rdb_6y" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6y3" atomicselection="true" name="rdb_6y" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6y4" atomicselection="true" name="rdb_6y" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6y5" atomicselection="true" name="rdb_6y" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6y6" atomicselection="true" name="rdb_6y" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Nomina - Eventos de Intervención LRPA</td>
                                <td align=center style="width: 88px"><input id="rdb_6z1" atomicselection="true" name="rdb_6z" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6z2" atomicselection="true" name="rdb_6z" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6z3" atomicselection="true" name="rdb_6z" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6z4" atomicselection="true" name="rdb_6z" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6z5" atomicselection="true" name="rdb_6z" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6z6" atomicselection="true" name="rdb_6z" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Nomina - Atendidos LRPA SIMULTANEAMENTE</td>
                                <td align=center style="width: 88px"><input id="rdb_6aa1" atomicselection="true" name="rdb_6aa" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6aa2" atomicselection="true" name="rdb_6aa" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6aa3" atomicselection="true" name="rdb_6aa" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6aa4" atomicselection="true" name="rdb_6aa" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6aa5" atomicselection="true" name="rdb_6aa" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6aa6" atomicselection="true" name="rdb_6aa" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    <strong>Financiero</strong></td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                                <td align="center" style="width: 88px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Reporte Balance Rendición Cuentas</td>
                                <td align=center style="width: 88px"><input id="rdb_6bb1" atomicselection="true" name="rdb_6bb" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6bb2" atomicselection="true" name="rdb_6bb" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6bb3" atomicselection="true" name="rdb_6bb" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6bb4" atomicselection="true" name="rdb_6bb" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6bb5" atomicselection="true" name="rdb_6bb" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6bb6" atomicselection="true" name="rdb_6bb" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel: Rendición Cuentas</td>
                                <td align=center style="width: 88px"><input id="rdb_6cc1" atomicselection="true" name="rdb_6cc" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6cc2" atomicselection="true" name="rdb_6cc" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6cc3" atomicselection="true" name="rdb_6cc" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6cc4" atomicselection="true" name="rdb_6cc" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6cc5" atomicselection="true" name="rdb_6cc" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6cc6" atomicselection="true" name="rdb_6cc" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 591px">
                                    Excel:  Atenciones, Sub Atención, Sobre Atención - por Mes</td>
                                <td align=center style="width: 88px"><input id="rdb_6dd1" atomicselection="true" name="rdb_6dd" type="radio"
                            value="1" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6dd2" atomicselection="true" name="rdb_6dd" type="radio"
                            value="2" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6dd3" atomicselection="true" name="rdb_6dd" type="radio"
                            value="3" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6dd4" atomicselection="true" name="rdb_6dd" type="radio"
                            value="4" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6dd5" atomicselection="true" name="rdb_6dd" type="radio"
                            value="5" contenteditable="true" runat="server"/></td>
                                <td align="center" style="width: 88px"><input id="rdb_6dd6" atomicselection="true" name="rdb_6dd" type="radio"
                            value="6" contenteditable="true" runat="server"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPregunta07" runat="server" Width = 100% Visible="False">
            <table style="width: 80%" id="TABLE7" rules="all">
                <tr>
                    <td>
                        &nbsp;<table style="width: 871px" rules="all">
                            <tr>
                                <td style="width: 53px">
                                </td>
                                <td style="width: 632px">
                                    <asp:TextBox ID="txtObservacionPregunta07" runat="server" AutoPostBack="True" Height="101px"
                                        MaxLength="500" Width="832px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <table width="100%" style="width: 70%">
            <tr>
                <td align="right">
                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAnterior" runat="server" BackColor="RoyalBlue" ForeColor="White"
                        Height="29px" OnClick="btnAnterior_Click" Text="Anterior" Visible="False" Width="90px" />&nbsp;
                </td>
                <td align="center">
                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnSiguiente" runat="server" BackColor="RoyalBlue" ForeColor="White"
                        Height="29px" OnClick="btnSiguiente_Click" Text="Siguiente" Width="90px" />&nbsp;
                </td>
                <td>
                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGrabar" runat="server" BackColor="RoyalBlue" ForeColor="White"
                        Height="29px" OnClick="btnGrabar_Click" Text="Grabar" Visible="False" Width="90px" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
