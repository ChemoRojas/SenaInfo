<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_EvProyecto.aspx.cs" Inherits="mod_reportes_Rep_EvProyecto" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>




<html>
<head id="Head1" runat="server">
    <title>Reporte :: SenaInfo :: Servicio Nacional de Menores</title>


    <script type="text/javascript" src="../Script/jquery.min.js"></script>

    <link rel="icon" href="../img/favicon.ico">
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>

    <style type="text/css">
        .auto-style2 {
            width: 198px;
        }
    </style>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
                <asp:PostBackTrigger ControlID="ImageButton1" />
                <asp:PostBackTrigger ControlID="btnExportaExcelAsistencia" />
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

                <Ajax:ModalPopupExtender
                    ID="ModalPopupExtender1"
                    BehaviorID="mpe1b"
                    runat="server"
                    TargetControlID="imb_lupa_modal2"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </Ajax:ModalPopupExtender>
                <div>
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes</a>            </li>
                            <li class="active">Reporte de Eventos del Proyecto</li>
                        </ol>
                        <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
 <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reporte de Eventos del Proyecto</h4>
                            <hr>
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Institución:</label></th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlproyecto_SelectIndex_changed">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion', '../mod_reportes/Rep_ninos.aspx', 'mpe1a')">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Proyecto:</label></th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddproyecto" runat="server" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_EvProyecto.aspx','mpe1b')">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>

                                            <th>
                                                <label for="">Período:</label></th>
                                            <td>
                                                <div class="col-md-3 no-padding">
                                                    <asp:DropDownList ID="ddown_Mes" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="0">Seleccionar mes</asp:ListItem>
                                                        <asp:ListItem Value="1">Enero</asp:ListItem>
                                                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="4">Abril</asp:ListItem>
                                                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="6">Junio</asp:ListItem>
                                                        <asp:ListItem Value="7">Julio</asp:ListItem>
                                                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-3 no-padding">
                                                    <asp:TextBox ID="txtAno" runat="server" MaxLength="4" placeholder="año" CssClass="form-control input-sm">2015</asp:TextBox>
                                                </div>
                                                <div class="col-md-3 ">
                                                    <label for="">
                                                        <asp:Label ID="lbl_tipo" runat="server" Text="Tipo :" Visible="False" for=""></asp:Label>
                                                        <asp:Label ID="lbl_fechaEvento" runat="server" Text="Fecha Evento :" Visible="False"></asp:Label>
                                                    </label>
                                                </div>
                                                <div class="col-md-3 no-padding">

                                                    <asp:TextBox ID="cal_inicio" AutoPostBack="true" runat="server" EDITABLE="False" CssClass="form-control form-control-fecha-large input-sm" Placeholder="dd-mm-aaaa" ONVALUECHANGED="cal_inicio_ValueChanged" Visible="False" />
                                                    <Ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" ControlToValidate="cal_inicio" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" Type="Date" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal_inicio" CssClass="help-block" Display="Dynamic" ErrorMessage="" ValidationGroup="FechaDiag">
                                                    </asp:RequiredFieldValidator>
                                                    <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

                                                </div>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td></td>
                                            <td>

                                                <asp:LinkButton ID="btn_buscar" ValidationGroup="valError" CssClass="btn btn-danger btn-sm fixed-width-button" runat="server" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                                <asp:LinkButton ID="btn_limpiar" CssClass="btn btn-info btn-sm fixed-width-button pull-right" runat="server" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>
                                                <asp:LinkButton ID="ImageButton1" CssClass="btn btn-success btn-sm fixed-width-button" runat="server" OnClick="ImageButton1_Click1"><span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar</asp:LinkButton>

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


                            </div>
                            <!--cierra Row-->
                            <!--Row para desplegar tabla con datos-->
                            <!--popup-->
                            <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                            <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">REPORTE EVENTOS DEL PROYECTO</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>

                            <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                            <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">REPORTE EVENTOS DEL PROYECTO</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>
                            <!--fin popup-->


                            <div class="row">
                                <%--<div class="table-bordered table-hover">--%>
                                <div>
                                    <table class="table table table-bordered table-hover">


                                        <tbody>
                                            <asp:GridView ID="grd001" runat="server" OnRowEditing="grd001_RowEditing" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">

                                                <Columns>
                                                    <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                                    <asp:BoundField DataField="DescTipoEvento" HeaderText="Tipo Evento"></asp:BoundField>
                                                    <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" DataFormatString="{0:d}"></asp:BoundField>
                                                    <asp:BoundField DataField="Region" HeaderText="Regi&#243;n"></asp:BoundField>
                                                    <asp:BoundField DataField="Comuna" HeaderText="Comuna"></asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n"></asp:BoundField>
                                                    <asp:BoundField DataField="CantAsistNinosAdolecentesFemenino" HeaderText="Cantidad de Ni&#241;os Femenino"></asp:BoundField>
                                                    <asp:BoundField DataField="CantAsistNinosAdolecentesMasculino" HeaderText="Cantidad de Ni&#241;os Masculinos"></asp:BoundField>
                                                    <asp:BoundField DataField="CantAsistAdultoFemenino" HeaderText="Cantidad Adultos Femeninos"></asp:BoundField>
                                                    <asp:BoundField DataField="CantAsistAdultoMasculino" HeaderText="Cantidad Adultos Masculinos"></asp:BoundField>
                                                    <asp:BoundField DataField="CantidadAsistentes" HeaderText="Cantidad de Asistentes"></asp:BoundField>
                                                    <asp:CommandField EditText="Ni&#241;os Asistentes" InsertVisible="False" ShowCancelButton="False"
                                                        ShowEditButton="True"></asp:CommandField>
                                                    <asp:BoundField DataField="ICodEventosProyectos" HeaderText="ICod Ev.Proy."></asp:BoundField>
                                                    <asp:BoundField DataField="FechaActualizacion" DataFormatString="{0:d}" HeaderText="Fecha Actualizacion"></asp:BoundField>
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </tbody>
                                        <tfoot>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlAsistencia" runat="server" Height="100%" Visible="False" Width="100%">
                            <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                <tr>
                                    <td class="auto-style2">
                                        <label for="">Tipo de Evento</label></td>
                                    <td>&nbsp<asp:TextBox ID="txtTipoEvento" runat="server" CssClass="form-control-fecha input-sm" Width="441px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <label for="">Evento</label></td>
                                    <td>&nbsp;<asp:TextBox ID="txtFechaEvento" runat="server" CssClass="form-control-fecha input-sm" Width="441px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <label for="">Región</label></td>
                                    <td>&nbsp;<asp:TextBox ID="txtRegion" runat="server" CssClass="form-control-fecha input-sm" Width="441px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <label for="">Comuna</label></td>
                                    <td>&nbsp;<asp:TextBox ID="txtComuna" runat="server" CssClass="form-control-fecha input-sm" Width="441px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <label for="">Descripción</label></td>
                                    <td>&nbsp;<asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control-fecha input-sm" Width="441px"></asp:TextBox></td>
                                </tr>
                            </table>
                            <br />
                            <asp:Label ID="lblCantidadAsistentes" runat="server" CssClass="texto_form" Text="lblcantidadVigentes" Width="70%" Font-Strikeout="False"></asp:Label>
                            &nbsp;
                                        <%--<asp:ImageButton ID="btnExportaExcelAsistencia" runat="server" ImageUrl="~/images/Excel1.bmp" OnClick="btnExportaExcelAsistencia_Click" />--%>
                            <asp:LinkButton ID="btnExportaExcelAsistencia" runat="server" OnClick="btnExportaExcelAsistencia_Click1" CssClass="btn btn-success btn-sm"><span class="glyphicon glyphicon-floppy-save"></span></asp:LinkButton>

                            <asp:Button ID="btn_VolverListadoEventos" runat="server" Text="Volver al Listado de Eventos" Width="206px" OnClick="btn_VolverListadoEventos_Click" CssClass="tytbtn" Visible="False" />


                            <asp:GridView ID="grdAsistencia" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-bordered table-hover">

                                <Columns>
                                    <asp:BoundField DataField="ICodEventoProyectoAsistenciaNinos"></asp:BoundField>
                                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                    <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno">
                                        <HeaderStyle HorizontalAlign="Left" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno">
                                        <HeaderStyle HorizontalAlign="Left" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                        <HeaderStyle HorizontalAlign="Left" />

                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Presente" Visible="False">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkPresente" runat="server" Enabled="False" />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ICodEventosProyectos"></asp:BoundField>
                                </Columns>
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <HeaderStyle CssClass="titulo-tabla" />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />

                            </asp:GridView>
                        </asp:Panel>
                    </div>

                </div>
                <footer class="footer">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                <br>
                            mesadeayuda@sename.cl
                        </p>
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
        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="valError" runat="server" />
    </form>
</body>
</html>
