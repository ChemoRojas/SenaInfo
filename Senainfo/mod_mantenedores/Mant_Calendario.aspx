<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mant_Calendario.aspx.cs" Inherits="mod_mantenedores_Mant_Calendario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante_buscador.ascx" TagPrefix="uc1" TagName="menu_colgante_buscador" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Mantenedor de Calendarios :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script src="../js/senainfoTools.js"></script>

    <script type="text/javascript">
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

            document.getElementById('divProgress').style.top = posy + "px";
        }

     




        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press
            }
        }

        function limpiarForm() {
            window.location = "Mant_Calendario.aspx"
        }
    </script>

  
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante_buscador runat="server" ID="menu_colgante_buscador" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
           
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A3" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Mantenedores</li>
                        <li class="active">Calendario</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alertW" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>Faltan datos obligatorios para realizar el registro.
                        <asp:Label ID="lblMsgWarning" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>

                  
                     <div class="alert alert-warning text-center" role="alert" id="alertafechainiciomayor" runat="server" visible="false">
                        <span class="glyphicon glyphicon-warning-sign"></span>La fecha de inicio no puede ser mayor a la fecha de fin.
                        <asp:Label ID="Label3" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>

                      <div class="alert alert-success text-center" role="alert" id="alertEli" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>Estado modificado Correctamente
                        <asp:Label ID="Label1" runat="server" Text="Faltan datos obligatorios para realizar el registro." Visible="false"></asp:Label>
                    </div>

                    <div class="alert alert-success text-center" role="alert" id="alertS" runat="server" visible="false">
                        <span class="glyphicon glyphicon-ok"></span>Datos del Calendario registrados satisfactoriamente.
                        <asp:Label ID="lblMsgSuccess" runat="server" Text="Datos del Área registrados satisfactoriamente." Visible="false">Datos del Área registrados satisfactoriamente.</asp:Label>
                    </div>



                          <div class="row" visible="true" id="buscar" runat="server">
                                  <div class="col-md-9">
                                      <form action="">
                                          <table class="table table-borderless table-condensed table-col-fix">
                                              <tr>
                                                  <th class="col-md-3">
                                                      <label for="">Código del Calendario:</label>
                                                  </th>
                                                  <td>
                                                      <div class="input-group">
                                                          <asp:TextBox ID="txtCodCalendario" CssClass="form-control input-sm" runat="server" onkeypress="return numbersonly(event);"></asp:TextBox>
                                                      </div>
                                                      
                                                  </td>
                                              </tr>                               
                                          </table>
                                          <!--gfontbrevis modal institucion -->
                                    </form>
                                </div><!--cierra col-md-9-->  
                                <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Ingrese código de Calendario." ></asp:Label><br />
                                        <asp:Label ID="Lbl_Info2" CssClass="subtitulo-form-info" runat="server" Text="" ></asp:Label>                                      
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                                        </div>
                                
                            <div class="row">
                                <table class="table table-borderless table-condensed table-col-fix">
                                <tr>
                                    <td class="col-md-3">
                                        
                                    </td>
                                    <td>
                                
                                    <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnBuscar_Click">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnAgregar_Click">
                                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnLimpiar" runat="server" CssClass="btn btn-danger btn-sm " OnClick="btnLimpiar_Click">
                                        <span class="glyphicon glyphicon-remove"></span>&nbsp;Borrar
                                    </asp:LinkButton>
                                </td></tr></table>
                            
                                </div><!-- cierra row-->

                          <br>
                            <div class="row">
                                <div class="col-md-9">
                                    
                                        <asp:Panel ID="lbl002panel" runat="server" Visible="false" CssClass="text-center">
                                            <h4><label class="subtitulo-form">Resultados Búsqueda: 
                                            <asp:Label ID="lbl002" runat="server">0</asp:Label></label></h4>
                                        </asp:Panel>
                                    
                                                    <asp:GridView ID="grdBusqueda" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="table table table-bordered table-hover">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="CodCalendario" HeaderText="Código del Calendario" />
                                                            <asp:BoundField DataField="Nombre" HeaderText="Institución" />
                                                            <asp:BoundField DataField="NombreModulo" HeaderText="Módulo" />
                                                            <asp:BoundField DataField="Nombres" HeaderText="Responsable" />
                                                            <asp:BoundField DataField="FechaInicioModulo" HeaderText="Fecha de Inicio" />
                                                            <asp:BoundField DataField="FechaFinModulo" HeaderText="Fecha de Fin" />
                                                            <asp:BoundField DataField="Vigencia" HeaderText="Vigencia" />
                                                            <asp:BoundField DataField="CodCalendario" HtmlEncode="False" DataFormatString="<a href='editarCalendario.aspx?CodCalendario={0}'>Editar</a>" HeaderText="Editar" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField DataField="CodCalendario" HtmlEncode="False" DataFormatString="<a href='Mant_Calendario.aspx?CodCalendario={0}'>Cambiar Vigencia</a>" HeaderText="Cambiar Vigencia" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                
                                </div>
                                
                            </div>

                   
                    <div class="well" id="grabar" visible="false" runat="server">
                        <h4 class="subtitulo-form">Objetivos</h4>
                  
                            
                                <table class="table table-bordered  table-condensed">

                                    
                                    <tr>                                         
                                        <th class="titulo-tabla" scope="row">Modulo *</th>
                                            <td class="col-md-8">
                                                <asp:DropDownList ID="ddownModulo" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                   </tr>

                                    <tr>                                         
                                        <th class="titulo-tabla" scope="row">Institución *</th>
                                            <td class="col-md-8">
                                                <asp:DropDownList ID="ddownInstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="mostrar_profesionales">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                   </tr>

                                    <tr>                                         
                                        <th class="titulo-tabla" scope="row">Profesional *</th>
                                            <td class="col-md-8">
                                                <asp:DropDownList ID="ddownProfesional" runat="server" CssClass="form-control input-sm">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                   </tr>

                                    <tr>
                                        <th class="titulo-tabla" scope="row">Fecha de Inicio *</th>
                                            <td class="col-md-8">
                                                 <div class="input-group">
                                                          <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                                                          <asp:LinkButton ID="btnFecha" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnFechaInicio_Click" Height="13px" Width="15px" >
                                                          <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                          </asp:LinkButton>

                                                          <asp:Calendar ID="CalFechaInicio" runat="server"  OnSelectionChanged="Calendar1_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Visible="False" Width="220px">
                                                              <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                              <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                              <OtherMonthDayStyle ForeColor="#CC9966" />
                                                              <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                              <SelectorStyle BackColor="#FFCC66" />
                                                              <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                              <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                          </asp:Calendar>

                                        <!-- textoOculto--><asp:HiddenField ID="txtId" runat="server" />
                                                          
                                                   
                                                      </div>
                                            </td>
                                   </tr>

                                        <tr>
                                        <th class="titulo-tabla" scope="row">Fecha de Fin *</th>
                                            <td class="col-md-8">
                                                 <div class="input-group">
                                                          <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                                                          <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnFechaFin_Click" Height="13px" Width="15px" >
                                                          <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                          </asp:LinkButton>

                                                          <asp:Calendar ID="CalFechaFin" runat="server"  OnSelectionChanged="Calendar2_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Visible="False" Width="220px">
                                                              <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                              <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                              <OtherMonthDayStyle ForeColor="#CC9966" />
                                                              <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                              <SelectorStyle BackColor="#FFCC66" />
                                                              <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                              <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                          </asp:Calendar>

                                        <!-- textoOculto--><asp:HiddenField ID="txtID2" runat="server" />
                                                          
                                                   
                                                      </div>
                                            </td>
                                   </tr>

                                   



                                           
                                                         
                                </table>
                                <div class="botonera pull-right">
                                            
                                          
                                                <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton2" runat="server" Text="Limpiar" OnClick="WebImageButton2_Click" />--%>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" runat="server"  OnClientClick="limpiarForm();" >
                                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="WebImageButton3" runat="server" Text="Volver" OnClick="WebImageButton3_Click" />--%>
                                                 <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="WebImageButton1" runat="server"  OnClick="WebImageButton1_Click" >
                                                   <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                                </asp:LinkButton>
                               </div>
                   
                    </div>
                </div>
                <footer class="footer" aria-hidden="False">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                            <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>
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