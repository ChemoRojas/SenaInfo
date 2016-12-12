<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modal.aspx.cs" Inherits="modal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<!DOCTYPE html>
<html lang="es">
<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Modal :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">
    <link href="css/ventanas-modales.css" rel="stylesheet" />

    <style>
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="sm1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" runat="server"
                    TargetControlID="LinkButton1"
                    PopupControlID="modal_hola"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <%--<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default" OnClick="LinkButton1_Click">Levantar ModalPopUp</asp:LinkButton>--%>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default">Levantar ModalPopUp</asp:LinkButton>

                <div class="popupConfirmation" id="modal_hola" style="display: none">
                    <iframe id="iframe_hola" src="mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../modal.aspx" width="800px" height="600px" runat="server"></iframe>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
            <ProgressTemplate>
                <div style="position: absolute; top: 45%; left: 42%; right: 0; bottom: 0;">
                    <img alt="Cargando" src="images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>




    </form>
</body>
</html>

