<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="C_FormatRut.ascx.cs" Inherits="SenainfoSdk.UI.C_FormatRut" %>

 <asp:TextBox ID="txtCtrlRut" runat="server" placeholder="Ingresar Rut o buscar existente" 
      MaxLength="12" CssClass="form-control input-sm" /><%--AutoPostBack="true"--%>

<%--<script type="text/javascript">
       $(document).ready(function () {            
            $('#<%=this.txtCtrlRut.ClientID%>').RUT({                
                on_error: function () {
                    alert('RUT Incorrecto');
                    $('#<%=this.txtCtrlRut.ClientID%>').val('');
                    $('#<%=this.txtCtrlRut.ClientID%>').focus();
                },
                on_success: function () {
                    console.log('0 postback on_success');
                    __doPostBack('<%=this.txtCtrlRut.ClientID%>', '');
                },
                format_on: 'keyup'
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                $('#<%=this.txtCtrlRut.ClientID%>').RUT({
                    on_error: function () {
                        alert('RUT Incorrecto');
                        $('#<%=this.txtCtrlRut.ClientID%>').val('');
                        $('#<%=this.txtCtrlRut.ClientID%>').focus();
                    },
                    on_success: function () {
                        console.log('1 postback on_success');
                        //__doPostBack('<%=this.txtCtrlRut.ClientID%>', '');
                    },
                    format_on: 'keyup'
                });
            });

       });

    function MainContent_C_FormatRut_EndRequestHandler() {
        $('#MainContent_C_FormatRut_txtCtrlRut').RUT({
            on_success: function () {
                console.log('2 postback on_success');
                __doPostBack('MainContent_C_FormatRut_txtCtrlRut', '');
            }
        })
    };

    $(function () {
        console.log('3 add_endRequest: MainContent_C_FormatRut_EndRequestHandler');
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(MainContent_C_FormatRut_EndRequestHandler);
        MainContent_C_FormatRut_EndRequestHandler();
    });

</script>--%>