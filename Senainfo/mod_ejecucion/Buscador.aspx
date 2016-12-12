<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Buscador.aspx.cs" Inherits="mod_ejecucion_Buscador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante_buscador.ascx" TagPrefix="uc1" TagName="menu_colgante_buscador" %>


<!DOCTYPE html>
<html lang="es">
<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Buscador de NNA :: Senainfo :: Servicio Nacional de Menores</title>

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

        <uc1:menu_colgante_buscador runat="server" ID="menu_colgante_buscador" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
                <input type="hidden" id="Buscando" value="0">
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
                <div>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Búsqueda de NNA</li>
                        </ol>
                        
                        <div class="well">

                            <h4 class="subtitulo-form">Búsqueda de NNA</h4>
                            <hr>
                            
                                
                                    <div class="row">
                                  <div class="col-md-9">
                                          <table class="table table-borderless table-condensed table-col-fix">
                                              <tr>
                                                  <th class="col-md-3">
                                                      <label for="">RUN:</label>
                                                  </th>
                                                  <td>
                                                      <div class="input-group">
                                                          <asp:TextBox ID="txtRun" runat="server" ToolTip="RUT del NNA" CssClass="form-control input-sm"></asp:TextBox>
                                                          <ajax:FilteredTextBoxExtender ID="Validador1" runat="server" TargetControlID="txtRun" ValidChars="Kk0123456789-" />
                                                      </div>
                                                      
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">RUC:</label>
                                                  </th>
                                                  <td>
                                                      <div class="input-group">
                                                          <asp:TextBox ID="txtRuc" runat="server" ToolTip="Núm. RUC de causa" CssClass="form-control input-sm"></asp:TextBox>
                                                      </div>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">Cód. Niño:</label>
                                                  </th>
                                                  <td>
                                                      <div class="input-group">
                                                          <asp:TextBox ID="txtCodNino" runat="server" ToolTip="Cód. del NNA en SenaInfo" CssClass="form-control input-sm"></asp:TextBox>
                                                      </div>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">Nombre NNA:</label>
                                                  </th>
                                                  <td>
                                                      <asp:TextBox ID="txtNombre" runat="server" ToolTip="Nombre" CssClass="form-control input-sm"></asp:TextBox>                  
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">Apellido Paterno NNA:</label>
                                                  </th>
                                                  <td>
                                                      <asp:TextBox ID="txtApellPaterno" runat="server" ToolTip="Apellido Paterno" CssClass="form-control input-sm"></asp:TextBox>                
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <th>
                                                      <label for="">Apellido Materno NNA:</label>
                                                  </th>
                                                  <td>
                                                      <asp:TextBox ID="txtApellMaterno" runat="server" ToolTip="Apellido Materno" CssClass="form-control input-sm"></asp:TextBox>              
                                                  </td>
                                              </tr>
                                          </table>
                                          <!--gfontbrevis modal institucion -->
                                </div><!--cierra col-md-9-->  
                                <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Ingrese al menos uno de los campos a buscar" ></asp:Label><br />
                                        <asp:Label ID="Lbl_Info2" CssClass="subtitulo-form-info" runat="server" Text="" ></asp:Label>                                      
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                                        </div>
                                
                            <div class="row">
                                <table class="table table-borderless table-condensed table-col-fix">
                                <tr>
                                    <td class="col-md-3">
                                        
                                    </td>
                                    <td>
                                
                                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnBuscar_Click">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiar" runat="server" CssClass="btn btn-danger btn-sm " OnClick="btnLimpiar_Click">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Borrar
                                    </asp:LinkButton>
                                </td></tr></table>
                            
                                </div><!-- cierra row-->
                            <br>
                            <div class="row">
                                <div class="col-md-9">
                                    
                                        <asp:Panel ID="lbl002panel" runat="server" Visible="false" CssClass="text-center">
                                            <h4><label class="subtitulo-form">Resultados Búsqueda: 
                                            <asp:Label ID="lbl002" runat="server">0</asp:Label></label></h4>
                                        </asp:Panel>
                                    
                                                    <asp:GridView ID="grdBusqueda" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="table table table-bordered table-hover"
                                                        ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron resultados">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                                                            <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                                            <asp:BoundField DataField="rut" HeaderText="RUN" />
                                                            <asp:BoundField DataField="ruc" HeaderText="RUC" />
                                                            <asp:hyperlinkfield text="Planificar Módulo" datanavigateurlfields="CodNino,Ruc" datanavigateurlformatstring="Despliegue_Modulos.aspx?CodNino={0}&amp;Ruc={1}" HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
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

    </form>
</body>
</html>
