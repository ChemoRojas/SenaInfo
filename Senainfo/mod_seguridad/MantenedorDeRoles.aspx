<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenedorDeRoles.aspx.cs" Inherits="mod_seguridad_MantenedorDeRoles" %>

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
    <title>Mantenedor de Roles :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jquery-ui.js"></script>

    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

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

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#txt_run').Rut({
                    on_error: function () { alert('RUN Incorrecto'); $('#txt_run').val(''); $('#txt_run').focus(); },
                    format_on: 'keyup'
                });

            });
        };
    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)" onkeydown="return (event.keyCode!=13)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <Triggers>
                <asp:PostBackTrigger ControlID="lnb_ExportarExcel" />
            </Triggers>
            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Seguridad</li>
                        <li class="active">Mantenedor de Roles</li>
                    </ol>

                    <div class="alert alert-warning" role="alert" id="alerts" runat="server"  style="margin-top:10px;display:none" >
                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lb_mensaje" runat="server" Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Mantenedor de Roles</h4>
                        <hr>

                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Descripción:</label>
                                        </th>
                                        <td>
                                            <asp:HiddenField ID="hf_idrol" runat="server" Value="0" />
                                            <asp:TextBox ID="txt_descripcion" runat="server" CssClass="form-control input-sm" placeholder="Ingresar Descripción" MaxLength="100" AutoCompleteType="None"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt_descripcion" runat="server" TargetControlID="txt_descripcion" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Nombre:</label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control input-sm" placeholder="Ingresar Nombre" MaxLength="100" AutoCompleteType="None"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt_nombre" runat="server" TargetControlID="txt_nombre" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Vigencia:</label>
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddl_vigencia" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="V">Vigente</asp:ListItem>
                                                <asp:ListItem Value="C">Caducado</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <!-- inicio: nueva posicion de botones -->
                                    <tr>
                                        <th></th>
                                        <td>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnb_guardar" runat="server" Text="Guardar" ValidationGroup="grupo1" AutoPostback="false" OnClick="lnb_guardar_Click" >
                                              <span class="glyphicon glyphicon-log-in"></span>&nbsp;Guardar
                                            </asp:LinkButton>

                                            <asp:LinkButton CssClass="btn btn-success btn-sm fixed-width-button" ID="lnb_actualizar" runat="server" Text="Actualizar" ValidationGroup="grupo1" AutoPostback="false" Visible="false" OnClick="lnb_actualizar_Click" >
                                              <span class="glyphicon glyphicon-log-in"></span>&nbsp;Actualizar
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
                        <div class="col-md-12">
                            <div class="table-bordered table-hover">
                                <!-- inicio gfontbrevis se agrega para fijar header -->
                                <div id="tableHeader" class="fixed-header"></div>
                                <div class="fixed-header-table-container">
                                    <!-- fin -->

                                    <asp:GridView ID="grd_resultado" CssClass="table table-bordered table-hover caja-tabla" AutoPostback="true" runat="server" Visible="False" onAutoGenerateColumns="False" AutoGenerateColumns="False" OnRowCommand="grd_resultado_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="IdRol" HeaderText="ID Rol" AccessibleHeaderText="IdRol"></asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" AccessibleHeaderText="Descripcion"></asp:BoundField>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" AccessibleHeaderText="Nombre"></asp:BoundField>
                                            <asp:BoundField DataField="IndVigencia" HeaderText="Vigencia" AccessibleHeaderText="IndVigencia"></asp:BoundField>
                                            <asp:ButtonField Text="Editar" CommandName="EditarRol" HeaderText="Editar"></asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <asp:LinkButton ID="lnb_ExportarExcel" runat="server" CssClass="btn btn-success btn-sm pull-right fixed-width-button" Text="Exportar" CausesValidation="False" AutoPostback="true" Visible="false" >
                                <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                            </asp:LinkButton>
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