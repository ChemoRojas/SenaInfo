<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="P_AJAX.aspx.cs" Inherits="P_AJAX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<script type="text/javascript">

    
    </script>
  
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button1" runat="server" Text="Button" OnClientClick ="P_AJAX.HelloWorld(HelloWorld_CallBack)" />
    <div>
        &nbsp;</div>
    </div>
    </form>
</body>
</html>
