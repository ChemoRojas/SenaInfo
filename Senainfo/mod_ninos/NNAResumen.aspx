<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="NNAResumen.aspx.cs" Inherits="ResumenNNA" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    >
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Resumen NNA :: Senainfo :: Servicio Nacional de Menores</title>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
</head>
<body>
    <form name="form1" id="form2" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <div class="container theme-showcase" role="main">
            <div class="jumbotron">

                <div class="row">

                    <div class="col-sm-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>Resumen NNA</h3>
                            </div>
                            <div class="panel-body">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12 caja-tabla">
                                            <table class="table table-bordered table-col-fix table-condensed">
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Nombre de la Institución</th>
                                                    <td>
                                                        <asp:TextBox ID="tb_nombre_institucion" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Código de Proyecto</th>
                                                    <td>
                                                        <asp:TextBox ID="tb_codigo_proyecto" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Nombre del NNA</th>
                                                    <td>
                                                        <asp:TextBox ID="tb_nombre_nna" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Apellido Paterno</th>
                                                    <td>
                                                        <asp:TextBox ID="tb_apellido_paterno" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Apellido Materno</th>
                                                    <td>
                                                        <asp:TextBox ID="tb_apellido_materno" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Fecha de Nacimiento</th>
                                                    <td>
                                                        <asp:TextBox ID="tb_fecha_nacimiento" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-12">
              <div class="panel panel-primary">
                <div class="panel-heading">
                  <h3 class="panel-title"><span class="glyphicon glyphicon-share-alt" aria-hidden="true"></span> Ir a:</h3>
                </div>
                <div class="panel-body">
                    <ul>
                        <li id="ii_datos_de_gestion" runat="server"><a id="A1" runat="server" href="~/mod_ninos/DatosdeGestion.aspx">Datos de Gestión</a></li>
                        <li id="ii_diagnostico_del_nino" runat="server"><a id="A2" runat="server" href="~/mod_ninos/ninos_diagnosticoninos.aspx">Diagnóstico del Niño</a></li>
                        <li id="iii_nuevo_plan_intervencion" runat="server"><a id="A3" runat="server" href="~/mod_ninos/plan_intervencion_new.aspx">Nuevo Plan de Intervención</a></li>
                        <li id="iii_gestionar_plan_intervencion" runat="server"><a id="A4" runat="server" href="~/mod_ninos/pi_gestion.aspx">Gestionar Plan de Intervención</a></li>
                        <li id="ii_egresos" runat="server"><a id="A5" runat="server" href="~/mod_ninos/ninos_egreso.aspx">Egresos</a></li>
                    </ul>
                </div>
              </div>
            </div>
                </div>
            </div>
        </div>
        <!-- /Jumbotron -->
        </div>
        <!-- /container -->


        <footer class="footer">
            <div class="container">
                <p>Para tus dudas y consultas, escribe a:
                    <br>
                    mesadeayuda@sename.cl</p>
            </div>
        </footer>

        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
        <script src="http://code.jquery.com/jquery-latest.js"></script>

    </form>
</body>
</html>