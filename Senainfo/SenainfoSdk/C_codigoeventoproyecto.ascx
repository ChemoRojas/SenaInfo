<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_codigoeventoproyecto.ascx.cs" Inherits="SenainfoSdk.UI.C_codigoeventoproyecto" %>
<%@ Register src="C_buscar_x_institu_proyecto.ascx" tagname="C_buscar_x_institu_proyecto" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>



<uc1:C_buscar_x_institu_proyecto ID="C_buscar_x_institu_proyecto1"  runat="server" OnCodProyectoSeleccionadoCambio="C_buscar_x_institu_proyecto1_CodProyectoSeleccionadoCambio"   />
<% if (this.UsarTabla) { %>
<div class="row">
    <div class="col-md-12">
        <table class="table table-bordered table-condensed">
            <% } %>
            <tr>
                <th class="titulo-tabla col-md-1">Tipo de evento *</th>
                <td class="col-md-4">
                    
                        <asp:DropDownList ID="ddl_tipoevento" runat="server" AutoPostBack="True"  CssClass="form-control input-sm" OnSelectedIndexChanged="ddl_tipoevento_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                     
                </td>

            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">Fecha2</th>
                <td class="col-md-4">
                    <asp:DropDownList ID="ddl_fechaEvento" runat="server" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddl_fechaEvento_SelectedIndexChanged" OnTextChanged="ddl_fechaEvento_TextChanged"></asp:DropDownList>
                &nbsp;</td>
            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">Codigo de evento del proyecto *</th>
                <td class="col-md-4">
                    
                        <asp:DropDownList ID="ddl_codeventproy" runat="server" AutoPostBack="true"  CssClass="form-control input-sm" OnSelectedIndexChanged="ddl_codeventproy_SelectedIndexChanged"></asp:DropDownList>
                        <br />
                </td>
            </tr>
            <tr>
                <th class="titulo-tabla col-md-1">Descripción del evento del proyecto *</th>
                <td class="col-md-4">
                    
                        <asp:Label ID="lbl_tituDescripcion" runat="server"></asp:Label>
                </td>
            </tr>
            <% if (this.UsarTabla) { %>
        </table>
    </div>

</div>
<% } %>
<asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
