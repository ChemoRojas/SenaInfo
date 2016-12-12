<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index_ReporteDatosGestion.aspx.cs" Inherits="mod_reportes_Index_ReporteDatosGestion" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>



<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Reportes :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>

    <script type="text/javascript">

        function carga() {
            var down = window.document.getElementById("ddown001");
            var iframe = window.document.getElementById("gestion");
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

        <asp:ScriptManager ID="ScripManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="ddown001" />
            </Triggers>
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <!--<li><a href="#">Home</a></li>-->
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li><a href="#">Reportes </a></li>
                        <li class="active">Reportes Datos Gestión </li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Reportes Datos de Gestión</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">Tipo de Reporte :</label></th>
                                        <td>

                                            <asp:DropDownList ID="ddown001" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Value="Rep_Diligencias.aspx" Selected="True">Reporte de Diligencias</asp:ListItem>
                                                <asp:ListItem Value="Rep_PersonasRelacionadas.aspx?Param01=0">Reporte de Personas Relacionadas</asp:ListItem>
                                                <asp:ListItem Value="Rep_PersonaContacto.aspx">Reporte Persona de Contacto</asp:ListItem>
                                                <asp:ListItem Value="Rep_PersonasRelacionadas.aspx?Param01=1">Reporte de Personas Relacionadas CUIDADORAS</asp:ListItem>
                                                <asp:ListItem Value="Rep_PersonasRelacionadas.aspx?Param01=2">Reporte de Personas Relacionadas Detalle</asp:ListItem>
                                            </asp:DropDownList>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-3">
                                   <!-- Panel de informacion va en los iframes -->


                                </div>
                        </div>
                          <iframe id="gestion" src="Rep_Diligencias.aspx" frameborder="0" scrolling="auto" height="100%" width="100%"></iframe>
                     
                    </div>
                </div>
                   </ContentTemplate>
        </asp:UpdatePanel>
         
         
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel">
            <ProgressTemplate>

                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
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
