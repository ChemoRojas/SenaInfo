<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="edit_falta.aspx.cs" Inherits="mod_faltas_edit_falta" %>

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
    <title>Infracción :: Senainfo :: Servicio Nacional de Menores</title>
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script type="text/javascript" src="../Script/jquery.min.js"></script>
    <script type="text/javascript" src="../js/senainfoTools.js"></script>




    <script type="text/javascript">

        function AbrirURLModalPopUp(url) {
            $('#UpdateProgress1').fadeIn();
            parent.location.replace(url);

        }


        function max(txt_descripcionevento) {
            total = 200;
            tam = txt_descripcionevento.value.length;
            str = "";
            str = str + tam;
            Digitado.innerHTML = str;
            Restante.innerHTML = total - str;

            if (tam > total) {
                aux = txt_descripcionevento.value;
                txt_descripcionevento.value = aux.substring(0, total);
                Digitado.innerHTML = total
                Restante.innerHTML = 0
            }
        }
        function max2(txt_descrpIntervencion) {

            total = 200;
            tam = txt_descrpIntervencion.value.length;
            str = "";
            str = str + tam;
            digitado2.innerHTML = str;
            restante2.innerHTML = total - str;

            if (tam > total) {
                aux = txt_descrpIntervencion.value;
                txt_descrpIntervencion.value = aux.substring(0, total);
                digitado2.innerHTML = total
                restante2.innerHTML = 0
            }
        }
        function max3(txt_refuerzonegativo) {

            total = 200;
            tam = txt_refuerzonegativo.value.length;
            str = "";
            str = str + tam;
            digitado3.innerHTML = str;
            restante3.innerHTML = total - str;

            if (tam > total) {
                aux = txt_refuerzonegativo.value;
                txt_refuerzonegativo.value = aux.substring(0, total);
                digitado3.innerHTML = total
                restante3.innerHTML = 0
            }
        }




    </script>
</head>

<body class="body-form" role="document" onmousemove="SetProgressPosition(event)" onkeydown="return (event.keyCode!=13)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="imgbtn_guardar" />
            </Triggers>
            <ContentTemplate>
                <div class="container">
                    <div class="row">


                        <div class="col-md-12">
                            <h4 class="subtitulo-form">Niño(a) 
                            <asp:Label ID="lbl_nino" runat="server" Text="Label"></asp:Label>
                                <asp:Label ID="lbl_IDusuario" runat="server" Visible="False"></asp:Label>
                            </h4>
                            <p class="titulo-form">
                                <asp:Label ID="Label2" runat="server" Text="Evento Infracciones Disciplinarias"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Evento *</th>
                                    <td>
                                        
                                                    <asp:TextBox ID="cal001" runat="server" CssClass="form-control form-control-fecha-large input-sm" MaxLength="10" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                    <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="cal001" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="cal001" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                                
                                                    <asp:RangeValidator ID="RangeValidator903" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="cal001" Type="Date" OnInit="rv_fecha_Init" />
                                                
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Presenta Denuncia *</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_denuncia" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Amerita Infracción Disciplinaria *</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_falta" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Breve descripción evento</th>
                                    <td>
                                        <asp:TextBox ID="txt_descripcionevento" CssClass="form-control input-sm" runat="server" TextMode="MultiLine" onKeyUp="max(this);" onKeyPress="max(this);" Font-Names="Helvetica"></asp:TextBox>
                                        <asp:Label ID="Label13" runat="server" Text="Máximo 200 caracteres:"></asp:Label>
                                        <asp:Label ID="Label14" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="Digitado" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;
                                        <asp:Label ID="Label15" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="Restante" runat="server" Text="200"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label3" runat="server" Text="Comisión Disciplinaria"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">N° Acta</th>
                                    <td>
                                        <asp:TextBox ID="txt_numacta" CssClass="form-control form-control-fecha-large input-sm" runat="server" MaxLength="4">0</asp:TextBox>
                                        <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txt_numacta" ValidChars="0123456789-/" />
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Fecha Sesión</th>
                                    <td>
                                        
                                                    <asp:TextBox ID="cal002" runat="server" CssClass="form-control form-control-fecha-large input-sm" MaxLength="10" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                    <ajax:FilteredTextBoxExtender ID="fte3" runat="server" TargetControlID="cal002" ValidChars="0123456789-/" />
                                                    <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="cal002" Format="dd-MM-yyyy" ValidateRequestMode="Enabled" />
                                                
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="help-block" Display="Dynamic" ErrorMessage="Fecha Invalida" ControlToValidate="cal002" Type="Date" OnInit="rv_fecha_Init" />
                                               
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">FSe aplica sanción</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_sansion" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label4" runat="server" Text="Clasificación  Infracción(es) Disciplinaria(s)"></asp:Label></p>
                                <asp:Label ID="lbl_error_falta" CssClass="help-block" runat="server" Text="* Debe seleccionar al menos una Infracción Disciplinaria" Visible="False"></asp:Label>

                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Tipo Infracción Disciplinaria *</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_tipofalta" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceFaltas" DataTextField="Descripcion" DataValueField="CodTipoFalta" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipofalta_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceFaltas" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [CodTipoFalta], [Descripcion] FROM [parTipoFaltas] WHERE ([IndVigencia] = @IndVigencia)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lbl_vigencia" Name="IndVigencia" PropertyName="Text" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:Label ID="lbl_vigencia" runat="server" Text="v" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Infracción Disciplinaria *</th>
                                    <td>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="basic-addon1">1</span>
                                            <asp:DropDownList ID="ddl_f1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span1">2</span>
                                            <asp:DropDownList ID="ddl_falta2" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span2">3</span>
                                            <asp:DropDownList ID="ddl_falta3" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span3">4</span>
                                            <asp:DropDownList ID="ddl_falta4" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label5" runat="server" Text="Clasificacion sancion(es)"></asp:Label></p>
                                <asp:Label ID="lbl_error_sancion" runat="server" CssClass="help-block" Text="* Debe seleccionar al menos una sanción" Visible="False"></asp:Label>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Sanciones *</th>
                                    <td>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span4">1</span>
                                            <asp:DropDownList ID="ddl_sansion1" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span5">2</span>
                                            <asp:DropDownList ID="ddl_sansion2" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span6">3</span>
                                            <asp:DropDownList ID="ddl_sansion3" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="input-group">
                                            <span class="input-group-addon-telefono" id="Span7">4</span>
                                            <asp:DropDownList ID="ddl_sansion4" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label6" runat="server" Text="Duración sancion(es)"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">N° de días</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_numdias" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceDias" DataTextField="Descripcion" DataValueField="CodDuracionDiasSancion">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceDias" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [CodDuracionDiasSancion], [Descripcion] FROM [parDuracionDiasSancion]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">N° de meses</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_nummeses" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceMeses" DataTextField="Descripcion" DataValueField="CodDuracionMesSancion">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceMeses" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [CodDuracionMesSancion], [Descripcion] FROM [parDuracionMesSancion]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">N° de semanas</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_numsemanas" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceSemanas" DataTextField="Descripcion" DataValueField="CodDuracionSemanaSancion">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceSemanas" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodDuracionSemanaSancion] FROM [parDuracionSemanaSancion]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Ratificación Director/a</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_ratificacion" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label7" runat="server" Text="Formalidad registro sanción"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Medio de notificación al tribunal *</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_medioNotTrib" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceNotTribunal" DataTextField="Descripcion" DataValueField="CodMedioNotificacionTribunal">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceNotTribunal" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodMedioNotificacionTribunal] FROM [parMedioNotificacionTribunal]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Notificación tribunal</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_nottribunal" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Notificación joven *</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_notjoven" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceNotJoven" DataTextField="Descripcion" DataValueField="CodNotificacionJoven">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceNotJoven" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodNotificacionJoven] FROM [parNotificacionJoven]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Registro expediente</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_regexpediente" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label8" runat="server" Text="Ejecución debido proceso"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Considera reporte joven</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_reportejoven" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Revisión circunstancias responsabilidad</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_cirresponsabilidad" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Gestiones comprobación hecho</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_gestionhecho" align="center" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label9" runat="server" Text="Recurso revisión sanción"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Quien apela</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_quienapela" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceApela" DataTextField="Descripcion" DataValueField="CodQuienApela">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceApela" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodQuienApela] FROM [parQuienApela]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Se acoge</th>
                                    <td>
                                        <asp:SqlDataSource ID="SqlDataSourceAcoge" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodSeAcogeApelacion] FROM [parSeAcogeApelacion]"></asp:SqlDataSource>
                                        <asp:DropDownList ID="ddl_acogeapelacion" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceAcoge" DataTextField="Descripcion" DataValueField="CodSeAcogeApelacion">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label10" runat="server" Text="Procedimiento separación"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Se aplica</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_aplica" runat="server" align="center" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Duración</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_DuracionSep" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceDuracion" DataTextField="Descripcion" DataValueField="CodDuracionSeparacion">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceDuracion" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodDuracionSeparacion] FROM [parDuracionSeparacion]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Espacio de separación</th>
                                    <td>
                                        <asp:SqlDataSource ID="SqlDataSourceEspacio" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [CodEspacioSeparacion], [Descripcion] FROM [parEspacioSeparacion]"></asp:SqlDataSource>
                                        <asp:DropDownList ID="ddl_espacioSep" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceEspacio" DataTextField="Descripcion" DataValueField="CodEspacioSeparacion">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label11" runat="server" Text="Intervención educativa y refuerzo Negativo"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Se aplica *</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_aplicacionInterv" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceAplicacionInterv" DataTextField="Descripcion" DataValueField="CodAplicacionIntervencion">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceAplicacionInterv" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodAplicacionIntervencion] FROM [parAplicacionIntervencion]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Descripción intervencion Socioeducativa</th>
                                    <td>
                                        <asp:TextBox ID="txt_descrpIntervencion" CssClass="form-control input-sm" runat="server" MaxLength="200" TextMode="MultiLine" onKeyUp="max2(this);" onKeyPress="max2(this);"></asp:TextBox>
                                        <asp:Label ID="Label16" runat="server" Text="Máximo 200 caracteres:"></asp:Label>
                                        <asp:Label ID="Label17" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="digitado2" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="Label18" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="restante2" runat="server" Text="200"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Refuerzo Negativo</th>
                                    <td>
                                        <asp:DropDownList ID="ddl_CodRefNegativo" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceRefuerzoNeg" DataTextField="Descripcion" DataValueField="CodRefuerzoNegativoAdicional">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSourceRefuerzoNeg" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodRefuerzoNegativoAdicional] FROM [parRefuerzoNegativoAdicional]"></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Descripción otro refuerzo negativo</th>
                                    <td>
                                        <asp:TextBox ID="txt_refuerzonegativo" CssClass="form-control input-sm" runat="server" MaxLength="200" TextMode="MultiLine" onKeyUp="max3(this);" onKeyPress="max3(this);"></asp:TextBox>
                                        <asp:Label ID="Label19" runat="server" Text="Máximo 200 caracteres:"></asp:Label>
                                        <asp:Label ID="Label20" runat="server" Text="Escritos"></asp:Label>
                                        <asp:Label ID="digitado3" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="Label21" runat="server" Text="Restantes"></asp:Label>
                                        <asp:Label ID="restante3" runat="server" Text="200"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <p class="titulo-form">
                                <asp:Label ID="Label12" runat="server" Text="Conflicto crítico"></asp:Label></p>
                            <table class="table table-bordered table-col-fix table-condensed">
                                <tr>
                                    <th class="titulo-tabla" scope="row">Constituye</th>
                                    <td>
                                        <asp:RadioButtonList ID="rdb_constituye" runat="server" align="center" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">SI&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="titulo-tabla" scope="row">Procedimiento Genchi</th>
                                    <td>
                                        <asp:SqlDataSource ID="SqlDataSourceConflictoCrit" runat="server" ConnectionString="<%$ ConnectionStrings:senainfoConnectionString1 %>" SelectCommand="SELECT [Descripcion], [CodConflictoCritico] FROM [parConflictoCritico]"></asp:SqlDataSource>
                                        <asp:DropDownList ID="ddl_ConflictoCritico" CssClass="form-control input-sm" runat="server" DataSourceID="SqlDataSourceConflictoCrit" DataTextField="Descripcion" DataValueField="CodConflictoCritico">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="botonera pull-right">
                            <asp:LinkButton ID="imgbtn_guardar" CssClass="btn btn-danger btn-sm fixed-width-button" runat="server" OnClick="imgbtn_guardar_Click" Text="" AutoPostback="true">
                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar
                            </asp:LinkButton>
                            <asp:LinkButton ID="imgbtn_limpiar" CssClass="btn btn-info btn-sm fixed-width-button" runat="server" OnClick="imgbtn_limpiar_Click" Text="" AutoPostback="true">
                               <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar

                            </asp:LinkButton>

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
    </form>
</body>
<script type="text/javascript">
    max(txt_descripcionevento);
    max2(txt_descrpIntervencion);
    max3(txt_refuerzonegativo);
</script>
</html>
