<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Successwindow.aspx.cs" Inherits="mod_coordinadores_Successwindow" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proceso exitoso</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 879px; height: 457px">
                <tr>
                    <td style="width: 100px"></td>
                    <td style="width: 100px"></td>
                    <td style="width: 100px"></td>
                </tr>
                <tr>
                    <td style="width: 100px"></td>
                    <td align="center" style="width: 100px">
                        <table style="width: 599px; height: 247px">
                            <tr>
                                <td class="texto_form" colspan="3" style="height: 14px">Exito en el proceso</td>
                            </tr>
                            <tr>
                                <td colspan="3">Los cambios se han generado exitosamente.</td>
                            </tr>
                            <tr>
                                <td style="width: 100px"></td>
                                <td style="width: 100px">&nbsp;
                       
                                    <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click" />

                                </td>
                                <td style="width: 100px"></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 100px"></td>
                </tr>
                <tr>
                    <td style="width: 100px"></td>
                    <td style="width: 100px"></td>
                    <td style="width: 100px"></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
