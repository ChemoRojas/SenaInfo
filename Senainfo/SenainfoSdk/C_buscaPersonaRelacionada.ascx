  <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_buscaPersonaRelacionada.ascx.cs" Inherits="SenainfoSdk.UI.C_buscaPersonaRelacionada" %>
<%@ Register Src="C_seleccionIcodie.ascx" TagPrefix="uc1" TagName="C_seleccionIcodie" %>

<uc1:C_seleccionIcodie runat="server" ID="C_seleccionIcodie" OnICODIECambio="C_seleccionIcodie_ICODIECambio" />
<% if (this.UsarTabla) { %>
<div class="row">

    <div class="col-md-12">
        <table class="table table-bordered table-condensed">
            <% } %>
            <th class="titulo-tabla col-md-1">Persona Relacionada *</th>
            <td class="col-md-4">
                <div class="input-group">
                    <asp:Label ID="lbl_persona_relacionada" runat="server"> </asp:Label>
                </div>
            </td>
            <% if (this.UsarTabla) { %>
        </table>
    </div>  
</div>
<% } %>