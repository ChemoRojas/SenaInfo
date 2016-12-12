<%@ Page Language="C#" AutoEventWireup="true" CodeFile="New_CoordinadoresModif.aspx.cs" Inherits="mod_coordinadores_New_CoordinadoresModif" %>

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
    <title>Modificar Coordinadores :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <script type="text/javascript" src="../js/senainfoTools.js"></script>




    <script type="text/javascript">
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

    </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <style>
        th {
            text-align: center;
            white-space: nowrap;
        }

        #grd004 tr td {
            text-align: center;
            white-space: nowrap;
        }

        .Rut {
            white-space: nowrap;
            text-align: center;
        }

        ocultar-columna {
            display: none;
        }
    </style>
    <form id="form1" runat="server" style="margin-left: 40px">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
            </Triggers>
            <ContentTemplate>
                <%-- //**FUO**// --%>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="~/index.aspx">Inicio</a></li>
                        <li class="active">Coordinadores</li>
                        <li class="active">Modificar Coordinadores</li>
                    </ol>


                    <asp:Panel ID="pnlCorrecto" runat="server" Visible="false">
                        <div class="alert alert-success text-center" role="alert">
                            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>&nbsp;
                            <asp:Label runat="server" ID="lblCorrecto"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlError" runat="server" Visible="false">
                        <div class="alert alert-warning text-center" role="alert">
                            <span class="glyphicon glyphicon-warning-sign" aria-hidden="true"></span>&nbsp;
                            <asp:Label runat="server" ID="lblAlertError"></asp:Label>

                        </div>
                    </asp:Panel>


                    <div class="well">
                        <h4 class="subtitulo-form">Búsqueda de Niños</h4>
                        <hr />
                        <div class="row">
                            <div class="col-md-9">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <th>
                                            <label for="">RUN Niño*:</label></th>
                                        <td>
                                            <asp:TextBox ID="txt_rut" runat="server" placeholder="Ingrese RUN Niño(a)" class="form-control input-sm"></asp:TextBox>
                                            <asp:CustomValidator ID="cv_rut" runat="server" CssClass="help-block" ControlToValidate="txt_rut" Display="Dynamic" ErrorMessage="Rut Inv&aacute;lido" ClientValidationFunction="validar_rut" ValidationGroup="grupo1" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_rut" ValidChars="1234567890-Kk" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Cod. Niño:</label></th>
                                        <td>
                                            <asp:TextBox ID="txt_codnino" placeholder="Ingrese Código Niño(a)" runat="server" class="form-control input-sm" MaxLength="12"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="txt_codnino" ValidChars="0123456789-/" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Nombre del Niño(a):</label></th>
                                        <td>
                                            <asp:TextBox ID="txt_nombres" runat="server" CssClass="form-control input-sm" placeholder="Ingrese Nombre"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Apellido Paterno:</label></th>
                                        <td>
                                            <asp:TextBox ID="txt_ap_paterno" runat="server" CssClass="form-control input-sm" placeholder="Ingrese Apellido"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label for="">Apellido Materno:</label></th>
                                        <td>
                                            <asp:TextBox ID="txt_ap_materno" runat="server" CssClass="form-control input-sm" placeholder="Ingrese Apellido"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <div>
                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_buscar" runat="server" OnClick="btn_buscar_Click" ValidationGroup="grupo1">
                                                <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button pull-right" ID="btn_limpiar" runat="server" OnClick="btn_limpiar_Click">
                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                                </asp:LinkButton>
                                                <%--<asp:Button CssClass="BtnSenaInfo-01 BtnSenaInfo-01-azul" ID="btn_volver" runat="server" Text="Volver" OnClick="btn_volver_Click" />--%>
                                            </div>

                                        </td>
                                    </tr>
                                </table>

                            </div>
                            <div class="col-md-3">
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                        Información
                                    </div>
                                    <div class="panel-footer">
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Ingrese parámetros de búsqueda para consultar."></asp:Label><br />
                                    </div>
                                </asp:Panel>

                            </div>
                            <div class="row col-md-12">
                                <asp:GridView ID="grd004" CssClass="table table-bordered table-hover" PageSize="8" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="grd004_RowCommand" Visible="False" OnPageIndexChanging="grd004_PageIndexChanging1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cod. Ingreso">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ICodIngreso") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ICodIngreso") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PROYECTO">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CodProyecto") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CodProyecto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CodNino" HeaderText="Cod. Niño"></asp:BoundField>
                                        <asp:BoundField ItemStyle-CssClass="rut" DataField="Rut" HeaderText="RUN"></asp:BoundField>
                                        <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                        <asp:BoundField ItemStyle-CssClass="rut" DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                        <asp:BoundField DataField="sexo" HeaderText="Sexo"></asp:BoundField>
                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="Fecha de Nacimiento" HtmlEncode="false"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Región" Visible="false">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("codregion") %>' Visible="false"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_region" runat="server" Text='<%# Bind("codregion") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Ruc" HeaderText="RUC"></asp:BoundField>
                                        <asp:BoundField DataField="rit" ItemStyle-CssClass="Rut" HeaderText="RIT"></asp:BoundField>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName='<%# Bind("ICodIngreso") %>' CommandArgument='<%# Bind("codregion") %>'
                                                    Text="Ver"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                    <PagerStyle CssClass="pagination-ys" />
                                    <RowStyle CssClass="table-bordered  caja-tabla" />
                                </asp:GridView>
                            </div>
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
        <!-- Bootstrap core JavaScript
                ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <%--<script src="../js/bootstrap.min.js"></script>--%>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <%--<script src="../js/ie10-viewport-bug-workaround.js"></script>--%>
        <!-- Latest compiled and minified JavaScript -->
    </form>
</body>
</html>
