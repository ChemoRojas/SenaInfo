<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="reg_eventosproy.aspx.cs" Inherits="mod_institucion_reg_eventosproy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="sbtb" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>



<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Eventos del Proyecto - Senainfo :: SERVICIO NACIONAL DE MENORES </title>



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
    <script src="../js/senainfoTools.js"></script>


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

        function funcionsuma() {
            if (trim(document.getElementById("txt003").value) == "") {
                a = 0;
            } else {
                a = parseInt(trim(document.getElementById("txt003").value));
            }
            if (trim(document.getElementById("txt004").value) == "") {
                b = 0;

            } else {
                b = parseInt(trim(document.getElementById("txt004").value));
            }
            if (trim(document.getElementById("txt005").value) == "") {
                c = 0;
            }
            else {
                c = parseInt(trim(document.getElementById("txt005").value));
            }

            if (trim(document.getElementById("txt006").value) == "") {
                d = 0;
            } else {
                d = parseInt(trim(document.getElementById("txt006").value));
            }

            var textoprop = a + b + c + d;

            //alert(textoprop);
            document.getElementById("txt002").value = textoprop.toString();

        }
        function trim(str) {
            str = str.toString();
            while (1) {
                if (str.substring(0, 1) != " ") {
                    break;
                }
                str = str.substring(1, str.length);
            }
            while (1) {
                if (str.substring(str.length - 1, str.length) != " ") {
                    break;
                }
                str = str.substring(0, str.length - 1);
            }
            return str;
        }

        function AcceptNum(evt) {
            var nav4 = window.Event ? true : false;
            var key = nav4 ? evt.which : evt.keyCode;
            return (key <= 13 || (key >= 48 && key <= 57) || key == 44);
        }
        function f_SoloNumeros() {
            var key = window.event.keyCode;
            if (key < 48 || key > 57) {
                window.event.keyCode = 0;
            }
        }

        function MostrarModalInstitucionDDOWN() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            //var olbl001 = document.getElementById('lbl001');
            var oddown001 = document.getElementById('ddown002');

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Eventos-Proyecto&dir=reg_eventosproy.aspx" + "&codproy=" + oddown001.options[oddown001.selectedIndex].value;
            //"../mod_instituciones/bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadoresproy.aspx" + "&codinst=" + ddown001.SelectedValue;
            objIframe.height = "300px";
            objIframe.width = "750px";
            $find("mpe4a").show();
            return false;
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "";

        }
    </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <style type="text/css">
        .esconder {
            display:none;
        }
    </style>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_Excel" />
            </Triggers>
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Registro de Eventos del Proyecto</li>
                    </ol>
                    <div class="alert alert-warning" role="alert" id="alerts" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="alert alert-success" role="alert" id="alerts2" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Eventos del Proyecto</h4>
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
                            TargetControlID="imb_lupa_modal"
                            PopupControlID="modal_bsc_institucion"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModal4">
                        </cc1:ModalPopupExtender>
                        <cc1:ModalPopupExtender ID="mpe3a" BehaviorID="mpe3a" runat="server"
                        TargetControlID="imb_lupa_modal2"
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
                                                <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','reg_eventosproy.aspx','mpe4a')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>

                                        <th class="titulo-tabla col-md-1">Proyecto *</th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                    <%-- OnSelectedIndexChanged="ddown002_SelectedIndexChanged" --%>
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal2" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','reg_eventosproy.aspx','mpea3')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                        
                                    </tr>
                                    <tr id="oculto" runat="server" visible="false">
                                        <th class="titulo-tabla">Registra Taller</th>
                                        <td>
                                            <asp:RadioButtonList ID="rbl_registrarTaller" CssClass="text-center" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbl_registrarTaller_SelectedIndexChanged">
                                                <asp:ListItem Value="1">si</asp:ListItem>
                                                <asp:ListItem Value="2">no</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                         <th class="titulo-tabla" id="thNombreTaller" runat="server">Nombre Taller</th>
                                        <td id="tdNombreTaller" runat="server">
                                            <asp:DropDownList ID="NombreTaller" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Tipo de Evento *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla">Fecha Evento *</th>
                                        <td>
                                            <asp:TextBox ID="WebDateChooser1" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" AutoPostBack="true" OnTextChanged="WebDateChooser1_TextChanged"></asp:TextBox>
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="WebDateChooser1" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></cc1:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Enabled="true" ControlToValidate="WebDateChooser1" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Región *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla">Comuna *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown005" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0" Selected="True"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Descripción</th>
                                        <td>
                                            <asp:TextBox ID="txt001" runat="server" CssClass="form-control input-sm " MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla">Cantidad de Asistentes Niñas y Adolecentes (femeninos) *</th>
                                        <td>
                                            <asp:TextBox ID="txt003" runat="server" CssClass="form-control input-sm " MaxLength="4"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt003" runat="server" ErrorMessage="Cantidad Inv&aacute;lida" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            <cc1:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt003" ValidChars="0123456789-/" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Cantidad de Asistentes Niños y Adolecentes (masculinos) *</th>
                                        <td>
                                            <asp:TextBox ID="txt004" runat="server" CssClass="form-control input-sm " MaxLength="4"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt004" runat="server" ErrorMessage="Cantidad Inv&aacute;lida" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt004" ValidChars="0123456789-/" />
                                        </td>

                                        <th class="titulo-tabla">Cantidad Asistentes Adultos (femeninos) *</th>
                                        <td>
                                            <asp:TextBox ID="txt005" runat="server" CssClass="form-control input-sm" MaxLength="4"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt005" runat="server" ErrorMessage="Cantidad Inv&aacute;lida" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt005" ValidChars="0123456789-/" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Cantidad Asistentes Adultos (masculinos) *</th>
                                        <td>
                                            <asp:TextBox ID="txt006" runat="server" CssClass="form-control input-sm " MaxLength="4"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txt006" runat="server" ErrorMessage="Cantidad Inv&aacute;lida" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt006" ValidChars="0123456789-/" />
                                        </td>

                                        <th class="titulo-tabla">Suma de los Asistentes</th>
                                        <td>
                                            <asp:TextBox ID="txt002" runat="server" CssClass="form-control input-sm" MaxLength="4" Enabled="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt002" runat="server" ErrorMessage="Cantidad Inv&aacute;lida" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt006" ValidChars="0123456789-/" />
                                        </td>
                                    </tr>
                                </table>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton1" runat="server" OnClientClick="return MostrarModalInstitucionDDOWN()" Visible="true" OnClick="WebImageButton1_Click1">
                                    <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <a id="A3" runat="server" class="ifancybox" />

                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton4" runat="server" OnClick="WebImageButton4_Click" Visible="false">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb001" runat="server" OnClick="imb001_Click">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" runat="server" OnClick="WebImageButton2_Click">
                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                </div>

                                <table class="table table-borderless table-condensed">
                                    <tr>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblCantidadVigentes" class="subtitulo-form" Text="lblcantidadVigentes" runat="server" Visible="false" /></h4>
                                        </td>
                                    </tr>
                                </table>
                                <div class="table-condensed">
                                    <asp:GridView ID="grdAsistencia" CssClass="table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ICodEventoProyectoAsistenciaNinos" HeaderText="Cod Proyecto" ItemStyle-CssClass="esconder" HeaderStyle-CssClass="esconder">
                                            <HeaderStyle CssClass="esconder" />
                                            <ItemStyle CssClass="esconder" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ICodIE" HeaderText="Cod IE"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Presente">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPresente" runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ICodEventosProyectos" HeaderText="Cod Eventos Proyectos" ItemStyle-CssClass="esconder" HeaderStyle-CssClass="esconder">
                                            <HeaderStyle CssClass="esconder" />
                                            <ItemStyle CssClass="esconder" />
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnMarcarTodo" Text="Marcar Todos" runat="server" OnClick="btnMarcarTodo_Click" Visible="False">
                                    <span class="glyphicon glyphicon-check"></span>&nbsp;
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnDesmarcarTodo" Text="Desmarcar todos" runat="server" OnClick="btnDesmarcarTodo_Click" Visible="False">
                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn_Excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" Text="Exportar" OnClick="btn_Excel_Click" Visible="False">
                                    <span class="glyphicon glyphicon-save-file"></span>&nbsp;
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               <%-- <footer class="footer" aria-hidden="False">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                            <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>--%>
                </a>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
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
<%--<div>
            <br />
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="titulo_form" style="height: 20px">&nbsp;Registro de Eventos-Proyecto<table align="right" border="0" cellpadding="1"
                        cellspacing="1" width="120">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <a id="A3" runat="server" class="ifancybox"><asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="Buscar" OnClick="WebImageButton1_Click" /></a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                        <br />
                        <br />
                        <asp:Label ID="lbl001" runat="server" ForeColor="Red" Text="No puede registrar evento en mes cerrado"
                            Visible="False"></asp:Label></td>
                </tr>--%>