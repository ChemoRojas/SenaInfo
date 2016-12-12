<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abre_mes.aspx.cs" Inherits="mod_mesa_Abre_mes" %>
<%@ Register Src="~/SenainfoSdk/C_seleccionIcodie.ascx" TagPrefix="uc1" TagName="C_seleccionIcodie" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="sbtb" %>
<%@ Register Src="~/SenainfoSdk/C_buscar_x_institu_proyecto.ascx" TagPrefix="uc1" TagName="C_buscar_x_institu_proyecto" %>
<%@ Register Src="~/SenainfoSdk/C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>
<%@ Register Src="~/SenainfoSdk/C_modalPopUp.ascx" TagPrefix="uc1" TagName="C_modalPopUp" %>
<script runat="server">
</script>
<html  lang="es">
<head id="Head1" runat="server">
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico"> 
    <title>Mesa de Ayuda - Senainfo :: SERVICIO NACIONAL DE MENORES </title>

    
    <script src="../js/jquery-1.11.1.min.js"></script>
    <%--<script src="../js/jquery-1.10.2.js"></script>--%>
   <link rel="stylesheet" href="../css/jquery-ui.css">
    <script src="../js/jquery-ui.js"></script>
        <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">

    <link href="../css/theme.css" rel="stylesheet">
       <script src="../js/jquery.Rut.js"></script>
   <script src="../js/jquery-2.1.4.js"></script>
   <script src="../js/jquery-2.1.4.min.js"></script>
   <script src="../js/jquery-ui.js"></script>
   <script src="../js/senainfoTools.js"></script>
   <script src="../js/ie-emulation-modes-warning.js"></script>
   <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
   <link rel="stylesheet" type="text/css" href="../css/jquery.maxlength.css">
   <script src="../js/jquery.plugin.js"></script>
   <script src="../js/jquery.maxlength.js"></script>
      <script src="../js/jquery.Rut.js"></script>
        <script type="text/javascript">
            function LoadScript() {
                $(document).ready(function () {
                    //function
                    SetProgressPosition();
                    $("#txt_comentarios").maxlength({ max: 100 });
                });
            }
            LoadScript();

            function funcionsuma() {
                if (trim(document.getElementById("txt003").value) == "") {
                    a = 0;
                } else {
                    a = parseInt(trim(document.getElementById("txt003").value));
                }
                if (trim(document.getElementById("txt004").value) == "") {
                    b = 0;

                } else {
                    b = parseInt(trim(document.getElementById("txt004").value));
                }
                if (trim(document.getElementById("txt005").value) == "") {
                    c = 0;
                }
                else {
                    c = parseInt(trim(document.getElementById("txt005").value));
                }

                if (trim(document.getElementById("txt006").value) == "") {
                    d = 0;
                } else {
                    d = parseInt(trim(document.getElementById("txt006").value));
                }

                var textoprop = a + b + c + d;

                //alert(textoprop);
                document.getElementById("txt002").value = textoprop.toString();

            }
            function trim(str) {
                str = str.toString();
                while (1) {
                    if (str.substring(0, 1) != " ") {
                        break;
                    }
                    str = str.substring(1, str.length);
                }
                while (1) {
                    if (str.substring(str.length - 1, str.length) != " ") {
                        break;
                    }
                    str = str.substring(0, str.length - 1);
                }
                return str;
            }

            function AcceptNum(evt) {
                var nav4 = window.Event ? true : false;
                var key = nav4 ? evt.which : evt.keyCode;
                return (key <= 13 || (key >= 48 && key <= 57) || key == 44);
            }
            function f_SoloNumeros() {
                var key = window.event.keyCode;
                if (key < 48 || key > 57) {
                    window.event.keyCode = 0;
                }
            }

    </script>
    
     
    </head>
<body  role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(LoadScript);
                </script>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Mesa de Ayuda</li>
                        <li class="active">Abrir Mes</li>
                    </ol>

                    <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
                    <br />
                    <uc1:C_modalPopUp runat="server" ID="C_modalPopUp" OnResultadoPopup="C_modalPopUp_ResultadoPopup" />
                    <div class="well">
                        <h4 class="subtitulo-form">Mesa de Ayuda Abre Mes</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-bordered table-condensed">
                                    <uc1:C_buscar_x_institu_proyecto runat="server" ID="C_buscar_x_institu_proyecto" OnCodProyectoSeleccionadoCambio="C_buscar_x_institu_proyecto1_CodProyectoSeleccionadoCambio" UsarTabla="false" />
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Mes *</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_mes" runat="server" AutoPostBack="True" class="form-control form-control-fecha-large input-sm">
                                                <asp:ListItem Value="01">Enero</asp:ListItem>
                                                <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                                <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                <asp:ListItem Value="06">Junio</asp:ListItem>
                                                <asp:ListItem Value="07">Julio</asp:ListItem>
                                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Año *</th>
                                        <td>
                                            <div>
                                                <asp:DropDownList ID="ddl_anios" runat="server" AutoPostBack="True" class="form-control form-control-fecha-large input-sm">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Comentario*          </th>
                                        <td>
                                            <div>
                                                <asp:TextBox ID="txt_comentarios" runat="server" Height="71px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th></th>
                                        <td>
                                            <br />

                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_ejecutar" runat="server" OnClick="btn_ejecutar_Click">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Ejecutar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnlimpiar" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btnlimpiar_Click">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>

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
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados."></asp:Label>
                                    </div>
                                </div>

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


    </form>
      <footer class="footer" aria-hidden="False">
          <div class="container">
              <p>
                  Para tus dudas y consultas, escribe a:
                            <br>
                  mesadeayuda@sename.cl
              </p>
          </div>
                    </footer>
                </div>
</body>
</html>
