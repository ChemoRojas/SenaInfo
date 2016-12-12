<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Reg_Egresos_Instituciones.aspx.cs" Inherits="mod_instituciones_Reg_Egresos_Instituciones" %>

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
    <title>Registro de Egresos de instituciones :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=Reg_Egresos_Instituciones.aspx";
            objIframe.height = "300px";
            objIframe.width = "760px";
            $find("mpe1a").show();

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
    </script>
</head>

<body role="document" onmousemove="SetProgressPosition(event)">

    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A4" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Instituciones</li>
                        <li class="active">Registro de Egresos de instituciones</li>
                    </ol>
                    <div class="well">
                        <h4 class="subtitulo-form">Registro de Egresos de instituciones</h4>
                        <hr>
                        <div class="row">
                            <div class="col-md-12">

                                <asp:Panel ID="pnlHeader" runat="server" Width="100%" Visible="true">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <ajax:ModalPopupExtender
                                                ID="mpe1"
                                                BehaviorID="mpe1a"
                                                runat="server"
                                                TargetControlID="lbn_buscar_institucion"
                                                PopupControlID="modal_institucion"
                                                DropShadow="true"
                                                BackgroundCssClass="modalBackground"
                                                CancelControlID="lnb_close_buscar_institucion">
                                            </ajax:ModalPopupExtender>
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td>
                                                        <table class="table table-borderless table-condensed table-col-fix">
                                                            <tr>
                                                                <td>
                                                                    <table class="table table-borderless table-condensed table-col-fix">
                                                                        <tr>
                                                                            <td class="texto_form" width="225PX">Instituci&oacute;n</td>
                                                                            <td>
                                                                                <div class="input-group">
                                                                                    <asp:DropDownList ID="ddlInstitucion" runat="server" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:LinkButton ID="lbn_buscar_institucion" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion()">
                                                                                    <span class="glyphicon glyphicon-question-sign"></span>
                                                                                    </asp:LinkButton>
                                                                                </div>
                                                                                <div class="popupConfirmation" id="modal_institucion" style="display: none">
                                                                                    <div class="modal-header header-modal">
                                                                                        <asp:LinkButton ID="lnb_close_buscar_institucion" CssClass="close" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                                                                        <span aria-hidden="true">&times;</span>
                                                                                        </asp:LinkButton>
                                                                                        <h4 class="modal-title">Senainfo / Institución</h4>
                                                                                    </div>
                                                                                    <div>
                                                                                        <iframe id="iframe_bsc_institucion" runat="server" frameborder="0"></iframe>
                                                                                    </div>
                                                                                </div>
                                                                            </td>
                                                                            <%--<td>
                                                                                <asp:DropDownList ID="ddlInstitucion" runat="server" Width="560px" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitucion_SelectedIndexChanged" Font-Names="Arial" Font-Size="11px">
                                                                                    <asp:ListItem>Seleccionar</asp:ListItem>
                                                                                </asp:DropDownList>&nbsp;
                                                                                 <a id="A1" runat="server" class="ifancybox" href="bsc_institucion.aspx?param001=Plan de Intervencion&dir=Reg_Egresos_Instituciones.aspx">
                                                                                     <input type="image" src="../images/lupa.jpg">
                                                                              </a>
                                                                            </td>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="texto_form">Periodo a Rendir</td>
                                                                            <td><span style="font-size: 11px">&nbsp;Mes:&nbsp;</span>
                                                                                <asp:DropDownList ID="ddlMeses" runat="server" Font-Names="Arial" CssClass="form-control input-sm">
                                                                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                                                    <asp:ListItem Value="1">ENERO</asp:ListItem>
                                                                                    <asp:ListItem Value="2">FEBRERO</asp:ListItem>
                                                                                    <asp:ListItem Value="3">MARZO</asp:ListItem>
                                                                                    <asp:ListItem Value="4">ABRIL</asp:ListItem>
                                                                                    <asp:ListItem Value="5">MAYO</asp:ListItem>
                                                                                    <asp:ListItem Value="6">JUNIO</asp:ListItem>
                                                                                    <asp:ListItem Value="7">JULIO</asp:ListItem>
                                                                                    <asp:ListItem Value="8">AGOSTO</asp:ListItem>
                                                                                    <asp:ListItem Value="9">SEPTIEMBRE</asp:ListItem>
                                                                                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                                                                                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                                                                                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp; <span style="font-size: 11px">&nbsp;A&ntilde;o:&nbsp;<asp:TextBox ID="txtAno_NEW" runat="server" MaxLength="4" CssClass="form-control input-sm"></asp:TextBox></span>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="texto_form">Fecha Registro de Egreso</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFechaRegistro" runat="server" MaxLength="10" CssClass="form-control input-sm"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table class="table table-borderless table-condensed table-col-fix">
                                                                        <tr>
                                                                            <td style="height: 26px">
                                                                                <asp:Button ID="btnNuevo_NEW" runat="server" Height="26px" OnClick="btnNuevo_Click_NEW" Text="Nuevo Egreso" Width="123px" CssClass="btn btn-info btn-sm" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Button ID="btnBuscaRendicion_NEW" runat="server" Height="26px" OnClick="btnBuscaRendicion_Click_NEW" Text="Buscar Egresos" Width="123px" CssClass="btn btn-info btn-sm" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 26px">
                                                                                <asp:Button ID="btnCancelarNEW" runat="server" Height="26px" OnClick="btnCancelarNEW_Click" Text="Limpiar Egreso" Width="123px" CssClass="btn btn-info btn-sm" />
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td>
                                                                                <asp:Button ID="btnVolver_NEW" runat="server" Height="26px" OnClick="btnVolver_NEW_Click" Text="Volver" Width="123px" CssClass="btn btn-info btn-sm" />
                                                                            </td>
                                                                        </tr>--%>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lblInformacion" runat="server" CssClass="texto_rojo_peque" Text="La rendición de cuentas de este mes ya fue cerrada y no podrá realizar cambios." Visible="False" Width="100%" Font-Size="Small"></asp:Label>&nbsp;
                                                                         <br />
                                                        <asp:TextBox ID="txtIdRendicionEgreso" runat="server" Visible="False" CssClass="form-control input-sm"></asp:TextBox>
                                                        <br />

                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>


                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlBody" runat="server" Width="99%" Visible="False" Wrap="False">

                                            <asp:Panel ID="pnlDetail" runat="server" Width="100%" Visible="False" Wrap="False">
                                                <table class="table table-borderless table-condensed table-col-fix">
                                                    <tr>
                                                        <td bgcolor="#FFFFFF" style="height: 355px">
                                                            <table class="table table-borderless table-condensed table-col-fix">
                                                                <tr>
                                                                    <td valign="top" style="height: 340px">
                                                                        <table class="table table-borderless table-condensed table-col-fix" id="tblEditar" runat="server">
                                                                            <tr>
                                                                                <td width="225" class="texto_form">Fecha</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFechaComprobante" runat="server" MaxLength="10" CssClass="form-control input-sm"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style1">Nro Comprobante</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtNumeroComprobante" runat="server" ReadOnly="True" Font-Names="Arial" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form" style="height: 25px">Correlativo</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtCorrelativo_NEW" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Objetivo</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlObjetivo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlObjetivo_SelectedIndexChanged" Font-Names="Arial" CssClass="form-control input-sm">
                                                                                    </asp:DropDownList>
                                                                                      <asp:Label ID="lblObjetivo" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Uso</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlUso" runat="server" OnSelectedIndexChanged="ddlUso_SelectedIndexChanged" Font-Names="Arial" CssClass="form-control input-sm" AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                    <asp:Label ID="lblUso" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Monto</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMonto_NEW" runat="server" SkinID="##.###" CssClass="form-control input-sm"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="txtMonto_NEW" runat="server" ErrorMessage="Monto Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                                    <asp:Label ID="lblMonto" runat="server" Font-Size="11px" ForeColor="Red" Text="*" Visible="False" Width="136px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Medio de Pago</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlMedioDePago" runat="server" Font-Names="Arial" CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="ddlMedioDePago_SelectedIndexChanged"></asp:DropDownList>
                                                                                   <asp:Label ID="lblMedioPago" runat="server" ForeColor="Red" Text="*" Visible="False" Width="150px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Glosa</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtGlosa" runat="server" MaxLength="20" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Destino</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtDestino" runat="server" MaxLength="40" CssClass="form-control input-sm"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">N&uacute;mero de Cheque</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtNumeroDeCheque" runat="server" MaxLength="20" CssClass="form-control input-sm"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="txtNumeroDeCheque" runat="server" ErrorMessage="N&uacute;mero Cheque Inv&aacute;lido" Font-Bold="True" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="texto_form">Anular</td>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbAnular" runat="server" RepeatDirection="Horizontal" Font-Names="Arial" Font-Size="11px" Width="100px">
                                                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                                                    </asp:RadioButtonList></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="150" align="center" style="height: 340px">
                                                                        <asp:Button ID="btnGuardaEgreso_NEW" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnGuardaIngreso_Click_NEW" Text="Guardar Egreso" /><br />
                                                                        <asp:Button ID="btnCancelaEgreso_NEW" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnCancelaEgreso_Click_NEW" Text="Cancelar" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <div id="divbotonera" runat="server" visible="False">
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td>&nbsp;<asp:Button CssClass="btn btn-info btn-sm" ID="btnEgreso_NEW" runat="server" Height="25px" OnClick="btnEgreso_Click_NEW" Text="Agregar Egreso" />
                                                        &nbsp; &nbsp;
                                                      &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                      <a id="A3" runat="server" class="ifancyboxalter">
                                                          <asp:Button CssClass="btn btn-info btn-sm" ID="btnImprimir_NEW" runat="server" Height="25px" OnClick="btnImprimir_Click_NEW" Text="Imprimir" /></a>
                                                        &nbsp;
                                                      &nbsp; &nbsp;&nbsp;
                                                      <a id="A2" runat="server" class="ifancyboxalter">
                                                          <asp:Button CssClass="btn btn-info btn-sm" ID="btnExcel_NEW" runat="server" Height="25px" OnClick="btnExcel_Click_NEW" Text="Exportar a Excel" /></a></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grdEgresoDetalles" runat="server" AllowSorting="True"
                                                            AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No hay Información"
                                                            ForeColor="#333333" GridLines="None" OnRowEditing="grdEgresoDetalles_RowEditing" Width="100%" OnRowCommand="grdEgresoDetalles_RowCommand" Font-Names="Arial" Font-Size="11px">
                                                            <Columns>
                                                                <asp:BoundField DataField="FechaComprobante" DataFormatString="{0:d}" HeaderText="Fecha" HtmlEncode="False">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" Width="60px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NroComprobante" HeaderText="N&#186; Comprob.">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Correlativo" HeaderText="#">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Center" Width="30px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Objetivo" HeaderText="Objetivo">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Uso" HeaderText="Uso">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Monto" DataFormatString="{0:n0}" HeaderText="Monto" HtmlEncode="False">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="MedioDePago" HeaderText="Medio de Pago">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Glosa" HeaderText="Glosa">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Destino" HeaderText="Destino">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NumeroCheque" HeaderText="N&#186; Cheque">
                                                                    <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Nulo">
                                                                    <ItemTemplate>
                                                                        &nbsp;
                                                              <asp:CheckBox ID="chkNulo" runat="server" Enabled="False" ForeColor="Black" Font-Size="11px" Checked='<%# Eval("Nulo") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        &nbsp;
                                                             <asp:CheckBox ID="chkNulo" runat="server" Enabled="False" ForeColor="Black" Font-Size="11px" />
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:CommandField InsertVisible="False" ShowEditButton="True" ShowHeader="True" DeleteText="Borrar" EditText="Modificar">
                                                                    <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                                </asp:CommandField>
                                                                <asp:ButtonField CommandName="Correlativo" Text="Dividir Comprobante">
                                                                    <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                                </asp:ButtonField>
                                                                <asp:ButtonField CommandName="Eliminar" Text="Eliminar">
                                                                    <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                                </asp:ButtonField>
                                                                <asp:BoundField DataField="CodObjetivo">
                                                                    <ItemStyle Font-Size="8px" HorizontalAlign="Left" ForeColor="White" Width="1px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CodUso">
                                                                    <ItemStyle Font-Size="8px" HorizontalAlign="Left" ForeColor="White" Width="1px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CodMedioDePago">
                                                                    <ItemStyle Font-Size="8px" HorizontalAlign="Center" ForeColor="White" Width="1px" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                                            <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                            <EditRowStyle BackColor="#2461BF" Font-Overline="True" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        </asp:GridView>
                                                        <br />
                                                        <table id="tblTotal" runat="server" width="100%" border="0" cellspacing="1" cellpadding="1">
                                                            <tr>
                                                                <td width="225" class="texto_form">Monto Total de Egreso</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTotal_NEW" runat="server" Font-Bold="True" ReadOnly="True" CssClass="form-control input-sm"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlSearch" runat="server" Width="100%" Visible="False" Wrap="False">
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td class="titulo_form">Egresos</td>
                                                </tr>
                                            </table>
                                            <table class="table table-borderless table-condensed table-col-fix">
                                                <tr>
                                                    <td valign="top" style="height: 91px">
                                                        <table class="table table-borderless table-condensed table-col-fix">
                                                            <tr>
                                                                <td width="225px" class="texto_form">IdRendicion Egreso</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtIdrendicionEgreso2_NEW" runat="server" CssClass="form-control input-sm"></asp:TextBox>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="texto_form" style="width: 225px">Instituci&oacute;n</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInstitucion_NEW" runat="server" Width="600px" CssClass="form-control input-sm"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="texto_form">AñoMes (aaaamm)</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAnoMes_NEW" runat="server" Width="64px" CssClass="form-control input-sm"></asp:TextBox>&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="lbl_notFound" runat="server" CssClass="texto_rojo_peque" Font-Size="Small" Text="No se han encontrado registros." Visible="False" Width="100%"></asp:Label></td>
                                                    <td>
                                                        <table class="table table-borderless table-condensed table-col-fix">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnBuscar_NEW" runat="server" Height="26px" OnClick="btnBuscar_Click_NEW" Text="Buscar" Width="90px" CssClass="btn btn-info btn-sm" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 26px">
                                                                    <asp:Button ID="btnLimpiaBusqueda_NEW" runat="server" Height="26px" OnClick="btnLimpiaBusqueda_Click_NEW" Text="Limpiar" Width="90px" CssClass="btn btn-info btn-sm" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnCancelarBusqueda_NEW" runat="server" Height="26px" OnClick="btnCancelarBusqueda_Click_NEW" Text="Cancelar" Width="90px" CssClass="btn btn-info btn-sm" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <asp:GridView ID="grdBuscador" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CellPadding="4" EmptyDataText="No hay Información" ForeColor="#333333" GridLines="None"
                                                OnRowEditing="grdBuscador_RowEditing" Width="100%" Font-Names="Arial" Font-Size="11px">
                                                <Columns>
                                                    <asp:BoundField DataField="IdRendicionEgreso" HeaderText="IdRendicionEgreso">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField HeaderText="Nombre Institucion" DataField="Nombre">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="A&#241;o Mes (aaaamm)" DataField="AnoMes">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Fecha de Registro" DataField="FechaRegistro" DataFormatString="{0:d}" HtmlEncode="False">
                                                        <ItemStyle Font-Size="11px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Cerrado">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkCerrado" runat="server" Font-Size="11px" Checked='<%# Eval("Cerrado") %>' Enabled="False" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True" CancelText="Cancelar" DeleteText="Borrar" EditText="Modificar">
                                                        <ItemStyle Font-Names="Arial" Font-Size="11px" ForeColor="Red" />
                                                    </asp:CommandField>
                                                </Columns>
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Names="Verdana" Font-Size="10px" ForeColor="White" HorizontalAlign="Left" />
                                                <RowStyle BackColor="#EFF3FB" Font-Names="Arial" Font-Size="11px" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="11px" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                            <br />
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
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