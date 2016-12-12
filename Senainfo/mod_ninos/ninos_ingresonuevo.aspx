<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="~/mod_ninos/ninos_ingresonuevo.aspx.cs" Inherits="mod_ninos_ingresonuevo" %>


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
    <link rel="icon" href="img/favicon.ico">
    <title>Ingreso de Nuevo Niño</title> 

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <%--<script src="../js/ventanas-modales.js"></script>--%>
    
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
   
   <script src="../js/ie-emulation-modes-warning.js"></script>
   <%--<script type="text/javascript" src="../Script/jquery.min.js"></script>--%>  

    <script  type="text/javascript">


        function pageLoad(sender, args) {
            $(function () {
                $("#txt005").Rut({
                    format_on: 'keyup',
                    on_error: function () {
                        $("#txt005").val("");
                    },
                    on_success: function () {
                        $("#buscaMadre").click();
                    }

                });                
            });
        }

        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }

        function AbrirURLModalPopUp(url) {

            $('#UpdateProgress1').fadeIn();
            parent.location.replace(url);
        }
        function CerrarModalPopUp() {
            parent.location.reload();
        }

    </script>

</head>
<body class="body-form" onmousemove="SetProgressPosition(event)">
  <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers >
                <asp:PostBackTrigger ControlID="btn001" />
                <asp:PostBackTrigger ControlID="lnk_si" />
            </Triggers>
            <ContentTemplate>
                <div class="container">
                  <div class="row">
                    <div class="col-md-12 caja-tabla">
                      <asp:Panel ID="pnl005" runat="server">                 
                       <p class="titulo-form">Ingreso de Nuevo Niño </p>
                          <div class="alert alert-warning text-center" role="alert" id="divAlerta" runat="server" visible="false">
                                <asp:Label ID="lblAlerta" CssClass="subtitulo-form-info" runat="server" Text="Faltan campos obligatorios. "></asp:Label>
                            </div>
                        <table class="table table-bordered  table-condensed">
                          <tbody>
                           <tr>
                              <th class="titulo-tabla col-md-1" scope="row">RUN *</th>
                              <td class="col-md-5">
                                 <table>
                                     <tr>
                                         <td>
                                          <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server" OnTextChanged="txt001_ValueChange" MaxLength="12" AutoPostBack="true"/>
                                          <asp:CustomValidator id="cv_rut" runat="server" CssClass="help-block"  ControlToValidate="txt001" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />
                                          <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt001" ValidChars="Kk0123456789-." />
                                         </td>
                                         <td>&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:RadioButton  ID="chk001" Visible="false" runat="server" AutoPostBack="True" OnCheckedChanged="chk001_CheckedChanged" Text="Sin Run" />                                    
                                         </td>
                                         <td>&nbsp;
                                             <asp:RadioButton  ID="chk002" runat="server" AutoPostBack="True" OnCheckedChanged="chk002_CheckedChanged" Text="En Gestación"/>
                                         </td>
                                         <div>
                                          <asp:Panel ID="pnl003" runat="server"  HorizontalAlign="Center" Visible="False">
                                            <asp:Label ID="lbl004" runat="server" CssClass="help-block"></asp:Label>
                                          </asp:Panel>
                                          </div>
                                          <div>
                                          <asp:Label ID="lblexrut" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                                         </div>
                                     </tr>
                                 </table>
                              </td>
                           
                               <th class="titulo-tabla col-md-1">Nombres *</th>
                               <td>
                                  <asp:TextBox ID="txt002" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <th class="titulo-tabla">Apellido Paterno *</th>
                               <td>
                                  <asp:TextBox ID="txt003" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                               </td>
                           
                               <th class="titulo-tabla">Apellido Materno</th>
                               <td>
                                   <asp:TextBox ID="txt004" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                               </td>
                           </tr>

                           <tr>
                               <th class="titulo-tabla">Sexo *</th>
                               <td>
                                    <asp:RadioButton ID="rdo001" runat="server" GroupName="rdosexo" Text="Femenino" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdo002" runat="server" GroupName="rdosexo" Text="Masculino" />
                               </td>
                          
                              <th class="titulo-tabla" scope="row">Fecha de Nacimiento *</th>
                               <td>
                                   
                                               <asp:TextBox ID="cal001" CssClass="form-control form-control-fecha-large input-sm" OnKeyPress="return false;" runat="server" MaxLength="10" placeholder="dd-mm-aaaa"  />
                                               <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />
                                               <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende952" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled"  />
                                          
                                                <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block"  ErrorMessage="Fecha Invalida" ControlToValidate="cal001" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" Display="Dynamic"  />
                                                <asp:Label ID="lbl_avisoFecha" CssClass="help-block" runat="server" Visible="False"></asp:Label>
                                           
                                               <asp:Label ID="lblFechNac" runat="server" CssClass="help-block" Visible="False"></asp:Label>
                                           
                                               <asp:LinkButton ID="lnk_si" runat="server" OnClick="lnk_si_Click" Visible="False">Si&nbsp;&nbsp;</asp:LinkButton>
                                                <asp:LinkButton ID="lnk_no" runat="server" OnClick="lnk_no_Click" Visible="False">No</asp:LinkButton>
                                           
                               </td> 
                              
                            </tr>
                            <tr>
                              <th class="titulo-tabla" scope="row">Tipo de Nacionalidad</th>
                              <td>
                                    <asp:DropDownList ID="ddown_tipo_nacionalidad" CssClass="form-control input-sm" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown_tipo_nacionalidad_SelectedIndexChanged" >
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                    </asp:DropDownList>
                              </td>
                            
                              <th class="titulo-tabla" scope="row">Nacionalidad *</th>
                              <td>
                                    <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                    </asp:DropDownList>
                              </td>
                            </tr>
                            </tbody>
                        </table>                        
                        <asp:Panel ID="pnl004" runat="server" Visible="false">
                           <p class="titulo-form">Datos de la Madre (Solo para niños en Gestación)</p>
                            <asp:Button Text="buscaMadre" ID="buscaMadre" runat="server" OnClick="btn002_Click" style="display:none;" />
                            <div>
                                   <asp:Label ID="lbl002" runat="server" CssClass="help-block"></asp:Label>
                               </div>
                               <div>
                                   <asp:GridView ID="grd001" CssClass="table table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" OnRowCommand="grd001_RowCommand" Width="100%" OnSelectedIndexChanged="grd001_SelectedIndexChanged">
                                       <HeaderStyle CssClass="titulo-tabla" />
                                       <Columns>
                                           <asp:BoundField DataField="CodPersonaRelacionada" HeaderText="CodPersonaRelacionada"></asp:BoundField>
                                           <asp:BoundField DataField="RUT" HeaderText="RUT"></asp:BoundField>
                                           <asp:BoundField DataField="Nombres" HeaderText="Nombre"></asp:BoundField>
                                           <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                           <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                           <asp:ButtonField Text="Seleccionar"></asp:ButtonField>
                                       </Columns>
                                   </asp:GridView>
                               </div>
                            <table class="table table-bordered  table-condensed">
                              <tbody>                           
                               <tr>
                                  <th class="titulo-tabla col-md-1" scope="row">RUN</th>
                                  <td class="col-md-5">
                                      <table>
                                          <tr>
                                              <td>
                                                  <asp:TextBox ID="txt005" CssClass="form-control input-sm" runat="server" Enabled="False"  placeholder="Ingresar" MaxLength="12" />
                                                  <ajax:FilteredTextBoxExtender ID="fte3" runat="server" TargetControlID="txt005" ValidChars=".K0123456789-" />
                                              </td>
                                              <td>
                                                  <asp:CustomValidator id="CustomValidator2" runat="server" CssClass="help-block"  ControlToValidate="txt005" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" /><br />
                                                  <asp:Label ID="lblb001" runat="server" CssClass="help-block" Text="*(FALTAN CONDICIONES DE BUSQUEDA)" Visible="False"></asp:Label>
                                              </td>
                                              <td>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn002" runat="server" OnClick="btn002_Click"  Visible="False" >
                                                    <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar a la Madre
                                                </asp:LinkButton>
                                                  
                                              </td>
                                          </tr>
                                      </table>
                                    </td>
                               
                                   <th class="titulo-tabla col-md-1">Nombres *</th>
                                   <td >
                                       <asp:TextBox ID="txt006" CssClass="form-control input-sm" runat="server" Enabled="False" placeholder="Ingresar"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <th class="titulo-tabla col-md-1">Apellido Paterno *</th>
                                   <td>
                                       <asp:TextBox ID="txt007" CssClass="form-control input-sm" runat="server"  Enabled="False" placeholder="Ingresar" ></asp:TextBox>
                                   </td>
                               
                                   <th class="titulo-tabla">Apellido Materno *</th>
                                   <td>
                                       <asp:TextBox ID="txt008" CssClass="form-control input-sm" runat="server" Enabled="False" placeholder="Ingresar" ></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                  <th class="titulo-tabla" scope="row">Fecha Ingreso</th> 
                                  <td>
                                      
                                                  <asp:TextBox ID="cal004" CssClass="form-control form-control-fecha-large input-sm" OnKeyPress="return false;" MaxLength="10" runat="server" Text="" OnTextChanged="cal004_ValueChanged" Enabled="False" placeholder="dd-mm-aaaa" />
                                                  <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal004" ValidChars="0123456789-/" />
                                                  <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende964" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal004" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                              
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="cal004" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" Display="Dynamic" />
                                             
                                     </td>
                                          <th class="titulo-tabla" scope="row">Fecha Nacimiento *</th>
                                          <td>
                                              
                                                          <asp:TextBox ID="cal005" CssClass="form-control form-control-fecha-large input-sm" OnKeyPress="return false;" runat="server" MaxLength="10" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                          <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="cal005" ValidChars="0123456789-/" />
                                                          <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende975" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal005" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                      
                                                          <asp:RangeValidator ID="RangeValidator2" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="cal005" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" />
                                                      
                                         </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Nacionalidad *</th>
                                          <td>
                                              <asp:DropDownList ID="ddown001M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown001M_SelectedIndexChanged">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      
                                          <th class="titulo-tabla" scope="row">Profesión u Oficio *</th>
                                          <td>
                                              <asp:DropDownList ID="ddown002M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Actividad *</th>
                                          <td>
                                              <asp:DropDownList ID="ddown003M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True"  AutoPostBack="True" OnSelectedIndexChanged="ddown003M_SelectedIndexChanged">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      
                                              <th class="titulo-tabla" scope="row">Escolaridad *</th>
                                              <td>
                                                  <asp:DropDownList ID="ddown004M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                      <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                  </asp:DropDownList>
                                              </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Situación 1 *</th>
                                          <td>
                                              <asp:DropDownList ID="ddown006M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="false">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      
                                          <th class="titulo-tabla" scope="row">Situación 2</th>
                                          <td>
                                              <asp:DropDownList ID="ddown007M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="false">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Situación 3</th>
                                          <td>
                                              <asp:DropDownList ID="ddown008M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="false">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      
                                          <th class="titulo-tabla" scope="row">Tipo Relación *</th>
                                          <td>
                                              <asp:DropDownList ID="ddown005M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Dirección</th>
                                          <td colspan="3">
                                              <asp:TextBox ID="txt001M" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Región</th>
                                          <td>
                                              <asp:DropDownList ID="ddown009M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown009M_SelectedIndexChanged">
                                              </asp:DropDownList>
                                          </td>
                                      
                                          <th class="titulo-tabla" scope="row">Comuna *</th>
                                          <td>
                                              <asp:DropDownList ID="ddown010M" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                  <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                              </asp:DropDownList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <th class="titulo-tabla" scope="row">Teléfono</th>
                                          <td>
                                              <asp:TextBox ID="txttelefono" CssClass="form-control  input-sm" runat="server" placeholder="Ingresar" MaxLength="10" />
                                              <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txttelefono" ValidChars="0123456789" />
                                          </td>
                                      
                                          <th class="titulo-tabla" scope="row">Fecha Relacion *</th>
                                          <td>
                                              
                                                          <asp:TextBox ID="cal001M" CssClass="form-control form-control-fecha-large input-sm" OnKeyPress="return false;" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                          <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="cal001M" ValidChars="0123456789-/" />
                                                          <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende988" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001M" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                     
                                                          <asp:RangeValidator ID="RangeValidator3" runat="server" CssClass="help-block" ErrorMessage="Fecha Invalida" ControlToValidate="cal001M" Type="Date" OnInit="rv_fecha_Init" ValidationGroup="grupo1" Display="Dynamic" />
                                                      
                                              
                                          </td>
                                      </tr>
                                 
                          </tbody>
                        </table>
                                </asp:Panel>
                  
                        <div class="pull-right">
                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btn003" runat="server" OnClick="btn003_Click"  Visible="False" ValidationGroup="grupo1" CausesValidation="true" ValidateRequestMode="Enabled" >
                                <span class="glyphicon glyphicon-search"></span>&nbsp;Agregar a la Madre
                            </asp:LinkButton>
                        </div>
                        <div class="pull-right">
                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn001" runat="server" OnClick="btn001_Click"  CausesValidation="false" > 
                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Niño
                            </asp:LinkButton>
                            
                        </div>
                          
                       </asp:Panel>
                     <asp:Panel ID="pnl006" runat="server" Width="100%" Visible="False">
                     <div>
                     <asp:Label ID="Label2" CssClass="help-block" runat="server"  Text="EL RUT INGRESADO YA EXISTE Y CORRESPONDE A ESTE NIÑO(A), SI DESEA CONTINUAR CON EL INGRESO HAGA CLIC EN CONTINUAR. SI ESTA IDENTIDAD NO CORRESPONDE AL RUT, NO LO INGRESE  Y LLAME A LA MESA DE AYUDA." Font-Bold="True"></asp:Label>
                   </div>
                     <div>
                    <asp:GridView ID="grd003" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False"  GridLines="None">
                      <HeaderStyle CssClass="titulo-tabla" />
                        <Columns>
                        <asp:BoundField DataField="CodNino" HeaderText="CODIGO NI&#209;O">
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaAdoptabilidad" HeaderText="FECHA ADOPTABILIDAD" />
                        <asp:BoundField DataField="IdentidadConfirmada" HeaderText="IDENTIDAD CONFIRMADA" />
                        <asp:BoundField DataField="Rut" HeaderText="RUT">
                        </asp:BoundField>
                        <asp:BoundField DataField="Sexo" HeaderText="SEXO">
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombres" HeaderText="NOMBRES">
                        </asp:BoundField>
                        <asp:BoundField DataField="Apellido_paterno" HeaderText="APELLIDO PATERNO">
                        </asp:BoundField>
                        <asp:BoundField DataField="Apellido_Materno" HeaderText="APELLIDO MATERNO">
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FECHA DE NACIMIENTO" HtmlEncode="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="Nacionalidad" HeaderText="NACIONALIDAD" />
                        <asp:BoundField DataField="Etnia" HeaderText="ETNIA" />
                        <asp:BoundField DataField="OficinaInscripcion" HeaderText="OFICINA INSCRIP." />
                        <asp:BoundField DataField="AnoInscripcion" HeaderText="A&#209;O INSCRIP." />
                        <asp:BoundField DataField="NumeroInscripcionCivil" HeaderText="NUM. INSCRIP. CIVIL" />
                        <asp:BoundField DataField="AlergiasConocidas" HeaderText="ALERGIAS CONOCIDAS" />
                        <asp:BoundField DataField="InscritoFONADIS" HeaderText="INSCRITO FONADIS" />
                        <asp:BoundField DataField="InscritoFONASA" HeaderText="INSCRITO FONASA" />
                        <asp:BoundField HeaderText="NI&#209;O SUSEPTIBLE ADOPCION" />
                        <asp:BoundField DataField="EstadoGestacion" HeaderText="ESTADO GESTACION" />
                      </Columns>
                    </asp:GridView>
                   </div>
                     <div class="botonera pull-right">
                    <asp:Button CssClass="btn btn-info btn-sm" ID="btn004" runat="server" Text="Continuar" OnClick="btn004_Click" AutoPostback="true" CausesValidation="false" />
                   </div>
                     </asp:Panel>
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
</body>
</html>