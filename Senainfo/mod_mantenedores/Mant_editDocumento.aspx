<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_editDocumento.aspx.cs" Inherits="mod_biblioteca_editDocumento" %>
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

    <title>Editar Documento en Biblioteca :: Senainfo :: Servicio Nacional de Menores</title>

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
<body role="document">
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">

        <uc1:menu_colgante_buscador runat="server" ID="menu_colgante_buscador" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <input type="hidden" id="Buscando" value="0">
        <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />

        <div class="container theme-showcase" role="main">
            <ol class="breadcrumb">
                <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                <li class="active">Mantenedores</li>
                <li class="active">Biblioteca de Documentos</li>
            </ol>
                        
            <div class="well">

                <h4 class="subtitulo-form">Editar Documento en Biblioteca</h4>
                <hr>

                <div class="row">
                    <div class="col-md-9">
                        <table class="table table-borderless table-condensed table-col-fix">
                            <tr>
                                <th class="col-md-3">
                                    <label for="">Archivo:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:FileUpload ID="archivo1" runat="server" ToolTip="Archivo a cargar. Tipos soportados: PDF, Word, Excel" />
                                        <asp:HiddenField ID="txtId" runat="server" />
                                    </div>                                                      
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label for="">Nombre:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtNombre" runat="server" ToolTip="Nombre del archivo a cargar" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label for="">Descripción:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtDescripcion" runat="server" ToolTip="Descripción del archivo a cargar" CssClass="form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <label for="">Vigencia:</label>
                                </th>
                                <td>
                                    <div class="input-group">
                                        <asp:CheckBox ID="chkVigencia" runat="server" ToolTip="Indica si el archivo está aún vigente (y lo mostrará en la grilla de documentos)" CssClass="input-sm" Text="&nbsp;Vigente" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div><!--cierra col-md-9-->  
                    <div class="col-md-3">       
                                                        
                    <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                        <div class="panel-heading">
                            Información
                        </div>
                        <div class="panel-footer">
                            <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Tipos de archivos soportados:" ></asp:Label><br />
                            <asp:Label ID="Lbl_Info2" CssClass="subtitulo-form-info" runat="server" Text="PDF, Word, Excel" ></asp:Label>                                      
                        </div>
                        </asp:Panel>
                                
                                  
                    </div>
                </div>
            </div>
            
            <div class="row">
                <table class="table table-borderless table-condensed table-col-fix">
                <tr>
                    <td class="col-md-3">
                                        
                    </td>
                    <td>
                                
                        <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnGuardar_Click">
                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Guardar
                        </asp:LinkButton>
                        
                    </td>

                </tr>

                </table>
                            
            </div><!-- cierra row-->

            <br>
                         
        </div>
    </form>

    <footer class="footer">
        <div class="container">
            <p>
                Para tus dudas y consultas, escribe a:
                <br>
                mesadeayuda@sename.cl
            </p>
        </div>
    </footer>
</body>
</html>