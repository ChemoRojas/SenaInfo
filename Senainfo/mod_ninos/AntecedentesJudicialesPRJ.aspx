<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AntecedentesJudicialesPRJ.aspx.cs" Inherits="mod_ninos_AntecedentesJudicialesPRJ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>

<html lang="es">
<head runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Antecedentes Judiciales</title>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="../css/theme.css" rel="stylesheet">

    <script type="text/javascript">
        function cleanForm() {}

    </script>
    <style>
        .avoid-clicks
        {
            pointer-events: none;
        }

        .btnIguales
        {
            width: 100%;
        }        
    </style>
</head>
<body class="body-form well" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="container">
                    <h4>
                        <label class="titulo-form">Antecedentes Judiciales PRJ</label></h4>
                    <div class="row">
                        <div class="col-md-12">

                            <asp:Panel ID="pnlAvisoAntecedente" Visible="false" runat="server" CssClass="panel-info panel-primary-info text-center nopadding">
                                <div class="panel-heading ">
                                    Información
                                </div>
                                <div class="panel-footer">
                                    <p>
                                        <asp:Label ID="lblAvisoAntecedente" CssClass="subtitulo-form-info" runat="server" Text="Este(a) niño(a) no posee registros de Antecedente Judicial"></asp:Label>
                                    </p>
                                </div>
                            </asp:Panel>

                            <asp:GridView ID="grdAntecedentesJudicialesPRJ" CssClass="table table-bordered table-hover caja-tabla tabla-tabs" AutoPostback="true" OnRowCommand="grdAntecedentesJudicialesPRJ_RowCommand" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%">
                                <HeaderStyle CssClass="titulo-tabla" />
                                <Columns>
                                    <asp:BoundField DataField="CodAntecedenteJudicialPRJ" HeaderText="Cod. Antecedente Judicial "></asp:BoundField>
                                    <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Registro Antecedente" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="DescripcionTipoMateria" HeaderText="Tipo de Materia" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="RIT" HeaderText="RIT" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="DescripcionTribunal" HeaderText="Tribunal" HtmlEncode="False"></asp:BoundField>
                                    <asp:ButtonField Text="Ver" HeaderText="Seleccionar"></asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                            <table class="table">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="btnGatillo" runat="server" AutoPostback="true" CssClass="btn btn-primary btn-sm pull-right" OnClick="btnGatillo_Click">
                                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Registrar Nuevo Antecedente Judicial
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="lblAvisoDiagnostico" runat="server" CssClass="help-block"></asp:Label>
                            <table class="table table-bordered table-condensed">
                                <tbody>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Fecha Antecedente Judicial *</th>
                                        <td class="col-md-4" colspan="3">

                                            <asp:TextBox ID="txtFechaAntecedenteJudicial" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFechaAntecedenteJudicial" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende379" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaAntecedenteJudicial" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaAntecedenteJudicial" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Región *</th>
                                        <td>
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Comuna *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlComuna" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Representante Legal del Niño *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnRepresentanteLegalSi" runat="server" AutoPostBack="true" GroupName="rbtnRepresentanteLegal" OnCheckedChanged="rbtnRepresentanteLegal_CheckedChanged" Text="Si" />&nbsp;
                                            <asp:RadioButton ID="rbtnRepresentanteLegalNo" runat="server" AutoPostBack="true" Checked="true" GroupName="rbtnRepresentanteLegal" OnCheckedChanged="rbtnRepresentanteLegal_CheckedChanged" Text="No" />
                                        </td>
                                        <th id="thQuienRepresentanteLegal" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">Quién es el Representante Legal *</th>
                                        <td id="tdQuienRepresentanteLegal" runat="server" visible="false" class="col-md-4">
                                            <asp:DropDownList ID="ddlRepresentanteLegal" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Representante Judicial / Cuidado Personal *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnRepresentanteJudicialSi" runat="server" AutoPostBack="true" GroupName="rbtnRepresentanteJudicial" OnCheckedChanged="rbtnRepresentanteJudicial_CheckedChanged" Text="Si" />&nbsp;
                                            <asp:RadioButton ID="rbtnRepresentanteJudicialNo" runat="server" AutoPostBack="true" Checked="true" GroupName="rbtnRepresentanteJudicial" OnCheckedChanged="rbtnRepresentanteJudicial_CheckedChanged" Text="No" />
                                        </td>
                                        <th id="thQuienRepresentanteJudicial" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">Quién es el Representante Judicial *</th>
                                        <td id="tdQuienRepresentanteJudicial" runat="server" visible="false" class="col-md-4">
                                            <asp:DropDownList ID="ddlRepresentanteJudicial" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Tipo de Cuidado Personal *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlTipoCuidadoPersonal" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Susceptibilidad de Adopción </th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlSusceptibilidad" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">NNA Tiene Curador Ad Litem *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnNNACuradorAdLitemSi" runat="server" OnCheckedChanged="rbtnNNACuradorAdLitem_CheckedChanged" AutoPostBack="true" GroupName="rbtnNNACuradorAdLitem" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnNNACuradorAdLitemNo" runat="server" Checked="true" OnCheckedChanged="rbtnNNACuradorAdLitem_CheckedChanged" AutoPostBack="true" GroupName="rbtnNNACuradorAdLitem" Text="No" />
                                        </td>
                                        <th id="thNNACuradorAdLitem" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">Curador Ad Litem *</th>
                                        <td id="tdNNACuradorAdLitem" runat="server" visible="false" class="col-md-4">
                                            <asp:DropDownList ID="ddlNNACuradorAdLitem" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Abogado PRJ ha Sostenido Entrevista con NNA Representado *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnAbogadoEntrevistaRepresentanteNNASi" runat="server" AutoPostBack="true" GroupName="rbtnAbogadoEntrevistaRepresentanteNNA" OnCheckedChanged="rbtnAbogadoEntrevistaRepresentanteNNA_CheckedChanged" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnAbogadoEntrevistaRepresentanteNNANo" runat="server" AutoPostBack="true" Checked="true" GroupName="rbtnAbogadoEntrevistaRepresentanteNNA" OnCheckedChanged="rbtnAbogadoEntrevistaRepresentanteNNA_CheckedChanged" Text="No" />
                                        </td>

                                    </tr>
                                    <tr id="trEntrevistaRepresentanteNNA" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Fecha Última Entrevista *</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txtFechaUltimaEntrevista" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtFechaUltimaEntrevista" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaUltimaEntrevista" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaUltimaEntrevista" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Motivo Última Entrevista *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlMotivoUltimaEntrevista" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trSintesisEntrevistaRepresentanteNNA" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Síntesis de Contenido de Entrevista, Señalando la Opinión Expresada por NNA *</th>
                                        <td class="col-md-4" colspan="3">
                                            <asp:TextBox ID="txtSintesisEntrevistaRepresentanteNNA" CssClass="form-control form-control input-sm" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla" scope="row">Profesional / Técnico *</th>
                                        <td>
                                            <asp:DropDownList ID="ddlProfesionalTecnico" CssClass="form-control input-sm" runat="server">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla" scope="row">Observaciones</th>
                                        <td>
                                            <asp:TextBox ID="txtObservaciones" CssClass="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="table table-bordered table-condensed">
                                <tbody>
                                    <tr>
                                        <td colspan="4">
                                            <h4>
                                                <h4>
                                                    <label class="titulo-form">Materia</label></h4>
                                            </h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Tipo Materia *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlTipoMateria" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddlTipoMateria_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Materia Causa *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlMateria" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right" ID="btnAgregarMateria" runat="server" OnClick="btnAgregarMateria_Click" Text="Guardar" AutoPostback="true">
                                            <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar Materia
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr id="trGrdMateria" runat="server" visible=" false">
                                        <td colspan="4">
                                            <asp:GridView ID="grdMateria" Width="100%" CssClass="table table table-bordered table-hover" runat="server" OnRowCommand="grdMateria_RowCommand" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Tipo de Materia" DataField="DescripcionTipoMateria"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Materia" DataField="DescripcionMateria"></asp:BoundField>
                                                    <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                                </Columns>
                                                <HeaderStyle CssClass="titulo-tabla" />
                                                <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trAvisoMateria" runat="server" visible="false">
                                        <td colspan="4">
                                            <div class="alert alert-warning text-center" role="alert">
                                                <asp:Label ID="lblAvisoMateria" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="tblCausaFamilia" runat="server" visible="false" class="table table-bordered table-condensed">
                                <tbody>
                                    <tr>
                                        <td colspan="4">
                                            <h4>
                                                <label class="titulo-form">Materia Causa Familia</label></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Tribunal *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlTribunalCausaFamilia" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">RUC *</th>
                                        <td>
                                            <asp:TextBox ID="txtRUCCausaFamilia" runat="server" CssClass="form-control form-control input-sm" placeholder="YYONNNNNNN-D" MaxLength="12"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="fte2" runat="server" TargetControlID="txtRUCCausaFamilia" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />
                                            <asp:CustomValidator ID="cv_txt006F2" runat="server" ControlToValidate="txtRUCCausaFamilia" Display="Dynamic" CssClass="help-block" ErrorMessage="RUC inválido. " ClientValidationFunction="ValidaRuc" />
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">RIT *</th>
                                        <td>
                                            <asp:TextBox ID="txtRITCausaFamilia" runat="server" CssClass="form-control form-control-fecha input-sm" placeholder="Ingresar"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Calidad en que Comparece PRJ *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlCalidadComparecePRJCausaFamilia" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Director/a del Proyecto PRJ Tiene Clave SITFA *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnDirectorClaveSITFASi" runat="server" GroupName="rbtnDirectorClaveSITFA" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnDirectorClaveSITFANo" runat="server" GroupName="rbtnDirectorClaveSITFA" Text="No" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Requirente de la Medida de Protección *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlRequirenteMedida" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Vínculo con el Ofensor *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlVinculoOfensor" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <h4>
                                                <label class="subtitulo-form">Causa Proteccional</label>
                                            </h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Estado de la Causa *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlEstadoCausaFamilia" CssClass="form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoCausaFamilia_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Audiencia *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlAudiencia" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Fecha Audiencia *</th>
                                        <td class="col-md-4" colspan="3">
                                            <asp:TextBox ID="txtFechaAudienciaFamilia" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtFechaAudienciaFamilia" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtende500" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaAudienciaFamilia" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator40" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaAudienciaFamilia" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right" ID="lnkAgregarAudiencia" runat="server" OnClick="lnkAgregarAudiencia_Click" Text="Guardar" AutoPostback="true">
                                            <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar Audiencia
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr id="trGrdAudiencia" runat="server" visible=" false">
                                        <td colspan="4">
                                            <asp:GridView ID="grdAudiencia" Width="100%" CssClass="table table table-bordered table-hover" runat="server" OnRowCommand="grdAudiencia_RowCommand" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Estado de la Causa Familia" DataField="DescripcionEstadoCausaFamilia"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Audiencia" DataField="DescripcionAudiencia"></asp:BoundField>
                                                    <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                                </Columns>
                                                <HeaderStyle CssClass="titulo-tabla" />
                                                <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trAvisoAudiencia" runat="server" visible="false">
                                        <td colspan="4">
                                            <div class="alert alert-warning text-center" role="alert">
                                               <asp:Label ID="lblAvisoAudiencia" runat="server" />
                                            </div>
                                        </td>
                                    </tr>

                                    <tr id="trMedidaCautelar" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Medidas Cautelares *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlMedidaCautelar" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:LinkButton CssClass="btnIguales btn btn-info btn-sm pull-right" ID="lnkAgregarMedidaCautelar" OnClick="lnkAgregarMedidaCautelar_Click" runat="server" Text="Guardar" AutoPostback="true">
                                            <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar Medida Cautelar
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr id="trGrdMedidaCautelar" runat="server" visible=" false">
                                        <td colspan="4">
                                            <asp:GridView ID="grdMedidaCautelar" Width="100%" CssClass="table table table-bordered table-hover" OnRowCommand="grdMedidaCautelar_RowCommand" runat="server" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Medida Cautelar" DataField="DescripcionMedidaCautelar"></asp:BoundField>
                                                    <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                                </Columns>
                                                <HeaderStyle CssClass="titulo-tabla" />
                                                <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trAvisoMedidaCautelar" runat="server" visible="false">
                                        <td colspan="4">                                            
                                            <div class="alert alert-warning text-center" role="alert">
                                                <asp:Label runat="server" ID="lblAvisoMedidaCautelar"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table id="tblCausaPenal" runat="server" visible="false" class="table table-bordered table-condensed">
                                <tbody>
                                    <tr>
                                        <td colspan="4">
                                            <h4>
                                                <label class="titulo-form">Materia Causa Penal</label></h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Calidad en que comparece PRJ *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlCalidadComparecePRJCausaPenal" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Fecha de Denuncia *</th>
                                        <td class="col-md-4">

                                            <asp:TextBox ID="txtFechaDenuncia" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFechaDenuncia" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="Calendarextender1" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaDenuncia" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaDenuncia" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Quién es el Denunciante *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlQuienDenunciante" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">PRJ Presenta Querella *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnPRJPresentaQuerellaSi" runat="server" AutoPostBack="true" GroupName="rbtnPRJPresentaQuerella" OnCheckedChanged="rbtnPRJPresentaQuerella_CheckedChanged" Text="Si" />&nbsp;
                                            <asp:RadioButton ID="rbtnPRJPresentaQuerellaNo" runat="server" AutoPostBack="true" GroupName="rbtnPRJPresentaQuerella" Checked="true" OnCheckedChanged="rbtnPRJPresentaQuerella_CheckedChanged" Text="No" />
                                        </td>
                                        <th id="thPRJFechaPresentacionQuerella" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">Fecha de Presentación de Querella *</th>
                                        <td id="tdPRJFechaPresentacionQuerella" runat="server" visible="false" class="col-md-4">
                                            <asp:TextBox ID="txtPRJFechaPresentacionQuerella" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPRJFechaPresentacionQuerella" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="Calendarextender2" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtPRJFechaPresentacionQuerella" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtPRJFechaPresentacionQuerella" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Vínculo con el Victimario *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlVinculoVictimario" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Tribunal *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlTribunalCausaPenal" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Fiscalía a Cargo de Investigación *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlFiscaliaInvestigacion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>

                                        <th class="titulo-tabla col-md-1" scope="row">RUC *</th>
                                        <td>
                                            <asp:TextBox ID="txtRUCCausaPenal" runat="server" CssClass="form-control form-control input-sm" placeholder="YYONNNNNNN-D" MaxLength="12"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtRUCCausaPenal" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789-" />
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtRUCCausaPenal" Display="Dynamic" CssClass="help-block" ErrorMessage="RUC inválido. " ClientValidationFunction="ValidaRuc" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">RIT *</th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtRitCausaPenal" runat="server" CssClass="form-control form-control-fecha input-sm" placeholder="Ingresar"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="titulo-tabla col-md-1" scope="row">Estado de la Causa *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlEstadoCausaPenal" CssClass="form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoCausaPenal_SelectedIndexChanged" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Categoría Investigación *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlCategoriaInvestigación" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlCategoriaInvestigación_SelectedIndexChanged" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th id="thCategoriaInvestigacionCerrada" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">Categoría Investigación Cerrada *</th>
                                        <td id="tdCategoriaInvestigacionCerrada" runat="server" visible="false" class="col-md-4">
                                            <asp:DropDownList ID="ddlCategoriaInvestigacionCerrada" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlCategoriaInvestigacionCerrada_SelectedIndexChanged" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th id="thFechaFormalizacion" runat="server" visible="false" class="titulo-tabla col-md-1" scope="row">Fecha Formalización *</th>
                                        <td id="tdFechaFormalizacion" runat="server" visible="false" class="col-md-4">
                                            <asp:TextBox ID="txtFechaFormalizacion" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtFechaFormalizacion" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="Calendarextender6" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaFormalizacion" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaFormalizacion" Type="Date" OnInit="rv_fecha_Init" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr id="trAcusacion" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Categoría Acusación *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlCategoriaAcusacion" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="2">
                                            <asp:LinkButton CssClass="btn btn-info btn-sm pull-right" ID="lnkAgregarCategoriaAcusacion" OnClick="lnkAgregarCategoriaAcusacion_Click" runat="server" Text="Guardar" AutoPostback="true">
                                            <span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar Categoria Acusacion
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr id="trGrdCategoriaAcusacion" runat="server" visible=" false">
                                        <td colspan="4">
                                            <asp:GridView ID="grdCategoriaAcusacion" Width="100%" CssClass="table table table-bordered table-hover" OnRowCommand="grdCategoriaAcusacion_RowCommand" runat="server" AutoGenerateColumns="False" CellPadding="4" Visible="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Categoría Acusación" DataField="DescripcionCategoriaInvestigacion"></asp:BoundField>
                                                    <asp:ButtonField Text="Eliminar" CommandName="E" HeaderText="Seleccionar"></asp:ButtonField>
                                                </Columns>
                                                <HeaderStyle CssClass="titulo-tabla" />
                                                <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="trAvisoCategoriaAcusacion" runat="server" visible="false">
                                        <td colspan="4">                                            
                                            <div class="alert alert-warning text-center" role="alert">
                                                <asp:Label runat="server" ID="lblAvisoCategoriaAcusacion"></asp:Label>
                                            </div>
                                        </td>

                                    </tr>

                                    <tr id="trCategoriaConAcusacion" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Categoría con Acusación *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlCategoriaConAcusacion" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoriaConAcusacion_SelectedIndexChanged" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trAudienciaPreparacionJuicio" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Audiencia de Preparación del Juicio Oral *</th>
                                        <td colspan="3" class="col-md-4">
                                            <asp:DropDownList ID="ddlAudienciaPreparacionJuicio" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trProcedimientoAbreviado" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Procedimiento Abreviado *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnProcedimientoAbreviadoSi" runat="server" AutoPostBack="true" GroupName="rbtnProcedimientoAbreviado" OnCheckedChanged="rbtnProcedimientoAbreviado_CheckedChanged" Text="Si" />&nbsp;
                                    <asp:RadioButton ID="rbtnProcedimientoAbreviadoNo" runat="server" AutoPostBack="true" GroupName="rbtnProcedimientoAbreviado" OnCheckedChanged="rbtnProcedimientoAbreviado_CheckedChanged" Text="No" />
                                        </td>
                                    </tr>
                                    <tr id="trSentencia" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Sentencia *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlSentencia" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlSentencia_SelectedIndexChanged" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trDuracionJuicio" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Duración del Juicio *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlTipoDuracionJuicio" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlSentencia_SelectedIndexChanged" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                <asp:ListItem Value="Dias">Días</asp:ListItem>
                                                <asp:ListItem Value="Semanas">Semanas</asp:ListItem>
                                                <asp:ListItem Value="Meses">Meses</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Cantidad Duración Juicio*</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txtCantidadDuracionJuicio" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="3" placeholder="Cantidad" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtCantidadDuracionJuicio" ValidChars="0123456789" />
                                        </td>
                                    </tr>
                                    <tr id="trFechaProgramadaAudiencia" runat="server" visible="false">
                                        <th runat="server" class="titulo-tabla col-md-1" scope="row">Fecha Programada para la Audiencia de Juicio *</th>
                                        <td class="col-md-4">
                                            <asp:TextBox ID="txtFechaProgramadaAudiencia" CssClass="form-control form-control-fecha input-sm" runat="server" MaxLength="10" placeholder="dd-mm-aaaa" />
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtFechaProgramadaAudiencia" ValidChars="0123456789-/" />
                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="Calendarextender9" runat="server" Enabled="true" Format="dd-MM-yyyy" TargetControlID="txtFechaProgramadaAudiencia" ValidateRequestMode="Enabled" ViewStateMode="Enabled" />
                                            <asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="Fecha Fuera de Rango" ValidationGroup="ValidaFicha" ControlToValidate="txtFechaProgramadaAudiencia" Type="Date" OnInit="rv_fecha_Init2" CssClass="help-block" Display="Dynamic" />
                                        </td>
                                    </tr>
                                    <tr id="trCategoriaRecursoNulidad" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Categría Recurso de Nulidad *</th>
                                        <td>
                                            <asp:RadioButton ID="rbtnCategoriaRecursoNulidadSi" runat="server" AutoPostBack="true" OnCheckedChanged="rbtnCategoriaRecursoNulidad_CheckedChanged" GroupName="rbtnCategoriaRecursoNulidad" Text="Si" />&nbsp;
                                            <asp:RadioButton ID="rbtnCategoriaRecursoNulidadNo" runat="server" AutoPostBack="true" Checked ="true" OnCheckedChanged="rbtnCategoriaRecursoNulidad_CheckedChanged" GroupName="rbtnCategoriaRecursoNulidad" Text="No" />
                                            <asp:RadioButton ID="rbtnCategoriaRecursoNulidadPlazoVigente" runat="server" AutoPostBack="true" Checked ="true" OnCheckedChanged="rbtnCategoriaRecursoNulidad_CheckedChanged" GroupName="rbtnCategoriaRecursoNulidad" Text="Plazo Vigente" />
                                        </td>
                                    </tr>
                                    <tr id="trPersonayFalloRecursoNulidad" runat="server" visible="false">
                                        <th class="titulo-tabla col-md-1" scope="row">Quien Interpone Recursos *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlQuienInterponeRecursos" CssClass="form-control input-sm" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <th class="titulo-tabla col-md-1" scope="row">Fallo del Recurso *</th>
                                        <td class="col-md-4">
                                            <asp:DropDownList ID="ddlFalloRecurso" CssClass="form-control input-sm" AutoPostBack="true" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>

                            <table class="table">
                                <tr>
                                    <td>
                                        <div class="pull-right">
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm " ID="BtnAgregarDiagnostico" OnClick="BtnAgregarDiagnostico_Click" runat="server" AutoPostback="true">
                                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar Antecedente Judicial
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="BtnModificarDiagnostico"  Visible="false" runat="server" AutoPostback="true">
                                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Modificar Diagnóstico
                                            </asp:LinkButton>
                                            <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="BtnLimpiar" OnClick="BtnLimpiar_Click" runat="server" AutoPostback="true" CausesValidation="false">
                                                <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnGatilloCancelar" runat="server" CssClass="btn btn-primary btn-sm fixed-width-button pull-right" OnClientClick="return mostrarBotonAgregar()">
                                                <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar
                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div> 
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
</html>
