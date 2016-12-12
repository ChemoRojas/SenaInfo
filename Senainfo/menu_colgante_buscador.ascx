<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_colgante_buscador.ascx.cs" Inherits="menu_colgante_buscador" %>

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
    .dropdown-submenu
    {
        position: relative;
    }

        .dropdown-submenu > .dropdown-menu
        {
            top: 0;
            left: 100%;
            margin-top: -6px;
            margin-left: -1px;
            -webkit-border-radius: 0 6px 6px 6px;
            -moz-border-radius: 0 6px 6px 6px;
            border-radius: 0 6px 6px 6px;
        }

        .dropdown-submenu > a:after
        {
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

        .dropdown-submenu:hover > a:after
        {
            border-left-color: #555;
        }

        .dropdown-submenu.pull-left
        {
            float: none;
        }

            .dropdown-submenu.pull-left > .dropdown-menu
            {
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
                <li class="active" id="home" runat="server"><a id="A2" href="~/mod_buscador/buscador.aspx" runat="server"><span class="glyphicon glyphicon-home" aria-hidden="true"></span> Inicio</a></li>

                
                <li class="dropdown" id="Li7" runat="server">
                    <a href="#" class="dropdown-toggle glyphicon glyphicon-eye-open"  data-toggle="dropdown" role="button" aria-expanded="false"> Diagnóstico <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span></a>
                      <ul class="dropdown-menu" role="menu">
                         <!--<asp:Literal ID="menu_dinamico" runat="server" Mode="PassThrough"></asp:Literal>-->
                        <li id="Li8" runat="server" visible="true"><a id="A7" runat="server" target="_self" href="~/mod_ejecucion/Buscador.aspx">Realizar diagnóstico</a></li>
                        <li id="Li9" runat="server" visible="true"><a id="A8" runat="server" target="_self" href="~/mod_ejecucion/BuscarCalendario.aspx">Plan de intervención individual</a></li>

                    </ul>
                </li>

                <li class="dropdown" id="menu_menu" runat="server">
                    <a href="#" class="dropdown-toggle glyphicon glyphicon-cog"  data-toggle="dropdown" role="button" aria-hidden="true"> Planificación <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span></a>
                    <ul class="dropdown-menu" role="menu">

                  
                        <li id="Li3" runat="server" visible="true"><a id="A5" runat="server" target="_self" href="~/mod_ejecucion/Buscador.aspx">Planificar Modulo</a></li>
                        <li id="Li6" runat="server" visible="true"><a id="A3" runat="server" target="_self" href="~/mod_ejecucion/BuscarCalendario.aspx">Ejecutar Modulo</a></li>

                    </ul>
                </li>

                <li class="dropdown" id="Li1" runat="server">
                    <a href="#" class="dropdown-toggle glyphicon glyphicon glyphicon-tasks" data-toggle="dropdown" role="button" aria-hidden="true"> Evaluación <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span></a>
                    <ul class="dropdown-menu" role="menu">

                        
                        <li id="Li2" runat="server" visible="true"><a id="A4" runat="server" target="_self" href="~/mod_evaluacion/BuscadorInformes.aspx">Búsqueda de informes</a></li>

                    </ul>
                </li>

                <li class="dropdown" id="Li4" runat="server">
                    <a href="#" class="dropdown-toggle glyphicon glyphicon glyphicon-hdd" data-toggle="dropdown" role="button" aria-hidden="true"> Mantenedor <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span></a>
                    <ul class="dropdown-menu" role="menu">


                        <li id="Li5" runat="server" visible="true"><a id="A6" runat="server" target="_self" href="~/mod_mantenedores/Mant_Actividades.aspx">Actividad</a></li>
                        <li id="Li10" runat="server" visible="true"><a id="A9" runat="server" target="_self" href="~/mod_mantenedores/Mant_Areas.aspx">Área</a></li>
                        <li id="Li11" runat="server" visible="true"><a id="A10" runat="server" target="_self" href="~/mod_mantenedores/Mant_Calendario.aspx">Calendario</a></li>
                        <li id="Li12" runat="server" visible="true"><a id="A11" runat="server" target="_self" href="~/mod_mantenedores/Mant_Documentos.aspx">Documento</a></li>
                        <li id="Li13" runat="server" visible="true"><a id="A12" runat="server" target="_self" href="~/mod_mantenedores/Mant_Modulos.aspx">Modulo</a></li>
                        <li id="Li14" runat="server" visible="true"><a id="A13" runat="server" target="_self" href="~/mod_mantenedores/Mant_Objetivos.aspx">Objetivo</a></li>
                        <li id="Li15" runat="server" visible="true"><a id="A14" runat="server" target="_self" href="~/mod_mantenedores/Mant_PreguntasModulo.aspx">Pregunta Modulo</a></li>
                        <li id="Li16" runat="server" visible="true"><a id="A15" runat="server" target="_self" href="~/mod_buscadorHoja/buscador.aspx">Anotaciones NNA</a></li>

                    </ul>
                </li>

             

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
                                <li id="buscador_ninos" runat="server" visible="true"><a id="Busca01" runat="server" href="~/mod_buscador/buscador.aspx">Buscador</a></li>
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