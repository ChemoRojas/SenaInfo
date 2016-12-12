<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_AgregarTomaADN.aspx.cs" Inherits="mod_ninos_ninos_AgregarTomaADN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">  
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Detalles Muestra ADN :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script type="text/javascript" src="../Script/jquery.min.js"></script>  

<script type="text/javascript">

    function AbrirURLModalPopUp(url) {
        $('#UpdateProgress1').fadeIn();
        parent.location.replace(url);
    }

    
</script>
</head>

<body class="body-form" role="document" onmousemove="SetProgressPosition(event)" onkeydown = "return (event.keyCode!=13)" >
    <form id="form1" runat="server">              
        <asp:ScriptManager ID="ScriptManager1"  runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"  EnablePageMethods="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>    
                <asp:PostBackTrigger ControlID="imb_nuevo" />                                   
            </Triggers>
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                       <%-- <h4 class="subtitulo-form">ACTO TOMA DE MUESTRA ADN&nbsp;</h4>--%>
                        <br>
                        </br>
                        <br>
                        </br>
                        <div class="col-md-12">
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row"><asp:Label ID="Label1" runat="server" Text="Sentencia Expresa" ></asp:Label></th>
                                    <td>
                                        <asp:RadioButton ID="ChkSentenciaExpresa"   AutoPostBack="true"   runat="server" GroupName="sentencia" OnCheckedChanged="ChkSentenciaExpresa_CheckedChanged" Text="NO&nbsp;&nbsp;" />
                                        <asp:RadioButton ID="ChkSentenciaExpresaSI" AutoPostBack="true" runat="server" GroupName="sentencia"  OnCheckedChanged="ChkSentenciaExpresaSI_CheckedChanged" Text="SI" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlNotificacion" runat="server" Width="100%">
                                <table class="table table-bordered table-col-fix table-condensed">
                                    <tr>                                    
                                        <th class="titulo-tabla" scope="row">Se hizo la notificación</th>
                                        <td>
                                            <asp:CheckBox ID="chkNotificacion" runat="server" Text="SI" AutoPostBack="True" OnCheckedChanged="chkNotificacion_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Fecha Notificación</th>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFechaNotificacion" CssClass="form-control form-control-fecha input-sm" MaxLength="10"  placeholder="dd-mm-aaaa" runat="server" Enabled="False" OnTextChanged="txtFechaNotificacion_ValueChanged" />
                                                        <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txtFechaNotificacion" ValidChars="0123456789-/" />
                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende642" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaNotificacion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    </td>
                                                    <td>
                                                        <asp:RangeValidator ID="RangeValidator903" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="txtFechaNotificacion" Type="Date" OnInit="rv_fecha_Init" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Fecha cita en Médico Legal</th>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFechaMedicoLegal" runat="server"  Enabled="False" CssClass="form-control form-control-fecha input-sm" MaxLength="10"  placeholder="dd-mm-aaaa" />
                                                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFechaMedicoLegal" ValidChars="0123456789-/" />
                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende653" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaMedicoLegal" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    </td>                                                        
                                                    <td>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="txtFechaMedicoLegal" Type="Date" OnInit="rv_fecha_Init" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Hora</th>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtHora" runat="server"  Enabled="False" Text="0" MaxLength="2" CssClass="form-control input-sm" />
                                                                                                         
                                                    </td>
                                                    <td>
                                                         <asp:RangeValidator ID="RangeValidator67" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtHora" Type="Integer" MaximumValue="24" MinimumValue="0" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Minuto</th>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                         <asp:TextBox ID="txtMinuto" runat="server" Enabled="False" Text="0" MaxLength="2" CssClass="form-control input-sm" />
                                                         <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMinuto" ValidChars="0123456789" />
                                                    </td>
                                                    <td>
                                                        <asp:RangeValidator ID="RangeValidator70" runat="server" Text="Numero Fuera De Rango" ControlToValidate="txtMinuto" Type="Integer" MaximumValue="59" MinimumValue="0" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Consentimiento del Adolescente</th>
                                    <td>
                                        <asp:RadioButton ID="rdo001" runat="server" GroupName="TomaADN" Text="Si&nbsp;&nbsp;" OnCheckedChanged="rdo001_CheckedChanged" AutoPostBack="True" />
                                        <asp:RadioButton ID="rdo002" runat="server" GroupName="TomaADN" Text="No&nbsp;&nbsp;" AutoPostBack="True" OnCheckedChanged="rdo002_CheckedChanged1" />
                                        <asp:RadioButton ID="rdo003" runat="server" GroupName="TomaADN" Text="No se presenta" AutoPostBack="True" OnCheckedChanged="rdo003_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Consentimiento</th>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="cal001" runat="server" Enabled="False"   CssClass="form-control form-control-fecha input-sm" MaxLength="10"  placeholder="dd-mm-aaaa" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende690" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                </td>
                                                <td>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" OnInit="rv_fecha_Init" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Nombres</th>
                                    <td>
                                        <asp:TextBox ID="txtnombres" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Apellido Paterno</th>
                                    <td>
                                        <asp:TextBox ID="txtpaterno" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Apellido Materno</th>
                                    <td>
                                        <asp:TextBox ID="txtmaterno" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">RUN</th>
                                    <td>
                                        <asp:TextBox ID="txt_rut" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <p class="titulo-form">TOMA MUESTRA</p>
                            <br />
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Tipo Muestra</th>
                                    <td>
                                        <asp:CheckBox ID="Chk001" runat="server" Text="ADN"  OnCheckedChanged="Chk001_CheckedChanged" />
                                        <asp:CheckBox ID="Chk002" runat="server" Text="Dactilar" />
                                    </td>
                                </tr>   
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Muestra</th>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="cal003" runat="server" Enabled="False" CssClass="form-control form-control-fecha input-sm" MaxLength="10"  placeholder="dd-mm-aaaa" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende703" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal003" ValidateRequestMode="Enabled" ViewStateMode="Enabled" /> 
                                                </td>
                                                <td>
                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="cal003" Type="Date" OnInit="rv_fecha_Init" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">N.U.E.</th>
                                    <td>
                                        <asp:TextBox ID="Txt_nue" runat="server" CssClass="form-control input-sm" />
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">RESPONSABLE INFORMACION</p>
                            <br />
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Técnico</th>
                                    <td>
                                        <asp:TextBox ID="Txt_tecnico" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Cargo</th>
                                    <td>
                                        <asp:TextBox ID="Txt_cargo" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">RUN</th>
                                    <td>
                                        <asp:TextBox ID="Txt_run" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">ORDEN DE TRIBUNAL (Para la toma de muestra)</p>
                            <br />
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Región</th>
                                    <td>
                                        <asp:DropDownList ID="ddown005g" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown001g_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Tipo Tribunal</th>
                                    <td>
                                        <asp:DropDownList ID="ddown001g" runat="server" CssClass="form-control input-sm" AutoPostBack="True"  OnSelectedIndexChanged="ddown001g_SelectedIndexChanged" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Tribunal</th>
                                    <td>
                                        <asp:DropDownList ID="ddown006g" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown006g_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                            <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Orden Tribunal</th>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="cal002" runat="server" Enabled="False" CssClass="form-control form-control-fecha input-sm" MaxLength="10"  placeholder="dd-mm-aaaa"   />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende716" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                </td>
                                                <td>
                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="cal002" Type="Date" OnInit="rv_fecha_Init" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Identificación Orden</th>
                                    <td>
                                        <asp:TextBox ID="Txt_orden" runat="server" CssClass="form-control input-sm" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="botonera pull-right">
                            <asp:Button CssClass="btn btn-info btn-sm" ID="imb_nuevo" AutoPostback="true" runat="server" Text="Guardar" OnClick="imb_nuevo_Click"  />
                            <asp:TextBox ID="rdoestado" runat="server" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="cdtr" runat="server" Visible="False"></asp:TextBox>
                        </div>                                                           
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
