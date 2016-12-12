<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_ReportesLRPA.aspx.cs" Inherits="mod_reportes_Rep_Diag_Ninos_Rep_ReportesLRPA" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head id="Head1" runat="server">
    <title>Reporte :: Senainfo :: Servicio Nacional de Menores</title>
    <link rel="icon" href="../images/favicon.ico">

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/senainfoTools.js"></script>
    <script type="text/javascript">

        function carga() {
            var down = window.document.getElementById("ddown001");
            var iframe = window.document.getElementById("LRPA");
            var link = down.value;
            if (link == 0) {
                iframe.src = '';
            }
            else {
                iframe.src = link;
            }
        }
    </script>


</head>

<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div>
                    <div>
                        <div class="container theme-showcase" role="main">
                            <ol class="breadcrumb">
                                <!--<li><a href="#">Home</a></li>-->
                                <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                                <li><a href="#">Reportes</a>            </li>
                                <li class="active">Reportes LRPA</li>
                            </ol>
                            <div class="well">
                                <h4 class="subtitulo-form">Reportes LRPA</h4>

                                <hr>
                                <div class="row">
                                    <div class="col-md-9">
                                        <form class="form-horizontal" action="">
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <th>
                                                        <label for="">Tipo de Reporte:</label>
                                                    </th>
                                                    <td>

                                                        <asp:DropDownList CssClass="form-control input-sm" ID="ddown001" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                            <asp:ListItem Value="Rep_OcupacionDiariaCentros.aspx" Selected="True">Ocupaci&#243;n Diaria Centros AA.DD.</asp:ListItem>
                                                            <asp:ListItem Value="Rep_NominaAdolescente.aspx">N&#243;mina de Adolescentes</asp:ListItem>
                                                            <asp:ListItem Value="Rep_VigenciaDiariaCentros.aspx">Vigencia Diaria AA.DD.</asp:ListItem>
                                                            <asp:ListItem Value="Rep_InfraccionDisciplinaria.aspx">Nómina de infracciones disciplinarias</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_buscar" runat="server" OnClick="btnBuscar_NEW_Click" Visible="False"><span class="glyphicon glyphicon-zoom-in"></span> Buscar</asp:LinkButton>


                                                        <asp:LinkButton ID="btn_limpiar" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btnLimpiar_NEW_Click" Visible="False"><span class="glyphicon glyphicon-remove-sign"></span> Limpiar</asp:LinkButton>

                                                    </td>
                                                </tr>
                                            </table>
                                        </form>
                                        <!--fin botones -->
                                    </div>

                                    <div class="col-md-3">

                                    
                                    </div>

                                </div>

                                <iframe id="LRPA" src="Rep_OcupacionDiariaCentros.aspx" frameborder="0" scrolling="auto" height="100%" width="100%"></iframe>

                            </div>
                    </div>
                </div>
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
