<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="reg_inmueblesproy.aspx.cs" Inherits="mod_institucion_reg_inmueblesproy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Registro de Inmuebles en el Proyecto - Senainfo :: SERVICIO NACIONAL DE MENORES</title>
    <script src="../js/senainfoTools.js"></script>



    <link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <%--<script src="../js/ventanas-modales.js"></script>--%>
    <script src="../js/jquery-ui.js"></script>

    <script src="../js/ie-emulation-modes-warning.js"></script>
    <%-- <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.1.1.min.js"></script>--%>
    <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <%-- <script src="../Script/jquery.fancybox-1.3.4.js"></script>--%>
    <!--<script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script> -->

    <!-- originales -->
    <!--<script src="../Script/jquery.min.js"></script> 
    <script src="../Script/jquery-1.4.3.min.js"></script>-->

    <%-- <link href="../css/sename_aplica.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <%--<script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>--%>
    <%-- <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>--%>
    <link href="../css/theme.css" rel="stylesheet" />
    <link href="../css/ventanas-modales.css" rel="stylesheet" />

    <script type="text/javascript">

        function MostrarModalInstitucionDDL() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            //var olbl001 = document.getElementById('lbl001');
            var oddown001 = document.getElementById('ddl_institucion');

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Inmuebles-Proyecto&dir=reg_inmueblesproy.aspx" + "&codinst=" + oddown001.options[oddown001.selectedIndex].value;
            //"../mod_instituciones/bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadoresproy.aspx" + "&codinst=" + ddown001.SelectedValue;
            objIframe.height = "300px";
            objIframe.width = "750px";
            $find("mpe4a").show();
            return false;
        }
        
    </script>
</head>

<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Registro Inmuebles Proyecto</li>
                    </ol>
                    <div class="alert alert-warning" role="alert" id="alerts" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="alert alert-success" role="alert" id="alerts2" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Inmuebles en el Proyecto</h4>

                        <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="btnCerrarModal4" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                    <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">INSTITUCION</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server"></iframe>
                            </div>
                        </div>
                        <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="btnCerrarModal3" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                           <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">PROYECTO</h4>

                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server"></iframe>
                            </div>
                        </div>

                        <cc1:ModalPopupExtender ID="mpe4a" BehaviorID="mpe4a" runat="server"
                            TargetControlID="btn_buscar"
                            PopupControlID="modal_bsc_institucion"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModal4">
                        </cc1:ModalPopupExtender>
                        <cc1:ModalPopupExtender ID="mpe3a" BehaviorID="mpe3a" runat="server"
                            TargetControlID="imb_lupa_modal"
                            PopupControlID="modal_bsc_proyecto"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModal3">
                        </cc1:ModalPopupExtender>

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-bordered table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1">Institución *</th>
                                        <td class="col-md-4">
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddl_institucion" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddl_institucion_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="btn_buscar" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucionDDL()" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>

                                        <th class="titulo-tabla col-md-1">Proyecto *</th>
                                        <td>
                                            <div class="input-group">

                                                <asp:DropDownList ID="ddl_proyecto" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddl_proyecto_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_instituciones/reg_inmueblesproy.aspx','mpe3a')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Inmueble *</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_inmueble" CssClass="form-control input-sm" runat="server" AutoPostBack="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla">Fecha Inicio *</th>
                                        <td>
                                            <asp:TextBox ID="txt_fi" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fi" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></cc1:CalendarExtender>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_fi" ValidChars="0123456789-/" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Fecha Término</th>
                                        <td>
                                            <asp:TextBox ID="txt_ft" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txt_ft" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></cc1:CalendarExtender>
                                            <cc1:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt_ft" ValidChars="0123456789-/" />
                                        </td>

                                        <th class="titulo-tabla">Vigencia</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_vigencia" align="center" CssClass="form-control input-sm" runat="server" AutoPostBack="True">
                                                <asp:ListItem Value="V">Vigente</asp:ListItem>
                                                <asp:ListItem Value="C">Caducado</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="botonera pull-right">

                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" Visible="false" ID="btn_actualizar" runat="server" OnClick="btn_actualizar_Click">
                                  <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_guardar" runat="server" OnClick="btn_guardar_Click">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click">
                                  <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <footer class="footer" aria-hidden="False">
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
        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <script src="../js/bootstrap.min.js"></script>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
        <!-- Latest compiled and minified JavaScript -->
    </form>
</body>
</html>
