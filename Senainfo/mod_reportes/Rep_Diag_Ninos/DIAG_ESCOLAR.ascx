<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DIAG_ESCOLAR.ascx.cs" Inherits="mod_reportes_Rep_Diag_Ninos_DIAG_ESCOLAR" %>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Excel1.bmp"
    OnClick="ImageButton1_Click" /><br />
<br />
<asp:GridView ID="grd001" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    CellPadding="2" ForeColor="#333333" GridLines="None" PageSize="20" Width="100%" OnPageIndexChanging="grd001_PageIndexChanging">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <Columns>
        <asp:BoundField DataField="CodNino" HeaderText="Cod. Ni&#241;o">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="ICodIE" HeaderText="Icodie">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="Apellido_Paterno" HeaderText="Ap. Paterno">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="Apellido_Materno" HeaderText="Ap. Materno">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="NombresNino" HeaderText="Nombres">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="Rut" HeaderText="Rut">
            <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
            <HeaderStyle Wrap="False" />
            <FooterStyle Wrap="False" />
        </asp:BoundField>
        <asp:BoundField DataField="Sexo" HeaderText="Sexo">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="F. Nacim."
            HtmlEncode="False">
            <ItemStyle Font-Size="11px" Width="60px" Wrap="True" />
            <HeaderStyle Wrap="True" />
            <FooterStyle Wrap="True" />
        </asp:BoundField>
        <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="F. Ingreso">
            <ItemStyle Font-Size="11px" HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="FechaEgreso" DataFormatString="{0:d}" HeaderText="F. Egreso">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="ICodEscolar" HeaderText="Cod. Escolar">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="CodDiagnostico" HeaderText="Cod. Diagnostico">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="CodEscolaridad" HeaderText="Cod. Escolaridad">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="Escolaridad" HeaderText="Escolaridad">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
        <asp:BoundField DataField="FechaDiagnostico" HeaderText="F. Diagnostico" />
        <asp:BoundField DataField="AnoEscolaridad" HeaderText="A&#241;o Escolaridad" />
        <asp:BoundField DataField="CodTipoAsistencia" HeaderText="Cod. Tipo Asistencia" />
        <asp:BoundField DataField="TipoAsistencia" HeaderText="Tipo Asistencia" />
        <asp:BoundField DataField="Tecnico" HeaderText="Tecnico" HtmlEncode="False">
            <ItemStyle Font-Size="11px" Width="60px" />
        </asp:BoundField>
        <asp:BoundField DataField="FechaActualizacion" DataFormatString="{0:d}" HeaderText="F. Actualizacion">
            <ItemStyle Font-Size="11px" />
        </asp:BoundField>
    </Columns>
    <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
    <EditRowStyle BackColor="#2461BF" Font-Size="11px" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" Font-Names="Arial" Font-Size="11px"
        ForeColor="#333333" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
        ForeColor="White" HorizontalAlign="Left" />
    <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
</asp:GridView>
