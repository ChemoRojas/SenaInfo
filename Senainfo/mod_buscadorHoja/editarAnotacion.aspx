<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editarAnotacion.aspx.cs" Inherits="mod_buscadorHoja_editarAnotacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante_buscador.ascx" TagPrefix="uc1" TagName="menu_colgante_buscador" %>


<!DOCTYPE html>
<html lang="es">
<head id="Head2" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">

    <title>Buscador de NNA :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <%--<script src="../js/ventanas-modales.js"></script>--%>

    <%--<script src="../js/jquery-ui.js"></script>--%>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/ventanas-modales.css" rel="stylesheet" />
    <!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>

    <script type="text/javascript">

        
    </script>
</head>
<body role="document">
    <form id="form1" runat="server">

        <uc1:menu_colgante_buscador runat="server" ID="menu_colgante_buscador" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
                <input type="hidden" id="Buscando" value="0">
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
                <div>

                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Editar Anotación</li>
                        </ol>

                          <div class="alert alert-success text-center" color-text="green" role="alert" id="alertaEditar" runat="server" visible="false">
                               Anotación Editada con exito.<span class="glyphicon glyphicon-ok"></span>
                              <asp:Label ID="lblMsgSuccess" runat="server" Text="Anotación Editada con exito." Visible="false">Anotación Editada con exito.</asp:Label>
                              <asp:Button ID="btnVolver" runat="server" Text="Volver"  CssClass="btn btn-Link btn-m" BackColor="Transparent" OnClick="btnVolver_Click"  />
                          </div>
                        
                        <div class="well">
                            <fieldset>
                            <legend>
                            <h4 class="subtitulo-form">Editar Anotación</h4>
                            </legend>

                            
                                    <div class="row">
                                  <div class="col-md-9">
                                          <table class="table table-borderless table-condensed table-col-fix">
                                              <tr>
                                                  <th class="col-md-3">
                                                      <label for="">Motivo:</label>
                                                  </th>
                                             </tr> 
                                              <tr>
                                                  <th>
                                                      <div class="input-group">
                                                          <asp:TextBox ID="txtMotivo" runat="server"></asp:TextBox>
                                                      </div>
                                                      
                                                  </th>
                                              </tr> 
                                               <tr>
                                                  <th class="col-md-3">
                                                      <label for="">Observación:</label>
                                                  </th>

                                              </tr>
                                              <tr>
                                                  <th>
                                                      <div class="input-group" >
                                                          <asp:TextBox ID="txtObservacion" runat="server" Height="100"></asp:TextBox>
                                                      </div>
                                                      
                                                  </th>
                                              </tr> 

                                               <tr>
                                                  <th class="col-md-3">
                                                      <label for="">Fecha Anotación:</label>
                                                  </th>
                                               </tr>

                                               <tr>
                                                  <th>
                                                     
                                                          <asp:TextBox ID="txtFecha" runat="server" Height="27px"></asp:TextBox>

                                                          <asp:LinkButton ID="btnFecha" runat="server" CssClass="btn btn-link btn-sm" OnClick="btnFecha_Click" Height="16px" Width="27px" >
                                                          <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                          </asp:LinkButton>

                                                          <asp:Calendar ID="CalFechaAnotacion" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Visible="False" Width="220px">
                                                              <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                              <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                              <OtherMonthDayStyle ForeColor="#CC9966" />
                                                              <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                              <SelectorStyle BackColor="#FFCC66" />
                                                              <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                              <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                          </asp:Calendar>
                                                 
                                                                  <!-- textoOculto --><asp:HiddenField ID="txtId" runat="server" />
                                                    
                                                  </th>
                                               </tr>
                                             
                                                                                         
                                          </table>
                                       <asp:HiddenField ID="txtRut" runat="server" />
                                      
                                          <asp:LinkButton ID="btnModificar" runat="server" CssClass="btn btn-warning btn-sm" OnClick="btnModificar_Click">
                                        <span class="glyphicon glyphicon-pencil"></span>&nbsp;Modificar
                                    </asp:LinkButton>
                                          <!--gfontbrevis modal institucion -->
                                </div><!--cierra col-md-9--> 
                                </div>
                                   </fieldset>
                               
                           </div>
                                
                            
                           
                         
                        </div>
                    </div>


    </form>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

         <footer class="footer">
                    <div class="container">
                        <p>
                            Para tus dudas y consultas, escribe a:
                            <br>
                            mesadeayuda@sename.cl
                        </p>
                    </div>
                </footer>
</body>
</html>
