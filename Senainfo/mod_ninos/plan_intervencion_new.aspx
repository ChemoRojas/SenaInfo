<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="plan_intervencion_new.aspx.cs" Inherits="mod_ninos_Nuevo_Plan_de_Intervención_plan_intervencion" %>

<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>


<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Plan de Intervención :: Senainfo :: Servicio Nacional de Menores</title>



    <%--<link rel="stylesheet" href="../css/jquery.fancybox-1.3.4.css" type="text/css" media="screen" />--%>
    <!-- Bootstrap core CSS -->
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/dataTables.bootstrap.css" rel="stylesheet" />


    <%--<script src="../js/ie-emulation-modes-warning.js"></script>--%>
    <%--<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script> 
    <script src="http://code.jquery.com/jquery-migrate-1.1.1.min.js"></script>--%>

    <%--<script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>--%>
    <%--<script src="../Script/jquery.fancybox-1.3.4.js"></script>--%>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/dataTables.bootstrap.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>
    



    <script type="text/jscript">

        //$(function () {
        //    pageLoad();
        //});

        function pageLoad(sender, args) {
            $(document).ready(function () {
                if ($("#PItxt002").length > 0){
                    $('#PItxt002').on('input propertychange', function () {
                        max(PItxt002);
                        CharLimit(this, 1000);

                    });
                }

                if ($("#PI_Stxt001").length > 0){
                    $('#PI_Stxt001').on('input propertychange', function () {
                        max2(PI_Stxt001);
                        CharLimit2(this, 200);
                    });
                }

                //$('#collapse').click(function () {
                //    collapseFixHeader('#grd001');
                //});

                if ($("#grd001").length > 0) {
                    //$("#grd001").DataTable();
                    generateDataTable($("#grd001"));
                }


                //generateDataTable("#grd001");
                //if ($("#grd001").length > 0) {
                 
                //}
                
            });
        };

        $(document).on('shown.bs.tab', 'a[data-toggle="tab"]', function (e) {
            $("#lbl005").hide();
            $("#alerts").hide();
            $("#lbl0052").hide();
            $("#alerts2").hide();
        })

        window.clickCollapse = function () {
            $('#collapse').click();
            $("#icon-collapse").removeClass(); // oculto
            $("#icon-collapse").addClass("glyphicon glyphicon-plus");
            $("#lbl_acordeon").text('Pinche aquí para mostrar los detalles de la búsqueda');
            mostrarlbl_resumen();
        }

        function clean() {
            //
            //$("#ddown006").each(function () { this.selectedIndex = 0 });
            //$("#cal003").val("seleccione");
            //$("#ddl_EtapasRealizadas").each(function () { this.selectedIndex = 0 });

            //----- DATOS
            $("#PItxt001").val("");
            $("#PIwdc001").val("");
            $("#PIwdc002").val("");
            $("#PIwdc003").val("");
            $("#PIddown001").each(function () { this.selectedIndex = 0 });
            if ($("#PItxt002").length > 0) {
                $("#PItxt002").val("");
            }
            //---- AREA
            $('#PI_Albl002').hide();
            $("#PI_Addown001").each(function () { this.selectedIndex = 0 });
            $("#PI_Addown001").each(function () { this.selectedIndex = 0 });
            //$("#PI_Agrd001 tr:not(:first-child)").html("");
            $("#PI_Agrd001").html("");
            //---- SEGUIMIENTO
            $("#PI_Sddown001").each(function () { this.selectedIndex = 0 });
            $('input[type=checkbox]').attr('checked', false); //limpia todos los checkbox
            //$('#PI_Schk001 :checked').removeAttr('checked'); //nofunca
            //$('#PI_Schk002 :checked').removeAttr('checked'); //nofunca
            $("#PI_Stxt001").val("");
            //$("#PI_Sgrd001 tr:not(:first-child)").html("");
            $("#PI_Sgrd001").html("");
            //------ CON QUIEN
            $("#PI_Cddown001").each(function () { this.selectedIndex = 0 });
            $('#PI_Clbl002').html("Seleccionar");
            $('#PI_Clbl003').html('');
            $('#PI_Clbl004').html('');
            //$("#PI_Cgrd001 tr:not(:first-child)").html("");
            $("#PI_Cgrd001").html("");
            //------ FIN
            $('#PI_Frdolist001').removeAttr('checked');
            $('#PI_Frdolist002').removeAttr('checked');
            $("#PI_Fddown001").each(function () { this.selectedIndex = 0 });
            $("#PI_Fwdc001").val("");
            //------ PANEL COMPLETO
            $('#div_panel').hide();
        }

        //es para cambiarse de tab
        //function LlamaTab(index) {
        //    igtab_selectTab("utab", index);
        //}

        //function LlamaSesiones(nFrame) {
        //    var objeto = window.frames[nFrame].document.getElementById('lnb001');
        //    objeto.click();
        //}

        //function LlamaBuscador() {
        //    var objeto = window.document.getElementById('lnb003');
        //    objeto.click();
        //}



        window.validaSeguimiento = function () {
            if ($("#PI_Sddown001").val() == 0) {
                $("#alerts").show();
                $("#lbl006").show();
                return false;
            } else {
                $("#alerts").hide();
                $("#lbl006").hide();
                return true;
            }
        }



        

        function max(PItxt002) {
            total = 1000;
            tam = PItxt002.value.length;
            str = "";
            str = str + tam;
            Digitado.innerHTML = str;
            Restante.innerHTML = total - str;

            if (tam > total) {
                //aux = PItxt002.value;
                //PItxt002.value = aux.substring(0, total);
                //Digitado.innerHTML = total
                Restante.innerHTML = 0
            }
        }
        function max2(PI_Stxt001) {
            total = 200;
            tam = PI_Stxt001.value.length;
            str = "";
            str = str + tam;
            Digitado2.innerHTML = str;
            Restante2.innerHTML = total - str;

            if (tam > total) {
                //aux = PItxt002.value;
                //PItxt002.value = aux.substring(0, total);
                //Digitado.innerHTML = total
                Restante2.innerHTML = 0
            }
        }

        function CharLimit(input, maxChar) {
            var len = $(input).val().length;
            var PIwib001 = document.getElementById('PIwib001');
            var Digitado = document.getElementById('Digitado');
            var Label14 = document.getElementById('Label14');

            if (len > maxChar) {

                $("#divCaracteres").css({ display: "block" });
                PIwib001.setAttribute("disabled", true);

                Digitado.setAttribute("style", "color:red");
                Label14.setAttribute("style", "color:red");
            }
            else {
                $("#divCaracteres").css({ display: "none" });
                PIwib001.removeAttribute("disabled");

                Digitado.setAttribute("style", "color:lead");
                Label14.setAttribute("style", "color:lead");
            }
        }

        function CharLimit2(input, maxChar) {
            var len = $(input).val().length;
            var PI_Swib001 = document.getElementById('PI_Swib001');
            var Digitado2 = document.getElementById('Digitado2');
            var Label144 = document.getElementById('Label144');

            if (len > maxChar) {

                $("#divCaracteres2").css({ display: "block" });
                PI_Swib001.setAttribute("disabled", true);

                Digitado2.setAttribute("style", "color:red");
                Label144.setAttribute("style", "color:red");
            }
            else {
                $("#divCaracteres2").css({ display: "none" });
                PI_Swib001.removeAttribute("disabled");

                Digitado2.setAttribute("style", "color:lead");
                Label144.setAttribute("style", "color:lead");
            }
        }


    </script>

</head>

<body onmousemove="SetProgressPosition(event)">

    <style>
        #wib002 {
            display: none;
        }

        .Rut {
            white-space: nowrap;
        }
    </style>
    <form id="frmPlanIntervencion" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

        <div>

            <asp:UpdatePanel ID="updatePanel6" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:PostBackTrigger ControlID="wib001" />
                    <asp:PostBackTrigger ControlID="wib003" />
                </Triggers>
                <ContentTemplate>

                    <ajax:ModalPopupExtender
                        ID="mpe1"
                        BehaviorID="mpe1a"
                        runat="server"
                        TargetControlID="imb_proyecto"
                        PopupControlID="modal_bsc_proyecto"
                        CancelControlID="bt_cerrar_buscar_proyecto"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground">
                    </ajax:ModalPopupExtender>
                    <ajax:ModalPopupExtender ID="mpe2a" BehaviorID="mpe2a" runat="server"
                        TargetControlID="imb_institucion"
                        PopupControlID="modal_bsc_institucion"
                        DropShadow="true"
                        BackgroundCssClass="modalBackground"
                        CancelControlID="bt_cerrar_buscar_institucion">
                    </ajax:ModalPopupExtender>
                    <!-- modales -->
                    <div id="divContenido">
                        <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" aria-label="Close" ID="bt_cerrar_buscar_institucion" runat="server" Text="Cerrar" CausesValidation="false">
                                                            <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">INSTITUCION</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                    </div>
                    <div id="divContenido2">

                        <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" aria-label="Close" ID="bt_cerrar_buscar_proyecto" runat="server" Text="Cerrar" CausesValidation="false">
                                                            <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">PROYECTO</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                    </div>
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a href="../index.aspx">Inicio</a></li>
                            <li class="active">Niños</li>
                            <li class="active">Plan de Intervención</li>
                        </ol>

                     
                        <div class="alert alert-success text-center" role="alert" id="alerts2" runat="server" style="margin-top: 10px; display: none">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp;
                            <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                        </div>

                        <div class="well">
                            <h4 class="subtitulo-form">Plan de Intervención</h4>
                            <hr>



                            <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                                <asp:Label ID="lbl_acordeon" runat="server" Visible="true" Text="Ocultar Detalles de la Búsqueda"></asp:Label>
                                <span id="icon-collapse" class="glyphicon glyphicon-triangle-top"></span>
                                <asp:Label ID="lbl_resumen_filtro" runat="server" Visible="false" Text=""></asp:Label>
                                <asp:Label ID="lbl_resumen_proyecto" runat="server" Visible="false"></asp:Label>
                            </a>


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
                                                        <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:LinkButton ID="imb_institucion" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion', '../mod_ninos/plan_intervencion_new.aspx','mpe2a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Proyecto:</label>
                                                </th>
                                                <td>
                                                    <div class="input-group">
                                                        <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm">
                                                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:LinkButton ID="imb_proyecto" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_ninos/plan_intervencion_new.aspx','mpe1a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="tr_Nombres">
                                                <th>
                                                    <label for="">Nombre del Niño(a):</label>

                                                </th>
                                                <td>
                                                    <asp:TextBox ID="TextBox2" Enabled="false" CssClass="form-control input-sm" TextMode="SingleLine" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="tr_apellidoPaterno">
                                                <th>
                                                    <label for="">Apellido Paterno:</label>
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txt001" Enabled="false" CssClass="form-control input-sm" TextMode="SingleLine" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="tr_apellidoMaterno">
                                                <th>
                                                    <label for="">Apellido Materno:</label>

                                                </th>
                                                <td>
                                                    <asp:TextBox ID="TextBox1" Enabled="false" CssClass="form-control input-sm" TextMode="SingleLine" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <!--gfontbrevis nuevo estandar de botones -->
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <th></th>
                                                <td>
                                                    <asp:LinkButton ID="btnbuscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btnbuscar_Click" Text="Buscar" AutoPostback="true">
                                    <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="Button1" CssClass="btn btn-info btn-sm fixed-width-button" Visible="false" runat="server" Text="Filtrar" CausesValidation="False" OnClick="Button1_Click">
                                        <span class="glyphicon glyphicon-filter"></span>&nbsp;Filtrar
                                                    </asp:LinkButton>

                                                    <asp:LinkButton ID="wib003" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="wib003_Click" Text="Limpiar" OnClientClick="clean()">
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
                                        <div>
                                            <asp:Label ID="lbl001_aviso" runat="server" CssClass="help-block" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <table class="table table-borderless table-condensed">

                                    <tr>
                                        <td colspan="2">
                                            <div class="col-md-9">
                                                <h4>
                                                    <asp:Label ID="lbl001" CssClass="subtitulo-form" runat="server" Text="Niños Seleccionados Plan Intervención" Visible="False"></asp:Label></h4>

                                                <asp:Label ID="lbl003" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <asp:GridView ID="grd002" runat="server"  AutoGenerateColumns="False" CssClass="table table-hover table-bordered text-center"
                                                Visible="False" OnRowCommand="grd002_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="CodPlanIntervencion" HeaderText="Cod. Plan Intervención" Visible="False"></asp:BoundField>
                                                    <asp:BoundField DataField="CodNino" HeaderText="Código Niño"></asp:BoundField>
                                                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                                    <asp:BoundField DataField="Rut" HeaderText="RUN"></asp:BoundField>
                                                    <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                                                    <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="Fecha de Nacimiento" HtmlEncode="False"></asp:BoundField>
                                                    <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="Fecha de Ingreso" HtmlEncode="False"></asp:BoundField>
                                                    <asp:ButtonField CommandName="Quitar" Text="Quitar" HeaderText="Seleccionar" ItemStyle-CssClass="text-center"></asp:ButtonField>
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="table-bordered caja-tabla" />
                                            </asp:GridView>
                                            <div>
                                                <asp:LinkButton ID="wib001" runat="server" Visible="false" CssClass="btn btn-danger btn-sm pull-right " OnClick="wib001_Click" CausesValidation="false">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbspCrear Plan de Intervención
                                                </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trmenu" runat="server" visible="false">
                                        <td colspan="2">
                                            <div class="col-md-9">
                                            </div>
                                            <div class="col-md-3" style="text-align: center">
                                                <asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="wib002" Visible="false" runat="server" Text="Ver Estados PII" OnClick="wib002_Click" CausesValidation="false" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr visible="False" id="trgrd001" runat="server">
                                        <td colspan="2">

                                            <%--<div id="tableHeader1" class="fixed-header"></div>--%>
                                            <%--<div id="tableContainer1" class="fixed-header-table-container">--%>
                                            <asp:GridView ID="grd001" runat="server" data-name="grd001" AutoGenerateColumns="False" CssClass="table table-bordered"
                                                OnRowCommand="grd001_RowCommand" OnPageIndexChanging="grd001_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="CodNino" HeaderText="Cód Niño"></asp:BoundField>
                                                    <asp:BoundField DataField="pii" HeaderText="PII" Visible="False"></asp:BoundField>
                                                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                                    <asp:BoundField DataField="Rut" HeaderText="RUN"></asp:BoundField>
                                                    <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                                                    <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="Fecha de Nacimiento" HtmlEncode="False"></asp:BoundField>
                                                    <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="Fecha de Ingreso" HtmlEncode="False"></asp:BoundField>

                                                    <asp:ButtonField CommandName="Agregar" Text="Agregar" HeaderText="Seleccionar" ItemStyle-CssClass="text-center"></asp:ButtonField>
                                                </Columns>
                                                <%--<FooterStyle CssClass="titulo-tabla" ForeColor="White" />--%>
                                                <HeaderStyle CssClass="Rut titulo-tabla" />
                                                <%--<PagerStyle CssClass="pager-tabla" ForeColor="White" />--%>
                                                <RowStyle CssClass="Rut text-center" />


                                            </asp:GridView>
                                            <%--</div>--%>

                                        </td>
                                    </tr>
                                </table>



                            <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" style="margin-top: 10px; display: none">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;
                            <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                            <asp:Label ID="lbl006" runat="server" Style="display: none;" Text="Debe ingresar un estado de Intervención"></asp:Label>
                            </div>

                            <asp:Label ID="PI_Albl001" CssClass="titulo-form" runat="server" Text="Ingrese Área de Intervención (Máximo seis)"></asp:Label></h4>
                            <asp:Label ID="PI_Albl002" runat="server" CssClass="help-block" Text="* Debe seleccionar Tipo Intervención y Nivel de Intervención."
                             Visible="False"></asp:Label>


                                <%--GMP INICIO--%>
                                <div id="div_panel" runat="server" visible="false">
                                    <%--<asp:Panel ID="utab" runat="server" CssClass="">--%>
                                    <!-- Titulos Tabs FUO -->
                                    <div>
                                        <ul id="Ul1" class="nav nav-tabs tab-fixed-height nav-justified" role="tablist">
                                            <li id="li_nav1" runat="server" role="presentation" class="active">
                                                <a id="link_tab1" runat="server" href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab">1 - DATOS PLAN DE INTERVENCION
                                                </a>
                                            </li>
                                            <li id="li_nav2" runat="server" role="presentation">
                                                <a id="link_tab2" runat="server" href="#tab2" aria-controls="tab2" role="tab" class="disabled-nav-tabs">2 - AREA DE INTERVENCION
                                                </a>
                                            </li>
                                            <li id="li_nav3" runat="server" role="presentation">
                                                <a id="link_tab3" runat="server" href="#tab3" aria-controls="tab3" role="tab" class="disabled-nav-tabs">3 - SEGUIMIENTO DE INTERVENCION
                                                </a>
                                            </li>
                                            <li id="li_nav4" runat="server" role="presentation">
                                                <a id="link_tab4" runat="server" href="#tab4" aria-controls="tab4" role="tab" class="disabled-nav-tabs">4 - CON QUIEN PUEDE TRABAJAR EL EGRESO

                                                </a>
                                            </li>
                                            <li id="li_nav5" runat="server" role="presentation">
                                                <a id="link_tab5" runat="server" href="#tab5" aria-controls="tab5" role="tab" class="disabled-nav-tabs">4 - TERMINO DE LA INTERVENCION
                                                </a>
                                            </li>
                                        </ul>
                                    </div>
                                    <%--<div>
                             <ul id="myTabs" class="nav nav-utab nav-tabs" role="tablist">
                                 <li id="li_nav1" runat="server" role="presentation" class="active" >
                                    <asp:linkButton id="link_tab1" runat="server" aria-controls="tab1"  role="tab" data-toggle="tab" Onclick="link_tab1_Click" CausesValidation="true" CssClass="btn-block">Datos del Plan de intervención
                                    </asp:linkButton>
                                </li>
                                <li id="li_nav2" runat="server" role="presentation" style="display: none">
                                    <asp:linkButton id="link_tab2" runat="server" aria-controls="tab2" role="tab" data-toggle="tab" OnClick="link_tab2_Click" CausesValidation="true" >Area de Intervención 
                                    </asp:linkButton>
                                </li>
                                <li id="li_nav3" runat="server" role="presentation" style="display: none">
                                    <asp:linkButton id="link_tab3" runat="server" aria-controls="tab3" role="tab" data-toggle="tab" OnClick="link_tab3_Click" CausesValidation="true" >Seguimiento del Plan de Intervención
                                    </asp:linkButton>
                                </li>
                                <li id="li_nav4" runat="server" role="presentation" style="display: none">
                                    <asp:linkButton id="link_tab4" runat="server" aria-controls="tab4" role="tab" data-toggle="tab" OnClick="link_tab4_Click" CausesValidation="true">Con Quien Puede Trabajar el Egreso
                                    </asp:linkButton>
                                </li>
                                <li id="li_nav5" runat="server" role="presentation" style="display: none">
                                    <asp:linkButton id="link_tab5" runat="server" aria-controls="tab5" role="tab" data-toggle="tab" OnClick="link_tab5_Click" CausesValidation="true">Término de la Intervención
                                    </asp:linkButton>
                                </li>
                             </ul>
                         </div>--%>
                                    <div class="tab-content">
                                        <div role="tabpanel" class="tab-pane fade in active" id="tab1" runat="server">
                                            <asp:Panel ID="pnl_utab1" runat="server" Visible="true">
                                                <div id="Plan_intervencion_datos">

                                                    <h4>
                                                        <asp:Label ID="lblTitPI" CssClass="titulo-form" runat="server" Text="Plan de Intervención"></asp:Label></h4>


                                                    <table class="table table-bordered table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-1" scope="row">
                                                                <asp:Label ID="lblTitPIIdent" runat="server" Text="Identificación del Grupo *"></asp:Label></th>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="PItxt001" runat="server" Visible="False" CssClass="form-control input-sm" />
                                                                <%--<ajax:MaskedEditExtender ID="PIMaskedEditExtender1" PromptCharacter=""  runat="server" TargetControlID="PItxt001" MaskType="None" InputDirection="RightToLeft" ErrorTooltipEnabled="True" DisplayMoney="None" Mask="$$$$$$$$$$$$$$$$$$$$$$$$$" />--%>

                                                                <asp:Label ID="PIlbl003" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>

                                                            <th class="titulo-tabla" scope="row">Fecha Elaboración PII *</th>
                                                            <td class="col-md-4">

                                                                <asp:TextBox ID="PIwdc001" runat="server" onkeypress="return false;" placeholder="dd-mm-aaaa" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="PIwdc001_ValueChanged" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" CausesValidation="false"></asp:TextBox>
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="PICalendarExtender_wdc001" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="PIwdc001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                                <asp:RangeValidator ID="RV_PIwdc001" runat="server" ErrorMessage="Fecha Invalida" ControlToValidate="PIwdc001" Type="Date" CssClass="help-block" Display="Dynamic" />
                                                                <%--<ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="PIwdc001" ValidChars="0123456789-/" />--%>
                                                                <asp:Label ID="PIlbl004" runat="server" ForeColor="Red"></asp:Label></td>


                                                            <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio PII *</th>
                                                            <td>

                                                                <asp:TextBox ID="PIwdc002" runat="server" onkeypress="return false;" placeholder="dd-mm-aaaa" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="PIwdc002_ValueChanged" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                                                                <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="PICalendarExtender_wdc002" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="PIwdc002" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                                <asp:RegularExpressionValidator ID="PIRegularExpressionValidator2" Enabled="true" ControlToValidate="PIwdc002" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Inv&aacute;lida" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="PIwdc002" ValidChars="0123456789-/" />
                                                                &nbsp;<asp:Label ID="PIlbl005" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Fecha de Término estimada de PII *</th>
                                                            <td>

                                                                <asp:TextBox ID="PIwdc003" runat="server" onkeypress="return false;" placeholder="dd-mm-aaaa" TextMode="SingleLine" MaxLength="10"  CssClass="form-control form-control-fecha-large input-sm"></asp:TextBox>
                                                                <ajax:CalendarExtender ID="PICalendarExtender_wdc003" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="PIwdc003" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                                <asp:RegularExpressionValidator ID="PIRegularExpressionValidator1" Enabled="true" ControlToValidate="PIwdc003" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="PIwdc003" ValidChars="0123456789-/" />
                                                                &nbsp;<asp:Label ID="PIlbl006" runat="server" Visible="False"></asp:Label>

                                                            </td>

                                                            <th class="titulo-tabla" scope="row">Profesional/Técnico *</th>
                                                            <td>
                                                                <asp:DropDownList ID="PIddown001" runat="server" CssClass="form-control input-sm">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="titulo-tabla" scope="row">Descripción</th>
                                                            <td colspan="3">
                                                                <cc1:SenameTextBox ID="PItxt002" runat="server" CssClass="form-control input-sm"></cc1:SenameTextBox>
                                                                <asp:Label ID="Label13" runat="server" Text="Máximo 1000 caracteres:"></asp:Label>
                                                                <asp:Label ID="Label14" runat="server" Text="Escritos"></asp:Label>
                                                                <asp:Label ID="Digitado" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                                                <asp:Label ID="Label15" runat="server" Text="Restantes"></asp:Label>
                                                                <asp:Label ID="Restante" runat="server" Text="1000"></asp:Label>

                                                                <div class="alert alert-warning text-center" role="alert" id="divCaracteres" runat="server" style="display: none">
                                                                    <span class="glyphicon glyphicon-warning-sign"></span>
                                                                    <asp:Label ID="lblbmsg" runat="server" Text="Se han sobrepasado el límite de 1000 caracteres"></asp:Label>
                                                                </div>

                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td colspan="4">

                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right " ID="PIwib001" runat="server" OnClick="PIwib001b_Click">
                                                                    <span class="glyphicon glyphicon-arrow-right" id="Span13"></span>&nbsp;Siguiente
                                                                </asp:LinkButton>

                                                            </td>
                                                        </tr>
                                                    </table>

                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="tab2" runat="server">
                                            <asp:Panel ID="pnl_utab2" runat="server" Visible="true">
                                                <div id="plan_intervencion_area" style="height: auto;">

                                                    <h4>
                                                      


                                                    <asp:GridView ID="PI_Agrd001" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered table-hover"
                                                        OnRowCommand="PI_Agrd001_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="TipoIntervencion" HeaderText="Tipo Intervenci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="DescripcionTipo" HeaderText="Descripci&#243;n Tipo Intervenci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="NivelIntervencion" HeaderText="Nivel de Intervenci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="DescripcionNivel" HeaderText="Descripci&#243;n Nivel Intervenci&#243;n"></asp:BoundField>
                                                            <asp:ButtonField CommandName="Quitar" Text="Quitar" HeaderText="Seleccionar"></asp:ButtonField>
                                                            <asp:BoundField DataField="Chequea">
                                                                <ControlStyle BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"
                                                                    BorderWidth="0px" ForeColor="Transparent" />
                                                                <ItemStyle BackColor="Transparent" BorderColor="Transparent" Font-Size="1px" ForeColor="White"
                                                                    Width="1px" />
                                                                <HeaderStyle BackColor="Transparent" BorderColor="Transparent" ForeColor="Transparent" />
                                                                <FooterStyle BackColor="Transparent" BorderColor="Transparent" ForeColor="Transparent" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="IdGrupoIntervenciones">
                                                                <ItemStyle BackColor="Transparent" BorderColor="Transparent" Font-Size="1px" ForeColor="White"
                                                                    Width="1px" />
                                                                <HeaderStyle BackColor="Transparent" BorderColor="Transparent" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                                    </asp:GridView>

                                                    <table class="table table-borderless table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla-centrado ">
                                                                <asp:Label ID="PI_Albl003" runat="server" Text="Tipo de Intervención *"></asp:Label>
                                                            </th>
                                                            <th class="titulo-tabla-centrado">
                                                                <asp:Label ID="PI_Albl004" runat="server" Text="Nivel de Intervención *"></asp:Label>
                                                            </th>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="PI_Addown001" runat="server" CssClass="form-control input-sm">
                                                                </asp:DropDownList></td>
                                                            <td>
                                                                <asp:DropDownList ID="PI_Addown002" runat="server" CssClass="form-control input-sm">
                                                                </asp:DropDownList></td>

                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div class="pull-right">
                                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="PI_Awib001" runat="server" OnClick="PI_Awib001_Click">
                                                                               <span class="glyphicon glyphicon-ok" id="Span2"></span>&nbsp;Agregar
                                                                    </asp:LinkButton>

                                                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="PI_Awib002" runat="server" OnClick="PI_Awib002_Click">
                                                                                <span class="glyphicon glyphicon-arrow-right" id="Span1"></span>&nbsp;Siguiente
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="tab3" runat="server">
                                            <br />
                                            <asp:Panel ID="pnl_utab3" runat="server" Visible="true">
                                                <div id="plan_intervencion_seguimiento">

                                                    <asp:Label ID="PI_Slbl002" runat="server" Text="Estados del Plan" Visible="False"></asp:Label></td>
                                                
                                                    <asp:GridView ID="PI_Sgrd001" runat="server" AutoGenerateColumns="False" CssClass="table table table-bordered table-hover"
                                                        Visible="False" OnRowCommand="PI_Sgrd001_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="FechaCreacion" DataFormatString="{0:d}" HeaderText="Fecha Creacion" HtmlEncode="False"></asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n"></asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                    <table class="table table-bordered table-condensed text-center">
                                                        <tr>
                                                            <th class="titulo-tabla-centrado">
                                                                <asp:Label ID="PI_Slbl001" runat="server" Text="Estado de Intervención *"></asp:Label>
                                                            </th>
                                                            <th class="titulo-tabla-centrado">Colaboración Niño(a)</th>
                                                            <th class="titulo-tabla-centrado">Participación Familia</th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="PI_Sddown001" runat="server" CssClass="form-control input-sm">
                                                                </asp:DropDownList></td>
                                                            <td>
                                                                <asp:CheckBox ID="PI_Schk001" runat="server" /></td>
                                                            <td>
                                                                <asp:CheckBox ID="PI_Schk002" runat="server" /></td>
                                                        </tr>
                                                    </table>
                                                    <table class="table table-bordered table-condensed tabla-tabs">
                                                        <tr>
                                                            <th class="titulo-tabla col-md-1">Observaciones</th>
                                                            <td>
                                                                <cc1:SenameTextBox ID="PI_Stxt001" runat="server" CssClass="form-control input-sm"></cc1:SenameTextBox>
                                                                <asp:Label ID="Label133" runat="server" Text="Máximo 200 caracteres:"></asp:Label>
                                                                <asp:Label ID="Label144" runat="server" Text="Escritos"></asp:Label>
                                                                <asp:Label ID="Digitado2" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                                    <asp:Label ID="Label155" runat="server" Text="Restantes"></asp:Label>
                                                                <asp:Label ID="Restante2" runat="server" Text="200"></asp:Label>

                                                                <div class="alert alert-warning text-center" role="alert" id="divCaracteres2" runat="server" style="display: none">
                                                                    <span class="glyphicon glyphicon-warning-sign"></span>
                                                                    <asp:Label ID="lblbmsg2" runat="server" Text="Se han sobrepasado el límite de 200 caracteres"></asp:Label>
                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="2">
                                                                <div>
                                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button pull-right" ID="PI_Swib001" runat="server" Text="Siguiente >" OnClick="PI_Swib001_Click" OnClientClick="return validaSeguimiento();">
                                                           <span class="glyphicon glyphicon-arrow-right" id="Span3"></span>&nbsp;Siguiente
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--<asp:LinkButton ID="PI_Slnb001" runat="server" OnClick="PI_Slnb001_Click"></asp:LinkButton>--%>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="tab4" runat="server">

                                            <asp:Panel ID="pnl_utab4" runat="server" Visible="true">
                                                <div id="Plan_intervencion_con_quien" style="height: auto;">
                                                    <asp:GridView ID="PI_Cgrd001" runat="server" AutoGenerateColumns="False" CellPadding="3" CssClass="table table table-bordered table-hover"
                                                        GridLines="None" Width="100%" OnRowCommand="PI_Cgrd001_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombre"></asp:BoundField>
                                                            <asp:BoundField DataField="CodPersonaRelacionada" HeaderText="Cod. Persona Relacionada"></asp:BoundField>
                                                            <asp:BoundField DataField="descripcion" HeaderText="Tipo de Relaci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="fecharelacion" DataFormatString="{0:d}" HeaderText="Fecha Relaci&#243;n"
                                                                HtmlEncode="False"></asp:BoundField>
                                                            <asp:ButtonField CommandName="Quitar" Text="Quitar"></asp:ButtonField>
                                                            <asp:BoundField DataField="chequea"></asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>


                                                    <table class="table table-bordered table-condensed text-center tabla-tabs">
                                                        <tr class="text-center">
                                                            <th class="titulo-tabla-centrado">
                                                                <asp:Label ID="PI_Clbl001" runat="server" Text="Persona Relacionada *"></asp:Label>
                                                            </th>
                                                            <th class="titulo-tabla-centrado">Nombre</th>
                                                            <th class="titulo-tabla-centrado">Tipo de Relacion</th>
                                                            <th class="titulo-tabla-centrado">Fecha Relación</th>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="PI_Cddown001" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="PI_Cddown001_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                            <td class="text-center">
                                                                <asp:Label ID="PI_Clbl002" runat="server"></asp:Label></td>
                                                            <td class="text-center">
                                                                <asp:Label ID="PI_Clbl003" runat="server"></asp:Label></td>
                                                            <td class="text-center">
                                                                <asp:Label ID="PI_Clbl004" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>

                                                            <td colspan="4" class="text-center">
                                                                <div class="pull-right">
                                                                    <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="PI_Cwib001" runat="server" Text="Agregar" OnClick="PI_Cwib001_Click">
                                                           <span class="glyphicon glyphicon-ok" id="Span5"></span>&nbsp;Agregar

                                                                    </asp:LinkButton>
                                                                    <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="PI_Cbut001" runat="server" Text="Grabar" OnClick="PI_Cbut001_Click">
                                                           <span class="glyphicon glyphicon-ok" id="Span6"></span>&nbsp;Grabar Todo

                                                                    </asp:LinkButton>

                                                                </div>

                                                            </td>

                                                        </tr>
                                                    </table>
                                                    <%--<asp:LinkButton ID="PI_Clnb002" runat="server" OnClick="PI_Clnb002_Click"></asp:LinkButton>--%>
                                                    <%--<input id="PI_Cbut001" class="capsula" onclick="window.parent.LlamaSesiones(0);" type="button" value="Grabar" />--%>
                                                    <%--<asp:Button CssClass="btn btn-info btn-sm btn-margen" ID="PI_Cwib002" runat="server" Text="Siguiente >>"  Visible="False" OnClick="PI_Cwib002_Click" />--%>

                                                    <%--<asp:LinkButton ID="PI_Clnb001" runat="server" OnClick="PI_Clnb001_Click"></asp:LinkButton>--%>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div role="tabpanel" class="tab-pane fade" id="tab5" runat="server">
                                            <asp:Panel ID="pnl_utab5" runat="server" Visible="true">
                                                <div id="Plan_intervencion_termino">
                                                    <h4>
                                                        <asp:Label ID="PI_Flbl002" runat="server" CssClass="titulo-form">Término (Sólo completar si el Plan de Intervención ha concluido)</asp:Label></h4>
                                                    </td>

                                        <table class="table table-bordered table-condensed tabla-tabs">
                                            <tr>
                                                <th class="titulo-tabla col-md-1">Intervención Completa</th>
                                                <td class="col-md-4">
                                                    <div class="text-center ">

                                                        <asp:RadioButtonList ID="PI_Frdolist001" runat="server" align="center" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>

                                                <th class="titulo-tabla col-md-1">Habilitado para Egreso</th>
                                                <td>
                                                    <div class="text-center ">
                                                        <asp:RadioButtonList ID="PI_Frdolist002" runat="server" align="center" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla">Grado de Cumplimiento</th>
                                                <td>
                                                    <asp:DropDownList ID="PI_Fddown001" runat="server" CssClass="form-control input-sm">
                                                    </asp:DropDownList></td>

                                                <th class="titulo-tabla">Fecha Real Término</th>
                                                <td>

                                                    <asp:TextBox ID="PI_Fwdc001" onkeypress="return false;" runat="server" placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha-large input-sm" TextMode="SingleLine" ReadOnly="false" OnTextChanged="PI_Fwdc001_ValueChanged"></asp:TextBox>
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="PI_FCalendarExtender_wdc001" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="PI_Fwdc001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>

                                                    <asp:Label ID="PI_Flbl001" runat="server"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="4">
                                                    <div>
                                                        <asp:LinkButton ID="PI_Flnb001" CssClass="btn btn-danger btn-sm fixed-width-button pull-right" runat="server" OnClick="PI_Flnb001_Click1">
                                                           <span class="glyphicon glyphicon-ok" id="Span4"></span>&nbsp;Grabar Todo

                                                        </asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                                    <%-- <asp:LinkButton ID="PI_Flnb001" runat="server" OnClick="PI_Flnb001_Click"></asp:LinkButton>--%>
                                                    <%-- <br />
                                        <input id="PI_Fbut001" type="button" class="capsula" value="Grabar" onclick="window.parent.LlamaSesiones(0);" />--%>
                                                </div>

                                            </asp:Panel>
                                        </div>

                                    </div>
                                    <%-- </asp:Panel>--%>
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
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatePanel6">
                <ProgressTemplate>
                    <div id="divProgress" class="ajax_cargando">
                        <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                        Cargando...       
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <script src="../js/bootstrap.min.js"></script>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
        <!-- Latest compiled and minified JavaScript -->
        <div class="container theme-showcase">
            <asp:LinkButton ID="lnb003" runat="server" OnClick="lnb003_Click"></asp:LinkButton>
        </div>

    </form>
</body>
</html>
