<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="NinosEnProyecto.aspx.cs" Inherits="NinosEnProyecto" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
  <head id="Head1" runat="server">>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="images/favicon.ico">

    <title>Niños, Niñas y Adolescentes Vigentes :: Senainfo :: Servicio Nacional de Menores</title>

        <link href="css/bootstrap.min.css" rel="stylesheet">
        <link href="css/bootstrap-theme.min.css" rel="stylesheet">
        <link href="css/theme.css" rel="stylesheet">

        <script src="js/jquery-1.11.1.min.js"></script> 
        <script src="js/jquery-migrate-1.2.1.min.js"></script>


      <link href="css/jquery-ui.css" rel="stylesheet" />
      <script src="js/jquery-1.10.2.js"></script>
      <script src="js/jquery-ui.js"></script>

      <script>
          $(document).ready(function () {
              $('#p1').on('click', function () {
                  $('#r1').toggle('slow');
              });
              $('#p2').on('click', function () {
                  $('#r2').toggle('slow');
              });
          });
    </script>

    <script language="JavaScript" type="text/javascript">
<!--
    function multiLoad2(doc1, doc2) {
        parent.bottomFrame.location.href = doc1;
        parent.mainFrame.location.href = doc2;
    }
    //--> 
    </script>
    
    <script>
        $(function () {
            var availableTags = [
               <%=autocom%>
            ];
            $("#tags").autocomplete({
                source: availableTags
            });
        });
    </script>

</head>
<body>
    <form name="form1" id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        
        <div class="container theme-showcase" role="main">
            <div class="jumbotron">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><span class="glyphicon glyphicon-th-list" aria-hidden="true"></span> Niños en Proyecto <span class="badge"><asp:Literal ID="TotalNNA" runat="server"></asp:Literal></span></h3>
                            </div>
                            <br />
                            <div class="ui-widget">
                            <div class="col-sm-8">
                                <asp:TextBox ID="tags" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="bt_selecionarNNA" runat="server" Text="Seleccionar" CssClass="btn btn-primary btn-block" OnClick="bt_selecionarNNA_Click" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="bt_limpiar" runat="server" Text="Limpiar" CssClass="btn btn-info btn-block" OnClick="bt_limpiar_Click" />
                            </div>
                            <div class="col-sm-12">
                                <div id="alert" runat="server" class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-warning-sign" aria-hidden="true"></span> <asp:Label ID="lb_busqueda" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <ul>
                                <li>
                                    <a href="#" id="p1">Registro de Eventos e Intervención Pendientes <span class="badge"><asp:Literal ID="CantidadNNA" runat="server"></asp:Literal></span></a></li>
                                    <div id="r1" style="display:none">
                                        <asp:Literal ID="NNAVigentes" runat="server"></asp:Literal>
                                    </div>
                                <li>
                                    <a href="#" id="p2">Falta de Registro de Eventos e Intervención Mayores a 5 días <span class="badge">2</span></a>
                                </li>
                                <div id="r2" style="display:none">
                                    <ul>
                                        <li><a href="#">Cristian Castillo</a></li>
                                        <li><a href="#">Roberto Aguilera</a></li>
                                    </ul>
                                </div>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div><!-- /Jumbotron -->
    </div> <!-- /container -->


    <footer class="footer">
        <div class="container">
            <p>Para tus dudas y consultas, escribe a: <br> mesadeayuda@sename.cl</p>
        </div>
    </footer>

    <%--<script src="js/jquery.min.js"></script>--%>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/ie10-viewport-bug-workaround.js"></script>
    <%--<script src="http://code.jquery.com/jquery-latest.js"></script>--%>

        </form>
    </body>
</html>