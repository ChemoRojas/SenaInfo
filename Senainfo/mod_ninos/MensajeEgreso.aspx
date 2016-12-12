<%@ Page Language="C#" Culture="es-CL" UICulture="es"    AutoEventWireup="true" CodeFile="MensajeEgreso.aspx.cs" Inherits="mod_ninos_MensajeEgreso" %>

<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>### Egreso ### :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script> 
    <script src="../js/bootstrap.min.js"></script> 
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <%--<script src="../js/ventanas-modales.js"></script>--%>

    <script src="../js/jquery-ui.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script  type="text/javascript">

        function CerrarFancybox() {
            parent.$.fancybox.close();
             };

        function AbrirURLModalPopUp(url) {
            //$.blockUI.defaults.message = '<img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />';
            //$.blockUI();

            parent.location.replace(url);
        }

        //function AbrirURLModalPopUp(url) {

        //    window.open(url,'_blank');
        //}

    </script>
</head>
<body class="body-form">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1"  runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
            </Triggers>
            <ContentTemplate>
    <div class="container-modal">
        <div class="modal-body">
            <form>
                <table class="table table-bordered table-modal" style="width:100%" >
                    <tbody>
                        <tr>
                            <th class="tit-tabla-modal" scope="row">
                                <asp:Label ID="lbl_nino" runat="server"></asp:Label></th>
                        </tr>
                        <tr>
                            <td class="alert alert-warning"><span class="glyphicon glyphicon-alert" aria-hidden="true"></span>
                                El niño/a seleccionado no puede ser egresado, primero debe cerrar lo que se indica:
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ul class="listado-diligencias" id="li_pendiente" runat="server">
                                </ul>
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