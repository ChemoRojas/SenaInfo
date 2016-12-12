<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_Catastro.aspx.cs" Inherits="Reportes_Rep_Catastro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<html lang="es">

<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../img/favicon.ico">
    <title>Reportes :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>



</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
            </Triggers>
            <ContentTemplate>
                <div>
                    <uc1:menu_colgante runat="server" ID="menu_colgante" />
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A2" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a id="A1" href="~/index.aspx" runat="server">Reportes</a></li>

                            <li class="active">Reportes de Catastro</li>

                        </ol>
                        <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                            <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reporte Catastro Jueces</h4>
                            <hr>
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Fecha Vigencia:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="cal_inicio" runat="server" CssClass="form-control form-control-fecha-large input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" /> 
                                                <Ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_inicio" ValidChars="0123456789-/" />
                                                <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ControlToValidate="cal_inicio" CssClass="help-block" Display="Dynamic" OnInit="rv_fecha_Init" ErrorMessage="Fecha Invalida" Type="Date" ValidationGroup="valError" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal_inicio" ErrorMessage="" CssClass="help-block" Display="Dynamic" ValidationGroup="FechaDiag"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>

                                                <asp:LinkButton ValidationGroup="valError" CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_buscar" runat="server" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar</asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click" CausesValidation="False"><span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar</asp:LinkButton>


                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <!--fin col-md-9 -->
                                <div class="col-md-3">

                                    <div class="panel-info panel-primary-info">
                                        <div class="panel-heading">
                                            Información
                                        </div>
                                        <div class="panel-footer">
                                            <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados para generar el reporte."></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!--cierra Row-->
                            <!--Row para desplegar tabla con datos-->



                        </div>
                    </div>

                </div>
                <asp:ValidationSummary ValidationGroup="valError" ID="ValidationSummary1" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <footer class="footer">
            <div class="container">
                <p>
                    Para tus dudas y consultas, escribe a:
                <br>
                    mesadeayuda@sename.cl
                </p>
            </div>
        </footer>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel">
            <ProgressTemplate>

                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
