<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InformeTipo.aspx.cs" Inherits="mod_evaluacion_InformeTipo" %>

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
    <script src="../js/jspdf.js"></script>
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

                    <div class="container theme-showcase" role="main" id="contenido">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Detalle de NNA</li>
                        </ol>


                        <div class="well">
                                
                                           <h4 class="subtitulo-form">Informe de:</h4> 
                                                <asp:DropDownList ID="ddownRango" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Informe 1</asp:ListItem>
                                                    <asp:ListItem Value="1">Informe 2</asp:ListItem>
                                                    <asp:ListItem Value="2">Informe 3</asp:ListItem>
                                                    <asp:ListItem Value="3">Informe 4</asp:ListItem>
                                                </asp:DropDownList>
                        </div>
                        
                        <div class="well">

                            <h4 class="subtitulo-form">Información del NNA</h4>
                            <hr>
                                <div class="row">
                                    <div class="col-md-12">
                                        <table class="table table-borderless table-condensed">
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Nombre:</label>
                                                </th>
                                                <td>
                                                    <label id="lblNombre" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    <label for="">Fecha Nacimiento:</label>
                                                </th>
                                                <td>
                                                    <label id="lblFechaNac" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">RUN del NNA:</label>
                                                </th>
                                                <td>
                                                    <label id="lblRun" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    <label for="">Sexo:</label>
                                                </th>
                                                <td>
                                                    <label id="lblSexo" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Cód. NNA:</label>
                                                </th>
                                                <td>
                                                    <label id="lblCodNino" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    <label for="">Dirección:</label>
                                                </th>
                                                <td>
                                                    <label id="lblDireccion" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Comuna:</label>
                                                </th>
                                                <td>
                                                    <label id="lblComuna" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    
                                                </th>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                        
                                        </table>
                                        <!--gfontbrevis modal institucion -->
                                    </div><!--cierra col-md-9-->  
                                </div>
                        </div>


                               <div class="well">

                            <h4 class="subtitulo-form">Información Sanción</h4>
                            <hr>
                                <div class="row">
                                    <div class="col-md-12">
                                        <table class="table table-borderless table-condensed">
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Ruc:</label>
                                                </th>
                                                <td>
                                                    <label id="LblRuc" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    <label for="">Rit:</label>
                                                </th>
                                                <td>
                                                    <label id="LblRit" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Calidad Juridica:</label>
                                                </th>
                                                <td>
                                                    <label id="LblCalidadJuridica" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    <label for="">Tipo de Atención:</label>
                                                </th>
                                                <td>
                                                    <label id="LblTipoAtencion" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Nombre Centro:</label>
                                                </th>
                                                <td>
                                                    <label id="LblNombreCentro" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    <label for="">Fecha Ingreso:</label>
                                                </th>
                                                <td>
                                                    <label id="LblFechaIngreso" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="col-md-2">
                                                    <label for="">Tribunal de Origen:</label>
                                                </th>
                                                <td>
                                                    <label id="LblTribunalOrigen" runat="server" />
                                                </td>
                                                <th class="col-md-2">
                                                    
                                                </th>
                                                <td>
                                                    
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
                                    
                                        <h4 class="subtitulo-form">Intervención Vigente</h4>
                                    
                                        <asp:GridView ID="grdIntervencion" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table table-bordered table-hover"
                                            ShowHeaderWhenEmpty="true" EmptyDataText="El NNA consultado no posee un Diagnóstico vigentes." >
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <Columns>
                                                <asp:BoundField DataField="NombreObjetivo" HeaderText="Objetivo" />
                                                <asp:BoundField DataField="NombreModulo" HeaderText="Modulo" />
                                                <asp:BoundField DataField="CodCalendario" HeaderText="Código Calendario" />
                                                <asp:BoundField DataField="porcentaje" HeaderText="Cumplimiento Modulo" dataformatstring="{0:0.00}%"/>
                                                <asp:BoundField DataField="porcentaje2" HeaderText="Cumplimiento Objetivo" dataformatstring="{0:0.00}%"/>
                                                                                               
                                                <%--<asp:hyperlinkfield text="Asignar Profesional..." datanavigateurlfields="CalidadJuridica" datanavigateurlformatstring="IngresoPII.aspx?CalidadJuridica={0}" HeaderText="Acción" ItemStyle-HorizontalAlign="Center" />--%>
                                            </Columns>
                                        </asp:GridView>
                                                
                                </div>
                                
                            </div>
                        </div>

                    </div>
                    <div id="editor"></div>
                   
                     <asp:LinkButton ID="transformar" runat="server" CssClass="btn btn-info btn-sm" >
                                        <span class="glyphicon glyphicon-file"></span>&nbsp;Generar PDF
                                    </asp:LinkButton>


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
