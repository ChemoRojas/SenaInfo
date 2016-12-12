<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_Informes_Coordinador.aspx.cs" Inherits="mod_reportes_Rep_Informes_Coordinador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Nómina de adolescentes / Certificado de Ingreso :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>


    <script type="text/javascript">

        function f_MuestraEspera() {
            var Buscando = document.getElementById('Buscando');
            if (Buscando.value == '0') {
                Buscando.value = '1';
                document.getElementById('lblBuscando').style.visibility = 'visible';
                return true;
            }
            else
                return false;
        };

        //function diffFecha() {
        //  var fecha_inicio = $("#cal001").val();
        //  var fecha_termino = $("#cal002").val();
        //  if (fecha_inicio > fecha_termino) {
        //    alert("Fecha desde no puede ser mayor que fecha de termino");
        //    return false;
        //  } else {
        //    return true;
        //  }
        //};


    </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server" >
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="imb_3" />
                <asp:PostBackTrigger ControlID="imb_05" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="ModalPopupExtender1"
                    BehaviorID="mpe1b"
                    runat="server"
                    TargetControlID="imb_lupa_modal2"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>
                <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                    <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">INSTITUCION</h4>
                    </div>
                    <div>
                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                    </div>
                </div>


                <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="btnCerrarModal2" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">PROYECTO</h4>
                    </div>
                    <div>
                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                    </div>
                </div>

                 


                <%-- //**FUO**// --%>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Coordinadores</li>
                        <li class="active">Reporte Nómina de Adolescente / Certificado de Ingreso</li>
                    </ol>

                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <asp:Label ID="lblSinResultados" runat="server" Text="No se han encontrado resultados" Visible="false"></asp:Label>
                        <asp:Label ID="lbl006" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="alert alert-warning" role="alert" id="alert2" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                        <asp:Label ID="lblErrorFecha" runat="server" Text="Fecha termino no puede ser menor que fecha de inicio" Visible="false"></asp:Label>
                    </div>


                    <div class="well">
                        <h4 class="subtitulo-form">Reporte Nómina de Adolescente / Certificado de Ingreso</h4>
                        <hr />
                        <div class="row">


                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Tipo Listado:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="0" Selected="True">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">Nómina</asp:ListItem>
                                                <asp:ListItem Value="2">Certificado Ingreso</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Institución:</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion', '../mod_reportes/Rep_Informes_Coordinador.aspx','mpe1a')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Proyecto:</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown003" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" AutoPostBack="false">
                                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal2" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_Informes_Coordinador.aspx','mpe1b')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Medida:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem>Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Medio:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddown005" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown005_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem>Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">Medio Libre</asp:ListItem>
                                                <asp:ListItem Value="2">Privado Libertad</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Fecha: </label>
                                        </th>
                                        <td>
                                            <div class="col-md-2">
                                                <label for="">Desde: </label>
                                            </div>

                                            <div class="col-md-4">
                                                <asp:TextBox ID="cal001" CssClass="form-control input-sm" runat="server" placeholder="dd-mm-aaaa" MaxLength="10" OnTextChanged="cal001_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1393" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal001" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Desde Requerida" ValidationGroup="fechas"></asp:RequiredFieldValidator><br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="fechas" />
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />

                                            </div>

                                            <div class="col-md-2">
                                                <label for="">Hasta: </label>
                                            </div>
                                            <div class="col-md-4 no-padding">
                                                <asp:TextBox ID="cal002" CssClass="form-control input-sm" runat="server" placeholder="dd-mm-aaaa" MaxLength="10"></asp:TextBox>
                                                <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1405" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal002" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Desde Requerida" ValidationGroup="fechas"></asp:RequiredFieldValidator><br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="cal002" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="fechas" />
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal002" ValidChars="0123456789-/" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="imb_1" Text="" runat="server" OnClick="imb_1_Click">
                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm fixed-width-button" ID="imb_3" Text="" runat="server" OnClick="imb_3_Click" Visible="false">
                                                <span class="glyphicon glyphicon-print"></span>&nbsp;Imprimir Certificado
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm fixed-width-button" ID="imb_05" Text="" runat="server" OnClick="imb_05_Click" ValidationGroup="fechas" Visible="false">
                                                <span class="glyphicon glyphicon-print"></span>&nbsp;Imprimir Nómina
                                            </asp:LinkButton>

                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <%--OnClientClick="return diffFecha();--%>
                            <div class="col-md-3">
                                <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados para generar el reporte."></asp:Label>
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
                <br />
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

        <%--<script src="../js/bootstrap.min.js"></script>
                <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
                <script src="../js/ie10-viewport-bug-workaround.js"></script>
                <!-- Latest compiled and minified JavaScript -->--%>
    </form>
</body>
</html>

