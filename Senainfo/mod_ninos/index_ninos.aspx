<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="index_ninos.aspx.cs" Inherits="mod_ninos_index_ninos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
</head>

<body onload="history.go(+1);">
    <form id="form1" runat="server">
    <div>
    	      <table border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="20" colspan="3" >&nbsp;</td>
        </tr>
        <tr>
          <td height="20" colspan="3" align="center" class="titulo" >Ni&ntilde;os - Ingresar y Actualizar Informaci&oacute;n </td>
        </tr>
        <tr>
          <td height="20" colspan="3" >&nbsp;</td>
        </tr>
        <tr>
          <td valign="top" align="center" ><table width="100%" border="0" cellspacing="0" cellpadding="0">

              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_Ninos" runat="server" ImageUrl="../images/bot_nino_ingresonino.jpg" OnClick="Imb_Ninos_Click"  />                </td>
              </tr>
              <tr><td align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/bot_ninos_datosgestion.jpg" OnClick="ImageButton1_Click"  /></td></tr>
              
              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_DiagNiño" runat="server" ImageUrl="../images/menu_nino_diagnostico.jpg" OnClick="Imb_DiagNiño_Click"  />             </td>
              </tr>
              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_Planes" runat="server" ImageUrl="../images/bot_ninos_planesinterv.jpg" OnClick="Imb_Planes_Click" />                </td>
              </tr>
              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_Egresos" runat="server" ImageUrl="../images/bot_ninos_egresos.jpg" OnClick="Imb_Egresos_Click" />                </td>
              </tr>
              <tr>
                <td align="center">
                    <asp:ImageButton ID="Imb_Cierre" runat="server" ImageUrl="../images/bot_ninos_cierremes.jpg" OnClick="Imb_Cierre_Click"  />                </td>
              </tr>
              <tr>
              <td align="center">
                  <asp:ImageButton ID="Imb_NinoRelac" runat="server" ImageUrl="../images/bot_ninos_ninosrelac.jpg" OnClick="Imb_NinoRelac_Click" /></td></tr>
              <tr>
              <td align="center">
                  <asp:ImageButton ID="Imb_NinoVisitado" runat="server" ImageUrl="../images/bot_ninos_ninosvisitados.jpg" OnClick="Imb_NinoVisitado_Click" /></td></tr>
              <tr>
              <td align="center">
                  <asp:ImageButton ID="Imb_Direccion" runat="server" ImageUrl="../images/bot_ninos_direccion.jpg" OnClick="Imb_Direccion_Click" /></td></tr>
                  <tr>
              <td align="center">
                  <asp:ImageButton ID="Imb_adn" runat="server" ImageUrl="../images/bot_ADN.jpg" OnClick="Imb_ADN_Click" Width="280px" /></td></tr>
          </table>
              <asp:ImageButton ID="imb_Faltas" runat="server" Height="70px" ImageUrl="~/images/btn_infrac_disciplinarias.jpg"
                  OnClick="LinkButton1_Click" Width="286px" /></td>
        <tr>
          <td >&nbsp;</td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>
