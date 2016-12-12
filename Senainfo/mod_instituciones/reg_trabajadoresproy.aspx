<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="reg_trabajadoresproy.aspx.cs" Inherits="mod_institucion_reg_trabajadoresproy" %>

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
    <title>Relación Trabajador - Proyecto :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/senainfoTools.js"></script>



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
    <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <link href="../css/theme.css" rel="stylesheet" />
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>

    <script type="text/javascript">

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "";

        }
        $(document).ready(function () {
            $("#lbl005").hide();
            $("#alerts").hide();
            $("#lbl0052").hide();
            $("#alerts2").hide();
        })

        function MostrarModalInstitucionDDOWN() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            //var olbl001 = document.getElementById('lbl001');
            var oddown001 = document.getElementById('ddown001');

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Trabajadores-Proyecto&dir=reg_trabajadoresproy.aspx" + "&codinst=" + oddown001.options[oddown001.selectedIndex].value;
            //"../mod_instituciones/bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadoresproy.aspx" + "&codinst=" + ddown001.SelectedValue;
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe4a").show();
            return false;
        }

        function diffFecha() {
            var fit_start_time = new Date($("#wdc001").val());
            var fit_end_time = new Date($("#wdc002").val());

            if (fit_end_time < fit_start_time) {
                $("#lbl005").show();
                $("#alerts").show();
                $("#lbl005").text("Fecha de egreso debe ser posterior a la fecha de ingreso.");
                $("#lbl0052").hide();
                $("#alerts2").hide();
                return false;
            } else {
                $("#lbl005").hide();
                $("#alerts").hide();
                $("#lbl0052").hide();
                $("#alerts2").hide();
                return true;
            }
            if (fit_end_time.trim() == "") {
                $("#lbl005").hide();
                $("#alerts").hide();
                $("#lbl0052").hide();
                $("#alerts2").hide();
                return true;
            }
            //if (fit_start_time.replace("0", "9") > fit_end_time.replace("0", "9")) {
            //    //alert(fit_start_time);
            //    $("#lbl005").show();
            //    $("#alerts").show();
            //    $("#lbl005").text("Fecha de egreso debe ser posterior a la fecha de ingreso.");
            //    $("#lbl0052").hide();
            //    $("#alerts2").hide();
            //    return false;
            //} else {
            //    $("#lbl005").hide();
            //    $("#alerts").hide();
            //    $("#lbl0052").hide();
            //    $("#alerts2").hide();
            //    return true;
            //}


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
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Instituciones/Proyecto</li>
                        <li class="active">Registro Trabajador - Proyecto</li>
                    </ol>
                    <div class="alert alert-warning" role="alert" id="alerts" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="alert alert-success" role="alert" id="alerts2" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Trabajadores - Proyecto</h4>
                        <hr>


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
                    <cc1:ModalPopupExtender ID="mpe4a" BehaviorID="mpe4a" runat="server"
                        TargetControlID="imb001"
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
                    <%-- /**FUO**/ --%>
                    <div class="row">
                        <div class="col-md-12">
                            <table class="table table-bordered table-condensed">

                                <tr>
                                    <th class="titulo-tabla col-md-1">Institución *</th>
                                    <td class="col-md-4">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_instituciones/reg_trabajadoresproy.aspx','mpe4a')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </td>

                                    <th class="titulo-tabla col-md-1">Proyecto *</th>
                                    <td>
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_instituciones/reg_trabajadoresproy.aspx', 'mpe3a')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla">Trabajador *</th>
                                    <td>
                                        <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <th class="titulo-tabla ">Cargo *</th>
                                    <td>
                                        <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla ">Estamento *</th>
                                    <td>
                                        <asp:DropDownList ID="ddown005" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <td class="titulo-tabla ">Profesión *</td>
                                    <td>
                                        <asp:DropDownList ID="ddown006" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla ">Fecha de ingreso:</th>
                                    <td>
                                        <asp:TextBox ID="wdc001" Text="Seleccione Fecha" runat="server" CssClass="form-control input-sm" TextMode="SingleLine" placeholder="dd-mm-aaaa" ReadOnly="false" AutoPostBack="true"></asp:TextBox>
                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender_wdc001" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="wdc001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></cc1:CalendarExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="vguno" Enabled="true" ControlToValidate="wdc001" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        <cc1:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="wdc001" ValidChars="0123456789-/" />
                                    </td>

                                    <th class="titulo-tabla ">Responsable Ingreso</th>
                                    <td>
                                        <asp:TextBox ID="txt001" runat="server" CssClass="form-control input-sm form-control-60" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla ">Fecha de Egreso:</th>
                                    <td>
                                        <asp:TextBox ID="wdc002" Text="Seleccione Fecha" runat="server" CssClass="form-control input-sm" TextMode="SingleLine" placeholder="dd-mm-aaaa" ReadOnly="false" AutoPostBack="true"></asp:TextBox>
                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender_wdc002" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="wdc002" Format="dd-MM-yyyy" StartDate="<%# DateTime.Now.AddDays(1) %>" ValidateRequestMode="Enabled" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="vgdos" Enabled="true" ControlToValidate="wdc002" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="wdc002" ValidChars="0123456789-/" />
                                    </td>

                                    <th class="titulo-tabla ">Responsable Egreso</th>
                                    <td>
                                        <asp:TextBox ID="txt002" runat="server" CssClass="form-control input-sm form-control-60" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla ">Causal de Egreso</th>
                                    <td>
                                        <asp:DropDownList ID="ddown007" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <th class="titulo-tabla">Vigencia</th>
                                    <td>
                                        <asp:DropDownList ID="ddown008" CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Selected="True" Value="V">Vigente</asp:ListItem>
                                            <asp:ListItem Value="C">Caducado</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>

                            <div class="botonera pull-right">
                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb001" runat="server" OnClientClick="return MostrarModalInstitucionDDOWN()" Visible="true">
                                            <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton4" ValidationGroup="vguno" OnClientClick="return diffFecha();" Style="margin: auto;" runat="server" Visible="false" OnClick="WebImageButton4_Click">
                                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton1" ValidationGroup="vgdos" runat="server" OnClientClick="return diffFecha();" OnClick="WebImageButton1_Click">
                                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" CausesValidation="False" runat="server" OnClick="WebImageButton2_Click">
                                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                </asp:LinkButton>
                            </div>
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
