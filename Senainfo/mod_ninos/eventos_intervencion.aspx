    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="eventos_intervencion.aspx.cs"
    Inherits="mod_ninos_eventos_intervencion" EnableEventValidation="false" %>

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
    <title>Buscador Eventos Intervencion :: Senainfo :: Servicio Nacional de Menores</title>
        <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery.blockUI.js"></script>   
    <script src="../js/notify.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>
    <link href="../css/ventanas-modales.css" rel="stylesheet" />


</head>
<body  onmousemove="SetProgressPosition(event)" style="
    margin-top: -100px;
">

    <style>
        .ocultar-tabla {
            display:none;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">    
                <Triggers>
                    <asp:PostBackTrigger ControlID="WebImageButton3" />
                    <asp:PostBackTrigger ControlID="ddown005" />                    
                </Triggers>
            <ContentTemplate> 
              <div class="container">
                <div class="row" id="divTODO">
                    <asp:HiddenField runat="server" ID="idenEvento" Value="0" />
                    <asp:HiddenField runat="server" ID="rowSelected" Value="0" />
                    <div class="col-md-10">
                        <asp:Panel ID="pnl002" runat="server" Width="100%">
                                                    <h4><asp:Label ID="Label1" CssClass="subtitulo-form" runat="server" Text="LISTA DE EVENTOS (Eventos que se han asignado al área de Intervención)"></asp:Label></h4>

                        
                    </asp:Panel>
                    
                                            <asp:GridView ID="grd003" CssClass="table  table-bordered table-hover caja-tabla" AllowPaging="True" runat="server" AutoGenerateColumns="False"  OnPageIndexChanging="grd003_PageIndexChanging" OnRowCommand="grd003_RowCommand" 
                                             PageSize="8">
                                            <Columns>
                                                <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" DataFormatString="{0:d}"
                                                    HtmlEncode="False">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TipoEventoIntervencion" HeaderText="Tipo Evento">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DescTipoIntervencion" HeaderText="Tipo y Nivel de Intervención">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CodTrabajador" HeaderText="Técnico">
                                                </asp:BoundField>
                                                <asp:ButtonField CommandName="Eliminar" Text="Eliminar" HeaderText="Seleccionar">
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="IdGrupoEventos"  Visible="true" HeaderStyle-CssClass="ocultar-tabla" ItemStyle-ForeColor="transparent">
                                                    <ItemStyle BackColor="Transparent" CssClass="ocultar-tabla" BorderColor="Transparent" ForeColor="Transparent" />
                                                </asp:BoundField>
                                            </Columns>
                                              <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                              <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                              <PagerStyle CssClass="pager-tabla" ForeColor="White"/>      
                                                <RowStyle CssClass="caja-tabla table-bordered" />                         
                                            </asp:GridView>
                                    
                      <div class=" pull-right">                    
                          <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton2" runat="server"  OnClick="WebImageButton2_Click1" >
                              <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar
                          </asp:LinkButton>
                          <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton3" runat="server"  OnClick="WebImageButton3_Click" visible="false" >
                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                          </asp:LinkButton>                    
                      </div>
                      
                      <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="False">
                      <div class="container">
                        <div class="row" id="div1">
                            <div class="col-md-10">
                                
                        
                                <table class="table table-bordered table-col-fix table-condensed">
                                    <caption><asp:Label ID="Label2" runat="server" Text="AREA DE INTERVENCION"></asp:Label></caption>
                                    <tbody>                                    
                                    <tr id="tr_rut_institucion" runat="server">
                                        <th class="titulo-tabla" scope="row"> <asp:Label ID="lbl003" runat="server" Text="Tipo y Nivel de Intervención *"></asp:Label></th>
                                        <td>                                    
                                            <asp:DropDownList ID="ddown003" runat="server" CssClass="form-control  input-sm" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" AutoPostBack="true"  >
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="tr_rut_tecnico" runat="server">
                                        <th class="titulo-tabla" scope="row"><asp:Label ID="lbl006" runat="server" Text="Fecha Evento *"></asp:Label><!-- ONVALUECHANGED="WebDateChooser1_ValueChanged" --></th> 
                                        <td>                                    
                                            <asp:TextBox ID="WebDateChooser1"  placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha-large input-sm" AutoPostBack="true" OnTextChanged="WebDateChooser1_TextChanged" runat="server" ></asp:TextBox>
                                          <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende473" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="WebDateChooser1" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                        <asp:RangeValidator ID="RangeValidator473" runat="server" Text="Fecha Invalida" ControlToValidate="WebDateChooser1" Type="Date" MaximumValue="4000-12-31" MinimumValue="1000-01-01" ValidationGroup="grupo1" Display="Dynamic" />
                                          <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="WebDateChooser1" ValidChars="0123456789-/" />
                                          <asp:Label ID="lbl004b" runat="server" CssClass="help-block" Visible="false" ></asp:Label>
                                        </td>
                                    </tr>                                    
                                    <tr id="tr1" runat="server">
                                        <th class="titulo-tabla" scope="row"> <asp:Label ID="Label3" runat="server" Text="Tipo de Evento *"></asp:Label></th>
                                        <td>                                    
                                            <asp:DropDownList ID="ddown004" runat="server" CssClass="form-control  input-sm" >                                                    
                                            </asp:DropDownList>
                                        </td>
                                    </tr>                                   
                                    <tr id="tr2" runat="server">
                                        <th class="titulo-tabla" scope="row"> <asp:Label ID="Label4" runat="server" Text="Técnico *"></asp:Label></th>
                                        <td>                                    
                                            <asp:DropDownList ID="ddown005" runat="server" CssClass="form-control  input-sm" >                                                    
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                      <tr id="tr3" runat="server">
                                        <th class="titulo-tabla" scope="row"><asp:Label ID="Label5" runat="server" Text="Descripción"></asp:Label></th>
                                        <td>                                    
                                            <asp:TextBox ID="txt002" CssClass="form-control  input-sm" runat="server"  TextMode="MultiLine" ></asp:TextBox>
                                        </td>
                                    </tr>
                        </tbody>
                    </table>
                                  <div class="pull-right">                    
                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton1" runat="server"  OnClick="WebImageButton1_Click" >
                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Grabar

                    </asp:LinkButton>
                </div>
                        </div>         
                          </div> 
                        </div>
                      </asp:Panel>
                        </div>
                  </div>
                </div>
    </ContentTemplate>
    </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
</div>
    </form>
    <%--<script src="../js/jquery-1.9.1.js"></script>--%>
    <script type="text/javascript">
        //$(document).ready(function() {
            //$('#iframe_bsc_eventos').contents().find('#grd003').notify('Hola', { clickToHide: true, autoHide: true, autoHideDelay: 4000, arrowShow: true, arrowSize: 10, elementPosition: 'bottom center', style: 'bootstrap', className: 'success', showAnimation: 'slideDown', showDuration: 350, hideAnimation: 'slideUp', hideDuration: 350, gap: 5 })
        //})
            
            //if ($("#iframe_bsc_eventos").contents().find("#idenEvento").val() != 0 && $("#iframe_bsc_eventos").contents().find("#rowSelected").val() != 0) {
            //    console.log("entro");
            //    var x, y;
            //    $("#iframe_bsc_eventos").contents().find("#grd003 tr")[$("#iframe_bsc_eventos").contents().find("#rowSelected").val()].$(y).notify("Se ha añadido este evento",
            //        {
            //            clickToHide: true,
            //            autoHide: true,
            //            autoHideDelay: 4000,
            //            arrowShow: true,
            //            arrowSize: 10,
            //            elementPosition: "top center",
            //            style: "bootstrap",
            //            className: "success",
            //            showAnimation: "slideDown",
            //            showDuration: 350,
            //            hideAnimation: "slideUp",
            //            hideDuration: 350,
            //            gap: 5
            //        }
            //     );;      
            //};
            
    </script>
</body>

</html>
