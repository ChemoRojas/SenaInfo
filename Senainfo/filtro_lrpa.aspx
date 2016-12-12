<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="filtro_lrpa.aspx.cs" Inherits="links_link" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Instructivos</title>
    <link href="css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <table width="450px" border="0" align="center" cellpadding="0" cellspacing="0" style="height: 1%">
        <tbody>
            <tr>
                <td valign="top" style="height: 1px">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="1" style="height: 29px">
                                <img src="images/log_top1.jpg" alt="" width="71" height="29" /></td>
                            <td background="images/log_top3.jpg" style="height: 29px">
                                <img src="images/log_top3.jpg" width="77" height="29" /></td>
                            <td width="1" style="height: 29px">
                                <img src="images/log_top22.jpg" width="116" height="29" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="38" valign="top" background="images/log_fondologo.jpg" class="fdoizq">
                                <img src="images/log_fondologo.jpg" width="38" height="123" /></td>
                            <td>
                                <div align="center">
                                    <!--Aplicación-->
                                    <form id="form1" runat="server">
                                        <table border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="height: 156px">
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="4">
                                                        <tr>
                                                            <td align="left" class="titulo2" rowspan="3" style="text-align: center">
                                                                <strong><span style="font-size: 9pt; color: #000080; font-family: Verdana">Edad &lt;
                                                                    de 14 años</span></strong></td>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="titulo2" style="text-align: center">
                                                                <strong><span style="font-size: 9pt; color: #000080; font-family: Verdana">USTED REGISTRARA
                                                                    UN DELITO </span></strong>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-size: 9pt">
                                                            <td align="left" class="titulo2" style="height: 15px; text-align: center">
                                                                <strong><span style="color: #000080; font-family: Verdana">COMETIDO POR EL NIÑO(A)</span></strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="titulo2" style="height: 15px; font-size: 9pt;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="titulo2" style="text-align: center">
                                                                <strong><span style="font-size: 9pt; color: red; font-family: Verdana">Desea Continuar?</span></strong>&nbsp;</td>
                                                        </tr>
                                                        <tr style="font-family: Arial">
                                                            <td align="left" class="titulo2" rowspan="9" style="text-align: center">&nbsp;
                                                                
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnnext001" runat="server" Text="SI" OnClick="btnnext" />


                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                                
                                                                <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="NO" OnClick="btnnext_no" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="titulo2" rowspan="1" style="text-align: center">*Si el niño(a) es <span style="text-decoration: underline">víctima de </span>seleccione</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="titulo2" rowspan="1" style="text-align: center">Tipo Causal Ingreso Protección de Derechos</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </form>
                                    <!--Fín Aplicación-->
                                </div>
                            </td>
                            <td width="1" valign="top" background="images/log_fdorayader.jpg" style="font-family: Arial; font-size: 9pt;">
                                <span class="fdoizq">
                                    <img src="images/log_fdorayader.jpg" width="13" height="5" /></span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="font-size: 9pt">
                <td bgcolor="#f7f7fb" style="height: 13px">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="1" style="height: 13px">
                                <img src="images/log_inf_1.jpg" width="69" height="13" /></td>
                            <td background="images/log_inf_2.jpg" style="height: 13px">
                                <img src="images/log_inf_2.jpg" width="70" height="13" /></td>
                            <td width="1" style="height: 13px">
                                <img src="images/log_inf_3.jpg" width="88" height="13" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
