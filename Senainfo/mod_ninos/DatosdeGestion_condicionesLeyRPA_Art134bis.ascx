<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatosdeGestion_condicionesLeyRPA_Art134bis.ascx.cs" Inherits="mod_ninos_DatosdeGestion_condicionesLeyRPA_Art134bis" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <h4 class="titulo-form">Artículo 134-bis</h4>
        <p>&nbsp;</p>

        <div class="row">
            <div class="col-md-12">
                <%-- INICIO: Atículo 134-bis --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Laboral</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="rdb_laboral" runat="server" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio</th>
                        <td>
                            <asp:TextBox ID="calFechaCambio" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3_calFechaCambio" runat="server" ViewStateMode="Enabled" TargetControlID="calFechaCambio" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="calFechaCambio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="calFechaCambio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Capacitación</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="rbl_capacitacion" runat="server" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">&nbsp;</th>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Educación</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="rbl_educacion" runat="server" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Fecha Término</th>
                        <td>
                            <asp:TextBox ID="txt_fechatermino" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechatermino" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_TextBox2"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_fechatermino" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_fechatermino" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cese del Permiso</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddl_cesePermiso" CssClass="form-control input-sm" runat="server">
                              <%--  <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">CONCLUYE PERMISO</asp:ListItem>
                                <asp:ListItem Value="2">REVOCA PERMISO</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cumple Estandar</th>
                        <td class="col-md-4" style="margin-left: 40px">
                            <asp:RadioButton ID="rbl_cumpleestandar" runat="server" />
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:Label ID="Label1" runat="server" Text="Label">Implica la formalización del compromiso del joven y la existencia del acta de análisis de caso relacionado al permiso</asp:Label>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="bt_situacion_migratoria" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-search"></span>&nbsp; Buscar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="btn_update_situacionMigratoria" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="btn_update_situacionMigratoria_Click">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Atículo 134-bis --%>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>