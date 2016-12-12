<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editarHerramienta.aspx.cs" Inherits="mod_mantenedores_editarHerramienta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Registro de Inmuebles :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function SetProgressPosition(e) {
            var posx = 0;
            var posy = 0;
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                posx = e.pageX;
                posy = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                posx = e.clientX + document.documentElement.scrollLeft;
                posy = e.clientY + document.documentElement.scrollTop;
            }

            document.getElementById('divProgress').style.top = posy + "px";
        }





        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press
            }
        }

        function limpiarForm() {
            window.location = "editarHerramienta.aspx"
        }


        function volver() {
            window.location = "Mant_Herramientas.aspx"
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>

                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>Faltan datos obligatorios para realizar el registro.
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>Datos de la Herramienta Modificados satisfactoriamente.
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos de la Herramienta Modificados satisfactoriamente." Visible="false">Datos de la Herramienta registrados satisfactoriamente.</asp:Label>
                    </div>
                    <div class="well" id="grabar" visible="true" runat="server">
                        <h4 class="subtitulo-form">Herramientas</h4>


                        <table class="table table-bordered  table-condensed">
                            <tr>
                                <th class="titulo-tabla" scope="row">Nombre de la Herramienta *</th>
                                <td colspan="3" class="col-md-8">
                                    <asp:TextBox ID="txtNombreHerramienta" runat="server" MaxLength="100" CssClass="form-control input-sm" placeholder="Ingrese nombre de la herramienta"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Descripción de la Herramienta *</th>
                                <td colspan="3" class="col-md-8">
                                    <asp:TextBox ID="txtDescripcionHerramienta" runat="server" MaxLength="500" CssClass="form-control input-sm" placeholder="Ingrese nombre de la herramienta"></asp:TextBox>
                                </td>

                            </tr>
                            
                            
                            <asp:TextBox ID="txtVigencia" runat="server" MaxLength="100" CssClass="form-control input-sm" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtCodHerramienta" runat="server" MaxLength="100" CssClass="form-control input-sm" Visible="false"></asp:TextBox>

                        </table>
                        <br />
                        <br />
                        <br />
                        <div class="botonera pull-right">


                            <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton2" runat="server" Text="Limpiar" OnClick="WebImageButton2_Click" />--%>
                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" runat="server" OnClientClick="limpiarForm();">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                            </asp:LinkButton>
                            <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton3" runat="server" Text="Volver" OnClick="WebImageButton3_Click" />--%>
                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton1" runat="server" OnClick="WebImageButton1_Click">
                                                   <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                            </asp:LinkButton>

                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="volver" runat="server" OnClientClick="volver();">
                                                   <span class="glyphicon glyphicon-chevron-left"></span>&nbsp;Volver
                            </asp:LinkButton>
                        </div>

                    </div>

                </div>
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
</body>
</html>
