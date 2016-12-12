<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionAlertas.aspx.cs" Inherits="mod_alertas_GestionAlertas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/menu_colgante.ascx" TagPrefix="uc1" TagName="menu_colgante" %>
<%@ Register Src="~/Referencias.ascx" TagPrefix="uc2" TagName="Referencias" %>

<%--<%@ Register src="~/mod_alertas/FormularioAlertas.ascx" TagPrefix="ucAlertas" TagName="Alertas" %>--%>

<meta charset="utf-8"><meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta name="description" content="S"><meta name="author" content="">
<title>Gestión de Alertas :: Senainfo :: Sename</title>

<script src="../js/jquery-2.1.4.js"></script>
<script src="../js/bootstrap3.3.4.min.js"></script>
<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<link rel="stylesheet" href="../css/bootstrap.css" />
<link rel="stylesheet" href="../css/bootstrap-theme.css" />
<link rel="stylesheet" href="../css/bootstrap.min.css" />
<link rel="stylesheet" href="../css/theme.css" />
 <%-- modif --%>

<%--<uc2:Referencias runat="server" ID="Referencias" />--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

<script type="text/javascript">
  $(function() {
    $( document ).tooltip({
      track: true
    });
  });

  //$(function () {
  //  $("#mensajeTipo").css('display', 'none');
  //  $("#mensajePersonalizado").css('display', 'none');
  //});

  $(function () {

    //$("#tipoMensaje").on('change', function () {
    //  if ($(this).val() == '1') {
    //    $('#mensajePersonalizado').hide('slow');
    //    $("#mensajeTipo").show('slow');
    //  } else if ($(this).val() == '2') {
    //    $("#mensajeTipo").hide('slow');
    //    $('#mensajePersonalizado').show('slow');
    //  } else {
    //    $("#mensajeTipo").hide('slow');
    //    $("#mensajePersonalizado").hide('slow');
    //  }
    //});

    //if ($('#tipoMensaje').on('change'), function () {
    //  if ($("#tipoMensaje").val() == '1') {
    //    $('#mensajePersonalizado').hide('fast');
    //    $("#mensajeTipo").show('fast');
    //   } else if ($("#tipoMensaje").val() == '2') {
    //      $("#mensajeTipo").hide('fast');
    //      $('#mensajePersonalizado').show('fast');
    //   } else {
    //        $("#mensajeTipo").hide('fast');
    //        $("#mensajePersonalizado").hide('fast');
    //}
    //});
  });


  </script>
</head>
  <body>
  <style type="text/css">
        .ocultar-columna {
          display:none;
        }
        tr td {
          color:black;
          white-space: pre;
        }
        th {
          text-align: center;
        }

      
</style>

    <form id="form1" runat="server">
      <uc1:menu_colgante runat="server" ID="menu_colgante" />
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
          
      <div class="container theme-showcase" role="main">
        <div class ="well">
          <label class="titulo-form">Gestión de Alertas</label>
          <br /><br />

            <!-- Nav tabs -->
           <asp:Panel runat="server">
              <div id="tabs">
                <ul class="nav nav-tabs text-center" role="tablist">
                  <li role="presentation" class="active"><a href="#alertaTab1" aria-controls="home" role="tab" data-toggle="tab">ESTADOS</a></li>
                  <%--<li role="presentation"><a href="#alertaTabModulos" aria-controls="profile" role="tab" data-toggle="tab">Gestión<br />Módulos</a></li>--%>
                  <%--<li role="presentation"><a href="#alertaTabParametros" aria-controls="profile" role="tab" data-toggle="tab">Gestión<br />Parametros</a></li>--%>
                  <li role="presentation"><a href="#alertaTab2" aria-controls="profile" role="tab" data-toggle="tab">CATEGORÍAS</a></li>
                  <li role="presentation"><a href="#alertaTab3" aria-controls="messages" role="tab" data-toggle="tab">SUBCATEGORÍAS</a></li>
                  <li role="presentation"><a href="#alertaTab4" aria-controls="settings" role="tab" data-toggle="tab">TIPO</a></li>
                  <%--<li role="presentation"><a href="#alertaTab5" aria-controls="settings" role="tab" data-toggle="tab">GESTIÓN<br />DETALLES</a></li>--%>
                  <li role="presentation"><a href="#alertaTab6" aria-controls="settings" role="tab" data-toggle="tab">GESTIÓN MANUAL</a></li>
                </ul>
             </div>

               <!-- Tab panes -->
              <div class="tab-content">
                  
                  <%-- Estado --%>
                <div role="tabpanel" class="tab-pane fade in active" id="alertaTab1">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="descEstado" class="col-sm-2 control-label">Estado</label>
                        <div class="col-sm-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="descEstado"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarEstado" OnClick="agregarEstado_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarEstado" OnClick="modificarEstado_Click">Modificar</asp:LinkButton>
                        </div>
                      </div>
                      <br /> <br />
                    <asp:GridView runat="server" ID="gridEstadosAlerta" CssClass="table table-condensed table-bordered text-center" Visible="true" AutoGenerateColumns="false" OnRowCommand="gridEstadosAlerta_RowCommand">
                        <Columns>
                        <asp:BoundField HeaderText="CodEstado" DataField="COD_ESTADO" />
                        <asp:BoundField HeaderText="Estado" DataField="DESC_ESTADO" />
                        <asp:ButtonField HeaderText="Acción" CommandName="Modificar" Text="Modificar" />
                        </Columns>
                    <HeaderStyle CssClass="titulo-tabla text-center" />
                    <RowStyle CssClass="text-center" />   
                    </asp:GridView>
                    <br /><br />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                  
                  <%-- Modulos --%>
               
                <%--<div role="tabpanel" class="tab-pane fade" id="alertaTabModulos">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="descModulo" class="col-sm-2 control-label">Nombre Módulo</label>
                        <div class="col-sm-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="descModulo"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="rutaModulo" class="col-sm-2 control-label">Ruta Módulo</label>
                        <div class="col-sm-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="rutaModulo" ToolTip="Ejemplo: ../mod_ninos/"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarModulo" OnClick="agregarModulo_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarModulo" OnClick="modificarModulo_Click">Modificar</asp:LinkButton>
                        </div>
                      </div>
                      <br /> <br />
                      <div class="col-md-12">
                        <asp:GridView runat="server" ID="GridView1" CssClass="table table-condensed table-bordered" Visible="true" AutoGenerateColumns="false" OnRowCommand="gridEstadosAlerta_RowCommand">
                          <Columns>
                            <asp:BoundField HeaderText="CodModulo" DataField="COD_MODULO" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Estado" DataField="DESC_MODULO" />
                            <asp:BoundField HeaderText="Ruta Módulo" DataField="RUTA_ASOCIADA" />
                            <asp:ButtonField HeaderText="Acción" CommandName="Modificar" Text="Modificar" />
                          </Columns>
                        </asp:GridView>
                        <br /><br />
                      </div> 
                    </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>--%>

                  <%-- Parametros --%>

                <%--<div role="tabpanel" class="tab-pane fade" id="alertaTabParametros">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="descParametro" class="col-sm-2 control-label">Nombre Parametro</label>
                        <div class="col-sm-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="descParametro"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="rutaParametro" class="col-sm-2 control-label">Ruta Parametro</label>
                        <div class="col-sm-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="rutaParametro" ToolTip="Ejemplo: ICODIE"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarParametro" OnClick="agregarParametro_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarParametro" OnClick="modificarParametro_Click">Modificar</asp:LinkButton>
                        </div>
                      </div>
                      <br /> <br />
                      <div class="col-md-12">
                        <asp:GridView runat="server" ID="GridView2" CssClass="table table-condensed table-bordered" Visible="true" AutoGenerateColumns="false" OnRowCommand="gridEstadosAlerta_RowCommand">
                          <Columns>
                            <asp:BoundField HeaderText="CodModulo" DataField="COD_MODULO" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Estado" DataField="DESC_MODULO" />
                            <asp:BoundField HeaderText="Ruta Módulo" DataField="RUTA_ASOCIADA" />
                            <asp:ButtonField HeaderText="Acción" CommandName="Modificar" Text="Modificar" />
                          </Columns>
                        </asp:GridView>
                        <br /><br />
                      </div> 
                    </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>--%>
              
                  <%-- Categorias --%>
                <div role="tabpanel" class="tab-pane fade" id="alertaTab2">
                  <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="descCategoria" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-md-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="descCategoria"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <%--<div class="form-group">
                        <label for="ddownSubcategoriaCategoria" class="col-sm-2 control-label">Sub Categoría<br /> (Sí posee)</label> 
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" ID="ddownSubcategoriaCategoria" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                      </div>
                      <br /><br />--%>
                      <div class="form-group">
                       <label for="ddModulosCategoria" class="col-sm-2 control-label">Modulo al que pertenece</label> 
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" ID="ddModulosCategoria" CssClass="form-control input-sm" OnSelectedIndexChanged="ddModulosCategoria_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group" id="divArchivoAsociado" runat="server">
                        <label for="ddArchivoAsociado" runat="server" class="col-sm-2 control-label">Archivo Asociado</label> 
                        <div class="col-md-10">
                          <%--<asp:TextBox runat="server" CssClass="form-control input-sm" ID="archivoAsociado"></asp:TextBox>--%> 
                          <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddArchivoAsociado">
                            <asp:ListItem Value="-2" Text="SELECCIONAR">SELECCIONAR</asp:ListItem>
                          </asp:DropDownList>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="ddEstadosCategoria" class="col-sm-2 control-label">Estado</label> 
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" ID="ddEstadosCategoria" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10 ">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarCategoria" OnClick="agregarCategoria_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarCategoria" OnClick="modificarCategoria_Click">Modificar</asp:LinkButton>
                        </div>
                      </div>
                      <br /><br />
                        <asp:GridView runat="server" ID="gridCategorias" CssClass="table table-condensed table-bordered text-center"  AutoGenerateColumns="false" OnRowCommand="gridCategorias_RowCommand">
                          <Columns>
                            <asp:BoundField HeaderText="CodCategoria" DataField="COD_CATEGORIA" />
                            <asp:BoundField HeaderText="Categoría" DataField="DESC_CATEGORIA" />
                            <asp:BoundField HeaderText="Modulo" DataField="MODULO" />
                            <asp:BoundField HeaderText="Archivo Asociado" DataField="ARCHIVO_ASOCIADO" />
                            <asp:BoundField HeaderText="CodEstado" DataField="COD_ESTADO" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna"/>
                            <asp:BoundField HeaderText="Estado" DataField="DESC_ESTADO" />
                            <asp:ButtonField Text="Modificar" CommandName="Modificar" HeaderText="Acción" />
                          </Columns>
                            <HeaderStyle CssClass="titulo-tabla text-center" />
                          <RowStyle CssClass="text-center" />   
                        </asp:GridView>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>

                  <%-- Subcategorias --%>
                <div role="tabpanel" class="tab-pane fade" id="alertaTab3">
                  <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="Subcategoría" class="col-sm-2 control-label">Sub Categoría</label>
                        <div class="col-md-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="Subcategoría"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="formgroup">
                        <label for="ddownCategoriasSubcategorias" class="col-sm-2 control-label">Categoría Asociada</label>
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" CssClass="form-control input-sm" id="ddownCategoriasSubcategorias"></asp:DropDownList>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                          <label for="ddownEstadoSubcategoria" class="col-sm-2 control-label">Estado</label>
                          <div class="col-md-10">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownEstadoSubcategoria"></asp:DropDownList>
                          </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10 ">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarSubcategoria" OnClick="agregarSubcategoria_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarSubcategoria" OnClick="modificarSubcategoria_Click">Modificar</asp:LinkButton>
                        </div>
                      </div>
                      <br /><br />
                        <asp:GridView runat="server" ID="gridSubCategorias" CssClass="table table-condensed table-bordered text-center" AutoGenerateColumns="false" OnRowCommand="gridSubCategorias_RowCommand">
                          <Columns>
                            <asp:BoundField HeaderText="ID Relación" DataField="ID_REL_CATSUBCAT" />
                            <asp:BoundField HeaderText="CodSubcategoria" DataField="COD_SUBCATEGORIA" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Subcategoria" DataField="DESC_SUBCATEGORIA" />
                            <asp:BoundField HeaderText="CodCategoria" DataField="COD_CATEGORIA" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Categoria Asociada" DataField="DESC_CATEGORIA" />
                            <asp:BoundField HeaderText="CodEstado" DataField="COD_ESTADO" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Estado" DataField="DESC_ESTADO" />
                            <asp:ButtonField HeaderText="Acción" Text="Modificar" CommandName="Modificar" />
                          </Columns>
                          <HeaderStyle CssClass="titulo-tabla text-center" />
                          <RowStyle CssClass="text-center" />   
                        </asp:GridView>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>

                  <%-- Tipo --%>
                <div role="tabpanel" class="tab-pane fade" id="alertaTab4">
                  <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="descTipoAlerta" class="col-sm-2 control-label">Tipo de Alerta</label>
                        <div class="col-md-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="descTipoAlerta"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                          <label for="ddownEstadoTipoAlerta" class="col-sm-2 control-label">Estado</label>
                          <div class="col-md-10">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownEstadoTipoAlerta"></asp:DropDownList>
                          </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10 ">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarTipo" OnClick="agregarTipo_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarTipo" OnClick="modificarTipo_Click">Modificar</asp:LinkButton> 
                        </div>
                      </div>
                      <br /><br />
                      <div class="col-md-12">
                        <asp:GridView runat="server" ID="gridTiposAlerta" CssClass="table table-condensed table-bordered text-center" AutoGenerateColumns="false" OnRowCommand="gridTiposAlerta_RowCommand">
                          <Columns>
                            <asp:BoundField HeaderText="CodTipo" DataField="COD_TIPO" />
                            <asp:BoundField HeaderText="Tipo Alerta" DataField="DESC_TIPO" />
                            <asp:BoundField HeaderText="CodEstado" DataField="COD_ESTADO" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Estado" DataField="DESC_ESTADO" />
                            <asp:ButtonField Text="Modificar" HeaderText="Acción" CommandName="Modificar" />
                          </Columns>
                        <HeaderStyle CssClass="titulo-tabla text-center" />
                        <RowStyle CssClass="text-center" />   
                        </asp:GridView>
                      </div>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>

                  <%-- Detalles --%>
                <%--<div role="tabpanel" class="tab-pane fade" id="alertaTab5">
                  <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                      <div class="form-group">
                        <label for="descEncabezado" class="col-sm-2 control-label">Encabezado</label>
                        <div class="col-md-10">
                          <asp:TextBox runat="server" CssClass="form-control input-sm" ID="descEncabezado"></asp:TextBox>
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="descDetalle" class="col-sm-2 control-label">Cuerpo</label>
                        <div class="col-md-10">
                          <textarea runat="server" class="form-control input-sm" ID="descDetalle"></textarea> 
                        </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                          <label for="ddownEstadosDetalle" class="col-sm-2 control-label">Estado</label>
                          <div class="col-md-10">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownEstadosDetalle"></asp:DropDownList>
                          </div>
                      </div>
                      <br /><br />
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10 ">
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarDetalle" OnClick="agregarDetalle_Click">Agregar</asp:LinkButton>
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificardetalle" OnClick="modificardetalle_Click">Modificar</asp:LinkButton> 
                        </div>
                      </div>
                      <br /><br />
                      <asp:GridView runat="server" ID="gridDetallesAlerta" CssClass="table table-bordered table-condensed"  AutoGenerateColumns="false" OnRowCommand="gridDetallesAlerta_RowCommand" OnRowDataBound="gridDetallesAlerta_RowDataBound">
                        <Columns>
                          <asp:BoundField HeaderText="CodDetalle" DataField="COD_DETALLE" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                          <asp:BoundField HeaderText="Encabezado" DataField="DESC_ENCABEZADO" />
                          <asp:BoundField HeaderText="Cuerpo" DataField="DESC_DETALLE" />
                          <asp:BoundField HeaderText="CodEstado" DataField="COD_ESTADO" HeaderStyle-CssClass="ocultar-columna" ItemStyle-CssClass="ocultar-columna" />
                          <asp:BoundField HeaderText="Estado" DataField="DESC_ESTADO" />
                          <asp:ButtonField HeaderText="Acción" Text="Modificar" CommandName="Modificar" />
                        </Columns>
                        <HeaderStyle CssClass="titulo-tabla text-center" />
                        <RowStyle CssClass="text-center" />   
                      </asp:GridView>
                    </ContentTemplate>
                 </asp:UpdatePanel>
                </div>--%>

                  <%-- Alertas Manuales --%>
                <div role="tabpanel" class="tab-pane fade" id="alertaTab6">
                  <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                      <br />
                      <div class="form-group">
                        <%--<strong><label for="" class="col-sm-12 text-info">Datos de Alerta</label></strong>--%>
                          <strong class="text-info">Datos de Alerta</strong>
                          <%--<label class="titulo-form">Gestión de Alertas</label>--%>
                      </div>
                      <div class="form-group">
                        <label for="ddownCategorias" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-md-4">
                          <%--<asp:TextBox runat="server" CssClass="form-control input-sm" ID="TextBox1"></asp:TextBox>--%>
                          <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownCategorias" AutoPostBack="true" OnSelectedIndexChanged="ddownCategorias_SelectedIndexChanged">
                          </asp:DropDownList>
                        </div>
                        <label for="ddownSubcategorias" class="col-sm-2 control-label">Subcategoría</label>
                        <div class="col-md-4">
                          <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownSubcategorias" >
                            <asp:ListItem Value="0" Text="Seleccionar"></asp:ListItem>
                          </asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="ddownTipos" class="col-sm-2 control-label">Tipo</label>
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownTipos">
                          </asp:DropDownList> 
                        </div>
                      </div>
                       <div class="form-group">
                           <label for="ddownEstadosAlerta" class="col-sm-2 control-label">Estado</label>
                           <div class="col-md-10">
                                <asp:DropDownList runat="server" CssClass="form-control input-sm" id="ddownEstadosAlerta"></asp:DropDownList>
                            </div>
                       </div>
                        <br />
                        <%--<label for="" class="col-sm-12 control-label text-info">Mensaje</label>--%>
                          <strong class="text-info">Mensaje</strong>
                        <br />
                     <%-- <div class="form-group">
                        <label for="tipoMensaje" class="col-sm-2 control-label text-info text-center">&nbsp;</label>--%>
                        <%--<div class="col-md-4 col-md-offset-2">--%>
                           <%--<asp:DropDownList runat="server" ID="tipoMensaje" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="tipoMensaje_SelectedIndexChanged">
                             <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                             <asp:ListItem Value="1">Mensaje Tipo</asp:ListItem>
                             <asp:ListItem Value="2">Mensaje Personalizado</asp:ListItem>
                           </asp:DropDownList>--%>
                          <%--<select class="form-control input-sm" id="tipoMensaje">
                            <option value="0">Seleccionar</option>
                            <option value="1">Mensaje Tipo</option>
                            <option value="2">Mensaje Personalizado</option>
                          </select>--%>
                         <%--</div>--%>
                      <%--</div>--%>

                     <%-- <div id="mensajeTipo" runat="server">
                        <div class="form-group" id="encabezadoTipo">
                          <label for="ddownEncabezadoDetalle" class="col-sm-2 control-label">Encabezado</label>
                          <div class="col-md-10">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownEncabezadoDetalle" OnSelectedIndexChanged="ddownEncabezadoDetalle_SelectedIndexChanged" OnSelectedOnTextChanged="ddownEncabezadoDetalle_TextChanged" AutoPostBack="true"></asp:DropDownList>
                          </div>
                        </div>
                        <br /><br />
                        <div class="form-group" id="cuerpoTipo">
                          <label for="descDetalleAlertaManual" class="col-sm-2 control-label">Cuerpo</label>
                          <div class="col-md-10">
                              <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control input-sm" TextMode="MultiLine"  ID="descDetalleAlertaManual"></asp:TextBox> 
                          </div>
                        </div>
                        <br /><br />
                      </div>--%>
                      
                      <div id="mensajePersonalizado" runat="server" visible="true">
                        <div class="form-group">
                          <label for="encabezadoPersonalizado" class="col-sm-2 control-label">Encabezado</label>
                          <div class="col-md-10">
                            <%--<asp:DropDownList runat="server" CssClass="form-control input-sm" ID="DropDownList1" OnSelectedIndexChanged="ddownEncabezadoDetalle_SelectedIndexChanged" OnSelectedOnTextChanged="ddownEncabezadoDetalle_TextChanged" AutoPostBack="true"></asp:DropDownList>--%>
                                <asp:TextBox runat="server" CssClass="form-control input-sm" ID="encabezadoPersonalizado" MaxLength="30"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="cuerpoPersonalizado" class="col-sm-2 control-label">Cuerpo</label>
                          <div class="col-md-10">
                              <asp:TextBox runat="server" CssClass="form-control input-sm" TextMode="MultiLine"  ID="cuerpoPersonalizado" MaxLength="100"></asp:TextBox> 
                          </div>
                        </div>
                        <br />
                      </div>

                        <%--<label for="" class="col-sm-12 control-label text-info">Datos Relacionados</label>--%>
                        <strong class="text-info">Datos Relacionados</strong>
                        <br /><br />
                      <div class="form-group">
                        <label for="ddownRol" class="col-sm-2 control-label">Rol</label>
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" ID="ddownRol" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="ICODIE" class="col-sm-2 control-label">ICODIE</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" CssClass="form-control input-sm" ID="ICODIE" MaxLength="7"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="ddownDeptos" class="col-sm-2 control-label">Departamento Sename</label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownDeptos">
                              <asp:ListItem Value="-2" Text="Seleccionar"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <%--<label for="" class="col-sm-12 control-label text-info">Proyecto e Institución Relacionados</label>--%>
                          <%--<strong class="text-info">Institución y Proyecto Relacionado</strong>--%>
                      </div>
                      <br />
                      <div class="form-group">
                        <label for="ddownInstituciones" class="col-sm-2 control-label">Institución</label>
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddownInstituciones" OnSelectedIndexChanged="ddownInstituciones_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="ddownProyectos" class="col-sm-2 control-label">Proyecto</label>
                        <div class="col-md-10">
                          <asp:DropDownList runat="server" CssClass="form-control input-sm col-sm-8" ID="ddownProyectos" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="Seleccionar">Seleccionar</asp:ListItem>
                          </asp:DropDownList>
                          <%--<label class="text-info" style="font-style:italic">Nota: Sólo este dato se asociara a la alerta</label>--%>
                        </div>
                      </div>
                      
                      <div class="form-group">
                        <label for="" class="col-sm-2 control-label">&nbsp;</label>
                        <div class="col-sm-10 ">
                            <br />
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="agregarAlertaManual" OnClick="agregarAlertaManual_Click">Agregar</asp:LinkButton>
                            <br />
                          <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" ID="modificarAlertaManual" OnClick="modificarAlertaManual_Click">Modificar</asp:LinkButton>
                            <br /><br />
                        </div>
                      </div>

                      
                      <%-- GridView de Alertas --%>
                        <asp:GridView runat="server" Visible="true" ID="gridAlertas" CssClass="table table-bordered table-hover text-center" AutoGenerateColumns="false" OnRowCommand="gridAlertas_RowCommand">
                          <Columns>
                            <asp:BoundField HeaderText="CodAlerta" DataField="COD_ALERTA" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="IdRel" DataField="ID_REL_CATSUBCAT" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna"  />
                            <asp:BoundField HeaderText="CodCategoria" DataField="COD_CATEGORIA" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="CodSubcategoria" DataField="COD_SUBCATEGORIA" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="CodDepto" DataField="COD_DEPTO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="CodTipo" DataField="COD_TIPO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Rol" DataField="ROL" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="CodProyecto" DataField="COD_PROYECTO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="CodInstitucion" DataField="COD_INSTITUCION" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="CodEstado" DataField="COD_ESTADO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />

                            <asp:BoundField HeaderText="Modulo" DataField="MODULO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna"/>
                            <asp:BoundField HeaderText="Archivo" DataField="ARCHIVO_ASOCIADO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Desc_Encabezado"  DataField="DESC_ENCABEZADO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="desc_cuerpo" DataField="DESC_CUERPO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="DescRol" DataField="DESC_ROL" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Proyecto" DataField="PROYECTO"  ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna"/>
                            
                            <asp:BoundField HeaderText="ICODIE" DataField="ICODIE" />
                            <asp:BoundField HeaderText="Categoria" DataField="DESC_CATEGORIA" />
                            <asp:BoundField HeaderText="Subcategoría" DataField="DESC_SUBCATEGORIA" />
                            <asp:BoundField HeaderText="Tipo" DataField="DESC_TIPO" ItemStyle-CssClass="tipoAlerta" />
                            <asp:BoundField HeaderText="Descripción" DataField="DESCRIPCION" />
                            <asp:BoundField HeaderText="Depto" DataField="DEPTO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Estado" DataField="DESC_ESTADO" />
                            <asp:BoundField HeaderText="FechaCreacion" DataField="FECHA_CREACION" DataFormatString="{0:d}" />
                            <asp:BoundField HeaderText="Fecha Modificacion" DataField="FECHA_MODIFICACION" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:BoundField HeaderText="Fecha Termino" DataField="FECHA_TERMINO" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />
                            <asp:ButtonField HeaderText="Modificar" CommandName="Modificar" Text="Modificar" />
                            <asp:ButtonField HeaderText="Acción" CommandName="accion" Text="Ir" />
                          </Columns>       
                            <%--<asp:BoundField HeaderText="CodDetalle" DataField="COD_DETALLE" ItemStyle-CssClass="ocultar-columna" HeaderStyle-CssClass="ocultar-columna" />--%>
                          <HeaderStyle CssClass="titulo-tabla text-center" />
                          <RowStyle CssClass="text-center" />                
                        </asp:GridView>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
              </div>
          </asp:Panel>
        </div>
      </div>
    </form>
  </body>
</html>
