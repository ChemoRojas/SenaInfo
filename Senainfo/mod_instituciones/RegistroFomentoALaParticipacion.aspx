<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroFomentoALaParticipacion.aspx.cs" Inherits="mod_instituciones_RegistroFomentoALaParticipacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="sbtb" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<%@ Register src="../SenainfoSdk/C_buscar_x_institu_proyecto.ascx" tagname="C_buscar_x_institu_proyecto" tagprefix="uc2" %>

<%@ Register src="../SenainfoSdk/I_Institucion.ascx" tagname="I_Institucion" tagprefix="uc3" %>
<%@ Register src="../SenainfoSdk/I_Proyecto.ascx" tagname="I_Proyecto" tagprefix="uc4" %>

<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Registro Fomentos a la Participación :: Senainfo :: Servicio Nacional de Menores</title>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/dataTables.bootstrap.js"></script>
    <script src="../js/senainfoTools.js"></script>

    <link href="../css/theme.css" rel="stylesheet" />

<%--    <script type="text/javascript">
        $(function () {
      

            function limpiaiframe(objIframe) {
                frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
                frameDoc.documentElement.innerHTML = "";
            }
        })
    </script>--%>
</head>
<body onmousemove="SetProgressPosition(event)">
    <p>
    </p>
    <style type="text/css">
        .esconder
        {
            display: none;
        }

        #grd_ninosVigentes tbody td input
        {
            width:50px;
            text-align:center;
        }
        .auto-style1
        {
            background-color: #3c83bf;
            font-size: 12px;
            font-weight: normal;
            color: #fff;
            padding-top: 10px;
            padding-bottom: 10px;
            padding-left: 5px;
            text-align: left;
            width: 613px;
        }
        .auto-style2
        {
            background-color: #3c83bf;
            font-size: 12px;
            font-weight: normal;
            color: #fff;
            padding-top: 10px;
            padding-bottom: 10px;
            padding-left: 5px;
            text-align: left;
            width: 200px;
        }
    </style>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Registro Fomento a la Participación</li>
                    </ol>
                    <div class="alert alert-warning" role="alert" id="alerts" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="alert alert-success" role="alert" id="alerts2" runat="server" style="margin-top: 10px; display: none">
                        <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="well">
                        <h4 class="subtitulo-form">Registro Fomento a la Participación</h4>
                <%--        <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="btnCerrarModal3" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                   <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">PROYECTO</h4>

                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server"></iframe>
                            </div>
                        </div>
                        <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="btnCerrarModal4" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                  <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">INSTITUCION</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server"></iframe>
                            </div>
                        </div>--%>

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-bordered table-condensed">
                                    <tr>
                                        <th class="auto-style2">Institución</th>
                                        <td>

                                            <uc3:I_Institucion runat="server" ID="I_Institucion" UsarAllInOne="true" AutoPostBack="true" />

                                        </td>
                                    </tr>
                                    <tr>
                                         <th class="auto-style2">Proyecto</th>
                                        <td>
                                            <uc4:I_Proyecto  runat="server" ID="I_Proyecto" UsarAllInOne="true"  InstitucionControlID="I_Institucion" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="auto-style2">Ámbito</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_ambito" CssClass="form-control input-sm" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th class="auto-style2">Módulo</th>
                                        <td>
                                            <asp:DropDownList ID="ddl_modulo" CssClass="form-control input-sm" runat="server" AutoPostBack="true">
                                               
                                            </asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th class="auto-style2">Fecha</th>
                                        <td>
                                            
                                            <asp:TextBox ID="WebDateChooser1" runat="server" AutoPostBack="true" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_fecha" runat="server" ControlToValidate="WebDateChooser1" Display="Dynamic" ErrorMessage="Debe Ingresar una fecha"></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="true" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="WebDateChooser1" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="WebDateChooser1" Enabled="true" ErrorMessage="Fecha Inválida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        </td>
                                    </tr>
                                </table>
                                <div class="botonera pull-right">
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton1" runat="server" Visible="true" OnClick="WebImageButton1_Click">
                                        <span class="glyphicon glyphicon-search"></span>&nbsp;Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnk_guardar" runat="server" OnClick="lnk_guardar_Click">
                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                                    </asp:LinkButton>
                                   <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnk_modificar" runat="server" OnClick="lnk_modificar_Click" Visible ="false">
                                       <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar
                                   </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" runat="server" OnClick="WebImageButton2_Click">
                                        <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                    </asp:LinkButton>
                                </div>

                                <table class="table table-borderless table-condensed">
                                    <tr>
                                        <td>
                                            <h4>
                                                <asp:Label ID="lblCantidadVigentes" class="subtitulo-form" runat="server" Visible="true" />
                                                <asp:Label ID="lbl_contador" runat="server"></asp:Label>
                                            </h4>
                                        </td>
                                    </tr>
                                </table>
                              
                            </div>
                            <asp:GridView ID="grd_ninosVigentes" data-name="grd_ninosVigentes" runat="server" AutoGenerateColumns="False" Visible="true" CssClass="table table-bordered table-hover caja-tabla text-center">
                                <Columns>
                                    <asp:BoundField DataField="ICodIE" HeaderText="CodIE"></asp:BoundField>
                                    <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Asistencia al 100%">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAsistencia" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="P1">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_P1" runat="server" CssClass="form-control input-sm" MaxLength="1" Text="0" onkeypress="return true;" ControlToValidate="p1"></asp:TextBox>
                                                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="01234567" TargetControlID="txt_p1" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P2">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_P2" runat="server" CssClass="form-control input-sm" MaxLength="1" Text="0" onkeypress="return true;" ControlToValidate="p2"></asp:TextBox>
                                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="01234567" TargetControlID="txt_p2"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P3">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_P3" runat="server" CssClass="form-control input-sm" MaxLength="1" Text="0" onkeypress="return true;" ControlToValidate="p3"></asp:TextBox>
                                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="01234567" TargetControlID="txt_p3"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P4">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_P4" runat="server" CssClass="form-control input-sm" MaxLength="1" Text="0" onkeypress="return true;" ControlToValidate="p4"></asp:TextBox>
                                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="01234567" TargetControlID="txt_p4"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P5">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_P5a" runat="server" CssClass="form-control input-sm" MaxLength="1" Text="0" onkeypress="return true;" ControlToValidate="txt_p5"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="ftbe_p5" runat="server" ValidChars="01234567" TargetControlID="txt_P5a" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                <RowStyle CssClass="caja-tabla table-bordered" />

                            </asp:GridView>  
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
                </a>
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
    </form>
</body>
</html>