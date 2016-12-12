<%@ Page Language="C#" AutoEventWireup="true" Culture="es-CL" UICulture="es" CodeFile="ninos_Egreso.aspx.cs" Inherits="mod_ninos_ninos_Egreso" EnableEventValidation="false" ClientIDMode="static" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Niños Egreso :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>    <%--<script src="../js/ventanas-modales.js"></script>--%>
    <script src="../js/jquery-ui.js"></script>
    <%--<script type="text/javascript" charset="utf-8" src="../js/jquery.dataTables.js"></script>--%>
    <!-- gfontbrevis agrega senainfotools con herramientas como fijador de headers de tablas -->
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">

    <%--<link href="../css/ventanas-modales.css" rel="stylesheet" />--%>    <%--<link rel="stylesheet" type="text/css" href="../css/jquery.dataTables.css" />--%>
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">


        

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $('#collapse').click(function () {
                    collapseFixHeader('#grd001');
                });

            });
        };

        function validar_rut(source, arguments) {
            var rut = arguments.Value; suma = 0; mul = 2; i = 0;

            for (i = rut.length - 3; i >= 0; i--) {
                suma = suma + parseInt(rut.charAt(i)) * mul;
                mul = mul == 7 ? 2 : mul + 1;
            }

            var dvr = '' + (11 - suma % 11);
            if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

            if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
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
        }

        function mostrar_cargando(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 35%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }
        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            mostrar_cargando(objIframe);
            //objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan%20de%20Intervencion&dir=../mod_ninos/ninos_egreso.aspx";
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan%20de%20Intervencion&dir=../mod_ninos/ninos_egreso.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe5a").show();
            return false;

        }

        function MostrarModalProyecto() {
            var objIframe = document.getElementById('iframe_bsc_proyecto');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_egreso.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe1a").show();
            return false;
        }

        function MostrarModalEgresoInstitucion() {
            var codTematica = document.getElementById("ddown009").value;
            var objIframe = document.getElementById('iframe_bsc_egreso_institucion');
            mostrar_cargando(objIframe);

            if (codTematica == "15") {
                objIframe.src = "../mod_ninos/bsc_egreso_institucion.aspx?param001=Busca Proyectos&codConQuienEgresa=" + codTematica + "&dir=../mod_ninos/ninos_egreso.aspx";
            } else {
                objIframe.src = "../mod_ninos/bsc_egreso_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_egreso.aspx";
            }
            //objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_ninos/ninos_egreso.aspx";
            objIframe.height = "600px";
            objIframe.width = "760px";
            $find("mpe2a").show();
            return false;
        }

        function MostrarModalValidarDireccion() {
            var objIframe = document.getElementById('iframe_validar_direccion');
            mostrar_cargando(objIframe);
            objIframe.src = "../mod_ninos/ninos_Egreso_Direccion.aspx";
            objIframe.height = "500px";
            objIframe.width = "920px";
            $find("mpe3a").show();
            return false;
        }

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#txt004').Rut({
                    on_error: function () { alert('El rut ingresado no es válido'); $('#txt004').val(""); },
                    format_on: 'keyup'
                });
            });
        };

        //function pageLoad(sender, args) {
        //    $(document).ready(function () {
        //    });
        //};


        function mostrarlbl_resumen() {
            $("#lbl_resumen_filtro").show();
            $("#lbl_resumen_proyecto").show();
        }

        function ocultarlbl_resumen() {
            $("#lbl_resumen_filtro").hide();
            $("#lbl_resumen_proyecto").hide();
        }


        //function pageLoad(sender, args) {
        //    $(document).ready(function () {
        //        if ($("#sessionICODIE").val() != "0") {
        //            var table = $('#grd001').DataTable(
        //                {
        //                    searching: true,
        //                    sort: false,
        //                    paging: true
        //                }
        //            );


        //            x = $('#sessionICODIE').val();
        //            table.search(x);
        //            table.draw();
        //            $("#grd001_filter input").focus().val(x);
        //            //$('#grd001_filter input').val(x)
        //        } else {
        //            //alert("no hay dato");
        //        }
        //    }
        //    )
        //};

        //$("#asdf").on("click", function () {
        //    $("#grd001_filter input").attr("value", $("#sessionICODIE").val());
        //});

        //function test() {
        //    //$("#grd001_filter input").attr("value", $("#sessionICODIE").val());
        //    if (("#sessionICODIE").val() != "0") {
        //        $("#grd001_filter input").attr("value", $("#sessionICODIE").val());
        //    }
        //    return false;
        //}


    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)" onkeydown="return (event.keyCode!=13)">
    <style>
        #grd001 tr th {
            text-align: center;
            white-space: nowrap;
            font-weight: 400;
            font-family: "Roboto", sans-serif;
        }

        #grd001 td {
            text-align: left;
            white-space: nowrap;
            font-family: "Roboto", sans-serif;
        }
    </style>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnablePartialRendering="true" EnableScriptLocalization="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnexcel" />
                <asp:PostBackTrigger ControlID="imb_guardar" />
            </Triggers>
            <ContentTemplate>

                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="mpe2"
                    BehaviorID="mpe2a"
                    runat="server"
                    TargetControlID="imb_lupa_modal2"
                    PopupControlID="modal_bsc_egreso_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="mpe3"
                    BehaviorID="mpe3a"
                    runat="server"
                    TargetControlID="imb_lupa_modal3"
                    PopupControlID="modal_validar_direccion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal3">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="mpe4"
                    BehaviorID="mpe4a"
                    runat="server"
                    TargetControlID="imb_lupa_modal4"
                    PopupControlID="modal_egreso"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal4">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="mpe5"
                    BehaviorID="mpe5a"
                    runat="server"
                    TargetControlID="imb_institucion"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModalInstitucion">
                </ajax:ModalPopupExtender>






                <%--Modal egreso --%>
                <asp:LinkButton ID="imb_lupa_modal4" runat="server" CausesValidation="False" />
                <div class="popupConfirmation" id="modal_egreso" style="display: none; border: none">
                    <div class="modal-header header-modal">
                        <asp:LinkButton CssClass="close" ID="btnCerrarModal4" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false"><span aria-hidden="true">&times;</span></asp:LinkButton>
                        <h4 class="modal-title">EGRESO</h4>
                    </div>

                    <div>
                        <iframe id="iframe_egreso" runat="server" frameborder="0"></iframe>
                    </div>
                </div>
                <%--Modal egreso --%>

                <asp:HiddenField ID="sessionICODIE" runat="server" Value="0" />


                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Egreso</li>
                    </ol>

                    <%--<asp:Button runat="server" id="refresher" Text="refresh" OnClick="refresher_Click" />--%>
                    <%--<button id="asdf" onclick="return test();">tests</button>--%>

                    <div class="well">
                        <h4 class="subtitulo-form">Egreso</h4>
                        <hr>

                        <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                            <asp:Label ID="lbl_acordeon" runat="server" Visible="true" Text="Ocultar Detalles de la Búsqueda"></asp:Label>
                            <span id="icon-collapse" class="glyphicon glyphicon-triangle-top"></span>
                        </a>
                        <br />
                        <asp:Label ID="lbl_resumen_filtro" runat="server" Visible="false" Text=""></asp:Label><br />
                        <asp:Label ID="lbl_resumen_proyecto" runat="server" Visible="false"></asp:Label>

                        <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th>
                                                <label for="">Institución:</label>
                                            </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddl_Institucion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_institucion" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                                    <div class="modal-header header-modal">
                                                        <asp:LinkButton ID="btnCerrarModalInstitucion" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
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
                                                    <asp:DropDownList ID="ddl_Proyecto" runat="server" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto()" CausesValidation="False">
                                          <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                                                    <div class="modal-header header-modal">
                                                        <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
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
                                                <label for="">Nombre del Niño(a):</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt_nombres" runat="server" AutoCompleteType="FirstName" CssClass="form-control  input-sm" placeholder="Ingresar" MaxLength="30"></asp:TextBox>
                                                <asp:LinkButton ID="lnkfiltrar" runat="server" OnClick="lnkfiltrar_Click" Visible="False" CssClass="btn btn-info btn-sm btn-ancho-100">Filtrar</asp:LinkButton>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_nombres" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Paterno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt_apaterno" runat="server" AutoCompleteType="LastName" CssClass="form-control  input-sm" placeholder="Ingresar Apellido" MaxLength="30"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_apaterno" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Materno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt_amaterno" runat="server" AutoCompleteType="LastName" CssClass="form-control  input-sm" placeholder="Ingresar Apellido" MaxLength="30"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_amaterno" ValidChars="  ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzüÜáéíóúÁÉÍÓÚ" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <!-- inicio: nueva posicion de botones -->
                                        <tr>
                                            <th></th>
                                            <td>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="imb_buscar" runat="server" Text="Buscar" OnClick="imb_buscar_Click" ValidationGroup="grupo1" CausesValidation="true" AutoPostback="true">
                                              <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                </asp:LinkButton>
                                                <!-- agrega pull-right para alinear a la derecha boton limpiar -->
                                                <asp:LinkButton CssClass="btn btn-info btn-sm pull-right fixed-width-button" ID="imb_limpiar" runat="server" Text="Limpiar" OnClick="imb_limpiar_Click" AutoPostback="true" CausesValidation="false">
                                              <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>


                                            </td>
                                            <td></td>
                                            <!-- fin: nueva posicion de botones -->

                                        </tr>
                                    </table>

                                </div>
                                <div class="col-md-3">
                                    <div class="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="lblinfo" CssClass="subtitulo-form-info" runat="server" Text="El Tiempo de Carga de la información dependerá de la cantidad de registros."></asp:Label>
                                    </div>
                                </div>

                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-bordered table-hover">
                                    <!-- inicio gfontbrevis se agrega para fijar header -->
                                    <div id="tableHeader" class="fixed-header"></div>
                                    <div class="fixed-header-table-container">
                                        <!-- fin -->

                                        <asp:GridView ID="grd001" CssClass="table table-bordered table-hover caja-tabla " runat="server" Visible="False" onAutoGenerateColumns="False" AutoGenerateColumns="False">

                                            <Columns>

                                                <asp:BoundField DataField="codnino" HeaderText="Cod. Niño" AccessibleHeaderText="COD. NIÑO"></asp:BoundField>
                                                <asp:BoundField DataField="ICODIE" HeaderText="ICODIE" AccessibleHeaderText="ICODIE"></asp:BoundField>
                                                <asp:BoundField DataField="rut" HeaderText="RUN" AccessibleHeaderText="RUN"></asp:BoundField>
                                                <asp:BoundField DataField="sexo" HeaderText="SEXO" AccessibleHeaderText="Sexo"></asp:BoundField>
                                                <asp:BoundField DataField="nombres" HeaderText="NOMBRES" AccessibleHeaderText="Nombres"></asp:BoundField>
                                                <asp:BoundField DataField="apellido_paterno" HeaderText="APELLIDO PATERNO" AccessibleHeaderText="ApellidoPaterno"></asp:BoundField>
                                                <asp:BoundField DataField="apellido_materno" HeaderText="APELLIDO MATERNO" AccessibleHeaderText="ApellidoMaterno"></asp:BoundField>
                                                <asp:BoundField DataField="FechaIngreso" HeaderText="FECHA DE INGRESO" AccessibleHeaderText="FechaIngreso" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                                <asp:BoundField DataField="FechaNacimiento" HeaderText="FECHA DE NACIMIENTO" AccessibleHeaderText="FechaDeNacimiento" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Seleccionar" ItemStyle-Width="200px" AccessibleHeaderText="Seleccionar">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkegresar" runat="server" OnClick="lnkegresar_Click" Visible="False" AutoPostback="true" CommandName="N">Egresar</asp:LinkButton>
                                                        <asp:Label ID="lblegreso" runat="server" Text="Label" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblcomment" runat="server" Visible="False"></asp:Label>
                                                        <table id="tblges" runat="server">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lbltitle" runat="server" Text="Niño en Gestación" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkegresarg" runat="server" OnClick="lnkegresarg_Click" Visible="False" CommandName="G" ForeColor="Red">Solo Egresar</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkegresar2g" runat="server" OnClick="lnkegresar2g_Click" Visible="False">Egresar e Ingresar</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:LinkButton ID="lnkegresar3g" runat="server" OnClick="lnkegresar3g_Click" Visible="False">Modificar/Ver</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <!-- inicio: nueva posicion boton exportar -->
                                <!-- agrega pull-right para alinear a la derecha boton limpiar -->
                                <asp:LinkButton ID="btnexcel" runat="server" CssClass="btn btn-success btn-sm pull-right fixed-width-button" Text="Exportar" OnClick="btnexcel_Click" CausesValidation="False" Visible="false">
                                           <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                </asp:LinkButton>
                                <!-- fin: nueva posicion boton exportar -->

                                <asp:Panel ID="pnl001" runat="server" Width="100%" Visible="False">


                                    <table class="table table-bordered table-condensed">
                                        <tbody>
                                            <tr>
                                                <th class="titulo-tabla col-md-4" scope="row">Fecha Egreso *</th>
                                                <th class="titulo-tabla " scope="row">Observaciones</th>
                                            </tr>
                                            <tr>
                                                <td class="col-md-3">
                                                    <asp:TextBox ID="call001" runat="server" CssClass="form-control form-control-fecha-large input-sm " MaxLength="10" AutoPostBack="True" placeholder="dd-mm-aaaa" OnTextChanged="call001_ValueChanged" />
                                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="call001" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende810" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="call001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" ValidationGroup="validaguardado" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="call001" Type="Date" OnInit="rv_fecha_Init" /><br />
                                                    <asp:Label ID="lbl001" runat="server" CssClass="help-block"></asp:Label>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt002" runat="server" MaxLength="200"  CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>


                                                <th class="titulo-tabla" scope="row">Tipo Causal Egreso *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown003" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown003_SelectedIndexChanged">
                                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>


                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Causal Egreso *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown004" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddown004_SelectedIndexChanged" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>

                                                <th>
                                                    <div class="alert alert-success text-center" color-text="red" role="alert" id="alertaObligatorio" runat="server" visible="false">
                                                          Campo Causal Egreso es Obligatorio<span class=""></span>
                                                         <asp:Label ID="lblMsgSuccess" runat="server" Text=" Campo Causal Egreso es Obligatorio" Visible="false"> Campo Causal Egreso es Obligatorio</asp:Label>
                                                         
                                                   </div>
                        
                                                </th>
                                            </tr>

                                            <tr runat="server" id="trCausalFallecimiento" visible="false">
                                                <th class="titulo-tabla" scope="row">Causal de Defunción *</th>
                                                <td>
                                                   <asp:TextBox ID="txtCausalFallecimiento" runat="server" CssClass="form-control input-sm" placeholder="Ingresar" MaxLength="35" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Con Quien Egresa *</th>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddown009" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown009_SelectedIndexChanged">
                                                                    <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtproyecto" runat="server" CssClass="form-control input-sm" OnTextChanged="txtproyecto_TextChanged" placeholder="Codigo proyecto" style="display:none;" />
                                                                <asp:button runat="server" ID="cargaddlProyConQuienEgresa" OnClick="cargaddlProyConQuienEgresa_Click" style="display:none;" />
                                                                <div class="input-group">
                                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtproyecto" ValidChars="0123456789" />
                                                                    <asp:DropDownList runat="server" ID="ddlProyectoConQuienEgresa" CssClass="form-control input-md" OnSelectedIndexChanged="ddlProyectoConQuienEgresa_SelectedIndexChanged">
                                                                        <asp:ListItem Text="Seleccionar" Value="0" />
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="imb_lupa_modal2" runat="server" CssClass="input-group-addon btn btn-info btn-sm" disabled="disabled" OnClientClick="return MostrarModalEgresoInstitucion()">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div id="modal_bsc_egreso_institucion" class="popupConfirmation" style="display: none">
                                                                    <div class="modal-header header-modal">
                                                                        <asp:LinkButton ID="btnCerrarModal2" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                                                <span aria-hidden="true">×</span>
                                                                        </asp:LinkButton>
                                                                        <h4 class="modal-title">CODIGO PROYECTO</h4>
                                                                    </div>
                                                                    <div>
                                                                        <iframe id="iframe_bsc_egreso_institucion" runat="server" frameborder="0"></iframe>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                             <tr>
                                                <th class="titulo-tabla" scope="row">Dirección *</th>
                                                <td>
                                                    <asp:CheckBox ID="chk001" runat="server" AutoPostBack="True" OnCheckedChanged="chk001_CheckedChanged1" Text="Dirección Validada" />
                                                    <asp:LinkButton ID="imb_lupa_modal3" runat="server" CssClass="btn btn-info btn-sm pull-right fixed-width-button" OnClientClick="return MostrarModalValidarDireccion()">
                                                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Agregar Dirección
                                                    </asp:LinkButton>   
                                                    <div id="modal_validar_direccion" class="popupConfirmation" style="display: none">
                                                        <div class="modal-header header-modal">
                                                            <asp:LinkButton ID="btnCerrarModal3" runat="server" aria-label="Close" CausesValidation="false" CssClass="close" Text="Cerrar">
                                                            <span aria-hidden="true">×</span>
                                                            </asp:LinkButton>
                                                            <h4 class="modal-title">DIRECCION</h4>
                                                        </div>
                                                        <div>
                                                            <iframe id="iframe_validar_direccion" runat="server" frameborder="0"></iframe>
                                                        </div>
                                                    </div>
                                                </td>

                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Medida Sugerencia Técnico / Derivación *</th>


                                                <td>

                                                    <asp:DropDownList ID="ddown008" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>

                                                </td>
                                            </tr>

                                            <tr id="tr_calidadJuridica" runat ="server" visible ="false">
                                                <th class="titulo-tabla" scope="row">Calidad Jurídica</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown010" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="True" Enabled="False" Visible="True">
                                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                   <%-- nunca se utiliza la calidad jurídica--%>
                                                </td>
                                            </tr>
                                            </tbody>
                                        <tr id="trRellenoDefuncion" runat="server" visible="false">
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr id="trTituloDetallesDefuncion" runat="server" visible="false">
                                            <td colspan="2">
                                                <p class="titulo-form">
                                                    Detalles Defunción
                                                </p>
                                            </td>
                                        </tr>
                                        <tr id="trFechaDefuncion" runat="server" visible="false">
                                            <th class="titulo-tabla" scope="row">Fecha de Defunción *</th>
                                            <td >
                                                <asp:TextBox ID="txtFechaDefuncion" runat="server" AutoPostBack="true" CssClass="form-control form-control-fecha input-sm" MaxLength="10" OnTextChanged="txtFechaDefuncion_TextChanged" placeholder="dd-mm-aaaa" />
                                                <ajax:FilteredTextBoxExtender ID="FTEFechaDefuncion" runat="server" TargetControlID="txtFechaDefuncion" ValidChars="0123456789-/" />
                                                <ajax:CalendarExtender ID="CEFechaDefuncion" runat="server" Enabled="true" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaDefuncion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                <asp:RangeValidator ID="RVFechaDefuncion" runat="server" ControlToValidate="txtFechaDefuncion" ForeColor="Red" OnInit="rv_fecha_Init" Text="Fecha Invalida" Type="Date" ValidationGroup="validaguardado" />
                                            </td>
                                        </tr>
                                            <tr id="trLugarFallecimiento" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Lugar Defunción *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddlLugarFallecimiento" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>                                                    
                                            </tr>
                                            <tr id="trRegionFallecimiento" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Región Defunción *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddlRegionFallecimiento" runat="server"  AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlRegionFallecimiento_SelectedIndexChanged" >
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trComunaFallecimiento" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Comuna Defunción *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddlComunaFallecimiento" runat="server" CssClass="form-control input-sm">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trExisteDenunciaMinisterio" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Existe Denuncia al Ministerio Público *</th>
                                                <td>
                                                    <asp:RadioButton ID="rbtnExisteDenunciaMinisterioSi" runat="server" AutoPostBack="True" GroupName="rbtnExisteDenunciaMinisterio" OnCheckedChanged="rbtnExisteDenunciaMinisterio_CheckedChanged" Text="Si" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="rbtnExisteDenunciaMinisterioNo" runat="server" AutoPostBack="True" Checked="True" GroupName="rbtnExisteDenunciaMinisterio" OnCheckedChanged="rbtnExisteDenunciaMinisterio_CheckedChanged" Text="No" />
                                                </td>
                                            </tr>
                                            <tr id="trFechaDenunciaMinisterio" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Fecha Denuncia al MP *</th>
                                                <td>
                                                    <asp:TextBox ID="txtFechaDenunciaMinisterio" runat="server" CssClass="form-control form-control-fecha input-sm " MaxLength="10" placeholder="dd-mm-aaaa" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtFechaDenunciaMinisterio" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaDenunciaMinisterio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtFechaDenunciaMinisterio" ForeColor="Red" OnInit="rv_fecha_Init" Text="Fecha Invalida" Type="Date" ValidationGroup="validaguardado" />
                                                    <br />
                                                </td>
                                                </tr>
                                            <tr id="trExisteQuerella" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Existe Querella *</th>
                                                <td>
                                                    <asp:RadioButton ID="rbtnExisteQuerellaSi" runat="server" AutoPostBack="True" GroupName="rbtnExisteQuerella" OnCheckedChanged="rbtnExisteQuerella_CheckedChanged" Text="Si" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="rbtnExisteQuerellaNo" runat="server" AutoPostBack="True" Checked="True" GroupName="rbtnExisteQuerella" OnCheckedChanged="rbtnExisteQuerella_CheckedChanged" Text="No" />
                                                </td>
                                            </tr>
                                            <tr id="trFechaQuerella" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Fecha Querella *</th>
                                                <td>
                                                    <asp:TextBox ID="txtFechaQuerella" runat="server" CssClass="form-control form-control-fecha input-sm " MaxLength="10" placeholder="dd-mm-aaaa" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtFechaQuerella" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="true" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaQuerella" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtFechaQuerella" ForeColor="Red" OnInit="rv_fecha_Init" Text="Fecha Invalida" Type="Date" ValidationGroup="validaguardado" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr id="trSeActivoCircular" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row" id="thCircular2308" runat="server" visible="false">Se Activo Circular 2308 *</th>
                                                <td id="tdCircular2308" runat="server" visible="false">
                                                    <asp:RadioButton ID="rbtnSeActivoCircular2308Si" runat="server" GroupName="rbtnSeActivoCircular2308" Text="Si" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="rbtnSeActivoCircular2308No" runat="server" GroupName="rbtnSeActivoCircular2308" Text="No" />
                                                </td>
                                                <th id="thCircular2309" runat="server" class="titulo-tabla" scope="row" visible="false">Se Activo Circular 2309 *</th>
                                                <td id="tdCircular2309" runat="server" visible="false">
                                                    <asp:RadioButton ID="rbtnSeActivoCircular2309Si" runat="server" GroupName="rbtnSeActivoCircular2309" Text="Si" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="rbtnSeActivoCircular2309No" runat="server" GroupName="rbtnSeActivoCircular2309" Text="No" />
                                                </td>
                                            </tr>
                                            <tr id="trFechaCertificado" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Fecha Certificado</th>
                                                <td>
                                                    <asp:TextBox ID="txtFechaCertificado" runat="server" CssClass="form-control form-control-fecha input-sm " MaxLength="10" placeholder="dd-mm-aaaa" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtFechaCertificado" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="true" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaCertificado" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtFechaCertificado" ForeColor="Red" OnInit="rv_fecha_Init" Text="Fecha Inválida" Type="Date" ValidationGroup="validaguardado" />
                                                    <br />
                                                </td>
                                            </tr>
                                             <tr id="trNumeroCertificado" runat="server" visible="false">
                                                <th class="titulo-tabla" scope="row">Número Certificado</th>
                                                <td>
                                                    <asp:TextBox ID="txtNumeroCertificado" runat="server" CssClass="form-control form-control-fecha input-sm " MaxLength="10" />
                                                    <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtNumeroCertificado" ValidChars="1234567890ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz" />
                                                </td>
                                            </tr>
                                            </tbody>
                                        </table>
                                    <table class="table table-bordered table-condensed">
                                        <tbody>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Tiene Orden Tribunal</th>
                                                <td>
                                                    <asp:RadioButton ID="rdo001" runat="server" AutoPostBack="True" GroupName="rdos" OnCheckedChanged="rdo001_CheckedChanged" Text="Si" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdo005" runat="server" AutoPostBack="True" GroupName="rdos" OnCheckedChanged="rdo005_CheckedChanged" Text="En Trámite" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdo002" runat="server" AutoPostBack="True" Checked="True" GroupName="rdos" OnCheckedChanged="rdo002_CheckedChanged" Text="No" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Pnl_Orden" runat="server" Width="100%" Visible="False">
                                    <p class="titulo-form">Detalle Ordenes de Tribunal </p>
                                    <p>&nbsp;</p>
                                    <table class="table table-bordered  table-condensed">
                                        <tbody>
                                            <tr>
                                                <th class="titulo-tabla col-md-4" scope="row">Fecha Orden *</th>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="call002" runat="server" CssClass="form-control form-control-fecha input-sm" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="call002" ValidChars="0123456789-/" />
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende825" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="call002" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                            </td>
                                                            <td>
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="call002" Type="Date" OnInit="rv_fecha_Init" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Región</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown012" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddown012_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Tipo de Tribunal</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown013" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddown013_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Tribunal *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown006" runat="server" CssClass="form-control input-sm">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="tr_expediente" runat="server">
                                                <th class="titulo-tabla" scope="row">Expediente Nº</th>
                                                <td>
                                                    <asp:TextBox ID="txt003" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Medida Aplicada Tribunal *</th>
                                                <td>
                                                    <asp:DropDownList ID="ddown007" runat="server" CssClass="form-control input-sm" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnl002" runat="server" Width="100%" Visible="False">
                                    <p class="titulo-form">Información del Niño(a) </p>
                                    <p>&nbsp;</p>
                                    <table class="table table-bordered table-col-fix table-condensed">
                                        <tbody>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Fecha Nacimiento</th>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="cal003" OnKeyPress="return false;"  runat="server" CssClass="form-control form-control-fecha input-sm" MaxLength="10" placeholder="dd-mm-aaaa" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="cal003" ValidChars="0123456789-/" />
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende840" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal003" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                            </td>
                                                            <td>
                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" lass="alert alert-warning text-center" Text="Fecha Invalida" ControlToValidate="cal003" Type="Date" OnInit="rv_fecha_Init" />
                                                                &nbsp;<asp:Label ID="lblAvisoFechaNacimiento" CssClass="help-block" runat="server" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Rut</th>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txt004" CssClass="form-control input-sm" runat="server" placeholder="RUN Niño(a)" MaxLength="12" />
                                                                <ajax:FilteredTextBoxExtender ID="fte3" runat="server" TargetControlID="txt004" ValidChars="kK.-0123456789" />
                                                            </td>
                                                            <%--<td>--%>
                                                                <%--<asp:CustomValidator ID="cv_rut" runat="server" CssClass="help-block" ControlToValidate="txt004" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />--%>
                                                            <%--</td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Nombre</th>
                                                <td>
                                                    <asp:TextBox ID="txt005" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Apellido Paterno</th>
                                                <td>
                                                    <asp:TextBox ID="txt006" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Apellido Materno</th>
                                                <td>
                                                    <asp:TextBox ID="txt007" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Sexo</th>
                                                <td>
                                                    <asp:RadioButton ID="rdo003" runat="server" GroupName="rdos2" OnCheckedChanged="rdo001_CheckedChanged" Text="Femenino" Checked="True" />
                                                    <asp:RadioButton ID="rdo004" runat="server" GroupName="rdos2" OnCheckedChanged="rdo001_CheckedChanged" Text="Masculino" />
                                                </td>
                                            </tr>

                                            <tr>
                                                 <th class="titulo-tabla" scope="row">Tipo de Nacionalidad</th>
                                                 <td>
                                                     <asp:DropDownList ID="ddown_tipo_nacionalidad" CssClass="form-control input-sm" runat="server" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown_tipo_nacionalidad_SelectedIndexChanged" >
                                                         <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="titulo-tabla" scope="row">Nacionalidad</th>
                                                <td>
                                                     <asp:DropDownList ID="ddow011" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown011_SelectedIndexChanged">
                                                       <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                                     </asp:DropDownList>
                                                </td>
                                            </tr>

                                          

                                        </tbody>
                                    </table>
                                </asp:Panel>

                                <asp:LinkButton ID="imb_guardar" CssClass="btn btn-danger btn-sm pull-right fixed-width-button" AutoPostback="true" runat="server" ValidationGroup="validaguardado" CausesValidation="true" OnClick="imb_guardar_Click" Visible="False">
                                </asp:LinkButton>


                            </div>
                        </div>
                    </div>
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
