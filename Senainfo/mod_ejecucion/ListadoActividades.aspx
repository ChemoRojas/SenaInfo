<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoActividades.aspx.cs" Inherits="mod_ejecucion_ListadoActividades" %>
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
                            <li class="active">Niños/as</li>
                            <li class="active">Detalle de NNA</li>
                        </ol>
                        
                        <div class="well">

                            <h4 class="subtitulo-form">Evaluar Actividades</h4>
                            <hr>
                                <div class="row">
                                    <div class="col-md-12">
                                        <table class="table table-borderless table-condensed">
                                            <tr>
                                                <th class="col-md-4">
                                                    <label for="">Nombre Modulo:</label>
                                                </th>
                                                <td>
                                                    <label id="lblNombreModulo" runat="server" />
                                                </td>


                                               
                                            </tr>

                                             <tr>
                                                <th class="col-md-4">
                                                    <label for="">Nombre Objetivo:</label>
                                                </th>
                                                <td>
                                                    <label id="lblNombreObjetivo" runat="server" />
                                                </td>


                                               
                                            </tr>
                                           
                                               
                                            
                                           
                                        </table>
                                        <!--gfontbrevis modal institucion -->
                                    </div><!--cierra col-md-9-->  
                                </div>
                        </div>

                        <div class="well">

                            <div class="row">
                                <div class="col-md-12">
                                    
                                        <h4 class="subtitulo-form">Evaluar actividades</h4>
                                    
                                        <asp:GridView ID="grdPlanificarModulo" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table table-bordered table-hover"
                                            ShowHeaderWhenEmpty="true" EmptyDataText="El NNA consultado no posee intervenciones vigentes.">
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <Columns>
                                                <asp:BoundField DataField="Nombres" HeaderText="Nombre NNA" />
                                                <asp:BoundField DataField="FechaInicioModulo" HeaderText="Fecha Inicio" />
                                                <asp:BoundField DataField="FechaFinModulo" HeaderText="Fecha Fin" />
                                                <asp:hyperlinkfield text="Evaluar Actividades" datanavigateurlfields="CodModulo,CodNino,CodCalendario" datanavigateurlformatstring="EvaluearActividades.aspx?CodModulo={0}&CodNino={1}&CodCalendario={2}" HeaderText="Acción" ItemStyle-HorizontalAlign="Center" />
                                                
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