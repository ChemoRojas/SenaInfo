<%@ Page Language="C#" AutoEventWireup="true" CodeFile="documentos.aspx.cs" Inherits="mod_biblioteca_documentos" %>
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

    <title>Biblioteca de Documentos :: Senainfo :: Servicio Nacional de Menores</title>

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
    <form id="form1" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <input type="hidden" id="Buscando" value="0">
        <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />

        <div class="container theme-showcase" role="main">
            <ol class="breadcrumb">
                <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                <li class="active">Documentos</li>
                <li class="active">Biblioteca</li>
            </ol>
                        
            <div class="well">

                <h4 class="subtitulo-form">Biblioteca de Documentos</h4>
                <hr>

                <div class="row">
                    <div class="col-md-9">

                        <asp:GridView ID="grdDocumentos" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None"
                            CssClass="table table table-bordered table-hover" ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron resultados">
                            <HeaderStyle CssClass="titulo-tabla" />
                            <Columns>
                                <asp:BoundField DataField="Extension" HeaderText="Tipo" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha creación" DataFormatString="{0:d}" />
                                <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" runat="server" Text='<span class="glyphicon glyphicon-download-alt"></span>' OnClick="lnkDownload_Click"
                                            CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                                                
                    </div>
                                
                </div><!-- cierra row-->
            </div>
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