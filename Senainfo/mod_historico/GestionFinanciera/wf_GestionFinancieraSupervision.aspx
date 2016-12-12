<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/SenainfoSdk/SenainfoHistorico.master"
    CodeBehind="wf_GestionFinancieraSupervision.aspx.cs"
    Inherits="Historico.GestionFinanciera.mod_historico_wf_GestionFinancieraSupervision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Src="~/SenainfoSdk/I_Institucion.ascx" TagPrefix="uc1" TagName="I_Institucion" %>
<%@ Register Src="~/SenainfoSdk/I_Proyecto.ascx" TagPrefix="uc1" TagName="I_Proyecto" %>
<%@ Register Src="~/SenainfoSdk/C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHead" runat="Server">
    Gestión Financiera - Supervisión :: Sistema Histórico :: Servicio Nacional de Menores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BreadcrumbContent" runat="Server">
    <li><a id="A2" href="../../index.aspx" runat="server">Inicio</a></li>
    <li class="active"><strong>Sistema Histórico</strong></li>
    <li class="active"><strong>Gestión Financiera - Supervisión</strong></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="up_GestionFinancieraSupervision" runat="server" ChildrenAsTriggers="true">
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="gv_Proyectos" />--%>
            <%--<asp:AsyncPostBackTrigger ControlID="lnkBuscarProyecto" />--%>
            <asp:PostBackTrigger ControlID="gv_Reportes" />

        </Triggers>


        <ContentTemplate>

            <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
            <br />

            <%--                    <script>

                        function mostrarModalProyectos(x) {

                            var cont = x;

                            if (cont == 0) {
                                $('#form1').append('<div id="over" style="z-index:2; background-color: rgba(0, 0 , 0, 0.5); position: absolute; top:0; left:0; width:100%; height:100%;"></div>');
                            }

                            $('#<% = panelProyectos.ClientID %>').show();
                            $('body').addClass('stopScroll');


                        }

                        function cerrarModalProyectos() {

                            $('#<% = panelProyectos.ClientID %>').hide();
                            $('body').removeClass('stopScroll');
                            //Eliminamos el div con capa
                            $('#over').remove();
                        }

                    </script>
            --%>

            <!-- Div universo -->

            <div class="well">

                <h4 class="subtitulo-form">Universo de datos</h4>
                <hr />

                <div class="row">
                    <div class="col-md-12">
                        <table class="table table-bordered table-condensed" id="Table2">
                            <tbody>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">
                                        <label>Institucion</label></th>
                                    <td class="col-md-4">
                                        <uc1:I_Institucion runat="server" ID="I_Institucion" UsarAllInOne="False" TextoDefault="TODAS" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">
                                        <label>Proyecto</label></th>
                                    <td class="col-md-4">
                                        <uc1:I_Proyecto runat="server" ID="I_Proyecto" UsarAllInOne="False" TextoDefault="TODAS" InstitucionControlID="I_Institucion" OnCodProyectoSeleccionadoCambio="I_Proyecto_CodProyectoSeleccionadoCambio" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:LinkButton runat="server" ID="btnLimpiar" CssClass="btn btn-info btn-sm pull-right" OnClick="btnLimpiarFiltros_Click" Text="">
                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp Limpiar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

            <asp:Panel ID="PanelModalMensaje" runat="server" class="panelReporte">
                <div class="header-modal" style="height: 80px; padding: 5px;">
                    <asp:Button ID="btnCerrarMensaje" runat="server" Text="X" CssClass="close" OnClick="btnCerrarMensaje_Click" CausesValidation="False" />
                    <h3 id="H2" style="text-align: center">Informes</h3>
                </div>
                <div class="modal-body">
                    <br />
                    <!-- Div reportes -->

                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gv_Reportes" runat="server" CssClass="table table table-bordered table-hover caja-tabla" CellPadding="3" ForeColor="Black"
                                GridLines="Vertical"
                                AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                RowStyle-Wrap="true">
                                <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                <Columns>

                                    <asp:BoundField DataField="codreporte" HeaderText="Código" HeaderStyle-CssClass="" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                        <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:CommandField ShowSelectButton="True" CausesValidation="False" SelectText="Exportar" ButtonType="Button" ItemStyle-HorizontalAlign="Center" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                </div>
            </asp:Panel>

            <%--                        <asp:Panel ID="panelProyectos" runat="server" class="panelReporte">
                            <div class="header-modal" style="height: 80px; padding: 5px;">
                                <asp:Button ID="btnSalir" runat="server" Text="X" CssClass="close" OnClick="btnSalir_Click" CausesValidation="False" />
                                <h3 id="H1" style="text-align: center">Búsqueda de Proyectos</h3>
                            </div>
                            <div class="modal-body">
                                <br />
                                <!-- Div reportes -->

                                <div class="row" style="margin-left: 0px; margin-right: 0px;">
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-sm-1">
                                                <asp:Label runat="server" Text="Código" ID="lblCodigo"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control input-sm" ID="txtCodigo"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCodigo" ValidChars="0123456789" />
                                            </div>

                                            <div class="col-sm-1">
                                                <asp:Label runat="server" Text="Nombre" ID="lblNombre"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control input-sm" ID="txtNombre"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtNombre" ValidChars=" ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                            </div>

                                            <div class="col-sm-1">
                                                <asp:Label runat="server" Text="Código Institución" ID="lblInstitucion"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox runat="server" CssClass="form-control input-sm" ID="txtCodigoInstitucion"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCodigoInstitucion" ValidChars="0123456789" />
                                            </div>

                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="col-md-9">
                                                <asp:Label runat="server" ID="lblRegistros"></asp:Label>
                                            </div>
                                            <div class="col-md-3" style="text-align:right">
                                                <asp:LinkButton runat="server" ID="lnkBuscarProyecto" CssClass="btn btn-danger btn-sm" Width="100%" OnClick="lnkBuscarProyecto_Click">
                                                    <span class="glyphicon glyphicon-zoom-in"></span>&nbspBuscar
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <br />

                            </div>
                            <div class="modal-footer">

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="gv_Proyectos" runat="server" CssClass="table table table-bordered table-hover caja-tabla" CellPadding="3" ForeColor="Black"
                                            GridLines="Vertical"
                                            AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            OnSelectedIndexChanged="gv_Proyectos_SelectedIndexChanged"
                                            RowStyle-Wrap="true">
                                            <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                            <Columns>

                                                <asp:BoundField DataField="codproyecto" HeaderText="Código Proyecto" HeaderStyle-CssClass="" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="nombre" HeaderText="Nombre Proyecto">
                                                    <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="codinstitucion" HeaderText="Código Institución">
                                                    <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fechacreacion" HeaderText="Fecha Creación">
                                                    <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="fechatermino" HeaderText="Fecha Termino">
                                                    <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="indvigencia" HeaderText="Vigencia">
                                                    <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                                </asp:BoundField>


                                                <asp:CommandField ShowSelectButton="True" CausesValidation="False" SelectText="Seleccionar" ButtonType="Button" ItemStyle-HorizontalAlign="Center" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                </div>
                        </asp:Panel>--%>

            <div class="well">
                <h5 class="subtitulo-form">Filtros de b&uacute;squeda</h5>
                <br />

                <!-- Row -->

                <div class="row" id="filtros">
                    <div class="col-sm-8">
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:Label ID="lblFechaDesde" runat="server">Fecha desde</asp:Label>
                                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>
                                <ajax:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDesde" PopupButtonID="txtFechaDesde" />
                                <ajax:FilteredTextBoxExtender ID="filtroDesde" runat="server" TargetControlID="txtFechaDesde" ValidChars="0123456789-" />

                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblFechaHasta" runat="server">Fecha hasta</asp:Label>
                                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>
                                <ajax:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtFechaHasta" PopupButtonID="txtFechaHasta" />
                                <ajax:FilteredTextBoxExtender ID="filtroHasta" runat="server" TargetControlID="txtFechaHasta" ValidChars="0123456789-" />

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="LnkBtnContinuar" CssClass="btn btn-info btn-sm pull-right" OnClick="ValidaCamposDeFecha" Text="">
                                            <span class="glyphicon glyphicon-check"></span>&nbsp Continuar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <div class="well" runat="server" id="PnelInformes" visible="false">

                <div class="row">
                    <div class="col-md-6">

                        <h5 class="subtitulo-form">
                            <img src="../../images/excel-ico.png" />&nbsp Informes</h5>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="Lnk_Rendiciones" OnClick="Rendiciones_ServerClick" runat="server" Style="font-size: 11pt; color: blue;">Informes Rendiciones</asp:LinkButton>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="Lnk_Atenciones" OnClick="Atenciones_ServerClick" runat="server" Style="font-size: 11pt; color: blue;">Informes Atenciones</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">

                        <h5 class="subtitulo-form">
                            <img src="../../images/pdf-ico.png" />&nbsp Reportes</h5>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-9">
                                        <asp:LinkButton ID="Lnk_InformacionRendiciones" OnClick="InformacionRendiciones_ServerClick" runat="server" Style="font-size: 11pt; color: blue;">Reportes Rendiciones</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

            <div class="well" runat="server" id="PnelSeleccionarInformes" visible="false">
                <h4 class="subtitulo-form">
                    <img id="IconoPnelSeleccionarInformes" runat="server" />&nbsp 
                            <asp:Label ID="LblTituloSelecionarInformes" runat="server"></asp:Label>
                </h4>
                <br />
                <div class="row" id="DivInformes">
                    <div class="row">
                        <div class="col-md-12">

                            <asp:GridView ID="GvwInformes" runat="server" CssClass="table table table-bordered table-hover caja-tabla" CellPadding="3" ForeColor="Black"
                                GridLines="Vertical"
                                AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                RowStyle-Wrap="true" OnSelectedIndexChanged="GvwInformes_SelectedIndexChanged">
                                <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                <Columns>
                                    <asp:BoundField DataField="codreporte" HeaderText="Código" HeaderStyle-CssClass="" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                        <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="url" HeaderText="URL" Visible="False" />
                                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" ItemStyle-Font-Size="12pt" />
                                    <asp:BoundField DataField="selecciona" ItemStyle-Font-Size="12pt" ItemStyle-Width="40px" />


                                    <%--                                            <asp:TemplateField HeaderText="url"  HeaderStyle-Font-Size="Medium"
                                                ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" Visible="False">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="url" runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle Font-Size="Medium" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                    --%>

                                    <%--                                            <asp:TemplateField HeaderText="Acción" HeaderStyle-Font-Size="Large"
                                                ItemStyle-Width="" ItemStyle-HorizontalAlign="Center">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                </EditItemTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("url") %>' runat="server" Target="_blank" ForeColor="Blue" Font-Size="12pt" >
                                                        Generar
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Size="12pt" ForeColor="White" />
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            </asp:TemplateField>
                                    --%>
                                </Columns>
                                <RowStyle Wrap="True" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-info btn-sm pull-right" OnClick="SolicitaInformes" Text="">
                                            <span class="glyphicon glyphicon-ok"></span>&nbsp Solicitar Informes Seleccionados
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-info btn-sm pull-right" OnClick="MuestraPnelInformes" Text="">
                                <span class="glyphicon glyphicon-arrow-left"></span>&nbsp
                                <asp:Label ID="LblBotonVolver" runat="server"></asp:Label>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>


            </div>



                    <!-- Fin div universo -->

            <!-- Div  mensajes validacion -->

            <!-- Fin div validacion -->


            <!-- Botón exportar -->
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
