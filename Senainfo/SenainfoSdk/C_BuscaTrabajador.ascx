<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="C_BuscaTrabajador.ascx.cs" Inherits="SenainfoSdk.UI.C_BuscaTrabajador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="C_FormatRut.ascx" TagPrefix="uc1" TagName="C_FormatRut" %>

<asp:LinkButton ID="lbn_buscar_trabajador" runat="server" CssClass="btn btn-info btn-sm input-group-addon" OnClick="lbn_buscar_trabajador_Click">
          <span class="glyphicon glyphicon-question-sign"></span>
</asp:LinkButton>


<cc1:ModalPopupExtender ID="mpe" runat="server"
    PopupControlID="Panel1"
    DropShadow="true"
    TargetControlID="lbn_buscar_trabajador"
    CancelControlID="lnb_close_buscar_trabajador"
    BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

<asp:Panel ID="Panel1" runat="server" align="center" Style="display: none">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="grdTabajadores" />
            <asp:PostBackTrigger ControlID="btnBuscar" />
            <asp:PostBackTrigger ControlID="lnb_close_buscar_trabajador" />
        </Triggers>
        <ContentTemplate>
            <div class="popupConfirmation" id="modal_trabajador">
                <div class="modal-header header-modal">
                    <asp:LinkButton ID="lnb_close_buscar_trabajador" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                <span aria-hidden="true">&times;</span>
                    </asp:LinkButton>
                    <h4 class="modal-title">BUSCAR TRABAJADOR</h4>
                </div>
                <div class="container">

                    <asp:Panel ID="pnl001" runat="server" Width="100%">
                        <table class="table table-bordered table-col-fix table-condensed">
                            <caption>
                                <asp:Label ID="lbl001" runat="server"></asp:Label></caption>
                            <tbody>
                                <tr id="tr_codigo_institucion" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl002" runat="server" Text="Código Institución"></asp:Label></th>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>

                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtCodInst" CssClass="form-control input-sm" Style="width: 50px;" runat="server"></asp:TextBox>
                                                        <asp:LinkButton ID="imgGetInst" CssClass="input-group-addon btn btn-info" runat="server" CausesValidation="False" OnClick="imgGetInst_Click" AutoPostback="true">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>

                                                </td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlInstitucion" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged" Visible="true" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr id="tr_institucion" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl004" runat="server" Text="Institución"></asp:Label></th>
                                    <td>
                                        <asp:TextBox ID="txtInstitucion" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr id="tr_rut_tecnico" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl006" runat="server" Text="Run Técnico"></asp:Label></th>
                                    <td>
                                        <uc1:C_FormatRut ID="C_FormatRutTecnico" runat="server"></uc1:C_FormatRut>
                                    </td>
                                </tr>
                                <tr id="tr_apellido_paterno" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl007" runat="server" Text="Apellido Paterno"></asp:Label></th>
                                    <td>
                                        <asp:TextBox ID="txtApPatTecn" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_apellido_materno" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl008" runat="server" Text="Apellido Materno"></asp:Label></th>
                                    <td>
                                        <asp:TextBox ID="txtApMatTecn" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_nombres" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl009" runat="server" Text="Nombres"></asp:Label></th>
                                    <td>
                                        <asp:TextBox ID="txtNomTecn" runat="server" CssClass="form-control  input-sm" />
                                    </td>
                                </tr>

                                <tr id="tr_vigencia" runat="server">
                                    <th class="titulo-tabla" scope="row">
                                        <asp:Label ID="lbl020" runat="server" Text="Vigencia"></asp:Label></th>
                                    <td>
                                        <asp:RadioButtonList ID="chkVigencia" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="V">Vigente</asp:ListItem>
                                            <asp:ListItem Value="C">Caducado</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>

                    <div class="text-center">
                        <div class="row">
                            <div class="alert alert-warning" runat="server" visible="false" id="alertSinRegistros">
                                <span class="glyphicon glyphicon-warning-sign"></span>&nbsp; No se han encontrado registros
                            </div>
                        </div>
                    </div>

                    <div>
                        <h4>
                            <asp:Label ID="lbl0014" runat="server" CssClass="subtitulo-form" Text="Coincidencias" Visible="False"></asp:Label></h4>
                        <asp:GridView ID="grdTabajadores" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Visible="False" AllowPaging="True" OnRowCommand="grdTabajadores_rowcommand" OnPageIndexChanging="grdTabajadores_PageIndexChanging" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="ICodTrabajador" HeaderText="Cod. Trabajador"></asp:BoundField>
                                <asp:BoundField DataField="CodInstitucion" HeaderText="Cod. Instituci&#243;n"></asp:BoundField>
                                <asp:BoundField DataField="Paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                <asp:BoundField DataField="Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                <asp:BoundField DataField="RutTrabajador" HeaderText="RUN Trabajador"></asp:BoundField>
                                <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="VigRelacionProy" HeaderText="Vigencia en Proyecto" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="VigenciaTrabajador" HeaderText="Vigencia Trabajador" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="Institucion" HeaderText="Institución" Visible="False"></asp:BoundField>
                                <asp:ButtonField Text="Ver" CommandName="V" HeaderText="Ver"></asp:ButtonField>
                                <asp:ButtonField CommandName="Relacionar" Text="Nueva" Visible="False" HeaderText="Nueva"></asp:ButtonField>
                            </Columns>
                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                            <RowStyle CssClass="table-bordered caja-tabla" />
                        </asp:GridView>
                    </div>
                    <div class="row">
                        <div class="botonera pull-right">
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" AutoPostback="true">
                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnLimpiar" runat="server" AutoPostback="true" OnClick="btnLimpiaBusqueda_Click">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button" ID="btnCancelarBusqueda_NEW" runat="server" OnClick="btnCancelar_Click" CausesValidation="False" Visible="False">
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>


            </div>
            <%--<script type="text/javascript">
                    $(document).ready(function () {
                        $('#<%=this.txtRunTecnico.ClientID%>').RUT({
                            on_error: function () {
                                alert('RUT Incorrecto');
                                $('#<%=this.txtRunTecnico.ClientID%>').val('');
                    $('#<%=this.txtRunTecnico.ClientID%>').focus();
                },
                            format_on: 'keyup'
                        });
                    });
                var prm = Sys.WebForms.PageRequestManager.getInstance();

                prm.add_endRequest(function () {
                    $('#<%=this.txtRunTecnico.ClientID%>').RUT({
            on_error: function () {
                alert('RUT Incorrecto');
                $('#<%=this.txtRunTecnico.ClientID%>').val('');
                $('#<%=this.txtRunTecnico.ClientID%>').focus();
            },
            format_on: 'keyup'
        });
    });

            </script>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>





