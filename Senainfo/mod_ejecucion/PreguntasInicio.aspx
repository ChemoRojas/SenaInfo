<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreguntasInicio.aspx.cs" Inherits="mod_ejecucion_PreguntasInicio" %>

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
                        
         <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>Faltan datos obligatorios para realizar el registro.
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>


                   
                        
                        <div class="well">

                            <h4 class="subtitulo-form">Información del NNA</h4>
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
                                    
                                        <h4 class="subtitulo-form">Preguntas Inicio Modulo  <label id="NombreM" runat="server" /></h4>
                                    
                                                                             
                                        <asp:GridView ID="grdPlanificarModulo" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table table-bordered table-hover"
                                            ShowHeaderWhenEmpty="true" EmptyDataText="El NNA consultado no posee intervenciones vigentes.">
                                            
                                            <HeaderStyle CssClass="titulo-tabla" />

                                            <Columns>

                                                <asp:BoundField DataField="TextoPregunta" HeaderText="Pregunta" ItemStyle-Width="600" runat="server" />


                                                

                                               <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="Row1" runat="server" GroupName="SelectGroup" value="1" />Si 
                                                    <asp:RadioButton ID="Row2" runat="server" GroupName="SelectGroup" value="2" />No
                                                    <asp:RadioButton ID="Row3" runat="server" GroupName="SelectGroup" value="3" />Tal Vez
                                                    <asp:TextBox ID="txt2" runat="server" Text='<%# Bind("CodPreguntaModulo") %>' Visible="false"></asp:TextBox>
                                                </ItemTemplate>
                                              </asp:TemplateField>


                                                
                                                                              
                                                
                                            </Columns>
                                        </asp:GridView>
                                     
                                    
                                       <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnGuardar_Click">
                                        <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Guardar
                                    </asp:LinkButton>   
                                     <asp:LinkButton ID="btnBoton" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnGuardar_Click">
                                        <span class="glyphicon glyphicon-chevron-left"></span>&nbsp;Volver
                                    </asp:LinkButton> 

                                    <asp:TextBox ID="txtCodNino" runat="server"  CssClass="form-control input-sm" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TxtCodCalendario" runat="server"  CssClass="form-control input-sm" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TxtCodModulo" runat="server"  CssClass="form-control input-sm" Visible="false"></asp:TextBox>
   
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