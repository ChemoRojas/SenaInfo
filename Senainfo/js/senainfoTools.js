/*
Senainfo Tools

Herramientas utiles para senainfo
Recopilado por GFontBrevis

Importante: guardar este archivo con encoding UTF-8 (Archivo > Opciones Avanzadas para Guardar > UNICODE (utf-8)...)


*/

// CET region en donde se mantiene estático el encabezado de la tabla sin clonarla



function fixHeader_(gridviewID, esGridview) {

    if (esGridview == '1') {
        //inserta el encabezado como thead para que se puede hacer el fix en el head.
        $(gridviewID + " tbody").before("<thead Class='titulo-tabla'><tr></tr></thead>");
        $(gridviewID + " thead tr").append($(gridviewID + " th"));
        $(gridviewID + " tbody tr:first").remove();

        //agregado para el formulario  ninos_egreso, para que no genere un thead en una sub tabla
        if ($("#tblges").length) {
            $('#tblges thead').remove();
        }
    }

    // se setean los valores por defecto en donde se utiliza el alto del menu para colocar el encabezado estático
    var menuheight = $("#navbar").height();
    $.floatThead.defaults = {
        headerCellSelector: 'tr:visible:first>*:visible',
        zIndex: 1001,
        position: 'auto',
        top: menuheight + 4, // alto del menu mas un margen 
        bottom: 0,
        scrollContainer: function ($table) {
            return $([]);
        },
        getSizingRow: function ($table, $cols, $fthCells) {
            return $table.find('tbody tr:visible:first>*:visible');
        },
        floatTableClass: 'floatThead-table',
        floatWrapperClass: 'floatThead-wrapper',
        floatContainerClass: 'floatThead-container',
        copyTableClass: true,
        enableAria: false,
        autoReflow: false,
        debug: false
    };

    // se realiza la magia que deja estático el encabezado
    var $NuevaGrilla = $(gridviewID);
    $NuevaGrilla.floatThead({
        scrollContainer: function ($NuevaGrilla) {
            return $NuevaGrilla.closest('.wrapper');
        }
    });

}


// mueve el FixHeader cuando se muestra u oculta el collapse
function collapseFixHeader(gridviewID) {
    var interval = window.setInterval(function () {
        $(gridviewID).floatThead('reflow');
    }, 10);
    $('#collapse_Form').on('transitionend webkitTransitionEnd oTransitionEnd', function () {
        window.clearInterval(interval);
        $(gridviewID).floatThead('reflow');
    });
}


/*funcion para fijar headers de tabla
Args: 
    gridviewID: ID del gridview del cual se quiere fijar el header.
    tableHeader: id del div vacio que contendra el header fijo.
La funcion se llama desde codeBehind, al final del metodo que genera la tabla gridview.
*/
function fixHeader(gridviewID, tableHeader) {
    var gridHeader = $(gridviewID).clone(true);
    $(gridviewID + ' tr th').each(function (i) {
        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
    });
    $(gridHeader).find("tr:gt(0)").remove();
    $(tableHeader).append(gridHeader);
    $(tableHeader).css('position', 'relative');
    gridHeader.attr('id', "grd001header");

    //esconder header de tabla
    $(gridviewID + ' .titulo-tabla').css('visibility', 'hidden');
    var height = $(gridviewID + ' th').outerHeight();
    $(gridviewID).css('position', 'relative');
    $(gridviewID).css('top', -height);

    //fijar altura de div de la tabla
    $('.fixed-header-table-container').css('height', '400px');

}
/*
funcion para fijar headers de tabla cuando hay mas de una tabla por pagina
Args: 
    gridviewID: ID del gridview del cual se quiere fijar el header.
    tableHeader: id del div vacio que contendra el header fijo.
    tableContainer: id del div que contiene el cuerpo de la tabla.
La funcion se llama desde codeBehind, al final del metodo que genera la tabla gridview.
*/

/*
Funcion para generar tablas dinamicas Jquery Datatables
Args: 
    gridviewID: ID del gridview del cual se quiere fijar el header, ej: #ID.
    form_name: nombre del formulario
Esta función se utilizará en una función postBack dentro de los formularios.
*/
function generateDataTable(gridViewId) {
    //$("#" + gridViewId.data("name") + "").DataTable()

    if (gridViewId.data("name") == "grd_ninosVigentes")
    {
        gridViewId.DataTable({
            sorting: false,
            ordering: false,
            paging: false
        });
    } else {
        gridViewId.DataTable({
            sorting: false,
            ordering: false
        });
    }
    
    $("#" + gridViewId.data("name") + " th").removeAttr("style");
    $("#" + gridViewId.data("name") + " th").addClass("text-center");
    $("#" + gridViewId.data("name") + "_filter").width($("#" + gridViewId.data("name") + "_filter").parent().width());

    if (gridViewId.data("name") == "GridAlertasEgresosPendientesxCausal") {
        $("#" + gridViewId.data("name") + "_filter").removeAttr("style");
        $("#" + gridViewId.data("name") + "_filter").removeClass("col-md-6");
    }

    if (gridViewId.data("name") == "GridAlertasListaEsperaxAbuso") {
        $("#" + gridViewId.data("name") + "_filter").removeAttr("style");
        $("#" + gridViewId.data("name") + "_filter").removeClass("col-md-6");
    }

    if (gridViewId.data("name") == "GridAlertasEgresosxTraslado") {
        $("#" + gridViewId.data("name") + "_filter").removeAttr("style");
        $("#" + gridViewId.data("name") + "_filter").removeClass("col-md-6");
    }

}




function fixHeaders(gridviewID, tableHeader, tableContainer) {
    //DEPRECADO
    //fijar altura de div de la tabla
    $(tableContainer).css('height', '400px');

    var gridHeader = $(gridviewID).clone(true);
    $(gridviewID + ' tr th').each(function (i) {
        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
    });
    $(gridHeader).find("tr:gt(0)").remove();
    $(tableHeader).append(gridHeader);
    //TODO: agregar td para dar ancho de scroll
    //$(tableHeader + ' th:last').after("<th scope='col' style='width: 10px; padding:0px;'></th>");
    $(tableHeader).css('position', 'relative');
    gridHeader.attr('id', gridviewID + "header");

    //esconder header de tabla
    $(gridviewID + ' .titulo-tabla').css('visibility', 'hidden');
    var height = $(gridviewID + ' th').outerHeight();
    $(gridviewID).css('position', 'relative');
    $(gridviewID).css('top', -height);
}
function fixNHeaders(gridviewID, tableHeader, tableContainer, N) {
    //fijar altura de div de la tabla
    var height = 0;
    $(tableContainer).css('height', '400px');
    if (N == 2) {
        height += $("#fila1header").height() + $("#fila2header").height();
    } else {
        height += $(gridviewID + ' th').outerHeight() * N;
    }

    //fijar altura de div de header
    $(tableHeader).css('height', height);


    var gridHeader = $(gridviewID).clone(true);
    gridHeader.attr('id', gridviewID + "header");
    gridHeader.find('td:last-child').after("<th scope='col' style='width: 13px; padding:0px;'></th>");

    $(tableHeader).append(gridHeader);
    $(gridviewID).css('position', 'relative');
    $(gridviewID).css('top', -height);
}

function limpiaiframe(objIframe) {

    if (objIframe) {
        frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
        frameDoc.documentElement.innerHTML = "";
    }
}

function mostrar_cargando(objIframe) {
    
    if (objIframe) {
        frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
        frameDoc.documentElement.innerHTML = "<div style='padding: 5px;z-index: 100;width: 220px;position: absolute;left : 35%;-moz-opacity: 0.75;opacity: 0.75;filter: alpha(opacity=75);font-family: Tahoma;font-size: 11px;font-weight: bold;text-align: center;'><img alt='Cargando' src='../images/Cursors/ajax-loader.gif' /></br>Cargando... </div>";
    }
}
function MostrarModalProyecto(param, dir, modalPopupExtender) {
    var objIframe = document.getElementById('iframe_bsc_proyecto');
    mostrar_cargando(objIframe);
    objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=" + param + "&dir=" + dir;
    objIframe.height = "300px";
    objIframe.width = "760px";
    $find(modalPopupExtender).show();
    return false;
}
function MostrarModalInstitucion(param, dir, modalPopupExtender) {
    var objIframe = document.getElementById('iframe_bsc_institucion');
    mostrar_cargando(objIframe);
    objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=" + param + "&dir=" + dir;
    objIframe.height = "300px";
    objIframe.width = "760px";
    $find(modalPopupExtender).show();
    return false;
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
    if (document.getElementById('divProgress')) {

        document.getElementById('divProgress').style.top = posy + "px";
    }
    
}
/*
Funcion para mostrar y ocultar columnas segun semanas
*/
function mostrarSemana(semana) {
    for (var i = 1; i <= 5; i++) {
        if (i != semana) {
            $(".semana" + i).hide();
            $("#ts" + i).removeClass();
        }
    }
    $(".semana" + semana).show();
    $("#ts" + semana).addClass("active");
    console.log(semana);
}

/*Funcion para hacer colapsable el menu de busqueda*/
//TODO: hacer una para "busqueda avanzada" y otra para "detalles de busqueda"
function mostrarlbl_resumen() {
    $("#lbl_resumen_filtro").show();
    $("#lbl_resumen_proyecto").show();
}

function ocultarlbl_resumen() {
    $("#lbl_resumen_filtro").hide();
    $("#lbl_resumen_proyecto").hide();
}
function pageLoad(sender, args) {
    $(document).ready(function () {
        if (typeof $("#collapse") !== 'undefined') {
            // the variable is defined

            $("#collapse").click(function () {
                if ($("#collapse").hasClass("collapsed")) { //mostrado
                    $("#icon-collapse").removeClass();
                    $("#icon-collapse").addClass("glyphicon glyphicon-triangle-top");
                    $("#lbl_acordeon").text('Ocultar Detalles de la Búsqueda');
                    ocultarlbl_resumen();
                }
                else {
                    $("#icon-collapse").removeClass(); // oculto
                    $("#icon-collapse").addClass("glyphicon glyphicon-triangle-bottom");
                    $("#lbl_acordeon").text('Mostrar Detalles de la Búsqueda');
                    mostrarlbl_resumen();
                }
            });
        }

    });
};

/*funcion que se utiliza para mostrar solo la pestaña correspondiente a la semana actual*/
function mostrarSemanaActual(anio, mes) {
    var anioActual = new Date().getFullYear();
    var mesActual = new Date().getMonth() + 1;
    if (mesActual != mes || anioActual != anio) {
        //consultando mes que no está en curso
        mostrarSemana(1);

    } else {
        //consultando mes en curso
        var hoy = new Date().getDate();
        var semana = Math.floor((hoy - 1) / 7) + 1;
        mostrarSemana(semana);
    }

}
/*Funciones para modulo niños - diagnostico del niño */

function mostrarCollapse(valor) {
    if (valor) {
        document.getElementById("collapse_Form").removeAttribute("class");
        document.getElementById("collapse_Form").setAttribute("class", "panel-collapse collapse in");
    }
    if (!valor) {

        document.getElementById("collapse_Form").removeAttribute("class");
        document.getElementById("collapse_Form").setAttribute("class", "panel-collapse collapse out");
    }
}
function mostrarBotonCancelar() {
    //gfontbrevis 
    document.getElementById("btnGatillo").setAttribute("disabled", "disabled");
    mostrarCollapse(true);
    return false;
}

function mostrarBotonAgregar() {
    //gfontbrevis
    document.getElementById("btnGatillo").removeAttribute("disabled");
    mostrarCollapse(false);
    cleanForm();
    return false;
}

/*function getScrollbarWidth() {
    var outer = document.createElement("div");
    outer.style.visibility = "hidden";
    outer.style.width = "100px";
    outer.style.msOverflowStyle = "scrollbar"; // needed for WinJS apps

    document.body.appendChild(outer);

    var widthNoScroll = outer.offsetWidth;
    // force scrollbars
    outer.style.overflow = "scroll";

    // add innerdiv
    var inner = document.createElement("div");
    inner.style.width = "100%";
    outer.appendChild(inner);

    var widthWithScroll = inner.offsetWidth;

    // remove divs
    outer.parentNode.removeChild(outer);

    return widthNoScroll - widthWithScroll;
}*/

function formatearTabla(tableId) {
    tableId.DataTable({
        "dom": '<"top"ilf>t<"bottom"p><"clear">'
    });
}

function mostrarDocumentacionActiva() {
    $("#documentacion :radio").filter(":checked").closest("tr").css("display", "");
}

function mostrarIdiomasActivos() {
    $("#idiomas :radio").filter(":checked").closest('tr').css("display", "");
}

function mostrarTodosDocumentacion() {
    $("#documentacion :radio").closest("tr").css("display", "");
}

function mostrarTodosIdiomas() {
    $("#idiomas :radio").closest('tr').css("display", "");
}

function ValidaRuc(source, arguments) {

    var rut = arguments.Value;
    rut = rut.trim();
    if (rut.length > 12) { arguments.IsValid = false; return }
    //if (rut == '0000000000-0') { arguments.IsValid = false; return }
    var strGuionDigito = rut.substring(rut.length - 2);
    var strDigitoV = rut.substring(rut.length - 1);
    var strCuerpo = rut.substring(0, rut.length - 2);

    if (!$.isNumeric(strCuerpo)) { arguments.IsValid = false; return }

    if (strGuionDigito.substring(0, 1) != '-') { arguments.IsValid = false; return }
    var aux = "2765432765432";
    if (strDigitoV == 'K') {
        var ruc = "123456789K0";
    }
    else {
        var ruc = "123456789k0";
    }
    var ns = rut.length;
    var i = ns - 2;
    var a = 12;
    var sum = 0;
    while (i >= 0) {
        if (rut.substring(i, i + 1) != '-') {
            sum = sum + (parseInt(rut.substring(i, i + 1)) * parseInt(aux.substring(a, a + 1)));
            a = a - 1;
            if (a == 0) a = 12;
        }
        i = i - 1;
    }
    sum = 11 - (sum % 11);
    if (rut.substring(ns - 1, ns) == ruc.substring(sum - 1, sum))
        arguments.IsValid = true;

    else
        arguments.IsValid = false;
}

function ValidaRucLRPA(source, arguments) {

    var rut = arguments.Value;
    rut = rut.trim();
    if (rut.length > 12) { arguments.IsValid = false; return }
    if (rut == '0000000000-0') { arguments.IsValid = false; return }
    var strGuionDigito = rut.substring(rut.length - 2);
    var strDigitoV = rut.substring(rut.length - 1);
    var strCuerpo = rut.substring(0, rut.length - 2);

    if (!$.isNumeric(strCuerpo)) { arguments.IsValid = false; return }

    if (strGuionDigito.substring(0, 1) != '-') { arguments.IsValid = false; return }
    var aux = "2765432765432";
    if (strDigitoV == 'K') {
        var ruc = "123456789K0";
    }
    else {
        var ruc = "123456789k0";
    }
    var ns = rut.length;
    var i = ns - 2;
    var a = 12;
    var sum = 0;
    while (i >= 0) {
        if (rut.substring(i, i + 1) != '-') {
            sum = sum + (parseInt(rut.substring(i, i + 1)) * parseInt(aux.substring(a, a + 1)));
            a = a - 1;
            if (a == 0) a = 12;
        }
        i = i - 1;
    }
    sum = 11 - (sum % 11);
    if (rut.substring(ns - 1, ns) == ruc.substring(sum - 1, sum))
        arguments.IsValid = true;

    else
        arguments.IsValid = false;
}

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


//CountDownTimer('04/13/2016 6:30 PM', 'countdown');

function CountDownTimer(dt, id) {

    for (var i = 1; i < 99999; i++) { // detiene todos los countdown existentes anteriormente
        window.clearInterval(i);
        window.clearTimeout(i);
        if (window.mozCancelAnimationFrame) window.mozCancelAnimationFrame(i); // Firefox
    }

    var end = new Date(dt);
    var timer;
    var _second = 1000;
    var _minute = _second * 60;
    var _hour = _minute * 60;
    var _day = _hour * 24;
    

    function showRemaining() {
        var now = new Date();
        var distance = end - now;
        if (distance < 0) {

            clearInterval(timer);
            document.getElementById(id).innerHTML = ' TIEMPO EXPIRADO. ';

            return;
        }
        var days = Math.floor(distance / _day);
        var hours = Math.floor((distance % _day) / _hour);
        var minutes = Math.floor((distance % _hour) / _minute);
        var seconds = Math.floor((distance % _minute) / _second);

        document.getElementById(id).innerHTML = days + ' Dias ';
        document.getElementById(id).innerHTML += hours + ' Horas ';
        document.getElementById(id).innerHTML += minutes + ' Minutos ';
        document.getElementById(id).innerHTML += seconds + ' Segundos';        
    }

    timer = setInterval(showRemaining, 1000);
    
}

