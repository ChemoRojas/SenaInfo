<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_enfermedadescronicas.aspx.cs" Inherits="mod_ninos_enfermedadescronicas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<html lang="es">
<head  runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Enfermedades Crónicas</title>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet"> 
   
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script> 

     
    <script  type="text/javascript">
   
        function RefrescaPadre() {
            window.parent.MFref_EnfCro();
        };

    </script>
</head>
<body class="body-form">
  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <Triggers>
         <%-- <asp:PostBackTrigger ControlID="btn001" />--%>
          <%--<asp:PostBackTrigger ControlID="btn002" />--%>
        </Triggers>
        <ContentTemplate>
          <div class="container">
            <div class="row">
              <div class="col-md-12 caja-tabla">
                <form>
                  <h4 class="subtitulo-form"><label>Enfermedades Crónicas</label></h4>
                  <table class="table table-bordered table-col-fix table-condensed">
                    <tbody>
                      <tr>
                        <th class="titulo-tabla" scope="row">Fecha de Inicio del Diagnóstico *</th>
                        <td>                         
                          <asp:TextBox ID="cal001" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" TextMode="SingleLine" ReadOnly="false"></asp:TextBox>
                          <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender_cal001" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="cal001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal001" Display="Dynamic" CssClass="help-block" ErrorMessage="Fecha Requerida" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inv&aacute;lida" Display="Dynamic" CssClass="help-block" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo1" />
                        </td>
                      </tr>
                      <tr>
                        <th class="titulo-tabla" scope="row">Enfermedad *</th>
                        <td>
                          <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                          </asp:DropDownList>
                        </td>
                      </tr>
                      <tr>
                        <th class="titulo-tabla" scope="row">Técnico *</th>
                        <td>
                          <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                          </asp:DropDownList>
                        </td>
                      </tr>
                      <tr>
                        <th class="titulo-tabla" scope="row">Observaciones</th>
                        <td>
                          <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server" placeholder="Ingresa tus observaciones" TextMode="MultiLine"></asp:TextBox>
                        </td>
                      </tr>
                    </tbody>
                  </table>
	              </form>
                <div class="botonera pull-right">
                  <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn001" runat="server" OnClick="btn001_Click" ValidationGroup="grupo1" >
                      <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar
                  </asp:LinkButton>
                  <%--<asp:Button CssClass="btn btn-info btn-sm" ID="btn002" runat="server" Text="Cerrar" OnClick="btn002_Click" CausesValidation="False" />--%>
                </div>
              </div>
            </div>
          </div>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../js/ie10-viewport-bug-workaround.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://code.jquery.com/jquery-latest.js"></script>
        </ContentTemplate>
      </asp:UpdatePanel>
  </form>
</body>
</html>