<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="I_ICodIE.ascx.cs" Inherits="SenainfoSdk.UI.I_ICodIE" %>
<%@ Register Src="C_buscar_proyecto.ascx" TagPrefix="uc1" TagName="C_buscar_proyecto" %>
<div class="input-group" style="width:100%">
    <asp:DropDownList ID="ddl_icodie" runat="server" OnSelectedIndexChanged="ddl_icodie_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <uc1:C_buscar_proyecto runat="server" ID="C_buscar_proyecto" Visible="false" OnProyectoSeleccionado="C_buscar_proyecto_ProyectoSeleccionado" />
</div>