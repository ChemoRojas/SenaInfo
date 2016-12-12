<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="index_mesa.aspx.cs" Inherits="mod_mesa_index_mesa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="20" colspan="3" >&nbsp;</td>
        </tr>
        <tr>
          <td height="20" colspan="3" align="center" class="titulo" >Mesa de Ayuda </td>
        </tr>
        <tr>
          <td height="20" colspan="3" >&nbsp;</td>
        </tr>
        <tr>
          <td valign="top" style="height: 219px" ><table width="100%" border="0" cellspacing="0" cellpadding="0">

              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_ResAtencion" runat="server" ImageUrl="../images/bot_mesa_trabajadores.jpg" OnClick="Imb_ResAtencion_Click" Visible="False" />                </td>
              </tr>
              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_MesaRectif" runat="server" ImageUrl="../images/bot_mesa_rectificacion.jpg" OnClick="Imb_MesaRectif_Click" />                </td>
              </tr>
              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_MesaRegenerar" runat="server" ImageUrl="../images/bot_mesa_regenerar.jpg" OnClick="Imb_MesaRegenerar_Click" />                </td>
              </tr>
              <tr>
              <td>
                  <asp:ImageButton ID="Imb_MesaMantenedor" runat="server" ImageUrl="../images/bot_mesa_mantenedor.jpg" Visible="False" /></td></tr>
          </table></td>
        <tr>
          <td >&nbsp;</td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>
