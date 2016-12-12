<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="EncuestaProyectosFuncionarios.aspx.cs"
    Inherits="EncuestaProyectosFuncionarios" %>


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
                        <a href="EncuestaProyectosFuncionarios.aspx" target="_parent">
                            <img border="0"  alt="" height="60" src="images/logosename.gif" width="258" /></a></td>
                    <td bgcolor="#015089">
                        <table align="right" border="0" cellpadding="0" cellspacing="0" width="150">
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <br />
                        <asp:Label ID="lbHeader" runat="server" EnableTheming="True" Font-Bold="True" Font-Size="12px"
                            Font-Strikeout="False" Font-Underline="False" ForeColor="#507CD1" Text="Por instrucciones del Ministerio de Justicia, se solicita registrar a TODAS las personas que laboran en su centro o proyecto, cualquiera sea su actividad y régimen de contratación, voluntarios, alumnos en práctica, etc. Debe ingresar una a una a dichas personas, luego pinchar el botón agregar, registrar al siguiente y así sucesivamente hasta terminar, si comete algún error puede eliminar Una vez concluida dicha lista debe pinchar el botón “GRABAR”, y la información quedará registrada en SENAINFO. Si el RUT es menor a 10 millones, se debe anteponer un 0 (cero) ... Muchas gracias"
                            Font-Overline="False" Height="78px" Width="52%"></asp:Label>
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
                                <asp:TextBox ID="txHeader" runat="server" BorderStyle="None" Font-Names="Arial" Height="1px"
                                    ReadOnly="True" TextMode="MultiLine" Width="100%" Font-Italic="True" Font-Size="12px"
                                    ForeColor="Navy" BorderColor="White"></asp:TextBox>
                            </p>
                        </blockquote>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table style="width: 70%">
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Institucion</td>
                                <td style="width: 411px">
                                    <asp:TextBox ID="txtInstitucion" runat="server" ReadOnly="True" Width="362px"></asp:TextBox></td>
                                <td style="width: 86px">
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px; height: 19px">
                                    Proyecto</td>
                                <td style="width: 411px; height: 19px">
                                    <asp:TextBox ID="txtProyecto" runat="server" ReadOnly="True" Width="362px"></asp:TextBox></td>
                                <td style="width: 86px; height: 19px">
                                </td>
                            </tr>
                            <tr>
                                <td class="texto_form" style="width: 138px">
                                    Modelo</td>
                                <td style="width: 411px">
                                    <asp:TextBox ID="txtModelo" runat="server" ReadOnly="True" Width="362px"></asp:TextBox></td>
                                <td style="width: 86px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 33px">
                        <table border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td class="texto_form" bgcolor="#015089">
                                    <asp:Label ID="lbPregunta" runat="server" Width="100%" Font-Bold="True" Font-Size="12px">Trabajadores</asp:Label>
                                </td>
                            </tr>
                        </table>
                
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnAgregar" runat="server" Text="Agregar Trabajador" OnClick="btnAgregar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 14px">
                        <asp:Label ID="lbError" runat="server" Font-Size="22px" ForeColor="Red" Width="100%"
                            Visible="False">Debe ingresar la información</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 160px">
                        <asp:Panel ID="pnlIngresoTrabajador" runat="server" Width="100%" Wrap="False">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td valign="top" style="width: 835px">
                                                    <table id="tblEditar" runat="server" border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td class="texto_form" width="225">
                                                                Rut</td>
                                                            <td class="linea_inferior" style="width: 749px">
                                                                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="txtRutValidator" runat="server" ControlToValidate="txtRut"
                                                                    ErrorMessage="Formato de Rut Inválido" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)" Font-Bold="True"></asp:RegularExpressionValidator>
                                                                &nbsp;
                                                                 <asp:Label ID="lblErrorRut" runat="server" Font-Size="11px" ForeColor="Red" Visible="False"
                                                                    Width="191px">lblErrorRut</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Apellido Paterno</td>
                                                            <td class="linea_inferior" style="width: 749px">
                                                                <asp:TextBox ID="txtApellidoPaterno" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                    MaxLength="50" Width="90%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Apellido Materno</td>
                                                            <td class="linea_inferior" style="width: 749px">
                                                                <asp:TextBox ID="txtApellidoMaterno" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                    MaxLength="50" Width="90%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form" style="height: 23px">
                                                                Nombres</td>
                                                            <td class="linea_inferior" style="height: 23px; width: 749px;">
                                                                <asp:TextBox ID="txtNombres" runat="server" Font-Names="Arial" Font-Size="11px" MaxLength="50"
                                                                    Width="90%"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form">
                                                                Cargo o Función</td>
                                                            <td class="linea_inferior" style="width: 749px">
                                                                <asp:DropDownList ID="ddlCargoFuncion" runat="server" Font-Size="11px" Width="350px">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="texto_form" style="height: 18px">
                                                                Otro Cargo o Función</td>
                                                            <td class="linea_inferior" style="width: 749px; height: 18px;">
                                                                <asp:TextBox ID="txtCargoFuncion" runat="server" Font-Names="Arial" Font-Size="11px"
                                                                    MaxLength="50" Width="90%"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="center" style="width: 133px">
                                 
                                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnGuardaIngreso" runat="server" Text="Agregar" Width="128px" OnClick="btnGuardaIngreso_Click" />
                                                    <br />
                                  
                                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCancelaIngreso" runat="server" Text="Cancelar" Width="128px" Visible="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 160px">
                        <blockquote>
                            <asp:Panel ID="pnlTrabajadores" runat="server" Width="100%">
                                <asp:GridView ID="grdTrabajadores" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height="100%"
                                    OnRowCommand="grdTrabajadores_RowCommand">
                                    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                    <Columns>
                                        <asp:BoundField DataField="Rut" HeaderText="Rut" HeaderStyle-HorizontalAlign="Left"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno" HeaderStyle-HorizontalAlign="Left"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" HeaderStyle-HorizontalAlign="Left"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" HeaderStyle-HorizontalAlign="Left"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Profesion" HeaderText="Profesi&#243;n/Oficio" HeaderStyle-HorizontalAlign="Left"
                                            HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OtraProfesionOficio" HeaderText="Otra Profesi&#243;n / Oficio"
                                            HeaderStyle-HorizontalAlign="Left" HtmlEncode="False">
                                            <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar">
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" Width="5%" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="CodProfesion">
                                            <ItemStyle Font-Size="0px" HorizontalAlign="Left" ForeColor="White" Width="1px" />
                                            <ControlStyle ForeColor="White" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                        ForeColor="White" HorizontalAlign="Left" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                </asp:GridView>
                            </asp:Panel>
                            &nbsp;</blockquote>
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
                                            
                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btGrabar" runat="server" Text="Grabar" Width="191px" OnClick="btGrabar_Click" />   
                                                
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
