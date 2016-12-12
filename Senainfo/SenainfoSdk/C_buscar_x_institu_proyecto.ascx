<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_buscar_x_institu_proyecto.ascx.cs" Inherits="SenainfoSdk.UI.C_buscar_x_institu_proyecto" %>
<%@ Register Src="I_Institucion.ascx" TagPrefix="uc1" TagName="I_Institucion" %>
<%@ Register Src="I_Proyecto.ascx" TagPrefix="uc1" TagName="I_Proyecto" %>






<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <%--<Triggers>
        <asp:AsyncPostBackTrigger ControlID="C_buscar_proyecto" />
        <asp:AsyncPostBackTrigger ControlID="C_buscar_institucion" />
    </Triggers>--%>
    <ContentTemplate>
        <% if (this.UsarTabla) { %>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-bordered table-condensed">
        <% } %>
                    <tr>
                        <th class="titulo-tabla col-md-1">Institución *</th>
                        <td class="col-md-4">
                            <uc1:I_Institucion runat="server" id="I_Institucion" UsarAllInOne="True" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1">Proyecto *</th>
                        <td class="col-md-4">
                            <uc1:I_Proyecto runat="server" id="I_Proyecto" UsarAllInOne="True" InstitucionControlID="I_Institucion" OnCodProyectoSeleccionadoCambio="I_Proyecto_CodProyectoSeleccionadoCambio" />
                        </td>
                    </tr>
        <% if (this.UsarTabla) { %>
                </table>
            </div>
        </div>
        <% } %>

    </ContentTemplate>
</asp:UpdatePanel>

