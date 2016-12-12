<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiagnosticoSocial.aspx.cs" Inherits="mod_ninos_DiagnosticoSocial" %>

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
    <title>Diagnóstico Social</title>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function MostrarModalDiagnosticoSocial() {
            var objIframe = document.getElementById('iframe_diagnostico_social');
            if (objIframe.src == "") {
                objIframe.src = "../mod_ninos/ninos_HistoricoDiagnosticosocial.aspx?dir=DiagnosticoSocial.aspx";
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
            
            document.getElementById("ddown001d").value = "0";
            document.getElementById("ddown002d").value = "0";
            document.getElementById("ddown003d").value = "0";
            document.getElementById("ddown004d").value = "0";
            document.getElementById("ddown005d").value = "0";
            document.getElementById("ddown006d").value = "0";
            document.getElementById("ddown007d").value = "0";
            document.getElementById("ddown009d").value = "0";
            
            document.getElementById("ddown001d").style.background = "Empty";
            document.getElementById("ddown006d").style.background = "Empty";
            document.getElementById("ddown007d").style.background = "Empty";
            document.getElementById("ddown009d").style.background = "Empty";
            document.getElementById("ddown005d").style.background = "Empty";
            
            document.getElementById("txt001d").value = "";
            document.getElementById("txt002d").value = "";
            document.getElementById("txt003d").value = "";
            document.getElementById("txt004d").value = "";
            document.getElementById("txt005d").value = "";
            document.getElementById("txt006d").value = "";
            document.getElementById("txt007d").value = "";

            document.getElementById("cal001d").value = "";
            document.getElementById("cal002d").value = "";
            document.getElementById("cal003d").value = "";
            document.getElementById("cal004d").value = "";
            document.getElementById("cal005d").value = "";
           
            document.getElementById("cal001d").style.background = "Empty";
            document.getElementById("cal003d").style.background = "Empty";
            document.getElementById("cal004d").style.background = "Empty";
            document.getElementById("cal005d").style.background = "Empty";

            document.getElementById("chk001d").checked = false;
            document.getElementById("chk002d").checked = false;
            document.getElementById("chk003d").checked = false;
            
        }


        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#txt006d').on('input propertychange', function () {
                    max(txt006d);
                    CharLimit(this, 100);
                });


                
            });
        };

        function max(textbox) {
            total = 100;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado.innerHTML = str;
            Restante.innerHTML = total - str;

            if (tam > total) {
                //aux = PItxt002.value;
                //PItxt002.value = aux.substring(0, total);
                //Digitado.innerHTML = total
                Restante.innerHTML = 0
            }
        }

        function CharLimit(input, maxChar) {
            var len = $(input).val().length;
            var imb_001d = document.getElementById('imb_001d');
            var Digitado = document.getElementById('Digitado');
            var Label14 = document.getElementById('Label14');

            if (len > maxChar) {

                $("#divCaracteres").css({ display: "block" });
                imb_001d.setAttribute("disabled", true);

                Digitado.setAttribute("style", "color:red");
                Label14.setAttribute("style", "color:red");


                imb_001d
            }
            else {
                $("#divCaracteres").css({ display: "none" });
                imb_001d.removeAttribute("disabled");

                Digitado.setAttribute("style", "color:lead");
                Label14.setAttribute("style", "color:lead");
            }
        }



    </script>
</head>
<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="imb_001d" />
                <asp:AsyncPostBackTrigger ControlID="imb_002d" />
                <asp:AsyncPostBackTrigger ControlID="imb_003d" />
                <asp:AsyncPostBackTrigger ControlID="imb_004d" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_004d"
                    PopupControlID="modal_diagnostico_social"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>
                <div class="container">

                    <h4>
                        <label class="titulo-form">Diagnóstico Social</label></h4>

                    <asp:Label ID="lbl001d" runat="server" CssClass="help-block"></asp:Label>


                    <div class="row">
                        <div class="col-md-12">



                            <asp:GridView ID="grd001d" CssClass="table  table-bordered table-hover caja-tabla tabla-tabs" runat="server" AutoGenerateColumns="False" OnRowCommand="grd001d_RowCommand">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="ICodSocial" HeaderText="ICodSocial" />
                                    <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico "></asp:BoundField>
                                    <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="SituacionEspecial" HeaderText="Situaci&#243;n Especial"></asp:BoundField>
                                    <asp:BoundField DataField="SituacionCalle" HeaderText="Situaci&#243;n Calle"></asp:BoundField>
                                    <asp:BoundField DataField="EstadodeAbandono" HeaderText="Estado de Abandono"></asp:BoundField>
                                    <asp:BoundField DataField="SituacionTuicion" HeaderText="Situaci&#243;n Tuicion"></asp:BoundField>
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="T&#233;cnico"></asp:BoundField>
                                    <asp:ButtonField Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
                                </Columns>
                            </asp:GridView>



                            <asp:Panel ID="lbl001da" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no posee Diagnóstico Social"></asp:Label>

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
                            <%--<div>--%>

                                <div class="alert alert-warning text-center" color-text="green" role="alert" id="alertaEditar" runat="server" visible="false">
                                    <span class="glyphicon glyphicon-alert"></span>&nbsp;&nbsp;
                                    El menor posee menos de 12 años (Fecha nacimiento: <asp:Label ID="lblFechaNac" runat="server" Text=""></asp:Label>), por lo que 
                                    es posible que la Situación Especial seleccionada, sea errónea.
                                </div>

                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Fecha de Diagnóstico *</th>
                                            <td class="col-md-4">

                                                <asp:TextBox ID="cal001d" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001d" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende391" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001d" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal001d" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />

                                            </td>

                                            <th class="titulo-tabla col-md-1" scope="row">Situación Especial *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown001d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" 
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddown001d_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Situación SocioEconómica</th>
                                            <td>
                                                <asp:DropDownList ID="ddown002d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Situación Calle</th>
                                            <td>
                                                <asp:DropDownList ID="ddown003d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Mes y Año inicio vivir en la calle</th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddown004d" CssClass="form-control  input-sm" runat="server" AppendDataBoundItems="True">
                                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                <asp:ListItem Value="01">Enero</asp:ListItem>
                                                                <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                                <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                                                <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                                <asp:ListItem Value="06">Junio</asp:ListItem>
                                                                <asp:ListItem Value="07">Julio</asp:ListItem>
                                                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txt001d" CssClass=" form-control  input-sm pull-right" MaxLength="4" runat="server" placeholder="Año" OnTextChanged="txt001d_TextChanged" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt001d" ValidChars="0123456789" />
                                                            <asp:RangeValidator ID="rv_año" CssClass="help-block" runat="server" Display="Dynamic" ControlToValidate="txt001d" ErrorMessage=" Año fuera de rango" Type="Double" OnInit="rv_año_Init" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Número de personas en el hogar</th>
                                            <td>
                                                <asp:TextBox ID="txt002d" CssClass="form-control  input-sm" MaxLength="2" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt002d" ValidChars="0123456789" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Número de personas en el sitio</th>
                                            <td>
                                                <asp:TextBox ID="txt003d" CssClass="form-control  input-sm" MaxLength="2" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt003d" ValidChars="0123456789" />
                                            </td>

                                            <th class="titulo-tabla" scope="row">Número hermanos viven con él</th>
                                            <td>
                                                <asp:TextBox ID="txt004d" CssClass="form-control input-sm" MaxLength="2" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt004d" ValidChars="0123456789" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Número de hermanos</th>
                                            <td>
                                                <asp:TextBox ID="txt005d" CssClass="form-control  input-sm" MaxLength="2" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt005d" ValidChars="0123456789" />
                                            </td>

                                            <th class="titulo-tabla" scope="row">Puntaje Protección Social</th>
                                            <td>
                                                <asp:TextBox ID="txt007d" CssClass="form-control  input-sm" MaxLength="6" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txt007d" ValidChars="0123456789" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Fecha puntaje proteción Social</th>
                                            <td>

                                                <asp:TextBox ID="cal002d" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="cal002d" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende403" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002d" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal002d" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />

                                            </td>

                                            <th class="titulo-tabla" scope="row">Estado Abandono *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown006d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown006d_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Situación Tuición *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown007d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <th class="titulo-tabla" scope="row">Etnia *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown009d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">El niño(a) o adolecente se encuentra inscrito en:</th>
                                            <td colspan="3">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chk001d" runat="server" OnCheckedChanged="chk001d_CheckedChanged" Text="Fonasa " AutoPostBack="True" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="cal003d" CssClass="form-control form-control-fecha input-sm" runat="server" OnTextChanged="cal003d_ValueChanged" AutoPostBack="True" Enabled="False" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="cal003d" ValidChars="0123456789-/" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende416" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal003d" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal003d" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chk002d" runat="server" OnCheckedChanged="chk002d_CheckedChanged" Text="Chile Solidario " AutoPostBack="True" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="cal004d" CssClass="form-control form-control-fecha input-sm" runat="server" OnTextChanged="cal004d_ValueChanged" AutoPostBack="True" Enabled="False" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                            <ajax:CalendarExtender ID="CalendarExtende429" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal004d" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal004d" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />
                                                        </td>

                                                        <td>
                                                            <asp:CheckBox ID="chk003d" runat="server" OnCheckedChanged="chk003d_CheckedChanged" Text="Chile Crece Contigo " AutoPostBack="True" />

                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="cal005d" CssClass="form-control form-control-fecha input-sm" runat="server" OnTextChanged="cal005d_ValueChanged" AutoPostBack="True" Enabled="False" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende442" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal005d" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                            <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal005d" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        </tbody>
                                    </table>

                                <p id="pPaternidad" runat="server"  class="titulo-form">Antecedentes de paternidad adolescente</p>
                                <p id="pMaternidad" runat="server"  class="titulo-form">Antecedentes de maternidad adolescente</p>                                
                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr id="trEmbarazadarbtn" runat="server">
                                            <th class="titulo-tabla" scope="row">Adolescente embarazada</th>
                                            <td>                                                
                                                <asp:RadioButton ID="RbtnEmbarazadaSi" runat="server" GroupName="rbtnEmbarazada" OnCheckedChanged="RbtnEmbarazadaSi_CheckedChanged" Text="SI"  AutoPostBack="true" />&nbsp;
                                                <asp:RadioButton ID="RbtnEmbarazadaNo" runat="server" GroupName="rbtnEmbarazada" OnCheckedChanged="RbtnEmbarazadaNo_CheckedChanged" Text="NO" Checked="true"  AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr id="trEmbarazadaSi" runat="server"  visible ="false">
                                            <th class="titulo-tabla" scope="row">N° de semanas de gestación</th>
                                            <td>
                                                <asp:TextBox ID="txtNumeroSemanasGestacion" CssClass="form-control  input-sm" MaxLength="2" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FTENumeroSemanasGestacion" runat="server" TargetControlID="txtNumeroSemanasGestacion" ValidChars="0123456789" />
                                                <asp:RangeValidator runat="server" ID="RVNumeroSemanasGestacion" ControlToValidate="txtNumeroSemanasGestacion" Type="Double" MinimumValue="1" MaximumValue="42" ErrorMessage="Valor ingresado inválido" ValidationGroup="grupo1"></asp:RangeValidator>
                                            </td>
                                            <th class="titulo-tabla" scope="row">Embarazo producto de abuso sexual o violación</th>
                                            <td>
                                                <asp:RadioButton ID="rbtnEmbarazoAbusoViolacionSi" runat="server" GroupName="rbtnAbusoViolacion" Text="SI" AutoPostBack="true" />&nbsp;
                                                <asp:RadioButton ID="rbtnEmbarazoAbusoViolacionNo" runat="server" GroupName="rbtnAbusoViolacion" Text="NO" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th id="thAdolescentePadre" runat="server" class="titulo-tabla" scope="row">Adolescente padre</th>
                                            <th id="thAdolescenteMadre" runat="server" class="titulo-tabla" scope="row">Adolescente madre</th>
                                            <td>
                                                <asp:RadioButton ID="rbtnAdolescentePadreMadreSi" runat="server" OnCheckedChanged="rbtnAdolescentePadreMadreSi_CheckedChanged" GroupName="rbtnAdolescentePadreMadre" Text="SI" AutoPostBack="true" />&nbsp;
                                                <asp:RadioButton ID="rbtnAdolescentePadreMadreNo" runat="server" OnCheckedChanged="rbtnAdolescentePadreMadreNo_CheckedChanged" GroupName="rbtnAdolescentePadreMadre" Text="NO" Checked="true" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr id="trPadreMadre" runat="server" visible ="false">
                                            <th class="titulo-tabla" scope="row">N° de hijos/as</th>
                                            <td>
                                                <asp:TextBox ID="txtNumeroHijos" CssClass="form-control  input-sm" MaxLength="2" runat="server" placeholder="Ingresar" />
                                                <ajax:FilteredTextBoxExtender ID="FTENumeroHijos" runat="server" TargetControlID="txtNumeroHijos" ValidChars="0123456789" />
                                            </td>
                                            <th class="titulo-tabla" scope="row">Hijos/as producto de abuso sexual o violación</th>
                                            <td>
                                                <asp:RadioButton ID="rbtnHijosViolacionSi" runat="server" GroupName="rbtnHijosViolacion" Text="SI" AutoPostBack="true" />&nbsp;
                                                <asp:RadioButton ID="rbtnHijosViolacionNo" runat="server" GroupName="rbtnHijosViolacion" Text="NO" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        </tbody>
                                    </table>
                                <table class="table table-bordered  table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown005d" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Observaciones</th>
                                            <td>
                                                <asp:TextBox ID="txt006d" TextMode="MultiLine" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                                <asp:Label ID="lblNumeroMaximo" runat="server" Text="Máximo 100 caracteres:"></asp:Label>
                                                <asp:Label ID="lblEscritos" runat="server" Text="Escritos"></asp:Label>
                                                <asp:Label ID="Digitado" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                                <asp:Label ID="lblRestantes" runat="server" Text="Restantes"></asp:Label>
                                                <asp:Label ID="Restante" runat="server" Text="100"></asp:Label>

                                                <div class="alert alert-warning text-center" role="alert" id="divCaracteres" runat="server" style="display: none">
                                                    <span class="glyphicon glyphicon-warning-sign"></span>
                                                    <asp:Label ID="lblbmsg" runat="server" Text="Se han sobrepasado el límite de 100 caracteres"></asp:Label>
                                                </div>

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_001d" runat="server" ValidationGroup="grupo1" OnClick="imb_001d_Click" AutoPostback="true">
                  <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_002d" runat="server" OnClick="imb_002d_Click" ValidationGroup="grupo1" AutoPostback="true">
                  <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb_003d" runat="server" OnClick="imb_003d_Click" CausesValidation="False" AutoPostback="true">
                  <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="imb_004d" runat="server" OnClientClick="return MostrarModalDiagnosticoSocial()" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button">
                  <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Histórico
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button" OnClientClick="return mostrarBotonAgregar()">
                  <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                    </asp:LinkButton>

                                    <div class="popupConfirmation" id="modal_diagnostico_social" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton CssClass="close" aria-label="Close" ID="btnCerrarModal1" runat="server" CausesValidation="false">
                              <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">HISTORICO DIAGNOSTICO SOCIAL</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_diagnostico_social" frameborder="0" runat="server"></iframe>
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
