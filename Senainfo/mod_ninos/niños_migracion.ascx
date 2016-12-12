<%@ Control Language="C#" AutoEventWireup="true" CodeFile="niños_migracion.ascx.cs" Inherits="mod_ninos_niños_migracion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<style type="text/css">
    .auto-style2 {
        width: 132px;
    }
</style>
<%--<script src="../js/jquery-2.1.4.js"></script>
<script src="../js/jquery-2.1.4.min.js"></script>
<script src="../js/jquery-ui.js"></script>
<link href="../css/bootstrap.min.css" rel="stylesheet" />
<link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
<link href="../css/theme.css" rel="stylesheet" />--%>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
                <asp:HiddenField ID="icod_situacion_migratoria" runat="server" Value="0" />
                <table class="table table-bordered  table-condensed text-center">
                    <%-- <tbody>--%>
                    <tr>
                        <th class="titulo-tabla col-md-3" scope="row">Situación Migratoria</th>
                        <td>
                            <div class="col-md-3 col-md-offset-2 text-center">
                                <asp:RadioButtonList ID="rbl_situacionMigratoria" CssClass="text-center" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">SI</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RadioButton ID="rb_situacion_si" runat="server" GroupName="sm" Text="Si" Visible="False" OnCheckedChanged="control_controles" AutoPostBack="true" />
                                <asp:RadioButton ID="rb_situacion_no" runat="server" GroupName="sm" Text="No" Visible="False" Checked="true" OnCheckedChanged="control_controles" AutoPostBack="true" />
                            </div>
                            <div class="col-md-6 pull-right">
                                <asp:DropDownList ID="dd_situacion_migratoria" CssClass="form-control input-sm" runat="server" Enabled="False">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="1">Con regularización migratoria</asp:ListItem>
                                    <asp:ListItem Value="2">Refugiado</asp:ListItem>
                                    <asp:ListItem Value="3">Solicitante de refugio</asp:ListItem>
                                    <asp:ListItem Value="4">En proceso de retorno protegido</asp:ListItem>
                                    <asp:ListItem Value="5">Desplazado (conflicto bélico/económico)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <asp:Panel ID="pnl_victima" runat="server" Visible="true">
                        <tr>
                            <th class="titulo-tabla" scope="row">Víctima Tráfico de Personas</th>
                            <td>
                                <div class="text-center col-md-6">
                                    <asp:RadioButton ID="rb_victima_trafico_si" runat="server" GroupName="vtp" Text="Si" Visible="True" Enabled="true" />
                                    <asp:RadioButton ID="rb_victima_trafico_no" runat="server" GroupName="vtp" Text="No" Visible="True" Enabled="true" Checked="true" />
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
                <asp:Panel runat="server" ID="panel_migra" Visible="true">
                    <h4 class="subtitulo-form col-md-3">Documentación Migratoria</h4>
                    <asp:ListView ID="ListView2" runat="server" DataKeyNames="Descripcion" DataSourceID="SqlDataSource2">
                        <LayoutTemplate>
                            <table class="table table-bordered  table-condensed" id="documentacion">
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <th class="titulo-tabla col-md-3"><%# Eval("Descripcion") %></th>
                                <input type="hidden" name="Documen_<%# Eval("CodDocumentacionMigratoria") %>" value="<%# Eval("Descripcion") %>" />
                                <td>
                                    <div class="col-md-6 text-center">
                                        <label>

                                            <input class="label-radiobutton" name='RadioDoc_<%# Eval("CodDocumentacionMigratoria") %>_<%# Eval("ICodDocumentacionMigratoria") %>' type="radio" value="1" <%# PoseeDatosMigracion(Eval("DocumentacionMigratoria_SI_NO"),1) %> />Si</input>
                                    <input class="label-radiobutton" name='RadioDoc_<%# Eval("CodDocumentacionMigratoria") %>_<%# Eval("ICodDocumentacionMigratoria") %>' type="radio" value="0" <%# PoseeDatosMigracion(Eval("DocumentacionMigratoria_SI_NO"),0) %> />No</input></label>
                                    </div>
                                    <div class="col-md-6">
                                        <input class='form-control input-sm' maxlength="50" name='Doc_datos_<%# Eval("CodDocumentacionMigratoria") %>' type="<%# PoseDocumento(Eval("RequiereDetalle")) %>" value="<%#Eval("NroDocumento_NivelEscolaridad") %>">

                                    </div>
                                </td>

                            </tr>
                        </ItemTemplate>
                    </asp:ListView>

                    <h4 class="subtitulo-form col-md-3">Proceso de Migración</h4>
                    <table class="table table-bordered  table-condensed">

                        <tr>
                            <th class="titulo-tabla col-md-3">Fecha ingreso actual a Chile</th>
                            <td>
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Mes" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_mes" runat="server" CssClass="form-control input-sm" Visible="false">
                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <%--<asp:TextBox ID="cal_ingreso_chile" runat="server" VALUE="" class="form-control form-control-40 input-sm" />
                                                                                    <ajax:CalendarExtender ID="CalendarExtende1041" runat="server" Enabled="true" Format="MM-yyyy" TargetControlID="cal_ingreso_chile" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                                                    <asp:RangeValidator ID="RangeValidator1041" runat="server" Text="Fecha Invalida" ControlToValidate="cal_ingreso_chile" Type="Date" MaximumValue="2010-01-01" MinimumValue="1900-01-01" />--%>
                                <div class="col-md-6">
                                    <asp:Label ID="Label2" runat="server" Text="Año" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_ano" runat="server" CssClass="form-control input-sm" Visible="false">
                                    </asp:DropDownList>
                                </div>

                                <asp:TextBox runat="server" ID="txt_fechaIngresoChile" CssClass="form-control input-sm text-center" placeholder="Fecha Ingreso a Chile"></asp:TextBox>
                                <ajax:CalendarExtender runat="server" ID="ceFechaIngresoChile" Format="yyyy-MM" ClientIDMode="Static"
                                     TargetControlID="txt_fechaIngresoChile" DefaultView="Months" OnClientShown="onCalendarShown" OnClientHidden="onCalendarHidden" />

                                <script type="text/javascript">
                                    function onCalendarHidden() {
                                        var cal = $find("ceFechaIngresoChile");

                                        if (cal._monthsBody) {
                                            for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                                                var row = cal._monthsBody.rows[i];
                                                for (var j = 0; j < row.cells.length; j++) {
                                                    Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                                                }
                                            }
                                        }
                                    }

                                    function onCalendarShown() {

                                        var cal = $find("ceFechaIngresoChile");

                                        cal._switchMode("months", true);

                                        if (cal._monthsBody) {
                                            for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                                                var row = cal._monthsBody.rows[i];
                                                for (var j = 0; j < row.cells.length; j++) {
                                                    Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                                                }
                                            }
                                        }
                                    }

                                    function call(eventElement) {
                                        var target = eventElement.target;
                                        switch (target.mode) {
                                            case "month":
                                                var cal = $find("ceFechaIngresoChile");
                                                cal._visibleDate = target.date;
                                                cal.set_selectedDate(target.date);
                                                //cal._switchMonth(target.date);
                                                cal._blur.post(true);
                                                cal.raiseDateSelectionChanged();
                                                break;
                                        }
                                    }
                                </script>

                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">Paso fronterizo por el cual ingresa a chile</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton ID="rb_paso_fronterizo_si" runat="server" Enabled="true" GroupName="paso_fronterizo" Text="Habilitado" Visible="True" />
                                    <asp:RadioButton ID="rb_paso_fronterizo_no" runat="server" Checked="true" Enabled="true" GroupName="paso_fronterizo" Text="No Habilitado" Visible="True" />
                                </div>
                                <div class="col-md-6">

                                    <asp:TextBox CssClass="form-control input-sm" ID="txt_paso_fronterizo" runat="server" Enabled="true" placeholder="Ingrese paso fronterizo" TabIndex="100" Visible="false" />
                                    <asp:DropDownList CssClass="form-control input-sm" ID="ddlPasoFronterizo" runat="server" Enabled="true">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">NNA ¿Ha tenido ingresos anteriores a Chile?</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton ID="rb_ingresos_chile_si" runat="server" Enabled="true" GroupName="ingresos_chile" Text="Si" Visible="True" />
                                    <asp:RadioButton ID="rb_ingresos_chile_no" runat="server" Checked="true" Enabled="true" GroupName="ingresos_chile" Text="No" Visible="True" />
                                </div>
                                <div class="col-md-6">

                                    <asp:TextBox CssClass="form-control input-sm" ID="txt_ingreso_chile" runat="server" Enabled="true" placeholder="Ingrese número de ingresos" MaxLength="3" />
                                    <ajax:FilteredTextBoxExtender ID="fteTxtIngresoChile" runat="server" TargetControlID="txt_ingreso_chile" ValidChars="123456789" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">NNA ¿Ha transitado con anterioridad en otros países?</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton ID="rb_otros_paises_si" runat="server" Enabled="true" GroupName="otros_paises" Text="Si" Visible="True" />
                                    <asp:RadioButton ID="rb_otros_paises_no" runat="server" Checked="true" Enabled="true" GroupName="otros_paises" Text="No" Visible="True" />
                                </div>
                                <div class="col-md-6">

                                    <asp:TextBox CssClass="form-control input-sm" ID="txt_otros_paises" runat="server" Enabled="true" placeholder="Ingrese número de países" MaxLength="3" />
                                    <ajax:FilteredTextBoxExtender runat="server" ID="fte_txt_otros_paises" TargetControlID="txt_otros_paises" ValidChars="123456789" />
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <th class="titulo-tabla">Ciudad de origen o residencia</th>
                            <td>
                                <asp:TextBox ID="txt_ciudad_origen" CssClass="form-control input-sm" runat="server" Enabled="true" placeholder="Ingrese ciudad" MaxLength="50" />
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">Motivo de ingreso a Chile del NNA</th>

                            <th>
                                <asp:DropDownList ID="dd_motivo_ingreso" runat="server" CssClass="form-control input-sm" Enabled="true">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="1">Reunificación familiar</asp:ListItem>
                                    <asp:ListItem Value="2">Búsqueda de trabajo</asp:ListItem>
                                    <asp:ListItem Value="3">Estudios</asp:ListItem>
                                    <asp:ListItem Value="4">Turismo</asp:ListItem>
                                    <asp:ListItem Value="5">Traslado familiar (familia inmigrante)</asp:ListItem>
                                    <asp:ListItem Value="6">Comercio (familia comerciante)</asp:ListItem>
                                    <asp:ListItem Value="7">Bienestar familiar</asp:ListItem>
                                </asp:DropDownList>
                            </th>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">Aviso a RRII de ingreso de NNA Migrante</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton runat="server" ID="avisorrii_si" Text="Si" AutoPostBack="true" GroupName="AvisoRRII" OnCheckedChanged="avisorrii_si_CheckedChanged" />
                                    <asp:RadioButton runat="server" ID="avisorrii_no" Text="N   o" AutoPostBack="true" Checked="true" GroupName="AvisoRRII" OnCheckedChanged="avisorrii_no_CheckedChanged" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control input-sm text-center"  ID="txtFechaAvisoRRII" runat="server" Enabled="false" MaxLength="10" onkeypress="return false;" />
                                    <ajax:CalendarExtender runat="server" ID="calw" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaAvisoRRII" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">Gestión de Regulación Migratoria</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton runat="server" ID="GestionRegulacionMigratoria_si" AutoPostBack="true" Text="Si" GroupName="GestionRegulacion" OnCheckedChanged="GestionRegulacionMigratoria_si_CheckedChanged" />
                                    <asp:RadioButton runat="server" ID="GestionRegulacionMigratoria_no" AutoPostBack="true" Text="No" GroupName="GestionRegulacion" Checked="true" OnCheckedChanged="GestionRegulacionMigratoria_no_CheckedChanged"   />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control input-sm text-center" ID="txtFechaGestionRegulacionMigratoria" runat="server" Enabled="false" MaxLength="10" onkeypress="return false;" />
                                    <ajax:CalendarExtender runat="server" ID="calx" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaGestionRegulacionMigratoria" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">Remite Antecedentes del Caso/Informe Pericial y Diagnóstico a RRII</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton runat="server" ID="RemiteAntecedentesCasoInformePericialDiagnostico_si" AutoPostBack="true" GroupName="RemiteAntecedentes" Text="Si" OnCheckedChanged="RemiteAntecedentesCasoInformePericialDiagnostico_si_CheckedChanged" />
                                    <asp:RadioButton runat="server" ID="RemiteAntecedentesCasoInformePericialDiagnostico_no" AutoPostBack="true" GroupName="RemiteAntecedentes" Text="No" Checked="true" OnCheckedChanged="RemiteAntecedentesCasoInformePericialDiagnostico_no_CheckedChanged" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control input-sm text-center" ID="txtFechaRemiteAntecedentes" runat="server" Enabled="false" MaxLength="10" onkeypress="return false;" />
                                    <ajax:CalendarExtender runat="server" ID="caly" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaRemiteAntecedentes" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th class="titulo-tabla">Retorno del NNA al Pais de Origen</th>
                            <td>
                                <div class="col-md-6 text-center">
                                    <asp:RadioButton runat="server" ID="RetornoNNAaPaisOrigen_si" Text="Si" GroupName="RetornoNNAPaisOrigen" AutoPostBack="true" OnCheckedChanged="RetornoNNAaPaisOrigen_si_CheckedChanged" />
                                    <asp:RadioButton runat="server" ID="RetornoNNAaPaisOrigen_no" Text="No" GroupName="RetornoNNAPaisOrigen" AutoPostBack="true" Checked="true" OnCheckedChanged="RetornoNNAaPaisOrigen_no_CheckedChanged" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control input-sm text-center" ID="txtFechaRetornoPaisOrigen" runat="server" Enabled="false" MaxLength="10" onkeypress="return false;" />
                                    <ajax:CalendarExtender runat="server" ID="calz" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaRetornoPaisOrigen" />
                                </div>
                            </td>
                        </tr>
                    </table>

                    <h4 class="subtitulo-form col-md-3">Dominio de Idiomas</h4>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>"
                        SelectCommand="Get_NivelIdiomaMigratorio" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter Name="ICodIE" SessionField="SS_ICodIE" DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>"
                        SelectCommand="Get_infoMigracion" SelectCommandType="StoredProcedure" ProviderName="<%$ ConnectionStrings:Conexiones.ProviderName %>">
                        <SelectParameters>
                            <asp:SessionParameter Name="ICodIE" SessionField="SS_ICodIE" DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <div class="SIM"></div>
                    <asp:ListView ID="regionesList" runat="server" DataKeyNames="Descripcion" DataSourceID="SqlDataSource1">
                        <LayoutTemplate>
                            <table class="table table-bordered  table-condensed" id="idiomas">
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <th class="titulo-tabla col-md-3"><%# Eval("Descripcion") %></th>
                                <input type="hidden" name="idioma_<%# Eval("CodIdiomas") %>" value="<%# Eval("Descripcion") %>" />

                                <%--<td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="0" <%#  (int)Eval("NivelIdioma") == 0 ? "checked": "" %> >Bajo</td>--%>
                                <td>
                                    <div class="text-center">
                                        <label>

                                            <input type="radio" name='Radio_<%# Eval("CodIdiomas") %>_<%# Eval("ICodDominioIdiomas") %>' value="0" <%# PoseNivelIdioma(Eval("NivelIdioma"),0) %>>Bajo
                            
                                <input type="radio" name='Radio_<%# Eval("CodIdiomas") %>_<%# Eval("ICodDominioIdiomas") %>' value="1" <%# PoseNivelIdioma(Eval("NivelIdioma"),1) %>>Medio
                            
                                <input type="radio" name='Radio_<%# Eval("CodIdiomas") %>_<%# Eval("ICodDominioIdiomas") %>' value="2" <%# PoseNivelIdioma(Eval("NivelIdioma"),2) %>>Alto
                            
                                <input type="radio" name='Radio_<%# Eval("CodIdiomas") %>_<%# Eval("ICodDominioIdiomas") %>' value="3" <%# PoseNivelIdioma(Eval("NivelIdioma"),3) %>>Nativo
                                    </div>
                                    </label></td>


                                <%--                                <td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="1" <%#(int)Eval("NivelIdioma") == 1 ? "checked": "" %> >Medio</td>
                                <td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="2" <%#(int)Eval("NivelIdioma") == 2 ? "checked": "" %> >Alto</td>
                                <td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="3" <%#(int)Eval("NivelIdioma") == 3 ? "checked": "" %> >Nativo</td>--%>
                                <%--<td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="0" <%  int.TryParse(Eval("NivelIdioma").ToString(), out nivel); if (nivel == 1) { Response.Write("checked"); }%> >Medio</td>
                                <td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="0" <%  int.TryParse(Eval("NivelIdioma").ToString(), out nivel); if (nivel == 2) { Response.Write("checked"); }%> >Alto</td>
                                <td><input type="radio" name='Radio_<%# Eval("CodIdiomas") %>' value="0" <%  int.TryParse(Eval("NivelIdioma").ToString(), out nivel); if (nivel == 3) { Response.Write("checked"); }%> >Nativo</td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>

                </asp:Panel>

                <%--  <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="idioma" DataValueField="descripcion">
                            </asp:RadioButtonList>--%>


                <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                    <span class="glyphicon glyphicon-alert" aria-hidden="true"></span>&nbsp;
                                                                        <asp:Label ID="lb_situacion_migratoria" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lb_documentacion_migratoria" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lb_proceso_migracion" runat="server" Visible="false"></asp:Label>
                    <%--<asp:Label ID="lb_dominio_idiomas" runat="server" Visible="false"></asp:Label>--%>
                </div>
                <div class="botonera pull-right">
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="bt_situacion_migratoria" runat="server" OnClick="bt_situacion_migratoria_Click" AutoPostback="true" CausesValidation="false" Visible="False">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                    </asp:LinkButton>
                    <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="btn_update_situacionMigratoria" runat="server" AutoPostback="true" CausesValidation="false" OnClick="btn_update_situacionMigratoria_Click" Visible="False">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Modificar
                    </asp:LinkButton>
                </div>
            </div>

        </div>

    </ContentTemplate>
</asp:UpdatePanel>
