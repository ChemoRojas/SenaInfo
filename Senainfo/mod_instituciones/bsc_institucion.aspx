<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="bsc_institucion.aspx.cs" Inherits="mod_institucion_bsc_institucion" %>
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
    
    <%--<script src="../js/jquery-1.10.2.js"></script>--%>
    <%--<script src="../js/jquery-1.9.1.js"></script>--%>
    <script src="../js/jquery1.10.2.min.js"></script>
    <script src="../js/bootstrap3.3.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/jquery.blockUI.js"></script>

    <%--<script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/ie10-viewport-bug-workaround.js"></script>--%>

    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet"/>
    <link href="../css/theme.css" rel="stylesheet"/>

    <script  type="text/javascript">

        function CerrarModalPopUp() {
            parent.location.reload();
        }

        function AbrirURLModalPopUp(url) {
            $.blockUI.defaults.message = '<img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />';
            $.blockUI();

            parent.location.replace(url);
            
        }

        function pageLoad(sender, args) {
            $(document).ready(function () {
                //RUN Tecnico
                $('#txt006').Rut({
                    on_error: function () { alert('RUN Incorrecto'); $('#txt006').val(''); $('#txt006').focus(); },
                    format_on: 'keyup'
                });
                //RUT Institucion
                $('#txt002').Rut({
                    on_error: function () { alert('RUT Incorrecto'); $('#txt002').val(''); $('#txt002').focus(); },
                    format_on: 'keyup'
                });
            });
        };
    </script>

    <style type="text/css">
        .ocultar{
            display:none;
        }
    </style>
</head>

<body class="body-form" onkeypress="JavaScript:if (event.keyCode==13) {self.document.getElementById('btnBuscar').click();event.keyCode=null;}">
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>                                
                <asp:PostBackTrigger ControlID="grd001" />
                <asp:PostBackTrigger ControlID="grd002" />
                <asp:PostBackTrigger ControlID="btnBuscar" />
            </Triggers>
            <ContentTemplate>
                
            <div class="container">
                <div class="row" id="divTODO">
                    <div class="col-md-10">
                        <asp:Panel ID="pnl001" runat="server" Width="100%">
                        <table class="table table-bordered table-col-fix table-condensed">
                            <caption><asp:Label ID="lbl001" runat="server"></asp:Label></caption>
                            <tbody>
                            <tr id="tr_codigo_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"> <asp:Label ID="lbl002" runat="server" Text="Código Institución"></asp:Label></th>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                    <asp:LinkButton ID="ImageButton1" CssClass="input-group-addon btn btn-info btn-sm" runat="server" CausesValidation="False"  OnClick="ImageButton1_Click1"  AutoPostback="true" >
                                                        <span class="glyphicon glyphicon-search"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                            <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" Visible="true" Enabled="false">
                                            </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_rut_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"> <asp:Label ID="lbl003" runat="server" Text="Rut Institución"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt002" runat="server" CssClass="form-control  input-sm" MaxLength="12" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl004" runat="server" Text="Institución"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt005" CssClass="form-control  input-sm" runat="server" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_tipo_institucion" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl005" runat="server" Text="Tipo Institución"></asp:Label></th>
                                <td>                                    
                                    <asp:DropDownList ID="ddown004" runat="server" CssClass="form-control  input-sm" >
                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr_rut_tecnico" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl006" runat="server" Text="Run Técnico"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt006" CssClass="form-control  input-sm" runat="server" MaxLength="12"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_apellido_paterno" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl007" runat="server" Text="Apellido Paterno"></asp:Label></th>
                                <td>                                    
                                     <asp:TextBox ID="txt007" runat="server" CssClass="form-control  input-sm" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_apellido_materno" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl008" runat="server" Text="Apellido Materno"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt003" runat="server" CssClass="form-control  input-sm" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_nombres" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl009" runat="server" Text="Nombres"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt004" runat="server" CssClass="form-control  input-sm" />
                                </td>
                            </tr>
                            <tr id="tr_codigo_inmueble" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0011" runat="server" Text="Codigo del Inmueble"></asp:Label></th>
                                <td>
                                    <asp:TextBox ID="txt0010" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_tipo_inmueble" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0010" runat="server" Text="Tipo Inmueble"></asp:Label></th>
                                <td>                                    
                                    <asp:DropDownList ID="ddown005" runat="server" CssClass="form-control  input-sm" >
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr_nombre_inmueble" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0012" runat="server" Text="Nombre del Inmueble"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt009" runat="server" CssClass="form-control  input-sm" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_nombre_proyecto" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0016" runat="server" Text="Nombre del Proyecto"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt0011" runat="server" CssClass="form-control  input-sm" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="tr_codigo_proyecto" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0017" runat="server" Text="Código del Proyecto"></asp:Label></th>
                                <td>                                    
                                    <asp:TextBox ID="txt0012" runat="server" CssClass="form-control  input-sm" ></asp:TextBox>
                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt0012" ValidChars="0123456789" />
                                </td>
                            </tr>
                            <tr id="tr_tipo_proyecto" runat="server">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0018" runat="server" Text="Tipo de Proyecto"></asp:Label></th>
                                <td>                                    
                                    <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm" >
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr_tipo_evento" runat="server" style="display:none">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl0019" runat="server" Text="Tipo de Evento" ></asp:Label></th>
                                <td>                                    
                                    <asp:DropDownList ID="ddown006" runat="server"  CssClass="form-control input-sm" Visible="False" >
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr_vigencia" runat="server" visible="false">
                                <th class="titulo-tabla" scope="row"><asp:Label ID="lbl020" runat="server" Text="Vigencia" ></asp:Label></th>
                                <td>                                    
                                    <asp:RadioButtonList ID="chklist001" runat="server" RepeatDirection="Horizontal" Visible="False" >
                                        <asp:ListItem Selected="True" Value="V">Vigente</asp:ListItem>
                                        <asp:ListItem Value="C">Caducado</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    </asp:Panel>
                <div class="row">
                    <div class="botonera pull-right">                    
                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnBuscar" runat="server"  OnClick="btnBuscar_Click" AutoPostback="true"  >
                            <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                        </asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="btnLimpiar" runat="server"  AutoPostback="true" OnClick="btnLimpiaBusqueda_Click" >
                            <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                        </asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button" ID="btnCancelarBusqueda_NEW" runat="server"  OnClick="btnCancelar_Click" CausesValidation="False" Visible="False"  >
                            <span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar
                        </asp:LinkButton>
                    </div>
                </div>                
                <div class="text-center">
                    <div class="row">
                        <div class="alert alert-warning" runat="server" visible="false" id="alertSinRegistros">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp; No se han encontrado registros
                        </div>
                    </div>
                    <h4><asp:Label ID="lbl0013" runat="server" CssClass="subtitulo-form" Text="0" Visible="False"></asp:Label></h4>
                    <h4><asp:Label ID="lbl0014" runat="server" CssClass="subtitulo-form" Text="Coincidencias" Visible="False"></asp:Label></h4>
                    <h4><asp:Label ID="lbl0015" runat="server" CssClass="subtitulo-form" OnClick="lnkbtnver_Click" Visible="False" Text="Ver Resultados" AutoPostback="true"/></h4>
                </div>
                <div>
                    <asp:GridView ID="grd001" CssClass="table  table-bordered table-hover" runat="server" AutoGenerateColumns="False" Visible="False" AllowPaging="True" Width="100%" OnRowCommand="grd001_rowcommand" OnPageIndexChanging="grd001_PageIndexChanging" OnSelectedIndexChanged="grd001_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="CodInstitucion" HeaderText="C&#243;digo Instituci&#243;n">
                            </asp:BoundField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo Instituci&#243;n">
                            </asp:BoundField>
                            <asp:BoundField DataField="RutInstitucion" HeaderText="Rut Instituci&#243;n">
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                            </asp:BoundField>
                            <asp:BoundField DataField="ICodInmueble" HeaderText="Cod. Inmueble" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="DesTipoInmueble" HeaderText="Tipo Inmueble" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoProyecto" HeaderText="Tipo Proyecto" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre Proyecto">
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoEventos" HeaderText="Evento" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="ICodEventosProyectos" HeaderText="Cod. Evento Proyecto" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" Visible="False" DataFormatString="{0:d}" HtmlEncode="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="DesCodSituacionLegal" HeaderText="Situacion Legal" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n Evento" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="CodSistemaAsistencial" HeaderText="Sistema Asistencial" Visible="False" />
                            <asp:BoundField DataField="VigenciaInmueble" HeaderText="Vigencia Inmueble" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="VigenciaRelacion" HeaderText="Vigencia Relacion" Visible="False">
                            </asp:BoundField>
                            <asp:ButtonField Text="Ver" CommandName="V" HeaderText="Ver">
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="NuevaRelacion" Text="Nueva" Visible="False" HeaderText="Nueva">
                            </asp:ButtonField>
                            <asp:BoundField DataField="CodTematicaProyecto" HeaderText="CodTematicaProyecto" ItemStyle-CssClass="ocultar" HeaderStyle-CssClass="ocultar" />
                        </Columns>
                        <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                        <RowStyle CssClass="caja-tabla table-bordered" /> 
                    </asp:GridView>
                </div>
                <div>
                    <asp:GridView ID="grd002" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" Visible="False" AllowPaging="True" OnRowCommand="grd002_rowcommand" OnPageIndexChanging="grd002_PageIndexChanging" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ICodTrabajador" HeaderText="Cod. Trabajador">
                            </asp:BoundField>
                            <asp:BoundField DataField="CodInstitucion" HeaderText="Cod. Instituci&#243;n">
                            </asp:BoundField>
                            <asp:BoundField DataField="Paterno" HeaderText="Apellido Paterno">
                            </asp:BoundField>
                            <asp:BoundField DataField="Materno" HeaderText="Apellido Materno">
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                            </asp:BoundField>
                            <asp:BoundField DataField="RutTrabajador" HeaderText="RUN Trabajador">
                            </asp:BoundField>
                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="VigRelacionProy" HeaderText="Vigencia en Proyecto" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="VigenciaTrabajador" HeaderText="Vigencia Trabajador" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="Institucion" HeaderText="Institución" Visible="False">
                            </asp:BoundField>
                            <asp:ButtonField Text="Ver" CommandName="V" HeaderText="Ver">
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="Relacionar" Text="Nueva" Visible="False" HeaderText="Nueva">
                            </asp:ButtonField>
                        </Columns>
                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                        <RowStyle CssClass="table-bordered caja-tabla" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
</body>

</html>