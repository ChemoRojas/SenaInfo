<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_Notificacion.ascx.cs" Inherits="SenainfoSdk.UI.C_Notificacion" %>
<%--<link href="css/bootstrap-modal-bs3patch.css" rel="stylesheet" />--%>
<script type="text/javascript">

    $(document).ready(function () {
        //generateDataTable($("#GridAlertas"), function(){);
        var countEPT = $("#<%=GridAlertasEgresosxTraslado.ClientID%> > tbody > tr").length;
        var countLEA = $("#<%=GridAlertasListaEsperaxAbuso.ClientID%> > tbody > tr").length;
        var countEPC = $("#<%=GridAlertasEgresosPendientesxCausal.ClientID%> > tbody > tr").length;
        var total = countEPT + countLEA + countEPC;

        $('.badge .badge-notify').val(total);
        //$('.badge .badge-info .EPT').val(countEPT);
        //$('.badge .badge-info .LEA').val(countLEA);
        //$('.badge .badge-info .EPC').val(countEPC);
     
        $("li a").on("click", function () {
             if (this.id == "lknEPC" && countEPC > 0) {
                 $('#modal1').modal('show');
            }
            else if (this.id == "lknLEA" && countLEA > 0) {
                $('#modal2').modal('show');
            }
            else if  (this.id == "lknEPT" && countEPT > 0) {
                $('#modal3').modal('show');
            }
        });


        $('.modal').on('show.bs.modal', function () {
            $(this).find('.modal-dialog').css({
                width: '90%',
            });
            $(this).find('.modal-body').css({
                width: 'auto', //probably not needed
                height: 'auto', //probably not needed 
                'max-height': '100%'
            });
            $(this).find('.panel-body').css({ 'overflow-x': 'auto', 'max-height': '400px', 'overflow-y': 'scroll' }); //overlay
        });

    });
</script>
<style>
    /* CSS used here will be applied after bootstrap.css */
    .badge-notify{
       background:orange;
       position:relative;
       top: -15px;
       left: -10px;
      }
    .badge-info {
       background-color:#0f69b4;
    }
   
</style>
<!-- MENU Notificaciones -->
<li class="dropdown"> 

    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
        <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>    
        <span class="badge badge-notify">3</span>
        Notificaciones de Alertas 
        <span class="glyphicon glyphicon-triangle-bottom" aria-hidden="true"></span>
    </a>
    <ul class="dropdown-menu" role="menu">
        <li id="Li1" runat="server" visible="true">
            <a id="lknEPC" href="#">
                <asp:Label runat="server" CssClass="badge badge-info" ID="LA1"></asp:Label>
                Alertas Egresos Pendientes por Causal</a>
            <a id="lknLEA" href="#">
                <asp:Label runat="server" CssClass="badge badge-info" ID="LA2"></asp:Label>
                Alertas Lista de Espera por Abuso</a>
            <a id="lknEPT" href="#">
                <asp:Label runat="server" CssClass="badge badge-info" ID="LA3"></asp:Label>
                Alertas Egresos por Traslado</a>
        </li>
    </ul>
</li>

<!-- Modal 1 -->
<div class="modal fade" id="modal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            </div>
            <div class="modal-body">

                <%--<div id="Alertas" class="container theme-showcase" role="main" runat="server" visible="true">--%>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-bienvenida" id="divAlertas">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-bullhorn" aria-hidden="true"></span>
                                    <%-- <a role="button" id="collapse" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Alertas Activas 
                                    </a>--%>
                                    <span>Alertas Activas - Egresos Pendientes por Causal</span>
                                    <%--<span class="badge">
                                        <asp:Label runat="server" ID="NumeroAlertas"></asp:Label>
                                    </span>--%>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <asp:Label runat="server" CssClass="badge" ID="numAlertasEgresosPendientesxCausal"></asp:Label>
                                <a role="button" id="A1" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#Div1" aria-expanded="true" aria-controls="Div1">Alertas Egresos Pendientes por Causal 
                                </a>
                                <div id="Div1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="AlertaOne">
                                    <%--<div class="panel-body">--%>
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
                                   <%-- </div>--%>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>

                <%--</div>--%>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->

<!-- Modal 2 -->
<div class="modal fade" id="modal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            </div>
            <div class="modal-body">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-bienvenida" id="div5">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-bullhorn" aria-hidden="true"></span>
                                    <%-- <a role="button" id="collapse" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Alertas Activas 
                                    </a>--%>
                                    <span>Alertas Activas - ListaEspera por Abuso</span>
                                    <%--<span class="badge">
                                        <asp:Label runat="server" ID="NumeroAlertas"></asp:Label>
                                    </span>--%>
                                </h3>
                            </div>
                            <div class="panel-body">

                                <asp:Label runat="server" ID="numAlertaListaEspera" CssClass="badge"></asp:Label>
                                <a role="button" id="A2" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#Div2" aria-expanded="true" aria-controls="Div2">Alertas Lista de Espera por Abuso 
                                </a>
                                <div id="Div2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="AlertaTwo">
                                    <%--<div class="panel-body">--%>
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
                                    <%--</div>--%>
                                </div>
                                <br />

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>
<!-- / Modal 2 -->

<!-- Modal 3-->
<div class="modal fade" id="modal3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            </div>
            <div class="modal-body">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-bienvenida" id="div7">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <span class="glyphicon glyphicon-bullhorn" aria-hidden="true"></span>
                                    <%-- <a role="button" id="collapse" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Alertas Activas 
                                    </a>--%>
                                    <span>Alertas Activas - Egresos por Traslado</span>
                                    <%--<span class="badge">
                                        <asp:Label runat="server" ID="NumeroAlertas"></asp:Label>
                                    </span>--%>
                                </h3>
                            </div>
                            <div class="panel-body">

                                <asp:Label runat="server" ID="numAlertaEgresosxTraslado" CssClass="badge"></asp:Label>
                                <a role="button" id="A3" class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#Div3" aria-expanded="true" aria-controls="Div3">Alertas Egresos por Traslado
                                </a>
                                <div id="Div3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="AlertaThree">
                                    <%--<div class="panel-body">--%>
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
                                   <%-- </div>--%>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>
<!-- Modal 3-->
