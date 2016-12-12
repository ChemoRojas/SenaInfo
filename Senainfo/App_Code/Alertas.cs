using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
/// <summary>
/// Descripción breve de Alertas
/// </summary>
public class Alertas
{
	public Alertas()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

  //OPC!
  //OPC = 1 -> Índica al procedimiento traer la data correspondiente al módulo
  //OPC = 2 -> Índica al procedimiento insertar un nuevo valor en el módulo que corresponde
  //OPC = 3 -> Índica al procedimiento modificar el valor del elemento seleccionado en el módulo
  //OPC = 4 -> Índica al procedimiento que desactive el valor seleccionado en el módulo
  //OPC = 5 -> Índica al procedimiento que reactive el valor seleccionado en el módulo
  // No elimina datos de la BD en ninguna de las opciones, ya que puede requerir que se vuelva a reactivar cualquiera de los elementos
  // esto implica que se puedan utilizar los datos a modo de historico y/o auditoría

  #region gestionEstados
  public DataTable getDropdownEstados()
  {
    Conexiones con = new Conexiones();
    DataTable dt = new DataTable();

    dt = con.TraerDataTable("GESTION_ALERTAS_ESTADOS", 1, "", 0);
    DataRow dr = dt.NewRow();
    dr[0] = -2;
    dr[1] = "Seleccionar";
    dt.Rows.Add(dr);

    return dt;
  }
   public DataTable getEstadosAlerta(int OPC, string desc_estado, int cod_estado)
  {
    Conexiones con = new Conexiones();
    DataTable dt = new DataTable();

    dt = con.TraerDataTable("GESTION_ALERTAS_ESTADOS", 1, "", 0);

    return dt;
  }
   public void gestionEstadosAlerta(int opc, string desc_estado, int cod_estado)
  {
    Conexiones con = new Conexiones();
    DbDataReader dr = null;

    if (cod_estado != 0)
    {
      DbParameter[] parametros = {
                                 con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                 con.parametros("@DESC_ESTADO", SqlDbType.VarChar, 255, desc_estado),
                                 con.parametros("@COD_ESTADO", SqlDbType.Int, 10, cod_estado)
                               };
      con.ejecutarProcedimiento("GESTION_ALERTAS_ESTADOS", parametros, out dr);
      con.Desconectar();
    }
    else
    {
      DbParameter[] parametros = {
                                   con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                   con.parametros("@DESC_ESTADO",SqlDbType.VarChar, 255, desc_estado),
                                   con.parametros("@COD_ESTADO", SqlDbType.Int, 10, 0)
                                 };
      con.ejecutarProcedimiento("GESTION_ALERTAS_ESTADOS", parametros, out dr);
      con.Desconectar();
    }
  }
  #endregion

  #region GestionModulos
   public void gestionModulos(int opc, int cod_modulo, string desc_modulo, string ruta_modulo)
   {
     Conexiones con = new Conexiones();
     DbDataReader dr = null;

     DbParameter[] parametros = {
                                  con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                  con.parametros("@COD_MODULO", SqlDbType.Int, 10, cod_modulo),
                                  con.parametros("@DESC_MODULO", SqlDbType.VarChar, 255, desc_modulo),
                                  con.parametros("@RUTA_MODULO", SqlDbType.VarChar, 255, ruta_modulo)
                                };
     con.ejecutarProcedimiento("GESTION_ALERTAS_MODULOS", parametros, out dr);
     con.Desconectar();
   }
   #endregion

  #region gestionCategorias
   public DataTable getDropdownCategorias(int OPC, int cod_categoria, string desc_categoria, string modulo, string archivo_asociado, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTAS_CATEGORIAS", OPC, cod_categoria, desc_categoria, modulo, archivo_asociado, cod_estado);
     
     DataRow dr = dt.NewRow();
     dr[0] = -2;
     dr[1] = " Seleccionar ";
     dt.Rows.Add(dr);

     return dt; 
   }
   public DataTable getCategorias(int OPC, int cod_categoria, string desc_categoria,string modulo, string archivo_asociado, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTAS_CATEGORIAS", OPC, cod_categoria, desc_categoria, modulo, archivo_asociado, cod_estado);

     return dt;
   }
   public void gestionCategorias(int opc, int cod_categoria, string desc_categoria, string modulo, string archivo_asociado, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DbDataReader dr = null;

       DbParameter[] parametros = {
                                 con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                 con.parametros("@COD_CATEGORIA", SqlDbType.Int, 10, cod_categoria),
                                 con.parametros("@DESC_CATEGORIA", SqlDbType.VarChar, 255, desc_categoria),
                                 con.parametros("@MODULO", SqlDbType.VarChar, 255, modulo),
                                 con.parametros("@ARCHIVO_ASOCIADO", SqlDbType.VarChar,255, archivo_asociado),
                                 con.parametros("@COD_ESTADO", SqlDbType.Int, 10, cod_estado)
                               };
       con.ejecutarProcedimiento("GESTION_ALERTAS_CATEGORIAS", parametros, out dr);
       con.Desconectar();
     //else
     //{
     //  DbParameter[] parametros = {
     //                              con.parametros("@OPC", SqlDbType.Int, 10, opc),
     //                              con.parametros("@CODCATEGORIA", SqlDbType.Int, 10, 0),
     //                              con.parametros("@DESC_ESTADO",SqlDbType.VarChar, 255, desc_categoria),
     //                              con.parametros("@COD_ESTADO", SqlDbType.Int, 10, cod_estado)
     //                              //con.parametros("@CODSUBCATEGORIA", SqlDbType.Int, 10, cod_subcategoria)
     //                            };
     //  con.ejecutarProcedimiento("GESTION_ALERTAS_CATEGORIAS", parametros, out dr);
     //  con.Desconectar();
     //}
   }
  #endregion

  #region gestionSubCategorias
   public DataTable getDropdownSubcategorias(int opc, int cod_subcategoria, string desc_subcategoria, int cod_categoria, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTAS_SUBCATEGORIA", opc, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado);

     DataRow dr = dt.NewRow();
     dr[0] = -2;
     dr[1] = " Seleccionar ";
     dt.Rows.Add(dr);

     return dt; 
   }
   public DataTable getSubcategorias(int OPC, int cod_subcategoria, string desc_subcategoria, int cod_categoria, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTAS_SUBCATEGORIA", OPC, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado);

     return dt;
   }
   public void gestionSubcategorias(int opc, int cod_subcategoria, string desc_subcategoria, int cod_categoria, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DbDataReader dr = null;

       DbParameter[] parametros = {
                                    con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                    con.parametros("@CODSUBCATEGORIA", SqlDbType.Int, 10, cod_subcategoria),
                                    con.parametros("@DESCSUBCATEGORIA", SqlDbType.VarChar, 255, desc_subcategoria),
                                    con.parametros("@COD_CATEGORIA", SqlDbType.Int, 10, cod_categoria),
                                    con.parametros("@COD_ESTADO", SqlDbType.Int, 255, cod_estado)
                                  };
       con.ejecutarProcedimiento("GESTION_ALERTAS_SUBCATEGORIA", parametros, out dr);
       con.Desconectar(); 
  }
   public DataTable getSubcategoriaxCategoria(int opc, int cod_subcategoria, string desc_subcategoria, int cod_categoria, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTAS_SUBCATEGORIA", opc, cod_subcategoria, desc_subcategoria, cod_categoria, cod_estado);
     DataRow dr = dt.NewRow();
     dr[0] = -2;
     dr[1] = " Seleccionar ";
     dt.Rows.Add(dr);
     return dt;
   }
  #endregion

  #region gestionTipos
   public DataTable getDropdownTipos(int OPC, int cod_tipo, string desc_tipo, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTA_TIPO", OPC, cod_tipo, desc_tipo, cod_estado);
     DataRow dr = dt.NewRow();
     dr[0] = -2;
     dr[1] = " Seleccionar ";
     dt.Rows.Add(dr);
     return dt;
   }
   public DataTable getTipos(int OPC, int cod_tipo, string desc_tipo, int cod_estado)
   {
     Conexiones con = new Conexiones();
     DataTable dt = new DataTable();

     dt = con.TraerDataTable("GESTION_ALERTA_TIPO", OPC, cod_tipo, desc_tipo, cod_estado);

     return dt;
   }
   public void gestionTipos(int opc, int cod_tipoalerta, string desc_tipo, int cod_estado)
   {
     Conexiones con = new Conexiones();

     DbDataReader dr = null;

     DbParameter[] parametros = {
                                  con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                  con.parametros("@COD_TIPOALERTA", SqlDbType.Int, 10, cod_tipoalerta),
                                  con.parametros("@DESC_TIPOALERTA", SqlDbType.VarChar,250, desc_tipo),
                                  con.parametros("@COD_ESTADO", SqlDbType.Int, 10, cod_estado)
                                };
     con.ejecutarProcedimiento("GESTION_ALERTA_TIPO", parametros, out dr);
     con.Desconectar();
     
   }
  #endregion

  #region gestionDetalles
   //public DataTable getDetalles(int OPC, int cod_detalle, string desc_encabezado, string desc_detalle, int cod_estado)
   //{
   //  Conexiones con = new Conexiones();
   //  DataTable dt = new DataTable();

   //  if (OPC == 1 || OPC == 5)
   //  {
   //    dt = con.TraerDataTable("GESTION_ALERTA_DETALLES", OPC, cod_detalle, desc_encabezado, desc_detalle, cod_estado);
   //  }

   //  if (OPC == 4)
   //  {
   //    dt = con.TraerDataTable("GESTION_ALERTA_DETALLES", OPC, cod_detalle, desc_encabezado, desc_detalle, cod_estado);
   //    DataRow dr = dt.NewRow();
   //    dr[0] = -2;
   //    dr[1] = " Seleccionar ";
   //    dt.Rows.Add(dr);
   //  }

   //  return dt;
   //}
   //public void gestionDetalles(int opc, int cod_detalle, string desc_encabezado, string desc_detalle, int cod_estado)
   //{

   // Conexiones con = new Conexiones();
   // DbDataReader dr = null;

   // DbParameter[] parametros = {
   //                              con.parametros("@OPC", SqlDbType.Int, 10, opc),
   //                              con.parametros("@COD_TIPOALERTA", SqlDbType.Int, 10, cod_detalle),
   //                              con.parametros("@DESC_ENCABEZADO", SqlDbType.VarChar, 255, desc_encabezado),
   //                              con.parametros("@DESC_DETALLE", SqlDbType.VarChar,255, desc_detalle),
   //                              con.parametros("@COD_ESTADO", SqlDbType.Int, 10, cod_estado)
   //                             };

   // con.ejecutarProcedimiento("GESTION_ALERTA_DETALLES", parametros, out dr);
   // con.Desconectar();
   //}
  #endregion

  #region gestionAlertasManual
    public void gestionAlertas(int opc, int cod_alerta, int id_rel, int cod_tipo, string desc_encabezado,
                                string desc_cuerpo, int cod_depto, int rol, string icodie, int cod_proyecto, int cod_institucion, int cod_estado)
  {
    Conexiones con = new Conexiones();
    DbDataReader dr = null;

    DbParameter[] parametros = {
                                 con.parametros("@OPC", SqlDbType.Int, 10, opc),
                                 con.parametros("@COD_ALERTA", SqlDbType.Int, 10, cod_alerta),
                                 con.parametros("@ID_REL", SqlDbType.Int, 10, id_rel),
                                 //con.parametros("@COD_SUBCATEGORIA", SqlDbType.Int, 10, cod_subcategoria),
                                 con.parametros("@COD_TIPO", SqlDbType.Int, 10, cod_tipo),
                                 con.parametros("@DESC_ENCABEZADO", SqlDbType.VarChar,25, desc_encabezado),
                                 con.parametros("@DESC_CUERPO", SqlDbType.VarChar,255, desc_cuerpo),
                                 //con.parametros("@COD_DETALLE", SqlDbType.Int, 10, cod_detalle),
                                 con.parametros("@COD_DEPTO", SqlDbType.Int, 10, cod_depto),
                                 con.parametros("@ROL", SqlDbType.Int, 10, rol),
                                 con.parametros("@ICODIE", SqlDbType.VarChar, 255, icodie),
                                 con.parametros("@COD_PROYECTO", SqlDbType.Int, 10, cod_proyecto),
                                 con.parametros("@COD_INSTITUCION", SqlDbType.Int, 10, cod_institucion),
                                 con.parametros("@COD_ESTADO", SqlDbType.Int, 10, cod_estado)
                                 };
      
    con.ejecutarProcedimiento("GESTION_ALERTAS", parametros, out dr);
    con.Desconectar();
  }


    public DataTable getCodCategoriaCodSubcategoria(int id_rel_catsubcat)
    {

        Conexiones con = new Conexiones();
        DataTable dt = new DataTable();

        dt = con.TraerDataTable("GESTION_ALERTAS_REL_CATEGORIA_SUBCATEGORIA", 2, id_rel_catsubcat, 0,0);

        return dt;
    }

    public DataTable getIDRelCategoriaSubcategoria(int cod_categoria, int cod_subcategoria)
    {
        Conexiones con = new Conexiones();
        DataTable dt = new DataTable();

        dt = con.TraerDataTable("GESTION_ALERTAS_REL_CATEGORIA_SUBCATEGORIA", 1, 0, cod_categoria, cod_subcategoria);

        return dt;
    }

    public DataTable getDropdownRoles()
    {
      Conexiones con = new Conexiones();
      DataTable dt = new DataTable();

      dt = con.TraerDataTable("GESTION_ALERTAS", 0, 0, 0, 0, "", "", 0, 0, "", 0, 0, 0);

      DataRow dr = dt.NewRow();
      dr[0] = -2;
      dr[1] = "Seleccionar";
      dt.Rows.Add(dr);

      return dt;
    }

    public DataTable getAlertas(int opc, int cod_alerta, int id_rel, int cod_tipo, int cod_depto, int rol, string desc_encabezado, string desc_cuerpo, string icodie, int cod_proyecto, int cod_institucion, int cod_estado)
    {
      Conexiones con = new Conexiones();
      DataTable dt = new DataTable();

      //dt = con.TraerDataTable("GESTION_ALERTAS", opc, cod_alerta, cod_categoria, cod_tipo, cod_detalle, cod_depto, rol, cod_proyecto, icodie, cod_estado);
      //dt = con.TraerDataTable("GESTION_ALERTAS", 0,   0,          0,              0,        0,          0,      0,         0,   "0",           0);
      //dt = con.TraerDataTable("GESTION_ALERTAS", 1, 0, 0, 0, 0, 0, 0, 0, "0", 0);
      dt = con.TraerDataTable("GESTION_ALERTAS", opc, cod_alerta, id_rel, cod_tipo, desc_cuerpo, desc_encabezado, cod_depto, rol, icodie, cod_proyecto, cod_institucion, cod_estado);

      return dt;
    }

    public DataTable getCodCategoriaCodSubcategoria(int opc, int cod_categoria, int cod_subcategoria)
    {
        DataTable dt = new DataTable();
        Conexiones con = new Conexiones();

        Alertas alerta = new Alertas();

        opc = 1;

        dt = con.TraerDataTable("GESTION_ALERTAS_REL_CATEGORIA_SUBCATEGORIA", opc, 0, cod_categoria, cod_subcategoria);

        return dt;
    }


    public void agregarNuevaAlerta(int id_relacion_categoria_subcategoria, int cod_tipo, string desc_encabezado,
                                    string desc_cuerpo, int cod_depto, int rol, string icodie, int cod_proyecto, int cod_institucion)
    {
        Conexiones con = new Conexiones();
        DbDataReader dr = null;

        DbParameter[] parametros = {
                                       con.parametros("@OPC", SqlDbType.Int, 10, 2), //OPC para que ejecute la sección Insert en el SP
                                       con.parametros("@COD_ALERTA", SqlDbType.Int, 10,  0), //Mando un cero ya que no se va a modificar ni eliminar, es solo para que reciba el parametro
                                       con.parametros("@ID_REL", SqlDbType.Int, 10, id_relacion_categoria_subcategoria),
                                       con.parametros("@COD_TIPO", SqlDbType.Int, 10, cod_tipo),
                                       con.parametros("@DESC_ENCABEZADO", SqlDbType.VarChar,35, desc_encabezado),
                                       con.parametros("@DESC_CUERPO", SqlDbType.VarChar, 100, desc_cuerpo),
                                       con.parametros("@COD_DEPTO", SqlDbType.Int, 10, cod_depto),
                                       con.parametros("@ROL", SqlDbType.VarChar, 255, rol),
                                       con.parametros("@ICODIE", SqlDbType.VarChar, 255, icodie),
                                       con.parametros("@COD_PROYECTO", SqlDbType.Int, 10, cod_proyecto),
                                       con.parametros("@COD_INSTITUCION", SqlDbType.Int, 10, cod_institucion),
                                       con.parametros("@COD_ESTADO", SqlDbType.Int, 10, 1) //Todas las alertas que se creen estaran vigentes.
                                   };
        con.ejecutarProcedimiento("GESTION_ALERTAS", parametros, out dr);
        con.Desconectar();
    }

  #endregion


    
}