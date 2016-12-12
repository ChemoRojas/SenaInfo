<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ingresoninolistaespera.aspx.cs" Inherits="mod_ninos_Ingresoninolistaespera" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Ingreso Lista de Espera</title>

    <%--<script src="../js/jquery-1.9.1.js"></script>--%>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/jquery-ui.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/notify.js"></script>
    <script src="../js/jquery.Rut.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>

    <script type="text/javascript">

        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }

        function ValidaRuc(source, arguments) {

            var rut = arguments.Value;
            rut = rut.trim();
            if (rut.length < 12) { arguments.IsValid = false; return }

            var strGuionDigito = rut.substring(rut.length - 2);
            var strCuerpo = rut.substring(0, rut.length - 2);

            if (!isNumeric(strCuerpo)) { arguments.IsValid = false; return }

            if (strGuionDigito.substring(0, 1) != '-') { arguments.IsValid = false; return }
            var aux = "2765432765432";
            var ruc = "123456789K0";
            var ns = rut.length;
            var i = ns - 2;
            var a = 12;
            var sum = 0;
            while (i >= 0) {
                if (rut.substring(i, i + 1) != '-') {
                    sum = sum + (parseInt(rut.substring(i, i + 1)) * parseInt(aux.substring(a, a + 1)));
                    a = a - 1;
                    if (a == 0) a = 12;
                }
                i = i - 1;
            }
            sum = 11 - (sum % 11);
            if (rut.substring(ns - 1, ns) == ruc.substring(sum - 1, sum))
                arguments.IsValid = true;
            else
                arguments.IsValid = false;
        };

        function CerrarModalPopUp() {
            $('#UpdateProgress1').fadeIn();
            parent.location.reload();
        }

        function AbrirURLModalPopUp(url) {

            $('#UpdateProgress1').fadeIn();
            parent.location.replace(url);
        }
            
    </script>

</head>
<body class="body-form" onkeydown="return (event.keyCode!=13)" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="imb003" />
                <%-- <asp:PostBackTrigger ControlID="ImageButton1" />--%>
                <asp:PostBackTrigger ControlID="btn_agregar" />
            </Triggers>
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="table-borderless table-condensed">
                            <p class="titulo-form">Ingreso Lista de Espera</p>
                            <div>
                                <asp:Label ID="lbl001" runat="server" Text="Coincidencias" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_encontrados" runat="server" Visible="False" Font-Bold="True"></asp:Label>
                                <asp:LinkButton ID="lnk_resultados" runat="server" Visible="False" OnClick="lnk_resultados_Click" CausesValidation="False">VER RESULTADOS</asp:LinkButton>
                                <asp:Label ID="lbl_error" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_CodNino" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_ICodIngresoLE" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lbl_existe" CssClass="help-block" runat="server" Text="Ingreso no válido, ya se encontraron registros para este niño(a)." Visible="False"></asp:Label>
                            </div>

                            <asp:GridView ID="grd004" CssClass="table table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd004_PageIndexChanging" OnRowCommand="grd004_RowCommand">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="CodNino" HeaderText="Codigo Ni&#241;o" />
                                    <asp:BoundField DataField="rut" HeaderText="Rut" />
                                    <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                    <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno" />
                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                                    <asp:ButtonField CommandName="ver" Text="Ver"></asp:ButtonField>
                                </Columns>

                            </asp:GridView>

                            <div>
                                <caption>
                                    <h4>
                                        <asp:Label ID="lbl_exito" runat="server" Text="Ingreso exitoso." Visible="False" />
                                    </h4>
                                    <h4>
                                        <asp:Label ID="lbl_exito2" runat="server" Font-Bold="True" Text="Actualización exitosa." Visible="False" />
                                    </h4>
                                </caption>
                            </div>
                            <div>
                                <asp:Label ID="lbl_warning" CssClass="help-block" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12 caja-tabla">

                            <table class="table table-bordered  table-condensed">
                                <tbody>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Tipo de Nacionalidad</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_tipo_nacionalidad" CssClass="form-control input-sm" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown_tipo_nacionalidad_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>

                                        <th class="titulo-tabla" scope="row">Nacionalidad *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_nacionalidad" CssClass="form-control input-sm" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddown_nacionalidad_SelectedIndexChanged">
                                            </asp:DropDownList>

                                            
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="tblBusquedaRut" visible="false" runat="server" class="table table-bordered  table-condensed">
                                <tbody>
                                    <tr>
                                        <th id="thRut" runat="server" class="titulo-tabla col-md-1" scope="row">RUN *</th>
                                        <td id="tdRut" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txt_rut" CssClass="form-control input-sm" MaxLength="12" runat="server" placeholder="Ingresar" />
                                                        <%--<asp:CustomValidator ID="cv_rut" runat="server" CssClass="help-block" ControlToValidate="txt_rut" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" />--%>
                                                        <ajax:FilteredTextBoxExtender ID="fte3" runat="server" TargetControlID="txt_rut" ValidChars=".kK0123456789-" />
                                                        <asp:Label ID="lblErrorRut" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRutTest" runat="server" Visible="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rdblist_nacionalidad" runat="server" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="rdblist_rut_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True">Chileno</asp:ListItem>
                                                            <asp:ListItem>Extranjero</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <th class="titulo-tabla">Nombres *</th>
                                        <td>
                                            <asp:TextBox ID="txt_nombres" CssClass="form-control input-sm" runat="server" placeholder="Ingresar"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>

                                        <th class="titulo-tabla">Apellido Paterno *</th>
                                        <td>
                                            <asp:TextBox ID="txt_ap_paterno" CssClass="form-control input-sm" runat="server" placeholder="Ingresar"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla">Apellido Materno *</th>
                                        <td>
                                            <asp:TextBox ID="txt_ap_materno" CssClass="form-control input-sm" runat="server" placeholder="Ingresar"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;
                                        </td>
                                        <td colspan="3">
                                            <asp:LinkButton ID="ImageButton1" CssClass="btn btn-info btn-sm fixed-width-button" AutoPostback="true" runat="server" OnClick="ImageButton1_Click" CausesValidation="False">
                                                <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="tblDatos" visible="false" runat="server" class="table table-bordered  table-condensed">
                                <tbody>

                                    <tr>


                                        <th class="titulo-tabla col-md-1">Sexo *</th>
                                        <td>
                                            <asp:RadioButtonList ID="rdbl_sexo" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="F">&nbsp;Femenino&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="M">&nbsp;Masculino</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Fecha de Nacimiento *</th>
                                        <td>

                                            <asp:TextBox ID="wdc_Fnacimiento" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="wdc_Fnacimiento" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender ID="CalendarExtende498" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="wdc_Fnacimiento" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                            <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="wdc_Fnacimiento" Type="Date" OnInit="rv_fecha_Init" />

                                        </td>

                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Región del Niño*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_region" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_region_SelectedIndexChanged" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Comuna del Niño*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_comuna" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown_comuna_SelectedIndexChanged" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Solicitante de Ingreso*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_solicitante" CssClass="form-control input-sm" runat="server" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla" scope="row">Fecha de Ingreso a Lista de Espera*</th>
                                        <td>

                                            <asp:TextBox ID="wdc_Flistaespera" CssClass="form-control form-control-fecha-large input-sm" runat="server" Enabled="False" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="wdc_Flistaespera" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender ID="CalendarExtende510" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="wdc_Flistaespera" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                            <asp:RangeValidator ID="RangeValidator2" runat="server" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="wdc_Flistaespera" Type="Date" OnInit="rv_fecha_Init" />
                                            <div>
                                                <asp:Label ID="lbl_errorFecha1" runat="server" Font-Bold="True" CssClass="help-block" Text="No puede ingresar una fecha futura" Visible="False"></asp:Label>
                                            </div>

                                        </td>

                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Región Tribunal*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_RegionTribunal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_RegionTribunal_SelectedIndexChanged1" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Tipo de Tribunal*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_TipoTribunal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_TipoTribunal_SelectedIndexChanged1" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Tribunal*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_Tribunal" CssClass="form-control input-sm" runat="server" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">RUC*</th>
                                        <td>
                                            <asp:TextBox ID="txt_ruc" CssClass="form-control input-sm" runat="server" OnTextChanged="txt_ruc_ValueChange" AutoPostBack="True" Enabled="False" placeholder="Ingresar" />
                                            <asp:Label ID="lblErrorRUC" runat="server" CssClass="help-block" Text="El RUC ingresado no es válido" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">RIT*</th>
                                        <td>
                                            <asp:TextBox ID="txt_rit" CssClass="form-control input-sm" runat="server" Enabled="False" placeholder="Ingresar"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt_rit" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />
                                        </td>

                                        <th class="titulo-tabla" scope="row">Fecha de la Orden*</th>
                                        <td>

                                            <asp:TextBox ID="wdc_fecha" CssClass="form-control form-control-fecha-large input-sm" runat="server" Enabled="False" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="wdc_fecha" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender ID="CalendarExtende522" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="wdc_fecha" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                            <asp:RangeValidator ID="RangeValidator3" runat="server" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="wdc_fecha" Type="Date" OnInit="rv_fecha_Init" />

                                            <div>
                                                <asp:Label ID="lbl_errorFecha2" runat="server" CssClass="help-block" Font-Bold="True" Text="No puede ingresar una fecha futura" Visible="False"></asp:Label>
                                            </div>

                                        </td>

                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Tipo Causal*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_TipoCausal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_TipoCausal_SelectedIndexChanged" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Causal Ingreso*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_Causal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Institución*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_Institucion" CssClass="form-control input-sm" runat="server" AutoPostBack="True" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Proyecto*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_Proyecto" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown_Proyecto_SelectedIndexChanged" Enabled="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="tr_fecha_egreso" runat="server" visible=" false">
                                        <th class="titulo-tabla" scope="row">
                                            <asp:Label ID="lbl_egreso" runat="server" Text="Fecha de Egreso Lista de Espera *" Visible="False"></asp:Label>
                                        </th>
                                        <td colspan="3">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="wdc_F_egreso" ToolTip="Si solo desea actualizxar datos, mantenga en blanco la fecha y la opción seleccionar en el campo Estado" CssClass="form-control form-control-fecha input-sm" runat="server" Visible="False" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="wdc_F_egreso" ValidChars="0123456789-/" />
                                                        <ajax:CalendarExtender ID="CalendarExtende534" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="wdc_F_egreso" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    </td>
                                                    <td>
                                                        <asp:RangeValidator ID="RangeValidator534" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="wdc_F_egreso" Type="Date" OnInit="rv_fecha_Init" /><br />
                                                        <asp:Label ID="lbl_errorFecha3" CssClass="help-block" runat="server" Font-Bold="True" Text="No puede ingresar una fecha futura" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="tr_estado" runat="server" visible="false">
                                        <th class="titulo-tabla" scope="row">
                                            <asp:Label ID="lbl_estado" runat="server" Text="Estado" Visible="False"></asp:Label>
                                        </th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddown_estado" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddown_estado_SelectedIndexChanged" runat="server" Visible="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trCausalFallecimiento" visible="false">
                                        <th class="titulo-tabla" scope="row">Causal de Defunción *</th>
                                        <td>
                                            <asp:TextBox ID="txtCausalFallecimiento" runat="server" CssClass="form-control input-sm" placeholder="Ingresar" MaxLength="35" />
                                        </td>
                                    </tr>
                                    <tr id="trFechaDefuncion" runat="server" visible="false">
                                        <th class="titulo-tabla" scope="row">Fecha de Defunción *</th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtFechaDefuncion" runat="server" CssClass="form-control form-control-fecha input-sm" AutoPostBack="true" OnTextChanged="txtFechaDefuncion_TextChanged" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FTEFechaDefuncion" runat="server" TargetControlID="txtFechaDefuncion" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CEFechaDefuncion" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaDefuncion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RVFechaDefuncion" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="txtFechaDefuncion" Type="Date" OnInit="rv_fecha_Init" />
                                        </td>
                                    </tr>
                                    <tr id="trLugarFallecimiento" runat="server" visible="false">
                                        <th class="titulo-tabla" scope="row">Lugar Defunción *</th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlLugarFallecimiento" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trRegionFallecimiento" runat="server" visible="false">
                                        <th class="titulo-tabla" scope="row">Región Defunción *</th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlRegionFallecimiento" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlRegionFallecimiento_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trComunaFallecimiento" runat="server" visible="false">
                                        <th class="titulo-tabla" scope="row">Comuna Defunción *</th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlComunaFallecimiento" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="botonera pull-right">
                                <asp:Button CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_agregar" runat="server" OnClick="btn_agregar_Click" Enabled="False" AutoPostback="true" Text="Agregar" />

                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click" Visible="False" CausesValidation="False">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Limpiar
                                </asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb003" runat="server" OnClick="imb003_Click" CausesValidation="False" Visible="False">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Bootstrap core JavaScript
                ================================================== -->
                <!-- Placed at the end of the document so the pages load faster -->

                <script src="../js/bootstrap.min.js"></script>
                <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
                <script src="../js/ie10-viewport-bug-workaround.js"></script>
                <!-- Latest compiled and minified JavaScript -->

                <script type="text/javascript">
                    function pageLoad(sender, args) {
                        $(document).ready(function () {
                            $("#txt_rut").Rut(
                                {
                                    on_error: function () { alert('El rut ingresado no es válido'); $('#txt_rut').val(""); },
                                    format_on: 'keyup'
                                });

                            //$.notify(
                            //    "Hay alertas que deberías revisar!",
                            //  {
                            //      // whether to hide the notification on click
                            //      clickToHide: true,
                            //      // whether to auto-hide the notification
                            //      autoHide: true,
                            //      // if autoHide, hide after milliseconds
                            //      autoHideDelay: 5000,
                            //      // show the arrow pointing at the element
                            //      arrowShow: true,
                            //      // arrow size in pixels
                            //      arrowSize: 5,
                            //      // default positions
                            //      globalPosition: 'top center',
                            //      //elementPosition: 'top center',
                            //      // default style
                            //      style: 'bootstrap',
                            //      // default class (string or [string])
                            //      className: 'info',
                            //      // show animation
                            //      showAnimation: 'slideDown',
                            //      // show animation duration
                            //      showDuration: 400,
                            //      // hide animation
                            //      hideAnimation: 'slideUp',
                            //      // hide animation duration
                            //      hideDuration: 200,
                            //      // padding between element and notification
                            //      gap: 2
                            //  });
                        });
                    }

                    function mostrarAlerta() {
                        $.notify(
                                "Hay alertas que deberías revisar!",
                              {
                                  // whether to hide the notification on click
                                  clickToHide: true,
                                  // whether to auto-hide the notification
                                  autoHide: true,
                                  // if autoHide, hide after milliseconds
                                  autoHideDelay: 5000,
                                  // show the arrow pointing at the element
                                  arrowShow: true,
                                  // arrow size in pixels
                                  arrowSize: 5,
                                  // default positions
                                  globalPosition: 'top center',
                                  //elementPosition: 'top center',
                                  // default style
                                  style: 'bootstrap',
                                  // default class (string or [string])
                                  className: 'info',
                                  // show animation
                                  showAnimation: 'slideDown',
                                  // show animation duration
                                  showDuration: 400,
                                  // hide animation
                                  hideAnimation: 'slideUp',
                                  // hide animation duration
                                  hideDuration: 200,
                                  // padding between element and notification
                                  gap: 2
                              });
                    }

                    
                </script>
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

</html>
