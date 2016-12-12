<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defensoria.aspx.cs" Inherits="mod_jueces_Defensoria" %>

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
    <title>Defensoria :: Senainfo :: Servicio Nacional de Menores</title>

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
                        <li><a href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Busqueda <strong>NNA</strong></li>
                        <li class="active">LRPA - <strong>Defensoría</strong></li>
                    </ol>

                    <div class="alert alert-warning" role="alert" id="alerts" runat="server"  style="margin-top:10px;display:none" >
                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lb_mensaje" runat="server" Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Defensoria</h4>
                        <hr>

                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">RUN NNA:</label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_run" runat="server" CssClass="form-control input-sm" placeholder="RUN" MaxLength="12"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Apellido Paterno:</label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_apaterno" runat="server" AutoCompleteType="LastName" CssClass="form-control input-sm" placeholder="Ingresar Apellido Paterno" MaxLength="30"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_apaterno" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Apellido Materno:</label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_amaterno" runat="server" AutoCompleteType="LastName" CssClass="form-control input-sm" placeholder="Ingresar Apellido Materno" MaxLength="30"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_amaterno" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Nombre del Niño(a):</label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_nombres" runat="server" AutoCompleteType="FirstName" CssClass="form-control input-sm" placeholder="Ingresar Nombre(s)" MaxLength="30"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_nombres" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                        </td>
                                    </tr>
                                    <!-- inicio: nueva posicion de botones -->
                                    <tr>
                                        <th></th>
                                        <td>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnb_buscar" runat="server" Text="Buscar" ValidationGroup="grupo1" AutoPostback="false" OnClick="lnb_buscar_Click">
                                              <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                            <!-- agrega pull-right para alinear a la derecha boton limpiar -->
                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right fixed-width-button" ID="lbn_Limpiar" runat="server" Text="Limpiar" AutoPostback="true" CausesValidation="false" OnClick="lbn_Limpiar_Click">
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

                                    <asp:GridView ID="grd_resultado" CssClass="table table-bordered table-hover caja-tabla " runat="server" Visible="False" onAutoGenerateColumns="False" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="ICodIE" HeaderText="ICodIE" AccessibleHeaderText="ICodIE"></asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="CodProyecto" AccessibleHeaderText="CodProyecto"></asp:BoundField>
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" AccessibleHeaderText="Nombre"></asp:BoundField>
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="FechaIngreso" AccessibleHeaderText="FechaIngreso" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                            <asp:BoundField DataField="rut" HeaderText="rut" AccessibleHeaderText="rut"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido_Paterno" AccessibleHeaderText="Apellido_Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido_Materno" AccessibleHeaderText="Apellido_Materno"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" AccessibleHeaderText="Nombres"></asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" AccessibleHeaderText="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                            <asp:BoundField DataField="RUC" HeaderText="RUC" AccessibleHeaderText="RUC"></asp:BoundField>
                                            <asp:BoundField DataField="RIT" HeaderText="RIT" AccessibleHeaderText="RIT"></asp:BoundField>
                                            <asp:BoundField DataField="Tribunal" HeaderText="Tribunal" AccessibleHeaderText="Tribunal"></asp:BoundField>
                                            <asp:BoundField DataField="Delito" HeaderText="Delito" AccessibleHeaderText="Delito"></asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <asp:LinkButton ID="lnb_ExportarExcel" runat="server" CssClass="btn btn-success btn-sm pull-right fixed-width-button" Text="Exportar" CausesValidation="False" AutoPostback="true" Visible="false" OnClick="lnb_ExportarExcel_Click">
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