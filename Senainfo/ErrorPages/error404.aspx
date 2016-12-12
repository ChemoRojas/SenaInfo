<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error404.aspx.cs" Inherits="ErrorPages_error404" %>

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

<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="description" content="S">
<meta name="author" content="">
<link rel="icon" href="../images/favicon.ico">
<title>Página no encontrada :: Senainfo :: Servicio Nacional de Menores</title>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
    
<body>
    <style type="text/css">
        img {
            width: 100%;
            border-radius: 10px;
        }
    </style>
    <div class="container text-center">
        <form id="form1" runat="server">
            <uc1:menu_colgante runat="server" ID="menu_colgante" Visible='<%# ((int)Eval(Session["IdUsuario"].ToString()) > 0) ? true : false %>' />
            <asp:ScriptManager ID="Scriptmanager1" ScriptMode="Release" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
            <div>
                <img src="../images/ERROR 404-01.jpg" />
                
            </div>
        </form>
    </div>
</body>
</html>
