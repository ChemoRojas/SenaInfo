<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="rendicion_cuentas.aspx.cs" Inherits="mod_instituciones_rendicion_cuentas" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

      <table border="0" cellpadding="1" cellspacing="1" width="100%" style="position: static; text-align: center" align="center">
          <tr>
          <td height="20" colspan="3" >&nbsp;</td>
        </tr>
        <tr>
          <td height="20" colspan="3" align="center" class="titulo" >Rendicion de Cuentas</td>
        </tr>
          <tr>
              <td align="center" class="titulo" colspan="3" height="20">
              </td>
          </tr>
          <tr>
              <td align="center" class="titulo" colspan="3" height="20">
                  <table align="center" style="direction: ltr; text-align: center">
                      <tr>
                          <td>
                          </td>
                          <td>
              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/bot_rend_regingreso.jpg"
                  OnClick="ImageButton1_Click" /></td>
                          <td>
                          </td>
                      </tr>
                      <tr>
                          <td>
                          </td>
                          <td>
              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/bot_rend_regegreso.jpg"
                  OnClick="ImageButton2_Click" /></td>
                          <td>
                          </td>
                      </tr>
                      <tr>
                          <td>
                          </td>
                          <td>
              <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../images/bot_rend_rendcuentas.jpg"
                  OnClick="ImageButton3_Click" /></td>
                          <td>
                          </td>
                      </tr>
                      <tr>
                          <td>
                          </td>
                          <td>
              <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/Registro_Ingresos_Instituciones.jpg"
                  OnClick="ImageButton4_Click" /></td>
                          <td>
                          </td>
                      </tr>
                      <tr>
                          <td>
                          </td>
                          <td>
              <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/Registro_Egresos_Instituciones.jpg"
                  OnClick="ImageButton5_Click" /></td>
                          <td>
                          </td>
                      </tr>
                      <tr>
                          <td>
                          </td>
                          <td>
              <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/Rendicion_de_Cuentas_de_Instituciones.jpg"
                  OnClick="ImageButton6_Click" /></td>
                          <td>
                          </td>
                      </tr>
                  </table>
              </td>
          </tr>
      </table>
                

           </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
