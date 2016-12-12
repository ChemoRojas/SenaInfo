<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatosdeGestion_condicionesLeyRPA_DerivacionPRE.ascx.cs" Inherits="mod_ninos_DatosdeGestion_condicionesLeyRPA_DerivacionPRE" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <h4 class="titulo-form">Derivación PRE</h4>
        <p>&nbsp;</p>
        <div class="row">
            <div class="col-md-12">
                <%-- INICIO: Derivación PRE --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Región</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList4" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">I</asp:ListItem>
                                <asp:ListItem Value="2">II</asp:ListItem>
                                <asp:ListItem Value="3">...</asp:ListItem>
                                <asp:ListItem Value="5">XV</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Institución</th>
                        <td class="col-md-4">
                            <div class="input-group">
                                <asp:DropDownList ID="DropDownList5" CssClass="form-control input-sm" runat="server">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="6050">SERVICIO NACIONAL DE MENORES .I.</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="input-group-addon btn btn-info btn-sm" CausesValidation="False">
                                    <span class="glyphicon glyphicon-question-sign"></span>
                                </asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Proyecto</th>
                        <td class="col-md-4">
                            <div class="input-group">
                                <asp:DropDownList ID="DropDownList6" CssClass="form-control input-sm" runat="server">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="1">(1131210) CRC - CENTRO CERRADO METROPOLITANO NORTE</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="input-group-addon btn btn-info btn-sm" CausesValidation="False">
                                    <span class="glyphicon glyphicon-question-sign"></span>
                                </asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Fecha Derivación</th>
                        <td>
                            <asp:TextBox ID="TextBox9" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender6" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox9" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox9" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="TextBox9" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Fecha Ingreso</th>
                        <td>
                            <asp:TextBox ID="TextBox10" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender7" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox10" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox10" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="TextBox10" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Técnico</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList7" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">Juan Perez</asp:ListItem>
                                <asp:ListItem Value="2">Luis Perez</asp:ListItem>
                                <asp:ListItem Value="3">Danilo Perez</asp:ListItem>
                                <asp:ListItem Value="5">Rodrigo Perez</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="LinkButton3" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="LinkButton4" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Derivación PRE --%>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>