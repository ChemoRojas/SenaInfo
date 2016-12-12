<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_instituciones.aspx.cs" Inherits="Reportes_rep_instituciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../img/favicon.ico">
    <title>Reportes :: Senainfo :: Servicio Naciona de Menores</title>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>


</head>
<body role="document" onmousemove="SetProgressPosition(event)">

    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_excel" />
                <asp:PostBackTrigger ControlID="btn_limpiar" />
            </Triggers>
            <ContentTemplate>
                <Ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </Ajax:ModalPopupExtender>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Reportes</li>
                        <li class="active">Reportes de Instituciones</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;<asp:Label ID="lbl_error_estile" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Reportes de Instituciones</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Región :</label>
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddregion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Institución :</label>
                                        </th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddinstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True"></asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" disabled="disabled" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_instituciones.aspx','mpe1a')">
                                    <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Tipo de Instituciones:</label>
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddtipoInstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True">
                                            </asp:DropDownList>

                                        </td>
                                    </tr>

                                    <tr>
                                        <th>
                                            <label for="">Vigencia Proyectos Asociados:</label>
                                        </th>
                                        <td>
                                            <div class="col-md-1">
                                                <label for="">Inicio:</label>
                                            </div>
                                            <div class="col-md-4 ">
                                                <asp:TextBox ID="cal_inicio" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                <Ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ValidationGroup="valError" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="cal_inicio" Type="Date" OnInit="rv_fecha_Init" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="FechaDiag" runat="server" ControlToValidate="cal_inicio" Visible="false" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Diagn&oacute;stico Requerida"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-1">
                                                <label for="">Término:</label>
                                            </div>
                                            <div class="col-md-4 pull-right no-padding">
                                                <asp:TextBox ID="cal_termino" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                <Ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_termino" ValidChars="0123456789-/" />
                                                <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="valError" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="cal_termino" Type="Date" OnInit="rv_fecha_Init" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="FechaDiag" runat="server" ControlToValidate="cal_termino" CssClass="help-block" Display="Dynamic" Visible="false" ErrorMessage="Fecha Diagn&oacute;stico Requerida"></asp:RequiredFieldValidator>
                                            </div>

                                        </td>
                                    </tr>

                                    <tr>
                                        <th>
                                            <label for="">Proyectos Vigentes:</label>
                                        </th>
                                        <td class="text-center">
                                            <asp:RadioButton ID="rdb001" runat="server" Checked="True" GroupName="ProyectosVigentes" Text="Tiene al menos uno" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="rdb002" runat="server" GroupName="ProyectosVigentes" Text="Alguna vez tuvo al menos uno" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="rdb003" runat="server" GroupName="ProyectosVigentes" Text="Nunca ha tenido" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="btn_buscar" ValidationGroup="valError" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click">
                                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btn_limpiar" runat="server" AutoPostback="true" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click" CausesValidation="false">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btn_excel" Visible="false" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click1">
                                        <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                            </asp:LinkButton>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <!--fin col-md-9 -->
                            <div class="col-md-3">

                                <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados para generar el reporte."></asp:Label>
                                    </div>
                                </div>
                                
                            </div>

                            <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                             <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">REPORTE INSTITUCIONES</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                </div>

                            </div>


                            <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                            <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                                    <asp:BoundField DataField="RutInstitucion" HeaderText="Rut"></asp:BoundField>
                                    <asp:BoundField DataField="TipoInstitucion" HeaderText="Tipo Inst."></asp:BoundField>
                                    <asp:BoundField DataField="SistemaAdministrativo" HeaderText="Sist. Adm." Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Comuna" HeaderText="Comuna" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="NombreCorto" HeaderText="Nombre Corto" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Direccion" HeaderText="Direcci&#243;n" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Telefono" HeaderText="Tel&#233;fono" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="EMail" HeaderText="Email" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Fax" HeaderText="Fax" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="CodigoPostal" HeaderText="Cod. Postal" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="RepresentanteLegal" HeaderText="Nombre Rep. Legal" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="RutRepresentante" HeaderText="Run Rep. Legal" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="PersonaContacto" HeaderText="Persona Contacto" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="FechaAniversario" HeaderText="Fecha Aniv." Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="NombrePrimeraAutoridad" HeaderText="Nombre 1&#186; Autoridad" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="CargoPrimeraAutoridad" HeaderText="Cargo" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="NumeroPersonalidadJuridica" HeaderText="N&#186; Pers. Jur&#237;d." Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="ModoInstitucion" HeaderText="Modo" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Documento" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="FechaIngresoAlRegistro" HeaderText="Fecha" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="N&#186; Doc." Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha Doc." Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="IndVigencia" HeaderText="Vigencia" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Personeria" HeaderText="Personer&#237;a" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="RutInterventor" HeaderText="Run Interv." Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="NombreInterventor" HeaderText="Nombre Interventor" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Vigentes" HeaderText="Proy. Vigentes" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Caducos" HeaderText="Proy. Caducos" Visible="False"></asp:BoundField>
                                    <asp:BoundField DataField="Monto" HeaderText="Monto Transf." Visible="False"></asp:BoundField>
                                </Columns>
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                <RowStyle CssClass="caja-tabla table-bordered" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valError" ShowModelStateErrors="False" />
                <footer class="footer" aria-hidden="False">
                    <div class="container">

                        <p>
                            Para tus dudas y consultas, escribe a:<br>
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
