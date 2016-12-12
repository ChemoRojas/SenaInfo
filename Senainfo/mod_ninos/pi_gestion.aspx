<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pi_gestion.aspx.cs" Inherits="mod_ninos_pi_gestion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="SenameWebTextbox" Namespace="CustomWebControls" TagPrefix="cc1" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>



<html lang="es">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="S">
    <meta name="author" content="">
    <link rel="icon" href="../images/favicon.ico">
    <title>Gestión Plan Internvención :: Senainfo :: Servicio Nacional de Menores</title>







    <script src="../js/ie-emulation-modes-warning.js"></script>
    <%--<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.1.1.min.js"></script>--%>
    <script src="../js/jquery-2.1.4.js">
    </script>
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../Script/jquery.mousewheel-3.0.4.pack.js"></script>
    <script src="../js/notify.js"></script>
    <script src="../js/senainfoTools.js"></script>
    <script src="../js/jquery.floatThead.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
    <script src="../js/dataTables.bootstrap.js"></script>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap theme -->
    <link href="../css/bootstrap-theme.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/theme.css" rel="stylesheet">
    <link href="../css/dataTables.bootstrap.css" rel="stylesheet" />

    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {

                $('#collapse').click(function () {
                    collapseFixHeader('#grd001');
                });

                if ($("#grd001").length > 0) {//&& new $.fn.dataTable.Api(gridViewId).init() == null) {
                    generateDataTable($("#grd001"));
                }



            });
        };

        //pageLoad();

        function LlamaActualizacion() {
            //gfontbrevis no se llama ni de aspx ni de cs
            var objeto = window.frames[0].document.getElementById('lbtActualizar');
            objeto.click();
            var objeto = window.frames[2].document.getElementById('lbtActualizar');
            objeto.click();
            alert('OK');


        }
        $(document).on('shown.bs.tab', 'a[data-toggle="tab"]', function (e) {
            $("#lbl005").hide();
            $("#alerts").hide();
            $("#lbl0052").hide();
            $("#alerts2").hide();
        })

        function LimpiarPlan() {
            var objeto = window.document.getElementById('lbtlimpiar');
            objeto.click();

        }
        function CierrePlan() {
            var objeto = window.document.getElementById('lbtCerrar');
            objeto.click();
            alert('El Plan ha sido cerrado.');
        }

        function LlamaValidacion() {
            //ojo, no existe lbtvalidar
            var objeto = window.document.getElementById('lbtValidar')
            alert(objeto);
            objeto.click();
        }

        function PestañaActual(n) {
            $("#CurrentPage").val(n);
        }

        function hacerclickboton(url) {
            var btn = document.getElementById('A3');
            btn.href = url;
            btn.click();
        }

        function limpiaiframe(objIframe) {
            frameDoc = objIframe.contentDocument || objIframe.contentWindow.document;
            frameDoc.documentElement.innerHTML = "";

        }

        /*function MostrarModalInstitucion() {
            var objIframe = document.getElementById('iframe_bsc_institucion');
            limpiaiframe(objIframe);

            objIframe.src = "../mod_instituciones/bsc_institucion.aspx?param001=Plan de Intervencion&dir=../mod_ninos/pi_gestion.aspx";
            objIframe.height = "600px";
            objIframe.width = "900px";
            $find("mpe4a").show();
            return false;
        }*/
        function MostrarModalInstitucion2() {
            var objIframe = document.getElementById('iframe_bsc_eventos');
            limpiaiframe(objIframe);
            //var olbl001 = document.getElementById('lbl001');
            var oddown001 = document.getElementById('piiinter');
            var oddown002 = document.getElementById('pigrupo');

            objIframe.src = "eventos_intervencion.aspx?sw=1&param002=" + oddown001 + "&param003=" + oddown002 + "";
            //"../mod_instituciones/bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadoresproy.aspx" + "&codinst=" + ddown001.SelectedValue;
            objIframe.height = "600px";
            objIframe.width = "900px";
            $find("mpe4a").show();
            return false;
        }

        function clean() {
            //$("#ddown001").each(function () { this.selectedIndex = 0 });
            //$("#ddown002").each(function () { this.selectedIndex = 0 });
            $("#txt_name").val("");
            $("#txt_patern").val("");
            $("#txt_matern").val("");
            $("#ddown001").prop("disabled", false);
            $("#ddown002").prop("disabled", false);
            $("#txt_name").prop("disabled", false);
            $("#txt_patern").prop("disabled", false);
            $("#txt_matern").prop("disabled", false);
            $("#btnbuscar").show();
            $("#grd001").hide();
            $("#grd002").hide();
            $("#utab").hide();
            $("#titulo_tab").hide();
            $("#wib004").hide();

        }

        window.mostrarNotificacionVerde = function () {
            console.log("entro en la función mostrarNotificacionVerde");
            var x;
            x = $("#iframe_bsc_eventos").contents().find("#grd003 tr")[$("#iframe_bsc_eventos").contents().find("#rowSelected").val()];
            $(x).notify('Se ha creado este nuevo evento', { clickToHide: true, autoHide: true, autoHideDelay: 2000, arrowShow: true, arrowSize: 10, elementPosition: 'bottom center', style: 'bootstrap', className: 'success', showAnimation: 'slideDown', showDuration: 350, hideAnimation: 'slideUp', hideDuration: 350, gap: 5 });
            $(x)
              .delay(2000)
              .queue(function (next) {
                  $(this).css('background-color', 'white');
                  next();
              });

            //$('#iframe_bsc_eventos').contents().find('#grd003').notify('Hola', { clickToHide: true, autoHide: true, autoHideDelay: 4000, arrowShow: true, arrowSize: 10, elementPosition: 'bottom center', style: 'bootstrap', className: 'success', showAnimation: 'slideDown', showDuration: 350, hideAnimation: 'slideUp', hideDuration: 350, gap: 5 })
        }

        function cargaValorEvaluacionLogroPRM() {
            $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogro").click(function () {
                $("#rdo_EvaluacionLogroPRM_19").val(
                  $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogro").val()
                 );
            });
        }

        function cargaValorEvaluacionLogroPAD() {
            $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogroPAD").click(function () {
                $("#rdo_EvaluacionLogroPAD_120").val($("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogroPAD").val());
            });
        }

        function cargaValorEvaluacionLogroPPF() {
            $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogroPPF").click(function () {
                $("#rdo_evaluacionLogro_136").val($("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogroPPF").val());
            });
        }

        function cargaValorNNAEgresaporPIIPRM() {
            $("#DescripcionesIntervencionNNA_ctrl7_ddlNNAegresaporPIIPRM").click(function () {
                $("#rdo_DdlNNAEgresoporPIIPRM_14").val(
                    $("#DescripcionesIntervencionNNA_ctrl7_ddlNNAegresaporPIIPRM").val()
                );
            });
        }



        function cargaValorInterrumpeConductasPAS() {
            $("#DescripcionesIntervencionNNA_ctrl3_ddlNNAInterrumpeConductas").click(function () {
                $("#rdo_InterrumpeConductas_32").val($("#DescripcionesIntervencionNNA_ctrl3_ddlNNAInterrumpeConductas").val());
            });
        }

        function cargaValorNNAEgresaporPIIPAS() {
            $("#DescripcionesIntervencionNNA_ctrl7_ddlNNAEgresaporPIIPAS").click(function () {
                $("#rdo_DdlNNAEgresoporPIIPAS_36").val($("#DescripcionesIntervencionNNA_ctrl7_ddlNNAEgresaporPIIPAS").val());
            });
        }

        function cargaValorAdultosaCargoPAS() {
            $("#DescripcionesTrabajoConFamilia_ctrl5_ddlAdultoaCargo").click(function () {
                $("#rdo_adultoaCargo_42").val($("#DescripcionesTrabajoConFamilia_ctrl5_ddlAdultoaCargo").val());
            });
        }


        function cargaValorAdultosaCargoPEE() {
            $("#DescripcionesTrabajoConFamilia_ctrl4_ddlAdultoaCargoPEE").click(function () {
                $("#rdo_adultoaCargoPEE64").val($("#DescripcionesTrabajoConFamilia_ctrl4_ddlAdultoaCargoPEE").val());
            });
        }

        function cargaValorAdultosaCargoPEC() {
            $("#DescripcionesTrabajoConFamilia_ctrl4_ddlAdultoaCargoPEC").click(function () {
                $("#rdo_adultoaCargoPEE85").val($("#DescripcionesTrabajoConFamilia_ctrl4_ddlAdultoaCargoPEC").val());
            });
        }

        function cargaValorAdultosaCargoPPF() {
            $("#DescripcionesTrabajoConFamilia_ctrl3_ddlAdultoaCargoPPF").click(function () {
                $("#rdo_adultoaCargoPPF134").val($("#DescripcionesTrabajoConFamilia_ctrl3_ddlAdultoaCargoPPF").val());
            });
        }


        function cargaValorDisminucionSintomatologiaPAS() {
            $("#getDescripcionSintomatología_ctrl0_ddlSintomatologia").click(function () {
                $("#rdo_Sintomatologia_43").val($("#getDescripcionSintomatología_ctrl0_ddlSintomatologia").val());
            });
        }

        function cargaValorDisminucionSintomatologiaPPF() {
            $("#getDescripcionSintomatología_ctrl0_ddlSintomatologiaPPF").click(function () {
                $("#rdo_Sintomatologia_137").val($("#getDescripcionSintomatología_ctrl0_ddlSintomatologiaPPF").val());
            });
        }


        window.actualizarDescripciones = function () {
            $("#refrescarDescripciones").click();
        }

        function LoadScript() {

            //Interactividad entre radio buttons
            //PRM
            if ($("input[name^='rdo_PRM_1']:checked").val() == 1) {
                $("#div_PRM_2").slideUp(500);
                $("#div_rdo_PRM_2").slideUp(500);
            }

            $("#rdo_PRM_1_si").click(function () {
                $("#div_PRM_2").slideUp(500);
                $("#div_rdo_PRM_2").slideUp(500);
                $("#rdo_PRM_2_si").removeAttr("checked");
                $("#rdo_PRM_2_no").attr("checked");
            });

            $("#rdo_PRM_1_no").click(function () {
                $("#div_PRM_2").slideDown(599);
                $("#div_rdo_PRM_2").slideDown(500);
            });

            if ($("input[name^='rdo_PRM_5']:checked").val() == 1) {
                $("#div_PRM_6").slideUp(500);
                $("#div_rdo_PRM_6").slideUp(500);
            }

            $("#rdo_PRM_5_si").click(function () {
                $("#div_PRM_6").slideUp(500);
                $("#div_rdo_PRM_6").slideUp(500);
                $("#rdo_PRM_6_si").removeAttr("checked");
                $("#rdo_PRM_6_no").attr("checked");
            });

            $("#rdo_PRM_5_no").click(function () {
                $("#div_PRM_6").slideDown(599);
                $("#div_rdo_PRM_6").slideDown(500);
            });

            //PRM------------ END

            //PAS

            if ($("input[name^='rdo_PAS_20']:checked").val() == 1) {
                $("#div_PAS_21").slideUp(500);
                $("#div_rdo_PAS_21").slideUp(500);
            }

            $("#rdo_PAS_20_si").click(function () {
                $("#div_PAS_21").slideUp();
                $("#div_rdo_PAS_21").slideUp();
                $("#rdo_PAS_21_si").removeAttr("checked");
                $("#rdo_PAS_21_no").attr("checked");
            });

            $("#rdo_PAS_20_no").click(function () {
                $("#div_PAS_21").slideDown();
                $("#div_rdo_PAS_21").slideDown();
            });


            if ($("input[name^='rdo_PAS_22']:checked").val() == 1) {
                $("#div_PAS_23").slideUp(500);
                $("#div_rdo_PAS_23").slideUp(500);
            }

            $("#rdo_PAS_22_si").click(function () {
                $("#div_PAS_23").slideUp();
                $("#div_rdo_PAS_23").slideUp();
                $("#rdo_PAS_23_si").removeAttr("checked");
                $("#rdo_PAS_23_no").attr("checked");
            });

            $("#rdo_PAS_22_no").click(function () {
                $("#div_PAS_23").slideDown();
                $("#div_rdo_PAS_23").slideDown();
            });


            if ($("input[name^='rdo_PAS_26']:checked").val() == 1) {
                $("#div_PAS_25").slideUp(500);
                $("#div_rdo_PAS_25").slideUp(500);
            }

            $("#rdo_PAS_26_si").click(function () {
                $("#div_PAS_25").slideUp();
                $("#div_rdo_PAS_25").slideUp();
                $("#rdo_PAS_25_si").removeAttr("checked");
                $("#rdo_PAS_25_no").attr("checked");
            });

            $("#rdo_PAS_26_no").click(function () {
                $("#div_PAS_25").slideDown();
                $("#div_rdo_PAS_25").slideDown();
            });


            if ($("input[name^='rdo_PAS_27']:checked").val() == 1) {
                $("#div_PAS_28").slideUp(500);
                $("#div_rdo_PAS_28").slideUp(500);
            }

            $("#rdo_PAS_27_si").click(function () {
                $("#div_PAS_28").slideUp();
                $("#div_rdo_PAS_28").slideUp();
                $("#rdo_PAS_28_si").removeAttr("checked");
                $("#rdo_PAS_28_no").attr("checked");
            });

            $("#rdo_PAS_27_no").click(function () {
                $("#div_PAS_28").slideDown();
                $("#div_rdo_PAS_28").slideDown();
            });



            //PAS------------ END

            //PEE
            if ($("input[name^='rdo_PEE_44']:checked").val() == 1) {
                $("#div_PEE_45").slideUp(500);
                $("#div_rdo_PEE_45").slideUp(500);
            }

            $("#rdo_PEE_44_si").click(function () {
                $("#div_PEE_45").slideUp();
                $("#div_rdo_PEE_45").slideUp();
                $("#rdo_PEE_45_si").removeAttr("checked");
                $("#rdo_PEE_45_no").attr("checked");
            });

            $("#rdo_PEE_44_no").click(function () {
                $("#div_PEE_45").slideDown();
                $("#div_rdo_PEE_45").slideDown();
            });



            if ($("input[name^='rdo_PEE_53']:checked").val() == 1) {
                $("#div_PEE_54").slideUp(500);
                $("#div_rdo_PEE_54").slideUp(500);
            }

            $("#rdo_PEE_53_si").click(function () {
                $("#div_PEE_54").slideUp();
                $("#div_rdo_PEE_54").slideUp();
                $("#rdo_PEE_54_si").removeAttr("checked");
                $("#rdo_PEE_54_no").attr("checked");
            });

            $("#rdo_PEE_53_no").click(function () {
                $("#div_PEE_54").slideDown();
                $("#div_rdo_PEE_54").slideDown();
            });



            //PEC
            if ($("input[name^='rdo_PEC_65']:checked").val() == 1) {
                $("#div_PEC_66").slideUp(500);
                $("#div_rdo_PEC_66").slideUp(500);
            }

            $("#rdo_PEC_65_si").click(function () {
                $("#div_PEC_66").slideUp();
                $("#div_rdo_PEC_66").slideUp();
                $("#rdo_PEC_66_si").removeAttr("checked");
                $("#rdo_PEC_66_no").attr("checked");
            });

            $("#rdo_PEC_65_no").click(function () {
                $("#div_PEC_66").slideDown();
                $("#div_rdo_PEC_66").slideDown();
            });

            if ($("input[name^='rdo_PEC_73']:checked").val() == 1) {
                $("#div_PEC_74").slideUp(500);
                $("#div_rdo_PEC_74").slideUp(500);
            }

            $("#rdo_PEC_73_si").click(function () {
                $("#div_PEC_74").slideUp();
                $("#div_rdo_PEC_74").slideUp();
                $("#rdo_PEC_74_si").removeAttr("checked");
                $("#rdo_PEC_74_no").attr("checked");
            });

            $("#rdo_PEC_73_no").click(function () {
                $("#div_PEC_74").slideDown();
                $("#div_rdo_PEC_74").slideDown();
            });

            //PEE --------------- END

            ////PIE
            if ($("input[name^='rdo_PIE_86']:checked").val() == 1) {
                $("#div_PIE_87").slideUp(500);
                $("#div_rdo_PIE_87").slideUp(500);
            }

            $("#rdo_PIE_86_si").click(function () {
                $("#div_PIE_87").slideUp();
                $("#div_rdo_PIE_87").slideUp();
                $("#rdo_PIE_87_si").removeAttr("checked");
                $("#rdo_PIE_87_no").attr("checked");
            });

            $("#rdo_PIE_86_no").click(function () {
                $("#div_PIE_87").slideDown();
                $("#div_rdo_PIE_87").slideDown();
            });


            if ($("input[name^='rdo_PIE_94']:checked").val() == 1) {
                $("#div_PIE_95").slideUp(500);
                $("#div_rdo_PIE_95").slideUp(500);
            }

            $("#rdo_PIE_94_si").click(function () {
                $("#div_PIE_95").slideUp();
                $("#div_rdo_PIE_95").slideUp();
                $("#rdo_PIE_95_si").removeAttr("checked");
                $("#rdo_PIE_95_no").attr("checked");
            });

            $("#rdo_PIE_94_no").click(function () {
                $("#div_PIE_95").slideDown();
                $("#div_rdo_PIE_95").slideDown();
            });
            //PIE ----- END


            //PAD

            if ($("input[name^='rdo_PAD_106']:checked").val() == 1) {
                $("#div_PAD_107").slideUp(500);
                $("#div_rdo_PAD_107").slideUp(500);
            }

            $("#rdo_PAD_106_si").click(function () {
                $("#div_PAD_107").slideUp();
                $("#div_rdo_PAD_107").slideUp();
                $("#rdo_PAD_107_si").removeAttr("checked");
                $("#rdo_PAD_107_no").attr("checked");
            });

            $("#rdo_PAD_106_no").click(function () {
                $("#div_PAD_107").slideDown();
                $("#div_rdo_PAD_107").slideDown();
            });

            if ($("input[name^='rdo_PAD_110']:checked").val() == 1) {
                $("#div_PAD_111").slideUp(500);
                $("#div_rdo_PAD_111").slideUp(500);
            }

            $("#rdo_PAD_110_si").click(function () {
                $("#div_PAD_111").slideUp();
                $("#div_rdo_PAD_111").slideUp();
                $("#rdo_PAD_111_si").removeAttr("checked");
                $("#rdo_PAD_111_no").attr("checked");
            });

            $("#rdo_PAD_110_no").click(function () {
                $("#div_PAD_111").slideDown(500);
                $("#div_rdo_PAD_111").slideDown(500);
            });

            //PAD -------- END

            //PPF

            if ($("input[name^='rdo_PPF_121']:checked").val() == 1) {
                $("#div_PPF_122").slideUp(500);
                $("#div_rdo_PPF_122").slideUp(500);
            }

            $("#rdo_PPF_121_no").click(function () {
                $("#div_PPF_122").slideDown();
                $("#div_rdo_PPF_122").slideDown();
            });

            $("#rdo_PPF_121_si").click(function () {
                $("#div_PPF_122").slideUp();
                $("#div_rdo_PPF_122").slideUp();
                $("#rdo_PPF_122_si").removeAttr("checked");
                $("#rdo_PPF_122_no").attr("checked");
            });



            if ($("input[name^='rdo_PPF_123']:checked").val() == 1) {
                $("#div_PPF_124").slideUp(500);
                $("#div_rdo_PPF_124").slideUp(500);
            }

            $("#rdo_PPF_123_no").click(function () {
                $("#div_PPF_124").slideDown();
                $("#div_rdo_PPF_124").slideDown();
            });

            $("#rdo_PPF_123_si").click(function () {
                $("#div_PPF_124").slideUp();
                $("#div_rdo_PPF_124").slideUp();
                $("#rdo_PPF_124_si").removeAttr("checked");
                $("#rdo_PPF_124_no").attr("checked");
            });

            //PPF -------- END

            //FAE

            if ($("input[name^='rdo_FAE_157']:checked").val() == 1) {
                $("#div_FAE_158").slideUp(500);
                $("#div_rdo_FAE_158").slideUp(500);
            }

            $("#rdo_FAE_157_no").click(function () {
                $("#div_FAE_158").slideDown();
                $("#div_rdo_FAE_158").slideDown();
            });

            $("#rdo_FAE_157_si").click(function () {
                $("#div_FAE_158").slideUp();
                $("#div_rdo_FAE_158").slideUp();
                $("#rdo_FAE_158_si").removeAttr("checked");
                $("#rdo_FAE_158_no").attr("checked");
            });

            //FAE --------- END

            // PRO

            if ($("input[name^='rdo_PRO_140']:checked").val() == 1) {
                $("#div_PRO_141").slideUp(500);
                $("#div_rdo_PRO_141").slideUp(500);
            }

            $("#rdo_PRO_140_no").click(function () {
                $("#div_PRO_141").slideDown();
                $("#div_rdo_PRO_141").slideDown();
            });

            $("#rdo_PRO_140_si").click(function () {
                $("#div_PRO_141").slideUp();
                $("#div_rdo_PRO_141").slideUp();
                $("#rdo_PRO_141_si").removeAttr("checked");
                $("#rdo_PRO_141_no").attr("checked");
            });

            // PRO ------------- END

            //CTL
            if ($("input[name^='rdo_CTL_207']:checked").val() == 1) {
                $("#div_CTL_208").slideUp(500);
                $("#div_rdo_CTL_208").slideUp(500);
            }

            $("#rdo_CTL_207_no").click(function () {
                $("#div_CTL_208").slideDown();
                $("#div_rdo_CTL_208").slideDown();
            });

            $("#rdo_CTL_207_si").click(function () {
                $("#div_CTL_208").slideUp();
                $("#div_rdo_CTL_208").slideUp();
                $("#rdo_CTL_208_si").removeAttr("checked");
                $("#rdo_CTL_208_no").attr("checked");   
            });


            //CTD
            if ($("input[name^='rdo_CTD_207']:checked").val() == 1) {
                $("#div_CTD_208").slideUp(500);
                $("#div_rdo_CTD_208").slideUp(500);
            }

            $("#rdo_CTD_207_no").click(function () {
                $("#div_CTD_208").slideDown();
                $("#div_rdo_CTD_208").slideDown();
            });

            $("#rdo_CTD_207_si").click(function () {
                $("#div_CTD_208").slideUp();
                $("#div_rdo_CTD_208").slideUp();
                $("#rdo_CTD_208_si").removeAttr("checked");
                $("#rdo_CTD_208_no").attr("checked");
            });

            //CIP
            if ($("input[name^='rdo_CIP_207']:checked").val() == 1) {
                $("#div_CIP_208").slideUp(500);
                $("#div_rdo_CIP_208").slideUp(500);
            }

            $("#rdo_CIP_207_no").click(function () {
                $("#div_CIP_208").slideDown();
                $("#div_rdo_CIP_208").slideDown();
            });

            $("#rdo_CIP_207_si").click(function () {
                $("#div_CIP_208").slideUp();
                $("#div_rdo_CIP_208").slideUp();
                $("#rdo_CIP_208_si").removeAttr("checked");
                $("#rdo_CIP_208_no").attr("checked");
            });

            //CSC
            if ($("input[name^='rdo_CSC_207']:checked").val() == 1) {
                $("#div_CSC_208").slideUp(500);
                $("#div_rdo_CSC_208").slideUp(500);
            }

            $("#rdo_CSC_207_no").click(function () {
                $("#div_CSC_208").slideDown();
                $("#div_rdo_CSC_208").slideDown();
            });

            $("#rdo_CSC_207_si").click(function () {
                $("#div_CSC_208").slideUp();
                $("#div_rdo_CSC_208").slideUp();
                $("#rdo_CSC_208_si").removeAttr("checked");
                $("#rdo_CSC_208_no").attr("checked");
            });

            //CRC
            if ($("input[name^='rdo_CRC_207']:checked").val() == 1) {
                $("#div_CRC_208").slideUp(500);
                $("#div_rdo_CRC_208").slideUp(500);
            }

            $("#rdo_CRC_207_no").click(function () {
                $("#div_CRC_208").slideDown();
                $("#div_rdo_CRC_208").slideDown();
            });

            $("#rdo_CRC_207_si").click(function () {
                $("#div_CRC_208").slideUp();
                $("#div_rdo_CRC_208").slideUp();
                $("#rdo_CRC_208_si").removeAttr("checked");
                $("#rdo_CRC_208_no").attr("checked");
            });

            //FAS
            if ($("input[name^='rdo_FAS_216']:checked").val() == 1) {
                $("#div_FAS_217").slideUp(500);
                $("#div_rdo_FAS_217").slideUp(500);
            }

            $("#rdo_FAS_216_no").click(function () {
                $("#div_FAS_217").slideDown();
                $("#div_rdo_FAS_217").slideDown();
            });
            
            $("#rdo_FAS_216_si").click(function () {
                $("#div_FAS_217").slideUp();
                $("#div_rdo_FAS_217").slideUp();
                $("#rdo_FAS_217_si").removeAttr("checked");
                $("#rdo_FAS_217_no").attr("checked");
            });

            //Interactividad de Dropdowns

            //PRM
            if ($("#rdo_DdlNNAEgresoporPIIPRM_14").val() > 0) {
                $("#DescripcionesIntervencionNNA_ctrl7_ddlNNAegresaporPIIPRM").val($("#rdo_DdlNNAEgresoporPIIPRM_14").val());
            }

            if ($("#rdo_EvaluacionLogroPRM_19").val() > 0) {
                $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogro").val($("#rdo_EvaluacionLogroPRM_19").val());
            }

            //PAS
            if ($("#rdo_InterrumpeConductas_32").val() > 0) {
                $("#DescripcionesIntervencionNNA_ctrl3_ddlNNAInterrumpeConductas").val($("#rdo_InterrumpeConductas_32").val());
            }

            if ($("#rdo_DdlNNAEgresoporPIIPAS_36").val() > 0) {
                $("#DescripcionesIntervencionNNA_ctrl7_ddlNNAEgresaporPIIPAS").val($("#rdo_DdlNNAEgresoporPIIPAS_36").val());
            }

            if ($("#rdo_adultoaCargo_42").val() > 0) {
                $("#DescripcionesTrabajoConFamilia_ctrl5_ddlAdultoaCargo").val($("#rdo_adultoaCargo_42").val());
            }

            if ($("#rdo_Sintomatologia_43").val() > 0) {
                $("#getDescripcionSintomatología_ctrl0_ddlSintomatologia").val($("#rdo_Sintomatologia_43").val());
            }

            //PEE
            if ($("#rdo_adultoaCargoPEE64").val() > 0) {
                $("#DescripcionesTrabajoConFamilia_ctrl4_ddlAdultoaCargoPEE").val($("#rdo_adultoaCargoPEE64").val());
            }

            //PEC
            if ($("#rdo_adultoaCargoPEE85").val() > 0) {
                $("#DescripcionesTrabajoConFamilia_ctrl4_ddlAdultoaCargoPEC").val($("#rdo_adultoaCargoPEE85").val());
            }

            //PAD
            if ($("#rdo_EvaluacionLogroPAD_120").val() > 0) {
                $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogroPAD").val($("#rdo_EvaluacionLogroPAD_120").val());
            }

            //PPF

            if ($("#rdo_adultoaCargoPPF134").val() > 0) {
                $("#DescripcionesTrabajoConFamilia_ctrl3_ddlAdultoaCargoPPF").val($("#rdo_adultoaCargoPPF134").val());
            }

            if ($("#rdo_evaluacionLogro_136").val() > 0) {
                $("#DescripcionesEvaluacionDelLogro_ctrl0_ddlEvaluacionLogroPPF").val($("#rdo_evaluacionLogro_136").val());
            }

            if ($("#rdo_Sintomatologia_137").val() > 0) {
                $("#getDescripcionSintomatología_ctrl0_ddlSintomatologiaPPF").val($("#rdo_Sintomatologia_137").val());
            }


           

            //--------------- Interactividad de dropdowns END


            //$("#link_tab5").click(function () {
            //    $("#SeguimientoPII").click();
            //})
        }


    </script>
</head>
<body onmousemove="SetProgressPosition(event)">
    <style type="text/css">
        .esconder {
            display: none;
        }
    </style>
    <!-- Fixed navbar -->
    <form id="form1" runat="server">
        <uc1:menu_colgante runat="server" ID="menu_colgante" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="wib002" />
                <asp:PostBackTrigger ControlID="wib004" />
            </Triggers>
            <ContentTemplate>
                <script type="text/javascript">
                    Sys.Application.add_load(LoadScript);
                </script>
                <ajax:ModalPopupExtender
                    ID="mpe1"
                    BehaviorID="mpe1a"
                    runat="server"
                    TargetControlID="LinkButton1"
                    PopupControlID="modal_buscar"
                    CancelControlID="bt_cerrar_buscar"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground">
                </ajax:ModalPopupExtender>
                <ajax:ModalPopupExtender ID="mpe4a" BehaviorID="mpe4a" runat="server"
                    TargetControlID="wib004"
                    PopupControlID="modal_bsc_eventos"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal4">
                </ajax:ModalPopupExtender>
                <ajax:ModalPopupExtender ID="mpe2a" BehaviorID="mpe2a" runat="server"
                    TargetControlID="imb_lupa_modal"
                    PopupControlID="modal_bsc_institucion"
                    DropShadow="true"
                    BackgroundCssClass="modalBackground"
                    CancelControlID="btnCerrarModal2">
                </ajax:ModalPopupExtender>
                <div class="container theme-showcase" role="main">
                    <ol class="breadcrumb">
                        <li><a href="../index.aspx">Inicio</a></li>
                        <li class="active">Niños</li>
                        <li class="active">Gestión plan de Intervención</li>
                    </ol>
                    <div class="alert alert-warning text-center" role="alert" id="alerts" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-warning-sign"></span>
                        <asp:Label ID="lbl005" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>
                    <div class="alert alert-success text-center" role="alert" id="alerts2" runat="server" style="margin-top: 10px; display: none">
                        <span class="glyphicon glyphicon-ok"></span>
                        <asp:Label ID="lbl0052" runat="server" Text="Asistencia Confirmada" Style="display: none"></asp:Label>
                    </div>

                    <div class="well">
                        <h4 class="subtitulo-form">Gestión Plan de Intervención</h4>
                        <div class="popupConfirmation" id="modal_bsc_institucion" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="btnCerrarModal2" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                    <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">INSTITUCION</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_institucion" runat="server"></iframe>
                            </div>
                        </div>
                        <div class="popupConfirmation" id="modal_bsc_eventos" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="btnCerrarModal4" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                    <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">EVENTOS DE INTERVENCION</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_eventos" runat="server"></iframe>
                            </div>
                        </div>
                        <div class="popupConfirmation" id="modal_buscar" style="display: none">
                            <div class="modal-header header-modal">
                                <asp:LinkButton CssClass="close" ID="bt_cerrar_buscar" aria-label="Close" runat="server" Text="Cerrar" CausesValidation="false">
                                       <span aria-hidden="true">&times;</span>
                                </asp:LinkButton>
                                <h4 class="modal-title">PROYECTO</h4>
                            </div>
                            <div>
                                <iframe id="iframe_bsc_proyecto" runat="server" frameborder="0"></iframe>
                            </div>
                        </div>
                        <hr>

                        <a id="collapse" data-toggle="collapse" data-parent="#accordion" href="#collapse_Form" aria-expanded="true" aria-controls="collapse_Form">
                            <asp:Label ID="lbl_acordeon" runat="server" Visible="true" Text="Ocultar Detalles de la Búsqueda"></asp:Label>
                            <span id="icon-collapse" class="glyphicon glyphicon-triangle-top"></span>
                            <asp:Label ID="lbl_resumen_filtro" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="lbl_resumen_proyecto" runat="server" Visible="false"></asp:Label>
                        </a>

                        <div id="collapse_Form" runat="server" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                            <div class="row">
                                <div class="col-md-9">
                                    <table class="table table-borderless table-condensed table-col-fix">

                                        <tr>
                                            <th>
                                                <label for="">
                                                    Institución:</label>
                                            </th>
                                            <td>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddown001" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="ddown001_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="imb_lupa_modal" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalInstitucion('Plan de Intervencion','../mod_ninos/pi_gestion.aspx','mpe2a')" CausesValidation="False">
                                        	    <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Proyecto:</label>
                                            </th>
                                            <td>

                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddown002" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddown002_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Value="0"> Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="input-group-addon btn btn-info btn-sm" OnClientClick="return MostrarModalProyecto('Busca Proyectos', '../mod_ninos/pi_gestion.aspx','mpe1a')" CausesValidation="False">
                                                              <span class="glyphicon glyphicon-question-sign"></span>
                                                    </asp:LinkButton>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Nombre del Niño(a):</label>
                                            </th>
                                            <td colspan="2">
                                                <asp:TextBox ID="txt_name" runat="server" CssClass="form-control input-sm form-control-60" placeholder="Ingresar nombre"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Apellido Paterno:</label>
                                            </th>
                                            <td colspan="2">
                                                <asp:TextBox ID="txt_patern" runat="server" CssClass="form-control input-sm form-control-60" placeholder="Ingresar Apellido"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                <label for="">
                                                    Apellido Materno:</label>
                                            </th>
                                            <td colspan="2">
                                                <asp:TextBox ID="txt_matern" runat="server" CssClass="form-control input-sm form-control-60" placeholder="Ingresar Apellido" type="text"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr_fecha_nacimiento" runat="server" visible="false">
                                            <th>
                                                <label for="">
                                                    Fecha de nacimiento:</label>
                                            </th>
                                            <td colspan="2">
                                                <asp:TextBox ID="lbl004" runat="server" placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha input-sm" Enabled="false"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="lbl004" ValidChars="0123456789-/" />
                                            </td>
                                        </tr>
                                        <tr id="tr_fecha_ingreso" runat="server" visible="false">
                                            <th>
                                                <label for="">
                                                    Fecha de ingreso:</label>
                                            </th>
                                            <td colspan="2">
                                                <asp:TextBox ID="lbl003" runat="server" placeholder="dd-mm-aaaa" CssClass="form-control form-control-fecha input-sm" Enabled="false"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="fte1" runat="server" TargetControlID="lbl003" ValidChars="0123456789-/" />
                                            </td>
                                        </tr>
                                    </table>
                                    <!--gfontbrevis nuevo estandar de botones -->
                                    <table class="table table-borderless table-condensed table-col-fix">
                                        <tr>
                                            <th></th>
                                            <td>
                                                <asp:LinkButton ID="btnbuscar" runat="server" CssClass="btn btn-danger btn-sm fixed-width-button" OnClick="btnbuscar_Click" Text="Buscar" AutoPostback="true">
                                    <span class="glyphicon glyphicon-zoom-in"></span>&nbsp;Buscar
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="wib002" runat="server" CssClass="btn btn-info btn-sm fixed-width-button pull-right" OnClick="wib002_Click" Text="Limpiar" OnClientClick="clean()">
                                    <span class="glyphicon glyphicon-remove-sign"></span>&nbsp;Limpiar
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
                                            <asp:Label ID="lbl001F2" CssClass="subtitulo-form-info" runat="server" Text="El Tiempo de Carga de la información dependerá de la cantidad de registros."></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:Label ID="lbl001_aviso" runat="server" CssClass="help-block" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <%--<div id="tableHeader1" class="fixed-header"></div>
                         <div id="tableContainer1" class="fixed-header-table-container">--%>

                                <asp:GridView ID="grd001" CssClass="table table-bordered table-hover" Visible="false" runat="server" data-name="grd001" AutoGenerateColumns="False" OnPageIndexChanging="grd001_PageIndexChanging" OnRowCommand="grd001_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="CodPlanIntervencion" HeaderText="Cod. Plan Interv."></asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Estado Interv." Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="CodProyecto" HeaderText="Cod. Proyecto"></asp:BoundField>
                                        <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre Proyecto" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="CodNino" HeaderText="Cod. Niño"></asp:BoundField>
                                        <asp:BoundField DataField="Rut" HeaderText="RUN" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="Apellido_Paterno" HeaderText="Apellido Paterno" />
                                        <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno" />
                                        <%--<asp:BoundField DataField="Apellidos_Nino" HeaderText="Apellidos NI&#209;O">                                                
                                            </asp:BoundField>--%>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                        <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="Fecha Ingreso" HeaderStyle-CssClass="esconder" ItemStyle-CssClass="esconder"></asp:BoundField>
                                        <asp:BoundField DataField="NombreTrabajador" HeaderText="Técnico" Visible="False"></asp:BoundField>
                                        <%--<asp:BoundField DataField="Apellidos_Tecnico" HeaderText="Apellidos T&#233;cnico" Visible="False">                                                
                                            </asp:BoundField>--%>
                                        <asp:BoundField DataField="FechaInicioPII" DataFormatString="{0:d}" HeaderText="Fecha Inicio PII"></asp:BoundField>
                                        <asp:BoundField DataField="FechaTerminoRealPII" HeaderText="Fecha Término" DataFormatString="{0:d}" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="CodGradoCumplimiento" HeaderText="Cod. Grado Cump." Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="CodGrupo" HeaderText="Cod. Grupo" Visible="False"></asp:BoundField>
                                        <asp:ButtonField Text="Seleccionar" CommandName="SELECCIONAR" HeaderText="Seleccionar"></asp:ButtonField>
                                    </Columns>
                                    <HeaderStyle CssClass="Rut titulo-tabla" />
                                    <%--<FooterStyle CssClass="titulo-tabla" ForeColor="White" />--%>
                                    <%--<HeaderStyle CssClass="titulo-tabla table-borderless" />--%>
                                    <%--<PagerStyle CssClass="pager-tabla" ForeColor="White" />--%>
                                    <%--<RowStyle CssClass="table-bordered caja-tabla" />--%>
                                    <RowStyle CssClass="rut text-center" />
                                </asp:GridView>
                            </div>
                            <table>
                                <tr id="tr1" runat="server">
                                    <td colspan="2"></td>
                                </tr>
                            </table>
                            <asp:GridView ID="grd002" CssClass="table table table-bordered table-hover " runat="server" AutoGenerateColumns="False" CellPadding="2" Visible="false"
                                GridLines="None" Width="100%" Height="1px">
                                <Columns>
                                    <asp:BoundField DataField="CodPlanIntervencion" HeaderText="Cod. Plan Intervención"></asp:BoundField>
                                    <asp:BoundField DataField="CodNino" HeaderText="Cod. Niño"></asp:BoundField>
                                    <asp:BoundField DataField="ICodIE" HeaderText="ICodIE"></asp:BoundField>
                                    <asp:BoundField DataField="Rut" HeaderText="RUN"></asp:BoundField>
                                    <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                    <asp:BoundField DataField="Apellido_Materno" HeaderText="Apellido Materno"></asp:BoundField>
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                    <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                                    <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="Fecha de Nacimiento" HtmlEncode="False"></asp:BoundField>
                                    <asp:BoundField DataField="FechaIngreso" DataFormatString="{0:d}" HeaderText="Fecha de Ingreso" HtmlEncode="False"></asp:BoundField>


                                </Columns>
                                <FooterStyle CssClass="titulo-tabla" ForeColor="White" />
                                <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                <PagerStyle CssClass="pager-tabla" ForeColor="White" />
                                <RowStyle CssClass="table-bordered caja-tabla" />
                            </asp:GridView>
                            <table class="table table-borderless table-condensed">
                                <tr>
                                    <td colspan="2">
                                        <div>
                                            <asp:LinkButton ID="wib004" runat="server" CssClass="btn btn-info btn-sm  pull-right" Visible="false" OnClientClick="return MostrarModalInstitucion2()" CausesValidation="False">
                                  <span class="glyphicon glyphicon-question-sign"></span>&nbsp;Eventos de Intervención

                                            </asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trmenu" runat="server" visible="false">
                                    <td colspan="2">
                                        <div class="col-md-3" style="text-align: center">
                                            <%--<a id="A4" runat="server"  Class="ifancybox">
                                                <asp:Button ID="wib004" runat="server" CssClass="btn btn-info btn-sm btn-margen" text= "Eventos de Intervención" Visible="false" OnClick="wib004_Click" CausesValidation="False"></asp:Button></a>                                                --%>
                                        </div>
                                    </td>
                                </tr>
                            </table>


                            <br />


                            <asp:HiddenField runat="server" ID="CurrentPage" />
                            <asp:HiddenField runat="server" ID="piiinter" />
                            <asp:HiddenField runat="server" ID="pigrupo" />
                            <div>

                                <h4>
                                    <asp:Label ID="titulo_tab" class="subtitulo-form" Text="Datos del Niño en el Proyecto" runat="server" Visible="false" />
                                    <asp:Label ID="consolaErrores" runat="server" Text=""></asp:Label></h4>

                                <asp:Panel ID="utab" runat="server" Visible="false">
                                    <!-- Titulos Tabs FUO -->
                                    <div>
                                        <ul id="myTabs" class="nav nav-tabs tab-fixed-height nav-justified" role="tablist">
                                            <li id="li_nav1" runat="server" role="presentation" class="active">
                                                <a id="link_tab1" runat="server" href="#tab1" aria-controls="tab1" role="tab" data-toggle="tab">DATOS PLAN DE INTERVENCION</a>
                                            </li>
                                            <li id="li_nav2" runat="server" role="presentation">
                                                <a id="link_tab2" runat="server" href="#tab2" aria-controls="tab2" role="tab" data-toggle="tab">AREA DE
                                                        INTERVENCION</a>
                                            </li>
                                            <li id="li_nav3" runat="server" role="presentation">
                                                <a id="link_tab3" runat="server" href="#tab3" aria-controls="tab3" role="tab" data-toggle="tab">SEGUIMIENTO DE
                                                        INTERVENCION</a>
                                            </li>
                                            <li id="li_nav4" runat="server" role="presentation">
                                                <a id="link_tab4" runat="server" href="#tab4" aria-controls="tab4" role="tab" data-toggle="tab">CON QUIEN PUEDE
                                                        TRABAJAR EL EGRESO</a>
                                            </li>
                                            <li id="li_nav5" runat="server" role="presentation">
                                                <a id="link_tab5" runat="server" href="#tab5" aria-controls="tab5" role="tab" data-toggle="tab">TERMINO DE LA
                                                        INTERVENCION</a>
                                            </li>
                                        </ul>
                                    </div>
                                    <!-- Contenidos Tabs FUO -->
                                    <div class="tab-content">
                                        <!-- Tab 1 Datos Plan de Intervencion -->
                                        <div role="tabpanel" class="tab-pane fade in active" id="tab1" runat="server">

                                            <asp:Panel ID="pnl_utab1" runat="server" Visible="true">

                                                <div class="subtitulo-form">
                                                    <h4>Datos del Plan de Intervencion</h4>
                                                </div>

                                                <table id="tbl_Datos_Plan_Intervencion" class="table table-bordered table-condensed tabla-tabs" runat="server">
                                                    <tr>
                                                        <th class="titulo-tabla col-md-1" scope="row">Fecha Elaboración PII *</th>
                                                        <td class="col-md-4">
                                                            <asp:TextBox ID="txt_fep" onkeypress="return false;" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa" Enabled="False"></asp:TextBox>
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender3" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fep" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                        </td>
                                                        <th class="titulo-tabla col-md-1" scope="row">Fecha Inicio PII *</th>
                                                        <td>
                                                            <asp:TextBox ID="txt_fip" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" onkeypress="return false;" runat="server" placeholder="dd-mm-aaaa" AutoPostBack="true"></asp:TextBox>
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender1" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txt_fip" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_fip" ValidChars="0123456789-/" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla" scope="row">Fecha de Término estimada de PII *</th>
                                                        <td>
                                                            <asp:TextBox ID="txt_ftp" onkeypress="return false;" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                            <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="CalendarExtender2" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txt_ftp" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_ftp" ValidChars="0123456789-/" />
                                                        </td>
                                                        <th class="titulo-tabla" scope="row">Técnico *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddl_tecnico" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_tecnico_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla" scope="row">Descripción</th>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txt_dsc" CssClass="form-control input-sm " runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <div class=" pull-right">
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btnOrdenesTribunal" runat="server" OnClick="lbtActualizar_Click">
                                                               <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                                                </asp:LinkButton>
                                                            </div>


                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <!-- Tab 2 Area de Intervención -->
                                        <div role="tabpanel" class="tab-pane fade" id="tab2" runat="server">
                                            <asp:Panel ID="pnl_utab2" runat="server" Visible="true">
                                                <div class="subtitulo-form">
                                                    <h4>Ingrese Area de Intervención  (Máximo 6)</h4>
                                                </div>



                                                <div class="table-condensed">
                                                    <asp:GridView ID="grdv_adp" CssClass="table  table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grdv_adp_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="TipoIntervencion" HeaderText="Tipo Intervenci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="NivelIntervencion" HeaderText="Nivel de Intervenci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="CodNivelIntervencion" HeaderText="CodNivelIntervenci&#243;n" />
                                                            <asp:ButtonField CommandName="Eliminar" Text="Eliminar" HeaderText="Seleccionar"></asp:ButtonField>
                                                            <asp:BoundField DataField="IdGrupoIntervenciones">
                                                                <ItemStyle BackColor="Transparent" BorderColor="Transparent" Font-Size="1px" ForeColor="Transparent" Width="1px" />
                                                                <HeaderStyle BackColor="Transparent" BorderColor="Transparent" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <RowStyle CssClass="table-bordered caja-tabla" />
                                                    </asp:GridView>
                                                </div>
                                                <table id="tbl_Area_de_intervencion" class="table table-bordered tabla-tabs table-condensed" runat="server">
                                                    <tr>
                                                        <th class="titulo-tabla col-md-1" scope="row">Tipo de Intervención *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddl_tti" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_tti_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla" scope="row">Nivel de Intervención *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddl_ndi" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_ndi_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div class="pull-right">
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="btn_add" runat="server" OnClick="btn_add_Click">
                                                    <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar
                                                                </asp:LinkButton>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                </table>


                                            </asp:Panel>


                                        </div>

                                        <asp:SqlDataSource ID="getDescripcionesNivelIntervencion" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getDescripcionesImplementacionMedida" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getDescripcionesIntervencionNNA" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getDescripcionesTrabajoConFamilia" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getDescripcionesEvaluacionDelLogro" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getDescripcionesSintomatologia" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getDescripcionesTrabajoGarantesDerecho" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="getDescripcionesGestionRedes24Horas" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="Codseguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="getDescripcionesPsicosocial" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="Codseguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="getDescripcionesRedes" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="Codseguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="getDescripcionesCapacitacion" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="getDescripcionesPII" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="CodPlanIntervencion" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        

                                        <asp:SqlDataSource ID="getPonderacionesNNAEgresoporPII" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesNNAEgresoporPIIPAS" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesEvaluaciondelLogro" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesEvaluaciondelLogroPAD" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesEvaluaciondelLogroPPF" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesSintomatologia" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesSintomatologiaPPF" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionesInterrumpeConductas" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionAdultosaCargo" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionAdultosaCargoPEE" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionAdultosaCargoPEC" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>

                                        <asp:SqlDataSource ID="getPonderacionAdultosaCargoPPF" runat="server" ConnectionString="<%$ ConnectionStrings:Conexiones %>" SelectCommand="get_PonderacionResultados" SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:Parameter Name="CodModelo" Type="Int32" />
                                                <asp:Parameter Name="CodSeguimiento" Type="Int32" />
                                                <asp:Parameter Name="iCodparResultado" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>


                                        <!-- Tab 3 Seguimiento del Plan de Intervención -->
                                        <div role="tabpanel" class="tab-pane fade" id="tab3" runat="server">
                                            <asp:Panel ID="pnl_utab3" runat="server" Visible="true">
                                                <div class="subtitulo-form"></div>





                                                <div class="table-condensed">

                                                    <asp:GridView ID="ggdv_pdi" CssClass="table table-bordered table-hover " runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="ggdv_pdi_PageIndexChanging" PagerSettings-PageButtonCount="8">
                                                        <Columns>
                                                            <asp:BoundField DataField="FechaCreacion" DataFormatString="{0:d}" HeaderText="Fecha Creacion" HtmlEncode="False"></asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n"></asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                                    </asp:GridView>
                                                </div>

                                                <table id="Table1" class="table table-bordered  table-condensed tabla-tabs" runat="server">
                                                    <tr>
                                                        <th class="titulo-tabla col-md-1" scope="row">Estado de Intervención *</th>
                                                        <td class="col-md-4">
                                                            <asp:DropDownList ID="ddl_edi" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_edi_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <th class="titulo-tabla col-md-1" scope="row">Colaboración Niño(a)</th>
                                                        <td>
                                                            <div class="text-center">
                                                                <asp:RadioButton ID="rb_colaboracion_nino_si" runat="server" GroupName="rcn" Text="Si" Visible="True" Enabled="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:RadioButton ID="rb_colaboracion_nino_no" runat="server" GroupName="rcn" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                            </div>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th class="titulo-tabla" scope="row">Participación Familia</th>
                                                        <td>
                                                            <div class="text-center">
                                                                <asp:RadioButton ID="rb_colaboracion_familia_si" runat="server" GroupName="rcf" Text="Si" Visible="True" Enabled="true" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:RadioButton ID="rb_colaboracion_familia_no" runat="server" GroupName="rcf" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                            </div>
                                                        </td>
                                                        <th class="titulo-tabla" scope="row">Observaciones</th>
                                                        <td>
                                                            <asp:TextBox ID="txt_obvs" CssClass="form-control input-sm" runat="server" TextMode="MultiLine" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <div class="pull-right">
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lbtActualizar" runat="server" OnClick="lbtActualizar3_Click">
                                                                <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar
                                                                </asp:LinkButton>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                </table>

                                            </asp:Panel>
                                        </div>
                                        <!-- Tab 4 Con Quien Puede Trabajar el Egreso -->
                                        <div role="tabpanel" class="tab-pane fade" id="tab4" runat="server">
                                            <asp:Panel ID="pnl_utab4" runat="server" Visible="true">
                                                <div class="subtitulo-form"></div>
                                                <div class="table-condensed">
                                                    <asp:GridView ID="grdv_prelac" CssClass="table  table-bordered table-hover " runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnRowCommand="grdv_prelac_RowCommand">
                                                        <Columns>
                                                            <asp:BoundField DataField="nombre" HeaderText="Nombre"></asp:BoundField>
                                                            <asp:BoundField DataField="Descripcion" HeaderText="Tipo de Relaci&#243;n"></asp:BoundField>
                                                            <asp:BoundField DataField="ICodTrabajaEgreso" HeaderText="Cod Trabaja Egreso"></asp:BoundField>
                                                            <asp:ButtonField CommandName="Cambiar" Text="Cambiar"></asp:ButtonField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla table-borderless" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                        <RowStyle CssClass="caja-tabla table-bordered" />
                                                    </asp:GridView>
                                                </div>
                                                <div class="table-condensed">
                                                    <asp:GridView ID="grdv_pplr" CssClass="table  table-bordered table-hover caja-tabla" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombre"></asp:BoundField>
                                                            <asp:BoundField DataField="descripcion" HeaderText="Tipo de Relaci&#243;n"></asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="titulo-tabla" />
                                                        <PagerStyle CssClass="titulo-tabla" ForeColor="White" />
                                                    </asp:GridView>
                                                </div>
                                                <table id="Table2" class="table table-bordered  table-condensed tabla-tabs " runat="server">
                                                    <tr>
                                                        <th class="titulo-tabla col-md-1" scope="row">Persona Relacionada *</th>
                                                        <td>
                                                            <asp:DropDownList ID="ddl_pplr" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_pplr_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div class="pull-right">
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lbtn_addpplr" runat="server" OnClick="lbtn_addpplr_Click">
                                                            <span class="glyphicon glyphicon-ok"></span>&nbsp;Agregar
                                                                </asp:LinkButton>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                        <!-- Tab 5 Termino de la Intervención -->
                                        <div role="tabpanel" class="tab-pane fade" id="tab5" runat="server">
                                            <asp:Panel ID="pnl_utab5" runat="server" Visible="true">
                                                <div class="subtitulo-form"></div>
                                                <asp:UpdatePanel runat="server" ID="updateDescripcionesPII" Visible="true" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="container">
                                                            <div class="col-md-6">
                                                                  <%-- 9 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesNivelIntervencionPsicosocial" DataKeyNames="Resultado" DataSourceID="getDescripcionesPsicosocial" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label1" CssClass="titulo-form" Text="Nivel de Intervención Psicosocial" runat="server" />   
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <input class="radio-inline"
                                                                                    id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                    name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                    type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                    <input class="radio-inline"
                                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                        type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>

                                                                <%-- 10 --%>
                                                                <asp:ListView ID="DescripcionesRedes" DataKeyNames="Resultado" DataSourceID="getDescripcionesRedes" Visible="false" runat="server">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label1" CssClass="titulo-form" Text="Redes" runat="server" />   
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <input class="radio-inline"
                                                                                    id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                    name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                    type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                    <input class="radio-inline"
                                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                        type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>

                                                                <%-- 1 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesNivelIntervencion" DataKeyNames="Resultado" DataSourceID="getDescripcionesNivelIntervencion" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label1" CssClass="titulo-form" Text="Nivel de Intervención Judicial" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server" />
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <input class="radio-inline" id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                    name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>' type="radio"
                                                                                    value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si

                                                                                                    <input class="radio-inline" id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>' type="radio"
                                                                                                        value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 3 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesIntervencionNNA" DataKeyNames="Resultado" DataSourceID="getDescripcionesIntervencionNNA" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label3" CssClass="titulo-form" Text="Intervención con el NNA" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                        <input class="radio-inline"
                                                                                                            id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                            name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                            type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-8">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlNNAegresaporPIIPRM" onclick="cargaValorNNAEgresaporPIIPRM();" DataSourceID="getPonderacionesNNAEgresoporPII" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 14) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>
                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 14) ? "rdo_DdlNNAEgresoporPIIPRM_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 14) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 14) ? Eval("valor") : "4" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-8">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlNNAInterrumpeConductas" onclick="cargaValorInterrumpeConductasPAS();" DataSourceID="getPonderacionesInterrumpeConductas" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 32) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>
                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 32) ? "rdo_InterrumpeConductas_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 32) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 32) ? Eval("valor") : "6" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-8">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlNNAEgresaporPIIPAS" onclick="cargaValorNNAEgresaporPIIPAS();" DataSourceID="getPonderacionesNNAEgresoporPIIPAS" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 36) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>
                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 36) ? "rdo_DdlNNAEgresoporPIIPAS_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 36) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 36) ? Eval("valor") : "4" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 8 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesGestionRedes24Horas" DataKeyNames="Resultado" DataSourceID="getDescripcionesGestionRedes24Horas" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label7" Text="Gestion de Redes Programa 24 Horas" CssClass="titulo-form" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%#Eval("Nemot") %>_<%#Eval("iCodparResultado") %>_si'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%#Eval("Nemot") %>_<%#Eval("iCodparResultado") %>_no'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No

                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />

                                                                <asp:Label ID="Label2" CssClass="titulo-form" Text="Termino de PII" runat="server" />
                                                                <br />
                                                                <div class="row">
                                                                    <div class="col-md-4 titulo-tabla">
                                                                        Intervención Completa
                                                                    </div>
                                                                    <div class="col-md-8 text-center">
                                                                        <asp:RadioButton ID="rb_intervencion_completa_si" runat="server" GroupName="rics" Text="Si" Visible="True" Enabled="true" />
                                                                                            <asp:RadioButton ID="rb_intervencion_completa_no" runat="server" GroupName="rics" Text="No" Visible="True" Enabled="true" Checked="true" />
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-4 titulo-tabla">
                                                                        Habilitado para Egreso
                                                                    </div>
                                                                    <div class="col-md-8 text-center">
                                                                        <asp:RadioButton ID="rb_habilitado_egreso_si" runat="server" GroupName="rhes" Text="Si" Visible="True" Enabled="true" />
                                                                        <asp:RadioButton ID="rb_habilitado_egreso_no" runat="server" GroupName="rhes" Text="No" Visible="True" Enabled="true" Checked="true" />

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-4 titulo-tabla">
                                                                        Grado de Cumplimiento
                                                                    </div>
                                                                    <div class="col-md-8 text-center">
                                                                        <asp:DropDownList ID="ddl_gdc" CssClass="form-control input-sm" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-4 titulo-tabla">
                                                                        Fecha Real Termino
                                                                    </div>
                                                                    <div class="col-md-8 text-center">
                                                                        <asp:TextBox ID="txt_frt" onkeypress="return false;" MaxLength="10" CssClass="form-control form-control-fecha-large input-sm" runat="server" placeholder="dd-mm-aaaa"></asp:TextBox>
                                                                        <ajax:CalendarExtender FirstDayOfWeek="Monday" ID="Calendartxtfrt" Enabled="true" runat="server" ViewStateMode="Enabled" TargetControlID="txt_frt" Format="dd-MM-yyyy" ValidateRequestMode="Enabled"></ajax:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                              
                                                                <%-- 2 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesImplementacionMedida" DataKeyNames="Resultado" DataSourceID="getDescripcionesImplementacionMedida" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label2" CssClass="titulo-form" Text="Implementacion Medida" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <input class="radio-inline"
                                                                                    id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                    name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                    type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                    <input class="radio-inline"
                                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                        type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 4 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesTrabajoConFamilia" DataKeyNames="Resultado" DataSourceID="getDescripcionesTrabajoConFamilia" Visible="false">                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label4" CssClass="titulo-form" Text="Trabajo Con Familia" runat="server"></asp:Label>
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                        <input class="radio-inline" id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                            name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                            type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 42) ? true : false %>'
                                                                                    ID="ddlAdultoaCargo" onclick="cargaValorAdultosaCargoPAS();" DataSourceID="getPonderacionAdultosaCargo" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control">
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 42) ? "rdo_adultoaCargo_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 42) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 42) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 64) ? true : false %>'
                                                                                    ID="ddlAdultoaCargoPEE" onclick="cargaValorAdultosaCargoPEE();" DataSourceID="getPonderacionAdultosaCargoPEE" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control">
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 64) ? "rdo_adultoaCargoPEE" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 64) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 64) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 85) ? true : false %>'
                                                                                    ID="ddlAdultoaCargoPEC" onclick="cargaValorAdultosaCargoPEC();" DataSourceID="getPonderacionAdultosaCargoPEC" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control">
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 85) ? "rdo_adultoaCargoPEE" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 85) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 85) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 134) ? true : false %>'
                                                                                    ID="ddlAdultoaCargoPPF" onclick="cargaValorAdultosaCargoPPF();" DataSourceID="getPonderacionAdultosaCargoPPF" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control">
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 134) ? "rdo_adultoaCargoPPF" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 134) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 134) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlEvaluacionLogro" onclick="cargaValorEvaluacionLogroPRM();" DataSourceID="getPonderacionesEvaluaciondelLogro" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 19) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 19) ? "rdo_EvaluacionLogroPRM_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 19) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 19) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("ICodparResultado")) %> />
                                                                            </div>

                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlEvaluacionLogroPAD" onclick="cargaValorEvaluacionLogroPAD();" DataSourceID="getPonderacionesEvaluaciondelLogroPAD" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 120) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 120) ? "rdo_EvaluacionLogroPAD_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 120) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 120) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("ICodparResultado")) %> />


                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlEvaluacionLogroPPF" onclick="cargaValorEvaluacionLogroPPF();" DataSourceID="getPonderacionesEvaluaciondelLogroPPF" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 136) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 136) ? "rdo_evaluacionLogro_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 136) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 136) ? Eval("valor") : "12" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />

                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 5 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesEvaluacionDelLogro" DataKeyNames="Resultado" DataSourceID="getDescripcionesEvaluacionDelLogro" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label5" CssClass="titulo-form" Text="Evaluacion del Logro" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input type="hidden" id='hdn_<%# Eval("Cod_Nivel_Intervencion") %>' />
                                                                                    <input class="radio-inline"
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                    <input class="radio-inline"
                                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                        type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlEvaluacionLogro" onclick="cargaValorEvaluacionLogroPRM();" DataSourceID="getPonderacionesEvaluaciondelLogro" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 19) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 19) ? "rdo_EvaluacionLogroPRM_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 19) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 19) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("ICodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlEvaluacionLogroPAD" onclick="cargaValorEvaluacionLogroPAD();" DataSourceID="getPonderacionesEvaluaciondelLogroPAD" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 120) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 120) ? "rdo_EvaluacionLogroPAD_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 120) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 120) ? Eval("valor") : "0" %>' <%# HabilitarHdn(Eval("ICodparResultado")) %> />


                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    ID="ddlEvaluacionLogroPPF" onclick="cargaValorEvaluacionLogroPPF();" DataSourceID="getPonderacionesEvaluaciondelLogroPPF" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 136) ? true : false %>'>
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>

                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 136) ? "rdo_evaluacionLogro_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 136) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 136) ? Eval("valor") : "12" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />

                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 6 --%>
                                                                <asp:ListView ID="getDescripcionSintomatología" runat="server" DataKeyNames="Resultado" DataSourceID="getDescripcionesSintomatologia" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label6" CssClass="titulo-form" Text="Sintomatologia de la Vulneración de Derechos" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-7 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> <%# HabilitarHdn(Eval("IcodparResultado")) %> />Si
                                                                                                        <input class="radio-inline"
                                                                                                            id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                            name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                            type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> <%# HabilitarHdn(Eval("IcodparResultado")) %> />No
                                                                                        
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 43) ? true : false %>'
                                                                                    ID="ddlSintomatologia" onclick="cargaValorDisminucionSintomatologiaPAS();" DataSourceID="getPonderacionesSintomatologia" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control">
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>
                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 43) ? "rdo_Sintomatologia_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 43) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 43) ? Eval("valor") : "12" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                            <div class="col-md-7">
                                                                                <asp:DropDownList runat="server"
                                                                                    Visible='<%# ((int)Eval("iCodparResultado") == 137) ? true : false %>'
                                                                                    ID="ddlSintomatologiaPPF" onclick="cargaValorDisminucionSintomatologiaPPF();" DataSourceID="getPonderacionesSintomatologiaPPF" DataTextField="Ponderacion_Variable" DataValueField="Cod_Ponderacion_Variable" CssClass="form-control">
                                                                                    <asp:ListItem Text="Seleccionar" Value="0" />
                                                                                </asp:DropDownList>
                                                                                <input type="hidden" id='<%# ((int)Eval("iCodparResultado") == 137) ? "rdo_Sintomatologia_" + Eval("iCodparResultado") : "" %>'
                                                                                    name='<%# ((int)Eval("iCodparResultado") == 137) ? "rdo_" + Eval("Nemot") + "_" + Eval("iCodparResultado") + "_" + Eval("Cod_nivel_Intervencion") : "" %>'
                                                                                    value='<%# ((int)Eval("iCodparResultado") == 137) ? Eval("valor") : "12" %>' <%# HabilitarHdn(Eval("IcodparResultado")) %> />
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 7 --%>
                                                                <asp:ListView runat="server" ID="getDescripcionTrabajoGarantesDerecho" DataKeyNames="Resultado" DataSourceID="getDescripcionesTrabajoGarantesDerecho" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label6" CssClass="titulo-form" Text="Trabajo con Garantes de Derechos" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>''>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                        <input class="radio-inline"
                                                                                                            id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                            name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                            type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                                        
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />
                                                                <%-- 11 --%>
                                                                <asp:ListView runat="server" ID="DescripcionesCapacitacion" DataKeyNames="Resultado" DataSourceID="getDescripcionesCapacitacion" Visible="false">
                                                                    <LayoutTemplate>
                                                                        <asp:Label ID="Label6"  CssClass="titulo-form" Text="Capacitación" runat="server" />
                                                                        <asp:PlaceHolder ID="ItemPlaceholder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-4 titulo-tabla" id='div_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>''>
                                                                                <%# Eval("Resultado") %>
                                                                            </div>
                                                                            <div class="col-md-8 text-center" id='div_rdo_<%#Eval("Nemot") %>_<%# Eval("iCodparResultado") %>'>
                                                                                <label>
                                                                                    <input class="radio-inline"
                                                                                        id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_si'
                                                                                        name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                        type="radio" value="1" <%# marcarRadio(Eval("valor"), 1) %> />Si
                                                                                                        <input class="radio-inline"
                                                                                                            id='rdo_<%# Eval("Nemot") %>_<%# Eval("iCodparResultado") %>_no'
                                                                                                            name='rdo_<%# Eval("Nemot") %>_<%# Eval("ICodparResultado") %>_<%# Eval("Cod_Nivel_Intervencion") %>'
                                                                                                            type="radio" value="0" <%# marcarRadio(Eval("valor"), 0) %> />No
                                                                                        
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                                <br />

                                                                <%--<asp:LinkButton
                                                                
                                                                
                                                                         runat="server" ID="guardarVariablesPII" CssClass="btn btn-danger" OnClick="guardarVariablesPII_Click">Guardar Seguimiento PII</asp:LinkButton>--%>
                                                            </div>

                                                            <br /><br />
                                                            <div class="text-center">
                                                                <asp:LinkButton CssClass="btn btn-danger btn-sm fixed-width-button" ID="lnkbtntab5" runat="server" OnClick="lnkbtntab5_Click">
                                                                                        <span class="glyphicon glyphicon-ok"></span>&nbsp;Actualizar
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                        </div>
                                    </div>
                            </div>
                        </div>

                                                <%--<table id="Table3" class="tabla tabla-tabs table-bordered table-condensed" runat="server">
                                            <tr>
                                                <th class="titulo-tabla col-md-1" scope="row">Intervención Completa</th>
                                                <td class="col-md-4">
                                                    <div class="text-center">
                                                    </div>
                                                </td>

                                                <th class="titulo-tabla col-md-1" scope="row">Habilitado para Egreso</th>
                                                <td>
                                                    <div class="text-center">
                                                        
                                                    </div>

                                                </td>
                                            </tr>
                                            <tr>
                                                <th class="titulo-tabla" scope="row">Grado de Cumplimiento *</th>
                                                <td>
                                                    
                                                </td>

                                                <th class="titulo-tabla" scope="row">Fecha Real Término *</th>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr>--%>
                        <td colspan="4"></td>
                        </tr>
                                        </table>
                                </asp:Panel>
                    </div>
                </div>



                </asp:Panel>




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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
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

        <script src="../js/bootstrap.min.js"></script>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
        <!-- Latest compiled and minified JavaScript -->
    </form>
</body>

</html>
