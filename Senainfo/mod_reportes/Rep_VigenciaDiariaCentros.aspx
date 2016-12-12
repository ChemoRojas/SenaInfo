<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_VigenciaDiariaCentros.aspx.cs" Inherits="mod_reportes_Rep_VigenciaDiariaCentros" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
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
    <title>Reportes LRPA :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>


    
     
</head>
<body class="body-iframe-reportes" onmousemove="SetProgressPosition(event)" onkeydown = "return (event.keyCode!=13)" >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>         
                <asp:PostBackTrigger ControlID="btnImprimir" />       
            </Triggers>            
            <ContentTemplate>
                       <div class="alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                          <strong><asp:Label runat="server" ID="lblError"></asp:Label></strong>
                          
                          <asp:Label ID="lblaviso" runat="server"></asp:Label>
                          
                        </div>
                <h5 class="subtitulo-form">Vigencia Diaria en el centro</h5>
                <div class="row">
                <div class="col-md-9">
                        <table class="table table-borderless table-condensed table-col-fix">
                            <tr>
                                <th>
                                    <label for="">Fecha de la Información:</label>
                                </th>
                                <td>

                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control form-control-fecha-large input-sm" MaxLength="10" placeholder="dd-mm-aaaa"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txtFecha" ValidChars="0123456789-/" />
                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txtFecha" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                    <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="txtFecha" Type="Date" OnInit="rv_fecha_Init" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btnLimpiar_NEW" runat="server" OnClick="btnLimpiar_NEW_Click" CausesValidation="False">
                                                                     <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar

                                    </asp:LinkButton>
                        <asp:LinkButton ID="btnImprimir" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btnImprimir_NEW_Click" target="_blank"  >
                             <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                        </asp:LinkButton>   
                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-3">
                        
                                    <div class="panel-info panel-primary-info">
                                        <div class="panel-heading">
                                            Información
                                        </div>
                                        <div class="panel-footer">
                                            <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados para generar el reporte."></asp:Label>
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