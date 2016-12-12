<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatosdeGestion_condicionesLeyRPA_PlanMotivacional.ascx.cs" Inherits="mod_ninos_DatosdeGestion_condicionesLeyRPA_PlanMotivacional" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <h4 class="titulo-form">Plan Motivacional</h4>
        <p>&nbsp;</p>
        <div class="row">
            <div class="col-md-12">
                <%-- INICIO: Plan Motivacional --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Categoría</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddl_categoria" CssClass="form-control input-sm" runat="server">
                            </asp:DropDownList>
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Fecha Incio</th>
                        <td>
                            <asp:TextBox ID="txt_fechaInicio" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaInicio" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fechaInicio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_fechaInicio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 1</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddl_condicion1" CssClass="form-control input-sm" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Compromiso de Cumplimiento</th>
                        <td>
                            <asp:CheckBox ID="chk_comproDeCumplimiento" runat="server" /></td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Pernocta</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="rbt_pernotaSiempre" runat="server" Text="Siempre" GroupName="pernocta" />
                            <asp:RadioButton ID="rbt_pernoctaAveces" runat="server" Text="Aveces" GroupName="pernocta" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Fecha Termino</th>
                        <td>
                            <asp:TextBox ID="txt_fechaTermino" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fechaTermino" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_TextBox2"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_fechaTermino" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_fechaTermino" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cantidad Días</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="txt_cantidadDiasPernocta" runat="server" CssClass="form-control form-control-fecha-large input-sm" TextMode="Number"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="Se entendera que la cantidad de días esta alrededor de la cifra indicada"></asp:Label>
                        </td>
                        <th class="titulo-tabla col-md-1" scope="row">Certificado de Constancia No Continuidad</th>
                        <td class="col-md-4">
                            <asp:CheckBox ID="chk_certificadoConstanciaContinuidad" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 3</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddl_condicion3" CssClass="form-control input-sm" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <th class="titulo-tabla col-md-1" scope="row">Resultado</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="rdb_positivo" runat="server" Text="Positivo" GroupName="resultado" />
                            <asp:RadioButton ID="rdb_negativo" runat="server" Text="Negativo" GroupName="resultado" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 4</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="rdb_continuo" runat="server" Text="Continuo" GroupName="condicion_4" />
                            <asp:RadioButton ID="rdb_discontinuo" runat="server" Text="Discontinuo" GroupName="condicion_4" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cantidad de Dias</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="txt_cantidaddeDias" runat="server" CssClass="form-control form-control-fecha-large input-sm" TextMode="Number"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="Si es continuo seran considerados dias seguidos. Si es discontinuo deran oportunidades en el periodo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Descripción</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="txt_descripcion" runat="server" CssClass="form-control form-control-fecha-large input-sm" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="link_buttonGuardar" runat="server" AutoPostback="true" CausesValidation="false" Visible="true" OnClick="link_buttonGuardar_Click">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="LinkButton1" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Plan Motivacional --%>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>