<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg_trabajadores.aspx.cs" Inherits="mod_institucion_reg_trabajadores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Src="~/SenainfoSdk/C_FormatRut.ascx" TagPrefix="uc1" TagName="C_FormatRut" %>
<%@ Register Src="~/SenainfoSdk/C_BuscaTrabajador.ascx" TagPrefix="uc1" TagName="C_BuscaTrabajador" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Registro de Trabajadores :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function MostrarModalTrabajador() {
            var objIframe = document.getElementById('iframe_trabajador');
            limpiaiframe(objIframe);
            var institucion = document.getElementById('ddown001');
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Trabajadores&dir=reg_trabajadores.aspx" + "&codinst=" + institucion.options[institucion.selectedIndex].value;
            objIframe.height = "430px";
            objIframe.width = "760px";
            $find("mpe1a").show();
            return false;
        }

        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=reg_trabajadores.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe2a").show();
            return false;
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }

        function SetProgressPosition(e) {
            var posx = 0;
            var posy = 0;
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                posx = e.clientX + document.documentElement.scrollLeft;
                posy = e.clientY + document.documentElement.scrollTop;
            }

            document.getElementById('divProgress').style.top = posy + "px";
        }


        function yaExiste(mensaje) {
            alert(' ' + mensaje);
            document.getElementById('run_tecnico').value = "";
            document.getElementById('run_tecnico').focus();
        }
        
    </script>
    <style>
        .titulo-tabla-estado {
            background-color: #eea236;
            font-size: 12px;
            font-weight: normal !important;
            color: #fff;
            padding-top: 10px;
            padding-bottom: 10px;
            padding-left: 5px;
            text-align: left;
        }

        .table-bordered-estado {
            border-top: 1px solid #eea236 !important;
            border: 1px solid #eea236;
        }
    </style>

</head>

<body role="document" onmousemove="SetProgressPosition(event)">

    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="WebImageButton3" />
                <asp:PostBackTrigger ControlID="imb002" />
                <asp:PostBackTrigger ControlID="btnPswChange" />
                <asp:PostBackTrigger ControlID="WebImageButton1" />
                <asp:AsyncPostBackTrigger ControlID="ddown001" EventName="SelectedIndexChanged" />
                <%--<asp:PostBackTrigger ControlID="ddown004" />--%>
                <asp:PostBackTrigger ControlID="btnCancelarSolicitud" />
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender
                    ID="mpe2"
                    BehaviorID="mpe2a"
                    runat="server"
                    TargetControlID="lbn_buscar_institucion"
                    PopupControlID="modal_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_institucion">
                </ajax:ModalPopupExtender>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A3" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Registro de Trabajadores</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos de Institución guardados satisfactoriamente." Visible="false"></asp:Label>
                    </div>

                    <div>
                        <asp:Label ID="lbl001" runat="server" Text="Registro de Trabajadores" Visible="false"></asp:Label>
                    </div>
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

                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Trabajadores</h4>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label runat="server" Visible="false" CssClass="help-block" ID="lblProyectosTrabajador">El Trabajador existe en las siguientes instituciones:</asp:Label>
                                <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" Visible="False" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="Nombre" HeaderText="Instituci&#243;n" />
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                                        <asp:BoundField DataField="Paterno" HeaderText="Paterno" />
                                        <asp:BoundField DataField="Materno" HeaderText="Materno" />
                                        <asp:BoundField DataField="vigencia" HeaderText="Vigencia" />
                                    </Columns>
                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                    <%--<RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                                <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />--%>
                                </asp:GridView>


                                <table class="table table-bordered  table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Institución *</th>
                                        <td class="col-md-4">
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="true" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info " OnClientClick="return MostrarModalInstitucion()">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>

                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Regi&oacute;n *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown004" runat="server" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <asp:UpdatePanel runat="server" ID="pnlDirReg">
                                        <ContentTemplate>
                                            <tr id="tr_direccionregional" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">
                                                    <asp:Label ID="lbl_direccionregional" runat="server" Text="Direcci&oacute;n Regional *" Visible="False"></asp:Label></th>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddown005" runat="server" Visible="False" CssClass="form-control input-sm" AutoPostBack="false">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Rut Técnico *</th>
                                        <td>
                                            <div class="input-group" id="dvRut">
                                                <uc1:C_FormatRut runat="server" ID="C_FormatRut" OnTextRutChanged="C_FormatRut_TextChanged" />
                                                <uc1:C_BuscaTrabajador runat="server" ID="C_BuscaTrabajador" OnCodTrabSel="C_BuscaTrabajador_CodTrabSel" />
                                                <%-- <asp:TextBox ID="run_tecnico" runat="server" placeholder="Ingresar Rut o buscar existente" AutoPostBack="true" MaxLength="10" CssClass="form-control input-sm" OnTextChanged="run_tecnico_TextChanged" />

                                                <asp:LinkButton ID="lbn_buscar_trabajador" runat="server" CssClass="btn btn-info btn-sm input-group-addon " OnClientClick="return MostrarModalTrabajador()">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>--%>
                                            </div>
                                            <%--<asp:RegularExpressionValidator ID="rev_run_tecnico" ControlToValidate="run_tecnico" runat="server" ErrorMessage="Ingrese Solo Números" Font-Bold="True" ForeColor="Red" ValidationExpression="^[0-9-]+$"></asp:RegularExpressionValidator>--%>
                                            <!-- OnValueChange="run_tecnico_ValueChange" -->
                                            <%--<ajax:MaskedEditExtender ID="MaskedEditExtender87" runat="server" TargetControlID="txt001" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999" />--%>

                                            <%--<asp:Panel ID="pnl003" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px" Height="50px" HorizontalAlign="Center" Visible="False" Width="250px">
                                                <asp:Label ID="lbl004" runat="server" Font-Size="11px"></asp:Label>
                                            </asp:Panel>--%>


                                            <asp:Panel ID="pnl003" runat="server" Height="16px" HorizontalAlign="Center" Visible="False">
                                                <asp:Label ID="lbl004" runat="server" CssClass="help-block"></asp:Label>
                                            </asp:Panel>


                                        </td>

                                        <th class="titulo-tabla" scope="row">Apellido Paterno *</th>
                                        <td>
                                            <asp:TextBox ID="txt002" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Apellido Materno *</th>
                                        <td>
                                            <asp:TextBox ID="txt003" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Nombres *</th>
                                        <td>
                                            <asp:TextBox ID="txt004" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Teléfono</th>
                                        <td>
                                            <asp:TextBox ID="txt005" runat="server" MaxLength="8" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rev_txt005" ControlToValidate="txt005" runat="server" ErrorMessage="Telefono Invalido" CssClass="help-block" Display="Dynamic" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                            <%--<ajax:MaskedEditExtender ID="mee_txt005" runat="server" TargetControlID="txt005" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="99999999" />--%>

                                        </td>

                                        <th class="titulo-tabla" scope="row">E-Mail *</th>
                                        <td>
                                            <asp:TextBox ID="txt006" runat="server" MaxLength="50" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt006" Display="Dynamic" runat="server" ErrorMessage="Correo inv&aacute;lido" CssClass="help-block" ValidationExpression="^[_a-z0-9-_A-Z0-9-]+(\.[_a-z0-9-_A-Z0-9-]+)*@[a-z0-9-A-Z0-9-]+(\.[a-z0-9-A-Z0-9-]+)*(\.[a-zA-Z]{2,3})$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Fax</th>
                                        <td>
                                            <asp:TextBox ID="txt007" runat="server" MaxLength="8" CssClass="form-control input-sm"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rev_txt007" ControlToValidate="txt007" Display="Dynamic" runat="server" ErrorMessage="Fax Invalido" CssClass="help-block" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                            <%--<ajax:MaskedEditExtender ID="mee_txt007" runat="server" TargetControlID="txt007" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="99999999" />--%>
                                        </td>

                                        <th class="titulo-tabla" scope="row">C&oacute;digo Postal&nbsp;</th>
                                        <td>
                                            <asp:TextBox ID="txt008" runat="server" MaxLength="7" CssClass="form-control input-sm" />
                                            <asp:RegularExpressionValidator ID="rev_txt008" ControlToValidate="txt008" Display="Dynamic" runat="server" ErrorMessage="Codigo Postal Invalido" CssClass="help-block" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                            <%--<ajax:MaskedEditExtender ID="MaskedEditExtender90" runat="server" TargetControlID="txt008" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999999" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Profesi&oacute;n *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Vigencia</th>
                                        <td>
                                            <asp:DropDownList ID="ddown003" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Selected="True" Value="V">Vigente</asp:ListItem>
                                                <asp:ListItem Value="C">Caducado</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                            <h4 class="subtitulo-form">Datos del Usuario</h4>

                            <div class="row">
                                <div class="col-md-12">

                                    <table class="table table-bordered table-condensed">
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row">Nombre Usuario *</th>
                                            <td class="col-md-4">
                                                <asp:TextBox ID="txt_usuario" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                <asp:Label ID="lbl_usrexiste" runat="server" Visible="False"></asp:Label>
                                            </td>

                                            <th class="titulo-tabla col-md-1" scope="row">Rol *</th>
                                            <td>
                                                <asp:DropDownList ID="ddown_rol" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <table class="table" id="tblInfoUser" runat="server">
                                        <tr>
                                            <td>
                                                <table class="table-bordered-estado table-condensed">
                                                    <tr>
                                                        <th class="titulo-tabla-estado col-md-1" scope="row">Estado</th>
                                                        <td class="col-md-4">
                                                            <asp:Label ID="txtInfoUser" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="col-md-6">
                                                <div class="pull-right">
                                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnCancelarSolicitud" runat="server" Visible="False" OnClick="btnCancelarSolicitud_Click">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Cancelar Solicitud</asp:LinkButton>
                                                     
                                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnReenvio" Visible="False" runat="server" OnClick="btnReenvio_Click" CausesValidation="False">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Reenvío Mail</asp:LinkButton>

                                                     <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnPswChange" Visible="False" runat="server" OnClick="btnPswChange_Click" CausesValidation="False">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Cambiar Contraseña</asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="pull-right">
                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton3" runat="server" Visible="False" OnClick="WebImageButton3_Click">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar</asp:LinkButton>

                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb002" runat="server" OnClick="imb002_Click">
                                     <span class="glyphicon glyphicon-ok"></span>&nbsp;Crear Cuenta</asp:LinkButton>
                                       
                                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton1" PostBackUrl="~/mod_instituciones/reg_trabajadores.aspx" runat="server" OnClick="WebImageButton1_Click1" CausesValidation="False">
                                     <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar </asp:LinkButton>
                                        <input type="hidden" name="hidValue" ID="hidValue" />
                                        <input type="hidden" name="hidFlag" ID="hidFlag" />
                                        <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton2" runat="server" Text="Volver" OnClick="WebImageButton2_Click" CausesValidation="False" />--%>
                                    </div>

                                </div>
                            </div>

                        </asp:Panel>
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
