<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="~/mod_instituciones/reg_instituciones.aspx.cs" Inherits="mod_institucion_reg_instituciones2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Instituciones :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery.Rut.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">


        function MostrarModalTransferencia() {
            var objIframe = document.getElementById('iframe_transferencia');
            limpiaiframe(objIframe);
            var uno = document.getElementById('txt0029');
            var dos = document.getElementById('txt001');

            objIframe.src = "../mod_instituciones/Transferencias.aspx?param001=" + uno.value + "&param002=" + dos.value + "&dir=reg_instituciones.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe2a").show();
            return false;
        }

        
        function pageLoad(sender, args) {
            $(function () {
                $("#txtRutInstitucion").Rut({
                    format_on: 'keyup',
                    on_error: function () {
                        alert("El rut es incorrecto, vuelva a ingresarlo");
                        $("#txtRutInstitucion").val("");
                    }
                });


                $("#txtRutRepLegal").Rut({
                    format_on: 'keyup',
                    on_error: function () {
                        alert("El rut es incorrecto, vuelva a ingresarlo");
                        $("#txtRutRepLegal").val("");
                    }
                });

            });
        }


        function LoadScript() {
            $(function () {
                $("#txtRutInstitucion").Rut({
                    format_on: 'keyup, focus',
                    on_error: function () {
                        alert("El rut es incorrecto, vuelva a ingresarlo");
                        $("#txtRutInstitucion").val("");
                    },
                });
                

                $("#txtRutRepLegal").Rut({
                    format_on: 'keyup, focus',
                    on_error: function () {
                        alert("El rut es incorrecto, vuelva a ingresarlo");
                        $("#txtRutRepLegal").val("");
                    },
                });

            });
        }


        //$(function () {
        //    $("#txtFecDocReconoce").datepicker({
        //        changeMonth: true,
        //        changeYear: true
        //    });
        //});
        //$(function () {
        //    $("#txtFecIngreso").datepicker({
        //        changeMonth: true,
        //        changeYear: true
        //    });
        //});


    </script>

</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGrabar" />
                <asp:PostBackTrigger ControlID="btnActualizar" />

            </Triggers>
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(LoadScript);
                </script>

                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="lbn_buscar_institucion"
                    PopupControlID="modal_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_institucion">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="mpe2"
                    BehaviorID="mpe2a"
                    runat="server"
                    TargetControlID="lbn_buscar_transferencia"
                    PopupControlID="modal_transferencia"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_transferencia">
                </ajax:ModalPopupExtender>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Instituciones</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos de Institución guardados satisfactoriamente." Visible="false"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Institución</h4>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <asp:Label ID="lbl001" runat="server" Text="Instituciones" Visible="false"></asp:Label>
                                    <div class="popupConfirmation" id="modal_institucion" style="display: none">
                                        <div class="modal-header header-modal">
                                            <asp:LinkButton ID="lnb_close_buscar_institucion" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                            </asp:LinkButton>
                                            <h4 class="modal-title">BUSCAR INSTITUCION</h4>
                                        </div>
                                        <div>
                                            <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                        </div>
                                    </div>
                                </div>
                                <table class="table table-bordered  table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Código Institución *</th>
                                        <td class="col-md-4">
                                            <div class="input-group">
                                                <asp:TextBox ID="txt0029" runat="server" OnTextChanged="txt0029_TextChanged" CssClass="form-control input-sm" ReadOnly="true" placeholder="Busque código; + para generar nuevo"></asp:TextBox>
                                                <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" title="Buscar código de Institución existente" OnClientClick="return MostrarModalInstitucion('Instituciones','reg_instituciones.aspx','mpe1a')">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="nuevoCodigo" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClick="nuevoCodigo_Click" title="Proponer Nuevo Codigo">
                                                    <span class="glyphicon glyphicon-plus"></span>
                                                </asp:LinkButton>


                                            </div>
                                            <asp:Panel ID="pnl001" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px" Height="1px" Visible="False" Width="250px" HorizontalAlign="Center">
                                                <asp:Label ID="lbl003" runat="server"></asp:Label>&nbsp;<br />
                                                <asp:Button ID="btnSugerir" runat="server" BackColor="LightSkyBlue" BorderStyle="Outset" BorderWidth="2px" Font-Bold="True" Font-Size="9pt" ForeColor="DarkBlue" Height="26px" OnClick="btnSugerir_NEW_Click" Text="Sugerir" Width="90px" />
                                                <asp:Button ID="btnMantener" runat="server" BackColor="LightSkyBlue" BorderStyle="Outset" BorderWidth="2px" Font-Bold="True" Font-Size="9pt" ForeColor="DarkBlue" Height="26px" OnClick="btnMantener_NEW_Click" Text="Mantener" Width="90px" Visible="False" />
                                            </asp:Panel>
                                        </td>

                                        <th class="titulo-tabla col-md-1" scope="row">Rut Institución *</th>
                                        <td>
                                            <asp:TextBox ID="txtRutInstitucion" runat="server" MaxLength="12" AutoPostBack="True" OnTextChanged="txtRutInstitucion_TextChanged" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:Panel ID="pnl002" runat="server" Visible="False">
                                                <asp:Label ID="lbl002" runat="server"></asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Nombre Institución (Razón Social) *</th>
                                        <td>
                                            <asp:TextBox ID="txt001" runat="server" MaxLength="100" Style="text-transform: uppercase" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Nombre Corto</th>
                                        <td>
                                            <asp:TextBox ID="txt003" runat="server" MaxLength="50" Style="text-transform: uppercase" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Representante Legal *</th>
                                        <td>
                                            <asp:TextBox ID="txt004" runat="server" MaxLength="100" Style="text-transform: uppercase" CssClass="form-control input-sm"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt004" runat="server" TargetControlID="txt004" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü- " BehaviorID="_content_txt004" />

                                        </td>

                                        <th class="titulo-tabla" scope="row">Rut Representante Legal *</th>
                                        <td>
                                            <asp:TextBox ID="txtRutRepLegal" runat="server" AutoPostBack="True" MaxLength="12" OnTextChanged="txtRutRepLegal_TextChanged" Style="text-transform: uppercase" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:Panel ID="pnl003" runat="server" Visible="False">
                                                <asp:Label ID="lbl004" runat="server"></asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <h4 class="subtitulo-form">Dirección</h4>
                                <table class="table table-bordered  table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Dirección *</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txt006" runat="server" MaxLength="100" Style="text-transform: uppercase" CssClass="form-control input-sm"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt006" runat="server" TargetControlID="txt006" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü0123456789°/- " BehaviorID="_content_txt006" />
                                        </td>

                                        <th class="titulo-tabla col-md-1" scope="row">Región *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown002" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Comuna *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown003" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Código Postal</th>
                                        <td>
                                            <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="7" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rev_txtCodigoPostal" ControlToValidate="txtCodigoPostal" runat="server" ErrorMessage="Ingrese Solo Números" CssClass="help-block" Display="Dynamic" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Teléfono</th>
                                        <td>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="12" CssClass="form-control input-sm"></asp:TextBox>
                                                <label class="input-group-addon-telefono">Fax</label>
                                                <asp:TextBox ID="txtFax" runat="server" MaxLength="12" CssClass="form-control input-sm"></asp:TextBox>
                                            </div>
                                            <ajax:FilteredTextBoxExtender runat="server" ID="fte_txtTelefono" TargetControlID="txtTelefono" ValidChars="1234567890-" />
                                            <ajax:FilteredTextBoxExtender runat="server" ID="fte_txtFax" TargetControlID="txtFax" ValidChars="1234567890-" />
                                            <%--<asp:RegularExpressionValidator ID="rev_txtTelefono" ControlToValidate="txtTelefono" runat="server" ErrorMessage="Ingrese Solo Números" CssClass="help-block" Display="Dynamic" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>--%>
                                            <%--<asp:RegularExpressionValidator ID="rev_txtFax" ControlToValidate="txtFax" runat="server" ErrorMessage="Ingrese Solo Números" CssClass="help-block" Display="Dynamic" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>--%>

                                        </td>

                                        <th class="titulo-tabla" scope="row">E-Mail *</th>
                                        <td>
                                            <asp:TextBox ID="txt0010" runat="server" MaxLength="100" Style="text-transform: uppercase" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rev_txt0010" ControlToValidate="txt0010" runat="server" ErrorMessage="Correo inv&aacute;lido" CssClass="help-block" Display="Dynamic" ValidationExpression="^[_a-z0-9-_A-Z0-9-]+(\.[_a-z0-9-_A-Z0-9-]+)*@[a-z0-9-A-Z0-9-]+(\.[a-z0-9-A-Z0-9-]+)*(\.[a-zA-Z]{2,3})$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                                <h4 class="subtitulo-form">Constitución y Registro</h4>
                                <table class="table table-bordered  table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Datos de Constitución</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txtDatosConstitucion" runat="server" MaxLength="200" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla col-md-1" scope="row">Nº Decreto que concede *</th>
                                        <td>
                                            <asp:TextBox ID="txtDecreto" runat="server" MaxLength="200" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Tipo Institución *</th>
                                        <td>
                                            <asp:DropDownList ID="dd0012" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Objeto Social</th>
                                        <td>
                                            <asp:TextBox ID="txtObjetoSocial" runat="server" MaxLength="300" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Vigencia</th>
                                        <td>
                                            <asp:TextBox ID="txtVigencia" runat="server" MaxLength="200" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Area de Especialización *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown005" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Modo Institucion *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="A">ADMINISTRACION DIRECTA</asp:ListItem>
                                                <asp:ListItem Value="Y">COADYUVANTE</asp:ListItem>
                                                <asp:ListItem Value="C">COLABORADORA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Tipo de Reconocimiento *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown007" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                <asp:ListItem Value="2">No</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Documento que la Reconoce *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown008" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="C">OFICIO</asp:ListItem>
                                                <asp:ListItem Value="R">RESOLUCION EXCENTA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Nº Documento que la Reconoce *</th>
                                        <td>
                                            <asp:TextBox ID="txtDoctoReconoce" runat="server" MaxLength="200" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Fecha Documento que la Reconoce *</th>
                                        <td>
                                            <asp:TextBox ID="txtFecDocReconoce" runat="server" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="ce_txtFecDocReconoce" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txtFecDocReconoce" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="rev_txtFecDocReconoce" Enabled="true" ControlToValidate="txtFecDocReconoce" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        </td>

                                        <th class="titulo-tabla" scope="row">Fecha de Ingreso al Registro</th>
                                        <td>
                                            <asp:TextBox ID="txtFecIngreso" runat="server" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="ce_txtFecIngreso" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txtFecIngreso" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="rev_txtFecIngreso" Enabled="true" ControlToValidate="txtFecIngreso" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        </td>

                                    </tr>
                                </table>
                                <h4 class="subtitulo-form">Datos Institucionales</h4>
                                <table class="table table-bordered  table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Personería</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txtPersoneria" runat="server" MaxLength="200" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla col-md-1" scope="row">Directorio</th>
                                        <td class="text-center">
                                            <asp:CheckBox ID="chk001" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>

                                        <th class="titulo-tabla" scope="row">Miembros del Directorio</th>
                                        <td>
                                            <asp:TextBox ID="txtMiembrosDirectorio" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txtMiembrosDirectorio" runat="server" TargetControlID="txtMiembrosDirectorio" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü-, " BehaviorID="_content_txtMiembrosDirectorio" />
                                        </td>

                                        <th class="titulo-tabla" scope="row">Certificado de Antecedentes</th>
                                        <td>
                                            <asp:TextBox ID="txtCertifAntecedentes" runat="server" MaxLength="200" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Antecedentes Financieros</th>
                                        <td>
                                            <asp:TextBox ID="txtAntecedFinancieros" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Marco Legal</th>
                                        <td>
                                            <asp:TextBox ID="txtMarcoLegal" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Objeto de Transferencia</th>
                                        <td>
                                            <asp:TextBox ID="txtObjTransferencia" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Trabajos Encargados</th>
                                        <td>
                                            <asp:TextBox ID="txtTrabajosEncargados" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Organismo Contralor</th>
                                        <td>
                                            <asp:TextBox ID="txtOrganismoContralor" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Resultado de Evaluación</th>
                                        <td>
                                            <asp:TextBox ID="txtResultEvaluacion" runat="server" MaxLength="300" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Transferencias</th>
                                        <td class="text-center">
                                            <div class="popupConfirmation" id="modal_transferencia" style="display: none">
                                                <div class="modal-header header-modal">
                                                    <asp:LinkButton ID="lnb_close_buscar_transferencia" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                                    </asp:LinkButton>
                                                    <h4 class="modal-title">TRANSFERENCIAS</h4>
                                                </div>
                                                <div>
                                                    <iframe id="iframe_transferencia" runat="server" frameborder="0"></iframe>
                                                </div>
                                            </div>

                                            <asp:LinkButton ID="lbn_buscar_transferencia" runat="server" disabled="disabled" CssClass=" btn btn-info btn-sm" OnClientClick="return MostrarModalTransferencia()" Enabled="false">
                                                <span class="glyphicon glyphicon-share"></span>
                                            </asp:LinkButton>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Persona de Contacto</th>
                                        <td>
                                            <asp:TextBox ID="txt0025" runat="server" MaxLength="100" CssClass="form-control input-sm"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt0025" runat="server" TargetControlID="txt0025" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü- " BehaviorID="_content_txt0025" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Mes y Día de Aniversario</th>
                                        <td>
                                            <div class="input-group">
                                                <span class="input-group-addon-telefono" id="basic-addon-anio">Día</span>
                                                <asp:TextBox ID="txtDia" runat="server" CssClass="form-control input-sm" MaxLength="2" OnTextChanged="txtDia_TextChanged"></asp:TextBox>
                                                <span class="input-group-addon-telefono" id="basic-addon-mes">Mes</span>
                                                <asp:DropDownList ID="ddown0010" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    <asp:ListItem Value="1">ENERO</asp:ListItem>
                                                    <asp:ListItem Value="2">FEBRERO</asp:ListItem>
                                                    <asp:ListItem Value="3">MARZO</asp:ListItem>
                                                    <asp:ListItem Value="4">ABRIL</asp:ListItem>
                                                    <asp:ListItem Value="5">MAYO</asp:ListItem>
                                                    <asp:ListItem Value="6">JUNIO</asp:ListItem>
                                                    <asp:ListItem Value="7">JULIO</asp:ListItem>
                                                    <asp:ListItem Value="8">AGOSTO</asp:ListItem>
                                                    <asp:ListItem Value="9">SEPTIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>




                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtDia" ValidChars="0123456789" BehaviorID="FilteredTextBoxExtender1" />
                                            <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Día invalido" ControlToValidate="txtDia" MinimumValue="01" MaximumValue="31" Type="Integer" />

                                        </td>

                                        <th class="titulo-tabla" scope="row">Nombre Primera Autoridad</th>
                                        <td>
                                            <asp:TextBox ID="txt0026" runat="server" MaxLength="100" CssClass="form-control input-sm"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt0026" runat="server" TargetControlID="txt0026" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü- " BehaviorID="_content_txt0026" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Cargo Primera Autoridad</th>
                                        <td>
                                            <asp:TextBox ID="txt0027" runat="server" MaxLength="100" CssClass="form-control input-sm"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="ftbe_txt0027" runat="server" TargetControlID="txt0027" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü- " BehaviorID="_content_txt0027" />
                                        </td>

                                        <th class="titulo-tabla" scope="row">Estado *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown0011" runat="server" Enabled="False" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="V">Vigente</asp:ListItem>
                                                <asp:ListItem Value="C">Caducado</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                </table>
                                <div class="text-right">
                                    <asp:LinkButton ID="btnActualizar" runat="server" OnClick="btnActualizar_NEW_Click" Visible="False" CssClass="btn btn-danger btn-sm fixed-width-button">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnGrabar" runat="server" OnClick="btnGrabar_NEW_Click" Visible="False" CssClass="btn btn-danger btn-sm fixed-width-button">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Grabar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiar_NEW" runat="server" OnClick="btnLimpiar_NEW_Click" Visible="False" CssClass="btn btn-info btn-sm fixed-width-button">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                    <%--<asp:Button ID="btnVolver_NEW" runat="server" OnClick="btnVolver_NEW_Click" Text="Volver" CssClass="btn btn-info btn-sm btn-margen" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <footer class="footer" aria-hidden="False">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                            <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>
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
