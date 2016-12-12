<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_diagnosticoninos.aspx.cs" Inherits="mod_ninos_ninos_diagnosticoninos" %>

<%@ Register Src="DiagnosticoEscolar.ascx" TagName="DiagnosticoEscolar" TagPrefix="uc1" %>
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
    <title>Diagnósticos del Niño :: Senainfo :: Servicio Nacional de Menores</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <%--<script src="../js/jquery-1.7.2.min.js"></script>--%>
    <script src="../js/jquery-ui.js"></script>
    <%--<script src="../js/bootstrap.min.js"></script>c--%>
    <script src="../js/senainfoTools.js"></script>

    <style type="text/css">
        .ocultar-columna {
            display: none;
        }

        th {
            white-space: nowrap;
        }
        .nav .open > a,
        .nav .open > a:hover,
        .nav .open > a:focus {
          background-color: #F59806;
          border-color: #337ab7;
          }

        .dropdown-menu>.active>a, .dropdown-menu>.active>a:hover, .dropdown-menu>.active>a:focus {
        color: #000;
        text-decoration: none;
        outline: 0;
        background-color: #FFFFFF;
        }

        .dropdown-menu > .active > a, .dropdown-menu > .active > a:hover, .dropdown-menu > .active > a:focus
        {
            background-image: -webkit-linear-gradient(top, #FFFFFF 0, #FFFFFF 100%);
        }
    </style>


    <script type="text/javascript">
        function RefrescaPadre() {
            var link = document.getElementById("Atmp");
            link.click();
        };
        function MostrarIframeUtab1() {
            var objIframetab1 = document.getElementById('iframe_utab1');
            if (objIframetab1.src == "") {
                objIframetab1.src = "../mod_ninos/ninos_DiagnisticoEscolar.aspx";
                objIframetab1.height = "50%";
                objIframetab1.width = "50%";
            }
            return false;
        }

        //function Mostrar_Cargando() {
        //    limpiaiframe(document.getElementById('iframe_utab2'));
        //    limpiaiframe(document.getElementById('iframe_utab3'));
        //    limpiaiframe(document.getElementById('iframe_utab4'));
        //    limpiaiframe(document.getElementById('iframe_utab5'));
        //    limpiaiframe(document.getElementById('iframe_utab6'));
        //    limpiaiframe(document.getElementById('iframe_utab7'));
        //    limpiaiframe(document.getElementById('iframe_utab8'));
        //    limpiaiframe(document.getElementById('iframe_utab9'));
        //    limpiaiframe(document.getElementById('iframe_utab10'));
        //    limpiaiframe(document.getElementById('iframe_utab11'));

        //}
        function limpiaiframe(objIframe) {

            if (objIframe) {
                frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
                frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
            }
        }

        function mostrar_cargando2(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 35%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
        }


        function MostrarIframeUtab2() {
            
            var objIframetab2 = document.getElementById('iframe_utab2');
            if (objIframetab2.src == "") {
                limpiaiframe(document.getElementById('iframe_utab2'));
                objIframetab2.src = "../mod_ninos/ninos_DiagnosticoMaltrato.aspx";
                objIframetab2.height = "100%";
                objIframetab2.width = "100%";
            }
            return false;   
        }
        function MostrarIframeUtab3() {
            
            var objIframetab3 = document.getElementById('iframe_utab3');
            if (objIframetab3.src == "") {
                limpiaiframe(document.getElementById('iframe_utab3'));
                objIframetab3.src = "../mod_ninos/ninos_DiagnosticoDroga.aspx";
                objIframetab3.height = "100%";
                objIframetab3.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab4() {
            
            var objIframetab4 = document.getElementById('iframe_utab4');
            if (objIframetab4.src == "") {
                limpiaiframe(document.getElementById('iframe_utab4'));
                objIframetab4.src = "../mod_ninos/DiagnosticoPsicologico.aspx";
                objIframetab4.height = "100%";
                objIframetab4.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab5() {
            
            var objIframetab5 = document.getElementById('iframe_utab5');
            if (objIframetab5.src == "") {
                limpiaiframe(document.getElementById('iframe_utab5'));
                objIframetab5.src = "../mod_ninos/DiagnosticoSocial.aspx";
                objIframetab5.height = "100%";
                objIframetab5.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab6() {
            
            var objIframetab6 = document.getElementById('iframe_utab6');
            if (objIframetab6.src == "") {
                limpiaiframe(document.getElementById('iframe_utab6'));
                objIframetab6.src = "../mod_ninos/CapacitacionNino.aspx";
                objIframetab6.height = "100%";
                objIframetab6.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab7() {
           
            var objIframetab7 = document.getElementById('iframe_utab7');
            if (objIframetab7.src == "") {
                limpiaiframe(document.getElementById('iframe_utab7'));
                objIframetab7.src = "../mod_ninos/SituacionLaboral.aspx";
                objIframetab7.height = "100%";
                objIframetab7.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab8() {
            
            var objIframetab8 = document.getElementById('iframe_utab8');
            if (objIframetab8.src == "") {
                limpiaiframe(document.getElementById('iframe_utab8'));
                objIframetab8.src = "../mod_ninos/HechosJudiciales.aspx";
                objIframetab8.height = "100%";
                objIframetab8.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab9() {
            
            var objIframetab9 = document.getElementById('iframe_utab9');
            if (objIframetab9.src == "") {
                limpiaiframe(document.getElementById('iframe_utab9'));
                objIframetab9.src = "../mod_ninos/PeoresFormas.aspx";
                objIframetab9.height = "100%";
                objIframetab9.width = "100%";
            }
            return false;
        }
        function MostrarIframeUtab10() {            

            limpiaiframe(document.getElementById('iframe_utab10'));
            var objIframetab10 = document.getElementById('iframe_utab10');
            //if (objIframetab10.src == "") {
                objIframetab10.src = "../mod_ninos/DiagnosticoSalud_FichaSaludInicial.aspx";
                objIframetab10.height = "100%";
                objIframetab10.width = "100%";
            //}

            
            return false;
        }

        function MostrarIframeUtab11() {

            limpiaiframe(document.getElementById('iframe_utab11'));
            var objIframetab11 = document.getElementById('iframe_utab11');
            //if (objIframetab11.src == "") {
                objIframetab11.src = "../mod_ninos/DiagnosticoSalud_FichaSaludPosterior.aspx";
                objIframetab11.height = "100%";
                objIframetab11.width = "100%";
            //}
            
            return false;
        }

        function MostrarIframeUtab12() {
            
            var objIframetab12 = document.getElementById('iframe_utab12');
            if (objIframetab12.src == "") {
                limpiaiframe(document.getElementById('iframe_utab12'));
                objIframetab12.src = "../mod_ninos/AntecedentesJudicialesPRJ.aspx";
                objIframetab12.height = "100%";
                objIframetab12.width = "100%";
            }

            return false;
        }

        function MostrarFichaPosterior() {
            $('#li_FichaSaludPosterior').attr('style', 'display:block;');
        }
        
        

    </script>
</head>
<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="imb_limpiardiag" />
                <asp:AsyncPostBackTrigger ControlID="ddown001" />


            </Triggers>
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" BehaviorID="mpe1a" runat="server"
                    TargetControlID="imb_institucion"
                    PopupControlID="modal_buscar_institucion"
                    CancelControlID="bt_cerrar_buscar_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe2" BehaviorID="mpe2a" runat="server"
                    TargetControlID="imb_proyecto"
                    PopupControlID="modal_buscar_proyecto"
                    CancelControlID="bt_cerrar_buscar_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender ID="mpe3" BehaviorID="mpe3a" runat="server"
                    TargetControlID="imb_historicos"
                    PopupControlID="modal_historicos"
                    CancelControlID="bt_cerrar_mostrar_historico"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <asp:LinkButton ID="imb_historicos" runat="server" CausesValidation="False"></asp:LinkButton>
                <div class="popupConfirmation" id="modal_historicos" style="display: none">
                    <asp:LinkButton ID="gatillo" runat="server" AutoPostback="true" style="display:none"></asp:LinkButton>
                    <div class="modal-header header-modal">
                        <asp:LinkButton CssClass="close" aria-label="Close" ID="bt_cerrar_mostrar_historico" runat="server" Text="Cerrar" CausesValidation="false">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                        <h4 class="modal-title">Históricos</h4>
                    </div>
                    <div>
                        <iframe id="iframe_historicos" runat="server" frameborder="0"></iframe>
                    </div>
                </div>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Diagnósticos del Niño</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">
                            <asp:Label ID="lbl_titulo" runat="server">Diagnósticos del Niño</asp:Label>
                        </h4>
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
                                                    <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_institucion" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan%20de%20Intervencion', '../mod_ninos/ninos_diagnosticoninos.aspx','mpe1a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>
                                                <div id="divContenido">
                                                    <div class="popupConfirmation" id="modal_buscar_institucion" style="display: none">
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Proyecto:</label>
                                            </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddown002" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddown002_SelectedIndexChanged"  runat="server">
                                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_proyecto" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_ninos/ninos_diagnosticoninos.aspx','mpe2a')" runat="server" CausesValidation="False">
                                                <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                            <td>
                                                <div id="divContenido2">

                                                    <div class="popupConfirmation" id="modal_buscar_proyecto" style="display: none">
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Nombre del Niño(a):</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt005" CssClass="form-control input-sm form-control-60" runat="server" AutoCompleteType="FirstName" placeholder="Ingresar nombre"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Paterno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt003" CssClass="form-control input-sm form-control-60" runat="server" AutoCompleteType="LastName" placeholder="Ingresar Apellido"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">Apellido Materno:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt004" CssClass="form-control input-sm form-control-60" runat="server" AutoCompleteType="LastName" placeholder="Ingresar Apellido"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr_fecha_nacimiento" runat="server" visible="false">

                                            <th>
                                                <label for="">Fecha de Nacimiento:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt006" CssClass="form-control input-sm form-control-fecha-large" runat="server" AutoCompleteType="LastName" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr_fecha_ingreso" runat="server" visible="false">
                                            <th>
                                                <label for="">Fecha de Ingreso:</label>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txt007" runat="server" AutoCompleteType="LastName" CssClass="form-control input-sm form-control-fecha-large" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <!--gfontbrevis nuevo estandar de botones -->
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th></th>
                                            <td>
                                                <asp:LinkButton ID="imb_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="imb_buscar_Click" Text="Buscar" AutoPostback="true">
                                    <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="imb_limpiardiag" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="imb_limpiardiag_Click" Text="Limpiar">
                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-3">


                                    <%--<div class="caja-despliegue">
                                    <asp:Label ID="lbl001F2" runat="server" Text="El Tiempo de Carga de la información dependerá de la cantidad de registros."></asp:Label>
                                </div>--%>
                                    
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

                            <div class="col-md-12">
                                <div>
                                    <!-- inicio gfontbrevis se agrega para fijar header -->
                                    <div id="tableHeader" class="fixed-header"></div>
                                    <div id="tableContainer" class="fixed-header-table-container">
                                        <asp:GridView ID="grd001" CssClass="table  table-bordered table-hover caja-tabla" runat="server" AutoPostback="true" AutoGenerateColumns="False" CellPadding="4" GridLines="None" AllowPaging="false" OnPageIndexChanging="grd001_PageIndexChanging" OnRowCommand="grd001_rowcommand" Visible="False" Width="100%">
                                            <HeaderStyle CssClass="titulo-tabla" />
                                            <Columns>
                                                <asp:BoundField DataField="CodigoNi&#241;o" HeaderText="Cod Ni&#241;o"></asp:BoundField>
                                                <asp:BoundField DataField="ICodIE" HeaderText="Cod Ingreso"></asp:BoundField>
                                                <asp:BoundField DataField="Rut" HeaderText="Run "></asp:BoundField>
                                                <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                                <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno"></asp:BoundField>
                                                <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                                <asp:BoundField DataField="FechadeNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de Ingreso" DataFormatString="{0:d}" HtmlEncode="False"></asp:BoundField>
                                                <asp:ButtonField CommandName="Historicos" HeaderText="Historicos" Text="Hist&#243;ricos"></asp:ButtonField>
                                                <asp:ButtonField CommandName="VerDiagnosticos" HeaderText="VerDiagnosticos" Text="Ver Diagn&#243;sticos"></asp:ButtonField>
                                            </Columns>
                                            <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                        </asp:GridView>
                                    </div>
                                    <asp:Panel ID="utab_diag" runat="server" Visible="false">
                                        <div>
                                            <ul id="myTabs" class="nav nav-tabs tab-fixed-height nav-justified" role="tablist">
                                                <li id="li_nav1" runat="server" role="presentation" class="active">
                                                    <asp:LinkButton ID="link_tab1" runat="server" href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab1()">ESCOLAR
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav2" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab2" runat="server" href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab2()">MALTRATO 
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav3" runat="server" role="presentation"> 
                                                    <asp:LinkButton ID="link_tab3" runat="server" href="#tab3" aria-controls="tab3" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab3()">DROGA
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav4" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab4" runat="server" href="#tab4" aria-controls="tab4" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab4()">PSICOLOGICO / PSIQUIATRICO
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav5" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab5" runat="server" href="#tab5" aria-controls="tab5" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab5()">SOCIAL
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav6" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab6" runat="server" href="#tab6" aria-controls="tab6" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab6()">CAPACITACION
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav7" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab7" runat="server" href="#tab7" aria-controls="tab7" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab7()">SITUACION LABORAL
                                                    </asp:LinkButton>
                                                </li> 
                                                <li id="li_nav8" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab8" runat="server" href="#tab8" aria-controls="tab8" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab8()">HECHOS JUDICIALES
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav9" runat="server" role="presentation">
                                                    <asp:LinkButton ID="link_tab9" runat="server" href="#tab9" aria-controls="tab9" role="tab" data-toggle="tab" OnClientClick="return MostrarIframeUtab9()">PEORES FORMAS DE TRABAJO
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="li_nav10" runat="server" role="presentation" class="dropdown">                                                          
                                                    <asp:LinkButton ID="link_tab10" runat="server" href="#" role="tab" data-toggle="dropdown" >DIAGNÓSTICO SALUD
                                                    </asp:LinkButton>  
                                                    <ul class="dropdown-menu" role="menu">
                                                        <li id="li_FichaSaludIngreso" runat="server" visible="true">
                                                            <asp:LinkButton ID="link_tab10_1" runat="server" href="#tab10" aria-controls="tab10" data-toggle="tab" OnClientClick="return MostrarIframeUtab10()">Ficha de Salud Inicial
                                                            </asp:LinkButton>
                                                        </li>
                                                        <li id="li_FichaSaludPosterior" runat="server">
                                                            <asp:LinkButton ID="link_tab10_2" runat="server" href="#tab11" aria-controls="tab11" data-toggle="tab" OnClientClick="return MostrarIframeUtab11()">Ficha de Salud Posterior
                                                            </asp:LinkButton>
                                                        </li>
                                                    </ul>                                                    
                                                </li>                                                
                                            </ul>
                                        </div>
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane fade in active" id="tab1" runat="server">
                                                <asp:Panel ID="pnl_utab1" runat="server" Visible="true">
                                                    <iframe id="iframe_utab1" src="ninos_DiagnisticoEscolar.aspx" width="100%" height="500px" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab2" runat="server">
                                                <asp:Panel ID="pnl_utab2" runat="server" Visible="true">
                                                    <iframe id="iframe_utab2" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab3" runat="server">
                                                <asp:Panel ID="pnl_utab3" runat="server" Visible="true">
                                                    <iframe id="iframe_utab3" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab4" runat="server">
                                                <asp:Panel ID="pnl_utab4" runat="server" Visible="true">
                                                    <iframe id="iframe_utab4" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab5" runat="server">
                                                <asp:Panel ID="pnl_utab5" runat="server" Visible="true">
                                                    <iframe id="iframe_utab5" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab6" runat="server">
                                                <asp:Panel ID="pnl_utab6" runat="server" Visible="true">
                                                    <iframe id="iframe_utab6" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab7" runat="server">
                                                <asp:Panel ID="pnl_utab7" runat="server" Visible="true">
                                                    <iframe id="iframe_utab7" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab8" runat="server">
                                                <asp:Panel ID="pnl_utab8" runat="server" Visible="true">
                                                    <iframe id="iframe_utab8" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab9" runat="server">
                                                <asp:Panel ID="pnl_utab9" runat="server" Visible="true">
                                                    <iframe id="iframe_utab9" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab10" runat="server">
                                                <asp:Panel ID="pnl_utab10" runat="server" Visible="true">
                                                    <iframe id="iframe_utab10" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab11" runat="server">
                                                <asp:Panel ID="pnl_utab11" runat="server" Visible="true">
                                                    <iframe id="iframe_utab11" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="tab12" runat="server">
                                                <asp:Panel ID="pnl_utab12" runat="server" Visible="true">
                                                    <iframe id="iframe_utab12" runat="server" frameborder="0"></iframe>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel10">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
<%--<script type="text/javascript">
    //Mostrar_Cargando();
</script>--%>
</html>
