<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RedireccionExterna.aspx.cs" Inherits="RedireccionExterna" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<html lang="es">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Redirección Externa :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/jquery-ui.js"></script>

    <%--<script src="js/jquery.validate.js"></script>--%>
    <%--<script src="js/jquery.Rut.js"></script>--%>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function SetProgressPosition(e) {
            var posx = 0;
            var posy = 0;
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                posx = e.clientX + document.documentElement.scrollLeft;
                posy = e.clientY + document.documentElement.scrollTop;
            }

            document.getElementById('divProgress').style.top = posy + "px";
        }

        //function pageLoad(sender, args) {
        //    $(document).ready(function () {
        //        $('#txt_run').Rut({
        //            on_error: function () { alert('RUN Incorrecto'); $('#txt_run').val(''); $('#txt_run').focus(); },
        //            format_on: 'keyup'
        //        });
        //    });
        //};
    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)" onkeydown="return (event.keyCode!=13)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Redirección Externa</li>
                    </ol>

                    <div class="alert alert-warning" role="alert" id="alerts" runat="server"  style="margin-top:10px;display:none" >
                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lb_mensaje" runat="server" Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Redirección Externa</h4>
                        <hr>

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <h2 class="text-center">Redireccionando a: <asp:Label ID="lb_destino" runat="server" Text="..."></asp:Label></h2>
                                </table>
                            </div>
                            
                        </div>
                    </div>
                    </div>
                </div>
                <footer class="footer">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                        <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>