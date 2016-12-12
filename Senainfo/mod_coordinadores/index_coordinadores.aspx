<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="index_coordinadores.aspx.cs" Inherits="mod_coordinadores_index_coordinadores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body onload="history.go(+1);">
    <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" height="20" style="width: 285px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" class="titulo" colspan="3" height="20" style="width: 285px">Coordinador Judicial&nbsp;
                    <br />
                    </td>
                </tr>

                <tr>
                    <td valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td colspan="3" align="center" style="width: 285px; height: 20px">&nbsp;<asp:ImageButton ID="imgbtn_ingresar" runat="server" ImageUrl="~/images/bot_rep_ingresar.jpg" OnClick="imgbtn_ingresar_Click" /></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center" style="width: 285px; height: 20px">
                                    <asp:ImageButton ID="imgbtn_modificar" runat="server" ImageUrl="~/images/bot_rep_modificar.jpg"
                                        OnClick="imgbtn_modificar_Click" /></td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 284px">
                                    <asp:ImageButton ID="Imb_reportes" runat="server" ImageUrl="~/images/bot_rep_coord.jpg" OnClick="Imb_reportes_Click" /></td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">&nbsp;<asp:HyperLink ID="hlInstructivo" runat="server" ForeColor="Red" NavigateUrl="~/links/INSTRUCTIVO-COORDINADORES.pdf"
                        Target="_blank">Instructivo</asp:HyperLink></td>
                </tr>
            </table>
                

           </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
