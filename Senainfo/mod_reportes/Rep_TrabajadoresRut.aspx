<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_TrabajadoresRut.aspx.cs" Inherits="mod_reportes_Rep_TrabajadoresRut" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<!DOCTYPE html >

<html lang="es-cl">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Reporte Trabajadores</title>
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
        &nbsp;&nbsp;&nbsp;
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
                <%--<asp:PostBackTrigger ControlID="btn_limpiar" />--%>
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
                    



                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Reportes</li>
                        <li class="active">Reportes de Trabajadores</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                                                    <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                        <asp:Label ID="lbl_Error" runat="server" Visible="False"></asp:Label>
                    </div>


                    <div class="well">
                        <h4 class="subtitulo-form">Reportes de Trabajadores</h4>
                        <hr />

                        <div class="row">
                            <div class="col-md-9">
                                <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                                          <span aria-hidden="true">&times</span>
                                        </asp:LinkButton>
                                        <caption>
                                            <h4 class="modal-title">REPORTES DE TRABAJADORES</h4>
                                        </caption>
                                    </div>
                                    <div>
                                        <caption>
                                            <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                        </caption>
                                    </div>
                                </div>
                                <div id="modal_bsc_proyecto" class="popupConfirmation" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton ID="btnCerrarModal2" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
	                                                            <span aria-hidden="true">&times;</span>
                                        </asp:LinkButton>
                                        <h4 class="modal-title">REPORTES DE TRABAJADORES</h4>
                                    </div>
                                    <div>
                                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                    </div>
                                    <!--fin popup-->
                                </div>
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">
                                                Región:</label>

                                        </th>
                                        <td>

                                            <asp:DropDownList ID="ddregion" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                            </asp:DropDownList>


                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Institución:</label>
                                        </th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddinstitucion"  OnSelectedIndexChanged="ddinstitucion_SelectedIndexChanged" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion', '../mod_reportes/Rep_TrabajadoresRut.aspx','mpe1a')">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Proyecto:</label>

                                        </th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddproyecto" OnSelectedIndexChanged="ddproyecto_SelectedIndexChanged" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal2" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_TrabajadoresRut.aspx','mpe1b')">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Vigencia:</label>
                                        </th>
                                        <td>
                                            <div class="text-center">
                                                <asp:RadioButton ID="rdbtn_Vigente" runat="server" Checked="True" GroupName="grouprdbtn_vc" Text="&nbsp;Vigentes" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="rdbtn_Caducado" runat="server" GroupName="grouprdbtn_vc" Text="&nbsp;Caducados" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="rdbtn_Todos" runat="server" GroupName="grouprdbtn_vc" Text="&nbsp;Todos" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">
                                                Buscar por:</label></th>
                                        <td>
                                            <asp:RadioButtonList ID="rbt_buscador" RepeatDirection="Horizontal" align="center" runat="server" AutoPostBack="True" style="margin-left:165px;">
                                                <asp:ListItem>Región</asp:ListItem>
                                                <asp:ListItem>Institución</asp:ListItem>
                                                <asp:ListItem>Proyecto</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click" ValidationGroup="valError" CausesValidation="false"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                            <asp:LinkButton ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click" CausesValidation="false" CssClass="btn btn-info btn-sm fixed-width-button pull-right"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>
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
       

    </form>
</body>
</html>
