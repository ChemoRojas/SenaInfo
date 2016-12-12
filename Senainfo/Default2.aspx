<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button1" runat="server" Text="Button" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <a href="App_Code/ninos.xsd"></a>
        </div>
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp;
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="346px">
        </asp:DropDownList>&nbsp;<br />
        <br />
        &nbsp;
        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="Button2" runat="server" Text="Button" /><br />
        <br />
        &nbsp;
        <asp:TextBox ID="TextBox1" runat="server">11911620</asp:TextBox>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" BackColor="White"
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ICodDiligencia"
            DataMember="DefaultView" DataSourceID="SqlDataSource1" GridLines="Both">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <EditItemTemplate>
                ICodDiligencia:
                <asp:Label ID="ICodDiligenciaLabel1" runat="server" Text='<%# Eval("ICodDiligencia") %>'>
                </asp:Label><br />
                CodDiligencia:
                <asp:TextBox ID="CodDiligenciaTextBox" runat="server" Text='<%# Bind("CodDiligencia") %>'>
                </asp:TextBox><br />
                ICodIE:
                <asp:TextBox ID="ICodIETextBox" runat="server" Text='<%# Bind("ICodIE") %>'>
                </asp:TextBox><br />
                CodNino:
                <asp:TextBox ID="CodNinoTextBox" runat="server" Text='<%# Bind("CodNino") %>'>
                </asp:TextBox><br />
                FechaSolicitud:
                <asp:TextBox ID="FechaSolicitudTextBox" runat="server" Text='<%# Bind("FechaSolicitud") %>'>
                </asp:TextBox><br />
                TipoSolicitanteDiligencia:
                <asp:TextBox ID="TipoSolicitanteDiligenciaTextBox" runat="server" Text='<%# Bind("TipoSolicitanteDiligencia") %>'>
                </asp:TextBox><br />
                Realizada:
                <asp:TextBox ID="RealizadaTextBox" runat="server" Text='<%# Bind("Realizada") %>'>
                </asp:TextBox><br />
                FechaRealizada:
                <asp:TextBox ID="FechaRealizadaTextBox" runat="server" Text='<%# Bind("FechaRealizada") %>'>
                </asp:TextBox><br />
                CodInstitucion:
                <asp:TextBox ID="CodInstitucionTextBox" runat="server" Text='<%# Bind("CodInstitucion") %>'>
                </asp:TextBox><br />
                CodTrabajador:
                <asp:TextBox ID="CodTrabajadorTextBox" runat="server" Text='<%# Bind("CodTrabajador") %>'>
                </asp:TextBox><br />
                PropuestaTecnica:
                <asp:TextBox ID="PropuestaTecnicaTextBox" runat="server" Text='<%# Bind("PropuestaTecnica") %>'>
                </asp:TextBox><br />
                ResultadoDiscernimiento:
                <asp:TextBox ID="ResultadoDiscernimientoTextBox" runat="server" Text='<%# Bind("ResultadoDiscernimiento") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
            <RowStyle BackColor="White" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <InsertItemTemplate>
                CodDiligencia:
                <asp:TextBox ID="CodDiligenciaTextBox" runat="server" Text='<%# Bind("CodDiligencia") %>'>
                </asp:TextBox><br />
                ICodIE:
                <asp:TextBox ID="ICodIETextBox" runat="server" Text='<%# Bind("ICodIE") %>'>
                </asp:TextBox><br />
                CodNino:
                <asp:TextBox ID="CodNinoTextBox" runat="server" Text='<%# Bind("CodNino") %>'>
                </asp:TextBox><br />
                FechaSolicitud:
                <asp:TextBox ID="FechaSolicitudTextBox" runat="server" Text='<%# Bind("FechaSolicitud") %>'>
                </asp:TextBox><br />
                TipoSolicitanteDiligencia:
                <asp:TextBox ID="TipoSolicitanteDiligenciaTextBox" runat="server" Text='<%# Bind("TipoSolicitanteDiligencia") %>'>
                </asp:TextBox><br />
                Realizada:
                <asp:TextBox ID="RealizadaTextBox" runat="server" Text='<%# Bind("Realizada") %>'>
                </asp:TextBox><br />
                FechaRealizada:
                <asp:TextBox ID="FechaRealizadaTextBox" runat="server" Text='<%# Bind("FechaRealizada") %>'>
                </asp:TextBox><br />
                CodInstitucion:
                <asp:TextBox ID="CodInstitucionTextBox" runat="server" Text='<%# Bind("CodInstitucion") %>'>
                </asp:TextBox><br />
                CodTrabajador:
                <asp:TextBox ID="CodTrabajadorTextBox" runat="server" Text='<%# Bind("CodTrabajador") %>'>
                </asp:TextBox><br />
                PropuestaTecnica:
                <asp:TextBox ID="PropuestaTecnicaTextBox" runat="server" Text='<%# Bind("PropuestaTecnica") %>'>
                </asp:TextBox><br />
                ResultadoDiscernimiento:
                <asp:TextBox ID="ResultadoDiscernimientoTextBox" runat="server" Text='<%# Bind("ResultadoDiscernimiento") %>'>
                </asp:TextBox><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                ICodDiligencia:
                <asp:Label ID="ICodDiligenciaLabel" runat="server" Text='<%# Eval("ICodDiligencia") %>'>
                </asp:Label><br />
                CodDiligencia:
                <asp:Label ID="CodDiligenciaLabel" runat="server" Text='<%# Bind("CodDiligencia") %>'>
                </asp:Label><br />
                ICodIE:
                <asp:Label ID="ICodIELabel" runat="server" Text='<%# Bind("ICodIE") %>'></asp:Label><br />
                CodNino:
                <asp:Label ID="CodNinoLabel" runat="server" Text='<%# Bind("CodNino") %>'></asp:Label><br />
                FechaSolicitud:
                <asp:Label ID="FechaSolicitudLabel" runat="server" Text='<%# Bind("FechaSolicitud") %>'>
                </asp:Label><br />
                TipoSolicitanteDiligencia:
                <asp:Label ID="TipoSolicitanteDiligenciaLabel" runat="server" Text='<%# Bind("TipoSolicitanteDiligencia") %>'>
                </asp:Label><br />
                Realizada:
                <asp:Label ID="RealizadaLabel" runat="server" Text='<%# Bind("Realizada") %>'></asp:Label><br />
                FechaRealizada:
                <asp:Label ID="FechaRealizadaLabel" runat="server" Text='<%# Bind("FechaRealizada") %>'>
                </asp:Label><br />
                CodInstitucion:
                <asp:Label ID="CodInstitucionLabel" runat="server" Text='<%# Bind("CodInstitucion") %>'>
                </asp:Label><br />
                CodTrabajador:
                <asp:Label ID="CodTrabajadorLabel" runat="server" Text='<%# Bind("CodTrabajador") %>'>
                </asp:Label><br />
                PropuestaTecnica:
                <asp:Label ID="PropuestaTecnicaLabel" runat="server" Text='<%# Bind("PropuestaTecnica") %>'>
                </asp:Label><br />
                ResultadoDiscernimiento:
                <asp:Label ID="ResultadoDiscernimientoLabel" runat="server" Text='<%# Bind("ResultadoDiscernimiento") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:senainfoConnectionString %>" DeleteCommand="DELETE FROM [Diligencias] WHERE [ICodDiligencia] = @original_ICodDiligencia AND [CodDiligencia] = @original_CodDiligencia AND [ICodIE] = @original_ICodIE AND [CodNino] = @original_CodNino AND [FechaSolicitud] = @original_FechaSolicitud AND [TipoSolicitanteDiligencia] = @original_TipoSolicitanteDiligencia AND [Realizada] = @original_Realizada AND [FechaRealizada] = @original_FechaRealizada AND [CodInstitucion] = @original_CodInstitucion AND [CodTrabajador] = @original_CodTrabajador AND [PropuestaTecnica] = @original_PropuestaTecnica AND [ResultadoDiscernimiento] = @original_ResultadoDiscernimiento"
            InsertCommand="INSERT INTO [Diligencias] ([CodDiligencia], [ICodIE], [CodNino], [FechaSolicitud], [TipoSolicitanteDiligencia], [Realizada], [FechaRealizada], [CodInstitucion], [CodTrabajador], [PropuestaTecnica], [ResultadoDiscernimiento]) VALUES (@CodDiligencia, @ICodIE, @CodNino, @FechaSolicitud, @TipoSolicitanteDiligencia, @Realizada, @FechaRealizada, @CodInstitucion, @CodTrabajador, @PropuestaTecnica, @ResultadoDiscernimiento)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Diligencias] WHERE ([ICodIE] = @ICodIE)"
            UpdateCommand="UPDATE [Diligencias] SET [CodDiligencia] = @CodDiligencia, [ICodIE] = @ICodIE, [CodNino] = @CodNino, [FechaSolicitud] = @FechaSolicitud, [TipoSolicitanteDiligencia] = @TipoSolicitanteDiligencia, [Realizada] = @Realizada, [FechaRealizada] = @FechaRealizada, [CodInstitucion] = @CodInstitucion, [CodTrabajador] = @CodTrabajador, [PropuestaTecnica] = @PropuestaTecnica, [ResultadoDiscernimiento] = @ResultadoDiscernimiento WHERE [ICodDiligencia] = @original_ICodDiligencia AND [CodDiligencia] = @original_CodDiligencia AND [ICodIE] = @original_ICodIE AND [CodNino] = @original_CodNino AND [FechaSolicitud] = @original_FechaSolicitud AND [TipoSolicitanteDiligencia] = @original_TipoSolicitanteDiligencia AND [Realizada] = @original_Realizada AND [FechaRealizada] = @original_FechaRealizada AND [CodInstitucion] = @original_CodInstitucion AND [CodTrabajador] = @original_CodTrabajador AND [PropuestaTecnica] = @original_PropuestaTecnica AND [ResultadoDiscernimiento] = @original_ResultadoDiscernimiento">
            <DeleteParameters>
                <asp:Parameter Name="original_ICodDiligencia" Type="Int32" />
                <asp:Parameter Name="original_CodDiligencia" Type="Int32" />
                <asp:Parameter Name="original_ICodIE" Type="Int32" />
                <asp:Parameter Name="original_CodNino" Type="Int32" />
                <asp:Parameter Name="original_FechaSolicitud" Type="DateTime" />
                <asp:Parameter Name="original_TipoSolicitanteDiligencia" Type="Int32" />
                <asp:Parameter Name="original_Realizada" Type="String" />
                <asp:Parameter Name="original_FechaRealizada" Type="DateTime" />
                <asp:Parameter Name="original_CodInstitucion" Type="Int32" />
                <asp:Parameter Name="original_CodTrabajador" Type="Int32" />
                <asp:Parameter Name="original_PropuestaTecnica" Type="String" />
                <asp:Parameter Name="original_ResultadoDiscernimiento" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="CodDiligencia" Type="Int32" />
                <asp:Parameter Name="ICodIE" Type="Int32" />
                <asp:Parameter Name="CodNino" Type="Int32" />
                <asp:Parameter Name="FechaSolicitud" Type="DateTime" />
                <asp:Parameter Name="TipoSolicitanteDiligencia" Type="Int32" />
                <asp:Parameter Name="Realizada" Type="String" />
                <asp:Parameter Name="FechaRealizada" Type="DateTime" />
                <asp:Parameter Name="CodInstitucion" Type="Int32" />
                <asp:Parameter Name="CodTrabajador" Type="Int32" />
                <asp:Parameter Name="PropuestaTecnica" Type="String" />
                <asp:Parameter Name="ResultadoDiscernimiento" Type="String" />
                <asp:Parameter Name="original_ICodDiligencia" Type="Int32" />
                <asp:Parameter Name="original_CodDiligencia" Type="Int32" />
                <asp:Parameter Name="original_ICodIE" Type="Int32" />
                <asp:Parameter Name="original_CodNino" Type="Int32" />
                <asp:Parameter Name="original_FechaSolicitud" Type="DateTime" />
                <asp:Parameter Name="original_TipoSolicitanteDiligencia" Type="Int32" />
                <asp:Parameter Name="original_Realizada" Type="String" />
                <asp:Parameter Name="original_FechaRealizada" Type="DateTime" />
                <asp:Parameter Name="original_CodInstitucion" Type="Int32" />
                <asp:Parameter Name="original_CodTrabajador" Type="Int32" />
                <asp:Parameter Name="original_PropuestaTecnica" Type="String" />
                <asp:Parameter Name="original_ResultadoDiscernimiento" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" DefaultValue="0" Name="ICodIE" PropertyName="Text"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="CodDiligencia" Type="Int32" />
                <asp:Parameter Name="ICodIE" Type="Int32" />
                <asp:Parameter Name="CodNino" Type="Int32" />
                <asp:Parameter Name="FechaSolicitud" Type="DateTime" />
                <asp:Parameter Name="TipoSolicitanteDiligencia" Type="Int32" />
                <asp:Parameter Name="Realizada" Type="String" />
                <asp:Parameter Name="FechaRealizada" Type="DateTime" />
                <asp:Parameter Name="CodInstitucion" Type="Int32" />
                <asp:Parameter Name="CodTrabajador" Type="Int32" />
                <asp:Parameter Name="PropuestaTecnica" Type="String" />
                <asp:Parameter Name="ResultadoDiscernimiento" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
 
        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="ACEPTAR" OnClick="WebImageButton1_Click" />
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataKeyNames="ICodDiligencia" DataMember="DefaultView"
            DataSourceID="SqlDataSource1">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ICodDiligencia" HeaderText="ICodDiligencia" InsertVisible="False"
                    ReadOnly="True" SortExpression="ICodDiligencia" />
                <asp:BoundField DataField="CodDiligencia" HeaderText="CodDiligencia" SortExpression="CodDiligencia" />
                <asp:BoundField DataField="ICodIE" HeaderText="ICodIE" SortExpression="ICodIE" />
                <asp:BoundField DataField="CodNino" HeaderText="CodNino" SortExpression="CodNino" />
                <asp:BoundField DataField="FechaSolicitud" HeaderText="FechaSolicitud" SortExpression="FechaSolicitud" />
                <asp:BoundField DataField="TipoSolicitanteDiligencia" HeaderText="TipoSolicitanteDiligencia"
                    SortExpression="TipoSolicitanteDiligencia" />
                <asp:BoundField DataField="Realizada" HeaderText="Realizada" SortExpression="Realizada" />
                <asp:BoundField DataField="FechaRealizada" HeaderText="FechaRealizada" SortExpression="FechaRealizada" />
                <asp:BoundField DataField="CodInstitucion" HeaderText="CodInstitucion" SortExpression="CodInstitucion" />
                <asp:BoundField DataField="CodTrabajador" HeaderText="CodTrabajador" SortExpression="CodTrabajador" />
                <asp:BoundField DataField="PropuestaTecnica" HeaderText="PropuestaTecnica" SortExpression="PropuestaTecnica" />
                <asp:BoundField DataField="ResultadoDiscernimiento" HeaderText="ResultadoDiscernimiento"
                    SortExpression="ResultadoDiscernimiento" />
            </Columns>
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        </asp:GridView>
    </form>
</body>
</html>
