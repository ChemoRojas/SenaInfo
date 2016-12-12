<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_eventos.aspx.cs" Inherits="Reportes_Rep_Eventis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Reportes :: SenaInfo :: Servicion Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>

</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_excel" />
                <asp:PostBackTrigger ControlID="btn_buscar" />
                <asp:PostBackTrigger ControlID="btnImprimir" />
            </Triggers>
            <ContentTemplate>
                <div>
                    <ajax:ModalPopupExtender
                        ID="mpe1"
                        BehaviorID="mpe1a"
                        runat="server"
                        TargetControlID="imb_lupa_modal"
                        PopupControlID="modal_bsc_institucion"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal1">
                    </ajax:ModalPopupExtender>

                    <ajax:ModalPopupExtender
                        ID="ModalPopupExtender1"
                        BehaviorID="mpe1b"
                        runat="server"
                        TargetControlID="imb_lupa_modal2"
                        PopupControlID="modal_bsc_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal2">
                    </ajax:ModalPopupExtender>
                    <uc1:menu_colgante runat="server" ID="menu_colgante" />
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes</a>            </li>
                            <li class="active">Reportes de plan de intervenci�n</li>
                        </ol>
                        <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                            <asp:Label ID="lbl_error" runat="server" Visible="False">No se han encontrado registros coincidentes.</asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reportes de plan de Intervenci�n</h4>
                            <hr />
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Regi�n :</label></th>
                                            <td>
                                                <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Instituci�n :</label></th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion', '../mod_reportes/Rep_eventos.aspx','mpe1a' )">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Proyecto :</label></th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddproyecto" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_eventos.aspx','mpe1b')">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Inicio :</label></th>
                                            <td>
                                                <div class="col-md-5 no-padding">
                                                    <asp:TextBox ID="cal_inicio" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" Placeholder="dd-mm-aaaa" />
                                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" ControlToValidate="cal_inicio" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" CssClass="help-block" Display="Dynamic" Type="Date" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal_inicio" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 text-right">
                                                    <label for="">
                                                        T�rmino :</label>
                                                </div>

                                                <div class="col-md-5 no-padding pull-right">
                                                    <asp:TextBox ID="cal_Termino" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" Placeholder="dd-mm-aaaa" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_Termino" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_Termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal_Termino" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag">                                                    </asp:RequiredFieldValidator>
                                                </div>

                                            </td>
                                            <tr>
                                                <th>
                                                    <label for="">
                                                        C�digo Plan de Intervenci�n :</label>
                                                </th>
                                                <td >
                                                    <div class="col-md-7">
                                                        <asp:RadioButtonList ID="RadioButtonList1" CssClass=" input-sm" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" DataValueField="0" align="center" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                            <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                                                            <asp:ListItem Value="1">Cod. PII</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <div class="col-md-5 no-padding">
                                                        <asp:TextBox ID="cPII" runat="server" AutoPostBack="True" CssClass="pull-right form-control input-sm" placeholder="Ingrese C�digo" ONVALUECHANGE="cPII_ValueChange" />
                                                    </div>

                                                    <%-- <ajax:MaskedEditExtender ID="MaskedEditExtender302" runat="server" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99999999999" MaskType="None" TargetControlID="cPII" />--%>
                                                </td>
                                            </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Detalle por:</label>
                                            </th>
                                            <td>
                                                <asp:RadioButtonList align="center" ID="RadioButtonList2" RepeatDirection="Horizontal" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Selected="True" Value="0">Eventos de Intervenci�n</asp:ListItem>
                                                    <asp:ListItem Value="1">Areas de Intervenci�n</asp:ListItem>
                                                    <asp:ListItem Value="2">Areas de Intervenci�n Excel</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>

                                                <asp:LinkButton ID="btn_buscar" runat="server" class="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span> Buscar</asp:LinkButton>
                                                <asp:LinkButton ID="btn_limpiar" runat="server" class="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click" ValidationGroup="valError"><span class="glyphicon glyphicon-remove-sign"></span> Limpiar </asp:LinkButton>
                                                <%-- <asp:LinkButton ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Visible="false"> Imprimir</asp:LinkButton>--%>
                                                <asp:LinkButton ID="btn_excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click"><span class="glyphicon glyphicon-floppy-save"></span> Exportar</asp:LinkButton>
                                                <asp:LinkButton ID="btnImprimir" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btnImprimir_Click"><span class="glyphicon glyphicon-print"></span> Imprimir</asp:LinkButton>

                                            </td>
                                        </tr>

                                    </table>
                                </div>
                                <!--fin col-md-9 -->
                                <div class="col-md-3">
                                    <div class="panel-info panel-primary-info">
                                        <div class="panel-heading">
                                            Informaci�n
                                        </div>
                                        <div class="panel-footer">
                                            <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los par�metros solicitados para generar el reporte."></asp:Label>
                                        </div>
                                    </div>



                                </div>
                            </div>
                            <!--cierra Row-->
                            <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                    <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">INSTITUCION</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>

                          
                            <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal2" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">PROYECTO</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>

                            </div>
                                    <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="2" CssClass="table table-bordered table-hover" GridLines="None">
                                        <Columns>
                                            <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                            <asp:BoundField DataField="nombinst" HeaderText="Nombre Inst."></asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre Proyecto"></asp:BoundField>
                                            <asp:BoundField DataField="CodRegion" HeaderText="Cod. Regi�n"></asp:BoundField>
                                            <asp:BoundField DataField="CodNino" HeaderText="Cod. Ni�o"></asp:BoundField>
                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Ap. Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="apellido_materno" HeaderText="Ap. Materno"></asp:BoundField>
                                            <asp:BoundField DataField="nombres" HeaderText="Nombres"></asp:BoundField>
                                            <asp:BoundField DataField="fechanacimiento" HeaderText="F. Nacim."></asp:BoundField>
                                            <asp:BoundField DataField="run" HeaderText="RUN"></asp:BoundField>
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="F. Ingreso"></asp:BoundField>
                                            <asp:BoundField DataField="FechaEgreso" HeaderText="F.  Egreso"></asp:BoundField>
                                            <asp:BoundField DataField="Grupo" HeaderText="Grupo"></asp:BoundField>
                                            <asp:BoundField DataField="DescripcionGrupo" HeaderText="Desc. Grupo"></asp:BoundField>
                                            <asp:BoundField DataField="CodPlanIntervencion" HeaderText="PII"></asp:BoundField>
                                            <asp:BoundField DataField="FechaElaboracionPII" HeaderText="Fecha Elaboracion PII"></asp:BoundField>
                                            <asp:BoundField DataField="EstadoPlan" HeaderText="Estado "></asp:BoundField>
                                            <asp:BoundField DataField="Grado" HeaderText="Grado Cumpl."></asp:BoundField>
                                            <asp:BoundField DataField="FechaTerminoRealPII" HeaderText="F. Termino PII"></asp:BoundField>
                                            <asp:BoundField DataField="TipoIntervencion" HeaderText="Tipo Intervencion"></asp:BoundField>
                                            <asp:BoundField DataField="Nivel" HeaderText="Nivel"></asp:BoundField>
                                            <asp:BoundField DataField="FechaEvento" HeaderText="FechaEvento"></asp:BoundField>
                                            <asp:BoundField DataField="TipoEvento" HeaderText="TipoEvento"></asp:BoundField>
                                            <asp:BoundField DataField="DescripcionEvento" HeaderText="Descripcion Evento"></asp:BoundField>
                                            <asp:BoundField DataField="Clasif_Evento" HeaderText="Clasif. Evento"></asp:BoundField>
                                            <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                            <asp:BoundField DataField="desde" HeaderText="desde"></asp:BoundField>
                                            <asp:BoundField DataField="hasta" HeaderText="hasta"></asp:BoundField>
                                            <asp:BoundField DataField="reporte" HeaderText="reporte"></asp:BoundField>
                                            <asp:BoundField DataField="Tpaterno" HeaderText="Ap. Paterno Tco"></asp:BoundField>
                                            <asp:BoundField DataField="Tmaterno" HeaderText="Ap. Materno Tco"></asp:BoundField>
                                            <asp:BoundField DataField="Tnombres" HeaderText="Nombres Tco."></asp:BoundField>
                                            <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Actualizaci�n"></asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                    </asp:GridView>

                                
                        
                    </div>
                </div>

                </span>
              
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
        <footer class="footer">
            <div class="container">
                <p>
                    Para tus dudas y consultas, escribe a:
                <br>
                    mesadeayuda@sename.cl
                </p>
            </div>
        </footer>
    </form>
</body>
</html>