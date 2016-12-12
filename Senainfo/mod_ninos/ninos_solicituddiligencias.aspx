<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="ninos_solicituddiligencias.aspx.cs" Inherits="mod_ninos_ninos_solicituddiligencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Diligencias</title>


    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
        <script src="js/html5shiv.min.js"></scrbtn001ipt>
        <script src="js/respond.min.js"></script>
    <![endif] -->

    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../Script/jquery-1.4.3.min.js"></script>

    <script type="text/javascript">

        function RefrescaPadre() {
            window.parent.MFref_SolDil();
            window.parent.close();
        };

        function AbrirVentana(url) {
            window.open(url);
        };






        ////--------------------------------------------------------------------SOLICITUD DE DILIGENCIA ---------------------------------------------------------------------------

        //window.MFref_SolDil = function () {
        //    $find("mpe1a").hide();
        //    document.getElementById('BtnFun_SolDil').click();
        //}
        //// Boton "Agregar Nueva Solicitud" (de diligencia)
        //function MostrarModalSolicitudDiligencia() {
        //    PestañaActual(1);
        //    var objIframe = document.getElementById('iframe_Solicitud_Diligencia');
        //    objIframe.height = "600px";
        //    objIframe.width = "800px";
        //    limpiaiframe(objIframe);
        //    objIframe.src = 'ninos_solicituddiligencias.aspx';
        //    $find("mpe1a").show();
        //    return false;
        //}

        //// BOTON INVISIBLE btn0012
        //function MostrarModalUtab1() {
        //    var objIframe = document.getElementById('iframe_Solicitud_Diligencia2');
        //    objIframe.height = "600px";
        //    objIframe.width = "800px";
        //    $find("mpe1a2").show();
        //    return false;
        //}

        //// LINKBUTTON "Modificar"
        //function LlamaUtab1(ICodDiligencia) {
        //    PestañaActual(1);
        //    var objIframe = document.getElementById('iframe_Solicitud_Diligencia2');
        //    objIframe.src = 'ninos_solicituddiligencias.aspx?ICodDiligencia=' + ICodDiligencia;
        //    limpiaiframe(objIframe);
        //    document.getElementById('btn0012').click();
        //    return false;
        //}
    </script>
</head>
<body class="body-form">
    <div class="container">
        <div class="row">
            <div class="col-md-12 caja-tabla">

                <form id="form1" runat="server">

                    <asp:ScriptManager ID="ScriptManager_datosGestion" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btn001" />
                            <%--<asp:PostBackTrigger ControlID="btn002" />--%>
                            <asp:PostBackTrigger ControlID="btn003" />
                        </Triggers>

                        <ContentTemplate>

                            <h4>
                                <label class="titulo-form">
                                    Diligencias</label>
                                <asp:Label ID="ll002" Text="" runat="server" />
                            </h4>

                            <table class="table table-bordered table-col-fix table-condensed caja tabla">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha de Solicitud *</th>

                                 

                                    <td>

                                        <asp:TextBox ID="cal001" class="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1063" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal001" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="help-block" runat="server" ValidationGroup="grupo1" ControlToValidate="cal001" Display="Dynamic" ErrorMessage="Fecha Requerida"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Enabled="true" CssClass="help-block" ValidationGroup="grupo1" ControlToValidate="cal001" runat="server" ErrorMessage="Fecha Inv&aacute;lida" Display="Dynamic" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        
                                    </td>



                                </tr>

                                <tr>
                                    <th class="titulo-tabla" scope="row">Tipo de Solicitante *</th>
                                    <%--<td class="texto_form" style="height: 24px">Tipo de Solicitante</td>--%>
                                    <td>
                                        <span>
                                            <asp:DropDownList ID="ddown001" class="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                            </asp:DropDownList>

                                        </span>

                                    </td>
                                </tr>

                                <tr>
                                    <%--<td class="texto_form">Diligencias</td>--%>
                                    <th class="titulo-tabla" scope="row">Diligencias *</th>

                                    <td>
                                        <span>
                                            <asp:DropDownList ID="ddown002" runat="server" class="form-control input-sm" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="0">Seleccionar </asp:ListItem>
                                            </asp:DropDownList>

                                        </span>

                                    </td>
                                </tr>

                                <tr runat="server" visible="false" id="fueRealizada">

                                    <th class="titulo-tabla" scope="row">¿Fue realizada?</th>

                                    <td><div class="text-center">
                                        <label>
                                            <asp:RadioButton ID="rdo001" type="radio" runat="server" GroupName="rdogroup001" AutoPostBack="True" OnCheckedChanged="rdo001_CheckedChanged" />
                                            SI
                                        </label>
                                        &nbsp 
                                                             <label>
                                                                 <asp:RadioButton ID="rdo002" type="radio" runat="server" GroupName="rdogroup001" OnCheckedChanged="rdo002_CheckedChanged" Checked="true" AutoPostBack="True" />
                                                                 NO
                                                             </label>
                                        &nbsp
                                                             <label runat="server" visible="false">
                                                                 <asp:RadioButton ID="rdo003" type="radio" runat="server" GroupName="rdogroup001" AutoPostBack="True" OnCheckedChanged="rdo003_CheckedChanged" Visible="false" />
                                                                 NO FUE POSIBLE
                                                             </label>
                                        </div>
                                    </td>

                                </tr>

                                <tr runat="server" id="fila_01">
                                    <%--<td class="texto_form">Fecha Realizada</td>--%>
                                    <th class="titulo-tabla" scope="row">Fecha Realizada</th>

                                    <td>

                                        <asp:TextBox ID="cal002" class="form-control form-control-fecha-large input-sm" placeholder="dd-mm-aaaa" runat="server" ReadOnly="true" OnTextChanged="cal002_ValueChanged" />
                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende1075" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="cal002" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Enabled="true" ControlToValidate="cal002" runat="server" ErrorMessage="Fecha Inv&aacute;lida" CssClass="help-block" ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$" />
                                        <asp:Label ID="lbl001" runat="server" CssClass="texto_rojo_peque"></asp:Label>
                                        <asp:Label ID="lbl002" runat="server" CssClass="texto_rojo_peque"></asp:Label>
                                    </td>
                                </tr>

                                <tr runat="server" id="fila_02">
                                    <%--<td class="texto_form">Técnico</td>--%>
                                    <th class="titulo-tabla" scope="row">Profesional / Técnico</th>
                                    <td>
                                        <asp:DropDownList ID="ddown003" class="form-control input-sm" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>

                                <tr runat="server" id="fila_03">
                                    <%--<td class="texto_form" style="height: 38px">Propuesta Técnica de Discerniento</td>--%>
                                    <th class="titulo-tabla" scope="row">Propuesta Técnica de Discernimiento</th>
                                    <td><div class="text-center">
                                        <label>
                                            <asp:RadioButton ID="rdo004" type="radio" runat="server" GroupName="rdogroup002" />
                                            CON DISCERNIMIENTO <%--Font-size:11--%>  <%--Font-Names="Arial"--%>
                                        </label>
                                        <label>
                                            <asp:RadioButton ID="rdo005" type="radio" runat="server" GroupName="rdogroup002" />
                                            SIN DISCERNIMIENTO
                                        </label>
                                        <label>
                                            <asp:RadioButton ID="rdo006" type="radio" runat="server" GroupName="rdogroup002" />
                                            SIN EVALUACIÓN
                                        </label>
                                        </div>
                                    </td>

                                </tr>


                                <tr runat="server" id="fila_04">
                                    <%--<td class="texto_form">Resultado Discernimiento Tribunal</td>--%>
                                    <th class="titulo-tabla" scope="row">Resultado Discernimiento Tribunal</th>

                                    <td><div class="text-center">
                                        <label>
                                            <asp:RadioButton ID="rdo007" type="radio" runat="server" GroupName="rdogroup003" />
                                            CON DISCERNIMIENTO
                                        </label>

                                        <label>
                                            <asp:RadioButton ID="rdo008" type="radio" runat="server" GroupName="rdogroup003" />
                                            SIN DISCERNIMIENTO
                                        </label>

                                        <label>
                                            <asp:RadioButton ID="rdo009" type="radio" runat="server" GroupName="rdogroup003" />
                                            SIN EVALUACIÓN
                                        </label>
                                        </div>
                                    </td>
                                </tr>
                                </table>
                                <table class="table table-borderless ">
                                <tr>
                                    <td colspan="2">
                                        <div class=" pull-right">

                                            <asp:LinkButton class="btn btn-danger btn-sm" ID="btn001" runat="server" OnClick="btn001_Click" Text="" ValidationGroup="grupo1">
                               <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar Nueva Diligencia

                                            </asp:LinkButton>
                                            <asp:LinkButton class="btn btn-info btn-sm fixed-width-button" ID="btn003" runat="server" OnClick="btn003_Click" CausesValidation="False">
                               <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar

                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>

                            </table>

                            <%-- <div style="text-align: center">
                                 <div style="text-align: left; width: 551px; display: block; margin-left: auto; margin-right: auto;">

                                     
                                 </div>

                             </div>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </form>

            </div>
        </div>
    </div>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../js/ie10-viewport-bug-workaround.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <%--<script src="http://code.jquery.com/jquery-latest.js"></script>--%>
</body>
</html>
