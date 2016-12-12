<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error403.aspx.cs" Inherits="ErrorPages_error403" %>

<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%--<%@ Register Src="ninos_busqueda.ascx" TagName="ninos_busqueda" TagPrefix="uc2" %>--%>


<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="description" content="S">
<meta name="author" content="">
<link rel="icon" href="../images/favicon.ico">
<title>Titulo Formulario :: Senainfo :: Servicio Nacional de Menores</title>

<%--Si el formulario se encuentra dentro de un folder descomentar estas lineas--%>
<script src="../js/jquery-2.1.4.js"></script>
<script src="../js/jquery-2.1.4.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/senainfoTools.js"></script>
<script src="../js/jquery-ui.js"></script>
<script src="../js/jquery.validate.js"></script>
<script src="../js/jquery.Rut.js"></script>
<script src="../js/notify.js"></script>
<script src="../js/moment.js"></script>
<script src="../js/jquery.plugin.js"></script>
<script src="../js/jquery.maxlength.js"></script>

<link href="../css/bootstrap.min.css" rel="stylesheet">
<link href="../css/bootstrap-theme.min.css" rel="stylesheet">
<link href="../css/theme.css" rel="stylesheet">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager runat="server" ID="Scriptmanager1"></asp:ScriptManager>
        <div class="container">
            <h2 class="subtitulo-form">Error 403</h2>
            <h2 class="subtitulo-form">No tienes permisos para acceder a esta página :(</h2>
        </div>
    </form>
</body>
</html>
