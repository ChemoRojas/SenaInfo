<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_proyectos.aspx.cs" Inherits="Reportes_Rep_proyectos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>



<html lang="es">
<head id="Head1" runat="server">


    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../img/favicon.ico">

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
        &nbsp;<uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptLocalization="true" EnableScriptGlobalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_excel" />
            </Triggers>
            <ContentTemplate>

                <!--busqueda popup instituciones-->
                <Ajax:ModalPopupExtender ID="mpe4" BehaviorID="mpe4a" runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </Ajax:ModalPopupExtender>

                <Ajax:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe4b" runat="server"
                    TargetControlID="LinkButton1"
                    PopupControlID="MostrarModalProyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </Ajax:ModalPopupExtender>
                <!--busqueda popup proyecto-->

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li><a href="#">Reportes</a></li>
                        <li class="active">Proyectos</li>
                    </ol>

                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;<asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Reportes de Proyectos</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Región:</label>
                                        </th>
                                        <td>

                                            <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddinstitucion_SelectIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>

                                        </td>

                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="label">Institución:</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlproyecto_SelectIndex_changed" CssClass="form-control input-sm"></asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion( 'Plan de Intervencion', '../mod_reportes/Rep_proyectos.aspx', 'mpe4a')" CausesValidation="False">
                            <span class="glyphicon glyphicon-question-sign"></span>  
                                                </asp:LinkButton>

                                                <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                                    <div class="modal-header header-modal">
                                                        <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                            <span aria-hidden="true">&times;</span>
                                                        </asp:LinkButton>
                                                        <h4 class="modal-title">REPORTES DE PROYECTO</h4>
                                                    </div>
                                                    <div>
                                                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--popup proyecto-->
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Proyecto :</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddproyecto" runat="server" CssClass="form-control input-sm" AutoPostBack="True" Width="530px"></asp:DropDownList>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_proyectos.aspx','mpe4b')" CausesValidation="False">
                            <span class="glyphicon glyphicon-question-sign"></span>  
                                                </asp:LinkButton>
                                                <div class="popupConfirmation" id="MostrarModalProyecto" style="display: none">
                                                    <div class="modal-header header-modal">
                                                        <asp:LinkButton ID="btnCerrarModal2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                            <span aria-hidden="true">&times;</span>
                                                        </asp:LinkButton>
                                                        <h4 class="modal-title">REPORTES DE PROYECTO</h4>
                                                    </div>
                                                    <div>
                                                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                                    </div>
                                                </div>
                                            </div>


                                        </td>

                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Tipo Proyectos :
                                            </label>
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddtipoProyecto" runat="server" AutoPostBack="True" class="form-control input-sm">
                                                <asp:ListItem Value="1">Leyes 1.385 y 20.032</asp:ListItem>
                                                <asp:ListItem Value="2">Emergencia, Estudios y Apoyo</asp:ListItem>
                                                <asp:ListItem Value="3">Administraciones Directas</asp:ListItem>
                                                <asp:ListItem Value="-1">Todos</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <th>
                                            <label for="">
                                                Período Proyectos Buscados:
                                            </label>
                                        </th>

                                        <td>
                                            <div class="col-md-1">
                                                <label for="">
                                                    Inicio :</label>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="cal_inicio" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" />
                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ControlToValidate="cal_inicio" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" ValidationGroup="valError" CssClass="help-block" Display="Dynamic" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal_inicio" ErrorMessage="Fecha Requerida" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag" Visible="false">
                                                </asp:RequiredFieldValidator>
                                                <Ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            </div>
                                            <div class="col-md-1">
                                                <label for="label">Término:</label>

                                            </div>
                                            <div class="col-md-4 pull-right no-padding">
                                                <asp:TextBox ID="cal_termino" runat="server" class="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" />
                                                <label for="label">
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="cal_termino" CssClass="help-block" Display="Dynamic" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" ValidationGroup="valError" />
                                                </label>
                                                <Ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal_termino" ValidChars="0123456789-/" />
                                                <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal_termino" ErrorMessage="Fecha Requerida" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag"></asp:RequiredFieldValidator>
                                            </div>


                                        </td>

                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Tipo de Reporte Proyectos :</label></th>
                                        <td class="text-center">
                                            <asp:RadioButton ID="rdb001" runat="server" Checked="True" GroupName="tipo" Text="Vigentes" />
                                            &nbsp;&nbsp; &nbsp;&nbsp;
                                    <asp:RadioButton ID="rdb002" runat="server" GroupName="tipo" Text="Caducados" />
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ValidationGroup="valError" CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_buscar" runat="server" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-success btn-sm fixed-width-button" ID="btn_excel" runat="server" OnClick="btn_excel_Click1"><span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar</asp:LinkButton>


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

                        <!--cierra Row-->
                        <asp:ValidationSummary ValidationGroup="valError" ID="ValidationSummary1" runat="server" />


                        
                                <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="table table-bordered table-hover">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                        <asp:BoundField DataField="NombreInstitucion" HeaderText="Nombre Inst."></asp:BoundField>
                                        <asp:BoundField DataField="CodRegion" HeaderText="Regi&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="NombreSistemaAsistencial" HeaderText="Sist. Asistencial"></asp:BoundField>
                                        <asp:BoundField DataField="Tematica" HeaderText="Tem&#225;tica"></asp:BoundField>
                                        <asp:BoundField DataField="nModelo" HeaderText="Modelo"></asp:BoundField>
                                        <asp:BoundField DataField="nTipoProyecto" HeaderText="Tipo Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="NumeroPlazas" HeaderText="Plazas"></asp:BoundField>
                                        <asp:BoundField DataField="NombreDepartamentosSename" HeaderText="Depto. Sename"></asp:BoundField>
                                        <asp:BoundField DataField="EdadMinima" HeaderText="Edad M&#237;n."></asp:BoundField>
                                        <asp:BoundField DataField="EdadMaxima" HeaderText="Edad M&#225;x."></asp:BoundField>
                                        <asp:BoundField DataField="nsexo" HeaderText="Sexo"></asp:BoundField>
                                        <asp:BoundField DataField="Direccion" HeaderText="Direcci&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="Comuna" HeaderText="Comuna"></asp:BoundField>
                                        <asp:BoundField DataField="Telefono" HeaderText="Tel&#233;fono"></asp:BoundField>
                                        <asp:BoundField DataField="Mail" HeaderText="Email"></asp:BoundField>
                                        <asp:BoundField DataField="director" HeaderText="Director"></asp:BoundField>
                                        <asp:BoundField DataField="FechaInicio" HeaderText="F.  Inicio"></asp:BoundField>
                                        <asp:BoundField DataField="FechaTermino" HeaderText="F. T&#233;rmino"></asp:BoundField>
                                        <asp:BoundField DataField="IndVigencia" HeaderText="Vigencia"></asp:BoundField>
                                        <asp:BoundField DataField="nino_i" HeaderText="Ingresos"></asp:BoundField>
                                        <asp:BoundField DataField="nino_e" HeaderText="Egresos"></asp:BoundField>
                                        <asp:BoundField DataField="nino_v" HeaderText="Vigentes"></asp:BoundField>
                                        <asp:BoundField DataField="nino_a" HeaderText="Atendidos"></asp:BoundField>
                                        <asp:BoundField DataField="desde" HeaderText="Per&#237;odo Reporte Desde" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="hasta" HeaderText="Hasta" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="reporte" HeaderText="Tipo Reporte"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                    <HeaderStyle CssClass="titulo-tabla" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                </asp:GridView>
                            


                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel">
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
                    Para tus dudas y consultas, escribe a:<br>
                    mesadeayuda@sename.cl
                </p>
            </div>
        </footer>
    </form>
</body>

</html>
