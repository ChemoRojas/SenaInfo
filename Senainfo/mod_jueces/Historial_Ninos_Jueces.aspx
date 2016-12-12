<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Historial_Ninos_Jueces.aspx.cs" Inherits="mod_jueces_Historial_Ninos_Jueces" %>

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
    <title>Busqueda de Niños :: Senainfo :: Servicio Nacional de Menores</title>
    <!-- Bootstrap core CSS -->
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <%--<script src="../js/ventanas-modales.js"></script>--%>
    <%--<script src="../js/jquery-ui.js"></script>--%>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>

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
        }
        //function pageLoad() {
        //    $(".ifancybox").fancybox({
        //        'width': '75%',
        //        'height': '75%',
        //        'autoScale': false,
        //        'transitionIn': 'none',
        //        'transitionOut': 'none',
        //        'type': 'iframe'
        //    });
        //};




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

        }


    </script>
</head>
<body onmousemove="SetProgressPosition(event)">

    <form id="Historial_Ninos_Jueces" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btn_Buscar" />--%>
                <%--<asp:PostBackTrigger ControlID="btn_Limpiar" />--%>
                <%--<asp:PostBackTrigger ControlID="btn_Volver" />--%>
                <asp:PostBackTrigger ControlID="btnExcel" />
                <asp:PostBackTrigger ControlID="lnkResultados" />
                <%--<asp:PostBackTrigger ControlID="grdNinosLista" />--%>
                <asp:PostBackTrigger ControlID="grdHistorialProteccion" />
            </Triggers>
            <ContentTemplate>

                <%-- Modal Instituciones --%>
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

                <%-- Modal Proyectos --%>
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

                <input type="hidden" id="Buscando" value="0" />
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Busqueda de Niños</li>
                        <li class="active">Busqueda de Niños</li>
                    </ol>
                    <asp:Panel runat="server" ID="pnlAlert" Visible="false">
                        <div id="divAlert" class="alert alert-warning text-center" runat="server">
                            <span class="glyphicon glyphicon-warning-sign"></span>
                            <asp:Label ID="lblError" runat="server" Text="[ERROR]" Visible="False"></asp:Label>

                            <asp:Label ID="lblCantidadResultado" runat="server" Text="0" Visible="False"></asp:Label>
                            <br />
                            <asp:Label ID="lblCoincidencias" runat="server" Text="Coincidencias" Visible="False"></asp:Label><br />
                            <asp:LinkButton ID="lnkResultados" runat="server" OnClick="lnkResultados_Click" Visible="False">VER RESULTADOS</asp:LinkButton></td>
                        </div>
                    </asp:Panel>

                    <div class="well">
                        <asp:Panel ID="pnl_Busqueda" runat="server" Width="100%">

                            <h4 class="subtitulo-form">
                                <asp:Label ID="lblTitulo" runat="server" Text="Búsqueda de Niños" Visible="true"></asp:Label></h4>
                            <hr />

                            <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                    	            <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">INSTITUCION</h4>
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
                                    <h4 class="modal-title">PROYECTO</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                </div>
                            </div>


                            <div class="row">
                                <%-- Formulario --%>
                                <div class="col-md-9 form-hozirontal">
                                    <div class="form-group">
                                        <label class="texto_form col-md-3"></label>
                                        <div class="col-md-6 col-md-offset-3">
                                            <asp:RadioButton ID="rdbHistorial" runat="server" GroupName="rdgSeleccione" Text="HISTORIAL" Checked="True" CssClass="radio-inline" Visible="false" />
                                            <asp:RadioButton ID="rdbCarpetas" runat="server" AutoPostBack="true" GroupName="rdgSeleccione" Text="CARPETAS DIGITALES" CssClass="radio-inline" Visible="false" /></td>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">Run Niño:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtRUN" runat="server" CssClass="form-control input-sm" placeholder="Ingrese RUN" />
                                            <asp:CustomValidator ID="cv_rut" runat="server" CssClass="help-block" ControlToValidate="txtRUN" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtRUN" ValidChars="1234567890-Kk" />
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtRUN" runat="server" ErrorMessage="Rut Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)" ValidationGroup="grupo1"></asp:RegularExpressionValidator>--%>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">Cod.Niño:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtCodNino" placeholder="Ingrese Código Niño" runat="server" CssClass="form-control input-sm" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtCodNino" ValidChars="1234567890" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">Apellido Paterno:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtApellido_Paterno" placeholder="Ingrese Apellido" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtApellido_Paterno" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü " />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">Apellido Materno:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtApellido_Materno" placeholder="Ingrese Apellido" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtApellido_Materno" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü " />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">Nombres:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtNombres" placeholder="Ingrese Nombres" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtNombres" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóúÄËÏÖÜäëïöü " />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">RUC:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txt_ruc" CssClass="form-control input-sm" runat="server" ONVALUECHANGE="txt_ruc_ValueChange" AutoPostBack="True" placeholder="YYONNNNNNN-D" />
                                            <%--<ajax:MaskedEditExtender ID="MaskedEditExtender93" runat="server" TargetControlID="txt_ruc" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="999999999999" />--%>
                                            <asp:Label ID="lblErrorRUC" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                                                Text="El RUC ingresado no es válido" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3">RIT:</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txt_rit" CssClass="form-control input-sm" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="texto_form col-md-3"></label>
                                        <div class="col-md-9">
                                            <asp:LinkButton ID="btn_Buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click" Text="Buscar">
                                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="hlInstructivo" Target="_blank" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btn_buscar_Click" Text="Buscar">
                                            <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Instructivo
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_Limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click" Text="Limpiar">
                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btnExcel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" Text="Exportar" OnClick="btn_excel_Click" CausesValidation="False" Visible="false">
                                                <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                            </asp:LinkButton>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <br />
                                    <br />
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





                                    <!-- NO SE USA ACTUALMENTE LAS CARPETAS DIGITALES -->
                                    <%--<div class="row">
                            <h5 class="subtitulo-form">Uso exclusivo carpetas digitales</h5>
                        </div>--%>

                                    <%--<div class="row">    
                            <div class="col-md-9">
                                <div class="form-group">
                                    <label class="texto_form col-md-2" style="width: 122px">Institución</label>
                                    <div class="col-md-8 col-md-offset-1">
                                        <asp:DropDownList ID="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:LinkButton ID="" OnClick="btnBuscaInstitucion_Click" runat="server" CssClass="input-group-addon btn btn-info btn-sm"  OnClientClick="return MostrarModalInstitucion()" CausesValidation="False" Width="50px" >
                                            <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="texto_form col-md-2" style="width: 122px">Proyecto</label>
                                    <div class="col-md-8 col-md-offset-1">
                                        <asp:DropDownList ID="" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:LinkButton ID="" OnClick="btnBuscaProyecto_Click" runat="server" CssClass="input-group-addon btn btn-info btn-sm"  OnClientClick="return MostrarModalProyecto()" CausesValidation="False" Width="50px" >
                                            <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                                    <%--<div class="col-md-9">--%>
                                    <%--<table class="table table-borderless table-condensed">
                            <tr> --%>
                                    <%--<label class="texto_form col-md-2" style="width: 122px">Institución</label>--%>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddown001" runat="server" CssClass="form-control input-sm" Visible="false"></asp:DropDownList>
                                        <asp:LinkButton ID="imb_lupa_modal_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" Visible="false" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_jueces/Historial_Ninos_Jueces.aspx','mpeInstitucion')" CausesValidation="False">
	                                           <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>

                                    <%--</tr>--%>

                                    <%-- <tr> --%>
                                    <%--<label class="texto_form col-md-2" style="width: 122px">Proyecto</label>--%>

                                    <div class="input-group">
                                        <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm" Visible="false"></asp:DropDownList>
                                        <asp:LinkButton ID="imb_lupa_modal_proyecto" runat="server" CssClass="input-group-addon btn btn-info btn-sm" Visible="false" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_jueces/Historial_Ninos_Jueces.aspx', 'mpeProyecto')" CausesValidation="False">
	                                           <span class="glyphicon glyphicon-question-sign"></span>
                                        </asp:LinkButton>
                                    </div>
                                    <%--   </tr>--%>

                                    <%--</table>--%>
                                    <%--<div class="col-md-6 col-md-offset-3">--%>

                                    <%--</div>--%>



                                    <br />

                                    <asp:GridView ID="grdNinosLista" CssClass="table  table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grdNinosLista_RowCommand" AllowPaging="true" OnPageIndexChanging="grdNinosLista_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="CodNino" HeaderText="C&#243;digo Ni&#241;o"></asp:BoundField>
                                            <asp:BoundField DataField="RUT" HeaderText="RUN"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}"></asp:BoundField>
                                            <asp:BoundField DataField="RUC" HeaderText="RUC" />
                                            <%--<asp:TemplateField HeaderText="RUC">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RUC") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton Font-Size="11px" ID="link_ruc" runat="server" Text='<%# Bind("RUC") %>'  OnClick="link_ruc_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField DataField="RIT" HeaderText="RIT"></asp:BoundField>
                                            <asp:ButtonField Text="Historico" CommandName="Historico" HeaderText="Historico"></asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        <PagerStyle CssClass="pager-tabla" ForeColor="white" />
                                        <RowStyle CssClass="table-bordered caja-tabla" />
                                    </asp:GridView>
                                </div>

                            </div>
                        </asp:Panel>
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <br />
                                <asp:GridView ID="grdHistorialProteccion" runat="server" OnRowCommand="grdHistorialProteccion_RowCommand" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" EmptyDataText="No hay Información"
                                    AllowPaging="True" OnPageIndexChanging="grdNinosHistorial_PageIndexChanged" PageSize="200">
                                    <Columns>
                                        <asp:BoundField DataField="Traspaso" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="ICodIE" HeaderText="C&#243;digo Ingreso"></asp:BoundField>
                                        <asp:BoundField DataField="Run" HeaderText="RUN" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" DataFormatString="{0:d}" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" SortExpression="FechaIngreso" DataFormatString="{0:d}"></asp:BoundField>
                                        <asp:BoundField DataField="CodProyecto" HeaderText="Cod Centro o Programa"></asp:BoundField>
                                        <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre Centro o Programa"></asp:BoundField>
                                        <asp:BoundField DataField="ModeloIntervencion" HeaderText="Modelo Intervenci&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="Tribunal" HeaderText="Tribunal"></asp:BoundField>
                                        <asp:BoundField DataField="RUC" HeaderText="RUC"></asp:BoundField>
                                        <asp:BoundField DataField="RIT" HeaderText="RIT"></asp:BoundField>
                                        <asp:BoundField DataField="CausalIngreso" HeaderText="Causal Ingreso"></asp:BoundField>
                                        <asp:BoundField DataField="EntidadAsigna" HeaderText="Quien Asig. Causal"></asp:BoundField>
                                        <asp:BoundField DataField="CausalIngreso2" HeaderText="Causal Ingreso 2"></asp:BoundField>
                                        <asp:BoundField DataField="EntidadAsigna2" HeaderText="Quien Asig. Causal 2"></asp:BoundField>
                                        <asp:BoundField DataField="CausalIngreso3" HeaderText="Causal Ingreso 3"></asp:BoundField>
                                        <asp:BoundField DataField="EntidadAsigna3" HeaderText="Quien Asig. Causal 3"></asp:BoundField>
                                        <asp:BoundField DataField="FechaEgreso" HeaderText="Fecha Egreso" DataFormatString="{0:d}"></asp:BoundField>
                                        <asp:BoundField DataField="CausalEgreso" HeaderText="CausalEgreso"></asp:BoundField>
                                        <asp:BoundField DataField="ConQuienEgresa" HeaderText="Con Quien Egresa"></asp:BoundField>
                                        <asp:ButtonField CommandName="Diagnosticos" Text="Diagn&#243;sticos" HeaderText="Diagnósticos"></asp:ButtonField>
                                        <asp:ButtonField CommandName="PII" Text="PII" Visible="False"></asp:ButtonField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <PagerStyle CssClass="pager-tabla" />
                                    <RowStyle CssClass="table-bordered caja-tabla" />

                                </asp:GridView>
                            </div>
                            <div class="col-md-12">
                                <asp:Panel ID="pnl_Historico" runat="server" Visible="False" Width="100%" Style="overflow-x: auto; width: auto;">
                                    <asp:Label ID="lblTraspasos" runat="server" CssClass="help-block" Text="* = Ingreso por traspaso de otro Proyecto"></asp:Label>
                                    <asp:Label ID="lblDescripcionNino" CssClass="subtitulo-form" runat="server" Text="lblDescripcionNino" Width="100%"></asp:Label>


                                    <asp:GridView ID="grdNinos_Historial" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay Información"
                                        AllowPaging="True" OnPageIndexChanging="grdNinosHistorial_PageIndexChanged" CssClass="table table-bordered table-hover" PageSize="200" OnRowCommand="grdNinos_Historial_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="Traspaso" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="ICodIE" HeaderText="C&#243;digo Ingreso"></asp:BoundField>
                                            <asp:BoundField DataField="Run" HeaderText="RUN" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" SortExpression="FechaNacimiento" DataFormatString="{0:d}" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="Edad" HeaderText="Edad" SortExpression="Edad" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" SortExpression="FechaIngreso" DataFormatString="{0:d}"></asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod Centro o Programa"></asp:BoundField>
                                            <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre Centro o Programa"></asp:BoundField>
                                            <asp:BoundField DataField="Nemotecnico" HeaderText="Medida o Sanci&#243;n"></asp:BoundField>
                                            <asp:BoundField DataField="CalidadJuridica" HeaderText="Calidad Jur&#237;dica"></asp:BoundField>
                                            <asp:BoundField DataField="Tribunal" HeaderText="Tribunal"></asp:BoundField>
                                            <asp:ButtonField CommandName="ruc" DataTextField="RUC" HeaderText="RUC" Text="RUC"></asp:ButtonField>
                                            <asp:BoundField DataField="RIT" HeaderText="RIT"></asp:BoundField>
                                            <asp:BoundField DataField="Delito" HeaderText="Delito"></asp:BoundField>
                                            <asp:BoundField DataField="CodDelito" HeaderText="Cod Delito"></asp:BoundField>
                                            <asp:BoundField DataField="Delito2" HeaderText="Delito 2"></asp:BoundField>
                                            <asp:BoundField DataField="CodDelito2" HeaderText="Cod Delito 2"></asp:BoundField>
                                            <asp:BoundField DataField="Delito3" HeaderText="Delito 3"></asp:BoundField>
                                            <asp:BoundField DataField="CodDelito3" HeaderText="Cod Delito 3"></asp:BoundField>
                                            <asp:BoundField DataField="FechaInicioSancion" HeaderText="Fecha Inicio Sanci&#243;n" DataFormatString="{0:d}"></asp:BoundField>
                                            <asp:BoundField DataField="AnosDuracionSancion" HeaderText="Sanci&#243;n Duraci&#243;n (A&#241;os)"></asp:BoundField>
                                            <asp:BoundField DataField="MesesDuracionSancion" HeaderText="Sanci&#243;n Duraci&#243;n (Meses)"></asp:BoundField>
                                            <asp:BoundField DataField="DiasDuracionSancion" HeaderText="Sanci&#243;n Duraci&#243;n (D&#237;as)"></asp:BoundField>
                                            <asp:BoundField DataField="Abono" HeaderText="Abono"></asp:BoundField>
                                            <asp:BoundField DataField="SancionAccesoria" HeaderText="Sanci&#243;n Accesoria"></asp:BoundField>
                                            <asp:BoundField DataField="FechaTerminoSancionCalculada" HeaderText="Fecha Termino Sanci&#243;n (Calculada)" DataFormatString="{0:d}"></asp:BoundField>
                                            <asp:BoundField DataField="FechaTerminoSancion" HeaderText="Fecha Termino Sanci&#243;n" DataFormatString="{0:d}"></asp:BoundField>
                                            <asp:BoundField DataField="FechaEgreso" HeaderText="Fecha Egreso" DataFormatString="{0:d}"></asp:BoundField>
                                            <asp:BoundField DataField="CausalEgreso" HeaderText="Causal Egreso"></asp:BoundField>
                                            <asp:BoundField DataField="ruc" HeaderText="RUC"></asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        <PagerStyle CssClass="pager-tabla" />
                                        <RowStyle CssClass="table-bordered caja-tabla" />

                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>




                <%-- Presionando Historico --%>


                <%-- Presionando RUC --%>


                <!-- Codigo Anterior -->

                <table id="TABLE1" width="100%">
                    <tr>
                        <td class="titulo_form" colspan="2">&nbsp;</td>
                    </tr>
                </table>

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

        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <%--<script src="../js/bootstrap.min.js"></script>--%>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <%--<script src="../js/ie10-viewport-bug-workaround.js"></script>--%>
        <!-- Latest compiled and minified JavaScript -->

    </form>
</body>
</html>
