<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Recep_RendCuenta.aspx.cs" Inherits="mod_recepcion_Recep_RendCuenta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <title>Certificación de Rendicion de Cuentas :: Senainfo :: Sename</title>
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">
    <link rel="icon" href="../images/favicon.ico">
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.dataTables.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/jquery.dataTables.css" />
    <script type="text/javascript" charset="utf-8" src="../js/senainfoTools.js"></script>


    <script type="text/javascript">


        function f_MuestraEspera() {
            var Buscando = document.getElementById('Buscando');
            if (Buscando.value == '0') {
                Buscando.value = '1';
                document.getElementById('lblBuscando').style.visibility = 'visible';
                return true;
            }
            else
                return false;
        };

    </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_excel" />
                <%--<asp:PostBackTrigger ControlID="btn_buscar" />--%>
            </Triggers>
            <ContentTemplate>

                <asp:Button ID="btnEscondido_Ver" runat="server" Text="Agregar Nueva Solicitud 2" CssClass="invisible" OnClientClick="return MostrarModal_Ver();" CausesValidation="False" />
                <ajax:ModalPopupExtender ID="mp_Ver"
                    BehaviorID="modalpop_Ver"
                    runat="server"
                    TargetControlID="btnEscondido_Ver"
                    PopupControlID="popcontrol_Ver"
                    DropShadow="True"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrar_Ver">
                </ajax:ModalPopupExtender>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Recepcion</li>
                        <li class="active">Certificación de Rendicion de Cuenta</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Certificación de Rendicion de Cuenta</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-col-fix table-condensed">
                                    <tr>
                                        <th>
                                            <label>Región:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label>Período:</label></th>
                                        <td>
                                            <div class="col-md-6 no-padding">
                                                <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
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
                                            <div class="col-md-6 no-padding">
                                                <asp:DropDownList ID="ddownAno" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td>Fecha Recepción (Mes):</td>--%>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label runat="server" id="lbl_ddown005" visible="false">Estado:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddown005" CssClass="form-control input-sm" runat="server" Visible="False">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">Recibido</asp:ListItem>
                                                <asp:ListItem Value="0">No Recibido</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <div>
                                                <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click">
                                                    <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btn_excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click" CausesValidation="False" Visible="false">
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
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados."></asp:Label>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12">

                                <asp:Panel ID="pnl003" runat="server" Width="100%" Visible="False">
                                    <table class="table table-borderless table-condensed">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txt002" CssClass="form-control input-sm" runat="server" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">Filtrar</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                                <div>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_confirmar" runat="server" OnClick="btn_confirmar_Click" Visible="False">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                    </asp:LinkButton>
                                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                                        <asp:LinkButton CssClass="btn btn-info btn-sm " ID="btn_MarcaTodo" runat="server" OnClick="btn_MarcaTodo_Click" Visible="False">
                                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Marcar Todos para Imprimir
                                        </asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-success btn-sm " ID="btn_Imprimir" runat="server" OnClick="btn_Imprimir_Click" Visible="False">
                                            <span class="glyphicon glyphicon-print"></span>&nbsp;Imprimir
                                        </asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-info btn-sm " ID="btn_DesmarcarTodo" runat="server" OnClick="btn_DesmarcarTodo_Click" Visible="False">
                                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Desmarcar Todos
                                        </asp:LinkButton>
                                    </asp:Panel>
                                </div>


                                <asp:GridView ID="grd001" CssClass="table  table-bordered table-hover"
                                    runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="grd001_PageIndexChanging" AllowPaging="false"
                                    OnRowEditing="grd001_RowEditing">
                                    <Columns>
                                        <asp:BoundField HeaderText="Cod. Institucion" DataField="CodInstitucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Nombre Institucion" DataField="Institucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Cod. Proyecto" DataField="CodProyecto"></asp:BoundField>
                                        <asp:BoundField HeaderText="Nombre Proyecto" DataField="Nombre"></asp:BoundField>
                                        <asp:BoundField DataField="Correlativo" HeaderText="Correlativo"></asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha Cierre" DataField="FechaActualizacion" DataFormatString="{0:d}">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IndicePago" HeaderText="I. Pago" Visible="False"></asp:BoundField>
                                        <asp:BoundField HeaderText="Per&#237;odo Rendici&#243;n" DataField="FechaInicio" DataFormatString="{0:d}"></asp:BoundField>
                                        <asp:BoundField HeaderText="F. T&#233;rmino" DataField="FechaFin" DataFormatString="{0:d}" Visible="False">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Retenci&#243;n">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk001" runat="server" AutoPostBack="True" OnCheckedChanged="chk001_CheckedChanged" Width="70px" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F. Retenci&#243;n" DataField="FechaRetencion" DataFormatString="{0:d}">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="FES">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkFES" runat="server" Enabled="False" Width="70px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Envio FES" DataField="FechaEnvioFES" DataFormatString="{0:d}">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:CommandField EditText="Ver" ShowEditButton="true"></asp:CommandField>
                                        <asp:TemplateField HeaderText="Imprimir" Visible="False">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkImprimir" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="En Auditoria">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEnAuditoria" runat="server" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                </asp:GridView>
                            </div>

                            <div class="popupConfirmation" id="popcontrol_Ver" style="display: none">
                                <div class="modal-header header-modal">
                                     <asp:LinkButton ID="btnCerrar_Ver" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false"> <span aria-hidden="true">&times;</span> </asp:LinkButton>
                                                                                    <h4 class="modal-title">RENDICION DE CUENTA</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_Ver" frameborder="0" height="600px" width="800px" runat="server"></iframe>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
    <!-- Bootstrap core JavaScript
                ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../js/ie10-viewport-bug-workaround.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script type="text/javascript">
        var objIframe = document.getElementById('iframe_Ver');
        limpiaiframe(objIframe);

        function SetProgressPosition(e) {
            var posx = 0;
            var posy = 0;
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                posx = e.clientX + document.documentElement.scrollLeft;
                posy = e.clientY + document.documentElement.scrollTop;
            }

            //alert(posx);
            //alert(posy);
            //document.getElementById('divProgress').style.left = posx  + "px";
            document.getElementById('divProgress').style.top = posy + "px";
        };

    </script>
</body>



</html>
