<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_buscar_proyecto.ascx.cs" Inherits="SenainfoSdk.UI.C_buscar_proyecto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>



<asp:LinkButton ID="Lnk_ProyectoBuscar" runat="server"
    CssClass="input-group-addon btn btn-info btn-sm" CausesValidation="False">
    <span class="glyphicon glyphicon-question-sign"></span>
</asp:LinkButton>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlPopupProyectos" runat="server" Style="Display: none">
            <div class="popupConfirmation" id="modal_bsc_proyecto">
                <div class="modal-header header-modal">
                    <asp:LinkButton ID="btnCerrarModal1" runat="server" CssClass="close" aria-label="Close" OnClick="btnCancelar_Click" Text="Cerrar" CausesValidation="false">
                        <span aria-hidden="true">&times;</span>
                    </asp:LinkButton>
                    <h4 class="modal-title">PROYECTO</h4>
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
                                                                        <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                                        <asp:LinkButton ID="btnBuscarInstitucion" CssClass="input-group-addon btn btn-info btn-sm" runat="server" CausesValidation="False" OnClick="btnBuscarInstitucion_Click" AutoPostback="true">
                                                                            <span class="glyphicon glyphicon-search"></span>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" Visible="true" Enabled="false">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tr_nombre_proyecto" runat="server">
                                                    <th class="titulo-tabla" scope="row">
                                                        <asp:Label ID="lbl0016" runat="server" Text="Nombre del Proyecto"></asp:Label></th>
                                                    <td>
                                                        <asp:TextBox ID="txt0011" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="tr_codigo_proyecto" runat="server">
                                                    <th class="titulo-tabla" scope="row">
                                                        <asp:Label ID="lbl0017" runat="server" Text="Código del Proyecto"></asp:Label></th>
                                                    <td>
                                                        <asp:TextBox ID="txt0012" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt0012" ValidChars="0123456789" />
                                                    </td>
                                                </tr>
                                                <tr id="tr_tipo_proyecto" runat="server">
                                                    <th class="titulo-tabla" scope="row">
                                                        <asp:Label ID="lbl0018" runat="server" Text="Tipo de Proyecto"></asp:Label></th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr_tipo_evento" runat="server" style="display: none">
                                                    <th class="titulo-tabla" scope="row">
                                                        <asp:Label ID="lbl0019" runat="server" Text="Tipo de Evento"></asp:Label></th>
                                                    <td>
                                                        <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm" Visible="False">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="tr_vigencia" runat="server" visible="false">
                                                    <th class="titulo-tabla" scope="row">
                                                        <asp:Label ID="lbl020" runat="server" Text="Vigencia"></asp:Label></th>
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
                                            CssClass="table table-bordered table-hover" Width="100%"
                                            AutoGenerateColumns="False" AllowPaging="True"
                                            OnRowCommand="grd001_rowcommand"
                                            OnPageIndexChanging="grd001_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="CodInstitucion" HeaderText="C&#243;digo Instituci&#243;n" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto" />
                                                <asp:BoundField DataField="TipoProyecto" HeaderText="Tipo Proyecto" />
                                                <asp:BoundField DataField="CodSistemaAsistencial" HeaderText="Sistema Asistencial" />
                                                <asp:BoundField DataField="NombreInstitucion" HeaderText="Nombre Instituci&#243;n" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
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
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click">
                                                <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnLimpiar" runat="server" AutoPostback="true" OnClick="btnLimpiaBusqueda_Click">
                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CausesValidation="False">
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

<ajax:ModalPopupExtender ID="MPE" runat="server"
    TargetControlID="Lnk_ProyectoBuscar"
    PopupControlID="pnlPopupProyectos"
    BackgroundCssClass="modalBackground"
    DropShadow="true" />
