<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DiagnosticoEscolar.ascx.cs" Inherits="DiagnosticoEscolar" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<div class="well">
    <table> <%--border="0" cellpadding="1" cellspacing="1" width="100%"--%>
        <tr>
            <td>
                <%--&nbsp;--%>Diagnóstico Escolar
                <br />
                <asp:Label ID="lbl002aa" runat="server" CssClass="texto_rojo_peque" Width="100%"></asp:Label>
                <asp:Label ID="lbl001aa" runat="server" CssClass="texto_rojo_peque" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_fecha" runat="server" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Fecha Diagnóstico
                <br />
                <br />
            </td>
            <td>
                <%--<asp:TextBox  CssClass="form-control form-control-20 input-sm" runat="server" Width="100px" />--%>
      <%--          <ajax:CalendarExtender ID="CalendarExtende16" runat="server" Enabled="true" ValidateRequestMode="Enabled" Format="dd-MM-yyyy"  TargetControlID="cal001" ViewStateMode="Enabled" />
                <asp:RangeValidator ID="RangeValidator1623" runat="server" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />    --%>                    
                <asp:TextBox ID="cal01" runat="server"></asp:TextBox>
                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="TextBox1_CalendarExtender" runat="server" TargetControlID="cal01" />
            </td>
        </tr>
        <tr>
            <td>
                Escolaridad
            </td>
            <td>
                <asp:DropDownList ID="ddown001" runat="server" AppendDataBoundItems="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Tipo Asistencia Escolar
            </td>
            <td>
                <asp:DropDownList ID="ddown003" runat="server" AppendDataBoundItems="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Año Escolaridad Indicada

            </td>
            <td>
                <asp:TextBox ID="txt001_wn" runat="server" AutoPostBack="True" ONVALUECHANGE="txt001_wn_ValueChange"/>
            </td>
        </tr>
        <tr>
            <td>
                Entrevistador (Técnico)
            </td>
            <td>
                <asp:DropDownList ID="ddown002" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Observaciones
            </td>
            <td>
                <swtb:SenameTextBox ID="txt002_te" runat="server" TextMode="MultiLine"></swtb:SenameTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <table>  <%--align="center" border="0" cellpadding="1" cellspacing="1" width="100%"--%>
                    <tr>
                        <td>
                            <br />
                            <asp:Button ID="btn001aa" runat="server" OnClick="imb_001aa_Click" Text="Agregar Diagnostico"  />
                            <asp:Button ID="btn002aa" runat="server" OnClick="imb_002aa_Click" Text="Modificar Diagnostico"  />
                            &nbsp;
                                <asp:Button ID="btn003aa" runat="server" OnClick="imb_003aa_Click" Text="Limpiar" CausesValidation="False"   />
                            &nbsp;
                                <asp:Button ID="btn004aa" runat="server" OnClick="btn004aa_Click" Text="Ver Historico"  />
                            &nbsp;
                                <%--<asp:Button ID="btn005aa" runat="server" OnClick="btn005aa_Click" Text="Volver"  />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grd001aa" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="grd001aa_RowCommand" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="alingreso" HeaderText="alingreso">
                            <%--<ItemStyle Font-Names="Arial" Font-Size="11px" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="ICodEscolar" HeaderText="ICod Escolar">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="50px" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="CodDiagnostico" HeaderText="Codigo del Diagnostico ">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="60px" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Escolaridad">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Left" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaDiagnostico" DataFormatString="{0:d}" HeaderText="Fecha de Diagnostico"
                            HtmlEncode="False">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="110px" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="AnoUltimoCursoAprobado" HeaderText="A&#241;o Escolaridad">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Center" />--%>
                        </asp:BoundField>
                        <asp:BoundField DataField="AsistenciaEscolar" HeaderText="Tipo Asistencia">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Left" />--%>
                        </asp:BoundField>
                        <asp:ButtonField Text="Modificar">
                            <%--<ItemStyle Font-Size="11px" HorizontalAlign="Center" />--%>
                            <ControlStyle ForeColor="Red" />
                        </asp:ButtonField>
                    </Columns>
                    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="XX-Small" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                    <EditRowStyle BackColor="#2461BF" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="XX-Small" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>

</div>
