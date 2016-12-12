<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="EncuestasFES.aspx.cs" Inherits="EncuestasFES" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Encuenta</title>
    <link href="css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="1" bgcolor="#015089">
                        <a href="EncuestasFES.aspx" target="_parent">
                            <img border="0" height="60" src="images/logosename.gif" width="258" /></a></td>
                    <td bgcolor="#015089">
                        <table align="right" border="0" cellpadding="0" cellspacing="0" width="150">
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <br />
                        <asp:Label ID="lbHeader" runat="server" EnableTheming="True" Font-Bold="True" Font-Size="12px"
                            Font-Strikeout="False" Font-Underline="False" ForeColor="#507CD1" Text="ANTES DE INGRESAR A LA SENAINFO, SOLICITO A UD, RESPONDER ESTA ENCUESTA POR FAVOR"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 34px">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                        &nbsp;&nbsp; <span lang="ES" style="font-size: 9pt; font-family: Arial">
                            <asp:Label ID="lblInstrucciones" runat="server" Font-Bold="True" ForeColor="#507CD1"
                                Text="INSTRUCCIONES :" Width="183px" Visible="False"></asp:Label></span><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; font-style: italic; color: Navy; font-family: Arial;">
                        <blockquote>
                            <p align="justify">
                                <asp:TextBox ID="txHeader" runat="server" BorderStyle="None" Font-Names="Arial" Height="205px"
                                    ReadOnly="True" TextMode="MultiLine" Width="100%" Font-Italic="True" Font-Size="12px"
                                    ForeColor="Navy" BorderColor="White"></asp:TextBox>
                            </p>
                        </blockquote>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblAfirmacion" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="Red"
                            Text="De acuerdo  a la siguiente afirmación, evalúe las preguntas a continuación:"
                            Visible="False"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td class="texto_form" bgcolor="#015089">
                                    <asp:Label ID="lbPregunta" runat="server" Width="100%" Font-Bold="True" Font-Size="12px"
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="Label1" runat="server" Font-Size="11px" ForeColor="Red" Width="466px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 14px">
                        <asp:Label ID="lbError" runat="server" Font-Size="11px" ForeColor="Red" Width="100%"
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <blockquote>
                            <asp:GridView ID="grPreguntas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" Width="100%">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Pregunta" HeaderText="C&#243;mo eval&#250;a usted la implementaci&#243;n de la firma electr&#243;nica simple">
                                        <ItemStyle Width="70%" ForeColor="Navy" Font-Size="11px" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Eval&#250;e de 1 a 7 las siguientes preguntas (7 = muy de acuerdo y 1 = total desacuerdo)">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddownNota" runat="server" Font-Size="11px" ForeColor="Navy">
                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                <asp:ListItem Value="1">1</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="12px" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </blockquote>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: center">
                                    
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btGrabar" runat="server" Text="Grabar" Width="80px" OnClick="btGrabar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
