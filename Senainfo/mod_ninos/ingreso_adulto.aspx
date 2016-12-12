    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="ingreso_adulto.aspx.cs" Inherits="mod_ninos_ingreso_adulto" %>

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
    <title>Ingreso Adulto :: Senainfo :: Servicio Nacional de Menores</title>
    
    <%--<script src="../js/jquery-1.10.2.js"></script>--%>
    <%--<script src="../js/jquery-1.9.1.js"></script>--%>
    <script src="../js/jquery1.10.2.min.js"></script>
    <script src="../js/bootstrap3.3.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/jquery.blockUI.js"></script>

    <%--<script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/ie10-viewport-bug-workaround.js"></script>--%>

    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>

    <script  type="text/javascript">

        //function rut_01() {
        //    mod_ninos_ingreso_adulto.rut_01()
        //}

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

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#txt_rut1').Rut({
                    on_error: function () { alert('El rut ingresado no es válido'); $('#txt_rut1').val(""); },
                    format_on: 'keyup'
                });

                $('#txt_rut2').Rut({
                    on_error: function () { alert('El rut ingresado no es válido'); $('#txt_rut2').val(""); },
                    format_on: 'keyup'
                });
                
            });
        };
</script>

    <style>
        .avoid-clicks
        {
            pointer-events: none;
        }
    </style>
</head>

<body class="body-form">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnnext004" />
            </Triggers>
            <ContentTemplate>

                <div class="container">
                    <div class="row">
                        <div class="col-md-12 caja-tabla">
                            <div class="text-center">
                                <div class="row">
                                    <div class="alert alert-warning" runat="server" visible="false" id="div_alert">
                                        <strong><span class="glyphicon glyphicon-warning-sign"></span>&nbsp;<asp:Label ID="lbl_info1" runat="server" Visible="False"></asp:Label></strong>
                                    </div>
                                </div>
                            </div>
                            <div>
                            <asp:Label ID="lblTitulo" class="titulo-form" runat="server" Text="Ingreso a SubProgramas Flia Origen y Solicitantes" ></asp:Label>
                            <%--<p class="titulo-form">Ingreso a SubProgramas Flia Origen y Solicitantes</p>--%>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tbody>
                                    <tr>
                                        <td>
                                            <div class="text-center">
                                                <asp:RadioButton ID="rd_PAF" runat="server" GroupName="Sub_prog" OnCheckedChanged="cambio_estado_inicial"
                                                    Text="Subp. Flia Origen" AutoPostBack="True" />
                                                <asp:RadioButton ID="rd_PES" runat="server" GroupName="Sub_Prog" OnCheckedChanged="cambio_estado_inicial"
                                                    Text="Subp. Solicitantes" AutoPostBack="True" />
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:Panel ID="pnl_01" runat="server" Enabled="False">
                                <asp:Label ID="lblSubTituloDatosUsuario" class="titulo-form" Text="Datos Usuario SubProgramas Flia Origen - Solicitantes" runat="server" />
                                <table class="table table-bordered table-col-fix table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Usuario *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_tuser01" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown_tuser01_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">RUN</th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                             <asp:TextBox ID="txt_rut1" CssClass="form-control input-sm" runat="server" ONVALUECHANGE="txt001_ValueChange" MaxLength="12" />
                                                            <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt_rut1" ValidChars="Kk0123456789-." />
                                                        </td>
                                                        <td>
                                                            <%--<asp:CustomValidator id="cv_rut" runat="server" CssClass="help-block"  ControlToValidate="txt_rut1" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />--%>
                                                            <%--<asp:Label ID="lbl_rut1" runat="server" Visible="False"></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Nombres *</th>
                                            <td>
                                                <asp:TextBox ID="txt_nombre1" CssClass="form-control input-sm" runat="server" OnTextChanged="txt_nombre1_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Apellido Paterno *</th>
                                            <td>
                                                <asp:TextBox ID="txt_paterno1" CssClass="form-control input-sm" runat="server" OnTextChanged="txt_paterno1_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txt_paterno1" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Apellido Materno *</th>
                                            <td>
                                                <asp:TextBox ID="txt_materno1" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnTextChanged="txt_materno1_TextChanged" ></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_materno1" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Sexo *</th>
                                            <td>
                                                <asp:RadioButton ID="rd_fem1" runat="server" Text="Mujer" GroupName="sexo1" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                                <asp:RadioButton ID="rd_masc1" runat="server" Text="Hombre" GroupName="sexo1" />
                                                <asp:Label ID="lbl_aviso" runat="server" Visible="False" CssClass="alert-warning"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Nacionalidad *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_tipo_nacionalidad1" CssClass="form-control input-sm" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown_tipo_nacionalidad_SelectedIndexChanged" >
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Nacionalidad *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_nac1" CssClass="form-control input-sm" runat="server">
                                                    <asp:ListItem Selected="True" Value="-1">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Fecha Nacimiento *</th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="cal_1" runat="server" CssClass="form-control input-sm" OnKeyPress="return false;" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende591" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_1" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        </td>
                                                        <td>
                                                             <asp:rangevalidator id="rv_año" CssClass="help-block" runat="server" Display="Dynamic" ControlToValidate="cal_1" ErrorMessage="Solo pueden adoptar personas mayores de 25 años de edad con un tope de 60 años" Type="Date"  OnInit="rv_fecha_Init" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnl_02" runat="server" Enabled="False" Visible="false">
                                <p class="titulo-form">
                                    Datos Usuario (2)&nbsp;
                                <asp:Label ID="lbl_usuario2" runat="server"></asp:Label>
                                </p>
                                <table class="table table-bordered table-col-fix table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Usuario</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_tuser2" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" >
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">RUN</th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                             <asp:TextBox ID="txt_rut2" runat="server" CssClass="form-control input-sm"  ONVALUECHANGE="txt_rut_02" MaxLength="12" />
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_rut2" ValidChars="Kk0123456789-." />
                                                        </td>
                                                        <td>
                                                            <%--<asp:CustomValidator id="CustomValidator1" runat="server" CssClass="help-block"  ControlToValidate="txt_rut2" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />--%>
                                                            <%--<asp:Label ID="lbl_rut2" runat="server" Visible="False"></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Nombres *</th>
                                            <td>
                                                <asp:TextBox ID="txt_nombre2" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Apellido Paterno *</th>
                                            <td>
                                                <asp:TextBox ID="txt_paterno2" CssClass="form-control input-sm" runat="server" OnTextChanged="txt_paterno1_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_paterno2" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Apellido Materno *</th>
                                            <td>
                                                <asp:TextBox ID="txt_materno2" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_materno2" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Sexo *</th>
                                            <td>
                                                <asp:RadioButton ID="rd_fem2" runat="server" Text="Mujer" GroupName="sexo2" />
                                                <asp:RadioButton ID="rd_masc2" runat="server" Text="Hombre" GroupName="sexo2" />
                                                <asp:Label ID="lbl_aviso1" runat="server" Visible="False" CssClass="alert-warning"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Tipo Nacionalidad *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_tipo_nacionalidad2" CssClass="form-control input-sm" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown_tipo_nacionalidad2_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Nacionalidad *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_nac2" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="-1">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Fecha Nacimiento *</th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="cal_2" CssClass="form-control input-sm" runat="server" Width="150px" OnKeyPress="return false;" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende604" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_2" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        </td>
                                                        <td>
                                                            <asp:rangevalidator id="Rangevalidator1" CssClass="help-block" runat="server" Display="Dynamic" ControlToValidate="cal_2" ErrorMessage="Solo pueden adoptar personas mayores de 25 años de edad con un tope de 60 años" Type="Date"  OnInit="rv_fecha_Init" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnl_03" runat="server" Enabled="False">
                                <asp:Label ID="lblSubtitulo2" class="titulo-form" Text="Datos de Solicitante" runat="server" />
                                <table class="table table-bordered table-col-fix table-condensed">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Nombres Solicitante</th>
                                            <td>
                                                <asp:TextBox ID="txt_nom_gen" CssClass="form-control input-sm avoid-clicks" Enabled="false"  runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Apellido Paterno Solicitante</th>
                                            <td>
                                                <asp:TextBox ID="txt_pat_gen" CssClass="form-control input-sm avoid-clicks" Enabled="false" runat="server"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_pat_gen" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Apellido Materno Solicitante</th>
                                            <td>
                                                <asp:TextBox ID="txt_mat_gen" CssClass="form-control input-sm avoid-clicks" Enabled="false"  runat="server"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_mat_gen" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü" />
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Técnico *</th>
                                            <td>
                                                <asp:DropDownList ID="dd_prueba" CssClass="form-control input-sm" runat="server">
                                                    <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Fecha Ingreso *</th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="cal_3" CssClass="form-control input-sm" runat="server" ONVALUECHANGED="cal004_ValueChanged" OnKeyPress="return false;" />
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende618" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_3" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                        </td>
                                                        <td>
                                                            <asp:RangeValidator ID="RangeValidator618" runat="server" Text="Fecha Invalida" ControlToValidate="cal_3" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />
                                                            <br></br>
                                                            <asp:Label ID="lbl_cal3" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Región Origen *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_region" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddown_region_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="-2">Seleccionar </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Comuna Origen *</t>
                                            <td>
                                                <asp:DropDownList ID="ddown_comuna" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <div>
                                <asp:Button ID="btnnext004" disabled="disabled" AutoPostback="true" CssClass="btn btn-info btn-sm" runat="server" Text="Realizar Ingreso" OnClick="btnnext004_Click" ValidationGroup="grupo1" />
                            </div>
                        </div>
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
