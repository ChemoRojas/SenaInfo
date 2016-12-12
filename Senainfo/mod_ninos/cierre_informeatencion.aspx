<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/mod_ninos/cierre_informeatencion.aspx.cs" Inherits="mod_institucion_cierreinformeatencion" EnableEventValidation="true" %>

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

    <title>Informe de Atención Mensual :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />

  <script>
      $(document).ready(function () {          
          fixHeader_('#grd001', '1');
      });

      $(document).ready(function () {
          $('#collapse').click(function () {
              collapseFixHeader('#grd001')
          });
      });

  </script>
</head>

<body>
    <form id="form1" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <input type="hidden" id="Buscando" value="0">
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
                <div>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Informe de Atención Mensual</li>
                        </ol>
                        <!-- Alerts -->
                          <div class=" text-center alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                              
                              <asp:Label ID="lbl002" runat="server" Text="Este mes fue cerrado, sólo Administrador podrá realizar cambios." Visible="False"></asp:Label>
                              <asp:Label ID="lbl003" runat="server" Text="No hay datos para el periodo consultado" Visible="False"></asp:Label>
                              <asp:Label ID="lblDosMeses" runat="server" Text="Niños sin asistencia en los últimos 2 Meses" Visible="False"></asp:Label>
                              <asp:Label ID="lblTresMeses" runat="server" Text="Niños sin asistencia en los últimos 3 Meses" Visible="False"></asp:Label>
                              <asp:Label ID="lblPRI" runat="server" Visible="False"></asp:Label>
                              <asp:Label ID="lblPri12" runat="server" Visible="False"></asp:Label>
                          </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Informe de Atención Mensual</h4>
                            <hr>
                          
                          <a id="collapse" data-toggle="collapse" class="collapsed" data-parent="#accordion"  href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                                  <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Mostrar Detalles de la Búsqueda"></asp:label>
                                    <span id="icon-collapse" class="glyphicon glyphicon-triangle-bottom" ></span>
                          <asp:label ID="lbl_resumen_filtro" runat="server" Visible ="false" Text=""></asp:label>
                              <asp:label ID="lbl_resumen_proyecto" runat="server" Visible ="false"></asp:label>
                          </a>
                          
                          
                          
                          

                          <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                          <!-- Form Busqueda -->
                            <div class="row">
                                <div class="col-md-9">
                                    <form action="">
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
                                                    <asp:DropDownList ID="ddown002" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label for="">Período</label>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddown_MesCierre" runat="server" OnSelectedIndexChanged="ddown_MesCierre_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control input-sm">
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
                                                                <asp:DropDownList ID="ddown_AnoCierre" runat="server" OnSelectedIndexChanged="ddown_MesCierre_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control input-sm pull-right">
                                                                </asp:DropDownList>
                                                            </td>
                                                             <td class="col-md-3 text-center">
                                                    <label for="">Sexo</label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdo_SexoA" runat="server"  GroupName="rdosexo" Text="Ambos" Checked="True" AutoPostBack="True" OnCheckedChanged="rdo_SexoA_CheckedChanged" />&nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="rdo_SexoM" runat="server"  GroupName="rdosexo" Text="Masculino" AutoPostBack="True" OnCheckedChanged="rdo_SexoA_CheckedChanged" />&nbsp;&nbsp;&nbsp;
                                                    <asp:RadioButton ID="rdo_SexoF" runat="server"  GroupName="rdosexo" Text="Femenino" AutoPostBack="True" OnCheckedChanged="rdo_SexoA_CheckedChanged" />
                                                </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                          
                                            
                                        </table>
                                    </form>
                                </div>
                                <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Días de Atención: " ></asp:Label>       
                                        <asp:Label ID="lbl001" CssClass="subtitulo-form-info" runat="server" ></asp:Label>
                                        
                                                                              
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                            </div>
                          </div>
                            <!--fin Row -->
                          
                          <!-- Botones -->
                            <div class="row">
                                <div class="col-md-9">
                                <table class="table table-borderless table-condensed">
                                            <tr>
                                                <td class="col-md-3">
                                                    
                                                </td>
                                                <td>
                                <asp:LinkButton ID="lbtn_ExportarExcel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="lbtn_ExportarExcel_Click">
                                    <span class="glyphicon glyphicon-save-file" aria-hidden="true"></span> Exportar a Excel</asp:LinkButton>
                                <%--<asp:Button CssClass="btn btn-info btn-sm" ID="WebImageButton1" runat="server" Text="Exportar a Excel" OnClick="WebImageButton1_Click" Visible="False"  />--%>
                                <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button pull-right" ID="Imb001" runat="server"  OnClick="Imb001_Click">
                                    <span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span> Atrás

                                </asp:LinkButton>
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="WebImageButton2" runat="server" OnClick="imb_volver_Click" Text="Volver" Visible="false" />
                             </td></tr></table>
                                                    
                                                    </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <br/>
                                        <caption>
                                            <asp:Label ID="lblEventosProyecto" runat="server" CssClass="texto_form" Text="Cantidad de Eventos del Proyecto:  " Visible="False" Width="373px"></asp:Label>
                                        </caption>
                                    <div id="tableHeader" class="fixed-header"></div>
                                        <div id="tableContainer" class="fixed-header-table-container">
                                        
                                                    <asp:GridView ID="grd001" runat="server" ViewStateMode="Disabled" AutoGenerateColumns="False"  CellPadding="4" GridLines="None" Visible="False" EnableTheming="True" CssClass="table table-bordered table-hover">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="icodie" HeaderText="Cod. Ingreso-Egreso"  />
                                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                                                            <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                                            <asp:BoundField DataField="diasatencion" HeaderText="Dias Atención" />
                                                            <asp:BoundField DataField="diasausentes" HeaderText="Dias Ausentes" />
                                                            <asp:BoundField DataField="numerointervencionesotras" HeaderText="Número Intervenciones Otras" />
                                                            <asp:BoundField DataField="numerointervenciones" HeaderText="Numero Intervenciones Directas" />
                                                            <asp:BoundField DataField="diasintervencion" HeaderText="Total días a pagar por intervención" />
                                                            <asp:BoundField DataField="DiasAtendido" HeaderText="Total días a pagar por atención" />
                                                        </Columns>
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                </div>
                                </div>
                            </div>
                        </>
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

            <Triggers>
                <asp:PostBackTrigger ControlID="lbtn_ExportarExcel" />
            </Triggers>

        </asp:UpdatePanel>
    </form>
</body>
</html>
