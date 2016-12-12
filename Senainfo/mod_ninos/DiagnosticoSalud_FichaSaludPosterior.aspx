<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiagnosticoSalud_FichaSaludPosterior.aspx.cs" Inherits="mod_ninos_DiagnosticoSalud_FichaSaludPosterior" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>

<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Ficha de salud (Atención Posterior)</title>

    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">   

    <style>
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
          padding: 5px;
          line-height: 1.42857143;
          vertical-align: middle;
          border-top: 1px solid #dddddd;
}
    </style>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {                
                $('#txtDiagnosticoMedicoIngreso').on('input propertychange', function () {
                    max(txtDiagnosticoMedicoIngreso);                    
                });

                $('#txtMotivoConsulta').on('input propertychange', function () {
                    max2(txtMotivoConsulta);                    
                });

                $('#txtExamenFisico').on('input propertychange', function () {
                    max3(txtExamenFisico);
                });

                $('#txtDiagnosticoEgreso').on('input propertychange', function () {
                    max4(txtDiagnosticoEgreso);
                });

                $('#txtTratamiento').on('input propertychange', function () {
                    max5(txtTratamiento);
                });

                $('#txtDerivacion').on('input propertychange', function () {
                    max6(txtDerivacion);
                });
                
            });
        };

        function max(textbox) {
            total = 140;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado.innerHTML = str;
            Restante.innerHTML = total - str;

            if (tam > total) {                
                Restante.innerHTML = 0
            }
        }
        function max2(textbox) {
            total = 140;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado2.innerHTML = str;
            Restante2.innerHTML = total - str;

            if (tam > total) {
                Restante2.innerHTML = 0
            }
        }
        function max3(textbox) {
            total = 140;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado3.innerHTML = str;
            Restante3.innerHTML = total - str;

            if (tam > total) {
                Restante3.innerHTML = 0
            }
        }

        function max4(textbox) {
            total = 140;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado4.innerHTML = str;
            Restante4.innerHTML = total - str;

            if (tam > total) {
                Restante4.innerHTML = 0
            }
        }

        function max5(textbox) {
            total = 250;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado5.innerHTML = str;
            Restante5.innerHTML = total - str;

            if (tam > total) {
                Restante5.innerHTML = 0
            }
        }

        function max6(textbox) {
            total = 250;
            tam = textbox.value.length;
            str = "";
            str = str + tam;
            Digitado6.innerHTML = str;
            Restante6.innerHTML = total - str;

            if (tam > total) {
                Restante6.innerHTML = 0
            }
        }

        
    </script>

    <style>
        .avoid-clicks
        {
            pointer-events: none;
        }

        .body-form-salud
        {
            padding-top: 5px;
            padding-bottom: 10px;
            margin-bottom: 0px;
            background-color: #fff;
        }
        
    </style>
</head>
<body class="body-form-salud well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkGuardarFichaPosterior" />
            </Triggers>
            <ContentTemplate>
                <hr />
                <div class="alert alert-warning text-center" role="alert" id="divAlertaSinDiagnosticoInicial" visible="false" runat="server">
                    <asp:Label ID="lblAlertaSinDiagnosticoInicial" CssClass="subtitulo-form-info" runat="server" Text="Primero debe realizar la ficha de Salud Inicial. "></asp:Label>
                </div>
                <div class="alert alert-warning text-center" role="alert" id="divAlertaSinDiagnostiposterior" visible="false" runat="server">
                    <asp:Label ID="lblAlertaSinDiagnostiposterior" CssClass="subtitulo-form-info" runat="server" Text="No existen registros de ficha de salud posterior. "></asp:Label>
                </div>
                <div class="row" id="GrillaFichaPosterior" runat="server" visible="false">
                    <asp:GridView ID="grdFichaPosterior" CssClass="table table table-bordered table-hover caja-tabla text-center" runat="server" AllowPaging="False" Visible="False" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowCommand="grdFichaPosterior_RowCommand" Width="100%">
                        <HeaderStyle CssClass="titulo-tabla" />
                        <Columns>
                            <asp:BoundField DataField="CodFichaSaludPosterior" HeaderText="Codigo Ficha Posterior"></asp:BoundField>
                            <%--<asp:BoundField DataField="NIdentificacion" HeaderText="N° Identificación"></asp:BoundField>--%>
                            <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnóstico"></asp:BoundField>
                            <asp:BoundField DataField="FechaIngresoFichaPosterior" DataFormatString="{0:d}" HeaderText="Fecha Ingreso de Ficha"></asp:BoundField>
                            <asp:ButtonField Text="Ver" CommandName="MODIFICAR"></asp:ButtonField>
                            <asp:ButtonField Text="Modificar" CommandName="MODIFICAR"></asp:ButtonField>
                        </Columns>
                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                    </asp:GridView>
                </div>
                <div class="row" id="DatosFichaPosterior" runat="server" visible="false">

                    <img src="../images/BannerFichaSaludPosterior.jpg" class="img-responsive" alt="Cinque Terre">
                    <table class="table table-bordered table-condensed">
                        <tbody>
                            <tr>
                                <th class="titulo-tabla col-md-1" scope="row">N° Identificación</th>
                                <td>
                                    <asp:TextBox ID="txtNIdentificacion" runat="server" CssClass="form-control input-sm avoid-clicks" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla" scope="row">Fecha de Diagnóstico *</th>
                                <td>
                                    <asp:TextBox ID="txtFechaDiagnostico" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" AutoPostBack="true" />
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFechaDiagnostico" ValidChars="0123456789-/" />
                                    <ajax:CalendarExtender ID="CalendarExtende353" FirstDayOfWeek="Monday" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaDiagnostico" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fecha Invalida" ValidationGroup="fichaposterior" ControlToValidate="txtFechaDiagnostico" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />

                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div id="tdHorasRestantes" visible="false" runat="server" class="alert alert-success text-center">
                                        <asp:Label ID="lblHorasRestantes" CssClass="subtitulo-form-info" runat="server" Text="Tiempo Restante Para Ser Modificada la Ficha de Salud Posterior: "></asp:Label>
                                        <div id="countdownDiagPosterior" runat="server" class="subtitulo-form-info"></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                 <td colspan="4">
                                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Faltan Campos Obligatorios. "></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                        <table id="tblTituloDatosPersonales" class="table table-bordered table-condensed">
                            <tr class="titulo-form-fichasalud">
                                <td colspan="8" style="text-align: center;">
                                    <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                        <label>Datos Personales </label><span id="icon-collapse" class="glyphicon glyphicon-triangle-bottom"></span>
                                    </h4>
                                </td>
                            </tr>
                        </table>
                    </a>
                    <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                        <table class="table table-bordered table-condensed">
                            <tbody>                                                           
                                
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Primer Apellido</th>
                                    <td>
                                        <asp:TextBox ID="txtPrimerApellido" Enabled="false" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Segundo Apellido</th>
                                    <td>
                                        <asp:TextBox ID="txtSegundoApellido" Enabled="false" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Nombre</th>
                                    <td>
                                        <asp:TextBox ID="txtNombre" Enabled="false" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">RUN</th>
                                    <td>
                                        <asp:TextBox ID="txtRut" Enabled="false" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Fecha de Nacimiento</th>
                                    <td>
                                        <asp:TextBox ID="txtFechaNacimiento" Enabled="false" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FTE3" runat="server" TargetControlID="txtFechaNacimiento" ValidChars="0123456789-/" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaNacimiento" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                    </td>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Edad</th>
                                    <td>
                                        <asp:TextBox ID="txtEdad" Enabled="false" runat="server" CssClass="form-control input-sm" p></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Fecha Ingreso</th>
                                    <td>
                                        <asp:TextBox ID="txtFechaIngreso" Enabled="false" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFechaIngreso" ValidChars="0123456789-/" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende391" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaIngreso" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <table id="tblTituloAnamnesis" class="table table-bordered table-condensed">
                        <tr class="titulo-form-fichasalud">
                            <td colspan="8" style="text-align: center;">
                                <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                    <label>Anamnesis Remota </label>
                                </h4>
                            </td>
                        </tr>
                    </table>

                    <table id="tblDatosFichaPosterior" class="table table-bordered table-condensed">
                        <tbody>                           
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Diagnóstico Médico del Ingreso</th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDiagnosticoMedicoIngreso" MaxLength="140" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:Label ID="lblNumeroMaximo" runat="server" Text="Máximo 140 caracteres:"></asp:Label>
                                    <asp:Label ID="lblEscritos" runat="server" Text="Escritos"></asp:Label>
                                    <asp:Label ID="Digitado" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblRestantes" runat="server" Text="Restantes"></asp:Label>
                                    <asp:Label ID="Restante" runat="server" Text="140"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Motivo de Consulta</th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtMotivoConsulta" MaxLength="140" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:Label ID="lblNumeroMaximo2" runat="server" Text="Máximo 140 caracteres:"></asp:Label>
                                    <asp:Label ID="lblEscritos2" runat="server" Text="Escritos"></asp:Label>
                                    <asp:Label ID="Digitado2" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblRestantes2" runat="server" Text="Restantes"></asp:Label>
                                    <asp:Label ID="Restante2" runat="server" Text="140"></asp:Label>
                                </td>
                            </tr>
                            <tr><td colspan="4"></td></tr>
                            <tr><td colspan="4"></td></tr>                      
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Riña</th>
                                <td>
                                    <asp:RadioButton ID="rbtnRinaSi" runat="server" GroupName="rbtnRina" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnRinaNo" runat="server" GroupName="rbtnRina" Text="No" AutoPostBack="true" />
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Trastornos del Sueño</th>
                                <td>
                                    <asp:RadioButton ID="rbtnTrastornoSuenoSi" runat="server" GroupName="rbtnTrastornoSueno" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnTrastornoSuenoNo" runat="server" GroupName="rbtnTrastornoSueno" Text="No" AutoPostBack="true" />
                                </td>
                                </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Autoagresión</th>
                                <td>
                                    <asp:RadioButton ID="rbtnAutoagresionSi" runat="server" GroupName="rbtnAutoagresion" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnAutoagresionNo" runat="server" GroupName="rbtnAutoagresion" Text="No" AutoPostBack="true" />
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Algia Bucal</th>
                                <td>
                                    <asp:RadioButton ID="rbtnAlgiaBucalSi" runat="server" GroupName="rbtnAlgiaBucal" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnAlgiaBucalNo" runat="server" GroupName="rbtnAlgiaBucal" Text="No" AutoPostBack="true" />
                                </td>
                                </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Ideación Suicida</th>
                                <td>
                                    <asp:RadioButton ID="rbtnIntentoSuicidioSi" runat="server" GroupName="rbtnIntentoSuicidio" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnIntentoSuicidioNo" runat="server" GroupName="rbtnIntentoSuicidio" Text="No" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr><td colspan="4"></td></tr>
                            <tr><td colspan="4"></td></tr>   
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">PA</th>
                                <td>
                                    <asp:DropDownList ID="ddlPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Pulso</th>
                                <td>
                                    <asp:DropDownList ID="ddlPulso" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">FR</th>
                                <td>
                                    <asp:DropDownList ID="ddlFR" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">T°</th>
                                <td>
                                    <asp:DropDownList ID="ddlTemperatura" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td colspan="4"></td></tr>
                            <tr><td colspan="4"></td></tr>   
                            <tr>
                                <td colspan="4">
                                    <label class="subtitulo-form">Estado de Conciencia</label>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Tranquilo</th>
                                <td>
                                    <asp:RadioButton ID="rbtnTranquiloSi" runat="server" GroupName="rbtnTranquilo" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnTranquiloNo" runat="server" GroupName="rbtnTranquilo" Text="No" AutoPostBack="true" />
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Excitado</th>
                                <td>
                                    <asp:RadioButton ID="rbtnExcitadoSi" runat="server" GroupName="rbtnExcitado" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnExcitadoNo" runat="server" GroupName="rbtnExcitado" Text="No" AutoPostBack="true" />
                                </td>
                                </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Angustiado</th>
                                <td>
                                    <asp:RadioButton ID="rbtnAngustiadoSi" runat="server" GroupName="rbtnAngustiado" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnAngustiadoNo" runat="server" GroupName="rbtnAngustiado" Text="No" AutoPostBack="true" />
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Decaído</th>
                                <td>
                                    <asp:RadioButton ID="rbtnDecaidoSi" runat="server" GroupName="rbtnDecaido" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnDecaidoNo" runat="server" GroupName="rbtnDecaido" Text="No" AutoPostBack="true" />
                                </td>
                                </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Irritable</th>
                                <td>
                                    <asp:RadioButton ID="rbtnIrritableSi" runat="server" GroupName="rbtnIrritable" Text="Si" AutoPostBack="true" />&nbsp;
                                    <asp:RadioButton ID="rbtnIrritableNo" runat="server" GroupName="rbtnIrritable" Text="No" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr><td colspan="4"></td></tr>
                            <tr><td colspan="4"></td></tr>   
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Examen Físico</th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtExamenFisico" MaxLength="140" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:Label ID="lblNumeroMaximo3" runat="server" Text="Máximo 140 caracteres:"></asp:Label>
                                    <asp:Label ID="lblEscritos3" runat="server" Text="Escritos"></asp:Label>
                                    <asp:Label ID="Digitado3" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblRestantes3" runat="server" Text="Restantes"></asp:Label>
                                    <asp:Label ID="Restante3" runat="server" Text="140"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Diagnóstico de Egreso</th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDiagnosticoEgreso" MaxLength="140" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:Label ID="lblNumeroMaximo4" runat="server" Text="Máximo 140 caracteres:"></asp:Label>
                                    <asp:Label ID="lblEscritos4" runat="server" Text="Escritos"></asp:Label>
                                    <asp:Label ID="Digitado4" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblRestantes4" runat="server" Text="Restantes"></asp:Label>
                                    <asp:Label ID="Restante4" runat="server" Text="140"></asp:Label>
                                </td>
                                <tr>
                                    <th class="titulo-tabla col-md-ficha" scope="row">Tratamiento</th>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtTratamiento" MaxLength="250" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                        <asp:Label ID="lblNumeroMaximo5" runat="server" Text="Máximo 250 caracteres:"></asp:Label>
                                        <asp:Label ID="lblEscritos5" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="Digitado5" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblRestantes5" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="Restante5" runat="server" Text="250"></asp:Label>
                                    </td>
                                </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Derivación</th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDerivacion" MaxLength="250" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <asp:Label ID="lblNumeroMaximo6" runat="server" Text="Máximo 250 caracteres:"></asp:Label>
                                    <asp:Label ID="lblEscritos6" runat="server" Text="Escritos"></asp:Label>
                                    <asp:Label ID="Digitado6" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="lblRestantes6" runat="server" Text="Restantes"></asp:Label>
                                    <asp:Label ID="Restante6" runat="server" Text="250"></asp:Label>
                                </td>
                            </tr>
                    </table>
                    <div class="botonera pull-right">
                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnkGuardarFichaPosterior" Visible="false" OnClick="lnkGuardarFichaPosterior_Click" ValidationGroup="fichaposterior" CausesValidation="true" runat="server" AutoPostback="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnCancelar" runat="server" Visible="false" CssClass="btn btn-primary btn-sm fixed-width-button pull-right" OnClick="btnCancelar_Click" CausesValidation="false">
                         <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                        </asp:LinkButton>
                    </div>
                </div>
                <div>
                    <asp:LinkButton ID="btnGatillo" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button pull-right" OnClick="btnGatillo_Click" CausesValidation="false">
                         <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Ficha
                    </asp:LinkButton>

                </div>
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
</html>
