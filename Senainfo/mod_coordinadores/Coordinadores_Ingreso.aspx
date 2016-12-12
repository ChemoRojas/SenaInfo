<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Coordinadores_Ingreso.aspx.cs" Inherits="mod_coordinadores_Coordinadores_Ingreso" Culture="es-CL" UICulture="es" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Ingreso Coordinadores :: Senainfo :: :: Servicio Nacional de Menores</title>
    
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/bootstrap.min.js"></script>


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
        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "";

        }

        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_reportes/busca_proyectosNuevaLeyRep.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe4a").show();
            return false;
        }

        function pageLoad(sender, args)
        {
            $(document).ready(function () {
                $("#txt_rut").Rut({
                    on_error: function () {
                        alert("El rut ingresado no es valido");
                        $("#txt_rut").val("");
                    },
                    format_on: 'keyup',
                    on_success: function () {
                        $("#getNinoRut").click();
                    }


                    
                });
            });
        }
        
      
    </script>

</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server" style="margin-left: 40px">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="ImageButton1" />--%>
                <%--<asp:PostBackTrigger ControlID="btn_agregar" />--%>
                <asp:PostBackTrigger ControlID="btnproy" />
            </Triggers>
            <ContentTemplate>
                <%-- //**FUO**// --%>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Coordinadores</li>
                        <li class="active">Ingreso Coordinadores</li>
                    </ol>
                    <div class="text-center alert alert-warning" role="alert" id="alerts" runat="server" style="display: none">
                        <span class="glyphicon glyphicon-warning-sign" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="text-center alert alert-success" role="alert" id="alerts2" runat="server" style="display: none">
                        <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>&nbsp;
                        <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Ingreso Coordinadores</h4>
                        <hr />

                        <div class="popupConfirmation" id="modal_bsc_institucion" visible="false">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal4" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">PROYECTO</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                        <cc1:ModalPopupExtender ID="mpe4a" BehaviorID="mpe4a" runat="server"
                            TargetControlID="imb_lupa_modal"
                            PopupControlID="modal_bsc_institucion"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModal4">
                        </cc1:ModalPopupExtender>
                        <asp:Button runat="server" ID="getNinoRut" OnClick="ImageButton1_Click" style="display:none;" />
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="subtitulo-form">Datos del Niño, Niña o Adolescente</h4>
                                <table class="table table-bordered table-condensed">
                                    <tr>
                                        <th class="titulo-tabla col-md-1">RUN</th>
                                        <td class="col-md-4">
                                            <div class="input-group">
                                                <asp:TextBox ID="txt_rut" runat="server" CssClass="form-control input-sm" MaxLength="12"></asp:TextBox>
                                                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" style="height: 0; width: 0;" ControlToValidate="txt_rut" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage="Rut Requerido" ValidationGroup="grupo1"></asp:RequiredFieldValidator><br />--%>
                                            <%--<asp:CustomValidator id="CustomValidator2" runat="server"  style="height: 0; width: 0;" ControlToValidate="txt_rut" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />                                        --%>
                                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_rut" ValidChars="Kk.-0123456789" />
                                                <asp:LinkButton ID="ImageButton1" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClick="ImageButton1_Click" ValidationGroup="grupo1">
                                <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                                
                                            </div>
                                        </td>

                                        <th class="titulo-tabla col-md-1">Búsqueda por RUN (Nacionalidad) </th>
                                        <td>
                                            <asp:RadioButtonList ID="rdblist_nacionalidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdblist_rut_SelectedIndexChanged" RepeatDirection="Horizontal" align="center" ValidationGroup="grupo1">
                                                <asp:ListItem Selected="True">Chileno</asp:ListItem>
                                                <asp:ListItem Selected="False">Extranjero</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1">Nombres</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txt_nombres" runat="server" CssClass="form-control input-sm" placeholder="Ingresar Nombres"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_nombres" ValidChars="aáAÁbBcCdDeéEÉfFgGhHiíIÍjJkKlLmMnNñÑoóOÓpPqQrRsStTuúUÚvVwWxXyYzZ- " />
                                        </td>

                                        <th class="titulo-tabla col-md-1">Apellido Paterno</th>
                                        <td>
                                            <asp:TextBox ID="txt_ap_paterno" runat="server" CssClass="form-control input-sm" placeholder="Ingresar Apellido Paterno"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_ap_paterno" ValidChars="aáAÁbBcCdDeéEÉfFgGhHiíIÍjJkKlLmMnNñÑoóOÓpPqQrRsStTuúUÚvVwWxXyYzZ- " />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Apellido Materno</th>
                                        <td>
                                            <asp:TextBox ID="txt_ap_materno" runat="server" CssClass="form-control input-sm" placeholder="Ingresar Apellido Materno"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_ap_materno" ValidChars="aáAÁbBcCdDeéEÉfFgGhHiíIÍjJkKlLmMnNñÑoóOÓpPqQrRsStTuúUÚvVwWxXyYzZ- " />
                                        </td>

                                        <th class="titulo-tabla">Sexo</th>
                                        <td>
                                            <asp:RadioButtonList ID="rdbl_sexo" runat="server" RepeatDirection="Horizontal" align="center">
                                                <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Fecha de Nacimiento</th>
                                        <td>
                                            <asp:TextBox ID="wdc_Fnacimiento" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" MaxLength="10"></asp:TextBox>
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="wdc_Fnacimiento" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="wdc_Fnacimiento" runat="server" ErrorMessage="Fecha Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo2" />
                                            <cc1:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="wdc_Fnacimiento" ValidChars="0123456789-/" />
                                        </td>

                                        <th class="titulo-tabla">Tipo Nacionalidad</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_tipo_nacionalidad" CssClass="form-control input-sm" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddownTipoNac_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Nacionalidad</th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddown_nacionalidad" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>


                                <asp:GridView ID="grd004" CssClass="table table-bordered table-hover" Visible="false" AllowPaging="True" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grd004_PageIndexChanging" OnRowCommand="grd004_RowCommand"
                                    Height="1px" PageSize="8">
                                    <Columns>
                                        <asp:BoundField DataField="CodNino" HeaderText="Codigo Ni&#241;o" />
                                        <asp:BoundField DataField="rut" HeaderText="RUN" />
                                        <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                                        <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                                        <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno" />
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" />
                                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                                        <asp:ButtonField CommandName="ver" Text="Ver" HeaderText="Ver"></asp:ButtonField>
                                    </Columns>
                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    <RowStyle CssClass="table-bordered caja-tabla" />
                                </asp:GridView>
                                <h4 class="subtitulo-form">Datos Judiciales</h4>

                                <table class="table table-bordered table-condensed">
                                    <tr>
                                        <th class="titulo-tabla">Región Tribunal*</th>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddown_RegionTribunal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_RegionTribunal_SelectedIndexChanged1">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1">Tipo de Tribunal*</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddown_TipoTribunal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_TipoTribunal_SelectedIndexChanged1">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla col-md-1">Tribunal*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_Tribunal" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">RUC*</th>
                                        <td>
                                            <asp:TextBox ID="txt_ruc" runat="server" CssClass="form-control input-sm" placeholder="YYONNNNNNN-D"></asp:TextBox>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="help-block" ControlToValidate="txt_ruc" Display="Dynamic" ErrorMessage="RUC Inv&aacute;lido" ClientValidationFunction="ValidaRucLRPA" ValidationGroup="grupo2" />
                                        </td>

                                        <th class="titulo-tabla">RIT</th>
                                        <td>
                                            <asp:TextBox ID="txt_rit" runat="server" CssClass="form-control input-sm" placeholder="Ingresar RIT"></asp:TextBox>
                                            <%--<asp:CustomValidator id="cv_rut" runat="server" CssClass="help-block"  ControlToValidate="txt_rit" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo2" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Fecha de Derivación*</th>
                                        <td>
                                            <asp:TextBox ID="wdc_fecha" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" MaxLength="10"></asp:TextBox>
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="wdc_fecha" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="wdc_fecha" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo2" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="wdc_fecha" ValidChars="0123456789-/" />
                                        </td>

                                        <th class="titulo-tabla">Tipo de Delito*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_TipoCausal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_TipoCausal_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Delito</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_Causal" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_Causal_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla">Código Delito*</th>
                                        <td>
                                            <asp:TextBox ID="txt_codDelito" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="help-block" ControlToValidate="txt_codDelito" Display="Dynamic" ErrorMessage="Ingrese Código Delito" Font-Bold="True" ValidationGroup="grupo2"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Región Proyecto*</th>
                                        <td>
                                            <asp:DropDownList ID="ddown_RegionProyecto" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_RegionProyecto_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla">Proyecto*</th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown_Proyecto" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown_Proyecto_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Sanción Accesoria</th>
                                        <td>
                                            <asp:RadioButtonList ID="rdblst_Sancion" runat="server" RepeatDirection="Horizontal" align="center" ValidationGroup="grupo22">
                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>

                                        <th class="titulo-tabla">ADN</th>
                                        <td>
                                            <asp:RadioButtonList ID="rdblst_Adn" runat="server" RepeatDirection="Horizontal" align="center" ValidationGroup="grupo33">
                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Sanción</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_sancion" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla">Pena</th>
                                        <td>
                                            <asp:RadioButtonList ID="rdblst_Pena" runat="server" RepeatDirection="Horizontal" align="center" ValidationGroup="grupo4">
                                                <asp:ListItem Selected="True" Value="0">Unica</asp:ListItem>
                                                <asp:ListItem Value="1">Mixta</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla">Fecha de Recepción*</th>
                                        <td>
                                            <asp:TextBox ID="wdc_fechaRecepcion" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" MaxLength="10"></asp:TextBox>
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="wdc_fechaRecepcion" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Enabled="true" ControlToValidate="wdc_fechaRecepcion" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo2" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="wdc_fechaRecepcion" ValidChars="0123456789-/" />
                                        </td>

                                        <th class="titulo-tabla">Folio</th>
                                        <td>
                                            <asp:TextBox ID="txt_Folio" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator_txt_Folio" Enabled="true" ControlToValidate="txt_Folio" runat="server" ErrorMessage="Formato Folio Inv&aacute;lido" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$" ValidationGroup="grupo2"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                                <div class="pull-right">
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_agregar"  runat="server" OnClick="btn_agregar_Click" ValidationGroup="grupo2" CausesValidation="true">
                                                                <span class="glyphicon glyphicon-ok"></span>&nbsp; Agregar
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click">
                                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnproy" runat="server" OnClick="btnproy_Click" CausesValidation="False"></asp:LinkButton>
                                    <asp:Label ID="lbl_CodNino" runat="server" Visible="False"></asp:Label>
                                </div>

                            </div>
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



