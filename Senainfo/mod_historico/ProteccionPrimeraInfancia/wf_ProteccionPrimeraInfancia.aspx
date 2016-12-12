<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/SenainfoSdk/SenainfoHistorico.master"
    CodeBehind="wf_ProteccionPrimeraInfancia.aspx.cs"
    Inherits="Historico.ProteccionPrimeraInfancia.mod_historico_wf_ProteccionPrimeraInfancia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/SenainfoSdk/I_Institucion.ascx" TagPrefix="uc1" TagName="I_Institucion" %>
<%@ Register Src="~/SenainfoSdk/I_Proyecto.ascx" TagPrefix="uc1" TagName="I_Proyecto" %>
<%@ Register Src="~/SenainfoSdk/C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHead" runat="Server">
    Proteccion Primera Infancia - Histórico :: Sistema Histórico :: Servicio Nacional de Menores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHead" runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BreadcrumbContent" runat="Server">
    <li><a id="A1" href="../../index.aspx" runat="server">Inicio</a></li>
    <li class="active"><strong>Sistema Histórico</strong></li>
    <li class="active"><strong>Protección Primera Infancia - Histórico</strong></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
<asp:UpdatePanel ID="up_ProteccionPrimeraInfancia" runat="server">


                <Triggers>
                    <asp:PostBackTrigger ControlID="gv_Reportes" />

                </Triggers>


                <ContentTemplate>
                    
                    <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
                    <br />

                    <script>
                        function mostrarModalMensaje() {

                            $('body').addClass('stopScroll');
                            //Añadimos un div con capa z-index 2 (intermedio) sobre el formulario principal
                            $('#form1').append('<div id="over" style="position: absolute;top:0;left:0;width: 100%;height:100%;z-index:2;background-color: rgba(0, 0 , 0, 0.5);"></div>');
                            $('#<% = PanelModalMensaje.ClientID %>').fadeIn(500);
                        }

                        function cerrarModalMensaje() {

                            $('#<% = PanelModalMensaje.ClientID %>').hide();
                            $('body').removeClass('stopScroll');
                            //Eliminamos el div con capa
                            $('#over').remove();
                        }


                    </script>


                    <!-- Div universo -->

                    <div class="well">

                        <h4 class="subtitulo-form">Universo de datos</h4>
                        <hr />

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-bordered table-condensed" id="formulario">
                                    <tbody>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">
                                            <label>Región</label>

                                        </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">
                                            <label>Provincia</label>

                                        </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlProvincia" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">
                                            <label>Comuna</label>

                                        </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlComuna" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlComuna_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>

<%--                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">
                                            <label>Institución</label>

                                        </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlInstitucion" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </td>
                                    </tr>
--%>
                                    </tbody>
                                </table>

                                <table class="table table-bordered table-condensed" id="Table2">
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row"><label>Institucion</label></th>
                                            <td class="col-md-4">
                                                <uc1:I_Institucion runat="server" ID="I_Institucion" UsarAllInOne="False" TextoDefault="TODAS" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla col-md-1" scope="row"><label>Proyecto</label></th>
                                            <td class="col-md-4">
                                                <uc1:I_Proyecto runat="server" ID="I_Proyecto" UsarAllInOne="False" TextoDefault="TODAS" InstitucionControlID="I_Institucion" OnCodProyectoSeleccionadoCambio="I_Proyecto_CodProyectoSeleccionadoCambio" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <%--<uc1:C_buscar_x_institu_proyecto ID="C_buscar_x_institu_proyecto" Estado="Todos" runat="server" OnCodProyectoSeleccionadoCambio="C_buscar_x_institu_proyecto1_CodProyectoSeleccionadoCambio" />
                                            <asp:TextBox ID="txtCodigoProyecto" ReadOnly="true" CssClass="form-control" runat="server"  Visible="false"/>
                                            <asp:TextBox ID="txtCodigoInstitucion" ReadOnly="true" CssClass="form-control" runat="server"  Visible="false"/>--%>

                                <table class="table table-bordered table-condensed" id="Table1">
                                    <tbody>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">
                                            <label>Temática</label>
                                        </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlTematica" CssClass="form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTematica_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                    </tr>


                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">
                                            <label>Modelo de Intervención</label>
                                        </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlModeloIntervencion" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModeloIntervencion_SelectedIndexChanged"></asp:DropDownList>

                                        </td>
                                    </tr>


                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton runat="server" ID="btnLimpiar" CssClass="btn btn-info btn-sm pull-right" OnClick="btnLimpiar_Click1" Text="">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp Limpiar
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>



                    </div>
                    <div class="well">
                        <h5 class="subtitulo-form">Filtros de Búsqueda</h5>
                        <br />
                        <div class="row" id="filtros">

                            <!-- Columna 1 -->

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:RadioButton ID="rbIngreso" Text="&nbspIngreso" runat="server" GroupName="grupo2" OnCheckedChanged="rbIngreso_CheckedChanged" AutoPostBack="true" />&nbsp

                                </div>

                            </div>

                            <!-- Columna 2 -->

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:RadioButton ID="rbEgreso" Text="&nbspEgreso" runat="server" GroupName="grupo2" OnCheckedChanged="rbEgreso_CheckedChanged" AutoPostBack="true" />

                                </div>

                            </div>

                            <!-- Columna 3 -->

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:RadioButton ID="rbAtendidos" Text="&nbspAtendidos" runat="server" GroupName="grupo2" OnCheckedChanged="rbAtendidos_CheckedChanged" AutoPostBack="true" />

                                </div>

                            </div>

                            <!-- Columna 4 -->

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:RadioButton ID="rbVigentes" Text="&nbspVigentes" runat="server" GroupName="grupo2" OnCheckedChanged="rbVigentes_CheckedChanged" AutoPostBack="true" />

                                </div>

                            </div>

                            <!-- Columna 5 -->

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:Label ID="lblFechaDesde" runat="server">Fecha desde</asp:Label>
                                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDesde" PopupButtonID="txtFechaDesde" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filtroDesde" runat="server" TargetControlID="txtFechaDesde" ValidChars="0123456789-"  />
                                    <asp:Label ID="lblALaFecha" runat="server">A la fecha</asp:Label>
                                    <asp:TextBox ID="txtALaFecha" runat="server" CssClass="form-control input-sm" Enabled="false" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" ID="CalendarExtender3" runat="server" TargetControlID="txtALaFecha" PopupButtonID="txtALaFecha" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filtroA" runat="server" TargetControlID="txtALaFecha" ValidChars="0123456789-" />


                                </div>

                            </div>

                            <!-- Columna 6 -->

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:Label ID="lblFechaHasta" runat="server">Fecha hasta</asp:Label>
                                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control input-sm" MaxLength="10" ></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtFechaHasta" PopupButtonID="txtFechaHasta" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filtroHasta" runat="server" TargetControlID="txtFechaHasta" ValidChars="0123456789-" />

                                </div>

                            </div>


                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="LnkBtnContinuar" CssClass="btn btn-info btn-sm pull-right" OnClick="ValidaCamposDeFecha" Text="">
                                            <span class="glyphicon glyphicon-check"></span>&nbsp Continuar
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>


                    <!-- Fin div filtros -->



                    <!-- Subtitulo -->




                    <!-- Row -->



                    <div class="well" runat="server" id="PnelInformes" visible="false">
                        <h5 class="subtitulo-form">
                            <img src="../../images/excel-ico.png" />&nbsp Informes Excel
                        </h5>
                        <div class="row">

                            <div class="col-md-12">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:LinkButton id="Lnk_NNA" OnClick="NNA_ServerClick" runat="server" style="font-size:11pt;color:blue;">Información de NNA</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:LinkButton id="Lnk_Permanencias" runat="server" OnClick="Permanencias_ServerClick" style="font-size:11pt;color:blue;">Información de Permanencias</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:LinkButton id="Lnk_Inimputables" runat="server" OnClick="Inimputables_ServerClick" style="font-size:11pt;color:blue;">Información de Inimputables</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:LinkButton id="Lnk_CDP" runat="server" OnClick="CDP_ServerClick" style="font-size:11pt;color:blue;">Información de CDP</asp:LinkButton>
                                        </div>
                                    </div>
                            </div>
                        </div>

                    </div>



                    <div class="well" runat="server" id="PnelSeleccionarInformes" visible="false">
                        <h4 class="subtitulo-form">
                            <img src="../../images/excel-ico.png" />&nbsp 
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

                                            <asp:TemplateField HeaderText="Acción" HeaderStyle-Font-Size="Large"
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
                            <div class="col-md-10">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-info btn-sm pull-right" OnClick="SolicitaInformes" Text="">
                                            <span class="glyphicon glyphicon-ok"></span>&nbsp Solicitar Informes Seleccionados
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-info btn-sm pull-right" OnClick="MuestraPnelInformes" Text="">
                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp Volver a Informes Excel
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>



                    </div>


                    </div>

                    <!-- Fin div universo -->

                    <!-- Div  mensajes validacion -->


                    <asp:Panel ID="PanelModalMensaje" runat="server" class="panelReporte">
                        <div class="header-modal" style="height: 80px; padding: 5px;">
                            <asp:Button ID="Button2" runat="server" Text="X" CssClass="close" OnClick="btn_Continuar_Click" CausesValidation="False" />
                            <h3 id="H1" style="text-align: center">Informes</h3>
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
                                        OnSelectedIndexChanged="gv_Reportes_SelectedIndexChanged"
                                        RowStyle-Wrap="true">
                                        <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                        <Columns>

                                            <asp:BoundField DataField="codreporte" HeaderText="Código" HeaderStyle-CssClass="" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                                <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Acción"  HeaderStyle-Font-Size="Medium"
                                                ItemStyle-Width="" ItemStyle-HorizontalAlign="Center">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                </EditItemTemplate>

                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ver1" ForeColor="Red"
                                                        OnClick="LinkButton1_Click" Visible="true">Ver1 

                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Excel.aspx" Target="_blank"
                                                        ForeColor="Blue" Font-Bold="true" Font-Size="12pt">Exportar</asp:HyperLink>

                                                    </asp:LinkButton>

                                                </ItemTemplate>


                                                <HeaderStyle Font-Size="11px" ForeColor="White" />
                                                <ItemStyle Width="20%" />
                                            </asp:TemplateField>

                                            <asp:CommandField ShowSelectButton="True" runat="server" ButtonType="Button" HeaderText="Seleccionar" />




                                            <asp:CheckBoxField HeaderText="Elegir" Text="x" />




                                        </Columns>
                                        <RowStyle Wrap="True" />
                                    </asp:GridView>



                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                        </div>
                    </asp:Panel>

                    <!-- Fin div validacion -->

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
