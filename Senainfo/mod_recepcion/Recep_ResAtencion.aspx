<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Recep_ResAtencion.aspx.cs" Inherits="mod_recepcion_Recep_ResAtencion" %>

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
    <title>Resumen Atención Mensual :: Senainfo :: Servicio Nacional de Menores</title>




    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/senainfoTools.js"></script>


    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/jquery.dataTables.css" rel="stylesheet" />



    <!-- originales -->
    <!--<script src="../Script/jquery.min.js"></script> 
    <script src="../Script/jquery-1.4.3.min.js"></script>-->
    <script type="text/javascript">
        /* $(document).ready(function () {
             $("a .paginate_button").addClass("btn btn-info btn-sm");
         });*/
    </script>



</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_excel" />
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
                        <li class="active">Certificación de Resumen de Atención</li>
                    </ol>
                    <asp:Panel runat="server" ID="pnlAlert">
                        <div id="divAlert" class="row alert alert-warning text-center" runat="server">
                            No se encontraron registros
                        </div>
                    </asp:Panel>
                    <div class="well">
                        <h4 class="subtitulo-form">Certificación de Resumen de Atención</h4>
                        <hr />
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
                                                <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown004_SelectedIndexChanged">
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
                                                <%--<asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server" Text="Seleccione Fecha"></asp:TextBox>
                                          <ajax:MaskedEditExtender ID="txt001_MaskedEditExtender1" PromptCharacter="" runat="server" Enabled="True" TargetControlID="txt001" Mask="9999" MaskType="None" ClearMaskOnLostFocus="true" InputDirection="RightToLeft" AcceptNegative="None" MessageValidatorTip="true"></ajax:MaskedEditExtender>--%>
                                            </div>
                                            <div class="col-md-6 no-padding">
                                                <asp:DropDownList ID="ddownAno" runat="server" CssClass="form-control form-group input-sm" OnSelectedIndexChanged="ddownAno_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>          
                                    <tr>
                                        <th>
                                            <label></label>
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddown005" CssClass="form-control input-sm" runat="server" AutoPostBack="True" Visible="False">
                                                <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="0">Abierto</asp:ListItem>
                                                <asp:ListItem Value="1">Cerrado</asp:ListItem>
                                                <asp:ListItem Value="2">Recibido</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click">
                                        <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click">
                                   <span class="glyphicon glyphicon-remove-sign"></span> Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btn_excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click" CausesValidation="False" Visible="false">
                                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                            </asp:LinkButton>



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
                                        <br />
                                        <label class="subtitulo-form-info">
                                            <asp:Label ID="lblmsj" runat="server" Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblnromes" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblmes" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblano" runat="server" Visible="False"></asp:Label>
                                        </label>
                                    </div>
                                </div>

                            </div>

                            <div class="col-md-9">
                                <asp:Panel ID="pnl001" runat="server" Visible="false" Width="100%">
                                    <div>
                                        <h4>
                                            <asp:Label ID="titulo_tab" class="subtitulo-form" Text="Estadística" runat="server" /></h4>

                                        <table class="table table-borderless table-col-fix table-condensed">

                                            <tr>
                                                <th>
                                                    <label for="">
                                                        Total Proyectos del Período:</label>
                                                    </label></th>
                                                <td>
                                                    <asp:TextBox ID="txt002" runat="server" CssClass="form-control input-sm" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr >
                                                <th>
                                                    <label for="">
                                                        Proyectos Cerrados:</label>
                                                    </label></th>
                                                <td>
                                                    <asp:TextBox ID="txt003" runat="server" CssClass="form-control input-sm " ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="row_txt004" runat="server" visible="false">
                                                <th>
                                                    <asp:Label ID="lbl_txt004" runat="server" Text="Proyectos Recepcionados:" Visible="false"></asp:Label>
                                                    </label></th>
                                                <td>
                                                    <asp:TextBox ID="txt004" runat="server" CssClass="form-control input-sm" ReadOnly="True" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="row_txt005" runat="server" visible="false">
                                                <th>
                                                    <asp:Label ID="lbl_txt005" runat="server" Text="Proyectos Abiertos:" Visible="false"></asp:Label>
                                                    </label></th>
                                                <td>
                                                    <asp:TextBox ID="txt005" runat="server" CssClass="form-control input-sm " ReadOnly="True" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right" ID="btn_guardar" Text="Guardar" runat="server" OnClick="btn_guardar_Click" Visible="false">
                                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                                    </asp:LinkButton></td>

                                            </tr>
                                        </table>

                                    </div>
                                </asp:Panel>
                                <table class="table table-borderless table-col-fix tabla-tabs">
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right" ID="btn_Reliquidaciones" runat="server" OnClick="btn_Reliquidaciones_Click" Visible="False">
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Reliquidaciones y Otros
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btn_ResumenAtencion" runat="server" OnClick="btn_ResumenAtencion_Click" Visible="False">
                                        <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Resumen de Atención
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel ID="pnl003" runat="server" Visible="False">
                                <table class="table table-borderless table-col-fix table-condensed">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl006" runat="server" Text="Cod. Proyecto" Visible="False"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt006" CssClass="form-control input-sm" runat="server" Visible="False" />
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">Filtrar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <div class="col-md-12">
                                <h4>
                                    <asp:Label runat="server" ID="tituloGrid" CssClass="subtitulo-form" Text="" Visible="false"></asp:Label>
                                </h4>

                                <asp:GridView ID="grd001" CssClass="table table-bordered table-hover " runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grd001_PageIndexChanging" OnRowEditing="grd001_RowVer" AllowPaging="false">
                                    <Columns>
                                        <asp:BoundField DataField="CodInstitucion" HeaderText="Cod Institucion"></asp:BoundField>
                                        <asp:BoundField DataField="Institucion" HeaderText="Institucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Cod. Proyecto" DataField="codproyecto"></asp:BoundField>
                                        <asp:BoundField HeaderText="Proyecto" DataField="nombre"></asp:BoundField>
                                        <asp:BoundField DataField="Correlativo" HeaderText="Correlativo"></asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha Cierre" DataField="FechaCierre">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="FES">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkFES" runat="server" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Envio FES" DataField="FechaEnvioFES">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Enviado al Financiero">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEnvioFinanciero" runat="server" OnCheckedChanged="chk001_CheckedChanged1" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Envio Financiero" DataField="FechaEnvioFinanciero">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Retenci&#243;n Pago" Visible="false">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRetencionPago" runat="server" AutoPostBack="True" OnCheckedChanged="chkRetencionPago_CheckedChanged" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Retenci&#243;n Pago" Visible="false" DataField="FechaRetencion">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:CommandField EditText="Ver" ShowEditButton="True" HeaderText="Ver"></asp:CommandField>
                                        <asp:TemplateField HeaderText="Imprimir" Visible="False">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkImprimir" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless text-center" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                </asp:GridView>

                                <div class="popupConfirmation" id="popcontrol_Ver" style="display: none">
                                    <div class="modal-header header-modal">
                                        <asp:LinkButton ID="btnCerrar_Ver" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false"> <span aria-hidden="true">&times;</span> </asp:LinkButton>
                                                                                    <h4 class="modal-title">RESUMEN DE ATENCION</h4>
                                    </div>
                                    <div>
                                        <iframe id="iframe_Ver" frameborder="0" height="600px" width="800px" runat="server"></iframe>
                                    </div>
                                </div>

                                <!-- gridView to Excel - Resumen Atención -->


                                <asp:GridView ID="grdResAtencionExcel" CssClass="table  table-bordered table-hover " runat="server"
                                    AutoGenerateColumns="False" OnPageIndexChanging="grd001_PageIndexChanging" OnRowEditing="grd001_RowVer" Visible="false">
                                    <Columns>
                                        <asp:BoundField DataField="CodInstitucion" HeaderText="Cod Institucion"></asp:BoundField>
                                        <asp:BoundField DataField="Institucion" HeaderText="Institucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Cod. Proyecto" DataField="codproyecto"></asp:BoundField>
                                        <asp:BoundField HeaderText="Proyecto" DataField="nombre"></asp:BoundField>
                                        <asp:BoundField DataField="Correlativo" HeaderText="Correlativo"></asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha Cierre" DataField="FechaCierre">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="FES">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkFES" runat="server" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Envio FES" DataField="FechaEnvioFES">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Enviado al Financiero">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEnvioFinanciero" runat="server" OnCheckedChanged="chk001_CheckedChanged1" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Envio Financiero" DataField="FechaEnvioFinanciero">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Retenci&#243;n Pago">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRetencionPago" runat="server" AutoPostBack="True" OnCheckedChanged="chkRetencionPago_CheckedChanged" Enabled="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="F.Retenci&#243;n Pago" DataField="FechaRetencion">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                        <asp:CommandField EditText="Ver" ShowEditButton="True" HeaderText="Ver"></asp:CommandField>
                                        <asp:TemplateField HeaderText="Imprimir" Visible="False">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkImprimir" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless text-center" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                </asp:GridView>



                                <asp:GridView ID="grdReliquidaciones" CssClass="table  table-bordered table-hover" runat="server" AutoGenerateColumns="False"
                                    AllowPaging="false" OnPageIndexChanging="grdReliquidaciones_PageIndexChanging" Visible="false">
                                    <Columns>
                                        <asp:BoundField HeaderText="Cod. Instituci&#243;n" DataField="CodInstitucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Instituci&#243;n" DataField="Institucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Cod. Proyecto" DataField="codproyecto"></asp:BoundField>
                                        <asp:BoundField HeaderText="Proyecto" DataField="nombre"></asp:BoundField>
                                        <asp:BoundField HeaderText="A&#241;oMes" DataField="MesAno"></asp:BoundField>
                                        <asp:BoundField DataField="Correlativo" HeaderText="Correlativo"></asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha Cierre" DataField="FechaCierre">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless text-center" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />

                                </asp:GridView>

                                <!-- gridView to Excel - Reliquidicaciones y otros -->


                                <asp:GridView ID="grdReliquidacionesExcel" CssClass="table  table-bordered table-hover" runat="server" AutoGenerateColumns="False" Visible="false">
                                    <Columns>
                                        <asp:BoundField HeaderText="Cod. Instituci&#243;n" DataField="CodInstitucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Instituci&#243;n" DataField="Institucion"></asp:BoundField>
                                        <asp:BoundField HeaderText="Cod. Proyecto" DataField="codproyecto"></asp:BoundField>
                                        <asp:BoundField HeaderText="Proyecto" DataField="nombre"></asp:BoundField>
                                        <asp:BoundField HeaderText="A&#241;oMes" DataField="MesAno"></asp:BoundField>
                                        <asp:BoundField DataField="Correlativo" HeaderText="Correlativo"></asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha Cierre" DataField="FechaCierre">
                                            <ItemStyle CssClass="columna-fecha" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless text-center" />
                                    <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />

                                </asp:GridView>

                            </div>

                            <div class="col-md-12">

                                <asp:ImageButton ID="old" runat="server" ImageUrl="../images/Excel1.bmp" OnClick="btn_excel_Click" Visible="False" Style="margin-bottom: -12px" />
                                <asp:Panel ID="Panel1" runat="server" Visible="False">
                                    <asp:LinkButton CssClass="btn btn-info btn-sm " ID="btn_MarcaTodo" runat="server" OnClick="btn_MarcaTodo_Click" Visible="False">
                                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Marcar Todos para Imprimir
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_Imprimir" runat="server" OnClick="btn_Imprimir_Click" Visible="False">
                                            <span class="glyphicon glyphicon-print"></span>&nbsp;Imprimir

                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn_DesmarcarTodo" runat="server" OnClick="btn_DesmarcarTodo_Click" Visible="False">
                                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Desmarcar Todos
                                    </asp:LinkButton>
                                </asp:Panel>
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

        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <script src="../js/bootstrap.min.js"></script>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
        <!-- Latest compiled and minified JavaScript -->
    </form>
    <script type="text/javascript">
        var objIframe = document.getElementById('iframe_Ver');
        limpiaiframe(objIframe);


    </script>
</body>
</html>
