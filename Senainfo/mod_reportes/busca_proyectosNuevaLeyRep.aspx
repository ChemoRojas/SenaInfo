<%@ Page Language="C#" AutoEventWireup="true" CodeFile="busca_proyectosNuevaLeyRep.aspx.cs" Inherits="mod_coordinadores_busca_proyectosNuevaLey" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="es">

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Buscador Busca Proyectos :: Senainfo :: Servicio Nacional de Menores</title>
  
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/jquery.blockUI.js"></script>   
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>
  

    <script type="text/javascript">


      function AbrirURLModalPopUp(url) {

            $('#UpdateProgress1').fadeIn();
          parent.location.replace(url);
        }

        function CerrarModalPopUp() {
          parent.location.reload();
        }

        function AbrirURLModalPopUp(url) {
          $.blockUI.defaults.message = '<img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />';
          $.blockUI();
          parent.location.replace(url);
          $.modal.close();
        }

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
        };


    </script>
</head>
<body style="
    margin-top: -100px;
" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>        
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <Triggers>
                  <asp:PostBackTrigger ControlID="grd001" />
              </Triggers>
              <ContentTemplate>
                <div class="container">
                <div class="row" id="divTODO">
                    <div class="col-md-10">
                        <asp:Panel ID="pnl001" runat="server" Width="100%">
                          <table class="table table-bordered table-col-fix table-condensed">
                            <caption><asp:Label ID="lbl001" runat="server" Text="Buscador Proyectos"></asp:Label></caption>
                            <tbody>
                            <tr id="tr_codigo_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"> <asp:Label ID="Label1" runat="server" Text="Código Institución"></asp:Label></th>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                    
                                                    <asp:LinkButton ID="ImageButton1" CssClass="input-group-addon btn btn-info btn-sm" runat="server" CausesValidation="False"  OnClick="ImageButton1_Click"  AutoPostback="true" >
                                                        <span class="glyphicon glyphicon-search"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                            <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" Visible="False">
                                            </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_rut_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"> <asp:Label ID="lbl003" runat="server" Text="Nombre del Proyecto"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt0011" runat="server" CssClass="form-control form-control-40 input-sm" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl004" runat="server" Text="Código del Proyecto"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt0012" CssClass="form-control form-control-80 input-sm" runat="server" ></asp:TextBox>

                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt0012" ValidChars="0123456789" />
                                </td>
                            </tr>
                              <tr id="tr_tipo_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl005" runat="server" Text="Medida"></asp:Label></th>
                                <td>                                    
                                    <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control form-control-80 input-sm" >
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>                              
                        </tbody>
                    </table>
                    </asp:Panel>                
                <div class="botonera pull-right">                    
                    <asp:Button CssClass="btn btn-info btn-sm btn-ancho-100" ID="imb001" runat="server" Text="Buscar" OnClick="imb001_Click" AutoPostback="true"  />
                    <asp:Button CssClass="btn btn-info btn-sm btn-ancho-100" ID="imb002" runat="server" Text="Limpiar" AutoPostback="true" OnClick="imb002_Click"  />
                    <asp:Button CssClass="btn btn-primary btn-sm btn-ancho-100" ID="imb003" runat="server" Text="Cerrar" OnClick="imb003_Click" CausesValidation="False" Visible="False"  />
                </div>
                <div class="text-center">
                    <h4><asp:Label ID="lbl0013" runat="server" CssClass="subtitulo-form" Text="0" Visible="False"></asp:Label></h4>
                    <h4><asp:Label ID="lbl0014" runat="server" CssClass="subtitulo-form" Text="Coincidencias" Visible="False"></asp:Label></h4>
                    <h4><asp:Label ID="lbl0015" runat="server" CssClass="subtitulo-form" OnClick="lnkbtnver_Click" Visible="False" Text="Ver Resultados" AutoPostback="true"/></h4>
                </div>
                <div>
                    <asp:GridView ID="grd001" CssClass="table table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Visible="False" AllowPaging="True" Width="100%" OnRowCommand="grd001_rowcommand" OnPageIndexChanging="grd001_PageIndexChanging" >
                        <Columns>
                          <asp:BoundField DataField="CodInstitucion" HeaderText="C&#243;digo Instituci&#243;n"></asp:BoundField>
                          <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                          <asp:BoundField DataField="TipoProyecto" HeaderText="Tipo Proyecto"></asp:BoundField>
                          <asp:BoundField DataField="Nombre" HeaderText="Nombre Proyecto"></asp:BoundField>
                          <asp:BoundField DataField="CodSistemaAsistencial" HeaderText="Sistema Asistencial" Visible="False"></asp:BoundField>
                          <asp:ButtonField Text="Ver" CommandName="V"></asp:ButtonField>                            
                        </Columns>
                        <HeaderStyle CssClass="titulo-tabla" />
                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                    </asp:GridView>
                </div>
                          
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
    <script src="../js/jquery-1.9.1.js"></script>
    <script src="../js/jquery1.10.2.min.js"></script>
    <script src="../js/bootstrap3.3.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script> 
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/ie10-viewport-bug-workaround.js"></script>
</body>

</html>