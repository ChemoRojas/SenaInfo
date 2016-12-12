<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_resoluciones.aspx.cs" Inherits="Reportes_Rep_resoluciones" %>

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
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_excel" />
                </Triggers>
                <ContentTemplate>

                    <Ajax:ModalPopupExtender ID="mpe4" BehaviorID="mpe4a" runat="server"
                        TargetControlID="imb_lupa_modal"
                        PopupControlID="modal_bsc_institucion"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal1">
                    </Ajax:ModalPopupExtender>

                    <!--popup de proyecto-->
                    <Ajax:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe4b" runat="server"
                        TargetControlID="imb_lupa_modal2"
                        PopupControlID="modal_bsc_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal3">
                    </Ajax:ModalPopupExtender>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes</a>            </li>
                            <li class="active">Reporte de Resoluciones</li>
                        </ol>
                        <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                            <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reportes Resoluciones</h4>
                            <hr>
                            <div class="row">
                                <div class="col-md-9">
                                    <form class="form-horizontal" action="">
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <th>
                                                    <label for="">Región:</label>
                                                </th>
                                                <td>

                                                    <asp:DropDownList ID="ddregion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" EnableViewState="true" OnSelectedIndexChanged="ddown001_SelectedIndexChanged"></asp:DropDownList>
                                                </td>

                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Institución:</label>
                                                </th>
                                                <td>
                                                    <div class="input-group">
                                                        <asp:DropDownList ID="ddinstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddproyectos_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_resoluciones.aspx', 'mpe4a')" CausesValidation="False">
                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>

                                                    </div>
                                                    <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                                <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">REPORTES</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                        </div>

                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Proyectos:</label>
                                                </th>
                                                <td>
                                                    <div class="input-group">
                                                        <asp:DropDownList ID="ddproyecto" runat="server" CssClass="form-control input-sm" AutoPostBack="True"></asp:DropDownList>
                                                        <asp:LinkButton ID="imb_lupa_modal2" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_resoluciones.aspx','mpe4b')" CausesValidation="False">
                                                            <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                    <!--popup proyecto-->
                                                    <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal3" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                                                            <span aria-hidden="true">&times;</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">REPORTES</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Incluir Proyectos Caducados:</label>
                                                </th>
                                                <td>
                                                    <asp:CheckBox ID="chk_001" runat="server" OnCheckedChanged="chk_001_CheckedChanged" />
                                                </td>
                                            </tr>
                                            <tr><td></td><td>
                                                
                                        <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                        <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>
                                        <asp:LinkButton ID="btn_excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click1"><span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar</asp:LinkButton>

                                                         </td></tr>


                                        </table>
                                    </form>
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
                        </div>

                                <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False"  CssClass="table table-bordered table-hover" Visible="False">
                                    <Columns>
                                        <asp:BoundField DataField="codproyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="nombre" HeaderText="Nombre Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                        <asp:BoundField DataField="nombinst" HeaderText="Nombre Instituci&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="region" HeaderText="Regi&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="comuna" HeaderText="Comuna"></asp:BoundField>
                                        <asp:BoundField DataField="Tematica" HeaderText="Tematica"></asp:BoundField>
                                        <asp:BoundField DataField="Modelo" HeaderText="Modelo"></asp:BoundField>
                                        <asp:BoundField DataField="SistemaAsistencial" HeaderText="SistemaAsistencial"></asp:BoundField>
                                        <asp:BoundField DataField="TipoSubvencion" HeaderText="TipoSubvencion"></asp:BoundField>
                                        <asp:BoundField DataField="TipoProyecto" HeaderText="TipoProyecto"></asp:BoundField>
                                        <asp:BoundField DataField="Departamento" HeaderText="Departamento"></asp:BoundField>
                                        <asp:BoundField DataField="numeroresolucion" HeaderText="N&#186; Resol."></asp:BoundField>
                                        <asp:BoundField DataField="anoresolucion" HeaderText="A&#241;o Resol."></asp:BoundField>
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo"></asp:BoundField>
                                        <asp:BoundField DataField="materia" HeaderText="Materia"></asp:BoundField>
                                        <asp:BoundField DataField="FechaResolucion" HeaderText="Fec.Resol."></asp:BoundField>
                                        <asp:BoundField DataField="fechaconvenio" HeaderText="Fec.Conv"></asp:BoundField>
                                        <asp:BoundField DataField="fechainicio" HeaderText="F. Inicio"></asp:BoundField>
                                        <asp:BoundField DataField="fechatermino" HeaderText="F. T&#233;rmino"></asp:BoundField>
                                        <asp:BoundField DataField="numeroplazas" HeaderText="N&#186; Plazas"></asp:BoundField>
                                        <asp:BoundField DataField="dias_atencion" HeaderText="D&#237;as Atenci&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="sexo" HeaderText="Sexo"></asp:BoundField>
                                        <asp:BoundField DataField="Termino" HeaderText="Termino"></asp:BoundField>
                                        <asp:BoundField DataField="Vigencia" HeaderText="Vigencia"></asp:BoundField>
                                        <asp:BoundField DataField="reporte" HeaderText="Reporte"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                </asp:GridView>
                            
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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
