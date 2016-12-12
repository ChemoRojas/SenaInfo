<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_NominaAdolescente.aspx.cs" Inherits="mod_reportes_Rep_NominaAdolescente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html >

<script runat="server">

 
</script>

<html lang="es">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Nomina de Adolescentes :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>



</head>

<body class="body-iframe-reportes" onmousemove="SetProgressPosition(event)">
    <form id="form1" class="form-horizontal" runat="server">
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="imb001" />
                <asp:PostBackTrigger ControlID="exportarExcel" />

            </Triggers>
            <ContentTemplate>
                <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                    <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    <asp:Label ID="lblaviso" runat="server"></asp:Label>

                </div>
                <asp:Panel runat="server" ID="panelForm">
                    <h5 class="subtitulo-form">Nómina Adolescentes</h5>

                    <ajax:ModalPopupExtender
                        ID="mpe1"
                        BehaviorID="mpeInstitucion"
                        runat="server"
                        TargetControlID="imb_lupa_modal_institucion"
                        PopupControlID="modal_bsc_institucion"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal1">
                    </ajax:ModalPopupExtender>
                    <ajax:ModalPopupExtender
                        ID="mpe2"
                        BehaviorID="mpeProyecto"
                        runat="server"
                        TargetControlID="imb_lupa_modal_proyecto"
                        PopupControlID="modal_bsc_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="btnCerrarModal2">
                    </ajax:ModalPopupExtender>

                    <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                        <div class="modal-header header-modal">
                            <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                    	            <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                            <h4 class="modal-title">NOMINA ADOLESCENTES</h4>
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
                            <h4 class="modal-title">NOMINA ADOLESCENTES</h4>
                        </div>
                        <div>
                            <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-9">

                            <table class="table table-col-fix table-borderless table-condensed">
                                <tr>
                                    <th>
                                        <label for="" >Institución :</label>
                                    </th>
                                    <td>
                                        <div class="input-group">

                                            <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" Enabled="true">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton runat="server" ID="imb_lupa_modal_institucion" CssClass="input-group-addon btn-info input-sm" OnClientClick="return MostrarModalInstitucion('Busca Proyectos', '../mod_reportes/Rep_NominaAdolescente.aspx','mpeInstitucion')">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>

                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="" >Proyecto :</label>
                                    </th>
                                    <td>
                                        <div class="input-group">
                                            <asp:TextBox ID="txt001" runat="server" CssClass="form-control input-sm" Visible="false"></asp:TextBox>
                                            <asp:DropDownList ID="ddownProyectos" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                            <asp:LinkButton runat="server" ID="imb_lupa_modal_proyecto" CssClass="input-group-addon btn-info input-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_reportes/Rep_NominaAdolescente.aspx','mpeProyecto')" OnClick="imb_lupa_modal_proyecto_Click">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="" >Tipo Listado :</label>
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="ddown003" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddown003_SelectedIndexChanged" CssClass="form-control input-sm">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                            <asp:ListItem Value="1">Ingresos</asp:ListItem>
                                            <asp:ListItem Value="2">Egresos</asp:ListItem>
                                            <asp:ListItem Value="3">Vigentes</asp:ListItem>
                                            <asp:ListItem Value="4">Atendidos</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <th><label>
                                        <asp:Label ID="lbl_periodo" runat="server" Text="Período :" Visible="false"></asp:Label></label>
                                    <label>
                                        <asp:Label ID="lbl_fecha" runat="server" Text="Fecha :" Visible="false"></asp:Label></label>
</th>
                                    <td>
                                        <div id="divFecha" runat="server" visible="false">
                                    <asp:TextBox ID="txtFecha" Placeholder="dd-mm-aaaa" runat="server" MaxLength="10" ReadOnly="false" Visible="False" CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txtFecha" ValidChars="0123456789-/" />
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="calExtender" runat="server" TargetControlID="txtFecha" />

                                </div>
                                        <div id="divPeriodo" runat="server" visible="false">

                                    <div class="col-md-6 no-padding">
                                        <div class="col-md-4">
                                            <asp:Label ID="lblmes" runat="server" Text="Mes: "></asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddown004" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm"
                                                OnSelectedIndexChanged="ddown004_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
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

                                    </div>
                                    <div class="col-md-6 no-padding">
                                        <div class="col-md-4">
                                            <asp:Label ID="lblano" runat="server" Text="Año :"></asp:Label>
                                        </div>
                                        <div class="col-md-8 pull-right no-padding">
                                            <asp:DropDownList ID="wne001" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem>2007</asp:ListItem>
                                                <asp:ListItem>2008</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>

                                    </div>

                                </div>
                                
                                    </td>
                                </tr>
                                <tr>
                                    <th></th>
                                    <td> <div>
                                    <asp:LinkButton runat="server" ID="btnBuscar" CssClass="btn btn-danger btn-sm fixed-width-button" Visible="false">
                          <span class="glyphicon glyphicon-search"></span>&nbsp; Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnLimpiar" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btnLimpiar_Click">
                          <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="exportarExcel" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="exportarExcel_Click">
                          <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                    </asp:LinkButton>

                                </div>
                            </td>
                                </tr>

                            </table>




                        </div>

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

                    <asp:Panel runat="server" ID="errorPanel" Visible="false">
                    </asp:Panel>

                    <asp:Panel runat="server" ID="panelCorrecto" Visible="false">
                        <div class="alert alert-success text-center">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;      
                            <asp:Label ID="lblCorrecto" runat="server" Text="Tu reporte será descargado enseguida" Visible="False"></asp:Label>
                        </div>
                    </asp:Panel>


                </asp:Panel>




                <!-- botones deprecados? -->
                <asp:LinkButton ID="btnproy" runat="server" OnClick="btnproy_Click" CssClass="btn btn-warning btn-md" Visible="false"></asp:LinkButton></td>
              <asp:ImageButton ID="imb001" runat="server" ImageUrl="~/images/Excel1.bmp" OnClick="imb001_Click" Visible="false" /></td>
              <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnVolver_NEW" runat="server" OnClick="btnVolver_NEW_Click" Text="Volver" Visible="false" />




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
