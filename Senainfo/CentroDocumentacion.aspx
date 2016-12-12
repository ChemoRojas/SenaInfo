<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CentroDocumentacion.aspx.cs" Inherits="CentroDocumentacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<html lang="es">

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="img/favicon.ico">
    <title>Centro de Documentación :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/jquery-ui.js"></script>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/theme.css" rel="stylesheet">
</head>

<body role="document">
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="SM001" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a id="A1" href="~/index.aspx" runat="server">Inicio</a></li>
                        <li class="active">Documentos</li>
                        <li class="active">Centro de Documentación</li>
                    </ol>

                    <div class="well">
                        <h4 class="subtitulo-form">Centro de Documentación</h4>
                        <hr>

                        <div class="row">
                            <div class="col-md-12">
                                <table class="table table-borderless table-condensed table-col-fix">
                                    <tr>
                                        <td>
                                            <ul>
                                                <li><strong>Avisos</strong></li>
                                                <ul>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/avisos/Calendario-2015-V02.pdf" target="_blank">Calendario-2015-V02</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/avisos/Memo Renovación Directorio.pdf" target="_blank">Memo Renovación Directorio</a></li>
                                                </ul>
                                                <li><strong>Instructivos</strong></li>
                                                <ul>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Causales de Ingreso 2015.pdf" target="_blank">Causales de Ingreso 2015</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Codificación de Delitos.pdf" target="_blank">Codificación de Delitos</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Instructivo Información Histórica.pdf" target="_blank">Instructivo Información Histórica</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Listado de Eventos Plan de Intervención.pdf" target="_blank">Listado de Eventos Plan de Intervención</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/NNA Explotación Infantil.pdf" target="_blank">NNA Explotación Infantil</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Registro Atención Mensual.pdf" target="_blank">Registro Atención Mensual</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Reportes Financiero.pdf" target="_blank">Reportes Financiero</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Reportes Histórico.pdf" target="_blank">Reportes Histórico</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/instructivos/Reportes Protección, Adpción.pdf" target="_blank">Reportes Protección, Adpción</a></li>
                                                </ul>
                                                <li><strong>Orientaciones</strong></li>
                                                <ul>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/orientaciones/Ingreso Niños PLA, PLE, SBC y MCA.pdf" target="_blank">Ingreso Niños PLA, PLE, SBC y MCA</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/orientaciones/Intervenciones sujetos a Subvención.pdf" target="_blank">Intervenciones sujetos a Subvención</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/orientaciones/Orientaciones Cuiadadoras FAS-FAE.pdf" target="_blank">Orientaciones Cuiadadoras FAS-FAE</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/orientaciones/Orientaciones Registro Información Módulo Niños.pdf" target="_blank">Orientaciones Registro Información Módulo Niños</a></li>
                                                </ul>
                                                <li><strong>Pago Subvenciones</strong></li>
                                                <ul>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago de Subvencion a Programas de Adopcion.pdf" target="_blank">Pago de Subvencion a Programas de Adopcion</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago de Subvencion OPD.pdf" target="_blank">Pago de Subvencion OPD</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion en Vacaciones.pdf" target="_blank">Pago Subvencion en Vacaciones</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion PIE.pdf" target="_blank">Pago Subvencion PIE</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion PIL.pdf" target="_blank">Pago Subvencion PIL</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion Programa de Reparacion del Abandono en Familia Alternativas.pdf" target="_blank">Pago Subvencion Programa de Reparacion del Abandono en Familia Alternativas</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion Programa Vida Nueva.pdf" target="_blank">Pago Subvencion Programa Vida Nueva</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion Programas de Familias de Acogida Simple.pdf" target="_blank">Pago Subvencion Programas de Familias de Acogida Simple</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion Programas de Intervencion Breve y Focalizada.pdf" target="_blank">Pago Subvencion Programas de Intervencion Breve y Focalizada</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/pago_subvenciones/Pago Subvencion RSP y PER.pdf" target="_blank">Pago Subvencion RSP y PER</a></li>
                                                </ul>
                                                <li><strong>Registro de Información</strong></li>
                                                <ul>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Instructivo CMN y Lineas de Atencion e Interaccion.pdf" target="_blank">Instructivo CMN y Lineas de Atencion e Interaccion</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Instructivo de Pago Programas PRF.pdf" target="_blank">Instructivo de Pago Programas PRF</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Instructivo Ingreso Medida o Sancion.pdf" target="_blank">Instructivo Ingreso Medida o Sancion</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Instructivo Programa Apoyo Psicosocial Reescolarizacion en CIP-CRC.pdf" target="_blank">Instructivo Programa Apoyo Psicosocial Reescolarizacion en CIP-CRC</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Orientacion Basica NNA en Senainfo Dependencia Tecnica.pdf" target="_blank">Orientacion Basica NNA en Senainfo Dependencia Tecnica</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Orientaciones Basicas en el Registro de los NNA.pdf" target="_blank">Orientaciones Basicas en el Registro de los NNA</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Registro Informacion LRPA.pdf" target="_blank">Registro Informacion LRPA</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Registro Informacion para Diagnosticos.pdf" target="_blank">Registro Informacion para Diagnosticos</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Registro Informacion PLA PLE SBC MCA.pdf" target="_blank">Registro Informacion PLA PLE SBC MCA</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Registro Informacion PSA.pdf" target="_blank">Registro Informacion PSA</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Registro Pago Subvencion a Programas Ambulatorios con Discapacidad.pdf" target="_blank">Registro Pago Subvencion a Programas Ambulatorios con Discapacidad</a></li>
                                                    <li><a href="https://cdn.senainfo.cl/pdf/cd/registro_informacion/Registro Pago Subvencion a Programas de Prevencion.pdf" target="_blank">Registro Pago Subvencion a Programas de Prevencion</a></li>
                                                </ul>
                                            </ul>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>


                </div>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
