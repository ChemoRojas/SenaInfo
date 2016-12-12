<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Talleres_Proyecto.aspx.cs" Inherits="mod_instituciones_Talleres_Proyecto" %>

<%@ Register src="../SenainfoSdk/C_buscar_x_institu_proyecto.ascx" tagname="C_buscar_x_institu_proyecto" tagprefix="uc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Src="~/SenainfoSdk/C_buscar_x_institu_proyecto.ascx" TagPrefix="uc2" TagName="C_buscar_x_institu_proyecto" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<%@ Register Src="~/SenainfoSdk/I_Institucion.ascx" TagPrefix="uc1" TagName="I_Institucion" %>
<%@ Register Src="~/SenainfoSdk/I_Proyecto.ascx" TagPrefix="uc1" TagName="I_Proyecto" %>




<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Registro de Trabajadores :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function MostrarModalTrabajador() {
            var objIframe = document.getElementById('iframe_trabajador');
            limpiaiframe(objIframe);
            var institucion = document.getElementById('ddown001');
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Registro de Trabajadores&dir=reg_trabajadores.aspx" + "&codinst=" + institucion.options[institucion.selectedIndex].value;
            objIframe.height = "430px";
            objIframe.width = "760px";
            $find("mpe1a").show();
            return false;
        }

        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);
            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=reg_trabajadores.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe2a").show();
            return false;
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 40%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
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

            document.getElementById('divProgress').style.top = posy + "px";
        }

        function funcionpropone() {
            if (document.getElementById("txt002").value.length > 1 && document.getElementById("txt003").value.length > 1 && document.getElementById("txt004").value.length > 1) {
                var textoprop = document.getElementById("txt004").value.substr(0, 1) +
                document.getElementById("txt002").value + document.getElementById("txt003").value;
                document.getElementById("txt_usuario").value = textoprop.toLowerCase();

             
            }
        }

        function yaExiste(mensaje) {
            alert(' ' + mensaje);
            document.getElementById('run_tecnico').value = "";
            document.getElementById('run_tecnico').focus();
        }

    </script>
    <style type="text/css">
        .auto-style1
        {
            height: 37px;
        }
    </style>
    </head>

<body>
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatepanel" runat="server">
            
            <ContentTemplate>
                <div>
                     <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Instituciones</a>            </li>
                            <li class="active">Talleres de Proyecto</li>
                        </ol>
                         <div class="well">
                              <div class="text-center alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                           <span class="glyphicon glyphicon-warning"></span>
                          <asp:Label ID="lbl_error_dia" runat="server" Visible="False"></asp:Label>
                          
                      </div>
                        <div class="text-center alert alert-success" role="alert" id="alertSuccess" runat="server" visible="false">
                            <span class="glyphicon glyphicon-ok"></span>
                            <asp:Label ID="lbl_alertSuccess" runat="server" Visible="False"></asp:Label>
                        </div>
                             
                    <table class="table table-bordered tabla-tabs table-condensed">
                        <tr>
                            <th class="titulo-tabla col-md-1" cssclass="form-control input-sm" scope="row">Institución</th>
                            <td class="col-md-4">
                                <uc1:I_Institucion runat="server" ID="I_Institucion" UsarAllInOne="true"/>

                                <th class="titulo-tabla col-md-1" cssclass="form-control input-sm" scope="row">Proyecto</th>
                            <td class="col-md-4">
                                <uc1:I_Proyecto runat="server" ID="I_Proyecto" UsarAllInOne="true" InstitucionControlID="I_Institucion" />
                            </td>

                        </tr>
                        
                        <tr>
                            <th class="titulo-tabla col-md-1" cssclass="form-control input-sm" scope="row">Tipo de Taller</th>
                            <td class="col-md-4">
                                <asp:DropDownList ID="ddl_tipoTaller" CssClass="form-control input-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipoTaller_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio *</th>
                            <td>
                                <asp:TextBox ID="txt_fechaInicio" runat="server" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                <ajax:CalendarExtender ID="CalendarExtender3_calFechaCambio" runat="server" BehaviorID="_content_CalendarExtender3_calFechaCambio" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txt_fechaInicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_fechaInicio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_fechaInicio" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Inválida" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                                <%--<asp:Label ID="lbl_FechaCambio" runat="server" CssClass="help-block"></asp:Label>--%>

                            </td>

                        </tr>
                        <tr>
                            <th class="titulo-tabla col-md-1" scope="row" rowspan="3">Nombre Taller</th>
                            <td rowspan="3">
                                <asp:DropDownList ID="ddl_nombreTaller" CssClass="form-control input-sm" runat="server" AutoPostBack="true"></asp:DropDownList>
                                <%--<asp:TextBox ID="txt_nombreTaller" CssClass="form-control input-sm" runat="server" Enabled="False"></asp:TextBox>--%>
                            </td>
                            <th class="titulo-tabla col-md-1" scope="row">Fecha Término *</th>
                            <td>
                                
                                <asp:TextBox ID="txt_fechaTermino" runat="server" CssClass="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa"></asp:TextBox>
                                <ajax:CalendarExtender ID="txt_fechaTermino_CalendarExtender" runat="server" BehaviorID="_content_CalendarExtender3_TextBox2" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txt_fechaTermino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_fechaTermino" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Requerida" ValidationGroup="gcjfecha1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_fechaTermino" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Inválida" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" ValidationGroup="gcjfecha1" />
                            
                            </td>
                        </tr>
                        <tr>
                             <th class="titulo-tabla col-md-1" scope="row">Descripción</th>
                            <td>
                                <asp:TextBox ID="txt_descripcion" runat="server" CssClass="&quot;form-control form-control-fecha-large input-sm&quot; " Height="75px" TextMode="SingleLine" Width="407px" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr> 
                        <tr id="tr_numSessiones" runat="server">
                             <th class="titulo-tabla col-md-1" scope="row" rowspan="3">N° Sesiones</th>
                            <td rowspan="3">
                                <%--<asp:Label ID="Label1" runat="server" CssClass="help-block"></asp:Label>--%>
                                <asp:TextBox ID="txt_nSessiones" runat="server"></asp:TextBox>
                            </td>
                        </tr> 
                        <tr id="tr_proyeccion" runat="server">
                            <th class="titulo-tabla col-md-1" scope="row" style="height: 37px; bottom: 186px">
                            <asp:Label ID="lbl_6" runat="server" Text="Con Proyección Productiva" Visible="true">
                            </asp:Label></th>
                            <td class="auto-style1">

                                <asp:RadioButtonList ID="rbl_conProyProd" runat="server" RepeatDirection="Horizontal" Visible="true">
                                    <asp:ListItem Value="1">si</asp:ListItem>
                                    <asp:ListItem Value="0">no</asp:ListItem>
                                </asp:RadioButtonList>

                            </td>
                            
                        </tr>
                        <tr id="tr_compraBienes" runat="server">
                            <th class="titulo-tabla col-md-1" scope="row">
                                
                                <asp:Label ID="lbl_1" runat="server" Text="Con Compra de Bienes y Servicios" Visible="true"></asp:Label>
                                
                            </th>
                          
                            <td class="col-md-4">
                                <asp:CheckBox ID="chk_cbs" runat="server" Visible="true" />
                            </td>
                           
                        </tr>
                        
                        <tr id="tr_registroTotal" runat="server">
                            <th class="titulo-tabla col-md-1" scope="row"><asp:Label ID="lbl_2" runat="server" Text="Registro Total de Sesiones y expediente joven" Visible="true"></asp:Label>
                            </th>
                            <td>
                                <asp:CheckBox ID="chk_rsE" runat="server" Visible="true" />
                            </td>
                        </tr>
                        <tr id="tr_reporteCierreRealizado" runat="server">
                            <th class="titulo-tabla col-md-1" scope="row">
                                <asp:Label ID="lbl_3" runat="server" Text="Reporte de cierre Realizado" Visible="true"></asp:Label>
                            </th>
                            <td class="col-md-4">
                                <asp:CheckBox ID="chk_rcr" runat="server" Visible="true" />
                            </td>
                          
                        </tr>
                        <tr id="tr_gastoplanificado" runat="server">
                            <th class="titulo-tabla col-md-1" scope="row"><asp:Label ID="lbl_4" runat="server" Text="Gasto Planificado" Visible="true"></asp:Label>
                            </th>
                            <td class="col-md-4">
                                <asp:TextBox ID="txt_gasto_planificado" runat="server" MaxLength="13" Visible="false" ></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_gasto_planificado" ValidChars="0123456789" />
                               <%-- <ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_gasto_planificado" Mask="99.99.999.9 " />--%>
                            </td>
                        </tr>
                        <tr id="tr_gastoejecutado" runat="server">
                            <th class="titulo-tabla col-md-1" scope="row"><asp:Label ID="lbl_5" runat="server" Text="Gasto Ejecutado" Visible="true"></asp:Label>
                            </th>
                            <td class="col-md-4">
                                <asp:TextBox ID="txt_gasto_ejecutado" runat="server" Visible="false"></asp:TextBox>
                                  <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_gasto_ejecutado" ValidChars="0123456789" />
                            </td>
                        </tr>
                    </table>
                             <div class="botonera pull-right">
                                  <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="btn_limpiar" runat="server" AutoPostback="true" CausesValidation="false" Visible="False" OnClick="btn_limpiar_Click">
                            <span class="glyphicon glyphicon-search"></span>&nbsp; Crear nuevo registro
                             </asp:LinkButton>
                                 <asp:LinkButton ID="btn_update_Planificacion" runat="server" AutoPostback="true" CausesValidation="false" CssClass="btn btn-sm btn-danger fixed-width-button" OnClick="btn_update_Planificacion_Click" Visible="False" ValidationGroup="gcjfecha1">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar Planificación </asp:LinkButton>
                                 <asp:LinkButton ID="btn_update_Ejecucion" runat="server" AutoPostback="true" CausesValidation="false" CssClass="btn btn-sm btn-danger fixed-width-button" OnClick="btn_update_Ejecucion_Click" Visible="False">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar Ejecución </asp:LinkButton>
                                 <asp:LinkButton ID="btn_update_Cierre" runat="server" AutoPostback="true" CausesValidation="false" CssClass="btn btn-sm btn-danger fixed-width-button" Visible="False" OnClick="btn_update_Cierre_Click">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar Cierre </asp:LinkButton>
                             </div>
                         </div>
                         <table>
                             <div>
                                 <asp:GridView ID="grd_taller" CssClass="table table-bordered table-hover" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="grd_taller_RowCommand" AllowPaging="True" OnPageIndexChanging="grd_taller_PageIndexChanging">
                                     <Columns>
                                         <asp:TemplateField HeaderText="IcodTaller">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IcodTaller") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("IcodTaller") %>'></asp:Label>
                                             </ItemTemplate>

                                         </asp:TemplateField>
                                         <asp:BoundField DataField="Codproyecto" HeaderText="Código de Proyecto"></asp:BoundField>
                                         <asp:BoundField DataField="CodTaller" HeaderText="Taller N°"></asp:BoundField>
                                         <asp:BoundField DataField="NombreTaller" HeaderText="Nombre del Taller"></asp:BoundField>
                                         <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio"></asp:BoundField>
                                         <asp:BoundField DataField="FechaTermino" HeaderText="Fecha Término"></asp:BoundField>
                                         <asp:BoundField DataField="Conproyeccionproductiva" HeaderText="Con Proyección Productiva"></asp:BoundField>
                                         <asp:BoundField DataField="CompraBienesServicio" HeaderText="Compra Bienes y Servicios"></asp:BoundField>
                                         <asp:BoundField DataField="SesionesExpediente" HeaderText="Sesiones Expediente"></asp:BoundField>
                                         <asp:BoundField DataField="CierreRealizado" HeaderText="Cierre Realizado"></asp:BoundField>
                                         <asp:BoundField DataField="Descripcion" HeaderText="Descripción"></asp:BoundField>
                                         <%--<asp:BoundField DataField="Estado" HeaderText="Estado"></asp:BoundField>--%>
                                         <asp:TemplateField HeaderText="Estado">
                                             <EditItemTemplate>
                                                 <asp:TextBox ID="Textbox_2" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Label_2" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>

                                         <asp:TemplateField ShowHeader="False">
                                             <ItemTemplate>
                                                 <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("IcodTaller") %>' Text="Seleccionar" CommandName='<%# Bind("Estado") %>'>
                                                 </asp:LinkButton>
                                             </ItemTemplate>


                                         </asp:TemplateField>
                                     </Columns>
                                      <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                      <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                      <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                      <RowStyle CssClass="caja-tabla table-bordered" />
                                 </asp:GridView>
                             </div>
                         </table>
                         <div class="botonera pull-right">
                             <asp:LinkButton CssClass="btn btn-sm btn-primary fixed-width-button" ID="bt_situacion_migratoria" runat="server" AutoPostback="true" CausesValidation="false" Visible="False">
                            <span class="glyphicon glyphicon-search"></span>&nbsp; Buscar
                             </asp:LinkButton>
                             <asp:LinkButton CssClass="btn btn-sm btn-danger fixed-width-button" ID="btn_update_situacionMigratoria" runat="server" AutoPostback="true" CausesValidation="false" Visible="False" OnClick="btn_update_situacionMigratoria_Click">
                            <span class="glyphicon glyphicon-ok"></span>&nbsp; Guardar
                             </asp:LinkButton>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
 