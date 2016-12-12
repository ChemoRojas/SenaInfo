<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetallePII.aspx.cs" Inherits="mod_buscador_DetallePII" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante_buscador.ascx" TagPrefix="uc1" TagName="menu_colgante_buscador" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Buscador de NNA :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/ventanas-modales.css" rel="stylesheet" />
    <!-- Dependencias para calendarios -->
    <script src="../js/jquery-1.10.2.min.js"></script>
    <script src="../js/bootstrap-datepicker.js"></script>
    <link href="../css/bootstrap-datepicker.css" rel="stylesheet" />
    <!-- Dependencias para DropDownList -->    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.11.2/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.11.2/css/bootstrap-select.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.11.2/js/i18n/defaults-*.min.js"></script>
    <!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="frmAsignaPro" runat="server">

        <uc1:menu_colgante_buscador runat="server" ID="menu_colgante_buscador" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

                <div>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Búsqueda de NNA</li>
                            <li class="active">Información del NNA</li>
                            <li class="active">Ver PII</li>
                        </ol>
                        
                        <div class="well">

                            <h4 class="subtitulo-form">Ingreso de intervención del caso</h4>
                            <hr>


                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th class="col-md-3">
                                                <label for="">Fecha de Ingreso al Centro o Proyecto</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="datepicker" data-style="btn-info"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Encargado o delegado del Caso</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList1" CssClass="selectpicker show-menu-arrow" data-style="btn-info" data-live-search="true" data-width="auto" runat="server">

                                                        <asp:ListItem>Luis Perez</asp:ListItem>

                                                        <asp:ListItem>Juan Perez</asp:ListItem>

                                                        <asp:ListItem>Pedro Perez</asp:ListItem>

                                                        <asp:ListItem>Maria Perez</asp:ListItem>

                                                        <asp:ListItem>Claudia Perez</asp:ListItem>

                                                        <asp:ListItem>Marcela Perez</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">PIC</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList2" CssClass="selectpicker show-menu-arrow" data-style="btn-info" data-live-search="true" data-width="auto" runat="server">

                                                        <asp:ListItem>Luis Perez</asp:ListItem>

                                                        <asp:ListItem>Juan Perez</asp:ListItem>

                                                        <asp:ListItem>Pedro Perez</asp:ListItem>

                                                        <asp:ListItem>Maria Perez</asp:ListItem>

                                                        <asp:ListItem>Claudia Perez</asp:ListItem>

                                                        <asp:ListItem>Marcela Perez</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">ETD</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList3" CssClass="selectpicker show-menu-arrow" data-style="btn-info" data-live-search="true" data-width="auto" runat="server">

                                                        <asp:ListItem>Luis Perez</asp:ListItem>

                                                        <asp:ListItem>Juan Perez</asp:ListItem>

                                                        <asp:ListItem>Pedro Perez</asp:ListItem>

                                                        <asp:ListItem>Maria Perez</asp:ListItem>

                                                        <asp:ListItem>Claudia Perez</asp:ListItem>

                                                        <asp:ListItem>Marcela Perez</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">TO</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList4" CssClass="selectpicker show-menu-arrow" data-style="btn-info" data-live-search="true" data-width="auto" runat="server">

                                                        <asp:ListItem>Luis Perez</asp:ListItem>

                                                        <asp:ListItem>Juan Perez</asp:ListItem>

                                                        <asp:ListItem>Pedro Perez</asp:ListItem>

                                                        <asp:ListItem>Maria Perez</asp:ListItem>

                                                        <asp:ListItem>Claudia Perez</asp:ListItem>

                                                        <asp:ListItem>Marcela Perez</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">CF</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList5" CssClass="selectpicker show-menu-arrow" data-style="btn-info" data-live-search="true" data-width="auto" runat="server">

                                                        <asp:ListItem>Luis Perez</asp:ListItem>

                                                        <asp:ListItem>Juan Perez</asp:ListItem>

                                                        <asp:ListItem>Pedro Perez</asp:ListItem>

                                                        <asp:ListItem>Maria Perez</asp:ListItem>

                                                        <asp:ListItem>Claudia Perez</asp:ListItem>

                                                        <asp:ListItem>Marcela Perez</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Ejecuta Primera Encuesta</label>
                                            </th>
                                            <td>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownList6" CssClass="selectpicker show-menu-arrow" data-style="btn-info" data-live-search="true" data-width="auto" runat="server">

                                                        <asp:ListItem>Luis Perez</asp:ListItem>

                                                        <asp:ListItem>Juan Perez</asp:ListItem>

                                                        <asp:ListItem>Pedro Perez</asp:ListItem>

                                                        <asp:ListItem>Maria Perez</asp:ListItem>

                                                        <asp:ListItem>Claudia Perez</asp:ListItem>

                                                        <asp:ListItem>Marcela Perez</asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <!--gfontbrevis modal institucion -->
                                </div>
                                <!--cierra col-md-9-->

                            </div>

                            <div class="row">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td class="col-md-3"></td>

                                    </tr>
                                </table>

                            </div>
                            <!-- cierra row-->
                            <br>
                            
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
<script type="text/javascript">
    $(document).ready(function () {
        $(".datepicker").datepicker({ format: 'dd/mm/yyyy', autoclose: true, todayBtn: 'linked' })
    });
    $(document).ready(function () {
        $(".selectpicker").selectpicker();
    });
</script>

