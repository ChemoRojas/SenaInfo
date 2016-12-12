<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_codplandiligencia.ascx.cs" Inherits="SenainfoSdk.UI.C_codplandiligencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register src="C_seleccionIcodie.ascx" tagname="C_seleccionIcodie" tagprefix="uc1" %>

<uc1:C_seleccionIcodie ID="C_seleccionIcodie1"  runat="server" OnICODIECambio="C_seleccionIcodie1_ICODIECambio" />
<% if (this.UsarTabla) { %>
<div class="row">
    <div class="col-md-12">
        <table class="table table-bordered table-condensed">
<% } %>
            <tr>
                <th class="titulo-tabla col-md-1">Seleccione IcodDiligencia *</th>
                <td class="col-md-4">
                        <asp:DropDownList ID="ddl_icoddiligencia" runat="server" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddl_icoddiligencia_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">Seleccione Fecha Realizada *</th>
                <td class="col-md-4">
                        <asp:DropDownList ID="ddl_fechasrealizadas" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddl_fechasrealizadas_SelectedIndexChanged" OnTextChanged="ddl_fechasrealizadas_TextChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">Descripción de la Diligencia *</th>
                <td class="col-md-4">
                        <asp:Label ID="lbl_descripcion" runat="server"></asp:Label>
                </td>
            </tr>
         
<% if (this.UsarTabla) { %>
        </table>
    </div>
</div>
<% } %>

