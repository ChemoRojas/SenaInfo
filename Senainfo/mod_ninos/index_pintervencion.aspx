<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="index_pintervencion.aspx.cs" Inherits="mod_ninos_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body onload="history.go(+1);">
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3" height="20">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="titulo" colspan="3" height="20">
                    Plan de Intervención&nbsp;
                    <br />
                    Ingresar y Actualizar Información
                </td>
            </tr>
            <tr>
                <td colspan="3" height="20">
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="Imb_NuevoPlan" runat="server" ImageUrl="~/images/bot_pi_nuevo.jpg" OnClick="Imb_NuevoPlan_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="Imb_gestionPlan" runat="server" ImageUrl="~/images/bot_pi_gestionar.jpg"
                                    OnClick="Imb_gestionPlan_Click" /></td>
                        </tr>
                        
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
