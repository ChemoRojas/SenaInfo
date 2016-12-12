<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/SenainfoSdk/SenainfoHistorico.master"
    CodeBehind="wf_MonitorInformesSolicitados.aspx.cs"
    Inherits="Historico.MonitorInformesSolicitados.mod_historico_wf_MonitorInformesSolicitados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleHead" runat="Server">
    Monitor de Informes Solicitados :: Sistema Histórico :: Servicio Nacional de Menores
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHead" runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BreadcrumbContent" runat="Server">
    <li><a id="A2" href="../../index.aspx" runat="server">Inicio</a></li>
    <li class="active"><strong>Sistema Histórico</strong></li>
    <li class="active"><strong>Monitor de Informes Solicitados</strong></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="Server">
            <asp:UpdatePanel ID="up_MonitorInformesSolicitados" runat="server" ChildrenAsTriggers="true">


                <Triggers>
                    <%--<asp:PostBackTrigger ControlID="GvwInformesGenerados" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID="LinkBtnDescargar" />--%>
                    <asp:PostBackTrigger ControlID="GvwInformesGenerados" />
                </Triggers>


                <ContentTemplate>

                    <asp:Panel ID="pnlInfo" runat="server" Visible="false">
                        <div class="alert alert-info text-center" role="alert">
                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>&nbsp;
                            <asp:Label runat="server" ID="lblInfo" Text=""></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlError" runat="server" Visible="false">
                        <div class="alert alert-danger text-center" role="alert">
                            <span class="glyphicon glyphicon-warning-sign" aria-hidden="true"></span>&nbsp;
                            <asp:Label runat="server" ID="lblAlertError"></asp:Label>

                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlAlerta" runat="server" Visible="false">
                        <div class="alert alert-warning text-center" role="alert">
                            <span class="glyphicon glyphicon-warning-sign" aria-hidden="true"></span>&nbsp;
                            <asp:Label runat="server" ID="lblAlertAlerta"></asp:Label>

                        </div>
                    </asp:Panel>

            

                    <div class="well" runat="server" id="PnelSeleccionarInformes">
                        <h4 class="subtitulo-form">
                            <%--<img id="IconoPnelSeleccionarInformes" runat="server" />&nbsp--%> 
                            <asp:Label ID="LblTituloSelecionarInformes" runat="server">Monitor de Informes Solicitados</asp:Label>
                        </h4>
                        <br />

                        <h5 class="subtitulo-form">
                            <%--<img id="IconoPnelSeleccionarInformes" runat="server" />&nbsp--%> 
                            <asp:Label ID="Label1" runat="server">Informes Generados Listos para Descargar</asp:Label>
                        </h5>
                        <div class="row" id="DivInformesGenerados">
                            <div class="row">
                                <div class="col-md-12">

                                    <asp:GridView ID="GvwInformesGenerados" runat="server" CssClass="table table table-bordered table-hover caja-tabla" CellPadding="3" ForeColor="Black"
                                        GridLines="Vertical"
                                        AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        RowStyle-Wrap="true" OnSelectedIndexChanged="GvwInformesGenerados_SelectedIndexChanged">
                                        <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                        <Columns>
                                            <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha Solicitud">
                                                <ItemStyle Width="100px" Font-Size="11pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Id_SolicitudReporte" HeaderText="Solicitud">
                                                <ItemStyle Width="100px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreArea" HeaderText="Area">
                                                <ItemStyle Width="150px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreTipo" HeaderText="Tipo">
                                                <ItemStyle Width="100px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodReporte" HeaderText="Código Reporte">
                                                <ItemStyle Width="90px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreReporte" HeaderText="Nombre Reporte">
                                                <ItemStyle Width="350px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreEstado" HeaderText="Estado">
                                                <ItemStyle Width="90px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaGeneracion" HeaderText="Fecha de Generación">
                                                <ItemStyle Width="100px" Font-Size="11pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:CommandField ShowSelectButton="True" SelectText="Descargar">        
                                                <ItemStyle Width="90px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="selecciona" ItemStyle-Font-Size="12pt" ItemStyle-Width="40px" >
                                                <ItemStyle Font-Size="12pt" Width="40px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle Wrap="True" />
                                    </asp:GridView>
                                </div>
                            </div>

                        </div>

<%--                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="LinkBtnDescargar" CssClass="btn btn-info btn-sm pull-right" OnClick="DescargaInformesSolicitados" Text="">
                                            <span class="glyphicon glyphicon-download-alt"></span>&nbsp Descargar Informes Seleccionados
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
--%>
                        <hr />

                        <h5 class="subtitulo-form">
                            <asp:Label ID="Label2" runat="server">Informes Pendientes por Generar</asp:Label>
                        </h5>
                        <div class="row" id="DivInformesPendientes">
                            <div class="row">
                                <div class="col-md-12">

                                    <asp:GridView ID="GvwInformesPendientes" runat="server" CssClass="table table table-bordered table-hover caja-tabla" CellPadding="3" ForeColor="Black"
                                        GridLines="Vertical"
                                        AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        RowStyle-Wrap="true" OnSelectedIndexChanged="GvwInformesPendientes_SelectedIndexChanged">
                                        <HeaderStyle BackColor="#0f69b4" Font-Bold="True" ForeColor="White" CssClass="tablaReporte" />
                                        <Columns>
                                            <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha Solicitud">
                                                <ItemStyle Width="100px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Id_SolicitudReporte" HeaderText="Solicitud">
                                                <ItemStyle Width="100px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreArea" HeaderText="Area">
                                                <ItemStyle Width="150px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreTipo" HeaderText="Tipo">
                                                <ItemStyle Width="100px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodReporte" HeaderText="Código Reporte">
                                                <ItemStyle Width="90px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreReporte" HeaderText="Nombre Reporte">
                                                <ItemStyle Width="350px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombreEstado" HeaderText="Estado" Visible="False">
                                                <ItemStyle Width="90px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar">        
                                                <ItemStyle Width="90px" Font-Size="12pt" HorizontalAlign="Center" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="selecciona" ItemStyle-Font-Size="12pt" ItemStyle-Width="40px" >
                                                <ItemStyle Font-Size="12pt" Width="40px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle Wrap="True" />
                                    </asp:GridView>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-info btn-sm pull-right" OnClick="CancelaInformesSolicitados" Text="">
                                            <span class="glyphicon glyphicon-remove"></span>&nbsp Cancelar Solicitud de Informes Seleccionados
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>


                    </div>



                </ContentTemplate>
                
            </asp:UpdatePanel>
</asp:Content>