<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapacitacionNino.aspx.cs" Inherits="mod_ninos_CapacitacionNino" %>

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
    <title>Capacitación Niñoa/a</title>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function MostrarModalCapacitacionNino() {
            var objIframe = document.getElementById('iframe_capacitacion_nino');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoCapacitacion.aspx?dir=CapacitacionNino.aspx";
                objIframe.height = "450px";
                objIframe.width = "800px";
            }
            $find("mpe1a").show();
            return false;
        }



        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }
        function cleanForm() {
            //gfontbrevis
            
            document.getElementById("ddown001e").value = "0";
            document.getElementById("ddown002e").value = "0";
            document.getElementById("ddown003e").value = "0";
            document.getElementById("ddown004e").value = "0";
            document.getElementById("ddown005e").value = "0";
            document.getElementById("ddown001e").style.background = "White";
            document.getElementById("ddown002e").style.background = "White";
            document.getElementById("ddown003e").style.background = "White";
            document.getElementById("ddown004e").style.background = "White";

            document.getElementById("txt001e").value = "";
            document.getElementById("txt002e").value = "";
            document.getElementById("cal001e").value = "";
            document.getElementById("cal002e").value = "";
            document.getElementById("cal001e").style.background = "White";

        }

    </script>
</head>
<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="imb_001e" />
                <asp:AsyncPostBackTrigger ControlID="imb_002e" />
                <asp:AsyncPostBackTrigger ControlID="imb_003e" />
                <asp:AsyncPostBackTrigger ControlID="imb_004e" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_004e"
                    PopupControlID="modal_capacitacion_nino"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">
                    <%--<a id="collapse_Capacitacion" runat="server" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
              <span id="icon-collapse" class="glyphicon glyphicon-minus" ></span>
              <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Pinche aqui para ocultar el formulario"></asp:label>
          </a>--%>
                    <h4>
                        <label class="titulo-form">Capacitación Niño (a)</label></h4>

                    <div class="row">
                        <div class="col-md-12">
                             <asp:Panel ID="lbl001ea" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="* Sólo llenar si se le imparte capacitación durante la permanencia en el proyecto"></asp:Label>
                                        </p><p>
                                        <asp:Label ID="lbl_nota2" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no posee Diagnóstico de Capacitación"></asp:Label>

                                    </p>
                                </div>
                            </asp:Panel>
                            <br />
                            
                                        <asp:GridView ID="grd001e" CssClass="table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False"  OnRowCommand="grd001e_RowCommand" >
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <Columns>
                                                <asp:BoundField DataField="ICodCapacitacionNino" HeaderText="ICodCapacitacionNino" />
                                                <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Capacitaci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico" HtmlEncode="False" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="Area" HeaderText="Area Capacitaci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="Termino" HeaderText="Termino"></asp:BoundField>
                                                <asp:BoundField DataField="FechaInicioCapacitacion" DataFormatString="{0:d}" HeaderText="Fecha Inicio" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="FechaTerminoCapacitacion" DataFormatString="{0:d}" HeaderText="FechaTermino" HtmlEncode="False"></asp:BoundField>
                                                <asp:ButtonField Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
                                            </Columns>
                                        </asp:GridView>
                                    

                           
                            <table class="table">
                                <tr>
                                    <td>
                                      <asp:LinkButton ID="btnGatillo" runat="server"  CssClass="btn btn-primary btn-sm fixed-width-button pull-right" OnClientClick="return mostrarBotonCancelar()">
                                          <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Diagnóstico
                                      </asp:LinkButton>

                                    </td>
                                </tr>
                            </table>

                            <asp:Label ID="lbl001e" CssClass="help-block" runat="server"></asp:Label>

                            <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">

                                <form>
                                    <table class="table table-bordered table-condensed">
                                        <tbody>
                                            <tr>
                                                <th class="titulo-tabla col-md-1" scope="row">Tipo Capacitación *</th>
                                                <td class="col-md-4">
                                                    <asp:DropDownList ID="ddown001e" CssClass="form-control input-sm" runat="server" >
                                                    </asp:DropDownList>
                                                </td>
                                            
                                                <th class="titulo-tabla col-md-1" scope="row">Área Capacitación *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown002e" CssClass="form-control input-sm" runat="server" >
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Organismo Capacitador *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown003e" CssClass="form-control input-sm" runat="server" >
                                                    </asp:DropDownList>
                                                </td>
                                              <th class="titulo-tabla" scope="row">Estado Capacitación *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown004e" CssClass="form-control input-sm" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Fecha Inicio *</th>
                                                <td>
                                                    
                                                                <asp:TextBox ID="cal001e" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" AutoPostBack="true" OnTextChanged="cal001e_TextChanged" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001e" ValidChars="0123456789-/" />
                                                                <ajax:CalendarExtender ID="CalendarExtende353" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001e" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server"  ErrorMessage="Fecha Invalida" ControlToValidate="cal001e" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                                            
                                                </td>
                                            
                                                <th class="titulo-tabla" scope="row">Horas</th>
                                                <td>
                                                    <asp:TextBox ID="txt001e" CssClass="form-control  input-sm" runat="server" MaxLength="3" placeholder="Ingresar" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt001e" ValidChars="0123456789" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Observaciones</th>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txt002e" CssClass="form-control  input-sm" runat="server" MaxLength="100"  ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Término</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown005e" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown005e_SelectedIndexChanged" >
                                                        <asp:ListItem Value="0"> Selecionar</asp:ListItem>
                                                        <asp:ListItem Value="A">Aprobado</asp:ListItem>
                                                        <asp:ListItem Value="E">Egresado sin Titulo</asp:ListItem>
                                                        <asp:ListItem Value="I">Interrumpe Deserci&#243;n</asp:ListItem>
                                                        <asp:ListItem Value="R">Reprobado</asp:ListItem>
                                                        <asp:ListItem Value="C">Egresado cursando capacitacion</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            
                                                <th class="titulo-tabla" scope="row">Fecha Término</th>
                                                <td>
                                                    
                                                                <asp:TextBox ID="cal002e" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" AutoPostBack="true" OnTextChanged="cal002e_TextChanged" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="cal002e" ValidChars="0123456789-/" />
                                                                <ajax:CalendarExtender ID="CalendarExtende366" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002e" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                <asp:RangeValidator ID="RangeValidator2" runat="server"  ErrorMessage="Fecha Invalida" ControlToValidate="cal002e" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                                           
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </form>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_001e" runat="server" OnClick="imb_001e_Click">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_002e" runat="server" OnClick="imb_002e_Click"   >
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb_003e" runat="server" OnClick="imb_003e_Click"  CausesValidation="False">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb_004e" OnClientClick="return MostrarModalCapacitacionNino()" runat="server"  CausesValidation="False">
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server"  CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>

                                    <div class="popupConfirmation" id="modal_capacitacion_nino" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                            <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO DIAGNOSTICO CAPACITACION</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_capacitacion_nino" frameborder="0" runat="server"></iframe>
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
