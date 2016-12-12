<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ninos_MedidaOSancion.ascx.cs" Inherits="mod_ninos_ninos_MedidaOSancion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<script>

     
</script>

    <h4 class="titulo-form">Datos sobre la Medida o la Sanción </h4>
    <p>&nbsp;</p>
    <asp:Label ID="lblbmsg" CssClass="subtitulo-form" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="lbl_aviso2LRPA" runat="server" CssClass="help-block" Visible="False" Width="100%"></asp:Label>

    <asp:Label ID="lbl_aviso_graba" runat="server" CssClass="help-block" Visible="False" Width="100%"></asp:Label>

    <asp:GridView ID="grdseleccionLRPA" runat="server" AutoGenerateColumns="False" OnRowCommand="grdseleccionLRPA_RowCommand" Width="100%" CssClass="table table table-bordered table-hover caja-tabla">
        <Columns>
            <asp:BoundField DataField="CodMedidaSancion" HeaderText="C&#243;digo"></asp:BoundField>
            <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio"></asp:BoundField>
            <asp:BoundField DataField="CodRegion" HeaderText="Regi&#243;n"></asp:BoundField>
            <asp:BoundField DataField="Tribunal" HeaderText="Tribunal"></asp:BoundField>
            <asp:BoundField DataField="TerminoSancion" HeaderText="Término"></asp:BoundField>
            <asp:BoundField DataField="FechaTerminoSansion" HeaderText="Fecha T&#233;rmino"></asp:BoundField>
            <asp:BoundField DataField="ICodTribunalIngreso" HeaderText="Código Tribunal"></asp:BoundField>
            <asp:ButtonField CommandName="ver" Text="Modificar" HeaderText="Seleccionar"></asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="titulo-tabla table-borderless" />
        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
        <RowStyle CssClass="caja-tabla table-bordered" />
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
    <div class="pull-right">
        <asp:LinkButton CssClass="btn btn-info btn-sm" ID="BtnAgregar" runat="server" Text="" CausesValidation="false" OnClientClick="MuestraTab();return true;" OnClick="LinkButton1_Click" Visible="True">
        <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Medida o Sanción
        </asp:LinkButton>
    </div>
    <p>&nbsp;</p>
    <asp:Panel ID="pnldatos" runat="server" Visible="false">
        <table class="table table-bordered tabla-tabs table-condensed">
            <tr>
                <th class="titulo-tabla col-md-1" scope="row">
                    <asp:Label ID="lbl_otm" runat="server" Text="Orden de Tribunal *"></asp:Label></th>
                <td>
                    <asp:DropDownList ID="ddl_OrdenDeTribunal_MedidaSancion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" Width="100%">
                    </asp:DropDownList></td>
            </tr>
        </table>


        <h4 class="subtitulo-form">
            <label>MCA, CIP Indicar tiempo investigación, PSA Indicar duracíón medida, PLA, PLE, CRC, CSC, SBC Indicar duración sanción. </label>
        </h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table table-bordered tabla-tabs table-condensed">

                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Inicio Sanción *</th>
                        <td class="col-md-3">

                            <%--<asp:TextBox ID="txt_FechaInicioSancionLRPA" CssClass="form-control form-control-fecha input-sm" runat="server" ONVALUECHANGED="ddown001LRPA_ValueChanged" />--%>
                            <asp:TextBox ID="txt_FechaInicioSancionLRPA" CssClass="form-control form-control-fecha-large input-sm" runat="server" AutoPostBack="true" placeholder="dd-mm-aaaa" MaxLength="10" OnTextChanged="txt_FechaInicioSancionLRPA_TextChanged" />
                            <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt_FechaInicioSancionLRPA" ValidChars="0123456789-/" />
                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende930" runat="server" Format="dd-MM-yyyy" TargetControlID="txt_FechaInicioSancionLRPA" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende930" />
                            <asp:RangeValidator ID="RangeValidator930" runat="server" ErrorMessage="Fecha Invalida" Display="Dynamic" CssClass="help-block" ControlToValidate="txt_FechaInicioSancionLRPA" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" /><asp:Label ID="lblfechaini1LRPA" runat="server"></asp:Label>

                        </td>

                        <th class="titulo-tabla col-md-1" scope="row">Duración *</th>
                        <td>
                            <div id="DatosSancion" class="input-group">
                                <asp:TextBox ID="txt001LRPA" Enabled="false" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control form-control-decena input-sm" OnTextChanged="txt001LRPA_TextChanged" runat="server" MaxLength="2" />
                                <!-- onblur="actualizaFecha()" -->


                                <span class="input-group-addon-telefono" id="Span1">Años</span>
                                <asp:TextBox ID="txt002LRPA" Enabled="false" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control form-control-decena input-sm" runat="server" MaxLength="2" />
                                <span class="input-group-addon-telefono" id="Span2">Meses</span>
                                <asp:TextBox ID="txt007LRPA" Enabled="false" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control input-sm" runat="server" MaxLength="4" />
                                <span class="input-group-addon-telefono" id="Span3">Días</span>
                                <asp:TextBox ID="txt009LRPA" Enabled="false" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control input-sm" runat="server" MaxLength="5" />
                                <span class="input-group-addon-telefono" id="Span4">Abono</span>

                            </div>
                            <%--<span id="errorFechaSancion" class="alert-warning">La fecha de Termino de sanción no puede ser menor que su fecha de Inicio</span>--%>
                            <ajax:FilteredTextBoxExtender ID="fte4" runat="server" TargetControlID="txt001LRPA" ValidChars="0123456789" />
                            <ajax:FilteredTextBoxExtender ID="fte5" runat="server" TargetControlID="txt002LRPA" ValidChars="0123456789" />
                            <ajax:FilteredTextBoxExtender ID="fte6" runat="server" TargetControlID="txt007LRPA" ValidChars="0123456789" />
                            <ajax:FilteredTextBoxExtender ID="fte7" runat="server" TargetControlID="txt009LRPA" ValidChars="0123456789" />

                            <asp:LinkButton ID="lnk001" runat="server" Visible="false">CALCULAR FECHA</asp:LinkButton>&#160;
                                             
                                                <asp:Label ID="lbl_avisoDuracionLRPA" CssClass="help-block" Visible="false" runat="server"></asp:Label>
                            <asp:HiddenField ID="myInput" runat="server" />


                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla" scope="row">Fecha Termino Sanción *</th>
                        <td>
                            <asp:TextBox ID="txt003LRPA" CssClass="form-control form-control-fecha-large input-sm avoid-clicks" runat="server" MaxLength="10"></asp:TextBox></td>
                                                
                        <th class="titulo-tabla col-md-1" scope="row">Sanción Mixta PLA, PLE, CRC, CSC</th>
                        <td>
                            <div class="text-center">

                                <asp:CheckBox ID="Chk002LRPAMixta" runat="server" AutoPostBack="true" OnCheckedChanged="Chk002LRPAMixta_CheckedChanged" />

                                <asp:Label ID="LblfechaLRPA" CssClass="help-block" runat="server"></asp:Label>

                            </div>
                        </td>
                    
                        </td>
                    </tr>
                </table>


            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="Chk002LRPAMixta" />--%>
            </Triggers>

            <ContentTemplate>
                    <asp:UpdatePanel ID="upLRP" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlLRPAmixta" runat="server" Visible="False">
                                                <table class="table table-bordered tabla-tabs table-condensed">

                                <tr>
                                    <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio Sanción: *</th>
                                    <td class="col-md-3">
                                        <asp:TextBox ID="ddown009LRPA" CssClass="form-control form-control-fecha-large input-sm" runat="server" disabled="disabled" />
                                        <%--<ajax:CalendarExtender ID="CalendarExtende943" runat="server" Format="dd-MM-yyyy" TargetControlID="ddown009LRPA" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende943" />
                                            <asp:RangeValidator ID="RangeValidator943" runat="server" Text="Fecha Invalida" ControlToValidate="ddown009LRPA" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />--%>
                                        <asp:Label ID="lblfechaIni2LRPA" runat="server" CssClass="help-block" Visible="false"></asp:Label></td>

                                    <th class="titulo-tabla col-md-1" scope="row">Duración *</th>
                                    <td>
                                        <div class="input-group">

                                            <asp:TextBox ID="txt004LRPA" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control form-control-decena input-sm" runat="server" MaxLength="2" />
                                            <span class="input-group-addon-telefono" id="Span5">Años</span>

                                            <asp:TextBox ID="txt005LRPA" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control form-control-decena input-sm" runat="server" MaxLength="2" />
                                            <span class="input-group-addon-telefono" id="Span6">Meses</span>

                                            <asp:TextBox ID="txt008LRPA" onChange="ObtenerFechaTerminoSancion(0);return false;" CssClass="form-control form-control-90 input-sm" runat="server" MaxLength="4" />
                                            <span class="input-group-addon-telefono" id="Span7">Días</span>

                                            <asp:LinkButton ID="lnk002" runat="server" Visible="false">CALCULAR FECHA</asp:LinkButton>&#160;
                                        </div>
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt004LRPA" ValidChars="0123456789" />
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt005LRPA" ValidChars="0123456789" />
                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt008LRPA" ValidChars="0123456789" />
                                        <asp:Label ID="lbl_avisoDuracion2LRPA" runat="server" CssClass="help-block" Visible="false"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Término Sanción *</th>
                                    <td>
                                        <asp:TextBox ID="txt006LRPA" CssClass="form-control form-control-fecha-large input-sm avoid-clicks" runat="server"></asp:TextBox>
                                    </td>

                                    <th class="titulo-tabla" scope="row">Modelo Sanción Mixta</th>
                                    <td>
                                        <asp:DropDownList ID="ddown011LRPA" AutoPostBack="true" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnk_limpiaFechas" runat="server" OnClick="lnk_limpiaFechas_Click" CausesValidation="false">RESETEAR FECHAS</asp:LinkButton></td>
                                </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </ContentTemplate>
        </asp:UpdatePanel>


        <h4 class="subtitulo-form">
            <label>Tribunal de Seguimiento de la Medida o Sanción </label>
        </h4>

        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <table class="table table-bordered tabla-tabs table-condensed">

                    <tr>
                        <th class="titulo-tabla" scope="row">Región  *</th>
                        <td colspan="3">
                            <%--Aqui se puede validar que ddown003LRPA y ddown004LRPA tengasn algo seleccionado antes de envairlo al código --%>
                            <asp:DropDownList ID="ddown003LRPA" CssClass="form-control input-sm" AutoPostBack="true" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged">
                                <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Tipo Tribunal</th>
                        <td class="col-md-4">
                            <%--Aqui se puede validar que ddown003LRPA y ddown004LRPA tengasn algo seleccionado antes de envairlo al código --%>
                            <asp:DropDownList ID="ddown004LRPA" CssClass="form-control input-sm" AutoPostBack="true" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown004LRPA_SelectedIndexChanged">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>

                        <th class="titulo-tabla col-md-1" scope="row">Tribunal</th>
                        <td>
                            <asp:DropDownList ID="ddown005LRPA" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList><asp:DropDownList ID="dd_focus1" CssClass="form-control input-sm" runat="server" Visible="False">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                </table>


                <h4 class="subtitulo-form">
                    <label>Sanción Accesoria PLA, PLE, CRC, CSC</label></h4>


                <asp:GridView ID="grd001LRPA" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" Visible="False">
            <Columns>
                <asp:BoundField HeaderText="Descripci&#243;n (Tipo de Sanci&#243;n)" DataField="CodSancion"></asp:BoundField>
                <asp:BoundField HeaderText="CodTipoSancionAccesoria" DataField="CodTipoSancionAccesoria"></asp:BoundField>
                <asp:BoundField HeaderText="CodSancion" DataField="Descripcion"></asp:BoundField>
            </Columns>
            <HeaderStyle CssClass="titulo-tabla table-borderless" />
            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
            <RowStyle CssClass="caja-tabla table-bordered" />
        </asp:GridView>
                <table class="table table-bordered tabla-tabs  table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Sanción Accesoria (Sí)</th>
                        <td>
                            <asp:CheckBox ID="chk001LRPA" runat="server" AutoPostBack="true" OnCheckedChanged="chk001LRPA_CheckedChanged" /></td>
                        <asp:DropDownList ID="focus1lrpachk" CssClass="form-control input-sm" runat="server" Visible="False">
                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                        </asp:DropDownList>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table id="pnl1LRPA" visible="false" runat="server" class="table table-borderless  table-condensed">
            <tbody>
                <tr id="tr_tipo_sancion_accesoria" runat="server">
                    <th class="titulo-tabla col-md-1" scope="row">Tipo(s) de Sanción Accesoria *</th>
                    <td>
                        <asp:DropDownList ID="ddown006LRPA" CssClass="form-control input-sm" runat="server" Visible="true">
                        </asp:DropDownList></td>
                    <td>
                        <div class="pull-right">
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnAgregarTsancionLRPA" runat="server" CausesValidation="false" OnClick="btnAgregarTsancionLRPA_Click" Visible="False">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Tipo Sanción
                            </asp:LinkButton>
                        </div>
                    </td>

                </tr>

            </tbody>
        </table>
        <asp:Label ID="lbl_avisoLRPA" runat="server" CssClass="help-block" Visible="False" Width="100%"></asp:Label>

        
        <asp:Panel ID="PnlServicio" runat="server" Visible="true">
            <h4 class="subtitulo-form">
                <label>Servicio en Beneficio a la Comunidad (SBC) y Programa Salidas Alternativas (PSA)</label></h4>

            <table class="table table-bordered table-condensed">

                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Tipo de Sanción (SBC) o Vía Ingreso *</th>
                        <td class="col-md-4">
                            <asp:DropDownList ID="ddown_tsancion" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    
                        <th class="titulo-tabla col-md-1" scope="row">Horas Servicio a la Comunidad *</th>
                        <td>
                            <asp:TextBox ID="txt_hservi" CssClass="form-control  input-sm" runat="server" MaxLength="3"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="fte8" runat="server" TargetControlID="txt_hservi" ValidChars="0123456789" />
                            <asp:Label ID="lbl_mensaje002" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla" scope="row">Tipo Actividad en Beneficio a la Comunidad *</th>
                        <td>
                            <asp:DropDownList ID="ddown_tipoBC" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    
                        <th class="titulo-tabla" scope="row">Tipo Institución en la que presta Servicio</th>
                        <td>
                            <asp:DropDownList ID="ddown_IPSER" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th class="titulo-tabla" scope="row">Área de Trabajo en la Institución</th>
                        <td>
                            <asp:DropDownList ID="ddown_areaTI" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    
                        <th class="titulo-tabla" scope="row">Tipo Reparación Daño</th>
                        <td>
                            <asp:DropDownList ID="ddown_repdaño" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown_repdaño_SelectedIndexChanged">
                                <asp:ListItem Value="-2">Seleccionar</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    </table>
                        <h4 class="subtitulo-form" ><label>Condiciones de Ingreso (PSA)</label></h4>
            <table class="table table-bordered table-condensed">
                    <tr>
                        <th class="titulo-tabla col-md-1" scope="row">Solicitante Ingreso</th>
                        <td>
                            <asp:DropDownList ID="ddown_conIng" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem>Seleccionar</asp:ListItem>
                            </asp:DropDownList><asp:Label ID="lbl_mensaje003" runat="server" CssClass="help-block" Visible="False"></asp:Label></td>
                    
                        
                    
                        <td>
                            <asp:Label ID="Lbl_mensaje001" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                    
                            <asp:TextBox ID="txt_foco" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" Visible="False" ReadOnly="True"></asp:TextBox>
                            <asp:TextBox ID="txt0010LRPA" runat="server"  Text="0" Visible="False" /><ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender90" runat="server" FilterType="Numbers" TargetControlID="txt0010LRPA" BehaviorID="_content_FilteredTextBoxExtender90" />
                            <asp:RangeValidator ID="RangeValidator90" runat="server" Display="Dynamic" ErrorMessage="Numero Fuera De Rango" ControlToValidate="txt0010LRPA" Type="Integer" MaximumValue="999999999" MinimumValue="0" /></td>
                    </tr>

            </table>
             <asp:GridView ID="grd_LRPA02" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4">
                                <Columns>
                                    <asp:BoundField HeaderText="CodCondicionIngreso" DataField="CodCondicionIngreso"></asp:BoundField>
                                    <asp:BoundField HeaderText="Descripcion (Condicion Ingreso)" DataField="Descripcion"></asp:BoundField>
                                    <asp:BoundField HeaderText="CodSancion" DataField="CodMedidaSancion"></asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="titulo-tabla" />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                            </asp:GridView>
        </asp:Panel>
        <div class="botonera pull-right">
            <asp:Button CssClass="btn btn-info btn-sm" ID="btn_coning" runat="server" Text="Agregar Condición Ingreso" OnClick="btnAgregar_coning_click" CausesValidation="false" />
            <asp:DropDownList ID="dd_focus2" runat="server" Visible="False">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--            <div class="botonera pull-right">   
                <asp:Button CssClass="btn btn-info btn-ancho-140" ID="btnsaveingreso2" runat="server" Text="Realizar Ingreso" OnClick="btnsaveingreso2_Click" />
            </div>--%>
        <h4 class="subtitulo-form">
            <label>Término de la medida o sanción (Todos)</label></h4>

        <table class="table table-bordered  table-condensed">
            <tbody>
                <tr>
                    <th class="titulo-tabla col-md-1" scope="row">Fecha de Termino Sanción:</th>
                    <td class="col-md-4">
                        <asp:TextBox ID="ddown007LRPA" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" /><ajax:CalendarExtender ID="CalendarExtende1030" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="ddown007LRPA" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                        <asp:RangeValidator ID="RangeValidator1030" runat="server" ErrorMessage="Fecha Invalida" Display="Dynamic" CssClass="help-block" ControlToValidate="ddown007LRPA" Type="Date" MaximumValue="2020-12-31" MinimumValue="1000-01-01" />

                    </td>
                
                    <th class="titulo-tabla col-md-1" scope="row">Situación del Termino de la Sanción:</th>
                    <td>
                        <asp:DropDownList ID="ddown008LRPA" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                            <asp:ListItem Value="-1"> Seleccionar</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

            </tbody>
        </table>

        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <table class="table table-borderless table-condensed">
                <tbody>
                    <tr id="tr1" runat="server">
                        <td class="text-right">
                            <asp:TextBox ID="TextBox1" runat="server" Width="50px" Visible="False" />
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender102" runat="server" FilterType="Numbers" TargetControlID="txt0010LRPA" />
                            <asp:RangeValidator ID="RangeValidator102" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txt0010LRPA" Type="Integer" MaximumValue="999999999" MinimumValue="0" />

                            <asp:LinkButton CssClass="btn btn-danger fixed-width-button" ID="btn_GuardarLRPA" runat="server" OnClick="btn_GuardarLRPA_Click" CausesValidation="false">
                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                            </asp:LinkButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>

    </asp:Panel>

