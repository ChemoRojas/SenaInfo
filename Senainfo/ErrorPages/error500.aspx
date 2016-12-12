<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error500.aspx.cs" Inherits="ErrorPages_error500" %>


<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="description" content="S">
<meta name="author" content="">
<link rel="icon" href="../images/favicon.ico">
<title>Error 500 :: Senainfo :: Servicio Nacional de Menores</title>

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



<!-- Si el formulario se encuentra en raiz, descomentar estas lineas
    <script src="js/jquery-2.1.4.js"></script>
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/senainfoTools.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery.validate.js"></script>
    <script src="js/jquery.Rut.js"></script>
    <script src="js/notify.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/jquery.plugin.js"></script>
    <script src="js/jquery.maxlength.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">
    <link href="css/jquery.maxlength.css" rel="stylesheet" />-->
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <div class="container">
            <div class="jumbotron">
                <h1>Error 500</h1>
                <p>
                    Se presento un problema mientras se establecia la conexión a la base de datos, por favor, verificar si es que logro realizar los cambios que estaba efectuando, de lo contrario,
                volver a realizar el ingreso de información.
                </p>
            </div>
        </div>
    </form>
</body>
</html>
