<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnvioMailMasivo.aspx.cs" Inherits="mod_instituciones_EnvioMailMasivo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnEnviarCorreos" runat="server" Text="Enviar Correos" OnClick="btnEnviarCorreos_Click" />
    </div>
    </form>
</body>
</html>
