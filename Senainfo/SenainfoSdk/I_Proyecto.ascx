<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="I_Proyecto.ascx.cs" Inherits="SenainfoSdk.UI.I_Proyecto" %>
<%@ Register Src="C_buscar_proyecto.ascx" TagPrefix="uc1" TagName="C_buscar_proyecto" %>
<div class="input-group" style="width:100%">
    <asp:DropDownList ID="ddl_proyecto" runat="server" AutoPostBack="True"  CssClass="form-control input-sm" OnSelectedIndexChanged="ddl_proyecto_SelectedIndexChanged">
    </asp:DropDownList>
    <uc1:C_buscar_proyecto runat="server" ID="C_buscar_proyecto" OnProyectoSeleccionado="C_buscar_proyecto_ProyectoSeleccionado" />
</div>