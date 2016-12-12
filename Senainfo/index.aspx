<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Index" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel="icon" href="images/favicon.ico">

    <script type="text/javascript" src="js/jquery-2.1.4.js"></script>
    <script type="text/javascript" src="js/jquery-2.1.4.min.js"></script>
    <%--<script type="text/javascript" src="js/bootstrap.min.js"></script>--%>
    <%--    <script type="text/javascript" src="js/bootstrap.js"></script>--%>
    <script type="text/javascript" src="js/bootstrap3.3.4.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="js/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="js/senainfoTools.js"></script>
    <script type="text/javascript" src="js/notify.js"></script>

    <link type="text/css" href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link type="text/css" href="css/bootstrap-theme.min.css" rel="stylesheet">
    <%--<link type="text/css" href="css/animate.css" rel="stylesheet" />--%>
    <%--<link type="text/css" href="css/animate.min.css" rel="stylesheet" />--%>
    <!-- Custom styles for this template -->
    <link type="text/css" href="css/theme.css" rel="stylesheet">

    <title>Página Principal :: Senainfo :: Servicio Nacional de Menores</title>
    <script type="text/javascript">

        $(function () {
            //generateDataTable($("#GridAlertas"), function(){);
            if ($("#GridAlertasEgresosPendientesxCausal").length > 0) {
                console.log("entro1");
                //generateDataTable($("#GridAlertasEgresosPendientesxCausal"));
            }
            
            if ($("#GridAlertasListaEsperaxAbuso").length > 0) {
                console.log("entro 2");
                //generateDataTable($("#GridAlertasListaEsperaxAbuso"));
            }

            if ($("#GridAlertasEgresosxTraslado").length > 0) {
                console.log("entro 3");
                //generateDataTable($("#GridAlertasEgresosxTraslado"));
            }
            
            
        });

    </script>
</head>

<body>

    <form name="form1" id="form1" runat="server">

        <style type="text/css">
            .ocultar-columna {
                display: none;
            }

            tr td {
                /*color: black;*/
                /*white-space: pre-line;*/
                text-align: center;
            }

                tr td .descripcion {
                }

            th {
                white-space: nowrap;
                text-transform: uppercase;
                text-align: center;
            }

            .panel-default {
                border: none;
            }

            .col-md-1 {
                width: auto;
            }

            #collapse {
                text-decoration: none;
            }

            .badge {
                background-color: #337ab7;
                width:50px;
            }
        </style>

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <div class="container theme-showcase" id="CuadroInformativo" role="main">
            <div class="all">
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-bienvenida">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-bullhorn" aria-hidden="true"></span>
                                    Bienvenido <strong>
                                        <asp:Label ID="lb_NombreUsuario" runat="server">
                                        </asp:Label></strong> al Nuevo Senainfo !!!</h3>
                            </div>
                            <div class="panel-body">
                                <div class="row seven-cols">
                                    <div class="col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">NUEVA MIRADA</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index01.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">Se han considerado las inquietudes de los usuarios
                                      y le dimos una nueva mirada y un diseño mucho más 
                                      amigable y facil de utilizar.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="row col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">NUEVO MENÚ</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index02.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">Se eliminaron las "botoneras" y se reemplazo por un menú desplegable
                                      que facilita el acceso a la información.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">MULTINAVEGADOR</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index03.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">Senainfo ahora funciona en todos los navegadores. Recomendamos usar Google Chrome.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">NO MÁS PESTAÑEOS</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index04.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">Nunca más saltos en las páginas, la nueva interfaz 
                                      permite actualizar la información dinámicamente.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">ALL IN ONE</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index05.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">El nuevo concepto de SenaInfo, permite buscar una sola vez y a 
                                      medida que avanza utiliza la información almacenada sin volver a buscar.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">MÁS INFORMACIÓN</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index06.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">Se aumentaron los registros de datos y se actualizaron 
                                      las paramétricas con la finalidad de obtener información más exacta de los NNA.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="text-center">
                                            <span class="titulosIndex">MÁS SEGURIDAD</span>
                                        </div>
                                        <br />
                                        <div class="text-center">
                                            <img src="images/index07.png" width="75pt" height="75pt" />
                                        </div>
                                        <br />
                                        <div class="text-justify">
                                            <span class="cuerposIndex">Sistema SSL, consistente en la encriptación de la conexión 
                                      entre usuarios y servidor. Lo que permite mayor confiabilidad de la información.
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="text-center">
                                    <br />
                                    <h4>Para iniciar, haga click en la zona superior en "Menu" y seleccione donde quiere ir.</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <div id="Alertas" class="container theme-showcase" role="main" runat="server" visible="true">
            <div class="all">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-bienvenida" id="divAlertas">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-bullhorn" aria-hidden="true"></span>
                                    <%-- <a role="button" id="collapse" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Alertas Activas 
                                    </a>--%>
                                    <span>Alertas Activas</span>
                                    <%--<span class="badge">
                                        <asp:Label runat="server" ID="NumeroAlertas"></asp:Label>
                                    </span>--%>
                            </div>
                            <div class="panel-body">

                                <asp:Label runat="server" CssClass="badge" ID="numAlertasEgresosPendientesxCausal"></asp:Label>
                                <a role="button" id="A1" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#Div1" aria-expanded="true" aria-controls="Div1">Alertas Egresos Pendientes por Causal 
                                </a>
                                <div id="Div1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="AlertaOne">
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="GridAlertasEgresosPendientesxCausal" OnRowCommand="GridAlertasEgresosPendientesxCausal_RowCommand" data-name="GridAlertasEgresosPendientesxCausal" CssClass="table table-bordered table-hover caja-tabla" Visible="true" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField HeaderText="Código Alerta" DataField="CODALERTA" />
                                                <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" />
                                                <asp:BoundField HeaderText="Código Niño" DataField="CODNINO" />
                                                <asp:BoundField HeaderText="Apellido Paterno" DataField="APELLIDO_PATERNO" />
                                                <asp:BoundField HeaderText="Apellido Materno" DataField="APELLIDO_MATERNO" />
                                                <asp:BoundField HeaderText="Nombres" DataField="NOMBRES" />
                                                <asp:BoundField HeaderText="Descripción" DataField="DESCALERTA" />
                                                <asp:BoundField HeaderText="URL" DataField="URL" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodProyecto" DataField="Codproyecto" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodInstitucion" DataField="CodInstitucion" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CUA" DataField="Cua" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:ButtonField HeaderText="" CommandName="Resolver" Text="Resolver" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <asp:Label runat="server" ID="numAlertaListaEspera" CssClass="badge"></asp:Label>
                                <a role="button" id="A2" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#Div2" aria-expanded="true" aria-controls="Div2">Alertas Lista de Espera por Abuso 
                                </a>
                                <div id="Div2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="AlertaTwo">
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="GridAlertasListaEsperaxAbuso" OnRowCommand="GridAlertasListaEsperaxAbuso_RowCommand" data-name="GridAlertasListaEsperaxAbuso" CssClass="table table-bordered table-hover caja-tabla" Visible="true" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField HeaderText="Código Alerta" DataField="CODALERTA" />
                                                <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" />
                                                <asp:BoundField HeaderText="Código Niño" DataField="CODNINO" />
                                                <asp:BoundField HeaderText="Apellido Paterno" DataField="APELLIDO_PATERNO" />
                                                <asp:BoundField HeaderText="Apellido Materno" DataField="APELLIDO_MATERNO" />
                                                <asp:BoundField HeaderText="Nombres" DataField="NOMBRES" />
                                                <asp:BoundField HeaderText="Descripción" DataField="DESCALERTA" />
                                                <asp:BoundField HeaderText="URL" DataField="URL" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodProyecto" DataField="Codproyecto" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodInstitucion" DataField="CodInstitucion" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CUA" DataField="Cua" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:ButtonField HeaderText="" CommandName="Resolver" Text="Resolver" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                 <asp:Label runat="server" ID="numAlertaEgresosxTraslado" CssClass="badge"></asp:Label>
                                <a role="button" id="A3" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#Div3" aria-expanded="true" aria-controls="Div3">Alertas Egresos por Traslado
                                </a>
                                <div id="Div3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="AlertaThree">
                                    <div class="panel-body">
                                        <asp:GridView runat="server" ID="GridAlertasEgresosxTraslado" OnRowCommand="GridAlertasEgresosxTraslado_RowCommand" data-name="GridAlertasEgresosxTraslado" CssClass="table table-bordered table-hover caja-tabla" Visible="true" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField HeaderText="Código Alerta" DataField="CODALERTA" />
                                                <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" />
                                                <asp:BoundField HeaderText="Código Niño" DataField="CODNINO" />
                                                <asp:BoundField HeaderText="Apellido Paterno" DataField="APELLIDO_PATERNO" />
                                                <asp:BoundField HeaderText="Apellido Materno" DataField="APELLIDO_MATERNO" />
                                                <asp:BoundField HeaderText="Nombres" DataField="NOMBRES" />
                                                <asp:BoundField HeaderText="Descripción" DataField="DESCALERTA" />
                                                <asp:BoundField HeaderText="URL" DataField="URL" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodProyecto" DataField="Codproyecto" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CodInstitucion" DataField="CodInstitucion" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:BoundField HeaderText="CUA" DataField="Cua" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                <asp:ButtonField HeaderText="" CommandName="Resolver" Text="Resolver" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <%--<div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">--%>
                                <%--<div class="panel panel-default">--%>
                                <%--<div id="collapseOne" runat="server" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                            <%--<div class="panel-body">--%>
                                <%--<asp:GridView runat="server" ID="GridAlertas" data-name="GridAlertas" CssClass="table table-bordered table-hover" Visible="true" AutoGenerateColumns="false"
                                                    OnRowCommand="GridAlertas_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Código Alerta" DataField="CODALERTA" />
                                                        <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" />
                                                        <asp:BoundField HeaderText="Código Niño" DataField="CODNINO" />
                                                        <asp:BoundField HeaderText="Apellido Paterno" DataField="APELLIDO_PATERNO" />
                                                        <asp:BoundField HeaderText="Apellido Materno" DataField="APELLIDO_MATERNO" />
                                                        <asp:BoundField HeaderText="Nombres" DataField="NOMBRES" />
                                                        <asp:BoundField HeaderText="Descripción" DataField="DESCALERTA" />
                                                        <asp:BoundField HeaderText="URL" DataField="URL" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                        <asp:BoundField HeaderText="CodProyecto" DataField="Codproyecto" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                        <asp:BoundField HeaderText="CodInstitucion" DataField="CodInstitucion" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                        <asp:BoundField HeaderText="CUA" DataField="Cua" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                                                        <asp:ButtonField HeaderText="" CommandName="Resolver" Text="Resolver" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="titulo-tabla" />
                                                </asp:GridView>--%>
                                <%--</div>--%>
                                <%--</div>--%>
                                <%--</div>--%>
                                <%--</div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" style="height: 15px">&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lbl_avisos2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px" ForeColor="Navy" Width="100%"></asp:Label></td>
            </tr>

            <tr>
                <td class="linea_inferior" style="height: 16px">
                    <asp:Label ID="lbl_avisos" runat="server" Width="100%" Font-Bold="True" Font-Names="Arial" Font-Size="12px" ForeColor="Navy"></asp:Label></td>
            </tr>
        </table>

        <div class="col-md-12">
            <%--<uc2:alerta runat="server" ID="alerta1" />--%>
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

        <%--<uc2:Referencias runat="server" ID="Referencias" />--%>

        <%--<script>
            $(document).ready(function () {
                $('#grd001').DataTable({
                    searching: true,
                    sort: false,
                    paging: false,
                });
            });

            $(document).ready(function () {
                if ($("#grd001").length > 0) {
                    $("#divAlertas").notify(
                    "Hay alertas que deberías revisar!",
                  {
                      // whether to hide the notification on click
                      clickToHide: true,
                      // whether to auto-hide the notification
                      autoHide: true,
                      // if autoHide, hide after milliseconds
                      autoHideDelay: 5000,
                      // show the arrow pointing at the element
                      arrowShow: true,
                      // arrow size in pixels
                      arrowSize: 5,
                      // default positions
                      //globalPosition: 'top right',
                      elementPosition: 'top center',
                      // default style
                      style: 'bootstrap',
                      // default class (string or [string])
                      className: 'info',
                      // show animation
                      showAnimation: 'slideDown',
                      // show animation duration
                      showDuration: 400,
                      // hide animation
                      hideAnimation: 'slideUp',
                      // hide animation duration
                      hideDuration: 200,
                      // padding between element and notification
                      gap: 2
                  }
                  )
                };
            });
        </script>--%>
        <%--<script src="js/bootstrap3.3.4.min.js"></script>
        <script src="js/ie10-viewport-bug-workaround.js"></script>--%>
    </form>
</body>
</html>
