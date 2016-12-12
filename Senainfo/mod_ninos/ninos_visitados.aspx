<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ninos_visitados.aspx.cs" Inherits="mod_ninos_ninos_visitados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="swtb" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico" />
    <title>Niños Visitados :: Senainfo :: Servicio Nacional de Menores</title>


    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>

    <%--<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.1.1.min.js"></script>--%>
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">
    <script src="../js/ie-emulation-modes-warning.js"></script>


    <script type="text/javascript">

        
        function pageLoad(sender, args) {
            $(document).ready(function () {

                $('#collapse').click(function () {
                    collapseFixHeader('#grd001');
                });
            });
        };


        //realiza un reflow al momento de presionar en agregar en la tabla y mostrar el mensaje de alerta en la parte superior.
        function collapseFixHeaderTimeLimit() {
            var counter = 0;

            var looper = setInterval(function () {
                counter++;
                $('#grd001').floatThead('reflow');

                if (counter >= 50) {
                    clearInterval(looper);
                }

            }, 100);
        }

        function MostrarModalProyecto() {
            var objIframe = document.getElementById('iframe_bsc_proyecto');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_visitados.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpeProyecto").show();
            return false;
        };

        function mostrar_cargando(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 35%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        };



        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_visitados.aspx";
            objIframe.height = "600px";
            objIframe.width = "900px";
            $find("mpe4a").show();
            return false;
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "";

        }

    </script>

</head>
<body role="document">

    <form id="form1" runat="server" onmousemove="SetProgressPosition(event)">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel_NV" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="imb_limpiar" />--%>
            </Triggers>
            <ContentTemplate>


                <!-- Modal Proyecto -->
                <ajax:ModalPopupExtender
                    ID="mpe2"
                    BehaviorID="mpeProyecto"
                    runat="server"
                    TargetControlID="imb_lupa_modal_proyecto"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>

                <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton ID="btnCerrarModal2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                    	            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">Senainfo/ Proyectos</h4>
                    </div>
                    <div>
                        <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                    </div>
                </div>


                <!-- Modal Institucion -->

                <ajax:ModalPopupExtender
                    ID="mpe4a" runat="server"
                    BackgroundCssClass="modalBackground"
                    BehaviorID="mpe4a"
                    CancelControlID="btnCerrarModal4"
                    DropShadow="true"
                    PopupControlID="modal_bsc_institucion"
                    TargetControlID="imb_lupa_modal">
                </ajax:ModalPopupExtender>

                <div id="modal_bsc_institucion" class="popupConfirmation" style="display: none">
                    <div class="botonera pull-right">
                        <asp:Button ID="btnCerrarModal4" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm" Text="Cerrar" />
                    </div>
                    <div>
                        <iframe id="iframe_bsc_institucion" runat="server"></iframe>
                    </div>
                </div>


                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Niños Visitados</li>
                    </ol>
                        <div class=" alert alert-warning text-center" role="alert" id="error" runat="server" visible="false">
                            <asp:Label ID="lbl001" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="lblErrorVerde" runat="server" Visible="false"></asp:Label>
                        </div>

                    <div class=" alert alert-success text-center" role="alert" id="alertCorrecto" runat="server" visible="false">
                        <asp:Label ID="lblCorrecto" runat="server" Visible="False"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Ni&ntilde;os Visitados</h4>
                        <hr>
                        <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                            <asp:Label ID="lbl_acordeon" runat="server" Visible="true" Text="Ocultar Detalles de la Búsqueda"></asp:Label>
                            <span id="icon-collapse" class="glyphicon glyphicon-triangle-top"></span>
                            <asp:Label ID="lbl_resumen_filtro" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="lbl_resumen_proyecto" runat="server" Visible="false"></asp:Label>
                        </a>

                        <div id="collapse_Form" runat="server" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tbody>
                                            <tr>
                                                <th>
                                                    <label for="">Instituci&oacute;n:</label>
                                                </th>
                                                <td>
                                                    <div class="input-group">
                                                        <asp:DropDownList CssClass="form-control input-sm" ID="ddown001" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()" CausesValidation="False">
                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <%--td class="col-md-2">
                                            <label for="">Proyecto</label>
                                        </td>
                                        <td>--%><%--<asp:DropDownList CssClass="form-control input-sm" ID="" runat="server" AutoPostBack="True" >
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>--%>



                                                <th>
                                                    <label for="">
                                                        Proyecto:</label>
                                                </th>
                                                <td><%--<asp:DropDownList ID="ddown002" runat="server" OnSelectedIndexChanged="ddown002_SelectedIndexChanged"
                                                AutoPostBack="True" CssClass="form-control input-sm">
                                                <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                            </asp:DropDownList>--%><%--<a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_DireccionNino.aspx"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/lupa.jpg" OnClick="ImageButton2_Click" /></a>--%>
                                                    <div class="input-group">
                                                        <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                                        </asp:DropDownList>
                                                        <asp:LinkButton ID="imb_lupa_modal_proyecto" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClick="imb_lupa_modal_proyecto_Click" OnClientClick="return MostrarModalProyecto()">
                                          	       <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Nombres:</label></th>
                                                <td>
                                                    <asp:TextBox ID="txtNombres" CssClass="form-control input-sm" runat="server" placeholder="Filtre por Nombres" Enabled="False" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNombres" ValidChars="abcdefghijklmnñoprstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Apellido Paterno:</label>
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txt001" CssClass="form-control input-sm" runat="server" placeholder="Filtre por Apellido Paterno" Enabled="False" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt001" ValidChars="abcdefghijklmnñoprstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" />
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Apellido Materno:</label></th>
                                                <td>
                                                    <asp:TextBox ID="txtApeMat" CssClass="form-control input-sm" runat="server" placeholder="Filtre por Apellido Materno" Enabled="False" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtApeMat" ValidChars="abcdefghijklmnñoprstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th></th>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger btn-sm fixed-width-button" runat="server" OnClick="LinkButton1_Click" CausesValidation="false">
                               <span class="glyphicon glyphicon-zoom-in"></span>&nbsp Buscar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnLimpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btnLimpiar_Click" CausesValidation="false">
                               <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
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
                                </div>
                            </div>
                        </div>
                    </div>



                    <asp:Panel ID="pnl" runat="server">
                        <div class=" well">
                            <h4 class="subtitulo-form">Registro</h4>
                            <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-col-fix table-condensed">
                                    <tr>
                                        <th>
                                            <label for="">Fecha Registro:</label>

                                        </th>
                                        <td>
                                            <asp:TextBox ID="call001" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" ONVALUECHANGED="call001_ValueChanged" MaxLength="10" />
                                            <%--<cc1:CalendarExtender ID="" runat="server" Format="dd-MM-yyyy" TargetControlID="" ViewStateMode="Enabled" />--%>
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1091" runat="server" Format="dd-MM-yyyy" TargetControlID="call001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" BehaviorID="_content_CalendarExtende1091" />
                                            <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="call001" ValidChars="0123456789-/" />

                                            <%--<asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="WebImageButton1" runat="server" Text="Buscar" OnClick="WebImageButton1_Click" />--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fecha Requerida" CssClass="help-block" ControlToValidate="call001" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ErrorMessage="Fecha Invalida" CssClass="help-block" ControlToValidate="call001" Type="Date" OnInit="rv_fecha_Init" /><br />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton3" CssClass="btn btn-info btn-sm fixed-width-button pull-right" runat="server" OnClick="LinkButton3_Click">
                                         <span class="glyphicon glyphicon-eye-open"></span>&nbsp;Ver Visitados &nbsp;
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Visible="False" CssClass="btn btn-info btn-sm fixed-width-button pull-right">
                              <span class="glyphicon glyphicon-eye-open"></span>&nbsp; Ver Vigentes</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>



                            </div>

                            <%--<div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                            	<asp:Label ID="lblErrorVerde" runat="server" Text="Debe seleccionar al menos un tipo de Visita(Verder)" Visible="false"></asp:Label><br />
                              <asp:Label ID="lblErrorRosado" runat="server" Text="Los niños señalados ya estan registrados para el proyecto y la fecha seleccionada (Rosada)" Visible="false"></asp:Label>
                          	</div>--%>

                            <div class="col-md-12">
                                <div id="lblTitNinVisitados" runat="server">

                                    <h4 class="subtitulo-form">
                                        <asp:Label ID="Label1" runat="server" Visible="false">Niños&nbsp; Visitados (Seleccionar un máximo de 10 niños cada vez)</asp:Label></h4>

                                    <asp:GridView ID="grd002" CssClass="table table-bordered table-hover tabla-tabs" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowCommand="grd002_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="CodNino" HeaderText="Código Niño" />
                                            <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Padre">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk003" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Madre">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk001" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Otro Masculino">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk004" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Otro Femenino">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk002" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="Quitar" Text="Quitar" HeaderText="Seleccionar" ItemStyle-CssClass="text-center"></asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="titulo-tabla text-center table-borderless" />
                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                        <RowStyle CssClass="text-center table-bordered caja-tabla" />

                                    </asp:GridView>

                                </div>


                                <h4>
                                    <asp:Label ID="lblTitVisible" CssClass="subtitulo-form" runat="server" Visible="false">Niños&nbsp; Visitados</asp:Label></h4>
                                <div id="tableHeader3" class="fixed-header"></div>
                                <div id="tableContainer3" class="fixed-header-table-container">
                                    <asp:GridView ID="grd003" CssClass="table table-bordered table-hover  tabla-tabs" runat="server" AutoGenerateColumns="False" OnRowCommand="grd003_RowCommand" OnPageIndexChanging="grd003_PageIndexChanging" AllowPaging="False">
                                        <Columns>
                                            <asp:BoundField DataField="CodNino" HeaderText="Código Niño"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                            <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Padre">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk003" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Madre">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk001" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Otro&lt;br&gt;Masculino">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk004" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Otro&lt;br&gt;Femenino">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk002" runat="server" CssClass="customCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="Eliminar" Text="Eliminar" HeaderText="Seleccionar" ItemStyle-CssClass="text-center"></asp:ButtonField>
                                        </Columns>
                                        <FooterStyle CssClass="table table-bordered table-hover" ForeColor="White" />
                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                        <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                        <RowStyle CssClass="table-bordered caja-tabla" />
                                    </asp:GridView>
                                </div>
                                <table class="table table-borderless">
                                    <tr>
                                        <td>

                                            <asp:LinkButton ID="imb_guardar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button pull-right" OnClick="imb_guardar_Click" Text="Guardar" Visible="false">
                                       <span class="glyphicon glyphicon-ok"></span>&nbsp Guardar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="imb_limpiar" runat="server" CausesValidation="false" CssClass="btn btn-info btn-sm fixed-width-button " OnClick="imb_limpiar_Click" Text="Limpiar" Visible="false">
                                       <span class="glyphicon glyphicon-remove-sign"></span>&nbsp Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="WebImageButton2" runat="server" OnClick="WebImageButton2_Click" Text="Quitar Todos" Visible="False">
                                                                            <span class="glyphicon glyphicon-remove"></span>&nbsp Quitar Todos
                                            </asp:LinkButton>




                                        </td>
                                    </tr>
                                </table>
                                <div runat="server" id="lblTitNinVigentes">

                                    <h4 class="subtitulo-form">
                                        <asp:Label ID="Label2" runat="server" Visible="false">Niños Vigentes </asp:Label></h4>
                                </div>

                                <div>
                                    <div id="tableHeader1" class="fixed-header"></div>
                                    <div id="tableContainer1" class="fixed-header-table-container">
                                        <asp:GridView ID="grd001" CssClass="table table-hover table-bordered tabla-tabs" runat="server" AutoGenerateColumns="False" OnRowCommand="grd001_RowCommand" OnPageIndexChanging="grd001_PageIndexChanging1" AllowPaging="False">
                                            <FooterStyle />
                                            <Columns>
                                                <asp:BoundField DataField="CodNino" HeaderText="Código Niño"></asp:BoundField>
                                                <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                                <asp:BoundField DataField="Rut" HeaderText="RUN"></asp:BoundField>
                                                <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                                <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                                <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                                <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:ButtonField CommandName="Agregar" Text="Agregar" HeaderText="Seleccionar" ItemStyle-CssClass="text-center"></asp:ButtonField>
                                            </Columns>
                                            <FooterStyle CssClass="table table table-bordered table-hover" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="table-bordered caja-tabla" />

                                        </asp:GridView>
                                    </div>
                                    <table class="table table-borderless">
                                        <tr>
                                            <td>

                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right" ID="imb_actualizar" runat="server" Text="Actualizar" Visible="False" OnClick="imb_actualizar_Click">
                                    <span class="glyphicon glyphicon-ok"></span>&nbsp Actualizar
                                                </asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </div>
                                </div>
                            </div>
                    </asp:Panel>
                </div>

                
                <footer class="footer">
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
        <%--<asp:UpdateProgress ID="UpdateProgress1"  runat="server" AssociatedUpdatePanelID="UpdatePanel_NV">
            <ProgressTemplate>
                <div style="position: absolute; top: 40%; left: 45%; right: 0; bottom: 0;">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_NV">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <script src="../js/bootstrap.min.js"></script>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
        <!-- Latest compiled and minified JavaScript -->
    </form>
</body>
</html>
