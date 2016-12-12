<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_adn.aspx.cs" EnableEventValidation="false" Culture="es-CL" Inherits="mod_ninos_adn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Acto Toma de Muestra ADN :: Senainfo :: Servicio Nacional de Menores</title>
    
    <script src="../js/jquery-1.10.2.js"></script> 
    <script src="../js/bootstrap.min.js"></script> 
    <script src="../js/jquery-1.7.2.min.js"></script>    
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    

    <script  type="text/javascript">
       

        

        
    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)" onkeydown = "return (event.keyCode!=13)" >
    
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExcelNinosSinADN" />
                <asp:PostBackTrigger ControlID="ImageButton5" />                
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
                    TargetControlID="imb_lupa_modal3"
                    PopupControlID="modal_adn"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal3" >                    
                </ajax:ModalPopupExtender>


                <%--Modal agregar muestra adn --%> 
                <asp:LinkButton ID="imb_lupa_modal3"  runat="server"  CausesValidation="False"  />
                <div class="popupConfirmation" id="modal_adn" style="display: none; border:none" >
                    <div class="modal-header header-modal">
                        <asp:LinkButton CssClass="close" ID="btnCerrarModal3" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">ACTO TOMA DE MUESTRA ADN</h4>
                    </div>
                    <div>
                    <iframe id="iframe_adn" runat="server" frameborder="0"></iframe>
                    </div>
                </div> 
            <%--Modal agregar muestra adn --%> 

                <div class="container theme-showcase" role="main">                    
                    <ol class="breadcrumb">            
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Acto Toma de Muestra ADN</li>                        
                    </ol>
                    <div class="alert alert-warning" role="alert" id="lbl_mensaje" runat="server" visible="false">
                            <asp:Label ID="LBLNO" runat="server" Text="NO EXISTEN DATOS PARA ESTA BÚSQUEDA" Visible="true"></asp:Label>
                        </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Acto Toma de Muestra ADN</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-9">                                
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Institución:</label>
                                            </th>
                                            <td>
                                                <div class="input-group">                                                
                                                    <asp:DropDownList ID="ddown001_Inst" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown001_Inst_SelectedIndexChanged" />
                                                    <asp:LinkButton ID="imb_lupainstitucion" runat="server"  CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Busca Proyectos','../mod_ninos/ninos_adn.aspx', 'mpe1a')" CausesValidation="False" >
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
                                                    <asp:DropDownList ID="ddown002_Proy" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown002_Proy_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem>Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupaproyecto" runat="server"  CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_ninos/ninos_adn.aspx', 'mpe2a')" CausesValidation="False"   >
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
                                                <label for="">Selección:</label>
                                            </th>
                                            <td>
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="0">&nbsp;Solo Cumplen Condici&#243;n&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="1">&nbsp;Todos</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:LinkButton ID="hlInstructivo" CssClass="btn btn-success btn-sm fixed-width-button" runat="server" href="INSTRUCTIVO%20ADN%20v3.pdf" Target="_blank">
                                                    <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Instructivo
                                                </asp:LinkButton>

                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="imb_limpiar" runat="server" Text="Limpiar"  AutoPostback="true"  CausesValidation="false" OnClick="imb_limpiar_Click">
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                 
                                            </td>
                                        </tr>
                                        
                                    </table>   
                                
                                
                                                                                             
                            </div>
                            <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Seleccione institución, proyecto y condición para consultar." ></asp:Label><br />
                                        <asp:Label ID="Lbl_Info2" CssClass="subtitulo-form-info" runat="server" Text="" ></asp:Label>                                      
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                        </div> <%--Fin de primer row--%>
                        

                        <div class="row">
                            <div id="div_encabezado1" runat="server" visible ="false">
                                <div class="col-md-12  table-responsive">
                                   
                                    <asp:Label ID="lblsin" runat="server" Text="Reporte Niños sin Muestra ADN" Visible="true"></asp:Label>
                                </div>
                            
                            <div class="col-md-12  table-responsive">                                
                                <asp:GridView ID="grd001" runat="server" CssClass="table table-bordered table-hover table-condensed caja-tabla" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="grd001_RowCommand"  OnPageIndexChanging="grd001_PageIndexChanging" OnSelectedIndexChanged="grd001_SelectedIndexChanged" AllowPaging="True">
                                    <Columns>
                                        <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaIngreso2" HeaderText="Fecha de Ingreso">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SentenciaExpresa" HeaderText="Sentencia Expresa">
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="Agregar" Text="Agregar">
                                        </asp:ButtonField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla" />
                                    <PagerStyle CssClass="pagination-ys"/>
                                </asp:GridView>   
                                
                                <asp:LinkButton ID="btnExcelNinosSinADN" runat="server" CssClass="btn btn-success btn-sm fixed-width-button pull-right"  OnClick="btnExcelNinosSinADN_Click" CausesValidation="False" Visible="true" >
                                        <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar Reporte
                                    </asp:LinkButton>                             
                            </div>
                                </div>
                            <div id="div_encabezado2" runat="server" visible="false">
                                <div class="col-md-12  table-responsive">
                                    
                                    <asp:Label ID="lblcon" runat="server" Text="Reporte Niños con Muestra ADN" Visible="true"></asp:Label>
                                </div>
                            
                            <div class="col-md-12 table-responsive">                                
                                    <asp:GridView ID="grd002" CssClass="table table-bordered table-hover table-condensed caja-tabla" runat="server" OnRowCommand="grd001_RowCommand" Width="1000px" OnPageIndexChanging="grd002_PageIndexChanging" OnSelectedIndexChanged="grd001_SelectedIndexChanged" AllowPaging="True" AutoPostback="true" >
                                    <Columns>
                                        <asp:BoundField DataField="ICodIE" HeaderText="ICodIE">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaIngreso2" HeaderText="Fecha de Ingreso">
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="N.U.E" DataField="NUE">
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Responsable" DataField="encargado">
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Tribunal" DataField="descripcion">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dactilar" HeaderText="Dactilar">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ADN" HeaderText="ADN">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Notificacion" HeaderText="Notificacion">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha Notificaci&#243;n">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaCita" HeaderText="Fecha Citaci&#243;n">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HoraCita" HeaderText="Hora Citaci&#243;n">
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla" />
                                    <PagerStyle CssClass="pagination-ys"/>
                                </asp:GridView>
                                <asp:LinkButton ID="ImageButton5" runat="server" CssClass="btn btn-success btn-sm fixed-width-button pull-right"  OnClick="ImageButton5_Click" CausesValidation="False" Visible="true">
                                        <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar Reporte
                                    </asp:LinkButton>
                                    
                            </div>
                                </div>
                        </div>
                        <!--cierra Row-->
                        <!--Row para desplegar tabla con datos-->
                    </div>
                </div>
                <footer class="footer">
                    <div class="container">
                        <p>Para tus dudas y consultas, escribe :a
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