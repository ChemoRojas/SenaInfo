<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_Diag_Ninos.aspx.cs" Inherits="mod_reportes_Rep_Diag_Ninos" %>

<%@ Register Src="Rep_Diag_Ninos/DIAG_SOCIAL.ascx" TagName="DIAG_SOCIAL" TagPrefix="uc3" %>
<%@ Register Src="Rep_Diag_Ninos/DIAG_MALTRATO.ascx" TagName="DIAG_MALTRATO" TagPrefix="uc4" %>
<%@ Register Src="Rep_Diag_Ninos/DIAG_PEORES_FORMA.ascx" TagName="DIAG_PEORES_FORMA" TagPrefix="uc5" %>
<%@ Register Src="Rep_Diag_Ninos/DIAG_PSICOLOGICO.ascx" TagName="DIAG_PSICOLOGICO" TagPrefix="uc6" %>

<%@ Register Src="Rep_Diag_Ninos/DIAG_DROGA.ascx" TagName="DIAG_DROGA" TagPrefix="uc1" %>
<%@ Register Src="Rep_Diag_Ninos/DIAG_ESCOLAR.ascx" TagName="DIAG_ESCOLAR" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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

    <title>Reporte :: SenaInfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>



    <script language="javascript" type="text/javascript">
        function MostrarModalInstitucionDEMO(param, dir, modalPopupExtender) {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=" + param + "&dir=" + dir;
            objIframe.height = "400px";
            objIframe.width = "1024";
            $find(modalPopupExtender).show();
            return false;
        }
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 666px;
        }
    </style>
</head>
<body onmousemove="SetProgressPosition(event)">

    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
            </Triggers>
            <ContentTemplate>
                <div class="container theme-showcase" role="main">

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
                        ID="mpe1b"
                        BehaviorID="mpe1b"
                        runat="server"
                        TargetControlID="imb_lupa_modal2"
                        PopupControlID="modal_bsc_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal2">
                    </ajax:ModalPopupExtender>

                    <ol class="breadcrumb">
                        <!--<li><a href="#">Home</a></li>-->
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li><a href="#">Reportes</a></li>
                        <li class="active">Reportes de niños</li>
                    </ol>
                    <div id="alerts" runat="server" class="alert alert-warning text-center" role="alert" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                      <asp:Label ID="lbl_error" runat="server" Visible="False">No se han encontrado registros coincidentes.</asp:Label>

                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Reportes Diagnóstico Niños</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Institución:</label></th>
                                        <td >
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_Diag_Ninos.aspx','mpe1a')">
                                     <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Proyecto:</label>
                                        </th>
                                        <td >
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" CssClass="form-control input-sm" Width="523px">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_Diag_Ninos.aspx','mpe1b')">
                                   <span class="glyphicon glyphicon-question-sign"></span></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Período :</label></th>
                                        <td>
                                        
                                        <div class="col-md-6 no-padding">
                                            <asp:DropDownList ID="ddown_MesCierre" runat="server" CssClass="form-control  input-sm" AutoPostBack="True">
                                                <asp:ListItem Value="0">Seleccione mes</asp:ListItem>
                                                <asp:ListItem Value="01">Enero</asp:ListItem>
                                                <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                                <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                <asp:ListItem Value="06">Junio</asp:ListItem>
                                                <asp:ListItem Value="07">Julio</asp:ListItem>
                                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                       
                                        <div class="col-md-6 no-padding pull-right">
                                            <asp:DropDownList ID="ddown_AnoCierre" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                        </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Tipo:</label>&nbsp;</th>
                                        <td >
                                            <asp:DropDownList ID="ddown_tipo" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td colspan="3">
                                            <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click">  <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>

                                            <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click">  <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>


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
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese todos los parámetros solicitados para generar el reporte."></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <!--cierra Row-->
                        <!--Row para desplegar tabla con datos-->
                        <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                                                <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnExpandir" CssClass="close" aria-label="Close" runat="server" Text="Expandir" CausesValidation="false" OnClientClick="return MostrarModalInstitucionDEMO('Plan de Intervencion','../mod_reportes/Rep_Diag_Ninos.aspx','mpe1a')">
	                                                <span aria-hidden="true" class="glyphicon glyphicon-resize-full" ></span>
                                </asp:LinkButton>

                                <h4 class="modal-title">REPORTES DIAGNOSTICO NIÑOS</h4>
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
                                <h4 class="modal-title">REPORTES DIAGNOSTICO NIÑOS</h4>
                            </div>

                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                        <div class="row">
                            <%-- <div class="col-md-12 caja-tabla table-responsive">--%>
                            <table class="table table table-bordered table-hover">
                                <caption></caption>
                                <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="2" GridLines="None" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                        <asp:BoundField DataField="nombinst" HeaderText="Nombre Inst."></asp:BoundField>
                                        <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="nombre" HeaderText="Nombre Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="CodRegion" HeaderText="Cod. Regi&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="CodNino" HeaderText="Cod. Ni&#241;o"></asp:BoundField>
                                        <asp:BoundField DataField="apellido_paterno" HeaderText="Ap. Paterno"></asp:BoundField>
                                        <asp:BoundField DataField="apellido_materno" HeaderText="Ap. Materno"></asp:BoundField>
                                        <asp:BoundField DataField="nombres" HeaderText="Nombres"></asp:BoundField>
                                        <asp:BoundField DataField="fechanacimiento" HeaderText="F. Nacim.">

                                            <HeaderStyle Wrap="True" />
                                            <FooterStyle Wrap="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="run" HeaderText="RUN">

                                            <HeaderStyle Wrap="False" />
                                            <FooterStyle Wrap="False" />
                                        </asp:BoundField>
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
                                        <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Actualizaci&#243;n"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                    <HeaderStyle CssClass="titulo-tabla" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />

                                </asp:GridView>

                            </table>
                            <%--         </div>--%>
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
        <uc1:DIAG_DROGA ID="DIAG_DROGA1" runat="server" Visible="false" OnLoad="DIAG_DROGA1_Load" />
        <uc3:DIAG_SOCIAL ID="DIAG_SOCIAL1" runat="server" Visible="false" />
        <uc2:DIAG_ESCOLAR ID="DIAG_ESCOLAR1" runat="server" Visible="false" />
        <uc4:DIAG_MALTRATO ID="DIAG_MALTRATO1" runat="server" Visible="false" />
        <uc5:DIAG_PEORES_FORMA ID="DIAG_PEORES_FORMA1" runat="server" Visible="false" />
        <uc6:DIAG_PSICOLOGICO ID="DIAG_PSICOLOGICO1" runat="server" Visible="false" />

    </form>
</body>
</html>
