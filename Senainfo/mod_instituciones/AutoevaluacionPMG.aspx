<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoevaluacionPMG.aspx.cs" Inherits="mod_instituciones_AutoevaluacionPMG" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="S" />
    <meta name="author" content="" />
    <link rel="icon" href="../images/favicon.ico" />
    <title>Titulo Formulario :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/jquery.validate.js"></script>
    <script src="../js/jquery.Rut.js"></script>
    <script src="../js/notify.js"></script>
    <script src="../js/moment.js"></script>
    <script src="../js/jquery.plugin.js"></script>
    <script src="../js/jquery.maxlength.js"></script>
    <script src="../js/fuelux.min.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/fuelux.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />


</head>
<body class="fuelux">
    <style>
        div {
            /*margin-bottom: 15px;*/
        }

        input[type="text"] {
            margin-bottom: 5px;
        }

        input[type="checkbox"] {
            width: 20px;
            height: 20px;
            margin-right: 5px;
        }

        .NroRespuesta {
            width: 20%;
        }
        .descripcion {
            color: #808080;
            font-size:12pt;
        }
        .titulopmg {
            color:black;
            font-size: 14pt;
        }
    </style>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManagerAutoEvaluacionPMG" EnableScriptGlobalization="true" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="container well">
            <div class="text-center">
                <img src="../images/minju.jpg" style="height: 200px; width: 200px;">
            </div>
            <div class="text-center">
                <h4><strong>Formulario de Autoevaluación</strong></h4>
                <h5>Linea de Acción de Protección de Derechos</h5>
            </div>
            <div class="wizard" data-initialize="wizard" id="myWizard">
                <div class="steps-container">
                    <ul class="steps">
                        <li data-step="1" data-name="campaign" class="active">
                            <span class="badge">1</span>DATOS GENERALES DEL PROYECTO 1/2
			                <span class="chevron"></span>
                        </li>
                        <li data-step="2">
                            <span class="badge">2</span>DATOS GENERALES DEL PROYECTO 2/2
			                <span class="chevron"></span>
                        </li>
                        <li data-step="3" data-name="template">
                            <span class="badge">3</span>SUJETO DE ATENCIÓN
			                <span class="chevron"></span>
                        </li>
                        <li data-step="4" data-name="template">
                            <span class="badge">4</span>DISEÑO DE INTERVENCIÓN 1/2
			                <span class="chevron"></span>
                        </li>
                        <li data-step="5" data-name="template">DISEÑO DE INTERVENCIÓN 2/2
                            <span class="badge">5</span>
                            <span class="chevron"></span>
                        </li>
                        <li data-step="6" data-name="template">
                            <span class="badge">6</span>INTEGRACIÓN DE VARIABLES TRANSVERSALES
			                <span class="chevron"></span>
                        </li>
                        <li data-step="7" data-name="template">
                            <span class="badge">7</span>RECURSOS HUMANOS
			                <span class="chevron"></span>
                        </li>
                        <li data-step="8" data-name="template">
                            <span class="badge">8</span>RECURSOS MATERIALES E INFRAESTRUCTURA
			                <span class="chevron"></span>
                        </li>
                        <li data-step="9" data-name="template">
                            <span class="badge">9</span>PROPUESTA PARA EL SIGUIENTE AÑO DE EJECUCIÓN
			                <span class="chevron"></span>
                        </li>
                    </ul>
                </div>
                <div class="actions">
                    <button type="button" class="btn btn-primary btn-prev">
                        <span class="glyphicon glyphicon-arrow-left"></span>Anterior</button>
                    <button type="button" class="btn btn-primary btn-next" data-last="Terminar">
                        Siguiente
		            <span class="glyphicon glyphicon-arrow-right"></span>
                    </button>
                </div>
                <div class="step-content">
                    <div class="step-pane active sample-pane alert" data-step="1">
                        <asp:Panel runat="server" ID="DatosGeneralesProyecto" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatePanelDatosGeneralesProyecto">
                                <ContentTemplate>

                                    <div class="row text-center titulopmg">
                                        <strong>DATOS GENERALES DEL PROYECTO</strong>
                                    </div>
                                    <br />
                                    <div class="row form-group">
                                        <label for="txtNombreProyecto" class="col-sm-3">Nombre del Proyecto</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtNombreProyecto" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtCodigo" class="col-sm-3">Código</label>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                                            <ajax:FilteredTextBoxExtender runat="server" ID="fteTxtCodigo" TargetControlID="txtCodigo" ValidChars="0123456789" />
                                        </div>
                                        <label for="ddlRegiones" class="col-sm-1">Región</label>
                                        <div class="col-md-5">
                                            <asp:DropDownList runat="server" ID="ddlRegiones" CssClass="form-control    ">
                                                <asp:ListItem Text="Seleccionar" />
                                                <asp:ListItem Text="Metropolitana" Value="1" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtColaboradorAcreditado" class="col-sm-3">Colaborador Acreditado</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtColaboradorAcreditado" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtCobertura" class="col-sm-3">Cobertura</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtCobertura" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtLineaAccion" class="col-sm-3">Linea de Acción</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtLineaAccion" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtModalidadAtencion" class="col-sm-3">Modalidad de Atención</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtModalidadAtencion" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtCoberturaTerritorial" class="col-sm-3">Cobertura Territorial</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtCoberturaTerritorial" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="email" class="col-sm-3">Periodo Evaluado</label>
                                        <div class="col-md-9">
                                            <div class="col-md-2">Desde</div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtPeriodoEvaluadoDesde" CssClass="form-control text-center" onkeypress="return false;" required></asp:TextBox>
                                                <ajax:CalendarExtender runat="server" ID="CEtxtPeriodoEvaluadoDesde" TargetControlID="txtPeriodoEvaluadoDesde" Animated="true" DefaultView="Days"  />
                                            </div>
                                            <div class="col-md-2">Hasta</div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtPeriodoEvaluadoHasta" CssClass="form-control text-center" onkeypress="return false;" required></asp:TextBox>
                                                <ajax:CalendarExtender runat="server" ID="CEtxtPeriodoEvaluadoHasta" TargetControlID="txtPeriodoEvaluadoHasta" Animated="true" DefaultView="Days" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtFechaPresentacionInforme" class="col-sm-3">Fecha de Presentacion de Informe</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtFechaPresentacionInforme" CssClass="form-control text-center" onkeypress="return false;" required></asp:TextBox>
                                            <ajax:CalendarExtender runat="server" ID="cetxtFechaPresentacionInforme" TargetControlID="txtFechaPresentacionInforme" DefaultView="Days" Animated="true" />
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtObjetivoGeneral" class="col-sm-3">Objetivo General</label>
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtObjetivoGeneral" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="2">
                        <asp:Panel runat="server" ID="DatosGeneralesProyecto2" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatePanelDatosGeneralesProyecto2">
                                <ContentTemplate>
                                    <div class="row text-center titulopmg">
                                        <strong>DATOS GENERALES DEL PROYECTO</strong>
                                    </div>
                                    <br />
                                    <div class="row form-group">
                                        <label for="txtRespuestaObjetivosEspecificos" class="titulo-form">Objetivos Especificos</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaObjetivosEspecificos" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestaObjetivosEspecificos" OnClick="btnAgregarRespuestaObjetivosEspecificos_Click">
                                        <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <br />
                                        <br />
                                        <asp:GridView runat="server" ID="grdRespuestasObjetivosEspecificos" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="N° Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta"></asp:BoundField>
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtRespuestaResultadosEsperados" class="titulo-form">Resultados Esperados</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaResultadosEsperados" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestaResultadosEsperados" OnClick="btnAgregarRespuestaResultadosEsperados_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasResultadosEsperados" CssClass="table table-condensed table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="N° Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtRespuestaMetaAñoQueCorresponda" class="titulo-form">Meta año que corresponda</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaMetaAñoQueCorresponda" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestaMetaAñoQueCorresponda" OnClick="btnAgregarRespuestaMetaAñoQueCorresponda_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasMetaAñoQueCorresponda" CssClass="table table-condensed table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="Nro Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtRespuestaIndicadorMeta" class="titulo-form">Indicador Meta</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaIndicadorMeta" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestaIndicadorMeta" OnClick="btnAgregarRespuestaIndicadorMeta_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasIndicadorMeta" CssClass="table table-condensed table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="Nro Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtRespuestaGradoCumplimiento" class="titulo-form">Grado de Cumplimiento</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaGradoCumplimiento" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestaGradoCumplimiento" OnClick="btnAgregarRespuestaGradoCumplimiento_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasGradoCumplimiento" CssClass="table table-condensed table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="Nro Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtRespuestaMediosVerificacion" class="titulo-form">Medios de Verificación</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaMediosVerificacion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestasMediosVerificacion" OnClick="btnAgregarRespuestasMediosVerificacion_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasMediosVerificacion" CssClass="table table-condensed table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="Nro Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <label for="txtRespuestaObservaciones" class="titulo-form">Observaciones</label>
                                        <asp:TextBox runat="server" ID="txtRespuestaObservaciones" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuestasObservaciones" OnClick="btnAgregarRespuestasObservaciones_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasObservaciones" CssClass="table table-condensed table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="Nro Respuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-6">
                                            <label for="txtRespuestaHitosAcciones" class="titulo-form">Hitos o principales acciones comprometidas, no realizadas en el periodo</label>
                                            <asp:TextBox runat="server" ID="txtRespuestaHitosAcciones" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtRespuestaObservacionesActividades" class="titulo-form">Observaciones sobre las actividades</label>
                                            <asp:TextBox runat="server" ID="txtRespuestaObservacionesActividades" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarRespuesta" OnClick="btnAgregarRespuesta_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Respuesta
                                            </asp:LinkButton>
                                        </div>
                                        <asp:GridView runat="server" ID="grdRespuestasHitosAcciones" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" ItemStyle-CssClass="NroRespuesta" HeaderStyle-CssClass="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                <asp:BoundField DataField="Respuesta2" HeaderText="Respuesta2" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="3">
                        <asp:Panel runat="server" ID="SujetoAtencion" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelSujetoAtencion">
                                <ContentTemplate>
                                    <div class="row text-center titulopmg">
                                        <strong>SUJETO DE ATENCIÓN</strong>
                                        <p class="descripcion">Mencione, conforme al cuadro que se presenta a continuación, las principales causales de ingreso en su proyecto del año de ejecución</p>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-3">
                                            <label for="" class="titulo-form">Causales de Ingreso</label>
                                        </div>
                                        <div class="col-md-6"></div>
                                        <div class="col-md-3">
                                            <label for="" class="titulo-form">Porcentaje</label>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-9">
                                            <asp:TextBox runat="server" ID="txtCausalIngreso" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox runat="server" ID="txtPorcentajeCausalIngreso" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarCausalIngreso" CssClass="btn btn-info" OnClick="btnAgregarCausalIngreso_Click">
                                    <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Causal    
                                                </asp:LinkButton>
                                            </div>
                                            <br />
                                            <br />
                                        </div>

                                        <asp:GridView runat="server" ID="grdCausalIngreso" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="N° Respuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Causal de Ingreso" />
                                                <asp:BoundField DataField="Respuesta2" HeaderText="Porcentaje" />
                                            </Columns>
                                            <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                            <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                            <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                            <RowStyle CssClass="caja-tabla table-bordered" />
                                        </asp:GridView>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-6">
                                            <label for="txtViasIngreso" class="titulo-form">Vías de Ingreso</label><span class="descripcion"> (Enumere las tres principales fuentes derivadoras)</span>
                                        </div>
                                        <div class="col-md-6"></div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtViasIngreso" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnAgregarViasIngreso" OnClick="btnAgregarViasIngreso_Click">
                            <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Vias de Ingreso
                                                </asp:LinkButton>
                                            </div>
                                            <br />
                                            <br />
                                            <asp:GridView runat="server" ID="grdViasIngreso" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="N° Respuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-6">
                                            <label for="" class="titulo-form">Cobertura y Lista de Espera</label>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-offset 3 col-md-9">
                                            <p>Adjunte cuadro con resumen mensual (solo n°) de Lista de Espera y capacidad  de absorción de la misma en los meses posteriores</p>
                                            <asp:FileUpload runat="server" ID="Archivo1" />
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-offset 3 col-md-9">
                                            <p>
                                                N° de NNA egresados durante el año (dividido por mes) dentro del plazo versus N° de NNA que superaron el tiempo de permanencia indicado por
                            las OOTT para la modalidad
                                            </p>
                                            <asp:FileUpload runat="server" ID="FileUpload1" />
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-offset 3 col-md-9">
                                            <p>
                                                Mayores de 18 años (Nómina actualizada y fecha de egreso comprometida)
                                            </p>
                                            <asp:FileUpload runat="server" ID="FileUpload2" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="4">
                        <asp:Panel runat="server" ID="DiseñoIntervencion" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelDiseñoIntervencion">
                                <ContentTemplate>


                                    <div class="row text-center titulopmg">
                                        <strong>DISEÑO DE INTERVENCIÓN</strong>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label for="" class="titulo-form">Describa</label>
                                            <p>
                                                La Metodología que implementa su proyecto señalando las intervenciones que realiza
                        con los niños, niñas y adolescentes, sus familias y redes comunitarias.
                        Profundice en el componente principal de la itnervencion señalando las principales estrategias utilizadas.
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcionMetodologia"></asp:TextBox>
                                            <asp:FileUpload runat="server" ID="archivoMetodologia" />
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-5">
                                            <label for="" class="titulo-form">Enfoques transversales de trabajo</label>
                                            <p>(Indique los 4 más relevante que Ud. utiliza)</p>
                                        </div>
                                        <div class="col-md-7">
                                            <label for="" class="titulo-form">En qué acciones, técnicas y estrategias ha traducido/operacionalizado estos enfoques</label>
                                            <p>(mencione uan acción o técnica, por cada enfoque seleccionado)</p>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <asp:TextBox runat="server" ID="txtEnfoquesTransversalesTrabajo" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="txtAccionesTecnicasEstrategias" CssClass="form-control"></asp:TextBox>
                                                <div class="pull-right">
                                                    <asp:LinkButton runat="server" ID="btnAgregarAccionesTecnicasEstrategias" CssClass="btn btn-info" OnClick="btnAgregarAccionesTecnicasEstrategias_Click">
                                        <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                    </asp:LinkButton>
                                                </div>

                                            </div>
                                            <br />
                                            <br />
                                            <div class="row form-group">
                                                <asp:GridView runat="server" ID="grdAccionesTecnicasEstrategias" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="NroRespuesta" HeaderText="N° Respuesta" />
                                                        <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                        <asp:BoundField DataField="Respuesta2" HeaderText="Respuesta2" />
                                                    </Columns>
                                                    <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                    <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                    <RowStyle CssClass="caja-tabla table-bordered" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-4">
                                            <label for="" class="titulo-form">Cuenta con instrumentos propios en el marco de los enfoques planteados</label>
                                        </div>
                                        <div class="col-md-offset-2 col-md-4">
                                            <label for="" class="titulo-form">Cuáles(nómbrelos)</label>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtCuentaconInstrumentosPropios"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Si" Value="1" />
                                                <asp:ListItem Text="No" Value="0" />
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox runat="server" ID="txtCualesInstrumentos" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="5">
                        <asp:Panel runat="server" ID="DiseñoIntervencion2" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelDiseñoIntervencion2">
                                <ContentTemplate>
                                    <div class="row text-center">
                                        <strong>DISEÑO DE INTERVENCIÓN</strong>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label for="" class="titulo-form">Flujo de Atención</label>
                                            <p>
                                                Elabore un diagrama con el flujo de atencion, que actualmente se lleva a cabo en su proyecto,
                            desde que ingresa un niño/a y su familia, hasta que egresa. Es posible repetir el flujo presentado en formularios
                            anteriores, integrando aspectos nuevos si corresponde.
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtFlujoAtencion"></asp:TextBox>
                                            <asp:FileUpload runat="server" ID="FileUpload3" />
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label for="" class="titulo-form">Intervención con los niños, niñas y adolescentes</label>
                                            <p>
                                                En relación a la participación de los niños, niñas y adolescentes:
                                            </p>
                                            <p>
                                                Señale concretamente cómo se incorpora la participación y la consideración de la opinión de los niños,
                            niñas y adolescentes en el diseño, ejecución y evaluacioón de sus planes de intervención (especifique si es que tiene tpecnicas diferencias por grupo etario)
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtIntervencionConNNA"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarIntervencionConNNA" CssClass="btn btn-info" OnClick="btnAgregarIntervencionConNNA_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar Intervención
                                                </asp:LinkButton>
                                            </div>
                                            <asp:GridView runat="server" ID="grdIntervencionConNNA" CssClass="table table-condensed table-hover">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="N° Respuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label for="" class="titulo-form">Vinculación con las Redes Comunitarias</label>
                                            <p>
                                                Mencione los actores y procedimientos de derivación efecutados durante el año intra y extra Sename,
                            en acuerdo a las caracteristicas de su sujeto de atención.
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtVinculacionRedesComunitarias" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload runat="server" ID="archivox" />
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <p>
                                                Describa las estrategias del trabajo de colaboración que realizó el proyecto durante el año.
                            En caso de responder afirmativamente, adjunte un acta u otro instrumento que valide su respuesta.
                                            </p>
                                            <asp:TextBox runat="server" ID="txtDescripcionEstrategiasDelTrabajo" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload runat="server" ID="archivoxy" />
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <p>
                                                Describa sus estrategias de coordinacion efectiva con Tribunales de Familia. En caso de responder afirmativamente.
                            adjunte un acta u otro instrumento que valide su respuesta.
                                            </p>
                                            <asp:TextBox runat="server" ID="txtDescribaEstrategiasCoordinacion" CssClass="form-control"></asp:TextBox>
                                            <asp:FileUpload runat="server" ID="FileUpload4" />
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="6">
                        <asp:Panel runat="server" ID="IntegracionVariablesTransversales" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelIntegracionVariablesTransversales">
                                <ContentTemplate>


                                    <div class="row text-center">
                                        <strong>INTEGRACIÓN DE VARIABLES TRANSVERSALES</strong>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <label for="" class="titulo-form">
                                                Plan de Coordinación con garantes y/o articulación territorial, autoevaluación, capacitación y autocuidado de equipo
                                            </label>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row form-group">
                                        <div class="col-md-4 text-center">
                                            <label class="titulo-form ">
                                                Hitos o principales acciones del año correspondiente
                                            </label>
                                            <p>
                                                (anotar lo comprometido en el proyecto aprobado prorrogado o licitado).
                                            </p>
                                            <p>
                                                Agregar las filas que se requieran.
                                            </p>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="titulo-form text-center">
                                                Seleccione, deacuerdo a si la actividad se realizó o no
                                            </label>
                                        </div>
                                        <div class="col-md-4">
                                            <label class="titulo-form text-center">
                                                Hitos o prinicipales acciones del año correspondiente
                                            </label>
                                        </div>
                                    </div>

                                    <label for="" class="control-label">
                                        Plan de Coordinación con garantes y/o articulación territorial
                                    </label>
                                    <div class="row form-group">
                                        <div class="col-md-4 text-center">
                                            <asp:TextBox runat="server" ID="txtHitosAccionesPlanCoordinacion" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="col-md-offset-4 col-md-8">
                                                <asp:RadioButtonList runat="server" ID="rblHitosAccionesPlanCoordinacion" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Si" Value="1" />
                                                    <asp:ListItem Text="No" Value="0" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtObservacionesHitosAccionesPlanCoordinacion" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarRespuestaHitosAccionesPlanCoordinacion" CssClass="btn btn-info" OnClick="btnAgregarRespuestaHitosAccionesPlanCoordinacion_Click">
                                          <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                            <br />
                                            <br />
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdHitosAccionesPlanCoordinacion" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                    <asp:BoundField DataField="RespuestaBool" HeaderText="RespuestaBool" />
                                                    <asp:BoundField DataField="Respuesta2" HeaderText="Respuesta2" />
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <label for="" class="control-label">
                                        Autoevaluación
                                    </label>
                                    <div class="row form-group">
                                        <div class="col-md-4 text-center">
                                            <asp:TextBox runat="server" ID="txtHitosAccionesAutoevaluacion" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="col-md-offset-4 col-md-8">
                                                <asp:RadioButtonList runat="server" ID="rdblHitosAccionesAutoevaluacion" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Si" Value="1" />
                                                    <asp:ListItem Text="No" Value="0" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtObservacionesHitosAccionesAutoevaluacion" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarRespuestaHitosAccionesAutoevaluacion" CssClass="btn btn-info" OnClick="btnAgregarRespuestaHitosAccionesAutoevaluacion_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                            <br />
                                            <br />
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdHitosAccionesAutoevaluacion" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                    <asp:BoundField DataField="RespuestaBool" HeaderText="RespuestaBool" />
                                                    <asp:BoundField DataField="Respuesta2" HeaderText="Respuesta2" />
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <label for="" class="control-label">
                                        Capacitación
                                    </label>
                                    <div class="row form-group">
                                        <div class="col-md-4 text-center">
                                            <asp:TextBox runat="server" ID="txtHitosAccionesCapacitacion" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="col-md-offset-4 col-md-8">
                                                <asp:RadioButtonList runat="server" ID="rdblHitosAccionesCapacitacion" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Si" Value="1" />
                                                    <asp:ListItem Text="No" Value="0" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtObservacionesHitosAccionesCapacitacion" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarHitosAccionesCapacitacion" CssClass="btn btn-info" OnClick="btnAgregarHitosAccionesCapacitacion_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                            <br />
                                            <br />
                                        </div>
                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdHitosAccionesCapacitacion" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                    <asp:BoundField DataField="RespuestaBool" HeaderText="RespuestaBool" />
                                                    <asp:BoundField DataField="Respuesta2" HeaderText="Respuesta2" />
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <label for="" class="control-label">
                                        Auto cuidado de equipo
                                    </label>
                                    <div class="row form-group">
                                        <div class="col-md-4 text-center">
                                            <asp:TextBox runat="server" ID="txtHitosAccionesAutoCuidado" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="col-md-offset-4 col-md-8">
                                                <asp:RadioButtonList runat="server" ID="rdblHitosAccionesAutoCuidado" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Si" Value="1" />
                                                    <asp:ListItem Text="No" Value="0" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox runat="server" ID="txtObservacionesHitosAccionesAutoCuidado" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarHitosAccionesAutocuidado" CssClass="btn btn-info" OnClick="btnAgregarHitosAccionesAutocuidado_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                            <br />
                                            <br />
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdHitosAccionesAutoCuidado" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                    <asp:BoundField DataField="RespuestaBool" HeaderText="RespuestaBool" />
                                                    <asp:BoundField DataField="Respuesta2" HeaderText="Respuesta2" />
                                                </Columns>
                                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                                <RowStyle CssClass="caja-tabla table-bordered" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="7">
                        <asp:Panel runat="server" ID="RecursosHumanos" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelRecursosHumanos">
                                <ContentTemplate>


                                    <div class="row text-center">
                                        <strong>RECURSOS HUMANOS</strong>
                                    </div>
                                    <label for="" class="titulo-form">EQUIPO TÉCNICO</label>

                                    <div class="row form-group">
                                        <div class="col-md-2">
                                            <br />
                                            <strong>DOTACIÓN</strong>
                                        </div>
                                        <div class="col-md-5">
                                            <p>
                                                <label for="" class="titulo-form">
                                                    Permanece igual a la comprometida
                                                </label>
                                            </p>
                                            <asp:RadioButtonList runat="server" ID="rdblDotacionRecursosHumanos" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Si" Value="1" />
                                                <asp:ListItem Text="No" Value="0" />
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-5">
                                            <p>
                                                <label for="" class="titulo-form">
                                                    Justifique si su respuesta es NO e indique como ha incidido
                            en el cumplimiento de objetivos del proyecto
                                                </label>
                                            </p>
                                            <asp:TextBox runat="server" ID="txtJustificaciónRespuestaDotación" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-2">
                                            <br />
                                            <strong>JORNADA</strong>
                                        </div>
                                        <div class="col-md-5">
                                            <p>
                                                <label for="" class="titulo-form">
                                                    Horas profesionales igual a la comprometida
                                                </label>
                                            </p>
                                            <asp:RadioButtonList ID="rdblJornada" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Si" Value="1" />
                                                <asp:ListItem Text="No" Value="0" />
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-5">
                                            <p>
                                                <label for="" class="titulo-form">
                                                    Justifique si su respuesta es NO e indique como ha incidido
                            en el cumplimiento de objetivos del proyecto
                                                </label>
                                            </p>
                                            <asp:TextBox runat="server" ID="txtJustificacionRespuestaJornada" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row form-group">
                                        <div class="col-md-2">
                                            <br />
                                            <strong>ROTACIÓN</strong>
                                        </div>
                                        <div class="col-md-5">
                                            <%--<p>
                            <label for="" class="titulo-form">
                                Permanece igual a la comprometida
                            </label>
                        </p>--%>
                                            <asp:RadioButtonList ID="rdblRotacion" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Si" Value="1" />
                                                <asp:ListItem Text="No" Value="0" />
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-5">
                                            <p>
                                                <label for="" class="titulo-form">
                                                    Justifique si su respuesta es NO e indique como ha incidido
                            en el cumplimiento de objetivos del proyecto
                                                </label>
                                            </p>
                                            <asp:TextBox runat="server" ID="txtJustificacionRespuestaRotacion" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <label for="" class="titulo-form">Describa</label>
                                        <p>
                                            ORGANIZACIÓN DEL EQUIPO y distribución de funciones, carga de trabajo, complementariedad, etc.
                                        </p>
                                        <asp:TextBox runat="server" ID="txtDescribaRecursosHumanos" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="row form-group">
                                        <label for="" class="titulo-form">OBSERVACIONES</label>
                                        <p>
                                            mencione, si estima pertinente, observaciones, obstaculos u otros aspectos referidos al recurso humano.
                                        </p>
                                        <asp:TextBox runat="server" ID="txtObservacionesRecursosHumanos" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="8">
                        <asp:Panel runat="server" ID="RecursosMaterialesInfraestructura" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelRecursosMaterialesInfraestructura">
                                <ContentTemplate>


                                    <div class="row text-center titulopmg">
                                        <strong>RECURSOS MATERIALES E INFRAESTRUCTURA</strong>
                                    </div>
                                    <label for="" class="titulo-form">Recursos materiales e infraestructura</label>
                                    <p class="descripcion">
                                        (marque con una cruz, si los recursos materiales y la infraestructura, son superiores, inferiores o iguales, a los propuestos 
                    en el proyecto de funcionamiento, y describa como ha incidido esto en el funcionamiento del proyecto
                     y el cumplimiento de objetivos)
                                    </p>
                                    <br />
                                    <label for="" class="titulo-form">Recursos Materiales</label>
                                    <hr />

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <label class="titulo-form">Descripción</label>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="titulo-form">Justificación y Análisis</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-2">
                                                    <asp:CheckBox runat="server" ID="chkSuperiorRM" />
                                                </div>
                                                <div class="col-md-10">
                                                    <span>Superior al propuesto en el proyecto de funcionamiento </span>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtJustificacionSuperiorRM" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-2">
                                                    <asp:CheckBox runat="server" ID="chkInferiorRM" />
                                                </div>
                                                <div class="col-md-10">
                                                    <span>Inferior al propuesto en el proyecto de funcionamiento</span>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtJustificacionInferiorRM" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-2">
                                                    <asp:CheckBox runat="server" ID="chkIgualRM" />
                                                </div>
                                                <div class="col-md-10">
                                                    <span>Igual al propuesto en el proyecto de funcionamiento</span>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtJustificacionigualRM" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <label for="" class="titulo-form">Infraestructura</label>
                                    <hr />

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <label class="titulo-form">Descripción</label>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="titulo-form">Justificación y Análisis</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-2">
                                                    <asp:CheckBox runat="server" ID="chkSuperiorI" />
                                                </div>
                                                <div class="col-md-10">
                                                    <span>Superior al propuesto en el proyecto de funcionamiento </span>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtJustificacionSuperiorI" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-2">
                                                    <asp:CheckBox runat="server" ID="chkInferiorI" />
                                                </div>
                                                <div class="col-md-10">
                                                    <span>Inferior al propuesto en el proyecto de funcionamiento</span>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtJustificacionInferiorI" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="col-md-2">
                                                    <asp:CheckBox runat="server" ID="chkIgualI" />
                                                </div>
                                                <div class="col-md-10">
                                                    <span>Igual al propuesto en el proyecto de funcionamiento</span>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox runat="server" ID="txtJustificacionIgualI" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label class="titulo-form">OBSERVACIONES</label>
                                            <p>
                                                mencione, si estima pertinente, observaciones obstáculos u otros aspectos referidos a los recursos materiales y de infraestructura.
                                            </p>
                                            <asp:TextBox runat="server" ID="txtObservacionesRMI" CssClass="form-control" TextMode="MultiLine" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="step-pane sample-pane alert" data-step="9">
                        <asp:Panel runat="server" ID="PropuestaParaSiguienteAño" Visible="true">
                            <asp:UpdatePanel runat="server" ID="updatepanelPropuestaParaSiguienteAño">
                                <ContentTemplate>


                                    <div class="row text-center">
                                        <strong>PROPUESTA PARA EL SIGUIENTE AÑO DE EJECUCIÓN</strong>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label class="titulo-form">Plan de Trabajo para el siguiente año</label>
                                            <p>
                                                En este apartado, el equipo tiene que presentar su planificacion para el año de ejecución siguiente. Puede copiar la matriz presentada en el proyecto
                        aprobado (sea prorrogado o licitado), o bien, puede modificarla considerando los aprendizajes, logros alcanzados, dificultades y observaciones realizadas
                        por los supervisores/as técnicos. Recuerdo que tiene que mantener el objetivo general, los objetivos especificos, resultados esperados para la modalidad, 
                        los indicadores, medios de verificación, el equipo puede proponer nuevas acciones.
                                            </p>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label class="titulo-form">
                                                Propuesta Para año
                            <asp:Label runat="server" ID="AñoSiguiente"></asp:Label>
                                            </label>
                                            <hr />
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            Objevitos Específicos
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtObjetivosEspecificosProximoAño" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarObjetivosEspecificosProximoAño" CssClass="btn btn-info" OnClick="btnAgregarObjetivosEspecificosProximoAño_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdObjetivosEspecificosProximoAño" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            Resultados Esperados
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtResultadosEsperadosProximoAño" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarResultadosEsperadosProximoAño" CssClass="btn btn-info" OnClick="btnAgregarResultadosEsperadosProximoAño_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdResultadosEsperadosProximoAño" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            Meta
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtMetaProximoAño" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarMetaProximoAño" CssClass="btn btn-info" OnClick="btnAgregarMetaProximoAño_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdMetaProximoAño" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            Indicador Meta
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtIndicadorMetaProximoAño" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarIndicadorMetaProximoAño" CssClass="btn btn-info" OnClick="btnAgregarIndicadorMetaProximoAño_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdIndicadorMetaProximoAño" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            Medios de Verificación
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" ID="txtMediosVerificacionProximoAño" CssClass="form-control"></asp:TextBox>
                                            <div class="pull-right">
                                                <asp:LinkButton runat="server" ID="btnAgregarMediosVerificacionProximoAño" CssClass="btn btn-info" OnClick="btnAgregarMediosVerificacionProximoAño_Click">
                                           <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                                </asp:LinkButton>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <asp:GridView runat="server" ID="grdMediosVerificacionProximoAño" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-6">
                                            <label for="" class="titulo-form">
                                                Hitos o principales acciones del año
                                            </label>

                                        </div>
                                        <div class="col-md-6">
                                            <label for="" class="titulo-form">
                                                Meses del año
                                            </label>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <p>
                                                    (debe señalar solo las acciones principales para lograr los objetivos propuestos, máximo seis actividades esenciales).
                                                </p>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="col-xs-1">1</div>
                                                <div class="col-xs-1">2</div>
                                                <div class="col-xs-1">3</div>
                                                <div class="col-xs-1">4</div>
                                                <div class="col-xs-1">5</div>
                                                <div class="col-xs-1">6</div>
                                                <div class="col-xs-1">7</div>
                                                <div class="col-xs-1">8</div>
                                                <div class="col-xs-1">9</div>
                                                <div class="col-xs-1">10</div>
                                                <div class="col-xs-1">11</div>
                                                <div class="col-xs-1">12</div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="HitosAccionesProximoAño" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:CheckBoxList ID="chklistMeses" runat="server" RepeatDirection="Horizontal" Width="100%" Style="margin-left: 3%;">
                                                    <asp:ListItem Value="1" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="2" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="3" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="4" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="5" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="6" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="7" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="8" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="9" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="10" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="11" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="12" Text=""></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" ID="btnAgregarHitosAccionesProximoAño" CssClass="btn btn-info" OnClick="btnAgregarHitosAccionesProximoAño_Click">
                                <span class="glyphicon glyphicon-plus-sign"></span>&nbsp; Agregar
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:GridView runat="server" ID="grdHitosAccionesProximoAño" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="NroRespuesta" HeaderText="NroRespuesta" />
                                                <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                                <asp:BoundField DataField="Meses" HeaderText="Meses" />
                                                <%-- <asp:BoundField DataField="mes1" HeaderText="mes1" />
                                        <asp:BoundField DataField="mes2" HeaderText="mes2" />
                                        <asp:BoundField DataField="mes3" HeaderText="mes3" />
                                        <asp:BoundField DataField="mes4" HeaderText="mes4" />
                                        <asp:BoundField DataField="mes5" HeaderText="mes5" />
                                        <asp:BoundField DataField="mes6" HeaderText="mes6" />
                                        <asp:BoundField DataField="mes7" HeaderText="mes7" />
                                        <asp:BoundField DataField="mes8" HeaderText="mes8" />
                                        <asp:BoundField DataField="mes9" HeaderText="mes9" />
                                        <asp:BoundField DataField="mes10" HeaderText="mes10" />
                                        <asp:BoundField DataField="mes11" HeaderText="mes11" />
                                        <asp:BoundField DataField="mes12" HeaderText="mes12" />--%>
                                            </Columns>
                                        </asp:GridView>
                                    </div>


                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <label for="" class="titulo-form">
                                                Metodología para el siguiente año de ejecución
                            <asp:Label runat="server" ID="ProximoAño"></asp:Label></label>
                                            <p>
                                                El equipo puede consignar el mismo modelo de intervención que ha venido implementando y que ya señaló,
                            si es que éste le permitio alcanzar los resultados y metas.
                            De lo contrario tendrá que realizar los ajustes necesarios, o bien, si el equipo lo estima puede incorporar modificaiones para optimizar resultados.
                            Es importante que considere las observaciones realizadas en el marco de la supervisión técnica.
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtMetodologiaProximoAño"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </div>
            </div>


            <br />

            <div class="row form-group">
                <div class="col-md-12 text-right">
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="btnGuardar" CssClass="btn btn-danger" OnClick="btnGuardar_Click">
                                <span class="glyphicon glyphicon-save"></span>&nbsp; Guardar
                        </asp:LinkButton>
                        <%--<asp:Button Text="Guardar" ID="btnGuardarInvisible" runat="server" />--%>
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            $("#txtObjetivoGeneral").maxlength({ max:250 })
        </script>

    </form>
    
</body>
</html>
