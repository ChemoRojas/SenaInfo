<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Noticias.aspx.cs" Inherits="Noticias" %>

<!DOCTYPE html>
<html lang="es">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>::Noticias - SENAINFO::</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">
  
    <!------------- PERSONAL STYLES ---------------->
    <link href="css/main.css" rel="stylesheet">

    <!------------- AWESOME FONT ICON ---------------->
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet">

    <script src="js/jquery-1.11.1.min.js"></script> 
    <script src="js/jquery-migrate-1.2.1.min.js"></script>
  <body>

      <form id="form1" runat="server">

    <!------------------------------------- COMIENZO  HEADER -------------------------------------->
    <div class="header-banner" id="header-top">
        <div class="container">
            <div class="row">
                <article class="col-md-12">
                    <div class="logo">
                        <a href="~/autenticacion.aspx" runat="server"><img src="images/header_senainfo.png" alt="header-senainfo"></a>
                    </div>
                </article>
            <!--<aside class="col-md-7">

                </aside>-->
            </div>
        </div>
    </div>

    <br><br>

    <section class="container">
      <div class="row">
        <div class="col-md-8 content-single">
          <div class="azul"></div>
          <div class="rojo"></div>
          <div class="home"><a href="~/autenticacion.aspx" runat="server"><i class="fa fa-home"></i></a></div>
          <h1>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod</h1> 
          <p class="date"><strong>Publicado</strong> 12 Septiembre 2015</p>
          <img src="http://placehold.it/750x300/cccccc/ffffff" alt="...">
          </br>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
          tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
          quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
          consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
          cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
          proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
          </p>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
          tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
          quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
          consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
          cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
          proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
          </p>
          <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod llum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
          proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
          </p>
        </div>
        <aside class="col-md-4 post-principal">
          <div class="content-aside">
            <div class="page-header2">
           <h3><i class="fa fa-file-text-o"></i> Noticias</h3>
            </div>
              <h5 class="titulo-noticias waves-effect"><a href="~/Noticias.aspx" runat="server">Lorem Ipsum es simplemente 1</a></h5>
              <h5 class="titulo-noticias waves-effect"><a href="~/Noticias.aspx" runat="server">Lorem Ipsum es simplemente 2</a></h5>
              <h5 class="titulo-noticias waves-effect"><a href="~/Noticias.aspx" runat="server">Lorem Ipsum es simplemente 3</a></h5>
            <br>
            <button type="submit" class="btn btn-sename-md">Ver todas las noticias</button>
            <br>
          </div>
          <div class="content-aside">
            <div class="page-header2">
              <h3><i class="fa fa-angle-right"></i> Centro de documentación</h3>
            </div>
            <a href="#"><img src="images/sidebar1.png" alt=""></a>
          </div>
          <div class="content-aside">
            <div class="page-header2">
              <h3><i class="fa fa-angle-right"></i> Mesa de ayuda</h3>
            </div>
            <a href="mailto:mesadeayuda@sename.cl"><img src="images/siderbar2.png" alt=""></a>
          </div>
        </aside>
      </div>
    </section>

   

    <!------------------------------- bg-input ---------------------------->

    <br>
    <footer class="footer">
        <div class="container">
            <p>Copyright (c) Servicio Nacional de Menores - Chile </br>
            Dirección Nacional: Huérfanos 587 Santiago Centro / Teléfono: (02) 23984000 </br>
            Todos los derechos reservados / Políticas de Privacidad</p>
        </div>
    </footer>

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/ie10-viewport-bug-workaround.js"></script>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
              </form>
  </body>
</html>