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
using System.ComponentModel;
using System.Data.Common;
using System.Collections.Generic;

public partial class mod_institucion_bsc_institucion : System.Web.UI.Page
{
    public DataTable DtBusqueda
    {
        get { return (DataTable)Session["DtBusqueda"]; }
        set { Session["DtBusqueda"] = value; }
    }
    public int vCodInstPaso
    {
        get { return (int)Session["vCodInstPaso"]; }
        set { Session["vCodInstPaso"] = value; }
    }
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }

    public int vCodPaso2
    {
        get { return (int)Session["vCodPaso2"]; }
        set { Session["vCodPaso2"] = value; }
    }

    string SParametrosConsultas = "";
    public string vsBuscaEspecifica
    {
        get { return (string)Session["vsBuscaEspecifica"]; }
        set { Session["vsBuscaEspecifica"] = value; }
    }

    public string vsParametro
    {
        get { return (string)Session["vsParametro"]; }
        set { Session["vsParametro"] = value; }
    }

    private string vsdir
    {
        get { return (string)Session["vsdir"]; }
        set { Session["vsdir"] = value; }
    }

    private DataTable dtRol
    {
        get { return (DataTable)Session["dtRol"]; }
        set { Session["dtRol"] = value; }
    }

    public proyecto SSproyecto
    {
        get
        {
            if (Session["neo_SSproyecto"] == null)
            { Session["neo_SSproyecto"] = new proyecto(); }
            return (proyecto)Session["neo_SSproyecto"];
        }
        set { Session["neo_SSproyecto"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            gettipoinstitucion();
            gettipoinmueble();

            getinstituciones();
            gettipoevento();


            if (Request.QueryString["param001"] != null)
            {
                vsParametro = Request.QueryString["param001"];
                lbl001.Text = "Buscador " + vsParametro;

                if (Request.QueryString["param001"] == "Registro de Eventos-Proyecto")
                {
                    tr_tipo_evento.Style.Remove("display");
                }

                //if (Request.QueryString["dir"] != null) RPA OLD
                if (Request.QueryString["dir"] != "")
                {
                    vsdir = Request.QueryString["dir"];
                }
                else
                {
                    vsdir = Session["SS_PATH_URL"].ToString();
                }
            }
            else//buscador para mesa de ayuda, temporal RPA 
            {
                vsParametro = Session["SS_PATH_URL"].ToString();
                lbl001.Text = "Buscador " + vsParametro;

            }
            if (Request.QueryString["param002"] != null)
            {
                vsBuscaEspecifica = Request.QueryString["param002"];
                lbl001.Text = "Instituciones";
                vsParametro = "Instituciones";
            }
            if (Request.QueryString["codinst"] != null)
            {
                if (Request.QueryString["codinst"] != "0")
                {
                    txt001.Text = Request.QueryString["codinst"];
                }
            }
            if (Request.QueryString["codproy"] != null)
            {
                if (Request.QueryString["codproy"] != "0")
                {
                    txt0012.Text = Request.QueryString["codproy"];
                }
            }
                        
            //vsdir = null;
            dtRol = consulta_rol();
            gettipoproyecto();
            if (vsParametro == "Proyectos" || vsParametro == "Busca Proyectos" || vsParametro == "Busca Proyectos2")
            {
                tr_rut_institucion.Visible = false;
                tr_institucion.Visible = false;
                tr_tipo_institucion.Visible = false;
                tr_rut_tecnico.Visible = false;
                tr_apellido_paterno.Visible = false;
                tr_apellido_materno.Visible = false;
                tr_nombres.Visible = false;
                txt002.Visible = false;
                txt005.Visible = false;
                ddown004.Visible = false;
                txt006.Visible = false;
                txt007.Visible = false;
                txt003.Visible = false;
                txt004.Visible = false;
                tr_tipo_inmueble.Visible = false;
                tr_codigo_inmueble.Visible = false;
                tr_nombre_inmueble.Visible = false;
                txt0010.Visible = false;
                ddown005.Visible = false;
                txt009.Visible = false;
                int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
                if (codrol == 266)
                {
                    chklist001.Visible = true;
                    tr_vigencia.Visible = true;
                }
                return;
            }
            
            if (vsParametro == "Registro de Inmuebles-Proyecto")
            {
                
                tr_rut_institucion.Visible = false;
                tr_institucion.Visible = false;
                tr_tipo_institucion.Visible = false;
                tr_rut_tecnico.Visible = false;
                tr_apellido_paterno.Visible = false;
                tr_apellido_materno.Visible = false;
                tr_nombres.Visible = false;
                tr_codigo_inmueble.Visible = false;
                tr_nombre_proyecto.Visible = false;
                txt0010.Visible = false;
                txt0011.Visible = false;    
                txt002.Visible = false;
                txt005.Visible = false;
                ddown004.Visible = false;
                txt006.Visible = false;
                txt007.Visible = false;
                txt003.Visible = false;
                txt004.Visible = false; 
            }
            else if (vsParametro == "Registro de Trabajadores-Proyecto" )
            {
                tr_rut_institucion.Visible = false;
                tr_tipo_institucion.Visible = false;
                tr_tipo_inmueble.Visible = false;
                tr_nombre_inmueble.Visible = false;
                tr_tipo_proyecto.Visible = false;
                tr_nombre_proyecto.Visible = false;
                txt0011.Visible = false;
                ddown002.Visible = false;
                txt002.Visible = false;
                ddown004.Visible = false;
                ddown005.Visible = false;
                txt009.Visible = false;
                tr_codigo_inmueble.Visible = false;
                txt0010.Visible = false;
                txt005.Visible = false;
                tr_institucion.Visible = false;
                tr_vigencia.Visible = true;
                chklist001.Visible = true;
            }
            else if (vsParametro == "Instituciones"|| vsParametro == "Plan de Intervencion")
            {
                lbl001.Text = "Buscador Instituciones";

                tr_rut_tecnico.Visible = false;
                tr_apellido_paterno.Visible = false;
                tr_apellido_materno.Visible = false;
                tr_nombres.Visible = false;
                tr_tipo_inmueble.Visible = false;
                tr_tipo_proyecto.Visible = false;
                tr_nombre_proyecto.Visible = false;
                tr_codigo_proyecto.Visible = false;
                txt0011.Visible = false;
                txt0012.Visible = false;
                ddown002.Visible = false;
                txt003.Visible = false;
                txt004.Visible = false;
                txt006.Visible = false;
                txt007.Visible = false;
                ddown005.Visible = false;
                txt009.Visible = false;
                tr_codigo_inmueble.Visible = false;
                txt0010.Visible = false;
                tr_nombre_inmueble.Visible = false;
                chklist001.Visible = vsParametro == "Instituciones";
                tr_vigencia.Visible = vsParametro == "Instituciones";
            }
            else if (vsParametro == "Registro de Trabajadores")
            {
                tr_rut_institucion.Visible = false;
                tr_tipo_institucion.Visible = false;
                tr_tipo_inmueble.Visible = false;
                tr_nombre_inmueble.Visible = false;
                tr_tipo_proyecto.Visible = false;
                tr_nombre_proyecto.Visible = false;
                tr_codigo_proyecto.Visible = false;
                txt0011.Visible = false;
                txt0012.Visible = false;
                ddown002.Visible = false;
                txt002.Visible = false;
                ddown004.Visible = false;
                ddown005.Visible = false;
                txt009.Visible = false;
                tr_codigo_inmueble.Visible = false;
                txt0010.Visible = false;
                tr_vigencia.Visible = true;
                chklist001.Visible = true;
            }
            else if (vsParametro == "Registro de Inmuebles" )
            {
                tr_rut_institucion.Visible = false;
                tr_institucion.Visible = false;
                tr_tipo_institucion.Visible = false;
                tr_rut_tecnico.Visible = false;
                tr_apellido_paterno.Visible = false;
                tr_apellido_materno.Visible = false;
                tr_nombres.Visible = false;
                tr_tipo_proyecto.Visible = false;
                tr_nombre_proyecto.Visible = false;
                tr_codigo_proyecto.Visible = false;
                txt0011.Visible = false;
                txt0012.Visible = false;
                ddown002.Visible = false;
                txt002.Visible = false;
                txt005.Visible = false;
                ddown004.Visible = false;
                txt006.Visible = false;
                txt007.Visible = false;
                txt003.Visible = false;
                txt004.Visible = false;
                txt0010.Visible = false;
                tr_codigo_inmueble.Visible = false;
            }
            else if (vsParametro == "Registro de Eventos-Proyecto")
            {
                tr_codigo_institucion.Visible = false;
                txt001.Visible = false;
                ImageButton1.Visible = false;
                tr_rut_institucion.Visible = false;
                tr_institucion.Visible = false;
                tr_tipo_institucion.Visible = false;
                tr_rut_tecnico.Visible = false;
                tr_apellido_paterno.Visible = false;
                tr_apellido_materno.Visible = false;
                tr_nombres.Visible = false;
                txt002.Visible = false;
                txt005.Visible = false;
                ddown004.Visible = false;
                txt006.Visible = false;
                txt007.Visible = false;
                txt003.Visible = false;
                txt004.Visible = false;
                tr_tipo_inmueble.Visible = false;
                tr_codigo_inmueble.Visible = false;
                tr_nombre_inmueble.Visible = false;
                txt0010.Visible = false;
                ddown005.Visible = false;
                txt009.Visible = false;
                tr_tipo_evento.Visible = true;
                ddown006.Visible = true;
            }
        }
    }
    private DataTable consulta_rol()
    {
        DbDataReader datareader = null;
        String sql = "Select * from usuarios where IdUsuario =" + Convert.ToInt32(Session["IdUsuario"]);
        Conexiones con = new Conexiones();
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDireccionRegional", typeof(int)));
        dt.Columns.Add(new DataColumn("Contrasena", typeof(String)));
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDireccionRegional"];
                dr[1] = (String)datareader["Contrasena"];
                dr[2] = (int)datareader["CodRegion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        //db.Close();
        return dt;
    
    }
   
    private void  Function_Genera_String_Consulta(string sParametrosConsulta, string sTipoBusqueda)
    {
        if (vsParametro == "Instituciones" || vsParametro == "Plan de Intervencion")
        {
             FunctionSelectInstitucion(sParametrosConsulta);
        }
        else if (vsParametro == "Registro de Trabajadores")
        {
             FunctionSelectTrabajadores(sParametrosConsulta);
        }
        else if (vsParametro == "Registro de Inmuebles" )
        {
            FunctionSelectInmuebles(sParametrosConsulta);
        }
        else if (vsParametro == "Proyectos" || vsParametro == "Busca Proyectos")
        {
            FunctionSelectProyecto(sParametrosConsulta);
        }
        else if (vsParametro == "Busca Proyectos2")
        {
          FunctionSelectProyecto2(sParametrosConsulta);
        }
        else if (vsParametro == "Registro de Trabajadores-Proyecto")
        {
            FunctionSelectTrabajadoresProyecto(sParametrosConsulta);
        }
        else if (vsParametro == "Registro de Inmuebles-Proyecto")
        {
            FunctionSelectInmueblesProyecto(sParametrosConsulta);
        }
        else if (vsParametro == "Registro de Eventos-Proyecto")
        {
            FunctionSelectEventosProyecto(sParametrosConsulta);
        }
    }
    private void FunctionSelectProyecto2(string sParametrosConsulta)
    {

        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        if (vsParametro == "Busca Proyectos2")
        {
            if (Convert.ToString(dtRol.Rows[0][1]) == "252" || Convert.ToString(dtRol.Rows[0][1]) == "253"  || Convert.ToString(dtRol.Rows[0][1]) == "275" || Convert.ToString(dtRol.Rows[0][1]) == "289") //252 roladministradorSENAINFO
          
            {
                sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
                                  "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                  "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 ";
            }
            else
            {
                if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
                {
                    //255 administrador tecnico nacional
                    //256 administrador finansas nacional
                    //257 tecnico nacional con niños
                    //260 administrador tecnico deplae senainfo
                    //261 administrador tecnico deplae senainfo

                    if (Convert.ToString(dtRol.Rows[0][1]) == "255" || Convert.ToString(dtRol.Rows[0][1]) == "256" ||
             Convert.ToString(dtRol.Rows[0][1]) == "257" || Convert.ToString(dtRol.Rows[0][1]) == "260" ||
             Convert.ToString(dtRol.Rows[0][1]) == "261" || Convert.ToString(dtRol.Rows[0][1]) == "259" || Convert.ToString(dtRol.Rows[0][1]) == "283"
                        || Convert.ToString(dtRol.Rows[0][1]) == "289")
                    {
                        sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
                                     "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                     "Where t1.IndVigencia = 'V' ";
                        if (Convert.ToString(dtRol.Rows[0][1]) != "259")
                            sParametrosConsulta += " and t1.EstadoProyecto = 1 ";
                    }

                    else
                    {
                        if (Convert.ToString(dtRol.Rows[0][1]) == "266")
                        {
                            sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto," +
                                            " t1.Nombre,t1.CodSistemaAsistencial " +
                                         "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                         "Where t1.IndVigencia =@pIndVigencia and t1.EstadoProyecto = 1 and t1.CodRegion =@pCodRegion ";

                            listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
                            listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
                        }
                        else
                        {
                            if (Convert.ToString(dtRol.Rows[0][1]) == "262")
                            {
                                sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto," +
                                        " t1.Nombre,t1.CodSistemaAsistencial " +
                                         "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                         "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.CodRegion =@pCodRegion";

                                listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));

                                 if (txt0012.Text != "")
                                        {
                                            sParametrosConsulta = sParametrosConsulta + " and t1.CodProyecto =@pCodProyecto";

                                            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
                                        }
                                            sParametrosConsulta = sParametrosConsulta + " union " + 
                                            " Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto, " +
                                            " t1.Nombre,t1.CodSistemaAsistencial " +
                                            " from Proyectos t1   " +
                                            " inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto  " +
                                            " INNER JOIN TrabajadorProyecto T3 ON T1.CodProyecto = T3.CodProyecto " +
                                            " inner join usuarios  T4 on T3.ICodTrabajador = T4.ICodTrabajador " +
                                            " Where t1.IndVigencia = 'V'  " +
                                            " and T3.indvigencia = 'V' " +
                                            " and t1.EstadoProyecto = 1  " +
                                            " and T4.idusuario =@pIdUsuario ";

                                            listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                            }
                            else 
                            sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto," +
                                        " t1.Nombre,t1.CodSistemaAsistencial " +
                                         "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                         "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.CodRegion =@pCodRegion ";

                            listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
                        }
                    }

                }
                else
                {
                    sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
                                      "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                      "INNER JOIN TrabajadorProyecto T5 ON T5.CodProyecto = T1.CodProyecto INNER JOIN USUARIOS T6 ON T6.ICodTrabajador = T5.ICodTrabajador " +
                                      "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and T6.idUsuario =@pIdUsuario ";

                    listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                }
            } 
        }

        if (txt001.Text != "" || txt0011.Text != "" || txt0012.Text != "" || ddown002.SelectedValue != "0")
            sParametrosConsulta = sParametrosConsulta + " And";
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.CodInstitucion =@pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (txt0011.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.Nombre like @pNombre And";

            listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt0011.Text + "%"));
        }
        if (txt0012.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.CodProyecto =@pCodProyecto And";

            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
        }
        if (ddown002.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.TipoProyecto =@pTipoProyecto And";

            listDbParameter.Add(con.parametros("@pTipoProyecto", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 302)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = true;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);

            //DtBusqueda = dt;
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();

        }
        else if (dt.Rows.Count == 0)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = false;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
        else if (dt.Rows.Count >= 302)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
        }



        if (dt.Rows.Count < 70)
        {
            //lbl0013.Visible = false;
            //lbl0014.Visible = false;
            //lbl0015.Visible = false;
            //btnBuscar.Visible = false;            
            //CargaGrilla();
            DtBusqueda = dt;
            CargaGrilla();

        }

    }
    
    private void FunctionSelectEventosProyecto(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        if (Convert.ToString(dtRol.Rows[0][1]) == "252" || Convert.ToString(dtRol.Rows[0][1]) == "253" || Convert.ToString(dtRol.Rows[0][1]) == "255" || Convert.ToString(dtRol.Rows[0][1]) == "257")
        {
            sParametrosConsulta = "Select distinct top 201 T1.ICodEventosProyectos, T1.CodProyecto, T1.TipoEventos, T1.FechaEvento," +
                                  "T1.IdUsuarioActualizacion, T1.CodComuna, T1.Descripcion, T1.CantidadAsistentes," +
                                  "T1.IndVigencia, T1.FechaActualizacion, t2.CodTematicaProyecto From EventosProyecto T1 Inner Join Proyectos T2 " +
                                  "ON T1.CodProyecto = T2.CodProyecto "+ //" inner join TrabajadorProyecto T3 on T3.CodProyecto = T2.CodProyecto " +
                                  "Where T1.IndVigencia = 'V' and YEAR(T1.FECHAEVENTO)*100+ MONTH(T1.FECHAEVENTO) NOT IN " +
                                  "(SELECT ANOMES FROM CIERREMOVIMIENTOMENSUAL B WHERE B.CODPROYECTO = T1.codproyecto) ";


        }
        else
        {
            if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
            {
                sParametrosConsulta = "Select distinct top 201 T1.ICodEventosProyectos, T1.CodProyecto, T1.TipoEventos, T1.FechaEvento," +
                                  "T1.IdUsuarioActualizacion, T1.CodComuna, T1.Descripcion, T1.CantidadAsistentes," +
                                  "T1.IndVigencia, T1.FechaActualizacion, t2.CodTematicaProyecto From EventosProyecto T1 Inner Join Proyectos T2 " +
                                  "ON T1.CodProyecto = T2.CodProyecto "+ //inner join TrabajadorProyecto T3 on T3.CodProyecto = T2.CodProyecto " +
                                  "Where T1.IndVigencia = 'V' and T2.CodRegion= @pCodRegion and YEAR(T1.FECHAEVENTO)*100+ MONTH(T1.FECHAEVENTO) NOT IN " +
                                  "(SELECT ANOMES FROM CIERREMOVIMIENTOMENSUAL B WHERE B.CODPROYECTO = T1.codproyecto) ";

                listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
            }
            else
            {
                sParametrosConsulta = "Select distinct top 201 T1.ICodEventosProyectos, T1.CodProyecto, T1.TipoEventos, T1.FechaEvento," +
                                      "T1.IdUsuarioActualizacion, T1.CodComuna, T1.Descripcion, T1.CantidadAsistentes," +
                                      "T1.IndVigencia, T1.FechaActualizacion, t2.CodTematicaProyecto From EventosProyecto T1 Inner Join Proyectos T2 " +
                                      "ON T1.CodProyecto = T2.CodProyecto  inner join TrabajadorProyecto T3 on T3.CodProyecto = T2.CodProyecto " +
                                      "inner join Usuarios T4 ON T3.ICodTrabajador = T4.ICodTrabajador Where T1.IndVigencia = 'V' and T4.idUsuario =@pIdUsuario" +
                                      " and YEAR(T1.FECHAEVENTO)*100+ MONTH(T1.FECHAEVENTO) NOT IN " +
                                      "(SELECT ANOMES FROM CIERREMOVIMIENTOMENSUAL B WHERE B.CODPROYECTO = T1.codproyecto) ";

                listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
            }
        }

        if (ddown006.SelectedValue != "0" || txt0011.Text != "" || txt0012.Text != "" || ddown002.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " And";
        }
        if (ddown006.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.TipoEventos =@pTipoEventos And";

            listDbParameter.Add(con.parametros("@pTipoEventos", SqlDbType.Int, 4, Convert.ToInt32(ddown006.SelectedValue)));
        }
        if (txt0011.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombre like @pNombre And";

            listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt0011.Text + "%"));
        }
        if (txt0012.Text != "")
        {
            //sParametrosConsulta = sParametrosConsulta + " T1.CodProyecto =@pCodProyecto" + txt0012.Text + " And";
            sParametrosConsulta = sParametrosConsulta + " T1.CodProyecto =@pCodProyecto And";

            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
        }
        if (ddown002.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.TipoProyecto =@pTipoProyecto And";

            listDbParameter.Add(con.parametros("@pTipoProyecto", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }
        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = true;          
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //aqui            
            DtBusqueda = dt;
            botonver2();
        }
        else if (dt.Rows.Count == 0)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);
            DtBusqueda = dt;
            //aqui
            botonver2();
        }
        else if (dt.Rows.Count >= 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
        }
    }
    private void FunctionSelectInmueblesProyecto(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
        if (codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 262 || codrol == 259 || codrol == 283 || codrol == 282)
        {
            sParametrosConsulta = "SELECT distinct T3.Nombre as NombreProyecto,T2.Nombre,T2.CodInstitucion,T1.CodProyecto," +
                                "T2.ICodInmueble,T2.IndVigencia as VigenciaInmueble,T1.IndVigencia as VigenciaRelacion" +
                                ",T4.Nombre, T3.CodTematicaProyecto FROM  Inmueble T2 LEFT JOIN  ProyectoInmueble T1 ON T1.ICodInmueble = T2.ICodInmueble " +
                                "LEFT JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto LEFT JOIN Instituciones T4 ON T4.CodInstitucion = T2.CodInstitucion ";
                                
                                
        }
        else
        {
            if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
            {
                sParametrosConsulta = "SELECT distinct T3.Nombre as NombreProyecto,T2.Nombre,T2.CodInstitucion,T1.CodProyecto," +
                                "T2.ICodInmueble,T2.IndVigencia as VigenciaInmueble,T1.IndVigencia as VigenciaRelacion" +
                                ",T4.Nombre, T3.CodTematicaProyecto FROM  Inmueble T2 LEFT JOIN  ProyectoInmueble T1 ON T1.ICodInmueble = T2.ICodInmueble " +
                                "LEFT JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto LEFT JOIN Instituciones T4 ON T4.CodInstitucion = T2.CodInstitucion "+
                                "Where T3.CodRegion =@pCodRegion ";

                listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
            }
            else
            {
                sParametrosConsulta = "SELECT distinct T3.Nombre as NombreProyecto,T2.Nombre,T2.CodInstitucion,T1.CodProyecto," +
                                      "T2.ICodInmueble,T2.IndVigencia as VigenciaInmueble,T1.IndVigencia as VigenciaRelacion" +
                                      ",T4.Nombre, T3.CodTematicaProyecto FROM  Inmueble T2 LEFT JOIN  ProyectoInmueble T1 ON T1.ICodInmueble = T2.ICodInmueble " +
                                      "LEFT JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto LEFT JOIN Instituciones T4 ON T4.CodInstitucion = T2.CodInstitucion " +
                                      "INNER JOIN TrabajadorProyecto T5 ON T5.CodProyecto = T3.CodProyecto INNER JOIN USUARIOS T6 ON T5.ICodTrabajador = T6.ICodTrabajador " +
                                      "WHERE T6.idUsuario =@pIdUsuario ";

                listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
            }
        }
        if (Convert.ToString(dtRol.Rows[0][1]) == "252")
        {
            if (txt001.Text != "" || txt0010.Text != "" || txt009.Text != "" || txt0012.Text != "" || ddown005.SelectedValue != "0" || ddown002.SelectedValue != "0")
            {
                sParametrosConsulta = sParametrosConsulta + "Where";
            }
        }
        else
        {
            if (txt001.Text != "" || txt0010.Text != "" || txt009.Text != "" || txt0012.Text != "" || ddown005.SelectedValue != "0" || ddown002.SelectedValue != "0")
            {
                sParametrosConsulta = sParametrosConsulta + "And";
            }
        }
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.CodInstitucion =@pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (txt0010.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.ICodInmueble  =@pICodInmueble And";

            listDbParameter.Add(con.parametros("@pICodInmueble", SqlDbType.Int, 4, Convert.ToInt32(txt0010.Text)));
        }
        if (ddown005.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.TipoInmueble =@pTipoInmueble And";

            listDbParameter.Add(con.parametros("@pTipoInmueble", SqlDbType.Int, 4, Convert.ToInt32(ddown005.SelectedValue)));
        }
        if (txt009.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombre like @pNombreInmueble And";

            listDbParameter.Add(con.parametros("@pNombreInmueble", SqlDbType.VarChar, 100, "%" + txt009.Text + "%"));
        }
        if (txt0011.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T3.Nombre like @pNombreProyectos And";

            listDbParameter.Add(con.parametros("@pNombreProyectos", SqlDbType.VarChar, 100, "%" + txt0011.Text + "%"));
        }
        if (txt0012.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.CodProyecto =@pCodProyecto And";

            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
        }
        if (ddown002.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " T3.TipoProyecto =@pTipoProyecto And";

            listDbParameter.Add(con.parametros("@pTipoProyecto", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = true;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);

            DtBusqueda = dt;
            botonver2();

        }
        else if (dt.Rows.Count == 0)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);
            botonver2();
        }
        else if (dt.Rows.Count >= 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
        }
    }
    private void FunctionSelectTrabajadoresProyecto(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
        if (codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 262 || codrol == 259 || codrol == 283 || codrol == 282) 
        {
            sParametrosConsulta = "Select top 201 T3.CodInstitucion,T3.IcodTrabajador,T3.Nombres,T3.Paterno,T3.Materno," +
                               "T1.CodProyecto,T1.IndVigencia as VigRelacionProy,T3.IndVigencia as VigenciaTrabajador," +
                               "T3.RutTrabajador,T2.Nombre as Institucion From  Trabajadores T3 left join TrabajadorProyecto T1  On T1.ICodTrabajador = T3.ICodTrabajador " +
                               "inner join instituciones T2 On T2.CodInstitucion = T3.CodInstitucion " +
                               "Where T3.IndVigencia=@pIndVigencia ";

            listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.VarChar, 1, chklist001.SelectedValue));
        }
        else if (codrol == 265 )
        {
            sParametrosConsulta = "Select top 201 T3.CodInstitucion,T3.IcodTrabajador,T3.Nombres,T3.Paterno,T3.Materno,T1.CodProyecto,T1.IndVigencia as VigRelacionProy,T3.IndVigencia as VigenciaTrabajador,T3.RutTrabajador,T2.Nombre as Institucion " +
                                        "From  Trabajadores T3 " +
                                        "left join TrabajadorProyecto T1  On T1.ICodTrabajador = T3.ICodTrabajador " +
                                        "inner join instituciones T2 On T2.CodInstitucion = T3.CodInstitucion " +
                                        "Where T1.IndVigencia=@pIndVigencia AND   T3.CodInstitucion in( " +
                                        "SELECT T1.CodInstitucion from trabajadores  T1 " +
                                        "INNER JOIN Usuarios T2 ON T1.iCodTrabajador = T2.iCodTrabajador " +
                                        "where idusuario =@pIdUsuario )";

            listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
            listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        }
        else
        {
            if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
            {
                sParametrosConsulta = "Select top 201 T3.CodInstitucion,T3.IcodTrabajador,T3.Nombres,T3.Paterno,T3.Materno," +
                              "T1.CodProyecto,T1.IndVigencia as VigRelacionProy,T3.IndVigencia as VigenciaTrabajador," +
                              "T3.RutTrabajador,T2.Nombre as Institucion From  Trabajadores T3 left join TrabajadorProyecto T1  On T1.ICodTrabajador = T3.ICodTrabajador " +
                              "inner join instituciones T2 On T2.CodInstitucion = T3.CodInstitucion inner join Proyectos T4 on T4.CodProyecto = T1.CodProyecto " +
                              "Where T3.IndVigencia=@pIndVigencia ";

                listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
            }
            else
            {
                if (codrol == 251)
                {
                    sParametrosConsulta = "Select top 201 T3.CodInstitucion,T3.IcodTrabajador,T3.Nombres,T3.Paterno,T3.Materno,T1.CodProyecto,T1.IndVigencia as VigRelacionProy,T3.IndVigencia as VigenciaTrabajador,T3.RutTrabajador,T2.Nombre as Institucion " +
                                        "From  Trabajadores T3 " +
                                        "left join TrabajadorProyecto T1  On T1.ICodTrabajador = T3.ICodTrabajador " +
                                        "inner join instituciones T2 On T2.CodInstitucion = T3.CodInstitucion " +
                                        "Where T1.IndVigencia=@pIndVigencia AND   T3.CodInstitucion in( " +
                                        "SELECT T1.CodInstitucion from trabajadores  T1 " +
                                        "INNER JOIN Usuarios T2 ON T1.iCodTrabajador = T2.iCodTrabajador " +
                                        "where idusuario =@pIdUsuario )";

                    listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
                    listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                }
                else
                {
                    sParametrosConsulta = "Select top 201 T3.CodInstitucion,T3.IcodTrabajador,T3.Nombres,T3.Paterno,T3.Materno," +
                                        "T1.CodProyecto,T1.IndVigencia as VigRelacionProy,T3.IndVigencia as VigenciaTrabajador," +
                                        "T3.RutTrabajador,T2.Nombre as Institucion From  Trabajadores T3 left join TrabajadorProyecto T1  On T1.ICodTrabajador = T3.ICodTrabajador " +
                                        "inner join instituciones T2 On T2.CodInstitucion = T3.CodInstitucion " +
                                        "INNER JOIN USUARIOS T4 ON T4.ICodTrabajador = T1.ICodTrabajador Where T3.IndVigencia=@pIndVigencia and " +
                                        "T4.idUsuario =@pIdUsuario ";

                    listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
                    listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                }
            }
        }
        
        
        
        
        if (txt001.Text != "" || txt006.Text != "" || txt007.Text != "" || txt003.Text != "" || txt004.Text != "" || txt0012.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + "AND";
        }
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T3.CodInstitucion =@pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (txt006.Text != "")
        {
            //string rutsinguion = txt006.Text.Replace("-", "");
            string rutsinguion = txt006.Text.Replace(".", "").Trim().ToString();
            sParametrosConsulta = sParametrosConsulta + " T3.RutTrabajador  =@pRutTrabajador And";

            listDbParameter.Add(con.parametros("@pRutTrabajador", SqlDbType.VarChar, 100, rutsinguion));
        }
        if (txt007.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T3.Paterno like @pPaterno And";

            listDbParameter.Add(con.parametros("@pPaterno", SqlDbType.VarChar, 50, txt007.Text + "%"));
        }
        if (txt003.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T3.Materno like @pMaterno And";

            listDbParameter.Add(con.parametros("@pMaterno", SqlDbType.VarChar, 50, txt003.Text + "%"));
        }
        if (txt004.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T3.Nombres like @pNombres And";

            listDbParameter.Add(con.parametros("@pNombres", SqlDbType.VarChar, 50, txt004.Text + "%"));
        }
        if (txt0012.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.CodProyecto = @pCodProyecto And";

            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = true;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);

            DtBusqueda = dt;
            CargaGrilla();
            //botonver2();

        }
        else if (dt.Rows.Count == 0)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = false;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
        else if (dt.Rows.Count >= 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
        }
    }

    private void FunctionSelectProyecto(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        if (vsParametro == "Proyectos")
        {
            int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
            if (codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 262 || codrol == 259 || codrol == 275 || codrol == 283 || codrol == 282) 
            {

                sParametrosConsulta = "Select DISTINCT top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto," +
                                        "t3.Descripcion  ,t4.Descripcion as VigenciaInmueble from Proyectos t1  " +
                                        "inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                        "Inner Join parSistemaAsistencial t3 ON t3.CodSistemaAsistencial = t1.CodSistemaAsistencial " +
                                        "Inner Join parModeloIntervencion t4 ON t4.CodModeloIntervencion = t1.CodModeloIntervencion " +
                                        "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 ";
            }
            else if (Convert.ToString(dtRol.Rows[0][1]) == "251")
            {
                sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial,t3.Descripcion  ,t4.Descripcion as VigenciaInmueble, t1.CodTematicaProyecto " +
                                       " from Proyectos t1  " +
                                       " inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                       " Inner Join parSistemaAsistencial t3 ON t3.CodSistemaAsistencial = t1.CodSistemaAsistencial " +
                                       " Inner Join parModeloIntervencion t4 ON t4.CodModeloIntervencion = t1.CodModeloIntervencion " +
                                       " INNER JOIN TRABAJADORES t7 ON t1.CODINSTITUCION = t7.CODINSTITUCION " +
                                       " INNER JOIN USUARIOS T6 ON t7.ICodTrabajador = T6.ICodTrabajador " +
                                       " Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and T6.idUsuario =@pIdUsuario ";

                listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
            }
            else
            {
                if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
                {

                    sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto," +
                                        "t3.Descripcion  ,t4.Descripcion as VigenciaInmueble from Proyectos t1  " +
                                        "inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                        "Inner Join parSistemaAsistencial t3 ON t3.CodSistemaAsistencial = t1.CodSistemaAsistencial " +
                                        "Inner Join parModeloIntervencion t4 ON t4.CodModeloIntervencion = t1.CodModeloIntervencion " +
                                        "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.CodRegion=@pCodRegion ";

                    listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
                }
                else
                {
                    sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto," +
                                            "t3.Descripcion  ,t4.Descripcion as VigenciaInmueble from Proyectos t1  " +
                                            "inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                            "Inner Join parSistemaAsistencial t3 ON t3.CodSistemaAsistencial = t1.CodSistemaAsistencial " +
                                            "Inner Join parModeloIntervencion t4 ON t4.CodModeloIntervencion = t1.CodModeloIntervencion " +
                                            "INNER JOIN TrabajadorProyecto T5 ON T5.CodProyecto = T1.CodProyecto INNER JOIN USUARIOS T6 ON T6.ICodTrabajador = T5.ICodTrabajador " +
                                            "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and T6.idUsuario =@pIdUsuario ";

                    listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                }
                
            }
        }
        else if (vsParametro == "Busca Proyectos")
        {
            if (Convert.ToString(dtRol.Rows[0][1]) == "252" || Convert.ToString(dtRol.Rows[0][1]) == "253"  || Convert.ToString(dtRol.Rows[0][1]) == "275" || Convert.ToString(dtRol.Rows[0][1]) == "289") //252 roladministradorSENAINFO
          
            {
                sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                  "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                  "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 ";
            }
            else
            {
                if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
                {
                    //255 administrador tecnico nacional
                    //256 administrador finansas nacional
                    //257 tecnico nacional con niños
                    //260 administrador tecnico deplae senainfo
                    //261 administrador tecnico deplae senainfo

                    if (Convert.ToString(dtRol.Rows[0][1]) == "255" || Convert.ToString(dtRol.Rows[0][1]) == "256" ||
             Convert.ToString(dtRol.Rows[0][1]) == "257" || Convert.ToString(dtRol.Rows[0][1]) == "260" ||
             Convert.ToString(dtRol.Rows[0][1]) == "261" || Convert.ToString(dtRol.Rows[0][1]) == "259" || Convert.ToString(dtRol.Rows[0][1]) == "283"
                        || Convert.ToString(dtRol.Rows[0][1]) == "289")
                    {
                        sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                     "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                     "Where t1.IndVigencia = 'V' ";
                        if (Convert.ToString(dtRol.Rows[0][1]) != "259")
                            sParametrosConsulta += " and t1.EstadoProyecto = 1 ";
                    }

                    else
                    {
                        if (Convert.ToString(dtRol.Rows[0][1]) == "266")
                        {
                            sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto," +
                                            " t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                         "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                         "Where t1.IndVigencia =@pIndVigencia  and t1.EstadoProyecto = 1 and t1.CodRegion =@pCodRegion ";

                            listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
                            listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
                        }
                        else
                        {
                            if (Convert.ToString(dtRol.Rows[0][1]) == "262")
                            {
                                sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto," +
                                        " t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                         "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                         "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.CodRegion =@pCodRegion";

                                listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
                                 if (txt0012.Text != "")
                                        {
                                            sParametrosConsulta = sParametrosConsulta + " and t1.CodProyecto =@pCodProyecto";

                                            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
                                        }
                                            sParametrosConsulta = sParametrosConsulta + " union " + 
                                            " Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto, " +
                                            " t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                            " from Proyectos t1   " +
                                            " inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto  " +
                                            " INNER JOIN TrabajadorProyecto T3 ON T1.CodProyecto = T3.CodProyecto " +
                                            " inner join usuarios  T4 on T3.ICodTrabajador = T4.ICodTrabajador " +
                                            " Where t1.IndVigencia = 'V'  " +
                                            " and T3.indvigencia = 'V' " +
                                            " and t1.EstadoProyecto = 1  " +
                                            " and T4.idusuario =@pIdUsuario ";

                                            listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                            }
                            else 
                            sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto," +
                                        " t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                         "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                         "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.CodRegion =@pCodRegion ";

                            listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));

                        }
                    }

                }
                else
                {
                    sParametrosConsulta = "Select top 301 t1.CodProyecto,t1.CodInstitucion,t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial, t1.CodTematicaProyecto " +
                                      "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
                                      "INNER JOIN TrabajadorProyecto T5 ON T5.CodProyecto = T1.CodProyecto INNER JOIN USUARIOS T6 ON T6.ICodTrabajador = T5.ICodTrabajador " +
                                      "Where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and T6.idUsuario =@pIdUsuario ";

                    listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                }
            } 
        }

        if (txt001.Text != "" || txt0011.Text != "" || txt0012.Text != "" || ddown002.SelectedValue != "0")
            sParametrosConsulta = sParametrosConsulta + " And";
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.CodInstitucion =@pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (txt0011.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.Nombre like @pNombre And";

            listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt0011.Text + "%"));
        }
        if (txt0012.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.CodProyecto =@pCodProyecto And";

            listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 10, Convert.ToInt32(txt0012.Text)));
        }
        if (ddown002.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " t1.TipoProyecto =@pTipoProyecto And";

            listDbParameter.Add(con.parametros("@pTipoProyecto", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 302)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = true;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);

            //DtBusqueda = dt;
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();

        }
        else if (dt.Rows.Count == 0)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = false;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
        else if (dt.Rows.Count >= 302)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
        }



        if (dt.Rows.Count < 70)
        {
            //lbl0013.Visible = false;
            //lbl0014.Visible = false;
            //lbl0015.Visible = false;
            //btnBuscar.Visible = false;            
            //CargaGrilla();
            DtBusqueda = dt;
            CargaGrilla();

        }

    }

    private void FunctionSelectInmuebles(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
        if (codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 262 || codrol == 259 || codrol == 283 || codrol == 282)
        {
      
                sParametrosConsulta = "Select distinct top 201 T1.CodInstitucion,T1.ICodInmueble,T1.CodInmueble,T1.IdUsuarioActualizacion,T1.CodSituacionLegalInmueble," +
            "T1.CodComuna,T1.TipoInmueble,T1.Nombre,T1.Direccion,T1.Telefono,T1.Fax,T1.CodigoPostal,T1.m2Construidos,T1.m2totales,T1.NumeroDormitorios," +
            "T1.CapacidadNinos,T1.NumeroBanos,T1.CantidadPisos,T1.AreasVerdes,T1.IndVigencia,T1.FechaActualizacion, T3.Descripcion as DesTipoInmueble, T2.Descripcion as DesCodSituacionLegal " +
            "From Inmueble T1 INNER JOIN parSituacionLegalInmueble T2 on T2.CodSituacionLegalInmueble = T1.CodSituacionLegalInmueble " +
            "INNER JOIN parTipoInmueble T3 ON T1.TipoInmueble = T3.TipoInmueble Where T1.IndVigencia = 'V' ";
        }
        else
        {
            if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
            {
                sParametrosConsulta = "Select distinct top 201 T1.CodInstitucion,T1.ICodInmueble,T1.CodInmueble, " +
                "T1.IdUsuarioActualizacion,T1.CodSituacionLegalInmueble,T1.CodComuna, T1.TipoInmueble,T1.Nombre,T1.Direccion,T1.Telefono,T1.Fax,T1.CodigoPostal," +
                "T1.m2Construidos,T1.m2totales,T1.NumeroDormitorios,T1.CapacidadNinos, " +
                "T1.NumeroBanos,T1.CantidadPisos,T1.AreasVerdes,T1.IndVigencia, T1.FechaActualizacion, T3.Descripcion as DesTipoInmueble, " +
                "T2.Descripcion as DesCodSituacionLegal From Inmueble T1 " +
                "INNER JOIN parSituacionLegalInmueble T2 on T2.CodSituacionLegalInmueble = T1.CodSituacionLegalInmueble " +
                "INNER JOIN parTipoInmueble T3 ON T1.TipoInmueble = T3.TipoInmueble " +
                "INNER JOIN parcomunas T4 ON T4.CodComuna = T1.CodComuna " +
                "INNER JOIN parprovincia T5 ON T4.CodProvincia = T5.CodProvincia " +
                "Where T1.IndVigencia = 'V' and T5.CodRegion=@pCodRegion ";

                listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
               
            }
            else
            {
                sParametrosConsulta = "Select distinct top 201 T1.CodInstitucion,T1.ICodInmueble,T1.CodInmueble,T1.IdUsuarioActualizacion,T1.CodSituacionLegalInmueble," +
                "T1.CodComuna,T1.TipoInmueble,T1.Nombre,T1.Direccion,T1.Telefono,T1.Fax,T1.CodigoPostal,T1.m2Construidos,T1.m2totales,T1.NumeroDormitorios," +
                "T1.CapacidadNinos,T1.NumeroBanos,T1.CantidadPisos,T1.AreasVerdes,T1.IndVigencia,T1.FechaActualizacion, T3.Descripcion as DesTipoInmueble, T2.Descripcion as DesCodSituacionLegal " +
                "From Inmueble T1 INNER JOIN parSituacionLegalInmueble T2 on T2.CodSituacionLegalInmueble = T1.CodSituacionLegalInmueble " +
                "INNER JOIN parTipoInmueble T3 ON T1.TipoInmueble = T3.TipoInmueble  INNER JOIN PROYECTOS T4 ON T4.CodInstitucion = T1.CODINSTITUCION " +
                "INNER JOIN TrabajadorProyecto T5 ON T4.CodProyecto = T5.CodProyecto INNER JOIN USUARIOS T6 ON T5.ICodTrabajador = T6.ICodTrabajador " +
                "Where T1.IndVigencia = 'V' and T6.idUsuario =@pIdUsuario ";

                listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
            }
        }
        if (txt001.Text != "" || ddown005.SelectedValue != "0" || txt009.Text != "")
            sParametrosConsulta = sParametrosConsulta + " And";
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.CodInstitucion =@pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (ddown005.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.TipoInmueble =@pTipoInmueble And";

            listDbParameter.Add(con.parametros("@pTipoInmueble", SqlDbType.Int, 4, Convert.ToInt32(ddown005.SelectedValue)));
        }
        if (txt009.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.Nombre like @pNombre And";

            listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt009.Text + "%"));
        }
        if (txt0010.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.ICodInmueble =@pICodInmueble And";

            listDbParameter.Add(con.parametros("@pICodInmueble", SqlDbType.Int, 4, Convert.ToInt32(txt0010.Text)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = true;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);

            //DtBusqueda = dt;
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();

        }
        else if ( dt.Rows.Count == 0)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = false;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
        else if (dt.Rows.Count >= 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";        
        }

    }

    private void FunctionSelectTrabajadores(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
        if (codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 262 || codrol == 259 || codrol == 283 || codrol == 282)
        {
            sParametrosConsulta = "Select DISTINCT top 201 T1.ICodTrabajador,T1.CodInstitucion,T1.CodTrabajador,T1.CodProfesion,T1.Paterno,T1.Materno," +
                                  "T1.Nombres,T1.RutTrabajador,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.IndVigencia as VigenciaTrabajador,T1.FechaActualizacion," +
                                  "T1.IdUsuarioActualizacion From Trabajadores T1 inner join instituciones T2 ON T1.CodInstitucion = T2.CodInstitucion " +
                                  "Where T1.IndVigencia =@pIndVigencia ";

            listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));

        }
        else if (codrol == 265 || codrol == 251)
        {
            sParametrosConsulta = "Select DISTINCT top 201 T1.ICodTrabajador,T1.CodInstitucion,T1.CodTrabajador,T1.CodProfesion,T1.Paterno,T1.Materno,T1.Nombres,T1.RutTrabajador,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.IndVigencia as VigenciaTrabajador,T1.FechaActualizacion,T1.IdUsuarioActualizacion " +
                                    "FROM Trabajadores T1 " +
                                    "INNER JOIN USUARIOS T4 ON T1.ICodTrabajador = T4.ICodTrabajador " +
                                    "WHERE T1.IndVigencia = 'V' And  T1.CodInstitucion in( " +
                                    "SELECT T1.CodInstitucion from trabajadores  T1 " +
                                    "INNER JOIN Usuarios T2 ON T1.iCodTrabajador = T2.iCodTrabajador " +
                                    "where idusuario =@pIdUsuario )";

            listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        }
        else
        {
            if (Convert.ToInt32(dtRol.Rows[0][0]) > 0)
            {
                sParametrosConsulta = "Select DISTINCT top 201 T1.ICodTrabajador,T1.CodInstitucion,T1.CodTrabajador,T1.CodProfesion,T1.Paterno,T1.Materno," +
                                    "T1.Nombres,T1.RutTrabajador,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.IndVigencia as VigenciaTrabajador,T1.FechaActualizacion," +
                                    "T1.IdUsuarioActualizacion From Trabajadores T1 inner join instituciones T2 ON T1.CodInstitucion = T2.CodInstitucion " +
                                    "INNER JOIN PROYECTOS T3 ON T3.CodInstitucion = T2.CODINSTITUCION Where T1.IndVigencia =@pIndVigencia " +
                                    "and T3.CodRegion=@pCodRegion ";

                listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
                listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
            }
            else
            {
                sParametrosConsulta = "Select DISTINCT top 201 T1.ICodTrabajador,T1.CodInstitucion,T1.CodTrabajador,T1.CodProfesion,T1.Paterno,T1.Materno," +
                                        "T1.Nombres,T1.RutTrabajador,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.IndVigencia as VigenciaTrabajador,T1.FechaActualizacion," +
                                        "T1.IdUsuarioActualizacion From Trabajadores T1 inner join instituciones T2 ON T1.CodInstitucion = T2.CodInstitucion " +
                                        "INNER JOIN USUARIOS T4 ON T1.ICodTrabajador = T4.ICodTrabajador " +
                                        "Where T1.IndVigencia =@pIndVigencia and T4.idUsuario =@pIdUsuario ";

                listDbParameter.Add(con.parametros("@pIndVigencia", SqlDbType.Char, 1, chklist001.SelectedValue));
                listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
            }

        }
        if (txt001.Text != "" || txt005.Text != "" || txt006.Text != "" || txt007.Text != "" || txt003.Text != "" || txt004.Text != "")
            sParametrosConsulta = sParametrosConsulta + "And ";
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.CodInstitucion =@pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (txt005.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombre like @pNombre And";

            listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt005.Text + "%"));
        }
        if (txt006.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.RutTrabajador =@pRutTrabajador And";

            //listDbParameter.Add(con.parametros("@pRutTrabajador", SqlDbType.VarChar, 11, "%" + txt006.Text + "%"));
            listDbParameter.Add(con.parametros("@pRutTrabajador", SqlDbType.VarChar, 11, txt006.Text.Replace(".", "").ToString()));
        }
        if (txt007.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.Paterno like @pPaterno And";

            listDbParameter.Add(con.parametros("@pPaterno", SqlDbType.VarChar, 50, txt007.Text + "%"));
        }
        if (txt003.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.Materno like @pMaterno And";

            listDbParameter.Add(con.parametros("@pMaterno", SqlDbType.VarChar, 50, txt003.Text + "%"));
        }
        if (txt004.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.Nombres like @pNombres And";

            listDbParameter.Add(con.parametros("@pNombres", SqlDbType.VarChar, 50, txt004.Text + "%"));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = true;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);

            //DtBusqueda = dt;
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
        else if (dt.Rows.Count == 0)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = false;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
         else if (dt.Rows.Count >= 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";        
        }
    }
    private void FunctionSelectInstitucion(string sParametrosConsulta)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
        if (codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 262 || codrol == 259 || codrol == 283 || codrol == 282 || Convert.ToInt32(dtRol.Rows[0][0]) > 0) 
        {
            sParametrosConsulta = "SELECT DISTINCT top 201 T1.CodInstitucion,T1.TipoInstitucion,T1.codSistemaAdministrativo,T1.CodComuna,T1.RutInstitucion,T1.Nombre,T1.NombreCorto,T1.Direccion,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.RepresentanteLegal," +
                                  "T1.RutRepresentante,T1.PersonaContacto,T1.FechaAniversario,T1.NombrePrimeraAutoridad," +
                                  "T1.CargoPrimeraAutoridad,T1.NumeroPersonalidadJuridica,T1.ModoInstitucion,T1.DocumentoReconoce," +
                                  "T1.FechaDocumento,T1.IndVigencia,T1.Personeria,T1.RutInterventor,T1.IdAdministrador,T1.FechaActualizacion," +
                                  "T1.IdUsuarioActualizacion,T1.ObjetoSocial,T1.TipoReconocimiento,T1.Vigencia,T1.CodAreaEspecializacion," +
                                  "T1.Directorio,T1.MiembrosDirectorio,T1.AntecedentesFinancieros,T1.MarcoLegal,T1.ObjetoTransferencia," +
                                  "T1.TrabajosEncargados,T1.OrganismoContralor,T1.ResultadoEvaluacion,T1.CertificadoAntecedentes," +
                                  "T1.DatosConstitucion, T2.Descripcion, T3.CodTematicaProyecto " +
                                  "FROM Instituciones T1 INNER JOIN parTipoInstitucion T2 ON T1.TipoInstitucion = T2.TipoInstitucion " + 
                                  "INNER JOIN Proyectos T3 on T1.CodInstitucion = T3.CodInstitucion ";
                                  //"WHERE T1.IndVigencia = 'V' ";
            if (chklist001.Visible && chklist001.SelectedValue == "C")
                sParametrosConsulta += "WHERE T1.IndVigencia = 'C' ";
            else
                sParametrosConsulta += "WHERE T1.IndVigencia = 'V' ";
        }
        else
        {
            sParametrosConsulta = "SELECT top 201 T1.CodInstitucion,T1.TipoInstitucion,T1.codSistemaAdministrativo,T1.CodComuna,T1.RutInstitucion,T1.Nombre,T1.NombreCorto,T1.Direccion,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.RepresentanteLegal," +
                                  "T1.RutRepresentante,T1.PersonaContacto,T1.FechaAniversario,T1.NombrePrimeraAutoridad," +
                                  "T1.CargoPrimeraAutoridad,T1.NumeroPersonalidadJuridica,T1.ModoInstitucion,T1.DocumentoReconoce," +
                                  "T1.FechaDocumento,T1.IndVigencia,T1.Personeria,T1.RutInterventor,T1.IdAdministrador,T1.FechaActualizacion," +
                                  "T1.IdUsuarioActualizacion,T1.ObjetoSocial,T1.TipoReconocimiento,T1.Vigencia,T1.CodAreaEspecializacion," +
                                  "T1.Directorio,T1.MiembrosDirectorio,T1.AntecedentesFinancieros,T1.MarcoLegal,T1.ObjetoTransferencia," +
                                  "T1.TrabajosEncargados,T1.OrganismoContralor,T1.ResultadoEvaluacion,T1.CertificadoAntecedentes," +
                                  "T1.DatosConstitucion, T2.Descripcion, T3.CodTematicaProyecto " +
                                  "FROM Instituciones T1 INNER JOIN parTipoInstitucion T2 ON T1.TipoInstitucion = T2.TipoInstitucion " +
                                  "INNER JOIN PROYECTOS T3 ON T1.CodInstitucion = T3.CODINSTITUCION INNER JOIN TrabajadorProyecto T4 ON T3.CodProyecto = T4.CodProyecto " +
                                  "INNER JOIN USUARIOS T5 ON T5.ICodTrabajador = T4.ICodTrabajador ";
                                  //"WHERE T1.IndVigencia = 'V' and T5.idUsuario =" + Convert.ToInt32(Session["IdUsuario"]) + " ";

            if (chklist001.Visible && chklist001.SelectedValue == "C")
                sParametrosConsulta += "WHERE T1.IndVigencia = 'C' and T5.idUsuario = @pIdUsuario ";
            else
                sParametrosConsulta += "WHERE T1.IndVigencia = 'V' and T5.idUsuario = @pIdUsuario ";

            listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        }
        if (txt001.Text != "" || txt002.Text != "" || txt005.Text != "" || ddown004.SelectedValue != "0")
            sParametrosConsulta = sParametrosConsulta + "And ";
        if (txt001.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.CodInstitucion = @pCodInstitucion And";

            listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
        }
        if (txt005.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.Nombre like @pNombre And";

            listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt005.Text + "%"));
        }
        //if (txt002.Text != "")
        //{
        //    sParametrosConsulta = sParametrosConsulta + " T1.RutInstitucion = @pRutInstitucion'" + txt002.Text.Replace(".", "").ToString() + "' And";

        //    listDbParameter.Add(con.parametros("@pRutInstitucion", SqlDbType.VarChar, 11, txt002.Text));
        //}
        if (txt002.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.RutInstitucion = @pRutInstitucion And";

            listDbParameter.Add(con.parametros("@pRutInstitucion", SqlDbType.VarChar, 11, txt002.Text.Replace(".", "").ToString()));
        }
        //if (txt006.Text != "")
        //{
        //    sParametrosConsulta = sParametrosConsulta + " T1.RutTrabajador =@pRutTrabajador And";
        //    listDbParameter.Add(con.parametros("@pRutTrabajador", SqlDbType.VarChar, 11, txt006.Text.Replace(".", "").ToString()));
        //}
        if (ddown004.SelectedValue != "0")
        {
            sParametrosConsulta = sParametrosConsulta + " T1.TipoInstitucion = @pTipoInstitucion And";

            listDbParameter.Add(con.parametros("@pTipoInstitucion", SqlDbType.Int, 4, Convert.ToInt32(ddown004.SelectedValue)));
        }
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);

        buscador_institucion bsc_inst = new buscador_institucion();
        DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, vsParametro);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            ////lbl0013.Visible = true;
            ////lbl0014.Visible = true;
            ////lbl0015.Visible = true;
            ////lbl0014.Text = "Coincidencias";
            ////lbl0013.Text = Convert.ToString(dt.Rows.Count);

            ////DtBusqueda = dt;
            ////botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
        else if (dt.Rows.Count == 0)
        {
            //lbl0013.Visible = true;
            //lbl0014.Visible = true;
            //lbl0015.Visible = false;
            //lbl0014.Text = "Coincidencias";
            //lbl0013.Text = Convert.ToString(dt.Rows.Count);
            //botonver2();
            DtBusqueda = dt;
            CargaGrilla();
        }
         else if (dt.Rows.Count >= 200)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";        
        }
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown008_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Function_Genera_String_Consulta(SParametrosConsultas, vsParametro);
    }
    protected void grd001_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "NuevaRelacion")
        {
            if (vsParametro == "Registro de Inmuebles-Proyecto")
            {
                string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                string cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                vCodPaso = Convert.ToInt32(cod);
                vCodPaso2 = Convert.ToInt32(cod2);

                //Response.Write("<script language='JavaScript'>var url = 'reg_inmueblesproy.aspx?sw=5&codInmueble=" + vCodPaso + "&codinst=" + vCodPaso2 + "';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");


                string url = "reg_inmueblesproy.aspx?sw=5&codInmueble=" + vCodPaso + "&codinst=" + vCodPaso2;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);
            }
        }
       if(e.CommandName == "V")
        {

            if (vsParametro == "Registro de Eventos-Proyecto")
            {
                string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;
                vCodPaso = Convert.ToInt32(cod);
                //Response.Write("<script language='JavaScript'>var url = 'reg_eventosproy.aspx?sw=1';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");

                string url = "reg_eventosproy.aspx?sw=1";
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);

            } 
            if (vsParametro == "Proyectos")
            {
                string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                string cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[14].Text;
                vCodPaso = Convert.ToInt32(cod);
                vCodPaso2 = Convert.ToInt32(cod2);
                //Response.Write("<script language='JavaScript'>var url = '../mod_proyectos/proyectoreferente.aspx?sw=1';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");

                string url = "../mod_proyectos/proyectoreferente.aspx?sw=1";
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);

            }
            if (vsParametro == "Busca Proyectos")
            {
                string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                vCodPaso = Convert.ToInt32(cod);
                string CodInst = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                vCodInstPaso = Convert.ToInt32(CodInst);

                string url = vsdir + "?sw=4&codinst=" + cod + "&codproy=" + CodInst;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);                
            } 

            if (vsParametro == "Registro de Inmuebles-Proyecto")
                    {
                        string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                        string cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                        vCodPaso = Convert.ToInt32(cod);
                        vCodPaso2 = Convert.ToInt32(cod2);
                        //Response.Write("<script language='JavaScript'>var url = 'reg_inmueblesproy.aspx?sw=1';");
                        //Response.Write("window.opener.location = url;");
                        //Response.Write("self.close();");
                        //Response.Write("</script>");

                        string url = "reg_inmueblesproy.aspx?sw=1";
                        ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);

                       
                                                            
                     } 
           if (vsParametro == "Instituciones")
                    {
                        if (vsBuscaEspecifica != null)
                        {
                            vsBuscaEspecifica = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                            
                            //Response.Write("<script language='JavaScript'>var url = 'reg_inmuebles.aspx?sw=1';");
                            //Response.Write("window.opener.location = url;");
                            //Response.Write("self.close();");
                            //Response.Write("</script>");

                            string url = "reg_inmuebles.aspx?sw=1";
                            ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);
                           
                        }
                        else
                        {
                            string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                            vCodPaso = Convert.ToInt32(cod);
                            
                            //Response.Write("<script language='JavaScript'>var url = 'reg_instituciones.aspx?sw=1';");
                            //Response.Write("window.opener.location = url;");
                            //Response.Write("self.close();");
                            //Response.Write("</script>");

                            string url = "reg_instituciones.aspx?sw=1";
                            ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);
                        
                        }
                                                            
                     }
            if (vsParametro == "Registro de Inmuebles")
                     {
                         string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                         vCodPaso = Convert.ToInt32(cod);
                         //Response.Write("<script language='JavaScript'>var url = 'reg_inmuebles.aspx?sw=1';");
                         //Response.Write("window.opener.location = url;");
                         //Response.Write("self.close();");
                         //Response.Write("</script>");

                         string url = "reg_inmuebles.aspx?sw=1";
                         ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);

                     }
                     if (vsParametro == "Plan de Intervencion")
                     {
                         string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                         //Response.Write("<script language='JavaScript'>var url = '" + vsdir + "?sw=3&codinst=" + cod + "';");
                         //Response.Write("window.opener.location = url;");
                         //Response.Write("self.close();");
                         //Response.Write("</script>");

                         string url = vsdir + "?sw=3&codinst=" + cod;
                         ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);                       
                     }
        }
    }

    protected void grd002_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Relacionar")
        {
            if (vsParametro == "Registro de Trabajadores-Proyecto")
            {
                string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                string cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                string codinstitucion = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                vCodPaso = Convert.ToInt32(cod);
                vCodPaso2 = Convert.ToInt32(cod2);
                //Response.Write("<script language='JavaScript'>var url = 'reg_trabajadoresproy.aspx?sw=5&codtrab=" + vCodPaso + "&codinst=" + vCodPaso2 +"&codinstitucion="+codinstitucion+"';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");

                string url = "reg_trabajadoresproy.aspx?sw=5&codtrab=" + vCodPaso + "&codinst=" + vCodPaso2 + "&codinstitucion=" + codinstitucion;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);  

            }
        }

        if (e.CommandName == "V")
        {
            if (vsParametro == "Registro de Trabajadores-Proyecto")
            {
                string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                string cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
                vCodPaso = Convert.ToInt32(cod);
                vCodPaso2 = Convert.ToInt32(cod2);
                //Response.Write("<script language='JavaScript'>var url = 'reg_trabajadoresproy.aspx?sw=1';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");

                string url = "reg_trabajadoresproy.aspx?sw=1";
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);
               }
               else if (vsParametro == "Registro de Trabajadores")
               {
                   string cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                   vCodPaso = Convert.ToInt32(cod);
                   //Response.Write("<script language='JavaScript'>var url = 'reg_trabajadores.aspx?sw=1';");
                   //Response.Write("window.opener.location = url;");
                   //Response.Write("self.close();");
                   //Response.Write("</script>");

                   string url = "reg_trabajadores.aspx?sw=1";
                   ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);
               }
        }
    }

    private void CargaGrilla()
    {
        lbl0014.Visible = false;
        btnBuscar.Visible = false;
        DataTable dt = DtBusqueda;
        if (vsParametro == "Registro de Inmuebles-Proyecto")
        {
            grd001.Columns[0].Visible = true;
            grd001.Columns[1].Visible = false;
            grd001.Columns[2].Visible = false;
            grd001.Columns[3].Visible = true;
            grd001.Columns[4].Visible = true;
            grd001.Columns[5].Visible = false;
            grd001.Columns[6].Visible = true;
            grd001.Columns[7].Visible = false;
            grd001.Columns[8].Visible = true;
            grd001.Columns[15].Visible = true;
            grd001.Columns[16].Visible = true;
            grd001.Columns[18].Visible = true;

            grd001.Visible = true;

            DataView dv = new DataView(dt);
            
            grd001.DataSource = dv;
            grd001.DataBind();
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                if (grd001.Rows[i].Cells[6].Text == "0")
                {
                    grd001.Rows[i].Cells[17].Enabled = false;

                }
                else
                {
                    grd001.Rows[i].Cells[18].Enabled = false;
                }
                if (grd001.Rows[i].Cells[15].Text == "0" && grd001.Rows[i].Cells[16].Text == "0")
                {
                    grd001.Rows[i].Cells[17].Enabled = false;
                    grd001.Rows[i].Cells[18].Enabled = false;
                }
            }
            pnl001.Visible = false;
        }
        else if (vsParametro == "Registro de Trabajadores-Proyecto")
        {
            grd002.Columns[6].Visible = true;
            grd002.Columns[5].Visible = true;
            grd002.Columns[7].Visible = true;
            grd002.Columns[8].Visible = true;
            grd002.Columns[11].Visible = true;
            grd002.Columns[9].Visible = true;
            grd002.Visible = true;

            DataView dv = new DataView(dt);
            dv.Sort = "IcodTrabajador Desc,Paterno ASC";
            grd002.DataSource = dv;
            grd002.DataBind();

            for (int i = 0; i < grd002.Rows.Count; i++)
            {
                if (grd002.Rows[i].Cells[6].Text == "0")
                {
                    grd002.Rows[i].Cells[11].Enabled = true;
                    grd002.Rows[i].Cells[10].Enabled = false;
                }
                else
                {
                    grd002.Rows[i].Cells[10].Enabled = true;
                    grd002.Rows[i].Cells[11].Enabled = true;
                }
            }

            pnl001.Visible = false;
        }
        else if (vsParametro == "Registro de Trabajadores")
        {
            grd002.Visible = true;
            grd002.Columns[8].Visible = true;
            DataView dv = new DataView(dt);
            grd002.DataSource = dv;
            grd002.DataBind();
            pnl001.Visible = false;
        }
        else if (vsParametro == "Instituciones"||vsParametro == "Plan de Intervencion")
        {
            grd001.Columns[8].Visible = false;
            grd001.Visible = true;
            DataView dv = new DataView(dt);
            dv.Sort = "Nombre";
            grd001.DataSource = dv;
            grd001.DataBind();
            pnl001.Visible = false;
        }
        else  if (vsParametro == "Registro de Inmuebles")
        {
            grd001.Columns[1].Visible = false;
            grd001.Columns[2].Visible = false;
            grd001.Columns[4].Visible = true;
            grd001.Columns[5].Visible = true;
            grd001.Columns[8].Visible = false;
            grd001.Columns[12].Visible = true;
            grd001.Visible = true;
            DataView dv = new DataView(dt);
            grd001.DataSource = dv;
            grd001.DataBind();
            pnl001.Visible = false;
        }
        else if (vsParametro =="Busca Proyectos" )
        {
            grd001.Columns[1].Visible = false;
            grd001.Columns[2].Visible = false;
            grd001.Columns[4].Visible = false;
            grd001.Columns[5].Visible = false;
            grd001.Columns[6].Visible = true;
            grd001.Columns[7].Visible = true;
            grd001.Columns[8].Visible = false;
            grd001.Columns[14].Visible = true;
           
            grd001.Visible = true;
            DataView dv = new DataView(dt);
            grd001.DataSource = dv;
            grd001.DataBind();
            pnl001.Visible = false;
        }
        else if (vsParametro == "Proyectos" )
        {
            grd001.Columns[1].Visible = false;
            grd001.Columns[2].Visible = false;
            grd001.Columns[4].Visible = false;
            grd001.Columns[5].Visible = false;
            grd001.Columns[6].Visible = true;
            grd001.Columns[7].Visible = true;
            grd001.Columns[8].Visible = false;
            grd001.Columns[13].Visible = true;
            grd001.Columns[13].HeaderText = "Sistema Asistencial";
            grd001.Columns[14].Visible = true;
            grd001.Columns[14].HeaderText = "Cod. Sistema Asistencial";
            grd001.Columns[15].Visible = true;
            grd001.Columns[15].HeaderText = "Modelo Intervención";

            grd001.Visible = true;
            DataView dv = new DataView(dt);
            grd001.DataSource = dv;
            grd001.DataBind();
            pnl001.Visible = false;
        }
        else if (vsParametro == "Registro de Eventos-Proyecto")
        {
            grd001.Columns[0].Visible = false;
            grd001.Columns[1].Visible = false;
            grd001.Columns[2].Visible = false;
            grd001.Columns[3].Visible = false;
            grd001.Columns[4].Visible = false;
            grd001.Columns[5].Visible = false;
            grd001.Columns[6].Visible = true;
            grd001.Columns[7].Visible = false;
            grd001.Columns[8].Visible = false;
            grd001.Columns[9].Visible = true;
            grd001.Columns[10].Visible = true;
            grd001.Columns[11].Visible = true;
            grd001.Columns[13].Visible = true;
            grd001.Visible = true;
            DataView dv = new DataView(dt);
            grd001.DataSource = dv;
            grd001.DataBind();
            pnl001.Visible = false;
        }

        if (grd001.Rows.Count == 0)
        {
            alertSinRegistros.Visible = true;
            btnLimpiar.Text = "<span class='glyphicon glyphicon-arrow-left'></span>&nbsp;Volver";
        }

        if (grd002.Rows.Count == 0)
        {
            alertSinRegistros.Visible = true;
            btnLimpiar.Text = "<span class='glyphicon glyphicon-arrow-left'></span>&nbsp;Volver";
        }

        if (grd001.Rows.Count > 0 || grd002.Rows.Count > 0)
        {
            alertSinRegistros.Visible = false;
            btnLimpiar.Text = "<span class='glyphicon glyphicon-arrow-left'></span>&nbsp;Volver";
        }
    }

    protected void grd002_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd002.PageIndex = e.NewPageIndex;
        CargaGrilla();
    }

    private void botonver2(){
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        btnBuscar.Visible = false;
        Response.Write("<script language='JavaScript'>");
        Response.Write("window.resizeTo(770,420)");
        Response.Write("</script>");
        CargaGrilla();
     }   

    protected void lnkbtnver_Click(object sender, EventArgs e)
    {
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        btnBuscar.Visible = false;
        Response.Write("<script language='JavaScript'>");
        Response.Write("window.resizeTo(770,420)");
        Response.Write("</script>");
        CargaGrilla();
    }

    private void gettipoevento()
    {
        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparTipoEvento("", null));
        ddown006.DataSource = dv6;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "TipoEventos";
        dv6.Sort = "TipoEventos";
        ddown006.DataBind();
    }

    private void gettipoinstitucion()
    {
        institucioncoll par = new institucioncoll();
        DataView dv6 = new DataView(par.GetparTipoInstitucion());
        ddown004.DataSource = dv6;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "TipoInstitucion";
        dv6.Sort = "TipoInstitucion";
        ddown004.DataBind();
    }

    private void gettipoinmueble()
    {
        inmueblecoll icoll = new inmueblecoll();
        DataTable dtproy = icoll.GetparTipoInmueble();
        ddown005.DataSource = dtproy;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "TipoInmueble";
        ddown005.DataBind();
    }

    private void gettipoproyecto()
    {
        parcoll par = new parcoll();
        DataTable dtproy = par.GetparTipoProyecto();
        ddown002.DataSource = dtproy;
        ddown002.DataTextField = "Descripcion";
        ddown002.DataValueField = "TipoProyecto";
        ddown002.DataBind();
    }

    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown003.DataSource = dv1;
        ddown003.DataTextField = "Nombre";
        ddown003.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        DataBind();
    }

    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla();
    }
    //protected void imb003_Click(object sender, EventArgs e)
    //{
    //    window.close(this.Page);
    //}
    //protected void imb002_Click(object sender, EventArgs e)
    //{
    //    txt001.Text = "";
    //    txt001.Text = "";
    //    txt002.Text = "";
    //    txt003.Text = "";
    //    txt004.Text = "";
    //    txt005.Text = "";
    //    txt006.Text = "";
    //    txt007.Text = "";
    //    txt009.Text = "";
    //    txt0010.Text = "";
    //    txt0011.Text = "";
    //    txt0012.Text = "";
    //    ddown002.SelectedIndex = 0;
    //    ddown004.SelectedIndex = 0;
    //    ddown005.SelectedIndex = 0;
    //    grd001.Columns.Clear();
    //    grd002.Columns.Clear();
    //    grd001.Visible = false;
    //    grd002.Visible = false;
    //    pnl001.Visible = true;
    //    btnBuscar.Visible = true;
    //    lbl0013.Visible = false;
    //    lbl0014.Visible = false;
    //    lbl0015.Visible = false;
    //    Response.Write("<script language='JavaScript'>");
    //    Response.Write("window.resizeTo(770,420)");
    //    Response.Write("</script>");
        
        
    //}
    
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt001.Text=ddown003.SelectedValue;
    }
    protected void grd001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    /*-----------------------------------------------------------------------------------------
    // 23/12/2014
    // Se agregan las siguientes VOID que reemplazarán a los originales que se encuentran 
    // asociados a Infragistics.
    //---------------------------------------------------------------------------------------*/
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (txt0012.Text.Trim() != "")
        {
            proyecto proyec = new proyecto();
            SSproyecto.codproyecto_coincidente = Convert.ToInt32(txt0012.Text);
        }
        Function_Genera_String_Consulta(SParametrosConsultas, vsParametro);
    }
    protected void btnLimpiaBusqueda_Click(object sender, EventArgs e)
    {
        btnBuscar.Visible = true;
        txt001.Text = "";
        txt001.Text = "";
        txt002.Text = "";
        txt003.Text = "";
        txt004.Text = "";
        txt005.Text = "";
        txt006.Text = "";
        txt007.Text = "";
        txt009.Text = "";
        txt0010.Text = "";
        txt0011.Text = "";
        txt0012.Text = "";
        //ddown003.Visible = false;//gfontbrevis
        ddown003.Enabled = false;//gfontbrevis

        ddown002.SelectedIndex = 0;
        ddown004.SelectedIndex = 0;
        ddown005.SelectedIndex = 0;
        grd001.DataSource = null;
        grd001.DataBind();
        grd002.DataSource = null;
        grd002.DataBind();
        grd001.Visible = false;
        grd002.Visible = false;
        pnl001.Visible = true;
        btnBuscar.Visible = true;
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        alertSinRegistros.Visible = false;
        btnLimpiar.Text = "<span class='glyphicon glyphicon-remove-sign'></span>&nbsp;Limpiar";
        
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //window.close(this.Page);
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarModalPopUp();", true);      
    }
    protected void ImageButton1_Click1(object sender, EventArgs e)
    {

        if (txt001.Text != "")
        {
            ListItem val = ddown003.Items.FindByValue(txt001.Text);
            if (val != null)
            {
                ddown003.SelectedValue = txt001.Text;
                //ddown003.Visible = true;//gfontbrevis
                ddown003.Enabled = true;
            }
        }

    }
}
