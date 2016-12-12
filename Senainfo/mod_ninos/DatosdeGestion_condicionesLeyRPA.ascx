<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatosdeGestion_condicionesLeyRPA.ascx.cs" Inherits="mod_ninos_DatosdeGestion_condicionesLeyRPA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

        <div class="row">
            <div class="col-md-12">

                <%-- INICIO: Atículo 134-bis --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">LABORAL</th>
                        <td class="col-md-4">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">FECHA INICIO</th>
                        <td>
                            <asp:TextBox ID="calFechaCambio" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3_calFechaCambio" runat="server" ViewStateMode="Enabled" TargetControlID="calFechaCambio" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="calFechaCambio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="calFechaCambio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">CAPACITACIÓN</th>
                        <td class="col-md-4">
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">&nbsp;</th>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">EDUCACIÓN</th>
                        <td class="col-md-4">
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">FECHA TERMINO</th>
                        <td>
                            <asp:TextBox ID="TextBox2" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox2" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_TextBox2"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="TextBox2" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cese del Permiso</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddd_test1" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">CONCLUYE PERMISO</asp:ListItem>
                                <asp:ListItem Value="2">REVOCA PERMISO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cumple Estandar</th>
                        <td class="col-md-4">
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:Label ID="Label1" runat="server" Text="Label">Implica la formalización del compromiso del joven y la existencia del acta de análisis de caso relacionado al permiso</asp:Label>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="bt_situacion_migratoria" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-search"></span>&nbsp; Buscar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="btn_update_situacionMigratoria" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Atículo 134-bis --%>

                <%-- INICIO: Plan Motivacional --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Categoría</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList2" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">INTERRUPCION</asp:ListItem>
                                <asp:ListItem Value="2">DESERCION</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Fecha Incio</th>
                        <td>
                            <asp:TextBox ID="TextBox1" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox1" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="TextBox1" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 1</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList3" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">LLega tarde sin aviso (despúes de las 23:30 horas)</asp:ListItem>
                                <asp:ListItem Value="2">LLega con droga o alcohol</asp:ListItem>
                                <asp:ListItem Value="3">Presenta faltas graves art 108</asp:ListItem>
                                <asp:ListItem Value="4">Presenta faltas mnos graves art 109</asp:ListItem>
                                <asp:ListItem Value="5">Presenta faltas leves art 110</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Compromiso de Cumplimiento</th>
                        <td>
                            <asp:CheckBox ID="CheckBox5" runat="server" /></td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Pernocta</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Siempre" GroupName="pernocta" />
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Aveces" GroupName="pernocta" />
                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Fecha Termino</th>
                        <td>
                            <asp:TextBox ID="TextBox3" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox3" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_TextBox2"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="TextBox3" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Cantidad Días</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="Se entendera que la cantidad de días esta alrededor de la cifra indicada"></asp:Label>
                        </td>
                        <th class="titulo-tabla col-md-1" scope="row">Certificado de Constancia No Continuidad</th>
                        <td class="col-md-4">
                            <asp:CheckBox ID="CheckBox8" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 3</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">ddd</asp:ListItem>
                                <asp:ListItem Value="2">fff</asp:ListItem>
                                <asp:ListItem Value="3">hhhh</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <th class="titulo-tabla col-md-1" scope="row">Resultado</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="RadioButton3" runat="server" Text="Positivo" GroupName="resultado" />
                            <asp:RadioButton ID="RadioButton4" runat="server" Text="Negativo" GroupName="resultado" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 4</th>
                        <td class="col-md-4">
                            <asp:RadioButton ID="RadioButton7" runat="server" Text="Continuo" GroupName="condicion_4" />
                            <asp:RadioButton ID="RadioButton8" runat="server" Text="Discontinuo" GroupName="condicion_4" />
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Condición 4</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="Si es continuo seran considerados dias seguidos. Si es discontinuo deran oportunidades en el periodo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Descripción</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control form-control-fecha-large input-sm" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="LinkButton2" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="LinkButton1" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Plan Motivacional --%>

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

                <%-- INICIO: Flexibilización --%>
                <table class="table table-bordered tabla-tabs table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Tipo</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="DropDownList8" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">Hospitalización</asp:ListItem>
                                <asp:ListItem Value="2">Estudios Jornada Completa</asp:ListItem>
                                <asp:ListItem Value="3">Laboral Jornada Completa</asp:ListItem>
                                <asp:ListItem Value="4">Estadía otra región por trabajo</asp:ListItem>
                                <asp:ListItem Value="5">Estadía otra región por tratamiento</asp:ListItem>
                                <asp:ListItem Value="6">Por vacaciones delegado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="TextBox7" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender4" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox7" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox7" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="TextBox7" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-1">&nbsp;</td>
                        <td class="col-md-4">&nbsp;</td>
                        <th class="titulo-tabla col-md-1" scope="row">Fecha Termino</th>
                        <td class="col-md-4">
                            <asp:TextBox ID="TextBox8" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender5" runat="server" ViewStateMode="Enabled" TargetControlID="TextBox8" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" BehaviorID="_content_CalendarExtender3_calFechaCambio"></ajax:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox8" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="TextBox8" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>
                        </td>
                    </tr>
                </table>

                <div class="botonera pull-right">
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="LinkButton7" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="LinkButton8" runat="server" AutoPostback="true" CausesValidation="false" Visible="true">
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                    </asp:LinkButton>
                </div>
                <%-- FIN: Flexibilización --%>
            </div>
        </div>



    </ContentTemplate>
</asp:UpdatePanel>