<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_Estadistico.aspx.cs" Inherits="mod_reportes_Rep_Estadistico" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Reportes :: SenaInfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     
            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">

                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li><a href="#">Reportes</a>            </li>
                        <li class="active">Reportes Estadísticos</li>
                    </ol>

                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

                                    <asp:Label ID="lbl_error" runat="server" Text="No existe ningun Pdf Activo en Este Mes"
                                        Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Reporte Estadístico</h4>
                        <hr />
                        <%--  <asp:Label ID="Label1" runat="server" Text="Reporte Estadístico" ForeColor="Navy"></asp:Label><br />--%>
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">
                                                Período:</label>
                                        </th>
                                        <td>
                                            <div class="col-md-6 no-padding">
                                                <asp:DropDownList ID="ddl_año" placeholder="año" runat="server" AutoPostBack="True" CssClass="form-control  input-sm" OnSelectedIndexChanged="ddl_año_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-6 no-padding">
                                                <asp:DropDownList ID="ddl_mes" runat="server" placeholder="mes" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddl_mes_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>


                                        </td>

                                    </tr>
                                </table>

                            </div>

                            <div class="col-md-3">
                                <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Seleccione el período y luego el reporte que desea consultar."></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12">
                            <asp:GridView ID="dtgv_pdf" runat="server" CssClass="table table-bordered table-hover" OnRowCommand="gv_pdf_RowCommand">
                                <Columns>
                                    <asp:ButtonField HeaderText="Ver" Text="Ver"  />
                                </Columns>
                                <PagerTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" />

                                </PagerTemplate>
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <HeaderStyle CssClass="titulo-tabla table-borderless " />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                <RowStyle CssClass="caja-tabla table-bordered" />
 
                            </asp:GridView>
                            </div>

                        </div>
                    </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
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
