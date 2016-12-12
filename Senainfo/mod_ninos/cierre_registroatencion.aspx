<%@ Page Language="C#" Culture="es-CL" UICulture="es" AutoEventWireup="true" CodeFile="~/mod_ninos/cierre_registroatencion.aspx.cs" EnableEventValidation="false" ValidateRequest="false" EnableSessionState="True" EnableViewState="true" Inherits="mod_institucion_cierre_registroatencion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Import Namespace="System.IO" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>

<!DOCTYPE html>
<html lang="es">
<head id="Head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="../images/favicon.ico" />
    
    <title>Registro de Atención :: Senainfo :: Servicio Nacional de Menores</title>

    <script src="../js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>
    <script src="../js/jquery.blockUI.js"></script>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../css/theme.css" rel="stylesheet" />
    
    <style>

        .table-hover > tbody > td:hover {
            background-color: #9dd4fb;
}

    </style>
  <%--  <style>

    .mira table {
    overflow: hidden;
    z-index: 1;
    position: relative;
}

    .mira td,.mira th,.mira .row,.mira .col,.mira .ff-fix {
    
    position: relative;
}
    /*.mira td:hover::before,
    .mira .row:hover::before,
    .mira .ff-fix:hover::before { 
    background-color: #9dd4fb;
    content: '\00a0';  
    height: 100%;
    left: -5000px;
    position: absolute;  
    top: 0;
    width: 100%;
    z-index: -1;   
}*/
    .mira td:hover::after,
    .mira .col:hover::after,
    .mira .ff-fix:hover::after { 
    background-color: #9dd4fb;
    content: '\00a0';  
    height: 10000px;
    left: 0;
    position: absolute;  
    top: -5000px;
    width: 100%;
    z-index: -1;        
}

    </style>--%>

    
    <script type="text/javascript">

       

        var headerHeight = 0;
        $(document).ready(function () {

            $("#c1").click(function () {
                $("#c1").text("A");
            });
            
        });

        $(document).ready(function () {

            $("#c2").click(function () {
                $("#c2").text("B");
            });
        });

        $(document).ready(function () {

            $("#c3").click(function () {
                $("#c3").text("C");
            });
        });

        //$(document).ready(function () {
        //    $("#collapse").click(function () {
        //        $(window).triggerHandler("scroll");
        //    });
        //});


        
        $(document).ready(function () {

            $('#collapse').click(function () {                
                var interval = window.setInterval(function () {
                    $('#NuevaGrilla').floatThead('reflow');
                }, 10);

                $('#collapse_Form').on('transitionend webkitTransitionEnd oTransitionEnd', function () {
                    window.clearInterval(interval);
                    $('#NuevaGrilla').floatThead('reflow');
                });
            });

            $('#btnGuardaAsistencia,#btnGuardaAsistenciaSinConfirmar').click(function () {
                $.blockUI({
                    message: 'Espere mientras se guarda la asistencia, por favor no cerrar esta ventana.',
                    css: {
                        border: 'none',
                        padding: '15px',
                        backgroundColor: '#000',
                        '-webkit-border-radius': '10px',
                        '-moz-border-radius': '10px',
                        opacity: 2,
                        color: '#FFFFFF',                                         
                    }
                });

                //$.blockUI.defaults.message = '<img alt="Cargando" src="../images/Cursors/ajax-loader.gif" /></br> Espere mientras se guarda la asistencia, no cerrar la ventana.';
                //$.blockUI();

                $('#NuevaGrilla').floatThead('destroy');

                //setTimeout($.unblockUI, 4000);
            });

            // exportar a excel
            $("#Imb007").click(function () {

                var $NuevaGrilla = $('#NuevaGrilla');
                $NuevaGrilla.floatThead('destroy');


                var NuevaGrillaExport = $("#NuevaGrilla").clone();
                //gfontbrevis Quitar primera fila
                NuevaGrillaExport.find('tr:first').remove();
                //gfontbrevis Quitar penultima columna
                NuevaGrillaExport.find('td:nth-last-child(2)').remove();
                NuevaGrillaExport.find('th:nth-last-child(2)').remove();
                NuevaGrillaExport.find('td').css('width', 'auto');

                NuevaGrillaExport.find('th').removeAttr('align');
                NuevaGrillaExport.find('td').removeAttr('style');
                NuevaGrillaExport.find('tr').removeAttr('style');
                NuevaGrillaExport.removeAttr('style');
                NuevaGrillaExport.removeAttr('GridLines');
                NuevaGrillaExport.removeAttr('BorderStyle');
                NuevaGrillaExport.removeAttr('border');

                var grillitaHTML = NuevaGrillaExport.prop('outerHTML');

                var newValue = grillitaHTML.replace('<tbody>', '');
                newValue = newValue.replace('</tbody>', '');
                grillitaHTML = newValue;
                $('input[name="GrillaHTML"]').val(grillitaHTML); //limpiar campo hidden      

                fixHeader_(NuevaGrilla);

            });
        });

        function nuevaGrillaClick() {
            $("#NuevaGrilla").click(function () {
                guardagrilla(); // CET se separa a otra funcion para llamarla de forma independiente
            });            
        }

        function GuardaAsistencia(ConfirmaAsistencia)
        {
            guardagrilla();

            if (ConfirmaAsistencia == 1) {

                $('#ConfirmaAsistencia').val('1');
                var btnGuardaAsistencia = document.getElementById('btnGuardaAsistencia');
                btnGuardaAsistencia.click();
            }

            if (ConfirmaAsistencia == 0) {
                var btnGuardaAsistenciaSinConfirmar = document.getElementById('btnGuardaAsistenciaSinConfirmar');
                btnGuardaAsistenciaSinConfirmar.click();
            }
            
        }
        
        
        function guardagrilla() {
                $('input[name="CampoDatosAsistencia"]').val('VACIO'); //limpiar campo hidden
                var linea_tmp;
                linea_tmp = "";
                var numb_linea = 1;
                var TotalNumLineas = $('#NuevaGrilla >tbody >tr').length;
                if (TotalNumLineas >= 1) //---> ya no existen las cabeceras porque se cambiaron al thead
                {
                    TotalNumLineas = TotalNumLineas - 2; //-2 por las lineas pie de grilla resumenes
                    $('#NuevaGrilla >tbody >tr').each(function () {     // recorre solo los tr existentes en el tbody                   
                        
                        //ya no existe encabezado en el tbody cambiado por CET 15/02/2016
                        if (numb_linea <= TotalNumLineas) {  
                            var ap_pat = $(this).find("td").eq(0).html();
                            var ap_mat = $(this).find("td").eq(1).html();
                            var nombre = $(this).find("td").eq(2).html();
                            var ICodIE = $(this).find("td").eq(3).html();
                            var codnino = $(this).find("td").eq(4).html();
                            var sexo = $(this).find("td").eq(5).html();
                            var cod_diasat = $(this).find("td").eq(6).html();
                            //DIAS 1-31
                            var d1 = $(this).find("td").eq(7).html();
                            var d2 = $(this).find("td").eq(8).html();
                            var d3 = $(this).find("td").eq(9).html();
                            var d4 = $(this).find("td").eq(10).html();
                            var d5 = $(this).find("td").eq(11).html();
                            var d6 = $(this).find("td").eq(12).html();
                            var d7 = $(this).find("td").eq(13).html();
                            var d8 = $(this).find("td").eq(14).html();
                            var d9 = $(this).find("td").eq(15).html();
                            var d10 = $(this).find("td").eq(16).html();
                            var d11 = $(this).find("td").eq(17).html();
                            var d12 = $(this).find("td").eq(18).html();
                            var d13 = $(this).find("td").eq(19).html();
                            var d14 = $(this).find("td").eq(20).html();
                            var d15 = $(this).find("td").eq(21).html();
                            var d16 = $(this).find("td").eq(22).html();
                            var d17 = $(this).find("td").eq(23).html();
                            var d18 = $(this).find("td").eq(24).html();
                            var d19 = $(this).find("td").eq(25).html();
                            var d20 = $(this).find("td").eq(26).html();
                            var d21 = $(this).find("td").eq(27).html();
                            var d22 = $(this).find("td").eq(28).html();
                            var d23 = $(this).find("td").eq(29).html();
                            var d24 = $(this).find("td").eq(30).html();
                            var d25 = $(this).find("td").eq(31).html();
                            var d26 = $(this).find("td").eq(32).html();
                            var d27 = $(this).find("td").eq(33).html();
                            var d28 = $(this).find("td").eq(34).html();
                            var d29 = $(this).find("td").eq(35).html();
                            var d30 = $(this).find("td").eq(36).html();
                            var d31 = $(this).find("td").eq(37).html();

                            var dias_at = $(this).find("td").eq(38).html();
                            if ((numb_linea) == TotalNumLineas)  //si llego a la ultima linea // cambiado por CET 17/11/2015
                            {
                                linea_tmp = linea_tmp + ap_pat + ";" + ap_mat + ";" + nombre + ";" + ICodIE + ";" + codnino + ";" + sexo + ";" + cod_diasat + ";" + d1 + ";" + d2 + ";" + d3 + ";" + d4 + ";" + d5 + ";" + d6 + ";" + d7 + ";" + d8 + ";" + d9 + ";" + d10 + ";" + d11 + ";" + d12 + ";" + d13 + ";" + d14 + ";" + d15 + ";" + d16 + ";" + d17 + ";" + d18 + ";" + d19 + ";" + d20 + ";" + d21 + ";" + d22 + ";" + d23 + ";" + d24 + ";" + d25 + ";" + d26 + ";" + d27 + ";" + d28 + ";" + d29 + ";" + d30 + ";" + d31 + ";" + dias_at; //agregando fin de linea | y Fin de Campo ;
                            }
                            else {
                                linea_tmp = linea_tmp + ap_pat + ";" + ap_mat + ";" + nombre + ";" + ICodIE + ";" + codnino + ";" + sexo + ";" + cod_diasat + ";" + d1 + ";" + d2 + ";" + d3 + ";" + d4 + ";" + d5 + ";" + d6 + ";" + d7 + ";" + d8 + ";" + d9 + ";" + d10 + ";" + d11 + ";" + d12 + ";" + d13 + ";" + d14 + ";" + d15 + ";" + d16 + ";" + d17 + ";" + d18 + ";" + d19 + ";" + d20 + ";" + d21 + ";" + d22 + ";" + d23 + ";" + d24 + ";" + d25 + ";" + d26 + ";" + d27 + ";" + d28 + ";" + d29 + ";" + d30 + ";" + d31 + ";" + dias_at + "|"; // Fin de Campo ;
                            }
                        }
                        numb_linea = numb_linea + 1;
                    });
                    $('input[name="CampoDatosAsistencia"]').val(linea_tmp);
                }
        }
        
        function mostrarMesOSemanas() {
            

            // se quita encabezado estático de forma temporal por conflictos de estilo
            var $NuevaGrilla = $('#NuevaGrilla');
            $NuevaGrilla.floatThead();
            $NuevaGrilla.floatThead('destroy');

            //// por día
            if ($('#ttodo > a').hasClass('muestra-semanas')) {
                //mostrar todos los que tienen clase semana1,...,semana5
                //esconder ids ts1,...,ts5
                for (var i = 1; i <= 5; i++) {                    
                    $(".semana" + i).show();
                    $("#ts" + i).hide();                    
                }
                
                //establece los rellenos que para ocultar el fondo
                $("#rellenoHead").hide();
                $("[id^='rellenoBody']").hide();


                var columnas = document.getElementById('NuevaGrilla').rows[1].cells.length;
                document.getElementById("rellenofila1header").colSpan = columnas - 15;
               
                
                //cambiar texto de ttodo a "Mostrar Semanas"
                $("#ttodo > a").html('Mostrar Semanas');
                //cambiar clase de ttodo
                $('#ttodo > a').removeClass('muestra-semanas');
                
                //ajustar altura de header y scrollbar


                //$('#tableHeader').css('height', headerHeight+30);

                //$('#NuevaGrilla').css('top', -headerHeight - 10); // se modifica para que no aparezca por debajo el encabezado duplicado.
                //$('#tableHeader').scroll(function () {
                //    $('#tableContainer').scrollLeft($('#tableHeader').scrollLeft());
                //});
                //$('#tableContainer').scroll(function () {
                //    $('#tableHeader').scrollLeft($('#tableContainer').scrollLeft());
                //});


            } else { /// por semana
                //agregar clase muestra-semana a ttodo
                $('#ttodo > a').addClass('muestra-semanas');
                //cambiar texto de ttodo a "Mostrar Mes"
                $("#ttodo > a").html('Mostrar<br/>Mes');
                //mostrar ids ts1,...,ts5
                for (var i = 1; i <= 5; i++) {
                    $("#ts" + i).show();
                }

                //establece los rellenos que para ocultar el fondo
                $("#rellenoHead").show();
                $("[id^=rellenoBody]").show();                
                document.getElementById("rellenofila1header").colSpan = "1";

                //llamar a mostrar semana actual
                var anio = document.getElementById("anioConsultado").value;
                var mes = document.getElementById("mesConsultado").value;
                mostrarSemanaActual(anio, mes);
                //ajustar altura de header y scrollbar
                //$('#tableHeader').css('height', headerHeight );
                //$('#NuevaGrilla').css('top', -headerHeight);
            }


            // se agrega nuevamente el encabezado estático
            fixHeader_(NuevaGrilla);

        }
        
        //gfontbrevis función para setear headers con tabs de semanas
        function setearTabsSemanas() {
            var anio = document.getElementById("anioConsultado").value;
            var mes = document.getElementById("mesConsultado").value;
            var nDiasMes = new Date(anio, mes, 0).getDate();
            var diasCompletar = 35 - nDiasMes;

            $('#NuevaGrilla').find('tr').eq(1).find('th').eq(nDiasMes + 6).after('<th id="rellenoHead" colspan=' + diasCompletar + ' class="semana5" style="background-color:#f59806;"></th>');

            //$('#NuevaGrilla td:last-child').before('<td id="rellenoBody" colspan=' + diasCompletar + ' class="semana5" style="width:10%;"></td>');

            //for (var i = 1; i <= diasCompletar; i++) {

            //    $('#NuevaGrilla td:last-child').before('<td id="rellenoBody' + i + '" class="semana5" style="width:10%;"></td>');
            //}

            if (diasCompletar == 7) {
                $('#NuevaGrilla td:last-child').before('<td id="rellenoBody1" class="semana5" style="width:10%;"></td>');
                $('#NuevaGrilla td:last-child').before('<td id="rellenoBody2" class="semana5" style="width:10%;"></td>');
                $('#NuevaGrilla td:last-child').before('<td id="rellenoBody3" colspan="5" class="semana5" style="width:10%;"></td>');
            }

            if (diasCompletar == 6) {
                $('#NuevaGrilla td:last-child').before('<td id="rellenoBody1" class="semana5" style="width:10%;"></td>');                
                $('#NuevaGrilla td:last-child').before('<td id="rellenoBody2" colspan="5" class="semana5" style="width:10%;"></td>');
            }

            if (diasCompletar == 5) {               
                $('#NuevaGrilla td:last-child').before('<td id="rellenoBody1" colspan="5" class="semana5" style="width:10%;"></td>');
            }

            if (diasCompletar == 4) {
                $('#NuevaGrilla td:last-child').before('<th id="rellenoBody1" colspan="4" class="semana5" style="width:10%;"></th>');
            }


            $('#tabsSemanas').html('<table class="tabs-semanas text-center"><tr><td id="ts1"><a onclick="mostrarSemana(1)">Semana<br/>N°1</a></td><td id="ts2"><a onclick="mostrarSemana(2)">Semana<br/>N°2</a></td><td id="ts3"><a onclick="mostrarSemana(3)">Semana<br/>N°3</a></td><td id="ts4"><a onclick="mostrarSemana(4)">Semana<br/>N°4</a></td><td id="ts5"><a onclick="mostrarSemana(5)">Semana<br/>N°5</a></td><td id="ttodo" bgcolor="#419641"><a class="muestra-semanas" onclick="mostrarMesOSemanas()">Mostrar<br/>Mes</a></td>   </tr><table>');

            //$("#rellenofila1headermes").hide();
            document.getElementById("rellenofila1header").colSpan = "1";

            mostrarSemanaActual(anio, mes);

            //if ($('#NuevaGrilla tr').length > 18) {
            //    fixNHeaders('#NuevaGrilla', '#tableHeader', '#tableContainer', 2);
            //}
            

            
            //Bloquear pestañas de semanas que aún no llegan
            var mes_actual = new Date().getMonth() + 1;
            var anio_actual = new Date().getFullYear();
            var hoy = new Date().getDate();
            if (mes == mes_actual && anio == anio_actual) {
                var semana_bloqueada = Math.floor((hoy-1) / 7 + 2);//+1 es la semana actual que no debe bloquearse
                for (var i = semana_bloqueada; i <= 5; i++) {
                    $("#ts" + i + " > a").removeAttr("onclick");
                }
            }
        }

        $(document).ready(function () {
            $("#btnmMostrar").click(function () {
                var contenido = $('#CampoDatosAsistencia').val();

                alert(contenido);
            });
        });
        $(document).ready(function () {

            $("#tablaAsistencia").show();
            setearTabsSemanas();
            nuevaGrillaClick();

            fixHeader_(NuevaGrilla);

            // CET region en donde se mantiene estático el encabezado de la tabla

            // se setean los valores por defecto en donde se utiliza el alto del menu para colocar el encabezado estático
            //var menuheight = $("#navbar").height();

            //$.floatThead.defaults = {
            //    headerCellSelector: 'tr:visible:first>*:visible', //thead cells are this.
            //    zIndex: 1001,
            //    position: 'auto', 
            //    top: menuheight + 4, // alto del menu mas un margen 
            //    bottom: 0, 
            //    scrollContainer: function ($table) {
            //        return $([]); 
            //    },
            //    getSizingRow: function ($table, $cols, $fthCells) {                    
            //        return $table.find('tbody tr:visible:first>*:visible');
            //    },
            //    floatTableClass: 'floatThead-table',
            //    floatWrapperClass: 'floatThead-wrapper',
            //    floatContainerClass: 'floatThead-container',
            //    copyTableClass: true, 
            //    enableAria: false, 
            //    autoReflow: false, 
            //    debug: false 
            //};

            //// funcion en donde se realiza la magia, en ella se utiliza el js jquery.floatThead.js
            //var $NuevaGrilla = $('#NuevaGrilla');
            //$NuevaGrilla.floatThead({
            //    scrollContainer: function ($NuevaGrilla) {
            //        return $NuevaGrilla.closest('.wrapper');
            //    }
            //});

            
            //document.getElementById("#NuevaGrillaheader").setAttribute("style", "border-color:'transparent';");

            //document.getElementById("#NuevaGrillaheader").removeAttribute("class");
            //document.getElementById("#NuevaGrillaheader").setAttribute("class","table table-borderless table-hover");
            headerHeight = $("#fila1header").height() + $("#fila2header").height();
           
        });

        function getVal(e) {
            var Table = e.parentNode.parentNode.parentNode;
            var row = e.parentNode;
            var rowTotalAtendidos = Table.rows[Table.rows.length - 2];
            var rowTotalInasistencia = Table.rows[Table.rows.length - 1];

            var TotalLinea = parseInt(row.cells[row.cells.length - 1].innerHTML) || 0;
            var TotalAtendidosDia = parseInt(rowTotalAtendidos.cells[e.cellIndex - 6].innerHTML) || 0;
            var TotalAtendidosLinea = parseInt(rowTotalAtendidos.cells[rowTotalAtendidos.cells.length - 1].innerHTML) || 0;

            var TotalInasistenciaDia = parseInt(rowTotalInasistencia.cells[e.cellIndex - 6].innerHTML) || 0;
            var TotalInasistenciaLinea = parseInt(rowTotalInasistencia.cells[rowTotalInasistencia.cells.length - 1].innerHTML) || 0;

            switch (e.innerHTML) {
                case "P":
                    e.innerHTML = "A";
                    e.style.backgroundColor = '#ff0000';
                    TotalLinea -= 1;
                    TotalAtendidosDia -= 1;
                    TotalAtendidosLinea -= 1;
                    TotalInasistenciaDia += 1;
                    TotalInasistenciaLinea += 1;
                    $('#ConfirmaAsistencia').val('1');
                    break;
                case "A":
                    e.innerHTML = "F";
                    e.style.backgroundColor = '#ffff00';
                    TotalLinea += 1;
                    TotalAtendidosDia += 1;
                    TotalAtendidosLinea += 1;
                    TotalInasistenciaDia -= 1;
                    TotalInasistenciaLinea -= 1;
                    $('#ConfirmaAsistencia').val('1');
                    break;
                case "F":
                    e.innerHTML = "H";
                    e.style.backgroundColor = '#00f5ff';
                    $('#ConfirmaAsistencia').val('1');
                    break;
                case "H":
                    $('#ConfirmaAsistencia').val('1');
                    e.innerHTML = "P";
                    e.style.backgroundColor = '#008b00';
                    break;
            }

            if (e.innerHTML != "") // && LetraNueva != LetraActual)
            {
                row.cells[row.cells.length - 1].innerHTML = TotalLinea || "";
                rowTotalAtendidos.cells[e.cellIndex - 6].innerHTML = TotalAtendidosDia || "";
                rowTotalAtendidos.cells[rowTotalAtendidos.cells.length - 1].innerHTML = TotalAtendidosLinea || "";

                rowTotalInasistencia.cells[e.cellIndex - 6].innerHTML = TotalInasistenciaDia || "";
                rowTotalInasistencia.cells[rowTotalInasistencia.cells.length - 1].innerHTML = TotalInasistenciaLinea || "";
            }
            
        }


    </script>

</head>

<body role="document" onmousemove="SetProgressPosition(event)">
    <form id="form1" runat="server">

        <uc1:menu_colgante runat="server" ID="menu_colgante" />

        <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ajax:ModalPopupExtender ID="mpe1" runat="server"
                    TargetControlID="Imb004"
                    PopupControlID="modal_imprimir"
                    CancelControlID="bt_cerrar_imprimir"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>

                <input type="hidden" id="Buscando" value="0">
                <input id="TiempoBusqueda" type="hidden" runat="server" name="TiempoBusqueda" />
                <div>
                    <div class="container theme-showcase" role="main">
                        <ol class="breadcrumb">
                            <li><a href="~/index.aspx" runat="server">Inicio</a></li>
                            <li class="active">Niños/as</li>
                            <li class="active">Registro de Atención</li>
                        </ol>
                        <div class="text-center alert alert-warning" role="alert" id="alerts" runat="server" visible="false">
                          <%--
                          <asp:Label ID="lbl003" runat="server" CssClass="texto_rojo_peque" Text="No hay datos para el periodo consultado" Visible="False"></asp:Label>
                          <asp:Label ID="lbl002" runat="server" Text="Este mes fue cerrado, sólo Administrador podrá realizar cambios." Visible="False" CssClass="texto_rojo_peque"></asp:Label>
                          <asp:Label ID="lbl004" runat="server" CssClass="texto_rojo_peque" Text="Cambios Realizados." Visible="False"></asp:Label>
                          <asp:Label ID="lbl005" runat="server" CssClass="texto_rojo_peque" Text="Asistencia Confirmada" Visible="False"></asp:Label>
                          <asp:Label ID="lbl_error_dia" runat="server" CssClass="texto_rojo_peque" Text="Solo se pueden realizar cambios sobre el día en curso." Visible="False"></asp:Label>
                          --%>
                                                        <span class="glyphicon glyphicon-warning"></span>

                          <asp:Label ID="lbl003" runat="server" Text="No hay datos para el periodo consultado" Visible="False"></asp:Label>
                          <asp:Label ID="lbl002" runat="server" Text="Este mes fue cerrado, sólo Administrador podrá realizar cambios." Visible="False"></asp:Label>
                          <asp:Label ID="lbl_error_dia" runat="server" Text="Solo se pueden realizar cambios sobre el día en curso." Visible="False"></asp:Label>
                          
                      </div>
                        <div class="text-center alert alert-success" role="alert" id="alertSuccess" runat="server" visible="false">
                            <span class="glyphicon glyphicon-ok"></span>
                            <asp:Label ID="lbl004" runat="server" Text="Cambios Realizados." Visible="False"></asp:Label>
                            <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Visible="False"></asp:Label>
                        </div>
                        <div class="well">
                            <h4 class="subtitulo-form">Registro de Atención</h4>
                            <hr>

                          <a id="collapse" class="collapsed" data-toggle="collapse" data-parent="#accordion"  href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                                  <asp:label ID="lbl_acordeon" runat="server" Visible ="true" Text="Mostrar Detalles de la Búsqueda"></asp:label>
                                    <span id="icon-collapse" class="glyphicon glyphicon-triangle-bottom" ></span>
                          <asp:label ID="lbl_resumen_filtro" runat="server" Visible ="false" Text=""></asp:label>
                          <asp:label ID="lbl_resumen_proyecto" runat="server" Visible ="false"></asp:label>
                          </a>
                          
                          
                          
                            <asp:HiddenField ID="mesConsultado" Value="" runat="server" /><!-- gfontbrevis: mes que se está consultando-->
                            <asp:HiddenField ID="anioConsultado" Value="" runat="server" /><!-- gfontbrevis: anio que se está consultando-->
                          <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="row">
                                <div class="col-md-9">
                                    <form action="">
                                        
                                        <table class="table table-borderless table-condensed">
                                            <tr>
                                                <td class="col-md-3">
                                                    <label for="">Institución:</label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddown001" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" CssClass="form-control input-sm" disabled="disabled" >
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label for="">Proyecto:</label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddown002" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" CssClass="form-control input-sm" disabled="disabled">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label for="">Inmueble del Proyecto:</label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddown003" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" CssClass="form-control input-sm" disabled="disabled">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                         
                                            <tr>
                                                <td>
                                                    <label for="">Período</label>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddown_MesCierre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" CssClass="form-control input-sm" Enabled="False">
                                                                    <asp:ListItem>Seleccione mes</asp:ListItem>
                                                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddown_AnoCierre" runat="server" OnSelectedIndexChanged="ddown003_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control input-sm" Enabled="False">
                                                                </asp:DropDownList>
                                                                        </td>
                                                                        <td class="col-md-3 text-center">
                                                                <label for="">Sexo:</label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButton ID="rdo_SexoA" runat="server" Font-Size="11px" GroupName="rdosexo" Text="Ambos" Checked="True" AutoPostBack="True" OnCheckedChanged="rdo_SexoA_CheckedChanged" Enabled="False" />&nbsp;&nbsp;&nbsp;
                                                                <asp:RadioButton ID="rdo_SexoM" runat="server" Font-Size="11px" GroupName="rdosexo" Text="Masculino" AutoPostBack="True" OnCheckedChanged="rdo_SexoA_CheckedChanged" Enabled="False"  />&nbsp;&nbsp;&nbsp;
                                                                <asp:RadioButton ID="rdo_SexoF" runat="server" Font-Size="11px" GroupName="rdosexo" Text="Femenino" AutoPostBack="True" OnCheckedChanged="rdo_SexoA_CheckedChanged" Enabled="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    

                                                </td>
                                            </tr>
                                        </table>
                                    </form>
                                </div>
                                <div class="col-md-3">       
                                                        
                                <asp:Panel ID="panelInfoBusqueda" runat="server" CssClass="panel-info panel-primary-info">
                                    <div class="panel-heading">
                                       Información
                                    </div>
                                    <div class="panel-footer">
                                        
                                        <asp:Label ID="Lbl_Info1" CssClass="subtitulo-form-info" runat="server" Text="Días de Atención: " ></asp:Label>       
                                        <asp:Label ID="lbl001" CssClass="subtitulo-form-info" runat="server" ></asp:Label>
                                        
                                                                              
                                    </div>
                                    </asp:Panel>
                                
                                  
                                </div>
                            </div>
                            <!--fin Row -->
                          </div>
                          <div class="row">
                                <div class="col-md-9">
                                <table class="table table-borderless table-condensed">
                                    <tr>
                                        <td class="col-md-2"></td><td class="pull-right">
                              
                              <asp:LinkButton ID="Imb007" runat="server" CssClass="btn btn-success btn-sm fixed-width-button" OnClick="Imb007_Click1"><span class="glyphicon glyphicon-save-file" aria-hidden="true"></span> Exportar a Excel</asp:LinkButton>

                              <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="Imb003" OnClientClick="GuardaAsistencia(0);" runat="server"  Visible="true" ><span class="glyphicon glyphicon-ok"></span>&nbsp;Guardar</asp:LinkButton>
                              <asp:Button ID="btnGuardaAsistenciaSinConfirmar" runat="server" OnClick="btnGuardaAsistenciaSinConfirmar_Click" CssClass="btn btn-danger btn-sm fixed-width-button" style="display: none" ></asp:Button>                  

                              <asp:LinkButton ID="Imb006" runat="server" OnClientClick="GuardaAsistencia(1);" CssClass="btn btn-danger btn-sm fixed-width-button"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span>Guardar Asistencia</asp:LinkButton>
                              <asp:Button ID="btnGuardaAsistencia" runat="server" OnClick="btnGuardaAsistencia_Click" CssClass="btn btn-danger btn-sm fixed-width-button" style="display: none" ></asp:Button>
                              
                              <asp:LinkButton ID="Imb004" runat="server"  CssClass="btn btn-success btn-sm fixed-width-button" OnClick="Imb004_Click"><span class="glyphicon glyphicon-print" aria-hidden="true"></span> Imprimir</asp:LinkButton>                                 
                              
                              <asp:LinkButton CssClass="btn btn-primary btn-sm fixed-width-button" ID="Imb001" runat="server"  Visible="true" OnClick="Imb001_Click">
                                  <span class="glyphicon glyphicon-arrow-left" aria-hidden="true"></span> Atrás
                              </asp:LinkButton>

                              
                              <asp:LinkButton CssClass="btn btn-info btn-sm fixed-width-button" ID="imb005" runat="server"  Visible="False" OnClick="imb005_Click" >
                                  <span class="glyphicon glyphicon-repeat"></span>&nbsp;Regenerar
                              </asp:LinkButton>

                              <%--<asp:Button CssClass="btn btn-info btn-sm" ID="Imb007" runat="server" Text="Exportar a Excel" Visible="true" OnClick="Imb007_Click1" />--%>
                              <%--<asp:Button CssClass="btn btn-info btn-sm" ID="Imb004" runat="server" Text="Imprimir" Visible="true" OnClick="Imb004_Click" />--%>
                              <%--<asp:Button CssClass="btn btn-primary btn-sm" ID="WebImageButton1" runat="server" Text="Volver" Visible="true" OnClick="imb_volver_Click" />--%>
                              <%--<asp:Button ID="Button1" runat="server" Text="Confirmar y guardar asistencia" Width="180px" Visible="true" OnClick="imb006_Click" CssClass="btn btn-info btn-sm" />--%>
                                       </td></tr></table></div>
                          </div>
                          <br />
                            <!-- WELL -->
                        </div>

                      
                      <div id="divContenido">
                          <div class="popupConfirmation" id="modal_imprimir" style="display: none" runat="server">
                              <iframe id="iframe_imprimir" src="Cierre_RegistroAtencionReporte.aspx" width="800px" height="600px" runat="server"></iframe>
                              <asp:Button ID="bt_cerrar_imprimir" Text="Cerrar" runat="server" CssClass="btn btn-primary btn-sm" />
                          </div>
                      </div>

                        <!-- Container -->
                      
                    </div>

                    <br>
                    <div class="row">
                        <%--<div class="col-md-12 caja-tabla table-responsive">--%>
                        <div class="col-md-12">
                            
                            <caption>
                                <asp:Label ID="lblEventosProyecto" runat="server" CssClass="texto_form" Text="Cantidad de Eventos del Proyecto:  " Visible="False" Width="373px"></asp:Label>
                            </caption>
                               
                            <div runat="server" id="exportargrilla">
                                <div id="tablaAsistencia" style="display: none;">
                                    <div id="tableHeader" <%--class="fixed-header"--%>></div>
                                    <div id="tableContainer" class="fixed-header-table-container">
                                        <asp:Table ID="NuevaGrilla" runat="server" EnableViewState="true" RowCssClass="table-bordered" HeaderCssClass="titulo-tabla table-borderless" CssClass="mira table table-bordered table-hover">
                                                                              
                                        </asp:Table>
                                            
                                    </div>
                                </div>
                            </div>
                                            <%--<asp:GridView ID="grd001" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" Visible="False" EnableTheming="True" CssClass="table table-bordered table-hover">
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <Columns>
                                                            <asp:BoundField DataField="icodie" HeaderText="Cod. Ingreso-Egreso" />
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                                            <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                                                            <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                                                            <asp:BoundField DataField="diasatencion" HeaderText="Dias Atención" />
                                                            <asp:BoundField DataField="diasausentes" HeaderText="Dias Ausentes" />
                                                            <asp:BoundField DataField="numerointervencionesotras" HeaderText="Número Intervenciones Otras" />
                                                            <asp:BoundField DataField="numerointervenciones" HeaderText="Numero Intervenciones Directas" />
                                                            <asp:BoundField DataField="diasintervencion" HeaderText="Total días a pagar por intervención" />
                                                            <asp:BoundField DataField="DiasAtendido" HeaderText="Total días a pagar por atención" />
                                                        </Columns>
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>--%>
                                        
                                    <asp:HiddenField ID="CampoDatosAsistencia" Value="VACIO" runat="server" />
                                    <asp:HiddenField ID="ConfirmaAsistencia" Value="0" runat="server" />
                                    <asp:HiddenField ID="GrillaHTML" Value="VACIO" runat="server" />
                                
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

            <Triggers>
                <asp:PostBackTrigger ControlID="Imb007" />
                <asp:PostBackTrigger ControlID="Imb004" />
                <asp:PostBackTrigger ControlID="btnGuardaAsistencia" />
                <asp:PostBackTrigger ControlID="btnGuardaAsistenciaSinConfirmar" />

            </Triggers>

        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
               
                <div  id="divProgress" class="ajax_cargando">
                    <img alt="Cargando" src="../images/Cursors/ajax-loader.gif"/>
                    Cargando...       
                </div>
                
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
