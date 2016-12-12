<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="~/mod_reportes/Rep_ninosvisitados.aspx.cs" Inherits="Reportes_Rep_ninos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html lang="es">
<head id="Head1" runat="server">
    <title>Reportes :: Senainfo :: Servicio Nacional de Menores</title>




    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <%--<script src="../js/bootstrap.min.js"></script>--%>
    <%--<script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-1.11.1.min.js"></script>--%>

    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <link rel="icon" href="../images/favicon.ico">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>

    <style type="text/css">
        .auto-style2 {
            width: 23%;
        }
    </style>
</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <div>
            <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="ImageButton12" />

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
                        ID="mpe1proyecto"
                        BehaviorID="mpe1proyecto"
                        runat="server"
                        TargetControlID="imb_lupa_modal_proyecto"
                        PopupControlID="modal_bsc_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal2">
                    </ajax:ModalPopupExtender>


                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes </a></li>
                            <li class="active">Niños Visitados </li>
                        </ol>
                        <div id="alerts" runat="server" class="alert alert-warning text-center" role="alert" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;<asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <%-- <div class="col-md-12  table-responsive">--%>
                        <div class="well">
                            <h4 class="subtitulo-form">Reporte Niños Visitados</h4>
                            <hr />
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Región :</label>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Institución :</label></th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_ninosvisitados.aspx','mpe1a')">
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
                                                    <asp:DropDownList ID="ddproyecto" runat="server" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal_proyecto" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_ninosvisitados.aspx','mpe1a')">
                                                  <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Fecha Búsqueda(Fecha de Registro)</label></th>
                                            <td>
                                                <div class="col-md-1">
                                                    <label for="">
                                                        Inicio:</label>
                                                </div>
                                                <div class="col-md-4 no-padding">
                                                    <asp:TextBox ID="cal_inicio" runat="server" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"  />
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" ControlToValidate="cal_inicio"  OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" Type="Date" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal_inicio" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="">
                                                        Término</label>
                                                </div>
                                                <div class="col-md-4 no-padding pull-right">
                                                    <asp:TextBox ID="cal_Termino" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa"  />
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="cal_Termino" CssClass="help-block" Display="Dynamic" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_Termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_Termino" ValidChars="0123456789-/" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal_Termino" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag"></asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                
                                        <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click" ValidationGroup="valError"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp; Buscar</asp:LinkButton>
                                        <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar</asp:LinkButton>
                                        <asp:LinkButton ID="ImageButton12" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="ImageButton12_Click"><span class="glyphicon glyphicon-floppy-save"></span>&nbsp; Exportar</asp:LinkButton>
                                    
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
                            <!--popup-->
                            <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                    <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">REPORTE NIÑOS VISITADOS</h4>
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
                                    <h4 class="modal-title">REPORTE NIÑOS VISITADOS</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>
                        </div>   
                                    <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-hover" >
                                        <Columns>
                                            <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst.">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nombinst" HeaderText="Nombre Inst.">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nombproy" HeaderText="Nombre Proyecto">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodRegion" HeaderText="Cod. Región">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="comuna" HeaderText="Comuna">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="codnino" HeaderText="Cod. Niño">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Ap. Paterno">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="apellido_materno" HeaderText="Ap. Materno">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nombres" HeaderText="Nombres">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fechanacimiento" DataFormatString="{0:d}" HeaderText="F. Nacim." HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
                                                <HeaderStyle Wrap="True" />
                                                <FooterStyle Wrap="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="rut" HeaderText="RUN">
                                                <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
                                                <HeaderStyle Wrap="False" />
                                                <FooterStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fechaRegistro" DataFormatString="{0:d}" HeaderText="F. Registro" HtmlEncode="False">
                                                <ItemStyle Font-Size="11px" Font-Strikeout="False" Width="70px" Wrap="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Madre" HeaderText="Madre">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Padre" HeaderText="Padre">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Otro_Femenino" HeaderText="Otro Femenino" />
                                            <asp:BoundField DataField="Otro_Masculino" HeaderText="Otro Masculino" />
                                            <asp:BoundField DataField="desde" DataFormatString="{0:d}" HeaderText="desde" HtmlEncode="False">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="hasta" DataFormatString="{0:d}" HeaderText="hasta" HtmlEncode="False">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="reporte" HeaderText="reporte">
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                    </asp:GridView>
                                
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
           
        </div>
    </form>
</body>

</html>
