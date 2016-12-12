<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncuestaEMAIL.aspx.cs" Inherits="EncuestaEMAIL" %>

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
    <title>Actualización Datos Institución :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/jquery-ui.js"></script>

    <script src="js/jquery.validate.js"></script>
    <script src="js/jquery.Rut.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">

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
        <%-- Se oculta el menu para que no puedan saltarse la encuesta y navegar por el sitio --%>
        <%--<uc1:menu_colgante runat="server" ID="menu_colgante" />--%>
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li class="active">Inicio</li>
                        <li class="active">Encuesta</li>
                        <li class="active"><strong>Actualización Datos Institución</strong></li>
                    </ol>

                    <div class="alert alert-warning" role="alert" id="alerts" runat="server"  style="margin-top:10px;display:none" >
                        <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lb_mensaje" runat="server" Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Actualización Datos Institución</h4>
                        <hr>

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Nombre Completo Representante Legal: <strong>(*)</strong></label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_nombrerepleg" runat="server" CssClass="form-control input-sm" placeholder="Nombre Completo Representante Legal" MaxLength="150"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">E-Mail Institución: <strong>(*)</strong></label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control input-sm" placeholder="E-Mail Institución" MaxLength="150"></asp:TextBox>
                                            <%--<ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_email" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />--%>
                                            <asp:RegularExpressionValidator ID="rev_txt_email" runat="server" ControlToValidate="txt_email" ErrorMessage="E-Mail Inválido" Display="Dynamic" CssClass="help-block" ValidationExpression="^[_a-z0-9-_A-Z0-9-]+(\.[_a-z0-9-_A-Z0-9-]+)*@[a-z0-9-A-Z0-9-]+(\.[a-z0-9-A-Z0-9-]+)*(\.[a-zA-Z]{2,3})$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Teléfono Institución: <strong>(*)</strong></label>
                                        </th>
                                        <td>
                                            <div class="input-group">
                                                <span class="input-group-addon-telefono">(+56-)</span>
                                                <asp:TextBox ID="txt_telefono" runat="server" AutoCompleteType="LastName" CssClass="form-control input-sm" placeholder="Teléfono Institución" MaxLength="10"></asp:TextBox>
                                            </div>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt_telefono" runat="server" TargetControlID="txt_telefono" ValidChars="1234567890" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Dirección Institución: <strong>(*)</strong></label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txt_direccion" runat="server" AutoCompleteType="FirstName" CssClass="form-control input-sm" placeholder="Dirección Institución" MaxLength="150"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt_direccion" runat="server" TargetControlID="txt_direccion" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ1234567890" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>&nbsp;</th>
                                        <td><strong>(*): Campos Obligatorios</strong></td>
                                    </tr>
                                    <!-- inicio: nueva posicion de botones -->
                                    <tr>
                                        <th></th>
                                        <td>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnb_grabar" runat="server" Text="Grabar" ValidationGroup="grupo1" AutoPostback="false" OnClick="lnb_grabar_Click">
                                              <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Grabar
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
                            <%--<div class="col-md-2">
                                <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lb_informacion" CssClass="subtitulo-form-info" runat="server"></asp:Label><br /><br />  
                                    </div>
                                </div>
                            </div>--%>
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