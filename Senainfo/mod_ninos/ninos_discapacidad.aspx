<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_discapacidad.aspx.cs" Inherits="mod_ninos_discapacidad" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<html lang="es">
<head  runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Discapacidad</title>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet"> 
       
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery-ui.js"></script> 

     
    <script type="text/javascript">

        function RefrescaPadre() {
            //alert('RefrescaPadre');
            window.parent.MFref_AgrDis();
            window.parent.close();

        };
        //function CerrarModalPopUp() {
        //    parent.location.reload();
        //}

        //function AbrirURLModalPopUp(url) {
        //    parent.location.replace(url);
        //}
    </script>

</head>
<body class="body-form">
  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <Triggers>
        <%--<asp:PostBackTrigger ControlID="btn001" />--%>
      </Triggers>
      <ContentTemplate> 
        <div class="container">
          <div class="row">
            <div class="caja-tabla">
              <p class="titulo-form">Detalles Discapacidad</p>
                <table class="table table-bordered  table-condensed">
                  <tbody>
                    <tr>
                      <th class="titulo-tabla col-md-1" scope="row">Fecha</th>
                      <td class="col-md-4">
                        <asp:TextBox ID="cal001" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"/>
                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende782" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cal001" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true"  ControlToValidate="cal001" CssClass="help-block" Display="Dynamic" runat="server" ErrorMessage="Fecha Inv&aacute;lida" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="grupo1" />
                      </td>
                   
                      <th class="titulo-tabla col-md-1" scope="row">Tipo de Discapacidad*</th>
                      <td class="col-md-4">
                        <asp:DropDownList ID="ddown001" CssClass="form-control input-sm"  runat="server" AppendDataBoundItems="True">
                          <asp:ListItem Selected="True" Value="0">Seleccionar 
                          </asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <th class="titulo-tabla" scope="row">Nivel *</th>
                      <td>
                        <asp:DropDownList ID="ddown002"  CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                          <asp:ListItem Selected="True" Value="0">Seleccionar 
                          </asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    
                      <th class="titulo-tabla" scope="row">Incrito(a)FONADIS</th>
                      <td>
                        <asp:CheckBox ID="chk001" runat="server" AutoPostBack="True" OnCheckedChanged="chk001_CheckedChanged" />
                        <asp:TextBox ID="cal004" CssClass="form-control form-control-fecha-large input-sm" runat="server" Enabled="False" placeholder="dd-mm-aaaa" />
                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende793"  runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal004" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                        <asp:RangeValidator ID="RangeValidator793" CssClass="help-block" Display="Dynamic" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal004" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />
                      </td>
                    </tr>
                    <tr>
                      <th class="titulo-tabla" scope="row">Técnico *</th>
                      <td>
                        <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                          <asp:ListItem Selected="True" Value="0">Seleccionar 
                          </asp:ListItem>
                        </asp:DropDownList>
                      </td>
                   
                      <th class="titulo-tabla" scope="row">Observaciones</th>
                      <td>
                        <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server" MaxLength="100" placeholder="Ingresa tus observaciones" TextMode="MultiLine"></asp:TextBox>
                      </td>
                    </tr>
                  </tbody>
                </table>
                <asp:Label ID="Lbl002" runat="server" Text="El Formulario Posee Datos Nulos" Visible="False"></asp:Label>
              <div class="botonera pull-right">
                <asp:LinkButton CssClass="btn btn-danger btn-sm" ID="btn001" runat="server" OnClick="btn001_Click"  ValidationGroup="grupo1">
                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Nueva Discapacidad
                </asp:LinkButton>
                <%--<asp:Button CssClass="btn btn-info btn-sm" ID="btn002" runat="server" OnClick="btn002_Click" Text="Cerrar" CausesValidation="False" />--%>
                  
              </div>
            </div>
          </div>
        </div>  
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
      <ProgressTemplate>
        <%--<div class="UpdateProgress">
          <img alt="Cargando" height="70" src="../images/Cursors/ajax-loader.gif" width="70" />
          Cargando...       
        </div>--%>
      </ProgressTemplate>
    </asp:UpdateProgress>
      
</form>

    

     <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../js/ie10-viewport-bug-workaround.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://code.jquery.com/jquery-latest.js"></script>
</body>
</html>