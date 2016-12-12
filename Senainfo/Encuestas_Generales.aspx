<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Encuestas_Generales.aspx.cs" Inherits="Encuestas_Generales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                        <a href="Encuestas_Generales.aspx" target="_parent">
                            <img border="0" height="60" src="images/logosename.gif" width="258" /></a></td>
                    <td bgcolor="#015089">
                        <table align="right" border="0" cellpadding="0" cellspacing="0" width="150">
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align=center>
                        <br />
                        <asp:Label ID="lbHeader" runat="server" EnableTheming="True" Font-Bold="True" Font-Size="12px"
                            Font-Strikeout="False" Font-Underline="False" ForeColor="#507CD1" Text="ANTES DE INGRESAR AL SISTEMA, SOLICITO A UD, RESPONDER ESTA ENCUESTA POR FAVOR"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 34px">
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span
                                lang="ES" style="font-size: 9pt; font-family: Arial">
                            <asp:Label ID="lblInstrucciones" runat="server" Font-Bold="True" ForeColor="#507CD1"
                                Text="INSTRUCCIONES :" Width="183px"></asp:Label></span></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 10pt; font-style: italic;	color: Navy;	font-family: Arial;">
                       <blockquote>
                            <p align="justify">
                        <asp:TextBox ID="txHeader" runat="server" BorderStyle="None" Font-Names="Arial"
                            Height="150px" ReadOnly="True" TextMode="MultiLine" Width="94%" Font-Italic="True" Font-Size="14px" ForeColor="Navy" BorderColor="White"></asp:TextBox>
                            </p></blockquote>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 30px">
                        <asp:Label ID="lblAfirmacion" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="Red"
                            Text="De acuerdo  a la siguiente afirmación, evalúe las preguntas a continuación:"></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td colspan=2>
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td class="texto_form" bgcolor="#015089">
                                   
                                    <asp:Label ID="lbPregunta" runat="server" Width="100%" Font-Bold="True"
                                        Font-Size="12px"></asp:Label>
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 14px">
                        <asp:Label ID="lbError" runat="server" Font-Size="11px" ForeColor="Red" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                     <blockquote>
                        <asp:GridView ID="grPreguntas" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Width="95%" >
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="SubPregunta" HeaderText="Pregunta" >
                                    <ItemStyle Width="45%" ForeColor="Navy" Font-Size=11px  />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddownNota" runat="server" Font-Size="11px" ForeColor="Navy">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rb001" runat="server" Text="No corresponde" GroupName="vgPreguntas"
                                            OnCheckedChanged="rb001_CheckedChanged" ForeColor="Navy" Font-Size="11px" Visible="False" /><asp:RadioButton ID="rb002" runat="server" Text="No sabe, no lo ha utilizado" GroupName="vgPreguntas"
                                            ForeColor="Navy" Font-Size="11px" Visible="False" /><br />
                                        &nbsp;
                                    </ItemTemplate>
                                    <ItemStyle Width="0%" />
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
                                <td style="height: 97px">
                                    <asp:Label ID="lblObservacion" runat="server" Font-Size="12px" ForeColor="#507CD1" Visible="False">OBSERVACIÓN :</asp:Label><br />
                                    <asp:TextBox ID="TextBox1" runat="server" Height="57px" Width="415px" MaxLength="400" TextMode="MultiLine"></asp:TextBox><br />
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblObservacionGeneral" runat="server" Font-Size="12px" ForeColor="#507CD1"
                                        Visible="False">OBSERVACIÓN  GENERAL:</asp:Label><br />
                                    <asp:TextBox ID="txtObservacionGeneral" runat="server" Height="156px" MaxLength="400"
                                        TextMode="MultiLine" Visible="False" Width="573px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width=100% >
                                       <tr>
                                        <td align="right" >
                                 
                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btAnterior" runat="server" Text="Anterior" Width="80px" Visible="False" OnClick="btAnterior_Click" />
                                        </td>
                                      
                                       
                                       <td align="center" >
                       
                                           <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btSiguiente" runat="server" Text="Siguiente" Width="80px" OnClick="WebImageButton2_Click" />
                                    
                                       </td>
                                        <td >
                             
                                            <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btGrabar" runat="server" Text="Grabar" Visible="False" Width="80px" OnClick="btGrabar_Click" />
                                    
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
