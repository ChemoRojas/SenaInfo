<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/SenainfoSdk/SenainfoHistorico.master"
    CodeBehind="wf_GestionFinanciera.aspx.cs"
    Inherits="Historico.GestionFinanciera.mod_historico_wf_GestionFinanciera" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/SenainfoSdk/I_Region.ascx" TagPrefix="uc1" TagName="I_Region" %>
<%@ Register Src="~/SenainfoSdk/I_Institucion.ascx" TagPrefix="uc1" TagName="I_Institucion" %>
<%@ Register Src="~/SenainfoSdk/I_Proyecto.ascx" TagPrefix="uc1" TagName="I_Proyecto" %>
<%@ Register Src="~/SenainfoSdk/C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHead" runat="Server">
    Gestión Financiera - Histórico :: Sistema Histórico :: Servicio Nacional de Menores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHead" runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BreadcrumbContent" runat="Server">
    <li><a id="A2" href="../../index.aspx" runat="server">Inicio</a></li>
    <li class="active"><strong>Sistema Histórico</strong></li>
    <li class="active"><strong>Gestión Financiera - Hist&oacute;rico</strong></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
            <asp:UpdatePanel ID="up_GestionFinanciera" runat="server" ChildrenAsTriggers="true">


                <Triggers>
                    <asp:PostBackTrigger ControlID="gv_Reportes" />

                </Triggers>


                <ContentTemplate>

                    <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
                    <br />

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
                                            <uc1:I_Region runat="server" ID="I_Region" TextoDefault="TODAS" OnCodRegionSeleccionadoCambio="I_Region_CodRegionSeleccionadoCambio"  />

                                            <%--<asp:DropDownList ID="ddlRegion" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>--%>

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
                                    </tr>--%>

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
                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:Label ID="lblFechaDesde" runat="server">Fecha desde</asp:Label>
                                    <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDesde" PopupButtonID="txtFechaDesde" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filtroDesde" runat="server" TargetControlID="txtFechaDesde" ValidChars="0123456789-" />
                                    <asp:Label ID="lblALaFecha" runat="server">A la fecha</asp:Label>
                                    <asp:TextBox ID="txtALaFecha" runat="server" CssClass="form-control input-sm" Enabled="false" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="MM/yyyy" ID="CalendarExtender3" runat="server" TargetControlID="txtALaFecha" PopupButtonID="txtALaFecha" DefaultView="Months" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filtroA" runat="server" TargetControlID="txtALaFecha" ValidChars="0123456789-" />

                                </div>

                            </div>

                            <div class="col-md-2">

                                <div class="form-group">

                                    <asp:Label ID="lblFechaHasta" runat="server">Fecha hasta</asp:Label>
                                    <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtFechaHasta" PopupButtonID="txtFechaHasta" TodaysDateFormat="MMMM d,  yyyy" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filtroHasta" runat="server" TargetControlID="txtFechaHasta" ValidChars="0123456789-" />

                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="LnkBtnContinuar" CssClass="btn btn-info btn-sm pull-right" OnClick="ValidaCamposDeFecha" Text="">
                                            <span class="glyphicon glyphicon-check"></span>&nbsp Continuar
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="well" runat="server" id="PnelInformes" visible="false">
                        <h5 class="subtitulo-form">
                            <img src="../../images/excel-ico.png" />&nbsp Informes Excel</h5>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <div class="form-group">
                                    <asp:LinkButton id="Lnk_Rendiciones" OnClick="Rendiciones_ServerClick" runat="server" style="font-size:11pt;color:blue;">Información de Rendiciones</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                    <asp:LinkButton id="Lnk_Atenciones" runat="server" OnClick="Atenciones_ServerClick" style="font-size:11pt;color:blue;">Información de Atenciones</asp:LinkButton>
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
                                        RowStyle-Wrap="true" OnSelectedIndexChanged="GvwInformes_SelectedIndexChanged" >
                                        <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                        <Columns>
                                            <asp:BoundField DataField="codreporte" HeaderText="Código" HeaderStyle-CssClass="" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                                <ItemStyle Width="" Font-Size="Medium" HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="url" HeaderText="URL" Visible="false" />
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
                                            
<%--                                            <asp:TemplateField HeaderText="Seleccionar" HeaderStyle-Font-Size="Large"
                                                ItemStyle-Width="" ItemStyle-HorizontalAlign="Center">--%>
<%--                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Font-Size="14pt"></asp:TextBox>
                                                </EditItemTemplate>--%>

                                                <%--<ItemTemplate>--%>
                                                    <%--<asp:Label ID="Label1" runat="server"></asp:Label>--%>

<%--                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Bind("url") %>' runat="server" Target="_blank" ForeColor="Blue" Font-Size="12pt" >
                                                        Generar
                                                    </asp:HyperLink>
--%>
<%--                                                    <asp:Label ID="LblSeleccionado" runat="server" Font-Size="14pt" ></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Size="12pt" ForeColor="White" />
                                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                            </asp:TemplateField>--%>


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
                                        RowStyle-Wrap="true">
                                        <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                        <Columns>

                                            <asp:BoundField DataField="codreporte" HeaderText="Código" HeaderStyle-CssClass="" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Width="100px" Font-Size="Medium" HorizontalAlign="Center" />
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

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>