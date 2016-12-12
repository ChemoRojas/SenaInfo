using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;

using System.Collections.Generic;

////////using neocsharp.NeoDatabase;
/// <summary>
/// Descripción breve de buscador_institucion
/// </summary>
public class buscador_institucion
{
	public buscador_institucion()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable Get_Resultado_Busqueda(string sParametrosConsulta, List<DbParameter> listDbParameter, string TipoBusqueda)
    {
        if (TipoBusqueda == "Registro de Eventos-Proyecto")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("ICodEventosProyectos", typeof(int)));
            dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            dt.Columns.Add(new DataColumn("TipoEventos", typeof(String)));
            dt.Columns.Add(new DataColumn("FechaEvento", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));


            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["ICodEventosProyectos"];
                    dr[1] = (int)datareader["CodProyecto"];
                    dr[2] = (String)datareader["Descripcion"];
                    string evento = getnombretipoevento((int)datareader["TipoEventos"]);
                    dr[3] = evento;
                    dr[4] = (DateTime)datareader["FechaEvento"];
                    dr[5] = (int)datareader["CodTematicaProyecto"];

                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }
        else if (TipoBusqueda == "Registro de Inmuebles-Proyecto")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("ICodInmueble", typeof(int)));
            dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
            dt.Columns.Add(new DataColumn("NombreProyecto", typeof(String)));
            dt.Columns.Add(new DataColumn("VigenciaInmueble", typeof(String)));
            dt.Columns.Add(new DataColumn("VigenciaRelacion", typeof(String)));
            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));

            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    try
                    {
                        dr[0] = (int)datareader["ICodInmueble"];
                    }
                    catch
                    {
                        dr[0] = 0;
                    }
                    try
                    {
                        dr[1] = (int)datareader["CodProyecto"];
                    }
                    catch
                    {
                        dr[1] = 0;
                    }
                    dr[2] = (String)datareader["Nombre"];
                    try
                    {
                        dr[3] = (String)datareader["NombreProyecto"];
                    }
                    catch
                    {
                        dr[3] = "";
                    }
                    try
                    {
                        dr[4] = (String)datareader["VigenciaInmueble"];
                    }
                    catch
                    {
                        dr[4] = "";
                    }
                    try
                    {
                        dr[5] = (String)datareader["VigenciaRelacion"];
                    }
                    catch
                    {
                        dr[5] = "";
                    }
                    dr[6] = (int)datareader["CodInstitucion"];
                    dr[7] = (int)datareader["CodTematicaProyecto"];
                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }
        else if (TipoBusqueda == "Registro de Trabajadores-Proyecto")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("IcodTrabajador", typeof(int)));
            dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
            dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
            dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
            dt.Columns.Add(new DataColumn("Materno", typeof(String)));
            dt.Columns.Add(new DataColumn("VigRelacionProy", typeof(String)));
            dt.Columns.Add(new DataColumn("VigenciaTrabajador", typeof(String)));
            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("RutTrabajador", typeof(String)));
            dt.Columns.Add(new DataColumn("Institucion", typeof(String)));

            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    try
                    {
                        dr[0] = (int)datareader["IcodTrabajador"];
                    }
                    catch
                    {
                        dr[0] = 0;
                    }
                    try
                    {
                        dr[1] = (int)datareader["CodProyecto"];
                    }
                    catch
                    {
                        dr[1] = 0;
                    }

                    dr[2] = (String)datareader["Nombres"];
                    dr[3] = (String)datareader["Paterno"];
                    dr[4] = (String)datareader["Materno"];
                    try
                    {
                        dr[5] = (String)datareader["VigRelacionProy"];
                    }
                    catch
                    {
                        dr[5] = "";
                    }
                    dr[6] = (String)datareader["VigenciaTrabajador"];
                    dr[7] = (int)datareader["CodInstitucion"];
                    dr[8] = (String)datareader["RutTrabajador"];
                    dr[9] = (String)datareader["Institucion"];
                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }

        else if (TipoBusqueda == "Busca Proyectos")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("TipoProyecto", typeof(String)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
            dt.Columns.Add(new DataColumn("CodSistemaAsistencial", typeof(int)));
            dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));



            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodProyecto"];
                    dr[1] = (int)datareader["CodInstitucion"];
                    dr[2] = (String)datareader["TipoProyecto"];
                    dr[3] = (String)datareader["Nombre"];
                    dr[4] = (int)datareader["CodSistemaAsistencial"];
                    dr[5] = (int)datareader["CodTematicaProyecto"];

                    dt.Rows.Add(dr);

                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }
        else if (TipoBusqueda == "Proyectos")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("TipoProyecto", typeof(String)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
            dt.Columns.Add(new DataColumn("CodSistemaAsistencial", typeof(int)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            dt.Columns.Add(new DataColumn("VigenciaInmueble", typeof(String)));
            dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));


            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodProyecto"];
                    dr[1] = (int)datareader["CodInstitucion"];
                    dr[2] = (String)datareader["TipoProyecto"];
                    dr[3] = (String)datareader["Nombre"];
                    dr[4] = (int)datareader["CodSistemaAsistencial"];
                    dr[5] = (String)datareader["Descripcion"];
                    dr[6] = (String)datareader["VigenciaInmueble"];
                    dr[7] = (int)datareader["CodTematicaProyecto"];
                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }
        else if (TipoBusqueda == "Registro de Inmuebles")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("ICodInmueble", typeof(int)));
            dt.Columns.Add(new DataColumn("DesTipoInmueble", typeof(String)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
            dt.Columns.Add(new DataColumn("DesCodSituacionLegal", typeof(String)));
            dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));

            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodInstitucion"];
                    dr[1] = (int)datareader["ICodInmueble"];
                    dr[2] = (String)datareader["DesTipoInmueble"];
                    dr[3] = (String)datareader["Nombre"];
                    dr[4] = (String)datareader["DesCodSituacionLegal"];
                    dr[5] = 0;

                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }
        else if (TipoBusqueda == "Registro de Trabajadores")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("Paterno", typeof(String)));
            dt.Columns.Add(new DataColumn("Materno", typeof(String)));
            dt.Columns.Add(new DataColumn("Nombres", typeof(String)));
            dt.Columns.Add(new DataColumn("RutTrabajador", typeof(String)));
            dt.Columns.Add(new DataColumn("VigenciaTrabajador", typeof(String)));

            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["ICodTrabajador"];
                    dr[1] = (int)datareader["CodInstitucion"];
                    dr[2] = (String)datareader["Paterno"];
                    dr[3] = (String)datareader["Materno"];
                    dr[4] = (String)datareader["Nombres"];
                    dr[5] = (String)datareader["RutTrabajador"];
                    dr[6] = (String)datareader["VigenciaTrabajador"];
                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }

        else if (TipoBusqueda == "Instituciones" || TipoBusqueda == "Plan de Intervencion")
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            con.ejecutar(sParametrosConsulta, listDbParameter, out datareader);
            DataTable dt = new DataTable();


            DataRow dr;

            dt.Columns.Add(new DataColumn("CodInstitucion", typeof(int)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            dt.Columns.Add(new DataColumn("RutInstitucion", typeof(String)));
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
            dt.Columns.Add(new DataColumn("CodTematicaProyecto", typeof(int)));

            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["CodInstitucion"];
                    dr[1] = (String)datareader["Descripcion"];
                    dr[2] = (String)datareader["RutInstitucion"];
                    dr[3] = (String)datareader["Nombre"];
                    dr[4] = (int)datareader["CodTematicaProyecto"];
                    dt.Rows.Add(dr);


                }
                catch { }
            }
            con.Desconectar();
            return dt;
        }
        else
        {
            return null;
        }
    }
    private string getnombretipoevento(int tipoevento)
    {

            string evento="";
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */
            Conexiones con = new Conexiones();
            string sParametrosConsulta = " Select TipoEventos,Descripcion,IndVigencia From parTipoEventos  "+
                                         "Where IndVigencia = 'V' and TipoEventos ="+tipoevento;
            con.ejecutar(sParametrosConsulta, out datareader);
            DataTable dt = new DataTable();
            
           
            DataRow dr;
            dt.Columns.Add(new DataColumn("Descripcion", typeof(String)));
            while (datareader.Read())
            {
                try
                {
                    dr = dt.NewRow();
                    evento = (String)datareader["Descripcion"];
                    dt.Rows.Add(dr);
                }
                catch { }
            }
            con.Desconectar();
            return evento;
        }

    public int GetCodInstxCodProy(int CodProyecto)
    {
        int codinstitucion = 0;
        DbDataReader datareader = null;
        
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetCodInstxCodProy + CodProyecto, out datareader);
        while (datareader.Read())
        {
            try
            {
               codinstitucion = (int)datareader["CodInstitucion"];
            }
            catch { }
        }
        con.Desconectar();
        return codinstitucion;

    }
    public int GetCodRegionxCodProy(int CodProyecto)
    {
        int CodRegion = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetCodRegionxCodProy + CodProyecto, out datareader);
        while (datareader.Read())
        {
            try
            {
                CodRegion = (int)datareader["CodRegion"];
            }
            catch { }
        }
        con.Desconectar();
        return CodRegion;

    }
    
}
