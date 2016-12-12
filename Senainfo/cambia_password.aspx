<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="cambia_password.aspx.cs" Inherits="cambia_password" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Cambiar Contraseña :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">
</head>

<body>
    <form id="form1" runat="server">

        <div class="container theme-showcase" role="main">
            <div class="well">
                <h4 class="subtitulo-form">Cambiar Contraseña</h4>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Panel ID="pnlCambio" runat="server">
                        <table class="table table-borderless table-condensed">
                            <tr>
                                <td><asp:Label ID="lbl_usuario" runat="server">Usuario</asp:Label></td>
                                <td><asp:TextBox ID="txt_usuario" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lbl_password" runat="server">Password Actual</asp:Label></td>
                                <td><asp:TextBox ID="txt_password" runat="server" TextMode="Password" CssClass="form-control input-sm"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="Label1" runat="server" Width="150px">Nueva Password</asp:Label></td>
                                <td><asp:TextBox ID="txt_nueva_password" runat="server" TextMode="Password" CssClass="form-control input-sm"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="Label2" runat="server" >Repetir Password</asp:Label></td>
                                <td><asp:TextBox ID="txt_repassword" runat="server" TextMode="Password" CssClass="form-control input-sm"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Button CssClass="btn btn-primary btn-sm" ID="imb_ingresar" runat="server" Text="Cambiar" OnClick="imb_ingresar_Click" /></td>
                            </tr>
                        </table>
                        <asp:Label ID="lbl_aviso" runat="server"></asp:Label>
                        </asp:Panel>

                        <asp:Panel ID="pnlMensaje" runat="server" Visible="False">
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </asp:Panel>
       
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
