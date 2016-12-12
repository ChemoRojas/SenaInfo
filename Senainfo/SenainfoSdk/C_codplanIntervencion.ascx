<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_codplanIntervencion.ascx.cs" Inherits="SenainfoSdk.UI.C_codplanIntervencion" %>
<%@ Register src="C_seleccionIcodie.ascx" tagname="C_seleccionIcodie" tagprefix="uc1" %>

<uc1:C_seleccionIcodie ID="C_seleccionIcodie1" runat="server" OnICODIECambio="C_seleccionIcodie1_ICODIECambio" />
<% if (this.UsarTabla) { %>
<div class="row">
    <div class="col-md-12">
        <table class="table table-bordered table-condensed">
<% } %>
            <th class="titulo-tabla col-md-1">Código de Plan de Intervención *</th>
            <td class="col-md-4">
                <asp:DropDownList ID="ddl_codplanintervencion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddl_codplanintervencion_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
<% if (this.UsarTabla) { %>
        </table>
    </div>
</div>
<% } %>
