<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rep_ninosAdoptabilidad.aspx.cs" Inherits="mod_reportes_Rep_ninosAdoptabilidad" Culture="es-CL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<html lang="es">
<head id="Head1" runat="server">
    <title>Reportes :: SenaInfo :: Servicio Nacional de Menores</title>

    <link rel="icon" href="../img/favicon.ico">
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/ventanas-modales.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">

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
  </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
         <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="Updatepanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_buscar" />
            </Triggers>
            <ContentTemplate>
                <div>
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <!--<li><a href="#">Home</a></li>-->
                            <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                            <li><a href="#">Reportes</a>
                            </li>
                            <li class="active">Reportes niños Adoptabilidad</li>
                        </ol>
                        <div class="alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                            <asp:Label ID="lbl_error" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Reportes niños Adoptabilidad</h4>
                            <hr>
                            <div class="row">
                                <div class="col-md-9">
                                    <form class="form-horizontal" action="">
                                        <table class="table table-borderless table-condensed table-col-fix">
                                            <tr>
                                                <th>
                                                    <label for="">Región:</label>
                                                </th>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddregion" runat="server" CssClass="form-control input-sm" AutoPostBack="True"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    <label for="">Fecha Inicio :</label>
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="cal_inicio" runat="server" EDITABLE="False" CssClass="form-control form-control-fecha input-sm" placeholder="dd-mm-aaaa" />
                                                    <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender328" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_inicio" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <asp:RangeValidator ID="RangeValidator903" ValidationGroup="valError" runat="server" ForeColor="Red" Text="Fecha Invalida" ControlToValidate="cal_inicio" Type="Date" OnInit="rv_fecha_Init" />&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="FechaDiag" runat="server" ControlToValidate="cal_inicio" ForeColor="Red" ErrorMessage="">
                                                    </asp:RequiredFieldValidator>

                                                </td>
                                                <td>
                                                    <label for="">
                                                        Fecha Término :</label></td>
                                                <td>
                                                    <asp:TextBox ID="cal_termino" runat="server" CssClass="form-control form-control-fecha input-sm" EDITABLE="False" placeholder="dd-mm-aaaa" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cal_termino" ErrorMessage="" ForeColor="Red" ValidationGroup="FechaDiag">
                                                    </asp:RequiredFieldValidator>
                                                    <Ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal_termino" ValidChars="0123456789-/" />
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="cal_termino" ForeColor="Red" OnInit="rv_fecha_Init" Text="Fecha Invalida" Type="Date" ValidationGroup="valError" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>&nbsp;</th>
                                                <td colspan="3">
                                                    <Ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal_termino" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </form>
                                </div>
                                <!--fin col-md-9 -->
                                <div class="col-md-3">
                                    <p class="subtitulo-form">Buscar Niño(a) en la Red:</p>
                                    <div>

                                        <asp:LinkButton CssClass="btn btn-success btn-sm" ID="btn_buscar" ValidationGroup="valError" runat="server" OnClick="btn_buscar_Click"><span class="glyphicon glyphicon-zoom-in"></span> Exportar</asp:LinkButton>


                                        <asp:LinkButton ID="btn_limpiar" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm" OnClick="btn_limpiar_Click"><span class="glyphicon glyphicon-remove-sign"></span> Limpiar</asp:LinkButton>

                                    </div>

                                </div>
                            </div>
                            <!--cierra Row-->
                            <!--Row para desplegar tabla con datos-->

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
    </form>
</body>
     <script src="../js/jquery-1.10.2.js"></script> 
    <script src="../js/bootstrap.min.js"></script> 
    <script src="../js/jquery-1.7.2.min.js"></script>    
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/bootstrap.min.js"></script>
</html>
