<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Encuestas.aspx.cs" Inherits="Encuestas" %>


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
                        <a href="Encuestas.aspx" target="_parent">
                            <img border="0" alt="" height="60" src="images/logosename.gif" width="258" /></a></td>
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
                    <td colspan="2" style="height: 34px" align="center">
                        <br />
                        <asp:Label ID="lblErrorExperiencia" runat="server" Font-Size="11px" ForeColor="Red"
                            Visible="False" Width="100%" Font-Bold="True">Debe reponder la sección de Frecuencia y Tiempo de Utilización de SENAINFO</asp:Label><br />
                        <asp:Label ID="lblExperienciaHeader" runat="server" Text="Por favor indique la frecuencia y tiempo que lleva utilizando SENAINFO en los siguientes ITEMs:"
                            Width="80%" CssClass="texto_form" Font-Size="12px"></asp:Label><br />
                        <asp:GridView ID="grdExperiencia" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" HorizontalAlign="Center" Width="80%">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" BorderColor="Black" />
                            <Columns>
                                <asp:BoundField DataField="Descripcion" HeaderText="ITEM">
                                    <ControlStyle Font-Size="11px" />
                                    <ItemStyle ForeColor="Navy" Font-Size="11px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Frecuencia">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbFrecuencia001" runat="server" Text="Siempre" GroupName="vgFrecuencia"
                                            OnCheckedChanged="rb001_CheckedChanged" ForeColor="Navy" Font-Size="11px" /><asp:RadioButton
                                                ID="rbFrecuencia002" runat="server" Text="A veces" GroupName="vgFrecuencia" OnCheckedChanged="rb001_CheckedChanged"
                                                ForeColor="Navy" Font-Size="11px" /><br />
                                        <asp:RadioButton ID="rbFrecuencia003" runat="server" Text="Nunca" GroupName="vgFrecuencia"
                                            ForeColor="Navy" Font-Size="11px" /><br />
                                        <asp:DropDownList ID="ddlFrecuencia" runat="server" Font-Size="11px" ForeColor="Navy"
                                            Width="215px" Visible="False">
                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            <asp:ListItem Value="1">SIEMPRE</asp:ListItem>
                                            <asp:ListItem Value="2">A VECES</asp:ListItem>
                                            <asp:ListItem Value="3">NUNCA</asp:ListItem>
                                            <asp:ListItem Value="4">NO CORRESPONDE</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tiempo">
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rbTiempo001" runat="server" Text="Hace menos 1 mes" GroupName="vgTiempo"
                                            OnCheckedChanged="rb001_CheckedChanged" ForeColor="Navy" Font-Size="11px" /><asp:RadioButton
                                                ID="rbTiempo002" runat="server" Text="Mas de un mes menos de 3" GroupName="vgTiempo"
                                                ForeColor="Navy" Font-Size="11px" /><br />
                                        <asp:RadioButton ID="rbTiempo003" runat="server" Text="Hace mas de 3 meses" GroupName="vgTiempo"
                                            ForeColor="Navy" Font-Size="11px" /><asp:RadioButton ID="rbTiempo004" runat="server"
                                                Text="No Corresponde" GroupName="vgTiempo" ForeColor="Navy" Font-Size="11px" /><br />
                                        <asp:DropDownList ID="ddlTiempo" runat="server" Font-Size="11px" ForeColor="Navy"
                                            Width="215px" Visible="False">
                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            <asp:ListItem Value="1">HACE  MENOS 1 MES</asp:ListItem>
                                            <asp:ListItem Value="2">MAS DE 1 MES MENOS DE 3</asp:ListItem>
                                            <asp:ListItem Value="3">HACE MAS DE 3 MES</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" BorderColor="Black" />
                        </asp:GridView>
                        <br />
                 
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnSiguienteExperiencia" runat="server" Text="Siguiente" Width="80px" OnClick="btnSiguienteExperiencia_Click" />
                        
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
                                <asp:TextBox ID="txHeader" runat="server" BorderStyle="None" Font-Names="Arial" Height="150px"
                                    ReadOnly="True" TextMode="MultiLine" Width="100%" Font-Italic="True" Font-Size="12px"
                                    ForeColor="Navy" BorderColor="White" Visible="False"></asp:TextBox>
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
                    </td>
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
                                ForeColor="#333333" GridLines="None" Width="100%" Visible="False">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="SubPregunta" HeaderText="Pregunta">
                                        <ItemStyle Width="70%" ForeColor="Navy" Font-Size="11px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Nota del 1 al 7">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:DropDownList ID="ddownNota" runat="server" Font-Size="11px" ForeColor="Navy">
                                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                <asp:ListItem Value="6"> 6 </asp:ListItem>
                                                <asp:ListItem Value="7"> 7 </asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rb001" runat="server" Text="No corresponde" GroupName="vgPreguntas"
                                                OnCheckedChanged="rb001_CheckedChanged" ForeColor="Navy" Font-Size="11px" /><br />
                                            <asp:RadioButton ID="rb002" runat="server" Text="No sabe, no lo ha utilizado" GroupName="vgPreguntas"
                                                ForeColor="Navy" Font-Size="11px" />
                                        </ItemTemplate>
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
                                    <asp:Label ID="lblObservacion" runat="server" Font-Size="12px" ForeColor="#507CD1"
                                        Visible="False">OBSERVACIÓN :</asp:Label><br />
                                    <asp:TextBox ID="TextBox1" runat="server" Height="57px" Width="415px" MaxLength="400"
                                        TextMode="MultiLine" Visible="False"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                            
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btAnterior" runat="server" Text="Anterior" Width="80px" Visible="False" OnClick="btAnterior_Click" />
                                                
                                            </td>
                                            <td align="center">
                                          
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btSiguiente" runat="server" Text="Siguiente" Width="80px" Visible="False" OnClick="WebImageButton2_Click" />
                                                
                                            </td>
                                            <td>
                                      
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btGrabar" runat="server" Text="Grabar" Width="80px" Visible="False" OnClick="btGrabar_Click" />
                                                
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
