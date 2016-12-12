<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Rep_LRPA.aspx.cs" Inherits="mod_reportes_Rep_Diag_Ninos_Rep_LRPA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
      
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="titulo_form">Reporte de Plan de Intervención</td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="1000">
                        <tr>
                            <td valign="top">
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td class="texto_form" width="215">
                                            Seleccione</td>
                                        <td class="linea_inferior" colspan="3">
                                            <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" Font-Size="11px"
                                                 Width="600px">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">a. Ocupaci&#243;n Diaria Centros AA.DD.</asp:ListItem>
                                                <asp:ListItem Value="2">b. N&#243;mina de adolescentes.</asp:ListItem>
                                                
                                            </asp:DropDownList>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                      
                                        <td class="linea_inferior" colspan="4">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form" colspan="4">
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="texto_form" colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="texto_form" colspan="4">
                                        </td>
                                     
                                        
                                    </tr>
                                    <tr>
                                        <td class="texto_form" width="150" colspan="4">
                                        </td>
                                       
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
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




