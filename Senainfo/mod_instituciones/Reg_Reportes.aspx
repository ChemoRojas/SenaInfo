<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Reg_Reportes.aspx.cs" Inherits="mod_rendiciones_Reg_Reportes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>

     <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.fancybox-1.3.4.js"></script>
   
     <script language="javascript" type="text/javascript">
      
         function CerrarFancybox() {
             parent.$.fancybox.close();
         };

         function AbrirURLFancybox(url) {
             parent.location.replace(url);
         };
         function Forzar() {
             __doPostBack('', '');
         };

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnCancelarBusqueda_NEW" runat="server" Text="Cerrar" OnClick="btnCancelar_Click"  />
                                
    </div>
    </form>
</body>
</html>
