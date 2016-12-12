<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenedorRelacionRolesTokens.aspx.cs" Inherits="mod_seguridad_MantenedorRelacionRolesTokens" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<html lang="es">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Mantenedor Relación Roles Tokens :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <%--<script src="../js/jquery-ui.js"></script>--%>
    <%--<script src="../js/jquery.multi-select.js"></script>--%>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/multi-select.css" rel="stylesheet" />--%>

    <script type="text/javascript">
        function SetProgressPosition(e) {
            var posx = 0;
            var posy = 0;
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                posx = e.clientX + document.documentElement.scrollLeft;
                posy = e.clientY + document.documentElement.scrollTop;
            }

            document.getElementById('divProgress').style.top = posy + "px";
        }

        //(function ($) {
        //    $(function () {
        //        $('#aloha').multiSelect({
        //            keepOrder: true
        //        });
        //        $('.multiselect').multiSelect({});
        //    });
        //})(jQuery);
    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)" onkeydown="return (event.keyCode!=13)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <Triggers>
                <%--<asp:PostBackTrigger ControlID="lnb_ExportarExcel" />--%>
            </Triggers>
            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Seguridad</li>
                        <li class="active">Mantenedor Relación Roles Tokens</li>
                    </ol>

                    <div class="alert alert-warning" role="alert" id="alerts" runat="server"  style="margin-top:10px;display:none" >
                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lb_mensaje" runat="server" Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Mantenedor Relación Roles Tokens</h4>
                        <hr>

                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Roles:</label>
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddl_roles" runat="server" CssClass="form-control input-sm" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!-- inicio: nueva posicion de botones -->
                                    <tr>
                                        <th></th>
                                        <td>

                                            <asp:LinkButton CssClass="btn btn-success btn-sm fixed-width-button" ID="lnb_actualizar" runat="server" Text="Actualizar" ValidationGroup="grupo1" AutoPostback="false" Visible="false" OnClick="lnb_actualizar_Click" >
                                              <span class="glyphicon glyphicon-log-in"></span>&nbsp;Actualizar
                                            </asp:LinkButton>

                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right fixed-width-button" ID="lnb_buscar" runat="server" Text="Buscar" AutoPostback="true" CausesValidation="false" OnClick="lnb_buscar_Click">
                                              <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                            </asp:LinkButton>

                                            <!-- agrega pull-right para alinear a la derecha boton limpiar -->
                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right fixed-width-button" ID="lbn_Limpiar" runat="server" Text="Limpiar" AutoPostback="true" CausesValidation="false" OnClick="lbn_Limpiar_Click" >
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                        </td>
                                        <!-- fin: nueva posicion de botones -->
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-3">
                                <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lb_informacion" CssClass="subtitulo-form-info" runat="server"></asp:Label><br /><br />  
                                    </div>
                                </div>

                                <%--<table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                </table>--%>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-5">
                            <div class="table-bordered table-hover">
                                <div id="tableHeader" class="fixed-header"></div>
                                <div class="fixed-header-table-container">

                                    <%--<asp:DropDownList id="aloha" name="aloha[]" runat="server" multiple="multiple" AutoPostBack="true"> <!-- CssClass="form-control input-sm" -->
                                    </asp:DropDownList>--%>

                                    <%--<asp:ListBox runat="server" id="lb_aloha" SelectionMode="Multiple" CssClass="form-control input-sm" Rows="25"  >
                                    </asp:ListBox>--%>

                                    <asp:ListBox ID="ddl_disponible" runat="server" AutoPostBack="true" CssClass="form-control input-sm" Rows="25" multiple="multiple">
                                    </asp:ListBox>

                                    Cantidad: <asp:Label ID="lb_cantidad_disponible" runat="server" Text="0"></asp:Label>

                                    <%--<asp:DropDownList id="ddl_aloha" runat="server" multiple="multiple" AutoPostBack="true" CssClass="form-control input-sm">
                                    </asp:DropDownList>--%>

                                </div>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="table-hover">
                                <div id="tableHeader" class="fixed-header"></div>
                                <div class="fixed-header-table-container">

                                    <asp:LinkButton ID="lnb_agregar_uno" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="lnb_agregar_uno_Click"> > </asp:LinkButton>
                                    <br /><br />
                                    <asp:LinkButton ID="lnb_quitar_uno" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="lnb_quitar_uno_Click"> < </asp:LinkButton>
                                    <br /><br />
                                    <asp:LinkButton ID="lnb_agregar_todos" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" Visible="false"> >> </asp:LinkButton>
                                    <br /><br />
                                    <asp:LinkButton ID="lnb_quitar_todos" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" Visible="false"> << </asp:LinkButton>

                                </div>
                            </div>
                        </div>

                        <div class="col-md-5">
                            <div class="table-bordered table-hover">
                                <div id="tableHeader" class="fixed-header"></div>
                                <div class="fixed-header-table-container">

                                    <asp:ListBox ID="ddl_asignado" runat="server" AutoPostBack="true" CssClass="form-control input-sm" Rows="25" multiple="multiple">
                                    </asp:ListBox>

                                    Cantidad: <asp:Label ID="lb_cantidad_asignado" runat="server" Text="0"></asp:Label>

                                </div>
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
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>