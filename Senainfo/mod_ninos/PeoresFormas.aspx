<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PeoresFormas.aspx.cs" Inherits="mod_ninos_PeoresFormas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>
<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Diagnóstico Peores Formas de Trabajo</title>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">

        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }

        function MostrarModalPeoresFormas() {
            var objIframe = document.getElementById('iframe_peores_formas');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoPeoresFormas.aspx?dir=PeoresFormas.aspx";
                objIframe.height = "450px";
                objIframe.width = "800px";
            }
            $find("mpe1a").show();
            return false;
        }
        function cleanForm() {
            //gfontbrevis
            document.getElementById("ddown_Comuna").selectedIndex = 0;
            document.getElementById("ddown_relacion").selectedIndex = 0;
            document.getElementById("ddown_region").selectedIndex = 0;
            document.getElementById("ddown001h").value = "0";
            document.getElementById("ddown002h").value = "0";
            document.getElementById("ddown003h").value = "0";


            document.getElementById("txt001_wth").value = "";

            document.getElementById("cal001h").value = "";
            document.getElementById("cal002h").value = "";

            document.getElementById("chk001h").checked = false;
            document.getElementById("rdo001h").checked = true;
            document.getElementById("rdo002h").checked = false;

            document.getElementById("ddown001h").removeAttribute("disabled");
            document.getElementById("ddown002h").removeAttribute("disabled");
            document.getElementById("chk001h").removeAttribute("disabled");
            document.getElementById("ddown003h").removeAttribute("disabled");


            document.getElementById("ddown_Comuna").style.background = "White";
            document.getElementById("ddown001h").style.background = "White";
            document.getElementById("ddown003h").style.background = "White";

            document.getElementById("cal001h").style.background = "White";
            document.getElementById("cal002h").style.background = "White";
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
                    TargetControlID="btn004h"
                    PopupControlID="modal_peores_formas"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>

                <div class="container">
                    <%--<a id="collapse_PeoresFormas" runat="server" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
              <span id="icon-collapse" class="glyphicon glyphicon-minus" ></span>
              <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Pinche aqui para ocultar el formulario"></asp:label>
          </a>--%>

                    <h4><label class="titulo-form">
                        Diagnóstico Peores Formas de Trabajo
                        
                    </label></h4>
                    
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Panel ID="lbl001fa" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="* Sólo registrar si el niño(a) o adolescente presenta esta situación"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lbl_nota2" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no Posee Diagnóstico Peores Formas de Trabajo"></asp:Label>

                                    </p>
                                </div>
                            </asp:Panel>
                            <br />


                            <asp:GridView ID="grd001h" CssClass="table  table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False"  OnRowCommand="grd001h_RowCommand" >
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="ICodPFTI" HeaderText="ICodPFTI" />
                                    <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagn&#243;stico "></asp:BoundField>
                                    <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagn&#243;stico" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Categor&#237;a Formas de Trabajo"></asp:BoundField>
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="T&#233;cnico"></asp:BoundField>
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
                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Fecha Diagnóstico *</th>
                                            <td class="col-md-4">
                                                
                                                            <asp:TextBox ID="cal001h" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001h" ValidChars="0123456789-/" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1104" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001h" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal001h" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />
                                                        
                                            </td>
                                        
                                            <th class="titulo-tabla col-md-1" scope="row">Región Ocurrencia *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_region" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown_region_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Comuna Ocurrencia *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_Comuna" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        
                                            <th class="titulo-tabla" scope="row">Fecha Ocurrencia</th>
                                            <td>
                                                
                                                            <asp:TextBox ID="cal002h" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="cal002h" ValidChars="0123456789-/" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1117" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002h" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                        
                                                            <asp:RangeValidator ID="RangeValidator2" runat="server"  ErrorMessage="Fecha Invalida" ControlToValidate="cal002h" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic"/>
                                                        
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Relacion Presunto Explotador Laboral</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_relacion" CssClass="form-control input-sm" runat="server"  AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        
                                            <th class="titulo-tabla" scope="row">Presenta situación</th>
                                            <td class="text-center">
                                                <asp:RadioButton ID="rdo001h" runat="server" AutoPostBack="True" Checked="True" GroupName="gr1" OnCheckedChanged="rdo001h_CheckedChanged" Text="&nbsp;Si" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                &nbsp;
                                        <asp:RadioButton ID="rdo002h" runat="server" AutoPostBack="True" GroupName="gr1" OnCheckedChanged="rdo002h_CheckedChanged" Text="&nbsp;No" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Categoría Forma de Trabajo *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001h" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        
                                            <th class="titulo-tabla" scope="row">Presunto Explotador</th>
                                            <td>
                                                <asp:DropDownList ID="ddown002h" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Vive con el Presunto Explotador</th>
                                            <td class="text-center">
                                                <asp:CheckBox ID="chk001h" runat="server"  Text="&nbsp;Si" />
                                            </td>
                                        
                                            <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003h" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Observaciones</th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txt001_wth" CssClass="form-control input-sm" runat="server" MaxLength="100" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn001h" runat="server" OnClick="imb_001h_Click"  ValidationGroup="grupo1" AutoPostback="true" >
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn002h" runat="server" OnClick="imb_002h_Click"  ValidationGroup="grupo1" AutoPostback="true" >
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn003h" runat="server" OnClick="btn003h_Click"  CausesValidation="False" AutoPostback="true" >
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn004h" runat="server"  OnClientClick="return MostrarModalPeoresFormas()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button" AutoPostback="true" >
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>
                                    <div class="popupConfirmation" id="modal_peores_formas" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                                     <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO PEORES FORMAS DE TRABAJO</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_peores_formas" frameborder="0" runat="server"></iframe>
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
