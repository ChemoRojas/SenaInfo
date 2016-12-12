<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="I_Institucion.ascx.cs" Inherits="SenainfoSdk.UI.I_Institucion" %>
<%@ Register Src="C_buscar_institucion.ascx" TagPrefix="uc1" TagName="C_buscar_institucion" %>
<div class="input-group" style="width:100%">
    <asp:DropDownList ID="ddl_institucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddl_institucion_SelectedIndexChanged">
    </asp:DropDownList>
    <uc1:C_buscar_institucion runat="server" ID="C_buscar_institucion" OnInstitucionSeleccionado="C_buscar_institucion_InstitucionSeleccionado" />
</div>