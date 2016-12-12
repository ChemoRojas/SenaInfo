<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="reg_inmuebles.aspx.cs" Inherits="mod_institucion_reg_inmuebles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <title>Registro de Inmuebles :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
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

        function MostrarModalInmuebles() {
            var objIframe = document.getElementById('iframe_inmueble');
            limpiaiframe(objIframe);
            var institucion = document.getElementById('ddown001');
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Inmuebles&dir=reg_inmuebles.aspx" + "&codinst=" + institucion.options[institucion.selectedIndex].value;
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe1a").show();

            return false;
        }

        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Inmuebles&dir=reg_inmuebles.aspx&param002=SI";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe2a").show();

            return false;
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press
            }
        }

        function limpiarForm() {
            window.location = "reg_inmuebles.aspx"
        }
    </script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <cc1:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="lbn_buscar_inmueble"
                    PopupControlID="modal_inmueble"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_inmueble">
                </cc1:ModalPopupExtender>

                <cc1:ModalPopupExtender
                    ID="mpe2"
                    BehaviorID="mpe2a"
                    runat="server"
                    TargetControlID="lbn_buscar_institucion"
                    PopupControlID="modal_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="lnb_close_buscar_institucion">
                </cc1:ModalPopupExtender>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A3" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Registro de Inmuebles</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos de Inmueble guardados satisfactoriamente." Visible="false"></asp:Label>
                    </div>
                    <div class="pull-right">
                        <asp:Label ID="lbl001" runat="server" Text="Registro de Inmuebles" Visible="false"></asp:Label>
                        <div class="popupConfirmation" id="modal_inmueble" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="lnb_close_buscar_inmueble" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">BUSCAR INMUEBLE</h4>
                            </div>
                            <div>
                                <iframe id="iframe_inmueble" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
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
                        <h4 class="subtitulo-form">Registro de Inmuebles</h4>
                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-bordered  table-condensed">

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Institución *</th>
                                        <td colspan="3">
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown001" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>

                                        <th class="titulo-tabla" scope="row">Nombre del Inmueble *</th>
                                        <td class="col-md-4">
                                            <div class="input-group">
                                                <asp:TextBox ID="txt0015" runat="server" MaxLength="100" CssClass="form-control input-sm" placeholder="Busque inmueble o ingrese uno nuevo" ></asp:TextBox>
                                                <asp:LinkButton ID="lbn_buscar_inmueble" runat="server" CssClass="btn btn-info btn-sm input-group-addon" OnClientClick="return MostrarModalInmuebles()">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>

                                            </div>
                                        </td>
                                    
                                        <th class="titulo-tabla col-md-1" scope="row">Dirección *</th>
                                        <td>
                                            <asp:TextBox ID="txt002" runat="server" MaxLength="100" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Región *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown004" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    
                                        <th class="titulo-tabla" scope="row">Comuna *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown009" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Teléfono *</th>
                                        <td>
                                            <asp:TextBox ID="txt005" runat="server" CssClass="form-control input-sm" MaxLength="8" onkeypress="return numbersonly(event);" autocomplete="off"></asp:TextBox>
                                            <%--<cc1:MaskedEditExtender ID="mee_txt005" runat="server" TargetControlID="txt005" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="99999999" />--%>
                                            <%-- <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt005" Mask="^(\d{12})" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" />--%>
                                        </td>
                                    
                                        <th class="titulo-tabla" scope="row">Fax</th>
                                        <td>
                                            <asp:TextBox ID="txt007" runat="server" CssClass="form-control input-sm" MaxLength="8" onkeypress="return numbersonly(event);" autocomplete="off"></asp:TextBox>
                                            <%--<cc1:MaskedEditExtender ID="mee_txt007" runat="server" TargetControlID="txt007" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="99999999" />--%>
                                            <%--<cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt007" Mask="^(\d{12})" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Código Postal</th>
                                        <td>
                                            <asp:TextBox ID="txt008" runat="server" CssClass="form-control input-sm" MaxLength="7" onkeypress="return numbersonly(event);" autocomplete="off"></asp:TextBox>
                                            <%--<cc1:MaskedEditExtender ID="mee_txt008" runat="server" TargetControlID="txt008" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999999" />--%>
                                            <%--<asp:RegularExpressionValidator ID="mee_txt008" Enabled="true" ControlToValidate="txt008" runat="server" ErrorMessage="Código Postal Inválido" Font-Bold="True" ForeColor="Red" ValidationExpression="^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$"></asp:RegularExpressionValidator>--%>
                                        </td>
                                    
                                        <th class="titulo-tabla" scope="row">Tipo Inmueble *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown005" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Situación Legal *</th>
                                        <td>
                                            <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    
                                        <th class="titulo-tabla" scope="row">Mts. Construidos</th>
                                        <td>
                                            <asp:TextBox ID="txt009" runat="server" CssClass="form-control input-sm" onkeypress="return numbersonly(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Enabled="true" ControlToValidate="txt009" runat="server" ErrorMessage="Mts. Construidos Inválido" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Mts. Totales</th>
                                        <td>
                                            <asp:TextBox ID="txt0010" runat="server" CssClass="form-control input-sm" onkeypress="return numbersonly(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Enabled="true" ControlToValidate="txt0010" runat="server" ErrorMessage="Mts. Totales Inválido" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                    
                                        <th class="titulo-tabla" scope="row">Nº Dormitorios</th>
                                        <td>
                                            <asp:TextBox ID="txt0011" runat="server" CssClass="form-control input-sm" onkeypress="return numbersonly(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="txt0011" runat="server" ErrorMessage="Nº Dormitorios Inválido" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Capacidad de Niños(as)</th>
                                        <td>
                                            <asp:TextBox ID="txt0012" runat="server" CssClass="form-control input-sm" onkeypress="return numbersonly(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator_txt0012" Enabled="true" ControlToValidate="txt0012" runat="server" ErrorMessage="Capacidad Niños Inválida" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                    
                                        <th class="titulo-tabla" scope="row">Número Baños</th>
                                        <td>
                                            <asp:TextBox ID="txt0013" runat="server" CssClass="form-control input-sm" onkeypress="return numbersonly(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator_txt0013" Enabled="true" ControlToValidate="txt0013" runat="server" ErrorMessage="Número Baños Inválido" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Cantidad de Pisos</th>
                                        <td>
                                            <asp:TextBox ID="txt0014" runat="server" CssClass="form-control input-sm" onkeypress="return numbersonly(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="txt0014" runat="server" ErrorMessage="Cantidad Pisos Inválido" CssClass="help-block" Display="Dynamic" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                        </td>
                                   
                                        <th class="titulo-tabla" scope="row">Areas Verdes&nbsp;</th>
                                        <td>
                                            <asp:DropDownList ID="ddown007" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="S">Si</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>                                    
                                </table>
                                <div class="botonera pull-right">
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton4" runat="server"  Visible="False" OnClick="WebImageButton4_Click" >
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton1" runat="server"  OnClick="WebImageButton1_Click" >
                                                   <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                                </asp:LinkButton>
                                                <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton2" runat="server" Text="Limpiar" OnClick="WebImageButton2_Click" />--%>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" runat="server"  OnClientClick="limpiarForm();" >
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton3" runat="server" Text="Volver" OnClick="WebImageButton3_Click" />--%>
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
