<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="Elimina_falta.aspx.cs" Inherits="mod_faltas_Elimina_falta" %>

<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>### Eliminar Falta ### :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script> 
    <script src="../js/bootstrap.min.js"></script> 
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/ventanas-modales.js"></script>

    <script src="../js/jquery-ui.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script  type="text/javascript">

        function CerrarFancybox() {
            parent.$.fancybox.close();
        };

        function AbrirURLModalPopUp(url) {

            $('#UpdateProgress1').fadeIn();
            parent.location.replace(url);
        }

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

        

    </script>
</head>
<body class="body-form" onmousemove="SetProgressPosition(event)" onkeydown = "return (event.keyCode!=13)">
    <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager1"  runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="img_btn_si" />
            </Triggers>
            <ContentTemplate>
    <div class="container-modal">
        <div class="modal-body">
            <form>
                <table class="table table-bordered table-modal" style="width:100%" >
                    <tbody>
                        <tr>
                            <th class="tit-tabla-modal" scope="row">Esta a punto de borrar este registro de Infracción Disciplinaria :</th>
                        </tr>
                        <tr>
                            <td class="alert alert-warning"><span class="glyphicon glyphicon-alert" aria-hidden="true"></span>
                               Infracción Disciplinaria: <asp:Label ID="lbl_IdFalta" runat="server"></asp:Label><br />
                               Niño(a) : <asp:Label ID="lbl_nino" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="img_btn_si" CssClass="btn btn-info btn-sm" runat="server" text="Eliminar Infracción" AutoPostback="true" OnClick="img_btn_si_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_error" runat="server" CssClass="help-block" Text="No esta autorizado para esta acción." Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
        </div>
     </ContentTemplate>
     </asp:UpdatePanel>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div  id="divProgress" class="ajax_cargando">
                <img alt="Cargando" src="../images/Cursors/ajax-loader.gif"/>
                Cargando...       
            </div>
        </ProgressTemplate>
     </asp:UpdateProgress>  
   </form>  
</body>
</html>
