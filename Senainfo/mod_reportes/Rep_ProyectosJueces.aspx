<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_ProyectosJueces.aspx.cs" Inherits="Reportes_Rep_ProyectosJueces" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>



<html lang="es">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Reporte Vacantes :: Senainfo :: Servicio Nacional de Menores</title>
    <!-- Bootstrap core CSS -->
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>


    <script type="text/javascript">

        function f_SoloNumeros() {
            var key = window.event.keyCode;
            if (key < 48 || key > 57) {
                window.event.keyCode = 0;
            }
        }

        function f_MuestraEspera() {
            var Buscando = document.getElementById('Buscando');
            if (Buscando.value == '0') {
                Buscando.value = '1';
                document.getElementById('lblBuscando').style.visibility = 'visible';
                return true;
            }
            else
                return false;
        }

    </script>
</head>

<body onkeypress="JavaScript:if (event.keyCode==13) {self.document.getElementById('btn_buscar').click();event.keyCode=null;}" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server" enableviewstate="true">
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
                <%--<asp:PostBackTrigger ControlID="btn_limpiar" />--%>
                <asp:PostBackTrigger ControlID="btn_volver" />
                <asp:PostBackTrigger ControlID="btn_excel" />
            </Triggers>


            <ContentTemplate>

                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal1">
                </ajax:ModalPopupExtender>

                <ajax:ModalPopupExtender
                    ID="ModalPopupExtender1"
                    BehaviorID="mpe1b"
                    runat="server"
                    TargetControlID="imb_lupa_modal_proyecto"
                    PopupControlID="modal_bsc_proyecto"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>

                <div class="container theme-showcase" style="height: auto;" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Reportes</li>
                        <li class="active">Reporte de vacantes</li>
                    </ol>

                    <asp:Panel runat="server" ID="pnlAlert" Visible="false">
                        <div id="divAlert" class="alert alert-warning text-center" runat="server">
                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;

                                <asp:Label ID="lbl_error" runat="server" Visible="False">No se han encontrado registros coincidentes.</asp:Label>

                        </div>
                    </asp:Panel>
                    <div class="well">

                        <h4 class="subtitulo-form">Reporte de Vacantes</h4>
                        <hr />

                        <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                                <div class="modal-header header-modal">
                                    <asp:LinkButton ID="btnCerrarModal1" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
	                            <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                    <h4 class="modal-title">INSTITUCIÓN</h4>
                                </div>
                                <div>
                                    <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                </div>
                        </div>
                        <div class="popupConfirmation" id="modal_bsc_proyecto" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton ID="btnCerrarModal2" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                    	        <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">PROYECTOS</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>


                        <div class="row">
                            <%--label e inputs--%>
                            <div class="col-md-9">
                                <table class="table table-borderless table-col-fix table-condensed">
                                    <tr>
                                        <th>
                                            <label for="">Región:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddregion" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddregion_SelectIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Comuna:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddComuna" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddComuna_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Institución:</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddinstitucion" runat="server" AutoPostBack="True" CssClass="form-control input-sm" OnSelectedIndexChanged="ddinstitucion_SelectIndex_changed">
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CausesValidation="False" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_reportes/Rep_ProyectoJueces.aspx','mpe1a')">
                                                        <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Area de Atención:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddDepartamentosSename" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddDepartamentosSename_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="1">PROTECCI&#211;N DE DERECHOS - ADOPCI&#211;N</asp:ListItem>
                                                <asp:ListItem Value="2">JUSTICIA JUVENIL</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Temática:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddTematica" runat="server" AutoPostBack="True"
                                                CssClass="form-control input-sm" OnSelectedIndexChanged="ddTematica_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Modelo de Intervención:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddModeloIntervencion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddModeloIntervencion_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Proyecto:</label></th>
                                        <td>
                                            <%--<asp:DropDownList ID="" runat="server" CssClass="form-control input-sm"></asp:DropDownList>&nbsp;
                                            <asp:LinkButton ID="" OnClick="btnBuscaProyecto_Click" runat="server" CssClass="input-group-addon btn btn-info btn-sm"  OnClientClick="" CausesValidation="False" Width="100px" >
                                            <span class="glyphicon glyphicon-question-sign"></span>
                                         </asp:LinkButton>
                                        </div>--%>

                                            <div class="input-group">
                                                <asp:DropDownList ID="ddproyecto" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                                <asp:LinkButton ID="imb_lupa_modal_proyecto" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos','../mod_reportes/Rep_ProyectosJueces.aspx','mpe1b')" CausesValidation="False">
	                                           <span class="glyphicon glyphicon-question-sign"></span>
                                                </asp:LinkButton>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Sexo:</label></th>
                                        <td>
                                            <asp:DropDownList ID="ddSexo" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="A">Ambos</asp:ListItem>
                                                <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Tramo Etáreo:</label></th>
                                        <td>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtAnos" CssClass="form-control input-sm" runat="server" MaxLength="2">0</asp:TextBox>
                                                <span class="input-group-addon-telefono">Años </span>
                                                <asp:TextBox ID="txtMeses" CssClass="form-control input-sm" runat="server" MaxLength="2">0</asp:TextBox>
                                                <span class="input-group-addon-telefono">Meses </span>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Vacantes al:</label></th>
                                        <td>
                                            <label class="titulo-form"><asp:Label ID="lblPeriodo" runat="server" Text="01-01-1900" ></asp:Label></label>
                            
                                <asp:TextBox ID="cal_inicio" runat="server" placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha-large input-sm" Visible="False" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1619" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="cal_inicio" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" /></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:LinkButton ID="btn_buscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btn_buscar_Click">
                                        <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_limpiar" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btn_limpiar_Click">
                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_excel" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="btn_excel_Click" CausesValidation="False" Visible="false">
                                            <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_volver" runat="server" CssClass="btn btn-info btn-sm fixed-width-button" OnClick="btn_volver_Click" CausesValidation="False" Visible="false">
                                            <span class="glyphicon glyphicon-arrow-left"></span>&nbsp;Volver
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
                                        <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Ingrese los parámetros solicitados para generar el reporte."></asp:Label>
                                    </div>
                                </div>




                            </div>
                        </div>
                        <br />
                                            </div>



                        <asp:Panel ID="pnl001" runat="server" Visible="false" >
                            <asp:GridView ID="grd001" CssClass="table table-bordered table-hover" AllowPaging="true" OnPageIndexChanging="grd001_PageIndexChanging" PageSize="8" runat="server" AutoGenerateColumns="False" Width="300px">
                                
                                <Columns>
                                    <asp:BoundField DataField="codinstitucion" HeaderText="Cod. Inst."></asp:BoundField>
                                    <asp:BoundField DataField="NombreInstitucion" HeaderText="Nombre Inst."></asp:BoundField>
                                    <asp:BoundField DataField="CodRegion" HeaderText="Regi&#243;n"></asp:BoundField>
                                    <asp:BoundField DataField="Comuna" HeaderText="Comuna"></asp:BoundField>
                                    <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Proyecto"></asp:BoundField>
                                    <asp:BoundField DataField="nModelo" HeaderText="Modelo"></asp:BoundField>
                                    <asp:BoundField DataField="NumeroPlazasMesAnterior" HeaderText="Plazas al Mes Anterior"></asp:BoundField>
                                    <asp:BoundField DataField="PlazasOcupadasMesAnterior" HeaderText="Plazas Ocupadas al Mes Anterior"></asp:BoundField>
                                    <asp:BoundField DataField="VacantesMesAnterior" HeaderText="Plazas Vacantes al Mes Anterior"></asp:BoundField>
                                    <asp:BoundField DataField="NumeroPlazas" HeaderText="Plazas a la Fecha"></asp:BoundField>
                                    <asp:BoundField DataField="PlazasOcupadas" HeaderText="Plazas Ocupadas a la Fecha"></asp:BoundField>
                                    <asp:BoundField DataField="Vacantes" HeaderText="Plazas Vacantes a la Fecha"></asp:BoundField>
                                    <asp:BoundField DataField="ListasDeEspera" HeaderText="Niños(as) o Adolescentes en Lista de Espera"></asp:BoundField>
                                    <asp:BoundField DataField="EdadMinima" HeaderText="Edad M&#237;n."></asp:BoundField>
                                    <asp:BoundField DataField="EdadMaxima" HeaderText="Edad M&#225;x."></asp:BoundField>
                                    <asp:BoundField DataField="nsexo" HeaderText="Sexo"></asp:BoundField>
                                    <asp:BoundField DataField="Telefono" HeaderText="Tel&#233;fono"></asp:BoundField>
                                    <asp:BoundField DataField="director" HeaderText="Director"></asp:BoundField>
                                    <asp:BoundField DataField="Mail" HeaderText="Email"></asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="pager-tabla" ForeColor="white" />
                                <HeaderStyle CssClass="titulo-tabla table-borderless" ForeColor="white" />
                                <RowStyle CssClass="caja-tabla table-bordered" />
                            </asp:GridView>
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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif" />
                    Cargando...       
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <br />
    </form>
</body>
</html>

<!-- codigo antiguo, sin controles -->

<%-- <div>
             <input type="hidden" id="Buscando" value="0" />
        <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="titulo_form">Reporte de Vacantes</td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="1000" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                        <tr>
                                            <td  style="height: 23px">Regi&oacute;n</td>
                                            <td colspan="3" class="linea_inferior" style="height: 23px">
                                                
                                        </tr>
                                        <tr>
                                            <td >Comuna</td>
                                            <td class="linea_inferior" colspan="3">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td >Instituci&oacute;n</td>
                                            <td colspan="3" class="linea_inferior">
                                                
                                                 <a id="A1" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_reportes/Rep_ProyectosJueces.aspx"> <asp:ImageButton ID="btnBuscaInstitucion" runat="server" ImageUrl="~/images/lupa.jpg"  OnClick="btnBuscaInstitucion_Click" Visible="False" /></a>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td >Área de atención</td>
                                            <td class="linea_inferior" colspan="3">
                                                
                                        </tr>
                                        <tr>
                                            <td >Temática</td>
                                            <td class="linea_inferior" colspan="3">
                                                
                                        </tr>
                                        <tr>
                                            <td  style="height: 23px">Modelo de Intervención
                                            </td>
                                            <td class="linea_inferior" colspan="3" style="height: 23px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td >Proyecto</td>
                                            <td colspan="3" class="linea_inferior">
                                                &nbsp;
                       <a id="A2" runat="server" class="ifancybox" href="../mod_instituciones/bsc_institucion.aspx?param001=Busca Proyectos&dir=../mod_reportes/Rep_ProyectosJueces.aspx">  <asp:ImageButton ID="btnBuscaProyecto" runat="server"  ImageUrl="~/images/lupa.jpg" OnClick="btnBuscaProyecto_Click" /></a>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td >Sexo</td>
                                            <td class="linea_inferior" colspan="3" valign="right">
                                                
                                        </tr>
                                        <tr>
                                            <td >Tramo Etareo</td>
                                            <td class="linea_inferior" colspan="3" valign="right">
                                                
                                                Meses</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td >Vacantes al</td>
                                            <td class="linea_inferior">
                                                


                                            </td>
                                            <td class="linea_inferior"></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="150" align="center">

                                    
                            </tr>
                            <tr>
                                <td valign="top" style="height: 15px">
                                    <asp:HyperLink ID="hlInstructivo" runat="server" ForeColor="Red" NavigateUrl="~/links/INSTRUCTIVO_modulo_vacantes3.pdf"
                                        Target="_blank">Instructivo</asp:HyperLink></td>
                                <td align="center" width="150" style="height: 15px"></td>
                            </tr>
                            <tr>
                                <td style="text-align: center" valign="top">
                                    <div class="TextoMensaje" id="lblBuscando" style="VISIBILITY: hidden; TEXT-ALIGN: center">
                                        <asp:Image ID="Img_cargando" runat="server" ImageUrl="~/images/bar_animada.gif" /></div>
                                    <td align="center" width="150"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                </tr>
                <tr>
                    <td>
                        <br />
                        
                    </td>
                </tr>
            </table>
        </div>--%>
                
 
