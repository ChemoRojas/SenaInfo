<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_DiagnisticoEscolar.aspx.cs" Inherits="mod_ninos_ninos_DiagnisticoEscolar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="cc1" %>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Diagnóstico Escolar</title>
    <script src="../js/jquery-1.10.2.js"></script>
    <%--<script src="../js/jquery-1.11.1.min.js"></script>--%>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/ventanas-modales.js"></script>--%>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">    
    <script type="text/javascript">


        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }


        function MostrarModalDiagnosticoEscolar() {
            var objIframe = document.getElementById('iframe_diagnostico_escolar');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoEscolar.aspx?dir=DiagnosticoEscolar.aspx";
                objIframe.height = "450px";
                objIframe.width = "800px";
            }
            $find("mpe2a").show();
            return false;
        }



        //function pageLoad(sender, args) {
        //  $(document).ready(function () {
        //    $("#collapse_diagEscolar").click(function () {
        //      if ($("#collapse_diagEscolar").hasClass("collapsed")) { //mostrado
        //        $("#icon-collapse").removeClass();
        //        $("#icon-collapse").addClass("glyphicon glyphicon-minus");
        //        $("#lbl_acordeon").text('Cancelar');
        //      }
        //      else {
        //        $("#icon-collapse").removeClass(); // oculto
        //        $("#icon-collapse").addClass("glyphicon glyphicon-plus");
        //        $("#lbl_acordeon").text('Agregar Diagnostico Escolcar');
        //      }
        //    });
        //  });
        //}
        function cleanForm() {
            //gfontbrevis
            document.getElementById("ddown001").value = "0";
            document.getElementById("ddown002").value = "0";
            document.getElementById("ddown003").value = "0";
            document.getElementById("TxtAnoEscolaridad").value = "";
            document.getElementById("txt002_te").value = "";

            document.getElementById("CalDiagnostico").value = "";

            document.getElementById("ddown001").style.background = "White";
            document.getElementById("ddown002").style.background = "White";
            document.getElementById("ddown003").style.background = "White";
            document.getElementById("TxtAnoEscolaridad").style.background = "White";
            document.getElementById("CalDiagnostico").style.background = "White";

        }



    </script>

</head>
<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="botonLimpiar" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                    TargetControlID="BtnVerHistorico"
                    PopupControlID="modal_diagnostico_escolar"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>
                <div class="container">

                    <h4><label class="titulo-form">Diagnóstico Escolar</label></h4>

                    <div class="row">
                        <div class="col-md-12">
                            
                            <div class="alert alert-warning text-center" color-text="green" role="alert" id="alertaEditar" runat="server" visible="false">
                                <span class="glyphicon glyphicon-alert"></span>&nbsp;&nbsp;
                                No se ha realizado diagnóstico escolar para el año <asp:Label ID="lblAnoActual" runat="server" Text=""></asp:Label>, favor
                                revisar y realizar si es necesario.
                            </div>

                            <asp:GridView ID="grd001aa" CssClass="table table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCommand="grd001aa_RowCommand" Width="100%" OnRowDataBound="grd001aa_RowDataBound">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="alingreso" HeaderText="Primer Diagnóstico"></asp:BoundField>
                                    <asp:BoundField DataField="ICodEscolar" HeaderText="ICod Escolar"></asp:BoundField>
                                    <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Escolaridad"></asp:BoundField>
                                    <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="AnoUltimoCursoAprobado" HeaderText="A&#241;o Escolaridad"></asp:BoundField>
                                    <asp:BoundField DataField="AsistenciaEscolar" HeaderText="Tipo Asistencia"></asp:BoundField>
                                    <asp:ButtonField Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
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


                                <asp:Label ID="lbl002aa" runat="server" CssClass="help-block"></asp:Label>
                                <asp:Label ID="lbl001aa" runat="server" CssClass="help-block"></asp:Label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <table class="table table-bordered  table-condensed">
                                            <tbody>
                                                <tr>
                                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Diagnóstico *</th>

                                                    <td class="col-md-4">
                                                        <asp:TextBox ID="CalDiagnostico" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                        <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="CalDiagnostico" ValidChars="0123456789-/" />
                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="CalDiagnostico" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                        <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" Display="Dynamic" ControlToValidate="CalDiagnostico" Type="Date" OnInit="rv_fecha_Init" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="help-block" ValidationGroup="FechaDiag" runat="server" ControlToValidate="CalDiagnostico" Display="Dynamic" ErrorMessage="Fecha Diagn&oacute;stico Requerida">
                                                        </asp:RequiredFieldValidator>

                                                    </td>

                                                    <th class="titulo-tabla col-md-1" scope="row">Escolaridad *</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Tipo de Asistencia Escolar *</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                        </asp:DropDownList>
                                                    </td>

                                                    <th class="titulo-tabla" scope="row">Año Escolaridad Indicada *</th>
                                                    <td>
                                                        <asp:TextBox ID="TxtAnoEscolaridad" CssClass="form-control form-control input-sm" AutoPostBack="true" MaxLength="4" placeholder="Ingresar" runat="server" OnTextChanged="TxtAnoEscolaridad_TextChanged"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtAnoEscolaridad" ValidChars="0123456789" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <th class="titulo-tabla" scope="row">Observaciones</th>
                                                    <td>
                                                        <asp:TextBox ID="txt002_te" CssClass="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <table class="table">
                                    <tr>
                                        <td>
                                            <div class="pull-right">
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnAgregarDiagnostico" runat="server" OnClick="imb_001aa_Click" AutoPostback="true">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnModificarDiagnostico" runat="server" OnClick="imb_002aa_Click" AutoPostback="true">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="BtnLimpiar" runat="server" OnClick="imb_003aa_Click" AutoPostback="true" CausesValidation="false">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="botonLimpiar" Visible="false" runat="server" OnClick="imb_003aa_Click" CausesValidation="false">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;New Limpiar
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="BtnVerHistorico" runat="server" OnClientClick="return MostrarModalDiagnosticoEscolar()" class="btn btn-info btn-sm" AutoPostback="true">
                                                    <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button pull-right" OnClientClick="return mostrarBotonAgregar()">
                                                    <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div class="popupConfirmation" id="modal_diagnostico_escolar" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal2" runat="server" CausesValidation="false">
                                            <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                        <h4 class="modal-title">HISTORICO DIAGNOSTICO ESCOLAR</h4>
                                    </div>
                                    <div>
                                        <iframe id="iframe_diagnostico_escolar" frameborder="0" runat="server"></iframe>
                                    </div>
                                </div>
                            </div>




                            <div class="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <strong>Nota: </strong>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="El primer diagnóstico no se puede modificar ya que se registra en el formulario de ingreso del niño al proyecto."></asp:Label>

                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <button id="btnMostrarForm" style="background-color: transparent; border: 0;" runat="server" type="button" data-toggle="collapse" data-target="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
                </button>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
<%--<script src="../js/jquery-1.10.2.js"></script>--%>
<%--<script src="../js/bootstrap.min.js"></script>--%>
<%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
<%--<script src="../js/ventanas-modales.js"></script>--%>
<%--<script src="../js/jquery-ui.js"></script>--%>
<%--<script src="../js/bootstrap.min.js"></script>--%>

</html>
