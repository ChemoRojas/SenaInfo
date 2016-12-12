<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transferencias.aspx.cs" Inherits="mod_institucion_Transferencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Transferencias :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
</head>

<body role="document">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="container theme-showcase" role="main">
                        <div class="well">
                            <h4 class="subtitulo-form">
                                <asp:Label ID="lbl001" runat="server" Text="Transferencias"></asp:Label><br />
                                <asp:Label ID="lbl004" runat="server" Text="Institución : "></asp:Label>
                                <asp:Label ID="lbl005" runat="server"></asp:Label>
                            </h4>
                            <hr>
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="table table-bordered table-col-fix table-condensed">
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Fecha Transaccion:</th>
                                            <td>
                                                <asp:TextBox ID="WebDateTimeEdit1" runat="server" Text="Seleccione Fecha" ReadOnly="True" TextMode="SingleLine"></asp:TextBox>
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="WebDateTimeEdit1" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="WebDateTimeEdit1" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">Monto Transaccion:</th>
                                            <td>
                                                <asp:TextBox ID="lbl003" runat="server" ReadOnly="True" />
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender64" runat="server" FilterType="Numbers" TargetControlID="lbl003" />
                                                <asp:RangeValidator ID="RangeValidator64" runat="server" Text="Numero Fuera De Rango" ControlToValidate="lbl003" Type="Integer" MaximumValue="999999999" MinimumValue="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button CssClass="btn btn-info btn-sm" ID="WebImageButton1" runat="server" Text="Cerrar" OnClick="WebImageButton1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                 </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>