<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_hechosdesalud.aspx.cs" Inherits="mod_ninos_hechosdesalud" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<!DOCTYPE html>

<html lang="es">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Hechos de Salud</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">


    <script type="text/javascript">

        function CerrarFancybox() {
            parent.$.fancybox.close();
        };

        function RefrescaPadre() {
            window.parent.MFref_HecSal();
        };

        function AbrirURLFancybox(url) {
            //parent.location.replace(url);
            window.parent.mfrefrescahechossalud();
        };

    </script>

</head>
<body class="body-form">
    <div class="container">
        <div class="row">
            <div class="col-md-12 caja-tabla">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <%--<asp:PostBackTrigger ControlID="btn001" />--%>
                            <%--<asp:PostBackTrigger ControlID="btn002" />--%>
                        </Triggers>
                        <ContentTemplate>


                            <%-- <tr>
                                        <td class="titulo_form" style="height: 22px">Hechos de Salud</td>
                                    </tr>--%>

                            <h4 class="subtitulo-form">
                                <label>Hechos de Salud</label></h4>


                            <table class="table table-bordered table-condensed">

                                <tr>
                                    <%-- <td class="texto_form" width="30%">
                                                        Fecha&nbsp;
                                                    </td>--%>
                                    <th class="titulo-tabla col-md-1" scope="row">Fecha *</th>

                                    <td class="col-md-5">

                                        <asp:TextBox ID="cal001" class="form-control form-control-fecha-large input-sm" runat="server" ValidationGroup="grupo1" placeholder="dd-mm-aaaa" />

                                    </td>
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende889" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal001" ErrorMessage="Fecha Requerida" CssClass="help-block" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo1" />


                                    <%--<td class="texto_form" style="height: 24px">Hecho de Salud</td>--%>
                                    <th class="titulo-tabla col-md-1" scope="row">Hecho de Salud *</th>

                                    <td>
                                        <%--<span class="texto_rojo_peque">--%>
                                        <asp:DropDownList ID="ddown001" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList>
                                        <%--</span>--%>

                                    </td>
                                </tr>

                                <tr>
                                    <%--<td class="texto_form">Atención</td>--%>
                                    <th class="titulo-tabla" scope="row">Atención *</th>

                                    <td>
                                        <%--<span class="texto_rojo_peque">--%>
                                        <asp:DropDownList ID="ddown002" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList>

                                        <%--</span>--%>

                                    </td>

                                    <%--<td class="texto_form">Lugar</td>--%>
                                    <th class="titulo-tabla" scope="row">Lugar *</th>
                                    <td>
                                        <asp:DropDownList ID="ddown003" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>

                                <tr>
                                    <%--<td class="texto_form">Tenico</td>--%>
                                    <th class="titulo-tabla" scope="row">Técnico *</th>
                                    <td>
                                        <asp:DropDownList ID="ddown004" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList></td>

                                    <%--<td class="texto_form">Observaciones</td>--%>
                                    <th class="titulo-tabla" scope="row">Observaciones</th>
                                    <td>
                                        <swtb:SenameTextBox ID="txt001" runat="server" class="form-control input-sm" MaxLength="100" TextMode="MultiLine" placeholder="Ingresa tus observaciones"></swtb:SenameTextBox></td>
                                </tr>

                            </table>




                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <div class="botonera pull-right">
                        <asp:LinkButton class="btn btn-danger btn-sm fixed-width-button" ID="btn001" runat="server" OnClick="btn001_Click" ValidationGroup="grupo1">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar
                        </asp:LinkButton>
                        <%--<asp:Button class="btn btn-info btn-sm" ID="btn002" runat="server" OnClick="btn002_Click" Text="Cerrar" CausesValidation="False" />--%>
                        <%--    <button >Agregar Nuevo Hecho de Salud</button><button >Cerrar</button>--%>
                    </div>
                </form>

            </div>
        </div>
    </div>

</body>
</html>
