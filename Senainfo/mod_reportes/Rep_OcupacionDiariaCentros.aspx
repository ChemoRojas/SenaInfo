<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="Rep_OcupacionDiariaCentros.aspx.cs" Inherits="mod_reportes_Rep_OcupacionDiariaCentros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html >
<script runat="server">

 
</script>

<html lang="es">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Ocupación Diaria Centros AA.DD. :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/bootstrap.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>



</head>



<body class="body-iframe-reportes" onmousemove="SetProgressPosition(event)">
    <form id="form1" class="form-horizontal" runat="server">
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="ImageButton1" />
                <asp:PostBackTrigger ControlID="exportarExcel" />

            </Triggers>
            <ContentTemplate>

                <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" visible="false">
                    <span class="glyphicon glyphicon-warning-sign"></span>&nbsp;  
                        <asp:Label runat="server" ID="lblError"></asp:Label>

                </div>
                <asp:Panel runat="server" ID="pnlError" Visible="false">
                    <div class="row">
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="panelOcupacionDiaria" Visible="true">
                    <h5 class="subtitulo-form">Ocupación Diaria</h5>
                    <div class="row">
                        <div class="col-md-9">
                            <table class="table table-borderless table-col-fix table-condensed">
                                <tr>
                                    <th>
                                        <label for="">Fecha de la Información</label></th>
                                    <td>
                                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control-fecha-large form-control input-sm" MaxLength="10" placeholder="dd-mm-aaaa" />
                                        <cc1:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txtFecha" ValidChars="0123456789-+/" />
                                        <cc1:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txtFecha" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></cc1:CalendarExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" ControlToValidate="txtFecha" runat="server" ErrorMessage="Fecha Inv&aacute;lida" Font-Bold="True" ForeColor="Red" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        <asp:Label ID="lblaviso" runat="server" BackColor="White" BorderColor="White" CssClass="help-block" Visible="False"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <th></th>
                                    <td>
                                        <asp:LinkButton runat="server" ID="btnBuscar" OnClick="imb_001d_Click" CssClass="btn btn-danger btn-sm fixed-width-button">
                          <span class="glyphicon glyphicon-search"></span>&nbsp; Buscar
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnLimpiar" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="btnLimpiar_Click">
                          <span class="glyphicon glyphicon-remove-sign"></span>&nbsp; Limpiar
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="exportarExcel" OnClick="exportarExcel_Click" CssClass="btn btn-success btn-sm fixed-width-button" Visible="false">
                          <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Exportar
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
                                    <asp:Label ID="lbl_info" CssClass="subtitulo-form-info" runat="server" Text="Seleccione parámetros  para generar el reporte."></asp:Label>
                                </div>
                            </div>

                        </div>
                        <!-- botones deprecados? -->
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnLimpiar_NEW" runat="server" OnClick="btnLimpiar_NEW_Click" Text="Limpiar" Width="90px" CausesValidation="False" Visible="false" />
                        <asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btnVolver_NEW" runat="server" Onlick="btnVolver_NEW_Click" Text="Volver" Width="90px" CausesValidation="False" Visible="false" />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Excel1.bmp"
                            OnClick="ImageButton1_Click" Visible="false" />

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <br />
                            <br />
                            <asp:GridView ID="grd001" CssClass="table table-bordered table-condensed table-hover" runat="server" AutoGenerateColumns="False"
                                Visible="true">
                                <Columns>
                                    <%--<asp:BoundField DataField="FechaAsistencia" HeaderText="Fecha De Asistencia">
                          </asp:BoundField>--%>
                                    <asp:BoundField DataField="CodRegion" HeaderText="CodRegion"></asp:BoundField>
                                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto"></asp:BoundField>
                                    <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                    <asp:BoundField DataField="Presentes" HeaderText="Presentes"></asp:BoundField>
                                    <asp:BoundField DataField="Ausentes" HeaderText="Ausentes"></asp:BoundField>
                                    <asp:BoundField DataField="Permisos" HeaderText="Permisos/Salidas"></asp:BoundField>
                                </Columns>
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                <RowStyle CssClass="caja-tabla table-bordered" />
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
                </div>



                </div>
                
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel33">
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
