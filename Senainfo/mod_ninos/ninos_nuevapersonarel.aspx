<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_nuevapersonarel.aspx.cs" Inherits="mod_ninos_nuevapersonarel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>

<!DOCTYPE html>

<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Agregar Persona Relacionada</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">

        function RefrescaPadre() {
           window.parent.MFref_PerRel();
        };

        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;
            var txt;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.trim().length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;

            }

        };

   </script>
</head>

<body class="body-form">
    <div class="container">
        <div class="row">
             <div class="col-md-12 caja-tabla">

                 <form id="form1" runat="server">
                     
                     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
                     
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <Triggers>
                             <%--<asp:PostBackTrigger ControlID="btn002_2f" />--%>
                         </Triggers>

                         <ContentTemplate>
                             <div>
                                <h4 class="subtitulo-form"><asp:Label ID="lblTitulo" runat="server">Agregar Persona Relacionada</asp:Label></h4>
                                             <asp:Panel ID="pnlBuscar" runat="server" Visible="true">
                                               <%--<h4> <label class="subtitulo-form"> Buscar </label></h4>--%> 
                                                                                                               <asp:Label ID="lblb001" runat="server" CssClass="help-block"></asp:Label>

                                                             <table class="table table-bordered table-condensed" >
                                                                 <tr>
                                                                     <th class="titulo-tabla" scope="row">RUN</th>
                                                                     <td>
                                                                         <asp:TextBox ID="txtb001" runat="server" class="form-control input-sm" CausesValidation="true" MaxLength="12" />
                                                                         <asp:CustomValidator id="CustomValidatorR" runat="server" CssClass="help-block"  ControlToValidate="txtb001" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />
                                                                         <ajax:FilteredTextBoxExtender BehaviorID="valid" TargetControlID="txtb001" ValidChars="123456789-0Kk." />
                                                                         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtb001" ErrorMessage="Rut Requerido" Font-Bold="true" ForeColor="Red" ValidationGroup="grupo2"></asp:RequiredFieldValidator>--%>
                                                                         <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtb001" ErrorMessage="Rut Inválido" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)" ValidationGroup="grupo2"></asp:RegularExpressionValidator>--%>
                                                                         <asp:Panel ID="Pnl2" runat="server" BorderColor="Red" BorderStyle="Inset" BorderWidth="1px" Height="1px" HorizontalAlign="Center" Visible="False" Width="100%">
                                                                             <asp:Label ID="lbl004" runat="server" Font-Size="11px"></asp:Label>
                                                                         </asp:Panel>   
                                                                     </td>
                                                                 </tr>
                                                                 <tr>
                                                                     <th class="titulo-tabla" scope="row">Nombre</th>
                                                                     <td class="linea_inferior">
                                                                         <asp:TextBox ID="txtb002" runat="server" class="form-control form-control-80 input-sm" />
                                                                     </td>
                                                                 </tr>
                                                                 <tr>
                                                                     <th class="titulo-tabla" scope="row">Apellido Paterno</th>
                                                                     <td class="linea_inferior">
                                                                         <asp:TextBox ID="txtb003" runat="server" class="form-control form-control-80 input-sm" />
                                                                     </td>
                                                                 </tr>
                                                                 <tr>
                                                                     <th class="titulo-tabla" scope="row">Apellido Materno</th>
                                                                     <td class="linea_inferior">
                                                                         <asp:TextBox ID="txtb004" runat="server" class="form-control form-control-80 input-sm" />
                                                                     </td>
                                                                 </tr>
                                                         <tr>
                                                         <td></td><td>
                                                             <asp:LinkButton ID="btn004" runat="server" CausesValidation="false" class="btn btn-danger btn-sm fixed-width-button" OnClick="btn004_Click" ValidationGroup="grupo2" >
                                                                 <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                             </asp:LinkButton>
                                                             
                                                             <asp:LinkButton ID="btnAgregarNueva" runat="server" CausesValidation="false" class="btn btn-info btn-sm pull-right" OnClick="btnAgregarNueva_Click" >
                                                                 <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Nueva Persona

                                                             </asp:LinkButton>
                                                         </td>
                                                         </tr>
                                                      </table>
                                                 <div class="alert alert-warning text-center" role="alert" id="alert" runat="server"  style="margin-top:10px;display:none" >
                                                    <span class="glyphicon glyphicon-warning-sign">&nbsp;</span><asp:Label ID="lbl0055" runat="server" Text="Asistencia Confirmada" style="display:none" ></asp:Label>
                                                </div>
                                                <div class="alert alert-success text-center" role="alert" id="alert2" runat="server"  style="margin-top:10px;display:none">
                                                   <span class="glyphicon glyphicon-ok"></span>&nbsp; <asp:Label ID="lbl00552" runat="server" Text="Asistencia Confirmada" style="display:none" ></asp:Label>
                                                </div>   
                                                
                                                
                                                             <asp:GridView ID="grd001buscar" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered table-hover " OnRowCommand="grd001buscar_RowCommand" OnSelectedIndexChanged="grd001buscar_SelectedIndexChanged" Visible="False" Width="100%">
                                                                 <Columns>
                                                                     <asp:BoundField DataField="CodPersonaRelacionada" HeaderText="Cod Persona"><%--<ItemStyle Font-Names="Arial" Font-Size="11px" />--%></asp:BoundField>
                                                                     <asp:BoundField DataField="Rut" HeaderText="RUN"><%--<ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="50px" />--%></asp:BoundField>
                                                                     <asp:BoundField DataField="Nombres" HeaderText="Nombre"><%--<ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="60px" />--%></asp:BoundField>
                                                                     <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno"><%--<ItemStyle Font-Size="11px" HorizontalAlign="Left" />--%></asp:BoundField>
                                                                     <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"><%--<ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="110px" />--%></asp:BoundField>
                                                                     <asp:ButtonField Text="Seleccionar" HeaderText="Seleccionar">
                                                                     </asp:ButtonField>
                                                                 </Columns>
                                                                 <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                                 <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                                 <RowStyle CssClass="table-bordered caja-tabla" /> 
                                                             </asp:GridView>
                                                        
                                             </asp:Panel>
                                         
                                             <asp:Panel ID="pnlAgregar" runat="server" Visible="false">
                                                 <table class="table table-bordered table-condensed">
                                                     <tr>
                                                         <th class="titulo-tabla col-md-1" scope="row">RUN *</th>
                                                         <td class="col-md-4">
                                                             <asp:TextBox ID="txt001" runat="server" class="form-control form-control input-sm" type="text" />
                                                             <%--<asp:CustomValidator id="CustomValidator1" runat="server" CssClass="help-block"  ControlToValidate="txtb001" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />--%>
                                                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt001" runat="server" Font-Bold="true" ForeColor="Red" ErrorMessage="Rut Requerido" ValidationGroup="grupo1"></asp:RequiredFieldValidator>--%><br />
                                                             <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt001" runat="server" ErrorMessage="Rut Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^(\d{2}\d{3}\d{3})-([a-zA-Z]{1}$|\d{1}$)" ValidationGroup="grupo1"></asp:RegularExpressionValidator>--%>
                                                             <asp:CustomValidator id="CustomValidator1" runat="server" CssClass="help-block"  ControlToValidate="txt001" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />
                                                             <asp:Label ID="lbl001" runat="server" Font-Names="Arial" Font-Overline="False" Font-Size="11px"></asp:Label>
                                                             <asp:Label ID="lbl005" runat="server"  Visible="False"></asp:Label>
                                                             <asp:Label ID="lbl003" runat="server" CssClass="texto_rojo_peque" Visible="False"></asp:Label>
                                                         </td>
                                                   
                                                         <th class="titulo-tabla col-md-1" scope="row">Nombres *</th>
                                                         <td>
                                                             <asp:TextBox ID="txt002" runat="server" class="form-control form-control-80 input-sm" type="text"></asp:TextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <th class="titulo-tabla" scope="row">Apellido  Paterno *</th>
                                                         <td>
                                                             <asp:TextBox ID="txt003" runat="server" class="form-control form-control-80 input-sm" type="text"></asp:TextBox>
                                                         </td>
                                                    
                                                         <th class="titulo-tabla" scope="row">Apellido Materno</th>

                                                         <td>
                                                             <asp:TextBox ID="txt004" runat="server" class="form-control form-control-80 input-sm" type="text"></asp:TextBox></td>
                                                     </tr>

                                                     <tr>
                                                         <th class="titulo-tabla" scope="row">Sexo *</th>
                                                         <td>
                                                             <%--<span>--%><div class="text-center">
                                                             <label>
                                                                 <asp:RadioButton ID="rdo001" type="radio" runat="server" GroupName="rdosexo" />
                                                                 Mujer
                                                             </label>
                                                             <label>
                                                                 <asp:RadioButton ID="rdo002" type="radio" runat="server" GroupName="rdosexo" />
                                                                 Hombre
                                                             </label>
                                                             </div>
                                                             <%--</span>--%>
                                                         </td>
                                                    
                                                         <%--<td width="200" class="texto_form">Fecha de Nacimiento</td>--%>
                                                         <th class="titulo-tabla" scope="row">Fecha de Nacimiento</th>
                                                         <td>

                                                             <asp:TextBox ID="cal001" runat="server" ONVALUECHANGED="cal001_ValueChanged" VALUE="" class="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa" />
                                                             <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1041" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                             <asp:RangeValidator ID="RangeValidator1041" runat="server" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" MaximumValue="2010-01-01" MinimumValue="1900-01-01" />


                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <th class="titulo-tabla" scope="row">Tipo Nacionalidad</th>
                                                         <td>
                                                             <asp:DropDownList ID="ddown_tipo_nacionalidad" CssClass="form-control input-sm" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddownTipoNac_SelectedIndexChanged">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     
                                                         <%--<td width="200" class="texto_form">Nacionalidad</td>--%>

                                                         <th class="titulo-tabla" scope="row">Nacionalidad *</th>

                                                         <td>
                                                             <%--<span class="texto_rojo_peque">--%>
                                                             <asp:DropDownList ID="ddown001" class="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList>
                                                             <%--</span>--%>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <%--<td width="200" class="texto_form">Profesion u Oficio</td>--%>
                                                         <th class="titulo-tabla" scope="row">Profesión u Oficio *</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown002" runat="server" AppendDataBoundItems="True" class="form-control input-sm">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList></td>
                                                     

                                                         <%--<td width="200" class="texto_form">Actividad</td>--%>
                                                         <th class="titulo-tabla" scope="row">Actividad *</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown003" class="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <%--<td width="200" class="texto_form">Escolaridad</td>--%>
                                                         <th class="titulo-tabla" scope="row">Escolaridad *</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown004" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                 <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                             </asp:DropDownList>

                                                         </td>
                                                     
                                                         <%--<td width="200" class="texto_form">Situacion 1</td>--%>
                                                         <th class="titulo-tabla" scope="row">Situación 1 *</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown006" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <%--<td width="200" class="texto_form">Situacion 2</td>--%>
                                                         <th class="titulo-tabla" scope="row">Situación 2</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown007" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     
                                                         <%--<td width="200" class="texto_form">Situacion 3</td>--%>

                                                         <th class="titulo-tabla" scope="row">Situación 3</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown008" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <%--<td width="200" class="texto_form">Tipo Relacion</td>--%>
                                                         <th class="titulo-tabla" scope="row">Tipo Relación *</th>
                                                         <td>
                                                             <asp:DropDownList ID="ddown005" class="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown005_SelectedIndexChanged">
                                                                 <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                             </asp:DropDownList>
                                                         </td>
                                                     
                                                         <%--<td class="texto_form">Dirección</td>--%>
                                                         <th class="titulo-tabla" scope="row">Dirección</th>
                                                         <td>
                                                             <swtb:SenameTextBox ID="txt_direccion" runat="server" TextMode="MultiLine" class="form-control input-sm"></swtb:SenameTextBox>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <%--<td class="texto_form">Region</td>--%>
                                                         <th class="titulo-tabla" scope="row">Región</th>

                                                         <td>
                                                             <asp:DropDownList ID="ddown009" class="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown009_SelectedIndexChanged">
                                                             </asp:DropDownList></td>
                                                     
                                                         <%--<td class="texto_form">Comuna</td>--%>
                                                         <th class="titulo-tabla" scope="row">Comuna</th>
                                                         <td>
                                                             <asp:DropDownList ID="ddown010" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                             </asp:DropDownList></td>
                                                     </tr>
                                                     <tr>
                                                         <%--<td class="texto_form" style="height: 32px">Teléfono</td>--%>
                                                         <th class="titulo-tabla" scope="row">Teléfono</th>
                                                         <td>
                                                             <asp:TextBox ID="txttelefono" class="form-control form-control input-sm" type="text" runat="server" MaxLength="30" />
                                                             <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txttelefono" ValidChars="-0123456789" />
                                                             <%--<ajax:MaskedEditExtender ID="MaskedEditExtender207" runat="server" TargetControlID="txttelefono" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" Mask="9999999999" />--%>

                                                         </td>
                                                     
                                                         <%--<td width="200" class="texto_form">Fecha Relacion</td>--%>
                                                         <th class="titulo-tabla" scope="row">Fecha Relación *</th>

                                                         <td>

                                                             <asp:TextBox ID="cal002" runat="server" class="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa" />
                                                             <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1052" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                             <asp:RangeValidator ID="RangeValidator1052" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="cal002" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" />


                                                         </td>
                                                     </tr>
                                                     <%--<tr>
                                                     <td>--%>


                                                     <%--  </td>
                                                 </tr>--%>
                                                 </table>
                                                 <div class="botonera pull-right">
                                                     <asp:LinkButton class="btn btn-danger btn-sm" ID="btn001" runat="server" OnClick="btn001_Click"  ValidationGroup="grupo1" >
                                                         <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Persona Relacionada
                                                     </asp:LinkButton>
                                                     <%--<asp:Button class="btn btn-info btn-sm" ID="btn002" runat="server" OnClientClick="clean(); " OnClick="btn002_Click1" Text="Limpiar" CausesValidation="False" />--%>
                                                     <asp:LinkButton class="btn btn-info btn-sm fixed-width-button" ID="btnB001" runat="server" OnClick="btnB001_Click" AutoPostback="true"  CausesValidation="false" >
                                                          <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar Persona

                                                     </asp:LinkButton>
                                                 </div>

                                             </asp:Panel>
                                         

                             </div>
                         </ContentTemplate>
                     </asp:UpdatePanel>

                     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                         <ProgressTemplate>
                             <div style="position: absolute; top: 40%; left: 45%; right: 0; bottom: 0;">
                                 <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                                 Cargando...       
                             </div>
                         </ProgressTemplate>
                     </asp:UpdateProgress>
                      
                 </form>

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
    <%--<script src="http://code.jquery.com/jquery-latest.js"></script>--%>
</body>
</html>
