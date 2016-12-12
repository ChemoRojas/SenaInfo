﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abrir_plan_Intervencion.aspx.cs" Inherits="mod_mesa_Abrir_plan_Intervencion" %>

<%@ Register src="~/SenainfoSdk/C_seleccionIcodie.ascx" tagname="C_seleccionIcodie" tagprefix="uc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<%@ Register src="~/SenainfoSdk/C_codplanIntervencion.ascx" tagname="C_codplanIntervencion" tagprefix="uc1" %>
<%@ Register Src="~/SenainfoSdk/C_msgAlerta.ascx" TagPrefix="uc1" TagName="C_msgAlerta" %>
<%@ Register Src="~/SenainfoSdk/C_modalPopUp.ascx" TagPrefix="uc1" TagName="C_modalPopUp" %>




<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico"> 
    <title>Mesa de Ayuda - Senainfo :: SERVICIO NACIONAL DE MENORES </title>
    <script src="../js/jquery-1.11.1.min.js"></script>
    <%--<script src="../js/jquery-1.10.2.js"></script>--%>
   <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
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
                $("#txt_comentario").maxlength({ max: 100 });
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
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
         <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          <script type="text/javascript">
              Sys.Application.add_load(LoadScript);
                </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
             
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Mesa de Ayuda</li>
                        <li class="active">Abrir Plan de Intervención</li>
                    </ol>

                    <uc1:C_msgAlerta runat="server" ID="C_msgAlerta" />
                    <br />
                    <uc1:C_modalPopUp runat="server" ID="C_modalPopUp" OnResultadoPopup="C_modalPopUp_ResultadoPopup" />
                    <div class="well">
                        <h4 class="subtitulo-form">Mesa de Ayuda Abrir Plan de Intervención</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-bordered table-condensed">
                                    <uc1:C_codplanIntervencion ID="C_codplanIntervencion1" runat="server" UsarTabla="false" />
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Ingrese un Comentario *</th>
                                        <td>
                                            <asp:TextBox ID="txt_comentario" runat="server" Height="71px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th></th>
                                        <td>
                                            <br />
                                            <asp:LinkButton ID="btn_ejecutar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_ejecutar_Click">
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
                                        <asp:Label ID="Label1" CssClass="subtitulo-form-info" runat="server" Text="Identifique al NNA del proyecto y seleccione el código de plan de intervención que desea abrir. En el campo “comentario”, debe incorporar información relativa con el origen de la solicitud., debe incorporar información relativa con el origen de la solicitud."></asp:Label>
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
     <footer class="footer">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                        <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>
</body>
</html>
