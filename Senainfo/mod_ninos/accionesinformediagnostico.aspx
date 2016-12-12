<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="accionesinformediagnostico.aspx.cs" Inherits="accionesinformediagnostico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Datos de Gestion - Senainfo :: Sename</title>
   
      <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet"> 
   
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script> 

    <!-- originales -->
    <script src="../Script/jquery.min.js"></script> 
    <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script src="../Script/jquery-1.4.3.min.js"></script>
  
    <script type="text/javascript">

        function RefrescaPadre() {
            window.parent.MFref_AccInf();
        };

    </script>
</head>
<body class="body-form">
    <div class="container">
        <div class="row">
            <div class="col-md-12 caja-tabla">
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Always">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnLimpiar" />
                            <%--<asp:PostBackTrigger ControlID="btnsalir" />--%>
                            <asp:PostBackTrigger ControlID="btn001" />
                        </Triggers>
                        <ContentTemplate>
                            <h4 class="subtitulo-form">Acciones Informe Diagnostico</h4>

                            <table class="table table-bordered table-col-fix table-condensed">
                                <tbody>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Fecha de Acción</th>
                                        <td>

                                            <asp:TextBox ID="cal001" CssClass="form-control form-control-40 input-sm" runat="server" placeholder="dd-mm-aaaa" />
                                            <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende339" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" DaysModeTitleFormat="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Tipo de Acción</th>
                                        <td>
                                            <span class="texto_rojo_peque">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </span></td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Tecnico</th>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                        <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Observaciones</th>
                                        <td>
                                            <swtb:SenameTextBox ID="txt001" CssClass="form-control input-sm" runat="server" MaxLength="100" TextMode="MultiLine"></swtb:SenameTextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" UpdatePanel11="UpdatePanel11">
                        <ProgressTemplate>
                            <div style="position: absolute; top: 40%; left: 45%; right: 0; bottom: 0;">
                                <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                                Cargando...       
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="botonera pull-right">
                        <asp:Button CssClass="btn btn-info btn-sm btn-ancho-100" ID="btn001" runat="server" OnClick="btn001_Click" Text="Agregar Acciones" />
                        <asp:Button CssClass="btn btn-info btn-sm btn-ancho-100" ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
                        <%--<asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnsalir" runat="server" OnClick="btnsalir_Click" Text="Cerrar" CausesValidation="False" />--%>
                    </div>
                </form>
            </div>
        </div>
    </div>
    
</body>
</html>
