<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_menu_colgante.ascx.cs" Inherits="SenainfoSdk.UI.C_menu_colgante" %>

<%@ Register Src="C_Notificacion.ascx" TagPrefix="uc1" TagName="C_Notificacion" %>

<script>
    (function ($) {
        $(document).ready(function () {
            $('ul.dropdown-menu [data-toggle=dropdown]').on('click', function (event) {
                event.preventDefault();
                event.stopPropagation();
                $(this).parent().siblings().removeClass('open');
                $(this).parent().toggleClass('open');
            });
        });
    })(jQuery);
</script>
<style>
    .dropdown-submenu {
        position: relative;
    }

    .dropdown-submenu > .dropdown-menu {
            top: 0;
            left: 100%;
            margin-top: -6px;
            margin-left: -1px;
            -webkit-border-radius: 0 6px 6px 6px;
            -moz-border-radius: 0 6px 6px 6px;
            border-radius: 0 6px 6px 6px;
        }

    .dropdown-submenu > a:after {
            display: block;
            content: " ";
            float: right;
            width: 0;
            height: 0;
            border-color: transparent;
            border-style: solid;
            border-width: 5px 0 5px 5px;
            border-left-color: #cccccc;
            margin-top: 5px;
            margin-right: -10px;
        }

    .dropdown-submenu:hover > a:after {
            border-left-color: #555;
        }

    .dropdown-submenu.pull-left {
            float: none;
        }

    .dropdown-submenu.pull-left > .dropdown-menu {
                left: -100%;
                margin-left: 10px;
                -webkit-border-radius: 6px 0 6px 6px;
                -moz-border-radius: 6px 0 6px 6px;
                border-radius: 6px 0 6px 6px;
            }
</style>

<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a id="A1" runat="server" class="navbar-brand" href="~/index.aspx">
                <img id="Img1" src="~/images/sename.jpg" runat="server" alt="">
            </a>
        </div>

        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <!-- Home: Siempre se muestra -->
                <li class="active" id="home" runat="server"><a id="A2" href="~/index.aspx" runat="server"><span class="glyphicon glyphicon-home" aria-hidden="true"></span>Inicio</a></li>

                <li class="dropdown" id="menu_menu" runat="server">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Menu <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span></a>
                    <ul class="dropdown-menu" role="menu">

                        <asp:Literal ID="menu_dinamico" runat="server" Mode="PassThrough"></asp:Literal>

                    </ul>
                </li>

                <li><a id="A72" runat="server" href="~/mod_ninos/NNAVigentes.aspx"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>Niños, Niñas y Adolescentes Vigentes</a></li>

                <li><a id="A73" target="_blank" runat="server" href="https://www.senainfo.cl/centro-de-documentacion/"><span class="glyphicon glyphicon-file" aria-hidden="true"></span>Centro de Documentación</a></li>

                <uc1:C_Notificacion ID="notifControl" runat="server" />

                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false" title="Pinche Aquí Para Ver Opciones del Usuario">
                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                        <asp:Label ID="lbl_name" runat="server" ForeColor="White" Text="Label"></asp:Label>
                    </a>
                    <ul class="dropdown-menu" role="menu">
                        <li class="dropdown-submenu">
                            <a tabindex="-1" href="#"><span class="glyphicon glyphicon-refresh" aria-hidden="true"></span>Cambiar de Sistema</a>
                            <ul class="dropdown-menu">
                                <li><a href="http://historico.senainfo.cl" target="_blank">Historico</a></li>
                                <li><a href="http://financiero.senainfo.cl" target="_blank">Financiero</a></li>
                            </ul>
                        </li>
                        <li class="divider"></li>
                        <li>
                            <asp:LinkButton ID="lnk_CerrarSesion" runat="server" OnClick="lnk_CerrarSesion_Click" ForeColor="Black">
                                        <span class="glyphicon glyphicon-off" aria-hidden="true"></span> Cerrar Sesión
                            </asp:LinkButton>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</nav>
