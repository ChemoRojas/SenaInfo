<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Registro_Faltas.aspx.cs" Inherits="mod_ninos_ninos_DireccionNino" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">  
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Infracción Disciplinaria :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script type="text/javascript" src="../Script/jquery.min.js"></script>  
    <script type="text/javascript" charset="utf-8" src="../js/senainfoTools.js"></script>
   
    
    <script  type="text/javascript">

        

        
        

        function AbrirURLModalPopUp(url) {

            $.blockUI.defaults.message = '<img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />';
            $.blockUI();

            //parent.location.replace(url);
            window.location.replace(url);
        }
    </script>


</head>
<body role="document" onmousemove="SetProgressPosition(event)" onkeydown = "return (event.keyCode!=13)" >
    <form id="form1" runat="server">  
        <uc1:menu_colgante runat="server" ID="menu_colgante" />        
        <asp:ScriptManager ID="ScriptManager1"  runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_lupainstitucion"
                    PopupControlID="modal_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1" >                    
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                    TargetControlID="imb_lupaproyecto"
                    PopupControlID="modal_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2" >                    
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe3" BehaviorID="mpe3a" runat="server"
                    TargetControlID="imb_agregar_infraccion"
                    PopupControlID="modal_agregar_infraccion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal3" >                    
                </ajax:ModalPopupExtender>


                <asp:LinkButton ID="imb_agregar_infraccion" runat="server"  CausesValidation="False">
                </asp:LinkButton>
                <div class="popupConfirmation" id="modal_agregar_infraccion" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="btnCerrarModal3" CssClass="close"  aria-label="Close" runat="server" CausesValidation="false">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">INFRACCIONES DISCIPLINARIAS</h4>
                    </div>
                    <div>
                        <iframe id="iframe_agregar_infraccion" runat="server" frameborder="0"></iframe>
                    </div>
                </div>

                <div class="container theme-showcase" role="main">                    
                    <ol class="breadcrumb">            
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Registro de Infracciones Disciplinarias LRPA</li>                        
                    </ol>

                     <!-- alertas -->
                   
                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-ok"></span>
                    </div>
                    <div class="alert alert-warning text-center" role="alert" id="alert_lbl_error" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                                <asp:Label ID="lbl_Error" runat="server" Visible="False" ></asp:Label>
                            </div>


                    <div class="well">
                    <h4 class="subtitulo-form">Registro de Infracciones Disciplinarias LRPA</h4>
                    <hr />
                    <div class="row">
                        <asp:Panel ID="pnl001" runat="server">
                        <div class="col-md-9">                                
                            <table class="table table-borderless table-condensed table-col-fix">
                                <tr>
                                    <th>
                                        <label for="">Institución:</label>
                                    </th>
                                    <td>
                                        <div class="input-group">                                                
                                            <asp:DropDownList ID="ddown001" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True" >
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupainstitucion" runat="server"  CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion','../mod_faltas/Registro_Faltas.aspx','mpe1a')" CausesValidation="False"   >
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="popupConfirmation" id="modal_institucion" style="display: none">
                                            <div class="modal-header header-modal">
                                                <asp:LinkButton ID="btnCerrarModal1" CssClass="close"  aria-label="Close"  runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                                </asp:LinkButton>
                                                <h4 class="modal-title">INSTITUCION</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="">Proyecto:</label>
                                    </th>
                                    <td>
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server"  OnSelectedIndexChanged="ddown002_SelectedIndexChanged"  AutoPostBack="True">
                                                <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="imb_lupaproyecto" runat="server"  CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto( 'Busca Proyectos','../mod_faltas/Registro_Faltas.aspx','mpe2a')" CausesValidation="False"   >
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="popupConfirmation" id="modal_proyecto" style="display: none">
                                            <div class="modal-header header-modal">
                                                <asp:LinkButton ID="btnCerrarModal2" CssClass="close"  aria-label="Close"  runat="server" Text="Cerrar" CausesValidation="false">
                                                    <span aria-hidden="true">&times;</span>
                                                </asp:LinkButton>
                                                <h4 class="modal-title">PROYECTO</h4>
                                            </div>
                                            <div>
                                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="">Apellido Paterno:</label>
                                    </th>
                                    <td>
                                        <div class="input-group"> 
                                            <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server" Enabled="false"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton1" CssClass="input-group-addon btn btn-info btn-sm" AutoPostback="true" runat="server" disabled="disabled" OnClick="LinkButton1_Click" >
                                                <span class="glyphicon glyphicon-question-sign"></span>                                            
                                            </asp:LinkButton>
                                        </div>                                        
                                    </td>
                                </tr> 
                                <tr><td></td>
                                    <td>
                                        <asp:LinkButton ID="hlInstructivo" CssClass="btn btn-success btn-sm fixed-width-button " runat="server" href="../links/INSTRUCTIVO_modulo_faltas_V2.pdf" Target="_blank">
                                <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Instructivo
                            </asp:LinkButton>
                            
                                         <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right"  ID="btn_limpiar" runat="server"  OnClick="btn_limpiar_Click" AutoPostback="true" >
                               <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                            </asp:LinkButton>
                                    </td></tr>                               
                            </table>
                            
                        </div>
                        <div class="col-md-3">                            
                            <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lbl001F2" CssClass="subtitulo-form-info" runat="server" Text="El Tiempo de Carga de la información dependerá de la cantidad de registros."></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl001_aviso" runat="server" CssClass="help-block" />
                                </div>
                                                      
                        </div>
                        </asp:Panel>
                    </div>                        
                    <div class="row">                        
                        <asp:Panel ID="pnl003" runat="server" Visible="False">
                            <asp:GridView ID="grd002" CssClass="table table table-bordered table-hover " runat="server" AllowPaging="True" AutoGenerateColumns="False" Visible="False" OnRowCommand="grd002_RowCommand" OnPageIndexChanging="grd002_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ICodFalta" HeaderText="IcodFalta">                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ICodIE" HeaderText="IcodIE">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaEventoFalta" HeaderText="Fecha Evento">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EventoDescripcionFalta" HeaderText="Descripcion Infracci&#243;n Disciplinaria" Visible="False">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PresentaDenuncia" HeaderText="Presenta Denuncia" Visible="False">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FaltaCF" HeaderText="Tipo Infracci&#243;n Disciplinaria">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Falta1" HeaderText="Infracci&#243;n Disciplinaria 1">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Falta2" HeaderText="Infracci&#243;n Disciplinaria 2">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Falta3" HeaderText="Infracci&#243;n Disciplinaria 3">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Falta4" HeaderText="Infracci&#243;n Disciplinaria 4">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sancion1" HeaderText="Sanción 1">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sancion2" HeaderText="Sanción 2">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sancion3" HeaderText="Sanción 3">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sancion4" HeaderText="Sanción 4">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Conflicto" HeaderText="Conflicto Crítico">
                                    </asp:BoundField>
                                    <asp:ButtonField CommandName="Modificar" Text="Modificar" HeaderText="Modificar" >
                                    </asp:ButtonField>
                                    <asp:ButtonField CommandName="Eliminar" Text="Eliminar" HeaderText="Eliminar">
                                    </asp:ButtonField>
                                </Columns>
                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                <PagerStyle CssClass="pagination-ys"/>
                                <RowStyle CssClass="caja-tabla table-bordered" />
                            </asp:GridView>
                        <div class="botonera pull-right">
                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button"  ID="WebImageButton1" runat="server"  OnClick="WebImageButton1_Click" AutoPostback="true" >
                                <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar
                            </asp:LinkButton>
                        </div>

                        </asp:Panel>
                                                                                      
                        <asp:Panel ID="pnl004" runat="server" Visible="true">
                            <asp:GridView ID="grd001" CssClass="table table table-bordered table-hover "  runat="server" AllowPaging="True" AutoGenerateColumns="False"  OnPageIndexChanging="grd001_PageIndexChanging" Visible="False" OnRowCommand="grd001_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="CodNino" HeaderText="Código Niño">                                                            
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rut" HeaderText="RUN">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" DataFormatString="{0:d}" HtmlEncode="False">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False">
                                    </asp:BoundField>
                                    <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" HeaderText="Seleccionar" >
                                    </asp:ButtonField>
                                </Columns>
                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <PagerStyle CssClass="pagination-ys" />
                                <RowStyle CssClass="caja-tabla table-bordered" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                    <div class="row">
                        <asp:Panel ID="pnl002" runat="server" Visible="False">
                        <table class="table table-bordered table-col-fix table-condensed">
                            <tr>
                                <th class="titulo-tabla" scope="row">Fecha Ingreso</th>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="cal001" runat="server" CssClass="form-control form-control-fecha input-sm" MaxLength="10"  placeholder="dd-mm-aaaa" ></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="cal001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                            </td>
                                            <td>
                                                <asp:RangeValidator ID="RangeValidator903" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="cal001" Type="Date" OnInit="rv_fecha_Init" /><br />
                                                <asp:Label ID="lbl001" runat="server" Visible="False"></asp:Label>
                                            </td>                                            
                                        </tr>
                                    </table>
                                </td>
                            </tr>    
                            <tr>
                                <th class="titulo-tabla" scope="row">Dirección</th>
                                <td>
                                    <asp:TextBox ID="txt007" CssClass="form-control input-sm" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>                                    
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Región</th>
                                <td>
                                    <asp:DropDownList ID="ddown006" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown006_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Comuna</th>
                                <td>
                                    <asp:DropDownList ID="ddown004" CssClass="form-control input-sm" runat="server" Width="350px" Font-Size="11px" Font-Names="Arial">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Teléfono</th>
                                <td>
                                     <asp:TextBox ID="txt002" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                     <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt002" ValidChars="0123456789" />
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Teléfono Recado</th>
                                <td>
                                    <asp:TextBox ID="txt003" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte3" runat="server" TargetControlID="txt003" ValidChars="0123456789" />
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">E-Mail</th>
                                <td>
                                    <asp:TextBox ID="txt004" CssClass="form-control input-sm" runat="server" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Fax</th>
                                <td>
                                    <asp:TextBox ID="txt005" runat="server"  CssClass="form-control input-sm"></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte4" runat="server" TargetControlID="txt005" ValidChars="0123456789" />
                                </td>
                            </tr>
                            <tr>
                                <th class="titulo-tabla" scope="row">Código postal</th>
                                <td>
                                    <asp:TextBox ID="txt006" CssClass="form-control input-sm" runat="server" ></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte5" runat="server" TargetControlID="txt006" ValidChars="0123456789" />
                                </td>
                            </tr>
                        </table>
                        <div class="botonera pull-right">
                            <asp:Button CssClass="btn btn-info btn-sm"  ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" />
                            <asp:Button CssClass="btn btn-info btn-sm"  ID="btn_guardar" runat="server" Visible="False"  Text="Guardar" OnClick="btn_guardar_Click" />                              
                        </div>
                        </asp:Panel>
                    </div>      
                        </div>
                    </div>
                        <footer class="footer">
        <div class="container">
            <p>Para tus dudas y consultas, escribe a:
                <br> mesadeayuda@sename.cl</p>
        </div>
    </footer>                   
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
