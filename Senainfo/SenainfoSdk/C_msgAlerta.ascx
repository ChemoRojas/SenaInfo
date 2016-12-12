<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_msgAlerta.ascx.cs" Inherits="SenainfoSdk.UI.C_msgAlerta" %>

<script>
    function MostrarAlerta_<%=this.alert.ClientID%>() {
        var alerta = $('#<%=this.alert.ClientID%>');
        if ((alerta.css("visibility") == "visible") &&
            $(window).scrollTop() > alerta.offset().top + alerta.outerHeight()) {
            $('body').scrollTop(alerta.offset().top - 80);
        }
    }
    $(function () {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MostrarAlerta_<%=this.alert.ClientID%>);
    });
</script>
<div class="alert text-center" role="alert" id="alert" runat="server" style="margin-top: 10px; margin-bottom: 0px" visible="false">
    <span class="glyphicon <%= this.CssGlyphicon %>"></span>
    <asp:Label ID="lbl_alertwarning" runat="server"></asp:Label>
</div>
