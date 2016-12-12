<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_DiagnosticoDroga.aspx.cs" Inherits="mod_ninos_ninos_DiagnosticoDroga" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="./images/favicon.ico">
    <title>Diagnóstico Droga</title>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>

    <script type="text/javascript">
        function MostrarModalDiagnosticoDroga() {
            var objIframe = document.getElementById('iframe_diagnostico_droga');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoDroga.aspx?dir=ninos_DiagnosticoDroga.aspx";
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
            document.getElementById("CalDiagnostico").value = "";

            document.getElementById("ddown001b").value = "0";
            document.getElementById("ddown002b").value = "0";
            document.getElementById("ddown003b").value = "0";
            if (document.getElementById("chk001DrogaLRPA")) {
                document.getElementById("chk001DrogaLRPA").checked = false;
            }

            document.getElementById("txt002b").value = "";


            document.getElementById("ddown001b").style.background = "White";
            document.getElementById("ddown002b").style.background = "White";
            document.getElementById("ddown003b").style.background = "White";
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
                    PopupControlID="modal_diagnostico_droga"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">
                    
                   
                    <h4><label class="titulo-form">Diagnóstico Droga</label></h4>

                    <div class="row">
                        <div class="col-md-12">

                            
                                    <asp:GridView ID="grd001b" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCommand="grd001b_RowCommand" Width="100%">
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <Columns>
                                            <asp:BoundField DataField="ICodDroga" HeaderText="ICodDroga"></asp:BoundField>
                                            <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                            <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico" HtmlEncode="False"></asp:BoundField>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Droga"></asp:BoundField>
                                            <asp:BoundField DataField="TipoConsumo" HeaderText="Tipo Consumo"></asp:BoundField>
                                            <asp:BoundField DataField="NombreCompleto" HeaderText="T&#233;cnico"></asp:BoundField>
                                            <asp:ButtonField Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                               

                            <asp:Panel ID="lbl001a" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no posee Diagnóstico de Droga"></asp:Label>

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

                                <div class="alert alert-warning text-center" color-text="green" role="alert" id="alertaEditar" runat="server" visible="false">
                                    <span class="glyphicon glyphicon-alert"></span>&nbsp;&nbsp;
                                    El menor posee menos de 6 años (Fecha nacimiento: <asp:Label ID="lblFechaNac" runat="server" Text=""></asp:Label>), por lo que 
                                    es posible que el diagnóstico de Droga sea erróneo.
                                </div>

                                <asp:Label ID="lbl001b" runat="server" CssClass="help-block" Width="100%" />
                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Fecha Diagnóstico *</th>
                                            <td class="col-md-4">

                                                <asp:TextBox ID="CalDiagnostico" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender  ID="fte1" runat="server" TargetControlID="CalDiagnostico" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="CalDiagnostico" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="CalDiagnostico" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="FechaDiag" runat="server" ControlToValidate="CalDiagnostico" ErrorMessage="Fecha Diagn&oacute;stico Requerida" CssClass="help-block" Display="Dynamic">
                                                </asp:RequiredFieldValidator>

                                            </td>

                                            <th class="titulo-tabla col-md-1" scope="row">Droga *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001b" CssClass="form-control input-sm" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown001b_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Consumo Droga *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown002b" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown002b_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003b" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Observaciones</th>
                                            <td>
                                                <asp:TextBox ID="txt002b" runat="server" CssClass="form-control input-sm" MaxLength="100" />
                                            </td>


                                            <th class="titulo-tabla" scope="row">
                                                <asp:Panel ID="tblSENDA_1" runat="server" Visible="false">Se atiende en SENDA (SI)</asp:Panel>
                                            </th>
                                            <td>
                                                <asp:Panel ID="tblSENDA_2" runat="server" Visible="false">
                                                    <asp:CheckBox ID="chk001DrogaLRPA" runat="server" Enabled="False" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnAgregarDiagnostico" runat="server" OnClick="imb_001b_Click" ValidationGroup="grupo1" AutoPostback="true">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnostico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnModificarDiagnostico" runat="server" OnClick="imb_002b_Click" AutoPostback="true">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="BtnLimpiar" runat="server" OnClick="imb_003b_Click" AutoPostback="true" CausesValidation="False">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="BtnVerHistorico" runat="server" OnClientClick="return MostrarModalDiagnosticoDroga()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button" AutoPostback="true">
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>

                                    <div class="popupConfirmation" id="modal_diagnostico_droga" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                                      <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO DIAGNOSTICO DROGA</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_diagnostico_droga" frameborder="0" runat="server"></iframe>
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
