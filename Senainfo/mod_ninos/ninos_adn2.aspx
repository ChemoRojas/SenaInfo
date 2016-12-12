<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_adn2.aspx.cs" Inherits="mod_ninos_ninos_adn2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="description" content="S">
<meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Acto Toma de Muestra ADN :: Senainfo :: Servicio Nacional de Menores</title>    
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
     <script  type="text/javascript">
         function SetProgressPosition(e) {
             var posx = 0;
             var posy = 0;
             if (!e) var e = window.event;
             if (e.pageX || e.pageY) {
                 posx = e.pageX;
                 posy = e.pageY;
             }
             else if (e.clientX || e.clientY) {
                 posx = e.clientX + document.documentElement.scrollLeft;
                 posy = e.clientY + document.documentElement.scrollTop;
             }

             //alert(posx);
             //alert(posy);
             //document.getElementById('divProgress').style.left = posx  + "px";
             document.getElementById('divProgress').style.top = posy + "px";
         }

         function mostrar_cargando(objIframe) {
             frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
             frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 35%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
         }

         function MostrarModalInstitucion() {
             var objIframe = document.getElementById('iframe_institucion');
             mostrar_cargando(objIframe);
             objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_adn.aspx";
             objIframe.height = "300px";
             objIframe.width = "760px";
             $find("ModalPopupExtender1").show();
             //$find("mpe1a").show();
             return false;
         }

         function MostrarModalProyecto() {
             var objIframe = document.getElementById('iframe_proyecto');
             mostrar_cargando(objIframe);
             objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_adn.aspx";
             objIframe.height = "300px";
             objIframe.width = "760px";
             $find("mpe2a").show();
             return false;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
               
              <div class="container theme-showcase" role="main">                    
                    <ol class="breadcrumb">            
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Acto Toma de Muestra ADN</li>                        
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Acto Toma de Muestra ADN</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-10">                                
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Institución:</label>
                                            </th>
                                            <td>
                                                     
                                                <div class="input-group">                                                
                                                    <asp:DropDownList ID="ddown001_Inst" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown001_Inst_SelectedIndexChanged" />
                                                    <asp:LinkButton ID="imb_lupainstitucion" runat="server"  CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()" CausesValidation="False" >
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
                                                        <h4 class="modal-title">Senainfo/ Institución</h4>
                                                    </div>
                                                    <div>
                                                        <iframe id="iframe_institucion" runat="server" frameborder="0"></iframe>
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
                                                    <asp:LinkButton ID="imb_lupaproyecto" runat="server"  CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto()" CausesValidation="False"   >
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>
                                               <%--aqui el popup--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Selección:</label>
                                            </th>
                                            <td>
                                                <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="0">Solo Cumplen Condici&#243;n</asp:ListItem>
                                                    <asp:ListItem Value="1">Todos</asp:ListItem>
                                                </asp:RadioButtonList>--%>
                                            </td>                                            
                                        </tr>                                        
                                    </table>                                                    
                                                      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            
                            </div>
                            <!--fin col-md-10 -->
                         <div class="pull-left">
                            <a href="INSTRUCTIVO ADN v3.pdf" target="_blank">Descargar Instructivo</a><br />
                            <asp:ImageButton ID="btnExcelNinosSinADN" runat="server" ImageUrl="~/images/Excel1.bmp" Visible="False" OnClick="btnExcelNinosSinADN_Click" CausesValidation="False" /><br />
                            <asp:Label ID="lblsin" runat="server" Text="Reporte Niños sin Muestra ADN" Visible="False"></asp:Label><br />
                            <asp:Label ID="LBLNO" runat="server" Text="NO EXISTEN DATOS PARA ESTA BUSQUEDA" Visible="False" ></asp:Label>
                         </div>   
                        </div>
                        <div class="row">
                            <div class="col-md-12  table-responsive">                                
                                <asp:GridView ID="grd001" runat="server" CssClass="table table-bordered table-hover table-condensed caja-tabla" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="grd001_RowCommand"  OnPageIndexChanging="grd001_PageIndexChanging" OnSelectedIndexChanged="grd001_SelectedIndexChanged" AllowPaging="True">
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
                                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SentenciaExpresa" HeaderText="Sentencia Expresa">
                                        </asp:BoundField>
                                        <asp:ButtonField CommandName="Agregar" Text="Agregar">
                                        </asp:ButtonField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla" />
                                    <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                </asp:GridView>                                
                            </div>
                            <div>
                                <%--<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/Excel1.bmp" OnClick="ImageButton5_Click" Visible="False" />--%>
                                <asp:Label ID="lblcon" runat="server" Text="Reporte Niños con Muestra ADN" Visible="False"></asp:Label>
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
                                    
                                </asp:GridView>
                                    
                            </div>
                        </div>
                        <!--cierra Row-->
                        <!--Row para desplegar tabla con datos-->
                    </div>
                </div>
      
            </ContentTemplate>
        </asp:UpdatePanel>
          
         
    </form>
</body>
</html>
