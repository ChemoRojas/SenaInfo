<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="~/autenticacion.aspx.cs"  Inherits="autenticacion" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>::Bienvenido a SENAINFO::</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">

    <!------------- PERSONAL STYLES ---------------->
    <link href="css/main.css" rel="stylesheet">

    <!------------- AWESOME FONT ICON ---------------->
    <link href="css/font-awesome/css/font-awesome.min.css" rel="stylesheet">

    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/jquery-migrate-1.2.1.min.js"></script>
    <script>
        function frameKiller() {
            if (self == top) {
                document.documentElement.style.display = 'block';
            } else {
                top.location = self.location;
            }
        }

        $(function () {
            frameKiller();
        });
    </script>
    <body>

        <form id="form1" runat="server">

            <!------------------------------------- COMIENZO  HEADER -------------------------------------->
            <div class="header-banner" id="header-top">
                <div class="container">
                    <div class="row">
                        <article class="col-md-12">
                            <div class="logo">
                                <a href="~/autenticacion.aspx" runat="server">
                                    <img src="images/header_senainfo.png" alt="header-senainfo"></a>
                            </div>
                        </article>
                        <!--<aside class="col-md-7">

                </aside>-->
                    </div>
                </div>
            </div>

            <br>
            <br>

                <main class="container">
      <section class="row">
        <article class="col-md-4">
          <!--<div class="card card-container">
              <h3 id="profile-name" class="profile-name-card"><i class="fa fa-sign-out"></i> Ingreso</h3>
              <form class="form-signin">
                  <span id="reauth-email" class="reauth-email"></span>
                  <input type="email" id="inputEmail" class="form-control" placeholder="Usuario" required autofocus>
                  <input type="password" id="inputPassword" class="form-control" placeholder="Contraseña" required>
                  <div id="remember" class="checkbox">
                      <label>
                          <input type="checkbox" value="remember-me">Recordar mis datos
                      </label>
                  </div>
                  <button class="btn btn-sename-md btn-block" type="submit"><a class="boton-acceder" href="./index.html">Ingresar</a></button>
                  <button class="btn btn-sename-md btn-block" data-toggle="modal" data-target="#myModal">Cambiar mi clave</button>
              </form>-->

              <form class="card card-container">
              <h3 id="profile-name" class="profile-name-card"><i class="fa fa-sign-out"></i> Ingreso</h3>
                <div class="row">
                  <div class="input-field col-sm-12">
                      <label for="txt_usuario">Usuario</label>
            </br>
            <%--<input id="email" type="email" class="validate form-control">--%>
            <asp:TextBox ID="txt_usuario" runat="server" class="validate form-control" required="" autocomplete="off"></asp:TextBox>
            </div>
                </div>
                <div class="row">
                    <div class="input-field col-sm-12">
                        <label for="txt_password">Contraseña</label>
                        <%--<input id="password" type="password" class="form-control validate">--%>
                        <asp:TextBox ID="txt_password" runat="server" TextMode="Password" class="validate form-control" required=""></asp:TextBox>
                        <!--<label for="txt_password">Contraseña</label>-->
                    </div>
                </div>
            <div class="row">
                <div class="input-field col-sm-12">
                    <%--<p>
                        <input type="checkbox" id="test5">
                        <label for="test5">Recordar mis datos</label>
                    </p>--%>
                    <br>
                    <%--<asp:Button ID="imb_ingresar" runat="server" Text="Ingresar" OnClick="imb_ingresar_Click1" CssClass="btn btn-sename-md btn-block" />--%>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imb_ingresar_Click1" CssClass="btn btn-sename-md btn-block">Ingresar</asp:LinkButton>
                    <asp:LinkButton ID="lnk001" runat="server" OnClick="lnk001_Click" CssClass="btn btn-sename-md btn-block">Cambiar Contraseña</asp:LinkButton>


                    <%--<a class="btn btn-sename-md btn-block">Ingresar</a>
                      <a class="btn btn-sename-md btn-block">Cambiar clave</a>--%>
                    <br />
                    <%--<br />--%>
                    <div id="alerta" class="alert alert-danger" role="alert" runat="server">
                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>
                        <asp:Label ID="lbl_aviso" runat="server" BackColor="Transparent" BorderColor="Transparent"></asp:Label>
                    </div>
                </div>
            </div>
        </form>
        </div>
        </article>






        <%--<!-- RECUPERACION DE CLAVE -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Cambiar clave</h4>
              </div>
              <div class="modal-body">
                <div class="row">
                  <div class="col-md-12">
                    <form>
                    <div class="form-group">
                      <label for="exampleInputEmail1">E-mail</label>
                      <input type="email" class="form-control" id="exampleInputEmail1">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Contraseña</label>
                      <input type="password" class="form-control" id="exampleInputPassword1">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Contraseña nueva</label>
                      <input type="password" class="form-control" id="Password1">
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">Repetir contraseña nueva</label>
                      <input type="password" class="form-control" id="Password2">
                    </div>
                    <div class="checkbox">
                      <label>
                        <input type="checkbox"> Deseo realizar los cambios
                      </label>
                    </div>
                    <button type="submit" class="btn btn-default">Hacer cambios</button>
                  </form>
                  </div>
                </div>  
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Salir</button>
              </div>
            </div>
          </div>
        </div>--%>


        <aside class="col-sm-8">
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="images/slider1.jpg" alt="...">
                        <div class="carousel-caption carousel-caption-login">
                            <h3><a href="./single.html">Se da inicio la marcha blanca de Nueva Senainfo</a></h3>
                            <p>Gradualmente se iran incorporando nuevos funcionalidades del sistema.</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="images/slider2.jpg" alt="...">
                        <div class="carousel-caption carousel-caption-login">
                            <h3><a href="./single.html">Nueva Senainfo: Presentación en regiones</a></h3>
                            <p>Integrantes del equipo Senainfo visitan distintas regiones para presentar las mejoras del sistema.</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="images/slider3.jpg" alt="...">
                        <div class="carousel-caption carousel-caption-login">
                            <h3><a href="./single.html">Sename presenta nueva Misión, Visión y Valores</a></h3>
                            <p>Las propuestas finales fueron elaboradas a partir de las ideas de funcionarios/as de todo el país.</p>
                        </div>
                    </div>
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="fa icon-slider-home fa-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="fa icon-slider-home fa-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </aside>
        </section>
    </main>

    <main class="container">
      <section class="row">
         <hgroup class="col-md-4 post-principal">
          <div class="page-header2">
           <h3><i class="fa fa-file-text-o"></i> Noticias</h3>
          </div>
            <h5 class="titulo-noticias waves-effect"><a href="~/Noticias.aspx" runat="server">Lorem Ipsum es simplemente 1</a></h5>
            <h5 class="titulo-noticias waves-effect"><a href="~/Noticias.aspx" runat="server">Lorem Ipsum es simplemente 2</a></h5>
            <h5 class="titulo-noticias waves-effect"><a href="~/Noticias.aspx" runat="server">Lorem Ipsum es simplemente 3</a></h5>
          <br>
          <button type="submit" class="btn btn-sename-md"><a class="boton-acceder" href="#">Ver todas las noticias</a></button>
          <br>
        </hgroup>
        <div class="col-md-4">
          <div class="page-header2">
            <h3><i class="fa fa-angle-right"></i> Centro de documentación</h3>
          </div>
          <a href="#"><img src="images/sidebar1.png" alt=""></a>
        </div>
        <div class="col-md-4">
          <div class="page-header2">
            <h3><i class="fa fa-angle-right"></i> Mesa de ayuda</h3>
          </div>
          <a href="mailto:mesadeayuda@sename.cl"><img src="images/siderbar2.png" alt=""></a>
        </div>
      </section>
    </main>

        <!------------------------------- bg-input ---------------------------->

        <br>
            <footer class="footer">
                <div class="container">
                    <p>
                        Copyright (c) Servicio Nacional de Menores - Chile </br>
        Dirección Nacional: Huérfanos 587 Santiago Centro / Teléfono: (02) 23984000 </br>
            Todos los derechos reservados / Políticas de Privacidad</p>
        </div>
    </footer>

        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/ie10-viewport-bug-workaround.js"></script>
        <script src="js/jquery-latest.js"></script>

        </form>

    </body>
</html>