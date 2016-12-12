<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/mod_ninos/cierre_resumenatencion.aspx.cs" Inherits="mod_institucion_cierre_resumenatencion" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="../images/favicon.ico" />

    <title>Resumen Atención Mensual :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />

     <script type="text/javascript">
         


         



         

     </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <ajax:ModalPopupExtender ID="mpe1" runat="server"
                    TargetControlID="Imb002"
                    PopupControlID="modal_imprimir"
                    DropShadow="true"
                    CancelControlID="bt_cerrar_imprmir"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <input type="hidden" id="Buscando" value="0">
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
                <div>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Resumen Atención Mensual</li>
                        </ol>
                        <div class="text-center alert alert-warning" role="alert" id="alert_lb_5y4" runat="server">
                                <asp:Label ID="lbl_aviso5" runat="server" Text="Aviso: Este Mes fue cerrado, solo Administrador podrá realizar cambios" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_aviso4" runat="server" Visible="False"></asp:Label>
                                <%--<strong>Oh snap!</strong> Change a few things up and try submitting again.--%>
                            </div>
                        <div class="text-center alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                                        <asp:Label ID="lbl_aviso1" runat="server" Text="Aviso: Se ha detectado un descuadre con los vigentes del mes anterior, contáctese con el administrador." Visible="False"></asp:Label>
                                        <asp:Label ID="lbl_aviso2" runat="server" Text="Aviso: Se ha detectado un descuadre en el mes actual, contáctese con el administrador." Visible="False"></asp:Label>
                                        <asp:Label ID="lbl_aviso3" runat="server" Text="Aviso: No se puede cerrar este mes sin haber realizado esta operación los meses anteriores. " Visible="False"></asp:Label>
                                    </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Resumen Atención Mensual</h4>
                            <hr>

                          <a id="collapse" data-toggle="collapse" data-parent="#accordion" class="collapsed"  href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                                  <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Mostrar Detalles de la Búsqueda"></asp:label>
                                    <span id="icon-collapse" class="glyphicon glyphicon-triangle-bottom" ></span>
                          <asp:label ID="lbl_resumen_filtro" runat="server" Visible ="false" Text=""></asp:label>
                              <asp:label ID="lbl_resumen_proyecto" runat="server" Visible ="false"></asp:label>
                          </a>
                          <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="row">
                            <div class="col-md-9">
                                <asp:Panel ID="pnlBody" runat="server" Visible="True">
                                    <table class="table table-borderless table-condensed">
                                        <tr>
                                            <td class="col-md-3">
                                                <label for="">Institución:</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="">Proyecto:</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="">Periodo Resumen:</label>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddown_MesCierre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_MesCierre_SelectedIndexChanged" CssClass="form-control input-sm">
                                                                <asp:ListItem>Seleccione mes</asp:ListItem>
                                                                <asp:ListItem Value="01">Enero</asp:ListItem>
                                                                <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                                <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                                                <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                                <asp:ListItem Value="06">Junio</asp:ListItem>
                                                                <asp:ListItem Value="07">Julio</asp:ListItem>
                                                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddown_AnoCierre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_MesCierre_SelectedIndexChanged" CssClass="form-control input-sm">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                  </asp:Panel>
                            </div>
                                <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer subtitulo-form-info">
                                             <!--   <label for="">Región:</label><label for="">Sistema Asistencial:</label><label for="">Modelo de Intervención:</label><label for="">Tipo Pago:</label><label for="">Tipo Proyecto:</label>-->
                                                <asp:Label ID="lbl001" runat="server"></asp:Label><br />
                                                <asp:Label ID="lbl002" runat="server"></asp:Label><br />
                                                <asp:Label ID="lbl003" runat="server"></asp:Label><br />
                                                <asp:Label ID="lbl004" runat="server"></asp:Label><br />
                                                <asp:Label ID="lbl005" runat="server"></asp:Label>
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                          </div>
                          </div>
                            <div class="row">
                                <div class="col-md-9">
                                <table class="table table-borderless table-condensed">
                                            <tr>
                                                <td class="col-md-3">
                                                    
                                                </td>
                                                <td>
                              <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="Imb001" runat="server" OnClick="Imb001_Click" ViewStateMode="Disabled" Visible="False" >
                                  <span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span> Atrás
                              </asp:LinkButton>
                              <%--<asp:Button CssClass="btn btn-info btn-sm" ID="Imb002" runat="server" Text="Imprimir" OnClick="Imb002_Click" />--%>
                              <asp:LinkButton CssClass="btn btn-success btn-sm fixed-width-button" ID="Imb002" runat="server">
                                  <span class="glyphicon glyphicon-print" aria-hidden="true"></span> Imprimir
                              </asp:LinkButton>
                              <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="Imb004" runat="server"  OnClick="Imb004_Click" >
                                  <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Cierre y Firma
                              </asp:LinkButton>
                              <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button pull-right" ID="WebImageButton1" runat="server" OnClick="imb_volver_Click" Text="Atrás" >
                                  <span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span> Atrás
                              </asp:LinkButton>
                       </td></tr></table></div>

                          <div class="popupConfirmation" id="modal_imprimir" style="display: none">
                              <%-- "CodProyecto=" + ddown002.SelectedValue + "&AnoMes=" + ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue + "&IdUsr=" + Session["IdUsuario"].ToString(); --%>
                              <%--<iframe id="iframe_buscar" src="Cierre_ResumenAtencionReporte.aspx?CodProyecto=1130226&AnoMes=201504&IdUsr=50490" width="800px" height="600px" runat="server"></iframe>--%>

                              <iframe id="iframe_buscar" src="Cierre_ResumenAtencionReporte.aspx" width="800px" height="600px" runat="server"></iframe>
                              <asp:Button ID="bt_cerrar_imprmir" Text="Cerrar" runat="server" CssClass="btn btn-primary btn-sm" />
                          </div>
                          <br /><br />
                          
                            <!--fin Row -->
                          <div class="row">
                            
                          </div>

                          <div class="row">
                                <div class="col-md-12">
                                    <table class="table table-bordered table-condensed table-hover">
                                        <tr class="titulo-tabla">
                                            <th scope="col"></th>
                                            <th scope="col">Femenino</th>
                                            <th scope="col">Masculino</th>
                                            <th scope="col">Total</th>
                                        </tr>
                                        <tr>
                                            <td>A - Número de niños/as vigentes al último día del mes anterior</td>
                                            <td>
                                                <asp:Label ID="lbl006" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl007" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl008" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>B - Número de ingresos del mes</td>
                                            <td>
                                                <asp:Label ID="lbl009" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl010" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl011" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>C - Número de egresos del mes</td>
                                            <td>
                                                <asp:Label ID="lbl012" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl013" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl014" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Total niños/as - adolecentes vigentes al último día del mes que se informa</td>
                                            <td>
                                                <asp:Label ID="lbl015" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl016" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl017" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                        </tr>
                                    </table>

                                    

                                    <table class="table table-bordered table-condensed table-hover">
                                        <tr class="titulo-tabla">
                                            <th colspan="3">Total Días (A)</th>
                                            <th colspan="3">Total días inasistencias injustificadas (B)</th>
                                            <th colspan="3">Total Días Atendidos (C) </th>
                                        </tr>
                                        <tr>
                                            <th>FEM</th>
                                            <th>MASC</th>
                                            <th>TOTAL</th>
                                            <th>FEM</th>
                                            <th>MASC</th>
                                            <th>TOTAL</th>
                                            <th>FEM</th>
                                            <th>MASC</th>
                                            <th>TOTAL</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl018" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl019" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl020" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl021" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl022" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl023" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl024" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl025" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl026" runat="server" Width="70px" Font-Size="11px">---</asp:Label></td>
                                        </tr>
                                    </table>


                                    <asp:Panel ID="pnl001" runat="server" Visible="False">
                                        <table class="table table-bordered table-condensed">
                                            <tr class="titulo-tabla">
                                                <th>Pago por Intervención</th>
                                                <th>Num. Intervenciones Exigidas</th>
                                                <th>
                                                    <asp:Label ID="lbl027" runat="server" Font-Size="11px"></asp:Label></th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table table-bordered table-condensed table-hover">
                                                        <tr>
                                                            <td colspan="4">Numero de niño(as) y adolecentes con más, menos o igual intervenciones que las exigidas.</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>FEM</td>
                                                            <td>MAS</td>
                                                            <td>TOTAL</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Más</td>
                                                            <td>
                                                                <asp:Label ID="lbl028" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl029" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl030" runat="server" Font-Size="11px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Menos</td>
                                                            <td>
                                                                <asp:Label ID="lbl031" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl032" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl033" runat="server" Font-Size="11px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Igual</td>
                                                            <td>
                                                                <asp:Label ID="lbl034" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl035" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl036" runat="server" Font-Size="11px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table class="table table-bordered table-condensed table-hover">
                                                        <tr>
                                                            <td colspan="4">Total intervenciones registradas.</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>FEM</td>
                                                            <td>MASC</td>
                                                            <td><strong>TOTAL</strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total</td>
                                                            <td>
                                                                <asp:Label ID="lbl037" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl038" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl039" runat="server" Font-Size="11px"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Prom.</td>
                                                            <td>
                                                                <asp:Label ID="lbl040" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl041" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl042" runat="server" Font-Size="11px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table class="table table-bordered table-condensed table-hover">
                                                        <tr>
                                                            <td colspan="4">Total días a pagar según intervenciones.</td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>FEM</td>
                                                            <td>MASC</td>
                                                            <td><strong>TOTAL</strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total</td>
                                                            <td>
                                                                <asp:Label ID="lbl043" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl044" runat="server" Font-Size="11px"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl045" runat="server" Font-Size="11px"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <%-- pnl001 --%>
                                    </asp:Panel>


                                    <asp:Panel ID="pnl002" runat="server" Visible="False">
                                        <table class="table table-bordered table-condensed table-hover">
                                            <tr class="titulo-tabla">
                                                <th colspan="3">Pago por Diagnóstico</th>
                                            </tr>
                                            <tr>
                                                <td>Femenino</td>
                                                <td>Masculino</td>
                                                <td>Total Prestaciones</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl046" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl047" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl048" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <%-- pnl002 --%>
                                    </asp:Panel>

                                    <asp:Panel ID="pnl003" runat="server" Visible="False">
                                        <table class="table table-bordered table-condensed table-hover">
                                            <tr class="titulo-tabla">
                                                <th colspan="3">Pago por Monto Mensual</th>
                                            </tr>
                                            <tr>
                                                <td>Femenino</td>
                                                <td>Masculino</td>
                                                <td>Total Prestaciones </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl049" runat="server"></asp:Label>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="lbl050" runat="server"></asp:Label>&nbsp;</td>
                                                <td>
                                                    <asp:Label ID="lbl051" runat="server"></asp:Label>&nbsp;</td>
                                            </tr>
                                        </table>
                                        <%-- pnl003 --%>
                                    </asp:Panel>

                                    <asp:Panel ID="pnl004" runat="server" Visible="False">
                                        <table class="table table-bordered table-condensed table-hover">
                                            <tr class="titulo-tabla">
                                                <th colspan="4">Pago por Monto Mensual (Discapacidad)</th>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>Femenino</td>
                                                <td>Masculino</td>
                                                <td>Total Prestaciones</td>
                                            </tr>
                                            <tr>
                                                <td>Discapacidad Grave</td>
                                                <td>
                                                    <asp:Label ID="lbl052" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl053" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl054" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Discapacidad Otros</td>
                                                <td>
                                                    <asp:Label ID="lbl055" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl056" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl057" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <%-- pnl004 --%>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlPJC" runat="server" Visible="False">
                                        <table class="table table-bordered table-condensed table-hover">
                                            <tr class="titulo-tabla">
                                                <th colspan="7">Pago por Monto Mensual y Niños/as Atendidos/as</th>
                                            </tr>
                                            <tr>
                                                <td>ASD</td>
                                                <td>ASN</td>
                                                <td>ASF</td>
                                                <td>APS</td>
                                                <td>ALA</td>
                                                <td>ARD</td>
                                                <td>Total Prestaciones</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblASD" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblASN" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblASF" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblAPS" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblALA" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblARD" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblTotalPJC1" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblASD_Total" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblASN_Total" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblASF_Total" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblAPS_Total" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblALA_Total" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblARD_Total" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblTotaPJC2" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <%-- pnlPJC --%>
                                    </asp:Panel>

                                    <asp:Panel ID="pnl80Bis" runat="server" Visible="False">
                                        <table class="table table-bordered table-condensed table-hover">
                                            <tr class="titulo-tabla">
                                                <th colspan="4">80 BIS</th>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>Femenino</td>
                                                <td>Masculino</td>
                                                <td>Total Prestaciones</td>
                                            </tr>
                                            <tr>
                                                <td>80 BIS</td>
                                                <td>
                                                    <asp:Label ID="lbl80BisFemenino" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl80BisMasculino" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblTotal80Bis" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Otros</td>
                                                <td>
                                                    <asp:Label ID="lbl80BisFemeninoOtros" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl80BisMasculinoOtros" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblTotal80BisOtros" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <%-- pnl80Bis --%>
                                    </asp:Panel>
                                    <%-- pnlBody --%>
                                </asp:Panel>

                                <asp:Panel ID="pnlMessageBox" runat="server" Visible="False" Width="100%">
                                    <div class="col-md-3">
                                        &nbsp;
                                    </div>
                                    <div class="col-md-6 caja-tabla">
                                        <table class="table table-bordered table-condensed">
                                            <tr class="titulo-tabla">
                                                <th colspan="2" class="text-center">
                                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="White" Text="Label"></asp:Label></th>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="text-center">
                                                    <asp:Button CssClass="btn btn-primary btn-lg" ID="btnSi" runat="server" OnCommand="btn_MessageBox" Text="Si" Visible="False" CommandArgument="6" CommandName="6" />
                                                    <asp:Button CssClass="btn btn-primary btn-lg" ID="btnNo" runat="server" OnCommand="btn_MessageBox" Text="No" Visible="False" CommandArgument="7" CommandName="7" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="text-center">
                                                    <asp:Label ID="lblFirma" runat="server" ForeColor="Red" Text="Debe seleccionar Quien Firma el Documento" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Seleccione quien firma el Documento</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFirma" runat="server" Font-Names="Arial" Font-Size="11px" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-md-3">
                                        &nbsp;
                                    </div>
                                    <%-- pnlMessageBox --%>
                                </asp:Panel>

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
         <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
               <div  id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif"/>
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
