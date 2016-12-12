<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_ninos.aspx.cs" Inherits="Reportes_Rep_ninos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<html lang="es">
<head id="Head1" runat="server">
    <title>Reportes :: Senainfo :: Servicio Nacional de Menores</title>
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
                <asp:PostBackTrigger ControlID="btn_buscar" />
            </Triggers>
            <ContentTemplate>

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
                <div>
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes</a>            </li>
                            <li class="active">Reporte de niños</li>
                        </ol>
                        <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;<asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reporte de Niños</h4>
                            <hr>
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Región:</label></th>
                                            <td>
                                                <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" EnableViewState="true" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Institución:</label></th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_ninos.aspx','mpe1a')">
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
                                                    <asp:DropDownList ID="ddproyecto" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddproyecto_SelectedIndexChanged" Width="523px" AutoPostBack="True">
                                                        <asp:ListItem selected="true" Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_reportes/Rep_ninos.aspx', 'mpe1b')">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>

                                            </td>
                                        </tr>
                                         <tr>
                                            <th>
                                                <label for="">Tipo:</label></th>
                                            <td>
                                                <asp:DropDownList ID="ddtipo" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="1">Ingresos</asp:ListItem>
                                                    <asp:ListItem Value="2">Egresos</asp:ListItem>
                                                    <asp:ListItem Value="3">Vigentes</asp:ListItem>
                                                    <asp:ListItem Value="4">Atendidos</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <th>
                                                <label for="">Fecha de búsqueda:</label></th>
                                            <td>
                                                <div class="col-md-1">
                                                    <label for="">Inicio:</label>
                                                </div>
                                                <div class="col-md-4 no-padding">
                                                    <asp:TextBox ID="cal_inicio" runat="server" placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha-large input-sm"  />
                                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block" Display="Dynamic" ValidationGroup="valError" ErrorMessage="Fecha Invalida" ControlToValidate="cal_inicio" Type="Date" OnInit="rv_fecha_Init" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="FechaDiag" runat="server" ControlToValidate="cal_inicio" CssClass="help-block" Display="Dynamic" ErrorMessage="">
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="">Término</label>
                                                </div>
                                                <div class="col-md-4 no-padding pull-right">
                                                    <asp:TextBox ID="cal_Termino" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa"  />
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="cal_Termino" CssClass="help-block" Display="Dynamic" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" ValidationGroup="valError" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_Termino" ValidChars="0123456789-/" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal_Termino" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag">
                                                    </asp:RequiredFieldValidator>
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_Termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />

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
                                    <h4 class="modal-title">REPORTE NIÑOS</h4>
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
                                    <h4 class="modal-title">REPORTE NIÑOS</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>
                            <!--fin popup-->


                            <div class="row">
                                <div>
                                   
                                            <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False"  CssClass="table  table-bordered table-hover ">
                                                <Columns>
                                                    <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst.">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nombinst" HeaderText="Nombre Inst.">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nombproy" HeaderText="Nombre Proyecto">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="codnino" HeaderText="Cod. Ni&#241;o">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="apellido_paterno" HeaderText="Ap. Paterno">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="apellido_materno" HeaderText="Ap. Materno">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nombres" HeaderText="Nombres">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="fechanacimiento" HeaderText="F. Nacim." DataFormatString="{0:d}" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
                                                        <HeaderStyle Wrap="True" />
                                                        <FooterStyle Wrap="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="rut" HeaderText="RUN">
                                                        <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
                                                        <HeaderStyle Wrap="False" />
                                                        <FooterStyle Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="sexo" HeaderText="Sexo">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="fechaingreso" HeaderText="F. Ingreso" DataFormatString="{0:d}" HtmlEncode="False">
                                                        <ItemStyle  Font-Strikeout="False" Width="60px" Wrap="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TipoAtencion" HeaderText="Tipo de Atenci&#243;n">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CalidadJuridica" HeaderText="Calidad Juridica">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DireccionNino" HeaderText="Domicilio">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegionNino" HeaderText="Regi&#243;n">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="comuna" HeaderText="Comuna">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ConQuienVive" HeaderText="Con Quien Vive">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TipoSolicitanteIngreso" HeaderText="Tipo Solicitante Ingreso">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Tribunal" HeaderText="Tribunal">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Ruc" HeaderText="RUC">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Rit" HeaderText="RIT">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CausalIngreso_1" HeaderText="Causal Ingreso 1">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CausalIngreso_2" HeaderText="Causal Ingreso 2">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CausalIngreso_3" HeaderText="Causal Ingreso 3">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="fechaegreso" HeaderText="F. Egreso">
                                                        <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TipoCausalEgreso" HeaderText="Tipo Causal Egreso">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CausalEgreso" HeaderText="Causa lEgreso">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ConQuienEgresa" HeaderText="Con Quien Egresa">
                                                        <ItemStyle Font-Size="11px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="vigencia" HeaderText="Vigente a Hoy">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="desde" HeaderText="desde" DataFormatString="{0:d}" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" Width="60px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="hasta" HeaderText="hasta" DataFormatString="{0:d}" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" Width="60px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="reporte" HeaderText="reporte">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GradoCumplimiento" HeaderText="Grado Cumplimiento">
                                                    </asp:BoundField>
                                                </Columns>
                                                <HeaderStyle CssClass="table-borderless titulo-tabla" />
                                                <RowStyle CssClass="table-bordered caja-tabla"  />
                                                <EditRowStyle BackColor="#2461BF" Font-Size="11px" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Names="Arial" Font-Size="11px" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valError" />
                                </div>
                            </div>
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
                    </footer>

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
