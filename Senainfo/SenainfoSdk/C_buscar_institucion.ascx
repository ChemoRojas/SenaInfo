<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_buscar_institucion.ascx.cs" Inherits="SenainfoSdk.UI.C_buscar_institucion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>


<asp:LinkButton ID="Lnk_InstitucionBuscar" runat="server" 
    CssClass="input-group-addon btn btn-info btn-sm" CausesValidation="False">
    <span class="glyphicon glyphicon-question-sign"></span>
</asp:LinkButton>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            //RUT Institucion
            $('#<%=this.txt002.ClientID%>').RUT({
                on_error: function () {
                    alert('RUT Incorrecto');
                    $('#<%=this.txt002.ClientID%>').val('');
                    $('#<%=this.txt002.ClientID%>').focus();
                },
                format_on: 'keyup'
            });
        });
    };

</script>


<asp:UpdatePanel ID="UpdatePanel_inst" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlPupupInstituciones" runat="server" Style="Display: none">
            <div class="popupConfirmation" id="modal_bsc_instituciones">
                <div class="modal-header header-modal">
                    <asp:LinkButton ID="btnCerrarModal1" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" OnClick="btnCerrarModal1_Click" Text="Cerrar">
	                    <span aria-hidden="true">&times;</span>
                    </asp:LinkButton>
                    <h4 class="modal-title">INSTITUCION</h4>
                </div>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnBuscar" />
                        </Triggers>
                        <ContentTemplate>
                            <div class="container">
                                <div id="divTODO">
                                    <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
                                    <asp:Panel ID="pnl001" runat="server">
                                        <table class="table table-bordered table-col-fix table-condensed">
                                            <caption>Buscador Instituciones</caption>
                                            <tbody>
                                                <tr id="tr_codigo_institucion" runat="server">
                                                    <th class="titulo-tabla" scope="row">Código Institución</th>
                                                    <td>
                                                        <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr_rut_institucion" runat="server">
                                                    <th class="titulo-tabla" scope="row">Rut Institución</th>
                                                    <td>
                                                        <asp:TextBox ID="txt002" runat="server" CssClass="form-control  input-sm" MaxLength="12"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr_institucion" runat="server">
                                                    <th class="titulo-tabla" scope="row">Institución</th>
                                                    <td>
                                                        <asp:TextBox ID="txt005" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr_tipo_institucion" runat="server">
                                                    <th class="titulo-tabla" scope="row">Tipo Institución</th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown004" runat="server" CssClass="form-control  input-sm">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr_vigencia" runat="server" visible="false">
                                                    <th class="titulo-tabla" scope="row">Vigencia</th>
                                                    <td>
                                                        <asp:RadioButtonList ID="chklist001" runat="server" RepeatDirection="Horizontal" Visible="False">
                                                            <asp:ListItem Selected="True" Value="V">Vigente</asp:ListItem>
                                                            <asp:ListItem Value="C">Caducado</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlResultado" runat="server">
                                        <asp:GridView ID="grd001" runat="server"
                                            Caption="Resultados"
                                            CssClass="table  table-bordered table-hover" Width="100%" 
                                            AutoGenerateColumns="False" AllowPaging="True" 
                                            OnRowCommand="grd001_RowCommand" 
                                            OnPageIndexChanging="grd001_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="CodInstitucion" HeaderText="C&#243;digo Instituci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Tipo Instituci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="RutInstitucion" HeaderText="Rut Instituci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                                                <asp:ButtonField Text="Ver" CommandName="V" HeaderText="Ver"></asp:ButtonField>
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </asp:Panel>

                                    <div class="row">
                                        <div class="botonera pull-right">
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnvolver" runat="server" OnClick="btnvolver_Click" Visible="false">
                                                <span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Volver
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" AutoPostback="true">
                                                <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnLimpiar" runat="server" AutoPostback="true" OnClick="btnLimpiar_Click">
                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button" ID="btnCancelar" runat="server" OnClick="btnCerrarModal1_Click" CausesValidation="False">
                                                <span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<ajax:ModalPopupExtender ID="MPE2" runat="server"
    TargetControlID="Lnk_InstitucionBuscar"
    PopupControlID="pnlPupupInstituciones"
    BackgroundCssClass="modalBackground"
    DropShadow="true" />


