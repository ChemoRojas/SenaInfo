<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HechosJudiciales.aspx.cs" Inherits="mod_ninos_HechosJudiciales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Hechos Judiciales</title>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">

        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }

        function MostrarModalHechosJudiciales() {
            var objIframe = document.getElementById('iframe_hechos_judiciales');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoHechosJudiciales.aspx?dir=HechosJudiciales.aspx";
                objIframe.height = "450px";
                objIframe.width = "800px";
            }
            $find("mpe1a").show();
            return false;
        }

        function isNumeric(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        function ValidaRuc(source, arguments) {

            var rut = arguments.Value;
            rut = rut.trim();
            if (rut.length < 12) { arguments.IsValid = false; return }

            var strGuionDigito = rut.substring(rut.length - 2);
            var strCuerpo = rut.substring(0, rut.length - 2);

            if (!isNumeric(strCuerpo)) { arguments.IsValid = false; return }

            if (strGuionDigito.substring(0, 1) != '-') { arguments.IsValid = false; return }
            var aux = "2765432765432";
            var ruc = "123456789K0";
            var ns = rut.length;
            var i = ns - 2;
            var a = 12;
            var sum = 0;
            while (i >= 0) {
                if (rut.substring(i, i + 1) != '-') {
                    sum = sum + (parseInt(rut.substring(i, i + 1)) * parseInt(aux.substring(a, a + 1)));
                    a = a - 1;
                    if (a == 0) a = 12;
                }
                i = i - 1;
            }
            sum = 11 - (sum % 11);
            if (rut.substring(ns - 1, ns) == ruc.substring(sum - 1, sum))
                arguments.IsValid = true;
            else
                arguments.IsValid = false;
        };
        function cleanForm() {
            //gfontbrevis
            document.getElementById("ddown001g").selectedIndex = 0;
            document.getElementById("ddown001g_2f").value = "0";
            document.getElementById("ddown002g").value = "0";
            document.getElementById("ddown003g").value = "0";
            document.getElementById("ddown005g").value = "0";
            document.getElementById("ddown006g").value = "-2";
            document.getElementById("ddown001g").style.background = "White";
            document.getElementById("ddown001g_2f").style.background = "White";
            document.getElementById("ddown002g").style.background = "White";
            document.getElementById("ddown003g").style.background = "White";
            document.getElementById("ddown005g").style.background = "White";


            document.getElementById("txt001g").value = "";
            document.getElementById("txt002g").value = "";
            document.getElementById("txt004g").value = "";
            document.getElementById("txt005g").value = "";
            document.getElementById("cal001g").value = "";

            document.getElementById("cal001g").style.background = "White";

            document.getElementById("chk001g").checked = false;
            document.getElementById("chk002g").checked = false;
            document.getElementById("chk003g").checked = false;
            document.getElementById("chk004g").checked = false;

        }



    </script>
</head>
<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_004g"
                    PopupControlID="modal_hechos_judiciales"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">
                    <%--<a id="collapse_HechosJudiciales" runat="server" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
          <span id="icon-collapse" class="glyphicon glyphicon-minus" ></span>
          <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Pinche aqui para ocultar el formulario"></asp:label>
      </a>--%>

                    <h4>
                        <label class="titulo-form">Hechos Judiciales</label></h4>




                    <div class="row">
                        <div class="col-md-12">

                            <asp:Panel ID="lbl001fa" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="* Esta información sólo debe ser utilizada por proyectos que trabajen con abogados defendiendo niños(as) adolescentes"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lbl_nota2" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no Posee Hechos Judiciales"></asp:Label>

                                    </p>
                                </div>
                            </asp:Panel>
                            <br />

                            <asp:GridView ID="grd001g" CssClass="table table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False"  OnRowCommand="grd001g_RowCommand">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="ICodHechosJudiciales" HeaderText="ICodhJudiciales"></asp:BoundField>
                                    <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                    <asp:BoundField DataField="MateriaCausa" HeaderText="Materia Causa"></asp:BoundField>
                                    <asp:BoundField DataField="Tribunal" HeaderText="Tribunal"></asp:BoundField>
                                    <asp:BoundField DataField="FechaHechoJudicial" DataFormatString="{0:d}" HeaderText="Fecha Hecho Judicial" HtmlEncode="False"></asp:BoundField>
                                    <asp:ButtonField Text="Modificar"></asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                            <table class="table">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="btnGatillo" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button pull-right" OnClientClick="return mostrarBotonCancelar()">
                                              <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Diagnóstico
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>


                            <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                <table class="table table-bordered table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Fecha Hecho Judicial *</th>
                                            <td class="col-md-4">

                                                <asp:TextBox ID="cal001g" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001g" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende486" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001g" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal001g" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />

                                            </td>

                                            <th class="titulo-tabla col-md-1" scope="row">Tipo Tribunal *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown005g" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown006g_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Región *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown006g" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown006g_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Tribunal *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001g" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001g_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Materia *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001g_2f" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001g_2f_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Materia Causa *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown002g" CssClass="form-control input-sm" runat="server">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Rol Causa</th>
                                            <td>
                                                <asp:TextBox ID="txt001g" CssClass="form-control  input-sm" MaxLength="12" runat="server" />
                                            </td>

                                            <th class="titulo-tabla" scope="row">Ruc</th>
                                            <td>

                                                <asp:TextBox ID="txt004g" CssClass="form-control input-sm" MaxLength="12" runat="server" placeholder="YYONNNNNNN-D Ejemplo 1010083505-6" />
                                                <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt004g" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />

                                                <asp:CustomValidator ID="cv_txt006F2" runat="server" ControlToValidate="txt004g" Display="Dynamic" CssClass="help-block" ErrorMessage="El RUC ingresado no es válido" ClientValidationFunction="ValidaRuc" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Rit</th>
                                            <td>
                                                <asp:TextBox ID="txt005g" CssClass="form-control  input-sm" MaxLength="32" runat="server" />
                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt005g" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />
                                            </td>

                                            <th class="titulo-tabla" scope="row">Tiene Querella SENAME</th>
                                            <td>
                                                <table class="table table-bordered tabla-tabs">
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chk001g" runat="server" />
                                                        </td>


                                                        <td>
                                                            <asp:CheckBox ID="chk002g" runat="server" Text="&nbsp;Víctima" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                        
                                                            <asp:CheckBox ID="chk003g" runat="server" Text="&nbsp;Acusado" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                        
                                                            <asp:CheckBox ID="chk004g" runat="server" Text="&nbsp;Tiene Defensor" />
                                                        </td>
                                                    </tr>

                                                </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003g" CssClass="form-control input-sm" runat="server">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Observaciones</th>
                                            <td>
                                                <asp:TextBox ID="txt002g" CssClass="form-control input-sm" runat="server" Font-Names="Arial" MaxLength="100"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_001g" runat="server" OnClick="imb_001g_Click" ValidationGroup="grupo1" AutoPostback="true">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_002g" runat="server" OnClick="imb_002g_Click" ValidationGroup="grupo1" AutoPostback="true">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb_003g" runat="server" OnClick="imb_003g_Click" CausesValidation="False" AutoPostback="true">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="imb_004g" runat="server" OnClientClick="return MostrarModalHechosJudiciales()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button" AutoPostback="true">
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>
                                    <div class="popupConfirmation" id="modal_hechos_judiciales" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                            <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO DIAGNOSTICO HECHOS JUDICIALES</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_hechos_judiciales" frameborder="0" runat="server"></iframe>
                                        </div>
                                    </div>
                                </div>
                            </div>




                        </div>
                    </div>
                </div>
                <button id="btnMostrarForm" style="background-color: transparent; border: 0;" runat="server" type="button" data-toggle="collapse" data-target="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
                </button>
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
<script src="../js/jquery-1.10.2.js"></script>
<script src="../js/bootstrap.min.js"></script>
<%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
<%--<script src="../js/ventanas-modales.js"></script>--%>
<script src="../js/jquery-ui.js"></script>
<script src="../js/bootstrap.min.js"></script>
</html>
