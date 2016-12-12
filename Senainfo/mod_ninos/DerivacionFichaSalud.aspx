<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DerivacionFichaSalud.aspx.cs" Inherits="mod_ninos_DerivacionFichaSalud" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>

<!DOCTYPE html>

<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Ficha de salud (Primera atención)</title>

    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/ventanas-modales.css" rel="stylesheet" />

     <style>
        .table > thead > tr > th,
        .table > tbody > tr > th,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > tbody > tr > td,
        .table > tfoot > tr > td {
          padding: 5px;
          line-height: 1.42857143;
          vertical-align: middle;
          border-top: 1px solid #dddddd;
}
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#txtRut').Rut({
                    on_error: function () { alert('El rut ingresado no es válido'); $('#txtRut').val(""); },
                    format_on: 'keyup'
                });

            });
        };

    </script>

    <style>
        .avoid-clicks
        {
            pointer-events: none;
        }
        
    </style>
    
</head>


<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkGuardarDerivacion" />               
                
            </Triggers>
            <ContentTemplate>


                <div style="text-align: center;">
                    <h4>
                        <label class="titulo-form">FICHA DE DERIVACIÓN</label></h4>
                </div>

                <div class="alert alert-warning text-center" role="alert" id="divAlertaSinDerivacion" visible="false" runat="server">
                    <asp:Label ID="lblAlertaSinDerivacion" CssClass="subtitulo-form-info" runat="server" Text=""></asp:Label>
                </div>


                <div id="divIngresoDatos" class="row" runat="server" visible="false">
                    <table class="table table-bordered table-condensed">
                        <tbody>
                            <tr>
                                <th class="titulo-tabla col-md-1" scope="row">N° Identificación</th>
                                <td>
                                    <asp:TextBox ID="txtNIdentificacion" runat="server" CssClass="form-control input-sm avoid-clicks" placeholder="Ingresar"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                                        <asp:Label ID="lbl_nota1" CssClass="subtitulo-form-info" runat="server" Text="Faltan campos obligatorios. "></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            </tbody>
                        </table>

                    <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                        <table id="tblTituloDatosPersonales" class="table table-bordered table-condensed">
                            <tr class="titulo-form-fichasalud">
                                <td colspan="8" style="text-align: center;">
                                    <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                        <label>Datos Personales </label><span id="icon-collapse" class="glyphicon glyphicon-triangle-bottom"></span>
                                    </h4>
                                </td>
                            </tr>
                        </table>
                    </a>
                    <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                           <table class="table table-bordered table-condensed">
                        <tbody>                            
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Primer Apellido</th>
                                <td>
                                    <asp:TextBox ID="txtPrimerApellido" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Segundo Apellido</th>
                                <td>
                                    <asp:TextBox ID="txtSegundoApellido" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Nombre</th>
                                <td>
                                    <asp:TextBox ID="txtNombre" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">RUN</th>
                                <td>
                                    <asp:TextBox ID="txtRut" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Fecha de Nacimiento</th>
                                <td>
                                    <asp:TextBox ID="txtFechaNacimiento" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FTE3" runat="server" TargetControlID="txtFechaNacimiento" ValidChars="0123456789-/" />
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaNacimiento" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Edad</th>
                                <td>
                                    <asp:TextBox ID="txtEdad" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Sexo</th>
                                <td>
                                    <asp:DropDownList ID="ddlSexo" Enabled="false" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Region</th>
                                <td>
                                    <asp:DropDownList ID="ddlRegion" Enabled="false" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Comuna</th>
                                <td >
                                    <asp:DropDownList ID="ddlComuna" Enabled="false" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Domicilio</th>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDomicilio" Enabled="false" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                        </div>

                    <table id="Table1" class="table table-bordered table-condensed">
                            <tr class="titulo-form-fichasalud">
                                <td colspan="8" style="text-align: center;">
                                    <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                        <label>Datos Derivación </label>
                                    </h4>
                                </td>
                            </tr>
                        </table>

                    <table class="table table-bordered table-condensed">
                        <tbody>                            
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Institución que deriva</th>
                                <td>
                                     <asp:TextBox ID="txtInstitucionQueDeriva" runat="server" CssClass="form-control input-sm" ></asp:TextBox>                                   
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Proyecto que deriva</th>
                                <td>
                                    <asp:TextBox ID="txtProyectoQueDeriva" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Institución a la que deriva</th>
                                <td>
                                    <asp:TextBox ID="txtInstitucionALaQueDeriva" MaxLength="50" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Región</th>
                                <td>
                                    <asp:DropDownList ID="ddlRegionInstitucionALaQueDeriva" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Persona Quien Deriva</th>                                
                                <td>
                                    <asp:DropDownList ID="ddlPersonaQuienDeriva" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <%--<table class="table table-bordered table-condensed">
                        <tbody>
                            <tr style="border: 2px solid; border-color: #8F8F8F">
                                <td colspan="6" style="text-align: center;">
                                    <h4 style="margin-top: 0px; margin-bottom: 0px;">
                                        <label class="titulo-form">Persona Quien Deriva</label></h4>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Primer Apellido</th>
                                <td>
                                    <asp:TextBox ID="txtPrimerApellidoQuienDeriva" MaxLength="30" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Segundo Apellido</th>
                                <td>
                                    <asp:TextBox ID="txtSegundoApellidoQuienDeriva" MaxLength="30" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Nombre</th>
                                <td>
                                    <asp:TextBox ID="txtNombreQuienDeriva" MaxLength="30" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">RUN</th>
                                <td>
                                    <asp:TextBox ID="txtRutQuienDeriva" runat="server" MaxLength="11" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtRutQuienDeriva" ValidChars="0123456789Kk-." />
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Cargo</th>
                                <td>
                                    <asp:TextBox ID="txtCargoQuienDeriva" runat="server" MaxLength="50" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                                <th class="titulo-tabla col-md-ficha" scope="row">Telefono</th>
                                <td>
                                    <asp:TextBox ID="txtTelefonoQuienDeriva" runat="server" MaxLength="20" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTelefonoQuienDeriva" ValidChars="+0123456789-" />
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla col-md-ficha" scope="row">Correo Electrónico</th>
                                <td>
                                    <asp:TextBox ID="txtCorreoElectronicoQuienDeriva" MaxLength="50" runat="server" CssClass="form-control input-sm" placeholder="Ingresar"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>--%>
                    <div class="botonera pull-right">
                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnkGuardarDerivacion" OnClick="lnkGuardarDerivacion_Click" runat="server" AutoPostback="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Derivacion
                        </asp:LinkButton>

                       
                        <%--<asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" Visible="false" ID="lnkModificarDerivacion" runat="server" ValidationGroup="grupoficha" AutoPostback="true">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Derivacion
                        </asp:LinkButton>--%>
                    </div>
                </div>
                <%--<div id="divGridviewDatosGuardados" class="row" runat="server">
                    <asp:GridView ID="grdFichaDerivacion" CssClass="table table table-bordered table-hover caja-tabla text-center" runat="server" AllowPaging="False" Visible="False" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnPageIndexChanging="grd001_PageIndexChanging" OnRowCommand="grd001_RowCommand" Width="99%" OnPageIndexChanged="grd001_PageIndexChanged">
                        <HeaderStyle CssClass="titulo-tabla" />
                        <Columns>
                            <asp:BoundField DataField="CodFicha&#241;o" HeaderText="Codigo Ficha"></asp:BoundField>
                            <asp:BoundField DataField="NIdentificion" HeaderText="N° Identificación"></asp:BoundField>
                            <asp:BoundField DataField="sexo" HeaderText="Sexo"></asp:BoundField>
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                            <asp:BoundField DataField="apellidopaterno" HeaderText="Apellido Paterno"></asp:BoundField>
                            <asp:BoundField DataField="apellidomaterno" HeaderText="Apellido Materno"></asp:BoundField>
                            <asp:BoundField DataField="fechadenacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                            <asp:ButtonField Text="Ver Detalle Vigentes" CommandName="LINK"></asp:ButtonField>
                            <asp:BoundField DataField="CantidadVecesVigenteEnOtrosProyectos" HeaderText="Nro de Vigentes"></asp:BoundField>
                            <asp:ButtonField Text="Modificar" CommandName="MODIFICAR"></asp:ButtonField>
                        </Columns>
                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                    </asp:GridView>

                </div>--%>
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
