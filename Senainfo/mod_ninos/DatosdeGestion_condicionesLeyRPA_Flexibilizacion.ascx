<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatosdeGestion_condicionesLeyRPA_Flexibilizacion.ascx.cs" Inherits="mod_ninos_DatosdeGestion_condicionesLeyRPA_Flexibilizacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <h4 class="titulo-form">Flexibilización</h4>
        <p>&nbsp;</p>
        <div class="row">
            <div class="col-md-12">
                <%-- INICIO: Flexibilización --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Tipo</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddl_tipoParflexibilidad" CssClass="form-control input-sm" runat="server">
                               
                            </asp:DropDownList>
                        </td>
                        <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="txt_fechaInicio" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender4" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaInicio" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_fechaInicio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt_fechaInicio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-1">&nbsp;</td>
                        <td class="col-md-4">&nbsp;</td>
                        <th class="titulo-tabla col-md-1" scope="row">Fecha Termino</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="txt_fechatermino" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender5" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechatermino" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_fechatermino" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt_fechatermino" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="lnk_guardar" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="lnk_guardar_Click" >
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="lnk_limpiar" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Flexibilización --%>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>