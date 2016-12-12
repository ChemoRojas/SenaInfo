<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Planificacion_Modulo.aspx.cs" Inherits="mod_ejecucion_Planificacion_Modulo" %>
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

    <title>Detalle de NNA :: Senainfo :: Servicio Nacional de Menores</title>

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
                            <li class="active">Modulo</li>
                            <li class="active">Actividades</li>
                        </ol>

                         <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>Faltan datos obligatorios para realizar el registro.
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>


                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>Datos de la Planificación registrados satisfactoriamente.
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos del Área registrados satisfactoriamente." Visible="false">Datos del Área registrados satisfactoriamente.</asp:Label>
                    </div>


                        <div class="well">
                            <div class="row">
                                <div class="col-md-12">

                                    <h4>Registrar Actividades a Realizar</h4>

                                    <asp:DropDownList ID="ddownCalendario" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="true">
                                          <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:TextBox ID="TxtCodNino" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TxtRuc" runat="server" Visible="false"></asp:TextBox>
                         
                                    
                                        <h4 class="subtitulo-form"><asp:Label ID="LblTitulo" runat="server"></asp:Label></h4>
                                    
                                        <asp:GridView ID="grdPlanificarModulo" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table table-bordered table-hover"
                                            ShowHeaderWhenEmpty="true" EmptyDataText="El NNA consultado no posee intervenciones vigentes.">
                                            
                                            <HeaderStyle CssClass="titulo-tabla" />

                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRow" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>  
                                            <asp:BoundField DataField="CodActividad" HeaderText="Código Actividad"  />

                                                <asp:BoundField DataField="NombreActividad" HeaderText="Actividad" ItemStyle-Width="600" />
                                                                              
                                                
                                            </Columns>
                                        </asp:GridView>

                                    <br />
                                <asp:Button ID="btnGetSelected" class="btn-primary" runat="server" Text="Guardar" OnClick="GetSelectedRecords" />
                                    
                                    
                                              
                                </div>
                                
                            </div>
                        </div>


                         <div class="well">

                            <div class="row">
                                <div class="col-md-12">
                                    

                                    <h4>Registrar Actividades a Realizar</h4>

                                       <asp:GridView ID="grdListado" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table table-bordered table-hover"
                                            ShowHeaderWhenEmpty="true" EmptyDataText="El NNA consultado no posee intervenciones vigentes.">
                                            
                                            <HeaderStyle CssClass="titulo-tabla" />

                                            <Columns>
                                                 <asp:BoundField DataField="CodCalendario" HeaderText="Código Calendario"  />
                                                 <asp:BoundField DataField="CodActividad" HeaderText="Código Actividad"  />
                                                 <asp:BoundField DataField="NombreActividad" HeaderText="Actividad" ItemStyle-Width="600" />
                                                                              
                                                
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
