<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/mod_ninos/cierre_movmensual.aspx.cs" Inherits="mod_institucion_reg_cierremovmensual" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<!DOCTYPE html>
<html lang="es">
<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Cierre Movimiento Mensual :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <%--<script src="../js/ventanas-modales.js"></script>--%>

    <%--<script src="../js/jquery-ui.js"></script>--%>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/ventanas-modales.css" rel="stylesheet" />
    <!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>

    <script type="text/javascript">

        
    </script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="LinkButton1"
                    PopupControlID="modal_buscar"
                    CancelControlID="bt_cerrar_buscar"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>
                <ajax:ModalPopupExtender ID="mpe5" BehaviorID="mpe5a" runat="server"
                    TargetControlID="imb_lupainstitucion"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal5" >                    
                </ajax:ModalPopupExtender>

                <input type="hidden" id="Buscando" value="0">
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
                <div>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Cierre Movimiento Mensual</li>
                        </ol>
                        <div class="text-center  alert alert-warning" role="alert" id="alert_lb_1y8" runat="server" visible="false">
                                      <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                                      <asp:Label ID="lbl001" runat="server" Text="Este mes fue cerrado, sólo Administrador podrá realizar cambios." Visible="False"></asp:Label>

                                      <asp:Label ID="lbl008" runat="server" Text="Debe Ingresar un Período" Visible="False"></asp:Label>
                                  </div>
                        <div class="text-center  alert alert-warning" role="alert" id="alertfuturo" runat="server" visible="false">
                                      <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                                      <asp:Label  runat="server" Text="Seleccione el período actual o uno pasado" ></asp:Label>

                                  </div>
                        <div class="well">

                            <h4 class="subtitulo-form">Cierre Movimento Mensual</h4>
                            <hr>
                            
                                                         
                            
                                
                                <a id="collapse" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                                  <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Ocultar Detalles de la Búsqueda"></asp:label>
                                    <span id="icon-collapse" class="glyphicon glyphicon-triangle-top" ></span>
                                    <asp:label ID="lbl_resumen_filtro" runat="server" Visible ="false" Text=""></asp:label>
                                    <asp:label ID="lbl_resumen_proyecto" runat="server" Visible ="false"></asp:label>
                                </a>
                                
                                
                                <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                    <div class="row">
                                  <div class="col-md-9">
                                      <form action="">
                                          <table class="table table-borderless table-condensed table-col-fix">
                                              <tr>
                                                  <th class="col-md-3">
                                                      <label for="">Institución:</label>
                                                  </th>
                                                  <td>
                                                      <div class="input-group">
                                                        <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged"  CssClass="form-control input-sm">
                                                      </asp:DropDownList>
                                                      <asp:LinkButton ID="imb_lupainstitucion" runat="server" CssClass="input-group-addon btn btn-primary btn-sm " OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion', '../mod_ninos/cierre_movmensual.aspx','mpe5a')" CausesValidation="False">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                                
                                            </div>
                                                      
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">Proyecto:</label>
                                                  </th>
                                                  <td>
                                                      <div class="input-group">
                                                          <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged"  CssClass="form-control input-sm">
                                                          </asp:DropDownList>
                                                          <asp:LinkButton ID="LinkButton1" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_ninos/cierre_movmensual.aspx','mpe1a')" CausesValidation="False">
                                                              <span class="glyphicon glyphicon-question-sign"></span>
                                                          </asp:LinkButton>
                                                      </div>
                                                      <div class="popupConfirmation" id="modal_buscar" style="display: none">
                                                          <div class="modal-header header-modal">
                                                              <asp:LinkButton CssClass="close" ID="bt_cerrar_buscar" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false" >
                                                                  <span aria-hidden="true">&times;</span>
                                                              </asp:LinkButton>
                                                              <h4 class="modal-title">PROYECTO</h4>
                                                          </div>
                                                          <div>
                                                              <%--<iframe id="iframe_buscar" src="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/cierre_movmensual.aspx" width="800px" height="600px" runat="server" frameborder="0"></iframe>--%>
                                                               <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                                          </div>
                                                      </div>
                                                  </td>
                                                  <%--<td>
                                              <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                                          <div class="modal-header header-modal">
                                                              <asp:LinkButton ID="LinkButton4" CssClass="close"  aria-label="Close"  runat="server" Text="Cerrar" CausesValidation="false">
                                                                  <span aria-hidden="true">&times;</span>
                                                              </asp:LinkButton>
                                                              <h4 class="modal-title">Senainfo/ Institucion</h4>
                                                          </div>
                                                          <div>
                                                              <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                          </div>
                                                      </div>
                                          </td>--%>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">Período:</label>
                                                  </th>
                                                  <td>
                                                      <div class="col-md-6 no-padding" ><asp:DropDownList ID="ddown_MesCierre" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddown_MesCierre_SelectedIndexChanged" CssClass="form-control input-sm">
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
                                                                  </asp:DropDownList></div>
                                                      <div class="col-md-6 no-padding" ><asp:DropDownList ID="ddown_AnoCierre" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddown_MesCierre_SelectedIndexChanged" CssClass="form-control input-sm">
                                                                  </asp:DropDownList></div>
                                                      
                                                  </td>
                                              </tr>
                                              
                                          </table>
                                          <!--gfontbrevis modal institucion -->
                                <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton ID="btnCerrarModal5" CssClass="close" aria-label="Close" OnClientClick="LimpiarModalInstitucion()" runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                        <h4 class="modal-title">INSTITUCION</h4>
                                    </div>
                                    <div>
                                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                    </div>
                                </div>
                                      </form>
                                </div><!--cierra col-md-9-->  
                                <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Seleccione institución, proyecto y período para consultar." ></asp:Label><br />
                                        <asp:Label ID="Lbl_Info2" CssClass="subtitulo-form-info" runat="server" Text="" ></asp:Label>                                      
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                                        </div>
                                </div><!-- cierra collapse-->
                                
                            <div class="row">
                                <table class="table table-borderless table-condensed table-col-fix">
                                <tr>
                                    <td class="col-md-3">
                                        
                                    </td>
                                    <td>
                                
                                    <asp:LinkButton ID="Imb002" runat="server"  OnClick="Imb002_Click" CssClass="btn btn-info btn-sm">
                                        <span class="glyphicon glyphicon-file"></span>&nbsp;Informe atención Mensual
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="Imb003" runat="server"  OnClick="Imb003_Click" CssClass="btn btn-danger btn-sm ">
                                        <span class="glyphicon glyphicon-pencil"></span>&nbsp;Registro atención Mensual
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="WebImageButton1" runat="server"  OnClick="WebImageButton1_Click" CssClass="btn btn-info btn-sm ">
                                        <span class="glyphicon glyphicon-list-alt"></span>&nbsp;Resumen atencion Mensual
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="imb005" runat="server"  OnClick="ImageButton1_Click" CssClass="btn btn-info btn-sm " Visible="False">
                                        <span class="glyphicon glyphicon-refresh"></span>&nbsp;Regenerar
                                    </asp:LinkButton>
                                    <%--<asp:Button ID="WebImageButton2" runat="server" OnClick="imb_volver_Click" Text="Volver" CssClass="btn btn-primary btn-sm" Visible="False" />--%>
                                </td></tr></table>
                            
                                </div><!-- cierra row-->
                            <br>
                            <div class="row">
                                <div class="col-md-6">
                                    
                                        <asp:Panel ID="lbl002panel" runat="server" Visible="false" CssClass="text-center">
                                            <h4><label class="subtitulo-form">Nómina Ingresos: 
                                            <asp:Label ID="lbl002" runat="server">0</asp:Label></label></h4>
                                        </asp:Panel>
                                    
                                                    <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="table table table-bordered table-hover">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                                                            <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                                            <asp:BoundField DataField="rut" HeaderText="Run" />
                                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha Ingreso" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                
                                </div>
                                <div class="col-md-6">
                                    
                                        <asp:Panel ID="lbl003panel" runat="server" Visible="false" CssClass="text-center">
                                            <h4><label class="subtitulo-form">Nómina Egresos: 
                                            <asp:Label ID="lbl003" runat="server">0</asp:Label></label></h4>
                                        </asp:Panel>
                                        
                                                    <asp:GridView ID="grd002" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="table table-bordered table-hover">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                                                            <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                                            <asp:BoundField DataField="rut" HeaderText="Run" />
                                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha Egreso" />
                                                        </Columns>
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                
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
               <div  id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif"/>
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
