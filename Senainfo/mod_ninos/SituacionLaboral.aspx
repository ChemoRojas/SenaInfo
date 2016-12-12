<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SituacionLaboral.aspx.cs" Inherits="mod_ninos_SituacionLaboral" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Situación Laboral</title>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">

        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }


        function MostrarModalSituacionLaboral() {
            var objIframe = document.getElementById('iframe_situacion_laboral');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoSituacionLaboral.aspx?dir=SituacionLaboral.aspx";
                objIframe.height = "450px";
                objIframe.width = "800px";
            }
            $find("mpe1a").show();
            return false;
        }
        function cleanForm() {
            //gfontbrevis

            document.getElementById("ddown001f").value = "0";
            document.getElementById("ddown002f").value = "0";
            
            document.getElementById("ddown001f").style.background = "White";
            document.getElementById("ddown002f").style.background = "White";
           

            document.getElementById("txt001f").value = "";
            document.getElementById("txt002f").value = "";
            document.getElementById("txt003f").value = "";
            document.getElementById("txt004f").value = "";
            document.getElementById("txt005f").value = "";
            document.getElementById("cal_001f").value = "";
            document.getElementById("cal_001f").style.background = "White";
            document.getElementById("chk001OcupacionLaboral").checked = false;
            
           

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
                    TargetControlID="imb_004f"
                    PopupControlID="modal_situacion_laboral"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">
                    <%--<a id="collapse_SituacionLaboral" runat="server" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
              <span id="icon-collapse" class="glyphicon glyphicon-minus" ></span>
              <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Pinche aqui para ocultar el formulario"></asp:label>
          </a>--%>



                    <h4>
                        <label class="titulo-form">Situación Laboral Adolescente</label></h4>

                    <div class="row">

                        <div class="col-md-12">
                            <asp:Panel ID="lbl001fa" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="* Solo llenar si se encuentra trabajando"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lbl_nota2" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no Posee Situación Laboral"></asp:Label>

                                    </p>
                                </div>
                            </asp:Panel>
                            <br />

                            <asp:GridView ID="grd001f" CssClass="table table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" OnRowCommand="grd001f_RowCommand">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="IcodSituacionLaboral" HeaderText="IcodSituacionLaboral" />
                                    <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagn&#243;stico "></asp:BoundField>
                                    <asp:BoundField DataField="FechaSituacionLaboral" DataFormatString="{0:d}" HeaderText="Fecha de Diagn&#243;stico" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Area de Inserci&#243;n Laboral"></asp:BoundField>
                                    <asp:BoundField DataField="SituacionLaboral" HeaderText="Situaci&#243;n Laboral"></asp:BoundField>
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

                                <form>
                                    <table class="table table-bordered  table-condensed tabla-tabs">
                                        <tbody>
                                            <tr>
                                                <th class="titulo-tabla col-md-1" scope="row">Fecha *</th>
                                                <td class="col-md-4">
                                                    
                                                                <asp:TextBox ID="cal_001f" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_001f" ValidChars="0123456789-/" />
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1130" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_001f" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server"  ErrorMessage="Fecha Invalida" ControlToValidate="cal_001f" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic"/>
                                                            
                                                </td>
                                            
                                                <th class="titulo-tabla col-md-1" scope="row">Área Inserción Laboral *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown001f" CssClass="form-control input-sm" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Situación Laboral *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown002f" CssClass="form-control input-sm" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            
                                                <th class="titulo-tabla" scope="row">Dirección Laboral</th>
                                                <td>
                                                    <asp:TextBox ID="txt001f" CssClass="form-control  input-sm" runat="server" MaxLength="100" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Código Postal</th>
                                                <td>
                                                    <asp:TextBox ID="txt002f" CssClass="form-control  input-sm" runat="server" MaxLength="32" placeholder="Ingresar" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt002f" ValidChars="0123456789" />

                                                </td>
                                            
                                                <th class="titulo-tabla" scope="row">Teléfono Laboral</th>
                                                <td>
                                                    <asp:TextBox ID="txt003f" CssClass="form-control  input-sm" runat="server" MaxLength="10" placeholder="Ingresar" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt003f" ValidChars="0123456789" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Persona Referencia</th>
                                                <td>
                                                    <asp:TextBox ID="txt004f" CssClass="form-control  input-sm" runat="server" placeholder="Ingresar" />
                                                </td>
                                            
                                                <th class="titulo-tabla" scope="row">E-Mail</th>
                                                <td>
                                                    <asp:TextBox ID="txt005f" CssClass="form-control  input-sm" runat="server" MaxLength="30" OnTextChanged="TextBox1_TextChanged" placeholder="Ingresar"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                                <span class="subtitulo-form" scope="row">&nbsp;Cuenta con HEDI Laboral &nbsp;&nbsp;&nbsp;</span><asp:CheckBox ID="chk001OcupacionLaboral" runat="server" />
                                                
                                            
                                </form>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_001f" runat="server" OnClick="imb_001f_Click"  AutoPostback="true" ValidationGroup="grupo1" >
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_002f" runat="server" OnClick="imb_002f_Click"  AutoPostback="true" ValidationGroup="grupo1">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb_003f" runat="server" OnClick="imb_003f_Click"  AutoPostback="true" CausesValidation="False">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="imb_004f" runat="server"  OnClientClick="return MostrarModalSituacionLaboral()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button" AutoPostback="true">
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server"  CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>

                                    <div class="popupConfirmation" id="modal_situacion_laboral" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                                 <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO DIAGNOSTICO SITUACION LABORAL</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_situacion_laboral" frameborder="0" runat="server"></iframe>
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
