<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiagnosticoPsicologico.aspx.cs" Inherits="mod_ninos_DiagnosticoPsicologico" %>

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
    <title>Diagnóstico Psicológico / Psiquiátrico</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script src="../js/senainfoTools.js"></script>

    <script type="text/javascript">

        function AbrirURLModalPopUp(url) {
            parent.location.replace(url);
        }


        function MostrarModalDiagnosticoPsicologico() {
            var objIframe = document.getElementById('iframe_diagnostico_psicologico');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticoPsicologico.aspx?dir=DiagnosticoPsicologico.aspx";
                objIframe.height = "450px";
                objIframe.width = "800px";
            }
            $find("mpe1a").show();
            return false;
        }
        function cleanForm() {
            /*.SelectedValue = "0";               
            .Text = "";
            .Text = "";      
            .Text = "";
            ddl_TipoDiag.Items.Clear();
            ddl_TipoDiag.Enabled = true;
            ddl_TipoDiag.Items.Clear();
            ddl_TipoDiag.Items.Insert(0, new ListItem("Seleccionar", "0"));
            parcoll par = new parcoll();
            DataView dv26 = new DataView(par.GetparTipoDiagnosticosPsicologico());
            ddl_TipoDiag.DataSource = dv26;
            ddl_TipoDiag.DataTextField = "Descripcion";
            ddl_TipoDiag.DataValueField = "CodTipoDiagnosticoPsi";
            dv26.Sort = "Descripcion";
            ddl_TipoDiag.DataBind();
            ddl_TipoTransMent.Items.Clear();
            ddl_TipoTransMent.Enabled = false;
            ddown001c.Items.Clear(); 
            ddown001c.Enabled = false;
            ddown002c.Items.Clear();        
            ddown002c.Enabled = false;*/
            //gfontbrevis
           // document.getElementById("CalDiagnostico").value = "";

            document.getElementById("ddown001c").value = "0";
            document.getElementById("ddown002c").value = "0";

            document.getElementById("ddown003c").value = "0";

            /*
            if (document.getElementById("chk001DrogaLRPA")) {
                document.getElementById("chk001DrogaLRPA").checked = false;
            }*/

            document.getElementById("txt002_wtc").value = "";
            document.getElementById("txt001c").value = "";
            document.getElementById("cal001c").value = "";

            
            document.getElementById("ddl_TipoDiag").style.background = "White";
            document.getElementById("ddown001c").style.background = "White";
            document.getElementById("ddown002c").style.background = "White";
            document.getElementById("ddown003c").style.background = "White";


            document.getElementById("txt002_wtc").style.background = "White";
            document.getElementById("txt001c").style.background = "White";
            document.getElementById("cal001c").style.background = "White";
            
        }

        

    </script>

</head>
<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="imb_002c" />
                <asp:AsyncPostBackTrigger ControlID="imb_003c" />
                <asp:AsyncPostBackTrigger ControlID="imb_004c" />
                <asp:AsyncPostBackTrigger ControlID="imb_005c" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_005c"
                    PopupControlID="modal_diagnostico_psicologico"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">

                    <%--<a id="collapse_diagPsicologico" runat="server" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="false" aria-controls="collapse_Form">
              <span id="icon-collapse" class="glyphicon glyphicon-minus" ></span>
              <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Pinche aqui para ocultar el formulario"></asp:label>
          </a>--%>

                   <h4> <label class="titulo-form">Diagnóstico Psicológico / Psiquiátrico</label></h4>



                    <div class="row">
                        <div class="col-md-12">

                            <asp:GridView ID="grd001c" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCommand="grd001c_RowCommand" Width="100%">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="ICodPsicologico" HeaderText="ICodPsicologico" />
                                    <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                    <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="CodTipoDiagnosticoPsi" HeaderText="Tipo Diagnostico" />
                                    <asp:BoundField DataField="DescMediciones" HeaderText="Instrumento de Diagnostico"></asp:BoundField>
                                    <asp:BoundField DataField="DescInstrumentoMedicion" HeaderText="Medici&#243;n Diagnostica"></asp:BoundField>
                                    <asp:BoundField DataField="CodTranstornoMental" HeaderText="Tipo Trastorno Mental" />
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="T&#233;cnico"></asp:BoundField>
                                    <asp:ButtonField Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
                                </Columns>
                            </asp:GridView>

                            <asp:Panel ID="lbl001cinfo" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no posee Diagnóstico Psicológico"></asp:Label>

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
                                <asp:Label ID="lbl001c" runat="server" CssClass="help-block" Width="100%"></asp:Label>
                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Fecha Diagnóstico *</th>
                                            <td class="col-md-4">
                                                
                                                            <asp:TextBox ID="cal001c" CssClass="form-control form-control-fecha-large input-sm" runat="server" OnTextChanged="cal001c_ValueChanged" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001c" ValidChars="0123456789-/" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende379" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001c" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                       
                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="cal001c" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" Display="Dynamic" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal001c" CssClass="help-block" ErrorMessage="Fecha Requerida" ValidationGroup="grupo1" Display="Dynamic" ></asp:RequiredFieldValidator>
                                                        
                                            </td>
                                        
                                            <th class="titulo-tabla col-md-1" scope="row">Tipo de Diagnóstico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddl_TipoDiag" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_TipoDiag_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Instrumento  Diagnóstico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001c" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown001c_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        
                                            <th class="titulo-tabla" scope="row">Medición Diagnóstica *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown002c" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown002c_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Transtorno Mental</th>
                                            <td>
                                                <asp:DropDownList ID="ddl_TipoTransMent" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                      
                                            <th class="titulo-tabla" scope="row">Valor medición</th>
                                            <td>
                                                <asp:TextBox ID="txt001c" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="3" ValidationGroup="grupo1" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt001c" ValidChars="0123456789" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003c" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Selecionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                       
                                            <th class="titulo-tabla" scope="row">Observaciones</th>
                                            <td>
                                                <asp:TextBox ID="txt002_wtc" CssClass="form-control input-sm" runat="server" MaxLength="100" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class="table">
                                <tr>
                                    <td>
                                        <div class="pull-right">

                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_002c" runat="server" OnClick="imb_002c_Click" ValidationGroup="grupo1">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_003c" runat="server" OnClick="imb_003c_Click" ValidationGroup="grupo1">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb_004c" runat="server" OnClick="imb_004c_Click" CausesValidation="False">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="imb_005c" runat="server" OnClientClick="return MostrarModalDiagnosticoPsicologico()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button">
                                                    <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                                                    <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <div class="popupConfirmation" id="modal_diagnostico_psicologico" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                                      <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">HISTORICO DIAGNOSTICO PSICOLOGICO/PSIQUIATRICO</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_diagnostico_psicologico" frameborder="0" runat="server"></iframe>
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
