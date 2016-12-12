<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_DireccionNino.aspx.cs" Inherits="mod_ninos_ninos_DireccionNino" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="S" />
    <meta name="author" content="" />
    <link rel="icon" href="../images/favicon.ico" />
    <title>Dirección Niño :: Senainfo :: Servicio Nacional de Menores </title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.dataTables.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/dataTables.bootstrap.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/dataTables.fixedHeader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/dataTables.fixedHeader.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>


    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />

    <link href="../css/theme.css" rel="stylesheet" />

    <script type="text/javascript">

        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;
            var txt;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;

            }
        };

        function f_SoloNumeros() {
            var key = window.event.keyCode;
            if (key < 48 || key > 57) {
                window.event.keyCode = 0;
            }
        };


    </script>
    
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <style>
        th {
            text-align: center;
            white-space: nowrap;
        }

        tr {
            white-space: nowrap;
        }
    </style>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="grd001" />--%>
            </Triggers>
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Dirección Niños</li>
                    </ol>

                    <!-- alertas -->
                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">No se encuentran datos disponibles con el proyecto seleccionado</asp:Label>

                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-ok"></span>
                    </div>


                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Dirección Niño(a)</h4>
                        <hr>

                        <ajax:ModalPopupExtender
                            ID="mpeProyecto"
                            BehaviorID="mpeProyecto"
                            runat="server"
                            TargetControlID="imb_lupa_modal_proyecto"
                            PopupControlID="modal_bsc_proyecto"
                            DropShadow="true"
                            BackgroundCssClass="modalBackground"
                            CancelControlID="btnCerrarModal2">
                        </ajax:ModalPopupExtender>

                        <ajax:ModalPopupExtender
                            ID="mpeInstitucion" runat="server"
                            BackgroundCssClass="modalBackground"
                            BehaviorID="mpeInstitucion"
                            CancelControlID="btnCerrarModal4"
                            DropShadow="true"
                            PopupControlID="modal_bsc_institucion"
                            TargetControlID="imb_lupa_modal">
                        </ajax:ModalPopupExtender>

                        <!-- Modal -->
                        <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal4" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                    	        <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">Buscador de Instituciones</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server"></iframe>
                            </div>
                        </div>

                        <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                    	            <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">Buscador de Proyectos</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>


                        <%--  Formulario 2.0 --%>


                        <article class="row">
                            
                            <div class="form-horizontal col-md-9">
                                <div class="form-group">
                                    <label for="ddown001" class="col-md-4">Institución :</label>
                                    <div class="col-md-8">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Busca Proyectos','../mod_ninos/ninos_direccionnino.aspx','mpeInstitucion')" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="ddown002" class="col-md-4">Proyecto:</label>
                                    <div class="col-md-8">
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupa_modal_proyecto" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClick="imb_lupa_modal_proyecto_Click" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_ninos/ninos_DireccionNino.aspx','mpeProyecto')">
                                          	    <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" CausesValidation="false">
                                        <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" CssClass="pull-right btn btn-info btn-sm fixed-width-button" CausesValidation="false">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                </div>

                            </div>


                            <div class="col-md-3">
                                <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lbl001F2" CssClass="subtitulo-form-info" runat="server" Text="El Tiempo de Carga de la información dependerá de la cantidad de registros."></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl001_aviso" runat="server" CssClass="help-block" />
                                </div>
                            </div>
                        </article>

                        <%-- Formulario --%>
                        <div class="col-md-9" runat="server" visible="false">
                            <table class="table table-borderless table-condensed table-col-fix">
                                <caption>
                                    <label class="subtitulo-form">
                                        Registro de Dirección Niño(a)</label>
                                    <asp:Panel ID="pnl001" runat="server">
                                        <tr>
                                            <td class="col-md-2">
                                                <label for="">
                                                    Institución</label>
                                            </td>
                                            <td>
                                                <div class="input-group">
                                                </div>
                                                <%--<a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_ninos/ninos_DireccionNino.aspx"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton1_Click" /></a>--%></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="col-md-2">
                                                <label for="">
                                                    Proyecto</label>
                                            </td>
                                            <td><%--<asp:DropDownList ID="ddown002" runat="server" OnSelectedIndexChanged="ddown002_SelectedIndexChanged"
                                                AutoPostBack="True" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>--%><%--<a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_DireccionNino.aspx"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton2_Click" /></a>--%>
                                                <div class="input-group">
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="col-md-2">
                                                <label class="" style="display: none;">
                                                    Nombre niño(a)</label></td>
                                            <td>
                                                <asp:TextBox ID="TextBox1" Visible="false" runat="server" CssClass="form-control input-sm" Enabled="False" placeholder="Nombres" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="col-md-2">
                                                <label class="" style="display: none;">
                                                    Apellido Paterno</label></td>
                                            <td>
                                                <asp:TextBox ID="txt001" Visible="false" runat="server" CssClass="form-control input-sm" Enabled="False" placeholder="Apellido Paterno" />
                                            </td>
                                            <%--<td><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-info btn-sm">Filtrar</asp:LinkButton></td>--%><%--<td><asp:LinkButton ID="" runat="server" OnClick="" CssClass="btn btn-info btn-sm"><span class="glyphicon glyphicon-remove"></span>&nbsp;Limpiar</asp:LinkButton></td>--%>
                                        </tr>
                                        <tr>
                                            <td class="col-md-2">
                                                <label class="" style="display: none;">
                                                    Apellido Materno</label></td>
                                            <td>
                                                <asp:TextBox ID="TextBox2" Visible="false" runat="server" CssClass="form-control input-sm" Enabled="False" placeholder="Apellido Materno" />
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </caption>
                            </table>
                        </div>
                        <%-- Botones --%>
                        <%-- Label Error --%>


                        <!-- Modal -->

                        <div class="modal fade bs-example-modal-lg" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel ID="upModal" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-content" style="width: 1024px;">
                                            <div class="modal-header header-modal">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="$('#modalElement').data('modal', null);"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title text-center" id="myModalLabel">
                                                    <asp:Label runat="server" ID="tituloModal" Text="AGREGAR O ACTUALIZAR DIRECCIONES"></asp:Label></h4>
                                            </div>
                                            <div class="modal-body">

                                                <div class="body-form col-md-12" style="overflow: auto">
                                                    <%-- Formulario de Agregar Dirección --%>

                                                    <asp:Panel ID="pnlCorrecto" runat="server" Visible="false">
                                                        
                                                        <div class="row alert alert-success  text-center">
                                                           <span class="glyphicon glyphicon-ok"></span>&nbsp;     <asp:Label runat="server" ID="lblCorrecto"></asp:Label>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlError" runat="server" Visible="false">
                                                        <div class="row alert alert-warning text-center">
                                                                <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;<asp:Label runat="server" ID="lblAlertError"></asp:Label>
                                                        </div>
                                                    </asp:Panel>


                                                    <asp:Panel ID="pnl002" runat="server" Visible="false">
                                                        <div class="row">
                                                            <table class="table table-bordered table-condensed">
                                                                <tr>
                                                                    <th class="titulo-tabla col-md-1"><label for="">Código Dirección</label></th>
                                                                    <td class="col-md-3">
                                                                        <asp:Label ID="lbl001" runat="server" Visible="False"></asp:Label></td>
                                                                    <th class="titulo-tabla col-md-1">
                                                                        <label for="cal001">Fecha Ingreso *</label></th>
                                                                    <td>

                                                                        <asp:TextBox ID="cal001" runat="server" placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha-large input-sm" MaxLength="10" />
                                                                        <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende771" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="cal001" Type="Date" OnInit="rv_fecha_Init" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="fechaIng" runat="server" ControlToValidate="cal001" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Ingreso Requerida">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla">
                                                                        <label for="txt007">Dirección *</label></th>
                                                                    <td>
                                                                        <swtb:SenameTextBox ID="txt007" runat="server" placeholder="Ingrese Dirección" MaxLength="100" TextMode="MultiLine"
                                                                            CssClass="form-control input-sm"></swtb:SenameTextBox>
                                                                    </td>

                                                                    <th class="titulo-tabla">
                                                                        <label for="ddown006">Región *</label></th>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddown006" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown006_SelectedIndexChanged1" CssClass="form-control input-sm"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla">
                                                                        <label for="ddown004">Comuna *</label></th>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddown004" runat="server" CssClass="form-control input-sm">
                                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                    <th class="titulo-tabla">
                                                                        <label for="txt002">Teléfono</label></th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt002" runat="server" placeholder="0712222222" MaxLength="10" CssClass="form-control input-sm" />
                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt002" ValidChars="0123456789-+/" />
                                                                    </td>
                                                                    <tr>
                                                                    </tr>

                                                                    <th class="titulo-tabla">
                                                                        <label for="txt003">Teléfono Recado</label></th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt003" runat="server" placeholder="0712222222" MaxLength="10" CssClass="form-control input-sm" />
                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt003" ValidChars="0123456789-+/" />
                                                                    </td>
                                                                    <th class="titulo-tabla">
                                                                        <label for="txt004">E-Mail</label></th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt004" runat="server" placeholder="Ingrese Email" MaxLength="30" CssClass="form-control input-sm"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th class="titulo-tabla">
                                                                        <label for="txt005">Fax</label></th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt005" runat="server" placeholder="0712222222" MaxLength="10" CssClass="form-control input-sm" />
                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt005" ValidChars="0123456789-+/" />
                                                                    </td>

                                                                    <th class="titulo-tabla">
                                                                        <label for="txt006">Código Postal</label></th>
                                                                    <td>
                                                                        <asp:TextBox ID="txt006" runat="server" placeholder="1230000" MaxLength="7" CssClass="form-control input-sm" />
                                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt006" ValidChars="0123456789-+/" />
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div class="pull-right">
                                                            <asp:LinkButton ID="btn_actualizar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_actualizar_Click" Text="Actualizar">
                                                          <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btn_guardarDireccion" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_guardarDireccion_Click">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                                            </asp:LinkButton>

                                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_guardar" runat="server" Visible="false" OnClick="btn_guardar_Click">
                                                              <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar

                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btn_limpiar_Click" Text="Limpiar" CausesValidation="false">
                                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btnAtras" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btnAtras_Click" CausesValidation="false" Visible="false">
                                                      <span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Atras
                                                            </asp:LinkButton>

                                                            <asp:Button CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" Visible="false" runat="server" Text="Volver" OnClick="WebImageButton2_Click" />
                                                        </div>
                                                        <div class="row" runat="server" visible="false">
                                                            <div id="titulo">
                                                                <h4 class="subtitulo-form col-sm-12">INGRESO DE NUEVA DIRECCION</h4>
                                                            </div>

                                                        </div>


                                                    </asp:Panel>
                                                    


                                                <%-- Panel de grid de Direcciones --%>
                                                    <asp:Panel ID="pnl003" runat="server" Visible="false">

                                                        <asp:GridView ID="grd002" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover"
                                                            Visible="False" OnRowCommand="grd002_RowCommand">
                                                            <Columns>
                                                                <asp:BoundField DataField="FechaIngresoDireccion" HeaderText="Ingreso Direccion" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                                <asp:BoundField DataField="Direccion" HeaderText="Direccion"></asp:BoundField>
                                                                <asp:BoundField DataField="Telefono" HeaderText="Telefono"></asp:BoundField>
                                                                <asp:BoundField DataField="TelefonoRecado" HeaderText="Telefono Recado"></asp:BoundField>
                                                                <asp:BoundField DataField="Mail" HeaderText="Mail"></asp:BoundField>
                                                                <asp:BoundField DataField="Fax" HeaderText="Fax"></asp:BoundField>
                                                                <asp:BoundField DataField="CodigoPostal" HeaderText="CodigoPostal"></asp:BoundField>
                                                                <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Actualizacion" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Comuna"></asp:BoundField>
                                                                <asp:BoundField DataField="CodComuna" HeaderText="Cod. Comuna"></asp:BoundField>
                                                                <asp:BoundField DataField="ICodDireccion" HeaderText="C&#243;digo Direcci&#243;n"></asp:BoundField>
                                                                <asp:ButtonField CommandName="Ver" Text="Ver" HeaderText="Ver"></asp:ButtonField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                                        </asp:GridView>

                                                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="WebImageButton1" runat="server" OnClick="WebImageButton1_Click">
                                                                    <span class="glyphicon glyphicon-plus"></span>&nbsp; Agregar

                                                        </asp:LinkButton>


                                                    </asp:Panel>
                                                </div>

                                            </div>
                                        </div>
                                        <!-- Button trigger modal -->
                                        <div class="row">
                                            <button type="button" runat="server" visible="true" id="myButton" class="" data-toggle="modal" data-target=".bs-example-modal-lg" style="background-color: transparent; border: 0;">
                                            </button>
                                            <%--data-target="#myModal"--%>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row" style="border: 0; overflow-y: inherit;">
                            <%-- Panel de Selección de niño --%>
                            <asp:Panel ID="pnl004" runat="server" Visible="false">
                                <asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table table-bordered table-hover"
                                    CellPadding="4" OnPageIndexChanging="grd001_PageIndexChanging" Visible="False" OnRowCommand="grd001_RowCommand">

                                    <Columns>
                                        <asp:BoundField DataField="CodNino" HeaderText="Código Niño"></asp:BoundField>
                                        <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                        <asp:BoundField DataField="RUT" HeaderText="RUN" />
                                        <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                        <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                        <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" HeaderText="Seleccionar"></asp:ButtonField>
                                        <%--<asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnSeleccionar" runat="server" OnClick="btnSeleccionar_Click1" Text="Seleccionar" CssClass="btn btn-primary btn-sm" data-toggle="modal" data-target="#myModal"  />
                                                                </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                </asp:GridView>

                            </asp:Panel>
                        </div>
                    </div>
                </div>

                <footer class="footer">
        <div class="container">
            <p>Para tus dudas y consultas, escribe a:
                <br> mesadeayuda@sename.cl</p>
        </div>
    </footer>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>


        <%--<asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upModal">
	        <ProgressTemplate>
	            <div  id="divProgress" class="ajax_cargando">
	                <img alt="Cargando" src="../images/Cursors/ajax-loader.gif"/>
	                Cargando...       
	            </div>
	        </ProgressTemplate>
	    </asp:UpdateProgress>--%>
    </form>


</body>
</html>
