<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_DiagnosticoMaltrato.aspx.cs" Inherits="mod_instituciones_ninos_DiagnosticoMaltrato" %>

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
    <title>Diagnóstico Maltrato</title>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">

        function MostrarModalDiagnosticoMaltrato() {
            var objIframe = document.getElementById('iframe_diagnostico_maltrato');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoMaltrato.aspx?dir=ninos_DiagnosticoMaltrato.aspx";
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
            document.getElementById("ddown001a").value = "0";
            document.getElementById("ddown002a").value = "0";
            document.getElementById("ddown003a").value = "0";
            document.getElementById("ddown004a").value = "0";
            document.getElementById("txt_003a").value = "";
            document.getElementById("CalDiagnostico").value = "";

            document.getElementById("chk001a").checked = false;
            document.getElementById("chk002a").checked = false;

            document.getElementById("rdo001a").checked = true;
            document.getElementById("rdo002a").checked = false;
            document.getElementById("rdo003a").checked = true;
            document.getElementById("rdo004a").checked = false;

            document.getElementById("ddown001a").style.background = "White";
            document.getElementById("ddown003a").style.background = "White";
            document.getElementById("ddown004a").style.background = "White";
            document.getElementById("CalDiagnostico").style.background = "White";

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
                    TargetControlID="BtnVerHistorico"
                    PopupControlID="modal_diagnostico_maltrato"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">

                    <%--<a id="collapse_diagMaltrato" class="btn btn-primary btn-sm"  runat="server" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
                      <span id="icon-collapse" class="glyphicon glyphicon-minus" ></span>
                      <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Agregar Diagnostico Maltrato"></asp:label>
                  </a>--%>
                    
                    <h4><label class="titulo-form">Diagnóstico Maltrato</label></h4>
                    <div class="row">
                        <div class="col-md-12">
                            
                                    <asp:GridView ID="grd001a" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCommand="grd001a_RowCommand" Width="100%">
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <Columns>
                                            <asp:BoundField DataField="ICodMaltrato" HeaderText="ICodMaltrato"></asp:BoundField>
                                            <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                            <asp:BoundField DataField="TipoMaltratoDes" HeaderText="Tipo de Maltrato"></asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Maltrato"></asp:BoundField>
                                            <asp:BoundField DataField="NombreCompletoPR" HeaderText="Relaci&#243;n con el Maltratador"></asp:BoundField>
                                            <asp:BoundField DataField="NombreCompleto" HeaderText="T&#233;cnico"></asp:BoundField>
                                            <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico" HtmlEncode="False"></asp:BoundField>
                                            <asp:ButtonField Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                
                            <asp:Panel ID="lbl001a" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no posee Diagnóstico de Maltrato"></asp:Label>

                                    </p>
                                </div>
                            </asp:Panel>
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


                                <asp:Label ID="lbl002a" runat="server" CssClass="help-block"></asp:Label>
                                <asp:Label ID="inicioFormulario" runat="server"></asp:Label>
                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Fecha Diagnóstico *</th>
                                            <td class="col-md-4">

                                                <asp:TextBox ID="CalDiagnostico" CssClass="form-control form-control-fecha-large input-sm" MaxLength="10" runat="server" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="CalDiagnostico" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="CalDiagnostico" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="CalDiagnostico" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="FechaDiag" runat="server" ControlToValidate="CalDiagnostico" ErrorMessage="Fecha Diagn&oacute;stico Requerida" CssClass="help-block" Display="Dynamic">
                                                </asp:RequiredFieldValidator>

                                            </td>

                                            <th class="titulo-tabla col-md-1" scope="row">Presenta Maltrato *</th>
                                            <td class="text-center">
                                                <asp:RadioButton ID="rdo001a" runat="server" AutoPostBack="True" Checked="True" GroupName="gr1" OnCheckedChanged="rdo001a_CheckedChanged" Text="Si" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton ID="rdo002a" runat="server" AutoPostBack="True" GroupName="gr1" OnCheckedChanged="rdo002a_CheckedChanged" Text="No" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo de Maltrato *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001a" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown001a_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Maltrato *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown002a" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Conoce Presunto Maltratador *</th>
                                            <td class="text-center">
                                                <asp:RadioButton ID="rdo003a" runat="server" AutoPostBack="True" GroupName="gr2" OnCheckedChanged="rdo003a_CheckedChanged" Text="SI" Checked="True" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton ID="rdo004a" runat="server" AutoPostBack="True" GroupName="gr2" OnCheckedChanged="rdo004a_CheckedChanged" Text="NO" />
                                            </td>

                                            <th class="titulo-tabla" scope="row">Relación con el Presunto Maltratador *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003a" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown003a_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Vive con el Agresor *</th>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chk001a" runat="server" Text="SI" />
                                            </td>

                                            <th class="titulo-tabla" scope="row">Existe Querella *</th>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chk002a" runat="server" Text="SI" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown004a" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Observaciones</th>
                                            <td>
                                                <asp:TextBox ID="txt_003a" CssClass="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnAgregarDiagnostico" runat="server" OnClick="imb_001a_Click" AutoPostback="true">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnModificarDiagnostico" runat="server" OnClick="imb_002a_Click" AutoPostback="true">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="BtnLimpiar" runat="server" OnClick="imb_003a_Click" AutoPostback="true" CausesValidation="False">
                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="BtnVerHistorico" runat="server" OnClientClick="return MostrarModalDiagnosticoMaltrato()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button" AutoPostback="true">
                                    <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>

                                    <div class="popupConfirmation" id="modal_diagnostico_maltrato" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                                                   <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO DIAGNOSTICO MALTRATO</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_diagnostico_maltrato" frameborder="0" runat="server"></iframe>
                                        </div>
                                    </div>
                                    </a>
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
