using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CustomWebControls;
using AjaxControlToolkit;
using System.Data.Common;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class mod_alertas_GestionAlertas : System.Web.UI.Page
{
  #region cargaInicial
  protected void Page_Load(object sender, EventArgs e)
  {
      if (!IsPostBack)
      {
          getDataModAlertas();
      }
  }


  #endregion

  #region Data
  protected void getDataModAlertas()
  {
    modificarEstado.Style.Add("display", "none");
    modificarCategoria.Style.Add("display", "none");
    modificarSubcategoria.Style.Add("display", "none");
    modificarTipo.Style.Add("display", "none");
    //modificarAlertaManual.Style.Add("display", "none");
    //modificardetalle.Style.Add("display", "none");
    modificarAlertaManual.Visible = false;
    //ddArchivoAsociado.Style.Add("display", "none");
    divArchivoAsociado.Style.Add("display", "none");
    //lblArchivoAsociado.Style.Add("display", "none");
    //modificarModulo.Style.Add("display", "none");
    //modificarParametro.Style.Add("display", "none");

    //Cargando Información
    getEstados();
    cargaEstados();
    cargaCategorias();
    cargaSubcategorias();
    cargaTipos();
    //cargaDetalles();
    cargaAlertasDisponibles();
    cargaDropdownlistDeptosAlertas();
    cargaRoles();
    getinstituciones();
    cargaGridAlertas(); 

    DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/"));
    DirectoryInfo[] di = dirInfo.GetDirectories("mod*");
    
    ddModulosCategoria.DataSource = di;
    ddModulosCategoria.Items.Add("Seleccionar");
    ddModulosCategoria.DataValueField = "Name";
    ddModulosCategoria.DataBind();
    
  }

  private void cargaEstados()
  {
    int OPC;
    string desc_estado;
    int cod_estado;

    OPC = 1;
    desc_estado = "";
    cod_estado = 0;

    DataTable dt = new DataTable();
    Alertas alerta = new Alertas();

    //Traigo los datos desde el SP para el dropdown
    DataView dv = new DataView(alerta.getDropdownEstados());

    //Traigo los datos desde el sp para cargar la grilla
    dt = alerta.getEstadosAlerta(OPC, desc_estado, cod_estado);

    //Cargando la grilla con el datatable que retornó
    gridEstadosAlerta.DataSource = dt;
    gridEstadosAlerta.DataBind();

    //Carga Dropdown de Estados en Categoria
    ddEstadosCategoria.DataSource = dv;
    ddEstadosCategoria.DataTextField = "DESC_ESTADO";
    ddEstadosCategoria.DataValueField = "COD_ESTADO";
    dv.Sort = "COD_ESTADO";
    ddEstadosCategoria.DataBind();

    //Carga Dropdown de estados en Subcategoria

    ddownEstadoSubcategoria.DataSource = dv;
    ddownEstadoSubcategoria.DataTextField = "DESC_ESTADO";
    ddownEstadoSubcategoria.DataValueField = "COD_ESTADO";
    dv.Sort = "COD_ESTADO";
    ddownEstadoSubcategoria.DataBind();

    //Carga dropdown de estados en Tipo de alerta

    ddownEstadoTipoAlerta.DataSource = dv;
    ddownEstadoTipoAlerta.DataTextField = "DESC_ESTADO";
    ddownEstadoTipoAlerta.DataValueField = "COD_ESTADO";
    dv.Sort = "COD_ESTADO";
    ddownEstadoTipoAlerta.DataBind();

    ddownEstadosAlerta.DataSource = dv;
    ddownEstadosAlerta.DataTextField = "DESC_ESTADO";
    ddownEstadosAlerta.DataValueField = "COD_ESTADO";
    dv.Sort = "COD_ESTADO";
    ddownEstadosAlerta.DataBind();

    //Carga dropdown de estado en detalles

    //ddownEstadosDetalle.DataSource = dv;
    //ddownEstadosDetalle.DataTextField = "DESC_ESTADO";
    //ddownEstadosDetalle.DataValueField = "COD_ESTADO";
    //dv.Sort = "COD_ESTADO";
    //ddownEstadosDetalle.DataBind();

  }
  private void cargaCategorias()
  {
    int OPC;
    string desc_categoria, modulo, archivo_asociado;
    int cod_estado;
    int cod_subcategoria;
    int cod_categoria;

    OPC = 1;
    desc_categoria = "";
    cod_estado = 0;
    cod_subcategoria = 0;
    cod_categoria = 0;
    modulo = "";
    archivo_asociado = "";

    DataTable dt = new DataTable();
    //DataTable dtc = new DataTable();
    Alertas alerta = new Alertas();
    DataView dv = new DataView(alerta.getDropdownCategorias(OPC, cod_categoria, desc_categoria, modulo, archivo_asociado, cod_estado));

    dt = alerta.getCategorias(OPC, cod_categoria, desc_categoria, modulo, archivo_asociado, cod_estado);

    ddownCategorias.DataSource = dv;
    ddownCategorias.DataTextField = "DESC_CATEGORIA";
    ddownCategorias.DataValueField = "COD_CATEGORIA";
    dv.Sort = "DESC_CATEGORIA";
    ddownCategorias.DataBind();

    ddownCategoriasSubcategorias.DataSource = dv;
    ddownCategoriasSubcategorias.DataSource = dv;
    ddownCategoriasSubcategorias.DataTextField = "DESC_CATEGORIA";
    ddownCategoriasSubcategorias.DataValueField = "COD_CATEGORIA";
    dv.Sort = "DESC_CATEGORIA";
    ddownCategoriasSubcategorias.DataBind();

    gridCategorias.DataSource = dt;
    gridCategorias.DataBind();
  }

  private void cargaSubcategorias()
  {
    int OPC, cod_subcategoria, cod_categoria, cod_estado;
    string desc_subcategoria;

    OPC = 4;
    desc_subcategoria = "";
    cod_estado = 0;
    cod_subcategoria = 0;
    cod_categoria = 0;

    DataTable dt = new DataTable();
    Alertas alerta = new Alertas();
    DataView dv = new DataView(alerta.getDropdownSubcategorias(OPC, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado));

    OPC = 1; //Se modifica OPC para que realice una consulta diferente en el metodo que sigue


    dt = alerta.getSubcategorias(OPC, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado);

    //ddownSubcategorias.DataSource = dv;
    //ddownSubcategorias.DataTextField = "DESC_SUBCATEGORIA";
    //ddownSubcategorias.DataValueField = "COD_SUBCATEGORIA";
    //dv.Sort = "DESC_SUBCATEGORIA";
    //ddownSubcategorias.DataBind();

    //ddownSubcategoriaCategoria.DataSource = dv;
    //ddownSubcategoriaCategoria.DataTextField = "DESCSUBCATEGORIA";
    //ddownSubcategoriaCategoria.DataValueField = "CODSUBCATEGORIA";
    //dv.Sort = "DESCSUBCATEGORIA";
    //ddownSubcategoriaCategoria.DataBind();

    gridSubCategorias.DataSource = dt;
    gridSubCategorias.DataBind();



  }
  private void cargaTipos()
  {
    int opc, cod_tipo, cod_estado;
    string desc_tipo;

    opc = 1;
    cod_tipo = 0;
    desc_tipo = "";
    cod_estado = 0;

    DataTable dt = new DataTable();
    Alertas alerta = new Alertas();
    DataView dv = new DataView(alerta.getDropdownTipos(opc, cod_tipo, desc_tipo, cod_estado));

    dt = alerta.getTipos(opc, cod_tipo, desc_tipo, cod_estado);

    ddownTipos.DataSource = dv;
    ddownTipos.DataTextField = "DESC_TIPO";
    ddownTipos.DataValueField = "COD_TIPO";
    dv.Sort = "DESC_TIPO";
    ddownTipos.DataBind();

    gridTiposAlerta.DataSource = dt;
    gridTiposAlerta.DataBind();

  }
  //private void cargaDetalles()
  //{
  //  int opc, cod_detalle, cod_estado;
  //  string desc_detalle, desc_encabezado;

  //  opc = 1;
  //  cod_detalle = 0;
  //  desc_detalle = "";
  //  desc_encabezado = "";
  //  cod_estado = 0;


  //  Alertas alerta = new Alertas();
  //  DataTable dt = new DataTable();

  //  dt = alerta.getDetalles(opc, cod_detalle, desc_encabezado, desc_detalle, cod_estado);

  //  opc = 4;
  //  DataView dv = new DataView(alerta.getDetalles(opc, cod_detalle, desc_encabezado, desc_detalle, cod_estado));

  //  //ddownEncabezadoDetalle.DataSource = dv;
  //  //ddownEncabezadoDetalle.DataTextField = "DESC_ENCABEZADO";
  //  //ddownEncabezadoDetalle.DataValueField = "COD_DETALLE";
  //  //dv.Sort = "COD_DETALLE";
  //  //ddownEncabezadoDetalle.DataBind();

  //  gridDetallesAlerta.DataSource = dt;
  //  gridDetallesAlerta.DataBind();
  //}
  private void cargaAlertasDisponibles()
  {

  }
  private void cargaRoles()
  {
    Alertas alerta = new Alertas();
    DataView dv = new DataView(alerta.getDropdownRoles());

    ddownRol.DataSource = dv;
    ddownRol.DataTextField = "descripcion";
    ddownRol.DataValueField = "contrasena";
    dv.Sort = "contrasena";
    ddownRol.DataBind();
  }

  private void getEstados()
  {
      //Alertas a = new Alertas();
      //DataView dv = new DataView(a.getEstados());

      //ddownEstadosAlerta.DataSource = dv;
      //ddownEstadosAlerta.DataBind();
      
  }
  private void cargaGridAlertas()
  {
    int opc, cod_alerta, id_rel, cod_tipo, cod_detalle, cod_depto, rol, cod_proyecto, cod_institucion, cod_estado;
    string icodie, rutaGrid, desc_encabezado, desc_cuerpo;

    opc = 1;
    cod_alerta = 0;
    id_rel = 0;
    cod_tipo = 0;
    desc_encabezado = "";
    desc_cuerpo = "";
    cod_detalle = 0;
    cod_depto = 0;
    rol = 0;
    cod_depto = 0;
    icodie = "0";
    cod_proyecto = 0;
    cod_institucion = 0;
    cod_estado = 0;


    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    dt = alerta.getAlertas(opc, cod_alerta, id_rel, cod_tipo, cod_depto, rol, desc_encabezado, desc_cuerpo, icodie, cod_proyecto, cod_institucion, cod_estado);

    gridAlertas.DataSource = dt;
    gridAlertas.DataBind();

    //for (int i = 0; i <= gridAlertas.Rows.Count - 1; i++)
    //{
    //    for (int j = 0; j <= gridAlertas.Columns.Count - 1; j++)
    //    {

    //        if (gridAlertas.Rows[i].Cells[j].Text != null)
    //        {
    //            //MODULO
    //            if (j == 19)
    //            {
    //                if (gridAlertas.Rows[i].Cells[j].Text == "Informativo")
    //                    gridAlertas.Rows[i].Style.Add("background-color", "lightblue");
    //                else if (gridAlertas.Rows[i].Cells[j].Text == "Advertencia")
    //                    gridAlertas.Rows[i].Style.Add("background-color", "lightyellow");
    //                else if (gridAlertas.Rows[i].Cells[j].Text == "Urgente")
    //                    gridAlertas.Rows[i].Style.Add("background-color", "pink");
    //                else if (gridAlertas.Rows[i].Cells[j].Text == "Activa")
    //                    gridAlertas.Rows[i].Style.Add("background-color", "lightgreen");
    //                else
    //                    gridAlertas.Rows[i].Style.Add("background-color", "");
    //            }
    //        }
    //    }
    //    //gridAlertas.Rows[i].Cells[1].Text = "rutaNueva";
    //}

    #region testRutasManuales
    //BoundField Ruta = new BoundField();
    //ButtonField Ruta = new ButtonField();
    //CommandField Ruta = new CommandField();

    //Ruta.HeaderText = "ruta";
    //Ruta.ShowSelectButton = true;
    //gridAlertas.Columns.Add(Ruta);
    //gridAlertas.DataBind();

    //Response.Write("pause");

    // añadir ruta al grid D=

    //  rutaGrid = "";

    //    for (int i = 0; i <= gridAlertas.Rows.Count - 1; i++)
    //    {
    //      for (int j = 0; j <= gridAlertas.Columns.Count - 1; j++)
    //      {

    //        if (gridAlertas.Rows[i].Cells[j].Text != null)
    //        {
    //          //MODULO
    //          if (j == 1)
    //          {
    //            rutaGrid = "";
    //            rutaGrid += "<a href='../";
    //            rutaGrid += gridAlertas.Rows[i].Cells[1].Text;
    //            rutaGrid += "/";
    //          }

    //          //Archivo Asociado
    //          if (j == 2)
    //          {
    //            //rutaGrid += gridAlertas.Rows[i].Cells[2].Text;
    //            rutaGrid += "ninos_egreso.aspx";

    //          }

    //          if (j == 12)
    //          {
    //            icodie = gridAlertas.Rows[i].Cells[12].Text;
    //            rutaGrid += "?ICODIE=" + icodie + "";
    //            rutaGrid += "/'>Entrar</a>";
    //          }
    //        }

    //        if (j == 20)
    //        {
    //          gridAlertas.Rows[i].Cells[j].Text = rutaGrid;
    //        }
    //      }
    //      //gridAlertas.Rows[i].Cells[1].Text = "rutaNueva";
    //    }


    //}
    #endregion
  }

  #endregion

  #region gestionEstados
  protected void agregarEstado_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int OPC, cod_estado;
    string desc_estado;

    OPC = 2;
    desc_estado = descEstado.Text.Trim();
    cod_estado = 0;


    alerta.gestionEstadosAlerta(OPC, desc_estado, cod_estado);

    cargaEstados();
    descEstado.Text = "";
  }
  protected void modificarEstado_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int OPC;
    string desc_estado;
    int cod_estado;

    OPC = 3;
    desc_estado = descEstado.Text.Trim();

    if (Session["cod_estado"] != null)
    {
      cod_estado = Convert.ToInt32(Session["cod_estado"]);
    }
    else
    {
      cod_estado = 0;
    }


    alerta.gestionEstadosAlerta(OPC, desc_estado, cod_estado);

    cargaEstados();
    descEstado.Text = "";
    ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarEstado').show('fast')", true);
  }
  protected void gridEstadosAlerta_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "Modificar")
    {
      int cod_estado;
      string desc_estado;

      Session["cod_estado"] = null;

      Session["cod_estado"] = Convert.ToInt32(gridEstadosAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
      desc_estado = Convert.ToString(gridEstadosAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);

      descEstado.Text = HttpUtility.HtmlDecode(desc_estado);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarEstado').hide('fast')", true);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#modificarEstado').show('fast')", true);
    }
  }
  #endregion

  #region gestionCategoria
  protected void agregarCategoria_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int OPC, cod_estado, cod_categoria;
    int cod_subcategoria;
    string desc_categoria, modulo, archivo_asociado;

    OPC = 2;
    desc_categoria = descCategoria.Text.Trim();
    cod_estado = 1;
    cod_categoria = 0;
    archivo_asociado = ddArchivoAsociado.SelectedItem.Text.Trim();
    modulo = ddModulosCategoria.SelectedItem.Text.Trim();

    //if (ddownSubcategoriaCategoria.SelectedValue != "-2")
    //{
    //  cod_subcategoria = Convert.ToInt32(ddownSubcategoriaCategoria.SelectedValue);
    //}
    //else
    //{
    //  cod_subcategoria = 0;
    //}

    alerta.gestionCategorias(OPC, cod_categoria, desc_categoria, modulo, archivo_asociado, cod_estado);

    cargaCategorias();
    descCategoria.Text = "";
    ddEstadosCategoria.SelectedIndex = 0;
    ddModulosCategoria.SelectedIndex = 0;
    ddArchivoAsociado.SelectedIndex = 0;
    //ddownSubcategoriaCategoria.SelectedIndex = 0;
  }
  protected void modificarCategoria_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int opc;
    string desc_categoria, modulo, archivo_asociado;
    int cod_estado;
    int cod_subcategoria;
    int cod_categoria;

    opc = 3;
    desc_categoria = descCategoria.Text.Trim();
    cod_categoria = Convert.ToInt32(Session["CodCategoria"]);
    modulo = ddModulosCategoria.SelectedValue;
    archivo_asociado = ddArchivoAsociado.SelectedValue;

    if (ddEstadosCategoria.SelectedValue != "0")
    {
      cod_estado = Convert.ToInt32(ddEstadosCategoria.SelectedValue);
    }
    else
    {
      cod_estado = 0;
    }

    //if (ddownSubcategoriaCategoria.SelectedValue != "0")
    //{
    //  cod_subcategoria = Convert.ToInt32(ddownSubcategoriaCategoria.SelectedValue);
    //}
    //else
    //{
    //  cod_subcategoria = 0;
    //}

    alerta.gestionCategorias(opc, cod_categoria, desc_categoria, modulo, archivo_asociado, cod_estado);

    //actualizando grilla posterior a la modificación

    cargaCategorias();
    descCategoria.Text = "";
    ddEstadosCategoria.SelectedIndex = 0;
    ddModulosCategoria.SelectedIndex = 0;
    ddArchivoAsociado.SelectedIndex = 0;
    //ddownSubcategoriaCategoria.SelectedIndex = 0;

  }
  protected void gridCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "Modificar")
    {
      int cod_estado;
      string desc_categoria, modulo, archivo_asociado;

      Session["CodCategoria"] = null;

      Session["CodCategoria"] = Convert.ToInt32(gridCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
      desc_categoria = Convert.ToString(gridCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
      modulo = Convert.ToString(gridCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
      archivo_asociado = Convert.ToString(gridCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
      cod_estado = Convert.ToInt32(gridCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);

      ddEstadosCategoria.SelectedValue = Convert.ToString(cod_estado);
      descCategoria.Text = HttpUtility.HtmlDecode(desc_categoria);
      ddModulosCategoria.SelectedValue = modulo;
      ddModulosCategoria_SelectedIndexChanged(sender, e);
      ddArchivoAsociado.SelectedValue = archivo_asociado;

      ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarCategoria').hide('fast')", true);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#modificarCategoria').show('fast')", true);
    }
  }

  #endregion

  #region gestionSubCategorias
  protected void agregarSubcategoria_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int OPC, cod_subcategoria, cod_categoria, cod_estado;
    string desc_subcategoria;

    OPC = 2;
    desc_subcategoria = Subcategoría.Text.Trim();
    cod_estado = Convert.ToInt32(ddownEstadoSubcategoria.SelectedValue);
    cod_categoria = Convert.ToInt32(ddownCategoriasSubcategorias.SelectedValue);

    cod_subcategoria = 0; //Se manda cero ya que actualmente esta subcategoría no existe.

    alerta.gestionSubcategorias(OPC, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado);

    cargaSubcategorias();
    Subcategoría.Text = "";
    ddownCategoriasSubcategorias.SelectedValue = "-2";
    ddownEstadoSubcategoria.SelectedValue = "-2";
  }
  protected void modificarSubcategoria_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int OPC, id_rel, cod_subcategoria, cod_categoria, cod_estado;
    string desc_subcategoria;

    OPC = 3;
    id_rel = Convert.ToInt32(Session["ID_REL"]);
    cod_subcategoria = Convert.ToInt32(Session["COD_SUBCATEGORIA"]);
    desc_subcategoria = Subcategoría.Text.Trim();
    cod_categoria = Convert.ToInt32(ddownCategoriasSubcategorias.SelectedValue);
    cod_estado = Convert.ToInt32(ddownEstadoSubcategoria.SelectedValue);

    alerta.gestionSubcategorias(OPC, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado);
    cargaSubcategorias();
    Subcategoría.Text = "";
    ddownCategoriasSubcategorias.SelectedValue = "-2";
    ddownEstadoSubcategoria.SelectedValue = "-2";
  }
  protected void gridSubCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "Modificar")
    {
      int cod_estado, cod_categoria, cod_subcategoria;
      string desc_subcategoria;
      Session["ID_REL"] = null;


      // [0] ID REL
      // [1] COD_SUBCATEGORIA
      // [2] DESC_SUBCATEGORIA
      // [3] COD_CATEGORIA
      // [4] DESC_CATEGORIA
      // [5] COD_ESTADO
      // [6] DESC_ESTADO

      Session["ID_REL"] = Convert.ToInt32(gridSubCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
      Session["COD_SUBCATEGORIA"] = Convert.ToInt32(gridSubCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
      desc_subcategoria = Convert.ToString(gridSubCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
      cod_categoria = Convert.ToInt32(gridSubCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
      cod_estado = Convert.ToInt32(gridSubCategorias.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);

      Subcategoría.Text = HttpUtility.HtmlDecode(desc_subcategoria);
      ddownEstadoSubcategoria.SelectedValue = Convert.ToString(cod_estado);
      ddownCategoriasSubcategorias.SelectedValue = Convert.ToString(cod_categoria);

      ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarSubcategoria').hide('fast')", true);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#modificarSubcategoria').show('fast')", true);
    }
  }

  #endregion

  #region gestionTipo
  protected void agregarTipo_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int opc, cod_tipoalerta, cod_estado;
    string desc_tipo;

    opc = 2;
    cod_tipoalerta = 0;
    desc_tipo = descTipoAlerta.Text.Trim();
    cod_estado = Convert.ToInt32(ddownEstadoTipoAlerta.SelectedValue);

    alerta.gestionTipos(opc, cod_tipoalerta, desc_tipo, cod_estado);

    cargaTipos();
    descTipoAlerta.Text = "";
  }
  protected void modificarTipo_Click(object sender, EventArgs e)
  {
    Alertas alerta = new Alertas();
    DataTable dt = new DataTable();

    int opc, cod_tipo, cod_estado;
    string desc_tipo;

    opc = 3;
    cod_tipo = Convert.ToInt32(Session["CodTipo"]);
    cod_estado = Convert.ToInt32(ddownEstadoTipoAlerta.SelectedValue);
    desc_tipo = descTipoAlerta.Text.Trim();

    alerta.gestionTipos(opc, cod_tipo, desc_tipo, cod_estado);

    cargaTipos();

    descTipoAlerta.Text = "";

  }
  protected void gridTiposAlerta_RowCommand(object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "Modificar")
    {
      int cod_estado;
      string desc_tipo;

      Session["CodTipo"] = null;

      Session["CodTipo"] = Convert.ToInt32(gridTiposAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

      desc_tipo = Convert.ToString(gridTiposAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
      cod_estado = Convert.ToInt32(gridTiposAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);

      descTipoAlerta.Text = HttpUtility.HtmlDecode(desc_tipo);
      ddownEstadoTipoAlerta.SelectedValue = Convert.ToString(cod_estado);

      ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarTipo').hide('fast')", true);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#modificarTipo').show('fast')", true);
    }
  }
  #endregion

  #region gestionDetalles
  //protected void agregarDetalle_Click(object sender, EventArgs e)
  //{
  //  Alertas alerta = new Alertas();
  //  DataTable dt = new DataTable();

  //  int opc, cod_detalle, cod_estado;
  //  string desc_detalle, desc_encabezado;

  //  opc = 2;
  //  cod_detalle = 0;
  //  desc_detalle = descDetalle.InnerText.Trim();
  //  desc_encabezado = descEncabezado.Text.Trim();
  //  cod_estado = Convert.ToInt32(ddownEstadosDetalle.SelectedValue);

  //  alerta.gestionDetalles(opc, cod_detalle, desc_encabezado, desc_detalle, cod_estado);

  //  cargaDetalles();
  //  descEncabezado.Text = "";
  //  descDetalle.InnerText = "";
  //}
  //protected void modificardetalle_Click(object sender, EventArgs e)
  //{
  //  Alertas alerta = new Alertas();
  //  DataTable dt = new DataTable();

  //  int opc, cod_detalle, cod_estado;
  //  string desc_encabezado, desc_detalle;

  //  opc = 3;
  //  cod_detalle = Convert.ToInt32(Session["CodDetalle"]);
  //  cod_estado = Convert.ToInt32(ddownEstadosDetalle.SelectedValue);
  //  desc_detalle = descDetalle.InnerText.Trim();
  //  desc_encabezado = descEncabezado.Text.Trim();

  //  alerta.gestionDetalles(opc, cod_detalle, desc_encabezado, desc_detalle, cod_estado);

  //  cargaDetalles();

  //  descDetalle.InnerText = "";
  //  descEncabezado.Text = "";
  //  ddownEstadosDetalle.SelectedValue = "0";
  //}
  //protected void gridDetallesAlerta_RowCommand(object sender, GridViewCommandEventArgs e)
  //{
  //  if (e.CommandName == "Modificar")
  //  {
  //    int cod_estado;
  //    string desc_encabezado, desc_detalle;

  //    Session["CodDetalle"] = null;

  //    Session["CodDetalle"] = Convert.ToInt32(gridDetallesAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

  //    desc_encabezado = Convert.ToString(gridDetallesAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
  //    desc_detalle = Convert.ToString(gridDetallesAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
  //    cod_estado = Convert.ToInt32(gridDetallesAlerta.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);

  //    descEncabezado.Text = desc_encabezado;
  //    descDetalle.InnerText = desc_detalle;
  //    ddownEstadosDetalle.SelectedValue = Convert.ToString(cod_estado);


  //    ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarDetalle').hide('fast')", true);
  //    ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#modificardetalle').show('fast')", true);
  //  }
  //}
  #endregion

  #region gestionAlertasManual
  protected void gridAlertas_RowCommand(object sender, GridViewCommandEventArgs e)
  {
      #region Accion
      string cinstitucion,
    cproyecto,
    rut,
    nombres,
    apepat,
    apemat,
    fingreso,
    fnacimiento;
      int codie,
        cnino;


      if (e.CommandName == "accion")
      {

          ninocoll nino = new ninocoll();

          int icodie;
          int cod_nino;
          int cod_proyecto;
          int cod_institucion;
          string modulo, archivo_asociado;

          Session["NNA"] = null;

          nino n = new nino();

          DataTable dt = new DataTable();


          //icodie = ;

          if (Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[16].Text) == "&nbsp;")
          {
              icodie = 0;
          }
          else
          {
              icodie = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[16].Text);
          }

          if (Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text) == "&nbsp;")
          {
              cod_proyecto = 0;
          }
          else
          {
              cod_proyecto = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
          }


          if (Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text) == "&nbsp;")
          {
              cod_institucion = 0;
          }
          else
          {
              cod_institucion = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
          }

          modulo = Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text);
          archivo_asociado = Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[11].Text);


          //Generar ruta según modulo y archivo al que pertenece la alerta seleccionada

          if (icodie != 0)
          {
              // Si hay un ICODIE ingresado, se obtienen los datos del niño y se carga la variable de session NNA, para aplicar lógica de All in One
         
              dt = nino.callto_getingresos_egresos(icodie);

              cod_nino = Convert.ToInt32(dt.Rows[0][2].ToString());

              n = nino.GetNinos(cod_nino);

              codie = icodie;
              cnino = n.CodNino;
              rut = n.rut;
              nombres = n.Nombres;
              apepat = n.Apellido_Paterno;
              apemat = n.Apellido_Materno;
              cproyecto = Convert.ToString(cod_proyecto);
              cinstitucion = Convert.ToString(cod_institucion);
              fnacimiento = Convert.ToString(n.FechaNacimiento);
              fingreso = Convert.ToString(n.fchingdesde);

              oNNA NNA = new oNNA(cinstitucion, cproyecto, codie, cnino, rut, nombres, apepat, apemat, fingreso, fnacimiento);
              Session["NNA"] = NNA;
              Response.Redirect("../" + modulo + "/" + archivo_asociado + "?icodie=" + codie + "");
          }
          else
          {
              Response.Redirect("../" + modulo + "/" + archivo_asociado + "");
          }
      }
      #endregion
      #region modificarAlerta
      if (e.CommandName == "Modificar")
      {
          int opc, cod_alerta, id_rel_catsubcat,cod_categoria, cod_subcategoria, cod_tipo, cod_depto, rol, cod_proyecto, cod_institucion, cod_estado;
          string icodie, desc_encabezado, desc_cuerpo;

          DataTable dt = new DataTable();
          Alertas alerta = new Alertas();

          Session["COD_ALERTA"] = null;


          cod_alerta = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);

          id_rel_catsubcat = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
          cod_categoria = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
          cod_subcategoria = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
          cod_depto = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
          cod_tipo = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
          rol = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
          cod_proyecto = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
          cod_institucion = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
          cod_estado = Convert.ToInt32(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);

          desc_encabezado = Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[12].Text);
          desc_cuerpo = Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[13].Text);

          icodie = Convert.ToString(gridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[16].Text);

          if (icodie == "&nbsp;")
          {
              icodie = "";
          }

          
          Session["COD_ALERTA"] = cod_alerta;
          
          ddownCategorias.SelectedValue = Convert.ToString(cod_categoria);
          ddownCategorias_SelectedIndexChanged(sender, e);
          ddownSubcategorias.SelectedValue = Convert.ToString(cod_subcategoria);
          ddownTipos.SelectedValue = Convert.ToString(cod_tipo);
          ddownEstadosAlerta.SelectedValue = Convert.ToString(cod_estado);
          encabezadoPersonalizado.Text = HttpUtility.HtmlDecode(desc_encabezado);
          cuerpoPersonalizado.Text = HttpUtility.HtmlDecode(desc_cuerpo);
          ddownRol.SelectedValue = Convert.ToString(rol);
          ICODIE.Text = HttpUtility.HtmlDecode(icodie);
          ddownDeptos.SelectedValue = Convert.ToString(cod_depto);
          ddownInstituciones.SelectedValue = Convert.ToString(cod_institucion);
          ddownInstituciones_SelectedIndexChanged(sender, e);
          ddownProyectos.SelectedValue = Convert.ToString(cod_proyecto);

          modificarAlertaManual.Visible = true;
          agregarAlertaManual.Visible = false;


          //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarAlertaManual').hide('fast');$('#modificarAlertaManual').show('fast');", true);
      }
      #endregion
  }

  protected void cargaDropdownlistDeptosAlertas()
  {
      parcoll par = new parcoll();

      DataView dv = new DataView(par.GetparDepartamentosSENAME());

      ddownDeptos.DataSource = dv;
      dv.Table.Rows.Add("1", "Seleccionar");
      ddownDeptos.DataTextField = "Nombre";
      ddownDeptos.DataValueField = "CodDepartamentosSENAME";
      dv.Sort = "CodDepartamentosSENAME";
      ddownDeptos.DataBind();
  }

  private void getinstituciones()
  {
      institucioncoll ncoll = new institucioncoll();
      DataView dv = new DataView(ncoll.GetData());
      ddownInstituciones.DataSource = dv;
      ddownInstituciones.DataTextField = "Nombre";
      ddownInstituciones.DataValueField = "Codigo Institución";
      dv.Sort = "Nombre";
      ddownInstituciones.DataBind();

  }

  protected void ddownInstituciones_SelectedIndexChanged(object sender, EventArgs e)
  {
      getproyectosxcod();
      //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarAlertaManual').hide();$('#modificarAlertaManual').show();", true);
  }

  protected void ddownCategorias_SelectedIndexChanged(object sender, EventArgs e)
  {
      Alertas x = new Alertas();

      int opc;
      int cod_subcategoria;
      string desc_subcategoria;
      int cod_categoria;
      int cod_estado;

      opc = 5;
      cod_subcategoria = 0;
      desc_subcategoria = "";
      cod_categoria = Convert.ToInt32(ddownCategorias.SelectedValue);
      cod_estado = 0;

      DataView dv = new DataView(x.getSubcategoriaxCategoria(opc, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado));

      ddownSubcategorias.DataSource = dv;
      ddownSubcategorias.DataTextField = "DESC_SUBCATEGORIA";
      ddownSubcategorias.DataValueField = "COD_SUBCATEGORIA";
      dv.Sort = "COD_SUBCATEGORIA";
      ddownSubcategorias.DataBind();

      //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#agregarAlertaManual').hide();$('#modificarAlertaManual').show();", true);
      //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#mensajeTipo').hide(); $('#mensajePersonalizado').hide();", true);
  }

  protected void agregarAlertaManual_Click(object sender, EventArgs e)
  {
      Alertas alerta = new Alertas();
      DataTable dt = new DataTable();

      int opc, cod_alerta, id_rel_catsubcat, cod_categoria, cod_subcategoria, cod_tipo, 
          //cod_detalle,
          cod_depto, rol, cod_proyecto, cod_institucion, cod_estado;

      string desc_encabezado, desc_cuerpo, icodie;

      opc = 2;
      
      cod_alerta = 0;
      cod_categoria = Convert.ToInt32(ddownCategorias.SelectedValue);
      cod_subcategoria = Convert.ToInt32(ddownSubcategorias.SelectedValue);

      dt = alerta.getCodCategoriaCodSubcategoria(1, cod_categoria, cod_subcategoria);

      id_rel_catsubcat = Convert.ToInt32(dt.Rows[0][0].ToString());

      cod_tipo = Convert.ToInt32(ddownTipos.SelectedValue);
      //cod_detalle = Convert.ToInt32(ddownEncabezadoDetalle.SelectedValue);
      cod_institucion = Convert.ToInt32(ddownInstituciones.SelectedValue);

      rol = Convert.ToInt32(ddownRol.SelectedValue);

      cod_estado = Convert.ToInt32(ddownEstadosAlerta.SelectedValue);

      desc_encabezado = encabezadoPersonalizado.Text;
      desc_cuerpo = cuerpoPersonalizado.Text;

      icodie = ICODIE.Text.Trim();
      cod_depto = Convert.ToInt32(ddownDeptos.SelectedValue);
      cod_proyecto = Convert.ToInt32(ddownProyectos.SelectedValue);

      alerta.gestionAlertas(opc, cod_alerta, id_rel_catsubcat, cod_tipo, desc_encabezado,
                                desc_cuerpo, cod_depto, rol, icodie, cod_proyecto, cod_institucion, cod_estado);

      ddownCategorias.SelectedValue = "-2";
      ddownSubcategorias.SelectedValue = "-2";
      ddownTipos.SelectedValue = "-2";
      //ddownEncabezadoDetalle.SelectedValue = "-2";
      encabezadoPersonalizado.Text = "";
      cuerpoPersonalizado.Text = "";
      ddownRol.SelectedIndex = 0;
      ICODIE.Text = "";
      ddownDeptos.SelectedValue = "1";
      ddownInstituciones.SelectedValue = "0";
      ddownProyectos.SelectedValue = "0";
      cargaGridAlertas();
  }

  private void getproyectosxcod()
  {
      proyectocoll pcoll = new proyectocoll();
      DataTable dtproy = pcoll.GetProyectoxInst(Convert.ToInt32(ddownInstituciones.SelectedValue));
      DataView dv = new DataView(dtproy);
      dv.Sort = "CodProyecto";
      // <---------- DPL ---------->  09-08-2010
      //dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
      // <---------- DPL ---------->  09-08-2010

      ddownProyectos.DataSource = dv;
      ddownProyectos.DataTextField = "Nombre";
      ddownProyectos.DataValueField = "CodProyecto";
      ddownProyectos.DataBind();
      if (dv.Count == 2)
      {
          ddownProyectos.SelectedIndex = 1;
          // ddown002_SelectedIndexChanged(new object(), new EventArgs());
      }
      
  }

  protected void ddModulosCategoria_SelectedIndexChanged(object sender, EventArgs e)
  {
      string moduloSeleccionado;

      moduloSeleccionado = ddModulosCategoria.SelectedItem.Text;
      DirectoryInfo fileInfo = new DirectoryInfo(Server.MapPath("~/" + moduloSeleccionado + "/"));
      FileInfo[] fi = fileInfo.GetFiles("*.aspx");

      ddArchivoAsociado.DataSource = fi;
      ddArchivoAsociado.DataValueField = "Name";
      ddArchivoAsociado.DataBind();

      ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#divArchivoAsociado').show('fast');$('#agregarCategoria').hide();$('#modificarCategoria').show();", true);
  }

  protected void modificarAlertaManual_Click(object sender, EventArgs e)
  {
      Alertas alerta = new Alertas();
      DataTable dt = new DataTable();

      int opc, cod_alerta, id_rel_catsubcat, cod_categoria, cod_subcategoria, cod_tipo,
          //cod_detalle,
          cod_depto, rol, cod_proyecto, cod_institucion, cod_estado;

      string desc_encabezado, desc_cuerpo, icodie;

      opc = 3;

      cod_alerta = Convert.ToInt32(Session["COD_ALERTA"]);
      cod_categoria = Convert.ToInt32(ddownCategorias.SelectedValue);
      cod_subcategoria = Convert.ToInt32(ddownSubcategorias.SelectedValue);

      dt = alerta.getCodCategoriaCodSubcategoria(1, cod_categoria, cod_subcategoria);

      id_rel_catsubcat = Convert.ToInt32(dt.Rows[0][0].ToString());

      cod_tipo = Convert.ToInt32(ddownTipos.SelectedValue);
      //cod_detalle = Convert.ToInt32(ddownEncabezadoDetalle.SelectedValue);
      cod_institucion = Convert.ToInt32(ddownInstituciones.SelectedValue);

      rol = Convert.ToInt32(ddownRol.SelectedValue);

      cod_estado = Convert.ToInt32(ddownEstadosAlerta.SelectedValue);

      desc_encabezado = encabezadoPersonalizado.Text;
      desc_cuerpo = cuerpoPersonalizado.Text;

      icodie = ICODIE.Text.Trim();
      cod_depto = Convert.ToInt32(ddownDeptos.SelectedValue);
      cod_proyecto = Convert.ToInt32(ddownProyectos.SelectedValue);

      alerta.gestionAlertas(opc, cod_alerta, id_rel_catsubcat, cod_tipo, desc_encabezado,
                                desc_cuerpo, cod_depto, rol, icodie, cod_proyecto, cod_institucion, cod_estado);

      ddownCategorias.SelectedValue = "-2";
      ddownSubcategorias.SelectedValue = "-2";
      ddownTipos.SelectedValue = "-2";
      //ddownEncabezadoDetalle.SelectedValue = "-2";
      encabezadoPersonalizado.Text = "";
      cuerpoPersonalizado.Text = "";
      ddownRol.SelectedIndex = 0;
      ICODIE.Text = "";
      ddownDeptos.SelectedValue = "1";
      ddownInstituciones.SelectedValue = "0";
      ddownProyectos.SelectedValue = "0";
      modificarAlertaManual.Visible = false;
      agregarAlertaManual.Visible = true;
      cargaGridAlertas();
  }

  #endregion

  #region GestionModulos
  //protected void agregarModulo_Click(object sender, EventArgs e)
  //{
  //  Alertas alerta = new Alertas();
  //  DataTable dt = new DataTable();

  //  int opc, cod_modulo;
  //  string desc_modulo, ruta_modulo;

  //  opc = 2;
  //  cod_modulo = 0;
  //  desc_modulo = descModulo.Text.Trim();
  //  ruta_modulo = rutaModulo.Text.Trim();

  //  alerta.gestionModulos(opc, cod_modulo, desc_modulo, ruta_modulo);

  //  descModulo.Text = "";
  //  rutaModulo.Text = "";


  //}
  protected void modificarModulo_Click(object sender, EventArgs e)
  {

  }
  #endregion

  #region GestionParametros

  #endregion
  

  protected void ddownEncabezadoDetalle_SelectedIndexChanged(object sender, EventArgs e)
  {
    int cod_detalle;

    Alertas x = new Alertas();
    DataTable dt = new DataTable();

    //cod_detalle = Convert.ToInt32(ddownEncabezadoDetalle.SelectedItem.Value);

    //dt = x.getDetalles(5, cod_detalle, "", "", 0);

    int i;
    string desc_detalle;

    foreach (DataRow row in dt.Rows)
    {
      //desc_detalle = row[0].ToString(); //CodigoDetalle
      //desc_detalle = row[1].ToString(); //Encabezado
      desc_detalle = row[2].ToString(); //Cuerpo
      //desc_detalle = row[3].ToString(); //Codigo Estado
      //desc_detalle = row[4].ToString(); //Desc. Estado

      //descDetalleAlertaManual.Text = desc_detalle;
    }

  }

  protected void gridDetallesAlerta_RowDataBound(object sender, GridViewRowEventArgs e)
  {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        //int icodie;
        //ninocoll n = new ninocoll();
        //DataTable dt = new DataTable();

        //icodie = Convert.ToInt32((e.Row.DataItem as DataRowView)["ICODIE"].ToString());

        //dt = n.callto_getingresos_egresos(icodie);



        //e.Row.Attributes.Add("onmouseover", "");

        e.Row.ToolTip = "Cuerpo del Mensaje: " + (e.Row.DataItem as DataRowView)["DESC_DETALLE"].ToString() + "";
    }
  }
 

  
  //protected void tipoMensaje_SelectedIndexChanged(object sender, EventArgs e)
  //{
  //  if (tipoMensaje.SelectedValue == "1")
  //  {
  //    mensajeTipo.Visible = true;
  //    mensajePersonalizado.Visible = false;
  //  }
  //  else if (tipoMensaje.SelectedValue == "2")
  //  {
  //    mensajeTipo.Visible = false;
  //    mensajePersonalizado.Visible = true;
  //  }
  //  else
  //  {
  //    mensajePersonalizado.Visible = false;
  //    mensajeTipo.Visible = false;
  //  }


  //}


  //protected void agregarAlertaAutomatica_Click(object sender, EventArgs e)
  //{
  //    Alertas a = new Alertas();
  //    DataTable dt = new DataTable();

  //    int id_relacion_categoria_subcategoria, cod_tipo, cod_depto, rol, cod_proyecto, cod_institucion;

  //    int cod_categoria, cod_subcategoria;

  //    string desc_encabezado, desc_cuerpo, icodie;

  //    //Si necesito obtener el ID_Relacion_categoria, hay que hacerlo de la siguiente manera

  //    // hay que tener claro cuales son los codigos de categoría y subcategoría


  //    //Estas se pueden obtener del módulo de alertas e incluso generar la relación en el módulo

  //    cod_categoria = 1; //Diagnóstico, por ejemplo
  //    cod_subcategoria = 1; // Sociofamiliar, por ejemplo

  //    //Entonces llamamos un metodo de la clase de alertas de la siguiente forma y lo asignamos a un datatable (lo pueden hacer de otra manera, la idea es obtener los datos que entregará el SP

  //    dt = a.getIDRelCategoriaSubcategoria(cod_categoria, cod_subcategoria);


  //    //Tendremos cargado el ID_REL_CATSUBCAT en el datatable, correpsondiente al ID de la relación

  //    //asignamos el ID_REL_CATSUBCAT a variable

  //    id_relacion_categoria_subcategoria = Convert.ToInt32(dt.Rows[0][0].ToString()); //Este método hace que el SP traiga el ID y solo el ID, por lo que siempre vendrá en la primera posicion del datatable

  //    //De caso contrario, si necesitaramos el cod_categoria y el cod_subcategoria, y disponemos del id_relacion_categoria_proyecto, podemos hacer lo siguiente

  //    //dt = a.getCodCategoriaCodSubcategoria(id_relacion_categoria_subcategoria); // Este metodo nos retornara una fila con el cod_categoria y cod_subcategoría asociados al ID que usamos como parametro


  //    //// Siempre en la posicion 0 vendrá el cod_categoria y en la posicion 1 vendrá el cód_subcategoria

  //    //cod_categoria = Convert.ToInt32(dt.Rows[0][0].ToString());
  //    //cod_subcategoria = Convert.ToInt32(dt.Rows[0][1].ToString());


  //    //Teniendo el ID de relación, podemos seguir añadiendo los parametros necesarios para generar una nueva alerta

  //    //Asignamos los valores correspondientes a los parametros

  //    cod_tipo = 1; // 1 informativo, 2 Advertencia, 3 Urgente, 4 Activa
  //    desc_encabezado = "El encabezado de la alerta"; //El encabezado tiene como máximo en la BD de 30 caracteres, para no distorsionar el grid
  //    desc_cuerpo = "el cuerpo de la alerta Prueba"; //el cuerpo en la base de datos es de 100 carácteres
  //    cod_depto = 7; // 6 DEPRODE, 7 Justicia Juvenil, 8 Adopción, 9 Primera Infancia, sacados de la parDepartamentosSename
  //    rol = 267; // El 267 es de técnico de proyecto, pero hay un combo en el cual se encuentran los roles cargados en el módulo, añadiré a la documentación un listado con los roles y descripciones
  //    icodie = "4479891"; // el dato universal, sirve para obtener los datos del niño y cargarlos en la
  //    //                     session para cargar el All in One donde se encuentre disponible, puede ir vacío si no es necesario, direccionara de todas formas al´formulario relacionado
  //    cod_proyecto = 1010078; // El código del proyecto, puede ir vacío también, pero si se pone vacío el all in one puede que no funcione correctamente.
  //    cod_institucion = 6050; // El´código de la institución, también puede ir vacío pero no es recomendado si se aplicará All in One.


  //    a.agregarNuevaAlerta(id_relacion_categoria_subcategoria, cod_tipo, desc_encabezado, desc_cuerpo, cod_depto, rol, icodie, cod_proyecto, cod_institucion);

  //}
}