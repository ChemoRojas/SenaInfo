<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mesa_excepciones.aspx.cs" Inherits="mod_mesa_mesa_excepciones" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<!DOCTYPE html>

<html lang="es">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Mesa de Ayuda UPLAE :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/senainfoTools.js"></script>



    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">
    <script src="../js/jquery-ui.js"></script>

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
            <script src="../js/bootstrap.min.js"></script>



    <script type="text/javascript">
        function Mensajear(mensaje) {
            alert(mensaje);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <div class="container theme-showcase" role="main">
            <ol class="breadcrumb">
                <li><a href="../index.aspx">Inicio</a></li>
                <li class="active">Mesa</li>
                <li class="active">Mesa de Ayuda UPLAE</li>
            </ol>

            <div class="alert alert-warning text-center" role="alert" id="alertw" runat="server" visible="false">
                <span class="glyphicon glyphicon-warning-sign"></span>
                <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>

            </div>


            <div class="well">
                <h4 class="subtitulo-form">Mesa de Ayuda UPLAE</h4>
                <hr />
                <div class="row">
                    <div class="col-md-12">

                        <asp:GridView ID="grv_excepciones" runat="server" CssClass="table table-bordered text-center" AutoGenerateColumns="False" OnRowCommand="grv_excepciones_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Accion">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" CssClass="form-control input-sm input-UPLAE" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <h5>
                                            <asp:Label ID="Label1" CssClass="subtitulo-form" runat="server" Text='<%# Bind("accion") %>'></asp:Label></h5>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Procedimiento" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" CssClass="form-control input-sm input-UPLAE" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Procedimiento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P1">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_p1" runat="server" Text='<%# Bind("P1") %>'></asp:Label>
                                        <asp:TextBox ID="txt_p1" CssClass="form-control input-sm input-UPLAE" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="grupo1" CssClass="help-block" Display="Dynamic" ControlToValidate="txt_p1" ErrorMessage="Formato Inv&aacute;lido" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P2">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_p2" runat="server" Text='<%# Bind("p2") %>'></asp:Label>
                                        <asp:TextBox ID="txt_p2" CssClass="form-control input-sm input-UPLAE" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="help-block" Display="Dynamic" ValidationGroup="grupo1" ControlToValidate="txt_p2" ErrorMessage="Formato Inv&aacute;lido" ValidationExpression="^\d{6}$"></asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ejecutar">
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-sm btn-danger" ID="btn_ejecutar" runat="server" ValidationGroup="grupo1" CommandArgument="demo">
                                                    <span class="glyphicon glyphicon-ok"> </span>&nbsp;Aplicar Procedimiento
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <HeaderStyle CssClass="titulo-tabla-centrado table-borderless" />
                            <RowStyle CssClass="table-bordered" />
                        </asp:GridView>

                        <label class="help-block">El formato para la fecha debe ser añomes. Ejemplo 201502</label>

                        <asp:GridView ID="grv_datos" runat="server" CssClass="table table-bordered" Visible="False">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <footer class="footer">
            <div class="container">
                <p>
                    Para tus dudas y consultas, escribe a:
                <br>
                    mesadeayuda@sename.cl
                </p>
            </div>
        </footer>


    </form>
</body>
</html>
