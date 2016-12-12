<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="bsc_egreso_institucion.aspx.cs" Inherits="mod_institucion_bsc_egreso_institucion" %>

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

    <title>Buscador Instituciones</title>

    <%--<link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />--%>
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>
    <%--<script type="text/javascript" src="../Script/jquery.fancybox-1.3.4.js"></script>--%>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />
    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>
    <script src="../js/senainfoTools.js"></script>

    <script type="text/javascript">
        
    </script>
</head>
<body class="body-form">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="imb002" />
                <asp:PostBackTrigger ControlID="grd001" />

            </Triggers>
            <ContentTemplate>
                <div class="container">
                    <style type="text/css">
                        .ocultar {
                            display:none;
                        }
                    </style>
                    <asp:Panel runat="server" ID="pnlAlerta" Visible="false">
                        <div class="alert alert-warning text-center" role="alert">
                            <p><span class="glyphicon glyphicon-exclamation-sign"></span>&nbsp;No se han encontrado resultados en la busqueda que ha realizado</p>
                        </div>
                        <asp:LinkButton runat="server" ID="Volver" CssClass="btn btn-primary pull-right" OnClick="Volver_Click">
                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp; Volver
                        </asp:LinkButton>
                    </asp:Panel>
                    <div class="row" id="divTODO">
                        <div class="col-md-10">

                            <asp:Panel ID="pnl001" runat="server" Width="100%">
                                <table class="table table-bordered table-col-fix table-condensed">
                                    <caption>
                                        <asp:Label ID="lbl001" runat="server"></asp:Label></caption>
                                    <tbody>
                                        <tr>
                                            <th class="titulo-tabla" scope="row">

                                                <asp:Label ID="lbl002" runat="server" Text="Código Institución"></asp:Label>

                                            </th>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div class="input-group">

                                                                <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                                <asp:LinkButton CssClass="input-group-addon btn btn-info btn-sm " ID="ImageButton1" runat="server" OnClick="ImageButton1_Click">
                                              <span class="glyphicon glyphicon-zoom-in"></span>
                                                    
                                                                </asp:LinkButton>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddown003" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" Visible="False">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <!--      <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl003" runat="server" Text="Rut Institución"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt002" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl004" runat="server" Text="Institución"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt005" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl005" runat="server" Text="Tipo Institución"></asp:Label></th>
                                            <td align="left">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList CssClass="form-control input-sm" ID="ddown004" runat="server" >
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl006" runat="server" Text="Rut Técnico"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt006" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl007" runat="server" Text="Apellido Paterno"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt007" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl008" runat="server" Text="Apellido Materno"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt003" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl009" runat="server" Text="Nombres"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt004" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl0011" runat="server" Text="Codigo del Inmueble"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt0010" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl0010" runat="server" Text="Tipo Inmueble"></asp:Label></th>
                                            <td >
                                                <asp:DropDownList ID="ddown005" CssClass="form-control input-sm" runat="server">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl0012" runat="server" Text="Nombre del Inmueble"></asp:Label></th>
                                            <td >
                                                <asp:TextBox ID="txt009" CssClass="form-control input-sm" runat="server" ></asp:TextBox></td>
                                        </tr>
                                      -->
                                        <tr>
                                            <th class="titulo-tabla">
                                                <asp:Label ID="lbl0016" runat="server" Text="Nombre del Proyecto"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt0011" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">
                                                <asp:Label ID="lbl0017" runat="server" Text="Código del Proyecto"></asp:Label></th>
                                            <td>
                                                <asp:TextBox ID="txt0012" CssClass="form-control input-sm" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla">
                                                <asp:Label ID="lbl0018" runat="server" Text="Tipo de Proyecto"></asp:Label></th>
                                            <td>
                                                <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" runat="server">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <!--
                                        <tr>
                                            <th class="titulo-tabla">
                                                <asp:Label ID="lbl0019" runat="server" Text="Tipo de Evento" Visible="False"></asp:Label></th>
                                            <td >
                                                <asp:DropDownList ID="ddown006" CssClass="form-control input-sm" runat="server"  Visible="False">
                                                    <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <th class="titulo-tabla" >
                                                <asp:Label ID="lbl020" runat="server" Text="Vigencia" Visible="False"></asp:Label></th>
                                            <td >
                                                <asp:RadioButtonList ID="chklist001" runat="server" RepeatDirection="Horizontal"
                                                    Visible="False" >
                                                    <asp:ListItem Selected="True" Value="V">Vigente</asp:ListItem>
                                                    <asp:ListItem Value="C">Caducado</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>-->
                                </table>
                                <div class="center-block">
                                    <span class="pull-left">
                                        <asp:Label ID="lbl0013" runat="server" Font-Size="XX-Large" ForeColor="#0253B7" Text="0" Visible="False"></asp:Label>
                                        <asp:Label ID="lbl0014" runat="server" Font-Size="Small" ForeColor="#0253B7" Text="Coincidencias" Visible="False"></asp:Label>

                                    </span>
                                    <span class="pull-right">

                                        <asp:LinkButton ID="lbl0015" CssClass="btn btn-info btn-sm fixed-width-button" runat="server" OnClick="lnkbtnver_Click" Visible="False">
                                            <span class="glyphicon glyphicon-check"></span>&nbsp;Ver Resultados</asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb001" runat="server" Text="Buscar" OnClick="imb001_Click" ValidationGroup="grupo1" AutoPostback="true">
                                              <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb002" runat="server" Text="Limpiar" OnClick="imb002_Click" AutoPostback="true" CausesValidation="false">
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                        </asp:LinkButton>
                                    </span>
                                </div>

                            </asp:Panel>
                        </div>
                    </div>



                    <div class="row" id="div1">
                        <div class="col-md-10">
                            <div id="tableHeader" class="fixed-header"></div>
                            <div class="fixed-header-table-container">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="grd001" CssClass="table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" Visible="False" Width="100%" OnRowCommand="grd001_rowcommand" OnPageIndexChanging="grd001_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="CodInstitucion" HeaderText="C&#243;digo Instituci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Tipo Instituci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="RutInstitucion" HeaderText="Rut Instituci&#243;n"></asp:BoundField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                                                <asp:BoundField DataField="ICodInmueble" HeaderText="Cod. Inmueble" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="DesTipoInmueble" HeaderText="Tipo Inmueble" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="TipoProyecto" HeaderText="Tipo Proyecto" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre Proyecto"></asp:BoundField>
                                                <asp:BoundField DataField="TipoEventos" HeaderText="Evento" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="ICodEventosProyectos" HeaderText="Cod. Evento Proyecto"
                                                    Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="FechaEvento" HeaderText="Fecha Evento" Visible="False" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="DesCodSituacionLegal" HeaderText="Situacion Legal" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n Evento" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="CodSistemaAsistencial" HeaderText="Sistema Asistencial"
                                                    Visible="False" />
                                                <asp:BoundField DataField="VigenciaInmueble" HeaderText="Vigencia Inmueble" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="VigenciaRelacion" HeaderText="Vigencia Relacion" Visible="False"></asp:BoundField>
                                                <asp:ButtonField Text="Ver" CommandName="V"></asp:ButtonField>
                                                <asp:ButtonField CommandName="NuevaRelacion" Text="Nueva" Visible="False"></asp:ButtonField>
                                                <asp:BoundField DataField="CodTematicaProyecto" HeaderText="CodTematica" HeaderStyle-CssClass="ocultar" ItemStyle-CssClass="ocultar" />
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />

                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grd002" CssClass="table table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" Visible="False" AllowPaging="True" OnRowCommand="grd002_rowcommand" OnPageIndexChanging="grd002_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="ICodTrabajador" HeaderText="Cod. Trabajador"></asp:BoundField>
                                            <asp:BoundField DataField="CodInstitucion" HeaderText="Cod. Instituci&#243;n"></asp:BoundField>
                                            <asp:BoundField DataField="Paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                            <asp:BoundField DataField="RutTrabajador" HeaderText="Rut Trabajador"></asp:BoundField>
                                            <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="VigRelacionProy" HeaderText="Vigencia en Proyecto" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="VigenciaTrabajador" HeaderText="Vigencia Trabajador" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="Institucion" HeaderText="Institucion" Visible="False"></asp:BoundField>
                                            <asp:ButtonField Text="Ver" CommandName="V"></asp:ButtonField>
                                            <asp:ButtonField CommandName="Relacionar" Text="Modificaci&#243;n" Visible="False"></asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla" />
                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />

                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
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
