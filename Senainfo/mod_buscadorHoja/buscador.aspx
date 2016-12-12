<%@ Page Language="C#" AutoEventWireup="true" CodeFile="buscador.aspx.cs" Inherits="buscador" %>
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
    <style type="text/css">
        .table-hover
        {
            margin-top: 31px;
        }
        .auto-style1
        {
            width: 13px;
            height: 4px;
        }
        .auto-style2
        {
            width: 88px;
            height: 4px;
        }
        .auto-style4
        {
            position: relative;
            min-height: 1px;
            top: 0px;
            left: 0px;
            float: left;
            width: 25%;
            height: 4px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style5
        {
            height: 4px;
        }
        .auto-style6
        {
            width: 81px;
            height: 4px;
        }
    </style>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
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
                            <li class="active">Búsqueda de NNA</li>
                        </ol>
                        
                        <div class="well">

                            <h4 class="subtitulo-form">Hoja de Vida NNA</h4>
                            
                                
                                 <div class="row">
                                  <div class="col-md-9">
                                     
                                          <table class="table table-borderless table-condensed table-col-fix">
                                              <tr>
                                                   <th class="auto-style4">
                                                      <label for="">RUN:</label>
                                                  </th>

                                                  <td class="auto-style2">
                                                      <div class="input-group">
                                                          <asp:TextBox ID="txtRun" runat="server" ToolTip="RUT del NNA" CssClass="form-control input-sm"></asp:TextBox>
                                                          <ajax:FilteredTextBoxExtender ID="Validador1" runat="server" TargetControlID="txtRun" ValidChars="Kk0123456789-" />
                                                      </div>
                                                      
                                                  </td>
                                              
                                                  <td class="auto-style1">
                                                      -
                                                  </td>

                                                  <td class="auto-style6">
                                                      <asp:TextBox ID="txtDv" runat="server" ToolTip="dv" CssClass="form-control input-sm" Height="34px" Width="49px"></asp:TextBox>              
                                                  </td>

                                               <td class="auto-style5">
                                
                                                  <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnBuscar_Click">
                                                  <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                                  </asp:LinkButton>
                                               </td>

                                             </tr>
                                          </table>
                                          <!--gfontbrevis modal institucion -->
                               

                                </div><!--cierra col-md-9-->  

                              </div>

                            

                             <div class="row">       

                                <div class="col-md-9">

                                     <asp:Panel ID="lbl002panel" runat="server" Visible="false" CssClass="text-left">

                                         <fieldset>
                                         <legend>
                                         </legend>
                                         </fieldset>
                                         
                                        Nombre NNA :   <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label><br/>
                                        Rut NNA    :   <asp:Label ID="lblRut" runat="server" Text="Label"></asp:Label><br/>
                                        CodNino    :   <asp:Label ID="lblCodigo" runat="server" Text="Label"></asp:Label><br/>
                                       <br/>
                                       <br/>
                                    
                                       <fieldset>
                                       <legend>

                                        
                                            <h4><label class="subtitulo-form">Antecedentes : <asp:Label ID="lblNombreAntecedentes" runat="server" Text="Label"></asp:Label>
                                            <asp:Label ID="lbl002" runat="server">0</asp:Label></label></h4>
                                         
                                       </legend>
                                            
                                
                                                  <asp:LinkButton ID="btnNuevaAnotacion" runat="server" CssClass="btn btn-success btn-sm" OnClick="btnNuevaAnotacion_Click"  >
                                                  <span class="	glyphicon glyphicon-plus"></span>&nbsp;Nueva Anotación
                                                  </asp:LinkButton>
                                            
                                            	
                                       
                                    
                                                    <asp:GridView ID="grdAntecedentes" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" CssClass="table table table-bordered table-hover"
                                                       ShowHeaderWhenEmpty="true" EmptyDataText="No hay Antecedentes para Mostrar">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="id" HeaderText="ID "/>
                                                            <asp:BoundField DataField="motivo" HeaderText="Motivo" />
                                                            <asp:BoundField DataField="observacion" HeaderText="Observación" />
                                                            <asp:BoundField DataField="fechaAnotacion" HeaderText="Fecha de Ejecución" />                                                            
                                                            <asp:BoundField DataField="txtVigencia" HeaderText="¿Vigente?" />
                                                            <asp:hyperlinkfield text="Cambiar" datanavigateurlfields="id,vigencia" datanavigateurlformatstring="cambiarVigencia.aspx?id={0}&amp;vigencia={1}" HeaderText="Accion" ItemStyle-HorizontalAlign="Center"/>
                                                            <asp:hyperlinkfield text="Editar" DataNavigateUrlFields="id,rut" datanavigateurlformatstring="editarAnotacion.aspx?id={0}&amp;Rut={1}" HeaderText="Acción" ItemStyle-HorizontalAlign="Center"/>
                                                                
                                                             
                                                                
                                                           
                                                           
                                                        </Columns>
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                       </asp:GridView>
                                         </fieldset>

                                     </asp:Panel>

                               
                                                
                                </div>
                                
                            </div>
                        </div>
                    </div>

                </div>



    </form>

      <footer class="footer">
        <div class="container">
            <p>Para tus dudas y consultas, escribe a:
            <br> mesadeayuda@sename.cl</p>
        </div>
     </footer>  
</body>
</html>
